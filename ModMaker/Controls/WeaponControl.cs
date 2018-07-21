using System;
using LibModMaker;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ModMaker
{
    /// <summary>
    /// Main interface of the Weapon Editor, enabled editing of a wapon script
    /// </summary>
    public partial class WeaponControl
    {
        private KeyValues _value;
        private SourceMod _Game;

        private WeaponScript _WeaponScript;

        public SourceMod Game
        {
            get { return _Game; }
            set
            {
                _Game = value;

                if (_Game == null)
                    return;

                _WeaponScript = new WeaponScript(_Game);
                TexWeapon.Game = value;
                TexWeapon_S.Game = value;
                TexZoom.Game = value;
                TexAmmo.Game = value;
                TexAmmo2.Game = value;
                TexCrosshair.Game = value;
                TexAutoAim.Game = value;
                TexAutoAimZoom.Game = value;
                TexDeath.Game = value;
            }
        }

        public string WeaponName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public KeyValues Value
        {
            get
            {
                if (_value == null)
                    _value = new KeyValues("WeaponData");


                if (DesignMode) return _value;

                _value.SetValue("printname", txtPrintName.Text);
                _value.SetValue("viewmodel", txtViewModel.Text);
                _value.SetValue("playermodel", txtWorldModel.Text);
                _value.SetValue("anim_prefix", txtAnimPrefix.Text);
                _value.SetValue("bucket", udBucket.Value.ToString());
                _value.SetValue("bucket_position", udSlot.Value.ToString());
                _value.SetValue("item_flags", Item_Flags.ToString());

                _value.SetValue("autoswitchto", chkAutoSwitchTo.Checked ? "1" : "0");
                _value.SetValue("autoswitchfrom", chkAutoSwitchFrom.Checked ? "1" : "0");
                _value.SetValue("weight", udWeight.Value.ToString());

                _value.SetValue("BuiltRightHanded", chkRightHanded.Checked ? "1" : "0");
                _value.SetValue("AllowFlipping", chkCanFlip.Checked ? "1" : "0");

                _value.SetValue("rumble", txtRumble.Text);
                _value.SetValue("showusagehint", (txtHint.Text.Length > 0) ? "1" : "0");

                if (cboPrimaryAmmo.Text.Length > 0)
                {
                    _value.SetValue("primary_ammo", cboPrimaryAmmo.Text);
                    _value.SetValue("clip_size", udClipSize.Value.ToString());
                    _value.SetValue("default_clip", udDefAmmo.Value.ToString());
                }
                else
                {
                    _value.SetValue("primary_ammo", null);
                    _value.SetValue("clip_size", "-1");
                    _value.SetValue("default_clip", "-1");
                }

                if (cboSecondaryAmmo.Text.Length > 0)
                {
                    _value.SetValue("secondary_ammo", cboSecondaryAmmo.Text);
                    _value.SetValue("clip2_size", udClip2Size.Value.ToString());
                    _value.SetValue("default_clip2", udDefAmmo2.Value.ToString());
                }
                else
                {
                    _value.SetValue("secondary_ammo", null);
                    _value.SetValue("clip2_size", -1);
                    _value.SetValue("default_clip2", -1);
                }

                try
                {
                    KeyValues Junk = _value.GetKey("SoundData");
                    if (Junk != null)
                        _value.Keys.Remove(Junk);
                    _value["SoundData"] = SoundData;

                    Junk = _value.GetKey("TextureData");
                    if (Junk != null)
                        _value.Keys.Remove(Junk);
                    _value["TextureData"] = TextureData;
                }
                catch (System.Exception)
                {
                }

                return _value;
            }
            set
            {
                if (value == null)
                    return;

                _value = value;

                txtPrintName.Text = _value.GetString("printname");
                txtViewModel.Text = _value.GetString("viewmodel");
                txtWorldModel.Text = _value.GetString("playermodel");
                txtAnimPrefix.Text = _value.GetString("anim_prefix");
                udBucket.Value = _value.GetInt("bucket");
                udSlot.Value = _value.GetInt("bucket_position");
                Item_Flags = (UInt32)_value.GetInt("item_flags");

                chkAutoSwitchTo.Checked = _value.GetBool("autoswitchto", true);
                chkAutoSwitchFrom.Checked = _value.GetBool("autoswitchfrom", true);
                udWeight.Value = _value.GetInt("weight");

                chkRightHanded.Checked = _value.GetBool("BuiltRightHanded", true);
                chkCanFlip.Checked = _value.GetBool("AllowFlipping", true);

                txtRumble.Text = _value.GetString("rumble");
                txtHint.Text = _value.GetBool("showusagehint") ? "Hint" : "";

                cboPrimaryAmmo.Text = _value.GetString("primary_ammo");
                udClipSize.Value = _value.GetInt("clip_size", 0);
                udDefAmmo.Value = _value.GetInt("default_clip", 0);

                cboSecondaryAmmo.Text = _value.GetString("secondary_ammo");
                udClip2Size.Value = _value.GetInt("clip2_size", 0);
                udDefAmmo2.Value = _value.GetInt("default_clip2", 0);

                SoundData = _value.GetKey("SoundData");
                TextureData = _value.GetKey("TextureData");
            }
        }

        public KeyValues SoundData
        {
            get
            {
                KeyValues Result = null;

                if (_value == null)
                {
                    Result = new KeyValues("SoundData");
                }
                else
                {
                    Result = _value["SoundData"];

                    if (Result == null)
                        Result = new KeyValues("SoundData");
                }

                if (_WeaponScript == null)
                    return Result;

                _WeaponScript.Name = txtName.Text;

                Result.Keys.Clear();
                _WeaponScript.SetSoundKey(Result, "single_shot", sndSingle.SoundPath);
                _WeaponScript.SetSoundKey(Result, "single_shot_npc", sndSingleNPC.SoundPath);
                _WeaponScript.SetSoundKey(Result, "double_shot", sndDoubleShot.SoundPath);
                _WeaponScript.SetSoundKey(Result, "double_shot", sndDoubleShotNPC.SoundPath);
                _WeaponScript.SetSoundKey(Result, "burst", sndBurst.SoundPath);
                _WeaponScript.SetSoundKey(Result, "empty", sndEmpty.SoundPath);
                _WeaponScript.SetSoundKey(Result, "reload", sndReload.SoundPath);
                _WeaponScript.SetSoundKey(Result, "reload_npc", sndReloadNPC.SoundPath);
                _WeaponScript.SetSoundKey(Result, "melee_miss", sndMeleeMiss.SoundPath);
                _WeaponScript.SetSoundKey(Result, "melee_hit", sndMeleeHit.SoundPath);
                _WeaponScript.SetSoundKey(Result, "melee_hit_world", sndMeleeHitWorld.SoundPath);
                _WeaponScript.SetSoundKey(Result, "special1", sndSpecial1.SoundPath);
                _WeaponScript.SetSoundKey(Result, "special2", sndSpecial2.SoundPath);
                _WeaponScript.SetSoundKey(Result, "special3", sndSpecial3.SoundPath);
                _WeaponScript.SetSoundKey(Result, "taunt", sndTaunt.SoundPath);

                return Result;
            }
            set
            {
                if (value == null)
                    return;
                if (_WeaponScript == null)
                    return;

                sndSingle.SoundPath = _WeaponScript.GetSoundWav(value, "single_shot");
                sndSingleNPC.SoundPath = _WeaponScript.GetSoundWav(value, "single_shot_npc");
                sndDoubleShot.SoundPath = _WeaponScript.GetSoundWav(value, "double_shot");
                sndDoubleShotNPC.SoundPath = _WeaponScript.GetSoundWav(value, "double_shot");
                sndBurst.SoundPath = _WeaponScript.GetSoundWav(value, "burst");
                sndEmpty.SoundPath = _WeaponScript.GetSoundWav(value, "empty");
                sndReload.SoundPath = _WeaponScript.GetSoundWav(value, "reload");
                sndReloadNPC.SoundPath = _WeaponScript.GetSoundWav(value, "reload_npc");
                sndMeleeMiss.SoundPath = _WeaponScript.GetSoundWav(value, "melee_miss");
                sndMeleeHit.SoundPath = _WeaponScript.GetSoundWav(value, "melee_hit");
                sndMeleeHitWorld.SoundPath = _WeaponScript.GetSoundWav(value, "melee_hit_world");
                sndSpecial1.SoundPath = _WeaponScript.GetSoundWav(value, "special1");
                sndSpecial2.SoundPath = _WeaponScript.GetSoundWav(value, "special2");
                sndSpecial3.SoundPath = _WeaponScript.GetSoundWav(value, "special3");
                sndTaunt.SoundPath = _WeaponScript.GetSoundWav(value, "taunt");
            }
        }

        public KeyValues TextureData
        {
            get
            {
                KeyValues Result = null;

                if (_value == null)
                {
                    Result = new KeyValues("TextureData");
                }
                else
                {
                    Result = _value["TextureData"];

                    if (Result == null)
                        Result = new KeyValues("TextureData");
                }

                Result.Keys.Clear();

                Result.Keys.Add(this.TexWeapon.Data);
                Result.Keys.Add(this.TexWeapon_S.Data);
                Result.Keys.Add(this.TexAmmo.Data);
                Result.Keys.Add(this.TexAmmo2.Data);
                Result.Keys.Add(this.TexCrosshair.Data);
                Result.Keys.Add(this.TexZoom.Data);
                Result.Keys.Add(this.TexAutoAim.Data);
                Result.Keys.Add(this.TexAutoAimZoom.Data);

                return Result;
            }
            set
            {
                this.TexWeapon.Data = null;
                this.TexWeapon_S.Data = null;
                this.TexAmmo.Data = null;
                this.TexAmmo2.Data = null;
                this.TexCrosshair.Data = null;
                this.TexZoom.Data = null;
                this.TexAutoAim.Data = null;
                this.TexAutoAimZoom.Data = null;

                if (value == null)
                    return;

                foreach (var TexData in value.Keys)
                {
                    switch (TexData.Name)
                    {
                        case "weapon":
                            this.TexWeapon.Data = TexData;
                            break;
                        case "weapon_s":
                            this.TexWeapon_S.Data = TexData; break;
                        case "ammo":
                            this.TexAmmo.Data = TexData; break;
                        case "ammo2":
                            this.TexAmmo2.Data = TexData; break;
                        case "crosshair":
                            this.TexCrosshair.Data = TexData; break;
                        case "autoaim":
                            this.TexAutoAim.Data = TexData; break;
                        case "zoom":
                            this.TexZoom.Data = TexData; break;
                        case "zoomautoaim":
                            this.TexAutoAimZoom.Data = TexData; break;
                    }
                }
            }
        }

        public KeyValues DeathTexureData
        {
            get { return this.TexDeath.Data; }
            set { this.TexDeath.Data = value; }
        }

        public UInt32 Item_Flags
        {
            get
            {
                UInt32 Result = 0;

                if (DesignMode) return Result;

                if (chkSELECTONEMPTY.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.SELECTONEMPTY;
                if (chkNOAUTORELOAD.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.NOAUTORELOAD;
                if (chkSELECTONEMPTY.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.NOAUTOSWITCHEMPTY;
                if (chkLIMITINWORLD.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.LIMITINWORLD;
                if (chkEXHAUSTIBLE.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.EXHAUSTIBLE;
                if (chkDOHITLOCATIONDMG.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.DOHITLOCATIONDMG;
                if (chkNOAMMOPICKUPS.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.NOAMMOPICKUPS;
                if (chkNOITEMPICKUP.Checked)
                    Result = Result | (uint)WeaponScript.item_flag.NOITEMPICKUP;

                return Result;
            }
            set
            {
                chkSELECTONEMPTY.Checked = ((value & (uint)WeaponScript.item_flag.SELECTONEMPTY) > 0);
                chkNOAUTORELOAD.Checked = ((value & (uint)WeaponScript.item_flag.NOAUTORELOAD) > 0);
                chkSELECTONEMPTY.Checked = ((value & (uint)WeaponScript.item_flag.NOAUTOSWITCHEMPTY) > 0);
                chkLIMITINWORLD.Checked = ((value & (uint)WeaponScript.item_flag.LIMITINWORLD) > 0);
                chkEXHAUSTIBLE.Checked = ((value & (uint)WeaponScript.item_flag.EXHAUSTIBLE) > 0);
                chkDOHITLOCATIONDMG.Checked = ((value & (uint)WeaponScript.item_flag.DOHITLOCATIONDMG) > 0);
                chkNOAMMOPICKUPS.Checked = ((value & (uint)WeaponScript.item_flag.NOAMMOPICKUPS) > 0);
                chkNOITEMPICKUP.Checked = ((value & (uint)WeaponScript.item_flag.NOITEMPICKUP) > 0);
            }
        }

        public WeaponControl()
        {
            InitializeComponent();
            cboPrimaryAmmo.Items.Clear();
            cboPrimaryAmmo.Items.AddRange(WeaponScript.AmmoTypes);
            cboSecondaryAmmo.Items.Clear();
            cboSecondaryAmmo.Items.AddRange(WeaponScript.AmmoTypes);
        }

        private void btnBrowseView_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select View Model",
                Filter = "View Models (v_*.mdl)|v_*.mdl|All Models (*.mdl)|*.mdl",
                DefaultExt = ".mdl",
                CheckFileExists = true
            };

            if (Game != null)
            {
                if (txtViewModel.Text.Length > 0)
                {
                    Dialog.FileName = Path.GetFileName(txtViewModel.Text);
                    Dialog.InitialDirectory =
                        Path.GetDirectoryName(Path.Combine(Game.InstallPath, txtViewModel.Text));
                }
                else
                {
                    Dialog.FileName = "v_" + txtName.Text + ".mdl";
                    Dialog.InitialDirectory = Path.Combine(Game.InstallPath, "models/weapons");
                }
            }
            else
            {
                Dialog.FileName = Path.GetFileName(txtViewModel.Text);
            }

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            if (Game != null)
            {
                string Path = Dialog.FileName;

                if (Path.StartsWith(Game.InstallPath))
                    Path = Path.Substring(Game.InstallPath.Length);

                txtViewModel.Text = Path;
            }
            else
            {
                txtViewModel.Text = Dialog.FileName;
            }
        }

        // ERROR: Handles clauses are not supported in C#
        private void btnBrowseWorld_Click(System.Object sender, System.EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Select World Model",
                Filter = "World Models (w_*.mdl)|w_*.mdl|Player Models (p_*.mdl)|p_*.mdl|All Models (*.mdl)|*.mdl",
                DefaultExt = ".mdl",
                CheckFileExists = true
            };

            if (Game != null)
            {
                if (txtWorldModel.Text.Length > 0)
                {
                    Dialog.FileName = Path.GetFileName(txtWorldModel.Text);
                    Dialog.InitialDirectory =
                        Path.GetDirectoryName(Path.Combine(Game.InstallPath, txtWorldModel.Text));
                }
                else
                {
                    Dialog.FileName = "p_" + txtName.Text + ".mdl";
                    Dialog.InitialDirectory = Path.Combine(Game.InstallPath, "models/weapons");
                }
            }
            else
            {
                Dialog.FileName = Path.GetFileName(txtWorldModel.Text);
            }

            if (Dialog.ShowDialog() != DialogResult.OK)
                return;

            if (Game != null)
            {
                string Path = Dialog.FileName;

                if (Path.StartsWith(Game.InstallPath))
                    Path = Path.Substring(Game.InstallPath.Length);

                txtWorldModel.Text = Path;
            }
            else
            {
                txtWorldModel.Text = Dialog.FileName;
            }
        }
    }

}