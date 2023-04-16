using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{
    [Serializable()]
    [DataContract]
    public abstract class BaseResponse
    {
        [DataMember]
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("ErrorMessage: {0}, ", ErrorMessage);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
