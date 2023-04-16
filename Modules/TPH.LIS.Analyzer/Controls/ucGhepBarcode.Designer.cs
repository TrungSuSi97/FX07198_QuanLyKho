namespace TPH.LIS.Analyzer.Controls
{
    partial class ucGhepBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucGhepBarcode));
            this.pnFillter = new System.Windows.Forms.Panel();
            this.ucAnalyzer = new TPH.LIS.Common.Controls.ucCheckListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new TPH.Controls.TPHNormalButton();
            this.pnDSMay = new System.Windows.Forms.Panel();
            this.pnFillter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnFillter
            // 
            this.pnFillter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFillter.Controls.Add(this.ucAnalyzer);
            this.pnFillter.Controls.Add(this.panel1);
            this.pnFillter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnFillter.Location = new System.Drawing.Point(3, 2);
            this.pnFillter.Name = "pnFillter";
            this.pnFillter.Size = new System.Drawing.Size(218, 731);
            this.pnFillter.TabIndex = 0;
            // 
            // ucAnalyzer
            // 
            this.ucAnalyzer.DataSource = null;
            this.ucAnalyzer.DisplayMember = "";
            this.ucAnalyzer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAnalyzer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucAnalyzer.IsCheckedAll = true;
            this.ucAnalyzer.ListCaption = "Danh sách máy xét nghiệm";
            this.ucAnalyzer.Location = new System.Drawing.Point(0, 50);
            this.ucAnalyzer.Name = "ucAnalyzer";
            this.ucAnalyzer.Size = new System.Drawing.Size(216, 679);
            this.ucAnalyzer.TabIndex = 0;
            this.ucAnalyzer.ValueMember = "";
            this.ucAnalyzer.ListSelectedIndexChanged += new System.EventHandler(this.ucAnalyzer_ListSelectedIndexChanged);
            this.ucAnalyzer.CheckboAllCheckedChanged += new System.EventHandler(this.ucAnalyzer_CheckboAllCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 50);
            this.panel1.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnRefresh.BackColorHover = System.Drawing.Color.Empty;
            this.btnRefresh.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnRefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.BorderSize = 1;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForceColorHover = System.Drawing.Color.Empty;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(56, 5);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 35);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.UseHightLight = true;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnDSMay
            // 
            this.pnDSMay.AutoScroll = true;
            this.pnDSMay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDSMay.Location = new System.Drawing.Point(221, 2);
            this.pnDSMay.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnDSMay.Name = "pnDSMay";
            this.pnDSMay.Size = new System.Drawing.Size(773, 731);
            this.pnDSMay.TabIndex = 1;
            // 
            // ucGhepBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnDSMay);
            this.Controls.Add(this.pnFillter);
            this.Name = "ucGhepBarcode";
            this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Size = new System.Drawing.Size(997, 735);
            this.pnFillter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Controls.ucCheckListBox ucAnalyzer;
        private System.Windows.Forms.Panel pnFillter;
        private System.Windows.Forms.Panel pnDSMay;
        private TPH.Controls.TPHNormalButton btnRefresh;
        private System.Windows.Forms.Panel panel1;
    }
}
