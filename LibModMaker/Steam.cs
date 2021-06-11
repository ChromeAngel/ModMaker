using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using Microsoft.Win32;

namespace LibModMaker
{
    /// <summary>
    /// Model, query and operate on the installed Steam app
    /// </summary>
    public class Steam
    {
        public static bool IsNumeric(string subject)
        {
            double junk;

            return double.TryParse(subject, out junk);
        }


        private static string _path;

        private static string _user;


        /// <summary>
        /// The path to the folder where Steam is installed
        /// </summary>
        /// <exception cref="ApplicationException"></exception>
        public static string InstallPath
        {
            get
            {
                if (_path == null)
                {
                    object oRegEntry = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null);

                    if (oRegEntry == null)
                    {
                        //Cannot find the registry entry
                        //Take a guess at the default install folder
                        string defaultPath = "c:\\program files (x86)\\Steam\\";

                        if (Directory.Exists(defaultPath))
                        {
                            if (File.Exists(Path.Combine(defaultPath, "steam.exe")))
                            {
                                InstallPath = defaultPath;

                                return _path;
                            } 
                        }

                        //try the 64bit version...
                        defaultPath = "c:\\program files\\Steam\\";

                        if (Directory.Exists(defaultPath))
                        {
                            if (File.Exists(Path.Combine(defaultPath, "steam.exe")))
                            {
                                InstallPath = defaultPath;

                                return _path;
                            }
                        }

                        throw new ApplicationException("Steam path not found");
                    }

                    _path = SourceFileSystem.FormatFolderPath(oRegEntry.ToString());
                }

                return _path;
            }
            set
            {
                if(!Directory.Exists(value)) throw new System.IO.DirectoryNotFoundException(string.Format("{0} not found", value));

                _path = value;
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", value);
            }
        }



