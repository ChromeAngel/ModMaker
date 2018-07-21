using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using LibModMaker;

namespace warHammer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Is Steam installed?
            try
            {
                if (Steam.ExePath == null)
                {
                    Exclaim(string.Format("{0} cannot find your Steam installation.  Steam must be installed to use {0}",Application.ProductName), "Steam not found");
                }
            }
            catch (ApplicationException)
            {
                Exclaim(string.Format("{0} cannot find your Steam installation.  Steam must be installed to use {0}", Application.ProductName), "Steam not found");
            }

            SourceMod Game = null;

            //Get the gameinfo for this mod
            if (args.Length == 2 && args[0] == "-game" && Directory.Exists(args[1]))
            {
                //specify the mod folder with the -game command line arguments
                Game = new SourceMod(args[1]);
            }
            else
            {
                var BinPath = Application.StartupPath;
                var InstallPathInfo = Directory.GetParent(BinPath); //Assume we're in the mod's /bin folder
                Game = new SourceMod(InstallPathInfo.FullName);
            }

            //Check the mods GameInfo exists
            if (!File.Exists(Game.GameInfoPath))
            {
                Exclaim(
                    string.Format("{0} is expecting {1} , but could not find it.", Application.ProductName, Game.GameInfoPath),
                    "GameInfo not found"
                 );
            }

            //Check where the base game is installed
            string AppPath = Steam.AppPath(Game.AppId);

            if (AppPath == null)
            {
                if (
                    MessageBox.Show(
                        string.Format("The game {0} is based on is not installed.  Would you like to install it now?",Game.Name), 
                        "Install?", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Question
                    ) == DialogResult.Cancel)
                {
                    Application.Exit();
                }

                Steam.InstallApp(Game.AppId);

                MessageBox.Show(
                    string.Format("Please restart {0} once the installation is complete", Application.ProductName),
                    "Restart required", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information
                 );
                Application.Exit();
            }

            //Check if hammer is in the base game's /bin folder as we expect
            string HammerPath = Path.Combine(AppPath, "bin", "hammer.exe");

            if (!File.Exists(HammerPath))
            {
                Exclaim( string.Format("{0} cannot find Hammer.  It was expected to be installed in {1}", Application.ProductName, HammerPath), "Hammer not found");
            }

            //Check if it's configured for this mod
            Launcher launcher = new Launcher();
            launcher.Game = Game;

            if (!launcher.IsSDKConfigured())
            {
                launcher.SetupSDK();
            }

            //Launch Hammer
            launcher.LaunchHammer();
        }

        private static void Exclaim(string message, string title)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
                );
            Application.Exit();
        }
    }
}
