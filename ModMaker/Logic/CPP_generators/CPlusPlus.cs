using LibModMaker;
using System;
using System.IO;
using System.Drawing;

namespace ModMaker
{

    /// <summary>
    /// Helper for generating valid C++ class, method and varible names
    /// </summary>
    public class CPlusPlus
    {
        public static string ToID(string Plain)
        {
            if (string.IsNullOrEmpty(Plain))
                throw new ArgumentException("Plain required");

            System.Text.StringBuilder Result = new System.Text.StringBuilder(Plain.Length);

            char[] plainChars = Plain.ToCharArray();

            if (char.IsDigit(plainChars[0]))
                Result.Append("_");

            foreach (char C in plainChars)
            {
                if (char.IsLetterOrDigit(C) | C == '_')
                    Result.Append(C);
            }

            return Result.ToString();
        }
    }

}