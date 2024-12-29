namespace Stronghold.Forms
{
    partial class DuplicateFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DuplicatFilesList = new CheckedListBox();
            backgroundScanner = new System.ComponentModel.BackgroundWorker();
            SartScanBtn = new Button();
            StopBtn = new Button();
            SendToRecycleBin = new Button();
            BrowseBtn = new Button();
            FolderPathLbl = new Label();
            label2 = new Label();
            SelectAll = new LinkLabel();
            UnselectAll = new LinkLabel();
            TotalFilesScanned = new Label();
            ScanNested = new CheckBox();
            DeleteForever = new Button();
            ScannedPath = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // DuplicatFilesList
            // 
            DuplicatFilesList.BorderStyle = BorderStyle.FixedSingle;
            DuplicatFilesList.Font = new Font("Segoe UI", 10F);
            DuplicatFilesList.HorizontalScrollbar = true;
            DuplicatFilesList.Location = new Point(25, 290);
            DuplicatFilesList.Margin = new Padding(0);
            DuplicatFilesList.Name = "DuplicatFilesList";
            DuplicatFilesList.ScrollAlwaysVisible = true;
            DuplicatFilesList.Size = new Size(761, 202);
            DuplicatFilesList.TabIndex = 35;
            // 
            // backgroundScanner
            // 
            backgroundScanner.WorkerSupportsCancellation = true;
            backgroundScanner.DoWork += backgroundScanner_DoWork;
            backgroundScanner.RunWorkerCompleted += backgroundScanner_RunWorkerCompleted;
            // 
            // SartScanBtn
            // 
            SartScanBtn.BackColor = Color.White;
            SartScanBtn.FlatStyle = FlatStyle.Flat;
            SartScanBtn.Font = new Font("Segoe UI", 10F);
            SartScanBtn.Location = new Point(697, 522);
            SartScanBtn.Margin = new Padding(3, 2, 3, 2);
            SartScanBtn.Name = "SartScanBtn";
            SartScanBtn.Size = new Size(88, 44);
            SartScanBtn.TabIndex = 36;
            SartScanBtn.Text = "Scan";
            SartScanBtn.UseVisualStyleBackColor = false;
            SartScanBtn.Click += SartScanBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.BackColor = Color.White;
            StopBtn.FlatStyle = FlatStyle.Flat;
            StopBtn.Font = new Font("Segoe UI", 10F);
            StopBtn.Location = new Point(25, 522);
            StopBtn.Margin = new Padding(3, 2, 3, 2);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(88, 44);
            StopBtn.TabIndex = 37;
            StopBtn.Text = "Stop";
            StopBtn.UseVisualStyleBackColor = false;
            StopBtn.Click += StopBtn_Click;
            // 
            // SendToRecycleBin
            // 
            SendToRecycleBin.BackColor = Color.White;
            SendToRecycleBin.FlatStyle = FlatStyle.Flat;
            SendToRecycleBin.Font = new Font("Segoe UI", 10F);
            SendToRecycleBin.Location = new Point(119, 522);
            SendToRecycleBin.Margin = new Padding(3, 2, 3, 2);
            SendToRecycleBin.Name = "SendToRecycleBin";
            SendToRecycleBin.Size = new Size(184, 44);
            SendToRecycleBin.TabIndex = 38;
            SendToRecycleBin.Text = "Send to Recycle bin";
            SendToRecycleBin.UseVisualStyleBackColor = false;
            SendToRecycleBin.Click += DeleteSelectedFilesBtn_Click;
            // 
            // BrowseBtn
            // 
            BrowseBtn.BackColor = Color.White;
            BrowseBtn.FlatStyle = FlatStyle.Flat;
            BrowseBtn.Font = new Font("Segoe UI", 10F);
            BrowseBtn.Location = new Point(658, 68);
            BrowseBtn.Margin = new Padding(3, 2, 3, 2);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new Size(130, 44);
            BrowseBtn.TabIndex = 39;
            BrowseBtn.Text = "Select Folder";
            BrowseBtn.UseVisualStyleBackColor = false;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // FolderPathLbl
            // 
            FolderPathLbl.BackColor = Color.WhiteSmoke;
            FolderPathLbl.FlatStyle = FlatStyle.Flat;
            FolderPathLbl.Font = new Font("Segoe UI", 10F);
            FolderPathLbl.Location = new Point(25, 136);
            FolderPathLbl.Name = "FolderPathLbl";
            FolderPathLbl.Size = new Size(760, 28);
            FolderPathLbl.TabIndex = 52;
            FolderPathLbl.Text = "Folder Path:";
            FolderPathLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(25, 58);
            label2.Name = "label2";
            label2.Size = new Size(760, 69);
            label2.TabIndex = 57;
            // 
            // SelectAll
            // 
            SelectAll.AutoSize = true;
            SelectAll.Font = new Font("Segoe UI", 10F);
            SelectAll.LinkColor = Color.SteelBlue;
            SelectAll.Location = new Point(717, 261);
            SelectAll.Margin = new Padding(4, 0, 4, 0);
            SelectAll.Name = "SelectAll";
            SelectAll.Size = new Size(63, 19);
            SelectAll.TabIndex = 59;
            SelectAll.TabStop = true;
            SelectAll.Text = "Select All";
            SelectAll.LinkClicked += SelectAll_LinkClicked;
            // 
            // UnselectAll
            // 
            UnselectAll.AutoSize = true;
            UnselectAll.Font = new Font("Segoe UI", 10F);
            UnselectAll.LinkColor = Color.SteelBlue;
            UnselectAll.Location = new Point(620, 261);
            UnselectAll.Margin = new Padding(4, 0, 4, 0);
            UnselectAll.Name = "UnselectAll";
            UnselectAll.Size = new Size(80, 19);
            UnselectAll.TabIndex = 60;
            UnselectAll.TabStop = true;
            UnselectAll.Text = "Unselect All";
            UnselectAll.LinkClicked += UnselectAll_LinkClicked;
            // 
            // TotalFilesScanned
            // 
            TotalFilesScanned.BackColor = Color.WhiteSmoke;
            TotalFilesScanned.FlatStyle = FlatStyle.Flat;
            TotalFilesScanned.Font = new Font("Segoe UI", 10F);
            TotalFilesScanned.Location = new Point(25, 175);
            TotalFilesScanned.Name = "TotalFilesScanned";
            TotalFilesScanned.Size = new Size(760, 28);
            TotalFilesScanned.TabIndex = 62;
            TotalFilesScanned.Text = "Status: ";
            TotalFilesScanned.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ScanNested
            // 
            ScanNested.AutoSize = true;
            ScanNested.Checked = true;
            ScanNested.CheckState = CheckState.Checked;
            ScanNested.Font = new Font("Segoe UI", 10F);
            ScanNested.Location = new Point(25, 261);
            ScanNested.Name = "ScanNested";
            ScanNested.Size = new Size(151, 23);
            ScanNested.TabIndex = 63;
            ScanNested.Text = "Scan Nested Folders";
            ScanNested.UseVisualStyleBackColor = true;
            // 
            // DeleteForever
            // 
            DeleteForever.BackColor = Color.White;
            DeleteForever.FlatStyle = FlatStyle.Flat;
            DeleteForever.Font = new Font("Segoe UI", 10F);
            DeleteForever.Location = new Point(308, 522);
            DeleteForever.Margin = new Padding(3, 2, 3, 2);
            DeleteForever.Name = "DeleteForever";
            DeleteForever.Size = new Size(88, 44);
            DeleteForever.TabIndex = 64;
            DeleteForever.Text = "Delete";
            DeleteForever.UseVisualStyleBackColor = false;
            DeleteForever.Click += DeleteFiles_Click;
            // 
            // ScannedPath
            // 
            ScannedPath.BackColor = Color.WhiteSmoke;
            ScannedPath.FlatStyle = FlatStyle.Flat;
            ScannedPath.Font = new Font("Segoe UI", 10F);
            ScannedPath.Location = new Point(25, 215);
            ScannedPath.Name = "ScannedPath";
            ScannedPath.Size = new Size(760, 28);
            ScannedPath.TabIndex = 65;
            ScannedPath.Text = "File:";
            ScannedPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.RoyalBlue;
            label3.Font = new Font("Segoe UI", 14F);
            label3.ForeColor = SystemColors.HighlightText;
            label3.ImageAlign = ContentAlignment.TopCenter;
            label3.Location = new Point(10, 8);
            label3.Name = "label3";
            label3.Size = new Size(788, 41);
            label3.TabIndex = 66;
            label3.Text = "Find Duplicate Files:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DuplicateFiles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(809, 587);
            Controls.Add(label3);
            Controls.Add(ScannedPath);
            Controls.Add(DeleteForever);
            Controls.Add(ScanNested);
            Controls.Add(BrowseBtn);
            Controls.Add(TotalFilesScanned);
            Controls.Add(UnselectAll);
            Controls.Add(SelectAll);
            Controls.Add(label2);
            Controls.Add(FolderPathLbl);
            Controls.Add(SendToRecycleBin);
            Controls.Add(StopBtn);
            Controls.Add(SartScanBtn);
            Controls.Add(DuplicatFilesList);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "DuplicateFiles";
            Load += DuplicateFiles_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.CheckedListBox DuplicatFilesList;
        private System.ComponentModel.BackgroundWorker backgroundScanner;
        private System.Windows.Forms.Button SartScanBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button SendToRecycleBin;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Label FolderPathLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel SelectAll;
        private System.Windows.Forms.LinkLabel UnselectAll;
        private System.Windows.Forms.Label TotalFilesScanned;
        private System.Windows.Forms.CheckBox ScanNested;
        private System.Windows.Forms.Button DeleteForever;
        private System.Windows.Forms.Label ScannedPath;
        private System.Windows.Forms.Label label3;
    }
}