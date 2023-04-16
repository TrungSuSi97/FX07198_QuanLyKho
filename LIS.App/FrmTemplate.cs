using DevExpress.XtraGrid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using System.Runtime.InteropServices;
using System.Reflection;

namespace TPH.LIS.App
{
    public partial class FrmTemplate : DevExpress.XtraEditors.XtraForm
    {
        private bool useMinimize = true;
        private bool useMaximize = true;
        private bool useFormControl = true;
        private bool FirstLoad = true;
        public bool UseMinimize
        {
            get { return useMinimize; }
            set
            {
                useMinimize = value;
                btnMinimize.Visible = useMinimize;
            }
        }
        public bool UseMaximize
        {
            get { return useMaximize; }
            set
            {
                useMaximize = value;
                btnMaximize.Visible = value;

            }
        }
        public bool UseFormControl
        {
            get { return useFormControl; }
            set
            {
                useFormControl = value;
                pnFormControl.Visible = value;
            }
        }
        public bool MoveForm { get; set; } = true;
        public int BorderSize
        {
            get
            {
                return borderSize;
            }

            set
            {
                borderSize = value;
            }
        }

        public Size FormSize
        {
            get
            {
                return formSize;
            }

            set
            {
                formSize = value;
            }
        }

        //Fields form
        private int borderSize = 1;
        private Size formSize;
        private Point LastLocation = new Point(0, 0);
        public Size DefaultFormSize = new Size(1200, 700);
        public FrmTemplate()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.BackColor = CommonAppColors.ColorAppFormColor2;
            pnContaint.BackColor = CommonAppColors.ColorAppFormColor;
            //pnLabel.BackColor = CommonAppColors.ColorMainAppColor;
            //pnLabel.TopColor = CommonAppColors.ColorMainAppColor;
           // pnLabel.BottomColor = CommonAppColors.ColorMainAppColor;
            lblTitle.ForeColor = CommonAppColors.ColorFormTextCaption;
            pnMenu.Visible = _hienThiMenu;
            //xtraScrollableControlMain.BackColor = CommonAppColors.ColorMainAppColor;
            // Creating a Global culture specific to our application.
            System.Globalization.CultureInfo cultureInfo =
                new System.Globalization.CultureInfo("en-US");
            // Creating the DateTime Information specific to our application.
            System.Globalization.DateTimeFormatInfo dateTimeInfo =
                new System.Globalization.DateTimeFormatInfo();
            // Defining various date and time formats.
            //dateTimeInfo.DateSeparator = "/";
            //dateTimeInfo.LongDatePattern = "dd/MM/yyyy";
            //dateTimeInfo.ShortDatePattern = "dd/MM/yyyy";
            //dateTimeInfo.LongTimePattern = "hh:mm:ss tt";
            //dateTimeInfo.ShortTimePattern = "hh:mm tt";
            // Setting application wide date time format.
            cultureInfo.DateTimeFormat = dateTimeInfo;
            //format decimal
            System.Globalization.NumberFormatInfo numberInfo =
                new System.Globalization.NumberFormatInfo();

            numberInfo.NumberDecimalSeparator = ".";
            numberInfo.NumberGroupSeparator = ",";
            numberInfo.CurrencyDecimalSeparator = ".";
            numberInfo.CurrencyGroupSeparator = ",";
            // Setting application wide number format
            cultureInfo.NumberFormat = numberInfo;
            // Assigning our custom Culture to the application.
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            pnMenu.Appearance.BackColor = CommonAppColors.ColorMainAppColor;
            pnMenu.Appearance.BackColor2 = CommonAppColors.ColorAppFormColor;
            xtraScrollableControlMain.BackColor = CommonAppColors.ColorMainAppColor;
        }
        private FormWindowState lastWindowState = FormWindowState.Normal;
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public Panel manche = new Panel();
        public void ShowManChe()
        {
            if (manche == null)
                manche = new Panel();
            manche.Size = this.Size;
            manche.BackColor = this.BackColor;
            manche.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(manche);
            manche.BringToFront();
        }
        public void AnManChe()
        {
            manche.Size = new Size(0, 0);
            this.Controls.Remove(manche);
        }
        private bool _hienThiMenu = false;
        [Category("Custom")]
        public bool HienThiMenu
        {
            set
            {
                _hienThiMenu = value;
                pnMenu.Visible = _hienThiMenu;
            }
            get
            {
                return _hienThiMenu;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                frmParent f = (frmParent)this.TopLevelControl;
                f.CloseForm(this);
            }
            else
            {
                this.Close();
            }
        }

