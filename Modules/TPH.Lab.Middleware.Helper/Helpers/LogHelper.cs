using System;
using System.IO;
using TPH.Lab.Middleware.Helpers.Enum;

namespace TPH.Lab.Middleware.Helpers
{
    public class LogHelper
    {
        public static void WriteLogFile(LogType logType, string msg)
        {
            try
            {
                var folderPath = "Logs";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = string.Format(@"{0}\{1}_{2}.txt", folderPath, logType.ToString(), DateTime.Now.ToString("yyyyMMdd"));

                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(string.Format("{0:yyyy/MM/dd HH:mm:ss}: {1}", DateTime.Now, msg));
                sw.WriteLine("====================================================");

                sw.Close();
                fs.Close();
            }
            catch
            {
                return;
            }
        }
        public static void DeleteLogFile(int day)
        {
            try
            {

                var folderPath = "Logs";
                
                if (Directory.Exists(folderPath))
                {
                    var msg = string.Format("Scan delete log file on {0}", Path.GetFullPath(folderPath));
                    WriteLogFile(LogType.DeleteLogFile, msg);

                    var files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.LastWriteTime < DateTime.Now.AddDays(-day) &&
                            (fi.Extension.Equals(".txt", StringComparison.OrdinalIgnoreCase) ||
                            fi.Extension.Equals(".log", StringComparison.OrdinalIgnoreCase))
                            )
                        {
                            WriteLogFile(LogType.DeleteLogFile, string.Format("delete file: {0} with datemodified: {1:yyyy-MM-dd HH:mm:ss}", fi.Name, fi.LastWriteTime));
                            fi.Delete();
                        }
                    }

                    //Directory.GetFiles(folderPath).Select(
                    //    f => new FileInfo(f)).Where
                    //    (f => f.LastAccessTime < DateTime.Now.AddDays(-5) &&
                    //    (f.Extension.Equals("txt", StringComparison.OrdinalIgnoreCase) ||
                    //    f.Extension.Equals("log", StringComparison.OrdinalIgnoreCase))).ToList()
                    //    .ForEach(f => f.Delete());
                }
            }
            catch (Exception ex)
            {
                WriteLogFile(LogType.DeleteLogFile, "Error occur when check delete log file: " + ex.Message);
            }
        }
    }
}
