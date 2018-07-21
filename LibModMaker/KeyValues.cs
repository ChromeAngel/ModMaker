using System.IO;
using System.Collections.Generic;

namespace LibModMaker
{
    /// <summary>
    /// A node in a human-readable, heirarchical data format used by Valve and the Source engine
    /// </summary>
    /// <remarks>this format is use by GameInfo.txt for game configuation, VMT files to describe materials, sound scripts and manifest files etc.
    /// A more modern engine would probabaly use standard JSON</remarks>
    public class KeyValues
    {
        /// <summary>
        /// Name of this node
        /// </summary>
        public string Name = "";
        /// <summary>
        /// Value of this node
        /// </summary>
        public string Value = "";
        /// <summary>
        /// rarely used condional argement for this node eg "[win32]"
        /// </summary>
        public string Condition = null;

        /// <summary>
        /// Child keys
        /// </summary>
        public List<KeyValues> Keys = new List<KeyValues>();

        /// <summary>
        /// Parent key
        /// </summary>
        public KeyValues Parent;

        /// <summary>
        /// crate an anonymous node
        /// </summary>
        public KeyValues()
        {
        }

        /// <summary>
        /// Create a new named root node
        /// </summary>
        /// <param name="NewName"></param>
        public KeyValues(string NewName)
        {
            Name = NewName;
        }

        /// <summary>
        /// Create a new node and make it a child of a given node
        /// </summary>
        /// <param name="NewName"></param>
        /// <param name="NewParent"></param>
        public KeyValues(string NewName, KeyValues NewParent)
        {
            Name = NewName;
            Parent = NewParent;

            if (Parent == null)
                return;
            if (!Parent.Keys.Contains(this))
                Parent.Keys.Add(this);
        }

        /// <summary>
        /// Create a new child node specifying it's name and value
        /// </summary>
        /// <param name="NewName"></param>
        /// <param name="NewValue"></param>
        /// <param name="NewParent"></param>
        public KeyValues(string NewName, string NewValue, KeyValues NewParent)
        {
            Name = NewName;
            Value = NewValue;
            Parent = NewParent;

            if (Parent == null)
                return;
            if (!Parent.Keys.Contains(this))
                Parent.Keys.Add(this);
        }

        /// <summary>
        /// Get the value of a named child as a string
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Def">value to return if the child node is missing</param>
        /// <returns>the string value of the child node or the specified default if the child is null or missing</returns>
        public string GetString(string Key, string Def = "")
        {
            KeyValues Child = GetKey(Key);

            return Child == null ? Def : Child.Value;
        }

        /// <summary>
        /// Get the value of a named child as an integer
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Def">value to return if the child node is missing</param>
        /// <returns>the int value of the child node or the specified default if the child is missing</returns>
        public int GetInt(string Key, int Def = 0)
        {
            KeyValues Child = GetKey(Key);

            return Child == null ? Def : int.Parse(Child.Value);
        }

        /// <summary>
        /// Get the value of a named child as a floating point number
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Def">value to return if the child node is missing</param>
        /// <returns>the float value of the child node or the specified default if the child is missing</returns>
        public double GetFloat(string Key, double Def = 0)
        {
            KeyValues Child = GetKey(Key);

            return Child == null ? Def : double.Parse(Child.Value);
        }

        /// <summary>
        /// Get the value of a named child as a boolean
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Def">value to return if the child node is missing</param>
        /// <returns>the bool value of the child node or the specified default if the child is missing</returns>
        public bool GetBool(string Key, bool Def = false)
        {
            KeyValues Child = GetKey(Key);

            if (Child == null)
                return Def;

            if (string.IsNullOrEmpty(Child.Value))
                return Def;

            switch(Child.Value.ToLowerInvariant())
            {
                case "1": return true; 
                case "0": return false;
                case "true": return true; 
                case "false": return false;
                case "yes": return true;
                case "no": return false;
                case "on": return true;
                case "off": return false;
            }

            return bool.Parse(Child.Value);
        }

        /// <summary>
        /// Get a child node by name
        /// </summary>
        /// <param name="Key">name of the child node (case insensitive)</param>
        /// <returns>the first child node with a matching name or null if no match is found</returns>
        public KeyValues GetKey(string Key)
        {
            foreach (KeyValues Child in Keys)
            {
                if (Child.Name.Equals(Key, System.StringComparison.InvariantCultureIgnoreCase))
                    return Child;
            }

            return null;
        }

        /// <summary>
        /// Get or Set a child node by it's name
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <returns>the first child node with a matching name or null if no match is found</returns>
        public KeyValues this[string Key]
        {
            get { return GetKey(Key); }
            set
            {
                if (value == null)
                    return;

                value.Parent = this;
                Keys.Add(value);
            }
        }


