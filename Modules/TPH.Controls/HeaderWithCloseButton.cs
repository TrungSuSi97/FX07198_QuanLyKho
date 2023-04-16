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
    public partial class HeaderWithCloseButton : UserControl
    {
        public HeaderWithCloseButton()
        {
            InitializeComponent();
        }
        public event EventHandler ButtonCloseClick;
        public event EventHandler HeaderClick;
        public string TabName = string.Empty;
        private readonly TPHIconButton _close = new TPHIconButton();
        public Color SetBackColor
        {
            get => pnHeader.BackColor;
            set => pnHeader.BackColor = value;
        }
        public Color SetForeColor
        {
            get => pnHeader.ForeColor;
            set => pnHeader.ForeColor = value;
        }
        public void CreateNewTitle(string title, string formName = "")
        {
            var label = new Label {Text = title};
            label.Click += Label_Click;
            pnHeader.Controls.Add(label);
            label.AutoSize = true;
            label.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            var w = (int)label.Width + 10;
            label.AutoSize = false;
            Width = w;
            if (!formName.Equals("FrmHome"))
            {
                CreateCloseButton(this);
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Padding = new Padding(5, 0, 0, 0);
            }
            else
            {
                label.TextAlign = ContentAlignment.MiddleCenter;
            }
            label.Dock = DockStyle.Fill;
        }
        private float MeasureWidth(Control lbl)
        {
            using (var g = CreateGraphics())
            {
                var size = g.MeasureString(lbl.Text, lbl.Font);
                return size.Width;
            }
        }

        public void CreateNewTitle(string title, IconChar iconChar)
        {
   
            var label = new Label();
            label.Click += Label_Click;
            pnHeader.Controls.Add(label);
            label.Text = title;
          
            label.Dock = DockStyle.Left;
            var pic = new IconButton();
            pic.Text = string.Empty;
            pic.IconChar = iconChar;
            pic.IconColor = Color.Orange;
            pic.Width = 24;
            pic.FlatAppearance.BorderSize = 0;
            pnHeader.Controls.Add(pic);
            pic.Dock = DockStyle.Left;
            this.Width = (int)MeasureWidth(label) + pic.Width + 20;
            this.Padding = new Padding(3);
            CreateCloseButton(this);
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Dock = DockStyle.Fill;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            HeaderClick?.Invoke(this, e);
        }

        public void CreateNewTitle(string title, Image icon)
        {
            var label = new Label();
            label.Click += Label_Click;
            pnHeader.Controls.Add(label);
            label.Text = title;
            label.Dock = DockStyle.Left;
            label.MouseHover += HeaderWithCloseButton_MouseHover;

            var pic = new PictureBox();
            pic.Image = icon;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Width = 24;
            pnHeader.Controls.Add(pic);
            pic.Dock = DockStyle.Left;
            this.Width = (int)MeasureWidth(label) + pic.Width + 20;
            this.Padding = new Padding(3);
            CreateCloseButton(this);
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Dock = DockStyle.Fill;
        }

        private void CreateCloseButton(Control mainControl)
        {
            _close.Text = string.Empty;
            _close.IconChar = IconChar.Times;
            _close.IconColor = Color.Red;
            _close.BackColor = Color.Transparent;
            _close.IconSize = 16;
            _close.ButtonBorderSize = 0;
            _close.ButtonRadius = 0;
            _close.ImageAlign = ContentAlignment.MiddleCenter;
            _close.FlatAppearance.BorderSize = 0;
            _close.FlatAppearance.MouseDownBackColor = CommonAppColors.ColorButtonMenuSelectedBackColor; //Color.FromArgb(234, 182, 118);
            _close.FlatAppearance.MouseOverBackColor = CommonAppColors.ColorButtonMenuSelectedBackColor;
            _close.FlatStyle = FlatStyle.Flat;
            _close.UseHoverColor = false;
            _close.Padding = new Padding(0, 2, 0, 0);
            //_close.Image = global::TPH.Controls.Properties.Resources.close_delete_icon;
            _close.Width = 24;
            _close.Height = 24;
            pnHeader.Controls.Add(_close);
            _close.Dock = DockStyle.Right;
            _close.Click += Close_Click;
            _close.BringToFront();
            mainControl.Width += _close.Width;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            ButtonCloseClick?.Invoke(this, e);
        }

        private void HeaderWithCloseButton_MouseHover(object sender, EventArgs e)
        {
            //if (close != null)
            //{
            //    close.Visible = true;
            //    close.BringToFront();
            //}
        }

        private void HeaderWithCloseButton_MouseLeave(object sender, EventArgs e)
        {
            //if (close != null)
            //    close.Visible = false;
        }

        private void HeaderWithCloseButton_Click(object sender, EventArgs e)
        {
            HeaderClick?.Invoke(this, e);
        }
    }
}
