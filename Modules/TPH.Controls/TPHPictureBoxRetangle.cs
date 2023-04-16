using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public class TPHPictureBoxRetangle : PictureBox
    {
        private Color borderColor = Color.RoyalBlue;

        private int borderSize = 0;

        private int borderRadius = 0;

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
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        private void ApplyAppearanceSettings()
        {
            if (!customizable)
            {
                borderColor = AppearanceStyle.Neptune;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            BackColor = base.Parent.BackColor;
            ppwag.DrawBorderRadius(this, borderRadius, pe.Graphics, borderColor, borderSize);
        }
    }
}
