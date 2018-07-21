using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace ModMaker
{

    /// <summary>
    /// Tool for cleaning up temporary, auto-generated and player specific files tend to clutter up games install folders
    /// </summary>
    public class CleanupTool : iTool, InstallScriptMaker.iPrereqisite
    {

        /// <summary>
        /// Regualr expression to match files in ModMakers backup file name format
        /// </summary>
        protected static System.Text.RegularExpressions.Regex BackupRegex =
            new System.Text.RegularExpressions.Regex(".*-\\d{8}-\\d{6}\\..*");

        /// <summary>
        /// Known specific files that are known to generate clutter
        /// </summary>
        protected static string[] ClutterFiles =
        {
            "*.log",
            "*.db",
            "*.dem",
            "albedo.tga",
            "demoheader.tmp",
            "stats.txt",
            "textwindow_temp.html",
            "scene.cache",
            "modelsounds.cache",
            "voice_ban.dt",
            "cfg\\banned_user.cfg",
            "cfg\\banned_ip.cfg",
            "cfg\\config.cfg",
            "cfg\\pet.txt",
            "scripts\\kb_def.lst",
            "scripts\\settings.scr",
            "bin\\client.pdb",
            "bin\\server.pdb"
        };

        /// <summary>
        /// Folders that are known to be full of clutter
        /// </summary>
        protected static string[] ClutterFolders =
        {
            "SAVE\\",
            "Expressions\\",
            "screenshots\\",
            "reslists\\",
            "downloads\\",
            "downloadlists\\",
            "materialsrc\\",
            "materials\\maps\\",
            "maps\\graphs\\",
            "maps\\soundcache\\",
            "materials\\temp\\",
            "user_custom\\"

        };

        public string Name
        {
            get { return "Cleanup"; }
        }

        public bool Test(LibModMaker.SourceMod Subject)
        {
            Launch(Subject);

            return true;
        }

        public string TipText
        {
            get { return "Send temporary, auto-generated and player specific files to the Recycle Bin"; }
        }

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.Clean.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return true;
        }

        public bool ShouldPrompt { get; set; }

        /// <summary>
        /// Launch the cleanup tool for a specific game
        /// </summary>
        /// <param name="Game"></param>
        public void Launch(LibModMaker.SourceMod Game)
        {
            if (ShouldPrompt)
            {
                if (
                    Interaction.MsgBox("Send temporary, auto-generated and player specific files to the Recycle Bin?",
                        MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Delete Clutter?") == MsgBoxResult.No)
                    return;
            }

            //Known junk/temp folders
            foreach (string Folder in CleanupTool.ClutterFolders)
            {
                string FullPath = Path.Combine(Game.InstallPath, Folder);

                if (!Directory.Exists(FullPath))
                    continue;

                Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(FullPath, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }

            //Known junk/temp files
            foreach (string strFile in CleanupTool.ClutterFiles)
            {
                if(strFile.StartsWith("*"))
                {
                    string[] JunkFiles = Directory.GetFiles(Game.InstallPath, strFile, System.IO.SearchOption.AllDirectories);

                    foreach (string File in JunkFiles)
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                            Path.Combine(Game.InstallPath, File),
                            Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                            Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin
                        );
                    }
                }
                else
                {
                    string FullPath = Path.Combine(Game.InstallPath, strFile);

                    if (!File.Exists(FullPath))
                        continue;

                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                        Path.Combine(Game.InstallPath, strFile),
                        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                        Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin
                    );
                }
            }

            //Xbox specific files
            string ModelsPath = Path.Combine(Game.InstallPath, "models");

            if (Directory.Exists(ModelsPath))
            {
                string[] JunkFiles = Directory.GetFiles(ModelsPath, "*.xbox.vtx", System.IO.SearchOption.AllDirectories);

                foreach (string File in JunkFiles)
                {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                        Path.Combine(Game.InstallPath, File),
                        UIOption.OnlyErrorDialogs,
                        RecycleOption.SendToRecycleBin
                    );
                }
            }

            //ModMaker backup files
            string[] BackupFiles = GetModMakerBackups(Game);

            foreach (string File in BackupFiles)
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                    Path.Combine(Game.InstallPath, File),
                    UIOption.OnlyErrorDialogs,
                    RecycleOption.SendToRecycleBin
                );
            }

            //Remove empty folders
            EmptyFolders(Game.InstallPath);

            //Affirm to the user that we're done
            Interaction.MsgBox("Cleanup completed.", MsgBoxStyle.Information , "Cleanup - Done");
        }

        /// <summary>
        /// Recursively remove empty folders
        /// </summary>
        /// <param name="FilePath"></param>
        /// <remarks></remarks>
        public void EmptyFolders(string FilePath)
        {
            string[] Folders = Directory.GetDirectories(FilePath);

            foreach (string Folder in Folders)
            {
                EmptyFolders(Folder);
            }

            Folders = Directory.GetDirectories(FilePath);

            if (Folders.Length > 0)
                return;
            if (Directory.GetFileSystemEntries(FilePath).Length > 0)
                return;

            Directory.Delete(FilePath);
        }

        /// <summary>
        /// Find all the files in the game that look like modmaker backups
        /// </summary>
        /// <param name="Game"></param>
        /// <returns>array of full file paths</returns>
        protected string[] GetModMakerBackups(LibModMaker.SourceMod Game)
        {
            List<string> Result = new List<string>();

            FillModMakerBackups(Game.InstallPath, Result);

            return Result.ToArray();
        }

        /// <summary>
        /// Recursive search of the RootPath for files that look like ModMaker backups
        /// </summary>
        /// <param name="RootPath"></param>
        /// <param name="Files"></param>
        protected void FillModMakerBackups(string RootPath, List<string> Files)
        {
            string[] LocalFiles = Directory.GetFiles(RootPath);

            foreach (string File in LocalFiles)
            {
                if (BackupRegex.Matches(File).Count == 0)
                    continue;

                //Looks like a backup, strip out the timestamp to work out what the orignal looked like
                string OriginalFileName = Path.GetFileNameWithoutExtension(File);
                OriginalFileName = OriginalFileName.Substring(0, OriginalFileName.Length - 16);
                OriginalFileName += Path.GetExtension(File);
                OriginalFileName = Path.Combine(RootPath, OriginalFileName);

                foreach (string OtherFile in LocalFiles)
                {
                    if (OtherFile == OriginalFileName)
                    {
                        //Found the backup it is a legit backup
                        Files.Add(File);

                        break;
                    }
                }
            }

            string[] LocalFolders = Directory.GetDirectories(RootPath);

            foreach (string Folder in LocalFolders)
            {
                FillModMakerBackups(Folder, Files);
            }
        }


    }

}