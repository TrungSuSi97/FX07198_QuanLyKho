using System;
using System.Data;
using System.Data.SqlClient;
using TPH.Common.Converter;
using TPH.Data;
using TPH.HIS.WebAPI.Extensions;
using TPH.HIS.WebAPI.Models;
using TPH.HIS.WebAPI.Models.Logs;
using TPH.LIS.Data;
using TPH.WriteLog;

namespace TPH.HIS.WebAPI.DataAccess.Impl
{
    public class LogDataAccessImpl: ILogDataAccess
    {
        public DataTable GetHisTracking(LogFilter filter)
        {
            try
            {
                var logs = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selHisTracking", new SqlParameter[]
                {
                    new SqlParameter("@fromDate", DateConverterHelper.ToDateTime(filter.LogDate, "dd/MM/yyyy")),
                    new SqlParameter("@filter", StringConverter.ToString(filter.Filter))
                });

                if (logs != null && logs.Tables.Count > 0)
                {
                    return logs.Tables[0];
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogError(string.Empty, "HISTracking_SelectLog", ex);
            }

            return new DataTable();
        }

        public BaseResult InsertHisTracking(LogMessageModel message)
        {
            try
            {
                DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insHisTracking", new SqlParameter[]
                {
                    new SqlParameter("@action", StringConverter.ToString(message.Action)),
                    new SqlParameter("@inputMsg", StringConverter.ToString(message.InputMessage)),
                    new SqlParameter("@outputMsg", StringConverter.ToString(message.OutputMessage)),
                    new SqlParameter("@errorMsg", StringConverter.ToString(message.ErrorMessage)),
                    new SqlParameter("@username", StringConverter.ToString(message.Username)),
                    new SqlParameter("@ip", message.Ip)
                });
            }
            catch (Exception ex)
            {
                LogService.RecordLogError(string.Empty, "HISTracking_InsertLog", ex);
            }

            return new BaseResult();
        }
    }
}