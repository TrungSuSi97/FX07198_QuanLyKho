namespace TPH.LIS.Common.Controls.Chart
{
    partial class CustomChart
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
            this.pbChart = new System.Windows.Forms.PictureBox();
            this.lblLabelMain = new System.Windows.Forms.Label();
            this.lblLabelSub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pbChart
            // 
            this.pbChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbChart.Location = new System.Drawing.Point(0, 70);
            this.pbChart.Name = "pbChart";
            this.pbChart.Size = new System.Drawing.Size(663, 399);
            this.pbChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbChart.TabIndex = 0;
            this.pbChart.TabStop = false;
            // 
            // lblLabelMain
            // 
            this.lblLabelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLabelMain.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelMain.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLabelMain.Location = new System.Drawing.Point(0, 0);
            this.lblLabelMain.Name = "lblLabelMain";
            this.lblLabelMain.Size = new System.Drawing.Size(663, 35);
            this.lblLabelMain.TabIndex = 1;
            this.lblLabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLabelMain.Visible = false;
            // 
            // lblLabelSub
            // 
            this.lblLabelSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLabelSub.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelSub.Location = new System.Drawing.Point(0, 35);
            this.lblLabelSub.Name = "lblLabelSub";
            this.lblLabelSub.Size = new System.Drawing.Size(663, 35);
            this.lblLabelSub.TabIndex = 3;
            this.lblLabelSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLabelSub.Visible = false;
            // 
            // CustomChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pbChart);
            this.Controls.Add(this.lblLabelSub);
            this.Controls.Add(this.lblLabelMain);
            this.Name = "CustomChart";
            this.Size = new System.Drawing.Size(663, 469);
            ((System.ComponentModel.ISupportInitialize)(this.pbChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbChart;
        private System.Windows.Forms.Label lblLabelMain;
        private System.Windows.Forms.Label lblLabelSub;
    }
}
