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
    [DefaultEvent("OnValueChanged")]
    public class TPHDatePicker : UserControl
    {
        private int borderRadius;

        private int borderSize = 1;

        private ctrls controlStyle;

        private Color dropDownBackColor = Color.White;

        private Color backColor = Color.White;

        private Color iconDropDownColor = Color.MediumSlateBlue;

        private bool customizable = true;

        private TPHTextBox lblDisplay;
        private TPHCheckBox checkBox;

        private IconButton dropDownButton;

        private DateTimePicker mainDateTimePicker;

        [Category("TPH CustomControl")]
        public bool ShowCheckbox
        {
            get { return checkBox.Visible; }
            set { checkBox.Visible = value; }
        }
        [Category("TPH CustomControl")]
        public bool Checked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }

        [Category("TPH CustomControl")]
        public ctrls ControlStyle
        {
            get
            {
                return controlStyle;
            }
            set
            {
                controlStyle = value;
                checkBox.ControlStyle = controlStyle;
                //BorderRadius = borderRadius;
                if (base.DesignMode)
                {
                    SetDefaultColor();
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
            }
        }

        [Category("TPH CustomControl")]
        public Color BoderColor
        {
            get
            {
                return BackColor;
            }
            set
            {
                backColor = value;
                BackColor = backColor;
            }
        }

        [Category("TPH CustomControl")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                base.Padding = new Padding(borderSize);
                OnResize(null);
            }
        }

        [Category("TPH CustomControl")]
        public Color DropDownBackColor
        {
            get
            {
                return dropDownBackColor;
            }
            set
            {
                dropDownBackColor = value;
                lblDisplay.BackColor = dropDownBackColor;
                dropDownButton.BackColor = dropDownBackColor;
                checkBox.BackColor = dropDownBackColor;
            }
        }

        [Description("Set or keep the icon color.")]
        [Category("TPH CustomControl")]
        public Color IconDropDownColor
        {
            get
            {
                return dropDownButton.IconColor;
            }
            set
            {
                iconDropDownColor = value;
                dropDownButton.IconColor = iconDropDownColor;
            }
        }

        //[DefaultValue(0)]
        //[Category("TPH CustomControl")]
        //public int BorderRadius
        //{
        //    get
        //    {
        //        return borderRadius;
        //    }
        //    set
        //    {
        //        borderRadius = value;
        //        if (controlStyle == ctrls.Solid)
        //        {
        //            ppwag.DrawBorder(this, borderRadius);
        //        }
        //        else
        //        {
        //            ppwag.DrawBorder(this, 0);
        //        }
        //    }
        //}

        [Category("TPH CustomControl")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lblDisplay.ForeColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public DateTimePickerFormat Format
        {
            get
            {
                return mainDateTimePicker.Format;
            }
            set
            {
                mainDateTimePicker.Format = value;
                lblDisplay.TextValue = mainDateTimePicker.Text;
            }
        }

        [Category("TPH CustomControl")]
        public string DisplayFormat
        {
            get
            {
                return mainDateTimePicker.CustomFormat;
            }
            set
            {
                mainDateTimePicker.CustomFormat = value;
                lblDisplay.TextValue = mainDateTimePicker.Text;
            }
        }

        [Category("TPH CustomControl")]
        public DateTime? Value
        {
            get
            {
                if (checkBox.Checked)
                    return mainDateTimePicker.Value;
                else
                    return (DateTime?)null;
            }
            set
            {
                if (value == null)
                {
                    checkBox.Checked = false;
                    lblDisplay.TextValue = string.Empty; ;
                }
                else
                {
                    checkBox.Checked = true;
                    mainDateTimePicker.Value = value.Value;
                    lblDisplay.TextValue = mainDateTimePicker.Text;
                }
            }
        }

        [Browsable(false)]
        public override string Text => mainDateTimePicker.Text;

        [Category("TPH CustomControl")]
        public event EventHandler OnValueChanged;
        public TPHDatePicker()
        {
            lblDisplay = new TPHTextBox();
            checkBox = new TPHCheckBox();
            mainDateTimePicker = new DateTimePicker();
            dropDownButton = new IconButton();
            SuspendLayout();
            lblDisplay.Dock = DockStyle.Fill;
           // lblDisplay.FlatStyle = FlatStyle.Flat;
            lblDisplay.Font = new Font("Arial", 10f);
            lblDisplay.BackColor = dropDownBackColor;
            lblDisplay.ForeColor = Color.Gray;
           // lblDisplay.ImageAlign = ContentAlignment.MiddleLeft;
            lblDisplay.Location = new Point(1, 1);
            lblDisplay.Name = "dateText";
            lblDisplay.Padding = new Padding(8, 0, 0, 0);
            //lblDisplay.text = HorizontalAlignment.Center;
            lblDisplay.Click += lblDisplay_Click;
            lblDisplay.KeyDown += lblDisplay_KeyDown;
            lblDisplay.KeyPress += lblDisplay_KeyPress;
            lblDisplay.KeyUp += lblDisplay_KeyUp;
            lblDisplay.MouseEnter += lblDisplay_MouseEnter;
            checkBox.Dock = DockStyle.Left;
            checkBox.ControlStyle = this.controlStyle;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            checkBox.Checked = true;
            checkBox.BackColor = this.dropDownBackColor;
            checkBox.Visible = false;
            dropDownButton.Dock = DockStyle.Right;
            dropDownButton.FlatAppearance.BorderSize = 0;
            dropDownButton.FlatStyle = FlatStyle.Flat;
            dropDownButton.Flip = FlipOrientation.Normal;
            dropDownButton.IconChar = IconChar.CalendarAlt;
            dropDownButton.IconColor = iconDropDownColor;
            dropDownButton.IconSize = 22;
            dropDownButton.Location = new Point(189, 1);
            dropDownButton.BackColor = this.dropDownBackColor;
            dropDownButton.Name = "dropdownArrowIcon";
            dropDownButton.Rotation = 0.0;
            dropDownButton.Size = new Size(30, 30);
            dropDownButton.UseVisualStyleBackColor = false;
            dropDownButton.Cursor = Cursors.Hand;
            dropDownButton.Click += DropDownButton_Click;
            mainDateTimePicker.Name = "datePicker";
            mainDateTimePicker.Size = new Size(100, 1);
            mainDateTimePicker.Location = new Point(2, 2);
            mainDateTimePicker.DropDownAlign = LeftRightAlignment.Right;
            mainDateTimePicker.CloseUp += MainDateTimePicker_CloseUp;
            mainDateTimePicker.ValueChanged += MainDateTimePicker_ValueChanged;
            base.Controls.Add(lblDisplay);
            base.Controls.Add(checkBox);
            base.Controls.Add(dropDownButton);
            base.Controls.Add(mainDateTimePicker);
            base.AutoScaleDimensions = new SizeF(96F, 96F);
            base.AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.MediumSlateBlue;
            MinimumSize = new Size(120, 25);
            base.Padding = new Padding(1);
            base.Size = new Size(260, 32);
            ResumeLayout(performLayout: false);
            OnResize();
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mainDateTimePicker.Checked = checkBox.Checked;
            dropDownButton.Enabled = checkBox.Checked;
            lblDisplay.Enabled = checkBox.Checked;
            if (checkBox.Checked)
                lblDisplay.TextValue = mainDateTimePicker.Text;
            else
                lblDisplay.TextValue = string.Empty;
        }

        private void SetDefaultColor()
        {
            if (customizable)
            {
                return;
            }
            switch (controlStyle)
            {
                case ctrls.Solid:
                    BoderColor = AppearanceStyle.Neptune;
                    BorderSize = 0;
                    lblDisplay.ForeColor = Color.White;
                    dropDownButton.IconColor = Color.White;
                    DropDownBackColor = AppearanceStyle.Neptune;
                    break;
                case ctrls.Glass:
                    dropDownButton.IconColor = AppearanceStyle.Neptune;
                    lblDisplay.ForeColor = AppearanceStyle.LightTextColor;
                    if (base.Parent != null)
                    {
                        DropDownBackColor = base.Parent.BackColor;
                    }
                    if (AppearanceStyle.theme == uuufteme.Dark)
                    {
                        BoderColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 10);
                    }
                    else
                    {
                        BoderColor = AppearanceStyle.LightTextColor;
                    }
                    break;
            }
        }

        private void OnResize()
        {
            mainDateTimePicker.Location = new Point
            {
                X = base.Width - 100,
                Y = dropDownButton.Bottom
            };
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool PostMessage(
                IntPtr hWnd, // handle to destination window
                Int32 msg, // message
                Int32 wParam, // first message parameter
                Int32 lParam // second message parameter
                );
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private void DropDownButton_Click(object sender, EventArgs ev)
        {
            mainDateTimePicker.Focus();
            mainDateTimePicker.BringToFront();
            int x = mainDateTimePicker.Width - 10;
            int y = mainDateTimePicker.Height / 2;
            int lParam = x + y * 0x00010000;
            PostMessage(mainDateTimePicker.Handle, WM_LBUTTONDOWN, 1, lParam);
    
            //SendKeys.Send("{DOWN}");
            if (customizable)
            {
                switch (controlStyle)
                {
                    case ctrls.Solid:
                        dropDownButton.BackColor = kkgegea.hgfhfg(dropDownBackColor, 10);
                        dropDownButton.IconColor = Color.White;
                        break;
                    case ctrls.Glass:
                        dropDownButton.BackColor = backColor;
                        dropDownButton.IconColor = Color.White;
                        break;
                }
                return;
            }
            switch (controlStyle)
            {
                case ctrls.Solid:
                    dropDownButton.BackColor = kkgegea.hgfhfg(AppearanceStyle.Neptune, 10);
                    dropDownButton.IconColor = Color.White;
                    break;
                case ctrls.Glass:
                    dropDownButton.BackColor = AppearanceStyle.Neptune;
                    dropDownButton.IconColor = Color.White;
                    BoderColor = AppearanceStyle.Neptune;
                    break;
            }
        }

        private void MainDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            if (customizable)
            {
                dropDownButton.BackColor = dropDownBackColor;
                dropDownButton.IconColor = iconDropDownColor;
            }
            else
            {
                SetDefaultColor();
            }
        }
        private void MainDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.OnValueChanged != null)
            {
                this.OnValueChanged(sender, e);
            }
            lblDisplay.TextValue = mainDateTimePicker.Text;
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void lblDisplay_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void lblDisplay_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void lblDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void lblDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblDisplay.TextValue = mainDateTimePicker.Text;
            base.Visible = false;
            SetDefaultColor();
            OnResize();
            base.Visible = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            OnResize();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TPHDatePicker
            // 
            this.Name = "TPHDatePicker";
            this.Size = new System.Drawing.Size(150, 20);
            this.ResumeLayout(false);

        }
    }
}
