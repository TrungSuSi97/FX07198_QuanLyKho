namespace ClinicManagementSystem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintHeader));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radXQuang = new System.Windows.Forms.RadioButton();
            this.radSieuAm = new System.Windows.Forms.RadioButton();
            this.radViSinh = new System.Windows.Forms.RadioButton();
            this.radMienDich = new System.Windows.Forms.RadioButton();
            this.radHuyetHoc = new System.Windows.Forms.RadioButton();
            this.radSinhHoa = new System.Windows.Forms.RadioButton();
            this.radXNChung = new System.Windows.Forms.RadioButton();
            this.bvHeader = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dtgHeader = new System.Windows.Forms.DataGridView();
            this.MaDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InMau = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TenPhieuIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiKyTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDe6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvHeader)).BeginInit();
            this.bvHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "CÀI ĐẶT TIÊU ĐỀ TRANG IN";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.dtgHeader);
            this.pnContaint.Controls.Add(this.bvHeader);
            this.pnContaint.Controls.Add(this.panel1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radXQuang);
            this.panel1.Controls.Add(this.radSieuAm);
            this.panel1.Controls.Add(this.radViSinh);
            this.panel1.Controls.Add(this.radMienDich);
            this.panel1.Controls.Add(this.radHuyetHoc);
            this.panel1.Controls.Add(this.radSinhHoa);
            this.panel1.Controls.Add(this.radXNChung);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 84);
            this.panel1.TabIndex = 0;
            // 
            // radXQuang
            // 
            this.radXQuang.AutoSize = true;
            this.radXQuang.Location = new System.Drawing.Point(19, 48);
            this.radXQuang.Name = "radXQuang";
            this.radXQuang.Size = new System.Drawing.Size(84, 21);
            this.radXQuang.TabIndex = 6;
            this.radXQuang.Text = "X-Quang";
            this.radXQuang.UseVisualStyleBackColor = true;
            this.radXQuang.CheckedChanged += new System.EventHandler(this.radXQuang_CheckedChanged);
            // 
            // radSieuAm
            // 
            this.radSieuAm.AutoSize = true;
            this.radSieuAm.Location = new System.Drawing.Point(19, 22);
            this.radSieuAm.Name = "radSieuAm";
            this.radSieuAm.Size = new System.Drawing.Size(80, 21);
            this.radSieuAm.TabIndex = 5;
            this.radSieuAm.Text = "Siêu âm";
            this.radSieuAm.UseVisualStyleBackColor = true;
            this.radSieuAm.CheckedChanged += new System.EventHandler(this.radSieuAm_CheckedChanged);
            // 
            // radViSinh
            // 
            this.radViSinh.AutoSize = true;
            this.radViSinh.Location = new System.Drawing.Point(318, 48);
            this.radViSinh.Name = "radViSinh";
            this.radViSinh.Size = new System.Drawing.Size(69, 21);
            this.radViSinh.TabIndex = 4;
            this.radViSinh.Text = "Vi sinh";
            this.radViSinh.UseVisualStyleBackColor = true;
            this.radViSinh.CheckedChanged += new System.EventHandler(this.radViSinh_CheckedChanged);
            // 
            // radMienDich
            // 
            this.radMienDich.AutoSize = true;
            this.radMienDich.Location = new System.Drawing.Point(318, 22);
            this.radMienDich.Name = "radMienDich";
            this.radMienDich.Size = new System.Drawing.Size(87, 21);
            this.radMienDich.TabIndex = 3;
            this.radMienDich.Text = "Miễn dịch";
            this.radMienDich.UseVisualStyleBackColor = true;
            this.radMienDich.CheckedChanged += new System.EventHandler(this.radMienDich_CheckedChanged);
            // 
            // radHuyetHoc
            // 
            this.radHuyetHoc.AutoSize = true;
            this.radHuyetHoc.Location = new System.Drawing.Point(167, 48);
            this.radHuyetHoc.Name = "radHuyetHoc";
            this.radHuyetHoc.Size = new System.Drawing.Size(91, 21);
            this.radHuyetHoc.TabIndex = 2;
            this.radHuyetHoc.Text = "Huyết học";
            this.radHuyetHoc.UseVisualStyleBackColor = true;
            this.radHuyetHoc.CheckedChanged += new System.EventHandler(this.radHuyetHoc_CheckedChanged);
            // 
            // radSinhHoa
            // 
            this.radSinhHoa.AutoSize = true;
            this.radSinhHoa.Location = new System.Drawing.Point(167, 22);
            this.radSinhHoa.Name = "radSinhHoa";
            this.radSinhHoa.Size = new System.Drawing.Size(83, 21);
            this.radSinhHoa.TabIndex = 1;
            this.radSinhHoa.Text = "Sinh hóa";
            this.radSinhHoa.UseVisualStyleBackColor = true;
            this.radSinhHoa.CheckedChanged += new System.EventHandler(this.radSinhHoa_CheckedChanged);
            // 
            // radXNChung
            // 
            this.radXNChung.AutoSize = true;
            this.radXNChung.Checked = true;
            this.radXNChung.Location = new System.Drawing.Point(461, 48);
            this.radXNChung.Name = "radXNChung";
            this.radXNChung.Size = new System.Drawing.Size(105, 21);
            this.radXNChung.TabIndex = 0;
            this.radXNChung.TabStop = true;
            this.radXNChung.Text = "Dùng chung";
            this.radXNChung.UseVisualStyleBackColor = true;
            this.radXNChung.CheckedChanged += new System.EventHandler(this.radXNChung_CheckedChanged);
            // 
            // bvHeader
            // 
            this.bvHeader.AddNewItem = null;
            this.bvHeader.CountItem = this.bindingNavigatorCountItem;
            this.bvHeader.DeleteItem = null;
            this.bvHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bvHeader.Location = new System.Drawing.Point(0, 532);
            this.bvHeader.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvHeader.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvHeader.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvHeader.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvHeader.Name = "bvHeader";
            this.bvHeader.PositionItem = this.bindingNavigatorPositionItem;
            this.bvHeader.Size = new System.Drawing.Size(1010, 25);
            this.bvHeader.TabIndex = 1;
            this.bvHeader.Text = "bindingNavigator1";
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
            // dtgHeader
            // 
            this.dtgHeader.AllowUserToAddRows = false;
            this.dtgHeader.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDonVi,
            this.InMau,
            this.TenPhieuIn,
            this.NguoiKyTen,
            this.ChucVu,
            this.TieuDe1,
            this.TieuDe2,
            this.TieuDe3,
            this.TieuDe4,
            this.TieuDe5,
            this.TieuDe6});
            this.dtgHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHeader.Location = new System.Drawing.Point(0, 84);
            this.dtgHeader.Name = "dtgHeader";
            this.dtgHeader.RowHeadersVisible = false;
            this.dtgHeader.Size = new System.Drawing.Size(1010, 448);
            this.dtgHeader.TabIndex = 2;
            this.dtgHeader.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgHeader_DataBindingComplete);
            // 
            // MaDonVi
            // 
            this.MaDonVi.DataPropertyName = "MaDonVi";
            this.MaDonVi.HeaderText = "Mã đơn vị";
            this.MaDonVi.Name = "MaDonVi";
            this.MaDonVi.ReadOnly = true;
            this.MaDonVi.Visible = false;
            // 
            // InMau
            // 
            this.InMau.DataPropertyName = "InMau";
            this.InMau.HeaderText = "In màu";
            this.InMau.Name = "InMau";
            this.InMau.Width = 60;
            // 
            // TenPhieuIn
            // 
            this.TenPhieuIn.DataPropertyName = "TenPhieuIn";
            this.TenPhieuIn.HeaderText = "Tên phiếu in kết quả";
            this.TenPhieuIn.Name = "TenPhieuIn";
            this.TenPhieuIn.Width = 200;
            // 
            // NguoiKyTen
            // 
            this.NguoiKyTen.DataPropertyName = "NguoiKyTen";
            this.NguoiKyTen.HeaderText = "Tên người ký";
            this.NguoiKyTen.Name = "NguoiKyTen";
            this.NguoiKyTen.Width = 130;
            // 
            // ChucVu
            // 
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.Width = 130;
            // 
            // TieuDe1
            // 
            this.TieuDe1.DataPropertyName = "TieuDe1";
            this.TieuDe1.HeaderText = "Dòng tiêu đề 1";
            this.TieuDe1.Name = "TieuDe1";
            this.TieuDe1.Width = 200;
            // 
            // TieuDe2
            // 
            this.TieuDe2.DataPropertyName = "TieuDe2";
            this.TieuDe2.HeaderText = "Dòng tiêu đề 2";
            this.TieuDe2.Name = "TieuDe2";
            this.TieuDe2.Width = 200;
            // 
            // TieuDe3
            // 
            this.TieuDe3.DataPropertyName = "TieuDe3";
            this.TieuDe3.HeaderText = "Dòng tiêu đề 3";
            this.TieuDe3.Name = "TieuDe3";
            this.TieuDe3.Width = 200;
            // 
            // TieuDe4
            // 
            this.TieuDe4.DataPropertyName = "TieuDe4";
            this.TieuDe4.HeaderText = "Dòng tiêu đề 4";
            this.TieuDe4.Name = "TieuDe4";
            this.TieuDe4.Width = 200;
            // 
            // TieuDe5
            // 
            this.TieuDe5.DataPropertyName = "TieuDe5";
            this.TieuDe5.HeaderText = "Dòng tiêu đề 5";
            this.TieuDe5.Name = "TieuDe5";
            this.TieuDe5.Width = 200;
            // 
            // TieuDe6
            // 
            this.TieuDe6.DataPropertyName = "TieuDe6";
            this.TieuDe6.HeaderText = "Dòng tiêu đề 6";
            this.TieuDe6.Name = "TieuDe6";
            this.TieuDe6.Width = 200;
            // 
            // frmPrintHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 591);
            this.Name = "frmPrintHeader";
            this.Text = "frmPrintHeader";
            this.Load += new System.EventHandler(this.frmPrintHeader_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvHeader)).EndInit();
            this.bvHeader.ResumeLayout(false);
            this.bvHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radXQuang;
        private System.Windows.Forms.RadioButton radSieuAm;
        private System.Windows.Forms.RadioButton radViSinh;
        private System.Windows.Forms.RadioButton radMienDich;
        private System.Windows.Forms.RadioButton radHuyetHoc;
        private System.Windows.Forms.RadioButton radSinhHoa;
        private System.Windows.Forms.RadioButton radXNChung;
        private System.Windows.Forms.BindingNavigator bvHeader;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView dtgHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonVi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InMau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhieuIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiKyTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe5;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDe6;
    }
}