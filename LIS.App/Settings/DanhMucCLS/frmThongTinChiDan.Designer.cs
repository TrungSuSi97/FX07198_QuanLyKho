namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    partial class frmThongTinChiDan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinChiDan));
            this.dtgDichVuCLS = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaDVCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDoiTuongDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiDan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvDichVuCLS = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLamMoi = new System.Windows.Forms.ToolStripButton();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDichVuCLS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDichVuCLS)).BeginInit();
            this.bvDichVuCLS.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Size = new System.Drawing.Size(168, 22);
            this.lblTitle.Text = "THÔNG TIN CHỈ DẪN";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.dtgDichVuCLS);
            this.pnContaint.Controls.Add(this.bvDichVuCLS);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnContaint.Size = new System.Drawing.Size(574, 271);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(3, 6, 3, 2);
            this.pnLabel.Size = new System.Drawing.Size(574, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(202, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(231, 6);
            this.lblMainESC.Size = new System.Drawing.Size(340, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(574, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(574, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(170, 1);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(466, 1);
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
            // dtgDichVuCLS
            // 
            this.dtgDichVuCLS.AlignColumns = "";
            this.dtgDichVuCLS.AllignNumberText = false;
            this.dtgDichVuCLS.AllowUserToAddRows = false;
            this.dtgDichVuCLS.AllowUserToDeleteRows = false;
            this.dtgDichVuCLS.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDichVuCLS.CheckBoldColumn = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDichVuCLS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDichVuCLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDichVuCLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDVCLS,
            this.MaNhap,
            this.TenDoiTuongDichVu,
            this.colChiDan});
            this.dtgDichVuCLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDichVuCLS.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgDichVuCLS.Location = new System.Drawing.Point(3, 2);
            this.dtgDichVuCLS.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtgDichVuCLS.MarkOddEven = true;
            this.dtgDichVuCLS.Name = "dtgDichVuCLS";
            this.dtgDichVuCLS.Size = new System.Drawing.Size(568, 242);
            this.dtgDichVuCLS.TabIndex = 0;
            this.dtgDichVuCLS.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgDichVuCLS_DataBindingComplete);
            // 
            // MaDVCLS
            // 
            this.MaDVCLS.DataPropertyName = "MaPhanLoai";
            this.MaDVCLS.HeaderText = "Mã dịch vụ";
            this.MaDVCLS.Name = "MaDVCLS";
            this.MaDVCLS.ReadOnly = true;
            this.MaDVCLS.Width = 130;
            // 
            // MaNhap
            // 
            this.MaNhap.DataPropertyName = "MaNhap";
            this.MaNhap.HeaderText = "Mã nhập";
            this.MaNhap.Name = "MaNhap";
            this.MaNhap.ReadOnly = true;
            this.MaNhap.Visible = false;
            // 
            // TenDoiTuongDichVu
            // 
            this.TenDoiTuongDichVu.DataPropertyName = "TenPhanLoai";
            this.TenDoiTuongDichVu.HeaderText = "Tên loại dịch vụ";
            this.TenDoiTuongDichVu.Name = "TenDoiTuongDichVu";
            this.TenDoiTuongDichVu.Width = 250;
            // 
            // colChiDan
            // 
            this.colChiDan.DataPropertyName = "PhongKham";
            this.colChiDan.HeaderText = "Chỉ dẫn ";
            this.colChiDan.MaxInputLength = 250;
            this.colChiDan.Name = "colChiDan";
            this.colChiDan.Width = 300;
            // 
            // bvDichVuCLS
            // 
            this.bvDichVuCLS.AddNewItem = null;
            this.bvDichVuCLS.CountItem = this.bindingNavigatorCountItem;
            this.bvDichVuCLS.CountItemFormat = "/ {0}";
            this.bvDichVuCLS.DeleteItem = null;
            this.bvDichVuCLS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvDichVuCLS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvDichVuCLS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnLamMoi});
            this.bvDichVuCLS.Location = new System.Drawing.Point(3, 244);
            this.bvDichVuCLS.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvDichVuCLS.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvDichVuCLS.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvDichVuCLS.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvDichVuCLS.Name = "bvDichVuCLS";
            this.bvDichVuCLS.PositionItem = this.bindingNavigatorPositionItem;
            this.bvDichVuCLS.Size = new System.Drawing.Size(568, 25);
            this.bvDichVuCLS.TabIndex = 1;
            this.bvDichVuCLS.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(30, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(38, 23);
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
            // btnLamMoi
            // 
            this.btnLamMoi.Image = global::TPH.LIS.App.Properties.Resources.Refresh__1_;
            this.btnLamMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(78, 22);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmThongTinChiDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(574, 297);
            this.Name = "frmThongTinChiDan";
            this.Text = "Thông tin chi dẫn";
            this.Load += new System.EventHandler(this.frmDichVuCLS_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDichVuCLS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDichVuCLS)).EndInit();
            this.bvDichVuCLS.ResumeLayout(false);
            this.bvDichVuCLS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TPH.LIS.Common.Controls.CustomBindingNavigator bvDichVuCLS;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgDichVuCLS;
        private System.Windows.Forms.ToolStripButton btnLamMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDVCLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDoiTuongDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiDan;
    }
}