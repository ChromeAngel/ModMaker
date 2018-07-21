using System.Collections.Generic;
using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Datamodel;
using System.Numerics;

namespace ModMaker
{
    /// <summary>
    /// Experimental tool for manipulating particle systems
    /// </summary>
    /// <remarks>Makes extensive use of Datamodel.NET to read the DMX fomat binary files used for particle systems</remarks>
    public class ParticleTool : iTool
    {

        public struct Vector3
        {
            public float X;
            public float Y;
            public float Z;

            public override string ToString()
            {
                return string.Format("({0},{1},{2})", X, Y, Z);
            }
        }

        public Image Image
        {
//Throw New NotImplementedException()
            get { return Properties.Resources.ModMaker.ToBitmap(); }
        }

        public string Name
        {
            get { return "Particle Tool"; }
        }

        public string TipText
        {
            get { return "Scale, Speed up or Slow down Particle Systems"; }
        }

        public frmParticleTool Form;
        public SourceMod Game;
        public KeyValues Manifest;

        public void Launch(SourceMod Game)
        {
            this.Game = Game;
            Form = new frmParticleTool();
            Form.Tool = this;
            Form.Show();
        }

        public bool IsValidForMod(SourceMod Game)
        {
            return true;
        }

        /// <summary>
        /// Particle System file we're reading from
        /// </summary>
        public Datamodel.Datamodel Source;
        /// <summary>
        /// Array of particle systems from the source
        /// </summary>
        public Datamodel.ElementArray SourceParticleSystems;

        /// <summary>
        /// Particle System file we're writing to
        /// </summary>
        public Datamodel.Datamodel Target;
        /// <summary>
        /// Array of particle systems in the Target
        /// </summary>
        public Datamodel.ElementArray TargetParticleSystems;

        /// <summary>
        /// Particle properties related to their size
        /// </summary>
        public string[] SizeKeys =
        {
            "radius_start_scale",
            "radius_end_scale",
            "radius_min",
            "radius_max",
            "distance_min",
            "distance_max",
            "Visibility Proxy Radius",
            "Visibility Radius Scale maximum",
            "Visibility Radius Scale minimum",
            "Visibility Proxy Radius",
            "bounding_box_min",
            "bounding_box_max",
            "cull_radius",
            "radius",
            "distance_min",
            "distance_max",
            "maximum draw distance"
        };

        /// <summary>
        /// Known particle properties related to time
        /// </summary>
        public string[] TimeKeys =
        {
            "operator start fadein",
            "operator end fadein",
            "operator start fadeout",
            "operator end fadeout",
            "animation rate",
            "second sequence animation rate",
            "velocity scale",
            "end_fade_out_time",
            "start_fade_out_time",
            "end_fade_in_time",
            "start_fade_in_time",
            "speed_in_local_coordinate_system_max",
            "speed_in_local_coordinate_system_min",
            "speed_min",
            "speed_max",
            "lifetime_min",
            "lifetime_max",
            "time to sleep when not drawn",
            "rotation_speed",
            "emission_rate",
            "emission_duration",
            "emission_start_time",
            "fade_start_time",
            "fade_end_time",
            "gravity",
            "drag",
            "max force",
            "min force"
        };

        /// <summary>
        /// Known particle properties related to colour of the particle
        /// </summary>
        public string[] ColorKeys =
        {
            "color",
            "color1",
            "color2",
            "color_fade"
        };

        /// <summary>
        /// Resize a particle sysyem to a percentage of it's current size
        /// </summary>
        /// <param name="system"></param>
        /// <param name="percentage"></param>
        public void Resize(Datamodel.Element system, decimal percentage)
        {
            foreach (KeyValuePair<string, object> pair in system)
            {
                switch (pair.Value.GetType().Name)
                {
                    case "ElementArray":
                        Datamodel.ElementArray el = pair.Value as ElementArray;
                        foreach (Datamodel.Element Sube in el)
                        {
                            Resize(Sube, percentage);
                        }
                        break;
                    case "String":
                    //NA
                    case "Single":
                        if (!SizeKeys.Contains(pair.Key))
                            continue;

                        system[pair.Key] = ScaleSingle((float)pair.Value, percentage);
                        break;
                    case "Int32":
                        if (!SizeKeys.Contains(pair.Key))
                            continue;

                        int Y = (int)pair.Value;
                        float OnePercent = (float)Y/100.0f;
                        Y = Y + (int) (OnePercent*(float)percentage);
                        system[pair.Key] = Y;
                        break;
                    case "Boolean":
                    //NA
                    case "Vector3":
                        if (!SizeKeys.Contains(pair.Key))
                            continue;
                        Vector3 vthree = (Vector3)pair.Value;
                        vthree.X = ScaleSingle(vthree.X, percentage);
                        vthree.Y = ScaleSingle(vthree.Y, percentage);
                        vthree.Z = ScaleSingle(vthree.Z, percentage);
                        system[pair.Key] = vthree;
                        break;
                    case "Color":
                    //NA
                    case "Element":
                        Resize(pair.Value as Element, percentage);
                        break;
                }
            }
        }

