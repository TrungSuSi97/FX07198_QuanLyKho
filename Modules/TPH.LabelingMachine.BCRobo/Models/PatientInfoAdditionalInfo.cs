using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{

    /// <summary>
    /// Thông tin bổ sung cho của bệnh nhân
    /// </summary>
    [Serializable()]
    [DataContract]
    public class PatientInfoAdditionalInfo
    {
        /// <summary>
        /// Key chính không trùng lắp cho thông tin bổ sung
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// Giá trị thông tin
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        public PatientInfoAdditionalInfo()
        {

        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("Key: {0}, ", Key);
            builder.AppendFormat("Value: {0}, ", Value);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
