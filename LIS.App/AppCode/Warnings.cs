using System;
using System.Windows.Forms;

namespace TPH.LIS.App.AppCode
{
    public class Warnings
    {
        public const string SQLSERVER_NOT_CONNECT = "Không kết nối được với SQL Server";
        public const string CAPTION = "TPH.LabIMS";
        public const string ERROR = "TPH.LabIMS - Error";
        public const string DUPLICATE = "TPH.LabIMS - Lỗi trùng dữ liệu";
        public static void MSG_WARNING(string _Mess)
        {
            MessageBox.Show(_Mess, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MSG_ERROR(string _Mess)
        {
            MessageBox.Show(_Mess, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MSG_INFORMATION(string _Mess)
        {
            MessageBox.Show(_Mess, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static bool MSG_ERROR(Exception ex, string _Method)
        {
            Error_Code err = new Error_Code();
            return err.GetErr_Framework(ex, _Method);
        }
        public static DialogResult MSG_QUESTION(string _Mess)
        {
            return MessageBox.Show(_Mess, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static bool MSG_QUESTION_GET_YES(string _Mess)
        {
            return MessageBox.Show(_Mess, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        public static bool MSG_QUESTION_GET_NO(string _Mess)
        {
            return MessageBox.Show(_Mess, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }
    }
}
