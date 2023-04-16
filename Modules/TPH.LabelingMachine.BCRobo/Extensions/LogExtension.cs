using System;
using TPH.WriteLog;

namespace TPH.LabelingMachine.BCRobo.Extensions
{
    public class LogExtension
    {
        private const string ErrorLogFileName = @"TPH.BCRoboERR";
        private const string InfoLogFileName = @"TPH.BCRobo";

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
    }
}
