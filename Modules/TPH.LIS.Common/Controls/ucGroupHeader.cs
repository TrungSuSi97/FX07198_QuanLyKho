using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;

namespace TPH.LIS.Common.Controls
{
    public partial class ucGroupHeader : UserControl
    {
        public ucGroupHeader()
        {
            InitializeComponent();
            this.BackColor = CommonAppColors.ColorMainAppColorSub2;
            this.ForeColor = CommonAppColors.ColorTextNormal;
        }
        [Category("TPH CutomControl -  Appearance")]
        public string GroupCaption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }
        [Category("TPH CutomControl -  Appearance")]
        public ContentAlignment GroupCaptionAlign
        {
            get { return lblCaption.TextAlign; }
            set { lblCaption.TextAlign = value; }
        }

        private void ucGroupHeader_FontChanged(object sender, System.EventArgs e)
        {
            lblCaption.Font = this.Font; //new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            if (DesignMode)
                lblCaption.Invalidate();
        }

        private void ucGroupHeader_Load(object sender, System.EventArgs e)
        {
            if (!DesignMode)
            {
                LanguageExtension.LocalizeForm(this, string.Empty);
            }
            //LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
