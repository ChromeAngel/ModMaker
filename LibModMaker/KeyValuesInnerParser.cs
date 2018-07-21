using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// Low-level helper class for parsing KeyValues files (see KeyValues.cs)
    /// </summary>
    internal class KeyValuesInnerParser
    {
        internal class SetStartEventArgs : EventArgs
        {
            public string Key;
            internal SetStartEventArgs(string SetKey)
            {
                Key = SetKey;
            }
        }

        internal class KeyEventArgs : SetStartEventArgs
        {
            public string Value;
            internal KeyEventArgs(string KeyName, string KeyValue) : base(KeyName)
            {
                Value = KeyValue;
            }
        }

        public event SetStartEventHandler SetStart;
        public delegate void SetStartEventHandler(object sender, SetStartEventArgs e);
        public event SetEndEventHandler SetEnd;
        public delegate void SetEndEventHandler(object sender, EventArgs e);
        public event ReadKeyEventHandler ReadKey;
        public delegate void ReadKeyEventHandler(object sender, KeyEventArgs e);
        public event SetLastKeyConditionEventHandler SetLastKeyCondition;
        public delegate void SetLastKeyConditionEventHandler(object Sender, SetStartEventArgs e);
        public event SetConditionEventHandler SetCondition;
        public delegate void SetConditionEventHandler(object Sender, SetStartEventArgs e);


        private static System.Text.RegularExpressions.Regex KeyValueRegex = new System.Text.RegularExpressions.Regex("\\s*(\\x22.*\\x22|\\S*)\\s*(\\x22.*\\x22|\\S*)\\s*");
        private System.Text.StringBuilder Read = new System.Text.StringBuilder();
        private string Key = null;
        private bool InQuote = false;
        private bool InCondition = false;

        private char PrevChar = '\0';
        public void Parse(TextReader Source)
        {
            if (Source == null)
                throw new ArgumentNullException();

            ValveCommentStream CommentStripper = new ValveCommentStream(Source);
            string Buffer = CommentStripper.ReadLine();

            Read.Length = 0;
            Key = null;
            InQuote = false;

            while (Buffer != null)
            {
                if (!InQuote)
                {
                    Buffer = Buffer.TrimStart();
                }

                foreach (char BC in Buffer)
                {
                    if (InQuote)
                    {
                        ParseQuoted(BC);
                    }
                    else
                    {
                        ParseUnQuoted(BC);
                    }
                }

                if (Read.Length > 0)
                {
                    HandleKeyOrValue();
                }

                Buffer = CommentStripper.ReadLine();
            }
        }

        private void HandleKeyOrValue()
        {
            if (Key == null)
            {
                Key = Read.ToString();
            }
            else
            {
                if (ReadKey != null)
                {
                    ReadKey(this, new KeyEventArgs(Key, Read.ToString()));
                }

                Key = null;
            }

            Read.Length = 0;
        }

        private void ParseQuoted(char BC)
        {
            switch (BC)
            {
                case '"':
                    if (PrevChar == '\\')
                    {
                        Read.Append(BC);
                    }
                    else
                    {
                        HandleKeyOrValue();
                        InQuote = false;
                    }
                    break;
                default:
                    Read.Append(BC);
                    break;
            }

            PrevChar = BC;
        }

        private void ParseUnQuoted(char BC)
        {
            PrevChar = '\0';

            if (BC == '"')
            {
                InQuote = true;

                return;
            }

            if (Key == null)
            {
                switch (BC)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                        if (Read.Length > 0)
                        {
                            Key = Read.ToString();
                            Read.Length = 0;
                        }
                        break;
                    case '}':
                        if (SetEnd != null)
                        {
                            SetEnd(this, EventArgs.Empty);
                        }
                        break;
                    case '[':
                        InCondition = true;
                        break;
                    case ']':
                        //Coniditions may occur on the end of value lines too in which cas they apply to the values just read
                        if (InCondition)
                        {
                            InCondition = false;

                            if (SetLastKeyCondition != null)
                            {
                                SetLastKeyCondition(this, new SetStartEventArgs(Read.ToString()));
                            }

                            Read.Length = 0;
                        }
                        else
                        {
                            Read.Append(BC);
                        }
                        break;
                    default:
                        Read.Append(BC);
                        break;
                }
            }
            else
            {
                switch (BC)
                {
                    case '{':
                        if (SetStart != null)
                        {
                            SetStart(this, new SetStartEventArgs(Key.Trim()));
                        }


                        Key = null;
                        break;
                    case '}':
                        if (SetEnd != null)
                        {
                            SetEnd(this, EventArgs.Empty);
                        }
                        break;
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                    //ignore whitespace between a key and a value
                    case '[':
                        InCondition = true;
                        break;
                    case ']':
                        if (InCondition)
                        {
                            InCondition = false;

                            if (SetCondition != null)
                            {
                                SetCondition(this, new SetStartEventArgs(Read.ToString()));
                            }

                            Read.Length = 0;
                        }
                        else
                        {
                            Read.Append(BC);
                        }
                        break;
                    default:
                        Read.Append(BC);
                        break;
                }
            }
        }


    }
}
