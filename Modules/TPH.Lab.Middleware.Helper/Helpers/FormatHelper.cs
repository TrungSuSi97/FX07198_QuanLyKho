
using System;
using System.Text.RegularExpressions;

namespace TPH.Lab.Middleware.Helpers
{
    public class FormatHelper
    {
        public static string SampleID(DateTime date, string stt)
        {
            if (stt.IndexOf(".", StringComparison.Ordinal) == 6)
            {
                return stt;
            }
            else
            {
                return string.Format("{0:yyMMdd}.{1}", date, stt.Trim());
            }
        }
        public static bool IsNumeric(string text)
        {
            return string.IsNullOrEmpty(text) ? false :
                    Regex.IsMatch(text, @"^\s*\-?\d+(\.\d+)?\s*$");
        }
        public static DateTime GetDateTime(string _yyyyMMddHHmmss)
        {
            string _yyyy = _yyyyMMddHHmmss.Substring(0, 4);
            string _MM = _yyyyMMddHHmmss.Substring(4, 2);
            string _dd = _yyyyMMddHHmmss.Substring(6, 2);
            string _HH = _yyyyMMddHHmmss.Substring(8, 2);
            string _mm = _yyyyMMddHHmmss.Substring(10, 2);
            string _ss = _yyyyMMddHHmmss.Substring(12, 2);
            string _datetime = _yyyy + "/" + _MM + "/" + _dd + " " + _HH + ":" + _mm + ":" + _ss;
            return DateTime.Parse(_datetime);
        }
        public static DateTime GetDateOfBirth(string _yyyyMMdd)
        {
            string _yyyy = _yyyyMMdd.Substring(0, 4);
            string _MM = _yyyyMMdd.Substring(4, 2);
            string _dd = _yyyyMMdd.Substring(6, 2);
            string _datetime = _yyyy + "/" + _MM + "/" + _dd;
            return DateTime.Parse(_datetime);
        }
        public static string GetAge(string _yyyyMMdd)
        {
            if (_yyyyMMdd.Length < 4)
                return "";
            else
                return _yyyyMMdd.Substring(0, 4);
        }
        public static string ReturnFullName(string fullName)
        {
            string fullPatientName = fullName;
            if (!string.IsNullOrEmpty(fullName))
            {
                string[] splitFullName = fullName.Split(new char[] { ' ' });
                if (splitFullName.Length > 1)
                {
                    var lastName = splitFullName[0];
                    var firstName = "";
                    for (int k = 1; k < splitFullName.Length; k++)
                    {
                        firstName += string.Format("{0} ", splitFullName[k]);
                    }
                    fullPatientName = string.Format("{0}^{1}", lastName, firstName.Trim());
                }
            }
            return fullPatientName;
        }
    }
}
