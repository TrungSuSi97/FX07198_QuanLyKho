using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucKetQua_SHPT_LuoiThuong : UserControl
    {
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private string CurrentMaTiepNhan = string.Empty;
        private string CurrentMaXn = string.Empty;
        DataTable CurrentdataPatient;
        int Currentindex;
        public string CurrentuserID;
        public string[] CurrentuserWorkPlace;
        public string[] CurrentarrayAllowNhom;
        public string CurrentPCWorkPlace;
        float heSo = 0;
        int lamtron = -1;
        public bool DaXacNhan = false;

        public ucKetQua_SHPT_LuoiThuong()
        {
            InitializeComponent();
        }
        public void Load_KetQua(DataTable dataPatient, int index, string userID
            , string[] userWorkPlace, string[] arrayAllowNhom
            , string maXNCha, string maTiepNhan)
        {
            CurrentMaTiepNhan = maTiepNhan;
            CurrentMaXn = maXNCha;
            CurrentdataPatient = dataPatient;
            int Currentindex = index;
            string CurrentuserID = userID;
            string[] CurrentuserWorkPlace = userWorkPlace;
            string[] CurrentarrayAllowNhom = arrayAllowNhom;

         //   var dataChitiet = _xetnghiem.DuLieuIn_XN(dataPatient, Currentindex
         //, false, CurrentuserID, maXNCha, false, DateTime.Now, CurrentuserWorkPlace
         //, string.Empty, false, new Common.TestType.EnumTestType[] { Common.TestType.EnumTestType.SinhHocPhanTu }
         //, Utilities.ConvertStrinArryToInClauseSQL(CurrentarrayAllowNhom, true));
            var dataChitiet = _xetnghiem.DuLieuKetQua_XN(dataPatient, Currentindex, false, CurrentuserID, maXNCha, false
                                , null, CurrentuserWorkPlace, string.Empty, false
                                , new Common.TestType.EnumTestType[] { Common.TestType.EnumTestType.SinhHocPhanTu }
                                , Utilities.ConvertStrinArryToInClauseSQL(CurrentarrayAllowNhom, true));

            ClearThongTin();
            if (dataChitiet.Rows.Count >0)
            {
                DataRow dr = dataChitiet.Rows[0];
                txtKetQuaHeSo.Text = dr["KetQuaNhanHeSo"].ToString();
                txtKetQuaThuong.Text = dr["KetQuaDinhLuong"].ToString();
                cboKetQuaDinhTinh.Text = dr["KetQua"].ToString();
                txttenInheSo.Text = dr["TenXNSHPTHeSo"].ToString();
                txtTenXnIn.Text = dr["TenXNSHPT"].ToString();
                txtDonViTinh.Text = dr["DonVi"].ToString();
                heSo = float.Parse(dr["HeSoQuiDoi"].ToString());
                txtHeSoNhan.Text = heSo.ToString();
                lamtron = int.Parse(string.IsNullOrEmpty(dr["LamTron"].ToString())?"-1": dr["LamTron"].ToString());
            }

            btnNhanHeSo.Enabled = !DaXacNhan;
        }
        private void ClearThongTin()
        {
            txtTenXnIn.DataBindings.Clear();
            txtTenXnIn.Text = string.Empty;

            txttenInheSo.DataBindings.Clear();
            txttenInheSo.Text = string.Empty;

            txtKetQuaThuong.DataBindings.Clear();
            txtKetQuaThuong.Text = string.Empty;
            txtDonViTinh.DataBindings.Clear();
            txtDonViTinh.Text = string.Empty;

            txtKetQuaHeSo.DataBindings.Clear();
            txtKetQuaHeSo.Text = string.Empty;

            cboKetQuaDinhTinh.DataBindings.Clear();
            cboKetQuaDinhTinh.SelectedIndex = -1;
        }
        public string Get_KetQua()
        {
            return txtKetQuaThuong.Text;
        }
        public int Luu_KetQua(string nguongTren, string nguongDuoi
          , string DKDanhGia, string ghiChu, string idMayXn, string phuongPhap, string noikiemtra, string ghiChuCu, int idMayCu, string ketquaCu)
        {
            var objImage = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(CurrentMaTiepNhan, CurrentMaXn);
            objImage.Matiepnhan = CurrentMaTiepNhan;
            objImage.Maxn = CurrentMaXn;
            objImage.KetLuan = cboKetQuaDinhTinh.Text; 
            objImage.KetQuaHeSo = txtKetQuaHeSo.Text;
            objImage.CapNhatKetQuaDinhLuong = true;
            objImage.KetQuaDinhLuong = txtKetQuaThuong.Text;
            objImage.NguongDuoi = nguongDuoi;
            objImage.NguongTren = nguongTren;
            objImage.DKBatThuong = DKDanhGia;
            objImage.Nguoinhap = CurrentuserID;
            objImage.Nguoisua = CurrentuserID;
            objImage.GhiChu = ghiChu;
            objImage.CapNhatDonVi = true;
            objImage.DonViTinh = txtDonViTinh.Text;
            objImage.IDMayXn = idMayXn;
            objImage.PhuongPhap = phuongPhap;
            objImage.NoiKiemTra = noikiemtra;
            objImage.CapNhatGhiChu = LabResultService.KiemtraCapNhatGhiChu(ghiChu, idMayXn, objImage.KetLuan, ghiChuCu, idMayCu, ketquaCu);
            return _xetnghiem.LuuKetQua_SHPT(objImage);
        }

        private void btnNhanHeSo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentMaXn) && !string.IsNullOrEmpty(txtKetQuaThuong.Text))
            {
                var currentResult = txtKetQuaThuong.Text;
                var convertArr = txtKetQuaThuong.Text.Trim().Split(new string[] { " ", "<", ">", "=" }, StringSplitOptions.RemoveEmptyEntries);
                var kqGoc = string.Empty;
                var formatString = string.Empty;

                foreach (string s in convertArr)
                {
                    if (s.Contains("E+") || s.Contains("e+"))
                    {
                        kqGoc = s.Trim();
                        formatString = s.Replace("1", "0")
                                       .Replace("2", "0").Replace("3", "0")
                                       .Replace("4", "0").Replace("5", "0")
                                       .Replace("6", "0").Replace("7", "0")
                                       .Replace("8", "0").Replace("9", "0");
                        formatString = "{0:" + formatString + "}";
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(kqGoc) && !string.IsNullOrEmpty(formatString))
                {
                    var d = decimal.Parse(kqGoc, System.Globalization.NumberStyles.Float) * (decimal)heSo;

                    var kq = string.Format(formatString, d);
                    txtKetQuaHeSo.Text = currentResult.Replace(kqGoc, kq);
                //    btnLuu_Click(sender, e);
                }

                if (currentResult.Contains("E+") || currentResult.Contains("E +") || currentResult.Contains("e+") || currentResult.Contains("e +"))
                {
                    var arrSpl = currentResult.Split(new string[] { "E+", "E +", "e+", "e +" }, StringSplitOptions.RemoveEmptyEntries);
                    if (arrSpl.Length > 1)
                    {
                        var num1 = arrSpl[0];
                        var numConvert = num1.Replace("<", "").Replace(">", "").Replace("=", "").Trim();
                        if (WorkingServices.IsNumeric(numConvert))
                        {
                            var rsul = double.Parse(numConvert) * heSo;
                            var kq = string.Empty;
                            if (lamtron > -1)
                            {
                                var kqRound = Math.Round(rsul, lamtron).ToString();
                                string formatRound = string.Empty;
                                for (int i = 0; i < lamtron; i++)
                                {
                                    formatRound += "0";
                                }
                                var fullFormatstring = string.Empty;
                                if (lamtron > 0)
                                    fullFormatstring = "{0:0." + formatRound + "}";
                                else
                                    fullFormatstring = "{0:0}";

                                kq = string.Format(fullFormatstring, kqRound);
                            }
                            else
                                kq = rsul.ToString();

                            txtKetQuaHeSo.Text = currentResult.Replace(numConvert, kq);
                         //   btnLuu_Click(sender, e);
                        }
                    }
                }
                else if (currentResult.Contains(">") || currentResult.Contains("<") || currentResult.Contains("=") || WorkingServices.IsNumeric(currentResult))
                {
                    var numConvert = currentResult.Replace("<", "").Replace(">", "").Replace("=", "").Trim();
                    if (WorkingServices.IsNumeric(numConvert))
                    {
                        var rsul = double.Parse(numConvert) * heSo;
                        var kq = string.Empty;
                        if (lamtron > -1)
                        {
                            var kqRound = Math.Round(rsul, lamtron).ToString();
                            string formatRound = string.Empty;
                            for (int i = 0; i < lamtron; i++)
                            {
                                formatRound += "0";
                            }
                            var fullFormatstring = string.Empty;
                            if (lamtron > 0)
                                fullFormatstring = "{0:0." + formatRound + "}";
                            else
                                fullFormatstring = "{0:0}";

                            kq = string.Format(fullFormatstring, kqRound);
                        }
                        else
                            kq = rsul.ToString();
                        txtKetQuaHeSo.Text = currentResult.Replace(numConvert, kq);
                       // btnLuu_Click(sender, e);
                    }
                }
            }
        }
    }
}
