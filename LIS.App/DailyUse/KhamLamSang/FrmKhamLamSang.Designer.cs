using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi.KhamLamSang
{
    partial class FrmKhamLamSang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKhamLamSang));
            this.gbResultInfo = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label22 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhipTho = new System.Windows.Forms.TextBox();
            this.label21 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenBacSi = new System.Windows.Forms.TextBox();
            this.cboBacSi = new CustomComboBox();
            this.label20 = new DevExpress.XtraEditors.LabelControl();
            this.dtpTaiKham = new System.Windows.Forms.DateTimePicker();
            this.chkTaiKham = new System.Windows.Forms.CheckBox();
            this.txtDeNghi = new System.Windows.Forms.TextBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuuKQKB = new TPH.Controls.TPHNormalButton();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.cboChanDoan = new CustomComboBox();
            this.label16 = new DevExpress.XtraEditors.LabelControl();
            this.txtCanNang = new System.Windows.Forms.TextBox();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.txtChieuCao = new System.Windows.Forms.TextBox();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhietDo = new System.Windows.Forms.TextBox();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.txtMach = new System.Windows.Forms.TextBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtHuyetAp = new System.Windows.Forms.TextBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgayKham = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstThuoc = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.cboItem = new CustomComboBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.panel5 = new DevExpress.XtraEditors.PanelControl();
            this.chkDaInYC = new System.Windows.Forms.CheckBox();
            this.chkXacNhan = new System.Windows.Forms.CheckBox();
            this.btnThemThuoc = new TPH.Controls.TPHNormalButton();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.txtTenNhomThuoc = new System.Windows.Forms.TextBox();
            this.cboNhomThuoc = new CustomComboBox();
            this.label19 = new DevExpress.XtraEditors.LabelControl();
            this.btnCheckAll = new TPH.Controls.TPHNormalButton();
            this.dtgChiDinhThuoc = new CustomDatagridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CachDung = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNhapKQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserSuaKQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvChiDinhThuoc = new CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.btnCheckItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshResult = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnValidResult = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.progressPrint = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel4 = new DevExpress.XtraEditors.PanelControl();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.gbResultInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiDinhThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiDinhThuoc)).BeginInit();
            this.bvChiDinhThuoc.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(599, 26);
            this.lblTitle.Text = "KHÁM LÂM SÀNG";
            // 
            // pnContaint
            // 
            this.pnContaint.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnContaint.Controls.Add(this.panel4);
            this.pnContaint.Location = new System.Drawing.Point(3, 45);
            this.pnContaint.Size = new System.Drawing.Size(607, 418);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // gbResultInfo
            // 
            this.gbResultInfo.Controls.Add(this.txtGhiChu);
            this.gbResultInfo.Controls.Add(this.label22);
            this.gbResultInfo.Controls.Add(this.txtNhipTho);
            this.gbResultInfo.Controls.Add(this.label21);
            this.gbResultInfo.Controls.Add(this.txtTenBacSi);
            this.gbResultInfo.Controls.Add(this.cboBacSi);
            this.gbResultInfo.Controls.Add(this.label20);
            this.gbResultInfo.Controls.Add(this.dtpTaiKham);
            this.gbResultInfo.Controls.Add(this.chkTaiKham);
            this.gbResultInfo.Controls.Add(this.txtDeNghi);
            this.gbResultInfo.Controls.Add(this.label10);
            this.gbResultInfo.Controls.Add(this.btnLuuKQKB);
            this.gbResultInfo.Controls.Add(this.txtChanDoan);
            this.gbResultInfo.Controls.Add(this.cboChanDoan);
            this.gbResultInfo.Controls.Add(this.label16);
            this.gbResultInfo.Controls.Add(this.txtCanNang);
            this.gbResultInfo.Controls.Add(this.label11);
            this.gbResultInfo.Controls.Add(this.txtChieuCao);
            this.gbResultInfo.Controls.Add(this.label15);
            this.gbResultInfo.Controls.Add(this.txtNhietDo);
            this.gbResultInfo.Controls.Add(this.label9);
            this.gbResultInfo.Controls.Add(this.txtMach);
            this.gbResultInfo.Controls.Add(this.label7);
            this.gbResultInfo.Controls.Add(this.txtHuyetAp);
            this.gbResultInfo.Controls.Add(this.label6);
            this.gbResultInfo.Controls.Add(this.label2);
            this.gbResultInfo.Controls.Add(this.dtpNgayKham);
            this.gbResultInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbResultInfo.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultInfo.Location = new System.Drawing.Point(0, 0);
            this.gbResultInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbResultInfo.Name = "gbResultInfo";
            this.gbResultInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbResultInfo.Size = new System.Drawing.Size(597, 129);
            this.gbResultInfo.TabIndex = 110;
            this.gbResultInfo.TabStop = false;
            this.gbResultInfo.Text = "Kết quả khám bệnh";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(65, 101);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(184, 25);
            this.txtGhiChu.TabIndex = 116;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 104);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(50, 19);
            this.label22.TabIndex = 115;
            this.label22.Text = "Ghi chú";
            // 
            // txtNhipTho
            // 
            this.txtNhipTho.Location = new System.Drawing.Point(297, 46);
            this.txtNhipTho.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNhipTho.Name = "txtNhipTho";
            this.txtNhipTho.Size = new System.Drawing.Size(30, 25);
            this.txtNhipTho.TabIndex = 114;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(234, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 19);
            this.label21.TabIndex = 113;
            this.label21.Text = "Nhịp thở";
            // 
            // txtTenBacSi
            // 
            this.txtTenBacSi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtTenBacSi.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBacSi.Location = new System.Drawing.Point(6, 73);
            this.txtTenBacSi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenBacSi.Name = "txtTenBacSi";
            this.txtTenBacSi.ReadOnly = true;
            this.txtTenBacSi.Size = new System.Drawing.Size(134, 25);
            this.txtTenBacSi.TabIndex = 112;
            this.txtTenBacSi.TabStop = false;
            this.txtTenBacSi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboBacSi
            // 
            this.cboBacSi.AutoComplete = false;
            this.cboBacSi.AutoDropdown = false;
            this.cboBacSi.BackColorEven = System.Drawing.Color.White;
            this.cboBacSi.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboBacSi.ColumnNames = "MaBacSi, TenBacSi";
            this.cboBacSi.ColumnWidthDefault = 75;
            this.cboBacSi.ColumnWidths = "75,150";
            this.cboBacSi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboBacSi.FormattingEnabled = true;
            this.cboBacSi.LinkedColumnIndex1 = 1;
            this.cboBacSi.LinkedColumnIndex2 = 0;
            this.cboBacSi.LinkedTextBox1 = this.txtTenBacSi;
            this.cboBacSi.LinkedTextBox2 = null;
            this.cboBacSi.Location = new System.Drawing.Point(65, 45);
            this.cboBacSi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBacSi.Name = "cboBacSi";
            this.cboBacSi.Size = new System.Drawing.Size(75, 26);
            this.cboBacSi.TabIndex = 110;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(2, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 19);
            this.label20.TabIndex = 111;
            this.label20.Text = "Bác sĩ";
            // 
            // dtpTaiKham
            // 
            this.dtpTaiKham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTaiKham.CustomFormat = "dd/MM/yyyy";
            this.dtpTaiKham.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTaiKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTaiKham.Location = new System.Drawing.Point(361, 101);
            this.dtpTaiKham.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTaiKham.Name = "dtpTaiKham";
            this.dtpTaiKham.Size = new System.Drawing.Size(106, 25);
            this.dtpTaiKham.TabIndex = 109;
            // 
            // chkTaiKham
            // 
            this.chkTaiKham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTaiKham.AutoSize = true;
            this.chkTaiKham.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTaiKham.Location = new System.Drawing.Point(255, 102);
            this.chkTaiKham.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTaiKham.Name = "chkTaiKham";
            this.chkTaiKham.Size = new System.Drawing.Size(100, 23);
            this.chkTaiKham.TabIndex = 108;
            this.chkTaiKham.Text = "Hẹn tái khám";
            this.chkTaiKham.UseVisualStyleBackColor = true;
            // 
            // txtDeNghi
            // 
            this.txtDeNghi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeNghi.Location = new System.Drawing.Point(198, 73);
            this.txtDeNghi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDeNghi.Name = "txtDeNghi";
            this.txtDeNghi.Size = new System.Drawing.Size(222, 25);
            this.txtDeNghi.TabIndex = 107;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 19);
            this.label10.TabIndex = 106;
            this.label10.Text = "Đề nghị";
            // 
            // btnLuuKQKB
            // 
            this.btnLuuKQKB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuKQKB.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuKQKB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuKQKB.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnLuuKQKB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuKQKB.ForeColor = System.Drawing.Color.Black;
            this.btnLuuKQKB.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuKQKB.Image")));
            this.btnLuuKQKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuKQKB.Location = new System.Drawing.Point(488, 101);
            this.btnLuuKQKB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuuKQKB.Name = "btnLuuKQKB";
            this.btnLuuKQKB.Size = new System.Drawing.Size(103, 25);
            this.btnLuuKQKB.TabIndex = 105;
            this.btnLuuKQKB.Text = "Lưu kết quả";
            this.btnLuuKQKB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuKQKB.UseHightLight = true;
            this.btnLuuKQKB.UseVisualStyleBackColor = true;
            this.btnLuuKQKB.Click += new System.EventHandler(this.btnLuuKQKB_Click);
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChanDoan.Location = new System.Drawing.Point(422, 48);
            this.txtChanDoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChanDoan.Size = new System.Drawing.Size(169, 51);
            this.txtChanDoan.TabIndex = 103;
            this.txtChanDoan.TabStop = false;
            // 
            // cboChanDoan
            // 
            this.cboChanDoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChanDoan.AutoComplete = false;
            this.cboChanDoan.AutoDropdown = false;
            this.cboChanDoan.BackColorEven = System.Drawing.Color.White;
            this.cboChanDoan.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboChanDoan.ColumnNames = "MaChanDoan, TenChanDoan";
            this.cboChanDoan.ColumnWidthDefault = 75;
            this.cboChanDoan.ColumnWidths = "75,150";
            this.cboChanDoan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboChanDoan.FormattingEnabled = true;
            this.cboChanDoan.LinkedColumnIndex1 = 1;
            this.cboChanDoan.LinkedColumnIndex2 = 0;
            this.cboChanDoan.LinkedTextBox1 = this.txtChanDoan;
            this.cboChanDoan.LinkedTextBox2 = null;
            this.cboChanDoan.Location = new System.Drawing.Point(494, 18);
            this.cboChanDoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboChanDoan.Name = "cboChanDoan";
            this.cboChanDoan.Size = new System.Drawing.Size(97, 26);
            this.cboChanDoan.TabIndex = 100;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(422, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 19);
            this.label16.TabIndex = 102;
            this.label16.Text = "Chẩn đoán";
            // 
            // txtCanNang
            // 
            this.txtCanNang.Location = new System.Drawing.Point(297, 19);
            this.txtCanNang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCanNang.Name = "txtCanNang";
            this.txtCanNang.Size = new System.Drawing.Size(30, 25);
            this.txtCanNang.TabIndex = 97;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 19);
            this.label11.TabIndex = 96;
            this.label11.Text = "Cân nặng";
            // 
            // txtChieuCao
            // 
            this.txtChieuCao.Location = new System.Drawing.Point(198, 19);
            this.txtChieuCao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChieuCao.Name = "txtChieuCao";
            this.txtChieuCao.Size = new System.Drawing.Size(30, 25);
            this.txtChieuCao.TabIndex = 95;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(140, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 19);
            this.label15.TabIndex = 94;
            this.label15.Text = "Chiều cao";
            // 
            // txtNhietDo
            // 
            this.txtNhietDo.Location = new System.Drawing.Point(392, 46);
            this.txtNhietDo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNhietDo.Name = "txtNhietDo";
            this.txtNhietDo.Size = new System.Drawing.Size(30, 25);
            this.txtNhietDo.TabIndex = 93;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 19);
            this.label9.TabIndex = 92;
            this.label9.Text = "Nhiệt độ";
            // 
            // txtMach
            // 
            this.txtMach.Location = new System.Drawing.Point(198, 46);
            this.txtMach.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMach.Name = "txtMach";
            this.txtMach.Size = new System.Drawing.Size(30, 25);
            this.txtMach.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 90;
            this.label7.Text = "Mạch";
            // 
            // txtHuyetAp
            // 
            this.txtHuyetAp.Location = new System.Drawing.Point(392, 19);
            this.txtHuyetAp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHuyetAp.Name = "txtHuyetAp";
            this.txtHuyetAp.Size = new System.Drawing.Size(30, 25);
            this.txtHuyetAp.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 88;
            this.label6.Text = "Huyết áp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 87;
            this.label2.Text = "Ngày khám";
            // 
            // dtpNgayKham
            // 
            this.dtpNgayKham.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKham.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKham.Location = new System.Drawing.Point(65, 19);
            this.dtpNgayKham.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpNgayKham.Name = "dtpNgayKham";
            this.dtpNgayKham.Size = new System.Drawing.Size(75, 25);
            this.dtpNgayKham.TabIndex = 86;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstThuoc);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 129);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(597, 110);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kê đơn thuốc";
            // 
            // lstThuoc
            // 
            this.lstThuoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstThuoc.CheckBoxes = true;
            this.lstThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstThuoc.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstThuoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstThuoc.GridLines = true;
            this.lstThuoc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstThuoc.Location = new System.Drawing.Point(325, 24);
            this.lstThuoc.Name = "lstThuoc";
            this.lstThuoc.Size = new System.Drawing.Size(185, 82);
            this.lstThuoc.SmallImageList = this.imageList1;
            this.lstThuoc.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstThuoc.TabIndex = 63;
            this.lstThuoc.UseCompatibleStateImageBehavior = false;
            this.lstThuoc.View = System.Windows.Forms.View.List;
            this.lstThuoc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstThuoc_ItemCheck);
            this.lstThuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstThuoc_KeyPress);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check.jpg");
            this.imageList1.Images.SetKeyName(1, "Uncheck.png");
            this.imageList1.Images.SetKeyName(2, "tag_blue_24x24.png");
            this.imageList1.Images.SetKeyName(3, "Forward_green_24x24.bmp");
            this.imageList1.Images.SetKeyName(4, "Vial-O.png");
            this.imageList1.Images.SetKeyName(5, "PatientData.png");
            this.imageList1.Images.SetKeyName(6, "Stethoscope.png");
            this.imageList1.Images.SetKeyName(7, "Syringe.png");
            this.imageList1.Images.SetKeyName(8, "UltraSound2_24x24.png");
            this.imageList1.Images.SetKeyName(9, "DienTim.jpg");
            this.imageList1.Images.SetKeyName(10, "XRay.png");
            this.imageList1.Images.SetKeyName(11, "cancel-icon.png");
            this.imageList1.Images.SetKeyName(12, "DeleteRed.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtItemName);
            this.panel1.Controls.Add(this.cboItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(164, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 82);
            this.panel1.TabIndex = 64;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtItemName.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.ForeColor = System.Drawing.Color.Crimson;
            this.txtItemName.Location = new System.Drawing.Point(5, 50);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(150, 23);
            this.txtItemName.TabIndex = 4;
            this.txtItemName.TabStop = false;
            // 
            // cboItem
            // 
            this.cboItem.AutoComplete = false;
            this.cboItem.AutoDropdown = false;
            this.cboItem.BackColorEven = System.Drawing.Color.White;
            this.cboItem.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.cboItem.ColumnNames = "";
            this.cboItem.ColumnWidthDefault = 75;
            this.cboItem.ColumnWidths = "";
            this.cboItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboItem.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItem.FormattingEnabled = true;
            this.cboItem.LinkedColumnIndex1 = 1;
            this.cboItem.LinkedColumnIndex2 = 0;
            this.cboItem.LinkedTextBox1 = this.txtItemName;
            this.cboItem.LinkedTextBox2 = null;
            this.cboItem.Location = new System.Drawing.Point(5, 21);
            this.cboItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(150, 24);
            this.cboItem.TabIndex = 2;
            this.cboItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboItem_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thuốc (T) - Profile (P)";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkDaInYC);
            this.panel5.Controls.Add(this.chkXacNhan);
            this.panel5.Controls.Add(this.btnThemThuoc);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(510, 24);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(84, 82);
            this.panel5.TabIndex = 8;
            // 
            // chkDaInYC
            // 
            this.chkDaInYC.AutoSize = true;
            this.chkDaInYC.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaInYC.Location = new System.Drawing.Point(3, 14);
            this.chkDaInYC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDaInYC.Name = "chkDaInYC";
            this.chkDaInYC.Size = new System.Drawing.Size(52, 20);
            this.chkDaInYC.TabIndex = 108;
            this.chkDaInYC.Text = "Đã in";
            this.chkDaInYC.UseVisualStyleBackColor = true;
            this.chkDaInYC.Click += new System.EventHandler(this.chkDaInYC_Click);
            // 
            // chkXacNhan
            // 
            this.chkXacNhan.AutoCheck = false;
            this.chkXacNhan.AutoSize = true;
            this.chkXacNhan.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkXacNhan.Location = new System.Drawing.Point(3, -2);
            this.chkXacNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkXacNhan.Name = "chkXacNhan";
            this.chkXacNhan.Size = new System.Drawing.Size(89, 20);
            this.chkXacNhan.TabIndex = 107;
            this.chkXacNhan.Text = "Đã xác nhận ";
            this.chkXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemThuoc.BackColor = System.Drawing.Color.Transparent;
            this.btnThemThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnThemThuoc.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemThuoc.ForeColor = System.Drawing.Color.Black;
            this.btnThemThuoc.Location = new System.Drawing.Point(4, 35);
            this.btnThemThuoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(77, 46);
            this.btnThemThuoc.TabIndex = 106;
            this.btnThemThuoc.Text = "Thêm vào đơn thuốc";
            this.btnThemThuoc.UseHightLight = true;
            this.btnThemThuoc.UseVisualStyleBackColor = true;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTenNhomThuoc);
            this.panel3.Controls.Add(this.cboNhomThuoc);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 82);
            this.panel3.TabIndex = 6;
            // 
            // txtTenNhomThuoc
            // 
            this.txtTenNhomThuoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTenNhomThuoc.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNhomThuoc.ForeColor = System.Drawing.Color.Crimson;
            this.txtTenNhomThuoc.Location = new System.Drawing.Point(5, 50);
            this.txtTenNhomThuoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenNhomThuoc.Name = "txtTenNhomThuoc";
            this.txtTenNhomThuoc.Size = new System.Drawing.Size(150, 23);
            this.txtTenNhomThuoc.TabIndex = 4;
            this.txtTenNhomThuoc.TabStop = false;
            // 
            // cboNhomThuoc
            // 
            this.cboNhomThuoc.AutoComplete = false;
            this.cboNhomThuoc.AutoDropdown = false;
            this.cboNhomThuoc.BackColorEven = System.Drawing.Color.White;
            this.cboNhomThuoc.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.cboNhomThuoc.ColumnNames = "";
            this.cboNhomThuoc.ColumnWidthDefault = 75;
            this.cboNhomThuoc.ColumnWidths = "";
            this.cboNhomThuoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomThuoc.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhomThuoc.FormattingEnabled = true;
            this.cboNhomThuoc.LinkedColumnIndex1 = 1;
            this.cboNhomThuoc.LinkedColumnIndex2 = 0;
            this.cboNhomThuoc.LinkedTextBox1 = this.txtTenNhomThuoc;
            this.cboNhomThuoc.LinkedTextBox2 = null;
            this.cboNhomThuoc.Location = new System.Drawing.Point(5, 21);
            this.cboNhomThuoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboNhomThuoc.Name = "cboNhomThuoc";
            this.cboNhomThuoc.Size = new System.Drawing.Size(150, 24);
            this.cboNhomThuoc.TabIndex = 2;
            this.cboNhomThuoc.SelectionChangeCommitted += new System.EventHandler(this.cboNhomThuoc_SelectionChangeCommitted);
            this.cboNhomThuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomThuoc_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "Nhóm thuốc";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnCheckAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.ForeColor = System.Drawing.Color.Black;
            this.btnCheckAll.Location = new System.Drawing.Point(1, 240);
            this.btnCheckAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(62, 25);
            this.btnCheckAll.TabIndex = 114;
            this.btnCheckAll.Text = "Chọn";
            this.btnCheckAll.UseHightLight = true;
            this.btnCheckAll.UseVisualStyleBackColor = true;
            // 
            // dtgChiDinhThuoc
            // 
            this.dtgChiDinhThuoc.AlignColumns = "";
            this.dtgChiDinhThuoc.AllignNumberText = false;
            this.dtgChiDinhThuoc.AllowUserToAddRows = false;
            this.dtgChiDinhThuoc.AllowUserToDeleteRows = false;
            this.dtgChiDinhThuoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgChiDinhThuoc.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgChiDinhThuoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgChiDinhThuoc.CheckBoldColumn = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgChiDinhThuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgChiDinhThuoc.ColumnHeadersHeight = 28;
            this.dtgChiDinhThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.MaThuoc,
            this.TenThuoc,
            this.SoLuong,
            this.Sang,
            this.Trua,
            this.Chieu,
            this.Toi,
            this.CachDung,
            this.DonViTinh,
            this.GhiChu,
            this.UserNhapKQ,
            this.UserSuaKQ});
            this.dtgChiDinhThuoc.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgChiDinhThuoc.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgChiDinhThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChiDinhThuoc.GridColor = System.Drawing.Color.DodgerBlue;
            this.dtgChiDinhThuoc.Location = new System.Drawing.Point(0, 239);
            this.dtgChiDinhThuoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgChiDinhThuoc.MarkOddEven = true;
            this.dtgChiDinhThuoc.MultiSelect = false;
            this.dtgChiDinhThuoc.Name = "dtgChiDinhThuoc";
            this.dtgChiDinhThuoc.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgChiDinhThuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgChiDinhThuoc.RowHeadersVisible = false;
            this.dtgChiDinhThuoc.RowHeadersWidth = 20;
            this.dtgChiDinhThuoc.RowTemplate.DividerHeight = 1;
            this.dtgChiDinhThuoc.RowTemplate.Height = 28;
            this.dtgChiDinhThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgChiDinhThuoc.Size = new System.Drawing.Size(597, 140);
            this.dtgChiDinhThuoc.TabIndex = 112;
            this.dtgChiDinhThuoc.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgChiDinhThuoc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgChiDinhThuoc_CellEndEdit);
            // 
            // Select
            // 
            this.Select.Frozen = true;
            this.Select.HeaderText = "Chọn";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Select.Width = 60;
            // 
            // MaThuoc
            // 
            this.MaThuoc.DataPropertyName = "MaThuoc";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            this.MaThuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaThuoc.HeaderText = "Mã thuốc";
            this.MaThuoc.Name = "MaThuoc";
            this.MaThuoc.ReadOnly = true;
            this.MaThuoc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MaThuoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaThuoc.Visible = false;
            // 
            // TenThuoc
            // 
            this.TenThuoc.DataPropertyName = "TenThuoc";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.TenThuoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.TenThuoc.Frozen = true;
            this.TenThuoc.HeaderText = "Tên thuốc";
            this.TenThuoc.Name = "TenThuoc";
            this.TenThuoc.ReadOnly = true;
            this.TenThuoc.Width = 300;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Crimson;
            this.SoLuong.DefaultCellStyle = dataGridViewCellStyle4;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 80;
            // 
            // Sang
            // 
            this.Sang.DataPropertyName = "Sang";
            this.Sang.HeaderText = "Sáng ";
            this.Sang.Name = "Sang";
            this.Sang.Width = 50;
            // 
            // Trua
            // 
            this.Trua.DataPropertyName = "Trua";
            this.Trua.HeaderText = "Trưa";
            this.Trua.Name = "Trua";
            this.Trua.Width = 50;
            // 
            // Chieu
            // 
            this.Chieu.DataPropertyName = "Chieu";
            this.Chieu.HeaderText = "Chiều";
            this.Chieu.Name = "Chieu";
            this.Chieu.Width = 50;
            // 
            // Toi
            // 
            this.Toi.DataPropertyName = "Toi";
            this.Toi.HeaderText = "Tối";
            this.Toi.Name = "Toi";
            this.Toi.Width = 50;
            // 
            // CachDung
            // 
            this.CachDung.DataPropertyName = "CachDung";
            this.CachDung.HeaderText = "Cách dùng";
            this.CachDung.Name = "CachDung";
            this.CachDung.Width = 120;
            // 
            // DonViTinh
            // 
            this.DonViTinh.DataPropertyName = "DonViTinh";
            this.DonViTinh.HeaderText = "Đơn vị";
            this.DonViTinh.Name = "DonViTinh";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 200;
            // 
            // UserNhapKQ
            // 
            this.UserNhapKQ.DataPropertyName = "UserNhapKQ";
            this.UserNhapKQ.HeaderText = "UserNhap";
            this.UserNhapKQ.Name = "UserNhapKQ";
            this.UserNhapKQ.Visible = false;
            // 
            // UserSuaKQ
            // 
            this.UserSuaKQ.DataPropertyName = "UserSuaKQ";
            this.UserSuaKQ.HeaderText = "UserSua";
            this.UserSuaKQ.Name = "UserSuaKQ";
            this.UserSuaKQ.Visible = false;
            // 
            // bvChiDinhThuoc
            // 
            this.bvChiDinhThuoc.AddNewItem = null;
            this.bvChiDinhThuoc.CountItem = this.bindingNavigatorCountItem;
            this.bvChiDinhThuoc.CountItemFormat = "/ {0}";
            this.bvChiDinhThuoc.DeleteItem = null;
            this.bvChiDinhThuoc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvChiDinhThuoc.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold);
            this.bvChiDinhThuoc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvChiDinhThuoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCheckItem,
            this.toolStripSeparator1,
            this.btnPreview,
            this.toolStripSeparator3,
            this.btnPrint,
            this.toolStripSeparator6,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.btnRefreshResult,
            this.toolStripSeparator4,
            this.btnValidResult,
            this.toolStripSeparator5,
            this.btnDeleteItem,
            this.progressPrint,
            this.toolStripSeparator2});
            this.bvChiDinhThuoc.Location = new System.Drawing.Point(0, 379);
            this.bvChiDinhThuoc.MoveFirstItem = null;
            this.bvChiDinhThuoc.MoveLastItem = null;
            this.bvChiDinhThuoc.MoveNextItem = null;
            this.bvChiDinhThuoc.MovePreviousItem = null;
            this.bvChiDinhThuoc.Name = "bvChiDinhThuoc";
            this.bvChiDinhThuoc.PositionItem = this.bindingNavigatorPositionItem;
            this.bvChiDinhThuoc.Size = new System.Drawing.Size(597, 25);
            this.bvChiDinhThuoc.TabIndex = 113;
            this.bvChiDinhThuoc.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Font = new System.Drawing.Font("Roboto Condensed", 9F);
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // btnCheckItem
            // 
            this.btnCheckItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCheckItem.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckItem.Image")));
            this.btnCheckItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckItem.Name = "btnCheckItem";
            this.btnCheckItem.Size = new System.Drawing.Size(23, 22);
            this.btnCheckItem.Text = "Check";
            this.btnCheckItem.Click += new System.EventHandler(this.btnCheckItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(78, 22);
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 22);
            this.btnPrint.Text = "In đơn thuốc";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Roboto Condensed", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(30, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefreshResult
            // 
            this.btnRefreshResult.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshResult.Image")));
            this.btnRefreshResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshResult.Name = "btnRefreshResult";
            this.btnRefreshResult.Size = new System.Drawing.Size(70, 22);
            this.btnRefreshResult.Text = "Làm mới";
            this.btnRefreshResult.Click += new System.EventHandler(this.btnRefreshResult_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnValidResult
            // 
            this.btnValidResult.Image = ((System.Drawing.Image)(resources.GetObject("btnValidResult.Image")));
            this.btnValidResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidResult.Name = "btnValidResult";
            this.btnValidResult.Size = new System.Drawing.Size(73, 22);
            this.btnValidResult.Text = "Xác nhận";
            this.btnValidResult.Click += new System.EventHandler(this.btnValidResult_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(77, 22);
            this.btnDeleteItem.Text = "Xóa thuốc";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // progressPrint
            // 
            this.progressPrint.Name = "progressPrint";
            this.progressPrint.Size = new System.Drawing.Size(70, 26);
            this.progressPrint.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCheckAll);
            this.panel4.Controls.Add(this.dtgChiDinhThuoc);
            this.panel4.Controls.Add(this.bvChiDinhThuoc);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.gbResultInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(597, 404);
            this.panel4.TabIndex = 116;
            // 
            // FrmKhamLamSang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(613, 467);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmKhamLamSang";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text = "Khám lâm sàng";
            this.Load += new System.EventHandler(this.FrmKhamLamSang_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.gbResultInfo.ResumeLayout(false);
            this.gbResultInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiDinhThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiDinhThuoc)).EndInit();
            this.bvChiDinhThuoc.ResumeLayout(false);
            this.bvChiDinhThuoc.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResultInfo;
        private System.Windows.Forms.TextBox txtCanNang;
        private DevExpress.XtraEditors.LabelControl label11;
        private System.Windows.Forms.TextBox txtChieuCao;
        private DevExpress.XtraEditors.LabelControl label15;
        private System.Windows.Forms.TextBox txtNhietDo;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.TextBox txtMach;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtHuyetAp;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.DateTimePicker dtpNgayKham;
        private CustomComboBox cboChanDoan;
        private DevExpress.XtraEditors.LabelControl label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTenNhomThuoc;
        private CustomComboBox cboNhomThuoc;
        private DevExpress.XtraEditors.LabelControl label19;
        private TPH.Controls.TPHNormalButton btnCheckAll;
        private CustomDatagridView dtgChiDinhThuoc;
        private CustomBindingNavigator bvChiDinhThuoc;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefreshResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnValidResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDeleteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripProgressBar progressPrint;
        private TPH.Controls.TPHNormalButton btnLuuKQKB;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.TextBox txtDeNghi;
        private DevExpress.XtraEditors.LabelControl label10;
        private System.Windows.Forms.TextBox txtNhipTho;
        private DevExpress.XtraEditors.LabelControl label21;
        private System.Windows.Forms.TextBox txtTenBacSi;
        private CustomComboBox cboBacSi;
        private DevExpress.XtraEditors.LabelControl label20;
        private System.Windows.Forms.DateTimePicker dtpTaiKham;
        private System.Windows.Forms.CheckBox chkTaiKham;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl label22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toi;
        private System.Windows.Forms.DataGridViewComboBoxColumn CachDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNhapKQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserSuaKQ;
        private DevExpress.XtraEditors.PanelControl panel4;
        private DevExpress.XtraEditors.PanelControl panel5;
        private TPH.Controls.TPHNormalButton btnThemThuoc;
        private DevExpress.XtraEditors.PanelControl panel3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lstThuoc;
        private System.Windows.Forms.ToolStripButton btnCheckItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox chkDaInYC;
        private System.Windows.Forms.CheckBox chkXacNhan;
        private DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.TextBox txtItemName;
        private CustomComboBox cboItem;
        private DevExpress.XtraEditors.LabelControl label1;

    }
}