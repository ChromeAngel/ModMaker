using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace ModMaker
{
    /// <summary>
    /// Experimental tool for launching an external map compiler 
    /// </summary>
    public class MapBuilderTool : iTool
    {
        private SourceMod _game = null;

        public System.Drawing.Image Image
        {
            get
            {
                if (_game == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                Image Result = GetHammerIcon().ToBitmap();

                if (Result == null)
                    return Properties.Resources.ModMaker.ToBitmap();

                return Result;
            }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            _game = Game;

            return true;
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            _game = Game;

            System.Diagnostics.Process _Process = new System.Diagnostics.Process();

            _Process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            _Process.StartInfo.FileName = "MapBuilder.exe";
            _Process.StartInfo.Arguments = "-game \"" + Game.InstallPath + "\"";
            _Process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            _Process.StartInfo.UseShellExecute = true;

            _Process.Start();
            _Process.WaitForExit();
        }

        public string Name
        {
            get { return "Map Builder"; }
        }

        public string TipText
        {
            get { return "Compile maps outside Hammer"; }
        }

        public System.Drawing.Icon GetHammerIcon()
        {
            string HammerExe = Path.Combine(_game.SDKPath, "hammer.exe");

            if (!File.Exists(HammerExe))
                return null;

            return System.Drawing.Icon.ExtractAssociatedIcon(HammerExe);
        }
    }

}