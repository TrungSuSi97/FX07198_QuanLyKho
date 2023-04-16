using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    partial class FrmThuPhiDichVu_bk
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThuPhiDichVu_bk));
            this.dtgPatient = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvPatient = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMFirst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoveLast = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshChargeList = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.label24 = new DevExpress.XtraEditors.LabelControl();
            this.txtFindIDBienLai = new System.Windows.Forms.TextBox();
            this.radAllCharge = new System.Windows.Forms.RadioButton();
            this.radNotCharge = new System.Windows.Forms.RadioButton();
            this.radFinishCharge = new System.Windows.Forms.RadioButton();
            this.txtFindSEQ = new System.Windows.Forms.TextBox();
            this.txtFindName = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabThuPhi = new System.Windows.Forms.TabPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.ucChiTietChiDinh1 = new TPH.LIS.App.AppCode.ucChiTietChiDinh();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.radCK_Per = new System.Windows.Forms.RadioButton();
            this.radCK_VND = new System.Windows.Forms.RadioButton();
            this.txtCK = new System.Windows.Forms.TextBox();
            this.label26 = new DevExpress.XtraEditors.LabelControl();
            this.label20 = new DevExpress.XtraEditors.LabelControl();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.chkThuPhi_InTrucTiep = new System.Windows.Forms.CheckBox();
            this.btnTaoBienLai = new TPH.Controls.TPHNormalButton();
            this.txtChuaThu = new System.Windows.Forms.TextBox();
            this.chkUpdateChagreAuto = new System.Windows.Forms.CheckBox();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.txtDaThu = new System.Windows.Forms.TextBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.cboUsersign = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtSignName = new System.Windows.Forms.TextBox();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.tabBienLaiThuPhi = new System.Windows.Forms.TabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcChiTietBienLai = new DevExpress.XtraGrid.GridControl();
            this.gvChiTietBienlai = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChiTietnBl_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colBienLai_TenPhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_TenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_Dongia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_Soluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_ThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_DaThuTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_DaHoanTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_MaTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_MaBienLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_MaPhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_MaNhomDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_TenNhomDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_MaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_ThuTuInDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_ThuTuInNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_PhanTramCK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLai_ThucTra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bvChiTietBienLai = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bntChonThuTien = new System.Windows.Forms.ToolStripButton();
            this.bntChonHoanTien = new System.Windows.Forms.ToolStripButton();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.txtTotalReturnCount = new System.Windows.Forms.TextBox();
            this.label23 = new DevExpress.XtraEditors.LabelControl();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.label22 = new DevExpress.XtraEditors.LabelControl();
            this.cboThuNganHoantien = new TPH.LIS.Common.Controls.CustomComboBox();
            this.TxtThuNganHoantien = new System.Windows.Forms.TextBox();
            this.btnHoanTien = new TPH.Controls.TPHNormalButton();
            this.label16 = new DevExpress.XtraEditors.LabelControl();
            this.btnCapNhatThanhToan = new TPH.Controls.TPHNormalButton();
            this.chkBienLai_BatThuTien = new System.Windows.Forms.CheckBox();
            this.btnDaThuTien = new TPH.Controls.TPHNormalButton();
            this.txtTongTien_BienLai = new System.Windows.Forms.TextBox();
            this.chkBienLai_inTrucTiep = new System.Windows.Forms.CheckBox();
            this.btnInBienLai_BienLai = new TPH.Controls.TPHNormalButton();
            this.txtConNo_BienLai = new System.Windows.Forms.TextBox();
            this.label17 = new DevExpress.XtraEditors.LabelControl();
            this.txtThanhToan_BienLai = new System.Windows.Forms.TextBox();
            this.label18 = new DevExpress.XtraEditors.LabelControl();
            this.label19 = new DevExpress.XtraEditors.LabelControl();
            this.cboThuNgan2 = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtThuNgan2 = new System.Windows.Forms.TextBox();
            this.label21 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcBienLai = new DevExpress.XtraGrid.GridControl();
            this.gvBienLai = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBienLaiMaTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiMaBienLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiTongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiConLai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiNgayThannhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiThuNgan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiMayTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiNguoiThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiHinhThucThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiThaoTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiTenThaoTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiSEQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBienLaiNgayTiepNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.txtMaTiepNhan = new System.Windows.Forms.TextBox();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.txtBSChiDinh = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.label14 = new DevExpress.XtraEditors.LabelControl();
            this.label25 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.chkAgeType = new System.Windows.Forms.CheckBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.listPrinterCharge = new System.Windows.Forms.ListBox();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatient)).BeginInit();
            this.bvPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabThuPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.tabBienLaiThuPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTietBienLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTietBienlai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiTietBienLai)).BeginInit();
            this.bvChiTietBienLai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBienLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBienLai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
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
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(136, 21);
            this.lblTitle.Text = "THU PHÍ DỊCH VỤ";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Controls.Add(this.groupControl7);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0);
            this.pnLabel.Size = new System.Drawing.Size(1184, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Transparent;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Margin = new System.Windows.Forms.Padding(0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(138, 1);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
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
            // dtgPatient
            // 
            this.dtgPatient.AlignColumns = "";
            this.dtgPatient.AllignNumberText = false;
            this.dtgPatient.AllowUserToAddRows = false;
            this.dtgPatient.AllowUserToDeleteRows = false;
            this.dtgPatient.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgPatient.CheckBoldColumn = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPatient.ColumnHeadersHeight = 28;
            this.dtgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.SoTT,
            this.TenBN,
            this.DateIn,
            this.NamSinh,
            this.DiaChi,
            this.MaTiepNhan});
            this.dtgPatient.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPatient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPatient.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgPatient.Location = new System.Drawing.Point(2, 155);
            this.dtgPatient.Margin = new System.Windows.Forms.Padding(0);
            this.dtgPatient.MarkOddEven = true;
            this.dtgPatient.MultiSelect = false;
            this.dtgPatient.Name = "dtgPatient";
            this.dtgPatient.ReadOnly = true;
            this.dtgPatient.RowHeadersVisible = false;
            this.dtgPatient.RowHeadersWidth = 35;
            this.dtgPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPatient.Size = new System.Drawing.Size(287, 399);
            this.dtgPatient.TabIndex = 98;
            this.dtgPatient.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatient_CellEnter);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Chon";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Chọn";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // SoTT
            // 
            this.SoTT.DataPropertyName = "SEQ";
            this.SoTT.HeaderText = "Số TT";
            this.SoTT.Name = "SoTT";
            this.SoTT.ReadOnly = true;
            this.SoTT.Width = 70;
            // 
            // TenBN
            // 
            this.TenBN.DataPropertyName = "TenBN";
            this.TenBN.HeaderText = "Tên bệnh nhân";
            this.TenBN.Name = "TenBN";
            this.TenBN.ReadOnly = true;
            this.TenBN.Width = 200;
            // 
            // DateIn
            // 
            this.DateIn.DataPropertyName = "NgayTiepNhan";
            this.DateIn.HeaderText = "NgayTiepNhan";
            this.DateIn.Name = "DateIn";
            this.DateIn.ReadOnly = true;
            this.DateIn.Visible = false;
            // 
            // NamSinh
            // 
            this.NamSinh.DataPropertyName = "Tuoi";
            this.NamSinh.HeaderText = "Năm sinh";
            this.NamSinh.Name = "NamSinh";
            this.NamSinh.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // MaTiepNhan
            // 
            this.MaTiepNhan.DataPropertyName = "MaTiepNhan";
            this.MaTiepNhan.HeaderText = "Mã tiếp nhận";
            this.MaTiepNhan.Name = "MaTiepNhan";
            this.MaTiepNhan.ReadOnly = true;
            this.MaTiepNhan.Visible = false;
            this.MaTiepNhan.Width = 130;
            // 
            // bvPatient
            // 
            this.bvPatient.AddNewItem = null;
            this.bvPatient.CountItem = this.toolStripLabel3;
            this.bvPatient.CountItemFormat = "/ {0}";
            this.bvPatient.DeleteItem = null;
            this.bvPatient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvPatient.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvPatient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnMFirst,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel3,
            this.toolStripSeparator3,
            this.btnMoveLast,
            this.btnRefreshChargeList});
            this.bvPatient.Location = new System.Drawing.Point(2, 130);
            this.bvPatient.MoveFirstItem = this.btnMFirst;
            this.bvPatient.MoveLastItem = this.btnMoveLast;
            this.bvPatient.MoveNextItem = null;
            this.bvPatient.MovePreviousItem = null;
            this.bvPatient.Name = "bvPatient";
            this.bvPatient.PositionItem = this.toolStripTextBox1;
            this.bvPatient.Size = new System.Drawing.Size(287, 25);
            this.bvPatient.TabIndex = 97;
            this.bvPatient.Text = "bindingNavigator1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel3.Text = "/ {0}";
            this.toolStripLabel3.ToolTipText = "Total number of items";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMFirst
            // 
            this.btnMFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnMFirst.Image")));
            this.btnMFirst.Name = "btnMFirst";
            this.btnMFirst.RightToLeftAutoMirrorImage = true;
            this.btnMFirst.Size = new System.Drawing.Size(23, 22);
            this.btnMFirst.Text = "Move first";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(26, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Current position";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveLast.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLast.Image")));
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.RightToLeftAutoMirrorImage = true;
            this.btnMoveLast.Size = new System.Drawing.Size(23, 22);
            this.btnMoveLast.Text = "Move last";
            // 
            // btnRefreshChargeList
            // 
            this.btnRefreshChargeList.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshChargeList.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshChargeList.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshChargeList.Image")));
            this.btnRefreshChargeList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshChargeList.Name = "btnRefreshChargeList";
            this.btnRefreshChargeList.Size = new System.Drawing.Size(78, 22);
            this.btnRefreshChargeList.Text = "Làm mới";
            this.btnRefreshChargeList.Click += new System.EventHandler(this.btnRefreshChargeList_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.txtFindIDBienLai);
            this.panel3.Controls.Add(this.radAllCharge);
            this.panel3.Controls.Add(this.radNotCharge);
            this.panel3.Controls.Add(this.radFinishCharge);
            this.panel3.Controls.Add(this.txtFindSEQ);
            this.panel3.Controls.Add(this.txtFindName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtpDateIn);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 23);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 107);
            this.panel3.TabIndex = 99;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(3, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 13);
            this.label24.TabIndex = 38;
            this.label24.Text = "Mã biên lai";
            // 
            // txtFindIDBienLai
            // 
            this.txtFindIDBienLai.Location = new System.Drawing.Point(91, 53);
            this.txtFindIDBienLai.Margin = new System.Windows.Forms.Padding(0);
            this.txtFindIDBienLai.Name = "txtFindIDBienLai";
            this.txtFindIDBienLai.Size = new System.Drawing.Size(187, 20);
            this.txtFindIDBienLai.TabIndex = 37;
            this.txtFindIDBienLai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindIDBienLai_KeyPress);
            // 
            // radAllCharge
            // 
            this.radAllCharge.AutoSize = true;
            this.radAllCharge.Location = new System.Drawing.Point(205, 81);
            this.radAllCharge.Margin = new System.Windows.Forms.Padding(0);
            this.radAllCharge.Name = "radAllCharge";
            this.radAllCharge.Size = new System.Drawing.Size(56, 17);
            this.radAllCharge.TabIndex = 34;
            this.radAllCharge.TabStop = true;
            this.radAllCharge.Text = "Tất cả";
            this.radAllCharge.UseVisualStyleBackColor = true;
            this.radAllCharge.CheckedChanged += new System.EventHandler(this.radAllCharge_CheckedChanged);
            // 
            // radNotCharge
            // 
            this.radNotCharge.AutoSize = true;
            this.radNotCharge.Location = new System.Drawing.Point(106, 81);
            this.radNotCharge.Margin = new System.Windows.Forms.Padding(0);
            this.radNotCharge.Name = "radNotCharge";
            this.radNotCharge.Size = new System.Drawing.Size(87, 17);
            this.radNotCharge.TabIndex = 33;
            this.radNotCharge.TabStop = true;
            this.radNotCharge.Text = "Chưa thu phí";
            this.radNotCharge.UseVisualStyleBackColor = true;
            this.radNotCharge.CheckedChanged += new System.EventHandler(this.radNotCharge_CheckedChanged);
            // 
            // radFinishCharge
            // 
            this.radFinishCharge.AutoSize = true;
            this.radFinishCharge.Location = new System.Drawing.Point(26, 81);
            this.radFinishCharge.Margin = new System.Windows.Forms.Padding(0);
            this.radFinishCharge.Name = "radFinishCharge";
            this.radFinishCharge.Size = new System.Drawing.Size(76, 17);
            this.radFinishCharge.TabIndex = 32;
            this.radFinishCharge.TabStop = true;
            this.radFinishCharge.Text = "Đã thu phí";
            this.radFinishCharge.UseVisualStyleBackColor = true;
            this.radFinishCharge.CheckedChanged += new System.EventHandler(this.radFinishCharge_CheckedChanged);
            // 
            // txtFindSEQ
            // 
            this.txtFindSEQ.Location = new System.Drawing.Point(216, 5);
            this.txtFindSEQ.Margin = new System.Windows.Forms.Padding(0);
            this.txtFindSEQ.Name = "txtFindSEQ";
            this.txtFindSEQ.Size = new System.Drawing.Size(63, 20);
            this.txtFindSEQ.TabIndex = 31;
            this.txtFindSEQ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindSEQ_KeyUp);
            // 
            // txtFindName
            // 
            this.txtFindName.Location = new System.Drawing.Point(91, 32);
            this.txtFindName.Margin = new System.Windows.Forms.Padding(0);
            this.txtFindName.Name = "txtFindName";
            this.txtFindName.Size = new System.Drawing.Size(187, 20);
            this.txtFindName.TabIndex = 30;
            this.txtFindName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindName_KeyUp);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Tìm tên";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(186, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "STT";
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(91, 5);
            this.dtpDateIn.Margin = new System.Windows.Forms.Padding(0);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(89, 21);
            this.dtpDateIn.TabIndex = 27;
            this.dtpDateIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDateIn_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày tiếp nhận";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupControl5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(293, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(889, 630);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabThuPhi);
            this.tabControl1.Controls.Add(this.tabBienLaiThuPhi);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(5, 126);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 502);
            this.tabControl1.TabIndex = 29;
            // 
            // tabThuPhi
            // 
            this.tabThuPhi.Controls.Add(this.groupControl4);
            this.tabThuPhi.Controls.Add(this.groupControl3);
            this.tabThuPhi.Location = new System.Drawing.Point(4, 22);
            this.tabThuPhi.Margin = new System.Windows.Forms.Padding(0);
            this.tabThuPhi.Name = "tabThuPhi";
            this.tabThuPhi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabThuPhi.Size = new System.Drawing.Size(874, 476);
            this.tabThuPhi.TabIndex = 0;
            this.tabThuPhi.Text = "Dịch vụ chỉ định";
            this.tabThuPhi.UseVisualStyleBackColor = true;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.ucChiTietChiDinh1);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(3, 2);
            this.groupControl4.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(658, 472);
            this.groupControl4.TabIndex = 30;
            this.groupControl4.Text = "Danh sách chỉ định";
            // 
            // ucChiTietChiDinh1
            // 
            this.ucChiTietChiDinh1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucChiTietChiDinh1.CoThuPhi = true;
            this.ucChiTietChiDinh1.CurrentMatiepNhan = null;
            this.ucChiTietChiDinh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChiTietChiDinh1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChiTietChiDinh1.HienThiChonChiDinh = true;
            this.ucChiTietChiDinh1.HienThiInBarcode = false;
            this.ucChiTietChiDinh1.HienThiKetQua = false;
            this.ucChiTietChiDinh1.HienThiXoaChiDinh = false;
            this.ucChiTietChiDinh1.Location = new System.Drawing.Point(2, 23);
            this.ucChiTietChiDinh1.Margin = new System.Windows.Forms.Padding(0);
            this.ucChiTietChiDinh1.MinimumSize = new System.Drawing.Size(257, 81);
            this.ucChiTietChiDinh1.Name = "ucChiTietChiDinh1";
            this.ucChiTietChiDinh1.Size = new System.Drawing.Size(654, 447);
            this.ucChiTietChiDinh1.TabIndex = 1;
            this.ucChiTietChiDinh1.TotalMoney = 0D;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.radCK_Per);
            this.groupControl3.Controls.Add(this.radCK_VND);
            this.groupControl3.Controls.Add(this.txtCK);
            this.groupControl3.Controls.Add(this.label26);
            this.groupControl3.Controls.Add(this.label20);
            this.groupControl3.Controls.Add(this.txtTongTien);
            this.groupControl3.Controls.Add(this.chkThuPhi_InTrucTiep);
            this.groupControl3.Controls.Add(this.btnTaoBienLai);
            this.groupControl3.Controls.Add(this.txtChuaThu);
            this.groupControl3.Controls.Add(this.chkUpdateChagreAuto);
            this.groupControl3.Controls.Add(this.label15);
            this.groupControl3.Controls.Add(this.txtDaThu);
            this.groupControl3.Controls.Add(this.label10);
            this.groupControl3.Controls.Add(this.label13);
            this.groupControl3.Controls.Add(this.cboUsersign);
            this.groupControl3.Controls.Add(this.txtSignName);
            this.groupControl3.Controls.Add(this.label11);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl3.Location = new System.Drawing.Point(661, 2);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(210, 472);
            this.groupControl3.TabIndex = 29;
            this.groupControl3.Text = "Chức năng ";
            // 
            // radCK_Per
            // 
            this.radCK_Per.AutoSize = true;
            this.radCK_Per.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radCK_Per.Location = new System.Drawing.Point(150, 115);
            this.radCK_Per.Name = "radCK_Per";
            this.radCK_Per.Size = new System.Drawing.Size(38, 17);
            this.radCK_Per.TabIndex = 151;
            this.radCK_Per.Text = "%";
            this.radCK_Per.UseVisualStyleBackColor = true;
            this.radCK_Per.CheckedChanged += new System.EventHandler(this.radCK_Per_CheckedChanged);
            // 
            // radCK_VND
            // 
            this.radCK_VND.AutoSize = true;
            this.radCK_VND.Checked = true;
            this.radCK_VND.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radCK_VND.Location = new System.Drawing.Point(87, 115);
            this.radCK_VND.Name = "radCK_VND";
            this.radCK_VND.Size = new System.Drawing.Size(47, 17);
            this.radCK_VND.TabIndex = 150;
            this.radCK_VND.TabStop = true;
            this.radCK_VND.Text = "VND";
            this.radCK_VND.UseVisualStyleBackColor = true;
            this.radCK_VND.CheckedChanged += new System.EventHandler(this.radCK_VND_CheckedChanged);
            // 
            // txtCK
            // 
            this.txtCK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCK.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCK.Location = new System.Drawing.Point(87, 86);
            this.txtCK.Name = "txtCK";
            this.txtCK.Size = new System.Drawing.Size(103, 23);
            this.txtCK.TabIndex = 149;
            this.txtCK.TextChanged += new System.EventHandler(this.txtCK_TextChanged);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(5, 91);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 13);
            this.label26.TabIndex = 148;
            this.label26.Text = "Chiết khấu";
            // 
            // label20
            // 
            this.label20.Appearance.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label20.Appearance.Options.UseFont = true;
            this.label20.Appearance.Options.UseForeColor = true;
            this.label20.Location = new System.Drawing.Point(87, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 15);
            this.label20.TabIndex = 143;
            this.label20.Text = "(Để trống => thu đủ)";
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.LightGray;
            this.txtTongTien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(87, 23);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(0);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(103, 23);
            this.txtTongTien.TabIndex = 137;
            // 
            // chkThuPhi_InTrucTiep
            // 
            this.chkThuPhi_InTrucTiep.AutoSize = true;
            this.chkThuPhi_InTrucTiep.Checked = true;
            this.chkThuPhi_InTrucTiep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThuPhi_InTrucTiep.Location = new System.Drawing.Point(30, 325);
            this.chkThuPhi_InTrucTiep.Margin = new System.Windows.Forms.Padding(0);
            this.chkThuPhi_InTrucTiep.Name = "chkThuPhi_InTrucTiep";
            this.chkThuPhi_InTrucTiep.Size = new System.Drawing.Size(76, 17);
            this.chkThuPhi_InTrucTiep.TabIndex = 142;
            this.chkThuPhi_InTrucTiep.Text = "In trực tiếp";
            this.chkThuPhi_InTrucTiep.UseVisualStyleBackColor = true;
            this.chkThuPhi_InTrucTiep.CheckedChanged += new System.EventHandler(this.chkThuPhi_InTrucTiep_CheckedChanged);
            // 
            // btnTaoBienLai
            // 
            this.btnTaoBienLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnTaoBienLai.BackColorHover = System.Drawing.Color.Empty;
            this.btnTaoBienLai.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnTaoBienLai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnTaoBienLai.BorderRadius = 5;
            this.btnTaoBienLai.BorderSize = 1;
            this.btnTaoBienLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoBienLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoBienLai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoBienLai.ForceColorHover = System.Drawing.Color.Empty;
            this.btnTaoBienLai.ForeColor = System.Drawing.Color.Black;
            this.btnTaoBienLai.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoBienLai.Image")));
            this.btnTaoBienLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoBienLai.Location = new System.Drawing.Point(48, 257);
            this.btnTaoBienLai.Margin = new System.Windows.Forms.Padding(0);
            this.btnTaoBienLai.Name = "btnTaoBienLai";
            this.btnTaoBienLai.Size = new System.Drawing.Size(115, 36);
            this.btnTaoBienLai.TabIndex = 25;
            this.btnTaoBienLai.Text = "&Tạo biên lai";
            this.btnTaoBienLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoBienLai.TextColor = System.Drawing.Color.Black;
            this.btnTaoBienLai.UseHightLight = true;
            this.btnTaoBienLai.UseVisualStyleBackColor = false;
            this.btnTaoBienLai.Click += new System.EventHandler(this.btnTaoBienLai_BienLai_Click);
            // 
            // txtChuaThu
            // 
            this.txtChuaThu.BackColor = System.Drawing.Color.LightGray;
            this.txtChuaThu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChuaThu.Location = new System.Drawing.Point(87, 134);
            this.txtChuaThu.Margin = new System.Windows.Forms.Padding(0);
            this.txtChuaThu.Name = "txtChuaThu";
            this.txtChuaThu.ReadOnly = true;
            this.txtChuaThu.Size = new System.Drawing.Size(103, 23);
            this.txtChuaThu.TabIndex = 141;
            // 
            // chkUpdateChagreAuto
            // 
            this.chkUpdateChagreAuto.AutoSize = true;
            this.chkUpdateChagreAuto.Checked = true;
            this.chkUpdateChagreAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateChagreAuto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkUpdateChagreAuto.Location = new System.Drawing.Point(30, 302);
            this.chkUpdateChagreAuto.Margin = new System.Windows.Forms.Padding(0);
            this.chkUpdateChagreAuto.Name = "chkUpdateChagreAuto";
            this.chkUpdateChagreAuto.Size = new System.Drawing.Size(148, 17);
            this.chkUpdateChagreAuto.TabIndex = 96;
            this.chkUpdateChagreAuto.Text = "Thu tiền khi in biên lai";
            this.chkUpdateChagreAuto.UseVisualStyleBackColor = true;
            this.chkUpdateChagreAuto.CheckedChanged += new System.EventHandler(this.chkUpdateChagreAuto_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(5, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 140;
            this.label15.Text = "Còn nợ";
            // 
            // txtDaThu
            // 
            this.txtDaThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDaThu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaThu.Location = new System.Drawing.Point(87, 44);
            this.txtDaThu.Margin = new System.Windows.Forms.Padding(0);
            this.txtDaThu.Name = "txtDaThu";
            this.txtDaThu.Size = new System.Drawing.Size(103, 23);
            this.txtDaThu.TabIndex = 139;
            this.txtDaThu.TextChanged += new System.EventHandler(this.txtDaThu_TextChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 133;
            this.label10.Text = "Thu ngân";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(5, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 138;
            this.label13.Text = "Thanh toán";
            // 
            // cboUsersign
            // 
            this.cboUsersign.AutoComplete = false;
            this.cboUsersign.AutoDropdown = true;
            this.cboUsersign.BackColorEven = System.Drawing.Color.White;
            this.cboUsersign.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboUsersign.ColumnNames = "MaNguoiDung, TenNhanVien";
            this.cboUsersign.ColumnWidthDefault = 75;
            this.cboUsersign.ColumnWidths = "30,215";
            this.cboUsersign.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboUsersign.DropDownWidth = 300;
            this.cboUsersign.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUsersign.FormattingEnabled = true;
            this.cboUsersign.LinkedColumnIndex = 0;
            this.cboUsersign.LinkedColumnIndex1 = 1;
            this.cboUsersign.LinkedColumnIndex2 = 0;
            this.cboUsersign.LinkedTextBox = null;
            this.cboUsersign.LinkedTextBox1 = this.txtSignName;
            this.cboUsersign.LinkedTextBox2 = null;
            this.cboUsersign.Location = new System.Drawing.Point(87, 161);
            this.cboUsersign.Margin = new System.Windows.Forms.Padding(0);
            this.cboUsersign.Name = "cboUsersign";
            this.cboUsersign.Size = new System.Drawing.Size(103, 24);
            this.cboUsersign.TabIndex = 134;
            // 
            // txtSignName
            // 
            this.txtSignName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtSignName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignName.Location = new System.Drawing.Point(5, 188);
            this.txtSignName.Margin = new System.Windows.Forms.Padding(0);
            this.txtSignName.Multiline = true;
            this.txtSignName.Name = "txtSignName";
            this.txtSignName.Size = new System.Drawing.Size(185, 21);
            this.txtSignName.TabIndex = 135;
            this.txtSignName.TabStop = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 136;
            this.label11.Text = "Tổng tiền";
            // 
            // tabBienLaiThuPhi
            // 
            this.tabBienLaiThuPhi.Controls.Add(this.groupControl2);
            this.tabBienLaiThuPhi.Controls.Add(this.groupControl6);
            this.tabBienLaiThuPhi.Controls.Add(this.groupControl1);
            this.tabBienLaiThuPhi.Location = new System.Drawing.Point(4, 22);
            this.tabBienLaiThuPhi.Margin = new System.Windows.Forms.Padding(0);
            this.tabBienLaiThuPhi.Name = "tabBienLaiThuPhi";
            this.tabBienLaiThuPhi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabBienLaiThuPhi.Size = new System.Drawing.Size(874, 476);
            this.tabBienLaiThuPhi.TabIndex = 1;
            this.tabBienLaiThuPhi.Text = "Biên lai thu phi";
            this.tabBienLaiThuPhi.UseVisualStyleBackColor = true;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gcChiTietBienLai);
            this.groupControl2.Controls.Add(this.bvChiTietBienLai);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 129);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(637, 345);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Chi tiết biên lai";
            // 
            // gcChiTietBienLai
            // 
            this.gcChiTietBienLai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChiTietBienLai.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcChiTietBienLai.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcChiTietBienLai.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcChiTietBienLai.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcChiTietBienLai.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcChiTietBienLai.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcChiTietBienLai.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcChiTietBienLai.Location = new System.Drawing.Point(2, 23);
            this.gcChiTietBienLai.MainView = this.gvChiTietBienlai;
            this.gcChiTietBienLai.Margin = new System.Windows.Forms.Padding(0);
            this.gcChiTietBienLai.Name = "gcChiTietBienLai";
            this.gcChiTietBienLai.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcChiTietBienLai.Size = new System.Drawing.Size(633, 295);
            this.gcChiTietBienLai.TabIndex = 1;
            this.gcChiTietBienLai.UseEmbeddedNavigator = true;
            this.gcChiTietBienLai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChiTietBienlai});
            // 
            // gvChiTietBienlai
            // 
            this.gvChiTietBienlai.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvChiTietBienlai.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvChiTietBienlai.Appearance.GroupRow.Options.UseFont = true;
            this.gvChiTietBienlai.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvChiTietBienlai.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChiTietnBl_Chon,
            this.colBienLai_TenPhanLoai,
            this.colBienLai_TenDichVu,
            this.colBienLai_Dongia,
            this.colBienLai_Soluong,
            this.colBienLai_ThanhTien,
            this.colBienLai_DaThuTien,
            this.colBienLai_DaHoanTien,
            this.colBienLai_MaTiepNhan,
            this.colBienLai_MaBienLai,
            this.colBienLai_MaPhanLoai,
            this.colBienLai_MaNhomDichVu,
            this.colBienLai_TenNhomDichVu,
            this.colBienLai_MaDichVu,
            this.colBienLai_DonViTinh,
            this.colBienLai_ThuTuInDichVu,
            this.colBienLai_ThuTuInNhom,
            this.colBienLai_PhanTramCK,
            this.colBienLai_ThucTra});
            this.gvChiTietBienlai.DetailHeight = 284;
            this.gvChiTietBienlai.GridControl = this.gcChiTietBienLai;
            this.gvChiTietBienlai.GroupCount = 2;
            this.gvChiTietBienlai.Name = "gvChiTietBienlai";
            this.gvChiTietBienlai.OptionsView.ColumnAutoWidth = false;
            this.gvChiTietBienlai.OptionsView.ShowGroupPanel = false;
            this.gvChiTietBienlai.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBienLai_TenPhanLoai, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBienLai_TenNhomDichVu, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBienLai_MaPhanLoai, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvChiTietBienlai.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvChiTietBienlai_CellValueChanged);
            // 
            // colChiTietnBl_Chon
            // 
            this.colChiTietnBl_Chon.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colChiTietnBl_Chon.FieldName = "chon";
            this.colChiTietnBl_Chon.MinWidth = 17;
            this.colChiTietnBl_Chon.Name = "colChiTietnBl_Chon";
            this.colChiTietnBl_Chon.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colChiTietnBl_Chon.Visible = true;
            this.colChiTietnBl_Chon.VisibleIndex = 0;
            this.colChiTietnBl_Chon.Width = 53;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colBienLai_TenPhanLoai
            // 
            this.colBienLai_TenPhanLoai.Caption = "Loại DV";
            this.colBienLai_TenPhanLoai.FieldName = "TenPhanLoai";
            this.colBienLai_TenPhanLoai.FieldNameSortGroup = "ThuTuInLoai";
            this.colBienLai_TenPhanLoai.MinWidth = 17;
            this.colBienLai_TenPhanLoai.Name = "colBienLai_TenPhanLoai";
            this.colBienLai_TenPhanLoai.OptionsColumn.AllowEdit = false;
            this.colBienLai_TenPhanLoai.Visible = true;
            this.colBienLai_TenPhanLoai.VisibleIndex = 7;
            this.colBienLai_TenPhanLoai.Width = 64;
            // 
            // colBienLai_TenDichVu
            // 
            this.colBienLai_TenDichVu.Caption = "Tên dịch vụ";
            this.colBienLai_TenDichVu.FieldName = "TenDichVu";
            this.colBienLai_TenDichVu.MinWidth = 17;
            this.colBienLai_TenDichVu.Name = "colBienLai_TenDichVu";
            this.colBienLai_TenDichVu.OptionsColumn.AllowEdit = false;
            this.colBienLai_TenDichVu.OptionsColumn.ReadOnly = true;
            this.colBienLai_TenDichVu.Visible = true;
            this.colBienLai_TenDichVu.VisibleIndex = 1;
            this.colBienLai_TenDichVu.Width = 279;
            // 
            // colBienLai_Dongia
            // 
            this.colBienLai_Dongia.Caption = "Đơn giá";
            this.colBienLai_Dongia.FieldName = "DonGia";
            this.colBienLai_Dongia.MinWidth = 17;
            this.colBienLai_Dongia.Name = "colBienLai_Dongia";
            this.colBienLai_Dongia.OptionsColumn.AllowEdit = false;
            this.colBienLai_Dongia.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colBienLai_Dongia.Visible = true;
            this.colBienLai_Dongia.VisibleIndex = 2;
            this.colBienLai_Dongia.Width = 102;
            // 
            // colBienLai_Soluong
            // 
            this.colBienLai_Soluong.Caption = "Số lượng";
            this.colBienLai_Soluong.FieldName = "SoLuong";
            this.colBienLai_Soluong.MinWidth = 17;
            this.colBienLai_Soluong.Name = "colBienLai_Soluong";
            this.colBienLai_Soluong.OptionsColumn.AllowEdit = false;
            this.colBienLai_Soluong.OptionsColumn.ReadOnly = true;
            this.colBienLai_Soluong.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colBienLai_Soluong.Visible = true;
            this.colBienLai_Soluong.VisibleIndex = 3;
            this.colBienLai_Soluong.Width = 55;
            // 
            // colBienLai_ThanhTien
            // 
            this.colBienLai_ThanhTien.Caption = "Tổng tiền";
            this.colBienLai_ThanhTien.FieldName = "ThanhTien";
            this.colBienLai_ThanhTien.MinWidth = 17;
            this.colBienLai_ThanhTien.Name = "colBienLai_ThanhTien";
            this.colBienLai_ThanhTien.OptionsColumn.AllowEdit = false;
            this.colBienLai_ThanhTien.OptionsColumn.ReadOnly = true;
            this.colBienLai_ThanhTien.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colBienLai_ThanhTien.Visible = true;
            this.colBienLai_ThanhTien.VisibleIndex = 4;
            this.colBienLai_ThanhTien.Width = 103;
            // 
            // colBienLai_DaThuTien
            // 
            this.colBienLai_DaThuTien.Caption = "Đã thu tiền";
            this.colBienLai_DaThuTien.FieldName = "DaThuTien";
            this.colBienLai_DaThuTien.MinWidth = 17;
            this.colBienLai_DaThuTien.Name = "colBienLai_DaThuTien";
            this.colBienLai_DaThuTien.OptionsColumn.AllowEdit = false;
            this.colBienLai_DaThuTien.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colBienLai_DaThuTien.Visible = true;
            this.colBienLai_DaThuTien.VisibleIndex = 7;
            this.colBienLai_DaThuTien.Width = 81;
            // 
            // colBienLai_DaHoanTien
            // 
            this.colBienLai_DaHoanTien.Caption = "Đã hoàn tiền";
            this.colBienLai_DaHoanTien.FieldName = "DaHoanTien";
            this.colBienLai_DaHoanTien.MinWidth = 17;
            this.colBienLai_DaHoanTien.Name = "colBienLai_DaHoanTien";
            this.colBienLai_DaHoanTien.OptionsColumn.AllowEdit = false;
            this.colBienLai_DaHoanTien.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colBienLai_DaHoanTien.Visible = true;
            this.colBienLai_DaHoanTien.VisibleIndex = 8;
            this.colBienLai_DaHoanTien.Width = 83;
            // 
            // colBienLai_MaTiepNhan
            // 
            this.colBienLai_MaTiepNhan.Caption = "Mã tiếp nhận";
            this.colBienLai_MaTiepNhan.FieldName = "MaTiepNhan";
            this.colBienLai_MaTiepNhan.MinWidth = 17;
            this.colBienLai_MaTiepNhan.Name = "colBienLai_MaTiepNhan";
            this.colBienLai_MaTiepNhan.OptionsColumn.ReadOnly = true;
            this.colBienLai_MaTiepNhan.Width = 93;
            // 
            // colBienLai_MaBienLai
            // 
            this.colBienLai_MaBienLai.Caption = " Mã biên lai";
            this.colBienLai_MaBienLai.FieldName = "ID";
            this.colBienLai_MaBienLai.MinWidth = 17;
            this.colBienLai_MaBienLai.Name = "colBienLai_MaBienLai";
            this.colBienLai_MaBienLai.OptionsColumn.ReadOnly = true;
            this.colBienLai_MaBienLai.Width = 93;
            // 
            // colBienLai_MaPhanLoai
            // 
            this.colBienLai_MaPhanLoai.Caption = "Mã phân loại";
            this.colBienLai_MaPhanLoai.FieldName = "MaPhanLoai";
            this.colBienLai_MaPhanLoai.MinWidth = 17;
            this.colBienLai_MaPhanLoai.Name = "colBienLai_MaPhanLoai";
            this.colBienLai_MaPhanLoai.OptionsColumn.AllowEdit = false;
            this.colBienLai_MaPhanLoai.OptionsColumn.ReadOnly = true;
            this.colBienLai_MaPhanLoai.Width = 64;
            // 
            // colBienLai_MaNhomDichVu
            // 
            this.colBienLai_MaNhomDichVu.Caption = "Mã nhóm dịch vụ";
            this.colBienLai_MaNhomDichVu.FieldName = "MaNhomDichVu";
            this.colBienLai_MaNhomDichVu.MinWidth = 17;
            this.colBienLai_MaNhomDichVu.Name = "colBienLai_MaNhomDichVu";
            this.colBienLai_MaNhomDichVu.Width = 64;
            // 
            // colBienLai_TenNhomDichVu
            // 
            this.colBienLai_TenNhomDichVu.Caption = "Nhóm";
            this.colBienLai_TenNhomDichVu.FieldName = "TenNhomDichVu";
            this.colBienLai_TenNhomDichVu.MinWidth = 17;
            this.colBienLai_TenNhomDichVu.Name = "colBienLai_TenNhomDichVu";
            this.colBienLai_TenNhomDichVu.Visible = true;
            this.colBienLai_TenNhomDichVu.VisibleIndex = 6;
            this.colBienLai_TenNhomDichVu.Width = 64;
            // 
            // colBienLai_MaDichVu
            // 
            this.colBienLai_MaDichVu.Caption = "Mã dịch vụ";
            this.colBienLai_MaDichVu.FieldName = "MaDichVu";
            this.colBienLai_MaDichVu.MinWidth = 17;
            this.colBienLai_MaDichVu.Name = "colBienLai_MaDichVu";
            this.colBienLai_MaDichVu.Width = 64;
            // 
            // colBienLai_DonViTinh
            // 
            this.colBienLai_DonViTinh.Caption = "Đơn vị tính";
            this.colBienLai_DonViTinh.FieldName = "DonViTinh";
            this.colBienLai_DonViTinh.MinWidth = 17;
            this.colBienLai_DonViTinh.Name = "colBienLai_DonViTinh";
            this.colBienLai_DonViTinh.Width = 64;
            // 
            // colBienLai_ThuTuInDichVu
            // 
            this.colBienLai_ThuTuInDichVu.Caption = "Thứ tự dịch vụ";
            this.colBienLai_ThuTuInDichVu.FieldName = "ThuTuInDichVu";
            this.colBienLai_ThuTuInDichVu.MinWidth = 17;
            this.colBienLai_ThuTuInDichVu.Name = "colBienLai_ThuTuInDichVu";
            this.colBienLai_ThuTuInDichVu.Width = 64;
            // 
            // colBienLai_ThuTuInNhom
            // 
            this.colBienLai_ThuTuInNhom.Caption = "Thứ tự in nhóm";
            this.colBienLai_ThuTuInNhom.FieldName = "ThuTuInNhom";
            this.colBienLai_ThuTuInNhom.MinWidth = 17;
            this.colBienLai_ThuTuInNhom.Name = "colBienLai_ThuTuInNhom";
            this.colBienLai_ThuTuInNhom.Width = 64;
            // 
            // colBienLai_PhanTramCK
            // 
            this.colBienLai_PhanTramCK.Caption = "Phần trăm chiết khấu";
            this.colBienLai_PhanTramCK.FieldName = "PhanTramChietKhau";
            this.colBienLai_PhanTramCK.Name = "colBienLai_PhanTramCK";
            this.colBienLai_PhanTramCK.UnboundDataType = typeof(decimal);
            this.colBienLai_PhanTramCK.Visible = true;
            this.colBienLai_PhanTramCK.VisibleIndex = 5;
            this.colBienLai_PhanTramCK.Width = 111;
            // 
            // colBienLai_ThucTra
            // 
            this.colBienLai_ThucTra.Caption = "Thực trả";
            this.colBienLai_ThucTra.FieldName = "ThucTraXN";
            this.colBienLai_ThucTra.Name = "colBienLai_ThucTra";
            this.colBienLai_ThucTra.UnboundDataType = typeof(decimal);
            this.colBienLai_ThucTra.Visible = true;
            this.colBienLai_ThucTra.VisibleIndex = 6;
            // 
            // bvChiTietBienLai
            // 
            this.bvChiTietBienLai.AddNewItem = null;
            this.bvChiTietBienLai.CountItem = this.bindingNavigatorCountItem;
            this.bvChiTietBienLai.CountItemFormat = "/ {0}";
            this.bvChiTietBienLai.DeleteItem = null;
            this.bvChiTietBienLai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvChiTietBienLai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvChiTietBienLai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bntChonThuTien,
            this.bntChonHoanTien});
            this.bvChiTietBienLai.Location = new System.Drawing.Point(2, 318);
            this.bvChiTietBienLai.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvChiTietBienLai.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvChiTietBienLai.MoveNextItem = null;
            this.bvChiTietBienLai.MovePreviousItem = null;
            this.bvChiTietBienLai.Name = "bvChiTietBienLai";
            this.bvChiTietBienLai.PositionItem = this.bindingNavigatorPositionItem;
            this.bvChiTietBienLai.Size = new System.Drawing.Size(633, 25);
            this.bvChiTietBienLai.TabIndex = 2;
            this.bvChiTietBienLai.Text = "customBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(43, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bntChonThuTien
            // 
            this.bntChonThuTien.Image = global::TPH.LIS.App.Properties.Resources.tick_octagon;
            this.bntChonThuTien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntChonThuTien.Name = "bntChonThuTien";
            this.bntChonThuTien.Size = new System.Drawing.Size(101, 22);
            this.bntChonThuTien.Text = "Chọn thu tiền";
            this.bntChonThuTien.Click += new System.EventHandler(this.bntChonThuTien_Click);
            // 
            // bntChonHoanTien
            // 
            this.bntChonHoanTien.Image = global::TPH.LIS.App.Properties.Resources.check_white_16x16;
            this.bntChonHoanTien.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntChonHoanTien.Name = "bntChonHoanTien";
            this.bntChonHoanTien.Size = new System.Drawing.Size(111, 22);
            this.bntChonHoanTien.Text = "Chọn hoàn tiền";
            this.bntChonHoanTien.Click += new System.EventHandler(this.bntChonHoanTien_Click);
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.txtTotalReturnCount);
            this.groupControl6.Controls.Add(this.label23);
            this.groupControl6.Controls.Add(this.panel4);
            this.groupControl6.Controls.Add(this.label22);
            this.groupControl6.Controls.Add(this.cboThuNganHoantien);
            this.groupControl6.Controls.Add(this.TxtThuNganHoantien);
            this.groupControl6.Controls.Add(this.btnHoanTien);
            this.groupControl6.Controls.Add(this.label16);
            this.groupControl6.Controls.Add(this.btnCapNhatThanhToan);
            this.groupControl6.Controls.Add(this.chkBienLai_BatThuTien);
            this.groupControl6.Controls.Add(this.btnDaThuTien);
            this.groupControl6.Controls.Add(this.txtTongTien_BienLai);
            this.groupControl6.Controls.Add(this.chkBienLai_inTrucTiep);
            this.groupControl6.Controls.Add(this.btnInBienLai_BienLai);
            this.groupControl6.Controls.Add(this.txtConNo_BienLai);
            this.groupControl6.Controls.Add(this.label17);
            this.groupControl6.Controls.Add(this.txtThanhToan_BienLai);
            this.groupControl6.Controls.Add(this.label18);
            this.groupControl6.Controls.Add(this.label19);
            this.groupControl6.Controls.Add(this.cboThuNgan2);
            this.groupControl6.Controls.Add(this.txtThuNgan2);
            this.groupControl6.Controls.Add(this.label21);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl6.Location = new System.Drawing.Point(640, 129);
            this.groupControl6.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(231, 345);
            this.groupControl6.TabIndex = 30;
            this.groupControl6.Text = "Chức năng ";
            // 
            // txtTotalReturnCount
            // 
            this.txtTotalReturnCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTotalReturnCount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReturnCount.Location = new System.Drawing.Point(101, 274);
            this.txtTotalReturnCount.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalReturnCount.Name = "txtTotalReturnCount";
            this.txtTotalReturnCount.Size = new System.Drawing.Size(125, 23);
            this.txtTotalReturnCount.TabIndex = 153;
            this.txtTotalReturnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label23.Appearance.Options.UseFont = true;
            this.label23.Location = new System.Drawing.Point(9, 279);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 13);
            this.label23.TabIndex = 152;
            this.label23.Text = "Tiền hoàn";
            // 
            // panel4
            // 
            this.panel4.Appearance.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel4.Appearance.Options.UseBackColor = true;
            this.panel4.Location = new System.Drawing.Point(5, 236);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 2);
            this.panel4.TabIndex = 151;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(9, 308);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 148;
            this.label22.Text = "Thu ngân";
            // 
            // cboThuNganHoantien
            // 
            this.cboThuNganHoantien.AutoComplete = false;
            this.cboThuNganHoantien.AutoDropdown = true;
            this.cboThuNganHoantien.BackColorEven = System.Drawing.Color.White;
            this.cboThuNganHoantien.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboThuNganHoantien.ColumnNames = "MaNguoiDung, TenNhanVien";
            this.cboThuNganHoantien.ColumnWidthDefault = 75;
            this.cboThuNganHoantien.ColumnWidths = "30,215";
            this.cboThuNganHoantien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboThuNganHoantien.DropDownWidth = 300;
            this.cboThuNganHoantien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThuNganHoantien.FormattingEnabled = true;
            this.cboThuNganHoantien.LinkedColumnIndex = 0;
            this.cboThuNganHoantien.LinkedColumnIndex1 = 1;
            this.cboThuNganHoantien.LinkedColumnIndex2 = 0;
            this.cboThuNganHoantien.LinkedTextBox = null;
            this.cboThuNganHoantien.LinkedTextBox1 = this.TxtThuNganHoantien;
            this.cboThuNganHoantien.LinkedTextBox2 = null;
            this.cboThuNganHoantien.Location = new System.Drawing.Point(65, 303);
            this.cboThuNganHoantien.Margin = new System.Windows.Forms.Padding(0);
            this.cboThuNganHoantien.Name = "cboThuNganHoantien";
            this.cboThuNganHoantien.Size = new System.Drawing.Size(35, 24);
            this.cboThuNganHoantien.TabIndex = 149;
            // 
            // TxtThuNganHoantien
            // 
            this.TxtThuNganHoantien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.TxtThuNganHoantien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtThuNganHoantien.Enabled = false;
            this.TxtThuNganHoantien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtThuNganHoantien.Location = new System.Drawing.Point(102, 303);
            this.TxtThuNganHoantien.Margin = new System.Windows.Forms.Padding(0);
            this.TxtThuNganHoantien.Multiline = true;
            this.TxtThuNganHoantien.Name = "TxtThuNganHoantien";
            this.TxtThuNganHoantien.Size = new System.Drawing.Size(132, 23);
            this.TxtThuNganHoantien.TabIndex = 150;
            this.TxtThuNganHoantien.TabStop = false;
            // 
            // btnHoanTien
            // 
            this.btnHoanTien.BackColor = System.Drawing.Color.Transparent;
            this.btnHoanTien.BackColorHover = System.Drawing.Color.Empty;
            this.btnHoanTien.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnHoanTien.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHoanTien.BorderRadius = 5;
            this.btnHoanTien.BorderSize = 0;
            this.btnHoanTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoanTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoanTien.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanTien.ForceColorHover = System.Drawing.Color.Empty;
            this.btnHoanTien.ForeColor = System.Drawing.Color.Black;
            this.btnHoanTien.Image = ((System.Drawing.Image)(resources.GetObject("btnHoanTien.Image")));
            this.btnHoanTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoanTien.Location = new System.Drawing.Point(7, 239);
            this.btnHoanTien.Margin = new System.Windows.Forms.Padding(0);
            this.btnHoanTien.Name = "btnHoanTien";
            this.btnHoanTien.Size = new System.Drawing.Size(100, 29);
            this.btnHoanTien.TabIndex = 147;
            this.btnHoanTien.Text = "Hoàn tiền";
            this.btnHoanTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoanTien.TextColor = System.Drawing.Color.Black;
            this.btnHoanTien.UseHightLight = true;
            this.btnHoanTien.UseVisualStyleBackColor = false;
            this.btnHoanTien.Click += new System.EventHandler(this.btnHoanTien_Click);
            // 
            // label16
            // 
            this.label16.Appearance.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label16.Appearance.Options.UseFont = true;
            this.label16.Appearance.Options.UseForeColor = true;
            this.label16.Location = new System.Drawing.Point(61, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 15);
            this.label16.TabIndex = 146;
            this.label16.Text = "(Để trống => thu đủ)";
            // 
            // btnCapNhatThanhToan
            // 
            this.btnCapNhatThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCapNhatThanhToan.BackColorHover = System.Drawing.Color.Empty;
            this.btnCapNhatThanhToan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCapNhatThanhToan.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapNhatThanhToan.BorderRadius = 5;
            this.btnCapNhatThanhToan.BorderSize = 0;
            this.btnCapNhatThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhatThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatThanhToan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatThanhToan.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCapNhatThanhToan.ForeColor = System.Drawing.Color.Red;
            this.btnCapNhatThanhToan.Image = global::TPH.LIS.App.Properties.Resources.Save;
            this.btnCapNhatThanhToan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhatThanhToan.Location = new System.Drawing.Point(77, 111);
            this.btnCapNhatThanhToan.Margin = new System.Windows.Forms.Padding(0);
            this.btnCapNhatThanhToan.Name = "btnCapNhatThanhToan";
            this.btnCapNhatThanhToan.Size = new System.Drawing.Size(155, 25);
            this.btnCapNhatThanhToan.TabIndex = 145;
            this.btnCapNhatThanhToan.Text = "Cập nhật thanh toán";
            this.btnCapNhatThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhatThanhToan.TextColor = System.Drawing.Color.Red;
            this.btnCapNhatThanhToan.UseHightLight = true;
            this.btnCapNhatThanhToan.UseVisualStyleBackColor = false;
            this.btnCapNhatThanhToan.Click += new System.EventHandler(this.btnCapNhatThanhToan_Click);
            // 
            // chkBienLai_BatThuTien
            // 
            this.chkBienLai_BatThuTien.AutoSize = true;
            this.chkBienLai_BatThuTien.Checked = true;
            this.chkBienLai_BatThuTien.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBienLai_BatThuTien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkBienLai_BatThuTien.Location = new System.Drawing.Point(122, 216);
            this.chkBienLai_BatThuTien.Margin = new System.Windows.Forms.Padding(0);
            this.chkBienLai_BatThuTien.Name = "chkBienLai_BatThuTien";
            this.chkBienLai_BatThuTien.Size = new System.Drawing.Size(105, 17);
            this.chkBienLai_BatThuTien.TabIndex = 144;
            this.chkBienLai_BatThuTien.Text = "Thu tiền khi in";
            this.chkBienLai_BatThuTien.UseVisualStyleBackColor = true;
            // 
            // btnDaThuTien
            // 
            this.btnDaThuTien.BackColor = System.Drawing.Color.Transparent;
            this.btnDaThuTien.BackColorHover = System.Drawing.Color.Empty;
            this.btnDaThuTien.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDaThuTien.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDaThuTien.BorderRadius = 5;
            this.btnDaThuTien.BorderSize = 0;
            this.btnDaThuTien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDaThuTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaThuTien.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaThuTien.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDaThuTien.ForeColor = System.Drawing.Color.Black;
            this.btnDaThuTien.Image = ((System.Drawing.Image)(resources.GetObject("btnDaThuTien.Image")));
            this.btnDaThuTien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaThuTien.Location = new System.Drawing.Point(122, 189);
            this.btnDaThuTien.Margin = new System.Windows.Forms.Padding(0);
            this.btnDaThuTien.Name = "btnDaThuTien";
            this.btnDaThuTien.Size = new System.Drawing.Size(108, 23);
            this.btnDaThuTien.TabIndex = 142;
            this.btnDaThuTien.Text = "Đã thu tiền";
            this.btnDaThuTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDaThuTien.TextColor = System.Drawing.Color.Black;
            this.btnDaThuTien.UseHightLight = true;
            this.btnDaThuTien.UseVisualStyleBackColor = false;
            this.btnDaThuTien.Click += new System.EventHandler(this.btnDaThuTien_Click);
            // 
            // txtTongTien_BienLai
            // 
            this.txtTongTien_BienLai.BackColor = System.Drawing.Color.LightGray;
            this.txtTongTien_BienLai.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien_BienLai.Location = new System.Drawing.Point(75, 24);
            this.txtTongTien_BienLai.Margin = new System.Windows.Forms.Padding(0);
            this.txtTongTien_BienLai.Name = "txtTongTien_BienLai";
            this.txtTongTien_BienLai.ReadOnly = true;
            this.txtTongTien_BienLai.Size = new System.Drawing.Size(157, 23);
            this.txtTongTien_BienLai.TabIndex = 137;
            this.txtTongTien_BienLai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkBienLai_inTrucTiep
            // 
            this.chkBienLai_inTrucTiep.AutoSize = true;
            this.chkBienLai_inTrucTiep.Checked = true;
            this.chkBienLai_inTrucTiep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBienLai_inTrucTiep.Location = new System.Drawing.Point(20, 216);
            this.chkBienLai_inTrucTiep.Margin = new System.Windows.Forms.Padding(0);
            this.chkBienLai_inTrucTiep.Name = "chkBienLai_inTrucTiep";
            this.chkBienLai_inTrucTiep.Size = new System.Drawing.Size(76, 17);
            this.chkBienLai_inTrucTiep.TabIndex = 142;
            this.chkBienLai_inTrucTiep.Text = "In trực tiếp";
            this.chkBienLai_inTrucTiep.UseVisualStyleBackColor = true;
            // 
            // btnInBienLai_BienLai
            // 
            this.btnInBienLai_BienLai.BackColor = System.Drawing.Color.Transparent;
            this.btnInBienLai_BienLai.BackColorHover = System.Drawing.Color.Empty;
            this.btnInBienLai_BienLai.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnInBienLai_BienLai.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInBienLai_BienLai.BorderRadius = 5;
            this.btnInBienLai_BienLai.BorderSize = 0;
            this.btnInBienLai_BienLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInBienLai_BienLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBienLai_BienLai.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBienLai_BienLai.ForceColorHover = System.Drawing.Color.Empty;
            this.btnInBienLai_BienLai.ForeColor = System.Drawing.Color.Black;
            this.btnInBienLai_BienLai.Image = ((System.Drawing.Image)(resources.GetObject("btnInBienLai_BienLai.Image")));
            this.btnInBienLai_BienLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInBienLai_BienLai.Location = new System.Drawing.Point(7, 189);
            this.btnInBienLai_BienLai.Margin = new System.Windows.Forms.Padding(0);
            this.btnInBienLai_BienLai.Name = "btnInBienLai_BienLai";
            this.btnInBienLai_BienLai.Size = new System.Drawing.Size(100, 23);
            this.btnInBienLai_BienLai.TabIndex = 25;
            this.btnInBienLai_BienLai.Text = "In &biên lai";
            this.btnInBienLai_BienLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInBienLai_BienLai.TextColor = System.Drawing.Color.Black;
            this.btnInBienLai_BienLai.UseHightLight = true;
            this.btnInBienLai_BienLai.UseVisualStyleBackColor = false;
            this.btnInBienLai_BienLai.Click += new System.EventHandler(this.btnInBienLai_BienLai_Click);
            // 
            // txtConNo_BienLai
            // 
            this.txtConNo_BienLai.BackColor = System.Drawing.Color.LightGray;
            this.txtConNo_BienLai.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConNo_BienLai.Location = new System.Drawing.Point(63, 86);
            this.txtConNo_BienLai.Margin = new System.Windows.Forms.Padding(0);
            this.txtConNo_BienLai.Name = "txtConNo_BienLai";
            this.txtConNo_BienLai.ReadOnly = true;
            this.txtConNo_BienLai.Size = new System.Drawing.Size(169, 23);
            this.txtConNo_BienLai.TabIndex = 141;
            this.txtConNo_BienLai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(7, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 140;
            this.label17.Text = "Còn nợ";
            // 
            // txtThanhToan_BienLai
            // 
            this.txtThanhToan_BienLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtThanhToan_BienLai.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhToan_BienLai.Location = new System.Drawing.Point(75, 45);
            this.txtThanhToan_BienLai.Margin = new System.Windows.Forms.Padding(0);
            this.txtThanhToan_BienLai.Name = "txtThanhToan_BienLai";
            this.txtThanhToan_BienLai.Size = new System.Drawing.Size(157, 23);
            this.txtThanhToan_BienLai.TabIndex = 139;
            this.txtThanhToan_BienLai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtThanhToan_BienLai.Click += new System.EventHandler(this.txtThanhToan_BienLai_Click);
            this.txtThanhToan_BienLai.TextChanged += new System.EventHandler(this.txtThanhToan_BienLai_TextChanged);
            this.txtThanhToan_BienLai.Enter += new System.EventHandler(this.txtThanhToan_BienLai_Enter);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(7, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 133;
            this.label18.Text = "Thu ngân";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(7, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 138;
            this.label19.Text = "Thanh toán";
            // 
            // cboThuNgan2
            // 
            this.cboThuNgan2.AutoComplete = false;
            this.cboThuNgan2.AutoDropdown = true;
            this.cboThuNgan2.BackColorEven = System.Drawing.Color.White;
            this.cboThuNgan2.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboThuNgan2.ColumnNames = "MaNguoiDung, TenNhanVien";
            this.cboThuNgan2.ColumnWidthDefault = 75;
            this.cboThuNgan2.ColumnWidths = "30,215";
            this.cboThuNgan2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboThuNgan2.DropDownWidth = 300;
            this.cboThuNgan2.Enabled = false;
            this.cboThuNgan2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThuNgan2.FormattingEnabled = true;
            this.cboThuNgan2.LinkedColumnIndex = 0;
            this.cboThuNgan2.LinkedColumnIndex1 = 1;
            this.cboThuNgan2.LinkedColumnIndex2 = 0;
            this.cboThuNgan2.LinkedTextBox = null;
            this.cboThuNgan2.LinkedTextBox1 = this.txtThuNgan2;
            this.cboThuNgan2.LinkedTextBox2 = null;
            this.cboThuNgan2.Location = new System.Drawing.Point(63, 140);
            this.cboThuNgan2.Margin = new System.Windows.Forms.Padding(0);
            this.cboThuNgan2.Name = "cboThuNgan2";
            this.cboThuNgan2.Size = new System.Drawing.Size(169, 24);
            this.cboThuNgan2.TabIndex = 134;
            // 
            // txtThuNgan2
            // 
            this.txtThuNgan2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtThuNgan2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThuNgan2.Enabled = false;
            this.txtThuNgan2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThuNgan2.Location = new System.Drawing.Point(9, 165);
            this.txtThuNgan2.Margin = new System.Windows.Forms.Padding(0);
            this.txtThuNgan2.Multiline = true;
            this.txtThuNgan2.Name = "txtThuNgan2";
            this.txtThuNgan2.Size = new System.Drawing.Size(222, 21);
            this.txtThuNgan2.TabIndex = 135;
            this.txtThuNgan2.TabStop = false;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(7, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 13);
            this.label21.TabIndex = 136;
            this.label21.Text = "Tổng tiền";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcBienLai);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(3, 2);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(868, 127);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách biên lai";
            // 
            // gcBienLai
            // 
            this.gcBienLai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBienLai.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcBienLai.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcBienLai.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcBienLai.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcBienLai.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcBienLai.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.gcBienLai.EmbeddedNavigator.TextStringFormat = "Dòng {0} / {1}";
            this.gcBienLai.Location = new System.Drawing.Point(2, 23);
            this.gcBienLai.MainView = this.gvBienLai;
            this.gcBienLai.Margin = new System.Windows.Forms.Padding(0);
            this.gcBienLai.Name = "gcBienLai";
            this.gcBienLai.Size = new System.Drawing.Size(864, 102);
            this.gcBienLai.TabIndex = 0;
            this.gcBienLai.UseEmbeddedNavigator = true;
            this.gcBienLai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBienLai});
            // 
            // gvBienLai
            // 
            this.gvBienLai.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvBienLai.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvBienLai.Appearance.GroupRow.Options.UseFont = true;
            this.gvBienLai.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvBienLai.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBienLaiMaTiepNhan,
            this.colBienLaiMaBienLai,
            this.colBienLaiTongTien,
            this.colBienLaiThanhToan,
            this.colBienLaiConLai,
            this.colBienLaiNgayThannhToan,
            this.colBienLaiThuNgan,
            this.colBienLaiMayTinh,
            this.colBienLaiNguoiThucHien,
            this.colBienLaiHinhThucThanhToan,
            this.colBienLaiThaoTac,
            this.colBienLaiTenThaoTac,
            this.colBienLaiSEQ,
            this.colBienLaiNgayTiepNhan});
            this.gvBienLai.DetailHeight = 284;
            this.gvBienLai.GridControl = this.gcBienLai;
            this.gvBienLai.GroupCount = 1;
            this.gvBienLai.Name = "gvBienLai";
            this.gvBienLai.OptionsView.ColumnAutoWidth = false;
            this.gvBienLai.OptionsView.ShowGroupPanel = false;
            this.gvBienLai.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBienLaiTenThaoTac, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvBienLai.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvBienLai_FocusedRowChanged);
            this.gvBienLai.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.gvBienLai_FocusedRowObjectChanged);
            // 
            // colBienLaiMaTiepNhan
            // 
            this.colBienLaiMaTiepNhan.Caption = "Mã tiếp nhận";
            this.colBienLaiMaTiepNhan.FieldName = "MaTiepNhan";
            this.colBienLaiMaTiepNhan.MinWidth = 17;
            this.colBienLaiMaTiepNhan.Name = "colBienLaiMaTiepNhan";
            this.colBienLaiMaTiepNhan.OptionsColumn.ReadOnly = true;
            this.colBienLaiMaTiepNhan.Visible = true;
            this.colBienLaiMaTiepNhan.VisibleIndex = 1;
            this.colBienLaiMaTiepNhan.Width = 93;
            // 
            // colBienLaiMaBienLai
            // 
            this.colBienLaiMaBienLai.Caption = " Mã biên lai";
            this.colBienLaiMaBienLai.FieldName = "ID";
            this.colBienLaiMaBienLai.MinWidth = 17;
            this.colBienLaiMaBienLai.Name = "colBienLaiMaBienLai";
            this.colBienLaiMaBienLai.OptionsColumn.ReadOnly = true;
            this.colBienLaiMaBienLai.Visible = true;
            this.colBienLaiMaBienLai.VisibleIndex = 0;
            this.colBienLaiMaBienLai.Width = 93;
            // 
            // colBienLaiTongTien
            // 
            this.colBienLaiTongTien.Caption = "Tổng tiền";
            this.colBienLaiTongTien.FieldName = "TongTien";
            this.colBienLaiTongTien.MinWidth = 17;
            this.colBienLaiTongTien.Name = "colBienLaiTongTien";
            this.colBienLaiTongTien.OptionsColumn.AllowEdit = false;
            this.colBienLaiTongTien.OptionsColumn.ReadOnly = true;
            this.colBienLaiTongTien.Visible = true;
            this.colBienLaiTongTien.VisibleIndex = 2;
            this.colBienLaiTongTien.Width = 81;
            // 
            // colBienLaiThanhToan
            // 
            this.colBienLaiThanhToan.Caption = "Thanh toán";
            this.colBienLaiThanhToan.FieldName = "ThanhToan";
            this.colBienLaiThanhToan.MinWidth = 17;
            this.colBienLaiThanhToan.Name = "colBienLaiThanhToan";
            this.colBienLaiThanhToan.OptionsColumn.AllowEdit = false;
            this.colBienLaiThanhToan.OptionsColumn.ReadOnly = true;
            this.colBienLaiThanhToan.Visible = true;
            this.colBienLaiThanhToan.VisibleIndex = 3;
            this.colBienLaiThanhToan.Width = 77;
            // 
            // colBienLaiConLai
            // 
            this.colBienLaiConLai.Caption = "Còn lại";
            this.colBienLaiConLai.FieldName = "ConLai";
            this.colBienLaiConLai.MinWidth = 17;
            this.colBienLaiConLai.Name = "colBienLaiConLai";
            this.colBienLaiConLai.OptionsColumn.AllowEdit = false;
            this.colBienLaiConLai.OptionsColumn.ReadOnly = true;
            this.colBienLaiConLai.Visible = true;
            this.colBienLaiConLai.VisibleIndex = 4;
            this.colBienLaiConLai.Width = 66;
            // 
            // colBienLaiNgayThannhToan
            // 
            this.colBienLaiNgayThannhToan.Caption = "Ngày tạo";
            this.colBienLaiNgayThannhToan.FieldName = "NgayThanhToan";
            this.colBienLaiNgayThannhToan.MinWidth = 17;
            this.colBienLaiNgayThannhToan.Name = "colBienLaiNgayThannhToan";
            this.colBienLaiNgayThannhToan.OptionsColumn.AllowEdit = false;
            this.colBienLaiNgayThannhToan.OptionsColumn.ReadOnly = true;
            this.colBienLaiNgayThannhToan.Visible = true;
            this.colBienLaiNgayThannhToan.VisibleIndex = 5;
            this.colBienLaiNgayThannhToan.Width = 89;
            // 
            // colBienLaiThuNgan
            // 
            this.colBienLaiThuNgan.Caption = "Thu ngân";
            this.colBienLaiThuNgan.FieldName = "ThuNgan";
            this.colBienLaiThuNgan.MinWidth = 17;
            this.colBienLaiThuNgan.Name = "colBienLaiThuNgan";
            this.colBienLaiThuNgan.OptionsColumn.AllowEdit = false;
            this.colBienLaiThuNgan.OptionsColumn.ReadOnly = true;
            this.colBienLaiThuNgan.Visible = true;
            this.colBienLaiThuNgan.VisibleIndex = 6;
            this.colBienLaiThuNgan.Width = 80;
            // 
            // colBienLaiMayTinh
            // 
            this.colBienLaiMayTinh.Caption = "Máy thu phí";
            this.colBienLaiMayTinh.FieldName = "MayTinh";
            this.colBienLaiMayTinh.MinWidth = 17;
            this.colBienLaiMayTinh.Name = "colBienLaiMayTinh";
            this.colBienLaiMayTinh.OptionsColumn.AllowEdit = false;
            this.colBienLaiMayTinh.OptionsColumn.ReadOnly = true;
            this.colBienLaiMayTinh.Visible = true;
            this.colBienLaiMayTinh.VisibleIndex = 7;
            this.colBienLaiMayTinh.Width = 77;
            // 
            // colBienLaiNguoiThucHien
            // 
            this.colBienLaiNguoiThucHien.Caption = "Người thực hiện";
            this.colBienLaiNguoiThucHien.FieldName = "NguoiTao";
            this.colBienLaiNguoiThucHien.MinWidth = 17;
            this.colBienLaiNguoiThucHien.Name = "colBienLaiNguoiThucHien";
            this.colBienLaiNguoiThucHien.OptionsColumn.AllowEdit = false;
            this.colBienLaiNguoiThucHien.OptionsColumn.ReadOnly = true;
            this.colBienLaiNguoiThucHien.Visible = true;
            this.colBienLaiNguoiThucHien.VisibleIndex = 8;
            this.colBienLaiNguoiThucHien.Width = 91;
            // 
            // colBienLaiHinhThucThanhToan
            // 
            this.colBienLaiHinhThucThanhToan.Caption = "Hình thức thanh toán";
            this.colBienLaiHinhThucThanhToan.FieldName = "HinhThucThanhToan";
            this.colBienLaiHinhThucThanhToan.MinWidth = 17;
            this.colBienLaiHinhThucThanhToan.Name = "colBienLaiHinhThucThanhToan";
            this.colBienLaiHinhThucThanhToan.OptionsColumn.AllowEdit = false;
            this.colBienLaiHinhThucThanhToan.OptionsColumn.ReadOnly = true;
            this.colBienLaiHinhThucThanhToan.Width = 103;
            // 
            // colBienLaiThaoTac
            // 
            this.colBienLaiThaoTac.Caption = "Loại biên lai";
            this.colBienLaiThaoTac.FieldName = "ThaoTac";
            this.colBienLaiThaoTac.MinWidth = 17;
            this.colBienLaiThaoTac.Name = "colBienLaiThaoTac";
            this.colBienLaiThaoTac.OptionsColumn.AllowEdit = false;
            this.colBienLaiThaoTac.OptionsColumn.ReadOnly = true;
            this.colBienLaiThaoTac.Width = 74;
            // 
            // colBienLaiTenThaoTac
            // 
            this.colBienLaiTenThaoTac.Caption = "Loại: ";
            this.colBienLaiTenThaoTac.FieldName = "TenThaoTac";
            this.colBienLaiTenThaoTac.MinWidth = 17;
            this.colBienLaiTenThaoTac.Name = "colBienLaiTenThaoTac";
            this.colBienLaiTenThaoTac.OptionsColumn.AllowEdit = false;
            this.colBienLaiTenThaoTac.OptionsColumn.ReadOnly = true;
            this.colBienLaiTenThaoTac.Visible = true;
            this.colBienLaiTenThaoTac.VisibleIndex = 11;
            this.colBienLaiTenThaoTac.Width = 64;
            // 
            // colBienLaiSEQ
            // 
            this.colBienLaiSEQ.Caption = "gridColumn1";
            this.colBienLaiSEQ.FieldName = "barcode";
            this.colBienLaiSEQ.Name = "colBienLaiSEQ";
            this.colBienLaiSEQ.Visible = true;
            this.colBienLaiSEQ.VisibleIndex = 9;
            // 
            // colBienLaiNgayTiepNhan
            // 
            this.colBienLaiNgayTiepNhan.Caption = "gridColumn1";
            this.colBienLaiNgayTiepNhan.FieldName = "NgayTiepNhan";
            this.colBienLaiNgayTiepNhan.Name = "colBienLaiNgayTiepNhan";
            this.colBienLaiNgayTiepNhan.Visible = true;
            this.colBienLaiNgayTiepNhan.VisibleIndex = 10;
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Arial", 8.75F);
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.Controls.Add(this.txtDoiTuong);
            this.groupControl5.Controls.Add(this.txtMaTiepNhan);
            this.groupControl5.Controls.Add(this.label9);
            this.groupControl5.Controls.Add(this.label12);
            this.groupControl5.Controls.Add(this.txtBSChiDinh);
            this.groupControl5.Controls.Add(this.txtAddress);
            this.groupControl5.Controls.Add(this.label8);
            this.groupControl5.Controls.Add(this.txtSex);
            this.groupControl5.Controls.Add(this.lblSex);
            this.groupControl5.Controls.Add(this.label7);
            this.groupControl5.Controls.Add(this.label14);
            this.groupControl5.Controls.Add(this.label25);
            this.groupControl5.Controls.Add(this.label6);
            this.groupControl5.Controls.Add(this.txtTenBN);
            this.groupControl5.Controls.Add(this.txtEmail);
            this.groupControl5.Controls.Add(this.label4);
            this.groupControl5.Controls.Add(this.txtChanDoan);
            this.groupControl5.Controls.Add(this.dtpBirthday);
            this.groupControl5.Controls.Add(this.txtPhone);
            this.groupControl5.Controls.Add(this.label5);
            this.groupControl5.Controls.Add(this.chkAgeType);
            this.groupControl5.Controls.Add(this.txtAge);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl5.Location = new System.Drawing.Point(5, 2);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(882, 124);
            this.groupControl5.TabIndex = 30;
            this.groupControl5.Text = "Thông tin khách hàng";
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoiTuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtDoiTuong.Location = new System.Drawing.Point(430, 76);
            this.txtDoiTuong.Margin = new System.Windows.Forms.Padding(0);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.ReadOnly = true;
            this.txtDoiTuong.Size = new System.Drawing.Size(445, 20);
            this.txtDoiTuong.TabIndex = 133;
            // 
            // txtMaTiepNhan
            // 
            this.txtMaTiepNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtMaTiepNhan.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTiepNhan.Location = new System.Drawing.Point(48, 26);
            this.txtMaTiepNhan.Margin = new System.Windows.Forms.Padding(0);
            this.txtMaTiepNhan.Name = "txtMaTiepNhan";
            this.txtMaTiepNhan.Size = new System.Drawing.Size(75, 23);
            this.txtMaTiepNhan.TabIndex = 128;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(369, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 132;
            this.label9.Text = "Đối tượng";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(718, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 123;
            this.label12.Text = "Giới tính";
            // 
            // txtBSChiDinh
            // 
            this.txtBSChiDinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBSChiDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtBSChiDinh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBSChiDinh.Location = new System.Drawing.Point(346, 98);
            this.txtBSChiDinh.Margin = new System.Windows.Forms.Padding(0);
            this.txtBSChiDinh.Name = "txtBSChiDinh";
            this.txtBSChiDinh.ReadOnly = true;
            this.txtBSChiDinh.Size = new System.Drawing.Size(529, 23);
            this.txtBSChiDinh.TabIndex = 131;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtAddress.Location = new System.Drawing.Point(430, 51);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(445, 20);
            this.txtAddress.TabIndex = 115;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(284, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 130;
            this.label8.Text = "BS/Nơi gửi";
            // 
            // txtSex
            // 
            this.txtSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtSex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSex.Location = new System.Drawing.Point(767, 27);
            this.txtSex.Margin = new System.Windows.Forms.Padding(0);
            this.txtSex.MaxLength = 1;
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(43, 20);
            this.txtSex.TabIndex = 124;
            // 
            // lblSex
            // 
            this.lblSex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSex.Location = new System.Drawing.Point(815, 26);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(0, 13);
            this.lblSex.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(369, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "Địa chỉ";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 125;
            this.label14.Text = "Chẩn đoán";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(7, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 13);
            this.label25.TabIndex = 127;
            this.label25.Text = "Mã TN";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 118;
            this.label6.Text = "Email";
            // 
            // txtTenBN
            // 
            this.txtTenBN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenBN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTenBN.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBN.ForeColor = System.Drawing.Color.Black;
            this.txtTenBN.Location = new System.Drawing.Point(200, 26);
            this.txtTenBN.Margin = new System.Windows.Forms.Padding(0);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.Size = new System.Drawing.Size(513, 23);
            this.txtTenBN.TabIndex = 113;
            this.txtTenBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtEmail.Location = new System.Drawing.Point(47, 99);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(132, 20);
            this.txtEmail.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(129, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Họ và tên";
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtChanDoan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChanDoan.Location = new System.Drawing.Point(74, 76);
            this.txtChanDoan.Margin = new System.Windows.Forms.Padding(0);
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.ReadOnly = true;
            this.txtChanDoan.Size = new System.Drawing.Size(291, 21);
            this.txtChanDoan.TabIndex = 126;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CalendarFont = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthday.Checked = false;
            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Enabled = false;
            this.dtpBirthday.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(200, 50);
            this.dtpBirthday.Margin = new System.Windows.Forms.Padding(0);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(115, 23);
            this.dtpBirthday.TabIndex = 121;
            this.dtpBirthday.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtPhone.Location = new System.Drawing.Point(183, 99);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(0);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(97, 20);
            this.txtPhone.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Năm sinh";
            // 
            // chkAgeType
            // 
            this.chkAgeType.AutoSize = true;
            this.chkAgeType.Enabled = false;
            this.chkAgeType.Location = new System.Drawing.Point(129, 53);
            this.chkAgeType.Margin = new System.Windows.Forms.Padding(0);
            this.chkAgeType.Name = "chkAgeType";
            this.chkAgeType.Size = new System.Drawing.Size(73, 17);
            this.chkAgeType.TabIndex = 122;
            this.chkAgeType.Text = "Ngày sinh";
            this.chkAgeType.UseVisualStyleBackColor = true;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtAge.Location = new System.Drawing.Point(74, 51);
            this.txtAge.Margin = new System.Windows.Forms.Padding(0);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(51, 20);
            this.txtAge.TabIndex = 117;
            // 
            // listPrinterCharge
            // 
            this.listPrinterCharge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listPrinterCharge.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPrinterCharge.FormattingEnabled = true;
            this.listPrinterCharge.HorizontalScrollbar = true;
            this.listPrinterCharge.ItemHeight = 14;
            this.listPrinterCharge.Location = new System.Drawing.Point(2, 554);
            this.listPrinterCharge.Margin = new System.Windows.Forms.Padding(0);
            this.listPrinterCharge.Name = "listPrinterCharge";
            this.listPrinterCharge.Size = new System.Drawing.Size(287, 74);
            this.listPrinterCharge.TabIndex = 97;
            this.listPrinterCharge.SelectedIndexChanged += new System.EventHandler(this.listPrinterCharge_SelectedIndexChanged);
            // 
            // groupControl7
            // 
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Arial", 8.75F);
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.Controls.Add(this.dtgPatient);
            this.groupControl7.Controls.Add(this.listPrinterCharge);
            this.groupControl7.Controls.Add(this.bvPatient);
            this.groupControl7.Controls.Add(this.panel3);
            this.groupControl7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl7.Location = new System.Drawing.Point(2, 2);
            this.groupControl7.Margin = new System.Windows.Forms.Padding(0);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(291, 630);
            this.groupControl7.TabIndex = 2;
            this.groupControl7.Text = "Danh sách khách hàng";
            // 
            // FrmThuPhiDichVu_bk
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FrmThuPhiDichVu_bk";
            this.Text = "Thu phí dịch vụ";
            this.Load += new System.EventHandler(this.FrmThuPhiDichVu_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatient)).EndInit();
            this.bvPatient.ResumeLayout(false);
            this.bvPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabThuPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.tabBienLaiThuPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTietBienLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTietBienlai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiTietBienLai)).EndInit();
            this.bvChiTietBienLai.ResumeLayout(false);
            this.bvChiTietBienLai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBienLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBienLai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panel1;
        private CustomBindingNavigator bvPatient;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnRefreshChargeList;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnMFirst;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnMoveLast;
        private CustomDatagridView dtgPatient;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTiepNhan;
        private DevExpress.XtraEditors.PanelControl panel3;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.RadioButton radAllCharge;
        private System.Windows.Forms.RadioButton radNotCharge;
        private System.Windows.Forms.RadioButton radFinishCharge;
        private System.Windows.Forms.TextBox txtFindSEQ;
        private System.Windows.Forms.TextBox txtFindName;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private System.Windows.Forms.TextBox txtMaTiepNhan;
        private DevExpress.XtraEditors.LabelControl label25;
        private System.Windows.Forms.TextBox txtTenBN;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private DevExpress.XtraEditors.LabelControl label5;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.CheckBox chkAgeType;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.TextBox txtEmail;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.LabelControl label14;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtSex;
        private System.Windows.Forms.TextBox txtAddress;
        private DevExpress.XtraEditors.LabelControl label12;
        private System.Windows.Forms.TextBox txtDoiTuong;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.TextBox txtBSChiDinh;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.ListBox listPrinterCharge;
        private System.Windows.Forms.CheckBox chkUpdateChagreAuto;
        private TPH.Controls.TPHNormalButton btnTaoBienLai;
        private DevExpress.XtraEditors.LabelControl label10;
        private System.Windows.Forms.TextBox txtSignName;
        private CustomComboBox cboUsersign;
        private System.Windows.Forms.TextBox txtChuaThu;
        private DevExpress.XtraEditors.LabelControl label15;
        private System.Windows.Forms.TextBox txtDaThu;
        private DevExpress.XtraEditors.LabelControl label13;
        private System.Windows.Forms.TextBox txtTongTien;
        private DevExpress.XtraEditors.LabelControl label11;
        private AppCode.ucChiTietChiDinh ucChiTietChiDinh1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabThuPhi;
        private System.Windows.Forms.TabPage tabBienLaiThuPhi;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.CheckBox chkThuPhi_InTrucTiep;
        private DevExpress.XtraEditors.LabelControl label20;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private TPH.Controls.TPHNormalButton btnDaThuTien;
        private System.Windows.Forms.TextBox txtTongTien_BienLai;
        private System.Windows.Forms.CheckBox chkBienLai_inTrucTiep;
        private TPH.Controls.TPHNormalButton btnInBienLai_BienLai;
        private System.Windows.Forms.TextBox txtConNo_BienLai;
        private DevExpress.XtraEditors.LabelControl label17;
        private System.Windows.Forms.TextBox txtThanhToan_BienLai;
        private DevExpress.XtraEditors.LabelControl label18;
        private DevExpress.XtraEditors.LabelControl label19;
        private CustomComboBox cboThuNgan2;
        private System.Windows.Forms.TextBox txtThuNgan2;
        private DevExpress.XtraEditors.LabelControl label21;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gcChiTietBienLai;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChiTietBienlai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_TenPhanLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_TenDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_Dongia;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_Soluong;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_ThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_DaThuTien;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_DaHoanTien;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_MaTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_MaBienLai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_MaPhanLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_MaNhomDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_TenNhomDichVu;
        private System.Windows.Forms.CheckBox chkBienLai_BatThuTien;
        private TPH.Controls.TPHNormalButton btnCapNhatThanhToan;
        private DevExpress.XtraEditors.LabelControl label16;
        private DevExpress.XtraGrid.Columns.GridColumn colChiTietnBl_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_MaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_DonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_ThuTuInDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_ThuTuInNhom;
        private CustomBindingNavigator bvChiTietBienLai;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bntChonHoanTien;
        private System.Windows.Forms.ToolStripButton bntChonThuTien;
        private TPH.Controls.TPHNormalButton btnHoanTien;
        private DevExpress.XtraEditors.PanelControl panel4;
        private DevExpress.XtraEditors.LabelControl label22;
        private CustomComboBox cboThuNganHoantien;
        private System.Windows.Forms.TextBox TxtThuNganHoantien;
        private System.Windows.Forms.TextBox txtTotalReturnCount;
        private DevExpress.XtraEditors.LabelControl label23;
        private System.Windows.Forms.RadioButton radCK_Per;
        private System.Windows.Forms.RadioButton radCK_VND;
        private System.Windows.Forms.TextBox txtCK;
        private DevExpress.XtraEditors.LabelControl label26;
        private DevExpress.XtraGrid.GridControl gcBienLai;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBienLai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiMaTiepNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiMaBienLai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiTongTien;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiConLai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiNgayThannhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiThuNgan;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiMayTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiNguoiThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiHinhThucThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiThaoTac;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiTenThaoTac;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_PhanTramCK;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLai_ThucTra;
        private DevExpress.XtraEditors.LabelControl label24;
        private System.Windows.Forms.TextBox txtFindIDBienLai;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiSEQ;
        private DevExpress.XtraGrid.Columns.GridColumn colBienLaiNgayTiepNhan;
    }
}