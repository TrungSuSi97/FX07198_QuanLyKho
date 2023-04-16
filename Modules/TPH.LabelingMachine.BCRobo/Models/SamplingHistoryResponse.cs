using System;
using System.Collections.Generic;
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
    public class SamplingHistoryResponse
    {
        /// <summary>
        /// Message lỗi
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Mã bệnh nhân
        /// </summary>
        [DataMember]
        public string PatientId { get; set; }

        /// <summary>
        /// Ngày bắt đầu yêu cầu, format: yyyy-MM-dd
        /// </summary>
        [DataMember]
        public string DateRequestFrom
        {
            get
            {
                return DateRequestFrom_DateTime.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime result = DateTime.Now;

                if (DateTime.TryParseExact(value, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestFrom_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestFrom_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy/MM/dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestFrom_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy/MM/dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestFrom_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy.MM.dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestFrom_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy.MM.dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestFrom_DateTime = result;
                }
                else
                {
                    throw new ArgumentException("DateRequestFrom is not a valid format.");
                }
            }
        }

        /// <summary>
        /// Ngày kết thú yêu cầu, format: yyyy-MM-dd
        /// </summary>
        [DataMember]
        public string DateRequestTo
        {
            get
            {
                return DateRequestTo_DateTime.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime result = DateTime.Now;

                if (DateTime.TryParseExact(value, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestTo_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestTo_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy/MM/dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestTo_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy/MM/dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestTo_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy.MM.dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestTo_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy.MM.dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    DateRequestTo_DateTime = result;
                }
                else
                {
                    throw new ArgumentException("DateRequestTo is not a valid format.");
                }
            }
        }

        /// <summary>
        /// Ngày bắt đầu yêu cầu, format datetime
        /// </summary>
        [XmlIgnore]
        [IgnoreDataMember]
        public DateTime DateRequestFrom_DateTime { get; set; }

        /// <summary>
        /// Ngày kết thú yêu cầu, format datetime
        /// </summary>
        [XmlIgnore]
        [IgnoreDataMember]
        public DateTime DateRequestTo_DateTime { get; set; }

        /// <summary>
        /// Danh sách các mã xét nghiệm gán cho bệnh nhân
        /// </summary>
        [DataMember]
        public List<SamplingHistoryResponseDetail> ListSamplingHistoryDetail { get; set; }

        public SamplingHistoryResponse()
        {
            ListSamplingHistoryDetail = new List<SamplingHistoryResponseDetail>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("ErrorMessage: {0}, ", ErrorMessage);
            builder.AppendFormat("PatientId: {0}, ", PatientId);
            builder.AppendFormat("DateRequestFrom: {0}, ", DateRequestFrom);
            builder.AppendFormat("DateRequestTo: {0}, ", DateRequestTo);
            builder.Append("ListSamplingHistoryDetail: [");
            if (ListSamplingHistoryDetail != null)
            {
                foreach (var item in ListSamplingHistoryDetail)
                {
                    builder.AppendFormat("{0}, ", item);
                }
            }
            builder.Append("]");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
