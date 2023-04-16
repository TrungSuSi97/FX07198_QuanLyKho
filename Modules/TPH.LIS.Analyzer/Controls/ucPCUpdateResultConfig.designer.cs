namespace TPH.LIS.Analyzer.Controls
{
    partial class ucPCUpdateResultConfig
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcDanhSachMayTinh = new DevExpress.XtraGrid.GridControl();
            this.gvDSMayTinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenMayTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaKhuVuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhuVuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRequestUpdate = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnViewFileInfo = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcMayXN = new DevExpress.XtraGrid.GridControl();
            this.gvMayXN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDMayXn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xolTenMayXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoamayXetNghiem = new System.Windows.Forms.Button();
            this.btnThemMayXn = new System.Windows.Forms.Button();
            this.gcMayXnKhaiBao = new DevExpress.XtraGrid.GridControl();
            this.gvMayXnKhaiBao = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMayXnKhaiBao_IdMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayXnKhaiBao_TenMay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayXnKhaiBao_TgNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayXnKhaiBao_NguoiNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayXnKhaiBao_Makhuvuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayXnKhaiBao_TenMayTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachMayTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSMayTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRequestUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXN)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXnKhaiBao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXnKhaiBao)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 510);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcDanhSachMayTinh);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcMayXN);
            this.splitContainer1.Size = new System.Drawing.Size(364, 510);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // gcDanhSachMayTinh
            // 
            this.gcDanhSachMayTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachMayTinh.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSachMayTinh.MainView = this.gvDSMayTinh;
            this.gcDanhSachMayTinh.Name = "gcDanhSachMayTinh";
            this.gcDanhSachMayTinh.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnRequestUpdate,
            this.btnViewFileInfo});
            this.gcDanhSachMayTinh.Size = new System.Drawing.Size(364, 239);
            this.gcDanhSachMayTinh.TabIndex = 1;
            this.gcDanhSachMayTinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDSMayTinh});
            // 
            // gvDSMayTinh
            // 
            this.gvDSMayTinh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvDSMayTinh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDSMayTinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenMayTinh,
            this.colMaKhuVuc,
            this.colTenKhuVuc});
            this.gvDSMayTinh.GridControl = this.gcDanhSachMayTinh;
            this.gvDSMayTinh.GroupCount = 1;
            this.gvDSMayTinh.Name = "gvDSMayTinh";
            this.gvDSMayTinh.OptionsView.ColumnAutoWidth = false;
            this.gvDSMayTinh.OptionsView.ShowAutoFilterRow = true;
            this.gvDSMayTinh.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gvDSMayTinh.OptionsView.ShowGroupPanel = false;
            this.gvDSMayTinh.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTenKhuVuc, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDSMayTinh.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDSMayTinh_FocusedRowChanged);
            this.gvDSMayTinh.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvDSMayTinh_FocusedColumnChanged);
            // 
            // colTenMayTinh
            // 
            this.colTenMayTinh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colTenMayTinh.AppearanceCell.Options.UseFont = true;
            this.colTenMayTinh.Caption = "Máy Tính";
            this.colTenMayTinh.FieldName = "TenMayTinh";
            this.colTenMayTinh.Name = "colTenMayTinh";
            this.colTenMayTinh.OptionsColumn.ReadOnly = true;
            this.colTenMayTinh.Visible = true;
            this.colTenMayTinh.VisibleIndex = 0;
            this.colTenMayTinh.Width = 325;
            // 
            // colMaKhuVuc
            // 
            this.colMaKhuVuc.Caption = "Mã khuc vực";
            this.colMaKhuVuc.FieldName = "MaKhuVuc";
            this.colMaKhuVuc.Name = "colMaKhuVuc";
            this.colMaKhuVuc.Width = 63;
            // 
            // colTenKhuVuc
            // 
            this.colTenKhuVuc.Caption = "Khu vực";
            this.colTenKhuVuc.FieldName = "TenKhuVuc";
            this.colTenKhuVuc.Name = "colTenKhuVuc";
            this.colTenKhuVuc.OptionsColumn.AllowEdit = false;
            this.colTenKhuVuc.Visible = true;
            this.colTenKhuVuc.VisibleIndex = 2;
            this.colTenKhuVuc.Width = 194;
            // 
            // btnRequestUpdate
            // 
            this.btnRequestUpdate.AutoHeight = false;
            this.btnRequestUpdate.Name = "btnRequestUpdate";
            this.btnRequestUpdate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // btnViewFileInfo
            // 
            this.btnViewFileInfo.AutoHeight = false;
            this.btnViewFileInfo.Name = "btnViewFileInfo";
            this.btnViewFileInfo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gcMayXN
            // 
            this.gcMayXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMayXN.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcMayXN.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcMayXN.Location = new System.Drawing.Point(0, 0);
            this.gcMayXN.MainView = this.gvMayXN;
            this.gcMayXN.Name = "gcMayXN";
            this.gcMayXN.Size = new System.Drawing.Size(364, 267);
            this.gcMayXN.TabIndex = 361;
            this.gcMayXN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMayXN});
            // 
            // gvMayXN
            // 
            this.gvMayXN.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvMayXN.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvMayXN.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvMayXN.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.DetailTip.Options.UseFont = true;
            this.gvMayXN.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.Empty.Options.UseFont = true;
            this.gvMayXN.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.EvenRow.Options.UseFont = true;
            this.gvMayXN.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvMayXN.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FilterPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.FixedLine.Options.UseFont = true;
            this.gvMayXN.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvMayXN.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvMayXN.Appearance.FocusedCell.Options.UseFont = true;
            this.gvMayXN.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.FocusedRow.Options.UseFont = true;
            this.gvMayXN.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.FooterPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupButton.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupFooter.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXN.Appearance.GroupPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvMayXN.Appearance.GroupRow.Options.UseFont = true;
            this.gvMayXN.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvMayXN.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXN.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMayXN.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvMayXN.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.HorzLine.Options.UseFont = true;
            this.gvMayXN.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.OddRow.Options.UseFont = true;
            this.gvMayXN.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.Preview.Options.UseFont = true;
            this.gvMayXN.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.Row.Options.UseFont = true;
            this.gvMayXN.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.RowSeparator.Options.UseFont = true;
            this.gvMayXN.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvMayXN.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvMayXN.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMayXN.Appearance.SelectedRow.Options.UseFont = true;
            this.gvMayXN.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvMayXN.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.TopNewRow.Options.UseFont = true;
            this.gvMayXN.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.VertLine.Options.UseFont = true;
            this.gvMayXN.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXN.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMayXN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDMayXn,
            this.xolTenMayXN});
            this.gvMayXN.GridControl = this.gcMayXN;
            this.gvMayXN.Name = "gvMayXN";
            this.gvMayXN.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvMayXN.OptionsSelection.MultiSelect = true;
            this.gvMayXN.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvMayXN.OptionsView.ColumnAutoWidth = false;
            this.gvMayXN.OptionsView.RowAutoHeight = true;
            this.gvMayXN.OptionsView.ShowAutoFilterRow = true;
            this.gvMayXN.OptionsView.ShowGroupPanel = false;
            // 
            // colIDMayXn
            // 
            this.colIDMayXn.Caption = "ID Máy XN";
            this.colIDMayXn.FieldName = "idmay";
            this.colIDMayXn.Name = "colIDMayXn";
            this.colIDMayXn.OptionsColumn.AllowEdit = false;
            this.colIDMayXn.OptionsColumn.ReadOnly = true;
            this.colIDMayXn.Visible = true;
            this.colIDMayXn.VisibleIndex = 1;
            this.colIDMayXn.Width = 72;
            // 
            // xolTenMayXN
            // 
            this.xolTenMayXN.Caption = "Tên máy xét nghiệm";
            this.xolTenMayXN.FieldName = "tenmay";
            this.xolTenMayXN.Name = "xolTenMayXN";
            this.xolTenMayXN.OptionsColumn.AllowEdit = false;
            this.xolTenMayXN.OptionsColumn.ReadOnly = true;
            this.xolTenMayXN.Visible = true;
            this.xolTenMayXN.VisibleIndex = 2;
            this.xolTenMayXN.Width = 190;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoamayXetNghiem);
            this.panel2.Controls.Add(this.btnThemMayXn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(364, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(42, 510);
            this.panel2.TabIndex = 1;
            // 
            // btnXoamayXetNghiem
            // 
            this.btnXoamayXetNghiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXoamayXetNghiem.Location = new System.Drawing.Point(2, 252);
            this.btnXoamayXetNghiem.Name = "btnXoamayXetNghiem";
            this.btnXoamayXetNghiem.Size = new System.Drawing.Size(39, 23);
            this.btnXoamayXetNghiem.TabIndex = 1;
            this.btnXoamayXetNghiem.Text = "<<";
            this.btnXoamayXetNghiem.UseVisualStyleBackColor = true;
            this.btnXoamayXetNghiem.Click += new System.EventHandler(this.btnXoamayXetNghiem_Click);
            // 
            // btnThemMayXn
            // 
            this.btnThemMayXn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnThemMayXn.Location = new System.Drawing.Point(2, 216);
            this.btnThemMayXn.Name = "btnThemMayXn";
            this.btnThemMayXn.Size = new System.Drawing.Size(39, 23);
            this.btnThemMayXn.TabIndex = 0;
            this.btnThemMayXn.Text = ">>";
            this.btnThemMayXn.UseVisualStyleBackColor = true;
            this.btnThemMayXn.Click += new System.EventHandler(this.btnThemMayXn_Click);
            // 
            // gcMayXnKhaiBao
            // 
            this.gcMayXnKhaiBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMayXnKhaiBao.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcMayXnKhaiBao.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcMayXnKhaiBao.Location = new System.Drawing.Point(406, 22);
            this.gcMayXnKhaiBao.MainView = this.gvMayXnKhaiBao;
            this.gcMayXnKhaiBao.Name = "gcMayXnKhaiBao";
            this.gcMayXnKhaiBao.Size = new System.Drawing.Size(329, 488);
            this.gcMayXnKhaiBao.TabIndex = 362;
            this.gcMayXnKhaiBao.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMayXnKhaiBao});
            // 
            // gvMayXnKhaiBao
            // 
            this.gvMayXnKhaiBao.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.DetailTip.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.Empty.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.EvenRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.FilterPanel.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.FixedLine.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvMayXnKhaiBao.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvMayXnKhaiBao.Appearance.FocusedCell.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.FocusedRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXnKhaiBao.Appearance.FooterPanel.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXnKhaiBao.Appearance.GroupButton.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXnKhaiBao.Appearance.GroupFooter.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvMayXnKhaiBao.Appearance.GroupPanel.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXnKhaiBao.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvMayXnKhaiBao.Appearance.GroupRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvMayXnKhaiBao.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvMayXnKhaiBao.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.HorzLine.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.OddRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.Preview.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.Row.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.RowSeparator.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvMayXnKhaiBao.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvMayXnKhaiBao.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvMayXnKhaiBao.Appearance.SelectedRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvMayXnKhaiBao.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.TopNewRow.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.VertLine.Options.UseFont = true;
            this.gvMayXnKhaiBao.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvMayXnKhaiBao.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMayXnKhaiBao.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMayXnKhaiBao_IdMay,
            this.colMayXnKhaiBao_TenMay,
            this.colMayXnKhaiBao_TgNhap,
            this.colMayXnKhaiBao_NguoiNhap,
            this.colMayXnKhaiBao_Makhuvuc,
            this.colMayXnKhaiBao_TenMayTinh});
            this.gvMayXnKhaiBao.GridControl = this.gcMayXnKhaiBao;
            this.gvMayXnKhaiBao.Name = "gvMayXnKhaiBao";
            this.gvMayXnKhaiBao.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvMayXnKhaiBao.OptionsSelection.MultiSelect = true;
            this.gvMayXnKhaiBao.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvMayXnKhaiBao.OptionsView.ColumnAutoWidth = false;
            this.gvMayXnKhaiBao.OptionsView.RowAutoHeight = true;
            this.gvMayXnKhaiBao.OptionsView.ShowAutoFilterRow = true;
            this.gvMayXnKhaiBao.OptionsView.ShowGroupPanel = false;
            // 
            // colMayXnKhaiBao_IdMay
            // 
            this.colMayXnKhaiBao_IdMay.Caption = "ID Máy XN";
            this.colMayXnKhaiBao_IdMay.FieldName = "idmayxetnghiem";
            this.colMayXnKhaiBao_IdMay.Name = "colMayXnKhaiBao_IdMay";
            this.colMayXnKhaiBao_IdMay.OptionsColumn.AllowEdit = false;
            this.colMayXnKhaiBao_IdMay.OptionsColumn.ReadOnly = true;
            this.colMayXnKhaiBao_IdMay.Visible = true;
            this.colMayXnKhaiBao_IdMay.VisibleIndex = 1;
            this.colMayXnKhaiBao_IdMay.Width = 72;
            // 
            // colMayXnKhaiBao_TenMay
            // 
            this.colMayXnKhaiBao_TenMay.Caption = "Tên máy xét nghiệm";
            this.colMayXnKhaiBao_TenMay.FieldName = "tenmay";
            this.colMayXnKhaiBao_TenMay.Name = "colMayXnKhaiBao_TenMay";
            this.colMayXnKhaiBao_TenMay.OptionsColumn.AllowEdit = false;
            this.colMayXnKhaiBao_TenMay.OptionsColumn.ReadOnly = true;
            this.colMayXnKhaiBao_TenMay.Visible = true;
            this.colMayXnKhaiBao_TenMay.VisibleIndex = 2;
            this.colMayXnKhaiBao_TenMay.Width = 190;
            // 
            // colMayXnKhaiBao_TgNhap
            // 
            this.colMayXnKhaiBao_TgNhap.Caption = "TG nhập";
            this.colMayXnKhaiBao_TgNhap.FieldName = "thoigiannhap";
            this.colMayXnKhaiBao_TgNhap.Name = "colMayXnKhaiBao_TgNhap";
            this.colMayXnKhaiBao_TgNhap.OptionsColumn.AllowEdit = false;
            this.colMayXnKhaiBao_TgNhap.OptionsColumn.ReadOnly = true;
            this.colMayXnKhaiBao_TgNhap.Visible = true;
            this.colMayXnKhaiBao_TgNhap.VisibleIndex = 5;
            this.colMayXnKhaiBao_TgNhap.Width = 120;
            // 
            // colMayXnKhaiBao_NguoiNhap
            // 
            this.colMayXnKhaiBao_NguoiNhap.Caption = "Người nhập";
            this.colMayXnKhaiBao_NguoiNhap.FieldName = "nguoinhap";
            this.colMayXnKhaiBao_NguoiNhap.Name = "colMayXnKhaiBao_NguoiNhap";
            this.colMayXnKhaiBao_NguoiNhap.OptionsColumn.AllowEdit = false;
            this.colMayXnKhaiBao_NguoiNhap.OptionsColumn.ReadOnly = true;
            this.colMayXnKhaiBao_NguoiNhap.Visible = true;
            this.colMayXnKhaiBao_NguoiNhap.VisibleIndex = 6;
            this.colMayXnKhaiBao_NguoiNhap.Width = 210;
            // 
            // colMayXnKhaiBao_Makhuvuc
            // 
            this.colMayXnKhaiBao_Makhuvuc.Caption = "Mã khu vực";
            this.colMayXnKhaiBao_Makhuvuc.FieldName = "makhuvuc";
            this.colMayXnKhaiBao_Makhuvuc.Name = "colMayXnKhaiBao_Makhuvuc";
            this.colMayXnKhaiBao_Makhuvuc.OptionsColumn.AllowEdit = false;
            this.colMayXnKhaiBao_Makhuvuc.OptionsColumn.ReadOnly = true;
            this.colMayXnKhaiBao_Makhuvuc.Visible = true;
            this.colMayXnKhaiBao_Makhuvuc.VisibleIndex = 3;
            // 
            // colMayXnKhaiBao_TenMayTinh
            // 
            this.colMayXnKhaiBao_TenMayTinh.Caption = "Tên máy tính";
            this.colMayXnKhaiBao_TenMayTinh.FieldName = "tenmaytinh";
            this.colMayXnKhaiBao_TenMayTinh.Name = "colMayXnKhaiBao_TenMayTinh";
            this.colMayXnKhaiBao_TenMayTinh.OptionsColumn.AllowEdit = false;
            this.colMayXnKhaiBao_TenMayTinh.OptionsColumn.ReadOnly = true;
            this.colMayXnKhaiBao_TenMayTinh.Visible = true;
            this.colMayXnKhaiBao_TenMayTinh.VisibleIndex = 4;
            this.colMayXnKhaiBao_TenMayTinh.Width = 109;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(406, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(329, 22);
            this.label3.TabIndex = 363;
            this.label3.Text = "Máy xét nghiệm đã khai báo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucPCUpdateResultConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMayXnKhaiBao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucPCUpdateResultConfig";
            this.Size = new System.Drawing.Size(735, 510);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachMayTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSMayTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRequestUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXN)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMayXnKhaiBao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMayXnKhaiBao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gcDanhSachMayTinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDSMayTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenMayTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKhuVuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhuVuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRequestUpdate;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnViewFileInfo;
        private DevExpress.XtraGrid.GridControl gcMayXN;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMayXN;
        private DevExpress.XtraGrid.Columns.GridColumn colIDMayXn;
        private DevExpress.XtraGrid.Columns.GridColumn xolTenMayXN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoamayXetNghiem;
        private System.Windows.Forms.Button btnThemMayXn;
        private DevExpress.XtraGrid.GridControl gcMayXnKhaiBao;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMayXnKhaiBao;
        private DevExpress.XtraGrid.Columns.GridColumn colMayXnKhaiBao_IdMay;
        private DevExpress.XtraGrid.Columns.GridColumn colMayXnKhaiBao_TenMay;
        public System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn colMayXnKhaiBao_TgNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colMayXnKhaiBao_NguoiNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colMayXnKhaiBao_Makhuvuc;
        private DevExpress.XtraGrid.Columns.GridColumn colMayXnKhaiBao_TenMayTinh;
    }
}
