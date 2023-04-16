using Npgsql;
using System.Data;
using System.Data.SqlClient;
using TPH.Data.HIS.Configuration;
using TPH.Data.HIS.Models;

namespace TPH.Data.HIS
{
    public class HisDataProvider
    {
        private static NpgsqlParameter[] convertPosgreParas(SqlParameter[] sqlPara)
        {
            var paraReturn = new NpgsqlParameter[sqlPara.Length];
            if (sqlPara != null)
            {
                if (sqlPara.Length > 0)
                {
                    paraReturn = new NpgsqlParameter[sqlPara.Length];
                    for (int i = 0; i < sqlPara.Length; i++)
                    {
                        paraReturn[i] = new NpgsqlParameter(sqlPara[i].ParameterName, sqlPara[i].Value);
                    }
                }
            }
            return paraReturn;
        }
        public static DataSet ExecuteDataset(HisConnection hisConnect, CommandType commandType, string commandText, SqlParameter[] sqlPara)
        {
            if (hisConnect.DbType == HISDataCommon.DBConnectType.POSTGRE)
            {
                var conn = PostgreDBConfigurationBase.GetConnection(hisConnect);
                return PosgreDb.ExecuteDataset(conn, commandType, commandText, convertPosgreParas(sqlPara));
            }
            else if (hisConnect.DbType == HISDataCommon.DBConnectType.MSSQL)
            {
                //hisConnect.DbType == HISDataCommon.DBConnectType.MSSQL
                var conn = SqlDbConfigurationBase.GetConnection(hisConnect);
                return SqlDb.ExecuteDataset(conn, commandType, commandText, sqlPara);
            }
            return null;
        }
        public static int ExecuteNoneQuery(HisConnection hisConnect, CommandType commandType, string commandText, SqlParameter[] sqlPara)
        {
            if (hisConnect.DbType == HISDataCommon.DBConnectType.POSTGRE)
            {
                var conn = PostgreDBConfigurationBase.GetConnection(hisConnect);
                return PosgreDb.ExecuteNonQuery(conn, commandType, commandText, convertPosgreParas(sqlPara));
            }
            else if (hisConnect.DbType == HISDataCommon.DBConnectType.MSSQL)
            {
                //hisConnect.DbType == HISDataCommon.DBConnectType.MSSQL
                var conn = SqlDbConfigurationBase.GetConnection(hisConnect);
                return SqlDb.ExecuteNonQuery(conn, commandType, commandText, sqlPara);
            }
            else
                return -1;
        }
    }
}
