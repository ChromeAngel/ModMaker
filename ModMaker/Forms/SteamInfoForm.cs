using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Datamodel;
using LibModMaker;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace ModMaker {
    /// <summary>
    /// UI for presenting info sniffed from Steam by MM
    /// </summary>
    public partial class SteamInfoForm
    {
        public SteamInfoForm()
        {
            InitializeComponent();

            Load += new EventHandler(frmSteamInfo_Load); 
            btnCopy.Click += new EventHandler(btnCopy_Click); 
        }

        private void frmSteamInfo_Load(object sender, System.EventArgs e)
        {
            Icon = Properties.Resources.ModMaker;
            UseWaitCursor = true;

            Application.DoEvents();

            txtOuput.AppendText("ModMaker Path : " + Application.StartupPath + "\r\n");

            string SteamReg = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null).ToString();

            txtOuput.AppendText("Steam Registry Key : ");

            if (SteamReg == null) {
                txtOuput.AppendText("Undefined");
            } else {
                txtOuput.AppendText(SteamReg);
            }

            txtOuput.AppendText("\r\n");
            txtOuput.AppendText("Steam Install Folder : ");

            try
            {
                txtOuput.AppendText(Steam.InstallPath);
            }
            catch (ApplicationException)
            {
                txtOuput.AppendText("Not Found");
            }
            
            txtOuput.AppendText("\r\n");
            txtOuput.AppendText("Steam Installed Apps : \r\n" );

            Dictionary<int, string> Apps = Steam.InstalledApps();

            if (Apps == null) {
                txtOuput.AppendText("Error :(\r\n" );
            } else {
                foreach (int AppID in Apps.Keys) {
                    txtOuput.AppendText(string.Format("    {0} : {1}\r\n", AppID, Apps[AppID]));
                }
            }

            txtOuput.AppendText(ControlChars.NewLine);

            string OldSourceSDKPath = Environment.GetEnvironmentVariable("sourcesdk");

            txtOuput.AppendText("Source SDK Environment Variable : ");

            if (OldSourceSDKPath == null) {
                txtOuput.AppendText("Undefined");
            } else {
                txtOuput.AppendText(OldSourceSDKPath);
            }

            txtOuput.AppendText(ControlChars.NewLine);

            string VProject = Environment.GetEnvironmentVariable("VProject");

            txtOuput.AppendText("VProject Environment Variable : ");

            if (VProject == null) {
                txtOuput.AppendText("Undefined");
            } else {
                txtOuput.AppendText(VProject);
            }

            txtOuput.AppendText(ControlChars.NewLine);
            txtOuput.AppendText("Source Mods Folder : " );

            try
            {
                txtOuput.AppendText(Steam.SourceModPath);
            }
            catch (ApplicationException)
            {
                txtOuput.AppendText("Not Found");
            }

            txtOuput.AppendText("\r\n");
            txtOuput.AppendText("Source Mods : \r\n");

            List<SourceMod> Mods = Steam.SourceMods;

            if (Mods == null) {
                txtOuput.AppendText("Error :(\r\n" );
            } else {
                foreach (SourceMod SMod in Mods) {
                    txtOuput.AppendText(string.Format("    {0}    \"{1}\"\r\n", SMod.InstallFolder, SMod.Name));
                }
            }


            UseWaitCursor = false;
        }

        void DescribeVDF(Datamodel.Element e, string indent)
        {
            txtOuput.AppendText(indent + e.Name + "{");

            string NextIndent = indent + "\t";

            foreach (KeyValuePair<string, object> pair in e) {
                switch (pair.Value.GetType().Name) {
                    case "ElementArray":
                        txtOuput.AppendText(NextIndent + pair.Key + "[");
                        Datamodel.ElementArray ell = pair.Value as ElementArray;
                        Datamodel.ElementArray ResultArray = new Datamodel.ElementArray(ell.Count);

                        foreach (Datamodel.Element Sube in ell) {
                            DescribeVDF(Sube, NextIndent);
                            txtOuput.AppendText(NextIndent + ",");
                        }

                        txtOuput.AppendText(NextIndent + "]");
                        break;
                    case "String":
                        txtOuput.AppendText(string.Format("{0}{1} '{2}'", NextIndent, pair.Key, pair.Value)); break;
                    case "Single":
                        txtOuput.AppendText(string.Format("{0}{1} {2}", NextIndent, pair.Key, pair.Value)); break;
                    case "Int32":
                        txtOuput.AppendText(string.Format("{0}{1} {2}", NextIndent, pair.Key, pair.Value)); break;
                    case "Boolean":
                        txtOuput.AppendText(string.Format("{0}{1} {2}", NextIndent, pair.Key, pair.Value)); break;
                    case "Vector3":
                        txtOuput.AppendText(string.Format("{0}{1} ({2})", NextIndent, pair.Key, pair.Value)); break;
                    case "Color":
                        txtOuput.AppendText(string.Format("{0}{1} ({2})", NextIndent, pair.Key, pair.Value)); break;
                    case "Element":
                        Datamodel.Element el = pair.Value as Element;
                        DescribeVDF(el, NextIndent);
                        break;
                    default:
                        Debug.WriteLine(string.Format("Unexpected data type {0} found in element {1}", pair.Value.GetType().Name, e.Name));
                        break;
                }
            }

            txtOuput.AppendText(indent + "}");
        }

        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            Clipboard.SetText(txtOuput.Text);
        }
    }

}