using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public partial class TPHTemplateForm : Form
    {
        private bool useMinimize = true;
        private bool useMaximize = true;
        private bool useFormControl = true;
        private bool FirstLoad = true;
        public bool UseMinimize
        {
            get { return useMinimize; }
            set { useMinimize = value;
                btnMinimize.Visible = useMinimize;
            }
        }
        public bool UseMaximize
        {
            get { return useMaximize; }
            set { useMaximize = value;
                btnMaximize.Visible = value;
               
            }
        }
        public bool UseFormControl
        {
            get { return useFormControl; }
            set { useFormControl = value;
                pnFormControl.Visible = value;
            }
        }

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
        public TPHTemplateForm()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            btnMaximize.Visible = useMaximize;
            btnMinimize.Visible = useMinimize;
            pnFormControl.Visible = useFormControl;
            //this.Size = DefaultFormSize;
            //formSize = this.ClientSize;
            pnTitleBar.BackColor = CommonAppColors.ColorMainAppColor;
            this.BackColor = CommonAppColors.ColorAppFormColor2;
            pnContent.BackColor = CommonAppColors.ColorAppFormColor;
            this.chromeWidth = this.Width - this.ClientSize.Width;
            this.chromeHeight = this.Height - this.ClientSize.Height;
        }
        private FormWindowState lastWindowState = FormWindowState.Normal;
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #region Overridden methods
        private float constantWidth = 2;
        private float constantHeight = 1;

        private int chromeWidth;
        private int chromeHeight;
        // From Windows SDK
        private const int WM_SIZING = 0x214;

        private const int WMSZ_LEFT = 1;
        private const int WMSZ_RIGHT = 2;
        private const int WMSZ_TOP = 3;
        private const int WMSZ_BOTTOM = 6;

        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            if (!DesignMode)
            {
                const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
                //const int WM_SYSCOMMAND = 0x0112;
                //const int SC_MAXIMIZE = 0xF030;
                //const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
                //const int SC_RESTORE = 0xF120; //Restore form (Before)
                //const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
                //const int resizeAreaSize = 10;
                #region Form Resize
                //// Resize/WM_NCHITTEST values
                //const int HTCLIENT = 1; //Represents the client area of the window
                //const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
                //const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
                //const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
                //const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
                //const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
                //const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
                //const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
                //const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
                //                             ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
                //                             ///   //Remove border and keep snap window
                //const int WM_RESTOREWINDOWSTYLE = 70; //Represents the client area of the window

                if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
                {
                    return;
                }
                //if (m.Msg == WM_SIZING)
                //{
                //    RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));

                //    int w = rc.Right - rc.Left - chromeWidth;
                //    int h = rc.Bottom - rc.Top - chromeHeight;

                //    switch (m.WParam.ToInt32()) // Resize handle
                //    {
                //        case WMSZ_LEFT:
                //        case WMSZ_RIGHT:
                //            // Left or right handles, adjust height
                //            rc.Bottom = rc.Top + chromeHeight + (int)(constantHeight * w / constantWidth);
                //            break;

                //        case WMSZ_TOP:
                //        case WMSZ_BOTTOM:
                //            // Top or bottom handles, adjust width
                //            rc.Right = rc.Left + chromeWidth + (int)(constantWidth * h / constantHeight);
                //            break;

                //        case WMSZ_LEFT + WMSZ_TOP:
                //        case WMSZ_LEFT + WMSZ_BOTTOM:
                //            // Top-left or bottom-left handles, adjust width
                //            rc.Left = rc.Right - chromeWidth - (int)(constantWidth * h / constantHeight);
                //            break;

                //        case WMSZ_RIGHT + WMSZ_TOP:
                //            // Top-right handle, adjust height
                //            rc.Top = rc.Bottom - chromeHeight - (int)(constantHeight * w / constantWidth);
                //            break;

                //        case WMSZ_RIGHT + WMSZ_BOTTOM:
                //            // Bottom-right handle, adjust height
                //            rc.Bottom = rc.Top + chromeHeight + (int)(constantHeight * w / constantWidth);
                //            break;
                //    }

                //    Marshal.StructureToPtr(rc, m.LParam, true);
                //}
            }
            base.WndProc(ref m);
            #endregion
        }
        #endregion
        #region Private methods
        //Private methods
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
    
        #endregion
        #region Event methods
        public void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            AdjustForm();
        }
        private void FrnTemplateForm_Resize(object sender, EventArgs e)
        {
         //   AdjustForm();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            LastLocation = this.Location;
            lastWindowState = this.WindowState;
            this.WindowState = FormWindowState.Minimized;
           // AdjustForm();
        }
        public void BtnMaximize_Click(object sender, EventArgs e)
        {
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
                //var workingSize = Screen.GetWorkingArea(this).Size;
                //if (this.ClientSize.Width > DefaultFormSize.Width || this.ClientSize.Height > DefaultFormSize.Height)
                //    this.Size = DefaultFormSize;
                this.CenterToScreen();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void TPHTemplateForm_Load(object sender, EventArgs e)
        {
            //this.Height = this.Height - 31;
        }

        private void TPHTemplateForm_Shown(object sender, EventArgs e)
        {
            if (FirstLoad)
            {
                FirstLoad = false;
                AdjustForm();
                FixFormScale(this);
                HighDpiHelper.AdjustControlImagesDpiScale(this);
            }
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
        private void FixFormScale(Control c)
        {
            foreach (Control child in c.Controls)
            {
                if (child is SplitContainer)
                {
                    var sp = (SplitContainer)child;
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
    }
}
