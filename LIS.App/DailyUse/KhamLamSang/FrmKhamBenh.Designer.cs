using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi.KhamLamSang
{
    partial class FrmKhamBenh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKhamBenh));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkDaInYC = new System.Windows.Forms.CheckBox();
            this.chkXacNhan = new System.Windows.Forms.CheckBox();
            this.dtgPatient = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaInKQ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DuKQ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DaXacNhanKQ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KetLuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuChiDinhCLS = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearchSEQ = new TPH.Controls.TPHNormalButton();
            this.radPrinted = new System.Windows.Forms.RadioButton();
            this.radAllPrint = new System.Windows.Forms.RadioButton();
            this.radNotPrint = new System.Windows.Forms.RadioButton();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.txtSEQ = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.bvPatient = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnMFirst = new System.Windows.Forms.ToolStripButton();
            this.btnMBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnmNext = new System.Windows.Forms.ToolStripButton();
            this.btnMoveLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshList = new System.Windows.Forms.ToolStripButton();
            this.panel5 = new DevExpress.XtraEditors.PanelControl();
            this.btnKqetQuaXN = new TPH.Controls.TPHNormalButton();
            this.btnChiDinhDichVu = new TPH.Controls.TPHNormalButton();
            this.listPrinter = new System.Windows.Forms.ListBox();
            this.cmdRefreshPrinter = new TPH.Controls.TPHNormalButton();
            this.txtDoctorSend = new System.Windows.Forms.TextBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtServiceID = new System.Windows.Forms.TextBox();
            this.txtTenYeuCauKhamBenh = new System.Windows.Forms.TextBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.cboYeuCauKhamBenh = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtTGIn = new System.Windows.Forms.TextBox();
            this.txtLanIn = new System.Windows.Forms.TextBox();
            this.txtTienSu = new System.Windows.Forms.TextBox();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSID = new System.Windows.Forms.TextBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.chkAgeType = new System.Windows.Forms.CheckBox();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.chkDaIn = new System.Windows.Forms.CheckBox();
            this.chkDaXacNhan = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radReturn = new System.Windows.Forms.RadioButton();
            this.radFirstTime = new System.Windows.Forms.RadioButton();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label22 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhipTho = new System.Windows.Forms.TextBox();
            this.label21 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenBacSi = new System.Windows.Forms.TextBox();
            this.cboBacSi = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label20 = new DevExpress.XtraEditors.LabelControl();
            this.dtpTaiKham = new System.Windows.Forms.DateTimePicker();
            this.chkTaiKham = new System.Windows.Forms.CheckBox();
            this.txtDeNghi = new System.Windows.Forms.TextBox();
            this.label11 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuuKQKB = new TPH.Controls.TPHNormalButton();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.cboChanDoan = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label16 = new DevExpress.XtraEditors.LabelControl();
            this.txtCanNang = new System.Windows.Forms.TextBox();
            this.label14 = new DevExpress.XtraEditors.LabelControl();
            this.txtChieuCao = new System.Windows.Forms.TextBox();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhietDo = new System.Windows.Forms.TextBox();
            this.label17 = new DevExpress.XtraEditors.LabelControl();
            this.txtMach = new System.Windows.Forms.TextBox();
            this.label18 = new DevExpress.XtraEditors.LabelControl();
            this.txtHuyetAp = new System.Windows.Forms.TextBox();
            this.label19 = new DevExpress.XtraEditors.LabelControl();
            this.label23 = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgayKham = new System.Windows.Forms.DateTimePicker();
            this.splitContainer2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainer3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnThemThuoc = new TPH.Controls.TPHNormalButton();
            this.panel8 = new DevExpress.XtraEditors.PanelControl();
            this.cboNhomThuoc = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label25 = new DevExpress.XtraEditors.LabelControl();
            this.gcThuoc = new DevExpress.XtraGrid.GridControl();
            this.gvThuoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaThuoc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.splitContainer4 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.gcToaThuoc = new DevExpress.XtraGrid.GridControl();
            this.gvToaThuoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenThuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCachDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDonviTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel7 = new DevExpress.XtraEditors.PanelControl();
            this.btnLuuThanhToan = new TPH.Controls.TPHNormalButton();
            this.label26 = new DevExpress.XtraEditors.LabelControl();
            this.txtThanhToan = new System.Windows.Forms.TextBox();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.bvChiDinhThuoc = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.btnPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshResult = new System.Windows.Forms.ToolStripButton();
            this.btnValidResult = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.progressPrint = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gcToaThuocHistory = new DevExpress.XtraGrid.GridControl();
            this.gvToaThuocHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.panel11 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtMSBenhNhan = new System.Windows.Forms.TextBox();
            this.label24 = new DevExpress.XtraEditors.LabelControl();
            this.gbDonThuoc = new DevExpress.XtraEditors.GroupControl();
            this.panel13 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.panel12 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatient)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatient)).BeginInit();
            this.bvPatient.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcToaThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvToaThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiDinhThuoc)).BeginInit();
            this.bvChiDinhThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcToaThuocHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvToaThuocHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDonThuoc)).BeginInit();
            this.gbDonThuoc.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(4, 7);
            this.lblTitle.Size = new System.Drawing.Size(994, 24);
            this.lblTitle.Text = "KHÁM BỆNH";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.splitContainer1);
            this.pnContaint.Location = new System.Drawing.Point(3, 36);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnContaint.Size = new System.Drawing.Size(1002, 623);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(-758, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(645, 7);
            this.lblMainESC.Size = new System.Drawing.Size(353, 24);
            // 
            // chkDaInYC
            // 
            this.chkDaInYC.AutoSize = true;
            this.chkDaInYC.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaInYC.Location = new System.Drawing.Point(340, 34);
            this.chkDaInYC.Name = "chkDaInYC";
            this.chkDaInYC.Size = new System.Drawing.Size(51, 17);
            this.chkDaInYC.TabIndex = 108;
            this.chkDaInYC.Text = "Đã in";
            this.chkDaInYC.UseVisualStyleBackColor = true;
            this.chkDaInYC.Visible = false;
            this.chkDaInYC.Click += new System.EventHandler(this.chkDaInYC_Click);
            // 
            // chkXacNhan
            // 
            this.chkXacNhan.AutoCheck = false;
            this.chkXacNhan.AutoSize = true;
            this.chkXacNhan.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkXacNhan.Location = new System.Drawing.Point(340, 9);
            this.chkXacNhan.Name = "chkXacNhan";
            this.chkXacNhan.Size = new System.Drawing.Size(88, 17);
            this.chkXacNhan.TabIndex = 107;
            this.chkXacNhan.Text = "Đã xác nhận ";
            this.chkXacNhan.UseVisualStyleBackColor = true;
            this.chkXacNhan.Visible = false;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPatient.ColumnHeadersHeight = 28;
            this.dtgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.SEQ,
            this.TenBN,
            this.DaInKQ,
            this.DuKQ,
            this.DaXacNhanKQ,
            this.KetLuan,
            this.DateIn,
            this.MaTiepNhan});
            this.dtgPatient.ContextMenuStrip = this.contextMenuStrip1;
            this.dtgPatient.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPatient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPatient.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgPatient.Location = new System.Drawing.Point(2, 82);
            this.dtgPatient.MarkOddEven = true;
            this.dtgPatient.MultiSelect = false;
            this.dtgPatient.Name = "dtgPatient";
            this.dtgPatient.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgPatient.RowHeadersWidth = 25;
            this.dtgPatient.Size = new System.Drawing.Size(388, 224);
            this.dtgPatient.TabIndex = 94;
            this.dtgPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatient_CellClick);
            this.dtgPatient.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatient_CellEnter);
            // 
            // Chon
            // 
            this.Chon.DataPropertyName = "Chon";
            this.Chon.HeaderText = "Chọn";
            this.Chon.Name = "Chon";
            this.Chon.ReadOnly = true;
            this.Chon.Visible = false;
            // 
            // SEQ
            // 
            this.SEQ.DataPropertyName = "SEQ";
            this.SEQ.HeaderText = "Số thứ tự";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            this.SEQ.Width = 70;
            // 
            // TenBN
            // 
            this.TenBN.DataPropertyName = "TenBN";
            this.TenBN.HeaderText = "Tên bệnh nhân";
            this.TenBN.Name = "TenBN";
            this.TenBN.ReadOnly = true;
            this.TenBN.Width = 200;
            // 
            // DaInKQ
            // 
            this.DaInKQ.DataPropertyName = "DaInKQXN";
            this.DaInKQ.HeaderText = "Đã in";
            this.DaInKQ.Name = "DaInKQ";
            this.DaInKQ.ReadOnly = true;
            this.DaInKQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DaInKQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DaInKQ.Width = 70;
            // 
            // DuKQ
            // 
            this.DuKQ.DataPropertyName = "DuKQXN";
            this.DuKQ.HeaderText = "Đủ KQ";
            this.DuKQ.Name = "DuKQ";
            this.DuKQ.ReadOnly = true;
            this.DuKQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DuKQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DuKQ.Width = 80;
            // 
            // DaXacNhanKQ
            // 
            this.DaXacNhanKQ.DataPropertyName = "ValidKQXN";
            this.DaXacNhanKQ.HeaderText = "Đã xác nhận KQ";
            this.DaXacNhanKQ.Name = "DaXacNhanKQ";
            this.DaXacNhanKQ.ReadOnly = true;
            this.DaXacNhanKQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DaXacNhanKQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DaXacNhanKQ.Width = 150;
            // 
            // KetLuan
            // 
            this.KetLuan.DataPropertyName = "KetLuanXN";
            this.KetLuan.HeaderText = "Kết luận";
            this.KetLuan.Name = "KetLuan";
            this.KetLuan.ReadOnly = true;
            this.KetLuan.Width = 150;
            // 
            // DateIn
            // 
            this.DateIn.DataPropertyName = "NgayTiepNhan";
            this.DateIn.HeaderText = "NgayTiepNhan";
            this.DateIn.Name = "DateIn";
            this.DateIn.ReadOnly = true;
            this.DateIn.Visible = false;
            // 
            // MaTiepNhan
            // 
            this.MaTiepNhan.DataPropertyName = "MaTiepNhan";
            this.MaTiepNhan.HeaderText = "Mã tiếp nhận";
            this.MaTiepNhan.Name = "MaTiepNhan";
            this.MaTiepNhan.ReadOnly = true;
            this.MaTiepNhan.Width = 130;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChiDinhCLS});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 30);
            // 
            // mnuChiDinhCLS
            // 
            this.mnuChiDinhCLS.Image = ((System.Drawing.Image)(resources.GetObject("mnuChiDinhCLS.Image")));
            this.mnuChiDinhCLS.Name = "mnuChiDinhCLS";
            this.mnuChiDinhCLS.Size = new System.Drawing.Size(146, 26);
            this.mnuChiDinhCLS.Text = "Chỉ định CLS";
            this.mnuChiDinhCLS.Click += new System.EventHandler(this.mnuChiDinhCLS_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSearchSEQ);
            this.panel6.Controls.Add(this.radPrinted);
            this.panel6.Controls.Add(this.radAllPrint);
            this.panel6.Controls.Add(this.radNotPrint);
            this.panel6.Controls.Add(this.chkDaInYC);
            this.panel6.Controls.Add(this.chkXacNhan);
            this.panel6.Controls.Add(this.dtpDateIn);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.txtSEQ);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 22);
            this.panel6.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(388, 60);
            this.panel6.TabIndex = 93;
            // 
            // btnSearchSEQ
            // 
            this.btnSearchSEQ.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchSEQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchSEQ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSEQ.ForeColor = System.Drawing.Color.Black;
            this.btnSearchSEQ.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSEQ.Image")));
            this.btnSearchSEQ.Location = new System.Drawing.Point(329, 28);
            this.btnSearchSEQ.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnSearchSEQ.Name = "btnSearchSEQ";
            this.btnSearchSEQ.Size = new System.Drawing.Size(35, 27);
            this.btnSearchSEQ.TabIndex = 91;
            this.btnSearchSEQ.UseVisualStyleBackColor = false;
            this.btnSearchSEQ.Click += new System.EventHandler(this.btnTimBN_Click);
            // 
            // radPrinted
            // 
            this.radPrinted.AutoSize = true;
            this.radPrinted.Location = new System.Drawing.Point(187, 4);
            this.radPrinted.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radPrinted.Name = "radPrinted";
            this.radPrinted.Size = new System.Drawing.Size(54, 19);
            this.radPrinted.TabIndex = 117;
            this.radPrinted.Text = "Đã in";
            this.radPrinted.UseVisualStyleBackColor = true;
            this.radPrinted.Click += new System.EventHandler(this.radAllPrint_Click);
            // 
            // radAllPrint
            // 
            this.radAllPrint.AutoSize = true;
            this.radAllPrint.Location = new System.Drawing.Point(325, 4);
            this.radAllPrint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radAllPrint.Name = "radAllPrint";
            this.radAllPrint.Size = new System.Drawing.Size(58, 19);
            this.radAllPrint.TabIndex = 119;
            this.radAllPrint.Text = "Tất cả";
            this.radAllPrint.UseVisualStyleBackColor = true;
            this.radAllPrint.Click += new System.EventHandler(this.radAllPrint_Click);
            // 
            // radNotPrint
            // 
            this.radNotPrint.AutoSize = true;
            this.radNotPrint.Checked = true;
            this.radNotPrint.Location = new System.Drawing.Point(249, 4);
            this.radNotPrint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.radNotPrint.Name = "radNotPrint";
            this.radNotPrint.Size = new System.Drawing.Size(69, 19);
            this.radNotPrint.TabIndex = 118;
            this.radNotPrint.TabStop = true;
            this.radNotPrint.Text = "Chưa in";
            this.radNotPrint.UseVisualStyleBackColor = true;
            this.radNotPrint.Click += new System.EventHandler(this.radAllPrint_Click);
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy";
            this.dtpDateIn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(72, 3);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(109, 21);
            this.dtpDateIn.TabIndex = 61;
            this.dtpDateIn.ValueChanged += new System.EventHandler(this.dtpDateIn_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 62;
            this.label8.Text = "Ngày";
            // 
            // txtSEQ
            // 
            this.txtSEQ.Location = new System.Drawing.Point(72, 30);
            this.txtSEQ.MaxLength = 6;
            this.txtSEQ.Name = "txtSEQ";
            this.txtSEQ.Size = new System.Drawing.Size(251, 21);
            this.txtSEQ.TabIndex = 49;
            this.txtSEQ.Click += new System.EventHandler(this.txtSEQ_Click);
            this.txtSEQ.TextChanged += new System.EventHandler(this.txtSEQ_TextChanged);
            this.txtSEQ.Enter += new System.EventHandler(this.txtSEQ_Enter);
            this.txtSEQ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSEQ_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "Số thứ tự";
            // 
            // bvPatient
            // 
            this.bvPatient.AddNewItem = null;
            this.bvPatient.CountItem = this.toolStripLabel1;
            this.bvPatient.CountItemFormat = "/ {0}";
            this.bvPatient.DeleteItem = null;
            this.bvPatient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvPatient.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold);
            this.bvPatient.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvPatient.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvPatient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMFirst,
            this.btnMBack,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.btnmNext,
            this.btnMoveLast,
            this.toolStripButton1,
            this.btnRefreshList});
            this.bvPatient.Location = new System.Drawing.Point(2, 306);
            this.bvPatient.MoveFirstItem = this.btnMFirst;
            this.bvPatient.MoveLastItem = this.btnMoveLast;
            this.bvPatient.MoveNextItem = this.btnmNext;
            this.bvPatient.MovePreviousItem = this.btnMBack;
            this.bvPatient.Name = "bvPatient";
            this.bvPatient.PositionItem = this.toolStripTextBox1;
            this.bvPatient.Size = new System.Drawing.Size(388, 27);
            this.bvPatient.TabIndex = 84;
            this.bvPatient.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 24);
            this.toolStripLabel1.Text = "/ {0}";
            this.toolStripLabel1.ToolTipText = "Total number of items";
            // 
            // btnMFirst
            // 
            this.btnMFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnMFirst.Image")));
            this.btnMFirst.Name = "btnMFirst";
            this.btnMFirst.RightToLeftAutoMirrorImage = true;
            this.btnMFirst.Size = new System.Drawing.Size(24, 24);
            this.btnMFirst.Text = "Move first";
            // 
            // btnMBack
            // 
            this.btnMBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMBack.Image = ((System.Drawing.Image)(resources.GetObject("btnMBack.Image")));
            this.btnMBack.Name = "btnMBack";
            this.btnMBack.RightToLeftAutoMirrorImage = true;
            this.btnMBack.Size = new System.Drawing.Size(24, 24);
            this.btnMBack.Text = "Move previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(44, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Current position";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnmNext
            // 
            this.btnmNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmNext.Image = ((System.Drawing.Image)(resources.GetObject("btnmNext.Image")));
            this.btnmNext.Name = "btnmNext";
            this.btnmNext.RightToLeftAutoMirrorImage = true;
            this.btnmNext.Size = new System.Drawing.Size(24, 24);
            this.btnmNext.Text = "Move next";
            // 
            // btnMoveLast
            // 
            this.btnMoveLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveLast.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLast.Image")));
            this.btnMoveLast.Name = "btnMoveLast";
            this.btnMoveLast.RightToLeftAutoMirrorImage = true;
            this.btnMoveLast.Size = new System.Drawing.Size(24, 24);
            this.btnMoveLast.Text = "Move last";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshList.Image")));
            this.btnRefreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(139, 24);
            this.btnRefreshList.Text = "Làm mới danh sách";
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnKqetQuaXN);
            this.panel5.Controls.Add(this.btnChiDinhDichVu);
            this.panel5.Controls.Add(this.listPrinter);
            this.panel5.Controls.Add(this.cmdRefreshPrinter);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 333);
            this.panel5.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(388, 73);
            this.panel5.TabIndex = 92;
            // 
            // btnKqetQuaXN
            // 
            this.btnKqetQuaXN.BackColor = System.Drawing.Color.Transparent;
            this.btnKqetQuaXN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKqetQuaXN.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKqetQuaXN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKqetQuaXN.ForeColor = System.Drawing.Color.Black;
            this.btnKqetQuaXN.Image = ((System.Drawing.Image)(resources.GetObject("btnKqetQuaXN.Image")));
            this.btnKqetQuaXN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKqetQuaXN.Location = new System.Drawing.Point(253, 0);
            this.btnKqetQuaXN.Name = "btnKqetQuaXN";
            this.btnKqetQuaXN.Size = new System.Drawing.Size(69, 73);
            this.btnKqetQuaXN.TabIndex = 91;
            this.btnKqetQuaXN.Text = "Xem KQ XN";
            this.btnKqetQuaXN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKqetQuaXN.UseVisualStyleBackColor = false;
            this.btnKqetQuaXN.Click += new System.EventHandler(this.btnKqetQuaXN_Click);
            // 
            // btnChiDinhDichVu
            // 
            this.btnChiDinhDichVu.BackColor = System.Drawing.Color.Transparent;
            this.btnChiDinhDichVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChiDinhDichVu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChiDinhDichVu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiDinhDichVu.ForeColor = System.Drawing.Color.Black;
            this.btnChiDinhDichVu.Image = ((System.Drawing.Image)(resources.GetObject("btnChiDinhDichVu.Image")));
            this.btnChiDinhDichVu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChiDinhDichVu.Location = new System.Drawing.Point(322, 0);
            this.btnChiDinhDichVu.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnChiDinhDichVu.Name = "btnChiDinhDichVu";
            this.btnChiDinhDichVu.Size = new System.Drawing.Size(66, 73);
            this.btnChiDinhDichVu.TabIndex = 0;
            this.btnChiDinhDichVu.Text = "Chỉ định CLS";
            this.btnChiDinhDichVu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChiDinhDichVu.UseVisualStyleBackColor = false;
            this.btnChiDinhDichVu.Click += new System.EventHandler(this.custom_Button1_Click);
            // 
            // listPrinter
            // 
            this.listPrinter.Dock = System.Windows.Forms.DockStyle.Left;
            this.listPrinter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPrinter.FormattingEnabled = true;
            this.listPrinter.HorizontalScrollbar = true;
            this.listPrinter.ItemHeight = 14;
            this.listPrinter.Location = new System.Drawing.Point(0, 0);
            this.listPrinter.Name = "listPrinter";
            this.listPrinter.Size = new System.Drawing.Size(219, 73);
            this.listPrinter.TabIndex = 85;
            this.listPrinter.SelectedIndexChanged += new System.EventHandler(this.listPrinter_SelectedIndexChanged);
            // 
            // cmdRefreshPrinter
            // 
            this.cmdRefreshPrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefreshPrinter.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefreshPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdRefreshPrinter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefreshPrinter.ForeColor = System.Drawing.Color.Black;
            this.cmdRefreshPrinter.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefreshPrinter.Image")));
            this.cmdRefreshPrinter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdRefreshPrinter.Location = new System.Drawing.Point(222, 49);
            this.cmdRefreshPrinter.Name = "cmdRefreshPrinter";
            this.cmdRefreshPrinter.Size = new System.Drawing.Size(29, 23);
            this.cmdRefreshPrinter.TabIndex = 90;
            this.cmdRefreshPrinter.UseVisualStyleBackColor = true;
            // 
            // txtDoctorSend
            // 
            this.txtDoctorSend.ForeColor = System.Drawing.Color.DarkRed;
            this.txtDoctorSend.Location = new System.Drawing.Point(74, 124);
            this.txtDoctorSend.Name = "txtDoctorSend";
            this.txtDoctorSend.ReadOnly = true;
            this.txtDoctorSend.Size = new System.Drawing.Size(314, 21);
            this.txtDoctorSend.TabIndex = 131;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 130;
            this.label7.Text = "BS CĐ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtServiceID
            // 
            this.txtServiceID.Font = new System.Drawing.Font("Arial", 9F);
            this.txtServiceID.Location = new System.Drawing.Point(74, 27);
            this.txtServiceID.Name = "txtServiceID";
            this.txtServiceID.ReadOnly = true;
            this.txtServiceID.Size = new System.Drawing.Size(52, 21);
            this.txtServiceID.TabIndex = 129;
            // 
            // txtTenYeuCauKhamBenh
            // 
            this.txtTenYeuCauKhamBenh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenYeuCauKhamBenh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTenYeuCauKhamBenh.ForeColor = System.Drawing.Color.Crimson;
            this.txtTenYeuCauKhamBenh.Location = new System.Drawing.Point(134, 27);
            this.txtTenYeuCauKhamBenh.Name = "txtTenYeuCauKhamBenh";
            this.txtTenYeuCauKhamBenh.ReadOnly = true;
            this.txtTenYeuCauKhamBenh.Size = new System.Drawing.Size(202, 21);
            this.txtTenYeuCauKhamBenh.TabIndex = 128;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(5, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 21);
            this.label6.TabIndex = 127;
            this.label6.Text = "Yêu cầu";
            // 
            // cboYeuCauKhamBenh
            // 
            this.cboYeuCauKhamBenh.AutoComplete = false;
            this.cboYeuCauKhamBenh.AutoDropdown = false;
            this.cboYeuCauKhamBenh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cboYeuCauKhamBenh.BackColorEven = System.Drawing.Color.White;
            this.cboYeuCauKhamBenh.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboYeuCauKhamBenh.ColumnNames = "";
            this.cboYeuCauKhamBenh.ColumnWidthDefault = 75;
            this.cboYeuCauKhamBenh.ColumnWidths = "";
            this.cboYeuCauKhamBenh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboYeuCauKhamBenh.ForeColor = System.Drawing.Color.Crimson;
            this.cboYeuCauKhamBenh.FormattingEnabled = true;
            this.cboYeuCauKhamBenh.LinkedColumnIndex = 0;
            this.cboYeuCauKhamBenh.LinkedColumnIndex1 = 0;
            this.cboYeuCauKhamBenh.LinkedColumnIndex2 = 0;
            this.cboYeuCauKhamBenh.LinkedTextBox = null;
            this.cboYeuCauKhamBenh.LinkedTextBox1 = null;
            this.cboYeuCauKhamBenh.LinkedTextBox2 = null;
            this.cboYeuCauKhamBenh.Location = new System.Drawing.Point(63, 27);
            this.cboYeuCauKhamBenh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboYeuCauKhamBenh.Name = "cboYeuCauKhamBenh";
            this.cboYeuCauKhamBenh.Size = new System.Drawing.Size(68, 22);
            this.cboYeuCauKhamBenh.TabIndex = 126;
            this.cboYeuCauKhamBenh.SelectionChangeCommitted += new System.EventHandler(this.cboYeuCauKhamBenh_SelectionChangeCommitted);
            // 
            // txtTGIn
            // 
            this.txtTGIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTGIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtTGIn.Location = new System.Drawing.Point(491, 26);
            this.txtTGIn.MaxLength = 5;
            this.txtTGIn.Name = "txtTGIn";
            this.txtTGIn.ReadOnly = true;
            this.txtTGIn.Size = new System.Drawing.Size(103, 21);
            this.txtTGIn.TabIndex = 82;
            this.txtTGIn.Visible = false;
            // 
            // txtLanIn
            // 
            this.txtLanIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLanIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtLanIn.Location = new System.Drawing.Point(467, 26);
            this.txtLanIn.MaxLength = 5;
            this.txtLanIn.Name = "txtLanIn";
            this.txtLanIn.ReadOnly = true;
            this.txtLanIn.Size = new System.Drawing.Size(23, 21);
            this.txtLanIn.TabIndex = 80;
            this.txtLanIn.Visible = false;
            // 
            // txtTienSu
            // 
            this.txtTienSu.Location = new System.Drawing.Point(116, 176);
            this.txtTienSu.Multiline = true;
            this.txtTienSu.Name = "txtTienSu";
            this.txtTienSu.ReadOnly = true;
            this.txtTienSu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTienSu.Size = new System.Drawing.Size(272, 23);
            this.txtTienSu.TabIndex = 125;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 124;
            this.label13.Text = "Tiền sử bệnh";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(116, 149);
            this.txtTinhTrang.Multiline = true;
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.ReadOnly = true;
            this.txtTinhTrang.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTinhTrang.Size = new System.Drawing.Size(272, 23);
            this.txtTinhTrang.TabIndex = 123;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 122;
            this.label2.Text = "Tình trạng ban đầu";
            // 
            // txtSID
            // 
            this.txtSID.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSID.Location = new System.Drawing.Point(129, 27);
            this.txtSID.Name = "txtSID";
            this.txtSID.ReadOnly = true;
            this.txtSID.Size = new System.Drawing.Size(92, 21);
            this.txtSID.TabIndex = 84;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 15);
            this.label10.TabIndex = 83;
            this.label10.Text = "Mã TN";
            // 
            // txtTenBN
            // 
            this.txtTenBN.Font = new System.Drawing.Font("Arial", 9F);
            this.txtTenBN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTenBN.Location = new System.Drawing.Point(74, 50);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.ReadOnly = true;
            this.txtTenBN.Size = new System.Drawing.Size(314, 21);
            this.txtTenBN.TabIndex = 52;
            this.txtTenBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 51;
            this.label3.Text = "Họ tên";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Checked = false;
            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Enabled = false;
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(150, 74);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(99, 21);
            this.dtpBirthday.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 55;
            this.label5.Text = "Năm sinh";
            // 
            // txtAge
            // 
            this.txtAge.Font = new System.Drawing.Font("Arial", 9F);
            this.txtAge.Location = new System.Drawing.Point(74, 75);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(52, 21);
            this.txtAge.TabIndex = 56;
            // 
            // chkAgeType
            // 
            this.chkAgeType.AutoSize = true;
            this.chkAgeType.Enabled = false;
            this.chkAgeType.Location = new System.Drawing.Point(131, 78);
            this.chkAgeType.Name = "chkAgeType";
            this.chkAgeType.Size = new System.Drawing.Size(15, 14);
            this.chkAgeType.TabIndex = 65;
            this.chkAgeType.UseVisualStyleBackColor = true;
            // 
            // txtSex
            // 
            this.txtSex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSex.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSex.Location = new System.Drawing.Point(317, 74);
            this.txtSex.MaxLength = 1;
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(30, 21);
            this.txtSex.TabIndex = 67;
            this.txtSex.TextChanged += new System.EventHandler(this.txtSex_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(255, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 66;
            this.label12.Text = "Giới tính";
            // 
            // lblSex
            // 
            this.lblSex.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblSex.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSex.Location = new System.Drawing.Point(351, 74);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(37, 22);
            this.lblSex.TabIndex = 68;
            // 
            // chkDaIn
            // 
            this.chkDaIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDaIn.AutoCheck = false;
            this.chkDaIn.AutoSize = true;
            this.chkDaIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaIn.Location = new System.Drawing.Point(425, 29);
            this.chkDaIn.Name = "chkDaIn";
            this.chkDaIn.Size = new System.Drawing.Size(53, 18);
            this.chkDaIn.TabIndex = 79;
            this.chkDaIn.Text = "Đã In";
            this.chkDaIn.UseVisualStyleBackColor = true;
            this.chkDaIn.CheckedChanged += new System.EventHandler(this.chkDaXacNhan_CheckedChanged);
            this.chkDaIn.Click += new System.EventHandler(this.chkDaIn_Click);
            // 
            // chkDaXacNhan
            // 
            this.chkDaXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDaXacNhan.AutoCheck = false;
            this.chkDaXacNhan.AutoSize = true;
            this.chkDaXacNhan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDaXacNhan.Location = new System.Drawing.Point(342, 29);
            this.chkDaXacNhan.Name = "chkDaXacNhan";
            this.chkDaXacNhan.Size = new System.Drawing.Size(78, 18);
            this.chkDaXacNhan.TabIndex = 78;
            this.chkDaXacNhan.Text = "Xác nhận ";
            this.chkDaXacNhan.UseVisualStyleBackColor = true;
            this.chkDaXacNhan.CheckedChanged += new System.EventHandler(this.chkDaXacNhan_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(74, 98);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(314, 21);
            this.txtAddress.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "Địa chỉ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radReturn);
            this.groupBox1.Controls.Add(this.radFirstTime);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(255, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 32);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lần khám";
            this.groupBox1.Visible = false;
            // 
            // radReturn
            // 
            this.radReturn.AutoSize = true;
            this.radReturn.Location = new System.Drawing.Point(79, 12);
            this.radReturn.Name = "radReturn";
            this.radReturn.Size = new System.Drawing.Size(76, 19);
            this.radReturn.TabIndex = 126;
            this.radReturn.TabStop = true;
            this.radReturn.Text = "Tái khám";
            this.radReturn.UseVisualStyleBackColor = true;
            // 
            // radFirstTime
            // 
            this.radFirstTime.AutoSize = true;
            this.radFirstTime.Checked = true;
            this.radFirstTime.Location = new System.Drawing.Point(5, 12);
            this.radFirstTime.Name = "radFirstTime";
            this.radFirstTime.Size = new System.Drawing.Size(70, 19);
            this.radFirstTime.TabIndex = 125;
            this.radFirstTime.TabStop = true;
            this.radFirstTime.Text = "Lần đầu";
            this.radFirstTime.UseVisualStyleBackColor = true;
            this.radFirstTime.CheckedChanged += new System.EventHandler(this.radFirstTime_CheckedChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtGhiChu.Location = new System.Drawing.Point(263, 96);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(331, 20);
            this.txtGhiChu.TabIndex = 116;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label22.Location = new System.Drawing.Point(196, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 14);
            this.label22.TabIndex = 115;
            this.label22.Text = "Ghi chú";
            // 
            // txtNhipTho
            // 
            this.txtNhipTho.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtNhipTho.Location = new System.Drawing.Point(159, 73);
            this.txtNhipTho.Name = "txtNhipTho";
            this.txtNhipTho.Size = new System.Drawing.Size(30, 20);
            this.txtNhipTho.TabIndex = 114;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label21.Location = new System.Drawing.Point(102, 76);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 14);
            this.label21.TabIndex = 113;
            this.label21.Text = "Nhịp thở";
            // 
            // txtTenBacSi
            // 
            this.txtTenBacSi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenBacSi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.txtTenBacSi.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtTenBacSi.Location = new System.Drawing.Point(343, 25);
            this.txtTenBacSi.Name = "txtTenBacSi";
            this.txtTenBacSi.ReadOnly = true;
            this.txtTenBacSi.Size = new System.Drawing.Size(251, 20);
            this.txtTenBacSi.TabIndex = 112;
            this.txtTenBacSi.TabStop = false;
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
            this.cboBacSi.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cboBacSi.FormattingEnabled = true;
            this.cboBacSi.LinkedColumnIndex = 0;
            this.cboBacSi.LinkedColumnIndex1 = 1;
            this.cboBacSi.LinkedColumnIndex2 = 0;
            this.cboBacSi.LinkedTextBox = null;
            this.cboBacSi.LinkedTextBox1 = this.txtTenBacSi;
            this.cboBacSi.LinkedTextBox2 = null;
            this.cboBacSi.Location = new System.Drawing.Point(263, 23);
            this.cboBacSi.Name = "cboBacSi";
            this.cboBacSi.Size = new System.Drawing.Size(76, 21);
            this.cboBacSi.TabIndex = 110;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(196, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 14);
            this.label20.TabIndex = 111;
            this.label20.Text = "Bác sĩ";
            // 
            // dtpTaiKham
            // 
            this.dtpTaiKham.CustomFormat = "dd/MM/yyyy";
            this.dtpTaiKham.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpTaiKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTaiKham.Location = new System.Drawing.Point(96, 121);
            this.dtpTaiKham.Name = "dtpTaiKham";
            this.dtpTaiKham.Size = new System.Drawing.Size(93, 20);
            this.dtpTaiKham.TabIndex = 109;
            // 
            // chkTaiKham
            // 
            this.chkTaiKham.AutoSize = true;
            this.chkTaiKham.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTaiKham.Font = new System.Drawing.Font("Arial", 8.25F);
            this.chkTaiKham.Location = new System.Drawing.Point(5, 123);
            this.chkTaiKham.Name = "chkTaiKham";
            this.chkTaiKham.Size = new System.Drawing.Size(87, 18);
            this.chkTaiKham.TabIndex = 108;
            this.chkTaiKham.Text = "Hẹn tái khám";
            this.chkTaiKham.UseVisualStyleBackColor = true;
            // 
            // txtDeNghi
            // 
            this.txtDeNghi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeNghi.Location = new System.Drawing.Point(263, 73);
            this.txtDeNghi.Name = "txtDeNghi";
            this.txtDeNghi.Size = new System.Drawing.Size(331, 21);
            this.txtDeNghi.TabIndex = 107;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label11.Location = new System.Drawing.Point(196, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 14);
            this.label11.TabIndex = 106;
            this.label11.Text = "Đề nghị";
            // 
            // btnLuuKQKB
            // 
            this.btnLuuKQKB.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuKQKB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuKQKB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuKQKB.ForeColor = System.Drawing.Color.Black;
            this.btnLuuKQKB.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuKQKB.Image")));
            this.btnLuuKQKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuKQKB.Location = new System.Drawing.Point(263, 117);
            this.btnLuuKQKB.Name = "btnLuuKQKB";
            this.btnLuuKQKB.Size = new System.Drawing.Size(140, 27);
            this.btnLuuKQKB.TabIndex = 105;
            this.btnLuuKQKB.Text = "Lưu thông tin khám";
            this.btnLuuKQKB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuKQKB.UseVisualStyleBackColor = true;
            this.btnLuuKQKB.Click += new System.EventHandler(this.btnLuuKQKB_Click);
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChanDoan.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtChanDoan.Location = new System.Drawing.Point(343, 49);
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChanDoan.Size = new System.Drawing.Size(251, 20);
            this.txtChanDoan.TabIndex = 103;
            this.txtChanDoan.TabStop = false;
            // 
            // cboChanDoan
            // 
            this.cboChanDoan.AutoComplete = false;
            this.cboChanDoan.AutoDropdown = false;
            this.cboChanDoan.BackColorEven = System.Drawing.Color.White;
            this.cboChanDoan.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboChanDoan.ColumnNames = "MaChanDoan, TenChanDoan";
            this.cboChanDoan.ColumnWidthDefault = 75;
            this.cboChanDoan.ColumnWidths = "75,150";
            this.cboChanDoan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboChanDoan.Font = new System.Drawing.Font("Arial", 8.25F);
            this.cboChanDoan.FormattingEnabled = true;
            this.cboChanDoan.LinkedColumnIndex = 0;
            this.cboChanDoan.LinkedColumnIndex1 = 1;
            this.cboChanDoan.LinkedColumnIndex2 = 0;
            this.cboChanDoan.LinkedTextBox = null;
            this.cboChanDoan.LinkedTextBox1 = this.txtChanDoan;
            this.cboChanDoan.LinkedTextBox2 = null;
            this.cboChanDoan.Location = new System.Drawing.Point(263, 49);
            this.cboChanDoan.Name = "cboChanDoan";
            this.cboChanDoan.Size = new System.Drawing.Size(76, 21);
            this.cboChanDoan.TabIndex = 100;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label16.Location = new System.Drawing.Point(196, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 14);
            this.label16.TabIndex = 102;
            this.label16.Text = "Chẩn đoán";
            // 
            // txtCanNang
            // 
            this.txtCanNang.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtCanNang.Location = new System.Drawing.Point(159, 49);
            this.txtCanNang.Name = "txtCanNang";
            this.txtCanNang.Size = new System.Drawing.Size(30, 20);
            this.txtCanNang.TabIndex = 97;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label14.Location = new System.Drawing.Point(102, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 14);
            this.label14.TabIndex = 96;
            this.label14.Text = "Cân nặng";
            // 
            // txtChieuCao
            // 
            this.txtChieuCao.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtChieuCao.Location = new System.Drawing.Point(63, 49);
            this.txtChieuCao.Name = "txtChieuCao";
            this.txtChieuCao.Size = new System.Drawing.Size(30, 20);
            this.txtChieuCao.TabIndex = 95;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label15.Location = new System.Drawing.Point(5, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 14);
            this.label15.TabIndex = 94;
            this.label15.Text = "Chiều cao";
            // 
            // txtNhietDo
            // 
            this.txtNhietDo.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtNhietDo.Location = new System.Drawing.Point(159, 96);
            this.txtNhietDo.Name = "txtNhietDo";
            this.txtNhietDo.Size = new System.Drawing.Size(30, 20);
            this.txtNhietDo.TabIndex = 93;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label17.Location = new System.Drawing.Point(101, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 14);
            this.label17.TabIndex = 92;
            this.label17.Text = "Nhiệt độ";
            // 
            // txtMach
            // 
            this.txtMach.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtMach.Location = new System.Drawing.Point(63, 73);
            this.txtMach.Name = "txtMach";
            this.txtMach.Size = new System.Drawing.Size(30, 20);
            this.txtMach.TabIndex = 91;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label18.Location = new System.Drawing.Point(5, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 14);
            this.label18.TabIndex = 90;
            this.label18.Text = "Mạch";
            // 
            // txtHuyetAp
            // 
            this.txtHuyetAp.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtHuyetAp.Location = new System.Drawing.Point(63, 96);
            this.txtHuyetAp.Name = "txtHuyetAp";
            this.txtHuyetAp.Size = new System.Drawing.Size(30, 20);
            this.txtHuyetAp.TabIndex = 89;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label19.Location = new System.Drawing.Point(5, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 14);
            this.label19.TabIndex = 88;
            this.label19.Text = "Huyết áp";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(5, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 14);
            this.label23.TabIndex = 87;
            this.label23.Text = "Ngày khám";
            // 
            // dtpNgayKham
            // 
            this.dtpNgayKham.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKham.Font = new System.Drawing.Font("Arial", 8.25F);
            this.dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKham.Location = new System.Drawing.Point(96, 25);
            this.dtpNgayKham.Name = "dtpNgayKham";
            this.dtpNgayKham.Size = new System.Drawing.Size(93, 20);
            this.dtpNgayKham.TabIndex = 86;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(2, 22);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(594, 384);
            this.splitContainer2.SplitterPosition = 238;
            this.splitContainer2.TabIndex = 109;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Horizontal = true;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnThemThuoc);
            this.splitContainer3.Panel1.Controls.Add(this.panel8);
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gcThuoc);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(238, 384);
            this.splitContainer3.SplitterPosition = 44;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemThuoc.BackColor = System.Drawing.Color.Transparent;
            this.btnThemThuoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemThuoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemThuoc.ForeColor = System.Drawing.Color.Black;
            this.btnThemThuoc.Image = ((System.Drawing.Image)(resources.GetObject("btnThemThuoc.Image")));
            this.btnThemThuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemThuoc.Location = new System.Drawing.Point(167, 15);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(68, 30);
            this.btnThemThuoc.TabIndex = 106;
            this.btnThemThuoc.Text = "Thêm";
            this.btnThemThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemThuoc.UseVisualStyleBackColor = true;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.cboNhomThuoc);
            this.panel8.Controls.Add(this.label25);
            this.panel8.Location = new System.Drawing.Point(3, 2);
            this.panel8.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(161, 44);
            this.panel8.TabIndex = 6;
            // 
            // cboNhomThuoc
            // 
            this.cboNhomThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNhomThuoc.AutoComplete = false;
            this.cboNhomThuoc.AutoDropdown = false;
            this.cboNhomThuoc.BackColorEven = System.Drawing.Color.White;
            this.cboNhomThuoc.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.cboNhomThuoc.ColumnNames = "";
            this.cboNhomThuoc.ColumnWidthDefault = 75;
            this.cboNhomThuoc.ColumnWidths = "";
            this.cboNhomThuoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboNhomThuoc.FormattingEnabled = true;
            this.cboNhomThuoc.LinkedColumnIndex = 0;
            this.cboNhomThuoc.LinkedColumnIndex1 = 1;
            this.cboNhomThuoc.LinkedColumnIndex2 = 0;
            this.cboNhomThuoc.LinkedTextBox = null;
            this.cboNhomThuoc.LinkedTextBox1 = null;
            this.cboNhomThuoc.LinkedTextBox2 = null;
            this.cboNhomThuoc.Location = new System.Drawing.Point(5, 17);
            this.cboNhomThuoc.Name = "cboNhomThuoc";
            this.cboNhomThuoc.Size = new System.Drawing.Size(153, 22);
            this.cboNhomThuoc.TabIndex = 2;
            this.cboNhomThuoc.SelectionChangeCommitted += new System.EventHandler(this.cboNhomThuoc_SelectionChangeCommitted);
            this.cboNhomThuoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNhomThuoc_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(5, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 15);
            this.label25.TabIndex = 0;
            this.label25.Text = "Nhóm thuốc";
            // 
            // gcThuoc
            // 
            this.gcThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcThuoc.Location = new System.Drawing.Point(0, 0);
            this.gcThuoc.MainView = this.gvThuoc;
            this.gcThuoc.Name = "gcThuoc";
            this.gcThuoc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2});
            this.gcThuoc.Size = new System.Drawing.Size(238, 336);
            this.gcThuoc.TabIndex = 33;
            this.gcThuoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThuoc});
            // 
            // gvThuoc
            // 
            this.gvThuoc.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.EvenRow.Options.UseFont = true;
            this.gvThuoc.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.FilterPanel.Options.UseFont = true;
            this.gvThuoc.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvThuoc.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvThuoc.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvThuoc.Appearance.FocusedCell.Options.UseFont = true;
            this.gvThuoc.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvThuoc.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.FocusedRow.Options.UseFont = true;
            this.gvThuoc.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvThuoc.Appearance.FooterPanel.Options.UseFont = true;
            this.gvThuoc.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.GroupButton.Options.UseFont = true;
            this.gvThuoc.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvThuoc.Appearance.GroupFooter.Options.UseFont = true;
            this.gvThuoc.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvThuoc.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvThuoc.Appearance.GroupRow.Options.UseFont = true;
            this.gvThuoc.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvThuoc.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvThuoc.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvThuoc.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvThuoc.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.HorzLine.Options.UseFont = true;
            this.gvThuoc.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.OddRow.Options.UseFont = true;
            this.gvThuoc.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.Row.Options.UseFont = true;
            this.gvThuoc.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.RowSeparator.Options.UseFont = true;
            this.gvThuoc.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvThuoc.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvThuoc.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvThuoc.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvThuoc.Appearance.SelectedRow.Options.UseFont = true;
            this.gvThuoc.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvThuoc.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.TopNewRow.Options.UseFont = true;
            this.gvThuoc.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvThuoc.Appearance.VertLine.Options.UseFont = true;
            this.gvThuoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaThuoc2,
            this.gridColumn3,
            this.gridColumn13,
            this.gridColumn2});
            this.gvThuoc.GridControl = this.gcThuoc;
            this.gvThuoc.GroupCount = 1;
            this.gvThuoc.Name = "gvThuoc";
            this.gvThuoc.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvThuoc.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvThuoc.OptionsSelection.MultiSelect = true;
            this.gvThuoc.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvThuoc.OptionsView.ColumnAutoWidth = false;
            this.gvThuoc.OptionsView.ShowAutoFilterRow = true;
            this.gvThuoc.OptionsView.ShowGroupPanel = false;
            this.gvThuoc.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMaThuoc2
            // 
            this.colMaThuoc2.Caption = "Mã Thuốc";
            this.colMaThuoc2.FieldName = "MaThuoc";
            this.colMaThuoc2.Name = "colMaThuoc2";
            this.colMaThuoc2.OptionsColumn.AllowEdit = false;
            this.colMaThuoc2.OptionsColumn.ReadOnly = true;
            this.colMaThuoc2.Width = 72;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên thuốc";
            this.gridColumn3.FieldName = "TenThuoc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 149;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "ĐVT";
            this.gridColumn13.FieldName = "DonViTinh";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 40;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nhóm";
            this.gridColumn2.FieldName = "TenNhomThuoc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit2.Appearance.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit2.AppearanceDisabled.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit2.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit2.AppearanceDropDownHeader.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit2.AppearanceFocused.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit2.AppearanceReadOnly.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenCachDung", "Tên")});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Horizontal = true;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupControl6);
            this.splitContainer4.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupControl7);
            this.splitContainer4.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer4.Size = new System.Drawing.Size(352, 384);
            this.splitContainer4.SplitterPosition = 205;
            this.splitContainer4.TabIndex = 116;
            // 
            // groupControl6
            // 
            this.groupControl6.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl6.Appearance.Options.UseFont = true;
            this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.Controls.Add(this.gcToaThuoc);
            this.groupControl6.Controls.Add(this.panel7);
            this.groupControl6.Controls.Add(this.bvChiDinhThuoc);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl6.Location = new System.Drawing.Point(0, 0);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(352, 205);
            this.groupControl6.TabIndex = 0;
            this.groupControl6.Text = "Toa thuốc";
            // 
            // gcToaThuoc
            // 
            this.gcToaThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcToaThuoc.Location = new System.Drawing.Point(2, 22);
            this.gcToaThuoc.MainView = this.gvToaThuoc;
            this.gcToaThuoc.Name = "gcToaThuoc";
            this.gcToaThuoc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gcToaThuoc.Size = new System.Drawing.Size(348, 127);
            this.gcToaThuoc.TabIndex = 32;
            this.gcToaThuoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvToaThuoc});
            this.gcToaThuoc.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcToaThuoc_ProcessGridKey);
            // 
            // gvToaThuoc
            // 
            this.gvToaThuoc.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.EvenRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.FilterPanel.Options.UseFont = true;
            this.gvToaThuoc.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvToaThuoc.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvToaThuoc.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvToaThuoc.Appearance.FocusedCell.Options.UseFont = true;
            this.gvToaThuoc.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvToaThuoc.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.FocusedRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuoc.Appearance.FooterPanel.Options.UseFont = true;
            this.gvToaThuoc.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.GroupButton.Options.UseFont = true;
            this.gvToaThuoc.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuoc.Appearance.GroupFooter.Options.UseFont = true;
            this.gvToaThuoc.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuoc.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvToaThuoc.Appearance.GroupRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvToaThuoc.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuoc.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvToaThuoc.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.HorzLine.Options.UseFont = true;
            this.gvToaThuoc.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.OddRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.Row.Options.UseFont = true;
            this.gvToaThuoc.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.RowSeparator.Options.UseFont = true;
            this.gvToaThuoc.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvToaThuoc.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuoc.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvToaThuoc.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvToaThuoc.Appearance.SelectedRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvToaThuoc.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.TopNewRow.Options.UseFont = true;
            this.gvToaThuoc.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuoc.Appearance.VertLine.Options.UseFont = true;
            this.gvToaThuoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaThuoc,
            this.colNo,
            this.colTenThuoc,
            this.colSoLuong,
            this.colSang,
            this.colTrua,
            this.colChieu,
            this.colToi,
            this.colCachDung,
            this.colDonviTinh,
            this.colGhiChu,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.gvToaThuoc.GridControl = this.gcToaThuoc;
            this.gvToaThuoc.Name = "gvToaThuoc";
            this.gvToaThuoc.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvToaThuoc.OptionsSelection.MultiSelect = true;
            this.gvToaThuoc.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvToaThuoc.OptionsView.ColumnAutoWidth = false;
            this.gvToaThuoc.OptionsView.ShowGroupPanel = false;
            this.gvToaThuoc.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvToaThuoc_CustomDrawCell);
            this.gvToaThuoc.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvToaThuoc_CellValueChanged);
            // 
            // colMaThuoc
            // 
            this.colMaThuoc.Caption = "Mã Thuốc";
            this.colMaThuoc.FieldName = "MaThuoc";
            this.colMaThuoc.Name = "colMaThuoc";
            this.colMaThuoc.OptionsColumn.AllowEdit = false;
            this.colMaThuoc.Width = 72;
            // 
            // colNo
            // 
            this.colNo.AppearanceCell.Options.UseTextOptions = true;
            this.colNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colNo.Caption = "#";
            this.colNo.Name = "colNo";
            this.colNo.OptionsColumn.AllowEdit = false;
            this.colNo.OptionsColumn.ReadOnly = true;
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 1;
            this.colNo.Width = 25;
            // 
            // colTenThuoc
            // 
            this.colTenThuoc.Caption = "Tên thuốc";
            this.colTenThuoc.FieldName = "TenThuoc";
            this.colTenThuoc.Name = "colTenThuoc";
            this.colTenThuoc.OptionsColumn.ReadOnly = true;
            this.colTenThuoc.Visible = true;
            this.colTenThuoc.VisibleIndex = 2;
            this.colTenThuoc.Width = 160;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 3;
            this.colSoLuong.Width = 62;
            // 
            // colSang
            // 
            this.colSang.Caption = "Sáng";
            this.colSang.FieldName = "Sang";
            this.colSang.Name = "colSang";
            this.colSang.Visible = true;
            this.colSang.VisibleIndex = 4;
            this.colSang.Width = 39;
            // 
            // colTrua
            // 
            this.colTrua.Caption = "Trưa";
            this.colTrua.FieldName = "Trua";
            this.colTrua.Name = "colTrua";
            this.colTrua.Visible = true;
            this.colTrua.VisibleIndex = 5;
            this.colTrua.Width = 37;
            // 
            // colChieu
            // 
            this.colChieu.Caption = "Chiều";
            this.colChieu.FieldName = "Chieu";
            this.colChieu.Name = "colChieu";
            this.colChieu.Visible = true;
            this.colChieu.VisibleIndex = 6;
            this.colChieu.Width = 44;
            // 
            // colToi
            // 
            this.colToi.Caption = "Tối";
            this.colToi.FieldName = "Toi";
            this.colToi.Name = "colToi";
            this.colToi.Visible = true;
            this.colToi.VisibleIndex = 7;
            this.colToi.Width = 31;
            // 
            // colCachDung
            // 
            this.colCachDung.Caption = "Cách dùng";
            this.colCachDung.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCachDung.FieldName = "CachDung";
            this.colCachDung.Name = "colCachDung";
            this.colCachDung.Visible = true;
            this.colCachDung.VisibleIndex = 8;
            this.colCachDung.Width = 71;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit1.AppearanceDisabled.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit1.AppearanceDropDownHeader.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AppearanceFocused.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit1.AppearanceFocused.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.Font = new System.Drawing.Font("Arial", 9F);
            this.repositoryItemLookUpEdit1.AppearanceReadOnly.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenCachDung", "Tên")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // colDonviTinh
            // 
            this.colDonviTinh.Caption = "Đơn vị tính";
            this.colDonviTinh.FieldName = "DonViTinh";
            this.colDonviTinh.Name = "colDonviTinh";
            this.colDonviTinh.OptionsColumn.ReadOnly = true;
            this.colDonviTinh.Visible = true;
            this.colDonviTinh.VisibleIndex = 9;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 10;
            this.colGhiChu.Width = 385;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "UserNhapKQ";
            this.gridColumn9.FieldName = "UserNhapKQ";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "UserSuaKQ";
            this.gridColumn10.FieldName = "UserSuaKQ";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Thành tiền";
            this.gridColumn11.FieldName = "ThanhTien";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnLuuThanhToan);
            this.panel7.Controls.Add(this.label26);
            this.panel7.Controls.Add(this.txtThanhToan);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.txtTotal);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(2, 149);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(348, 27);
            this.panel7.TabIndex = 115;
            // 
            // btnLuuThanhToan
            // 
            this.btnLuuThanhToan.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuThanhToan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuThanhToan.ForeColor = System.Drawing.Color.Black;
            this.btnLuuThanhToan.Location = new System.Drawing.Point(301, 1);
            this.btnLuuThanhToan.Name = "btnLuuThanhToan";
            this.btnLuuThanhToan.Size = new System.Drawing.Size(44, 25);
            this.btnLuuThanhToan.TabIndex = 4;
            this.btnLuuThanhToan.Text = "Lưu";
            this.btnLuuThanhToan.UseVisualStyleBackColor = false;
            this.btnLuuThanhToan.Click += new System.EventHandler(this.btnLuuThanhToan_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(140, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 15);
            this.label26.TabIndex = 3;
            this.label26.Text = "Thanh toán";
            // 
            // txtThanhToan
            // 
            this.txtThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtThanhToan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhToan.ForeColor = System.Drawing.Color.Maroon;
            this.txtThanhToan.Location = new System.Drawing.Point(213, 2);
            this.txtThanhToan.Name = "txtThanhToan";
            this.txtThanhToan.Size = new System.Drawing.Size(85, 21);
            this.txtThanhToan.TabIndex = 2;
            this.txtThanhToan.Leave += new System.EventHandler(this.txtThanhToan_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Thành tiền";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Maroon;
            this.txtTotal.Location = new System.Drawing.Point(73, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(64, 21);
            this.txtTotal.TabIndex = 0;
            // 
            // bvChiDinhThuoc
            // 
            this.bvChiDinhThuoc.AddNewItem = null;
            this.bvChiDinhThuoc.CountItem = null;
            this.bvChiDinhThuoc.CountItemFormat = "/ {0}";
            this.bvChiDinhThuoc.DeleteItem = null;
            this.bvChiDinhThuoc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvChiDinhThuoc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvChiDinhThuoc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvChiDinhThuoc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvChiDinhThuoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreview,
            this.toolStripSeparator4,
            this.btnPrint,
            this.toolStripSeparator6,
            this.btnRefreshResult,
            this.btnValidResult,
            this.toolStripSeparator7,
            this.btnDeleteItem,
            this.progressPrint,
            this.toolStripSeparator8});
            this.bvChiDinhThuoc.Location = new System.Drawing.Point(2, 176);
            this.bvChiDinhThuoc.MoveFirstItem = null;
            this.bvChiDinhThuoc.MoveLastItem = null;
            this.bvChiDinhThuoc.MoveNextItem = null;
            this.bvChiDinhThuoc.MovePreviousItem = null;
            this.bvChiDinhThuoc.Name = "bvChiDinhThuoc";
            this.bvChiDinhThuoc.PositionItem = null;
            this.bvChiDinhThuoc.Size = new System.Drawing.Size(348, 27);
            this.bvChiDinhThuoc.TabIndex = 115;
            this.bvChiDinhThuoc.Text = "bindingNavigator1";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(94, 24);
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(41, 24);
            this.btnPrint.Text = "In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefreshResult
            // 
            this.btnRefreshResult.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshResult.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshResult.Image")));
            this.btnRefreshResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshResult.Name = "btnRefreshResult";
            this.btnRefreshResult.Size = new System.Drawing.Size(82, 24);
            this.btnRefreshResult.Text = "Làm mới";
            this.btnRefreshResult.Visible = false;
            this.btnRefreshResult.Click += new System.EventHandler(this.btnRefreshResult_Click);
            // 
            // btnValidResult
            // 
            this.btnValidResult.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnValidResult.Image = ((System.Drawing.Image)(resources.GetObject("btnValidResult.Image")));
            this.btnValidResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidResult.Name = "btnValidResult";
            this.btnValidResult.Size = new System.Drawing.Size(84, 24);
            this.btnValidResult.Text = "Xác nhận";
            this.btnValidResult.Click += new System.EventHandler(this.btnValidResult_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteItem.Image")));
            this.btnDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(88, 24);
            this.btnDeleteItem.Text = "Xóa thuốc";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // progressPrint
            // 
            this.progressPrint.Name = "progressPrint";
            this.progressPrint.Size = new System.Drawing.Size(70, 24);
            this.progressPrint.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // groupControl7
            // 
            this.groupControl7.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl7.Appearance.Options.UseFont = true;
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.Controls.Add(this.gcToaThuocHistory);
            this.groupControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl7.Location = new System.Drawing.Point(0, 0);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(352, 175);
            this.groupControl7.TabIndex = 1;
            this.groupControl7.Text = "Lịch sử toa thuốc";
            // 
            // gcToaThuocHistory
            // 
            this.gcToaThuocHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcToaThuocHistory.Location = new System.Drawing.Point(2, 22);
            this.gcToaThuocHistory.MainView = this.gvToaThuocHistory;
            this.gcToaThuocHistory.Name = "gcToaThuocHistory";
            this.gcToaThuocHistory.Size = new System.Drawing.Size(348, 151);
            this.gcToaThuocHistory.TabIndex = 33;
            this.gcToaThuocHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvToaThuocHistory});
            // 
            // gvToaThuocHistory
            // 
            this.gvToaThuocHistory.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.EvenRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.FilterPanel.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvToaThuocHistory.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvToaThuocHistory.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvToaThuocHistory.Appearance.FocusedCell.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvToaThuocHistory.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.FocusedRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuocHistory.Appearance.FooterPanel.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.GroupButton.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuocHistory.Appearance.GroupFooter.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuocHistory.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvToaThuocHistory.Appearance.GroupRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvToaThuocHistory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuocHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.HorzLine.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.OddRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.Row.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.RowSeparator.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvToaThuocHistory.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvToaThuocHistory.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvToaThuocHistory.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvToaThuocHistory.Appearance.SelectedRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvToaThuocHistory.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.TopNewRow.Options.UseFont = true;
            this.gvToaThuocHistory.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvToaThuocHistory.Appearance.VertLine.Options.UseFont = true;
            this.gvToaThuocHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn4});
            this.gvToaThuocHistory.GridControl = this.gcToaThuocHistory;
            this.gvToaThuocHistory.GroupCount = 1;
            this.gvToaThuocHistory.Name = "gvToaThuocHistory";
            this.gvToaThuocHistory.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvToaThuocHistory.OptionsView.ColumnAutoWidth = false;
            this.gvToaThuocHistory.OptionsView.ShowGroupPanel = false;
            this.gvToaThuocHistory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn21, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã Thuốc";
            this.gridColumn1.FieldName = "MaThuoc";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Width = 72;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tên thuốc";
            this.gridColumn5.FieldName = "TenThuoc";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 160;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số lượng";
            this.gridColumn6.FieldName = "SoLuong";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 62;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Sáng";
            this.gridColumn7.FieldName = "Sang";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 39;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Trưa";
            this.gridColumn8.FieldName = "Trua";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 37;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Chiều";
            this.gridColumn12.FieldName = "Chieu";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 44;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tối";
            this.gridColumn14.FieldName = "Toi";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 5;
            this.gridColumn14.Width = 31;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Cách dùng";
            this.gridColumn15.FieldName = "TenCachDung";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 6;
            this.gridColumn15.Width = 71;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Đơn vị tính";
            this.gridColumn16.FieldName = "DonViTinh";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Ghi chú";
            this.gridColumn17.FieldName = "GhiChu";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 8;
            this.gridColumn17.Width = 385;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "UserNhapKQ";
            this.gridColumn18.FieldName = "UserNhapKQ";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "UserSuaKQ";
            this.gridColumn19.FieldName = "UserSuaKQ";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Thành tiền";
            this.gridColumn20.FieldName = "ThanhTien";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Mã tiếp nhận";
            this.gridColumn21.FieldName = "MaTiepNhanThanhTien";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 11;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mã tiếp nhận";
            this.gridColumn4.FieldName = "MaTiepNhan";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 9;
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
            this.imageList1.Images.SetKeyName(13, "Klukeart-Medical-Pills-3.ico");
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SEQ";
            this.dataGridViewTextBoxColumn1.HeaderText = "Số thứ tự";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenBN";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên bệnh nhân";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KetLuanXN";
            this.dataGridViewTextBoxColumn3.HeaderText = "Kết luận";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NgayTiepNhan";
            this.dataGridViewTextBoxColumn4.HeaderText = "NgayTiepNhan";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "MaTiepNhan";
            this.dataGridViewTextBoxColumn5.HeaderText = "Mã tiếp nhận";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "MaThuoc";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn6.HeaderText = "Mã thuốc";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TenThuoc";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "Tên thuốc";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SoLuong";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Crimson;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn8.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Sang";
            this.dataGridViewTextBoxColumn9.HeaderText = "Sáng ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Trua";
            this.dataGridViewTextBoxColumn10.HeaderText = "Trưa";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Chieu";
            this.dataGridViewTextBoxColumn11.HeaderText = "Chiều";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Toi";
            this.dataGridViewTextBoxColumn12.HeaderText = "Tối";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "DonViTinh";
            this.dataGridViewTextBoxColumn13.HeaderText = "Đơn vị";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "GhiChu";
            this.dataGridViewTextBoxColumn14.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 200;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "UserNhapKQ";
            this.dataGridViewTextBoxColumn15.HeaderText = "UserNhap";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "UserSuaKQ";
            this.dataGridViewTextBoxColumn16.HeaderText = "UserSua";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "ThanhTien";
            this.dataGridViewTextBoxColumn17.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(4, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupControl4);
            this.splitContainer1.Panel1.Controls.Add(this.panel11);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbDonThuoc);
            this.splitContainer1.Panel2.Controls.Add(this.panel13);
            this.splitContainer1.Panel2.Controls.Add(this.panel12);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(994, 617);
            this.splitContainer1.SplitterPosition = 392;
            this.splitContainer1.TabIndex = 113;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl4.Appearance.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.dtgPatient);
            this.groupControl4.Controls.Add(this.bvPatient);
            this.groupControl4.Controls.Add(this.panel5);
            this.groupControl4.Controls.Add(this.panel6);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(0, 209);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(392, 408);
            this.groupControl4.TabIndex = 1;
            this.groupControl4.Text = "Danh sách bệnh nhân";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.groupControl1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel11.Size = new System.Drawing.Size(392, 209);
            this.panel11.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtMSBenhNhan);
            this.groupControl1.Controls.Add(this.label24);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.txtDoctorSend);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.txtSID);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtServiceID);
            this.groupControl1.Controls.Add(this.txtTienSu);
            this.groupControl1.Controls.Add(this.label13);
            this.groupControl1.Controls.Add(this.txtTenBN);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtTinhTrang);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtAge);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.dtpBirthday);
            this.groupControl1.Controls.Add(this.chkAgeType);
            this.groupControl1.Controls.Add(this.lblSex);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Controls.Add(this.txtSex);
            this.groupControl1.Controls.Add(this.txtAddress);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(392, 204);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin bệnh nhân";
            // 
            // txtMSBenhNhan
            // 
            this.txtMSBenhNhan.Location = new System.Drawing.Point(271, 27);
            this.txtMSBenhNhan.Name = "txtMSBenhNhan";
            this.txtMSBenhNhan.ReadOnly = true;
            this.txtMSBenhNhan.Size = new System.Drawing.Size(117, 21);
            this.txtMSBenhNhan.TabIndex = 133;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(223, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 15);
            this.label24.TabIndex = 132;
            this.label24.Text = "Mã BN";
            // 
            // gbDonThuoc
            // 
            this.gbDonThuoc.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.gbDonThuoc.Appearance.Options.UseFont = true;
            this.gbDonThuoc.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gbDonThuoc.AppearanceCaption.Options.UseFont = true;
            this.gbDonThuoc.Controls.Add(this.splitContainer2);
            this.gbDonThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDonThuoc.Location = new System.Drawing.Point(0, 209);
            this.gbDonThuoc.Name = "gbDonThuoc";
            this.gbDonThuoc.Size = new System.Drawing.Size(598, 408);
            this.gbDonThuoc.TabIndex = 113;
            this.gbDonThuoc.Text = "Kê toa thuốc";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.groupControl3);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 60);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel13.Size = new System.Drawing.Size(598, 149);
            this.panel13.TabIndex = 88;
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.txtGhiChu);
            this.groupControl3.Controls.Add(this.label23);
            this.groupControl3.Controls.Add(this.label22);
            this.groupControl3.Controls.Add(this.dtpNgayKham);
            this.groupControl3.Controls.Add(this.txtNhipTho);
            this.groupControl3.Controls.Add(this.label19);
            this.groupControl3.Controls.Add(this.label21);
            this.groupControl3.Controls.Add(this.txtHuyetAp);
            this.groupControl3.Controls.Add(this.txtTenBacSi);
            this.groupControl3.Controls.Add(this.label18);
            this.groupControl3.Controls.Add(this.cboBacSi);
            this.groupControl3.Controls.Add(this.txtMach);
            this.groupControl3.Controls.Add(this.label20);
            this.groupControl3.Controls.Add(this.label17);
            this.groupControl3.Controls.Add(this.dtpTaiKham);
            this.groupControl3.Controls.Add(this.txtNhietDo);
            this.groupControl3.Controls.Add(this.chkTaiKham);
            this.groupControl3.Controls.Add(this.label15);
            this.groupControl3.Controls.Add(this.txtDeNghi);
            this.groupControl3.Controls.Add(this.txtChieuCao);
            this.groupControl3.Controls.Add(this.label11);
            this.groupControl3.Controls.Add(this.label14);
            this.groupControl3.Controls.Add(this.btnLuuKQKB);
            this.groupControl3.Controls.Add(this.txtCanNang);
            this.groupControl3.Controls.Add(this.txtChanDoan);
            this.groupControl3.Controls.Add(this.label16);
            this.groupControl3.Controls.Add(this.cboChanDoan);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(598, 144);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Kết quả khám";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.groupControl2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel12.Size = new System.Drawing.Size(598, 60);
            this.panel12.TabIndex = 87;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.txtTenYeuCauKhamBenh);
            this.groupControl2.Controls.Add(this.label6);
            this.groupControl2.Controls.Add(this.chkDaXacNhan);
            this.groupControl2.Controls.Add(this.cboYeuCauKhamBenh);
            this.groupControl2.Controls.Add(this.chkDaIn);
            this.groupControl2.Controls.Add(this.txtTGIn);
            this.groupControl2.Controls.Add(this.txtLanIn);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(598, 55);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Thông tin khám";
            // 
            // FrmKhamBenh
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Name = "FrmKhamBenh";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Khám bệnh";
            this.Load += new System.EventHandler(this.FrmKhamBenh_Load);
            this.Shown += new System.EventHandler(this.FrmKhamBenh_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmKhamBenh_SizeChanged);
            this.Controls.SetChildIndex(this.pnLabel, 0);
            this.Controls.SetChildIndex(this.pnContaint, 0);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatient)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatient)).EndInit();
            this.bvPatient.ResumeLayout(false);
            this.bvPatient.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcToaThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvToaThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvChiDinhThuoc)).EndInit();
            this.bvChiDinhThuoc.ResumeLayout(false);
            this.bvChiDinhThuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcToaThuocHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvToaThuocHistory)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbDonThuoc)).EndInit();
            this.gbDonThuoc.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomDatagridView dtgPatient;
        private DevExpress.XtraEditors.PanelControl panel6;
        private System.Windows.Forms.RadioButton radPrinted;
        private System.Windows.Forms.RadioButton radAllPrint;
        private System.Windows.Forms.RadioButton radNotPrint;
        private TPH.Controls.TPHNormalButton btnSearchSEQ;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.TextBox txtSEQ;
        private DevExpress.XtraEditors.LabelControl label1;
        private CustomBindingNavigator bvPatient;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnMFirst;
        private System.Windows.Forms.ToolStripButton btnMBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnmNext;
        private System.Windows.Forms.ToolStripButton btnMoveLast;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnRefreshList;
        private DevExpress.XtraEditors.PanelControl panel5;
        private System.Windows.Forms.ListBox listPrinter;
        private TPH.Controls.TPHNormalButton cmdRefreshPrinter;
        private System.Windows.Forms.TextBox txtSID;
        private System.Windows.Forms.TextBox txtTGIn;
        private DevExpress.XtraEditors.LabelControl label10;
        private System.Windows.Forms.TextBox txtTenBN;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private DevExpress.XtraEditors.LabelControl label5;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.CheckBox chkAgeType;
        private System.Windows.Forms.TextBox txtSex;
        private DevExpress.XtraEditors.LabelControl label12;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private System.Windows.Forms.CheckBox chkDaIn;
        private System.Windows.Forms.TextBox txtLanIn;
        private System.Windows.Forms.CheckBox chkDaXacNhan;
        private System.Windows.Forms.TextBox txtAddress;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radReturn;
        private System.Windows.Forms.RadioButton radFirstTime;
        private System.Windows.Forms.TextBox txtTienSu;
        private DevExpress.XtraEditors.LabelControl label13;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtTenYeuCauKhamBenh;
        private DevExpress.XtraEditors.LabelControl label6;
        private CustomComboBox cboYeuCauKhamBenh;
        private System.Windows.Forms.TextBox txtServiceID;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtDoctorSend;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl label22;
        private System.Windows.Forms.TextBox txtNhipTho;
        private DevExpress.XtraEditors.LabelControl label21;
        private System.Windows.Forms.TextBox txtTenBacSi;
        private CustomComboBox cboBacSi;
        private DevExpress.XtraEditors.LabelControl label20;
        private System.Windows.Forms.DateTimePicker dtpTaiKham;
        private System.Windows.Forms.CheckBox chkTaiKham;
        private System.Windows.Forms.TextBox txtDeNghi;
        private DevExpress.XtraEditors.LabelControl label11;
        private TPH.Controls.TPHNormalButton btnLuuKQKB;
        private System.Windows.Forms.TextBox txtChanDoan;
        private CustomComboBox cboChanDoan;
        private DevExpress.XtraEditors.LabelControl label16;
        private System.Windows.Forms.TextBox txtCanNang;
        private DevExpress.XtraEditors.LabelControl label14;
        private System.Windows.Forms.TextBox txtChieuCao;
        private DevExpress.XtraEditors.LabelControl label15;
        private System.Windows.Forms.TextBox txtNhietDo;
        private DevExpress.XtraEditors.LabelControl label17;
        private System.Windows.Forms.TextBox txtMach;
        private DevExpress.XtraEditors.LabelControl label18;
        private System.Windows.Forms.TextBox txtHuyetAp;
        private DevExpress.XtraEditors.LabelControl label19;
        private DevExpress.XtraEditors.LabelControl label23;
        private System.Windows.Forms.DateTimePicker dtpNgayKham;
        private TPH.Controls.TPHNormalButton btnThemThuoc;
        private DevExpress.XtraEditors.PanelControl panel8;
        private CustomComboBox cboNhomThuoc;
        private DevExpress.XtraEditors.LabelControl label25;
        private CustomBindingNavigator bvChiDinhThuoc;
        private System.Windows.Forms.ToolStripButton btnPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnRefreshResult;
        private System.Windows.Forms.ToolStripButton btnValidResult;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnDeleteItem;
        private System.Windows.Forms.ToolStripProgressBar progressPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkDaInYC;
        private System.Windows.Forms.CheckBox chkXacNhan;
        private TPH.Controls.TPHNormalButton btnChiDinhDichVu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuChiDinhCLS;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaInKQ;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DuKQ;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaXacNhanKQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetLuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTiepNhan;
        private TPH.Controls.TPHNormalButton btnKqetQuaXN;
        private DevExpress.XtraEditors.PanelControl panel7;
        private DevExpress.XtraEditors.LabelControl label9;
        private System.Windows.Forms.TextBox txtTotal;
        private DevExpress.XtraEditors.LabelControl label26;
        private System.Windows.Forms.TextBox txtThanhToan;
        private TPH.Controls.TPHNormalButton btnLuuThanhToan;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.PanelControl panel11;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl gbDonThuoc;
        private DevExpress.XtraEditors.SplitContainerControl splitContainer4;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraEditors.PanelControl panel13;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.PanelControl panel12;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcToaThuoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvToaThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colMaThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTenThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colSang;
        private DevExpress.XtraGrid.Columns.GridColumn colTrua;
        private DevExpress.XtraGrid.Columns.GridColumn colChieu;
        private DevExpress.XtraGrid.Columns.GridColumn colToi;
        private DevExpress.XtraGrid.Columns.GridColumn colCachDung;
        private DevExpress.XtraGrid.Columns.GridColumn colDonviTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.GridControl gcThuoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colMaThuoc2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.TextBox txtMSBenhNhan;
        private DevExpress.XtraEditors.LabelControl label24;
        private DevExpress.XtraGrid.GridControl gcToaThuocHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvToaThuocHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}