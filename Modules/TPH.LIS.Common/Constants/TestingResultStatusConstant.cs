using System.Collections.Generic;
using TPH.Language;

namespace TPH.LIS.Common
{
    public class TestingResultStatusConstant
    {
        public static string ChuaNhapMa =
            LanguageExtension.GetResourceValueFromValue("0::Chưa map mã", LanguageExtension.AppLanguage);//"0::Chưa map mã";
        public static string ChapNhan = LanguageExtension.GetResourceValueFromValue("1::Chấp nhận", LanguageExtension.AppLanguage);//"1::Chấp nhận";

        public static string XemLai =
            LanguageExtension.GetResourceValueFromValue("2::Xem lại", LanguageExtension.AppLanguage);//;"2::Xem lại";
        public static string ChuaNhapThongTin = LanguageExtension.GetResourceValueFromValue("3::Chưa nhập SID", LanguageExtension.AppLanguage);//"3::Chưa nhập SID";
        public static string ChuaNhapChiDinh = LanguageExtension.GetResourceValueFromValue("4::Chưa nhập XN", LanguageExtension.AppLanguage);//"4::Chưa nhập XN";
        public static string DaCapNhatKetQua = LanguageExtension.GetResourceValueFromValue("5::Đã cập nhật kết quả", LanguageExtension.AppLanguage);//"5::Đã cập nhật kết quả";
        public static string DaCoKetQua = LanguageExtension.GetResourceValueFromValue("6::XN đã có kết quả", LanguageExtension.AppLanguage);//"6::XN đã có kết quả";
        public static string DaInKetQua = LanguageExtension.GetResourceValueFromValue("7::Đã in kết quả", LanguageExtension.AppLanguage);//"7::Đã in kết quả";
        public static string DaXacNhanKetQua = LanguageExtension.GetResourceValueFromValue("10::Đã xác nhận kết quả", LanguageExtension.AppLanguage);//"10::Đã xác nhận kết quả";

        public static Dictionary<string, string> TestingResultStatusConstantList = new Dictionary<string, string>()
        {
            { ChuaNhapMa,ChuaNhapMa},
            { ChapNhan,ChapNhan },
            { XemLai,XemLai },
            { ChuaNhapThongTin,ChuaNhapThongTin },
            { ChuaNhapChiDinh,ChuaNhapChiDinh },
            { DaCapNhatKetQua,DaCapNhatKetQua },
            { DaCoKetQua,DaCoKetQua },
            { DaInKetQua,DaInKetQua },
            { DaXacNhanKetQua,DaXacNhanKetQua }
        };
    }

