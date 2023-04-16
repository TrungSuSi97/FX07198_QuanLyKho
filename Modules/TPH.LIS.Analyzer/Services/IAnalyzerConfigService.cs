using System;
using System.Data;
using System.Data.SqlClient;
using TPH.LIS.Analyzer.Model;

namespace TPH.LIS.Analyzer.Services
{
    public interface IAnalyzerConfigService
    {
        #region H_MAYXETNGHIEM
        int Insert_Update_H_MAYXETNGHIEM(H_MAYXETNGHIEM objInfo, bool isUpdate);
        DataTable Data_h_mayxetnghiem(bool withEmpty = false, bool withZero = false, int loaiMay = -1);
        bool Delete_MayXetNghiem(H_MAYXETNGHIEM info);
        DataTable Data_Loai_KetNoi();
        DataTable DataDanhMucMayXN_GhepCode(string userAllow);
        #endregion
        #region H_BANGMAMAYXN
        int Insert_h_bangmamayxn(H_BANGMAMAYXN objInfo);
        int Update_h_bangmamayxn(H_BANGMAMAYXN objInfo);
        int Delete_h_bangmamayxn(int idmay, string maxn);
        DataTable Data_h_bangmamayxn(int idmay, string maxn);
        H_BANGMAMAYXN Get_Info_h_bangmamayxn(DataRow drInfo);
        H_BANGMAMAYXN Get_Info_h_bangmamayxn(int idmay, string maxn);
        bool CheckExists_h_bangmamayxn(int idmay, string maxn);
        DataTable Data_h_bangmamayxn_xetnghiem_forSelect(string idMay, string maXnMay, string maXn, string nhomXn);
        DataTable Data_Status();
        #endregion
        #region H_HOSTCONFIG
        int Insert_Update_H_HOSTCONFIG(H_HOSTCONFIG objInfo, bool isUpdate);
        DataTable Data_h_hostconfig();
        #endregion
        #region H_KETQUAMAY
        int Insert_Update_H_KETQUAMAY(H_KETQUAMAY objInfo, bool isUpdate);
        DataTable Data_h_ketquamay();
        #endregion
        #region H_THONGTINKETQUAMAY
        int Insert_Update_H_THONGTINKETQUAMAY(H_THONGTINKETQUAMAY objInfo, bool isUpdate);
        DataTable Data_h_thongtinketquamay();
        #endregion
        #region chaymau_vitrimau
        int Insert_ViTriChayMau_Plate(CHAYMAU_VITRIMAU objIn);
        int Update_ViTriChayMau_Pos(CHAYMAU_VITRIMAU objIn);
        int Update_ViTriChayMau_Pos_Runtype(CHAYMAU_VITRIMAU objIn);
        int Delete_ViTriChayMa_Plate(int idLantao);
        DataTable Data_VitriChayChaiMau_Plate(DateTime tuNgay, DateTime denNgay, int idMay, string maXn);
        DataTable Data_ViTriChayMau_Pos(int id);
        int ViTriChayMau_IdLanTao();
        CHAYMAU_VITRIMAU GetInfo_VitriChayMua_Pos(int id);
        CHAYMAU_VITRIMAU GetInfo_VitriChayMua_Pos_ByRow(DataRow dr);
        #endregion
        #region dm_maytinh_mayxetnghiem
        int Insert_dm_maytinh_mayxetnghiem(DM_MAYTINH_MAYXETNGHIEM objInfo);
        int Delete_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem);
        DataTable Data_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem);
        DM_MAYTINH_MAYXETNGHIEM Get_Info_dm_maytinh_mayxetnghiem(DataRow drInfo);
        DM_MAYTINH_MAYXETNGHIEM Get_Info_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem);
        bool CheckExists_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem);
        #endregion
    }
}
