namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    using Data.HIS.Models;
    using System.Collections.Generic;
    using System.Data;

    public interface IGetHISDataAccessBase
    {
        HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns);
        DataTable DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable DanhMucCongTy(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        DataTable GetUploadKeyOfOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns);
        DataTable GetUploadKeyOfDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns);
        int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList);
    }
}
