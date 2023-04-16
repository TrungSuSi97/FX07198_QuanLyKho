using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using log4net;

namespace TPH.ViettelSignCertificate.Extensions
{
    public class LogExtension
    {
        private log4net.ILog _log;
        private const string ErrorLogFileName = @"_Logs\{0:yyyyMMdd}\TPH.Viettel.CerERR_{1}_{0:yyyyMMdd}.log";
        private const string InfoLogFileName = @"_Logs\{0:yyyyMMdd}\TPH.Viettel.Cer_{1}_{0:yyyyMMdd}.log";

        public LogExtension()
        {
        }

        public LogExtension(ILog log)
        {
            Log = log;
        }

        public ILog Log
        {
            get { return _log ?? (_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)); }
            set { _log = value; }
        }


        public void WriteInfo(string message, string suffix = "INFO")
        {
            ChangeLogFileName(string.Format(InfoLogFileName, DateTime.Now, suffix));

            //var logFormat = Environment.NewLine + Environment.NewLine + "{0} ";
            Log.Info(message);
            Task.Factory.StartNew(DeleteLogFiles);
        }

        public void WriteException(Exception exception, string suffix = "ERROR")
        {
            ChangeLogFileName(string.Format(ErrorLogFileName, DateTime.Now, suffix));

            var logInfo = string.Format("Exception Source: {0}\nStackTrace: {1}\nSource: {2}\nTargetSite: {3}\nMessage: {4}",
                exception.Source, exception.StackTrace, exception.Source, exception.TargetSite, exception.Message);

            //var logFormat = Environment.NewLine + Environment.NewLine + "{0} ";
            Log.Error(logInfo);

            Task.Factory.StartNew(DeleteLogFiles);
        }


        private void DeleteLogFiles()
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory + @"_Logs\";
                foreach (var file in Directory.GetFiles(basePath, "*.log"))
                {
                    try
                    {
                        var fi = new FileInfo(file);
                        if (fi.LastWriteTime < DateTime.Now.AddDays(-15))
                            fi.Delete();
                    }
                    catch { }
                }
            }
            catch { }
        }

        private static bool ChangeLogFileName(string newFilename = "", string appenderName = "LogFileAppender")
        {
            var rootRepository = LogManager.GetRepository();
            foreach (var appender in rootRepository.GetAppenders())
            {
                if (appender.Name.Equals(appenderName) && appender is log4net.Appender.FileAppender)
                {
                    var fileAppender = appender as log4net.Appender.FileAppender;
                    fileAppender.File = newFilename;
                    fileAppender.ActivateOptions();


                    return true;  // Appender found and name changed to NewFilename
                }
            }

            return false; // appender not found
        }
    }
}
