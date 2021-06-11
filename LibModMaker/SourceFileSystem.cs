using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace LibModMaker
{
    /// <summary>
    /// Class encapsulating Source's use of a virtual filesystem composed of loose and packaged folders governed by the Game's GameInfo.txt keyvalues
    /// </summary>
    public class SourceFileSystem : iFileSystem
    {
        /// <summary>
        /// The various mount points (loose or packaged folders)
        /// </summary>
        private List<iFileSystem> mounts;

        /// <summary>
        /// The game we're providing a file system form
        /// </summary>
        private SourceGame game;

        public SourceFileSystem(SourceGame Game)
        {
            mounts = new List<iFileSystem>();
            game = Game;

            KeyValues GameInfo = KeyValues.LoadFile(game.GameInfoPath);
            KeyValues FileSystemKeys = GameInfo["FileSystem"];
            KeyValues SearchPaths = FileSystemKeys["SearchPaths"];

            foreach(var key in SearchPaths.Keys)
            {
                if(key.Name.Contains("game"))
                {
                    Add(key.Value);
                }
            }
        } //End the constructor

        /// <summary>
        /// Add a mount as desribed by GameInfo.txt into the file system
        /// </summary>
        /// <param name="mount"></param>
        protected void Add(string mount)
        {
            // points at the directory where gameinfo.txt is.
            mount = mount.Replace("|gameinfo_path|", game.InstallPath);

            string gameExeFolder = game.GameExeFolder();

            if (gameExeFolder != null)
            {
                //points at the directory containing HL2 shared content. which is what exactly?
                mount = mount.Replace("|all_source_engine_paths|", gameExeFolder + Path.DirectorySeparatorChar);
            }

            if (mount.EndsWith(".vpk", StringComparison.InvariantCultureIgnoreCase))
            {
                mount = mount.Replace(".vpk", "_dir.vpk");

                if(File.Exists(mount))
                {
                    var package = new Package();
                    package.Open(mount);
                    mounts.Add(package);
                }

            }
            else 
            if (mount.EndsWith("*"))
            {
                mount = mount.TrimEnd('*');

                if (!Path.IsPathRooted(mount))
                {
                    string ModPath = Path.Combine(game.InstallPath, mount);

                    if (!Directory.Exists(ModPath))
                    {
                        ModPath = Path.Combine(gameExeFolder, mount);
                    }

                    mount = ModPath;
                }

                if(Directory.Exists(mount))
                {
                    string[] subFolders = Directory.GetDirectories(mount);

                    foreach(string subFolder in subFolders)
                    {
                        var subFolderMount = new LooseFiles();
                        subFolderMount.Open(mount);
                        mounts.Add(subFolderMount);
                    }
                }

            }
            else
            {
                if (Directory.Exists(mount))
                {
                    var folderMount = new LooseFiles();
                    folderMount.Open(mount);
                    mounts.Add(folderMount);
                }
            }
        }//End Add

        /// <summary>
        /// Does the filesystem contain the specified path
        /// </summary>
        /// <param name="path">relative to the root game folder</param>
        /// <returns>true if the path is contained in any of the mounts</returns>
        public bool Contains(string path)
        {
            foreach (var mount in mounts)
            {
                if (mount.Contains(path)) return true;
            }

            return false;
        }//End contains

        /// <summary>
        /// Extract a file from the virtual file system to the OS file system
        /// </summary>
        /// <param name="path">relative to the root game folder</param>
        /// <param name="folderPath"></param>
        /// <returns>true on success</returns>
        public bool Extract(string path, string folderPath)
        {
            foreach (var mount in mounts)
            {
                if (mount.Contains(path))
                {
                    return mount.Extract(path, folderPath);
                }
            }

            return false;
        }//End Extract

        /// <summary>
        /// List the entire contents of the FileSystem
        /// </summary>
        /// <returns>paths to all the files and folder relative to the game root</returns>
        public List<string> Listing()
        {
            var result = new List<string>();

            foreach (var mount in mounts)
            {
                List<string> files = mount.Listing();

                foreach (var file in files)
                {
                    if (!result.Contains(file))
                    {
                        result.Add(file);

                        if(!mount.Contains(file))
                        {
                            if(mount.GetType().Name == "Package")
                            {
                                var P = mount as Package;
                                Debug.WriteLine(string.Format("Package {0} disowns {1}", P.Name, file));
                            } else if (mount.GetType().Name == "LooseFiles")
                            {
                                var P = mount as LooseFiles;
                                Debug.WriteLine(string.Format("LooseFiles {0} disowns {1}", P.Name, file));
                            }
                            else
                            {
                                Debug.WriteLine(string.Format("{0} disowns {1}", mount.GetType().Name, file));
                            }
                        }
                    }
                        
                }
            }

            return result;
        }// End Listing

        /// <summary>
        /// Get the Size in bytes of the specified file or folder
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ulong GetSize(string path)
        {
            foreach (var mount in mounts)
            {
                if (mount.Contains(path))
                {
                    return mount.GetSize(path);
                }
            }

            return 0;
        }// End GetSize

        public FileSystemInfo GetInfo(string path)
        {
            var result = new FileSystemInfo() { Path = path, Mount = "Unknown" };

            foreach (var mount in mounts)
            {
                if (mount.Contains(path))
                {
                    result = mount.GetInfo(path);
                    if(string.IsNullOrEmpty(result.Mount))
                    {
                        result.Mount = mount.GetType().Name;
                    }

                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Format a path properly, so it's terminated with a directory seperator
        /// </summary>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        public static string FormatFolderPath(string targetPath)
        {
            if (targetPath == null)
            {
                return null;
            }

            targetPath = targetPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            if (targetPath.EndsWith(Path.DirectorySeparatorChar.ToString())) return targetPath;

            return targetPath + Path.DirectorySeparatorChar;
        }

        /// <summary>
        /// Utility to backup a file with a timestamp
        /// </summary>
        /// <param name="FilePath">file to backup</param>
        /// <remarks>not used by Source, but by ModMaker to fail-safe</remarks>
        public static void BackUpFile(string FilePath)
        {
            if (!File.Exists(FilePath)) return;

            string FolderPath = Path.GetDirectoryName(FilePath);
            string FileName = Path.GetFileNameWithoutExtension(FilePath);
            string Ext = Path.GetExtension(FilePath);
            string BackupFilePath = Path.Combine(FolderPath, FileName + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + Ext);

            File.Copy(FilePath, BackupFilePath);
        }

        /// <summary>
        /// Check if a given file appear to be a backup take by BackupFile
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns>true if the FilePath does appear to be a backup</returns>
        public static bool IsBackupFile(string FilePath)
        {
            System.Text.RegularExpressions.Regex BackupRegex =
                new System.Text.RegularExpressions.Regex(".*-\\d{8}-\\d{6}\\..*");

            if (!BackupRegex.IsMatch(FilePath)) return false;

            //Looks like a backup, strip out the timestamp to work out what the orignal looked like
            string OriginalFileName = Path.GetFileNameWithoutExtension(FilePath);
            OriginalFileName = OriginalFileName.Substring(0, OriginalFileName.Length - 16);
            OriginalFileName += Path.GetExtension(FilePath);
            OriginalFileName = Path.Combine(Path.GetDirectoryName(FilePath), OriginalFileName);

            return File.Exists(OriginalFileName);
            //looks like a backup and the original exists
        }
    }
}
