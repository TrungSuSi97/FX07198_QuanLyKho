namespace TPH.HIS.Controls
{
    partial class FrmCompareConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompareConfig));
            this.dtgList = new TPH.LIS.Common.Controls.CustomDatagridView();
            this.colHis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new TPH.Controls.TPHNormalButton();
            this.btnOk = new TPH.Controls.TPHNormalButton();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSetToRow = new TPH.Controls.TPHNormalButton();
            this.txtLIS = new System.Windows.Forms.TextBox();
            this.cboLIS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).BeginInit();
            this.bvList.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgList
            // 
            this.dtgList.AlignColumns = null;
            this.dtgList.AllignNumberText = false;
            this.dtgList.AllowUserToAddRows = false;
            this.dtgList.AllowUserToDeleteRows = false;
            this.dtgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgList.CheckBoldColumn = false;
            this.dtgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHis,
            this.colLIS});
            this.dtgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgList.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.dtgList.Location = new System.Drawing.Point(0, 73);
            this.dtgList.MarkOddEven = true;
            this.dtgList.Name = "dtgList";
            this.dtgList.Size = new System.Drawing.Size(631, 512);
            this.dtgList.TabIndex = 0;
            this.dtgList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgList_RowPostPaint);
            // 
            // colHis
            // 
            this.colHis.DataPropertyName = "HIS";
            this.colHis.HeaderText = "Trường HIS";
            this.colHis.Name = "colHis";
            this.colHis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colLIS
            // 
            this.colLIS.DataPropertyName = "LIS";
            this.colLIS.HeaderText = "Trường LIS";
            this.colLIS.Name = "colLIS";
            this.colLIS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 585);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnClose.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderSize = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(322, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnOk.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOk.BorderRadius = 5;
            this.btnOk.BorderSize = 1;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(179, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(115, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Lấy cấu hình";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnOk.UseHightLight = true;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // bvList
            // 
            this.bvList.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bvList.CountItem = this.bindingNavigatorCountItem;
            this.bvList.DeleteItem = this.bindingNavigatorDeleteItem;
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
            this.bvList.Location = new System.Drawing.Point(0, 48);
            this.bvList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvList.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvList.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvList.Name = "bvList";
            this.bvList.PositionItem = this.bindingNavigatorPositionItem;
            this.bvList.Size = new System.Drawing.Size(631, 25);
            this.bvList.TabIndex = 2;
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 23);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSetToRow);
            this.panel2.Controls.Add(this.txtLIS);
            this.panel2.Controls.Add(this.cboLIS);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 48);
            this.panel2.TabIndex = 3;
            // 
            // btnSetToRow
            // 
            this.btnSetToRow.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetToRow.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnSetToRow.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSetToRow.BorderRadius = 5;
            this.btnSetToRow.BorderSize = 1;
            this.btnSetToRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetToRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetToRow.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetToRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetToRow.Image = ((System.Drawing.Image)(resources.GetObject("btnSetToRow.Image")));
            this.btnSetToRow.Location = new System.Drawing.Point(584, 7);
            this.btnSetToRow.Name = "btnSetToRow";
            this.btnSetToRow.Size = new System.Drawing.Size(35, 29);
            this.btnSetToRow.TabIndex = 3;
            this.btnSetToRow.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnSetToRow.UseHightLight = true;
            this.btnSetToRow.UseVisualStyleBackColor = true;
            this.btnSetToRow.Click += new System.EventHandler(this.btnSetToRow_Click);
            // 
            // txtLIS
            // 
            this.txtLIS.Location = new System.Drawing.Point(384, 10);
            this.txtLIS.Name = "txtLIS";
            this.txtLIS.ReadOnly = true;
            this.txtLIS.Size = new System.Drawing.Size(194, 23);
            this.txtLIS.TabIndex = 2;
            // 
            // cboLIS
            // 
            this.cboLIS.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLIS.FormattingEnabled = true;
            this.cboLIS.Location = new System.Drawing.Point(85, 7);
            this.cboLIS.Name = "cboLIS";
            this.cboLIS.Size = new System.Drawing.Size(293, 25);
            this.cboLIS.TabIndex = 1;
            this.cboLIS.SelectedIndexChanged += new System.EventHandler(this.cboLIS_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giá trị LIS:";
            // 
            // FrmCompareConfig
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(631, 627);
            this.ControlBox = false;
            this.Controls.Add(this.dtgList);
            this.Controls.Add(this.bvList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCompareConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KHAI BÁO PARA";
            this.Load += new System.EventHandler(this.FrmCompareConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgList)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bvList)).EndInit();
            this.bvList.ResumeLayout(false);
            this.bvList.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LIS.Common.Controls.CustomDatagridView dtgList;
        private System.Windows.Forms.Panel panel1;
        private TPH.Controls.TPHNormalButton btnClose;
        private TPH.Controls.TPHNormalButton btnOk;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colHis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLIS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLIS;
        private System.Windows.Forms.ComboBox cboLIS;
        private System.Windows.Forms.Label label1;
        private TPH.Controls.TPHNormalButton btnSetToRow;
    }
}