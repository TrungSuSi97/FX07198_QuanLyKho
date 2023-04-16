using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;
using TPH.LIS.Configuration.Models;
using TPH.LIS.User.Enum;

namespace TPH.LIS.Configuration.Services.SystemConfig
{
    public interface ISystemConfigService
    {
        ConfigurationDetail GetSystemConfigurationDetail(string withLocaionID = "");
        void InsertUpdateConfiguationDetail(ConfigurationDetail objconfig);
        int SaveConfig_WithConfigID(string maCauHinh, string mayTinh, string giaTri);
        int Check_UpdateSoftware(string pcName, string fileVersion, string appName);
        int Update_PcLogin(string pcName, string versionId, string ip, string appName);
        int Update_PcLogin_FileInfo(string pcName, string fileInfo);
        bool Check_ExistsMaXN(string MaXN);
        void AddNewTest(string code, string name, string group, string unit,
             string normal, string lower, string upper, string price, bool isBoldName,
             bool isBoldResult, bool isMainTest, string criteria, string sampleType
            , string printNo, string orderNo, bool ignoreCheckResult);

        #region Cấu hình danh mục loại dịch vụ
        DataTable Data_CauHinh_PhanLoaiChucNang(string filter);
        void Get_CauHinh_PhanLoaiChucNang(ComboBox cbo, string filter, ref DataTable dt);
        void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, string filter);
        void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, TextBox txt, string filter);
        #endregion

        #region Load danh sách tổng hợp
        DataTable Load_Nhom_TheoDVCLS(string nhomDichVu, string filter = "");
        DataTable Load_ChiDinhCLS(CustomComboBox cbo, string loaiDichVu, string nhomCd, string sex, string maDoiTuongDv
            , string filter = "", bool ForClick = true, bool forConfig = false);
        DataTable ConvertColumnName_DanhMucDichVu(DataTable _danhSachChiDinh);
        #endregion


        #region dm_xetnghiem
        int Insert_dm_xetnghiem(DM_XETNGHIEM objInfo);
        int Update_dm_xetnghiem(DM_XETNGHIEM objInfo);
        int Delete_dm_xetnghiem(string maxn);
        DM_XETNGHIEM Get_Info_dm_xetnghiem(DataRow drInfo);
        DM_XETNGHIEM Get_Info_dm_xetnghiem(string maxn);
        bool CheckExists_dm_xetnghiem(string maxn);
        DataTable Data_dm_xetnghiem(string phanquyenNhom, bool checkQuyenNhom, string maxn);
        DataTable Data_dm_xetnghiem_NotInProfile(string profileID);
        DataTable Data_dm_xetnghiem_NotInMappingMaMy(int idMayXn);
        DataTable XetNghiemDangDung(string testCode);
        DataTable GetDM_XetNghiem_CoNhomCLSVaProfile(bool chiXNDichVu);
        #endregion
        #region dm_xetnghiem_nhom
        int Insert_dm_xetnghiem_nhom(DM_XETNGHIEM_NHOM objInfo);
        int Update_dm_xetnghiem_nhom(DM_XETNGHIEM_NHOM objInfo);
        int Delete_dm_xetnghiem_nhom(string manhomcls);
        DataTable Data_dm_xetnghiem_nhom(string manhomcls);
        DM_XETNGHIEM_NHOM Get_Info_dm_xetnghiem_nhom(DataRow drInfo);
        DM_XETNGHIEM_NHOM Get_Info_dm_xetnghiem_nhom(string manhomcls);
        bool CheckExists_dm_xetnghiem_nhom(string manhomcls);
        #endregion
        #region dm_xetnghiem_profile
        int Insert_dm_xetnghiem_profile(DM_XETNGHIEM_PROFILE objInfo);
        int Update_dm_xetnghiem_profile(DM_XETNGHIEM_PROFILE objInfo);
        int Delete_dm_xetnghiem_profile(string profileid);
        DataTable Data_dm_xetnghiem_profile(string profileid);
        DM_XETNGHIEM_PROFILE Get_Info_dm_xetnghiem_profile(DataRow drInfo);
        DM_XETNGHIEM_PROFILE Get_Info_dm_xetnghiem_profile(string profileid);
        bool CheckExists_dm_xetnghiem_profile(string profileid);
        #endregion
        #region dm_xetnghiem_profile_chitiet
        int Insert_dm_xetnghiem_profile_chitiet(DM_XETNGHIEM_PROFILE_CHITIET objInfo);
        int Update_dm_xetnghiem_profile_chitiet(DM_XETNGHIEM_PROFILE_CHITIET objInfo);
        int Delete_dm_xetnghiem_profile_chitiet(string profileid, string maxn);
        DataTable Data_dm_xetnghiem_profile_chitiet(string profileid, string maxn);
        DM_XETNGHIEM_PROFILE_CHITIET Get_Info_dm_xetnghiem_profile_chitiet(DataRow drInfo);
        DM_XETNGHIEM_PROFILE_CHITIET Get_Info_dm_xetnghiem_profile_chitiet(string profileid, string maxn);
        bool CheckExists_dm_xetnghiem_profile_chitiet(string profileid, string maxn);
        #endregion
        #region dm_xetnghiem_tinhtoan
        int Insert_dm_xetnghiem_tinhtoan(DM_XETNGHIEM_TINHTOAN objInfo);
        int Update_dm_xetnghiem_tinhtoan(DM_XETNGHIEM_TINHTOAN objInfo);
        int Delete_dm_xetnghiem_tinhtoan(int id);
        DataTable Data_dm_xetnghiem_tinhtoan(int? id);
        DM_XETNGHIEM_TINHTOAN Get_Info_dm_xetnghiem_tinhtoan(DataRow drInfo);
        DM_XETNGHIEM_TINHTOAN Get_Info_dm_xetnghiem_tinhtoan(int id);
        bool CheckExists_dm_xetnghiem_tinhtoan(int id);
        #endregion
        #region dm_xetnghiem_csbt
        int Insert_dm_xetnghiem_csbt(DM_XETNGHIEM_CSBT objInfo);
        int Update_dm_xetnghiem_csbt(DM_XETNGHIEM_CSBT objInfo);
        int Delete_dm_xetnghiem_csbt(int autoid);
        DataTable Data_dm_xetnghiem_csbt(int? autoid, string maxn);
        DM_XETNGHIEM_CSBT Get_Info_dm_xetnghiem_csbt(DataRow drInfo);
        DM_XETNGHIEM_CSBT Get_Info_dm_xetnghiem_csbt(int autoid);
        bool CheckExists_dm_xetnghiem_csbt(int autoid);
        #endregion
        #region dm_xetnghiem_biendichketqua
        int Insert_dm_xetnghiem_biendichketqua(DM_XETNGHIEM_BIENDICHKETQUA objInfo);
        int Update_dm_xetnghiem_biendichketqua(DM_XETNGHIEM_BIENDICHKETQUA objInfo);
        int Delete_dm_xetnghiem_biendichketqua(int autoid);
        DataTable Data_dm_xetnghiem_biendichketqua(int? autoid);
        DM_XETNGHIEM_BIENDICHKETQUA Get_Info_dm_xetnghiem_biendichketqua(DataRow drInfo);
        DM_XETNGHIEM_BIENDICHKETQUA Get_Info_dm_xetnghiem_biendichketqua(int autoid);
        bool CheckExists_dm_xetnghiem_biendichketqua(int autoid);
        #endregion
        DataTable GetDM_XetNghiem_CauHinhMaMayXn(int idMayXN);
        DataTable GetTestGroup(string filter, string filter2 = "");
        void GetTestGroup(CustomComboBox cbo, string filter, string filter2 = "");
        void GetTestGroup(ComboBox cbo, string filter, string filter2 = "");
        DataTable GetSubclinical(string filter);
        DataTable GetSubclinical(ref SqlDataAdapter da, ref DataTable data, string filter);
        void GetSubclinical(CustomComboBox cbo, string filter);
        DataTable GetSubclinicalTestAndProfile(CustomComboBox cbo, string maNhom, string maDoiTuongDv, string filter2 = "", bool checkMagoTat = true);
        
        DataTable GetSubclinicalTest_NoProfile(string filter);
        DataTable GetData_Profile_SLSS();
        DataTable GetTestCaculate(string filter);
        DataTable GetTestingMachines(); 
        BaseModel AddNewTestingMachine(TestingMachineModel testingMachineInfo);
        BaseModel UpdateTestingMachine(TestingMachineModel testingMachineInfo);
        bool DeleteTestingMachine(TestingMachineModel testingMachineInfo);
        DataTable GetTestingMachines(string id, string testingCode, string testingMachineCode);
        DataTable GetNormalRange(string maxn, int? idMay);
        List<DM_XETNGHIEM_CSBT> ListNormalRange(DataTable dataNormalRange);
        #region ql_nhanvien
        DataTable Data_dm_nhomnhanvien();
        BaseModel Insert_ql_nhanvien(QL_NHANVIEN objInfo);
        bool Update_ql_nhanvien(QL_NHANVIEN objInfo);
        bool Delete_ql_nhanvien(QL_NHANVIEN objInfo);
        DataTable Data_ql_nhanvien(string manhanvien, string manhomNhanvien);
        QL_NHANVIEN Get_Info_ql_nhanvien(string manhanvien, string manhomNhanvien);
        #endregion
        #region Bộ phận
        BaseModel Insert_dm_bophan(DM_BOPHAN objInfo);
        bool Update_dm_bophan(DM_BOPHAN objInfo);
        bool Delete_dm_bophan(DM_BOPHAN objInfo);
        DataTable Data_dm_bophan(string mabophan, string maphanloai);
        DataTable Get_Data_dm_bophan(DataGridView dtg, BindingNavigator bv, string mabophan, string maphanloai);
        DataTable Get_Data_dm_bophan(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabophan, string maphanloai);
        DataTable Get_Data_dm_bophan(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabophan, string maphanloai);
        DM_BOPHAN Get_Info_dm_bophan(string mabophan, string maphanloai);
        #endregion
        #region Khoa phòng

        DataTable GetLocation(string makhoaphong, string tenKhoaPhong, string maBophan = "");

        BaseModel AddNewLocation(LocationDepartmentModel locationInfo);

        BaseModel UpdateLocation(LocationDepartmentModel locationInfo, string maKhoaPhongOld);

        bool DeleteLocation(LocationDepartmentModel locationInfo);

        DataTable GetLocation(DataGridView dtg, BindingNavigator bv, string makhoaphong, string tenKhoaPhong);
        DataTable GetLocation(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, TextBox txt, int linkColumnIndex, 
            string makhoaphong, string mabophan);

        LocationDepartmentModel Get_Info_LocationDepartment(string makhoaphong);


        #endregion
        #region dm_khuvuc
        BaseModel Insert_dm_khuvuc(DM_KHUVUC objInfo);
        bool Update_dm_khuvuc(DM_KHUVUC objInfo);
        bool Delete_dm_khuvuc(DM_KHUVUC objInfo);
        DataTable Data_dm_khuvuc(string makhuvuc);
        DataTable Get_Data_dm_khuvuc(DataGridView dtg, BindingNavigator bv, string makhuvuc);
        DataTable Get_Data_dm_khuvuc(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string makhuvuc);
        DataTable Get_Data_dm_khuvuc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string makhuvuc);
        DM_KHUVUC Get_Info_dm_khuvuc(string makhuvuc);
        DM_KHUVUC Get_Info_dm_khuvuc(DataRow dr);
        #endregion
        #region KhuVuc-MayTinh
        BaseModel Insert_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo);
        bool Update_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo);
        bool Delete_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo);
        DataTable Data_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh);
        DataTable Get_Data_dm_khuvuc_maytinh(DataGridView dtg, BindingNavigator bv, string id, string makhuvuc, string tenmaytinh);
        DataTable Get_Data_dm_khuvuc_maytinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id, string makhuvuc, string tenmaytinh);
        DataTable Get_Data_dm_khuvuc_maytinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string makhuvuc, string tenmaytinh);
        DM_KHUVUC_MAYTINH Get_Info_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh);
        DataTable DataThongTinKhuVucTheomayTinh(string pcName);
        List<DM_KHUVUC_MAYTINH> Get_LstInfo_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh);
        List<DM_KHUVUC_MAYTINH> Get_LstInfo_dm_khuvuc_maytinh(string tenmaytinh);
        int[] GetPCHisWorking(string tenmaytinh, string makhuvuc);
        DataTable Data_dm_khuVu_maytinh(string makhuvuc, string tenmaytinh);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_mauphieuin
        BaseModel Insert_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo);
        bool Update_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo);
        bool Delete_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo);
        DataTable Data_dm_xetnghiem_mauphieuin(string idmauketqua);
        DataTable DSMauPhieuIn_ThaoTac();
        DataTable Get_Data_dm_xetnghiem_mauphieuin(DataGridView dtg, BindingNavigator bv, string idmauketqua);
        DataTable Get_Data_dm_xetnghiem_mauphieuin(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauketqua);
        DataTable Get_Data_dm_xetnghiem_mauphieuin(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauketqua);
        DM_XETNGHIEM_MAUPHIEUIN Get_Info_dm_xetnghiem_mauphieuin(string idmauketqua);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_mauphieuin_vitri
        BaseModel Insert_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo);
        bool Update_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo);
        bool Delete_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo);
        DataTable Data_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem);
        DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(DataGridView dtg, BindingNavigator bv, string idmauketqua, string mavitri, string maxetnghiem);
        DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauketqua, string mavitri, string maxetnghiem);
        DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauketqua, string mavitri, string maxetnghiem);
        DM_XETNGHIEM_MAUPHIEUIN_VITRI Get_Info_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_mauphieuin_tuychon
        BaseModel Insert_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo);
        bool Update_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo);
        bool Delete_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo);
        DataTable Data_dm_xetnghiem_mauphieuin_tuychon_CoMauCha(string idmauchon);
        DataTable Data_dm_xetnghiem_mauphieuin_tuychon(string idmauchon);
        DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(DataGridView dtg, BindingNavigator bv, string idmauchon);
        DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauchon);
        DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauchon);
        DM_XETNGHIEM_MAUPHIEUIN_TUYCHON Get_Info_dm_xetnghiem_mauphieuin_tuychon(string idmauchon);
        #endregion
        //================================|||=====================================
        #region cauhinh_mayinketqua
        BaseModel Insert_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo);
        bool Update_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo, CAUHINH_MAYINKETQUA objInfoOld);
        bool Delete_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo);
        DataTable Data_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid);
        DataTable Get_Data_cauhinh_mayinketqua(DataGridView dtg, BindingNavigator bv, string pcname, string printername, string reporttemplateid);
        DataTable Get_Data_cauhinh_mayinketqua(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string pcname, string printername, string reporttemplateid);
        DataTable Get_Data_cauhinh_mayinketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string pcname, string printername, string reporttemplateid);
        CAUHINH_MAYINKETQUA Get_Info_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid);
        List<CAUHINH_MAYINKETQUA> ListCauHinhMayIn(string tenmaytinh);
        #endregion
        #region Danh mục siêu âm
        void Get_NhomCLS_SieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_NhomCLS_SieuAm(ref SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
        ref DataTable dt);
        void Get_NhomCLS_SieuAm(ComboBox cbo, string filter, ref DataTable dt);
        DataTable Get_NhomCLS_SieuAm(ComboBox cbo, string filter);
        DataTable Get_NhomCLS_SieuAm(CustomComboBox cbo, string filter);
        void Get_DMSieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        DataTable Get_DMSieuAm(string filter);
        int Insert_MaySieuAm(string tenMay);
        DataTable Get_DMSieuAm(CustomComboBox cbo, string filter, string maDoiTuongDv);
        void Get_DMMaySA(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt);
        void Get_DMMaySA(CustomComboBox cbo);
        void Get_DMMaySA(ComboBox cbo);
        int Insert_Update_DMSieuAm(string maNhomSieuAm, string maSoMau, string goTat, string tenMauSieuAm,
            string tenChiDinh, string tieuDePhieuKetQua, string gioiTinhSuDung, string chanDoanMacDinh,
            string ketluanMacDinh, string deNghi, string soLuongHinh, string soTrangIn, string noiDung1, string noiDung2,
            bool insert);
        #endregion
        #region Dah mục nội soi
        bool Insert_Update_DMNoiSoi(string maNhomNoiSoi, string maSoMauNoiSoi, string goTat, string tenMauNoiSoi,
        string tenChiDinh, string tieuDePhieuKetQua, string gioiTinhSuDung, string chanDoanMacDinh,
        string ketluanMacDinh, string deNghi, string soLuongHinh, string soTrangIn, string noiDung1, string noiDung2,
        bool insert);
        void Get_DM_NoiSoi_KetQuaHP(CustomDatagridView dtg, BindingNavigator bv,
            ref SqlDataAdapter da, ref DataTable dt);
        void Get_DM_NoiSoi_KetQuaHP(CustomComboBox cbo, TextBox txt);
        void Get_DM_NoiSoi_KyThuatHP(CustomDatagridView dtg, BindingNavigator bv,
        ref SqlDataAdapter da, ref DataTable dt);
        void Get_DM_NoiSoi_KyThuatHP(CustomComboBox cbo, TextBox txt);
        void Get_DMMayNS(CustomComboBox cbo);
        void Get_DMMayNS(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
        ref DataTable dt);
        DataTable Get_DMNoiSoi(CustomComboBox cbo, string filter, string maDoiTuongDv);
        void Insert_MayNoiSoi(string tenMay);
        DataTable Get_DMNoiSoi(string filter);
        void Get_DMNoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        DataTable Get_NhomCLS_NoiSoi(CustomComboBox cbo, string filter);
        DataTable Get_NhomCLS_NoiSoi(ComboBox cbo, string filter);
        void Get_NhomCLS_NoiSoi(ComboBox cbo, string filter, ref DataTable dt);
        void Get_NhomCLS_NoiSoi(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
        ref DataTable dt);
        void Get_NhomCLS_NoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        #endregion
        #region Danh mục thuốc
        void Get_DM_Thuoc_GocThuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_Thuoc_GocThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_Thuoc_GocThuoc(CustomComboBox cbo, string filter, ref DataTable dt);
        void Get_DM_Thuoc_GocThuoc(CustomComboBox cbo, string filter);
        bool Insert_GocThuoc(string maGocThuoc, string tenGocThuoc, string maNhomThuoc, string thuTuIn);
        void Get_DM_Thuoc_NhomThuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_Thuoc_NhomThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                ref DataTable dt);
        DataTable Get_DM_Thuoc_NhomThuoc(CustomComboBox cbo, string filter, ref DataTable dt);
        DataTable Get_DM_Thuoc_NhomThuoc(CustomComboBox cbo);
        bool Insert_NhomThuoc(string maNhomThuoc, string tenNhomThuoc);
        DataTable Data_DM_Thuoc_ForWork(CustomComboBox cbo, string valueColumn, string displayColumn,
         string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
         string maNhaCungCap, string manhomThuoc, string doiTuongDv);
        void Data_DM_Thuoc_ForInput(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
            string maNhaCungCap, string manhomThuoc);
        void Get_DM_Thuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_Thuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                ref DataTable dt);
        void Get_DM_Thuoc(CustomComboBox cbo, string filter, ref DataTable dt);
        void Get_DM_Thuoc(CustomComboBox cbo, string filter);
        void Get_DM_Thuoc_List(ListView lst, ImageList iml, int indexNormal, string itemdId, string categoryId);
        DataTable Get_DM_Thuoc_List(string itemdId, string categoryId, string _MaTiepNhan = "", string _MaDonVi = "", string _MaYeuCau = "");
        void Addrange(ListViewItem it, ListViewGroup grp, DataRow item, int indexNormal);
        bool Insert_Update_Thuoc(string maThuoc, string tenThuoc, string maVatTu,
        string maGocThuoc, string donViTinh, string cachDung, string sang, string trua,
        string chieu, string toi, string goTat, string sapXep, string gia, bool update);
        bool Delete_Thuoc(string maThuoc);
        void Get_DM_Thuoc_CachDung(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_Thuoc_CachDung(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                ref DataTable dt);
        void Get_DM_Thuoc_CachDung(CustomComboBox cbo, string filter, ref DataTable dt);
        void Get_DM_Thuoc_CachDung(CustomComboBox cbo, string filter);
        void Get_DM_Thuoc_CachDung(DataGridViewComboBoxColumn cbo, string filter);
        DataTable Get_DM_Thuoc_CachDung();
        void Get_DM_THUOC_PROFILE(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_THUOC_PROFILE(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                ref DataTable dt);
        void Get_DM_THUOC_PROFILE(CustomComboBox cbo, string filter, ref DataTable dt);
        void Get_DM_THUOC_PROFILE(CustomComboBox cbo, string filter);
        bool Insert_DM_Thuoc_Profile(string maprofile, string tenprofile);
        bool Update_DM_THUOC_PROFILE(string maprofile, string tenprofile);
        bool Delete_DM_THUOC_PROFILE(string maprofile);
        void Get_DM_THUOC_PROFILE_CHITIET(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_THUOC_PROFILE_CHITIET(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv,
                string filter, ref DataTable dt);
        void Get_DM_THUOC_PROFILE_CHITIET(CustomComboBox cbo, string filter, ref DataTable dt);
        void Get_DM_THUOC_PROFILE_CHITIET(CustomComboBox cbo, string filter);
        bool Insert_DM_Thuoc_Profile_ChiTiet(string maprofile, string mathuoc);
        bool Update_DM_THUOC_PROFILE_CHITIET(string maprofile, string mathuoc, string cachDung, string sang,
                string trua, string chieu, string toi);
        bool Delete_DM_THUOC_PROFILE_CHITIET(string maprofile, string mathuoc);
        void GET_THUOC_VA_PROFILE(CustomComboBox cbo, TextBox txt, string nhomThuoc);
        #endregion
        #region Danh mục khám bệnh
        bool Insert_DM_KhamBenh_NhomDichVu(string maNhom, string tenNhom, string thuTuIn);
        void Get_DM_KhamBenh_NhomDichVu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                  ref DataTable dt);
        DataTable Get_DM_KhamBenh_NhomDichVu(ComboBox cbo, string filter);
        DataTable Get_DM_KhamBenh_NhomDichVu(CustomComboBox cbo, string filter, TextBox txt);
        bool Insert_KhamBenh_DichVu(string maNhomDichVu, string maYeuCau, string tenYeucau, string ghiChuMacDinh,
                 string deNghiMacDinh, string giaChuan);
        void Get_DM_KhamBenh_DichVu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                    string maNhom, ref DataTable dt);
        void Get_DM_KhamBenh_DichVu(ComboBox cbo, string maNhom, string filter);
        DataTable Get_DM_KhamBenh_DichVu(CustomComboBox cbo, string maNhom, string filter, TextBox txt,
                  string maDoiTuongDv);
        #endregion
        #region Danh mục XQuang
        void Get_DM_XQuang_KyThuat(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_XQuang_KyThuat(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                   ref DataTable dt);
        DataTable Get_DM_XQuang_KyThuat(CustomComboBox cbo);
        void Get_DM_XQuang_VungChup(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_XQuang_VungChup(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                   ref DataTable dt);
        DataTable Get_DM_XQuang_VungChup(CustomComboBox cbo, string filter, string maDoiDuongDv);
        void Get_DM_XQuang_VungChup_ChiTiet(DataGridView dtg, BindingNavigator bv, string filter,
                    ref DataTable dt);
        void Get_DM_XQuang_VungChup_ChiTiet(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv,
                    string filter, ref DataTable dt);
        void Get_DM_XQuang_VungChup_ChiTiet(CustomComboBox cbo, string filter);
        void Insert_KyThuat(string maKyThuat, string tenKyThuat, string thuTuIn);
        void Delete_KyThuat(string maKyThuat);
        void Insert_VungChup(string maKyThuat, string maVungChup, string tenVungChup, string thuTuIn,
                   string phim, string soLuongPhim, string thuoc, string soLuongThuoc, string ketLuanMacDinh,
                   string deNghiMacDinh, string giaChuan);
        void Update_VungChup(string maKyThuat, string maVungChup, string tenVungChup, string thuTuIn,
                    string phim, string soLuongPhim, string thuoc, string soLuongThuoc, string ketLuanMacDinh,
                    string deNghiMacDinh, string giaChuan);
        void Delete_VungChup(string maKyThuat, string maVungChup);
        bool Update_MauKetQua(string maVungChup, string rtfMauKetQua);
        void Insert_MayXQuang(string tenMay);
        void Get_DMMayXQuang(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
                    ref DataTable dt);
        void Get_DMMayXQuang(CustomComboBox cbo);
        #endregion
        #region Danh mục dich vụ khác
        void Get_DM_DICHVUKHAC(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_DICHVUKHAC(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
       ref DataTable dt);
        void Get_DM_DICHVUKHAC(CustomComboBox cbo, string filter, ref DataTable dt);
        DataTable Get_DM_DICHVUKHAC(CustomComboBox cbo, string filter, string maDoiTuongDv);
        bool Insert_DM_DichVuKhac(string denghi, string ghichu, string giachuan, string madvkhac,
       string manhomcls, string mauketqua
       , string tendvkhac, string thutuin);
        bool Update_DM_DICHVUKHAC(string denghi, string ghichu, string giachuan, string madvkhac,
       string manhomcls, string mauketqua
       , string nguoisua, string tendvkhac, string thutuin);
        bool Delete_DM_DICHVUKHAC(string madvkhac);
        void Get_DM_NHOMCLS_DVKHAC(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DM_NHOMCLS_DVKHAC(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
       ref DataTable dt);
        DataTable Get_DM_NHOMCLS_DVKHAC(CustomComboBox cbo, string filter, ref DataTable dt);
        DataTable Get_DM_NHOMCLS_DVKHAC(CustomComboBox cbo, string filter);
        bool Insert_DM_NhomCLS_DVKhac(string manhomcls, string tennhomcls, string mauKq);
        DataTable Data_DS_MauKQ();
        void GET_DS_MAU_KQ(CustomComboBox cbo, TextBox txt);
        void GET_DS_MAU_KQ(DataGridViewComboBoxColumn cbo);
        #endregion
        #region dm_xetngnghiem_phuongphap
        //================================|||=====================================
        int Insert_dm_xetngnghiem_phuongphap(DM_XETNGNGHIEM_PHUONGPHAP objInfo);
        int Update_dm_xetngnghiem_phuongphap(DM_XETNGNGHIEM_PHUONGPHAP objInfo);
        int Delete_dm_xetngnghiem_phuongphap(int autoid);
        DataTable Data_dm_xetngnghiem_phuongphap(int? autoid, string maxn, int ? idMayXn);
        DM_XETNGNGHIEM_PHUONGPHAP Get_Info_dm_xetngnghiem_phuongphap(DataRow drInfo);
        DM_XETNGNGHIEM_PHUONGPHAP Get_Info_dm_xetngnghiem_phuongphap(int autoid);
        bool CheckExists_dm_xetngnghiem_phuongphap(int autoid);
        //================================|||=====================================
        #endregion
        #region Đối tượng dịch vụ
        DataTable Get_NhomDoiTuongDichVu(bool checkUsing);
        void Get_DoiTuongDichVu(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DoiTuongDichVu(ref  SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt);
        void Get_DoiTuongDichVu(ComboBox cbo, string filter, ref DataTable dt);
        DataTable Get_DoiTuongDichVu(string filter);
        void Get_DoiTuongDichVu(CustomComboBox cbo, string filter, ref DataTable dt);
        void Get_DoiTuongDichVu(CustomComboBox cbo, TextBox txt);
        string Get_Default_DoiTuongDV();
        void Get_DichVu_XN(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_SieuAm(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_XQuang(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_NoiSoi(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_KhamBenh(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_Khac(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_Thuoc(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Get_DichVu_ViSinh(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt);
        void Add_DichVu_ChiTiet_XN(string maDichVu, string maXetNghiem);
        int Copy_DichVu_ChiTiet_XN(string tuMaDoiTuong, string denMaDoiTuong);
        int Copy_GiaDichVu_ChiTiet_XN(string tuMaDoiTuong, string denMaDoiTuong);
        int Copy_DoiTuongDichVu_Gia(string tuMaDoiTuong, string denMaDoiTuong, ServiceType svrType);
        void Add_DichVu_ChiTiet_SieuAm(string maDoiTuongDichVu, string maDichVu);
        void Add_DichVu_ChiTiet_NoiSoi(string maDoiTuongDichVu, string maDichVu);
        void Add_DichVu_ChiTiet_XQuang(string maDoiTuongDichVu, string maDichVu);
        void Add_DichVu_ChiTiet_KhamBenh(string maDoiTuongDichVu, string maDichVu);
        void Add_DichVu_ChiTiet_DVKhac(string maDoiTuongDichVu, string maDichVu);
        void Add_DichVu_ChiTiet_Thuoc(string maDoiTuongDichVu, string maDichVu);
        void Delete_DichVu(string maDichVu);
        void Delete_ChiTiet_XN(string maDichVu, string maXetNghiem);
        void Delete_ChiTiet_SieuAm(string maDichVu, string maSoMau);
        void Delete_ChiTiet_NoiSoi(string maDichVu, string maSoMau);
        void Delete_ChiTiet_XQuang(string maDichVu, string maVungChup);
        void Delete_ChiTiet_KhamBenh(string maDichVu, string maYeuCau);
        void Delete_ChiTiet_DVKhac(string maDichVu, string maDvKhac);
        void Delete_ChiTiet_Thuoc(string maDichVu, string maThuoc);
        void Delete_ChiTiet_ViSinh(string maDichVu, string maXetNghiem);
        void Update_ChiTiet_XN_Gia(string maDichVu, string maXetNghiem, string gia);
        void Update_ChiTiet_XN_Gia(string maDichVu, string maXetNghiem, int phanTram);
        void Update_ChiTiet_SieuAm_Gia(string maDichVu, string maSoMau, string gia);
        void Update_ChiTiet_SieuAm_Gia(string maDichVu, string maSoMau, int phanTram);
        void Update_ChiTiet_NoiSoi_Gia(string maDichVu, string maSoMau, string gia);
        void Update_ChiTiet_NoiSoi_Gia(string maDichVu, string maSoMau, int phanTram);
        void Update_ChiTiet_XQuang_Gia(string maDichVu, string maVungChup, string gia);
        void Update_ChiTiet_XQuang_Gia(string maDichVu, string maVungChup, int phanTram);
        void Update_ChiTiet_KhamBenh_Gia(string maDichVu, string maYeuCau, string gia);
        void Update_ChiTiet_KhamBenh_Gia(string maDichVu, string maYeuCau, int phanTram);
        void Update_ChiTiet_DVKhac_Gia(string maDichVu, string maDvKhac, string gia);
        void Update_ChiTiet_DVKhac_Gia(string maDichVu, string maDvKhac, int phanTram);
        void Update_ChiTiet_Thuoc_Gia(string maDichVu, string maThuoc, string gia);
        void Update_ChiTiet_Thuoc_Gia(string maDichVu, string maThuoc, int phanTram);
        void Add_DichVu_ChiTiet_ViSinh(string maDichVu, string maXetNghiem);
        int Copy_DichVu_ChiTiet_ViSinh(string tuMaDoiTuong, string denMaDoiTuong);
        int Copy_GiaDichVu_ChiTiet_ViSinh(string tuMaDoiTuong, string denMaDoiTuong);

        int Insert_dm_xetnghiem_canhbao(string maxn, string idLocaichucNang);
        int Update_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang);
        DataTable Data_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang);

        #endregion
        #region QL Chẩn đoán
        void Add_ChanDoan(string maChanDoan, string chanDoan);
        void Add_ChanDoan(string maChanDoan);
        void Get_ChanDoan(ref SqlDataAdapter sqlDataAdapter, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dtData);
        void Get_ChanDoan(CustomComboBox cbo, TextBox txtLink);
        #endregion
        #region Quản lý mẫu để chọn
        BaseModel Insert_dm_mauchon(DM_MAUCHON objInfo);
        bool Update_dm_mauchon(DM_MAUCHON objInfo);
        bool Delete_dm_mauchon(DM_MAUCHON objInfo);
        DataTable Data_dm_mauchon(string[] id);
        DataTable Get_Data_dm_mauchon(DataGridView dtg, BindingNavigator bv, string[] id);
        DataTable Get_Data_dm_mauchon(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string[] id);
        DataTable Get_Data_dm_mauchon(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string[] id);
        DM_MAUCHON Get_Info_dm_mauchon(string[] id);

        #endregion
        #region dm_hentraketqua
        //================================|||=====================================
        BaseModel Insert_dm_hentraketqua(DM_HENTRAKETQUA objInfo);
        bool Update_dm_hentraketqua(DM_HENTRAKETQUA objInfo);
        bool Delete_dm_hentraketqua(string id);
        DataTable Data_dm_hentraketqua(string id, string maloaiDichVu, string maNhom);
        DataTable Get_Data_dm_hentraketqua(DataGridView dtg, BindingNavigator bv, string id, string maloaiDichVu, string maNhom);
        DataTable Get_Data_dm_hentraketqua(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData
            , string id, string maloaiDichVu, string maNhom);
        DataTable Get_Data_dm_hentraketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth
            , System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string maloaiDichVu, string maNhom);
        DM_HENTRAKETQUA Get_Info_dm_hentraketqua(string id);
        bool Copy_CauHinhHenTraKQ(string loaiDanhMuc, int id, List<string> denMaXn, bool cheDoNhom);
        #endregion
        #region dm_ngaynghi
        //================================|||=====================================
        BaseModel Insert_dm_ngaynghi(DM_NGAYNGHI objInfo);
        bool Update_dm_ngaynghi(DM_NGAYNGHI objInfo);
        bool Delete_dm_ngaynghi(DM_NGAYNGHI objInfo);
        DataTable Data_dm_ngaynghi_benhnhan(string matiepnhan);
        DataTable Data_dm_ngaynghi(string ngaynghi);
        DataTable Get_Data_dm_ngaynghi(DataGridView dtg, BindingNavigator bv, string ngaynghi);
        DataTable Get_Data_dm_ngaynghi(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string ngaynghi);
        DataTable Get_Data_dm_ngaynghi(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string ngaynghi);
        DM_NGAYNGHI Get_Info_dm_ngaynghi(string ngaynghi);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bophan
        BaseModel Insert_dm_xetnghiem_bophan(DM_XETNGHIEM_BOPHAN objInfo);
        int Update_dm_xetnghiem_bophan(DM_XETNGHIEM_BOPHAN objInfo);
        int Delete_dm_xetnghiem_bophan(string mabophan);
        DataTable Data_dm_xetnghiem_bophan(string mabophan);
        DataTable Data_dm_xetnghiem_bophan_withCategory(string maNhom);
        DM_XETNGHIEM_BOPHAN Get_Info_dm_xetnghiem_bophan(DataRow drInfo);
        DM_XETNGHIEM_BOPHAN Get_Info_dm_xetnghiem_bophan(string mabophan);
        bool CheckExists_dm_xetnghiem_bophan(string mabophan);
        #endregion
        //================================|||=====================================
        #region h_mayxetnghiem_chitiet
        //================================|||=====================================
        BaseModel Insert_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo);
        bool Update_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo);
        bool Delete_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo);
        DataTable Data_h_mayxetnghiem_chitiet(string idmayxn);
        DataTable Get_Data_h_mayxetnghiem_chitiet(DataGridView dtg, BindingNavigator bv, string idmayxn);
        DataTable Get_Data_h_mayxetnghiem_chitiet(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmayxn);
        DataTable Get_Data_h_mayxetnghiem_chitiet(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmayxn);
        H_MAYXETNGHIEM_CHITIET Get_Info_h_mayxetnghiem_chitiet(string idmayxn);
        DataTable Data_h_mayxetnghiem_chitiet_theo_phanloai(int idphanloai);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bo
        int Insert_dm_xetnghiem_bo(DM_XETNGHIEM_BO objInfo);
        int Update_dm_xetnghiem_bo(DM_XETNGHIEM_BO objInfo);
        int Delete_dm_xetnghiem_bo(string maboxetnghiem);
        DataTable Data_dm_xetnghiem_bo(string maboxetnghiem);
        DM_XETNGHIEM_BO Get_Info_dm_xetnghiem_bo(DataRow drInfo);
        DM_XETNGHIEM_BO Get_Info_dm_xetnghiem_bo(string maboxetnghiem);
        bool CheckExists_dm_xetnghiem_bo(string maboxetnghiem);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bo_chitiet
        int Insert_dm_xetnghiem_bo_chitiet(DM_XETNGHIEM_BO_CHITIET objInfo);
        int Delete_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile);
        DataTable Data_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile);
        DM_XETNGHIEM_BO_CHITIET Get_Info_dm_xetnghiem_bo_chitiet(DataRow drInfo);
        DM_XETNGHIEM_BO_CHITIET Get_Info_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile);
        bool CheckExists_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile);
        #endregion
        //================================|||=====================================
        #region Loại mẫu
        int Insert_dm_xetnghiem_loaimau(DM_XETNGHIEM_LOAIMAU objInfo);
        int Update_dm_xetnghiem_loaimau(DM_XETNGHIEM_LOAIMAU objInfo);
        int Delete_dm_xetnghiem_loaimau(string maloaimau);
        DataTable Data_dm_xetnghiem_loaimau(string maloaimau, string LoaiDvCLS);
        DM_XETNGHIEM_LOAIMAU Get_Info_dm_xetnghiem_loaimau(DataRow drInfo);
        DM_XETNGHIEM_LOAIMAU Get_Info_dm_xetnghiem_loaimau(string maloaimau);
        bool CheckExists_dm_xetnghiem_loaimau(string maloaimau);
        string MauOngMauTheoLoaiMau(string maloaimau);
        DataTable Data_LoaiMau_GetDM(string maloaimau, bool hienthinhan, string[] phanLoaiMau);
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_loaimauchinh
        BaseModel Insert_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo);
        bool Update_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo);
        bool Delete_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo);
        DataTable Data_dm_xetnghiem_loaimauchinh(string maloaimauchinh);
        DataTable Get_Data_dm_xetnghiem_loaimauchinh(DataGridView dtg, BindingNavigator bv, string maloaimauchinh);
        DataTable Get_Data_dm_xetnghiem_loaimauchinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maloaimauchinh);
        DataTable Get_Data_dm_xetnghiem_loaimauchinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maloaimauchinh);
        DM_XETNGHIEM_LOAIMAUCHINH Get_Info_dm_xetnghiem_loaimauchinh(string maloaimauchinh);
        #endregion
        //================================|||=====================================
        #region Loại mẫu nhận
        BaseModel Insert_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo);
        bool Update_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo);
        bool Delete_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo);
        DataTable Data_dm_xetnghiem_loaimau_nhom(string manhomloaimau, bool hienthinhan, string phanLoaiMau);
        DataTable Get_Data_dm_xetnghiem_loaimau_nhom(DataGridView dtg, BindingNavigator bv, string manhomloaimau);
        DataTable Get_Data_dm_xetnghiem_loaimau_nhom(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manhomloaimau);
        DataTable Get_Data_dm_xetnghiem_loaimau_nhom(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manhomloaimau);
        DM_XETNGHIEM_LOAIMAU_NHOM Get_Info_dm_xetnghiem_loaimau_nhom(string manhomloaimau);

        #endregion
        //================================|||=====================================
        #region dm_khulaymau
        BaseModel Insert_dm_khulaymau(DM_KHULAYMAU objInfo);
        bool Update_dm_khulaymau(DM_KHULAYMAU objInfo);
        bool Delete_dm_khulaymau(DM_KHULAYMAU objInfo);
        DataTable Data_dm_khulaymau(string idkhulaymau, string makhuvuc);
        DataTable Get_Data_dm_khulaymau(DataGridView dtg, BindingNavigator bv, string idkhulaymau, string makhuvuc);
        DataTable Get_Data_dm_khulaymau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idkhulaymau, string makhuvuc);
        DataTable Get_Data_dm_khulaymau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idkhulaymau, string makhuvuc);
        DM_KHULAYMAU Get_Info_dm_khulaymau(string idkhulaymau);
        DM_KHULAYMAU Get_Info_dm_khulaymau_Theomaytinh(string pcName);
        #endregion
        //================================|||=====================================
        #region Tình trạng mẫu
        DataTable Data_DanhMucTinhTrangMau(int LoaiXetNghiem);
        BaseModel Insert_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo);
        bool Update_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo);
        bool Delete_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo);
        DataTable Data_dm_tinhtrangmau(string id);
        DataTable Get_Data_dm_tinhtrangmau(DataGridView dtg, BindingNavigator bv, string id);
        DataTable Get_Data_dm_tinhtrangmau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id);
        DataTable Get_Data_dm_tinhtrangmau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id);
        DM_TINHTRANGMAU Get_Info_dm_tinhtrangmau(string id);
        #endregion
        //================================|||=====================================
        #region dm_email
        BaseModel Insert_dm_email(DM_EMAIL objInfo);
        bool Update_dm_email(DM_EMAIL objInfo);
        bool Delete_dm_email(DM_EMAIL objInfo);
        DataTable Data_dm_email(string email);
        DataTable Get_Data_dm_email(DataGridView dtg, BindingNavigator bv, string email);
        DataTable Get_Data_dm_email(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string email);
        DataTable Get_Data_dm_email(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string email);
        DM_EMAIL Get_Info_dm_email(string email);
        #endregion
        //================================|||=====================================
        #region Tieu de trang in
        void Get_Header_Config(SqlDataAdapter da, DataGridView dtg,
           BindingNavigator bv, string headerId,
           ref DataTable dt);
        DataTable Get_Header_Config(string headerId);
        Image Load_Logo(string maDonVi);
        #endregion

        #region LICENSE

        LicenseModel ValidLicense(string computerName, string applicationName, string serial);
        BaseModel ValidSerial(string computerName, string applicationId, string applicationName, string serial);
        bool InsertSerialKey(string computerName, string applicationName, string serialNumber);
        bool UpdateSerialKey(string computerName, string applicationName, string serialNumber, string keyNumber);
        #endregion LICENSE
        #region Cấu hình máy in barcode
        int Insert_CauHinhMayInbarcode(DM_MAYTINH_MAYIN obj);
        int Update_CauHinhMayInbarcode(DM_MAYTINH_MAYIN obj);
        int Delete_CauHinhMayInBarcode(DM_MAYTINH_MAYIN obj);
        DataTable Data_DanhSach_CauHinhMayInbarcode(string tenMayTinh, int idMay, int suDung);
        DM_MAYTINH_MAYIN Get_info_CauHinh_MaInbarcode(string tenMayTinh, int idMay, int suDung);
        DM_MAYTINH_MAYIN Get_info_CauHinh_MaInbarcode(DataRow dr);
        #endregion
        #region Máy tính
        BaseModel Insert_dm_maytinh(DM_MAYTINH objInfo);
        bool Update_dm_maytinh(DM_MAYTINH objInfo);
        bool Delete_dm_maytinh(DM_MAYTINH objInfo);
        DataTable Data_dm_maytinh(string tenmaytinh, string khulamviec);
        DataTable Get_Data_dm_maytinh(DataGridView dtg, BindingNavigator bv, string tenmaytinh, string khulamviec);
        DataTable Get_Data_dm_maytinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string tenmaytinh, string khulamviec);
        DataTable Get_Data_dm_maytinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string tenmaytinh, string khulamviec);
        DM_MAYTINH Get_Info_dm_maytinh(string tenmaytinh);
        #endregion
        #region Ghi chú tự động
        int Insert_dm_xetnghiem_ghichutudong(DM_XETNGHIEM_GHICHUTUDONG objInfo);
        int Update_dm_xetnghiem_ghichutudong(DM_XETNGHIEM_GHICHUTUDONG objInfo);
        int Delete_dm_xetnghiem_ghichutudong(int id);
        DataTable Data_dm_xetnghiem_ghichutudong(int? id, string maXn);
        DM_XETNGHIEM_GHICHUTUDONG Get_Info_dm_xetnghiem_ghichutudong(DataRow drInfo);
        DM_XETNGHIEM_GHICHUTUDONG Get_Info_dm_xetnghiem_ghichutudong(int id);
        bool CheckExists_dm_xetnghiem_ghichutudong(int id);
        #endregion
        #region Cấu hình hiển thị
        List<HienThiModel> lstThongTinHienThi(string idLoaihienThi);
        HienThiModel InfoThongTinHienthi(string idLoaiHienthi, string idHienThi);
        HienThiModel InfoThongTinHienThiTuDataRow(DataRow dr);
        DataTable DataThongTinHienThi(string idLoaiHienthi, string idHienThi);
        int InsertThongTinHienThi(HienThiModel hienThiModel);
        int UpdateThongTinHienThi(HienThiModel hienThiModel);
        int DeleteThongTinHienThi(string idLoaiHienthi, string idHienThi);
        #endregion
        #region dm_nhomphong
        BaseModel Insert_dm_nhomphong(DM_NHOMPHONG objInfo);
        bool Update_dm_nhomphong(DM_NHOMPHONG objInfo);
        bool Delete_dm_nhomphong(DM_NHOMPHONG objInfo);
        DataTable Data_dm_nhomphong(string manhomphong);
        DataTable Get_Data_dm_nhomphong(DataGridView dtg, BindingNavigator bv, string manhomphong);
        DataTable Get_Data_dm_nhomphong(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manhomphong);
        DataTable Get_Data_dm_nhomphong(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manhomphong);
        DM_NHOMPHONG Get_Info_dm_nhomphong(string manhomphong);
        #endregion
        #region dm_phong
        BaseModel Insert_dm_phong(DM_PHONG objInfo);
        bool Update_dm_phong(DM_PHONG objInfo);
        bool Delete_dm_phong(DM_PHONG objInfo);
        DataTable Data_dm_phong(string maphong, string makhoaphong, string manhomphong);
        DataTable Get_Data_dm_phong(DataGridView dtg, BindingNavigator bv, string maphong, string makhoaphong, string manhomphong);
        DataTable Get_Data_dm_phong(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maphong, string makhoaphong, string manhomphong);
        DataTable Get_Data_dm_phong(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maphong, string makhoaphong, string manhomphong);
        DM_PHONG Get_Info_dm_phong(string maphong, string makhoaphong, string manhomphong);
        #endregion
        #region config
        BaseModel Insert_config(CONFIG objInfo);
        bool Update_config(CONFIG objInfo);
        bool Delete_config(CONFIG objInfo);
        DataTable Data_config(string id, string idConfig);
        DataTable Get_Data_config(DataGridView dtg, BindingNavigator bv, string id, string idConfig);
        DataTable Get_Data_config(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id, string idConfig);
        DataTable Get_Data_config(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string idConfig);
        CONFIG Get_Info_config(string id);
        #endregion

        #region dm_loaiimport
        BaseModel Insert_dm_loaiimport(DM_LOAIIMPORT objInfo);
        bool Update_dm_loaiimport(DM_LOAIIMPORT objInfo);
        bool Delete_dm_loaiimport(DM_LOAIIMPORT objInfo);
        DataTable Data_dm_loaiimport(string maimport);
        DataTable Get_Data_dm_loaiimport(DataGridView dtg, BindingNavigator bv, string maimport);
        DataTable Get_Data_dm_loaiimport(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maimport);
        DataTable Get_Data_dm_loaiimport(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maimport);
        DM_LOAIIMPORT Get_Info_dm_loaiimport(string maimport);
        BaseModel Insert_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo);
        bool Update_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo);
        bool Delete_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo);
        DataTable Data_dm_loaiimport_mapping(string maimport, string liscolumn);
        DataTable Get_Data_dm_loaiimport_mapping(DataGridView dtg, BindingNavigator bv, string maimport, string liscolumn);
        DataTable Get_Data_dm_loaiimport_mapping(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maimport, string liscolumn);
        DataTable Get_Data_dm_loaiimport_mapping(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maimport, string liscolumn);
        DM_LOAIIMPORT_MAPPING Get_Info_dm_loaiimport_mapping(string maimport, string liscolumn);
        List<DM_LOAIIMPORT_MAPPING> Get_ListInfo_dm_loaiimport_mapping(string maimport);

        #endregion
        #region dm_doituongbenhnhan
        int Insert_dm_doituongbenhnhan(DM_DOITUONGBENHNHAN objInfo);
        int Update_dm_doituongbenhnhan(DM_DOITUONGBENHNHAN objInfo);
        int Delete_dm_doituongbenhnhan(string madoituongbn);
        DataTable Data_dm_doituongbenhnhan(string madoituongbn);
        DM_DOITUONGBENHNHAN Get_Info_dm_doituongbenhnhan(DataRow drInfo);
        DM_DOITUONGBENHNHAN Get_Info_dm_doituongbenhnhan(string madoituongbn);
        bool CheckExists_dm_doituongbenhnhan(string madoituongbn);
        #endregion
        #region Ngôn ngữ
        BaseModel Insert_dm_ngonngu(DM_NGONNGU objInfo);
        bool Update_dm_ngonngu(DM_NGONNGU objInfo);
        bool Delete_dm_ngonngu(DM_NGONNGU objInfo);
        DataTable Data_dm_ngonngu(string idngonngu);
        DataTable Get_Data_dm_ngonngu(DataGridView dtg, BindingNavigator bv, string idngonngu);
        DataTable Get_Data_dm_ngonngu(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idngonngu);
        DataTable Get_Data_dm_ngonngu(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idngonngu);
        DM_NGONNGU Get_Info_dm_ngonngu(string idngonngu);

        BaseModel Insert_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo);
        bool Update_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo);
        bool Delete_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo);
        DataTable Data_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu);
        DataTable Get_Data_dm_ngonngu_danhmuc(DataGridView dtg, BindingNavigator bv, string iddanhmuc, string madanhmuc, string idngonngu);
        DataTable Get_Data_dm_ngonngu_danhmuc(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string iddanhmuc, string madanhmuc, string idngonngu);
        DataTable Get_Data_dm_ngonngu_danhmuc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string iddanhmuc, string madanhmuc, string idngonngu);
        DM_NGONNGU_DANHMUC Get_Info_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu);
        DataTable Data_DSDanhMuc_KhaiBaoNgonNgu(int idLoaiDanhMuc);
        #endregion
        #region dm_congtacvien
        int Insert_dm_congtacvien(DM_CONGTACVIEN objInfo);
        int Update_dm_congtacvien(DM_CONGTACVIEN objInfo);
        int Delete_dm_congtacvien(string macongtacvien);
        DataTable Data_dm_congtacvien(string macongtacvien);
        DM_CONGTACVIEN Get_Info_dm_congtacvien(DataRow drInfo);
        DM_CONGTACVIEN Get_Info_dm_congtacvien(string macongtacvien);
        bool CheckExists_dm_congtacvien(string macongtacvien);
        #endregion
        #region dm_sinhly
        int Insert_dm_sinhly(DM_SINHLY objInfo);
        int Update_dm_sinhly(DM_SINHLY objInfo);
        int Delete_dm_sinhly(string masinhly);
        DataTable Data_dm_sinhly(string masinhly);
        DM_SINHLY Get_Info_dm_sinhly(DataRow drInfo);
        DM_SINHLY Get_Info_dm_sinhly(string masinhly);
        bool CheckExists_dm_sinhly(string masinhly);
        #endregion
        #region DanhSachMayXetNghiem
        DataTable Data_DanhSachMayXetNghiem();
        #endregion
        #region dm_congty
        int Insert_dm_congty(DM_CONGTY objInfo);
        int Update_dm_congty(DM_CONGTY objInfo);
        int Delete_dm_congty(string macongty);
        DataTable Data_dm_congty(string macongty);
        DM_CONGTY Get_Info_dm_congty(DataRow drInfo);
        DM_CONGTY Get_Info_dm_congty(string macongty);
        bool CheckExists_dm_congty(string macongty);
        #endregion
        #region dm_khayluumau
        int Insert_dm_khayluumau(DM_KHAYLUUMAU objInfo);
        int Update_dm_khayluumau(DM_KHAYLUUMAU objInfo);
        int Delete_dm_khayluumau(string makhayluumau);
        DataTable Data_dm_khayluumau(string matuluumau, string makhayluumau);
        DM_KHAYLUUMAU Get_Info_dm_khayluumau(DataRow drInfo);
        DM_KHAYLUUMAU Get_Info_dm_khayluumau(string makhayluumau);
        bool CheckExists_dm_khayluumau(string makhayluumau);
        #endregion
        #region dm_tuluumau
        int Insert_dm_tuluumau(DM_TULUUMAU objInfo);
        int Update_dm_tuluumau(DM_TULUUMAU objInfo);
        int Delete_dm_tuluumau(string matuluu);
        DataTable Data_dm_tuluumau(string matuluu);
        DM_TULUUMAU Get_Info_dm_tuluumau(DataRow drInfo);
        DM_TULUUMAU Get_Info_dm_tuluumau(string matuluu);
        bool CheckExists_dm_tuluumau(string matuluu);
        #endregion
        #region dm_khuvuc_xnkhongthuchien
        int Insert_dm_khuvuc_xnkhongthuchien(DM_KHUVUC_XNKHONGTHUCHIEN objInfo);
        int Update_dm_khuvuc_xnkhongthuchien(DM_KHUVUC_XNKHONGTHUCHIEN objInfo);
        int Delete_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan, string Nguoixoa, string Pcxoa);
        DataTable Data_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan);
        DM_KHUVUC_XNKHONGTHUCHIEN Get_Info_dm_khuvuc_xnkhongthuchien(DataRow drInfo);
        DM_KHUVUC_XNKHONGTHUCHIEN Get_Info_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan);
        bool CheckExists_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan);
        #endregion
        #region DM diễn giải
        DataSet DanhMuc_Gen_ChaCon();
        int Insert_dm_diengiaketquagen(DM_DIENGIAKETQUAGEN objInfo);
        int Update_dm_diengiaketquagen(DM_DIENGIAKETQUAGEN objInfo);
        int Delete_dm_diengiaketquagen(int id);
        DataTable Data_dm_diengiaketquagen(int? id);
        DataTable Data_dm_diengiaketquagen_theoxetnghiem(string maXn);
        DM_DIENGIAKETQUAGEN Get_Info_dm_diengiaketquagen(DataRow drInfo);
        DM_DIENGIAKETQUAGEN Get_Info_dm_diengiaketquagen(int id);
        bool CheckExists_dm_diengiaketquagen(int id);
        #endregion
    }
}
