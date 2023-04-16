namespace TPH.LabIMS.Updater
{
    partial class FrmDetailFileInPc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetailFileInPc));
            this.dtgChiTietFile = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietFile)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgChiTietFile
            // 
            this.dtgChiTietFile.AllowUserToAddRows = false;
            this.dtgChiTietFile.AllowUserToDeleteRows = false;
            this.dtgChiTietFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgChiTietFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChiTietFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgChiTietFile.Location = new System.Drawing.Point(0, 0);
            this.dtgChiTietFile.Name = "dtgChiTietFile";
            this.dtgChiTietFile.ReadOnly = true;
            this.dtgChiTietFile.Size = new System.Drawing.Size(719, 597);
            this.dtgChiTietFile.TabIndex = 0;
            // 
            // FrmDetailFileInPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(719, 597);
            this.Controls.Add(this.dtgChiTietFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmDetailFileInPc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHI TIẾT FILE TRÊN MÁY";
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgChiTietFile;
    }
}