using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Cashier.CashierContanst;
using TPH.Cashier.Model;
using TPH.Cashier.Service;
using TPH.Excel;
using TPH.HIS.Model;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Services;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Statistics.Models;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;


namespace TPH.LIS.App.Statistics
{
    public partial class FrmBaoCaoDoanhThu : FrmTemplate
    {
        public FrmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        private readonly ICashierService _isCashier = new CashierService();
        IPatientInformationService _iPatient = new PatientInformationService();
        ITestResultService _iTestResult = new TestResultService();

        private C_Patient_SieuAm p_sieuam = new C_Patient_SieuAm();
        private C_Patient_XQuang p_xquang = new C_Patient_XQuang();
        private C_Patient_NoiSoi p_noisoi = new C_Patient_NoiSoi();
        private C_Patient_KhamBenh p_khambenh = new C_Patient_KhamBenh();
        private C_Patient_DichVu_Khac p_dvkhac = new C_Patient_DichVu_Khac();
        private THUPHI_THUOC_DAL thuphiThuocDAL = new THUPHI_THUOC_DAL();

        BaoCaoThuTienModel objKetChuyen = new BaoCaoThuTienModel();
        private void FrmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            if (!ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenThuNgan, UserConstant.PermissionCashierManageCashierData))
                xtraTabControl1.TabPages.Remove(xtraTabPage2);

