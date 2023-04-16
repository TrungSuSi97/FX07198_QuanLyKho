namespace TPH.LIS.Analyzer.Controls
{
    partial class ucAnalyzerAlarmList
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
            this.pnListContaint = new System.Windows.Forms.Panel();
            this.btnHide = new TPH.Controls.TPHNormalButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH CẢNH BÁO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnListContaint
            // 
            this.pnListContaint.AutoScroll = true;
            this.pnListContaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListContaint.Location = new System.Drawing.Point(0, 24);
            this.pnListContaint.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.pnListContaint.Name = "pnListContaint";
            this.pnListContaint.Padding = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.pnListContaint.Size = new System.Drawing.Size(292, 2);
            this.pnListContaint.TabIndex = 2;
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackColor = System.Drawing.SystemColors.Control;
            this.btnHide.BackColorHover = System.Drawing.Color.Empty;
            this.btnHide.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnHide.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHide.BorderRadius = 5;
            this.btnHide.BorderSize = 1;
            this.btnHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.ForceColorHover = System.Drawing.Color.Empty;
            this.btnHide.ForeColor = System.Drawing.Color.Maroon;
            this.btnHide.Location = new System.Drawing.Point(266, -1);
            this.btnHide.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(26, 23);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "X";
            this.btnHide.TextColor = System.Drawing.Color.Maroon;
            this.btnHide.UseHightLight = true;
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // ucAnalyzerAlarmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.pnListContaint);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0,0,0,0);
            this.Name = "ucAnalyzerAlarmList";
            this.Size = new System.Drawing.Size(292, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnListContaint;
        private TPH.Controls.TPHNormalButton btnHide;
    }
}
