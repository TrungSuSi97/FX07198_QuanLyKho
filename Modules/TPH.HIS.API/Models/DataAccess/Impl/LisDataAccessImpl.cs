using System.Data.SqlClient;
using TPH.Common.Converter;
using TPH.Data;
using TPH.HIS.WebAPI.Configs;
using TPH.HIS.WebAPI.Extensions;
using TPH.HIS.WebAPI.Models;
using TPH.HIS.WebAPI.Models.Params;
using TPH.LIS.Data;

namespace TPH.HIS.WebAPI.DataAccess.Impl
{
    public class LisDataAccessImpl : ILisDataAccess
    {
        public SystemConfigModel GetSystemConfig(int hisId)
        {
            SystemConfigModel result = null;

            var sqlQuery = $"select h.* from {{TPH_Standard}}_System.dbo.cauhinh_thongtin_his h (nolock)\n where HisID ='{hisId}'";

            using (var reader = DataProvider.ExecuteReader(System.Data.CommandType.Text, sqlQuery))
            {
                while (reader.Read())
                {
                    result = new SystemConfigModel()
                    {
                        HisID = NumberConverter.ToInt(reader["HisID"]),
                        HisUrl = StringConverter.ToString(reader["Servername"]),
                        HisDatabaseName = StringConverter.ToString(reader["Databasename"]),
                        HisUser = StringConverter.ToString(reader["Username"]),
                        HisPassword = StringConverter.ToString(reader["Password"]),
                        HisPort = StringConverter.ToString(reader["PortNumber"]),
                        LisUrl = StringConverter.ToString(reader["LisServername"]),
                        LisUser = StringConverter.ToString(reader["LisUsername"]),
                        LisPassword = StringConverter.ToString(reader["LisPassword"])
                    };
                }

                reader.Close();
            }
            if (result != null)
            {
                CachingExtension.Set(HisApiCommonConfigs.SystemConfigCacheKey, result);
            }

            return result;
        }

        public bool UpdatePatientInfo(PatientParams patient)
        {

            var result = (int)DataProvider.ExecuteNonQuery( System.Data.CommandType.StoredProcedure, "updADTPatient", new SqlParameter[]
            {
                new SqlParameter("@mabn", patient.MaBenhNhan),
                new SqlParameter("@TenBN", patient.HoTen),
                new SqlParameter("@tuoi", patient.NamSinh),
                new SqlParameter("@sinhnhat", patient.SinhNhat),
                new SqlParameter("@gioitinh", patient.GioiTinh),
                new SqlParameter("@sdt", patient.SoDienThoai),
                new SqlParameter("@diachi", patient.DiaChi),
                //new SqlParameter("@sobhyt", StringConverter.ToString(patient.b)),
            });

            return result != -1;
        }
    }
}