using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace ModMaker
{
    /// <summary>
    /// Tool to launch the HL model viewer for a given game
    /// </summary>
    public class ModelViewerTool : iTool
    {
        private SourceMod _game = null;

        public System.Drawing.Image Image
        {
            get
            {
                if (_game == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                if (!HasHLMV())
                    return null;

                return System.Drawing.Icon.ExtractAssociatedIcon(HLMVPath).ToBitmap();
            }
        }

        public bool HasHLMV()
        {
            return File.Exists(HLMVPath);
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            _game = Game;

            return HasHLMV();
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            _game = Game;
            ProcessStartInfo S = new ProcessStartInfo
            {
                FileName = HLMVPath,
                Arguments = "-game \"" + Game.InstallPath.TrimEnd('/').TrimEnd('\\') + "\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            S.EnvironmentVariables["VProject"] = _game.InstallPath.TrimEnd('/').TrimEnd('\\');
            S.EnvironmentVariables["VPPROJECT"] = _game.InstallPath.TrimEnd('/').TrimEnd('\\');

            Process.Start(S);
        }

        public string Name
        {
            get { return "Model Viewer"; }
        }

        public string TipText
        {
            get { return "Launch the Model Viewer"; }
        }

        private string HLMVPath
        {
            get
            {
                string AppPath = Steam.AppPath(_game.AppId);

                if (AppPath == null)
                    return null;

                return Path.Combine(Path.Combine(AppPath, "bin"), "hlmv.exe");
            }
        }
    }

}