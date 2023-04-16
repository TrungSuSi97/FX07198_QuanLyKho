namespace TPH.Controls
{
    partial class TesForm
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
            this.tphPanel1 = new TPH.Controls.TPHPanel();
            this.button1 = new TPH.Controls.TPHNormalButton();
            this.tphPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tphPanel1
            // 
            this.tphPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tphPanel1.BackColorOpacity = 100;
            this.tphPanel1.BackImage = null;
            this.tphPanel1.BackImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.tphPanel1.BorderRadius = 10;
            this.tphPanel1.BottomColor = System.Drawing.Color.Empty;
            this.tphPanel1.Controls.Add(this.button1);
            this.tphPanel1.Customizable = true;
            this.tphPanel1.GradientDegree = 90F;
            this.tphPanel1.Location = new System.Drawing.Point(362, 79);
            this.tphPanel1.Name = "tphPanel1";
            this.tphPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.tphPanel1.Size = new System.Drawing.Size(451, 159);
            this.tphPanel1.TabIndex = 0;
            this.tphPanel1.TopColor = System.Drawing.Color.Empty;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(376, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 144);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1114, 539);
            this.Controls.Add(this.tphPanel1);
            this.Name = "TesForm";
            this.Text = "TesForm";
            this.tphPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TPHPanel tphPanel1;
        private TPH.Controls.TPHNormalButton button1;
    }
}