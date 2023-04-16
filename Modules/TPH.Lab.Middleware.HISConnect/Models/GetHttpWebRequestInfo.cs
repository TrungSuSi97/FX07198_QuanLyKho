namespace TPH.Lab.Middleware.HISConnect.Models
{

    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    public class GetHttpWebRequestInfo
    {

        public string GetHttpWebRequestData(HttpWebRequestInfo info)
        {
            string data = string.Empty;
            string urlAddress = string.Format(info.WebRequestURL, info.Parameter);
            try
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "GetHttpWebRequestData - Request URL: {0}", urlAddress);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    WriteLog.LogService.RecordLogFileFormat("Log_", "GetHttpWebRequestData - Response: {0}", data);
                }
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFileFormat("Log_", "GetHttpWebRequestData - Response Request {0} occur error: {1}", urlAddress, ex.Message);
            }

            return data;
        }
    }
}
