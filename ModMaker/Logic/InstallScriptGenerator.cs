using System;
using LibModMaker;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ModMaker
{

    /// <summary>
    /// Tool for generating an NSI installer script for a mod
    /// </summary>
    public class InstallScriptMaker
    {
        private List<iPrereqisite> Prerequisites = new List<iPrereqisite>();
        private SourceMod _Mod;

        public string ScriptPath;

        public InstallScriptMaker(SourceMod Subject)
        {
            _Mod = Subject;
            PerformCleanup = false;
        }

        public SourceMod Game
        {
            get { return _Mod; }
        }


        private bool _PerformCleanup = false;

        public bool PerformCleanup
        {
            get { return _PerformCleanup; }
            set
            {
                _PerformCleanup = value;

                Prerequisites.Clear();
                Prerequisites.Add(new HasFgd());
                Prerequisites.Add(new HasIcon());
                Prerequisites.Add(new EncryptedWeaponScripts());
                if ((_PerformCleanup))
                {
                    Prerequisites.Add(new CleanupTool {ShouldPrompt = false});
                }
                Prerequisites.Add(new SourceSDKSetupTool());
            }
        }

        public bool Make(string Version)
        {
            if (!PassedAllPrerequisites())
                return false;

            return MakeInstallerScript(Version);
        }

//#Region "Prerequsites"

        public bool PassedAllPrerequisites()
        {
            //see http://developer.valvesoftware.com/wiki/Pre-publication_evaluation

            foreach (iPrereqisite Test in Prerequisites)
            {
                if (!Test.Test(_Mod))
                    return false;
            }

            return true;

            //Build map list
            //build res list (
            //-sw -console -condebug -nocrashdialog -makereslists -usereslistfile maplist.txt +mat_picmip 2 +r_lod 3 -autoconfig
            //)
            // Note:	You should be shipping cfg\config_default.cfg.

            //scripts\settings.scr
            // Note:	This should be placed in the cfg folder.
        }

        internal interface iPrereqisite
        {
            bool Test(SourceMod Subject);
        }

        public class HasFgd : iPrereqisite
        {

            public bool Test(SourceMod Subject)
            {
                string[] FGDs = Directory.GetFiles(Subject.InstallPath, "*.fgd");

                if (FGDs.Length > 0)
                    return true;

                return
                    (Interaction.MsgBox("No FGD found, continue anyway?", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "FGD Missing") == MsgBoxResult.Yes);
            }
        }

        public class HasIcon : iPrereqisite
        {

            public bool Test(SourceMod Subject)
            {
                if (File.Exists(Path.Combine(Subject.InstallPath, "Resource\\game.ico")))
                    return true;

                return
                    (Interaction.MsgBox("No resource\\game.ico found, continue anyway?", MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                        "Icon Missing") == MsgBoxResult.Yes);
            }
        }

        public class EncryptedWeaponScripts : iPrereqisite
        {

            public bool Test(SourceMod Subject)
            {
                string ScriptsPath = Path.Combine(Subject.InstallPath, "scripts");

                if (!Directory.Exists(ScriptsPath))
                    return true;

                string[] weaponScripts = Directory.GetFiles(ScriptsPath, "*weapon_*.txt");

                if (weaponScripts.Length == 0)
                    return true;

                string Exe = Path.Combine(Subject.SDKPath, "CtxConverter\\vice.exe");

                if (File.Exists(Exe))
                {
                    if (
                        Interaction.MsgBox("There are un-encrypted weapon scripts.  Would you like to encrypt them now?",
                            MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Encrypt weapon scripts?") == MsgBoxResult.Yes)
                    {
                        string Key =
                            Interaction.InputBox(
                                "Please enter the encryption key (as returned by the GetEncryptionKey function in your mod's game rules).",
                                "Encryption Key", "");
                        FolderDialog PathPicker = new FolderDialog
                        {
                            Description = "Please specify the folder to move the un-encrypted scripts to"
                        };

                        if (string.IsNullOrEmpty(Key))
                            return false;
                        if (PathPicker.ShowDialog() == DialogResult.Cancel)
                            return false;

                        string Args;

                        foreach (string Script in weaponScripts)
                        {
                            Args = string.Format("-x .ctx -k {0} {1}", Key, Script);

                            Process.Start(Exe, Args);

                            File.Move(Script, PathPicker.SelectedPath);
                        }
                    }
                    else
                    {
                        return
                            (Interaction.MsgBox("Continue anyway?", MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                                "Un=encrypted weapon scripts") == MsgBoxResult.Yes);
                    }

                    return true;
                }
                else
                {
                    return
                        Interaction.MsgBox("There are un-encrypted weapon scripts.  Continue anyway?",
                            MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Include clear weapon scripts?") == MsgBoxResult.Yes;
                }
            }
        }

//#End Region

        private string GetInstallerIconPath()
        {
            string Result = Path.Combine(_Mod.InstallPath, "resource","game.ico");

            if (File.Exists(Result))
                return Result;

            //if we don't have an icon we must make(or steal) one
            Bitmap BitmapIcon = _Mod.BigIcon;
            Icon InstallerIcon = null;

            if (BitmapIcon == null)
            {
                //if the mod has no big icon, nick steam's
                try
                {
                    InstallerIcon = System.Drawing.Icon.ExtractAssociatedIcon(Steam.ExePath);
                }
                catch (ApplicationException)
                {
                    InstallerIcon = Properties.Resources.ModMaker;
                }
            }
            else
            {
                // Get an Hicon for myBitmap.
                IntPtr HIcon = BitmapIcon.GetHicon();

                // Create a new icon from the handle.
                InstallerIcon = System.Drawing.Icon.FromHandle(HIcon);
            }

            using (FileStream IconOut = File.OpenWrite(Result))
            {
                InstallerIcon.Save(IconOut);
                IconOut.Flush();
            }

            return Result;
        }

        public string CreateScriptPath(string Version)
        {
            string FileName = _Mod.Name.Trim();

            if (!string.IsNullOrEmpty(Version))
            {
                if (!FileName.EndsWith(Version))
                {
                    FileName = FileName.Trim('-') + '-' + Version.Trim('-');
                }
            }

            string Folder;
            KeyValues ModKeys = MainForm.ModOptions[_Mod.InstallFolder];

            if (ModKeys == null)
            {
                Folder = _Mod.SourcePath;
            }
            else
            {
                Folder = ModKeys.GetString("InstallerPath", _Mod.SourcePath);
            }

            ScriptPath = Path.Combine(Folder, string.Format("{0}-setup.nsi", FileName));

            return ScriptPath;
        }

        private bool MakeInstallerScript(string Version)
        {
            if (string.IsNullOrEmpty(ScriptPath))
            {
                CreateScriptPath(Version);
            }

            string IconPath = GetInstallerIconPath();
            string ProductName = _Mod.Name.Trim();

            if (ProductName.EndsWith(Version))
            {
                ProductName = ProductName.Substring(0, ProductName.Length - Version.Length).Trim();
            }

            using (StreamWriter Out = new StreamWriter(ScriptPath))
            {
                Out.WriteLine("!define PRODUCT_NAME \"{0}\"", ProductName);
                Out.WriteLine("!define PRODUCT_VERSION \"{0}\"", Version);
                Out.WriteLine("!define PRODUCT_PUBLISHER \"{0}\"", _Mod.Developer);
                Out.WriteLine("!define PRODUCT_WEB_SITE \"{0}\"", _Mod.DeveloperURL);
                Out.WriteLine("!define APPID " + _Mod.AppId.ToString());
                Out.WriteLine("!define LOCAL_DIR \"{0}\"", _Mod.InstallPath);
                Out.WriteLine("!define MUI_ICON \"{0}\"", IconPath);
                Out.WriteLine("!define FULL_GAME_NAME \"{0}\"", _Mod.Name);
                Out.WriteLine("!define DESKICO \"{0}\"", IconPath);
                //Out.WriteLine("!define NO_DESKTOP_ICON");
                Out.WriteLine("!define ZIPDLL");
                Out.WriteLine("!include \"MUI.nsh\"");

                if (File.Exists(Path.Combine(_Mod.InstallPath, "licence.txt")))
                {
                    Out.WriteLine("!define MUI_LICENSEPAGE_RADIOBUTTONS");
                    Out.WriteLine("!insertmacro MUI_PAGE_LICENSE \"${LOCAL_DIR}\\licence.txt\"");
                }

                Out.WriteLine("Section \"Mod Files\" FILES");
                Out.WriteLine("\tSetOverwrite try");

                Out.Flush();

                ScriptFolder(_Mod.InstallPath, Out);

                //Out.WriteLine("\t!ifndef NO_DESKTOP_ICON");
                //Out.WriteLine("\tSetOutPath \"$ICONDIR\"");
                //Out.WriteLine("\tFile \"${DESKICO}\"");
                //Out.WriteLine("\t!endif");
                Out.WriteLine("SectionEnd");

                Out.Write(SetInstallDir(Properties.Resources.NSI_Footer));

                Out.Flush();
            }

            return true;
        }

        private string SetInstallDir(string NSIFooter)
        {
            return NSIFooter.Replace("StrCpy $INSTDIR \"$R1\"", "StrCpy $INSTDIR \"$R1\\" + _Mod.InstallFolder + "\"");
        }

        private string ToInstallPath(string Path)
        {
            if (Path.Length <= _Mod.InstallPath.Length)
                return "";

            return Path.Substring(_Mod.InstallPath.Length);
        }

        private void ScriptFolder(string TargetFolder, StreamWriter Out)
        {
            Out.WriteLine(ControlChars.Tab + "SetOutPath \"$INSTDIR\\" + ToInstallPath(TargetFolder) + '"');

            foreach (string File in Directory.GetFiles(TargetFolder))
            {
                Out.WriteLine(ControlChars.Tab + "File \"${LOCAL_DIR}\\" + ToInstallPath(File) + '"');
            }

            foreach (string Folder in Directory.GetDirectories(TargetFolder))
            {
                ScriptFolder(Folder, Out);
            }

            Out.Flush();
        }
    }

}