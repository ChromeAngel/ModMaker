﻿using LibModMaker;
using System;
using System.IO;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ModMaker
{

    /// <summary>
    /// Generates C++ code for a VGUI panel given a Resource file
    /// </summary>
    public class VGUI_ScriptGenerator
    {
        public KeyValues ResourceFile;
        public SourceMod Game;
        private string ClassName;
        private string PanelName;
        private string HeaderName;
        private StreamWriter Header;
        private StreamWriter Body;

        public void Export(SourceMod Game, KeyValues ResourceFile, string Folder, string FileName)
        {
            this.ResourceFile = ResourceFile;
            PanelName = Path.GetFileNameWithoutExtension(FileName);
            ClassName = "C_" + ToCPP_ID(PanelName);
            HeaderName = PanelName + ".h";

            string HeaderPath = Path.Combine(Folder, HeaderName);
            string BodyPath = Path.Combine(Folder, PanelName + ".cpp");

            using (var Header = new StreamWriter(HeaderPath))
            {
                using (var Body = new StreamWriter(BodyPath))
                {
                    this.Header = Header;
                    this.Body = Body;

                    WriteFileHeaders();
                    WriteMembers();
                    WriteFileFooters(FileName);
                }
            }

            Interaction.MsgBox("Exported " + BodyPath, MsgBoxStyle.Information, "Mod Maker");
        }

        string ToCPP_ID(string Plain)
        {
            return CPlusPlus.ToID(Plain);
        }

        void WriteFileHeaders()
        {
            Header.WriteLine("// Purpose: Header for " + ClassName);
            Header.WriteLine("// Boilerplate generated by ModMaker on " + DateTime.Now.ToString());
            Header.WriteLine();
            Header.WriteLine("#ifndef {0}_H", PanelName.ToUpper());
            Header.WriteLine("#define {0}_H", PanelName.ToUpper());
            Header.WriteLine("#ifdef _WIN32");
            Header.WriteLine("#pragma once");
            Header.WriteLine("#endif");
            Header.WriteLine();
            WriteControlHeaderIncludes();
            Header.WriteLine();
            Header.WriteLine("class {0} : public vgui::EditPanel", ClassName);
            Header.WriteLine("{");
            Header.WriteLine("public:");
            Header.WriteLine("    {0}(Panel *parent, const char *panelName);", ClassName);
            Header.WriteLine();

            Body.WriteLine("// Purpose: Body for " + ClassName);
            Body.WriteLine("// Boilerplate generated by ModMaker on " + DateTime.Now.ToString());
            Body.WriteLine();
            Body.WriteLine("#include \"cbase.h\"");
            Body.WriteLine("#include \"{0}\"", HeaderName);
            Body.WriteLine();
            Body.WriteLine("// memdbgon must be the last include file in a .cpp file!!!");
            Body.WriteLine("#include \"tier0/memdbgon.h\"");
            Body.WriteLine();
            Body.WriteLine("{0}::{0}(Panel *parent, const char *panelName): EditPanel(parent, panelName)", ClassName);
            Body.WriteLine("{");
        }

        void WriteControlHeaderIncludes()
        {
            Dictionary<string, string> ControlNames = new Dictionary<string, string>();
            string memberType;

            foreach (KeyValues Panel in ResourceFile.Keys)
            {
                if (PanelName == Panel.Name)
                    continue;

                memberType = Panel.GetString("controlname", "Panel");
                ControlNames[memberType] = memberType;
            }

            foreach (string aMemberType in ControlNames.Keys)
            {
                Header.WriteLine("#include <vgui_controls/{0}.h>", aMemberType);
            }
        }

        void WriteMembers()
        {
            string varName;
            string memberType;

            foreach (KeyValues Panel in ResourceFile.Keys)
            {
                if (PanelName == Panel.Name)
                    continue;

                memberType = Panel.GetString("controlname", "Panel");
                varName = "m_p" + ToCPP_ID(Panel.Name);

                Header.WriteLine("    vgui::{0} * {1};", memberType, varName);
                Body.WriteLine("    {0} = new vgui::{1}(this,\"{2}\");", varName, memberType,
                    Panel.GetString("fieldname"));
            }
        }

        void WriteFileFooters(string FileName)
        {
            Header.WriteLine("};");
            Header.WriteLine();
            Header.WriteLine("#endif // {0}_H", PanelName.ToUpper());

            Body.WriteLine();
            Body.WriteLine("    LoadControlSettings(\"{0}\");", FileName);
            Body.WriteLine("}");
        }
    }

}