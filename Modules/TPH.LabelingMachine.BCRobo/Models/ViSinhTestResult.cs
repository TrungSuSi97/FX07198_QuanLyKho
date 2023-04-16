using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{

    /// <summary>
    /// Thông tin và kết quả chỉ định vi sinh
    /// </summary>
    [Serializable()]
    [DataContract]
    public class ViSinhTestResult
    {
        /// <summary>
        /// ID chi tiết của phiếu yêu cầu ứng với từng dịch vụ 1 dịch vụ = 1 ID chi tiết
        /// </summary>
        [DataMember]
        public string OrderDetailID { get; set; }

        /// <summary>
        /// Mã loại dịch vụ như Sinh Hóa - Huyết học - ...
        /// </summary>
        [DataMember]
        public string MaLoaiDV { get; set; }

        /// <summary>
        /// Tên loại dịch vụ như Sinh Hóa - Huyết học - ...
        /// </summary>
        [DataMember]
        public string TenLoaiDV { get; set; }

        /// <summary>
        /// Mã đặc thù của dịch vụ hoặc chỉ định thực hiện, VD: GLU
        /// </summary>
        [DataMember]
        public string MaDV { get; set; }
        /// ma yeu cau
        /// </summary>
        [DataMember]
        public string CLSYeuCau_ID { get; set; }

        /// <summary>
        /// Tên dịch vụ hoặc chỉ định thực hiện
        /// </summary>
        [DataMember]
        public string TenDichVu { get; set; }

        /// <summary>
        /// Mã loại bệnh phẩm - 001:Máu, 002:Huyết Thanh, 003:Phân, 004:Nước tiểu, ...
        /// </summary>
        [DataMember]
        public string TestTypeId { get; set; }

        /// <summary>
        /// Tên loại bệnh phẩm  - Máu, Huyết Thanh, Phân, Nước tiểu, ...
        /// </summary>
        [DataMember]
        public string TestTypeName { get; set; }

        /// <summary>
        /// Kết quả cấy
        /// </summary>
        [DataMember]
        public string KetQuaCay { get; set; }

        /// <summary>
        /// Kết quả soi/nhuộm
        /// </summary>
        [DataMember]
        public string KetQuaSoiNhuom { get; set; }

        /// <summary>
        /// Thời gian thực hiện yyyy/MM/dd HH:mm:ss
        /// </summary>
        [DataMember]
        public string NgayThucHien { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Tên user valid kết quả
        /// </summary>
        [DataMember]
        public string UserValid { get; set; }

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        [DataMember]
        public string Unit { get; set; }

        /// <summary>
        /// Tên người thực hiện
        /// </summary>
        [DataMember]
        public string NguoiThucHien { get; set; }

        /// <summary>
        /// Máy xét nghiệm làm
        /// </summary>
        [DataMember]
        public string MayXetNghiem { get; set; }

        /// <summary>
        /// ID Máy xét nghiệm làm
        /// </summary>
        [DataMember]
        public int MayXetNghiemID { get; set; }

        /// <summary>
        /// 0: Định danh; 1: Kháng sinh đồ
        /// </summary>
        [DataMember]
        public bool IsAntibioticMaps { get; set; }

        /// <summary>
        /// Danh sách kết quả kháng sinh đồ
        /// </summary>
        [DataMember]
        public List<ViSinhKhangSinhDoDetailResult> ListViSinhKhangSinhDoDetailResult { get; set; }

        public ViSinhTestResult()
        {
            ListViSinhKhangSinhDoDetailResult = new List<ViSinhKhangSinhDoDetailResult>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("OrderDetailID: {0}, ", OrderDetailID);
            builder.AppendFormat("MaLoaiDV: {0}, ", MaLoaiDV);
            builder.AppendFormat("TenLoaiDV: {0}, ", TenLoaiDV);
            builder.AppendFormat("MaDV: {0}, ", MaDV);
            builder.AppendFormat("TenDichVu: {0}, ", TenDichVu);
            builder.AppendFormat("TestTypeId: {0}, ", TestTypeId);
            builder.AppendFormat("TestTypeName: {0}, ", TestTypeName);
            builder.AppendFormat("KetQuaCay: {0}, ", KetQuaCay);
            builder.AppendFormat("KetQuaSoiNhuom: {0}, ", KetQuaSoiNhuom);
            builder.AppendFormat("NgayThucHien: {0}, ", NgayThucHien);
            builder.AppendFormat("Comment: {0}, ", Comment);
            builder.AppendFormat("UserValid: {0}, ", UserValid);
            builder.Append("ListViSinhKhangSinhDoDetailResult: [");
            foreach (var item in ListViSinhKhangSinhDoDetailResult)
            {
                builder.AppendFormat("{0}, ", item);
            }
            builder.Append("]}");
            return builder.ToString();
        }
    }
}
