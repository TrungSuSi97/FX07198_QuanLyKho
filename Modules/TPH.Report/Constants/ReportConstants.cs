using System.Collections.Generic;

namespace TPH.Report.Constants
{
    public class ReportConstants
    {
        public static string KetQuaXnThuongQuy_Chung = "KetQuaXnThuongQuy_Chung";
        public static string KetQuaXnISO_Chung = "KetQuaXnISO_Chung";
        public static string KetQuaXnISO_ABO = "KetQuaXnISO_ABO";
        public static string KetQuaXnISO_SHPT_ThuongQuy = "KetQuaXnISO_SHPT_ThuongQuy";
        public static string KetQuaXn_VIP = "KetQuaXn_VIP";
        public static string KetQuaXn_HIV = "KetQuaXn_HIV";
        public static string PhieuHen = "PhieuHen";
        public static string PhieuHenSLSS = "PhieuHenSLSS";
        public static string KetQuaXnSHPT_1 = "KetQuaXnSHPT_1";
        public static string KetQuaXnSHPT_2 = "KetQuaXnSHPT_2";
        public static string KetQuaXnSHPT_3 = "KetQuaXnSHPT_3";
        public static string KetQuaXnSHPT_4 = "KetQuaXnSHPT_4";
        public static string KetQuaXnSHPT_5 = "KetQuaXnSHPT_5";
        public static string KetQuaXnSHPT_5E = "KetQuaXnSHPT_5E";
        public static string KetQuaXnSHPT_5J = "KetQuaXnSHPT_5J";
        public static string KetQuaXnSHPT_5C = "KetQuaXnSHPT_5C";
        public static string KetQuaXnSHPT_5F = "KetQuaXnSHPT_5F";
        public static string KetQuaXn_PhieuChuyen = "KetQuaXn_PhieuChuyen";
        public static string KetQuaXn_PhieuNhan = "KetQuaXn_PhieuNhan";
        public static string KetQuaXnViSinhNuoiCay = "KetQuaXnViSinhNuoiCay";
        public static string PhieuTienTrinhViSinh = "PhieuTienTrinhViSinh";
        public static string BaoCaoLuuHuyMau = "BaoCaoLuuHuyMau";
        public static string BaoCaoLuuHuyMau_Vitri = "BaoCaoLuuHuyMau_Vitri";
        public static string BaoCaoLuuMau = "BaoCaoLuuMau";
        public static string BaoCaoLuuMau_Vitri = "BaoCaoLuuMau_Vitri";
        public static string LabBlood_PhieuLinh = "LabBlood_PhieuLinh";
        public static string LabBlood_PhieuLinh_XNThem = "LabBlood_PhieuLinh_XNThem";
        public static string LabBlood_PhieuLinh_TuiMau = "LabBlood_PhieuLinh_TuiMau";
        public static string LabBlood_PhieuTDTruyenMau = "LabBlood_PhieuTDTruyenMau";
        public static string LabBlood_PhieuTDTruyenMau_TuiMau = "LabBlood_PhieuTDTruyenMau_TuiMau";
        public static string IQC_BieuDoYouden = "IQC_BieuDoYouden";
        public static string IQC_BieuDoLeveyJennings2Col = "IQC_BieuDoLeveyJennings2Col";
        public static string IQC_BieuDoLeveyJennings = "IQC_BieuDoLeveyJennings";
        public static string IQC_BieuDoLeveyJenningsNgang = "IQC_BieuDoLeveyJenningsNgang";
        public static string IQC_Lot = "IQC_Lot";
        public static string IQC_LotTest = "IQC_LotTest";
        public static string IQC_LotPoint = "IQC_LotPoint";
        public static string IQC_InternalQCLog = "IQC_InternalQCLog";
        public static string IQC_InternalQCLogCard = "IQC_InternalQCLogCard";
        public static string IQC_InternalQCLogDayToColumn = "IQC_InternalQCLogDayToColumn";
        public static string IQC_NonConformity = "IQC_NonConformity";
        public static string KetQuaXn_BBChocHutTuy = "KetQuaXn_BBChocHutTuy";
        public static string DanhSachChiDinh = "DanhSachChiDinh";
        public static string DanhSachChiDinhNhanMau = "DanhSachChiDinhNhanMau";
        public static string BienLaiThuTien = "BienLaiThuTien";
        public static string DanhSachGuiMau = "DanhSachGuiMau";

    }
    public enum EnumReportApp
    {
        LabIMS = 0,
        LabBlood = 1,
        FBlood = 2,
        IQC = 3,
        AnaPath = 4
    }
    public class ReportAppType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<ReportAppType> ListReportApp()
        {
            var list = new List<ReportAppType>();
            list.Add(new ReportAppType
            {
                ID = (int)EnumReportApp.LabIMS,
                Name = string.Format("{0} - TPH.LabIMS", (int)EnumReportApp.LabIMS)
            });
            list.Add(new ReportAppType
            {
                ID = (int)EnumReportApp.LabBlood,
                Name = string.Format("{0} - TPH.LabBlood", (int)EnumReportApp.LabBlood)
            });
            list.Add(new ReportAppType
            {
                ID = (int)EnumReportApp.FBlood,
                Name = string.Format("{0} - TPH.FBlood", (int)EnumReportApp.FBlood)
            });
            list.Add(new ReportAppType
            {
                ID = (int)EnumReportApp.IQC,
                Name = string.Format("{0} - TPH.IQC", (int)EnumReportApp.IQC)
            });
            list.Add(new ReportAppType
            {
                ID = (int)EnumReportApp.AnaPath,
                Name = string.Format("{0} - TPH.AnaPath", (int)EnumReportApp.AnaPath)
            });
            return list;
        }
    }
}
