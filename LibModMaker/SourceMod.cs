using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace LibModMaker
{
    /// <summary>
    /// Represtenation of a mod running on the Source engine game
    /// </summary>
    public class SourceMod : SourceGame
    {
        public SourceMod() : base()
        {
        }

        public SourceMod(string GamePath)
        {
            InstallPath = SourceFileSystem.FormatFolderPath(GamePath);
            _GameInfo = KeyValues.LoadFile(GameInfoPath);
        }

        public override int AppId
        {
            get
            {
                return (_GameInfo["FileSystem"]).GetInt("SteamAppId", (_GameInfo["FileSystem"]).GetInt("AppId", 218));
            }
        }

        public override void Play(string Arguments = "")
        {
            Process.Start(Steam.ExePath,
                string.Format("-applaunch {0} -game \"{1}\" {2}", AppId, InstallPath, Arguments));
        }


        protected override string GetSDKPath(string RootFolder, string SDKVersion)
        {
            string Result = RootFolder;
            Dictionary<int, string> Apps = Steam.InstalledApps();
            string AppPath = Steam.AppPath(ToolsAppId);

            switch (SDKVersion)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                    // classic SDK
                    if (AppPath == null)
                        AppPath = Environment.GetEnvironmentVariable("sourcesdk");
                    //fallback to the env var
                    if (AppPath == null)
                        AppPath = RootFolder;
                    //Fail! Fallback!

                    Result = Path.Combine(AppPath, "bin");

                    switch (SDKVersion)
                    {
                        case "2":
                            Result = Path.Combine(Result, "ep1");
                            break;
                        case "3":
                            Result = Path.Combine(Result, "source2007"); break;
                        case "4":
                            Result = Path.Combine(Result, "source2009"); break;
                        case "5":
                            Result = Path.Combine(Result, "orangebox"); break;
                    }
                    break;
                case "6":
                    //base 2013 SP

                    Result = AppPath;
                    break;
                //If Result Is Nothing Then Result = Path.Combine(Result, "Source SDK Base 2013 Singleplayer")
                case "7":
                    //base 2013 MP

                    Result = AppPath;
                    break;
                    //If Result Is Nothing Then Result = Path.Combine(Result, "Source SDK Base 2013 Multiplayer")
            }

            if (Result == null)
            {
                return RootFolder;
            }

            //Fail! Fallback!

            Result = Path.Combine(Result, "bin");

            return Result;
        }

    }//end class

}