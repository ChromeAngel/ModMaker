using System;
using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// A text stream filter that strips out C style comments
    /// </summary>
    internal class ValveCommentStream
    {

        protected TextReader Source;
        public ValveCommentStream(TextReader source)
        {
            Source = source;
        }

        public string ReadLine()
        {
            string buffer = Source.ReadLine();

            if (buffer == null)
            {
                return null;
            }

            while (buffer.TrimStart().StartsWith("//"))
            {
                buffer = Source.ReadLine();

                if (buffer == null)
                {
                    return null;
                }
            }

            int commentIndex = buffer.IndexOf("//", StringComparison.InvariantCultureIgnoreCase);

            if (commentIndex > -1)
            {
                //looks like a C comment, but may be inside a quoted string
                bool IsQuoted = false;

                char[] bufferChars = buffer.ToCharArray();

                for (int I = 0; I <= commentIndex; I++)
                {
                    if (bufferChars[I] == '"')
                    {
                        IsQuoted = !IsQuoted;
                    }
                }

                if (!IsQuoted)
                {
                    buffer = buffer.Substring(0, commentIndex);
                }
            }

            return buffer;
        }
    }
}
