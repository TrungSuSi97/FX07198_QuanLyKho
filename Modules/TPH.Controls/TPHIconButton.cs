using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace TPH.Controls
{
    public partial class TPHIconButton : IconButton
    {
        public TPHIconButton()
        {
            InitializeComponent();
            base.FlatAppearance.BorderSize = 0;
            base.FlatStyle = FlatStyle.Flat;
            BackColor = CommonAppColors.ColorButtonBackColor;
            base.Flip = FlipOrientation.Normal;
            Font = new Font("Arial", AppearanceStyle.fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = CommonAppColors.ColorButtonForceColor;
            base.IconColor = CommonAppColors.ColorButtonForceColor;
            base.Rotation = 0.0;
            base.Size = new Size(170, 40);
            msbd();
        }
        private ctrls controlStyle = ctrls.Solid;

        private bd buttonStyle = bd.Normal;

        private int borderRadius = 5;

        private int boderSize = 1;

        private Color buttonBorderColor = CommonAppColors.ColorButtonBackColor;

        private static readonly Color mordenBorderColor = ((AppearanceStyle.colorStyle == stekeely.Supernova) ? clors.GetSupernovaColor() : CommonAppColors.ColorButtonForceColor);

        private Color MouseHoverForceColor = CommonAppColors.ColorButtonForceColorHover;
        private Color MouseHoverForceColorBefore = Color.Empty;

        private Color MouseHoverBackColor = CommonAppColors.ColorButtonBackColorHover;
        public Color MouseHoverBackColorBefore = Color.Empty;

        private Color MouseHoverIconColor = CommonAppColors.ColorButtonForceColorHover;
        public Color MouseHoverIconColorBefore = Color.Empty;

        private bool useHoverColor = true;

        [Browsable(false)]
        public Size _1_Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
            }
        }

        [Category("TPH CustomControl")]
        public bd ButtonStyle
        {
            get
            {
                return buttonStyle;
            }
            set
            {
                buttonStyle = value;
                if (buttonStyle != bd.Custom)
                {
                    msbd();
                }
            }
        }

        [Category("TPH CustomControl")]
        public ctrls ButtonBackColorStyle
        {
            get
            {
                return controlStyle;
            }
            set
            {
                if (buttonStyle != bd.Custom)
                {
                    controlStyle = value;
                    mstb();
                }
            }
        }

        [Category("TPH CustomControl")]
        public Color ButtonBorderColor
        {
            get
            {
                return buttonBorderColor;
            }
            set
            {
                buttonBorderColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public int ButtonBorderSize
        {
            get
            {
                return boderSize;
            }
            set
            {
                boderSize = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public int ButtonRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    int num = base.Height / 2;
                    if (value <= num)
                    {
                        borderRadius = value;
                    }
                    else
                    {
                        borderRadius = num;
                    }
                    Invalidate();
                }
            }
        }
        [Category("TPH CustomControl")]
        public bool UseHoverColor
        {
            get => useHoverColor;

            set => useHoverColor = value;
        }

        private void mstb()
        {
            if (boderSize < 0)
            {
                boderSize = 0;
            }
            ForeColor = buttonBorderColor;
            base.IconColor = buttonBorderColor;
        }

        private void msbd()
        {
            switch (buttonStyle)
            {
                case bd.Normal:
                    msnb();
                    maas();
                    break;
                case bd.IconButton:
                    msic();
                    if (base.IconChar == IconChar.None || base.IconChar == IconChar.Check || base.IconChar == IconChar.TrashAlt || base.IconChar == IconChar.TimesCircle)
                    {
                        Text = string.Empty;
                        //base.IconChar = IconChar.Magento;
                    }
                    maas();
                    break;
                case bd.Metro:
                    msmb();
                    //if (base.IconChar == IconChar.None || base.IconChar == IconChar.Check || base.IconChar == IconChar.TrashAlt || base.IconChar == IconChar.TimesCircle)
                    //{
                    //    base.IconChar = IconChar.Magento;
                    //}
                    maas();
                    break;
                case bd.Confirm:
                    msic();
                    base.IconChar = IconChar.Check;
                    Text = "Confirm";
                    buttonBorderColor = clors.Confirm;
                    break;
                case bd.Delete:
                    msic();
                    base.IconChar = IconChar.TrashAlt;
                    Text = "Delete";
                    buttonBorderColor = clors.Delete;
                    break;
                case bd.Cancel:
                    msic();
                    base.IconChar = IconChar.TimesCircle;
                    Text = "Cancel";
                    buttonBorderColor = clors.Cancel;
                    break;
            }
            mstb();
        }

        private void msnb()
        {
            base.TextImageRelation = TextImageRelation.Overlay;
            TextAlign = ContentAlignment.MiddleCenter;
            base.IconChar = IconChar.None;
            //if (base.DesignMode)
            //{
            //    base.Size = new Size(160, 40);
            //}
        }

        private void msic()
        {
            TextAlign = ContentAlignment.MiddleRight;
            base.ImageAlign = ContentAlignment.MiddleCenter;
            base.TextImageRelation = TextImageRelation.ImageBeforeText;
            //if (base.DesignMode)
            //{
            //    base.Size = new Size(160, 40);
            //    base.IconSize = 24;
            //}
        }

        private void msmb()
        {
            TextAlign = ContentAlignment.BottomCenter;
            base.ImageAlign = ContentAlignment.MiddleCenter;
            base.TextImageRelation = TextImageRelation.ImageAboveText;
            //if (base.DesignMode)
            //{
            //    base.Size = new Size(110, 110);
            //    base.IconSize = 50;
            //}
        }

        private void maas()
        {
            if (buttonStyle == bd.Normal || buttonStyle == bd.IconButton || buttonStyle == bd.Metro)
            {
                //if (appeagtr.b == stekeely.Supernova)
                //{
                buttonBorderColor = mordenBorderColor;
                //}
                //else
                //{
                //    buttonBorderColor = appeagtr.d;
                //}
            }
            //base.FlatAppearance.MouseOverBackColor = kkgegea.hgfhfg(BackColor, 12);
            //base.FlatAppearance.MouseDownBackColor = kkgegea.hgfhfg(BackColor, 6);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics graphics = pevent.Graphics;
            ppwag.DrawBorderRadius(this, borderRadius, graphics, buttonBorderColor, boderSize);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int num = base.Height / 2;
            if (borderRadius > num)
            {
                borderRadius = num;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            maas();
        }

      

        private void TPHIconButton_MouseHover(object sender, EventArgs e)
        {
            if (useHoverColor)
            {
                MouseHoverForceColorBefore = ForeColor;
                MouseHoverIconColorBefore = IconColor;
                MouseHoverBackColorBefore = BackColor;
                this.ForeColor = MouseHoverForceColor;
                this.IconColor = MouseHoverIconColor;
                this.BackColor = MouseHoverBackColor;
            }
        }

        private void TPHIconButton_MouseLeave(object sender, EventArgs e)
        {
            if (useHoverColor)
            {
                if (MouseHoverForceColorBefore != Color.Empty && this.ForeColor == MouseHoverForceColor)
                    this.ForeColor = MouseHoverForceColorBefore;
                if (MouseHoverIconColorBefore != Color.Empty && this.IconColor == MouseHoverIconColor)
                    this.IconColor = MouseHoverIconColorBefore;
                if (MouseHoverBackColorBefore != Color.Empty && this.BackColor == MouseHoverBackColor)
                    this.BackColor = MouseHoverBackColorBefore;
            }
        }
    }
}
