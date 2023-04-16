using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomTextBox : TextBox
    {
        Color _cForeColor, _cBackColor, _mForeColor, _mBackColor;
        Font _cFont, _mFont;
        private bool useFocusColor = true;
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

        public bool UseFocusColor
        {
            get
            {
                return useFocusColor;
            }

            set
            {
                useFocusColor = value;
            }
        }

        public Color ForceColorEnter
        {
            get
            {
                return forceColorEnter;
            }

            set
            {
                forceColorEnter = value;
            }
        }

        public Color BackColorEnter
        {
            get
            {
                return backColorEnter;
            }

            set
            {
                backColorEnter = value;
            }
        }

        private Color forceColorEnter = Color.DarkRed;
        private Color backColorEnter = Color.Yellow;

        bool _isEnter = false, _onLeave = false;
        public CustomTextBox()
        {
            InitializeComponent();
        }
        public CustomTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!this.ReadOnly && useFocusColor)
            {
                if (_onLeave == false)
                {
                    _mForeColor = this.ForeColor;
                    _mBackColor = this.BackColor;
                   // mFont = this.Font;
                }
                else
                {
                    _mForeColor = _cForeColor;
                    _mBackColor = _cBackColor;
                    _mFont = _cFont;
                }
                _isEnter = true;
                this.ForeColor = Color.OrangeRed;
                //this.Font = new Font(this.Font.Name, 11, FontStyle.Regular);
                this.Invalidate(true);
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.ReadOnly && useFocusColor)
            {
                if (_onLeave == false)
                {
                    this.ForeColor = _mForeColor;
                    this.BackColor = _mBackColor;
                   // this.Font = mFont;
                }
                _isEnter = false;
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (!this.ReadOnly && useFocusColor)
            {
                _onLeave = true;
                if (_isEnter == false)
                {
                    _cForeColor = this.ForeColor;
                    _cBackColor = this.BackColor;
                    _cFont = this.Font;
                }
                else
                {
                    _cForeColor = _mForeColor;
                    _cBackColor = _mBackColor;
                    _cFont = _mFont;
                }
                this.ForeColor = forceColorEnter;
                this.BackColor = backColorEnter;  
                //Color.FromArgb(244, 247, 252);
                //this.Font = new Font(this.Font.Name, 11, FontStyle.Regular);
                this.Invalidate(true);
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (!this.ReadOnly && useFocusColor)
            {
                this.ForeColor = _cForeColor;
                this.BackColor = _cBackColor;
              //  this.Font = cFont;
                _onLeave = false;
            }
        }
    }
}
