namespace TPH.LabIMS.Updater
{
    partial class FrmDownloadUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDownloadUpdate));
            this.lblFileStatus = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblThuMuc = new System.Windows.Forms.Label();
            this.lblFolderStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDownload = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileStatus
            // 
            this.lblFileStatus.AutoSize = true;
            this.lblFileStatus.Location = new System.Drawing.Point(224, 55);
            this.lblFileStatus.Name = "lblFileStatus";
            this.lblFileStatus.Size = new System.Drawing.Size(0, 13);
            this.lblFileStatus.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(96, 55);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(96, 13);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "File đang cập nhật";
            this.lblFile.Visible = false;
            // 
            // lblThuMuc
            // 
            this.lblThuMuc.AutoSize = true;
            this.lblThuMuc.Location = new System.Drawing.Point(96, 31);
            this.lblThuMuc.Name = "lblThuMuc";
            this.lblThuMuc.Size = new System.Drawing.Size(122, 13);
            this.lblThuMuc.TabIndex = 3;
            this.lblThuMuc.Text = "Thư mục đang cập nhật";
            this.lblThuMuc.Visible = false;
            // 
            // lblFolderStatus
            // 
            this.lblFolderStatus.AutoSize = true;
            this.lblFolderStatus.Location = new System.Drawing.Point(224, 31);
            this.lblFolderStatus.Name = "lblFolderStatus";
            this.lblFolderStatus.Size = new System.Drawing.Size(0, 13);
            this.lblFolderStatus.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TPH.LabIMS.Updater.Properties.Resources.update2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Image = global::TPH.LabIMS.Updater.Properties.Resources.down_24x24;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(12, 87);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(103, 35);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Thực hiện";
            this.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Visible = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // FrmDownloadUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(532, 118);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFolderStatus);
            this.Controls.Add(this.lblThuMuc);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblFileStatus);
            this.Controls.Add(this.btnDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDownloadUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tải về các update";
            this.Load += new System.EventHandler(this.FrmDownloadUpdate_Load);
            this.Shown += new System.EventHandler(this.FrmDownloadUpdate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TPH.Controls.TPHNormalButton btnDownload;
        private System.Windows.Forms.Label lblFileStatus;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblThuMuc;
        private System.Windows.Forms.Label lblFolderStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}