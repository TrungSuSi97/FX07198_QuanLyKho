using System;
using System.Data;
using TPH.LIS.Data;

namespace TPH.LIS.App.AppCode
{
    class C_Ultilities
    {
        

        /// <summary>
        /// Hàm dùng để lấy ngày giờ hệ thống trên máy server
        /// </summary>
        /// <returns>Trả về DateTime</returns>
        public static DateTime ServerDate()
        {
            var dt = DataProvider.ExecuteScalar(CommandType.StoredProcedure, "selServerTime");
            DateTime svrDate = (DateTime)dt;
            return svrDate;
        }
    }
}
