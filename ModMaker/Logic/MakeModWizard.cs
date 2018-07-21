using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using LibModMaker;
using Microsoft.Win32;
using ModMaker.Properties;

namespace ModMaker
{
    /// <summary>
    /// A Wizard to make a new Source 2013 mod from scratch
    /// </summary>
    /// <remarks></remarks>
    public class MakeModWizard
    {
        public enum ModTypes
        {
            Unknown,
            HL2MP,
            HL2,
            Episodic
        }

        private System.Net.WebClient Downloader = new System.Net.WebClient();
        private System.Diagnostics.Process BatchCreate = new System.Diagnostics.Process();
        private SevenZip.SevenZipExtractor Unzipper;
        private NewModForm Dialog = new NewModForm();
        private NewModProgressForm Feedback = new NewModProgressForm();
        private string ZipPath;
        private string ModFullPath;

        private SourceMod Game;
        public event ProgressEventHandler Progress;

        public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

        public event FailedEventHandler Failed;

        public delegate void FailedEventHandler(object sender, String msg);

        public event FinishedEventHandler Finished;

        public delegate void FinishedEventHandler(object sender, String folder);

        public string Title;
        public string InstallFolder;
        public string SourcePath;

        public class ProgressEventArgs : EventArgs
        {
            public string msg;
            public int percent;
        }

        public MakeModWizard()
        {
            Downloader = new System.Net.WebClient();
            Downloader.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Downloader_DownloadFileCompleted);
            Downloader.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Downloader_DownloadProgressChanged);

            BatchCreate = new System.Diagnostics.Process();
            BatchCreate.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(BatchCreate_ErrorDataReceived);
            BatchCreate.Exited += new EventHandler(BatchCreate_Exited);

