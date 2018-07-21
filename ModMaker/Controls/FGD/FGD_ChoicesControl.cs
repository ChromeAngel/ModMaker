using LibModMaker;
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// Provide the mapper with a dropdown list of choices for an enity property
    /// </summary>
    /// <remarks>
    /// Part of the MM FGD editor
    /// </remarks>
    public partial class FGD_ChoicesControl
    {

        private ForgeGameData.ChoicesProperty _Choices;
        public event OnDeleteEventHandler OnDelete;

        public delegate void OnDeleteEventHandler(object sender, String Name);

        public ForgeGameData.ChoicesProperty ChoicesProperty
        {
            get
            {
                _Choices._Name = txtClassName.Text;
                _Choices.LabelText = txtNotes.Text;

                if(cboOptions.SelectedItem != null)
                {
                    foreach (string X in _Choices.choices.Keys)
                    {
                        if (_Choices.choices[X] == cboOptions.SelectedItem.ToString())
                        {
                            _Choices.DefaultValue = X;

                            break; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }

                return _Choices;
            }
            set
            {
                _Choices = value;

                if (value == null)
                    return;

                txtClassName.Text = _Choices._Name;
                txtNotes.Text = _Choices.LabelText;
                RefreshOptionList();
                cboOptions.SelectedValue = _Choices.DefaultValue;
            }
        }

        public bool IsReadOnly
        {
            get { return !txtClassName.Enabled; }
            set
            {
                txtClassName.Enabled = !value;
                txtNotes.Enabled = !value;
                btnManageOptions.Enabled = !value;
                lblChoices.Enabled = !value;

                txtClassName.BorderStyle = value ? BorderStyle.None : BorderStyle.Fixed3D;
                txtNotes.BorderStyle = value ? BorderStyle.None : BorderStyle.Fixed3D;
                btnDelete.Visible = !value;
            }
        }

        public FGD_ChoicesControl()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
        }

        public FGD_ChoicesControl(ForgeGameData.ChoicesProperty BaseProperty)
        {
            InitializeComponent();

            this.Name = BaseProperty._Name;
            this.ChoicesProperty = BaseProperty;
        }

        void RefreshOptionList()
        {
            int Index = 0;
            int DefaultIndex = -1;

            cboOptions.Items.Clear();

            foreach (string Value in _Choices.choices.Keys)
            {
                if (Value == _Choices.DefaultValue)
                    DefaultIndex = Index;

                Index += 1;
                cboOptions.Items.Add(_Choices.choices[Value]);
            }

            cboOptions.SelectedIndex = DefaultIndex;
        }

        private void btnManageOptions_Click(System.Object sender, System.EventArgs e)
        {
            FGDChoicesForm Dialog = new FGDChoicesForm();

            Dialog.ChoicesProperty = _Choices;

            if (Dialog.ShowDialog() == DialogResult.Cancel)
                return;

            ChoicesProperty = Dialog.ChoicesProperty;
        }


        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (
                Interaction.MsgBox("Delete the property " + _Choices.Name + "?", MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                    "Delete Property?") != MsgBoxResult.Yes)
                return;

            if (OnDelete != null)
            {
                OnDelete(this, _Choices.Name);
            }
        }
    }

}