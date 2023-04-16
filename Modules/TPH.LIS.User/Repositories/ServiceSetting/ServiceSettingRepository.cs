using System.Data;
using TPH.Common.Converter;
using TPH.LIS.Data;

namespace TPH.LIS.User.Repositories.ServiceSetting
{
    public class ServiceSettingRepository : IServiceSettingRepository
    {
        public string GetDefaultServiceCode()
        {
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selDoiTuongDichVu_MacDinh"))
            {
                if (!reader.HasRows)
                {
                    return string.Empty;
                }

                while (reader.Read())
                {
                    return StringConverter.ToString(reader["MaDoiTuongDichVu"]);
                }
            }

            return string.Empty;
        }
    }
}
