namespace TPH.LIS.App.AppCode
{
    partial class ucDanhMucDichVu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnNhomChiDinh = new DevExpress.XtraEditors.PanelControl();
            this.flpNhom = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnNhomChiDinh.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnNhomChiDinh
            // 
            this.pnNhomChiDinh.AutoScroll = true;
            this.pnNhomChiDinh.AutoSize = true;
            this.pnNhomChiDinh.Controls.Add(this.flpNhom);
            this.pnNhomChiDinh.Controls.Add(this.lblTitle);
            this.pnNhomChiDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnNhomChiDinh.Location = new System.Drawing.Point(0, 0);
            this.pnNhomChiDinh.MaximumSize = new System.Drawing.Size(0, 300);
            this.pnNhomChiDinh.Name = "pnNhomChiDinh";
            this.pnNhomChiDinh.Size = new System.Drawing.Size(529, 51);
            this.pnNhomChiDinh.TabIndex = 1;
            // 
            // flpNhom
            // 
            this.flpNhom.AutoSize = true;
            this.flpNhom.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpNhom.Location = new System.Drawing.Point(0, 22);
            this.flpNhom.Name = "flpNhom";
            this.flpNhom.Padding = new System.Windows.Forms.Padding(3);
            this.flpNhom.Size = new System.Drawing.Size(529, 6);
            this.flpNhom.TabIndex = 53;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(529, 22);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "Tên nhóm chỉ định";
            // 
            // ucDanhMucDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.pnNhomChiDinh);
            this.Name = "ucDanhMucDichVu";
            this.Size = new System.Drawing.Size(529, 51);
            this.pnNhomChiDinh.ResumeLayout(false);
            this.pnNhomChiDinh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnNhomChiDinh;
        private System.Windows.Forms.FlowLayoutPanel flpNhom;
        public DevExpress.XtraEditors.LabelControl lblTitle;
    }
}
