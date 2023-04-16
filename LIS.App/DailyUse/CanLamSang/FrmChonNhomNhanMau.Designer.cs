using DevExpress.XtraEditors;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    partial class FrmChonNhomNhanMau
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
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.lblDaCHon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new DevExpress.XtraEditors.PanelControl();
            this.btnThucHien = new TPH.Controls.TPHNormalButton();
            this.ucDanhSachNhom1 = new TPH.LIS.Configuration.Controls.ucDanhSachNhom();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Controls.Add(this.lblDaCHon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 93);
            this.panel1.TabIndex = 0;
            // 
            // lblDaCHon
            // 
            this.lblDaCHon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDaCHon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDaCHon.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaCHon.Location = new System.Drawing.Point(0, 41);
            this.lblDaCHon.Name = "lblDaCHon";
            this.lblDaCHon.Size = new System.Drawing.Size(415, 52);
            this.lblDaCHon.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đã chọn";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(415, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHỌN NHÓM XÉT NGHIỆM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel2.Controls.Add(this.btnThucHien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 476);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 30);
            this.panel2.TabIndex = 2;
            // 
            // btnThucHien
            // 
            this.btnThucHien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThucHien.BackColorHover = System.Drawing.Color.Empty;
            this.btnThucHien.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnThucHien.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnThucHien.BorderRadius = 5;
            this.btnThucHien.BorderSize = 1;
            this.btnThucHien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThucHien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThucHien.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.ForceColorHover = System.Drawing.Color.Empty;
            this.btnThucHien.ForeColor = System.Drawing.Color.Black;
            this.btnThucHien.Image = global::TPH.LIS.App.Properties.Resources.Finish_16x16;
            this.btnThucHien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucHien.Location = new System.Drawing.Point(136, 1);
            this.btnThucHien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(143, 27);
            this.btnThucHien.TabIndex = 0;
            this.btnThucHien.Text = "Thực hiện (F2)";
            this.btnThucHien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThucHien.TextColor = System.Drawing.Color.Black;
            this.btnThucHien.UseHightLight = true;
            this.btnThucHien.UseVisualStyleBackColor = false;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // ucDanhSachNhom1
            // 
            this.ucDanhSachNhom1.AutoExpandAll = false;
            this.ucDanhSachNhom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDanhSachNhom1.Location = new System.Drawing.Point(0, 93);
            this.ucDanhSachNhom1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucDanhSachNhom1.Name = "ucDanhSachNhom1";
            this.ucDanhSachNhom1.Size = new System.Drawing.Size(415, 383);
            this.ucDanhSachNhom1.TabIndex = 3;
            // 
            // FrmChonNhomNhanMau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(252)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(415, 506);
            this.Controls.Add(this.ucDanhSachNhom1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChonNhomNhanMau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỌN NHÓM XÉT NGHIỆM";
            this.Load += new System.EventHandler(this.FrmChonNhomNhanMau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl panel1;
        private PanelControl panel2;
        private System.Windows.Forms.Label lblDaCHon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private TPH.Controls.TPHNormalButton btnThucHien;
        private Configuration.Controls.ucDanhSachNhom ucDanhSachNhom1;
    }
}