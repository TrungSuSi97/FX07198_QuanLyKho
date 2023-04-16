using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Controls;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services;
using static TPH.LIS.Common.TestType;
using TPH.LIS.TestResult.Model;
using TPH.LIS.Configuration.Models;
using TPH.Controls;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucKetQua_SHPT_1_Hinh : UserControl
    {
        public ucKetQua_SHPT_1_Hinh()
        {
            InitializeComponent();
            ucGroupHeader1.BackColor = CommonAppColors.ColorMainAppColor;
            ucGroupHeader1.ForeColor = CommonAppColors.ColorTextCaption;
            ucGroupHeader2.BackColor = CommonAppColors.ColorMainAppColor;
            ucGroupHeader2.ForeColor = CommonAppColors.ColorTextCaption;
            lblResult.BackColor = CommonAppColors.ColorMainAppColor;
            lblResult.ForeColor = CommonAppColors.ColorTextCaption;
            lblTacNhan.BackColor = CommonAppColors.ColorMainAppColor;
            lblTacNhan.ForeColor = CommonAppColors.ColorTextCaption;
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
        private bool _kqGen = false;
        float heSo = 0;
        int lamTron = -1;
        string UserNhapKetQua = string.Empty;
        public bool KetQuaGen
        {
            get
            {
                return _kqGen;
            }
            set
            {
                _kqGen = value;

                Check_HienThi();
            }
        }
        private bool _isTacnhan = false;
        public bool IsTacNhan
        {
            get
            {
                return _isTacnhan;
            }
            set
            {
                _isTacnhan = value;
                Check_HienThi();
            }
        }
        private void Check_HienThi()
        {
            pnType.Visible = (_kqGen || _isTacnhan);
            pnKQThuong.Visible = !pnType.Visible;
            pnNhanHeSo.Visible = !pnType.Visible;
            if (pnKQThuong.Visible)
            {
                pnKQThuong.Dock = DockStyle.Fill;
            }
            else
                pnKQThuong.Dock = DockStyle.Top;
            lblGroupTacNhan.Text = (_isTacnhan ? "TÁC NHÂN" : "GEN");
            lblTacNhan.Text = (_isTacnhan ? "Tác nhân" : "GEN");
            lblDVTDinhLuong.Visible = txtDonViTinh.Visible = _isTacnhan;
        }
        private void Check_Lock_Unlock()
        {
            btnPaste.Enabled = !DaXacNhan;
            btnThemGenotype.Enabled = !DaXacNhan;
            dtgKetQuaType.ReadOnly = DaXacNhan;
            btnThemHình.Enabled = !DaXacNhan;
            btnXoaGenotype.Enabled = !DaXacNhan;
            btnXoaHinh.Enabled = !DaXacNhan;
            colKetQua_DinhLuong.ReadOnly = DaXacNhan;
            colKetQua_Gen.ReadOnly = DaXacNhan;
            txtKetQua.ReadOnly = DaXacNhan;
            txtKetQuaHeSo.ReadOnly = DaXacNhan;
            txtDonViTinh.ReadOnly = DaXacNhan;
        }
        private void btnThemHình_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadImage_ToPicturebox(pbHinhKetQua, KichCoHinhSHPT);
        }
        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            pbHinhKetQua.Image = null;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            var obj = Clipboard.GetImage();
            if (obj != null)
            {
               var img2 = GraphicSupport.ResizeImage_NoAutoScale(Clipboard.GetImage(), KichCoHinhSHPT);
                // pbHinhKetQua.Image = GraphicSupport.ResizeImage(Clipboard.GetImage(), new Size(660, 360));
                pbHinhKetQua.Image = img2;
            }
            else
                CustomMessageBox.MSG_Information_OK("Không có thông tin hình ảnh trong clipboard!");
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            var f = new Common.Controls.FrmZoomImage();
            f.pbImage.Image = pbHinhKetQua.Image;
            f.ShowDialog();
        }
        public string Get_KetQua()
        {
            return txtKetQua.Text;
        }
        public void Load_KetQua_Hinh(string maTiepNhan, string maXn
            , string ketqua, float heso, int lamtron, string ketquaheso
            , string userNhapKetQua)
        {
            CurrentMaTiepNhan = maTiepNhan;
            CurrentMaXn = maXn;
            pbHinhKetQua.DataBindings.Clear();
            pbHinhKetQua.Image = null;
            txtKetQua.Text = ketqua;
            heSo = heso;
            lamTron = lamtron;
            txtKetQuaHeSo.Text = ketquaheso;
            UserNhapKetQua = userNhapKetQua;
            if (!string.IsNullOrEmpty(maXn))
            {
                var objImage = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(maTiepNhan, maXn);
                pbHinhKetQua.DataBindings.Add("Image", objImage, "HinhAnh1", true, DataSourceUpdateMode.Never, null);
            }
            Check_Lock_Unlock();
            if (chkTuNhanHeSo.Checked)
                NhanHeSo(true);
        }
        private void Load_TacNhan(string maXNCha)
        {
            if (!string.IsNullOrEmpty(maXNCha))
            {
                var data = _isSysConfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        data = WorkingServices.SearchResult_OnDatatable(data, string.Format("{0} =  {1} and {2} = {3} "
                            , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaimau), (_isTacnhan ? (int)EnumTestType.SHPTTacNhan : (int)EnumTestType.SHPTGen)
                            , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Macaptren), maXNCha));
                    }
                    ControlExtension.BindDataToCobobox(data, ref cboTacNhan, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Maxn), ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Tenxn));
                }
            }
            else
            {
                cboTacNhan.DataSource = null;
            }
        }
        public void Load_KetQua_Gen(DataTable dataPatient, int index, string userID
            , string[] userWorkPlace, string[] arrayAllowNhom, string maXNCha, string maTiepNhan, string donViTinh)
        {
            CurrentMaTiepNhan = maTiepNhan;
            CurrentMaXn = maXNCha;
            CurrentdataPatient = dataPatient;
            int Currentindex = index;
            string CurrentuserID = userID;
            string[] CurrentuserWorkPlace = userWorkPlace;
            string[] CurrentarrayAllowNhom = arrayAllowNhom;
            txtDonViTinh.Text = donViTinh;
            if (!string.IsNullOrEmpty(maXNCha))
            {
                var dataChitiet_gen = _xetnghiem.Data_SHPT_Gen(maTiepNhan, maXNCha, string.Empty);
                ControlExtension.BindDataToGrid(dataChitiet_gen, ref dtgKetQuaType, ref bvKetQuaType);
                Load_TacNhan(maXNCha);
            }
            else
            {
                dtgKetQuaType.DataSource = null;
                bvKetQuaType.BindingSource = null;
            }

            Check_Lock_Unlock();
        }
        public int Luu_KetQua(string nguongTren, string nguongDuoi
            , string DKDanhGia, string ghiChu, string idMayXn, string phuongPhap, string noikiemtra)
        {
            var objImage = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(CurrentMaTiepNhan, CurrentMaXn);
            objImage.Matiepnhan = CurrentMaTiepNhan;
            objImage.Maxn = CurrentMaXn;
            objImage.Hinhanh1 = pbHinhKetQua.Image;
            objImage.KetLuan = txtKetQua.Text;
            objImage.KetQuaHeSo = txtKetQuaHeSo.Text;
            //  objImage.KetQuaHeSo = txtKetQuaHeSo.Text;
            objImage.NguongDuoi = nguongDuoi;
            objImage.NguongTren = nguongTren;
            objImage.DKBatThuong = DKDanhGia;
            objImage.Nguoinhap = CurrentuserID;
            objImage.Nguoisua = CurrentuserID;
            objImage.IDMayXn = idMayXn;
            objImage.KTQuaGenKhac = txtChuGiaiType.Text;
            objImage.GhiChu = ghiChu;
            objImage.CapNhatDonVi = pnType.Visible;
            objImage.DonViTinh = txtDonViTinh.Text;
            objImage.PhuongPhap = phuongPhap;
            objImage.NoiKiemTra = noikiemtra;
            objImage.withImage = pnKQThuong.Visible;
            objImage.suaKetqua = !string.IsNullOrEmpty(UserNhapKetQua);
            return _xetnghiem.LuuKetQua_SHPT(objImage);
        }
        private void btnXoaGenotype_Click(object sender, EventArgs e)
        {
            if (dtgKetQuaType.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kết quả Type đang chọn ?"))
                {
                    var maGen= dtgKetQuaType.CurrentRow.Cells[colKqGen_MaGen.Name].Value.ToString();
                    var maxn = dtgKetQuaType.CurrentRow.Cells[colMaXn.Name].Value.ToString();
                    _xetnghiem.Delete_SHPT_Gen(new KETQUA_CLS_XETNGHIEM_SHPT_GEN
                    {
                        Matiepnhan = CurrentMaTiepNhan
                    ,
                        Maxn = maxn
                    ,
                        Magen = maGen
                    });

                    Load_KetQua_Gen(CurrentdataPatient, Currentindex, CurrentuserID, CurrentuserWorkPlace
                        , CurrentarrayAllowNhom, CurrentMaXn, CurrentMaTiepNhan, txtDonViTinh.Text);
                }
            }
        }
        private void dtgKetQuaType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgKetQuaType.RowCount > 0)
            {
                for (int i = 0; i < dtgKetQuaType.RowCount; i++)
                {
                    var flat = int.Parse(dtgKetQuaType[colKqGen_Flat.Name, i].Value.ToString());
                    FontStyle fs = new FontStyle();
                    var color = LabResultService.MauKQ(flat, ref fs);
                    Font font = new Font("Arial", 10, fs);
                    dtgKetQuaType[colKetQua_Gen.Name, i].Style.Font = font;
                    dtgKetQuaType[colKetQua_Gen.Name, i].Style.ForeColor = color;
                }
            }
        }
        private void btnThemGenotype_Click(object sender, EventArgs e)
        {
            if (cboTacNhan.SelectedIndex > -1)
            {
                var maTacNhan = cboTacNhan.SelectedValue.ToString();
                var ketquaDinhTinh = cboKetQua.Text;
                var ketquaDinhLuong = txtKetQuaDinhLuong.Text;

                CapNhatKetQua(maTacNhan, ketquaDinhTinh, ketquaDinhLuong, false);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn Type");
            }
        }
        private void CapNhatKetQua(string maTacNhan, string ketquaDinhTinh, string ketquaDinhLuong, bool forUpdate)
        {
            if (!string.IsNullOrEmpty(CurrentMaXn) && !string.IsNullOrEmpty(maTacNhan))
            {
                string maTiepNhan = CurrentMaTiepNhan;
                var objPatient = _patient.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });

                var objChiDinh = new KETQUA_CLS_XETNGHIEM_SHPT_GEN();
                objChiDinh.Matiepnhan = CurrentMaTiepNhan;
                objChiDinh.Maxn = CurrentMaXn;
                objChiDinh.Magen = maTacNhan;
                objChiDinh.Ketquadinhluong = ketquaDinhLuong;
                objChiDinh.Ketquadinhtinh = ketquaDinhTinh;
                objChiDinh.Nguoinhap = CurrentuserID;
                objChiDinh.Nguoisua = CurrentuserID;

                bool allowUpdate = false;

                var isExists = _xetnghiem.Check_ExistsSHPT_Gen(objChiDinh.Matiepnhan, objChiDinh.Maxn, objChiDinh.Magen);
                if (isExists)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin tác nhân?"))
                    {
                        allowUpdate = true;
                    }
                }
                else
                    allowUpdate = true;

                if (allowUpdate)
                {
                    _xetnghiem.Insert_Update_SHPT_Gen(objChiDinh);
                    //if (idMayXN > -1)
                    //{
                    //    _xetnghiem.CapNhan_CSBT(maTiepNhan, CurrentMaXn, idMayXN.ToString());
                    //}
                    //lấy dữ liệu xn 
                   // var data = _xetnghiem.Load_ChiDinhXetNghiem(maTiepNhan, maTacNhan);
                   
                  //  var ghiChu = string.Empty;
                    //if (data.Rows.Count > 0)
                    //{
                        //var nguongTren = !string.IsNullOrEmpty(data.Rows[0]["NguongTren"].ToString())
                        //    ? data.Rows[0]["NguongTren"].ToString().ToString().Trim()
                        //    : string.Empty;
                        //var nguongDuoi = !string.IsNullOrEmpty(data.Rows[0]["NguongTren"].ToString())
                        //    ? data.Rows[0]["NguongTren"].ToString().ToString().Trim()
                        //    : string.Empty;
                        //var dieuKienBatThuong = !string.IsNullOrEmpty(data.Rows[0]["DKBatThuong"].ToString())
                        //    ? data.Rows[0]["DKBatThuong"].ToString().ToString().Trim()
                        //    : string.Empty;
                        //var flag = 0;
                        //var userNhap = !string.IsNullOrEmpty(data.Rows[0]["UserNhapKQ"].ToString())
                        //    ? data.Rows[0]["UserNhapKQ"].ToString().ToString().Trim() : CurrentuserID;

                        //var xnChinh = !string.IsNullOrEmpty(data.Rows[0]["XNChinh"].ToString())
                        //    ? bool.Parse(data.Rows[0]["XNChinh"].ToString())
                        //    : false;

                        //var hesoquidoi = !string.IsNullOrEmpty(data.Rows[0]["HeSoQuiDoi"].ToString())
                        //    ? float.Parse(data.Rows[0]["HeSoQuiDoi"].ToString())
                        //    : 0;
                        //var lamtron = string.Empty;

                        //flag = LabResultService.SetColor(ketquaDinhTinh, nguongTren, nguongDuoi, dieuKienBatThuong);

                        //_xetnghiem.CapNhat_KQ_XN(maTiepNhan, maTacNhan, ketquaDinhTinh, true, ghiChu, flag.ToString(), CurrentuserID,
                        //    (!string.IsNullOrWhiteSpace(userNhap)), CurrentMaXn, string.Empty, false
                        //    , string.Empty, string.Empty, string.Empty, string.Empty, false, string.Empty, string.Empty
                        //    , string.Empty, false, string.Empty, string.Empty, false, string.Empty
                        //    , null, false, true, ketquaDinhLuong);

                        //_xetnghiem.CapNhat_DuKQ_XN(maTiepNhan);
                    //}
                }
                Load_KetQua_Gen(CurrentdataPatient, Currentindex, CurrentuserID, CurrentuserWorkPlace
                    , CurrentarrayAllowNhom, CurrentMaXn, CurrentMaTiepNhan, txtDonViTinh.Text);
            }
        }

        private void dtgKetQuaType_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var maTacNhan = dtgKetQuaType[colKqGen_MaGen.Name, e.RowIndex].Value.ToString();
            var ketquaDinhTinh = dtgKetQuaType[colKetQua_Gen.Name, e.RowIndex].Value.ToString(); 
            var ketquaDinhLuong = dtgKetQuaType[colKetQua_DinhLuong.Name, e.RowIndex].Value.ToString();
            CapNhatKetQua(maTacNhan, ketquaDinhTinh, ketquaDinhLuong, true);
        }

        private void cboTacNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboKetQua);
        }

        private void cboKetQua_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKetQuaDinhLuong);
        }

        private void txtKetQuaDinhLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemGenotype);
        }

        private void btnNhanHeSo_Click(object sender, EventArgs e)
        {
            NhanHeSo(false);
        }
        private void NhanHeSo(bool auto)
        {
            if (!string.IsNullOrEmpty(CurrentMaXn) && !string.IsNullOrEmpty(txtKetQua.Text) && DaXacNhan == false && heSo > 0 )
            {
                if ((auto && string.IsNullOrEmpty(txtKetQuaHeSo.Text)) || auto == false)
                {
                    var currentResult = txtKetQua.Text;
                    var convertArr = txtKetQua.Text.Trim().Split(new string[] { " ", "<", ">", "=" }, StringSplitOptions.RemoveEmptyEntries);
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
                    }
                }
            }
        }
    }
}
