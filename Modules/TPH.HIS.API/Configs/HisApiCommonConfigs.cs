using System;
using System.Configuration;
using TPH.Common.Converter;

namespace TPH.HIS.WebAPI.Configs
{
    public class HisApiCommonConfigs
    {
        public const string SystemConfigCacheKey = "TPH.HIS.WebAPI.Configs.CommonConfigs.SystemConfigCacheKey";
        public static int HisSendRequestTimeoutAfterSeconds
        {
            get
            {
                if (ConfigurationManager.AppSettings["HIS:SendRequestTimeoutAfterSeconds"] == null)
                {
                    return 30000;
                }

                return NumberConverter.ToInt(ConfigurationManager.AppSettings["HIS:SendRequestTimeoutAfterSeconds"]) * 1000;
            }
        }

        public static string DatabaseServerIp
        {
            get
            {
                if (ConfigurationManager.AppSettings["Database:ServerIP"] == null)
                {
                    return "127.0.0.1";
                }

                return StringConverter.ToString(ConfigurationManager.AppSettings["Database:ServerIP"]);
            }
        }
        public static string DatabaseDbName
        {
            get
            {
                if (ConfigurationManager.AppSettings["Database:DbName"] == null)
                {
                    return "TPHLabIMS";
                }

                return StringConverter.ToString(ConfigurationManager.AppSettings["Database:DbName"]);
            }
        }
        public static string JsVersion
        {
            get
            {
                if (ConfigurationManager.AppSettings["App:JsVersion"] == null)
                {
                    return DateTime.Now.ToString("ddMMyyHHmm");
                }

                return StringConverter.ToString(ConfigurationManager.AppSettings["App:JsVersion"]);
            }
        }
        public static bool EnableLogsDb
        {
            get
            {
                if (ConfigurationManager.AppSettings["Database:EnableLogDb"] == null)
                {
                    return false;
                }

                return NumberConverter.ToInt(ConfigurationManager.AppSettings["Database:EnableLogDb"]) == 1;
            }
        }
        public static string LogsDatabaseServerIp
        {
            get
            {
                if (ConfigurationManager.AppSettings["Database:LogServerIp"] == null)
                {
                    return "127.0.0.1";
                }

                return StringConverter.ToString(ConfigurationManager.AppSettings["Database:LogServerIp"]);
            }
        }

        public static string LogsDatabaseDBName
        {
            get
            {
                if (ConfigurationManager.AppSettings["Database:LogDb"] == null)
                {
                    return "{{TPH_Standard}}_Log";
                }

                return StringConverter.ToString(ConfigurationManager.AppSettings["Database:LogDb"]);
            }
        }
    }
}
