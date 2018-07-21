using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{
    /// <summary>
    /// A Tool to install the Software Development Kit (SDK) for this game's version of Source (so that modmaker can act as a launcher for much of it's functionality
    /// </summary>
    public class SDKInstallTool : iTool
    {

        public System.Drawing.Image Image
        {
            get { return Steam.Icon.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return !Game.HasSDKInstalled();
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            Steam.InstallApp(Game.ToolsAppId);
        }

        public string Name
        {
            get { return "Install Source SDK"; }
        }

        public string TipText
        {
            get { return "Installs the version of the Source SDK used by this mod"; }
        }
    }

}