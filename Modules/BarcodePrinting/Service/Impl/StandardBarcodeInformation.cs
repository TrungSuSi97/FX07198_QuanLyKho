using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using TPH.LIS.Data;

namespace TPH.LIS.BarcodePrinting.Service.Impl
{
    public class StandardBarcodeInformation: IBarcodeStandardInformation
    {
        public int Insert_ThongTinbarcode(string nguoiNhap, string pcNhap, byte[] noidungTem, string tenMauBarcode, int loaiBarcode)
        {

            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@NguoiNhap",nguoiNhap)
                , new SqlParameter("@PcNhap",pcNhap)
                , new SqlParameter("@NoiDungTem",noidungTem)
                , new SqlParameter("@TenMauBarcode",tenMauBarcode)
                , new SqlParameter("@LoaiBarcode",loaiBarcode)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insReport_Barcode", sqlPara);
        }
        public int Update_ThongTinbarcode(int id, string tenMaubarcode, int loaibarcode, string nguoiSua, string pcSua)
        {
            //@id int
            //, @TenMauBarcode varchar(100)
            //,@LoaiBarcode int
            //, @NguoiCapNhat  varchar(25)
            //,@PcCapNhat varchar(100)
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@id",id)
                ,new SqlParameter("@TenMauBarcode",tenMaubarcode)
                ,new SqlParameter("@LoaiBarcode",loaibarcode)
                ,new SqlParameter("@NguoiCapNhat",nguoiSua)
                ,new SqlParameter("@PcCapNhat",pcSua)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpReport_Barcode", sqlPara);
        }
        public int Update_NoiDungTem(int id, byte[] noidungTem)
        {
            var sqlPara = new SqlParameter[]
                {
                        new SqlParameter("@Id",id)
                        , new SqlParameter("@NoiDungTem",noidungTem)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpReport_Barcode_NoiDungTem", sqlPara);
        }
        public int Delete_Report(int id)
        {
            var sqlPara = new SqlParameter[]
                {
                        new SqlParameter("@Id",id)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delReport_Barcode", sqlPara);
        }
        public DataTable Data_DanhSachThongTin(string id)
        {
            var sqlPara = new SqlParameter[]
               {
                    new SqlParameter("@Id",string.IsNullOrEmpty(id)?(object)DBNull.Value: int.Parse(id))
               };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selReport_Barcode", sqlPara).Tables[0];
        }
        public DataTable Data_DanhSachThongTin_TheoMayTinh(string tenMayTinh, int loaiTem)
        {
            var sqlPara = new SqlParameter[]
               {
                     new SqlParameter("@TenMayTinh",tenMayTinh)
                     , new SqlParameter("@IdLoaiTem",loaiTem)
               };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selReport_Barcode_MayTinh", sqlPara).Tables[0];
        }
        public int Insert_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh, string TenMayIn, string NguoiCapNhat, string PcCapNhat)
        {
            var sqlPara = new SqlParameter[]
                    {
                        new SqlParameter("@IdBarcode",IdBarcode)
                        ,new SqlParameter("@TenMayTinh",TenMayTinh)
                        ,new SqlParameter("@TenMayIn",TenMayIn)
                        ,new SqlParameter("@NguoiCapNhat",NguoiCapNhat)
                        ,new SqlParameter("@PcCapNhat",PcCapNhat)
                    };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insTemBarcode_MayTinh", sqlPara);
        }
        public int Update_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh, string TenMayIn, string NguoiCapNhat, string PcCapNhat)
        {
            var sqlPara = new SqlParameter[]
                    {
                        new SqlParameter("@IdBarcode",IdBarcode)
                        ,new SqlParameter("@TenMayTinh",TenMayTinh)
                        ,new SqlParameter("@TenMayIn",TenMayIn)
                        ,new SqlParameter("@NguoiCapNhat",NguoiCapNhat)
                        ,new SqlParameter("@PcCapNhat",PcCapNhat)
                    };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updTemBarcode_MayTinh", sqlPara);
        }
        public int Delete_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh)
        {
            var sqlPara = new SqlParameter[]
                    {
                        new SqlParameter("@IdBarcode",IdBarcode)
                        ,new SqlParameter("@TenMayTinh",TenMayTinh)
                    };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delTembarcode_MayTinh", sqlPara);
        }
        public DataTable Data_TemBarcode_MayTinh(int IdBarcode, string TenMayTinh)
        {
            var sqlPara = new SqlParameter[]
               {
                    new SqlParameter("@IdBarcode",IdBarcode)
                        ,new SqlParameter("@TenMayTinh",string.IsNullOrEmpty(TenMayTinh)?(object)DBNull.Value: TenMayTinh)
               };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selTembarcode_MayTinh", sqlPara).Tables[0];
        }
        public XtraReport GetReport_SuDung_TheoCauHinh(string tenMayTinh, int loaiTem, ref string tenMayIn, ref byte[] datareport)
        {
            var info = Data_DanhSachThongTin_TheoMayTinh(tenMayTinh, loaiTem);
            if(info.Rows.Count >0)
            {
                tenMayIn = info.Rows[0]["TenMayIn"].ToString();
                datareport = (byte[])info.Rows[0]["NoiDungTem"];
                return CreateReportFromStream(datareport);
            }
            return null;
        }
        public XtraReport CreateReportFromStream(byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            var report = XtraReport.FromStream(stream, true);
            return report;
        }
        
    }
}
