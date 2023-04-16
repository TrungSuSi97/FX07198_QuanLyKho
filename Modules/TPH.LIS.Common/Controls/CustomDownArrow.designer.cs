namespace TPH.LIS.Common.Controls
{
    partial class CustomDownArrow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDownArrow));
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DownArrow
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
            this.Size = new System.Drawing.Size(31, 33);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Visible = false;
            this.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.DownArrow_LoadCompleted);
            this.VisibleChanged += new System.EventHandler(this.DownArrow_VisibleChanged);
            this.MouseHover += new System.EventHandler(this.DownArrow_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
