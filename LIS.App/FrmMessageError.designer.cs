namespace TPH.LIS.App
{
    partial class FrmMessageError
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageError));
            this.lblMsg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnOK = new TPH.LIS.Common.Controls.CustomButton();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.btnDetail = new TPH.LIS.Common.Controls.CustomButton();
            this.btnIgnore = new TPH.LIS.Common.Controls.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(8, 5);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(443, 109);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "label1";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.Location = new System.Drawing.Point(4, 149);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(452, 209);
            this.txtDetail.TabIndex = 4;
            this.txtDetail.Visible = false;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.Font = new System.Drawing.Font("Tahoma", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Black;
            this.lblWarning.Location = new System.Drawing.Point(189, 359);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(271, 18);
            this.lblWarning.TabIndex = 7;
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(384, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 29);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Thoát ";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.BackgroundImage")));
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.Location = new System.Drawing.Point(20, 35);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(48, 45);
            this.pbIcon.TabIndex = 9;
            this.pbIcon.TabStop = false;
            this.pbIcon.Visible = false;
            // 
            // btnDetail
            // 
            this.btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.Color.Black;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetail.Location = new System.Drawing.Point(4, 117);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(74, 29);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIgnore.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnore.ForeColor = System.Drawing.Color.Black;
            this.btnIgnore.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnore.Image")));
            this.btnIgnore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIgnore.Location = new System.Drawing.Point(309, 117);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(73, 29);
            this.btnIgnore.TabIndex = 8;
            this.btnIgnore.Text = "Bỏ qua";
            this.btnIgnore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMessageError
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(460, 380);
            this.ControlBox = false;
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.lblMsg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageError";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMessageError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private TPH.LIS.Common.Controls.CustomButton btnOK;
        private System.Windows.Forms.Timer timer1;
        private TPH.LIS.Common.Controls.CustomButton btnDetail;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label lblWarning;
        private TPH.LIS.Common.Controls.CustomButton btnIgnore;
        private System.Windows.Forms.PictureBox pbIcon;
    }
}