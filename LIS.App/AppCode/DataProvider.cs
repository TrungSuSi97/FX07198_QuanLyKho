using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
   public class DataProvider
    {
        private static DataProvider dp;
        static readonly object _object = new object();
        private static SqlConnection _SqlConnection;
        Error_Code error = new Error_Code();
        private DataProvider()
        {
            if (_SqlConnection == null)
                _SqlConnection = new SqlConnection();

            try
            {
                if (_SqlConnection.State != ConnectionState.Open)
                {
                    string sFileConfig = Application.ExecutablePath;
                    int i_Index = sFileConfig.LastIndexOf('\\');
                    sFileConfig = sFileConfig.Substring(0, i_Index).Trim('\\');
                    sFileConfig = sFileConfig + "\\TPH.exe";
                    Configuration config = ConfigurationManager.OpenExeConfiguration(sFileConfig);
                    string userName = TPH.Common.StringCryptography.EnDeCrypt.DecryptString("tVNi25NtnzY="); ;
                    string passWord = TPH.Common.StringCryptography.EnDeCrypt.DecryptString("qwg2mejF5jNYevjglE/Sng==");

                    string serverName = config.AppSettings.Settings["ServerName"].Value.ToString();
                    string databaseName = config.AppSettings.Settings["DatabaseName"].Value.ToString();
                    _SqlConnection.ConnectionString = string.Format("server={0};database={1};uid={2};password={3};", serverName, databaseName, userName, passWord);
                    _SqlConnection.Open();
                }
            }
            catch
            {
                _SqlConnection.Close();
            }
        }

        public static DataProvider Get_DataConnect()
        {
            lock (_object)
            {
                if (_SqlConnection == null)
                {
                    dp = new DataProvider();
                }
                return dp;
            }
        } /// Mo ket noi toi server
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            if (_SqlConnection.State == ConnectionState.Closed)
            {
                try
                {
                    _SqlConnection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    error.GetErr_Framework(ex, "Get connect");
                    return false;
                }
            }
            return false;
        }
        /// Ngat ket noi
        /// </summary>
        /// <returns></returns>
        public bool Disconect()
        {
            try
            {
                _SqlConnection.Close();
                return true;
            }
            catch
            { }
            return false;
        }
        //SqlDataReader dr = null;
        /// <summary>
        /// Hàm này dùng để thực thi câu lệnh sql kiểu dự liệu trả về là DataSet
        /// </summary>
        /// <param name="strSQL">Truyền vào câu lệnh SQL</param>
        /// <returns>Dữ liệu trả về DataSet</returns>
        public DataSet ExcuteDataSet(string strSQL)
        {

            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataSet ds = new DataSet();
            SqlDataAdapter odbcAdt = new SqlDataAdapter(strSQL, _SqlConnection);
            odbcAdt.Fill(ds);
            return ds;
        }
        /// <summary>
        /// Hàm này dùng để thực thi câu lệnh sql kiểu dự liệu trả về là DataTable
        /// </summary>
        /// <param name="strSQL">Truyền vào câu lệnh SQL</param>
        /// <returns>Dữ liệu trả về DataTable</returns>
        public DataTable ExcuteDataTable(string strSQL)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataTable dt = new DataTable();
            SqlDataAdapter odbcAdt = new SqlDataAdapter(strSQL, _SqlConnection);
            odbcAdt.Fill(dt);
            return dt;
        }
        /// <summary>
        /// Hàm này dùng để thực thi câu lệnh sql như Insert, Update, Delete
        /// </summary>
        /// <param name="strSQL">Truyền vào câu lệnh SQL</param>
        public bool ExecuteQuery(string strSQL)
        {
            SqlTransaction trans = null;
            if (_SqlConnection.State == ConnectionState.Closed)
                Connect();
            trans = _SqlConnection.BeginTransaction();
            SqlCommand cmd = new SqlCommand(strSQL, _SqlConnection);
            cmd.CommandType = CommandType.Text;

            try
            {
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            // 300709
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                trans.Rollback();
                _SqlConnection.Close();
                //_SqlConnection.Dispose();
                return error.GetErr_Framework(ex, strSQL);

            }
        }

       public void ExcuteWithImage(string strSQL, byte[] _imgParamater, bool _Null)
        {
            if (_SqlConnection.State == ConnectionState.Closed)
                Connect();
            SqlCommand cmd = new SqlCommand(strSQL, _SqlConnection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@HinhAnh", (_Null ? (object)DBNull.Value : _imgParamater)).SqlDbType = SqlDbType.Image;
            cmd.ExecuteNonQuery();
            _SqlConnection.Close();
        }

        /// <summary>
        /// Hàm này dùng để thực thi câu lệnh sql kiểu dự liệu trả về là DataReader
        /// </summary>
        /// <param name="strSQL">Truyền vào câu lệnh SQL</param>
        /// <returns>Dữ liệu trả về DataReader</returns>
        public SqlDataReader ExcuteDataReader(string strSQL)
        {
            
            try
            {
                SqlDataReader dr;
                if (_SqlConnection.State == ConnectionState.Closed) Connect();
                SqlCommand cmd = new SqlCommand(strSQL, _SqlConnection);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strSQL);
            }
            return null;
        }
       
        /// <summary>
        /// dataset goi store procedure khong truyen tham so
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>

        //su dung store procedure
        public DataSet GetDataSet(string strQuery, CommandType commandType)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataSet ds = new DataSet();
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        /// <summary>
        /// dataset goi store procedure co truyen tham so
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="commandType"></param>
        /// <param name="Parameters"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string strQuery, CommandType commandType, string[] Parameters, string[] Values)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataSet ds = new DataSet();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;
                SqlParameter sqlParameter;
                for (int i = 0; i < Parameters.Length; i++)
                {
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = Parameters[i];
                    sqlParameter.SqlValue = Values[i];
                    sqlCommand.Parameters.Add(sqlParameter);
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);
                sqlDataAdapter.Dispose();

            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return ds;
        }
        //DataTableReader dar = da.CreateDataReader();(dar giong Idatareader)


        /// <summary>
        /// datatable goi store procedure khong truyen tham so
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strQuery, CommandType commandType)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataTable da = new DataTable();
            try
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(da);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return da;
        }
        /// <summary>
        /// datatable goi store procedure co truyen tham so
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="commandType"></param>
        /// <param name="Parameters"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string strQuery, CommandType commandType, string[] Parameters, string[] Values)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            //khoi tao doi tuong cho dataTable
            DataTable da = new DataTable();
            try
            {
                //khai bao khoi tao doi tuong SqlCommand
                SqlCommand sqlCommand = new SqlCommand();
                //khai bao thuoc tinh cho doi tuong SqlCommand
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;
                SqlParameter sqlParameter;
                for (int i = 0; i < Parameters.Length; i++)
                {
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = Parameters[i];
                    sqlParameter.SqlValue = Values[i];
                    sqlCommand.Parameters.Add(sqlParameter);
                }
                //khai bao va khoi tao doi tuong SqlDataAdapter
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //khai bao goi phuong thuc Fill cua doi tuong SqlDataAdapter
                sqlDataAdapter.Fill(da);
                sqlDataAdapter.Dispose();

            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return da;
        }
        /// <summary>
        /// thuc hien chay store procedure
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="commandType"></param>
        /// <param name="Parameters"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public bool ExecuteSqlQuery(string strQuery, CommandType commandType, string[] Parameters, string[] Values)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            SqlTransaction trans = null;
            trans = _SqlConnection.BeginTransaction();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.Connection = _SqlConnection;
                sqlCommand.CommandType = commandType;
                SqlParameter sqlParameter;
                for (int i = 0; i < Parameters.Length; i++)
                {
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = Parameters[i];
                    sqlParameter.SqlValue = Values[i];
                    sqlCommand.Parameters.Add(sqlParameter);
                }
                sqlCommand.Transaction = trans;
                sqlCommand.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                error.GetErr_Framework(ex, strQuery);
                //
            }
            return false;
        }
        /// <summary>
        /// thuc hien chay store procedure
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="commandType"></param>
        /// <param name="Parameters"></param>
        /// <param name="Values"></param>
        /// <returns></returns>
        public bool ExecuteSqlQuery(string strQuery, CommandType commandType)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            SqlTransaction trans = null;
            trans = _SqlConnection.BeginTransaction();
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.Connection = _SqlConnection;
                sqlCommand.CommandType = commandType;

                sqlCommand.Transaction = trans;
                sqlCommand.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                error.GetErr_Framework(ex, strQuery);
               
            }
            return false;
        }
        ///goi phuong thuc Fill de phan trang
        ///
        public DataSet GetDataSet(string strQuery, CommandType commandType, int startIndex, int endIndex)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataSet ds = new DataSet();
            DataTable da = new DataTable();
            try
            {
                //khai bao thuoc tinh cho SqlCommand
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;

                //khai bao doi tuong SqlDataAdapter
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(startIndex, endIndex, ds.Tables[0]);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return ds;
        }
        //co tham so truyen vao
        public DataSet GetDataSet(string strQuery, CommandType commandType, string[] Parameters, string[] Values, int startIndex, int endIndex)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataSet ds = new DataSet();
            DataTable da = new DataTable();
            try
            {
                //khai bao thuoc tinh cho SqlCommand
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;
                //khai bao va khoi tao thuoc tinh cho SqlCommand
                SqlParameter sqlParameter;
                for (int i = 0; i < Parameters.Length; i++)
                {
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = Parameters[i];
                    sqlParameter.SqlValue = Values[i];
                    sqlCommand.Parameters.Add(sqlParameter);
                }
                //khai bao doi tuong SqlDataAdapter
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(startIndex, endIndex, ds.Tables[0]);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return ds;
        }
        public DataTable GetDataTable(string strQuery, CommandType commandType, string[] Parameters, string[] Values, int startIndex, int endIndex)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataTable da = new DataTable();
            try
            {
                //khai bao thuoc tinh cho SqlCommand
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;
                //khai bao va khoi tao thuoc tinh cho SqlCommand
                SqlParameter sqlParameter;
                for (int i = 0; i < Parameters.Length; i++)
                {
                    sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = Parameters[i];
                    sqlParameter.SqlValue = Values[i];
                    sqlCommand.Parameters.Add(sqlParameter);
                }
                //khai bao doi tuong SqlDataAdapter
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(startIndex, endIndex, da);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return da;
        }
        public DataTable GetDataTable(string strQuery, CommandType commandType, int startIndex, int endIndex)
        {
            if (_SqlConnection.State == ConnectionState.Closed) Connect();
            DataTable da = new DataTable();
            try
            {
                //khai bao thuoc tinh cho SqlCommand
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = strQuery;
                sqlCommand.CommandType = commandType;
                sqlCommand.Connection = _SqlConnection;

                //khai bao doi tuong SqlDataAdapter
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(startIndex, endIndex, da);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, strQuery);
            }
            return da;
        }
        public string GetRequestValue(string str)
        {
            string temp = "";
            int i = 0;
            if (str == null) return null;
            for (i = 0; i < str.Length; i++)
            {
                if ((str[i] >= '0') & (str[i] <= '9'))
                {
                    temp = temp + str[i];
                }
            }
            if (i == 0) return null;
            return temp;
        }
        public DataTable GetData(string SqlQuerry)
        {
            if (_SqlConnection.State == ConnectionState.Closed)
            { Connect(); }
            SqlDataAdapter Dta = new SqlDataAdapter(SqlQuerry, _SqlConnection);
            DataTable data = new DataTable();

            try
            { Dta.Fill(data); }
            catch (Exception ex)
            {
                error.GetErr_Framework(ex, SqlQuerry);
                return null; }
            return data;
        }
        public DataTable GetData(string Sqlquerry, int StartRecord, int MaxRecord)
        {
            SqlDataAdapter dta = new SqlDataAdapter(Sqlquerry, _SqlConnection);
            DataTable data = new DataTable();
            dta.Fill(StartRecord, MaxRecord, data);
            return data;
        }
        public void SelInsUpdDelODBC(SqlDataAdapter _dataAdt, string _strSQL, DataTable _dataTable)
        {
            SqlCommand cmd = new SqlCommand(_strSQL, _SqlConnection);
            cmd.CommandTimeout = 3000;
            _dataAdt.SelectCommand = cmd;
            SqlCommandBuilder _cmdBuilder = new SqlCommandBuilder(_dataAdt);
            _dataAdt.Fill(_dataTable);
           
        }

        public bool UpdateData(SqlDataAdapter da, ref DataTable dt, DataGridView dtg, string _SQLLogUpdate, string _SQLLogDel)
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
