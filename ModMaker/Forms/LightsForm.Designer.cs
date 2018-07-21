namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class LightsForm : System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewShadows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewModels = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitMaterials = new System.Windows.Forms.SplitContainer();
            this.ListLights = new System.Windows.Forms.ListView();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtNewLight = new System.Windows.Forms.TextBox();
            this.btnNewLight = new System.Windows.Forms.Button();
            this.txtHDR_Intensity = new System.Windows.Forms.TextBox();
            this.txtLDR_Intensity = new System.Windows.Forms.TextBox();
            this.txtLightMaterial = new System.Windows.Forms.TextBox();
            this.radLightHDR = new System.Windows.Forms.RadioButton();
            this.radLightLDR = new System.Windows.Forms.RadioButton();
            this.radLightBoth = new System.Windows.Forms.RadioButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlHDRColor = new System.Windows.Forms.Panel();
            this.pnlLDRColor = new System.Windows.Forms.Panel();
            this.SplitNoShadows = new System.Windows.Forms.SplitContainer();
            this.ListShadows = new System.Windows.Forms.ListView();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.txtNewShadow = new System.Windows.Forms.TextBox();
            this.btnNewShadow = new System.Windows.Forms.Button();
            this.txtShadowMaterial = new System.Windows.Forms.TextBox();
            this.radShadowHDR = new System.Windows.Forms.RadioButton();
            this.radShadowLDR = new System.Windows.Forms.RadioButton();
            this.radShadowBoth = new System.Windows.Forms.RadioButton();
            this.SplitModels = new System.Windows.Forms.SplitContainer();
            this.ListModels = new System.Windows.Forms.ListView();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.txtNewModel = new System.Windows.Forms.TextBox();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.radModelHDR = new System.Windows.Forms.RadioButton();
            this.radModelLDR = new System.Windows.Forms.RadioButton();
            this.radModelBoth = new System.Windows.Forms.RadioButton();
            this.ToolTipManager = new System.Windows.Forms.ToolTip(this.components);
            this.MenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitMaterials)).BeginInit();
            this.SplitMaterials.Panel1.SuspendLayout();
            this.SplitMaterials.Panel2.SuspendLayout();
            this.SplitMaterials.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitNoShadows)).BeginInit();
            this.SplitNoShadows.Panel1.SuspendLayout();
            this.SplitNoShadows.Panel2.SuspendLayout();
            this.SplitNoShadows.SuspendLayout();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitModels)).BeginInit();
            this.SplitModels.Panel1.SuspendLayout();
            this.SplitModels.Panel2.SuspendLayout();
            this.SplitModels.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.mnuHelp});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MenuStrip1.Size = new System.Drawing.Size(683, 28);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.LoadToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.mnuFileSaveAs,
            this.ToolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(181, 26);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.LoadToolStripMenuItem.Text = "&Load";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.SaveToolStripMenuItem.Text = "&Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(181, 26);
            this.mnuFileSaveAs.Text = "Save &As";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewLight,
            this.mnuViewShadows,
            this.mnuViewModels});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.ViewToolStripMenuItem.Text = "&View";
            // 
            // mnuViewLight
            // 
            this.mnuViewLight.Name = "mnuViewLight";
            this.mnuViewLight.Size = new System.Drawing.Size(247, 26);
            this.mnuViewLight.Text = "Light &Emiters";
            this.mnuViewLight.Click += new System.EventHandler(this.mnuViewLight_Click);
            // 
            // mnuViewShadows
            // 
            this.mnuViewShadows.Name = "mnuViewShadows";
            this.mnuViewShadows.Size = new System.Drawing.Size(247, 26);
            this.mnuViewShadows.Text = "Don\'t &Shadow";
            this.mnuViewShadows.Click += new System.EventHandler(this.mnuViewShadows_Click);
            // 
            // mnuViewModels
            // 
            this.mnuViewModels.Name = "mnuViewModels";
            this.mnuViewModels.Size = new System.Drawing.Size(247, 26);
            this.mnuViewModels.Text = "Shadow Casting &Models ";
            this.mnuViewModels.Click += new System.EventHandler(this.mnuViewModels_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelp.Size = new System.Drawing.Size(53, 24);
            this.mnuHelp.Text = "&Help";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // SplitMaterials
            // 
            this.SplitMaterials.Location = new System.Drawing.Point(0, 33);
            this.SplitMaterials.Margin = new System.Windows.Forms.Padding(4);
            this.SplitMaterials.Name = "SplitMaterials";
            // 
            // SplitMaterials.Panel1
            // 
            this.SplitMaterials.Panel1.Controls.Add(this.ListLights);
            this.SplitMaterials.Panel1.Controls.Add(this.Panel1);
            // 
            // SplitMaterials.Panel2
            // 
            this.SplitMaterials.Panel2.Controls.Add(this.txtHDR_Intensity);
            this.SplitMaterials.Panel2.Controls.Add(this.txtLDR_Intensity);
            this.SplitMaterials.Panel2.Controls.Add(this.txtLightMaterial);
            this.SplitMaterials.Panel2.Controls.Add(this.radLightHDR);
            this.SplitMaterials.Panel2.Controls.Add(this.radLightLDR);
            this.SplitMaterials.Panel2.Controls.Add(this.radLightBoth);
            this.SplitMaterials.Panel2.Controls.Add(this.Label2);
            this.SplitMaterials.Panel2.Controls.Add(this.Label1);
            this.SplitMaterials.Panel2.Controls.Add(this.pnlHDRColor);
            this.SplitMaterials.Panel2.Controls.Add(this.pnlLDRColor);
            this.SplitMaterials.Panel2.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SplitMaterials.Size = new System.Drawing.Size(683, 238);
            this.SplitMaterials.SplitterDistance = 226;
            this.SplitMaterials.SplitterWidth = 5;
            this.SplitMaterials.TabIndex = 1;
            this.SplitMaterials.TabStop = false;
            // 
            // ListLights
            // 
            this.ListLights.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListLights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListLights.FullRowSelect = true;
            this.ListLights.Location = new System.Drawing.Point(0, 27);
            this.ListLights.Margin = new System.Windows.Forms.Padding(4);
            this.ListLights.MultiSelect = false;
            this.ListLights.Name = "ListLights";
            this.ListLights.Size = new System.Drawing.Size(226, 211);
            this.ListLights.TabIndex = 1;
            this.ListLights.UseCompatibleStateImageBehavior = false;
            this.ListLights.View = System.Windows.Forms.View.List;
            this.ListLights.SelectedIndexChanged += new System.EventHandler(this.ListLights_SelectedIndexChanged);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.txtNewLight);
            this.Panel1.Controls.Add(this.btnNewLight);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(226, 27);
            this.Panel1.TabIndex = 0;
            // 
            // txtNewLight
            // 
            this.txtNewLight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNewLight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNewLight.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewLight.Location = new System.Drawing.Point(0, 0);
            this.txtNewLight.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewLight.Name = "txtNewLight";
            this.txtNewLight.Size = new System.Drawing.Size(191, 22);
            this.txtNewLight.TabIndex = 1;
            this.ToolTipManager.SetToolTip(this.txtNewLight, "New Material Name");
            // 
            // btnNewLight
            // 
            this.btnNewLight.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNewLight.Location = new System.Drawing.Point(191, 0);
            this.btnNewLight.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewLight.Name = "btnNewLight";
            this.btnNewLight.Size = new System.Drawing.Size(35, 27);
            this.btnNewLight.TabIndex = 0;
            this.btnNewLight.Text = "+";
            this.ToolTipManager.SetToolTip(this.btnNewLight, "Add new light emitting material");
            this.btnNewLight.UseVisualStyleBackColor = true;
            this.btnNewLight.Click += new System.EventHandler(this.btnNewLight_Click);
            // 
            // txtHDR_Intensity
            // 
            this.txtHDR_Intensity.Location = new System.Drawing.Point(149, 105);
            this.txtHDR_Intensity.Margin = new System.Windows.Forms.Padding(4);
            this.txtHDR_Intensity.Name = "txtHDR_Intensity";
            this.txtHDR_Intensity.Size = new System.Drawing.Size(132, 22);
            this.txtHDR_Intensity.TabIndex = 9;
            this.txtHDR_Intensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTipManager.SetToolTip(this.txtHDR_Intensity, "HDR Color intensity");
            // 
            // txtLDR_Intensity
            // 
            this.txtLDR_Intensity.Location = new System.Drawing.Point(149, 55);
            this.txtLDR_Intensity.Margin = new System.Windows.Forms.Padding(4);
            this.txtLDR_Intensity.Name = "txtLDR_Intensity";
            this.txtLDR_Intensity.Size = new System.Drawing.Size(132, 22);
            this.txtLDR_Intensity.TabIndex = 8;
            this.txtLDR_Intensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ToolTipManager.SetToolTip(this.txtLDR_Intensity, "LDR color intensity");
            // 
            // txtLightMaterial
            // 
            this.txtLightMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLightMaterial.Location = new System.Drawing.Point(16, 15);
            this.txtLightMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.txtLightMaterial.Name = "txtLightMaterial";
            this.txtLightMaterial.Size = new System.Drawing.Size(420, 22);
            this.txtLightMaterial.TabIndex = 7;
            this.ToolTipManager.SetToolTip(this.txtLightMaterial, "Material path (relative to the materials folder)");
            // 
            // radLightHDR
            // 
            this.radLightHDR.AutoSize = true;
            this.radLightHDR.Location = new System.Drawing.Point(16, 199);
            this.radLightHDR.Margin = new System.Windows.Forms.Padding(4);
            this.radLightHDR.Name = "radLightHDR";
            this.radLightHDR.Size = new System.Drawing.Size(92, 21);
            this.radLightHDR.TabIndex = 6;
            this.radLightHDR.TabStop = true;
            this.radLightHDR.Text = "HDR Only";
            this.radLightHDR.UseVisualStyleBackColor = true;
            // 
            // radLightLDR
            // 
            this.radLightLDR.AutoSize = true;
            this.radLightLDR.Location = new System.Drawing.Point(16, 171);
            this.radLightLDR.Margin = new System.Windows.Forms.Padding(4);
            this.radLightLDR.Name = "radLightLDR";
            this.radLightLDR.Size = new System.Drawing.Size(90, 21);
            this.radLightLDR.TabIndex = 5;
            this.radLightLDR.TabStop = true;
            this.radLightLDR.Text = "LDR Only";
            this.radLightLDR.UseVisualStyleBackColor = true;
            // 
            // radLightBoth
            // 
            this.radLightBoth.AutoSize = true;
            this.radLightBoth.Location = new System.Drawing.Point(16, 143);
            this.radLightBoth.Margin = new System.Windows.Forms.Padding(4);
            this.radLightBoth.Name = "radLightBoth";
            this.radLightBoth.Size = new System.Drawing.Size(119, 21);
            this.radLightBoth.TabIndex = 4;
            this.radLightBoth.TabStop = true;
            this.radLightBoth.Text = "HDR and LDR";
            this.radLightBoth.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(67, 106);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 17);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "HDR Color";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(68, 59);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 17);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "LDR Color";
            // 
            // pnlHDRColor
            // 
            this.pnlHDRColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHDRColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlHDRColor.Location = new System.Drawing.Point(16, 95);
            this.pnlHDRColor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHDRColor.Name = "pnlHDRColor";
            this.pnlHDRColor.Size = new System.Drawing.Size(41, 38);
            this.pnlHDRColor.TabIndex = 1;
            this.pnlHDRColor.TabStop = true;
            this.pnlHDRColor.Click += new System.EventHandler(this.pnlHDRColor_Click);
            // 
            // pnlLDRColor
            // 
            this.pnlLDRColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLDRColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLDRColor.Location = new System.Drawing.Point(16, 48);
            this.pnlLDRColor.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLDRColor.Name = "pnlLDRColor";
            this.pnlLDRColor.Size = new System.Drawing.Size(41, 38);
            this.pnlLDRColor.TabIndex = 0;
            this.pnlLDRColor.TabStop = true;
            this.pnlLDRColor.Click += new System.EventHandler(this.pnlLDRColor_Click);
            // 
            // SplitNoShadows
            // 
            this.SplitNoShadows.Location = new System.Drawing.Point(0, 278);
            this.SplitNoShadows.Margin = new System.Windows.Forms.Padding(4);
            this.SplitNoShadows.Name = "SplitNoShadows";
            // 
            // SplitNoShadows.Panel1
            // 
            this.SplitNoShadows.Panel1.Controls.Add(this.ListShadows);
            this.SplitNoShadows.Panel1.Controls.Add(this.Panel4);
            // 
            // SplitNoShadows.Panel2
            // 
            this.SplitNoShadows.Panel2.Controls.Add(this.txtShadowMaterial);
            this.SplitNoShadows.Panel2.Controls.Add(this.radShadowHDR);
            this.SplitNoShadows.Panel2.Controls.Add(this.radShadowLDR);
            this.SplitNoShadows.Panel2.Controls.Add(this.radShadowBoth);
            this.SplitNoShadows.Panel2.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SplitNoShadows.Size = new System.Drawing.Size(683, 145);
            this.SplitNoShadows.SplitterDistance = 226;
            this.SplitNoShadows.SplitterWidth = 5;
            this.SplitNoShadows.TabIndex = 2;
            this.SplitNoShadows.TabStop = false;
            // 
            // ListShadows
            // 
            this.ListShadows.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListShadows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListShadows.FullRowSelect = true;
            this.ListShadows.Location = new System.Drawing.Point(0, 27);
            this.ListShadows.Margin = new System.Windows.Forms.Padding(4);
            this.ListShadows.MultiSelect = false;
            this.ListShadows.Name = "ListShadows";
            this.ListShadows.Size = new System.Drawing.Size(226, 118);
            this.ListShadows.TabIndex = 1;
            this.ListShadows.UseCompatibleStateImageBehavior = false;
            this.ListShadows.View = System.Windows.Forms.View.List;
            this.ListShadows.SelectedIndexChanged += new System.EventHandler(this.ListShadows_SelectedIndexChanged);
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.txtNewShadow);
            this.Panel4.Controls.Add(this.btnNewShadow);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Margin = new System.Windows.Forms.Padding(4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(226, 27);
            this.Panel4.TabIndex = 0;
            // 
            // txtNewShadow
            // 
            this.txtNewShadow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNewShadow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNewShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewShadow.Location = new System.Drawing.Point(0, 0);
            this.txtNewShadow.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewShadow.Name = "txtNewShadow";
            this.txtNewShadow.Size = new System.Drawing.Size(191, 22);
            this.txtNewShadow.TabIndex = 1;
            this.ToolTipManager.SetToolTip(this.txtNewShadow, "New material");
            // 
            // btnNewShadow
            // 
            this.btnNewShadow.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNewShadow.Location = new System.Drawing.Point(191, 0);
            this.btnNewShadow.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewShadow.Name = "btnNewShadow";
            this.btnNewShadow.Size = new System.Drawing.Size(35, 27);
            this.btnNewShadow.TabIndex = 0;
            this.btnNewShadow.Text = "+";
            this.ToolTipManager.SetToolTip(this.btnNewShadow, "Add new material");
            this.btnNewShadow.UseVisualStyleBackColor = true;
            this.btnNewShadow.Click += new System.EventHandler(this.btnNewShadow_Click);
            // 
            // txtShadowMaterial
            // 
            this.txtShadowMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtShadowMaterial.Location = new System.Drawing.Point(16, 15);
            this.txtShadowMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.txtShadowMaterial.Name = "txtShadowMaterial";
            this.txtShadowMaterial.Size = new System.Drawing.Size(420, 22);
            this.txtShadowMaterial.TabIndex = 7;
            this.ToolTipManager.SetToolTip(this.txtShadowMaterial, "Material path (relative to the materials folder)");
            // 
            // radShadowHDR
            // 
            this.radShadowHDR.AutoSize = true;
            this.radShadowHDR.Location = new System.Drawing.Point(20, 103);
            this.radShadowHDR.Margin = new System.Windows.Forms.Padding(4);
            this.radShadowHDR.Name = "radShadowHDR";
            this.radShadowHDR.Size = new System.Drawing.Size(92, 21);
            this.radShadowHDR.TabIndex = 6;
            this.radShadowHDR.TabStop = true;
            this.radShadowHDR.Text = "HDR Only";
            this.radShadowHDR.UseVisualStyleBackColor = true;
            // 
            // radShadowLDR
            // 
            this.radShadowLDR.AutoSize = true;
            this.radShadowLDR.Location = new System.Drawing.Point(20, 75);
            this.radShadowLDR.Margin = new System.Windows.Forms.Padding(4);
            this.radShadowLDR.Name = "radShadowLDR";
            this.radShadowLDR.Size = new System.Drawing.Size(90, 21);
            this.radShadowLDR.TabIndex = 5;
            this.radShadowLDR.TabStop = true;
            this.radShadowLDR.Text = "LDR Only";
            this.radShadowLDR.UseVisualStyleBackColor = true;
            // 
            // radShadowBoth
            // 
            this.radShadowBoth.AutoSize = true;
            this.radShadowBoth.Location = new System.Drawing.Point(20, 47);
            this.radShadowBoth.Margin = new System.Windows.Forms.Padding(4);
            this.radShadowBoth.Name = "radShadowBoth";
            this.radShadowBoth.Size = new System.Drawing.Size(119, 21);
            this.radShadowBoth.TabIndex = 4;
            this.radShadowBoth.TabStop = true;
            this.radShadowBoth.Text = "HDR and LDR";
            this.radShadowBoth.UseVisualStyleBackColor = true;
            // 
            // SplitModels
            // 
            this.SplitModels.Location = new System.Drawing.Point(0, 431);
            this.SplitModels.Margin = new System.Windows.Forms.Padding(4);
            this.SplitModels.Name = "SplitModels";
            // 
            // SplitModels.Panel1
            // 
            this.SplitModels.Panel1.Controls.Add(this.ListModels);
            this.SplitModels.Panel1.Controls.Add(this.Panel5);
            // 
            // SplitModels.Panel2
            // 
            this.SplitModels.Panel2.Controls.Add(this.txtModel);
            this.SplitModels.Panel2.Controls.Add(this.radModelHDR);
            this.SplitModels.Panel2.Controls.Add(this.radModelLDR);
            this.SplitModels.Panel2.Controls.Add(this.radModelBoth);
            this.SplitModels.Panel2.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.SplitModels.Size = new System.Drawing.Size(683, 145);
            this.SplitModels.SplitterDistance = 226;
            this.SplitModels.SplitterWidth = 5;
            this.SplitModels.TabIndex = 3;
            this.SplitModels.TabStop = false;
            // 
            // ListModels
            // 
            this.ListModels.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListModels.FullRowSelect = true;
            this.ListModels.Location = new System.Drawing.Point(0, 27);
            this.ListModels.Margin = new System.Windows.Forms.Padding(4);
            this.ListModels.MultiSelect = false;
            this.ListModels.Name = "ListModels";
            this.ListModels.Size = new System.Drawing.Size(226, 118);
            this.ListModels.TabIndex = 1;
            this.ListModels.UseCompatibleStateImageBehavior = false;
            this.ListModels.View = System.Windows.Forms.View.List;
            this.ListModels.SelectedIndexChanged += new System.EventHandler(this.ListModels_SelectedIndexChanged);
            // 
            // Panel5
            // 
            this.Panel5.Controls.Add(this.txtNewModel);
            this.Panel5.Controls.Add(this.btnAddModel);
            this.Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel5.Location = new System.Drawing.Point(0, 0);
            this.Panel5.Margin = new System.Windows.Forms.Padding(4);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(226, 27);
            this.Panel5.TabIndex = 0;
            // 
            // txtNewModel
            // 
            this.txtNewModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNewModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNewModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewModel.Location = new System.Drawing.Point(0, 0);
            this.txtNewModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewModel.Name = "txtNewModel";
            this.txtNewModel.Size = new System.Drawing.Size(191, 22);
            this.txtNewModel.TabIndex = 1;
            this.ToolTipManager.SetToolTip(this.txtNewModel, "New model path");
            // 
            // btnAddModel
            // 
            this.btnAddModel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddModel.Location = new System.Drawing.Point(191, 0);
            this.btnAddModel.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(35, 27);
            this.btnAddModel.TabIndex = 0;
            this.btnAddModel.Text = "+";
            this.ToolTipManager.SetToolTip(this.btnAddModel, "Add new model");
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtModel.Location = new System.Drawing.Point(16, 15);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(420, 22);
            this.txtModel.TabIndex = 7;
            this.ToolTipManager.SetToolTip(this.txtModel, "Model path (relative to the models folder)");
            // 
            // radModelHDR
            // 
            this.radModelHDR.AutoSize = true;
            this.radModelHDR.Location = new System.Drawing.Point(16, 103);
            this.radModelHDR.Margin = new System.Windows.Forms.Padding(4);
            this.radModelHDR.Name = "radModelHDR";
            this.radModelHDR.Size = new System.Drawing.Size(92, 21);
            this.radModelHDR.TabIndex = 6;
            this.radModelHDR.TabStop = true;
            this.radModelHDR.Text = "HDR Only";
            this.radModelHDR.UseVisualStyleBackColor = true;
            // 
            // radModelLDR
            // 
            this.radModelLDR.AutoSize = true;
            this.radModelLDR.Location = new System.Drawing.Point(16, 75);
            this.radModelLDR.Margin = new System.Windows.Forms.Padding(4);
            this.radModelLDR.Name = "radModelLDR";
            this.radModelLDR.Size = new System.Drawing.Size(90, 21);
            this.radModelLDR.TabIndex = 5;
            this.radModelLDR.TabStop = true;
            this.radModelLDR.Text = "LDR Only";
            this.radModelLDR.UseVisualStyleBackColor = true;
            // 
            // radModelBoth
            // 
            this.radModelBoth.AutoSize = true;
            this.radModelBoth.Location = new System.Drawing.Point(16, 47);
            this.radModelBoth.Margin = new System.Windows.Forms.Padding(4);
            this.radModelBoth.Name = "radModelBoth";
            this.radModelBoth.Size = new System.Drawing.Size(119, 21);
            this.radModelBoth.TabIndex = 4;
            this.radModelBoth.TabStop = true;
            this.radModelBoth.Text = "HDR and LDR";
            this.radModelBoth.UseVisualStyleBackColor = true;
            // 
            // LightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 479);
            this.Controls.Add(this.SplitModels);
            this.Controls.Add(this.SplitNoShadows);
            this.Controls.Add(this.SplitMaterials);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LightsForm";
            this.Text = "Lights - Mod Maker";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.SplitMaterials.Panel1.ResumeLayout(false);
            this.SplitMaterials.Panel2.ResumeLayout(false);
            this.SplitMaterials.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitMaterials)).EndInit();
            this.SplitMaterials.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.SplitNoShadows.Panel1.ResumeLayout(false);
            this.SplitNoShadows.Panel2.ResumeLayout(false);
            this.SplitNoShadows.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitNoShadows)).EndInit();
            this.SplitNoShadows.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.SplitModels.Panel1.ResumeLayout(false);
            this.SplitModels.Panel2.ResumeLayout(false);
            this.SplitModels.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitModels)).EndInit();
            this.SplitModels.ResumeLayout(false);
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        internal System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewLight;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewShadows;
        internal System.Windows.Forms.ToolStripMenuItem mnuViewModels;
        internal System.Windows.Forms.SplitContainer SplitMaterials;
        internal System.Windows.Forms.ListView ListLights;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtNewLight;
        internal System.Windows.Forms.Button btnNewLight;
        internal System.Windows.Forms.TextBox txtLightMaterial;
        internal System.Windows.Forms.RadioButton radLightHDR;
        internal System.Windows.Forms.RadioButton radLightLDR;
        internal System.Windows.Forms.RadioButton radLightBoth;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel pnlHDRColor;
        internal System.Windows.Forms.Panel pnlLDRColor;
        internal System.Windows.Forms.SplitContainer SplitNoShadows;
        internal System.Windows.Forms.ListView ListShadows;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.TextBox txtNewShadow;
        internal System.Windows.Forms.Button btnNewShadow;
        internal System.Windows.Forms.TextBox txtShadowMaterial;
        internal System.Windows.Forms.RadioButton radShadowHDR;
        internal System.Windows.Forms.RadioButton radShadowLDR;
        internal System.Windows.Forms.RadioButton radShadowBoth;
        internal System.Windows.Forms.SplitContainer SplitModels;
        internal System.Windows.Forms.ListView ListModels;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.TextBox txtNewModel;
        internal System.Windows.Forms.Button btnAddModel;
        internal System.Windows.Forms.TextBox txtModel;
        internal System.Windows.Forms.RadioButton radModelHDR;
        internal System.Windows.Forms.RadioButton radModelLDR;
        internal System.Windows.Forms.RadioButton radModelBoth;
        internal System.Windows.Forms.TextBox txtHDR_Intensity;
        internal System.Windows.Forms.TextBox txtLDR_Intensity;
        internal System.Windows.Forms.ToolStripMenuItem mnuHelp;
        internal System.Windows.Forms.ToolTip ToolTipManager;
    }

}