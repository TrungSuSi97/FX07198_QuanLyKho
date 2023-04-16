using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public class GradientPanel : Panel
    {
        private Color topColor = Color.Empty;
        private Color bottomColor = Color.Empty;
        public Color TopColor
        {
            get { return topColor; }
            set { topColor = value; this.Invalidate(); }
        }
        public Color BottomColor
        {
            get { return bottomColor; }
            set { bottomColor = value; this.Invalidate(); }
        }
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
                    if (ClientRectangle.Width > 0 || ClientRectangle.Height > 0 || ClientRectangle.X > 0 || ClientRectangle.Y > 0)
                    {
                        var lgb = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, gradientDegree);
                        var gb = e.Graphics;
                        gb.FillRectangle(lgb, this.ClientRectangle);
                    }
                }
            }
            base.OnPaint(e);
        }
    }
}
