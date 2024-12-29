using Microsoft.VisualBasic.FileIO;
using System.Security.Cryptography;

namespace Stronghold.Forms
{
    public partial class DuplicateFiles : Form
    {
        public DuplicateFiles()
        {
            InitializeComponent();
        }

        static string folderPath = "";

        /// collection of unique files hash
        List<DuplicateFileModel> filesHash = new List<DuplicateFileModel>();

        long TotalPotentialSpace = 0;
        int FilesProcessed = 0;


        private void DuplicateFiles_Load(object sender, EventArgs e)
        {
            filesHash = new List<DuplicateFileModel>();
            TotalPotentialSpace = 0;
            FilesProcessed = 0;
            DeleteForever.Enabled = false;
            BrowseBtn.Enabled = true;
            SartScanBtn.Enabled = false;
            StopBtn.Enabled = false;
            ScanNested.Enabled = true;
            SendToRecycleBin.Enabled = false;
            DeleteForever.Enabled = false;
            filesHash = new List<DuplicateFileModel>();
        }


        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog diag = new FolderBrowserDialog())
            {
                var res = diag.ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (Directory.Exists(diag.SelectedPath))
                    {
                        folderPath = diag.SelectedPath;
                        DuplicatFilesList.Items.Clear();
                        StopBtn.Enabled = false;
                        SendToRecycleBin.Enabled = false;
                        DeleteForever.Enabled = false;
                        SartScanBtn.Enabled = true;
                        ScanNested.Enabled = true;
                        FolderPathLbl.Text = "Folder Path: " + folderPath;
                        TotalFilesScanned.Text = "Status: ";
                        ScannedPath.Text = "File: ";
                        return;
                    }
                }
            }

            FolderPathLbl.Text = "Folder Path:";
            folderPath = "";
            ScannedPath.Text = "File: ";
            TotalFilesScanned.Text = "Status: ";
        }

        private void SartScanBtn_Click(object sender, EventArgs e)
        {
            if (folderPath == "")
            {
                MessageBox.Show("Please select a folder to scan");
                return;
            }

            filesHash = new List<DuplicateFileModel>();
            TotalPotentialSpace = 0;
            FilesProcessed = 0;
            DuplicatFilesList.Items.Clear();
            ScanNested.Enabled = false;
            BrowseBtn.Enabled = false;
            SendToRecycleBin.Enabled = false;
            DeleteForever.Enabled = false;
            StopBtn.Enabled = true;
            backgroundScanner.RunWorkerAsync();
        }

        async Task<bool> StartScan()
        {
            FilesProcessed = 0;
            var task = Task.Run(() => ScanNestedFolders(folderPath, ScanNested.Checked));
            task.Wait();
            return await Task.FromResult(true);
        }

        /// /// scan nested files, and folders

        async Task ScanNestedFolders(string path, bool nestedFolders)
        {
            if (backgroundScanner.CancellationPending == true) return;

            try
            {
                //updateContent(ScannedFolderName, $"Directory: {Path.GetDirectoryName(path)}");
                var files = Directory.GetFiles(path);
                foreach (var fileName in files)
                {
                    if (File.Exists(fileName))
                    {
                        //exit if canceledshore
                        if (backgroundScanner.CancellationPending == true)
                            break;

                        FileInfo fileLen = new FileInfo(fileName);

                        ///skip zero kb files
                        if (fileLen.Length == 0)
                        {
                            continue;
                        }

                        ScannedPath.Invoke(new Action(() => { ScannedPath.Text = "File: " + Path.GetFileName(fileName); }));

                        string FileHash = await CompareHash(fileName);

                        var foundDup = filesHash.Where(e => e.fileHash == FileHash).FirstOrDefault();

                        /// file was duplicate
                        if (foundDup != null)
                        {

                            // add files to checkbox
                            DuplicatFilesList.Invoke(new Action(() =>
                            {
                                string fileInfo = $"{fileName} | Duplicate with: {foundDup.fileUrl} | avg: {FormatSize(fileLen.Length)}";
                                DuplicatFilesList.Items.Add(fileInfo, false);
                            }));

                            TotalPotentialSpace += fileLen.Length;  //potential size saving
                        }
                        else
                        {
                            // if not a duplicate.
                            var fileObj = new DuplicateFileModel()
                            {
                                fileUrl = fileName,
                                fileName = Path.GetFileName(fileName),
                                fileSize = fileLen.Length,
                                fileHash = FileHash
                            };

                            filesHash.Add(fileObj);
                        }

                        FilesProcessed++;

                        TotalFilesScanned.Invoke(new Action(() =>
                        {
                            TotalFilesScanned.Text = $"Status: Total Files Scanned: {FilesProcessed} Files | Duplicates Found: {DuplicatFilesList.Items.Count} Files | Avg Size: {FormatSize(TotalPotentialSpace)}";
                            TotalFilesScanned.Update();
                        }));

                    }
                }

                if (backgroundScanner.CancellationPending == true) return;

                if (nestedFolders)
                {
                    //// recursion
                    List<string> directories = Directory.GetDirectories(path).ToList();
                    foreach (var dirct in directories)
                    {
                        if (Directory.Exists(dirct))
                        {
                            if (backgroundScanner.CancellationPending == true) break;
                            await ScanNestedFolders(dirct, nestedFolders);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
        }

        async Task<string> CompareHash(string fileName)
        {
            /// calc file hash,
            using (SHA256 SHA256 = SHA256.Create())
            {
                using (FileStream fileStream = File.OpenRead(fileName))
                {
                    string fileHash = Convert.ToBase64String(SHA256.ComputeHash(fileStream));

                    return await Task.FromResult(fileHash);
                }
            }

        }

        string FormatSize(long bytes)
        {
            // Load all suffixes in an array  
            string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
            int counter = 0;
            decimal number = bytes;
            while (Math.Round(number / 1024) >= 1 && counter < 5)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }

        private void backgroundScanner_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (backgroundScanner.CancellationPending == true)
            {
                e.Cancel = true;
            }

            bool stats = StartScan().GetAwaiter().GetResult();

            /// exit, then finished job

            if (DuplicatFilesList.Items.Count > 0)
            {
                SendToRecycleBin.Invoke(new Action(() => { SendToRecycleBin.Enabled = true; }));
                DeleteForever.Invoke(new Action(() => { DeleteForever.Enabled = true; }));
            }

            BrowseBtn.Invoke(new Action(() => { BrowseBtn.Enabled = true; }));
            SartScanBtn.Invoke(new Action(() => { SartScanBtn.Enabled = false; }));
            StopBtn.Invoke(new Action(() => { StopBtn.Enabled = false; }));

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to stop scanning task? ?", "Confirm:", MessageBoxButtons.YesNo);

            if (res == DialogResult.No)
            {
                return;
            }
            else
            {
                backgroundScanner.CancelAsync();

                //MessageBox.Show("Find duplicate job has stopped, you can delete the duplicate files, or start a new scan.");

                BrowseBtn.Enabled = true;
                SartScanBtn.Enabled = false;

                if (DuplicatFilesList.Items.Count > 0)
                {
                    SendToRecycleBin.Enabled = true;
                    DeleteForever.Enabled = true;
                }

                filesHash = new List<DuplicateFileModel>();
                TotalPotentialSpace = 0;
                FilesProcessed = 0;

                BrowseBtn.Enabled = true;
                SendToRecycleBin.Enabled = true;
                SartScanBtn.Enabled = false;
                StopBtn.Enabled = false;
                ScanNested.Enabled = false;
                FolderPathLbl.Text = "Folder Path: ";
                ScannedPath.Text = "File: ";
                // TotalFilesScanned.Text = "Status: ";
            }

        }

        private void backgroundScanner_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            SendToRecycleBin.Invoke(new Action(() => { SendToRecycleBin.Enabled = true; }));
            BrowseBtn.Invoke(new Action(() => { BrowseBtn.Enabled = true; }));
            SartScanBtn.Invoke(new Action(() => { SartScanBtn.Enabled = false; }));
            StopBtn.Invoke(new Action(() => { StopBtn.Enabled = false; }));
            ScanNested.Invoke(new Action(() => { ScanNested.Enabled = false; }));

            FolderPathLbl.Invoke(new Action(() => { FolderPathLbl.Text = "Folder Path: "; }));
            ScannedPath.Invoke(new Action(() => { ScannedPath.Text = "File: "; }));

            StopBtn.Enabled = false;

            string msg = "Scanning duplicate files has completed, all duplicate files are listed to be deleted, or send to recycle bin";

            MessageBox.Show(msg);
        }

        private void SelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < DuplicatFilesList.Items.Count; i++)
            {
                DuplicatFilesList.SetItemChecked(i, true);
            }
        }

        private void UnselectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < DuplicatFilesList.Items.Count; i++)
            {
                DuplicatFilesList.SetItemChecked(i, false);
            }
        }


        /// show a window with a progress bar... 
        /// too many files, can take up to 5 minutes to move + task manager can take too much memory
        private void DeleteSelectedFilesBtn_Click(object sender, EventArgs e)
        {
            if (DuplicatFilesList.CheckedItems != null)
            {
                if (DuplicatFilesList.CheckedItems.Count > 0)
                {
                    //is somefiles delete errored out

                    bool deleteErr = false;
                    // confirm file deletion? 
                    var itmsToDelete = DuplicatFilesList.CheckedItems;

                    foreach (var itm in itmsToDelete)
                    {
                        string filePath = itm.ToString();
                        filePath = itm.ToString().Split('|')[0].Trim(); /// first txt is file path

                        //move files to recycle bin.
                        if (File.Exists(filePath))
                        {
                            try
                            {
                                FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }
                            catch (Exception)
                            {
                                deleteErr = true;
                                MessageBox.Show($"File: {filePath} was not found or moved.");
                            }
                        }
                    }

                    if (deleteErr == false)
                        MessageBox.Show("File(s) moved to Recycle Bin successfully,");

                    if (deleteErr == true)
                        MessageBox.Show("Operations completed, however, some files were not found or already delete,");


                }
            }
            else
            {
                return;
            }
        }

        private void DeleteFiles_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Confirm File(s) Deletion?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (DuplicatFilesList.CheckedItems != null)
                {
                    if (DuplicatFilesList.CheckedItems.Count > 0)
                    {
                        //is somefiles delete errored out

                        bool deleteErr = false;
                        // confirm file deletion? 
                        var itmsToDelete = DuplicatFilesList.CheckedItems;

                        foreach (var itm in itmsToDelete)
                        {
                            string filePath = itm.ToString();
                            filePath = itm.ToString().Split('|')[0].Trim(); /// first txt is file path

                            //move files to recycle bin.
                            if (File.Exists(filePath))
                            {
                                try
                                {
                                    File.Delete(filePath);
                                }
                                catch (Exception)
                                {
                                    deleteErr = true;
                                }
                            }
                        }

                        if (deleteErr == false)
                            MessageBox.Show("File(s) were deleted successfully,");

                        if (deleteErr == true)
                            MessageBox.Show("Operations completed, however, some files were not found or already delete,");

                    }
                }
                else
                {
                    return;
                }
            }

        }



    }
}
