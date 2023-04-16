using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.LIS.Common;

namespace TPH.LIS.Patient.Model
{
    public class SearchPatientCondit_XN
    {
        public DateTime? tungay { get; set; }
        public DateTime? denngay { get; set; }
        public string maDoiTuong { get; set; }
        public string tenBN { get; set; }
        public string barcode { get; set; }
        public string maBN { get; set; }
        public string sdt { get; set; }
        public string idCongDan { get; set; }
        public string sophieuHis { get; set; }
        public string khuTiepNhan { get; set; }
        public enumThucHien daNhanMau = enumThucHien.TatCa;
        public enumThucHien daLayMau = enumThucHien.TatCa;
        public enumThucHien daTraKQ = enumThucHien.TatCa;
        public enumThucHien daDuKQ = enumThucHien.TatCa;
        public enumThucHien dainKQ = enumThucHien.TatCa;
        public enumThucHien daXacNhanKQ = enumThucHien.TatCa;
        public TestType.EnumTestType[] testType = null;
        public string nguonnhap { get; set; }
        public string soHoSo { get; set; }
    }
    public class SearchPatientCondit
    {
        public DateTime? tungay { get; set; }
        public DateTime? denngay { get; set; }
        public string maDoiTuong { get; set; }
        public string tenBN { get; set; }
        public string barcode { get; set; }
        public string maBN { get; set; }
        public string sdt { get; set; }
        public string idCongDan { get; set; }
        public string sophieuHis { get; set; }
        public string soHoSo { get; set; }
        public string khuTiepNhan { get; set; }
        public string nguonnhap { get; set; }
    }
}
