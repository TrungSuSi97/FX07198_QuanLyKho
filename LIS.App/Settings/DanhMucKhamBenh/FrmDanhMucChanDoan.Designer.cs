namespace TPH.LIS.App.CauHinh.DanhMucKhamBenh
{
    partial class FrmDanhMucChanDoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDanhMucChanDoan));
            this.dtgChanDoan = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.MaChanDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChanDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvChanDoan = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.btnXoaChanDoan = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshMaNhomCLS = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaChanDoan = new System.Windows.Forms.TextBox();
            this.btnAddChanDoan = new TPH.Controls.TPHNormalButton();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChanDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChanDoan)).BeginInit();
            this.bvChanDoan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(208, 22);
            this.lblTitle.Text = "DANH SÁCH CHẨN ĐOÁN";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.dtgChanDoan);
            this.pnContaint.Controls.Add(this.bvChanDoan);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Location = new System.Drawing.Point(0, 48);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnContaint.Size = new System.Drawing.Size(1150, 652);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Padding = new System.Windows.Forms.Padding(4, 7, 4, 2);
            this.pnLabel.Size = new System.Drawing.Size(1150, 38);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(764, 7);
            this.btnClose.Size = new System.Drawing.Size(29, 29);
            this.btnClose.TextColor = System.Drawing.Color.Crimson;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(793, 7);
            this.lblMainESC.Size = new System.Drawing.Size(353, 29);
            // 
            // pnMenu
            // 
            this.pnMenu.Location = new System.Drawing.Point(0, 38);
            this.pnMenu.Size = new System.Drawing.Size(1150, 10);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(130)))), ((int)(((byte)(167)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(1150, 9);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(210, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 8);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(1042, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 8);
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
            // dtgChanDoan
            // 
            this.dtgChanDoan.AlignColumns = "";
            this.dtgChanDoan.AllignNumberText = false;
            this.dtgChanDoan.AllowUserToAddRows = false;
            this.dtgChanDoan.AllowUserToDeleteRows = false;
            this.dtgChanDoan.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgChanDoan.CheckBoldColumn = false;
            this.dtgChanDoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChanDoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChanDoan,
            this.TenChanDoan});
            this.dtgChanDoan.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgChanDoan.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgChanDoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChanDoan.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgChanDoan.Location = new System.Drawing.Point(4, 81);
            this.dtgChanDoan.MarkOddEven = true;
            this.dtgChanDoan.MultiSelect = false;
            this.dtgChanDoan.Name = "dtgChanDoan";
            this.dtgChanDoan.RowHeadersWidth = 35;
            this.dtgChanDoan.Size = new System.Drawing.Size(1142, 568);
            this.dtgChanDoan.TabIndex = 5;
            this.dtgChanDoan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgChanDoan_DataBindingComplete);
            // 
            // MaChanDoan
            // 
            this.MaChanDoan.DataPropertyName = "MaChanDoan";
            this.MaChanDoan.HeaderText = "Mã chẩn đoán";
            this.MaChanDoan.MinimumWidth = 6;
            this.MaChanDoan.Name = "MaChanDoan";
            this.MaChanDoan.Width = 150;
            // 
            // TenChanDoan
            // 
            this.TenChanDoan.DataPropertyName = "TenChanDoan";
            this.TenChanDoan.HeaderText = "Chẩn đoán";
            this.TenChanDoan.MinimumWidth = 6;
            this.TenChanDoan.Name = "TenChanDoan";
            this.TenChanDoan.Width = 500;
            // 
            // bvChanDoan
            // 
            this.bvChanDoan.AddNewItem = null;
            this.bvChanDoan.CountItem = this.bindingNavigatorCountItem1;
            this.bvChanDoan.CountItemFormat = "/ {0}";
            this.bvChanDoan.DeleteItem = this.btnXoaChanDoan;
            this.bvChanDoan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvChanDoan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bvChanDoan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator4,
            this.btnXoaChanDoan,
            this.toolStripSeparator1,
            this.btnRefreshMaNhomCLS});
            this.bvChanDoan.Location = new System.Drawing.Point(4, 54);
            this.bvChanDoan.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvChanDoan.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvChanDoan.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bvChanDoan.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bvChanDoan.Name = "bvChanDoan";
            this.bvChanDoan.PositionItem = this.bindingNavigatorPositionItem1;
            this.bvChanDoan.Size = new System.Drawing.Size(1142, 27);
            this.bvChanDoan.TabIndex = 6;
            this.bvChanDoan.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(30, 24);
            this.bindingNavigatorCountItem1.Text = "/ {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // btnXoaChanDoan
            // 
            this.btnXoaChanDoan.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaChanDoan.Image")));
            this.btnXoaChanDoan.Name = "btnXoaChanDoan";
            this.btnXoaChanDoan.RightToLeftAutoMirrorImage = true;
            this.btnXoaChanDoan.Size = new System.Drawing.Size(115, 24);
            this.btnXoaChanDoan.Text = "Xóa chẩn đoán";
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
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(44, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 27);
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
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRefreshMaNhomCLS
            // 
            this.btnRefreshMaNhomCLS.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshMaNhomCLS.Image")));
            this.btnRefreshMaNhomCLS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshMaNhomCLS.Name = "btnRefreshMaNhomCLS";
            this.btnRefreshMaNhomCLS.Size = new System.Drawing.Size(82, 24);
            this.btnRefreshMaNhomCLS.Text = "Làm mới";
            this.btnRefreshMaNhomCLS.Click += new System.EventHandler(this.btnRefreshMaNhomCLS_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaChanDoan);
            this.panel1.Controls.Add(this.btnAddChanDoan);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtChanDoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 51);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mã chẩn đoán";
            // 
            // txtMaChanDoan
            // 
            this.txtMaChanDoan.Location = new System.Drawing.Point(125, 14);
            this.txtMaChanDoan.Name = "txtMaChanDoan";
            this.txtMaChanDoan.Size = new System.Drawing.Size(104, 20);
            this.txtMaChanDoan.TabIndex = 8;
            this.txtMaChanDoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaChanDoan_KeyPress);
            // 
            // btnAddChanDoan
            // 
            this.btnAddChanDoan.BackColor = System.Drawing.Color.Transparent;
            this.btnAddChanDoan.BackColorHover = System.Drawing.Color.Empty;
            this.btnAddChanDoan.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddChanDoan.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChanDoan.BorderRadius = 5;
            this.btnAddChanDoan.BorderSize = 1;
            this.btnAddChanDoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddChanDoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddChanDoan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddChanDoan.ForceColorHover = System.Drawing.Color.Empty;
            this.btnAddChanDoan.ForeColor = System.Drawing.Color.Black;
            this.btnAddChanDoan.Image = ((System.Drawing.Image)(resources.GetObject("btnAddChanDoan.Image")));
            this.btnAddChanDoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddChanDoan.Location = new System.Drawing.Point(740, 12);
            this.btnAddChanDoan.Name = "btnAddChanDoan";
            this.btnAddChanDoan.Size = new System.Drawing.Size(123, 27);
            this.btnAddChanDoan.TabIndex = 5;
            this.btnAddChanDoan.Text = "Thêm mới";
            this.btnAddChanDoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddChanDoan.TextColor = System.Drawing.Color.Black;
            this.btnAddChanDoan.UseHightLight = true;
            this.btnAddChanDoan.UseVisualStyleBackColor = true;
            this.btnAddChanDoan.Click += new System.EventHandler(this.btnAddChanDoan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Chẩn đoán";
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Location = new System.Drawing.Point(329, 14);
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.Size = new System.Drawing.Size(396, 20);
            this.txtChanDoan.TabIndex = 0;
            this.txtChanDoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChanDoan_KeyPress);
            // 
            // FrmDanhMucChanDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FrmDanhMucChanDoan";
            this.Text = "Danh sách chẩn đoán";
            this.Load += new System.EventHandler(this.FrmDanhMucChanDoan_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChanDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvChanDoan)).EndInit();
            this.bvChanDoan.ResumeLayout(false);
            this.bvChanDoan.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TPH.LIS.Common.Controls.CustomDatagridView dtgChanDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChanDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChanDoan;
        private TPH.LIS.Common.Controls.CustomBindingNavigator bvChanDoan;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton btnXoaChanDoan;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRefreshMaNhomCLS;
        private DevExpress.XtraEditors.PanelControl panel1;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.TextBox txtMaChanDoan;
        private TPH.Controls.TPHNormalButton btnAddChanDoan;
        private DevExpress.XtraEditors.LabelControl label4;
        private System.Windows.Forms.TextBox txtChanDoan;
    }
}