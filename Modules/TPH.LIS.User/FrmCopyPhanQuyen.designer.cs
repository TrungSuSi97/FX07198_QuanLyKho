namespace TPH.LIS.User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCopyPhanQuyen));
            this.label1 = new System.Windows.Forms.Label();
            this.cboFromUser = new System.Windows.Forms.ComboBox();
            this.cboToUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopy = new TPH.Controls.TPHNormalButton();
            this.button1 = new TPH.Controls.TPHNormalButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tài khoản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboFromUser
            // 
            this.cboFromUser.Font = new System.Drawing.Font("Arial", 9F);
            this.cboFromUser.FormattingEnabled = true;
            this.cboFromUser.Location = new System.Drawing.Point(106, 12);
            this.cboFromUser.Name = "cboFromUser";
            this.cboFromUser.Size = new System.Drawing.Size(137, 23);
            this.cboFromUser.TabIndex = 1;
            // 
            // cboToUser
            // 
            this.cboToUser.Font = new System.Drawing.Font("Arial", 9F);
            this.cboToUser.FormattingEnabled = true;
            this.cboToUser.Location = new System.Drawing.Point(106, 51);
            this.cboToUser.Name = "cboToUser";
            this.cboToUser.Size = new System.Drawing.Size(137, 23);
            this.cboToUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến tài khoản";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(82, 111);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(87, 32);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Sao chép";
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.TextColor = System.Drawing.Color.Black;
            this.btnCopy.UseHightLight = true;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.button1.BackColorHover = System.Drawing.Color.Empty;
            this.button1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.button1.BorderRadius = 5;
            this.button1.BorderSize = 1;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForceColorHover = System.Drawing.Color.Empty;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(168, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "Đóng";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextColor = System.Drawing.Color.Black;
            this.button1.UseHightLight = true;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCopyPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(251, 152);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cboToUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFromUser);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCopyPhanQuyen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao chép phân quyền";
            this.Load += new System.EventHandler(this.FrmCopyPhanQuyen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFromUser;
        private System.Windows.Forms.ComboBox cboToUser;
        private System.Windows.Forms.Label label2;
        private TPH.Controls.TPHNormalButton btnCopy;
        private TPH.Controls.TPHNormalButton button1;
    }
}