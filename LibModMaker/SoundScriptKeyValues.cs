using System;
using System.IO;

namespace LibModMaker
{

    /// <summary>
    /// Sounds in Source are generally not referenced directly, but via sounds scripts that allows non-programmers to change and configure sounds
    /// </summary>
    public class SoundScriptKeyValues : KeyValues
    {
        protected override int IndentLevel()
        {
            return -1;
        }

        public static SoundScriptKeyValues Load(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                return null;
            }

            SoundScriptKeyParser Helper = new SoundScriptKeyParser();

            using (StreamReader SR = File.OpenText(FilePath))
            {
                return Helper.Parse(SR) as SoundScriptKeyValues;
            }
        }

        public override void Save(string FilePath, System.Text.Encoding Encoding = null)
        {
            if (Encoding == null)
            {
                Encoding = System.Text.Encoding.Unicode;
            }

            using (StreamWriter SR = new StreamWriter(FilePath, false, Encoding))
            {
                if (Keys != null && Keys.Count > 0)
                {
                    foreach (var Child in Keys)
                    {
                        SR.WriteLine(Child.ToString());
                    }
                }

                SR.Flush();
            }
        }

        private class SoundScriptKeyParser : KeyValvesParser
        {

            public override KeyValues Parse(TextReader Source)
            {
                Context = new SoundScriptKeyValues();
                InnerParser.Parse(Source);

                KeyValues Result = Context;

                Context = null;

                while (Result.Parent != null)
                {
                    Result = Result.Parent;
                }

                return Result;
            }
        }
    } //End class

}