        /// <summary>
        /// Scale a float to a percentage of it's current value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="percentage"></param>
        /// <returns>a float scaled to a percentage of it's current value</returns>
        float ScaleSingle(float source, decimal percentage)
        {
            float OnePercent = source/100;

            return source + (OnePercent * (float)percentage);
        }

        /// <summary>
        /// Speed up or slow down a particle system by given percentage
        /// </summary>
        /// <param name="system"></param>
        /// <param name="percentage"></param>
        public void ReTime(Datamodel.Element system, decimal percentage)
        {
            foreach (KeyValuePair<string, object> pair in system)
            {
                switch (pair.Value.GetType().Name)
                {
                    case "ElementArray":
                        Datamodel.ElementArray el = pair.Value as ElementArray;
                        foreach (Datamodel.Element Sube in el)
                        {
                            Resize(Sube, percentage);
                        }
                        break;
                    case "String":
                    //NA
                    case "Single":
                        if (!TimeKeys.Contains(pair.Key))
                            continue;

                        system[pair.Key] = ScaleSingle((float)pair.Value, percentage);
                        break;
                    case "Int32":
                        if (!TimeKeys.Contains(pair.Key))
                            continue;

                        int Y = (int)pair.Value;

                        float OnePercent = Y/100.0f;
                        Y = Y + (int) ((decimal)OnePercent* percentage);
                        system[pair.Key] = Y;
                        break;
                    case "Boolean":
                    //NA
                    case "Vector3":
                        if (!TimeKeys.Contains(pair.Key))
                            continue;

                        Vector3 vthree = (Vector3)pair.Value;
                        vthree.X = ScaleSingle(vthree.X, percentage);
                        vthree.Y = ScaleSingle(vthree.Y, percentage);
                        vthree.Z = ScaleSingle(vthree.Z, percentage);
                        system[pair.Key] = vthree;
                        break;
                    case "Color":
                    //NA
                    case "Element":
                        Resize(pair.Value as Element, percentage);
                        break;
                }
            }
        }

        /// <summary>
        /// Tint a particle system toward a percentage of a given color
        /// </summary>
        /// <param name="system"></param>
        /// <param name="percentage"></param>
        /// <param name="colour"></param>
        public void ReColour(Datamodel.Element system, decimal percentage, Color colour)
        {
            foreach (KeyValuePair<string, object> pair in system)
            {
                switch (pair.Value.GetType().Name)
                {
                    case "ElementArray":
                        Datamodel.ElementArray el = pair.Value as ElementArray;
                        foreach (Datamodel.Element Sube in el)
                        {
                            ReColour(Sube, percentage, colour);
                        }
                        break;
                    case "String":
                    //NA
                    case "Single":
                    //NA
                    case "Int32":
                    //NA
                    case "Boolean":
                    //NA
                    case "Vector3":
                        if (!ColorKeys.Contains(pair.Key))
                            continue;

                        Vector3 vthree = (Vector3)pair.Value;
                        vthree.X = BlendChannel(vthree.X, (float) colour.R/255, percentage);
                        vthree.Y = BlendChannel(vthree.Y, (float) colour.G/255, percentage);
                        vthree.Z = BlendChannel(vthree.Z, (float) colour.B/255, percentage);
                        system[pair.Key] = vthree;
                        break;
                    case "Color":
                        if (!ColorKeys.Contains(pair.Key))
                            continue;

                        Color colourValue = (Color)pair.Value;
                        Color result = Color.FromArgb(colourValue.A, BlendChannel(colourValue.R, colour.R, percentage),
                            BlendChannel(colourValue.G, colour.G, percentage), BlendChannel(colourValue.B, colour.B, percentage));

                        system[pair.Key] = result;
                        break;
                    case "Element":
                        Resize(pair.Value as Element, percentage);
                        break;
                }
            }
        }

