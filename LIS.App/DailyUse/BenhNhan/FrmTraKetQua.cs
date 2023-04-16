using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Constants;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmTraKetQua : FrmTemplate
    {
        public FrmTraKetQua()
        {
            InitializeComponent();
        }
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        TestResult.Services.ITestResultService _iTestResult = new TestResult.Services.TestResultService();
        Patient.Services.IPatientInformationService _iPatient = new Patient.Services.PatientInformationService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        private void FrmTraKetQua_Load(object sender, EventArgs e)
        {
            txtNguoiTra.Text = CommonAppVarsAndFunctions.UserID;
            dtpNgayChiDinh.Value = CommonAppVarsAndFunctions.ServerTime;
            Load_DanhSach_KhoaPhong();
            Get_DanhSach_ChuaTraKQ();
            Get_DanhSach_DaTraKQ();
        }

        private void Load_DanhSach_KhoaPhong()
        {
            var data = sysConfig.GetLocation(string.Empty, string.Empty);
            lueDonViNhan.Properties.DataSource = data;
            lueDonViNhan.Properties.ValueMember = "MaKhoaPhong";
            lueDonViNhan.Properties.DisplayMember = "TenKhoaPhong";
            lueDonViNhan.Properties.AutoHeight = false;
            lueDonViNhan.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            colTraKQ_NoiNhan.DataSource = data.Copy();
            colTraKQ_NoiNhan.ValueMember = "MaKhoaPhong";
            colTraKQ_NoiNhan.DisplayMember = "TenKhoaPhong";
        }

        public void Get_DanhSach_ChuaTraKQ()
        {
            var data = _iPatient.TimBenhNhanXetNghiem(
                new Patient.Model.SearchPatientCondit_XN
                {
                    tungay = dtpNgayChiDinh.Value.Date,
                    denngay = dtpNgayChiDinh.Value.Date,
                    maDoiTuong = string.Empty,
                    tenBN = string.Empty,
                    barcode = string.Empty,
                    maBN = string.Empty,
                    sdt = string.Empty,
                    idCongDan = string.Empty,
                    sophieuHis = string.Empty,
                    khuTiepNhan = string.Empty,
                    daNhanMau = Common.enumThucHien.TatCa,
                    daLayMau = Common.enumThucHien.TatCa,
                    daTraKQ = Common.enumThucHien.ChuaThucHien,
                    dainKQ = Common.enumThucHien.DaThucHien
                });

               // dtpNgayChiDinh.Value.Date, dtpNgayChiDinh.Value.Date
               // , string.Empty, string.Empty, string.Empty
               //, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
               //, Common.enumThucHien.TatCa
               //, Common.enumThucHien.TatCa
               //, Common.enumThucHien.ChuaThucHien
               //, dainKQ: Common.enumThucHien.DaThucHien);
            ControlExtension.BindDataToGrid(data, ref dtgChoTraKQ, ref bvChoTraKQ);
        }
        private void Get_ChiTiet_ChuaTraKQ()
        {
            if (dtgChoTraKQ.CurrentRow != null)
            {
                var maTiepNhan = dtgChoTraKQ.CurrentRow.Cells[colChoTraKQMaTiepNhan.Name].Value.ToString();
                var tenBN = dtgChoTraKQ.CurrentRow.Cells[colChoTraKQTenBN.Name].Value.ToString();
                txtBarcode.Text = dtgChoTraKQ.CurrentRow.Cells[colChoTraKQBarcode.Name].Value.ToString();
                Get_ChiTietXetNghiem(maTiepNhan, tenBN);
            }
        }
        public void Get_DanhSach_DaTraKQ()
        {
            var data = _iPatient.TimBenhNhanXetNghiem(new Patient.Model.SearchPatientCondit_XN
            {
                tungay = dtpNgayChiDinh.Value.Date,
                denngay = dtpNgayChiDinh.Value.Date,
                maDoiTuong = string.Empty,
                tenBN = string.Empty,
                barcode = string.Empty,
                maBN = string.Empty,
                sdt = string.Empty,
                idCongDan = string.Empty,
                sophieuHis = string.Empty,
                khuTiepNhan = string.Empty,
                daNhanMau = Common.enumThucHien.TatCa,
                daLayMau = Common.enumThucHien.TatCa,
                daTraKQ = Common.enumThucHien.DaThucHien
            });
            ControlExtension.BindDataToGrid(data, ref dtgDaTraKQ, ref bvDaTraKQ);
        }
        private void Get_ChiTiet_DaTraKQ()
        {
            if (dtgDaTraKQ.CurrentRow != null)
            {
                var maTiepNhan = dtgDaTraKQ.CurrentRow.Cells[colDaTraKQMaTiepNhan.Name].Value.ToString();
                var tenBN = dtgDaTraKQ.CurrentRow.Cells[colDaTraKQTenBN.Name].Value.ToString();
                Get_ChiTietXetNghiem(maTiepNhan, tenBN);
            }
        }
        private void Get_ChiTietXetNghiem(string maTiepNhan, string tenBN)
        {
            lblChiTietXetNghiem.Text = string.Format("CHI TIẾT XÉT NGHIỆM CỦA: {0} - {1}", tenBN, maTiepNhan);

            ucChiTietChiDinh1.Get_ChiTietChiDinh(maTiepNhan, new User.Enum.ServiceType[] { User.Enum.ServiceType.ClsXetNghiem });
        }
        private void CapNhat_TraketQua(string maTiepNhan, bool thucHienTra)
        {
            string userThucHien = CommonAppVarsAndFunctions.UserID;
            string nguoiNhan = txtNguoiNhan.Text;
            string noiNhan = (lueDonViNhan.EditValue == null ? string.Empty : lueDonViNhan.EditValue.ToString());

            _iPatient.Update_TraKetqua(maTiepNhan, userThucHien, nguoiNhan, noiNhan, thucHienTra);
            Get_DanhSach_ChuaTraKQ();
            Get_DanhSach_DaTraKQ();
        }

        private void btnLayMau_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                var maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(txtBarcode.Text, dtpNgayChiDinh.Value);
                CapNhat_TraketQua(maTiepNhan, true);
            }
        }

        private void btnChoTraKQXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgChoTraKQ);
        }

        private void btnChoTraKQLamMoi_Click(object sender, EventArgs e)
        {
            Get_DanhSach_ChuaTraKQ();
        }

        private void txtTimChoTraKQ_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimChoTraKQ.Text.Trim()))
            {
                if (WorkingServices.IsNumeric(txtTimChoTraKQ.Text.Trim()))
                    bvChoTraKQ.BindingSource.Filter = string.Format("Seq = {0}", txtTimChoTraKQ.Text.Trim());
                else
                    bvChoTraKQ.BindingSource.Filter = string.Format("TenBN like '%{0}%'", WorkingServices.EscapeLikeValue(txtTimChoTraKQ.Text.Trim()));
            }
            else
                Get_DanhSach_ChuaTraKQ();
        }

        private void btnDaTraKQXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgDaTraKQ);
        }

        private void btnDayLayMauLamMoi_Click(object sender, EventArgs e)
        {
            Get_DanhSach_DaTraKQ();
        }

        private void txtTimDaTraKQ_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimDaTraKQ.Text.Trim()))
            {
                if (WorkingServices.IsNumeric(txtTimDaTraKQ.Text.Trim()))
                    bvDaTraKQ.BindingSource.Filter = string.Format("Seq = {0}", txtTimDaTraKQ.Text.Trim());
                else
                    bvDaTraKQ.BindingSource.Filter = string.Format("TenBN like '%{0}%'", WorkingServices.EscapeLikeValue(txtTimDaTraKQ.Text.Trim()));
            }
            else
                Get_DanhSach_DaTraKQ();
        }

        private void Check_FocusRow(string barcode)
        {
            int index = bvChoTraKQ.BindingSource.Find("Seq", barcode);
            if (index > -1)
            {
                bvChoTraKQ.BindingSource.Position = index;
                Get_ChiTiet_ChuaTraKQ();
            }
            else
            {
                index = bvDaTraKQ.BindingSource.Find("Seq", barcode);
                if (index > -1)
                {
                    bvDaTraKQ.BindingSource.Position = index;
                    Get_ChiTiet_DaTraKQ();
                }
            }

        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBarcode.Text))
                {
                    Get_DanhSach_ChuaTraKQ();
                    Get_DanhSach_DaTraKQ();

                    if (chkTraKQKhiQuet.Checked)
                    {
                        var maTiepNhan = ConfigurationDetail.Get_MaTiepNhan(txtBarcode.Text, dtpNgayChiDinh.Value);

                        Check_FocusRow(txtBarcode.Text);

                        CapNhat_TraketQua(maTiepNhan, true);
                    }
                }
                e.Handled = true;
            }
        }

        private void dtgChoTraKQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Get_ChiTiet_ChuaTraKQ();
        }

        private void dtgDaTraKQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Get_ChiTiet_DaTraKQ();
        }

        private void btnGoiManHinhDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("TPH.LabIMS.ResultListScreen.exe"))
                {
                    var p = new Process
                    {
                        StartInfo =
                    {

                    FileName = "TPH.LabIMS.ResultListScreen.exe"
                        }
                    };

                    p.Start();
                }
                else
                    MessageBox.Show("Ứng dụng chưa được cài đặt!");
            }
            catch
            {

            }
        }
    }
}
