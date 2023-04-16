using System.Data;
using TPH.LIS.Data;

namespace TPH.LIS.Patient.Repositories.TestMethod
{
    public class TestMethodRepository : ITestMethodRepository
    {
        public void UpdatePrintedInfoOfTestResult(string reciverCode, string userId)
        {
            var sqlQuery = "update BenhNhan_CLS_XetNghiem set DaInKQXN = 1 , ThoiGianInXN = getdate(), UserInXN='" +
                userId + "',LanInXN = LanInXN + 1 where MaTiepNhan = '" + reciverCode + "'";

            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void UpdatePrintedInfoOfXRayResult(string reciverCode, string userId)
        {
            var sqlQuery = "update BenhNhan_CLS_XQuang set ThoiGianInXQuang = getdate(), UserInXQuang='" +
                userId + "',LanInXQuang = LanInXQuang + 1, DaInKQXQuang = 1 where MaTiepNhan = '" + reciverCode + "'";

            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }

        public void UpdatePrintedInfoOfSupersonicResult(string reciverCode, string userId, string color)
        {
            var sqlQuery = " update BenhNhan_CLS_SieuAm set ThoiGianInSieuAm = getdate(), UserInSieuAm='" + 
                userId + "',LanInSieuAm = LanInSieuAm + 1, DaInKQSieuAm = (case when (select count(*) from KetQua_CLS_SieuAm where  MaTiepNhan = '" +
                reciverCode + "' and MaSoMau='" +  color + "' and DaInKQ = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + reciverCode + "'";
            
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
    }
}
