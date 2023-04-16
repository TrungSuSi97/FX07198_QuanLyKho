namespace TPH.LIS.Statistic.Controls
{
    partial class ucTongHopBenhNhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTongHopBenhNhan));
            this.gcKetQua = new DevExpress.XtraGrid.GridControl();
            this.gvKetQua = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNgayXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmatiepnhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMabn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBacSiCD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDoiTuongDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongTienTheoDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBenhNhan_KhoaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongTienBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChietKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXuatExcel = new TPH.Controls.TPHNormalButton();
            this.btnThongKe = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKetQua)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcKetQua
            // 
            this.gcKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKetQua.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcKetQua.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcKetQua.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcKetQua.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcKetQua.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcKetQua.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcKetQua.EmbeddedNavigator.TextStringFormat = "Dòng {0}/{1}";
            this.gcKetQua.Location = new System.Drawing.Point(0, 0);
            this.gcKetQua.MainView = this.gvKetQua;
            this.gcKetQua.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.gcKetQua.Name = "gcKetQua";
            this.gcKetQua.Size = new System.Drawing.Size(564, 282);
            this.gcKetQua.TabIndex = 35;
            this.gcKetQua.UseEmbeddedNavigator = true;
            this.gcKetQua.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKetQua});
            // 
            // gvKetQua
            // 
            this.gvKetQua.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.EvenRow.Options.UseFont = true;
            this.gvKetQua.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.FilterPanel.Options.UseFont = true;
            this.gvKetQua.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvKetQua.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvKetQua.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvKetQua.Appearance.FocusedCell.Options.UseFont = true;
            this.gvKetQua.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvKetQua.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.FocusedRow.Options.UseFont = true;
            this.gvKetQua.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKetQua.Appearance.FooterPanel.Options.UseFont = true;
            this.gvKetQua.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.GroupButton.Options.UseFont = true;
            this.gvKetQua.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKetQua.Appearance.GroupFooter.Options.UseFont = true;
            this.gvKetQua.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKetQua.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvKetQua.Appearance.GroupRow.Options.UseFont = true;
            this.gvKetQua.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvKetQua.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKetQua.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvKetQua.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvKetQua.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.HorzLine.Options.UseFont = true;
            this.gvKetQua.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.OddRow.Options.UseFont = true;
            this.gvKetQua.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.Row.Options.UseFont = true;
            this.gvKetQua.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.RowSeparator.Options.UseFont = true;
            this.gvKetQua.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvKetQua.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKetQua.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvKetQua.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvKetQua.Appearance.SelectedRow.Options.UseFont = true;
            this.gvKetQua.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvKetQua.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.TopNewRow.Options.UseFont = true;
            this.gvKetQua.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKetQua.Appearance.VertLine.Options.UseFont = true;
            this.gvKetQua.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgayXN,
            this.colmatiepnhan,
            this.colMabn,
            this.colTenBN,
            this.colTuoi,
            this.colGioiTinh,
            this.colDiaChi,
            this.colBacSiCD,
            this.colTenDoiTuongDichVu,
            this.colTongTienTheoDV,
            this.colBenhNhan_KhoaPhong,
            this.colTongTienBN,
            this.colChietKhau});
            this.gvKetQua.DetailHeight = 284;
            this.gvKetQua.GridControl = this.gcKetQua;
            this.gvKetQua.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTienTheoDV", this.colTongTienTheoDV, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTien", this.colTongTienBN, "{0:N0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", this.colChietKhau, "{0:N0}")});
            this.gvKetQua.Name = "gvKetQua";
            this.gvKetQua.OptionsSelection.MultiSelect = true;
            this.gvKetQua.OptionsView.ColumnAutoWidth = false;
            this.gvKetQua.OptionsView.ShowFooter = true;
            this.gvKetQua.OptionsView.ShowGroupPanel = false;
            // 
            // colNgayXN
            // 
            this.colNgayXN.Caption = "Ngày xét nghiệm";
            this.colNgayXN.DisplayFormat.FormatString = "{0:dd/MM/yyyy}";
            this.colNgayXN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayXN.FieldName = "NgayTiepNhan";
            this.colNgayXN.MinWidth = 17;
            this.colNgayXN.Name = "colNgayXN";
            this.colNgayXN.OptionsColumn.AllowEdit = false;
            this.colNgayXN.OptionsColumn.ReadOnly = true;
            this.colNgayXN.Visible = true;
            this.colNgayXN.VisibleIndex = 0;
            this.colNgayXN.Width = 87;
            // 
            // colmatiepnhan
            // 
            this.colmatiepnhan.Caption = "SID";
            this.colmatiepnhan.FieldName = "matiepnhan";
            this.colmatiepnhan.MinWidth = 17;
            this.colmatiepnhan.Name = "colmatiepnhan";
            this.colmatiepnhan.OptionsColumn.AllowEdit = false;
            this.colmatiepnhan.OptionsColumn.ReadOnly = true;
            this.colmatiepnhan.Visible = true;
            this.colmatiepnhan.VisibleIndex = 1;
            this.colmatiepnhan.Width = 95;
            // 
            // colMabn
            // 
            this.colMabn.Caption = "Mã BN";
            this.colMabn.FieldName = "mabn";
            this.colMabn.MinWidth = 17;
            this.colMabn.Name = "colMabn";
            this.colMabn.OptionsColumn.AllowEdit = false;
            this.colMabn.OptionsColumn.ReadOnly = true;
            this.colMabn.Visible = true;
            this.colMabn.VisibleIndex = 2;
            this.colMabn.Width = 105;
            // 
            // colTenBN
            // 
            this.colTenBN.Caption = "Tên bệnh nhân";
            this.colTenBN.FieldName = "TenBN";
            this.colTenBN.MinWidth = 17;
            this.colTenBN.Name = "colTenBN";
            this.colTenBN.OptionsColumn.AllowEdit = false;
            this.colTenBN.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTenBN.OptionsColumn.ReadOnly = true;
            this.colTenBN.Visible = true;
            this.colTenBN.VisibleIndex = 3;
            this.colTenBN.Width = 128;
            // 
            // colTuoi
            // 
            this.colTuoi.Caption = "Năm sinh";
            this.colTuoi.FieldName = "Tuoi";
            this.colTuoi.MinWidth = 17;
            this.colTuoi.Name = "colTuoi";
            this.colTuoi.OptionsColumn.AllowEdit = false;
            this.colTuoi.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTuoi.OptionsColumn.ReadOnly = true;
            this.colTuoi.Visible = true;
            this.colTuoi.VisibleIndex = 4;
            this.colTuoi.Width = 57;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.MinWidth = 17;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.OptionsColumn.AllowEdit = false;
            this.colGioiTinh.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colGioiTinh.OptionsColumn.ReadOnly = true;
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 5;
            this.colGioiTinh.Width = 49;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.MinWidth = 17;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.OptionsColumn.AllowEdit = false;
            this.colDiaChi.OptionsColumn.ReadOnly = true;
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 6;
            this.colDiaChi.Width = 118;
            // 
            // colBacSiCD
            // 
            this.colBacSiCD.Caption = "Bác sĩ";
            this.colBacSiCD.FieldName = "BacSiCD";
            this.colBacSiCD.MinWidth = 17;
            this.colBacSiCD.Name = "colBacSiCD";
            this.colBacSiCD.OptionsColumn.AllowEdit = false;
            this.colBacSiCD.OptionsColumn.ReadOnly = true;
            this.colBacSiCD.Visible = true;
            this.colBacSiCD.VisibleIndex = 8;
            this.colBacSiCD.Width = 89;
            // 
            // colTenDoiTuongDichVu
            // 
            this.colTenDoiTuongDichVu.Caption = "Đối tượng";
            this.colTenDoiTuongDichVu.FieldName = "TenDoiTuongDichVu";
            this.colTenDoiTuongDichVu.MinWidth = 17;
            this.colTenDoiTuongDichVu.Name = "colTenDoiTuongDichVu";
            this.colTenDoiTuongDichVu.OptionsColumn.AllowEdit = false;
            this.colTenDoiTuongDichVu.OptionsColumn.ReadOnly = true;
            this.colTenDoiTuongDichVu.Visible = true;
            this.colTenDoiTuongDichVu.VisibleIndex = 9;
            this.colTenDoiTuongDichVu.Width = 99;
            // 
            // colTongTienTheoDV
            // 
            this.colTongTienTheoDV.Caption = "Thành tiền";
            this.colTongTienTheoDV.DisplayFormat.FormatString = "{0:N0}";
            this.colTongTienTheoDV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTienTheoDV.FieldName = "TongTienTheoDV";
            this.colTongTienTheoDV.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTienTheoDV.MinWidth = 17;
            this.colTongTienTheoDV.Name = "colTongTienTheoDV";
            this.colTongTienTheoDV.OptionsColumn.AllowEdit = false;
            this.colTongTienTheoDV.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTongTienTheoDV.OptionsColumn.ReadOnly = true;
            this.colTongTienTheoDV.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTienTheoDV", "{0:N0}")});
            this.colTongTienTheoDV.Visible = true;
            this.colTongTienTheoDV.VisibleIndex = 10;
            this.colTongTienTheoDV.Width = 65;
            // 
            // colBenhNhan_KhoaPhong
            // 
            this.colBenhNhan_KhoaPhong.Caption = "Khoa phòng";
            this.colBenhNhan_KhoaPhong.FieldName = "TenKhoaPhong";
            this.colBenhNhan_KhoaPhong.MinWidth = 17;
            this.colBenhNhan_KhoaPhong.Name = "colBenhNhan_KhoaPhong";
            this.colBenhNhan_KhoaPhong.Visible = true;
            this.colBenhNhan_KhoaPhong.VisibleIndex = 7;
            this.colBenhNhan_KhoaPhong.Width = 166;
            // 
            // colTongTienBN
            // 
            this.colTongTienBN.Caption = "Tiền thu bệnh nhân";
            this.colTongTienBN.DisplayFormat.FormatString = "{0:N0}";
            this.colTongTienBN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTongTienBN.FieldName = "TongTien";
            this.colTongTienBN.MinWidth = 17;
            this.colTongTienBN.Name = "colTongTienBN";
            this.colTongTienBN.OptionsColumn.AllowEdit = false;
            this.colTongTienBN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TongTien", "{0:N0}")});
            this.colTongTienBN.Width = 105;
            // 
            // colChietKhau
            // 
            this.colChietKhau.Caption = "Chiết khấu";
            this.colChietKhau.DisplayFormat.FormatString = "{0:N0}";
            this.colChietKhau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colChietKhau.FieldName = "TienCong";
            this.colChietKhau.GroupFormat.FormatString = "{0:N0}";
            this.colChietKhau.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colChietKhau.MinWidth = 17;
            this.colChietKhau.Name = "colChietKhau";
            this.colChietKhau.OptionsColumn.AllowEdit = false;
            this.colChietKhau.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colChietKhau.OptionsColumn.ReadOnly = true;
            this.colChietKhau.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TienCong", "{0:N0}")});
            this.colChietKhau.Width = 160;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 282);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 43);
            this.panel1.TabIndex = 37;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXuatExcel.BackColorHover = System.Drawing.Color.Empty;
            this.btnXuatExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXuatExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXuatExcel.BorderRadius = 5;
            this.btnXuatExcel.BorderSize = 1;
            this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Black;
            this.btnXuatExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Image")));
            this.btnXuatExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuatExcel.Location = new System.Drawing.Point(290, 2);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 39);
            this.btnXuatExcel.TabIndex = 38;
            this.btnXuatExcel.Text = "Xuất excel ";
            this.btnXuatExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuatExcel.TextColor = System.Drawing.Color.Black;
            this.btnXuatExcel.UseHightLight = true;
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThongKe.BackColorHover = System.Drawing.Color.Empty;
            this.btnThongKe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThongKe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThongKe.BorderRadius = 5;
            this.btnThongKe.BorderSize = 1;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThongKe.ForeColor = System.Drawing.Color.Black;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(175, 2);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 39);
            this.btnThongKe.TabIndex = 37;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThongKe.TextColor = System.Drawing.Color.Black;
            this.btnThongKe.UseHightLight = true;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // ucTongHopBenhNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gcKetQua);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucTongHopBenhNhan";
            this.Size = new System.Drawing.Size(564, 325);
            this.Load += new System.EventHandler(this.ucTongHopBenhNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKetQua)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcKetQua;
        private DevExpress.XtraGrid.Views.Grid.GridView gvKetQua;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayXN;
        private DevExpress.XtraGrid.Columns.GridColumn colmatiepnhan;
        private DevExpress.XtraGrid.Columns.GridColumn colMabn;
        private DevExpress.XtraGrid.Columns.GridColumn colTenBN;
        private DevExpress.XtraGrid.Columns.GridColumn colTuoi;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colBacSiCD;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDoiTuongDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTienTheoDV;
        private DevExpress.XtraGrid.Columns.GridColumn colBenhNhan_KhoaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTienBN;
        private DevExpress.XtraGrid.Columns.GridColumn colChietKhau;
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnXuatExcel;
        private TPH.Controls.TPHNormalButton btnThongKe;
    }
}