    public class TestType
    {
        public enum EnumTestType
        {
            TatCa = -1,
            ThongThuong = 0,
            HuyetDo = 1,
            HoaHocTebao = 2,
            TuyDo = 3,
            TuyBao = 4,
            HauTuyBao = 5,
            BacCauDua = 6,
            BCDoan = 7,
            PhanTramTeBaoDongMTC = 8,
            SinhHocPhanTu = 9,
            SHPTGen = 10,
            HIV = 11,
            ViSinh_TQ = 12,
            ViSinh = 13,
            ViSinhSoiNhuom = 14,
            ViSinhNuoiCay = 15,
            ViSinhNam = 16,
            SHPTTacNhan = 17,
            SHPTThuongQuy = 18,
            HIVKD = 19,
            HIVSP = 20,
            NhanXetHuyetDo = 21,
            KetLuanHuyetDo = 22,
            DeNghiHuyetDo = 23,
            NhanXetHuyetTuyDo = 24,
            KetLuanHuyetTuyDo = 25,
            DeNghiHuyetTuyDo = 26,
            SinhThietTuySinhMau = 27,
            TienSan = 28,
            NIPT = 29,
            PLGF = 30,
            SFLT1 = 31,
            SLSS = 32,
            TBH = 33,
            GPB = 34,
            ChiDinhTruyenMau = 35,
            XetNghiemTruyenMau = 36,
            XNCoombs = 37,
            XNNacl9 = 38,
            XNTuiMau = 39,
            XNABONguoiNhanMau = 40,
            XNRhNguoiNhanMau = 41,
            XNCoombs_2 = 42,
            XNNacl9_2 = 43,
            Covid19 = 44,
            KhangNguyenCovid = 45,
            SHPTGenType = 46
        }
        public int TestTypeID { get; set; }
        public string TestTypeName { get; set; }
        public static List<TestType> ListTestType()
        {
            var list = new List<TestType>();
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.ThongThuong,
                TestTypeName = string.Format("{0} - Thông thường", (int)EnumTestType.ThongThuong)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.HuyetDo,
                TestTypeName = string.Format("{0} - Huyết đồ", (int)EnumTestType.HuyetDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.NhanXetHuyetDo,
                TestTypeName = string.Format("{0}:Nhận xét huyết đồ", (int)EnumTestType.NhanXetHuyetDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.KetLuanHuyetDo,
                TestTypeName = string.Format("{0}:Kết luận huyết đồ", (int)EnumTestType.KetLuanHuyetDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.DeNghiHuyetDo,
                TestTypeName = string.Format("{0}:Đề nghị huyết đồ", (int)EnumTestType.DeNghiHuyetDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.HoaHocTebao,
                TestTypeName = string.Format("{0} - Hóa học tế bào", (int)EnumTestType.HoaHocTebao)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.TuyDo,
                TestTypeName = string.Format("{0} - Tủy đồ", (int)EnumTestType.TuyDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.NhanXetHuyetTuyDo,
                TestTypeName = string.Format("{0}:Nhận xét huyết tủy đồ", (int)EnumTestType.NhanXetHuyetTuyDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.KetLuanHuyetTuyDo,
                TestTypeName = string.Format("{0}:Kết luận huyết tủy đồ", (int)EnumTestType.KetLuanHuyetTuyDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.DeNghiHuyetTuyDo,
                TestTypeName = string.Format("{0}:Đề nghị huyết tủy đồ", (int)EnumTestType.DeNghiHuyetTuyDo)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.TienSan,
                TestTypeName = string.Format("{0}:Tiền sản", (int)EnumTestType.TienSan)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.NIPT,
                TestTypeName = string.Format("{0}:NIPT", (int)EnumTestType.NIPT)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SFLT1,
                TestTypeName = string.Format("{0}:SFLT1", (int)EnumTestType.SFLT1)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SLSS,
                TestTypeName = string.Format("{0}:Sàng lọc sơ sinh", (int)EnumTestType.SLSS)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.PLGF,
                TestTypeName = string.Format("{0}:PLGF", (int)EnumTestType.PLGF)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SinhThietTuySinhMau,
                TestTypeName = string.Format("{0} - Sinh thiết tủy sinh máu", (int)EnumTestType.SinhThietTuySinhMau)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SinhHocPhanTu,
                TestTypeName = string.Format("{0} - SH phân tử", (int)EnumTestType.SinhHocPhanTu)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SHPTGen,
                TestTypeName = string.Format("{0} - SHPT (Gen)", (int)EnumTestType.SHPTGen)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SHPTGenType,
                TestTypeName = string.Format("{0} - SHPT (GenType)", (int)EnumTestType.SHPTGenType)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SHPTTacNhan,
                TestTypeName = string.Format("{0} - SHPT (Tác nhân)", (int)EnumTestType.SHPTTacNhan)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.SHPTThuongQuy,
                TestTypeName = string.Format("{0} - SHPT Thường quy", (int)EnumTestType.SHPTThuongQuy)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.HIV,
                TestTypeName = string.Format("{0} - HIV", (int)EnumTestType.HIV)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.HIVKD,
                TestTypeName = string.Format("{0} - HIV-Khẳng định", (int)EnumTestType.HIVKD)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.HIVSP,
                TestTypeName = string.Format("{0} - HIV-Sinh phẩm", (int)EnumTestType.HIVSP)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.ViSinh_TQ,
                TestTypeName = string.Format("{0} - Vi sinh (TQ)", (int)EnumTestType.ViSinh_TQ)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.ViSinhSoiNhuom,
                TestTypeName = string.Format("{0} - Vi sinh (Soi nhuộm)", (int)EnumTestType.ViSinhSoiNhuom)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.ViSinhNuoiCay,
                TestTypeName = string.Format("{0} - Vi sinh (Nuôi cấy)", (int)EnumTestType.ViSinhNuoiCay)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.ViSinhNam,
                TestTypeName = string.Format("{0} - Vi sinh (Nấm)", (int)EnumTestType.ViSinhNam)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.TBH,
                TestTypeName = string.Format("{0} - ThinPrep Pap Test", (int)EnumTestType.TBH)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.GPB,
                TestTypeName = string.Format("{0} - Giải phẩu bệnh", (int)EnumTestType.GPB)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.ChiDinhTruyenMau,
                TestTypeName = string.Format("{0} - Chỉ định truyền máu", (int)EnumTestType.ChiDinhTruyenMau)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XetNghiemTruyenMau,
                TestTypeName = string.Format("{0} - Xét nghiệm truyển máu", (int)EnumTestType.XetNghiemTruyenMau)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNABONguoiNhanMau,
                TestTypeName = string.Format("{0} - ABO người nhận máu", (int)EnumTestType.XNABONguoiNhanMau)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNRhNguoiNhanMau,
                TestTypeName = string.Format("{0} - Rh người nhận máu", (int)EnumTestType.XNRhNguoiNhanMau)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNCoombs,
                TestTypeName = string.Format("{0} - XN Coombs - 1", (int)EnumTestType.XNCoombs)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNNacl9,
                TestTypeName = string.Format("{0} - XN NaCl19 - 1", (int)EnumTestType.XNNacl9)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNCoombs_2,
                TestTypeName = string.Format("{0} - XN Coombs - 2", (int)EnumTestType.XNCoombs_2)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNNacl9_2,
                TestTypeName = string.Format("{0} - XN NaCl19 - 2", (int)EnumTestType.XNNacl9_2)
            });
            list.Add(new TestType
            {
                TestTypeID = (int)EnumTestType.XNTuiMau,
                TestTypeName = string.Format("{0} - XN Túi máu", (int)EnumTestType.XNTuiMau)
            });
            return list;
        }
    }
    public class TemplateInput
    {
        public enum EnumTemplateInput
        {
            TatCa = -1,
            KetLuanXN = 0,
            KetLuanHuyetDo = 1,
            KetLuanTuyDo = 2,
            DeNghiHuyetDo = 3,
            DeNghiTuyDo = 4,
            NhanXetHuyetDo = 5,
            NhanXetTuyDo = 6,
            KetQuaSoi = 7,
            KetQuaNhuom = 8,
            BienBanHutTuyXuong = 9,
            SinhThietTuySinhMau = 10
        }
        public int TemplateInputID { get; set; }
        public string TemplateInputName { get; set; }
        public static List<TemplateInput> ListTemplateInput()
        {
            var list = new List<TemplateInput>();
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.DeNghiHuyetDo,
                TemplateInputName = "Đề nghị (Huyết đồ)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.DeNghiTuyDo,
                TemplateInputName = "Đề nghị (Tủy đồ)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.KetLuanHuyetDo,
                TemplateInputName = "Kết luận (Huyết đồ)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.KetLuanTuyDo,
                TemplateInputName = "Kết luận (Tủy đồ)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.KetLuanXN,
                TemplateInputName = "Kết luận (XN chung)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.KetQuaNhuom,
                TemplateInputName = "Kết quả nhuộm"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.KetQuaSoi,
                TemplateInputName = "Kết quả soi"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.NhanXetHuyetDo,
                TemplateInputName = "Nhận xét (Huyết đồ)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.NhanXetTuyDo,
                TemplateInputName = "Nhận xét (Tủy đồ)"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.BienBanHutTuyXuong,
                TemplateInputName = "Biên bản hút tủy xương"
            });
            list.Add(new TemplateInput
            {
                TemplateInputID = (int)EnumTemplateInput.SinhThietTuySinhMau,
                TemplateInputName = "Sinh thiết tủy sinh máu"
            });
            return list;
        }
    }
    public enum enumThucHien
    {
        ChuaThucHien = 0,
        DaThucHien = 1,
        TatCa = 2,
        TuChoi = 3
    }
    public enum enumTacVu
    {
        TatCa = 0,
        LayMau = 1,
        NhanMau = 2,
        ChayMay = 3
    }


}
