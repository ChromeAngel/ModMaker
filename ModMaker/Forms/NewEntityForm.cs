using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LibModMaker;
using Microsoft.VisualBasic;
using System.Linq;

namespace ModMaker
{
    /// <summary>
    /// UI for creating a new enity type, part of the FGD editor
    /// </summary>
    public partial class NewEntityForm
    {
        private ForgeGameData _FGD;

        private SourceMod _Game;
        public ForgeGameData FGD
        {
            get { return _FGD; }
            set
            {
                _FGD = value;

                FillBaseList();
            }
        }

        public SourceMod Game
        {
            get { return _Game; }
            set
            {
                _Game = value;
                txtName.Text = _Game.InstallFolder + "_";
            }
        }

        public ForgeGameData.EntityDef.EntityTypes EntityType
        {
            get
            {
                if (radBase.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.Base;
                }
                if (radSolid.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.Solid;
                }
                if (radPoint.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.Point;
                }
                if (radFilter.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.Filter;
                }
                if (radNPC.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.NPC;
                }
                if (radMove.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.Move;
                }
                if (radKeyFrame.Checked)
                {
                    return ForgeGameData.EntityDef.EntityTypes.KeyFrame;
                }

                return ForgeGameData.EntityDef.EntityTypes.Point;
            }
            set
            {
                switch (value)
                {
                    case ForgeGameData.EntityDef.EntityTypes.Base:
                        radBase.Checked = true;break;
                    case ForgeGameData.EntityDef.EntityTypes.Point:
                        radPoint.Checked = true;break;
                    case ForgeGameData.EntityDef.EntityTypes.Solid:
                        radSolid.Checked = true;break;
                    case ForgeGameData.EntityDef.EntityTypes.Filter:
                        radFilter.Checked = true;break;
                    case ForgeGameData.EntityDef.EntityTypes.KeyFrame:
                        radKeyFrame.Checked = true;break;
                    case ForgeGameData.EntityDef.EntityTypes.Move:
                        radMove.Checked = true;break;
                    case ForgeGameData.EntityDef.EntityTypes.NPC:
                        radNPC.Checked = true;break;
                    default:
                        radPoint.Checked = true;
                        break;
                }
            }
        }

        public NewEntityForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ModMaker;
        }


        public void FillBaseList()
        {
            ListBases.Clear();
            AddBaseItems(FGD);
        }


        private void AddBaseItems(ForgeGameData FGD)
        {
            foreach (ForgeGameData Included in FGD.Includes)
            {
                AddBaseItems(Included);
            }

            foreach (ForgeGameData.EntityDef Entity in FGD.Entities)
            {
                if (Entity.EntityType != ForgeGameData.EntityDef.EntityTypes.Base) continue;

                ListBases.Items.Add(Entity.Name);
            }
        }


        private void txtName_TextChanged(object sender, System.EventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                txtName.BackColor = System.Drawing.SystemColors.Window;
            }
            else
            {
                // if (FGD.Bases.ContainsKey(txtName.Text) || FGD.Points.ContainsKey(txtName.Text) || FGD.Solids.ContainsKey(txtName.Text))
                if (FGD.Entities.FirstOrDefault(x=>x.Name == txtName.Text) == null)
                {
                    txtName.BackColor = Color.FromArgb(213, 239, 186);
                    //pastel green - no conflict
                }
                else
                {
                    txtName.BackColor = Color.FromArgb(247, 221, 234);
                    //pastel pink - conflict
                }
            }
        }

        public ForgeGameData.EntityDef MakeEntity()
        {
            ForgeGameData.EntityDef Result = new ForgeGameData.EntityDef();

            Result.Name = txtName.Text;
            Result.Comment = txtDesk.Text;

            if (ListBases.CheckedItems.Count > 0)
            {
                ForgeGameData.Widget BaseWidget = new ForgeGameData.Widget
                {
                    Name = "base",
                    Seperator = ", "
                };

                foreach (ListViewItem Item in ListBases.CheckedItems)
                {
                    BaseWidget.Parameters.Add(Item.Text);
                }

                Result.Widgets.Add(BaseWidget);
            }

            ParseDataDesc(Result);

            if (radBase.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.Base;
            }
            if (radSolid.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.Solid;
            }
            if (radPoint.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.Point;
            }
            if (radFilter.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.Filter;
            }
            if (radNPC.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.NPC;
            }
            if (radMove.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.Move;
            }
            if (radKeyFrame.Checked)
            {
                Result.EntityType = ForgeGameData.EntityDef.EntityTypes.KeyFrame;
            }

            FGD.Entities.Add(Result);

            return Result;
        }

        void ParseDataDesc(ForgeGameData.EntityDef Result)
        {
            string[] Lines = txtDataDesc.Text.Split(ControlChars.Lf);

            foreach (string Line in Lines)
            {
                string strLine = Line.Trim();

                if (strLine.Length == 0)
                    continue;

                if (strLine.StartsWith("DEFINE_KEYFIELD"))
                {
                    strLine = strLine.Substring("DEFINE_KEYFIELD(".Length);
                    strLine = strLine.Substring(0, strLine.Length - 2);
                    //trim trailing ),

                    string[] Params = strLine.Split(',');

                    ForgeGameData.BaseProperty Prop = new ForgeGameData.BaseProperty();

                    Prop._Name = Params[2].Replace("\"", "").Trim();

                    switch (Params[1].Trim())
                    {
                        case "FIELD_VOID":
                            Prop.DataType = "void";break;
                        case "FIELD_FLOAT":
                            Prop.DataType = "float";break;
                        case "FIELD_STRING":
                            Prop.DataType = "string";break;
                        case "FIELD_VECTOR":
                            Prop.DataType = "vector";break;
                        case "FIELD_INTEGER":
                            Prop.DataType = "integer";break;
                        case "FIELD_COLOR32":
                            Prop.DataType = "color255";break;
                        case "FIELD_MODELNAME":
                            Prop.DataType = "studio";break;
                        case "FIELD_SOUNDNAME":
                            Prop.DataType = "sound";break;
                        default:
                            Prop.DataType = "string";break;
                    }

                    Result.Properties[Prop.Name] = Prop;
                }

                if (strLine.StartsWith("DEFINE_INPUTFUNC"))
                {
                    strLine = strLine.Substring("DEFINE_INPUTFUNC(".Length);
                    strLine = strLine.Substring(0, Line.Length - 2);
                    //trim trailing ),

                    string[] Params = strLine.Split(',');

                    ForgeGameData.IOConnector Inp = new ForgeGameData.IOConnector { IsInput = true };
                    Inp.Name = Params[1].Replace("\"", "").Trim();

                    Result.Inputs[Inp.Name] = Inp;
                }

                if (strLine.StartsWith("DEFINE_OUTPUT"))
                {
                    strLine = strLine.Substring("DEFINE_OUTPUT(".Length);
                    strLine = strLine.Substring(0, strLine.Length - 2);
                    //trim trailing ),

                    string[] Params = strLine.Split(',');

                    ForgeGameData.IOConnector Out = new ForgeGameData.IOConnector() { IsInput = false };
                    Out.Name = Params[1].Replace("\"", "").Trim();

                    Result.Outputs[Out.Name] = Out;
                }
            } //each line
        } //end ParseDataDesc
    }

}