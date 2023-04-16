using System.Collections.Generic;
using System.Data;
using System.Linq;
using TPH.Data.HIS.Models;

namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    partial class GetHISDataAccess_MSSQLTrungGian : IGetHISDataAccess_MSSQLTrungGian
    {
        private IGetHISDataAccessBase _iHisAccessBase = new GetHISDataAccessBase();
        public HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            var function = from item in hisColumns
                           where item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
                return function.FirstOrDefault();
            return null;
        }
        public DataTable DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucBacSi(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucChanDoan(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucDoiTuong(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucKhoaPhong(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucXetNghiem(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucMayXN(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucCongTy(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucCongTy(hisConnect, hisFunction, null);
        }
        public DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientOrderedList(hisConnect, hisFunction, paraInfo);
        }
        public DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfo);
        }
        public DataTable GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientInformationDetail(hisConnect, hisFunction, paraInfo);
        }
        public DataTable GetUploadKeyOfOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns)
        {
            return _iHisAccessBase.GetUploadKeyOfOrder(hisConnect, hisFunction, paraInfo, ref SelectedColumns);
        }
        public DataTable GetUploadKeyOfDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns)
        {
            return _iHisAccessBase.GetUploadKeyOfDetail(hisConnect, hisFunction, paraInfo, ref SelectedColumns);
        }

        public int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisAccessBase.LISCheck(hisConnect, hisFunction, paraInfoList);
        }
        public int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList)
        {
            return _iHisAccessBase.TransferResultToHIS(hisConnect, hisFunction, paraInfoList);
        }
    }
}