        /// <summary>
        /// Blend an original and tint 8bit colour channel together by a percenage
        /// </summary>
        /// <param name="Original">0 to 255</param>
        /// <param name="Tint">0 to 255</param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        private Int32 BlendChannel(byte Original, byte Tint, decimal percentage)
        {
            if (percentage == 100) return Tint;
            if (percentage == 0) return Original;

            float fTint = (float) Tint;
            float sOriginal = (float) Original/255;
            float sTint = fTint / 255.0f;

            return (Int32)Math.Round(BlendChannel(sOriginal, sTint, percentage) * 255.0f);
        }

        /// <summary>
        /// Blend an original and tint normalised colour channel together by a percenage
        /// </summary>
        /// <param name="Original">0.0 to 1.0</param>
        /// <param name="Tint">0.0 to 1.0</param>
        /// <param name="percentage"></param>
        /// <returns>a float from 0.0 to 1.0</returns>
        private float BlendChannel(float Original, float Tint, decimal percentage)
        {
            if (percentage == 100) return Tint;
            if (percentage == 0) return Original;

            float fPercentage = (float) percentage;
            float sOriRatio = (100.0f - fPercentage) /100.0f;
            float sTintRatio = fPercentage / 100.0f;

            return (Original*sOriRatio) + (Tint*sTintRatio);
        }

        //event for notifying the UI of loaded particle systems
        public event OnParticleSystemLoadedEventHandler OnParticleSystemLoaded;

        public delegate void OnParticleSystemLoadedEventHandler(object sender, String Name);

        /// <summary>
        /// Load a source file system
        /// </summary>
        /// <param name="FilePath"></param>
        void Load(string FilePath)
        {
            Source = Datamodel.Datamodel.Load(FilePath);
            SourceParticleSystems = Source.Root["particleSystemDefinitions"] as ElementArray;

            foreach (Datamodel.Element ParticleSystem in SourceParticleSystems)
            {
                if (OnParticleSystemLoaded != null)
                {
                    OnParticleSystemLoaded(this, ParticleSystem.Name);
                }
            }
        }

        public event OnProcessEventHandler OnProcess;

        public delegate void OnProcessEventHandler(object sender, int index);

