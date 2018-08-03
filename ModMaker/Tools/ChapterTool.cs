using LibModMaker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ModMaker
{

    /// <summary>
    /// Tool for managing chapters (sequences of maps, like chapters in a book) for a game
    /// </summary>
    public class ChapterTool : iTool
    {

        /// <summary>
        /// Icon for the tools view
        /// </summary>
        public System.Drawing.Image Image
        {
            get { return Properties.Resources.Chapter.ToBitmap(); }
        }

        /// <summary>
        /// Is this tool usefull for the given game?
        /// </summary>
        /// <param name="Game"></param>
        /// <returns>true if this tool is valid for the given game</returns>
        public bool IsValidForMod(LibModMaker.SourceMod Game)
        {
            if (Game == null) return false;

            KeyValues GameInfo = KeyValues.LoadFile(Game.GameInfoPath);

            if (GameInfo == null) return false;

            if (GameInfo.GetString("type") == "multiplayer_only") return false;

            return true;
        }

        /// <summary>
        /// Launch this tool for the given Game
        /// </summary>
        /// <param name="Game"></param>
        public void Launch(LibModMaker.SourceMod Game)
        {
            ChapterList Chapters = new ChapterList();

            Chapters.Load(Game);

            ChaptersForm Dialog = new ChaptersForm{ Game = Game };

            Dialog.Chapters = Chapters;

            if (Dialog.ShowDialog() != DialogResult.OK) return;

            Dialog.GatherChanges();

            //save it
            Dialog.Chapters.Save(Game);
        }

        /// <summary>
        /// Tool name for use in the tools view
        /// </summary>
        public string Name
        {
            get { return "Chapter Maker"; }
        }

        /// <summary>
        /// Tool tip text when the user mouses over this tool in the view
        /// </summary>
        public string TipText
        {
            get { return "Add chapters to your mod"; }
        }

        /// <summary>
        /// Conceptual Chapter to work with
        /// </summary>
        public class Chapter
        {
            /// <summary>
            /// Order that Chapters are played in
            /// </summary>
            public int Index;

            /// <summary>
            /// Title of the chapter to be shown to the player
            /// </summary>
            public string Title;

            /// <summary>
            /// Name of the first BSP in the chapyer
            /// </summary>
            public string Map;

            /// <summary>
            /// Path to the Thumbnail image for this chapter
            /// </summary>
            public string Thumbnail;

            /// <summary>
            /// Translation token for this chapters title
            /// </summary>
            /// <param name="Game"></param>
            /// <returns>{gamename}_chapter{index}</returns>
            public string TitleToken(SourceMod Game)
            {
                return string.Format("{0}_Chapter{1}_Title", Game.InstallFolder, Index);
            }

            /// <summary>
            /// Relative path to this chapter's config file
            /// </summary>
            /// <returns></returns>
            public string ConfigFilePath()
            {
                return String.Format("cfg/chapter{0}.cfg", Index);
            }

            public bool Save(ref Dictionary<string, string> Tokens, SourceMod Game)
            {
                Tokens[TitleToken(Game)] = Title;

                string CfgFilePath = Path.Combine(Game.InstallPath, ConfigFilePath());

                //Backup the chapter config file before we overwrite it
                SourceFileSystem.BackUpFile(CfgFilePath);

                //Save the map command
                using (StreamWriter ConfigFileStream = new StreamWriter(CfgFilePath))
                {
                    ConfigFileStream.WriteLine("{0}{1}", mapCommand, Path.GetFileNameWithoutExtension(Map));
                }

                if (!File.Exists(Thumbnail)) return false;

                Bitmap ThumbnailBmp = GetThumbnailBitmap(Thumbnail);
                Bitmap VtfReadyThumbail = new Bitmap(256, 128, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                Graphics gfx = Graphics.FromImage(VtfReadyThumbail);

                gfx.Clear(Color.Black);
                gfx.DrawImageUnscaled(ThumbnailBmp, 0, 0);
                gfx.Flush();

                TGA TGA = new TGA(VtfReadyThumbail);
                string FolderPath = Path.Combine(Game.SourcePath, "materialsrc", "vgui", "chapters");

                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                string TGAPath = Path.Combine(FolderPath, string.Format("chapter{0}.tga", Index));

                TGA.Save(TGAPath);

                string VtexConfigPath = Path.Combine(FolderPath, string.Format("chapter{0}.txt", Index));

                using (StreamWriter ConfigFile = new StreamWriter(VtexConfigPath))
                {
                    ConfigFile.WriteLine("nolod 1");
                    ConfigFile.WriteLine("nomip 1");
                }

                if (!Steam.IsRunning()) Steam.Launch();

                string OutputFolderPath = Path.Combine(Game.InstallPath, "materials", "vgui", "chapters");
                if (!Directory.Exists(OutputFolderPath))
                {
                    Directory.CreateDirectory(OutputFolderPath);
                }

                System.Diagnostics.Process Vtex = new System.Diagnostics.Process();

                Vtex.StartInfo.FileName = "vtex.exe";
                Vtex.StartInfo.Arguments = String.Format(
                    "-outdir \"{0}\" -mkdir -quiet -nopause -shader UnlitGeneric -vmtparam $vertexalpha 1 \"{1}\"",
                    OutputFolderPath,
                    TGAPath
                );
                Vtex.StartInfo.CreateNoWindow = true;
                Vtex.StartInfo.WorkingDirectory = Game.SDKPath;
                Vtex.StartInfo.UseShellExecute = true;

                Vtex.Start();
                Vtex.WaitForExit();

                return true;
            }
        } // end of the Chapter class

        private static string mapCommand = "map ";

        /// <summary>
        /// Conceptual list of Chapters
        /// </summary>
        public class ChapterList : List<Chapter>
        {

            /// <summary>
            /// Load the chapter information about a given game
            /// </summary>
            /// <param name="Game"></param>
            public void Load(SourceMod Game)
            {
                string[] Configs = Directory.GetFiles(Path.Combine(Game.InstallPath, "cfg"), "chapter*.cfg");

                Clear();

                foreach (string ConfigFilePath in Configs)
                {
                    //trim the leading 7 charecters "chapter" off of the filename, the remainder is expected to be the chapter index
                    string strIndex = Path.GetFileNameWithoutExtension(ConfigFilePath).Substring("chapter".Length);  
                    int Index = -1;

                    if (!int.TryParse(strIndex,out Index))
                        continue; //strIndex is not an integer skip this file

                    Chapter Result = new Chapter {Index = Index};

                    //Get title from localization
                    Result.Title = Game.Localize(Result.TitleToken(Game));
                    Result.Thumbnail = Path.Combine(Game.InstallPath, "materials", "vgui", "chapters", string.Format("chapter{0}.vtf", Index));

                    if (!File.Exists(Result.Thumbnail)) Result.Thumbnail = null;

                    //get map from the config file
                    using (StreamReader CfgFile = new StreamReader(ConfigFilePath))
                    {
                        string Line = CfgFile.ReadLine();

                        while (Line != null)
                        {
                            Line = Line.Trim();

                            if (Line.StartsWith(mapCommand))
                            {
                                //Get Map from config file, this trims the leading "map " command
                                Result.Map = Line.Substring(mapCommand.Length);

                                break; // TODO: might not be correct. Was : Exit While
                            }
                            else
                            {
                                Line = CfgFile.ReadLine();
                            }
                        }
                    }

                    //Can't actually load the thumbnail :/
                    this.Add(Result);
                }
            }

            /// <summary>
            /// Save our chapter information to the given game's folder structure
            /// </summary>
            /// <param name="Game"></param>
            public void Save(SourceMod Game)
            {
                Dictionary<string, string> Tokens = new Dictionary<string, string>();

                foreach (Chapter C in this)
                {
                    C.Save(ref Tokens, Game);
                }

                //Save tokens to the localization file
                SaveTokens(Game, Tokens);

                SaveTitle(Game, Tokens);
            }


            /// <summary>
            /// Save our chapter titles to scripts/titles.txt
            /// </summary>
            /// <param name="Game"></param>
            /// <param name="NewTokens">translation tokens for chapter titles</param>
            /// <returns>true on sucess</returns>
            private bool SaveTitle(SourceMod Game, Dictionary<string, string> NewTokens)
            {
                if (NewTokens == null) return false;
                if (NewTokens.Count == 0) return true;

                string TitleFilePath = Path.Combine(Game.InstallPath, "scripts", "titles.txt");

                if (File.Exists(TitleFilePath))
                {
                    //editing

                    //Backup the existing titles before we begin
                    SourceFileSystem.BackUpFile(TitleFilePath);

                    int LineIndex = -1;
                    int ChapterStartOffset = -1;
                    int PositionOffset = -1;
                    int ChapterFinishOffset = -1;
                    string[] TitleLines = File.ReadAllLines(TitleFilePath);

                    foreach (string Line in TitleLines)
                    {
                        LineIndex += 1;

                        if (ChapterStartOffset == -1)
                        {
                            if (Line.Contains("//CHAPTER TITLES"))
                                ChapterStartOffset = LineIndex;
                        }
                        else
                        {
                            if (Line.Contains("$position"))
                            {
                                if (PositionOffset == -1)
                                {
                                    PositionOffset = LineIndex;
                                    //1st $position after the //CHAPTER TITLES
                                }
                                else
                                {
                                    if (ChapterFinishOffset == -1)
                                    {
                                        ChapterFinishOffset = LineIndex;
                                        //2nd $position after the //CHAPTER TITLES

                                        break; // TODO: might not be correct. Was : Exit For
                                    }
                                }
                            }
                        }
                    }

                    if (PositionOffset < 0)
                    {
                        //Missing //CHAPTER TITLES or $position
                        //Append our titles to the end
                        using (FileStream RawFile = new FileStream(TitleFilePath, FileMode.Append))
                        {
                            using (StreamWriter TitlesFileStream = new StreamWriter(RawFile))
                            {
                                TitlesFileStream.WriteLine("//CHAPTER TITLES");
                                TitlesFileStream.WriteLine();
                                TitlesFileStream.WriteLine("$fadein 0.01");
                                TitlesFileStream.WriteLine("$holdtime 3.5");
                                TitlesFileStream.WriteLine("$position -1 0.58");

                                WriteTitles(NewTokens, TitlesFileStream);
                            }
                        }
                    }
                    else
                    {
                        //Replace the existing chapter titles with our own
                        File.Delete(TitleFilePath);

                        using (StreamWriter TitlesFileStream = new StreamWriter(TitleFilePath))
                        {
                            for (LineIndex = 0; LineIndex <= PositionOffset; LineIndex++)
                            {
                                TitlesFileStream.WriteLine(TitleLines[LineIndex]);
                            }

                            WriteTitles(NewTokens, TitlesFileStream);

                            TitlesFileStream.WriteLine();

                            if (ChapterFinishOffset > PositionOffset)
                            {
                                for (LineIndex = ChapterFinishOffset;
                                    LineIndex <= TitleLines.GetUpperBound(0);
                                    LineIndex++)
                                {
                                    TitlesFileStream.WriteLine(TitleLines[LineIndex]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //create
                    using (StreamWriter TitlesFileStream = new StreamWriter(TitleFilePath))
                    {
                        TitlesFileStream.WriteLine("//CHAPTER TITLES");
                        TitlesFileStream.WriteLine();
                        TitlesFileStream.WriteLine("$fadein 0.01");
                        TitlesFileStream.WriteLine("$holdtime 3.5");
                        TitlesFileStream.WriteLine("$position -1 0.58");

                        WriteTitles(NewTokens, TitlesFileStream);
                    }
                }

                return true;
            }

            /// <summary>
            /// Write the translation tokens to the given file string
            /// </summary>
            /// <param name="NewTokens"></param>
            /// <param name="File"></param>
            void WriteTitles(Dictionary<string, string> NewTokens, StreamWriter File)
            {
                File.WriteLine();
                File.WriteLine("//ModMaker Chapter Titles");
                File.WriteLine();

                foreach (string Token in NewTokens.Keys)
                {
                    File.WriteLine(Token.ToUpper());
                    File.WriteLine("{");
                    File.WriteLine("#" + Token);
                    File.WriteLine("}");
                    File.WriteLine();
                }
            }

            /// <summary>
            /// Save the translation tokens and local equivilents to the language specific localization file
            /// </summary>
            /// <param name="Game"></param>
            /// <param name="NewTokens"></param>
            /// <param name="Language"></param>
            /// <returns>true on success</returns>
            public bool SaveTokens(SourceMod Game, Dictionary<string, string> NewTokens, string Language = "English")
            {
                if (NewTokens == null) return false;
                if (NewTokens.Count == 0) return true;

                string LanguageFilePath = Path.Combine(Game.InstallPath, "resource");

                LanguageFilePath = Path.Combine(LanguageFilePath, String.Format("{0}_{1}.txt", Game.InstallFolder ,Language));

                if (!File.Exists(LanguageFilePath)) return false;

                //Backup files before changing them
                SourceFileSystem.BackUpFile(LanguageFilePath);

                KeyValues LocalizationFile = KeyValues.LoadFile(LanguageFilePath);

                if (LocalizationFile == null) return false;

                KeyValues Tokens = LocalizationFile.GetKey("Tokens");

                if (Tokens == null) return false;

                foreach (var Token in NewTokens.Keys)
                {
                    Tokens.SetValue(Token, NewTokens[Token]);
                }

                LocalizationFile.Save(LanguageFilePath);

                return true;
            }
        } // end of the chapter list class

        //dimensions in pixels of the thumbnail images for each chapter
        const int ThumbnailWidth = 152;
        const int ThumbnailHeight = 86;

        /// <summary>
        /// Get a bitmap version of the given file path
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns>A bitmap ThumbnailWidth x ThumbnailHeight</returns>
        public static Bitmap GetThumbnailBitmap(string FilePath)
        {
            GraphicsUnit pixel = GraphicsUnit.Pixel;
            Bitmap RawImage = OpenBitmap(FilePath);
            Bitmap ThumbnailImage = new Bitmap(ThumbnailWidth, ThumbnailHeight);
            Graphics Gfx = Graphics.FromImage(ThumbnailImage);

            Gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            if (RawImage != null)
            {
                Gfx.DrawImage(RawImage, ThumbnailImage.GetBounds(ref pixel));
            }

            Gfx.Flush();

            return ThumbnailImage;
        }

        /// <summary>
        /// Get a bitmap version of the given file path
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns>null for unknown file types</returns>
        public static Bitmap OpenBitmap(string FilePath)
        {
            switch (Path.GetExtension(FilePath))
            {
                case ".tga":
                    return Paloma.TargaImage.LoadTargaImage(FilePath);
                case ".vtf":
                    using (VTFConverter Converter = new VTFConverter())
                    {
                        return Converter.ToBitmap(FilePath);
                    }

                case ".bmp":
                case ".jpg":
                case ".png":
                case ".gif":
                    return new Bitmap(FilePath);
                default:
                    return null;
            }
        }
    }

}