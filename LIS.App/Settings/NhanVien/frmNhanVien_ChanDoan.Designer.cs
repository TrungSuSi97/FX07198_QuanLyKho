namespace TPH.LIS.App.CauHinh.NhanVien
{
    partial class frmNhanVien_ChanDoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien_ChanDoan));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.gcNhanVien = new DevExpress.XtraGrid.GridControl();
            this.gvNhanVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaNghi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThongKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coTGNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiSua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBoPhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEditDonVi = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lukMaKhoaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lukTenKhoaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEditPhong = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lukMaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lukTenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnInfoBacSi = new DevExpress.XtraEditors.PanelControl();
            this.cboNhomNhanVien = new TPH.LIS.Common.Controls.CustomComboBox();
            this.btnRefreshBacSi = new TPH.Controls.TPHNormalButton();
            this.btnXoaBacSi = new TPH.Controls.TPHNormalButton();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaBacSi = new System.Windows.Forms.TextBox();
            this.btnAddBacSi = new TPH.Controls.TPHNormalButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBacSi = new System.Windows.Forms.TextBox();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnInfoBacSi)).BeginInit();
            this.pnInfoBacSi.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Size = new System.Drawing.Size(190, 22);
            this.lblTitle.Text = "THÔNG TIN NHÂN VIÊN ";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.tabControl1);
            this.pnContaint.Location = new System.Drawing.Point(0, 26);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnContaint.Size = new System.Drawing.Size(1010, 637);
            // 
            // pnLabel
            // 
            this.pnLabel.Padding = new System.Windows.Forms.Padding(4, 8, 4, 3);
            this.pnLabel.Size = new System.Drawing.Size(1010, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(654, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(683, 8);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(1010, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1010, 25);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(902, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 24);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Enabled = false;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhanVien);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1002, 631);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.gcNhanVien);
            this.tabNhanVien.Controls.Add(this.pnInfoBacSi);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 24);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(994, 603);
            this.tabNhanVien.TabIndex = 0;
            this.tabNhanVien.Text = "Danh mục nhân viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // gcNhanVien
            // 
            this.gcNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNhanVien.Location = new System.Drawing.Point(3, 50);
            this.gcNhanVien.MainView = this.gvNhanVien;
            this.gcNhanVien.Name = "gcNhanVien";
            this.gcNhanVien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEditDonVi,
            this.repositoryItemGridLookUpEditPhong});
            this.gcNhanVien.Size = new System.Drawing.Size(988, 550);
            this.gcNhanVien.TabIndex = 4;
            this.gcNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNhanVien});
            // 
            // gvNhanVien
            // 
            this.gvNhanVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNhanVien,
            this.colTenNhanVien,
            this.colDiaChi,
            this.colDienThoai,
            this.colDaNghi,
            this.colThongKe,
            this.colNguoiNhap,
            this.coTGNhap,
            this.colNguoiSua,
            this.colNgaySua,
            this.colBoPhan,
            this.colChucVu,
            this.gridColumn1,
            this.gridColumn2});
            this.gvNhanVien.GridControl = this.gcNhanVien;
            this.gvNhanVien.GroupCount = 1;
            this.gvNhanVien.Name = "gvNhanVien";
            this.gvNhanVien.OptionsView.ColumnAutoWidth = false;
            this.gvNhanVien.OptionsView.ShowAutoFilterRow = true;
            this.gvNhanVien.OptionsView.ShowGroupPanel = false;
            this.gvNhanVien.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvNhanVien.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvNhanVien_CellValueChanged);
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.Caption = "Mã nhân viên";
            this.colMaNhanVien.FieldName = "MaNhanVien";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.OptionsColumn.ReadOnly = true;
            this.colMaNhanVien.Visible = true;
            this.colMaNhanVien.VisibleIndex = 0;
            this.colMaNhanVien.Width = 106;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.Caption = "Tên nhân viên";
            this.colTenNhanVien.FieldName = "TenNhanVien";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.Visible = true;
            this.colTenNhanVien.VisibleIndex = 1;
            this.colTenNhanVien.Width = 197;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 2;
            this.colDiaChi.Width = 182;
            // 
            // colDienThoai
            // 
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.FieldName = "DienThoai";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 3;
            this.colDienThoai.Width = 76;
            // 
            // colDaNghi
            // 
            this.colDaNghi.Caption = "Đã nghỉ";
            this.colDaNghi.FieldName = "DaNghi";
            this.colDaNghi.Name = "colDaNghi";
            this.colDaNghi.Visible = true;
            this.colDaNghi.VisibleIndex = 4;
            this.colDaNghi.Width = 76;
            // 
            // colThongKe
            // 
            this.colThongKe.Caption = "Thống kê";
            this.colThongKe.FieldName = "ThongKe";
            this.colThongKe.Name = "colThongKe";
            this.colThongKe.Visible = true;
            this.colThongKe.VisibleIndex = 5;
            this.colThongKe.Width = 76;
            // 
            // colNguoiNhap
            // 
            this.colNguoiNhap.Caption = "Người nhập";
            this.colNguoiNhap.FieldName = "NguoiNhap";
            this.colNguoiNhap.Name = "colNguoiNhap";
            this.colNguoiNhap.OptionsColumn.AllowEdit = false;
            this.colNguoiNhap.Visible = true;
            this.colNguoiNhap.VisibleIndex = 8;
            // 
            // coTGNhap
            // 
            this.coTGNhap.Caption = "TG Nhập";
            this.coTGNhap.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.coTGNhap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.coTGNhap.FieldName = "TGNhap";
            this.coTGNhap.Name = "coTGNhap";
            this.coTGNhap.OptionsColumn.AllowEdit = false;
            this.coTGNhap.Visible = true;
            this.coTGNhap.VisibleIndex = 9;
            // 
            // colNguoiSua
            // 
            this.colNguoiSua.Caption = "Người sửa";
            this.colNguoiSua.FieldName = "NguoiSua";
            this.colNguoiSua.Name = "colNguoiSua";
            this.colNguoiSua.OptionsColumn.AllowEdit = false;
            this.colNguoiSua.Visible = true;
            this.colNguoiSua.VisibleIndex = 10;
            // 
            // colNgaySua
            // 
            this.colNgaySua.Caption = "TG sửa";
            this.colNgaySua.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colNgaySua.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgaySua.FieldName = "NgaySua";
            this.colNgaySua.Name = "colNgaySua";
            this.colNgaySua.OptionsColumn.AllowEdit = false;
            this.colNgaySua.Visible = true;
            this.colNgaySua.VisibleIndex = 11;
            // 
            // colBoPhan
            // 
            this.colBoPhan.Caption = "Bộ phận";
            this.colBoPhan.ColumnEdit = this.repositoryItemGridLookUpEditDonVi;
            this.colBoPhan.FieldName = "MaBoPhan";
            this.colBoPhan.Name = "colBoPhan";
            this.colBoPhan.Visible = true;
            this.colBoPhan.VisibleIndex = 6;
            this.colBoPhan.Width = 170;
            // 
            // repositoryItemGridLookUpEditDonVi
            // 
            this.repositoryItemGridLookUpEditDonVi.AutoHeight = false;
            this.repositoryItemGridLookUpEditDonVi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEditDonVi.DisplayMember = "TenBoPhan";
            this.repositoryItemGridLookUpEditDonVi.Name = "repositoryItemGridLookUpEditDonVi";
            this.repositoryItemGridLookUpEditDonVi.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEditDonVi.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEditDonVi.ValueMember = "MaBoPhan";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.lukMaKhoaPhong,
            this.lukTenKhoaPhong});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ColumnAutoWidth = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lukMaKhoaPhong
            // 
            this.lukMaKhoaPhong.Caption = "Mã bộ phận";
            this.lukMaKhoaPhong.FieldName = "MaBoPhan";
            this.lukMaKhoaPhong.Name = "lukMaKhoaPhong";
            this.lukMaKhoaPhong.OptionsColumn.ReadOnly = true;
            this.lukMaKhoaPhong.Visible = true;
            this.lukMaKhoaPhong.VisibleIndex = 0;
            // 
            // lukTenKhoaPhong
            // 
            this.lukTenKhoaPhong.Caption = "Tên bộ phận";
            this.lukTenKhoaPhong.FieldName = "TenBoPhan";
            this.lukTenKhoaPhong.Name = "lukTenKhoaPhong";
            this.lukTenKhoaPhong.OptionsColumn.AllowEdit = false;
            this.lukTenKhoaPhong.Visible = true;
            this.lukTenKhoaPhong.VisibleIndex = 1;
            this.lukTenKhoaPhong.Width = 330;
            // 
            // colChucVu
            // 
            this.colChucVu.Caption = "Chức vụ";
            this.colChucVu.ColumnEdit = this.repositoryItemGridLookUpEditPhong;
            this.colChucVu.FieldName = "NhomNhanVien";
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.Visible = true;
            this.colChucVu.VisibleIndex = 7;
            this.colChucVu.Width = 188;
            // 
            // repositoryItemGridLookUpEditPhong
            // 
            this.repositoryItemGridLookUpEditPhong.AutoHeight = false;
            this.repositoryItemGridLookUpEditPhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEditPhong.DisplayMember = "TenNhomNhanVien";
            this.repositoryItemGridLookUpEditPhong.Name = "repositoryItemGridLookUpEditPhong";
            this.repositoryItemGridLookUpEditPhong.NullText = "[Chưa chọn]";
            this.repositoryItemGridLookUpEditPhong.PopupView = this.gridView1;
            this.repositoryItemGridLookUpEditPhong.ValueMember = "MaNhomNhanVien";
            this.repositoryItemGridLookUpEditPhong.Popup += new System.EventHandler(this.repositoryItemGridLookUpEditPhong_Popup);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.lukMaPhong,
            this.lukTenPhong});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lukMaPhong
            // 
            this.lukMaPhong.Caption = "Mã chức vụ";
            this.lukMaPhong.FieldName = "MaNhomNhanVien";
            this.lukMaPhong.Name = "lukMaPhong";
            this.lukMaPhong.OptionsColumn.ReadOnly = true;
            this.lukMaPhong.Visible = true;
            this.lukMaPhong.VisibleIndex = 0;
            this.lukMaPhong.Width = 90;
            // 
            // lukTenPhong
            // 
            this.lukTenPhong.Caption = "Tên chức vụ";
            this.lukTenPhong.FieldName = "TenNhomNhanVien";
            this.lukTenPhong.Name = "lukTenPhong";
            this.lukTenPhong.OptionsColumn.AllowEdit = false;
            this.lukTenPhong.Visible = true;
            this.lukTenPhong.VisibleIndex = 1;
            this.lukTenPhong.Width = 202;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Chức vụ";
            this.gridColumn1.FieldName = "TenNhomNhanVien";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 12;
            // 
            // pnInfoBacSi
            // 
            this.pnInfoBacSi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnInfoBacSi.Appearance.Options.UseBackColor = true;
            this.pnInfoBacSi.Controls.Add(this.cboNhomNhanVien);
            this.pnInfoBacSi.Controls.Add(this.btnRefreshBacSi);
            this.pnInfoBacSi.Controls.Add(this.btnXoaBacSi);
            this.pnInfoBacSi.Controls.Add(this.label5);
            this.pnInfoBacSi.Controls.Add(this.label2);
            this.pnInfoBacSi.Controls.Add(this.txtMaBacSi);
            this.pnInfoBacSi.Controls.Add(this.btnAddBacSi);
            this.pnInfoBacSi.Controls.Add(this.label1);
            this.pnInfoBacSi.Controls.Add(this.txtBacSi);
            this.pnInfoBacSi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnInfoBacSi.Location = new System.Drawing.Point(3, 3);
            this.pnInfoBacSi.Name = "pnInfoBacSi";
            this.pnInfoBacSi.Size = new System.Drawing.Size(988, 47);
            this.pnInfoBacSi.TabIndex = 0;
            // 
            // cboNhomNhanVien
            // 
            this.cboNhomNhanVien.AutoComplete = false;
            this.cboNhomNhanVien.AutoDropdown = false;
            this.cboNhomNhanVien.BackColorEven = System.Drawing.Color.White;
            this.cboNhomNhanVien.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhomNhanVien.ColumnNames = "";
            this.cboNhomNhanVien.ColumnWidthDefault = 75;
            this.cboNhomNhanVien.ColumnWidths = "";
            this.cboNhomNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomNhanVien.FormattingEnabled = true;
            this.cboNhomNhanVien.LinkedColumnIndex = 0;
            this.cboNhomNhanVien.LinkedColumnIndex1 = 0;
            this.cboNhomNhanVien.LinkedColumnIndex2 = 0;
            this.cboNhomNhanVien.LinkedTextBox = null;
            this.cboNhomNhanVien.LinkedTextBox1 = null;
            this.cboNhomNhanVien.LinkedTextBox2 = null;
            this.cboNhomNhanVien.Location = new System.Drawing.Point(510, 11);
            this.cboNhomNhanVien.Name = "cboNhomNhanVien";
            this.cboNhomNhanVien.Size = new System.Drawing.Size(112, 21);
            this.cboNhomNhanVien.TabIndex = 2;
            // 
            // btnRefreshBacSi
            // 
            this.btnRefreshBacSi.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshBacSi.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshBacSi.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshBacSi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnRefreshBacSi.BorderRadius = 5;
            this.btnRefreshBacSi.BorderSize = 1;
            this.btnRefreshBacSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBacSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBacSi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshBacSi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshBacSi.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshBacSi.Image = global::TPH.LIS.App.Properties.Resources.Refresh_16x16;
            this.btnRefreshBacSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefreshBacSi.Location = new System.Drawing.Point(887, 11);
            this.btnRefreshBacSi.Name = "btnRefreshBacSi";
            this.btnRefreshBacSi.Size = new System.Drawing.Size(96, 27);
            this.btnRefreshBacSi.TabIndex = 11;
            this.btnRefreshBacSi.Text = "Làm mới";
            this.btnRefreshBacSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefreshBacSi.TextColor = System.Drawing.Color.Black;
            this.btnRefreshBacSi.UseHightLight = true;
            this.btnRefreshBacSi.UseVisualStyleBackColor = true;
            this.btnRefreshBacSi.Click += new System.EventHandler(this.btnRefreshBacSi_Click);
            // 
            // btnXoaBacSi
            // 
            this.btnXoaBacSi.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaBacSi.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaBacSi.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnXoaBacSi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaBacSi.BorderRadius = 5;
            this.btnXoaBacSi.BorderSize = 1;
            this.btnXoaBacSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaBacSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBacSi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaBacSi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaBacSi.ForeColor = System.Drawing.Color.Black;
            this.btnXoaBacSi.Image = global::TPH.LIS.App.Properties.Resources.DeleteRed_16x16;
            this.btnXoaBacSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaBacSi.Location = new System.Drawing.Point(746, 11);
            this.btnXoaBacSi.Name = "btnXoaBacSi";
            this.btnXoaBacSi.Size = new System.Drawing.Size(133, 27);
            this.btnXoaBacSi.TabIndex = 10;
            this.btnXoaBacSi.Text = "Xóa nhân viên";
            this.btnXoaBacSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaBacSi.TextColor = System.Drawing.Color.Black;
            this.btnXoaBacSi.UseHightLight = true;
            this.btnXoaBacSi.UseVisualStyleBackColor = true;
            this.btnXoaBacSi.Click += new System.EventHandler(this.btnXoaBacSi_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(461, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nhóm";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã NV";
            // 
            // txtMaBacSi
            // 
            this.txtMaBacSi.Location = new System.Drawing.Point(71, 12);
            this.txtMaBacSi.Name = "txtMaBacSi";
            this.txtMaBacSi.Size = new System.Drawing.Size(109, 20);
            this.txtMaBacSi.TabIndex = 0;
            this.txtMaBacSi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaBacSi_KeyPress);
            // 
            // btnAddBacSi
            // 
            this.btnAddBacSi.BackColor = System.Drawing.Color.Transparent;
            this.btnAddBacSi.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddBacSi.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddBacSi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnAddBacSi.BorderRadius = 5;
            this.btnAddBacSi.BorderSize = 1;
            this.btnAddBacSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBacSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBacSi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBacSi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddBacSi.ForeColor = System.Drawing.Color.Black;
            this.btnAddBacSi.Image = ((System.Drawing.Image)(resources.GetObject("btnAddBacSi.Image")));
            this.btnAddBacSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBacSi.Location = new System.Drawing.Point(628, 11);
            this.btnAddBacSi.Name = "btnAddBacSi";
            this.btnAddBacSi.Size = new System.Drawing.Size(110, 27);
            this.btnAddBacSi.TabIndex = 3;
            this.btnAddBacSi.Text = "Thêm mới";
            this.btnAddBacSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddBacSi.TextColor = System.Drawing.Color.Black;
            this.btnAddBacSi.UseHightLight = true;
            this.btnAddBacSi.UseVisualStyleBackColor = true;
            this.btnAddBacSi.Click += new System.EventHandler(this.btnAddBacSi_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(186, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên NV";
            // 
            // txtBacSi
            // 
            this.txtBacSi.Location = new System.Drawing.Point(247, 12);
            this.txtBacSi.Name = "txtBacSi";
            this.txtBacSi.Size = new System.Drawing.Size(208, 20);
            this.txtBacSi.TabIndex = 1;
            this.txtBacSi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBacSi_KeyPress);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Lương";
            this.gridColumn2.FieldName = "Luong";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 12;
            // 
            // frmNhanVien_ChanDoan
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1010, 663);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmNhanVien_ChanDoan";
            this.Text = "Thông tin nhân viên";
            this.Load += new System.EventHandler(this.frmBacSi_ChanDoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).EndInit();
            this.pnFormControl.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEditPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnInfoBacSi)).EndInit();
            this.pnInfoBacSi.ResumeLayout(false);
            this.pnInfoBacSi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNhanVien;
        private DevExpress.XtraEditors.PanelControl pnInfoBacSi;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.TextBox txtBacSi;
        private TPH.Controls.TPHNormalButton btnAddBacSi;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtMaBacSi;
        private DevExpress.XtraGrid.GridControl gcNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colDaNghi;
        private DevExpress.XtraGrid.Columns.GridColumn colThongKe;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiNhap;
        private DevExpress.XtraGrid.Columns.GridColumn coTGNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiSua;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySua;
        private TPH.Controls.TPHNormalButton btnRefreshBacSi;
        private TPH.Controls.TPHNormalButton btnXoaBacSi;
        private DevExpress.XtraGrid.Columns.GridColumn colBoPhan;
        private Common.Controls.CustomComboBox cboNhomNhanVien;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEditDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colChucVu;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEditPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn lukMaKhoaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn lukTenKhoaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn lukMaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn lukTenPhong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}