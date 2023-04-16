using System.Configuration;

namespace TPH.LIS.BarcodePrinting.Configurations
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
