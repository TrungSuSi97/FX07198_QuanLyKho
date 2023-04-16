using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.App.AppCode;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Services;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmPrintbarcodeTemp : Form
    {

        public FrmPrintbarcodeTemp()
        {
            InitializeComponent();
        }
        private IPatientInformationService informationService = new PatientInformationService();

        public void PrintBarcode()
        {
            var objPatient = informationService.Get_Info_BenhNhan_TiepNhan(txtMaTiepNhan.Text, new string[] { });
            var barcode = new BarcodeProperties();
            barcode.NamSinh = objPatient.Tuoi.ToString();
            barcode.TenBarcode = barcode.SoBarcode = objPatient.Seq;
            barcode.NgayTiepNhan = objPatient.Ngaytiepnhan;
            barcode.PatientName = objPatient.Tenbn;
            barcode.Sid = objPatient.Matiepnhan;
            barcode.GioiTinh = objPatient.Gioitinh;
            barcode.MaKhoaPhong = objPatient.Madonvi;
            barcode.SoTT = objPatient.Sott.ToString();

            barcode.NumberOfCopy =
                NumberConverter.ToInt(string.IsNullOrEmpty(txtSoLuongTem.Text) || txtSoLuongTem.Text == "0"
                    ? "1"
                    : txtSoLuongTem.Text);
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemBacodeCoLoaiMau)
            {
                barcode.TenBarcode = barcode.SoBarcode = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangBarcode.Replace("{ID}", objPatient.Seq).Replace("{T}", txtMaLoaiMau.Text.Trim());
            }
            barcode.DanhSachTube = new System.Collections.Generic.List<BarcodeTubeDetail>();
            barcode.DanhSachTube.Add(new BarcodeTubeDetail
            {
                Tubecode = txtMaLoaiMau.Text,
                TubeCate = string.Empty,
                Tubename = txtMaLoaiMau.Text,
                TubeCount = barcode.NumberOfCopy,
                NguoiLayMau = string.Empty,
                NgayLayMau = objPatient.Ngaytiepnhan,
                NhomXetNghiem = string.Empty,
                BoPhanXetNghiem = string.Empty,
                Barcode = barcode.SoBarcode,
                BarcodeName = barcode.TenBarcode
            });
            var objPrintInfo = new DM_MAYTINH_MAYIN();
            PrintBarcodeHelper.PrintBarcode(objPrintInfo, new List<BarcodeProperties>() { barcode }, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInBarCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTiepNhan.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã tiếp nhận!");
            else if (string.IsNullOrEmpty(txtSoLuongTem.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập số tem barcode");
            else
            {
                //if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemBacodeCoLoaiMau && string.IsNullOrEmpty(txtMaLoaiMau.Text))
                //{
                //    CustomMessageBox.MSG_Information_OK("Hãy nhập số tem barcode");
                //    return;
                //}

                PrintBarcode();
                this.Close();
            }

        }

        private void txtMaTiepNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtSoLuongTem);
        }

        private void txtSoLuongTem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemBacodeCoLoaiMau)
                ControlExtension.LeaveFocusNext(e, txtMaLoaiMau);
            else
                ControlExtension.LeaveFocusNext(e, btnInBarCode);
        }

        private void FrmPrintbarcodeTemp_Load(object sender, EventArgs e)
        {
            txtMaLoaiMau.Enabled = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemBacodeCoLoaiMau;
        }

        private void FrmPrintbarcodeTemp_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaTiepNhan.Text))
                txtSoLuongTem.Focus();
            else
                txtMaTiepNhan.Focus();
        }

        private void txtMaLoaiMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnInBarCode);
        }
    }
}
