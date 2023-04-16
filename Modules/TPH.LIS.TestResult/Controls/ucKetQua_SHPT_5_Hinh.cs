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
using System.Collections.Generic;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucKetQua_SHPT_5_Hinh : UserControl
    {
        public ucKetQua_SHPT_5_Hinh()
        {
            InitializeComponent();
            ucGroupHeader1.BackColor = CommonAppColors.ColorMainAppColor;
            ucGroupHeader1.ForeColor = CommonAppColors.ColorTextCaption;
            ucGroupHeader2.BackColor = CommonAppColors.ColorMainAppColor;
            ucGroupHeader2.ForeColor = CommonAppColors.ColorTextCaption;
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
        public string GenBatThuong
        {
            get
            {
                List<string> lstbatThuong = new List<string>();
                if (dtgKetQuaType.RowCount > 0)
                {
                    for (int i = 0; i < dtgKetQuaType.RowCount; i++)
                    {
                        var flag = int.Parse((dtgKetQuaType[colKqGen_Flat.Name, i].Value ?? "0").ToString());
                        if (flag > 1)
                        {
                            lstbatThuong.Add(dtgKetQuaType[colKqGen_MaGen.Name, i].Value.ToString());
                        }
                    }
                }
                return string.Join(",", lstbatThuong);
            }
        }
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
            ucGroupHeaderTacNhan.GroupCaption = (_isTacnhan ? "TÁC NHÂN" : "GEN");
            lblTacNhan.Text = (_isTacnhan ? "Tác nhân" : "GEN");
            lblDVTDinhLuong.Visible = txtDonViTinh.Visible = _isTacnhan;
        }
        private void Check_Lock_Unlock()
        {
            btnThemGenotype.Enabled = !DaXacNhan;
            dtgKetQuaType.ReadOnly = DaXacNhan;
            btnXoaGenotype.Enabled = !DaXacNhan;
            colKetQua_DinhLuong.ReadOnly = DaXacNhan;
            colKetQua_Gen.ReadOnly = DaXacNhan;
            txtKetQua.ReadOnly = DaXacNhan;
            txtKetQuaHeSo.ReadOnly = DaXacNhan;
            txtDonViTinh.ReadOnly = DaXacNhan;
            btnThemHinh.Enabled = !DaXacNhan;
            LockUnlockPicture(DaXacNhan);
        }
        private void LockUnlockPicture(bool isLock)
        {
            foreach (ucPictureTool uc in pnPictures.Controls)
            {
                uc.Lock_UnlockFunction(isLock);
            }
        }

        public void Load_KetQua_Hinh(string maTiepNhan, string maXn
            , string ketqua, float heso, int lamtron, string ketquaheso
            , string userNhapKetQua)
        {
            XoaHinh();

            CurrentMaTiepNhan = maTiepNhan;
            CurrentMaXn = maXn;
            ucPictureTool1.SetImage = null;
            txtKetQua.Text = ketqua;
            heSo = heso;
            lamTron = lamtron;
            txtKetQuaHeSo.Text = ketquaheso;
            UserNhapKetQua = userNhapKetQua;
            if (!string.IsNullOrEmpty(maXn))
            {
                var objImage = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(maTiepNhan, maXn);
                ucPictureTool1.SetImage = objImage.Hinhanh1;
                if (objImage.Hinhanh2 != null)
                {
                    TinhToaThemHinh(1, objImage.Hinhanh2);
                }
                if (objImage.Hinhanh3 != null)
                {
                    TinhToaThemHinh(1, objImage.Hinhanh3);
                }
                if (objImage.Hinhanh4 != null)
                {
                    TinhToaThemHinh(1, objImage.Hinhanh4);
                }
                if (objImage.Hinhanh5 != null)
                {
                    TinhToaThemHinh(1, objImage.Hinhanh5);
                }
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
                        data = WorkingServices.SearchResult_OnDatatable(data, string.Format("{0} =  '{1}' and {2} = '{3}' "
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
        public string Get_KetQua()
        {
            return txtKetQua.Text;
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
            , string DKDanhGia, string ghiChu, string idMayXn, string phuongPhap, string noikiemtra, string ghiChuCu, int idMayCu, string ketquaCu)
        {
            var objImage = _xetnghiem.Get_Info_ketqua_cls_xetnghiem_spht(CurrentMaTiepNhan, CurrentMaXn);
            objImage.Matiepnhan = CurrentMaTiepNhan;
            objImage.Maxn = CurrentMaXn;
            objImage.Hinhanh1 = ucPictureTool1.GetImage;
            if (pnPictures.Controls.Count>1)
            {
                var pic = (ucPictureTool)pnPictures.Controls[1];
                objImage.Hinhanh2 = pic.GetImage;
            }
            if (pnPictures.Controls.Count > 2)
            {
                var pic = (ucPictureTool)pnPictures.Controls[2];
                objImage.Hinhanh3 = pic.GetImage;
            }
            if (pnPictures.Controls.Count > 3)
            {
                var pic = (ucPictureTool)pnPictures.Controls[3];
                objImage.Hinhanh4 = pic.GetImage;
            }
            if (pnPictures.Controls.Count > 4)
            {
                var pic = (ucPictureTool)pnPictures.Controls[4];
                objImage.Hinhanh5 = pic.GetImage;
            }
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
            objImage.CapNhatGhiChu = LabResultService.KiemtraCapNhatGhiChu(ghiChu, idMayXn, objImage.KetLuan, ghiChuCu, idMayCu, ketquaCu);
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

        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            if (pnPictures.Controls.Count < 5)
            {
                TinhToaThemHinh(1, null);
            }
            else
                CustomMessageBox.MSG_Information_OK("Giới hạn 5 hình cho 1 kết quả.");
        }
        int limitPicHeight = 175;
        private void TinhToaThemHinh(int slHinh, Image img)
        {
            var width = 515;
            if (pnPictures.Controls.Count == 1)
            {
                var pic = (ucPictureTool)pnPictures.Controls[0];
                pic.Dock = DockStyle.None;
                pic.Width = width;
                pic.Height = limitPicHeight;
                //pic.Location = new Point (0,0);
               
            }
            for (int i = 0; i < slHinh; i++)
            {
                var picNew = new ucPictureTool();
                picNew.Name = string.Format("pic{0}", pnPictures.Controls.Count);
                picNew.Width = width;
                picNew.SetImage = img;
                pnPictures.Controls.Add(picNew);
                //set location
                picNew.Height = limitPicHeight;
            }
            TinhToanKichCoHinhAnh();
        }
        private void XoaHinh()
        {
            if (pnPictures.Controls.Count > 1)
            {
                for (int i = 1; i < pnPictures.Controls.Count; i++)
                {
                    pnPictures.Controls.RemoveAt(i);
                    i--;
                }
            }
            ucPictureTool1.Width = pnPictures.Width - 7;
            ucPictureTool1.Height = pnPictures.Height - 7;
        }

        private void TinhToanKichCoHinhAnh()
        {
            var totalHinh = pnPictures.Controls.Count;
            if (totalHinh == 5 || totalHinh > 2)
            {
                var totalRow = (int)(Math.Round((float)totalHinh / 2, 0));
                var totalPicHeight = totalRow * limitPicHeight;
                if(totalPicHeight < pnPictures.Height)
                {
                    limitPicHeight = (pnPictures.Height / totalRow) - 6;
                    foreach (ucPictureTool item in pnPictures.Controls)
                    {
                        item.Height = limitPicHeight;
                    }
                }
            }
        }

        private void ucKetQua_SHPT_5_Hinh_SizeChanged(object sender, EventArgs e)
        {
            if (pnPictures.Controls.Count == 1)
            {
                ucPictureTool1.Width = pnPictures.Width - 7;
                ucPictureTool1.Height = pnPictures.Height - 7;
            }
        }
    }
}
