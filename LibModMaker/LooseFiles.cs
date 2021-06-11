using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// Class encapsulating a folder of loose files and folders as part of the SourceFileSystem
    /// </summary>
    class LooseFiles : iFileSystem
    {
        private string rootPath;

        public string Name
        {
            get { return rootPath; }
        }

        /// <summary>
        /// Open a specified folder to use as a mount point
        /// </summary>
        /// <param name="folderPath">full path to a folder to mount</param>
        public void Open(string folderPath)
        {
            if (folderPath.EndsWith(".."))
            {
                folderPath = folderPath.Substring(0, folderPath.Length - 2);
                var DI = new DirectoryInfo(folderPath);
                folderPath = DI.Parent.FullName;
            }

            if (folderPath.EndsWith("."))
            {
                folderPath = folderPath.Substring(0, folderPath.Length - 1);
                var DI = new DirectoryInfo(folderPath);
                folderPath = DI.FullName;
            }

            if (!Directory.Exists(folderPath))
            {
                throw new ArgumentException(folderPath + " does not exist");
            }
            rootPath = folderPath;
        }

        /// <summary>
        /// Folder contains the specified path
        /// </summary>
        /// <param name="path">relative to the game root</param>
        /// <returns>if if this path is a loose file</returns>
        public bool Contains(string path)
        {
            string fullPath = Path.Combine(rootPath, path);

            if (File.Exists(fullPath)) return true;

            return Directory.Exists(fullPath);
        }

        /// <summary>
        /// Extract a loose file to a folder
        /// </summary>
        /// <param name="path">relative to the game root</param>
        /// <param name="folderPath">full path to the folder we're copying to</param>
        /// <returns>true on success</returns>
        public bool Extract(string path, string folderPath)
        {
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string sourcePath = Path.Combine(rootPath, path);
            
            if (File.Exists(sourcePath))
            {
                string targetPath = Path.Combine(folderPath, Path.GetFileName(path));
                File.Copy(sourcePath, targetPath);

                return true;
            }

            if (Directory.Exists(sourcePath))
            {
                CopyFolder(sourcePath, folderPath);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Recirsively copy a folder and all it's contents
        /// </summary>
        /// <param name="SourcePath"></param>
        /// <param name="DestinationPath"></param>
        private void CopyFolder(string SourcePath, String DestinationPath)
        {
            if (!Directory.Exists(SourcePath)) return;

            DestinationPath = Path.Combine(DestinationPath, Path.GetDirectoryName(SourcePath));

            if (!Directory.Exists(DestinationPath))
            {
                Directory.CreateDirectory(DestinationPath);
            }

            string[] files = Directory.GetFiles(SourcePath);
            int rootOffSet = rootPath.Length; //Add one for the directory seperator?

            foreach (string filePath in files)
            {
                File.Copy(filePath, Path.Combine(DestinationPath, Path.GetFileName(filePath)) );
            }

            string[] folders = Directory.GetDirectories(SourcePath);
            foreach (var childFolder in folders)
            {
                CopyFolder(childFolder, DestinationPath); //Recursive
            }
        }

        /// <summary>
        /// Get the size in Bytes of the specified path
        /// </summary>
        /// <param name="path">relative to the game root</param>
        /// <returns>0 if the path is not a loose file or folder</returns>
        public ulong GetSize(string path)
        {
            string FullPath = Path.Combine(rootPath, path);

            if (File.Exists(FullPath))
            {
                var x = new FileInfo(FullPath);

                return (ulong)x.Length;
            }

            if (Directory.Exists(FullPath))
            {
                var folderInfo = new DirectoryInfo(FullPath);

                return (ulong) GetFolderSize(FullPath);
            }

            return 0;
        }

        public FileSystemInfo GetInfo(string path)
        {
            var result = new FileSystemInfo() {Path = path, Mount = rootPath };

            result.Mount = "LooseFiles (" + result.Mount + ")";

            string FullPath = Path.Combine(rootPath, path);

            if (File.Exists(FullPath))
            {
                var x = new FileInfo(FullPath);

                result.Size = (ulong)x.Length;
                result.IsFolder = false;
            }

            if (Directory.Exists(FullPath))
            {
                var folderInfo = new DirectoryInfo(FullPath);

                result.Size = (ulong)GetFolderSize(FullPath);
                result.IsFolder = true;
            }

            return result;
        }

        /// <summary>
        /// Recirsively work out the size of a folder and all it's contents
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>size of the folder in bytes</returns>
        private long GetFolderSize(string folderPath)
        {
            if (!Directory.Exists(folderPath)) return 0;

            long result = 0;

            string[] files = Directory.GetFiles(folderPath);
            FileInfo fileInfo;

            foreach (string filePath in files)
            {
                fileInfo = new FileInfo(filePath);
                result = result + fileInfo.Length;
            }

            string[] folders = Directory.GetDirectories(folderPath);
            foreach (var childFolder in folders)
            {
                result = result + GetFolderSize(childFolder); //recursive
            }

            return result;
        } //End GetFolderSize

        /// <summary>
        /// List all the files and folder within this mount
        /// </summary>
        /// <returns></returns>
        public List<string> Listing()
        {
            var result = new List<string>();

            InnerListing(rootPath, result);

            return result;
        }//End Listing

        /// <summary>
        /// Recursivly list all files and folders within a given folder
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="result"></param>
        private void InnerListing(string folderPath, List<string> result)
        {
            if (!Directory.Exists(folderPath)) return;

            string[] files = Directory.GetFiles(folderPath);
            int rootOffSet = rootPath.Length; //Add one for the directory seperator?
            bool IsEmpty = true;

            foreach (string filePath in files)
            {
                result.Add(filePath.Substring(rootOffSet));
                IsEmpty = false;
            }

            string[] folders = Directory.GetDirectories(folderPath);
            foreach (var childFolder in folders)
            {
                InnerListing(childFolder, result);
                IsEmpty = false;
            }

            if (IsEmpty)
            {
                result.Add( Path.DirectorySeparatorChar + folderPath.Substring(rootOffSet));
            }
        }//End InnerListing

    }
}
