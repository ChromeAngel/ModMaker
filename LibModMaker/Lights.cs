using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace LibModMaker
{
    /// <summary>
    /// Models the format of the lights.rad files
    /// </summary>
    public class Lights
    {
        public string FilePath = null;

        public List<Rule> Rules = new List<Rule>();
        public Lights()
        {
        }

        public static Lights Load(string FilePath)
        {
            if (!File.Exists(FilePath))
                return null;

            Lights Result = new Lights { FilePath = FilePath };

            using (StreamReader FS = new StreamReader(FilePath))
            {
                string Line = FS.ReadLine();

                while (Line != null)
                {
                    Rule ThisRule = Rule.Parse(Line);

                    if (ThisRule != null)
                        Result.Rules.Add(ThisRule);

                    Line = FS.ReadLine();
                }
            }

            return Result;
        }

        public bool Save(string FilePath = null)
        {
            if (FilePath == null)
                FilePath = this.FilePath;
            if (FilePath == null)
                return false;

            SourceFileSystem.BackUpFile(FilePath);

            try
            {
                using (StreamWriter FR = new StreamWriter(FilePath))
                {
                    foreach (Rule R in Rules)
                    {
                        FR.WriteLine(R.ToString());
                    }
                }

                this.FilePath = FilePath;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public class Rule
        {
            public bool LDR_Only;

            public bool HDR_Only;
            public static Rule Parse(string Line)
            {
                if (Line.Trim().Length == 0)
                    return null;
                if (Line.StartsWith("hdr:ldr:"))
                    return null;
                // comments

                bool LDR_Only = Line.StartsWith("ldr:");
                bool HDR_Only = Line.StartsWith("hdr:");

                if (LDR_Only | HDR_Only)
                    Line = Line.Substring(4).TrimStart();

                Rule Result = null;

                if (Line.StartsWith("noshadow"))
                    Result = NoShadow.Parse(Line);
                if (Line.StartsWith("forcetextureshadow"))
                    Result = ForceTextureShadow.Parse(Line);
                if (Result == null)
                    Result = TextureLight.Parse(Line);
                if (Result != null)
                {
                    Result.HDR_Only = HDR_Only;
                    Result.LDR_Only = LDR_Only;
                }

                return Result;
            }

            public override string ToString()
            {
                if (LDR_Only & HDR_Only)
                    return "";
                if (LDR_Only)
                    return "ldr:";
                if (HDR_Only)
                    return "hdr:";

                return "";
            }
        }

        public class NoShadow : Rule
        {


            public string material;
            public static new NoShadow Parse(string Line)
            {
                NoShadow Result = new NoShadow { material = Line.Substring("noshadow".Length + 1).Trim() };

                return Result;
            }

            public override string ToString()
            {
                return string.Format("{0}noshadow {1}", base.ToString(), material);
            }
        }

        public class ForceTextureShadow : Rule
        {


            public string model;
            public static new ForceTextureShadow Parse(string Line)
            {
                ForceTextureShadow Result = new ForceTextureShadow { model = Line.Substring("forcetextureshadow".Length + 1).Trim() };

                return Result;
            }

            public override string ToString()
            {
                return string.Format("{0}forcetextureshadow {1}", base.ToString(), model);
            }
        }

        public class TextureLight : Rule
        {

            public string material;
            public byte red;
            public byte green;
            public byte blue;
            public int intensity;
            //<material> <red> <green> <blue> <intensity>

            public Color color
            {
                get { return Color.FromArgb(255, red, green, blue); }
                set
                {
                    red = value.R;
                    green = value.G;
                    blue = value.B;
                }
            }

            public static new TextureLight Parse(string Line)
            {
                char[] Whitespace = { ' ', '\t' };
                string[] Parts = Line.Split(Whitespace);

                if (Parts.Length < 5)
                    return null;
                if (Parts.Length > 5)
                    return HDR_TextureLight.Parse(Parts);

                TextureLight Result = new TextureLight();

                Result.material = Parts[0];

                if (!byte.TryParse(Parts[1], out Result.red))
                    return null;
                if (!byte.TryParse(Parts[2], out Result.green))
                    return null;
                if (!byte.TryParse(Parts[3], out Result.blue))
                    return null;
                if (!int.TryParse(Parts[4], out Result.intensity))
                    return null;

                return Result;
            }

            public override string ToString()
            {
                return string.Format("{0}{1}{2}{3} {4} {5} {6}", base.ToString(), material, '\t', red, green, blue, intensity);
            }
        }

        public class HDR_TextureLight : TextureLight
        {

            public byte HDR_red;
            public byte HDR_green;
            public byte HDR_blue;

            public int HDR_intensity;
            public Color HDR_color
            {
                get { return Color.FromArgb(255, HDR_red, HDR_green, HDR_blue); }
                set
                {
                    HDR_red = value.R;
                    HDR_green = value.G;
                    HDR_blue = value.B;
                }
            }

            public HDR_TextureLight()
            {
            }

            public HDR_TextureLight(TextureLight Base)
            {
                if (Base == null)
                    return;

                material = Base.material;
                red = Base.red;
                green = Base.green;
                blue = Base.blue;
                intensity = Base.intensity;
                LDR_Only = Base.LDR_Only;
                HDR_Only = Base.HDR_Only;
            }

            public static HDR_TextureLight Parse(string[] Parts)
            {
                HDR_TextureLight Result = new HDR_TextureLight { material = Parts[0] };

                if (!byte.TryParse(Parts[1],out Result.red))
                    return null;
                if (!byte.TryParse(Parts[2],out Result.green))
                    return null;
                if (!byte.TryParse(Parts[3],out Result.blue))
                    return null;
                if (!int.TryParse(Parts[4],out Result.intensity))
                    return null;

                if (!byte.TryParse(Parts[5],out Result.HDR_red))
                    return null;
                if (!byte.TryParse(Parts[6],out Result.HDR_green))
                    return null;
                if (!byte.TryParse(Parts[7],out Result.HDR_blue))
                    return null;
                if (!int.TryParse(Parts[8],out Result.HDR_intensity))
                    return null;

                return Result;
            }

            public static new HDR_TextureLight Parse(string Line)
            {
                char[] Whitespace = {' ','\t'};
                string[] Parts = Line.Split(Whitespace);

                return Parse(Parts);
            }

            public override string ToString()
            {
                if (HDR_intensity == 0 || (HDR_red == 0 && HDR_green == 0 && HDR_blue == 0))
                {
                    return base.ToString();
                }

                return string.Format("{0} {1} {2} {3} {4}", base.ToString(), HDR_red, HDR_green, HDR_blue, HDR_intensity);
            }
        }
    }

}
