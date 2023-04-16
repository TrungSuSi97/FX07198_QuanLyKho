using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{

    /// <summary>
    /// Thông tin và kết quả kháng sinh đồ
    /// </summary>
    [Serializable()]
    [DataContract]
    public class ViSinhKhangSinhDoDetailResult
    {
        /// <summary>
        /// Mã vi khuẩn
        /// </summary>
        [DataMember]
        public string BacteriumId { get; set; }

        /// <summary>
        /// Tên vi khuẩn
        /// </summary>
        [DataMember]
        public string BacteriumName { get; set; }

        /// <summary>
        /// Mã kháng sinh
        /// </summary>
        [DataMember]
        public string AntibioticId { get; set; }

        /// <summary>
        /// Tên kháng sinh
        /// </summary>
        [DataMember]
        public string AntibioticName { get; set; }

        /// <summary>
        /// Kết quả
        /// </summary>
        [DataMember]
        public string Result { get; set; }

        /// <summary>
        /// Số lượng vi khuẩn
        /// </summary>
        [DataMember]
        public string BacteriumCount { get; set; }

        /// <summary>
        /// Ngưỡng bình thường
        /// </summary>
        [DataMember]
        public string RangeDisplay { get; set; }

        /// <summary>
        /// Kết quả Nhạy/Trung gian/Kháng
        /// S = Nhạy
        /// R = Kháng
        /// I = Trung gian
        /// </summary>
        [DataMember]
        public string SRI { get; set; }


        public ViSinhKhangSinhDoDetailResult()
        {

        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("BacteriumId: {0}, ", BacteriumId);
            builder.AppendFormat("BacteriumName: {0}, ", BacteriumName);
            builder.AppendFormat("AntibioticId: {0}, ", AntibioticId);
            builder.AppendFormat("AntibioticName: {0}, ", AntibioticName);
            builder.AppendFormat("Result: {0}, ", Result);
            builder.AppendFormat("BacteriumCount: {0}, ", BacteriumCount);
            builder.AppendFormat("RangeDisplay: {0}, ", RangeDisplay);
            builder.AppendFormat("SRI: {0}, ", SRI);
            builder.Append("}");
            return builder.ToString();
        }
    }
}
