using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    partial class FrmHoSoBenhAn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoSoBenhAn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchPatient = new TPH.Controls.TPHNormalButton();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchPID = new System.Windows.Forms.TextBox();
            this.label18 = new DevExpress.XtraEditors.LabelControl();
            this.tabThongTin = new System.Windows.Forms.TabControl();
            this.tabPatientInfomation = new System.Windows.Forms.TabPage();
            this.pnHisreception = new DevExpress.XtraEditors.PanelControl();
            this.dtgReceptionList = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.NgayTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BacSiCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvReceptionList = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new DevExpress.XtraEditors.PanelControl();
            this.multiColumnComboBox5 = new TPH.LIS.Common.Controls.CustomComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label27 = new DevExpress.XtraEditors.LabelControl();
            this.label26 = new DevExpress.XtraEditors.LabelControl();
            this.cboDiagnostic = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtDiagnostic = new System.Windows.Forms.TextBox();
            this.label25 = new DevExpress.XtraEditors.LabelControl();
            this.lblRecptionID = new DevExpress.XtraEditors.LabelControl();
            this.label24 = new DevExpress.XtraEditors.LabelControl();
            this.cboSend_Diagnostic = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtSend_Diagnostic = new System.Windows.Forms.TextBox();
            this.label23 = new DevExpress.XtraEditors.LabelControl();
            this.txtDoctorComment = new System.Windows.Forms.TextBox();
            this.label22 = new DevExpress.XtraEditors.LabelControl();
            this.cboSend_Location = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtSend_Location = new System.Windows.Forms.TextBox();
            this.label21 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.label17 = new DevExpress.XtraEditors.LabelControl();
            this.radReturn = new System.Windows.Forms.RadioButton();
            this.radFirstTime = new System.Windows.Forms.RadioButton();
            this.pnPatientInfo = new DevExpress.XtraEditors.PanelControl();
            this.label16 = new DevExpress.XtraEditors.LabelControl();
            this.pbPatientImage = new System.Windows.Forms.PictureBox();
            this.btnReMoveImage = new TPH.Controls.TPHNormalButton();
            this.btnAddImage = new TPH.Controls.TPHNormalButton();
            this.lblPatientID = new DevExpress.XtraEditors.LabelControl();
            this.label14 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenBN = new System.Windows.Forms.TextBox();
            this.label15 = new DevExpress.XtraEditors.LabelControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new DevExpress.XtraEditors.LabelControl();
            this.txtHocVan = new System.Windows.Forms.TextBox();
            this.txtQuocTich = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.txtDanToc = new System.Windows.Forms.TextBox();
            this.txtNgheNghiep = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.txtNoiLamViec = new System.Windows.Forms.TextBox();
            this.label12 = new DevExpress.XtraEditors.LabelControl();
            this.chkAgeType = new System.Windows.Forms.CheckBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new DevExpress.XtraEditors.LabelControl();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label5 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSoNha = new System.Windows.Forms.TextBox();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhuongXa = new System.Windows.Forms.TextBox();
            this.txtQuanHuyen = new System.Windows.Forms.TextBox();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.txtTinh = new System.Windows.Forms.TextBox();
            this.cboQuanHuyen = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label20 = new DevExpress.XtraEditors.LabelControl();
            this.label19 = new DevExpress.XtraEditors.LabelControl();
            this.cboTinh = new TPH.LIS.Common.Controls.CustomComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tabDiagnostic = new System.Windows.Forms.TabPage();
            this.btnRefreshDiagnostic = new TPH.Controls.TPHNormalButton();
            this.gcChanDoan = new DevExpress.XtraGrid.GridControl();
            this.grdLichSuChanDoan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclBacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclKetQuaChanDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPrescribe = new System.Windows.Forms.TabPage();
            this.btnRefreshPrescribe = new TPH.Controls.TPHNormalButton();
            this.gcPrescribe = new DevExpress.XtraGrid.GridControl();
            this.grdPrescribe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrescribe_BacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPrescribe_MedicineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescride_Soluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescribe_Sang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescribe_Trua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescribe_Chieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescribe_GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescribe_CachDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrescribe_DonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.pnChart = new DevExpress.XtraEditors.PanelControl();
            this.customChart1 = new TPH.LIS.Common.Controls.Chart.CustomChart();
            this.btnRefreshTest = new TPH.Controls.TPHNormalButton();
            this.gcXetNghiem = new DevExpress.XtraGrid.GridControl();
            this.grdMainXetnghiem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcolNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcolTenXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcolMaXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcolThuTuInNhom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcolSapXep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel5 = new DevExpress.XtraEditors.PanelControl();
            this.btnPhongToBieuDo = new TPH.Controls.TPHNormalButton();
            this.btnDongBieuDo = new TPH.Controls.TPHNormalButton();
            this.btnXemBieuDo = new TPH.Controls.TPHNormalButton();
            this.tabUltraSound = new System.Windows.Forms.TabPage();
            this.pnUltraSoundGirid = new DevExpress.XtraEditors.PanelControl();
            this.gcUltraSound_Grid = new DevExpress.XtraGrid.GridControl();
            this.gvUltraSound_Grid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUltraSound_Grid_YeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUltraSound_Grid_Mota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemRichTextEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.pnUltraSoundfreeText = new DevExpress.XtraEditors.PanelControl();
            this.gcUltrasound = new DevExpress.XtraGrid.GridControl();
            this.grdUltrasound = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUltrasound_BacSi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUltrasound_YeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUltrasound_KetLuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.colUltrasound_NoiDung1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.colUltrasound_HinhKetQua1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUltrasound_HinhKetQua2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.radKetQuaSieuAm_VanBan = new System.Windows.Forms.RadioButton();
            this.radKetQuaSieuAm_Luoi = new System.Windows.Forms.RadioButton();
            this.btnRefreshUltraSound = new TPH.Controls.TPHNormalButton();
            this.tabEdoscopy = new System.Windows.Forms.TabPage();
            this.btnRefreshEdoscopic = new TPH.Controls.TPHNormalButton();
            this.gcEdoscopic = new DevExpress.XtraGrid.GridControl();
            this.grdEdoscopic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabXRay = new System.Windows.Forms.TabPage();
            this.btnRefreshXRay = new TPH.Controls.TPHNormalButton();
            this.gcXRay = new DevExpress.XtraGrid.GridControl();
            this.grdXRay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.repositoryItemRichTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.tabLichSuKSD = new System.Windows.Forms.TabPage();
            this.btnXemLichSuKSD = new TPH.Controls.TPHNormalButton();
            this.ucLichSuKhangSinhDo1 = new TPH.HIS.Controls.ucLichSuKhangSinhDo();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.dtgPatientList = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.TenBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvPatientList = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tabPatientInfomation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnHisreception)).BeginInit();
            this.pnHisreception.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceptionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvReceptionList)).BeginInit();
            this.bvReceptionList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnPatientInfo)).BeginInit();
            this.pnPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatientImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabDiagnostic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChanDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLichSuChanDoan)).BeginInit();
            this.tabPrescribe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPrescribe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrescribe)).BeginInit();
            this.tabTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnChart)).BeginInit();
            this.pnChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcXetNghiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMainXetnghiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel5)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabUltraSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnUltraSoundGirid)).BeginInit();
            this.pnUltraSoundGirid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUltraSound_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUltraSound_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnUltraSoundfreeText)).BeginInit();
            this.pnUltraSoundfreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUltrasound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUltrasound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabEdoscopy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEdoscopic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEdoscopic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit4)).BeginInit();
            this.tabXRay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcXRay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXRay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit5)).BeginInit();
            this.tabLichSuKSD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatientList)).BeginInit();
            this.bvPatientList.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(131, 22);
            this.lblTitle.Text = "HỒ SƠ BỆNH ÁN";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.tabThongTin);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Location = new System.Drawing.Point(0, 26);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnContaint.Size = new System.Drawing.Size(1008, 636);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(4, 7, 4, 2);
            this.pnLabel.Size = new System.Drawing.Size(1008, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(652, 7);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(681, 7);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(1008, 26);
            this.pnMenu.Visible = true;
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1008, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(133, 1);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(900, 1);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchPatient);
            this.groupBox1.Controls.Add(this.txtSearchName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearchPID);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchPatient.BackColorHover = System.Drawing.Color.Empty;
            this.btnSearchPatient.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSearchPatient.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchPatient.BorderRadius = 5;
            this.btnSearchPatient.BorderSize = 1;
            this.btnSearchPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPatient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatient.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSearchPatient.ForeColor = System.Drawing.Color.Black;
            this.btnSearchPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPatient.Image")));
            this.btnSearchPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchPatient.Location = new System.Drawing.Point(117, 71);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(99, 30);
            this.btnSearchPatient.TabIndex = 95;
            this.btnSearchPatient.Text = "Tìm BN";
            this.btnSearchPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchPatient.TextColor = System.Drawing.Color.Black;
            this.btnSearchPatient.UseHightLight = true;
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(82, 46);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(136, 21);
            this.txtSearchName.TabIndex = 96;
            this.txtSearchName.Visible = false;
            this.txtSearchName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchName_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Tên BN";
            this.label1.Visible = false;
            // 
            // txtSearchPID
            // 
            this.txtSearchPID.Location = new System.Drawing.Point(82, 19);
            this.txtSearchPID.Name = "txtSearchPID";
            this.txtSearchPID.Size = new System.Drawing.Size(136, 21);
            this.txtSearchPID.TabIndex = 93;
            this.txtSearchPID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPID_KeyPress);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 94;
            this.label18.Text = "Mã số BN";
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.tabPatientInfomation);
            this.tabThongTin.Controls.Add(this.tabDiagnostic);
            this.tabThongTin.Controls.Add(this.tabPrescribe);
            this.tabThongTin.Controls.Add(this.tabTest);
            this.tabThongTin.Controls.Add(this.tabUltraSound);
            this.tabThongTin.Controls.Add(this.tabEdoscopy);
            this.tabThongTin.Controls.Add(this.tabXRay);
            this.tabThongTin.Controls.Add(this.tabLichSuKSD);
            this.tabThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabThongTin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabThongTin.Location = new System.Drawing.Point(232, 3);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.SelectedIndex = 0;
            this.tabThongTin.Size = new System.Drawing.Size(772, 630);
            this.tabThongTin.TabIndex = 1;
            this.tabThongTin.SelectedIndexChanged += new System.EventHandler(this.tabThongTin_SelectedIndexChanged);
            // 
            // tabPatientInfomation
            // 
            this.tabPatientInfomation.Controls.Add(this.pnHisreception);
            this.tabPatientInfomation.Controls.Add(this.panel3);
            this.tabPatientInfomation.Controls.Add(this.pnPatientInfo);
            this.tabPatientInfomation.Location = new System.Drawing.Point(4, 24);
            this.tabPatientInfomation.Name = "tabPatientInfomation";
            this.tabPatientInfomation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPatientInfomation.Size = new System.Drawing.Size(764, 602);
            this.tabPatientInfomation.TabIndex = 0;
            this.tabPatientInfomation.Text = "Thông tin";
            this.tabPatientInfomation.UseVisualStyleBackColor = true;
            // 
            // pnHisreception
            // 
            this.pnHisreception.Controls.Add(this.dtgReceptionList);
            this.pnHisreception.Controls.Add(this.bvReceptionList);
            this.pnHisreception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHisreception.Location = new System.Drawing.Point(3, 228);
            this.pnHisreception.Name = "pnHisreception";
            this.pnHisreception.Size = new System.Drawing.Size(357, 371);
            this.pnHisreception.TabIndex = 121;
            // 
            // dtgReceptionList
            // 
            this.dtgReceptionList.AlignColumns = "";
            this.dtgReceptionList.AllignNumberText = false;
            this.dtgReceptionList.AllowUserToAddRows = false;
            this.dtgReceptionList.AllowUserToDeleteRows = false;
            this.dtgReceptionList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgReceptionList.CheckBoldColumn = false;
            this.dtgReceptionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgReceptionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayTiepNhan,
            this.MaTiepNhan,
            this.BacSiCD});
            this.dtgReceptionList.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgReceptionList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgReceptionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReceptionList.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgReceptionList.Location = new System.Drawing.Point(2, 2);
            this.dtgReceptionList.MarkOddEven = true;
            this.dtgReceptionList.MultiSelect = false;
            this.dtgReceptionList.Name = "dtgReceptionList";
            this.dtgReceptionList.ReadOnly = true;
            this.dtgReceptionList.RowHeadersWidth = 20;
            this.dtgReceptionList.RowTemplate.Height = 28;
            this.dtgReceptionList.Size = new System.Drawing.Size(353, 340);
            this.dtgReceptionList.TabIndex = 0;
            // 
            // NgayTiepNhan
            // 
            this.NgayTiepNhan.DataPropertyName = "NgayTiepNhan";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.NgayTiepNhan.DefaultCellStyle = dataGridViewCellStyle1;
            this.NgayTiepNhan.HeaderText = "Ngày đăng ký";
            this.NgayTiepNhan.MinimumWidth = 6;
            this.NgayTiepNhan.Name = "NgayTiepNhan";
            this.NgayTiepNhan.ReadOnly = true;
            this.NgayTiepNhan.Width = 150;
            // 
            // MaTiepNhan
            // 
            this.MaTiepNhan.DataPropertyName = "MaTiepNhan";
            this.MaTiepNhan.HeaderText = "Mã tiếp nhận";
            this.MaTiepNhan.MinimumWidth = 6;
            this.MaTiepNhan.Name = "MaTiepNhan";
            this.MaTiepNhan.ReadOnly = true;
            this.MaTiepNhan.Width = 150;
            // 
            // BacSiCD
            // 
            this.BacSiCD.DataPropertyName = "TenNhanVien";
            this.BacSiCD.HeaderText = "BS Chỉ định";
            this.BacSiCD.MinimumWidth = 6;
            this.BacSiCD.Name = "BacSiCD";
            this.BacSiCD.ReadOnly = true;
            this.BacSiCD.Width = 150;
            // 
            // bvReceptionList
            // 
            this.bvReceptionList.AddNewItem = null;
            this.bvReceptionList.CountItem = this.bindingNavigatorCountItem;
            this.bvReceptionList.CountItemFormat = "/ {0}";
            this.bvReceptionList.DeleteItem = null;
            this.bvReceptionList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvReceptionList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvReceptionList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvReceptionList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvReceptionList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.btnEdit,
            this.toolStripSeparator1,
            this.btnCancel,
            this.toolStripSeparator2,
            this.btnUpdate});
            this.bvReceptionList.Location = new System.Drawing.Point(2, 342);
            this.bvReceptionList.MoveFirstItem = null;
            this.bvReceptionList.MoveLastItem = null;
            this.bvReceptionList.MoveNextItem = null;
            this.bvReceptionList.MovePreviousItem = null;
            this.bvReceptionList.Name = "bvReceptionList";
            this.bvReceptionList.PositionItem = this.bindingNavigatorPositionItem;
            this.bvReceptionList.Size = new System.Drawing.Size(353, 27);
            this.bvReceptionList.TabIndex = 1;
            this.bvReceptionList.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 24);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(44, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.Blue;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 24);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Crimson;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 24);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.Green;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(54, 24);
            this.btnUpdate.Text = "Lưu";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.multiColumnComboBox5);
            this.panel3.Controls.Add(this.textBox7);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.cboDiagnostic);
            this.panel3.Controls.Add(this.txtDiagnostic);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.lblRecptionID);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.cboSend_Diagnostic);
            this.panel3.Controls.Add(this.txtSend_Diagnostic);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.txtDoctorComment);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.cboSend_Location);
            this.panel3.Controls.Add(this.txtSend_Location);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.dtpDateIn);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.radReturn);
            this.panel3.Controls.Add(this.radFirstTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(360, 228);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 371);
            this.panel3.TabIndex = 149;
            // 
            // multiColumnComboBox5
            // 
            this.multiColumnComboBox5.AutoComplete = false;
            this.multiColumnComboBox5.AutoDropdown = false;
            this.multiColumnComboBox5.BackColorEven = System.Drawing.Color.White;
            this.multiColumnComboBox5.BackColorOdd = System.Drawing.Color.LightBlue;
            this.multiColumnComboBox5.ColumnNames = "MaNhanVien, TenNhanVien";
            this.multiColumnComboBox5.ColumnWidthDefault = 75;
            this.multiColumnComboBox5.ColumnWidths = "75,150";
            this.multiColumnComboBox5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiColumnComboBox5.FormattingEnabled = true;
            this.multiColumnComboBox5.LinkedColumnIndex = 0;
            this.multiColumnComboBox5.LinkedColumnIndex1 = 1;
            this.multiColumnComboBox5.LinkedColumnIndex2 = 0;
            this.multiColumnComboBox5.LinkedTextBox = null;
            this.multiColumnComboBox5.LinkedTextBox1 = null;
            this.multiColumnComboBox5.LinkedTextBox2 = null;
            this.multiColumnComboBox5.Location = new System.Drawing.Point(143, 240);
            this.multiColumnComboBox5.Name = "multiColumnComboBox5";
            this.multiColumnComboBox5.Size = new System.Drawing.Size(37, 21);
            this.multiColumnComboBox5.TabIndex = 148;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(190, 241);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(201, 20);
            this.textBox7.TabIndex = 147;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(10, 244);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(50, 13);
            this.label27.TabIndex = 146;
            this.label27.Text = "BS Điều trị";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(10, 186);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 145;
            this.label26.Text = "Nhận xét";
            // 
            // cboDiagnostic
            // 
            this.cboDiagnostic.AutoComplete = false;
            this.cboDiagnostic.AutoDropdown = false;
            this.cboDiagnostic.BackColorEven = System.Drawing.Color.White;
            this.cboDiagnostic.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboDiagnostic.ColumnNames = "MaNhanVien, TenNhanVien";
            this.cboDiagnostic.ColumnWidthDefault = 75;
            this.cboDiagnostic.ColumnWidths = "75,150";
            this.cboDiagnostic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboDiagnostic.FormattingEnabled = true;
            this.cboDiagnostic.LinkedColumnIndex = 0;
            this.cboDiagnostic.LinkedColumnIndex1 = 1;
            this.cboDiagnostic.LinkedColumnIndex2 = 0;
            this.cboDiagnostic.LinkedTextBox = null;
            this.cboDiagnostic.LinkedTextBox1 = null;
            this.cboDiagnostic.LinkedTextBox2 = null;
            this.cboDiagnostic.Location = new System.Drawing.Point(143, 132);
            this.cboDiagnostic.Name = "cboDiagnostic";
            this.cboDiagnostic.Size = new System.Drawing.Size(37, 21);
            this.cboDiagnostic.TabIndex = 141;
            // 
            // txtDiagnostic
            // 
            this.txtDiagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnostic.Location = new System.Drawing.Point(190, 132);
            this.txtDiagnostic.Multiline = true;
            this.txtDiagnostic.Name = "txtDiagnostic";
            this.txtDiagnostic.Size = new System.Drawing.Size(201, 48);
            this.txtDiagnostic.TabIndex = 140;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(10, 132);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 13);
            this.label25.TabIndex = 139;
            this.label25.Text = "Chẩn đoán";
            // 
            // lblRecptionID
            // 
            this.lblRecptionID.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblRecptionID.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecptionID.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.lblRecptionID.Appearance.Options.UseBackColor = true;
            this.lblRecptionID.Appearance.Options.UseFont = true;
            this.lblRecptionID.Appearance.Options.UseForeColor = true;
            this.lblRecptionID.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblRecptionID.Location = new System.Drawing.Point(143, 3);
            this.lblRecptionID.Name = "lblRecptionID";
            this.lblRecptionID.Size = new System.Drawing.Size(2, 20);
            this.lblRecptionID.TabIndex = 138;
            // 
            // label24
            // 
            this.label24.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Appearance.Options.UseFont = true;
            this.label24.Location = new System.Drawing.Point(10, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 15);
            this.label24.TabIndex = 135;
            this.label24.Text = "Mã tiếp nhận";
            // 
            // cboSend_Diagnostic
            // 
            this.cboSend_Diagnostic.AutoComplete = false;
            this.cboSend_Diagnostic.AutoDropdown = false;
            this.cboSend_Diagnostic.BackColorEven = System.Drawing.Color.White;
            this.cboSend_Diagnostic.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboSend_Diagnostic.ColumnNames = "MaNhanVien, TenNhanVien";
            this.cboSend_Diagnostic.ColumnWidthDefault = 75;
            this.cboSend_Diagnostic.ColumnWidths = "75,150";
            this.cboSend_Diagnostic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboSend_Diagnostic.FormattingEnabled = true;
            this.cboSend_Diagnostic.LinkedColumnIndex = 0;
            this.cboSend_Diagnostic.LinkedColumnIndex1 = 1;
            this.cboSend_Diagnostic.LinkedColumnIndex2 = 0;
            this.cboSend_Diagnostic.LinkedTextBox = null;
            this.cboSend_Diagnostic.LinkedTextBox1 = null;
            this.cboSend_Diagnostic.LinkedTextBox2 = null;
            this.cboSend_Diagnostic.Location = new System.Drawing.Point(143, 84);
            this.cboSend_Diagnostic.Name = "cboSend_Diagnostic";
            this.cboSend_Diagnostic.Size = new System.Drawing.Size(37, 21);
            this.cboSend_Diagnostic.TabIndex = 134;
            // 
            // txtSend_Diagnostic
            // 
            this.txtSend_Diagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend_Diagnostic.Location = new System.Drawing.Point(190, 81);
            this.txtSend_Diagnostic.Multiline = true;
            this.txtSend_Diagnostic.Name = "txtSend_Diagnostic";
            this.txtSend_Diagnostic.Size = new System.Drawing.Size(201, 48);
            this.txtSend_Diagnostic.TabIndex = 133;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(10, 84);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 13);
            this.label23.TabIndex = 132;
            this.label23.Text = "Chẩn đoán nơi gửi";
            // 
            // txtDoctorComment
            // 
            this.txtDoctorComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDoctorComment.Location = new System.Drawing.Point(141, 183);
            this.txtDoctorComment.Multiline = true;
            this.txtDoctorComment.Name = "txtDoctorComment";
            this.txtDoctorComment.Size = new System.Drawing.Size(250, 53);
            this.txtDoctorComment.TabIndex = 131;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(10, 100);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 13);
            this.label22.TabIndex = 130;
            this.label22.Text = "(Yêu cầu điều trị)";
            // 
            // cboSend_Location
            // 
            this.cboSend_Location.AutoComplete = false;
            this.cboSend_Location.AutoDropdown = false;
            this.cboSend_Location.BackColorEven = System.Drawing.Color.White;
            this.cboSend_Location.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboSend_Location.ColumnNames = "MaNhanVien, TenNhanVien";
            this.cboSend_Location.ColumnWidthDefault = 75;
            this.cboSend_Location.ColumnWidths = "75,150";
            this.cboSend_Location.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboSend_Location.FormattingEnabled = true;
            this.cboSend_Location.LinkedColumnIndex = 0;
            this.cboSend_Location.LinkedColumnIndex1 = 1;
            this.cboSend_Location.LinkedColumnIndex2 = 0;
            this.cboSend_Location.LinkedTextBox = null;
            this.cboSend_Location.LinkedTextBox1 = null;
            this.cboSend_Location.LinkedTextBox2 = null;
            this.cboSend_Location.Location = new System.Drawing.Point(143, 55);
            this.cboSend_Location.Name = "cboSend_Location";
            this.cboSend_Location.Size = new System.Drawing.Size(37, 21);
            this.cboSend_Location.TabIndex = 129;
            // 
            // txtSend_Location
            // 
            this.txtSend_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend_Location.Location = new System.Drawing.Point(190, 55);
            this.txtSend_Location.Name = "txtSend_Location";
            this.txtSend_Location.Size = new System.Drawing.Size(201, 20);
            this.txtSend_Location.TabIndex = 128;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(10, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 13);
            this.label21.TabIndex = 127;
            this.label21.Text = "Khoa/Nơi gửi";
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy ";
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(143, 29);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(137, 20);
            this.dtpDateIn.TabIndex = 126;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(10, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 125;
            this.label17.Text = "Ngày đăng ký";
            // 
            // radReturn
            // 
            this.radReturn.AutoSize = true;
            this.radReturn.Location = new System.Drawing.Point(307, 30);
            this.radReturn.Name = "radReturn";
            this.radReturn.Size = new System.Drawing.Size(69, 17);
            this.radReturn.TabIndex = 124;
            this.radReturn.TabStop = true;
            this.radReturn.Text = "Tái khám";
            this.radReturn.UseVisualStyleBackColor = true;
            // 
            // radFirstTime
            // 
            this.radFirstTime.AutoSize = true;
            this.radFirstTime.Location = new System.Drawing.Point(307, 5);
            this.radFirstTime.Name = "radFirstTime";
            this.radFirstTime.Size = new System.Drawing.Size(65, 17);
            this.radFirstTime.TabIndex = 123;
            this.radFirstTime.TabStop = true;
            this.radFirstTime.Text = "Lần đầu";
            this.radFirstTime.UseVisualStyleBackColor = true;
            // 
            // pnPatientInfo
            // 
            this.pnPatientInfo.Controls.Add(this.label16);
            this.pnPatientInfo.Controls.Add(this.pbPatientImage);
            this.pnPatientInfo.Controls.Add(this.btnReMoveImage);
            this.pnPatientInfo.Controls.Add(this.btnAddImage);
            this.pnPatientInfo.Controls.Add(this.lblPatientID);
            this.pnPatientInfo.Controls.Add(this.label14);
            this.pnPatientInfo.Controls.Add(this.txtTenBN);
            this.pnPatientInfo.Controls.Add(this.label15);
            this.pnPatientInfo.Controls.Add(this.checkBox1);
            this.pnPatientInfo.Controls.Add(this.label13);
            this.pnPatientInfo.Controls.Add(this.txtHocVan);
            this.pnPatientInfo.Controls.Add(this.txtQuocTich);
            this.pnPatientInfo.Controls.Add(this.label4);
            this.pnPatientInfo.Controls.Add(this.txtEmail);
            this.pnPatientInfo.Controls.Add(this.label6);
            this.pnPatientInfo.Controls.Add(this.label8);
            this.pnPatientInfo.Controls.Add(this.txtDanToc);
            this.pnPatientInfo.Controls.Add(this.txtNgheNghiep);
            this.pnPatientInfo.Controls.Add(this.label2);
            this.pnPatientInfo.Controls.Add(this.txtSex);
            this.pnPatientInfo.Controls.Add(this.txtNoiLamViec);
            this.pnPatientInfo.Controls.Add(this.label12);
            this.pnPatientInfo.Controls.Add(this.chkAgeType);
            this.pnPatientInfo.Controls.Add(this.dtpBirthday);
            this.pnPatientInfo.Controls.Add(this.txtPhone);
            this.pnPatientInfo.Controls.Add(this.label7);
            this.pnPatientInfo.Controls.Add(this.txtAge);
            this.pnPatientInfo.Controls.Add(this.label5);
            this.pnPatientInfo.Controls.Add(this.label3);
            this.pnPatientInfo.Controls.Add(this.groupBox2);
            this.pnPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnPatientInfo.Location = new System.Drawing.Point(3, 3);
            this.pnPatientInfo.Name = "pnPatientInfo";
            this.pnPatientInfo.Size = new System.Drawing.Size(758, 225);
            this.pnPatientInfo.TabIndex = 120;
            this.pnPatientInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnPatientInfo_Paint);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(571, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 141;
            this.label16.Text = "Hình";
            // 
            // pbPatientImage
            // 
            this.pbPatientImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPatientImage.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbPatientImage.ErrorImage")));
            this.pbPatientImage.Location = new System.Drawing.Point(614, 52);
            this.pbPatientImage.Name = "pbPatientImage";
            this.pbPatientImage.Size = new System.Drawing.Size(88, 94);
            this.pbPatientImage.TabIndex = 140;
            this.pbPatientImage.TabStop = false;
            // 
            // btnReMoveImage
            // 
            this.btnReMoveImage.BackColor = System.Drawing.Color.Transparent;
            this.btnReMoveImage.BackColorHover = System.Drawing.Color.Empty;
            this.btnReMoveImage.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnReMoveImage.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReMoveImage.BorderRadius = 5;
            this.btnReMoveImage.BorderSize = 1;
            this.btnReMoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReMoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReMoveImage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReMoveImage.ForceColorHover = System.Drawing.Color.Empty;
            this.btnReMoveImage.ForeColor = System.Drawing.Color.Black;
            this.btnReMoveImage.Location = new System.Drawing.Point(579, 112);
            this.btnReMoveImage.Name = "btnReMoveImage";
            this.btnReMoveImage.Size = new System.Drawing.Size(22, 21);
            this.btnReMoveImage.TabIndex = 139;
            this.btnReMoveImage.Text = "-";
            this.btnReMoveImage.TextColor = System.Drawing.Color.Black;
            this.btnReMoveImage.UseHightLight = true;
            this.btnReMoveImage.UseVisualStyleBackColor = true;
            this.btnReMoveImage.Click += new System.EventHandler(this.btnReMoveImage_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Transparent;
            this.btnAddImage.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddImage.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddImage.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddImage.BorderRadius = 5;
            this.btnAddImage.BorderSize = 1;
            this.btnAddImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddImage.ForeColor = System.Drawing.Color.Black;
            this.btnAddImage.Location = new System.Drawing.Point(579, 84);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(22, 21);
            this.btnAddImage.TabIndex = 138;
            this.btnAddImage.Text = "+";
            this.btnAddImage.TextColor = System.Drawing.Color.Black;
            this.btnAddImage.UseHightLight = true;
            this.btnAddImage.UseVisualStyleBackColor = true;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // lblPatientID
            // 
            this.lblPatientID.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.lblPatientID.Appearance.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.lblPatientID.Appearance.Options.UseBackColor = true;
            this.lblPatientID.Appearance.Options.UseFont = true;
            this.lblPatientID.Appearance.Options.UseForeColor = true;
            this.lblPatientID.Location = new System.Drawing.Point(547, 3);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(0, 18);
            this.lblPatientID.TabIndex = 137;
            // 
            // label14
            // 
            this.label14.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Appearance.Options.UseFont = true;
            this.label14.Location = new System.Drawing.Point(447, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 15);
            this.label14.TabIndex = 118;
            this.label14.Text = "Mã bệnh nhân";
            // 
            // txtTenBN
            // 
            this.txtTenBN.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTenBN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTenBN.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenBN.ForeColor = System.Drawing.Color.Crimson;
            this.txtTenBN.Location = new System.Drawing.Point(94, 2);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.Size = new System.Drawing.Size(326, 21);
            this.txtTenBN.TabIndex = 65;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(2, 106);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 117;
            this.label15.Text = "Nơi làm việc";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(596, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 22);
            this.checkBox1.TabIndex = 116;
            this.checkBox1.Text = "Cán bộ/CNV";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(278, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 115;
            this.label13.Text = "Học vấn";
            // 
            // txtHocVan
            // 
            this.txtHocVan.Location = new System.Drawing.Point(353, 79);
            this.txtHocVan.Name = "txtHocVan";
            this.txtHocVan.Size = new System.Drawing.Size(205, 20);
            this.txtHocVan.TabIndex = 114;
            this.txtHocVan.TabStop = false;
            // 
            // txtQuocTich
            // 
            this.txtQuocTich.Location = new System.Drawing.Point(94, 53);
            this.txtQuocTich.Name = "txtQuocTich";
            this.txtQuocTich.Size = new System.Drawing.Size(176, 20);
            this.txtQuocTich.TabIndex = 112;
            this.txtQuocTich.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "Quốc tịch";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(353, 131);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(204, 20);
            this.txtEmail.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(278, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 83;
            this.label6.Text = "Email";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(278, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 107;
            this.label8.Text = "Dân tộc";
            // 
            // txtDanToc
            // 
            this.txtDanToc.Location = new System.Drawing.Point(353, 53);
            this.txtDanToc.Name = "txtDanToc";
            this.txtDanToc.Size = new System.Drawing.Size(205, 20);
            this.txtDanToc.TabIndex = 106;
            this.txtDanToc.TabStop = false;
            // 
            // txtNgheNghiep
            // 
            this.txtNgheNghiep.Location = new System.Drawing.Point(94, 79);
            this.txtNgheNghiep.Name = "txtNgheNghiep";
            this.txtNgheNghiep.Size = new System.Drawing.Size(176, 20);
            this.txtNgheNghiep.TabIndex = 104;
            this.txtNgheNghiep.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Nghề nghiệp";
            // 
            // txtSex
            // 
            this.txtSex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSex.Location = new System.Drawing.Point(496, 25);
            this.txtSex.MaxLength = 1;
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(39, 20);
            this.txtSex.TabIndex = 69;
            // 
            // txtNoiLamViec
            // 
            this.txtNoiLamViec.Location = new System.Drawing.Point(94, 104);
            this.txtNoiLamViec.Name = "txtNoiLamViec";
            this.txtNoiLamViec.Size = new System.Drawing.Size(464, 20);
            this.txtNoiLamViec.TabIndex = 80;
            this.txtNoiLamViec.TabStop = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(392, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 88;
            this.label12.Text = "Giới tính (F/M)";
            // 
            // chkAgeType
            // 
            this.chkAgeType.AutoSize = true;
            this.chkAgeType.Location = new System.Drawing.Point(2, 26);
            this.chkAgeType.Name = "chkAgeType";
            this.chkAgeType.Size = new System.Drawing.Size(73, 17);
            this.chkAgeType.TabIndex = 67;
            this.chkAgeType.Text = "Ngày sinh";
            this.chkAgeType.UseVisualStyleBackColor = true;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Checked = false;
            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(94, 26);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(96, 24);
            this.dtpBirthday.TabIndex = 68;
            this.dtpBirthday.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(94, 131);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(176, 20);
            this.txtPhone.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 84;
            this.label7.Text = "Điện thoại";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(290, 25);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(78, 20);
            this.txtAge.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(198, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Tuổi / N. sinh";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(2, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 77;
            this.label3.Text = "Tên bệnh nhân";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoNha);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtPhuongXa);
            this.groupBox2.Controls.Add(this.txtQuanHuyen);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTinh);
            this.groupBox2.Controls.Add(this.cboQuanHuyen);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.cboTinh);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Location = new System.Drawing.Point(3, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 67);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Điạ chỉ";
            // 
            // txtSoNha
            // 
            this.txtSoNha.Location = new System.Drawing.Point(91, 41);
            this.txtSoNha.Name = "txtSoNha";
            this.txtSoNha.Size = new System.Drawing.Size(129, 20);
            this.txtSoNha.TabIndex = 111;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(4, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "Số nhà";
            // 
            // txtPhuongXa
            // 
            this.txtPhuongXa.Location = new System.Drawing.Point(584, 11);
            this.txtPhuongXa.Name = "txtPhuongXa";
            this.txtPhuongXa.Size = new System.Drawing.Size(115, 20);
            this.txtPhuongXa.TabIndex = 109;
            // 
            // txtQuanHuyen
            // 
            this.txtQuanHuyen.Location = new System.Drawing.Point(398, 11);
            this.txtQuanHuyen.Name = "txtQuanHuyen";
            this.txtQuanHuyen.ReadOnly = true;
            this.txtQuanHuyen.Size = new System.Drawing.Size(99, 20);
            this.txtQuanHuyen.TabIndex = 100;
            this.txtQuanHuyen.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(501, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "Phường/Xã";
            // 
            // txtTinh
            // 
            this.txtTinh.Location = new System.Drawing.Point(125, 11);
            this.txtTinh.Name = "txtTinh";
            this.txtTinh.ReadOnly = true;
            this.txtTinh.Size = new System.Drawing.Size(130, 20);
            this.txtTinh.TabIndex = 99;
            this.txtTinh.TabStop = false;
            // 
            // cboQuanHuyen
            // 
            this.cboQuanHuyen.AutoComplete = false;
            this.cboQuanHuyen.AutoDropdown = false;
            this.cboQuanHuyen.BackColorEven = System.Drawing.Color.White;
            this.cboQuanHuyen.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboQuanHuyen.ColumnNames = "MaNhap, QuanHuyen";
            this.cboQuanHuyen.ColumnWidthDefault = 75;
            this.cboQuanHuyen.ColumnWidths = "75,150";
            this.cboQuanHuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboQuanHuyen.FormattingEnabled = true;
            this.cboQuanHuyen.LinkedColumnIndex = 0;
            this.cboQuanHuyen.LinkedColumnIndex1 = 1;
            this.cboQuanHuyen.LinkedColumnIndex2 = 0;
            this.cboQuanHuyen.LinkedTextBox = null;
            this.cboQuanHuyen.LinkedTextBox1 = this.txtQuanHuyen;
            this.cboQuanHuyen.LinkedTextBox2 = null;
            this.cboQuanHuyen.Location = new System.Drawing.Point(350, 11);
            this.cboQuanHuyen.Name = "cboQuanHuyen";
            this.cboQuanHuyen.Size = new System.Drawing.Size(44, 21);
            this.cboQuanHuyen.TabIndex = 98;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(259, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 13);
            this.label20.TabIndex = 97;
            this.label20.Text = "Quận/Huyện";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 95;
            this.label19.Text = "Tỉnh / TP";
            // 
            // cboTinh
            // 
            this.cboTinh.AutoComplete = false;
            this.cboTinh.AutoDropdown = false;
            this.cboTinh.BackColorEven = System.Drawing.Color.White;
            this.cboTinh.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboTinh.ColumnNames = "MaNhanVien, TenNhanVien";
            this.cboTinh.ColumnWidthDefault = 75;
            this.cboTinh.ColumnWidths = "75,150";
            this.cboTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboTinh.FormattingEnabled = true;
            this.cboTinh.LinkedColumnIndex = 0;
            this.cboTinh.LinkedColumnIndex1 = 1;
            this.cboTinh.LinkedColumnIndex2 = 0;
            this.cboTinh.LinkedTextBox = null;
            this.cboTinh.LinkedTextBox1 = null;
            this.cboTinh.LinkedTextBox2 = null;
            this.cboTinh.Location = new System.Drawing.Point(91, 11);
            this.cboTinh.Name = "cboTinh";
            this.cboTinh.Size = new System.Drawing.Size(30, 21);
            this.cboTinh.TabIndex = 76;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(224, 41);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(475, 20);
            this.txtAddress.TabIndex = 71;
            // 
            // tabDiagnostic
            // 
            this.tabDiagnostic.Controls.Add(this.btnRefreshDiagnostic);
            this.tabDiagnostic.Controls.Add(this.gcChanDoan);
            this.tabDiagnostic.Location = new System.Drawing.Point(4, 24);
            this.tabDiagnostic.Name = "tabDiagnostic";
            this.tabDiagnostic.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnostic.Size = new System.Drawing.Size(940, 601);
            this.tabDiagnostic.TabIndex = 7;
            this.tabDiagnostic.Tag = "KhamBenh";
            this.tabDiagnostic.Text = "Lịch sử chẩn đoán";
            this.tabDiagnostic.UseVisualStyleBackColor = true;
            // 
            // btnRefreshDiagnostic
            // 
            this.btnRefreshDiagnostic.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshDiagnostic.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshDiagnostic.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshDiagnostic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDiagnostic.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshDiagnostic.BorderRadius = 0;
            this.btnRefreshDiagnostic.BorderSize = 0;
            this.btnRefreshDiagnostic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshDiagnostic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDiagnostic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDiagnostic.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshDiagnostic.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshDiagnostic.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnRefreshDiagnostic.Location = new System.Drawing.Point(2, 4);
            this.btnRefreshDiagnostic.Name = "btnRefreshDiagnostic";
            this.btnRefreshDiagnostic.Size = new System.Drawing.Size(22, 23);
            this.btnRefreshDiagnostic.TabIndex = 33;
            this.btnRefreshDiagnostic.TextColor = System.Drawing.Color.Black;
            this.btnRefreshDiagnostic.UseHightLight = true;
            this.btnRefreshDiagnostic.UseVisualStyleBackColor = false;
            this.btnRefreshDiagnostic.Click += new System.EventHandler(this.btnRefreshDiagnostic_Click);
            // 
            // gcChanDoan
            // 
            this.gcChanDoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChanDoan.Location = new System.Drawing.Point(3, 3);
            this.gcChanDoan.MainView = this.grdLichSuChanDoan;
            this.gcChanDoan.Name = "gcChanDoan";
            this.gcChanDoan.Size = new System.Drawing.Size(934, 595);
            this.gcChanDoan.TabIndex = 30;
            this.gcChanDoan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdLichSuChanDoan});
            // 
            // grdLichSuChanDoan
            // 
            this.grdLichSuChanDoan.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.EvenRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.FilterPanel.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdLichSuChanDoan.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.grdLichSuChanDoan.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdLichSuChanDoan.Appearance.FocusedCell.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdLichSuChanDoan.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.FocusedRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdLichSuChanDoan.Appearance.FooterPanel.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.GroupButton.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdLichSuChanDoan.Appearance.GroupFooter.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdLichSuChanDoan.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdLichSuChanDoan.Appearance.GroupRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdLichSuChanDoan.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdLichSuChanDoan.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.HorzLine.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.OddRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.Row.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.RowSeparator.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grdLichSuChanDoan.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdLichSuChanDoan.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grdLichSuChanDoan.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdLichSuChanDoan.Appearance.SelectedRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdLichSuChanDoan.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.TopNewRow.Options.UseFont = true;
            this.grdLichSuChanDoan.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdLichSuChanDoan.Appearance.VertLine.Options.UseFont = true;
            this.grdLichSuChanDoan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclBacSi,
            this.gclKetQuaChanDoan});
            this.grdLichSuChanDoan.GridControl = this.gcChanDoan;
            this.grdLichSuChanDoan.GroupCount = 1;
            this.grdLichSuChanDoan.GroupFormat = "{0}: [#image]{1}{2}";
            this.grdLichSuChanDoan.Name = "grdLichSuChanDoan";
            this.grdLichSuChanDoan.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdLichSuChanDoan.OptionsBehavior.Editable = false;
            this.grdLichSuChanDoan.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdLichSuChanDoan.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdLichSuChanDoan.OptionsView.ShowFooter = true;
            this.grdLichSuChanDoan.OptionsView.ShowGroupPanel = false;
            this.grdLichSuChanDoan.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gclBacSi, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gclBacSi
            // 
            this.gclBacSi.Caption = "Bác Sĩ";
            this.gclBacSi.FieldName = "BacSi";
            this.gclBacSi.Name = "gclBacSi";
            this.gclBacSi.Visible = true;
            this.gclBacSi.VisibleIndex = 0;
            // 
            // gclKetQuaChanDoan
            // 
            this.gclKetQuaChanDoan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gclKetQuaChanDoan.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gclKetQuaChanDoan.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gclKetQuaChanDoan.AppearanceCell.Options.UseFont = true;
            this.gclKetQuaChanDoan.AppearanceCell.Options.UseForeColor = true;
            this.gclKetQuaChanDoan.AppearanceCell.Options.UseTextOptions = true;
            this.gclKetQuaChanDoan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gclKetQuaChanDoan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gclKetQuaChanDoan.Caption = " ";
            this.gclKetQuaChanDoan.FieldName = "ChanDoan";
            this.gclKetQuaChanDoan.Name = "gclKetQuaChanDoan";
            this.gclKetQuaChanDoan.Visible = true;
            this.gclKetQuaChanDoan.VisibleIndex = 0;
            // 
            // tabPrescribe
            // 
            this.tabPrescribe.Controls.Add(this.btnRefreshPrescribe);
            this.tabPrescribe.Controls.Add(this.gcPrescribe);
            this.tabPrescribe.Location = new System.Drawing.Point(4, 24);
            this.tabPrescribe.Name = "tabPrescribe";
            this.tabPrescribe.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrescribe.Size = new System.Drawing.Size(940, 601);
            this.tabPrescribe.TabIndex = 2;
            this.tabPrescribe.Tag = "KhamBenh";
            this.tabPrescribe.Text = "Lịch sử kê đơn thuốc";
            this.tabPrescribe.UseVisualStyleBackColor = true;
            // 
            // btnRefreshPrescribe
            // 
            this.btnRefreshPrescribe.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshPrescribe.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshPrescribe.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshPrescribe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshPrescribe.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshPrescribe.BorderRadius = 0;
            this.btnRefreshPrescribe.BorderSize = 0;
            this.btnRefreshPrescribe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshPrescribe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPrescribe.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshPrescribe.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshPrescribe.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshPrescribe.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnRefreshPrescribe.Location = new System.Drawing.Point(2, 5);
            this.btnRefreshPrescribe.Name = "btnRefreshPrescribe";
            this.btnRefreshPrescribe.Size = new System.Drawing.Size(22, 23);
            this.btnRefreshPrescribe.TabIndex = 34;
            this.btnRefreshPrescribe.TextColor = System.Drawing.Color.Black;
            this.btnRefreshPrescribe.UseHightLight = true;
            this.btnRefreshPrescribe.UseVisualStyleBackColor = false;
            this.btnRefreshPrescribe.Click += new System.EventHandler(this.btnRefreshPrescribe_Click);
            // 
            // gcPrescribe
            // 
            this.gcPrescribe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPrescribe.Location = new System.Drawing.Point(3, 3);
            this.gcPrescribe.MainView = this.grdPrescribe;
            this.gcPrescribe.Name = "gcPrescribe";
            this.gcPrescribe.Size = new System.Drawing.Size(934, 595);
            this.gcPrescribe.TabIndex = 33;
            this.gcPrescribe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPrescribe});
            // 
            // grdPrescribe
            // 
            this.grdPrescribe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.EvenRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.FilterPanel.Options.UseFont = true;
            this.grdPrescribe.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdPrescribe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.grdPrescribe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdPrescribe.Appearance.FocusedCell.Options.UseFont = true;
            this.grdPrescribe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdPrescribe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.FocusedRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPrescribe.Appearance.FooterPanel.Options.UseFont = true;
            this.grdPrescribe.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.GroupButton.Options.UseFont = true;
            this.grdPrescribe.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPrescribe.Appearance.GroupFooter.Options.UseFont = true;
            this.grdPrescribe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPrescribe.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdPrescribe.Appearance.GroupRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdPrescribe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPrescribe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdPrescribe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.HorzLine.Options.UseFont = true;
            this.grdPrescribe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.OddRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.Row.Options.UseFont = true;
            this.grdPrescribe.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.RowSeparator.Options.UseFont = true;
            this.grdPrescribe.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grdPrescribe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdPrescribe.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grdPrescribe.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdPrescribe.Appearance.SelectedRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdPrescribe.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.TopNewRow.Options.UseFont = true;
            this.grdPrescribe.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdPrescribe.Appearance.VertLine.Options.UseFont = true;
            this.grdPrescribe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrescribe_BacSi,
            this.grdPrescribe_MedicineName,
            this.colPrescride_Soluong,
            this.colPrescribe_Sang,
            this.colPrescribe_Trua,
            this.colPrescribe_Chieu,
            this.colPrescribe_GhiChu,
            this.colPrescribe_CachDung,
            this.colPrescribe_DonViTinh});
            this.grdPrescribe.GridControl = this.gcPrescribe;
            this.grdPrescribe.GroupCount = 1;
            this.grdPrescribe.GroupFormat = "{0}: [#image]{1}{2}";
            this.grdPrescribe.Name = "grdPrescribe";
            this.grdPrescribe.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdPrescribe.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdPrescribe.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdPrescribe.OptionsView.ColumnAutoWidth = false;
            this.grdPrescribe.OptionsView.ShowGroupPanel = false;
            this.grdPrescribe.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPrescribe_BacSi, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPrescribe_BacSi
            // 
            this.colPrescribe_BacSi.Caption = "Bác sĩ";
            this.colPrescribe_BacSi.FieldName = "BacSi";
            this.colPrescribe_BacSi.Name = "colPrescribe_BacSi";
            this.colPrescribe_BacSi.Visible = true;
            this.colPrescribe_BacSi.VisibleIndex = 0;
            // 
            // grdPrescribe_MedicineName
            // 
            this.grdPrescribe_MedicineName.Caption = "Tên thuốc";
            this.grdPrescribe_MedicineName.FieldName = "TenThuoc";
            this.grdPrescribe_MedicineName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.grdPrescribe_MedicineName.Name = "grdPrescribe_MedicineName";
            this.grdPrescribe_MedicineName.Visible = true;
            this.grdPrescribe_MedicineName.VisibleIndex = 0;
            this.grdPrescribe_MedicineName.Width = 107;
            // 
            // colPrescride_Soluong
            // 
            this.colPrescride_Soluong.Caption = "Số lượng";
            this.colPrescride_Soluong.FieldName = "SoLuong";
            this.colPrescride_Soluong.Name = "colPrescride_Soluong";
            this.colPrescride_Soluong.Visible = true;
            this.colPrescride_Soluong.VisibleIndex = 1;
            // 
            // colPrescribe_Sang
            // 
            this.colPrescribe_Sang.Caption = "Sáng";
            this.colPrescribe_Sang.FieldName = "Sang";
            this.colPrescribe_Sang.Name = "colPrescribe_Sang";
            this.colPrescribe_Sang.Visible = true;
            this.colPrescribe_Sang.VisibleIndex = 2;
            // 
            // colPrescribe_Trua
            // 
            this.colPrescribe_Trua.Caption = "Trưa";
            this.colPrescribe_Trua.FieldName = "Trua";
            this.colPrescribe_Trua.Name = "colPrescribe_Trua";
            this.colPrescribe_Trua.Visible = true;
            this.colPrescribe_Trua.VisibleIndex = 3;
            // 
            // colPrescribe_Chieu
            // 
            this.colPrescribe_Chieu.Caption = "Chiều";
            this.colPrescribe_Chieu.FieldName = "Chieu";
            this.colPrescribe_Chieu.Name = "colPrescribe_Chieu";
            this.colPrescribe_Chieu.Visible = true;
            this.colPrescribe_Chieu.VisibleIndex = 4;
            // 
            // colPrescribe_GhiChu
            // 
            this.colPrescribe_GhiChu.Caption = "Ghi chú";
            this.colPrescribe_GhiChu.FieldName = "GhiChu";
            this.colPrescribe_GhiChu.Name = "colPrescribe_GhiChu";
            this.colPrescribe_GhiChu.Visible = true;
            this.colPrescribe_GhiChu.VisibleIndex = 5;
            // 
            // colPrescribe_CachDung
            // 
            this.colPrescribe_CachDung.Caption = "Cách dùng";
            this.colPrescribe_CachDung.FieldName = "TenCachDung";
            this.colPrescribe_CachDung.Name = "colPrescribe_CachDung";
            this.colPrescribe_CachDung.Visible = true;
            this.colPrescribe_CachDung.VisibleIndex = 6;
            // 
            // colPrescribe_DonViTinh
            // 
            this.colPrescribe_DonViTinh.Caption = "Đơn vị tính";
            this.colPrescribe_DonViTinh.FieldName = "DonViTinh";
            this.colPrescribe_DonViTinh.Name = "colPrescribe_DonViTinh";
            this.colPrescribe_DonViTinh.Visible = true;
            this.colPrescribe_DonViTinh.VisibleIndex = 7;
            // 
            // tabTest
            // 
            this.tabTest.Controls.Add(this.pnChart);
            this.tabTest.Controls.Add(this.btnRefreshTest);
            this.tabTest.Controls.Add(this.gcXetNghiem);
            this.tabTest.Controls.Add(this.panel5);
            this.tabTest.Location = new System.Drawing.Point(4, 24);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(940, 601);
            this.tabTest.TabIndex = 3;
            this.tabTest.Tag = "ClsXetNghiem";
            this.tabTest.Text = "Lịch sử xét nghiệm";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // pnChart
            // 
            this.pnChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnChart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnChart.Controls.Add(this.customChart1);
            this.pnChart.Location = new System.Drawing.Point(-755, 217);
            this.pnChart.Name = "pnChart";
            this.pnChart.Size = new System.Drawing.Size(459, 356);
            this.pnChart.TabIndex = 33;
            // 
            // customChart1
            // 
            this.customChart1.ArrowDistance = 5;
            this.customChart1.ArrowWidth = 5;
            this.customChart1.AutoAddHeight = 100;
            this.customChart1.AutoAddWidth = 200;
            this.customChart1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customChart1.AxisNameColor = System.Drawing.Color.Black;
            this.customChart1.AxisNameFont = new System.Drawing.Font("Arial", 9F);
            this.customChart1.BottomPadding = 120;
            this.customChart1.BreakPointColor = System.Drawing.Color.Black;
            this.customChart1.BreakPointFont = new System.Drawing.Font("Arial", 15F);
            this.customChart1.ChartSize = new System.Drawing.Size(1024, 768);
            this.customChart1.ChartSubTile = "";
            this.customChart1.ChartTile = "";
            this.customChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customChart1.DrawHorizotalDottedLine = false;
            this.customChart1.LeftPadding = 150;
            this.customChart1.LineColorMerge = System.Drawing.Color.Red;
            this.customChart1.LineColoroPointVal = System.Drawing.Color.Blue;
            this.customChart1.LineColorX = System.Drawing.Color.Blue;
            this.customChart1.LineColorY = System.Drawing.Color.Blue;
            this.customChart1.LineMergeWeight = 1;
            this.customChart1.LineXWeight = 3;
            this.customChart1.LineYWeight = 3;
            this.customChart1.Location = new System.Drawing.Point(2, 2);
            this.customChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customChart1.Name = "customChart1";
            this.customChart1.NameXColor = System.Drawing.Color.Red;
            this.customChart1.NameYColor = System.Drawing.Color.Red;
            this.customChart1.PointValueColor = System.Drawing.Color.Black;
            this.customChart1.RightPadding = 30;
            this.customChart1.Size = new System.Drawing.Size(455, 352);
            this.customChart1.TabIndex = 0;
            this.customChart1.TopPadding = 30;
            this.customChart1.ValuePoint = new System.Drawing.Font("Arial", 9F);
            this.customChart1.XName = "X";
            this.customChart1.YName = "Y";
            // 
            // btnRefreshTest
            // 
            this.btnRefreshTest.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshTest.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshTest.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshTest.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshTest.BorderRadius = 0;
            this.btnRefreshTest.BorderSize = 0;
            this.btnRefreshTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTest.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTest.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshTest.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshTest.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnRefreshTest.Location = new System.Drawing.Point(2, 4);
            this.btnRefreshTest.Name = "btnRefreshTest";
            this.btnRefreshTest.Size = new System.Drawing.Size(23, 23);
            this.btnRefreshTest.TabIndex = 32;
            this.btnRefreshTest.TextColor = System.Drawing.Color.Black;
            this.btnRefreshTest.UseHightLight = true;
            this.btnRefreshTest.UseVisualStyleBackColor = false;
            this.btnRefreshTest.Click += new System.EventHandler(this.btnRefreshTest_Click);
            // 
            // gcXetNghiem
            // 
            this.gcXetNghiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcXetNghiem.Location = new System.Drawing.Point(3, 3);
            this.gcXetNghiem.MainView = this.grdMainXetnghiem;
            this.gcXetNghiem.Name = "gcXetNghiem";
            this.gcXetNghiem.Size = new System.Drawing.Size(934, 566);
            this.gcXetNghiem.TabIndex = 31;
            this.gcXetNghiem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdMainXetnghiem});
            // 
            // grdMainXetnghiem
            // 
            this.grdMainXetnghiem.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.EvenRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.FilterPanel.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdMainXetnghiem.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.grdMainXetnghiem.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdMainXetnghiem.Appearance.FocusedCell.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdMainXetnghiem.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.FocusedRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdMainXetnghiem.Appearance.FooterPanel.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.GroupButton.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdMainXetnghiem.Appearance.GroupFooter.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdMainXetnghiem.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdMainXetnghiem.Appearance.GroupRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdMainXetnghiem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdMainXetnghiem.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.HorzLine.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.OddRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.Row.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.RowSeparator.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grdMainXetnghiem.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdMainXetnghiem.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grdMainXetnghiem.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdMainXetnghiem.Appearance.SelectedRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdMainXetnghiem.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.TopNewRow.Options.UseFont = true;
            this.grdMainXetnghiem.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdMainXetnghiem.Appearance.VertLine.Options.UseFont = true;
            this.grdMainXetnghiem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcolNhom,
            this.grcolTenXN,
            this.grcolMaXN,
            this.grcolThuTuInNhom,
            this.grcolSapXep});
            this.grdMainXetnghiem.GridControl = this.gcXetNghiem;
            this.grdMainXetnghiem.GroupCount = 1;
            this.grdMainXetnghiem.GroupFormat = "{0}: [#image]{1}{2}";
            this.grdMainXetnghiem.Name = "grdMainXetnghiem";
            this.grdMainXetnghiem.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdMainXetnghiem.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdMainXetnghiem.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdMainXetnghiem.OptionsView.ColumnAutoWidth = false;
            this.grdMainXetnghiem.OptionsView.ShowGroupPanel = false;
            this.grdMainXetnghiem.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.grcolNhom, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.grcolThuTuInNhom, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.grcolSapXep, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdMainXetnghiem.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdMainXetnghiem_RowCellStyle);
            this.grdMainXetnghiem.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdMainXetnghiem_FocusedRowChanged);
            // 
            // grcolNhom
            // 
            this.grcolNhom.Caption = "Nhóm";
            this.grcolNhom.FieldName = "TenNhomCLS";
            this.grcolNhom.Name = "grcolNhom";
            this.grcolNhom.Visible = true;
            this.grcolNhom.VisibleIndex = 0;
            // 
            // grcolTenXN
            // 
            this.grcolTenXN.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcolTenXN.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.grcolTenXN.AppearanceCell.Options.UseFont = true;
            this.grcolTenXN.AppearanceCell.Options.UseForeColor = true;
            this.grcolTenXN.Caption = "Xét nghiệm";
            this.grcolTenXN.FieldName = "TenChiDinh";
            this.grcolTenXN.Name = "grcolTenXN";
            this.grcolTenXN.Visible = true;
            this.grcolTenXN.VisibleIndex = 0;
            this.grcolTenXN.Width = 107;
            // 
            // grcolMaXN
            // 
            this.grcolMaXN.Caption = "MaXN";
            this.grcolMaXN.FieldName = "MaChiDinh";
            this.grcolMaXN.Name = "grcolMaXN";
            // 
            // grcolThuTuInNhom
            // 
            this.grcolThuTuInNhom.Caption = "ThuTuInNhom";
            this.grcolThuTuInNhom.FieldName = "ThuTuNhom";
            this.grcolThuTuInNhom.Name = "grcolThuTuInNhom";
            this.grcolThuTuInNhom.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.grcolThuTuInNhom.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // grcolSapXep
            // 
            this.grcolSapXep.Caption = "SapXep";
            this.grcolSapXep.FieldName = "SapXep";
            this.grcolSapXep.Name = "grcolSapXep";
            this.grcolSapXep.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.grcolSapXep.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // panel5
            // 
            this.panel5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.panel5.Appearance.Options.UseBackColor = true;
            this.panel5.Controls.Add(this.btnPhongToBieuDo);
            this.panel5.Controls.Add(this.btnDongBieuDo);
            this.panel5.Controls.Add(this.btnXemBieuDo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 569);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(934, 29);
            this.panel5.TabIndex = 34;
            // 
            // btnPhongToBieuDo
            // 
            this.btnPhongToBieuDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhongToBieuDo.BackColor = System.Drawing.SystemColors.Control;
            this.btnPhongToBieuDo.BackColorHover = System.Drawing.Color.Empty;
            this.btnPhongToBieuDo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnPhongToBieuDo.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPhongToBieuDo.BorderRadius = 5;
            this.btnPhongToBieuDo.BorderSize = 1;
            this.btnPhongToBieuDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhongToBieuDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhongToBieuDo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhongToBieuDo.ForceColorHover = System.Drawing.Color.Empty;
            this.btnPhongToBieuDo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPhongToBieuDo.Image = global::TPH.LIS.App.Properties.Resources.Zoom;
            this.btnPhongToBieuDo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhongToBieuDo.Location = new System.Drawing.Point(814, 1);
            this.btnPhongToBieuDo.Name = "btnPhongToBieuDo";
            this.btnPhongToBieuDo.Size = new System.Drawing.Size(108, 26);
            this.btnPhongToBieuDo.TabIndex = 2;
            this.btnPhongToBieuDo.Text = "Phóng to";
            this.btnPhongToBieuDo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPhongToBieuDo.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnPhongToBieuDo.UseHightLight = true;
            this.btnPhongToBieuDo.UseVisualStyleBackColor = true;
            this.btnPhongToBieuDo.Click += new System.EventHandler(this.btnPhongToBieuDo_Click);
            // 
            // btnDongBieuDo
            // 
            this.btnDongBieuDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDongBieuDo.BackColor = System.Drawing.SystemColors.Control;
            this.btnDongBieuDo.BackColorHover = System.Drawing.Color.Empty;
            this.btnDongBieuDo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnDongBieuDo.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDongBieuDo.BorderRadius = 5;
            this.btnDongBieuDo.BorderSize = 1;
            this.btnDongBieuDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongBieuDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongBieuDo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongBieuDo.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDongBieuDo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDongBieuDo.Image = global::TPH.LIS.App.Properties.Resources.close_circle_16x161;
            this.btnDongBieuDo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongBieuDo.Location = new System.Drawing.Point(658, 1);
            this.btnDongBieuDo.Name = "btnDongBieuDo";
            this.btnDongBieuDo.Size = new System.Drawing.Size(130, 26);
            this.btnDongBieuDo.TabIndex = 1;
            this.btnDongBieuDo.Text = "Đóng biểu đồ";
            this.btnDongBieuDo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongBieuDo.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnDongBieuDo.UseHightLight = true;
            this.btnDongBieuDo.UseVisualStyleBackColor = true;
            this.btnDongBieuDo.Click += new System.EventHandler(this.btnDongBieuDo_Click);
            // 
            // btnXemBieuDo
            // 
            this.btnXemBieuDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemBieuDo.BackColor = System.Drawing.SystemColors.Control;
            this.btnXemBieuDo.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemBieuDo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnXemBieuDo.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemBieuDo.BorderRadius = 5;
            this.btnXemBieuDo.BorderSize = 1;
            this.btnXemBieuDo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemBieuDo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBieuDo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBieuDo.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemBieuDo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnXemBieuDo.Image = ((System.Drawing.Image)(resources.GetObject("btnXemBieuDo.Image")));
            this.btnXemBieuDo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemBieuDo.Location = new System.Drawing.Point(502, 1);
            this.btnXemBieuDo.Name = "btnXemBieuDo";
            this.btnXemBieuDo.Size = new System.Drawing.Size(130, 26);
            this.btnXemBieuDo.TabIndex = 0;
            this.btnXemBieuDo.Text = "Xem biểu đồ";
            this.btnXemBieuDo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemBieuDo.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnXemBieuDo.UseHightLight = true;
            this.btnXemBieuDo.UseVisualStyleBackColor = true;
            this.btnXemBieuDo.Click += new System.EventHandler(this.btnXemBieuDo_Click);
            // 
            // tabUltraSound
            // 
            this.tabUltraSound.Controls.Add(this.pnUltraSoundGirid);
            this.tabUltraSound.Controls.Add(this.pnUltraSoundfreeText);
            this.tabUltraSound.Controls.Add(this.panel2);
            this.tabUltraSound.Location = new System.Drawing.Point(4, 24);
            this.tabUltraSound.Name = "tabUltraSound";
            this.tabUltraSound.Padding = new System.Windows.Forms.Padding(3);
            this.tabUltraSound.Size = new System.Drawing.Size(940, 601);
            this.tabUltraSound.TabIndex = 4;
            this.tabUltraSound.Tag = "ClsSieuAm";
            this.tabUltraSound.Text = "Lịch sử siêu âm";
            this.tabUltraSound.UseVisualStyleBackColor = true;
            // 
            // pnUltraSoundGirid
            // 
            this.pnUltraSoundGirid.Controls.Add(this.gcUltraSound_Grid);
            this.pnUltraSoundGirid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnUltraSoundGirid.Location = new System.Drawing.Point(3, 32);
            this.pnUltraSoundGirid.Name = "pnUltraSoundGirid";
            this.pnUltraSoundGirid.Size = new System.Drawing.Size(934, 566);
            this.pnUltraSoundGirid.TabIndex = 38;
            // 
            // gcUltraSound_Grid
            // 
            this.gcUltraSound_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUltraSound_Grid.Location = new System.Drawing.Point(2, 2);
            this.gcUltraSound_Grid.MainView = this.gvUltraSound_Grid;
            this.gcUltraSound_Grid.Name = "gcUltraSound_Grid";
            this.gcUltraSound_Grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit7,
            this.repositoryItemRichTextEdit8,
            this.repositoryItemMemoEdit1});
            this.gcUltraSound_Grid.Size = new System.Drawing.Size(930, 562);
            this.gcUltraSound_Grid.TabIndex = 34;
            this.gcUltraSound_Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUltraSound_Grid});
            // 
            // gvUltraSound_Grid
            // 
            this.gvUltraSound_Grid.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.EvenRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.FilterPanel.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvUltraSound_Grid.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.gvUltraSound_Grid.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvUltraSound_Grid.Appearance.FocusedCell.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvUltraSound_Grid.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.FocusedRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvUltraSound_Grid.Appearance.FooterPanel.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.GroupButton.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvUltraSound_Grid.Appearance.GroupFooter.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvUltraSound_Grid.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvUltraSound_Grid.Appearance.GroupRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvUltraSound_Grid.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvUltraSound_Grid.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.HorzLine.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.OddRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.Row.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.RowSeparator.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gvUltraSound_Grid.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gvUltraSound_Grid.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gvUltraSound_Grid.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvUltraSound_Grid.Appearance.SelectedRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvUltraSound_Grid.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.TopNewRow.Options.UseFont = true;
            this.gvUltraSound_Grid.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.gvUltraSound_Grid.Appearance.VertLine.Options.UseFont = true;
            this.gvUltraSound_Grid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUltraSound_Grid_YeuCau,
            this.colUltraSound_Grid_Mota});
            this.gvUltraSound_Grid.GridControl = this.gcUltraSound_Grid;
            this.gvUltraSound_Grid.GroupCount = 1;
            this.gvUltraSound_Grid.GroupFormat = "{0}: [#image]{1}{2}";
            this.gvUltraSound_Grid.Name = "gvUltraSound_Grid";
            this.gvUltraSound_Grid.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvUltraSound_Grid.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvUltraSound_Grid.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvUltraSound_Grid.OptionsView.ColumnAutoWidth = false;
            this.gvUltraSound_Grid.OptionsView.RowAutoHeight = true;
            this.gvUltraSound_Grid.OptionsView.ShowGroupPanel = false;
            this.gvUltraSound_Grid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUltraSound_Grid_YeuCau, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUltraSound_Grid_YeuCau
            // 
            this.colUltraSound_Grid_YeuCau.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUltraSound_Grid_YeuCau.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.colUltraSound_Grid_YeuCau.AppearanceCell.Options.UseFont = true;
            this.colUltraSound_Grid_YeuCau.AppearanceCell.Options.UseForeColor = true;
            this.colUltraSound_Grid_YeuCau.Caption = "Tên yêu cầu";
            this.colUltraSound_Grid_YeuCau.FieldName = "TenMauSieuAm";
            this.colUltraSound_Grid_YeuCau.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUltraSound_Grid_YeuCau.Name = "colUltraSound_Grid_YeuCau";
            this.colUltraSound_Grid_YeuCau.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colUltraSound_Grid_YeuCau.Visible = true;
            this.colUltraSound_Grid_YeuCau.VisibleIndex = 0;
            this.colUltraSound_Grid_YeuCau.Width = 200;
            // 
            // colUltraSound_Grid_Mota
            // 
            this.colUltraSound_Grid_Mota.AppearanceCell.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUltraSound_Grid_Mota.AppearanceCell.Options.UseFont = true;
            this.colUltraSound_Grid_Mota.Caption = "Mô tả";
            this.colUltraSound_Grid_Mota.FieldName = "TenMota";
            this.colUltraSound_Grid_Mota.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUltraSound_Grid_Mota.Name = "colUltraSound_Grid_Mota";
            this.colUltraSound_Grid_Mota.Visible = true;
            this.colUltraSound_Grid_Mota.VisibleIndex = 0;
            this.colUltraSound_Grid_Mota.Width = 225;
            // 
            // repositoryItemRichTextEdit7
            // 
            this.repositoryItemRichTextEdit7.Name = "repositoryItemRichTextEdit7";
            this.repositoryItemRichTextEdit7.ShowCaretInReadOnly = false;
            // 
            // repositoryItemRichTextEdit8
            // 
            this.repositoryItemRichTextEdit8.Name = "repositoryItemRichTextEdit8";
            this.repositoryItemRichTextEdit8.ShowCaretInReadOnly = false;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Font = new System.Drawing.Font("Arial", 8.25F);
            this.repositoryItemMemoEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // pnUltraSoundfreeText
            // 
            this.pnUltraSoundfreeText.Controls.Add(this.gcUltrasound);
            this.pnUltraSoundfreeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnUltraSoundfreeText.Location = new System.Drawing.Point(3, 32);
            this.pnUltraSoundfreeText.Name = "pnUltraSoundfreeText";
            this.pnUltraSoundfreeText.Size = new System.Drawing.Size(934, 566);
            this.pnUltraSoundfreeText.TabIndex = 37;
            this.pnUltraSoundfreeText.Visible = false;
            // 
            // gcUltrasound
            // 
            this.gcUltrasound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUltrasound.Location = new System.Drawing.Point(2, 2);
            this.gcUltrasound.MainView = this.grdUltrasound;
            this.gcUltrasound.Name = "gcUltrasound";
            this.gcUltrasound.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1,
            this.repositoryItemRichTextEdit2});
            this.gcUltrasound.Size = new System.Drawing.Size(930, 562);
            this.gcUltrasound.TabIndex = 34;
            this.gcUltrasound.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdUltrasound});
            // 
            // grdUltrasound
            // 
            this.grdUltrasound.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.EvenRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.FilterPanel.Options.UseFont = true;
            this.grdUltrasound.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdUltrasound.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.grdUltrasound.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdUltrasound.Appearance.FocusedCell.Options.UseFont = true;
            this.grdUltrasound.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdUltrasound.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.FocusedRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdUltrasound.Appearance.FooterPanel.Options.UseFont = true;
            this.grdUltrasound.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.GroupButton.Options.UseFont = true;
            this.grdUltrasound.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdUltrasound.Appearance.GroupFooter.Options.UseFont = true;
            this.grdUltrasound.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdUltrasound.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdUltrasound.Appearance.GroupRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdUltrasound.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdUltrasound.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdUltrasound.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.HorzLine.Options.UseFont = true;
            this.grdUltrasound.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.OddRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.Row.Options.UseFont = true;
            this.grdUltrasound.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.RowSeparator.Options.UseFont = true;
            this.grdUltrasound.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grdUltrasound.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdUltrasound.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grdUltrasound.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdUltrasound.Appearance.SelectedRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdUltrasound.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.TopNewRow.Options.UseFont = true;
            this.grdUltrasound.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdUltrasound.Appearance.VertLine.Options.UseFont = true;
            this.grdUltrasound.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUltrasound_BacSi,
            this.colUltrasound_YeuCau,
            this.colUltrasound_KetLuan,
            this.colUltrasound_NoiDung1,
            this.colUltrasound_HinhKetQua1,
            this.colUltrasound_HinhKetQua2});
            this.grdUltrasound.GridControl = this.gcUltrasound;
            this.grdUltrasound.GroupCount = 1;
            this.grdUltrasound.GroupFormat = "{0}: [#image]{1}{2}";
            this.grdUltrasound.Name = "grdUltrasound";
            this.grdUltrasound.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdUltrasound.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdUltrasound.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdUltrasound.OptionsView.ColumnAutoWidth = false;
            this.grdUltrasound.OptionsView.RowAutoHeight = true;
            this.grdUltrasound.OptionsView.ShowGroupPanel = false;
            this.grdUltrasound.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUltrasound_BacSi, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUltrasound_BacSi
            // 
            this.colUltrasound_BacSi.Caption = "Bác sĩ";
            this.colUltrasound_BacSi.FieldName = "BacSi";
            this.colUltrasound_BacSi.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUltrasound_BacSi.Name = "colUltrasound_BacSi";
            this.colUltrasound_BacSi.Visible = true;
            this.colUltrasound_BacSi.VisibleIndex = 1;
            // 
            // colUltrasound_YeuCau
            // 
            this.colUltrasound_YeuCau.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUltrasound_YeuCau.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.colUltrasound_YeuCau.AppearanceCell.Options.UseFont = true;
            this.colUltrasound_YeuCau.AppearanceCell.Options.UseForeColor = true;
            this.colUltrasound_YeuCau.Caption = "Tên yêu cầu";
            this.colUltrasound_YeuCau.FieldName = "TenMauSieuAm";
            this.colUltrasound_YeuCau.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUltrasound_YeuCau.Name = "colUltrasound_YeuCau";
            this.colUltrasound_YeuCau.Visible = true;
            this.colUltrasound_YeuCau.VisibleIndex = 0;
            this.colUltrasound_YeuCau.Width = 200;
            // 
            // colUltrasound_KetLuan
            // 
            this.colUltrasound_KetLuan.AppearanceCell.Options.UseTextOptions = true;
            this.colUltrasound_KetLuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUltrasound_KetLuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUltrasound_KetLuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUltrasound_KetLuan.Caption = "Kết luận";
            this.colUltrasound_KetLuan.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.colUltrasound_KetLuan.FieldName = "Ketluan";
            this.colUltrasound_KetLuan.Name = "colUltrasound_KetLuan";
            this.colUltrasound_KetLuan.Visible = true;
            this.colUltrasound_KetLuan.VisibleIndex = 1;
            this.colUltrasound_KetLuan.Width = 225;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // colUltrasound_NoiDung1
            // 
            this.colUltrasound_NoiDung1.AppearanceCell.Options.UseTextOptions = true;
            this.colUltrasound_NoiDung1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUltrasound_NoiDung1.AppearanceHeader.Options.UseTextOptions = true;
            this.colUltrasound_NoiDung1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUltrasound_NoiDung1.Caption = "Nội dung siêu âm";
            this.colUltrasound_NoiDung1.ColumnEdit = this.repositoryItemRichTextEdit2;
            this.colUltrasound_NoiDung1.FieldName = "NoiDung1";
            this.colUltrasound_NoiDung1.Name = "colUltrasound_NoiDung1";
            this.colUltrasound_NoiDung1.Visible = true;
            this.colUltrasound_NoiDung1.VisibleIndex = 2;
            this.colUltrasound_NoiDung1.Width = 215;
            // 
            // repositoryItemRichTextEdit2
            // 
            this.repositoryItemRichTextEdit2.Name = "repositoryItemRichTextEdit2";
            this.repositoryItemRichTextEdit2.ShowCaretInReadOnly = false;
            // 
            // colUltrasound_HinhKetQua1
            // 
            this.colUltrasound_HinhKetQua1.Caption = "Hình ảnh 1";
            this.colUltrasound_HinhKetQua1.FieldName = "HinhKetQua1";
            this.colUltrasound_HinhKetQua1.Name = "colUltrasound_HinhKetQua1";
            this.colUltrasound_HinhKetQua1.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUltrasound_HinhKetQua1.Visible = true;
            this.colUltrasound_HinhKetQua1.VisibleIndex = 3;
            this.colUltrasound_HinhKetQua1.Width = 125;
            // 
            // colUltrasound_HinhKetQua2
            // 
            this.colUltrasound_HinhKetQua2.Caption = "Hình ảnh 2";
            this.colUltrasound_HinhKetQua2.FieldName = "HinhKetQua1";
            this.colUltrasound_HinhKetQua2.Name = "colUltrasound_HinhKetQua2";
            this.colUltrasound_HinhKetQua2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colUltrasound_HinhKetQua2.Visible = true;
            this.colUltrasound_HinhKetQua2.VisibleIndex = 4;
            this.colUltrasound_HinhKetQua2.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radKetQuaSieuAm_VanBan);
            this.panel2.Controls.Add(this.radKetQuaSieuAm_Luoi);
            this.panel2.Controls.Add(this.btnRefreshUltraSound);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 29);
            this.panel2.TabIndex = 36;
            // 
            // radKetQuaSieuAm_VanBan
            // 
            this.radKetQuaSieuAm_VanBan.AutoSize = true;
            this.radKetQuaSieuAm_VanBan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radKetQuaSieuAm_VanBan.Location = new System.Drawing.Point(205, 4);
            this.radKetQuaSieuAm_VanBan.Name = "radKetQuaSieuAm_VanBan";
            this.radKetQuaSieuAm_VanBan.Size = new System.Drawing.Size(146, 19);
            this.radKetQuaSieuAm_VanBan.TabIndex = 37;
            this.radKetQuaSieuAm_VanBan.Text = "Kết quả dạng văn bản";
            this.radKetQuaSieuAm_VanBan.UseVisualStyleBackColor = true;
            this.radKetQuaSieuAm_VanBan.CheckedChanged += new System.EventHandler(this.radKetQuaSieuAm_VanBan_CheckedChanged);
            // 
            // radKetQuaSieuAm_Luoi
            // 
            this.radKetQuaSieuAm_Luoi.AutoSize = true;
            this.radKetQuaSieuAm_Luoi.BackColor = System.Drawing.Color.Yellow;
            this.radKetQuaSieuAm_Luoi.Checked = true;
            this.radKetQuaSieuAm_Luoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radKetQuaSieuAm_Luoi.Location = new System.Drawing.Point(63, 4);
            this.radKetQuaSieuAm_Luoi.Name = "radKetQuaSieuAm_Luoi";
            this.radKetQuaSieuAm_Luoi.Size = new System.Drawing.Size(126, 19);
            this.radKetQuaSieuAm_Luoi.TabIndex = 36;
            this.radKetQuaSieuAm_Luoi.TabStop = true;
            this.radKetQuaSieuAm_Luoi.Text = "Kết quả dạng lưới";
            this.radKetQuaSieuAm_Luoi.UseVisualStyleBackColor = false;
            this.radKetQuaSieuAm_Luoi.CheckedChanged += new System.EventHandler(this.radKetQuaSieuAm_Luoi_CheckedChanged);
            // 
            // btnRefreshUltraSound
            // 
            this.btnRefreshUltraSound.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUltraSound.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshUltraSound.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshUltraSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefreshUltraSound.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshUltraSound.BorderRadius = 0;
            this.btnRefreshUltraSound.BorderSize = 0;
            this.btnRefreshUltraSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUltraSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUltraSound.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshUltraSound.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshUltraSound.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshUltraSound.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnRefreshUltraSound.Location = new System.Drawing.Point(0, 3);
            this.btnRefreshUltraSound.Name = "btnRefreshUltraSound";
            this.btnRefreshUltraSound.Size = new System.Drawing.Size(29, 23);
            this.btnRefreshUltraSound.TabIndex = 35;
            this.btnRefreshUltraSound.TextColor = System.Drawing.Color.Black;
            this.btnRefreshUltraSound.UseHightLight = true;
            this.btnRefreshUltraSound.UseVisualStyleBackColor = false;
            this.btnRefreshUltraSound.Click += new System.EventHandler(this.btnRefreshUltraSound_Click);
            // 
            // tabEdoscopy
            // 
            this.tabEdoscopy.Controls.Add(this.btnRefreshEdoscopic);
            this.tabEdoscopy.Controls.Add(this.gcEdoscopic);
            this.tabEdoscopy.Location = new System.Drawing.Point(4, 24);
            this.tabEdoscopy.Name = "tabEdoscopy";
            this.tabEdoscopy.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdoscopy.Size = new System.Drawing.Size(940, 601);
            this.tabEdoscopy.TabIndex = 5;
            this.tabEdoscopy.Tag = "ClsNoiSoi";
            this.tabEdoscopy.Text = "Lịch sử nội soi";
            this.tabEdoscopy.UseVisualStyleBackColor = true;
            // 
            // btnRefreshEdoscopic
            // 
            this.btnRefreshEdoscopic.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshEdoscopic.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshEdoscopic.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshEdoscopic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshEdoscopic.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshEdoscopic.BorderRadius = 0;
            this.btnRefreshEdoscopic.BorderSize = 0;
            this.btnRefreshEdoscopic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshEdoscopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshEdoscopic.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshEdoscopic.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshEdoscopic.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshEdoscopic.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnRefreshEdoscopic.Location = new System.Drawing.Point(2, 3);
            this.btnRefreshEdoscopic.Name = "btnRefreshEdoscopic";
            this.btnRefreshEdoscopic.Size = new System.Drawing.Size(22, 23);
            this.btnRefreshEdoscopic.TabIndex = 37;
            this.btnRefreshEdoscopic.TextColor = System.Drawing.Color.Black;
            this.btnRefreshEdoscopic.UseHightLight = true;
            this.btnRefreshEdoscopic.UseVisualStyleBackColor = false;
            this.btnRefreshEdoscopic.Click += new System.EventHandler(this.btnRefreshEdoscopic_Click);
            // 
            // gcEdoscopic
            // 
            this.gcEdoscopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEdoscopic.Location = new System.Drawing.Point(3, 3);
            this.gcEdoscopic.MainView = this.grdEdoscopic;
            this.gcEdoscopic.Name = "gcEdoscopic";
            this.gcEdoscopic.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit3,
            this.repositoryItemRichTextEdit4});
            this.gcEdoscopic.Size = new System.Drawing.Size(934, 595);
            this.gcEdoscopic.TabIndex = 36;
            this.gcEdoscopic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdEdoscopic});
            // 
            // grdEdoscopic
            // 
            this.grdEdoscopic.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.EvenRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.FilterPanel.Options.UseFont = true;
            this.grdEdoscopic.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdEdoscopic.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.grdEdoscopic.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdEdoscopic.Appearance.FocusedCell.Options.UseFont = true;
            this.grdEdoscopic.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdEdoscopic.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.FocusedRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdEdoscopic.Appearance.FooterPanel.Options.UseFont = true;
            this.grdEdoscopic.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.GroupButton.Options.UseFont = true;
            this.grdEdoscopic.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdEdoscopic.Appearance.GroupFooter.Options.UseFont = true;
            this.grdEdoscopic.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdEdoscopic.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdEdoscopic.Appearance.GroupRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdEdoscopic.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdEdoscopic.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdEdoscopic.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.HorzLine.Options.UseFont = true;
            this.grdEdoscopic.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.OddRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.Row.Options.UseFont = true;
            this.grdEdoscopic.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.RowSeparator.Options.UseFont = true;
            this.grdEdoscopic.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grdEdoscopic.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdEdoscopic.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grdEdoscopic.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdEdoscopic.Appearance.SelectedRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdEdoscopic.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.TopNewRow.Options.UseFont = true;
            this.grdEdoscopic.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdEdoscopic.Appearance.VertLine.Options.UseFont = true;
            this.grdEdoscopic.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grdEdoscopic.GridControl = this.gcEdoscopic;
            this.grdEdoscopic.GroupCount = 1;
            this.grdEdoscopic.GroupFormat = "{0}: [#image]{1}{2}";
            this.grdEdoscopic.Name = "grdEdoscopic";
            this.grdEdoscopic.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdEdoscopic.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdEdoscopic.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdEdoscopic.OptionsView.ColumnAutoWidth = false;
            this.grdEdoscopic.OptionsView.RowAutoHeight = true;
            this.grdEdoscopic.OptionsView.ShowGroupPanel = false;
            this.grdEdoscopic.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Bác sĩ";
            this.gridColumn1.FieldName = "BacSi";
            this.gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn2.Caption = "Tên yêu cầu";
            this.gridColumn2.FieldName = "TenMauNoiSoi";
            this.gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Kết luận";
            this.gridColumn3.ColumnEdit = this.repositoryItemRichTextEdit3;
            this.gridColumn3.FieldName = "Ketluan";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 225;
            // 
            // repositoryItemRichTextEdit3
            // 
            this.repositoryItemRichTextEdit3.Name = "repositoryItemRichTextEdit3";
            this.repositoryItemRichTextEdit3.ShowCaretInReadOnly = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "Nội dung nội soi";
            this.gridColumn4.ColumnEdit = this.repositoryItemRichTextEdit4;
            this.gridColumn4.FieldName = "NoiDung1";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 215;
            // 
            // repositoryItemRichTextEdit4
            // 
            this.repositoryItemRichTextEdit4.Name = "repositoryItemRichTextEdit4";
            this.repositoryItemRichTextEdit4.ShowCaretInReadOnly = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Hình ảnh 1";
            this.gridColumn5.FieldName = "HinhKetQua1";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 125;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Hình ảnh 2";
            this.gridColumn6.FieldName = "HinhKetQua1";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 125;
            // 
            // tabXRay
            // 
            this.tabXRay.Controls.Add(this.btnRefreshXRay);
            this.tabXRay.Controls.Add(this.gcXRay);
            this.tabXRay.Location = new System.Drawing.Point(4, 24);
            this.tabXRay.Name = "tabXRay";
            this.tabXRay.Padding = new System.Windows.Forms.Padding(3);
            this.tabXRay.Size = new System.Drawing.Size(940, 601);
            this.tabXRay.TabIndex = 6;
            this.tabXRay.Tag = "ClsXQuang";
            this.tabXRay.Text = "Lịch sử XQuang";
            this.tabXRay.UseVisualStyleBackColor = true;
            // 
            // btnRefreshXRay
            // 
            this.btnRefreshXRay.BackColor = System.Drawing.Color.Transparent;
            this.btnRefreshXRay.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefreshXRay.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRefreshXRay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshXRay.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefreshXRay.BorderRadius = 0;
            this.btnRefreshXRay.BorderSize = 0;
            this.btnRefreshXRay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshXRay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshXRay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshXRay.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefreshXRay.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshXRay.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnRefreshXRay.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshXRay.Name = "btnRefreshXRay";
            this.btnRefreshXRay.Size = new System.Drawing.Size(23, 24);
            this.btnRefreshXRay.TabIndex = 39;
            this.btnRefreshXRay.TextColor = System.Drawing.Color.Black;
            this.btnRefreshXRay.UseHightLight = true;
            this.btnRefreshXRay.UseVisualStyleBackColor = false;
            this.btnRefreshXRay.Click += new System.EventHandler(this.btnRefreshXRay_Click);
            // 
            // gcXRay
            // 
            this.gcXRay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcXRay.Location = new System.Drawing.Point(3, 3);
            this.gcXRay.MainView = this.grdXRay;
            this.gcXRay.Name = "gcXRay";
            this.gcXRay.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit5,
            this.repositoryItemRichTextEdit6});
            this.gcXRay.Size = new System.Drawing.Size(934, 595);
            this.gcXRay.TabIndex = 38;
            this.gcXRay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdXRay});
            // 
            // grdXRay
            // 
            this.grdXRay.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.EvenRow.Options.UseFont = true;
            this.grdXRay.Appearance.FilterPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.FilterPanel.Options.UseFont = true;
            this.grdXRay.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdXRay.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Red;
            this.grdXRay.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdXRay.Appearance.FocusedCell.Options.UseFont = true;
            this.grdXRay.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdXRay.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.FocusedRow.Options.UseFont = true;
            this.grdXRay.Appearance.FooterPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdXRay.Appearance.FooterPanel.Options.UseFont = true;
            this.grdXRay.Appearance.GroupButton.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.GroupButton.Options.UseFont = true;
            this.grdXRay.Appearance.GroupFooter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdXRay.Appearance.GroupFooter.Options.UseFont = true;
            this.grdXRay.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdXRay.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grdXRay.Appearance.GroupRow.Options.UseFont = true;
            this.grdXRay.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdXRay.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdXRay.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdXRay.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdXRay.Appearance.HorzLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.HorzLine.Options.UseFont = true;
            this.grdXRay.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.OddRow.Options.UseFont = true;
            this.grdXRay.Appearance.Row.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.Row.Options.UseFont = true;
            this.grdXRay.Appearance.RowSeparator.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.RowSeparator.Options.UseFont = true;
            this.grdXRay.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grdXRay.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.grdXRay.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grdXRay.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdXRay.Appearance.SelectedRow.Options.UseFont = true;
            this.grdXRay.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdXRay.Appearance.TopNewRow.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.TopNewRow.Options.UseFont = true;
            this.grdXRay.Appearance.VertLine.Font = new System.Drawing.Font("Arial", 9F);
            this.grdXRay.Appearance.VertLine.Options.UseFont = true;
            this.grdXRay.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.grdXRay.GridControl = this.gcXRay;
            this.grdXRay.GroupCount = 1;
            this.grdXRay.GroupFormat = "{0}: [#image]{1}{2}";
            this.grdXRay.Name = "grdXRay";
            this.grdXRay.OptionsBehavior.AutoExpandAllGroups = true;
            this.grdXRay.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.grdXRay.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grdXRay.OptionsView.ColumnAutoWidth = false;
            this.grdXRay.OptionsView.RowAutoHeight = true;
            this.grdXRay.OptionsView.ShowGroupPanel = false;
            this.grdXRay.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn7, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Bác sĩ";
            this.gridColumn7.FieldName = "BacSi";
            this.gridColumn7.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn8.Caption = "Tên yêu cầu";
            this.gridColumn8.FieldName = "TenVungChup";
            this.gridColumn8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 200;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn9.Caption = "Kết luận";
            this.gridColumn9.FieldName = "Ketluan";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 225;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn10.Caption = "Kết quả chi tiết";
            this.gridColumn10.ColumnEdit = this.repositoryItemRichTextEdit6;
            this.gridColumn10.FieldName = "KetQua";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 215;
            // 
            // repositoryItemRichTextEdit6
            // 
            this.repositoryItemRichTextEdit6.Name = "repositoryItemRichTextEdit6";
            this.repositoryItemRichTextEdit6.ShowCaretInReadOnly = false;
            // 
            // repositoryItemRichTextEdit5
            // 
            this.repositoryItemRichTextEdit5.Name = "repositoryItemRichTextEdit5";
            this.repositoryItemRichTextEdit5.ShowCaretInReadOnly = false;
            // 
            // tabLichSuKSD
            // 
            this.tabLichSuKSD.Controls.Add(this.btnXemLichSuKSD);
            this.tabLichSuKSD.Controls.Add(this.ucLichSuKhangSinhDo1);
            this.tabLichSuKSD.Location = new System.Drawing.Point(4, 24);
            this.tabLichSuKSD.Name = "tabLichSuKSD";
            this.tabLichSuKSD.Padding = new System.Windows.Forms.Padding(3);
            this.tabLichSuKSD.Size = new System.Drawing.Size(940, 601);
            this.tabLichSuKSD.TabIndex = 8;
            this.tabLichSuKSD.Tag = "ClsXNViSinh";
            this.tabLichSuKSD.Text = "Lịch sử KSD";
            this.tabLichSuKSD.UseVisualStyleBackColor = true;
            // 
            // btnXemLichSuKSD
            // 
            this.btnXemLichSuKSD.BackColor = System.Drawing.Color.Transparent;
            this.btnXemLichSuKSD.BackColorHover = System.Drawing.Color.Empty;
            this.btnXemLichSuKSD.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnXemLichSuKSD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXemLichSuKSD.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemLichSuKSD.BorderRadius = 0;
            this.btnXemLichSuKSD.BorderSize = 0;
            this.btnXemLichSuKSD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemLichSuKSD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemLichSuKSD.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemLichSuKSD.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXemLichSuKSD.ForeColor = System.Drawing.Color.Black;
            this.btnXemLichSuKSD.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnXemLichSuKSD.Location = new System.Drawing.Point(3, 1);
            this.btnXemLichSuKSD.Name = "btnXemLichSuKSD";
            this.btnXemLichSuKSD.Size = new System.Drawing.Size(22, 23);
            this.btnXemLichSuKSD.TabIndex = 34;
            this.btnXemLichSuKSD.TextColor = System.Drawing.Color.Black;
            this.btnXemLichSuKSD.UseHightLight = true;
            this.btnXemLichSuKSD.UseVisualStyleBackColor = false;
            this.btnXemLichSuKSD.Click += new System.EventHandler(this.btnXemLichSuKSD_Click);
            // 
            // ucLichSuKhangSinhDo1
            // 
            this.ucLichSuKhangSinhDo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLichSuKhangSinhDo1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLichSuKhangSinhDo1.Location = new System.Drawing.Point(3, 3);
            this.ucLichSuKhangSinhDo1.Name = "ucLichSuKhangSinhDo1";
            this.ucLichSuKhangSinhDo1.Size = new System.Drawing.Size(934, 595);
            this.ucLichSuKhangSinhDo1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgPatientList);
            this.panel1.Controls.Add(this.bvPatientList);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 630);
            this.panel1.TabIndex = 102;
            // 
            // dtgPatientList
            // 
            this.dtgPatientList.AlignColumns = "";
            this.dtgPatientList.AllignNumberText = false;
            this.dtgPatientList.AllowUserToAddRows = false;
            this.dtgPatientList.AllowUserToDeleteRows = false;
            this.dtgPatientList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgPatientList.CheckBoldColumn = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPatientList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgPatientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenBN,
            this.MaBN});
            this.dtgPatientList.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPatientList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgPatientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPatientList.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgPatientList.Location = new System.Drawing.Point(2, 107);
            this.dtgPatientList.MarkOddEven = true;
            this.dtgPatientList.MultiSelect = false;
            this.dtgPatientList.Name = "dtgPatientList";
            this.dtgPatientList.ReadOnly = true;
            this.dtgPatientList.RowHeadersWidth = 20;
            this.dtgPatientList.RowTemplate.Height = 28;
            this.dtgPatientList.Size = new System.Drawing.Size(224, 494);
            this.dtgPatientList.TabIndex = 4;
            this.dtgPatientList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPatientList_CellEnter);
            // 
            // TenBN
            // 
            this.TenBN.DataPropertyName = "TenBN";
            this.TenBN.HeaderText = "TÊN BỆNH NHÂN";
            this.TenBN.MinimumWidth = 6;
            this.TenBN.Name = "TenBN";
            this.TenBN.ReadOnly = true;
            this.TenBN.Width = 250;
            // 
            // MaBN
            // 
            this.MaBN.DataPropertyName = "MaBN";
            this.MaBN.HeaderText = "MÃ BN";
            this.MaBN.MinimumWidth = 6;
            this.MaBN.Name = "MaBN";
            this.MaBN.ReadOnly = true;
            this.MaBN.Width = 150;
            // 
            // bvPatientList
            // 
            this.bvPatientList.AddNewItem = null;
            this.bvPatientList.CountItem = this.toolStripLabel3;
            this.bvPatientList.CountItemFormat = "/ {0}";
            this.bvPatientList.DeleteItem = null;
            this.bvPatientList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvPatientList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvPatientList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvPatientList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvPatientList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox3,
            this.toolStripLabel3,
            this.toolStripSeparator3,
            this.toolStripButton4});
            this.bvPatientList.Location = new System.Drawing.Point(2, 601);
            this.bvPatientList.MoveFirstItem = null;
            this.bvPatientList.MoveLastItem = null;
            this.bvPatientList.MoveNextItem = null;
            this.bvPatientList.MovePreviousItem = null;
            this.bvPatientList.Name = "bvPatientList";
            this.bvPatientList.PositionItem = this.toolStripTextBox3;
            this.bvPatientList.Size = new System.Drawing.Size(224, 27);
            this.bvPatientList.TabIndex = 5;
            this.bvPatientList.Text = "bindingNavigator2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 24);
            this.toolStripLabel3.Text = "/ {0}";
            this.toolStripLabel3.ToolTipText = "Total number of items";
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.AccessibleName = "Position";
            this.toolStripTextBox3.AutoSize = false;
            this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(44, 23);
            this.toolStripTextBox3.Text = "0";
            this.toolStripTextBox3.ToolTipText = "Current position";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(82, 24);
            this.toolStripButton4.Text = "Làm mới";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "no_image.jpg");
            // 
            // FrmHoSoBenhAn
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Name = "FrmHoSoBenhAn";
            this.Text = "Hồ sơ bệnh án";
            this.Load += new System.EventHandler(this.FrmHoSoBenhAn_Load);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabThongTin.ResumeLayout(false);
            this.tabPatientInfomation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnHisreception)).EndInit();
            this.pnHisreception.ResumeLayout(false);
            this.pnHisreception.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReceptionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvReceptionList)).EndInit();
            this.bvReceptionList.ResumeLayout(false);
            this.bvReceptionList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnPatientInfo)).EndInit();
            this.pnPatientInfo.ResumeLayout(false);
            this.pnPatientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatientImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabDiagnostic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChanDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLichSuChanDoan)).EndInit();
            this.tabPrescribe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPrescribe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrescribe)).EndInit();
            this.tabTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnChart)).EndInit();
            this.pnChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcXetNghiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMainXetnghiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel5)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tabUltraSound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnUltraSoundGirid)).EndInit();
            this.pnUltraSoundGirid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUltraSound_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUltraSound_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnUltraSoundfreeText)).EndInit();
            this.pnUltraSoundfreeText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUltrasound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUltrasound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabEdoscopy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEdoscopic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEdoscopic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit4)).EndInit();
            this.tabXRay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcXRay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXRay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit5)).EndInit();
            this.tabLichSuKSD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatientList)).EndInit();
            this.bvPatientList.ResumeLayout(false);
            this.bvPatientList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabThongTin;
        private System.Windows.Forms.TabPage tabPatientInfomation;
        private System.Windows.Forms.TextBox txtQuanHuyen;
        private System.Windows.Forms.TextBox txtTinh;
        private CustomComboBox cboQuanHuyen;
        private DevExpress.XtraEditors.LabelControl label20;
        private DevExpress.XtraEditors.LabelControl label19;
        private System.Windows.Forms.TextBox txtNoiLamViec;
        private CustomComboBox cboTinh;
        private System.Windows.Forms.TextBox txtSex;
        private DevExpress.XtraEditors.LabelControl label12;
        private System.Windows.Forms.CheckBox chkAgeType;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.TextBox txtTenBN;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private DevExpress.XtraEditors.LabelControl label6;
        private System.Windows.Forms.TextBox txtEmail;
        private DevExpress.XtraEditors.LabelControl label7;
        private System.Windows.Forms.TextBox txtAge;
        private DevExpress.XtraEditors.LabelControl label5;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private TPH.Controls.TPHNormalButton btnSearchPatient;
        private System.Windows.Forms.TextBox txtSearchPID;
        private DevExpress.XtraEditors.LabelControl label18;
        private DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.TextBox txtSearchName;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label9;
        private DevExpress.XtraEditors.LabelControl label8;
        private System.Windows.Forms.TextBox txtDanToc;
        private System.Windows.Forms.TextBox txtNgheNghiep;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoNha;
        private DevExpress.XtraEditors.LabelControl label10;
        private System.Windows.Forms.TextBox txtPhuongXa;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraEditors.LabelControl label13;
        private System.Windows.Forms.TextBox txtHocVan;
        private System.Windows.Forms.TextBox txtQuocTich;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.LabelControl label14;
        private DevExpress.XtraEditors.LabelControl label15;
        private DevExpress.XtraEditors.PanelControl pnPatientInfo;
        private DevExpress.XtraEditors.PanelControl pnHisreception;
        private CustomBindingNavigator bvReceptionList;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private CustomComboBox cboSend_Location;
        private System.Windows.Forms.TextBox txtSend_Location;
        private DevExpress.XtraEditors.LabelControl label21;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private DevExpress.XtraEditors.LabelControl label17;
        private System.Windows.Forms.RadioButton radReturn;
        private System.Windows.Forms.RadioButton radFirstTime;
        private CustomComboBox cboSend_Diagnostic;
        private System.Windows.Forms.TextBox txtSend_Diagnostic;
        private DevExpress.XtraEditors.LabelControl label23;
        private System.Windows.Forms.TextBox txtDoctorComment;
        private DevExpress.XtraEditors.LabelControl label22;
        private DevExpress.XtraEditors.LabelControl lblRecptionID;
        private DevExpress.XtraEditors.LabelControl label24;
        private DevExpress.XtraEditors.LabelControl lblPatientID;
        private CustomComboBox cboDiagnostic;
        private System.Windows.Forms.TextBox txtDiagnostic;
        private DevExpress.XtraEditors.LabelControl label25;
        private System.Windows.Forms.TabPage tabPrescribe;
        private CustomComboBox multiColumnComboBox5;
        private System.Windows.Forms.TextBox textBox7;
        private DevExpress.XtraEditors.LabelControl label27;
        private DevExpress.XtraEditors.LabelControl label26;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private DevExpress.XtraEditors.PanelControl panel3;
        private DevExpress.XtraEditors.LabelControl label16;
        private System.Windows.Forms.PictureBox pbPatientImage;
        private TPH.Controls.TPHNormalButton btnReMoveImage;
        private TPH.Controls.TPHNormalButton btnAddImage;
        private CustomBindingNavigator bvPatientList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBN;
        private CustomDatagridView dtgReceptionList;
        private CustomDatagridView dtgPatientList;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTiepNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTiepNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn BacSiCD;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.TabPage tabUltraSound;
        private System.Windows.Forms.TabPage tabEdoscopy;
        private System.Windows.Forms.TabPage tabXRay;
        private System.Windows.Forms.TabPage tabDiagnostic;
        private DevExpress.XtraGrid.GridControl gcChanDoan;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLichSuChanDoan;
        private DevExpress.XtraGrid.Columns.GridColumn gclBacSi;
        private DevExpress.XtraGrid.Columns.GridColumn gclKetQuaChanDoan;
        private DevExpress.XtraGrid.GridControl gcXetNghiem;
        private DevExpress.XtraGrid.Views.Grid.GridView grdMainXetnghiem;
        private DevExpress.XtraGrid.Columns.GridColumn grcolNhom;
        private DevExpress.XtraGrid.Columns.GridColumn grcolTenXN;
        private DevExpress.XtraGrid.Columns.GridColumn grcolMaXN;
        private TPH.Controls.TPHNormalButton btnRefreshTest;
        private TPH.Controls.TPHNormalButton btnRefreshDiagnostic;
        private TPH.Controls.TPHNormalButton btnRefreshPrescribe;
        private DevExpress.XtraGrid.GridControl gcPrescribe;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPrescribe;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_BacSi;
        private DevExpress.XtraGrid.Columns.GridColumn grdPrescribe_MedicineName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescride_Soluong;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_Sang;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_Trua;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_Chieu;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_GhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_CachDung;
        private DevExpress.XtraGrid.Columns.GridColumn colPrescribe_DonViTinh;
        private TPH.Controls.TPHNormalButton btnRefreshUltraSound;
        private DevExpress.XtraGrid.GridControl gcUltrasound;
        private DevExpress.XtraGrid.Views.Grid.GridView grdUltrasound;
        private DevExpress.XtraGrid.Columns.GridColumn colUltrasound_BacSi;
        private DevExpress.XtraGrid.Columns.GridColumn colUltrasound_YeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn colUltrasound_KetLuan;
        private DevExpress.XtraGrid.Columns.GridColumn colUltrasound_NoiDung1;
        private DevExpress.XtraGrid.Columns.GridColumn colUltrasound_HinhKetQua1;
        private DevExpress.XtraGrid.Columns.GridColumn colUltrasound_HinhKetQua2;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit2;
        private TPH.Controls.TPHNormalButton btnRefreshEdoscopic;
        private DevExpress.XtraGrid.GridControl gcEdoscopic;
        private DevExpress.XtraGrid.Views.Grid.GridView grdEdoscopic;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private TPH.Controls.TPHNormalButton btnRefreshXRay;
        private DevExpress.XtraGrid.GridControl gcXRay;
        private DevExpress.XtraGrid.Views.Grid.GridView grdXRay;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit6;
        private DevExpress.XtraEditors.PanelControl panel2;
        private System.Windows.Forms.RadioButton radKetQuaSieuAm_VanBan;
        private System.Windows.Forms.RadioButton radKetQuaSieuAm_Luoi;
        private DevExpress.XtraEditors.PanelControl pnUltraSoundGirid;
        private DevExpress.XtraGrid.GridControl gcUltraSound_Grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUltraSound_Grid;
        private DevExpress.XtraGrid.Columns.GridColumn colUltraSound_Grid_YeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn colUltraSound_Grid_Mota;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit8;
        private DevExpress.XtraEditors.PanelControl pnUltraSoundfreeText;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn grcolThuTuInNhom;
        private DevExpress.XtraGrid.Columns.GridColumn grcolSapXep;
        private DevExpress.XtraEditors.PanelControl pnChart;
        private DevExpress.XtraEditors.PanelControl panel5;
        private TPH.Controls.TPHNormalButton btnDongBieuDo;
        private TPH.Controls.TPHNormalButton btnXemBieuDo;
        private TPH.Controls.TPHNormalButton btnPhongToBieuDo;
        private Common.Controls.Chart.CustomChart customChart1;
        private System.Windows.Forms.TabPage tabLichSuKSD;
        private HIS.Controls.ucLichSuKhangSinhDo ucLichSuKhangSinhDo1;
        private TPH.Controls.TPHNormalButton btnXemLichSuKSD;
    }
}