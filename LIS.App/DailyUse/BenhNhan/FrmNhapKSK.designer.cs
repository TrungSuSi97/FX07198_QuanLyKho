namespace TPH.LIS.App.ThucThi.BenhNhan
{
    partial class FrmNhapKSK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNhapKSK));
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcDanhSachImport = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachImport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNhanVien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayDangKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSinhNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaChiDinhHIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayChiDinhHIS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamSinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoBHYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCMND_HC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayCapCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuocTich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoituongBn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoiTuongDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBSChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChanDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colimportProfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTglayMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiLaymau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.pnDonVi = new DevExpress.XtraEditors.PanelControl();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.cboDonVi = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.ucSearchLookupEditor_BSChiDinh = new TPH.LIS.App.AppCode.ucSearchLookupEditor_Doctor();
            this.chkTuTaoCode = new System.Windows.Forms.CheckBox();
            this.btnThucHien = new TPH.Controls.TPHNormalButton();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.txtDoiTuongDichVu = new System.Windows.Forms.TextBox();
            this.customLable6 = new TPH.LIS.Common.Controls.CustomLable();
            this.cboDoiTuongDichVu = new TPH.LIS.Common.Controls.CustomComboBox();
            this.lblMess = new DevExpress.XtraEditors.LabelControl();
            this.pnBarcode = new System.Windows.Forms.GroupBox();
            this.txtTobarcode = new TPH.LIS.Common.Controls.CustomTextBox(this.components);
            this.customLable9 = new TPH.LIS.Common.Controls.CustomLable();
            this.txtFromBarcode = new TPH.LIS.Common.Controls.CustomTextBox(this.components);
            this.customLable8 = new TPH.LIS.Common.Controls.CustomLable();
            this.pnExcel = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new TPH.Controls.TPHNormalButton();
            this.pnNguonChiDinh = new DevExpress.XtraEditors.PanelControl();
            this.radChiDinhNhapDanhSach = new System.Windows.Forms.RadioButton();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.radChiDinhTuExcel = new System.Windows.Forms.RadioButton();
            this.chkChiDInhChuaLayMau = new System.Windows.Forms.CheckBox();
            this.chkHISMode = new System.Windows.Forms.CheckBox();
            this.btnBrowsePath = new TPH.Controls.TPHNormalButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkIncodeKhiNhap = new System.Windows.Forms.CheckBox();
            this.radInputWithBarcodeRange = new System.Windows.Forms.RadioButton();
            this.radInputWithExcelFile = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcDanhSachChiDinh = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSachChiDinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IsProfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenLoaiDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MaLoaiDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXoaChiDinh = new TPH.Controls.TPHNormalButton();
            this.dgvXetNghiem = new System.Windows.Forms.DataGridView();
            this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TenXN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaXN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiDichVuAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChiDinhAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customLable5 = new TPH.LIS.Common.Controls.CustomLable();
            this.txtTimDichVu = new System.Windows.Forms.TextBox();
            this.btnThemChiDinh = new TPH.Controls.TPHNormalButton();
            this.txtNhomDichVu = new System.Windows.Forms.TextBox();
            this.cboNhomDichVu = new TPH.LIS.Common.Controls.CustomComboBox();
            this.customLable3 = new TPH.LIS.Common.Controls.CustomLable();
            this.txtLoaiDichVu = new System.Windows.Forms.TextBox();
            this.cboLoaiDichVu = new TPH.LIS.Common.Controls.CustomComboBox();
            this.customLable2 = new TPH.LIS.Common.Controls.CustomLable();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnDonVi)).BeginInit();
            this.pnDonVi.SuspendLayout();
            this.pnBarcode.SuspendLayout();
            this.pnExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnNguonChiDinh)).BeginInit();
            this.pnNguonChiDinh.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXetNghiem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Size = new System.Drawing.Size(196, 22);
            this.lblTitle.Text = "NHẬP THEO DANH SÁCH";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.splitContainer1);
            this.pnContaint.Location = new System.Drawing.Point(0, 0);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Size = new System.Drawing.Size(1029, 427);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Size = new System.Drawing.Size(1029, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(677, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(706, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnMenu.Size = new System.Drawing.Size(1029, 0);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(167)))), ((int)(((byte)(195)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1029, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(198, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(60, 0);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(921, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 0);
            // 
            // btnMinimize
            // 
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcDanhSachImport);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.pnBarcode);
            this.splitContainer1.Panel1.Controls.Add(this.pnExcel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 423);
            this.splitContainer1.SplitterPosition = 598;
            this.splitContainer1.TabIndex = 0;
            // 
            // gcDanhSachImport
            // 
            this.gcDanhSachImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachImport.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhSachImport.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhSachImport.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhSachImport.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhSachImport.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhSachImport.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcDanhSachImport.Location = new System.Drawing.Point(0, 264);
            this.gcDanhSachImport.MainView = this.gvDanhSachImport;
            this.gcDanhSachImport.Name = "gcDanhSachImport";
            this.gcDanhSachImport.Size = new System.Drawing.Size(598, 159);
            this.gcDanhSachImport.TabIndex = 7;
            this.gcDanhSachImport.UseEmbeddedNavigator = true;
            this.gcDanhSachImport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachImport});
            // 
            // gvDanhSachImport
            // 
            this.gvDanhSachImport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBarcode,
            this.colMaNhanVien,
            this.colNgayDangKy,
            this.colMaBN,
            this.colHoTen,
            this.colSinhNhat,
            this.colMaChiDinhHIS,
            this.colNgayChiDinhHIS,
            this.colNamSinh,
            this.colGioiTinh,
            this.colDiaChi,
            this.colSoBHYT,
            this.colCMND_HC,
            this.colNgayCapCMND,
            this.colQuocTich,
            this.colDienThoai,
            this.colDoituongBn,
            this.colDoiTuongDichVu,
            this.colBSChiDinh,
            this.colCTV,
            this.colDonVi,
            this.colChanDoan,
            this.colChiDinh,
            this.colimportProfile,
            this.colTglayMau,
            this.colNguoiLaymau});
            this.gvDanhSachImport.GridControl = this.gcDanhSachImport;
            this.gvDanhSachImport.Name = "gvDanhSachImport";
            this.gvDanhSachImport.OptionsPrint.AutoWidth = false;
            this.gvDanhSachImport.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSachImport.OptionsView.ShowGroupPanel = false;
            this.gvDanhSachImport.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvDanhSachImport_RowCellStyle);
            // 
            // colBarcode
            // 
            this.colBarcode.Caption = "Barcode";
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 0;
            this.colBarcode.Width = 63;
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.Caption = "Mã nhân viên";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.Visible = true;
            this.colMaNhanVien.VisibleIndex = 1;
            this.colMaNhanVien.Width = 72;
            // 
            // colNgayDangKy
            // 
            this.colNgayDangKy.Caption = "Ngày đăng ký";
            this.colNgayDangKy.Name = "colNgayDangKy";
            this.colNgayDangKy.Visible = true;
            this.colNgayDangKy.VisibleIndex = 2;
            this.colNgayDangKy.Width = 78;
            // 
            // colMaBN
            // 
            this.colMaBN.Caption = "Mã BN";
            this.colMaBN.Name = "colMaBN";
            this.colMaBN.Visible = true;
            this.colMaBN.VisibleIndex = 3;
            this.colMaBN.Width = 78;
            // 
            // colHoTen
            // 
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 4;
            this.colHoTen.Width = 115;
            // 
            // colSinhNhat
            // 
            this.colSinhNhat.Caption = "Sinh nhật";
            this.colSinhNhat.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSinhNhat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSinhNhat.Name = "colSinhNhat";
            this.colSinhNhat.Visible = true;
            this.colSinhNhat.VisibleIndex = 5;
            this.colSinhNhat.Width = 80;
            // 
            // colMaChiDinhHIS
            // 
            this.colMaChiDinhHIS.Caption = "Phiếu chỉ định HIS";
            this.colMaChiDinhHIS.FieldName = "MaSoPhieu";
            this.colMaChiDinhHIS.Name = "colMaChiDinhHIS";
            this.colMaChiDinhHIS.Visible = true;
            this.colMaChiDinhHIS.VisibleIndex = 6;
            this.colMaChiDinhHIS.Width = 105;
            // 
            // colNgayChiDinhHIS
            // 
            this.colNgayChiDinhHIS.Caption = "Ngày chỉ định HIS";
            this.colNgayChiDinhHIS.FieldName = "NgayChiDinh";
            this.colNgayChiDinhHIS.Name = "colNgayChiDinhHIS";
            this.colNgayChiDinhHIS.Visible = true;
            this.colNgayChiDinhHIS.VisibleIndex = 7;
            this.colNgayChiDinhHIS.Width = 107;
            // 
            // colNamSinh
            // 
            this.colNamSinh.Caption = "Năm sinh";
            this.colNamSinh.FieldName = "NamSinh";
            this.colNamSinh.Name = "colNamSinh";
            this.colNamSinh.Visible = true;
            this.colNamSinh.VisibleIndex = 8;
            this.colNamSinh.Width = 80;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới tính";
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 9;
            this.colGioiTinh.Width = 71;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 10;
            this.colDiaChi.Width = 64;
            // 
            // colSoBHYT
            // 
            this.colSoBHYT.Caption = "Số BHYT";
            this.colSoBHYT.FieldName = "SoBHYT";
            this.colSoBHYT.Name = "colSoBHYT";
            this.colSoBHYT.Visible = true;
            this.colSoBHYT.VisibleIndex = 11;
            this.colSoBHYT.Width = 68;
            // 
            // colCMND_HC
            // 
            this.colCMND_HC.Caption = "CMND/HC";
            this.colCMND_HC.Name = "colCMND_HC";
            this.colCMND_HC.Visible = true;
            this.colCMND_HC.VisibleIndex = 12;
            this.colCMND_HC.Width = 110;
            // 
            // colNgayCapCMND
            // 
            this.colNgayCapCMND.Caption = "Ngày cấp CMND/HC";
            this.colNgayCapCMND.Name = "colNgayCapCMND";
            this.colNgayCapCMND.Visible = true;
            this.colNgayCapCMND.VisibleIndex = 13;
            this.colNgayCapCMND.Width = 117;
            // 
            // colQuocTich
            // 
            this.colQuocTich.Caption = "Quốc tịch";
            this.colQuocTich.Name = "colQuocTich";
            this.colQuocTich.Visible = true;
            this.colQuocTich.VisibleIndex = 14;
            this.colQuocTich.Width = 77;
            // 
            // colDienThoai
            // 
            this.colDienThoai.Caption = "Điện thoại";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 15;
            this.colDienThoai.Width = 83;
            // 
            // colDoituongBn
            // 
            this.colDoituongBn.Caption = "Đối tượng BN";
            this.colDoituongBn.Name = "colDoituongBn";
            this.colDoituongBn.Visible = true;
            this.colDoituongBn.VisibleIndex = 16;
            this.colDoituongBn.Width = 135;
            // 
            // colDoiTuongDichVu
            // 
            this.colDoiTuongDichVu.Caption = "Đối tượng";
            this.colDoiTuongDichVu.Name = "colDoiTuongDichVu";
            this.colDoiTuongDichVu.Visible = true;
            this.colDoiTuongDichVu.VisibleIndex = 17;
            this.colDoiTuongDichVu.Width = 104;
            // 
            // colBSChiDinh
            // 
            this.colBSChiDinh.Caption = "Bác sĩ CĐ";
            this.colBSChiDinh.Name = "colBSChiDinh";
            this.colBSChiDinh.Visible = true;
            this.colBSChiDinh.VisibleIndex = 18;
            this.colBSChiDinh.Width = 95;
            // 
            // colCTV
            // 
            this.colCTV.Caption = "CTV";
            this.colCTV.Name = "colCTV";
            this.colCTV.Visible = true;
            this.colCTV.VisibleIndex = 19;
            this.colCTV.Width = 90;
            // 
            // colDonVi
            // 
            this.colDonVi.Caption = "Mã đơn vị";
            this.colDonVi.Name = "colDonVi";
            this.colDonVi.Visible = true;
            this.colDonVi.VisibleIndex = 20;
            this.colDonVi.Width = 100;
            // 
            // colChanDoan
            // 
            this.colChanDoan.Caption = "Chẩn đoán";
            this.colChanDoan.Name = "colChanDoan";
            this.colChanDoan.Visible = true;
            this.colChanDoan.VisibleIndex = 21;
            this.colChanDoan.Width = 137;
            // 
            // colChiDinh
            // 
            this.colChiDinh.Caption = "Chỉ định";
            this.colChiDinh.Name = "colChiDinh";
            this.colChiDinh.Visible = true;
            this.colChiDinh.VisibleIndex = 22;
            this.colChiDinh.Width = 84;
            // 
            // colimportProfile
            // 
            this.colimportProfile.Caption = "Profile";
            this.colimportProfile.Name = "colimportProfile";
            this.colimportProfile.Visible = true;
            this.colimportProfile.VisibleIndex = 23;
            this.colimportProfile.Width = 74;
            // 
            // colTglayMau
            // 
            this.colTglayMau.Caption = "Thời gian lấy mẫu";
            this.colTglayMau.DisplayFormat.FormatString = "HH:mm:ss dd/MM/yyyy";
            this.colTglayMau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTglayMau.Name = "colTglayMau";
            this.colTglayMau.Visible = true;
            this.colTglayMau.VisibleIndex = 24;
            this.colTglayMau.Width = 91;
            // 
            // colNguoiLaymau
            // 
            this.colNguoiLaymau.Caption = "Người lấy mẫu";
            this.colNguoiLaymau.Name = "colNguoiLaymau";
            this.colNguoiLaymau.Visible = true;
            this.colNguoiLaymau.VisibleIndex = 25;
            this.colNguoiLaymau.Width = 79;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnDonVi);
            this.panel3.Controls.Add(this.ucSearchLookupEditor_BSChiDinh);
            this.panel3.Controls.Add(this.chkTuTaoCode);
            this.panel3.Controls.Add(this.btnThucHien);
            this.panel3.Controls.Add(this.dtpDateIn);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtDoiTuongDichVu);
            this.panel3.Controls.Add(this.customLable6);
            this.panel3.Controls.Add(this.cboDoiTuongDichVu);
            this.panel3.Controls.Add(this.lblMess);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 153);
            this.panel3.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 111);
            this.panel3.TabIndex = 5;
            // 
            // pnDonVi
            // 
            this.pnDonVi.Controls.Add(this.txtDonVi);
            this.pnDonVi.Controls.Add(this.cboDonVi);
            this.pnDonVi.Controls.Add(this.label1);
            this.pnDonVi.Location = new System.Drawing.Point(4, 80);
            this.pnDonVi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnDonVi.Name = "pnDonVi";
            this.pnDonVi.Size = new System.Drawing.Size(391, 29);
            this.pnDonVi.TabIndex = 6;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDonVi.Location = new System.Drawing.Point(187, 5);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(199, 21);
            this.txtDonVi.TabIndex = 41;
            this.txtDonVi.TabStop = false;
            // 
            // cboDonVi
            // 
            this.cboDonVi.AutoComplete = false;
            this.cboDonVi.AutoDropdown = false;
            this.cboDonVi.BackColorEven = System.Drawing.Color.White;
            this.cboDonVi.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDonVi.ColumnNames = "";
            this.cboDonVi.ColumnWidthDefault = 75;
            this.cboDonVi.ColumnWidths = "";
            this.cboDonVi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDonVi.Font = new System.Drawing.Font("Arial", 9F);
            this.cboDonVi.FormattingEnabled = true;
            this.cboDonVi.LinkedColumnIndex = 0;
            this.cboDonVi.LinkedColumnIndex1 = 0;
            this.cboDonVi.LinkedColumnIndex2 = 0;
            this.cboDonVi.LinkedTextBox = null;
            this.cboDonVi.LinkedTextBox1 = null;
            this.cboDonVi.LinkedTextBox2 = null;
            this.cboDonVi.Location = new System.Drawing.Point(97, 4);
            this.cboDonVi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(88, 22);
            this.cboDonVi.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(15, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "Đơn vị";
            // 
            // ucSearchLookupEditor_BSChiDinh
            // 
            this.ucSearchLookupEditor_BSChiDinh.CatchEnterKey = false;
            this.ucSearchLookupEditor_BSChiDinh.CatchTabKey = false;
            this.ucSearchLookupEditor_BSChiDinh.ControlBack = null;
            this.ucSearchLookupEditor_BSChiDinh.ControlNext = null;
            this.ucSearchLookupEditor_BSChiDinh.DisplayMember = "";
            this.ucSearchLookupEditor_BSChiDinh.Location = new System.Drawing.Point(102, 58);
            this.ucSearchLookupEditor_BSChiDinh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucSearchLookupEditor_BSChiDinh.Name = "ucSearchLookupEditor_BSChiDinh";
            this.ucSearchLookupEditor_BSChiDinh.SelectedValue = null;
            this.ucSearchLookupEditor_BSChiDinh.Size = new System.Drawing.Size(288, 23);
            this.ucSearchLookupEditor_BSChiDinh.TabIndex = 67;
            this.ucSearchLookupEditor_BSChiDinh.ValueMember = "";
            // 
            // chkTuTaoCode
            // 
            this.chkTuTaoCode.AutoSize = true;
            this.chkTuTaoCode.BackColor = System.Drawing.Color.Cornsilk;
            this.chkTuTaoCode.Checked = true;
            this.chkTuTaoCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTuTaoCode.Location = new System.Drawing.Point(224, 8);
            this.chkTuTaoCode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkTuTaoCode.Name = "chkTuTaoCode";
            this.chkTuTaoCode.Size = new System.Drawing.Size(127, 17);
            this.chkTuTaoCode.TabIndex = 66;
            this.chkTuTaoCode.Text = "Cấp barcode tự động";
            this.chkTuTaoCode.UseVisualStyleBackColor = false;
            this.chkTuTaoCode.CheckedChanged += new System.EventHandler(this.chkTuTaoCode_CheckedChanged);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThucHien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThucHien.BackColorHover = System.Drawing.Color.Empty;
            this.btnThucHien.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThucHien.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThucHien.BorderRadius = 5;
            this.btnThucHien.BorderSize = 1;
            this.btnThucHien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHien.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThucHien.ForeColor = System.Drawing.Color.Black;
            this.btnThucHien.Image = ((System.Drawing.Image)(resources.GetObject("btnThucHien.Image")));
            this.btnThucHien.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThucHien.Location = new System.Drawing.Point(397, 64);
            this.btnThucHien.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(93, 45);
            this.btnThucHien.TabIndex = 1;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThucHien.TextColor = System.Drawing.Color.Black;
            this.btnThucHien.UseHightLight = true;
            this.btnThucHien.UseVisualStyleBackColor = false;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(101, 7);
            this.dtpDateIn.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(88, 21);
            this.dtpDateIn.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Ngày đăng ký";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(19, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "BS Chỉ định";
            // 
            // txtDoiTuongDichVu
            // 
            this.txtDoiTuongDichVu.Location = new System.Drawing.Point(191, 34);
            this.txtDoiTuongDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtDoiTuongDichVu.Name = "txtDoiTuongDichVu";
            this.txtDoiTuongDichVu.Size = new System.Drawing.Size(199, 21);
            this.txtDoiTuongDichVu.TabIndex = 9;
            // 
            // customLable6
            // 
            this.customLable6.AutoSize = true;
            this.customLable6.BindFieldName = null;
            this.customLable6.Color = System.Drawing.Color.Black;
            this.customLable6.ForeColorClicked = System.Drawing.Color.White;
            this.customLable6.GetControl = null;
            this.customLable6.Location = new System.Drawing.Point(19, 37);
            this.customLable6.Name = "customLable6";
            this.customLable6.OldValue = null;
            this.customLable6.ShadowDepth = 3;
            this.customLable6.Size = new System.Drawing.Size(56, 13);
            this.customLable6.Softness = 1.5F;
            this.customLable6.TabIndex = 7;
            this.customLable6.Text = "Đối tượng ";
            this.customLable6.UseShadow = false;
            this.customLable6.UseZoom = false;
            // 
            // cboDoiTuongDichVu
            // 
            this.cboDoiTuongDichVu.AutoComplete = false;
            this.cboDoiTuongDichVu.AutoDropdown = false;
            this.cboDoiTuongDichVu.BackColorEven = System.Drawing.Color.White;
            this.cboDoiTuongDichVu.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboDoiTuongDichVu.ColumnNames = "";
            this.cboDoiTuongDichVu.ColumnWidthDefault = 75;
            this.cboDoiTuongDichVu.ColumnWidths = "";
            this.cboDoiTuongDichVu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDoiTuongDichVu.FormattingEnabled = true;
            this.cboDoiTuongDichVu.LinkedColumnIndex = 0;
            this.cboDoiTuongDichVu.LinkedColumnIndex1 = 0;
            this.cboDoiTuongDichVu.LinkedColumnIndex2 = 0;
            this.cboDoiTuongDichVu.LinkedTextBox = null;
            this.cboDoiTuongDichVu.LinkedTextBox1 = null;
            this.cboDoiTuongDichVu.LinkedTextBox2 = null;
            this.cboDoiTuongDichVu.Location = new System.Drawing.Point(101, 33);
            this.cboDoiTuongDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboDoiTuongDichVu.Name = "cboDoiTuongDichVu";
            this.cboDoiTuongDichVu.Size = new System.Drawing.Size(88, 22);
            this.cboDoiTuongDichVu.TabIndex = 8;
            // 
            // lblMess
            // 
            this.lblMess.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblMess.Appearance.Options.UseForeColor = true;
            this.lblMess.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMess.Location = new System.Drawing.Point(596, 2);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(0, 13);
            this.lblMess.TabIndex = 68;
            // 
            // pnBarcode
            // 
            this.pnBarcode.Controls.Add(this.txtTobarcode);
            this.pnBarcode.Controls.Add(this.customLable9);
            this.pnBarcode.Controls.Add(this.txtFromBarcode);
            this.pnBarcode.Controls.Add(this.customLable8);
            this.pnBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnBarcode.Location = new System.Drawing.Point(0, 113);
            this.pnBarcode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnBarcode.Name = "pnBarcode";
            this.pnBarcode.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnBarcode.Size = new System.Drawing.Size(598, 40);
            this.pnBarcode.TabIndex = 4;
            this.pnBarcode.TabStop = false;
            this.pnBarcode.Text = "Thông tin nhập";
            this.pnBarcode.Visible = false;
            // 
            // txtTobarcode
            // 
            this.txtTobarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTobarcode.BackColorEnter = System.Drawing.Color.Yellow;
            this.txtTobarcode.BindFieldName = null;
            this.txtTobarcode.ForceColorEnter = System.Drawing.Color.DarkRed;
            this.txtTobarcode.Location = new System.Drawing.Point(304, 16);
            this.txtTobarcode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTobarcode.Name = "txtTobarcode";
            this.txtTobarcode.OldValue = null;
            this.txtTobarcode.Size = new System.Drawing.Size(91, 21);
            this.txtTobarcode.TabIndex = 66;
            this.txtTobarcode.UseFocusColor = true;
            // 
            // customLable9
            // 
            this.customLable9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customLable9.AutoSize = true;
            this.customLable9.BindFieldName = null;
            this.customLable9.Color = System.Drawing.Color.Black;
            this.customLable9.ForeColorClicked = System.Drawing.Color.White;
            this.customLable9.GetControl = null;
            this.customLable9.Location = new System.Drawing.Point(221, 19);
            this.customLable9.Name = "customLable9";
            this.customLable9.OldValue = null;
            this.customLable9.ShadowDepth = 3;
            this.customLable9.Size = new System.Drawing.Size(47, 15);
            this.customLable9.Softness = 1.5F;
            this.customLable9.TabIndex = 65;
            this.customLable9.Text = "Đến số";
            this.customLable9.UseShadow = false;
            this.customLable9.UseZoom = false;
            // 
            // txtFromBarcode
            // 
            this.txtFromBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFromBarcode.BackColorEnter = System.Drawing.Color.Yellow;
            this.txtFromBarcode.BindFieldName = null;
            this.txtFromBarcode.ForceColorEnter = System.Drawing.Color.DarkRed;
            this.txtFromBarcode.Location = new System.Drawing.Point(101, 13);
            this.txtFromBarcode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtFromBarcode.Name = "txtFromBarcode";
            this.txtFromBarcode.OldValue = null;
            this.txtFromBarcode.Size = new System.Drawing.Size(88, 21);
            this.txtFromBarcode.TabIndex = 1;
            this.txtFromBarcode.UseFocusColor = true;
            // 
            // customLable8
            // 
            this.customLable8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customLable8.AutoSize = true;
            this.customLable8.BindFieldName = null;
            this.customLable8.Color = System.Drawing.Color.Black;
            this.customLable8.ForeColorClicked = System.Drawing.Color.White;
            this.customLable8.GetControl = null;
            this.customLable8.Location = new System.Drawing.Point(19, 19);
            this.customLable8.Name = "customLable8";
            this.customLable8.OldValue = null;
            this.customLable8.ShadowDepth = 3;
            this.customLable8.Size = new System.Drawing.Size(53, 15);
            this.customLable8.Softness = 1.5F;
            this.customLable8.TabIndex = 0;
            this.customLable8.Text = "Barcode";
            this.customLable8.UseShadow = false;
            this.customLable8.UseZoom = false;
            // 
            // pnExcel
            // 
            this.pnExcel.Controls.Add(this.btnExportToExcel);
            this.pnExcel.Controls.Add(this.pnNguonChiDinh);
            this.pnExcel.Controls.Add(this.chkChiDInhChuaLayMau);
            this.pnExcel.Controls.Add(this.chkHISMode);
            this.pnExcel.Controls.Add(this.btnBrowsePath);
            this.pnExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnExcel.Location = new System.Drawing.Point(0, 41);
            this.pnExcel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnExcel.Name = "pnExcel";
            this.pnExcel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnExcel.Size = new System.Drawing.Size(598, 72);
            this.pnExcel.TabIndex = 0;
            this.pnExcel.TabStop = false;
            this.pnExcel.Text = "Đọc file excel";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnExportToExcel.BackColorHover = System.Drawing.Color.Empty;
            this.btnExportToExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnExportToExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnExportToExcel.BorderRadius = 5;
            this.btnExportToExcel.BorderSize = 1;
            this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnExportToExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportToExcel.Location = new System.Drawing.Point(496, 18);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(88, 49);
            this.btnExportToExcel.TabIndex = 7;
            this.btnExportToExcel.Text = "Xuất Excel";
            this.btnExportToExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportToExcel.TextColor = System.Drawing.Color.Black;
            this.btnExportToExcel.UseHightLight = true;
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // pnNguonChiDinh
            // 
            this.pnNguonChiDinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnNguonChiDinh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnNguonChiDinh.Controls.Add(this.radChiDinhNhapDanhSach);
            this.pnNguonChiDinh.Controls.Add(this.label2);
            this.pnNguonChiDinh.Controls.Add(this.radChiDinhTuExcel);
            this.pnNguonChiDinh.Enabled = false;
            this.pnNguonChiDinh.Location = new System.Drawing.Point(22, 42);
            this.pnNguonChiDinh.Name = "pnNguonChiDinh";
            this.pnNguonChiDinh.Size = new System.Drawing.Size(370, 25);
            this.pnNguonChiDinh.TabIndex = 6;
            // 
            // radChiDinhNhapDanhSach
            // 
            this.radChiDinhNhapDanhSach.AutoSize = true;
            this.radChiDinhNhapDanhSach.Location = new System.Drawing.Point(251, 2);
            this.radChiDinhNhapDanhSach.Name = "radChiDinhNhapDanhSach";
            this.radChiDinhNhapDanhSach.Size = new System.Drawing.Size(104, 17);
            this.radChiDinhNhapDanhSach.TabIndex = 1;
            this.radChiDinhNhapDanhSach.Text = "Danh sách chọn";
            this.radChiDinhNhapDanhSach.UseVisualStyleBackColor = true;
            this.radChiDinhNhapDanhSach.CheckedChanged += new System.EventHandler(this.radChiDinhNhapDanhSach_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nguồn chỉ định:";
            // 
            // radChiDinhTuExcel
            // 
            this.radChiDinhTuExcel.AutoSize = true;
            this.radChiDinhTuExcel.Checked = true;
            this.radChiDinhTuExcel.Location = new System.Drawing.Point(120, 2);
            this.radChiDinhTuExcel.Name = "radChiDinhTuExcel";
            this.radChiDinhTuExcel.Size = new System.Drawing.Size(97, 17);
            this.radChiDinhTuExcel.TabIndex = 0;
            this.radChiDinhTuExcel.TabStop = true;
            this.radChiDinhTuExcel.Text = "Trong file excel";
            this.radChiDinhTuExcel.UseVisualStyleBackColor = true;
            this.radChiDinhTuExcel.CheckedChanged += new System.EventHandler(this.radChiDinhTuExcel_CheckedChanged);
            // 
            // chkChiDInhChuaLayMau
            // 
            this.chkChiDInhChuaLayMau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkChiDInhChuaLayMau.AutoSize = true;
            this.chkChiDInhChuaLayMau.Checked = true;
            this.chkChiDInhChuaLayMau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChiDInhChuaLayMau.Location = new System.Drawing.Point(162, 18);
            this.chkChiDInhChuaLayMau.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkChiDInhChuaLayMau.Name = "chkChiDInhChuaLayMau";
            this.chkChiDInhChuaLayMau.Size = new System.Drawing.Size(233, 19);
            this.chkChiDInhChuaLayMau.TabIndex = 4;
            this.chkChiDInhChuaLayMau.Text = "Chỉ lấy chỉ định chưa lấy mẫu trên HIS";
            this.chkChiDInhChuaLayMau.UseVisualStyleBackColor = true;
            this.chkChiDInhChuaLayMau.Visible = false;
            // 
            // chkHISMode
            // 
            this.chkHISMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkHISMode.AutoSize = true;
            this.chkHISMode.Checked = true;
            this.chkHISMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHISMode.Location = new System.Drawing.Point(22, 18);
            this.chkHISMode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkHISMode.Name = "chkHISMode";
            this.chkHISMode.Size = new System.Drawing.Size(132, 19);
            this.chkHISMode.TabIndex = 3;
            this.chkHISMode.Text = "Lấy thông tin từ HIS";
            this.chkHISMode.UseVisualStyleBackColor = true;
            this.chkHISMode.CheckedChanged += new System.EventHandler(this.chkHISMode_CheckedChanged);
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBrowsePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnBrowsePath.BackColorHover = System.Drawing.Color.Empty;
            this.btnBrowsePath.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnBrowsePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnBrowsePath.BorderRadius = 5;
            this.btnBrowsePath.BorderSize = 1;
            this.btnBrowsePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowsePath.ForceColorHover = System.Drawing.Color.Empty;
            this.btnBrowsePath.ForeColor = System.Drawing.Color.Black;
            this.btnBrowsePath.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowsePath.Image")));
            this.btnBrowsePath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBrowsePath.Location = new System.Drawing.Point(395, 18);
            this.btnBrowsePath.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(95, 49);
            this.btnBrowsePath.TabIndex = 2;
            this.btnBrowsePath.Text = "Đọc file Excel";
            this.btnBrowsePath.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBrowsePath.TextColor = System.Drawing.Color.Black;
            this.btnBrowsePath.UseHightLight = true;
            this.btnBrowsePath.UseVisualStyleBackColor = false;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.chkIncodeKhiNhap);
            this.groupBox3.Controls.Add(this.radInputWithBarcodeRange);
            this.groupBox3.Controls.Add(this.radInputWithExcelFile);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(598, 41);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CHỌN CHẾ ĐÔ NHẬP";
            // 
            // chkIncodeKhiNhap
            // 
            this.chkIncodeKhiNhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkIncodeKhiNhap.AutoSize = true;
            this.chkIncodeKhiNhap.BackColor = System.Drawing.Color.Cornsilk;
            this.chkIncodeKhiNhap.Checked = true;
            this.chkIncodeKhiNhap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncodeKhiNhap.Location = new System.Drawing.Point(418, 18);
            this.chkIncodeKhiNhap.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.chkIncodeKhiNhap.Name = "chkIncodeKhiNhap";
            this.chkIncodeKhiNhap.Size = new System.Drawing.Size(134, 19);
            this.chkIncodeKhiNhap.TabIndex = 67;
            this.chkIncodeKhiNhap.Text = "In barcode khi nhập";
            this.chkIncodeKhiNhap.UseVisualStyleBackColor = false;
            // 
            // radInputWithBarcodeRange
            // 
            this.radInputWithBarcodeRange.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radInputWithBarcodeRange.AutoSize = true;
            this.radInputWithBarcodeRange.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInputWithBarcodeRange.Location = new System.Drawing.Point(219, 18);
            this.radInputWithBarcodeRange.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radInputWithBarcodeRange.Name = "radInputWithBarcodeRange";
            this.radInputWithBarcodeRange.Size = new System.Drawing.Size(191, 19);
            this.radInputWithBarcodeRange.TabIndex = 1;
            this.radInputWithBarcodeRange.Text = "NHẬP THEO DÃY SỐ LIÊN TỤC";
            this.radInputWithBarcodeRange.UseVisualStyleBackColor = false;
            this.radInputWithBarcodeRange.CheckedChanged += new System.EventHandler(this.radInputWithBarcode_CheckedChanged);
            // 
            // radInputWithExcelFile
            // 
            this.radInputWithExcelFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radInputWithExcelFile.AutoSize = true;
            this.radInputWithExcelFile.BackColor = System.Drawing.Color.Yellow;
            this.radInputWithExcelFile.Checked = true;
            this.radInputWithExcelFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInputWithExcelFile.Location = new System.Drawing.Point(70, 18);
            this.radInputWithExcelFile.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radInputWithExcelFile.Name = "radInputWithExcelFile";
            this.radInputWithExcelFile.Size = new System.Drawing.Size(143, 19);
            this.radInputWithExcelFile.TabIndex = 0;
            this.radInputWithExcelFile.TabStop = true;
            this.radInputWithExcelFile.Text = "NHẬP TỪ FILE EXCEL";
            this.radInputWithExcelFile.UseVisualStyleBackColor = false;
            this.radInputWithExcelFile.CheckedChanged += new System.EventHandler(this.radInputWithExcelFile_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gcDanhSachChiDinh);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(417, 245);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách chỉ định đã chọn";
            // 
            // gcDanhSachChiDinh
            // 
            this.gcDanhSachChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSachChiDinh.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDanhSachChiDinh.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDanhSachChiDinh.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDanhSachChiDinh.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDanhSachChiDinh.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gcDanhSachChiDinh.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDanhSachChiDinh.EmbeddedNavigator.TextStringFormat = "Chỉ định {0} / {1}";
            this.gcDanhSachChiDinh.Location = new System.Drawing.Point(3, 15);
            this.gcDanhSachChiDinh.MainView = this.gvDanhSachChiDinh;
            this.gcDanhSachChiDinh.Name = "gcDanhSachChiDinh";
            this.gcDanhSachChiDinh.Size = new System.Drawing.Size(411, 228);
            this.gcDanhSachChiDinh.TabIndex = 8;
            this.gcDanhSachChiDinh.UseEmbeddedNavigator = true;
            this.gcDanhSachChiDinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSachChiDinh});
            // 
            // gvDanhSachChiDinh
            // 
            this.gvDanhSachChiDinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IsProfile,
            this.TenChiDinh,
            this.MaChiDinh,
            this.TenLoaiDichVu,
            this.MaLoaiDichVu});
            this.gvDanhSachChiDinh.GridControl = this.gcDanhSachChiDinh;
            this.gvDanhSachChiDinh.Name = "gvDanhSachChiDinh";
            this.gvDanhSachChiDinh.OptionsPrint.UsePrintStyles = false;
            this.gvDanhSachChiDinh.OptionsView.ColumnAutoWidth = false;
            this.gvDanhSachChiDinh.OptionsView.ShowGroupPanel = false;
            // 
            // IsProfile
            // 
            this.IsProfile.Caption = "Nhập theo danh sách";
            this.IsProfile.FieldName = "IsProfile";
            this.IsProfile.Name = "IsProfile";
            this.IsProfile.Visible = true;
            this.IsProfile.VisibleIndex = 2;
            this.IsProfile.Width = 110;
            // 
            // TenChiDinh
            // 
            this.TenChiDinh.Caption = "Tên chỉ định";
            this.TenChiDinh.FieldName = "TenChiDinh";
            this.TenChiDinh.Name = "TenChiDinh";
            this.TenChiDinh.Visible = true;
            this.TenChiDinh.VisibleIndex = 0;
            this.TenChiDinh.Width = 228;
            // 
            // MaChiDinh
            // 
            this.MaChiDinh.Caption = "Mã chỉ định";
            this.MaChiDinh.FieldName = "MaChiDinh";
            this.MaChiDinh.Name = "MaChiDinh";
            this.MaChiDinh.Visible = true;
            this.MaChiDinh.VisibleIndex = 1;
            // 
            // TenLoaiDichVu
            // 
            this.TenLoaiDichVu.Caption = "Dịch vụ";
            this.TenLoaiDichVu.FieldName = "TenLoaiDichVu";
            this.TenLoaiDichVu.Name = "TenLoaiDichVu";
            this.TenLoaiDichVu.Visible = true;
            this.TenLoaiDichVu.VisibleIndex = 3;
            this.TenLoaiDichVu.Width = 62;
            // 
            // MaLoaiDichVu
            // 
            this.MaLoaiDichVu.Caption = "Mã loại dịch vụ";
            this.MaLoaiDichVu.FieldName = "MaLoaiDichVu";
            this.MaLoaiDichVu.Name = "MaLoaiDichVu";
            this.MaLoaiDichVu.Visible = true;
            this.MaLoaiDichVu.VisibleIndex = 4;
            this.MaLoaiDichVu.Width = 94;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXoaChiDinh);
            this.panel1.Controls.Add(this.dgvXetNghiem);
            this.panel1.Controls.Add(this.customLable5);
            this.panel1.Controls.Add(this.txtTimDichVu);
            this.panel1.Controls.Add(this.btnThemChiDinh);
            this.panel1.Controls.Add(this.txtNhomDichVu);
            this.panel1.Controls.Add(this.cboNhomDichVu);
            this.panel1.Controls.Add(this.customLable3);
            this.panel1.Controls.Add(this.txtLoaiDichVu);
            this.panel1.Controls.Add(this.cboLoaiDichVu);
            this.panel1.Controls.Add(this.customLable2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 178);
            this.panel1.TabIndex = 8;
            // 
            // btnXoaChiDinh
            // 
            this.btnXoaChiDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoaChiDinh.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaChiDinh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnXoaChiDinh.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoaChiDinh.BorderRadius = 5;
            this.btnXoaChiDinh.BorderSize = 1;
            this.btnXoaChiDinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaChiDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaChiDinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaChiDinh.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaChiDinh.ForeColor = System.Drawing.Color.Black;
            this.btnXoaChiDinh.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaChiDinh.Image")));
            this.btnXoaChiDinh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnXoaChiDinh.Location = new System.Drawing.Point(306, 70);
            this.btnXoaChiDinh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXoaChiDinh.Name = "btnXoaChiDinh";
            this.btnXoaChiDinh.Size = new System.Drawing.Size(108, 51);
            this.btnXoaChiDinh.TabIndex = 12;
            this.btnXoaChiDinh.Text = "Xóa chỉ định";
            this.btnXoaChiDinh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXoaChiDinh.TextColor = System.Drawing.Color.Black;
            this.btnXoaChiDinh.UseHightLight = true;
            this.btnXoaChiDinh.UseVisualStyleBackColor = false;
            this.btnXoaChiDinh.Click += new System.EventHandler(this.btnXoaChiDinh_Click_1);
            // 
            // dgvXetNghiem
            // 
            this.dgvXetNghiem.AllowUserToAddRows = false;
            this.dgvXetNghiem.AllowUserToDeleteRows = false;
            this.dgvXetNghiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXetNghiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Checked,
            this.TenXN,
            this.MaXN,
            this.MaLoaiDichVuAdd,
            this.MaChiDinhAdd});
            this.dgvXetNghiem.Location = new System.Drawing.Point(9, 67);
            this.dgvXetNghiem.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dgvXetNghiem.Name = "dgvXetNghiem";
            this.dgvXetNghiem.RowHeadersWidth = 23;
            this.dgvXetNghiem.Size = new System.Drawing.Size(291, 109);
            this.dgvXetNghiem.TabIndex = 11;
            // 
            // Checked
            // 
            this.Checked.DataPropertyName = "tudongchon";
            this.Checked.HeaderText = "";
            this.Checked.Name = "Checked";
            this.Checked.Width = 25;
            // 
            // TenXN
            // 
            this.TenXN.DataPropertyName = "TenXN";
            this.TenXN.HeaderText = "Tên xét nghiệm";
            this.TenXN.Name = "TenXN";
            this.TenXN.Width = 350;
            // 
            // MaXN
            // 
            this.MaXN.DataPropertyName = "MaXN";
            this.MaXN.HeaderText = "Mã XN";
            this.MaXN.Name = "MaXN";
            this.MaXN.Visible = false;
            // 
            // MaLoaiDichVuAdd
            // 
            this.MaLoaiDichVuAdd.DataPropertyName = "MaLoaiDichVu";
            this.MaLoaiDichVuAdd.HeaderText = "Mã loại dịch vụ";
            this.MaLoaiDichVuAdd.Name = "MaLoaiDichVuAdd";
            this.MaLoaiDichVuAdd.Visible = false;
            // 
            // MaChiDinhAdd
            // 
            this.MaChiDinhAdd.DataPropertyName = "MaChiDinh";
            this.MaChiDinhAdd.HeaderText = "Mã chỉ định";
            this.MaChiDinhAdd.Name = "MaChiDinhAdd";
            this.MaChiDinhAdd.Visible = false;
            // 
            // customLable5
            // 
            this.customLable5.AutoSize = true;
            this.customLable5.BindFieldName = null;
            this.customLable5.Color = System.Drawing.Color.Black;
            this.customLable5.ForeColorClicked = System.Drawing.Color.White;
            this.customLable5.GetControl = null;
            this.customLable5.Location = new System.Drawing.Point(7, 49);
            this.customLable5.Name = "customLable5";
            this.customLable5.OldValue = null;
            this.customLable5.ShadowDepth = 3;
            this.customLable5.Size = new System.Drawing.Size(78, 13);
            this.customLable5.Softness = 1.5F;
            this.customLable5.TabIndex = 10;
            this.customLable5.Text = "Tìm xét nghiệm";
            this.customLable5.UseShadow = false;
            this.customLable5.UseZoom = false;
            // 
            // txtTimDichVu
            // 
            this.txtTimDichVu.Location = new System.Drawing.Point(105, 46);
            this.txtTimDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTimDichVu.Name = "txtTimDichVu";
            this.txtTimDichVu.Size = new System.Drawing.Size(283, 20);
            this.txtTimDichVu.TabIndex = 9;
            this.txtTimDichVu.TextChanged += new System.EventHandler(this.txtTimDichVu_TextChanged);
            this.txtTimDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimDichVu_KeyPress);
            this.txtTimDichVu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTimDichVu_KeyUp);
            // 
            // btnThemChiDinh
            // 
            this.btnThemChiDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThemChiDinh.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemChiDinh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnThemChiDinh.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemChiDinh.BorderRadius = 5;
            this.btnThemChiDinh.BorderSize = 1;
            this.btnThemChiDinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemChiDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemChiDinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemChiDinh.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemChiDinh.ForeColor = System.Drawing.Color.Black;
            this.btnThemChiDinh.Image = ((System.Drawing.Image)(resources.GetObject("btnThemChiDinh.Image")));
            this.btnThemChiDinh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThemChiDinh.Location = new System.Drawing.Point(306, 125);
            this.btnThemChiDinh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThemChiDinh.Name = "btnThemChiDinh";
            this.btnThemChiDinh.Size = new System.Drawing.Size(108, 50);
            this.btnThemChiDinh.TabIndex = 8;
            this.btnThemChiDinh.Text = "Chọn chỉ định";
            this.btnThemChiDinh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemChiDinh.TextColor = System.Drawing.Color.Black;
            this.btnThemChiDinh.UseHightLight = true;
            this.btnThemChiDinh.UseVisualStyleBackColor = false;
            this.btnThemChiDinh.Click += new System.EventHandler(this.btnThemChiDinh_Click);
            // 
            // txtNhomDichVu
            // 
            this.txtNhomDichVu.Location = new System.Drawing.Point(194, 26);
            this.txtNhomDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtNhomDichVu.Name = "txtNhomDichVu";
            this.txtNhomDichVu.Size = new System.Drawing.Size(194, 20);
            this.txtNhomDichVu.TabIndex = 6;
            // 
            // cboNhomDichVu
            // 
            this.cboNhomDichVu.AutoComplete = false;
            this.cboNhomDichVu.AutoDropdown = false;
            this.cboNhomDichVu.BackColorEven = System.Drawing.Color.White;
            this.cboNhomDichVu.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboNhomDichVu.ColumnNames = "";
            this.cboNhomDichVu.ColumnWidthDefault = 75;
            this.cboNhomDichVu.ColumnWidths = "";
            this.cboNhomDichVu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomDichVu.FormattingEnabled = true;
            this.cboNhomDichVu.LinkedColumnIndex = 0;
            this.cboNhomDichVu.LinkedColumnIndex1 = 0;
            this.cboNhomDichVu.LinkedColumnIndex2 = 0;
            this.cboNhomDichVu.LinkedTextBox = null;
            this.cboNhomDichVu.LinkedTextBox1 = null;
            this.cboNhomDichVu.LinkedTextBox2 = null;
            this.cboNhomDichVu.Location = new System.Drawing.Point(105, 25);
            this.cboNhomDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboNhomDichVu.Name = "cboNhomDichVu";
            this.cboNhomDichVu.Size = new System.Drawing.Size(84, 21);
            this.cboNhomDichVu.TabIndex = 5;
            this.cboNhomDichVu.SelectionChangeCommitted += new System.EventHandler(this.cboNhomDichVu_SelectionChangeCommitted);
            this.cboNhomDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomDichVu_KeyPress);
            // 
            // customLable3
            // 
            this.customLable3.AutoSize = true;
            this.customLable3.BindFieldName = null;
            this.customLable3.Color = System.Drawing.Color.Black;
            this.customLable3.ForeColorClicked = System.Drawing.Color.White;
            this.customLable3.GetControl = null;
            this.customLable3.Location = new System.Drawing.Point(7, 28);
            this.customLable3.Name = "customLable3";
            this.customLable3.OldValue = null;
            this.customLable3.ShadowDepth = 3;
            this.customLable3.Size = new System.Drawing.Size(89, 13);
            this.customLable3.Softness = 1.5F;
            this.customLable3.TabIndex = 4;
            this.customLable3.Text = "Nhóm xét nghiệm";
            this.customLable3.UseShadow = false;
            this.customLable3.UseZoom = false;
            // 
            // txtLoaiDichVu
            // 
            this.txtLoaiDichVu.Location = new System.Drawing.Point(194, 2);
            this.txtLoaiDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtLoaiDichVu.Name = "txtLoaiDichVu";
            this.txtLoaiDichVu.Size = new System.Drawing.Size(194, 20);
            this.txtLoaiDichVu.TabIndex = 3;
            // 
            // cboLoaiDichVu
            // 
            this.cboLoaiDichVu.AutoComplete = false;
            this.cboLoaiDichVu.AutoDropdown = false;
            this.cboLoaiDichVu.BackColorEven = System.Drawing.Color.White;
            this.cboLoaiDichVu.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboLoaiDichVu.ColumnNames = "";
            this.cboLoaiDichVu.ColumnWidthDefault = 75;
            this.cboLoaiDichVu.ColumnWidths = "";
            this.cboLoaiDichVu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoaiDichVu.FormattingEnabled = true;
            this.cboLoaiDichVu.LinkedColumnIndex = 0;
            this.cboLoaiDichVu.LinkedColumnIndex1 = 0;
            this.cboLoaiDichVu.LinkedColumnIndex2 = 0;
            this.cboLoaiDichVu.LinkedTextBox = null;
            this.cboLoaiDichVu.LinkedTextBox1 = null;
            this.cboLoaiDichVu.LinkedTextBox2 = null;
            this.cboLoaiDichVu.Location = new System.Drawing.Point(105, 2);
            this.cboLoaiDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboLoaiDichVu.Name = "cboLoaiDichVu";
            this.cboLoaiDichVu.Size = new System.Drawing.Size(84, 21);
            this.cboLoaiDichVu.TabIndex = 2;
            this.cboLoaiDichVu.SelectionChangeCommitted += new System.EventHandler(this.cboLoaiDichVu_SelectionChangeCommitted);
            this.cboLoaiDichVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLoaiDichVu_KeyPress);
            // 
            // customLable2
            // 
            this.customLable2.AutoSize = true;
            this.customLable2.BindFieldName = null;
            this.customLable2.Color = System.Drawing.Color.Black;
            this.customLable2.ForeColorClicked = System.Drawing.Color.White;
            this.customLable2.GetControl = null;
            this.customLable2.Location = new System.Drawing.Point(7, 5);
            this.customLable2.Name = "customLable2";
            this.customLable2.OldValue = null;
            this.customLable2.ShadowDepth = 3;
            this.customLable2.Size = new System.Drawing.Size(65, 13);
            this.customLable2.Softness = 1.5F;
            this.customLable2.TabIndex = 1;
            this.customLable2.Text = "Loại dịch vụ";
            this.customLable2.UseShadow = false;
            this.customLable2.UseZoom = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Column1";
            this.dataGridViewTextBoxColumn1.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Column2";
            this.dataGridViewTextBoxColumn2.HeaderText = "Họ tên";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Column3";
            this.dataGridViewTextBoxColumn3.HeaderText = "Năm sinh";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Column4";
            this.dataGridViewTextBoxColumn4.HeaderText = "Giới tính";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Column5";
            this.dataGridViewTextBoxColumn5.HeaderText = "Địa chỉ";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Column6";
            this.dataGridViewTextBoxColumn6.HeaderText = "Đơn vị";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TenChiDinh";
            this.dataGridViewTextBoxColumn7.HeaderText = "Tên chỉ định";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 350;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "MaChiDinh";
            this.dataGridViewTextBoxColumn8.HeaderText = "Mã chỉ định";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TenLoaiDichVu";
            this.dataGridViewTextBoxColumn9.HeaderText = "Dịch vụ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MaLoaiDichVu";
            this.dataGridViewTextBoxColumn10.HeaderText = "Mã loại dịch vụ";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // FrmNhapKSK
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1029, 427);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "FrmNhapKSK";
            this.Text = "Nhập khám sức khỏe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNhapKSK_FormClosing);
            this.Load += new System.EventHandler(this.FrmNhapKSK_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnDonVi)).EndInit();
            this.pnDonVi.ResumeLayout(false);
            this.pnDonVi.PerformLayout();
            this.pnBarcode.ResumeLayout(false);
            this.pnBarcode.PerformLayout();
            this.pnExcel.ResumeLayout(false);
            this.pnExcel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnNguonChiDinh)).EndInit();
            this.pnNguonChiDinh.ResumeLayout(false);
            this.pnNguonChiDinh.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSachChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSachChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXetNghiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private System.Windows.Forms.GroupBox pnExcel;
        private TPH.Controls.TPHNormalButton btnBrowsePath;
        private System.Windows.Forms.TextBox txtNhomDichVu;
        private Common.Controls.CustomComboBox cboNhomDichVu;
        private Common.Controls.CustomLable customLable3;
        private System.Windows.Forms.TextBox txtLoaiDichVu;
        private Common.Controls.CustomComboBox cboLoaiDichVu;
        private Common.Controls.CustomLable customLable2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.PanelControl panel1;
        private TPH.Controls.TPHNormalButton btnThucHien;
        private TPH.Controls.TPHNormalButton btnThemChiDinh;
        private Common.Controls.CustomLable customLable5;
        private System.Windows.Forms.TextBox txtTimDichVu;
        private System.Windows.Forms.TextBox txtDoiTuongDichVu;
        private Common.Controls.CustomComboBox cboDoiTuongDichVu;
        private Common.Controls.CustomLable customLable6;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radInputWithBarcodeRange;
        private System.Windows.Forms.RadioButton radInputWithExcelFile;
        private System.Windows.Forms.GroupBox pnBarcode;
        private Common.Controls.CustomTextBox txtFromBarcode;
        private Common.Controls.CustomLable customLable8;
        private Common.Controls.CustomTextBox txtTobarcode;
        private Common.Controls.CustomLable customLable9;
        private DevExpress.XtraEditors.PanelControl panel3;
        private DevExpress.XtraEditors.LabelControl label13;
        private DevExpress.XtraEditors.PanelControl pnDonVi;
        private System.Windows.Forms.TextBox txtDonVi;
        private Common.Controls.CustomComboBox cboDonVi;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.DataGridView dgvXetNghiem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Checked;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiDichVuAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiDinhAdd;
        private System.Windows.Forms.CheckBox chkHISMode;
        private System.Windows.Forms.CheckBox chkIncodeKhiNhap;
        private System.Windows.Forms.CheckBox chkTuTaoCode;
        private System.Windows.Forms.CheckBox chkChiDInhChuaLayMau;
        private AppCode.ucSearchLookupEditor_Doctor ucSearchLookupEditor_BSChiDinh;
        private DevExpress.XtraEditors.PanelControl pnNguonChiDinh;
        private System.Windows.Forms.RadioButton radChiDinhNhapDanhSach;
        private System.Windows.Forms.RadioButton radChiDinhTuExcel;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraGrid.GridControl gcDanhSachImport;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachImport;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNhanVien;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayDangKy;
        private DevExpress.XtraGrid.Columns.GridColumn colMaBN;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colSinhNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colMaChiDinhHIS;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayChiDinhHIS;
        private DevExpress.XtraGrid.Columns.GridColumn colNamSinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoBHYT;
        private DevExpress.XtraGrid.Columns.GridColumn colCMND_HC;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCapCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colQuocTich;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colDoituongBn;
        private DevExpress.XtraGrid.Columns.GridColumn colDoiTuongDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colBSChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colCTV;
        private DevExpress.XtraGrid.Columns.GridColumn colDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colChanDoan;
        private DevExpress.XtraGrid.Columns.GridColumn colChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colimportProfile;
        private DevExpress.XtraGrid.Columns.GridColumn colTglayMau;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiLaymau;
        private Controls.TPHNormalButton btnExportToExcel;
        private DevExpress.XtraGrid.GridControl gcDanhSachChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSachChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn IsProfile;
        private DevExpress.XtraGrid.Columns.GridColumn TenChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn MaChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn TenLoaiDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn MaLoaiDichVu;
        private Controls.TPHNormalButton btnXoaChiDinh;
        private DevExpress.XtraEditors.LabelControl lblMess;
    }
}