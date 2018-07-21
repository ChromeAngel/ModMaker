namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class KeyBindControl : System.Windows.Forms.UserControl
    {

        //UserControl overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabelToken = new System.Data.DataColumn();
            this.KeyGrid = new System.Windows.Forms.DataGridView();
            this.colGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KeyLookups = new System.Data.DataSet();
            this.Group = new System.Data.DataTable();
            this.Token = new System.Data.DataColumn();
            this.TextColumn = new System.Data.DataColumn();
            this.Keys = new System.Data.DataTable();
            this.Key = new System.Data.DataColumn();
            this.dcKeyCode = new System.Data.DataColumn();
            this.KeyBind = new System.Data.DataTable();
            this.dcGroup = new System.Data.DataColumn();
            this.dcLabel = new System.Data.DataColumn();
            this.dcCommand = new System.Data.DataColumn();
            this.dcKey = new System.Data.DataColumn();
            this.colLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.KeyGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyLookups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Keys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyBind)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelToken
            // 
            this.LabelToken.ColumnName = "LabelToken";
            // 
            // KeyGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.KeyGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.KeyGrid.AutoGenerateColumns = false;
            this.KeyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KeyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroup,
            this.colLabel,
            this.colCommand,
            this.colKey});
            this.KeyGrid.DataMember = "KeyBind";
            this.KeyGrid.DataSource = this.KeyLookups;
            this.KeyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyGrid.Location = new System.Drawing.Point(4, 5);
            this.KeyGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KeyGrid.Name = "KeyGrid";
            this.KeyGrid.RowTemplate.Height = 24;
            this.KeyGrid.Size = new System.Drawing.Size(664, 119);
            this.KeyGrid.TabIndex = 0;
            this.KeyGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.KeyGrid_DataError);
            // 
            // colGroup
            // 
            this.colGroup.DataPropertyName = "Group";
            this.colGroup.DataSource = this.KeyLookups;
            this.colGroup.DisplayMember = "Group.Text";
            this.colGroup.HeaderText = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.ValueMember = "Group.Token";
            this.colGroup.Width = 250;
            // 
            // KeyLookups
            // 
            this.KeyLookups.DataSetName = "NewDataSet";
            this.KeyLookups.Tables.AddRange(new System.Data.DataTable[] {
            this.Group,
            this.Keys,
            this.KeyBind});
            // 
            // Group
            // 
            this.Group.Columns.AddRange(new System.Data.DataColumn[] {
            this.Token,
            this.TextColumn});
            this.Group.TableName = "Group";
            // 
            // Token
            // 
            this.Token.ColumnName = "Token";
            // 
            // Text
            // 
            this.TextColumn.ColumnName = "Text";
            // 
            // Keys
            // 
            this.Keys.CaseSensitive = true;
            this.Keys.Columns.AddRange(new System.Data.DataColumn[] {
            this.Key,
            this.dcKeyCode});
            this.Keys.TableName = "Keys";
            // 
            // Key
            // 
            this.Key.ColumnName = "Key";
            // 
            // dcKeyCode
            // 
            this.dcKeyCode.ColumnName = "KeyCode";
            // 
            // KeyBind
            // 
            this.KeyBind.Columns.AddRange(new System.Data.DataColumn[] {
            this.dcGroup,
            this.dcLabel,
            this.dcCommand,
            this.dcKey,
            this.LabelToken});
            this.KeyBind.TableName = "KeyBind";
            // 
            // dcGroup
            // 
            this.dcGroup.ColumnName = "Group";
            // 
            // dcLabel
            // 
            this.dcLabel.ColumnName = "Label";
            // 
            // dcCommand
            // 
            this.dcCommand.ColumnName = "Command";
            // 
            // dcKey
            // 
            this.dcKey.Caption = "Key";
            this.dcKey.ColumnName = "Key";
            // 
            // colLabel
            // 
            this.colLabel.DataPropertyName = "Label";
            this.colLabel.HeaderText = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.Width = 250;
            // 
            // colCommand
            // 
            this.colCommand.DataPropertyName = "Command";
            this.colCommand.HeaderText = "Command";
            this.colCommand.Name = "colCommand";
            this.colCommand.Width = 200;
            // 
            // colKey
            // 
            this.colKey.DataPropertyName = "Key";
            this.colKey.DataSource = this.KeyLookups;
            this.colKey.DisplayMember = "Keys.Key";
            this.colKey.HeaderText = "Key";
            this.colKey.Name = "colKey";
            this.colKey.ValueMember = "Keys.KeyCode";
            this.colKey.Width = 120;
            // 
            // KeyBindControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KeyGrid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "KeyBindControl";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Size = new System.Drawing.Size(672, 129);
            ((System.ComponentModel.ISupportInitialize)(this.KeyGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyLookups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Keys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyBind)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.DataGridView KeyGrid;
        internal System.Data.DataSet KeyLookups;
        internal System.Data.DataTable Group;
        internal System.Data.DataColumn Token;
        internal System.Data.DataColumn TextColumn;
        internal System.Data.DataTable Keys;
        internal System.Data.DataColumn Key;
        internal System.Data.DataTable KeyBind;
        internal System.Data.DataColumn dcGroup;
        internal System.Data.DataColumn dcLabel;
        internal System.Data.DataColumn dcCommand;
        internal System.Data.DataColumn dcKey;
        internal System.Data.DataColumn dcKeyCode;
        internal System.Windows.Forms.DataGridViewComboBoxColumn colGroup;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colLabel;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colCommand;

        internal System.Windows.Forms.DataGridViewComboBoxColumn colKey;
        private System.Data.DataColumn LabelToken;
    }

}