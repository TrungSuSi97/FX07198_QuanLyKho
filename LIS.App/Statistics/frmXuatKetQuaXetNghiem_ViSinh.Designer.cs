using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThongKe
{
    partial class frmXuatKetQuaXetNghiem_ViSinh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Báo cáo kháng sinh (WHONet)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Báo cáo kháng sinh (BYT)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Báo cáo tổng hợp vi sinh");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Xuất thông tin bệnh phẩm");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Xuất phiếu tiến trình vi sinh");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("KẾT QUẢ XÉT NGHIỆM", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatKetQuaXetNghiem_ViSinh));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.ucLoaiMau = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.ucLoai = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.ucDoiTuong = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.chkNotresult = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radTGInKQDauTien = new System.Windows.Forms.RadioButton();
            this.radTGNhapBN = new System.Windows.Forms.RadioButton();
            this.ucMayXetNghiem = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.ucProfile = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.ucDSXetNghiem = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.chkChiXNDaXacNhan = new System.Windows.Forms.CheckBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label20 = new DevExpress.XtraEditors.LabelControl();
            this.label19 = new DevExpress.XtraEditors.LabelControl();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.label18 = new DevExpress.XtraEditors.LabelControl();
            this.cboNhanVienXacNhan = new TPH.LIS.Common.Controls.CustomComboBox();
            this.chkChiCoKetQua = new System.Windows.Forms.CheckBox();
            this.cboBSChiDinh = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.label28 = new DevExpress.XtraEditors.LabelControl();
            this.cboBoPhanXN = new TPH.LIS.Common.Controls.CustomComboBox();
            this.cboKhuDieuTri = new TPH.LIS.Common.Controls.CustomComboBox();
            this.cboDonvi = new TPH.LIS.Common.Controls.CustomComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radXNChiSo = new System.Windows.Forms.RadioButton();
            this.radXNDichVu = new System.Windows.Forms.RadioButton();
            this.radTatCaLoaiXN = new System.Windows.Forms.RadioButton();
            this.cboKhuVuc = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.cboNhomCLS = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.ucGroupHeader2 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treLoaiThongKe = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeaderTabHeader = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(207, 22);
            this.lblTitle.Text = "XUẤT BÁO CÁO KẾT QUẢ (Vi sinh)";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.splitContainer2);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Location = new System.Drawing.Point(0, 0);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Size = new System.Drawing.Size(1008, 661);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(4, 10, 4, 2);
            this.pnLabel.Size = new System.Drawing.Size(1008, 0);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Yellow;
            this.btnClose.BackgroundColor = System.Drawing.Color.Yellow;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(622, 10);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(651, 10);
            this.lblMainESC.Size = new System.Drawing.Size(353, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1008, 0);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(130)))), ((int)(((byte)(167)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1008, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(209, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 0);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(900, 1);
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ucLoaiMau);
            this.panel1.Controls.Add(this.ucLoai);
            this.panel1.Controls.Add(this.ucDoiTuong);
            this.panel1.Controls.Add(this.chkNotresult);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.ucMayXetNghiem);
            this.panel1.Controls.Add(this.ucProfile);
            this.panel1.Controls.Add(this.ucDSXetNghiem);
            this.panel1.Controls.Add(this.chkChiXNDaXacNhan);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtKetQua);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.cboNhanVienXacNhan);
            this.panel1.Controls.Add(this.chkChiCoKetQua);
            this.panel1.Controls.Add(this.cboBSChiDinh);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.cboBoPhanXN);
            this.panel1.Controls.Add(this.cboKhuDieuTri);
            this.panel1.Controls.Add(this.cboDonvi);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtProfile);
            this.panel1.Controls.Add(this.cboNhomCLS);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ucGroupHeader2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 186);
            this.panel1.TabIndex = 0;
            // 
            // ucLoaiMau
            // 
            this.ucLoaiMau.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucLoaiMau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLoaiMau.DataSource = null;
            this.ucLoaiMau.DisplayMember = "";
            this.ucLoaiMau.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLoaiMau.IsCheckedAll = true;
            this.ucLoaiMau.ListCaption = "Loại mẫu";
            this.ucLoaiMau.Location = new System.Drawing.Point(1041, 27);
            this.ucLoaiMau.Margin = new System.Windows.Forms.Padding(4);
            this.ucLoaiMau.Name = "ucLoaiMau";
            this.ucLoaiMau.Size = new System.Drawing.Size(211, 139);
            this.ucLoaiMau.TabIndex = 71;
            this.ucLoaiMau.ValueMember = "";
            // 
            // ucLoai
            // 
            this.ucLoai.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucLoai.DataSource = null;
            this.ucLoai.DisplayMember = "";
            this.ucLoai.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLoai.IsCheckedAll = true;
            this.ucLoai.ListCaption = "Loài";
            this.ucLoai.Location = new System.Drawing.Point(826, 27);
            this.ucLoai.Margin = new System.Windows.Forms.Padding(4);
            this.ucLoai.Name = "ucLoai";
            this.ucLoai.Size = new System.Drawing.Size(211, 139);
            this.ucLoai.TabIndex = 70;
            this.ucLoai.ValueMember = "";
            // 
            // ucDoiTuong
            // 
            this.ucDoiTuong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDoiTuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDoiTuong.DataSource = null;
            this.ucDoiTuong.DisplayMember = "";
            this.ucDoiTuong.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDoiTuong.IsCheckedAll = true;
            this.ucDoiTuong.ListCaption = "Đối tượng";
            this.ucDoiTuong.Location = new System.Drawing.Point(1256, 27);
            this.ucDoiTuong.Margin = new System.Windows.Forms.Padding(4);
            this.ucDoiTuong.Name = "ucDoiTuong";
            this.ucDoiTuong.Size = new System.Drawing.Size(211, 139);
            this.ucDoiTuong.TabIndex = 67;
            this.ucDoiTuong.ValueMember = "";
            // 
            // chkNotresult
            // 
            this.chkNotresult.AutoSize = true;
            this.chkNotresult.Location = new System.Drawing.Point(478, 117);
            this.chkNotresult.Name = "chkNotresult";
            this.chkNotresult.Size = new System.Drawing.Size(154, 19);
            this.chkNotresult.TabIndex = 65;
            this.chkNotresult.Text = "Chỉ XN chưa có kết quả";
            this.chkNotresult.UseVisualStyleBackColor = true;
            this.chkNotresult.CheckedChanged += new System.EventHandler(this.chkNotresult_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.radTGInKQDauTien);
            this.groupBox2.Controls.Add(this.radTGNhapBN);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 49);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thời gian";
            // 
            // radTGInKQDauTien
            // 
            this.radTGInKQDauTien.AutoSize = true;
            this.radTGInKQDauTien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTGInKQDauTien.Location = new System.Drawing.Point(125, 22);
            this.radTGInKQDauTien.Name = "radTGInKQDauTien";
            this.radTGInKQDauTien.Size = new System.Drawing.Size(87, 20);
            this.radTGInKQDauTien.TabIndex = 2;
            this.radTGInKQDauTien.Text = "TG in KQ";
            this.radTGInKQDauTien.UseVisualStyleBackColor = true;
            // 
            // radTGNhapBN
            // 
            this.radTGNhapBN.AutoSize = true;
            this.radTGNhapBN.Checked = true;
            this.radTGNhapBN.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTGNhapBN.ForeColor = System.Drawing.Color.Maroon;
            this.radTGNhapBN.Location = new System.Drawing.Point(6, 22);
            this.radTGNhapBN.Name = "radTGNhapBN";
            this.radTGNhapBN.Size = new System.Drawing.Size(108, 20);
            this.radTGNhapBN.TabIndex = 1;
            this.radTGNhapBN.TabStop = true;
            this.radTGNhapBN.Text = "TG nhập BN";
            this.radTGNhapBN.UseVisualStyleBackColor = true;
            // 
            // ucMayXetNghiem
            // 
            this.ucMayXetNghiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucMayXetNghiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucMayXetNghiem.DataSource = null;
            this.ucMayXetNghiem.DisplayMember = "";
            this.ucMayXetNghiem.IsCheckedAll = true;
            this.ucMayXetNghiem.ListCaption = "Máy xét nghiệm";
            this.ucMayXetNghiem.Location = new System.Drawing.Point(1907, 27);
            this.ucMayXetNghiem.Name = "ucMayXetNghiem";
            this.ucMayXetNghiem.Size = new System.Drawing.Size(211, 139);
            this.ucMayXetNghiem.TabIndex = 60;
            this.ucMayXetNghiem.ValueMember = "";
            // 
            // ucProfile
            // 
            this.ucProfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucProfile.DataSource = null;
            this.ucProfile.DisplayMember = "";
            this.ucProfile.IsCheckedAll = true;
            this.ucProfile.ListCaption = "Profile";
            this.ucProfile.Location = new System.Drawing.Point(1690, 27);
            this.ucProfile.Name = "ucProfile";
            this.ucProfile.Size = new System.Drawing.Size(211, 139);
            this.ucProfile.TabIndex = 59;
            this.ucProfile.ValueMember = "";
            // 
            // ucDSXetNghiem
            // 
            this.ucDSXetNghiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDSXetNghiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDSXetNghiem.DataSource = null;
            this.ucDSXetNghiem.DisplayMember = "";
            this.ucDSXetNghiem.IsCheckedAll = true;
            this.ucDSXetNghiem.ListCaption = "Xét nghiệm";
            this.ucDSXetNghiem.Location = new System.Drawing.Point(1473, 27);
            this.ucDSXetNghiem.Name = "ucDSXetNghiem";
            this.ucDSXetNghiem.Size = new System.Drawing.Size(211, 139);
            this.ucDSXetNghiem.TabIndex = 58;
            this.ucDSXetNghiem.ValueMember = "";
            // 
            // chkChiXNDaXacNhan
            // 
            this.chkChiXNDaXacNhan.AutoSize = true;
            this.chkChiXNDaXacNhan.ForeColor = System.Drawing.Color.Black;
            this.chkChiXNDaXacNhan.Location = new System.Drawing.Point(478, 143);
            this.chkChiXNDaXacNhan.Name = "chkChiXNDaXacNhan";
            this.chkChiXNDaXacNhan.Size = new System.Drawing.Size(133, 19);
            this.chkChiXNDaXacNhan.TabIndex = 57;
            this.chkChiXNDaXacNhan.Text = "Chỉ XN đã xác nhận";
            this.chkChiXNDaXacNhan.UseVisualStyleBackColor = false;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(542, 58);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(110, 21);
            this.txtGhiChu.TabIndex = 56;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(478, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 15);
            this.label20.TabIndex = 55;
            this.label20.Text = "Ghi chú";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(478, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 15);
            this.label19.TabIndex = 54;
            this.label19.Text = "Kết quả";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(542, 30);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(110, 21);
            this.txtKetQua.TabIndex = 53;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(239, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 15);
            this.label18.TabIndex = 52;
            this.label18.Text = "Người xác nhận";
            // 
            // cboNhanVienXacNhan
            // 
            this.cboNhanVienXacNhan.AutoComplete = false;
            this.cboNhanVienXacNhan.AutoDropdown = false;
            this.cboNhanVienXacNhan.BackColorEven = System.Drawing.Color.White;
            this.cboNhanVienXacNhan.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhanVienXacNhan.ColumnNames = "MaNhanVien, TenNhanVien";
            this.cboNhanVienXacNhan.ColumnWidthDefault = 75;
            this.cboNhanVienXacNhan.ColumnWidths = "75,150";
            this.cboNhanVienXacNhan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhanVienXacNhan.FormattingEnabled = true;
            this.cboNhanVienXacNhan.LinkedColumnIndex = 0;
            this.cboNhanVienXacNhan.LinkedColumnIndex1 = 0;
            this.cboNhanVienXacNhan.LinkedColumnIndex2 = 0;
            this.cboNhanVienXacNhan.LinkedTextBox = null;
            this.cboNhanVienXacNhan.LinkedTextBox1 = null;
            this.cboNhanVienXacNhan.LinkedTextBox2 = null;
            this.cboNhanVienXacNhan.Location = new System.Drawing.Point(351, 113);
            this.cboNhanVienXacNhan.Name = "cboNhanVienXacNhan";
            this.cboNhanVienXacNhan.Size = new System.Drawing.Size(120, 22);
            this.cboNhanVienXacNhan.TabIndex = 7;
            this.cboNhanVienXacNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhanVienThucHien_KeyPress);
            // 
            // chkChiCoKetQua
            // 
            this.chkChiCoKetQua.AutoSize = true;
            this.chkChiCoKetQua.Location = new System.Drawing.Point(478, 88);
            this.chkChiCoKetQua.Name = "chkChiCoKetQua";
            this.chkChiCoKetQua.Size = new System.Drawing.Size(140, 19);
            this.chkChiCoKetQua.TabIndex = 51;
            this.chkChiCoKetQua.Text = "Chỉ XN đã có kết quả";
            this.chkChiCoKetQua.UseVisualStyleBackColor = true;
            this.chkChiCoKetQua.CheckedChanged += new System.EventHandler(this.chkChiCoKetQua_CheckedChanged);
            // 
            // cboBSChiDinh
            // 
            this.cboBSChiDinh.AutoComplete = false;
            this.cboBSChiDinh.AutoDropdown = false;
            this.cboBSChiDinh.BackColorEven = System.Drawing.Color.White;
            this.cboBSChiDinh.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboBSChiDinh.ColumnNames = "MaNhanVien, TenNhanVien";
            this.cboBSChiDinh.ColumnWidthDefault = 75;
            this.cboBSChiDinh.ColumnWidths = "75,150";
            this.cboBSChiDinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBSChiDinh.FormattingEnabled = true;
            this.cboBSChiDinh.LinkedColumnIndex = 0;
            this.cboBSChiDinh.LinkedColumnIndex1 = 0;
            this.cboBSChiDinh.LinkedColumnIndex2 = 0;
            this.cboBSChiDinh.LinkedTextBox = null;
            this.cboBSChiDinh.LinkedTextBox1 = null;
            this.cboBSChiDinh.LinkedTextBox2 = null;
            this.cboBSChiDinh.Location = new System.Drawing.Point(351, 85);
            this.cboBSChiDinh.Name = "cboBSChiDinh";
            this.cboBSChiDinh.Size = new System.Drawing.Size(120, 22);
            this.cboBSChiDinh.TabIndex = 5;
            this.cboBSChiDinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhanVien_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 46;
            this.label15.Text = "Nhóm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(239, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 15);
            this.label13.TabIndex = 46;
            this.label13.Text = "Khu điều trị";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(239, 61);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(74, 15);
            this.label28.TabIndex = 46;
            this.label28.Text = "Khoa phòng";
            // 
            // cboBoPhanXN
            // 
            this.cboBoPhanXN.AutoComplete = false;
            this.cboBoPhanXN.AutoDropdown = false;
            this.cboBoPhanXN.BackColorEven = System.Drawing.Color.White;
            this.cboBoPhanXN.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboBoPhanXN.ColumnNames = "";
            this.cboBoPhanXN.ColumnWidthDefault = 75;
            this.cboBoPhanXN.ColumnWidths = "";
            this.cboBoPhanXN.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBoPhanXN.FormattingEnabled = true;
            this.cboBoPhanXN.LinkedColumnIndex = 0;
            this.cboBoPhanXN.LinkedColumnIndex1 = 1;
            this.cboBoPhanXN.LinkedColumnIndex2 = 0;
            this.cboBoPhanXN.LinkedTextBox = null;
            this.cboBoPhanXN.LinkedTextBox1 = null;
            this.cboBoPhanXN.LinkedTextBox2 = null;
            this.cboBoPhanXN.Location = new System.Drawing.Point(351, 141);
            this.cboBoPhanXN.Name = "cboBoPhanXN";
            this.cboBoPhanXN.Size = new System.Drawing.Size(121, 22);
            this.cboBoPhanXN.TabIndex = 45;
            this.cboBoPhanXN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBoPhanXN_KeyPress);
            // 
            // cboKhuDieuTri
            // 
            this.cboKhuDieuTri.AutoComplete = false;
            this.cboKhuDieuTri.AutoDropdown = false;
            this.cboKhuDieuTri.BackColorEven = System.Drawing.Color.White;
            this.cboKhuDieuTri.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboKhuDieuTri.ColumnNames = "";
            this.cboKhuDieuTri.ColumnWidthDefault = 75;
            this.cboKhuDieuTri.ColumnWidths = "";
            this.cboKhuDieuTri.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboKhuDieuTri.FormattingEnabled = true;
            this.cboKhuDieuTri.LinkedColumnIndex = 0;
            this.cboKhuDieuTri.LinkedColumnIndex1 = 1;
            this.cboKhuDieuTri.LinkedColumnIndex2 = 0;
            this.cboKhuDieuTri.LinkedTextBox = null;
            this.cboKhuDieuTri.LinkedTextBox1 = null;
            this.cboKhuDieuTri.LinkedTextBox2 = null;
            this.cboKhuDieuTri.Location = new System.Drawing.Point(351, 30);
            this.cboKhuDieuTri.Name = "cboKhuDieuTri";
            this.cboKhuDieuTri.Size = new System.Drawing.Size(120, 22);
            this.cboKhuDieuTri.TabIndex = 45;
            this.cboKhuDieuTri.SelectedIndexChanged += new System.EventHandler(this.cboKhuDieuTri_SelectedIndexChanged);
            this.cboKhuDieuTri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboKhuDieuTri_KeyPress);
            // 
            // cboDonvi
            // 
            this.cboDonvi.AutoComplete = false;
            this.cboDonvi.AutoDropdown = false;
            this.cboDonvi.BackColorEven = System.Drawing.Color.White;
            this.cboDonvi.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDonvi.ColumnNames = "";
            this.cboDonvi.ColumnWidthDefault = 75;
            this.cboDonvi.ColumnWidths = "";
            this.cboDonvi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDonvi.FormattingEnabled = true;
            this.cboDonvi.LinkedColumnIndex = 0;
            this.cboDonvi.LinkedColumnIndex1 = 1;
            this.cboDonvi.LinkedColumnIndex2 = 0;
            this.cboDonvi.LinkedTextBox = null;
            this.cboDonvi.LinkedTextBox1 = null;
            this.cboDonvi.LinkedTextBox2 = null;
            this.cboDonvi.Location = new System.Drawing.Point(351, 58);
            this.cboDonvi.Name = "cboDonvi";
            this.cboDonvi.Size = new System.Drawing.Size(120, 22);
            this.cboDonvi.TabIndex = 45;
            this.cboDonvi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDonvi_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radXNChiSo);
            this.groupBox1.Controls.Add(this.radXNDichVu);
            this.groupBox1.Controls.Add(this.radTatCaLoaiXN);
            this.groupBox1.Controls.Add(this.cboKhuVuc);
            this.groupBox1.Location = new System.Drawing.Point(655, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 109);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // radXNChiSo
            // 
            this.radXNChiSo.AutoSize = true;
            this.radXNChiSo.Location = new System.Drawing.Point(6, 80);
            this.radXNChiSo.Name = "radXNChiSo";
            this.radXNChiSo.Size = new System.Drawing.Size(123, 19);
            this.radXNChiSo.TabIndex = 2;
            this.radXNChiSo.Text = "Xét nghiệm chỉ số";
            this.radXNChiSo.UseVisualStyleBackColor = true;
            // 
            // radXNDichVu
            // 
            this.radXNDichVu.AutoSize = true;
            this.radXNDichVu.Location = new System.Drawing.Point(6, 48);
            this.radXNDichVu.Name = "radXNDichVu";
            this.radXNDichVu.Size = new System.Drawing.Size(128, 19);
            this.radXNDichVu.TabIndex = 1;
            this.radXNDichVu.Text = "Xét nghiệm dịch vụ";
            this.radXNDichVu.UseVisualStyleBackColor = true;
            // 
            // radTatCaLoaiXN
            // 
            this.radTatCaLoaiXN.AutoSize = true;
            this.radTatCaLoaiXN.Checked = true;
            this.radTatCaLoaiXN.Location = new System.Drawing.Point(6, 22);
            this.radTatCaLoaiXN.Name = "radTatCaLoaiXN";
            this.radTatCaLoaiXN.Size = new System.Drawing.Size(58, 19);
            this.radTatCaLoaiXN.TabIndex = 0;
            this.radTatCaLoaiXN.TabStop = true;
            this.radTatCaLoaiXN.Text = "Tất cả";
            this.radTatCaLoaiXN.UseVisualStyleBackColor = true;
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.AutoComplete = false;
            this.cboKhuVuc.AutoDropdown = false;
            this.cboKhuVuc.BackColorEven = System.Drawing.Color.White;
            this.cboKhuVuc.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboKhuVuc.ColumnNames = "";
            this.cboKhuVuc.ColumnWidthDefault = 75;
            this.cboKhuVuc.ColumnWidths = "";
            this.cboKhuVuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.LinkedColumnIndex = 0;
            this.cboKhuVuc.LinkedColumnIndex1 = 1;
            this.cboKhuVuc.LinkedColumnIndex2 = 0;
            this.cboKhuVuc.LinkedTextBox = null;
            this.cboKhuVuc.LinkedTextBox1 = null;
            this.cboKhuVuc.LinkedTextBox2 = null;
            this.cboKhuVuc.Location = new System.Drawing.Point(48, -29);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(74, 22);
            this.cboKhuVuc.TabIndex = 47;
            this.cboKhuVuc.Visible = false;
            // 
            // txtProfile
            // 
            this.txtProfile.Location = new System.Drawing.Point(488, 86);
            this.txtProfile.Name = "txtProfile";
            this.txtProfile.ReadOnly = true;
            this.txtProfile.Size = new System.Drawing.Size(0, 21);
            this.txtProfile.TabIndex = 18;
            this.txtProfile.TabStop = false;
            // 
            // cboNhomCLS
            // 
            this.cboNhomCLS.AutoComplete = false;
            this.cboNhomCLS.AutoDropdown = false;
            this.cboNhomCLS.BackColorEven = System.Drawing.Color.White;
            this.cboNhomCLS.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhomCLS.ColumnNames = "MaNhomCLS,TenNhomCLS";
            this.cboNhomCLS.ColumnWidthDefault = 75;
            this.cboNhomCLS.ColumnWidths = "50,200";
            this.cboNhomCLS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomCLS.FormattingEnabled = true;
            this.cboNhomCLS.LinkedColumnIndex = 0;
            this.cboNhomCLS.LinkedColumnIndex1 = 1;
            this.cboNhomCLS.LinkedColumnIndex2 = 0;
            this.cboNhomCLS.LinkedTextBox = null;
            this.cboNhomCLS.LinkedTextBox1 = null;
            this.cboNhomCLS.LinkedTextBox2 = null;
            this.cboNhomCLS.Location = new System.Drawing.Point(74, 140);
            this.cboNhomCLS.Name = "cboNhomCLS";
            this.cboNhomCLS.Size = new System.Drawing.Size(156, 22);
            this.cboNhomCLS.TabIndex = 13;
            this.cboNhomCLS.SelectionChangeCommitted += new System.EventHandler(this.cboNhomCLS_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Bộ phận";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "BS Chỉ định";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(74, 111);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(156, 21);
            this.dtpDateTo.TabIndex = 3;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(74, 83);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(156, 21);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "đến";
            // 
            // ucGroupHeader2
            // 
            this.ucGroupHeader2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader2.GroupCaption = "ĐIỀU KIỆN THỐNG KÊ";
            this.ucGroupHeader2.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader2.Name = "ucGroupHeader2";
            this.ucGroupHeader2.Size = new System.Drawing.Size(2118, 20);
            this.ucGroupHeader2.TabIndex = 91;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "TongTien";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn17.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 80;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "No1";
            this.dataGridViewTextBoxColumn22.HeaderText = "STT";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn22.Width = 50;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "TenXN";
            this.dataGridViewTextBoxColumn23.HeaderText = "Tên xét nghiệm";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn23.Width = 160;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "SoLuong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn24.HeaderText = "Tổng số lượng";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn24.Width = 60;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "SoLuongHeSo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn25.HeaderText = "Tổng số tiêu bản";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn25.Width = 60;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "TongTien";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn26.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn26.Width = 80;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "MaXN";
            this.dataGridViewTextBoxColumn27.HeaderText = "Ma XN";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn27.Visible = false;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "No1";
            this.dataGridViewTextBoxColumn28.HeaderText = "STT";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 50;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "TenBN";
            this.dataGridViewTextBoxColumn29.HeaderText = "Tên BN";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Width = 150;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Tuoi";
            this.dataGridViewTextBoxColumn30.HeaderText = "Năm sinh";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 60;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "GioiTinh";
            this.dataGridViewTextBoxColumn31.HeaderText = "Giới tính";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 60;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "DiaChi";
            this.dataGridViewTextBoxColumn32.HeaderText = "Địa chỉ";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 150;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "TenDoiTuongDichVu";
            this.dataGridViewTextBoxColumn33.HeaderText = "Đối tượng";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Width = 80;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "BacSiCD";
            this.dataGridViewTextBoxColumn34.HeaderText = "Bác sĩ CĐ";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Visible = false;
            this.dataGridViewTextBoxColumn34.Width = 120;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "TongTien";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn35.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Width = 80;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "No1";
            this.dataGridViewTextBoxColumn36.HeaderText = "STT";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 50;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "TenXN";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.dataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn37.HeaderText = "Xét nghiệm";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Width = 160;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "SoLuong";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn38.HeaderText = "Tổng số lượng";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Visible = false;
            this.dataGridViewTextBoxColumn38.Width = 65;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "TongTien";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn39.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Visible = false;
            this.dataGridViewTextBoxColumn39.Width = 80;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "MaXN";
            this.dataGridViewTextBoxColumn40.HeaderText = "Mã XN";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Visible = false;
            this.dataGridViewTextBoxColumn40.Width = 50;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "No1";
            this.dataGridViewTextBoxColumn41.HeaderText = "STT";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            this.dataGridViewTextBoxColumn41.Width = 50;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "MaNhanVien";
            this.dataGridViewTextBoxColumn42.HeaderText = "MaNhanVien";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "TenNhanVien";
            this.dataGridViewTextBoxColumn43.HeaderText = "Bác sĩ";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Width = 150;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "SoLuong";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.dataGridViewTextBoxColumn44.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn44.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Width = 60;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "TongTien";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.dataGridViewTextBoxColumn45.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn45.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Width = 80;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "TienCong";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            this.dataGridViewTextBoxColumn46.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn46.HeaderText = "Tiền chiết khấu";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Width = 80;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(2, 188);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treLoaiThongKe);
            this.splitContainer2.Panel1.Controls.Add(this.ucGroupHeader1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucGroupHeaderTabHeader);
            this.splitContainer2.Size = new System.Drawing.Size(1004, 471);
            this.splitContainer2.SplitterPosition = 275;
            this.splitContainer2.TabIndex = 2;
            // 
            // treLoaiThongKe
            // 
            this.treLoaiThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.treLoaiThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treLoaiThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treLoaiThongKe.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treLoaiThongKe.ImageIndex = 0;
            this.treLoaiThongKe.ImageList = this.imageList1;
            this.treLoaiThongKe.ItemHeight = 25;
            this.treLoaiThongKe.Location = new System.Drawing.Point(0, 20);
            this.treLoaiThongKe.Name = "treLoaiThongKe";
            treeNode1.ImageKey = "Log";
            treeNode1.Name = "nodWHONet";
            treeNode1.SelectedImageKey = "Selected";
            treeNode1.Text = "Báo cáo kháng sinh (WHONet)";
            treeNode2.ImageKey = "Log";
            treeNode2.Name = "nodBYT";
            treeNode2.SelectedImageKey = "Selected";
            treeNode2.Text = "Báo cáo kháng sinh (BYT)";
            treeNode3.ImageKey = "Log";
            treeNode3.Name = "nodBCTH";
            treeNode3.SelectedImageKey = "Selected";
            treeNode3.Text = "Báo cáo tổng hợp vi sinh";
            treeNode4.ImageKey = "Log";
            treeNode4.Name = "nodXuatThongTinBenhPham";
            treeNode4.SelectedImageKey = "Selected";
            treeNode4.Text = "Xuất thông tin bệnh phẩm";
            treeNode5.ImageKey = "Log";
            treeNode5.Name = "nodeXuatPhieuTienTrinhViSinh";
            treeNode5.SelectedImageKey = "Selected";
            treeNode5.Text = "Xuất phiếu tiến trình vi sinh";
            treeNode6.Name = "NodeRoot";
            treeNode6.NodeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "KẾT QUẢ XÉT NGHIỆM";
            this.treLoaiThongKe.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treLoaiThongKe.SelectedImageKey = "Selected.png";
            this.treLoaiThongKe.Size = new System.Drawing.Size(275, 451);
            this.treLoaiThongKe.TabIndex = 2;
            this.treLoaiThongKe.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treLoaiThongKe_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Root");
            this.imageList1.Images.SetKeyName(1, "Log");
            this.imageList1.Images.SetKeyName(2, "Selected");
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader1.GroupCaption = "LOẠI BÁO CÁO";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(275, 20);
            this.ucGroupHeader1.TabIndex = 9;
            // 
            // ucGroupHeaderTabHeader
            // 
            this.ucGroupHeaderTabHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeaderTabHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeaderTabHeader.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeaderTabHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeaderTabHeader.GroupCaption = "HÃY CHỌN BÁO CÁO";
            this.ucGroupHeaderTabHeader.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeaderTabHeader.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeaderTabHeader.Name = "ucGroupHeaderTabHeader";
            this.ucGroupHeaderTabHeader.Size = new System.Drawing.Size(725, 20);
            this.ucGroupHeaderTabHeader.TabIndex = 8;
            // 
            // frmXuatKetQuaXetNghiem_ViSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmXuatKetQuaXetNghiem_ViSinh";
            this.Text = "XUẤT BÁO CÁO KẾT QUẢ (Vi sinh)";
            this.Load += new System.EventHandler(this.frmXuatKetQuaXetNghiem_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.LabelControl label6;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label4;
        private CustomComboBox cboNhanVienXacNhan;
        private CustomComboBox cboBSChiDinh;
        private CustomComboBox cboNhomCLS;
        private DevExpress.XtraEditors.LabelControl label10;
        private System.Windows.Forms.TextBox txtProfile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radXNChiSo;
        private System.Windows.Forms.RadioButton radXNDichVu;
        private System.Windows.Forms.RadioButton radTatCaLoaiXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private DevExpress.XtraEditors.LabelControl label28;
        private CustomComboBox cboDonvi;
        private DevExpress.XtraEditors.LabelControl label15;
        private DevExpress.XtraEditors.LabelControl label13;
        private CustomComboBox cboBoPhanXN;
        private CustomComboBox cboKhuDieuTri;
        private CustomComboBox cboKhuVuc;
        private System.Windows.Forms.CheckBox chkChiCoKetQua;
        private DevExpress.XtraEditors.LabelControl label18;
        private DevExpress.XtraEditors.LabelControl label19;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl label20;
        private System.Windows.Forms.CheckBox chkChiXNDaXacNhan;
        private ucCheckListBox ucProfile;
        private ucCheckListBox ucDSXetNghiem;
        private ucCheckListBox ucMayXetNghiem;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radTGInKQDauTien;
        private System.Windows.Forms.RadioButton radTGNhapBN;
        private System.Windows.Forms.CheckBox chkNotresult;
        private ucCheckListBox ucDoiTuong;
        private System.Windows.Forms.TreeView treLoaiThongKe;
        private ucCheckListBox ucLoaiMau;
        private ucCheckListBox ucLoai;
        private ucGroupHeader ucGroupHeaderTabHeader;
        private ucGroupHeader ucGroupHeader1;
        private ucGroupHeader ucGroupHeader2;
    }
}