using System;

namespace TPH.Report.Models
{
    public class ReportModel
    {
        public string ReportId { get; set; }
        public byte[] ReportGoc { get; set; }
        public byte[] ReportSuDung { get; set; }
        public bool KichHoat { get; set; }
        public DateTime? NgayApDung { get; set; }
        public string NguoiApDung { get; set; }
        public string NguoiSua { get; set; }
        public DateTime? NgaySua { get; set; }
        public string PCSua { get; set; }
        public string TenDataset { get; set; }
        public string TenDatatable { get; set; }
        public string ReportSub1 { get; set; }
        public string TenDataSetSub1 { get; set; }
        public string TenDatatableSub1 { get; set; }

        public string ReportSub2 { get; set; }
        public string TenDataSetSub2 { get; set; }
        public string TenDatatableSub2 { get; set; }

    }
}
