using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using LibModMaker;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility;
using System.IO;

namespace ModMaker
{

    /// <summary>
    /// Tool that uses file extensions to launch the appropriate app to view/open/process or compile a given file
    /// </summary>
    public class Compiler
    {

        public static KeyValues FileTypes = null;

        private SourceMod _Mod;

        public Compiler(SourceMod SourceMod)
        {
            if (FileTypes == null)
            {
                FileTypes = KeyValues.LoadFile(FileTypesPath());

                if (FileTypes == null)
                    throw new ApplicationException("options/FileType.txt is missing");
            }

            _Mod = SourceMod;
        }

        public bool Compile(string FilePath)
        {
            string Ext = Path.GetExtension(FilePath).TrimStart('.').ToLower();

            foreach (KeyValues Key in FileTypes.Keys)
            {
                if (Key.Name != Ext)
                    continue;

                RunCommand(Key.GetString("command"), FilePath, Key.GetBool("logwindow"));

                return true;
            }

            if (
                MessageBox.Show("Unknown file type (" + Ext + "), would you like to specify a compiler to use for this type now?",
                                "Unknown File Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return false;

            OpenFileDialog Dialog = new OpenFileDialog();

            Dialog.Title = "Select a compiler";
            Dialog.Filter = "Executables|*.exe|Executables|*.com|Command Scripts|*.cmd|Batch Files|*.bat";
            Dialog.InitialDirectory = _Mod.SDKPath;

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return false;

            //TODO make a form to collect these
            string Description = Interaction.InputBox("Please enter a description for files of type " + Ext, "Description", "File");
            string Arguments = Interaction.InputBox("Please verify these " + Dialog.FileName + " arguments", "Compiler Arguments","{FilePath}");
            KeyValues TypeKey = new KeyValues(Ext, FileTypes);
            KeyValues TempKey = new KeyValues("command", Dialog.FileName + " " + Arguments, TypeKey);

            TempKey = new KeyValues("filter", Description, TypeKey);
            FileTypes.Save(FileTypesPath());
            RunCommand(Dialog.FileName + " " + Arguments, FilePath);

            return true;
        }

        public static string FileTypesPath()
        {
            return Path.Combine(Application.StartupPath, "options/FileType.txt");
        }

        public static string[] ParseCommandLine(string CommandLine)
        {
            List<string> Result = new List<string>();

            if (string.IsNullOrEmpty(CommandLine))
                return Result.ToArray();

            if (CommandLine.Contains(" "))
            {
                bool inQuote = false;
                System.Text.StringBuilder argument = new System.Text.StringBuilder();
                Char[] commandChars = CommandLine.ToCharArray();

                for (int CharIdx = 0; CharIdx <= CommandLine.Length - 1; CharIdx++)
                {
                    switch (commandChars[CharIdx])
                    {
                        case '"':
                            inQuote = !inQuote;
                            break;
                        case ' ':
                            if (inQuote)
                            {
                                argument.Append(" ");
                            }
                            else
                            {
                                Result.Add(argument.ToString());
                                argument.Length = 0;
                            }
                            break;
                        default:
                            argument.Append(commandChars[CharIdx]);
                            break;
                    }
                }

                if (argument.Length > 0)
                    Result.Add(argument.ToString());
            }
            else
            {
                Result.Add(CommandLine);
            }

            return Result.ToArray();
        }

        public void RunCommand(string Command, string FilePath, bool LogWindow = false)
        {
            if (string.IsNullOrEmpty(Command))
                return;

            System.Text.StringBuilder Buffer = new System.Text.StringBuilder(Command);

            Buffer.Replace("{FilePath}", KeyValues.Quote(FilePath));
            Buffer.Replace("{SteamPath}", KeyValues.Quote(Steam.InstallPath));
            Buffer.Replace("{ModMakerPath}", SourceFileSystem.MakeFolderPath(Application.StartupPath));
            Buffer.Replace("{SDKPath}", KeyValues.Quote(_Mod.SDKPath));
            Buffer.Replace("{ModPath}", KeyValues.Quote(_Mod.InstallPath));
            Buffer.Replace("{AppId}", _Mod.AppId.ToString());

            string FullCommand = Buffer.ToString();

            string[] Arguments = ParseCommandLine(FullCommand);

            if (!File.Exists(Arguments[0]))
            {
                Interaction.MsgBox(
                    "Unable to find " + Arguments[0] + " to compile " + FilePath +
                    ".  Please check the file associations in File->Options.", MsgBoxStyle.Exclamation,
                    "Missing Compiler");

                return;
            }

            if (LogWindow)
            {
                frmConsoleProcessMonitor Log = new frmConsoleProcessMonitor();
                List<string> JustArgs = new List<string>();

                if (Arguments.Length > 1)
                {
                    for (int I = 1; I <= Arguments.Length - 1; I++)
                    {
                        JustArgs.Add(KeyValues.Quote(Arguments[I]));
                    }
                }

                Log.SaveLogAs = FilePath.Substring(0, FilePath.Length - 4) + ".log";
                Log.Monitor(Arguments[0], string.Join(" ", JustArgs.ToArray()));
            }
            else
            {
                try
                {
                    Process.Start(FullCommand.Substring(0, FullCommand.IndexOf(" ")), FullCommand.Substring(FullCommand.IndexOf(" ")));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.GetType().Name);
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine("RunCommand({0},{1},{2})", Command, FilePath, LogWindow);
                    Debug.WriteLine(FullCommand);

                    Interaction.MsgBox("Compile Process Failed.  Please check the file associations in File->Options.",
                        MsgBoxStyle.Exclamation, "Whoops!");
                }
            }
        }

        public string GetFileTypeFilter()
        {
            System.Text.StringBuilder Result = new System.Text.StringBuilder();

            foreach (KeyValues Key in FileTypes.Keys)
            {
                Result.AppendFormat("{0}(*.{1})|*.{1}|", Key.GetString("filter"), Key.Name);
            }

            Result.Append("Any Files|*.*");

            return Result.ToString();
        }
    }

}