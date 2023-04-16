namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    using Data.HIS.Models;
    using System.Collections.Generic;
    using System.Data;

    public interface IGetHISDataAccess_DHHospital
    {
        HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns);
        DataTable DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList);
    }
}
