using LibModMaker;
using System;
using Microsoft.VisualBasic;


namespace ModMaker
{

    /// <summary>
    /// Provide the mapper with a control to define inputs or outputs from and enity
    /// </summary>
    /// <remarks>
    /// Part of the MM FGD editor
    /// </remarks>
    public partial class FGD_IOControl
    {

        private ForgeGameData.IOConnector _Connector;
        public event OnDeleteEventHandler OnDelete;

        public delegate void OnDeleteEventHandler(object sender, String Name);

        public FGD_IOControl()
        {
            InitializeComponent();
        }

        public ForgeGameData.IOConnector Connector
        {
            get
            {
                _Connector.Name = txtName.Text;
                _Connector.DataType = cboDataType.SelectedItem.ToString();
                _Connector.Notes = txtNotes.Text;

                return _Connector;
            }
            set
            {
                _Connector = value;


                if (value == null)
                {
                    return;
                }

                txtName.Text = _Connector.Name;
                cboDataType.SelectedItem = _Connector.DataType;
                txtNotes.Text = _Connector.Notes;
            }
        }

        public bool IsReadonly
        {
            get { return txtName.ReadOnly; }
            set
            {
                txtName.ReadOnly = value;
                txtNotes.ReadOnly = value;
                cboDataType.Enabled = !value;
                btnDelete.Visible = !value;
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (
                Interaction.MsgBox(string.Format("Delete the {0} {1}?", _Connector.IsInput ? "input" : "output", _Connector.Name),
                    MsgBoxStyle.Question & MsgBoxStyle.YesNo,
                    string.Format("Delete {0}?", _Connector.IsInput ? "input" : "output")) != MsgBoxResult.Yes)
                return;

            if (OnDelete != null)
            {
                OnDelete(this, _Connector.Name);
            }
        }
    }

}