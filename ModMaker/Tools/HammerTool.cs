using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace ModMaker
{

    /// <summary>
    /// Launch the Valve Hammer for the given game
    /// </summary>
    public class HammerTool : iTool
    {
        private SourceMod _game = null;

        public Image Image
        {
            get
            {
                if (_game == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                Icon HammerIcon = GetHammerIcon();

                if (HammerIcon == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                return HammerIcon.ToBitmap();
            }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            _game = Game;

            return HasHammer();
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            _game = Game;
            LaunchHammer();
        }

        public string Name
        {
            get { return "Hammer"; }
        }

        public string TipText
        {
            get { return "Launch the Valve Hammer"; }
        }

        private string HammerPath
        {
            get
            {
                string AppPath = Steam.AppPath(_game.AppId);

                if (AppPath == null)
                    return null;

                return Path.Combine(AppPath, "bin", "hammer.exe");
            }
        }

        public bool HasHammer()
        {
            return File.Exists(HammerPath);
        }

        public void LaunchHammer()
        {
            ProcessStartInfo S = new ProcessStartInfo
            {
                FileName = HammerPath,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            S.EnvironmentVariables["VProject"] = _game.InstallPath.TrimEnd('/').TrimEnd('\\');
            S.EnvironmentVariables["VPPROJECT"] = _game.InstallPath.TrimEnd('/').TrimEnd('\\');

            Process.Start(S);
        }

        public Icon GetHammerIcon()
        {
            if (!File.Exists(HammerPath))
                return null;

            return System.Drawing.Icon.ExtractAssociatedIcon(HammerPath);
        }
    }

}