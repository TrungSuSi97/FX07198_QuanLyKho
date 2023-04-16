using System;
using System.Data;
using TPH.Common.Converter;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Data;

namespace TPH.LIS.Configuration.Repositories.PrintedForm
{
    public class PrintedFormRepository : IPrintedFormRepository
    {
        public PrintedHeader GetPrintedHeaderByDepartement(string departement)
        {

            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selThongTinTieuDe_TheoMaTieuDe"
                , new System.Data.SqlClient.SqlParameter[] {  WorkingServices.GetParaFromOject("@MaTieuDe", departement) }))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return null;
                }
                PrintedHeader header = new PrintedHeader();
                while (reader.Read())
                {
                    header = new PrintedHeader
                    {
                        TieuDe1 = StringConverter.ToString(reader["TieuDe1"]),
                        TieuDe2 = StringConverter.ToString(reader["TieuDe2"]),
                        TieuDe3 = StringConverter.ToString(reader["TieuDe3"]),
                        TieuDe4 = StringConverter.ToString(reader["TieuDe4"]),
                        TieuDe5 = StringConverter.ToString(reader["TieuDe5"]),
                        TieuDe6 = StringConverter.ToString(reader["TieuDe6"]),
                        TenPhieuIn = StringConverter.ToString(reader["TenPhieuIn"]),
                        ChuKy = StringConverter.ToString(reader["NguoiKyTen"]),
                        ChucVu = StringConverter.ToString(reader["ChucVu"]),
                        PhuTrach = StringConverter.ToString(reader["NguoiPhuTrach"]),
                        ChungChiHanhNghe = StringConverter.ToString(reader["chungchihanhnghe"]),
                        InMau = NumberConverter.ToBool(reader["InMau"])
                    };
                }
                ((IDisposable)reader).Dispose();
                return header;
            }
        }
        public PrintedHeader GetPrintedHeaderByDepartementWithUserPrint(string userId, string departement)
        {
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selThongTinTieuDe_KyTen"
                , new System.Data.SqlClient.SqlParameter[] {WorkingServices.GetParaFromOject("@MaNguoiDung", userId), WorkingServices.GetParaFromOject("@MaTieuDe", departement) }))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return null;
                }
                PrintedHeader header = new PrintedHeader();
                while (reader.Read())
                {
                    header = new PrintedHeader
                    {
                        TieuDe1 = StringConverter.ToString(reader["TieuDe1"]),
                        TieuDe2 = StringConverter.ToString(reader["TieuDe2"]),
                        TieuDe3 = StringConverter.ToString(reader["TieuDe3"]),
                        TieuDe4 = StringConverter.ToString(reader["TieuDe4"]),
                        TieuDe5 = StringConverter.ToString(reader["TieuDe5"]),
                        TieuDe6 = StringConverter.ToString(reader["TieuDe6"]),
                        TenPhieuIn = StringConverter.ToString(reader["TenPhieuIn"]),
                        ChuKy = StringConverter.ToString(reader["NguoiKyTen2"]),
                        ChucVu = StringConverter.ToString(reader["ChucVu2"]),
                        ChungChiHanhNghe = StringConverter.ToString(reader["Chungchihanhnghe2"]),
                        PhuTrach = StringConverter.ToString(reader["NguoiPhuTrach"]),
                        InMau = NumberConverter.ToBool(reader["InMau"])
                    };
                }
                ((IDisposable)reader).Dispose();
                return header;
            }
        }
    }
}