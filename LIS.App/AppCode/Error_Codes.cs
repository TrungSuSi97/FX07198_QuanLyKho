using System;
using System.Data.Odbc;
using Microsoft.VisualBasic;

namespace TPH.LIS.App.AppCode
{
    class Error_Code
    {
        public string ErrCode(string _errCode)
        {
            switch (_errCode)
            {
                case "0":
                    return "Lỗi không kết nối được máy chủ";
                case "156":
                    return "Lỗi cú pháp SQL";
                case "102" :
                    return "Lỗi cú pháp SQL";
                case "208":
                    return "Không tìm thấy bảng";
                case "205":
                    return "Cấu trúc giữa các bảng cần lấy không đồng bộ";
                case "17":
                    return "Không kết nối được máy chủ";
                case "53":
                    return "Không thể mở kết nối";
                case "207" :
                    return "Không tìm thấy cột";
                case "2627":
                    return "Dữ liệu đã được nhập truớc";
                case "535":
                    return "Optional feature not implemented";
                case "534":
                    return "Invalid cursor position";
                case "18456":
                    return "Lỗi nhập vào Database";
                case "533":
                    return "Row value out of range";
                case "532":
                    return "Fetch type out of range";
                case "531":
                    return "Function type out of range";
                case "530":
                    return "Invalid parameter number";
                case "529":
                    return "Invalid attribute/option identifier";
                case "528":
                    return "Invalid descriptor field identifier";
                case "527":
                    return "Invalid string or buffer length";
                case "526":
                    return "Invalid attribute value";
                case "525":
                    return "No cursor name available";
                case "524":
                    return "Memory management error";
                case "523":
                    return "Invalid transaction operation code";
                case "522":
                    return "Attribute can not be set now";
                case "521":
                    return "Function sequence error";
                case "520":
                    return "Invalid use of null pointer";
                case "519":
                    return "Kiểu dữ liệu không đúng";
                case "518":
                    return "Invalid application buffer type";
                case "517":
                    return "Invalid column number";
                case "516":
                    return "Memory allocation error";
                case "515":
                    return "Không thể ghi giá trị NULL";
                case "514":
                    return "Invalid cursor name";
                case "513":
                    return "Transaction state unknown";
                case "512":
                    return "Invalid transaction state";
                case "511":
                    return "Invalid cursor state";
                case "510":
                    return "Kết nối không tồn tại";
                case "509":
                    return "Kết nối đang sử dụng";
                case "508":
                    return "Invalid descriptor index";
                case "507":
                    return "Prepared statement not a cursor-specification";
                case "506":
                    return "SQLBindParameter not used for all parameters";
                case "505":
                    return "Attempt to fetch before the result set returned the first row set";
                case "504":
                    return "More than one row updated/deleted";
                case "503":
                    return "No rows updated/deleted";
                case "502":
                    return "Option value changed";
                case "501":
                    return "String data, right truncated";
                case "500":
                    return "General warning";
                case "120" :
                    return "Số cột trong câu insert và select không giống nhau";
                case "2812":
                    return "Không tìm thấy stored";
                case "3621":
                    return "Quá trình thực thi bị dừng";
                case "248":
                    return "Việc chuyển đổi các giá trị \"varchar\" vượt quá cột \"int\".\r\n\t=>Giá trị số nguyên vượt quá tối đa .";
                    //orther
                default:
                    return "";

            }
        }
        private string _Message(string _str)
        {
            _str = _str.Replace("[Microsoft][ODBC SQL Server Driver]", "");
            _str = _str.Replace("System.InvalidOperationException:", "");
            _str = _str.Replace("[SQL Server]", "");
            _str = _str.Replace("[DBNETLIB]", "");
            _str = _str.Replace("on the DataSource.\r\nParameter name: dataMember", "");
            _str = _str.Replace("Cannot bind to the property or column", "Không thể gán thuộc tính hoặc giá trị cho cột");
            _str = _str.Replace("The connection's current state is closed", "Kết nối hiện tại đã bị đóng");
            _str = _str.Replace("The connection has been disabled.", "Lỗi kết nối mạng.\nVui lòng kiểm tra mạng LAN");
            _str = _str.Replace("Object reference not set to an instance of an object", "Đối tượng cần tham chiếu chưa khởi tạo hoặc đang null");
            _str = _str.Replace("Index and length must refer to a location within the string", "Vị trí bắt đầu và độ dài chuỗi cần lấy vuợt độ dài");
            _str = _str.Replace("Cannot access a disposed object.", "Không thể truy cập đối tượng đã đóng.");
            _str = _str.Replace("Object name:", "Đối tượng:");
            _str = _str.Replace("There is no row at position ", "Không có dòng nào tại vị trí ");
            _str = _str.Replace("The device is not ready.", "Đường dẫn lưu trữ không thể truy xuất.");
            _str = _str.Replace("The RPC server is unavailable", "Không lấy được danh sách máy in !\nService: \"Print Spooler\" chưa chạy.");
            if (Strings.InStr(1, _str, "System.Runtime.InteropServices.COMException", CompareMethod.Text) > 0)
            {
                _str = "Lỗi .NET FrameWork! \nGặp lỗi này bạn nên tắt và mở lại ứng dụng!";
            }
            return _str;
        }
        public void GetErr_ODBC(OdbcException ex, string strSQL)
        {
            string _err = "";
            string _errReturn = "";
            string _code = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                _code += (_code.Length > 0 ? ", " + ex.Errors[i].NativeError.ToString() : ex.Errors[i].NativeError.ToString());
                _errReturn = ErrCode(ex.Errors[i].NativeError.ToString());
                if (_errReturn != "")
                {
                    if (_err != "")
                    {
                        _err += Environment.NewLine + _errReturn + " - " + ex.Errors[i].Message;
                    }
                    else
                    {
                        _err += _errReturn + " - " + ex.Errors[i].Message;
                    }
                }
                else
                {
                    if (_err != "")
                    {
                        _err += Environment.NewLine + " - " + _Message(ex.Errors[i].Message);
                    }
                    else
                    {
                        _err += " - " + _Message(ex.Errors[i].Message);
                    }
                }
            }

