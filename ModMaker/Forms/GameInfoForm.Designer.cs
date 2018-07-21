using System;
using System.Collections.Generic;

namespace ModMaker
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class GameInfoForm : System.Windows.Forms.Form
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
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.SplitLibraryProps = new System.Windows.Forms.SplitContainer();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.PicIcon = new System.Windows.Forms.PictureBox();
            this.txtManURL = new System.Windows.Forms.TextBox();
            this.txtDevURL = new System.Windows.Forms.TextBox();
            this.txtDeveloper = new System.Windows.Forms.TextBox();
            this.txtGame = new System.Windows.Forms.TextBox();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.SplitMenuProps = new System.Windows.Forms.SplitContainer();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.radTypeBoth = new System.Windows.Forms.RadioButton();
            this.chkGameLogo = new System.Windows.Forms.CheckBox();
            this.chkAdvCrosshair = new System.Windows.Forms.CheckBox();
            this.chkHasPortals = new System.Windows.Forms.CheckBox();
            this.chkNoDoff = new System.Windows.Forms.CheckBox();
            this.txtTitle2 = new System.Windows.Forms.TextBox();
            this.chkNoCrosshair = new System.Windows.Forms.CheckBox();
            this.chkNoModels = new System.Windows.Forms.CheckBox();
            this.radTypeMP = new System.Windows.Forms.RadioButton();
            this.radTypeSP = new System.Windows.Forms.RadioButton();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ListMaps = new System.Windows.Forms.ListView();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.FlowLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.SplitLibraryProps.Panel1.SuspendLayout();
            this.SplitLibraryProps.Panel2.SuspendLayout();
            this.SplitLibraryProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.PicIcon).BeginInit();
            this.TabPage3.SuspendLayout();
            this.SplitMenuProps.Panel1.SuspendLayout();
            this.SplitMenuProps.Panel2.SuspendLayout();
            this.SplitMenuProps.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            //
            //FlowLayoutPanel1
            //
            this.FlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.FlowLayoutPanel1.Controls.Add(this.btnOK);
            this.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(0, 205);
            this.FlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(479, 27);
            this.FlowLayoutPanel1.TabIndex = 1;
            //
            //btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(421, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 21);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            //btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(361, 2);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 21);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            //
            //Panel1
            //
            this.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.Panel1.Controls.Add(this.TabControl1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Panel1.Size = new System.Drawing.Size(479, 205);
            this.Panel1.TabIndex = 2;
            //
            //TabControl1
            //
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(4, 5);
            this.TabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(471, 195);
            this.TabControl1.TabIndex = 0;
            //
            //TabPage1
            //
            this.TabPage1.Controls.Add(this.SplitLibraryProps);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.TabPage1.Size = new System.Drawing.Size(463, 169);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Library";
            this.TabPage1.UseVisualStyleBackColor = true;
            //
            //SplitLibraryProps
            //
            this.SplitLibraryProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitLibraryProps.Location = new System.Drawing.Point(2, 2);
            this.SplitLibraryProps.Margin = new System.Windows.Forms.Padding(2);
            this.SplitLibraryProps.Name = "SplitLibraryProps";
            //
            //SplitLibraryProps.Panel1
            //
            this.SplitLibraryProps.Panel1.Controls.Add(this.Label11);
            this.SplitLibraryProps.Panel1.Controls.Add(this.Label6);
            this.SplitLibraryProps.Panel1.Controls.Add(this.Label5);
            this.SplitLibraryProps.Panel1.Controls.Add(this.Label4);
            this.SplitLibraryProps.Panel1.Controls.Add(this.Label1);
            //
            //SplitLibraryProps.Panel2
            //
            this.SplitLibraryProps.Panel2.Controls.Add(this.PicIcon);
            this.SplitLibraryProps.Panel2.Controls.Add(this.txtManURL);
            this.SplitLibraryProps.Panel2.Controls.Add(this.txtDevURL);
            this.SplitLibraryProps.Panel2.Controls.Add(this.txtDeveloper);
            this.SplitLibraryProps.Panel2.Controls.Add(this.txtGame);
            this.SplitLibraryProps.Size = new System.Drawing.Size(459, 165);
            this.SplitLibraryProps.SplitterDistance = 94;
            this.SplitLibraryProps.SplitterWidth = 3;
            this.SplitLibraryProps.TabIndex = 0;
            //
            //Label11
            //
            this.Label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label11.Location = new System.Drawing.Point(0, 96);
            this.Label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(94, 24);
            this.Label11.TabIndex = 10;
            this.Label11.Text = "Icon";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label6
            //
            this.Label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label6.Location = new System.Drawing.Point(0, 72);
            this.Label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(94, 24);
            this.Label6.TabIndex = 5;
            this.Label6.Text = "Manual URL";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label5
            //
            this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label5.Location = new System.Drawing.Point(0, 48);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(94, 24);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Developer URL";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label4
            //
            this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label4.Location = new System.Drawing.Point(0, 24);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 24);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Developer";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label1
            //
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Library Name";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //PicIcon
            //
            this.PicIcon.BackColor = System.Drawing.Color.DimGray;
            this.PicIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PicIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicIcon.Location = new System.Drawing.Point(0, 99);
            this.PicIcon.Margin = new System.Windows.Forms.Padding(2);
            this.PicIcon.Name = "PicIcon";
            this.PicIcon.Size = new System.Drawing.Size(28, 30);
            this.PicIcon.TabIndex = 5;
            this.PicIcon.TabStop = false;
            //
            //txtManURL
            //
            this.txtManURL.Location = new System.Drawing.Point(0, 76);
            this.txtManURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtManURL.Name = "txtManURL";
            this.txtManURL.Size = new System.Drawing.Size(360, 20);
            this.txtManURL.TabIndex = 4;
            //
            //txtDevURL
            //
            this.txtDevURL.Location = new System.Drawing.Point(0, 52);
            this.txtDevURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtDevURL.Name = "txtDevURL";
            this.txtDevURL.Size = new System.Drawing.Size(360, 20);
            this.txtDevURL.TabIndex = 3;
            //
            //txtDeveloper
            //
            this.txtDeveloper.Location = new System.Drawing.Point(0, 28);
            this.txtDeveloper.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.Size = new System.Drawing.Size(360, 20);
            this.txtDeveloper.TabIndex = 2;
            //
            //txtGame
            //
            this.txtGame.Location = new System.Drawing.Point(0, 3);
            this.txtGame.Margin = new System.Windows.Forms.Padding(2);
            this.txtGame.Name = "txtGame";
            this.txtGame.Size = new System.Drawing.Size(360, 20);
            this.txtGame.TabIndex = 0;
            //
            //TabPage3
            //
            this.TabPage3.Controls.Add(this.SplitMenuProps);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(463, 169);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Menus";
            this.TabPage3.UseVisualStyleBackColor = true;
            //
            //SplitMenuProps
            //
            this.SplitMenuProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitMenuProps.Location = new System.Drawing.Point(0, 0);
            this.SplitMenuProps.Margin = new System.Windows.Forms.Padding(2);
            this.SplitMenuProps.Name = "SplitMenuProps";
            //
            //SplitMenuProps.Panel1
            //
            this.SplitMenuProps.Panel1.Controls.Add(this.Label14);
            this.SplitMenuProps.Panel1.Controls.Add(this.Label15);
            this.SplitMenuProps.Panel1.Controls.Add(this.Label19);
            this.SplitMenuProps.Panel1.Controls.Add(this.Label20);
            this.SplitMenuProps.Panel1.Controls.Add(this.Label21);
            this.SplitMenuProps.Panel1.Controls.Add(this.Label13);
            //
            //SplitMenuProps.Panel2
            //
            this.SplitMenuProps.Panel2.Controls.Add(this.btnBrowse);
            this.SplitMenuProps.Panel2.Controls.Add(this.radTypeBoth);
            this.SplitMenuProps.Panel2.Controls.Add(this.chkGameLogo);
            this.SplitMenuProps.Panel2.Controls.Add(this.chkAdvCrosshair);
            this.SplitMenuProps.Panel2.Controls.Add(this.chkHasPortals);
            this.SplitMenuProps.Panel2.Controls.Add(this.chkNoDoff);
            this.SplitMenuProps.Panel2.Controls.Add(this.txtTitle2);
            this.SplitMenuProps.Panel2.Controls.Add(this.chkNoCrosshair);
            this.SplitMenuProps.Panel2.Controls.Add(this.chkNoModels);
            this.SplitMenuProps.Panel2.Controls.Add(this.radTypeMP);
            this.SplitMenuProps.Panel2.Controls.Add(this.radTypeSP);
            this.SplitMenuProps.Panel2.Controls.Add(this.txtTitle);
            this.SplitMenuProps.Size = new System.Drawing.Size(463, 169);
            this.SplitMenuProps.SplitterDistance = 142;
            this.SplitMenuProps.SplitterWidth = 3;
            this.SplitMenuProps.TabIndex = 1;
            //
            //Label14
            //
            this.Label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label14.Location = new System.Drawing.Point(0, 119);
            this.Label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(142, 24);
            this.Label14.TabIndex = 7;
            this.Label14.Text = "Hide Crosshair";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label15
            //
            this.Label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label15.Location = new System.Drawing.Point(0, 95);
            this.Label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(142, 24);
            this.Label15.TabIndex = 6;
            this.Label15.Text = "Hide Player Model Picker";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label19
            //
            this.Label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label19.Location = new System.Drawing.Point(0, 71);
            this.Label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(142, 24);
            this.Label19.TabIndex = 2;
            this.Label19.Text = "Mod Type";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label20
            //
            this.Label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label20.Location = new System.Drawing.Point(0, 47);
            this.Label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(142, 24);
            this.Label20.TabIndex = 1;
            this.Label20.Text = "Title Line 2";
            this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label21
            //
            this.Label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label21.Location = new System.Drawing.Point(0, 23);
            this.Label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(142, 24);
            this.Label21.TabIndex = 9;
            this.Label21.Text = "Title Line 1";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            //Label13
            //
            this.Label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label13.Location = new System.Drawing.Point(0, 0);
            this.Label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Label13.Size = new System.Drawing.Size(142, 23);
            this.Label13.TabIndex = 8;
            this.Label13.Text = "Use Title Logo";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            //radTypeBoth
            //
            this.radTypeBoth.AutoSize = true;
            this.radTypeBoth.Location = new System.Drawing.Point(182, 77);
            this.radTypeBoth.Margin = new System.Windows.Forms.Padding(2);
            this.radTypeBoth.Name = "radTypeBoth";
            this.radTypeBoth.Size = new System.Drawing.Size(47, 17);
            this.radTypeBoth.TabIndex = 14;
            this.radTypeBoth.TabStop = true;
            this.radTypeBoth.Text = "Both";
            this.radTypeBoth.UseVisualStyleBackColor = true;
            //
            //chkGameLogo
            //
            this.chkGameLogo.AutoSize = true;
            this.chkGameLogo.Location = new System.Drawing.Point(2, 6);
            this.chkGameLogo.Margin = new System.Windows.Forms.Padding(2);
            this.chkGameLogo.Name = "chkGameLogo";
            this.chkGameLogo.Size = new System.Drawing.Size(15, 14);
            this.chkGameLogo.TabIndex = 13;
            this.chkGameLogo.UseVisualStyleBackColor = true;
            //
            //chkAdvCrosshair
            //
            this.chkAdvCrosshair.AutoSize = true;
            this.chkAdvCrosshair.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAdvCrosshair.Location = new System.Drawing.Point(30, 126);
            this.chkAdvCrosshair.Margin = new System.Windows.Forms.Padding(2);
            this.chkAdvCrosshair.Name = "chkAdvCrosshair";
            this.chkAdvCrosshair.Size = new System.Drawing.Size(121, 17);
            this.chkAdvCrosshair.TabIndex = 12;
            this.chkAdvCrosshair.Text = "Advanced Crosshair";
            this.chkAdvCrosshair.UseVisualStyleBackColor = true;
            //
            //chkHasPortals
            //
            this.chkHasPortals.AutoSize = true;
            this.chkHasPortals.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHasPortals.Location = new System.Drawing.Point(192, 100);
            this.chkHasPortals.Margin = new System.Windows.Forms.Padding(2);
            this.chkHasPortals.Name = "chkHasPortals";
            this.chkHasPortals.Size = new System.Drawing.Size(80, 17);
            this.chkHasPortals.TabIndex = 11;
            this.chkHasPortals.Text = "Has Portals";
            this.chkHasPortals.UseVisualStyleBackColor = true;
            //
            //chkNoDoff
            //
            this.chkNoDoff.AutoSize = true;
            this.chkNoDoff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoDoff.Location = new System.Drawing.Point(61, 102);
            this.chkNoDoff.Margin = new System.Windows.Forms.Padding(2);
            this.chkNoDoff.Name = "chkNoDoff";
            this.chkNoDoff.Size = new System.Drawing.Size(91, 17);
            this.chkNoDoff.TabIndex = 10;
            this.chkNoDoff.Text = "Hide Difficulty";
            this.chkNoDoff.UseVisualStyleBackColor = true;
            //
            //txtTitle2
            //
            this.txtTitle2.Location = new System.Drawing.Point(1, 51);
            this.txtTitle2.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle2.Name = "txtTitle2";
            this.txtTitle2.Size = new System.Drawing.Size(311, 20);
            this.txtTitle2.TabIndex = 9;
            //
            //chkNoCrosshair
            //
            this.chkNoCrosshair.AutoSize = true;
            this.chkNoCrosshair.Location = new System.Drawing.Point(1, 128);
            this.chkNoCrosshair.Margin = new System.Windows.Forms.Padding(2);
            this.chkNoCrosshair.Name = "chkNoCrosshair";
            this.chkNoCrosshair.Size = new System.Drawing.Size(15, 14);
            this.chkNoCrosshair.TabIndex = 8;
            this.chkNoCrosshair.UseVisualStyleBackColor = true;
            //
            //chkNoModels
            //
            this.chkNoModels.AutoSize = true;
            this.chkNoModels.Location = new System.Drawing.Point(1, 102);
            this.chkNoModels.Margin = new System.Windows.Forms.Padding(2);
            this.chkNoModels.Name = "chkNoModels";
            this.chkNoModels.Size = new System.Drawing.Size(15, 14);
            this.chkNoModels.TabIndex = 7;
            this.chkNoModels.UseVisualStyleBackColor = true;
            //
            //radTypeMP
            //
            this.radTypeMP.AutoSize = true;
            this.radTypeMP.Location = new System.Drawing.Point(96, 77);
            this.radTypeMP.Margin = new System.Windows.Forms.Padding(2);
            this.radTypeMP.Name = "radTypeMP";
            this.radTypeMP.Size = new System.Drawing.Size(75, 17);
            this.radTypeMP.TabIndex = 6;
            this.radTypeMP.TabStop = true;
            this.radTypeMP.Text = "Multiplayer";
            this.radTypeMP.UseVisualStyleBackColor = true;
            //
            //radTypeSP
            //
            this.radTypeSP.AutoSize = true;
            this.radTypeSP.Location = new System.Drawing.Point(2, 77);
            this.radTypeSP.Margin = new System.Windows.Forms.Padding(2);
            this.radTypeSP.Name = "radTypeSP";
            this.radTypeSP.Size = new System.Drawing.Size(82, 17);
            this.radTypeSP.TabIndex = 5;
            this.radTypeSP.TabStop = true;
            this.radTypeSP.Text = "Singleplayer";
            this.radTypeSP.UseVisualStyleBackColor = true;
            //
            //txtTitle
            //
            this.txtTitle.Location = new System.Drawing.Point(1, 27);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(311, 20);
            this.txtTitle.TabIndex = 1;
            //
            //TabPage2
            //
            this.TabPage2.Controls.Add(this.ListMaps);
            this.TabPage2.Controls.Add(this.Label2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabPage2.Size = new System.Drawing.Size(463, 169);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Maps";
            this.TabPage2.UseVisualStyleBackColor = true;
            //
            //ListMaps
            //
            this.ListMaps.CheckBoxes = true;
            this.ListMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListMaps.HideSelection = false;
            this.ListMaps.Location = new System.Drawing.Point(4, 23);
            this.ListMaps.Margin = new System.Windows.Forms.Padding(2);
            this.ListMaps.Name = "ListMaps";
            this.ListMaps.Size = new System.Drawing.Size(455, 141);
            this.ListMaps.TabIndex = 0;
            this.ListMaps.UseCompatibleStateImageBehavior = false;
            this.ListMaps.View = System.Windows.Forms.View.List;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Location = new System.Drawing.Point(4, 5);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Label2.Size = new System.Drawing.Size(416, 18);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Check maps to hide them from the console.  Any other maps will be added to maplis" +
                               "t.txt";
            //
            //btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(22, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 15;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            //
            //frmGameInfo
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 232);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGameInfo";
            this.Text = "Game Information";
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.SplitLibraryProps.Panel1.ResumeLayout(false);
            this.SplitLibraryProps.Panel2.ResumeLayout(false);
            this.SplitLibraryProps.Panel2.PerformLayout();
            this.SplitLibraryProps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.PicIcon).EndInit();
            this.TabPage3.ResumeLayout(false);
            this.SplitMenuProps.Panel1.ResumeLayout(false);
            this.SplitMenuProps.Panel2.ResumeLayout(false);
            this.SplitMenuProps.Panel2.PerformLayout();
            this.SplitMenuProps.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.SplitContainer SplitLibraryProps;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtManURL;
        internal System.Windows.Forms.TextBox txtDevURL;
        internal System.Windows.Forms.TextBox txtDeveloper;
        internal System.Windows.Forms.TextBox txtGame;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.SplitContainer SplitMenuProps;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.CheckBox chkAdvCrosshair;
        internal System.Windows.Forms.CheckBox chkHasPortals;
        internal System.Windows.Forms.CheckBox chkNoDoff;
        internal System.Windows.Forms.TextBox txtTitle2;
        internal System.Windows.Forms.CheckBox chkNoCrosshair;
        internal System.Windows.Forms.RadioButton radTypeMP;
        internal System.Windows.Forms.RadioButton radTypeSP;
        internal System.Windows.Forms.TextBox txtTitle;
        internal System.Windows.Forms.CheckBox chkGameLogo;
        internal System.Windows.Forms.ListView ListMaps;
        internal System.Windows.Forms.PictureBox PicIcon;
        internal System.Windows.Forms.RadioButton radTypeBoth;
        internal System.Windows.Forms.CheckBox chkNoModels;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnBrowse;
    }

}