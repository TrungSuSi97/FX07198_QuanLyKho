namespace TPH.LIS.App.DailyUse.BenhNhan
{
    partial class FrmTechUpdate
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
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.ucTechUpdate1 = new TPH.LIS.Patient.Controls.ucTechUpdate();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỖ TRỢ CẬP NHẬT DỮ LIỆU";
            // 
            // ucTechUpdate1
            // 
            this.ucTechUpdate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTechUpdate1.Location = new System.Drawing.Point(0, 22);
            this.ucTechUpdate1.Name = "ucTechUpdate1";
            this.ucTechUpdate1.Size = new System.Drawing.Size(366, 222);
            this.ucTechUpdate1.TabIndex = 1;
            // 
            // FrmTechUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(366, 244);
            this.Controls.Add(this.ucTechUpdate1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTechUpdate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỖ TRỢ CẬP NHẬT DỮ LIỆU";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private Patient.Controls.ucTechUpdate ucTechUpdate1;
    }
}