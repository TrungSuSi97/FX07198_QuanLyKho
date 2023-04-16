using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Lịch sử xét nghiệm trong khoảng thời gian định sẵn của
    /// </summary>
    [Serializable()]
    [DataContract]
    public class SamplingHistoryResponseDetail
    {
        /// <summary>
        /// Mã xét nghiệm gán cho bệnh nhân
        /// </summary>
        [DataMember]
        public string SampleId { get; set; }

        /// <summary>
        /// Ngày yêu cầu, format: yyyy-MM-dd
        /// </summary>
        [DataMember]
        public string DateRequest
        {
            get
            {
                return DateRequest_DateTime.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime result = DateTime.Now;

                if (DateTime.TryParseExact(value, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequest_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequest_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy/MM/dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequest_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy/MM/dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequest_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy.MM.dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequest_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy.MM.dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequest_DateTime = result;
                }
                else
                {
                    throw new ArgumentException("DateRequestTo is not a valid format.");
                }
            }
        }

        /// <summary>
        /// Ngày yêu cầu, format: format datetime
        /// </summary>
        [XmlIgnore]
        [IgnoreDataMember]
        public DateTime DateRequest_DateTime { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("SampleId: {0}, ", SampleId);
            builder.AppendFormat("DateRequest: {0}, ", DateRequest);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
