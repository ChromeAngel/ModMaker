using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Diagnostics;

namespace LibModMaker
{

    /// <summary>
    /// Represtenation of a Source engine game
    /// </summary>
    public class SourceGame
    {

        public string InstallPath;
        protected int _AppID;
        protected KeyValues _GameInfo;
        protected Bitmap _Icon;
        protected Bitmap _BigIcon;
        protected Bitmap _GameIcon;
        protected string _SourcePath = null;
        protected string _gameExeFolder = null;

        protected Localization _Localization = null;

        /// <summary>
        /// Emptyt constructor, because you never know when you're going to need an instance for testing
        /// </summary>
        public SourceGame()
        {
        }

        /// <summary>
        /// Constructor that takes a Steam AppID as it's paramameter, the expected way to initialise an instance of this class
        /// </summary>
        /// <param name="AppID"></param>
        public SourceGame(int AppID)
        {
            _AppID = AppID;
            InstallPath = Steam.AppPath(AppID);
            _GameInfo = KeyValues.LoadFile(GameInfoPath);
        }

        public string Name
        {
            get { return _GameInfo.GetString("game", Path.GetFileName(InstallPath)); }
        }

        public string Developer
        {
            get { return _GameInfo.GetString("developer", null); }
        }

        public string DeveloperURL
        {
            get { return _GameInfo.GetString("developer_url", null); }
        }

        /// <summary>
        /// Steam AppID for this game
        /// </summary>
        public virtual int AppId
        {
            get { return _AppID; }
        }


        /// <summary>
        /// AppID for the tools/SDK for this game
        /// </summary>
        public int ToolsAppId
        {
            get
            {
                return (_GameInfo["FileSystem"]).GetInt("ToolsAppId",
                    (_GameInfo["FileSystem"]).GetInt("SteamAppId", 211));
            }
        }

        /// <summary>
        /// Path to the gameinfo file
        /// </summary>
        public string GameInfoPath
        {
            get { return Path.Combine(InstallPath, "gameinfo.txt"); }
        }

        /// <summary>
        /// Get the name of the sourcemods folder where this mod is installed
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks>just the folder name, not the full path (use InstallPath for that)</remarks>
        public string InstallFolder
        {
            get
            {
                return
                    Path.GetFileName(
                        InstallPath.TrimEnd(Path.DirectorySeparatorChar).TrimEnd(Path.AltDirectorySeparatorChar));
            }
        }

        #region "Icon Properties"

        public string IconPath
        {
            get
            {
                string Result = Path.Combine(InstallPath, _GameInfo.GetString("icon", Name)) + ".tga";

                if (File.Exists(Result))
                    return Result;

                return null;
            }
        }

        public string BigIconPath
        {
            get
            {
                string Result = Path.Combine(InstallPath, _GameInfo.GetString("icon", Name)) + "_big.tga";

                if (File.Exists(Result))
                    return Result;

                return null;
            }
        }

        public string GameIconPath
        {
            get
            {
                string Result = Path.Combine(InstallPath, "resource\\game.ico");

                if (File.Exists(Result))
                    return Result;

                return null;
            }
        }

        public Bitmap Icon
        {
            get
            {
                if (_Icon == null && IconPath != null)
                {
                    //Dim Img As New TGA(IconPath)
                    try
                    {
                        _Icon = Paloma.TargaImage.LoadTargaImage(IconPath);
                        //Img.Bitmap
                    }
                    catch (Exception)
                    {
                        _Icon = null;
                    }
                }

                return _Icon;
            }
        }

        public Bitmap BigIcon
        {
            get
            {
                if (_BigIcon == null && BigIconPath != null)
                {
                    try
                    {
                        _BigIcon = Paloma.TargaImage.LoadTargaImage(BigIconPath);
                        //Img.Bitmap
                    }
                    catch (Exception)
                    {
                        _BigIcon = null;
                    }
                }

                return _BigIcon;
            }
        }

