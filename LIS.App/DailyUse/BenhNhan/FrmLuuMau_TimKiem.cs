using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Patient.Services;
using TPH.LIS.Patient.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmLuuMau_TimKiem : FrmTemplate
    {
        public FrmLuuMau_TimKiem()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        private void btnTimMau_Click(object sender, EventArgs e)
        {
            KiemTraLoadDanhSach();
        }
        private void KiemTraLoadDanhSach()
        {
            flpDanhSach.Controls.Clear();
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                var barcode = txtBarcode.Text;
                if (!WorkingServices.IsNumeric(barcode) && !string.IsNullOrEmpty(barcode))
                    barcode = WorkingServices.SplitSampleCode(barcode);
                LoadDanhSach_Tube(barcode);
            }
            else
            {
                var dataDSBn = iPatient.LayDanhSach_TiepNhan_TheoMaBN(txtMaBenhNhan.Text);
                if (dataDSBn != null)
                {
                    foreach (DataRow dr in dataDSBn.Rows)
                    {
                        var barcode = dr["Seq"].ToString();
                        LoadDanhSach_Tube(barcode);
                    }
                }
            }
        }
        private void  LoadDanhSach_Tube(string barcode)
        {
            var data = iPatient.DanhSach_OngMauLuu(barcode, string.Empty, string.Empty);
            if(data !=null)
            {
                foreach(DataRow dr in data.Rows)
                {
                    var obj = iPatient.Get_Info_mauxetnghiem_luumau_FromDatarow(dr);
                    var ucOngMau = new ucThongTinOngMauTim();
                    ucOngMau.SetThongTinMau(obj);
                    flpDanhSach.Controls.Add(ucOngMau);
                }
            }
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaBenhNhan.Text))
                txtMaBenhNhan.Text = string.Empty;
        }

        private void txtMaBenhNhan_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
                txtBarcode.Text = string.Empty;
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                KiemTraLoadDanhSach();
                e.Handled = true;
            }
        }

        private void txtMaBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                KiemTraLoadDanhSach();
                e.Handled = true;
            }
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtMaBenhNhan_Click(object sender, EventArgs e)
        {
            txtMaBenhNhan.SelectAll();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtMaBenhNhan_Enter(object sender, EventArgs e)
        {
            txtMaBenhNhan.SelectAll();
        }
    }
}
