using System.Collections.Generic;
using System.Data;
using TPH.Data.HIS.Models;

namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    interface IGetHISDataAccess_MSSQLTrungGian
    {
        HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns);
        DataTable DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable DanhMucCongTy(HisConnection hisConnect, List<HisFunctionConfig> hisFunction);
        DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo);
        DataTable GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList);
        DataTable GetUploadKeyOfOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns);
        DataTable GetUploadKeyOfDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns);
        int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList);
        int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList);
    }
}
