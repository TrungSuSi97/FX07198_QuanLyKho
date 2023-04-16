namespace TPH.LIS.Data
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using TPH.Data;
    using TPH.Data.Configuration;
    using Common.Extensions;
    using System.Data.OleDb;
    using TPH.LIS.Common.Controls;
    using System.Threading;

    public class DataProvider
    {

        private static string DbConnectName = string.Empty;
        public static void ExcuteWithImage(
            string sqlQuery,
            byte[] imgParamters,
            bool isNull)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                var imageParam = new SqlParameter("@HinhAnh", SqlDbType.Image)
                {
                    Value = isNull ? (object)DBNull.Value : imgParamters
                };

                SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlQuery, Conn), imageParam);
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(sqlQuery, Conn), Environment.NewLine), "");
            }
        }

        public static void SelInsUpdDelODBC(
            SqlDataAdapter sqlDataAdapter,
            string sqlQuery,
            DataTable dataTable)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {

                var cmd = new SqlCommand(ChangeDBNameToConfig(sqlQuery, Conn), Conn)
                {
                    CommandTimeout = 3000
                };
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.SelectCommand = cmd;
                cmdBuilder.RefreshSchema();
                dataTable.Clear();
                sqlDataAdapter.Fill(dataTable);
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(sqlQuery, Conn), Environment.NewLine), "");
            }
        }

        public static void SelInsUpdDelODBC(
            string sqlQuery,
            ref SqlDataAdapter datatAdapter,
            ref DataTable dataTable)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                dataTable = new DataTable();
                datatAdapter = new SqlDataAdapter();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(datatAdapter);
                var cmd = new SqlCommand(ChangeDBNameToConfig(sqlQuery, Conn), Conn) { CommandTimeout = 3000 };
                datatAdapter.SelectCommand = cmd;
                cmdBuilder.RefreshSchema();
                datatAdapter.Fill(dataTable);
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(sqlQuery, Conn), Environment.NewLine), "");
            }
        }
        public static void SelInsUpdDelODBC(
           string spName,
           SqlParameter[] para,
           ref SqlDataAdapter datatAdapter,
           ref DataTable dataTable)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {

                dataTable = new DataTable();
                datatAdapter = new SqlDataAdapter();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(datatAdapter);
                var cmd = new SqlCommand(ChangeDBNameToConfig(spName, Conn), Conn) { CommandTimeout = 3000 };
                cmd.Parameters.Add(ChangeDBNameToConfigInPara(para, Conn));
                cmd.CommandType = CommandType.StoredProcedure;
                datatAdapter.SelectCommand = cmd;
                cmdBuilder.RefreshSchema();
                datatAdapter.Fill(dataTable);
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(spName, Conn), Environment.NewLine), "");
            }
        }
        public static bool UpdateData(
            SqlDataAdapter datatAdapter,
            ref DataTable dataTable,
            string sqlLogUpdate,
            string sqlLogDelete)
        {
            try
            {
                SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
                var dtUpdate = dataTable.GetChanges(DataRowState.Modified);
                var dtDelete = dataTable.GetChanges(DataRowState.Deleted);
                var dtAddNew = dataTable.GetChanges(DataRowState.Added);

                if (dtUpdate != null)
                {
                    if (!string.IsNullOrWhiteSpace(sqlLogUpdate))
                    {
                        SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlLogUpdate, Conn));
                    }
                    datatAdapter.Update(dtUpdate);

                    dataTable.AcceptChanges();
                    Conn.Close();
                    return true;
                }
                if (dtDelete != null)
                {
                    if (!string.IsNullOrWhiteSpace(sqlLogDelete))
                    {
                        SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlLogDelete, Conn));
                    }
                    datatAdapter.Update(dtDelete);
                    dataTable.AcceptChanges();
                    Conn.Close();
                    return true;
                }
                if (dtAddNew != null)
                {
                    datatAdapter.Update(dtAddNew);
                    datatAdapter.Fill(dataTable);
                    Conn.Close();
                    return true;
                }
                Conn.Close();
                return false;
            }
            catch (SqlException ex)
            {
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command - Update from context:{1}{0}{1}", datatAdapter.SelectCommand, Environment.NewLine), "");
                return false;
            }
        }

        public static bool UpdateData(SqlDataAdapter sqlDataAdapter, ref DataTable dt, DataGridView dataGridView, string sqlLogUpdate, string sqlLogDelete)
        {
            try
            {
                SqlConnection Conn = SqlDbConfigurationBase.GetConnection();

                var dtUpdate = dt.GetChanges(DataRowState.Modified);
                var dtDelete = dt.GetChanges(DataRowState.Deleted);
                var dtAddNew = dt.GetChanges(DataRowState.Added);

                if (dtUpdate != null)
                {
                    if (!string.IsNullOrWhiteSpace(sqlLogUpdate))
                    {
                        SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlLogUpdate, Conn));
                    }
                    sqlDataAdapter.Update(dtUpdate);
                    dt.AcceptChanges();
                    Conn.Close();
                    return true;
                }

                if (dtDelete != null)
                {
                    if (!string.IsNullOrWhiteSpace(sqlLogDelete))
                    {
                        SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlLogDelete, Conn));
                    }
                    sqlDataAdapter.Update(dtDelete);
                    dt.AcceptChanges();
                    Conn.Close();
                    return true;
                }

                if (dtAddNew != null)
                {
                    sqlDataAdapter.Update(dtAddNew);
                    dt.AcceptChanges();
                    Conn.Close();
                    return true;
                }
                Conn.Close();
                return false;
            }
            catch (SqlException ex)
            {
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command - Update from context:{1}{0}{1}", sqlDataAdapter.SelectCommand, Environment.NewLine), "");
                return false;
            }
        }
        public static bool UpdateData(SqlDataAdapter sqlDataAdapter, ref DataTable dt, DataGridView dataGridView, string sqlLogUpdate, string sqlLogDelete, ref DataTable dtChanged)
        {
            try
            {
                SqlConnection Conn = SqlDbConfigurationBase.GetConnection();

                var dtUpdate = dt.GetChanges(DataRowState.Modified);
                var dtDelete = dt.GetChanges(DataRowState.Deleted);
                var dtAddNew = dt.GetChanges(DataRowState.Added);

                if (dtUpdate != null)
                {
                    dtChanged = dtUpdate;
                    if (!string.IsNullOrWhiteSpace(sqlLogUpdate))
                    {
                        SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlLogUpdate, Conn));
                    }
                    sqlDataAdapter.Update(dtUpdate);
                    dt.AcceptChanges();
                    Conn.Close();
                    return true;
                }

                if (dtDelete != null)
                {
                    dtChanged = dtDelete;
                    if (!string.IsNullOrWhiteSpace(sqlLogDelete))
                    {
                        SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(sqlLogDelete, Conn));
                    }
                    sqlDataAdapter.Update(dtDelete);
                    dt.AcceptChanges();
                    Conn.Close();
                    return true;
                }

                if (dtAddNew != null)
                {
                    dtChanged = dtAddNew;
                    sqlDataAdapter.Update(dtAddNew);
                    dt.Clear();
                    sqlDataAdapter.Fill(dt);
                    dt.AcceptChanges();
                    Conn.Close();
                    return true;
                }
                Conn.Close();
                return false;
            }
            catch (SqlException ex)
            {
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command - Update from context:{1}{0}{1}", sqlDataAdapter.SelectCommand, Environment.NewLine), "");
                return false;
            }
        }
        public static bool CheckExisted(string commandText)
        {
            bool hasrow = false;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                var reader = SqlDb.ExecuteReader(Conn, CommandType.Text, ChangeDBNameToConfig(commandText, Conn));
                hasrow = reader.HasRows;
                ((IDisposable)reader).Dispose();
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(commandText, Conn), Environment.NewLine), "");
            }
            return hasrow;
        }

        public static bool CheckExisted(
            string commandText,
            SqlParameter[] para)
        {
            bool hasrow = false;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {

                var reader = SqlDb.ExecuteReader(Conn, CommandType.Text, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(para, Conn));
                hasrow = reader.HasRows;
                ((IDisposable)reader).Dispose();
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(commandText, Conn), Environment.NewLine), "");
            }
            return hasrow;
        }
        public static bool CheckExisted(CommandType cmType,
        string commandText,
        SqlParameter[] para)
        {
            bool hasrow = false;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                var reader = SqlDb.ExecuteReader(Conn, cmType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(para, Conn));
                hasrow = reader.HasRows;
                ((IDisposable)reader).Dispose();
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(commandText, Conn), Environment.NewLine), "");
            }
            return hasrow;
        }
        public static DataSet ExecuteDataset(
            CommandType commandType,
            string commandText,
            params SqlParameter[] commandParameters
            )
        {
            DataSet ds = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, false, 0);
                    //CustomMessageBox.ShowAlert("Đã có lỗi kết nối mạng, ứng dụng đang cố gắng kết nối lại máy chủ.");
                    ds = ExecuteDataset(commandType, commandText, 1, commandParameters);
                    //CustomMessageBox.CloseAlert();
                    if (ds == null)
                        ShowError(ex, commandText, Conn, true, 0);
                }
                else
                    ShowError(ex, commandText, Conn, true, 0);
            }

            return ds;
        }
        public static DataSet ExecuteDataset(
           CommandType commandType,
           string commandText, int retry = 0,
           params SqlParameter[] commandParameters
           )
        {
            DataSet ds = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ShowError(ex, commandText, Conn, false, retry);
                if (RequiredRetry(ex.Message))
                {
                    if (retry < 3)
                    {
                        retry++;
                        ds = ExecuteDataset(commandType, commandText, retry, commandParameters);
                    }
                }
            }
            return ds;
        }
        public static DataSet ExecuteDataset(CommandType commandType, string commandText, bool showMess = false, params SqlParameter[] commandParameters)
        {
            DataSet ds = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {

                ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, showMess, 0);
                    ds = ExecuteDataset(commandType, commandText, showMess, 30, 1, commandParameters);
                    if (ds == null)
                        ShowError(ex, commandText, Conn, showMess, 0, commandParameters);
                }
                else
                    ShowError(ex, commandText, Conn, showMess, 0, commandParameters);
            }
            return ds;
        }

        public static DataSet ExecuteDataset(CommandType commandType, string commandText, bool showMess = false, int timeOut = 30, params SqlParameter[] commandParameters)
        {
            DataSet ds = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                if (timeOut != 30)
                    ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), timeOut, ChangeDBNameToConfigInPara(commandParameters, Conn));
                else
                    ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, showMess, 0);
                    ds = ExecuteDataset(commandType, commandText, showMess, timeOut, 1, commandParameters);
                    if (ds == null)
                        ShowError(ex, commandText, Conn, showMess, 0, commandParameters);
                }
                else
                    ShowError(ex, commandText, Conn, showMess, 0, commandParameters);
            }
            return ds;
        }
        public static DataSet ExecuteDataset(CommandType commandType, string commandText, bool showMess = false, int timeOut = 30, int retry = 0, params SqlParameter[] commandParameters)
        {
            DataSet ds = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                if (timeOut != 30)
                    ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), timeOut, ChangeDBNameToConfigInPara(commandParameters, Conn));
                else
                    ds = SqlDb.ExecuteDataset(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ShowError(ex, commandText, Conn, false, retry, commandParameters);
                if (RequiredRetry(ex.Message))
                {
                    if (retry < 3)
                    {
                        return ExecuteDataset(commandType, commandText, showMess, timeOut, retry++, commandParameters);
                    }
                }
            }
            return ds;
        }
        public static object ExecuteScalar(
            CommandType commandType,
            string commandText)
        {
            object obj = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            // Pass through the call providing null for the set of SqlParameters
            try
            {
                obj = SqlDb.ExecuteScalar(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), (SqlParameter[])null);
            }
            catch (SqlException ex)
            {
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}", ChangeDBNameToConfig(commandText, Conn), Environment.NewLine), "");
            }
            return obj;
        }

        public static object ExecuteScalar(
            CommandType commandType,
            string commandText,
            params SqlParameter[] commandParameters)
        {
            object obj = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            // Pass through the call providing null for the set of SqlParameters
            try
            {

                obj = SqlDb.ExecuteScalar(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, false, 0);
                   // CustomMessageBox.ShowAlert("Đã có lỗi kết nối mạng, ứng dụng đang cố gắng kết nối lại máy chủ.");
                    obj = ExecuteScalar(commandType, commandText, 1, commandParameters);
                    //CustomMessageBox.CloseAlert();
                    if (obj == null)
                        ShowError(ex, commandText, Conn, true, 0, commandParameters);
                }
                else
                    ShowError(ex, commandText, Conn, true, 0, commandParameters);
            }
            return obj;
        }
        public static object ExecuteScalar(
       CommandType commandType,
       string commandText, int retry = 0,
       params SqlParameter[] commandParameters)
        {
            object obj = null;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            // Pass through the call providing null for the set of SqlParameters
            try
            {
                obj = SqlDb.ExecuteScalar(Conn, commandType, ChangeDBNameToConfig(commandText, Conn), ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ShowError(ex, commandText, Conn, false, retry, commandParameters);
                if (RequiredRetry(ex.Message))
                {
                    if (retry < 3)
                    {
                        return ExecuteQuery(commandText, retry++);
                    }
                }
            }
            return obj;
        }

        public static bool ExecuteQuery(string commandText)
        {
            bool flat = false;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(commandText, Conn), (SqlParameter[])null);
                flat = true;
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, false, 0);
                    flat = ExecuteQuery(commandText, 1);
                    if (!flat)
                        ShowError(ex, commandText, Conn, true, 0);

                }
                else
                    ShowError(ex, commandText, Conn, true, 0);
            }
            return flat;
        }
        public static bool ExecuteQuery(string commandText, int retry)
        {
            bool flat = false;
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                SqlDb.ExecuteNonQuery(Conn, CommandType.Text, ChangeDBNameToConfig(commandText, Conn), (SqlParameter[])null);
                flat = true;
                Conn.Close();
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ShowError(ex, commandText, Conn, false, retry);
                if (RequiredRetry(ex.Message))
                {
                    if (retry < 3)
                    {
                        return ExecuteQuery(commandText, retry++);
                    }
                }
            }
            return flat;
        }
        public static object ExecuteNonQuery(
            CommandType commandType,
            string commandText,
            params SqlParameter[] commandParameters)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                Conn.Close();
                Conn.Open();
                // Pass through the call providing null for the set of SqlParameters
                int r = SqlDb.ExecuteNonQuery(Conn, commandType
                    , ChangeDBNameToConfig(commandText, Conn)
                    , ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
                return r;
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, false, 0, commandParameters);
                    var i = (int)ExecuteNonQuery(commandType, commandText, true, 1, commandParameters);
                    if (i == -1)
                        ShowError(ex, commandText, Conn, true, 0, commandParameters);
                    return i;
                }
                else
                    ShowError(ex, commandText, Conn, true, 0, commandParameters);
                return -1;
            }
        }
        public static object ExecuteNonQuery(
           CommandType commandType,
           string commandText, bool showMess = false,
           params SqlParameter[] commandParameters)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                Conn.Close();
                Conn.Open();
                // Pass through the call providing null for the set of SqlParameters
                int r = SqlDb.ExecuteNonQuery(Conn, commandType
                    , ChangeDBNameToConfig(commandText, Conn)
                    , ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
                return r;
            }
            catch (SqlException ex)
            {
                Conn.Close();
                if (RequiredRetry(ex.Message))
                {
                    ShowError(ex, commandText, Conn, false, 0, commandParameters);
                    var i = (int)ExecuteNonQuery(commandType, commandText, showMess, 1, commandParameters);
                    if (i == -1)
                        ShowError(ex, commandText, Conn, showMess, 0, commandParameters);
                    return i;
                }
                else
                    ShowError(ex, commandText, Conn, showMess, 0, commandParameters);
                return -1;
            }
        }
        public static object ExecuteNonQuery(
          CommandType commandType,
          string commandText, bool showMess = false, int retry = 0,
          params SqlParameter[] commandParameters)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                Conn.Close();
                Conn.Open();
                // Pass through the call providing null for the set of SqlParameters
                int r = SqlDb.ExecuteNonQuery(Conn, commandType, ChangeDBNameToConfig(commandText, Conn),
                     ChangeDBNameToConfigInPara(commandParameters, Conn));
                Conn.Close();
                return r;
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ShowError(ex, commandText, Conn, false, retry);
                if (RequiredRetry(ex.Message))
                {
                    if (retry < 3)
                    {
                        return ExecuteNonQuery(commandType, commandText, showMess, retry++, commandParameters);
                    }
                }
                return -1;
            }
        }
        public static SqlDataReader ExecuteReader(
            CommandType commandType,
            string commandText,
            params SqlParameter[] commandParameters)
        {
            SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
            try
            {
                // Pass through the call to the private overload using a null transaction value and an externally owned connection
                return SqlDb.ExecuteReader(
                    Conn,
                    commandType,
                    ChangeDBNameToConfig(commandText, Conn),
                    (commandParameters == null ? null : ChangeDBNameToConfigInPara(commandParameters, Conn)));
            }
            catch (SqlException ex)
            {
                Conn.Close();
                ShowError(ex, commandText, Conn, true, 0, commandParameters);
                return null;
            }
        }
        private static void ShowError(SqlException ex, string commandText, SqlConnection Conn, bool isShowMessage = true, int retry = 0, params SqlParameter[] commandParameters)
        {
            if (commandParameters != null)
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}*Parametrs:{1} {2}{3}"
                    , ChangeDBNameToConfig(commandText, Conn), Environment.NewLine, ChangeDBNameToConfigInPara(commandParameters, Conn).ToString()
                    , (retry > 0 ? string.Format("\r\nWith retry: {0}", retry) : "")), "", isShowMessage);
            else
                ErrorService.GetSQLErrorMessage(ex, string.Format("*Command:{1}{0}{1}{3}", ChangeDBNameToConfig(commandText, Conn), Environment.NewLine
                    , (retry > 0 ? string.Format("\r\nWith retry: {0}", retry) : "")), "", isShowMessage);
        }
        public static string ChangeDBNameToConfig(string inputSql, SqlConnection Conn, string keyName = "{{TPH_Standard}}")

        {
            if (string.IsNullOrEmpty(DbConnectName))
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Conn.ConnectionString);
                DbConnectName = builder.InitialCatalog;
            }
            if (!string.IsNullOrEmpty(DbConnectName))
            {
                if (keyName.Equals("{{TPH_Standard}}"))
                    return ChangeDBNameToConfig(inputSql.Replace(keyName, DbConnectName).Replace(keyName.ToLower(), DbConnectName).Replace(keyName.ToUpper(), DbConnectName), Conn, "{TPH_Standard}");
                else
                    return inputSql.Replace(keyName, DbConnectName).Replace(keyName.ToLower(), DbConnectName).Replace(keyName.ToUpper(), DbConnectName);
            }
            return inputSql;
        }
        public static SqlParameter[] ChangeDBNameToConfigInPara(SqlParameter[] inputPara, SqlConnection Conn)
        {
            if (inputPara != null)
            {
                if (string.IsNullOrEmpty(DbConnectName))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Conn.ConnectionString);
                    DbConnectName = builder.InitialCatalog;
                }
                if (!string.IsNullOrEmpty(DbConnectName))
                {
                    string keyName = "{{TPH_Standard}}";
                    string keyName2 = "{TPH_Standard}";
                    foreach (var item in inputPara)
                    {
                        if (item.Value is string)
                        {
                            var newValue = item.Value.ToString().Replace(keyName, DbConnectName).Replace(keyName.ToLower(), DbConnectName).Replace(keyName.ToUpper(), DbConnectName);
                            newValue = newValue.Replace(keyName2, DbConnectName).Replace(keyName2.ToLower(), DbConnectName).Replace(keyName2.ToUpper(), DbConnectName);
                            item.Value = newValue;
                        }
                    }
                }
            }
            return inputPara;
        }
        private static bool RequiredRetry(string exception)
        {
            return exception.ToUpper().Contains("PHYSICAL CONNECTION IS NOT USABLE");
        }
    }
    public class OleDbDataProvider
    {

        OleDbConnection ConnHISOleDb;
        private string DbPath = string.Empty;
        public OleDbDataProvider(string dbpath)
        {
            DbPath = dbpath;
        }
        private void ConnectData()
        {
            ConnHISOleDb = new OleDbConnection(string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", DbPath));
            if (ConnHISOleDb.State == ConnectionState.Open)
            {
                ConnHISOleDb.Close();
            }
            try
            {
                ConnHISOleDb.Open();
            }
            catch
            {
                ConnHISOleDb.Close();
            }
        }
        private void CloseConnect()
        {
            if (ConnHISOleDb.State == ConnectionState.Open)
            {
                ConnHISOleDb.Close();
            }
            ConnHISOleDb.Dispose();
        }

        public DataTable GetDatatable(string SQL)
        {
            ConnectData();
            DataTable dt = new DataTable();
            OleDbDataAdapter odbcAdt = new OleDbDataAdapter(SQL, ConnHISOleDb);
            odbcAdt.Fill(dt);
            CloseConnect();
            return dt;
        }
        public void ExecuteQuery(string SQL)
        {
            ConnectData();
            OleDbCommand cmd = new OleDbCommand(SQL, ConnHISOleDb);
            cmd.CommandTimeout = 500;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            CloseConnect();
        }

        public void SelInsUpdDelOleDB(ref OleDbDataAdapter da, ref DataTable dt, string SQL)
        {
            ConnectData();
            da = new OleDbDataAdapter();
            dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand(SQL, ConnHISOleDb);
            cmd.CommandTimeout = 500;
            da.SelectCommand = cmd;
            OleDbCommandBuilder _cmdBuilder = new OleDbCommandBuilder(da);
            da.Fill(dt);
        }

        public bool UpdateData(OleDbDataAdapter da, ref DataTable dt, DataGridView dtg, string _SQLLogUpdate, string _SQLLogDel)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataTable dtUpdate = dt.GetChanges(DataRowState.Modified);
            DataTable dtDelete = dt.GetChanges(DataRowState.Deleted);
            DataTable dtAddNew = dt.GetChanges(DataRowState.Added);
            if (dtUpdate != null)
            {
                if (_SQLLogUpdate != "")
                {
                    ExecuteQuery(_SQLLogUpdate);
                }
                da.Update(dtUpdate);
                dt.AcceptChanges();
                return true;
            }
            if (dtDelete != null)
            {
                if (_SQLLogDel != "")
                {
                    ExecuteQuery(_SQLLogDel);
                }
                da.Update(dtDelete);
                dt.AcceptChanges();
                return true;
            }
            if (dtAddNew != null)
            {
                da.Update(dtAddNew);
                dt.AcceptChanges();
                SelInsUpdDelOleDB(ref da, ref dt, da.SelectCommand.CommandText);
                return true;
            }
            else
            {
                return false;
            }
        }
 
    }
}
