using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Drawing.Design;

namespace TPH.Controls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public partial class TPHCombobox : UserControl
    {
        private ctrls controlStyle;

        private Color comboboxBackColor;

        private Color c;

        private Color borderColor;

        private int comboboxBoderSize = 1;

        private bool customizable = true;

        private ComboBox comboboxMain;

        private IconButton buttonDropDown;

        private Label p;

        [Category("TPH CutomControl -  Appearance")]
        public ctrls ControlStyle
        {
            get
            {
                return controlStyle;
            }
            set
            {
                controlStyle = value;
                if (base.DesignMode)
                {
                    SetDefaultColor();
                }
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public bool Customizable
        {
            get
            {
                return customizable;
            }
            set
            {
                customizable = value;
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public Color ComboboxBackColor
        {
            get
            {
                return comboboxBackColor;
            }
            set
            {
                comboboxBackColor = value;
                p.BackColor = comboboxBackColor;
                buttonDropDown.BackColor = comboboxBackColor;
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public Color BorderColor
        {
            get
            {
                return BackColor;
            }
            set
            {
                borderColor = value;
                BackColor = borderColor;
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public int ComboboxBoderSize
        {
            get
            {
                return comboboxBoderSize;
            }
            set
            {
                comboboxBoderSize = value;
                base.Padding = new Padding(comboboxBoderSize);
                OnResize(null);
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public Color ButtonDropDownColor
        {
            get
            {
                return buttonDropDown.IconColor;
            }
            set
            {
                c = value;
                buttonDropDown.IconColor = c;
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return comboboxMain.DropDownStyle;
            }
            set
            {
                comboboxMain.DropDownStyle = value;
                if (comboboxMain.DropDownStyle == ComboBoxStyle.Simple)
                {
                    buttonDropDown.Visible = false;
                }
                else
                {
                    buttonDropDown.Visible = true;
                }
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public Color PopupBackColor
        {
            get
            {
                return comboboxMain.BackColor;
            }
            set
            {
                comboboxMain.BackColor = value;
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public Color PopupForceColor
        {
            get
            {
                return comboboxMain.ForeColor;
            }
            set
            {
                comboboxMain.ForeColor = value;
            }
        }

        [Category("TPH CutomControl -  Appearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                p.ForeColor = value;
            }
        }

        [Localizable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design", typeof(UITypeEditor))]
        [Category("TPH CutomControl -  Data")]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items => comboboxMain.Items;

        [Category("TPH CutomControl -  Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get
            {
                return comboboxMain.DataSource;
            }
            set
            {
                comboboxMain.DataSource = value;
            }
        }

        [Category("TPH CutomControl -  Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design")]
        public string DisplayMember
        {
            get
            {
                return comboboxMain.DisplayMember;
            }
            set
            {
                comboboxMain.DisplayMember = value;
            }
        }

        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", typeof(UITypeEditor))]
        [Category("TPH CutomControl -  Data")]
        [DefaultValue("")]
        public string ValueMember
        {
            get
            {
                return comboboxMain.ValueMember;
            }
            set
            {
                comboboxMain.ValueMember = value;
            }
        }

        [Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return comboboxMain.SelectedIndex;
            }
            set
            {
                if (value >= 0)
                {
                    comboboxMain.SelectedIndex = value;
                }
            }
        }

        [Browsable(false)]
        public object SelectedValue => comboboxMain.SelectedValue;

        [Browsable(false)]
        public object SelectedItem => comboboxMain.SelectedItem;

        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("TPH CutomControl -  Data AC")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Browsable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return comboboxMain.AutoCompleteCustomSource;
            }
            set
            {
                comboboxMain.AutoCompleteCustomSource = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("TPH CutomControl -  Data AC")]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return comboboxMain.AutoCompleteMode;
            }
            set
            {
                comboboxMain.AutoCompleteMode = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("TPH CutomControl -  Data AC")]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return comboboxMain.AutoCompleteSource;
            }
            set
            {
                comboboxMain.AutoCompleteSource = value;
            }
        }

        public new string Text
        {
            get
            {
                return p.Text;
            }
            set
            {
                p.Text = value;
            }
        }

        [Category("TPH CustomControl")]
        public event EventHandler OnSelectedIndexChanged;

        public TPHCombobox()
        {
            comboboxMain = new ComboBox();
            buttonDropDown = new IconButton();
            p = new Label();
            SuspendLayout();
            comboboxMain.Font = new Font("Arial", 9.5f);
            comboboxMain.FormattingEnabled = true;
            comboboxMain.Size = new Size(170, 21);
            comboboxMain.SelectedIndexChanged += juyyu;
            comboboxMain.DropDownClosed += yty;
            comboboxMain.TextChanged += kjh;
            buttonDropDown.FlatStyle = FlatStyle.Flat;
            buttonDropDown.FlatAppearance.BorderSize = 0;
            buttonDropDown.Size = new Size(30, 30);
            buttonDropDown.Dock = DockStyle.Right;
            buttonDropDown.BackColor = Color.WhiteSmoke;
            buttonDropDown.IconChar = IconChar.AngleDown;
            buttonDropDown.IconColor = Color.MediumSlateBlue;
            buttonDropDown.IconSize = 22;
            buttonDropDown.Location = new Point(169, 1);
            buttonDropDown.Cursor = Cursors.Hand;
            buttonDropDown.Click += ykigfbhgf;
            p.BackColor = Color.WhiteSmoke;
            p.Dock = DockStyle.Fill;
            p.Location = new Point(1, 1);
            p.Padding = new Padding(8, 0, 0, 0);
            p.Size = new Size(168, 30);
            p.TextAlign = ContentAlignment.MiddleLeft;
            p.Text = "";
            p.Font = new Font(AppearanceStyle.fontName, AppearanceStyle.fontSize);
            p.Click += jt;
            p.KeyDown += rhrth;
            p.KeyPress += qwdq;
            p.KeyUp += jtjtyj;
            p.MouseEnter += juyjyuj;
            base.AutoScaleDimensions = new SizeF(96F, 96F);
            base.AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.MediumSlateBlue;
            base.Padding = new Padding(1);
            base.Size = new Size(200, 32);
            base.Controls.Add(p);
            base.Controls.Add(buttonDropDown);
            base.Controls.Add(comboboxMain);
            ResumeLayout(performLayout: false);
        }

        private void SetDefaultColor()
        {
            if (customizable)
            {
                return;
            }
            comboboxMain.ForeColor = AppearanceStyle.LightTextColor;
            comboboxMain.BackColor = AppearanceStyle.LightItemBackground;
            switch (controlStyle)
            {
                case ctrls.Solid:
                    BorderColor = AppearanceStyle.Neptune;
                    ComboboxBoderSize = 0;
                    p.ForeColor = Color.White;
                    buttonDropDown.IconColor = Color.White;
                    ComboboxBackColor = AppearanceStyle.Neptune;
                    break;
                case ctrls.Glass:
                    buttonDropDown.IconColor = AppearanceStyle.Neptune;
                    p.ForeColor = AppearanceStyle.LightTextColor;
                    if (base.Parent != null)
                    {
                        ComboboxBackColor = base.Parent.BackColor;
                    }
                    if (AppearanceStyle.theme == uuufteme.Dark)
                    {
                        BorderColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 10);
                    }
                    else
                    {
                        BorderColor = AppearanceStyle.LightTextColor;
                    }
                    break;
            }
        }

        public void Clear()
        {
            p.Text = "";
            comboboxMain.Items.Clear();
        }

        private void kjh(object sender, EventArgs e)
        {
            p.Text = comboboxMain.Text;
        }

        private void ykigfbhgf(object sender, EventArgs e)
        {
            comboboxMain.Select();
            comboboxMain.DroppedDown = true;
            if (customizable)
            {
                switch (controlStyle)
                {
                    case ctrls.Solid:
                        buttonDropDown.BackColor = kkgegea.hgfhfg(comboboxBackColor, 10);
                        buttonDropDown.IconColor = Color.White;
                        break;
                    case ctrls.Glass:
                        buttonDropDown.BackColor = borderColor;
                        buttonDropDown.IconColor = Color.White;
                        break;
                }
                return;
            }
            switch (controlStyle)
            {
                case ctrls.Solid:
                    buttonDropDown.BackColor = kkgegea.hgfhfg(AppearanceStyle.Neptune, 10);
                    buttonDropDown.IconColor = Color.White;
                    break;
                case ctrls.Glass:
                    buttonDropDown.BackColor = AppearanceStyle.Neptune;
                    buttonDropDown.IconColor = Color.White;
                    BorderColor = AppearanceStyle.Neptune;
                    break;
            }
        }

        private void yty(object sender, EventArgs e)
        {
            if (customizable)
            {
                buttonDropDown.BackColor = comboboxBackColor;
                buttonDropDown.IconColor = c;
            }
            else
            {
                SetDefaultColor();
            }
        }

        private void juyyu(object sender, EventArgs e)
        {
            if (this.OnSelectedIndexChanged != null)
            {
                this.OnSelectedIndexChanged(comboboxMain, e);
            }
        }

        private void jt(object sender, EventArgs e)
        {
            OnClick(e);
            comboboxMain.Select();
        }

        private void juyjyuj(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void jtjtyj(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void qwdq(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void rhrth(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            comboboxMain.Width = p.Width;
            comboboxMain.Location = new Point(base.Width - comboboxMain.Width - base.Padding.Right, p.Bottom - comboboxMain.Height);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.Visible = false;
            SetDefaultColor();
            base.Visible = true;
        }
    }
}
