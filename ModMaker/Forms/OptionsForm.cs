using System;
using System.Windows.Forms;
using LibModMaker;
using System.IO;
using System.Data;

namespace ModMaker
{
    /// <summary>
    /// User interface for configuring MM
    /// </summary>
    public partial class OptionsForm
    {
        public OptionsForm()
        {
            InitializeComponent();

            Icon = Properties.Resources.ModMaker;

            Load += new EventHandler(frmOptions_Load);
            btnOK.Click += new EventHandler(btnOK_Click);
        }

        private void frmOptions_Load(object sender, System.EventArgs e)
        {
            FillGridData();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            SaveGridData();

            this.DialogResult = DialogResult.OK;
        }

        public string AppsFilePath
        {
            get { return Path.Combine(Application.StartupPath, "options/apps.txt");  }
        }

        public void FillGridData()
        {
            KeyValues FileTypeKey = KeyValues.LoadFile(Compiler.FileTypesPath());

            GridData.Tables["FileType"].Rows.Clear();

            foreach (KeyValues FileType in FileTypeKey.Keys)
            {
                DataRow R = GridData.Tables["FileType"].NewRow();

                R["extension"] = FileType.Name;
                R["filter"] = FileType.GetString("filter");
                R["command"] = FileType.GetString("command");
                R["logwindow"] = FileType.GetBool("logwindow");

                GridData.Tables["FileType"].Rows.Add(R);
            }

            KeyValues AppList = KeyValues.LoadFile(AppsFilePath);

            GridData.Tables["Apps"].Rows.Clear();

            foreach (KeyValues App in AppList.Keys)
            {
                DataRow R = GridData.Tables["Apps"].NewRow();

                R["AppID"] = int.Parse(App.Name);
                R["game"] = App.GetString("game");
                R["sdkversion"] = App.GetString("sdkversion");
                R["engine"] = App.GetString("engine");
                R["gameexe"] = App.GetString("gameexe");

                GridData.Tables["Apps"].Rows.Add(R);
            }

        }

        public void SaveGridData()
        {
            KeyValues FileTypeKey = new KeyValues("FileType");

            foreach (DataRow R in GridData.Tables["FileType"].Rows)
            {
                KeyValues Key = new KeyValues(R["extension"].ToString(), FileTypeKey);
                KeyValues Value = new KeyValues("filter", R["filter"].ToString(), Key);

                Value = new KeyValues("command", R["command"].ToString(), Key);
                Value = new KeyValues("logwindow", (bool)R["logwindow"] ? "1" : "0", Key);
            }

            FileTypeKey.Save(Compiler.FileTypesPath());

            KeyValues AppList = new KeyValues("Apps");

            foreach (DataRow R in GridData.Tables["Apps"].Rows)
            {
                KeyValues Key = new KeyValues(R["Appid"].ToString(), AppList);
                KeyValues Value = new KeyValues("game", R["game"].ToString(), Key);

                Value = new KeyValues("sdkversion", R["sdkversion"].ToString(), Key);
                Value = new KeyValues("engine", R["engine"].ToString(), Key);
                Value = new KeyValues("gameexe", R["gameexe"].ToString(), Key);
            }

            AppList.Save(AppsFilePath);
        }
    }

}