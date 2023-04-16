using System.Net;
using System.Net.Sockets;
using System.Web;

namespace TPH.HIS.WebAPI.Extensions
{
    public class Client
    {
        public static string Ip()
        {
            try
            {
                var ip = HttpContext.Current != null ?
                    (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? 
                     HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]) :
                    GetLocalIPAddress();

                return ip.Equals("::1") ? "127.0.0.1" : (string.IsNullOrEmpty(ip) ? "127.0.0.1" : ip.Split(',')[0]);
            }
            catch
            {

            }

            return string.Empty;
        }
        public static string Browser()
        {
            var browser = HttpContext.Current.Request.Browser;
            var userAgent = HttpContext.Current.Request.UserAgent;

            return $"{userAgent}";
        }

        public static string PcName()
        {
            try
            {
                return System.Net.Dns.GetHostName();
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
