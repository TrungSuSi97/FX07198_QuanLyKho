using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.Common.Controls.CustomMsgBox;
using TPH.WriteLog;

namespace TPH.LIS.Common.Controls
{
    public class CustomMessageBox
    {
        private const string MessTitleWarning = "CẢNH BÁO !";
        private const string MessTitleInformation = "THÔNG BÁO !";
        private const string MessTitleQuestion = "XÁC NHẬN THỰC HIỆN";
        private const string MessTitleError = "THÔNG BÁO LỖI";
        private const string MessTitlePleaseWait = "VUI LÒNG CHỜ!";
        private static FrmMessageBox _fAlert = new FrmMessageBox();
        private static bool _showingNetworkError;

        /// <summary>
        /// Hiển thị message thông báo
        /// <param name="messalert">Nội dung</param>
        /// <param name="iconIndex">0: Asterisk - 1: Error - 2: Exclamation - 3: Hand - 4: Information - 5: Question - 6: Stop - 7: Warning - 8: Loading</param>
        /// <param name="topMost">Topmost(Default:True)</param>
        /// </summary>
        public static void ShowAlert(string messalert, int iconIndex = 4, bool topMost = true)
        {
            if (_fAlert.IsDisposed)
            {
                _fAlert = new FrmMessageBox();
                SetControlColor(_fAlert);
            }

            _fAlert.TopMost = true;
            _fAlert.IsAlertMode = true;
            _fAlert.MsgTitle =
                MessTitlePleaseWait; // LanguageExtension.GetResourceValueFromValue(Mess_Title_PleaseWait, LanguageExtension.AppLanguage);
            _fAlert.MsgContent = messalert.Replace("\r\n", "\n").Replace("\n", "\r\n");
            _fAlert.MsgIcon = iconIndex;
            _fAlert.ControlBox = true;
            _fAlert.AutoSize = false;
            _fAlert.Size = new System.Drawing.Size(_fAlert.Width, 177);
            _fAlert.pnContent.AutoSize = false;
            _fAlert.pnContent.Dock = DockStyle.Fill;

            _fAlert.Show();
            _fAlert.Refresh();
            _fAlert.TopMost = topMost;
        }

        public static void CloseAlert()
        {
            if (!_fAlert.IsDisposed)
                _fAlert.Close();
        }

        public static DialogResult MSG_Waring_OK(string mess)
        {
            if (!Check_NetworkError_AllowShow(mess)) return DialogResult.OK;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.OK, MsgTitle = MessTitleWarning, MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"), MsgIcon = 7
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR;

        }

        public static DialogResult MSG_Information_OK(string mess)
        {
            if (!Check_NetworkError_AllowShow(mess)) return DialogResult.OK;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.OK, MsgTitle = MessTitleInformation, MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"), MsgIcon = 4
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR;

        }

        public static DialogResult MSG_Error_OK(string mess, Exception ex = null)
        {
            if (!Check_NetworkError_AllowShow(mess)) return DialogResult.OK;
            CloseAlert();
            LogService.RecordLogError(string.Empty, "ErrLog_Mess", ex, 0, mess, string.Empty);
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.OK, MsgTitle = MessTitleError, MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"), MsgIcon = 1
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;

            f.Dispose();
            return diagR;

        }

        public static bool MSG_Question_YesNo_GetYes(string mess,
            CustomMessageBoxConstants.DefaultButton btnDefault = CustomMessageBoxConstants.DefaultButton.Accept)
        {
            if (!Check_NetworkError_AllowShow(mess)) return false;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.YesNo,
                MsgTitle = MessTitleQuestion,
                MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"),
                MsgIcon = 5,
                btnDefault = btnDefault
            };

            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR == DialogResult.Yes;

        }

        public static bool MSG_Question_YesNo_GetNo(string mess,
            CustomMessageBoxConstants.DefaultButton btnDefault = CustomMessageBoxConstants.DefaultButton.Accept)
        {
            if (!Check_NetworkError_AllowShow(mess)) return false;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.YesNo,
                MsgTitle = MessTitleQuestion,
                MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"),
                MsgIcon = 5,
                btnDefault = btnDefault
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR == DialogResult.No;
        }

        public static bool MSG_Question_YesNoCancel_GetYes(string mess)
        {
            if (!Check_NetworkError_AllowShow(mess)) return false;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.YesNoCancel,
                MsgTitle = MessTitleQuestion,
                MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"),
                MsgIcon = 5
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR == DialogResult.Yes;
        }

        public static bool MSG_Question_YesNoCancel_GetNo(string mess)
        {
            if (!Check_NetworkError_AllowShow(mess)) return false;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.YesNoCancel,
                MsgTitle = MessTitleQuestion,
                MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"),
                MsgIcon = 5
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR == DialogResult.No;
        }

        public static bool MSG_Question_YesNoCancel_GetCancel(string mess)
        {
            if (!Check_NetworkError_AllowShow(mess)) return false;
            CloseAlert();
            var f = new FrmMessageBox
            {
                MsgBtn = MessageBoxButtons.YesNoCancel,
                MsgTitle = MessTitleQuestion,
                MsgContent = mess.Replace("\r\n", "\n").Replace("\n", "\r\n"),
                MsgIcon = 5
            };
            SetControlColor(f);
            f.ShowDialog();
            var diagR = f.MsgResult;
            f.Dispose();
            return diagR == DialogResult.Cancel;
        }

        public static void ShowRawData(DataTable data, string tiltle = "")
        {
            var f = new FrmShowRawData {lblTitle = {Text = tiltle}, ShowData = data};
            SetControlColor(f);
            f.ShowDialog();
        }

        private static bool Check_NetworkError_AllowShow(string mess)
        {
            if (_showingNetworkError && mess.ToUpper()
                    .Contains("A NETWORK-RELATED OR INSTANCE-SPECIFIC ERROR OCCURRED WHILE ESTABLISHING A CONNECTION"))
            {
                return false;
            }
            else if (!_showingNetworkError)
            {
                _showingNetworkError = mess.ToUpper()
                    .Contains("A NETWORK-RELATED OR INSTANCE-SPECIFIC ERROR OCCURRED WHILE ESTABLISHING A CONNECTION");
                return true;
            }
            else
                return true;
        }

        private static void SetControlColor(Control mainControl)
        {
            foreach (Control item in mainControl.Controls)
            {
                if (item is ucGroupHeader)
                {
                    var obj = (ucGroupHeader) item;
                    obj.BackColor = CommonAppColors.ColorMainAppColor;
                    obj.ForeColor = CommonAppColors.ColorTextCaption;
                }

                else if (item is TPHNormalButton)
                {
                    if (item.BackColor == SystemColors.Control || item.BackColor == Color.FromArgb(204, 204, 204))
                    {
                        item.BackColor = CommonAppColors.ColorButtonBackColor;
                        item.ForeColor = CommonAppColors.ColorButtonForceColor;
                        var btn = (TPHNormalButton) item;
                        if (string.IsNullOrEmpty(btn.Text) && btn.Image != null)
                        {
                            btn.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                }

                if (item.Controls.Count > 0)
                {
                    SetControlColor(item);
                }
            }
        }
    }
}