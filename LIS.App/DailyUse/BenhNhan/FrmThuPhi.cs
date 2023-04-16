using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmThuPhi : FrmTemplate
    {
        bool _FromKhamBenh = false;

        public bool FromKhamBenh
        {
            get { return _FromKhamBenh; }
            set { _FromKhamBenh = value; }
        }

        DateTime dtDateIn = new DateTime();

        public DateTime DtDateIn
        {
            get { return dtDateIn; }
            set { dtDateIn = value; }
        }

        string _SoTT = "";

        public string SoTT
        {
            get { return _SoTT; }
            set { _SoTT = value; }
        }

        
        public FrmThuPhi()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        C_Patient pInfo = new C_Patient();
        C_Config config = new C_Config();
        ITestResultService xetnghiem = new TestResultService();
        C_Patient_XQuang xray = new C_Patient_XQuang();
        C_Patient_SieuAm sieuam = new C_Patient_SieuAm();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        C_NhanVien nhanvien = new C_NhanVien();
        DataTable dtChiDinhXN = new DataTable();
        DataTable dtChiDinhSieuAm = new DataTable();
        DataTable dtChiDinhXQuang = new DataTable();

        DataTable dtBenhNhan = new DataTable();
        DataTable dtCLS_ChiDinh = new DataTable();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        private void FrmFrmThuPhi_Load(object sender, EventArgs e)
        {
            Collect_ControlToBindData();
            LabServices_Helper.LoadPrinterName(listPrinter, "PrintInvoice", false);

            if (_registryExtension.ReadRegistry(UserConstant.RegistryPrintInvoiceDirect).Equals("1"))
                chkNotPreview.Checked = true;
            else
                chkNotPreview.Checked = false;

            sysConfig.Get_DoiTuongDichVu(cboService, txtDTDichVu);
            data.Get_ChanDoan(cboChanDoan);
            nhanvien.Get_NhanVien(cboBSChiDinh);
            if (_FromKhamBenh)
            {
                pnLabel.Visible = false;
                btnClose.Visible = false;
                if (_SoTT != "")
                {
                    txtSEQ.Text = _SoTT;
                    dtpDateIn.Value = dtDateIn;
                }
            }
        }

        private void Load_BenhNhan()
        {
            dtBenhNhan = pInfo.GetPatient(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value));
            BindData(dtBenhNhan);
            Load_ChiDinh();
        }

        object[] objControl = new object[9];


        private void Collect_ControlToBindData()
        {
            txtMSBenhNhan.Tag = "MaBN";
            txtAge.Tag = "Tuoi";
            chkAgeType.Tag = "CoNgaySinh";
            dtpBirthday.Tag = "SinhNhat";
            txtTenBN.Tag = "TenBN";
            txtChanDoan.Tag = "ChanDoan";
            cboService.Tag = "DoiTuongDichVu";
            txtSex.Tag = "GioiTinh";
            txtAddress.Tag = "DiaChi";
            txtChanDoan.Tag = "ChanDoan";
            cboBSChiDinh.Tag = "BacSiCD";

            objControl[0] = txtMSBenhNhan;
            objControl[1] = txtAge;
            objControl[2] = chkAgeType;
            objControl[3] = dtpBirthday;
            objControl[4] = txtTenBN;
            objControl[5] = txtChanDoan;
            objControl[6] = cboService;
            objControl[7] = txtSex;
            objControl[8] = txtAddress;
            objControl[8] = txtChanDoan;
            objControl[8] = cboBSChiDinh;
        }
        private void BindData(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            for (int i = 0; i < objControl.Length; i++)
            {
                LabServices_Helper.CheckAndSetBindData(objControl[i], bs);
            }
        }


        private void Load_ChiDinh_XetNghiem()
        {
            xetnghiem.Get_DanhSachChiDinh(dtgChiDinhXN, bvChiDinhXN, " MaTiepNhan ='" + ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtChiDinhXN, true);
        }
        private void Load_ChiDinh_SieuAm()
        {
            sieuam.Get_DanhSachChiDinh(dtgChiDinhSA, bvChiDinhSA, " MaTiepNhan ='" + ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtChiDinhSieuAm, true);
        }
        private void Load_ChiDinh_XQuang()
        {
            xray.Get_DanhSachChiDinh(dtgChiDinhXRay, bvChiDinhXRay, " MaTiepNhan ='" + ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtChiDinhXQuang, true);
        }

        private void Load_ChiDinh()
        {
            Load_ChiDinh_XetNghiem();
            Load_ChiDinh_XQuang();
            Load_ChiDinh_SieuAm();
        }
        private void InBienLai()
        {
            string _ChiDinhXN = "", _ChiDinhSA = "", _ChiDinhXQ = "";
            _ChiDinhXN = _Get_ChiDinhThuTien(dtgChiDinhXN, "xnChon", "xnMaChiDinh");
            _ChiDinhSA = _Get_ChiDinhThuTien(dtgChiDinhSA, "saChon", "saMaChiDinh");
            _ChiDinhXQ = _Get_ChiDinhThuTien(dtgChiDinhXRay, "xChon", "xMaChiDinh");
            _ChiDinhXN = " and MaXN in (" + (_ChiDinhXN == "" ? "''" : _ChiDinhXN) + ")";
            _ChiDinhSA = " and MaSoMau in (" + (_ChiDinhSA == "" ? "''" : _ChiDinhSA) + ")";
            _ChiDinhXQ = " and k.MaVungChup in (" + (_ChiDinhXQ == "" ? "''" : _ChiDinhXQ) + ")";

            pInfo.Print_BienLai(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), chkNotPreview.Checked, listPrinter.SelectedItem.ToString().Trim(), chkHaveCost.Checked, _ChiDinhXN, _ChiDinhSA, _ChiDinhXQ);
            
        }
        private void CapNhat_ThuTien()
        {
            string _ChiDinhXN = "", _ChiDinhSA = "", _ChiDinhXQ = "";
            _ChiDinhXN = _Get_ChiDinhThuTien(dtgChiDinhXN, "xnChon", "xnMaChiDinh");
            _ChiDinhSA = _Get_ChiDinhThuTien(dtgChiDinhSA, "saChon", "saMaChiDinh");
            _ChiDinhXQ = _Get_ChiDinhThuTien(dtgChiDinhXRay, "xChon", "xMaChiDinh");
            string _MaTiepNhan = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text,dtpDateIn.Value);

            if (_ChiDinhXN != "")
            {
                xetnghiem.CapNhat_ThuTien(_MaTiepNhan, _ChiDinhXN, true);
            }
            if (_ChiDinhSA != "")
            {
                sieuam.CapNhat_ThuTien(_MaTiepNhan, _ChiDinhSA, true);
            }
            if (_ChiDinhXQ != "")
            {
                xray.CapNhat_ThuTien(_MaTiepNhan, _ChiDinhXQ, true);
            }
            Load_ChiDinh();
        }

        private string _Get_ChiDinhThuTien(DataGridView dtg, string _columnCheck, string _ColumnValue)
        {
            string _MaChiDinh = "";
            if (dtg.RowCount > 0)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    if ((bool)dtg[_columnCheck, i].Value == true)
                    {
                        _MaChiDinh += (_MaChiDinh.Length > 0 ? ",'" + dtg[_ColumnValue, i].Value.ToString().Trim() + "'" : "'" + dtg[_ColumnValue, i].Value.ToString().Trim() + "'");
                    }
                }
            }
            return _MaChiDinh;
        }
        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_BenhNhan();
            }
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            if (txtSEQ.Text != "")
            {
                Load_BenhNhan();
            }
        }

        private void chkHaveCost_Click(object sender, EventArgs e)
        {
            Load_ChiDinh();
        }

        private void SetColorRow(DataGridView dtg, string coloumCheckName, Color _colorRow)
        {
            if (dtg.RowCount > 0)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    if ((bool)dtg[coloumCheckName, i].Value == true)
                    {
                        dtg.Rows[i].DefaultCellStyle.BackColor = _colorRow;
                    }
                }
            }
        }

        private void dtgChiDinhXN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetColorRow(dtgChiDinhXN, "xnDaThu", Color.LightBlue);
        }

        private void dtgChiDinhSA_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetColorRow(dtgChiDinhSA, "saDaThu", Color.LightBlue);
        }

        private void dtgChiDinhXRay_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetColorRow(dtgChiDinhXRay, "xDaThu", Color.LightBlue);
        }
        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            InBienLai();
            if (chkThuTien.Checked)
            {
                CapNhat_ThuTien();
            }
        }

        private void btnThuTien_Click(object sender, EventArgs e)
        {
            CapNhat_ThuTien();
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrintInvoice, 
                listPrinter.SelectedIndex.ToString());
        }

        private void chkNotPreview_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrintInvoiceDirect, 
                chkNotPreview.Checked == true ? "1" : "0");
        }
    }
}
