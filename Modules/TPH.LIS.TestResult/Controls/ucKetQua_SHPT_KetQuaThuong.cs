using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.Controls;
using TPH.Language;
using System.Collections.Generic;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucKetQua_SHPT_KetQuaThuong : UserControl
    {
        public ucKetQua_SHPT_KetQuaThuong()
        {
            InitializeComponent();
            pnNgayKhoiPhat.BackColor = CommonAppColors.ColorMainAppColor;
            label1.ForeColor = label2.ForeColor = CommonAppColors.ColorTextCaption;
        }
        public Size KichCoHinhSHPT = new Size(646, 380);
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private string CurrentMaTiepNhan = string.Empty;
        private string CurrentMaXn = string.Empty;
        DataTable CurrentdataPatient;
        public int Currentindex;
        public string CurrentuserID;
        public string[] CurrentuserWorkPlace;
        public string[] CurrentarrayAllowNhom;
        public string CurrentPCWorkPlace;
        public int idMayXN = -1;
        public bool DaXacNhan = false;
        public string PhuongPhap = string.Empty;
        private string UserNhapKetQua = string.Empty;
        public string GenBatThuong
        {
            get
            {
                return ucKetQua_SHPT_TacNhan1.GenBatThuong;
            }
        }
        private void Check_Lock_Unlock()
        {
            txtKetQua.ReadOnly = DaXacNhan;
            txtDeNghi.ReadOnly = DaXacNhan;
            dtpNgayKhoiPhat.Enabled = !DaXacNhan;
            numLanXetNghiem.Enabled = !DaXacNhan;
        }
        public void Load_KetQua_ThuongQuy(string maTiepNhan, string maXn
            , string ketqua, string phuongPhap,DateTime? ngayKhoiPhat, int lanXetNghiem
            , string userNhapKetQua)
        {
            CurrentMaTiepNhan = maTiepNhan;
            CurrentMaXn = maXn;
            txtKetQua.Text = ketqua;
            txtDeNghi.Text = phuongPhap;
            dtpNgayKhoiPhat.Checked = false;
            UserNhapKetQua = userNhapKetQua;
            if (ngayKhoiPhat != null)
            {
                dtpNgayKhoiPhat.Checked = true;
                dtpNgayKhoiPhat.Value = ngayKhoiPhat.Value;
            }
            numLanXetNghiem.Value = lanXetNghiem;

            Check_Lock_Unlock();
            ucKetQua_SHPT_TacNhan1.CurrentuserID = CurrentuserID;
            ucKetQua_SHPT_TacNhan1.Load_KetQua_Gen(CurrentuserID, CurrentuserWorkPlace, CurrentarrayAllowNhom, maXn, maTiepNhan, string.Empty);
        }
        public string Get_KetQua()
        {
            return txtKetQua.Text;
        }
        public int Luu_KetQua(string nguongTren, string nguongDuoi
            , string DKDanhGia, string ghiChu, string idMayXn, string noikiemtra
           , string ghiChuCu, int idMayCu, string ketquaCu)
        {
            var objImage = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(CurrentMaTiepNhan, CurrentMaXn);
            objImage.Matiepnhan = CurrentMaTiepNhan;
            objImage.Maxn = CurrentMaXn;
            objImage.KetLuan = txtKetQua.Text;
            objImage.NguongDuoi = nguongDuoi;
            objImage.NguongTren = nguongTren;
            objImage.DKBatThuong = DKDanhGia;
            objImage.Nguoinhap = CurrentuserID;
            objImage.Nguoisua = CurrentuserID;
            objImage.IDMayXn = idMayXn;
            objImage.GhiChu = ghiChu;
            objImage.PhuongPhap = txtDeNghi.Text;
            objImage.NoiKiemTra = noikiemtra;
            objImage.LanXetNghiem = (int)numLanXetNghiem.Value;
            objImage.withImage = false;
            objImage.suaKetqua = !string.IsNullOrEmpty(UserNhapKetQua);
            objImage.coNgaykhoiPhat = true;
            objImage.CapNhatGhiChu = LabResultService.KiemtraCapNhatGhiChu(ghiChu, idMayXn, objImage.KetLuan, ghiChuCu, idMayCu, ketquaCu);
            if (dtpNgayKhoiPhat.Checked)
                objImage.ThoiGianXacNhanThucHien = dtpNgayKhoiPhat.Value;
            return _xetnghiem.LuuKetQua_SHPT(objImage);
        }

        private void txtKetQua_TextChanged(object sender, EventArgs e)
        {
            if (txtKetQua.Text.ToLower().Contains("âm tính") || txtKetQua.Text.ToLower().Contains("neg"))
                txtKetQua.ForeColor = Color.Blue;
            else if (txtKetQua.Text.ToLower().Contains("dương tính") || txtKetQua.Text.ToLower().Contains("pos"))
                txtKetQua.ForeColor = Color.Red;
            else
                txtKetQua.ForeColor = Color.Black;
        }

        private void ucKetQua_SHPT_KetQuaThuong_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
