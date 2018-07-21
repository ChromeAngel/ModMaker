using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace ModMaker
{

    /// <summary>
    /// Tool for packaging loose files and folders into VPK packages (for the Steampipe update to Source)
    /// </summary>
    public class VPKPackerTool : iTool
    {

        //Friend Shared CommonPaths As String() = {"Team Fortress 2\bin ", "Left 4 Dead\bin ", "Source SDK Base 2013 Singleplayer\bin", "Source SDK Base 2013 Multiplayer\bin"}

        /// <summary>
        /// Folders this tool is allowed to package
        /// </summary>
        public string[] PackFolders =
        {
            "maps",
            "materials",
            "models",
            "sound",
            "particles",
            "scenes",
            "scripts"

        };

        /// <summary>
        /// Event to notify the UI that progress is being made
        /// </summary>
        public event PackingEventHandler Packing;

        public delegate void PackingEventHandler(String FilePath, int Value, int Max);

        /// <summary>
        /// Form for monitoring the commandline tool we're using
        /// </summary>
        private ConsoleProcessMonitorForm Monitor;
        private LibModMaker.SourceMod PackGame;

        /// <summary>
        /// Path to the VPK file we're working on
        /// </summary>
        private string VPKPath;

        public string Name
        {
            get { return "Steampipe Packer"; }
        }

        public string TipText
        {
            get { return "Package your Maps, Materals, Models, Sound, Particles and Scenes as a VPK"; }
        }

        public System.Drawing.Image Image
        {
            get { return Steam.Icon.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            PackGame = Game;

            if (Game.SourcePath == null)
                return false;
            if (File.Exists(VPKAppPath))
                return true;

            return false;
        }

        /// <summary>
        /// Full path to the VPK command line utility
        /// </summary>
        private string VPKAppPath
        {
            get
            {
                string AppPath = Steam.AppPath(PackGame.AppId);

                if (AppPath == null)
                    return null;

                return Path.Combine(Path.Combine(AppPath, "bin"), "vpk.exe");
            }
        }

        /// <summary>
        /// Path to the resource file we are working with
        /// </summary>
        /// <remarks>The resource file is a list of paths, relative to the game install folder, 1 path per line, that tells VPK what files and folders to add/update in the package</remarks>
        private string ResourcePath;

        /// <summary>
        /// Launch the tool to package loose files and folders for the given game
        /// </summary>
        /// <param name="Game"></param>
        public void Launch(LibModMaker.SourceMod Game)
        {
            PackGame = Game;
            VPKPath = Path.Combine(Game.InstallPath, Game.InstallFolder + ".vpk");

            string Exe = VPKAppPath;
            ConsoleProcessMonitorForm Console = new ConsoleProcessMonitorForm();

            //VPKs need to be signed with a public and private key
            string PrivateKeyPath = Path.Combine(Game.SourcePath, Game.InstallFolder + ".privatekey.vdf");
            string PublicKeyPath = Path.Combine(Game.SourcePath, Game.InstallFolder + ".publickey.vdf");
            string Arguments;

            //Find all the packageable files and list them in a resource file
            ResourcePath = MakeResourceFile();

            //If you don't already have a key pair, generate them
            if (!(File.Exists(PrivateKeyPath) & File.Exists(PublicKeyPath)))
            {
                Console.Monitor(Exe, "generate_keypair " + Game.InstallFolder, Game.SourcePath);
            }

            //https://developer.valvesoftware.com/wiki/VPK
            //-v verbose output
            //-M Produce a multi-chunk VPK.
            //-k public key
            //-K private key
            // a Add files to a named VPK from a resource file prefixed by @
            Arguments = string.Format("-v -M -k {0} -K {1} a {2} @{3}", PublicKeyPath, PrivateKeyPath, VPKPath, ResourcePath);

            //launch the command line app in a window, so the user can see what it's doing
            Monitor = new ConsoleProcessMonitorForm();
            Monitor.ProcessEnded += Monitor_ProcessEnded;
            Monitor.Monitor(Exe, Arguments, Game.InstallPath);
        }

        /// <summary>
        /// Packaging process has finished, update the Gameinfo to refer to the package and clean up the loose files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Monitor_ProcessEnded(object sender, System.EventArgs e)
        {
            UpdateGameInfo();
            Monitor.Close();

            if (File.Exists(ResourcePath) &&
                Interaction.MsgBox("Move packed files to the Recycle Bin?", MsgBoxStyle.Question | MsgBoxStyle.YesNo,
                    "Recycle Packed Files?") == MsgBoxResult.Yes)
            {
                RecyclePackedFiles(ResourcePath);
                DeleteEmptyFolders();

                Interaction.MsgBox("Done.  Packed files have been recycled.", MsgBoxStyle.Information, "Packing Complete");
            }
            else
            {
                Interaction.MsgBox("Done packing loose files.", MsgBoxStyle.Information, "Packing Complete");
            }
        }

        /// <summary>
        /// Make a file listing all the resouces to be packaged
        /// </summary>
        /// <returns>Path to the resource file</returns>
        protected string MakeResourceFile()
        {
            //In the source path for this game make a date and time stamped .res file
            string FilePath = Path.Combine(PackGame.SourcePath,
                string.Format("{0}_vpk_list_{1:yyyyMMdd-hhmm}.res", PackGame.InstallFolder, DateTime.Now));

            using (StreamWriter SR = new StreamWriter(FilePath))
            {
                foreach (string rootFolder in PackFolders)
                {
                    string strPath = Path.Combine(PackGame.InstallPath, rootFolder);

                    if (Directory.Exists(strPath))
                        WriteFileList(SR, strPath);
                }
            }

            return FilePath;
        }

        /// <summary>
        /// Reursively write out a list of packageable file to the given Stream from within a given folder
        /// </summary>
        /// <param name="SR"></param>
        /// <param name="FolderPath"></param>
        protected void WriteFileList(StreamWriter SR, string FolderPath)
        {
            string[] Files = Directory.GetFiles(FolderPath);

            foreach (string File in Files)
            {
                //Can't pack BSP , beceause they can be packages in their own right and Source is too dumb to mount packages within packages
                if (Path.GetExtension(File).EndsWith("bsp"))
                    continue;

                SR.WriteLine(File.Substring(PackGame.InstallPath.Length));
            }

            string[] Folders = Directory.GetDirectories(FolderPath);

            foreach (string Folder in Folders)
            {
                WriteFileList(SR, Folder);
            }
        }

        /// <summary>
        /// Update the game's gameInfo.txt to tell the game to mount the VPK if it's not already mounted
        /// </summary>
        public void UpdateGameInfo()
        {
            string FilePath = Path.Combine(PackGame.InstallPath, "gameinfo.txt");
            KeyValues GameInfo = KeyValues.LoadFile(FilePath);
            KeyValues FileSystem = GameInfo.GetKey("FileSystem");

            SourceFileSystem.BackUpFile(FilePath);

            if (FileSystem == null)
                return;

            KeyValues SearchPaths = FileSystem.GetKey("SearchPaths");

            if (SearchPaths == null)
                return;

            string VPKFile = "|gameinfo_path|" + PackGame.InstallFolder + ".vpk";

            //check if the VPK is already mounted
            foreach (KeyValues Key in SearchPaths.Keys)
            {
                if (Key.Value == VPKFile)
                    return;
            }

            KeyValues NewSearchPath = new KeyValues("game+mod", VPKFile, SearchPaths);

            //Move it to the 2nd spot in the list
            SearchPaths.Keys.Remove(NewSearchPath);
            SearchPaths.Keys.Insert(1, NewSearchPath);

            GameInfo.Save(FilePath, System.Text.Encoding.ASCII);
        }

        /// <summary>
        /// Move files listed in the Resource file to the Recycle Bin
        /// </summary>
        /// <param name="ResourcePath"></param>
        private void RecyclePackedFiles(string ResourcePath)
        {
            if (!File.Exists(ResourcePath))
                return;

            string[] Files = File.ReadAllLines(ResourcePath);
            string FullPath;

            foreach (string strFile in Files)
            {
                FullPath = Path.Combine(PackGame.InstallPath, strFile);
                if ((!File.Exists(FullPath)))
                    continue;

                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                    FullPath,
                    UIOption.OnlyErrorDialogs,
                    RecycleOption.SendToRecycleBin
                );
            }
        }

        /// <summary>
        /// Recursively delete any folders within the package folders that are empty
        /// </summary>
        private void DeleteEmptyFolders()
        {
            string FolderPath;

            foreach (string rootFolder in PackFolders)
            {
                FolderPath = Path.Combine(PackGame.InstallPath, rootFolder);

                if (!Directory.Exists(FolderPath))
                    continue;

                //If the folder tree is now empty, delete it
                if (Directory.GetFiles(FolderPath, "*", SearchOption.AllDirectories).Length == 0)
                {
                    Directory.Delete(FolderPath, true);
                    //True = Recursive
                }
            }
        }




    }

}