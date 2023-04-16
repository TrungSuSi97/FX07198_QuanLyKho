using System;
using System.ComponentModel;

namespace TPH.LIS.Configuration.Constants
{
    public enum AntiBioticColor
    {
        Unidentified = -1,
        Normal = 0,
        Lower = 1,
        Higher = 2
    }
    public class AnitBioticResultIndex
    {
        public const string rS = "S";
        public const string rR = "R";
        public const string rI = "I";
        public const string rPos = "Pos";
        public const string rPlus = "+";
        public const string rNeg = "Neg";
        public const string rMinus = "-";

        public static AntiBioticColor GetResultColorFlat(string resultIndex)
        {
            if (resultIndex.Equals(rR, StringComparison.OrdinalIgnoreCase)
                || resultIndex.Equals(rPlus, StringComparison.OrdinalIgnoreCase)
                || resultIndex.Equals(rPos, StringComparison.OrdinalIgnoreCase)
                )
            {
                return AntiBioticColor.Higher;
            }
            else if (resultIndex.Equals(rS, StringComparison.OrdinalIgnoreCase)
                || resultIndex.Equals(rNeg, StringComparison.OrdinalIgnoreCase)
                || resultIndex.Equals(rMinus, StringComparison.OrdinalIgnoreCase)
                )
            {
                return AntiBioticColor.Lower;
            }
            else
                return AntiBioticColor.Normal;
        }
        public static string ConvertResultToSIR(string ketQua)
        {
            if (ketQua.Equals(rS, StringComparison.OrdinalIgnoreCase)
                    || ketQua.Equals(rR, StringComparison.OrdinalIgnoreCase)
                    || ketQua.Equals(rI, StringComparison.OrdinalIgnoreCase)

                    )
            {
                return ketQua.ToUpper();
            }
            else if (ketQua.Equals(rNeg, StringComparison.OrdinalIgnoreCase))
            {
                return rMinus;
            }
            else if (ketQua.Equals(rPos, StringComparison.OrdinalIgnoreCase))
            {
                return rPlus;
            }
            else
                return ketQua;
        }
    }

    public enum BacteriumCategory
    {
        [Description("Bộ")]
        order = 0,
        [Description("Họ")]
        family = 1,
        [Description("Chi")]
        genus = 2,
        [Description("Loài")]
        species = 3
    }
    public enum BioTestMethod
    {
        [Description("Disk")]
        Disk = 0,
        [Description("MIC")]
        MIC = 1,
        [Description("E-Test")]
        ETEST = 2,
    }
    public enum LoaiKetQuaViKhuan
    {
        [Description("Kết quả dương")]
        KetQuaDuong = 0,
        [Description("Kết quả âm")]
        KetQuaAmTinh = 1
    }
    public enum ToChucBreakpoint
    {
        [Description("CLSI")]
        CLSI = 0,
        [Description("EUCAST")]
        EUCST = 1,
        [Description("SFM")]
        SFM = 2,
        [Description("SRGA")]
        SRGA = 3,
        [Description("BSAC")]
        BSAC = 4,
        [Description("DIN")]
        DIN = 5,
        [Description("NEO")]
        NEODK = 6,
        [Description("AFA")]
        AFA = 7
    }
}