        public void FormEscape(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmTemplate_Load(object sender, EventArgs e)
        {
            var templateTiltle = lblTitle.Text.Trim(); //Utils.ChuyenTVKhongDau(lblTitle.Text);
            this.Text = templateTiltle.First().ToString().ToUpper() + templateTiltle.Remove(0, 1).ToLower();
            Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            pictureBox1.Image = Bitmap.FromHicon(appIcon.Handle);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            foreach (Control item in xtraScrollableControlMain.Controls)
            {
                if (item is Button)
                {
                    var btnC = (Button)item;
                    btnC.FlatAppearance.BorderColor = Color.Empty;
                    btnC.BackColor = CommonAppColors.ColorMainAppColor;
                    btnC.ForeColor = CommonAppColors.ColorButtonMenuNormalForce;
                }
            }

            if (!DesignMode)
            {
                LanguageExtension.LocalizeForm(this, string.Empty);
            }
        }
        int imagInde = 0;
        private void btnThuNhoMenu_Click(object sender, EventArgs e)
        {
            //if (imagInde == 0)
            //{
            //    imagInde = 1;
            //    pnMenu.Tag = pnMenu.Width;
            //    pnMenu.Width = 50;
            //    btnThuNhoMenu.Image = pnR.BackgroundImage;

            //}
            //else
            //{
            //    pnMenu.Width = int.Parse(pnMenu.Tag.ToString());
            //    btnThuNhoMenu.Image = pnL.BackgroundImage;
            //    imagInde = 0;
            //}
        }

        private void FrmTemplate_Shown(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LabServices_Helper.SetControlColor(this);
                FixFormScale(this);
                HighDpiHelper.AdjustControlImagesDpiScale(this);
            }
        }

        public void HightLightButton(Button btn)
        {
            foreach (Control item in xtraScrollableControlMain.Controls)
            {
                if (item is Button)
                {
                    var btnC = (Button)item;
                    //var color = new Color();
                    if (btnC.Equals(btn))
                    {
                        if (btn is TPHIconButton)
                        {
                            var btnTPH = (TPHIconButton)btn;
                            btn.Tag = (btnTPH.MouseHoverBackColorBefore == null ? btn.BackColor : btnTPH.MouseHoverBackColorBefore);
                            btnTPH.MouseHoverBackColorBefore = CommonAppColors.ColorButtonMenuSelectedBackColor;

                        }
                        else if (btn is TPHNormalButton)
                        {
                            var btnTPH = (TPHNormalButton)btn;
                            btn.Tag = (btnTPH.OldColorHover == Color.Empty ? (btnTPH.OldColorEnter == Color.Empty ? btn.BackColor : btnTPH.OldColorEnter) : btnTPH.OldColorHover);
                            btnTPH.OldColorHover = btnTPH.OldColorEnter = (Color)btn.Tag; //CommonAppColors.ColorButtonMenuSelectedBackColor;
                            //color = btnTPH.ForceColorHover;
                        }
                        else
                            btn.Tag = btn.BackColor;

                        //btn.FlatAppearance.BorderColor = Color.White;
                        btn.ForeColor = Color.Black;// CommonAppColors.ColorButtonForceColor;
                        btn.BackColor = CommonAppColors.ColorMainAppFormColor;
                    }
                    else
                    {
                        btnC.FlatAppearance.BorderColor = Color.Empty;
                        btnC.ForeColor = CommonAppColors.ColorButtonMenuNormalForce;
                        if (btnC.Tag != null)
                        {
                            btnC.BackColor = (Color)btnC.Tag;
                        }
                    }
                }
            }
        }
        public void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(3);
                    btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
                    //FormSize = this.ClientSize;
                    break;
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            LastLocation = this.Location;
            lastWindowState = this.WindowState;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            lastWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                AdjustForm();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                AdjustForm();
                this.CenterToScreen();
            }
        }

        private void tphIconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void pnMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (MoveForm)
            {
                SendMessage(this.Handle, 0x112, 0xf012, 0);
                ReleaseCapture();
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                AdjustForm();
            }
        }

        private void xtraScrollableControlMain_MouseDown(object sender, MouseEventArgs e)
        {
            pnMenu_MouseDown(sender, e);
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            pnMenu_MouseDown(sender, e);
        }
        // Save the current scale value
        // ScaleControl() is called during the Form's constructor
        private SizeF scale = new SizeF(1.0f, 1.0f);
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            scale = new SizeF(scale.Width * factor.Width, scale.Height * factor.Height);
            base.ScaleControl(factor, specified);
        }

        // Recursively search for SplitContainer controls
        public void FixFormScale(Control c)
        {
            foreach (Control child in c.Controls)
            {
                if (child is SplitContainer)
                {
                    SplitContainer sp = (SplitContainer)child;
                    FixScale(sp);
                    FixFormScale(sp.Panel1);
                    FixFormScale(sp.Panel2);
                }
                else
                {
                    FixFormScale(child);
                }
            }
        }

        private void FixScale(SplitContainer sp)
        {
            // Scale factor depends on orientation
            float sc = (sp.Orientation == Orientation.Vertical) ? scale.Width : scale.Height;
            if (sp.FixedPanel == FixedPanel.Panel1)
            {
                sp.SplitterDistance = (int)Math.Round((float)sp.SplitterDistance * sc);
            }
            else if (sp.FixedPanel == FixedPanel.Panel2)
            {
                int cs = (sp.Orientation == Orientation.Vertical) ? sp.Panel2.ClientSize.Width : sp.Panel2.ClientSize.Height;
                int newcs = (int)((float)cs * sc);
                sp.SplitterDistance -= (newcs - cs);
            }
        }

        private void FrmTemplate_Activated(object sender, EventArgs e)
        {
           // SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}