﻿using System;
using System.Runtime.Serialization;
using System.Text;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Thông tin chỉ số thực hiện
    /// </summary>
    [Serializable()]
    [DataContract]
    public class SubTestResult
    {


        /// <summary>
        /// ID chi tiết của phiếu yêu cầu ứng với từng dịch vụ 1 dịch vụ = 1 ID chi tiết, = TestResult.OrderDetailID
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
        /// Mã dịch vụ cha, hoặc chỉ định gốc như Công thức máu 13 chỉ số, ...
        /// </summary>
        [DataMember]
        public string MaDVCha { get; set; }

        /// <summary>
        /// Mã đặc thù của dịch vụ hoặc chỉ định thực hiện, VD: GLU
        /// </summary>
        [DataMember]
        public string MaDV { get; set; }

        /// <summary>
        /// Tên dịch vụ hoặc chỉ định thực hiện
        /// </summary>
        [DataMember]
        public string TenDichVu { get; set; }

        /// <summary>
        /// Kết quả thực hiện
        /// </summary>
        [DataMember]
        public string KetQua { get; set; }

        /// <summary>
        /// Ngưỡng bình thường
        /// </summary>
        [DataMember]
        public string NormalRange { get; set; }

        /// <summary>
        /// Đơn vị tính
        /// </summary>
        [DataMember]
        public string Unit { get; set; }

        //Giá trị bình thường min
        [DataMember]
        public string MucBinhThuongMin { get; set; }

        //Giá trị bình thường max
        [DataMember]
        public string MucBinhThuongMax { get; set; }

        /// <summary>
        /// Gửi bất thường khi trả kết quả của dịch vụ
        /// </summary>
        [DataMember]
        public string BatThuong { get; set; }

        /// <summary>
        /// Kết quả bất thường
        /// </summary>
        [DataMember]
        public bool IsAbnormal { get; set; }

        /// <summary>
        /// Vùng nguy hiểm
        /// </summary>
        public string WarningRange { get; set; }

        //Giá trị nguy hiểm min
        [DataMember]
        public string MucNguyHiemMin { get; set; }

        //Giá trị nguy hiểm max
        [DataMember]
        public string MucNguyHiemMax { get; set; }

        /// <summary>
        /// Gửi NguyHiem khi trả kết quả của dịch vụ
        /// </summary>
        [DataMember]
        public string NguyHiem { get; set; }

        /// <summary>
        /// Kết quả có nguy hiểm không
        /// </summary>
        [DataMember]
        public bool IsWarning { get; set; }

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

        ///// <summary>
        ///// Thời gian valid kết quả
        ///// </summary>
        //[DataMember]
        //public DateTime? ValidTime { get; set; }


        /// <summary>
        /// Thời gian valid kết quả
        /// </summary>
        [DataMember]
        public string ValidTime { get; set; }

        /// <summary>
        /// Mã user valid kết quả
        /// </summary>
        [DataMember]
        public string UserIdValid { get; set; }

        /// <summary>
        /// Tên user valid kết quả
        /// </summary>
        [DataMember]
        public string UserValid { get; set; }

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
        /// Phương pháp xét nghiệm (TestMethod)
        /// </summary>
        [DataMember]
        public string PhuongPhapXN { get; set; }

        /// <summary>
        /// Cảnh báo máy
        /// </summary>
        [DataMember]
        public string CanhBaoMay { get; set; }

        /// <summary>
        /// SID riêng đặc thù cho riêng ống mấu, chỉ sử dụng khi có nhiều SID riêng biệt cho từng loại bệnh phẩm
        /// </summary>
        [DataMember]
        public string DistinctSID { get; set; }

        /// <summary>
        /// Thời gian nhập
        /// </summary>
        [DataMember]
        public string InTime { get; set; }

        /// <summary>
        /// Loại mẫu SHPT
        /// </summary>
        [DataMember]
        public string TypeSHPT { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("MaLoaiDV: {0}, ", MaLoaiDV);
            builder.AppendFormat("TenLoaiDV: {0}, ", TenLoaiDV);
            builder.AppendFormat("MaDVCha: {0}, ", MaDVCha);
            builder.AppendFormat("MaDV: {0}, ", MaDV);
            builder.AppendFormat("OrderDetailID: {0}, ", OrderDetailID);
            builder.AppendFormat("TenDichVu: {0}, ", TenDichVu);
            builder.AppendFormat("KetQua: {0}, ", KetQua);
            builder.AppendFormat("NormalRange: {0}, ", NormalRange);
            builder.AppendFormat("Unit: {0}, ", Unit);
            builder.AppendFormat("MucBinhThuongMin: {0}, ", MucBinhThuongMin);
            builder.AppendFormat("MucBinhThuongMax: {0}, ", MucBinhThuongMax);
            builder.AppendFormat("BatThuong: {0}, ", BatThuong);
            builder.AppendFormat("IsAbnormal: {0}, ", IsAbnormal);

            builder.AppendFormat("WarningRange: {0}, ", WarningRange);
            builder.AppendFormat("MucNguyHiemMin: {0}, ", MucNguyHiemMin);
            builder.AppendFormat("MucNguyHiemMax: {0}, ", MucNguyHiemMax);
            builder.AppendFormat("NguyHiem: {0}, ", NguyHiem);
            builder.AppendFormat("IsWarning: {0}, ", IsWarning);
            builder.AppendFormat("NgayThucHien: {0}, ", NgayThucHien);

            builder.AppendFormat("UserIdValid: {0}, ", UserIdValid);
            builder.AppendFormat("UserValid: {0}, ", UserValid);
            builder.AppendFormat("DistinctSID: {0}, ", DistinctSID);
            builder.AppendFormat("InTime: {0}, ", InTime);
            builder.AppendFormat("TypeSHPT: {0}, ", TypeSHPT);

            builder.Append("}");
            return builder.ToString();
        }
    }
}
