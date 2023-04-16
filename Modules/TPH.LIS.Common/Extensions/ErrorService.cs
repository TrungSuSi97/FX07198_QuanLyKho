using System;
using System.Data.Odbc;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using TPH.LIS.Common.Controls;
using TPH.WriteLog;

namespace TPH.LIS.Common.Extensions
{
    public class ErrorService
    {
        private static bool ShowingNetworkError = false;

        public static string GetSqlErrorMessage(OdbcException exception, string sqlQuery, string userId, bool showMess = true)
        {
            var errorMessage = string.Empty;
            var errorCode = string.Empty;
            var totalErrors = exception.Errors.Count;

            for (int i = 0; i < totalErrors; i++)
            {
                errorCode += errorCode.Length > 0
                    ? string.Format(", {0}", exception.Errors[i].NativeError)
                    : exception.Errors[i].NativeError.ToString();
                var errorDetail = GetErrorMessage(exception.Errors[i].NativeError);

                if (!string.IsNullOrWhiteSpace(errorDetail))
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage += string.Format(
                            "{0}{1} - {2}",
                            Environment.NewLine,
                            errorDetail,
                            exception.Errors[i].Message);
                    }
                    else
                    {
                        errorMessage += string.Format("{0} - {1}", errorDetail, exception.Errors[i].Message);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage += string.Format(
                            "{0} - {1}",
                            Environment.NewLine,
                            exception.Errors[i].Message);
                    }
                    else
                    {
                        errorMessage += string.Format(" - {0}", HandleMessage(exception.Errors[i].Message));
                    }
                }
            }

            errorMessage = errorMessage.
                Replace("[Microsoft][ODBC SQL Server Driver]", string.Empty).
                Replace("[SQL Server]", string.Empty).
                Replace("[DBNETLIB]", string.Empty);


