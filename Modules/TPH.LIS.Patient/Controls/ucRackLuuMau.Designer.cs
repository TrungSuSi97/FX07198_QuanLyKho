namespace TPH.LIS.Patient.Controls
{
    partial class ucRackLuuMau
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
            this.pnMaSoRack = new System.Windows.Forms.Panel();
            this.lblSoRack = new System.Windows.Forms.Label();
            this.flpOngMau = new System.Windows.Forms.FlowLayoutPanel();
            this.pnMaSoRack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMaSoRack
            // 
            this.pnMaSoRack.Controls.Add(this.lblSoRack);
            this.pnMaSoRack.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMaSoRack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnMaSoRack.Location = new System.Drawing.Point(0, 0);
            this.pnMaSoRack.Name = "pnMaSoRack";
            this.pnMaSoRack.Size = new System.Drawing.Size(936, 26);
            this.pnMaSoRack.TabIndex = 0;
            // 
            // lblSoRack
            // 
            this.lblSoRack.BackColor = System.Drawing.Color.DimGray;
            this.lblSoRack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoRack.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoRack.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSoRack.Location = new System.Drawing.Point(0, 0);
            this.lblSoRack.Name = "lblSoRack";
            this.lblSoRack.Size = new System.Drawing.Size(936, 26);
            this.lblSoRack.TabIndex = 0;
            this.lblSoRack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpOngMau
            // 
            this.flpOngMau.AutoScroll = true;
            this.flpOngMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOngMau.Location = new System.Drawing.Point(0, 26);
            this.flpOngMau.Name = "flpOngMau";
            this.flpOngMau.Size = new System.Drawing.Size(936, 625);
            this.flpOngMau.TabIndex = 1;
            // 
            // ucRackLuuMau
            // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.flpOngMau);
            this.Controls.Add(this.pnMaSoRack);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucRackLuuMau";
            this.Size = new System.Drawing.Size(936, 651);
            this.pnMaSoRack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMaSoRack;
        private System.Windows.Forms.Label lblSoRack;
        private System.Windows.Forms.FlowLayoutPanel flpOngMau;
    }
}
