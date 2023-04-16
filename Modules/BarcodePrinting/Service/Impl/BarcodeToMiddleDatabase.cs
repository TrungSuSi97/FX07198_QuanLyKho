using TPH.LIS.BarcodePrinting.Barcode;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TPH.LIS.Data;

namespace TPH.LIS.BarcodePrinting.Service.Impl
{
    public class BarcodeToMiddleDatabase
    {
        public int InsertNewBarcodeInfo( List< BarcodeProperties> lstObj)
        {
            // @sampleid varchar(20),
            // @seq int,
            // @patientid varchar(50),
            // @patientname nvarchar(150),
            // @patientnamenosign nvarchar(150),
            // @age int,
            // @sex char(1),
            // @idmay int,
            // @ID bigint output,
            //--------------------Chi tiết-------------
            // @idthongtin bigint -> lấy từ @iD ouput,
            // @tubecode varchar(25),
            // @tubecate varchar(35),
            // @tubename nvarchar(100),
            // @tubecount int

            //@Orderlocationcode,@Orderplacedlocation,@Wardcode,@Wardname

            //Insert thông tin trước
            foreach (var obj in lstObj)
            {
                var sqlPara = new SqlParameter[]
                {
                new SqlParameter("@sampleid",obj.Sid ),
                new SqlParameter("@seq",obj.SoBarcode ),
                new SqlParameter("@increamentID",obj.SoTT ),
                new SqlParameter("@patientid",obj.PatientID ),
                new SqlParameter("@patientname",obj.PatientName ),
                new SqlParameter("@patientnamenosign",obj.PatientNameNosign ),
                new SqlParameter("@age",obj.NamSinh ),
                new SqlParameter("@sex",obj.GioiTinh ),
                new SqlParameter("@idmay",obj.LableMachineID),
                new SqlParameter("@Orderlocationcode",obj.MaKhoaPhong ),
                new SqlParameter("@Orderplacedlocation",obj.TenKhoaPhong ),
                new SqlParameter("@Wardcode",obj.MaKhoaPhong),
                new SqlParameter("@Wardname",obj.MaKhoaPhong),
                new SqlParameter("@SoHoSo",obj.SoHoSo)
                };
                var data = DataProvider.ExecuteDataset(System.Data.CommandType.StoredProcedure, "insPatientHEN_WithSelectID", sqlPara);
                if (data != null)
                {
                    var dataID = data.Tables[0];
                    if (dataID.Rows.Count > 0)
                    {
                        var id = long.Parse(string.IsNullOrEmpty(dataID.Rows[0]["ID"].ToString()) ? "0" : dataID.Rows[0]["ID"].ToString());
                        if (id > 0)
                        {
                            obj.DataRecordID = id;
                        }
                    }
                }
            }
            return InsertBarcodeDetail(lstObj);

        }
        public int InsertBarcodeDetail (List<BarcodeProperties> lstObj)
        {
            // @idthongtin bigint -> lấy từ @iD ouput,
            // @tubecode varchar(25),
            // @tubecate varchar(35),
            // @tubename nvarchar(100),
            // @tubecount int
            var sbInsert = new StringBuilder();
            var formatString = "Exec insSpecimenHEN @idthongtin = {0},@tubecode = {1}, @tubecate = {2},@tubename = {3}, @tubecount = {4}";
            foreach (var objList in lstObj)
            {
                if (objList.DanhSachTube != null)
                {
                    if (objList.DanhSachTube.Count > 0)
                    {
                       
                        foreach (var item in objList.DanhSachTube)
                        {
                            sbInsert.Append(string.IsNullOrEmpty(sbInsert.ToString()) ? "" : ";\n");
                            sbInsert.AppendFormat(formatString, objList.DataRecordID
                               , string.IsNullOrEmpty(item.Tubecode) ? "NULL" : string.Format("'{0}'", item.Tubecode)
                               , string.IsNullOrEmpty(item.TubeCate) ? "NULL" : string.Format("'{0}'", item.TubeCate)
                               , string.IsNullOrEmpty(item.Tubename) ? "NULL" : string.Format("'{0}'", item.Tubename)
                               , item.TubeCount);
                        }

                    }
                }
            }
            if (!string.IsNullOrEmpty(sbInsert.ToString()))
                return (int)DataProvider.ExecuteNonQuery(System.Data.CommandType.Text, sbInsert.ToString());
            return 0;
        }
    }
}
