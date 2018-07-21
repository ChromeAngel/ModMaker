using System;
using System.Collections.Generic;
using System.IO;

namespace ModMaker
{
    /// <summary>
    /// UI for "Advanced" command line options for starting a game/mod
    /// </summary>
    public partial class AdvancedStartupForm
    {
        public AdvancedStartupForm()
        {
            InitializeComponent();

            base.Load += new EventHandler(frmAdvancedStartup_Load);
            chkMap.CheckStateChanged += new EventHandler(chkMap_CheckedChanged);
        }


        public string Parameters
        {
            get
            {
                System.Text.StringBuilder Arguments = new System.Text.StringBuilder("");

                if (chkDeveloper.Checked)
                    Arguments.Append(" -dev");
                if (chkAllowDebug.Checked)
                    Arguments.Append(" -allowdebug");
                if (chkCondebug.Checked)
                    Arguments.Append(" -condebug");
                if (chkWindowed.Checked)
                    Arguments.Append(" -windowed");
                if (chkNoBorder.Checked)
                    Arguments.Append(" -noborder");
                if (chkNoIntro.Checked)
                    Arguments.Append(" -novid");
                if (chkToolsMode.Checked)
                    Arguments.Append(" -tools -nop4");
                if (chkToConsole.Checked)
                    Arguments.Append(" -toconsole");
                if (!string.IsNullOrEmpty(txtOther.Text))
                    Arguments.Append(" " + txtOther.Text);
                if (chkMap.Checked & !string.IsNullOrEmpty(cboMap.SelectedValue.ToString()))
                    Arguments.Append(" +map " + cboMap.SelectedValue);

                return Arguments.ToString();
            }
        }

        public bool SkipIntro
        {
            get { return chkNoIntro.Checked; }
            set { chkNoIntro.Checked = value; }
        }

        public bool Windowed
        {
            get { return chkWindowed.Checked; }
            set { chkWindowed.Checked = value; }
        }

        public bool AllowDebug
        {
            get { return chkAllowDebug.Checked; }
            set { chkAllowDebug.Checked = value; }
        }

        private void frmAdvancedStartup_Load(object sender, System.EventArgs e)
        {
            //TODO revisit this
            //this.Icon = Properties.Resources.ModMaker;
        }

        public void RefreshMapList(string Folder)
        {
            string[] RawBSPs = Directory.GetFiles(Folder, "*.bsp");
            List<string> BSPs = new List<string>();

            foreach (string RawBsp in RawBSPs)
            {
                string InnerRawBsp = RawBsp.Substring(Folder.Length + 1);
                // trim the maps path
                InnerRawBsp = InnerRawBsp.Substring(0, InnerRawBsp.Length - 4);
                // trim the trailing .bsp
                BSPs.Add(InnerRawBsp);
            }

            cboMap.DataSource = BSPs;
        }

        // ERROR: Handles clauses are not supported in C#
        private void chkMap_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            cboMap.Enabled = chkMap.Checked;
        }

        public void SelectMap(string MapName)
        {
            if (MapName == null)
            {
                chkMap.Checked = false;
            }
            else
            {
                chkMap.Checked = true;
                cboMap.SelectedItem = MapName;
            }
        }
    }

}
