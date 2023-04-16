using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Patient.Model;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucThongTinOngMauTim : UserControl
    {
        public ucThongTinOngMauTim()
        {
            InitializeComponent();
        }
        public void SetThongTinMau(ArchiveSample tubeInfo)
        {
            lblViTri.Text = string.Format("Vị trí: {0} - Khay: {1} - Tủ lưu: {2}", tubeInfo.Vitri, tubeInfo.Mahopluumau, tubeInfo.Masotuluu);
            lblBarode.Text = tubeInfo.Barcode;
            lblNgayHuy.Text = tubeInfo.Ngayhuy == null ? string.Empty : tubeInfo.Ngayhuy.Value.ToString("dd/MM/yyyy HH:mm:ss");
            lblNgayLuu.Text = tubeInfo.Ngayluu.ToString("dd/MM/yyyy HH:mm:ss");
            lblNguoiLuu.Text = tubeInfo.Nguoiluu;
            var colr = Color.LightGray;
            if (!string.IsNullOrEmpty(tubeInfo.Mauongmau))
            {
                string[] split = tubeInfo.Mauongmau.Split(',');
                if (split.Length == 3)
                {
                    colr = Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                }
            }
            ucOngMauLuu1.VisibleTube = true;
            ucOngMauLuu1.TubeColor = colr;
        }
    }
}
