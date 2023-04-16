namespace TPH.LIS.App.ActionLog
{
    partial class FrmDeleteCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeleteCustomer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bvPatient = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.btnCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnKQXetNghiem = new System.Windows.Forms.ToolStripButton();
            this.btnKQSieuAm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXemKQNoiSoi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnKQXQuang = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dtgPatient = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTiepNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChanDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetLuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearchSEQ = new TPH.Controls.TPHNormalButton();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvPatient)).BeginInit();
            this.bvPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatient)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(5, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Size = new System.Drawing.Size(1287, 29);
            this.lblTitle.Text = "TÌM BỆNH NHÂN ĐÃ XÓA";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.dtgPatient);
            this.pnContaint.Controls.Add(this.bvPatient);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Location = new System.Drawing.Point(1, 44);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(4);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(5);
            this.pnContaint.Size = new System.Drawing.Size(1297, 487);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // bvPatient
            // 
            this.bvPatient.AddNewItem = null;
            this.bvPatient.CountItem = this.bindingNavigatorCountItem;
            this.bvPatient.CountItemFormat = "/ {0}";
            this.bvPatient.DeleteItem = null;
            this.bvPatient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvPatient.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.bvPatient.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvPatient.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCheckAll,
            this.toolStripSeparator2,
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnKQXetNghiem,
            this.btnKQSieuAm,
            this.toolStripSeparator4,
            this.btnXemKQNoiSoi,
            this.toolStripSeparator5,
            this.btnKQXQuang,
            this.toolStripSeparator3});
            this.bvPatient.Location = new System.Drawing.Point(5, 457);
            this.bvPatient.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvPatient.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvPatient.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvPatient.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvPatient.Name = "bvPatient";
            this.bvPatient.PositionItem = this.bindingNavigatorPositionItem;
            this.bvPatient.Size = new System.Drawing.Size(1287, 25);
            this.bvPatient.TabIndex = 1;
            this.bvPatient.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(39, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(55, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
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
            // btnKQXetNghiem
            // 
            this.btnKQXetNghiem.Name = "btnKQXetNghiem";
            this.btnKQXetNghiem.Size = new System.Drawing.Size(23, 22);
            // 
            // btnKQSieuAm
            // 
            this.btnKQSieuAm.Name = "btnKQSieuAm";
            this.btnKQSieuAm.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // btnXemKQNoiSoi
            // 
            this.btnXemKQNoiSoi.Image = ((System.Drawing.Image)(resources.GetObject("btnXemKQNoiSoi.Image")));
            this.btnXemKQNoiSoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXemKQNoiSoi.Name = "btnXemKQNoiSoi";
            this.btnXemKQNoiSoi.Size = new System.Drawing.Size(175, 22);
            this.btnXemKQNoiSoi.Text = "Xem kết quả Nội Soi";
            this.btnXemKQNoiSoi.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator5.Visible = false;
            // 
            // btnKQXQuang
            // 
            this.btnKQXQuang.Name = "btnKQXQuang";
            this.btnKQXQuang.Size = new System.Drawing.Size(23, 22);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTiepNhan,
            this.SEQ,
            this.TenBN,
            this.NgayTiepNhan,
            this.GioTinh,
            this.NamSinh,
            this.ChanDoan,
            this.KetLuan,
            this.ActionUser,
            this.ActionDate});
            this.dtgPatient.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPatient.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPatient.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgPatient.Location = new System.Drawing.Point(5, 51);
            this.dtgPatient.Margin = new System.Windows.Forms.Padding(4);
            this.dtgPatient.MarkOddEven = true;
            this.dtgPatient.MultiSelect = false;
            this.dtgPatient.Name = "dtgPatient";
            this.dtgPatient.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgPatient.ReadOnly = true;
            this.dtgPatient.RowHeadersVisible = false;
            this.dtgPatient.RowHeadersWidth = 35;
            this.dtgPatient.Size = new System.Drawing.Size(1287, 406);
            this.dtgPatient.TabIndex = 2;
            this.dtgPatient.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgPatient.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgPatient_DataBindingComplete);
            // 
            // MaTiepNhan
            // 
            this.MaTiepNhan.DataPropertyName = "MaTiepNhan";
            this.MaTiepNhan.HeaderText = "Mã tiếp nhận";
            this.MaTiepNhan.Name = "MaTiepNhan";
            this.MaTiepNhan.ReadOnly = true;
            this.MaTiepNhan.Width = 130;
            // 
            // SEQ
            // 
            this.SEQ.DataPropertyName = "SEQ";
            this.SEQ.HeaderText = "Số TT";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            // 
            // TenBN
            // 
            this.TenBN.DataPropertyName = "TenBN";
            this.TenBN.HeaderText = "Tên bệnh nhân";
            this.TenBN.Name = "TenBN";
            this.TenBN.ReadOnly = true;
            this.TenBN.Width = 250;
            // 
            // NgayTiepNhan
            // 
            this.NgayTiepNhan.DataPropertyName = "NgayTiepNhan";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.NgayTiepNhan.DefaultCellStyle = dataGridViewCellStyle2;
            this.NgayTiepNhan.HeaderText = "Ngày tiếp nhận";
            this.NgayTiepNhan.Name = "NgayTiepNhan";
            this.NgayTiepNhan.ReadOnly = true;
            this.NgayTiepNhan.Width = 150;
            // 
            // GioTinh
            // 
            this.GioTinh.DataPropertyName = "GioiTinh";
            this.GioTinh.HeaderText = "Giới tính";
            this.GioTinh.Name = "GioTinh";
            this.GioTinh.ReadOnly = true;
            this.GioTinh.Width = 90;
            // 
            // NamSinh
            // 
            this.NamSinh.DataPropertyName = "Tuoi";
            this.NamSinh.HeaderText = "Năm sinh";
            this.NamSinh.Name = "NamSinh";
            this.NamSinh.ReadOnly = true;
            this.NamSinh.Width = 95;
            // 
            // ChanDoan
            // 
            this.ChanDoan.DataPropertyName = "ChanDoan";
            this.ChanDoan.HeaderText = "Chẩn đoán";
            this.ChanDoan.Name = "ChanDoan";
            this.ChanDoan.ReadOnly = true;
            this.ChanDoan.Width = 250;
            // 
            // KetLuan
            // 
            this.KetLuan.DataPropertyName = "KetLuan";
            this.KetLuan.HeaderText = "Kết luận";
            this.KetLuan.Name = "KetLuan";
            this.KetLuan.ReadOnly = true;
            this.KetLuan.Width = 150;
            // 
            // ActionUser
            // 
            this.ActionUser.DataPropertyName = "actionuser";
            this.ActionUser.HeaderText = "Xóa bởi";
            this.ActionUser.Name = "ActionUser";
            this.ActionUser.ReadOnly = true;
            // 
            // ActionDate
            // 
            this.ActionDate.DataPropertyName = "actiondate";
            this.ActionDate.HeaderText = "Ngày xóa";
            this.ActionDate.Name = "ActionDate";
            this.ActionDate.ReadOnly = true;
            this.ActionDate.Width = 140;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(81, 9);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(118, 24);
            this.dtpDateFrom.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Từ ngày";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(288, 9);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(118, 24);
            this.dtpDateTo.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Đến ngày";
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(538, 9);
            this.txtSeq.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(118, 24);
            this.txtSeq.TabIndex = 35;
            this.txtSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeq_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 36;
            this.label4.Text = "Hoặc  số thứ tự";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearchSEQ);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSeq);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnSearchSEQ
            // 
            this.btnSearchSEQ.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchSEQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchSEQ.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSearchSEQ.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSEQ.ForeColor = System.Drawing.Color.Black;
            this.btnSearchSEQ.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSEQ.Image")));
            this.btnSearchSEQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchSEQ.Location = new System.Drawing.Point(664, 9);
            this.btnSearchSEQ.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearchSEQ.Name = "btnSearchSEQ";
            this.btnSearchSEQ.Size = new System.Drawing.Size(75, 24);
            this.btnSearchSEQ.TabIndex = 93;
            this.btnSearchSEQ.Text = "Tìm ";
            this.btnSearchSEQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchSEQ.UseHightLight = true;
            this.btnSearchSEQ.UseVisualStyleBackColor = false;
            this.btnSearchSEQ.Click += new System.EventHandler(this.btnViewInfo_Click);
            // 
            // FrmDeleteCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi; 
            this.ClientSize = new System.Drawing.Size(1299, 532);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDeleteCustomer";
            this.Text = "Tìm kiếm bệnh nhân đã xóa";
            this.Load += new System.EventHandler(this.FrmDeleteCustomer_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bvPatient)).EndInit();
            this.bvPatient.ResumeLayout(false);
            this.bvPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPatient)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TPH.LIS.Common.Controls.CustomBindingNavigator bvPatient;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnKQXetNghiem;
        private System.Windows.Forms.ToolStripButton btnCheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnKQSieuAm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnKQXQuang;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgPatient;
        private System.Windows.Forms.ToolStripButton btnXemKQNoiSoi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.TextBox txtSeq;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private TPH.Controls.TPHNormalButton btnSearchSEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTiepNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTiepNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChanDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetLuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionDate;
    }
}