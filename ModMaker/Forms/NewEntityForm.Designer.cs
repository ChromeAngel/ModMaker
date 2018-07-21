namespace ModMaker
{


    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class NewEntityForm : System.Windows.Forms.Form
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
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.radKeyFrame = new System.Windows.Forms.RadioButton();
            this.radMove = new System.Windows.Forms.RadioButton();
            this.radNPC = new System.Windows.Forms.RadioButton();
            this.radFilter = new System.Windows.Forms.RadioButton();
            this.txtDesk = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.radBase = new System.Windows.Forms.RadioButton();
            this.radSolid = new System.Windows.Forms.RadioButton();
            this.radPoint = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ListBases = new System.Windows.Forms.ListView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.txtDataDesc = new System.Windows.Forms.TextBox();
            this.TheToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.FlowLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 300);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(883, 36);
            this.FlowLayoutPanel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(779, 4);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(671, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.radKeyFrame);
            this.Panel1.Controls.Add(this.radMove);
            this.Panel1.Controls.Add(this.radNPC);
            this.Panel1.Controls.Add(this.radFilter);
            this.Panel1.Controls.Add(this.txtDesk);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.radBase);
            this.Panel1.Controls.Add(this.radSolid);
            this.Panel1.Controls.Add(this.radPoint);
            this.Panel1.Controls.Add(this.txtName);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.lblname);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(883, 97);
            this.Panel1.TabIndex = 1;
            // 
            // radKeyFrame
            // 
            this.radKeyFrame.AutoSize = true;
            this.radKeyFrame.Location = new System.Drawing.Point(503, 32);
            this.radKeyFrame.Margin = new System.Windows.Forms.Padding(4);
            this.radKeyFrame.Name = "radKeyFrame";
            this.radKeyFrame.Size = new System.Drawing.Size(97, 21);
            this.radKeyFrame.TabIndex = 11;
            this.radKeyFrame.TabStop = true;
            this.radKeyFrame.Text = "Key Frame";
            this.TheToolTip.SetToolTip(this.radKeyFrame, "Keyframe entity such as track or rope waypoints (listed as point entity)");
            this.radKeyFrame.UseVisualStyleBackColor = true;
            // 
            // radMove
            // 
            this.radMove.AutoSize = true;
            this.radMove.Location = new System.Drawing.Point(432, 32);
            this.radMove.Margin = new System.Windows.Forms.Padding(4);
            this.radMove.Name = "radMove";
            this.radMove.Size = new System.Drawing.Size(63, 21);
            this.radMove.TabIndex = 10;
            this.radMove.TabStop = true;
            this.radMove.Text = "Move";
            this.TheToolTip.SetToolTip(this.radMove, "Moveable??? (listed as a point entity)");
            this.radMove.UseVisualStyleBackColor = true;
            // 
            // radNPC
            // 
            this.radNPC.AutoSize = true;
            this.radNPC.Location = new System.Drawing.Point(367, 32);
            this.radNPC.Margin = new System.Windows.Forms.Padding(4);
            this.radNPC.Name = "radNPC";
            this.radNPC.Size = new System.Drawing.Size(57, 21);
            this.radNPC.TabIndex = 9;
            this.radNPC.TabStop = true;
            this.radNPC.Text = "NPC";
            this.TheToolTip.SetToolTip(this.radNPC, "NPC entities (listed as a point entity)");
            this.radNPC.UseVisualStyleBackColor = true;
            // 
            // radFilter
            // 
            this.radFilter.AutoSize = true;
            this.radFilter.Location = new System.Drawing.Point(299, 33);
            this.radFilter.Margin = new System.Windows.Forms.Padding(4);
            this.radFilter.Name = "radFilter";
            this.radFilter.Size = new System.Drawing.Size(60, 21);
            this.radFilter.TabIndex = 8;
            this.radFilter.TabStop = true;
            this.radFilter.Text = "Filter";
            this.TheToolTip.SetToolTip(this.radFilter, "Filters IO between other entities (listed as a point entity)");
            this.radFilter.UseVisualStyleBackColor = true;
            // 
            // txtDesk
            // 
            this.txtDesk.Location = new System.Drawing.Point(93, 62);
            this.txtDesk.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesk.Name = "txtDesk";
            this.txtDesk.Size = new System.Drawing.Size(772, 22);
            this.txtDesk.TabIndex = 7;
            this.TheToolTip.SetToolTip(this.txtDesk, "Description for mapper documentation");
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(5, 62);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(79, 17);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Description";
            // 
            // radBase
            // 
            this.radBase.AutoSize = true;
            this.radBase.Location = new System.Drawing.Point(93, 32);
            this.radBase.Margin = new System.Windows.Forms.Padding(4);
            this.radBase.Name = "radBase";
            this.radBase.Size = new System.Drawing.Size(61, 21);
            this.radBase.TabIndex = 5;
            this.radBase.TabStop = true;
            this.radBase.Text = "Base";
            this.TheToolTip.SetToolTip(this.radBase, "Base entites which other entities inherit from");
            this.radBase.UseVisualStyleBackColor = true;
            // 
            // radSolid
            // 
            this.radSolid.AutoSize = true;
            this.radSolid.Location = new System.Drawing.Point(162, 33);
            this.radSolid.Margin = new System.Windows.Forms.Padding(4);
            this.radSolid.Name = "radSolid";
            this.radSolid.Size = new System.Drawing.Size(60, 21);
            this.radSolid.TabIndex = 4;
            this.radSolid.TabStop = true;
            this.radSolid.Text = "Solid";
            this.TheToolTip.SetToolTip(this.radSolid, "Brush entities in hammer");
            this.radSolid.UseVisualStyleBackColor = true;
            // 
            // radPoint
            // 
            this.radPoint.AutoSize = true;
            this.radPoint.Location = new System.Drawing.Point(230, 33);
            this.radPoint.Margin = new System.Windows.Forms.Padding(4);
            this.radPoint.Name = "radPoint";
            this.radPoint.Size = new System.Drawing.Size(61, 21);
            this.radPoint.TabIndex = 3;
            this.radPoint.TabStop = true;
            this.radPoint.Text = "Point";
            this.TheToolTip.SetToolTip(this.radPoint, "Point entities such as Lights or Props");
            this.radPoint.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 5);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(308, 22);
            this.txtName.TabIndex = 2;
            this.TheToolTip.SetToolTip(this.txtName, "Name of the entity as it appears in Hammer (eg func_door).  Recommended that you " +
        "prefix it with the short name of your mod.");
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(44, 36);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 17);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Type";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(39, 9);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(45, 17);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Name";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 97);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(883, 203);
            this.TabControl1.TabIndex = 4;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ListBases);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(875, 174);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Base(s)";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // ListBases
            // 
            this.ListBases.CheckBoxes = true;
            this.ListBases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBases.Location = new System.Drawing.Point(3, 3);
            this.ListBases.Margin = new System.Windows.Forms.Padding(4);
            this.ListBases.Name = "ListBases";
            this.ListBases.Size = new System.Drawing.Size(869, 168);
            this.ListBases.TabIndex = 4;
            this.TheToolTip.SetToolTip(this.ListBases, "Check the base entities for  which you want this class to inherit");
            this.ListBases.UseCompatibleStateImageBehavior = false;
            this.ListBases.View = System.Windows.Forms.View.List;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.txtDataDesc);
            this.TabPage2.Location = new System.Drawing.Point(4, 25);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(875, 174);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "C++ DATADESC (optional)";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDataDesc
            // 
            this.txtDataDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDataDesc.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataDesc.Location = new System.Drawing.Point(3, 3);
            this.txtDataDesc.Multiline = true;
            this.txtDataDesc.Name = "txtDataDesc";
            this.txtDataDesc.Size = new System.Drawing.Size(869, 168);
            this.txtDataDesc.TabIndex = 0;
            this.TheToolTip.SetToolTip(this.txtDataDesc, "If you have the DATADESC from the C++ code for this class paste it here to genera" +
        "te the properties and IO of this entity type");
            // 
            // frmNewEntity
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(883, 336);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNewEntity";
            this.Text = "New Entity - Mod Maker";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtDesk;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.RadioButton radBase;
        internal System.Windows.Forms.RadioButton radSolid;
        internal System.Windows.Forms.RadioButton radPoint;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblname;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.ListView ListBases;
        internal System.Windows.Forms.TextBox txtDataDesc;
        internal System.Windows.Forms.RadioButton radKeyFrame;
        internal System.Windows.Forms.RadioButton radMove;
        internal System.Windows.Forms.RadioButton radNPC;
        internal System.Windows.Forms.RadioButton radFilter;
        internal System.Windows.Forms.ToolTip TheToolTip;
    }

}