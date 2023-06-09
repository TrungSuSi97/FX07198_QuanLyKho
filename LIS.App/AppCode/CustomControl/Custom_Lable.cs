using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace CustomControl
{
    public class Custom_Lable : Label
    {
        //Value for binding
        private object _oldValue;
        public object OldValue
        {
            get { return _oldValue; }
            set { _oldValue = value; }
        }
        private string _bindFieldName = "";

        public string BindFieldName
        {
            get { return _bindFieldName; }
            set { _bindFieldName = value; }
        }

        /// <summary>
        /// Tạo ra Lable thay đổi màu khi rê chuột đến
        /// </summary>
        ///             
        //   System.Drawing.Font MyFont = new System.Drawing.Font(thisTempLabel.LabelFont, ((float)thisTempLabel.fontSize), FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);
        private Control _c = null;

        public Control GetControl
        {
            get { return _c; }
            set { _c = value; }
        }

        private bool _UseZoom = false;

        public bool UseZoom
        {
            get { return _UseZoom; }
            set { _UseZoom = value; }
        }

        private bool _UseShadow = false;

        public bool UseShadow
        {
            get { return _UseShadow; }
            set { _UseShadow = value; }
        }
        //Shawdow
        private Color color;
        private int direction;
        private float softness;
        private int opacity;
        private int shadowDepth;

        private Color _oldColor;
        FontStyle _oldStyle;
        public Custom_Lable()
        {
            if (UseZoom)
            {
                this.ForeColor = Color.White;
                this.Font = new Font(this.Font.Name, this.Font.Size, this.Font.Style);
                color = Color.Black;
                direction = 315;
                softness = 2f;
                opacity = 100;
                shadowDepth = 4;
            }
            else
            {
                color = Color.Black;
                direction = 315;
                softness = 1.5f;
                opacity = 100;
                shadowDepth = 3;
            }
           
        
        }
        private void SetSize(Control c, bool f)
        {
            if (f)
            {
                c.Size = new Size(c.Size.Width + 6, c.Size.Height + 6);
                c.Location = new Point(c.Location.X - 3, c.Location.Y - 3);
            }
            else
            {
                c.Size = new Size(c.Size.Width - 6, c.Size.Height - 6);
                c.Location = new Point(c.Location.X + 3, c.Location.Y + 3);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_UseZoom)
            {

                if (_oldColor == null || _oldColor == this.ForeColor)
                    _oldColor = this.ForeColor;
                this.ForeColor = Color.OrangeRed;
                if (_oldStyle != FontStyle.Bold && Font.Style != FontStyle.Bold)
                    _oldStyle = this.Font.Style;
                this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
                this.Cursor = Cursors.Hand;
                if (_c != null)
                    SetSize(_c, true);
            }

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_UseZoom)
            {
                this.ForeColor = _oldColor;
                this.Font = new Font(this.Font.Name, this.Font.Size, _oldStyle);
                this.Cursor = Cursors.Hand;
                if (_c != null)
                    SetSize(_c, false);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_UseZoom)
            {
                this.ForeColor = Color.Red;
                this.Cursor = Cursors.Hand;
            }
        }


        [Category("Appearance")]
        [Description("Gets or sets the color of the shadow")]
        [DefaultValue(typeof(Color), "0x800000")]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the degree of opacity of the shadow")]
        [DefaultValue(100)]
        public int Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentOutOfRangeException("Opacity",
                      "Opacity must be between 0 and 255");
                }
                opacity = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets how soft the shadow is")]
        [DefaultValue(2f)]
        public float Softness
        {
            get
            {
                return softness;
            }
            set
            {
                if (softness <= 0)
                {
                    throw new ArgumentOutOfRangeException("Softness",
                      "Softness must be greater than 0");
                }
                softness = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the angle the shadow is cast")]
        [DefaultValue(315)]
        public int Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (value < 0 || value > 360)
                {
                    throw new ArgumentOutOfRangeException("Direction",
                      "Direction must be between 0 and 360");
                }
                direction = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the distance between the plane " +
          "of the object casting the shadow and the shadow plane")]
        [DefaultValue(4)]
        public int ShadowDepth
        {
            get
            {
                return shadowDepth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ShadowDepth",
                      "ShadowDepth must be greater than 0");
                }
                shadowDepth = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_UseShadow)
            {
                Graphics screenGraphics = e.Graphics;
                Bitmap shadowBitmap = new Bitmap(Math.Max((int)(Width / softness), 1),
                  Math.Max((int)(Height / softness), 1));
                using (Graphics imageGraphics = Graphics.FromImage(shadowBitmap))
                {
                    imageGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    Matrix transformMatrix = new Matrix();
                    transformMatrix.Scale(1 / softness, 1 / softness);
                    transformMatrix.Translate((float)(shadowDepth * Math.Cos(direction)),
                      (float)(shadowDepth * Math.Sin(direction)));
                    imageGraphics.Transform = transformMatrix;
                    imageGraphics.DrawString(Text, Font,
                      new SolidBrush(Color.FromArgb(opacity, color)), 0, 0,
                      StringFormat.GenericTypographic);
                }
                screenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                screenGraphics.DrawImage(shadowBitmap, ClientRectangle, 0, 0,
                  shadowBitmap.Width, shadowBitmap.Height, GraphicsUnit.Pixel);
                screenGraphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                screenGraphics.DrawString(Text, Font, new SolidBrush(ForeColor), 0, 0,
                  StringFormat.GenericTypographic);
            }
            else
            {
                base.OnPaint(e);
            }

        }
    }
}
