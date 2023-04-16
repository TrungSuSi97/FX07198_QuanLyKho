namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    using System.Data;

    using System.Reflection;
    using Data.HIS;
    using System.Data.SqlClient;
    using Data.HIS.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Data.HIS.HISDataCommon;
    using System.Text;
    using WriteLog;

    public class GetHISDataAccessBase : IGetHISDataAccessBase
    {
        private HisFunctionID objHisFunctionID = new HisFunctionID();
        private bool IsNumerric(object inStr)
        {
            if (inStr == null)
                return false;
            int n;
            bool isNumeric = int.TryParse(inStr.ToString(), out n);
            return isNumeric;
        }
        public SqlParameter[] CreateSQlPara(string funtionParaNames, string functionParaListMapping
            , object objPara, string LogGroup, string FunctionName, ref string sqlWithparaCombine, DBConnectType hisType)
        {
            var paraReturn = new SqlParameter[0];
            var arrFuction = funtionParaNames.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var arrMapping = functionParaListMapping.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbHisPara = new StringBuilder();
            StringBuilder sblog = new StringBuilder();
            if (objPara != null)
            {
                if (arrFuction.Length == arrMapping.Length)
                {
                    PropertyInfo[] fiCheck = objPara.GetType().GetProperties();
                    paraReturn = new SqlParameter[arrFuction.Length];
                    for (int i = 0; i < arrFuction.Length; i++)
                    {
                        var value = objPara.GetType().GetProperty(arrMapping[i]) == null ? arrMapping[i] : objPara.GetType().GetProperty(arrMapping[i]).GetValue(objPara, null);
                        var paraName = arrFuction[i].Trim();
                        bool isOut = arrFuction[i].Trim().ToLower().Contains(" output");
                        var para = new SqlParameter();
                        para.ParameterName = paraName.Replace(" output", "");
                        if (!isOut)
                        {
                            if (value is string)
                            {
                                para.SqlDbType = SqlDbType.NVarChar;
                            }
                            if (value != null)
                                value = Extensions.ParseObjectWithDataType.GetObjectWithDatatype(arrFuction[i], value);

                            para.Value = value == null ? (object)DBNull.Value : value;
                        }
                        else
                        {
                            para.SqlDbType = SqlDbType.NVarChar;
                            para.Size = 500;
                        }
                        para.Direction = (isOut ? ParameterDirection.Output : ParameterDirection.Input);
                        paraReturn[i] = para;
                        if (!string.IsNullOrEmpty(sbHisPara.ToString()))
                            sbHisPara.Append(", ");
                        sbHisPara.AppendFormat("{0}={1}", arrFuction[i], value == null ? "NULL" : (value.ToString().Contains("@") ? value : string.Format("'{0}'", (value is DateTime ? ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss.fff") : value))));
                    }
                    sqlWithparaCombine = sbHisPara.ToString();
                    sblog.AppendFormat("[{0}] - Tham số gửi HIS [{1} {2} ", LogGroup.ToUpper(), (hisType == DBConnectType.POSTGRE ? "Select" : "Exec"), FunctionName.ToUpper());
                    sblog.Append(sbHisPara.ToString().Replace(" output", ""));
                    sblog.Append("]");
                    LogService.RecordLogFile("HISConnect", sblog.ToString(), "CREATE SQL COMMAND PARAMETER");
                    return paraReturn;
                }
            }
            else if (arrMapping.Length > 0 && arrMapping.Length == arrFuction.Length)
            {
                paraReturn = new SqlParameter[arrFuction.Length];
                for (int i = 0; i < arrFuction.Length; i++)
                {
                    var value = arrMapping[i];

                    var paraName = arrFuction[i].Trim();
                    bool isOut = arrFuction[i].Trim().ToLower().Contains(" output");
                    var para = new SqlParameter();
                    para.ParameterName = paraName.Replace(" output", "");
                    if (!isOut)
                    {
                        if (value is string)
                        {
                            para.SqlDbType = SqlDbType.NVarChar;
                        }
                        para.Value = value == null ? (object)DBNull.Value : value;
                    }
                    else
                    {
                        para.SqlDbType = SqlDbType.NVarChar;
                        para.Size = 250;
                    }
                    para.Direction = (isOut ? ParameterDirection.Output : ParameterDirection.Input);
                    paraReturn[i] = para;

                    if (!string.IsNullOrEmpty(sbHisPara.ToString()))
                        sbHisPara.Append(", ");
                    sbHisPara.AppendFormat("{0}={1}", arrFuction[i].Trim(), value == null ? "NULL" : string.Format("'{0}'", value));
                }
                sqlWithparaCombine = sbHisPara.ToString();
                sblog.AppendFormat("[{0}] - Tham số gửi HIS [{1} {2} ", (hisType == DBConnectType.POSTGRE ? "Select" : "Exec"), LogGroup.ToUpper(), FunctionName.ToUpper());
                sblog.Append(sbHisPara.ToString().Replace(" output", ""));
                sblog.Append("]");
                LogService.RecordLogFile("HISConnect", sblog.ToString(), "CREATE SQL COMMAND PARAMETER");
                return paraReturn;
            }
            return new SqlParameter[] { };
        }
        private void Get_DeclareForUptpara(string functionParaListMapping, ref string declareVar, ref string selectVar, ref List<string> selectedColumn)
        {
            StringBuilder sblog = new StringBuilder();
            var arrMapping = functionParaListMapping.Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrMapping.Length; i++)
            {
                if (arrMapping[i].Trim().ToLower().Contains(" output"))
                {
                    var variable = arrMapping[i].Replace(" output", "").Trim();
                    declareVar += string.IsNullOrEmpty(declareVar) ? string.Empty : ",";
                    declareVar += string.Format("@{0} as varchar(20)", variable.Replace("@", ""));

                    selectVar += string.IsNullOrEmpty(selectVar) ? string.Empty : ",";
                    selectVar += string.Format("@{0} as {0}", variable.Replace("@", ""));
                    selectedColumn.Add(variable);
                }
            }
            sblog.AppendFormat("Decalre {0}", declareVar);
            sblog.AppendFormat("\nSelect {0}", selectVar);
            LogService.RecordLogFile("HISConnect", sblog.ToString(), "CREATE SQL COMMAND PARAMETER");
        }

        public string CreateParaLog(object objPara, string FunctionName, string LogGroup)
        {
            StringBuilder sb = new StringBuilder();

            if (objPara != null)
            {
                PropertyInfo[] fiCheck = objPara.GetType().GetProperties();
                foreach (var item in fiCheck)
                {
                    var val = objPara.GetType().GetProperty(item.Name).GetValue(objPara, null);
                    if (!string.IsNullOrEmpty(sb.ToString()))
                        sb.Append(", ");
                    sb.AppendFormat("@{0}={1}", item.Name, val == null ? "NULL" : string.Format("'{0}'", val));
                }
            }
            var sblog = new StringBuilder();
            sblog.AppendFormat("[{0}] - Gọi store [exec/select {1} ( ", LogGroup.ToUpper(), FunctionName.ToUpper());
            sblog.Append(sb.ToString());
            sblog.Append(")]");
            return sblog.ToString();
        }
        /// <summary>
        /// Trà về cấu danh sách cột tương ưng dữ liệu trên his
        /// </summary>
        /// <returns></returns>
        public HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            var function = from item in hisColumns
                           where item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
                return function.FirstOrDefault();
            return null;
        }
        /// <summary>
        /// Bác sĩ
        /// </summary>
        /// <returns></returns>
        public DataTable DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucNhanVien) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;
                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục nhân viên");
                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục nhân viên", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục bác sĩ từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có dữ liệu danh mục bác sĩ từ HIS trả về");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucNhanVien));
            return null;
        }
        public DataTable DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucChanDoan) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == Data.HIS.HISDataCommon.FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục chẩn đoán");
                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục chẩn đoán", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục chẩn đoán từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có dữ liệu danh mục chẩn đoán từ HIS trả về");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucChanDoan));
            return null;
        }
        /// <summary>
        /// Đối tượng
        /// </summary>
        /// <returns></returns>
        public DataTable DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucDoiTuong) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == Data.HIS.HISDataCommon.FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục đối tượng");
                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục đối tượng", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục đối tượng từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có dữ liệu danh mục đối tượng từ HIS trả về");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucDoiTuong));
            return null;

        }
        /// <summary>
        /// Khoa phòng
        /// </summary>
        /// <returns></returns>
        public DataTable DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucKhoaPhong) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục khoa phòng");

                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục khoa phòng", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục khoa phòng từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có dữ liệu danh mục khoa phòng từ HIS trả về");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucKhoaPhong));
            return null;
        }
        /// <summary>
        /// Xét nghiệm
        /// </summary>
        /// <returns></returns>
        public DataTable DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucDichVu) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục dịch vụ");
                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục dịch vụ", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục dịch vụ từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có dữ liệu danh mục dịch vụ từ HIS trả về");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucDichVu));
            return null;


        }
        public DataTable DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucMayXetNghiem) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == Data.HIS.HISDataCommon.FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục máy XN");
                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục máy XN", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục máy XN từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Không có dữ liệu danh mục máy XN từ HIS trả về"));
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucMayXetNghiem));
            return null;
        }
        public DataTable DanhMucCongTy(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            string combineSQlpara = string.Empty;
            var function = from item in hisFunction
                           where item.FunctionID.Equals(objHisFunctionID.DanhMucCongTyHopDong) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == Data.HIS.HISDataCommon.FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Danh mục công ty");
                ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh mục công ty", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                if (ds.Tables.Count > 0)
                {
                    LogService.RecordLogFile("HISConnect", string.Format("Có dữ liệu danh mục công ty từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count));
                    return ds.Tables[0];
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có dữ liệu danh mục công ty từ HIS trả về");
                    return null;
                }
            }

            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", objHisFunctionID.DanhMucCongTyHopDong));
            return null;
        }
        /// <summary>
        /// Danh sách chỉ định chờ xét nghiệm
        /// </summary>
        /// <param name="paraInfo">HisParaGetList</param>
        /// <param name="hisConnect">HisConnection</param>
        /// <param name="hisFunctionMapping">List<HisFunctionConfig></param>
        /// <returns>DataTable</returns>
        public DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var DanhSachCho = objHisFunctionID.DanhSachCho;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfo.NoiTru)
                    DanhSachCho = objHisFunctionID.DanhSachChoNoiTru;
                else
                    DanhSachCho = objHisFunctionID.DanhSachCho;
            }
            string combineSQlpara = string.Empty;
            var function = from item in hisFunction
                           where item.FunctionID.Equals(DanhSachCho) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            if (function != null)
            {
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                if (paraInfo != null)
                {
                    CreateParaLog(paraInfo, objFunction.FunctionName, "Danh sách chờ xét nghiệm");

                    ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Danh sách chờ xét nghiệm", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                    if (ds != null)
                    {
                        dtOrder = ds.Tables[0];
                        LogService.RecordLogFile("HISConnect", string.Format("Số dữ liệu bệnh nhân chờ xét nghiệm trả về: {0}", dtOrder.Rows.Count));
                    }
                    else
                    {
                        LogService.RecordLogFile("HISConnect", "Không có dữ liệu bệnh nhân chờ xét nghiệm trả về");
                    }
                }
                foreach (DataColumn c in dtOrder.Columns)
                {
                    c.ColumnName = c.ColumnName.ToLower();
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", DanhSachCho));
            return dtOrder;
        }

        public DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var ChiTietChiDinh = objHisFunctionID.ChiTietChiDinh;

            if (hisConnect.DifferenceInOut)
            {
                if (paraInfo.NoiTru)
                    ChiTietChiDinh = objHisFunctionID.ChiTietChiDinhNoiTru;
                else
                    ChiTietChiDinh = objHisFunctionID.ChiTietChiDinh;
            }

            var function = from item in hisFunction
                           where item.FunctionID.Equals(ChiTietChiDinh) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                if (paraInfo != null)
                {
                    CreateParaLog(paraInfo, objFunction.FunctionName, "Chi tiết chỉ định");

                    ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                 , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                 , objFunction.LISColumns, paraInfo, "Chi tiết chỉ định", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                    if (ds != null)
                    {
                        dtOrder = ds.Tables[0];
                        LogService.RecordLogFile("HISConnect", string.Format("Số dữ liệu chi tiết chỉ định xét nghiệm trả về: {0}", dtOrder.Rows.Count));
                    }
                    else
                    {
                        LogService.RecordLogFile("HISConnect", "Không có dữ liệu chi tiết xét nghiệm trả về.");
                    }
                }

                foreach (DataColumn c in dtOrder.Columns)
                {
                    c.ColumnName = c.ColumnName.ToLower();
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", ChiTietChiDinh));
            return dtOrder;

        }

        /// <summary>
        /// Danh sách chi tiết chỉ định xét nghiệm
        /// </summary>
        /// <param name="paraInfo">HisParaGetList</param>
        /// <param name="hisConnect">HisConnection</param>
        /// <param name="hisFunctionMapping">List<HisFunctionConfig></param>
        /// <returns>DataTable</returns>
        public DataTable GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            var ChiTietChiDinh = objHisFunctionID.ChiTietBenhNhan;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfo.NoiTru)
                    ChiTietChiDinh = objHisFunctionID.ChiTietBenhNhanNoiTru;
                else
                    ChiTietChiDinh = objHisFunctionID.ChiTietBenhNhan;
            }

            var function = from item in hisFunction
                           where item.FunctionID.Equals(ChiTietChiDinh) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                if (paraInfo != null)
                {
                    CreateParaLog(paraInfo, objFunction.FunctionName, "Thông tin bệnh nhân xét nghiệm");

                    ds = HisDataProvider.ExecuteDataset(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, paraInfo, "Thông tin bệnh nhân xét nghiệm", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));

                    if (ds != null)
                    {
                        dtOrder = ds.Tables[0];
                        LogService.RecordLogFile("HISConnect", string.Format("Số dữ liệu thông tin bệnh nhân xét nghiệm trả về: {0}", dtOrder.Rows.Count));
                    }
                    else
                    {
                        LogService.RecordLogFile("HISConnect", "Không có dữ liệu thông tin bệnh nhân xét nghiệm trả về");
                    }
                }
            }

            foreach (DataColumn c in dtOrder.Columns)
            {
                c.ColumnName = c.ColumnName.ToLower();
            }
            return dtOrder;
        }
        /// <summary>
        /// Cập nhật trạng thái chỉ định
        /// </summary>
        /// <param name="hisConnect">HisConnection</param>
        /// <param name="hisFunction">List<HisFunctionConfig> </param>
        /// <param name="paraInfoList"> List<HisParaGetList></param>
        /// <returns>int Số dòng đã update</returns>
        public int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            var BatCoTrangThaiLay = objHisFunctionID.BatCoTrangThaiLay;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfoList.FirstOrDefault() != null)
                {
                    if (paraInfoList.FirstOrDefault().NoiTru)
                        BatCoTrangThaiLay = objHisFunctionID.BatCoTrangThaiLayNoiTru;
                    else
                        BatCoTrangThaiLay = objHisFunctionID.BatCoTrangThaiLay;
                }
            }

            var function = from item in hisFunction
                           where item.FunctionID.Equals(BatCoTrangThaiLay) && item.HisID == hisConnect.HisID
                           select item;
            int i = 0;
            if (function != null)
            {
                string combineSQlpara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;

                if (paraInfoList.Count > 0)
                {
                    foreach (var item in paraInfoList)
                    {
                        CreateParaLog(item, objFunction.FunctionName, "Cập nhật trạng thái lấy kết quả");

                        i = HisDataProvider.ExecuteNoneQuery(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, item, "Cập nhật trạng thái lấy kết quả", objFunction.FunctionName, ref combineSQlpara, hisConnect.DbType));
                    }
                    if (i > 0)
                    {
                        LogService.RecordLogFile("HISConnect", string.Format("Cập nhật xác nhận LIS đã lấy chỉ định: {0}", i));
                    }
                    else
                    {
                        LogService.RecordLogFile("HISConnect", "Không có thông tin HIS cập nhật LIS lấy chỉ định");
                    }
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", BatCoTrangThaiLay));
            return i;
        }
        public DataTable GetUploadKeyOfOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns)
        {
            var LayIDPhieuTraKetQua = objHisFunctionID.LayIdPhieuTraKetQuaXetNghiem;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfo != null)
                {
                    if (paraInfo.NoiTru)
                        LayIDPhieuTraKetQua = objHisFunctionID.LayIdPhieuTraKetQuaXetNghiemNoiTru;
                    else
                        LayIDPhieuTraKetQua = objHisFunctionID.LayIdPhieuTraKetQuaXetNghiem;
                }
            }
            var function = from item in hisFunction
                           where item.FunctionID.Equals(LayIDPhieuTraKetQua) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            var IDUpload = string.Empty;
            if (paraInfo != null)
            {
                var combineSQLPara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;
                var declareVar = string.Empty;
                var selectVar = string.Empty;

                CreateParaLog(paraInfo, objFunction.FunctionName, "Lấy ID Phiếu chuyển kết quả về HIS");
                CreateSQlPara(objFunction.FunctionParaNames
               , objFunction.LISColumns, paraInfo, "Lấy ID Phiếu chuyển kết quả về HIS", objFunction.FunctionName, ref combineSQLPara, hisConnect.DbType);

                Get_DeclareForUptpara(objFunction.LISColumns, ref declareVar, ref selectVar, ref SelectedColumns);

                var sqlCommand = string.Format("Declare {0}", declareVar);
                sqlCommand += string.Format("\nexec {0} {1}", objFunction.FunctionName, combineSQLPara);
                sqlCommand += string.Format("\nSelect {0}", selectVar);
                LogService.RecordLogFile("HISConnect", sqlCommand, "EXECUTE SQL COMMAND WITH SELECT DATA");

                var data = HisDataProvider.ExecuteDataset(hisConnect, cmtype, sqlCommand, null);
                if (data != null)
                {
                    var dt = data.Tables[0];
                    LogService.RecordLogFile("HISConnect", string.Format("Số lượng Lấy ID Phiếu chuyển kết quả về HIS: {0}", dt.Rows.Count));
                    return dt;
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có thông tin Lấy ID Phiếu chuyển kết quả về HIS.");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", LayIDPhieuTraKetQua));
            return null;
        }
        public DataTable GetUploadKeyOfDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo, ref List<string> SelectedColumns)
        {
            var LayIDTraKetQua = objHisFunctionID.LayIdTraKetQuaXetNghiem;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfo != null)
                {
                    if (paraInfo.NoiTru)
                        LayIDTraKetQua = objHisFunctionID.LayIdTraKetQuaXetNghiemNoiTru;
                    else
                        LayIDTraKetQua = objHisFunctionID.LayIdTraKetQuaXetNghiem;
                }
            }

            var function = from item in hisFunction
                           where item.FunctionID.Equals(LayIDTraKetQua) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            var IDUpload = string.Empty;
            if (paraInfo != null)
            {
                var combineSQLPara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;
                var declareVar = string.Empty;
                var selectVar = string.Empty;
                CreateParaLog(paraInfo, objFunction.FunctionName, "Lấy ID chuyển kết quả về HIS");
                CreateSQlPara(objFunction.FunctionParaNames
               , objFunction.LISColumns, paraInfo, "Lấy ID chuyển kết quả về HIS", objFunction.FunctionName, ref combineSQLPara, hisConnect.DbType);

                Get_DeclareForUptpara(objFunction.LISColumns, ref declareVar, ref selectVar, ref SelectedColumns);

                var sqlCommand = string.Format("Declare {0}", declareVar);
                sqlCommand += string.Format("\nexec {0} {1}", objFunction.FunctionName, combineSQLPara);
                sqlCommand += string.Format("\nSelect {0}", selectVar);
                LogService.RecordLogFile("HISConnect", sqlCommand, "EXECUTE SQL COMMAND WITH SELECT DATA");
                var data = HisDataProvider.ExecuteDataset(hisConnect, cmtype, sqlCommand, null);
                if (data != null)
                {
                    var dt = data.Tables[0];
                    LogService.RecordLogFile("HISConnect", string.Format("Số lượng Lấy ID chuyển kết quả về HIS: {0}", dt.Rows.Count));
                    return dt;
                }
                else
                {
                    LogService.RecordLogFile("HISConnect", "Không có thông tin Lấy ID chuyển kết quả về HIS.");
                    return null;
                }
            }
            LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", LayIDTraKetQua));
            return null;
        }

        /// <summary>
        /// Trả kết quả về HIS
        /// </summary>
        /// <param name="hisConnect">HisConnection</param>
        /// <param name="hisFunction">List<HisFunctionConfig></param>
        /// <param name="paraInfoList">List<HisResultBase></param>
        /// <returns>int Số dòng đã upload</returns>
        public int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , List<HisResultBase> paraInfoList)
        {
            if (hisConnect.HisID == HisProvider.FPT_SP)
                return TransferResultToHISFPT_SP(hisConnect, hisFunction, paraInfoList);
            else
                return StartUploadResult(hisConnect, hisFunction, paraInfoList, string.Empty);
        }

        private int TransferResultToHISFPT_SP(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , List<HisResultBase> paraInfoList)
        {
            //@Action, @CLSKetQua_Id, @CLSYeuCau_Id, @ThoiGianThucHien, @NoiThucHien_Id, @BacSiKetLuan_Id, @SID, @User_id
            //AddNew,@CLSKetQua_Id output,IDChiDinhDichVu,NgayTiepNhan,9,NullValue,MaTiepNhanLIS,NullValue
            var resultBase = paraInfoList.Select(x => x.SoPhieuYeuCau).Distinct();
            int count = 0;
            foreach (var sophieu in resultBase)
            {
                var rUpload = paraInfoList.Where(x => x.SoPhieuYeuCau.Equals(sophieu));
                var rInfo = rUpload.Where(x => x.NgayCoKetQua != null).FirstOrDefault();
                var paraInfo = new HisParaGetList
                {
                    ResultAction = FPTResultActionContanst.AddNew,
                    IDChiDinhDichVu = rInfo.IDDichVuHIS,
                    NgayTiepNhan = rInfo.NgayTiepNhan,
                    ThoiGianXacNhan = rInfo.NgayXacNhanKetQua,
                    ThoiGianCoKetQua = rInfo.NgayCoKetQua,
                    ThoiGianInKetQuaLanDau = rInfo.NgayInKetQualanDau,
                    MaTiepNhanLIS = rInfo.MaSoXetNghiem,
                    IDBSThucHien = rInfo.MaBacSiKetLuan,
                    IDUserThucHien = rInfo.MaNhanVienThucHien,
                    ThoiGianNhapBN = rInfo.ThoiGianTiepNhan
                };
                var SelectedColumns = new List<string>();

                var dataIDtraKetQua = GetUploadKeyOfDetail(hisConnect, hisFunction, paraInfo, ref SelectedColumns);
                //fpt lấy chỉ 1 para
                if (SelectedColumns.Count > 0 && dataIDtraKetQua.Rows.Count > 0)
                {
                    var idTraKetQua = string.Empty;
                    if (dataIDtraKetQua.Columns.Contains(SelectedColumns[0]))
                    {
                        idTraKetQua = dataIDtraKetQua.Rows[0][SelectedColumns[0]].ToString();
                        LogService.RecordLogFile("HISConnect", string.Format("ID trả kết quả: {0} = {1}", SelectedColumns[0], idTraKetQua));
                    }
                    else
                    {
                        idTraKetQua = dataIDtraKetQua.Rows[0][0].ToString();
                        LogService.RecordLogFile("HISConnect", string.Format("ID trả kết quả: {0} = {1}", dataIDtraKetQua.Columns[0].ColumnName, idTraKetQua));
                    }
                    count += StartUploadResult(hisConnect, hisFunction, rUpload.ToList(), idTraKetQua);
                }
            }
            return count;
        }
        private int StartUploadResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , List<HisResultBase> paraInfoList, string idTraketQua = "")
        {
            var TraKetQuaXetNghiem = objHisFunctionID.TraKetQuaXetNghiem;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfoList.FirstOrDefault() != null)
                {
                    if (paraInfoList.FirstOrDefault().NoiTru || paraInfoList.FirstOrDefault().NoiTruChar.Equals("I", StringComparison.OrdinalIgnoreCase))
                        TraKetQuaXetNghiem = objHisFunctionID.TraKetQuaXetNghiemNoiTru;
                    else
                        TraKetQuaXetNghiem = objHisFunctionID.TraKetQuaXetNghiem;
                }
            }

            var function = from item in hisFunction
                           where item.FunctionID.Equals(TraKetQuaXetNghiem) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            int i = 0;
            if (function != null)
            {
                var combineSQLPara = string.Empty;
                var objFunction = function.FirstOrDefault();
                DataSet ds = new DataSet();
                var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                    CommandType.StoredProcedure : CommandType.Text;
                int icount = 0;
                if (paraInfoList.Count > 0)
                {
                    foreach (var item in paraInfoList)
                    {
                        if (!string.IsNullOrEmpty(idTraketQua))
                            item.IdTraKetQua = idTraketQua;
                        item.ResultAction = FPTResultActionContanst.AddNew;
                        CreateParaLog(item, objFunction.FunctionName, "Chuyển kết quả về HIS");

                        icount = HisDataProvider.ExecuteNoneQuery(hisConnect, cmtype
                    , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                    , objFunction.LISColumns, item, "Chuyển kết quả về HIS", objFunction.FunctionName
                    , ref combineSQLPara, hisConnect.DbType));
                        LogService.RecordLogFile("HISConnect", string.Format("Thực thi trả về: {0}", icount));

                        i += icount > 0 ? 1 : 0;
                    }
                    if (i > 0)
                    {
                        LogService.RecordLogFile("HISConnect", string.Format("Số lượng LIS chuyển kết quả về HIS: {0}", i));
                        i += LISCheckUploadFinish(hisConnect, hisFunction, paraInfoList);
                    }
                    else
                    {
                        LogService.RecordLogFile("HISConnect", string.Format("Không có thông tin chuyển kết quả về HIS."));
                    }
                }
            }
            else
                LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", TraKetQuaXetNghiem));

            return i;
        }
        private int LISCheckUploadFinish(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList)
        {
            var BatTraKetQuaXetNghiemDu = objHisFunctionID.BatTraKetQuaXetNghiemDu;
            if (hisConnect.DifferenceInOut)
            {
                if (paraInfoList.FirstOrDefault() != null)
                {
                    if (paraInfoList.FirstOrDefault().NoiTru || paraInfoList.FirstOrDefault().NoiTruChar.Equals("I", StringComparison.OrdinalIgnoreCase))
                        BatTraKetQuaXetNghiemDu = objHisFunctionID.BatTraKetQuaXetNghiemDuNoiTru;
                    else
                        BatTraKetQuaXetNghiemDu = objHisFunctionID.BatTraKetQuaXetNghiemDu;
                }
            }

            var function = from item in hisFunction
                           where item.FunctionID.Equals(BatTraKetQuaXetNghiemDu) && item.HisID == hisConnect.HisID
                           select item;
            var dtOrder = new DataTable();
            int i = 0;
            if (function != null)
            {

                var combineSQLPara = string.Empty;
                var objFunction = function.FirstOrDefault();
                if (!string.IsNullOrEmpty(objFunction.FunctionName))
                {
                    DataSet ds = new DataSet();
                    var cmtype = objFunction.FunctionTypeID == FunctionType.StoreProcedure ?
                        CommandType.StoredProcedure : CommandType.Text;

                    if (paraInfoList.Count > 0)
                    {
                        var resultBase = new List<HisResultBase>();
                        if (hisConnect.HisID == HisProvider.FPT_SP)
                        {
                            resultBase.Add(paraInfoList.FirstOrDefault());
                        }
                        else
                        {
                            resultBase = paraInfoList;
                        }
                        foreach (var item in resultBase)
                        {
                            //  CreateParaLog(item, objFunction.FunctionName, "Xác nhận kết quả về HIS");

                            i = HisDataProvider.ExecuteNoneQuery(hisConnect, cmtype
                        , objFunction.FunctionName, CreateSQlPara(objFunction.FunctionParaNames
                        , objFunction.LISColumns, item, "Xác nhận kết quả về HIS", objFunction.FunctionName, ref combineSQLPara, hisConnect.DbType));
                        }

                        if (i > 0)
                        {
                            LogService.RecordLogFile("HISConnect", string.Format("Số lượng Xác nhận kết quả về HIS: {0}", i));
                        }
                        else
                        {
                            LogService.RecordLogFile("HISConnect", "Không có thông tin Xác nhận kết quả về HIS.");
                        }
                    }
                }
                else
                    LogService.RecordLogFile("HISConnect", string.Format("Function không khai báo: {0}.", BatTraKetQuaXetNghiemDu));
            }
            else
                LogService.RecordLogFile("HISConnect", string.Format("Function null {0}.", BatTraKetQuaXetNghiemDu));

            return i;
        }
    }
}
