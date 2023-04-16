namespace TPH.LIS.App.AppCode
{
    partial class ucNgonNguDanhMuc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNgonNguDanhMuc));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcNgonNgu = new DevExpress.XtraGrid.GridControl();
            this.gvNgonNgu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNgonNgu_IdNgonNgu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgonNgu_MoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLoadDSngonNgu = new TPH.Controls.TPHNormalButton();
            this.btnXoaNgonNgu = new TPH.Controls.TPHNormalButton();
            this.btnThemNgonNgu = new TPH.Controls.TPHNormalButton();
            this.txtIDNgonNguMoi = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcDanhMuc = new DevExpress.XtraGrid.GridControl();
            this.gvDanhMuc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDanhMuc_MaDanhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDanhMuc_MoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.cboLoaiDanHmuc = new System.Windows.Forms.ComboBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.gcDanhMucNgonNgu = new DevExpress.XtraGrid.GridControl();
            this.gvDanhMucNgonNgu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDanhMucNgonNgu_MaDanhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDanhMucNgonNgu_NoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDanhMucNgonNgu_IdNgonNgu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDanhMucNgonNgu_IDDanhMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDanhSachNgonNgu_DanhMuc = new TPH.Controls.TPHNormalButton();
            this.btnXoaDM = new TPH.Controls.TPHNormalButton();
            this.btnThemDM = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNgonNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNgonNgu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMuc)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMucNgonNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMucNgonNgu)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.gcNgonNgu);
            this.groupControl1.Controls.Add(this.panel1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(300, 155);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "NGÔN NGỮ";
            // 
            // gcNgonNgu
            // 
            this.gcNgonNgu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNgonNgu.Location = new System.Drawing.Point(2, 53);
            this.gcNgonNgu.MainView = this.gvNgonNgu;
            this.gcNgonNgu.Name = "gcNgonNgu";
            this.gcNgonNgu.Size = new System.Drawing.Size(296, 100);
            this.gcNgonNgu.TabIndex = 1;
            this.gcNgonNgu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNgonNgu});
            // 
            // gvNgonNgu
            // 
            this.gvNgonNgu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgonNgu_IdNgonNgu,
            this.colNgonNgu_MoTa});
            this.gvNgonNgu.GridControl = this.gcNgonNgu;
            this.gvNgonNgu.Name = "gvNgonNgu";
            this.gvNgonNgu.OptionsView.ShowGroupPanel = false;
            this.gvNgonNgu.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvNgonNgu_CellValueChanged);
            // 
            // colNgonNgu_IdNgonNgu
            // 
            this.colNgonNgu_IdNgonNgu.Caption = "ID Ngôn ngữ";
            this.colNgonNgu_IdNgonNgu.FieldName = "IdNgonNgu";
            this.colNgonNgu_IdNgonNgu.Name = "colNgonNgu_IdNgonNgu";
            this.colNgonNgu_IdNgonNgu.OptionsColumn.ReadOnly = true;
            this.colNgonNgu_IdNgonNgu.Visible = true;
            this.colNgonNgu_IdNgonNgu.VisibleIndex = 0;
            this.colNgonNgu_IdNgonNgu.Width = 77;
            // 
            // colNgonNgu_MoTa
            // 
            this.colNgonNgu_MoTa.Caption = "Mô tả";
            this.colNgonNgu_MoTa.FieldName = "MoTa";
            this.colNgonNgu_MoTa.Name = "colNgonNgu_MoTa";
            this.colNgonNgu_MoTa.Visible = true;
            this.colNgonNgu_MoTa.VisibleIndex = 1;
            this.colNgonNgu_MoTa.Width = 203;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel1.Controls.Add(this.btnLoadDSngonNgu);
            this.panel1.Controls.Add(this.btnXoaNgonNgu);
            this.panel1.Controls.Add(this.btnThemNgonNgu);
            this.panel1.Controls.Add(this.txtIDNgonNguMoi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadDSngonNgu
            // 
            this.btnLoadDSngonNgu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadDSngonNgu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLoadDSngonNgu.BackColorHover = System.Drawing.Color.Empty;
            this.btnLoadDSngonNgu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLoadDSngonNgu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLoadDSngonNgu.BorderRadius = 5;
            this.btnLoadDSngonNgu.BorderSize = 1;
            this.btnLoadDSngonNgu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadDSngonNgu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDSngonNgu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDSngonNgu.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLoadDSngonNgu.ForeColor = System.Drawing.Color.Black;
            this.btnLoadDSngonNgu.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDSngonNgu.Image")));
            this.btnLoadDSngonNgu.Location = new System.Drawing.Point(228, -1);
            this.btnLoadDSngonNgu.Name = "btnLoadDSngonNgu";
            this.btnLoadDSngonNgu.Size = new System.Drawing.Size(33, 31);
            this.btnLoadDSngonNgu.TabIndex = 6;
            this.btnLoadDSngonNgu.TextColor = System.Drawing.Color.Black;
            this.btnLoadDSngonNgu.UseHightLight = true;
            this.btnLoadDSngonNgu.UseVisualStyleBackColor = false;
            this.btnLoadDSngonNgu.Click += new System.EventHandler(this.btnLoadDSngonNgu_Click);
            // 
            // btnXoaNgonNgu
            // 
            this.btnXoaNgonNgu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaNgonNgu.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaNgonNgu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaNgonNgu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaNgonNgu.BorderRadius = 5;
            this.btnXoaNgonNgu.BorderSize = 1;
            this.btnXoaNgonNgu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNgonNgu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNgonNgu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNgonNgu.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaNgonNgu.ForeColor = System.Drawing.Color.Black;
            this.btnXoaNgonNgu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaNgonNgu.Image")));
            this.btnXoaNgonNgu.Location = new System.Drawing.Point(261, -1);
            this.btnXoaNgonNgu.Name = "btnXoaNgonNgu";
            this.btnXoaNgonNgu.Size = new System.Drawing.Size(33, 31);
            this.btnXoaNgonNgu.TabIndex = 3;
            this.btnXoaNgonNgu.TextColor = System.Drawing.Color.Black;
            this.btnXoaNgonNgu.UseHightLight = true;
            this.btnXoaNgonNgu.UseVisualStyleBackColor = false;
            this.btnXoaNgonNgu.Click += new System.EventHandler(this.btnXoaNgonNgu_Click);
            // 
            // btnThemNgonNgu
            // 
            this.btnThemNgonNgu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemNgonNgu.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemNgonNgu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemNgonNgu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemNgonNgu.BorderRadius = 5;
            this.btnThemNgonNgu.BorderSize = 1;
            this.btnThemNgonNgu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNgonNgu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNgonNgu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNgonNgu.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemNgonNgu.ForeColor = System.Drawing.Color.Black;
            this.btnThemNgonNgu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemNgonNgu.Image")));
            this.btnThemNgonNgu.Location = new System.Drawing.Point(195, -1);
            this.btnThemNgonNgu.Name = "btnThemNgonNgu";
            this.btnThemNgonNgu.Size = new System.Drawing.Size(33, 31);
            this.btnThemNgonNgu.TabIndex = 2;
            this.btnThemNgonNgu.TextColor = System.Drawing.Color.Black;
            this.btnThemNgonNgu.UseHightLight = true;
            this.btnThemNgonNgu.UseVisualStyleBackColor = false;
            this.btnThemNgonNgu.Click += new System.EventHandler(this.btnThemNgonNgu_Click);
            // 
            // txtIDNgonNguMoi
            // 
            this.txtIDNgonNguMoi.Location = new System.Drawing.Point(99, 4);
            this.txtIDNgonNguMoi.Name = "txtIDNgonNguMoi";
            this.txtIDNgonNguMoi.Size = new System.Drawing.Size(90, 21);
            this.txtIDNgonNguMoi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngôn ngữ mới:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcDanhMucNgonNgu);
            this.splitContainerControl1.Panel2.Controls.Add(this.panel3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(699, 379);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.gcDanhMuc);
            this.groupControl2.Controls.Add(this.panel2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 155);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(300, 224);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "DANH MỤC";
            // 
            // gcDanhMuc
            // 
            this.gcDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhMuc.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhMuc.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhMuc.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhMuc.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhMuc.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhMuc.Location = new System.Drawing.Point(2, 50);
            this.gcDanhMuc.MainView = this.gvDanhMuc;
            this.gcDanhMuc.Name = "gcDanhMuc";
            this.gcDanhMuc.Size = new System.Drawing.Size(296, 172);
            this.gcDanhMuc.TabIndex = 2;
            this.gcDanhMuc.UseEmbeddedNavigator = true;
            this.gcDanhMuc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhMuc});
            // 
            // gvDanhMuc
            // 
            this.gvDanhMuc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDanhMuc_MaDanhMuc,
            this.colDanhMuc_MoTa});
            this.gvDanhMuc.GridControl = this.gcDanhMuc;
            this.gvDanhMuc.Name = "gvDanhMuc";
            this.gvDanhMuc.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gvDanhMuc.OptionsSelection.MultiSelect = true;
            this.gvDanhMuc.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDanhMuc.OptionsView.ColumnAutoWidth = false;
            this.gvDanhMuc.OptionsView.ShowGroupPanel = false;
            // 
            // colDanhMuc_MaDanhMuc
            // 
            this.colDanhMuc_MaDanhMuc.Caption = "Mã danh mục";
            this.colDanhMuc_MaDanhMuc.FieldName = "MaDanhMuc";
            this.colDanhMuc_MaDanhMuc.Name = "colDanhMuc_MaDanhMuc";
            this.colDanhMuc_MaDanhMuc.OptionsColumn.ReadOnly = true;
            this.colDanhMuc_MaDanhMuc.Visible = true;
            this.colDanhMuc_MaDanhMuc.VisibleIndex = 1;
            this.colDanhMuc_MaDanhMuc.Width = 79;
            // 
            // colDanhMuc_MoTa
            // 
            this.colDanhMuc_MoTa.Caption = "Mô tả";
            this.colDanhMuc_MoTa.FieldName = "MoTa";
            this.colDanhMuc_MoTa.Name = "colDanhMuc_MoTa";
            this.colDanhMuc_MoTa.OptionsColumn.ReadOnly = true;
            this.colDanhMuc_MoTa.Visible = true;
            this.colDanhMuc_MoTa.VisibleIndex = 2;
            this.colDanhMuc_MoTa.Width = 165;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel2.Controls.Add(this.cboLoaiDanHmuc);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 27);
            this.panel2.TabIndex = 0;
            // 
            // cboLoaiDanHmuc
            // 
            this.cboLoaiDanHmuc.FormattingEnabled = true;
            this.cboLoaiDanHmuc.Location = new System.Drawing.Point(99, 2);
            this.cboLoaiDanHmuc.Name = "cboLoaiDanHmuc";
            this.cboLoaiDanHmuc.Size = new System.Drawing.Size(193, 23);
            this.cboLoaiDanHmuc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại danh mục:";
            // 
            // gcDanhMucNgonNgu
            // 
            this.gcDanhMucNgonNgu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gcDanhMucNgonNgu.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhMucNgonNgu.Location = new System.Drawing.Point(36, 0);
            this.gcDanhMucNgonNgu.MainView = this.gvDanhMucNgonNgu;
            this.gcDanhMucNgonNgu.Name = "gcDanhMucNgonNgu";
            this.gcDanhMucNgonNgu.Size = new System.Drawing.Size(353, 379);
            this.gcDanhMucNgonNgu.TabIndex = 3;
            this.gcDanhMucNgonNgu.UseEmbeddedNavigator = true;
            this.gcDanhMucNgonNgu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhMucNgonNgu});
            // 
            // gvDanhMucNgonNgu
            // 
            this.gvDanhMucNgonNgu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDanhMucNgonNgu_MaDanhMuc,
            this.colDanhMucNgonNgu_NoiDung,
            this.colDanhMucNgonNgu_IdNgonNgu,
            this.colDanhMucNgonNgu_IDDanhMuc});
            this.gvDanhMucNgonNgu.GridControl = this.gcDanhMucNgonNgu;
            this.gvDanhMucNgonNgu.GroupCount = 1;
            this.gvDanhMucNgonNgu.Name = "gvDanhMucNgonNgu";
            this.gvDanhMucNgonNgu.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gvDanhMucNgonNgu.OptionsSelection.MultiSelect = true;
            this.gvDanhMucNgonNgu.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvDanhMucNgonNgu.OptionsView.BestFitUseErrorInfo = DevExpress.Utils.DefaultBoolean.False;
            this.gvDanhMucNgonNgu.OptionsView.ColumnAutoWidth = false;
            this.gvDanhMucNgonNgu.OptionsView.ShowAutoFilterRow = true;
            this.gvDanhMucNgonNgu.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gvDanhMucNgonNgu.OptionsView.ShowGroupPanel = false;
            this.gvDanhMucNgonNgu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDanhMucNgonNgu_IDDanhMuc, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDanhMucNgonNgu.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDanhMucNgonNgu_CellValueChanged);
            // 
            // colDanhMucNgonNgu_MaDanhMuc
            // 
            this.colDanhMucNgonNgu_MaDanhMuc.Caption = "Mã danh mục";
            this.colDanhMucNgonNgu_MaDanhMuc.FieldName = "MaDanhMuc";
            this.colDanhMucNgonNgu_MaDanhMuc.Name = "colDanhMucNgonNgu_MaDanhMuc";
            this.colDanhMucNgonNgu_MaDanhMuc.OptionsColumn.ReadOnly = true;
            this.colDanhMucNgonNgu_MaDanhMuc.Visible = true;
            this.colDanhMucNgonNgu_MaDanhMuc.VisibleIndex = 2;
            this.colDanhMucNgonNgu_MaDanhMuc.Width = 85;
            // 
            // colDanhMucNgonNgu_NoiDung
            // 
            this.colDanhMucNgonNgu_NoiDung.Caption = "Nội dung";
            this.colDanhMucNgonNgu_NoiDung.FieldName = "NoiDung";
            this.colDanhMucNgonNgu_NoiDung.Name = "colDanhMucNgonNgu_NoiDung";
            this.colDanhMucNgonNgu_NoiDung.Visible = true;
            this.colDanhMucNgonNgu_NoiDung.VisibleIndex = 1;
            this.colDanhMucNgonNgu_NoiDung.Width = 238;
            // 
            // colDanhMucNgonNgu_IdNgonNgu
            // 
            this.colDanhMucNgonNgu_IdNgonNgu.Caption = "ID Ngôn ngữ";
            this.colDanhMucNgonNgu_IdNgonNgu.FieldName = "IdNgonNgu";
            this.colDanhMucNgonNgu_IdNgonNgu.Name = "colDanhMucNgonNgu_IdNgonNgu";
            this.colDanhMucNgonNgu_IdNgonNgu.OptionsColumn.ReadOnly = true;
            this.colDanhMucNgonNgu_IdNgonNgu.Visible = true;
            this.colDanhMucNgonNgu_IdNgonNgu.VisibleIndex = 3;
            this.colDanhMucNgonNgu_IdNgonNgu.Width = 82;
            // 
            // colDanhMucNgonNgu_IDDanhMuc
            // 
            this.colDanhMucNgonNgu_IDDanhMuc.Caption = "Id Danh mục";
            this.colDanhMucNgonNgu_IDDanhMuc.FieldName = "IdDanhMuc";
            this.colDanhMucNgonNgu_IDDanhMuc.Name = "colDanhMucNgonNgu_IDDanhMuc";
            this.colDanhMucNgonNgu_IDDanhMuc.OptionsColumn.ReadOnly = true;
            this.colDanhMucNgonNgu_IDDanhMuc.Visible = true;
            this.colDanhMucNgonNgu_IDDanhMuc.VisibleIndex = 4;
            this.colDanhMucNgonNgu_IDDanhMuc.Width = 87;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel3.Controls.Add(this.btnDanhSachNgonNgu_DanhMuc);
            this.panel3.Controls.Add(this.btnXoaDM);
            this.panel3.Controls.Add(this.btnThemDM);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(36, 379);
            this.panel3.TabIndex = 0;
            // 
            // btnDanhSachNgonNgu_DanhMuc
            // 
            this.btnDanhSachNgonNgu_DanhMuc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDanhSachNgonNgu_DanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDanhSachNgonNgu_DanhMuc.BackColorHover = System.Drawing.Color.Empty;
            this.btnDanhSachNgonNgu_DanhMuc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDanhSachNgonNgu_DanhMuc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnDanhSachNgonNgu_DanhMuc.BorderRadius = 5;
            this.btnDanhSachNgonNgu_DanhMuc.BorderSize = 1;
            this.btnDanhSachNgonNgu_DanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhSachNgonNgu_DanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhSachNgonNgu_DanhMuc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhSachNgonNgu_DanhMuc.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDanhSachNgonNgu_DanhMuc.ForeColor = System.Drawing.Color.Black;
            this.btnDanhSachNgonNgu_DanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhSachNgonNgu_DanhMuc.Image")));
            this.btnDanhSachNgonNgu_DanhMuc.Location = new System.Drawing.Point(0, 345);
            this.btnDanhSachNgonNgu_DanhMuc.Name = "btnDanhSachNgonNgu_DanhMuc";
            this.btnDanhSachNgonNgu_DanhMuc.Size = new System.Drawing.Size(33, 31);
            this.btnDanhSachNgonNgu_DanhMuc.TabIndex = 5;
            this.btnDanhSachNgonNgu_DanhMuc.TextColor = System.Drawing.Color.Black;
            this.btnDanhSachNgonNgu_DanhMuc.UseHightLight = true;
            this.btnDanhSachNgonNgu_DanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhSachNgonNgu_DanhMuc.Click += new System.EventHandler(this.btnDanhSachNgonNgu_DanhMuc_Click);
            // 
            // btnXoaDM
            // 
            this.btnXoaDM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoaDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaDM.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaDM.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaDM.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaDM.BorderRadius = 5;
            this.btnXoaDM.BorderSize = 1;
            this.btnXoaDM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDM.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaDM.ForeColor = System.Drawing.Color.Black;
            this.btnXoaDM.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDM.Image")));
            this.btnXoaDM.Location = new System.Drawing.Point(0, 299);
            this.btnXoaDM.Name = "btnXoaDM";
            this.btnXoaDM.Size = new System.Drawing.Size(33, 31);
            this.btnXoaDM.TabIndex = 4;
            this.btnXoaDM.TextColor = System.Drawing.Color.Black;
            this.btnXoaDM.UseHightLight = true;
            this.btnXoaDM.UseVisualStyleBackColor = false;
            this.btnXoaDM.Click += new System.EventHandler(this.btnXoaDM_Click);
            // 
            // btnThemDM
            // 
            this.btnThemDM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemDM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemDM.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemDM.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemDM.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemDM.BorderRadius = 5;
            this.btnThemDM.BorderSize = 1;
            this.btnThemDM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemDM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDM.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDM.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemDM.ForeColor = System.Drawing.Color.Black;
            this.btnThemDM.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDM.Image")));
            this.btnThemDM.Location = new System.Drawing.Point(0, 253);
            this.btnThemDM.Name = "btnThemDM";
            this.btnThemDM.Size = new System.Drawing.Size(33, 31);
            this.btnThemDM.TabIndex = 3;
            this.btnThemDM.TextColor = System.Drawing.Color.Black;
            this.btnThemDM.UseHightLight = true;
            this.btnThemDM.UseVisualStyleBackColor = false;
            this.btnThemDM.Click += new System.EventHandler(this.btnThemDM_Click);
            // 
            // ucNgonNguDanhMuc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "ucNgonNguDanhMuc";
            this.Size = new System.Drawing.Size(699, 379);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNgonNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNgonNgu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMuc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhMucNgonNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhMucNgonNgu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panel1;
        private TPH.Controls.TPHNormalButton btnThemNgonNgu;
        private System.Windows.Forms.TextBox txtIDNgonNguMoi;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraGrid.GridControl gcNgonNgu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNgonNgu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgonNgu_IdNgonNgu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgonNgu_MoTa;
        private DevExpress.XtraGrid.GridControl gcDanhMuc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMuc_MaDanhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMuc_MoTa;
        private DevExpress.XtraEditors.PanelControl panel2;
        private System.Windows.Forms.ComboBox cboLoaiDanHmuc;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraGrid.GridControl gcDanhMucNgonNgu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhMucNgonNgu;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMucNgonNgu_MaDanhMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMucNgonNgu_NoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMucNgonNgu_IdNgonNgu;
        private DevExpress.XtraGrid.Columns.GridColumn colDanhMucNgonNgu_IDDanhMuc;
        private DevExpress.XtraEditors.PanelControl panel3;
        private TPH.Controls.TPHNormalButton btnXoaDM;
        private TPH.Controls.TPHNormalButton btnThemDM;
        private TPH.Controls.TPHNormalButton btnXoaNgonNgu;
        private TPH.Controls.TPHNormalButton btnDanhSachNgonNgu_DanhMuc;
        private TPH.Controls.TPHNormalButton btnLoadDSngonNgu;
    }
}
