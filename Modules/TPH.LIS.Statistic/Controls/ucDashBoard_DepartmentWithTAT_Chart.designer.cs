namespace TPH.LIS.Statistic.Controls
{
    partial class ucDashBoard_DepartmentWithTAT_Chart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashBoard_DepartmentWithTAT_Chart));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            this.timerReLoad = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new TPH.Controls.TPHNormalButton();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucDashBoard_TAT1 = new TPH.LIS.Statistic.Controls.ucDashBoard_TAT();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucDashBoard_Department_Chart1 = new TPH.LIS.Statistic.Controls.ucDashBoard_Department_Chart();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(133)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1300, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1157, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Copyright © 2017 TPH Solutions All Rights Reserved.";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = false;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(130, 17);
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            // 
            // timerReLoad
            // 
            this.timerReLoad.Interval = 120000;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(83)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cboKhuVuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 28);
            this.panel1.TabIndex = 24;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRefresh.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefresh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnRefresh.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.BorderSize = 1;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1248, 0);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.TextColor = System.Drawing.Color.Black;
            this.btnRefresh.UseHightLight = true;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKhuVuc.BackColor = System.Drawing.Color.Gray;
            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(334, 2);
            this.cboKhuVuc.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(906, 26);
            this.cboKhuVuc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH TAT CỦA KHU VỰC:";
            // 
            // ucDashBoard_TAT1
            // 
            this.ucDashBoard_TAT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDashBoard_TAT1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDashBoard_TAT1.Location = new System.Drawing.Point(0, 0);
            this.ucDashBoard_TAT1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDashBoard_TAT1.Name = "ucDashBoard_TAT1";
            this.ucDashBoard_TAT1.Size = new System.Drawing.Size(864, 672);
            this.ucDashBoard_TAT1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucDashBoard_Department_Chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucDashBoard_TAT1);
            this.splitContainer1.Size = new System.Drawing.Size(1300, 672);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 25;
            // 
            // ucDashBoard_Department_Chart1
            // 
            this.ucDashBoard_Department_Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDashBoard_Department_Chart1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDashBoard_Department_Chart1.LeftMode = true;
            this.ucDashBoard_Department_Chart1.Location = new System.Drawing.Point(0, 0);
            this.ucDashBoard_Department_Chart1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucDashBoard_Department_Chart1.Name = "ucDashBoard_Department_Chart1";
            this.ucDashBoard_Department_Chart1.Size = new System.Drawing.Size(433, 672);
            this.ucDashBoard_Department_Chart1.TabIndex = 0;
            this.ucDashBoard_Department_Chart1.TenBoPhan = "TỔNG HỢP SỐ LƯỢNG";
            // 
            // ucDashBoard_DepartmentWithTAT_Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucDashBoard_DepartmentWithTAT_Chart";
            this.Size = new System.Drawing.Size(1300, 700);
            this.Load += new System.EventHandler(this.ucDashBoard_DepartmentWithTAT_Chart_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ucDashBoard_TAT ucDashBoard_TAT1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTimer;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.Timer timerReLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.Label label1;
        private TPH.Controls.TPHNormalButton btnRefresh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucDashBoard_Department_Chart ucDashBoard_Department_Chart1;
    }
}
