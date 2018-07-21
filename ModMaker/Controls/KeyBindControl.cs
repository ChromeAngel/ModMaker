using System;
using System.Text.RegularExpressions;
using LibModMaker;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// Core control of the keybindings editor
    /// </summary>
    public partial class KeyBindControl
    {

        public KeyBindControl()
        {
            InitializeComponent();
        }

        private SourceMod _game = null;
        private SourceFileSystem sfs = null;

        public SourceMod Game
        {
            get { return _game; } 
            set {
                _game = value;

                if (_game == null) return;

                sfs = new SourceFileSystem(_game);
            }    
        }

        private Dictionary<string, string> Translations = new Dictionary<string, string>();
        public void LoadFiles()
        {
            LoadKeys();
            LoadMenu();

            string configFolder = Path.Combine(Game.InstallPath, "cfg");
            string defaultConfigFile = Path.Combine(configFolder, "config_default.cfg");

            if (!File.Exists(defaultConfigFile))
            {
                if (sfs.Contains("cfg/config_default.cfg"))
                {
                    sfs.Extract("cfg/config_default.cfg", configFolder);
                }
            }

            if (!File.Exists(defaultConfigFile)) return;

            LoadKeyBindings(defaultConfigFile);
        }

        private void LoadKeys()
        {
            string scriptsPath = Path.Combine(Game.InstallPath, "scripts");
            string fileName = Path.Combine(scriptsPath, "kb_keys.lst");

            if (!File.Exists(fileName))
            {
                if (sfs.Contains("scripts/kb_keys.lst"))
                {
                    sfs.Extract("scripts/kb_keys.lst", scriptsPath);
                }
            }

            if (!File.Exists(fileName))
                return;

            KeyLookups.Tables["Keys"].Rows.Clear();

            string[] Lines = File.ReadAllLines(fileName);
            DataRow Row = KeyLookups.Tables["Keys"].NewRow();

            Row["Key"] = "<unbound>";
            KeyLookups.Tables["Keys"].Rows.Add(Row);

            foreach (string Line in Lines)
            {
                string[] Columns = Line.Split('"');
                string KeyName = Columns[1];

                if (KeyName.StartsWith("<UNKNOW"))
                    continue;

                Row = KeyLookups.Tables["Keys"].NewRow();
                Row["Key"] = KeyName;
                Row["KeyCode"] = KeyName;
                KeyLookups.Tables["Keys"].Rows.Add(Row);
            }
        }

        private void LoadMenu()
        {
            string scriptsPath = Path.Combine(Game.InstallPath, "scripts");
            string fileName = Path.Combine(scriptsPath, "kb_act.lst");

            if (!File.Exists(fileName))
            {
                if (sfs.Contains("scripts/kb_act.lst"))
                {
                    sfs.Extract("scripts/kb_act.lst", scriptsPath);
                }
            }

            if (!File.Exists(fileName))
                return;

            KeyLookups.Tables["Group"].Rows.Clear();
            KeyLookups.Tables["KeyBind"].Rows.Clear();

            Translations = new Dictionary<string, string>();

            string[] Lines = File.ReadAllLines(fileName);
            string Group = null;
            Regex QuoteMatcher = new Regex("\".+?\"");
            DataRow Row = KeyLookups.Tables["Group"].NewRow();

            Row["Text"] = "<hidden>";
            KeyLookups.Tables["Group"].Rows.Add(Row);

            foreach (string Line in Lines) {
                MatchCollection Matches = QuoteMatcher.Matches(Line);
                string Command = null;
                string Token = null;

                foreach (Match M in Matches) {
                    if (M.Value.Trim('"').Trim().Length == 0)
                        continue;

                    if (Command == null) {
                        Command = M.Value.Trim('"');
                    } else {
                        Token = M.Value.Trim('"');
                    }
                }

                if (Command == null || Token == null)
                    continue;

                if (!Token.StartsWith("#"))
                    continue;
                //spacers!

                Translations[Token] = Game.Localize(Token);

                if (Command == "blank") {
                    //Group
                    Row = KeyLookups.Tables["Group"].NewRow();
                    Row["Token"] = Token;
                    Row["Text"] = Translations[Token];
                    KeyLookups.Tables["Group"].Rows.Add(Row);

                    Group = Token;
                } else {
                    //Keybinding
                    Row = KeyLookups.Tables["KeyBind"].NewRow();
                    Row["Group"] = Group;
                    Row["Command"] = Command;
                    Row["LabelToken"] = Token;
                    Row["Label"] = Translations[Token];
                    KeyLookups.Tables["KeyBind"].Rows.Add(Row);
                }
            }
        }

        public void LoadKeyBindings(string FileName)
        {
            if (!File.Exists(FileName))
                return;

            string[] Lines = File.ReadAllLines(FileName);
            Regex QuoteMatcher = new Regex("\".+?\"");

            foreach (string Line in Lines) {
                if (!Line.StartsWith("bind "))
                    continue;

                string loopLine = Line.Substring(5);
                MatchCollection Matches = QuoteMatcher.Matches(loopLine);
                string Command = null;
                string Key = null;
                bool MatchedMenu = false;

                foreach (Match M in Matches) {
                    if (M.Value.Trim('"').Trim().Length == 0)
                        continue;

                    if (Key == null) {
                        Key = M.Value.Trim('"');
                    } else {
                        Command = M.Value.Trim('"');
                    }
                }

                foreach (DataRow Row in KeyLookups.Tables["KeyBind"].Rows) {
                    if (IsDBNull(Row["Command"]))
                        continue;

                    if (Row["Command"] as string == Command) {
                        Row["Key"] = Key;
                        MatchedMenu = true;

                        break; // TODO: might not be correct. Was : Exit For
                    }
                }

                if (!MatchedMenu) {
                    DataRow Row = KeyLookups.Tables["KeyBind"].NewRow();

                    Row["Command"] = Command;
                    Row["Key"] = Key;
                    KeyLookups.Tables["KeyBind"].Rows.Add(Row);
                }
            }
        }

        public void Save()
        {
            SaveMenu();
            SaveDefaults();
            SaveTokens();
        }

        private void SaveMenu()
        {
            string FileName = Path.Combine(Game.InstallPath, "scripts/kb_act.lst");

            SourceFileSystem.BackUpFile(FileName);

            DataView dvGroupKeyBinds = new DataView(KeyLookups.Tables["KeyBind"]);

            using (StreamWriter File = new StreamWriter(FileName)) {
                foreach (DataRow Group in KeyLookups.Tables["Group"].Rows) {
                    if (IsDBNull(Group["Token"]) || Group["Token"] == null)
                        continue;

                    File.WriteLine("\"blank\"\t\t\t\"==========================\"");
                    File.WriteLine("\"blank\"\t\t\t\"{0}\"", Group["Token"]);
                    File.WriteLine("\"blank\"\t\t\t\"==========================\"");

                    dvGroupKeyBinds.RowFilter = "Group = '" + Group["Token"] + "'";

                    foreach (DataRow KeyBind in dvGroupKeyBinds.ToTable().Rows) {
                        if (IsDBNull(KeyBind["LabelToken"]) || KeyBind["LabelToken"] == null) {
                            KeyBind["LabelToken"] = MakeSafeToken(KeyBind["LabelToken"], KeyBind["Label"].ToString());
                        }

                        File.WriteLine("\"{0}\"\t\t\t\"{1}\"", KeyBind["Command"], KeyBind["LabelToken"]);
                    }
                }
            }
        }

        private object MakeSafeToken(object LabelToken, string Token)
        {
            if (IsDBNull(LabelToken) || LabelToken == null) {
                return "#" + Game.InstallFolder + "_" + Token.ToUpper().Replace(" ", "_").Replace("\"", "").Replace("{", "").Replace("}", "").Replace("//", "").Replace("/*", "").Replace("*/", "");
            } else {
                return (string)LabelToken;
            }
        }

        private void SaveDefaults()
        {
            string FileName = Path.Combine(Game.InstallPath, "cfg/config_default.cfg");

            SourceFileSystem.BackUpFile(FileName);

            List<string> Lines = new List<string>();

            if (File.Exists(FileName)) {
                string[] OldLines = File.ReadAllLines(FileName);

                foreach (string OldLine in OldLines) {
                    if (OldLine.StartsWith("bind "))
                        continue;

                    Lines.Add(OldLine);
                }
            }

            if (Lines.Count == 0)
                Lines.Add("unbindall");

            foreach (DataRow KeyBind in KeyLookups.Tables["KeyBind"].Rows) {
                if (IsDBNull(KeyBind["Key"]) || IsDBNull(KeyBind["Command"]))
                    continue;

                Lines.Add(string.Format("bind \"{0}\" \"{1}\"", KeyBind["Key"], KeyBind["Command"]));
            }

            File.WriteAllLines(FileName, Lines.ToArray());
        }

        protected bool SaveTokens(string Language = "English")
        {
            string LanguageFilePath = Path.Combine(Game.InstallPath, "resource");

            LanguageFilePath = Path.Combine(LanguageFilePath, Game.InstallFolder + "_" + Language + ".txt");

            if (!File.Exists(LanguageFilePath))
                return false;

            SourceFileSystem.BackUpFile(LanguageFilePath);

            Localization LocalizationFile = new Localization();

            LocalizationFile.Add(LanguageFilePath);

            foreach (DataRow KeyBind in KeyLookups.Tables["KeyBind"].Rows) {
                if (IsDBNull(KeyBind["LabelToken"]))
                    continue;

                LocalizationFile[KeyBind["LabelToken"].ToString()] = KeyBind["Label"].ToString();
            }

            foreach (DataRow Group in KeyLookups.Tables["Group"].Rows) {
                if (IsDBNull(Group["Token"])) {
                    Group["Token"] = MakeSafeToken(Group["Token"], Group["Text"].ToString());
                }

                LocalizationFile[Group["Token"].ToString()] = Group["Text"].ToString();
            }

            LocalizationFile.Save();
            return true;
        }

        public static bool IsDBNull(object subject)
        {
            return (DBNull.Value == subject);
        }
        

        public void AddGroup(string Text)
        {
            DataRow Group = KeyLookups.Tables["Group"].NewRow();

            Group["Text"] = Text;
            Group["Token"] = MakeSafeToken(null, Text);

            KeyLookups.Tables["Group"].Rows.Add(Group);
        }

        private void KeyGrid_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
        }
    }

}