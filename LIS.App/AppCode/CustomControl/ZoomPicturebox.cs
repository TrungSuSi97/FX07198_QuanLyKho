using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControl
{
    public partial class ZoomPicturebox : PictureBox
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

        private bool _UseZoom = false;

        public bool UseZoom
        {
            get { return _UseZoom; }
            set { _UseZoom = value; }
        }

        public ZoomPicturebox()
        {
            InitializeComponent();
        }
        private Control _c = null;

        public Control GetControl
        {
            get { return _c; }
            set { _c = value; }
        }
        FontStyle _oldlinkStyle;
        Color _oldlinkForceColor;
        public ZoomPicturebox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        private void SetFont(Control c, bool f)
        {
            if (f)
            {
                _oldlinkStyle = c.Font.Style;
                if (_oldlinkForceColor == null)
                    _oldlinkForceColor = c.ForeColor;
                if(_oldlinkStyle != FontStyle.Bold && c.Font.Style != FontStyle.Bold)
                c.ForeColor = Color.OrangeRed;
                c.Font = new Font(c.Font.Name, c.Font.Size, FontStyle.Bold);
            }
            else
            {
                c.ForeColor = _oldlinkForceColor;
                c.Font = new Font(c.Font.Name, c.Font.Size, _oldlinkStyle);
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_UseZoom)
            {
                this.Size = new Size(this.Size.Width + 6, this.Size.Height + 6);
                this.Location = new Point(this.Location.X - 3, this.Location.Y - 3);
                this.Cursor = Cursors.Hand;
                if (_c != null)
                    SetFont(_c, true);
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_UseZoom)
            {
                this.Size = new Size(this.Size.Width - 6, this.Size.Height - 6);
                this.Location = new Point(this.Location.X + 3, this.Location.Y + 3);
                if (_c != null)
                    SetFont(_c, false);
            }
        }
    }
}
