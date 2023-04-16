using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TPH.Controls
{
    public partial class TPHPanel : Panel
    {

        private int backColorOpacity = 100;

        private int opacity;

       // private Color panelBackColor;

        private int borderRadius;

        private bool customizable = true;
        private Color topColor = Color.Empty;
        private Color bottomColor = Color.Empty;
        [Category("TPH CustomControl")]
        public Color TopColor
        {
            get { return topColor; }
            set { topColor = value;
                if (base.DesignMode)
                    this.Invalidate();
            }
        }
        [Category("TPH CustomControl")]
        public Color BottomColor
        {
            get { return bottomColor; }
            set { bottomColor = value;
                if (base.DesignMode)
                    this.Invalidate();
            }
        }
        [Category("TPH CustomControl")]
        private float gradientDegree = 90F;
        public float GradientDegree
        {
            get { return gradientDegree; }
            set { gradientDegree = value;
                if (base.DesignMode)
                    this.Invalidate(); }
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
        public int BackColorOpacity
        {
            get
            {
                return backColorOpacity;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    backColorOpacity = value;
                    opacity = Convert.ToInt32((double)backColorOpacity / 100.0 * 255.0);
                    if (base.DesignMode)
                    {
                        Invalidate(invalidateChildren: false);
                    }
                }
            }
        }

        //[Category("TPH CustomControl")]
        //public Color PanelBackColor
        //{
        //    get
        //    {
        //        return panelBackColor;
        //    }
        //    set
        //    {
        //        panelBackColor = value;
        //        if (base.DesignMode)
        //        {
        //            Invalidate(invalidateChildren: false);
        //        }
        //    }
        //}

        [Category("TPH CustomControl")]
        public Image BackImage
        {
            get
            {
                return BackgroundImage;
            }
            set
            {
                BackgroundImage = value;
            }
        }

        [Category("TPH CustomControl")]
        public ImageLayout BackImageLayout
        {
            get
            {
                return BackgroundImageLayout;
            }
            set
            {
                BackgroundImageLayout = value;
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

        public TPHPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            //BackgroundImage = Resources.BackImage;
            //BackgroundImageLayout = ImageLayout.Stretch;
            base.TabStop = false;
            base.Size = new Size(250, 250);
           // BackColorOpacity = 50;
           // PanelBackColor = Color.MediumSlateBlue;
        }

        private void SetDefaultColor()
        {
            if (!customizable)
            {
                BackColor = AppearanceStyle.Neptune;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetDefaultColor();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            if (BottomColor != Color.Empty || TopColor != Color.Empty)
            {
                if (ClientRectangle.Width > 0 || ClientRectangle.Height > 0 || ClientRectangle.X > 0 || ClientRectangle.Y > 0)
                {
                    var lgb = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, gradientDegree);
                    graphics.FillRectangle(lgb, this.ClientRectangle);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(opacity, BackColor)))
                {
                    graphics.FillRectangle(brush, base.ClientRectangle);
                }
            }
            ppwag.DrawBorderRadius(this, borderRadius, graphics);
        }
    }

}
