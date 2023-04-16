namespace LabSoftProfessional
{
    partial class FrmExportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExportExcel));
            this.lblMsg = new System.Windows.Forms.Label();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.lblDoing = new System.Windows.Forms.Label();
            this.lblList = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblStepWorking = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(11, 25);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(399, 73);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Xuất dữ liệu qua excel.\r\n        Vui lòng chờ !";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proBar
            // 
            this.proBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proBar.Location = new System.Drawing.Point(16, 152);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(387, 23);
            this.proBar.TabIndex = 3;
            // 
            // lblDoing
            // 
            this.lblDoing.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDoing.AutoSize = true;
            this.lblDoing.BackColor = System.Drawing.Color.Transparent;
            this.lblDoing.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoing.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDoing.Location = new System.Drawing.Point(3, 118);
            this.lblDoing.Name = "lblDoing";
            this.lblDoing.Size = new System.Drawing.Size(72, 16);
            this.lblDoing.TabIndex = 4;
            this.lblDoing.Text = "Tiến trình:";
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.BackColor = System.Drawing.Color.Transparent;
            this.lblList.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblList.ForeColor = System.Drawing.Color.White;
            this.lblList.Location = new System.Drawing.Point(19, 44);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(77, 22);
            this.lblList.TabIndex = 9;
            this.lblList.Text = "Message";
            this.lblList.Visible = false;
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ForeColor = System.Drawing.Color.Sienna;
            this.lblPercent.Location = new System.Drawing.Point(14, 134);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(67, 14);
            this.lblPercent.TabIndex = 10;
            this.lblPercent.Text = "100 %";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStepWorking
            // 
            this.lblStepWorking.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblStepWorking.BackColor = System.Drawing.Color.Transparent;
            this.lblStepWorking.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepWorking.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStepWorking.Location = new System.Drawing.Point(81, 118);
            this.lblStepWorking.Name = "lblStepWorking";
            this.lblStepWorking.Size = new System.Drawing.Size(326, 32);
            this.lblStepWorking.TabIndex = 11;
            this.lblStepWorking.Text = "step";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblTime.Location = new System.Drawing.Point(238, 177);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(162, 13);
            this.lblTime.TabIndex = 12;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(420, 194);
            this.ControlBox = false;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblStepWorking);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblDoing);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.proBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExportExcel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LABCONN DMS - XUAT EXCEL";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmExportExcel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar proBar;
        public System.Windows.Forms.Label lblDoing;
        public System.Windows.Forms.Label lblList;
        public System.Windows.Forms.Label lblMsg;
        public System.Windows.Forms.Label lblStepWorking;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lblPercent;
    }
}