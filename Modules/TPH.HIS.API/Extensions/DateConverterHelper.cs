using System;
using System.Globalization;

namespace TPH.HIS.WebAPI.Extensions
{
    public class DateConverterHelper
    {
        public static DateTime ToDateTime(string date)
        {
            return DateTime.ParseExact(date, "d/M/yyyy H:m:s", CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime(string date, string format)
        {
            return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        }
    }
}
