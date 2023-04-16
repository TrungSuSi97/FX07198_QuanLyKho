namespace TPH.LIS.App.DailyUse.BenhNhan
{
    partial class FrmChonKhoa
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
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.cboKhoaXetNghiem = new System.Windows.Forms.ComboBox();
            this.btnOk = new TPH.Controls.TPHNormalButton();
            this.btnClose = new TPH.Controls.TPHNormalButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseBackColor = true;
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHỌN KHOA XÉT NGHIỆM";
            // 
            // cboKhoaXetNghiem
            // 
            this.cboKhoaXetNghiem.FormattingEnabled = true;
            this.cboKhoaXetNghiem.Location = new System.Drawing.Point(48, 38);
            this.cboKhoaXetNghiem.Name = "cboKhoaXetNghiem";
            this.cboKhoaXetNghiem.Size = new System.Drawing.Size(233, 21);
            this.cboKhoaXetNghiem.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnOk.BackColorHover = System.Drawing.Color.Empty;
            this.btnOk.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnOk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnOk.BorderRadius = 5;
            this.btnOk.BorderSize = 1;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForceColorHover = System.Drawing.Color.Empty;
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Image = global::TPH.LIS.App.Properties.Resources.Check_Green_16x16;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(75, 68);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.TextColor = System.Drawing.Color.Black;
            this.btnOk.UseHightLight = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnClose.BackColorHover = System.Drawing.Color.Empty;
            this.btnClose.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnClose.BorderRadius = 5;
            this.btnClose.BorderSize = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForceColorHover = System.Drawing.Color.Empty;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::TPH.LIS.App.Properties.Resources.close_circle_16x161;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(173, 69);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmChonKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(328, 99);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cboKhoaXetNghiem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmChonKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khoa xét nghiệm";
            this.Load += new System.EventHandler(this.FrmChonKhoa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.ComboBox cboKhoaXetNghiem;
        private TPH.Controls.TPHNormalButton btnOk;
        private TPH.Controls.TPHNormalButton btnClose;
    }
}