using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.Configuration.Services.SystemConfig
{
    public interface IBacteriumAntibioticService
    {
        #region Bacterium
        bool Insert_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo);
        bool Update_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo, DM_XETNGHIEM_VIKHUAN objInfoOld);
        bool Delete_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo);
        DataTable Data_dm_xetnghiem_vikhuan(string maphanloai, string maPhanLoaiCaptren, string donViPhanLoai);
        DataTable Data_dm_xetnghiem_vikhuan(string maphanloai);
        DataTable Data_dm_xetnghiem_vikhuan_loai(string maphanloai, string maHoViKhuan);
        DataTable Get_Data_dm_xetnghiem_vikhuan(DataGridView dtg, BindingNavigator bv, string maphanloai);
        DataTable Get_Data_dm_xetnghiem_vikhuan(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string maphanloai);
        DM_XETNGHIEM_VIKHUAN Get_Info_dm_xetnghiem_vikhuan(DataRow drInfo);
        DM_XETNGHIEM_VIKHUAN Get_Info_dm_xetnghiem_vikhuan(string maphanloai);
        DataTable Get_dm_xetnghiem_vikhuan_loai();
        #endregion
        #region Antibiotic
        bool Insert_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo);
        bool Update_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo, DM_XETNGHIEM_NHOMKHANGSINH objInfoOld);
        bool Delete_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo);
        DataTable Data_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh);
        DataTable Get_Data_dm_xetnghiem_nhomkhangsinh(DataGridView dtg, BindingNavigator bv, string manhomkhangsinh);
        DataTable Get_Data_dm_xetnghiem_nhomkhangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string manhomkhangsinh);
        DM_XETNGHIEM_NHOMKHANGSINH Get_Info_dm_xetnghiem_nhomkhangsinh(DataRow drInfo);
        DM_XETNGHIEM_NHOMKHANGSINH Get_Info_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh);

        bool Insert_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo);
        bool Update_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo, DM_XETNGHIEM_KHANGSINH objInfoOld);
        bool Delete_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo);
        DataTable Data_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh);
        DataTable Get_Data_dm_xetnghiem_khangsinh(DataGridView dtg, BindingNavigator bv, string makhangsinh, string manhomkhangsinh);
        DataTable Get_Data_dm_xetnghiem_khangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string makhangsinh, string manhomkhangsinh);
        DM_XETNGHIEM_KHANGSINH Get_Info_dm_xetnghiem_khangsinh(DataRow drInfo);
        DM_XETNGHIEM_KHANGSINH Get_Info_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh, string guideLineType, string potency);
        #endregion
        #region Bacterium-Antibiotic
        bool Insert_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo);
        bool Update_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo);
        bool Delete_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo);
        DataTable Get_DM_Site_INF();
        DataTable Data_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat);
        DataTable Get_Data_dm_xetnghiem_vikhuan_khangsinh(DataGridView dtg, BindingNavigator bv, string mavikhuan, string makhangsinh, string kythuat);
        DataTable Get_Data_dm_xetnghiem_vikhuan_khangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName
            , string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mavikhuan, string makhangsinh, string kythuat);
        DM_XETNGHIEM_VIKHUAN_KHANGSINH Get_Info_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat);
        #endregion
        #region DaiThe
        bool Insert_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo);
        bool Update_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo, DM_XETNGHIEM_KHAOSATDAITHE objInfoOld);
        bool Delete_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo);
        DataTable Data_dm_xetnghiem_khaosatdaithe(string makhaosat);
        DataTable Get_Data_dm_xetnghiem_khaosatdaithe(DataGridView dtg, BindingNavigator bv, string makhaosat);
        DataTable Get_Data_dm_xetnghiem_khaosatdaithe(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string makhaosat);
        DM_XETNGHIEM_KHAOSATDAITHE Get_Info_dm_xetnghiem_khaosatdaithe(string makhaosat);

        bool Insert_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo);
        bool Update_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo, DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfoOld);
        bool Delete_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo);
        DataTable Data_dm_xetnghiem_khaosatdaithe_ketqua(string autoid, string makhaosat);
        DataTable Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(DataGridView dtg, BindingNavigator bv, string autoid, string makhaosat);
        DataTable Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string autoid, string makhaosat);
        DM_XETNGHIEM_KHAOSATDAITHE_KETQUA Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(string autoid);


        #endregion
        #region dm_xetnghiem_khangsinh_bo_chitiet
        //================================|||=====================================
        BaseModel Insert_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo);
        bool Update_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo);
        bool Delete_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo);
        DataTable Data_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh);
        DataTable Data_dm_xetnghiem_khangsinh_bo_chitiet(string mavikhuan);
        DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(DataGridView dtg, BindingNavigator bv, string mabokhangsinh, string makhangsinh);
        DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabokhangsinh, string makhangsinh);
        DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabokhangsinh, string makhangsinh);
        DM_XETNGHIEM_KHANGSINH_BO_CHITIET Get_Info_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh);
        #endregion
        #region dm_xetnghiem_visinh_bo
        BaseModel Insert_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo);
        bool Update_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo);
        bool Delete_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo);
        DataTable Data_dm_xetnghiem_visinh_bo(string mabokhangsinh);
        DataTable Data_dm_xetnghiem_visinh_bo_by_mvk(string mavikhuan);

        DataTable Get_Data_dm_xetnghiem_visinh_bo(DataGridView dtg, BindingNavigator bv, string mabokhangsinh);
        DataTable Get_Data_dm_xetnghiem_visinh_bo(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabokhangsinh);
        DataTable Get_Data_dm_xetnghiem_visinh_bo(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabokhangsinh);
        DM_XETNGHIEM_VISINH_BO Get_Info_dm_xetnghiem_visinh_bo(string mabokhangsinh);
        DataTable Get_Info_KS_KSD(string maViKhuan, string maKhangSinh, string kyThuat, string guideLine, string potency, string guideLineType);
        DataTable Get_F_Info_KS_KSD_MaBoKhangSinh_MaViKhuan(string maBoKhangSinh, string maViKhuan);
        #endregion
        #region dm_xetnghiem_khangkhangsinh
        BaseModel Insert_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo);
        bool Update_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo);
        bool Delete_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo);
        DataTable Data_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh);
        DataTable Get_Data_dm_xetnghiem_khangkhangsinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string makhangkhangsinh);
        DM_XETNGHIEM_KHANGKHANGSINH Get_Info_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh);
        #endregion
        #region Danh mục mapping
        DataTable Data_ViKhuan_ChuaMapping(int idMayXN);
        DataTable Data_ViKhuan_DaMapping(int idMayXN);
        int Insert_ViKhuan_Mapping(int idMayXN, string maVikhuan);
        int Update_ViKhuan_Mapping(int idMayXN, string maVikhuan, string maViKhuanMay);
        int Delete_ViKhuan_Mapping(int idMayXN, string maVikhuan, string maViKhuanMay);
        DataTable Data_KhangSinh_ChuaMapping(int idMayXN);
        DataTable Data_KhangSinh_DaMapping(int idMayXN);
        int Insert_KhangSinh_Mapping(int idMayXN, string maKhangSinh);
        int Update_KhangSinh_Mapping(int idMayXN, string maKhangSinh, string maKhangSinhMay, string SiteINF, int autoID);
        int Delete_KhangSinh_Mapping(int autoID);
        //Khang Khang Sinh
        DataTable Data_KhangKhangSinh_ChuaMapping(int idMayXN);
        DataTable Data_KhangKhangSinh_DaMapping(int idMayXN);
        int Insert_KhangKhangSinh_Mapping(int idMayXN, string maKhangKhangSinh);
        int Update_KhangKhangSinh_Mapping(int idMayXN, string maKhangKhangSinh, string maKhangKhangSinhMay, int autoID);
        int Delete_KhangKhangSinh_Mapping(int autoID);

        DataTable Data_ChiDinh_DaMapping(int idMayXN);
        int Insert_ChiDinh_Mapping(int idMayXN, string maChiDinh, string maLoaiMau);
        int Update_ChiDinh_Mapping(H_VISINH_BANGMAYEUCAUMAYXN obj);
        int Delete_ChiDinh_Mapping(int id);
        #endregion
        #region dm_visinh_maunhapnhanh
        BaseModel Insert_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo);
        bool Update_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo);
        bool Delete_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo);
        DataTable Data_dm_visinh_maunhapnhanh(string id);
        DataTable Get_Data_dm_visinh_maunhapnhanh(DataGridView dtg, BindingNavigator bv, string id);
        DataTable Get_Data_dm_visinh_maunhapnhanh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id);
        DataTable Get_Data_dm_visinh_maunhapnhanh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id);
        DM_VISINH_MAUNHAPNHANH Get_Info_dm_visinh_maunhapnhanh(string id);
        #endregion

        BaseModel Insert_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo);
        bool Update_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo);
        bool Delete_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo);
        DataTable Data_dm_visinh_quitrinh(string maKhangsinh, string kyThuat, string idMay);
        #region dm_xetnghiem_visinh_quytrinh_loaimau
        BaseModel Insert_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo);
        bool Update_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo);
        bool Delete_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo);
        DataTable Data_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn);
        DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(DataGridView dtg, BindingNavigator bv, string maloaimau, string idmayxn);
        DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maloaimau, string idmayxn);
        DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maloaimau, string idmayxn);
        DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU Get_Info_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn);
        #endregion

    }
}