        /// <summary>
        /// Transform the sub systems of a given particle system in space, time and colour
        /// </summary>
        /// <param name="System"></param>
        /// <param name="SpeedPercentage"></param>
        /// <param name="SizePercentage"></param>
        /// <param name="ColourPercentage"></param>
        /// <param name="Colour"></param>
        /// <param name="TransformChildren"></param>
        /// <param name="ResultName"></param>
        public void TransformChildSystems(Datamodel.Element System, decimal SpeedPercentage, decimal SizePercentage,
            decimal ColourPercentage, Color Colour, bool TransformChildren, string ResultName)
        {
            Datamodel.ElementArray elChildren = System["children"] as ElementArray;

            string[] Files = GetParticleFiles();

            foreach (string ChildFilePath in Files)
            {
                string[] Systems = GetParticleSystemNames(ChildFilePath);

                foreach (Datamodel.Element Child in elChildren)
                {
                    string TransfomedChildName = null;

                    if (!string.IsNullOrEmpty(ResultName))
                    {
                        TransfomedChildName = ResultName + "_" + Child.Name;
                    }

                    if (Systems.Contains(Child.Name))
                    {
                        Transform(ChildFilePath, Child.Name, SpeedPercentage, SizePercentage, ColourPercentage, Colour,
                            TransformChildren, TransfomedChildName);

                        if (!string.IsNullOrEmpty(ResultName))
                        {
                            Child.Name = TransfomedChildName;
                        }

                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
        }

        /// <summary>
        /// Transform all the particle systems in a file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="SystemName"></param>
        /// <param name="SpeedPercentage"></param>
        /// <param name="SizePercentage"></param>
        /// <param name="ColourPercentage"></param>
        /// <param name="Colour"></param>
        /// <param name="TransformChildren"></param>
        /// <param name="ResultName"></param>
        public void Transform(string FilePath, string SystemName, decimal SpeedPercentage, decimal SizePercentage,
            decimal ColourPercentage, Color Colour, bool TransformChildren, string ResultName)
        {
            Datamodel.Element System = GetParticleSystem(FilePath, SystemName);

            if (System == null)
                return;

            string SourceEncoding = DMXEncoding;
            int SourceEncodingVersion = DMXEncodingVersion;

            SourceFileSystem.BackUpFile(FilePath);

            using (var Source = Datamodel.Datamodel.Load(FilePath, Datamodel.Codecs.DeferredMode.Disabled))
            {
                SourceEncoding = Source.Encoding;
                SourceEncodingVersion = Source.EncodingVersion;
                SourceParticleSystems = Source.Root["particleSystemDefinitions"] as ElementArray;

                Datamodel.Element ImportedSystem;

                if (object.ReferenceEquals(System.Owner, Source) & ResultName == null)
                {
                    ImportedSystem = System;
                }
                else
                {
                    ImportedSystem = Copy(System, Source, ResultName);
                    //Source.ImportElement(System, Datamodel.Datamodel.ImportRecursionMode.Recursive, Datamodel.Datamodel.ImportOverwriteMode.None)
                    //ImportedSystem = ImportedSystem
                }

                //If Not String.IsNullOrEmpty(ResultName) Then
                //    ImportedSystem.Name = ResultName 'BUG this renames the System too
                //End If

                SourceParticleSystems.Add(ImportedSystem);

                if (SpeedPercentage != 0)
                {
                    ReTime(ImportedSystem, SpeedPercentage);
                }

                if (SizePercentage != 0)
                {
                    Resize(ImportedSystem, SizePercentage);
                }

                if (ColourPercentage > 0)
                {
                    ReColour(ImportedSystem, ColourPercentage, Colour);
                }

                if (TransformChildren)
                {
                    TransformChildSystems(ImportedSystem, SpeedPercentage, SizePercentage, ColourPercentage, Colour,
                        TransformChildren, ResultName);
                }

                Source.Save(FilePath, SourceEncoding, SourceEncodingVersion);
            }
        }


        private string _ParticlesPath = null;
        /// <summary>
        /// Path to the game's particles folder
        /// </summary>
        public string ParticlesPath
        {
            get
            {
                if (_ParticlesPath == null)
                {
                    _ParticlesPath = SourceFileSystem.FormatFolderPath(Path.Combine(Game.InstallPath, "particles"));

                    if (!Directory.Exists(_ParticlesPath))
                    {
                        Directory.CreateDirectory(_ParticlesPath);
                        //Make a new manifest too?
                    }
                }

                return _ParticlesPath;
            }
        }

        /// <summary>
        /// List all the particle system (PCF) files for this game
        /// </summary>
        /// <returns></returns>
        public string[] GetParticleFiles()
        {
            string[] AllFiles = Directory.GetFiles(ParticlesPath, "*.pcf");
            List<string> Result = new List<string>();

            foreach (string FilePath in AllFiles)
            {
                if (SourceFileSystem.IsBackupFile(FilePath))
                    continue;

                Result.Add(FilePath);
            }

            return Result.ToArray();
        }

        /// <summary>
        /// Load this game's particle system  manifest
        /// </summary>
        /// <returns></returns>
        public KeyValues GetParticleManifest()
        {
            if (Manifest == null)
            {
                string ParticleManifestPath = Path.Combine(ParticlesPath, "particles_manifest.txt");

                if (!File.Exists(ParticleManifestPath))
                    return null;

                Manifest = KeyValues.LoadFile(ParticleManifestPath);
            }

            return Manifest;
        }

        /// <summary>
        /// Get the names of all the particle systems known by the Game
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public string[] GetParticleSystemNames(string FilePath)
        {
            using (var Source = Datamodel.Datamodel.Load(FilePath))
            {
                SourceParticleSystems = Source.Root["particleSystemDefinitions"] as ElementArray;

                List<string> Result = new List<string>();

                foreach (Datamodel.Element ParticleSystem in SourceParticleSystems)
                {
                    if (ParticleSystem == null)
                        continue;

                    Result.Add(ParticleSystem.Name);
                }

                return Result.ToArray();
            }

            //Source = null;
            //SourceParticleSystems = null;
        }


        private const string DMXFormat = "pcf";
        private const int DMXFormatVersion = 1;
        private const string DMXEncoding = "binary";
        private const int DMXEncodingVersion = 2;

        /// <summary>
        /// Create a new PCF file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns>true on sucess</returns>
        public bool CreateParticleSystemFile(string FilePath)
        {
            try
            {
                Target = new Datamodel.Datamodel(DMXFormat, DMXFormatVersion);
                TargetParticleSystems = new Datamodel.ElementArray();
                Target.Root = new Datamodel.Element(Target, "untitled");
                Target.Root.Add("particleSystemDefinitions", TargetParticleSystems);

                Target.Save(FilePath, DMXEncoding, DMXEncodingVersion);
                Target.Dispose();
                Target = null;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Copy a particle system from one file to another
        /// </summary>
        /// <param name="SourceFilePath">File to copy from</param>
        /// <param name="SourceName">Name of the system to copy</param>
        /// <param name="TargetFilePath">File to copy to</param>
        /// <returns>true on sucess</returns>
        public bool Copy(string SourceFilePath, string SourceName, string TargetFilePath)
        {
            if (string.IsNullOrEmpty(SourceFilePath))
                return false;
            if (string.IsNullOrEmpty(SourceName))
                return false;
            if (string.IsNullOrEmpty(TargetFilePath))
                return false;
            if (!SourceFilePath.EndsWith(".pcf"))
                return false;
            if (!TargetFilePath.EndsWith(".pcf"))
                return false;
            if (!File.Exists(SourceFilePath))
                return false;
            if (!File.Exists(TargetFilePath))
                return false;

            try
            {
                using (var SourceFile = Datamodel.Datamodel.Load(SourceFilePath))
                {
                    SourceParticleSystems = SourceFile.Root["particleSystemDefinitions"] as ElementArray;

                    using (var TargetFile = Datamodel.Datamodel.Load(TargetFilePath, Datamodel.Codecs.DeferredMode.Disabled) )
                    {
                        TargetParticleSystems = TargetFile.Root["particleSystemDefinitions"] as ElementArray;

                        if (TargetParticleSystems != null)
                        {
                            Datamodel.Element system = FindFirstElementByName(SourceParticleSystems, SourceName);

                            if (system == null)
                                return false;

                            system = TargetFile.ImportElement(system, Datamodel.Datamodel.ImportRecursionMode.Recursive, Datamodel.Datamodel.ImportOverwriteMode.All);

                            TargetParticleSystems.Add(system);
                        }

                        TargetFile.Save(TargetFilePath, DMXEncoding, DMXEncodingVersion);
                    }

                    Target = null;

                }

                Source = null;

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetType().Name);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Copy a particle system from one file to another
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <param name="Name"></param>
        /// <returns>A copy of Source or null on fauilure</returns>
        public Datamodel.Element Copy(Datamodel.Element Source, Datamodel.Datamodel Destination, string Name = null)
        {
            if (Source == null)
                return null;

            if (Destination == null)
                return null;

            Datamodel.Element Result = new Element(Destination, Name ?? Source.Name);

            foreach (KeyValuePair<string, object> pair in Source)
            {
                switch (pair.Value.GetType().Name)
                {
                    case "ElementArray":
                        Datamodel.ElementArray ela = pair.Value as ElementArray;
                        Datamodel.ElementArray ResultArray = new Datamodel.ElementArray(ela.Count);

                        foreach (Datamodel.Element Sube in ela)
                        {
                            ResultArray.Add(Copy(Sube, Destination, (Name == null) ? null : Name + "_" + Sube.Name));
                        }


                        Result.Add(pair.Key, ResultArray);
                        break;
                    case "String":
                        Result.Add(pair.Key, pair.Value);
                        break;
                    case "Single":
                        Result.Add(pair.Key, pair.Value);
                        break;
                    case "Int32":
                        Result.Add(pair.Key, pair.Value);
                        break;
                    case "Boolean":
                        Result.Add(pair.Key, pair.Value);
                        break;
                    case "Vector3":
                        Result.Add(pair.Key, pair.Value);
                        break;
                    case "Color":
                        Result.Add(pair.Key, pair.Value);
                        break;
                    case "Element":
                        Datamodel.Element el = pair.Value as Element;
                        Result.Add(pair.Key, Copy(el, Destination, (Name == null)? null: Name + "_" + el.Name));
                        break;
                    default:
                        Debug.WriteLine(string.Format("Unexpected data type {0} found in element {1}",
                            pair.Value.GetType().Name, Source.Name));
                        break;
                }
            }

            return Result;
        }

        /// <summary>
        /// Delete a particle system from a given file
        /// </summary>
        /// <param name="SourceFilePath"></param>
        /// <param name="SystemName"></param>
        /// <returns>true on sucess</returns>
        public bool Delete(string SourceFilePath, string SystemName)
        {
            if (string.IsNullOrEmpty(SourceFilePath))
                return false;
            if (string.IsNullOrEmpty(SystemName))
                return false;
            if (!SourceFilePath.EndsWith(".pcf"))
                return false;
            if (!File.Exists(SourceFilePath))
                return false;

            string TempFileName = Path.GetTempFileName();

            try
            {
                SourceFileSystem.BackUpFile(SourceFilePath);

                using (var Source = Datamodel.Datamodel.Load(SourceFilePath, Datamodel.Codecs.DeferredMode.Disabled))
                {
                    SourceParticleSystems = Source.Root["particleSystemDefinitions"] as ElementArray;

                    Datamodel.Element result = FindFirstElementByName(SourceParticleSystems, SystemName);

                    if (result == null)
                        return true;

                    SourceParticleSystems.Remove(result);
                    Source.Save(TempFileName, DMXEncoding, DMXEncodingVersion);
                }
                Source = null;

                bool Sucess = false;
                int Attempts = 5;
                while ((Attempts > 0 & Sucess == false))
                {
                    Attempts = Attempts - 1;

                    try
                    {
                        File.Delete(SourceFilePath);
                        Sucess = true;
                    }
                    catch (Exception)
                    {
                        Sucess = false;
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }
                }

                if (!Sucess)
                    return false;

                File.Copy(TempFileName, SourceFilePath);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetType().Name);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
            finally
            {
                if (File.Exists(TempFileName))
                {
                    File.Delete(TempFileName);
                }
            }
        }

        /// <summary>
        /// Find the first element with a given name within an array of elements
        /// </summary>
        /// <param name="Elements"></param>
        /// <param name="Name"></param>
        /// <returns>an element matching Name or null</returns>
        private Datamodel.Element FindFirstElementByName(Datamodel.ElementArray Elements, string Name)
        {
            if (Elements.Count == 0)
                return null;

            foreach (Datamodel.Element result in Elements)
            {
                if (result.Name == Name)
                    return result;
            }

            return null;
        }

        /// <summary>
        /// Gate the names of child particle systems used by a named system
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="SystemName"></param>
        /// <returns>an array of particle system names OR null if SystemName cannot be found</returns>
        public string[] GetChildNames(string FilePath, string SystemName)
        {
            Datamodel.Element Parent = GetParticleSystem(FilePath, SystemName);

            if (Parent == null)
                return null;

            Datamodel.ElementArray elChildren = Parent["children"] as ElementArray;
            List<string> Result = new List<string>();

            foreach (Datamodel.Element Child in elChildren)
            {
                Result.Add(Child.Name);
            }

            return Result.ToArray();
        }

        /// <summary>
        /// Get a named particle system from a file
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="SystemName"></param>
        /// <returns>A particle system element OR null on failure</returns>
        public Datamodel.Element GetParticleSystem(string FilePath, string SystemName)
        {
            Datamodel.Element Result = null;

            try
            {
                using (var Source = Datamodel.Datamodel.Load(FilePath, Datamodel.Codecs.DeferredMode.Disabled))
                {
                    SourceParticleSystems = Source.Root["particleSystemDefinitions"] as ElementArray;

                    foreach (Datamodel.Element System in SourceParticleSystems)
                    {
                        if (System.Name == SystemName)
                        {
                            Result = System;
                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }

                }
                Source = null;
                SourceParticleSystems = null;

                return Result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetType().Name);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Get a named particle system from the Game
        /// </summary>
        /// <param name="SystemName"></param>
        /// <returns>A particle system element OR null on failure</returns>
        public Datamodel.Element GetParticleSystem(string SystemName)
        {
            if (string.IsNullOrEmpty(SystemName))
                return null;

            string[] Files = GetParticleFiles();

            foreach (string File in Files)
            {
                string[] Systems = GetParticleSystemNames(File);

                if (Systems.Contains(SystemName))
                {
                    return GetParticleSystem(File, SystemName);
                }
            }

            return null;
        }

        /// <summary>
        /// Set the particle system files that should be loaded by the game
        /// </summary>
        /// <param name="Files">an array of PCF file name s relative to the game's install folder</param>
        public void SetManifest(List<string> Files)
        {
            string ParticleManifestPath = Path.Combine(ParticlesPath, "particles_manifest.txt");

            SourceFileSystem.BackUpFile(ParticleManifestPath);

            Manifest = new KeyValues("particles_manifest");

            foreach (string File in Files)
            {
                string RelativePath = File;

                if (RelativePath.StartsWith(Game.InstallPath))
                    RelativePath = RelativePath.Substring(Game.InstallPath.Length);
                //trim off the game folder prefix

                RelativePath = RelativePath.Replace("/", "\\");

                KeyValues Entry = new KeyValues("File", RelativePath, Manifest);
            }

            Manifest.Save(ParticleManifestPath);
        }
    }
}