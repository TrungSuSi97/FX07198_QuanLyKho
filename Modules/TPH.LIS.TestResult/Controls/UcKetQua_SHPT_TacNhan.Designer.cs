namespace TPH.LIS.TestResult.Controls
{
    partial class ucKetQua_SHPT_TacNhan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKetQua_SHPT_TacNhan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ucGroupHeaderTacNhanChiTiet = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnXoaGenotype = new TPH.Controls.TPHNormalButton();
            this.bvKetQuaType = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtKetQuaDinhLuong = new System.Windows.Forms.TextBox();
            this.lblDVTDinhLuong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.btnThemGenotype = new TPH.Controls.TPHNormalButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTacNhan = new System.Windows.Forms.ComboBox();
            this.lblTacNhan = new System.Windows.Forms.Label();
            this.dtgKetQuaType = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenXN_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua_Gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKetQua_DinhLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMayXN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCSBT_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanhGia_gen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKqGen_Flat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKqGen_MaGen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaXn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvKetQuaType)).BeginInit();
            this.bvKetQuaType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKetQuaType)).BeginInit();
            this.SuspendLayout();
            // 
            // ucGroupHeaderTacNhanChiTiet
            // 
            this.ucGroupHeaderTacNhanChiTiet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.ucGroupHeaderTacNhanChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeaderTacNhanChiTiet.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeaderTacNhanChiTiet.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeaderTacNhanChiTiet.GroupCaption = "TÁC NHÂN";
            this.ucGroupHeaderTacNhanChiTiet.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeaderTacNhanChiTiet.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeaderTacNhanChiTiet.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucGroupHeaderTacNhanChiTiet.Name = "ucGroupHeaderTacNhanChiTiet";
            this.ucGroupHeaderTacNhanChiTiet.Size = new System.Drawing.Size(553, 20);
            this.ucGroupHeaderTacNhanChiTiet.TabIndex = 130;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(65)))), ((int)(((byte)(73)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnXoaGenotype);
            this.panel5.Controls.Add(this.bvKetQuaType);
            this.panel5.Controls.Add(this.txtDonViTinh);
            this.panel5.Controls.Add(this.txtKetQuaDinhLuong);
            this.panel5.Controls.Add(this.lblDVTDinhLuong);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cboKetQua);
            this.panel5.Controls.Add(this.btnThemGenotype);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.cboTacNhan);
            this.panel5.Controls.Add(this.lblTacNhan);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 20);
            this.panel5.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(161, 368);
            this.panel5.TabIndex = 96;
            // 
            // btnXoaGenotype
            // 
            this.btnXoaGenotype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaGenotype.BackColorHover = System.Drawing.Color.Empty;
            this.btnXoaGenotype.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnXoaGenotype.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnXoaGenotype.BorderRadius = 5;
            this.btnXoaGenotype.BorderSize = 1;
            this.btnXoaGenotype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaGenotype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaGenotype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaGenotype.ForceColorHover = System.Drawing.Color.Empty;
            this.btnXoaGenotype.ForeColor = System.Drawing.Color.Black;
            this.btnXoaGenotype.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaGenotype.Image")));
            this.btnXoaGenotype.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaGenotype.Location = new System.Drawing.Point(94, 81);
            this.btnXoaGenotype.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnXoaGenotype.Name = "btnXoaGenotype";
            this.btnXoaGenotype.Size = new System.Drawing.Size(58, 29);
            this.btnXoaGenotype.TabIndex = 93;
            this.btnXoaGenotype.Text = "Xóa";
            this.btnXoaGenotype.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaGenotype.TextColor = System.Drawing.Color.Black;
            this.btnXoaGenotype.UseHightLight = true;
            this.btnXoaGenotype.UseVisualStyleBackColor = false;
            this.btnXoaGenotype.Click += new System.EventHandler(this.btnXoaGenotype_Click);
            // 
            // bvKetQuaType
            // 
            this.bvKetQuaType.AddNewItem = null;
            this.bvKetQuaType.CountItem = this.bindingNavigatorCountItem1;
            this.bvKetQuaType.CountItemFormat = "/ {0}";
            this.bvKetQuaType.DeleteItem = null;
            this.bvKetQuaType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvKetQuaType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvKetQuaType.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bvKetQuaType.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvKetQuaType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorSeparator5});
            this.bvKetQuaType.Location = new System.Drawing.Point(0, 339);
            this.bvKetQuaType.MoveFirstItem = null;
            this.bvKetQuaType.MoveLastItem = null;
            this.bvKetQuaType.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bvKetQuaType.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bvKetQuaType.Name = "bvKetQuaType";
            this.bvKetQuaType.PositionItem = this.bindingNavigatorPositionItem1;
            this.bvKetQuaType.Size = new System.Drawing.Size(159, 27);
            this.bvKetQuaType.TabIndex = 98;
            this.bvKetQuaType.Text = "customBindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(30, 24);
            this.bindingNavigatorCountItem1.Text = "/ {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(22, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(4, 281);
            this.txtDonViTinh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(77, 20);
            this.txtDonViTinh.TabIndex = 92;
            // 
            // txtKetQuaDinhLuong
            // 
            this.txtKetQuaDinhLuong.Location = new System.Drawing.Point(75, 51);
            this.txtKetQuaDinhLuong.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtKetQuaDinhLuong.Name = "txtKetQuaDinhLuong";
            this.txtKetQuaDinhLuong.Size = new System.Drawing.Size(82, 20);
            this.txtKetQuaDinhLuong.TabIndex = 91;
            this.txtKetQuaDinhLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKetQuaDinhLuong_KeyPress);
            // 
            // lblDVTDinhLuong
            // 
            this.lblDVTDinhLuong.AutoSize = true;
            this.lblDVTDinhLuong.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVTDinhLuong.ForeColor = System.Drawing.Color.Gold;
            this.lblDVTDinhLuong.Location = new System.Drawing.Point(2, 287);
            this.lblDVTDinhLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDVTDinhLuong.Name = "lblDVTDinhLuong";
            this.lblDVTDinhLuong.Size = new System.Drawing.Size(36, 16);
            this.lblDVTDinhLuong.TabIndex = 91;
            this.lblDVTDinhLuong.Text = "ĐVT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(1, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 90;
            this.label1.Text = "Định lượng";
            // 
            // cboKetQua
            // 
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Items.AddRange(new object[] {
            "Âm tính",
            "Dương tính",
            "Không xác định"});
            this.cboKetQua.Location = new System.Drawing.Point(75, 26);
            this.cboKetQua.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(82, 21);
            this.cboKetQua.TabIndex = 84;
            this.cboKetQua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboKetQua_KeyPress);
            // 
            // btnThemGenotype
            // 
            this.btnThemGenotype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemGenotype.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemGenotype.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThemGenotype.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemGenotype.BorderRadius = 5;
            this.btnThemGenotype.BorderSize = 1;
            this.btnThemGenotype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemGenotype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemGenotype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGenotype.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemGenotype.ForeColor = System.Drawing.Color.Black;
            this.btnThemGenotype.Image = ((System.Drawing.Image)(resources.GetObject("btnThemGenotype.Image")));
            this.btnThemGenotype.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemGenotype.Location = new System.Drawing.Point(30, 81);
            this.btnThemGenotype.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnThemGenotype.Name = "btnThemGenotype";
            this.btnThemGenotype.Size = new System.Drawing.Size(59, 29);
            this.btnThemGenotype.TabIndex = 87;
            this.btnThemGenotype.Text = "Lưu";
            this.btnThemGenotype.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemGenotype.TextColor = System.Drawing.Color.Black;
            this.btnThemGenotype.UseHightLight = true;
            this.btnThemGenotype.UseVisualStyleBackColor = false;
            this.btnThemGenotype.Click += new System.EventHandler(this.btnThemGenotype_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(1, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 15);
            this.label7.TabIndex = 83;
            this.label7.Text = "Định tính";
            // 
            // cboTacNhan
            // 
            this.cboTacNhan.DropDownWidth = 300;
            this.cboTacNhan.FormattingEnabled = true;
            this.cboTacNhan.Location = new System.Drawing.Point(75, 2);
            this.cboTacNhan.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboTacNhan.Name = "cboTacNhan";
            this.cboTacNhan.Size = new System.Drawing.Size(82, 21);
            this.cboTacNhan.TabIndex = 88;
            this.cboTacNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTacNhan_KeyPress);
            // 
            // lblTacNhan
            // 
            this.lblTacNhan.AutoSize = true;
            this.lblTacNhan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblTacNhan.Location = new System.Drawing.Point(1, 5);
            this.lblTacNhan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTacNhan.Name = "lblTacNhan";
            this.lblTacNhan.Size = new System.Drawing.Size(59, 15);
            this.lblTacNhan.TabIndex = 81;
            this.lblTacNhan.Text = "Tác nhân";
            // 
            // dtgKetQuaType
            // 
            this.dtgKetQuaType.AllowUserToAddRows = false;
            this.dtgKetQuaType.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgKetQuaType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgKetQuaType.ColumnHeadersHeight = 25;
            this.dtgKetQuaType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenXN_gen,
            this.colKetQua_Gen,
            this.colKetQua_DinhLuong,
            this.colMayXN,
            this.colCSBT_gen,
            this.colDanhGia_gen,
            this.colKqGen_Flat,
            this.colKqGen_MaGen,
            this.colMaXn});
            this.dtgKetQuaType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgKetQuaType.Location = new System.Drawing.Point(161, 20);
            this.dtgKetQuaType.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtgKetQuaType.Name = "dtgKetQuaType";
            this.dtgKetQuaType.RowHeadersWidth = 25;
            this.dtgKetQuaType.Size = new System.Drawing.Size(392, 368);
            this.dtgKetQuaType.TabIndex = 97;
            this.dtgKetQuaType.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgKetQuaType_CellEndEdit);
            this.dtgKetQuaType.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgKetQuaType_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TenGen";
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 135;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "KetQuaDinhTinh";
            this.dataGridViewTextBoxColumn2.HeaderText = "KQ Định tính";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "KetQuaDinhLuong";
            this.dataGridViewTextBoxColumn3.HeaderText = "KQ Định lượng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IDMayXetNghiem";
            this.dataGridViewTextBoxColumn4.HeaderText = "Máy XN";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CSBT";
            this.dataGridViewTextBoxColumn5.HeaderText = "CSBT";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "DKBatThuong";
            this.dataGridViewTextBoxColumn6.HeaderText = "ĐK Đánh giá";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Flag";
            this.dataGridViewTextBoxColumn7.HeaderText = "Flat";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "MaGen";
            this.dataGridViewTextBoxColumn8.HeaderText = "Mã Type";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MaXn";
            this.dataGridViewTextBoxColumn9.HeaderText = "Mã XN";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // colTenXN_gen
            // 
            this.colTenXN_gen.DataPropertyName = "TenGen";
            this.colTenXN_gen.HeaderText = "";
            this.colTenXN_gen.MinimumWidth = 6;
            this.colTenXN_gen.Name = "colTenXN_gen";
            this.colTenXN_gen.ReadOnly = true;
            this.colTenXN_gen.Width = 135;
            // 
            // colKetQua_Gen
            // 
            this.colKetQua_Gen.DataPropertyName = "KetQuaDinhTinh";
            this.colKetQua_Gen.HeaderText = "KQ Định tính";
            this.colKetQua_Gen.MinimumWidth = 6;
            this.colKetQua_Gen.Name = "colKetQua_Gen";
            this.colKetQua_Gen.Width = 130;
            // 
            // colKetQua_DinhLuong
            // 
            this.colKetQua_DinhLuong.DataPropertyName = "KetQuaDinhLuong";
            this.colKetQua_DinhLuong.HeaderText = "KQ Định lượng";
            this.colKetQua_DinhLuong.MinimumWidth = 6;
            this.colKetQua_DinhLuong.Name = "colKetQua_DinhLuong";
            this.colKetQua_DinhLuong.Width = 130;
            // 
            // colMayXN
            // 
            this.colMayXN.DataPropertyName = "IDMayXetNghiem";
            this.colMayXN.HeaderText = "Máy XN";
            this.colMayXN.MinimumWidth = 6;
            this.colMayXN.Name = "colMayXN";
            this.colMayXN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMayXN.Visible = false;
            this.colMayXN.Width = 150;
            // 
            // colCSBT_gen
            // 
            this.colCSBT_gen.DataPropertyName = "CSBT";
            this.colCSBT_gen.HeaderText = "CSBT";
            this.colCSBT_gen.MinimumWidth = 6;
            this.colCSBT_gen.Name = "colCSBT_gen";
            this.colCSBT_gen.ReadOnly = true;
            this.colCSBT_gen.Visible = false;
            this.colCSBT_gen.Width = 125;
            // 
            // colDanhGia_gen
            // 
            this.colDanhGia_gen.DataPropertyName = "DKBatThuong";
            this.colDanhGia_gen.HeaderText = "ĐK Đánh giá";
            this.colDanhGia_gen.MinimumWidth = 6;
            this.colDanhGia_gen.Name = "colDanhGia_gen";
            this.colDanhGia_gen.ReadOnly = true;
            this.colDanhGia_gen.Visible = false;
            this.colDanhGia_gen.Width = 125;
            // 
            // colKqGen_Flat
            // 
            this.colKqGen_Flat.DataPropertyName = "Flag";
            this.colKqGen_Flat.HeaderText = "Flag";
            this.colKqGen_Flat.MinimumWidth = 6;
            this.colKqGen_Flat.Name = "colKqGen_Flat";
            this.colKqGen_Flat.ReadOnly = true;
            this.colKqGen_Flat.Visible = false;
            this.colKqGen_Flat.Width = 125;
            // 
            // colKqGen_MaGen
            // 
            this.colKqGen_MaGen.DataPropertyName = "MaGen";
            this.colKqGen_MaGen.HeaderText = "Mã Type";
            this.colKqGen_MaGen.MinimumWidth = 6;
            this.colKqGen_MaGen.Name = "colKqGen_MaGen";
            this.colKqGen_MaGen.ReadOnly = true;
            this.colKqGen_MaGen.Width = 125;
            // 
            // colMaXn
            // 
            this.colMaXn.DataPropertyName = "MaXn";
            this.colMaXn.HeaderText = "Mã XN";
            this.colMaXn.MinimumWidth = 6;
            this.colMaXn.Name = "colMaXn";
            this.colMaXn.ReadOnly = true;
            this.colMaXn.Visible = false;
            this.colMaXn.Width = 125;
            // 
            // ucKetQua_SHPT_TacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dtgKetQuaType);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.ucGroupHeaderTacNhanChiTiet);
            this.Name = "ucKetQua_SHPT_TacNhan";
            this.Size = new System.Drawing.Size(553, 388);
            this.Load += new System.EventHandler(this.ucKetQua_SHPT_TacNhan_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvKetQuaType)).EndInit();
            this.bvKetQuaType.ResumeLayout(false);
            this.bvKetQuaType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgKetQuaType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel5;
        private TPH.Controls.TPHNormalButton btnXoaGenotype;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtKetQuaDinhLuong;
        private System.Windows.Forms.Label lblDVTDinhLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKetQua;
        private TPH.Controls.TPHNormalButton btnThemGenotype;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTacNhan;
        private System.Windows.Forms.Label lblTacNhan;
        private System.Windows.Forms.DataGridView dtgKetQuaType;
        private Common.Controls.CustomBindingNavigator bvKetQuaType;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Common.Controls.ucGroupHeader ucGroupHeaderTacNhanChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenXN_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua_Gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKetQua_DinhLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMayXN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCSBT_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDanhGia_gen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKqGen_Flat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKqGen_MaGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaXn;
    }
}
