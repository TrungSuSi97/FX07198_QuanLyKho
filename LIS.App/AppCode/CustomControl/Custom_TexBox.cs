using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;


namespace CustomControl
{
    public partial class Custom_TexBox : TextBox
    {
        Color cForeColor, cBackColor, mForeColor, mBackColor;
        Font cFont, mFont;
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

        bool _isEnter = false, _Onter = false;
        public Custom_TexBox()
        {
            InitializeComponent();
        }
        public Custom_TexBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.ReadOnly == false)
            {
                if (_Onter == false)
                {
                    mForeColor = this.ForeColor;
                    mBackColor = this.BackColor;
                   // mFont = this.Font;
                }
                else
                {
                    mForeColor = cForeColor;
                    mBackColor = cBackColor;
                    mFont = cFont;
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
            if (this.ReadOnly == false)
            {
                if (_Onter == false)
                {
                    this.ForeColor = mForeColor;
                    this.BackColor = mBackColor;
                   // this.Font = mFont;
                }
                _isEnter = false;
            }
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.ReadOnly == false)
            {
                _Onter = true;
                if (_isEnter == false)
                {
                    cForeColor = this.ForeColor;
                    cBackColor = this.BackColor;
                    cFont = this.Font;
                }
                else
                {
                    cForeColor = mForeColor;
                    cBackColor = mBackColor;
                    cFont = mFont;
                }
                this.ForeColor = Color.OrangeRed;
                this.BackColor = Color.Cornsilk;  
                //Color.FromArgb(244, 247, 252);
                //this.Font = new Font(this.Font.Name, 11, FontStyle.Regular);
                this.Invalidate(true);
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.ReadOnly == false)
            {
                this.ForeColor = cForeColor;
                this.BackColor = cBackColor;
              //  this.Font = cFont;
                _Onter = false;
            }

        }
 
    }
}
