namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    partial class frmDichVuCLS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDichVuCLS));
            this.dtgDichVuCLS = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaDVCLS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDichVuCLS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvDichVuCLS)).BeginInit();
            this.bvDichVuCLS.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(874, 33);
            this.lblTitle.Text = "DANH MỤC DỊCH VỤ CẬN LÂM SÀNG";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.bvDichVuCLS);
            this.pnContaint.Controls.Add(this.dtgDichVuCLS);
            this.pnContaint.Size = new System.Drawing.Size(882, 645);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(882, 48);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Roboto Condensed", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            // 
            // dtgDichVuCLS
            // 
            this.dtgDichVuCLS.AlignColumns = "";
            this.dtgDichVuCLS.AllignNumberText = false;
            this.dtgDichVuCLS.AllowUserToAddRows = false;
            this.dtgDichVuCLS.AllowUserToDeleteRows = false;
            this.dtgDichVuCLS.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgDichVuCLS.CheckBoldColumn = false;
            this.dtgDichVuCLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDichVuCLS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDVCLS,
            this.MaNhap,
            this.TenDichVu});
            this.dtgDichVuCLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDichVuCLS.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgDichVuCLS.Location = new System.Drawing.Point(4, 6);
            this.dtgDichVuCLS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgDichVuCLS.MarkOddEven = true;
            this.dtgDichVuCLS.Name = "dtgDichVuCLS";
            this.dtgDichVuCLS.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dtgDichVuCLS.Size = new System.Drawing.Size(874, 633);
            this.dtgDichVuCLS.TabIndex = 0;
            this.dtgDichVuCLS.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgDichVuCLS.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgDichVuCLS_DataBindingComplete);
            // 
            // MaDVCLS
            // 
            this.MaDVCLS.DataPropertyName = "MaPhanLoai";
            this.MaDVCLS.HeaderText = "Mã dịch vụ";
            this.MaDVCLS.Name = "MaDVCLS";
            this.MaDVCLS.Visible = false;
            this.MaDVCLS.Width = 130;
            // 
            // MaNhap
            // 
            this.MaNhap.DataPropertyName = "MaNhap";
            this.MaNhap.HeaderText = "Mã nhập";
            this.MaNhap.Name = "MaNhap";
            // 
            // TenDichVu
            // 
            this.TenDichVu.DataPropertyName = "TenPhanLoai";
            this.TenDichVu.HeaderText = "Tên dịch vụ";
            this.TenDichVu.Name = "TenDoiTuongDichVu";
            this.TenDichVu.Width = 250;
            // 
            // bvDichVuCLS
            // 
            this.bvDichVuCLS.AddNewItem = null;
            this.bvDichVuCLS.CountItem = this.bindingNavigatorCountItem;
            this.bvDichVuCLS.CountItemFormat = "/ {0}";
            this.bvDichVuCLS.DeleteItem = null;
            this.bvDichVuCLS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvDichVuCLS.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Bold);
            this.bvDichVuCLS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bvDichVuCLS.Location = new System.Drawing.Point(4, 614);
            this.bvDichVuCLS.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvDichVuCLS.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvDichVuCLS.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvDichVuCLS.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvDichVuCLS.Name = "bvDichVuCLS";
            this.bvDichVuCLS.PositionItem = this.bindingNavigatorPositionItem;
            this.bvDichVuCLS.Size = new System.Drawing.Size(874, 25);
            this.bvDichVuCLS.TabIndex = 1;
            this.bvDichVuCLS.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
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
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(44, 23);
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
            // frmDichVuCLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 695);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmDichVuCLS";
            this.Text = "Dịch vụ cận lâm sàng";
            this.Load += new System.EventHandler(this.frmDichVuCLS_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDVCLS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgDichVuCLS;
    }
}