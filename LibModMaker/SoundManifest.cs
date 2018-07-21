using System;
using System.IO;
using System.Collections.Generic;

namespace LibModMaker
{
    /// <summary>
    /// The sound manifest tells Source what sound scripts to use
    /// sound scripts tell Source what sounds to load/cache and what the aliases used by the code are
    /// </summary>
    public class SoundManifest
    {
        public event ProgressEventHandler Progress;

        public delegate void ProgressEventHandler(object sender, string Text);

        public event CreatedScriptFileEventHandler CreatedScriptFile;

        public delegate void CreatedScriptFileEventHandler(object sender, string FilePath);

        public event CreatedScriptEntryEventHandler CreatedScriptEntry;

        public delegate void CreatedScriptEntryEventHandler(
            object sender, string ScriptFilePath, string SoundFile, string ScriptSoundName);

        public KeyValues Manifest = null;

        public Dictionary<string, SoundScriptKeyValues> SoundScriptFiles =
            new Dictionary<string, SoundScriptKeyValues>();

        public SourceMod Game { get; set; }

        private SourceFileSystem _fileSystem = null;

        public string ScriptsPath
        {
            get { return System.IO.Path.Combine(Game.InstallPath, "scripts"); }
        }

        public string ManifestPath
        {
            get { return System.IO.Path.Combine(ScriptsPath, "game_sounds_manifest.txt"); }
        }

        public SoundManifest(SourceMod Game)
        {
            this.Game = Game;
            _fileSystem = new SourceFileSystem(Game);

         }

    public void AddLooseFilesToManifest()
        {
            bool hasManifest = true;
            //If MOD does not have manifest copy the one from the GAME folder
            if (!System.IO.File.Exists(ManifestPath))
            {
                hasManifest = false;

                //Try and mount the file system
                var sfs = new SourceFileSystem(Game);

                //does the file system contain a copy of the manifest
                if(sfs.Contains("sctipts/game_sounds_manifest.txt"))
                {
                    hasManifest = sfs.Extract("sctipts/game_sounds_manifest.txt", ScriptsPath);
                }

            }

            if (!hasManifest)
            {
                string gameExeFolder = Game.GameExeFolder();

                if (gameExeFolder != null)
                {
                    string gameManifestPath = System.IO.Path.Combine(gameExeFolder, "hl2/scripts/game_sounds_manifest.txt");

                    if (System.IO.File.Exists(gameManifestPath))
                    {
                        if (!System.IO.Directory.Exists(ScriptsPath))
                            System.IO.Directory.CreateDirectory(ScriptsPath);

                        System.IO.File.Copy(gameManifestPath, ManifestPath);

                        hasManifest = true;
                    }
                }
                
            }

            if (!hasManifest)
            {
                throw new ApplicationException("game_sounds_manifest.txt not found");
                //TODO make our own, blank manifest
            }

            Load(ManifestPath);

            List<string> UnRefrencedFiles = GetUnRefrencedFiles();

            if (UnRefrencedFiles.Count == 0)
                return;

            if (Progress != null)
            {
                Progress(this, "Scripting Loose Files");
            }

            Dictionary<string, List<string>> FilesByFolder = new Dictionary<string, List<string>>();
            int NewScriptCount = 0;
            string Folder;

            foreach (string LooseFile in UnRefrencedFiles)
            {
                if (LooseFile.Contains("/"))
                {
                    Folder = LooseFile.Substring(0, LooseFile.LastIndexOf("/"));
                    Folder = Folder.Trim('/');
                }
                else
                {
                    Folder = "base";
                }

                if (!FilesByFolder.ContainsKey(Folder))
                {
                    FilesByFolder[Folder] = new List<string>();
                }

                FilesByFolder[Folder].Add(LooseFile);
            }

            foreach (string SubFolder in FilesByFolder.Keys)
            {
                string ScriptFileName = string.Format("scripts/{0}_{1}_sounds.txt", Game.InstallFolder, SubFolder.Replace("/", "_"))  ;

                ScriptFileName = ScriptFileName.Replace("__", "_");

                SoundScriptKeyValues SoundScriptFile;

                if (!SoundScriptFiles.ContainsKey(ScriptFileName))
                {
                    NewScriptCount += 1;
                    SoundScriptFiles.Add(ScriptFileName, new SoundScriptKeyValues());

                    KeyValues ManifestEntry = new KeyValues("precache_file", ScriptFileName, Manifest);

                    if (CreatedScriptFile != null)
                    {
                        CreatedScriptFile(this, ScriptFileName);
                    }
                }

                SoundScriptFile = SoundScriptFiles[ScriptFileName];

                foreach (string LooseFile in FilesByFolder[SubFolder])
                {
                    KeyValues Script = new KeyValues(System.IO.Path.GetFileNameWithoutExtension(LooseFile), SoundScriptFile);

                    Script.SetValue("channel", "CHAN_AUTO");
                    Script.SetValue("volume", "VOL_NORM");
                    Script.SetValue("soundlevel", "SNDLVL_NORM");
                    Script.SetValue("pitch", "PITCH_NORM");
                    Script.SetValue("wave", LooseFile);

                    if (CreatedScriptEntry != null)
                    {
                        CreatedScriptEntry(this, ScriptFileName, LooseFile, Script.Name);
                    }
                }

                ScriptFileName = System.IO.Path.Combine(Game.InstallPath, ScriptFileName);
                BackUpFile(ScriptFileName);
                SoundScriptFile.Save(ScriptFileName);
            }

            if (NewScriptCount > 0)
            {
                BackUpFile(ManifestPath);
                Manifest.Save(ManifestPath);
            }

            if (Progress != null)
            {
                Progress(this, "Done");
            }
        }

