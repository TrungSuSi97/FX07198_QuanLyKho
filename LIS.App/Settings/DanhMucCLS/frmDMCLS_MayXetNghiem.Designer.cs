using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    partial class frmDMCLS_MayXetNghiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMCLS_MayXetNghiem));
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btnThemMoi = new TPH.Controls.TPHNormalButton();
            this.chkTuValid = new System.Windows.Forms.CheckBox();
            this.cboLoaiKetNoi = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtProtocol = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenMay = new System.Windows.Forms.TextBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtIDMay = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.dtgMayXetNghiem = new System.Windows.Forms.DataGridView();
            this.IDMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tudongvalid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LoaiKetNoi = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bvMayXetNghiem = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaMay = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMayXetNghiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvMayXetNghiem)).BeginInit();
            this.bvMayXetNghiem.SuspendLayout();
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
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Size = new System.Drawing.Size(230, 22);
            this.lblTitle.Text = "DANH MỤC MÁY XÉT NGHIỆM";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.gbDetail);
            this.pnContaint.Controls.Add(this.gbInfo);
            this.pnContaint.Location = new System.Drawing.Point(0, 26);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnContaint.Size = new System.Drawing.Size(624, 401);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(3, 9, 3, 2);
            this.pnLabel.Size = new System.Drawing.Size(624, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnClose.Location = new System.Drawing.Point(269, 9);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.GhostWhite;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(298, 9);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(624, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(624, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(232, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 24);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(516, 1);
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
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.btnThemMoi);
            this.gbInfo.Controls.Add(this.chkTuValid);
            this.gbInfo.Controls.Add(this.cboLoaiKetNoi);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.txtProtocol);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.txtTenMay);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.txtIDMay);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.Location = new System.Drawing.Point(3, 4);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbInfo.Size = new System.Drawing.Size(618, 84);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Thông tin";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMoi.BackColorHover = System.Drawing.Color.Empty;
            this.btnThemMoi.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnThemMoi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThemMoi.BorderRadius = 5;
            this.btnThemMoi.BorderSize = 1;
            this.btnThemMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemMoi.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThemMoi.ForeColor = System.Drawing.Color.Black;
            this.btnThemMoi.Location = new System.Drawing.Point(506, 24);
            this.btnThemMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(79, 41);
            this.btnThemMoi.TabIndex = 9;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.TextColor = System.Drawing.Color.Black;
            this.btnThemMoi.UseHightLight = true;
            this.btnThemMoi.UseVisualStyleBackColor = false;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // chkTuValid
            // 
            this.chkTuValid.AutoSize = true;
            this.chkTuValid.Location = new System.Drawing.Point(332, 24);
            this.chkTuValid.Margin = new System.Windows.Forms.Padding(2);
            this.chkTuValid.Name = "chkTuValid";
            this.chkTuValid.Size = new System.Drawing.Size(112, 19);
            this.chkTuValid.TabIndex = 8;
            this.chkTuValid.Text = "Tự valid kết quả";
            this.chkTuValid.UseVisualStyleBackColor = true;
            // 
            // cboLoaiKetNoi
            // 
            this.cboLoaiKetNoi.AutoComplete = false;
            this.cboLoaiKetNoi.AutoDropdown = false;
            this.cboLoaiKetNoi.BackColorEven = System.Drawing.Color.White;
            this.cboLoaiKetNoi.BackColorOdd = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.cboLoaiKetNoi.ColumnNames = "";
            this.cboLoaiKetNoi.ColumnWidthDefault = 75;
            this.cboLoaiKetNoi.ColumnWidths = "";
            this.cboLoaiKetNoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboLoaiKetNoi.FormattingEnabled = true;
            this.cboLoaiKetNoi.LinkedColumnIndex = 0;
            this.cboLoaiKetNoi.LinkedColumnIndex1 = 0;
            this.cboLoaiKetNoi.LinkedColumnIndex2 = 0;
            this.cboLoaiKetNoi.LinkedTextBox = null;
            this.cboLoaiKetNoi.LinkedTextBox1 = null;
            this.cboLoaiKetNoi.LinkedTextBox2 = null;
            this.cboLoaiKetNoi.Location = new System.Drawing.Point(220, 43);
            this.cboLoaiKetNoi.Margin = new System.Windows.Forms.Padding(2);
            this.cboLoaiKetNoi.Name = "cboLoaiKetNoi";
            this.cboLoaiKetNoi.Size = new System.Drawing.Size(104, 22);
            this.cboLoaiKetNoi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(144, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Loại kết nối";
            // 
            // txtProtocol
            // 
            this.txtProtocol.Location = new System.Drawing.Point(74, 44);
            this.txtProtocol.Margin = new System.Windows.Forms.Padding(2);
            this.txtProtocol.Name = "txtProtocol";
            this.txtProtocol.Size = new System.Drawing.Size(68, 21);
            this.txtProtocol.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giao thức";
            // 
            // txtTenMay
            // 
            this.txtTenMay.Location = new System.Drawing.Point(220, 23);
            this.txtTenMay.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenMay.Name = "txtTenMay";
            this.txtTenMay.Size = new System.Drawing.Size(104, 21);
            this.txtTenMay.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên máy";
            // 
            // txtIDMay
            // 
            this.txtIDMay.Location = new System.Drawing.Point(74, 23);
            this.txtIDMay.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDMay.Name = "txtIDMay";
            this.txtIDMay.Size = new System.Drawing.Size(68, 21);
            this.txtIDMay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã máy";
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.dtgMayXetNghiem);
            this.gbDetail.Controls.Add(this.bvMayXetNghiem);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetail.Location = new System.Drawing.Point(3, 88);
            this.gbDetail.Margin = new System.Windows.Forms.Padding(2);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Padding = new System.Windows.Forms.Padding(2);
            this.gbDetail.Size = new System.Drawing.Size(618, 309);
            this.gbDetail.TabIndex = 1;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Danh sách máy";
            // 
            // dtgMayXetNghiem
            // 
            this.dtgMayXetNghiem.AllowUserToAddRows = false;
            this.dtgMayXetNghiem.AllowUserToDeleteRows = false;
            this.dtgMayXetNghiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMayXetNghiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDMay,
            this.TenMay,
            this.Protocol,
            this.Tudongvalid,
            this.LoaiKetNoi});
            this.dtgMayXetNghiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMayXetNghiem.Location = new System.Drawing.Point(2, 16);
            this.dtgMayXetNghiem.Margin = new System.Windows.Forms.Padding(2);
            this.dtgMayXetNghiem.Name = "dtgMayXetNghiem";
            this.dtgMayXetNghiem.Size = new System.Drawing.Size(614, 266);
            this.dtgMayXetNghiem.TabIndex = 0;
            // 
            // IDMay
            // 
            this.IDMay.DataPropertyName = "IDMay";
            this.IDMay.HeaderText = "Mã máy";
            this.IDMay.Name = "IDMay";
            // 
            // TenMay
            // 
            this.TenMay.DataPropertyName = "TenMay";
            this.TenMay.HeaderText = "Tên máy";
            this.TenMay.Name = "TenMay";
            this.TenMay.Width = 250;
            // 
            // Protocol
            // 
            this.Protocol.DataPropertyName = "Protocol";
            this.Protocol.HeaderText = "Giao thức";
            this.Protocol.Name = "Protocol";
            // 
            // Tudongvalid
            // 
            this.Tudongvalid.DataPropertyName = "Tudongvalid";
            this.Tudongvalid.HeaderText = "Tự động valid";
            this.Tudongvalid.Name = "Tudongvalid";
            // 
            // LoaiKetNoi
            // 
            this.LoaiKetNoi.DataPropertyName = "Loaiketnoi";
            this.LoaiKetNoi.HeaderText = "Loại kết nối";
            this.LoaiKetNoi.Name = "LoaiKetNoi";
            // 
            // bvMayXetNghiem
            // 
            this.bvMayXetNghiem.AddNewItem = null;
            this.bvMayXetNghiem.CountItem = this.bindingNavigatorCountItem;
            this.bvMayXetNghiem.DeleteItem = null;
            this.bvMayXetNghiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvMayXetNghiem.Font = new System.Drawing.Font("Arial", 9F);
            this.bvMayXetNghiem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnXoaMay});
            this.bvMayXetNghiem.Location = new System.Drawing.Point(2, 282);
            this.bvMayXetNghiem.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvMayXetNghiem.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvMayXetNghiem.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvMayXetNghiem.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvMayXetNghiem.Name = "bvMayXetNghiem";
            this.bvMayXetNghiem.PositionItem = this.bindingNavigatorPositionItem;
            this.bvMayXetNghiem.Size = new System.Drawing.Size(614, 25);
            this.bvMayXetNghiem.TabIndex = 1;
            this.bvMayXetNghiem.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(35, 23);
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
            // btnXoaMay
            // 
            this.btnXoaMay.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaMay.Image")));
            this.btnXoaMay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoaMay.Name = "btnXoaMay";
            this.btnXoaMay.Size = new System.Drawing.Size(74, 22);
            this.btnXoaMay.Text = "Xóa máy";
            // 
            // frmDMCLS_MayXetNghiem
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 427);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmDMCLS_MayXetNghiem";
            this.Text = "Danh mục xét nghiệm";
            this.Load += new System.EventHandler(this.frmDMCLS_MayXetNghiem_Load);
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
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMayXetNghiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvMayXetNghiem)).EndInit();
            this.bvMayXetNghiem.ResumeLayout(false);
            this.bvMayXetNghiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox txtIDMay;
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.TextBox txtProtocol;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.TextBox txtTenMay;
        private DevExpress.XtraEditors.LabelControl label2;
        private CustomComboBox cboLoaiKetNoi;
        private DevExpress.XtraEditors.LabelControl label4;
        private TPH.Controls.TPHNormalButton btnThemMoi;
        private System.Windows.Forms.CheckBox chkTuValid;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.DataGridView dtgMayXetNghiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tudongvalid;
        private System.Windows.Forms.DataGridViewComboBoxColumn LoaiKetNoi;
        private System.Windows.Forms.BindingNavigator bvMayXetNghiem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnXoaMay;
    }
}