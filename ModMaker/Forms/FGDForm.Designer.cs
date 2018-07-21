namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class FGDForm : System.Windows.Forms.Form
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboInclude = new System.Windows.Forms.ToolStripComboBox();
            this.EntiiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewEnt = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEntDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEntBases = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEntSolids = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEntPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.cboEntList = new System.Windows.Forms.ToolStripComboBox();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewChoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewFlag = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewInput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewWidget = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitComments = new System.Windows.Forms.SplitContainer();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.EntityTabs = new System.Windows.Forms.TabControl();
            this.TabProperties = new System.Windows.Forms.TabPage();
            this.pnlPropertyList = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabFlags = new System.Windows.Forms.TabPage();
            this.pnlFlagList = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.TabInputs = new System.Windows.Forms.TabPage();
            this.pnlInputList = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.TabOutput = new System.Windows.Forms.TabPage();
            this.pnlOutputList = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.TabWidgets = new System.Windows.Forms.TabPage();
            this.pnlWidgetList = new System.Windows.Forms.Panel();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.TabPreview = new System.Windows.Forms.TabPage();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitComments)).BeginInit();
            this.SplitComments.Panel1.SuspendLayout();
            this.SplitComments.Panel2.SuspendLayout();
            this.SplitComments.SuspendLayout();
            this.EntityTabs.SuspendLayout();
            this.TabProperties.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TabFlags.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.TabInputs.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.TabOutput.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.TabWidgets.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.TabPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ImportsToolStripMenuItem,
            this.EntiiesToolStripMenuItem,
            this.cboEntList,
            this.mnuEdit,
            this.mnuHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(585, 27);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuLoad,
            this.mnuSave,
            this.mnuFileSaveAs,
            this.ToolStripMenuItem1,
            this.mnuFileExport,
            this.ToolStripMenuItem3,
            this.mnuExit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(164, 22);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // mnuLoad
            // 
            this.mnuLoad.Name = "mnuLoad";
            this.mnuLoad.Size = new System.Drawing.Size(164, 22);
            this.mnuLoad.Text = "&Load";
            this.mnuLoad.Click += new System.EventHandler(this.mnuLoad_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(164, 22);
            this.mnuSave.Text = "&Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(164, 22);
            this.mnuFileSaveAs.Text = "Save &As";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuFileExport
            // 
            this.mnuFileExport.Name = "mnuFileExport";
            this.mnuFileExport.Size = new System.Drawing.Size(164, 22);
            this.mnuFileExport.Text = "Script &C++ Entity";
            this.mnuFileExport.Click += new System.EventHandler(this.mnuFileExport_Click);
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(164, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // ImportsToolStripMenuItem
            // 
            this.ImportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboInclude});
            this.ImportsToolStripMenuItem.Name = "ImportsToolStripMenuItem";
            this.ImportsToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.ImportsToolStripMenuItem.Text = "&Include";
            // 
            // cboInclude
            // 
            this.cboInclude.Name = "cboInclude";
            this.cboInclude.Size = new System.Drawing.Size(121, 23);
            this.cboInclude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboImports_KeyDown);
            // 
            // EntiiesToolStripMenuItem
            // 
            this.EntiiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewEnt,
            this.ToolStripMenuItem2,
            this.mnuEntDelete,
            this.ToolStripMenuItem4,
            this.mnuEntBases,
            this.mnuEntSolids,
            this.mnuEntPoints});
            this.EntiiesToolStripMenuItem.Name = "EntiiesToolStripMenuItem";
            this.EntiiesToolStripMenuItem.Size = new System.Drawing.Size(57, 23);
            this.EntiiesToolStripMenuItem.Text = "&Entities";
            this.EntiiesToolStripMenuItem.Click += new System.EventHandler(this.mnuEntBases_Click);
            // 
            // mnuNewEnt
            // 
            this.mnuNewEnt.Name = "mnuNewEnt";
            this.mnuNewEnt.Size = new System.Drawing.Size(107, 22);
            this.mnuNewEnt.Text = "&New";
            this.mnuNewEnt.Click += new System.EventHandler(this.mnuNewEnt_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(104, 6);
            // 
            // mnuEntDelete
            // 
            this.mnuEntDelete.Name = "mnuEntDelete";
            this.mnuEntDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuEntDelete.Text = "&Delete";
            this.mnuEntDelete.Click += new System.EventHandler(this.mnuEntDelete_Click);
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(104, 6);
            // 
            // mnuEntBases
            // 
            this.mnuEntBases.Checked = true;
            this.mnuEntBases.CheckOnClick = true;
            this.mnuEntBases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEntBases.Name = "mnuEntBases";
            this.mnuEntBases.Size = new System.Drawing.Size(107, 22);
            this.mnuEntBases.Text = "&Bases";
            // 
            // mnuEntSolids
            // 
            this.mnuEntSolids.CheckOnClick = true;
            this.mnuEntSolids.Name = "mnuEntSolids";
            this.mnuEntSolids.Size = new System.Drawing.Size(107, 22);
            this.mnuEntSolids.Text = "&Solids";
            this.mnuEntSolids.Click += new System.EventHandler(this.mnuEntBases_Click);
            // 
            // mnuEntPoints
            // 
            this.mnuEntPoints.CheckOnClick = true;
            this.mnuEntPoints.Name = "mnuEntPoints";
            this.mnuEntPoints.Size = new System.Drawing.Size(107, 22);
            this.mnuEntPoints.Text = "&Points";
            this.mnuEntPoints.Click += new System.EventHandler(this.mnuEntBases_Click);
            // 
            // cboEntList
            // 
            this.cboEntList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntList.Name = "cboEntList";
            this.cboEntList.Size = new System.Drawing.Size(200, 23);
            this.cboEntList.Sorted = true;
            this.cboEntList.SelectedIndexChanged += new System.EventHandler(this.cboEntList_SelectedIndexChanged);
            this.cboEntList.Click += new System.EventHandler(this.cboEntList_SelectedIndexChanged);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewProperty,
            this.mnuNewChoice,
            this.mnuNewFlag,
            this.mnuNewInput,
            this.mnuNewOutput,
            this.mnuNewWidget});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(41, 23);
            this.mnuEdit.Text = "&Add";
            // 
            // mnuNewProperty
            // 
            this.mnuNewProperty.Name = "mnuNewProperty";
            this.mnuNewProperty.Size = new System.Drawing.Size(119, 22);
            this.mnuNewProperty.Text = "&Property";
            this.mnuNewProperty.Click += new System.EventHandler(this.mnuNewProperty_Click);
            // 
            // mnuNewChoice
            // 
            this.mnuNewChoice.Name = "mnuNewChoice";
            this.mnuNewChoice.Size = new System.Drawing.Size(119, 22);
            this.mnuNewChoice.Text = "&Choice";
            this.mnuNewChoice.Click += new System.EventHandler(this.mnuNewChoice_Click);
            // 
            // mnuNewFlag
            // 
            this.mnuNewFlag.Name = "mnuNewFlag";
            this.mnuNewFlag.Size = new System.Drawing.Size(119, 22);
            this.mnuNewFlag.Text = "&Flag";
            this.mnuNewFlag.Click += new System.EventHandler(this.mnuNewFlag_Click);
            // 
            // mnuNewInput
            // 
            this.mnuNewInput.Name = "mnuNewInput";
            this.mnuNewInput.Size = new System.Drawing.Size(119, 22);
            this.mnuNewInput.Text = "&Input";
            this.mnuNewInput.Click += new System.EventHandler(this.mnuNewInput_Click);
            // 
            // mnuNewOutput
            // 
            this.mnuNewOutput.Name = "mnuNewOutput";
            this.mnuNewOutput.Size = new System.Drawing.Size(119, 22);
            this.mnuNewOutput.Text = "&Output";
            this.mnuNewOutput.Click += new System.EventHandler(this.mnuNewOutput_Click);
            // 
            // mnuNewWidget
            // 
            this.mnuNewWidget.Name = "mnuNewWidget";
            this.mnuNewWidget.Size = new System.Drawing.Size(119, 22);
            this.mnuNewWidget.Text = "&Widget";
            this.mnuNewWidget.Click += new System.EventHandler(this.mnuNewWidget_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 23);
            this.mnuHelp.Text = "&Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // SplitComments
            // 
            this.SplitComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitComments.Location = new System.Drawing.Point(0, 27);
            this.SplitComments.Name = "SplitComments";
            this.SplitComments.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitComments.Panel1
            // 
            this.SplitComments.Panel1.Controls.Add(this.txtComment);
            this.SplitComments.Panel1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            // 
            // SplitComments.Panel2
            // 
            this.SplitComments.Panel2.Controls.Add(this.EntityTabs);
            this.SplitComments.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.SplitComments.Size = new System.Drawing.Size(585, 348);
            this.SplitComments.SplitterDistance = 29;
            this.SplitComments.TabIndex = 4;
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Location = new System.Drawing.Point(6, 6);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(573, 23);
            this.txtComment.TabIndex = 4;
            // 
            // EntityTabs
            // 
            this.EntityTabs.Controls.Add(this.TabProperties);
            this.EntityTabs.Controls.Add(this.TabFlags);
            this.EntityTabs.Controls.Add(this.TabInputs);
            this.EntityTabs.Controls.Add(this.TabOutput);
            this.EntityTabs.Controls.Add(this.TabWidgets);
            this.EntityTabs.Controls.Add(this.TabPreview);
            this.EntityTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntityTabs.Location = new System.Drawing.Point(6, 0);
            this.EntityTabs.Name = "EntityTabs";
            this.EntityTabs.SelectedIndex = 0;
            this.EntityTabs.Size = new System.Drawing.Size(573, 309);
            this.EntityTabs.TabIndex = 3;
            this.EntityTabs.SelectedIndexChanged += new System.EventHandler(this.EntityTabs_SelectedIndexChanged);
            // 
            // TabProperties
            // 
            this.TabProperties.Controls.Add(this.pnlPropertyList);
            this.TabProperties.Controls.Add(this.Panel1);
            this.TabProperties.Location = new System.Drawing.Point(4, 22);
            this.TabProperties.Name = "TabProperties";
            this.TabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.TabProperties.Size = new System.Drawing.Size(565, 283);
            this.TabProperties.TabIndex = 0;
            this.TabProperties.Text = "Properties";
            this.TabProperties.UseVisualStyleBackColor = true;
            // 
            // pnlPropertyList
            // 
            this.pnlPropertyList.AutoScroll = true;
            this.pnlPropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPropertyList.Location = new System.Drawing.Point(3, 19);
            this.pnlPropertyList.Name = "pnlPropertyList";
            this.pnlPropertyList.Size = new System.Drawing.Size(559, 261);
            this.pnlPropertyList.TabIndex = 1;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(559, 16);
            this.Panel1.TabIndex = 0;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(150, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Label";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(450, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Default";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(350, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "DataType";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(35, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Name";
            // 
            // TabFlags
            // 
            this.TabFlags.Controls.Add(this.pnlFlagList);
            this.TabFlags.Controls.Add(this.Panel2);
            this.TabFlags.Location = new System.Drawing.Point(4, 22);
            this.TabFlags.Name = "TabFlags";
            this.TabFlags.Padding = new System.Windows.Forms.Padding(3);
            this.TabFlags.Size = new System.Drawing.Size(565, 283);
            this.TabFlags.TabIndex = 1;
            this.TabFlags.Text = "Flags";
            this.TabFlags.UseVisualStyleBackColor = true;
            // 
            // pnlFlagList
            // 
            this.pnlFlagList.AutoScroll = true;
            this.pnlFlagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFlagList.Location = new System.Drawing.Point(3, 19);
            this.pnlFlagList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFlagList.Name = "pnlFlagList";
            this.pnlFlagList.Size = new System.Drawing.Size(559, 261);
            this.pnlFlagList.TabIndex = 2;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.Label5);
            this.Panel2.Controls.Add(this.Label7);
            this.Panel2.Controls.Add(this.Label8);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(3, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(559, 16);
            this.Panel2.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(60, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(61, 13);
            this.Label5.TabIndex = 3;
            this.Label5.Text = "Is Default ?";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(120, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(33, 13);
            this.Label7.TabIndex = 1;
            this.Label7.Text = "Label";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(3, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(34, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Value";
            // 
            // TabInputs
            // 
            this.TabInputs.Controls.Add(this.pnlInputList);
            this.TabInputs.Controls.Add(this.Panel3);
            this.TabInputs.Location = new System.Drawing.Point(4, 22);
            this.TabInputs.Name = "TabInputs";
            this.TabInputs.Size = new System.Drawing.Size(565, 283);
            this.TabInputs.TabIndex = 2;
            this.TabInputs.Text = "Inputs";
            this.TabInputs.UseVisualStyleBackColor = true;
            // 
            // pnlInputList
            // 
            this.pnlInputList.AutoScroll = true;
            this.pnlInputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputList.Location = new System.Drawing.Point(0, 16);
            this.pnlInputList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlInputList.Name = "pnlInputList";
            this.pnlInputList.Size = new System.Drawing.Size(565, 267);
            this.pnlInputList.TabIndex = 3;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.Label6);
            this.Panel3.Controls.Add(this.Label9);
            this.Panel3.Controls.Add(this.Label10);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(565, 16);
            this.Panel3.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(112, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 13);
            this.Label6.TabIndex = 3;
            this.Label6.Text = "Data Type";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(214, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(33, 13);
            this.Label9.TabIndex = 1;
            this.Label9.Text = "Label";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(3, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(35, 13);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "Name";
            // 
            // TabOutput
            // 
            this.TabOutput.Controls.Add(this.pnlOutputList);
            this.TabOutput.Controls.Add(this.Panel4);
            this.TabOutput.Location = new System.Drawing.Point(4, 22);
            this.TabOutput.Name = "TabOutput";
            this.TabOutput.Size = new System.Drawing.Size(565, 283);
            this.TabOutput.TabIndex = 3;
            this.TabOutput.Text = "Outputs";
            this.TabOutput.UseVisualStyleBackColor = true;
            // 
            // pnlOutputList
            // 
            this.pnlOutputList.AutoScroll = true;
            this.pnlOutputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOutputList.Location = new System.Drawing.Point(0, 16);
            this.pnlOutputList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOutputList.Name = "pnlOutputList";
            this.pnlOutputList.Size = new System.Drawing.Size(565, 267);
            this.pnlOutputList.TabIndex = 4;
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.Label11);
            this.Panel4.Controls.Add(this.Label12);
            this.Panel4.Controls.Add(this.Label13);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(565, 16);
            this.Panel4.TabIndex = 3;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(112, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(57, 13);
            this.Label11.TabIndex = 3;
            this.Label11.Text = "Data Type";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(214, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 13);
            this.Label12.TabIndex = 1;
            this.Label12.Text = "Label";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(3, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(35, 13);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "Name";
            // 
            // TabWidgets
            // 
            this.TabWidgets.Controls.Add(this.pnlWidgetList);
            this.TabWidgets.Controls.Add(this.Panel5);
            this.TabWidgets.Location = new System.Drawing.Point(4, 22);
            this.TabWidgets.Margin = new System.Windows.Forms.Padding(2);
            this.TabWidgets.Name = "TabWidgets";
            this.TabWidgets.Padding = new System.Windows.Forms.Padding(2);
            this.TabWidgets.Size = new System.Drawing.Size(565, 283);
            this.TabWidgets.TabIndex = 5;
            this.TabWidgets.Text = "Widgets";
            this.TabWidgets.UseVisualStyleBackColor = true;
            // 
            // pnlWidgetList
            // 
            this.pnlWidgetList.AutoScroll = true;
            this.pnlWidgetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWidgetList.Location = new System.Drawing.Point(2, 23);
            this.pnlWidgetList.Margin = new System.Windows.Forms.Padding(2);
            this.pnlWidgetList.Name = "pnlWidgetList";
            this.pnlWidgetList.Size = new System.Drawing.Size(561, 258);
            this.pnlWidgetList.TabIndex = 5;
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.Label16);
            this.Panel5.Controls.Add(this.Label15);
            this.Panel5.Controls.Add(this.Label14);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(2, 2);
            this.Panel5.Margin = new System.Windows.Forms.Padding(2);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(561, 21);
            this.Panel5.TabIndex = 0;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(225, 0);
            this.Label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(60, 13);
            this.Label16.TabIndex = 2;
            this.Label16.Text = "Parameters";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(150, 0);
            this.Label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(53, 13);
            this.Label15.TabIndex = 1;
            this.Label15.Text = "Seperator";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(0, 0);
            this.Label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(35, 13);
            this.Label14.TabIndex = 0;
            this.Label14.Text = "Name";
            // 
            // TabPreview
            // 
            this.TabPreview.Controls.Add(this.txtPreview);
            this.TabPreview.Location = new System.Drawing.Point(4, 22);
            this.TabPreview.Name = "TabPreview";
            this.TabPreview.Padding = new System.Windows.Forms.Padding(3);
            this.TabPreview.Size = new System.Drawing.Size(565, 283);
            this.TabPreview.TabIndex = 4;
            this.TabPreview.Text = "Code";
            this.TabPreview.UseVisualStyleBackColor = true;
            // 
            // txtPreview
            // 
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreview.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreview.Location = new System.Drawing.Point(3, 3);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPreview.Size = new System.Drawing.Size(559, 277);
            this.txtPreview.TabIndex = 0;
            // 
            // FGDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 375);
            this.Controls.Add(this.SplitComments);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.Name = "FGDForm";
            this.Text = "Forge Game Data - Mod Maker";
            this.Load += new System.EventHandler(this.frmFGD_Load);
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.SplitComments.Panel1.ResumeLayout(false);
            this.SplitComments.Panel1.PerformLayout();
            this.SplitComments.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitComments)).EndInit();
            this.SplitComments.ResumeLayout(false);
            this.EntityTabs.ResumeLayout(false);
            this.TabProperties.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.TabFlags.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.TabInputs.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.TabOutput.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.TabWidgets.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.TabPreview.ResumeLayout(false);
            this.TabPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        internal System.Windows.Forms.ToolStripMenuItem mnuLoad;
        internal System.Windows.Forms.ToolStripMenuItem mnuSave;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ToolStripMenuItem EntiiesToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewEnt;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem2;
        internal System.Windows.Forms.ToolStripMenuItem mnuEntBases;
        internal System.Windows.Forms.ToolStripMenuItem mnuEntSolids;
        internal System.Windows.Forms.ToolStripMenuItem mnuEntPoints;
        internal System.Windows.Forms.ToolStripComboBox cboEntList;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        internal System.Windows.Forms.SplitContainer SplitComments;
        internal System.Windows.Forms.TextBox txtComment;
        internal System.Windows.Forms.TabControl EntityTabs;
        internal System.Windows.Forms.TabPage TabProperties;
        internal System.Windows.Forms.TabPage TabFlags;
        internal System.Windows.Forms.TabPage TabInputs;
        internal System.Windows.Forms.TabPage TabOutput;
        internal System.Windows.Forms.TabPage TabPreview;
        internal System.Windows.Forms.TextBox txtPreview;
        internal System.Windows.Forms.Panel pnlPropertyList;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ToolStripMenuItem mnuEdit;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewProperty;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewChoice;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewFlag;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewInput;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewOutput;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Panel pnlFlagList;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Panel pnlInputList;
        internal System.Windows.Forms.Panel pnlOutputList;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileExport;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem3;
        internal System.Windows.Forms.TabPage TabWidgets;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.ToolStripMenuItem mnuNewWidget;
        internal System.Windows.Forms.Panel pnlWidgetList;
        internal System.Windows.Forms.ToolStripMenuItem mnuEntDelete;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem4;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
        internal System.Windows.Forms.ToolStripMenuItem ImportsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripComboBox cboInclude;
    }

}