        public Bitmap GameIcon
        {
            get
            {
                if (_GameIcon == null)
                {
                    try
                    {
                        string IconPath = GameIconPath;

                        if (IconPath != null)
                        {
                            Icon Buffer = new Icon(IconPath);

                            _GameIcon = Buffer.ToBitmap();
                        }
                    }
                    catch (Exception)
                    {
                        _GameIcon = null;
                    }

                }

                return _GameIcon;
            }
        }

        public Bitmap DefaultIcon
        {
            get
            {
                Bitmap Result = GameIcon;

                if (Result == null)
                    Result = BigIcon;
                if (Result == null)
                    Result = Icon;
                if (Result == null)
                    Result = Steam.Icon.ToBitmap();

                if (Result.Width != 32 || Result.Height != 32)
                {
                    Bitmap Work = new Bitmap(32, 32, PixelFormat.Format32bppArgb);
                    Graphics Gfx = Graphics.FromImage(Work);

                    Gfx.Clear(Color.Transparent);
                    Gfx.DrawImage(Result, new Rectangle(0, 0, 32, 32));
                    Gfx.Flush();
                    Result = Work;
                }

                return Result;
            }
        }

        #endregion // Icon Properties 

        public void SetIcon(string FilePath)
        {
            Bitmap SourceImg = null;

            switch (Path.GetExtension(FilePath))
            {
                case ".tga":
                    SourceImg = Paloma.TargaImage.LoadTargaImage(FilePath);
                    break;
                case ".ico":
                    System.Drawing.Icon Ico = new System.Drawing.Icon(FilePath);
                    SourceImg = Ico.ToBitmap();
                    break;
                default:
                    SourceImg = new Bitmap(FilePath);
                    break;
            }

            if (SourceImg == null)
                return;

            Bitmap BigImg = new Bitmap(32, 32, PixelFormat.Format32bppArgb);
            string BigPath = Path.Combine(InstallPath, InstallFolder + "_big.tga");
            Bitmap SmallImg = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
            string SmallPath = Path.Combine(InstallPath, InstallFolder + ".tga");
            Graphics Gfx = Graphics.FromImage(BigImg);

            Gfx.Clear(Color.Transparent);
            Gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            Gfx.DrawImage(SourceImg, 0, 0, 32, 32);
            Gfx.Flush();

            TGA BigTGA = new TGA();
            BigTGA.Bitmap = BigImg;
            BigTGA.Save(BigPath);

            System.IntPtr iconHandle = BigImg.GetHicon();
            System.Drawing.Icon GameIco = System.Drawing.Icon.FromHandle(iconHandle);

            using (
                FileStream SW = new FileStream(Path.Combine(InstallPath, "resource\\game.ico"),
                    FileMode.Create))
            {
                GameIco.Save(SW);
            }

            Gfx = Graphics.FromImage(SmallImg);
            Gfx.Clear(Color.Transparent);
            Gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            Gfx.DrawImage(SourceImg, 0, 0, 16, 16);
            Gfx.Flush();

            TGA SmallTGA = new TGA();
            SmallTGA.Bitmap = SmallImg;
            SmallTGA.Save(SmallPath);

            KeyValues GameInfoIcon = new KeyValues("icon", InstallFolder, _GameInfo);

            _GameInfo.Save(GameInfoPath, System.Text.ASCIIEncoding.ASCII);
        }

