using LibModMaker;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace ModMaker
{

    /// <summary>
    /// Tool for launching the Face Poser tool for the given game
    /// </summary>
    public class FacePoserTool : iTool
    {
        private SourceMod _game = null;

        public System.Drawing.Image Image
        {
            get
            {
                if (_game == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                Icon ToolIcon = GetToolIcon();

                if (ToolIcon == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                return ToolIcon.ToBitmap();
            }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            _game = Game;

            return HasTool();
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            _game = Game;
            LaunchTool();
        }

        public string Name
        {
            get { return "Face Poser"; }
        }

        public string TipText
        {
            get { return "Launch the Valve Face Poser"; }
        }

        private string ToolPath
        {
            get
            {
                string AppPath = Steam.AppPath(_game.AppId);

                if (AppPath == null)
                    return null;

                return Path.Combine(Path.Combine(AppPath, "bin"), "hlfaceposer.exe");
            }
        }

        public bool HasTool()
        {
            return File.Exists(ToolPath);
        }

        public void LaunchTool()
        {
            var S = new ProcessStartInfo
            {
                FileName = ToolPath,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            S.EnvironmentVariables["VProject"] = _game.InstallPath.TrimEnd('/').TrimEnd('\\');
            S.EnvironmentVariables["VPPROJECT"] = _game.InstallPath.TrimEnd('/').TrimEnd('\\');

            Process.Start(S);
        }

        public Icon GetToolIcon()
        {
            if (!File.Exists(ToolPath))
                return null;

            return System.Drawing.Icon.ExtractAssociatedIcon(ToolPath);
        }
    }

}