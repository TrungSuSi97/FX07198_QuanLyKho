using System;
using System.Data;
using System.Data.SqlClient;
using TPH.LIS.Analyzer.Model;
using TPH.LIS.Analyzer.Repositories;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.Analyzer.Services
{
    public class AnalyzerConfigService : IAnalyzerConfigService
    {
        private readonly IAnalyzerConfigRepository _iAnalyzerConfig = new AnalyzerConfigRepository();
        #region H_MAYXETNGHIEM
        public int Insert_Update_H_MAYXETNGHIEM(H_MAYXETNGHIEM objInfo, bool isUpdate)
        {
            return _iAnalyzerConfig.Insert_Update_H_MAYXETNGHIEM(objInfo, isUpdate);
        }
        public DataTable Data_h_mayxetnghiem(bool withEmpty = false, bool withZero = false, int loaiMay = -1)
        {
            return _iAnalyzerConfig.Data_h_mayxetnghiem(withEmpty, withZero, loaiMay);
        }
        public bool Delete_MayXetNghiem(H_MAYXETNGHIEM info)
        {
            return _iAnalyzerConfig.Delete_MayXetNghiem(info);
        }
        public DataTable Data_Loai_KetNoi()
        {
            return _iAnalyzerConfig.Data_Loai_KetNoi();
        }
        public DataTable DataDanhMucMayXN_GhepCode(string userAllow)
        {
            return _iAnalyzerConfig.DataDanhMucMayXN_GhepCode(userAllow);
        }
        #endregion
        #region H_BANGMAMAYXN
        public int Insert_h_bangmamayxn(H_BANGMAMAYXN objInfo)
        {
            return _iAnalyzerConfig.Insert_h_bangmamayxn(objInfo);
        }

        public int Update_h_bangmamayxn(H_BANGMAMAYXN objInfo)
        {

            return _iAnalyzerConfig.Update_h_bangmamayxn(objInfo);
        }

        public int Delete_h_bangmamayxn(int idmay, string maxn)
        {

            return _iAnalyzerConfig.Delete_h_bangmamayxn(idmay, maxn);
        }

        public DataTable Data_h_bangmamayxn(int idmay, string maxn)
        {

            return _iAnalyzerConfig.Data_h_bangmamayxn(idmay, maxn);
        }

        public H_BANGMAMAYXN Get_Info_h_bangmamayxn(DataRow drInfo)
        {

            return _iAnalyzerConfig.Get_Info_h_bangmamayxn(drInfo);
        }
        public H_BANGMAMAYXN Get_Info_h_bangmamayxn(int idmay, string maxn)
        {

            return _iAnalyzerConfig.Get_Info_h_bangmamayxn(idmay, maxn);
        }

        public bool CheckExists_h_bangmamayxn(int idmay, string maxn)
        {

            return _iAnalyzerConfig.CheckExists_h_bangmamayxn(idmay, maxn);
        }


        public DataTable Data_h_bangmamayxn_xetnghiem_forSelect(string idMay, string maXnMay, string maXn, string nhomXn)
        {
            return _iAnalyzerConfig.Data_h_bangmamayxn_xetnghiem_forSelect(idMay, maXnMay, maXn, nhomXn);
        }
        public DataTable Data_Status()
        {
            return _iAnalyzerConfig.Data_Status();
        }
 
        #endregion
        #region H_HOSTCONFIG
        public int Insert_Update_H_HOSTCONFIG(H_HOSTCONFIG objInfo, bool isUpdate)
        {
            return _iAnalyzerConfig.Insert_Update_H_HOSTCONFIG(objInfo, isUpdate);
        }
        public DataTable Data_h_hostconfig()
        {
            return _iAnalyzerConfig.Data_h_hostconfig();
        }
        #endregion
        #region H_KETQUAMAY
        public int Insert_Update_H_KETQUAMAY(H_KETQUAMAY objInfo, bool isUpdate)
        {
            return _iAnalyzerConfig.Insert_Update_H_KETQUAMAY(objInfo, isUpdate);
        }
        public DataTable Data_h_ketquamay()
        {
            return _iAnalyzerConfig.Data_h_ketquamay();
        }
        #endregion
        #region H_THONGTINKETQUAMAY
        public int Insert_Update_H_THONGTINKETQUAMAY(H_THONGTINKETQUAMAY objInfo, bool isUpdate)
        {
            return _iAnalyzerConfig.Insert_Update_H_THONGTINKETQUAMAY(objInfo, isUpdate);
        }
        public DataTable Data_h_thongtinketquamay()
        {
            return _iAnalyzerConfig.Data_h_thongtinketquamay();
        }
        #endregion
        #region chaymau_vitrimau
        public int Insert_ViTriChayMau_Plate(CHAYMAU_VITRIMAU objIn)
        {
            return _iAnalyzerConfig.Insert_ViTriChayMau_Plate(objIn);
        }
        public int Update_ViTriChayMau_Pos(CHAYMAU_VITRIMAU objIn)
        {
            return _iAnalyzerConfig.Update_ViTriChayMau_Pos(objIn);
        }
        public int Update_ViTriChayMau_Pos_Runtype(CHAYMAU_VITRIMAU objIn)
        {
            return _iAnalyzerConfig.Update_ViTriChayMau_Pos_Runtype(objIn);
        }
        public int Delete_ViTriChayMa_Plate(int idLantao)
        {
            return _iAnalyzerConfig.Delete_ViTriChayMa_Plate(idLantao);
        }
        public DataTable Data_VitriChayChaiMau_Plate(DateTime tuNgay, DateTime denNgay, int idMay, string maXn)
        {
            return _iAnalyzerConfig.Data_VitriChayChaiMau_Plate(tuNgay, denNgay, idMay, maXn);
        }
        public DataTable Data_ViTriChayMau_Pos(int id)
        {
            return _iAnalyzerConfig.Data_ViTriChayMau_Pos(id);
        }
        public int ViTriChayMau_IdLanTao()
        {
            return _iAnalyzerConfig.ViTriChayMau_IdLanTao();
        }
        public CHAYMAU_VITRIMAU GetInfo_VitriChayMua_Pos(int id)
        {
            return _iAnalyzerConfig.GetInfo_VitriChayMua_Pos(id);
        }
        public CHAYMAU_VITRIMAU GetInfo_VitriChayMua_Pos_ByRow(DataRow dr)
        {
            return _iAnalyzerConfig.GetInfo_VitriChayMua_Pos_ByRow(dr);
        }
        #endregion
        #region dm_maytinh_mayxetnghiem
        public int Insert_dm_maytinh_mayxetnghiem(DM_MAYTINH_MAYXETNGHIEM objInfo)
        {
            return _iAnalyzerConfig.Insert_dm_maytinh_mayxetnghiem(objInfo);
        }

        public int Delete_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {

            return _iAnalyzerConfig.Delete_dm_maytinh_mayxetnghiem(makhuvuc, tenmaytinh, idmayxetnghiem);
        }

        public DataTable Data_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {

            return _iAnalyzerConfig.Data_dm_maytinh_mayxetnghiem(makhuvuc, tenmaytinh, idmayxetnghiem);
        }

        public DM_MAYTINH_MAYXETNGHIEM Get_Info_dm_maytinh_mayxetnghiem(DataRow drInfo)
        {

            return _iAnalyzerConfig.Get_Info_dm_maytinh_mayxetnghiem(drInfo);
        }

        public DM_MAYTINH_MAYXETNGHIEM Get_Info_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {

            return _iAnalyzerConfig.Get_Info_dm_maytinh_mayxetnghiem(makhuvuc, tenmaytinh, idmayxetnghiem);
        }

        public bool CheckExists_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {

            return _iAnalyzerConfig.CheckExists_dm_maytinh_mayxetnghiem(makhuvuc, tenmaytinh, idmayxetnghiem);
        }

        #endregion
    }
}
