using System;
using System.IO;
using System.Threading;

namespace TPH.WriteLog
{
    public class LogService
    {
        private static string _defaultErrorFolder = "Logs";
        private static string _defaultFileName = "Logs_";
        private static readonly object Block = new object();
        private static string FileDateFormat_ddMMyy = "ddMMyy";
        private static string LongDateTimeFormat_yyyyMMddHHmmss = "yyyy-MM-dd HH:mm:ss";
        private static string FileDateFormat_ddMMyyHHmmss = "ddMMyyHHmmss";
        private static int LimitSize = 7340032; //byte
        private static string Check_CreateLogFolder()
        {
            var logFolder = string.Format(@"{0}\{1}\{2:00}\{3:00}\APP_LOG", _defaultErrorFolder, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (!System.IO.Directory.Exists(logFolder))
            {
                System.IO.Directory.CreateDirectory(logFolder);
            }
            return logFolder;
        }

        public static void RecordLogError(
            string loginUser = "",
            string fileName = "Logs_",
            Exception exception = null,
            int errorCode = 0,
            string msg = "",
            string methodCalled = "")
        {

            var logFolder = Check_CreateLogFolder();

            var logFileName = fileName ?? _defaultFileName;

            var messageDetail = DateTime.Now.ToString(LongDateTimeFormat_yyyyMMddHHmmss) +
                                ",User: " + loginUser + " , Error Code: " + errorCode +
                                Environment.NewLine + msg +
                                Environment.NewLine + "METHOD CALL: " + methodCalled +
                                Environment.NewLine + "DETAIL: " +
                                Environment.NewLine + exception;

            fileName = string.Format("{0}{1}.txt", logFileName, DateTime.Now.ToString(FileDateFormat_ddMMyy));
            var fileNameBreak = string.Format("{0}{1}.txt", logFileName, DateTime.Now.ToString(FileDateFormat_ddMMyyHHmmss));
            var finalFilename = string.Format(@"{0}\{1}", logFolder, fileName);
            msg = string.Format("{0}: {1}{2}---------=====----------", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fff"), messageDetail, Environment.NewLine);
            StartWriteLog(finalFilename, fileName, fileNameBreak, msg);
        }
        public static void RecordLogFile(string logFileName = "Log_", string logContent = "", string methodCall = "")
        {
            var logFolder = Check_CreateLogFolder();
            var fileName = string.Format("{0}{1}.txt", (logFileName ?? _defaultFileName), DateTime.Now.ToString(FileDateFormat_ddMMyy));
            var fileNameBreak = string.Format("{0}{1}.txt", (logFileName ?? _defaultFileName), DateTime.Now.ToString(FileDateFormat_ddMMyyHHmmss));
            var finalFilename = string.Format(@"{0}\{1}", logFolder, fileName);
            var msg = string.Format("{0}: {1}{2}{3}---------=====----------", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fff")
                , (string.IsNullOrEmpty(methodCall) ? string.Empty : string.Format("Thủ tục: {0}{1}", methodCall, Environment.NewLine))
                , logContent, Environment.NewLine);
            StartWriteLog(finalFilename, fileName, fileNameBreak, msg);
        }
        private static void Check_FileSize(string fileName, string fName, string newFName)
        {
            var fileInfo = new FileInfo(fileName);
            if(fileInfo.Length >= LimitSize)
            {
                File.Move(fileName, fileName.Replace(fName, newFName));
            }
        }
        public static void RecordLogFileFormat(string logFileName = "Log_", string logContent = "", params object[] args)
        {
            if (!string.IsNullOrEmpty(logContent))
            {
                var logContentWrite = string.Format(logContent, args);
                var logFolder = Check_CreateLogFolder();
                var fileName = string.Format("{0}{1}.txt", (string.IsNullOrEmpty(logFileName) ? _defaultFileName: logFileName), DateTime.Now.ToString(FileDateFormat_ddMMyy));
                var fileNameBreak = string.Format("{0}{1}.txt", (string.IsNullOrEmpty(logFileName) ? _defaultFileName : logFileName), DateTime.Now.ToString(FileDateFormat_ddMMyyHHmmss));
                var finalFilename = string.Format(@"{0}\{1}", logFolder, fileName);
                var msg = string.Format("{0}: {1}{2}---------=====----------", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fff"), logContentWrite, Environment.NewLine);
                StartWriteLog(finalFilename, fileName, fileNameBreak, msg);
            }
        }
        private static EventWaitHandle waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "SHARED_BY_ALL_PROCESSES");
        private static void StartWriteLog(string finalFilename, string fileName, string fileNameBreak, string logContent)
        {
            try
            {
                waitHandle.WaitOne();
                /* process file*/
                var fs = new FileStream(finalFilename, FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);

                if (fs.Length >= LimitSize)
                {
                    fs.Close();
                    File.Move(finalFilename, finalFilename.Replace(fileName, fileNameBreak));
                    fs = new FileStream(finalFilename, FileMode.OpenOrCreate);
                    fs.Seek(0, SeekOrigin.End);
                }

                var sw = new StreamWriter(fs);
                sw.WriteLine(logContent);
                sw.Close();
                fs.Close();
                waitHandle.Set();
            }
            catch (Exception ex)
            {
                waitHandle.Set();
                RecordLogError("LogWriter", "Error_WriteLogs_", ex, 0, logContent, "StartWriteLog");
            }
        }
        public static void WriteException(Exception ex)
        {
            RecordLogFile("Log_WriteException", ex.ToString());
        }
        public static void DeleLogFile(string partFile, int numberOfDay)
        {
            if (Directory.Exists(_defaultErrorFolder))
            {
                var dir = new DirectoryInfo(_defaultErrorFolder);
                var fil = dir.GetFiles();
                if (fil.Length > 0)
                {
                    foreach (FileInfo f in fil)
                    {
                        try
                        {
                            if ((f.Name.Contains(partFile) || f.Name.Equals(partFile)) && f.CreationTimeUtc <= DateTime.Now.AddDays(-numberOfDay))
                            {
                                f.Delete();
                            }
                        }
                        catch
                        { }
                    }
                }
            }
        }
    }
}
