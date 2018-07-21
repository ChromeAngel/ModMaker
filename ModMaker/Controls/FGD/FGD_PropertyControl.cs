using LibModMaker;
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ModMaker
{

    /// <summary>
    /// Provide the mapper with an editor for a generic enity property
    /// </summary>
    /// <remarks>
    /// Part of the MM FGD editor
    /// </remarks>
    public partial class FGD_PropertyControl
    {

        private ForgeGameData.BaseProperty _BaseProperty;
        public event OnDeleteEventHandler OnDelete;

        public delegate void OnDeleteEventHandler(object sender, String Name);

        public ForgeGameData.BaseProperty BaseProperty
        {
            get
            {
                _BaseProperty._Name = txtClassName.Text;
                _BaseProperty.DefaultValue = txtDefault.Text;
                _BaseProperty.LabelText = txtNotes.Text;

                if(cboDataType.SelectedItem == null)
                {
                    if(_BaseProperty._Name == "spawnflags")
                    {
                        _BaseProperty.DataType = "flags";
                    } else
                    {
                        _BaseProperty.DataType = "string";
                    }
                } else
                {
                    _BaseProperty.DataType = cboDataType.SelectedItem.ToString();
                }
                

                return _BaseProperty;
            }
            set
            {
                _BaseProperty = value;

                if (value == null)
                    return;

                txtClassName.Text = _BaseProperty._Name;
                txtDefault.Text = _BaseProperty.DefaultValue;
                txtNotes.Text = _BaseProperty.LabelText;
                cboDataType.SelectedItem = _BaseProperty.DataType;
            }
        }

        public bool IsReadOnly
        {
            get { return !txtClassName.Enabled; }
            set
            {
                txtClassName.Enabled = !value;
                txtDefault.Enabled = !value;
                txtNotes.Enabled = !value;
                cboDataType.Enabled = !value;

                txtClassName.BorderStyle = value ? BorderStyle.None : BorderStyle.Fixed3D;
                txtDefault.BorderStyle = value ? BorderStyle.None : BorderStyle.Fixed3D;
                txtNotes.BorderStyle = value ? BorderStyle.None : BorderStyle.Fixed3D;
                btnDelete.Visible = !value;
            }
        }

        public FGD_PropertyControl()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
        }

        public FGD_PropertyControl(ForgeGameData.BaseProperty BaseProperty)
        {
            InitializeComponent();

            this.Name = BaseProperty._Name;
            this.BaseProperty = BaseProperty;
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (
                Interaction.MsgBox("Delete the property " + BaseProperty.Name + "?", MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                    "Delete Property?") != MsgBoxResult.Yes)
                return;

            if (OnDelete != null)
            {
                OnDelete(this, BaseProperty.Name);
            }
        }
    }

}