namespace TPH.LIS.App
{
    partial class FrmInputPasswordToReset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputPasswordToReset));
            this.btnOK = new TPH.Controls.TPHNormalButton();
            this.txtPassReset = new System.Windows.Forms.TextBox();
            this.lblReset = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new TPH.Controls.TPHNormalButton();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackColorHover = System.Drawing.Color.Empty;
            this.btnOK.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnOK.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOK.BorderRadius = 5;
            this.btnOK.BorderSize = 1;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForceColorHover = System.Drawing.Color.Empty;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(143, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.TextColor = System.Drawing.Color.Black;
            this.btnOK.UseHightLight = true;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtPassReset
            // 
            this.txtPassReset.Location = new System.Drawing.Point(153, 48);
            this.txtPassReset.Name = "txtPassReset";
            this.txtPassReset.Size = new System.Drawing.Size(172, 22);
            this.txtPassReset.TabIndex = 3;
            this.txtPassReset.UseSystemPasswordChar = true;
            // 
            // lblReset
            // 
            this.lblReset.AutoSize = true;
            this.lblReset.Location = new System.Drawing.Point(14, 51);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(112, 16);
            this.lblReset.TabIndex = 2;
            this.lblReset.Text = "Nhập lại mật khẩu";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(153, 14);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(172, 22);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackColorHover = System.Drawing.Color.Empty;
            this.btnCancel.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderSize = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(235, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.UseHightLight = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmInputPasswordToReset
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 117);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassReset);
            this.Controls.Add(this.lblReset);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputPasswordToReset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInputPasswordToReset_FormClosing);
            this.Load += new System.EventHandler(this.FrmInputPasswordToReset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TPH.Controls.TPHNormalButton btnOK;
        private System.Windows.Forms.TextBox txtPassReset;
        private DevExpress.XtraEditors.LabelControl lblReset;
        private System.Windows.Forms.TextBox txtNewPass;
        private DevExpress.XtraEditors.LabelControl label3;
        private TPH.Controls.TPHNormalButton btnCancel;
    }
}