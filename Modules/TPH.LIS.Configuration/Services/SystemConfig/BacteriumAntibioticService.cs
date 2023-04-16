using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Repositories.SystemConfig;

namespace TPH.LIS.Configuration.Services.SystemConfig
{
    public class BacteriumAntibioticService : IBacteriumAntibioticService
    {
        #region Bacterium

        private readonly IBacteriumAntibioticReposity _idm_xetnghiem_visinh_service;
        public BacteriumAntibioticService() : this(null) { }
        public BacteriumAntibioticService(BacteriumAntibioticReposity dm_xetnghiem_visinh_repository)
        {
            _idm_xetnghiem_visinh_service = dm_xetnghiem_visinh_repository ?? new BacteriumAntibioticReposity();
        }
        public bool Insert_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_vikhuan(objInfo);
        }
        public bool Update_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo, DM_XETNGHIEM_VIKHUAN objInfoOld)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_vikhuan(objInfo, objInfoOld);
        }
        public bool Delete_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_vikhuan(objInfo);
        }
        public DataTable Data_dm_xetnghiem_vikhuan(string maphanloai, string maPhanLoaiCaptren, string donViPhanLoai)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_vikhuan(maphanloai, maPhanLoaiCaptren, donViPhanLoai);
        }
        public DataTable Data_dm_xetnghiem_vikhuan_loai(string maphanloai, string maHoViKhuan)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_vikhuan_loai(maphanloai, maHoViKhuan);
        }
        public DataTable Data_dm_xetnghiem_vikhuan(string maphanloai)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_vikhuan(maphanloai);
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan(DataGridView dtg, BindingNavigator bv, string maphanloai)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_vikhuan(dtg, bv, maphanloai);
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string maphanloai)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_vikhuan(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, maphanloai);
        }
        public DM_XETNGHIEM_VIKHUAN Get_Info_dm_xetnghiem_vikhuan(DataRow drInfo)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_vikhuan(drInfo);
        }
        public DM_XETNGHIEM_VIKHUAN Get_Info_dm_xetnghiem_vikhuan(string maphanloai)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_vikhuan(maphanloai);
        }
        public DataTable Get_dm_xetnghiem_vikhuan_loai()
        {
            return _idm_xetnghiem_visinh_service.Get_dm_xetnghiem_vikhuan_loai();
        }


        #endregion
        #region Antibiotic

        public bool Insert_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_nhomkhangsinh(objInfo);
        }
        public bool Update_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo, DM_XETNGHIEM_NHOMKHANGSINH objInfoOld)
        {
            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_nhomkhangsinh(objInfo, objInfoOld);
        }
        public bool Delete_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_nhomkhangsinh(objInfo);
        }
        public DataTable Data_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_nhomkhangsinh(manhomkhangsinh);
        }
        public DataTable Get_Data_dm_xetnghiem_nhomkhangsinh(DataGridView dtg, BindingNavigator bv, string manhomkhangsinh)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_nhomkhangsinh(dtg, bv, manhomkhangsinh);
        }
        public DataTable Get_Data_dm_xetnghiem_nhomkhangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string manhomkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_nhomkhangsinh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, manhomkhangsinh);
        }
        public DM_XETNGHIEM_NHOMKHANGSINH Get_Info_dm_xetnghiem_nhomkhangsinh(DataRow drInfo)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_nhomkhangsinh(drInfo);
        }
        public DM_XETNGHIEM_NHOMKHANGSINH Get_Info_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_nhomkhangsinh(manhomkhangsinh);
        }
        public bool Insert_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_khangsinh(objInfo);
        }
        public bool Update_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo, DM_XETNGHIEM_KHANGSINH objInfoOld)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_khangsinh(objInfo, objInfoOld);
        }
        public bool Delete_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_khangsinh(objInfo);
        }
        public DataTable Data_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_khangsinh(makhangsinh, manhomkhangsinh);
        }
        public DataTable Get_Data_dm_xetnghiem_khangsinh(DataGridView dtg, BindingNavigator bv, string makhangsinh, string manhomkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khangsinh(dtg, bv, makhangsinh, manhomkhangsinh);
        }
        public DataTable Get_Data_dm_xetnghiem_khangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string makhangsinh, string manhomkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khangsinh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, makhangsinh, manhomkhangsinh);
        }
        public DM_XETNGHIEM_KHANGSINH Get_Info_dm_xetnghiem_khangsinh(DataRow drInfo)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_khangsinh(drInfo);
        }
        public DM_XETNGHIEM_KHANGSINH Get_Info_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh, string guideLineType, string potency)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_khangsinh(makhangsinh, manhomkhangsinh, guideLineType, potency);
        }
        #endregion
        #region Bacterium-Antibiotic
        public bool Insert_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_vikhuan_khangsinh(objInfo);
        }
        public bool Update_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_vikhuan_khangsinh(objInfo);
        }
        public bool Delete_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_vikhuan_khangsinh(objInfo);
        }

        public DataTable Get_DM_Site_INF()
        {
            return _idm_xetnghiem_visinh_service.Get_DM_Site_INF();
        }

        public DataTable Data_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_vikhuan_khangsinh(mavikhuan, makhangsinh, kythuat);
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan_khangsinh(DataGridView dtg, BindingNavigator bv, string mavikhuan, string makhangsinh, string kythuat)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_vikhuan_khangsinh(dtg, bv, mavikhuan, makhangsinh, kythuat);
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan_khangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName
            , string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mavikhuan, string makhangsinh, string kythuat)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_vikhuan_khangsinh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth
                , txt, LinkColumnIndex, mavikhuan, makhangsinh, kythuat);
        }
        public DM_XETNGHIEM_VIKHUAN_KHANGSINH Get_Info_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat)
        {
            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_vikhuan_khangsinh(mavikhuan, makhangsinh, kythuat);
        }
        #endregion
        #region DaiThe
        //danh mục khảo sát đại thể
        public bool Insert_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_khaosatdaithe(objInfo);
        }
        public bool Update_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo, DM_XETNGHIEM_KHAOSATDAITHE objInfoOld)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_khaosatdaithe(objInfo, objInfoOld);
        }
        public bool Delete_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_khaosatdaithe(objInfo);
        }
        public DataTable Data_dm_xetnghiem_khaosatdaithe(string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_khaosatdaithe(makhaosat);
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe(DataGridView dtg, BindingNavigator bv, string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khaosatdaithe(dtg, bv, makhaosat);
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khaosatdaithe(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, makhaosat);
        }
        public DM_XETNGHIEM_KHAOSATDAITHE Get_Info_dm_xetnghiem_khaosatdaithe(string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_khaosatdaithe(makhaosat);
        }

        //danh mục kết quả khảo sát
        public bool Insert_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_khaosatdaithe_ketqua(objInfo);
        }
        public bool Update_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo, DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfoOld)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_khaosatdaithe_ketqua(objInfo, objInfoOld);
        }
        public bool Delete_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_khaosatdaithe_ketqua(objInfo);
        }
        public DataTable Data_dm_xetnghiem_khaosatdaithe_ketqua(string autoid, string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_khaosatdaithe_ketqua(autoid, makhaosat);
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(DataGridView dtg, BindingNavigator bv, string autoid, string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(dtg, bv, autoid, makhaosat);
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn
            , string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string autoid, string makhaosat)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(cbo, _ValueColumn, _DisplayColumn
                , ColumnsName, ColumnsWidth, txt, LinkColumnIndex, autoid, makhaosat);
        }
        public DM_XETNGHIEM_KHAOSATDAITHE_KETQUA Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(string autoid)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(autoid);
        }


        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_khangsinh_bo_chitiet
        public BaseModel Insert_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
        }

        public bool Update_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
        }

        public bool Delete_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
        }

        public DataTable Data_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh);
        }

        public DataTable Data_dm_xetnghiem_khangsinh_bo_chitiet(string mavikhuan)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_khangsinh_bo_chitiet(mavikhuan);
        }

        public DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(DataGridView dtg, BindingNavigator bv, string mabokhangsinh, string makhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(dtg, bv, mabokhangsinh, makhangsinh);
        }

        public DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabokhangsinh, string makhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(dtg, bv, ref sqlDataAdapter, ref dtData, mabokhangsinh, makhangsinh);
        }

        public DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabokhangsinh, string makhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, mabokhangsinh, makhangsinh);
        }

        public DM_XETNGHIEM_KHANGSINH_BO_CHITIET Get_Info_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh);
        }
        #endregion
        #region dm_xetnghiem_visinh_bo
        public BaseModel Insert_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_visinh_bo(objInfo);
        }

        public bool Update_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo)
        {
            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_visinh_bo(objInfo);
        }

        public bool Delete_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo)
        {
            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_visinh_bo(objInfo);
        }

        public DataTable Data_dm_xetnghiem_visinh_bo(string mabokhangsinh)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_visinh_bo(mabokhangsinh);
        }

        public DataTable Data_dm_xetnghiem_visinh_bo_by_mvk(string mavikhuan)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_visinh_bo_by_mvk(mavikhuan);
        }

        public DataTable Get_Data_dm_xetnghiem_visinh_bo(DataGridView dtg, BindingNavigator bv, string mabokhangsinh)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_visinh_bo(dtg, bv, mabokhangsinh);
        }

        public DataTable Get_Data_dm_xetnghiem_visinh_bo(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabokhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_visinh_bo(dtg, bv, ref sqlDataAdapter, ref dtData, mabokhangsinh);
        }

        public DataTable Get_Data_dm_xetnghiem_visinh_bo(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabokhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_visinh_bo(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, mabokhangsinh);
        }

        public DM_XETNGHIEM_VISINH_BO Get_Info_dm_xetnghiem_visinh_bo(string mabokhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_visinh_bo(mabokhangsinh);
        }

        public DataTable Get_Info_KS_KSD(string maViKhuan, string maKhangSinh, string kyThuat, string guideLine, string potency, string guideLineType)
        {
            return _idm_xetnghiem_visinh_service.Get_Info_KS_KSD(maViKhuan, maKhangSinh, kyThuat, guideLine, potency, guideLineType);
        }

        public DataTable Get_F_Info_KS_KSD_MaBoKhangSinh_MaViKhuan(string maBoKhangSinh, string maViKhuan)
        {
            return _idm_xetnghiem_visinh_service.Get_F_Info_KS_KSD_MaBoKhangSinh_MaViKhuan(maBoKhangSinh, maViKhuan);
        }
        #endregion
        #region dm_xetnghiem_khangkhangsinh
        public BaseModel Insert_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_khangkhangsinh(objInfo);
        }

        public bool Update_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_khangkhangsinh(objInfo);
        }

        public bool Delete_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_khangkhangsinh(objInfo);
        }

        public DataTable Data_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_khangkhangsinh(makhangkhangsinh);
        }

        public DataTable Get_Data_dm_xetnghiem_khangkhangsinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string makhangkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_khangkhangsinh(dtg, bv, ref sqlDataAdapter, ref dtData, makhangkhangsinh);
        }

        public DM_XETNGHIEM_KHANGKHANGSINH Get_Info_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_khangkhangsinh(makhangkhangsinh);
        }
        #endregion
        //================================|||=====================================
        #region Danh mục mapping
        public DataTable Data_ViKhuan_ChuaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_ViKhuan_ChuaMapping(idMayXN);
        }
        public DataTable Data_ViKhuan_DaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_ViKhuan_DaMapping(idMayXN);
        }
        public int Insert_ViKhuan_Mapping(int idMayXN, string maVikhuan)
        {
            return _idm_xetnghiem_visinh_service.Insert_ViKhuan_Mapping(idMayXN, maVikhuan);
        }
        public int Update_ViKhuan_Mapping(int idMayXN, string maVikhuan, string maViKhuanMay)
        {
            return _idm_xetnghiem_visinh_service.Update_ViKhuan_Mapping(idMayXN, maVikhuan, maViKhuanMay);
        }
        public int Delete_ViKhuan_Mapping(int idMayXN, string maVikhuan, string maViKhuanMay)
        {
            return _idm_xetnghiem_visinh_service.Delete_ViKhuan_Mapping(idMayXN, maVikhuan, maViKhuanMay);
        }
        public DataTable Data_KhangSinh_ChuaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_KhangSinh_ChuaMapping(idMayXN);
        }
        public DataTable Data_KhangSinh_DaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_KhangSinh_DaMapping(idMayXN);
        }
        public int Insert_KhangSinh_Mapping(int idMayXN, string maKhangSinh)
        {
            return _idm_xetnghiem_visinh_service.Insert_KhangSinh_Mapping(idMayXN, maKhangSinh);
        }
        public int Update_KhangSinh_Mapping(int idMayXN, string maKhangSinh, string maKhangSinhMay, string SiteINF, int autoID)
        {
            return _idm_xetnghiem_visinh_service.Update_KhangSinh_Mapping(idMayXN, maKhangSinh, maKhangSinhMay, SiteINF, autoID);
        }
        public int Delete_KhangSinh_Mapping(int autoID)
        {
            return _idm_xetnghiem_visinh_service.Delete_KhangSinh_Mapping(autoID);
        }

        //Khang Khang Sinh
        public DataTable Data_KhangKhangSinh_ChuaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_KhangKhangSinh_ChuaMapping(idMayXN);
        }
        public DataTable Data_KhangKhangSinh_DaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_KhangKhangSinh_DaMapping(idMayXN);
        }
        public int Insert_KhangKhangSinh_Mapping(int idMayXN, string maKhangKhangSinh)
        {
            return _idm_xetnghiem_visinh_service.Insert_KhangKhangSinh_Mapping(idMayXN, maKhangKhangSinh);
        }
        public int Update_KhangKhangSinh_Mapping(int idMayXN, string maKhangKhangSinh, string maKhangKhangSinhMay, int autoID)
        {
            return _idm_xetnghiem_visinh_service.Update_KhangKhangSinh_Mapping(idMayXN, maKhangKhangSinh, maKhangKhangSinhMay, autoID);
        }
        public int Delete_KhangKhangSinh_Mapping(int autoID)
        {
            return _idm_xetnghiem_visinh_service.Delete_KhangKhangSinh_Mapping(autoID);
        }

        public DataTable Data_ChiDinh_DaMapping(int idMayXN)
        {
            return _idm_xetnghiem_visinh_service.Data_ChiDinh_DaMapping(idMayXN);
        }
        public int Insert_ChiDinh_Mapping(int idMayXN, string maChiDinh, string maLoaiMau)
        {
            return _idm_xetnghiem_visinh_service.Insert_ChiDinh_Mapping(idMayXN, maChiDinh, maLoaiMau);
        }
        public int Update_ChiDinh_Mapping(H_VISINH_BANGMAYEUCAUMAYXN obj)
        {
            return _idm_xetnghiem_visinh_service.Update_ChiDinh_Mapping(obj);
        }
        public int Delete_ChiDinh_Mapping(int id)
        {
            return _idm_xetnghiem_visinh_service.Delete_ChiDinh_Mapping(id);
        }
        #endregion
        #region dm_visinh_maunhapnhanh
        public BaseModel Insert_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_visinh_maunhapnhanh(objInfo);
        }

        public bool Update_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Update_dm_visinh_maunhapnhanh(objInfo);
        }

        public bool Delete_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Delete_dm_visinh_maunhapnhanh(objInfo);
        }

        public DataTable Data_dm_visinh_maunhapnhanh(string id)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_visinh_maunhapnhanh(id);
        }

        public DataTable Get_Data_dm_visinh_maunhapnhanh(DataGridView dtg, BindingNavigator bv, string id)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_visinh_maunhapnhanh(dtg, bv, id);
        }

        public DataTable Get_Data_dm_visinh_maunhapnhanh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_visinh_maunhapnhanh(dtg, bv, ref sqlDataAdapter, ref dtData, id);
        }



        public DataTable Get_Data_dm_visinh_maunhapnhanh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id)
        {
            return _idm_xetnghiem_visinh_service.Get_Data_dm_visinh_maunhapnhanh(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, id);
        }

        public DM_VISINH_MAUNHAPNHANH Get_Info_dm_visinh_maunhapnhanh(string id)
        {
            return _idm_xetnghiem_visinh_service.Get_Info_dm_visinh_maunhapnhanh(id);
        }
        #endregion

        public BaseModel Insert_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_visinh_quitrinh(objInfo);
        }

        public bool Update_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Update_dm_visinh_quitrinh(objInfo);
        }

        public bool Delete_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo)
        {
            return _idm_xetnghiem_visinh_service.Delete_dm_visinh_quitrinh(objInfo);
        }

        public DataTable Data_dm_visinh_quitrinh(string maKhangsinh, string kyThuat, string idMay)
        {
            return _idm_xetnghiem_visinh_service.Data_dm_visinh_quitrinh(maKhangsinh, kyThuat, idMay);
        }
        #region dm_xetnghiem_visinh_quytrinh_loaimau
        public BaseModel Insert_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo)
        {
            return _idm_xetnghiem_visinh_service.Insert_dm_xetnghiem_visinh_quytrinh_loaimau(objInfo);
        }

        public bool Update_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo)
        {

            return _idm_xetnghiem_visinh_service.Update_dm_xetnghiem_visinh_quytrinh_loaimau(objInfo);
        }

        public bool Delete_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo)
        {

            return _idm_xetnghiem_visinh_service.Delete_dm_xetnghiem_visinh_quytrinh_loaimau(objInfo);
        }

        public DataTable Data_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn)
        {

            return _idm_xetnghiem_visinh_service.Data_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn);
        }

        public DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(DataGridView dtg, BindingNavigator bv, string maloaimau, string idmayxn)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(dtg, bv, maloaimau, idmayxn);
        }

        public DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maloaimau, string idmayxn)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(dtg, bv, ref sqlDataAdapter, ref dtData, maloaimau, idmayxn);
        }

        public DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maloaimau, string idmayxn)
        {

            return _idm_xetnghiem_visinh_service.Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, maloaimau, idmayxn);
        }

        public DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU Get_Info_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn)
        {

            return _idm_xetnghiem_visinh_service.Get_Info_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn);
        }
        #endregion
    }
}
