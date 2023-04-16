namespace TPH.LIS.Common.Controls
{
    partial class FrmMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageBox));
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.pnNormalButton = new System.Windows.Forms.Panel();
            this.btnCopy = new TPH.Controls.TPHNormalButton();
            this.pnYes = new System.Windows.Forms.Panel();
            this.btnYes = new TPH.Controls.TPHNormalButton();
            this.pnNo = new System.Windows.Forms.Panel();
            this.btnNo = new TPH.Controls.TPHNormalButton();
            this.pnCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new TPH.Controls.TPHNormalButton();
            this.pnMessContent = new System.Windows.Forms.Panel();
            this.lblMsgContent = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.pnErrorButton = new System.Windows.Forms.Panel();
            this.btnCopyDetail = new TPH.Controls.TPHNormalButton();
            this.btnIgnore = new TPH.Controls.TPHNormalButton();
            this.btnDetail = new TPH.Controls.TPHNormalButton();
            this.pnContent.SuspendLayout();
            this.pnTitleBar.SuspendLayout();
            this.pnNormalButton.SuspendLayout();
            this.pnYes.SuspendLayout();
            this.pnNo.SuspendLayout();
            this.pnCancel.SuspendLayout();
            this.pnMessContent.SuspendLayout();
            this.pnErrorButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnContent
            // 
            this.pnContent.AutoSize = true;
            this.pnContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnContent.Controls.Add(this.txtDetail);
            this.pnContent.Controls.Add(this.pnErrorButton);
            this.pnContent.Controls.Add(this.pnNormalButton);
            this.pnContent.Controls.Add(this.pnMessContent);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnContent.Location = new System.Drawing.Point(3, 3);
            this.pnContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnContent.Size = new System.Drawing.Size(398, 382);
            this.pnContent.Controls.SetChildIndex(this.pnTitleBar, 0);
            this.pnContent.Controls.SetChildIndex(this.pnMessContent, 0);
            this.pnContent.Controls.SetChildIndex(this.pnNormalButton, 0);
            this.pnContent.Controls.SetChildIndex(this.pnErrorButton, 0);
            this.pnContent.Controls.SetChildIndex(this.txtDetail, 0);
            // 
            // pnTitleBar
            // 
            this.pnTitleBar.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnTitleBar.Size = new System.Drawing.Size(398, 33);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm._1_Size = new System.Drawing.Size(31, 29);
            this.iconCurrentChildForm.FlatAppearance.BorderSize = 0;
            this.iconCurrentChildForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.iconCurrentChildForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconCurrentChildForm.IconSize = 30;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(0, 4);
            this.iconCurrentChildForm.Margin = new System.Windows.Forms.Padding(4);
            this.iconCurrentChildForm.Size = new System.Drawing.Size(31, 29);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.Location = new System.Drawing.Point(31, 4);
            this.lblTitleChildForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleChildForm.Size = new System.Drawing.Size(367, 29);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "asterisk.png");
            this.imageList1.Images.SetKeyName(1, "Error.png");
            this.imageList1.Images.SetKeyName(2, "Exclamation.png");
            this.imageList1.Images.SetKeyName(3, "Hand.png");
            this.imageList1.Images.SetKeyName(4, "Information.png");
            this.imageList1.Images.SetKeyName(5, "Question.png");
            this.imageList1.Images.SetKeyName(6, "Stop.png");
            this.imageList1.Images.SetKeyName(7, "Warning.png");
            this.imageList1.Images.SetKeyName(8, "loading.gif");
            // 
            // pnNormalButton
            // 
            this.pnNormalButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnNormalButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnNormalButton.Controls.Add(this.btnCopy);
            this.pnNormalButton.Controls.Add(this.pnYes);
            this.pnNormalButton.Controls.Add(this.pnNo);
            this.pnNormalButton.Controls.Add(this.pnCancel);
            this.pnNormalButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNormalButton.Location = new System.Drawing.Point(0, 164);
            this.pnNormalButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnNormalButton.Name = "pnNormalButton";
            this.pnNormalButton.Padding = new System.Windows.Forms.Padding(1);
            this.pnNormalButton.Size = new System.Drawing.Size(398, 37);
            this.pnNormalButton.TabIndex = 1;
            this.pnNormalButton.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnCopy.BackColorHover = System.Drawing.Color.Empty;
            this.btnCopy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnCopy.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCopy.BorderRadius = 0;
            this.btnCopy.BorderSize = 0;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCopy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(1, 1);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(31, 35);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopy.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnCopy.UseHightLight = true;
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // pnYes
            // 
            this.pnYes.Controls.Add(this.btnYes);
            this.pnYes.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnYes.Location = new System.Drawing.Point(143, 1);
            this.pnYes.Margin = new System.Windows.Forms.Padding(0);
            this.pnYes.Name = "pnYes";
            this.pnYes.Size = new System.Drawing.Size(85, 35);
            this.pnYes.TabIndex = 5;
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(158)))), ((int)(((byte)(52)))));
            this.btnYes.BackColorHover = System.Drawing.Color.Empty;
            this.btnYes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(158)))), ((int)(((byte)(52)))));
            this.btnYes.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYes.BorderRadius = 0;
            this.btnYes.BorderSize = 0;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnYes.FlatAppearance.BorderSize = 3;
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(207)))), ((int)(((byte)(154)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(207)))), ((int)(((byte)(154)))));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForceColorHover = System.Drawing.Color.Empty;
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Image")));
            this.btnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYes.Location = new System.Drawing.Point(0, 0);
            this.btnYes.Margin = new System.Windows.Forms.Padding(0);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(85, 35);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "Đồng &ý";
            this.btnYes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnYes.TextColor = System.Drawing.Color.White;
            this.btnYes.UseHightLight = true;
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // pnNo
            // 
            this.pnNo.Controls.Add(this.btnNo);
            this.pnNo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnNo.Location = new System.Drawing.Point(228, 1);
            this.pnNo.Margin = new System.Windows.Forms.Padding(0);
            this.pnNo.Name = "pnNo";
            this.pnNo.Size = new System.Drawing.Size(84, 35);
            this.pnNo.TabIndex = 4;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(35)))), ((int)(((byte)(34)))));
            this.btnNo.BackColorHover = System.Drawing.Color.Empty;
            this.btnNo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(35)))), ((int)(((byte)(34)))));
            this.btnNo.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNo.BorderRadius = 0;
            this.btnNo.BorderSize = 0;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnNo.FlatAppearance.BorderSize = 3;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForceColorHover = System.Drawing.Color.Empty;
            this.btnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Location = new System.Drawing.Point(0, 0);
            this.btnNo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(84, 35);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "Khô&ng";
            this.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNo.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNo.UseHightLight = true;
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // pnCancel
            // 
            this.pnCancel.Controls.Add(this.btnCancel);
            this.pnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnCancel.Location = new System.Drawing.Point(312, 1);
            this.pnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.pnCancel.Name = "pnCancel";
            this.pnCancel.Size = new System.Drawing.Size(85, 35);
            this.pnCancel.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(35)))), ((int)(((byte)(34)))));
            this.btnCancel.BackColorHover = System.Drawing.Color.Empty;
            this.btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(35)))), ((int)(((byte)(34)))));
            this.btnCancel.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnCancel.FlatAppearance.BorderSize = 3;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 35);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy &bỏ";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.UseHightLight = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnMessContent
            // 
            this.pnMessContent.AutoScroll = true;
            this.pnMessContent.BackColor = System.Drawing.Color.Transparent;
            this.pnMessContent.Controls.Add(this.lblMsgContent);
            this.pnMessContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMessContent.Location = new System.Drawing.Point(0, 33);
            this.pnMessContent.MaximumSize = new System.Drawing.Size(0, 139);
            this.pnMessContent.Name = "pnMessContent";
            this.pnMessContent.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pnMessContent.Size = new System.Drawing.Size(398, 131);
            this.pnMessContent.TabIndex = 2;
            // 
            // lblMsgContent
            // 
            this.lblMsgContent.AutoSize = true;
            this.lblMsgContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsgContent.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgContent.Location = new System.Drawing.Point(10, 9);
            this.lblMsgContent.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblMsgContent.MinimumSize = new System.Drawing.Size(326, 107);
            this.lblMsgContent.Name = "lblMsgContent";
            this.lblMsgContent.Size = new System.Drawing.Size(387, 326);
            this.lblMsgContent.TabIndex = 1;
            this.lblMsgContent.Text = resources.GetString("lblMsgContent.Text");
            this.lblMsgContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMsgContent.UseCompatibleTextRendering = true;
            // 
            // txtDetail
            // 
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.Location = new System.Drawing.Point(0, 238);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(398, 144);
            this.txtDetail.TabIndex = 5;
            // 
            // pnErrorButton
            // 
            this.pnErrorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.pnErrorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnErrorButton.Controls.Add(this.btnCopyDetail);
            this.pnErrorButton.Controls.Add(this.btnIgnore);
            this.pnErrorButton.Controls.Add(this.btnDetail);
            this.pnErrorButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnErrorButton.Location = new System.Drawing.Point(0, 201);
            this.pnErrorButton.Name = "pnErrorButton";
            this.pnErrorButton.Padding = new System.Windows.Forms.Padding(1);
            this.pnErrorButton.Size = new System.Drawing.Size(398, 37);
            this.pnErrorButton.TabIndex = 4;
            this.pnErrorButton.Visible = false;
            // 
            // btnCopyDetail
            // 
            this.btnCopyDetail.BackColor = System.Drawing.SystemColors.Control;
            this.btnCopyDetail.BackColorHover = System.Drawing.Color.Empty;
            this.btnCopyDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnCopyDetail.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCopyDetail.BorderRadius = 0;
            this.btnCopyDetail.BorderSize = 0;
            this.btnCopyDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCopyDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCopyDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnCopyDetail.FlatAppearance.BorderSize = 3;
            this.btnCopyDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyDetail.ForceColorHover = System.Drawing.Color.Empty;
            this.btnCopyDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCopyDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyDetail.Image")));
            this.btnCopyDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyDetail.Location = new System.Drawing.Point(78, 1);
            this.btnCopyDetail.Name = "btnCopyDetail";
            this.btnCopyDetail.Size = new System.Drawing.Size(74, 35);
            this.btnCopyDetail.TabIndex = 12;
            this.btnCopyDetail.Text = "C&opy";
            this.btnCopyDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyDetail.TextColor = System.Drawing.SystemColors.ControlText;
            this.btnCopyDetail.UseHightLight = true;
            this.btnCopyDetail.UseVisualStyleBackColor = true;
            this.btnCopyDetail.Click += new System.EventHandler(this.btnCopyDetail_Click);
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(35)))), ((int)(((byte)(34)))));
            this.btnIgnore.BackColorHover = System.Drawing.Color.Empty;
            this.btnIgnore.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(35)))), ((int)(((byte)(34)))));
            this.btnIgnore.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIgnore.BorderRadius = 0;
            this.btnIgnore.BorderSize = 0;
            this.btnIgnore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIgnore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnIgnore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnIgnore.FlatAppearance.BorderSize = 3;
            this.btnIgnore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnIgnore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(91)))), ((int)(((byte)(90)))));
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnore.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnore.ForceColorHover = System.Drawing.Color.Empty;
            this.btnIgnore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIgnore.Image = ((System.Drawing.Image)(resources.GetObject("btnIgnore.Image")));
            this.btnIgnore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIgnore.Location = new System.Drawing.Point(312, 1);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(85, 35);
            this.btnIgnore.TabIndex = 11;
            this.btnIgnore.Text = "&Bỏ qua";
            this.btnIgnore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIgnore.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnIgnore.UseHightLight = true;
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.AutoSize = true;
            this.btnDetail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDetail.BackColor = System.Drawing.SystemColors.Control;
            this.btnDetail.BackColorHover = System.Drawing.Color.Empty;
            this.btnDetail.BackgroundColor = System.Drawing.SystemColors.Control;
            this.btnDetail.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetail.BorderRadius = 0;
            this.btnDetail.BorderSize = 0;
            this.btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.btnDetail.FlatAppearance.BorderSize = 3;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetail.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForceColorHover = System.Drawing.Color.Empty;
            this.btnDetail.ForeColor = System.Drawing.Color.Black;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetail.Location = new System.Drawing.Point(1, 1);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(77, 35);
            this.btnDetail.TabIndex = 10;
            this.btnDetail.Text = "     &Chi tiết";
            this.btnDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetail.TextColor = System.Drawing.Color.Black;
            this.btnDetail.UseHightLight = true;
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // FrmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 383);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = new System.Drawing.Size(406, 414);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(420, 433);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 161);
            this.Name = "FrmMessageBox";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.TopMost = true;
            this.UseFormControl = false;
            this.Load += new System.EventHandler(this.FrmMessageBox_Load);
            this.Shown += new System.EventHandler(this.FrmMessageBox_Shown);
            this.pnContent.ResumeLayout(false);
            this.pnContent.PerformLayout();
            this.pnTitleBar.ResumeLayout(false);
            this.pnNormalButton.ResumeLayout(false);
            this.pnYes.ResumeLayout(false);
            this.pnNo.ResumeLayout(false);
            this.pnCancel.ResumeLayout(false);
            this.pnMessContent.ResumeLayout(false);
            this.pnMessContent.PerformLayout();
            this.pnErrorButton.ResumeLayout(false);
            this.pnErrorButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private TPH.Controls.TPHNormalButton btnYes;
        private TPH.Controls.TPHNormalButton btnNo;
        private TPH.Controls.TPHNormalButton btnCancel;
        private System.Windows.Forms.Panel pnYes;
        private System.Windows.Forms.Panel pnNo;
        private System.Windows.Forms.Panel pnCancel;
        private System.Windows.Forms.Panel pnMessContent;
        private System.Windows.Forms.Panel pnErrorButton;
        private TPH.Controls.TPHNormalButton btnIgnore;
        private TPH.Controls.TPHNormalButton btnDetail;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label lblMsgContent;
        public System.Windows.Forms.Panel pnNormalButton;
        private TPH.Controls.TPHNormalButton btnCopy;
        private TPH.Controls.TPHNormalButton btnCopyDetail;
    }
}