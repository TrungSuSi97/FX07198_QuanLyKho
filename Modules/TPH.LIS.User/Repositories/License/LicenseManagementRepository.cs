using System;
using System.Data;
using System.Data.SqlClient;
using TPH.Common.StringCryptography;
using TPH.LIS.Data;

namespace TPH.LIS.User.Repositories.License
{
    public class LicenseManagementRepository : ILicenseManagementRepository
    {

        public bool CheckValidSerial(string computerName, string applicationName, string serialNumber)
        {
            bool f = false;
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selAppLicenseKeynumber",
                new SqlParameter[]  {
                    new SqlParameter("@pcName",computerName),
                    new SqlParameter("@appName",applicationName),
                    new SqlParameter("@serial",serialNumber)
                }
                ))
            {
                if (reader.Read())
                {
                    if (reader["keynumber"] != null && !DBNull.Value.Equals(reader["keynumber"]))
                    {
                        string keyNumber = (string)reader["keynumber"];
                        if (TPHSerialKeys.CheckSerial(keyNumber))
                        {
                            f = true;
                        }
                    }
                    reader.Close();
                }
            }
            return f;
        }
        public void UpdateSerialKey(string computerName, string applicationName, string serialNumber, string keyNumber)
        {
            DataProvider.ExecuteReader(CommandType.StoredProcedure, "ins_upd_AppLicenseKeyNumber", new SqlParameter[] {
                  new SqlParameter("@pcName",computerName),
                    new SqlParameter("@appName",applicationName),
                    new SqlParameter("@serial",serialNumber),
                    new SqlParameter("@KeyNumber",keyNumber)
            });
           
        }
    }
}
