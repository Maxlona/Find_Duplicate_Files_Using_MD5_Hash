
## Find Duplicate Files:
This tool will help you find duplicate files in a folder. You can search the folder files or the content of all nested folders.

This is a prototype using .NET/C# Windows Forms,

## How it works!

The algorithm used in this POC is to calculate a unique hash of all files found without regard to its extension using SHA265 
- More about SHA265 here -> https://debugpointer.com/security/sha256-overview)
- Build a collection with all hashes
- Compare generated hash (if found) flag as duplicate, and calculate it's size on the disk space
- Calculate overall duplicate files' disk space
- Delete all duplicate files or choose certain files to delete
- Move Files to the Recycle Bin, or delete it forever <please see screenshot>

![image](https://github.com/user-attachments/assets/32436d63-96ed-4ddc-b9a1-bdfdee9ee9f4)

