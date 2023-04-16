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
    public partial class TPHGradientPanel : Panel
    {
        Bitmap bmpback = null;
        public TPHGradientPanel()
        {
            InitializeComponent();
            bmpback = new Bitmap(Width, Height);
 
            Graphics gp = Graphics.FromImage(bmpback);
            if (topColor != Color.Empty || bottomColor != Color.Empty)
            {
                if (ClientRectangle.Width > 0 || ClientRectangle.Height > 0 || ClientRectangle.X > 0 || ClientRectangle.Y > 0)
                {
                    var lgb = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, gradientDegree);
                    gp.FillRectangle(lgb, this.ClientRectangle);

                }
            }
            this.BackgroundImage = bmpback;
        }
        private Color topColor = Color.Empty;
        private Color bottomColor = Color.Empty;
        [Category("TPH CustomControl")]
        public Color TopColor
        {
            get { return topColor; }
            set { topColor = value; this.Invalidate(); }
        }
        [Category("TPH CustomControl")]
        public Color BottomColor
        {
            get { return bottomColor; }
            set { bottomColor = value; this.Invalidate(); }
        }
        [Category("TPH CustomControl")]
        private float gradientDegree = 90F;
        public float GradientDegree
        {
            get { return gradientDegree; }
            set { gradientDegree = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (e.Graphics != null)
                {
                    Graphics gp = Graphics.FromImage(bmpback);
                    if (topColor != Color.Empty || bottomColor != Color.Empty)
                    {
                        if ((ClientRectangle.Width > 0 && ClientRectangle.Height > 0)|| ClientRectangle.X > 0 || ClientRectangle.Y > 0)
                        {
                            var lgb = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, gradientDegree);
                            var gb = e.Graphics;
                            gb.FillRectangle(lgb, this.ClientRectangle);

                        }
                    }
                }
            }
            base.OnPaint(e);
        }

        private void TPHGradientPanel_SizeChanged(object sender, EventArgs e)
        {  
            //if (!this.IsDisposed)
            //{
            //    if (Width > 0)
            //    {
            //        bmpback = new Bitmap(Width, Height);
            //        Graphics gp = Graphics.FromImage(bmpback);
            //        if (topColor != Color.Empty || bottomColor != Color.Empty)
            //        {
            //            if (ClientRectangle.Width > 0 || ClientRectangle.Height > 0 || ClientRectangle.X > 0 || ClientRectangle.Y > 0)
            //            {
            //                var lgb = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, gradientDegree);
            //                gp.FillRectangle(lgb, this.ClientRectangle);

            //            }
            //        }
            //        this.BackgroundImage = bmpback;
            //    }
            //    Invalidate();
            //}
        }
    }
}
