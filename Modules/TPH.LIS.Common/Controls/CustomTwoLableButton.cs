using System;
using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomTwoLableButton : UserControl
    {
        public CustomTwoLableButton()
        {
            InitializeComponent();
        }

        public string ButtonText
        {
            get { return lblButtonText.Text; }
            set { lblButtonText.Text = value; }
        }

        public string DescriptionText
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public BorderStyle Border
        {
            get { return this.BorderStyle; }
            set { this.BorderStyle = value; }
        }

        public object ButtonValue1 { get; set; }

        public object ButtonValue2 { get; set; }

        Color _focustEnterForceColor = Color.Crimson;
        public Color FocustEnterForceColor
        {
            get { return _focustEnterForceColor; }
            set { _focustEnterForceColor = value; }
        }

        Color _focustLeaveBackColor = Color.White;
        public Color FocustLeaveBackColor
        {
            get { return _focustLeaveBackColor; }
            set { _focustLeaveBackColor = value; }
        }

        bool _useImage = true;

        public bool UseImage
        {
            get { return _useImage; }
            set { _useImage = value; }
        }


        private void TwoLableButton_Enter(object sender, EventArgs e)
        {
            lblButtonText.ForeColor = Color.White;
            lblDescription.ForeColor = Color.Gold;
            pnLeft.BackColor = this.BackColor = Color.FromArgb(59, 148, 190);
            //pnLeft.BackgroundImage = imageList2.Images[1];
            //pnLeft.BackgroundImageLayout = ImageLayout.Stretch;
            //this.BackgroundImage = imageList1.Images[1];
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void TwoLableButton_Leave(object sender, EventArgs e)
        {
            lblButtonText.ForeColor = Color.Black;
            lblDescription.ForeColor = Color.Gold;
            pnLeft.BackColor = this.BackColor = Color.FromArgb(192, 228, 252);
            //pnLeft.BackgroundImage = imageList2.Images[0];
            //pnLeft.BackgroundImageLayout = ImageLayout.Stretch;
            //this.BackgroundImage = imageList1.Images[0];
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }

        public new event EventHandler MouseEnter
        {
            add
            {
                base.MouseEnter += value;
                foreach (Control control in Controls)
                {
                    control.MouseEnter += value;
                }
            }
            remove
            {
                base.MouseEnter -= value;
                foreach (Control control in Controls)
                {
                    control.MouseEnter -= value;
                }
            }
        }

        public new event EventHandler MouseHover
        {
            add
            {
                base.MouseHover += value;
                foreach (Control control in Controls)
                {
                    control.MouseHover += value;
                }
            }
            remove
            {
                base.MouseHover -= value;
                foreach (Control control in Controls)
                {
                    control.MouseHover -= value;
                }
            }
        }

        public new event EventHandler MouseLeave
        {
            add
            {
                base.MouseLeave += value;
                foreach (Control control in Controls)
                {
                    control.MouseLeave += value;
                }
            }
            remove
            {
                base.MouseLeave -= value;
                foreach (Control control in Controls)
                {
                    control.MouseLeave -= value;
                }
            }
        }

        private void TwoLableButton_Paint(object sender, PaintEventArgs e)
        {
            pnLeft.Visible = _useImage;
            lblButtonText.TextAlign = ContentAlignment.MiddleCenter;
            lblDescription.TextAlign = ContentAlignment.TopCenter;
            //Graphics g = e.Graphics;
            //g.DrawLine(System.Drawing.Pens.Red, this.Left, this.Top,
            //    this.Right, this.Bottom);
            //g.FillRectangle(
            //new LinearGradientBrush(PointF.Empty, new PointF(0, this.Height), Color.White, this._FocustLeaveBackColor),
            //new RectangleF(PointF.Empty, this.Size));
            //this.Invalidate();
            
        }
    }
}