            FrmMessageError frm = new FrmMessageError();
            _err = _err.Replace("[Microsoft][ODBC SQL Server Driver]", "").Replace("[SQL Server]", "").Replace("[DBNETLIB]", "");
            if (Strings.InStr(strSQL, "insert tbl_result(", CompareMethod.Text) > 0 && Strings.InStr(_code, "2627", CompareMethod.Text) > 0)
            {
                _err = " Chỉ định đã nhập trước !";
                frm.ShowType = 2;
            }
            frm.Msg = _err;
            frm.ErrDetail = "Error Code: " + _code + Environment.NewLine + ex.ToString();
            frm.ShowDialog();
            ProcessServices.RecordError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " + frmMDIParent.UserID + " , Error Code: " + _code + Environment.NewLine + _err.ToUpper() + (strSQL != "" ? Environment.NewLine + "SQL_ERROR: " + Environment.NewLine + strSQL : "") + Environment.NewLine + "DETAIL: " + Environment.NewLine + ex.ToString());

        }
        public void GetErr_ODBCHIS(OdbcException ex, string strSQL, bool _isTestConnect)
        {
            string _err = "";
            string _errReturn = "";
            string _code = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                _code += (_code.Length > 0 ? ", " + ex.Errors[i].NativeError.ToString() : ex.Errors[i].NativeError.ToString());
                _errReturn = ErrCode(ex.Errors[i].NativeError.ToString());
                if (_errReturn != "")
                {
                    if (_err != "")
                    {
                        _err += Environment.NewLine + _errReturn + " - " + ex.Errors[i].Message;
                    }
                    else
                    {
                        _err += _errReturn + " - " + ex.Errors[i].Message;
                    }
                }
                else
                {
                    if (_err != "")
                    {
                        _err += Environment.NewLine + " - " + _Message(ex.Errors[i].Message);
                    }
                    else
                    {
                        _err += " - " + _Message(ex.Errors[i].Message);
                    }
                }
            }

            FrmMessageError frm = new FrmMessageError();
            _err = _err.Replace("[Microsoft][ODBC SQL Server Driver]", "").Replace("[SQL Server]", "").Replace("[DBNETLIB]", "");
            if (_isTestConnect == true && Strings.InStr(_code, "17", CompareMethod.Text) > 0)
            {
                _err = "Không kết nối được máy chủ HIS";
            }
            _err = "LỖI KẾT NỐI HIS " + Environment.NewLine + _err;
            frm.Msg = _err;
            frm.ErrDetail = "Error Code: " + _code + Environment.NewLine + ex.ToString();
            frm.ShowDialog();
            ProcessServices.RecordError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " + frmMDIParent.UserID + " , Error Code: " + _code + Environment.NewLine + _err.ToUpper() + (strSQL != "" ? Environment.NewLine + "SQL_ERROR: " + Environment.NewLine + strSQL : "") + Environment.NewLine + "DETAIL: " + Environment.NewLine + ex.ToString());
        }
        /// <summary>
        /// Hàm hiển thị thông báo lỗi trong quá trình thao tác trên form 
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="Method_Call">Tên của hàm đang gọi</param>
        public bool GetErr_Framework(Exception ex, string Method_Call)
        {
            string _err = _Message(ex.Message);
            int _errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
            FrmMessageError frm = new FrmMessageError();
            frm.Msg = _err;
            frm.ErrDetail = Environment.NewLine + "METHOD CALL: " + Method_Call +
                Environment.NewLine + ex.ToString();
            frm.ShowDialog();
            ProcessServices.RecordError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " + frmMDIParent.UserID + " , Error Code: " + _errorCode.ToString() + 
                Environment.NewLine + _err.ToUpper() + 
                Environment.NewLine + "METHOD CALL: " + Method_Call +
                Environment.NewLine + "DETAIL: " + 
                Environment.NewLine + ex.ToString());
            return false;

        }
        public void GetErr_Framework(Exception ex, string Method_Call, bool _Show)
        {
            string _err = _Message(ex.Message);
            int _errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
            if (_Show)
            {
                FrmMessageError frm = new FrmMessageError();
                frm.Msg = _err;
                frm.ErrDetail = Environment.NewLine + "METHOD CALL: " + Method_Call +
                    Environment.NewLine + ex.ToString();
                frm.ShowDialog();
            }
            ProcessServices.RecordError(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ",User: " + frmMDIParent.UserID + " , Error Code: " + _errorCode.ToString() +
                Environment.NewLine + _err.ToUpper() +
                Environment.NewLine + "METHOD CALL: " + Method_Call +
                Environment.NewLine + "DETAIL: " +
                Environment.NewLine + ex.ToString());

        }
    }
}
