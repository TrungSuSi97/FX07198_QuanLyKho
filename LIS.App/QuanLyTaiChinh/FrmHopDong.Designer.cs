namespace TPH.LIS.App.QuanLyTaiChinh
{
    partial class FrmHopDong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHopDong));
            this.tphTabControl1 = new TPH.Controls.TPHTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.tphTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(800, 25);
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.tphTabControl1);
            this.pnContaint.Size = new System.Drawing.Size(799, 425);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(800, 25);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(374, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(403, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1, 425);
            // 
            // tphTabControl1
            // 
            this.tphTabControl1.Controls.Add(this.tabPage1);
            this.tphTabControl1.Controls.Add(this.tabPage2);
            this.tphTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tphTabControl1.Location = new System.Drawing.Point(4, 4);
            this.tphTabControl1.Name = "tphTabControl1";
            this.tphTabControl1.SelectedIndex = 0;
            this.tphTabControl1.Size = new System.Drawing.Size(791, 417);
            this.tphTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tạo hộp đồng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(783, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh sách hợp đồng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrmHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FrmHopDong";
            this.Text = "TÊN FORM";
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.tphTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TPHTabControl tphTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}