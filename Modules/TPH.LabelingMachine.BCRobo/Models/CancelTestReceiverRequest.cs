using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Thông tin hủy dịch vụ HIS
    /// </summary>
    [Serializable()]
    [DataContract]
    public class CancelTestReceiverRequest
    {
        /// <summary>
        /// ID chi tiết của phiếu yêu cầu ứng với từng dịch vụ 1 dịch vụ = 1 ID chi tiết
        /// </summary>
        [DataMember]
        public string OrderDetailID { get; set; }

        /// <summary>
        /// ID của phiếu yêu cầu = PatientInfo.OrderID
        /// </summary>
        [DataMember]
        public string OrderID { get; set; }

        /// <summary>
        /// Mã đặc thù của dịch vụ hoặc chỉ định thực hiện, VD: GLU
        /// </summary>
        [DataMember]
        public string MaDV { get; set; }

        /// <summary>
        /// Ghi chú chung
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("OrderDetailID: {0}, ", OrderDetailID);
            builder.AppendFormat("OrderID: {0}, ", OrderID);
            builder.AppendFormat("MaDV: {0}, ", MaDV);
            builder.AppendFormat("Description: {0}, ", Description);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