            Load_DanhSachThuNgan();
            Load_DanhSachKetChuyenThuNgan();
            btnKetChuyen.Visible = dtpTuNgayKetChuyen.Enabled = dtpDenNgayKetChuyen.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenThuNgan, UserConstant.PermissionCashierLockIncomeData);
        }
        private void Load_DanhSachThuNgan()
        {
            C_NguoiDung user = new C_NguoiDung();
            user.Get_Group_UserSign(cboThuNgan, ServiceType.ThuNgan, " and d.MaNguoiDung not in ('admin')");
            cboThuNgan.SelectedValue = CommonAppVarsAndFunctions.UserID;
            user.Get_Group_UserSign(cboBienLaiThuNgan, ServiceType.ThuNgan, " and d.MaNguoiDung not in ('admin')");
            cboBienLaiThuNgan.SelectedValue = CommonAppVarsAndFunctions.UserID;
        }
        private void Load_DanhSachKetChuyenThuNgan()
        {
            C_NguoiDung user = new C_NguoiDung();
            user.Get_Group_UserSign(cboDSKetChuyenThuNgan, ServiceType.ThuNgan, " and d.MaNguoiDung not in ('admin')");
            cboDSKetChuyenThuNgan.SelectedValue = CommonAppVarsAndFunctions.UserID;
        }
        private StatisticsCashierCondition getConditKetChuyen()
        {
            var obj = new StatisticsCashierCondition();
            obj.NgayThuTien = dtpNgayThuKetChuyen.Value;
            obj.ThuNgan = (cboThuNgan.SelectedIndex > -1 ? cboThuNgan.SelectedValue.ToString() : string.Empty);
            return obj;
        }
        private StatisticsCashierCondition getConditDanHSachKetChuyen()
        {
            var obj = new StatisticsCashierCondition();
            obj.TuNgay = dtpTuNgayKetChuyen.Value;
            obj.DenNgay = dtpDenNgayKetChuyen.Value;

            obj.ThuNgan = (cboDSKetChuyenThuNgan.SelectedIndex > -1 ? cboDSKetChuyenThuNgan.SelectedValue.ToString() : string.Empty);
            return obj;
        }
        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            TongHopDuLieuKetChuyen();
        }
        private void TongHopDuLieuKetChuyen()
        {
            if (cboThuNgan.SelectedIndex > -1)
            {
                CustomMessageBox.ShowAlert("Đang tổng hợp số liệu!");
                Clear_KetQua();
                objKetChuyen = _iStatistic.BaoCaoThuTien(getConditKetChuyen());

                txtTongSoBL.Text = objKetChuyen.TongBienLaiThu > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongBienLaiThu).Trim() : "0";
                txtTongDoanhThu.Text = objKetChuyen.TongTienDoanhThu > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongTienDoanhThu).Trim() : "0";
                txtTongSoBLHoan.Text = objKetChuyen.TongBienLaiHoan > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongBienLaiHoan).Trim() : "0";
                txtTongSoDaThu.Text = objKetChuyen.TongTienDaThu > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongTienDaThu).Trim() : "0";
                txtTongSoNo.Text = objKetChuyen.TongTienConNo > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongTienConNo).Trim() : "0";
                txtTongTienHoan.Text = objKetChuyen.TongTienHoan > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongTienHoan).Trim() : "0";
                txtTongBienLaiChuaThu.Text = objKetChuyen.TongBienLaiChuaThu > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongBienLaiChuaThu).Trim() : "0";
                txtTongTienBLChuThu.Text = objKetChuyen.TongTienChuaThu > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongTienChuaThu).Trim() : "0";
                txtTongThu.Text = objKetChuyen.TongTienThuThuc > 0 ? string.Format("{0:### ### ### ###.###}", objKetChuyen.TongTienThuThuc).Trim() : "0";
                btnKetChuyen.Enabled = true;

                if (objKetChuyen.TongTienChuaThu > 0)
                {
                    txtTongTienBLChuThu.BackColor = Color.Yellow;
                    btnKetChuyen.Enabled = false;
                }
                if (objKetChuyen.TongTienConNo > 0)
                {
                    txtTongSoNo.BackColor = Color.Yellow;
                    btnKetChuyen.Enabled = false;
                }

                CustomMessageBox.CloseAlert();
            }
            else
                CustomMessageBox.MSG_Waring_OK("Hãy chọn thu ngân.");
        }

        private void Clear_KetQua()
        {
            txtTongDoanhThu.Text = "";
            txtTongDoanhThu.BackColor = Color.Empty;

            txtTongSoBL.BackColor = Color.Empty;
            txtTongSoBL.Text = "";

            txtTongSoBLHoan.BackColor = Color.Empty;
            txtTongSoBLHoan.Text = "";

            txtTongSoDaThu.BackColor = Color.Empty;
            txtTongSoDaThu.Text = "";

            txtTongSoNo.BackColor = Color.Empty;
            txtTongSoNo.Text = "";

            txtTongTienHoan.BackColor = Color.Empty;
            txtTongTienHoan.Text = "";

            txtTongBienLaiChuaThu.BackColor = Color.Empty;
            txtTongBienLaiChuaThu.Text = "";

            txtTongTienBLChuThu.BackColor = Color.Empty;
            txtTongTienBLChuThu.Text = "";

            txtTongThu.BackColor = Color.Empty;
            txtTongThu.Text = "";
            btnKetChuyen.Enabled = false;
        }

        private void cboThuNgan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_KetQua();
        }

        private void dtpNgayThu_ValueChanged(object sender, EventArgs e)
        {
            Clear_KetQua();
        }
        private void btnKetChuyen_Click(object sender, EventArgs e)
        {
            TongHopDuLieuKetChuyen();
            if (btnKetChuyen.Enabled)
            {
                CustomMessageBox.ShowAlert("Đang thực hiện kết chuyển và khóa dữ liệu!");
                //1. Insert dữ liệu vào bảng lock
                var idKetChuyen = _isCashier.Lay_IDKetChuyen();
                var objLockKEtChuyen = new P_PAYMENT_LOCK();
                objLockKEtChuyen.Idketchuyen = idKetChuyen;
                objLockKEtChuyen.Ngaythutien = dtpNgayThuKetChuyen.Value;
                objLockKEtChuyen.Thungan = cboThuNgan.SelectedValue.ToString();
                objLockKEtChuyen.Tongno = (decimal)objKetChuyen.TongTienConNo;
                objLockKEtChuyen.Tongsobienlaihoan = int.Parse(objKetChuyen.TongBienLaiHoan.ToString());
                objLockKEtChuyen.Tongsobienlaithu = int.Parse(objKetChuyen.TongBienLaiThu.ToString());
                objLockKEtChuyen.Tongthucthu = (decimal)objKetChuyen.TongTienThuThuc;
                objLockKEtChuyen.Tongtienhoan = (decimal)objKetChuyen.TongTienHoan;
                objLockKEtChuyen.Tongtienthu = (decimal)objKetChuyen.TongTienDaThu;
                objLockKEtChuyen.Maytinh = Environment.MachineName;

                var objreturn = _isCashier.Insert_p_payment_lock(objLockKEtChuyen);
                if (objreturn.Id == -1)
                {
                    idKetChuyen = _isCashier.Lay_IDKetChuyen();
                    objLockKEtChuyen.Idketchuyen = idKetChuyen;
                    objreturn = _isCashier.Insert_p_payment_lock(objLockKEtChuyen);
                }
                if (objreturn.Id > -1)
                {
                    if (_isCashier.Update_Lock_payment(idKetChuyen, cboThuNgan.SelectedValue.ToString(), dtpNgayThuKetChuyen.Value))
                    {
                        dtpTuNgayKetChuyen.Value = dtpNgayThuKetChuyen.Value;
                        dtpDenNgayKetChuyen.Value = dtpNgayThuKetChuyen.Value;

                        ControlExtension.BindDataToGrid(_iStatistic.DanhSachDaKetChuyen(getConditDanHSachKetChuyen()), ref dtgDanhSachKetChuyen, bvDanHSAchKetChuyen);
                    }
                }
                CustomMessageBox.CloseAlert();
            }
        }
        private void btnKetChuyenXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(dtgDanhSachKetChuyen);
        }

        private void btnBienLaiXuatExcel_Click(object sender, EventArgs e)
        {
            //   ExportToExcel.Export(dtgBienLai);
        }

        private void btmXemDuLieuKetChuyen_Click(object sender, EventArgs e)
        {
            ControlExtension.BindDataToGrid(_iStatistic.DanhSachDaKetChuyen(getConditDanHSachKetChuyen()), ref dtgDanhSachKetChuyen, bvDanHSAchKetChuyen);
        }

        private void btnBienLaiXemDuLieu_Click(object sender, EventArgs e)
        {
            var userThuNgan = TPH.Common.Converter.StringConverter.ToString(cboBienLaiThuNgan.SelectedValue);
            var data = _isCashier.Data_p_payment(string.Empty, string.Empty, dtpBienLaiTuNgay.Value, dtpBienLaiDenNgay.Value, userThuNgan);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            bvBienLai.BindingSource = bs;
            gcBienLai.DataSource = bs;
            gvBienLai.ExpandAllGroups();
        }

        private void Load_ChitietBienLai()
        {
            DataTable data = new DataTable();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            bvChiTietBienLai.BindingSource = bs;
            gcChiTietBienLai.DataSource = bs;

            if (gvBienLai.RowCount > 0 && gvBienLai.FocusedRowHandle > -1)
            {
                string maTiepNhan = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaTiepNhan));
                string idBienlai = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaBienLai));
                if (!string.IsNullOrEmpty(maTiepNhan) && !string.IsNullOrEmpty(idBienlai))
                {
                    EnumThaoTacThuPhi loai = (EnumThaoTacThuPhi)Enum.Parse(typeof(EnumThaoTacThuPhi), gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThaoTac).ToString());
                    Get_ChiTietBienLai(maTiepNhan, idBienlai, loai);
                }
            }
        }
        private void Get_ChiTietBienLai(string maTiepNhan, string idBienlai, EnumThaoTacThuPhi loai)
        {
            DataTable data = new DataTable();
            data = _isCashier.Data_DanhSachChiDinh_BL(idBienlai, loai, EnumChon.TatCa, true);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            bvChiTietBienLai.BindingSource = bs;
            gcChiTietBienLai.DataSource = bs;
            gvChiTietBienlai.ExpandAllGroups();
        }
        private void gvBienLai_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_ChitietBienLai();
        }

        private void XoaBienLai()
        {
            if (gvBienLai.GetSelectedRows().Length > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa thông tin biên lai được chọn ?"))
                {
                    foreach (int i in gvBienLai.GetSelectedRows())
                    {
                        string maTiepNhan = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(i, colBienLaiMaTiepNhan));
                        string idBienlai = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(i, colBienLaiMaBienLai));
                        if (!string.IsNullOrEmpty(maTiepNhan) && !string.IsNullOrEmpty(idBienlai))
                        {
                            EnumThaoTacThuPhi loai = (EnumThaoTacThuPhi)Enum.Parse(typeof(EnumThaoTacThuPhi), gvBienLai.GetRowCellValue(i, colBienLaiThaoTac).ToString());
                            Get_ChiTietBienLai(maTiepNhan, idBienlai, loai);
                            var lstSelctedItem = Get_SelectedDetail_List(false);
                            if (lstSelctedItem.Count > 0)
                            {
                                if (_isCashier.CapNhat_ThuTien(maTiepNhan, false, lstSelctedItem, idBienlai))
                                {
                                    if (_isCashier.XoaBienLaiVaHoanTien(idBienlai) && chkXoaThongTinBN.Checked)
                                    {
                                        var OrderedServices = _iPatient.OrderedServices(" MaTiepNhan = '" + maTiepNhan + "'", true);
                                        Xoa_ChiDinh(OrderedServices);
                                        _iPatient.Delete_BenhNhan_TiepNhan(maTiepNhan, CommonAppVarsAndFunctions.UserID);
                                    }
                                }
                            }
                            else
                                _iPatient.Delete_BenhNhan_TiepNhan(maTiepNhan, CommonAppVarsAndFunctions.UserID);
                        }
                    }
                    btnBienLaiXemDuLieu_Click(btnBienLaiXemDuLieu, new EventArgs());
                }
                else
                    CustomMessageBox.MSG_Information_OK("Không có biên lai nào được chọn!");
            }
        }
        private List<CashierItemSelected> Get_SelectedDetail_List(bool withSelectedRow)
        {
            List<CashierItemSelected> lst = new List<CashierItemSelected>();

            if (gvChiTietBienlai.RowCount > 0)
            {
                for (int i = 0; i < gvChiTietBienlai.RowCount; i++)
                {
                    if (gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu) != null)
                    {
                        var isAllowAdd = true;
                        if (withSelectedRow)
                            isAllowAdd = gvChiTietBienlai.IsRowSelected(i);

                        if (isAllowAdd)
                        {
                            var dathuTien = (bool)gvChiTietBienlai.GetRowCellValue(i, colBienLai_DaThuTien);
                            var daHoatien = (bool)gvChiTietBienlai.GetRowCellValue(i, colBienLai_DaHoanTien);
                            lst.Add(new CashierItemSelected
                            {
                                ItemId = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu).ToString(),
                                ItemName = gvChiTietBienlai.GetRowCellValue(i, colBienLai_TenDichVu).ToString(),
                                ItemCatagory = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaPhanLoai).ToString(),
                                IsProfile = false,
                                ProfileId = string.Empty,
                                ItemCount = 1,
                                ItemCost = double.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_Dongia).ToString()),
                                ItemUnit = gvChiTietBienlai.GetRowCellValue(i, colBienLai_DonViTinh).ToString(),
                                TestGruopId = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaNhomDichVu).ToString(),
                                TestGroupName = gvChiTietBienlai.GetRowCellValue(i, colBienLai_TenNhomDichVu).ToString(),
                                ItemSort = int.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_ThuTuInDichVu).ToString()),
                                GroupSort = int.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_ThuTuInNhom).ToString()),
                                MaChiDan = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaChiDan).ToString()
                            });
                        }
                    }
                }
            }
            return lst;
        }

        private void Xoa_ChiDinh(List<Patient.Model.SeviceOrderedInformation> OrderedServices)
        {
            var _DV_CLS = string.Empty;
            var _maChidinh = string.Empty;
            var _tenChidinh = string.Empty;
            var matiepnhan = string.Empty;
            var _profileID = string.Empty;
            foreach (var itm in OrderedServices)
            {
                _DV_CLS = itm.MaPhanLoai;

                _profileID = itm.MaProfile;
                _maChidinh = itm.MaChiDinh;
                _tenChidinh = itm.TenChiDinh;
                matiepnhan = itm.MaTiepNhan;
                if (!string.IsNullOrEmpty(_DV_CLS))
                {
                    if (_DV_CLS.Equals(ServiceType.ClsXetNghiem.ToString()))
                    {
                        if (itm.ChiDinhCha)
                        {
                            _iTestResult.Delete_ChiDinhCLS_XN(matiepnhan, _maChidinh, _profileID, CommonAppVarsAndFunctions.UserID, false);
                        }
                        else
                        {
                            _iTestResult.Delete_ChiDinhCLS_XN(matiepnhan, _maChidinh, string.Empty, CommonAppVarsAndFunctions.UserID, false);
                        }
                    }
                    else if (_DV_CLS.Equals(ServiceType.ClsSieuAm.ToString()))
                    {
                        p_sieuam.Delete_ChiDinhCLS_SieuAm(matiepnhan, _maChidinh);
                    }
                    else if (_DV_CLS.Equals(ServiceType.ClsXQuang.ToString()))
                    {
                        p_xquang.Delete_ChiDinhCLS_XQuang(matiepnhan, _maChidinh);
                    }
                    else if (_DV_CLS.Equals(ServiceType.ClsNoiSoi.ToString()))
                    {
                        p_noisoi.Delete_ChiDinhCLS_NoiSoi(matiepnhan, _maChidinh);
                    }
                    else if (_DV_CLS.Equals(ServiceType.KhamBenh.ToString()))
                    {
                        p_khambenh.Delete_ChiDinh_KhamBenh(matiepnhan, "KB", _maChidinh);
                    }
                    else if (_DV_CLS.Equals(ServiceType.Duoc.ToString()))
                    {
                        thuphiThuocDAL.Delete_THUPHI_THUOC(new AppCode.PropertiesMember.THUPHI_THUOC(string.Empty,
                            string.Empty, false, false, 0,
                            string.Empty, string.Empty, string.Empty, string.Empty, _maChidinh,
                            matiepnhan, string.Empty, string.Empty, 0, 0, 0, string.Empty,
                            DateTime.Now, 0, string.Empty, string.Empty, false));
                    }
                }
            }
        }

        private void btnXoaBienLai_Click(object sender, EventArgs e)
        {
            XoaBienLai();
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chi tiết biên lai đang chọn ?"))
            {
                string maTiepNhan = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaTiepNhan));
                string idBienlai = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaBienLai));
                EnumThaoTacThuPhi loai = (EnumThaoTacThuPhi)Enum.Parse(typeof(EnumThaoTacThuPhi), gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThaoTac).ToString());

                if (gvChiTietBienlai.SelectedRowsCount > 0)
                {
                    var lstSelctedItem = Get_SelectedDetail_List(true);
                    if (lstSelctedItem.Count > 0)
                    {
                        var orderedServices = _iPatient.OrderedServices(" MaTiepNhan = '" + maTiepNhan + "'", true);

                        if (_isCashier.CapNhat_ThuTien(maTiepNhan, false, lstSelctedItem, idBienlai))
                        {
                            foreach (var itm in lstSelctedItem)
                            {
                                if (_isCashier.XoaChiTietBienLaiVaHoanTien(idBienlai, itm.ItemId) && chkXoaThongTinBN.Checked)
                                {
                                    if (loai == EnumThaoTacThuPhi.ThuTien)
                                    {
                                        var selectedOrder = orderedServices.Where(x => x.MaChiDinh.Equals(itm.ItemId) && x.MaPhanLoai.Equals(itm.ItemCatagory));
                                        if (selectedOrder != null)
                                        {
                                            Xoa_ChiDinh(selectedOrder.ToList());
                                        }
                                    }
                                }
                            }
                            _isCashier.TinhToanLaiTienThu(idBienlai, loai);
                        }
                    }
                }
                btnBienLaiXemDuLieu_Click(btnBienLaiXemDuLieu, new EventArgs());
                gvBienLai.FocusedRowHandle = bvBienLai.BindingSource.Find("MaTiepNhan", maTiepNhan);
            }
        }
    }
}
