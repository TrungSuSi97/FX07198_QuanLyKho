namespace TPH.LIS.App.Settings.DanhMucCLS
{
    partial class FrmDMCLS_XemDMXetNghiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDMCLS_XemDMXetNghiem));
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.cboMaNhomCLSFilter = new System.Windows.Forms.ComboBox();
            this.txtTestNameFilter = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.bvXetNghiem = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dtgXetNghiem = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.colMaXn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenXn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.bvXetNghiem)).BeginInit();
            this.bvXetNghiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgXetNghiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
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
            this.lblTitle.Text = "TÌM XÉT NGHIỆM";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.dtgXetNghiem);
            this.pnContaint.Controls.Add(this.panel2);
            this.pnContaint.Controls.Add(this.bvXetNghiem);
            this.pnContaint.Controls.Add(this.panel1);
            this.pnContaint.Location = new System.Drawing.Point(0, 26);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnContaint.Size = new System.Drawing.Size(496, 511);
            // 
            // pnLabel
            // 
            this.pnLabel.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnLabel.Size = new System.Drawing.Size(496, 0);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(144, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnClose.Size = new System.Drawing.Size(29, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(173, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Size = new System.Drawing.Size(496, 26);
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(496, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(133, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 24);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(388, 1);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.cboMaNhomCLSFilter);
            this.panel1.Controls.Add(this.txtTestNameFilter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 81);
            this.panel1.TabIndex = 0;
            // 
            // cboMaNhomCLSFilter
            // 
            this.cboMaNhomCLSFilter.FormattingEnabled = true;
            this.cboMaNhomCLSFilter.Location = new System.Drawing.Point(131, 18);
            this.cboMaNhomCLSFilter.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboMaNhomCLSFilter.Name = "cboMaNhomCLSFilter";
            this.cboMaNhomCLSFilter.Size = new System.Drawing.Size(137, 23);
            this.cboMaNhomCLSFilter.TabIndex = 7;
            this.cboMaNhomCLSFilter.SelectedIndexChanged += new System.EventHandler(this.cboMaNhomCLSFilter_SelectedIndexChanged);
            // 
            // txtTestNameFilter
            // 
            this.txtTestNameFilter.Location = new System.Drawing.Point(131, 43);
            this.txtTestNameFilter.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtTestNameFilter.Name = "txtTestNameFilter";
            this.txtTestNameFilter.Size = new System.Drawing.Size(316, 21);
            this.txtTestNameFilter.TabIndex = 4;
            this.txtTestNameFilter.TextChanged += new System.EventHandler(this.txtTestNameFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tìm xét nghiệm";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lọc theo nhóm";
            // 
            // bvXetNghiem
            // 
            this.bvXetNghiem.AddNewItem = null;
            this.bvXetNghiem.CountItem = this.bindingNavigatorCountItem;
            this.bvXetNghiem.CountItemFormat = "/ {0}";
            this.bvXetNghiem.DeleteItem = null;
            this.bvXetNghiem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvXetNghiem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bvXetNghiem.Location = new System.Drawing.Point(2, 83);
            this.bvXetNghiem.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvXetNghiem.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvXetNghiem.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvXetNghiem.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvXetNghiem.Name = "bvXetNghiem";
            this.bvXetNghiem.PositionItem = this.bindingNavigatorPositionItem;
            this.bvXetNghiem.Size = new System.Drawing.Size(492, 25);
            this.bvXetNghiem.TabIndex = 1;
            this.bvXetNghiem.Text = "customBindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(43, 23);
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
            // dtgXetNghiem
            // 
            this.dtgXetNghiem.AlignColumns = null;
            this.dtgXetNghiem.AllignNumberText = false;
            this.dtgXetNghiem.AllowUserToAddRows = false;
            this.dtgXetNghiem.AllowUserToDeleteRows = false;
            this.dtgXetNghiem.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgXetNghiem.CheckBoldColumn = false;
            this.dtgXetNghiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgXetNghiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaXn,
            this.colTenXn,
            this.colMaNhom,
            this.colProfile});
            this.dtgXetNghiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgXetNghiem.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgXetNghiem.Location = new System.Drawing.Point(2, 108);
            this.dtgXetNghiem.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtgXetNghiem.MarkOddEven = false;
            this.dtgXetNghiem.Name = "dtgXetNghiem";
            this.dtgXetNghiem.ReadOnly = true;
            this.dtgXetNghiem.Size = new System.Drawing.Size(492, 361);
            this.dtgXetNghiem.TabIndex = 2;
            // 
            // colMaXn
            // 
            this.colMaXn.DataPropertyName = "MAXN";
            this.colMaXn.HeaderText = "Mã XN";
            this.colMaXn.Name = "colMaXn";
            this.colMaXn.ReadOnly = true;
            // 
            // colTenXn
            // 
            this.colTenXn.DataPropertyName = "TenXn";
            this.colTenXn.HeaderText = "Tên XN";
            this.colTenXn.Name = "colTenXn";
            this.colTenXn.ReadOnly = true;
            this.colTenXn.Width = 300;
            // 
            // colMaNhom
            // 
            this.colMaNhom.DataPropertyName = "MaNhomCLS";
            this.colMaNhom.HeaderText = "Mã nhóm";
            this.colMaNhom.Name = "colMaNhom";
            this.colMaNhom.ReadOnly = true;
            // 
            // colProfile
            // 
            this.colProfile.DataPropertyName = "IsProfile";
            this.colProfile.HeaderText = "Profile (++)";
            this.colProfile.Name = "colProfile";
            this.colProfile.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(2, 469);
            this.panel2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 40);
            this.panel2.TabIndex = 3;
            // 
            // FrmDMCLS_XemDMXetNghiem
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(496, 537);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FrmDMCLS_XemDMXetNghiem";
            this.Text = "FrmDMCLS_XemDMXetNghiem";
            this.Load += new System.EventHandler(this.FrmDMCLS_XemDMXetNghiem_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.bvXetNghiem)).EndInit();
            this.bvXetNghiem.ResumeLayout(false);
            this.bvXetNghiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgXetNghiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panel1;
        private Common.Controls.CustomDatagridView dtgXetNghiem;
        private Common.Controls.CustomBindingNavigator bvXetNghiem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ComboBox cboMaNhomCLSFilter;
        private System.Windows.Forms.TextBox txtTestNameFilter;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.PanelControl panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaXn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenXn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfile;
    }
}