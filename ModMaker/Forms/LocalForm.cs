using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using LibModMaker;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// UI for editing locaizaion files
    /// </summary>
    public partial class LocalForm
    {
        public string GameDir { get; set; }
        public string FileName { get; set; }

        public string Langauge
        {
            get { return cboLangugae.SelectedItem.ToString(); }
        }


        private string _SelectedToken = null;
        public string SelectedToken
        {
            get { return _SelectedToken; }
            set
            {
                _SelectedToken = value;

                SelectToken(SelectedToken);
            }
        }


        private Dictionary<string, string> Tokens = new Dictionary<string, string>();
        public LocalForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            cboLangugae.SelectedItem = "English";
        }

        // ERROR: Handles clauses are not supported in C#
        private void frmLocal_Load(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(GameDir))
                return;

            SourceMod Game = new SourceMod(GameDir);
            string DefaultFile = null;

            try
            {
                DefaultFile = Path.Combine(Steam.SourceModPath, GameDir, "resource", GameDir + "_" + Langauge.ToLower() + ".txt");
            }
            catch (ApplicationException)
            {
                //If Steam cannot be found we cannot get a default file
                return;
            }

            if (!File.Exists(DefaultFile))
                return;

            LoadFile(DefaultFile);
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuNewFile_Click(System.Object sender, System.EventArgs e)
        {
            var Dialog = new OpenFileDialog
            {
                Filter = "Translation File ( modname_langauge.txt )|*_*.txt",
                Title = "Specify New Script Name",
                InitialDirectory = Path.Combine(Steam.SourceModPath, GameDir, "resource"),
                FileName = GameDir + "_" + Langauge.ToLower() + ".txt"
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = Dialog.FileName;
            Tokens = new Dictionary<string, string>();

            RefreshList();

            txtEnglish.Text = "";
            txtTranslation.Text = "";
        }

        public void RefreshList()
        {
            ListTokens.SuspendLayout();
            ListTokens.Items.Clear();

            foreach (string Token in Tokens.Keys)
            {
                if (!Token.StartsWith("[english]"))
                    ListTokens.Items.Add(Token);
            }

            ListTokens.ResumeLayout();
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuOpenFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Filter = "Translation File ( modname_langauge.txt )|*_*.txt",
                Title = "Open Script",
                InitialDirectory = Path.Combine(Steam.SourceModPath, GameDir, "resource"),
                CheckFileExists = true,
                FileName = GameDir + "_" + Langauge.ToLower() + ".txt"
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            FileName = Dialog.FileName;

            LoadFile(FileName);
        }

        void LoadFile(string FilePath)
        {
            KeyValues File = KeyValues.LoadFile(FilePath);

            Text = Path.GetFileName(FilePath) + " - Localization";

            Tokens = new Dictionary<string, string>();

            cboLangugae.SelectedItem = File.GetString("Language", "English");

            KeyValues TokenKeys = File.GetKey("Tokens") as KeyValues;

            if (TokenKeys == null)
            {
                Interaction.MsgBox("Invalid file format, missing \"Tokens\" key values", MsgBoxStyle.Information);

                return;
            }

            foreach (KeyValues Pair in TokenKeys.Keys)
            {
                Tokens[Pair.Name] = Pair.Value;
            }

            RefreshList();

            if (Tokens.Count > 0)
            {
                ListTokens.SelectedIndex = 0;
            }
            else
            {
                txtEnglish.Text = "";
                txtTranslation.Text = "";
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuSaveAs_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog Dialog = new SaveFileDialog
            {
                Filter = "Translation File ( modname_langauge.txt )|*_*.txt",
                Title = "Save Script As",
                InitialDirectory = Path.Combine(Steam.SourceModPath, GameDir, "resource"),
                FileName = GameDir + "_" + Langauge.ToLower() + ".txt"
            };

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            CaptureChanges();

            KeyValues File = new KeyValues("lang");
            KeyValues Key;
            KeyValues Translation;

            Key = new KeyValues("Language", Langauge, File);
            Key = new KeyValues("Tokens", File);

            foreach (string Token in Tokens.Keys)
            {
                Translation = new KeyValues(Token, Tokens[Token], Key);
            }

            File.Save(Dialog.FileName);

            FileName = Dialog.FileName;
        }

        // ERROR: Handles clauses are not supported in C#
        private void ListTokens_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            SelectToken(ListTokens.SelectedItem.ToString());
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuNewTaken_Click(System.Object sender, System.EventArgs e)
        {
            string TokenName = Interaction.InputBox("Please enter the new token name", "New Token");

            if (TokenName.Length == 0)
                return;

            AddToken(TokenName);
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string TokenName = txtFilter.Text;

            if (TokenName.Length == 0)
                return;

            AddToken(TokenName);
        }

        void AddToken(string TokenName)
        {
            Tokens.Add(TokenName, TokenName);

            if (Langauge != "English")
            {
                string EnglishToken = "[english]" + TokenName;

                if (!Tokens.ContainsKey(EnglishToken))
                    Tokens.Add(EnglishToken, TokenName);
            }

            RefreshList();
            SelectToken(TokenName);
        }

        void SelectToken(string SelectedToken)
        {
            CaptureChanges();

            txtFilter.Text = SelectedToken;
            txtTranslation.Text = DecodeNewLines(Tokens[SelectedToken]);

            if (Langauge == "English")
            {
                txtEnglish.Text = DecodeNewLines(Tokens[SelectedToken]);
            }
            else
            {
                if (Tokens.ContainsKey("[english]" + SelectedToken))
                {
                    txtEnglish.Text = DecodeNewLines(Tokens["[english]"] + SelectedToken);
                }
                else
                {
                    txtEnglish.Text = "";
                }
            }

            _SelectedToken = SelectedToken;
        }

        void CaptureChanges()
        {
            if (SelectedToken == null)
                return;

            Tokens[SelectedToken] = EncodeNewLines(txtTranslation.Text);

            if (Langauge != "English")
            {
                Tokens["[english]" + SelectedToken] = EncodeNewLines(txtEnglish.Text);
            }
        }

        string DecodeNewLines(string Escaped)
        {
            return Escaped.Replace("\\n", Environment.NewLine);
        }

        string EncodeNewLines(string Clear)
        {
            return Clear.Replace(Environment.NewLine, "\\n");
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuDeleteToken_Click(System.Object sender, System.EventArgs e)
        {
            Tokens.Remove(SelectedToken);
            RefreshList();
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuHelp_Click(System.Object sender, System.EventArgs e)
        {
            Interaction.MsgBox("Source mod will automatically load translations from resources/<gamename>_<language>.txt\r\n\r\n" +
                "This editor is intended to help you translate your english text into other localities.string\r\n\r\n" + 
                "The tokens which appear in your the source code are listed on the left and the translation of the selected token that is displayed to the player appears on the right.", 
                MsgBoxStyle.Information, "Help - Localization");
        }

        // ERROR: Handles clauses are not supported in C#
        private void mnuExit_Click(System.Object sender, System.EventArgs e)
        {
            Close();
        }
    }

}