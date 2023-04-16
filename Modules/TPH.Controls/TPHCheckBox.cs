using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public class TPHCheckBox: CheckBox
    {
        private bool customizable = true;

        private ctrls boxStyle = ctrls.Glass;

        private int boxSize = 1;

        private Color boxBorderColor = AppearanceStyle.Neptune;

        private IconPictureBox e;

        [Category("TPH CustomControl")]
        public ctrls ControlStyle
        {
            get
            {
                return boxStyle;
            }
            set
            {
                boxStyle = value;
                base.Image = null;
                SetDefaultStyle();
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public int BoxSize
        {
            get
            {
                return boxSize;
            }
            set
            {
                if (value > 0)
                {
                    boxSize = value;
                }
                Invalidate();
            }
        }
        [Category("TPH CustomControl")]
        public bool Customizable
        {
            get
            {
                return customizable;
            }
            set
            {
                customizable = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color BoxBorderColor
        {
            get
            {
                return boxBorderColor;
            }
            set
            {
                boxBorderColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color CheckColor
        {
            get
            {
                return e.IconColor;
            }
            set
            {
                e.IconColor = value;
                Invalidate();
            }
        }

        public TPHCheckBox()
        {
            e = new IconPictureBox();
            e.IconChar = IconChar.Check;
            e.IconSize = 19;
            e.IconColor = AppearanceStyle.Neptune;
            Cursor = Cursors.Hand;
            base.Checked = true;
            Font = new Font(AppearanceStyle.fontName, AppearanceStyle.fontSize);
            ForeColor = AppearanceStyle.LightTextColor;
            MinimumSize = new Size(0, 21);
        }

        private void SetDefaultStyle()
        {
            if (!customizable)
            {
                boxBorderColor = AppearanceStyle.Neptune;
                ForeColor = AppearanceStyle.LightTextColor;
                if (boxStyle == ctrls.Solid)
                {
                    CheckColor = Color.White;
                }
                else
                {
                    CheckColor = AppearanceStyle.Neptune;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            int num = 18;
            int iconSize = e.IconSize;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = 1;
            rectangle.Y = (base.Height - num) / 2;
            rectangle.Width = num;
            rectangle.Height = num;
            Rectangle rect = rectangle;
            Rectangle rectangle2 = default(Rectangle);
            rectangle2.X = rect.X + (rect.Width - iconSize) / 2 + 1;
            rectangle2.Y = (base.Height - iconSize) / 2 + 2;
            rectangle2.Width = iconSize;
            rectangle2.Height = iconSize;
            Rectangle rect2 = rectangle2;
            using (Pen pen = new Pen(boxBorderColor, boxSize))
            using (SolidBrush brush = new SolidBrush(boxBorderColor))
            using (SolidBrush brush2 = new SolidBrush(ForeColor))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(BackColor);
                if (base.Checked)
                {
                    if (boxStyle == ctrls.Solid)
                    {
                        graphics.FillRectangle(brush, rect);
                    }
                    graphics.DrawRectangle(pen, rect);
                    graphics.DrawImage(e.Image, rect2);
                }
                else
                {
                    graphics.DrawRectangle(pen, rect);
                }
                graphics.DrawString(Text, Font, brush2, num + 8, (base.Height - TextRenderer.MeasureText(Text, Font).Height) / 2);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Width = TextRenderer.MeasureText(Text, Font).Width + 25;
        }
    }
}
