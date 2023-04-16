using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace TPH.Controls
{
    public sealed partial class TPHNormalButton : Button
    {
        public Color OldColorHover;
        public Color OldColorEnter;
        private Font _oldFont;
        //Fields
        private int _borderSize = 1;
        private int _borderRadius = 5;
        private Color _borderColor;

        //Properties
        [Category("Custom")]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }

        [Category("Custom")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Custom")] public Color BackColorHover { get; set; }
        [Category("Custom")] public Color ForceColorHover { get; set; }
        [Category("Custom")]
        public Color BackgroundColor 
        {
            get => BackColor;
            set => BackColor = value;
        }

        [Category("Custom")]
        public Color TextColor
        {
            get => ForeColor;
            set => ForeColor = value;
        }
        public TPHNormalButton()
        {
            BackColor = CommonAppColors.ColorButtonBackColor;
            ForeColor = CommonAppColors.ColorButtonForceColor;
            _borderColor = CommonAppColors.ColorButtonBorderColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            InitializeComponent();
       
            Size = new Size(150, 40);
            Resize += Button_Resize;
            //TextAlign = ContentAlignment.MiddleCenter;
            //ImageAlign = ContentAlignment.MiddleLeft;
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        private bool _useHightLight = true;
        [Category("Custom")]
        public bool UseHightLight
        {
            get => _useHightLight;
            set => _useHightLight = value;
        }
        private Color BackColorFromParent(Control parent)
        {
            if (parent == null) return Color.Empty;
            return parent.BackColor != Color.Empty ? parent.BackColor : BackColorFromParent(parent.Parent);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            var rectSurface = ClientRectangle;
            var rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
            var smoothSize = 2;
            if (_borderSize > 0)
                smoothSize = _borderSize;

            if (_borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize))
                using (Pen penSurface = new Pen(BackColorFromParent(this.Parent), smoothSize))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (_borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (_borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(_borderColor, _borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (!UseHightLight) return;
            if (this.BackColor != OldColorEnter) return;
            OldColorEnter = this.BackColor;
            _oldFont = this.Font;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (UseHightLight)
            {
                if (this.BackColor != OldColorEnter) return;
                this.BackColor = OldColorEnter;
            }
        }
        Color beforeForceColor = new Color();
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!UseHightLight) return;
            OldColorHover = BackColor;
            BackColor = BackColorHover == Color.Empty ? CommonAppColors.ColorButtonBackColorHover : BackColorHover;
            beforeForceColor = ForeColor;
            ForeColor = ForceColorHover == Color.Empty ? ForeColor : ForceColorHover;
            _oldFont = Font;
        }
   
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!UseHightLight) return;
            BackColor = OldColorHover;
            ForceColorHover = ForeColor;
            ForeColor = beforeForceColor;
            Font = _oldFont;
        }

        public void Clone(Control targetControl)
        {
            // make sure these are the same
            if (GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (var sourceProperty in this.GetType().GetProperties())
            {
                var newValue = sourceProperty.GetValue(this, null);

                var mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }
        #region new custom
      
        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            var curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Parent != null)
                Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (_borderRadius > Height)
                _borderRadius = Height;
        }
        #endregion
    }
}