namespace TPH.Controls
{
    partial class TPHTemplateForm
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
            this.pnTitleBar = new System.Windows.Forms.Panel();
            this.pnFormControl = new System.Windows.Forms.Panel();
            this.btnMinimize = new TPH.Controls.TPHIconButton();
            this.btnMaximize = new TPH.Controls.TPHIconButton();
            this.btnClose = new TPH.Controls.TPHIconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new TPH.Controls.TPHIconButton();
            this.pnContent = new System.Windows.Forms.Panel();
            this.pnTitleBar.SuspendLayout();
            this.pnFormControl.SuspendLayout();
            this.pnContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTitleBar
            // 
            this.pnTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(57)))), ((int)(((byte)(112)))));
            this.pnTitleBar.Controls.Add(this.pnFormControl);
            this.pnTitleBar.Controls.Add(this.lblTitleChildForm);
            this.pnTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.pnTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.pnTitleBar.Name = "pnTitleBar";
            this.pnTitleBar.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnTitleBar.Size = new System.Drawing.Size(1184, 26);
            this.pnTitleBar.TabIndex = 2;
            this.pnTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // pnFormControl
            // 
            this.pnFormControl.Controls.Add(this.btnMinimize);
            this.pnFormControl.Controls.Add(this.btnMaximize);
            this.pnFormControl.Controls.Add(this.btnClose);
            this.pnFormControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnFormControl.Location = new System.Drawing.Point(1078, 3);
            this.pnFormControl.Name = "pnFormControl";
            this.pnFormControl.Size = new System.Drawing.Size(106, 23);
            this.pnFormControl.TabIndex = 7;
            // 
            // btnMinimize
            // 
            this.btnMinimize._1_Size = new System.Drawing.Size(32, 20);
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(182)))), ((int)(((byte)(216)))));
            this.btnMinimize.ButtonBackColorStyle = TPH.Controls.ctrls.Solid;
            this.btnMinimize.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnMinimize.ButtonBorderSize = 0;
            this.btnMinimize.ButtonRadius = 0;
            this.btnMinimize.ButtonStyle = TPH.Controls.bd.IconButton;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(171)))), ((int)(((byte)(203)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(160)))), ((int)(((byte)(190)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMinimize.IconSize = 24;
            this.btnMinimize.Location = new System.Drawing.Point(5, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 20);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMinimize.UseHoverColor = true;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize._1_Size = new System.Drawing.Size(32, 20);
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(150)))), ((int)(((byte)(248)))));
            this.btnMaximize.ButtonBackColorStyle = TPH.Controls.ctrls.Solid;
            this.btnMaximize.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnMaximize.ButtonBorderSize = 0;
            this.btnMaximize.ButtonRadius = 0;
            this.btnMaximize.ButtonStyle = TPH.Controls.bd.IconButton;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(141)))), ((int)(((byte)(233)))));
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(132)))), ((int)(((byte)(218)))));
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.White;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMaximize.IconSize = 24;
            this.btnMaximize.Location = new System.Drawing.Point(39, 2);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(32, 20);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaximize.UseHoverColor = true;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose._1_Size = new System.Drawing.Size(29, 20);
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(93)))), ((int)(((byte)(133)))));
            this.btnClose.ButtonBackColorStyle = TPH.Controls.ctrls.Solid;
            this.btnClose.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnClose.ButtonBorderSize = 0;
            this.btnClose.ButtonRadius = 0;
            this.btnClose.ButtonStyle = TPH.Controls.bd.IconButton;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(87)))), ((int)(((byte)(125)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(81)))), ((int)(((byte)(117)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 24;
            this.btnClose.Location = new System.Drawing.Point(74, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 20);
            this.btnClose.TabIndex = 2;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseHoverColor = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.White;
            this.lblTitleChildForm.Location = new System.Drawing.Point(31, 3);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(1153, 23);
            this.lblTitleChildForm.TabIndex = 6;
            this.lblTitleChildForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleChildForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm._1_Size = new System.Drawing.Size(31, 23);
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.Transparent;
            this.iconCurrentChildForm.ButtonBackColorStyle = TPH.Controls.ctrls.Glass;
            this.iconCurrentChildForm.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.iconCurrentChildForm.ButtonBorderSize = 0;
            this.iconCurrentChildForm.ButtonRadius = 0;
            this.iconCurrentChildForm.ButtonStyle = TPH.Controls.bd.Metro;
            this.iconCurrentChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconCurrentChildForm.FlatAppearance.BorderSize = 0;
            this.iconCurrentChildForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.iconCurrentChildForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconCurrentChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconCurrentChildForm.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 35;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(0, 3);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(31, 23);
            this.iconCurrentChildForm.TabIndex = 5;
            this.iconCurrentChildForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconCurrentChildForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.iconCurrentChildForm.UseHoverColor = true;
            this.iconCurrentChildForm.UseVisualStyleBackColor = false;
            this.iconCurrentChildForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // pnContent
            // 
            this.pnContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.pnContent.Controls.Add(this.pnTitleBar);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(0, 0);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1184, 661);
            this.pnContent.TabIndex = 3;
            // 
            // TPHTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnContent);
            this.Name = "TPHTemplateForm";
            this.Text = "TPHTemplateForm";
            this.Load += new System.EventHandler(this.TPHTemplateForm_Load);
            this.Shown += new System.EventHandler(this.TPHTemplateForm_Shown);
            this.Resize += new System.EventHandler(this.FrnTemplateForm_Resize);
            this.pnTitleBar.ResumeLayout(false);
            this.pnFormControl.ResumeLayout(false);
            this.pnContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnFormControl;
        private TPHIconButton btnMinimize;
        private TPHIconButton btnMaximize;
        private TPHIconButton btnClose;
        public System.Windows.Forms.Panel pnContent;
        public System.Windows.Forms.Panel pnTitleBar;
        public TPHIconButton iconCurrentChildForm;
        public System.Windows.Forms.Label lblTitleChildForm;
    }
}