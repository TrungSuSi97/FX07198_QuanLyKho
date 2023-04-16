using System.Configuration;

namespace TPH.LIS.App.Configurations
{
    using SystemConfig = ConfigurationManager;

    public class AppSettings
    {
        public static string BarcodeName
        {
            get { return SystemConfig.AppSettings["BarcodeName"]; }
        }
    }
}
