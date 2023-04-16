using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using static TPH.LIS.BarcodePrinting.Constants.Loaibarcode;

namespace TPH.LIS.BarcodePrinting.Barcode
{
    public class BarcodeTubeDetail
    {
        // @idthongtin bigint -> lấy từ @iD ouput,
        // @tubecode varchar(25),
        // @tubecate varchar(35),
        // @tubename nvarchar(100),
        // @tubecount int

        public long DataRecordID { get; set; }
        public string Tubecode { get; set; }
        public string TubeCate { get; set; }
        public string TubeCateName { get; set; }
        public string Tubename { get; set; }
        public int TubeCount { get; set; }
        public string NguoiLayMau { get; set; }
        public DateTime? NgayLayMau { get; set; }
        public DateTime TgNhapBN { get; set; }
        public string NhomXetNghiem { get; set; }
        public string BoPhanXetNghiem { get; set; }
        public string Barcode { get; set; }
        public string BarcodeName { get; set; }
        public string KyTuDanhDau { get; set; }
        public string MaSoMau { get; set; }

        //tem 2
        public string Tubecode2 { get; set; }
        public string TubeCate2 { get; set; }
        public string TubeCateName2 { get; set; }
        public string Tubename2 { get; set; }
        public string NguoiLayMau2 { get; set; }
        public DateTime? NgayLayMau2 { get; set; }
        public DateTime TgNhapBN2 { get; set; }
        public string NhomXetNghiem2 { get; set; }
        public string BoPhanXetNghiem2 { get; set; }
        public string Barcode2 { get; set; }
        public string BarcodeName2 { get; set; }
        public string KyTuDanhDau2 { get; set; }
        public string MaSoMau2 { get; set; }
        public BarcodeTubeDetail CopyInfo()
        {
            return (BarcodeTubeDetail)this.MemberwiseClone();
        }
    }
    public class BarcodeProperties
    {
        // @sampleid varchar(20),
        // @seq int,
        // @patientid varchar(50),
        // @patientname nvarchar(150),
        // @patientnamenosign nvarchar(150),
        // @age int,
        // @sex char(1),
        // @idmay int,
        // @ID bigint output,
        public string PrinterProtocol = "TIEUCHUAN";
        public string PrintFilePath = "TPH.Lab.Barcode.btw";
        public long DataRecordID { get; set; }
        public int LableMachineID { get; set; }
        private int _numberOfCopy = 1;
        public EnumLoaiBarcode LoaiTem = EnumLoaiBarcode.ThongThuong;
        public bool BN_KSK { get; set; }
        public bool InGhepLoaiMau = false;
        public int NumberOfCopy
        {
            get { return _numberOfCopy; }
            set { _numberOfCopy = value; }
        }

        public DateTime TgNhapBN { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        private string _soBarcode = string.Empty;

        public string SoBarcode
        {
            get { return _soBarcode; }
            set { _soBarcode = value; }
        }
        private string _sid = string.Empty;

        public string Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        private string _patientName = string.Empty;

        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }
        private string _patientNameNosign = string.Empty;

        public string PatientNameNosign
        {
            get { return _patientNameNosign; }
            set { _patientNameNosign = value; }
        }

        private string _patientID = string.Empty;

        public string PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }
        private string _maKhoaPhong = string.Empty;
        public string MaKhoaPhong
        {
            get { return _maKhoaPhong; }
            set { _maKhoaPhong = value; }
        }

        private string _gioiTinh = string.Empty;

        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        private string _namSinh = string.Empty;

        public string NamSinh
        {
            get { return _namSinh; }
            set { _namSinh = value; }
        }
        private string _tenBarcode = string.Empty;

        public string TenBarcode
        {
            get { return _tenBarcode; }
            set { _tenBarcode = value; }
        }
        private string _soTT = string.Empty;
        public string SoTT
        {
            get
            {
                return _soTT;
            }
            set
            {
                _soTT = value;
            }
        }
        //.Replace("{ID}", bnInfo.Seq).Replace("{T}", dr["LoaiMau"].ToString().Trim());
        public string DinhDangTemGhepLoaiMau { get; set; }
        public string LoaiMauKhongInLenTem { get; set; }
        public int SoTemToiThieu = 0;
        public string DiaChi { get; set; }
        public List<BarcodeTubeDetail> DanhSachTube { get; set; }
        public string SoGiuong { get; set; }
        public bool CapCuu { get; set; }
        public string ChanDoan { get; set; }
        public string Comment { get; set; }
        public DateTime? DateReceiving { get; set; }
        public string TenBSChiDinh { get; set; }
        public string GioChiDinh { get; set; }
        public DateTime GioChiDinh_DateTime { get; set; }
        public bool NoiTru { get; set; }
        public string SoBHYT { get; set; }
        public string TenKhoaPhong { get; set; }
        public string MaBSChiDinh { get; set; }
        public string MaDoiTuongDichVu { get; set; }
        public string MaYTe { get; set; }
        public string NgaySinh { get; set; }
        public DateTime? NgaySinh_DateTime { get; set; }
        public string TenDoiTuongDichVu { get; set; }
        public string SoPhieuChiDinh { get; set; }
        public string SoHoSo { get; set; }
        public string IDPhieuChiDinh { get; set; }
        public string SoPhong { get; internal set; }
        public XtraReport BarcodeReport { get; set; }
        public string NormalreportprinterName = string.Empty;

        public BarcodeProperties CopyInfo()
        {
            return (BarcodeProperties)this.MemberwiseClone();
        }
    }
}
