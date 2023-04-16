using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomZoomPicturebox : PictureBox
    {
        //Value for binding
        public object OldValue { get; set; }

        private string _bindFieldName = "";

        public string BindFieldName
        {
            get { return _bindFieldName; }
            set { _bindFieldName = value; }
        }

        public bool UseZoom { get; set; }

        public CustomZoomPicturebox()
        {
            UseZoom = false;
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
        public CustomZoomPicturebox(IContainer container)
        {
            UseZoom = false;
            container.Add(this);

            InitializeComponent();
        }
        private void SetFont(Control c, bool f)
        {
            if (f)
            {
                _oldlinkStyle = c.Font.Style;
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
            if (UseZoom)
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
            if (UseZoom)
            {
                this.Size = new Size(this.Size.Width - 6, this.Size.Height - 6);
                this.Location = new Point(this.Location.X + 3, this.Location.Y + 3);
                if (_c != null)
                    SetFont(_c, false);
            }
        }
    }
}