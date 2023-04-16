namespace TPH.LIS.BarcodePrinting
{
    partial class UcFontFormat
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.chkItalic = new System.Windows.Forms.CheckBox();
            this.nudLeftIndent = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRightIndent = new System.Windows.Forms.NumericUpDown();
            this.cboAlign = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkHideLabel = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numMergeRows = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTruongDuLieu = new System.Windows.Forms.TextBox();
            this.chkDongKhung = new System.Windows.Forms.CheckBox();
            this.cboXoay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMergeRows)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cỡ chữ";
            // 
            // nudFontSize
            // 
            this.nudFontSize.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudFontSize.Location = new System.Drawing.Point(50, 3);
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(35, 20);
            this.nudFontSize.TabIndex = 1;
            this.nudFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFontSize.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBold.Location = new System.Drawing.Point(206, 32);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(51, 18);
            this.chkBold.TabIndex = 2;
            this.chkBold.Text = "Đậm";
            this.chkBold.UseVisualStyleBackColor = true;
            this.chkBold.CheckedChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // chkItalic
            // 
            this.chkItalic.AutoSize = true;
            this.chkItalic.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItalic.Location = new System.Drawing.Point(289, 32);
            this.chkItalic.Name = "chkItalic";
            this.chkItalic.Size = new System.Drawing.Size(67, 18);
            this.chkItalic.TabIndex = 3;
            this.chkItalic.Text = "Nghiêng";
            this.chkItalic.UseVisualStyleBackColor = true;
            this.chkItalic.CheckedChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // nudLeftIndent
            // 
            this.nudLeftIndent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLeftIndent.Location = new System.Drawing.Point(271, 3);
            this.nudLeftIndent.Name = "nudLeftIndent";
            this.nudLeftIndent.Size = new System.Drawing.Size(40, 20);
            this.nudLeftIndent.TabIndex = 4;
            this.nudLeftIndent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLeftIndent.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Lề trái (mm)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(315, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lề phải (mm)";
            // 
            // nudRightIndent
            // 
            this.nudRightIndent.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRightIndent.Location = new System.Drawing.Point(388, 3);
            this.nudRightIndent.Name = "nudRightIndent";
            this.nudRightIndent.Size = new System.Drawing.Size(40, 20);
            this.nudRightIndent.TabIndex = 6;
            this.nudRightIndent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRightIndent.ValueChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // cboAlign
            // 
            this.cboAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlign.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAlign.FormattingEnabled = true;
            this.cboAlign.Location = new System.Drawing.Point(136, 2);
            this.cboAlign.Name = "cboAlign";
            this.cboAlign.Size = new System.Drawing.Size(63, 22);
            this.cboAlign.TabIndex = 8;
            this.cboAlign.SelectedIndexChanged += new System.EventHandler(this.cboAlign_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(89, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Canh lề";
            // 
            // chkHideLabel
            // 
            this.chkHideLabel.AutoSize = true;
            this.chkHideLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHideLabel.Location = new System.Drawing.Point(388, 32);
            this.chkHideLabel.Name = "chkHideLabel";
            this.chkHideLabel.Size = new System.Drawing.Size(40, 18);
            this.chkHideLabel.TabIndex = 10;
            this.chkHideLabel.Text = "Ẩn";
            this.chkHideLabel.UseVisualStyleBackColor = true;
            this.chkHideLabel.CheckedChanged += new System.EventHandler(this.ItemValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(432, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Rộng";
            // 
            // numWidth
            // 
            this.numWidth.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(464, 29);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(40, 20);
            this.numWidth.TabIndex = 13;
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(432, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cao";
            // 
            // numHeight
            // 
            this.numHeight.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeight.Location = new System.Drawing.Point(464, 3);
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(40, 20);
            this.numHeight.TabIndex = 11;
            this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nối dòng";
            // 
            // numMergeRows
            // 
            this.numMergeRows.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMergeRows.Location = new System.Drawing.Point(55, 29);
            this.numMergeRows.Name = "numMergeRows";
            this.numMergeRows.Size = new System.Drawing.Size(29, 20);
            this.numMergeRows.TabIndex = 15;
            this.numMergeRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(89, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "Xoay (độ)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "Trường dữ liệu:";
            // 
            // txtTruongDuLieu
            // 
            this.txtTruongDuLieu.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTruongDuLieu.Location = new System.Drawing.Point(89, 53);
            this.txtTruongDuLieu.Name = "txtTruongDuLieu";
            this.txtTruongDuLieu.Size = new System.Drawing.Size(295, 20);
            this.txtTruongDuLieu.TabIndex = 20;
            // 
            // chkDongKhung
            // 
            this.chkDongKhung.AutoSize = true;
            this.chkDongKhung.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDongKhung.Location = new System.Drawing.Point(388, 55);
            this.chkDongKhung.Name = "chkDongKhung";
            this.chkDongKhung.Size = new System.Drawing.Size(93, 18);
            this.chkDongKhung.TabIndex = 21;
            this.chkDongKhung.Text = "Đóng khung";
            this.chkDongKhung.UseVisualStyleBackColor = true;
            // 
            // cboXoay
            // 
            this.cboXoay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXoay.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboXoay.FormattingEnabled = true;
            this.cboXoay.Items.AddRange(new object[] {
            "0",
            "90",
            "-90"});
            this.cboXoay.Location = new System.Drawing.Point(150, 28);
            this.cboXoay.Name = "cboXoay";
            this.cboXoay.Size = new System.Drawing.Size(49, 22);
            this.cboXoay.TabIndex = 22;
            // 
            // UcFontFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cboXoay);
            this.Controls.Add(this.chkDongKhung);
            this.Controls.Add(this.txtTruongDuLieu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numMergeRows);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.chkHideLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboAlign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudRightIndent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudLeftIndent);
            this.Controls.Add(this.chkItalic);
            this.Controls.Add(this.chkBold);
            this.Controls.Add(this.nudFontSize);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcFontFormat";
            this.Size = new System.Drawing.Size(511, 80);
            this.Load += new System.EventHandler(this.UcFontFormat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMergeRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.CheckBox chkItalic;
        private System.Windows.Forms.NumericUpDown nudLeftIndent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRightIndent;
        private System.Windows.Forms.ComboBox cboAlign;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkHideLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMergeRows;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTruongDuLieu;
        private System.Windows.Forms.CheckBox chkDongKhung;
        private System.Windows.Forms.ComboBox cboXoay;
    }
}
