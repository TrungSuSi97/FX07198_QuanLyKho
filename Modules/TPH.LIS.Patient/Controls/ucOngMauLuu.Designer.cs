namespace TPH.LIS.Patient.Controls
{
    partial class ucOngMauLuu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOngMauLuu));
            this.pnTubeBody = new System.Windows.Forms.Panel();
            this.lblSampleID = new System.Windows.Forms.Label();
            this.pnTubeColor = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnTubeBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTubeBody
            // 
            this.pnTubeBody.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnTubeBody.BackgroundImage")));
            this.pnTubeBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTubeBody.Controls.Add(this.lblSampleID);
            this.pnTubeBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTubeBody.Location = new System.Drawing.Point(0, 0);
            this.pnTubeBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnTubeBody.Name = "pnTubeBody";
            this.pnTubeBody.Padding = new System.Windows.Forms.Padding(2, 0, 2, 4);
            this.pnTubeBody.Size = new System.Drawing.Size(25, 39);
            this.pnTubeBody.TabIndex = 0;
            this.pnTubeBody.Visible = false;
            // 
            // lblSampleID
            // 
            this.lblSampleID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSampleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleID.Location = new System.Drawing.Point(2, 19);
            this.lblSampleID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSampleID.Name = "lblSampleID";
            this.lblSampleID.Size = new System.Drawing.Size(21, 16);
            this.lblSampleID.TabIndex = 0;
            this.lblSampleID.Text = "BL";
            this.lblSampleID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnTubeColor
            // 
            this.pnTubeColor.BackColor = System.Drawing.Color.White;
            this.pnTubeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTubeColor.ForeColor = System.Drawing.Color.Black;
            this.pnTubeColor.Location = new System.Drawing.Point(0, 0);
            this.pnTubeColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnTubeColor.Name = "pnTubeColor";
            this.pnTubeColor.Size = new System.Drawing.Size(25, 25);
            this.pnTubeColor.TabIndex = 1;
            this.pnTubeColor.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnTubeColor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnTubeBody);
            this.splitContainer1.Size = new System.Drawing.Size(25, 65);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // ucOngMauLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucOngMauLuu";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Size = new System.Drawing.Size(29, 69);
            this.pnTubeBody.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTubeBody;
        private System.Windows.Forms.Panel pnTubeColor;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblSampleID;
    }
}
