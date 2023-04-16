using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Kết quả truy vấn kết quả bệnh nhân
    /// </summary>
    [Serializable()]
    [DataContract]
    public class SamplingResultResponse
    {
        /// <summary>
        /// Message lỗi
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Kết quả xét nghiệm
        /// </summary>
        [DataMember]
        public PatientInfo Result { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("ErrorMessage: {0}, ", ErrorMessage);
            builder.AppendFormat("Result: {0}, ", Result);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