        public void Load()
        {
            //If MOD does not have manifest copy the one from the GAME folder
            //TODO use the SourceFileSystem class to check if it's packaged with the mod
            if (!System.IO.File.Exists(ManifestPath))
            {
                string folder = Path.GetDirectoryName(ManifestPath);

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string gameExePath = Game.GameExeFolder();

                if (gameExePath != null)
                {
                    string GameManifestPath = System.IO.Path.Combine(gameExePath, "hl2/scripts/game_sounds_manifest.txt");

                    if (System.IO.File.Exists(GameManifestPath))
                    {
                        System.IO.File.Copy(GameManifestPath, ManifestPath);
                    }                    
                } //end has game exe path

            }

            Load(ManifestPath);
        }

        public void Load(string ManifestPath)
        {
            if (Progress != null)
            {
                Progress(this, "Loading manifest");
            }

            if (!System.IO.File.Exists(ManifestPath))
            {
                if( _fileSystem.Contains("scripts/game_sounds_manifest.txt") )
                {
                    _fileSystem.Extract("scripts/game_sounds_manifest.txt", Game.InstallPath);
                } else
                {
                    Manifest = new KeyValues("game_sounds_manifest");
                }

                return;
            }

            Manifest = KeyValues.LoadFile(ManifestPath);

            if (Progress != null)
            {
                Progress(this, "Loaded manifest");
            }

            if (Manifest == null)
                return;

            string ScriptPath;

            if (Progress != null)
            {
                Progress(this, "Loading scripts");
            }

            foreach (var K in Manifest.Keys)
            {
                if (SoundScriptFiles.ContainsKey(K.Value)) continue;

                ScriptPath = System.IO.Path.Combine(Game.InstallPath, K.Value);

                if (!System.IO.File.Exists(ScriptPath)) continue;

                SoundScriptFiles.Add(K.Value, SoundScriptKeyValues.Load(ScriptPath));
            }

            if (Progress != null)
            {
                Progress(this, "Loaded scripts");
            }
        }

        List<string> GetReferencedFiles()
        {
            List<string> Result = new List<string>();

            if (Progress != null)
            {
                Progress(this, "Getting Referenced Files");
            }

            if (SoundScriptFiles.Count == 0)
                return Result;

            //loop through the script files mentioned in the manifest
            foreach (KeyValues ScriptFile in SoundScriptFiles.Values)
            {
                if (ScriptFile == null)
                    continue;

                //loop through each script sound in the script file
                foreach (KeyValues Script in ScriptFile.Keys)
                {
                    KeyValues RndWave = Script.GetKey("rndwave");
                    string Wave;

                    //look for a set of random waves
                    if (RndWave == null)
                    {
                        //look for a single named wave
                        Wave = Script.GetString("wave", null);

                        if (Wave != null)
                        {
                            if (!Result.Contains(Wave))
                                Result.Add(Wave);
                        }

                    }
                    else
                    {
                        //add each of the possible waves
                        foreach (var WaveKey in RndWave.Keys)
                        {
                            if (WaveKey.Name == "wave")
                            {
                                Wave = (WaveKey.Value);

                                if (Wave != null)
                                {
                                    if (!Result.Contains(Wave))
                                        Result.Add(Wave);
                                }
                            }
                        }
                    }
                }
            }

            if (Progress != null)
            {
                Progress(this, "Found " + Result.Count + " referenced sounds");
            }

            return Result;
        }

