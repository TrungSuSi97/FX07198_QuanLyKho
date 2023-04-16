using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    partial class frmResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResetPassword));
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.cboUser = new TPH.LIS.Common.Controls.CustomComboBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new TPH.Controls.TPHNormalButton();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassReset = new System.Windows.Forms.TextBox();
            this.lblReset = new DevExpress.XtraEditors.LabelControl();
            this.btnReset = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).BeginInit();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).BeginInit();
            this.pnFormControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseBackColor = true;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 2);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(117, 23);
            this.lblTitle.Text = "ĐỔI MẬT KHẨU";
            // 
            // pnContaint
            // 
            this.pnContaint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContaint.Appearance.Options.UseBackColor = true;
            this.pnContaint.Controls.Add(this.btnReset);
            this.pnContaint.Controls.Add(this.txtPassReset);
            this.pnContaint.Controls.Add(this.lblReset);
            this.pnContaint.Controls.Add(this.txtNewPass);
            this.pnContaint.Controls.Add(this.label3);
            this.pnContaint.Controls.Add(this.txtOldPass);
            this.pnContaint.Controls.Add(this.btnSave);
            this.pnContaint.Controls.Add(this.label2);
            this.pnContaint.Controls.Add(this.cboUser);
            this.pnContaint.Controls.Add(this.lblUser);
            this.pnContaint.Location = new System.Drawing.Point(1, 28);
            this.pnContaint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnContaint.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnContaint.Size = new System.Drawing.Size(376, 184);
            // 
            // pnLabel
            // 
            this.pnLabel.Location = new System.Drawing.Point(1, 1);
            this.pnLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnLabel.Size = new System.Drawing.Size(376, 1);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnClose.Location = new System.Drawing.Point(347, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.TextColor = System.Drawing.Color.GhostWhite;
            // 
            // lblMainESC
            // 
            this.lblMainESC.Appearance.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainESC.Appearance.Options.UseFont = true;
            this.lblMainESC.Dock = System.Windows.Forms.DockStyle.None;
            this.lblMainESC.ImageOptions.Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lblMainESC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMainESC.ImageOptions.Image")));
            this.lblMainESC.Location = new System.Drawing.Point(249, 9);
            this.lblMainESC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnMenu.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnMenu.Appearance.Options.UseBackColor = true;
            this.pnMenu.Location = new System.Drawing.Point(1, 2);
            this.pnMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnMenu.Size = new System.Drawing.Size(376, 26);
            this.pnMenu.Visible = true;
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xtraScrollableControlMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(376, 25);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.ucGroupHeaderChonMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucGroupHeaderChonMain.GroupCaption = "THAY ĐỔI MẬT KHẨU";
            this.ucGroupHeaderChonMain.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(120, 2);
            this.ucGroupHeaderChonMain.Margin = new System.Windows.Forms.Padding(62, 27, 62, 27);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 23);
            this.ucGroupHeaderChonMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucGroupHeaderChonMain_MouseDown);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnFormControl.Appearance.Options.UseBackColor = true;
            this.pnFormControl.Location = new System.Drawing.Point(267, 2);
            this.pnFormControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnFormControl.Size = new System.Drawing.Size(106, 23);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Enabled = false;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnMinimize.Visible = false;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Enabled = false;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            this.btnMaximize.Visible = false;
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // lblUser
            // 
            this.lblUser.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Appearance.Options.UseFont = true;
            this.lblUser.Location = new System.Drawing.Point(12, 20);
            this.lblUser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(102, 16);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tên người dùng";
            this.lblUser.Visible = false;
            // 
            // cboUser
            // 
            this.cboUser.AutoComplete = false;
            this.cboUser.AutoDropdown = false;
            this.cboUser.BackColorEven = System.Drawing.Color.White;
            this.cboUser.BackColorOdd = System.Drawing.Color.LightBlue;
            this.cboUser.ColumnNames = "MaNguoiDung,TenNhanVien";
            this.cboUser.ColumnWidthDefault = 75;
            this.cboUser.ColumnWidths = "150,300";
            this.cboUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboUser.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.LinkedColumnIndex = 0;
            this.cboUser.LinkedColumnIndex1 = 0;
            this.cboUser.LinkedColumnIndex2 = 0;
            this.cboUser.LinkedTextBox = null;
            this.cboUser.LinkedTextBox1 = null;
            this.cboUser.LinkedTextBox2 = null;
            this.cboUser.Location = new System.Drawing.Point(157, 16);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(204, 24);
            this.cboUser.TabIndex = 1;
            this.cboUser.Visible = false;
            this.cboUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboUser_KeyPress);
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackColorHover = System.Drawing.Color.Empty;
            this.btnSave.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnSave.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(211, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 33);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Đổi mật khẩu";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextColor = System.Drawing.Color.Black;
            this.btnSave.UseHightLight = true;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.Location = new System.Drawing.Point(157, 48);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(204, 23);
            this.txtOldPass.TabIndex = 5;
            this.txtOldPass.UseSystemPasswordChar = true;
            this.txtOldPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOldPass_KeyPress);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(157, 80);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(204, 23);
            this.txtNewPass.TabIndex = 7;
            this.txtNewPass.UseSystemPasswordChar = true;
            this.txtNewPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewPass_KeyPress);
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txtPassReset
            // 
            this.txtPassReset.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassReset.Location = new System.Drawing.Point(157, 110);
            this.txtPassReset.Name = "txtPassReset";
            this.txtPassReset.Size = new System.Drawing.Size(204, 23);
            this.txtPassReset.TabIndex = 9;
            this.txtPassReset.UseSystemPasswordChar = true;
            this.txtPassReset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassReset_KeyPress);
            // 
            // lblReset
            // 
            this.lblReset.Appearance.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReset.Appearance.Options.UseFont = true;
            this.lblReset.Location = new System.Drawing.Point(12, 113);
            this.lblReset.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(113, 16);
            this.lblReset.TabIndex = 8;
            this.lblReset.Text = "Nhập lại mật khẩu";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.BackColorHover = System.Drawing.Color.Empty;
            this.btnReset.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnReset.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.BorderRadius = 5;
            this.btnReset.BorderSize = 1;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForceColorHover = System.Drawing.Color.Empty;
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(55, 148);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(148, 33);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Tạo mới mật khẩu";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextColor = System.Drawing.Color.Black;
            this.btnReset.UseHightLight = true;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmResetPassword
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(129)))), ((int)(((byte)(176)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(378, 213);
            this.FormSize = new System.Drawing.Size(394, 298);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResetPassword";
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmResetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnContaint)).EndInit();
            this.pnContaint.ResumeLayout(false);
            this.pnContaint.PerformLayout();
            this.pnLabel.ResumeLayout(false);
            this.pnLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnFormControl)).EndInit();
            this.pnFormControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomComboBox cboUser;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private TPH.Controls.TPHNormalButton btnSave;
        private DevExpress.XtraEditors.LabelControl label2;
        private System.Windows.Forms.TextBox txtPassReset;
        private DevExpress.XtraEditors.LabelControl lblReset;
        private System.Windows.Forms.TextBox txtNewPass;
        private DevExpress.XtraEditors.LabelControl label3;
        private System.Windows.Forms.TextBox txtOldPass;
        private TPH.Controls.TPHNormalButton btnReset;
    }
}