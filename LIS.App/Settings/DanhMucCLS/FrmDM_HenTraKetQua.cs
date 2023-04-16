using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmDM_HenTraKetQua : FrmTemplate
    {
        public FrmDM_HenTraKetQua()
        {
            InitializeComponent();
        }
        private ConfigurationDetail _objConfigurationDetail = new ConfigurationDetail();
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();
        #region Load config
        private void Load_LoaiDichVu()
        {
            lueLoaiDichVu.Properties.DataSource = _sysConfig.Data_CauHinh_PhanLoaiChucNang("and EnumID in (1)");
            lueLoaiDichVu.Properties.ValueMember = "MaPhanLoai";
            lueLoaiDichVu.Properties.DisplayMember = "TenPhanLoai";
            lueLoaiDichVu.Properties.AutoHeight = true;
            lueLoaiDichVu.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lueLoaiDichVu.EditValue = ServiceType.ClsXetNghiem.ToString();
            lueLoaiDichVu.Enabled = false;
        }
        private void Load_NhomDichVu()
        {
            var loaidichvu = lueLoaiDichVu.EditValue == null ? string.Empty : lueLoaiDichVu.EditValue.ToString();
            var data = _sysConfig.Load_Nhom_TheoDVCLS(loaidichvu, string.Empty);
            lueNhomDichVu.Properties.DataSource = data;
            lueNhomDichVu.Properties.ValueMember = "MaNhomDichVu".ToLower();
            lueNhomDichVu.Properties.DisplayMember = "TenNhomDichVu".ToLower();
            lueNhomDichVu.Properties.AutoHeight = true;
            lueNhomDichVu.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        private void Load_DSDichVu()
        {
            var loaidichvu = lueLoaiDichVu.EditValue == null ? string.Empty : lueLoaiDichVu.EditValue.ToString();
            var nhomdichvu = lueNhomDichVu.EditValue == null ? string.Empty : lueNhomDichVu.EditValue.ToString();

            var data = _sysConfig.Load_ChiDinhCLS(null, loaidichvu, nhomdichvu, string.Empty, string.Empty, string.Empty, false, true);

            if (data.Rows.Count > 0)
            {
                data.Columns.Add("Them", typeof(string));
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    data.Rows[i]["Them"] = "Thêm";
                }
            }
            gcDanhSachDichVu.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gvDanhSachDichVu.ExpandAllGroups();
        }
        private void Load_DanhSachCauHinh()
        {
            var loaidichvu = lueLoaiDichVu.EditValue == null ? string.Empty : lueLoaiDichVu.EditValue.ToString();
            if (!string.IsNullOrEmpty(loaidichvu))
            {
                gvCauHinh.FocusedRowChanged -= GvCauHinh_FocusedRowChanged;
                gvCauHinh.FocusedColumnChanged -= GvCauHinh_FocusedColumnChanged;
                var data =   _sysConfig.Data_dm_hentraketqua(string.Empty, loaidichvu, string.Empty);
                gcCauHinh.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                gvCauHinh.FocusedColumnChanged += GvCauHinh_FocusedColumnChanged;
                gvCauHinh.FocusedRowChanged += GvCauHinh_FocusedRowChanged;
                if (gvCauHinh.FocusedRowHandle > -1)
                {
                    Get_CauHinh_ChiTiet(gvCauHinh.GetFocusedRowCellValue(colCauHinh_ID.FieldName).ToString());
                }
            }
            else
            {
                gcCauHinh.DataSource = null;
                Clear_Cauhinh();
            }
        }

        private void GvCauHinh_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (gvCauHinh.FocusedRowHandle > -1)
            {
                Get_CauHinh_ChiTiet(gvCauHinh.GetFocusedRowCellValue(colCauHinh_ID.FieldName).ToString());
            }
        }

        private void GvCauHinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCauHinh.FocusedRowHandle > -1)
            {
                Get_CauHinh_ChiTiet(gvCauHinh.GetFocusedRowCellValue(colCauHinh_ID.FieldName).ToString());
            }
        }

        private void Them_CauHinh(string madichVu)
        {
            var loaidichvu = lueLoaiDichVu.EditValue == null ? string.Empty : lueLoaiDichVu.EditValue.ToString();
            var nhomdichvu = lueNhomDichVu.EditValue == null ? string.Empty : lueNhomDichVu.EditValue.ToString();
            var objInsert = new DM_HENTRAKETQUA();
            objInsert.Danhmucnhom = false;
            objInsert.Giobatdau = dtpGioLamSang.Value;
            objInsert.Gioketthuc = dtpGioNhanHenQuaNgay.Value;

            objInsert.Loaidanhmuc = loaidichvu;
            objInsert.Madanhmuc = madichVu;
            objInsert.Thoigianthuchien = 0;
            objInsert.Ngaytrongtuan = Get_Default_Workday();
            var obj = _sysConfig.Insert_dm_hentraketqua(objInsert);
            if (obj.Id > 0)
            {
                Load_DanhSachCauHinh();
                gvCauHinh.MoveLast();
            }
            else
                CustomMessageBox.MSG_Error_OK(obj.Name);
        }
        private void Clear_Cauhinh()
        {
            chkThu2.Checked = chkThu3.Checked = chkThu4.Checked = chkThu5.Checked = chkThu6.Checked = chkThu7.Checked = chkChuNhat.Checked = false;
            radTraKetQuaTrongNgay.Checked = true;
            dtpTGNhanTu.Value = DateTime.Now;
            dtpTGNhanDen.Value = DateTime.Now;
            txtSoNgayThucHien.Text = string.Empty;
            txtSoPhutThucHIen.Text = string.Empty;
            txtSoPhutCapCuu.Text = string.Empty;
            dtpGioTraQuaNgay.Value = DateTime.Now;
            ucSearchLookupEditor_KhuDieuTri1.SelectedValue = null;
            ucSearchLookupEditor_Location1.SelectedValue = null;
            ucSearchLookupEditor_Room1.SelectedValue = null;
            pnCaiDat.Enabled = false;
        }
        private void Calculate_Ngay(string ngayNhan)
        {
            var arrNgayNhan = ngayNhan.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            if (arrNgayNhan.Length > 0)
            {
                foreach (string str in arrNgayNhan)
                {
                    Set_CheckBoxNgay(str);
                }
            }
        }
        private void Set_CheckBoxNgay(string day)
        {
            switch (day)
            {
                case "2":
                    chkThu2.Checked = true;
                    break;
                case "3":
                    chkThu3.Checked = true;
                    break;
                case "4":
                    chkThu4.Checked = true;
                    break;
                case "5":
                    chkThu5.Checked = true;
                    break;
                case "6":
                    chkThu6.Checked = true;
                    break;
                case "7":
                    chkThu7.Checked = true;
                    break;
                case "1":
                    chkChuNhat.Checked = true;
                    break;
                default:
                    break;
            }
        }
        private void Get_CauHinh_ChiTiet(string id)
        {
            var obj = _sysConfig.Get_Info_dm_hentraketqua(id);
            Clear_Cauhinh();

            radTraKetQuaQuaNgay.Checked = obj.Traquangay;
            dtpTGNhanTu.Value = obj.Giobatdau;
            dtpTGNhanDen.Value = obj.Gioketthuc;
            txtSoNgayThucHien.Text = obj.Ngaythuchien.ToString();
            txtSoPhutThucHIen.Text = obj.Thoigianthuchien.ToString();
            txtSoPhutCapCuu.Text = obj.SoPhutCC.ToString();
            dtpGioTraQuaNgay.Value = obj.Giotraquangay;
            ucSearchLookupEditor_KhuDieuTri1.SelectedValue = obj.MaKhuDieuTri;
            ucSearchLookupEditor_Location1.SelectedValue = obj.MaKhoaPhong;
            ucSearchLookupEditor_Room1.SelectedValue = obj.MaPhong;
            if (obj.Giotratrongngay != null)
            {
                dtpGioTraTrongNgay.Value = obj.Giotratrongngay.Value;
            }
            else
                dtpGioTraTrongNgay.Checked = false;

            Calculate_Ngay(obj.Ngaytrongtuan);
        }
        private bool Check_CorrectRule()
        {
            if ((dtpTGNhanTu.Value.TimeOfDay >= dtpGioLamSang.Value.TimeOfDay)
                && (dtpTGNhanDen.Value.TimeOfDay <= dtpGioNghiChieu.Value.TimeOfDay))
                return true;
            else
                return false;
        }
        private void Save_CauHinh_ChiTiet(string id)
        {
            if (Check_CorrectRule())
            {
                var obj = _sysConfig.Get_Info_dm_hentraketqua(id);
                obj.Traquangay = radTraKetQuaQuaNgay.Checked;
                obj.Giobatdau = dtpTGNhanTu.Value;
                obj.Gioketthuc = dtpTGNhanDen.Value;
                obj.Ngaythuchien = int.Parse(string.IsNullOrEmpty(txtSoNgayThucHien.Text) ? "0" : txtSoNgayThucHien.Text);
                obj.Thoigianthuchien = int.Parse(string.IsNullOrEmpty(txtSoPhutThucHIen.Text) ? "0" : txtSoPhutThucHIen.Text);
                obj.Giotraquangay = dtpGioTraQuaNgay.Value;
                obj.SoPhutCC = int.Parse(string.IsNullOrEmpty(txtSoPhutCapCuu.Text) ? "0" : txtSoPhutCapCuu.Text);
                obj.MaKhoaPhong = ucSearchLookupEditor_Location1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_Location1.SelectedValue.ToString();
                obj.MaKhuDieuTri = ucSearchLookupEditor_KhuDieuTri1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_KhuDieuTri1.SelectedValue.ToString();
                obj.MaPhong = ucSearchLookupEditor_Room1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_Room1.SelectedValue.ToString();
                if (dtpGioTraTrongNgay.Checked)
                    obj.Giotratrongngay = dtpGioTraTrongNgay.Value;
                else
                    obj.Giotratrongngay = null;

                obj.Ngaytrongtuan = Convert_CheckBoxNgay();

                _sysConfig.Update_dm_hentraketqua(obj);
                Load_DanhSachCauHinh();
                gvCauHinh.FocusedRowHandle = gvCauHinh.LocateByValue(colCauHinh_ID.FieldName, int.Parse(id));
            }
            else
                CustomMessageBox.MSG_Information_OK("Thời gian nhận không hợp lý so với thời gian làm việc! ");
        }
        private string Convert_CheckBoxNgay()
        {
            string convertResult = string.Empty;
            if (chkThu2.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "2";
            if (chkThu3.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "3";
            if (chkThu4.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "4";
            if (chkThu5.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "5";
            if (chkThu6.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "6";
            if (chkThu7.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "7";
            if (chkChuNhat.Checked)
                convertResult += (string.IsNullOrEmpty(convertResult) ? "" : "|") + "1";

            return convertResult;

        }

        private string Get_Default_Workday()
        {
            var returnString = string.Format("{0}|{1}|{2}|{3}|{4}", "2", "3", "4", "5", "6");
            if ((int)cboNghiCuoiTuan.SelectedValue == (int)EnumNghiCuoiTuan.ChieuThubayChuNhat)
                returnString += string.Format("|{0}", "7");
            else if ((int)cboNghiCuoiTuan.SelectedValue == (int)EnumNghiCuoiTuan.ChuNhat || (int)cboNghiCuoiTuan.SelectedValue == (int)EnumNghiCuoiTuan.ChieuChuNhat || (int)cboNghiCuoiTuan.SelectedValue == (int)EnumNghiCuoiTuan.KhongNghi)
                returnString += string.Format("|{0}|{1}", "7", "1");

            return returnString;

        }
        #endregion
        private void FrmDM_HenTraKetQua_Load(object sender, EventArgs e)
        {
            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSachDichVu);
            ControlExtension.SetLowerCaseForXGridColumns(gvCauHinh);
            Load_LoaiDichVu();
            ucSearchLookupEditor_KhuDieuTri1.Load_DieuTri();
            ucSearchLookupEditor_Location1.Load_DonVi(string.Empty);
            ucSearchLookupEditor_Room1.Load_Phong(string.Empty);
            BindingSource bs = new BindingSource();
            bs.DataSource = NghiCuoiTuan.LisNghiCuoiTuan();
            ControlExtension.BindDataToCobobox(bs, ref cboNghiCuoiTuan, "Id", "NoiDung");

            var dateTimeNowStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var dateTimeNowEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 59);

            _objConfigurationDetail = _sysConfig.GetSystemConfigurationDetail();

            if (_objConfigurationDetail.GioLamViecSang != null)
                dtpGioLamSang.Value = DateTime.ParseExact(_objConfigurationDetail.GioLamViecSang, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
            else
                dtpGioLamSang.Value = dateTimeNowStart;

            if (_objConfigurationDetail.GioLamViecChieu != null)
                dtpGioLamChieu.Value = DateTime.ParseExact(_objConfigurationDetail.GioLamViecChieu, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
            else
                dtpGioLamChieu.Value = dateTimeNowEnd;

            if (_objConfigurationDetail.GioLamViecChieu != null)
                dtpGioNghiTrua.Value = DateTime.ParseExact(_objConfigurationDetail.GioNghiTrua, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
            else
                dtpGioNghiTrua.Value = dateTimeNowStart;

            if (_objConfigurationDetail.GioNghiChieu != null)
                dtpGioNghiChieu.Value = DateTime.ParseExact(_objConfigurationDetail.GioNghiChieu, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
            else
                dtpGioNghiChieu.Value = dateTimeNowEnd;

            if (_objConfigurationDetail.GioLayMauHenQuaNgay != null)
                dtpGioNhanHenQuaNgay.Value = string.IsNullOrEmpty(_objConfigurationDetail.GioLayMauHenQuaNgay) ? DateTime.Now : DateTime.ParseExact(_objConfigurationDetail.GioLayMauHenQuaNgay, "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
            else
                dtpGioNhanHenQuaNgay.Value = dateTimeNowEnd;

            cboNghiCuoiTuan.SelectedValue = _objConfigurationDetail.NghiCuoiTuan;

            dtpTGNhanTu.Value = dateTimeNowStart;
            dtpTGNhanDen.Value = dateTimeNowEnd;

            if (_objConfigurationDetail.GioLamViecSang == null
                || _objConfigurationDetail.GioLamViecChieu == null
                || _objConfigurationDetail.GioLamViecChieu == null
                || _objConfigurationDetail.GioNghiChieu == null
                || _objConfigurationDetail.GioLayMauHenQuaNgay == null
                || _objConfigurationDetail.NghiCuoiTuan < 0
                )
            {
                CustomMessageBox.MSG_Information_OK("Hãy cập nhật đủ thông tin thời gian làm việc.");
            }
        }
        private void radTraKetQuaTrongNgay_CheckedChanged(object sender, EventArgs e)
        {
            txtSoPhutThucHIen.Enabled = radTraKetQuaTrongNgay.Checked;
            dtpGioTraTrongNgay.Enabled = radTraKetQuaTrongNgay.Checked;
            txtSoNgayThucHien.Enabled = dtpGioTraQuaNgay.Enabled = !radTraKetQuaTrongNgay.Checked;
        }

        private void btnEditInformation_Click(object sender, EventArgs e)
        {
            pnCaiDat.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gvCauHinh.FocusedRowHandle > -1)
            {
                Save_CauHinh_ChiTiet(gvCauHinh.GetFocusedRowCellValue(colCauHinh_ID.FieldName).ToString());
            }
        }

        private void lueLoaiDichVu_EditValueChanged(object sender, EventArgs e)
        {
            Load_NhomDichVu();
            Load_DSDichVu();
            Load_DanhSachCauHinh();
        }

        private void lueNhomDichVu_EditValueChanged(object sender, EventArgs e)
        {
            Load_DSDichVu();
        }
        private void btnLuuCauHinhGio_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Lưu cấu hình giờ làm việc?"))
            {
                if (cboNghiCuoiTuan.SelectedIndex > -1)
                {
                    _objConfigurationDetail = _sysConfig.GetSystemConfigurationDetail();
                    _objConfigurationDetail.GioLamViecSang = dtpGioLamSang.Value.ToString("HH:mm:00");
                    _objConfigurationDetail.GioLamViecChieu = dtpGioLamChieu.Value.ToString("HH:mm:00");
                    _objConfigurationDetail.GioNghiTrua = dtpGioNghiTrua.Value.ToString("HH:mm:59");
                    _objConfigurationDetail.GioNghiChieu = dtpGioNghiChieu.Value.ToString("HH:mm:59");
                    _objConfigurationDetail.GioLayMauHenQuaNgay = dtpGioNhanHenQuaNgay.Value.ToString("HH:mm:59");
                    _objConfigurationDetail.NghiCuoiTuan = int.Parse(cboNghiCuoiTuan.SelectedValue.ToString());
                    _sysConfig.InsertUpdateConfiguationDetail(_objConfigurationDetail);
                    CommonAppVarsAndFunctions.sysConfig = _sysConfig.GetSystemConfigurationDetail();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn ngày nghỉ.");
            }

        }

        private void dtpGioTraTrongNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNgayNghi_Click(object sender, EventArgs e)
        {
            var f = new HeThong.FrmDanhMuc_NgayNghi();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
        }

        private void btnSaoChepCauHinh_Click(object sender, EventArgs e)
        {
            if (gvCauHinh.SelectedRowsCount > 0)
            {
                var f = new FrmCheDoCopy_HenTraKQ();
                f.ShowDialog();
                if (f.NhomCLS)
                {
                    if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Sao chép cấu hình hẹn trả kết quả của xét nghiệm đang chọn?"))
                    {
                        return;
                    }
                }
                else if (f.lstMaXn.Count > 0)
                {
                    if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Sao chép cấu hình hẹn trả kết quả của xét nghiệm đang chọn?"))
                    {
                        return;
                    }
                }
                foreach (var item in gvCauHinh.GetSelectedRows())
                {
                    var id = int.Parse(gvCauHinh.GetRowCellValue(item, colCauHinh_ID.FieldName).ToString());
                    if (f.NhomCLS)
                    {
                        _sysConfig.Copy_CauHinhHenTraKQ(lueLoaiDichVu.EditValue.ToString(), id, new List<string>(), true);
                    }
                    else if (f.lstMaXn.Count > 0)
                    {
                        _sysConfig.Copy_CauHinhHenTraKQ(lueLoaiDichVu.EditValue.ToString(), id, f.lstMaXn, false);
                    }
                }
                Load_DanhSachCauHinh();
            }
        }

        private void btnXoaHenGioDuocChon_Click(object sender, EventArgs e)
        {
            if (gvCauHinh.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các hẹn giờ đang chọn?"))
                {
                    foreach (var item in gvCauHinh.GetSelectedRows())
                    {
                        if (item > -1)
                        {
                            var id = gvCauHinh.GetRowCellValue(item, colCauHinh_ID).ToString();
                            _sysConfig.Delete_dm_hentraketqua(id);
                        }

                    }
                    Load_DanhSachCauHinh();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhSachCauHinh();
        }

        private void btnThemDichVu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gvDanhSachDichVu.FocusedRowHandle > -1)
            {
                var madichvu = gvDanhSachDichVu.GetFocusedRowCellValue(colDanhSach_MaDichVu).ToString();
                Them_CauHinh(madichvu);
            }
        }
    }
}
