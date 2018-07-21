using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LibModMaker;
using Microsoft.VisualBasic;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// Tool to confugure the SDK (and Hammer specifically) to work with this game
    /// </summary>
    public class SourceSDKSetupTool : iTool, InstallScriptMaker.iPrereqisite
    {

        public System.Drawing.Image Image
        {
            get { return Properties.Resources.orange_install.ToBitmap(); }
        }

        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            return Game.HasSDKInstalled();
        }

        public string Name
        {
            get { return "Setup Source SDK"; }
        }

        public string TipText
        {
            get { return "Configures the Source SDK for this mod"; }
        }

        public void Launch(LibModMaker.SourceMod Game)
        {
            var Dialog = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = "Please select the folder where this mods Source is kept",
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // My.Computer.FileSystem.SpecialDirectories.MyDocuments
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            Game.SourcePath = Dialog.SelectedPath;

            SetupSDK(Game);

            if (Game.ToolsAppId == 211)
            {
                if (
                    Interaction.MsgBox("Done.  Run the Source SDK now?", MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                        "Source SDK Setup") == MsgBoxResult.No)
                    return;

                Steam.LaunchApp("211");
            }
            else
            {
                Interaction.MsgBox("SDK Setup Complete", MsgBoxStyle.Information, "Source SDK Setup");
            }
        }


        public List<string> FGDs = new List<string>();

        public void SetupSDK(SourceMod Game)
        {
            string SDKConfigFile = Path.Combine(Game.SDKPath, "GameConfig.txt");
            KeyValues SDKConfig = KeyValues.LoadFile(SDKConfigFile);
            string GameExeDir = Game.GameExeFolder();
            KeyValues Temp;
            KeyValues Games;

            if (SDKConfig == null)
            {
                SDKConfig = new KeyValues("Configs");
                Temp = new KeyValues("SDKVersion", Game.GetSDKVersion(), SDKConfig);
            }

            Games = SDKConfig["Games"];

            if (Games == null)
            {
                Games = new KeyValues("Games", SDKConfig);
            }

            KeyValues ModKey = Games.GetKey(Game.Name);

            if (ModKey == null)
            {
                ModKey = new KeyValues(Game.Name, Games);
            }

            KeyValues Hammer = new KeyValues("hammer", ModKey);

            Temp = new KeyValues("GameDir", Game.InstallPath.TrimEnd('\\'), ModKey);

            Hammer.SetValue("TextureFormat", "5");
            Hammer.SetValue("MapFormat", "4");
            Hammer.SetValue("DefaultTextureScale", "0.250000");
            Hammer.SetValue("DefaultLightmapScale", "16");
            Hammer.SetValue("DefaultSolidEntity", "func_detail");
            Hammer.SetValue("DefaultPointEntity", "info_player_start");
            Hammer.SetValue("GameExeDir", GameExeDir.TrimEnd('\\'));
            Hammer.SetValue("MapDir", Path.Combine(Game.SourcePath, "mapsrc"));
            Hammer.SetValue("CordonTexture", "tools\\toolsskybox");
            Hammer.SetValue("MaterialExcludeCount", "0");
            Hammer.SetValue("GameExe", Path.Combine(GameExeDir, "hl2.exe"));
            Hammer.SetValue("BSP", Path.Combine(Game.SDKPath, "vbsp.exe"));
            Hammer.SetValue("Vis", Path.Combine(Game.SDKPath, "vvis.exe"));
            Hammer.SetValue("Light", Path.Combine(Game.SDKPath, "vrad.exe"));
            Hammer.SetValue("BSPDir", Path.Combine(Game.InstallPath, "maps"));

            int GameDataIndex = 0;

            FGDs.AddRange(Directory.GetFiles(Game.InstallPath, "*.fgd"));

            foreach (string File in FGDs)
            {
                Hammer.SetValue("GameData" + GameDataIndex.ToString(), File);
                GameDataIndex += 1;
            }

            FGDs.Clear();

            SourceFileSystem.BackUpFile(SDKConfigFile);

            SDKConfig.Save(SDKConfigFile, System.Text.Encoding.ASCII);
        }

        public bool Test(LibModMaker.SourceMod Subject)
        {
            if (Subject.SourcePath == null)
                Launch(Subject);

            return Directory.Exists(Subject.SourcePath);
        }
    }

}