        public static string User
        {
            get
            {
                if (_user == null)
                {
                    //this appears to be the only registry key with the steam user name in it
                    //actual this specifies where to install HL1 mods to
                    object oRegUser = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "ModInstallPath", null);

                    if(oRegUser == null) throw new ApplicationException("Steam username not known");

                    _user = oRegUser.ToString();

                    //if (_user == null)
                    //{
                    //    _user = InputBox("Please enter your Steam Username", "Steam Username", "");
                    //}
                    //else
                    //{
                    //    string SteamAppsPath = System.IO.Path.Combine(Path, "steamapps");

                    //    if (_user.Length < (SteamAppsPath.Length + "half-life".Length))
                    //    {
                    //        _user = InputBox("Please enter your Steam Username", "Steam Username", "");
                    //    }
                    //    else
                    //    {
                    //        _user = _user.Substring(SteamAppsPath.Length);
                    //        _user = _user.Substring(0, _user.Length - "half-life".Length);
                    //        _user = _user.Trim(System.IO.Path.DirectorySeparatorChar);
                    //        _user = _user.Trim(System.IO.Path.AltDirectorySeparatorChar);
                    //    }
                    //}
                }

                return _user;
            }
        }

        public static string UserPath
        {
            get { return SourceFileSystem.FormatFolderPath(Path.Combine(InstallPath, "steamapps", User)); }
        }

        public static string SourceModPath
        {
            get
            {
                object oPath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SourceModInstallPath", null);

                if (oPath == null)
                {
                    return SourceFileSystem.FormatFolderPath(Path.Combine(InstallPath, "SteamApps", "SourceMods"));
                }
                else
                {
                    return oPath.ToString();
                }
            }
        }

        public static string CommonPath
        {
            get { return SourceFileSystem.FormatFolderPath(Path.Combine(InstallPath, "SteamApps", "Common")); }
        }

        public static string ExePath
        {
            get { return Path.Combine(InstallPath, "steam.exe"); }
        }

        public static Icon Icon
        {
            get { return Icon.ExtractAssociatedIcon(ExePath); }
        }

        public static List<SourceMod> SourceMods
        {
            get
            {
                List<SourceMod> Result = new List<SourceMod>();
                string[] Folders;
                try
                {
                    Folders = Directory.GetDirectories(SourceModPath);
                }
                catch (ApplicationException)
                {
                    return Result;
                }

                foreach (string Folder in Folders)
                {
                    if (File.Exists(Path.Combine(Folder, "GameInfo.txt")))
                    {
                        Result.Add(new SourceMod(Folder));
                    }
                }

                return Result;
            }
        }

        /// <summary>
        /// Get a list of the installed steam app paths
        /// </summary>
        /// <returns>list of installation paths, keyed by AppID</returns>
        /// <remarks></remarks>
        public static Dictionary<int, string> InstalledApps()
        {
            Dictionary<int, string> Result = new Dictionary<int, string>();
            string ConfigPath;

            try
            {
                ConfigPath = Path.Combine(Steam.InstallPath, "config/config.vdf");
            }
            catch (ApplicationException)
            {
                return Result; //Cannot find the Steam installation, return an empty set
            }

            if (!File.Exists(ConfigPath)) return Result;

            KeyValues Config = KeyValues.LoadFile(ConfigPath);

            if (Config == null) return Result;

            KeyValues SteamConfig = Config.GetKey("Software").GetKey("Valve").GetKey("steam");
            string BaseInstallFolder = Steam.InstallPath;
            string CommonFolder;
            int InstallFolderIndex = 0;

            while (BaseInstallFolder != null)
            {
                if (!Directory.Exists(BaseInstallFolder))
                {
                    InstallFolderIndex += 1;
                    BaseInstallFolder = SteamConfig.GetString("BaseInstallFolder_" + InstallFolderIndex.ToString(), null);

                    if (!string.IsNullOrEmpty(BaseInstallFolder))
                        BaseInstallFolder = BaseInstallFolder.Replace("\\\\", "\\");

                    continue;
                }

                BaseInstallFolder = Path.Combine(BaseInstallFolder, "SteamApps");
                CommonFolder = Path.Combine(BaseInstallFolder, "common");

                string[] Manifests = Directory.GetFiles(BaseInstallFolder, "appmanifest_*.acf");

                foreach (var ManifestPath in Manifests)
                {
                    KeyValues Manifest = KeyValues.LoadFile(ManifestPath);

                    if (Manifest == null)
                        continue;

                    int appID = Manifest.GetInt("appID");
                    string installPath = Path.Combine(CommonFolder, Manifest.GetString("InstallDir"));

                    if (appID == 0 || string.IsNullOrEmpty(installPath))
                        continue;

                    if (Result.ContainsKey(appID))
                    {
                        Debug.WriteLine("Multiple installations of app #{0} found at {1} and {2}", appID, Result[appID], installPath);
                        Result[appID] = installPath;
                    } else
                    {
                        Result.Add(appID, installPath);
                    }

                    
                }

                InstallFolderIndex += 1;
                BaseInstallFolder = SteamConfig.GetString("BaseInstallFolder_" + InstallFolderIndex.ToString(), null);

                if (!string.IsNullOrEmpty(BaseInstallFolder))
                    BaseInstallFolder = BaseInstallFolder.Replace("\\\\", "\\");
            }

            return Result;
        }

        /// <summary>
        /// Return the full path where the specified app is installed
        /// </summary>
        /// <param name="AppID">ID number that identifies an app , ie 211 for Source SDK</param>
        /// <returns>full path where the specified app is installed or Nothing if it cannot be found</returns>
        /// <remarks></remarks>
        public static string AppPath(int AppID)
        {
            string BaseInstallFolder = Steam.InstallPath;
            int InstallFolderIndex = 0;
            KeyValues SteamConfig = null;

            while (BaseInstallFolder != null)
            {
                BaseInstallFolder = Path.Combine(BaseInstallFolder, "SteamApps");

                string ManifestPath = Path.Combine(BaseInstallFolder, "appmanifest_" + AppID.ToString() + ".acf");

                if (File.Exists(ManifestPath))
                {
                    KeyValues Manifest = KeyValues.LoadFile(ManifestPath);

                    return System.IO.Path.Combine(BaseInstallFolder, "common",Manifest.GetString("InstallDir"));
                }

                if (SteamConfig == null)
                {
                    string ConfigPath;

                    try
                    {
                        ConfigPath = Path.Combine(Steam.InstallPath, "config/config.vdf");
                    }
                    catch (ApplicationException)
                    {
                        return null; //Steam is not installed
                    }

                    if (!File.Exists(ConfigPath)) return null;

                    KeyValues Config = KeyValues.LoadFile(ConfigPath);

                    if (Config == null) return null;

                    SteamConfig = Config.GetKey("Software").GetKey("Valve").GetKey("steam");

                    if (SteamConfig == null) return null;
                }

                InstallFolderIndex += 1;
                BaseInstallFolder = SteamConfig.GetString("BaseInstallFolder_" + InstallFolderIndex.ToString(), null);

                if (!string.IsNullOrEmpty(BaseInstallFolder))
                    BaseInstallFolder = BaseInstallFolder.Replace("\\\\", "\\");
            }

            return null;
        }

        /// <summary>
        /// Is Steam running?
        /// </summary>
        /// <returns>true if the Steam process is running</returns>
        public static bool IsRunning()
        {
            Process[] processes = Process.GetProcesses();
            foreach(var p in processes)
            {
                if (p.ProcessName == "Steam") return true;

                Debug.WriteLine(p.ProcessName);
            }

            return false;
        }


        /// <summary>
        /// Start steam
        /// </summary>
        public static void Launch()
        {
            Process.Start(ExePath);
        }

        public static void InstallApp(int AppID)
        {
            Process.Start(ExePath, "steam://install/" + AppID);
        }

        public static void LaunchApp(string AppID)
        {
            Process.Start(ExePath, "-applaunch " + AppID);
        }

        public static void Shutdown()
        {
            Process.Start(ExePath, "-shutdown");
        }
    } //end class
}