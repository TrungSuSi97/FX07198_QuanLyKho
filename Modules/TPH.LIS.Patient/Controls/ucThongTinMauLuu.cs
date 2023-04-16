using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucThongTinMauLuu : UserControl
    {
        public ucThongTinMauLuu()
        {
            InitializeComponent();
        }
        [Category("Custom")]
        public event EventHandler XoaLuuMau;
        [Category("Custom")]
        public string Barcode
        {
            get { return lblBarcode.Text; }
            set { lblBarcode.Text = value; }
        }
        [Category("Custom")]
        public void SetAlarm(bool isAlarm)
        {
            if (isAlarm)
            {
                if (pnMainContaint.BackColor == Color.Yellow)
                    pnMainContaint.BackColor = Color.DarkGray;
                else
                    pnMainContaint.BackColor = Color.Yellow;
            }
            else
                pnMainContaint.BackColor = Color.DarkGray;
        }
        [Category("Custom")]
        public long IdMauLuu { get; set; }
        [Category("Custom")]
        public bool MauDaHuy { get { return !string.IsNullOrEmpty(lblNgayHuy.Text); } }
        [Category("Custom")]
        public int ViTriOngMau
        {
            get {
                return int.Parse(lblViTri.Tag == null ? "0" : (string.IsNullOrEmpty(lblViTri.Tag.ToString()) ? "0" : lblViTri.Tag.ToString())); }
            set
            {
                lblViTri.Text = string.Format("Vị trí:{0:000}", value);
                lblViTri.Tag = value;
            }
        }
        public void ThongTinOngMau(string Barcode, string nguoiLuu
            , Color mauOngMau
            , DateTime NgayLuu, DateTime? NgayHuy, string maOngMau) 
        {
            lblNguoiLuu.Text = nguoiLuu;
            lblNgayLuu.Text = NgayLuu.ToString("dd/MM/yyyy");
            lblNgayHuy.Text = (NgayHuy == null ? "" : NgayHuy.Value.ToString("dd/MM/yyyy"));
            lblBarcode.Text = Barcode;
            ucOngMauLuu1.TubeColor = mauOngMau;
            ucOngMauLuu1.SetSampleID = maOngMau;
            ucOngMauLuu1.VisibleTube = true;
            lblViTri.BackColor = Color.DimGray;
            pnChe.Visible = false;
        }
        public void XoaHienThi()
        {
            lblNguoiLuu.Text = string.Empty;
            lblNgayLuu.Text = string.Empty;
            lblNgayHuy.Text = string.Empty;
            lblBarcode.Text = string.Empty;
            ucOngMauLuu1.TubeColor = Color.Empty;
            ucOngMauLuu1.VisibleTube = false;
            ucOngMauLuu1.SetSampleID = string.Empty;
            lblViTri.BackColor = Color.LightGray;
            pnChe.Visible = true;

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            XoaLuuMau?.Invoke(this, e);
        }
    }
}
