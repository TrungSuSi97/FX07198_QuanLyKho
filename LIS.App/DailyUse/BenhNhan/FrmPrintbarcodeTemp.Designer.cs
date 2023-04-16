namespace TPH.LIS.App.DailyUse.BenhNhan
{
    partial class FrmPrintbarcodeTemp
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
            this.txtSoLuongTem = new System.Windows.Forms.TextBox();
            this.btnInBarCode = new TPH.Controls.TPHNormalButton();
            this.btnClose = new TPH.Controls.TPHNormalButton();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaTiepNhan = new System.Windows.Forms.TextBox();
            this.txtMaLoaiMau = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(95, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng tem";
            // 
            // txtSoLuongTem
            // 
            this.txtSoLuongTem.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSoLuongTem.ForeColor = System.Drawing.Color.Maroon;
            this.txtSoLuongTem.Location = new System.Drawing.Point(80, 104);
            this.txtSoLuongTem.Name = "txtSoLuongTem";
            this.txtSoLuongTem.Size = new System.Drawing.Size(112, 21);
            this.txtSoLuongTem.TabIndex = 1;
            this.txtSoLuongTem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoLuongTem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuongTem_KeyPress);
            // 
            // btnInBarCode
            // 
            this.btnInBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInBarCode.BackColorHover = System.Drawing.Color.Empty;
            this.btnInBarCode.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnInBarCode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnInBarCode.BorderRadius = 5;
            this.btnInBarCode.BorderSize = 1;
            this.btnInBarCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBarCode.Font = new System.Drawing.Font("Arial", 9F);
            this.btnInBarCode.ForceColorHover = System.Drawing.Color.Empty;
            this.btnInBarCode.ForeColor = System.Drawing.Color.Black;
            this.btnInBarCode.Location = new System.Drawing.Point(80, 191);
            this.btnInBarCode.Name = "btnInBarCode";
            this.btnInBarCode.Size = new System.Drawing.Size(112, 55);
            this.btnInBarCode.TabIndex = 2;
            this.btnInBarCode.Text = "&In barcode";
            this.btnInBarCode.TextColor = System.Drawing.Color.Black;
            this.btnInBarCode.UseHightLight = true;
            this.btnInBarCode.UseVisualStyleBackColor = false;
            this.btnInBarCode.Click += new System.EventHandler(this.btnInBarCode_Click);
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
            this.btnClose.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClose.ForceColorHover = System.Drawing.Color.Empty;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(80, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đ&óng";
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.UseHightLight = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(93, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã xét nghiệm";
            // 
            // txtMaTiepNhan
            // 
            this.txtMaTiepNhan.Font = new System.Drawing.Font("Arial", 9F);
            this.txtMaTiepNhan.ForeColor = System.Drawing.Color.Maroon;
            this.txtMaTiepNhan.Location = new System.Drawing.Point(80, 33);
            this.txtMaTiepNhan.Name = "txtMaTiepNhan";
            this.txtMaTiepNhan.Size = new System.Drawing.Size(112, 21);
            this.txtMaTiepNhan.TabIndex = 5;
            this.txtMaTiepNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaTiepNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaTiepNhan_KeyPress);
            // 
            // txtMaLoaiMau
            // 
            this.txtMaLoaiMau.Font = new System.Drawing.Font("Arial", 9F);
            this.txtMaLoaiMau.ForeColor = System.Drawing.Color.Maroon;
            this.txtMaLoaiMau.Location = new System.Drawing.Point(80, 165);
            this.txtMaLoaiMau.Name = "txtMaLoaiMau";
            this.txtMaLoaiMau.Size = new System.Drawing.Size(112, 21);
            this.txtMaLoaiMau.TabIndex = 7;
            this.txtMaLoaiMau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaLoaiMau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaLoaiMau_KeyPress);
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(99, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã loại mẫu";
            // 
            // FrmPrintbarcodeTemp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(272, 291);
            this.Controls.Add(this.txtMaLoaiMau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaTiepNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInBarCode);
            this.Controls.Add(this.txtSoLuongTem);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrintbarcodeTemp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In tem";
            this.Load += new System.EventHandler(this.FrmPrintbarcodeTemp_Load);
            this.Shown += new System.EventHandler(this.FrmPrintbarcodeTemp_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private TPH.Controls.TPHNormalButton btnInBarCode;
        private TPH.Controls.TPHNormalButton btnClose;
        private DevExpress.XtraEditors.LabelControl label2;
        public System.Windows.Forms.TextBox txtSoLuongTem;
        public System.Windows.Forms.TextBox txtMaTiepNhan;
        public System.Windows.Forms.TextBox txtMaLoaiMau;
        private DevExpress.XtraEditors.LabelControl label3;
    }
}