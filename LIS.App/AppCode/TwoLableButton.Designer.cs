namespace ClinicManagementSystem.AppCode
{
    partial class TwoLableButton
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwoLableButton));
            this.lblButtonText = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lblButtonText
            // 
            this.lblButtonText.BackColor = System.Drawing.Color.Transparent;
            this.lblButtonText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblButtonText.Font = new System.Drawing.Font("Roboto Condensed", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButtonText.ForeColor = System.Drawing.Color.Black;
            this.lblButtonText.Location = new System.Drawing.Point(0, 0);
            this.lblButtonText.Name = "lblButtonText";
            this.lblButtonText.Size = new System.Drawing.Size(214, 33);
            this.lblButtonText.TabIndex = 0;
            this.lblButtonText.Text = "ButtonTitle";
            this.lblButtonText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescription.Font = new System.Drawing.Font("Roboto Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDescription.Location = new System.Drawing.Point(0, 33);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(214, 17);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            this.pnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnLeft.BackgroundImage")));
            this.pnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnLeft.Location = new System.Drawing.Point(214, 0);
            this.pnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(27, 50);
            this.pnLeft.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BuutonImage256x45.png");
            this.imageList1.Images.SetKeyName(1, "BuutonImage256x45_H.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "RightArrow3N.png");
            this.imageList2.Images.SetKeyName(1, "RightArrow3H.png");
            // 
            // TwoLableButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblButtonText);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pnLeft);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto Condensed", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TwoLableButton";
            this.Size = new System.Drawing.Size(241, 50);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TwoLableButton_Paint);
            this.Enter += new System.EventHandler(this.TwoLableButton_Enter);
            this.Leave += new System.EventHandler(this.TwoLableButton_Leave);
            this.MouseEnter += new System.EventHandler(this.TwoLableButton_Enter);
            this.MouseLeave += new System.EventHandler(this.TwoLableButton_Leave);
            this.MouseHover += new System.EventHandler(this.TwoLableButton_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        public System.Windows.Forms.Label lblButtonText;
        public System.Windows.Forms.Label lblDescription;
    }
}
