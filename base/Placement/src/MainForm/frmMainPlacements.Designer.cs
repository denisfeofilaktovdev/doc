namespace Placements.src
{
    partial class frmMainPlacements
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader ShortPost;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainPlacements));
            this.tspMain = new System.Windows.Forms.ToolStrip();
            this.tspMain_Open = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tspMain_Update = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvMain = new System.Windows.Forms.TreeView();
            this.grbProperty = new System.Windows.Forms.GroupBox();
            this.lsvMain = new System.Windows.Forms.ListView();
            this.ShortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Contacts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlLSV = new System.Windows.Forms.ImageList(this.components);
            this.tspPlaceman = new System.Windows.Forms.ToolStrip();
            this.tspPlaceman_Add = new System.Windows.Forms.ToolStripButton();
            this.tspPlaceman_Edit = new System.Windows.Forms.ToolStripButton();
            this.tspPlaceman_Del = new System.Windows.Forms.ToolStripButton();
            this.tspPlaceman_Def = new System.Windows.Forms.ToolStripButton();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmsEditRegion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEditRegion_AddDistrict = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEditRegion_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditRegion_EditRSA = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditDistrict = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEditDistrict_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEditDistrict_EditDSA = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsEditDistrict_DelDistrict = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRegionCEC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRegionCEC_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDepartmentECO = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDepartmentECO_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRAW = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRAW_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDistrictCEC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDistrictCEC_Edit = new System.Windows.Forms.ToolStripMenuItem();
            ShortPost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tspMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbProperty.SuspendLayout();
            this.tspPlaceman.SuspendLayout();
            this.cmsEditRegion.SuspendLayout();
            this.cmsEditDistrict.SuspendLayout();
            this.cmsRegionCEC.SuspendLayout();
            this.cmsDepartmentECO.SuspendLayout();
            this.cmsRAW.SuspendLayout();
            this.cmsDistrictCEC.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShortPost
            // 
            ShortPost.Text = "Должность";
            ShortPost.Width = 136;
            // 
            // tspMain
            // 
            this.tspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspMain_Open,
            this.toolStripSeparator1,
            this.tspMain_Update});
            this.tspMain.Location = new System.Drawing.Point(0, 0);
            this.tspMain.Name = "tspMain";
            this.tspMain.Size = new System.Drawing.Size(773, 25);
            this.tspMain.TabIndex = 0;
            // 
            // tspMain_Open
            // 
            this.tspMain_Open.Image = ((System.Drawing.Image)(resources.GetObject("tspMain_Open.Image")));
            this.tspMain_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspMain_Open.Name = "tspMain_Open";
            this.tspMain_Open.Size = new System.Drawing.Size(77, 22);
            this.tspMain_Open.Text = "Отрыть...";
            this.tspMain_Open.Click += new System.EventHandler(this.tspMain_Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tspMain_Update
            // 
            this.tspMain_Update.Image = ((System.Drawing.Image)(resources.GetObject("tspMain_Update.Image")));
            this.tspMain_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspMain_Update.Name = "tspMain_Update";
            this.tspMain_Update.Size = new System.Drawing.Size(81, 22);
            this.tspMain_Update.Text = "Обновить";
            this.tspMain_Update.Click += new System.EventHandler(this.tspMain_Update_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbProperty);
            this.splitContainer1.Size = new System.Drawing.Size(773, 314);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 1;
            // 
            // trvMain
            // 
            this.trvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMain.HideSelection = false;
            this.trvMain.Indent = 19;
            this.trvMain.ItemHeight = 36;
            this.trvMain.Location = new System.Drawing.Point(0, 0);
            this.trvMain.Name = "trvMain";
            this.trvMain.Size = new System.Drawing.Size(257, 314);
            this.trvMain.TabIndex = 0;
            this.trvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMain_AfterSelect);
            this.trvMain.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvMain_NodeMouseClick);
            this.trvMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvMain_NodeMouseDoubleClick);
            // 
            // grbProperty
            // 
            this.grbProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProperty.Controls.Add(this.lsvMain);
            this.grbProperty.Controls.Add(this.tspPlaceman);
            this.grbProperty.Location = new System.Drawing.Point(3, 3);
            this.grbProperty.Name = "grbProperty";
            this.grbProperty.Size = new System.Drawing.Size(506, 308);
            this.grbProperty.TabIndex = 1;
            this.grbProperty.TabStop = false;
            // 
            // lsvMain
            // 
            this.lsvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvMain.BackColor = System.Drawing.SystemColors.Window;
            this.lsvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            ShortPost,
            this.ShortName,
            this.Status,
            this.Contacts});
            this.lsvMain.FullRowSelect = true;
            this.lsvMain.GridLines = true;
            this.lsvMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvMain.HideSelection = false;
            this.lsvMain.LargeImageList = this.imlLSV;
            this.lsvMain.Location = new System.Drawing.Point(3, 44);
            this.lsvMain.MultiSelect = false;
            this.lsvMain.Name = "lsvMain";
            this.lsvMain.Size = new System.Drawing.Size(500, 258);
            this.lsvMain.SmallImageList = this.imlLSV;
            this.lsvMain.TabIndex = 3;
            this.lsvMain.UseCompatibleStateImageBehavior = false;
            this.lsvMain.View = System.Windows.Forms.View.Details;
            this.lsvMain.SelectedIndexChanged += new System.EventHandler(this.lsvMain_SelectedIndexChanged);
            this.lsvMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsvMain_MouseDoubleClick);
            // 
            // ShortName
            // 
            this.ShortName.Text = "ФИО";
            this.ShortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ShortName.Width = 104;
            // 
            // Status
            // 
            this.Status.Text = "✔";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 73;
            // 
            // Contacts
            // 
            this.Contacts.Text = "Контакты";
            this.Contacts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Contacts.Width = 183;
            // 
            // imlLSV
            // 
            this.imlLSV.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLSV.ImageStream")));
            this.imlLSV.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLSV.Images.SetKeyName(0, "default.png");
            // 
            // tspPlaceman
            // 
            this.tspPlaceman.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspPlaceman_Add,
            this.tspPlaceman_Edit,
            this.tspPlaceman_Del,
            this.tspPlaceman_Def});
            this.tspPlaceman.Location = new System.Drawing.Point(3, 16);
            this.tspPlaceman.Name = "tspPlaceman";
            this.tspPlaceman.Size = new System.Drawing.Size(500, 25);
            this.tspPlaceman.TabIndex = 2;
            this.tspPlaceman.Text = "tstPlaceman";
            // 
            // tspPlaceman_Add
            // 
            this.tspPlaceman_Add.Image = ((System.Drawing.Image)(resources.GetObject("tspPlaceman_Add.Image")));
            this.tspPlaceman_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspPlaceman_Add.Name = "tspPlaceman_Add";
            this.tspPlaceman_Add.Size = new System.Drawing.Size(88, 22);
            this.tspPlaceman_Add.Text = "Добавить...";
            this.tspPlaceman_Add.Click += new System.EventHandler(this.tspPlaceman_Add_Click);
            // 
            // tspPlaceman_Edit
            // 
            this.tspPlaceman_Edit.Enabled = false;
            this.tspPlaceman_Edit.Image = ((System.Drawing.Image)(resources.GetObject("tspPlaceman_Edit.Image")));
            this.tspPlaceman_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspPlaceman_Edit.Name = "tspPlaceman_Edit";
            this.tspPlaceman_Edit.Size = new System.Drawing.Size(116, 22);
            this.tspPlaceman_Edit.Text = "Редактировать...";
            this.tspPlaceman_Edit.Click += new System.EventHandler(this.tspPlaceman_Edit_Click);
            // 
            // tspPlaceman_Del
            // 
            this.tspPlaceman_Del.Enabled = false;
            this.tspPlaceman_Del.Image = ((System.Drawing.Image)(resources.GetObject("tspPlaceman_Del.Image")));
            this.tspPlaceman_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspPlaceman_Del.Name = "tspPlaceman_Del";
            this.tspPlaceman_Del.Size = new System.Drawing.Size(71, 22);
            this.tspPlaceman_Del.Text = "Удалить";
            this.tspPlaceman_Del.Click += new System.EventHandler(this.tspPlaceman_Del_Click);
            // 
            // tspPlaceman_Def
            // 
            this.tspPlaceman_Def.Enabled = false;
            this.tspPlaceman_Def.Image = ((System.Drawing.Image)(resources.GetObject("tspPlaceman_Def.Image")));
            this.tspPlaceman_Def.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspPlaceman_Def.Name = "tspPlaceman_Def";
            this.tspPlaceman_Def.Size = new System.Drawing.Size(112, 22);
            this.tspPlaceman_Def.Text = "По умолчанию";
            this.tspPlaceman_Def.Click += new System.EventHandler(this.tspPlaceman_Def_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            this.openDialog.Filter = "Placements.db|Placements.db";
            // 
            // cmsEditRegion
            // 
            this.cmsEditRegion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEditRegion_AddDistrict,
            this.toolStripMenuItem1,
            this.cmsEditRegion_Edit,
            this.cmsEditRegion_EditRSA});
            this.cmsEditRegion.Name = "contextMenuStrip1";
            this.cmsEditRegion.Size = new System.Drawing.Size(213, 76);
            // 
            // cmsEditRegion_AddDistrict
            // 
            this.cmsEditRegion_AddDistrict.Name = "cmsEditRegion_AddDistrict";
            this.cmsEditRegion_AddDistrict.Size = new System.Drawing.Size(212, 22);
            this.cmsEditRegion_AddDistrict.Text = "Добавить Район...";
            this.cmsEditRegion_AddDistrict.Click += new System.EventHandler(this.cmsEditRegion_AddDistrict_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
            // 
            // cmsEditRegion_Edit
            // 
            this.cmsEditRegion_Edit.Name = "cmsEditRegion_Edit";
            this.cmsEditRegion_Edit.Size = new System.Drawing.Size(212, 22);
            this.cmsEditRegion_Edit.Text = "Редактировать Область...";
            this.cmsEditRegion_Edit.Click += new System.EventHandler(this.cmsEditRegion_Edit_Click);
            // 
            // cmsEditRegion_EditRSA
            // 
            this.cmsEditRegion_EditRSA.Name = "cmsEditRegion_EditRSA";
            this.cmsEditRegion_EditRSA.Size = new System.Drawing.Size(212, 22);
            this.cmsEditRegion_EditRSA.Text = "Редактировать ОДА...";
            this.cmsEditRegion_EditRSA.Click += new System.EventHandler(this.cmsEditRegion_EditRSA_Click);
            // 
            // cmsEditDistrict
            // 
            this.cmsEditDistrict.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEditDistrict_Edit,
            this.cmsEditDistrict_EditDSA,
            this.toolStripMenuItem2,
            this.cmsEditDistrict_DelDistrict});
            this.cmsEditDistrict.Name = "cmsEditDistrict";
            this.cmsEditDistrict.Size = new System.Drawing.Size(201, 76);
            // 
            // cmsEditDistrict_Edit
            // 
            this.cmsEditDistrict_Edit.Name = "cmsEditDistrict_Edit";
            this.cmsEditDistrict_Edit.Size = new System.Drawing.Size(200, 22);
            this.cmsEditDistrict_Edit.Text = "Редактировать Район...";
            this.cmsEditDistrict_Edit.Click += new System.EventHandler(this.cmsEditDistrict_Edit_Click);
            // 
            // cmsEditDistrict_EditDSA
            // 
            this.cmsEditDistrict_EditDSA.Name = "cmsEditDistrict_EditDSA";
            this.cmsEditDistrict_EditDSA.Size = new System.Drawing.Size(200, 22);
            this.cmsEditDistrict_EditDSA.Text = "Редактировать РДА...";
            this.cmsEditDistrict_EditDSA.Click += new System.EventHandler(this.cmsEditDistrict_EditDSA_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 6);
            // 
            // cmsEditDistrict_DelDistrict
            // 
            this.cmsEditDistrict_DelDistrict.Name = "cmsEditDistrict_DelDistrict";
            this.cmsEditDistrict_DelDistrict.Size = new System.Drawing.Size(200, 22);
            this.cmsEditDistrict_DelDistrict.Text = "Удалить Район...";
            this.cmsEditDistrict_DelDistrict.Click += new System.EventHandler(this.cmsEditDistrict_DelDistrict_Click);
            // 
            // cmsRegionCEC
            // 
            this.cmsRegionCEC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRegionCEC_Edit});
            this.cmsRegionCEC.Name = "cmsRegionCEC";
            this.cmsRegionCEC.Size = new System.Drawing.Size(222, 26);
            // 
            // cmsRegionCEC_Edit
            // 
            this.cmsRegionCEC_Edit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmsRegionCEC_Edit.Name = "cmsRegionCEC_Edit";
            this.cmsRegionCEC_Edit.Size = new System.Drawing.Size(221, 22);
            this.cmsRegionCEC_Edit.Text = "Редактировать Обл. СЕС...";
            this.cmsRegionCEC_Edit.Click += new System.EventHandler(this.cmsRegionCEC_Edit_Click);
            // 
            // cmsDepartmentECO
            // 
            this.cmsDepartmentECO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDepartmentECO_Edit});
            this.cmsDepartmentECO.Name = "cmsRegionCEC";
            this.cmsDepartmentECO.Size = new System.Drawing.Size(302, 26);
            // 
            // cmsDepartmentECO_Edit
            // 
            this.cmsDepartmentECO_Edit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmsDepartmentECO_Edit.Name = "cmsDepartmentECO_Edit";
            this.cmsDepartmentECO_Edit.Size = new System.Drawing.Size(301, 22);
            this.cmsDepartmentECO_Edit.Text = "Редактировать Управление Экологии...";
            this.cmsDepartmentECO_Edit.Click += new System.EventHandler(this.cmsDepartmentECO_Edit_Click);
            // 
            // cmsRAW
            // 
            this.cmsRAW.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRAW_Edit});
            this.cmsRAW.Name = "cmsRAW";
            this.cmsRAW.Size = new System.Drawing.Size(307, 26);
            // 
            // cmsRAW_Edit
            // 
            this.cmsRAW_Edit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmsRAW_Edit.Name = "cmsRAW_Edit";
            this.cmsRAW_Edit.Size = new System.Drawing.Size(306, 22);
            this.cmsRAW_Edit.Text = "Редактировать Управление ВодРесурс...";
            this.cmsRAW_Edit.Click += new System.EventHandler(this.cmsRAW_Edit_Click);
            // 
            // cmsDistrictCEC
            // 
            this.cmsDistrictCEC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDistrictCEC_Edit});
            this.cmsDistrictCEC.Name = "cmsDistrictCEC";
            this.cmsDistrictCEC.Size = new System.Drawing.Size(258, 26);
            // 
            // cmsDistrictCEC_Edit
            // 
            this.cmsDistrictCEC_Edit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmsDistrictCEC_Edit.Name = "cmsDistrictCEC_Edit";
            this.cmsDistrictCEC_Edit.Size = new System.Drawing.Size(257, 22);
            this.cmsDistrictCEC_Edit.Text = "Редактировать Районную  СЕС...";
            this.cmsDistrictCEC_Edit.Click += new System.EventHandler(this.cmsDistrictCEC_Edit_Click);
            // 
            // frmMainPlacements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 339);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tspMain);
            this.KeyPreview = true;
            this.Name = "frmMainPlacements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainPlacements";
            this.tspMain.ResumeLayout(false);
            this.tspMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbProperty.ResumeLayout(false);
            this.grbProperty.PerformLayout();
            this.tspPlaceman.ResumeLayout(false);
            this.tspPlaceman.PerformLayout();
            this.cmsEditRegion.ResumeLayout(false);
            this.cmsEditDistrict.ResumeLayout(false);
            this.cmsRegionCEC.ResumeLayout(false);
            this.cmsDepartmentECO.ResumeLayout(false);
            this.cmsRAW.ResumeLayout(false);
            this.cmsDistrictCEC.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspMain;
        private System.Windows.Forms.ToolStripButton tspMain_Open;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.ContextMenuStrip cmsEditRegion;
        private System.Windows.Forms.ToolStripMenuItem cmsEditRegion_AddDistrict;
        private System.Windows.Forms.ToolStripMenuItem cmsEditRegion_Edit;
        private System.Windows.Forms.ToolStripButton tspMain_Update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip tspPlaceman;
        private System.Windows.Forms.ContextMenuStrip cmsEditDistrict;
        private System.Windows.Forms.ToolStripMenuItem cmsEditDistrict_Edit;
        public System.Windows.Forms.TreeView trvMain;
        public System.Windows.Forms.ListView lsvMain;
        public System.Windows.Forms.GroupBox grbProperty;
        public System.Windows.Forms.ToolStripButton tspPlaceman_Add;
        public System.Windows.Forms.ToolStripButton tspPlaceman_Del;
        public System.Windows.Forms.ToolStripButton tspPlaceman_Edit;
        public System.Windows.Forms.ToolStripButton tspPlaceman_Def;
        private System.Windows.Forms.ColumnHeader ShortName;
        private System.Windows.Forms.ColumnHeader Contacts;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ToolStripMenuItem cmsEditRegion_EditRSA;
        private System.Windows.Forms.ToolStripMenuItem cmsEditDistrict_EditDSA;
        private System.Windows.Forms.ContextMenuStrip cmsRegionCEC;
        private System.Windows.Forms.ContextMenuStrip cmsDepartmentECO;
        private System.Windows.Forms.ContextMenuStrip cmsRAW;
        private System.Windows.Forms.ContextMenuStrip cmsDistrictCEC;
        private System.Windows.Forms.ImageList imlLSV;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmsRegionCEC_Edit;
        private System.Windows.Forms.ToolStripMenuItem cmsDepartmentECO_Edit;
        private System.Windows.Forms.ToolStripMenuItem cmsRAW_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmsEditDistrict_DelDistrict;
        private System.Windows.Forms.ToolStripMenuItem cmsDistrictCEC_Edit;



    }
}

