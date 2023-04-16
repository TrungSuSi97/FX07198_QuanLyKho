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

    }
}
