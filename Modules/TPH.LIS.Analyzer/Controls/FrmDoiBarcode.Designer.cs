namespace TPH.LIS.Analyzer.Controls
{
    partial class FrmDoiBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoiBarcode));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label13 = new System.Windows.Forms.Label();
            this.txtFromBarcode = new System.Windows.Forms.TextBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.txtToBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChange = new TPH.Controls.TPHNormalButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(231, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.label13);
            this.groupControl1.Controls.Add(this.txtFromBarcode);
            this.groupControl1.Controls.Add(this.dtpFromDate);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(4, 10);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(222, 89);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "ĐỔI TỪ BARCODE";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 16);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ngày xét nghiệm";
            // 
            // txtFromBarcode
            // 
            this.txtFromBarcode.Location = new System.Drawing.Point(120, 55);
            this.txtFromBarcode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtFromBarcode.Name = "txtFromBarcode";
            this.txtFromBarcode.Size = new System.Drawing.Size(97, 23);
            this.txtFromBarcode.TabIndex = 7;
            this.txtFromBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromBarcode_KeyPress);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(120, 27);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(97, 23);
            this.dtpFromDate.TabIndex = 4;
            this.dtpFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFromDate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Barcode";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Arial", 10F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.dtpToDate);
            this.groupControl2.Controls.Add(this.txtToBarcode);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Location = new System.Drawing.Point(337, 10);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(225, 89);
            this.groupControl2.TabIndex = 18;
            this.groupControl2.Text = "THÀNH BARCODE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày xét nghiệm";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(127, 30);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(93, 23);
            this.dtpToDate.TabIndex = 4;
            this.dtpToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpToDate_KeyPress);
            // 
            // txtToBarcode
            // 
            this.txtToBarcode.Location = new System.Drawing.Point(127, 61);
            this.txtToBarcode.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtToBarcode.Name = "txtToBarcode";
            this.txtToBarcode.Size = new System.Drawing.Size(93, 23);
            this.txtToBarcode.TabIndex = 7;
            this.txtToBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToBarcode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Barcode";
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnChange.BackColorHover = System.Drawing.Color.Empty;
            this.btnChange.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.btnChange.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnChange.BorderRadius = 5;
            this.btnChange.BorderSize = 1;
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForceColorHover = System.Drawing.Color.Empty;
            this.btnChange.ForeColor = System.Drawing.Color.Black;
            this.btnChange.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.Image")));
            this.btnChange.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChange.Location = new System.Drawing.Point(231, 105);
            this.btnChange.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 54);
            this.btnChange.TabIndex = 16;
            this.btnChange.Text = "Thực hiện";
            this.btnChange.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChange.TextColor = System.Drawing.Color.Black;
            this.btnChange.UseHightLight = true;
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // FrmDoiBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(570, 168);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "FrmDoiBarcode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Barcode";
            this.Load += new System.EventHandler(this.FrmDoiBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtFromBarcode;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.TextBox txtToBarcode;
        private System.Windows.Forms.Label label3;
        private TPH.Controls.TPHNormalButton btnChange;
    }
}