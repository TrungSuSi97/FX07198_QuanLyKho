namespace TPH.LIS.Common.Controls
{
    partial class ucPrinterForReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPrinterForReport));
            this.cboPrinterName = new System.Windows.Forms.ComboBox();
            this.cboPaperSize = new System.Windows.Forms.ComboBox();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.btnSave = new TPH.Controls.TPHNormalButton();
            this.btnDelete = new TPH.Controls.TPHNormalButton();
            this.customLable2 = new TPH.LIS.Common.Controls.CustomLable();
            this.customLable3 = new TPH.LIS.Common.Controls.CustomLable();
            this.customLable1 = new TPH.LIS.Common.Controls.CustomLable();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboPrinterName
            // 
            this.cboPrinterName.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboPrinterName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrinterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrinterName.FormattingEnabled = true;
            this.cboPrinterName.Location = new System.Drawing.Point(61, 0);
            this.cboPrinterName.Name = "cboPrinterName";
            this.cboPrinterName.Size = new System.Drawing.Size(231, 24);
            this.cboPrinterName.TabIndex = 1;
            this.cboPrinterName.SelectedIndexChanged += new System.EventHandler(this.cboPrinterName_SelectedIndexChanged);
            // 
            // cboPaperSize
            // 
            this.cboPaperSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaperSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaperSize.FormattingEnabled = true;
            this.cboPaperSize.Location = new System.Drawing.Point(674, 0);
            this.cboPaperSize.Name = "cboPaperSize";
            this.cboPaperSize.Size = new System.Drawing.Size(141, 24);
            this.cboPaperSize.TabIndex = 3;
            this.cboPaperSize.SelectedIndexChanged += new System.EventHandler(this.cboPaperSize_SelectedIndexChanged);
            // 
            // cboReportType
            // 
            this.cboReportType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.DropDownWidth = 300;
            this.cboReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Location = new System.Drawing.Point(347, 0);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(265, 24);
            this.cboReportType.TabIndex = 5;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.BackColorHover = System.Drawing.Color.Empty;
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderSize = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForceColorHover = System.Drawing.Color.Empty;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(815, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(35, 26);
            this.btnSave.TabIndex = 6;
            this.btnSave.TextColor = System.Drawing.Color.Black;
            this.btnSave.UseHightLight = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.BackColorHover = System.Drawing.Color.Empty;
            this.btnDelete.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(217)))), ((int)(((byte)(214)))));
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.BorderSize = 1;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(780, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(35, 26);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.TextColor = System.Drawing.Color.Black;
            this.btnDelete.UseHightLight = true;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // customLable2
            // 
            this.customLable2.BackColor = System.Drawing.SystemColors.Control;
            this.customLable2.BindFieldName = null;
            this.customLable2.Color = System.Drawing.Color.Black;
            this.customLable2.Dock = System.Windows.Forms.DockStyle.Left;
            this.customLable2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLable2.ForeColorClicked = System.Drawing.Color.White;
            this.customLable2.GetControl = null;
            this.customLable2.Location = new System.Drawing.Point(612, 0);
            this.customLable2.Name = "customLable2";
            this.customLable2.OldValue = null;
            this.customLable2.ShadowDepth = 3;
            this.customLable2.Size = new System.Drawing.Size(62, 26);
            this.customLable2.Softness = 1.5F;
            this.customLable2.TabIndex = 2;
            this.customLable2.Text = "Khổ giấy";
            this.customLable2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customLable2.UseShadow = false;
            this.customLable2.UseZoom = false;
            // 
            // customLable3
            // 
            this.customLable3.BackColor = System.Drawing.SystemColors.Control;
            this.customLable3.BindFieldName = null;
            this.customLable3.Color = System.Drawing.Color.Black;
            this.customLable3.Dock = System.Windows.Forms.DockStyle.Left;
            this.customLable3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLable3.ForeColorClicked = System.Drawing.Color.White;
            this.customLable3.GetControl = null;
            this.customLable3.Location = new System.Drawing.Point(292, 0);
            this.customLable3.Name = "customLable3";
            this.customLable3.OldValue = null;
            this.customLable3.ShadowDepth = 3;
            this.customLable3.Size = new System.Drawing.Size(55, 26);
            this.customLable3.Softness = 1.5F;
            this.customLable3.TabIndex = 4;
            this.customLable3.Text = "Phiếu in";
            this.customLable3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customLable3.UseShadow = false;
            this.customLable3.UseZoom = false;
            // 
            // customLable1
            // 
            this.customLable1.BackColor = System.Drawing.SystemColors.Control;
            this.customLable1.BindFieldName = null;
            this.customLable1.Color = System.Drawing.Color.Black;
            this.customLable1.Dock = System.Windows.Forms.DockStyle.Left;
            this.customLable1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLable1.ForeColorClicked = System.Drawing.Color.White;
            this.customLable1.GetControl = null;
            this.customLable1.Location = new System.Drawing.Point(17, 0);
            this.customLable1.Name = "customLable1";
            this.customLable1.OldValue = null;
            this.customLable1.ShadowDepth = 3;
            this.customLable1.Size = new System.Drawing.Size(44, 26);
            this.customLable1.Softness = 1.5F;
            this.customLable1.TabIndex = 0;
            this.customLable1.Text = "Máy in";
            this.customLable1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customLable1.UseShadow = false;
            this.customLable1.UseZoom = false;
            // 
            // lblCount
            // 
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Black;
            this.lblCount.Location = new System.Drawing.Point(0, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(17, 26);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "1";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucPrinterForReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboPaperSize);
            this.Controls.Add(this.customLable2);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.customLable3);
            this.Controls.Add(this.cboPrinterName);
            this.Controls.Add(this.customLable1);
            this.Controls.Add(this.lblCount);
            this.Name = "ucPrinterForReport";
            this.Size = new System.Drawing.Size(850, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomLable customLable1;
        private System.Windows.Forms.ComboBox cboPrinterName;
        private System.Windows.Forms.ComboBox cboPaperSize;
        private CustomLable customLable2;
        private System.Windows.Forms.ComboBox cboReportType;
        private CustomLable customLable3;
        private TPH.Controls.TPHNormalButton btnSave;
        private TPH.Controls.TPHNormalButton btnDelete;
        private System.Windows.Forms.Label lblCount;
    }
}
