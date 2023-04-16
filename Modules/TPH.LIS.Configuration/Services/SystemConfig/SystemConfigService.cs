using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.StringCryptography;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Model;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Repositories.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.LIS.Configuration.Services.SystemConfig
{
    public class SystemConfigService : ISystemConfigService
    {
        private readonly ISystemConfigRepository _systemConfigRepository;

        public SystemConfigService() : this(null)
        {

        }

        public SystemConfigService(SystemConfigRepository systemConfigRepository)
        {
            _systemConfigRepository = systemConfigRepository ?? new SystemConfigRepository();
        }

        public ConfigurationDetail GetSystemConfigurationDetail(string withLocaionID = "")
        {
            var result = _systemConfigRepository.GetSystemConfigurationDetail(withLocaionID);
            if (result != null)
            {
                result.BenhNhanSoKyTuBarCode = string.IsNullOrWhiteSpace(result.BenhNhanSoKyTuBarCode)
                    ? SystemStypeConstant.DefaultNumberOfBarcodeChar
                    : result.BenhNhanSoKyTuBarCode;

                result.BenhNhanCheDoSoThuTu = string.IsNullOrWhiteSpace(result.BenhNhanCheDoSoThuTu)
                    ? SystemStypeConstant.AutoBarcode
                    : result.BenhNhanCheDoSoThuTu;

                result.ClsNoiSoiKichCoXemHinh = string.IsNullOrWhiteSpace(result.ClsNoiSoiKichCoXemHinh)
                    ? SystemStypeConstant.DefaultImageSize
                    : result.ClsNoiSoiKichCoXemHinh;

                result.ClsSieuAmKichCoXemHinh = string.IsNullOrWhiteSpace(result.ClsSieuAmKichCoXemHinh)
                    ? SystemStypeConstant.DefaultImageSize
                    : result.ClsSieuAmKichCoXemHinh;

                result.ClsDienTimKichCoKetQua = string.IsNullOrWhiteSpace(result.ClsDienTimKichCoKetQua)
                    ? SystemStypeConstant.DefaultImageSize
                    : result.ClsDienTimKichCoKetQua;
            }
            return result;
        }

        public void InsertUpdateConfiguationDetail(ConfigurationDetail objconfig)
        {
            _systemConfigRepository.InsertUpdateConfiguationDetail(objconfig);
        }
        public int SaveConfig_WithConfigID(string maCauHinh, string mayTinh, string giaTri)
        {
            return _systemConfigRepository.SaveConfig_WithConfigID(maCauHinh, mayTinh, giaTri);
        }
        public int Check_UpdateSoftware(string pcName, string fileVersion, string appName)
        {
            return _systemConfigRepository.Check_UpdateSoftware(pcName, fileVersion, appName);
        }
        public int Update_PcLogin(string pcName, string versionId, string ip, string appName)
        {
            return _systemConfigRepository.Update_PcLogin(pcName, versionId, ip, appName);
        }
        public int Update_PcLogin_FileInfo(string pcName, string fileInfo)
        {
            return _systemConfigRepository.Update_PcLogin_FileInfo(pcName, fileInfo);
        }
        #region Cấu hình danh mục loại dịch vụ
        public DataTable Data_CauHinh_PhanLoaiChucNang(string filter)
        { return _systemConfigRepository.Data_CauHinh_PhanLoaiChucNang(filter); }
        public void Get_CauHinh_PhanLoaiChucNang(ComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_CauHinh_PhanLoaiChucNang(cbo, filter, ref dt);
        }
        public void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_CauHinh_PhanLoaiChucNang(cbo, filter);
        }
        public void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, TextBox txt, string filter)
        {
            _systemConfigRepository.Get_CauHinh_PhanLoaiChucNang(cbo, txt, filter);
        }
        #endregion

        #region Load danh sách tổng hợp
        public DataTable Load_Nhom_TheoDVCLS(string nhomDichVu, string filter = "")
        {
            return _systemConfigRepository.Load_Nhom_TheoDVCLS(nhomDichVu, filter);
        }
        public DataTable Load_ChiDinhCLS(CustomComboBox cbo, string loaiDichVu, string nhomCd, string sex
            , string maDoiTuongDv, string filter = "", bool ForClick = true, bool forConfig = false)
        {
            return _systemConfigRepository.Load_ChiDinhCLS(cbo, loaiDichVu, nhomCd, sex, maDoiTuongDv, filter, ForClick, forConfig);
        }
        public DataTable ConvertColumnName_DanhMucDichVu(DataTable _danhSachChiDinh)
        {
            return _systemConfigRepository.ConvertColumnName_DanhMucDichVu(_danhSachChiDinh);
        }
        #endregion
        public bool Check_ExistsMaXN(string MaXN)
        {
            return _systemConfigRepository.Check_ExistsMaXN(MaXN);
        }
        public void AddNewTest(string code, string name, string group, string unit,
            string normal, string lower, string upper, string price, bool isBoldName,
            bool isBoldResult, bool isMainTest, string criteria, string sampleType
            , string printNo, string orderNo, bool ignoreCheckResult)
        {
            lower = string.IsNullOrWhiteSpace(lower) ? "NULL" : lower;
            upper = string.IsNullOrWhiteSpace(upper) ? "NULL" : upper;
            price = string.IsNullOrWhiteSpace(price) ? "0" : price;
            var boldName = isBoldName ? "1" : "0";
            var boldResult = isBoldResult ? "1" : "0";
            var mainTest = isMainTest ? "1" : "0";
            criteria = string.IsNullOrWhiteSpace(criteria) ? "NULL" : "N'" + criteria + "'";

            _systemConfigRepository.AddNewTest(code, name, group.Trim(), unit, normal,
                lower, upper, price, boldName, boldResult, mainTest, criteria, sampleType
                , printNo, orderNo, ignoreCheckResult);
        }

        public DataTable GetDM_XetNghiem_CauHinhMaMayXn(int idMayXN)
        {
            return _systemConfigRepository.GetDM_XetNghiem_CauHinhMaMayXn(idMayXN);
        }
        #region dm_xetnghiem
        public int Insert_dm_xetnghiem(DM_XETNGHIEM objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem(objInfo);
        }
        public int Update_dm_xetnghiem(DM_XETNGHIEM objInfo)
        {
            return _systemConfigRepository.Update_dm_xetnghiem(objInfo);
        }
        public int Delete_dm_xetnghiem(string maxn)
        {
            return _systemConfigRepository.Delete_dm_xetnghiem(maxn);
        }
        public DM_XETNGHIEM Get_Info_dm_xetnghiem(DataRow drInfo)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem(drInfo);
        }
        public DM_XETNGHIEM Get_Info_dm_xetnghiem(string maxn)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem(maxn);
        }
        public bool CheckExists_dm_xetnghiem(string maxn)
        {
            return _systemConfigRepository.CheckExists_dm_xetnghiem(maxn);
        }
        public DataTable Data_dm_xetnghiem(string phanquyenNhom, bool checkQuyenNhom, string maxn)
        {
            return _systemConfigRepository.Data_dm_xetnghiem(phanquyenNhom, checkQuyenNhom, maxn);
        }
        public DataTable Data_dm_xetnghiem_NotInProfile(string profileID)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_NotInProfile(profileID);
        }
        public DataTable Data_dm_xetnghiem_NotInMappingMaMy(int idMayXn)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_NotInMappingMaMy(idMayXn);
        }
        public DataTable XetNghiemDangDung(string testCode)
        {
            return _systemConfigRepository.XetNghiemDangDung(testCode);
        }
        public DataTable GetDM_XetNghiem_CoNhomCLSVaProfile(bool chiXNDichVu)
        {
            return _systemConfigRepository.GetDM_XetNghiem_CoNhomCLSVaProfile(chiXNDichVu);
        }
        #endregion
        #region dm_xetnghiem_nhom
        public int Insert_dm_xetnghiem_nhom(DM_XETNGHIEM_NHOM objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_nhom(objInfo);
        }

        public int Update_dm_xetnghiem_nhom(DM_XETNGHIEM_NHOM objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_nhom(objInfo);
        }

        public int Delete_dm_xetnghiem_nhom(string manhomcls)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_nhom(manhomcls);
        }

        public DataTable Data_dm_xetnghiem_nhom(string manhomcls)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_nhom(manhomcls);
        }
        public DM_XETNGHIEM_NHOM Get_Info_dm_xetnghiem_nhom(string manhomcls)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem_nhom(manhomcls);
        }
        public DM_XETNGHIEM_NHOM Get_Info_dm_xetnghiem_nhom(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_nhom(drInfo);
        }

        public bool CheckExists_dm_xetnghiem_nhom(string manhomcls)
        {
            return _systemConfigRepository.CheckExists_dm_xetnghiem_nhom(manhomcls);

        }

        #endregion
        #region dm_xetnghiem_profile
        public int Insert_dm_xetnghiem_profile(DM_XETNGHIEM_PROFILE objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_profile(objInfo);
        }

        public int Update_dm_xetnghiem_profile(DM_XETNGHIEM_PROFILE objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_profile(objInfo);
        }

        public int Delete_dm_xetnghiem_profile(string profileid)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_profile(profileid);
        }

        public DataTable Data_dm_xetnghiem_profile(string profileid)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_profile(profileid);
        }
        public DM_XETNGHIEM_PROFILE Get_Info_dm_xetnghiem_profile(string profileid)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_profile(profileid);
        }
        public DM_XETNGHIEM_PROFILE Get_Info_dm_xetnghiem_profile(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_profile(drInfo);
        }

        public bool CheckExists_dm_xetnghiem_profile(string profileid)
        {
            return _systemConfigRepository.CheckExists_dm_xetnghiem_profile(profileid);
        }

        #endregion
        #region dm_xetnghiem_profile_chitiet
        public int Insert_dm_xetnghiem_profile_chitiet(DM_XETNGHIEM_PROFILE_CHITIET objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_profile_chitiet(objInfo);
        }

        public int Update_dm_xetnghiem_profile_chitiet(DM_XETNGHIEM_PROFILE_CHITIET objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_profile_chitiet(objInfo);
        }

        public int Delete_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_profile_chitiet(profileid, maxn);
        }

        public DataTable Data_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_profile_chitiet(profileid, maxn);
        }

        public DM_XETNGHIEM_PROFILE_CHITIET Get_Info_dm_xetnghiem_profile_chitiet(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_profile_chitiet(drInfo);
        }

        public DM_XETNGHIEM_PROFILE_CHITIET Get_Info_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_profile_chitiet(profileid, maxn);
        }

        public bool CheckExists_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_profile_chitiet(profileid, maxn);
        }

        #endregion
        #region dm_xetnghiem_tinhtoan
        public int Insert_dm_xetnghiem_tinhtoan(DM_XETNGHIEM_TINHTOAN objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_tinhtoan(objInfo);
        }

        public int Update_dm_xetnghiem_tinhtoan(DM_XETNGHIEM_TINHTOAN objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_tinhtoan(objInfo);
        }

        public int Delete_dm_xetnghiem_tinhtoan(int id)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_tinhtoan(id);
        }

        public DataTable Data_dm_xetnghiem_tinhtoan(int? id)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_tinhtoan(id);
        }

        public DM_XETNGHIEM_TINHTOAN Get_Info_dm_xetnghiem_tinhtoan(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_tinhtoan(drInfo);
        }

        public DM_XETNGHIEM_TINHTOAN Get_Info_dm_xetnghiem_tinhtoan(int id)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_tinhtoan(id);
        }

        public bool CheckExists_dm_xetnghiem_tinhtoan(int id)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_tinhtoan(id);
        }

        #endregion
        #region dm_xetnghiem_csbt
        public int Insert_dm_xetnghiem_csbt(DM_XETNGHIEM_CSBT objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_csbt(objInfo);
        }

        public int Update_dm_xetnghiem_csbt(DM_XETNGHIEM_CSBT objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_csbt(objInfo);
        }

        public int Delete_dm_xetnghiem_csbt(int autoid)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_csbt(autoid);
        }

        public DataTable Data_dm_xetnghiem_csbt(int? autoid, string maxn)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_csbt(autoid, maxn);
        }

        public DM_XETNGHIEM_CSBT Get_Info_dm_xetnghiem_csbt(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_csbt(drInfo);
        }
        public DM_XETNGHIEM_CSBT Get_Info_dm_xetnghiem_csbt(int autoid)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_csbt(autoid);
        }

        public bool CheckExists_dm_xetnghiem_csbt(int autoid)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_csbt(autoid);
        }

        #endregion
        #region dm_xetnghiem_biendichketqua
        public int Insert_dm_xetnghiem_biendichketqua(DM_XETNGHIEM_BIENDICHKETQUA objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_biendichketqua(objInfo);
        }

        public int Update_dm_xetnghiem_biendichketqua(DM_XETNGHIEM_BIENDICHKETQUA objInfo)
        {
            return _systemConfigRepository.Update_dm_xetnghiem_biendichketqua(objInfo);
        }

        public int Delete_dm_xetnghiem_biendichketqua(int autoid)
        {
            return _systemConfigRepository.Delete_dm_xetnghiem_biendichketqua(autoid);
        }

        public DataTable Data_dm_xetnghiem_biendichketqua(int? autoid)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_biendichketqua(autoid);
        }

        public DM_XETNGHIEM_BIENDICHKETQUA Get_Info_dm_xetnghiem_biendichketqua(DataRow drInfo)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem_biendichketqua(drInfo);
        }
        public DM_XETNGHIEM_BIENDICHKETQUA Get_Info_dm_xetnghiem_biendichketqua(int autoid)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem_biendichketqua(autoid);
        }

        public bool CheckExists_dm_xetnghiem_biendichketqua(int autoid)
        {
            return _systemConfigRepository.CheckExists_dm_xetnghiem_biendichketqua(autoid);
        }

        #endregion
        public DataTable GetTestGroup(string filter, string filter2 = "")
        {
            return _systemConfigRepository.GetTestGroup(filter, filter2);
        }
        public void GetTestGroup(CustomComboBox cbo, string filter, string filter2 = "")
        {
            ControlExtension.BindDataToCobobox(GetTestGroup(string.Empty, filter), ref cbo, "MaNhomCLS", "MaNhomCLS", "MaNhomCLS,TenNhomCLS", "50,150");
        }
        public void GetTestGroup(ComboBox cbo, string filter, string filter2 = "")
        {
            ControlExtension.BindDataToCobobox(GetTestGroup(string.Empty, filter), ref cbo, "MaNhomCLS", "MaNhomCLS");
        }
        public DataTable GetSubclinical(string filter)
        {
            return _systemConfigRepository.GetSubclinical(filter);
        }
        public DataTable GetSubclinical(ref SqlDataAdapter da, ref DataTable data, string filter)
        {
            return _systemConfigRepository.GetSubclinical(ref da, ref data, filter);
        }
        public void GetSubclinical(CustomComboBox cbo, string filter)
        {
            ControlExtension.BindDataToCobobox(GetSubclinical(filter), ref cbo, "MaPhanLoai", "MaNhap", "MaPhanLoai,TenPhanLoai", "100,150");
        }
        public DataTable GetSubclinicalTest_NoProfile(string filter)
        {
            return _systemConfigRepository.GetSubclinicalTest_NoProfile(filter);
        }
        public DataTable GetData_Profile_SLSS()
        {
            return _systemConfigRepository.GetData_Profile_SLSS();
        }
        public DataTable GetSubclinicalTestAndProfile(CustomComboBox cbo, string maNhom, string maDoiTuongDv, string filter2 = "", bool checkMagoTat = true)
        {
            return _systemConfigRepository.GetSubclinicalTestAndProfile(cbo, maNhom, maDoiTuongDv, filter2, checkMagoTat);
        }
        public DataTable GetTestCaculate(string filter)
        {
            return _systemConfigRepository.GetTestCaculate(filter);
        }
        public DataTable GetTestingMachines()
        {
            return _systemConfigRepository.GetTestingMachines();
        }
        public BaseModel AddNewTestingMachine(TestingMachineModel testingMachineInfo)
        {
            return _systemConfigRepository.AddNewTestingMachine(testingMachineInfo);
        }
        public BaseModel UpdateTestingMachine(TestingMachineModel testingMachineInfo)
        {
            return _systemConfigRepository.UpdateTestingMachine(testingMachineInfo);
        }
        public bool DeleteTestingMachine(TestingMachineModel testingMachineInfo)
        {
            return _systemConfigRepository.DeleteTestingMachine(testingMachineInfo);
        }
        public DataTable GetTestingMachines(string id, string testingCode, string testingMachineCode)
        {
            return _systemConfigRepository.GetTestingMachines(id, testingCode, testingMachineCode);
        }
        public DataTable GetNormalRange(string maxn, int? idMay)
        {
            return _systemConfigRepository.GetNormalRange(maxn, idMay);
        }
        public List<DM_XETNGHIEM_CSBT> ListNormalRange(DataTable dataNormalRange)
        {
            return _systemConfigRepository.ListNormalRange(dataNormalRange);
        }
        #region Nhân viên
        public DataTable Data_dm_nhomnhanvien()
        {
            return _systemConfigRepository.Data_dm_nhomnhanvien();
        }
        public BaseModel Insert_ql_nhanvien(QL_NHANVIEN objInfo)
        {
            return _systemConfigRepository.Insert_ql_nhanvien(objInfo);
        }

        public bool Update_ql_nhanvien(QL_NHANVIEN objInfo)
        {

            return _systemConfigRepository.Update_ql_nhanvien(objInfo);
        }

        public bool Delete_ql_nhanvien(QL_NHANVIEN objInfo)
        {

            return _systemConfigRepository.Delete_ql_nhanvien(objInfo);
        }

        public DataTable Data_ql_nhanvien(string manhanvien, string manhomNhanvien)
        {

            return _systemConfigRepository.Data_ql_nhanvien(manhanvien, manhomNhanvien);
        }
        public QL_NHANVIEN Get_Info_ql_nhanvien(string manhanvien, string manhomNhanvien)
        {

            return _systemConfigRepository.Get_Info_ql_nhanvien(manhanvien, manhomNhanvien);
        }
        #endregion
        #region Bộ phận
        public BaseModel Insert_dm_bophan(DM_BOPHAN objInfo)
        {
            return _systemConfigRepository.Insert_dm_bophan(objInfo);
        }

        public bool Update_dm_bophan(DM_BOPHAN objInfo)
        {

            return _systemConfigRepository.Update_dm_bophan(objInfo);
        }

        public bool Delete_dm_bophan(DM_BOPHAN objInfo)
        {

            return _systemConfigRepository.Delete_dm_bophan(objInfo);
        }

        public DataTable Data_dm_bophan(string mabophan, string maphanloai)
        {

            return _systemConfigRepository.Data_dm_bophan(mabophan, maphanloai);
        }

        public DataTable Get_Data_dm_bophan(DataGridView dtg, BindingNavigator bv, string mabophan, string maphanloai)
        {

            return _systemConfigRepository.Get_Data_dm_bophan(dtg, bv, mabophan, maphanloai);
        }

        public DataTable Get_Data_dm_bophan(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabophan, string maphanloai)
        {

            return _systemConfigRepository.Get_Data_dm_bophan(dtg, bv, ref sqlDataAdapter, ref dtData, mabophan, maphanloai);
        }

        public DataTable Get_Data_dm_bophan(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabophan, string maphanloai)
        {

            return _systemConfigRepository.Get_Data_dm_bophan(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, mabophan, maphanloai);
        }

        public DM_BOPHAN Get_Info_dm_bophan(string mabophan, string maphanloai)
        {

            return _systemConfigRepository.Get_Info_dm_bophan(mabophan, maphanloai);
        }

        #endregion

        #region Khoa phòng

        public BaseModel AddNewLocation(LocationDepartmentModel locationInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG (";
            sqlQuery += "\nMakhoaphong";
            sqlQuery += "\n,Tenkhoaphong";
            sqlQuery += "\n,Khongsudung";
            sqlQuery += "\n,Diachi";
            sqlQuery += "\n,Email";
            sqlQuery += "\n,Dienthoai";
            sqlQuery += "\n,Website";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n" + "'" + locationInfo.Makhoaphong.ToString() + "'";
            sqlQuery += "\n," +
                        (locationInfo.Tenkhoaphong == null ? "NULL" : "N'" + locationInfo.Tenkhoaphong.ToString() + "'");
            sqlQuery += "\n," + (bool.Parse(locationInfo.Khongsudung.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (locationInfo.Diachi == null ? "NULL" : "N'" + locationInfo.Diachi.ToString() + "'");
            sqlQuery += "\n," + (locationInfo.Email == null ? "NULL" : "N'" + locationInfo.Email.ToString() + "'");
            sqlQuery += "\n," +
                        (locationInfo.Dienthoai == null ? "NULL" : "N'" + locationInfo.Dienthoai.ToString() + "'");
            sqlQuery += "\n," + (locationInfo.Website == null ? "NULL" : "N'" + locationInfo.Website.ToString() + "'");
            if (
                DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG where 1 = 1  and Makhoaphong =  " + "'" +
                                          locationInfo.Makhoaphong.ToString() + "'"))
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã khoa phòng đã tồn tại ! \nHãy nhập mã máy khác."
                };
            }
            else
            {

                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery),
                    Name = string.Empty
                };
            }
        }

        public BaseModel UpdateLocation(LocationDepartmentModel objInfo, string maKhoaPhongOld)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG set";
            sqlQuery += "\n Makhoaphong = '" + objInfo.Makhoaphong.ToString() + "'";
            sqlQuery += "\n, Tenkhoaphong = " +
                        (objInfo.Tenkhoaphong == null ? "NULL" : "N'" + objInfo.Tenkhoaphong.ToString() + "'");
            sqlQuery += "\n, Khongsudung = " + (bool.Parse(objInfo.Khongsudung.ToString()) ? "1" : "0");
            sqlQuery += "\n, Diachi = " + (objInfo.Diachi == null ? "NULL" : "N'" + objInfo.Diachi.ToString() + "'");
            sqlQuery += "\n, Email = " + (objInfo.Email == null ? "NULL" : "N'" + objInfo.Email.ToString() + "'");
            sqlQuery += "\n, Dienthoai = " +
                        (objInfo.Dienthoai == null ? "NULL" : "N'" + objInfo.Dienthoai.ToString() + "'");
            sqlQuery += "\n, Website = " + (objInfo.Website == null ? "NULL" : "N'" + objInfo.Website.ToString() + "'");
            sqlQuery += "\nwhere Makhoaphong = '" + maKhoaPhongOld.Trim() + "'";
            if (
                DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG where Makhoaphong =  '" +
                                          objInfo.Makhoaphong.ToString() + "'"))
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã khoa phòng đã tồn tại ! \nHãy nhập mã máy khác."
                };
            }
            else
            {

                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery),
                    Name = string.Empty
                };
            }
        }

        public bool DeleteLocation(LocationDepartmentModel objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Makhoaphong = " + "'" + objInfo.Makhoaphong.ToString() + "'";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery) > 0;
        }

        private string SQLSelect_Data_DM_KhoaPhong(string makhoaphong, string tenKhoaPhong, string maBophan = "")
        {
            string strSql = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG where 1=1";
            if (!string.IsNullOrEmpty(makhoaphong))
                strSql += "\n and  makhoaphong = '" + makhoaphong + "'";
            if (!string.IsNullOrEmpty(tenKhoaPhong))
                strSql += "\n and  Tenkhoaphong like '%" + tenKhoaPhong + "%'";
            if (!string.IsNullOrEmpty(maBophan))
                strSql += "\n and  mabophan in " + (string.Format("({0})",
                    (maBophan.Contains("'") ? maBophan : string.Format("'{0}'", maBophan))));
            return strSql;
        }

        public DataTable GetLocation(string makhoaphong, string tenKhoaPhong, string maBophan = "")
        {
            using (
                var data = DataProvider.ExecuteDataset(CommandType.Text,
                    SQLSelect_Data_DM_KhoaPhong(makhoaphong, tenKhoaPhong, maBophan)))
            {
                if (data != null && data.Tables.Count > 0)
                {
                    return data.Tables[0];
                }
            }
            return null;
        }

        public DataTable GetLocation(DataGridView dtg, BindingNavigator bv, string makhoaphong, string tenKhoaPhong)
        {
            var dtData = new DataTable();
            dtData = GetLocation(makhoaphong, tenKhoaPhong);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }

        public DataTable GetLocation(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, TextBox txt, int linkColumnIndex,
            string makhoaphong, string mabophan)
        {
            var dtData = GetLocation(makhoaphong, string.Empty, mabophan);
            if (cbo != null)
            {
                ControlExtension.BindDataToCobobox(dtData.Copy(), ref cbo, valueColumn, displayColumn, columnsName,
                    columnsWidth, txt, linkColumnIndex);
            }
            return dtData;
        }

        public LocationDepartmentModel Get_Info_LocationDepartment(string makhoaphong)
        {
            return _systemConfigRepository.Get_Info_LocationDepartment(makhoaphong);
        }


        #endregion

        #region Khu Vuc
        public BaseModel Insert_dm_khuvuc(DM_KHUVUC objInfo)
        {
            return _systemConfigRepository.Insert_dm_khuvuc(objInfo);
        }

        public bool Update_dm_khuvuc(DM_KHUVUC objInfo)
        {

            return _systemConfigRepository.Update_dm_khuvuc(objInfo);
        }

        public bool Delete_dm_khuvuc(DM_KHUVUC objInfo)
        {

            return _systemConfigRepository.Delete_dm_khuvuc(objInfo);
        }

        public DataTable Data_dm_khuvuc(string makhuvuc)
        {

            return _systemConfigRepository.Data_dm_khuvuc(makhuvuc);
        }

        public DataTable Get_Data_dm_khuvuc(DataGridView dtg, BindingNavigator bv, string makhuvuc)
        {

            return _systemConfigRepository.Get_Data_dm_khuvuc(dtg, bv, makhuvuc);
        }

        public DataTable Get_Data_dm_khuvuc(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string makhuvuc)
        {

            return _systemConfigRepository.Get_Data_dm_khuvuc(dtg, bv, ref sqlDataAdapter, ref dtData, makhuvuc);
        }

        public DataTable Get_Data_dm_khuvuc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string makhuvuc)
        {

            return _systemConfigRepository.Get_Data_dm_khuvuc(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, makhuvuc);
        }

        public DM_KHUVUC Get_Info_dm_khuvuc(string makhuvuc)
        {

            return _systemConfigRepository.Get_Info_dm_khuvuc(makhuvuc);
        }
        public DM_KHUVUC Get_Info_dm_khuvuc(DataRow dr)
        {

            return _systemConfigRepository.Get_Info_dm_khuvuc(dr);
        }
        #endregion
        #region KhuVuc-MayTinh
        public BaseModel Insert_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo)
        {
            return _systemConfigRepository.Insert_dm_khuvuc_maytinh(objInfo);
        }

        public bool Update_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo)
        {

            return _systemConfigRepository.Update_dm_khuvuc_maytinh(objInfo);
        }

        public bool Delete_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo)
        {

            return _systemConfigRepository.Delete_dm_khuvuc_maytinh(objInfo);
        }

        public DataTable Data_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {

            return _systemConfigRepository.Data_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh);
        }

        public DataTable Get_Data_dm_khuvuc_maytinh(DataGridView dtg, BindingNavigator bv, string id, string makhuvuc, string tenmaytinh)
        {

            return _systemConfigRepository.Get_Data_dm_khuvuc_maytinh(dtg, bv, id, makhuvuc, tenmaytinh);
        }

        public DataTable Get_Data_dm_khuvuc_maytinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter
            , ref DataTable dtData, string id, string makhuvuc, string tenmaytinh)
        {

            return _systemConfigRepository.Get_Data_dm_khuvuc_maytinh(dtg, bv, ref sqlDataAdapter, ref dtData, id, makhuvuc, tenmaytinh);
        }

        public DataTable Get_Data_dm_khuvuc_maytinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName
            , string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string makhuvuc, string tenmaytinh)
        {

            return _systemConfigRepository.Get_Data_dm_khuvuc_maytinh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth
                , txt, LinkColumnIndex, id, makhuvuc, tenmaytinh);
        }

        public DM_KHUVUC_MAYTINH Get_Info_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {

            return _systemConfigRepository.Get_Info_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh);
        }
        public DataTable DataThongTinKhuVucTheomayTinh(string pcName)
        {
            return _systemConfigRepository.DataThongTinKhuVucTheomayTinh(pcName);
        }

        public List<DM_KHUVUC_MAYTINH> Get_LstInfo_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {
            return _systemConfigRepository.Get_LstInfo_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh);
        }
        public List<DM_KHUVUC_MAYTINH> Get_LstInfo_dm_khuvuc_maytinh(string tenmaytinh)
        {
            return _systemConfigRepository.Get_LstInfo_dm_khuvuc_maytinh(tenmaytinh);
        }
        public int[] GetPCHisWorking(string tenmaytinh, string makhuvuc)
        {
            return _systemConfigRepository.GetPCHisWorking(tenmaytinh, makhuvuc);
        }
        public DataTable Data_dm_khuVu_maytinh(string makhuvuc, string tenmaytinh)
        {
            return _systemConfigRepository.Data_dm_khuVu_maytinh(makhuvuc, tenmaytinh);
        }
        #endregion
        #region dm_xetnghiem_mauphieuin
        public BaseModel Insert_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_mauphieuin(objInfo);
        }

        public bool Update_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_mauphieuin(objInfo);
        }

        public bool Delete_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_mauphieuin(objInfo);
        }

        public DataTable Data_dm_xetnghiem_mauphieuin(string idmauketqua)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_mauphieuin(idmauketqua);
        }
        public DataTable DSMauPhieuIn_ThaoTac()
        {
            return _systemConfigRepository.DSMauPhieuIn_ThaoTac();
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin(DataGridView dtg, BindingNavigator bv, string idmauketqua)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin(dtg, bv, idmauketqua);
        }

        public DataTable Get_Data_dm_xetnghiem_mauphieuin(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauketqua)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin(dtg, bv, ref sqlDataAdapter, ref dtData, idmauketqua);
        }

        public DataTable Get_Data_dm_xetnghiem_mauphieuin(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauketqua)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idmauketqua);
        }

        public DM_XETNGHIEM_MAUPHIEUIN Get_Info_dm_xetnghiem_mauphieuin(string idmauketqua)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_mauphieuin(idmauketqua);
        }

        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_mauphieuin_vitri
        public BaseModel Insert_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_mauphieuin_vitri(objInfo);
        }

        public bool Update_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_mauphieuin_vitri(objInfo);
        }

        public bool Delete_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_mauphieuin_vitri(objInfo);
        }

        public DataTable Data_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem);
        }

        public DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(DataGridView dtg, BindingNavigator bv, string idmauketqua, string mavitri, string maxetnghiem)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin_vitri(dtg, bv, idmauketqua, mavitri, maxetnghiem);
        }

        public DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauketqua, string mavitri, string maxetnghiem)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin_vitri(dtg, bv, ref sqlDataAdapter, ref dtData, idmauketqua, mavitri, maxetnghiem);
        }

        public DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauketqua, string mavitri, string maxetnghiem)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin_vitri(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idmauketqua, mavitri, maxetnghiem);
        }

        public DM_XETNGHIEM_MAUPHIEUIN_VITRI Get_Info_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem);
        }
        public BaseModel Insert_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_mauphieuin_tuychon(objInfo);
        }

        public bool Update_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_mauphieuin_tuychon(objInfo);
        }

        public bool Delete_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_mauphieuin_tuychon(objInfo);
        }
        public DataTable Data_dm_xetnghiem_mauphieuin_tuychon_CoMauCha(string idmauchon)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_mauphieuin_tuychon_CoMauCha(idmauchon);
        }
        public DataTable Data_dm_xetnghiem_mauphieuin_tuychon(string idmauchon)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_mauphieuin_tuychon(idmauchon);
        }

        public DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(DataGridView dtg, BindingNavigator bv, string idmauchon)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin_tuychon(dtg, bv, idmauchon);
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauchon)
        {
            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin_tuychon(dtg, bv, ref sqlDataAdapter, ref dtData, idmauchon);
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauchon)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_mauphieuin_tuychon(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idmauchon);
        }

        public DM_XETNGHIEM_MAUPHIEUIN_TUYCHON Get_Info_dm_xetnghiem_mauphieuin_tuychon(string idmauchon)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_mauphieuin_tuychon(idmauchon);
        }
        #endregion
        //================================|||=====================================
        #region cauhinh_mayinketqua
        public BaseModel Insert_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo)
        {
            return _systemConfigRepository.Insert_cauhinh_mayinketqua(objInfo);
        }

        public bool Update_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo, CAUHINH_MAYINKETQUA objInfoOld)
        {

            return _systemConfigRepository.Update_cauhinh_mayinketqua(objInfo, objInfoOld);
        }

        public bool Delete_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo)
        {

            return _systemConfigRepository.Delete_cauhinh_mayinketqua(objInfo);
        }

        public DataTable Data_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid)
        {

            return _systemConfigRepository.Data_cauhinh_mayinketqua(pcname, printername, reporttemplateid);
        }

        public DataTable Get_Data_cauhinh_mayinketqua(DataGridView dtg, BindingNavigator bv, string pcname, string printername, string reporttemplateid)
        {

            return _systemConfigRepository.Get_Data_cauhinh_mayinketqua(dtg, bv, pcname, printername, reporttemplateid);
        }

        public DataTable Get_Data_cauhinh_mayinketqua(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string pcname, string printername, string reporttemplateid)
        {

            return _systemConfigRepository.Get_Data_cauhinh_mayinketqua(dtg, bv, ref sqlDataAdapter, ref dtData, pcname, printername, reporttemplateid);
        }

        public DataTable Get_Data_cauhinh_mayinketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string pcname, string printername, string reporttemplateid)
        {

            return _systemConfigRepository.Get_Data_cauhinh_mayinketqua(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, pcname, printername, reporttemplateid);
        }

        public CAUHINH_MAYINKETQUA Get_Info_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid)
        {

            return _systemConfigRepository.Get_Info_cauhinh_mayinketqua(pcname, printername, reporttemplateid);
        }
        public List<CAUHINH_MAYINKETQUA> ListCauHinhMayIn(string tenmaytinh)
        {
            return _systemConfigRepository.ListCauHinhMayIn(tenmaytinh);
        }
        #endregion
        #region Danh mục siêu âm
        public void Get_NhomCLS_SieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_NhomCLS_SieuAm(dtg, bv, filter, ref dt);
        }
        public void Get_NhomCLS_SieuAm(ref SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
        ref DataTable dt)
        {
            _systemConfigRepository.Get_NhomCLS_SieuAm(ref da, dtg, bv, filter, ref dt);
        }
        public void Get_NhomCLS_SieuAm(ComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_NhomCLS_SieuAm(cbo, filter, ref dt);
        }
        public DataTable Get_NhomCLS_SieuAm(ComboBox cbo, string filter)
        {
            return _systemConfigRepository.Get_NhomCLS_SieuAm(cbo, filter);
        }
        public DataTable Get_NhomCLS_SieuAm(CustomComboBox cbo, string filter)
        {
            return _systemConfigRepository.Get_NhomCLS_SieuAm(cbo, filter);
        }
        public void Get_DMSieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DMSieuAm(dtg, bv, filter, ref dt);
        }
        public DataTable Get_DMSieuAm(string filter)
        {
            return _systemConfigRepository.Get_DMSieuAm(filter);
        }
        public int Insert_MaySieuAm(string tenMay)
        {
            return _systemConfigRepository.Insert_MaySieuAm(tenMay);
        }
        public DataTable Get_DMSieuAm(CustomComboBox cbo, string filter, string maDoiTuongDv)
        {
            return _systemConfigRepository.Get_DMSieuAm(cbo, filter, maDoiTuongDv);
        }
        public void Get_DMMaySA(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DMMaySA(da, dtg, bv, filter, ref dt);
        }
        public void Get_DMMaySA(CustomComboBox cbo)
        {
            _systemConfigRepository.Get_DMMaySA(cbo);
        }
        public void Get_DMMaySA(ComboBox cbo)
        {
            _systemConfigRepository.Get_DMMaySA(cbo);
        }
        public int Insert_Update_DMSieuAm(string maNhomSieuAm, string maSoMau, string goTat, string tenMauSieuAm,
    string tenChiDinh, string tieuDePhieuKetQua, string gioiTinhSuDung, string chanDoanMacDinh,
    string ketluanMacDinh, string deNghi, string soLuongHinh, string soTrangIn, string noiDung1, string noiDung2,
    bool insert)
        {
            return _systemConfigRepository.Insert_Update_DMSieuAm(maNhomSieuAm, maSoMau, goTat, tenMauSieuAm,
     tenChiDinh, tieuDePhieuKetQua, gioiTinhSuDung, chanDoanMacDinh, ketluanMacDinh, deNghi, soLuongHinh, soTrangIn, noiDung1, noiDung2, insert);
        }
        #endregion
        #region Dah mục nội soi
        public bool Insert_Update_DMNoiSoi(string maNhomNoiSoi, string maSoMauNoiSoi, string goTat, string tenMauNoiSoi,
 string tenChiDinh, string tieuDePhieuKetQua, string gioiTinhSuDung, string chanDoanMacDinh, string ketluanMacDinh, string deNghi, string soLuongHinh, string soTrangIn, string noiDung1, string noiDung2, bool insert)
        {
            return _systemConfigRepository.Insert_Update_DMNoiSoi(maNhomNoiSoi, maSoMauNoiSoi, goTat, tenMauNoiSoi,
 tenChiDinh, tieuDePhieuKetQua, gioiTinhSuDung, chanDoanMacDinh, ketluanMacDinh, deNghi, soLuongHinh, soTrangIn, noiDung1, noiDung2, insert);
        }
        public void Get_DM_NoiSoi_KetQuaHP(CustomDatagridView dtg, BindingNavigator bv, ref SqlDataAdapter da, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_NoiSoi_KetQuaHP(dtg, bv, ref da, ref dt);
        }
        public void Get_DM_NoiSoi_KetQuaHP(CustomComboBox cbo, TextBox txt)
        {
            _systemConfigRepository.Get_DM_NoiSoi_KetQuaHP(cbo, txt);
        }
        public void Get_DM_NoiSoi_KyThuatHP(CustomDatagridView dtg, BindingNavigator bv, ref SqlDataAdapter da, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_NoiSoi_KyThuatHP(dtg, bv, ref da, ref dt);
        }
        public void Get_DM_NoiSoi_KyThuatHP(CustomComboBox cbo, TextBox txt)
        {
            _systemConfigRepository.Get_DM_NoiSoi_KyThuatHP(cbo, txt);
        }
        public void Get_DMMayNS(CustomComboBox cbo)
        {
            _systemConfigRepository.Get_DMMayNS(cbo);
        }
        public void Get_DMMayNS(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DMMayNS(da, dtg, bv, filter, ref dt);
        }
        public DataTable Get_DMNoiSoi(CustomComboBox cbo, string filter, string maDoiTuongDv)
        {
            return _systemConfigRepository.Get_DMNoiSoi(cbo, filter, maDoiTuongDv);
        }
        public void Insert_MayNoiSoi(string tenMay)
        {
            _systemConfigRepository.Insert_MayNoiSoi(tenMay);
        }
        public DataTable Get_DMNoiSoi(string filter)
        {
            return _systemConfigRepository.Get_DMNoiSoi(filter);
        }
        public void Get_DMNoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DMNoiSoi(dtg, bv, filter, ref dt);
        }
        public DataTable Get_NhomCLS_NoiSoi(CustomComboBox cbo, string filter)
        {
            return _systemConfigRepository.Get_NhomCLS_NoiSoi(cbo, filter);
        }
        public DataTable Get_NhomCLS_NoiSoi(ComboBox cbo, string filter)
        {
            return _systemConfigRepository.Get_NhomCLS_NoiSoi(cbo, filter);
        }
        public void Get_NhomCLS_NoiSoi(ComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_NhomCLS_NoiSoi(cbo, filter, ref dt);
        }
        public void Get_NhomCLS_NoiSoi(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_NhomCLS_NoiSoi(da, dtg, bv, filter, ref dt);
        }
        public void Get_NhomCLS_NoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_NhomCLS_NoiSoi(dtg, bv, filter, ref dt);
        }
        #endregion
        #region Danh mục thuốc
        //Gốc thuốc
        public void Get_DM_Thuoc_GocThuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_GocThuoc(dtg, bv, filter, ref dt);
        }

        public void Get_DM_Thuoc_GocThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_GocThuoc(da, dtg, bv, filter,
            ref dt);
        }

        public void Get_DM_Thuoc_GocThuoc(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_GocThuoc(cbo, filter, ref dt);
        }

        public void Get_DM_Thuoc_GocThuoc(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_DM_Thuoc_GocThuoc(cbo, filter);
        }

        public bool Insert_GocThuoc(string maGocThuoc, string tenGocThuoc, string maNhomThuoc, string thuTuIn)
        {
            return _systemConfigRepository.Insert_GocThuoc(maGocThuoc, tenGocThuoc, maNhomThuoc, thuTuIn);
        }

        //Nhóm thuốc
        public void Get_DM_Thuoc_NhomThuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_NhomThuoc(dtg, bv, filter, ref dt);
        }

        public void Get_DM_Thuoc_NhomThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_NhomThuoc(da, dtg, bv, filter,
            ref dt);
        }

        public DataTable Get_DM_Thuoc_NhomThuoc(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            return _systemConfigRepository.Get_DM_Thuoc_NhomThuoc(cbo, filter, ref dt);
        }

        public DataTable Get_DM_Thuoc_NhomThuoc(CustomComboBox cbo)
        {
            return _systemConfigRepository.Get_DM_Thuoc_NhomThuoc(cbo);
        }

        public bool Insert_NhomThuoc(string maNhomThuoc, string tenNhomThuoc)
        {
            return _systemConfigRepository.Insert_NhomThuoc(maNhomThuoc, tenNhomThuoc);
        }

        //Thuốc
        public DataTable Data_DM_Thuoc_ForWork(CustomComboBox cbo, string valueColumn, string displayColumn,
   string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
   string maNhaCungCap, string manhomThuoc, string doiTuongDv)
        {
            return _systemConfigRepository.Data_DM_Thuoc_ForWork(cbo, valueColumn, displayColumn,
   columnsName, columnsWidth, txt, linkColumnIndex,
   maNhaCungCap, manhomThuoc, doiTuongDv);
        }
        public void Data_DM_Thuoc_ForInput(CustomComboBox cbo, string valueColumn, string displayColumn,
             string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
             string maNhaCungCap, string manhomThuoc)
        {
            _systemConfigRepository.Data_DM_Thuoc_ForInput(cbo, valueColumn, displayColumn,
              columnsName, columnsWidth, txt, linkColumnIndex,
              maNhaCungCap, manhomThuoc);
        }
        public void Get_DM_Thuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc(dtg, bv, filter, ref dt);
        }

        public void Get_DM_Thuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc(da, dtg, bv, filter,
            ref dt);
        }

        public void Get_DM_Thuoc(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc(cbo, filter, ref dt);
        }

        public void Get_DM_Thuoc(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_DM_Thuoc(cbo, filter);
        }

        public void Get_DM_Thuoc_List(ListView lst, ImageList iml, int indexNormal, string itemdId, string categoryId)
        {
            _systemConfigRepository.Get_DM_Thuoc_List(lst, iml, indexNormal, itemdId, categoryId);
        }
        public DataTable Get_DM_Thuoc_List(string itemdId, string categoryId, string _MaTiepNhan = "", string _MaDonVi = "", string _MaYeuCau = "")
        {
            return _systemConfigRepository.Get_DM_Thuoc_List(itemdId, categoryId, _MaTiepNhan, _MaDonVi, _MaYeuCau);
        }
        public void Addrange(ListViewItem it, ListViewGroup grp, DataRow item, int indexNormal)
        {
            _systemConfigRepository.Addrange(it, grp, item, indexNormal);
        }


        public bool Insert_Update_Thuoc(string maThuoc, string tenThuoc, string maVatTu,
            string maGocThuoc, string donViTinh, string cachDung, string sang, string trua,
            string chieu, string toi, string goTat, string sapXep, string gia, bool update)
        {
            return _systemConfigRepository.Insert_Update_Thuoc(maThuoc, tenThuoc, maVatTu,
                 maGocThuoc, donViTinh, cachDung, sang, trua,
                 chieu, toi, goTat, sapXep, gia, update);
        }

        public bool Delete_Thuoc(string maThuoc)
        {
            return _systemConfigRepository.Delete_Thuoc(maThuoc);
        }

        //Cách dùng
        public void Get_DM_Thuoc_CachDung(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_CachDung(dtg, bv, filter, ref dt);
        }

        public void Get_DM_Thuoc_CachDung(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_CachDung(da, dtg, bv, filter,
            ref dt);
        }

        public void Get_DM_Thuoc_CachDung(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_Thuoc_CachDung(cbo, filter, ref dt);
        }

        public void Get_DM_Thuoc_CachDung(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_DM_Thuoc_CachDung(cbo, filter);
        }

        public void Get_DM_Thuoc_CachDung(DataGridViewComboBoxColumn cbo, string filter)
        {
            _systemConfigRepository.Get_DM_Thuoc_CachDung(cbo, filter);
        }

        public DataTable Get_DM_Thuoc_CachDung()
        {
            return _systemConfigRepository.Get_DM_Thuoc_CachDung();
        }
        // BẢNG DM_Thuoc_Profile
        // Getdata 
        public void Get_DM_THUOC_PROFILE(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE(dtg, bv, filter, ref dt);
        }

        public void Get_DM_THUOC_PROFILE(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE(da, dtg, bv, filter,
            ref dt);
        }

        public void Get_DM_THUOC_PROFILE(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE(cbo, filter, ref dt);
        }

        public void Get_DM_THUOC_PROFILE(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE(cbo, filter);
        }

        // Insert 
        public bool Insert_DM_Thuoc_Profile(string maprofile, string tenprofile)
        {
            return _systemConfigRepository.Insert_DM_Thuoc_Profile(maprofile, tenprofile);
        }

        // Update 
        public bool Update_DM_THUOC_PROFILE(string maprofile, string tenprofile)
        {
            return _systemConfigRepository.Update_DM_THUOC_PROFILE(maprofile, tenprofile);
        }

        // Delete 
        public bool Delete_DM_THUOC_PROFILE(string maprofile)
        {
            return _systemConfigRepository.Delete_DM_THUOC_PROFILE(maprofile);
        }

        // BẢNG DM_Thuoc_Profile_ChiTiet
        // Getdata 
        public void Get_DM_THUOC_PROFILE_CHITIET(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE_CHITIET(dtg, bv, filter, ref dt);
        }

        public void Get_DM_THUOC_PROFILE_CHITIET(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv,
            string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE_CHITIET(da, dtg, bv,
             filter, ref dt);
        }

        public void Get_DM_THUOC_PROFILE_CHITIET(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE_CHITIET(cbo, filter, ref dt);
        }

        public void Get_DM_THUOC_PROFILE_CHITIET(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_DM_THUOC_PROFILE_CHITIET(cbo, filter);
        }

        // Insert 
        public bool Insert_DM_Thuoc_Profile_ChiTiet(string maprofile, string mathuoc)
        {
            return _systemConfigRepository.Insert_DM_Thuoc_Profile_ChiTiet(maprofile, mathuoc);
        }

        // Update 
        public bool Update_DM_THUOC_PROFILE_CHITIET(string maprofile, string mathuoc, string cachDung, string sang,
            string trua, string chieu, string toi)
        {
            return _systemConfigRepository.Update_DM_THUOC_PROFILE_CHITIET(maprofile, mathuoc, cachDung, sang,
                trua, chieu, toi);
        }

        // Delete 
        public bool Delete_DM_THUOC_PROFILE_CHITIET(string maprofile, string mathuoc)
        {
            return _systemConfigRepository.Delete_DM_THUOC_PROFILE_CHITIET(maprofile, mathuoc);
        }

        public void GET_THUOC_VA_PROFILE(CustomComboBox cbo, TextBox txt, string nhomThuoc)
        {
            _systemConfigRepository.GET_THUOC_VA_PROFILE(cbo, txt, nhomThuoc);
        }
        #endregion

        #region Danh mục khám bệnh
        public bool Insert_DM_KhamBenh_NhomDichVu(string maNhom, string tenNhom, string thuTuIn)
        {
            return _systemConfigRepository.Insert_DM_KhamBenh_NhomDichVu(maNhom, tenNhom, thuTuIn);
        }
        public void Get_DM_KhamBenh_NhomDichVu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                  ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_KhamBenh_NhomDichVu(da, dtg, bv, filter,
                  ref dt);
        }
        public DataTable Get_DM_KhamBenh_NhomDichVu(ComboBox cbo, string filter)
        {
            return _systemConfigRepository.Get_DM_KhamBenh_NhomDichVu(cbo, filter);
        }
        public DataTable Get_DM_KhamBenh_NhomDichVu(CustomComboBox cbo, string filter, TextBox txt)
        {
            return _systemConfigRepository.Get_DM_KhamBenh_NhomDichVu(cbo, filter, txt);
        }
        public bool Insert_KhamBenh_DichVu(string maNhomDichVu, string maYeuCau, string tenYeucau, string ghiChuMacDinh,
                 string deNghiMacDinh, string giaChuan)
        {
            return _systemConfigRepository.Insert_KhamBenh_DichVu(maNhomDichVu, maYeuCau, tenYeucau, ghiChuMacDinh,
                  deNghiMacDinh, giaChuan);
        }
        public void Get_DM_KhamBenh_DichVu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                    string maNhom, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_KhamBenh_DichVu(da, dtg, bv, filter,
                    maNhom, ref dt);
        }
        public void Get_DM_KhamBenh_DichVu(ComboBox cbo, string maNhom, string filter)
        {
            _systemConfigRepository.Get_DM_KhamBenh_DichVu(cbo, maNhom, filter);
        }
        public DataTable Get_DM_KhamBenh_DichVu(CustomComboBox cbo, string maNhom, string filter, TextBox txt,
                  string maDoiTuongDv)
        {
            return _systemConfigRepository.Get_DM_KhamBenh_DichVu(cbo, maNhom, filter, txt, maDoiTuongDv);
        }
        #endregion
        #region Danh mục XQuang
        public void Get_DM_XQuang_KyThuat(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_XQuang_KyThuat(dtg, bv, filter, ref dt);
        }
        public void Get_DM_XQuang_KyThuat(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                   ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_XQuang_KyThuat(da, dtg, bv, filter,
                   ref dt);
        }
        public DataTable Get_DM_XQuang_KyThuat(CustomComboBox cbo)
        {
            return _systemConfigRepository.Get_DM_XQuang_KyThuat(cbo);
        }
        public void Get_DM_XQuang_VungChup(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_XQuang_VungChup(dtg, bv, filter, ref dt);
        }
        public void Get_DM_XQuang_VungChup(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                   ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_XQuang_VungChup(da, dtg, bv, filter,
                   ref dt);
        }
        public DataTable Get_DM_XQuang_VungChup(CustomComboBox cbo, string filter, string maDoiDuongDv)
        {
            return _systemConfigRepository.Get_DM_XQuang_VungChup(cbo, filter, maDoiDuongDv);
        }
        public void Get_DM_XQuang_VungChup_ChiTiet(DataGridView dtg, BindingNavigator bv, string filter,
                    ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_XQuang_VungChup_ChiTiet(dtg, bv, filter,
                    ref dt);
        }
        public void Get_DM_XQuang_VungChup_ChiTiet(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv,
                    string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_XQuang_VungChup_ChiTiet(da, dtg, bv,
                     filter, ref dt);
        }
        public void Get_DM_XQuang_VungChup_ChiTiet(CustomComboBox cbo, string filter)
        {
            _systemConfigRepository.Get_DM_XQuang_VungChup_ChiTiet(cbo, filter);
        }
        public void Insert_KyThuat(string maKyThuat, string tenKyThuat, string thuTuIn)
        {
            _systemConfigRepository.Insert_KyThuat(maKyThuat, tenKyThuat, thuTuIn);
        }
        public void Delete_KyThuat(string maKyThuat)
        {
            _systemConfigRepository.Delete_KyThuat(maKyThuat);
        }
        public void Insert_VungChup(string maKyThuat, string maVungChup, string tenVungChup, string thuTuIn,
                   string phim, string soLuongPhim, string thuoc, string soLuongThuoc, string ketLuanMacDinh,
                   string deNghiMacDinh, string giaChuan)
        {
            _systemConfigRepository.Insert_VungChup(maKyThuat, maVungChup, tenVungChup, thuTuIn,
                    phim, soLuongPhim, thuoc, soLuongThuoc, ketLuanMacDinh,
                    deNghiMacDinh, giaChuan);
        }
        public void Update_VungChup(string maKyThuat, string maVungChup, string tenVungChup, string thuTuIn,
                    string phim, string soLuongPhim, string thuoc, string soLuongThuoc, string ketLuanMacDinh,
                    string deNghiMacDinh, string giaChuan)
        {
            _systemConfigRepository.Update_VungChup(maKyThuat, maVungChup, tenVungChup, thuTuIn,
                     phim, soLuongPhim, thuoc, soLuongThuoc, ketLuanMacDinh,
                     deNghiMacDinh, giaChuan);
        }
        public void Delete_VungChup(string maKyThuat, string maVungChup)
        {
            _systemConfigRepository.Delete_VungChup(maKyThuat, maVungChup);
        }
        public bool Update_MauKetQua(string maVungChup, string rtfMauKetQua)
        {
            return _systemConfigRepository.Update_MauKetQua(maVungChup, rtfMauKetQua);
        }
        public void Insert_MayXQuang(string tenMay)
        {
            _systemConfigRepository.Insert_MayXQuang(tenMay);
        }
        public void Get_DMMayXQuang(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                    ref DataTable dt)
        {
            _systemConfigRepository.Get_DMMayXQuang(da, dtg, bv, filter,
                    ref dt);
        }
        public void Get_DMMayXQuang(CustomComboBox cbo)
        {
            _systemConfigRepository.Get_DMMayXQuang(cbo);
        }
        #endregion
        #region Danh mục dich vụ khác
        public void Get_DM_DICHVUKHAC(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_DICHVUKHAC(dtg, bv, filter, ref dt);
        }
        public void Get_DM_DICHVUKHAC(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
       ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_DICHVUKHAC(da, dtg, bv, filter, ref dt);
        }
        public void Get_DM_DICHVUKHAC(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_DICHVUKHAC(cbo, filter, ref dt);
        }
        public DataTable Get_DM_DICHVUKHAC(CustomComboBox cbo, string filter, string maDoiTuongDv)
        {
            return _systemConfigRepository.Get_DM_DICHVUKHAC(cbo, filter, maDoiTuongDv);
        }
        public bool Insert_DM_DichVuKhac(string denghi, string ghichu, string giachuan, string madvkhac,
       string manhomcls, string mauketqua
       , string tendvkhac, string thutuin)
        {
            return _systemConfigRepository.Insert_DM_DichVuKhac(denghi, ghichu, giachuan, madvkhac,
         manhomcls, mauketqua, tendvkhac, thutuin);
        }
        public bool Update_DM_DICHVUKHAC(string denghi, string ghichu, string giachuan, string madvkhac,
       string manhomcls, string mauketqua
       , string nguoisua, string tendvkhac, string thutuin)
        {
            return _systemConfigRepository.Update_DM_DICHVUKHAC(denghi, ghichu, giachuan, madvkhac, manhomcls, mauketqua, nguoisua, tendvkhac, thutuin);
        }
        public bool Delete_DM_DICHVUKHAC(string madvkhac)
        {
            return _systemConfigRepository.Delete_DM_DICHVUKHAC(madvkhac);
        }
        public void Get_DM_NHOMCLS_DVKHAC(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_NHOMCLS_DVKHAC(dtg, bv, filter, ref dt);
        }
        public void Get_DM_NHOMCLS_DVKHAC(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
       ref DataTable dt)
        {
            _systemConfigRepository.Get_DM_NHOMCLS_DVKHAC(da, dtg, bv, filter, ref dt);
        }
        public DataTable Get_DM_NHOMCLS_DVKHAC(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            return _systemConfigRepository.Get_DM_NHOMCLS_DVKHAC(cbo, filter, ref dt);
        }
        public DataTable Get_DM_NHOMCLS_DVKHAC(CustomComboBox cbo, string filter)
        {
            return _systemConfigRepository.Get_DM_NHOMCLS_DVKHAC(cbo, filter);
        }
        public bool Insert_DM_NhomCLS_DVKhac(string manhomcls, string tennhomcls, string mauKq)
        {
            return _systemConfigRepository.Insert_DM_NhomCLS_DVKhac(manhomcls, tennhomcls, mauKq);
        }
        public DataTable Data_DS_MauKQ()
        {
            return _systemConfigRepository.Data_DS_MauKQ();
        }
        public void GET_DS_MAU_KQ(CustomComboBox cbo, TextBox txt)
        {
            _systemConfigRepository.GET_DS_MAU_KQ(cbo, txt);
        }
        public void GET_DS_MAU_KQ(DataGridViewComboBoxColumn cbo)
        {
            _systemConfigRepository.GET_DS_MAU_KQ(cbo);
        }
        #endregion
        #region dm_xetngnghiem_phuongphap
        //================================|||=====================================
        public int Insert_dm_xetngnghiem_phuongphap(DM_XETNGNGHIEM_PHUONGPHAP objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetngnghiem_phuongphap(objInfo);
        }

        public int Update_dm_xetngnghiem_phuongphap(DM_XETNGNGHIEM_PHUONGPHAP objInfo)
        {

            return _systemConfigRepository.Update_dm_xetngnghiem_phuongphap(objInfo);
        }

        public int Delete_dm_xetngnghiem_phuongphap(int autoid)
        {

            return _systemConfigRepository.Delete_dm_xetngnghiem_phuongphap(autoid);
        }

        public DataTable Data_dm_xetngnghiem_phuongphap(int? autoid, string maxn, int? idMayXn)
        {

            return _systemConfigRepository.Data_dm_xetngnghiem_phuongphap(autoid, maxn, idMayXn);
        }

        public DM_XETNGNGHIEM_PHUONGPHAP Get_Info_dm_xetngnghiem_phuongphap(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetngnghiem_phuongphap(drInfo);
        }
        public DM_XETNGNGHIEM_PHUONGPHAP Get_Info_dm_xetngnghiem_phuongphap(int autoid)
        {

            return _systemConfigRepository.Get_Info_dm_xetngnghiem_phuongphap(autoid);
        }

        public bool CheckExists_dm_xetngnghiem_phuongphap(int autoid)
        {

            return _systemConfigRepository.CheckExists_dm_xetngnghiem_phuongphap(autoid);
        }


        //================================|||=====================================
        #endregion
        #region Đối tượng dịch vụ
        public DataTable Get_NhomDoiTuongDichVu(bool checkUsing)
        {
            return _systemConfigRepository.Get_NhomDoiTuongDichVu(checkUsing);
        }
        public void Get_DoiTuongDichVu(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DoiTuongDichVu(dtg, bv, filter, ref dt);
        }
        public void Get_DoiTuongDichVu(ref SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DoiTuongDichVu(ref da, dtg, bv, filter, ref dt);
        }
        public void Get_DoiTuongDichVu(ComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DoiTuongDichVu(cbo, filter, ref dt);
        }
        public DataTable Get_DoiTuongDichVu(string filter)
        {
            return _systemConfigRepository.Get_DoiTuongDichVu(filter);
        }
        public void Get_DoiTuongDichVu(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            _systemConfigRepository.Get_DoiTuongDichVu(cbo, filter, ref dt);
        }
        public void Get_DoiTuongDichVu(CustomComboBox cbo, TextBox txt)
        {
            _systemConfigRepository.Get_DoiTuongDichVu(cbo, txt);
        }
        public string Get_Default_DoiTuongDV()
        {
            return _systemConfigRepository.Get_Default_DoiTuongDV();
        }
        public void Get_DichVu_XN(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_XN(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_SieuAm(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_SieuAm(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_XQuang(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_XQuang(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_NoiSoi(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_NoiSoi(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_KhamBenh(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_KhamBenh(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_Khac(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_Khac(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_Thuoc(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_Thuoc(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Get_DichVu_ViSinh(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            _systemConfigRepository.Get_DichVu_ViSinh(dtg, bv, maDoiTuongDichVu, maDichVu, ref dt);
        }
        public void Add_DichVu_ChiTiet_XN(string maDichVu, string maXetNghiem)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_XN(maDichVu, maXetNghiem);
        }
        public int Copy_DichVu_ChiTiet_XN(string tuMaDoiTuong, string denMaDoiTuong)
        {
            return _systemConfigRepository.Copy_DichVu_ChiTiet_XN(tuMaDoiTuong, denMaDoiTuong);
        }
        public int Copy_GiaDichVu_ChiTiet_XN(string tuMaDoiTuong, string denMaDoiTuong)
        {
            return _systemConfigRepository.Copy_GiaDichVu_ChiTiet_XN(tuMaDoiTuong, denMaDoiTuong);
        }
        public void Add_DichVu_ChiTiet_ViSinh(string maDichVu, string maXetNghiem)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_ViSinh(maDichVu, maXetNghiem);
        }
        public int Copy_DichVu_ChiTiet_ViSinh(string tuMaDoiTuong, string denMaDoiTuong)
        {
            return _systemConfigRepository.Copy_DichVu_ChiTiet_ViSinh(tuMaDoiTuong, denMaDoiTuong);
        }
        public int Copy_GiaDichVu_ChiTiet_ViSinh(string tuMaDoiTuong, string denMaDoiTuong)
        {
            return _systemConfigRepository.Copy_GiaDichVu_ChiTiet_ViSinh(tuMaDoiTuong, denMaDoiTuong);
        }
        public int Copy_DoiTuongDichVu_Gia(string tuMaDoiTuong, string denMaDoiTuong, ServiceType svrType)
        {
            return _systemConfigRepository.Copy_DoiTuongDichVu_Gia(tuMaDoiTuong, denMaDoiTuong, svrType);
        }
        public void Add_DichVu_ChiTiet_SieuAm(string maDoiTuongDichVu, string maDichVu)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_SieuAm(maDoiTuongDichVu, maDichVu);
        }
        public void Add_DichVu_ChiTiet_NoiSoi(string maDoiTuongDichVu, string maDichVu)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_NoiSoi(maDoiTuongDichVu, maDichVu);

        }
        public void Add_DichVu_ChiTiet_XQuang(string maDoiTuongDichVu, string maDichVu)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_XQuang(maDoiTuongDichVu, maDichVu);
        }
        public void Add_DichVu_ChiTiet_KhamBenh(string maDoiTuongDichVu, string maDichVu)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_KhamBenh(maDoiTuongDichVu, maDichVu);
        }
        public void Add_DichVu_ChiTiet_DVKhac(string maDoiTuongDichVu, string maDichVu)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_DVKhac(maDoiTuongDichVu, maDichVu);
        }
        public void Add_DichVu_ChiTiet_Thuoc(string maDoiTuongDichVu, string maDichVu)
        {
            _systemConfigRepository.Add_DichVu_ChiTiet_Thuoc(maDoiTuongDichVu, maDichVu);
        }
        public void Delete_DichVu(string maDichVu)
        {
            _systemConfigRepository.Delete_DichVu(maDichVu);
        }
        public void Delete_ChiTiet_XN(string maDichVu, string maXetNghiem)
        {
            _systemConfigRepository.Delete_ChiTiet_XN(maDichVu, maXetNghiem);
        }
        public void Delete_ChiTiet_SieuAm(string maDichVu, string maSoMau)
        {
            _systemConfigRepository.Delete_ChiTiet_SieuAm(maDichVu, maSoMau);
        }
        public void Delete_ChiTiet_NoiSoi(string maDichVu, string maSoMau)
        {
            _systemConfigRepository.Delete_ChiTiet_NoiSoi(maDichVu, maSoMau);
        }
        public void Delete_ChiTiet_XQuang(string maDichVu, string maVungChup)
        {
            _systemConfigRepository.Delete_ChiTiet_XQuang(maDichVu, maVungChup);
        }
        public void Delete_ChiTiet_KhamBenh(string maDichVu, string maYeuCau)
        {
            _systemConfigRepository.Delete_ChiTiet_KhamBenh(maDichVu, maYeuCau);
        }
        public void Delete_ChiTiet_DVKhac(string maDichVu, string maDvKhac)
        {
            _systemConfigRepository.Delete_ChiTiet_KhamBenh(maDichVu, maDvKhac);
        }
        public void Delete_ChiTiet_Thuoc(string maDichVu, string maThuoc)
        {
            _systemConfigRepository.Delete_ChiTiet_Thuoc(maDichVu, maThuoc);
        }
        public void Delete_ChiTiet_ViSinh(string maDichVu, string maXetNghiem)
        {
            _systemConfigRepository.Delete_ChiTiet_ViSinh(maDichVu, maXetNghiem);
        }
        public void Update_ChiTiet_XN_Gia(string maDichVu, string maXetNghiem, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_XN_Gia(maDichVu, maXetNghiem, gia);
        }
        public void Update_ChiTiet_XN_Gia(string maDichVu, string maXetNghiem, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_XN_Gia(maDichVu, maXetNghiem, phanTram);
        }
        public void Update_ChiTiet_SieuAm_Gia(string maDichVu, string maSoMau, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_SieuAm_Gia(maDichVu, maSoMau, gia);
        }
        public void Update_ChiTiet_SieuAm_Gia(string maDichVu, string maSoMau, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_SieuAm_Gia(maDichVu, maSoMau, phanTram);
        }
        public void Update_ChiTiet_NoiSoi_Gia(string maDichVu, string maSoMau, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_NoiSoi_Gia(maDichVu, maSoMau, gia);
        }
        public void Update_ChiTiet_NoiSoi_Gia(string maDichVu, string maSoMau, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_NoiSoi_Gia(maDichVu, maSoMau, phanTram);
        }
        public void Update_ChiTiet_XQuang_Gia(string maDichVu, string maVungChup, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_XQuang_Gia(maDichVu, maVungChup, gia);
        }
        public void Update_ChiTiet_XQuang_Gia(string maDichVu, string maVungChup, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_XQuang_Gia(maDichVu, maVungChup, phanTram);
        }
        public void Update_ChiTiet_KhamBenh_Gia(string maDichVu, string maYeuCau, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_KhamBenh_Gia(maDichVu, maYeuCau, gia);
        }
        public void Update_ChiTiet_KhamBenh_Gia(string maDichVu, string maYeuCau, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_KhamBenh_Gia(maDichVu, maYeuCau, phanTram);
        }
        public void Update_ChiTiet_DVKhac_Gia(string maDichVu, string maDvKhac, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_DVKhac_Gia(maDichVu, maDvKhac, gia);
        }
        public void Update_ChiTiet_DVKhac_Gia(string maDichVu, string maDvKhac, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_DVKhac_Gia(maDichVu, maDvKhac, phanTram);
        }
        public void Update_ChiTiet_Thuoc_Gia(string maDichVu, string maThuoc, string gia)
        {
            _systemConfigRepository.Update_ChiTiet_Thuoc_Gia(maDichVu, maThuoc, gia);
        }
        public void Update_ChiTiet_Thuoc_Gia(string maDichVu, string maThuoc, int phanTram)
        {
            _systemConfigRepository.Update_ChiTiet_Thuoc_Gia(maDichVu, maThuoc, phanTram);
        }

        public int Insert_dm_xetnghiem_canhbao(string maxn, string idLocaichucNang)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_canhbao(maxn, idLocaichucNang);
        }
        public int Update_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang)
        {
            return _systemConfigRepository.Update_dm_xetnghiem_canhbao(id, maxn, idLocaichucNang);
        }
        public DataTable Data_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_canhbao(id, maxn, idLocaichucNang);
        }

        #endregion
        #region Quản lý chẩn doán
        public void Add_ChanDoan(string maChanDoan, string chanDoan)
        {
            _systemConfigRepository.Add_ChanDoan(maChanDoan, chanDoan);
        }
        public void Add_ChanDoan(string maChanDoan)
        {
            _systemConfigRepository.Add_ChanDoan(maChanDoan);
        }
        public void Get_ChanDoan(ref SqlDataAdapter sqlDataAdapter, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dtData)
        {
            _systemConfigRepository.Get_ChanDoan(ref sqlDataAdapter, dtg, bv, filter, ref dtData);
        }
        public void Get_ChanDoan(CustomComboBox cbo, TextBox txtLink)
        {
            _systemConfigRepository.Get_ChanDoan(cbo, txtLink);
        }
        #endregion
        #region Quả lý mẫu để chọn
        public BaseModel Insert_dm_mauchon(DM_MAUCHON objInfo)
        {
            return _systemConfigRepository.Insert_dm_mauchon(objInfo);
        }

        public bool Update_dm_mauchon(DM_MAUCHON objInfo)
        {

            return _systemConfigRepository.Update_dm_mauchon(objInfo);
        }

        public bool Delete_dm_mauchon(DM_MAUCHON objInfo)
        {

            return _systemConfigRepository.Delete_dm_mauchon(objInfo);
        }

        public DataTable Data_dm_mauchon(string[] id)
        {

            return _systemConfigRepository.Data_dm_mauchon(id);
        }

        public DataTable Get_Data_dm_mauchon(DataGridView dtg, BindingNavigator bv, string[] id)
        {

            return _systemConfigRepository.Get_Data_dm_mauchon(dtg, bv, id);
        }

        public DataTable Get_Data_dm_mauchon(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string[] id)
        {

            return _systemConfigRepository.Get_Data_dm_mauchon(dtg, bv, ref sqlDataAdapter, ref dtData, id);
        }

        public DataTable Get_Data_dm_mauchon(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string[] id)
        {

            return _systemConfigRepository.Get_Data_dm_mauchon(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, id);
        }

        public DM_MAUCHON Get_Info_dm_mauchon(string[] id)
        {

            return _systemConfigRepository.Get_Info_dm_mauchon(id);
        }
        #endregion
        #region dm_hentraketqua
        //================================|||=====================================
        public BaseModel Insert_dm_hentraketqua(DM_HENTRAKETQUA objInfo)
        {
            return _systemConfigRepository.Insert_dm_hentraketqua(objInfo);
        }

        public bool Update_dm_hentraketqua(DM_HENTRAKETQUA objInfo)
        {

            return _systemConfigRepository.Update_dm_hentraketqua(objInfo);
        }

        public bool Delete_dm_hentraketqua(string id)
        {

            return _systemConfigRepository.Delete_dm_hentraketqua(id);
        }

        public DataTable Data_dm_hentraketqua(string id, string maloaiDichVu, string maNhom)
        {
            return _systemConfigRepository.Data_dm_hentraketqua(id, maloaiDichVu, maNhom);
        }

        public DataTable Get_Data_dm_hentraketqua(DataGridView dtg, BindingNavigator bv, string id, string maloaiDichVu, string maNhom)
        {
            return _systemConfigRepository.Get_Data_dm_hentraketqua(dtg, bv, id, maloaiDichVu, maNhom);
        }

        public DataTable Get_Data_dm_hentraketqua(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id
            , string maloaiDichVu, string maNhom)
        {
            return _systemConfigRepository.Get_Data_dm_hentraketqua(dtg, bv, ref sqlDataAdapter, ref dtData, id, maloaiDichVu, maNhom);
        }

        public DataTable Get_Data_dm_hentraketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName
            , string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string maloaiDichVu, string maNhom)
        {
            return _systemConfigRepository.Get_Data_dm_hentraketqua(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth
                , txt, LinkColumnIndex, id, maloaiDichVu, maNhom);
        }

        public DM_HENTRAKETQUA Get_Info_dm_hentraketqua(string id)
        {
            return _systemConfigRepository.Get_Info_dm_hentraketqua(id);
        }
        public bool Copy_CauHinhHenTraKQ(string loaiDanhMuc, int id, List<string> denMaXn, bool cheDoNhom)
        {
            return _systemConfigRepository.Copy_CauHinhHenTraKQ(loaiDanhMuc, id, denMaXn, cheDoNhom);
        }
        #endregion
        #region dm_ngaynghi
        //================================|||=====================================
        public BaseModel Insert_dm_ngaynghi(DM_NGAYNGHI objInfo)
        {
            return _systemConfigRepository.Insert_dm_ngaynghi(objInfo);
        }

        public bool Update_dm_ngaynghi(DM_NGAYNGHI objInfo)
        {
            return _systemConfigRepository.Update_dm_ngaynghi(objInfo);
        }

        public bool Delete_dm_ngaynghi(DM_NGAYNGHI objInfo)
        {
            return _systemConfigRepository.Delete_dm_ngaynghi(objInfo);
        }

        public DataTable Data_dm_ngaynghi_benhnhan(string matiepnhan)
        {
            return _systemConfigRepository.Data_dm_ngaynghi_benhnhan(matiepnhan);
        }
        public DataTable Data_dm_ngaynghi(string ngaynghi)
        {
            return _systemConfigRepository.Data_dm_ngaynghi(ngaynghi);
        }

        public DataTable Get_Data_dm_ngaynghi(DataGridView dtg, BindingNavigator bv, string ngaynghi)
        {
            return _systemConfigRepository.Get_Data_dm_ngaynghi(dtg, bv, ngaynghi);
        }

        public DataTable Get_Data_dm_ngaynghi(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string ngaynghi)
        {
            return _systemConfigRepository.Get_Data_dm_ngaynghi(dtg, bv, ref sqlDataAdapter, ref dtData, ngaynghi);
        }

        public DataTable Get_Data_dm_ngaynghi(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string ngaynghi)
        {
            return _systemConfigRepository.Get_Data_dm_ngaynghi(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, ngaynghi);
        }

        public DM_NGAYNGHI Get_Info_dm_ngaynghi(string ngaynghi)
        {
            return _systemConfigRepository.Get_Info_dm_ngaynghi(ngaynghi);
        }

        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bophan
        public BaseModel Insert_dm_xetnghiem_bophan(DM_XETNGHIEM_BOPHAN objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_bophan(objInfo);
        }

        public int Update_dm_xetnghiem_bophan(DM_XETNGHIEM_BOPHAN objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_bophan(objInfo);
        }

        public int Delete_dm_xetnghiem_bophan(string mabophan)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_bophan(mabophan);
        }

        public DataTable Data_dm_xetnghiem_bophan(string mabophan)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_bophan(mabophan);
        }
        public DataTable Data_dm_xetnghiem_bophan_withCategory(string maNhom)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_bophan_withCategory(maNhom);
        }

        public DM_XETNGHIEM_BOPHAN Get_Info_dm_xetnghiem_bophan(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_bophan(drInfo);
        }
        public DM_XETNGHIEM_BOPHAN Get_Info_dm_xetnghiem_bophan(string mabophan)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_bophan(mabophan);
        }
        public bool CheckExists_dm_xetnghiem_bophan(string mabophan)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_bophan(mabophan);
        }
        #endregion
        //================================|||=====================================
        #region h_mayxetnghiem_chitiet
        //================================|||=====================================
        public BaseModel Insert_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo)
        {
            return _systemConfigRepository.Insert_h_mayxetnghiem_chitiet(objInfo);
        }

        public bool Update_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo)
        {

            return _systemConfigRepository.Update_h_mayxetnghiem_chitiet(objInfo);
        }

        public bool Delete_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo)
        {

            return _systemConfigRepository.Delete_h_mayxetnghiem_chitiet(objInfo);
        }

        public DataTable Data_h_mayxetnghiem_chitiet(string idmayxn)
        {

            return _systemConfigRepository.Data_h_mayxetnghiem_chitiet(idmayxn);
        }

        public DataTable Get_Data_h_mayxetnghiem_chitiet(DataGridView dtg, BindingNavigator bv, string idmayxn)
        {

            return _systemConfigRepository.Get_Data_h_mayxetnghiem_chitiet(dtg, bv, idmayxn);
        }

        public DataTable Get_Data_h_mayxetnghiem_chitiet(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmayxn)
        {

            return _systemConfigRepository.Get_Data_h_mayxetnghiem_chitiet(dtg, bv, ref sqlDataAdapter, ref dtData, idmayxn);
        }

        public DataTable Get_Data_h_mayxetnghiem_chitiet(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmayxn)
        {

            return _systemConfigRepository.Get_Data_h_mayxetnghiem_chitiet(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idmayxn);
        }

        public H_MAYXETNGHIEM_CHITIET Get_Info_h_mayxetnghiem_chitiet(string idmayxn)
        {

            return _systemConfigRepository.Get_Info_h_mayxetnghiem_chitiet(idmayxn);
        }
        public DataTable Data_h_mayxetnghiem_chitiet_theo_phanloai(int idphanloai)
        {
            return _systemConfigRepository.Data_h_mayxetnghiem_chitiet_theo_phanloai(idphanloai);
        }
        public void Data_h_mayxetnghiem_chitiet_theo_phanloai(ComboBox cbo, int idphanloai)
        {
            cbo.DataSource = _systemConfigRepository.Data_h_mayxetnghiem_chitiet_theo_phanloai(idphanloai);
            cbo.ValueMember = "idmayxn";
            cbo.DisplayMember = "tenhienthi";
            cbo.SelectedIndex = -1;
        }
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bo
        public int Insert_dm_xetnghiem_bo(DM_XETNGHIEM_BO objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_bo(objInfo);
        }

        public int Update_dm_xetnghiem_bo(DM_XETNGHIEM_BO objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_bo(objInfo);
        }

        public int Delete_dm_xetnghiem_bo(string maboxetnghiem)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_bo(maboxetnghiem);
        }

        public DataTable Data_dm_xetnghiem_bo(string maboxetnghiem)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_bo(maboxetnghiem);
        }

        public DM_XETNGHIEM_BO Get_Info_dm_xetnghiem_bo(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_bo(drInfo);
        }

        public DM_XETNGHIEM_BO Get_Info_dm_xetnghiem_bo(string maboxetnghiem)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_bo(maboxetnghiem);
        }

        public bool CheckExists_dm_xetnghiem_bo(string maboxetnghiem)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_bo(maboxetnghiem);
        }

        #endregion
        #region dm_xetnghiem_bo_chitiet
        public int Insert_dm_xetnghiem_bo_chitiet(DM_XETNGHIEM_BO_CHITIET objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_bo_chitiet(objInfo);
        }



        public int Delete_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_bo_chitiet(maboxetnghiem, machidinh, xnprofile);
        }

        public DataTable Data_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_bo_chitiet(maboxetnghiem, machidinh, xnprofile);
        }

        public DM_XETNGHIEM_BO_CHITIET Get_Info_dm_xetnghiem_bo_chitiet(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_bo_chitiet(drInfo);
        }
        public DM_XETNGHIEM_BO_CHITIET Get_Info_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_bo_chitiet(maboxetnghiem, machidinh, xnprofile);
        }

        public bool CheckExists_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_bo_chitiet(maboxetnghiem, machidinh, xnprofile);
        }

        #endregion
        #region Loại mẫu
        public int Insert_dm_xetnghiem_loaimau(DM_XETNGHIEM_LOAIMAU objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_loaimau(objInfo);
        }

        public int Update_dm_xetnghiem_loaimau(DM_XETNGHIEM_LOAIMAU objInfo)
        {
            return _systemConfigRepository.Update_dm_xetnghiem_loaimau(objInfo);
        }

        public int Delete_dm_xetnghiem_loaimau(string maloaimau)
        {
            return _systemConfigRepository.Delete_dm_xetnghiem_loaimau(maloaimau);
        }

        public DataTable Data_dm_xetnghiem_loaimau(string maloaimau, string LoaiDvCLS)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_loaimau(maloaimau, LoaiDvCLS);
        }

        public DM_XETNGHIEM_LOAIMAU Get_Info_dm_xetnghiem_loaimau(DataRow drInfo)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem_loaimau(drInfo);
        }
        public DM_XETNGHIEM_LOAIMAU Get_Info_dm_xetnghiem_loaimau(string maloaimau)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem_loaimau(maloaimau);
        }

        public bool CheckExists_dm_xetnghiem_loaimau(string maloaimau)
        {
            return _systemConfigRepository.CheckExists_dm_xetnghiem_loaimau(maloaimau);
        }
        public string MauOngMauTheoLoaiMau(string maloaimau)
        {
            return _systemConfigRepository.MauOngMauTheoLoaiMau(maloaimau);
        }
        public DataTable Data_LoaiMau_GetDM(string maloaimau, bool hienthinhan, string[] phanLoaiMau)
        {
            return _systemConfigRepository.Data_LoaiMau_GetDM(maloaimau, hienthinhan, phanLoaiMau);
        }
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_loaimauchinh
        public BaseModel Insert_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_loaimauchinh(objInfo);
        }

        public bool Update_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_loaimauchinh(objInfo);
        }

        public bool Delete_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_loaimauchinh(objInfo);
        }

        public DataTable Data_dm_xetnghiem_loaimauchinh(string maloaimauchinh)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_loaimauchinh(maloaimauchinh);
        }

        public DataTable Get_Data_dm_xetnghiem_loaimauchinh(DataGridView dtg, BindingNavigator bv, string maloaimauchinh)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_loaimauchinh(dtg, bv, maloaimauchinh);
        }

        public DataTable Get_Data_dm_xetnghiem_loaimauchinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maloaimauchinh)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_loaimauchinh(dtg, bv, ref sqlDataAdapter, ref dtData, maloaimauchinh);
        }

        public DataTable Get_Data_dm_xetnghiem_loaimauchinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maloaimauchinh)
        {

            return _systemConfigRepository.Get_Data_dm_xetnghiem_loaimauchinh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, maloaimauchinh);
        }

        public DM_XETNGHIEM_LOAIMAUCHINH Get_Info_dm_xetnghiem_loaimauchinh(string maloaimauchinh)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_loaimauchinh(maloaimauchinh);
        }
        #endregion
        //================================|||=====================================
        #region Loại mẫu nhận
        public BaseModel Insert_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_loaimau_nhom(objInfo);
        }

        public bool Update_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo)
        {
            return _systemConfigRepository.Update_dm_xetnghiem_loaimau_nhom(objInfo);
        }

        public bool Delete_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo)
        {
            return _systemConfigRepository.Delete_dm_xetnghiem_loaimau_nhom(objInfo);
        }

        public DataTable Data_dm_xetnghiem_loaimau_nhom(string manhomloaimau, bool hienthinhan, string phanLoaiMau)
        {
            return _systemConfigRepository.Data_dm_xetnghiem_loaimau_nhom(manhomloaimau, hienthinhan, phanLoaiMau);
        }

        public DataTable Get_Data_dm_xetnghiem_loaimau_nhom(DataGridView dtg, BindingNavigator bv, string manhomloaimau)
        {
            return _systemConfigRepository.Get_Data_dm_xetnghiem_loaimau_nhom(dtg, bv, manhomloaimau);
        }

        public DataTable Get_Data_dm_xetnghiem_loaimau_nhom(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manhomloaimau)
        {
            return _systemConfigRepository.Get_Data_dm_xetnghiem_loaimau_nhom(dtg, bv, ref sqlDataAdapter, ref dtData, manhomloaimau);
        }

        public DataTable Get_Data_dm_xetnghiem_loaimau_nhom(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manhomloaimau)
        {
            return _systemConfigRepository.Get_Data_dm_xetnghiem_loaimau_nhom(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, manhomloaimau);
        }

        public DM_XETNGHIEM_LOAIMAU_NHOM Get_Info_dm_xetnghiem_loaimau_nhom(string manhomloaimau)
        {
            return _systemConfigRepository.Get_Info_dm_xetnghiem_loaimau_nhom(manhomloaimau);
        }

        #endregion
        //================================|||=====================================
        #region dm_khulaymau
        public BaseModel Insert_dm_khulaymau(DM_KHULAYMAU objInfo)
        {
            return _systemConfigRepository.Insert_dm_khulaymau(objInfo);
        }

        public bool Update_dm_khulaymau(DM_KHULAYMAU objInfo)
        {

            return _systemConfigRepository.Update_dm_khulaymau(objInfo);
        }

        public bool Delete_dm_khulaymau(DM_KHULAYMAU objInfo)
        {

            return _systemConfigRepository.Delete_dm_khulaymau(objInfo);
        }

        public DataTable Data_dm_khulaymau(string idkhulaymau, string makhuvuc)
        {

            return _systemConfigRepository.Data_dm_khulaymau(idkhulaymau, makhuvuc);
        }

        public DataTable Get_Data_dm_khulaymau(DataGridView dtg, BindingNavigator bv, string idkhulaymau, string makhuvuc)
        {

            return _systemConfigRepository.Get_Data_dm_khulaymau(dtg, bv, idkhulaymau, makhuvuc);
        }

        public DataTable Get_Data_dm_khulaymau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idkhulaymau, string makhuvuc)
        {

            return _systemConfigRepository.Get_Data_dm_khulaymau(dtg, bv, ref sqlDataAdapter, ref dtData, idkhulaymau, makhuvuc);
        }

        public DataTable Get_Data_dm_khulaymau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idkhulaymau, string makhuvuc)
        {

            return _systemConfigRepository.Get_Data_dm_khulaymau(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idkhulaymau, makhuvuc);
        }

        public DM_KHULAYMAU Get_Info_dm_khulaymau(string idkhulaymau)
        {

            return _systemConfigRepository.Get_Info_dm_khulaymau(idkhulaymau);
        }
        public DM_KHULAYMAU Get_Info_dm_khulaymau_Theomaytinh(string pcName)
        {
            return _systemConfigRepository.Get_Info_dm_khulaymau_Theomaytinh(pcName);
        }
        #endregion
        //================================|||=====================================
        #region Tình trạng mẫu
        public DataTable Data_DanhMucTinhTrangMau(int LoaiXetNghiem)
        {
            return _systemConfigRepository.Data_DanhMucTinhTrangMau(LoaiXetNghiem);
        }
        public BaseModel Insert_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo)
        {
            return _systemConfigRepository.Insert_dm_tinhtrangmau(objInfo);
        }

        public bool Update_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo)
        {

            return _systemConfigRepository.Update_dm_tinhtrangmau(objInfo);
        }

        public bool Delete_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo)
        {

            return _systemConfigRepository.Delete_dm_tinhtrangmau(objInfo);
        }

        public DataTable Data_dm_tinhtrangmau(string id)
        {

            return _systemConfigRepository.Data_dm_tinhtrangmau(id);
        }

        public DataTable Get_Data_dm_tinhtrangmau(DataGridView dtg, BindingNavigator bv, string id)
        {

            return _systemConfigRepository.Get_Data_dm_tinhtrangmau(dtg, bv, id);
        }

        public DataTable Get_Data_dm_tinhtrangmau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id)
        {

            return _systemConfigRepository.Get_Data_dm_tinhtrangmau(dtg, bv, ref sqlDataAdapter, ref dtData, id);
        }

        public DataTable Get_Data_dm_tinhtrangmau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id)
        {

            return _systemConfigRepository.Get_Data_dm_tinhtrangmau(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, id);
        }

        public DM_TINHTRANGMAU Get_Info_dm_tinhtrangmau(string id)
        {

            return _systemConfigRepository.Get_Info_dm_tinhtrangmau(id);
        }

        #endregion
        //================================|||=====================================
        #region dm_email
        public BaseModel Insert_dm_email(DM_EMAIL objInfo)
        {
            return _systemConfigRepository.Insert_dm_email(objInfo);
        }

        public bool Update_dm_email(DM_EMAIL objInfo)
        {
            return _systemConfigRepository.Update_dm_email(objInfo);
        }

        public bool Delete_dm_email(DM_EMAIL objInfo)
        {
            return _systemConfigRepository.Delete_dm_email(objInfo);
        }

        public DataTable Data_dm_email(string email)
        {
            return _systemConfigRepository.Data_dm_email(email);
        }

        public DataTable Get_Data_dm_email(DataGridView dtg, BindingNavigator bv, string email)
        {
            return _systemConfigRepository.Get_Data_dm_email(dtg, bv, email);
        }

        public DataTable Get_Data_dm_email(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string email)
        {
            return _systemConfigRepository.Get_Data_dm_email(dtg, bv, ref sqlDataAdapter, ref dtData, email);
        }

        public DataTable Get_Data_dm_email(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string email)
        {
            return _systemConfigRepository.Get_Data_dm_email(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, email);
        }

        public DM_EMAIL Get_Info_dm_email(string email)
        {
            return _systemConfigRepository.Get_Info_dm_email(email);
        }
        #endregion
        //================================|||=====================================
        #region Tieu de trang in
        public void Get_Header_Config(SqlDataAdapter da, DataGridView dtg,
            BindingNavigator bv, string headerId,
            ref DataTable dt)
        {
            _systemConfigRepository.Get_Header_Config(da, dtg, bv, headerId, ref dt);
        }
        public DataTable Get_Header_Config(string headerId)
        {
            return _systemConfigRepository.Get_Header_Config(headerId);
        }
        public Image Load_Logo(string maDonVi)
        {
            return _systemConfigRepository.Load_Logo(maDonVi);
        }
        #endregion

        #region LICENSE
        public LicenseModel ValidLicense(string computerName, string applicationName, string serial)
        {
            var langMessageConstant = new MessageConstant();
            var licenseFlagDescription = langMessageConstant.LicenseOnClient;
            var licenseInfo = new LicenseModel
            {
                FullLicense = false,
                HasLicense = false,
                Serial = serial
            };

            var license = _systemConfigRepository.GetApplicationLicense(computerName, applicationName, serial);

            if (license == null || license.Tables.Count < 2)
            {
                licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, MessageConstant.LicenseUnRegister);
                licenseInfo.StatusFullDescription = langMessageConstant.PhanMemChuaDangKyNgaySuDung;
                return licenseInfo;
            }

            if (license.Tables[1].Rows.Count > 0)
            {
                licenseInfo.CheckLicenseOnServer =
                    NumberConverter.To<bool>(license.Tables[1].Rows[0]["IsCheckLicenseOnServer"]);
                licenseInfo.PcName =
                    StringConverter.ToString(license.Tables[1].Rows[0]["PcAuthenName"]);

                if (licenseInfo.CheckLicenseOnServer)
                {
                    licenseFlagDescription = langMessageConstant.LicenseOnServer;

                    if (license.Tables[0].Rows.Count > 0)
                    {
                        serial = StringConverter.ToString(license.Tables[0].Rows[0]["serialnumber"]);
                    }
                }
            }

            if (license.Tables[0].Rows.Count == 0)
            {
                licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, MessageConstant.LicenseUnRegister);
                licenseInfo.StatusFullDescription = langMessageConstant.PhanMemChuaDangKyNgaySuDung;
                return licenseInfo;
            }

            var keyNumber = StringConverter.ToString(license.Tables[0].Rows[0]["keynumber"]);
            var licenseDescrypted = EnDeCrypt.DecryptString(keyNumber);
            var licenseValues = licenseDescrypted.Split('_');

            if (licenseValues == null || licenseValues.Length < 5)
            {
                licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, MessageConstant.LicenseUnRegister);
                licenseInfo.StatusFullDescription = langMessageConstant.PhanMemChuaDangKyNgaySuDung;
                return licenseInfo;
            }
            else
            {
                var arrApp = applicationName.Split('.');
                var productKeyIsValid = TPHSerialKeys.CheckProtocolLicense(serial, string.Format("{0}.{1}", arrApp[0], arrApp[1]), keyNumber);
                if (productKeyIsValid)
                {
                    licenseInfo.Serial = serial;
                    var isTrial = NumberConverter.ToInt(licenseValues[2]);
                    if (isTrial == 0)
                    {
                        licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, MessageConstant.LicenseFull);
                        licenseInfo.StatusFullDescription = langMessageConstant.PhienBanDayDuKhongGioiHan;
                        licenseInfo.FullLicense = true;
                        licenseInfo.HasLicense = true;
                    }
                    else
                    {
                        var startDate = DateTimeConverter.ToDateTime(licenseValues[3]);
                        var endDate = DateTimeConverter.ToDateTime(licenseValues[4]);

                        var currentDate = DateTime.Now.Date;
                        var difference = endDate - currentDate;

                        licenseInfo.StartDate = startDate;
                        licenseInfo.EndDate = endDate;
                        licenseInfo.HasLicense = difference.Days > 0;

                        if (difference.Days <= 0)
                        {
                            licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, MessageConstant.LicenseExpired);
                            licenseInfo.StatusFullDescription = string.Format(langMessageConstant.PhanMemDaHetHanSuDungTuNgay, endDate);
                        }
                        else
                        {
                            licenseInfo.StatusShortDescription = string.Format(langMessageConstant.LicenseTrial, difference.Days);
                            licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, licenseInfo.StatusShortDescription);
                            licenseInfo.StatusFullDescription = string.Format(langMessageConstant.PhienBanDungThuDenHetNgay, endDate);
                        }
                    }
                }
                else
                {
                    var startDate = DateTimeConverter.ToDateTime(licenseValues[3]);
                    var endDate = DateTimeConverter.ToDateTime(licenseValues[4]);

                    var currentDate = DateTime.Now.Date;
                    var difference = endDate - currentDate;

                    if (difference.Days <= 0)
                    {
                        licenseInfo.StatusShortDescription = string.Format("{0}\n{1}", licenseFlagDescription, MessageConstant.LicenseExpired);
                        licenseInfo.StatusFullDescription = string.Format(langMessageConstant.PhanMemDaHetHanSuDungTuNgay, endDate);
                    }
                }
            }

            return licenseInfo;
        }

        public BaseModel ValidSerial(string computerName, string applicationId, string applicationName, string serial)
        {
            //var log = "get computerName";
            //log += string.Format(" computerName = {0}", computerName);
            //log += "get applicationID";
            //log += string.Format(" applicationID = {0}", applicationId);
            //log += "get applicationName";
            //log += string.Format(" applicationName = {0}", applicationName);

            //var serial = TPHSerialKeys.GetSerial();
            var license = _systemConfigRepository.GetApplicationLicense(computerName, applicationName, serial);
            var pcName = string.Empty;
            var result = new BaseModel();
            if (license == null)
                return null;
            else if (license.Tables.Count == 0)
                return null;
            if (license != null &&
                license.Tables.Count > 0 &&
                license.Tables[0] != null &&
                license.Tables[0].Rows.Count > 0)
            {
                result.Id = ErrorConstant.ErrorCode0;
                //var keyNumber = StringConverter.ToString(license.Rows[0]["keynumber"]);
                //if (!string.IsNullOrWhiteSpace(keyNumber) && TPHSerialKeys.CheckSerial(keyNumber))
                //{
                //   return true;
                //}
            }
            else
            {
                result.Id = ErrorConstant.ErrorCode1;
            }

            if (license != null &&
                license.Tables.Count > 0 &&
                license.Tables[1] != null &&
                license.Tables[1].Rows.Count > 0)
            {
                result.Name = StringConverter.ToString(license.Tables[1].Rows[0]["PcAuthenName"]);
            }

            return result;
        }

        public bool InsertSerialKey(string computerName, string applicationName, string serialNumber)
        {
            return _systemConfigRepository.InsertSerialKey(computerName, applicationName, serialNumber);
        }

        public bool UpdateSerialKey(string computerName, string applicationName, string serialNumber, string keyNumber)
        {
            return _systemConfigRepository.UpdateSerialKey(computerName, applicationName, serialNumber, keyNumber);
        }
        #endregion LICENSE

        #region Cấu hình máy in barcode
        public int Insert_CauHinhMayInbarcode(DM_MAYTINH_MAYIN obj)
        {
            return _systemConfigRepository.Insert_CauHinhMayInbarcode(obj);
        }
        public int Update_CauHinhMayInbarcode(DM_MAYTINH_MAYIN obj)
        {
            return _systemConfigRepository.Update_CauHinhMayInbarcode(obj);
        }
        public int Delete_CauHinhMayInBarcode(DM_MAYTINH_MAYIN obj)
        {
            return _systemConfigRepository.Delete_CauHinhMayInBarcode(obj);
        }
        public DataTable Data_DanhSach_CauHinhMayInbarcode(string tenMayTinh, int idMay, int suDung)
        {
            return _systemConfigRepository.Data_DanhSach_CauHinhMayInbarcode(tenMayTinh, idMay, suDung);
        }
        public DM_MAYTINH_MAYIN Get_info_CauHinh_MaInbarcode(string tenMayTinh, int idMay, int suDung)
        {
            return _systemConfigRepository.Get_info_CauHinh_MaInbarcode(tenMayTinh, idMay, suDung);
        }
        public DM_MAYTINH_MAYIN Get_info_CauHinh_MaInbarcode(DataRow dr)
        {
            return _systemConfigRepository.Get_info_CauHinh_MaInbarcode(dr);
        }
        #endregion
        #region Máy tính
        public BaseModel Insert_dm_maytinh(DM_MAYTINH objInfo)
        {
            return _systemConfigRepository.Insert_dm_maytinh(objInfo);
        }

        public bool Update_dm_maytinh(DM_MAYTINH objInfo)
        {
            return _systemConfigRepository.Update_dm_maytinh(objInfo);
        }

        public bool Delete_dm_maytinh(DM_MAYTINH objInfo)
        {
            return _systemConfigRepository.Delete_dm_maytinh(objInfo);
        }

        public DataTable Data_dm_maytinh(string tenmaytinh, string khulamviec)
        {
            return _systemConfigRepository.Data_dm_maytinh(tenmaytinh, khulamviec);
        }

        public DataTable Get_Data_dm_maytinh(DataGridView dtg, BindingNavigator bv, string tenmaytinh, string khulamviec)
        {
            return _systemConfigRepository.Get_Data_dm_maytinh(dtg, bv, tenmaytinh, khulamviec);
        }

        public DataTable Get_Data_dm_maytinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string tenmaytinh, string khulamviec)
        {
            return _systemConfigRepository.Get_Data_dm_maytinh(dtg, bv, ref sqlDataAdapter, ref dtData, tenmaytinh, khulamviec);
        }

        public DataTable Get_Data_dm_maytinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string tenmaytinh, string khulamviec)
        {
            return _systemConfigRepository.Get_Data_dm_maytinh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, tenmaytinh, khulamviec);
        }

        public DM_MAYTINH Get_Info_dm_maytinh(string tenmaytinh)
        {
            return _systemConfigRepository.Get_Info_dm_maytinh(tenmaytinh);
        }

        #endregion
        #region Ghi chú tự động
        public int Insert_dm_xetnghiem_ghichutudong(DM_XETNGHIEM_GHICHUTUDONG objInfo)
        {
            return _systemConfigRepository.Insert_dm_xetnghiem_ghichutudong(objInfo);
        }

        public int Update_dm_xetnghiem_ghichutudong(DM_XETNGHIEM_GHICHUTUDONG objInfo)
        {

            return _systemConfigRepository.Update_dm_xetnghiem_ghichutudong(objInfo);
        }

        public int Delete_dm_xetnghiem_ghichutudong(int id)
        {

            return _systemConfigRepository.Delete_dm_xetnghiem_ghichutudong(id);
        }

        public DataTable Data_dm_xetnghiem_ghichutudong(int? id, string maXn)
        {

            return _systemConfigRepository.Data_dm_xetnghiem_ghichutudong(id, maXn);
        }

        public DM_XETNGHIEM_GHICHUTUDONG Get_Info_dm_xetnghiem_ghichutudong(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_ghichutudong(drInfo);
        }

        public DM_XETNGHIEM_GHICHUTUDONG Get_Info_dm_xetnghiem_ghichutudong(int id)
        {

            return _systemConfigRepository.Get_Info_dm_xetnghiem_ghichutudong(id);
        }

        public bool CheckExists_dm_xetnghiem_ghichutudong(int id)
        {

            return _systemConfigRepository.CheckExists_dm_xetnghiem_ghichutudong(id);
        }

        #endregion
        #region Cấu hình hiển thị
        public List<HienThiModel> lstThongTinHienThi(string idLoaihienThi)
        {
            return _systemConfigRepository.lstThongTinHienThi(idLoaihienThi);
        }
        public HienThiModel InfoThongTinHienthi(string idLoaiHienthi, string idHienThi)
        {
            return _systemConfigRepository.InfoThongTinHienthi(idLoaiHienthi, idHienThi);
        }
        public HienThiModel InfoThongTinHienThiTuDataRow(DataRow dr)
        {
            return _systemConfigRepository.InfoThongTinHienThiTuDataRow(dr);
        }
        public DataTable DataThongTinHienThi(string idLoaiHienthi, string idHienThi)
        {
            return _systemConfigRepository.DataThongTinHienThi(idLoaiHienthi, idHienThi);
        }
        public int InsertThongTinHienThi(HienThiModel hienThiModel)
        {
            return _systemConfigRepository.InsertThongTinHienThi(hienThiModel);
        }
        public int UpdateThongTinHienThi(HienThiModel hienThiModel)
        {
            return _systemConfigRepository.UpdateThongTinHienThi(hienThiModel);
        }
        public int DeleteThongTinHienThi(string idLoaiHienthi, string idHienThi)
        {
            return _systemConfigRepository.DeleteThongTinHienThi(idLoaiHienthi, idHienThi);
        }
        #endregion
        #region dm_nhomphong
        public BaseModel Insert_dm_nhomphong(DM_NHOMPHONG objInfo)
        {
            return _systemConfigRepository.Insert_dm_nhomphong(objInfo);
        }

        public bool Update_dm_nhomphong(DM_NHOMPHONG objInfo)
        {
            return _systemConfigRepository.Update_dm_nhomphong(objInfo);
        }

        public bool Delete_dm_nhomphong(DM_NHOMPHONG objInfo)
        {
            return _systemConfigRepository.Delete_dm_nhomphong(objInfo);
        }

        public DataTable Data_dm_nhomphong(string manhomphong)
        {
            return _systemConfigRepository.Data_dm_nhomphong(manhomphong);
        }

        public DataTable Get_Data_dm_nhomphong(DataGridView dtg, BindingNavigator bv, string manhomphong)
        {
            return _systemConfigRepository.Get_Data_dm_nhomphong(dtg, bv, manhomphong);
        }

        public DataTable Get_Data_dm_nhomphong(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manhomphong)
        {
            return _systemConfigRepository.Get_Data_dm_nhomphong(dtg, bv, ref sqlDataAdapter, ref dtData, manhomphong);
        }

        public DataTable Get_Data_dm_nhomphong(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manhomphong)
        {
            return _systemConfigRepository.Get_Data_dm_nhomphong(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, manhomphong);
        }

        public DM_NHOMPHONG Get_Info_dm_nhomphong(string manhomphong)
        {
            return _systemConfigRepository.Get_Info_dm_nhomphong(manhomphong);
        }
        #endregion
        #region dm_phong
        public BaseModel Insert_dm_phong(DM_PHONG objInfo)
        {
            return _systemConfigRepository.Insert_dm_phong(objInfo);
        }

        public bool Update_dm_phong(DM_PHONG objInfo)
        {

            return _systemConfigRepository.Update_dm_phong(objInfo);
        }

        public bool Delete_dm_phong(DM_PHONG objInfo)
        {

            return _systemConfigRepository.Delete_dm_phong(objInfo);
        }

        public DataTable Data_dm_phong(string maphong, string makhoaphong, string manhomphong)
        {

            return _systemConfigRepository.Data_dm_phong(maphong, makhoaphong, manhomphong);
        }

        public DataTable Get_Data_dm_phong(DataGridView dtg, BindingNavigator bv, string maphong, string makhoaphong, string manhomphong)
        {

            return _systemConfigRepository.Get_Data_dm_phong(dtg, bv, maphong, makhoaphong, manhomphong);
        }

        public DataTable Get_Data_dm_phong(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maphong, string makhoaphong, string manhomphong)
        {

            return _systemConfigRepository.Get_Data_dm_phong(dtg, bv, ref sqlDataAdapter, ref dtData, maphong, makhoaphong, manhomphong);
        }

        public DataTable Get_Data_dm_phong(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maphong, string makhoaphong, string manhomphong)
        {

            return _systemConfigRepository.Get_Data_dm_phong(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, maphong, makhoaphong, manhomphong);
        }

        public DM_PHONG Get_Info_dm_phong(string maphong, string makhoaphong, string manhomphong)
        {

            return _systemConfigRepository.Get_Info_dm_phong(maphong, makhoaphong, manhomphong);
        }

        #endregion
        #region config
        public BaseModel Insert_config(CONFIG objInfo)
        {
            return _systemConfigRepository.Insert_config(objInfo);
        }

        public bool Update_config(CONFIG objInfo)
        {

            return _systemConfigRepository.Update_config(objInfo);
        }

        public bool Delete_config(CONFIG objInfo)
        {

            return _systemConfigRepository.Delete_config(objInfo);
        }

        public DataTable Data_config(string id, string idConfig)
        {

            return _systemConfigRepository.Data_config(id, idConfig);
        }

        public DataTable Get_Data_config(DataGridView dtg, BindingNavigator bv, string id, string idConfig)
        {

            return _systemConfigRepository.Get_Data_config(dtg, bv, id, idConfig);
        }

        public DataTable Get_Data_config(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id, string idConfig)
        {

            return _systemConfigRepository.Get_Data_config(dtg, bv, ref sqlDataAdapter, ref dtData, id, idConfig);
        }

        public DataTable Get_Data_config(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string idConfig)
        {

            return _systemConfigRepository.Get_Data_config(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, id, idConfig);
        }

        public CONFIG Get_Info_config(string id)
        {

            return _systemConfigRepository.Get_Info_config(id);
        }

        #endregion
        #region dm_loaiimport
        public BaseModel Insert_dm_loaiimport(DM_LOAIIMPORT objInfo)
        {
            return _systemConfigRepository.Insert_dm_loaiimport(objInfo);
        }

        public bool Update_dm_loaiimport(DM_LOAIIMPORT objInfo)
        {
            return _systemConfigRepository.Update_dm_loaiimport(objInfo);
        }

        public bool Delete_dm_loaiimport(DM_LOAIIMPORT objInfo)
        {
            return _systemConfigRepository.Delete_dm_loaiimport(objInfo);
        }

        public DataTable Data_dm_loaiimport(string maimport)
        {
            return _systemConfigRepository.Data_dm_loaiimport(maimport);
        }

        public DataTable Get_Data_dm_loaiimport(DataGridView dtg, BindingNavigator bv, string maimport)
        {
            return _systemConfigRepository.Get_Data_dm_loaiimport(dtg, bv, maimport);
        }

        public DataTable Get_Data_dm_loaiimport(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maimport)
        {
            return _systemConfigRepository.Get_Data_dm_loaiimport(dtg, bv, ref sqlDataAdapter, ref dtData, maimport);
        }

        public DataTable Get_Data_dm_loaiimport(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maimport)
        {
            return _systemConfigRepository.Get_Data_dm_loaiimport(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, maimport);
        }

        public DM_LOAIIMPORT Get_Info_dm_loaiimport(string maimport)
        {
            return _systemConfigRepository.Get_Info_dm_loaiimport(maimport);
        }
        public BaseModel Insert_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo)
        {
            return _systemConfigRepository.Insert_dm_loaiimport_mapping(objInfo);
        }

        public bool Update_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo)
        {

            return _systemConfigRepository.Update_dm_loaiimport_mapping(objInfo);
        }

        public bool Delete_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo)
        {

            return _systemConfigRepository.Delete_dm_loaiimport_mapping(objInfo);
        }

        public DataTable Data_dm_loaiimport_mapping(string maimport, string liscolumn)
        {

            return _systemConfigRepository.Data_dm_loaiimport_mapping(maimport, liscolumn);
        }

        public DataTable Get_Data_dm_loaiimport_mapping(DataGridView dtg, BindingNavigator bv, string maimport, string liscolumn)
        {

            return _systemConfigRepository.Get_Data_dm_loaiimport_mapping(dtg, bv, maimport, liscolumn);
        }

        public DataTable Get_Data_dm_loaiimport_mapping(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maimport, string liscolumn)
        {

            return _systemConfigRepository.Get_Data_dm_loaiimport_mapping(dtg, bv, ref sqlDataAdapter, ref dtData, maimport, liscolumn);
        }

        public DataTable Get_Data_dm_loaiimport_mapping(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maimport, string liscolumn)
        {

            return _systemConfigRepository.Get_Data_dm_loaiimport_mapping(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, maimport, liscolumn);
        }

        public DM_LOAIIMPORT_MAPPING Get_Info_dm_loaiimport_mapping(string maimport, string liscolumn)
        {

            return _systemConfigRepository.Get_Info_dm_loaiimport_mapping(maimport, liscolumn);
        }
        public List<DM_LOAIIMPORT_MAPPING> Get_ListInfo_dm_loaiimport_mapping(string maimport)
        {
            return _systemConfigRepository.Get_ListInfo_dm_loaiimport_mapping(maimport);
        }
        #endregion
        #region dm_doituongbenhnhan
        public int Insert_dm_doituongbenhnhan(DM_DOITUONGBENHNHAN objInfo)
        {
            return _systemConfigRepository.Insert_dm_doituongbenhnhan(objInfo);
        }

        public int Update_dm_doituongbenhnhan(DM_DOITUONGBENHNHAN objInfo)
        {

            return _systemConfigRepository.Update_dm_doituongbenhnhan(objInfo);
        }

        public int Delete_dm_doituongbenhnhan(string madoituongbn)
        {

            return _systemConfigRepository.Delete_dm_doituongbenhnhan(madoituongbn);
        }

        public DataTable Data_dm_doituongbenhnhan(string madoituongbn)
        {

            return _systemConfigRepository.Data_dm_doituongbenhnhan(madoituongbn);
        }

        public DM_DOITUONGBENHNHAN Get_Info_dm_doituongbenhnhan(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_doituongbenhnhan(drInfo);
        }
        public DM_DOITUONGBENHNHAN Get_Info_dm_doituongbenhnhan(string madoituongbn)
        {
            return _systemConfigRepository.Get_Info_dm_doituongbenhnhan(madoituongbn);
        }
        public bool CheckExists_dm_doituongbenhnhan(string madoituongbn)
        {
            return _systemConfigRepository.CheckExists_dm_doituongbenhnhan(madoituongbn);
        }

        #endregion
        #region Ngôn ngữ
        public BaseModel Insert_dm_ngonngu(DM_NGONNGU objInfo)
        {
            return _systemConfigRepository.Insert_dm_ngonngu(objInfo);
        }

        public bool Update_dm_ngonngu(DM_NGONNGU objInfo)
        {
            return _systemConfigRepository.Update_dm_ngonngu(objInfo);
        }

        public bool Delete_dm_ngonngu(DM_NGONNGU objInfo)
        {
            return _systemConfigRepository.Delete_dm_ngonngu(objInfo);
        }

        public DataTable Data_dm_ngonngu(string idngonngu)
        {
            return _systemConfigRepository.Data_dm_ngonngu(idngonngu);
        }

        public DataTable Get_Data_dm_ngonngu(DataGridView dtg, BindingNavigator bv, string idngonngu)
        {
            return _systemConfigRepository.Get_Data_dm_ngonngu(dtg, bv, idngonngu);
        }

        public DataTable Get_Data_dm_ngonngu(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idngonngu)
        {
            return _systemConfigRepository.Get_Data_dm_ngonngu(dtg, bv, ref sqlDataAdapter, ref dtData, idngonngu);
        }

        public DataTable Get_Data_dm_ngonngu(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idngonngu)
        {

            return _systemConfigRepository.Get_Data_dm_ngonngu(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idngonngu);
        }

        public DM_NGONNGU Get_Info_dm_ngonngu(string idngonngu)
        {
            return _systemConfigRepository.Get_Info_dm_ngonngu(idngonngu);
        }

        public BaseModel Insert_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo)
        {
            return _systemConfigRepository.Insert_dm_ngonngu_danhmuc(objInfo);
        }

        public bool Update_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo)
        {

            return _systemConfigRepository.Update_dm_ngonngu_danhmuc(objInfo);
        }

        public bool Delete_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo)
        {

            return _systemConfigRepository.Delete_dm_ngonngu_danhmuc(objInfo);
        }

        public DataTable Data_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu)
        {

            return _systemConfigRepository.Data_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu);
        }

        public DataTable Get_Data_dm_ngonngu_danhmuc(DataGridView dtg, BindingNavigator bv, string iddanhmuc, string madanhmuc, string idngonngu)
        {

            return _systemConfigRepository.Get_Data_dm_ngonngu_danhmuc(dtg, bv, iddanhmuc, madanhmuc, idngonngu);
        }

        public DataTable Get_Data_dm_ngonngu_danhmuc(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string iddanhmuc, string madanhmuc, string idngonngu)
        {

            return _systemConfigRepository.Get_Data_dm_ngonngu_danhmuc(dtg, bv, ref sqlDataAdapter, ref dtData, iddanhmuc, madanhmuc, idngonngu);
        }

        public DataTable Get_Data_dm_ngonngu_danhmuc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string iddanhmuc, string madanhmuc, string idngonngu)
        {

            return _systemConfigRepository.Get_Data_dm_ngonngu_danhmuc(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, iddanhmuc, madanhmuc, idngonngu);
        }

        public DM_NGONNGU_DANHMUC Get_Info_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu)
        {

            return _systemConfigRepository.Get_Info_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu);
        }
        public DataTable Data_DSDanhMuc_KhaiBaoNgonNgu(int idLoaiDanhMuc)
        {
            return _systemConfigRepository.Data_DSDanhMuc_KhaiBaoNgonNgu(idLoaiDanhMuc);
        }
        #endregion
        #region dm_congtacvien
        public int Insert_dm_congtacvien(DM_CONGTACVIEN objInfo)
        {
            return _systemConfigRepository.Insert_dm_congtacvien(objInfo);
        }

        public int Update_dm_congtacvien(DM_CONGTACVIEN objInfo)
        {

            return _systemConfigRepository.Update_dm_congtacvien(objInfo);
        }

        public int Delete_dm_congtacvien(string macongtacvien)
        {

            return _systemConfigRepository.Delete_dm_congtacvien(macongtacvien);
        }

        public DataTable Data_dm_congtacvien(string macongtacvien)
        {
            return _systemConfigRepository.Data_dm_congtacvien(macongtacvien);
        }

        public DM_CONGTACVIEN Get_Info_dm_congtacvien(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_congtacvien(drInfo);
        }
        public DM_CONGTACVIEN Get_Info_dm_congtacvien(string macongtacvien)
        {

            return _systemConfigRepository.Get_Info_dm_congtacvien(macongtacvien);
        }
        public bool CheckExists_dm_congtacvien(string macongtacvien)
        {
            return _systemConfigRepository.CheckExists_dm_congtacvien(macongtacvien);
        }

        #endregion
        #region dm_sinhly
        public int Insert_dm_sinhly(DM_SINHLY objInfo)
        {
            return _systemConfigRepository.Insert_dm_sinhly(objInfo);
        }

        public int Update_dm_sinhly(DM_SINHLY objInfo)
        {

            return _systemConfigRepository.Update_dm_sinhly(objInfo);
        }

        public int Delete_dm_sinhly(string masinhly)
        {

            return _systemConfigRepository.Delete_dm_sinhly(masinhly);
        }

        public DataTable Data_dm_sinhly(string masinhly)
        {

            return _systemConfigRepository.Data_dm_sinhly(masinhly);
        }

        public DM_SINHLY Get_Info_dm_sinhly(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_sinhly(drInfo);
        }

        public DM_SINHLY Get_Info_dm_sinhly(string masinhly)
        {

            return _systemConfigRepository.Get_Info_dm_sinhly(masinhly);
        }

        public bool CheckExists_dm_sinhly(string masinhly)
        {

            return _systemConfigRepository.CheckExists_dm_sinhly(masinhly);
        }
        #endregion
        #region DanhSachMayXetNghiem
        public DataTable Data_DanhSachMayXetNghiem()
        {
            return _systemConfigRepository.Data_DanhSachMayXetNghiem();
        }
        #endregion
        #region dm_congty

        public int Insert_dm_congty(DM_CONGTY objInfo)
        {
            return _systemConfigRepository.Insert_dm_congty(objInfo);
        }

        public int Update_dm_congty(DM_CONGTY objInfo)
        {

            return _systemConfigRepository.Update_dm_congty(objInfo);
        }

        public int Delete_dm_congty(string macongty)
        {

            return _systemConfigRepository.Delete_dm_congty(macongty);
        }

        public DataTable Data_dm_congty(string macongty)
        {

            return _systemConfigRepository.Data_dm_congty(macongty);
        }

        public DM_CONGTY Get_Info_dm_congty(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_congty(drInfo);
        }

        public DM_CONGTY Get_Info_dm_congty(string macongty)
        {

            return _systemConfigRepository.Get_Info_dm_congty(macongty);
        }

        public bool CheckExists_dm_congty(string macongty)
        {

            return _systemConfigRepository.CheckExists_dm_congty(macongty);
        }
        #endregion
        #region dm_khayluumau
        public int Insert_dm_khayluumau(DM_KHAYLUUMAU objInfo)
        {
            return _systemConfigRepository.Insert_dm_khayluumau(objInfo);
        }

        public int Update_dm_khayluumau(DM_KHAYLUUMAU objInfo)
        {

            return _systemConfigRepository.Update_dm_khayluumau(objInfo);
        }

        public int Delete_dm_khayluumau(string makhayluumau)
        {

            return _systemConfigRepository.Delete_dm_khayluumau(makhayluumau);
        }

        public DataTable Data_dm_khayluumau(string matuluumau, string makhayluumau)
        {

            return _systemConfigRepository.Data_dm_khayluumau(matuluumau, makhayluumau);
        }

        public DM_KHAYLUUMAU Get_Info_dm_khayluumau(DataRow drInfo)
        {

            return _systemConfigRepository.Get_Info_dm_khayluumau(drInfo);
        }

        public DM_KHAYLUUMAU Get_Info_dm_khayluumau(string makhayluumau)
        {

            return _systemConfigRepository.Get_Info_dm_khayluumau(makhayluumau);
        }

        public bool CheckExists_dm_khayluumau(string makhayluumau)
        {

            return _systemConfigRepository.CheckExists_dm_khayluumau(makhayluumau);
        }
        #endregion
        #region dm_tuluumau
        public int Insert_dm_tuluumau(DM_TULUUMAU objInfo)
        {
            return _systemConfigRepository.Insert_dm_tuluumau(objInfo);
        }

        public int Update_dm_tuluumau(DM_TULUUMAU objInfo)
        {
            return _systemConfigRepository.Update_dm_tuluumau(objInfo);
        }

        public int Delete_dm_tuluumau(string matuluu)
        {
            return _systemConfigRepository.Delete_dm_tuluumau(matuluu);
        }

        public DataTable Data_dm_tuluumau(string matuluu)
        {
            return _systemConfigRepository.Data_dm_tuluumau(matuluu);
        }

        public DM_TULUUMAU Get_Info_dm_tuluumau(DataRow drInfo)
        {
            return _systemConfigRepository.Get_Info_dm_tuluumau(drInfo);
        }

        public DM_TULUUMAU Get_Info_dm_tuluumau(string matuluu)
        {
            return _systemConfigRepository.Get_Info_dm_tuluumau(matuluu);
        }

        public bool CheckExists_dm_tuluumau(string matuluu)
        {
            return _systemConfigRepository.CheckExists_dm_tuluumau(matuluu);
        }

        #endregion
        #region dm_khuvuc_xnkhongthuchien
        public int Insert_dm_khuvuc_xnkhongthuchien(DM_KHUVUC_XNKHONGTHUCHIEN objInfo)
        {
            return _systemConfigRepository.Insert_dm_khuvuc_xnkhongthuchien(objInfo);
        }

        public int Update_dm_khuvuc_xnkhongthuchien(DM_KHUVUC_XNKHONGTHUCHIEN objInfo)
        {
            return _systemConfigRepository.Update_dm_khuvuc_xnkhongthuchien(objInfo);
        }

        public int Delete_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan, string Nguoixoa, string Pcxoa)
        {
            return _systemConfigRepository.Delete_dm_khuvuc_xnkhongthuchien(makhuvuc, maxn, makhuvucnhan, Nguoixoa, Pcxoa);
        }

        public DataTable Data_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan)
        {
            return _systemConfigRepository.Data_dm_khuvuc_xnkhongthuchien(makhuvuc, maxn, makhuvucnhan);
        }

        public DM_KHUVUC_XNKHONGTHUCHIEN Get_Info_dm_khuvuc_xnkhongthuchien(DataRow drInfo)
        {
            return _systemConfigRepository.Get_Info_dm_khuvuc_xnkhongthuchien(drInfo);
        }

        public DM_KHUVUC_XNKHONGTHUCHIEN Get_Info_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan)
        {
            return _systemConfigRepository.Get_Info_dm_khuvuc_xnkhongthuchien(makhuvuc, maxn, makhuvucnhan);
        }

        public bool CheckExists_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan)
        {
            return _systemConfigRepository.CheckExists_dm_khuvuc_xnkhongthuchien(makhuvuc, maxn, makhuvucnhan);
        }
        #endregion
        #region DM diễn giải
        public DataSet DanhMuc_Gen_ChaCon()
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_Gen_ChaCon");
            if (ds == null) return null;
            return ds;
        }
        public int Insert_dm_diengiaketquagen(DM_DIENGIAKETQUAGEN objInfo)
        {
            if (CheckExists_dm_diengiaketquagen(objInfo.Id)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaXnThamGia", objInfo.Maxnthamgia),
                        WorkingServices.GetParaFromOject("@NguoiTao", objInfo.Nguoitao),
                        WorkingServices.GetParaFromOject("@GiaiThich", objInfo.Giaithich),
                        WorkingServices.GetParaFromOject("@TuVan", objInfo.Tuvan),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@TaiLieuThamKhao", objInfo.Tailieuthamkhao),
                        WorkingServices.GetParaFromOject("@Gioihan", objInfo.Gioihan),
                        WorkingServices.GetParaFromOject("@Loai", objInfo.Loai),
                        WorkingServices.GetParaFromOject("@GhiChuDienGiai", objInfo.Ghichudiengiai),
                        WorkingServices.GetParaFromOject("@HinhDienGiai1", objInfo.Hinhdiengiai1, isImage: true),
                        WorkingServices.GetParaFromOject("@HinhDienGiai2", objInfo.Hinhdiengiai2, isImage: true)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_diengiaketquagen", para);
        }
        public int Update_dm_diengiaketquagen(DM_DIENGIAKETQUAGEN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", objInfo.Id),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaXnThamGia", objInfo.Maxnthamgia),
                        WorkingServices.GetParaFromOject("@NguoiSua", objInfo.Nguoisua),
                        WorkingServices.GetParaFromOject("@GiaiThich", objInfo.Giaithich),
                        WorkingServices.GetParaFromOject("@TuVan", objInfo.Tuvan),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@TaiLieuThamKhao", objInfo.Tailieuthamkhao),
                        WorkingServices.GetParaFromOject("@Gioihan", objInfo.Gioihan),
                        WorkingServices.GetParaFromOject("@Loai", objInfo.Loai),
                        WorkingServices.GetParaFromOject("@GhiChuDienGiai", objInfo.Ghichudiengiai),
                        WorkingServices.GetParaFromOject("@HinhDienGiai1", objInfo.Hinhdiengiai1, isImage: true),
                        WorkingServices.GetParaFromOject("@HinhDienGiai2", objInfo.Hinhdiengiai2, isImage: true)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_diengiaketquagen", para);
        }
        public int Delete_dm_diengiaketquagen(int id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_diengiaketquagen", para);
        }
        public DataTable Data_dm_diengiaketquagen(int? id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_diengiaketquagen", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable Data_dm_diengiaketquagen_theoxetnghiem(string maXn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", maXn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_diengiaketquagen_theoxetnghiem", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_DIENGIAKETQUAGEN Get_Info_dm_diengiaketquagen(DataRow drInfo)
        {
            return (DM_DIENGIAKETQUAGEN)WorkingServices.Get_InfoForObject(new DM_DIENGIAKETQUAGEN(), drInfo);
        }
        public DM_DIENGIAKETQUAGEN Get_Info_dm_diengiaketquagen(int id)
        {
            DataTable dt = Data_dm_diengiaketquagen(id);
            DM_DIENGIAKETQUAGEN obj = new DM_DIENGIAKETQUAGEN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_diengiaketquagen(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_diengiaketquagen(int id)
        {
            return Data_dm_diengiaketquagen(id).Rows.Count > 0;
        }
        #endregion
    }

}