namespace TPH.LIS.Common.Controls
{
    partial class TextBoxWithdate
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
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.txtValue = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // dtpNgay
            // 
            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpNgay.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(86, 0);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(20, 23);
            this.dtpNgay.TabIndex = 1;
            this.dtpNgay.CloseUp += new System.EventHandler(this.dtpNgay_CloseUp);
            this.dtpNgay.Enter += new System.EventHandler(this.dtpNgay_Enter);
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.txtValue.Mask = "00/00/0000";
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(86, 20);
            this.txtValue.TabIndex = 0;
            this.txtValue.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.txtValue.ValidatingType = typeof(System.DateTime);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // TextBoxWithdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.dtpNgay);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "TextBoxWithdate";
            this.Size = new System.Drawing.Size(106, 24);
            this.Enter += new System.EventHandler(this.TextBoxWithdate_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.MaskedTextBox txtValue;
    }
}
