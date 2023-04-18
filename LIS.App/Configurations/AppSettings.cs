using System;
using System.Configuration;

namespace TPH.LIS.App.Configurations
{
    using TPH.Common.Converter;
    using SystemConfig = ConfigurationManager;

    public class AppSettings
    {
        public const string EnglishLanguageKey = "en-US";
        public const string VietnameseLanguageKey = "vi-VN";
        public const string DefaultLanguageKey = "vi-VN";


        public static string ApiUrl
        {
            get { return SystemConfig.AppSettings["APIUrl"]; }
        }
        public static string AppLanguage
        {
            get
            {
                var languageKey = SystemConfig.AppSettings["AppConfig:AppLanguage"];
                return string.IsNullOrWhiteSpace(languageKey) ? DefaultLanguageKey : languageKey;
            }
        }
        public static bool IsCreateNewCustomerKey
        {
            get { return SystemConfig.AppSettings["IsCreateNewCustomerKey"].Equals("1"); }
        }

        public static string CustomerKey
        {
            get
            {
                var isCreateNewCustomerKey = IsCreateNewCustomerKey;
                var currentCustomerKey = SystemConfig.AppSettings["CustomerKey"];

                if (!isCreateNewCustomerKey &&
                    !string.IsNullOrWhiteSpace(currentCustomerKey))
                {
                    return currentCustomerKey;
                }

                var newCustomerKey = TPH.Authorization.ProductionKey.GetLocalSystemInformation();

                if (currentCustomerKey != null &&
                    currentCustomerKey.Equals(newCustomerKey, StringComparison.Ordinal))
                {
                    return currentCustomerKey;
                }

                ResetCustomerKey(newCustomerKey);

                return newCustomerKey;
            }
        }
        private static void ResetCustomerKey(string customerKey)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["CustomerKey"].Value = customerKey;
            config.Save(ConfigurationSaveMode.Modified);
        }

    }
}
