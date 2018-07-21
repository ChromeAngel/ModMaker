using System;
using System.Collections.Generic;
using System.Text;

namespace LibModMaker
{
    public struct FileSystemInfo
    {
        public string Path;
        public string Mount;
        public ulong Size;
        public bool IsFolder;
    }

    /// <summary>
    /// Interface for virtual file system components used in Source games (loose files, GCFs, VPKS)
    /// </summary>
    internal interface iFileSystem
    {
        bool Contains(string path);
        bool Extract(string path, string folderPath);
        List<string> Listing();
        ulong GetSize(string path);
        FileSystemInfo GetInfo(string path);
    }
}