        List<string> GetLooseFiles()
        {
            List<string> Result = new List<string>();
            string SoundPath = System.IO.Path.Combine(Game.InstallPath, "sound");

            if (Progress != null)
            {
                Progress(this, "Getting Loose Files");
            }

            if (System.IO.Directory.Exists(SoundPath))
                AddLooseFiles(SoundPath, Result);

            if (Progress != null)
            {
                Progress(this, "Found " + Result.Count + " loose sounds");
            }

            return Result;
        }

        private void AddLooseFiles(string FolderPath, List<string> List)
        {
            string[] Files = System.IO.Directory.GetFiles(FolderPath, "*.wav");

            List.AddRange(Files);
            Files = System.IO.Directory.GetFiles(FolderPath, "*.mp3");
            List.AddRange(Files);

            string[] Folders = System.IO.Directory.GetDirectories(FolderPath);

            foreach (string Folder in Folders)
            {
                AddLooseFiles(Folder, List);
            }
        }

        List<string> GetUnRefrencedFiles()
        {
            List<string> Result = new List<string>();
            List<string> LooseFiles = GetLooseFiles();

            if (Progress != null)
            {
                Progress(this, "Getting UnRefrenced Loose Files");
            }

            if (LooseFiles.Count == 0)
                return Result;

            List<string> ReferencedFiles = GetReferencedFiles();
            string SoundPath = System.IO.Path.Combine(Game.InstallPath, "sound");

            foreach (string LooseFile in LooseFiles)
            {
                string strLooseFile = LooseFile.Substring(SoundPath.Length + 1);
                // trim the leading soundpath
                strLooseFile = strLooseFile.Replace("\\", "/");

                if (ReferencedFiles.Contains(strLooseFile))
                    continue;

                Result.Add(strLooseFile);
            }

            return Result;
        }

        public void BackUpFile(string FilePath)
        {
            SourceFileSystem.BackUpFile(FilePath);
        }

        public string GetScriptNameByWavPath(string WavPath)
        {
            if (WavPath == null)
                return null;
            if (WavPath.Length == 0)
                return null;
            if (SoundScriptFiles.Count == 0)
                return null;

            //loop through the script files mentioned in the manifest
            foreach (KeyValues ScriptFile in SoundScriptFiles.Values)
            {
                if (ScriptFile == null)
                    continue;

                //loop through each script sound in the script file
                foreach (KeyValues Script in ScriptFile.Keys)
                {
                    KeyValues RndWave = Script.GetKey("rndwave");

                    //look for a set of random waves
                    if (RndWave == null)
                    {
                        //look for a single named wave
                        if (WavPath == Script.GetString("wave", null))
                        {
                            return Script.Name;
                        }
                    }
                    else
                    {
                        //add each of the possible waves
                        foreach (var WaveKey in RndWave.Keys)
                        {
                            if (WaveKey.Name == "wave" && WavPath == WaveKey.Value)
                            {
                                return Script.Name;
                            }
                        } //end for wave
                    }
                } //End for each scipt
            }// end for each script file

            return null;
        }

        public string GetWavPathByScriptName(string ScriptName)
        {
            if (ScriptName == null)
                return null;
            if (ScriptName.Length == 0)
                return null;
            if (SoundScriptFiles.Count == 0)
                return null;

            //loop through the script files mentioned in the manifest
            foreach (KeyValues ScriptFile in SoundScriptFiles.Values)
            {
                if (ScriptFile == null)
                    continue;

                //loop through each script sound in the script file
                foreach (KeyValues Script in ScriptFile.Keys)
                {
                    if (Script.Name != ScriptName)
                        continue;

                    KeyValues RndWave = Script.GetKey("rndwave");

                    //look for a set of random waves
                    if (RndWave == null)
                    {
                        //look for a single named wave
                        return Script.GetString("wave", null);
                    }
                    else
                    {
                        //add each of the possible waves
                        foreach (var WaveKey in RndWave.Keys)
                        {
                            if (WaveKey.Name == "wave")
                            {
                                return WaveKey.Value;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }//end class

}