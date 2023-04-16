namespace TPH.LIS.App.Settings.NhanVien
{
    partial class FrmCopyPhanQuyen
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
            this.cboFromUser = new System.Windows.Forms.ComboBox();
            this.cboToUser = new System.Windows.Forms.ComboBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCopy = new TPH.Controls.TPHNormalButton();
            this.button1 = new TPH.Controls.TPHNormalButton();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tài khoản";
            // 
            // cboFromUser
            // 
            this.cboFromUser.Font = new System.Drawing.Font("Arial", 9F);
            this.cboFromUser.FormattingEnabled = true;
            this.cboFromUser.Location = new System.Drawing.Point(98, 50);
            this.cboFromUser.Name = "cboFromUser";
            this.cboFromUser.Size = new System.Drawing.Size(121, 23);
            this.cboFromUser.TabIndex = 1;
            // 
            // cboToUser
            // 
            this.cboToUser.Font = new System.Drawing.Font("Arial", 9F);
            this.cboToUser.FormattingEnabled = true;
            this.cboToUser.Location = new System.Drawing.Point(98, 89);
            this.cboToUser.Name = "cboToUser";
            this.cboToUser.Size = new System.Drawing.Size(121, 23);
            this.cboToUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến tài khoản";
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnCopy.BackColorHover = System.Drawing.Color.Empty;
            this.btnCopy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnCopy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnCopy.BorderRadius = 5;
            this.btnCopy.BorderSize = 1;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCopy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCopy.ForeColor = System.Drawing.Color.Black;
            this.btnCopy.Location = new System.Drawing.Point(85, 152);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 31);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Sao chép";
            this.btnCopy.TextColor = System.Drawing.Color.Black;
            this.btnCopy.UseHightLight = true;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.button1.BackColorHover = System.Drawing.Color.Empty;
            this.button1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.button1.BorderRadius = 5;
            this.button1.BorderSize = 1;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForceColorHover = System.Drawing.Color.Empty;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(15, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Đóng";
            this.button1.TextColor = System.Drawing.Color.Black;
            this.button1.UseHightLight = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "SAO CHÉP PHÂN QUYỀN";
            this.label3.Visible = false;
            // 
            // FrmCopyPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(255, 195);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cboToUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFromUser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCopyPhanQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao chép phân quyền";
            this.Load += new System.EventHandler(this.FrmCopyPhanQuyen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.ComboBox cboFromUser;
        private System.Windows.Forms.ComboBox cboToUser;
        private DevExpress.XtraEditors.LabelControl label2;
        private TPH.Controls.TPHNormalButton btnCopy;
        private TPH.Controls.TPHNormalButton button1;
        private DevExpress.XtraEditors.LabelControl label3;
    }
}