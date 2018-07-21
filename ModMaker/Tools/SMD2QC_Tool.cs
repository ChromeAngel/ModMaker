using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using LibModMaker;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ModMaker
{

    /// <summary>
    /// Launch a tool to create static props from a reference SMD or compatible OBJ file
    /// </summary>
public class SMD2QC_Tool : iFileTool
{

	public System.Drawing.Image Image {
		get { return Properties.Resources.ModMaker.ToBitmap(); }
	}

	public bool IsValidForMod(LibModMaker.SourceMod Game)
	{
		return true;
	}

	public string Name {
		get { return "SMD to Prop"; }
	}

	public string TipText {
		get { return "Make a static prop model from a given OBJ or SMD"; }
	}

	public void Launch(LibModMaker.SourceMod Game)
	{
		LaunchFile(Game, "");
	}

	public void LaunchFile(SourceMod Game, string FilePath)
	{
		SMDtoQCForm Dialog = new SMDtoQCForm();

		Dialog.Game = Game;
		Dialog.SurfaceProperties = Game.GetSurfacePropertyNames();
		Dialog.FilePath = FilePath;

		if (Dialog.ShowDialog() == DialogResult.Cancel)
			return;

		if (Dialog.FilePath.EndsWith(".obj")) {
			ObjToSMD X = new ObjToSMD(Dialog.FilePath);
		}

		string Result = SMD2QC(Dialog.FilePath, Game, Dialog.SurfaceProperty);

		if (Result == null) {
			Interaction.MsgBox("Conversion Failed", MsgBoxStyle.Exclamation, "Conversion Failed");
		} else {
			if (Interaction.MsgBox("Generated QC script:\r\n"  + Result +  "\r\n\r\nCompile to MDL now?", MsgBoxStyle.Question & MsgBoxStyle.YesNo) == MsgBoxResult.Yes) {
				Compiler _Compiler = new Compiler(Game);

				_Compiler.Compile(Result);
			} else {
				using (Process P = new Process()) {
				    P.StartInfo.FileName = "explorer.exe";
				    P.StartInfo.Arguments = "/select," + Result;

                    P.Start();
				}
			}
		}
	}


	private string ModelName;
    
    /// <summary>
    /// Generate a QC file to be able compile the given SMD into a static prop
    /// </summary>
    /// <param name="FilePath"></param>
    /// <param name="Game"></param>
    /// <param name="SurfaceProperties"></param>
    /// <returns>Path to the QC file OR null on failure</returns>
	string SMD2QC(string FilePath, LibModMaker.SourceMod Game, string SurfaceProperties = "default")
	{
		try {
			ModelName = Path.GetFileNameWithoutExtension(FilePath);
            
            //trim any of these postfixes as they are used by convention but meaningless
			string[] Variations = {
				"_Reference",
				"Reference",
				"_Ref",
				"Ref",
				"_idle",
				"idle"
			};

			foreach (var Variation in Variations) {
				if (ModelName == Variation) {
					ModelName = Path.GetDirectoryName(FilePath);

					break;
				} else {
					if (ModelName.EndsWith(Variation, StringComparison.InvariantCultureIgnoreCase)) {
						ModelName = ModelName.Substring(0, ModelName.Length - Variation.Length);

						break;
					}
				}
			}


			string QCFolder = Path.GetDirectoryName(FilePath);
            //generate the QC file
			string QCPath = Path.Combine(QCFolder, ModelName + ".qc");

			if (string.IsNullOrEmpty(SurfaceProperties))
				SurfaceProperties = "default";

			using (StreamWriter Output = File.CreateText(QCPath)) {
				Output.Write(string.Format(Properties.Resources.QCTemplate, Path.GetFileName(FilePath), ModelName, SurfaceProperties));

				Output.Flush();
			}

            //prepare the textures used by our source model for use in Source
			List<string> Textures = GetTextureList(FilePath);

			foreach (string T in Textures) {
                string texturePath = Path.Combine(QCFolder, T);

				PrepareMaterials(texturePath, Game);
			}

			return QCPath;
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
    /// List all the textures uesd by a reference SMD file
    /// </summary>
    /// <param name="FilePath"></param>
    /// <returns>a list of relative file paths</returns>
	List<string> GetTextureList(string FilePath)
	{
		List<string> Result = new List<string>();

		if (!File.Exists(FilePath))
			return Result;

		using (StreamReader SR = new StreamReader(FilePath)) {
			string Line = SR.ReadLine();

			//Skip ahead to the geometry
			while (Line != "triangles") {
				if (Line == null)
					return Result;
				//EOF

				Line = SR.ReadLine();
			}

			Line = SR.ReadLine();

			if (!Result.Contains(Line))
				Result.Add(Line);

			while (Line != null) {
				Line = SR.ReadLine();

				if (Line == null || Line == "end")
					return Result;

				Line = SR.ReadLine();

				if (Line == null || Line == "end")
					return Result;

				Line = SR.ReadLine();

				if (Line == null || Line == "end")
					return Result;

				Line = SR.ReadLine();

				if (Line == null || Line == "end")
					return Result;

				if (!Result.Contains(Line))
					Result.Add(Line);
			}
		}

		return Result;
	}

    /// <summary>
    /// Prepare a texture file for use in soirce
    /// </summary>
    /// <param name="FilePath"></param>
    /// <param name="Game"></param>
	void PrepareMaterials(string FilePath, SourceMod Game)
	{
		string Ext = Path.GetExtension(FilePath);
        
        //if the texture is not in a fomat supported by VTEX convert the texture to TGA
		if (!(Ext == ".tga" || Ext == ".psd")) {
			FilePath = ConvertToTga(FilePath, Ext);
		}

        //if the file doesn't exist make a placeholder VMT and return
		if (FilePath == null) {
			MakePlaceholerVMT(FilePath, Game);

			return;
		}

        //Convert the TGA or PSD texture to VTF using VTEX and generate a VMT file referenceing it
		try {
			System.Diagnostics.Process Vtex = new System.Diagnostics.Process();

		    Vtex.StartInfo.FileName = "vtex.exe";
            Vtex.StartInfo.Arguments = string.Format("-outdir \"{0}\" -mkdir -quiet -shader VertexLitGeneric -vmtparam $model 1 \"{1}\"",Path.Combine(Game.InstallPath, "materials","models", ModelName),FilePath);
		    Vtex.StartInfo.CreateNoWindow = true;
		    Vtex.StartInfo.WorkingDirectory = Game.SDKPath;
		    Vtex.StartInfo.UseShellExecute = false;

            Vtex.Start();
			Vtex.WaitForExit();
		} catch (Exception ex) {
			Debug.WriteLine(ex.GetType().Name);
			Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }

	}

    /// <summary>
    /// Convert an image file to TGA
    /// </summary>
    /// <param name="SourceFile"></param>
    /// <param name="Ext"></param>
    /// <returns>path to the TGA file or null on error</returns>
	string ConvertToTga(string SourceFile, string Ext)
	{
		string[] SupportedFormats = {
			".bmp",
			".jpg",
			".gif",
			".png"
		};

		if (Array.IndexOf(SupportedFormats, Ext) == -1)
			return null;

		try {
			Bitmap Bitmap = new Bitmap(SourceFile);
			TGA TGA = new TGA(Bitmap);
			string TGAPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(SourceFile) + ".tga");

			if (File.Exists(TGAPath)) File.Delete(TGAPath);

			TGA.Save(TGAPath);

			return TGAPath;
		} catch (Exception ex) {
			Debug.WriteLine("SMD2QC_Tool.ConvertToTga");
			Debug.WriteLine(ex.GetType().Name);
			Debug.WriteLine(ex.Message);

			return null;
		}

	}
    
    /// <summary>
    /// Make a VMT file referencing a missing texture
    /// </summary>
    /// <param name="SourceFile">name of the missing texture</param>
    /// <param name="Game"></param>
	void MakePlaceholerVMT(string SourceFile, SourceMod Game)
	{
		string MaterialFolder = Path.Combine(Game.InstallPath, "materials/models/");
		string MaterialPath = Path.Combine(MaterialFolder, ModelName);

		Directory.CreateDirectory(MaterialPath);

		string SourceFileName = Path.GetFileNameWithoutExtension(SourceFile);
		KeyValues Result = new KeyValues("VertexLitGeneric");
		KeyValues Temp = new KeyValues("$basetexture", Path.Combine( "models" , ModelName , SourceFileName), Result);
		Temp = new KeyValues("$model", "1", Result);

		Result.Save(Path.Combine(MaterialPath, SourceFileName + ".vmt"));
	}

}


}