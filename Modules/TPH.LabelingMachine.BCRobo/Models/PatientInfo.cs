using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace TPH.LabelingMachine.BCRobo.Models
{
    /// <summary>
    /// Thông tin bệnh nhân
    /// </summary>
    [Serializable()]
    [DataContract]
    public class PatientInfo
    {
        /// <summary>
        /// Mã bệnh nhân
        /// </summary>
        [DataMember]
        public string PatientId { get; set; }

        /// <summary>
        /// Mã y tế của bệnh nhân
        /// </summary>
        [DataMember]
        public string MaYTe { get; set; }

        /// <summary>
        /// Số bảo hiểm của bệnh nhân
        /// </summary>
        [DataMember]
        public string InsureNumber { get; set; }

        /// <summary>
        /// Phòng của bệnh nhân
        /// </summary>
        [DataMember]
        public string Bed { get; set; }

        /// <summary>
        /// ID hệ thống của phiếu yêu cầu
        /// </summary>
        [DataMember]
        public string OrderId { get; set; }

        /// <summary>
        /// Mã code của phiếu yêu cầu
        /// </summary>
        [DataMember]
        public string OrderCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SampleId { get; set; }

        [DataMember]
        public string Sequence { get; set; }
        /// <summary>
        /// STT Bệnh nhân trong ngày
        /// </summary>
        [DataMember]
        public string SttPatient { get; set; }

        /// <summary>
        /// Họ và tên bệnh nhân
        /// </summary>
        [DataMember]
        public string HoTen { get; set; }

        /// <summary>
        /// Thời gian chỉ định format datetime
        /// </summary>
        [XmlIgnore]
        [IgnoreDataMember]
        public DateTime GioChiDinh_DateTime { get; set; }

        /// <summary>
        /// Thời gian chỉ định
        /// </summary>
        [XmlElement("GioChiDinh")]
        [DataMember]
        public string GioChiDinh
        {
            get
            {
                return GioChiDinh_DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime result = DateTime.Now;

                if (DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    GioChiDinh_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy.MM.dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    GioChiDinh_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yy.MM.dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    GioChiDinh_DateTime = result;
                }
                else
                {
                    throw new Exception("GioChiDinh is not a valid format.");
                }
            }
        }

        /// <summary>
        /// Giới tính, Nam=M, Nữ=F
        /// </summary>
        [DataMember]
        public string GioiTinh { get; set; }

        /// <summary>
        /// Năm sinh
        /// </summary>
        [DataMember]
        public int NamSinh { get; set; }

        /// <summary>
        /// Ngày tháng năm sinh format datetime
        /// </summary>
        [XmlIgnore]
        [IgnoreDataMember]
        public DateTime? NgaySinh_DateTime { get; set; }

        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        [XmlElement("NgaySinh")]
        [DataMember]
        public string NgaySinh
        {
            get
            {
                if (NgaySinh_DateTime != null)
                {
                    return NgaySinh_DateTime.GetValueOrDefault().ToString("yyyy-MM-dd");
                }
                return null;
            }
            set
            {
                DateTime result = DateTime.Now;
                NgaySinh_DateTime = null;
                if (DateTime.TryParseExact(value, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    NgaySinh_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "yyyy/MM/dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    NgaySinh_DateTime = result;
                }
                else if (DateTime.TryParseExact(value, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    NgaySinh_DateTime = result;
                }
            }
        }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Mã bác sĩ hoặc id bác sỉ chỉ định
        /// </summary>
        [DataMember]
        public string MaBSChiDinh { get; set; }
        /// <summary>
        /// Mã bác sĩ hoặc id bác sỉ chỉ định
        /// </summary>
        [DataMember]
        public string SoDienThoai { get; set; }

        /// <summary>
        /// Tên bác sĩ chỉ định
        /// </summary>
        [DataMember]
        public string DoctorName { get; set; }

        /// <summary>
        /// Nội dung chẩn đoán
        /// </summary>
        [DataMember]
        public string ChanDoan { get; set; }

        /// <summary>
        /// Mã hoặc id đối tượng bệnh nhân
        /// </summary>
        [DataMember]
        public string MaDoiTuong { get; set; }

        /// <summary>
        /// Tên đối tượng bệnh nhân
        /// </summary>
        [DataMember]
        public string ObjectName { get; set; }

        /// <summary>
        /// Mã khoa phòng của bệnh nhân
        /// </summary>
        [DataMember]
        public string MaKhoaPhong { get; set; }

        /// <summary>
        /// Tên khoa phòng
        /// </summary>
        [DataMember]
        public string LocationName { get; set; }

        /// <summary>
        /// Bệnh nhân cấp cứu hay không 
        /// </summary>
        [DataMember]
        public bool CapCuu { get; set; }
        /// <summary>
        /// Bệnh nhân khám sức khỏe
        /// </summary>
        [DataMember]
        public bool KSK { get; set; }
        /// <summary>
        /// Mã nơi tiếp nhận
        /// </summary>
        [DataMember]
        public string ReceptionLocationId { get; set; }

        /// <summary>
        /// Tên nơi tiếp nhận
        /// </summary>
        [DataMember]
        public string ReceptionLocationName { get; set; }

        /// <summary>
        /// Bệnh nhân ngoại trú/nội trú
        /// </summary>
        [DataMember]
        public bool InPatient { get; set; }

        ///// <summary>
        ///// Thời gian valid kết quả
        ///// </summary>
        //[DataMember]
        //public DateTime? PatientValidTime { get; set; }

        /// <summary>
        /// Thời gian valid kết quả
        /// </summary>
        [DataMember]
        public string PatientValidTime { get; set; }

        /// <summary>
        /// Mã user valid kết quả
        /// </summary>
        [DataMember]
        public string PatientUserIdValid { get; set; }

        /// <summary>
        /// Tên user valid kết quả
        /// </summary>
        [DataMember]
        public string PatientUserValid { get; set; }

        /// <summary>
        /// Người lấy mẫu
        /// </summary>
        [DataMember]
        public string UserGet { get; set; }

        /// <summary>
        /// Thời gian lấy mẫu
        /// </summary>
        [DataMember]
        public DateTime? DateGet { get; set; }

        /// <summary>
        /// Người nhận mẫu
        /// </summary>
        [DataMember]
        public string Receiver { get; set; }

        /// <summary>
        /// Thời gian nhận mẫu
        /// </summary>
        [DataMember]
        public DateTime? DateReceiving { get; set; }

        /// <summary>
        /// Loại mẫu
        /// </summary>
        [DataMember]
        public string TypeName { get; set; }

        /// <summary>
        /// Mã bác sĩ hoặc id bác sỉ chỉ định
        /// </summary>
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// Danh sách chỉ định
        /// </summary>
        [DataMember]
        public List<TestResult> ListTestResult { get; set; }

        /// <summary>
        /// Danh sách thông tin bổ sung
        /// </summary>
        [DataMember]
        public List<PatientInfoAdditionalInfo> ListAdditionalInfo { get; set; }

        /// <summary>
        /// Danh sách kết quả và chỉ định vi sinh có liên quan đến soi cấy và kháng sinh đồ
        /// </summary>
        [DataMember]
        public List<ViSinhTestResult> ListViSinhTestResult { get; set; }

        public PatientInfo()
        {
            ListTestResult = new List<TestResult>();
            ListViSinhTestResult = new List<ViSinhTestResult>();
            ListAdditionalInfo = new List<PatientInfoAdditionalInfo>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("{");
            builder.AppendFormat("PatientId: {0}, ", PatientId);
            builder.AppendFormat("MaYTe: {0}, ", MaYTe);
            builder.AppendFormat("InsureNumber: {0}, ", InsureNumber);
            builder.AppendFormat("Bed: {0}, ", Bed);
            builder.AppendFormat("SampleId: {0}, ", SampleId);
            builder.AppendFormat("OrderId: {0}, ", OrderId);
            builder.AppendFormat("HoTen: {0}, ", HoTen);
            builder.AppendFormat("GioChiDinh: {0}, ", GioChiDinh);
            builder.AppendFormat("GioiTinh: {0}, ", GioiTinh);
            builder.AppendFormat("NamSinh: {0}, ", NamSinh);
            builder.AppendFormat("Address: {0}, ", Address);
            builder.AppendFormat("MaBSChiDinh: {0}, ", MaBSChiDinh);
            builder.AppendFormat("ChanDoan: {0}, ", ChanDoan);
            builder.AppendFormat("MaDoiTuong: {0}, ", MaDoiTuong);
            builder.AppendFormat("MaKhoaPhong: {0}, ", MaKhoaPhong);
            builder.AppendFormat("OrderCode: {0}, ", OrderCode);
            builder.AppendFormat("LocationName: {0}, ", LocationName);
            builder.AppendFormat("CapCuu: {0}, ", CapCuu);
            builder.AppendFormat("InPatient: {0}, ", InPatient);
            builder.Append("ListTestResult: [");
            if (ListTestResult != null)
            {
                foreach (var item in ListTestResult)
                {
                    builder.AppendFormat("{0}, ", item);
                }
            }
            builder.Append("],");
            builder.Append("ListAdditionalInfo: [");
            if (ListAdditionalInfo != null)
            {
                foreach (var item in ListAdditionalInfo)
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