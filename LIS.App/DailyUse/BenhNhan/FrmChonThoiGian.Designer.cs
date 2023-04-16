namespace TPH.LIS.App.DailyUse.BenhNhan
{
    partial class FrmChonThoiGian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChonThoiGian));
            this.dtpTG = new System.Windows.Forms.DateTimePicker();
            this.btnDongY = new TPH.Controls.TPHNormalButton();
            this.btnHuy = new TPH.Controls.TPHNormalButton();
            this.SuspendLayout();
            // 
            // dtpTG
            // 
            this.dtpTG.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpTG.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTG.Location = new System.Drawing.Point(47, 11);
            this.dtpTG.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpTG.Name = "dtpTG";
            this.dtpTG.Size = new System.Drawing.Size(235, 29);
            this.dtpTG.TabIndex = 0;
            // 
            // btnDongY
            // 
            this.btnDongY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDongY.BackColorHover = System.Drawing.Color.Empty;
            this.btnDongY.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnDongY.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnDongY.BorderRadius = 5;
            this.btnDongY.BorderSize = 1;
            this.btnDongY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDongY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongY.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongY.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDongY.ForeColor = System.Drawing.Color.Black;
            this.btnDongY.Image = global::TPH.LIS.App.Properties.Resources.Check_Green_16x16;
            this.btnDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDongY.Location = new System.Drawing.Point(75, 48);
            this.btnDongY.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(85, 34);
            this.btnDongY.TabIndex = 1;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDongY.TextColor = System.Drawing.Color.Black;
            this.btnDongY.UseHightLight = true;
            this.btnDongY.UseVisualStyleBackColor = false;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuy.BackColorHover = System.Drawing.Color.Empty;
            this.btnHuy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnHuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.BorderSize = 1;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.Image = global::TPH.LIS.App.Properties.Resources.cancel_16x16;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(168, 48);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 34);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextColor = System.Drawing.Color.Black;
            this.btnHuy.UseHightLight = true;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FrmChonThoiGian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(328, 93);
            this.ControlBox = false;
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.dtpTG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "FrmChonThoiGian";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn thời gian";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTG;
        private TPH.Controls.TPHNormalButton btnDongY;
        private TPH.Controls.TPHNormalButton btnHuy;
    }
}