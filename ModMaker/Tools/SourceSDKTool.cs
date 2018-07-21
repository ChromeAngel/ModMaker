using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{
    /// <summary>
    /// Tool for launching the old (2007) Source SDK
    /// </summary>
    public class SourceSDKTool : iTool
    {
        private SourceMod _game;

        public System.Drawing.Image Image
        {
            get
            {
                Icon ExeIcon = Icon.ExtractAssociatedIcon(GetExePath());

                if (ExeIcon == null)
                    ExeIcon = Steam.Icon;

                return ExeIcon.ToBitmap();
            }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            _game = Game;

            if (int.Parse( _game.GetSDKVersion()) > 5)
                return false;

            if (GetExePath() == null)
                return false;

            return true;
        }


        public void Launch(LibModMaker.SourceMod Game)
        {
            Steam.LaunchApp(Game.ToolsAppId.ToString());
        }

        public string Name
        {
            get { return "Source SDK"; }
        }

        public string TipText
        {
            get { return "Launch the Source SDK"; }
        }

        private string GetExePath()
        {
            try
            {
                string SDKEnvVar = _game.SDKPath;
                string Result = Path.Combine(SDKEnvVar, "SDKLauncher.exe");

                if (File.Exists(Result)) return Result;

                Result = Path.Combine(Steam.CommonPath, "SourceSDK", "bin", "SDKLauncher.exe");

                if (File.Exists(Result)) return Result;

                Result = Path.Combine(Steam.UserPath, "SourceSDK", "bin", "SDKLauncher.exe");

                if (File.Exists(Result)) return Result;

            }
            catch (ApplicationException)
            {
                return null;
            }

            return null;
        } //end GetExePath
    } //end class

}