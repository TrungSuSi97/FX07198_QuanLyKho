using System;
using System.Collections.Generic;

namespace TPH.Lab.Middleware.HISConnect.Models
{
    #region Standard order information
    public class OrderInfo
    {
        public string SoPhieuYeuCau { get; set; }
        public bool InternalPatient { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDateTo { get; set; }
        public int LisGetStatus { get; set; }
        public string PatientID { get; set; }
        public string SampleID { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string PatientName { get; set; }
        public DateTime DateReceive { get; set; }
        public string InsuranceID { get; set; }
        public string DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Diagnostic { get; set; }
        public string KetLuan { get; set; }
    }
    public class OrderTestInfo
    {
        public DateTime DateOfOrderDetail { get; set; }
        public string HisOrderId { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
        public string NormalRange { get; set; }
        public bool Abnormal { get; set; }
        public bool UPD { get; set; }
        public string ResultQualitative { get; set; }
        public string ResultQuantitative { get; set; }
        public string Unit { get; set; }
        public string Machine { get; set; }
        public DateTime DateTimeResult { get; set; }
        public string Modules { get; set; }
        public int OrderNumber { get; set; }
        public int SampleGetted { get; set; }
        public string Comment { get; set; }
        public string ResultNumber { get; set; }
        public string UserOrder { get; set; }
    }
    #endregion
    #region Inherit from standard order information 
    //Đại học Cần Thơ
    public class DaiHocCanTho_ResultInfo
    {
        public int KetQuaXetNghiemId { get; set; }
        public string CLS_SOPHIEU { get; set; }
        public int CLS_CHIDINH_ID { get; set; }
        public int CLS_CHIDINH_CHITIET_CLS_ID { get; set; }
        public int BANGKE_ID { get; set; }
        public int BANGKE_CHIPHI_ID { get; set; }
        public int IDBENH { get; set; }
        public int IDNHOMCHUCNANGCLS { get; set; }
        public int IDLOAICHUCNANGCLS { get; set; }
        public string CLS_TENLOAICLS { get; set; }
        public DateTime CLS_KQ_NGAYLAP { get; set; }
        public int IDNHOMNOIDUNGCLS { get; set; }
        public int IDNOIDUNGCLS { get; set; }
        public string KETQUA1 { get; set; }
        public string KETQUA2 { get; set; }
        public string KETQUA3 { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class DaiHocCanTho_OrderInfo : OrderInfo
    {
        public List<OrderTestInfo> OrderTest { get; set; }
        public List<DaiHocCanTho_ResultInfo> resultInfo { get; set; }
        public DaiHocCanTho_OrderInfo()
        {
            OrderTest = new List<Models.OrderTestInfo>();
            resultInfo = new List<Models.DaiHocCanTho_ResultInfo>();
        }
    }
    // DH Hospital
    public class DHHospital_OrderTestInfo : OrderTestInfo
    {
        public int manv_chidinh { get; set; }
        public string thangkt { get; set; }
        public string namkt { get; set; }
        public string maloai { get; set; }
    }
    public class DHHospital_ResultInfo
    {
        public int mabn { get; set; }
        public string maloai { get; set; }
        public int manv_chidinh { get; set; }
        public int manv_thuchien { get; set; }
        public string thangkt { get; set; }
        public string namkt { get; set; }
        public int sophieuyeucau { get; set; }
        public int madichvu { get; set; }
        public DateTime ngaychidinh { get; set; }
        public int ketqua { get; set; }
        public string chisobinhthuong { get; set; }
        public int batthuong { get; set; }
    }
    public class DHHospital_OrderInfo: OrderInfo
    {
        public List<OrderTestInfo> OrderTest { get; set; }
        public List<DHHospital_ResultInfo> resultInfo { get; set; }
        public DHHospital_OrderInfo()
        {
            OrderTest = new List<Models.OrderTestInfo>();
            resultInfo = new List<Models.DHHospital_ResultInfo>();
        }
    }
    #endregion
}
