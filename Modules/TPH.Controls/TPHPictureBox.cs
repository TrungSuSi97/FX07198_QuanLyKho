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
    public class TPHPictureBox : PictureBox
    {
        private int borderSize = 2;

        private Color borderColor = Color.RoyalBlue;

        private Color borderColor2 = Color.HotPink;

        private DashStyle borderLineStyle = DashStyle.Solid;

        private DashCap borderCapStyle = DashCap.Flat;

        private bool gradientColor = false;

        private float gradientAngle = 50f;

        private bool customizable = true;

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
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color BorderColor2
        {
            get
            {
                return borderColor2;
            }
            set
            {
                borderColor2 = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public DashStyle BorderLineStyle
        {
            get
            {
                return borderLineStyle;
            }
            set
            {
                borderLineStyle = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public DashCap BorderCapStyle
        {
            get
            {
                return borderCapStyle;
            }
            set
            {
                borderCapStyle = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public bool GradientColor
        {
            get
            {
                return gradientColor;
            }
            set
            {
                gradientColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public float GradientAngle
        {
            get
            {
                return gradientAngle;
            }
            set
            {
                gradientAngle = value;
                Invalidate();
            }
        }

        public TPHPictureBox()
        {
            base.Size = new Size(100, 100);
            base.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ApplyAppearanceSettings()
        {
            if (!customizable)
            {
                borderColor = AppearanceStyle.Neptune;
                borderColor2 = AppearanceStyle.Neptune;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Size = new Size(base.Width, base.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics graphics = pe.Graphics;
            Rectangle rect = Rectangle.Inflate(base.ClientRectangle, -1, -1);
            Rectangle rectangle = Rectangle.Inflate(rect, -borderSize, -borderSize);
            RectangleF rect2 = RectangleF.Inflate(rectangle, 0.5f, 0.5f);
            int num = ((borderSize <= 0) ? 1 : borderSize);
            using (GraphicsPath graphicsPath = new GraphicsPath())
            using (Pen pen2 = new Pen(base.Parent.BackColor, num))
            using (Pen pen = new Pen(borderColor, borderSize))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                pen.DashStyle = borderLineStyle;
                pen.DashCap = borderCapStyle;
                graphicsPath.AddEllipse(rect);
                base.Region = new Region(graphicsPath);
                graphics.DrawEllipse(pen2, rect);
                if (borderSize <= 0)
                {
                    return;
                }
                graphics.DrawEllipse(pen2, rect2);
                if (gradientColor)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, borderColor, borderColor2, gradientAngle))
                    {
                        pen.Brush = brush;
                        graphics.DrawEllipse(pen, rectangle);
                    }
                }
                else
                {
                    graphics.DrawEllipse(pen, rectangle);
                }
            }
        }
    }
}
