using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
   public class TPHProgressBar : ProgressBar
    {
        private Color channelColor = Color.LightSteelBlue;

        private Color sliderColor = Color.RoyalBlue;

        private Color foreBackColor = Color.RoyalBlue;

        private int channelHeight = 6;

        private int sliderHeight = 6;

        private txp showValue = txp.Right;

        private string symbolBefore = "";

        private string symbolAfter = "";

        private bool showMaximun = false;

        private bool paintedBack = false;

        private bool stopPainting = false;

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
        public Color ChannelColor
        {
            get
            {
                return channelColor;
            }
            set
            {
                channelColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color SliderColor
        {
            get
            {
                return sliderColor;
            }
            set
            {
                sliderColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color ForeBackColor
        {
            get
            {
                return foreBackColor;
            }
            set
            {
                foreBackColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public int ChannelHeight
        {
            get
            {
                return channelHeight;
            }
            set
            {
                channelHeight = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public int SliderHeight
        {
            get
            {
                return sliderHeight;
            }
            set
            {
                sliderHeight = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public txp ShowValue
        {
            get
            {
                return showValue;
            }
            set
            {
                showValue = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public string SymbolBefore
        {
            get
            {
                return symbolBefore;
            }
            set
            {
                symbolBefore = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public string SymbolAfter
        {
            get
            {
                return symbolAfter;
            }
            set
            {
                symbolAfter = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public bool ShowMaximun
        {
            get
            {
                return showMaximun;
            }
            set
            {
                showMaximun = value;
                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("TPH CustomControl")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Category("TPH CustomControl")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        public TPHProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, value: true);
            ForeColor = Color.White;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
            base.Parent.Paint += ParentContainer_RePaint;
        }

        private void ParentContainer_RePaint(object sender, PaintEventArgs e)
        {
            stopPainting = false;
            paintedBack = false;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (stopPainting)
            {
                return;
            }
            if (!paintedBack)
            {
                Graphics graphics = pevent.Graphics;
                Rectangle rect = new Rectangle(0, 0, base.Width, ChannelHeight);
                using (SolidBrush brush = new SolidBrush(channelColor))
                {
                    if (channelHeight >= sliderHeight)
                    {
                        rect.Y = base.Height - channelHeight;
                    }
                    else
                    {
                        rect.Y = base.Height - (channelHeight + sliderHeight) / 2;
                    }
                    graphics.Clear(base.Parent.BackColor);
                    graphics.FillRectangle(brush, rect);
                    if (!base.DesignMode)
                    {
                        paintedBack = true;
                    }
                }
            }
            if (base.Value == base.Maximum || base.Value == base.Minimum)
            {
                paintedBack = false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!stopPainting)
            {
                Graphics graphics = e.Graphics;
                double num = ((double)base.Value - (double)base.Minimum) / ((double)base.Maximum - (double)base.Minimum);
                int num2 = (int)((double)base.Width * num);
                Rectangle rectangle = new Rectangle(0, 0, num2, sliderHeight);
                using (SolidBrush brush = new SolidBrush(sliderColor))
                {
                    if (sliderHeight >= channelHeight)
                    {
                        rectangle.Y = base.Height - sliderHeight;
                    }
                    else
                    {
                        rectangle.Y = base.Height - (sliderHeight + channelHeight) / 2;
                    }
                    if (num2 > 1)
                    {
                        graphics.FillRectangle(brush, rectangle);
                    }
                    if (showValue != txp.None)
                    {
                        DrawValueText(graphics, num2, rectangle);
                    }
                }
            }
            if (base.Value == base.Maximum)
            {
                stopPainting = true;
            }
            else
            {
                stopPainting = false;
            }
        }

        private void DrawValueText(Graphics graph, int sliderWidth, Rectangle rectSlider)
        {
            string text = symbolBefore + base.Value + symbolAfter;
            if (showMaximun)
            {
                text = text + "/" + symbolBefore + base.Maximum + symbolAfter;
            }
            Size size = TextRenderer.MeasureText(text, Font);
            Rectangle rectangle = new Rectangle(0, 0, size.Width, size.Height + 2);
            using (SolidBrush brush3 = new SolidBrush(ForeColor))
            using (SolidBrush brush2 = new SolidBrush(foreBackColor))
            using (StringFormat stringFormat = new StringFormat())
            {
                switch (showValue)
                {
                    case txp.Left:
                        rectangle.X = 0;
                        stringFormat.Alignment = StringAlignment.Near;
                        break;
                    case txp.Right:
                        rectangle.X = base.Width - size.Width;
                        stringFormat.Alignment = StringAlignment.Far;
                        break;
                    case txp.Center:
                        rectangle.X = (base.Width - size.Width) / 2;
                        stringFormat.Alignment = StringAlignment.Center;
                        break;
                    case txp.Sliding:
                        {
                            rectangle.X = sliderWidth - size.Width;
                            stringFormat.Alignment = StringAlignment.Center;
                            using (SolidBrush brush = new SolidBrush(base.Parent.BackColor))
                            {
                                Rectangle rect = rectSlider;
                                rect.Y = rectangle.Y;
                                rect.Height = rectangle.Height;
                                graph.FillRectangle(brush, rect);
                            }
                            break;
                        }
                }
                graph.FillRectangle(brush2, rectangle);
                graph.DrawString(text, Font, brush3, rectangle, stringFormat);
            }
        }

        private void ApplyAppearanceSettings()
        {
            if (!customizable)
            {
                foreBackColor = AppearanceStyle.Neptune;
                sliderColor = AppearanceStyle.Neptune;
                if (AppearanceStyle.theme == uuufteme.Dark)
                {
                    channelColor = kkgegea.gegeagge(AppearanceStyle.LightItemBackground, 5);
                }
                else
                {
                    channelColor = kkgegea.hgfhfg(AppearanceStyle.LightBackground, 15);
                }
            }
        }
    }
}
