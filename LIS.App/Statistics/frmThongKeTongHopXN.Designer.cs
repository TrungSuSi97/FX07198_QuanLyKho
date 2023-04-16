using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThongKe
{
    partial class frmThongKeTongHopXN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("TỔNG HỢP BỆNH NHÂN", 1, 2);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("CHI TIẾT THEO BỆNH NHÂN", 1, 2);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("TỔNG HỢP ĐỐI TƯỢNG BỆNH NHÂN", 1, 2);
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("TỔNG HỢP TAT", 1, 2);
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("BÁO CÁO RỐI LOẠN CHUYỂN HÓA", 1, 2);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("BÁO CÁO SÀNG LỌC SƠ SINH", 1, 2);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("BÁO CÁO SÀNG LỌC SƠ SINH - ĐƠN VỊ", 1, 2);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("BỆNH NHÂN", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("TỔNG HỢP XÉT NGHIỆM", 1, 2);
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("TỔNG HỢP XÉT NGHIỆM THEO NGÀY", 1, 2);
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("TỔNG HỢP XÉT NGHIỆM THEO BÁC SĨ", 1, 2);
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("XÉT NGHIỆM", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("TỔNG HỢP CHẠY MÁY THEO BỆNH NHÂN", 1, 2);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("TỔNG HỢP CHẠY MÁY THEO ĐỐI TƯỢNG BN", 1, 2);
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("TỔNG HỢP TỪ MÁY", 1, 2);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("THỐNG KÊ MÁY XÉT NGHIỆM", new System.Windows.Forms.TreeNode[] {
            treeNode29,
            treeNode30,
            treeNode31});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKeTongHopXN));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.pnKhoaChiDinh = new DevExpress.XtraEditors.PanelControl();
            this.gcKhoaChiDinh = new DevExpress.XtraGrid.GridControl();
            this.gvKhoaChiDinh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaKhoaChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhoaChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhomKhoaChiDinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel7 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radThoiGianNhanMau = new System.Windows.Forms.RadioButton();
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
            this.cboNhanVienNhap = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label16 = new DevExpress.XtraEditors.LabelControl();
            this.cboBSChiDinh = new TPH.LIS.Common.Controls.CustomComboBox();
            this.cboDoiTuongDV = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.cboBoPhanXN = new TPH.LIS.Common.Controls.CustomComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radXNChiSo = new System.Windows.Forms.RadioButton();
            this.radXNDichVu = new System.Windows.Forms.RadioButton();
            this.radTatCaLoaiXN = new System.Windows.Forms.RadioButton();
            this.cboKhuVuc = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.cboNhomCLS = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
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
            this.ucGroupHeader3 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.ucGroupHeaderTabHeader = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnKhoaChiDinh)).BeginInit();
            this.pnKhoaChiDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcKhoaChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhoaChiDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).BeginInit();
            this.panel7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(280, 22);
            this.lblTitle.Text = "TỔNG HỢP THỐNG KÊ XÉT NGHIỆM";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.splitContainer2);
            this.pnContaint.Controls.Add(this.xtraScrollableControl1);
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
            this.btnClose.Location = new System.Drawing.Point(652, 10);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(681, 10);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(1008, 0);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(130)))), ((int)(((byte)(167)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1008, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(282, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 0);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
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
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Controls.Add(this.pnKhoaChiDinh);
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
            this.panel1.Controls.Add(this.cboNhanVienNhap);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.cboBSChiDinh);
            this.panel1.Controls.Add(this.cboDoiTuongDV);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cboBoPhanXN);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtProfile);
            this.panel1.Controls.Add(this.cboNhomCLS);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ucGroupHeader1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1705, 198);
            this.panel1.TabIndex = 0;
            // 
            // pnKhoaChiDinh
            // 
            this.pnKhoaChiDinh.Controls.Add(this.gcKhoaChiDinh);
            this.pnKhoaChiDinh.Controls.Add(this.panel7);
            this.pnKhoaChiDinh.Location = new System.Drawing.Point(613, 23);
            this.pnKhoaChiDinh.Name = "pnKhoaChiDinh";
            this.pnKhoaChiDinh.Size = new System.Drawing.Size(427, 166);
            this.pnKhoaChiDinh.TabIndex = 88;
            // 
            // gcKhoaChiDinh
            // 
            this.gcKhoaChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcKhoaChiDinh.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gcKhoaChiDinh.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gcKhoaChiDinh.Location = new System.Drawing.Point(2, 24);
            this.gcKhoaChiDinh.MainView = this.gvKhoaChiDinh;
            this.gcKhoaChiDinh.Name = "gcKhoaChiDinh";
            this.gcKhoaChiDinh.Size = new System.Drawing.Size(423, 140);
            this.gcKhoaChiDinh.TabIndex = 360;
            this.gcKhoaChiDinh.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvKhoaChiDinh});
            // 
            // gvKhoaChiDinh
            // 
            this.gvKhoaChiDinh.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.DetailTip.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.Empty.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.EvenRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.FilterPanel.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.FixedLine.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvKhoaChiDinh.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvKhoaChiDinh.Appearance.FocusedCell.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.FocusedRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvKhoaChiDinh.Appearance.FooterPanel.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvKhoaChiDinh.Appearance.GroupButton.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gvKhoaChiDinh.Appearance.GroupFooter.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gvKhoaChiDinh.Appearance.GroupPanel.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKhoaChiDinh.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvKhoaChiDinh.Appearance.GroupRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvKhoaChiDinh.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvKhoaChiDinh.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.HorzLine.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.OddRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.Preview.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.Preview.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.Row.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.RowSeparator.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvKhoaChiDinh.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvKhoaChiDinh.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvKhoaChiDinh.Appearance.SelectedRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvKhoaChiDinh.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.TopNewRow.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.VertLine.Options.UseFont = true;
            this.gvKhoaChiDinh.Appearance.ViewCaption.Font = new System.Drawing.Font("Arial", 9F);
            this.gvKhoaChiDinh.Appearance.ViewCaption.Options.UseFont = true;
            this.gvKhoaChiDinh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaKhoaChiDinh,
            this.colTenKhoaChiDinh,
            this.colNhomKhoaChiDinh});
            this.gvKhoaChiDinh.GridControl = this.gcKhoaChiDinh;
            this.gvKhoaChiDinh.GroupCount = 1;
            this.gvKhoaChiDinh.Name = "gvKhoaChiDinh";
            this.gvKhoaChiDinh.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvKhoaChiDinh.OptionsSelection.MultiSelect = true;
            this.gvKhoaChiDinh.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvKhoaChiDinh.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gvKhoaChiDinh.OptionsView.ColumnAutoWidth = false;
            this.gvKhoaChiDinh.OptionsView.RowAutoHeight = true;
            this.gvKhoaChiDinh.OptionsView.ShowAutoFilterRow = true;
            this.gvKhoaChiDinh.OptionsView.ShowGroupPanel = false;
            this.gvKhoaChiDinh.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNhomKhoaChiDinh, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMaKhoaChiDinh
            // 
            this.colMaKhoaChiDinh.Caption = "Mã khoa phòng";
            this.colMaKhoaChiDinh.FieldName = "MaKhoaPhong";
            this.colMaKhoaChiDinh.Name = "colMaKhoaChiDinh";
            this.colMaKhoaChiDinh.OptionsColumn.AllowEdit = false;
            this.colMaKhoaChiDinh.OptionsColumn.ReadOnly = true;
            this.colMaKhoaChiDinh.Visible = true;
            this.colMaKhoaChiDinh.VisibleIndex = 1;
            this.colMaKhoaChiDinh.Width = 96;
            // 
            // colTenKhoaChiDinh
            // 
            this.colTenKhoaChiDinh.Caption = "Tên khoa phòng";
            this.colTenKhoaChiDinh.FieldName = "TenKhoaPhong";
            this.colTenKhoaChiDinh.Name = "colTenKhoaChiDinh";
            this.colTenKhoaChiDinh.OptionsColumn.AllowEdit = false;
            this.colTenKhoaChiDinh.OptionsColumn.ReadOnly = true;
            this.colTenKhoaChiDinh.Visible = true;
            this.colTenKhoaChiDinh.VisibleIndex = 2;
            this.colTenKhoaChiDinh.Width = 224;
            // 
            // colNhomKhoaChiDinh
            // 
            this.colNhomKhoaChiDinh.Caption = "Nhóm";
            this.colNhomKhoaChiDinh.FieldName = "mabophan";
            this.colNhomKhoaChiDinh.Name = "colNhomKhoaChiDinh";
            this.colNhomKhoaChiDinh.Visible = true;
            this.colNhomKhoaChiDinh.VisibleIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(2, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(423, 22);
            this.panel7.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label3.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.Options.UseBackColor = true;
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "KHOA CHỈ ĐỊNH";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.radThoiGianNhanMau);
            this.groupBox2.Controls.Add(this.radTGInKQDauTien);
            this.groupBox2.Controls.Add(this.radTGNhapBN);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(5, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 78);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thời gian thống kê";
            // 
            // radThoiGianNhanMau
            // 
            this.radThoiGianNhanMau.AutoSize = true;
            this.radThoiGianNhanMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.radThoiGianNhanMau.Location = new System.Drawing.Point(6, 49);
            this.radThoiGianNhanMau.Name = "radThoiGianNhanMau";
            this.radThoiGianNhanMau.Size = new System.Drawing.Size(99, 19);
            this.radThoiGianNhanMau.TabIndex = 3;
            this.radThoiGianNhanMau.Text = "TG nhận mẫu";
            this.radThoiGianNhanMau.UseVisualStyleBackColor = true;
            // 
            // radTGInKQDauTien
            // 
            this.radTGInKQDauTien.AutoSize = true;
            this.radTGInKQDauTien.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.radTGInKQDauTien.Location = new System.Drawing.Point(125, 49);
            this.radTGInKQDauTien.Name = "radTGInKQDauTien";
            this.radTGInKQDauTien.Size = new System.Drawing.Size(53, 19);
            this.radTGInKQDauTien.TabIndex = 2;
            this.radTGInKQDauTien.Text = "TG in";
            this.radTGInKQDauTien.UseVisualStyleBackColor = true;
            this.radTGInKQDauTien.Visible = false;
            // 
            // radTGNhapBN
            // 
            this.radTGNhapBN.AutoSize = true;
            this.radTGNhapBN.Checked = true;
            this.radTGNhapBN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.radTGNhapBN.ForeColor = System.Drawing.Color.Maroon;
            this.radTGNhapBN.Location = new System.Drawing.Point(6, 22);
            this.radTGNhapBN.Name = "radTGNhapBN";
            this.radTGNhapBN.Size = new System.Drawing.Size(90, 19);
            this.radTGNhapBN.TabIndex = 1;
            this.radTGNhapBN.TabStop = true;
            this.radTGNhapBN.Text = "TG nhập BN";
            this.radTGNhapBN.UseVisualStyleBackColor = true;
            // 
            // ucMayXetNghiem
            // 
            this.ucMayXetNghiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucMayXetNghiem.DataSource = null;
            this.ucMayXetNghiem.DisplayMember = "";
            this.ucMayXetNghiem.Font = new System.Drawing.Font("Arial", 10F);
            this.ucMayXetNghiem.IsCheckedAll = true;
            this.ucMayXetNghiem.ListCaption = "Máy xét nghiệm";
            this.ucMayXetNghiem.Location = new System.Drawing.Point(1484, 22);
            this.ucMayXetNghiem.Name = "ucMayXetNghiem";
            this.ucMayXetNghiem.Size = new System.Drawing.Size(211, 172);
            this.ucMayXetNghiem.TabIndex = 60;
            this.ucMayXetNghiem.ValueMember = "";
            // 
            // ucProfile
            // 
            this.ucProfile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucProfile.DataSource = null;
            this.ucProfile.DisplayMember = "";
            this.ucProfile.Font = new System.Drawing.Font("Arial", 10F);
            this.ucProfile.IsCheckedAll = true;
            this.ucProfile.ListCaption = "Profile";
            this.ucProfile.Location = new System.Drawing.Point(1263, 22);
            this.ucProfile.Name = "ucProfile";
            this.ucProfile.Size = new System.Drawing.Size(211, 172);
            this.ucProfile.TabIndex = 59;
            this.ucProfile.ValueMember = "";
            // 
            // ucDSXetNghiem
            // 
            this.ucDSXetNghiem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDSXetNghiem.DataSource = null;
            this.ucDSXetNghiem.DisplayMember = "";
            this.ucDSXetNghiem.Font = new System.Drawing.Font("Arial", 10F);
            this.ucDSXetNghiem.IsCheckedAll = true;
            this.ucDSXetNghiem.ListCaption = "Xét nghiệm";
            this.ucDSXetNghiem.Location = new System.Drawing.Point(1046, 22);
            this.ucDSXetNghiem.Name = "ucDSXetNghiem";
            this.ucDSXetNghiem.Size = new System.Drawing.Size(211, 167);
            this.ucDSXetNghiem.TabIndex = 58;
            this.ucDSXetNghiem.ValueMember = "";
            // 
            // chkChiXNDaXacNhan
            // 
            this.chkChiXNDaXacNhan.AutoSize = true;
            this.chkChiXNDaXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkChiXNDaXacNhan.Checked = true;
            this.chkChiXNDaXacNhan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChiXNDaXacNhan.Font = new System.Drawing.Font("Arial", 10F);
            this.chkChiXNDaXacNhan.ForeColor = System.Drawing.Color.Black;
            this.chkChiXNDaXacNhan.Location = new System.Drawing.Point(307, 146);
            this.chkChiXNDaXacNhan.Name = "chkChiXNDaXacNhan";
            this.chkChiXNDaXacNhan.Size = new System.Drawing.Size(105, 20);
            this.chkChiXNDaXacNhan.TabIndex = 57;
            this.chkChiXNDaXacNhan.Text = "Đã xác nhận";
            this.chkChiXNDaXacNhan.UseVisualStyleBackColor = false;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(463, 143);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(57, 23);
            this.txtGhiChu.TabIndex = 56;
            this.txtGhiChu.Visible = false;
            // 
            // label20
            // 
            this.label20.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label20.Appearance.Options.UseFont = true;
            this.label20.Location = new System.Drawing.Point(463, 146);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 16);
            this.label20.TabIndex = 55;
            this.label20.Text = "Ghi chú";
            this.label20.Visible = false;
            // 
            // label19
            // 
            this.label19.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label19.Appearance.Options.UseFont = true;
            this.label19.Location = new System.Drawing.Point(463, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 16);
            this.label19.TabIndex = 54;
            this.label19.Text = "Kết quả";
            this.label19.Visible = false;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKetQua.Location = new System.Drawing.Point(463, 143);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(49, 23);
            this.txtKetQua.TabIndex = 53;
            this.txtKetQua.Visible = false;
            // 
            // label18
            // 
            this.label18.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label18.Appearance.Options.UseFont = true;
            this.label18.Location = new System.Drawing.Point(463, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 16);
            this.label18.TabIndex = 52;
            this.label18.Text = "Người duyệt";
            this.label18.Visible = false;
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
            this.cboNhanVienXacNhan.Location = new System.Drawing.Point(463, 143);
            this.cboNhanVienXacNhan.Name = "cboNhanVienXacNhan";
            this.cboNhanVienXacNhan.Size = new System.Drawing.Size(120, 22);
            this.cboNhanVienXacNhan.TabIndex = 7;
            this.cboNhanVienXacNhan.Visible = false;
            this.cboNhanVienXacNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhanVienThucHien_KeyPress);
            // 
            // chkChiCoKetQua
            // 
            this.chkChiCoKetQua.AutoSize = true;
            this.chkChiCoKetQua.Checked = true;
            this.chkChiCoKetQua.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChiCoKetQua.Font = new System.Drawing.Font("Arial", 10F);
            this.chkChiCoKetQua.Location = new System.Drawing.Point(306, 176);
            this.chkChiCoKetQua.Name = "chkChiCoKetQua";
            this.chkChiCoKetQua.Size = new System.Drawing.Size(111, 20);
            this.chkChiCoKetQua.TabIndex = 51;
            this.chkChiCoKetQua.Text = "Chỉ XN có KQ";
            this.chkChiCoKetQua.UseVisualStyleBackColor = true;
            // 
            // cboNhanVienNhap
            // 
            this.cboNhanVienNhap.AutoComplete = false;
            this.cboNhanVienNhap.AutoDropdown = false;
            this.cboNhanVienNhap.BackColorEven = System.Drawing.Color.White;
            this.cboNhanVienNhap.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboNhanVienNhap.ColumnNames = "";
            this.cboNhanVienNhap.ColumnWidthDefault = 75;
            this.cboNhanVienNhap.ColumnWidths = "75,150";
            this.cboNhanVienNhap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhanVienNhap.FormattingEnabled = true;
            this.cboNhanVienNhap.LinkedColumnIndex = 0;
            this.cboNhanVienNhap.LinkedColumnIndex1 = 0;
            this.cboNhanVienNhap.LinkedColumnIndex2 = 0;
            this.cboNhanVienNhap.LinkedTextBox = null;
            this.cboNhanVienNhap.LinkedTextBox1 = null;
            this.cboNhanVienNhap.LinkedTextBox2 = null;
            this.cboNhanVienNhap.Location = new System.Drawing.Point(463, 163);
            this.cboNhanVienNhap.Name = "cboNhanVienNhap";
            this.cboNhanVienNhap.Size = new System.Drawing.Size(121, 22);
            this.cboNhanVienNhap.TabIndex = 50;
            this.cboNhanVienNhap.Visible = false;
            this.cboNhanVienNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhanVienNhap_KeyPress);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(519, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 49;
            this.label16.Text = "NV Nhập";
            this.label16.Visible = false;
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
            this.cboBSChiDinh.Location = new System.Drawing.Point(307, 27);
            this.cboBSChiDinh.Name = "cboBSChiDinh";
            this.cboBSChiDinh.Size = new System.Drawing.Size(120, 22);
            this.cboBSChiDinh.TabIndex = 5;
            this.cboBSChiDinh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhanVien_KeyPress);
            // 
            // cboDoiTuongDV
            // 
            this.cboDoiTuongDV.AutoComplete = false;
            this.cboDoiTuongDV.AutoDropdown = false;
            this.cboDoiTuongDV.BackColorEven = System.Drawing.Color.White;
            this.cboDoiTuongDV.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDoiTuongDV.ColumnNames = "";
            this.cboDoiTuongDV.ColumnWidthDefault = 75;
            this.cboDoiTuongDV.ColumnWidths = "75,150";
            this.cboDoiTuongDV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDoiTuongDV.FormattingEnabled = true;
            this.cboDoiTuongDV.LinkedColumnIndex = 0;
            this.cboDoiTuongDV.LinkedColumnIndex1 = 0;
            this.cboDoiTuongDV.LinkedColumnIndex2 = 0;
            this.cboDoiTuongDV.LinkedTextBox = null;
            this.cboDoiTuongDV.LinkedTextBox1 = null;
            this.cboDoiTuongDV.LinkedTextBox2 = null;
            this.cboDoiTuongDV.Location = new System.Drawing.Point(307, 115);
            this.cboDoiTuongDV.Name = "cboDoiTuongDV";
            this.cboDoiTuongDV.Size = new System.Drawing.Size(121, 22);
            this.cboDoiTuongDV.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label15.Appearance.Options.UseFont = true;
            this.label15.Location = new System.Drawing.Point(205, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 16);
            this.label15.TabIndex = 46;
            this.label15.Text = "Nhóm";
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
            this.cboBoPhanXN.Location = new System.Drawing.Point(307, 55);
            this.cboBoPhanXN.Name = "cboBoPhanXN";
            this.cboBoPhanXN.Size = new System.Drawing.Size(121, 22);
            this.cboBoPhanXN.TabIndex = 45;
            this.cboBoPhanXN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBoPhanXN_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radXNChiSo);
            this.groupBox1.Controls.Add(this.radXNDichVu);
            this.groupBox1.Controls.Add(this.radTatCaLoaiXN);
            this.groupBox1.Controls.Add(this.cboKhuVuc);
            this.groupBox1.Location = new System.Drawing.Point(433, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 113);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn";
            // 
            // radXNChiSo
            // 
            this.radXNChiSo.AutoSize = true;
            this.radXNChiSo.Font = new System.Drawing.Font("Arial", 10F);
            this.radXNChiSo.Location = new System.Drawing.Point(6, 80);
            this.radXNChiSo.Name = "radXNChiSo";
            this.radXNChiSo.Size = new System.Drawing.Size(136, 20);
            this.radXNChiSo.TabIndex = 2;
            this.radXNChiSo.Text = "Xét nghiệm chỉ số";
            this.radXNChiSo.UseVisualStyleBackColor = true;
            // 
            // radXNDichVu
            // 
            this.radXNDichVu.AutoSize = true;
            this.radXNDichVu.Checked = true;
            this.radXNDichVu.Font = new System.Drawing.Font("Arial", 10F);
            this.radXNDichVu.Location = new System.Drawing.Point(6, 48);
            this.radXNDichVu.Name = "radXNDichVu";
            this.radXNDichVu.Size = new System.Drawing.Size(144, 20);
            this.radXNDichVu.TabIndex = 1;
            this.radXNDichVu.TabStop = true;
            this.radXNDichVu.Text = "Xét nghiệm dịch vụ";
            this.radXNDichVu.UseVisualStyleBackColor = true;
            // 
            // radTatCaLoaiXN
            // 
            this.radTatCaLoaiXN.AutoSize = true;
            this.radTatCaLoaiXN.Font = new System.Drawing.Font("Arial", 10F);
            this.radTatCaLoaiXN.Location = new System.Drawing.Point(6, 22);
            this.radTatCaLoaiXN.Name = "radTatCaLoaiXN";
            this.radTatCaLoaiXN.Size = new System.Drawing.Size(65, 20);
            this.radTatCaLoaiXN.TabIndex = 0;
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
            this.txtProfile.Location = new System.Drawing.Point(437, 83);
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
            this.cboNhomCLS.Location = new System.Drawing.Point(306, 83);
            this.cboNhomCLS.Name = "cboNhomCLS";
            this.cboNhomCLS.Size = new System.Drawing.Size(121, 22);
            this.cboNhomCLS.TabIndex = 13;
            this.cboNhomCLS.SelectionChangeCommitted += new System.EventHandler(this.cboNhomCLS_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label10.Appearance.Options.UseFont = true;
            this.label10.Location = new System.Drawing.Point(206, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Bộ phận";
            // 
            // label9
            // 
            this.label9.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label9.Appearance.Options.UseFont = true;
            this.label9.Location = new System.Drawing.Point(206, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Đối tượng";
            // 
            // label6
            // 
            this.label6.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label6.Appearance.Options.UseFont = true;
            this.label6.Location = new System.Drawing.Point(206, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "BS Chỉ định";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(10, 167);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(179, 21);
            this.dtpDateTo.TabIndex = 3;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(10, 120);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(179, 21);
            this.dtpDateFrom.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.Appearance.Options.UseFont = true;
            this.label5.Location = new System.Drawing.Point(10, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Từ ngày";
            // 
            // label4
            // 
            this.label4.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.Appearance.Options.UseFont = true;
            this.label4.Location = new System.Drawing.Point(10, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "đến";
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader1.GroupCaption = "ĐIỀU KIỆN THỐNG KÊ";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(1705, 20);
            this.ucGroupHeader1.TabIndex = 89;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "TongTien";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle12;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn24.HeaderText = "Tổng số lượng";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn24.Width = 60;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "SoLuongHeSo";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn25.HeaderText = "Tổng số tiêu bản";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn25.Width = 60;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "TongTien";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle15;
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
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N0";
            this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle16;
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            this.dataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn37.HeaderText = "Xét nghiệm";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Width = 160;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "SoLuong";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            this.dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn38.HeaderText = "Tổng số lượng";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Visible = false;
            this.dataGridViewTextBoxColumn38.Width = 65;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "TongTien";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle19;
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "N0";
            this.dataGridViewTextBoxColumn44.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn44.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Width = 60;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "TongTien";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            this.dataGridViewTextBoxColumn45.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn45.HeaderText = "Tổng tiền";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Width = 80;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "TienCong";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N0";
            this.dataGridViewTextBoxColumn46.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn46.HeaderText = "Tiền chiết khấu";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Width = 80;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(2, 217);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treLoaiThongKe);
            this.splitContainer2.Panel1.Controls.Add(this.ucGroupHeader3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucGroupHeaderTabHeader);
            this.splitContainer2.Size = new System.Drawing.Size(1004, 442);
            this.splitContainer2.SplitterPosition = 363;
            this.splitContainer2.TabIndex = 2;
            // 
            // treLoaiThongKe
            // 
            this.treLoaiThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treLoaiThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treLoaiThongKe.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treLoaiThongKe.ImageIndex = 0;
            this.treLoaiThongKe.ImageList = this.imageList1;
            this.treLoaiThongKe.ItemHeight = 25;
            this.treLoaiThongKe.Location = new System.Drawing.Point(0, 20);
            this.treLoaiThongKe.Name = "treLoaiThongKe";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "nodTongHopBenhNhan";
            treeNode17.SelectedImageIndex = 2;
            treeNode17.Text = "TỔNG HỢP BỆNH NHÂN";
            treeNode18.ImageIndex = 1;
            treeNode18.Name = "nodChiTietXetNghiemTheoCot";
            treeNode18.SelectedImageIndex = 2;
            treeNode18.Text = "CHI TIẾT THEO BỆNH NHÂN";
            treeNode19.ImageIndex = 1;
            treeNode19.Name = "nodTongHopTheoDoiTuong";
            treeNode19.SelectedImageIndex = 2;
            treeNode19.Text = "TỔNG HỢP ĐỐI TƯỢNG BỆNH NHÂN";
            treeNode20.ImageIndex = 1;
            treeNode20.Name = "nodeTongHopTAT";
            treeNode20.SelectedImageIndex = 2;
            treeNode20.Text = "TỔNG HỢP TAT";
            treeNode21.ImageIndex = 1;
            treeNode21.Name = "nodeBaoCaoRoiLoanChuyenHoa";
            treeNode21.SelectedImageIndex = 2;
            treeNode21.Text = "BÁO CÁO RỐI LOẠN CHUYỂN HÓA";
            treeNode22.ImageIndex = 1;
            treeNode22.Name = "nodeBaoCaoSLSS";
            treeNode22.SelectedImageIndex = 2;
            treeNode22.Text = "BÁO CÁO SÀNG LỌC SƠ SINH";
            treeNode23.ImageIndex = 1;
            treeNode23.Name = "nodeBCSLSS_DonVi";
            treeNode23.SelectedImageIndex = 2;
            treeNode23.Text = "BÁO CÁO SÀNG LỌC SƠ SINH - ĐƠN VỊ";
            treeNode24.Name = "NodeRoot";
            treeNode24.NodeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode24.Text = "BỆNH NHÂN";
            treeNode25.ImageIndex = 1;
            treeNode25.Name = "nodTongHopXetNghiem";
            treeNode25.SelectedImageIndex = 2;
            treeNode25.Text = "TỔNG HỢP XÉT NGHIỆM";
            treeNode26.ImageIndex = 1;
            treeNode26.Name = "nodTongHopXetNghiemTheoNgay";
            treeNode26.SelectedImageIndex = 2;
            treeNode26.Text = "TỔNG HỢP XÉT NGHIỆM THEO NGÀY";
            treeNode27.ImageIndex = 1;
            treeNode27.Name = "nodTonghoptheoBSChiDinh";
            treeNode27.SelectedImageIndex = 2;
            treeNode27.Text = "TỔNG HỢP XÉT NGHIỆM THEO BÁC SĨ";
            treeNode28.Name = "nodNhatKyCanLamSang";
            treeNode28.NodeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode28.Text = "XÉT NGHIỆM";
            treeNode29.ImageIndex = 1;
            treeNode29.Name = "nodTongHopXnTuMayTheoBenhNhan";
            treeNode29.SelectedImageIndex = 2;
            treeNode29.Text = "TỔNG HỢP CHẠY MÁY THEO BỆNH NHÂN";
            treeNode30.ImageIndex = 1;
            treeNode30.Name = "nodTongHopMayTheoDoiTuong";
            treeNode30.SelectedImageIndex = 2;
            treeNode30.Text = "TỔNG HỢP CHẠY MÁY THEO ĐỐI TƯỢNG BN";
            treeNode31.ImageIndex = 1;
            treeNode31.Name = "nodTongHopXetNghiemMay";
            treeNode31.SelectedImageIndex = 2;
            treeNode31.Text = "TỔNG HỢP TỪ MÁY";
            treeNode32.Name = "nodNhatKySuDungPhanMem";
            treeNode32.NodeFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode32.Text = "THỐNG KÊ MÁY XÉT NGHIỆM";
            this.treLoaiThongKe.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode28,
            treeNode32});
            this.treLoaiThongKe.SelectedImageKey = "Selected.png";
            this.treLoaiThongKe.Size = new System.Drawing.Size(363, 422);
            this.treLoaiThongKe.TabIndex = 1;
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
            // ucGroupHeader3
            // 
            this.ucGroupHeader3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeader3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeader3.GroupCaption = "LOẠI THỐNG KÊ";
            this.ucGroupHeader3.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader3.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader3.Name = "ucGroupHeader3";
            this.ucGroupHeader3.Size = new System.Drawing.Size(363, 20);
            this.ucGroupHeader3.TabIndex = 6;
            // 
            // ucGroupHeaderTabHeader
            // 
            this.ucGroupHeaderTabHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeaderTabHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeaderTabHeader.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeaderTabHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(218)))), ((int)(((byte)(89)))));
            this.ucGroupHeaderTabHeader.GroupCaption = "HÃY CHỌN THỐNG KÊ";
            this.ucGroupHeaderTabHeader.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeaderTabHeader.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeaderTabHeader.Name = "ucGroupHeaderTabHeader";
            this.ucGroupHeaderTabHeader.Size = new System.Drawing.Size(631, 20);
            this.ucGroupHeaderTabHeader.TabIndex = 6;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.panel1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraScrollableControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1004, 215);
            this.xtraScrollableControl1.TabIndex = 3;
            // 
            // frmThongKeTongHopXN
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmThongKeTongHopXN";
            this.Text = "Tổng hợp thống kê xét nghiệm";
            this.Load += new System.EventHandler(this.frmThongKeTongHop_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnKhoaChiDinh)).EndInit();
            this.pnKhoaChiDinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcKhoaChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhoaChiDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel7)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2.Panel2)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
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
        private CustomComboBox cboDoiTuongDV;
        private DevExpress.XtraEditors.LabelControl label9;
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
        private DevExpress.XtraEditors.LabelControl label15;
        private CustomComboBox cboBoPhanXN;
        private CustomComboBox cboKhuVuc;
        private System.Windows.Forms.CheckBox chkChiCoKetQua;
        private CustomComboBox cboNhanVienNhap;
        private DevExpress.XtraEditors.LabelControl label16;
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
        private System.Windows.Forms.TreeView treLoaiThongKe;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radTGInKQDauTien;
        private System.Windows.Forms.RadioButton radTGNhapBN;
        private System.Windows.Forms.RadioButton radThoiGianNhanMau;
        private DevExpress.XtraEditors.PanelControl pnKhoaChiDinh;
        private DevExpress.XtraGrid.GridControl gcKhoaChiDinh;
        private DevExpress.XtraGrid.Views.Grid.GridView gvKhoaChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKhoaChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhoaChiDinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNhomKhoaChiDinh;
        private DevExpress.XtraEditors.PanelControl panel7;
        public DevExpress.XtraEditors.LabelControl label3;
        private ucGroupHeader ucGroupHeaderTabHeader;
        private ucGroupHeader ucGroupHeader3;
        private ucGroupHeader ucGroupHeader1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
    }
}