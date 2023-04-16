using System;
using TPH.HIS.WebAPI.DataAccess;
using TPH.HIS.WebAPI.DataAccess.Impl;
using TPH.HIS.WebAPI.Models.Logs;
using TPH.WriteLog;

namespace TPH.HIS.WebAPI.Extensions
{
    public class LogExtension
    {
        private const string ErrorLogFileName = @"_Logs\{0:yyyyMMdd}\TPH.ERR_{1}_{0:yyyyMMdd}.log";
        private const string InfoLogFileName = @"_Logs\{0:yyyyMMdd}\TPH.API_{1}_{0:yyyyMMdd}.log";
        private static string _defaultErrorFolder = "Logs";
        private static string _defaultFileName = "Logs_";
        private static string _fileDateFormatDdMMyy = "ddMMyy";
        private static string _longDateTimeFormatYyyyMMddHHmmss = "yyyy-MM-dd HH:mm:ss";
        private static string _fileDateFormatDdMMyyHHmmss = "ddMMyyHHmmss";
        private static readonly int LimitSize = 7340032; //byte

        private readonly ILisDataAccess _lisDataAccess = new LisDataAccessImpl();

        public LogExtension()
        {
        }

        public void WriteInfo(string message, string suffix = "INFO")
        {
            LogService.RecordLogFile(InfoLogFileName, message, suffix);
        }

        public void WriteException(Exception exception, string suffix = "ERROR")
        {
            var logInfo = string.Format("Exception Source: {0}\nStackTrace: {1}\nSource: {2}\nTargetSite: {3}\nMessage: {4}",
                exception.Source, exception.StackTrace, exception.Source, exception.TargetSite, exception.Message);
            LogService.RecordLogFile(ErrorLogFileName, logInfo, suffix);
        }


        public void WriteInfo(LogMessageModel message, string suffix = "INFO")
        {
            var detailMessage =
                $"{message.Username}-{message.Action}-{message.Ip}\n{message.InputMessage}\n{message.OutputMessage}\n{message.ErrorMessage}";

            WriteInfo(detailMessage);
        }

    }
}