namespace TPH.LIS.App.CauHinh.DanhMucKhamBenh
{
    partial class FrmCachDungThuoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCachDungThuoc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bvCachDung = new TPH.LIS.Common.Controls.CustomBindingNavigator();
            this.btnThemCachDung = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelCachDung = new System.Windows.Forms.ToolStripButton();
            this.dtgCachDung = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCachDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bvCachDung)).BeginInit();
            this.bvCachDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCachDung)).BeginInit();
            this.SuspendLayout();
            // 
            // bvCachDung
            // 
            this.bvCachDung.AddNewItem = this.btnThemCachDung;
            this.bvCachDung.CountItem = this.bindingNavigatorCountItem;
            this.bvCachDung.CountItemFormat = "/ {0}";
            this.bvCachDung.DeleteItem = null;
            this.bvCachDung.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bvCachDung.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.bvCachDung.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.btnThemCachDung,
            this.toolStripSeparator1,
            this.btnDelCachDung});
            this.bvCachDung.Location = new System.Drawing.Point(0, 287);
            this.bvCachDung.MoveFirstItem = null;
            this.bvCachDung.MoveLastItem = null;
            this.bvCachDung.MoveNextItem = null;
            this.bvCachDung.MovePreviousItem = null;
            this.bvCachDung.Name = "bvCachDung";
            this.bvCachDung.PositionItem = this.bindingNavigatorPositionItem;
            this.bvCachDung.Size = new System.Drawing.Size(343, 25);
            this.bvCachDung.TabIndex = 1;
            this.bvCachDung.Text = "bindingNavigator1";
            // 
            // btnThemCachDung
            // 
            this.btnThemCachDung.Image = ((System.Drawing.Image)(resources.GetObject("btnThemCachDung.Image")));
            this.btnThemCachDung.Name = "btnThemCachDung";
            this.btnThemCachDung.RightToLeftAutoMirrorImage = true;
            this.btnThemCachDung.Size = new System.Drawing.Size(55, 22);
            this.btnThemCachDung.Text = "Thêm";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelCachDung
            // 
            this.btnDelCachDung.Image = ((System.Drawing.Image)(resources.GetObject("btnDelCachDung.Image")));
            this.btnDelCachDung.Name = "btnDelCachDung";
            this.btnDelCachDung.RightToLeftAutoMirrorImage = true;
            this.btnDelCachDung.Size = new System.Drawing.Size(47, 22);
            this.btnDelCachDung.Text = "Xóa";
            this.btnDelCachDung.Click += new System.EventHandler(this.btnDelCachDung_Click);
            // 
            // dtgCachDung
            // 
            this.dtgCachDung.AllowUserToAddRows = false;
            this.dtgCachDung.AllowUserToDeleteRows = false;
            this.dtgCachDung.ColumnHeadersHeight = 25;
            this.dtgCachDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TenCachDung});
            this.dtgCachDung.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(132)))), ((int)(((byte)(176)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCachDung.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgCachDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCachDung.AlignColumns = "";
            this.dtgCachDung.Location = new System.Drawing.Point(0, 0);
            this.dtgCachDung.MultiSelect = false;
            this.dtgCachDung.Name = "dtgCachDung";
            this.dtgCachDung.NumberAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCachDung.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgCachDung.RowHeadersWidth = 40;
            this.dtgCachDung.Size = new System.Drawing.Size(343, 287);
            this.dtgCachDung.TabIndex = 2;
            this.dtgCachDung.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dtgCachDung.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgCachDung_DataBindingComplete);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Mã cách dùng";
            this.ID.Name = "ID";
            this.ID.Width = 110;
            // 
            // TenCachDung
            // 
            this.TenCachDung.DataPropertyName = "TenCachDung";
            this.TenCachDung.HeaderText = "Tên cách dùng";
            this.TenCachDung.Name = "TenCachDung";
            this.TenCachDung.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã cách dùng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenCachDung";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên cách dùng";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // FrmCachDungThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(343, 312);
            this.Controls.Add(this.dtgCachDung);
            this.Controls.Add(this.bvCachDung);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCachDungThuoc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách cách dùng thuốc";
            this.Load += new System.EventHandler(this.FrmCachDungThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bvCachDung)).EndInit();
            this.bvCachDung.ResumeLayout(false);
            this.bvCachDung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCachDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TPH.LIS.Common.Controls.CustomBindingNavigator bvCachDung;
        private System.Windows.Forms.ToolStripButton btnThemCachDung;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton btnDelCachDung;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCachDung;
        private TPH.LIS.Common.Controls.CustomDatagridView dtgCachDung;
    }
}