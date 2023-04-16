﻿using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    partial class FrmSinhHocPhanTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSinhHocPhanTu));
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnDanhSachBN = new DevExpress.XtraEditors.PanelControl();
            this.ucDanhSachBenhNhanXN1 = new TPH.LIS.App.AppCode.ucDanhSachBenhNhanXN();
            this.pnSignature = new DevExpress.XtraEditors.PanelControl();
            this.btnCloseSetting = new TPH.Controls.TPHNormalButton();
            this.cmdRefreshPrinter = new TPH.Controls.TPHNormalButton();
            this.listPrinter = new System.Windows.Forms.ListBox();
            this.panel25 = new DevExpress.XtraEditors.PanelControl();
            this.chkRePrint = new System.Windows.Forms.CheckBox();
            this.chkPrintTitle = new System.Windows.Forms.CheckBox();
            this.pnChonKyten = new DevExpress.XtraEditors.PanelControl();
            this.ucSearchLookupEditor_KyTentruongKhoa = new TPH.LIS.App.AppCode.ucSearchLookupEditor_KyTen();
            this.lblTruongKhoa = new DevExpress.XtraEditors.LabelControl();
            this.ucSearchLookupEditor_KyTenlanhdao = new TPH.LIS.App.AppCode.ucSearchLookupEditor_KyTen();
            this.lblKyLanhDao = new DevExpress.XtraEditors.LabelControl();
            this.btnSign = new TPH.Controls.TPHNormalButton();
            this.ucPatientInformation1 = new TPH.LIS.App.AppCode.ucPatientInformation();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageTachRoi = new DevExpress.XtraTab.XtraTabPage();
            this.pnKetQua_SHPT = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnChiDinh = new DevExpress.XtraEditors.PanelControl();
            this.dtgChiDInh = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.colMaTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaXN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenXN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaBenhPhamGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhuongPhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCSBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetqua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSHPTGenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguongTren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguongDuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDKBatThuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoKetQua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua_HeSoNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua_Lamtron = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_DaXacNhan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colChiDinh_NguoiXacNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_DaIn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colChiDinh_NguoiNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_NguoiSua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_NguoiXacNhan2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_ThoiGianXacNhanKQ2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMauInSHPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSoMau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua_KetQuaHeSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua_DaUpload = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colKetQua_LanUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_lanxn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDinh_ThoiGianXacNhanThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDS_IdMayXn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.bvChiDInh = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnResult_Containt = new DevExpress.XtraEditors.PanelControl();
            this.ucGroupHeader3 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.pnKetLuan = new DevExpress.XtraEditors.PanelControl();
            this.txtGhiChu = new TPH.LIS.Common.Controls.CustomTextBox(this.components);
            this.ucGroupHeaderChuThich = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.pnThongTinXN = new DevExpress.XtraEditors.PanelControl();
            this.panel5 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.rchThongTinXN_ThongThuong = new RicherTextBox.RicherTextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMaSoMau = new System.Windows.Forms.TextBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhuongPhap = new System.Windows.Forms.TextBox();
            this.ucSearchLookupEditor_DoiChieuSHPT1 = new TPH.LIS.App.AppCode.ucSearchLookupEditor_DoiChieuSHPT();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.btnThemDienGiai_ToRoi = new TPH.Controls.TPHNormalButton();
            this.btnXemDienGiai_ToRoi = new TPH.Controls.TPHNormalButton();
            this.lblPhieuIn = new DevExpress.XtraEditors.LabelControl();
            this.cboPhieuInSHPT = new System.Windows.Forms.ComboBox();
            this.chkValidWhenPrint = new System.Windows.Forms.CheckBox();
            this.btnLayThongTinTruocSHPT = new TPH.Controls.TPHNormalButton();
            this.chkInKhiXacNhanSHPT = new System.Windows.Forms.CheckBox();
            this.btnLuu = new TPH.Controls.TPHNormalButton();
            this.btnHuyXacNhanKetQua = new TPH.Controls.TPHNormalButton();
            this.btnXacNhanKetQua = new TPH.Controls.TPHNormalButton();
            this.btnXemIn = new TPH.Controls.TPHNormalButton();
            this.btnInketQua = new TPH.Controls.TPHNormalButton();
            this.lblAutoPrintStatus = new DevExpress.XtraEditors.LabelControl();
            this.chkInTheoChiDinh = new System.Windows.Forms.CheckBox();
            this.dtpTGDoiChieu = new TPH.LIS.Common.Controls.CustomDateTimePicker();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.chkKetQuaDaXacNhan = new System.Windows.Forms.CheckBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cboMayXn = new System.Windows.Forms.ComboBox();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCSBT = new System.Windows.Forms.TextBox();
            this.pnNgayInRoi = new DevExpress.XtraEditors.PanelControl();
            this.lblNgayInSHPTRoi = new DevExpress.XtraEditors.LabelControl();
            this.dtpGioInKQRoi = new System.Windows.Forms.DateTimePicker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ucGroupHeader5 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.xtraTabPageKQLuoi = new DevExpress.XtraTab.XtraTabPage();
            this.ucKetQuaThuongQuy1 = new TPH.LIS.App.AppCode.ucKetQuaThuongQuy();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainer4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.label36 = new DevExpress.XtraEditors.LabelControl();
            this.txtDeNghi = new System.Windows.Forms.TextBox();
            this.label33 = new DevExpress.XtraEditors.LabelControl();
            this.panel7 = new DevExpress.XtraEditors.PanelControl();
            this.btnLuuNX_DeNghi = new TPH.Controls.TPHNormalButton();
            this.ucGroupHeader4 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.pnChucNang = new DevExpress.XtraEditors.PanelControl();
            this.btnThemDienGiai_Luoi = new TPH.Controls.TPHNormalButton();
            this.btnXemDienGiai_Luoi = new TPH.Controls.TPHNormalButton();
            this.lblNgayInSHPTLuoi = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgayInKQLuoi = new System.Windows.Forms.DateTimePicker();
            this.lblPhieuIn2 = new DevExpress.XtraEditors.LabelControl();
            this.cboPhieuIn = new System.Windows.Forms.ComboBox();
            this.btnLayThongTinTruocTQ = new TPH.Controls.TPHNormalButton();
            this.btnLuuNguoiThucHienTQ = new TPH.Controls.TPHNormalButton();
            this.txtNguoiThucHienTQ = new System.Windows.Forms.TextBox();
            this.cboNguoiThcuHienTQ = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNguoiThucHienTQ = new TPH.LIS.Common.Controls.CustomDateTimePicker();
            this.chkInMau = new System.Windows.Forms.CheckBox();
            this.btnHuyXacNhanKQThuongQuy = new TPH.Controls.TPHNormalButton();
            this.btnXacNhanKQThuongQuy = new TPH.Controls.TPHNormalButton();
            this.chkTQ_InKhiXacNhan = new System.Windows.Forms.CheckBox();
            this.btnXemInKQThuongQuy = new TPH.Controls.TPHNormalButton();
            this.btnInKetQuaThuognQuy = new TPH.Controls.TPHNormalButton();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.chkChiInCoKetQua = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuLayHinhTuClipBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new TPH.Controls.TPHTabControl();
            this.tabKetQuaBN = new System.Windows.Forms.TabPage();
            this.tabKetQuaMay = new System.Windows.Forms.TabPage();
            this.analyzerResult1 = new TPH.LIS.Analyzer.Controls.AnalyzerResult();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucKiemSoatChiDinhChayMay = new TPH.LIS.Analyzer.Controls.ucKiemSoatDownloadMayXn();
            this.btnKQXetNghiem = new TPH.Controls.TPHNormalButton();
            this.btnKetQuaMay = new TPH.Controls.TPHNormalButton();
            this.btnChiDinhMay = new TPH.Controls.TPHNormalButton();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
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
            ((System.ComponentModel.ISupportInitialize)(this.pnDanhSachBN)).BeginInit();
            this.pnDanhSachBN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnSignature)).BeginInit();
            this.pnSignature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel25)).BeginInit();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnChonKyten)).BeginInit();
            this.pnChonKyten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPageTachRoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnKetQua_SHPT)).BeginInit();
            this.pnKetQua_SHPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel1)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel2)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnChiDinh)).BeginInit();
            this.pnChiDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiDInh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiDInh)).BeginInit();
            this.bvChiDInh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnResult_Containt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnKetLuan)).BeginInit();
            this.pnKetLuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnThongTinXN)).BeginInit();
            this.pnThongTinXN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel5)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnNgayInRoi)).BeginInit();
            this.pnNgayInRoi.SuspendLayout();
            this.xtraTabPageKQLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4.Panel1)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4.Panel2)).BeginInit();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnChucNang)).BeginInit();
            this.pnChucNang.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabKetQuaBN.SuspendLayout();
            this.tabKetQuaMay.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.lblTitle.Location = new System.Drawing.Point(28, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(232, 23);
            this.lblTitle.Text = "KẾT QUẢ SINH HỌC PHÂN TỬ";
            this.lblTitle.Visible = false;
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.tabControl1);
            this.pnContaint.Location = new System.Drawing.Point(0, 30);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(3);
            this.pnContaint.Size = new System.Drawing.Size(1115, 631);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(4);
            this.pnLabel.Size = new System.Drawing.Size(1115, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(756, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Size = new System.Drawing.Size(36, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(792, 0);
            this.lblMainESC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnMenu.Size = new System.Drawing.Size(1115, 30);
            this.pnMenu.Visible = true;
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Controls.Add(this.btnKQXetNghiem);
            this.xtraScrollableControlMain.Controls.Add(this.btnKetQuaMay);
            this.xtraScrollableControlMain.Controls.Add(this.btnChiDinhMay);
            this.xtraScrollableControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.xtraScrollableControlMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1115, 29);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.lblTitle, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.pnFormControl, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.ucGroupHeaderChonMain, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.btnChiDinhMay, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.btnKetQuaMay, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.btnKQXetNghiem, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.GroupCaption = "CHỨC NĂNG";
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(260, 2);
            this.ucGroupHeaderChonMain.Margin = new System.Windows.Forms.Padding(62, 27, 62, 27);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(1006, 2);
            this.pnFormControl.Margin = new System.Windows.Forms.Padding(4);
            this.pnFormControl.Size = new System.Drawing.Size(106, 27);
            this.pnFormControl.Visible = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnMinimize.Location = new System.Drawing.Point(4, 2);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4);
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            this.btnMaximize.Location = new System.Drawing.Point(31, 2);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(4);
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            this.tphIconButton1.Location = new System.Drawing.Point(59, 2);
            this.tphIconButton1.Margin = new System.Windows.Forms.Padding(4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Appearance.Options.UseBackColor = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnDanhSachBN);
            this.splitContainer1.Panel1.Controls.Add(this.pnSignature);
            this.splitContainer1.Panel1.Controls.Add(this.ucPatientInformation1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1095, 593);
            this.splitContainer1.SplitterPosition = 434;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnDanhSachBN
            // 
            this.pnDanhSachBN.Controls.Add(this.ucDanhSachBenhNhanXN1);
            this.pnDanhSachBN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDanhSachBN.Location = new System.Drawing.Point(0, 50);
            this.pnDanhSachBN.Name = "pnDanhSachBN";
            this.pnDanhSachBN.Size = new System.Drawing.Size(434, 470);
            this.pnDanhSachBN.TabIndex = 1;
            // 
            // ucDanhSachBenhNhanXN1
            // 
            this.ucDanhSachBenhNhanXN1.AutoScroll = true;
            this.ucDanhSachBenhNhanXN1.BackColor = System.Drawing.Color.Transparent;
            this.ucDanhSachBenhNhanXN1.Barcode = "";
            this.ucDanhSachBenhNhanXN1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDanhSachBenhNhanXN1.DungInDanhSach = true;
            this.ucDanhSachBenhNhanXN1.DungUploadHIS = true;
            this.ucDanhSachBenhNhanXN1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDanhSachBenhNhanXN1.Location = new System.Drawing.Point(2, 2);
            this.ucDanhSachBenhNhanXN1.LstDanhSachNhom = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDanhSachBenhNhanXN1.LstDanhSachNhom")));
            this.ucDanhSachBenhNhanXN1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ucDanhSachBenhNhanXN1.MinimumSize = new System.Drawing.Size(397, 182);
            this.ucDanhSachBenhNhanXN1.Name = "ucDanhSachBenhNhanXN1";
            this.ucDanhSachBenhNhanXN1.NgayNhanMau = new System.DateTime(2020, 3, 3, 14, 36, 33, 92);
            this.ucDanhSachBenhNhanXN1.ShowCheckChon = true;
            this.ucDanhSachBenhNhanXN1.ShowTuyChon = true;
            this.ucDanhSachBenhNhanXN1.Size = new System.Drawing.Size(430, 466);
            this.ucDanhSachBenhNhanXN1.TabIndex = 0;
            this.ucDanhSachBenhNhanXN1.InTheoDanhSach_Click += new System.EventHandler(this.ucDanhSachBenhNhanXN1_InTheoDanhSach_Click);
            // 
            // pnSignature
            // 
            this.pnSignature.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.pnSignature.Appearance.Options.UseBackColor = true;
            this.pnSignature.Controls.Add(this.btnCloseSetting);
            this.pnSignature.Controls.Add(this.cmdRefreshPrinter);
            this.pnSignature.Controls.Add(this.listPrinter);
            this.pnSignature.Controls.Add(this.panel25);
            this.pnSignature.Controls.Add(this.pnChonKyten);
            this.pnSignature.Controls.Add(this.btnSign);
            this.pnSignature.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSignature.Location = new System.Drawing.Point(0, 520);
            this.pnSignature.Margin = new System.Windows.Forms.Padding(2);
            this.pnSignature.Name = "pnSignature";
            this.pnSignature.Size = new System.Drawing.Size(434, 73);
            this.pnSignature.TabIndex = 94;
            // 
            // btnCloseSetting
            // 
            this.btnCloseSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseSetting.BackColorHover = System.Drawing.Color.Empty;
            this.btnCloseSetting.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCloseSetting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnCloseSetting.BorderRadius = 0;
            this.btnCloseSetting.BorderSize = 0;
            this.btnCloseSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseSetting.FlatAppearance.BorderSize = 0;
            this.btnCloseSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSetting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSetting.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCloseSetting.ForeColor = System.Drawing.Color.Black;
            this.btnCloseSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseSetting.Image")));
            this.btnCloseSetting.Location = new System.Drawing.Point(400, 48);
            this.btnCloseSetting.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCloseSetting.Name = "btnCloseSetting";
            this.btnCloseSetting.Size = new System.Drawing.Size(28, 24);
            this.btnCloseSetting.TabIndex = 103;
            this.btnCloseSetting.TextColor = System.Drawing.Color.Black;
            this.btnCloseSetting.UseHightLight = true;
            this.btnCloseSetting.UseVisualStyleBackColor = false;
            this.btnCloseSetting.Click += new System.EventHandler(this.btnCloseSetting_Click);
            // 
            // cmdRefreshPrinter
            // 
            this.cmdRefreshPrinter.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefreshPrinter.BackColorHover = System.Drawing.Color.Empty;
            this.cmdRefreshPrinter.BackgroundColor = System.Drawing.Color.Transparent;
            this.cmdRefreshPrinter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.cmdRefreshPrinter.BorderRadius = 0;
            this.cmdRefreshPrinter.BorderSize = 0;
            this.cmdRefreshPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdRefreshPrinter.FlatAppearance.BorderSize = 0;
            this.cmdRefreshPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefreshPrinter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefreshPrinter.ForceColorHover = System.Drawing.Color.Empty;
            this.cmdRefreshPrinter.ForeColor = System.Drawing.Color.Black;
            this.cmdRefreshPrinter.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefreshPrinter.Image")));
            this.cmdRefreshPrinter.Location = new System.Drawing.Point(400, 26);
            this.cmdRefreshPrinter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmdRefreshPrinter.Name = "cmdRefreshPrinter";
            this.cmdRefreshPrinter.Size = new System.Drawing.Size(28, 24);
            this.cmdRefreshPrinter.TabIndex = 90;
            this.cmdRefreshPrinter.TextColor = System.Drawing.Color.Black;
            this.cmdRefreshPrinter.UseHightLight = true;
            this.cmdRefreshPrinter.UseVisualStyleBackColor = false;
            this.cmdRefreshPrinter.Click += new System.EventHandler(this.btnRefreshPrinter_Click);
            // 
            // listPrinter
            // 
            this.listPrinter.Dock = System.Windows.Forms.DockStyle.Left;
            this.listPrinter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPrinter.FormattingEnabled = true;
            this.listPrinter.HorizontalScrollbar = true;
            this.listPrinter.ItemHeight = 15;
            this.listPrinter.Location = new System.Drawing.Point(122, 26);
            this.listPrinter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listPrinter.Name = "listPrinter";
            this.listPrinter.Size = new System.Drawing.Size(276, 45);
            this.listPrinter.TabIndex = 91;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.chkRePrint);
            this.panel25.Controls.Add(this.chkPrintTitle);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(2, 26);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(120, 45);
            this.panel25.TabIndex = 100;
            this.panel25.Visible = false;
            // 
            // chkRePrint
            // 
            this.chkRePrint.AutoSize = true;
            this.chkRePrint.Checked = true;
            this.chkRePrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRePrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRePrint.Location = new System.Drawing.Point(7, 27);
            this.chkRePrint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkRePrint.Name = "chkRePrint";
            this.chkRePrint.Size = new System.Drawing.Size(87, 19);
            this.chkRePrint.TabIndex = 94;
            this.chkRePrint.Text = "Phiếu in lại";
            this.chkRePrint.UseVisualStyleBackColor = true;
            this.chkRePrint.Visible = false;
            // 
            // chkPrintTitle
            // 
            this.chkPrintTitle.AutoSize = true;
            this.chkPrintTitle.Checked = true;
            this.chkPrintTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintTitle.Location = new System.Drawing.Point(7, 4);
            this.chkPrintTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkPrintTitle.Name = "chkPrintTitle";
            this.chkPrintTitle.Size = new System.Drawing.Size(94, 19);
            this.chkPrintTitle.TabIndex = 3;
            this.chkPrintTitle.Text = "In có tiêu đề";
            this.chkPrintTitle.UseVisualStyleBackColor = true;
            this.chkPrintTitle.Visible = false;
            // 
            // pnChonKyten
            // 
            this.pnChonKyten.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(59)))), ((int)(((byte)(65)))));
            this.pnChonKyten.Appearance.Options.UseBackColor = true;
            this.pnChonKyten.Controls.Add(this.ucSearchLookupEditor_KyTentruongKhoa);
            this.pnChonKyten.Controls.Add(this.lblTruongKhoa);
            this.pnChonKyten.Controls.Add(this.ucSearchLookupEditor_KyTenlanhdao);
            this.pnChonKyten.Controls.Add(this.lblKyLanhDao);
            this.pnChonKyten.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnChonKyten.Location = new System.Drawing.Point(2, 2);
            this.pnChonKyten.Name = "pnChonKyten";
            this.pnChonKyten.Size = new System.Drawing.Size(430, 24);
            this.pnChonKyten.TabIndex = 97;
            // 
            // ucSearchLookupEditor_KyTentruongKhoa
            // 
            this.ucSearchLookupEditor_KyTentruongKhoa.CatchEnterKey = false;
            this.ucSearchLookupEditor_KyTentruongKhoa.CatchTabKey = false;
            this.ucSearchLookupEditor_KyTentruongKhoa.ControlBack = null;
            this.ucSearchLookupEditor_KyTentruongKhoa.ControlNext = null;
            this.ucSearchLookupEditor_KyTentruongKhoa.DisplayMember = "";
            this.ucSearchLookupEditor_KyTentruongKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSearchLookupEditor_KyTentruongKhoa.Location = new System.Drawing.Point(265, 2);
            this.ucSearchLookupEditor_KyTentruongKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucSearchLookupEditor_KyTentruongKhoa.Name = "ucSearchLookupEditor_KyTentruongKhoa";
            this.ucSearchLookupEditor_KyTentruongKhoa.SelectedValue = null;
            this.ucSearchLookupEditor_KyTentruongKhoa.Size = new System.Drawing.Size(163, 20);
            this.ucSearchLookupEditor_KyTentruongKhoa.TabIndex = 104;
            this.ucSearchLookupEditor_KyTentruongKhoa.ValueMember = "";
            // 
            // lblTruongKhoa
            // 
            this.lblTruongKhoa.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruongKhoa.Appearance.Options.UseFont = true;
            this.lblTruongKhoa.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTruongKhoa.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTruongKhoa.Location = new System.Drawing.Point(184, 2);
            this.lblTruongKhoa.Name = "lblTruongKhoa";
            this.lblTruongKhoa.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblTruongKhoa.Size = new System.Drawing.Size(81, 20);
            this.lblTruongKhoa.TabIndex = 96;
            this.lblTruongKhoa.Text = "Trưởng khoa";
            // 
            // ucSearchLookupEditor_KyTenlanhdao
            // 
            this.ucSearchLookupEditor_KyTenlanhdao.CatchEnterKey = false;
            this.ucSearchLookupEditor_KyTenlanhdao.CatchTabKey = false;
            this.ucSearchLookupEditor_KyTenlanhdao.ControlBack = null;
            this.ucSearchLookupEditor_KyTenlanhdao.ControlNext = null;
            this.ucSearchLookupEditor_KyTenlanhdao.DisplayMember = "";
            this.ucSearchLookupEditor_KyTenlanhdao.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSearchLookupEditor_KyTenlanhdao.Location = new System.Drawing.Point(61, 2);
            this.ucSearchLookupEditor_KyTenlanhdao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucSearchLookupEditor_KyTenlanhdao.Name = "ucSearchLookupEditor_KyTenlanhdao";
            this.ucSearchLookupEditor_KyTenlanhdao.SelectedValue = null;
            this.ucSearchLookupEditor_KyTenlanhdao.Size = new System.Drawing.Size(123, 20);
            this.ucSearchLookupEditor_KyTenlanhdao.TabIndex = 106;
            this.ucSearchLookupEditor_KyTenlanhdao.ValueMember = "";
            // 
            // lblKyLanhDao
            // 
            this.lblKyLanhDao.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKyLanhDao.Appearance.Options.UseFont = true;
            this.lblKyLanhDao.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblKyLanhDao.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblKyLanhDao.Location = new System.Drawing.Point(2, 2);
            this.lblKyLanhDao.Name = "lblKyLanhDao";
            this.lblKyLanhDao.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblKyLanhDao.Size = new System.Drawing.Size(59, 20);
            this.lblKyLanhDao.TabIndex = 105;
            this.lblKyLanhDao.Text = "Lãnh đạo";
            // 
            // btnSign
            // 
            this.btnSign.BackColor = System.Drawing.Color.Yellow;
            this.btnSign.BackColorHover = System.Drawing.Color.Empty;
            this.btnSign.BackgroundColor = System.Drawing.Color.Yellow;
            this.btnSign.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSign.BorderRadius = 5;
            this.btnSign.BorderSize = 1;
            this.btnSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSign.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSign.ForeColor = System.Drawing.Color.Black;
            this.btnSign.Image = ((System.Drawing.Image)(resources.GetObject("btnSign.Image")));
            this.btnSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSign.Location = new System.Drawing.Point(5, 10);
            this.btnSign.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(189, 26);
            this.btnSign.TabIndex = 88;
            this.btnSign.Text = "      Xác nhận chữ ký";
            this.btnSign.TextColor = System.Drawing.Color.Black;
            this.btnSign.UseHightLight = true;
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Visible = false;
            // 
            // ucPatientInformation1
            // 
            this.ucPatientInformation1.AutoSize = true;
            this.ucPatientInformation1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucPatientInformation1.BackColor = System.Drawing.Color.Transparent;
            this.ucPatientInformation1.ChoPhepChonNgay = true;
            this.ucPatientInformation1.DataIndex = -1;
            this.ucPatientInformation1.DataSource = null;
            this.ucPatientInformation1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucPatientInformation1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPatientInformation1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientInformation1.Margin = new System.Windows.Forms.Padding(4);
            this.ucPatientInformation1.MaximumSize = new System.Drawing.Size(500, 370);
            this.ucPatientInformation1.MinimumSize = new System.Drawing.Size(0, 50);
            this.ucPatientInformation1.Name = "ucPatientInformation1";
            this.ucPatientInformation1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ucPatientInformation1.ShowBS_SDT = false;
            this.ucPatientInformation1.ShowBSChiDinh = false;
            this.ucPatientInformation1.ShowChanDoan = false;
            this.ucPatientInformation1.ShowDiachi = false;
            this.ucPatientInformation1.ShowDoiTuong = false;
            this.ucPatientInformation1.ShowEmail = false;
            this.ucPatientInformation1.ShowHoTen = false;
            this.ucPatientInformation1.ShowKhoaHienThoi = false;
            this.ucPatientInformation1.ShowKhoaPhong = false;
            this.ucPatientInformation1.ShowListBSChiDinh = false;
            this.ucPatientInformation1.ShowListKhoaPhong = false;
            this.ucPatientInformation1.ShowMaTiepNhan = false;
            this.ucPatientInformation1.ShowNgayTiepNhan = false;
            this.ucPatientInformation1.ShowPhong = false;
            this.ucPatientInformation1.ShowSexAge = false;
            this.ucPatientInformation1.ShowSoPhieu = false;
            this.ucPatientInformation1.Size = new System.Drawing.Size(434, 50);
            this.ucPatientInformation1.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.AppearancePage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(103)))), ((int)(((byte)(115)))));
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xtraTabControl1.AppearancePage.Header.Options.UseBackColor = true;
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Red;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl1.AppearancePage.PageClient.Font = new System.Drawing.Font("Arial", 10F);
            this.xtraTabControl1.AppearancePage.PageClient.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPageTachRoi;
            this.xtraTabControl1.Size = new System.Drawing.Size(651, 593);
            this.xtraTabControl1.TabIndex = 96;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageTachRoi,
            this.xtraTabPageKQLuoi});
            // 
            // xtraTabPageTachRoi
            // 
            this.xtraTabPageTachRoi.Controls.Add(this.pnKetQua_SHPT);
            this.xtraTabPageTachRoi.Controls.Add(this.pnThongTinXN);
            this.xtraTabPageTachRoi.Name = "xtraTabPageTachRoi";
            this.xtraTabPageTachRoi.Size = new System.Drawing.Size(624, 591);
            this.xtraTabPageTachRoi.Text = "KẾT QUẢ TÁCH RỜI";
            // 
            // pnKetQua_SHPT
            // 
            this.pnKetQua_SHPT.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnKetQua_SHPT.Controls.Add(this.splitContainer3);
            this.pnKetQua_SHPT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnKetQua_SHPT.Location = new System.Drawing.Point(0, 0);
            this.pnKetQua_SHPT.Name = "pnKetQua_SHPT";
            this.pnKetQua_SHPT.Size = new System.Drawing.Size(374, 591);
            this.pnKetQua_SHPT.TabIndex = 97;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Horizontal = false;
            this.splitContainer3.Location = new System.Drawing.Point(2, 2);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pnChiDinh);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pnResult_Containt);
            this.splitContainer3.Panel2.Controls.Add(this.ucGroupHeader3);
            this.splitContainer3.Panel2.Controls.Add(this.pnKetLuan);
            this.splitContainer3.Size = new System.Drawing.Size(370, 587);
            this.splitContainer3.SplitterPosition = 107;
            this.splitContainer3.TabIndex = 0;
            // 
            // pnChiDinh
            // 
            this.pnChiDinh.Controls.Add(this.dtgChiDInh);
            this.pnChiDinh.Controls.Add(this.ucGroupHeader2);
            this.pnChiDinh.Controls.Add(this.bvChiDInh);
            this.pnChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChiDinh.Location = new System.Drawing.Point(0, 0);
            this.pnChiDinh.Name = "pnChiDinh";
            this.pnChiDinh.Size = new System.Drawing.Size(370, 107);
            this.pnChiDinh.TabIndex = 2;
            // 
            // dtgChiDInh
            // 
            this.dtgChiDInh.AlignColumns = null;
            this.dtgChiDInh.AllignNumberText = false;
            this.dtgChiDInh.AllowUserToAddRows = false;
            this.dtgChiDInh.AllowUserToDeleteRows = false;
            this.dtgChiDInh.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgChiDInh.CheckBoldColumn = false;
            this.dtgChiDInh.ColumnHeadersHeight = 25;
            this.dtgChiDInh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaTiepNhan,
            this.colMaXN,
            this.colTenXN,
            this.colMaBenhPhamGui,
            this.colPhuongPhap,
            this.colCSBT,
            this.colDonViTinh,
            this.colKetqua,
            this.colSHPTGenName,
            this.colNguongTren,
            this.colNguongDuoi,
            this.colDKBatThuong,
            this.colCoKetQua,
            this.colKetQua_HeSoNhan,
            this.colKetQua_Lamtron,
            this.colGhiChu,
            this.colChiDinh_DaXacNhan,
            this.colChiDinh_NguoiXacNhan,
            this.colChiDinh_DaIn,
            this.colChiDinh_NguoiNhap,
            this.colChiDinh_NguoiSua,
            this.colChiDinh_NguoiXacNhan2,
            this.colChiDinh_ThoiGianXacNhanKQ2,
            this.colMauInSHPT,
            this.colMaSoMau,
            this.colKetQua_KetQuaHeSo,
            this.colKetQua_DaUpload,
            this.colKetQua_LanUpload,
            this.colChiDinh_lanxn,
            this.colChiDinh_ThoiGianXacNhanThucHien,
            this.colDS_IdMayXn});
            this.dtgChiDInh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChiDInh.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgChiDInh.Location = new System.Drawing.Point(2, 25);
            this.dtgChiDInh.MarkOddEven = false;
            this.dtgChiDInh.Name = "dtgChiDInh";
            this.dtgChiDInh.ReadOnly = true;
            this.dtgChiDInh.RowHeadersWidth = 25;
            this.dtgChiDInh.Size = new System.Drawing.Size(366, 80);
            this.dtgChiDInh.TabIndex = 2;
            // 
            // colMaTiepNhan
            // 
            this.colMaTiepNhan.DataPropertyName = "MaTiepNhan";
            this.colMaTiepNhan.HeaderText = "Mã tiếp nhận";
            this.colMaTiepNhan.MinimumWidth = 6;
            this.colMaTiepNhan.Name = "colMaTiepNhan";
            this.colMaTiepNhan.ReadOnly = true;
            this.colMaTiepNhan.Visible = false;
            this.colMaTiepNhan.Width = 125;
            // 
            // colMaXN
            // 
            this.colMaXN.DataPropertyName = "MaXN";
            this.colMaXN.HeaderText = "Mã XN";
            this.colMaXN.MinimumWidth = 6;
            this.colMaXN.Name = "colMaXN";
            this.colMaXN.ReadOnly = true;
            this.colMaXN.Visible = false;
            this.colMaXN.Width = 125;
            // 
            // colTenXN
            // 
            this.colTenXN.DataPropertyName = "TenXN";
            this.colTenXN.FillWeight = 47.71573F;
            this.colTenXN.HeaderText = "Chỉ định";
            this.colTenXN.MinimumWidth = 6;
            this.colTenXN.Name = "colTenXN";
            this.colTenXN.ReadOnly = true;
            this.colTenXN.Width = 250;
            // 
            // colMaBenhPhamGui
            // 
            this.colMaBenhPhamGui.DataPropertyName = "MaBenhPhamGui";
            this.colMaBenhPhamGui.HeaderText = "Mã bệnh phẩm gửi";
            this.colMaBenhPhamGui.MinimumWidth = 6;
            this.colMaBenhPhamGui.Name = "colMaBenhPhamGui";
            this.colMaBenhPhamGui.ReadOnly = true;
            this.colMaBenhPhamGui.Width = 120;
            // 
            // colPhuongPhap
            // 
            this.colPhuongPhap.DataPropertyName = "PhuongPhap";
            this.colPhuongPhap.HeaderText = "PP xét nghiệm";
            this.colPhuongPhap.MinimumWidth = 6;
            this.colPhuongPhap.Name = "colPhuongPhap";
            this.colPhuongPhap.ReadOnly = true;
            this.colPhuongPhap.Visible = false;
            this.colPhuongPhap.Width = 125;
            // 
            // colCSBT
            // 
            this.colCSBT.DataPropertyName = "CSBT";
            this.colCSBT.HeaderText = "Ngưỡng định lượng";
            this.colCSBT.MinimumWidth = 6;
            this.colCSBT.Name = "colCSBT";
            this.colCSBT.ReadOnly = true;
            this.colCSBT.Visible = false;
            this.colCSBT.Width = 125;
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.DataPropertyName = "DonVi";
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.MinimumWidth = 6;
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            this.colDonViTinh.Visible = false;
            this.colDonViTinh.Width = 125;
            // 
            // colKetqua
            // 
            this.colKetqua.DataPropertyName = "KetQua";
            this.colKetqua.HeaderText = "Kết luận";
            this.colKetqua.MinimumWidth = 6;
            this.colKetqua.Name = "colKetqua";
            this.colKetqua.ReadOnly = true;
            this.colKetqua.Visible = false;
            this.colKetqua.Width = 125;
            // 
            // colSHPTGenName
            // 
            this.colSHPTGenName.DataPropertyName = "SHPTGenName";
            this.colSHPTGenName.HeaderText = "SHPTGenName";
            this.colSHPTGenName.MinimumWidth = 6;
            this.colSHPTGenName.Name = "colSHPTGenName";
            this.colSHPTGenName.ReadOnly = true;
            this.colSHPTGenName.Visible = false;
            this.colSHPTGenName.Width = 125;
            // 
            // colNguongTren
            // 
            this.colNguongTren.DataPropertyName = "NguongTren";
            this.colNguongTren.HeaderText = "Ngưỡng trên";
            this.colNguongTren.MinimumWidth = 6;
            this.colNguongTren.Name = "colNguongTren";
            this.colNguongTren.ReadOnly = true;
            this.colNguongTren.Visible = false;
            this.colNguongTren.Width = 125;
            // 
            // colNguongDuoi
            // 
            this.colNguongDuoi.DataPropertyName = "NguongDuoi";
            this.colNguongDuoi.HeaderText = "Ngưỡng mới";
            this.colNguongDuoi.MinimumWidth = 6;
            this.colNguongDuoi.Name = "colNguongDuoi";
            this.colNguongDuoi.ReadOnly = true;
            this.colNguongDuoi.Visible = false;
            this.colNguongDuoi.Width = 125;
            // 
            // colDKBatThuong
            // 
            this.colDKBatThuong.DataPropertyName = "DKBatThuong";
            this.colDKBatThuong.HeaderText = "ĐK bất thường";
            this.colDKBatThuong.MinimumWidth = 6;
            this.colDKBatThuong.Name = "colDKBatThuong";
            this.colDKBatThuong.ReadOnly = true;
            this.colDKBatThuong.Visible = false;
            this.colDKBatThuong.Width = 125;
            // 
            // colCoKetQua
            // 
            this.colCoKetQua.DataPropertyName = "Flat";
            this.colCoKetQua.HeaderText = "Cờ";
            this.colCoKetQua.MinimumWidth = 6;
            this.colCoKetQua.Name = "colCoKetQua";
            this.colCoKetQua.ReadOnly = true;
            this.colCoKetQua.Visible = false;
            this.colCoKetQua.Width = 125;
            // 
            // colKetQua_HeSoNhan
            // 
            this.colKetQua_HeSoNhan.DataPropertyName = "HeSoQuiDoi";
            this.colKetQua_HeSoNhan.FillWeight = 20F;
            this.colKetQua_HeSoNhan.HeaderText = "Hệ số quy đổi";
            this.colKetQua_HeSoNhan.MinimumWidth = 6;
            this.colKetQua_HeSoNhan.Name = "colKetQua_HeSoNhan";
            this.colKetQua_HeSoNhan.ReadOnly = true;
            this.colKetQua_HeSoNhan.Width = 120;
            // 
            // colKetQua_Lamtron
            // 
            this.colKetQua_Lamtron.DataPropertyName = "LamTron";
            this.colKetQua_Lamtron.FillWeight = 20F;
            this.colKetQua_Lamtron.HeaderText = "Làm tròn";
            this.colKetQua_Lamtron.MinimumWidth = 6;
            this.colKetQua_Lamtron.Name = "colKetQua_Lamtron";
            this.colKetQua_Lamtron.ReadOnly = true;
            this.colKetQua_Lamtron.Visible = false;
            this.colKetQua_Lamtron.Width = 125;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.HeaderText = "Ghi chú/Type";
            this.colGhiChu.MinimumWidth = 6;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            this.colGhiChu.Visible = false;
            this.colGhiChu.Width = 125;
            // 
            // colChiDinh_DaXacNhan
            // 
            this.colChiDinh_DaXacNhan.DataPropertyName = "XacNhanKQ";
            this.colChiDinh_DaXacNhan.HeaderText = "Đã xác nhận";
            this.colChiDinh_DaXacNhan.MinimumWidth = 6;
            this.colChiDinh_DaXacNhan.Name = "colChiDinh_DaXacNhan";
            this.colChiDinh_DaXacNhan.ReadOnly = true;
            this.colChiDinh_DaXacNhan.Width = 120;
            // 
            // colChiDinh_NguoiXacNhan
            // 
            this.colChiDinh_NguoiXacNhan.DataPropertyName = "NguoiXacNhan";
            this.colChiDinh_NguoiXacNhan.HeaderText = "Người xác nhận";
            this.colChiDinh_NguoiXacNhan.MinimumWidth = 6;
            this.colChiDinh_NguoiXacNhan.Name = "colChiDinh_NguoiXacNhan";
            this.colChiDinh_NguoiXacNhan.ReadOnly = true;
            this.colChiDinh_NguoiXacNhan.Width = 130;
            // 
            // colChiDinh_DaIn
            // 
            this.colChiDinh_DaIn.DataPropertyName = "DaInKQXN";
            this.colChiDinh_DaIn.HeaderText = "Đã in";
            this.colChiDinh_DaIn.MinimumWidth = 6;
            this.colChiDinh_DaIn.Name = "colChiDinh_DaIn";
            this.colChiDinh_DaIn.ReadOnly = true;
            this.colChiDinh_DaIn.Width = 125;
            // 
            // colChiDinh_NguoiNhap
            // 
            this.colChiDinh_NguoiNhap.DataPropertyName = "UserNhapKQ";
            this.colChiDinh_NguoiNhap.HeaderText = "Người nhập KQ";
            this.colChiDinh_NguoiNhap.MinimumWidth = 6;
            this.colChiDinh_NguoiNhap.Name = "colChiDinh_NguoiNhap";
            this.colChiDinh_NguoiNhap.ReadOnly = true;
            this.colChiDinh_NguoiNhap.Width = 130;
            // 
            // colChiDinh_NguoiSua
            // 
            this.colChiDinh_NguoiSua.DataPropertyName = "UserSuaKQ";
            this.colChiDinh_NguoiSua.HeaderText = "Người sửa";
            this.colChiDinh_NguoiSua.MinimumWidth = 6;
            this.colChiDinh_NguoiSua.Name = "colChiDinh_NguoiSua";
            this.colChiDinh_NguoiSua.ReadOnly = true;
            this.colChiDinh_NguoiSua.Width = 125;
            // 
            // colChiDinh_NguoiXacNhan2
            // 
            this.colChiDinh_NguoiXacNhan2.DataPropertyName = "UserXacNhan2";
            this.colChiDinh_NguoiXacNhan2.HeaderText = "Người đối chiếu";
            this.colChiDinh_NguoiXacNhan2.MinimumWidth = 6;
            this.colChiDinh_NguoiXacNhan2.Name = "colChiDinh_NguoiXacNhan2";
            this.colChiDinh_NguoiXacNhan2.ReadOnly = true;
            this.colChiDinh_NguoiXacNhan2.Width = 125;
            // 
            // colChiDinh_ThoiGianXacNhanKQ2
            // 
            this.colChiDinh_ThoiGianXacNhanKQ2.DataPropertyName = "thoigianxacnhankq2";
            this.colChiDinh_ThoiGianXacNhanKQ2.HeaderText = "Thời gian đối chiếu";
            this.colChiDinh_ThoiGianXacNhanKQ2.MinimumWidth = 6;
            this.colChiDinh_ThoiGianXacNhanKQ2.Name = "colChiDinh_ThoiGianXacNhanKQ2";
            this.colChiDinh_ThoiGianXacNhanKQ2.ReadOnly = true;
            this.colChiDinh_ThoiGianXacNhanKQ2.Width = 125;
            // 
            // colMauInSHPT
            // 
            this.colMauInSHPT.DataPropertyName = "MauInSHPT";
            this.colMauInSHPT.HeaderText = "Mẫu in ";
            this.colMauInSHPT.MinimumWidth = 6;
            this.colMauInSHPT.Name = "colMauInSHPT";
            this.colMauInSHPT.ReadOnly = true;
            this.colMauInSHPT.Width = 125;
            // 
            // colMaSoMau
            // 
            this.colMaSoMau.DataPropertyName = "MaSoMau";
            this.colMaSoMau.HeaderText = "Mã số mẫu";
            this.colMaSoMau.MinimumWidth = 6;
            this.colMaSoMau.Name = "colMaSoMau";
            this.colMaSoMau.ReadOnly = true;
            this.colMaSoMau.Width = 120;
            // 
            // colKetQua_KetQuaHeSo
            // 
            this.colKetQua_KetQuaHeSo.DataPropertyName = "KetQuaNhanHeSo";
            this.colKetQua_KetQuaHeSo.HeaderText = "Kết quả hệ số";
            this.colKetQua_KetQuaHeSo.MinimumWidth = 6;
            this.colKetQua_KetQuaHeSo.Name = "colKetQua_KetQuaHeSo";
            this.colKetQua_KetQuaHeSo.ReadOnly = true;
            this.colKetQua_KetQuaHeSo.Visible = false;
            this.colKetQua_KetQuaHeSo.Width = 125;
            // 
            // colKetQua_DaUpload
            // 
            this.colKetQua_DaUpload.DataPropertyName = "uploadweb";
            this.colKetQua_DaUpload.HeaderText = "Đã upload HIS";
            this.colKetQua_DaUpload.MinimumWidth = 6;
            this.colKetQua_DaUpload.Name = "colKetQua_DaUpload";
            this.colKetQua_DaUpload.ReadOnly = true;
            this.colKetQua_DaUpload.Width = 125;
            // 
            // colKetQua_LanUpload
            // 
            this.colKetQua_LanUpload.DataPropertyName = "transferresultothis";
            this.colKetQua_LanUpload.HeaderText = "Lần upload";
            this.colKetQua_LanUpload.MinimumWidth = 6;
            this.colKetQua_LanUpload.Name = "colKetQua_LanUpload";
            this.colKetQua_LanUpload.ReadOnly = true;
            this.colKetQua_LanUpload.Width = 125;
            // 
            // colChiDinh_lanxn
            // 
            this.colChiDinh_lanxn.DataPropertyName = "lanxn";
            this.colChiDinh_lanxn.HeaderText = "Lần XN";
            this.colChiDinh_lanxn.MinimumWidth = 6;
            this.colChiDinh_lanxn.Name = "colChiDinh_lanxn";
            this.colChiDinh_lanxn.ReadOnly = true;
            this.colChiDinh_lanxn.Width = 125;
            // 
            // colChiDinh_ThoiGianXacNhanThucHien
            // 
            this.colChiDinh_ThoiGianXacNhanThucHien.DataPropertyName = "thoigianxacnhanthuchien";
            this.colChiDinh_ThoiGianXacNhanThucHien.HeaderText = "Ngày khởi phát";
            this.colChiDinh_ThoiGianXacNhanThucHien.MinimumWidth = 6;
            this.colChiDinh_ThoiGianXacNhanThucHien.Name = "colChiDinh_ThoiGianXacNhanThucHien";
            this.colChiDinh_ThoiGianXacNhanThucHien.ReadOnly = true;
            this.colChiDinh_ThoiGianXacNhanThucHien.Width = 125;
            // 
            // colDS_IdMayXn
            // 
            this.colDS_IdMayXn.DataPropertyName = "IDMayXetNghiem";
            this.colDS_IdMayXn.HeaderText = "Id máy xn";
            this.colDS_IdMayXn.MinimumWidth = 6;
            this.colDS_IdMayXn.Name = "colDS_IdMayXn";
            this.colDS_IdMayXn.ReadOnly = true;
            this.colDS_IdMayXn.Width = 125;
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader2.GroupCaption = "CHỈ ĐỊNH XÉT NGHIỆM";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(2, 2);
            this.ucGroupHeader2.Margin = new System.Windows.Forms.Padding(4);
            this.ucGroupHeader2.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(366, 23);
            this.ucGroupHeader2.TabIndex = 4;
            // 
            // bvChiDInh
            // 
            this.bvChiDInh.AddNewItem = null;
            this.bvChiDInh.CountItem = this.bindingNavigatorCountItem;
            this.bvChiDInh.DeleteItem = null;
            this.bvChiDInh.Dock = System.Windows.Forms.DockStyle.None;
            this.bvChiDInh.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvChiDInh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bvChiDInh.Location = new System.Drawing.Point(221, 68);
            this.bvChiDInh.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvChiDInh.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvChiDInh.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvChiDInh.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvChiDInh.Name = "bvChiDInh";
            this.bvChiDInh.PositionItem = this.bindingNavigatorPositionItem;
            this.bvChiDInh.Size = new System.Drawing.Size(213, 27);
            this.bvChiDInh.TabIndex = 3;
            this.bvChiDInh.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // pnResult_Containt
            // 
            this.pnResult_Containt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnResult_Containt.Location = new System.Drawing.Point(0, 23);
            this.pnResult_Containt.Name = "pnResult_Containt";
            this.pnResult_Containt.Padding = new System.Windows.Forms.Padding(5);
            this.pnResult_Containt.Size = new System.Drawing.Size(370, 334);
            this.pnResult_Containt.TabIndex = 6;
            // 
            // ucGroupHeader3
            // 
            this.ucGroupHeader3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader3.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader3.GroupCaption = "KẾT QUẢ";
            this.ucGroupHeader3.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader3.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader3.Margin = new System.Windows.Forms.Padding(4);
            this.ucGroupHeader3.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader3.Name = "ucGroupHeader3";
            this.ucGroupHeader3.Size = new System.Drawing.Size(370, 23);
            this.ucGroupHeader3.TabIndex = 5;
            // 
            // pnKetLuan
            // 
            this.pnKetLuan.Controls.Add(this.txtGhiChu);
            this.pnKetLuan.Controls.Add(this.ucGroupHeaderChuThich);
            this.pnKetLuan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnKetLuan.Location = new System.Drawing.Point(0, 357);
            this.pnKetLuan.Name = "pnKetLuan";
            this.pnKetLuan.Size = new System.Drawing.Size(370, 113);
            this.pnKetLuan.TabIndex = 4;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColorEnter = System.Drawing.Color.Yellow;
            this.txtGhiChu.BindFieldName = null;
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.ForceColorEnter = System.Drawing.Color.DarkRed;
            this.txtGhiChu.Location = new System.Drawing.Point(2, 25);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.OldValue = null;
            this.txtGhiChu.Size = new System.Drawing.Size(366, 86);
            this.txtGhiChu.TabIndex = 1;
            this.txtGhiChu.UseFocusColor = true;
            // 
            // ucGroupHeaderChuThich
            // 
            this.ucGroupHeaderChuThich.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeaderChuThich.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeaderChuThich.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeaderChuThich.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeaderChuThich.GroupCaption = "CHÚ THÍCH";
            this.ucGroupHeaderChuThich.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeaderChuThich.Location = new System.Drawing.Point(2, 2);
            this.ucGroupHeaderChuThich.Margin = new System.Windows.Forms.Padding(4);
            this.ucGroupHeaderChuThich.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeaderChuThich.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeaderChuThich.Name = "ucGroupHeaderChuThich";
            this.ucGroupHeaderChuThich.Size = new System.Drawing.Size(366, 23);
            this.ucGroupHeaderChuThich.TabIndex = 5;
            // 
            // pnThongTinXN
            // 
            this.pnThongTinXN.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnThongTinXN.Controls.Add(this.panel5);
            this.pnThongTinXN.Controls.Add(this.ucGroupHeader5);
            this.pnThongTinXN.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnThongTinXN.Location = new System.Drawing.Point(374, 0);
            this.pnThongTinXN.Name = "pnThongTinXN";
            this.pnThongTinXN.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnThongTinXN.Size = new System.Drawing.Size(250, 591);
            this.pnThongTinXN.TabIndex = 98;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.splitContainer2);
            this.panel5.Controls.Add(this.splitter1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(240, 561);
            this.panel5.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Horizontal = false;
            this.splitContainer2.Location = new System.Drawing.Point(5, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rchThongTinXN_ThongThuong);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.txtPhuongPhap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucSearchLookupEditor_DoiChieuSHPT1);
            this.splitContainer2.Panel2.Controls.Add(this.panel4);
            this.splitContainer2.Panel2.Controls.Add(this.dtpTGDoiChieu);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.chkKetQuaDaXacNhan);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.cboMayXn);
            this.splitContainer2.Panel2.Controls.Add(this.txtDonViTinh);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.txtCSBT);
            this.splitContainer2.Panel2.Controls.Add(this.pnNgayInRoi);
            this.splitContainer2.Size = new System.Drawing.Size(233, 557);
            this.splitContainer2.SplitterPosition = 152;
            this.splitContainer2.TabIndex = 93;
            // 
            // rchThongTinXN_ThongThuong
            // 
            this.rchThongTinXN_ThongThuong.AlignCenterVisible = false;
            this.rchThongTinXN_ThongThuong.AlignLeftVisible = false;
            this.rchThongTinXN_ThongThuong.AlignRightVisible = false;
            this.rchThongTinXN_ThongThuong.BoldVisible = false;
            this.rchThongTinXN_ThongThuong.BulletsVisible = false;
            this.rchThongTinXN_ThongThuong.ChooseFontVisible = false;
            this.rchThongTinXN_ThongThuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchThongTinXN_ThongThuong.FindReplaceVisible = false;
            this.rchThongTinXN_ThongThuong.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchThongTinXN_ThongThuong.FontColorVisible = false;
            this.rchThongTinXN_ThongThuong.FontFamilyVisible = false;
            this.rchThongTinXN_ThongThuong.FontSizeVisible = false;
            this.rchThongTinXN_ThongThuong.GroupAlignmentVisible = false;
            this.rchThongTinXN_ThongThuong.GroupBoldUnderlineItalicVisible = false;
            this.rchThongTinXN_ThongThuong.GroupFontColorVisible = false;
            this.rchThongTinXN_ThongThuong.GroupFontNameAndSizeVisible = false;
            this.rchThongTinXN_ThongThuong.GroupIndentationAndBulletsVisible = false;
            this.rchThongTinXN_ThongThuong.GroupInsertVisible = false;
            this.rchThongTinXN_ThongThuong.GroupSaveAndLoadVisible = false;
            this.rchThongTinXN_ThongThuong.GroupZoomVisible = false;
            this.rchThongTinXN_ThongThuong.INDENT = 10;
            this.rchThongTinXN_ThongThuong.IndentVisible = false;
            this.rchThongTinXN_ThongThuong.InsertPictureVisible = false;
            this.rchThongTinXN_ThongThuong.ItalicVisible = false;
            this.rchThongTinXN_ThongThuong.LoadVisible = false;
            this.rchThongTinXN_ThongThuong.Location = new System.Drawing.Point(0, 45);
            this.rchThongTinXN_ThongThuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rchThongTinXN_ThongThuong.Name = "rchThongTinXN_ThongThuong";
            this.rchThongTinXN_ThongThuong.OutdentVisible = false;
            this.rchThongTinXN_ThongThuong.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset20" +
    "4 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\p" +
    "ard\\f0\\fs18\\lang1049\\par\r\n}\r\n";
            this.rchThongTinXN_ThongThuong.SaveVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorAlignVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorBoldUnderlineItalicVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorFontColorVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorFontVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorIndentAndBulletsVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorInsertVisible = false;
            this.rchThongTinXN_ThongThuong.SeparatorSaveLoadVisible = false;
            this.rchThongTinXN_ThongThuong.Size = new System.Drawing.Size(233, 107);
            this.rchThongTinXN_ThongThuong.TabIndex = 5;
            this.rchThongTinXN_ThongThuong.ToolStripVisible = false;
            this.rchThongTinXN_ThongThuong.UnderlineVisible = false;
            this.rchThongTinXN_ThongThuong.WordWrapVisible = false;
            this.rchThongTinXN_ThongThuong.ZoomFactorTextVisible = false;
            this.rchThongTinXN_ThongThuong.ZoomInVisible = false;
            this.rchThongTinXN_ThongThuong.ZoomOutVisible = false;
            this.rchThongTinXN_ThongThuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchThongTinXN_ThongThuong_KeyDown);
            this.rchThongTinXN_ThongThuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rchThongTinXN_ThongThuong_KeyPress);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 26);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(210, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thông tin xét nghiệm/Nội kiểm tra";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMaSoMau);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 26);
            this.panel1.TabIndex = 7;
            // 
            // txtMaSoMau
            // 
            this.txtMaSoMau.BackColor = System.Drawing.Color.Beige;
            this.txtMaSoMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaSoMau.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtMaSoMau.ForeColor = System.Drawing.Color.Red;
            this.txtMaSoMau.Location = new System.Drawing.Point(77, 2);
            this.txtMaSoMau.Name = "txtMaSoMau";
            this.txtMaSoMau.ReadOnly = true;
            this.txtMaSoMau.Size = new System.Drawing.Size(154, 24);
            this.txtMaSoMau.TabIndex = 89;
            this.txtMaSoMau.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Appearance.Options.UseFont = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(2, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 88;
            this.label5.Text = "Mã số mẫu";
            // 
            // label12
            // 
            this.label12.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.label12.Appearance.Options.UseFont = true;
            this.label12.Appearance.Options.UseForeColor = true;
            this.label12.Location = new System.Drawing.Point(69, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Phương pháp xét nghiệm";
            // 
            // txtPhuongPhap
            // 
            this.txtPhuongPhap.Location = new System.Drawing.Point(85, 105);
            this.txtPhuongPhap.Multiline = true;
            this.txtPhuongPhap.Name = "txtPhuongPhap";
            this.txtPhuongPhap.ReadOnly = true;
            this.txtPhuongPhap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhuongPhap.Size = new System.Drawing.Size(14, 22);
            this.txtPhuongPhap.TabIndex = 1;
            // 
            // ucSearchLookupEditor_DoiChieuSHPT1
            // 
            this.ucSearchLookupEditor_DoiChieuSHPT1.CatchEnterKey = false;
            this.ucSearchLookupEditor_DoiChieuSHPT1.CatchTabKey = false;
            this.ucSearchLookupEditor_DoiChieuSHPT1.ControlBack = null;
            this.ucSearchLookupEditor_DoiChieuSHPT1.ControlNext = null;
            this.ucSearchLookupEditor_DoiChieuSHPT1.DisplayMember = "";
            this.ucSearchLookupEditor_DoiChieuSHPT1.Location = new System.Drawing.Point(6, 89);
            this.ucSearchLookupEditor_DoiChieuSHPT1.Margin = new System.Windows.Forms.Padding(4);
            this.ucSearchLookupEditor_DoiChieuSHPT1.Name = "ucSearchLookupEditor_DoiChieuSHPT1";
            this.ucSearchLookupEditor_DoiChieuSHPT1.SelectedValue = null;
            this.ucSearchLookupEditor_DoiChieuSHPT1.Size = new System.Drawing.Size(230, 23);
            this.ucSearchLookupEditor_DoiChieuSHPT1.TabIndex = 121;
            this.ucSearchLookupEditor_DoiChieuSHPT1.ValueMember = "";
            // 
            // panel4
            // 
            this.panel4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel4.Appearance.Options.UseBackColor = true;
            this.panel4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panel4.Controls.Add(this.btnThemDienGiai_ToRoi);
            this.panel4.Controls.Add(this.btnXemDienGiai_ToRoi);
            this.panel4.Controls.Add(this.lblPhieuIn);
            this.panel4.Controls.Add(this.cboPhieuInSHPT);
            this.panel4.Controls.Add(this.chkValidWhenPrint);
            this.panel4.Controls.Add(this.btnLayThongTinTruocSHPT);
            this.panel4.Controls.Add(this.chkInKhiXacNhanSHPT);
            this.panel4.Controls.Add(this.btnLuu);
            this.panel4.Controls.Add(this.btnHuyXacNhanKetQua);
            this.panel4.Controls.Add(this.btnXacNhanKetQua);
            this.panel4.Controls.Add(this.btnXemIn);
            this.panel4.Controls.Add(this.btnInketQua);
            this.panel4.Controls.Add(this.lblAutoPrintStatus);
            this.panel4.Controls.Add(this.chkInTheoChiDinh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 205);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 165);
            this.panel4.TabIndex = 3;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // btnThemDienGiai_ToRoi
            // 
            this.btnThemDienGiai_ToRoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemDienGiai_ToRoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemDienGiai_ToRoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemDienGiai_ToRoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemDienGiai_ToRoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemDienGiai_ToRoi.BorderRadius = 5;
            this.btnThemDienGiai_ToRoi.BorderSize = 1;
            this.btnThemDienGiai_ToRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemDienGiai_ToRoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDienGiai_ToRoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDienGiai_ToRoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemDienGiai_ToRoi.ForeColor = System.Drawing.Color.Black;
            this.btnThemDienGiai_ToRoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDienGiai_ToRoi.Image")));
            this.btnThemDienGiai_ToRoi.Location = new System.Drawing.Point(2, 0);
            this.btnThemDienGiai_ToRoi.Name = "btnThemDienGiai_ToRoi";
            this.btnThemDienGiai_ToRoi.Size = new System.Drawing.Size(42, 38);
            this.btnThemDienGiai_ToRoi.TabIndex = 121;
            this.btnThemDienGiai_ToRoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThemDienGiai_ToRoi.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnThemDienGiai_ToRoi, "Lấy thời gian thực hiện trước đó");
            this.btnThemDienGiai_ToRoi.UseHightLight = true;
            this.btnThemDienGiai_ToRoi.UseVisualStyleBackColor = false;
            this.btnThemDienGiai_ToRoi.Click += new System.EventHandler(this.btnThemDienGiai_ToRoi_Click);
            // 
            // btnXemDienGiai_ToRoi
            // 
            this.btnXemDienGiai_ToRoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXemDienGiai_ToRoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemDienGiai_ToRoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemDienGiai_ToRoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemDienGiai_ToRoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemDienGiai_ToRoi.BorderRadius = 5;
            this.btnXemDienGiai_ToRoi.BorderSize = 1;
            this.btnXemDienGiai_ToRoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDienGiai_ToRoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDienGiai_ToRoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDienGiai_ToRoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemDienGiai_ToRoi.ForeColor = System.Drawing.Color.Black;
            this.btnXemDienGiai_ToRoi.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDienGiai_ToRoi.Image")));
            this.btnXemDienGiai_ToRoi.Location = new System.Drawing.Point(49, 0);
            this.btnXemDienGiai_ToRoi.Name = "btnXemDienGiai_ToRoi";
            this.btnXemDienGiai_ToRoi.Size = new System.Drawing.Size(42, 38);
            this.btnXemDienGiai_ToRoi.TabIndex = 120;
            this.btnXemDienGiai_ToRoi.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnXemDienGiai_ToRoi, "Bỏ duyệt kết quả");
            this.btnXemDienGiai_ToRoi.UseHightLight = true;
            this.btnXemDienGiai_ToRoi.UseVisualStyleBackColor = false;
            this.btnXemDienGiai_ToRoi.Click += new System.EventHandler(this.btnXemDienGiai_ToRoi_Click);
            // 
            // lblPhieuIn
            // 
            this.lblPhieuIn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.lblPhieuIn.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieuIn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblPhieuIn.Appearance.Options.UseBackColor = true;
            this.lblPhieuIn.Appearance.Options.UseFont = true;
            this.lblPhieuIn.Appearance.Options.UseForeColor = true;
            this.lblPhieuIn.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPhieuIn.Location = new System.Drawing.Point(5, 118);
            this.lblPhieuIn.Name = "lblPhieuIn";
            this.lblPhieuIn.Size = new System.Drawing.Size(132, 19);
            this.lblPhieuIn.TabIndex = 115;
            this.lblPhieuIn.Text = "PHIẾU IN";
            // 
            // cboPhieuInSHPT
            // 
            this.cboPhieuInSHPT.FormattingEnabled = true;
            this.cboPhieuInSHPT.Items.AddRange(new object[] {
            "1: Tiếng Việt",
            "2: Tiếng Anh",
            "3: Tiếng Nhật",
            "4: Tiếng Trung Quốc",
            "5: Tiếng Pháp"});
            this.cboPhieuInSHPT.Location = new System.Drawing.Point(5, 138);
            this.cboPhieuInSHPT.Name = "cboPhieuInSHPT";
            this.cboPhieuInSHPT.Size = new System.Drawing.Size(132, 21);
            this.cboPhieuInSHPT.TabIndex = 114;
            // 
            // chkValidWhenPrint
            // 
            this.chkValidWhenPrint.AutoSize = true;
            this.chkValidWhenPrint.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkValidWhenPrint.Checked = true;
            this.chkValidWhenPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValidWhenPrint.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValidWhenPrint.Location = new System.Drawing.Point(145, 111);
            this.chkValidWhenPrint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkValidWhenPrint.Name = "chkValidWhenPrint";
            this.chkValidWhenPrint.Size = new System.Drawing.Size(80, 46);
            this.chkValidWhenPrint.TabIndex = 93;
            this.chkValidWhenPrint.Text = "Tự xác nhận \r\nsau khi in";
            this.chkValidWhenPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkValidWhenPrint.UseVisualStyleBackColor = true;
            // 
            // btnLayThongTinTruocSHPT
            // 
            this.btnLayThongTinTruocSHPT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLayThongTinTruocSHPT.BackColorHover = System.Drawing.Color.Empty;
            this.btnLayThongTinTruocSHPT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLayThongTinTruocSHPT.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLayThongTinTruocSHPT.BorderRadius = 5;
            this.btnLayThongTinTruocSHPT.BorderSize = 1;
            this.btnLayThongTinTruocSHPT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLayThongTinTruocSHPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayThongTinTruocSHPT.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayThongTinTruocSHPT.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLayThongTinTruocSHPT.ForeColor = System.Drawing.Color.Black;
            this.btnLayThongTinTruocSHPT.Image = ((System.Drawing.Image)(resources.GetObject("btnLayThongTinTruocSHPT.Image")));
            this.btnLayThongTinTruocSHPT.Location = new System.Drawing.Point(5, 39);
            this.btnLayThongTinTruocSHPT.Name = "btnLayThongTinTruocSHPT";
            this.btnLayThongTinTruocSHPT.Size = new System.Drawing.Size(42, 38);
            this.btnLayThongTinTruocSHPT.TabIndex = 103;
            this.btnLayThongTinTruocSHPT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLayThongTinTruocSHPT.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnLayThongTinTruocSHPT, "Lấy thời gian thực hiện trước đó");
            this.btnLayThongTinTruocSHPT.UseHightLight = true;
            this.btnLayThongTinTruocSHPT.UseVisualStyleBackColor = false;
            this.btnLayThongTinTruocSHPT.Click += new System.EventHandler(this.btnLayThongTinTruocSHPT_Click);
            // 
            // chkInKhiXacNhanSHPT
            // 
            this.chkInKhiXacNhanSHPT.AutoSize = true;
            this.chkInKhiXacNhanSHPT.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkInKhiXacNhanSHPT.Checked = true;
            this.chkInKhiXacNhanSHPT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInKhiXacNhanSHPT.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInKhiXacNhanSHPT.Location = new System.Drawing.Point(148, 69);
            this.chkInKhiXacNhanSHPT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkInKhiXacNhanSHPT.Name = "chkInKhiXacNhanSHPT";
            this.chkInKhiXacNhanSHPT.Size = new System.Drawing.Size(75, 32);
            this.chkInKhiXacNhanSHPT.TabIndex = 102;
            this.chkInKhiXacNhanSHPT.Text = "In khi duyệt";
            this.chkInKhiXacNhanSHPT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkInKhiXacNhanSHPT.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLuu.BackColorHover = System.Drawing.Color.Empty;
            this.btnLuu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLuu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.BorderSize = 1;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLuu.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(52, 39);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(42, 38);
            this.btnLuu.TabIndex = 101;
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLuu.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnLuu, "Lưu kết quả");
            this.btnLuu.UseHightLight = true;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuyXacNhanKetQua
            // 
            this.btnHuyXacNhanKetQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuyXacNhanKetQua.BackColorHover = System.Drawing.Color.Empty;
            this.btnHuyXacNhanKetQua.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuyXacNhanKetQua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnHuyXacNhanKetQua.BorderRadius = 5;
            this.btnHuyXacNhanKetQua.BorderSize = 1;
            this.btnHuyXacNhanKetQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyXacNhanKetQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyXacNhanKetQua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyXacNhanKetQua.ForceColorHover = System.Drawing.Color.Empty;
            this.btnHuyXacNhanKetQua.ForeColor = System.Drawing.Color.Black;
            this.btnHuyXacNhanKetQua.Image = ((System.Drawing.Image)(resources.GetObject("btnHuyXacNhanKetQua.Image")));
            this.btnHuyXacNhanKetQua.Location = new System.Drawing.Point(5, 78);
            this.btnHuyXacNhanKetQua.Name = "btnHuyXacNhanKetQua";
            this.btnHuyXacNhanKetQua.Size = new System.Drawing.Size(42, 38);
            this.btnHuyXacNhanKetQua.TabIndex = 100;
            this.btnHuyXacNhanKetQua.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnHuyXacNhanKetQua, "Bỏ duyệt kết quả");
            this.btnHuyXacNhanKetQua.UseHightLight = false;
            this.btnHuyXacNhanKetQua.UseVisualStyleBackColor = false;
            this.btnHuyXacNhanKetQua.Click += new System.EventHandler(this.btnHuyXacNhanKetQua_Click);
            // 
            // btnXacNhanKetQua
            // 
            this.btnXacNhanKetQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXacNhanKetQua.BackColorHover = System.Drawing.Color.Empty;
            this.btnXacNhanKetQua.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXacNhanKetQua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXacNhanKetQua.BorderRadius = 5;
            this.btnXacNhanKetQua.BorderSize = 1;
            this.btnXacNhanKetQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanKetQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanKetQua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanKetQua.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXacNhanKetQua.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhanKetQua.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhanKetQua.Image")));
            this.btnXacNhanKetQua.Location = new System.Drawing.Point(99, 39);
            this.btnXacNhanKetQua.Name = "btnXacNhanKetQua";
            this.btnXacNhanKetQua.Size = new System.Drawing.Size(42, 38);
            this.btnXacNhanKetQua.TabIndex = 99;
            this.btnXacNhanKetQua.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnXacNhanKetQua, "Duyệt kết quả");
            this.btnXacNhanKetQua.UseHightLight = false;
            this.btnXacNhanKetQua.UseVisualStyleBackColor = false;
            this.btnXacNhanKetQua.Click += new System.EventHandler(this.btnXacNhanKetQua_Click);
            // 
            // btnXemIn
            // 
            this.btnXemIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemIn.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemIn.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemIn.BorderRadius = 5;
            this.btnXemIn.BorderSize = 1;
            this.btnXemIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemIn.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemIn.ForeColor = System.Drawing.Color.Black;
            this.btnXemIn.Image = ((System.Drawing.Image)(resources.GetObject("btnXemIn.Image")));
            this.btnXemIn.Location = new System.Drawing.Point(52, 78);
            this.btnXemIn.Name = "btnXemIn";
            this.btnXemIn.Size = new System.Drawing.Size(42, 38);
            this.btnXemIn.TabIndex = 98;
            this.btnXemIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemIn.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnXemIn, "Xem in kết quả");
            this.btnXemIn.UseHightLight = true;
            this.btnXemIn.UseVisualStyleBackColor = false;
            this.btnXemIn.Click += new System.EventHandler(this.btnXemIn_Click);
            // 
            // btnInketQua
            // 
            this.btnInketQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInketQua.BackColorHover = System.Drawing.Color.Empty;
            this.btnInketQua.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInketQua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnInketQua.BorderRadius = 5;
            this.btnInketQua.BorderSize = 1;
            this.btnInketQua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInketQua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInketQua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInketQua.ForceColorHover = System.Drawing.Color.Empty;
            this.btnInketQua.ForeColor = System.Drawing.Color.Black;
            this.btnInketQua.Image = ((System.Drawing.Image)(resources.GetObject("btnInketQua.Image")));
            this.btnInketQua.Location = new System.Drawing.Point(98, 78);
            this.btnInketQua.Name = "btnInketQua";
            this.btnInketQua.Size = new System.Drawing.Size(42, 38);
            this.btnInketQua.TabIndex = 97;
            this.btnInketQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInketQua.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnInketQua, "In kết quả");
            this.btnInketQua.UseHightLight = true;
            this.btnInketQua.UseVisualStyleBackColor = false;
            this.btnInketQua.Click += new System.EventHandler(this.btnInketQua_Click);
            // 
            // lblAutoPrintStatus
            // 
            this.lblAutoPrintStatus.Location = new System.Drawing.Point(132, 50);
            this.lblAutoPrintStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAutoPrintStatus.Name = "lblAutoPrintStatus";
            this.lblAutoPrintStatus.Size = new System.Drawing.Size(0, 13);
            this.lblAutoPrintStatus.TabIndex = 83;
            // 
            // chkInTheoChiDinh
            // 
            this.chkInTheoChiDinh.AutoSize = true;
            this.chkInTheoChiDinh.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkInTheoChiDinh.Checked = true;
            this.chkInTheoChiDinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInTheoChiDinh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInTheoChiDinh.Location = new System.Drawing.Point(158, 4);
            this.chkInTheoChiDinh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkInTheoChiDinh.Name = "chkInTheoChiDinh";
            this.chkInTheoChiDinh.Size = new System.Drawing.Size(55, 48);
            this.chkInTheoChiDinh.TabIndex = 94;
            this.chkInTheoChiDinh.Text = "In theo\r\nchỉ định";
            this.chkInTheoChiDinh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkInTheoChiDinh.UseVisualStyleBackColor = true;
            // 
            // dtpTGDoiChieu
            // 
            this.dtpTGDoiChieu.AllowMoveFocus = false;
            this.dtpTGDoiChieu.Checked = false;
            this.dtpTGDoiChieu.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpTGDoiChieu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGDoiChieu.IsEndDate = false;
            this.dtpTGDoiChieu.IsStartDate = false;
            this.dtpTGDoiChieu.Location = new System.Drawing.Point(6, 136);
            this.dtpTGDoiChieu.Name = "dtpTGDoiChieu";
            this.dtpTGDoiChieu.ShowCheckBox = true;
            this.dtpTGDoiChieu.Size = new System.Drawing.Size(229, 20);
            this.dtpTGDoiChieu.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Thời gian thực hiện";
            // 
            // chkKetQuaDaXacNhan
            // 
            this.chkKetQuaDaXacNhan.AutoCheck = false;
            this.chkKetQuaDaXacNhan.AutoSize = true;
            this.chkKetQuaDaXacNhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKetQuaDaXacNhan.Location = new System.Drawing.Point(12, 164);
            this.chkKetQuaDaXacNhan.Name = "chkKetQuaDaXacNhan";
            this.chkKetQuaDaXacNhan.Size = new System.Drawing.Size(142, 19);
            this.chkKetQuaDaXacNhan.TabIndex = 4;
            this.chkKetQuaDaXacNhan.Text = "Đã xác nhận kết quả";
            this.chkKetQuaDaXacNhan.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 85;
            this.label8.Text = "Máy XN";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Người thực hiện";
            // 
            // cboMayXn
            // 
            this.cboMayXn.FormattingEnabled = true;
            this.cboMayXn.Location = new System.Drawing.Point(85, 45);
            this.cboMayXn.Name = "cboMayXn";
            this.cboMayXn.Size = new System.Drawing.Size(151, 21);
            this.cboMayXn.TabIndex = 86;
            this.cboMayXn.SelectedIndexChanged += new System.EventHandler(this.cboMayXn_SelectedIndexChanged);
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonViTinh.Location = new System.Drawing.Point(160, 20);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.ReadOnly = true;
            this.txtDonViTinh.Size = new System.Drawing.Size(75, 23);
            this.txtDonViTinh.TabIndex = 91;
            this.txtDonViTinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Appearance.Options.UseFont = true;
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 89;
            this.label4.Text = "Ngưỡng định lượng";
            // 
            // txtCSBT
            // 
            this.txtCSBT.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCSBT.Location = new System.Drawing.Point(6, 20);
            this.txtCSBT.Name = "txtCSBT";
            this.txtCSBT.ReadOnly = true;
            this.txtCSBT.Size = new System.Drawing.Size(148, 23);
            this.txtCSBT.TabIndex = 90;
            this.txtCSBT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnNgayInRoi
            // 
            this.pnNgayInRoi.Controls.Add(this.lblNgayInSHPTRoi);
            this.pnNgayInRoi.Controls.Add(this.dtpGioInKQRoi);
            this.pnNgayInRoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnNgayInRoi.Location = new System.Drawing.Point(0, 370);
            this.pnNgayInRoi.Name = "pnNgayInRoi";
            this.pnNgayInRoi.Size = new System.Drawing.Size(233, 25);
            this.pnNgayInRoi.TabIndex = 120;
            // 
            // lblNgayInSHPTRoi
            // 
            this.lblNgayInSHPTRoi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.lblNgayInSHPTRoi.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayInSHPTRoi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblNgayInSHPTRoi.Appearance.Options.UseBackColor = true;
            this.lblNgayInSHPTRoi.Appearance.Options.UseFont = true;
            this.lblNgayInSHPTRoi.Appearance.Options.UseForeColor = true;
            this.lblNgayInSHPTRoi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNgayInSHPTRoi.Location = new System.Drawing.Point(6, 3);
            this.lblNgayInSHPTRoi.Name = "lblNgayInSHPTRoi";
            this.lblNgayInSHPTRoi.Size = new System.Drawing.Size(54, 21);
            this.lblNgayInSHPTRoi.TabIndex = 119;
            this.lblNgayInSHPTRoi.Text = "GIỜ IN";
            // 
            // dtpGioInKQRoi
            // 
            this.dtpGioInKQRoi.Checked = false;
            this.dtpGioInKQRoi.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpGioInKQRoi.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpGioInKQRoi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGioInKQRoi.Location = new System.Drawing.Point(65, 3);
            this.dtpGioInKQRoi.Margin = new System.Windows.Forms.Padding(2);
            this.dtpGioInKQRoi.Name = "dtpGioInKQRoi";
            this.dtpGioInKQRoi.ShowCheckBox = true;
            this.dtpGioInKQRoi.Size = new System.Drawing.Size(171, 21);
            this.dtpGioInKQRoi.TabIndex = 118;
            this.dtpGioInKQRoi.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 557);
            this.splitter1.TabIndex = 92;
            this.splitter1.TabStop = false;
            // 
            // ucGroupHeader5
            // 
            this.ucGroupHeader5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader5.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader5.GroupCaption = "THÔNG TIN XÉT NGHIỆM";
            this.ucGroupHeader5.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader5.Location = new System.Drawing.Point(5, 2);
            this.ucGroupHeader5.Margin = new System.Windows.Forms.Padding(4);
            this.ucGroupHeader5.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader5.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader5.Name = "ucGroupHeader5";
            this.ucGroupHeader5.Size = new System.Drawing.Size(240, 23);
            this.ucGroupHeader5.TabIndex = 7;
            // 
            // xtraTabPageKQLuoi
            // 
            this.xtraTabPageKQLuoi.Controls.Add(this.ucKetQuaThuongQuy1);
            this.xtraTabPageKQLuoi.Controls.Add(this.groupControl5);
            this.xtraTabPageKQLuoi.Controls.Add(this.pnChucNang);
            this.xtraTabPageKQLuoi.Name = "xtraTabPageKQLuoi";
            this.xtraTabPageKQLuoi.Size = new System.Drawing.Size(693, 591);
            this.xtraTabPageKQLuoi.Text = "KẾT QUẢ LƯỚI";
            // 
            // ucKetQuaThuongQuy1
            // 
            this.ucKetQuaThuongQuy1.CheDoHienThi = 1;
            this.ucKetQuaThuongQuy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKetQuaThuongQuy1.DtDateInG = new System.DateTime(((long)(0)));
            this.ucKetQuaThuongQuy1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucKetQuaThuongQuy1.HienThiDanhGiaNhom = false;
            this.ucKetQuaThuongQuy1.HienThiGhiChuBoPhan = false;
            this.ucKetQuaThuongQuy1.Location = new System.Drawing.Point(0, 0);
            this.ucKetQuaThuongQuy1.Margin = new System.Windows.Forms.Padding(5);
            this.ucKetQuaThuongQuy1.MatiepNhanG = "";
            this.ucKetQuaThuongQuy1.Name = "ucKetQuaThuongQuy1";
            this.ucKetQuaThuongQuy1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.ucKetQuaThuongQuy1.Size = new System.Drawing.Size(693, 410);
            this.ucKetQuaThuongQuy1.TabIndex = 5;
            // 
            // groupControl5
            // 
            this.groupControl5.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.groupControl5.Appearance.Options.UseFont = true;
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl5.Controls.Add(this.splitContainer4);
            this.groupControl5.Controls.Add(this.panel7);
            this.groupControl5.Controls.Add(this.ucGroupHeader4);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl5.Location = new System.Drawing.Point(0, 410);
            this.groupControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(693, 90);
            this.groupControl5.TabIndex = 11;
            this.groupControl5.Text = "MÔ TẢ";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 23);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.txtDienGiai);
            this.splitContainer4.Panel1.Controls.Add(this.label36);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.txtDeNghi);
            this.splitContainer4.Panel2.Controls.Add(this.label33);
            this.splitContainer4.Size = new System.Drawing.Size(645, 67);
            this.splitContainer4.SplitterPosition = 331;
            this.splitContainer4.TabIndex = 8;
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDienGiai.Location = new System.Drawing.Point(50, 0);
            this.txtDienGiai.Multiline = true;
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(281, 67);
            this.txtDienGiai.TabIndex = 6;
            // 
            // label36
            // 
            this.label36.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(241)))), ((int)(((byte)(238)))));
            this.label36.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label36.Appearance.Options.UseBackColor = true;
            this.label36.Appearance.Options.UseFont = true;
            this.label36.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.label36.Dock = System.Windows.Forms.DockStyle.Left;
            this.label36.Location = new System.Drawing.Point(0, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 17);
            this.label36.TabIndex = 5;
            this.label36.Text = "Diễn giải";
            // 
            // txtDeNghi
            // 
            this.txtDeNghi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeNghi.Location = new System.Drawing.Point(45, 0);
            this.txtDeNghi.Multiline = true;
            this.txtDeNghi.Name = "txtDeNghi";
            this.txtDeNghi.Size = new System.Drawing.Size(259, 67);
            this.txtDeNghi.TabIndex = 4;
            // 
            // label33
            // 
            this.label33.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(241)))), ((int)(((byte)(238)))));
            this.label33.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label33.Appearance.Options.UseBackColor = true;
            this.label33.Appearance.Options.UseFont = true;
            this.label33.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.label33.Dock = System.Windows.Forms.DockStyle.Left;
            this.label33.Location = new System.Drawing.Point(0, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(45, 17);
            this.label33.TabIndex = 3;
            this.label33.Text = "Đề nghị";
            // 
            // panel7
            // 
            this.panel7.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.panel7.Appearance.Options.UseBackColor = true;
            this.panel7.Controls.Add(this.btnLuuNX_DeNghi);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(645, 23);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(48, 67);
            this.panel7.TabIndex = 9;
            // 
            // btnLuuNX_DeNghi
            // 
            this.btnLuuNX_DeNghi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLuuNX_DeNghi.BackColorHover = System.Drawing.Color.Empty;
            this.btnLuuNX_DeNghi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLuuNX_DeNghi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLuuNX_DeNghi.BorderRadius = 5;
            this.btnLuuNX_DeNghi.BorderSize = 1;
            this.btnLuuNX_DeNghi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuNX_DeNghi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuNX_DeNghi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuNX_DeNghi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLuuNX_DeNghi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLuuNX_DeNghi.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuNX_DeNghi.Image")));
            this.btnLuuNX_DeNghi.Location = new System.Drawing.Point(3, 25);
            this.btnLuuNX_DeNghi.Name = "btnLuuNX_DeNghi";
            this.btnLuuNX_DeNghi.Size = new System.Drawing.Size(38, 39);
            this.btnLuuNX_DeNghi.TabIndex = 5;
            this.btnLuuNX_DeNghi.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnLuuNX_DeNghi.UseHightLight = true;
            this.btnLuuNX_DeNghi.UseVisualStyleBackColor = false;
            this.btnLuuNX_DeNghi.Click += new System.EventHandler(this.btnLuuNX_DeNghi_Click);
            // 
            // ucGroupHeader4
            // 
            this.ucGroupHeader4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader4.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader4.GroupCaption = "MÔ TẢ";
            this.ucGroupHeader4.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader4.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader4.Margin = new System.Windows.Forms.Padding(4);
            this.ucGroupHeader4.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader4.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader4.Name = "ucGroupHeader4";
            this.ucGroupHeader4.Size = new System.Drawing.Size(693, 23);
            this.ucGroupHeader4.TabIndex = 101;
            // 
            // pnChucNang
            // 
            this.pnChucNang.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.pnChucNang.Appearance.Options.UseBackColor = true;
            this.pnChucNang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnChucNang.Controls.Add(this.btnThemDienGiai_Luoi);
            this.pnChucNang.Controls.Add(this.btnXemDienGiai_Luoi);
            this.pnChucNang.Controls.Add(this.lblNgayInSHPTLuoi);
            this.pnChucNang.Controls.Add(this.dtpNgayInKQLuoi);
            this.pnChucNang.Controls.Add(this.lblPhieuIn2);
            this.pnChucNang.Controls.Add(this.cboPhieuIn);
            this.pnChucNang.Controls.Add(this.btnLayThongTinTruocTQ);
            this.pnChucNang.Controls.Add(this.btnLuuNguoiThucHienTQ);
            this.pnChucNang.Controls.Add(this.txtNguoiThucHienTQ);
            this.pnChucNang.Controls.Add(this.cboNguoiThcuHienTQ);
            this.pnChucNang.Controls.Add(this.label10);
            this.pnChucNang.Controls.Add(this.dtpNguoiThucHienTQ);
            this.pnChucNang.Controls.Add(this.chkInMau);
            this.pnChucNang.Controls.Add(this.btnHuyXacNhanKQThuongQuy);
            this.pnChucNang.Controls.Add(this.btnXacNhanKQThuongQuy);
            this.pnChucNang.Controls.Add(this.chkTQ_InKhiXacNhan);
            this.pnChucNang.Controls.Add(this.btnXemInKQThuongQuy);
            this.pnChucNang.Controls.Add(this.btnInKetQuaThuognQuy);
            this.pnChucNang.Controls.Add(this.label7);
            this.pnChucNang.Controls.Add(this.chkChiInCoKetQua);
            this.pnChucNang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnChucNang.Location = new System.Drawing.Point(0, 500);
            this.pnChucNang.Name = "pnChucNang";
            this.pnChucNang.Size = new System.Drawing.Size(693, 91);
            this.pnChucNang.TabIndex = 4;
            // 
            // btnThemDienGiai_Luoi
            // 
            this.btnThemDienGiai_Luoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemDienGiai_Luoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemDienGiai_Luoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemDienGiai_Luoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemDienGiai_Luoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemDienGiai_Luoi.BorderRadius = 5;
            this.btnThemDienGiai_Luoi.BorderSize = 1;
            this.btnThemDienGiai_Luoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemDienGiai_Luoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDienGiai_Luoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDienGiai_Luoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemDienGiai_Luoi.ForeColor = System.Drawing.Color.Black;
            this.btnThemDienGiai_Luoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDienGiai_Luoi.Image")));
            this.btnThemDienGiai_Luoi.Location = new System.Drawing.Point(339, 5);
            this.btnThemDienGiai_Luoi.Name = "btnThemDienGiai_Luoi";
            this.btnThemDienGiai_Luoi.Size = new System.Drawing.Size(42, 38);
            this.btnThemDienGiai_Luoi.TabIndex = 119;
            this.btnThemDienGiai_Luoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThemDienGiai_Luoi.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnThemDienGiai_Luoi, "Lấy thời gian thực hiện trước đó");
            this.btnThemDienGiai_Luoi.UseHightLight = true;
            this.btnThemDienGiai_Luoi.UseVisualStyleBackColor = false;
            this.btnThemDienGiai_Luoi.Click += new System.EventHandler(this.btnThemDienGiai_Luoi_Click);
            // 
            // btnXemDienGiai_Luoi
            // 
            this.btnXemDienGiai_Luoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXemDienGiai_Luoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemDienGiai_Luoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemDienGiai_Luoi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemDienGiai_Luoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemDienGiai_Luoi.BorderRadius = 5;
            this.btnXemDienGiai_Luoi.BorderSize = 1;
            this.btnXemDienGiai_Luoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemDienGiai_Luoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDienGiai_Luoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDienGiai_Luoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemDienGiai_Luoi.ForeColor = System.Drawing.Color.Black;
            this.btnXemDienGiai_Luoi.Image = ((System.Drawing.Image)(resources.GetObject("btnXemDienGiai_Luoi.Image")));
            this.btnXemDienGiai_Luoi.Location = new System.Drawing.Point(339, 47);
            this.btnXemDienGiai_Luoi.Name = "btnXemDienGiai_Luoi";
            this.btnXemDienGiai_Luoi.Size = new System.Drawing.Size(42, 38);
            this.btnXemDienGiai_Luoi.TabIndex = 118;
            this.btnXemDienGiai_Luoi.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnXemDienGiai_Luoi, "Bỏ duyệt kết quả");
            this.btnXemDienGiai_Luoi.UseHightLight = true;
            this.btnXemDienGiai_Luoi.UseVisualStyleBackColor = false;
            this.btnXemDienGiai_Luoi.Click += new System.EventHandler(this.btnXemDienGiai_Luoi_Click);
            // 
            // lblNgayInSHPTLuoi
            // 
            this.lblNgayInSHPTLuoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNgayInSHPTLuoi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.lblNgayInSHPTLuoi.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayInSHPTLuoi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblNgayInSHPTLuoi.Appearance.Options.UseBackColor = true;
            this.lblNgayInSHPTLuoi.Appearance.Options.UseFont = true;
            this.lblNgayInSHPTLuoi.Appearance.Options.UseForeColor = true;
            this.lblNgayInSHPTLuoi.Location = new System.Drawing.Point(34, 68);
            this.lblNgayInSHPTLuoi.Name = "lblNgayInSHPTLuoi";
            this.lblNgayInSHPTLuoi.Size = new System.Drawing.Size(35, 15);
            this.lblNgayInSHPTLuoi.TabIndex = 117;
            this.lblNgayInSHPTLuoi.Text = "GIỜ IN";
            // 
            // dtpNgayInKQLuoi
            // 
            this.dtpNgayInKQLuoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNgayInKQLuoi.Checked = false;
            this.dtpNgayInKQLuoi.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpNgayInKQLuoi.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpNgayInKQLuoi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayInKQLuoi.Location = new System.Drawing.Point(146, 69);
            this.dtpNgayInKQLuoi.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayInKQLuoi.Name = "dtpNgayInKQLuoi";
            this.dtpNgayInKQLuoi.ShowCheckBox = true;
            this.dtpNgayInKQLuoi.Size = new System.Drawing.Size(192, 21);
            this.dtpNgayInKQLuoi.TabIndex = 116;
            this.dtpNgayInKQLuoi.Visible = false;
            // 
            // lblPhieuIn2
            // 
            this.lblPhieuIn2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPhieuIn2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.lblPhieuIn2.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieuIn2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblPhieuIn2.Appearance.Options.UseBackColor = true;
            this.lblPhieuIn2.Appearance.Options.UseFont = true;
            this.lblPhieuIn2.Appearance.Options.UseForeColor = true;
            this.lblPhieuIn2.Location = new System.Drawing.Point(34, 45);
            this.lblPhieuIn2.Name = "lblPhieuIn2";
            this.lblPhieuIn2.Size = new System.Drawing.Size(48, 15);
            this.lblPhieuIn2.TabIndex = 115;
            this.lblPhieuIn2.Text = "PHIẾU IN";
            // 
            // cboPhieuIn
            // 
            this.cboPhieuIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboPhieuIn.Font = new System.Drawing.Font("Arial", 8F);
            this.cboPhieuIn.FormattingEnabled = true;
            this.cboPhieuIn.Items.AddRange(new object[] {
            "1: Tiếng Việt",
            "2: Tiếng Anh",
            "3: Tiếng Nhật",
            "4: Tiếng Trung Quốc",
            "5: Tiếng Pháp"});
            this.cboPhieuIn.Location = new System.Drawing.Point(146, 45);
            this.cboPhieuIn.Name = "cboPhieuIn";
            this.cboPhieuIn.Size = new System.Drawing.Size(192, 22);
            this.cboPhieuIn.TabIndex = 114;
            // 
            // btnLayThongTinTruocTQ
            // 
            this.btnLayThongTinTruocTQ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLayThongTinTruocTQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLayThongTinTruocTQ.BackColorHover = System.Drawing.Color.Empty;
            this.btnLayThongTinTruocTQ.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLayThongTinTruocTQ.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLayThongTinTruocTQ.BorderRadius = 5;
            this.btnLayThongTinTruocTQ.BorderSize = 1;
            this.btnLayThongTinTruocTQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLayThongTinTruocTQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayThongTinTruocTQ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayThongTinTruocTQ.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLayThongTinTruocTQ.ForeColor = System.Drawing.Color.Black;
            this.btnLayThongTinTruocTQ.Image = ((System.Drawing.Image)(resources.GetObject("btnLayThongTinTruocTQ.Image")));
            this.btnLayThongTinTruocTQ.Location = new System.Drawing.Point(383, 5);
            this.btnLayThongTinTruocTQ.Name = "btnLayThongTinTruocTQ";
            this.btnLayThongTinTruocTQ.Size = new System.Drawing.Size(42, 38);
            this.btnLayThongTinTruocTQ.TabIndex = 111;
            this.btnLayThongTinTruocTQ.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLayThongTinTruocTQ.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnLayThongTinTruocTQ, "Lấy thời gian thực hiện trước đó");
            this.btnLayThongTinTruocTQ.UseHightLight = true;
            this.btnLayThongTinTruocTQ.UseVisualStyleBackColor = false;
            this.btnLayThongTinTruocTQ.Click += new System.EventHandler(this.btnLayThongTinTruocTQ_Click);
            // 
            // btnLuuNguoiThucHienTQ
            // 
            this.btnLuuNguoiThucHienTQ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuuNguoiThucHienTQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLuuNguoiThucHienTQ.BackColorHover = System.Drawing.Color.Empty;
            this.btnLuuNguoiThucHienTQ.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnLuuNguoiThucHienTQ.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnLuuNguoiThucHienTQ.BorderRadius = 5;
            this.btnLuuNguoiThucHienTQ.BorderSize = 1;
            this.btnLuuNguoiThucHienTQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuNguoiThucHienTQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuNguoiThucHienTQ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuNguoiThucHienTQ.ForceColorHover = System.Drawing.Color.Empty;
            this.btnLuuNguoiThucHienTQ.ForeColor = System.Drawing.Color.Black;
            this.btnLuuNguoiThucHienTQ.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuNguoiThucHienTQ.Image")));
            this.btnLuuNguoiThucHienTQ.Location = new System.Drawing.Point(427, 5);
            this.btnLuuNguoiThucHienTQ.Name = "btnLuuNguoiThucHienTQ";
            this.btnLuuNguoiThucHienTQ.Size = new System.Drawing.Size(42, 38);
            this.btnLuuNguoiThucHienTQ.TabIndex = 110;
            this.btnLuuNguoiThucHienTQ.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLuuNguoiThucHienTQ.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnLuuNguoiThucHienTQ, "Lưu kết quả");
            this.btnLuuNguoiThucHienTQ.UseHightLight = true;
            this.btnLuuNguoiThucHienTQ.UseVisualStyleBackColor = false;
            this.btnLuuNguoiThucHienTQ.Click += new System.EventHandler(this.btnLuuNguoiThucHienTQ_Click);
            // 
            // txtNguoiThucHienTQ
            // 
            this.txtNguoiThucHienTQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNguoiThucHienTQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtNguoiThucHienTQ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiThucHienTQ.ForeColor = System.Drawing.Color.Red;
            this.txtNguoiThucHienTQ.Location = new System.Drawing.Point(146, 22);
            this.txtNguoiThucHienTQ.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNguoiThucHienTQ.MaxLength = 5;
            this.txtNguoiThucHienTQ.Name = "txtNguoiThucHienTQ";
            this.txtNguoiThucHienTQ.ReadOnly = true;
            this.txtNguoiThucHienTQ.Size = new System.Drawing.Size(192, 21);
            this.txtNguoiThucHienTQ.TabIndex = 109;
            // 
            // cboNguoiThcuHienTQ
            // 
            this.cboNguoiThcuHienTQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboNguoiThcuHienTQ.AutoComplete = false;
            this.cboNguoiThcuHienTQ.AutoDropdown = false;
            this.cboNguoiThcuHienTQ.BackColorEven = System.Drawing.Color.White;
            this.cboNguoiThcuHienTQ.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNguoiThcuHienTQ.ColumnNames = "";
            this.cboNguoiThcuHienTQ.ColumnWidthDefault = 75;
            this.cboNguoiThcuHienTQ.ColumnWidths = "";
            this.cboNguoiThcuHienTQ.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNguoiThcuHienTQ.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNguoiThcuHienTQ.FormattingEnabled = true;
            this.cboNguoiThcuHienTQ.LinkedColumnIndex = 0;
            this.cboNguoiThcuHienTQ.LinkedColumnIndex1 = 0;
            this.cboNguoiThcuHienTQ.LinkedColumnIndex2 = 0;
            this.cboNguoiThcuHienTQ.LinkedTextBox = null;
            this.cboNguoiThcuHienTQ.LinkedTextBox1 = null;
            this.cboNguoiThcuHienTQ.LinkedTextBox2 = null;
            this.cboNguoiThcuHienTQ.Location = new System.Drawing.Point(34, 22);
            this.cboNguoiThcuHienTQ.Name = "cboNguoiThcuHienTQ";
            this.cboNguoiThcuHienTQ.Size = new System.Drawing.Size(107, 21);
            this.cboNguoiThcuHienTQ.TabIndex = 108;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.Location = new System.Drawing.Point(34, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 107;
            this.label10.Text = "Người thực hiện";
            // 
            // dtpNguoiThucHienTQ
            // 
            this.dtpNguoiThucHienTQ.AllowMoveFocus = false;
            this.dtpNguoiThucHienTQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNguoiThucHienTQ.Checked = false;
            this.dtpNguoiThucHienTQ.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpNguoiThucHienTQ.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpNguoiThucHienTQ.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNguoiThucHienTQ.IsEndDate = false;
            this.dtpNguoiThucHienTQ.IsStartDate = false;
            this.dtpNguoiThucHienTQ.Location = new System.Drawing.Point(147, 0);
            this.dtpNguoiThucHienTQ.Name = "dtpNguoiThucHienTQ";
            this.dtpNguoiThucHienTQ.ShowCheckBox = true;
            this.dtpNguoiThucHienTQ.Size = new System.Drawing.Size(190, 21);
            this.dtpNguoiThucHienTQ.TabIndex = 106;
            // 
            // chkInMau
            // 
            this.chkInMau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkInMau.AutoSize = true;
            this.chkInMau.Checked = true;
            this.chkInMau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInMau.Location = new System.Drawing.Point(520, 64);
            this.chkInMau.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkInMau.Name = "chkInMau";
            this.chkInMau.Size = new System.Drawing.Size(64, 19);
            this.chkInMau.TabIndex = 102;
            this.chkInMau.Text = "In màu";
            this.chkInMau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInMau.UseVisualStyleBackColor = true;
            // 
            // btnHuyXacNhanKQThuongQuy
            // 
            this.btnHuyXacNhanKQThuongQuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuyXacNhanKQThuongQuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuyXacNhanKQThuongQuy.BackColorHover = System.Drawing.Color.Empty;
            this.btnHuyXacNhanKQThuongQuy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuyXacNhanKQThuongQuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnHuyXacNhanKQThuongQuy.BorderRadius = 5;
            this.btnHuyXacNhanKQThuongQuy.BorderSize = 1;
            this.btnHuyXacNhanKQThuongQuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyXacNhanKQThuongQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyXacNhanKQThuongQuy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyXacNhanKQThuongQuy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnHuyXacNhanKQThuongQuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuyXacNhanKQThuongQuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuyXacNhanKQThuongQuy.Image")));
            this.btnHuyXacNhanKQThuongQuy.Location = new System.Drawing.Point(383, 47);
            this.btnHuyXacNhanKQThuongQuy.Name = "btnHuyXacNhanKQThuongQuy";
            this.btnHuyXacNhanKQThuongQuy.Size = new System.Drawing.Size(42, 38);
            this.btnHuyXacNhanKQThuongQuy.TabIndex = 100;
            this.btnHuyXacNhanKQThuongQuy.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnHuyXacNhanKQThuongQuy, "Bỏ duyệt kết quả");
            this.btnHuyXacNhanKQThuongQuy.UseHightLight = true;
            this.btnHuyXacNhanKQThuongQuy.UseVisualStyleBackColor = false;
            this.btnHuyXacNhanKQThuongQuy.Click += new System.EventHandler(this.btnHuyXacNhanKQThuongQuy_Click);
            // 
            // btnXacNhanKQThuongQuy
            // 
            this.btnXacNhanKQThuongQuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXacNhanKQThuongQuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXacNhanKQThuongQuy.BackColorHover = System.Drawing.Color.Empty;
            this.btnXacNhanKQThuongQuy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXacNhanKQThuongQuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXacNhanKQThuongQuy.BorderRadius = 5;
            this.btnXacNhanKQThuongQuy.BorderSize = 1;
            this.btnXacNhanKQThuongQuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanKQThuongQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanKQThuongQuy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanKQThuongQuy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXacNhanKQThuongQuy.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhanKQThuongQuy.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhanKQThuongQuy.Image")));
            this.btnXacNhanKQThuongQuy.Location = new System.Drawing.Point(471, 5);
            this.btnXacNhanKQThuongQuy.Name = "btnXacNhanKQThuongQuy";
            this.btnXacNhanKQThuongQuy.Size = new System.Drawing.Size(42, 38);
            this.btnXacNhanKQThuongQuy.TabIndex = 99;
            this.btnXacNhanKQThuongQuy.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnXacNhanKQThuongQuy, "Duyệt kết quả");
            this.btnXacNhanKQThuongQuy.UseHightLight = true;
            this.btnXacNhanKQThuongQuy.UseVisualStyleBackColor = false;
            this.btnXacNhanKQThuongQuy.Click += new System.EventHandler(this.btnXacNhanKQThuongQuy_Click);
            // 
            // chkTQ_InKhiXacNhan
            // 
            this.chkTQ_InKhiXacNhan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkTQ_InKhiXacNhan.AutoSize = true;
            this.chkTQ_InKhiXacNhan.Checked = true;
            this.chkTQ_InKhiXacNhan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTQ_InKhiXacNhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTQ_InKhiXacNhan.Location = new System.Drawing.Point(520, 35);
            this.chkTQ_InKhiXacNhan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkTQ_InKhiXacNhan.Name = "chkTQ_InKhiXacNhan";
            this.chkTQ_InKhiXacNhan.Size = new System.Drawing.Size(130, 19);
            this.chkTQ_InKhiXacNhan.TabIndex = 93;
            this.chkTQ_InKhiXacNhan.Text = "Tự in khi xác nhận";
            this.chkTQ_InKhiXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnXemInKQThuongQuy
            // 
            this.btnXemInKQThuongQuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXemInKQThuongQuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemInKQThuongQuy.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemInKQThuongQuy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXemInKQThuongQuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXemInKQThuongQuy.BorderRadius = 5;
            this.btnXemInKQThuongQuy.BorderSize = 1;
            this.btnXemInKQThuongQuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemInKQThuongQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemInKQThuongQuy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemInKQThuongQuy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemInKQThuongQuy.ForeColor = System.Drawing.Color.Black;
            this.btnXemInKQThuongQuy.Image = ((System.Drawing.Image)(resources.GetObject("btnXemInKQThuongQuy.Image")));
            this.btnXemInKQThuongQuy.Location = new System.Drawing.Point(427, 47);
            this.btnXemInKQThuongQuy.Name = "btnXemInKQThuongQuy";
            this.btnXemInKQThuongQuy.Size = new System.Drawing.Size(42, 38);
            this.btnXemInKQThuongQuy.TabIndex = 98;
            this.btnXemInKQThuongQuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemInKQThuongQuy.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnXemInKQThuongQuy, "Xin in kết quả");
            this.btnXemInKQThuongQuy.UseHightLight = true;
            this.btnXemInKQThuongQuy.UseVisualStyleBackColor = false;
            this.btnXemInKQThuongQuy.Click += new System.EventHandler(this.btnXamtruongKQThuongQuy_Click);
            // 
            // btnInKetQuaThuognQuy
            // 
            this.btnInKetQuaThuognQuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInKetQuaThuognQuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInKetQuaThuognQuy.BackColorHover = System.Drawing.Color.Empty;
            this.btnInKetQuaThuognQuy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInKetQuaThuognQuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnInKetQuaThuognQuy.BorderRadius = 5;
            this.btnInKetQuaThuognQuy.BorderSize = 1;
            this.btnInKetQuaThuognQuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInKetQuaThuognQuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInKetQuaThuognQuy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInKetQuaThuognQuy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnInKetQuaThuognQuy.ForeColor = System.Drawing.Color.Black;
            this.btnInKetQuaThuognQuy.Image = ((System.Drawing.Image)(resources.GetObject("btnInKetQuaThuognQuy.Image")));
            this.btnInKetQuaThuognQuy.Location = new System.Drawing.Point(471, 47);
            this.btnInKetQuaThuognQuy.Name = "btnInKetQuaThuognQuy";
            this.btnInKetQuaThuognQuy.Size = new System.Drawing.Size(42, 38);
            this.btnInKetQuaThuognQuy.TabIndex = 97;
            this.btnInKetQuaThuognQuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInKetQuaThuognQuy.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnInKetQuaThuognQuy, "In kết quả");
            this.btnInKetQuaThuognQuy.UseHightLight = true;
            this.btnInKetQuaThuognQuy.UseVisualStyleBackColor = false;
            this.btnInKetQuaThuognQuy.Click += new System.EventHandler(this.btnInKetQuaThuognQuy_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(620, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 83;
            // 
            // chkChiInCoKetQua
            // 
            this.chkChiInCoKetQua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkChiInCoKetQua.AutoSize = true;
            this.chkChiInCoKetQua.Checked = true;
            this.chkChiInCoKetQua.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChiInCoKetQua.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChiInCoKetQua.Location = new System.Drawing.Point(520, 5);
            this.chkChiInCoKetQua.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkChiInCoKetQua.Name = "chkChiInCoKetQua";
            this.chkChiInCoKetQua.Size = new System.Drawing.Size(94, 19);
            this.chkChiInCoKetQua.TabIndex = 94;
            this.chkChiInCoKetQua.Text = "Chỉ in có KQ";
            this.chkChiInCoKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkChiInCoKetQua.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLayHinhTuClipBoard});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 26);
            // 
            // mnuLayHinhTuClipBoard
            // 
            this.mnuLayHinhTuClipBoard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuLayHinhTuClipBoard.Name = "mnuLayHinhTuClipBoard";
            this.mnuLayHinhTuClipBoard.Size = new System.Drawing.Size(189, 22);
            this.mnuLayHinhTuClipBoard.Text = "Lấy hình từ clipborad";
            this.mnuLayHinhTuClipBoard.Click += new System.EventHandler(this.mnuLayHinhTuClipBoard_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Null.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKetQuaBN);
            this.tabControl1.Controls.Add(this.tabKetQuaMay);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1109, 625);
            this.tabControl1.TabIndex = 95;
            // 
            // tabKetQuaBN
            // 
            this.tabKetQuaBN.Controls.Add(this.splitContainer1);
            this.tabKetQuaBN.Location = new System.Drawing.Point(4, 22);
            this.tabKetQuaBN.Name = "tabKetQuaBN";
            this.tabKetQuaBN.Padding = new System.Windows.Forms.Padding(3);
            this.tabKetQuaBN.Size = new System.Drawing.Size(1101, 599);
            this.tabKetQuaBN.TabIndex = 0;
            this.tabKetQuaBN.Text = "Kết quả xét nghiệm";
            // 
            // tabKetQuaMay
            // 
            this.tabKetQuaMay.BackColor = System.Drawing.SystemColors.Control;
            this.tabKetQuaMay.Controls.Add(this.analyzerResult1);
            this.tabKetQuaMay.Location = new System.Drawing.Point(4, 22);
            this.tabKetQuaMay.Name = "tabKetQuaMay";
            this.tabKetQuaMay.Padding = new System.Windows.Forms.Padding(3);
            this.tabKetQuaMay.Size = new System.Drawing.Size(1170, 599);
            this.tabKetQuaMay.TabIndex = 1;
            this.tabKetQuaMay.Text = "Kết quả từ máy";
            // 
            // analyzerResult1
            // 
            this.analyzerResult1.BackColor = System.Drawing.Color.Transparent;
            this.analyzerResult1.BioticMode = false;
            this.analyzerResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analyzerResult1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyzerResult1.Location = new System.Drawing.Point(3, 3);
            this.analyzerResult1.Margin = new System.Windows.Forms.Padding(4);
            this.analyzerResult1.Name = "analyzerResult1";
            this.analyzerResult1.Size = new System.Drawing.Size(1164, 593);
            this.analyzerResult1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.ucKiemSoatChiDinhChayMay);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1170, 599);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Kiểm soát chỉ định máy";
            // 
            // ucKiemSoatChiDinhChayMay
            // 
            this.ucKiemSoatChiDinhChayMay.BackColor = System.Drawing.Color.Transparent;
            this.ucKiemSoatChiDinhChayMay.BarcodeLenght = 0;
            this.ucKiemSoatChiDinhChayMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucKiemSoatChiDinhChayMay.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucKiemSoatChiDinhChayMay.Location = new System.Drawing.Point(3, 3);
            this.ucKiemSoatChiDinhChayMay.Margin = new System.Windows.Forms.Padding(4);
            this.ucKiemSoatChiDinhChayMay.Name = "ucKiemSoatChiDinhChayMay";
            this.ucKiemSoatChiDinhChayMay.Size = new System.Drawing.Size(1164, 593);
            this.ucKiemSoatChiDinhChayMay.TabIndex = 1;
            // 
            // btnKQXetNghiem
            // 
            this.btnKQXetNghiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.btnKQXetNghiem.BackColorHover = System.Drawing.Color.Empty;
            this.btnKQXetNghiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.btnKQXetNghiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnKQXetNghiem.BorderRadius = 0;
            this.btnKQXetNghiem.BorderSize = 1;
            this.btnKQXetNghiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKQXetNghiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKQXetNghiem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnKQXetNghiem.ForceColorHover = System.Drawing.Color.Black;
            this.btnKQXetNghiem.ForeColor = System.Drawing.Color.White;
            this.btnKQXetNghiem.Location = new System.Drawing.Point(4, 1);
            this.btnKQXetNghiem.Name = "btnKQXetNghiem";
            this.btnKQXetNghiem.Size = new System.Drawing.Size(183, 26);
            this.btnKQXetNghiem.TabIndex = 14;
            this.btnKQXetNghiem.Text = "KẾT QUẢ XÉT NGHIỆM";
            this.btnKQXetNghiem.TextColor = System.Drawing.Color.White;
            this.btnKQXetNghiem.UseHightLight = false;
            this.btnKQXetNghiem.UseVisualStyleBackColor = false;
            this.btnKQXetNghiem.Click += new System.EventHandler(this.btnKQXetNghiem_Click);
            // 
            // btnKetQuaMay
            // 
            this.btnKetQuaMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.btnKetQuaMay.BackColorHover = System.Drawing.Color.Empty;
            this.btnKetQuaMay.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.btnKetQuaMay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnKetQuaMay.BorderRadius = 0;
            this.btnKetQuaMay.BorderSize = 1;
            this.btnKetQuaMay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKetQuaMay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetQuaMay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnKetQuaMay.ForceColorHover = System.Drawing.Color.Black;
            this.btnKetQuaMay.ForeColor = System.Drawing.Color.White;
            this.btnKetQuaMay.Location = new System.Drawing.Point(196, 1);
            this.btnKetQuaMay.Name = "btnKetQuaMay";
            this.btnKetQuaMay.Size = new System.Drawing.Size(164, 26);
            this.btnKetQuaMay.TabIndex = 11;
            this.btnKetQuaMay.Text = "KẾT QUẢ TỪ MÁY";
            this.btnKetQuaMay.TextColor = System.Drawing.Color.White;
            this.btnKetQuaMay.UseHightLight = false;
            this.btnKetQuaMay.UseVisualStyleBackColor = false;
            this.btnKetQuaMay.Click += new System.EventHandler(this.btnKetQuaMay_Click);
            // 
            // btnChiDinhMay
            // 
            this.btnChiDinhMay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.btnChiDinhMay.BackColorHover = System.Drawing.Color.Empty;
            this.btnChiDinhMay.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.btnChiDinhMay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnChiDinhMay.BorderRadius = 0;
            this.btnChiDinhMay.BorderSize = 1;
            this.btnChiDinhMay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChiDinhMay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiDinhMay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnChiDinhMay.ForceColorHover = System.Drawing.Color.Black;
            this.btnChiDinhMay.ForeColor = System.Drawing.Color.White;
            this.btnChiDinhMay.Location = new System.Drawing.Point(370, 1);
            this.btnChiDinhMay.Name = "btnChiDinhMay";
            this.btnChiDinhMay.Size = new System.Drawing.Size(165, 26);
            this.btnChiDinhMay.TabIndex = 13;
            this.btnChiDinhMay.Text = "CHỈ ĐỊNH GỬI MÁY";
            this.btnChiDinhMay.TextColor = System.Drawing.Color.White;
            this.btnChiDinhMay.UseHightLight = false;
            this.btnChiDinhMay.UseVisualStyleBackColor = false;
            this.btnChiDinhMay.Click += new System.EventHandler(this.btnChiDinhMay_Click);
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader1.GroupCaption = "CHỌN";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 5);
            this.ucGroupHeader1.Margin = new System.Windows.Forms.Padding(4);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(93, 23);
            this.ucGroupHeader1.TabIndex = 378;
            // 
            // FrmSinhHocPhanTu
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1115, 661);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MoveForm = false;
            this.Name = "FrmSinhHocPhanTu";
            this.Text = "Kết quả sinh học phân tử";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSinhHocPhanTu_FormClosing);
            this.Load += new System.EventHandler(this.FrmSinhHocPhanTu_Load);
            this.Shown += new System.EventHandler(this.FrmSinhHocPhanTu_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSinhHocPhanTu_KeyDown);
            this.Controls.SetChildIndex(this.pnLabel, 0);
            this.Controls.SetChildIndex(this.pnMenu, 0);
            this.Controls.SetChildIndex(this.pnContaint, 0);
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
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnDanhSachBN)).EndInit();
            this.pnDanhSachBN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnSignature)).EndInit();
            this.pnSignature.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel25)).EndInit();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnChonKyten)).EndInit();
            this.pnChonKyten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPageTachRoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnKetQua_SHPT)).EndInit();
            this.pnKetQua_SHPT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3.Panel2)).EndInit();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnChiDinh)).EndInit();
            this.pnChiDinh.ResumeLayout(false);
            this.pnChiDinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiDInh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiDInh)).EndInit();
            this.bvChiDInh.ResumeLayout(false);
            this.bvChiDInh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnResult_Containt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnKetLuan)).EndInit();
            this.pnKetLuan.ResumeLayout(false);
            this.pnKetLuan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnThongTinXN)).EndInit();
            this.pnThongTinXN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel5)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel2)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnNgayInRoi)).EndInit();
            this.pnNgayInRoi.ResumeLayout(false);
            this.xtraTabPageKQLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4.Panel1)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4.Panel2)).EndInit();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnChucNang)).EndInit();
            this.pnChucNang.ResumeLayout(false);
            this.pnChucNang.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabKetQuaBN.ResumeLayout(false);
            this.tabKetQuaMay.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private AppCode.ucPatientInformation ucPatientInformation1;
        private DevExpress.XtraEditors.PanelControl pnDanhSachBN;
        private DevExpress.XtraEditors.PanelControl pnKetLuan;
        private DevExpress.XtraEditors.PanelControl pnChiDinh;
        private Common.Controls.CustomDatagridView dtgChiDInh;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.PanelControl panel4;
        private System.Windows.Forms.ListBox listPrinter;
        private System.Windows.Forms.CheckBox chkPrintTitle;
        private DevExpress.XtraEditors.LabelControl lblAutoPrintStatus;
        private System.Windows.Forms.BindingNavigator bvChiDInh;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuLayHinhTuClipBoard;
        private System.Windows.Forms.CheckBox chkValidWhenPrint;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
        private RicherTextBox.RicherTextBox rchThongTinXN_ThongThuong;
        private System.Windows.Forms.ComboBox cboMayXn;
        private System.Windows.Forms.CheckBox chkKetQuaDaXacNhan;
        private System.Windows.Forms.TextBox txtPhuongPhap;
        private DevExpress.XtraEditors.LabelControl label8;
        private DevExpress.XtraEditors.LabelControl label12;
        private DevExpress.XtraEditors.PanelControl pnKetQua_SHPT;
        private DevExpress.XtraEditors.PanelControl pnThongTinXN;
        private DevExpress.XtraEditors.PanelControl panel5;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtCSBT;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer2;
        private System.Windows.Forms.Splitter splitter1;
        private DevExpress.XtraEditors.LabelControl label3;
        private Common.Controls.CustomDateTimePicker dtpTGDoiChieu;
        private Common.Controls.CustomTextBox txtGhiChu;
        private System.Windows.Forms.CheckBox chkInTheoChiDinh;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.LabelControl label5;
        private System.Windows.Forms.TextBox txtMaSoMau;
        private TPH.Controls.TPHNormalButton btnLuu;
        private System.Windows.Forms.ToolTip toolTip1;
        private TPH.Controls.TPHNormalButton btnHuyXacNhanKetQua;
        private TPH.Controls.TPHNormalButton btnXacNhanKetQua;
        private TPH.Controls.TPHNormalButton btnXemIn;
        private TPH.Controls.TPHNormalButton btnInketQua;
        private DevExpress.XtraEditors.PanelControl pnSignature;
        private TPH.Controls.TPHNormalButton cmdRefreshPrinter;
        private DevExpress.XtraEditors.PanelControl panel25;
        private DevExpress.XtraEditors.PanelControl pnChonKyten;
        private DevExpress.XtraEditors.LabelControl lblTruongKhoa;
        private TPH.Controls.TPHNormalButton btnSign;
        private System.Windows.Forms.CheckBox chkRePrint;
        private TPH.Controls.TPHNormalButton btnCloseSetting;
        private TPH.Controls.TPHTabControl tabControl1;
        private System.Windows.Forms.TabPage tabKetQuaBN;
        private System.Windows.Forms.TabPage tabKetQuaMay;
        private Analyzer.Controls.AnalyzerResult analyzerResult1;
        private System.Windows.Forms.TabPage tabPage1;
        private Analyzer.Controls.ucKiemSoatDownloadMayXn ucKiemSoatChiDinhChayMay;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer3;
        private DevExpress.XtraEditors.PanelControl pnChucNang;
        private System.Windows.Forms.CheckBox chkInMau;
        private TPH.Controls.TPHNormalButton btnHuyXacNhanKQThuongQuy;
        private TPH.Controls.TPHNormalButton btnXacNhanKQThuongQuy;
        private System.Windows.Forms.CheckBox chkTQ_InKhiXacNhan;
        private TPH.Controls.TPHNormalButton btnXemInKQThuongQuy;
        private TPH.Controls.TPHNormalButton btnInKetQuaThuognQuy;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.CheckBox chkChiInCoKetQua;
        private System.Windows.Forms.TextBox txtNguoiThucHienTQ;
        private Common.Controls.CustomComboBox cboNguoiThcuHienTQ;
        private DevExpress.XtraEditors.LabelControl label10;
        private Common.Controls.CustomDateTimePicker dtpNguoiThucHienTQ;
        private TPH.Controls.TPHNormalButton btnLuuNguoiThucHienTQ;
        private AppCode.ucDanhSachBenhNhanXN ucDanhSachBenhNhanXN1;
        private System.Windows.Forms.CheckBox chkInKhiXacNhanSHPT;
        private TPH.Controls.TPHNormalButton btnLayThongTinTruocSHPT;
        private TPH.Controls.TPHNormalButton btnLayThongTinTruocTQ;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageKQLuoi;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageTachRoi;
        private AppCode.ucKetQuaThuongQuy ucKetQuaThuongQuy1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer4;
        private System.Windows.Forms.TextBox txtDienGiai;
        private DevExpress.XtraEditors.LabelControl label36;
        private System.Windows.Forms.TextBox txtDeNghi;
        private DevExpress.XtraEditors.LabelControl label33;
        private DevExpress.XtraEditors.PanelControl panel7;
        private TPH.Controls.TPHNormalButton btnLuuNX_DeNghi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaTiepNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBenhPhamGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhuongPhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCSBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetqua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSHPTGenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguongTren;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguongDuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDKBatThuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua_HeSoNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua_Lamtron;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChiDinh_DaXacNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_NguoiXacNhan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChiDinh_DaIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_NguoiNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_NguoiSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_NguoiXacNhan2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_ThoiGianXacNhanKQ2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMauInSHPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSoMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua_KetQuaHeSo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colKetQua_DaUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua_LanUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_lanxn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDinh_ThoiGianXacNhanThucHien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDS_IdMayXn;
        private DevExpress.XtraEditors.LabelControl lblPhieuIn2;
        private System.Windows.Forms.ComboBox cboPhieuIn;
        private DevExpress.XtraEditors.LabelControl lblPhieuIn;
        private System.Windows.Forms.ComboBox cboPhieuInSHPT;
        private AppCode.ucSearchLookupEditor_KyTen ucSearchLookupEditor_KyTenlanhdao;
        private DevExpress.XtraEditors.LabelControl lblKyLanhDao;
        private AppCode.ucSearchLookupEditor_KyTen ucSearchLookupEditor_KyTentruongKhoa;
        private ucGroupHeader ucGroupHeader2;
        private ucGroupHeader ucGroupHeader3;
        private ucGroupHeader ucGroupHeaderChuThich;
        private ucGroupHeader ucGroupHeader5;
        private ucGroupHeader ucGroupHeader1;
        private TPH.Controls.TPHNormalButton btnKQXetNghiem;
        private TPH.Controls.TPHNormalButton btnKetQuaMay;
        private TPH.Controls.TPHNormalButton btnChiDinhMay;
        private ucGroupHeader ucGroupHeader4;
        private DevExpress.XtraEditors.LabelControl lblNgayInSHPTLuoi;
        private System.Windows.Forms.DateTimePicker dtpNgayInKQLuoi;
        private DevExpress.XtraEditors.LabelControl lblNgayInSHPTRoi;
        private System.Windows.Forms.DateTimePicker dtpGioInKQRoi;
        private DevExpress.XtraEditors.PanelControl pnNgayInRoi;
        private AppCode.ucSearchLookupEditor_DoiChieuSHPT ucSearchLookupEditor_DoiChieuSHPT1;
        private DevExpress.XtraEditors.PanelControl pnResult_Containt;
        private Controls.TPHNormalButton btnThemDienGiai_Luoi;
        private Controls.TPHNormalButton btnXemDienGiai_Luoi;
        private Controls.TPHNormalButton btnThemDienGiai_ToRoi;
        private Controls.TPHNormalButton btnXemDienGiai_ToRoi;
    }
}