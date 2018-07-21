using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// Class encapsulating packaged files and folders as part of the SourceFileSystem
    /// </summary>
    /// <remarks>heavily relies on HLLib which it attempts to present in an OOP fashion</remarks>
    internal class Package : IDisposable, iFileSystem
    {
        private static bool IsHLLibInitialized = false;
        private static int Instances = 0;
        //static readonly uint MAX_PATH_SIZE = 512;

        // Package stuff.
        HLLib.HLPackageType ePackageType = HLLib.HLPackageType.HL_PACKAGE_NONE;
        uint uiPackage = HLLib.HL_ID_INVALID;
        uint uiMode = (uint)HLLib.HLFileMode.HL_MODE_INVALID;

        IntPtr pItem = IntPtr.Zero;

        private bool IsPackageOpen = false;
        private FolderNode RootNode;
        private string Mount;

        public void Open(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException(filePath + " does not exist", "filePath");
            }

            Mount = filePath;

            Initialize();

            // Get the package type from the filename extension.
            ePackageType = HLLib.hlGetPackageTypeFromName(filePath);

            if (ePackageType == HLLib.HLPackageType.HL_PACKAGE_NONE && File.Exists(filePath))
            {
                throw new ApplicationException("Unsupported File Format");
            }

            // Create a package element, the element is allocated by the library and cleaned
            // up by the library.  An ID is generated which must be bound to apply operations
            // to the package.
            if (!HLLib.hlCreatePackage(ePackageType, out uiPackage))
            {
                throw new ApplicationException("CreatePackage Failed");
            }

            HLLib.hlBindPackage(uiPackage);

            uiMode = (uint)HLLib.HLFileMode.HL_MODE_READ;
            uiMode |= (uint)HLLib.HLFileMode.HL_MODE_VOLATILE;

            // Open the package.
            // Of the above modes, only HL_MODE_READ is required.  HL_MODE_WRITE is present
            // only for future use.  File mapping is recommended as an efficient way to load
            // packages.  Quick file mapping maps the entire file (instead of bits as they are
            // needed) and thus should only be used in Windows 2000 and up (older versions of
            // Windows have poor virtual memory management which means large files won't be able
            // to find a continues block and will fail to load).  Volatile access allows HLLib
            // to share files with other applications that have those file open for writing.
            // This is useful for, say, loading .gcf files while Steam is running.
            if (!HLLib.hlPackageOpenFile(filePath, uiMode))
            {
                throw new ApplicationException("PackageOpen Failed");
            }

            IsPackageOpen = true;

            RootNode = new FolderNode(HLLib.hlPackageGetRoot());
        }


        private class PackageSystemNode
        {
            public string Name;
            public IntPtr Handle;
            public HLLib.HLDirectoryItemType NodeType;
            public PackageSystemNode Parent;

            public PackageSystemNode()
            {
            }

            public PackageSystemNode(IntPtr handle)
            {
                this.Handle = handle;
                Parent = null;
                Name = HLLib.hlItemGetName(handle);
                NodeType = HLLib.hlItemGetType(handle);
            }

            public PackageSystemNode(IntPtr handle, PackageSystemNode parent)
            {
                this.Handle = handle;
                Parent = parent;
                Name = HLLib.hlItemGetName(handle);
                NodeType = HLLib.hlItemGetType(handle);
            }

            public string FullPath
            {
                get
                {
                    if (Parent == null) return "";

                    return Parent.FullPath + Path.DirectorySeparatorChar + Name;
                }
            }
        }

        private class FileNode : PackageSystemNode
        {
            public FileNode()
            {
            }

            public FileNode(IntPtr handle) : base(handle)
            {
            }

            public FileNode(IntPtr handle, PackageSystemNode parent): base(handle, parent)
            {
            }
        }

        private class FolderNode : PackageSystemNode
        {
            public FolderNode()
            {
            }

            public FolderNode(IntPtr handle) : base(handle)
            {
            }

            public FolderNode(IntPtr handle, PackageSystemNode parent) : base(handle, parent)
            {
            }

            private List<PackageSystemNode> _children = null;

            public List<PackageSystemNode> Children
            {
                get
                {
                    if (_children == null)
                    {
                        _children = new List<PackageSystemNode>();

                        uint uiItemCount = HLLib.hlFolderGetCount(Handle);

                        // List all items in the current folder.
                        for (uint i = 0; i < uiItemCount; i++)
                        {
                            IntPtr pSubItem = HLLib.hlFolderGetItem(Handle, i);
                            PackageSystemNode SubNode;

                            if (HLLib.hlItemGetType(pSubItem) == HLLib.HLDirectoryItemType.HL_ITEM_FILE)
                            {
                                SubNode = new FileNode(pSubItem, this);
                            }
                            else if (HLLib.hlItemGetType(pSubItem) == HLLib.HLDirectoryItemType.HL_ITEM_FOLDER)
                            {
                                SubNode = new FolderNode(pSubItem, this);
                            }
                            else
                            {
                                continue; 
                            }

                            _children.Add(SubNode);
                        }
                    }

                    return _children;
                }
            } //End Children

            internal PackageSystemNode Find(string[] path, int pathIndex)
            {
                foreach (var Child in Children)
                {
                    if (string.Compare(Child.Name, path[pathIndex], StringComparison.InvariantCultureIgnoreCase) == 0) //the child's name matches 
                    {
                        if (path.Length == pathIndex + 1) //is it the last part of the path?
                        {
                            return Child;  //we found it!
                        }
                        else
                        {
                            //If we found a folder that matches
                            if (Child.NodeType == HLLib.HLDirectoryItemType.HL_ITEM_FOLDER)
                            {
                                FolderNode ChildFolder = Child as FolderNode;

                                if (ChildFolder == null) return null; //should never happen

                                // check if the child folder contains the next part of the path
                                return ChildFolder.Find(path, pathIndex + 1);
                            }
                        }
                    }
                }

                return null; //nope! did not find any children matching this part of the path
            }
        }//End Folder Node

        public bool Contains(string path)
        {
            if (!IsPackageOpen) return false;
            if (string.IsNullOrEmpty(path)) return false;

            string[] nodes = path.Split(Path.DirectorySeparatorChar);
            PackageSystemNode found = RootNode.Find(nodes, 0);

            return (found != null);
        }

        /// <summary>
        /// Extract the specified file to a folder
        /// </summary>
        /// <param name="path"></param>
        /// <param name="folderPath"></param>
        /// <returns>true if the content has been extracted</returns>
        public bool Extract(string path, string folderPath)
        {
            if (!IsPackageOpen) return false;
            if (string.IsNullOrEmpty(path)) return false;

            string[] nodes = path.Split(Path.DirectorySeparatorChar);
            PackageSystemNode found = RootNode.Find(nodes, 0);

            if (found == null) return false;

            return HLLib.hlItemExtract(found.Handle, folderPath);
        }



        /// <summary>
        /// List all the files in the package
        /// </summary>
        /// <returns></returns>
        public List<string> Listing()
        {
            var result = new List<string>();

            InnerListing(RootNode, result);

            return result;
        }

        /// <summary>
        /// Recursive implementation for Listing
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="result"></param>
        private void InnerListing(FolderNode folder, List<string> result)
        {
            if (folder == null) return;
            if (folder.Children.Count == 0)
            {
                result.Add(folder.FullPath);
            }
            else
            {
                foreach (var Child in folder.Children)
                {
                    if (Child.NodeType == HLLib.HLDirectoryItemType.HL_ITEM_FILE)
                    {
                        result.Add(Child.FullPath);
                    }
                    else
                    {
                        InnerListing(Child as FolderNode, result); //recurse
                    }
                }
            }
        } //end  InnerListing


        /// <summary>
        /// Returns the size of the path in bytes
        /// </summary>
        /// <param name="path">a file or folder path in the file</param>
        /// <returns>0 on error or the path does not exist, otherwise the size of the path</returns>
        public ulong GetSize(string path)
        {
            if (!IsPackageOpen) return 0;
            if (string.IsNullOrEmpty(path)) return 0;

            string[] nodes = path.Split(Path.DirectorySeparatorChar);
            PackageSystemNode found = RootNode.Find(nodes, 0);

            if (found == null) return 0;

            ulong Result = 0;

            if (HLLib.hlItemGetSizeEx(found.Handle, out Result))
            {
                return Result;
            }
            else
            {
                return 0;
            }
        }

        public FileSystemInfo GetInfo(string path)
        {
            var result = new FileSystemInfo() {Path = path, Mount = Mount};

            if (!IsPackageOpen) return result;
            if (string.IsNullOrEmpty(path)) return result;

            string[] nodes = path.Split(Path.DirectorySeparatorChar);
            PackageSystemNode found = RootNode.Find(nodes, 0);

            if (found == null) return result;

            result.IsFolder = (result.GetType().Name == "FolderNode");

            ulong Size = 0;

            if (HLLib.hlItemGetSizeEx(found.Handle, out Size))
            {
                result.Size = Size;
            }
            else
            {
                result.Size = 0;
            }

            return result;
        }

        public byte[] GetData(string path)
        {
            byte[] result;

            if (!IsPackageOpen) return new byte[0];
            if (string.IsNullOrEmpty(path)) return new byte[0];

            string[] nodes = path.Split(Path.DirectorySeparatorChar);
            PackageSystemNode found = RootNode.Find(nodes, 0);

            if (found == null) return new byte[0];

            uint iSize = 0;

            if (HLLib.hlItemGetSize(found.Handle, out iSize))
            {
                result = new byte[iSize];
                IntPtr dataAddress = HLLib.hlItemGetData(found.Handle);
                Marshal.Copy(dataAddress, result, 0, (int)iSize);

                return result;
            }
            else
            {
                return new byte[0];
            }
        }


        private void Initialize()
        {
            if (IsHLLibInitialized) return;

            HLLib.hlInitialize();

            // Keep the delegates alive so they don't get garbage collected.
            HLLib.HLExtractItemStartProc HLExtractItemStartProc = new HLLib.HLExtractItemStartProc(ExtractItemStartCallback);
            HLLib.HLExtractItemEndProc HLExtractItemEndProc = new HLLib.HLExtractItemEndProc(ExtractItemEndCallback);
            HLLib.HLExtractFileProgressProc HLExtractFileProgressProc = new HLLib.HLExtractFileProgressProc(FileProgressCallback);
            HLLib.HLValidateFileProgressProc HLValidateFileProgressProc = new HLLib.HLValidateFileProgressProc(FileProgressCallback);
            HLLib.HLDefragmentFileProgressExProc HLDefragmentFileProgressProc = new HLLib.HLDefragmentFileProgressExProc(DefragmentProgressCallback);

            HLLib.hlSetBoolean(HLLib.HLOption.HL_OVERWRITE_FILES, false);
            HLLib.hlSetVoid(HLLib.HLOption.HL_PROC_EXTRACT_ITEM_START, Marshal.GetFunctionPointerForDelegate(HLExtractItemStartProc));
            HLLib.hlSetVoid(HLLib.HLOption.HL_PROC_EXTRACT_ITEM_END, Marshal.GetFunctionPointerForDelegate(HLExtractItemEndProc));
            HLLib.hlSetVoid(HLLib.HLOption.HL_PROC_EXTRACT_FILE_PROGRESS, Marshal.GetFunctionPointerForDelegate(HLExtractFileProgressProc));
            HLLib.hlSetVoid(HLLib.HLOption.HL_PROC_VALIDATE_FILE_PROGRESS, Marshal.GetFunctionPointerForDelegate(HLValidateFileProgressProc));
            HLLib.hlSetVoid(HLLib.HLOption.HL_PROC_DEFRAGMENT_PROGRESS_EX, Marshal.GetFunctionPointerForDelegate(HLDefragmentFileProgressProc));

            Instances++;
            IsHLLibInitialized = true;
        }

        #region "Callbacks"
        static void ExtractItemStartCallback(IntPtr pItem)
        {

        }

        static void FileProgressCallback(IntPtr pFile, uint uiBytesExtracted, uint uiBytesTotal, ref bool pCancel)
        {
        }

        static void ExtractItemEndCallback(IntPtr pItem, bool bSuccess)
        {

        }

        static void DefragmentProgressCallback(IntPtr pFile, uint uiFilesDefragmented, uint uiFilesTotal, UInt64 uiBytesDefragmented, UInt64 uiBytesTotal, ref bool pCancel)
        {

        }
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (IsHLLibInitialized)
                    {
                        if (IsPackageOpen)
                        {
                            // Close the package.
                            HLLib.hlPackageClose();

                            // Free up the allocated memory.
                            HLLib.hlDeletePackage(uiPackage);

                            RootNode = null;
                        }

                        Instances--;

                        if (Instances == 0)
                        {
                            HLLib.hlShutdown();
                        }

                    }
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

    }
}
