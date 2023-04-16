namespace TPH.Data.HIS.Configuration
{
    using System.Data;
    using System;
    using Npgsql;
    using Models;
    using WriteLog;

    public class PostgreDBConfigurationBase
    {
        static NpgsqlConnection connection = null;
        static readonly object lockConnection = new object();

        public static NpgsqlConnection GetConnection(HisConnection hisConnectConfig)
        {
            try
            {
                var connectString = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};Timeout=10;CommandTimeout = 10000;Pooling=false;",
                   hisConnectConfig.ServerName, hisConnectConfig.PortNumber, hisConnectConfig.UserName
                   , hisConnectConfig.PassWord, hisConnectConfig.DatabaseName);

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
                        connection = new NpgsqlConnection();
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
