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
    public class TPHToggleButton : CheckBox
    {
        private ctrls controlStyle;

        private Color colorBorderTrue = Color.MediumSlateBlue;

        private Color colorEllipseTrue = Color.White;

        private Color colorTextTrue = Color.White;

        private string textTrue;

        private Color colorBorderFalse = Color.LightGray;

        private Color colorEllipseFalse = Color.Gray;

        private Color colorTextFalse = Color.Gray;

        private string textFalse;

        private bool customizable;
         
        [Category("TPH CustomControl")]
        public string TextTrue
        {
            get
            {
                return textTrue;
            }
            set
            {
                textTrue = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public string TextFalse
        {
            get
            {
                return textFalse;
            }
            set
            {
                textFalse = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public ctrls ControlStyle
        {
            get
            {
                return controlStyle;
            }
            set
            {
                controlStyle = value;
                SetDefaultColor();
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public bool IsTrue
        {
            get
            {
                return base.Checked;
            }
            set
            {
                base.Checked = value;
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
        public Color ColorBorderTrue
        {
            get
            {
                return colorBorderTrue;
            }
            set
            {
                colorBorderTrue = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color ColorEllipseTrue
        {
            get
            {
                return colorEllipseTrue;
            }
            set
            {
                colorEllipseTrue = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color ColorTextTrue
        {
            get
            {
                return colorTextTrue;
            }
            set
            {
                colorTextTrue = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color ColorBorderFalse
        {
            get
            {
                return colorBorderFalse;
            }
            set
            {
                colorBorderFalse = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color ColorEllipseFalse
        {
            get
            {
                return colorEllipseFalse;
            }
            set
            {
                colorEllipseFalse = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color ColorTextFalse
        {
            get
            {
                return colorTextFalse;
            }
            set
            {
                colorTextFalse = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = "#";
            }
        }

        public TPHToggleButton()
        {
            MinimumSize = new Size(50, 25);
            IsTrue = true;
            ControlStyle = ctrls.Glass;
        }

        private void SetDefaultColor()
        {
            if (customizable)
            {
                return;
            }
            if (AppearanceStyle.theme == uuufteme.Light)
            {
                if (controlStyle == ctrls.Solid)
                {
                    colorBorderTrue = AppearanceStyle.Neptune;
                    colorEllipseTrue = Color.White;
                    colorTextTrue = Color.WhiteSmoke;
                    colorBorderFalse = Color.LightGray;
                    colorEllipseFalse = Color.White;
                    colorTextFalse = Color.Gray;
                }
                else
                {
                    colorBorderTrue = AppearanceStyle.Neptune;
                    colorEllipseTrue = AppearanceStyle.Neptune;
                    colorTextTrue = AppearanceStyle.LightTextColor;
                    colorBorderFalse = Color.FromArgb(171, 171, 171);
                    colorEllipseFalse = Color.FromArgb(171, 171, 171);
                    colorTextFalse = Color.Gray;
                }
            }
            else
            {
                colorBorderTrue = AppearanceStyle.Neptune;
                if (controlStyle == ctrls.Solid)
                {
                    colorEllipseTrue = clors.DarkItemBackground;
                    colorTextTrue = Color.Gainsboro;
                }
                else
                {
                    colorEllipseTrue = AppearanceStyle.Neptune;
                    colorTextTrue = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 20);
                }
                colorBorderFalse = clors.DarkActiveBackground;
                colorEllipseFalse = Color.FromArgb(110, 104, 153);
                colorTextFalse = AppearanceStyle.LightTextColor;
            }
        }

        private GraphicsPath mmas(Rectangle rect)
        {
            int height = rect.Height;
            Rectangle rect2 = new Rectangle(rect.X, rect.Y, height, height);
            Rectangle rect3 = new Rectangle(rect.Width - height, rect.Y, height, height);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rect2, 90f, 180f);
            graphicsPath.AddArc(rect3, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            Rectangle rect = Rectangle.Inflate(base.ClientRectangle, -2, -2);
            float num = (float)rect.Height - 4.8f;
            RectangleF rectangleF = default(RectangleF);
            rectangleF.X = (float)rect.X + ((float)rect.Height - num) / 2f;
            rectangleF.Y = (float)rect.Y + ((float)rect.Height - num) / 2f;
            rectangleF.Width = num;
            rectangleF.Height = num;
            RectangleF rect2 = rectangleF;
            RectangleF rectangleF2 = default(RectangleF);
            rectangleF2.X = (float)rect.Width - num - ((float)rect.Height - num) / 2f;
            rectangleF2.Y = (float)rect.Y + ((float)rect.Height - num) / 2f;
            rectangleF2.Width = num;
            rectangleF2.Height = num;
            RectangleF rect3 = rectangleF2;
            using (GraphicsPath path = mmas(rect))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(base.Parent.BackColor);
                if (base.Checked)
                {
                    if (controlStyle == ctrls.Solid)
                    {
                        graphics.FillPath(new SolidBrush(colorBorderTrue), path);
                    }
                    else
                    {
                        graphics.DrawPath(new Pen(colorBorderTrue, 2f), path);
                    }
                    graphics.FillEllipse(new SolidBrush(colorEllipseTrue), rect3);
                    if (textTrue != "" || textTrue != null)
                    {
                        graphics.DrawString(textTrue, Font, new SolidBrush(colorTextTrue), (float)((rect.Right - TextRenderer.MeasureText(textTrue, Font).Width) / 2) - num / 2f, (base.Height - TextRenderer.MeasureText(textTrue, Font).Height) / 2);
                    }
                }
                else
                {
                    if (controlStyle == ctrls.Solid)
                    {
                        graphics.FillPath(new SolidBrush(colorBorderFalse), path);
                    }
                    else
                    {
                        pevent.Graphics.DrawPath(new Pen(colorBorderFalse, 2f), path);
                    }
                    graphics.FillEllipse(new SolidBrush(colorEllipseFalse), rect2);
                    if (textFalse != "" || textFalse != null)
                    {
                        graphics.DrawString(textFalse, Font, new SolidBrush(colorTextFalse), (float)((rect.Right - TextRenderer.MeasureText(textTrue, Font).Width) / 2) + num / 2f, (base.Height - TextRenderer.MeasureText(textTrue, Font).Height) / 2);
                    }
                }
            }
        }
    }
}
