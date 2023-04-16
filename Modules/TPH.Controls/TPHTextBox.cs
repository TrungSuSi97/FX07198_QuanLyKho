using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    [DefaultEvent("onTextChanged")]
    public class TPHTextBox : UserControl
    {
        private tbs a;

        private Color ForeColorMain;

        private Color c;

        private Color d;

        private int f = 2;

        private int g = 0;

        private int maxLenght = 32767;

        private string passWordchar;

        private bool j;

        private bool usePasswordSystem;

        private bool customizable;

        private static int m = 7;

        private TPHTransparentTextBox mainTextBox;

        [Category("TPH CustomControl")]
        public tbs TextBoxStyle
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                if (base.DesignMode)
                {
                    CheckCustomizable();
                    Invalidate();
                }
            }
        }

        [Category("TPH CustomControl")]
        public bool Customizable
        {
            get
            {
                return customizable;
            }
            set
            {
                customizable = value;
                CheckCustomizable();
            }
        }

        [Category("TPH CustomControl")]
        public Color BackGroundColor
        {
            get
            {
                return BackColor;
            }
            set
            {
                BackColor = value;
                mainTextBox.BackColor = value;
                if (value != Color.Transparent)
                    mainTextBox.BackAlpha = 255;
            }
        }

        [Category("TPH CustomControl")]
        public Color BorderColor
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public int BorderSize
        {
            get
            {
                return f;
            }
            set
            {
                if (value > 0 || value < 5)
                {
                    f = value;
                    Invalidate();
                }
            }
        }

        [Category("TPH CustomControl")]
        public int BorderRadius
        {
            get
            {
                return g;
            }
            set
            {
                if (value >= 0)
                {
                    g = value;
                    Invalidate();
                }
            }
        }
        [Category("TPH CustomControl")]
        public bool PassordChar
        {
            get
            {
                return mainTextBox.UseSystemPasswordChar;
            }
            set
            {
                mainTextBox.UseSystemPasswordChar = value;
            }
        }

        [Category("TPH CustomControl")]
        public bool Multiline
        {
            get
            {
                return mainTextBox.Multiline;
            }
            set
            {
                mainTextBox.Multiline = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color TextForceColor
        {
            get
            {
                return ForeColorMain;
            }
            set
            {
                ForeColorMain = value;
                mainTextBox.ForeColor = value;
                Invalidate();
            }
        }

        [Category("TPH CustomControl")]
        public char PasswordChar
        {
            get
            {
                return mainTextBox.PasswordChar;
            }
            set
            {
                mainTextBox.PasswordChar = value;
            }
        }

        [Category("TPH CustomControl")]
        [DefaultValue(32767)]
        public int MaxLenght
        {
            get
            {
                return maxLenght;
            }
            set
            {
                maxLenght = value;
                mainTextBox.MaxLength = maxLenght;
            }
        }

        [Category("TPH CustomControl")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                mainTextBox.Font = value;
                if (base.DesignMode)
                {
                    SetMultiline();
                }
            }
        }

        [Description("Gets or sets the text in the text box")]
        [Category("TPH CustomControl")]
        public string TextValue
        {
            get
            {

                return mainTextBox.Text;
            }
            set
            {
                mainTextBox.Text = value;
            }
        }

        [Localizable(true)]
        [Category("TPH CustomControl")]
        public ScrollBars ScrollBarsType
        {
            get
            {
                return mainTextBox.ScrollBars;
            }
            set
            {
                mainTextBox.ScrollBars = value;
            }
        }

        [Browsable(false)]
        public new Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = new Padding(m);
            }
        }

        [Category("TPH CustomControl")]
        public event EventHandler onTextChanged;

        public TPHTextBox()
        {
            DoubleBuffered = true;
            mainTextBox = new TPHTransparentTextBox();
            SuspendLayout();
            mainTextBox.Location = new Point(2, 3);
            mainTextBox.Dock = DockStyle.Fill;
            mainTextBox.BackColor = AppearanceStyle.LightBackground;
            mainTextBox.BorderStyle = BorderStyle.None;
            mainTextBox.Size = new Size(230, 16);
            mainTextBox.Enter += TextBox_Enter;
            mainTextBox.Leave += TextBox_Leave;
            mainTextBox.TextChanged += TextBox_TextChanged;
            mainTextBox.Click += TPHTextBox_Click;
            mainTextBox.KeyDown += TPHTextBox_KeyDown;
            mainTextBox.KeyPress += TPHTextBox_KeyPress;
            mainTextBox.KeyUp += TPHTextBox_KeyUp;
            mainTextBox.MouseEnter += TPHTextBox_MouseEnter;
            base.Controls.Add(mainTextBox);
            base.AutoScaleDimensions = new SizeF(96F, 96F);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = (BackColor.Equals(Color.Empty) ? AppearanceStyle.Neptune : BackColor);
            Padding = new Padding(m);
            base.Size = new Size(250, 32);
            Font = new Font(AppearanceStyle.fontName, AppearanceStyle.fontSize);
            TextForceColor = (TextForceColor.Equals(Color.Empty) ? AppearanceStyle.LightBackground : TextForceColor);
            ResumeLayout(performLayout: false);
        }

        private void CheckSetTextboxPasswordChar()
        {
            if (string.IsNullOrWhiteSpace(mainTextBox.Text))
            {
                j = true;
                mainTextBox.Text = passWordchar;
                mainTextBox.ForeColor = c;
                if (usePasswordSystem)
                {
                    mainTextBox.UseSystemPasswordChar = false;
                }
            }
        }

        private void SetDefaultColor()
        {
            j = false;
            mainTextBox.Text = "";
            if (customizable)
            {
                mainTextBox.ForeColor = ForeColorMain;
            }
            else
            {
                mainTextBox.ForeColor = AppearanceStyle.LightTextColor;
            }
            if (usePasswordSystem)
            {
                mainTextBox.UseSystemPasswordChar = true;
            }
        }

        private void SetMultiline()
        {
            if (!Multiline)
            {
                int height = TextRenderer.MeasureText("Text", Font).Height + 1;
                mainTextBox.Multiline = true;
                mainTextBox.MinimumSize = new Size(0, height);
                mainTextBox.Multiline = false;
                base.Height = mainTextBox.Height + m * 2;
            }
        }

        private void aghrth()
        {
            int num = base.Height / 2;
            if (g > num)
            {
                g = num;
            }
        }

        private void CheckCustomizable()
        {
            if (customizable)
            {
                if (j)
                {
                    mainTextBox.ForeColor = c;
                }
                else
                {
                    mainTextBox.ForeColor = ForeColorMain;
                }
                return;
            }
            if (AppearanceStyle.theme == uuufteme.Dark)
            {
                c = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 5);
            }
            else
            {
                c = Color.DarkGray;
            }
            if (a == tbs.MatteBorder || a == tbs.MatteLine)
            {
                if (AppearanceStyle.theme == uuufteme.Dark)
                {
                    d = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 10);
                }
                else
                {
                    d = AppearanceStyle.LightTextColor;
                }
            }
            else
            {
                d = AppearanceStyle.Neptune;
            }
            BackGroundColor = AppearanceStyle.LightBackground;
            if (j)
            {
                mainTextBox.ForeColor = c;
            }
            else
            {
                mainTextBox.ForeColor = AppearanceStyle.LightTextColor;
            }
        }

        public void Clear()
        {
            TextValue = string.Empty;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (j)
            {
                SetDefaultColor();
            }
            if (!customizable)
            {
                BorderColor = kkgegea.gegeagge(AppearanceStyle.Neptune, 15);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (passWordchar != "")
            {
                CheckSetTextboxPasswordChar();
            }
            if (!customizable)
            {
                CheckCustomizable();
                Invalidate();
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = TextValue;
            if (this.onTextChanged != null)
            {
                this.onTextChanged(sender, e);
            }
        }

        private void TPHTextBox_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void TPHTextBox_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void TPHTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void TPHTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void TPHTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            if (a == tbs.MatteBorder || a == tbs.FlaringBorder)
            {
                ppwag.DrawBorderRadius(this, g, graphics, d, f);
                if (g > 15)
                {
                    if (!Multiline)
                    {
                        ppwag.DrawBorder(mainTextBox, f * 2);
                    }
                    else
                    {
                        ppwag.DrawBorder(mainTextBox, g - f * 2);
                    }
                }
            }
            else
            {
                using (Pen pen = new Pen(d, f))
                    graphics.DrawLine(pen, 0f, (float)base.Height - 1f, base.Width, (float)base.Height - 1f);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (base.DesignMode)
            {
                SetMultiline();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CheckCustomizable();
            SetMultiline();
            aghrth();
        }
    }
}
