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
    public class TPHRadioButton : RadioButton
    {
        private Color checkedColor = AppearanceStyle.Neptune;

        private Color unCheckColor = clors.Cancel;

        private Color gf = AppearanceStyle.LightItemBackground;

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
                if (base.DesignMode)
                {
                    ppea();
                    Invalidate();
                }
            }
        }

        [Category("TPH CustomControl")]
        public Color CheckedColor
        {
            get
            {
                return checkedColor;
            }
            set
            {
                checkedColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public Color UnCheckColor
        {
            get
            {
                return unCheckColor;
            }
            set
            {
                unCheckColor = value;
                Invalidate();
            }
        }

        public TPHRadioButton()
        {
            MinimumSize = new Size(0, 21);
            //  Font = new Font(this.Font.Name, AppearanceStyle.fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cursor = Cursors.Hand;
        }

        private void ppea()
        {
            if (!customizable)
            {
                checkedColor = AppearanceStyle.Neptune;
                unCheckColor = clors.Cancel;
                gf = AppearanceStyle.LightItemBackground;
                ForeColor = AppearanceStyle.LightTextColor;
            }
            else if (base.Parent != null)
            {
                if (AppearanceStyle.theme == uuufteme.Light)
                {
                    gf = kkgegea.gegeagge(base.Parent.BackColor, 30);
                }
                else
                {
                    gf = kkgegea.hgfhfg(base.Parent.BackColor, 8);
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ppea();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            int num = 18;
            int num2 = 12;
            Rectangle rectangle = default(Rectangle);
            rectangle.X = 1;
            rectangle.Y = (base.Height - num) / 2;
            rectangle.Width = num;
            rectangle.Height = num;
            Rectangle rect = rectangle;
            Rectangle rectangle2 = default(Rectangle);
            rectangle2.X = rect.X + (rect.Width - num2) / 2;
            rectangle2.Y = (base.Height - num2) / 2;
            rectangle2.Width = num2;
            rectangle2.Height = num2;
            Rectangle rect2 = rectangle2;
            using (Pen pen = new Pen(checkedColor, 1.5f))
            using (SolidBrush brush = new SolidBrush(gf))
            using (SolidBrush brush2 = new SolidBrush(checkedColor))
            using (SolidBrush brush3 = new SolidBrush(ForeColor))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(BackColor);
                if (base.Checked)
                {
                    graphics.FillEllipse(brush, rect);
                    graphics.DrawEllipse(pen, rect);
                    graphics.FillEllipse(brush2, rect2);
                }
                else
                {
                    pen.Color = unCheckColor;
                    graphics.FillEllipse(brush, rect);
                    graphics.DrawEllipse(pen, rect);
                }
                graphics.DrawString(Text, Font, brush3, num + 8, (base.Height - TextRenderer.MeasureText(Text, Font).Height) / 2);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Width = TextRenderer.MeasureText(Text, Font).Width + 30;
        }
    }
}
