using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomDownArrow : PictureBox
    {
        public CustomDownArrow()
        {
            InitializeComponent();
        }

        private Button _buttonLink;

        public Button ButtonLink
        {
            get { return _buttonLink; }
            set { _buttonLink = value; }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

        }

        private void DownArrow_MouseHover(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void DownArrow_VisibleChanged(object sender, EventArgs e)
        {
            if (_buttonLink != null)
            {
                this.Location = new Point(ButtonLink.Location.X + (ButtonLink.Width/2) - (this.Width/2),
                    ButtonLink.Location.Y - this.Height);
            }
        }

        private void DownArrow_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}