using System.Collections.Generic;
using System.Data;
using System.Linq;
using TPH.Data.HIS.Models;

namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    partial class GetHISDataAccess_FPT_SP : IGetHISDataAccess_FPT_SP
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
        public DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientOrderedList(hisConnect, hisFunction, paraInfo);
        }
        public DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfo);
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
