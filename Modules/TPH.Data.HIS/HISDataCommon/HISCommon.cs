using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TPH.Data.HIS.HISDataCommon
{
    public enum HisProvider
    {
        [Description("--Không chọn--")]
        NONE = -1,
        [Description("--Hãy chọn HIS--")]
        Default = 0,
        [Description("Công ty DH")]
        DH_DHG= 1,
        [Description("Đại học cần thơ")]
        DHCanTho = 2,
        [Description("VNPT Fujitsu")]
        VFT = 3,
        [Description("DB Trung Gian(A Hội)")]
        AHoi = 4,
        [Description("PTT (SP)")]
        PTT_SP = 5,
        [Description("FPT DB Trung Gian(HL7)")]
        DBTG_HL7_FPT= 6,
        [Description("FPT StoredProcedure")]
        FPT_SP = 7,
        [Description("Cty TNHH phần mềm Hằng Minh")]
        HangMinh = 8,
        [Description("Cty Phần mềm SHPT")]
        SHPT = 9,
        [Description("Cty ISofH")]
        ISofH = 10,
        [Description("Cty Vimes")]
        Vimes = 11,
        [Description("IT_BV Q.Phú Nhuận")]
        ITBVPhuNhuan = 12,
        [Description("HITEK Solution")]
        Hitek = 13,
        [Description("Cty PTT (API)")]
        PTT_API = 14,
        [Description("Cty DH (API)")]
        DH_API = 15,
        [Description("Cty Phan Nguyễn")]
        PhanNguyen = 16,
        [Description("Cty VietInfo")]
        VietInfo = 17,
        [Description("Cty E-Record")]
        ERecord_API = 18,
        [Description("Cty SUN")]
        SUN = 19,
        [Description("TP Soft")]
        TPSoft = 20,
        [Description("Leopard")]
        Leopard = 21, 
        [Description("ECO CLINIC")]
        ECOCLINIC = 22,
        [Description("VIETTEL - MN")]
        VIETTEL_MN = 23,
        [Description("PKTranDiepKhanh - IT")]
        PKTDK_IT = 24,
        [Description("VNPT - MN")]
        VNPTMN = 25,
        [Description("TPH.LabIMS Web (API)")]
        TPHLabIMS_Web_API = 99
    }
    public class OrderStatus
    {
        public const string OrderRecieved = "OK";
     //   public const string OrderRecieved = "OK";
        public const string SampleCollect = "OR";
        public const string SampleGet = "OE";
        public const string OrderCancel = "DC";
    }
    public enum DBConnectType
    {
        [Description("MS SQL")]
        MSSQL = 1,
        [Description("PostgreSQL")]
        POSTGRE = 2,
        [Description("Web API")]
        WebAPI = 3
    }
    public enum FunctionType
    {
        [Description("Thực thi Store Procedure")]
        StoreProcedure = 1,
        [Description("Thực thi query/none query")]
        QueryCommand = 2,
        [Description("Post")]
        Post = 3,
        [Description("Get")]
        Get = 4,
        [Description("Put")]
        Put = 5,
        [Description("Delete")]
        Delete = 6
    }
    public enum HisConfigType
    {
        Functions = 1,
        Columns = 2
    }
    public enum TestGroup
    {
        ALL = 0,
        HH = 1,
        SH = 2,
        VS = 3,
        SHPT = 4
    }
    public class HisDataType
    {
        public const string DateTime_Type = "DateTime";
        public const string Date_Type = "Date";
        public const string Time_Type = "Time";
        public const string Int_Type = "int";
        public const string Float_Type = "float";
        public const string Double_Type = "double";
        public const string Bool_Type = "bool";
        public const string String_Type = "string";

        public static Dictionary<string, string> HisDataTypeList = new Dictionary<string, string>()
        {
            {DateTime_Type,"Ngày giờ (DateTime)" },
            {Date_Type,"Ngày (DateTime)" },
            {Time_Type,"Giờ (DateTime)" },
            {Int_Type,"Số nguyên (int)" },
            {Float_Type,"Số thực (float)" },
            {Double_Type,"Số lớn (double)" },
            {Bool_Type,"True/Flase (bool)" },
            {String_Type,"Chuỗi ký tự (string)" }

        };
    }
    public class FPTKhuVuc
    {
        public const int NgoaiTru = 0;
        public const int NoiTru = 1;
        public const int CapCuu = 2;
        public const int TaCal = 9;
    }
    public class FPTResultActionContanst
    {
        public const string AddNew = "AddNew";
        public const string Update = "Update";
        public const string SoPhieuXN = "SoPhieuKetQuaXN";
    }
    public class FPTTrangThaiChiDinh
    {
        public const int DaCap = 0;
        public const int ChuaCap = 4;
        public const int DaCoKetQua = 2;
    }
    public class LisVarParaChiDinh
    {
        public const string sophieuchidinh = "Sophieuchidinh";
        public const string tungaychidinh = "Tungaychidinh";
        public const string denngaychidinh = "Denngaychidinh";
        public const string mabophan = "Mabophan";
        public const string trangthai = "Trangthai";
        public const string paraIn = "ParaIn";
        public const string IDMayInBarcode = "IDMayInBarcode";

        public static Dictionary<string, string> HisDataTypeList = new Dictionary<string, string>()
        {
            {sophieuchidinh,"Số phiếu chỉ định" },
            {tungaychidinh,"Từ ngày chỉ định" },
            {denngaychidinh,"Đến ngày chỉ định" },
            {mabophan,"Mã bộ phận" },
            {trangthai,"Trạng thái" },
            {paraIn,"Tham số ID" },
            {IDMayInBarcode,"ID máy in barcode" }

        };
    }
    public class CommonData
    {
        public static List<KeyValuePair<int, string>> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            List<KeyValuePair<int, string>> enumValList = new List<KeyValuePair<int, string>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<int, string>((int)e, (attributes.Length > 0) ? attributes[0].Description : e.ToString()));
            }

            return enumValList;
        }
    }
}

