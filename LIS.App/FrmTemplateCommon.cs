using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using TPH.LIS.App.Properties;

namespace TPH.LIS.App
{
    public partial class FrmTemplateCommon : Form
    {
        public FrmTemplateCommon()
        {
            InitializeComponent();
            pnMenu.Visible = _hienThiMenu;
            // Creating a Global culture specific to our application.
            System.Globalization.CultureInfo cultureInfo =
                new System.Globalization.CultureInfo("en-US");
            //// Creating the DateTime Information specific to our application.
            //System.Globalization.DateTimeFormatInfo dateTimeInfo =
            //    new System.Globalization.DateTimeFormatInfo();
            //// Defining various date and time formats.
            //dateTimeInfo.DateSeparator = "/";
            //dateTimeInfo.LongDatePattern = "dd/MM/yyyy";
            //dateTimeInfo.ShortDatePattern = "dd/MM/yyyy";
            //dateTimeInfo.LongTimePattern = "hh:mm:ss tt";
            //dateTimeInfo.ShortTimePattern = "hh:mm tt";
            //// Setting application wide date time format.
            //cultureInfo.DateTimeFormat = dateTimeInfo;
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
        }
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
                frmMDIParent f = (frmMDIParent)this.MdiParent;
                f.CloseForm(this);
            }
            else
            {
                this.Close();
            }
        }

        private void frmTemplate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmTemplate_Load(object sender, EventArgs e)
        {
            var templateTiltle = lblTitle.Text; //Utils.ChuyenTVKhongDau(lblTitle.Text);
            this.Text = templateTiltle.First().ToString().ToUpper() + templateTiltle.Remove(0, 1).ToLower(); 
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
    }
}