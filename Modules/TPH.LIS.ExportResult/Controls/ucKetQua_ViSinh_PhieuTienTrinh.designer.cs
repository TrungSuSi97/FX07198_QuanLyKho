namespace TPH.LIS.ExportResult.Controls
{
    partial class ucKetQua_ViSinh_PhieuTienTrinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKetQua_ViSinh_PhieuTienTrinh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new TPH.Controls.TPHNormalButton();
            this.btnThongKe = new TPH.Controls.TPHNormalButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNgayBaoCao = new System.Windows.Forms.Label();
            this.gcResult = new DevExpress.XtraGrid.GridControl();
            this.gvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_Seq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_SoPhieuYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_MaBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_TenBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_Tuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_GioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_TenLoaiMauHis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPTT_TenYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 41);
            this.panel1.TabIndex = 40;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXuatExcel.BackColorHover = System.Drawing.Color.Empty;
            this.btnXuatExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXuatExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.BorderSize = 1;
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Black;
            this.btnXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Image")));
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(297, 2);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(127, 34);
            this.btnXuatExcel.TabIndex = 38;
            this.btnXuatExcel.Text = "Xuất excel ";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.TextColor = System.Drawing.Color.Black;
            this.btnXuatExcel.UseHightLight = true;
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThongKe.BackColorHover = System.Drawing.Color.Empty;
            this.btnThongKe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThongKe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThongKe.BorderRadius = 5;
            this.btnThongKe.BorderSize = 1;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(174, 3);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(105, 34);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.TextColor = System.Drawing.Color.Black;
            this.btnThongKe.UseHightLight = true;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(564, 22);
            this.lblTitle.TabIndex = 43;
            this.lblTitle.Text = "PHIẾU TIẾN TRÌNH VI SINH";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNgayBaoCao
            // 
            this.lblNgayBaoCao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNgayBaoCao.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBaoCao.Location = new System.Drawing.Point(0, 22);
            this.lblNgayBaoCao.Name = "lblNgayBaoCao";
            this.lblNgayBaoCao.Size = new System.Drawing.Size(564, 22);
            this.lblNgayBaoCao.TabIndex = 44;
            this.lblNgayBaoCao.Text = "Từ ngày - đến ngày";
            this.lblNgayBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gcResult
            // 
            this.gcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcResult.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcResult.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcResult.EmbeddedNavigator.TextStringFormat = "Dòng {0} của {1}";
            this.gcResult.Location = new System.Drawing.Point(0, 44);
            this.gcResult.MainView = this.gvResult;
            this.gcResult.Name = "gcResult";
            this.gcResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.gcResult.Size = new System.Drawing.Size(564, 199);
            this.gcResult.TabIndex = 45;
            this.gcResult.UseEmbeddedNavigator = true;
            this.gcResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResult,
            this.gridView2,
            this.gridView3,
            this.gridView4,
            this.tileView1});
            // 
            // gvResult
            // 
            this.gvResult.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.EvenRow.Options.UseFont = true;
            this.gvResult.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.FilterPanel.Options.UseFont = true;
            this.gvResult.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvResult.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvResult.Appearance.FocusedCell.Options.UseFont = true;
            this.gvResult.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.FocusedRow.Options.UseFont = true;
            this.gvResult.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvResult.Appearance.FooterPanel.Options.UseFont = true;
            this.gvResult.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.GroupButton.Options.UseFont = true;
            this.gvResult.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvResult.Appearance.GroupFooter.Options.UseFont = true;
            this.gvResult.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvResult.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvResult.Appearance.GroupRow.Options.UseFont = true;
            this.gvResult.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvResult.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvResult.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvResult.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.HorzLine.Options.UseFont = true;
            this.gvResult.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.OddRow.Options.UseFont = true;
            this.gvResult.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.Row.Options.UseFont = true;
            this.gvResult.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.RowSeparator.Options.UseFont = true;
            this.gvResult.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvResult.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvResult.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvResult.Appearance.SelectedRow.Options.UseFont = true;
            this.gvResult.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvResult.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.TopNewRow.Options.UseFont = true;
            this.gvResult.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvResult.Appearance.VertLine.Options.UseFont = true;
            this.gvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colPTT_Seq,
            this.colPTT_SoPhieuYeuCau,
            this.colPTT_MaBN,
            this.colPTT_TenBN,
            this.colPTT_Tuoi,
            this.colPTT_GioiTinh,
            this.colPTT_TenLoaiMauHis,
            this.gridColumn5,
            this.colPTT_TenYeuCau,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvResult.GridControl = this.gcResult;
            this.gvResult.Name = "gvResult";
            this.gvResult.OptionsView.AllowCellMerge = true;
            this.gvResult.OptionsView.ColumnAutoWidth = false;
            this.gvResult.OptionsView.RowAutoHeight = true;
            this.gvResult.OptionsView.ShowFooter = true;
            this.gvResult.OptionsView.ShowGroupPanel = false;
            this.gvResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gvResult_CellMerge);
            this.gvResult.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gvResult_CustomUnboundColumnData);
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 54;
            // 
            // colPTT_Seq
            // 
            this.colPTT_Seq.Caption = "Barcode";
            this.colPTT_Seq.FieldName = "Seq";
            this.colPTT_Seq.Name = "colPTT_Seq";
            this.colPTT_Seq.OptionsColumn.AllowEdit = false;
            this.colPTT_Seq.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_Seq.Visible = true;
            this.colPTT_Seq.VisibleIndex = 1;
            // 
            // colPTT_SoPhieuYeuCau
            // 
            this.colPTT_SoPhieuYeuCau.Caption = "Số phiếu chỉ định(HIS)";
            this.colPTT_SoPhieuYeuCau.FieldName = "SoPhieuYeuCau";
            this.colPTT_SoPhieuYeuCau.Name = "colPTT_SoPhieuYeuCau";
            this.colPTT_SoPhieuYeuCau.OptionsColumn.AllowEdit = false;
            this.colPTT_SoPhieuYeuCau.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_SoPhieuYeuCau.Visible = true;
            this.colPTT_SoPhieuYeuCau.VisibleIndex = 2;
            this.colPTT_SoPhieuYeuCau.Width = 133;
            // 
            // colPTT_MaBN
            // 
            this.colPTT_MaBN.Caption = "Mã bệnh nhân";
            this.colPTT_MaBN.FieldName = "MaBN";
            this.colPTT_MaBN.Name = "colPTT_MaBN";
            this.colPTT_MaBN.OptionsColumn.AllowEdit = false;
            this.colPTT_MaBN.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_MaBN.Visible = true;
            this.colPTT_MaBN.VisibleIndex = 3;
            this.colPTT_MaBN.Width = 93;
            // 
            // colPTT_TenBN
            // 
            this.colPTT_TenBN.Caption = "Họ tên người bệnh";
            this.colPTT_TenBN.FieldName = "TenBN";
            this.colPTT_TenBN.Name = "colPTT_TenBN";
            this.colPTT_TenBN.OptionsColumn.AllowEdit = false;
            this.colPTT_TenBN.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_TenBN.Visible = true;
            this.colPTT_TenBN.VisibleIndex = 4;
            this.colPTT_TenBN.Width = 215;
            // 
            // colPTT_Tuoi
            // 
            this.colPTT_Tuoi.Caption = "Tuổi";
            this.colPTT_Tuoi.FieldName = "Tuoi";
            this.colPTT_Tuoi.Name = "colPTT_Tuoi";
            this.colPTT_Tuoi.OptionsColumn.AllowEdit = false;
            this.colPTT_Tuoi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_Tuoi.Visible = true;
            this.colPTT_Tuoi.VisibleIndex = 5;
            // 
            // colPTT_GioiTinh
            // 
            this.colPTT_GioiTinh.Caption = "Giới tính";
            this.colPTT_GioiTinh.FieldName = "GioiTinh";
            this.colPTT_GioiTinh.Name = "colPTT_GioiTinh";
            this.colPTT_GioiTinh.OptionsColumn.AllowEdit = false;
            this.colPTT_GioiTinh.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_GioiTinh.Visible = true;
            this.colPTT_GioiTinh.VisibleIndex = 6;
            // 
            // colPTT_TenLoaiMauHis
            // 
            this.colPTT_TenLoaiMauHis.Caption = "Loại bệnh phẩm";
            this.colPTT_TenLoaiMauHis.FieldName = "TenLoaiMauHis";
            this.colPTT_TenLoaiMauHis.Name = "colPTT_TenLoaiMauHis";
            this.colPTT_TenLoaiMauHis.OptionsColumn.AllowEdit = false;
            this.colPTT_TenLoaiMauHis.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_TenLoaiMauHis.Visible = true;
            this.colPTT_TenLoaiMauHis.VisibleIndex = 7;
            this.colPTT_TenLoaiMauHis.Width = 100;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mã số mẫu";
            this.gridColumn5.FieldName = "MaSoMau";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            // 
            // colPTT_TenYeuCau
            // 
            this.colPTT_TenYeuCau.Caption = "Tên chỉ định";
            this.colPTT_TenYeuCau.FieldName = "TenYeuCau";
            this.colPTT_TenYeuCau.Name = "colPTT_TenYeuCau";
            this.colPTT_TenYeuCau.OptionsColumn.AllowEdit = false;
            this.colPTT_TenYeuCau.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPTT_TenYeuCau.Visible = true;
            this.colPTT_TenYeuCau.VisibleIndex = 9;
            this.colPTT_TenYeuCau.Width = 220;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Nội dung thực hiện";
            this.gridColumn9.FieldName = "NoiDung";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 238;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Người thực hiện";
            this.gridColumn10.FieldName = "NguoiThucHien";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            this.gridColumn10.Width = 176;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Thời gian thực hiện";
            this.gridColumn11.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn11.FieldName = "ThoiGianThucHien";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            this.gridColumn11.Width = 120;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gcResult;
            this.gridView2.Name = "gridView2";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gcResult;
            this.gridView3.Name = "gridView3";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView4.GridControl = this.gcResult;
            this.gridView4.Name = "gridView4";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ngày tiếp  nhận";
            this.gridColumn3.FieldName = "NgayTiepNhan";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tên BN";
            this.gridColumn6.FieldName = "TenBN";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Năm sinh";
            this.gridColumn7.FieldName = "namsinh";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // tileView1
            // 
            this.tileView1.GridControl = this.gcResult;
            this.tileView1.Name = "tileView1";
            // 
            // ucKetQua_ViSinh_PhieuTienTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcResult);
            this.Controls.Add(this.lblNgayBaoCao);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Name = "ucKetQua_ViSinh_PhieuTienTrinh";
            this.Size = new System.Drawing.Size(564, 284);
            this.Load += new System.EventHandler(this.ucKetQua_ViSinh_PhieuTienTrinh_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnXuatExcel;
        private TPH.Controls.TPHNormalButton btnThongKe;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNgayBaoCao;
        private DevExpress.XtraGrid.GridControl gcResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResult;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_Seq;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_SoPhieuYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_MaBN;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_TenBN;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_Tuoi;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_GioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_TenLoaiMauHis;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colPTT_TenYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
    }
}
