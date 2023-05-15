namespace TPH.LIS.App
{
    partial class FrmNgonNguPhanMem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNgonNguPhanMem));
            this.ucCauHinhNgonNguUngDung1 = new TPH.Language.ucCauHinhNgonNguUngDung();
            this.pnContaint.SuspendLayout();
            this.pnLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(971, 25);
            this.lblTitle.Text = "NGÔN NGỮ";
            // 
            // pnContaint
            // 
            this.pnContaint.Controls.Add(this.ucCauHinhNgonNguUngDung1);
            this.pnContaint.Size = new System.Drawing.Size(970, 578);
            // 
            // pnLabel
            // 
            this.pnLabel.Size = new System.Drawing.Size(971, 25);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(545, 0);
            // 
            // lblMainESC
            // 
            this.lblMainESC.Location = new System.Drawing.Point(574, 0);
            // 
            // pnMenu
            // 
            this.pnMenu.Size = new System.Drawing.Size(1, 578);
            // 
            // ucCauHinhNgonNguUngDung1
            // 
            this.ucCauHinhNgonNguUngDung1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCauHinhNgonNguUngDung1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucCauHinhNgonNguUngDung1.Location = new System.Drawing.Point(4, 4);
            this.ucCauHinhNgonNguUngDung1.Name = "ucCauHinhNgonNguUngDung1";
            this.ucCauHinhNgonNguUngDung1.Size = new System.Drawing.Size(962, 570);
            this.ucCauHinhNgonNguUngDung1.TabIndex = 0;
            // 
            // FrmNgonNguPhanMem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 603);
            this.Name = "FrmNgonNguPhanMem";
            this.Text = "QUẢN LÝ DANH MỤC NGÔN NGỮ";
            this.Load += new System.EventHandler(this.FrmNgonNguPhanMem_Load);
            this.pnContaint.ResumeLayout(false);
            this.pnLabel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Language.ucCauHinhNgonNguUngDung ucCauHinhNgonNguUngDung1;
    }
}