        /// <summary>
        /// Set a child node to a specific string
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Value">value of the child</param>
        /// <remarks>creates new child nodes if the named node does not already exist</remarks>
        public void SetValue(string Key, string Value)
        {
            KeyValues KeyValue = GetKey(Key);

            if (KeyValue == null)
            {
                KeyValue = new KeyValues(Key, Value, this);
            }
            else
            {
                KeyValue.Value = Value;
            }
        }

        /// <summary>
        /// Set a child node to a specific integer
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Value">value of the child</param>
        /// <remarks>creates new child nodes if the named node does not already exist</remarks>
        public void SetValue(string Key, int Value)
        {
            SetValue(Key, Value.ToString());
        }

        /// <summary>
        /// Set a child node to a specific float
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Value">value of the child</param>
        /// <remarks>creates new child nodes if the named node does not already exist</remarks>
        public void SetValue(string Key, float Value)
        {
            SetValue(Key, Value.ToString());
        }

        /// <summary>
        /// Set a child node to a specific decimal
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Value">value of the child</param>
        /// <remarks>creates new child nodes if the named node does not already exist</remarks>
        public void SetValue(string Key, decimal Value)
        {
            SetValue(Key, Value.ToString());
        }


        /// <summary>
        /// Set a child node to a specific boolean
        /// </summary>
        /// <param name="Key">name of the child node</param>
        /// <param name="Value">value of the child</param>
        /// <remarks>creates new child nodes if the named node does not already exist.  Stores booleans as 0 or 1.</remarks>
        public void SetValue(string Key, bool Value)
        {
            SetValue(Key, Value ? "1":"0");
        }

        /// <summary>
        /// Conver this Keyvalue to a string
        /// </summary>
        /// <returns>string represention this node and it's children, as stored on disk</returns>
        public override string ToString()
        {
            if (Name == null)
            {
                     return string.Empty;           
            }

            string IndentCache = Indent();
            System.Text.StringBuilder Result = new System.Text.StringBuilder(IndentCache);

            Result.Append(Quote(Name));

            if (Condition != null)
            {
                Result.AppendFormat("{0}[{1}]", '\t', Condition);
            }

            if (Keys.Count == 0)
            {
                Result.Append('\t');
                Result.Append(Quote(Value));
            }
            else
            {
                Result.Append("\r\n");
                Result.Append(IndentCache);
                Result.Append("{");
                Result.Append("\r\n");

                foreach (var Child in Keys)
                {
                    Result.Append(Child.ToString());
                }

                Result.Append(IndentCache);
                Result.Append("}");
            }

            Result.Append("\r\n");

            return Result.ToString();
        }

        /// <summary>
        /// Proper number of tabs to indent the string version of this KeyValue
        /// </summary>
        /// <returns>a strign containing a tab for everylevel bellow the root node</returns>
        private string Indent()
        {
            string Empty = "";

            return Empty.PadRight(IndentLevel(), '\t');
        }

        /// <summary>
        /// How many levels bellow the root node are we?
        /// </summary>
        /// <returns>How many levels bellow the root node this keyvalue is</returns>
        protected virtual int IndentLevel()
        {
            if (Parent == null)
                return 0;

            return Parent.IndentLevel() + 1;
        }

        /// <summary>
        /// Quote the specified text
        /// </summary>
        /// <param name="ClearText">text to be quoted</param>
        /// <returns>numbers are untouched, otherwise cleartext surround by quotes and any quotes excaped with a leading backslash</returns>
        public static string Quote(string ClearText)
        {
            if (Steam.IsNumeric(ClearText))
            {
                return ClearText;
            }
            else
            {
                return '"' + ClearText.Replace("\"","\\\"") + '"';
            }
        }

        /// <summary>
        /// Stripo the quotes from quoted text
        /// </summary>
        /// <param name="QuotedText"></param>
        /// <returns>QuotedText without quotes and escape charecters</returns>
        public static string UnQuote(string QuotedText)
        {
            return QuotedText.Replace("\\\"", "\"");
        }

        /// <summary>
        /// Load a keyvalues file
        /// </summary>
        /// <param name="FilePath">path to the file to be loaded</param>
        /// <returns>the root node of the keyvalues file or null if an error occurs</returns>
        public static KeyValues LoadFile(string FilePath)
        {
            if (!File.Exists(FilePath))
                return null;

            KeyValvesParser Helper = new KeyValvesParser();

            using (StreamReader SR = File.OpenText(FilePath))
            {
                return Helper.Parse(SR);
            }
        }

        /// <summary>
        /// Save this node and it's children to a file
        /// </summary>
        /// <param name="FilePath">path to the file to be saved</param>
        /// <param name="Encoding">encoding for the file, not translation file must be UTF8, the default is ASCII</param>
        public virtual void Save(string FilePath, System.Text.Encoding Encoding = null)
        {
            if (Encoding == null)
                Encoding = System.Text.Encoding.Unicode;

            using (StreamWriter SR = new StreamWriter(FilePath, false, Encoding))
            {
                SR.Write(this.ToString());
                SR.Flush();
            }
        }
    } // end class

}