            Dialog = new NewModForm();
            Feedback = new NewModProgressForm();
        }

        public void Begin()
        {
            Dialog.Wizard = this;

            //Prompt the moddder about their new mod
            if (Dialog.ShowDialog() == DialogResult.Cancel)
            {
                if (Failed != null)
                {
                    Failed(this, null);
                }

                return;
            }

            if (!Directory.Exists(Dialog.SourcePath))
                Directory.CreateDirectory(Dialog.SourcePath);

            //Create sub folders for asset sources
            string[] SubFolders =
            {
                "mapsrc",
                "materialsrc",
                "soundsrc",
                "scriptsrc"
            };

            foreach (string SubFolder in SubFolders)
            {
                string innerSubFolder = Path.Combine(Dialog.SourcePath, SubFolder);

                if (!Directory.Exists(innerSubFolder))
                    Directory.CreateDirectory(innerSubFolder);
            }

            Feedback.Wizard = Dialog.Wizard;
            Feedback.Location = Dialog.Location;
            Feedback.Show();

            Application.DoEvents();

            //download the zip from github
            ZipPath = Path.Combine(Dialog.SourcePath, "source-sdk-2013-master.zip");
            Downloader.DownloadFileAsync(new Uri(Resources.SDK_2013_URL), ZipPath);

            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs
                {
                    msg = "Downloading latest source",
                    percent = 0
                });
            }
        }

        void DeepMove(string Source, string Destination)
        {
            if (!Directory.Exists(Source))
                return;

            if (!Directory.Exists(Destination))
                Directory.CreateDirectory(Destination);

            string[] Files = Directory.GetFiles(Source);

            foreach (string FileName in Files)
            {
                File.Copy(FileName, Path.Combine(Destination, Path.GetFileName(FileName)));
                File.Delete(FileName);
            }

            string[] Folders = Directory.GetDirectories(Source);

            foreach (string Folder in Folders)
            {
                DeepMove(Folder, Path.Combine(Destination, Path.GetFileName(Folder)));
            }

            Directory.Delete(Source);
        }


        private void Downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (!File.Exists(ZipPath))
            {
                if (Failed != null)
                {
                    Failed(this, "Failed to download the latest source.");
                }

                return;
            }

            //extract the zip to the source folder
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs
                {
                    msg = "Unzipping source files",
                    percent = 0
                });
            }

            Unzipper = new SevenZip.SevenZipExtractor(ZipPath);
            Unzipper.Extracting += new EventHandler<SevenZip.ProgressEventArgs>(Unzipper_Extracting);
            Unzipper.ExtractionFinished += new EventHandler<EventArgs>(Unzipper_ExtractionFinished);
            Unzipper.BeginExtractArchive(Dialog.SourcePath);
        }

        private void Downloader_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs
                {
                    msg = string.Format("Downloaded {0}%", e.ProgressPercentage),
                    percent = e.ProgressPercentage
                });
            }
        }

        private void Unzipper_Extracting(object sender, SevenZip.ProgressEventArgs e)
        {
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs
                {
                    msg = string.Format("Extracted {0}%", e.PercentDone),
                    percent = e.PercentDone
                });
            }
        }

        private void Unzipper_ExtractionFinished(object sender, System.EventArgs e)
        {
            string VanillaFolder = Path.Combine(Dialog.SourcePath, "source-sdk-2013-master");
            string VanillaModFolder = Dialog.ModType == ModTypes.HL2MP
                ? "mod_hl2mp"
                : Dialog.ModType == ModTypes.HL2 ? "mod_hl2" : "mod_episodic";

            VanillaFolder = Path.Combine(VanillaFolder, Dialog.ModType == ModTypes.HL2MP ? "mp" : "sp");

            if (!Directory.Exists(VanillaFolder))
            {
                if (Failed != null)
                {
                    Failed(this, "Failed to extract the latest source from " + ZipPath);
                }

                return;
            }

            //move the source code to out source folder
            string SourceCodePath = Path.Combine(Dialog.SourcePath, "src");
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Moving source code folder"});
            }
            DeepMove(Path.Combine(VanillaFolder, "src"), SourceCodePath);

            //move the mod template to the sourcemods folder
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Moving install folder"});
            }
            ModFullPath = Path.Combine(Steam.SourceModPath, Dialog.FolderName);
            DeepMove(Path.Combine(VanillaFolder, "game" , VanillaModFolder), ModFullPath);

            //Clean up the extracted folders
            Directory.Delete(VanillaFolder, true);

            //Edit the gameinfo.txt
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Customizing gameinfo.txt"});
            }
            string GameinfoPath = Path.Combine(ModFullPath, "gameinfo.txt");
            KeyValues GameInfo = KeyValues.LoadFile(GameinfoPath);

            GameInfo.SetValue("game", Dialog.Title);
            GameInfo.SetValue("title", Dialog.Title);
            GameInfo.Save(GameinfoPath, System.Text.ASCIIEncoding.ASCII);

            Game = new SourceMod(ModFullPath);

            //name the translations file
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Naming translation file"});
            }
            string ResourceFolder = Path.Combine(ModFullPath, "resource");

            Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(Path.Combine(ResourceFolder, VanillaModFolder + "_english.txt"),
                Path.Combine(ResourceFolder, Dialog.FolderName + "_english.txt"));

            if (GetVisualStudioVersion() > 0)
            {
                CreateVisualStudioProjects(SourceCodePath);
            }

            BatchCreate_Exited(null, EventArgs.Empty);
        }

        int GetVisualStudioVersion()
        {
            if (Registry.GetValue("HKEY_CLASSES_ROOT\\VisualStudio.DTE.11.0", "", null) != null)
                return 2012;
            if (Registry.GetValue("HKEY_CLASSES_ROOT\\VisualStudio.DTE.10.0", "", null) != null)
                return 2010;
            if (Registry.GetValue("HKEY_CLASSES_ROOT\\VisualStudio.DTE.9.0", "", null) != null)
                return 2008;
            if (Registry.GetValue("HKEY_CLASSES_ROOT\\VisualStudio.DTE.8.0", "", null) != null)
                return 2005;

            return 0;
        }

        void CreateVisualStudioProjects(string SourceCodePath)
        {
            //Create project files
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Creating Visual Studio Projects"});
            }

            string VPCFileName = Path.Combine(SourceCodePath, "game/client/client_base.vpc");

            ProcessVPCFile(VPCFileName);
            VPCFileName = Path.Combine(SourceCodePath, "game/server/server_base.vpc");
            ProcessVPCFile(VPCFileName);

            ConfigureVisualStudioVersion(SourceCodePath);

            BatchCreate.StartInfo.FileName = Path.Combine(SourceCodePath, "createallprojects.bat");
            BatchCreate.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            BatchCreate.StartInfo.WorkingDirectory = SourceCodePath;
            BatchCreate.StartInfo.CreateNoWindow = true;

            BatchCreate.Start();
            BatchCreate.WaitForExit();
        }

        void ConfigureVisualStudioVersion(string SourceCodePath)
        {
            string BatchFileName = Path.Combine(SourceCodePath, "createallprojects.bat");
            string Content = File.ReadAllText(BatchFileName);

            Content = Content.Replace("vpc.exe ", "vpc.exe /" + GetVisualStudioVersion().ToString() + " ");
            File.Move(BatchFileName, BatchFileName + ".bak");

            using (StreamWriter BatchFile = new StreamWriter(BatchFileName))
            {
                BatchFile.Write(Content);
                BatchFile.Flush();
            }
        }

        void ProcessVPCFile(string VPCFileName)
        {
            if (!File.Exists(VPCFileName))
                return;

            string Content = File.ReadAllText(VPCFileName);

            Content = Content.Replace("$SRCDIR\\..\\game\\$GAMENAME\\bin", Path.Combine(Game.InstallPath, "bin"));

            File.Move(VPCFileName, VPCFileName + ".bak");

            using (StreamWriter VPCFile = new StreamWriter(VPCFileName))
            {
                VPCFile.Write(Content);
                VPCFile.Flush();
            }
        }

        private void BatchCreate_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (Failed != null)
            {
                Failed(this, "Failed to create Visual Studio Projects");
            }
        }

        //create a .user file for the server and client projects to begin debugging the mod
        private void ConfigureProjectsDebugging()
        {
            string SourceCodePath = Path.Combine(Dialog.SourcePath, "src");
            string ProjectsPath = Path.Combine(SourceCodePath, "game/client/");
            string[] ProjectFiles = Directory.GetFiles(ProjectsPath, "*.vcxproj");

            foreach (string ProjectFileName in ProjectFiles)
            {
                ConfigProjectDebug(ProjectFileName);
            }

            ProjectsPath = Path.Combine(SourceCodePath, "game/server/");
            ProjectFiles = Directory.GetFiles(ProjectsPath, "*.vcxproj");

            foreach (string ProjectFileName in ProjectFiles)
            {
                ConfigProjectDebug(ProjectFileName);
            }
        }

        //create a .user file for the named project with all the options to begin debugging the mod
        private void ConfigProjectDebug(string ProjectPath)
        {
            string gameExeFolder = Game.GameExeFolder();

            if (gameExeFolder == null) return;

            using (StreamWriter ProjectUser = new StreamWriter(ProjectPath + ".user"))
            {
                ProjectUser.Write(string.Format(Resources.CPP_UserTemplate, gameExeFolder, Game.InstallPath));

                ProjectUser.Flush();
            }
        }

        void AddSoloutionShortcut(string EverythingSoloutionPath)
        {
            string ModsFilePath = Path.Combine(Application.StartupPath, "options/mods.txt");
            KeyValues Mods = KeyValues.LoadFile(ModsFilePath);
            KeyValues ThisMod = new KeyValues(Dialog.FolderName, Mods);
            KeyValues ShortCuts = new KeyValues("Shortcuts", ThisMod);

            ShortCuts.SetValue("everything.sln", EverythingSoloutionPath);

            Mods.Save(ModsFilePath);
        }

        private void BatchCreate_Exited(object sender, System.EventArgs e)
        {
            string EverythingSoloutionPath = Path.Combine(Dialog.SourcePath, "src/everything.sln");

            if (File.Exists(EverythingSoloutionPath))
            {
                ConfigureProjectsDebugging();
                AddSoloutionShortcut(EverythingSoloutionPath);
            }

            //Setup the Source SDK
            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Configuring the SDK"});
            }
            SourceMod Game = new SourceMod(ModFullPath);
            SourceSDKSetupTool Helper = new SourceSDKSetupTool();
            string DefaultFGD = Dialog.ModType == ModTypes.HL2MP ? "hl2mp.fgd" : "halflife2.fgd";

            //add an FGD so the SetupSDK has something to add to Hammer
            Helper.FGDs.Add(Path.Combine(Game.SDKPath, DefaultFGD));

            Game.SourcePath = Dialog.SourcePath;

            try
            {
                Helper.SetupSDK(Game);
            }
            catch (ApplicationException ex)
            {
                if (ex.Message != "Unable to locate the path to the Source SDK")
                    throw ex;
            }

            if (Progress != null)
            {
                Progress(this, new ProgressEventArgs {msg = "Done"});
            }

            if (Finished != null)
            {
                Finished(this, Dialog.FolderName);
            }
        }
    }
}