namespace TPH.LIS.Common.Controls
{
    partial class ucCheckListBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkCheckAll = new System.Windows.Forms.CheckBox();
            this.chkItemList = new TPH.LIS.Common.Controls.CustomCheckedListBox();
            this.ucGroupHeader1 = new TPH.LIS.Common.Controls.ucGroupHeader();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.chkCheckAll);
            this.panel1.Controls.Add(this.ucGroupHeader1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 48);
            this.panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(0, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(66, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // chkCheckAll
            // 
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Checked = true;
            this.chkCheckAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkCheckAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckAll.Location = new System.Drawing.Point(66, 26);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Padding = new System.Windows.Forms.Padding(3);
            this.chkCheckAll.Size = new System.Drawing.Size(62, 22);
            this.chkCheckAll.TabIndex = 2;
            this.chkCheckAll.Text = "Tất cả";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
            // 
            // chkItemList
            // 
            this.chkItemList.CheckOnClick = true;
            this.chkItemList.DataSource = null;
            this.chkItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkItemList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItemList.FormattingEnabled = true;
            this.chkItemList.Location = new System.Drawing.Point(0, 48);
            this.chkItemList.Name = "chkItemList";
            this.chkItemList.Size = new System.Drawing.Size(128, 44);
            this.chkItemList.TabIndex = 1;
            this.chkItemList.Value = 0;
            this.chkItemList.SelectedIndexChanged += new System.EventHandler(this.chkItemList_SelectedIndexChanged);
            // 
            // ucGroupHeader1
            // 
            this.ucGroupHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(111)))), ((int)(((byte)(152)))));
            this.ucGroupHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucGroupHeader1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucGroupHeader1.ForeColor = System.Drawing.Color.Yellow;
            this.ucGroupHeader1.GroupCaption = "Tên check list";
            this.ucGroupHeader1.GroupCaptionAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ucGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.ucGroupHeader1.MaximumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.MinimumSize = new System.Drawing.Size(0, 23);
            this.ucGroupHeader1.Name = "ucGroupHeader1";
            this.ucGroupHeader1.Size = new System.Drawing.Size(128, 26);
            this.ucGroupHeader1.TabIndex = 3;
            // 
            // ucCheckListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.chkItemList);
            this.Controls.Add(this.panel1);
            this.Name = "ucCheckListBox";
            this.Size = new System.Drawing.Size(128, 92);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private System.Windows.Forms.TextBox txtSearch;
        private CustomCheckedListBox chkItemList;
        private ucGroupHeader ucGroupHeader1;
    }
}
