using System.Net;
using System.Net.Sockets;
using System.Web;

namespace TPH.LIS.Common.Extensions
{
    public class IpExtension
    {
        public static string Ip()
        {
            try
            {
                var ip = HttpContext.Current != null ?
                    (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]) :
                    GetLocalIpAddress();

                return ip.Equals("::1") ? "127.0.0.1" : (string.IsNullOrEmpty(ip) ? "127.0.0.1" : ip.Split(',')[0]);
            }
            catch
            {

            }

            return string.Empty;
        }

        public static string GetLocalIpAddress()
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
