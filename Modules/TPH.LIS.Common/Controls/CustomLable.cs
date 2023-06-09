using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public class CustomLable : Label
    {
        //Value for binding
        public object OldValue
        {
            get;
            set;
        }

        public string BindFieldName
        {
            get;
            set;
        }

        /// <summary>
        /// Tạo ra Lable thay đổi màu khi rê chuột đến
        /// </summary>
        ///             
        //   System.Drawing.Font MyFont = new System.Drawing.Font(thisTempLabel.LabelFont, ((float)thisTempLabel.fontSize), FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);

        public Control GetControl
        {
            get;
            set;
        }


        public bool UseZoom
        {
            get;
            set;
        }


        public bool UseShadow
        {
            get;
            set;
        }

        //Shawdow
        private Color _color;
        private int _direction;
        private float _softness;
        private int _opacity;
        private int _shadowDepth;
        private Font _foOld;
        public Color _oldColor;
        FontStyle _oldStyle;

        public Color ForeColorClicked { get; set; } = System.Drawing.Color.White;public CustomLable()
        {
            if (UseZoom){
                this.ForeColor = ForeColorClicked;
                _foOld = this.Font;
                this.Font = new Font(this.Font.Name, this.Font.Size, this.Font.Style);
                _color = Color.Black;
                _direction = 315;
                _softness = 2f;
                _opacity = 100;
                _shadowDepth = 4;
            }
            else
            {
                _color = this.Color;
                _direction = 315;
                _softness = 1.5f;
                _opacity = 100;
                _shadowDepth = 3;
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
            if (UseZoom)
            {

                if (_oldColor == null)
                    _oldColor = this.ForeColor;
                this.ForeColor = Color.OrangeRed;
                if (_oldStyle != FontStyle.Bold && Font.Style != FontStyle.Bold)
                    _oldStyle = this.Font.Style;
                _foOld = this.Font;
                this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
                this.Cursor = Cursors.Hand;
                if (GetControl != null)
                    SetSize(GetControl, true);
            }

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (UseZoom)
            {
                this.ForeColor = _oldColor != null ? _oldColor : this.ForeColor;
                this.Font = _foOld;
                if (GetControl != null)
                    SetSize(GetControl, false);
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //if (UseZoom)
            //{
            //    this.ForeColor = Color.Red;
            //    this.Cursor = Cursors.Hand;
            //}
        }


        [Category("Appearance")]
        [Description("Gets or sets the color of the shadow")]
        [DefaultValue(typeof(Color), "0x800000")]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
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
                return _opacity;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    throw new ArgumentOutOfRangeException("Opacity",
                      "Opacity must be between 0 and 255");
                }
                _opacity = value;
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
                return _softness;
            }
            set
            {
                if (_softness <= 0)
                {
                    throw new ArgumentOutOfRangeException("Softness",
                      "Softness must be greater than 0");
                }
                _softness = value;
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
                return _direction;
            }
            set
            {
                if (value < 0 || value > 360)
                {
                    throw new ArgumentOutOfRangeException("Direction",
                      "Direction must be between 0 and 360");
                }
                _direction = value;
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
                return _shadowDepth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ShadowDepth",
                      "ShadowDepth must be greater than 0");
                }
                _shadowDepth = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (UseShadow)
            {
                var screenGraphics = e.Graphics;
                var shadowBitmap = new Bitmap(Math.Max((int)(Width / _softness), 1),
                  Math.Max((int)(Height / _softness), 1));
                using (var imageGraphics = Graphics.FromImage(shadowBitmap))
                {
                    imageGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    Matrix transformMatrix = new Matrix();
                    transformMatrix.Scale(1 / _softness, 1 / _softness);
                    transformMatrix.Translate((float)(_shadowDepth * Math.Cos(_direction)),
                      (float)(_shadowDepth * Math.Sin(_direction)));
                    imageGraphics.Transform = transformMatrix;
                    imageGraphics.DrawString(Text, Font,
                      new SolidBrush(Color.FromArgb(_opacity, _color)), 0, 0,
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