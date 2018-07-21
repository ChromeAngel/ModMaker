using System.IO;

namespace LibModMaker
{
    /// <summary>
    /// Helper class for working with weapon scripts, that allows non-programmers to control the assets and behaviour of Source weapons
    /// </summary>
public class WeaponScript
{
	public SourceMod Game { get; set; }
	public string Name { get; set; }


	private LibModMaker.SoundManifest Manifest = null;
	public enum item_flag
	{
		SELECTONEMPTY = 1,
		NOAUTORELOAD = 2,
		NOAUTOSWITCHEMPTY = 4,
		LIMITINWORLD = 8,
		EXHAUSTIBLE = 16,
		DOHITLOCATIONDMG = 32,
		NOAMMOPICKUPS = 64,
		NOITEMPICKUP = 128
	}


	public static string[] AmmoTypes = { "None","357","AR2","AR2AltFire","Buckshot","Grenade","Pistol","RPG_Round","slam","SMG1","SMG1_Grenade","XBowBolt" };
	public WeaponScript(SourceMod Game)
	{
		this.Game = Game;
		Manifest = new SoundManifest(Game);
		Manifest.Load();
	}

	public string GetSoundWav(KeyValues WeaponScript, string KeyName)
	{
		if (WeaponScript == null)
			return string.Empty;
		if (string.IsNullOrEmpty(KeyName))
			return string.Empty;

		string SoundScript = WeaponScript.GetString(KeyName);

		if (SoundScript.Length == 0)
			return string.Empty;

		return Manifest.GetWavPathByScriptName(SoundScript);
	}

	public void SetSoundKey(KeyValues SoundData, string KeyName, string WavFile)
	{
		if (string.IsNullOrEmpty(WavFile))
			return;

		//Lookup a script sound using the WAV file we picked
		string ScriptName = Manifest.GetScriptNameByWavPath(WavFile);

		//if there isn't one we need to create it
		if (ScriptName == null) {
			//not scripted , add to "game_sounds_weapons.txt"
			string ScriptFileName = "game_sounds_weapons.txt";
			//of somehow it's not in the manifest add it
			if (!Manifest.SoundScriptFiles.ContainsKey(ScriptFileName)) {
				Manifest.SoundScriptFiles.Add(ScriptFileName, new SoundScriptKeyValues());
				Manifest.Manifest.SetValue(ScriptFileName, "1");
				Manifest.Manifest.Save(Manifest.ManifestPath);
			}

			//create the script entry
			SoundScriptKeyValues SoundScriptFile = Manifest.SoundScriptFiles[ScriptFileName];

			ScriptName = string.Format("{0}.{1}", Name, KeyName);

			KeyValues Script = new KeyValues(ScriptName, SoundScriptFile);

			Script.SetValue("channel", "CHAN_AUTO");
			Script.SetValue("volume", "VOL_NORM");
			Script.SetValue("soundlevel", "SNDLVL_NORM");
			Script.SetValue("pitch", "PITCH_NORM");
			Script.SetValue("wave", WavFile);

			Manifest.BackUpFile(ScriptFileName);
			SoundScriptFile.Save(ScriptFileName);
		}

		KeyValues Result = new KeyValues(KeyName, ScriptName, SoundData);
	}

	public KeyValues MakeWeapon(string Name)
	{
		KeyValues Result = new KeyValues("WeaponData");

		Result.SetValue("printname", string.Format("#{0}{1}", Game.InstallFolder, Name.ToUpper()));
		Result.SetValue("viewmodel", string.Format("weapons/v_{0}.mdl", Name));
		Result.SetValue("playermodel", string.Format("weapons/p_{0}.mdl", Name));
		Result.SetValue("anim_prefix", Name);

		KeyValues SoundData = new KeyValues("SoundData", Result);
		KeyValues TextureData = new KeyValues("TextureData", Result);

		return Result;
	}

	//for some bizzare reason kill icons are scripted in "scripts/mod_textures.txt" not in the weapon scripts
	public void SetDeathTexture(string WeaponName, KeyValues TextureData)
	{
		string mod_texturesFilePath = Path.Combine(Game.InstallPath, "scripts/mod_textures.txt");
		KeyValues mod_textures = KeyValues.LoadFile(mod_texturesFilePath);

		if (mod_textures == null)
			mod_textures = new KeyValues("sprites/640_hud");

		KeyValues ModTextureData = mod_textures.GetKey("TextureData");

		if (ModTextureData == null) {
			ModTextureData = new KeyValues("TextureData");
			mod_textures["TextureData"] = ModTextureData;
		}

		KeyValues CurrentTexture = ModTextureData.GetKey("death_" + WeaponName);

		if (CurrentTexture != null)
			TextureData.Keys.Remove(CurrentTexture);

		TextureData["death_" + WeaponName] = TextureData;

		SourceFileSystem.BackUpFile(mod_texturesFilePath);
		mod_textures.Save(mod_texturesFilePath);
	}
} //end class
}