            LogService.RecordLogError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " +
                                     userId + " , Error Code: " + errorCode + Environment.NewLine +
                                     errorMessage.ToUpper() +
                                     (sqlQuery != ""
                                         ? Environment.NewLine + "SQL_ERROR: " + Environment.NewLine + sqlQuery
                                         : "") +
                                     Environment.NewLine + "DETAIL: " + Environment.NewLine + exception.ToString());
            if (Check_NetworkError_AllowShow(errorMessage) && showMess)
            {
                FrmMessageBox frm = new FrmMessageBox();
                frm.MsgContent = errorMessage;
                frm.ErrorDetail = "Error Code: " + errorCode + Environment.NewLine + exception.ToString();
                frm.IsErrorWithDetailMode = true;
                frm.ShowDialog();
                ShowingNetworkError = false;
            }
            return errorMessage;
        }

        public static bool GetSQLErrorMessage(SqlException exception, string sqlQuery, string userId, bool showMess = true)
        {
            var errorMessage = string.Empty;
            var errorCode = string.Empty;
            var totalErrors = exception.Errors.Count;

            for (int i = 0; i < totalErrors; i++)
            {
                errorCode += errorCode.Length > 0
                    ? string.Format(", {0}", exception.Errors[i].Number)
                    : exception.Errors[i].Number.ToString();
                var errorDetail = GetErrorMessage(exception.Errors[i].Number);

                if (!string.IsNullOrWhiteSpace(errorDetail))
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage += string.Format(
                            "{0}{1} - {2}",
                            Environment.NewLine,
                            errorDetail,
                            exception.Errors[i].Message);
                    }
                    else
                    {
                        errorMessage += string.Format("{0} - {1}", errorDetail, exception.Errors[i].Message);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage += string.Format(
                            "{0} - {1}",
                            Environment.NewLine,
                            exception.Errors[i].Message);
                    }
                    else
                    {
                        errorMessage += string.Format(" - {0}", HandleMessage(exception.Errors[i].Message));
                    }
                }
            }

            errorMessage = errorMessage.
                Replace("[Microsoft][ODBC SQL Server Driver]", string.Empty).
                Replace("[SQL Server]", string.Empty).
                Replace("[DBNETLIB]", string.Empty);


            LogService.RecordLogError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " +
                                     userId + " , Error Code: " + errorCode + Environment.NewLine +
                                     errorMessage.ToUpper() +
                                     (sqlQuery != ""
                                         ? Environment.NewLine + "SQL_ERROR: " + Environment.NewLine + sqlQuery
                                         : "") +
                                     Environment.NewLine + "DETAIL: " + Environment.NewLine + exception.ToString());
            if (Check_NetworkError_AllowShow(errorMessage) && showMess)
            {
                FrmMessageBox frm = new FrmMessageBox();
                frm.MsgTitle = MessageConstant.MessageBoxTitleError;
                frm.MsgContent = errorMessage;
                frm.ErrorDetail = "Error Code: " + errorCode + Environment.NewLine + exception.ToString();
                frm.IsErrorWithDetailMode = true;
                frm.ShowDialog();
                ShowingNetworkError = false;
            }
            return false;
        }

        public static string GetOdbchisErrorMessage(OdbcException exception, string sqlQuery, bool isTestConnect, string userid)
        {
            var errorMessage = string.Empty;
            var errorCode = string.Empty;
            var totalErrors = exception.Errors.Count;

            for (int i = 0; i < totalErrors; i++)
            {
                errorCode += errorCode.Length > 0
                    ? string.Format(", {0}", exception.Errors[i].NativeError)
                    : exception.Errors[i].NativeError.ToString();
                var errorDetail = GetErrorMessage(exception.Errors[i].NativeError);

                if (!string.IsNullOrWhiteSpace(errorDetail))
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage += string.Format(
                            "{0}{1} - {2}",
                            Environment.NewLine,
                            errorDetail,
                            exception.Errors[i].Message);
                    }
                    else
                    {
                        errorMessage += string.Format("{0} - {1}", errorDetail, exception.Errors[i].Message);
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(errorMessage))
                    {
                        errorMessage += string.Format(
                                "{0} - {1}",
                                Environment.NewLine,
                                exception.Errors[i].Message);
                    }
                    else
                    {
                        errorMessage += string.Format(" - {0}", HandleMessage(exception.Errors[i].Message));
                    }
                }
            }
            if (Check_NetworkError_AllowShow(errorMessage))
            {
                FrmMessageBox frm = new FrmMessageBox();
                errorMessage = errorMessage.
                    Replace("[Microsoft][ODBC SQL Server Driver]", string.Empty).
                    Replace("[SQL Server]", string.Empty).
                    Replace("[DBNETLIB]", string.Empty);
                if (isTestConnect && Strings.InStr(errorCode, "17", CompareMethod.Text) > 0)
                {
                    errorMessage = "Không kết nối được máy chủ LIS";
                }
                errorMessage = "LỖI KẾT NỐI LIS " + Environment.NewLine + errorMessage;

                frm.MsgTitle = MessageConstant.MessageBoxTitleError;
                frm.MsgContent = errorMessage;
                frm.ErrorDetail = "Error Code: " + errorCode + Environment.NewLine + exception.ToString();
                frm.ShowDialog();
                ShowingNetworkError = false;
            }
                LogService.RecordLogError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " + userid +
                                            " , Error Code: " + errorCode + Environment.NewLine + errorMessage.ToUpper() +
                                            (sqlQuery != ""
                                                ? Environment.NewLine + "SQL_ERROR: " + Environment.NewLine + sqlQuery
                                                : "") + Environment.NewLine + "DETAIL: " + Environment.NewLine +
                                            exception.ToString());
            
            return errorMessage;
        }
        
        /// <summary>
        /// Hàm hiển thị thông báo lỗi trong quá trình thao tác trên form 
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="methodCall">Tên của hàm đang gọi</param>
        public static string GetFrameworkErrorMessage(Exception exception, string methodCall)
        {
            var errorMessage = HandleMessage(exception.Message);

            return errorMessage;
        }

        public static string GetFrameworkErrorMessage(Exception ex, string methodCall, bool isShow, string userid)
        {
            var errorMessage = HandleMessage(ex.Message);
            var errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();



            LogService.RecordLogError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +
                                     ",User: " + userid + " , Error Code: " + errorCode.ToString() +
                                     Environment.NewLine + errorMessage.ToUpper() +
                                     Environment.NewLine + "METHOD CALL: " + methodCall +
                                     Environment.NewLine + "DETAIL: " +
                                     Environment.NewLine + ex.ToString());
            if (isShow)
            {
                FrmMessageBox frm = new FrmMessageBox();
                frm.MsgTitle = MessageConstant.MessageBoxTitleError;
                frm.MsgContent = errorMessage;
                frm.ErrorDetail = Environment.NewLine + "METHOD CALL: " + methodCall +
                                Environment.NewLine + ex.ToString();
                frm.IsErrorWithDetailMode = true;
                frm.ShowDialog();
            }
            return errorMessage;
        }
        public static bool GetFrameworkErrorMessage(Exception ex, string methodCall, string userid)
        {
            var errorMessage = HandleMessage(ex.Message);
            var errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();



            LogService.RecordLogError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") +
                                     ",User: " + userid + " , Error Code: " + errorCode.ToString() +
                                     Environment.NewLine + errorMessage.ToUpper() +
                                     Environment.NewLine + "METHOD CALL: " + methodCall +
                                     Environment.NewLine + "DETAIL: " +
                                     Environment.NewLine + ex.ToString());
            FrmMessageBox frm = new FrmMessageBox();
            frm.MsgTitle = MessageConstant.MessageBoxTitleError;
            frm.MsgContent = errorMessage;
            frm.ErrorDetail = Environment.NewLine + "METHOD CALL: " + methodCall +
                            Environment.NewLine + ex.ToString();
            frm.IsErrorWithDetailMode = true;
            frm.ShowDialog();
            return false;
        }
        private static string HandleMessage(string errorMessage)
        {
            errorMessage = errorMessage.Replace("[Microsoft][ODBC SQL Server Driver]", string.Empty);
            errorMessage = errorMessage.Replace("System.InvalidOperationException:", string.Empty);
            errorMessage = errorMessage.Replace("[SQL Server]", string.Empty);
            errorMessage = errorMessage.Replace("[DBNETLIB]", string.Empty);
            errorMessage = errorMessage.Replace("on the DataSource.\r\nParameter name: dataMember", string.Empty);
            errorMessage = errorMessage.Replace("Cannot bind to the property or column", "Không thể gán thuộc tính hoặc giá trị cho cột");
            errorMessage = errorMessage.Replace("The connection's current state is closed", "Kết nối hiện tại đã bị đóng");
            errorMessage = errorMessage.Replace("The connection has been disabled.", "Lỗi kết nối mạng.\nVui lòng kiểm tra mạng LAN");
            errorMessage = errorMessage.Replace("Object reference not set to an instance of an object", "Đối tượng cần tham chiếu chưa khởi tạo hoặc đang null");
            errorMessage = errorMessage.Replace("Index and length must refer to a location within the string", "Vị trí bắt đầu và độ dài chuỗi cần lấy vuợt độ dài");
            errorMessage = errorMessage.Replace("Cannot access a disposed object.", "Không thể truy cập đối tượng đã đóng.");
            errorMessage = errorMessage.Replace("Object name:", "Đối tượng:");
            errorMessage = errorMessage.Replace("There is no row at position ", "Không có dòng nào tại vị trí ");
            errorMessage = errorMessage.Replace("The device is not ready.", "Đường dẫn lưu trữ không thể truy xuất.");
            errorMessage = errorMessage.Replace("The RPC server is unavailable", "Không lấy được danh sách máy in !\nService: \"Print Spooler\" chưa chạy.");

            if (Strings.InStr(1, errorMessage, "System.Runtime.InteropServices.COMException", CompareMethod.Text) > 0)
            {
                errorMessage = "Lỗi .NET FrameWork! \nGặp lỗi này bạn nên tắt và mở lại ứng dụng!";
            }

            return errorMessage;
        }

        private static string GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case ErrorConstant.ErrorCode0:
                    return ErrorConstant.ErrorMessage0;
                case ErrorConstant.ErrorCode156:
                    return ErrorConstant.ErrorMessage156;
                case ErrorConstant.ErrorCode102:
                    return ErrorConstant.ErrorMessage102;
                case ErrorConstant.ErrorCode208:
                    return ErrorConstant.ErrorMessage208;
                case ErrorConstant.ErrorCode205:
                    return ErrorConstant.ErrorMessage205;
                case ErrorConstant.ErrorCode17:
                    return ErrorConstant.ErrorMessage17;
                case ErrorConstant.ErrorCode53:
                    return ErrorConstant.ErrorMessage53;
                case ErrorConstant.ErrorCode207:
                    return ErrorConstant.ErrorMessage207;
                case ErrorConstant.ErrorCode2627:
                    return ErrorConstant.ErrorMessage2627;
                case ErrorConstant.ErrorCode535:
                    return ErrorConstant.ErrorMessage535;
                case ErrorConstant.ErrorCode534:
                    return ErrorConstant.ErrorMessage534;
                case ErrorConstant.ErrorCode18456:
                    return ErrorConstant.ErrorMessage18456;
                case ErrorConstant.ErrorCode533:
                    return ErrorConstant.ErrorMessage533;
                case ErrorConstant.ErrorCode532:
                    return ErrorConstant.ErrorMessage532;
                case ErrorConstant.ErrorCode531:
                    return ErrorConstant.ErrorMessage531;
                case ErrorConstant.ErrorCode530:
                    return ErrorConstant.ErrorMessage530;
                case ErrorConstant.ErrorCode529:
                    return ErrorConstant.ErrorMessage529;
                case ErrorConstant.ErrorCode528:
                    return ErrorConstant.ErrorMessage528;
                case ErrorConstant.ErrorCode527:
                    return ErrorConstant.ErrorMessage527;
                case ErrorConstant.ErrorCode526:
                    return ErrorConstant.ErrorMessage526;
                case ErrorConstant.ErrorCode525:
                    return ErrorConstant.ErrorMessage525;
                case ErrorConstant.ErrorCode524:
                    return ErrorConstant.ErrorMessage524;
                case ErrorConstant.ErrorCode523:
                    return ErrorConstant.ErrorMessage523;
                case ErrorConstant.ErrorCode522:
                    return ErrorConstant.ErrorMessage522;
                case ErrorConstant.ErrorCode521:
                    return ErrorConstant.ErrorMessage521;
                case ErrorConstant.ErrorCode520:
                    return ErrorConstant.ErrorMessage520;
                case ErrorConstant.ErrorCode519:
                    return ErrorConstant.ErrorMessage519;
                case ErrorConstant.ErrorCode518:
                    return ErrorConstant.ErrorMessage518;
                case ErrorConstant.ErrorCode517:
                    return ErrorConstant.ErrorMessage517;
                case ErrorConstant.ErrorCode516:
                    return ErrorConstant.ErrorMessage516;
                case ErrorConstant.ErrorCode515:
                    return ErrorConstant.ErrorMessage515;
                case ErrorConstant.ErrorCode514:
                    return ErrorConstant.ErrorMessage514;
                case ErrorConstant.ErrorCode513:
                    return ErrorConstant.ErrorMessage513;
                case ErrorConstant.ErrorCode512:
                    return ErrorConstant.ErrorMessage512;
                case ErrorConstant.ErrorCode511:
                    return ErrorConstant.ErrorMessage511;
                case ErrorConstant.ErrorCode510:
                    return ErrorConstant.ErrorMessage510;
                case ErrorConstant.ErrorCode509:
                    return ErrorConstant.ErrorMessage509;
                case ErrorConstant.ErrorCode508:
                    return ErrorConstant.ErrorMessage508;
                case ErrorConstant.ErrorCode507:
                    return ErrorConstant.ErrorMessage507;
                case ErrorConstant.ErrorCode506:
                    return ErrorConstant.ErrorMessage506;
                case ErrorConstant.ErrorCode505:
                    return ErrorConstant.ErrorMessage505;
                case ErrorConstant.ErrorCode504:
                    return ErrorConstant.ErrorMessage504;
                case ErrorConstant.ErrorCode503:
                    return ErrorConstant.ErrorMessage503;
                case ErrorConstant.ErrorCode502:
                    return ErrorConstant.ErrorMessage502;
                case ErrorConstant.ErrorCode501:
                    return ErrorConstant.ErrorMessage501;
                case ErrorConstant.ErrorCode500:
                    return ErrorConstant.ErrorMessage500;
                case ErrorConstant.ErrorCode120:
                    return ErrorConstant.ErrorMessage120;
                case ErrorConstant.ErrorCode2812:
                    return ErrorConstant.ErrorMessage2812;
                case ErrorConstant.ErrorCode3621:
                    return ErrorConstant.ErrorMessage3621;
                case ErrorConstant.ErrorCode248:
                    return ErrorConstant.ErrorMessage248;
                //orther
                default:
                    return ErrorConstant.ErrorMessage9999;
            }
        }
        private static bool Check_NetworkError_AllowShow(string mess)
        {
            if (ShowingNetworkError && isNetworkError(mess))
            {
                return false;
            }
            else if (!ShowingNetworkError)
            {
                if (isNetworkError(mess) &&  !mess.ToUpper().Contains("DEADLOCKED ON LOCK"))
                {
                    ShowingNetworkError = true;
                    return true;
                }
                else if (mess.ToUpper().Contains("DEADLOCKED ON LOCK"))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        private static bool isNetworkError(string mess)
        {
          return   mess.ToUpper().Contains("A NETWORK-RELATED OR INSTANCE-SPECIFIC ERROR OCCURRED WHILE ESTABLISHING A CONNECTION")
                || mess.ToUpper().Contains("THE CONNECTION IS BROKEN AND RECOVERY IS NOT POSSIBLE")
                || mess.ToUpper().Contains("DEADLOCKED ON LOCK")
                || mess.ToUpper().Contains("EXECUTION TIMEOUT EXPIRED")
                || mess.ToUpper().Contains("A TRANSPORT - LEVEL ERROR HAS OCCURRED WHEN RECEIVING RESULTS FROM THE SERVER");
        }
    }
}