        public bool SetLogo(string FilePath)
        {
            if (!PrepareLogoMaterial(FilePath))
                return false;

            KeyValues ResFile = new KeyValues("Resource/GameLogo.res");
            KeyValues GameLogo = new KeyValues("GameLogo", ResFile);

            GameLogo.SetValue("ControlName", "EditablePanel");
            GameLogo.SetValue("fieldName", "GameLogo");
            GameLogo.SetValue("xpos", "0");
            GameLogo.SetValue("ypos", "0");
            GameLogo.SetValue("zpos", "50");
            GameLogo.SetValue("autoResize", "1");
            GameLogo.SetValue("pinCorner", "0");
            GameLogo.SetValue("visible", "1");
            GameLogo.SetValue("enabled", "1");
            GameLogo.SetValue("offsetX", "-20");
            GameLogo.SetValue("offsetY", "-15");
            GameLogo.SetValue("wide", "400");
            GameLogo.SetValue("tall", "100");

            KeyValues Logo = new KeyValues("Logo", ResFile);
            Logo.SetValue("ControlName", "ImagePanel");
            Logo.SetValue("fieldName", "Logo");
            Logo.SetValue("xpos", "0");
            Logo.SetValue("ypos", "0");
            Logo.SetValue("zpos", "50");
            Logo.SetValue("scaleImage", "1");
            Logo.SetValue("visible", "1");
            Logo.SetValue("enabled", "1");
            Logo.SetValue("image", "logo/" + InstallFolder);
            Logo.SetValue("wide", "400");
            Logo.SetValue("tall", "100");

            ResFile.Save(Path.Combine(InstallFolder, "Resource/GameLogo.res"));

            return true;
        }

        bool PrepareLogoMaterial(string FilePath)
        {
            string Ext = Path.GetExtension(FilePath);

            if (!(Ext == ".tga" || Ext == ".psd"))
            {
                FilePath = VTFConverter.ConvertToTga(FilePath, Ext);
            }

            if (FilePath == null)
                return false;

            System.Diagnostics.Process Vtex = new System.Diagnostics.Process();
            string ResultFile = Path.Combine(this.InstallPath, "materials", "vgui", "logo", InstallFolder);

            Vtex.StartInfo.FileName = "vtex.exe";
            Vtex.StartInfo.Arguments = String.Format(
                "-outdir \"{0}\" -mkdir -quiet -shader UnlitGeneric \"{1}\"",
                ResultFile,
                FilePath
            );
            Vtex.StartInfo.CreateNoWindow = true;
            Vtex.StartInfo.WorkingDirectory = SDKPath;
            Vtex.StartInfo.UseShellExecute = false;

            Vtex.Start();
            Vtex.WaitForExit();

            return File.Exists(ResultFile + ".vmt");
        }

        /// <summary>
        /// Launch the game
        /// </summary>
        /// <param name="Arguments"></param>
        public virtual void Play(string Arguments = "")
        {
            Process.Start(Steam.ExePath, string.Format("-applaunch {0} {1}", AppId, Arguments));
        }

        public void Browse()
        {
            Process.Start('"' + InstallPath + '"');
        }


        /// <summary>
        /// Get metadata about apps that MM knows about from it's options/apps.txt
        /// </summary>
        /// <returns></returns>
        protected KeyValues GetApps()
        {
            KeyValues AppList = KeyValues.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "options/apps.txt"));

            if (AppList == null)
                throw new ApplicationException("missing options file apps.txt");

