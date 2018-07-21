using System;
using System.Collections.Generic;
using System.IO;

namespace LibModMaker
{

    /// <summary>
    /// Performs localization functions in Source by mapping from ANSI tokens to the unicode text of a target language
    /// </summary>
    public class Localization : List<Localization.File>
    {

        public void Add(string FilePath)
        {
            if (!System.IO.File.Exists(FilePath))
                return;

            Add(new File(FilePath));
        }

        public void Add(KeyValues LocalizationFile)
        {
            if (LocalizationFile == null)
                return;
            if (LocalizationFile.Name != "Lang")
                return;

            Add(new File(LocalizationFile));
        }

        public string this[string Token]
        {
            get
            {
                if (Count == 0)
                    return null;
                if (string.IsNullOrEmpty(Token))
                    return null;
                if (Token.StartsWith("#"))
                    Token = Token.Substring(1);
                //trim the leading #

                foreach (File File in this)
                {
                    if (File.ContainsKey(Token))
                        return File[Token];
                }

                return null;
            }
            set
            {
                if (Count == 0)
                    return;

                //always write to the most local file, which must be added first
                this[0][Token] = value;
            }
        }

        public void Save()
        {
            if (Count == 0)
                return;

            this[0].SaveFile();
        }

        /// <summary>
        /// Key'd by token, actual text as values
        /// </summary>
        /// <remarks>wrapper for localization token files</remarks>
        public class File : Dictionary<string, string>
        {

            protected string _FilePath = null;

            protected string _Language = "English";

            internal File()
            {
            }

            internal File(string FilePath)
            {
                LoadFile(FilePath);
            }

            internal File(KeyValues LocalizationFile)
            {
                LoadFile(LocalizationFile);
            }

            internal int LoadFile(string FilePath)
            {
                if (string.IsNullOrEmpty(FilePath))
                    return 0;
                if (!System.IO.File.Exists(FilePath))
                    return 0;

                KeyValues LocalizationFile = KeyValues.LoadFile(FilePath);

                _FilePath = FilePath;

                return LoadFile(LocalizationFile);
            }

            internal int LoadFile(KeyValues LocalizationFile)
            {
                if (LocalizationFile == null)
                    return 0;

                _Language = LocalizationFile.GetString("Language");

                KeyValues Tokens = LocalizationFile.GetKey("Tokens");

                if (Tokens == null)
                    return 0;

                int Result = 0;

                foreach (KeyValues Pair in Tokens.Keys)
                {
                    try
                    {
                        if (this.ContainsKey(Pair.Name))
                        {
                            this[Pair.Name] = this[Pair.Name] + Pair.Value;
                        }
                        else
                        {
                            Add(Pair.Name, Pair.Value);
                            Result += 1;
                        }
                    }
                    catch (ArgumentException)
                    {
                        //duplicates may crop up, we dont care
                    }
                }

                return Result;
            }

            internal bool SaveFile(string FilePath)
            {
                try
                {
                    KeyValues LocalizationFile = new KeyValues("lang");

                    LocalizationFile.SetValue("Language", _Language);

                    KeyValues Tokens = new KeyValues("Tokens", LocalizationFile);

                    foreach (string Token in this.Keys)
                    {
                        Tokens.SetValue(Token, this[Token]);
                    }

                    LocalizationFile.Save(FilePath, System.Text.Encoding.UTF8);
                    _FilePath = FilePath;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            internal bool SaveFile()
            {
                if (_FilePath == null)
                    return false;

                return SaveFile(_FilePath);
            }
        }
    } //class

}