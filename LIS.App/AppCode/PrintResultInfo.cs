using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.App.AppCode
{
    public class PrintResultInfo
    {
        public string matiepnhan { get; set; }
        public bool inTheoBS { get; set; }
        public string conditSomeTestPrint { get; set; }
        public string boPhan { get; set; }
        public bool print { get; set; }
        public bool showMess { get; set; }
        public bool inCoQuiDoi { get; set; }
        public string printerName { get; set; }
        public bool inMau { get; set; }
        public string userSign { get; set; }
        public List<CAUHINH_MAYINKETQUA> ListCauHinhMayIn { get; set; }
        public ToolStripProgressBar progressPrint { get; set; }
        public byte[] imgLogo { get; set; }
        public string idNgonNgu { get; set; }
        public string idReport { get; set; }
        public bool exportPdf { get; set; }
        public List<string> pdfPathList { get; set; }
        public bool suDungChuKySo { get; set; }
        public bool in2Mat { get; set; }
        public bool xemlaiChuKySo { get; set; }
        public KieuKySo kieuKyTen { get; set; }
        public string idChuKy { get; set; }
        public string ghiChu { get; set; }
        public bool intheoNhomIn { get; set; }
        public bool inTheoOngMau { get; set; }
        public bool intheoUserValid { get; set; }
        public bool userValidTheoUserDangNhap { get; set; }
        public bool isAutoPrint { get; set; }
        public bool title { get; set; }
        public DateTime? ngayIn { get; set; }
        public List<string> reportType { get; set; }
        public TestType.EnumTestType[] arrLoaiXetNghiem { get; set; }
        public bool inlai { get; set; }
        public string category { get; set; }
        public bool chiInCoKetQua { get; internal set; }
        public string soPhieuChiDinh { get; internal set; }
        public object tenlanhdao { get; internal set; }
        public object chuvuLanhdao { get; internal set; }
        public string mauChonIn { get; internal set; }
    }
    public class PrintResultFinishInfo
    {
        public bool coDaDuyet { get; set; }
        public bool havePrint { get; set; }
    }
}
