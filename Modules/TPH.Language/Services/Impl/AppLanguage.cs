using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TPH.Data;
using TPH.Data.Configuration;
using TPH.Language.Models;

namespace TPH.Language.Services.Impl
{
    public class AppLanguage : IAppLanguage
    {
        #region Work helper
        //private readonly SqlConnection Conn = SqlDbConfigurationBase.GetConnection();
        private DataSet ExecuteDataset(
           CommandType commandType,
           string commandText,
           params SqlParameter[] commandParameters
           )
        {
            SqlConnection cnn = SqlDbConfigurationBase.GetConnection();
            DataSet ds = null;
            try
            {
                ds = SqlDb.ExecuteDataset(cnn, commandType, commandText, commandParameters);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(string.Format("Load data language error{0}{1}", Environment.NewLine, ex.Message));
            }
            return ds;
        }
        private object ExecuteNonQuery(
          CommandType commandType,
          string commandText,
          params SqlParameter[] commandParameters)
        {
            try
            {
                SqlConnection cnn = SqlDbConfigurationBase.GetConnection();
                cnn.Close();
                cnn.Open();
                // Pass through the call providing null for the set of SqlParameters
                int r = SqlDb.ExecuteNonQuery(cnn, commandType, commandText, commandParameters);
                cnn.Close();
                return r;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(string.Format("Command error{0}{1}", Environment.NewLine, ex.Message));

                return -1;
            }
        }
        public object Get_InfoForObject(object objInfo, DataRow drInfo)
        {
            PropertyInfo[] fiCheck = objInfo.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                var prop = objInfo.GetType().GetProperty(f.Name);
                if (objInfo.GetType().GetProperty(f.Name) != null)
                {
                    if (drInfo.Table.Columns.Contains(f.Name))
                    {
                        if (prop.PropertyType == typeof(Image) || prop.PropertyType == typeof(Bitmap))
                        {
                            var obj = drInfo[f.Name];
                            if (obj == null || obj == DBNull.Value)
                                prop.SetValue(objInfo, null, null);
                            else
                            {
                                var byteArr = (byte[])drInfo[f.Name];
                                Image image;
                                using (MemoryStream ms = new MemoryStream(byteArr))
                                {
                                    image = Image.FromStream(ms);
                                }
                                prop.SetValue(objInfo, image, null);
                            }
                        }
                        else
                            prop.SetValue(objInfo, ChangeTypeForOject(drInfo[f.Name], prop.PropertyType), null);
                    }
                }
            }
            return objInfo;
        }
        public object ChangeTypeForOject(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value == DBNull.Value)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }
            else if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return Convert.ChangeType(value, t);
        }

        public object ConvertObjectForSQPara(object inObject, bool getOnlyDate = false, bool isImage = false)
        {
            if (inObject == null)
            {
                return (object)DBNull.Value;
            }
            else
            {
                if (inObject is string)
                {
                    var str = (string)inObject;
                    return (string.IsNullOrEmpty(str) ? (object)DBNull.Value : str);
                }
                else if (inObject is DateTime?)
                {
                    if ((DateTime)inObject == DateTime.MinValue)
                        return (object)DBNull.Value;
                    var obj = (DateTime?)inObject;
                    return (obj == null ? (object)DBNull.Value : (getOnlyDate ? obj.Value.Date : obj.Value));
                }
                else if (inObject is DateTime)
                {
                    if ((DateTime)inObject == DateTime.MinValue)
                        return (object)DBNull.Value;
                    var obj = (DateTime)inObject;
                    return (obj == null ? (object)DBNull.Value : (getOnlyDate ? obj.Date : obj));
                }
                else if (inObject is float || inObject is float?)
                {
                    var obj = (float?)inObject;
                    return (obj == null ? (object)DBNull.Value : obj.Value.ToString());
                }
                else if (inObject is Image || inObject is Bitmap)
                {
                    var img = (Image)inObject;
                    byte[] byteArray = new byte[0];
                    using (MemoryStream stream = new MemoryStream())
                    {
                        img.Save(stream, img.RawFormat);
                        stream.Close();
                        byteArray = stream.ToArray();
                    }
                    return (byteArray == null ? (object)DBNull.Value : byteArray);
                }
            }
            return inObject;
        }
        public SqlParameter GetParaFromOject(string paraName, object inObject
            , bool getOnlyDate = false, bool datetime2 = false, bool isImage = false
            , ParameterDirection paraDirection = ParameterDirection.Input)
        {
            if (datetime2)
            {
                var para = new SqlParameter(paraName, SqlDbType.DateTime2);
                para.Direction = paraDirection;
                para.Value = ConvertObjectForSQPara(inObject, getOnlyDate);
                return para;
            }
            else if (inObject is Image || isImage)
            {
                var para = new SqlParameter(paraName, SqlDbType.Image);
                para.Direction = paraDirection;
                para.Value = ConvertObjectForSQPara(inObject, getOnlyDate);
                return para;
            }
            else
            {
                return new SqlParameter(paraName, ConvertObjectForSQPara(inObject, getOnlyDate));
            }
        }
        #endregion
        public int Insert_HeThong_NgonNgu(HETHONG_NGONNGU objInfo)
        {
            if (CheckExists_HeThong_NgonNgu(null, objInfo.Idtungu)) return -1;
            var para = new SqlParameter[] {
                        GetParaFromOject("@IdTuNgu", objInfo.Idtungu),
                        GetParaFromOject("@DefaultLang", objInfo.Defaultlang),
                        GetParaFromOject("@VN", objInfo.Vn),
                        GetParaFromOject("@ENG", objInfo.Eng)
                        };
            return (int)ExecuteNonQuery(CommandType.StoredProcedure, "ins_HeThong_NgonNgu", para);
        }
        public int Update_HeThong_NgonNgu(HETHONG_NGONNGU objInfo)
        {
            var para = new SqlParameter[] {
                        GetParaFromOject("@Id", objInfo.Id),
                        GetParaFromOject("@IdTuNgu", objInfo.Idtungu),
                        GetParaFromOject("@DefaultLang", objInfo.Defaultlang),
                        GetParaFromOject("@VN", objInfo.Vn),
                        GetParaFromOject("@ENG", objInfo.Eng)
                        };
            return (int)ExecuteNonQuery(CommandType.StoredProcedure, "upd_HeThong_NgonNgu", para);
        }

        public int Delete_HeThong_NgonNgu(int id)
        {
            var para = new SqlParameter[] {
                        GetParaFromOject("@Id", id)
                        };
            return (int)ExecuteNonQuery(CommandType.StoredProcedure, "del_HeThong_NgonNgu", para);
        }
        public DataTable Data_HeThong_NgonNgu(int? id, string idNgonNgu)
        {
            var para = new SqlParameter[] {
                        GetParaFromOject("@Id", id),
                       GetParaFromOject("@idNgonNgu", idNgonNgu)
                        };
            var ds = ExecuteDataset(CommandType.StoredProcedure, "sel_HeThong_NgonNgu", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public HETHONG_NGONNGU Get_Info_HeThong_NgonNgu(DataRow drInfo)
        {
            return (HETHONG_NGONNGU)Get_InfoForObject(new HETHONG_NGONNGU(), drInfo);
        }
        public HETHONG_NGONNGU Get_Info_HeThong_NgonNgu(int id)
        {
            DataTable dt = Data_HeThong_NgonNgu(id, string.Empty);
            HETHONG_NGONNGU obj = new HETHONG_NGONNGU();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_HeThong_NgonNgu(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_HeThong_NgonNgu(int? id, string idNgonNgu)
        {
            return Data_HeThong_NgonNgu(id, idNgonNgu).Rows.Count > 0;
        }

    }
}
