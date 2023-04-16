using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public class TPHTrackBar : TrackBar
    {
        private struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;
        }

        private const int WM_USER = 1024;

        private const int TBM_GETCHANNELRECT = 1050;

        private const int TBM_GETTHUMBRECT = 1049;

        private bool a;

        private bool b;

        private Color c;

        private Color d;

        private Color f;

        private int h;

        private Font i;

        [Category("TPH CustomControl")]
        public bool faf
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color cca
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                if (base.DesignMode)
                {
                    Invalidate();
                }
            }
        }

        [Category("TPH CustomControl")]
        public Color scl
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                if (base.DesignMode)
                {
                    Update();
                }
            }
        }

        [Category("TPH CustomControl")]
        public Color tcc
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
                if (base.DesignMode)
                {
                    Invalidate();
                }
            }
        }

        [Category("TPH CustomControl")]
        public bool sww
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                if (base.DesignMode)
                {
                    Invalidate();
                }
            }
        }

        public TPHTrackBar()
        {
            SetStyle(ControlStyles.UserPaint, value: true);
            i = new Font("Verdana", 8f, FontStyle.Regular);
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageRect(IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam);

        private Rectangle gaer()
        {
            RECT lParam = default(RECT);
            SendMessageRect(base.Handle, 1049, IntPtr.Zero, ref lParam);
            return new Rectangle(lParam.Left, lParam.Top, lParam.Right - lParam.Left, lParam.Bottom - lParam.Top);
        }

        private Rectangle hahah()
        {
            RECT lParam = default(RECT);
            SendMessageRect(base.Handle, 1050, IntPtr.Zero, ref lParam);
            if (base.Orientation == Orientation.Horizontal)
            {
                return new Rectangle(lParam.Left, lParam.Top, lParam.Right - lParam.Left, lParam.Bottom - lParam.Top + 3);
            }
            return new Rectangle(lParam.Left, lParam.Top, lParam.Bottom - lParam.Top + 3, lParam.Right - lParam.Left);
        }

        private void kkgkg()
        {
            if (!a)
            {
                if (AppearanceStyle.theme == uuufteme.Light)
                {
                    c = Color.LightGray;
                    d = AppearanceStyle.Neptune;
                    f = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 25);
                }
                else
                {
                    c = clors.DefaultFormBorderColor;
                    d = AppearanceStyle.Neptune;
                    f = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 7);
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            h = base.Value;
            kkgkg();
        }

        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            h = base.Value;
            Invalidate(invalidateChildren: false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = hahah();
            Rectangle rect2 = gaer();
            using (Graphics graphics = e.Graphics)
            using (SolidBrush brush = new SolidBrush(c))
            using (SolidBrush brush2 = new SolidBrush(d))
            using (SolidBrush brush3 = new SolidBrush(f))
            {
                graphics.FillRectangle(brush, rect);
                graphics.FillRectangle(brush2, rect2);
                if (!b)
                {
                    return;
                }
                if (base.Orientation == Orientation.Horizontal)
                {
                    if (h >= 100)
                    {
                        graphics.DrawString(h.ToString(), i, brush3, rect2.Left - 6, 21f);
                    }
                    else
                    {
                        graphics.DrawString(h.ToString(), i, brush3, rect2.Left, 21f);
                    }
                }
                else
                {
                    graphics.DrawString(h.ToString(), i, brush3, 21f, rect2.Top);
                }
            }
        }
    }
}
