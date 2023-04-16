namespace TPH.LIS.Patient.Controls
{
    partial class ucThongTinTheoDoiMauTheoBarcode
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
            this.pnBarcode = new System.Windows.Forms.Panel();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.pnDSTheoDoi = new System.Windows.Forms.Panel();
            this.pnBarcode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBarcode
            // 
            this.pnBarcode.BackColor = System.Drawing.Color.AliceBlue;
            this.pnBarcode.Controls.Add(this.lblBarcode);
            this.pnBarcode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBarcode.ForeColor = System.Drawing.Color.Maroon;
            this.pnBarcode.Location = new System.Drawing.Point(0, 0);
            this.pnBarcode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnBarcode.Name = "pnBarcode";
            this.pnBarcode.Size = new System.Drawing.Size(1114, 27);
            this.pnBarcode.TabIndex = 0;
            // 
            // lblBarcode
            // 
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBarcode.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Location = new System.Drawing.Point(0, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(1114, 27);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "BARCODE";
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnDSTheoDoi
            // 
            this.pnDSTheoDoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDSTheoDoi.Location = new System.Drawing.Point(0, 27);
            this.pnDSTheoDoi.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnDSTheoDoi.Name = "pnDSTheoDoi";
            this.pnDSTheoDoi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnDSTheoDoi.Size = new System.Drawing.Size(1114, 0);
            this.pnDSTheoDoi.TabIndex = 1;
            // 
            // ucThongTinTheoDoiMauTheoBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnDSTheoDoi);
            this.Controls.Add(this.pnBarcode);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucThongTinTheoDoiMauTheoBarcode";
            this.Size = new System.Drawing.Size(1114, 27);
            this.pnBarcode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Panel pnDSTheoDoi;
    }
}
