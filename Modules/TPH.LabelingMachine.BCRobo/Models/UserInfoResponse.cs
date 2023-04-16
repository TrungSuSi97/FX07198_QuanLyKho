using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Kết quả truy vấn thông tin người sử dụng
    /// </summary>
    [Serializable()]
    [DataContract]
    public class UserInfoResponse : BaseResponse
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("{0}, ", base.ToString());
            builder.AppendFormat("UserId: {0}, ", UserId);
            builder.AppendFormat("UserName: {0}, ", UserName);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
