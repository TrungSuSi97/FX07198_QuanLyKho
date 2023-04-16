namespace TPH.LIS.ExportResult.Controls
{
    partial class ucKetQua_TongHop_HIV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKetQua_TongHop_HIV));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new TPH.Controls.TPHNormalButton();
            this.btnThongKe = new TPH.Controls.TPHNormalButton();
            this.gcCTXN = new DevExpress.XtraGrid.GridControl();
            this.gvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTXN_TenBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoiTuongXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTGInDauTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPXetNghiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKetLuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKQKhangDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gcCTXN)).BeginInit();
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
            this.panel1.Location = new System.Drawing.Point(0, 272);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 53);
            this.panel1.TabIndex = 37;
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
            this.btnXuatExcel.Location = new System.Drawing.Point(290, 9);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(108, 35);
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
            this.btnThongKe.Location = new System.Drawing.Point(166, 9);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(108, 35);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.TextColor = System.Drawing.Color.Black;
            this.btnThongKe.UseHightLight = true;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // gcCTXN
            // 
            this.gcCTXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCTXN.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcCTXN.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcCTXN.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcCTXN.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcCTXN.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcCTXN.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcCTXN.EmbeddedNavigator.TextStringFormat = "Dòng {0} của {1}";
            this.gcCTXN.Location = new System.Drawing.Point(0, 0);
            this.gcCTXN.MainView = this.gvResult;
            this.gcCTXN.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcCTXN.Name = "gcCTXN";
            this.gcCTXN.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemMemoEdit1});
            this.gcCTXN.Size = new System.Drawing.Size(564, 272);
            this.gcCTXN.TabIndex = 38;
            this.gcCTXN.UseEmbeddedNavigator = true;
            this.gcCTXN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.colCTXN_TenBN,
            this.colBarcode,
            this.colNam,
            this.colNu,
            this.colDiaChi,
            this.colDoiTuongXN,
            this.colNgayTiepNhan,
            this.colTGInDauTien,
            this.colSPXetNghiem,
            this.colKetLuan,
            this.colKQKhangDinh,
            this.colNGhiChu});
            this.gvResult.DetailHeight = 284;
            this.gvResult.GridControl = this.gcCTXN;
            this.gvResult.Name = "gvResult";
            this.gvResult.OptionsView.ColumnAutoWidth = false;
            this.gvResult.OptionsView.RowAutoHeight = true;
            this.gvResult.OptionsView.ShowFooter = true;
            this.gvResult.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.MinWidth = 17;
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowEdit = false;
            this.colSTT.OptionsColumn.ReadOnly = true;
            this.colSTT.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 46;
            // 
            // colCTXN_TenBN
            // 
            this.colCTXN_TenBN.Caption = "Họ tên";
            this.colCTXN_TenBN.FieldName = "TenBN";
            this.colCTXN_TenBN.MinWidth = 10;
            this.colCTXN_TenBN.Name = "colCTXN_TenBN";
            this.colCTXN_TenBN.OptionsColumn.AllowEdit = false;
            this.colCTXN_TenBN.Visible = true;
            this.colCTXN_TenBN.VisibleIndex = 1;
            this.colCTXN_TenBN.Width = 184;
            // 
            // colBarcode
            // 
            this.colBarcode.Caption = "Mã số";
            this.colBarcode.FieldName = "Seq";
            this.colBarcode.MinWidth = 10;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.OptionsColumn.ReadOnly = true;
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 2;
            this.colBarcode.Width = 95;
            // 
            // colNam
            // 
            this.colNam.Caption = "Nam";
            this.colNam.FieldName = "NamSinhNam";
            this.colNam.MinWidth = 17;
            this.colNam.Name = "colNam";
            this.colNam.OptionsColumn.AllowEdit = false;
            this.colNam.Visible = true;
            this.colNam.VisibleIndex = 3;
            this.colNam.Width = 64;
            // 
            // colNu
            // 
            this.colNu.Caption = "Nữ";
            this.colNu.FieldName = "NamSinhNu";
            this.colNu.MinWidth = 17;
            this.colNu.Name = "colNu";
            this.colNu.OptionsColumn.AllowEdit = false;
            this.colNu.Visible = true;
            this.colNu.VisibleIndex = 4;
            this.colNu.Width = 84;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.MinWidth = 17;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 5;
            this.colDiaChi.Width = 161;
            // 
            // colDoiTuongXN
            // 
            this.colDoiTuongXN.Caption = "Đối tượng";
            this.colDoiTuongXN.FieldName = "DoiTuong";
            this.colDoiTuongXN.MinWidth = 17;
            this.colDoiTuongXN.Name = "colDoiTuongXN";
            this.colDoiTuongXN.OptionsColumn.AllowEdit = false;
            this.colDoiTuongXN.Visible = true;
            this.colDoiTuongXN.VisibleIndex = 6;
            this.colDoiTuongXN.Width = 197;
            // 
            // colNgayTiepNhan
            // 
            this.colNgayTiepNhan.Caption = "Ngày lấy mẫu";
            this.colNgayTiepNhan.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayTiepNhan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayTiepNhan.FieldName = "NgayTiepNhan";
            this.colNgayTiepNhan.MinWidth = 17;
            this.colNgayTiepNhan.Name = "colNgayTiepNhan";
            this.colNgayTiepNhan.OptionsColumn.AllowEdit = false;
            this.colNgayTiepNhan.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colNgayTiepNhan.Visible = true;
            this.colNgayTiepNhan.VisibleIndex = 7;
            this.colNgayTiepNhan.Width = 121;
            // 
            // colTGInDauTien
            // 
            this.colTGInDauTien.Caption = "Ngày xét nghiệm";
            this.colTGInDauTien.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colTGInDauTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTGInDauTien.FieldName = "ThoiGianInDauTien";
            this.colTGInDauTien.MinWidth = 17;
            this.colTGInDauTien.Name = "colTGInDauTien";
            this.colTGInDauTien.OptionsColumn.AllowEdit = false;
            this.colTGInDauTien.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.colTGInDauTien.Visible = true;
            this.colTGInDauTien.VisibleIndex = 8;
            this.colTGInDauTien.Width = 147;
            // 
            // colSPXetNghiem
            // 
            this.colSPXetNghiem.Caption = "SP (ghi rõ tên sinh phẩm)";
            this.colSPXetNghiem.FieldName = "XetNghiem";
            this.colSPXetNghiem.MinWidth = 17;
            this.colSPXetNghiem.Name = "colSPXetNghiem";
            this.colSPXetNghiem.OptionsColumn.AllowEdit = false;
            this.colSPXetNghiem.OptionsColumn.ReadOnly = true;
            this.colSPXetNghiem.Visible = true;
            this.colSPXetNghiem.VisibleIndex = 9;
            this.colSPXetNghiem.Width = 160;
            // 
            // colKetLuan
            // 
            this.colKetLuan.Caption = "Kết luận";
            this.colKetLuan.FieldName = "KetLuan";
            this.colKetLuan.MinWidth = 17;
            this.colKetLuan.Name = "colKetLuan";
            this.colKetLuan.Visible = true;
            this.colKetLuan.VisibleIndex = 10;
            this.colKetLuan.Width = 133;
            // 
            // colKQKhangDinh
            // 
            this.colKQKhangDinh.Caption = "Kết quả khẳng định";
            this.colKQKhangDinh.FieldName = "KQKhangDinh";
            this.colKQKhangDinh.MinWidth = 17;
            this.colKQKhangDinh.Name = "colKQKhangDinh";
            this.colKQKhangDinh.OptionsColumn.AllowEdit = false;
            this.colKQKhangDinh.Visible = true;
            this.colKQKhangDinh.VisibleIndex = 11;
            this.colKQKhangDinh.Width = 141;
            // 
            // colNGhiChu
            // 
            this.colNGhiChu.Caption = "Ghi chú";
            this.colNGhiChu.MinWidth = 17;
            this.colNGhiChu.Name = "colNGhiChu";
            this.colNGhiChu.OptionsColumn.AllowEdit = false;
            this.colNGhiChu.Visible = true;
            this.colNGhiChu.VisibleIndex = 12;
            this.colNGhiChu.Width = 112;
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
            this.gridView2.DetailHeight = 284;
            this.gridView2.GridControl = this.gcCTXN;
            this.gridView2.Name = "gridView2";
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 284;
            this.gridView3.GridControl = this.gcCTXN;
            this.gridView3.Name = "gridView3";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7});
            this.gridView4.DetailHeight = 284;
            this.gridView4.GridControl = this.gcCTXN;
            this.gridView4.Name = "gridView4";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ngày tiếp  nhận";
            this.gridColumn3.FieldName = "NgayTiepNhan";
            this.gridColumn3.MinWidth = 17;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 64;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tên BN";
            this.gridColumn6.FieldName = "TenBN";
            this.gridColumn6.MinWidth = 17;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 64;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Năm sinh";
            this.gridColumn7.FieldName = "namsinh";
            this.gridColumn7.MinWidth = 17;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 64;
            // 
            // tileView1
            // 
            this.tileView1.DetailHeight = 284;
            this.tileView1.GridControl = this.gcCTXN;
            this.tileView1.Name = "tileView1";
            // 
            // ucKetQua_TongHop_HIV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcCTXN);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucKetQua_TongHop_HIV";
            this.Size = new System.Drawing.Size(564, 325);
            this.Load += new System.EventHandler(this.ucKetQua_TongHop_HIV_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCTXN)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcCTXN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResult;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colCTXN_TenBN;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colNu;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colTGInDauTien;
        private DevExpress.XtraGrid.Columns.GridColumn colKetLuan;
        private DevExpress.XtraGrid.Columns.GridColumn colKQKhangDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colSPXetNghiem;
        private DevExpress.XtraGrid.Columns.GridColumn colNGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNam;
        private DevExpress.XtraGrid.Columns.GridColumn colDoiTuongXN;
    }
}
