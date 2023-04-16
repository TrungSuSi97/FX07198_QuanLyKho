using System;
using System.IO;
using TPH.LIS.Common.Constants;

namespace TPH.LIS.Common.Extensions
{
    public class ErrorHandler
    {
        private static string _defaultErrorFolder = "Logs";
        private static string _defaultFileName = "Logs_";
        private static readonly object Block = new object();

        public static void RecordError(
            string loginUser = "",
            string fileName = "Logs_", 
            Exception exception = null,
            int errorCode = 0,
            string msg = "", 
            string methodCalled = "")
        {
            try
            {
                lock (Block)
                {
                    if (!System.IO.Directory.Exists(_defaultErrorFolder))
                        System.IO.Directory.CreateDirectory(_defaultErrorFolder);
                    fileName = fileName ?? _defaultFileName;
                    
                    var messageDetail = DateTime.Now.ToString(DateTimeFormatConstant.LongDateTimeFormat_yyyyMMddHHmmss) +
                                        ",User: " + loginUser + " , Error Code: " + errorCode +
                                        Environment.NewLine + msg.ToUpper() +
                                        Environment.NewLine + "METHOD CALL: " + methodCalled +
                                        Environment.NewLine + "DETAIL: " +
                                        Environment.NewLine + exception;

                    var fs = new FileStream(
                        string.Format(@"{0}\{1}{2}.txt", 
                            _defaultErrorFolder,
                            fileName,
                            DateTime.Now.ToString(DateTimeFormatConstant.FileDateFormat_ddMMyy)),
                        FileMode.OpenOrCreate);
                    fs.Seek(0, SeekOrigin.End);

                    var sw = new StreamWriter(fs);

                    msg = string.Format("---------=====----------{0}{1}", Environment.NewLine, messageDetail);

                    sw.WriteLine(msg);
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception)
            {
                return;
            }
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