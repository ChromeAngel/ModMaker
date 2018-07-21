using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{

    /// <summary>
    /// Tool for launching the FGD editor for the given game
    /// </summary>
    public class FGD_Tool : iTool
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

                Image Result = HammerIcon.ToBitmap();

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

            FGDForm Dialog = new FGDForm {Game = Game};

            Dialog.Show();
        }

        public string Name
        {
            get { return "FGD Editor"; }
        }

        public string TipText
        {
            get { return "Edit Forge Game Data (FGD) files for Hammer"; }
        }

        public System.Drawing.Icon GetHammerIcon()
        {
            if (!_game.HasSDKInstalled())
                return null;

            string HammerExe = Path.Combine(_game.SDKPath, "hammer.exe");

            if (!File.Exists(HammerExe))
                return null;

            return System.Drawing.Icon.ExtractAssociatedIcon(HammerExe);
        }
    }

}