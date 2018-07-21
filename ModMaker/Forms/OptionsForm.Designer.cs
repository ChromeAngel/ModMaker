
namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class OptionsForm : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
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
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.CompilerGrid = new System.Windows.Forms.DataGridView();
            this.ExtensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogwindowDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridData = new System.Data.DataSet();
            this.FileType = new System.Data.DataTable();
            this.DataColumn1 = new System.Data.DataColumn();
            this.DataColumn2 = new System.Data.DataColumn();
            this.DataColumn3 = new System.Data.DataColumn();
            this.logwindow = new System.Data.DataColumn();
            this.Apps = new System.Data.DataTable();
            this.DataColumn4 = new System.Data.DataColumn();
            this.DataColumn5 = new System.Data.DataColumn();
            this.DataColumn6 = new System.Data.DataColumn();
            this.DataColumn7 = new System.Data.DataColumn();
            this.DataColumn8 = new System.Data.DataColumn();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.AppGrid = new System.Windows.Forms.DataGridView();
            this.AppIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameexeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SdkversionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowLayoutPanel1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompilerGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Apps)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 275);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(586, 30);
            this.FlowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(508, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(427, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(586, 275);
            this.TabControl1.TabIndex = 1;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.CompilerGrid);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(578, 249);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Compilers";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // CompilerGrid
            // 
            this.CompilerGrid.AutoGenerateColumns = false;
            this.CompilerGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.CompilerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompilerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExtensionDataGridViewTextBoxColumn,
            this.FilterDataGridViewTextBoxColumn,
            this.CommandDataGridViewTextBoxColumn,
            this.LogwindowDataGridViewCheckBoxColumn});
            this.CompilerGrid.DataMember = "FileType";
            this.CompilerGrid.DataSource = this.GridData;
            this.CompilerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompilerGrid.Location = new System.Drawing.Point(3, 3);
            this.CompilerGrid.Name = "CompilerGrid";
            this.CompilerGrid.Size = new System.Drawing.Size(572, 243);
            this.CompilerGrid.TabIndex = 0;
            // 
            // ExtensionDataGridViewTextBoxColumn
            // 
            this.ExtensionDataGridViewTextBoxColumn.DataPropertyName = "extension";
            this.ExtensionDataGridViewTextBoxColumn.HeaderText = "extension";
            this.ExtensionDataGridViewTextBoxColumn.Name = "ExtensionDataGridViewTextBoxColumn";
            this.ExtensionDataGridViewTextBoxColumn.Width = 77;
            // 
            // FilterDataGridViewTextBoxColumn
            // 
            this.FilterDataGridViewTextBoxColumn.DataPropertyName = "filter";
            this.FilterDataGridViewTextBoxColumn.HeaderText = "filter";
            this.FilterDataGridViewTextBoxColumn.Name = "FilterDataGridViewTextBoxColumn";
            this.FilterDataGridViewTextBoxColumn.Width = 51;
            // 
            // CommandDataGridViewTextBoxColumn
            // 
            this.CommandDataGridViewTextBoxColumn.DataPropertyName = "command";
            this.CommandDataGridViewTextBoxColumn.HeaderText = "command";
            this.CommandDataGridViewTextBoxColumn.Name = "CommandDataGridViewTextBoxColumn";
            this.CommandDataGridViewTextBoxColumn.Width = 78;
            // 
            // LogwindowDataGridViewCheckBoxColumn
            // 
            this.LogwindowDataGridViewCheckBoxColumn.DataPropertyName = "logwindow";
            this.LogwindowDataGridViewCheckBoxColumn.HeaderText = "logwindow";
            this.LogwindowDataGridViewCheckBoxColumn.Name = "LogwindowDataGridViewCheckBoxColumn";
            this.LogwindowDataGridViewCheckBoxColumn.Width = 63;
            // 
            // GridData
            // 
            this.GridData.DataSetName = "NewDataSet";
            this.GridData.Tables.AddRange(new System.Data.DataTable[] {
            this.FileType,
            this.Apps});
            // 
            // FileType
            // 
            this.FileType.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumn1,
            this.DataColumn2,
            this.DataColumn3,
            this.logwindow});
            this.FileType.TableName = "FileType";
            // 
            // DataColumn1
            // 
            this.DataColumn1.AllowDBNull = false;
            this.DataColumn1.ColumnName = "extension";
            // 
            // DataColumn2
            // 
            this.DataColumn2.AllowDBNull = false;
            this.DataColumn2.ColumnName = "filter";
            // 
            // DataColumn3
            // 
            this.DataColumn3.AllowDBNull = false;
            this.DataColumn3.ColumnName = "command";
            // 
            // logwindow
            // 
            this.logwindow.Caption = "log window";
            this.logwindow.ColumnName = "logwindow";
            this.logwindow.DataType = typeof(bool);
            // 
            // Apps
            // 
            this.Apps.Columns.AddRange(new System.Data.DataColumn[] {
            this.DataColumn4,
            this.DataColumn5,
            this.DataColumn6,
            this.DataColumn7,
            this.DataColumn8});
            this.Apps.TableName = "Apps";
            // 
            // DataColumn4
            // 
            this.DataColumn4.AllowDBNull = false;
            this.DataColumn4.ColumnName = "AppId";
            this.DataColumn4.DataType = typeof(int);
            // 
            // DataColumn5
            // 
            this.DataColumn5.AllowDBNull = false;
            this.DataColumn5.ColumnName = "engine";
            // 
            // DataColumn6
            // 
            this.DataColumn6.AllowDBNull = false;
            this.DataColumn6.ColumnName = "game";
            // 
            // DataColumn7
            // 
            this.DataColumn7.ColumnName = "gameexe";
            // 
            // DataColumn8
            // 
            this.DataColumn8.ColumnName = "sdkversion";
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.AppGrid);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(578, 249);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Apps";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // AppGrid
            // 
            this.AppGrid.AutoGenerateColumns = false;
            this.AppGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.AppGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppIdDataGridViewTextBoxColumn,
            this.EngineDataGridViewTextBoxColumn,
            this.GameDataGridViewTextBoxColumn,
            this.GameexeDataGridViewTextBoxColumn,
            this.SdkversionDataGridViewTextBoxColumn});
            this.AppGrid.DataMember = "Apps";
            this.AppGrid.DataSource = this.GridData;
            this.AppGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppGrid.Location = new System.Drawing.Point(3, 3);
            this.AppGrid.Name = "AppGrid";
            this.AppGrid.Size = new System.Drawing.Size(572, 243);
            this.AppGrid.TabIndex = 0;
            // 
            // AppIdDataGridViewTextBoxColumn
            // 
            this.AppIdDataGridViewTextBoxColumn.DataPropertyName = "AppId";
            this.AppIdDataGridViewTextBoxColumn.FillWeight = 5F;
            this.AppIdDataGridViewTextBoxColumn.HeaderText = "AppId";
            this.AppIdDataGridViewTextBoxColumn.Name = "AppIdDataGridViewTextBoxColumn";
            this.AppIdDataGridViewTextBoxColumn.Width = 60;
            // 
            // EngineDataGridViewTextBoxColumn
            // 
            this.EngineDataGridViewTextBoxColumn.DataPropertyName = "engine";
            this.EngineDataGridViewTextBoxColumn.HeaderText = "engine";
            this.EngineDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.EngineDataGridViewTextBoxColumn.Name = "EngineDataGridViewTextBoxColumn";
            this.EngineDataGridViewTextBoxColumn.Width = 64;
            // 
            // GameDataGridViewTextBoxColumn
            // 
            this.GameDataGridViewTextBoxColumn.DataPropertyName = "game";
            this.GameDataGridViewTextBoxColumn.HeaderText = "game";
            this.GameDataGridViewTextBoxColumn.MinimumWidth = 40;
            this.GameDataGridViewTextBoxColumn.Name = "GameDataGridViewTextBoxColumn";
            this.GameDataGridViewTextBoxColumn.Width = 58;
            // 
            // GameexeDataGridViewTextBoxColumn
            // 
            this.GameexeDataGridViewTextBoxColumn.DataPropertyName = "gameexe";
            this.GameexeDataGridViewTextBoxColumn.HeaderText = "gameexe";
            this.GameexeDataGridViewTextBoxColumn.MinimumWidth = 40;
            this.GameexeDataGridViewTextBoxColumn.Name = "GameexeDataGridViewTextBoxColumn";
            this.GameexeDataGridViewTextBoxColumn.Width = 75;
            // 
            // SdkversionDataGridViewTextBoxColumn
            // 
            this.SdkversionDataGridViewTextBoxColumn.DataPropertyName = "sdkversion";
            this.SdkversionDataGridViewTextBoxColumn.FillWeight = 5F;
            this.SdkversionDataGridViewTextBoxColumn.HeaderText = "sdkversion";
            this.SdkversionDataGridViewTextBoxColumn.Name = "SdkversionDataGridViewTextBoxColumn";
            this.SdkversionDataGridViewTextBoxColumn.Width = 83;
            // 
            // frmOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(586, 305);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Maker Options";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompilerGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Apps)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppGrid)).EndInit();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.DataGridView CompilerGrid;
        internal System.Windows.Forms.DataGridView AppGrid;
        internal System.Data.DataSet GridData;
        internal System.Data.DataTable FileType;
        internal System.Data.DataColumn DataColumn1;
        internal System.Data.DataColumn DataColumn2;
        internal System.Data.DataColumn DataColumn3;
        internal System.Data.DataTable Apps;
        internal System.Data.DataColumn DataColumn4;
        internal System.Data.DataColumn DataColumn5;
        internal System.Data.DataColumn DataColumn6;
        internal System.Data.DataColumn DataColumn7;
        internal System.Data.DataColumn DataColumn8;
        internal System.Windows.Forms.DataGridViewTextBoxColumn AppIdDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn EngineDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GameDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn GameexeDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn SdkversionDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn ExtensionDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn FilterDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewTextBoxColumn CommandDataGridViewTextBoxColumn;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn LogwindowDataGridViewCheckBoxColumn;
        internal System.Data.DataColumn logwindow;
    }

}