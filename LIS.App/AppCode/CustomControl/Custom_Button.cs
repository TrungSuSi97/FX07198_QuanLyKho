using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace CustomControl
{
    public partial class Custom_Button : Button
    {
        public Custom_Button()
        {
            InitializeComponent();
            _OldColor = ForeColor;
        }

        bool _UseHightLight = true;

        public bool UseHightLight
        {
            get { return _UseHightLight; }
            set { _UseHightLight = value; }
        }

        private Color _OldColor;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (_UseHightLight)
            {
                if (this.ForeColor == _OldColor)
                {
                    _OldColor = this.ForeColor;
                    this.ForeColor = Color.Crimson;
                    this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
                }
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (_UseHightLight)
            {
                this.ForeColor = _OldColor;
                this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_UseHightLight)
            {

                _OldColor = this.ForeColor;
                this.ForeColor = Color.Crimson;
                this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
                this.Cursor = Cursors.Hand;

            }

        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_UseHightLight)
            {
                this.ForeColor = _OldColor;
                this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
            }

        }
        public void Clone(Control targetControl)
        {
            // make sure these are the same
            if (this.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (PropertyInfo sourceProperty in this.GetType().GetProperties())
            {
                object newValue = sourceProperty.GetValue(this, null);

                MethodInfo mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }
    }
}
