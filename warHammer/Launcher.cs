using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibModMaker;
using System.IO;
using System.Diagnostics;

namespace warHammer
{
    class Launcher
    {
        public SourceMod Game;
        private string HammerPath
        {
            get
            {
                string AppPath = Steam.AppPath(Game.AppId);

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

            S.EnvironmentVariables["VProject"] = Game.InstallPath.TrimEnd('/').TrimEnd('\\');
            S.EnvironmentVariables["VPPROJECT"] = Game.InstallPath.TrimEnd('/').TrimEnd('\\');

            Process.Start(S);
        }

        private string _GameConfigPath = null;

        private KeyValues GetGameConfig()
        {
            _GameConfigPath = Path.Combine(Game.SDKPath, "GameConfig.txt");
            KeyValues result = KeyValues.LoadFile(_GameConfigPath);

            if (result == null)
            {
                result = new KeyValues("Configs");
                var temp = new KeyValues("SDKVersion", Game.GetSDKVersion(), result);

                result.Save(_GameConfigPath);
            }

            return result;
        }

        private KeyValues GetModConfig()
        {
            KeyValues SDKConfig = GetGameConfig();
            KeyValues Games = SDKConfig["Games"];

            if (Games == null)
            {
                Games = new KeyValues("Games", SDKConfig);
                SDKConfig.Save(_GameConfigPath);
            }

            return Games[Game.Name];
        }

        public bool IsSDKConfigured()
        {
            KeyValues modConfig = GetModConfig();

            if (modConfig == null) return false;
            if (string.IsNullOrEmpty(modConfig.GetString("GameDir"))) return false;

            return true;
        }

        public void SetupSDK()
        {
            string gameExeDir = Game.GameExeFolder();
            KeyValues Temp = null;
            KeyValues Games = null;
            KeyValues ModKey = GetModConfig();
            KeyValues Hammer = null;

            if (ModKey == null)
            {
                KeyValues SDKConfig = GetGameConfig();
                Games = SDKConfig["Games"];

                if (Game == null) Games = new KeyValues("Games", SDKConfig);

                ModKey = new KeyValues(Game.Name, Games);
                Hammer = new KeyValues("hammer", ModKey);
            }
            else
            {
                Hammer = ModKey["hammer"];
            }

            Temp = new KeyValues("GameDir", Game.InstallPath.TrimEnd('\\'), ModKey);

            Hammer.SetValue("TextureFormat", "5");
            Hammer.SetValue("MapFormat", "4");
            Hammer.SetValue("DefaultTextureScale", "0.250000");
            Hammer.SetValue("DefaultLightmapScale", "16");
            Hammer.SetValue("DefaultSolidEntity", "func_detail");
            Hammer.SetValue("DefaultPointEntity", "info_player_start");
            if(gameExeDir != null) Hammer.SetValue("GameExeDir", gameExeDir.TrimEnd('\\'));
            Hammer.SetValue("MapDir", Path.Combine(Game.SourcePath, "mapsrc"));
            Hammer.SetValue("CordonTexture", "tools\\toolsskybox");
            Hammer.SetValue("MaterialExcludeCount", "0");
            if (gameExeDir != null) Hammer.SetValue("GameExe", Path.Combine(gameExeDir, "hl2.exe"));
            Hammer.SetValue("BSP", Path.Combine(Game.SDKPath, "vbsp.exe"));
            Hammer.SetValue("Vis", Path.Combine(Game.SDKPath, "vvis.exe"));
            Hammer.SetValue("Light", Path.Combine(Game.SDKPath, "vrad.exe"));
            Hammer.SetValue("BSPDir", Path.Combine(Game.InstallPath, "maps"));

            int GameDataIndex = 0;
            var FGDs = new List<string>();

            FGDs.AddRange(Directory.GetFiles(Game.InstallPath, "*.fgd"));

            foreach(string filePath in FGDs)
            {
                Hammer.SetValue(string.Format("GameData{0}", GameDataIndex), filePath);
                GameDataIndex += 1;
            }

            FGDs.Clear();

            SourceFileSystem.BackUpFile(_GameConfigPath);

            ModKey.Parent.Parent.Save(_GameConfigPath, System.Text.Encoding.ASCII);
        }
    }
}
