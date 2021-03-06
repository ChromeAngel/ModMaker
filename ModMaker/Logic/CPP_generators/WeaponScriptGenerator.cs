﻿using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// Generates boilerplate C++ code for a Source weapon given a weapon script
    /// </summary>

    public class WeaponScriptGenerator
    {
        public SourceMod Game { get; set; }
        public string WeaponName { get; set; }

        private string ClassName;
        private StreamWriter Header;
        private StreamWriter Body;

        private KeyValues WeaponScript;

        public void Export(string SourceFolder, KeyValues WeaponScript)
        {
            if (WeaponScript == null)
                return;
            if (Game == null)
                return;
            if (string.IsNullOrEmpty(WeaponName))
                return;

            this.WeaponScript = WeaponScript;
            ClassName = "CWeapon" + CPlusPlus.ToID(WeaponName);

            string HeaderName = string.Format("weapon_{0}.h", WeaponName);
            string HeaderPath = Path.Combine(SourceFolder, HeaderName);
            string BodyPath = Path.Combine(SourceFolder, string.Format("weapon_{0}.cpp", WeaponName));

            using (var Header = new StreamWriter(HeaderPath))
            {
                using (var Body = new StreamWriter(BodyPath))
                {
                    this.Header = Header;
                    this.Body = Body;

                    WriteFileHeaders();
                    WriteBody();
                }
            }

            Interaction.MsgBox("Exported " + BodyPath, MsgBoxStyle.Information, "Mod Maker");
        }

        public bool IsMeleeWeapon
        {
            get { return ("None" == WeaponScript.GetString("primary_ammo", "None")); }
        }

        private string BaseClass
        {
            get { return IsMeleeWeapon ? "CBaseHLBludgeonWeapon" : "CHLMachineGun"; }
        }

        void WriteFileHeaders()
        {
            Header.WriteLine("// Purpose: Header for " + ClassName);
            Header.WriteLine("// Boilerplate generated by ModMaker on " + DateTime.Now.ToString());
            Header.WriteLine();
            Header.WriteLine("#ifndef {0}_WEAPON_{1}_H", Game.InstallFolder.ToUpper(), WeaponName.ToUpper());
            Header.WriteLine("#define {0}_WEAPON_{1}_H", Game.InstallFolder.ToUpper(), WeaponName.ToUpper());
            Header.WriteLine("#ifdef _WIN32");
            Header.WriteLine("#pragma once");
            Header.WriteLine();

            if (IsMeleeWeapon)
            {
                Header.WriteLine("#include \"basebludgeonweapon.h\"");
            }
            else
            {
                Header.WriteLine("#include \"basehlcombatnweapon.h\"");
            }

            Header.WriteLine();
            Header.WriteLine("#ifdef CLIENT_DLL");
            Header.WriteLine("#define {0} C_Weapon{1}", ClassName, WeaponName);
            Header.WriteLine("#ifdef CLIENT_DLL");
            Header.WriteLine();
            Header.WriteLine("//-----------------------------------------------------------------------------");
            Header.WriteLine("// " + ClassName);
            Header.WriteLine("//-----------------------------------------------------------------------------");
            Header.WriteLine();
            Header.WriteLine("class {0} : public {1}", ClassName, BaseClass);
            Header.WriteLine("{");
            Header.WriteLine("public:");
            Header.WriteLine("    DECLARE_CLASS( {0}, {1} );", ClassName, BaseClass);
            Header.WriteLine("    DECLARE_NETWORKCLASS(); ");
            Header.WriteLine("    DECLARE_PREDICTABLE();");
            Header.WriteLine("#ifndef CLIENT_DLL");
            Header.WriteLine("    DECLARE_ACTTABLE();");
            Header.WriteLine("#endif");
            Header.WriteLine();
            Header.WriteLine("    {0}();", ClassName);
            Header.WriteLine("    ~{0}();", ClassName);
            Header.WriteLine("};");
            Header.WriteLine();
            Header.WriteLine("#endif // {0}_WEAPON_{1}_H", Game.InstallFolder.ToUpper(), WeaponName.ToUpper());
        }

        void WriteBody()
        {
            string PlayerAnimPrefix = WeaponScript.GetString("anim_prefix", WeaponName);

            Body.WriteLine("// Purpose: Body for " + ClassName);
            Body.WriteLine("// Boilerplate generated by ModMaker on " + DateTime.Now.ToString());
            Body.WriteLine();
            Body.WriteLine("#include \"cbase.h\"");
            Body.WriteLine("#include \"{0}.h\"", WeaponName);
            Body.WriteLine();
            Body.WriteLine("// memdbgon must be the last include file in a .cpp file!!!");
            Body.WriteLine("#include \"tier0/memdbgon.h\"");
            Body.WriteLine();
            Body.WriteLine("IMPLEMENT_NETWORKCLASS_ALIASED( Weapon{0}, DT_Weapon{0} )", WeaponName);
            Body.WriteLine();
            Body.WriteLine("BEGIN_NETWORK_TABLE( {0}, DT_Weapon{1} )", ClassName, WeaponName);
            Body.WriteLine("END_NETWORK_TABLE()");
            Body.WriteLine();
            Body.WriteLine("BEGIN_PREDICTION_DATA({0} )", ClassName);
            Body.WriteLine("END_PREDICTION_DATA()");
            Body.WriteLine();
            Body.WriteLine("LINK_ENTITY_TO_CLASS( weapon_{0}, {1} );", WeaponName, ClassName);
            Body.WriteLine("PRECACHE_WEAPON_REGISTER(weapon_{0});", WeaponName);
            Body.WriteLine();
            Body.WriteLine("#ifndef CLIENT_DLL");
            Body.WriteLine("acttable_t {0}::m_acttable[] = ", ClassName);
            Body.WriteLine("{");
            Body.WriteLine("\t{{ ACT_HL2MP_IDLE,                 ACT_HL2MP_IDLE_{0},                 false }},",
                PlayerAnimPrefix);
            Body.WriteLine("\t{{ ACT_HL2MP_RUN,                  ACT_HL2MP_RUN_{0},                  false }},",
                PlayerAnimPrefix);
            Body.WriteLine("\t{{ ACT_HL2MP_IDLE_CROUCH,          ACT_HL2MP_IDLE_CROUCH_{0},          false }},",
                PlayerAnimPrefix);
            Body.WriteLine("\t{{ ACT_HL2MP_WALK_CROUCH,          ACT_HL2MP_WALK_CROUCH_{0},          false }},",
                PlayerAnimPrefix);
            Body.WriteLine("\t{{ ACT_HL2MP_JUMP,                 ACT_HL2MP_JUMP_{0},                 false }},",
                PlayerAnimPrefix);

            if (IsMeleeWeapon)
            {
                Body.WriteLine("\t{ ACT_MELEE_ATTACK1,              ACT_MELEE_ATTACK_SWING,             true },");
            }
            else
            {
                Body.WriteLine("\t{{ ACT_RANGE_ATTACK1,              ACT_RANGE_ATTACK_{0},               false }},",
                    PlayerAnimPrefix);
                Body.WriteLine("\t{{ ACT_HL2MP_GESTURE_RANGE_ATTACK, ACT_HL2MP_GESTURE_RANGE_ATTACK_{0}, false }},",
                    PlayerAnimPrefix);
                Body.WriteLine("\t{{ ACT_HL2MP_GESTURE_RELOAD,       ACT_HL2MP_GESTURE_RELOAD_{0},       false }},",
                    PlayerAnimPrefix);
            }

            Body.WriteLine("};");
            Body.WriteLine();
            Body.WriteLine("IMPLEMENT_ACTTABLE({0});", ClassName);
            Body.WriteLine("#endif");
            Body.WriteLine();
            Body.WriteLine("//-----------------------------------------------------------------------------");
            Body.WriteLine("// Constructor");
            Body.WriteLine("//-----------------------------------------------------------------------------");
            Body.WriteLine("{0}::{0}()", ClassName);
            Body.WriteLine("{");
            Body.WriteLine("};");
            Body.WriteLine();
            Body.WriteLine("//-----------------------------------------------------------------------------");
            Body.WriteLine("// Destructor");
            Body.WriteLine("//-----------------------------------------------------------------------------");
            Body.WriteLine("~{0}::{0}()", ClassName);
            Body.WriteLine("{");
            Body.WriteLine("};");
        }


    }


}
