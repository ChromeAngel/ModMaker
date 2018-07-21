using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace LibModMaker
{

    /// <summary>
    /// Structure for Forge Game Data (FGD) files used to configure Worldcraft/Hammer/Sledge for use with games and mods
    /// </summary>
    /// <remarks>This version is lossy, it will discard all the comments in the original file</remarks>
    public class ForgeGameData
{
	interface iCommand
	{
		string Name { get; }
		string Read(string CommandLine, TextReader Source);
	}
    
    /// <summary>
    /// All entity properties implement this interface
    /// </summary>
	public interface iEntityProperty
	{
		string Name { get; }
		string LabelText { get; set; }
		string DataType { get; set; }
		string Settings { get; set; }
		Control GetControl();
		Form GetEditor();
		string ToString(int Indent = 0);
	}
    
    /// <summary>
    /// An input/output connector between entities
    /// </summary>
	public class IOConnector
	{
		public string Name;
		public string DataType;
		public string Notes;

		public bool IsInput;
		public bool IsOutput {
			get { return !IsInput; }
			set { IsInput = !value; }
		}

		public string ToString(int Indent = 0)
		{
			System.Text.StringBuilder Result = new System.Text.StringBuilder();

			while (Indent > 0) {
				Result.Append('\t');
				Indent -= 1;
			}

			Result.AppendFormat("{0} {1}({2}) : \"{3}\"", IsInput ? "input" : "output", Name, DataType, Notes);
			Result.AppendLine("");

			return Result.ToString();
		}

		public static bool TryParse(string Line, IOConnector Result)
		{
			if (string.IsNullOrEmpty(Line))
				return false;

			Line = Line.Trim();
            Line = Line.Replace("\t", " ");

            while(Line.Contains("  "))
            {
                   Line = Line.Replace("  ", " ");
            }

            Line = Line.Replace("): ", ") : ");

            int TypeEndIndex = Line.IndexOf(") : \"");

			if (TypeEndIndex == -1)
            {
                    return false;
            }
				

			int NameStartIndex = Line.IndexOf(" ");

			if (NameStartIndex == -1)
				return false;

			NameStartIndex += 1;
			//we dont want the space, but the letter after it

			if (NameStartIndex > TypeEndIndex)
				return false;

			string[] NameType = Line.Substring(NameStartIndex, TypeEndIndex - NameStartIndex).Split('(');

			if (NameType.Length < 2)
				return false;

			TypeEndIndex += ") : \"".Length;

			Result.Name = NameType[0];
			Result.DataType = NameType[1];
			Result.IsInput = Line.StartsWith("input");
			Result.Notes = Line.Substring(TypeEndIndex, Line.Length - (TypeEndIndex + 1));

			return true;
		}
	}
    
    /// <summary>
    /// A spawn flag of an entity
    /// </summary>
	public class SpawnFlag
	{
		public int BitFlags { get; set; }
		public string Name { get; set; }
		public bool DefaultSetting { get; set; }

		public string ToString(int Indent = 0)
		{
			System.Text.StringBuilder Result = new System.Text.StringBuilder();

			while (Indent > 0) {
				Result.Append('\t');
				Indent -= 1;
			}

			Result.AppendFormat("{0}: \"{1}\" : {2}", BitFlags, Name, DefaultSetting ? "1": "0");
			Result.AppendLine("");

			return Result.ToString();
		}

		public static bool TryParse(string Line, SpawnFlag Result)
		{
			if (string.IsNullOrEmpty(Line))
				return false;

			Line = Line.Trim();

			string[] Bits = Line.Split(':');

			if (Bits.Length < 2)
				return false;

		    for (int i = 0; i < Bits.Length; i++)
		    {
		        Bits[i] = Bits[i].TrimEnd(' ');
		    }

		    int iTempBItFlags;

			if (!int.TryParse(Bits[0], out iTempBItFlags))
				return false;

		    Result.BitFlags = iTempBItFlags;
            Result.Name = Bits[1].Trim().Trim('"');

			if (Bits.Length > 2) {
				Result.DefaultSetting = (Bits[2] != "0");
			} else {
				Result.DefaultSetting = false;
			}

			return true;
		}
	}

    /// <summary>
    /// A "widget" that helps configure a property (eg direction picker for Angles)
    /// </summary>
	public class Widget
	{
		public string Name;
		public string Seperator;

		public List<string> Parameters = new List<string>();
		public Widget()
		{
		}

		public object ToFGDString()
		{
			return string.Format(" {0}({1})", Name, string.Join(Seperator, Parameters.ToArray()));
		}
	}
    
    /// <summary>
    /// The definition of an entity
    /// </summary>
	public class EntityDef
	{
		public string Name;
		public string Comment;
		public EntityTypes EntityType;
		public List<Widget> Widgets = new List<Widget>();
			// key by property name
		public Dictionary<string, iEntityProperty> Properties = new Dictionary<string, iEntityProperty>();
		public Dictionary<string, IOConnector> Inputs = new Dictionary<string, IOConnector>();
		public Dictionary<string, IOConnector> Outputs = new Dictionary<string, IOConnector>();
		//Public Flags As New Dictionary(Of Integer, SpawnFlag)
		public List<string> Bases {
			get {
				foreach (var W in Widgets) {
					if (W.Name == "base")
						return W.Parameters;
				}

				return new List<string>();
			}
			set {
				foreach (var W in Widgets) {
					if (W.Name == "base") {
						W.Parameters = value;

						return;
					}
				}

				Widget BaseWidget = new Widget {
					Name = "base",
					Seperator = ", ",
					Parameters = value
				};

				Widgets.Add(BaseWidget);
			}
		}

		public enum EntityTypes
		{
			Base,
			Point,
			Solid,
			Filter,
			KeyFrame,
			Move,
			NPC
		}

		public string ToString(int Indent = 0)
		{
			string strIndent = "".PadLeft(Indent, '\t');
			System.Text.StringBuilder Result = new System.Text.StringBuilder(strIndent);

			switch (EntityType) {
				case EntityTypes.Base:
					Result.Append("@BaseClass");
			        break;
				case EntityTypes.Point:
					Result.Append("@PointClass");
                        break;
                    case EntityTypes.Solid:
					Result.AppendFormat("@SolidClass"); break;
                    case EntityTypes.Filter:
					Result.AppendFormat("@FilterClass"); break;
                    case EntityTypes.KeyFrame:
					Result.AppendFormat("@KeyFrameClass"); break;
                    case EntityTypes.Move:
					Result.AppendFormat("@MoveClass"); break;
                    case EntityTypes.NPC:
					Result.AppendFormat("@NPCClass"); break;
                }

			foreach (Widget W in Widgets) {
				Result.Append(W.ToFGDString());
			}
			//If Bases.Count > 0 Then
			//    Result.Append(" base(")
			//    Result.Append(String.Join(", ", Bases.ToArray()))
			//    Result.Append(")")
			//End If

			switch (EntityType) {
				case EntityTypes.Base:
					Result.AppendFormat(" = {0}\r\n", Name);
                        break;
                    default:
					Result.AppendFormat(" = {0}:\r\n", Name);
                        break;
                }

			if (string.IsNullOrEmpty(Comment)) {
				Result.AppendFormat("{0}\"\"\r\n", strIndent);
			} else  {
                Result.AppendFormat("{0}\"{1}\"\r\n", strIndent, Comment);
            }

                Result.AppendFormat("{0}[\r\n", strIndent);

			foreach (iEntityProperty P in Properties.Values) {
				Result.Append(P.ToString(Indent + 1));
			}

			if (Inputs.Count > 0) {
				Result.AppendFormat("{0}\t// Inputs\r\n", strIndent);

				foreach (IOConnector I in Inputs.Values) {
					Result.Append(I.ToString(Indent + 1));
				}
			}

			if (Outputs.Count > 0) {
				Result.AppendFormat("{0}\t// Outputs\r\n", strIndent);

				foreach (IOConnector O in Outputs.Values) {
					Result.Append(O.ToString(Indent + 1));
				}
			}

			Result.AppendFormat("{0}]\r\n", strIndent);


            return Result.ToString();
		}
	}

	private string _FileName = null;
	public string MapSize = null;
	public Dictionary<string, EntityDef> Solids = new Dictionary<string, EntityDef>(); //the brush based entity types
	public Dictionary<string, EntityDef> Points = new Dictionary<string, EntityDef>(); //the point entity types
	public Dictionary<string, EntityDef> Filters = new Dictionary<string, EntityDef>(); // the filter entity types
	public Dictionary<string, EntityDef> Bases = new Dictionary<string, EntityDef>(); // the base entity types that other types inherit from
	public Dictionary<string, ForgeGameData> Includes = new Dictionary<string, ForgeGameData>(); //Other FGDs that have been included

	public string FileName {
		get {
			if (_FileName == null)
				return "Untitled.fgd";

			return _FileName;
		}
	}

	public void Load(string FileName)
	{
		if (string.IsNullOrEmpty(FileName))
			throw new ArgumentException("No Filename Specified");

		if (!File.Exists(FileName))
			throw new ArgumentException();

		_FileName = FileName;

		string Line;
		Dictionary<string, iCommand> Commands = new Dictionary<string, iCommand>();

		using (FGDReader file = new FGDReader(FileName)) {
			Line = file.ReadLine();

			while (Line != null) {
				if (Line.StartsWith("@")) {
					string Command = Line.Substring(1, Line.IndexOf(" ") - 1);

					switch (Command) {
						case "BaseClass":
							Line = BaseClassRead(Line.Substring("@BaseClass".Length), file, this.Bases, EntityDef.EntityTypes.Base);
					        break;
						case "SolidClass":
							Line = BaseClassRead(Line.Substring("@SolidClass".Length), file, this.Solids, EntityDef.EntityTypes.Solid); break;
                            case "PointClass":
							Line = BaseClassRead(Line.Substring("@PointClass".Length), file, this.Points, EntityDef.EntityTypes.Point); break;
                            case "FilterClass":
							Line = BaseClassRead(Line.Substring("@FilterClass".Length), file, this.Points, EntityDef.EntityTypes.Filter); break;
                            case "KeyFrameClass":
							Line = BaseClassRead(Line.Substring("@KeyFrameClass".Length), file, this.Points, EntityDef.EntityTypes.KeyFrame); break;
                            case "MoveClass":
							Line = BaseClassRead(Line.Substring("@MoveClass".Length), file, this.Points, EntityDef.EntityTypes.Move); break;
                            case "NPCClass":
							Line = BaseClassRead(Line.Substring("@NPCClass".Length), file, this.Points, EntityDef.EntityTypes.NPC); break;
                            case "include":
							Line = IncludeRead(Line.Substring("@include".Length), file); break;
                            case "mapsize":
							MapSize = Line.Substring("@mapsize".Length).Trim();
                                Line = file.ReadLine();
                                break;
                            default:
							Debug.WriteLine("Unknown Command @" + Command);

							Line = file.ReadLine();
                                break;
                        }
				} else {
					Line = file.ReadLine();
				}
			}
		}
	}

	public void Save(string FileName = null)
	{
		if (FileName == null)
			FileName = _FileName;

		_FileName = FileName;

		//Take a backup of the existing version
		SourceFileSystem.BackUpFile(FileName);

		using (StreamWriter file = new StreamWriter(FileName)) {
			file.WriteLine("// Generated by LibModMaker at " + DateTime.Now.ToString());

			foreach (string Inc in Includes.Keys) {
				file.WriteLine("@include \"{0}\"", Inc);
			}

			if (!string.IsNullOrEmpty(MapSize)) {
				file.WriteLine("@mapsize {0}", MapSize);
			}

			foreach (EntityDef B in Bases.Values) {
				file.WriteLine(B.ToString());
			}

			foreach (EntityDef P in Points.Values) {
				file.WriteLine(P.ToString());
			}

			foreach (EntityDef P in Filters.Values) {
				file.WriteLine(P.ToString());
			}

			foreach (EntityDef S in Solids.Values) {
				file.WriteLine(S.ToString());
			}
		}
	}

	public string IncludeRead(string CommandLine, FGDReader Source)
	{
		string LocalPath = Directory.GetCurrentDirectory();

		if (FileName != null)
			LocalPath = Path.GetDirectoryName(FileName);

		ForgeGameData Included = new ForgeGameData();

		CommandLine = CommandLine.Trim();
		CommandLine = CommandLine.Trim('"');
		LocalPath = Path.Combine(LocalPath, CommandLine);

		try {
			Included.Load(LocalPath);

			this.Includes[CommandLine] = Included;
		} catch (ArgumentException) {
			//Supress
		}

		return Source.ReadLine();
	}

	public string BaseClassRead(string CommandLine, FGDReader Source, Dictionary<string, EntityDef> EnitySet, EntityDef.EntityTypes EntityType)
	{
		EntityDef Result = new EntityDef();
		string[] Bits = SplitNTrim(CommandLine, '=');

		if (Bits.Length < 2)
			return Source.ReadLine();

		string[] DescriptionBits = SplitNTrim(Bits[1], ':');

		Result.EntityType = EntityType;

		if (DescriptionBits.Length > 1) {
			Result.Name = DescriptionBits[0];
			Result.Comment = DescriptionBits[1].Trim('"');
		} else {
			Result.Name = Bits[1];
		}

		ParseWidgets(Bits[0], Result);

		string Line = Source.ReadLine();

		if (Line == null)
			return null;

		Line = Line.Trim();

		while (!Line.StartsWith("[")) {
			Result.Comment = Result.Comment + Line.Trim('"');
			Line = Source.ReadLine().Trim();
		}

		Line = Source.ReadLine();

		while (Line != null && !Line.EndsWith("]")) {
			if (Line.StartsWith("input") || Line.StartsWith("output")) {
				Line = ReadIO(Line, Source, Result);
			} else {
				Line = PropertyRead(Line, Source, Result);
			}
		}

		if (EnitySet.ContainsKey(Result.Name)) {
			EnitySet.Remove(Result.Name);
		}

		EnitySet.Add(Result.Name, Result);

		return Source.ReadLine();
	}

	void ParseWidgets(string Text, EntityDef Entity)
	{
		string[] strWidgets = Text.Split(')');

		foreach (string Line in strWidgets) {
			if (Line.Length == 0)
				continue;

			string Line2 = Line.Trim().TrimEnd(')');

			string[] Bits = Line2.Split('(');
			Widget aWidget = new Widget {
				Name = Bits[0],
				Seperator = Bits[0] == "base" ? ", " : " "
			};

			aWidget.Parameters.AddRange(SplitNTrim(Bits[1], aWidget.Seperator));
			Entity.Widgets.Add(aWidget);
		}
	}

	string ReadIO(string Line, FGDReader Source, EntityDef Result)
	{
		IOConnector Connector = new IOConnector();

		if (IOConnector.TryParse(Line, Connector)) {
			if (Connector.IsInput) {
				Result.Inputs[Connector.Name] = Connector;
			} else {
				Result.Outputs[Connector.Name] = Connector;
			}
		} else {
			Debug.WriteLine("Failed to parse: " + Line);
		}

		return Source.ReadLine();
	}

	public class BaseProperty : ForgeGameData.iEntityProperty
	{
		private string _settings;
		private string _labelText;
		private string _dataType;

		public string _Name;
		public string DefaultValue;
		public string Notes;

		System.Windows.Forms.Control iEntityProperty.GetControl()
		{
			return new TextBox { Name = _Name };
		}

		System.Windows.Forms.Form iEntityProperty.GetEditor()
		{
			return null;
		}

		public string Name {
			get { return _Name; }
		}

		public string Settings {
			get { return _settings; }
			set { _settings = value; }
		}

		string iEntityProperty.ToString(int Indent)
		{
			System.Text.StringBuilder Result = new System.Text.StringBuilder("".PadLeft(Indent, '\t'));

			Result.AppendFormat("{0}({1}) : {2} ", _Name, _dataType, Quote(_labelText));

			if (!string.IsNullOrEmpty(DefaultValue)) {
				Result.AppendFormat(" : {0}", Quote(DefaultValue));
			}

			Result.AppendLine();

			return Result.ToString();
		}

		public string DataType {
			get { return _dataType; }
			set { _dataType = value; }
		}

		public string LabelText {
			get { return _labelText; }
			set { _labelText = value; }
		}


            protected string LineWrap(string Plain, int LineLength = 150)
		{
			string Result = Quote(Plain);
			System.Text.StringBuilder Buffer = new System.Text.StringBuilder();

			while (Result.Length > LineLength) {
				int Pos = LineLength;

				while (char.IsLetterOrDigit(Result.ToCharArray()[Pos]) & Pos > 1) {
					Pos = Pos - 1;
				}

				if (Pos == 1)
					Pos = LineLength;

				Buffer.Append(Result.Substring(0, Pos)).Append("\" +\r\n\t\t\"");
				Result = Result.Substring(Pos + 1);
			}

			Buffer.Append(Result);

			return Buffer.ToString();
		}

		protected string Quote(string Plain)
		{
			if (string.IsNullOrEmpty(Plain))
				return Plain;

			Plain = Plain.Trim();

			if (Steam.IsNumeric(Plain)) {
				if (Plain.Contains(".")) {
					return '"' + Plain + '"';
				} else {
					return Plain;
				}
			}

			if (Plain.StartsWith("\"")) {
				if (Plain.EndsWith("\"")) {
					return Plain;
				} else {
					return Plain + '"';
				}
			} else {
				if (Plain.EndsWith("\"")) {
					return '"' + Plain;
				} else {
					return '"' + Plain + '"';
				}
			}
		}

		public static string Sanitize(string Plain)
		{
			string Sanitized = Plain.Trim();

			Sanitized = Sanitized.ToLowerInvariant();
			Sanitized = Sanitized.Replace(" ", "_");

			return Sanitized;
		}
	}

	public class ChoicesProperty : BaseProperty, ForgeGameData.iEntityProperty
        {
		public Dictionary<string, string> choices = new Dictionary<string, string>();
		string iEntityProperty.ToString(int Indent = 0)
		{
			System.Text.StringBuilder Result = new System.Text.StringBuilder("".PadLeft(Indent, '\t'));

			Result.AppendFormat("{0}({1}) : {2}", _Name, DataType, Quote(LabelText));

			if (!string.IsNullOrEmpty(DefaultValue)) {
				Result.AppendFormat(" : {0} ", Quote(DefaultValue));
			}

			if (!string.IsNullOrEmpty(Notes)) {
				if (string.IsNullOrEmpty(DefaultValue))
					Result.Append(" :");

				Result.AppendFormat(" : {0} ", Quote(Notes));
			}

			Result.AppendFormat("=\r\n{0}[\r\n", "".PadLeft(Indent, '\t'));

			foreach (string Value in choices.Keys) {
				Result.AppendFormat("{2}{0} : {1}\r\n", Quote(Value), Quote(choices[Value]), "".PadLeft(Indent + 1, '\t'));
			}

			Result.AppendFormat("{0}]\r\n", "".PadLeft(Indent, '\t'));
			Result.AppendLine();

			return Result.ToString();
		}
	}

	public class FlagsProperty : BaseProperty , ForgeGameData.iEntityProperty
	{
		public Dictionary<int, SpawnFlag> flags = new Dictionary<int, SpawnFlag>();

        public FlagsProperty()
        {
                DataType = "flags";
        }
        string iEntityProperty.ToString(int Indent = 0)
		{
			System.Text.StringBuilder Result = new System.Text.StringBuilder();

			Result.AppendFormat("{0}spawnflags(flags) =\r\n{0}[\r\n", "".PadLeft(Indent, '\t'));

			foreach (int K in flags.Keys) {
				Result.AppendFormat("{3}{0} : {1} : {2}\r\n", K, Quote(flags[K].Name), flags[K].DefaultSetting? 1: 0, "".PadLeft(Indent + 1, '\t'));
			}

			Result.AppendFormat("{0}]\r\n", "".PadLeft(Indent, '\t'));
			Result.AppendLine();

			return Result.ToString();
		}
	}

	private string[] SplitNTrim(string Source, char Seperator)
	{
		string[] Result = Source.Split(Seperator);

		for (int I = 0; I <= Result.Length - 1; I++) {
			Result[I] = Result[I].Trim();
		}

		return Result;
	}

    private string[] SplitNTrim(string source, string seperator)
    {
        if (string.IsNullOrEmpty(source))
        {
            return new string[0];
        }

        if (string.IsNullOrEmpty(seperator))
        {
            var noSeperator = new string[1];

            noSeperator[0] = source;

            return noSeperator;
        }

        int firstSeperatorIndex = source.IndexOf(seperator);

        if (firstSeperatorIndex == -1)
        {
            string[] shortcut = new string[1];

            shortcut[0] = source.Trim();

            return shortcut;
        }
        else
        {
            var result = new List<string>();
            //get the first part
            result.Add(source.Substring(0, firstSeperatorIndex).Trim());
            //Recursive
            result.AddRange(
                SplitNTrim(
                    source.Substring(firstSeperatorIndex+seperator.Length)
                    ,seperator
                )
            );

            return result.ToArray();
        }
    }

    public string PropertyRead(string CommandLine, FGDReader Source, EntityDef Entity)
	{
		string[] Bits = SplitNTrim(CommandLine, ':');
		string[] NameType = Bits[0].Trim().Split("()".ToCharArray());

		if (NameType.Length < 2) {
			if (CommandLine.Trim().EndsWith("=")) {
				return ChoicesRead(CommandLine, Source, Entity);
			}

			return CommandLine + Source.ReadLine();
		}


		if (NameType[1].ToLowerInvariant() == "choices" || NameType[1].ToLowerInvariant() == "flags") {
			return ChoicesRead(CommandLine, Source, Entity);
		}

		//	nodeid(integer) readonly : "Node ID"


		BaseProperty Result = new BaseProperty {
			_Name = NameType[0],
			DataType = NameType[1].ToLowerInvariant()
		};

		if (NameType.Length > 2) {
			Result.Settings = Result.Settings + NameType[2];
		}

		if (Bits.Length > 1) {
			Result.LabelText = Bits[1].Trim('"');
		}

		if (Bits.Length > 2) {
			Result.DefaultValue = Bits[2].Trim('"');
		} else {
			Result.DefaultValue = "";
		}

		if (Bits.Length > 3) {
			Result.Notes = Bits[3].Trim('"');
		}

		Entity.Properties[Result.Name] = Result;

		return Source.ReadLine();
	}

	public string ChoicesRead(string CommandLine, CCommentReader Source, EntityDef Entity)
	{
		CommandLine = CommandLine.Substring(0, CommandLine.Length - 1);
		//trim the trailing "="
		CommandLine = CommandLine.Trim();

		string[] Bits = SplitNTrim(CommandLine, ':');
		string[] NameType = Bits[0].Trim().TrimEnd(')').Split('(');

		if (NameType.Length < 2)
			return CommandLine + Source.ReadLine();

		BaseProperty Result;

		if (CommandLine.StartsWith("spawnflags(", StringComparison.InvariantCultureIgnoreCase)) {
			Result = new FlagsProperty {
				DataType = "flags",
				_Name = "spawnflags"
			};

			string Line = Source.ReadLine().Trim();
			FlagsProperty SpawnFlags = Result as FlagsProperty;
			SpawnFlag aSpawnFlag;

			if (Line == "[") {
				Line = Source.ReadLine();

				while (Line != null && !Line.EndsWith("]")) {
					aSpawnFlag = new SpawnFlag();

					if (SpawnFlag.TryParse(Line, aSpawnFlag)) {
						SpawnFlags.flags.Add(aSpawnFlag.BitFlags, aSpawnFlag);
					}

					Line = Source.ReadLine();
				}
			}
		} else {
			ChoicesProperty X = new ChoicesProperty {
				_Name = NameType[0],
				DataType = NameType[1].ToLowerInvariant()
			};

			if (Bits.Length > 2) {
				X.DefaultValue = Bits[2].Trim('"');
			}

			string Line = Source.ReadLine().Trim();

			if (Line == "[") {
				Line = Source.ReadLine();

				while (Line != null && !Line.EndsWith("]")) {
					if (Line.EndsWith("]"))
						break; // TODO: might not be correct. Was : Exit While

					string[] Choice = SplitNTrim(Line, ':');

					X.choices.Add(Choice[0], Choice[1].Trim('"'));
					Line = Source.ReadLine();
				}
			}

			if (Bits.Length > 2) {
				X.DefaultValue = Bits[2].Trim('"');
			} else {
				X.DefaultValue = "";
			}
			if (Bits.Length > 1) {
				X.LabelText = Bits[1].Trim('"');
			}

			Result = X;
		}

		Entity.Properties[Result.Name] = Result;

		return Source.ReadLine();
	}

	///recursively search includes for the base class 
	public EntityDef GetBaseByName(string Name)
	{
		if (string.IsNullOrEmpty(Name))
			return null;
		if (Bases.ContainsKey(Name))
			return Bases[Name];

		foreach (ForgeGameData Include in Includes.Values) {
			EntityDef Result = Include.GetBaseByName(Name);

			if (Result != null)
				return Result;
		}

		return null;
	}
} //end class

}
