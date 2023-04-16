namespace TPH.LabIMS.ResultListScreen
{
    partial class FrmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblKhoa_KhuVuc = new System.Windows.Forms.Label();
            this.lblTenBenhVien = new System.Windows.Forms.Label();
            this.pnLogo = new System.Windows.Forms.PictureBox();
            this.dtgThongTin = new System.Windows.Forms.DataGridView();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerLoadList = new System.Windows.Forms.Timer(this.components);
            this.lblDanhSachDaCoKetQua = new System.Windows.Forms.Label();
            this.bvList = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnThongBao = new System.Windows.Forms.Panel();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.timerThongBao = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgThongTin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).BeginInit();
            this.bvList.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnThongBao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTitle
            // 
            this.pnTitle.BackColor = System.Drawing.Color.White;
            this.pnTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnTitle.BackgroundImage")));
            this.pnTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTitle.Controls.Add(this.pnLogo);
            this.pnTitle.Controls.Add(this.lblTime);
            this.pnTitle.Controls.Add(this.lblKhoa_KhuVuc);
            this.pnTitle.Controls.Add(this.lblTenBenhVien);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.ForeColor = System.Drawing.Color.White;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(1320, 127);
            this.pnTitle.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblTime.Location = new System.Drawing.Point(1173, 70);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(143, 54);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "20/01/2019 \r\n10:30:30";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKhoa_KhuVuc
            // 
            this.lblKhoa_KhuVuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKhoa_KhuVuc.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.lblKhoa_KhuVuc.ForeColor = System.Drawing.Color.Black;
            this.lblKhoa_KhuVuc.Location = new System.Drawing.Point(0, 68);
            this.lblKhoa_KhuVuc.Name = "lblKhoa_KhuVuc";
            this.lblKhoa_KhuVuc.Size = new System.Drawing.Size(1320, 59);
            this.lblKhoa_KhuVuc.TabIndex = 2;
            this.lblKhoa_KhuVuc.Text = "KHU KHÁM BỆNH";
            this.lblKhoa_KhuVuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenBenhVien
            // 
            this.lblTenBenhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTenBenhVien.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold);
            this.lblTenBenhVien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTenBenhVien.Location = new System.Drawing.Point(0, 0);
            this.lblTenBenhVien.Name = "lblTenBenhVien";
            this.lblTenBenhVien.Size = new System.Drawing.Size(1320, 68);
            this.lblTenBenhVien.TabIndex = 1;
            this.lblTenBenhVien.Text = "BỆNH VIỆN ĐA KHOA VÙNG TÂY NGUYÊN";
            this.lblTenBenhVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnLogo
            // 
            this.pnLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLogo.Location = new System.Drawing.Point(3, 1);
            this.pnLogo.Name = "pnLogo";
            this.pnLogo.Size = new System.Drawing.Size(117, 124);
            this.pnLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pnLogo.TabIndex = 3;
            this.pnLogo.TabStop = false;
            // 
            // dtgThongTin
            // 
            this.dtgThongTin.AllowUserToAddRows = false;
            this.dtgThongTin.AllowUserToDeleteRows = false;
            this.dtgThongTin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgThongTin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            this.dtgThongTin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgThongTin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgThongTin.ColumnHeadersHeight = 80;
            this.dtgThongTin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colHoTen,
            this.colNamSinh});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgThongTin.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgThongTin.EnableHeadersVisualStyles = false;
            this.dtgThongTin.GridColor = System.Drawing.Color.White;
            this.dtgThongTin.Location = new System.Drawing.Point(0, 173);
            this.dtgThongTin.Margin = new System.Windows.Forms.Padding(0);
            this.dtgThongTin.Name = "dtgThongTin";
            this.dtgThongTin.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgThongTin.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgThongTin.RowHeadersVisible = false;
            this.dtgThongTin.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgThongTin.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            this.dtgThongTin.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dtgThongTin.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(210)))), ((int)(((byte)(247)))));
            this.dtgThongTin.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgThongTin.RowTemplate.Height = 80;
            this.dtgThongTin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dtgThongTin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgThongTin.Size = new System.Drawing.Size(1320, 479);
            this.dtgThongTin.TabIndex = 18;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "SEQ";
            this.colBarcode.FillWeight = 31F;
            this.colBarcode.HeaderText = "BARCODE";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "TenBN";
            this.colHoTen.HeaderText = "HỌ TÊN";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colNamSinh
            // 
            this.colNamSinh.DataPropertyName = "Tuoi";
            this.colNamSinh.FillWeight = 30F;
            this.colNamSinh.HeaderText = "NĂM SINH";
            this.colNamSinh.Name = "colNamSinh";
            this.colNamSinh.ReadOnly = true;
            // 
            // timerLoadList
            // 
            this.timerLoadList.Interval = 1000;
            // 
            // lblDanhSachDaCoKetQua
            // 
            this.lblDanhSachDaCoKetQua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            this.lblDanhSachDaCoKetQua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDanhSachDaCoKetQua.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDanhSachDaCoKetQua.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold);
            this.lblDanhSachDaCoKetQua.ForeColor = System.Drawing.Color.Black;
            this.lblDanhSachDaCoKetQua.Location = new System.Drawing.Point(0, 127);
            this.lblDanhSachDaCoKetQua.Name = "lblDanhSachDaCoKetQua";
            this.lblDanhSachDaCoKetQua.Size = new System.Drawing.Size(1320, 46);
            this.lblDanhSachDaCoKetQua.TabIndex = 4;
            this.lblDanhSachDaCoKetQua.Text = "DANH SÁCH ĐÃ CÓ KẾT QUẢ XÉT NGHIỆM";
            this.lblDanhSachDaCoKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bvList
            // 
            this.bvList.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bvList.CountItem = this.bindingNavigatorCountItem;
            this.bvList.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bvList.Dock = System.Windows.Forms.DockStyle.None;
            this.bvList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bvList.Location = new System.Drawing.Point(342, 385);
            this.bvList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvList.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvList.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvList.Name = "bvList";
            this.bvList.PositionItem = this.bindingNavigatorPositionItem;
            this.bvList.Size = new System.Drawing.Size(255, 25);
            this.bvList.TabIndex = 19;
            this.bvList.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(149)))), ((int)(((byte)(219)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 708);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1320, 21);
            this.panel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(19, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phát triển bởi Công Ty TNHH Giải Pháp Thiên Phúc Hưng - TPH Solutions Co., LTD";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnThongBao
            // 
            this.pnThongBao.BackColor = System.Drawing.Color.OrangeRed;
            this.pnThongBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnThongBao.Controls.Add(this.lblThongBao);
            this.pnThongBao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnThongBao.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnThongBao.Location = new System.Drawing.Point(0, 652);
            this.pnThongBao.Name = "pnThongBao";
            this.pnThongBao.Size = new System.Drawing.Size(1320, 56);
            this.pnThongBao.TabIndex = 21;
            this.pnThongBao.Visible = false;
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.White;
            this.lblThongBao.Location = new System.Drawing.Point(817, 4);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(219, 46);
            this.lblThongBao.TabIndex = 0;
            this.lblThongBao.Text = "Thông báo";
            // 
            // timerThongBao
            // 
            this.timerThongBao.Tick += new System.EventHandler(this.timerThongBao_Tick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SEQ";
            this.dataGridViewTextBoxColumn1.FillWeight = 30F;
            this.dataGridViewTextBoxColumn1.HeaderText = "BARCODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 189;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenBN";
            this.dataGridViewTextBoxColumn2.HeaderText = "HỌ TÊN";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 629;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Tuoi";
            this.dataGridViewTextBoxColumn3.FillWeight = 30F;
            this.dataGridViewTextBoxColumn3.HeaderText = "NĂM SINH";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 189;
            // 
            // FrmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1320, 729);
            this.Controls.Add(this.dtgThongTin);
            this.Controls.Add(this.pnThongBao);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bvList);
            this.Controls.Add(this.lblDanhSachDaCoKetQua);
            this.Controls.Add(this.pnTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmList";
            this.Text = "Danh sách đã có kết quả";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmList_FormClosing);
            this.Load += new System.EventHandler(this.FrmList_Load);
            this.Shown += new System.EventHandler(this.FrmList_Shown);
            this.pnTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgThongTin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).EndInit();
            this.bvList.ResumeLayout(false);
            this.bvList.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnThongBao.ResumeLayout(false);
            this.pnThongBao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgThongTin;
        private System.Windows.Forms.Timer timerLoadList;
        private System.Windows.Forms.BindingNavigator bvList;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        public System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        public System.Windows.Forms.Label lblDanhSachDaCoKetQua;
        public System.Windows.Forms.Label lblTenBenhVien;
        public System.Windows.Forms.Label lblKhoa_KhuVuc;
        public System.Windows.Forms.PictureBox pnLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerThongBao;
        public System.Windows.Forms.Panel pnThongBao;
        public System.Windows.Forms.Label lblThongBao;
        public System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamSinh;
    }
}