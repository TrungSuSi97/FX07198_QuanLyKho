using TPH.Controls;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    partial class FrmTuLuuMau
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
            this.tabControl1 = new TPH.Controls.TPHTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucDanhMucTuLuuMau1 = new TPH.LIS.Configuration.Controls.ucDanhMucTuLuuMau();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucDanhMucKhayLuuMau1 = new TPH.LIS.Configuration.Controls.ucDanhMucKhayLuuMau();
            this.btnTuLuu = new TPH.Controls.TPHNormalButton();
            this.btnKhayMau = new TPH.Controls.TPHNormalButton();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.pnMenu.SuspendLayout();
            this.xtraScrollableControlMain.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(263, 22);
            this.lblTitle.Text = "TỦ LƯU MẪU VÀ KHAY LƯU MẪU";
            this.lblTitle.Visible = false;
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.tabControl1);
            this.pnContaint.Location = new System.Drawing.Point(0, 92);
            this.pnContaint.Size = new System.Drawing.Size(800, 358);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(800, 25);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Location = new System.Drawing.Point(374, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(403, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Location = new System.Drawing.Point(0, 25);
            this.pnMenu.Size = new System.Drawing.Size(800, 67);
            this.pnMenu.Visible = true;
            // 
            // xtraScrollableControlMain
            // 
            this.xtraScrollableControlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.xtraScrollableControlMain.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControlMain.Controls.Add(this.btnTuLuu);
            this.xtraScrollableControlMain.Controls.Add(this.btnKhayMau);
            this.xtraScrollableControlMain.Size = new System.Drawing.Size(800, 66);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.lblTitle, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.ucGroupHeaderChonMain, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.pnFormControl, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.btnKhayMau, 0);
            this.xtraScrollableControlMain.Controls.SetChildIndex(this.btnTuLuu, 0);
            // 
            // ucGroupHeaderChonMain
            // 
            this.ucGroupHeaderChonMain.Location = new System.Drawing.Point(265, 1);
            this.ucGroupHeaderChonMain.Size = new System.Drawing.Size(10, 65);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Location = new System.Drawing.Point(692, 1);
            this.pnFormControl.Size = new System.Drawing.Size(106, 65);
            this.pnFormControl.Visible = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            // 
            // btnMaximize
            // 
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            // 
            // tphIconButton1
            // 
            this.tphIconButton1.FlatAppearance.BorderSize = 0;
            this.tphIconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.tphIconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 354);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucDanhMucTuLuuMau1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tủ lưu mẫu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucDanhMucTuLuuMau1
            // 
            this.ucDanhMucTuLuuMau1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDanhMucTuLuuMau1.Location = new System.Drawing.Point(3, 3);
            this.ucDanhMucTuLuuMau1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucDanhMucTuLuuMau1.Name = "ucDanhMucTuLuuMau1";
            this.ucDanhMucTuLuuMau1.Size = new System.Drawing.Size(782, 322);
            this.ucDanhMucTuLuuMau1.TabIndex = 0;
            this.ucDanhMucTuLuuMau1.BuutonThemMoiClick += new System.EventHandler(this.ucDanhMucTuLuuMau1_BuutonThemMoiClick);
            this.ucDanhMucTuLuuMau1.BuutonXoaClick += new System.EventHandler(this.ucDanhMucTuLuuMau1_BuutonXoaClick);
            this.ucDanhMucTuLuuMau1.LuoiChinhSua += new System.EventHandler(this.ucDanhMucTuLuuMau1_LuoiChinhSua);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucDanhMucKhayLuuMau1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(788, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Khay đựng mẫu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucDanhMucKhayLuuMau1
            // 
            this.ucDanhMucKhayLuuMau1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDanhMucKhayLuuMau1.Location = new System.Drawing.Point(3, 3);
            this.ucDanhMucKhayLuuMau1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.ucDanhMucKhayLuuMau1.Name = "ucDanhMucKhayLuuMau1";
            this.ucDanhMucKhayLuuMau1.Size = new System.Drawing.Size(782, 322);
            this.ucDanhMucKhayLuuMau1.TabIndex = 0;
            // 
            // btnTuLuu
            // 
            this.btnTuLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnTuLuu.BackColorHover = System.Drawing.Color.Empty;
            this.btnTuLuu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnTuLuu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnTuLuu.BorderRadius = 0;
            this.btnTuLuu.BorderSize = 1;
            this.btnTuLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTuLuu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnTuLuu.ForceColorHover = System.Drawing.Color.Black;
            this.btnTuLuu.ForeColor = System.Drawing.Color.Black;
            this.btnTuLuu.Location = new System.Drawing.Point(3, 4);
            this.btnTuLuu.Name = "btnTuLuu";
            this.btnTuLuu.Size = new System.Drawing.Size(89, 57);
            this.btnTuLuu.TabIndex = 381;
            this.btnTuLuu.Text = "TỬ LƯU";
            this.btnTuLuu.TextColor = System.Drawing.Color.Black;
            this.btnTuLuu.UseHightLight = false;
            this.btnTuLuu.UseVisualStyleBackColor = false;
            this.btnTuLuu.Click += new System.EventHandler(this.btnTuLuu_Click);
            // 
            // btnKhayMau
            // 
            this.btnKhayMau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnKhayMau.BackColorHover = System.Drawing.Color.Empty;
            this.btnKhayMau.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnKhayMau.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnKhayMau.BorderRadius = 0;
            this.btnKhayMau.BorderSize = 1;
            this.btnKhayMau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhayMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhayMau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnKhayMau.ForceColorHover = System.Drawing.Color.Black;
            this.btnKhayMau.ForeColor = System.Drawing.Color.Black;
            this.btnKhayMau.Location = new System.Drawing.Point(98, 4);
            this.btnKhayMau.Name = "btnKhayMau";
            this.btnKhayMau.Size = new System.Drawing.Size(89, 57);
            this.btnKhayMau.TabIndex = 380;
            this.btnKhayMau.Text = "KHAY MẪU";
            this.btnKhayMau.TextColor = System.Drawing.Color.Black;
            this.btnKhayMau.UseHightLight = false;
            this.btnKhayMau.UseVisualStyleBackColor = false;
            this.btnKhayMau.Click += new System.EventHandler(this.btnKhayMau_Click);
            // 
            // FrmTuLuuMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmTuLuuMau";
            this.Text = "FrmTuLuuMau";
            this.Load += new System.EventHandler(this.FrmTuLuuMau_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.pnMenu.ResumeLayout(false);
            this.xtraScrollableControlMain.ResumeLayout(false);
            this.xtraScrollableControlMain.PerformLayout();
            this.pnFormControl.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TPHTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Configuration.Controls.ucDanhMucTuLuuMau ucDanhMucTuLuuMau1;
        private Controls.TPHNormalButton btnTuLuu;
        private Controls.TPHNormalButton btnKhayMau;
        private Configuration.Controls.ucDanhMucKhayLuuMau ucDanhMucKhayLuuMau1;
    }
}