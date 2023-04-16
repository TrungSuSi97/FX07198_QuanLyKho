namespace TPH.LIS.App.CauHinh.HeThong
{
    partial class frmPrintHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintHeader));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRemoveImge = new TPH.Controls.TPHNormalButton();
            this.btnAddLogo = new TPH.Controls.TPHNormalButton();
            this.pblogo = new System.Windows.Forms.PictureBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtHeaderID = new System.Windows.Forms.TextBox();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAddHeader = new TPH.Controls.TPHNormalButton();
            this.bvHeader = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.dtgHeader = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InMau = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TenPhieuIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiKyTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNguoiPhuTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReportLogo = new System.Windows.Forms.DataGridViewImageColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvHeader)).BeginInit();
            this.bvHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHeader)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(145, 22);
            this.lblTitle.Text = "TIÊU ĐỀ TRANG IN";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.dtgHeader);
            this.pnContaint.Controls.Add(this.bvHeader);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Location = new System.Drawing.Point(0, 0);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnContaint.Size = new System.Drawing.Size(884, 556);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(4, 7, 4, 2);
            this.pnLabel.Size = new System.Drawing.Size(884, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(531, 7);
            this.btnClose.Size = new System.Drawing.Size(26, 0);
            this.btnClose.TextColor = System.Drawing.Color.Transparent;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(557, 7);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(884, 0);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(130)))), ((int)(((byte)(167)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(884, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(147, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 0);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(776, 1);
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
            this.panel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.panel1.Appearance.Options.UseBackColor = true;
            this.panel1.Controls.Add(this.btnRemoveImge);
            this.panel1.Controls.Add(this.btnAddLogo);
            this.panel1.Controls.Add(this.pblogo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtHeaderID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 91);
            this.panel1.TabIndex = 0;
            // 
            // btnRemoveImge
            // 
            this.btnRemoveImge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveImge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnRemoveImge.BackColorHover = System.Drawing.Color.Empty;
            this.btnRemoveImge.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnRemoveImge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnRemoveImge.BorderRadius = 5;
            this.btnRemoveImge.BorderSize = 1;
            this.btnRemoveImge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveImge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveImge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveImge.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRemoveImge.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveImge.Location = new System.Drawing.Point(735, 46);
            this.btnRemoveImge.Name = "btnRemoveImge";
            this.btnRemoveImge.Size = new System.Drawing.Size(38, 27);
            this.btnRemoveImge.TabIndex = 7;
            this.btnRemoveImge.Text = "-";
            this.btnRemoveImge.TextColor = System.Drawing.Color.Black;
            this.btnRemoveImge.UseHightLight = true;
            this.btnRemoveImge.UseVisualStyleBackColor = false;
            this.btnRemoveImge.Click += new System.EventHandler(this.btnRemoveImge_Click);
            // 
            // btnAddLogo
            // 
            this.btnAddLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnAddLogo.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddLogo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnAddLogo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnAddLogo.BorderRadius = 5;
            this.btnAddLogo.BorderSize = 1;
            this.btnAddLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLogo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLogo.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddLogo.ForeColor = System.Drawing.Color.Black;
            this.btnAddLogo.Location = new System.Drawing.Point(735, 13);
            this.btnAddLogo.Name = "btnAddLogo";
            this.btnAddLogo.Size = new System.Drawing.Size(38, 27);
            this.btnAddLogo.TabIndex = 6;
            this.btnAddLogo.Text = "+";
            this.btnAddLogo.TextColor = System.Drawing.Color.Black;
            this.btnAddLogo.UseHightLight = true;
            this.btnAddLogo.UseVisualStyleBackColor = false;
            this.btnAddLogo.Click += new System.EventHandler(this.btnAddLogo_Click);
            // 
            // pblogo
            // 
            this.pblogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pblogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pblogo.Location = new System.Drawing.Point(774, 2);
            this.pblogo.Name = "pblogo";
            this.pblogo.Size = new System.Drawing.Size(100, 87);
            this.pblogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pblogo.TabIndex = 5;
            this.pblogo.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mô tả";
            this.label2.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(95, 29);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(243, 21);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Visible = false;
            // 
            // txtHeaderID
            // 
            this.txtHeaderID.Location = new System.Drawing.Point(95, 2);
            this.txtHeaderID.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtHeaderID.Name = "txtHeaderID";
            this.txtHeaderID.Size = new System.Drawing.Size(93, 21);
            this.txtHeaderID.TabIndex = 2;
            this.txtHeaderID.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã tiêu đề";
            this.label1.Visible = false;
            // 
            // btnAddHeader
            // 
            this.btnAddHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnAddHeader.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddHeader.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnAddHeader.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnAddHeader.BorderRadius = 5;
            this.btnAddHeader.BorderSize = 1;
            this.btnAddHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddHeader.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddHeader.ForeColor = System.Drawing.Color.Black;
            this.btnAddHeader.Location = new System.Drawing.Point(191, 54);
            this.btnAddHeader.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnAddHeader.Name = "btnAddHeader";
            this.btnAddHeader.Size = new System.Drawing.Size(147, 29);
            this.btnAddHeader.TabIndex = 0;
            this.btnAddHeader.Text = "Thêm tiêu đề";
            this.btnAddHeader.TextColor = System.Drawing.Color.Black;
            this.btnAddHeader.UseHightLight = true;
            this.btnAddHeader.UseVisualStyleBackColor = false;
            this.btnAddHeader.Visible = false;
            this.btnAddHeader.Click += new System.EventHandler(this.btnAddHeader_Click);
            // 
            // bvHeader
            // 
            this.bvHeader.AddNewItem = null;
            this.bvHeader.CountItem = this.bindingNavigatorCountItem;
            this.bvHeader.CountItemFormat = "/ {0}";
            this.bvHeader.DeleteItem = null;
            this.bvHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvHeader.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnRefresh});
            this.bvHeader.Location = new System.Drawing.Point(4, 94);
            this.bvHeader.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvHeader.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvHeader.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvHeader.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvHeader.Name = "bvHeader";
            this.bvHeader.PositionItem = this.bindingNavigatorPositionItem;
            this.bvHeader.Size = new System.Drawing.Size(876, 27);
            this.bvHeader.TabIndex = 1;
            this.bvHeader.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 24);
            this.bindingNavigatorCountItem.Text = "/ {0}";
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
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 24);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtgHeader
            // 
            this.dtgHeader.AlignColumns = "";
            this.dtgHeader.AllignNumberText = false;
            this.dtgHeader.AllowUserToAddRows = false;
            this.dtgHeader.AllowUserToDeleteRows = false;
            this.dtgHeader.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgHeader.CheckBoldColumn = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDonVi,
            this.Description,
            this.InMau,
            this.TenPhieuIn,
            this.NguoiKyTen,
            this.colNguoiPhuTrach,
            this.ChucVu,
            this.TieuDe1,
            this.TieuDe2,
            this.TieuDe3,
            this.TieuDe4,
            this.TieuDe5,
            this.TieuDe6,
            this.ReportLogo});
            this.dtgHeader.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHeader.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHeader.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgHeader.Location = new System.Drawing.Point(4, 121);
            this.dtgHeader.MarkOddEven = true;
            this.dtgHeader.MultiSelect = false;
            this.dtgHeader.Name = "dtgHeader";
            this.dtgHeader.RowHeadersWidth = 25;
            this.dtgHeader.Size = new System.Drawing.Size(876, 432);
            this.dtgHeader.TabIndex = 2;
            this.dtgHeader.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHeader_CellEnter);
            this.dtgHeader.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgHeader_DataBindingComplete);
            // 
            // MaDonVi
            // 
            this.MaDonVi.DataPropertyName = "MaDonVi";
            this.MaDonVi.HeaderText = "#";
            this.MaDonVi.MinimumWidth = 6;
            this.MaDonVi.Name = "MaDonVi";
            this.MaDonVi.ReadOnly = true;
            this.MaDonVi.Width = 35;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 150;
            // 
            // InMau
            // 
            this.InMau.DataPropertyName = "InMau";
            this.InMau.HeaderText = "In màu";
            this.InMau.MinimumWidth = 6;
            this.InMau.Name = "InMau";
            this.InMau.Visible = false;
            this.InMau.Width = 60;
            // 
            // TenPhieuIn
            // 
            this.TenPhieuIn.DataPropertyName = "TenPhieuIn";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TenPhieuIn.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenPhieuIn.HeaderText = "Tên phiếu in";
            this.TenPhieuIn.MinimumWidth = 6;
            this.TenPhieuIn.Name = "TenPhieuIn";
            this.TenPhieuIn.Width = 250;
            // 
            // NguoiKyTen
            // 
            this.NguoiKyTen.DataPropertyName = "NguoiKyTen";
            this.NguoiKyTen.HeaderText = "Tên người ký";
            this.NguoiKyTen.MinimumWidth = 6;
            this.NguoiKyTen.Name = "NguoiKyTen";
            this.NguoiKyTen.Width = 130;
            // 
            // colNguoiPhuTrach
            // 
            this.colNguoiPhuTrach.DataPropertyName = "NguoiPhuTrach";
            this.colNguoiPhuTrach.HeaderText = "Người phụ trách";
            this.colNguoiPhuTrach.MinimumWidth = 6;
            this.colNguoiPhuTrach.Name = "colNguoiPhuTrach";
            this.colNguoiPhuTrach.Width = 150;
            // 
            // ChucVu
            // 
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.MinimumWidth = 6;
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.Width = 130;
            // 
            // TieuDe1
            // 
            this.TieuDe1.DataPropertyName = "TieuDe1";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TieuDe1.DefaultCellStyle = dataGridViewCellStyle3;
            this.TieuDe1.HeaderText = "Dòng tiêu đề 1";
            this.TieuDe1.MinimumWidth = 6;
            this.TieuDe1.Name = "TieuDe1";
            this.TieuDe1.Width = 200;
            // 
            // TieuDe2
            // 
            this.TieuDe2.DataPropertyName = "TieuDe2";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TieuDe2.DefaultCellStyle = dataGridViewCellStyle4;
            this.TieuDe2.HeaderText = "Dòng tiêu đề 2";
            this.TieuDe2.MinimumWidth = 6;
            this.TieuDe2.Name = "TieuDe2";
            this.TieuDe2.Width = 200;
            // 
            // TieuDe3
            // 
            this.TieuDe3.DataPropertyName = "TieuDe3";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TieuDe3.DefaultCellStyle = dataGridViewCellStyle5;
            this.TieuDe3.HeaderText = "Dòng tiêu đề 3";
            this.TieuDe3.MinimumWidth = 6;
            this.TieuDe3.Name = "TieuDe3";
            this.TieuDe3.Width = 200;
            // 
            // TieuDe4
            // 
            this.TieuDe4.DataPropertyName = "TieuDe4";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TieuDe4.DefaultCellStyle = dataGridViewCellStyle6;
            this.TieuDe4.HeaderText = "Dòng tiêu đề 4";
            this.TieuDe4.MinimumWidth = 6;
            this.TieuDe4.Name = "TieuDe4";
            this.TieuDe4.Width = 200;
            // 
            // TieuDe5
            // 
            this.TieuDe5.DataPropertyName = "TieuDe5";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TieuDe5.DefaultCellStyle = dataGridViewCellStyle7;
            this.TieuDe5.HeaderText = "Dòng tiêu đề 5";
            this.TieuDe5.MinimumWidth = 6;
            this.TieuDe5.Name = "TieuDe5";
            this.TieuDe5.Width = 200;
            // 
            // TieuDe6
            // 
            this.TieuDe6.DataPropertyName = "TieuDe6";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TieuDe6.DefaultCellStyle = dataGridViewCellStyle8;
            this.TieuDe6.HeaderText = "Dòng tiêu đề 6";
            this.TieuDe6.MinimumWidth = 6;
            this.TieuDe6.Name = "TieuDe6";
            this.TieuDe6.Width = 200;
            // 
            // ReportLogo
            // 
            this.ReportLogo.DataPropertyName = "ReportLogo";
            this.ReportLogo.HeaderText = "Logo";
            this.ReportLogo.MinimumWidth = 6;
            this.ReportLogo.Name = "ReportLogo";
            this.ReportLogo.Width = 125;
            // 
            // frmPrintHeader
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(884, 556);
            this.Name = "frmPrintHeader";
            this.Text = "Cài đặt trang in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrintHeader_FormClosing);
            this.Load += new System.EventHandler(this.frmPrintHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pblogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvHeader)).EndInit();
            this.bvHeader.ResumeLayout(false);
            this.bvHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private TPH.LIS.Common.Controls.CustomBindingNavigator bvHeader;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtHeaderID;
        private DevExpress.XtraEditors.LabelControl label1;
        private TPH.Controls.TPHNormalButton btnAddHeader;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgHeader;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.PictureBox pblogo;
        private TPH.Controls.TPHNormalButton btnRemoveImge;
        private TPH.Controls.TPHNormalButton btnAddLogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhieuIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiKyTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNguoiPhuTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe5;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe6;
        private System.Windows.Forms.DataGridViewImageColumn ReportLogo;
    }
}