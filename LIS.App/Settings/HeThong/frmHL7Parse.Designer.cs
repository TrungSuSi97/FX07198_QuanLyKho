namespace TPH.LIS.App.Settings.HeThong
{
    partial class frmHL7Parser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHL7Parser));
            this.ucHL7ToTable1 = new HL7Parser.ucHL7ToTable();
            this.SuspendLayout();
            // 
            // ucHL7ToTable1
            // 
            this.ucHL7ToTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHL7ToTable1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucHL7ToTable1.Location = new System.Drawing.Point(0, 0);
            this.ucHL7ToTable1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ucHL7ToTable1.Name = "ucHL7ToTable1";
            this.ucHL7ToTable1.Size = new System.Drawing.Size(800, 450);
            this.ucHL7ToTable1.TabIndex = 0;
            // 
            // frmHL7Parser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucHL7ToTable1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHL7Parser";
            this.Text = "HL7 Parser ";
            this.Load += new System.EventHandler(this.frmHL7Parser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HL7Parser.ucHL7ToTable ucHL7ToTable1;
    }
}