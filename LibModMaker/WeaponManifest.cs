using System;
using System.Collections.Generic;
using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// Helper for working with the Source game engine's weapons manifest
    /// </summary>
public class WeaponManifest : Dictionary<string, KeyValues>
{

	public SourceMod Game { get; set; }

    private SourceFileSystem SFS = null;

    protected string ManifestFilePath {
		get {
			if (Game == null)
				return null;

			return Path.Combine(Path.Combine(Game.InstallPath, "scripts"), "weapon_manifest.txt");
		}
	}

	public WeaponManifest(SourceMod Game)
	{
		this.Game = Game;

        SFS = new SourceFileSystem(Game);

	    PrepareFile("scripts/weapon_manifest.txt");

		if (LoadFile(ManifestFilePath))
			return;

		LoadFolder();
	}

	public bool LoadFile(string FilePath)
	{
		KeyValues Manifest = KeyValues.LoadFile(FilePath);

		if (Manifest == null) return false;

		string ScriptPath;

		foreach (KeyValues WeaponKey in Manifest.Keys) {
            PrepareFile(WeaponKey.Value);
            ScriptPath = Path.Combine(Game.InstallPath, WeaponKey.Value);
			Add(ScriptPath, KeyValues.LoadFile(ScriptPath));
		}

		return Count > 0;
	}

    private void PrepareFile(string relativeFilePath)
    {
        if (File.Exists(Path.Combine(Game.InstallPath, String.Format(relativeFilePath)))) return;

        if (SFS.Contains(relativeFilePath))
        {
            SFS.Extract(relativeFilePath, Game.InstallPath);
        }
    }

	public void LoadFolder()
	{
		string[] WeaponScripts = Directory.GetFiles(Path.Combine(Game.InstallPath, "scripts"), "weapon_*.txt");

		foreach (string WeaponScript in WeaponScripts) {
			if (SourceFileSystem.IsBackupFile(WeaponScript))
				continue;

			KeyValues WeaponKey = KeyValues.LoadFile(WeaponScript);

			if (WeaponKey == null)
				continue;

			Add(WeaponScript, WeaponKey);
		}
	}

	public void Save()
	{
		KeyValues Result = new KeyValues("weapon_manifest");

		foreach (string FilePath in this.Keys) {
			KeyValues FileEntry = new KeyValues("file", FilePath.Substring(Game.InstallPath.Length), Result);
		}

		Result.Save(ManifestFilePath);
	}
}//end class
}