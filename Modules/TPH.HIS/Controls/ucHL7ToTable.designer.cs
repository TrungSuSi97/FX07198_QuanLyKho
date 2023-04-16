namespace HL7Parser
{
    partial class ucHL7ToTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHL7ToTable));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtHL7Message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConvertResultHL7 = new System.Windows.Forms.Button();
            this.btnClearSource = new System.Windows.Forms.Button();
            this.btnHL7ToDataTable = new System.Windows.Forms.Button();
            this.dtgData = new System.Windows.Forms.DataGridView();
            this.bvData = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXuatXML = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvData)).BeginInit();
            this.bvData.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtHL7Message);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtgData);
            this.splitContainer1.Panel2.Controls.Add(this.bvData);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1350, 661);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtHL7Message
            // 
            this.txtHL7Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHL7Message.Location = new System.Drawing.Point(81, 0);
            this.txtHL7Message.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHL7Message.Multiline = true;
            this.txtHL7Message.Name = "txtHL7Message";
            this.txtHL7Message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHL7Message.Size = new System.Drawing.Size(1173, 262);
            this.txtHL7Message.TabIndex = 1;
            this.txtHL7Message.Text = resources.GetString("txtHL7Message.Text");
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 262);
            this.label1.TabIndex = 2;
            this.label1.Text = "SOURCE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConvertResultHL7);
            this.panel1.Controls.Add(this.btnClearSource);
            this.panel1.Controls.Add(this.btnHL7ToDataTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1254, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 262);
            this.panel1.TabIndex = 0;
            // 
            // btnConvertResultHL7
            // 
            this.btnConvertResultHL7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertResultHL7.Location = new System.Drawing.Point(4, 90);
            this.btnConvertResultHL7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConvertResultHL7.Name = "btnConvertResultHL7";
            this.btnConvertResultHL7.Size = new System.Drawing.Size(89, 82);
            this.btnConvertResultHL7.TabIndex = 3;
            this.btnConvertResultHL7.Text = "Convert Data HL7 Result";
            this.btnConvertResultHL7.UseVisualStyleBackColor = true;
            this.btnConvertResultHL7.Click += new System.EventHandler(this.btnConvertResultHL7_Click);
            // 
            // btnClearSource
            // 
            this.btnClearSource.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSource.Location = new System.Drawing.Point(5, 179);
            this.btnClearSource.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClearSource.Name = "btnClearSource";
            this.btnClearSource.Size = new System.Drawing.Size(89, 82);
            this.btnClearSource.TabIndex = 2;
            this.btnClearSource.Text = "Clear source";
            this.btnClearSource.UseVisualStyleBackColor = true;
            this.btnClearSource.Click += new System.EventHandler(this.btnClearSource_Click);
            // 
            // btnHL7ToDataTable
            // 
            this.btnHL7ToDataTable.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHL7ToDataTable.Location = new System.Drawing.Point(4, 3);
            this.btnHL7ToDataTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHL7ToDataTable.Name = "btnHL7ToDataTable";
            this.btnHL7ToDataTable.Size = new System.Drawing.Size(89, 82);
            this.btnHL7ToDataTable.TabIndex = 0;
            this.btnHL7ToDataTable.Text = "Convert Data HL7 Order";
            this.btnHL7ToDataTable.UseVisualStyleBackColor = true;
            this.btnHL7ToDataTable.Click += new System.EventHandler(this.btnHL7ToDataTable_Click);
            // 
            // dtgData
            // 
            this.dtgData.AllowUserToAddRows = false;
            this.dtgData.AllowUserToDeleteRows = false;
            this.dtgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgData.Location = new System.Drawing.Point(81, 25);
            this.dtgData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtgData.Name = "dtgData";
            this.dtgData.Size = new System.Drawing.Size(1269, 369);
            this.dtgData.TabIndex = 0;
            // 
            // bvData
            // 
            this.bvData.AddNewItem = null;
            this.bvData.CountItem = this.bindingNavigatorCountItem;
            this.bvData.DeleteItem = null;
            this.bvData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnXuatXML});
            this.bvData.Location = new System.Drawing.Point(81, 0);
            this.bvData.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bvData.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bvData.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bvData.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bvData.Name = "bvData";
            this.bvData.PositionItem = this.bindingNavigatorPositionItem;
            this.bvData.Size = new System.Drawing.Size(1269, 25);
            this.bvData.TabIndex = 1;
            this.bvData.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            // btnXuatXML
            // 
            this.btnXuatXML.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatXML.Image")));
            this.btnXuatXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXuatXML.Name = "btnXuatXML";
            this.btnXuatXML.Size = new System.Drawing.Size(78, 22);
            this.btnXuatXML.Text = "Xuất XML";
            this.btnXuatXML.Click += new System.EventHandler(this.btnXuatXML_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 394);
            this.label2.TabIndex = 3;
            this.label2.Text = "RESULT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucHL7ToTable
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ucHL7ToTable";
            this.Size = new System.Drawing.Size(1350, 661);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bvData)).EndInit();
            this.bvData.ResumeLayout(false);
            this.bvData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtHL7Message;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHL7ToDataTable;
        private System.Windows.Forms.DataGridView dtgData;
        private System.Windows.Forms.Button btnClearSource;
        private System.Windows.Forms.BindingNavigator bvData;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnXuatXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvertResultHL7;
    }
}

