using System.Windows.Forms;
using TPH.Language;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmHuongDan_FormKetQuaTQ : Form
    {
        public FrmHuongDan_FormKetQuaTQ()
        {
            InitializeComponent();
        }

        private void FrmHuongDan_FormKetQuaTQ_Load(object sender, System.EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
