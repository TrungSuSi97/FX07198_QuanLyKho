namespace TPH.Lab.Middleware.HISConnect.Services
{
    using System;
    using Models;
    using DataAccesses;
    using System.Reflection;
    using System.Data;
    using System.Windows.Forms;
    using Data.HIS.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Impl;
    using LIS.Common.Extensions;
    using Models.Vft;
    using System.Text;
    using WriteLog;
    using TPH.HIS.WebAPI.Services;
    using TPH.HIS.WebAPI.Services.Impl;
    using TPH.HIS.WebAPI.Models.Params;
    using TPH.HIS.WebAPI.Constants;
    using Extensions;
    using Newtonsoft.Json;
    using HIS.WebAPI.Models.HisReponses;
    using TPH.Data.HIS;
    using Newtonsoft.Json.Linq;
    using System.Collections;
    using TPH.Data.HIS.Models.VNPT;
    using TPH.LIS.Patient.Model;
    using System.Runtime.CompilerServices;

    public class GetHISService : IGetHISService
    {
        private IGetHISDataAccess_DaiHocCanTho _hisDataAccess_DaiHocCanTho = new GetHISDataAccess_DaiHocCanTho();
        private IGetHISDataAccess_DHHospital _hisDataAccess_DHHospital = new GetHISDataAccess_DHHospital();
        private IGetHISDataAccess_MSSQLTrungGian _hisDataAccess_MSSQLTrungGian = new GetHISDataAccess_MSSQLTrungGian();
        private IVnptFujitsuService _hisDataAccess_VPTFujitsu = new VnptFujitsuService();
        private IWebAPIService _APIService = new WebAPIServiceImpl();
        private IHL7v25Service HL7v25 = new HL7v25Services();
        private HisFunctionID objHisFunctionID = new HisFunctionID();
        public HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            var function = from item in hisColumns
                           where item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
                return function.FirstOrDefault();
            return null;
        }
        public void SetDataPropertyNameForDatagriview(DataGridView dgv, HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            foreach (DataGridViewColumn dgc in dgv.Columns)
            {
               var visible = SetDataPropertyNameForDatagriviewColumn(dgc, hisConnect, hisColumns);
                dgc.Visible = visible;
            }
        }
        public bool SetDataPropertyNameForDatagriviewColumn(DataGridViewColumn dgc, HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            string[] arrColName = dgc.Name.Split('_');
            if (arrColName.Length > 2)
            {
                var HisColumnsName = GetHisColumnNameConfiguartion(hisConnect, hisColumns);
                PropertyInfo[] fiCheck = HisColumnsName.GetType().GetProperties();
                foreach (PropertyInfo f in fiCheck)
                {
                    if (f.Name.Equals(arrColName[2], StringComparison.OrdinalIgnoreCase))
                    {
                        var propertiesVal = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null);
                        if (propertiesVal != null)
                        {
                            if (!string.IsNullOrEmpty(propertiesVal.ToString()))
                            {
                                dgc.DataPropertyName = propertiesVal.ToString();
                                return true;
                            }
                            else
                            {
                                dgc.DataPropertyName = string.Empty;
                                dgc.Visible = false;
                            }
                            return false;
                        }
                        else
                        {
                            dgc.DataPropertyName = string.Empty;
                            dgc.Visible = false;
                        }
                        return false;
                    }
                }
            }
            return false;
        }
        public HISReturnBase CombineDatareturn(int code, string message, DataTable data)
        {
            return new HISReturnBase
            {
                Code = code,
                Message = ErrorLibrary.ConvertErrorToVietNamese(message),
                Data = data
            };
        }
        private LisRequestParams GetAPIRequestPara(HisConnection hisConnect,
       List<HisFunctionConfig> hisFunction, string hisFunctionId, HisParaGetList paraInfoList = null,
            string userDoing = "")
        {
            var apiName = string.Empty;
            var webMethod = string.Empty;

            var para = ParseApiObjectToDictionary(hisConnect, hisFunction, hisFunctionId,
                ref apiName, ref webMethod, paraInfoList);
            if (hisFunctionId.Equals(objHisFunctionID.LayToken, StringComparison.OrdinalIgnoreCase))
            {
                return new LisRequestParams
                {
                    ClientName = userDoing,
                    APIName = apiName,
                    HisId = (int)hisConnect.HisID,
                    WebMethod = webMethod,
                    Param = para
                };
            }
            else
            {
                var paraMain = new LisRequestParams
                {
                    ClientName = userDoing,
                    APIName = apiName,
                    HisId = (int)hisConnect.HisID,
                    WebMethod = webMethod,
                    Param = para
                };
                GetToken(hisConnect, hisFunction, ref paraMain);
                return paraMain;
            }
        }
        private Dictionary<string, dynamic> ParseApiObjectToDictionary(HisConnection hisConnect
    , List<HisFunctionConfig> hisFunction, string functionName, ref string apiName, ref string webMethod, object objPara = null)
        {
            var returnDic = new Dictionary<string, dynamic>();
            var function = from item in hisFunction
                           where item.FunctionID.Equals(functionName) && item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
            {
                var sblog = new StringBuilder();
                var objFunction = function.FirstOrDefault();

                var functionApi = objFunction.FunctionParaNames.Trim()
                    .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var functionPara = objFunction.LISColumns.Trim()
                    .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                apiName = objFunction.FunctionName;
                webMethod = objFunction.FunctionTypeID.ToString();

                if (functionPara.Length >= functionApi.Length && functionPara.Length > 0)
                {
                    var funcLength = functionApi.Length;
                    sblog.AppendFormat("{0} - Tham số gửi HIS [{1}?", functionName.ToUpper(), apiName);
                    if (objPara != null)
                    {
                        PropertyInfo[] fiCheck = objPara.GetType().GetProperties();

                        for (var i = 0; i < funcLength; i++)
                        {
                            var value = (object)null;
                            var valueOfSecurity = false;

                            var logValue = (object)null;
                            var secuLogValue = string.Empty;
                            if (functionPara[i] != null)
                            {
                                var paraFormat = functionPara[i].Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
                                var paraName = paraFormat[0];
                                if (paraName.Contains("(") && paraName.Contains(")"))
                                    paraName = paraName.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries)[0];
                                value = objPara.GetType().GetProperty(paraName) == null ?
                                    paraName.Replace("{password}", hisConnect.PassWord).Replace("{username}", hisConnect.UserName) :
                                    objPara.GetType().GetProperty(paraName).GetValue(objPara, null);
                                if (value != null)
                                    value = ParseObjectWithDataType.GetObjectWithDatatype(functionPara[i], value);
                                if (paraFormat.Length > 1)
                                {
                                    if (paraFormat[1] != null)
                                        value = string.Format(paraFormat[1], value);
                                }
                                if (paraFormat[0].Equals("{password}", StringComparison.OrdinalIgnoreCase) || paraFormat[0].Equals("{username}", StringComparison.OrdinalIgnoreCase))
                                {
                                    valueOfSecurity = true;
                                    secuLogValue = paraFormat[0];
                                }
                            }
                            if (functionApi[i].Equals("BatThuongBool", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!string.IsNullOrEmpty(value.ToString()))
                                {
                                    var obj = bool.Parse(value.ToString());
                                    returnDic.Add(functionApi[i], obj);
                                }
                            }
                            else
                                returnDic.Add(functionApi[i], value);
                            logValue = value;
                            if (valueOfSecurity)
                                logValue = string.Format("[para:{0}]", secuLogValue);

                            sblog.AppendFormat("{2}{0}={1}", functionApi[i], logValue, (i > 0 ? "&" : string.Empty));
                        }
                    }
                    else
                    {
                        for (var i = 0; i < funcLength; i++)
                        {
                            var value = (object)null;
                            var paraFormat = functionPara[i].Split(new string[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);
                            var paraName = paraFormat[0];
                            if (paraName.Contains("(") && paraName.Contains(")"))
                                paraName = paraName.Split(new string[] { "(", ")" }, StringSplitOptions.RemoveEmptyEntries)[0];

                            value = paraName.Replace("{password}", hisConnect.PassWord).Replace("{username}", hisConnect.UserName);

                            value = ParseObjectWithDataType.GetObjectWithDatatype(functionPara[i], value);
                            if (paraFormat.Length > 1)
                            {
                                if (paraFormat[1] != null)
                                    value = string.Format(paraFormat[1], value);
                            }

                            returnDic.Add(functionApi[i], value);
                            var logValue = value;
                            if (paraFormat[0].Equals("{password}", StringComparison.OrdinalIgnoreCase) || paraFormat[0].Equals("{username}", StringComparison.OrdinalIgnoreCase))
                                logValue = string.Format("[para:{0}]", paraFormat[0]);
                            sblog.AppendFormat("{2}{0}={1}", functionApi[i], logValue ?? "NULL", (i > 0 ? "&" : string.Empty));
                        }
                    }
                    sblog.Append("]");
                    LogService.RecordLogFile(string.Format("WebAPI_HISID_{0}_", (int)hisConnect.HisID), sblog.ToString(), "CREATE WEBSERVICE PARAMETER");
                }
            }
            return returnDic;
        }
        #region Parse data to object HL7
        private void SetDataFromDictionaryToObject(Dictionary<string, dynamic> dicIn, object objIn)
        {
            var objProp = objIn.GetType().GetProperties();
            foreach (var item in dicIn.Keys)
            {
                foreach (PropertyInfo prop in objProp)
                {
                    if (prop.Name.Equals(item, StringComparison.OrdinalIgnoreCase))
                    {
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            prop.SetValue(objIn, dicIn[item]);
                        }
                        else
                            prop.SetValue(objIn, dicIn[item], null);
                        break;
                    }
                }
            }
        }
        private HL7PatientInfo ParseDataToHL7PatientInfo(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, ref string apiName, ref string webMethod, object objPara = null)
        {
            var objPtient = new HL7PatientInfo();
            string functionName = objHisFunctionID.TraKetQuaXetNghiemHL7PID;
            var dicPid = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref apiName, ref webMethod, objPara);
            if (dicPid != null)
            {
                SetDataFromDictionaryToObject(dicPid, objPtient);
            }
            return objPtient;
        }
        private HL7ResultUpload ParseDataToHL7Result(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, ref string apiName,  ref string webMethod, object objPara = null)
        {
            var objResult = new HL7ResultUpload();
            //Get data for orc
            string functionName = objHisFunctionID.TraKetQuaXetNghiemHL7ORC;
            var dicORC = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref apiName, ref webMethod, objPara);
            if (dicORC != null)
            {
                objResult.hL7ORCResult = new HL7ORC_ADT_Detail();
                SetDataFromDictionaryToObject(dicORC, objResult.hL7ORCResult);
            }
            //Get data for pid
            functionName = objHisFunctionID.TraKetQuaXetNghiemHL7PID;
            var dicPID = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref apiName, ref webMethod, objPara);
            if (dicPID != null)
            {
                objResult.hL7Patient = new HL7PatientInfo();
                SetDataFromDictionaryToObject(dicPID, objResult.hL7Patient);
            }
            //Lấy obx sau cùng để có thông tin api trả về HIS
            //Get data for obx
            functionName = objHisFunctionID.TraKetQuaXetNghiem;
            var dicOBX = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref apiName, ref webMethod, objPara);
            if (dicOBX != null)
            {
                objResult.hL7OBXResult = new HL7OBX();
                SetDataFromDictionaryToObject(dicOBX, objResult.hL7OBXResult);
            }
          
            return objResult;
        }
        private HL7ResultUpload ParseDataToHL7Status(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, ref string apiName, ref string webMethod, HisParaGetList objPara)
        {
            var objResult = new HL7ResultUpload();
            string tempapiName =string.Empty;
            string tempMethod = string.Empty;
            //Get data for orc
            string functionName = objHisFunctionID.TraKetQuaXetNghiemHL7ORC;
            if (objPara == null)
                return objResult;
            var dicORC = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref tempapiName, ref tempMethod, objPara.DataTestInfo);
            if (dicORC != null)
            {
                objResult.hL7ORCResult = new HL7ORC_ADT_Detail();
                SetDataFromDictionaryToObject(dicORC, objResult.hL7ORCResult);
                functionName = objHisFunctionID.BatCoTrangThaiLay;
                var dicStatus = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref apiName, ref webMethod, objPara);
                SetDataFromDictionaryToObject(dicStatus, objResult.hL7ORCResult);
            }
            //Get data for pid
            functionName = objHisFunctionID.TraKetQuaXetNghiemHL7PID;
            var dicPID = ParseApiObjectToDictionary(hisConnect, hisFunction, functionName, ref tempapiName, ref tempMethod, objPara.DataTestInfo);
            if (dicPID != null)
            {
                objResult.hL7Patient = new HL7PatientInfo();
                SetDataFromDictionaryToObject(dicPID, objResult.hL7Patient);
            }
            return objResult;
        }
        #endregion
        #region Token
        private static Dictionary<string, string> dicToken = new Dictionary<string, string>();
        public void GetToken(HisConnection hisConnect
            , List<HisFunctionConfig> hisFunction
            , ref LisRequestParams paraMain)
        {
            if (string.IsNullOrEmpty(objHisFunctionID.LayToken))
            {
                paraMain.UseToken = false;
            }
            else
            {
                paraMain.UseToken = true;
                string rememberTokenFormat = "{0}|^|{1}|^|{2}";
                if (hisConnect.HisID != Data.HIS.HISDataCommon.HisProvider.ISofH)
                {
                    if (dicToken.Where(x => x.Key.Equals(hisConnect.HisID.ToString())).Any())
                    {
                        var lstToken = dicToken[hisConnect.HisID.ToString()];
                        var arrToken = lstToken.Split(new string[] { "|^|" }, StringSplitOptions.RemoveEmptyEntries);
                        if (arrToken.Length == 3)
                        {
                            var expire = DateTime.Parse(arrToken[2]);
                            if (expire.AddSeconds(-5) >= DateTime.Now)
                            {
                                paraMain.Access_token = arrToken[0];
                                paraMain.Token_type = arrToken[1];
                                paraMain.Expires_in = DateTime.Parse(arrToken[2]);
                                return;
                            }
                        }
                    }
                }
                //Sau khi kiểm tra mà token chưa có hoặc đã hết hạn.
                if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
                {
                    var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.LayToken, null);
                    var objData = _APIService.GetTokenKey(para);
                    if (objData != null)
                    {
                        if (objData.Data != null)
                        {
                            var data = (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data);
                            paraMain.Access_token = data.Rows[0]["access_token"].ToString();
                            paraMain.Token_type = data.Rows[0]["token_type"].ToString();
                            var exprires = data.Rows[0]["expires_in"].ToString();
                            if (WorkingServices.IsNumeric(exprires))
                            {
                                paraMain.Expires_in = WorkingServices.ConvertDate(DateTime.Now.AddSeconds(int.Parse(exprires)).ToString("MM/dd/yyyy HH:mm:ss"));
                            }
                            else
                                paraMain.Expires_in = WorkingServices.ConvertDate(data.Rows[0]["expires_in"].ToString());
                        }
                    }
                }
                else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
                {
                    var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.LayToken, null);
                    var objData = _APIService.GetTokenKey(para);
                    if (objData != null)
                    {
                        if (objData.Data != null)
                        {
                            var exprires = string.Empty;
                            var data = WorkingServices.ConvertDynamicToDictionary(objData.Data);

                            paraMain.Access_token = data["access_token"].ToString();
                            paraMain.Token_type = data["token_type"].ToString();
                            exprires = data["expires_in"].ToString();

                            if (WorkingServices.IsNumeric(exprires))
                            {
                                paraMain.Expires_in = DateTime.Now.AddSeconds(int.Parse(exprires));
                            }
                            else
                                paraMain.Expires_in = DateTime.Parse(exprires);
                        }
                    }
                }
                //Token sau khi lấy ghi vào thư viện
                var tokenAdd = string.Format(rememberTokenFormat, paraMain.Access_token, paraMain.Token_type, (paraMain.Expires_in == DateTime.MinValue ? DateTime.Now : paraMain.Expires_in).ToString());
                if (dicToken.Where(x => x.Key.Equals(hisConnect.HisID.ToString())).Any())
                {
                    dicToken[hisConnect.HisID.ToString()] = tokenAdd;
                }
                else
                    dicToken.Add(hisConnect.HisID.ToString(), tokenAdd);
            }
        }
        #endregion
        public HISReturnBase DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Data = null;
            returData.Code = -1;
            returData.Message = "Không có thông tin HIS";

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucXetNghiem(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.DanhMucXetNghiem(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucXetNghiem(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DanhMucXetNghiem(hisConnect));
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData =  _APIService.GetListOfTestISOFH(para);
                
                if (objData.Data != null)
                {
                    var objList = JsonConvert.SerializeObject(objData.Data);
                    var objList2 = JsonConvert.DeserializeObject<IList<DanhSachXetNghiemISofH>>(objList);
                    return CombineDatareturn(objData.Code, objData.Message, LayDanhSachDichVuISOFH(objList2));
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDichVu);
                var objData = _APIService.GetListOfTest(para);
                if (objData.Data != null)
                {
                    var jsonData = JsonConvert.SerializeObject(objData.Data);
                    List<DanhMucXetNghiemVNPT> benhNhans = JsonConvert.DeserializeObject<List<DanhMucXetNghiemVNPT>>(jsonData);
                    var lstReturn = new List<DanhMucXetNghiemVNPTForLIS>();

                    foreach (var sourceObject in benhNhans)
                    {
                        var targetObject = new DanhMucXetNghiemVNPTForLIS();
                        // Get the type of the target object
                        Type targetType = targetObject.GetType();
                        // Get the type of the source object
                        Type sourceType = sourceObject.GetType();
                        // Get all properties of the target object
                        PropertyInfo[] sourceProperties = sourceType.GetProperties();
                        // Loop through each property of the target object
                        foreach (PropertyInfo sourceProperty in sourceProperties)
                        {
                            if (sourceProperty.PropertyType == typeof(LoaiXetNghiemVNPT))
                            {
                                targetObject.tenLoai = sourceObject.loaiXetNghiem.tenLoai;
                                targetObject.dvtt = sourceObject.loaiXetNghiem.dvtt;

                                targetObject.moTa = sourceObject.loaiXetNghiem.moTa;
                                targetObject.hoatDong = sourceObject.loaiXetNghiem.hoatDong;
                            }
                            else
                            {
                                // Check if the source object has a property with the same name
                                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);

                                if (targetProperty != null)
                                {
                                    // Get the value of the source property
                                    object sourceValue = sourceProperty.GetValue(sourceObject, null);

                                    // Set the value of the target property
                                    targetProperty.SetValue(targetObject, sourceValue, null);
                                }
                            }
                        }
                        lstReturn.Add(targetObject);
                    }

                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(lstReturn, true, "-"));
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public DataTable LayDanhSachBacSiISOFH(List<DanhMucBacSiISOFH> lstISofH)
        {
            var data = new DataTable();
            data.Columns.Add("MaBacSi", typeof(string));
            data.Columns.Add("TenBacSi", typeof(string));
            data.Columns.Add("ChucVu", typeof(string));
           
            foreach (var item in lstISofH)
            {
                var drDV = data.NewRow();
                drDV["MaBacSi"] = (item.ma ?? string.Empty);
                drDV["TenBacSi"] = (item.ten ?? string.Empty);
                drDV["ChucVu"] = item.chucVu;
                data.Rows.Add(drDV);
            }
            return data;
        }
        public DataTable LayDanhSachDichVuISOFH(List<DanhSachXetNghiemISofH> lstISofH)
        {
            var data = new DataTable();
            data.Columns.Add("MaLoaiDV", typeof(string));
            data.Columns.Add("TenLoaiDV", typeof(string));
            data.Columns.Add("MaDV", typeof(string));
            data.Columns.Add("TenDichVu", typeof(string));
            data.Columns.Add("MaLIS", typeof(string));
            data.Columns.Add("MaCapTren", typeof(string));
            foreach (var item in lstISofH)
            {
                var drDV = data.NewRow();
                drDV["MaLoaiDV"] = (item.MaLoaiDV ?? string.Empty);
                drDV["TenLoaiDV"] = (item.TenDichVu ?? string.Empty);
                drDV["MaDV"] = item.MaDV;
                drDV["TenDichVu"] = item.TenDichVu;
                drDV["MaLIS"] = item.MaLIS;
                //  drDV["MaCapTren"] = item.MaLIS;
                data.Rows.Add(drDV);
                if (item.ListSubService != null)
                {
                    if (item.ListSubService.Count > 0)
                    {
                        foreach (var itemSub in item.ListSubService)
                        {
                            var drDVSub = data.NewRow();
                            drDVSub["MaLoaiDV"] = (itemSub.MaLoaiDV ?? string.Empty);
                            drDVSub["TenLoaiDV"] = (itemSub.TenDichVu ?? string.Empty);
                            drDVSub["MaDV"] = itemSub.MaDV;
                            drDVSub["TenDichVu"] = itemSub.TenDichVu;
                            drDVSub["MaLIS"] = itemSub.MaLIS;
                            drDVSub["MaCapTren"] = item.MaLIS;
                            data.Rows.Add(drDVSub);
                        }
                    }
                }
            }
            return data;
        }
        public HISReturnBase DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucBacSi(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.DanhMucBacSi(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucBacSi(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DanhMucBacSi(hisConnect));
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                {
                    var objList = JsonConvert.SerializeObject(objData.Data);
                    var objList2 = JsonConvert.DeserializeObject<IList<DanhMucBacSiISOFH>>(objList);
                    return CombineDatareturn(objData.Code, objData.Message, LayDanhSachBacSiISOFH(objList2));
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucNhanVien);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                {
                    var dicData = new List<Dictionary<string, string>>();
                    foreach (var item in objData.Data)
                    {
                        var dicMa = new Dictionary<string, string>();
                        var j = (JToken)item;
                        foreach (JProperty jProperty in j.Children().OfType<JProperty>())
                        {
                            if(jProperty.Type != JTokenType.Array)
                            {
                                var jt = (JToken)jProperty;
                                if (!jProperty.Name.Equals("phongban", StringComparison.OrdinalIgnoreCase) && !jProperty.Name.Equals("chucDanh", StringComparison.OrdinalIgnoreCase))
                                {
                                    dicMa.Add(jProperty.Name, jProperty.Value.ToString());
                                }
                            }
                        }
                        dicData.Add(dicMa);
                    }

                    var strData = JsonConvert.SerializeObject(dicData);
                    JObject jobject = JObject.Parse("{" + "\"Data\":" + strData + "}");
                    var response = JsonConvert.DeserializeObject<ResultResponse>(jobject.ToString());
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(response.Data));

                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucKhoaPhong(HisConnection hisConnect, List < HisFunctionConfig > hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucKhoaPhong(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.DanhMucKhoaPhong(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi 
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucKhoaPhong(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DanhMucKhoa(hisConnect));
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucKhoaPhong);
                var objData = _APIService.GetListOfDepartment(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucDoiTuong(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.DanhMucDoiTuong(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucDoiTuong(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DanhMucDoiTuong(hisConnect));
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucDoiTuong);
                var objData = _APIService.GetListOfObject(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucChanDoan(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.DanhMucChanDoan(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi 
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucChanDoan(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DanhMucChanDoan(hisConnect));
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucChanDoan);
                var objData = _APIService.GetListOfDiagnose(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            return returData;
        }
        public HISReturnBase DanhMucMayXN(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucMayXN(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucMayXN(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucMayXetNghiem);
                var objData = _APIService.GetListOfCompany(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP)
            {
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucCongTy(hisConnect, hisFunction);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucPhong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucSinhLy(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucSinhLy);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucCongTyHopDong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
           else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucCongTyHopDong);
                var objData = _APIService.GetListOfRoom(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase DanhMucLoaiMau(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.DanhMucBacSi(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.DanhMucBacSi(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.DanhMucBacSi(hisConnect, hisFunction);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DanhMucBacSi(hisConnect));
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                {
                    var objList = JsonConvert.SerializeObject(objData.Data);
                    var objList2 = JsonConvert.DeserializeObject<IList<DanhMucBacSiISOFH>>(objList);
                    return CombineDatareturn(objData.Code, objData.Message, LayDanhSachBacSiISOFH(objList2));
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhMucLoaiMau);
                var objData = _APIService.GetListOfDoctor(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public int LISCheckHL7(HisConnection hisConnect, List<HisFunctionConfig> hisFunction
            , List<HisParaGetList> paraInfoList, List<HisResultBase> paraResultBase)
        {

            var para = new LisRequestParams
            {
                HisUrl = hisConnect.ServerName,
                HisUser = hisConnect.UserName,
                HisPassword = hisConnect.PassWord,
                LisUrl = hisConnect.LISServerName,
                LisUser = hisConnect.LISUserName,
                LisPassword = hisConnect.LISPassword,
                ClientName = hisConnect.ServerName,
                HisId = (int)hisConnect.HisID
            };

            var iCount = 0;
            switch (hisConnect.HisID)
            {
                case Data.HIS.HISDataCommon.HisProvider.ISofH:
                    {
                        string APIName = string.Empty;
                        var webMethod = string.Empty;
                        foreach (var item in paraInfoList)
                        {
                            item.DataTestInfo = paraResultBase.Where(x => x.MaDichVuHIS.Equals(item.MaXetNghiemLIS)).FirstOrDefault();
                        }

                        var lstSoPhieu = from p in paraResultBase
                                         group p by p.SoPhieuYeuCau into g
                                         select new { SoPhieuYeuCau = g.Key };
                        foreach (var item in lstSoPhieu)
                        {

                            var lstUploadHl7ListThuongQuy = new List<HL7ResultUpload>();
                            var dataWithSoPhieu = paraInfoList.Where(x => ((x.DataTestInfo ?? new HisResultBase()).SoPhieuYeuCau ?? String.Empty).Equals(item.SoPhieuYeuCau));
                            if (dataWithSoPhieu.Any())
                            {
                                foreach (var sophieuData in dataWithSoPhieu)
                                {
                                    var uploadHL7 = ParseDataToHL7Status(hisConnect, hisFunction, ref APIName, ref webMethod, sophieuData);
                                    if (uploadHL7.hL7ORCResult != null)
                                        lstUploadHl7ListThuongQuy.Add(uploadHL7);
                                }
                                if (lstUploadHl7ListThuongQuy.Count > 0)
                                {
                                    var strData = HL7v25.DataOrderStatusToHL7(lstUploadHl7ListThuongQuy);
                                    para.APIName = APIName;
                                    para.WebMethod = webMethod;
                                    para.Param = new Dictionary<string, dynamic>();
                                    if (!para.Param.Keys.Contains("data"))
                                        para.Param.Add("data", strData);
                                    else
                                        para.Param["data"] = strData;
                                    if (!para.Param.Keys.Contains("ordercode"))
                                        para.Param.Add("ordercode", item.SoPhieuYeuCau);
                                    else
                                        para.Param["ordercode"] = item.SoPhieuYeuCau;

                                    GetToken(hisConnect, hisFunction, ref para);
                                    var objData = _APIService.UpdateOrderStatus(para);

                                    if (objData.Data != null)
                                        iCount++;
                                }
                            }
                        }
                        break;
                    }
            }
            return iCount;
        }
        public int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            switch (hisConnect.HisID)
            {
                case Data.HIS.HISDataCommon.HisProvider.DH_DHG:
                    return _hisDataAccess_DHHospital.LISCheck(hisConnect, hisFunction, paraInfoList);
                case Data.HIS.HISDataCommon.HisProvider.DHCanTho:
                    return _hisDataAccess_DaiHocCanTho.LISCheck(hisConnect, hisFunction, paraInfoList);
                case Data.HIS.HISDataCommon.HisProvider.AHoi:
                case Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT:
                case Data.HIS.HISDataCommon.HisProvider.FPT_SP:
                case Data.HIS.HISDataCommon.HisProvider.HangMinh:
                case Data.HIS.HISDataCommon.HisProvider.SHPT:
                    return _hisDataAccess_MSSQLTrungGian.LISCheck(hisConnect, hisFunction, paraInfoList);
                case Data.HIS.HISDataCommon.HisProvider.VFT:
                {
                    var para = new List<Models.Vft.UpdateOrderStatusParams>();
                    foreach (var item in paraInfoList)
                    {
                        para.Add(new Models.Vft.UpdateOrderStatusParams()
                        {
                            IdChiDinhDichVu = item.IDChiDinh,
                            SoPhieuYeuCau = item.SoPhieuChiDinh,
                            TrangThai = item.TrangThai.Value
                        });
                    }
                    return _hisDataAccess_VPTFujitsu.CapNhatTrangThaiChiDinh(para, hisConnect).Id;
                }
                case Data.HIS.HISDataCommon.HisProvider.Vimes:
                {
                    var iCount = 0;
                    foreach (var item in paraInfoList)
                    {
                        var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                        var objData = _APIService.UpdateOrderStatus(para);

                        if (objData.Data != null)
                            iCount++;

                    }
                    return iCount;
                }
                case Data.HIS.HISDataCommon.HisProvider.DH_API:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;

                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.PTT_API:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;

                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.SUN:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;

                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.TPSoft:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;
                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.Leopard:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;

                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.ECOCLINIC:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;

                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.PKTDK_IT:
                    {
                        var iCount = 0;
                        foreach (var item in paraInfoList)
                        {
                            var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            var objData = _APIService.UpdateOrderStatus(para);

                            if (objData.Data != null)
                                iCount++;

                        }
                        return iCount;
                    }
                case Data.HIS.HISDataCommon.HisProvider.VNPTMN:
                    {
                        var iCount = 0;
                        var lstPara = new List<LisRequestParams>();
                        LisRequestParams paReturn = null;
                        foreach (var item in paraInfoList)
                        {
                            if (paReturn == null)
                            {
                                paReturn = new LisRequestParams();
                            }
                            paReturn = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.BatCoTrangThaiLay, item);
                            lstPara.Add(paReturn);
                        }
                        var lstId = new List<Dictionary<string, string>>();
                        int status = -1;
                        foreach (var itm in lstPara)
                        {
                            var dic = new Dictionary<string, string>();
                            dic.Add("maXetNghiem", itm.Param["maXetNghiem"].ToString());
                            dic.Add("tenXetNghiem", itm.Param["tenXetNghiem"].ToString());
                            lstId.Add(dic);
                            if (status == -1)
                            {
                                status = int.Parse(itm.Param["trangThai"].ToString());
                            }
                        }
                        //xóa maxetnghiem va tenxet nghiem khỏi dic
                        paReturn.Param.Remove("maXetNghiem");
                        paReturn.Param.Remove("tenXetNghiem");
                        paReturn.Param.Add("xetNghiems", lstId);
                        paReturn.ConvertJObject = true;
                        var objData = _APIService.UpdateOrderStatus(paReturn);
                        if (objData.Data != null)
                            iCount++;
                        return iCount;
                    }
                default:
                    return -1;
            }
        }
        public HISReturnBase Update_HuyKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            switch (hisConnect.HisID)
            {
                case Data.HIS.HISDataCommon.HisProvider.VNPTMN:
                    {
                        var iCount = 0;
                        var lstPara = new List<LisRequestParams>();
                        LisRequestParams paReturn = null;
                        foreach (var item in paraInfoList)
                        {
                            if (paReturn == null)
                            {
                                paReturn = new LisRequestParams();
                            }
                            paReturn = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.HuyKetQua, item);
                            lstPara.Add(paReturn);
                        }
                        var lstId = new List<Dictionary<string, dynamic>>();
                        foreach (var itm in lstPara)
                        {
                            var dic = new Dictionary<string, dynamic>
                            {
                                { "maXetNghiem", itm.Param["maXetNghiem"]},
                                { "tenXetNghiem", itm.Param["tenXetNghiem"]}
                            };
                            lstId.Add(dic);
                        }
                        //xóa maxetnghiem va tenxet nghiem khỏi dic
                        paReturn.Param.Remove("maXetNghiem");
                        paReturn.Param.Remove("tenXetNghiem");
                        var dicUpload = new Dictionary<string, dynamic>
                        {
                            { "danhSachXN", lstId }
                        };
                        foreach (var item in paReturn.Param)
                        {
                            dicUpload.Add(item.Key, item.Value);
                        }
                        paReturn.Param = dicUpload;
                        paReturn.ConvertJObject = true;
                        var objData = _APIService.UpdateOrderStatus(paReturn);
                        if (objData.Data != null)
                            iCount++;
                        if (iCount > 0)
                            returData.Code = 1;
                        break;
                    }
                default:
                    {
                        returData.Code = 0;
                        returData.Message = "Không có thông tin HIS";
                        break;
                    }
            }
            return returData;
        }
        public HISReturnBase Update_TGHenTraKetQua(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List< HisParaGetList> paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {if (paraInfoList.Count > 0)
                {
                    foreach (var item in paraInfoList)
                    {
                        var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.CapNhatTGHenTraKQ, item);
                        var objData = _APIService.PatientInfomation(para);
                        //return CombineDatareturn(objData.Code, objData.Message,
                        //    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
                    }
                }
            }
            return returData;
        }
        public HISReturnBase Get_BsLayMauThuThuat(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                if (paraInfoList.Count > 0)
                {
                    foreach (var item in paraInfoList)
                    {
                        var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.EkipPhauThuat, item);
                        var objData = _APIService.GetOrders(para);
                        return CombineDatareturn(objData.Code, objData.Message,
                            objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
                    }
                }
            }
            return returData;
        }
        public HISReturnBase Get_ViTriLayMauPAP(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                if (paraInfoList.Count > 0)
                {
                    foreach (var item in paraInfoList)
                    {
                        var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ViTriLayMauPap, item);
                        var objData = _APIService.GetOrders(para);
                        return CombineDatareturn(objData.Code, objData.Message,
                            objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
                    }
                }
            }
            return returData;
        }
        public HISReturnBase Get_ViTriLayMauSinhThiet(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                if (paraInfoList.Count > 0)
                {
                    foreach (var item in paraInfoList)
                    {
                        var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ViTriLayMauSinhThiet, item);
                        var objData = _APIService.GetOrders(para);
                        return CombineDatareturn(objData.Code, objData.Message,
                            objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
                    }
                }
            }
            return returData;
        }
        public HISReturnBase GetPatientInformationDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP)
            {
                paraInfoList.NgayChiDinh = paraInfoList.NgayChiDinh.Value.Date;
                returData.Data = _hisDataAccess_MSSQLTrungGian.GetPatientInformationDetail(hisConnect, hisFunction, paraInfoList);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietBenhNhan, paraInfoList);
                var objData = _APIService.PatientInfomation(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
            {
                paraInfoList.NgayChiDinh = paraInfoList.NgayChiDinh.Value.Date;
                returData.Data = _hisDataAccess_MSSQLTrungGian.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfoList);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
            {
                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DownloadChiTietChiDinh(paraInfoList.SoPhieuChiDinh, hisConnect));
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);
                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                //var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem, paraInfoList);
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);
                var objData = _APIService.GetOrderByPatient(para);

                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);
                var objData = _APIService.GetOrderByPatient(para);

                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                //var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem, paraInfoList);
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                {
                    DataTable dataOrder = null;
                    foreach (dynamic item in objData.Data)
                    {
                        var dic = WorkingServices.ConvertDynamicToDictionary(item);
                        var datatemp = HL7v25.DataOrderFromHL7Message(dic["data"].ToString());
                        if (dataOrder == null)
                            dataOrder = datatemp;
                        else
                            dataOrder.Merge(datatemp);
                    }

                    return CombineDatareturn(objData.Code, objData.Message, dataOrder);
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                //var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem, paraInfoList);
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                //var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem, paraInfoList);
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                //var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem, paraInfoList);
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message??String.Empty, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message??String.Empty, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);

                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message ?? String.Empty, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message ?? String.Empty, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.ChiTietChiDinh, paraInfoList);

                var objData = _APIService.GetOrderByPatient(para);
                if (objData.Data != null)
                {
                    var jsonData = JsonConvert.SerializeObject(objData.Data);
                    List<ChiDinhXetNghiemVNPT> xetnghiems = JsonConvert.DeserializeObject<List<ChiDinhXetNghiemVNPT>>(jsonData);
                    var lstChiDinhGuiLIS = new List<ChiDinhXetNghiemVNPT_LIS>();

                    foreach (var sourceObject in xetnghiems)
                    {
                        var targetObject = new ChiDinhXetNghiemVNPT_LIS();
                        // Get the type of the target object
                        Type targetType = targetObject.GetType();
                        // Get the type of the source object
                        Type sourceType = sourceObject.GetType();
                        // Get all properties of the target object
                        PropertyInfo[] sourceProperties = sourceType.GetProperties();
                        // Loop through each property of the target object
                        foreach (PropertyInfo sourceProperty in sourceProperties)
                        {
                            if (sourceProperty.PropertyType == typeof(LoaiXetNghiemVNPT))
                            {
                                targetObject.maLoaiXetNghiem = sourceObject.loaiXetNghiem.maLoaiXetNghiem;
                                targetObject.tenLoai = sourceObject.loaiXetNghiem.tenLoai;
                            }
                            else if (sourceProperty.PropertyType == typeof(XetNghiemVNPT))
                            {
                                targetObject.maXetNghiem = sourceObject.xetNghiem.maXetNghiem;
                                targetObject.tenXetNghiem = sourceObject.xetNghiem.tenXetNghiem;
                            }
                            else
                            {
                                // Check if the source object has a property with the same name
                                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);
                                if (targetProperty != null)
                                {
                                    // Get the value of the source property
                                    object sourceValue = sourceProperty.GetValue(sourceObject, null);
                                    // Set the value of the target property
                                    targetProperty.SetValue(targetObject, sourceValue, null);
                                }
                            }
                        }
                        lstChiDinhGuiLIS.Add(targetObject);
                    }

                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(lstChiDinhGuiLIS, true, "-"));
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public HISReturnBase GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                returData.Data = _hisDataAccess_DHHospital.GetPatientOrderedList(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                returData.Data = _hisDataAccess_DaiHocCanTho.GetPatientOrderedList(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi 
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                returData.Data = _hisDataAccess_MSSQLTrungGian.GetPatientOrderedList(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
            {
                var para = new Models.Vft.DownloadOrderParams();
                if (paraInfoList.TimTuNgayChiDinh != null)
                    para.TuNgay = paraInfoList.TimTuNgayChiDinh.Value.ToString("yyyy-MM-dd");
                if (paraInfoList.TimDenNgayChiDinh != null)
                    para.DenNgay = paraInfoList.TimDenNgayChiDinh.Value.ToString("yyyy-MM-dd");
                if (paraInfoList.SoPhieuChiDinh != null)
                    para.SoPhieuYeuCau = paraInfoList.SoPhieuChiDinh;
                if (paraInfoList.HoTen != null)
                    para.HoTenBenhNhan = paraInfoList.HoTen;

                para.TrangThai = paraInfoList.TrangThai.Value;

                returData.Data = WorkingServices.ConvertToDataTable(_hisDataAccess_VPTFujitsu.DownloadChiDinh(para, hisConnect));
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable) WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                return CombineDatareturn(objData.Code, objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                {
                    DataTable dataOrder = null;
                    foreach (dynamic item in objData.Data)
                    {
                        var dic = WorkingServices.ConvertDynamicToDictionary(item);
                        var datatemp = HL7v25.DataOrderFromHL7Message(dic["data"].ToString());
                        if (dataOrder == null)
                            dataOrder = datatemp;
                        else
                            dataOrder.Merge(datatemp);
                    }
                 
                    return CombineDatareturn(objData.Code, objData.Message, dataOrder);
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);

                //if (objData.Data != null)
                //    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                //else
                //    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertDynamicToDataTable(objData.Data));
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var para = GetAPIRequestPara(hisConnect, hisFunction, objHisFunctionID.DanhSachCho, paraInfoList);
                var objData = _APIService.GetOrders(para);
                if (objData.Data != null)
                {
                    var jsonData = JsonConvert.SerializeObject(objData.Data);
                    List<BenhNhan> benhNhans = JsonConvert.DeserializeObject<List<BenhNhan>>(jsonData);
                    var lstBnLIS = new List<BenhNhanForLIS>();
             
                    foreach (var sourceObject in benhNhans)
                    {
                        var targetObject = new BenhNhanForLIS();
                        // Get the type of the target object
                        Type targetType = targetObject.GetType();
                        // Get the type of the source object
                        Type sourceType = sourceObject.GetType();
                        // Get all properties of the target object
                        PropertyInfo[] sourceProperties = sourceType.GetProperties();
                        // Loop through each property of the target object
                        foreach (PropertyInfo sourceProperty in sourceProperties)
                        {
                            if (sourceProperty.PropertyType == typeof(BacSiChiDinh))
                            {
                                targetObject.maNhanVien = sourceObject.bacSiChiDinh.maNhanVien;
                                targetObject.tenNhanVien = sourceObject.bacSiChiDinh.tenNhanVien;

                                targetObject.maChucDanh = sourceObject.bacSiChiDinh.chucDanh.maChucDanh;
                                targetObject.tenChucDanh = sourceObject.bacSiChiDinh.chucDanh.tenChucDanh;


                            }
                            else if (sourceProperty.PropertyType == typeof(PhongChiDinh))
                            {
                                targetObject.maPhongBenh = sourceObject.phongChiDinh.maPhongBenh;
                                targetObject.tenPhongbenh = sourceObject.phongChiDinh.tenPhongbenh;

                                targetObject.maPhongbanchidinh = sourceObject.phongChiDinh.phongBan.maPhongBan;
                                targetObject.tenPhongbanchidinh = sourceObject.phongChiDinh.phongBan.tenPhongBan;

                            }
                            else
                            {
                                // Check if the source object has a property with the same name
                                PropertyInfo targetProperty = targetType.GetProperty(sourceProperty.Name);

                                if (targetProperty != null)
                                {
                                    // Get the value of the source property
                                    object sourceValue = sourceProperty.GetValue(sourceObject, null);

                                    // Set the value of the target property
                                    targetProperty.SetValue(targetObject, sourceValue, null);
                                }
                            }
                        }
                        lstBnLIS.Add(targetObject);
                    }

                    return CombineDatareturn(objData.Code, objData.Message, WorkingServices.ConvertToDataTable(lstBnLIS, true, "-"));
                }
                else
                    return CombineDatareturn(objData.Code, objData.Message, null);
            }
            return returData;
        }
        public DataTable GetUploadKeyOfOrder(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList, ref List<string> SelectedColumns)
        {
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP)
                return _hisDataAccess_MSSQLTrungGian.GetUploadKeyOfOrder(hisConnect, hisFunction, paraInfoList, ref SelectedColumns);
            else
                return null;
        }
        public DataTable GetUploadKeyOfDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList, ref List<string> SelectedColumns)
        {
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP)
                return _hisDataAccess_MSSQLTrungGian.GetUploadKeyOfDetail(hisConnect, hisFunction, paraInfoList, ref SelectedColumns);
            else
                return null;
        }
        public int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList,
            ref List<string> lstNotFinishList)
        {
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_DHG)
                return _hisDataAccess_DHHospital.TransferResultToHIS(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DHCanTho)
                return _hisDataAccess_DaiHocCanTho.TransferResultToHIS(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.AHoi
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DBTG_HL7_FPT
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.FPT_SP
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.HangMinh
                || hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SHPT)
                return _hisDataAccess_MSSQLTrungGian.TransferResultToHIS(hisConnect, hisFunction, paraInfoList);
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VFT)
            {
                var para = new List<UploadOrderParams>();
                foreach (var item in paraInfoList)
                {
                    para.Add(new UploadOrderParams()
                    {
                        SoPhieuYeuCau = item.SoPhieuYeuCau,
                        IdDichVuChiDinh = item.IDDichVuHIS,
                        MaDichVu = item.MaDichVuHIS,
                        KetQua = item.KetQua,
                        BinhThuong = item.ChiSoBinhThuong,
                        BatThuong = item.BatThuong.ToString(),
                        KetLuan = item.KetLuan,
                        Username = item.MaNhanVienThucHien,
                        SoLanUpload = "1",
                        SoBarcode = item.MaSoXetNghiem
                    });
                }
                return _hisDataAccess_VPTFujitsu.UploadKetQuaChiDinh(para, hisConnect).Id;
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    var lstFinishKhoa = new List<HISResultValid>();

                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);

                            var obj = _APIService.UploadResult(new LisRequestParams
                            {
                                HisUrl = hisConnect.ServerName,
                                HisUser = hisConnect.UserName,
                                HisPassword = hisConnect.PassWord,
                                LisUrl = hisConnect.LISServerName,
                                LisUser = hisConnect.LISUserName,
                                LisPassword = hisConnect.LISPassword,
                                ClientName = hisConnect.ServerName,
                                APIName = APIName,
                                Param = pararequest,
                                WebMethod = webMethod
                            });

                            if (obj.Code != ApiMessageConstant.Success)
                            {
                                lstNotFinishList.Add(item.MaXetNghiemLIS);
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("Upload Fail:\n{0}", obj.Message));
                            }
                            else
                            {
                                if (!lstFinishKhoa.Contains(item.ThongTinXacNhanKhoa))
                                    lstFinishKhoa.Add(item.ThongTinXacNhanKhoa);
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                iCount++;
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);

                                var obj = _APIService.UploadResultNuoiCay(new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    Param = pararequest,
                                    WebMethod = webMethod
                                });

                                if (obj.Code != ApiMessageConstant.Success)
                                {
                                    lstNotFinishList.Add(item.MaXetNghiemLIS);
                                    LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload nuôi cấy Fail:\n{0}", obj.Message));
                                }
                                else
                                {
                                    if (!lstFinishKhoa.Contains(item.ThongTinXacNhanKhoa))
                                        lstFinishKhoa.Add(item.ThongTinXacNhanKhoa);
                                    LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload nuôi cấy finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                    iCount++;
                                }
                            }
                        }
                    }
                    if (lstFinishKhoa.Count > 0)
                    {
                        iCount += UploadValidResult(hisConnect, hisFunction, lstFinishKhoa);
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.DH_API)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();

                    //lstMaster.Add("username", hisConnect.UserName);
                    //lstMaster.Add("password", hisConnect.PassWord);

                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicThuongQuy);
                        else
                            lstMaster["Data"] = lstDicThuongQuy;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResult(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                        }
                        if (obj.Code != 1)
                        {
                            lstNotFinishList = paraInfoList.Select(x => x.MaXetNghiemLIS).ToList();
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicThuongQuy.Count();
                        }

                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicViSinh);
                        else
                            lstMaster["Data"] = lstDicViSinh;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    var lstFinishKhoa = new List<HISResultValid>();

                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);

                            var obj = _APIService.UploadResult(new LisRequestParams
                            {
                                HisUrl = hisConnect.ServerName,
                                HisUser = hisConnect.UserName,
                                HisPassword = hisConnect.PassWord,
                                LisUrl = hisConnect.LISServerName,
                                LisUser = hisConnect.LISUserName,
                                LisPassword = hisConnect.LISPassword,
                                ClientName = hisConnect.ServerName,
                                APIName = APIName,
                                Param = pararequest,
                                WebMethod = webMethod,
                                HisId = (int)hisConnect.HisID
                            });

                            if (obj.Code != ApiMessageConstant.Success)
                            {
                                lstNotFinishList.Add(item.MaXetNghiemLIS);
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("Upload Fail:\n{0}", obj.Message));
                            }
                            else
                            {
                                if (!lstFinishKhoa.Contains(item.ThongTinXacNhanKhoa))
                                    lstFinishKhoa.Add(item.ThongTinXacNhanKhoa);
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID.ToString()), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                iCount++;
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);

                                var obj = _APIService.UploadResultNuoiCay(new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    Param = pararequest,
                                    WebMethod = webMethod
                                });

                                if (obj.Code != ApiMessageConstant.Success)
                                {
                                    lstNotFinishList.Add(item.MaXetNghiemLIS);
                                    LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload nuôi cấy Fail:\n{0}", obj.Message));
                                }
                                else
                                {
                                    if (!lstFinishKhoa.Contains(item.ThongTinXacNhanKhoa))
                                        lstFinishKhoa.Add(item.ThongTinXacNhanKhoa);
                                    LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload nuôi cấy finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                    iCount++;
                                }
                            }
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                string APIName = string.Empty;
                var webMethod = string.Empty;
                var dataObj = new Dictionary<string, dynamic>();
                dataObj.Add("Data", JsonConvert.SerializeObject(paraInfoList));

                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem, ref APIName, ref webMethod, paraInfoList);
                //pararequest.Add("Data", new Dictionary<string, dynamic>(){"Data", paraInfoList });

                var obj = _APIService.UploadResult(new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = APIName,
                    Param = dataObj,
                    WebMethod = webMethod,
                    HisId = (int)hisConnect.HisID
                });

                return obj.Code > 0 ? -1 : 1;
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.SUN)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicThuongQuy);
                        else
                            lstMaster["Data"] = lstDicThuongQuy;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResult(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                        }
                        if (obj.Code != 1)
                        {
                            lstNotFinishList = paraInfoList.Select(x => x.MaXetNghiemLIS).ToList();
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicThuongQuy.Count();
                        }

                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicViSinh);
                        else
                            lstMaster["Data"] = lstDicViSinh;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ISofH)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lisPara = new LisRequestParams();
                    var lstUploadHl7ListThuongQuy = new List<HL7ResultUpload>();
                    var lstUploadHl7ListViSinh = new List<HL7ResultUpload>();

                    var lstSoPhieu = from p in paraInfoList
                                     group p by p.SoPhieuYeuCau into g
                                     select new { SoPhieuYeuCau = g.Key };
                    //Xử lý bỏ xn cha ra khỏi danh sách.
                    //Lấy danh sách xn cha.
                    var lsCha = paraInfoList.Where(x => !string.IsNullOrEmpty(x.MaDichVuChaHIS));
                    if (lsCha.Any())
                    {
                        var lstMaCha = from p in lsCha group p.MaDichVuChaHIS by p.MaDichVuChaHIS into g select new { MaDichVuChaHIS = g.Key };
                        paraInfoList = paraInfoList.Where(x => !(lstMaCha.Where(c => c.MaDichVuChaHIS.Equals(x.MaDichVuHIS)).Any())).ToList();

                    }
                    foreach (var itmSophieu in lstSoPhieu)
                    {
                        lstUploadHl7ListThuongQuy = new List<HL7ResultUpload>();
                        lstUploadHl7ListViSinh = new List<HL7ResultUpload>();
                        var parWithSophieu = paraInfoList.Where(x => x.SoPhieuYeuCau.Equals(itmSophieu.SoPhieuYeuCau)).ToList();
                        foreach (var item in parWithSophieu)
                        {
                            if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var uploadHL7 = ParseDataToHL7Result(hisConnect, hisFunction, ref APIName, ref webMethod, item);
                                lstUploadHl7ListThuongQuy.Add(uploadHL7);

                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                            else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                            {
                                foreach (var itemVs in item.lstKetQuaKhangSinh)
                                {
                                    string APIName = string.Empty;
                                    var webMethod = string.Empty;
                                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                        ref APIName, ref webMethod, item);
                                    var uploadHL7 = ParseDataToHL7Result(hisConnect, hisFunction, ref APIName, ref webMethod, item);
                                    lstUploadHl7ListViSinh.Add(uploadHL7);

                                    if (string.IsNullOrEmpty(lisPara.HisUrl))
                                    {
                                        lisPara = new LisRequestParams
                                        {
                                            HisUrl = hisConnect.ServerName,
                                            HisUser = hisConnect.UserName,
                                            HisPassword = hisConnect.PassWord,
                                            LisUrl = hisConnect.LISServerName,
                                            LisUser = hisConnect.LISUserName,
                                            LisPassword = hisConnect.LISPassword,
                                            ClientName = hisConnect.ServerName,
                                            APIName = APIName,
                                            WebMethod = webMethod,
                                            HisId = (int)hisConnect.HisID
                                        };
                                    }
                                }
                            }
                        }
                        if (lstUploadHl7ListThuongQuy.Count > 0)
                        {
                            var strData = HL7v25.DataResultToHL7(lstUploadHl7ListThuongQuy);
                            if (!lstMaster.Keys.Contains("data"))
                                lstMaster.Add("data", strData);
                            else
                                lstMaster["data"] = strData;
                            lisPara.Param = lstMaster;
                            GetToken(hisConnect, hisFunction, ref lisPara);
                            var obj = _APIService.UploadResult(lisPara);
                            //if (obj.Data != null)
                            //{
                            //    obj.Message = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                            //}
                            if (obj.Code != 0)
                            {
                                lstNotFinishList = parWithSophieu.Select(x => x.MaXetNghiemLIS).ToList();
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                            }
                            else
                            {
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                iCount += lstUploadHl7ListThuongQuy.Count();
                            }
                        }
                        if (lstUploadHl7ListViSinh.Count > 0)
                        {
                            var strData = HL7v25.DataResultToHL7(lstUploadHl7ListViSinh);
                            if (!lstMaster.Keys.Contains("Data"))
                                lstMaster.Add("Data", strData);
                            else
                                lstMaster["Data"] = strData;
                            lisPara.Param = lstMaster;
                            GetToken(hisConnect, hisFunction, ref lisPara);
                            var obj = _APIService.UploadResultNuoiCay(lisPara);
                            if (obj.Data != null)
                            {
                                obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                            }
                            if (obj.Code != 1)
                            {
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                            }
                            else
                            {
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                iCount += lstUploadHl7ListViSinh.Count();
                            }
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPSoft)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicThuongQuy);
                        else
                            lstMaster["Data"] = lstDicThuongQuy;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResult(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                        }
                        if (obj.Code != 1)
                        {
                            lstNotFinishList = paraInfoList.Select(x => x.MaXetNghiemLIS).ToList();
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicThuongQuy.Count();
                        }

                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicViSinh);
                        else
                            lstMaster["Data"] = lstDicViSinh;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Leopard)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicThuongQuy);
                        else
                            lstMaster["Data"] = lstDicThuongQuy;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResult(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                        }
                        if (obj.Code != 1)
                        {
                            lstNotFinishList = paraInfoList.Select(x => x.MaXetNghiemLIS).ToList();
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicThuongQuy.Count();
                        }

                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        if (!lstMaster.Keys.Contains("Data"))
                            lstMaster.Add("Data", lstDicViSinh);
                        else
                            lstMaster["Data"] = lstDicViSinh;

                        lisPara.Param = lstMaster;
                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ECOCLINIC)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        //if (!lstMaster.Keys.Contains("Data"))
                        //    lstMaster.Add("Data", lstDicThuongQuy);
                        //else
                        //    lstMaster["Data"] = lstDicThuongQuy;

                        lisPara.lstParam = lstDicThuongQuy;
                        var obj = _APIService.UploadResult(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                        }
                        if (obj.Code != 1 && obj.Code != 200)
                        {
                            lstNotFinishList = paraInfoList.Select(x => x.MaXetNghiemLIS).ToList();
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicThuongQuy.Count();
                        }
                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        //if (!lstMaster.Keys.Contains("Data"))
                        //    lstMaster.Add("Data", lstDicViSinh);
                        //else
                        //    lstMaster["Data"] = lstDicViSinh;
                        lisPara.lstParam = lstDicViSinh;

                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        //if (!lstMaster.Keys.Contains("Data"))
                        //    lstMaster.Add("Data", lstDicThuongQuy);
                        //else
                        //    lstMaster["Data"] = lstDicThuongQuy;

                        lisPara.lstParam = lstDicThuongQuy;
                        if (lisPara.APIName.Contains("{sophieuyeucau}"))
                        {
                            var itm = lstDicThuongQuy[0];
                            var dicFind = itm.Where(x => x.Key.Equals("sophieuyeucau", StringComparison.OrdinalIgnoreCase));
                            if (dicFind.Any())
                            {
                                lisPara.APIName = lisPara.APIName.Replace("{sophieuyeucau}", dicFind.First().Value);
                            }
                        }
                        var obj = _APIService.UploadResult(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());

                        }
                        if (obj.Code != 1 && obj.Code != 200)
                        {
                            lstNotFinishList = paraInfoList.Select(x => x.MaXetNghiemLIS).ToList();
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicThuongQuy.Count();
                        }
                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        //if (!lstMaster.Keys.Contains("Data"))
                        //    lstMaster.Add("Data", lstDicViSinh);
                        //else
                        //    lstMaster["Data"] = lstDicViSinh;
                        lisPara.lstParam = lstDicViSinh;

                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                var iCount = 0;
                if (paraInfoList.Count > 0)
                {
                    // var lstFinishKhoa = new List<HISResultValid>();
                    var lstMaster = new Dictionary<string, dynamic>();
                    var lstDicThuongQuy = new List<Dictionary<string, dynamic>>();
                    var lstDicViSinh = new List<Dictionary<string, dynamic>>();
                    var lisPara = new LisRequestParams();
                    foreach (var item in paraInfoList)
                    {

                        if (item.LoaiXetNghiem.Trim().Equals("ClsXetNghiem", StringComparison.OrdinalIgnoreCase))
                        {
                            string APIName = string.Empty;
                            var webMethod = string.Empty;
                            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaXetNghiem,
                                ref APIName, ref webMethod, item);
                            lstDicThuongQuy.Add(pararequest);
                            if (string.IsNullOrEmpty(lisPara.HisUrl))
                            {
                                lisPara = new LisRequestParams
                                {
                                    HisUrl = hisConnect.ServerName,
                                    HisUser = hisConnect.UserName,
                                    HisPassword = hisConnect.PassWord,
                                    LisUrl = hisConnect.LISServerName,
                                    LisUser = hisConnect.LISUserName,
                                    LisPassword = hisConnect.LISPassword,
                                    ClientName = hisConnect.ServerName,
                                    APIName = APIName,
                                    WebMethod = webMethod,
                                    HisId = (int)hisConnect.HisID
                                };
                            }
                        }
                        else if (item.LoaiXetNghiem.Trim().Equals("ClsXNViSinh", StringComparison.OrdinalIgnoreCase))
                        {
                            foreach (var itemVs in item.lstKetQuaKhangSinh)
                            {
                                string APIName = string.Empty;
                                var webMethod = string.Empty;
                                var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.TraKetQuaViSinh,
                                    ref APIName, ref webMethod, item);
                                lstDicViSinh.Add(pararequest);
                                if (string.IsNullOrEmpty(lisPara.HisUrl))
                                {
                                    lisPara = new LisRequestParams
                                    {
                                        HisUrl = hisConnect.ServerName,
                                        HisUser = hisConnect.UserName,
                                        HisPassword = hisConnect.PassWord,
                                        LisUrl = hisConnect.LISServerName,
                                        LisUser = hisConnect.LISUserName,
                                        LisPassword = hisConnect.LISPassword,
                                        ClientName = hisConnect.ServerName,
                                        APIName = APIName,
                                        WebMethod = webMethod,
                                        HisId = (int)hisConnect.HisID
                                    };
                                }
                            }
                        }
                    }
                    if (lstDicThuongQuy.Count > 0)
                    {
                        List<string> listDVTT = new List<string>();
                        var stringIndex = "dvtt:{0}_soPhieuXetNghiem:{1}_soVaoVien:{2}_soVaoVienDt:{3}";
                        foreach (var item in lstDicThuongQuy)
                        {
                            var id = string.Format(stringIndex, item["dvtt"].ToString(), item["soPhieuXetNghiem"].ToString(),
                                item["soVaoVien"].ToString(), item["soVaoVienDt"].ToString());
                            if (!listDVTT.Where(x => x.Equals(id)).Any())
                            {
                                listDVTT.Add(id);
                            }
                        }
                        foreach (var itmdvtt in listDVTT)
                        {
                            string dvtt, soPhieuXetNghiem, soVaoVien, soVaoVienDt;

                            var lstByDVTT = lstDicThuongQuy.Where(x => string.Format(stringIndex, x["dvtt"].ToString(), x["soPhieuXetNghiem"].ToString(),
                                x["soVaoVien"].ToString(), x["soVaoVienDt"].ToString()).Equals(itmdvtt)).ToList();
                            dvtt = lstByDVTT.First()["dvtt"].ToString();
                            soPhieuXetNghiem = lstByDVTT.First()["soPhieuXetNghiem"].ToString();
                            soVaoVien = lstByDVTT.First()["soVaoVien"].ToString();
                            soVaoVienDt = lstByDVTT.First()["soVaoVienDt"].ToString();
                            foreach (var itmUpl in lstByDVTT)
                            {
                                itmUpl.Remove("dvtt");
                                itmUpl.Remove("soPhieuXetNghiem");
                                itmUpl.Remove("soVaoVien");
                                itmUpl.Remove("soVaoVienDt");
                            }
                            lisPara.Param = new Dictionary<string, dynamic>
                            {
                             {"dvtt", dvtt },
                             {"ketQuaCmds", lstByDVTT },
                             {"soPhieuXetNghiem", soPhieuXetNghiem},
                             {"soVaoVien", int.Parse(string.IsNullOrEmpty(soVaoVien)?"0":soVaoVien ) },
                             {"soVaoVienDt" , int.Parse(string.IsNullOrEmpty(soVaoVienDt)?"0":soVaoVienDt ) }
                            };
                            var obj = _APIService.UploadResult(lisPara);
                            if (obj.Data != null)
                            {
                                obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                            }
                            if (obj.Code != 1 && obj.Code != 200)
                            {
                                lstNotFinishList.AddRange(paraInfoList.Select(x => x.MaXetNghiemLIS).ToList());
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                            }
                            else
                            {
                                LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                                iCount += lstDicThuongQuy.Count();
                            }
                        }
                    }
                    if (lstDicViSinh.Count > 0)
                    {
                        //if (!lstMaster.Keys.Contains("Data"))
                        //    lstMaster.Add("Data", lstDicViSinh);
                        //else
                        //    lstMaster["Data"] = lstDicViSinh;
                        lisPara.lstParam = lstDicViSinh;

                        var obj = _APIService.UploadResultNuoiCay(lisPara);
                        if (obj.Data != null)
                        {
                            obj = JsonConvert.DeserializeObject<ResultResponse>(obj.Data[0].ToString());
                        }
                        if (obj.Code != 1)
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh Fail - Code {0}:\n{1}", obj.Code, obj.Message));
                        }
                        else
                        {
                            LogService.RecordLogFile(string.Format("UploadFinishStatus_{0}_", hisConnect.HisID), string.Format("Upload_ViSinh finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                            iCount += lstDicViSinh.Count();
                        }
                    }
                    return iCount;
                }
            }
            return -1;
        }
        public int UploadFileToHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList)
        {
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.ERecord_API)
            {
                int iCount = 0;
                foreach (var item in paraInfoList)
                {
                    string APIName = string.Empty;
                    var webMethod = string.Empty;
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.PhieuTraKetQuaXetNghiem,
                        ref APIName, ref webMethod, item);

                    var para = new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = pararequest,
                        WebMethod = webMethod,
                        HisId = (int)hisConnect.HisID
                    };

                    var objData = _APIService.UploadResult(para);

                    if (objData.Data != null)
                        iCount++;

                }
                return iCount;
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PTT_API)
            {
                int iCount = 0;
                foreach (var item in paraInfoList)
                {
                    string APIName = string.Empty;
                    var webMethod = string.Empty;
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.PhieuTraKetQuaXetNghiem,
                        ref APIName, ref webMethod, item);

                    var para = new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = pararequest,
                        WebMethod = webMethod,
                        HisId = (int)hisConnect.HisID
                    };

                    var objData = _APIService.UploadResult(para);

                    if (objData.Data != null)
                        iCount++;

                }
                return iCount;
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.PKTDK_IT)
            {
                int iCount = 0;
                foreach (var item in paraInfoList)
                {
                    string APIName = string.Empty;
                    var webMethod = string.Empty;
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.PhieuTraKetQuaXetNghiem,
                        ref APIName, ref webMethod, item);

                    var para = new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = pararequest,
                        WebMethod = webMethod,
                        HisId = (int)hisConnect.HisID
                    };

                    var objData = _APIService.UploadResult(para);

                    if (objData.Data != null)
                        iCount++;

                }
                return iCount;
            }
            else if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.VNPTMN)
            {
                int iCount = 0;
                foreach (var item in paraInfoList)
                {
                    string APIName = string.Empty;
                    var webMethod = string.Empty;
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.PhieuTraKetQuaXetNghiem,
                        ref APIName, ref webMethod, item);

                    var para = new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = pararequest,
                        WebMethod = webMethod,
                        HisId = (int)hisConnect.HisID
                    };

                    var objData = _APIService.UploadResult(para);

                    if (objData.Data != null)
                        iCount++;

                }
                return iCount;
            }
            return -1;
        }
        public int UploadValidResult(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HISResultValid> paraInfoList)
        {
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                int iCount = 0;
                foreach (var item in paraInfoList)
                {
                    string APIName = string.Empty;
                    var webMethod = string.Empty;
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.BatTraKetQuaXetNghiemDu,
                        ref APIName, ref webMethod, item);

                    var para  =  new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = pararequest,
                        WebMethod = webMethod
                    };

                    var objData = _APIService.UpdateFinishOrderStatus(para);

                    if (objData.Data != null)
                        iCount++;

                }
                return iCount;
            }
            return -1;
        }
        public HISReturnBase GetBarcodeFromHis(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfoList)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;
            if (hisConnect.HisID != Data.HIS.HISDataCommon.HisProvider.Vimes) return returData;
            var APIName = string.Empty;
            var webMethod = string.Empty;
            var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.BatTraKetQuaXetNghiemDu,
                ref APIName, ref webMethod, paraInfoList);

            var barcode = _APIService.GetBarcode(
                new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = APIName,
                    Param = pararequest,
                    WebMethod = webMethod
                });
            return CombineDatareturn(barcode.Code, barcode.Message,
                barcode.Data != null
                    ? (DataTable) WorkingServices.ConvertToDataTable(barcode.Data)
                    : null);
        }
        //For LabBlood
        public int InsertOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {

            var iCount = 0;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var lstPara = new List<Dictionary<string, dynamic>>();
                string APIName = string.Empty;
                var webMethod = string.Empty;
                foreach (var item in paraInfoList)
                {
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.ThemChePhamTruyenMau, ref APIName, ref webMethod, item);
                    lstPara.Add(pararequest);
                }
                if (lstPara.Count > 0)
                {
                    var obj = _APIService.UploadResult(new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = new Dictionary<string, dynamic>() { { "Data", lstPara } }
                    }, 0, "InsertBloodElement");

                    if (obj.Code != ApiMessageConstant.Success)
                    {
                        LogService.RecordLogFile(string.Format("InsertBloodElement_{0}", hisConnect.HisID.ToString()), string.Format("InsertBloodElement Fail:\n{0}", obj.Message));
                    }
                    else
                    {
                        LogService.RecordLogFile(string.Format("InsertBloodElement_{0}", hisConnect.HisID.ToString()), string.Format("InsertBloodElement finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                        iCount++;
                    }
                }
            }
            return iCount;
        }
        public int DeleteOrderedBloodElement(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            var iCount = 0;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var lstPara = new List<Dictionary<string, dynamic>>();
                string APIName = string.Empty;
                var webMethod = string.Empty;
                foreach (var item in paraInfoList)
                {
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.XoaChePhamTruyenMau, ref APIName, ref webMethod, item);
                    lstPara.Add(pararequest);
                }
                if (lstPara.Count > 0)
                {
                    var obj = _APIService.UploadResult(new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = new Dictionary<string, dynamic>() { { "Data", lstPara } }
                    }, 0, "DeleteBloodElement");

                    if (obj.Code != ApiMessageConstant.Success)
                    {
                        LogService.RecordLogFile(string.Format("DeleteBloodElement_{0}", hisConnect.HisID.ToString()), string.Format("DeleteBloodElement Fail:\n{0}", obj.Message));
                    }
                    else
                    {
                        LogService.RecordLogFile(string.Format("DeleteBloodElement_{0}", hisConnect.HisID.ToString()), string.Format("DeleteBloodElement finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                        iCount++;
                    }
                }
            }
            return iCount;
        }
        public int ResetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {

            var iCount = 0;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var lstPara = new List<Dictionary<string, dynamic>>();
                string APIName = string.Empty;
                var webMethod = string.Empty;
                foreach (var item in paraInfoList)
                {
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.HuyBarcodeTruyenMau, ref APIName, ref webMethod, item);
                    lstPara.Add(pararequest);
                }
                if (lstPara.Count > 0)
                {
                    var obj = _APIService.UploadResult(new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = new Dictionary<string, dynamic>() { { "Data", lstPara } }
                    }, 0, "ResetBarcodeLabBlood");

                    if (obj.Code != ApiMessageConstant.Success)
                    {
                        LogService.RecordLogFile(string.Format("ResetBarcodeLabBlood_{0}", hisConnect.HisID.ToString()), string.Format("ResetBarcodeLabBlood Fail:\n{0}", obj.Message));
                    }
                    else
                    {
                        LogService.RecordLogFile(string.Format("ResetBarcodeLabBlood_{0}", hisConnect.HisID.ToString()), string.Format("ResetBarcodeLabBlood finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                        iCount++;
                    }
                }
            }
            return iCount;
        }
        public int ReGetBarcodeLabBlood(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {

            var iCount = 0;
            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.Vimes)
            {
                var lstPara = new List<Dictionary<string, dynamic>>();
                string APIName = string.Empty;
                var webMethod = string.Empty;
                foreach (var item in paraInfoList)
                {
                    var pararequest = ParseApiObjectToDictionary(hisConnect, hisFunction, objHisFunctionID.CapNhatCodeCu, ref APIName, ref webMethod, item);
                    lstPara.Add(pararequest);
                }
                if (lstPara.Count > 0)
                {
                    var obj = _APIService.UploadResult(new LisRequestParams
                    {
                        HisUrl = hisConnect.ServerName,
                        HisUser = hisConnect.UserName,
                        HisPassword = hisConnect.PassWord,
                        LisUrl = hisConnect.LISServerName,
                        LisUser = hisConnect.LISUserName,
                        LisPassword = hisConnect.LISPassword,
                        ClientName = hisConnect.ServerName,
                        APIName = APIName,
                        Param = new Dictionary<string, dynamic>() { { "Data", lstPara } }
                    }, 0, "ReGetBarcodeLabBlood");

                    if (obj.Code != ApiMessageConstant.Success)
                    {
                        LogService.RecordLogFile(string.Format("ReGetBarcodeLabBlood_{0}", hisConnect.HisID.ToString()), string.Format("ReGetBarcodeLabBlood Fail:\n{0}", obj.Message));
                    }
                    else
                    {
                        LogService.RecordLogFile(string.Format("ReGetBarcodeLabBlood_{0}", hisConnect.HisID.ToString()), string.Format("ReGetBarcodeLabBlood finish with message:\n Status: {0} - Message: {1}", obj.Code, obj.Message));
                        iCount++;
                    }
                }
            }
            return iCount;
        }
        public HISReturnBase DanhSachGuiMauDi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            var returData = new HISReturnBase();
            returData.Code = 0;
            returData.Message = string.Empty;

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                //var para = GetAPIRequestPara(hisConnect, hisFunction, "GetPartners");
                var para = new LisRequestParams
                {
                    ClientName = "",
                    APIName = "GetPartners",
                    HisId = (int)hisConnect.HisID,
                    WebMethod = "Get",
                    Param = new Dictionary<string, dynamic>() { }
                };

                var objData = _APIService.GetListOfPartner(para);

                return CombineDatareturn(objData.Code,
                    objData.Message,
                    objData.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(objData.Data) : null);
            }

            return returData;
        }
        public HISReturnBase ThemTiepNhanVaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            var returData = new HISReturnBase { Code = 0, Message = string.Empty };

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                var dataObj = new Dictionary<string, dynamic> { { "Data", JsonConvert.SerializeObject(tiepNhan) } };


                var obj = _APIService.AddReception(new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = "AddReception",
                    Param = dataObj,
                    WebMethod = "POST",
                    HisId = (int)hisConnect.HisID
                });

                return CombineDatareturn(obj.Code, obj.Message, null);
            }

            return returData;
        }
        public HISReturnBase LayKetQua(HisConnection hisConnect, Dictionary<string, object> paraInfoList)
        {
            var returData = new HISReturnBase { Code = 0, Message = string.Empty };

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                //var dataObj = new Dictionary<string, dynamic> { { "Data", JsonConvert.SerializeObject(tiepNhan) } };


                var obj = _APIService.GetResult(new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = "GetSampleResult",
                    Param = paraInfoList,
                    WebMethod = "GET",
                    HisId = (int)hisConnect.HisID
                });

                return CombineDatareturn(obj.Code, obj.Message, obj.Data != null ? (DataTable)WorkingServices.ConvertDynamicToDataTable(obj.Data) : null);
            }

            return returData;
        }

        public HISReturnBase ThemChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            var returData = new HISReturnBase { Code = 0, Message = string.Empty };

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                var obj = _APIService.AddAssignation(new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = "AddAssignationTest",
                    Param = tiepNhan,
                    WebMethod = "POST",
                    HisId = (int)hisConnect.HisID
                });

                return CombineDatareturn(obj.Code, obj.Message, null);
            }
            return returData;
        }

        public HISReturnBase XoaChiDinh(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            var returData = new HISReturnBase { Code = 0, Message = string.Empty };

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                //var dataObj = new Dictionary<string, dynamic> { { "Data", JsonConvert.SerializeObject(tiepNhan) } };
                var obj = _APIService.DeleteAssgnation(new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = "DeleteAssignationTest",
                    Param = tiepNhan,
                    WebMethod = "POST",
                    HisId = (int)hisConnect.HisID
                });

                return CombineDatareturn(obj.Code, obj.Message, null);
            }
            return returData;
        }

        public HISReturnBase UploadFileKetQua(HisConnection hisConnect, Dictionary<string, object> tiepNhan)
        {
            var returData = new HISReturnBase { Code = 0, Message = string.Empty };

            if (hisConnect.HisID == Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)
            {
                //var dataObj = new Dictionary<string, dynamic> { { "Data", JsonConvert.SerializeObject(tiepNhan) } };
                var obj = _APIService.UploadResultFile(new LisRequestParams
                {
                    HisUrl = hisConnect.ServerName,
                    HisUser = hisConnect.UserName,
                    HisPassword = hisConnect.PassWord,
                    LisUrl = hisConnect.LISServerName,
                    LisUser = hisConnect.LISUserName,
                    LisPassword = hisConnect.LISPassword,
                    ClientName = hisConnect.ServerName,
                    APIName = "AddResultFile",
                    Param = tiepNhan,
                    WebMethod = "POST",
                    HisId = (int)hisConnect.HisID
                });

                return CombineDatareturn(obj.Code, obj.Message, null);
            }
            return returData;
        }
        #region HL7
        
        #endregion
    }
}