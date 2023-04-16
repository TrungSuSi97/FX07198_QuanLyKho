using System.Collections.Generic;
using System.ComponentModel;
using TPH.Language;

namespace TPH.LIS.Common
{

    public class RepportPaper
    {
        public enum ReportPaperSize
        {
            None = 0,
            A4 = 1,
            A4_5 = 2,
            A5 = 3
        }
        public ReportPaperSize PaperID { get; set; }
        public string PaperName{ get; set; }
        public static List<RepportPaper> ListReportPaperSize()
        {
            var list = new List<RepportPaper>();
            list.Add(new RepportPaper
            {
                PaperID = ReportPaperSize.None,
                PaperName = "---None---"
            });
            list.Add(new RepportPaper
            {
                PaperID = ReportPaperSize.A4,
                PaperName = "Giấy A4"
            });
            list.Add(new RepportPaper
            {
                PaperID = ReportPaperSize.A4_5,
                PaperName = "Giấy A5 (Không chuẩn)"
            });
            list.Add(new RepportPaper
            {
                PaperID = ReportPaperSize.A5,
                PaperName = "Giấy A5"
            });
            return list;
        }
    }
    public enum EnumReportResultTemplatetype
    {
        MauKetQua_ThongThuong = 0,
        MauKetQua_BYT = 1,
        MauKetQua_ISO = 2
    }
    public enum EnumLoaiKetNoiMay
    {
        ThongThuong = 0,
        CoPhanMemTrungGian = 1
    }
    public enum EnumKieuLayKetQuaMay
    {
        TatCa = 0,
        ChiTuPhanMemTrungGian = 1,
        ChiTuMayThongThuong = 2
    }
    public class Gender
    {
        [Description("Nam")]
        public const string Nam = "M";
        [Description("Nữ")]
        public const string Nu = "F";
        [Description("Không xác định")]
        public const string KXD = "?";
        public static Dictionary<string, string> GenderList = new Dictionary<string, string>()
        {
                        //{Nam , "Nam"},
                        //{Nu , "Nữ"},
                        //{KXD , "K. xác định"}
                        {Nam ,    LanguageExtension.GetResourceValueFromValue("Nam",
                        LanguageExtension.AppLanguage)},
                        {Nu , LanguageExtension.GetResourceValueFromValue("Nữ",
                        LanguageExtension.AppLanguage)},
                        {KXD , LanguageExtension.GetResourceValueFromValue("K. xác định",
                        LanguageExtension.AppLanguage)}
        };
    }
    public class ReportResultTemplateConstant
    {
        [Description("TẤT CẢ PHIẾU IN")]
        public const string Mau_TC_TatCa = "Mau_TC_TatCa";
        [Description("PHIẾU IN CHUẨN THƯỜNG QUI")]
        public const string Mau_TC_ThongThuong = "Mau_TC_ThongThuong";
        [Description("PHIẾU IN CHUẨN VI SINH -THƯỜNG QUI")]
        public const string Mau_TC_ViSinh_TQ = "Mau_TC_ViSinh_TQ";
        [Description("PHIẾU XÉT NGHIỆM - BỆNH PHẨM ......")]
        public const string Mau_BYT_27BV01 = "Mau_BYT_27BV01";
        [Description("PHIẾU XÉT NGHIỆM - NỒNG ĐỘ CỒN")]
        public const string Mau_BYT_27BV01_ETHA = "Mau_BYT_27BV01_ETHA";
        [Description("PHIẾU XÉT NGHIỆM - NƯỚC TIỂU (G)")]
        public const string Mau_BYT_27BV01_2 = "Mau_BYT_27BV01_2";
        [Description("PHIẾU XÉT NGHIỆM - Vi sinh (Thường qui)")]
        public const string Mau_BYT_27BV01_VSTQ = "Mau_BYT_27BV01_VSTQ";
        [Description("BYT - PHIẾU XÉT NGHIỆM HUYẾT HỌC")]
        public const string Mau_BYT_28BV01 = "MauBYT_28BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM HIV")]
        public const string Mau_BYT_3A = "Mau_BYT_3A";
        [Description("BYT - PHIẾU XÉT NGHIỆM HUYẾT - TUỶ ĐỒ")]
        public const string Mau_BYT_29BV01 = "Mau_BYT_29BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM CHẨN ĐOÁN RỐI LOẠN ĐÔNG CẦM MÁU")]
        public const string Mau_BYT_30BV01 = "Mau_BYT_30BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM SINH THIẾT TUỶ XƯƠNG")]
        public const string Mau_BYT_31BV01 = "Mau_BYT_31BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM TẾ BÀO NƯỚC DỊCH")]
        public const string Mau_BYT_32BV01 = "Mau_BYT_32BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM HOÁ SINH MÁU")]
        public const string Mau_BYT_33BV01 = "Mau_BYT_33BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM NƯỚC TIỂU")]
        public const string Mau_BYT_34BV01 = "Mau_BYT_34BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM HOÁ SINH NƯỚC TIỂU, PHÂN, DỊCH CHỌC DÒ")]
        public const string Mau_BYT_34BV01_2 = "Mau_BYT_34BV01_2";
        [Description("BYT - PHIẾU XÉT NGHIỆM VI SINH")]
        public const string Mau_BYT_35BV01 = "Mau_BYT_35BV01";
        [Description("BYT - PHIẾU XÉT NGHIỆM GIẢI PHẪU BỆNH SINH THIẾT")]
        public const string Mau_BYT_36BV01 = "Mau_BYT_36BV01";
        [Description("TQ - PHIẾU XÉT NGHIỆM ABO Có hình GELCARD")]
        public const string Mau_TQ_ABO_ISO = "Mau_TQ_ABO_ISO";
        public static Dictionary<string, string> ReportResultTemplateConstantList = new Dictionary<string, string>()
        {
                        {Mau_TC_ThongThuong , "CHUẨN - THƯỜNG QUI"},
                        {Mau_TC_ViSinh_TQ , "CHUẨN - VI SINH (THƯỜNG QUI)"},
                        {Mau_BYT_27BV01 , "BYT - PHIẾU XÉT NGHIỆM - BỆNH PHẨM ......"},
                        {Mau_BYT_27BV01_ETHA , "BYT - PHIẾU XÉT NGHIỆM - NỒNG ĐỘ CỒN"},
                        {Mau_BYT_27BV01_2 , "BYT - PHIẾU XÉT NGHIỆM - NƯỚC TIỂU (G)"},
                        {Mau_BYT_27BV01_VSTQ , "BYT - PHIẾU XÉT NGHIỆM - VS Thường qui"},
                        {Mau_BYT_28BV01 , "BYT - HUYẾT HỌC"},
                        {Mau_BYT_29BV01 , "BYT - HUYẾT - TUỶ ĐỒ"},
                        {Mau_BYT_3A , "BYT - HIV"},
                        {Mau_BYT_30BV01 , "BYT - ĐÔNG CẦM MÁU"},
                        {Mau_BYT_31BV01 , "BYT - SINH THIẾT TUỶ XƯƠNG"},
                        {Mau_BYT_32BV01 , "BYT - XÉT NGHIỆM TẾ BÀO NƯỚC DỊCH"},
                        {Mau_BYT_33BV01 , "BYT - XÉT NGHIỆM HOÁ SINH MÁU"},
                        {Mau_BYT_34BV01 , "BYT - XÉT NGHIỆM HOÁ SINH NƯỚC TIỂU"},
                        {Mau_BYT_34BV01_2 , "BYT - XÉT NGHIỆM HOÁ SINH NƯỚC TIỂU, PHÂN, DỊCH CHỌC DÒ"},
                        {Mau_BYT_35BV01 , "BYT - XÉT NGHIỆM VI SINH"},
                        {Mau_BYT_36BV01 , "BYT - XÉT NGHIỆM GIẢI PHẪU BỆNH SINH THIẾT"},
                        {Mau_TQ_ABO_ISO , "TQ - PHIẾU XÉT NGHIỆM ABO Có hình GELCARD"}
        };
    }
    public class ReportResultPositionConstant
    {
        public const string KQ_None_Column = "KQ_None_Column";
        //Qui ước: L: Trái (Left) - R: Phải (right) - M: Giữa (Middle)
        //G : Trong lưới (Grid) - O: Ngoài lưới (Out)
        //Các const {LoaiConstant}_{ViTriCot}_{ViTriLuoi}_{ViTriDong}
        public const string KQ_L_G_01 = "KQ_L_G_01";
        public const string KQ_L_G_02 = "KQ_L_G_02";
        public const string KQ_L_G_03 = "KQ_L_G_03";
        public const string KQ_L_G_04 = "KQ_L_G_04";
        public const string KQ_L_G_05 = "KQ_L_G_05";
        public const string KQ_L_G_06 = "KQ_L_G_06";
        public const string KQ_L_G_07 = "KQ_L_G_07";
        public const string KQ_L_G_08 = "KQ_L_G_08";
        public const string KQ_L_G_09 = "KQ_L_G_09";
        public const string KQ_L_G_10 = "KQ_L_G_10";
        public const string KQ_L_G_11 = "KQ_L_G_11";
        public const string KQ_L_G_12 = "KQ_L_G_12";
        public const string KQ_L_G_13 = "KQ_L_G_13";
        public const string KQ_L_G_14 = "KQ_L_G_14";
        public const string KQ_L_G_15 = "KQ_L_G_15";
        public const string KQ_L_G_16 = "KQ_L_G_16";
        public const string KQ_L_G_17 = "KQ_L_G_17";
        public const string KQ_L_G_18 = "KQ_L_G_18";
        public const string KQ_L_G_19 = "KQ_L_G_19";
        public const string KQ_L_G_20 = "KQ_L_G_20";
        public const string KQ_L_G_21 = "KQ_L_G_21";
        public const string KQ_L_G_22 = "KQ_L_G_22";
        public const string KQ_L_G_23 = "KQ_L_G_23";
        public const string KQ_L_G_24 = "KQ_L_G_24";
        public const string KQ_L_G_25 = "KQ_L_G_25";
        public const string KQ_L_G_26 = "KQ_L_G_26";
        public const string KQ_L_G_27 = "KQ_L_G_27";
        public const string KQ_L_G_28 = "KQ_L_G_28";
        public const string KQ_L_G_29 = "KQ_L_G_29";
        public const string KQ_L_G_30 = "KQ_L_G_30";
        public const string KQ_L_G_31 = "KQ_L_G_31";
        public const string KQ_L_G_32 = "KQ_L_G_32";
        public const string KQ_L_G_33 = "KQ_L_G_33";
        public const string KQ_L_G_34 = "KQ_L_G_34";
        public const string KQ_L_G_35 = "KQ_L_G_35";
        public const string KQ_L_G_36 = "KQ_L_G_36";
        public const string KQ_L_G_37 = "KQ_L_G_37";
        public const string KQ_L_G_38 = "KQ_L_G_38";
        public const string KQ_L_G_39 = "KQ_L_G_39";
        public const string KQ_L_G_40 = "KQ_L_G_40";

        public const string KQ_R_G_01 = "KQ_R_G_01";
        public const string KQ_R_G_02 = "KQ_R_G_02";
        public const string KQ_R_G_03 = "KQ_R_G_03";
        public const string KQ_R_G_04 = "KQ_R_G_04";
        public const string KQ_R_G_05 = "KQ_R_G_05";
        public const string KQ_R_G_06 = "KQ_R_G_06";
        public const string KQ_R_G_07 = "KQ_R_G_07";
        public const string KQ_R_G_08 = "KQ_R_G_08";
        public const string KQ_R_G_09 = "KQ_R_G_09";
        public const string KQ_R_G_10 = "KQ_R_G_10";
        public const string KQ_R_G_11 = "KQ_R_G_11";
        public const string KQ_R_G_12 = "KQ_R_G_12";
        public const string KQ_R_G_13 = "KQ_R_G_13";
        public const string KQ_R_G_14 = "KQ_R_G_14";
        public const string KQ_R_G_15 = "KQ_R_G_15";
        public const string KQ_R_G_16 = "KQ_R_G_16";
        public const string KQ_R_G_17 = "KQ_R_G_17";
        public const string KQ_R_G_18 = "KQ_R_G_18";
        public const string KQ_R_G_19 = "KQ_R_G_19";
        public const string KQ_R_G_20 = "KQ_R_G_20";
        public const string KQ_R_G_21 = "KQ_R_G_21";
        public const string KQ_R_G_22 = "KQ_R_G_22";
        public const string KQ_R_G_23 = "KQ_R_G_23";
        public const string KQ_R_G_24 = "KQ_R_G_24";
        public const string KQ_R_G_25 = "KQ_R_G_25";
        public const string KQ_R_G_26 = "KQ_R_G_26";
        public const string KQ_R_G_27 = "KQ_R_G_27";
        public const string KQ_R_G_28 = "KQ_R_G_28";
        public const string KQ_R_G_29 = "KQ_R_G_29";
        public const string KQ_R_G_30 = "KQ_R_G_30";

        public const string KQ_R_G_31 = "KQ_R_G_31";
        public const string KQ_R_G_32 = "KQ_R_G_32";
        public const string KQ_R_G_33 = "KQ_R_G_33";
        public const string KQ_R_G_34 = "KQ_R_G_34";
        public const string KQ_R_G_35 = "KQ_R_G_35";
        public const string KQ_R_G_36 = "KQ_R_G_36";
        public const string KQ_R_G_37 = "KQ_R_G_37";
        public const string KQ_R_G_38 = "KQ_R_G_38";
        public const string KQ_R_G_39 = "KQ_R_G_39";
        public const string KQ_R_G_40 = "KQ_R_G_40";

        //public const string KQ_M_G_01 = "KQ_M_G_01";
        //public const string KQ_M_G_02 = "KQ_M_G_02";
        //public const string KQ_M_G_03 = "KQ_M_G_03";
        //public const string KQ_M_G_04 = "KQ_M_G_04";
        //public const string KQ_M_G_05 = "KQ_M_G_05";
        //public const string KQ_M_G_06 = "KQ_M_G_06";
        //public const string KQ_M_G_07 = "KQ_M_G_07";
        //public const string KQ_M_G_08 = "KQ_M_G_08";
        //public const string KQ_M_G_09 = "KQ_M_G_09";
        //public const string KQ_M_G_10 = "KQ_M_G_10";
        //public const string KQ_M_G_11 = "KQ_M_G_11";
        //public const string KQ_M_G_12 = "KQ_M_G_12";
        //public const string KQ_M_G_13 = "KQ_M_G_13";
        //public const string KQ_M_G_14 = "KQ_M_G_14";
        //public const string KQ_M_G_15 = "KQ_M_G_15";
        //public const string KQ_M_G_16 = "KQ_M_G_16";
        //public const string KQ_M_G_17 = "KQ_M_G_17";
        //public const string KQ_M_G_18 = "KQ_M_G_18";
        //public const string KQ_M_G_19 = "KQ_M_G_19";
        //public const string KQ_M_G_20 = "KQ_M_G_20";
        //public const string KQ_M_G_21 = "KQ_M_G_21";
        //public const string KQ_M_G_22 = "KQ_M_G_22";
        //public const string KQ_M_G_23 = "KQ_M_G_23";
        //public const string KQ_M_G_24 = "KQ_M_G_24";
        //public const string KQ_M_G_25 = "KQ_M_G_25";
        //public const string KQ_M_G_26 = "KQ_M_G_26";
        //public const string KQ_M_G_27 = "KQ_M_G_27";
        //public const string KQ_M_G_28 = "KQ_M_G_28";
        //public const string KQ_M_G_29 = "KQ_M_G_29";
        //public const string KQ_M_G_30 = "KQ_M_G_30";

        //Ngoài lưới
        public const string KQ_L_O_01 = "KQ_L_O_01";
        public const string KQ_L_O_02 = "KQ_L_O_02";
        public const string KQ_L_O_03 = "KQ_L_O_03";
        public const string KQ_L_O_04 = "KQ_L_O_04";
        public const string KQ_L_O_05 = "KQ_L_O_05";
        public const string KQ_L_O_06 = "KQ_L_O_06";
        public const string KQ_L_O_07 = "KQ_L_O_07";
        public const string KQ_L_O_08 = "KQ_L_O_08";
        public const string KQ_L_O_09 = "KQ_L_O_09";
        public const string KQ_L_O_10 = "KQ_L_O_10";
        //public const string KQ_L_O_11 = "KQ_L_O_11";
        //public const string KQ_L_O_12 = "KQ_L_O_12";
        //public const string KQ_L_O_13 = "KQ_L_O_13";
        //public const string KQ_L_O_14 = "KQ_L_O_14";
        //public const string KQ_L_O_15 = "KQ_L_O_15";
        //public const string KQ_L_O_16 = "KQ_L_O_16";
        //public const string KQ_L_O_17 = "KQ_L_O_17";
        //public const string KQ_L_O_18 = "KQ_L_O_18";
        //public const string KQ_L_O_19 = "KQ_L_O_19";
        //public const string KQ_L_O_20 = "KQ_L_O_20";
        //public const string KQ_L_O_21 = "KQ_L_O_21";
        //public const string KQ_L_O_22 = "KQ_L_O_22";
        //public const string KQ_L_O_23 = "KQ_L_O_23";
        //public const string KQ_L_O_24 = "KQ_L_O_24";
        //public const string KQ_L_O_25 = "KQ_L_O_25";
        //public const string KQ_L_O_26 = "KQ_L_O_26";
        //public const string KQ_L_O_27 = "KQ_L_O_27";
        //public const string KQ_L_O_28 = "KQ_L_O_28";
        //public const string KQ_L_O_29 = "KQ_L_O_29";
        //public const string KQ_L_O_30 = "KQ_L_O_30";

        public const string KQ_R_O_01 = "KQ_R_O_01";
        public const string KQ_R_O_02 = "KQ_R_O_02";
        public const string KQ_R_O_03 = "KQ_R_O_03";
        public const string KQ_R_O_04 = "KQ_R_O_04";
        public const string KQ_R_O_05 = "KQ_R_O_05";
        public const string KQ_R_O_06 = "KQ_R_O_06";
        public const string KQ_R_O_07 = "KQ_R_O_07";
        public const string KQ_R_O_08 = "KQ_R_O_08";
        public const string KQ_R_O_09 = "KQ_R_O_09";
        public const string KQ_R_O_10 = "KQ_R_O_10";
        //public const string KQ_R_O_11 = "KQ_R_O_11";
        //public const string KQ_R_O_12 = "KQ_R_O_12";
        //public const string KQ_R_O_13 = "KQ_R_O_13";
        //public const string KQ_R_O_14 = "KQ_R_O_14";
        //public const string KQ_R_O_15 = "KQ_R_O_15";
        //public const string KQ_R_O_16 = "KQ_R_O_16";
        //public const string KQ_R_O_17 = "KQ_R_O_17";
        //public const string KQ_R_O_18 = "KQ_R_O_18";
        //public const string KQ_R_O_19 = "KQ_R_O_19";
        //public const string KQ_R_O_20 = "KQ_R_O_20";
        //public const string KQ_R_O_21 = "KQ_R_O_21";
        //public const string KQ_R_O_22 = "KQ_R_O_22";
        //public const string KQ_R_O_23 = "KQ_R_O_23";
        //public const string KQ_R_O_24 = "KQ_R_O_24";
        //public const string KQ_R_O_25 = "KQ_R_O_25";
        //public const string KQ_R_O_26 = "KQ_R_O_26";
        //public const string KQ_R_O_27 = "KQ_R_O_27";
        //public const string KQ_R_O_28 = "KQ_R_O_28";
        //public const string KQ_R_O_29 = "KQ_R_O_29";
        //public const string KQ_R_O_30 = "KQ_R_O_30";

        //public const string KQ_M_O_01 = "KQ_M_O_01";
        //public const string KQ_M_O_02 = "KQ_M_O_02";
        //public const string KQ_M_O_03 = "KQ_M_O_03";
        //public const string KQ_M_O_04 = "KQ_M_O_04";
        //public const string KQ_M_O_05 = "KQ_M_O_05";
        //public const string KQ_M_O_06 = "KQ_M_O_06";
        //public const string KQ_M_O_07 = "KQ_M_O_07";
        //public const string KQ_M_O_08 = "KQ_M_O_08";
        //public const string KQ_M_O_09 = "KQ_M_O_09";
        //public const string KQ_M_O_10 = "KQ_M_O_10";
        //public const string KQ_M_O_11 = "KQ_M_O_11";
        //public const string KQ_M_O_12 = "KQ_M_O_12";
        //public const string KQ_M_O_13 = "KQ_M_O_13";
        //public const string KQ_M_O_14 = "KQ_M_O_14";
        //public const string KQ_M_O_15 = "KQ_M_O_15";
        //public const string KQ_M_O_16 = "KQ_M_O_16";
        //public const string KQ_M_O_17 = "KQ_M_O_17";
        //public const string KQ_M_O_18 = "KQ_M_O_18";
        //public const string KQ_M_O_19 = "KQ_M_O_19";
        //public const string KQ_M_O_20 = "KQ_M_O_20";
        //public const string KQ_M_O_21 = "KQ_M_O_21";
        //public const string KQ_M_O_22 = "KQ_M_O_22";
        //public const string KQ_M_O_23 = "KQ_M_O_23";
        //public const string KQ_M_O_24 = "KQ_M_O_24";
        //public const string KQ_M_O_25 = "KQ_M_O_25";
        //public const string KQ_M_O_26 = "KQ_M_O_26";
        //public const string KQ_M_O_27 = "KQ_M_O_27";
        //public const string KQ_M_O_28 = "KQ_M_O_28";
        //public const string KQ_M_O_29 = "KQ_M_O_29";
        //public const string KQ_M_O_30 = "KQ_M_O_30";

        public static Dictionary<string, string> ReportResultPositionConstantList = new Dictionary<string, string>()
        {
                                        {KQ_None_Column, "KQ_None_Column" },
                                        { KQ_L_G_01 , "KQ_L_G_01"},
                                        { KQ_L_G_02 , "KQ_L_G_02"},
                                        { KQ_L_G_03 , "KQ_L_G_03"},
                                        { KQ_L_G_04 , "KQ_L_G_04"},
                                        { KQ_L_G_05 , "KQ_L_G_05"},
                                        { KQ_L_G_06 , "KQ_L_G_06"},
                                        { KQ_L_G_07 , "KQ_L_G_07"},
                                        { KQ_L_G_08 , "KQ_L_G_08"},
                                        { KQ_L_G_09 , "KQ_L_G_09"},
                                        { KQ_L_G_10 , "KQ_L_G_10"},
                                        { KQ_L_G_11 , "KQ_L_G_11"},
                                        { KQ_L_G_12 , "KQ_L_G_12"},
                                        { KQ_L_G_13 , "KQ_L_G_13"},
                                        { KQ_L_G_14 , "KQ_L_G_14"},
                                        { KQ_L_G_15 , "KQ_L_G_15"},
                                        { KQ_L_G_16 , "KQ_L_G_16"},
                                        { KQ_L_G_17 , "KQ_L_G_17"},
                                        { KQ_L_G_18 , "KQ_L_G_18"},
                                        { KQ_L_G_19 , "KQ_L_G_19"},
                                        { KQ_L_G_20 , "KQ_L_G_20"},
                                        { KQ_L_G_21 , "KQ_L_G_21"},
                                        { KQ_L_G_22 , "KQ_L_G_22"},
                                        { KQ_L_G_23 , "KQ_L_G_23"},
                                        { KQ_L_G_24 , "KQ_L_G_24"},
                                        { KQ_L_G_25 , "KQ_L_G_25"},
                                        { KQ_L_G_26 , "KQ_L_G_26"},
                                        { KQ_L_G_27 , "KQ_L_G_27"},
                                        { KQ_L_G_28 , "KQ_L_G_28"},
                                        { KQ_L_G_29 , "KQ_L_G_29"},
                                        { KQ_L_G_30 , "KQ_L_G_30"},
                                        { KQ_L_G_31 , "KQ_L_G_31"},
                                        { KQ_L_G_32 , "KQ_L_G_32"},
                                        { KQ_L_G_33 , "KQ_L_G_33"},
                                        { KQ_L_G_34 , "KQ_L_G_34"},
                                        { KQ_L_G_35 , "KQ_L_G_35"},
                                        { KQ_L_G_36 , "KQ_L_G_36"},
                                        { KQ_L_G_37 , "KQ_L_G_37"},
                                        { KQ_L_G_38 , "KQ_L_G_38"},
                                        { KQ_L_G_39 , "KQ_L_G_39"},
                                        { KQ_L_G_40 , "KQ_L_G_40"},
                                        { KQ_R_G_01 , "KQ_R_G_01"},
                                        { KQ_R_G_02 , "KQ_R_G_02"},
                                        { KQ_R_G_03 , "KQ_R_G_03"},
                                        { KQ_R_G_04 , "KQ_R_G_04"},
                                        { KQ_R_G_05 , "KQ_R_G_05"},
                                        { KQ_R_G_06 , "KQ_R_G_06"},
                                        { KQ_R_G_07 , "KQ_R_G_07"},
                                        { KQ_R_G_08 , "KQ_R_G_08"},
                                        { KQ_R_G_09 , "KQ_R_G_09"},
                                        { KQ_R_G_10 , "KQ_R_G_10"},
                                        { KQ_R_G_11 , "KQ_R_G_11"},
                                        { KQ_R_G_12 , "KQ_R_G_12"},
                                        { KQ_R_G_13 , "KQ_R_G_13"},
                                        { KQ_R_G_14 , "KQ_R_G_14"},
                                        { KQ_R_G_15 , "KQ_R_G_15"},
                                        { KQ_R_G_16 , "KQ_R_G_16"},
                                        { KQ_R_G_17 , "KQ_R_G_17"},
                                        { KQ_R_G_18 , "KQ_R_G_18"},
                                        { KQ_R_G_19 , "KQ_R_G_19"},
                                        { KQ_R_G_20 , "KQ_R_G_20"},
                                        { KQ_R_G_21 , "KQ_R_G_21"},
                                        { KQ_R_G_22 , "KQ_R_G_22"},
                                        { KQ_R_G_23 , "KQ_R_G_23"},
                                        { KQ_R_G_24 , "KQ_R_G_24"},
                                        { KQ_R_G_25 , "KQ_R_G_25"},
                                        { KQ_R_G_26 , "KQ_R_G_26"},
                                        { KQ_R_G_27 , "KQ_R_G_27"},
                                        { KQ_R_G_28 , "KQ_R_G_28"},
                                        { KQ_R_G_29 , "KQ_R_G_29"},
                                        { KQ_R_G_30 , "KQ_R_G_30"},
                                        { KQ_R_G_31 , "KQ_R_G_31"},
                                        { KQ_R_G_32 , "KQ_R_G_32"},
                                        { KQ_R_G_33 , "KQ_R_G_33"},
                                        { KQ_R_G_34 , "KQ_R_G_34"},
                                        { KQ_R_G_35 , "KQ_R_G_35"},
                                        { KQ_R_G_36 , "KQ_R_G_36"},
                                        { KQ_R_G_37 , "KQ_R_G_37"},
                                        { KQ_R_G_38 , "KQ_R_G_38"},
                                        { KQ_R_G_39 , "KQ_R_G_39"},
                                        { KQ_R_G_40 , "KQ_R_G_40"},
                                        //{ KQ_M_G_01 , "KQ_M_G_01"},
                                        //{ KQ_M_G_02 , "KQ_M_G_02"},
                                        //{ KQ_M_G_03 , "KQ_M_G_03"},
                                        //{ KQ_M_G_04 , "KQ_M_G_04"},
                                        //{ KQ_M_G_05 , "KQ_M_G_05"},
                                        //{ KQ_M_G_06 , "KQ_M_G_06"},
                                        //{ KQ_M_G_07 , "KQ_M_G_07"},
                                        //{ KQ_M_G_08 , "KQ_M_G_08"},
                                        //{ KQ_M_G_09 , "KQ_M_G_09"},
                                        //{ KQ_M_G_10 , "KQ_M_G_10"},
                                        //{ KQ_M_G_11 , "KQ_M_G_11"},
                                        //{ KQ_M_G_12 , "KQ_M_G_12"},
                                        //{ KQ_M_G_13 , "KQ_M_G_13"},
                                        //{ KQ_M_G_14 , "KQ_M_G_14"},
                                        //{ KQ_M_G_15 , "KQ_M_G_15"},
                                        //{ KQ_M_G_16 , "KQ_M_G_16"},
                                        //{ KQ_M_G_17 , "KQ_M_G_17"},
                                        //{ KQ_M_G_18 , "KQ_M_G_18"},
                                        //{ KQ_M_G_19 , "KQ_M_G_19"},
                                        //{ KQ_M_G_20 , "KQ_M_G_20"},
                                        //{ KQ_M_G_21 , "KQ_M_G_21"},
                                        //{ KQ_M_G_22 , "KQ_M_G_22"},
                                        //{ KQ_M_G_23 , "KQ_M_G_23"},
                                        //{ KQ_M_G_24 , "KQ_M_G_24"},
                                        //{ KQ_M_G_25 , "KQ_M_G_25"},
                                        //{ KQ_M_G_26 , "KQ_M_G_26"},
                                        //{ KQ_M_G_27 , "KQ_M_G_27"},
                                        //{ KQ_M_G_28 , "KQ_M_G_28"},
                                        //{ KQ_M_G_29 , "KQ_M_G_29"},
                                        //{ KQ_M_G_30 , "KQ_M_G_30"},
                                        { KQ_L_O_01 , "KQ_L_O_01"},
                                        { KQ_L_O_02 , "KQ_L_O_02"},
                                        { KQ_L_O_03 , "KQ_L_O_03"},
                                        { KQ_L_O_04 , "KQ_L_O_04"},
                                        { KQ_L_O_05 , "KQ_L_O_05"},
                                        { KQ_L_O_06 , "KQ_L_O_06"},
                                        { KQ_L_O_07 , "KQ_L_O_07"},
                                        { KQ_L_O_08 , "KQ_L_O_08"},
                                        { KQ_L_O_09 , "KQ_L_O_09"},
                                        { KQ_L_O_10 , "KQ_L_O_10"},
                                        //{ KQ_L_O_11 , "KQ_L_O_11"},
                                        //{ KQ_L_O_12 , "KQ_L_O_12"},
                                        //{ KQ_L_O_13 , "KQ_L_O_13"},
                                        //{ KQ_L_O_14 , "KQ_L_O_14"},
                                        //{ KQ_L_O_15 , "KQ_L_O_15"},
                                        //{ KQ_L_O_16 , "KQ_L_O_16"},
                                        //{ KQ_L_O_17 , "KQ_L_O_17"},
                                        //{ KQ_L_O_18 , "KQ_L_O_18"},
                                        //{ KQ_L_O_19 , "KQ_L_O_19"},
                                        //{ KQ_L_O_20 , "KQ_L_O_20"},
                                        //{ KQ_L_O_21 , "KQ_L_O_21"},
                                        //{ KQ_L_O_22 , "KQ_L_O_22"},
                                        //{ KQ_L_O_23 , "KQ_L_O_23"},
                                        //{ KQ_L_O_24 , "KQ_L_O_24"},
                                        //{ KQ_L_O_25 , "KQ_L_O_25"},
                                        //{ KQ_L_O_26 , "KQ_L_O_26"},
                                        //{ KQ_L_O_27 , "KQ_L_O_27"},
                                        //{ KQ_L_O_28 , "KQ_L_O_28"},
                                        //{ KQ_L_O_29 , "KQ_L_O_29"},
                                        //{ KQ_L_O_30 , "KQ_L_O_30"},
                                        { KQ_R_O_01 , "KQ_R_O_01"},
                                        { KQ_R_O_02 , "KQ_R_O_02"},
                                        { KQ_R_O_03 , "KQ_R_O_03"},
                                        { KQ_R_O_04 , "KQ_R_O_04"},
                                        { KQ_R_O_05 , "KQ_R_O_05"},
                                        { KQ_R_O_06 , "KQ_R_O_06"},
                                        { KQ_R_O_07 , "KQ_R_O_07"},
                                        { KQ_R_O_08 , "KQ_R_O_08"},
                                        { KQ_R_O_09 , "KQ_R_O_09"},
                                        { KQ_R_O_10 , "KQ_R_O_10"}
                                        //{ KQ_R_O_11 , "KQ_R_O_11"},
                                        //{ KQ_R_O_12 , "KQ_R_O_12"},
                                        //{ KQ_R_O_13 , "KQ_R_O_13"},
                                        //{ KQ_R_O_14 , "KQ_R_O_14"},
                                        //{ KQ_R_O_15 , "KQ_R_O_15"},
                                        //{ KQ_R_O_16 , "KQ_R_O_16"},
                                        //{ KQ_R_O_17 , "KQ_R_O_17"},
                                        //{ KQ_R_O_18 , "KQ_R_O_18"},
                                        //{ KQ_R_O_19 , "KQ_R_O_19"},
                                        //{ KQ_R_O_20 , "KQ_R_O_20"},
                                        //{ KQ_R_O_21 , "KQ_R_O_21"},
                                        //{ KQ_R_O_22 , "KQ_R_O_22"},
                                        //{ KQ_R_O_23 , "KQ_R_O_23"},
                                        //{ KQ_R_O_24 , "KQ_R_O_24"},
                                        //{ KQ_R_O_25 , "KQ_R_O_25"},
                                        //{ KQ_R_O_26 , "KQ_R_O_26"},
                                        //{ KQ_R_O_27 , "KQ_R_O_27"},
                                        //{ KQ_R_O_28 , "KQ_R_O_28"},
                                        //{ KQ_R_O_29 , "KQ_R_O_29"},
                                        //{ KQ_R_O_30 , "KQ_R_O_30"},
                                        //{ KQ_M_O_01 , "KQ_M_O_01"},
                                        //{ KQ_M_O_02 , "KQ_M_O_02"},
                                        //{ KQ_M_O_03 , "KQ_M_O_03"},
                                        //{ KQ_M_O_04 , "KQ_M_O_04"},
                                        //{ KQ_M_O_05 , "KQ_M_O_05"},
                                        //{ KQ_M_O_06 , "KQ_M_O_06"},
                                        //{ KQ_M_O_07 , "KQ_M_O_07"},
                                        //{ KQ_M_O_08 , "KQ_M_O_08"},
                                        //{ KQ_M_O_09 , "KQ_M_O_09"},
                                        //{ KQ_M_O_10 , "KQ_M_O_10"},
                                        //{ KQ_M_O_11 , "KQ_M_O_11"},
                                        //{ KQ_M_O_12 , "KQ_M_O_12"},
                                        //{ KQ_M_O_13 , "KQ_M_O_13"},
                                        //{ KQ_M_O_14 , "KQ_M_O_14"},
                                        //{ KQ_M_O_15 , "KQ_M_O_15"},
                                        //{ KQ_M_O_16 , "KQ_M_O_16"},
                                        //{ KQ_M_O_17 , "KQ_M_O_17"},
                                        //{ KQ_M_O_18 , "KQ_M_O_18"},
                                        //{ KQ_M_O_19 , "KQ_M_O_19"},
                                        //{ KQ_M_O_20 , "KQ_M_O_20"},
                                        //{ KQ_M_O_21 , "KQ_M_O_21"},
                                        //{ KQ_M_O_22 , "KQ_M_O_22"},
                                        //{ KQ_M_O_23 , "KQ_M_O_23"},
                                        //{ KQ_M_O_24 , "KQ_M_O_24"},
                                        //{ KQ_M_O_25 , "KQ_M_O_25"},
                                        //{ KQ_M_O_26 , "KQ_M_O_26"},
                                        //{ KQ_M_O_27 , "KQ_M_O_27"},
                                        //{ KQ_M_O_28 , "KQ_M_O_28"},
                                        //{ KQ_M_O_29 , "KQ_M_O_29"},
                                        //{ KQ_M_O_30 , "KQ_M_O_30"}
        };
    }
    public class ReportMicrobiologyTemplateConstant
    {
        public enum EnumReportMicrobiologyTemplatetype
        {
            None = 0,
            Mau_1 = 1,
            Mau_2 = 2,
            Mau_3 = 3,
            Mau_4 = 4,
            Mau_5 = 5
        }
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public static List<ReportMicrobiologyTemplateConstant> ListReportType()
        {
            var list = new List<ReportMicrobiologyTemplateConstant>();
            list.Add(new ReportMicrobiologyTemplateConstant
            {
                ReportID = (int)EnumReportMicrobiologyTemplatetype.None,
                ReportName = "---None---"
            });
            list.Add(new ReportMicrobiologyTemplateConstant
            {
                ReportID = (int)EnumReportMicrobiologyTemplatetype.Mau_1,
                ReportName = "Mẫu 1"
            });
            list.Add(new ReportMicrobiologyTemplateConstant
            {
                ReportID = (int)EnumReportMicrobiologyTemplatetype.Mau_2,
                ReportName = "Mẫu 2"
            });
            list.Add(new ReportMicrobiologyTemplateConstant
            {
                ReportID = (int)EnumReportMicrobiologyTemplatetype.Mau_3,
                ReportName = "Mẫu 3"
            });
            list.Add(new ReportMicrobiologyTemplateConstant
            {
                ReportID = (int)EnumReportMicrobiologyTemplatetype.Mau_4,
                ReportName = "Mẫu 4"
            });
            list.Add(new ReportMicrobiologyTemplateConstant
            {
                ReportID = (int)EnumReportMicrobiologyTemplatetype.Mau_5,
                ReportName = "Mẫu 5"
            });
            return list;
        }
    }
}
