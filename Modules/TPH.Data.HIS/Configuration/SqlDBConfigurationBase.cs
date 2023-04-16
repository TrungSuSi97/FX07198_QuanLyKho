namespace TPH.Data.HIS.Configuration
{
    using System.Data.SqlClient;
    using System.Data;
    using System;
    using Models;
    using WriteLog;

    public class SqlDbConfigurationBase
    {
        static SqlConnection connection = null;
        static readonly object lockConnection = new object();

        public static SqlConnection GetConnection(HisConnection hisConnectConfig)
        {
            try
            {
                string userName = hisConnectConfig.UserName;  //EnDeCrypt.DecryptString(config.AppSettings.Settings["UserID"].Value.ToString());
                string passWord = hisConnectConfig.PassWord;  //EnDeCrypt.DecryptString(config.AppSettings.Settings["Pwd"].Value.ToString());
                string serverName = hisConnectConfig.ServerName;  //config.AppSettings.Settings["ServerName"].Value.ToString();
                string databaseName = hisConnectConfig.DatabaseName;  //config.AppSettings.Settings["DatabaseName"].Value.ToString();
                string connectString = string.Format("server={0};database={1};uid={2};password={3};MultipleActiveResultSets=True;", serverName, databaseName, userName, passWord);

                if (connection != null)
                {
                    if (!connection.ConnectionString.Equals(connectString, StringComparison.OrdinalIgnoreCase))
                    {
                        connection.Close();
                    }
                }

                lock (lockConnection)
                {
                    if (connection == null)
                    {
                        connection = new SqlConnection();
                    }

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connectString;
                        connection.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogFileFormat("Log_", "Connection HIS occur error {0}", ex.ToString());
                connection.Close();
            }

            return connection;
        }
    }
}
