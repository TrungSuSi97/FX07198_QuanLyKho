namespace TPH.Controls
{
    partial class HeaderWithCloseButton
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(145, 32);
            this.pnHeader.TabIndex = 0;
            // 
            // HeaderWithCloseButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnHeader);
            this.Name = "HeaderWithCloseButton";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Size = new System.Drawing.Size(148, 32);
            this.Click += new System.EventHandler(this.HeaderWithCloseButton_Click);
            this.MouseLeave += new System.EventHandler(this.HeaderWithCloseButton_MouseLeave);
            this.MouseHover += new System.EventHandler(this.HeaderWithCloseButton_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
    }
}
