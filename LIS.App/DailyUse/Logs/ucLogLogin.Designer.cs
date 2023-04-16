namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{
    partial class ucLogLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLogLogin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchSEQ = new TPH.Controls.TPHNormalButton();
            this.txtSearchValue = new TPH.LIS.Common.Controls.CustomTextBox(this.components);
            this.customLable3 = new TPH.LIS.Common.Controls.CustomLable();
            this.dtpToDate = new TPH.LIS.Common.Controls.CustomDateTimePicker();
            this.dtpFromDate = new TPH.LIS.Common.Controls.CustomDateTimePicker();
            this.customLable2 = new TPH.LIS.Common.Controls.CustomLable();
            this.customLable1 = new TPH.LIS.Common.Controls.CustomLable();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgLogList = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bvList = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLogList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).BeginInit();
            this.bvList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchSEQ);
            this.groupBox1.Controls.Add(this.txtSearchValue);
            this.groupBox1.Controls.Add(this.customLable3);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.customLable2);
            this.groupBox1.Controls.Add(this.customLable1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // btnSearchSEQ
            // 
            this.btnSearchSEQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnSearchSEQ.BackColorHover = System.Drawing.Color.Empty;
            this.btnSearchSEQ.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnSearchSEQ.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSearchSEQ.BorderRadius = 5;
            this.btnSearchSEQ.BorderSize = 1;
            this.btnSearchSEQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchSEQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSEQ.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSEQ.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSearchSEQ.ForeColor = System.Drawing.Color.Black;
            this.btnSearchSEQ.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSEQ.Image")));
            this.btnSearchSEQ.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchSEQ.Location = new System.Drawing.Point(364, 20);
            this.btnSearchSEQ.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnSearchSEQ.Name = "btnSearchSEQ";
            this.btnSearchSEQ.Size = new System.Drawing.Size(98, 55);
            this.btnSearchSEQ.TabIndex = 92;
            this.btnSearchSEQ.Text = "Tìm kiếm";
            this.btnSearchSEQ.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearchSEQ.TextColor = System.Drawing.Color.Black;
            this.btnSearchSEQ.UseHightLight = true;
            this.btnSearchSEQ.UseVisualStyleBackColor = false;
            this.btnSearchSEQ.Click += new System.EventHandler(this.btnSearchSEQ_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BackColorEnter = System.Drawing.Color.Yellow;
            this.txtSearchValue.BindFieldName = null;
            this.txtSearchValue.ForceColorEnter = System.Drawing.Color.DarkRed;
            this.txtSearchValue.Location = new System.Drawing.Point(91, 54);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.OldValue = null;
            this.txtSearchValue.Size = new System.Drawing.Size(267, 21);
            this.txtSearchValue.TabIndex = 5;
            this.txtSearchValue.UseFocusColor = true;
            // 
            // customLable3
            // 
            this.customLable3.AutoSize = true;
            this.customLable3.BindFieldName = null;
            this.customLable3.Color = System.Drawing.Color.Black;
            this.customLable3.ForeColorClicked = System.Drawing.Color.White;
            this.customLable3.GetControl = null;
            this.customLable3.Location = new System.Drawing.Point(6, 57);
            this.customLable3.Name = "customLable3";
            this.customLable3.OldValue = null;
            this.customLable3.ShadowDepth = 3;
            this.customLable3.Size = new System.Drawing.Size(79, 15);
            this.customLable3.Softness = 1.5F;
            this.customLable3.TabIndex = 4;
            this.customLable3.Text = "Mã tài khoản:";
            this.customLable3.UseShadow = false;
            this.customLable3.UseZoom = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.AllowMoveFocus = true;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.IsEndDate = true;
            this.dtpToDate.IsStartDate = false;
            this.dtpToDate.Location = new System.Drawing.Point(214, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(144, 21);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AllowMoveFocus = true;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.IsEndDate = false;
            this.dtpFromDate.IsStartDate = true;
            this.dtpFromDate.Location = new System.Drawing.Point(32, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(144, 21);
            this.dtpFromDate.TabIndex = 2;
            // 
            // customLable2
            // 
            this.customLable2.AutoSize = true;
            this.customLable2.BindFieldName = null;
            this.customLable2.Color = System.Drawing.Color.Black;
            this.customLable2.ForeColorClicked = System.Drawing.Color.White;
            this.customLable2.GetControl = null;
            this.customLable2.Location = new System.Drawing.Point(182, 29);
            this.customLable2.Name = "customLable2";
            this.customLable2.OldValue = null;
            this.customLable2.ShadowDepth = 3;
            this.customLable2.Size = new System.Drawing.Size(28, 15);
            this.customLable2.Softness = 1.5F;
            this.customLable2.TabIndex = 1;
            this.customLable2.Text = "đến";
            this.customLable2.UseShadow = false;
            this.customLable2.UseZoom = false;
            // 
            // customLable1
            // 
            this.customLable1.AutoSize = true;
            this.customLable1.BindFieldName = null;
            this.customLable1.Color = System.Drawing.Color.Black;
            this.customLable1.ForeColorClicked = System.Drawing.Color.White;
            this.customLable1.GetControl = null;
            this.customLable1.Location = new System.Drawing.Point(6, 29);
            this.customLable1.Name = "customLable1";
            this.customLable1.OldValue = null;
            this.customLable1.ShadowDepth = 3;
            this.customLable1.Size = new System.Drawing.Size(22, 15);
            this.customLable1.Softness = 1.5F;
            this.customLable1.TabIndex = 0;
            this.customLable1.Text = "Từ";
            this.customLable1.UseShadow = false;
            this.customLable1.UseZoom = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgLogList);
            this.groupBox2.Controls.Add(this.bvList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 420);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả tìm kiếm";
            // 
            // dtgLogList
            // 
            this.dtgLogList.AlignColumns = null;
            this.dtgLogList.AllignNumberText = false;
            this.dtgLogList.AllowUserToAddRows = false;
            this.dtgLogList.AllowUserToDeleteRows = false;
            this.dtgLogList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgLogList.CheckBoldColumn = false;
            this.dtgLogList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLogList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ThoiGian,
            this.NguoiThucHien,
            this.ID});
            this.dtgLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLogList.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgLogList.Location = new System.Drawing.Point(3, 17);
            this.dtgLogList.MarkOddEven = false;
            this.dtgLogList.Name = "dtgLogList";
            this.dtgLogList.ReadOnly = true;
            this.dtgLogList.Size = new System.Drawing.Size(654, 375);
            this.dtgLogList.TabIndex = 0;
            // 
            // ThoiGian
            // 
            this.ThoiGian.DataPropertyName = "ThoiGian";
            dataGridViewCellStyle1.Format = "HH:mm dd/MM/yyyy";
            this.ThoiGian.DefaultCellStyle = dataGridViewCellStyle1;
            this.ThoiGian.HeaderText = "T.Gian đăng nhập";
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.ReadOnly = true;
            this.ThoiGian.Width = 150;
            // 
            // NguoiThucHien
            // 
            this.NguoiThucHien.DataPropertyName = "NguoiThucHien";
            this.NguoiThucHien.HeaderText = "Mã tài khoản";
            this.NguoiThucHien.Name = "NguoiThucHien";
            this.NguoiThucHien.ReadOnly = true;
            this.NguoiThucHien.Width = 150;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // bvList
            // 
            this.bvList.AddNewItem = null;
            this.bvList.CountItem = this.bindingNavigatorCountItem;
            this.bvList.CountItemFormat = "/ {0}";
            this.bvList.DeleteItem = null;
            this.bvList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.bvList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bvList.Location = new System.Drawing.Point(3, 392);
            this.bvList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvList.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvList.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvList.Name = "bvList";
            this.bvList.PositionItem = this.bindingNavigatorPositionItem;
            this.bvList.Size = new System.Drawing.Size(654, 25);
            this.bvList.TabIndex = 79;
            this.bvList.Text = "customBindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(33, 22);
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
            // ucLogLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucLogLogin";
            this.Size = new System.Drawing.Size(660, 500);
            this.Load += new System.EventHandler(this.ucLogThongTinHanhChinh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLogList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).EndInit();
            this.bvList.ResumeLayout(false);
            this.bvList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Common.Controls.CustomLable customLable2;
        private Common.Controls.CustomLable customLable1;
        private Common.Controls.CustomLable customLable3;
        private TPH.Controls.TPHNormalButton btnSearchSEQ;
        public Common.Controls.CustomDateTimePicker dtpToDate;
        public Common.Controls.CustomDateTimePicker dtpFromDate;
        public Common.Controls.CustomTextBox txtSearchValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private Common.Controls.CustomDatagridView dtgLogList;
        private System.Windows.Forms.TextBox txtUserSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiThucHien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private Common.Controls.CustomBindingNavigator bvList;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
    }
}
