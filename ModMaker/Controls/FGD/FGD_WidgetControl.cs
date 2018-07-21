using LibModMaker;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace ModMaker
{

    /// <summary>
    /// Provide the mapper with a widget for an enity property
    /// </summary>
    /// <remarks>
    /// Part of the MM FGD editor
    /// </remarks>
    public partial class FGD_WidgetControl
    {

        private ForgeGameData.Widget _Widget;
        public event OnDeleteEventHandler OnDelete;

        public delegate void OnDeleteEventHandler(object sender, String Name);

        public FGD_WidgetControl()
        {
            InitializeComponent();
        }

        public ForgeGameData.Widget Widget
        {
            get
            {
                _Widget.Name = txtName.Text;
                _Widget.Seperator = txtSeperator.Text;
                _Widget.Parameters.Clear();

                foreach (string paramater in cboParameters.Items)
                {
                    _Widget.Parameters.Add(paramater);
                }

                return _Widget;
            }
            set
            {
                _Widget = value;

                txtName.Text = _Widget.Name;
                txtSeperator.Text = _Widget.Seperator;
                cboParameters.Items.Clear();
                cboParameters.Items.AddRange(_Widget.Parameters.ToArray());
            }
        }

        public bool IsReadOnly
        {
            get { return !txtName.Enabled; }
            set
            {
                txtName.Enabled = !value;
                txtSeperator.Enabled = !value;
                cboParameters.Enabled = !value;
                btnDelete.Visible = !value;
            }
        }

        private void cboParameters_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboParameters.Items.Add(cboParameters.Text);
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (
                Interaction.MsgBox("Delete the property " + _Widget.Name + "?", MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                    "Delete Property?") != MsgBoxResult.Yes)
                return;

            if (OnDelete != null)
            {
                OnDelete(this, _Widget.Name);
            }
        }
    }
}