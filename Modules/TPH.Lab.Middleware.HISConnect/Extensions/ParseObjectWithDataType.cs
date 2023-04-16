using System;

namespace TPH.Lab.Middleware.HISConnect.Extensions
{
    public class ParseObjectWithDataType
    {
        public static object GetObjectWithDatatype(string formatType, object input)
        {
            var fType = formatType.ToLower();
            if (fType.Contains("(") && fType.Contains(")"))
            {
                if (input != null)
                {
                    if (!string.IsNullOrEmpty(input.ToString()))
                    {
                        if (fType.Contains("(int)"))
                        {
                            return int.Parse(input.ToString());
                        }
                        else if (fType.Contains("(double)"))
                        {
                            return double.Parse(input.ToString());
                        }
                        else if (fType.Contains("(float)"))
                        {
                            return double.Parse(input.ToString());
                        }
                        else if (fType.Contains("(long)"))
                        {
                            return long.Parse(input.ToString());
                        }
                        else if (fType.Contains("(decimal)"))
                        {
                            return decimal.Parse(input.ToString());
                        }
                        else if (fType.Contains("(datetime)"))
                        {
                            return DateTime.Parse(input.ToString());
                        }
                        else if (fType.Contains("(bool)"))
                        {
                            return bool.Parse(input.ToString());
                        }
                        else if (fType.Contains("(string)"))
                        {
                            return input.ToString();
                        }
                    }
                    else
                        return null;
                }
            }

            return input;
        }
    }
}