            return AppList;
        }

        public string GetSDKVersion()
        {
            KeyValues AppList = GetApps();
            KeyValues App = AppList[AppId.ToString()];

            if (App == null)
                return null;

            return App.GetString("sdkversion");
        }

        public string SDKPath
        {
            get
            {
                string SDKVersion = GetSDKVersion();
                string Result = GetSDKPath(Steam.CommonPath, SDKVersion);

                return SourceFileSystem.FormatFolderPath(Result);
            }
        }

        public bool HasSDKInstalled()
        {
            return (Steam.AppPath(ToolsAppId) != null);
        }

        protected virtual string GetSDKPath(string RootFolder, string SDKVersion)
        {
            string Result = RootFolder;
            Dictionary<int, string> Apps = Steam.InstalledApps();
            string AppPath = Steam.AppPath(ToolsAppId);

            switch (SDKVersion)
            {
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    // classic SDK
                    if (AppPath == null)
                        AppPath = Environment.GetEnvironmentVariable("sourcesdk");
                    //fallback to the env var
                    if (AppPath == null)
                        AppPath = RootFolder;
                    //Fail! Fallback!

                    Result = Path.Combine(AppPath, "bin");

                    switch (SDKVersion)
                    {
                        case "2":
                            Result = Path.Combine(Result, "ep1");
                            break;
                        case "3":
                            Result = Path.Combine(Result, "source2007"); break;
                        case "4":
                            Result = Path.Combine(Result, "source2009"); break;
                        case "5":
                            Result = Path.Combine(Result, "orangebox"); break;
                    }
                    break;
                case "6":
                    //base 2013 SP

                    Result = AppPath;
                    break;
                //If Result Is Nothing Then Result = Path.Combine(Result, "Source SDK Base 2013 Singleplayer")
                case "7":
                    //base 2013 MP

                    Result = AppPath;
                    break;
                    //If Result Is Nothing Then Result = Path.Combine(Result, "Source SDK Base 2013 Multiplayer")
            }

            if (Result == null)
                return RootFolder;
            //Fail! Fallback!

            Result = Path.Combine(Result, "bin");

            return Result;
        }

        public string SourcePath
        {
            get
            {
                if (_SourcePath == null)
                {
                    string SDKPath = this.SDKPath;

                    if (SDKPath == null)
                    {
                        throw new ApplicationException(string.Format("Path not found for version {0} of the SDK used by {1}", GetSDKVersion(),InstallFolder));
                    }

                    KeyValues SDKConfig = KeyValues.LoadFile(Path.Combine(SDKPath, "GameConfig.txt"));

                    if (SDKConfig == null)
                    {
                    }
                    else
                    {
                        if (SDKConfig["Games"] == null)
                        {
                        }
                        else
                        {
                            foreach (KeyValues Game in (SDKConfig["Games"]).Keys)
                            {
                                if (
                                    !InstallPath.StartsWith(Game.GetString("GameDir"),
                                        StringComparison.InvariantCultureIgnoreCase))
                                    continue;

                                KeyValues Hammer = Game["Hammer"];

                                if (Hammer == null)
                                    continue;

                                string MapPath = Hammer.GetString("MapDir");

                                if (string.IsNullOrEmpty(MapPath))
                                    continue;

                                DirectoryInfo DirInfo = new DirectoryInfo(MapPath);

                                _SourcePath = DirInfo.Parent.FullName;
                            }
                        }
                    }
                }

                return _SourcePath;
            }
            set { _SourcePath = value; }
        }

        public virtual string GameExeFolder()
        {
            if (_gameExeFolder != null) return _gameExeFolder;


            string bestGuess = Path.Combine(InstallFolder, "hl2.exe");

            if (File.Exists(bestGuess))
            {
                _gameExeFolder = InstallFolder;

                return _gameExeFolder;
            }

            var InstalledApps = Steam.InstalledApps();
            if (InstalledApps.ContainsKey(AppId))
            {
                _gameExeFolder = InstalledApps[AppId];
                return _gameExeFolder;
            }

            KeyValues AppList = GetApps();

            if (AppList == null) return null;

            //Steam.AppPath(AppId)

            string Result = AppList[AppId.ToString()].GetString("gameexe", "");
            string Common;

            try
            {
                Common = Steam.CommonPath;
            }
            catch (ApplicationException)
            {
                return null; //Can't find Steam install folder
            }

            if (Result.Length > 0)
            {
                string gameExe= null;

                try
                {
                    gameExe = string.Format(Result, Steam.UserPath, Common);
                }
                catch (ApplicationException ex)
                {
                    //Can't find Steam install folder, fall through to the SDK version based code
                }

                if (gameExe != null)
                {
                    _gameExeFolder = SourceFileSystem.FormatFolderPath(new FileInfo(gameExe).Directory.FullName);
                    return _gameExeFolder;
                }
            }

            switch (GetSDKVersion())
            {
                case "2":
                    _gameExeFolder = Path.Combine(Common, "half-life 2 deathmatch\\hl2mp\\");
                    break;
                case "3":
                case "4":
                case "5":
                    _gameExeFolder = Path.Combine(Common, "source sdk base 2007\\");
                    break;
                case "6":
                    _gameExeFolder = Path.Combine(Common, "Source SDK Base 2013 Singleplayer\\");
                    break;
                case "7":
                    _gameExeFolder = Path.Combine(Common, "Source SDK Base 2013 Multiplayer\\");
                    break;
                default:
                    throw new ApplicationException("Unable to deduce the correct SDK version to use with this mod");
            }

            return _gameExeFolder;
        }

        public List<string> GetSurfacePropertyNames()
        {
            List<string> result = new List<string>();
            string ManifestPath = Path.Combine(this.InstallPath, "scripts/surfaceproperties_manifest.txt");

            if (!File.Exists(ManifestPath))
                return result;

            KeyValues Manifest = KeyValues.LoadFile(ManifestPath);
            string FilePath;

            foreach (KeyValues FileKey in Manifest.Keys)
            {
                FilePath = Path.Combine(this.InstallPath, FileKey.Value);

                if (!File.Exists(FilePath))
                    continue;

                result.AddRange(ParseSurfaceProperties(FilePath));
            }

            return result;
        }

        private List<string> ParseSurfaceProperties(string FilePath)
        {
            List<string> result = new List<string>();

            using (StreamReader Sr = File.OpenText(FilePath))
            {
                string Line = Sr.ReadLine();
                bool InBlock = false;

                while (Line != null)
                {
                    if (Line.StartsWith("//") || Line.Length == 0)
                    {
                    }
                    else
                    {
                        if (Line.StartsWith("{"))
                        {
                            InBlock = true;
                        }
                        else
                        {
                            if (Line.StartsWith("}"))
                            {
                                InBlock = false;
                            }
                            else
                            {
                                if (!InBlock)
                                {
                                    result.Add(Line.Trim().Trim('"'));
                                }
                            }
                        }
                    }

                    Line = Sr.ReadLine();
                }
            }

            return result;
        }

        /// <summary>
        /// Translate the given token into a specified language
        /// </summary>
        /// <param name="Token">Token to translate (with or without # prefix)</param>
        /// <param name="Language">language to translate into, English by default</param>
        /// <returns>translated text or the original token</returns>
        /// <remarks></remarks>
        public string Localize(string Token, string Language = "English")
        {
            if (_Localization == null)
            {
                _Localization = new Localization();

                //load this mods localization file
                string LanguageFilePath = Path.Combine(InstallPath, "resource");

                LanguageFilePath = Path.Combine(LanguageFilePath, InstallFolder + "_" + Language + ".txt");
                _Localization.Add(LanguageFilePath);

                if (_GameInfo.GetKey("singleplayer_only") == null)
                {
                    //load this game's multiplayer localization file
                    LanguageFilePath = Steam.AppPath(AppId);
                    LanguageFilePath = Path.Combine(LanguageFilePath, "hl2mp");
                    LanguageFilePath = Path.Combine(LanguageFilePath, "resource");
                    LanguageFilePath = Path.Combine(LanguageFilePath, "Valve_" + Language + ".txt");
                    _Localization.Add(LanguageFilePath);
                }

                if (_GameInfo.GetKey("multiplayer_only") == null)
                {
                    //load this game's singleplayer localization file
                    LanguageFilePath = Steam.AppPath(AppId);
                    LanguageFilePath = Path.Combine(LanguageFilePath, "hl2");
                    LanguageFilePath = Path.Combine(LanguageFilePath, "resource");
                    LanguageFilePath = Path.Combine(LanguageFilePath, "Valve_" + Language + ".txt");
                    _Localization.Add(LanguageFilePath);
                }
            }

            string Result = _Localization[Token];

            if (Result == null)
            {
                return Token;
            }
            else
            {
                return Result;
            }
        }
    }//end class

}