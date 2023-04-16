using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using TPH.Common.StringCryptography;
using TPH.HIS.WebAPI.Configs;

namespace TPH.HIS.WebAPI.DataAccess.Impl
{
    public class BaseDataAccess
    {
        private static SqlConnection _connection = null;
        private static readonly object LockConnection = new object();

        public static SqlConnection GetConnection()
        {
            try
            {
                var sFileConfig = Application.ExecutablePath;
                var index = sFileConfig.LastIndexOf('\\');
                sFileConfig = sFileConfig.Substring(0, index).Trim('\\');
                sFileConfig = sFileConfig + "\\TPH.exe";

                var serverName = string.Empty;
                var databaseName = string.Empty;
                if (File.Exists(sFileConfig))
                {
                    var config = ConfigurationManager.OpenExeConfiguration(sFileConfig);
                    serverName = config.AppSettings.Settings["ServerName"].Value.ToString();
                    databaseName = config.AppSettings.Settings["DatabaseName"].Value.ToString();
                }
                else
                {
                    serverName = HisApiCommonConfigs.DatabaseServerIp;
                    databaseName = HisApiCommonConfigs.DatabaseDbName;
                }

                var userName = EnDeCrypt.DecryptString("tVNi25NtnzY=");
                var passWord = EnDeCrypt.DecryptString("qwg2mejF5jNYevjglE/Sng==");
                var connectString =
                    $"server={serverName};database={databaseName};uid={userName};password={passWord};MultipleActiveResultSets=True;";

                if (_connection != null)
                {
                    if (!_connection.DataSource.Equals(serverName, StringComparison.OrdinalIgnoreCase) ||
                        !_connection.Database.Equals(databaseName, StringComparison.OrdinalIgnoreCase))
                    {
                        _connection.Close();
                    }
                }

                lock (LockConnection)
                {
                    if (_connection == null)
                    {
                        _connection = new SqlConnection();
                    }

                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.ConnectionString = connectString;
                        _connection.Open();
                    }
                }
            }
            catch (SqlException ex)
            {
                _connection.Close();
            }

            return _connection;
        }
    }
}