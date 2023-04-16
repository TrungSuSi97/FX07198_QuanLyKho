namespace TPH.Lab.Middleware.Helpers
{
    using Common.Contants;
    using Common.StringCryptography;

    using System;
    using System.IO;

    public class LicenseHelper
    {
        public static void WriteKeynumber(string keynumber)
        {
            try
            {
                var folderPath = "License";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = string.Format(@"{0}\key.reg", folderPath);

                FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);
                fs.Flush();
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(keynumber);
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                WriteLog.WriteErrorToLogFile("Logs", string.Format("Error occur when write serial keynumber {0}", ex.Message));
            }
        }
        public static bool ReadLicense()
        {
            bool f = false;
            try
            {

                var folderPath = "License";

                if (Directory.Exists(folderPath))
                {
                    var files = Directory.GetFiles(folderPath);
                    string lisencekey = "";
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.Extension.Equals(".reg", StringComparison.OrdinalIgnoreCase) &&
                            fi.Name.Equals("license.reg", StringComparison.OrdinalIgnoreCase)
                            )
                        {
                            StreamReader sr = new StreamReader(fi.FullName);
                            lisencekey = sr.ReadToEnd();
                            sr.Close();
                            break;
                        }
                    }
                    if (!string.IsNullOrEmpty(lisencekey))
                    {
                        f = TPHSerialKeys.CheckSerial(lisencekey);
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
                WriteLog.WriteErrorToLogFile("Logs", string.Format("Error occur when write serial keynumber {0}", ex.Message));
            }
            return f;
        }
    }
}
