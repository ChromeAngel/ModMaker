using LibModMaker;
using System;
using Microsoft.VisualBasic;

namespace ModMaker
{
    /// <summary>
    /// Provide the mapper with a checkbox to toggle a flag on an enity
    /// </summary>
    /// <remarks>
    /// Part of the MM FGD editor
    /// </remarks>
    public partial class FGD_FlagControl
    {

        private ForgeGameData.SpawnFlag _Flag;
        public event OnDeleteEventHandler OnDelete;

        public delegate void OnDeleteEventHandler(object sender, String Name);

        public FGD_FlagControl()
        {
            InitializeComponent();
        }

        public ForgeGameData.SpawnFlag Flag
        {
            get
            {
                _Flag.BitFlags = (int) numValue.Value;
                _Flag.DefaultSetting = chkDefault.Checked;
                _Flag.Name = txtLabel.Text;
                return _Flag;
            }
            set
            {
                _Flag = value;

                if (value == null)
                {
                    return;
                }

                numValue.Value = _Flag.BitFlags;
                chkDefault.Checked = _Flag.DefaultSetting;
                txtLabel.Text = _Flag.Name;
            }
        }

        public bool IsReadOnly
        {
            get { return txtLabel.ReadOnly; }
            set
            {
                txtLabel.ReadOnly = value;
                numValue.ReadOnly = value;
                chkDefault.Enabled = !value;
                btnDelete.Visible = !value;
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (
                Interaction.MsgBox("Delete the flag " + _Flag.Name + "?", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Delete Flag?") !=
                MsgBoxResult.Yes)
                return;

            if (OnDelete != null)
            {
                OnDelete(this, _Flag.Name);
            }
        }
    }
}