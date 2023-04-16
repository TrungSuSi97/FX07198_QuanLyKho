using System.Windows.Forms;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucThongTinNhom : UserControl
    {
        public ucThongTinNhom()
        {
            InitializeComponent();
        }

        private void ucThongTinNhom_Load(object sender, System.EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
        //[Ngay], [BoPhan], [DaNhanMauDu], [DaLayMauDu]
        //, [DaCoKetQua], [DaDuyet], [DaIn], [YeuCauLayLai]
        //, [DaNhanMau], [DaLayMau], [ChuaNhanMau], [ChuaLayMau]
        //, [DaDuKetQua]
    }
}
