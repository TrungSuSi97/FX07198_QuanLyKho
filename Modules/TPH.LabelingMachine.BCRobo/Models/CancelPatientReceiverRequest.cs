using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Thông tin hủy phiếu từ HIS
    /// </summary>
    [Serializable()]
    [DataContract]
    public class CancelPatientReceiverRequest
    {
        /// <summary>
        /// ID của phiếu yêu cầu = PatientInfo.OrderID
        /// </summary>
        [DataMember]
        public string OrderID { get; set; }

        /// <summary>
        /// Ghi chú chung
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("OrderID: {0}, ", OrderID);
            builder.AppendFormat("Description: {0}, ", Description);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
