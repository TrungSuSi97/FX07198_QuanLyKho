using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode
{
    public class SendMailHelper
    {
        public static bool SendEmail(int ReportType, string maTiepNhan, string duongDan, string eMailTo, List<string> listAttachPath = null, string tenBenhNhan = "")
        {
            var emailConfig = CommonAppVarsAndFunctions.sysConfig;
            if (emailConfig == null) return false;
            var SMTPServer = emailConfig.EmailSmptServer.Trim();
            var MailPortNumber = emailConfig.EmailPortNumber.Trim();
            var MailFrom = emailConfig.EmailMailFrom.Trim();
            var UserId = emailConfig.EmailUserId.Trim();
            var Password = emailConfig.EmailPassword.Trim();
            var  Body = emailConfig.EmailMailBody.Trim();
            var EmailUseSsl = emailConfig.EmailUseSsl;
            try
            {
                var mailcl = new SmtpClient { Host = SMTPServer };
                var from = new MailAddress(MailFrom);
                var mail = SMTPServer.Split(new char[] { '.' });

                if (!string.IsNullOrEmpty(MailPortNumber) && WorkingServices.IsNumeric(MailPortNumber))
                {
                    mailcl.Port = int.Parse(MailPortNumber);
                }

                mailcl.EnableSsl = EmailUseSsl;

                if (!string.IsNullOrWhiteSpace(UserId) &&
                    !string.IsNullOrWhiteSpace(Password))
                {
                    mailcl.UseDefaultCredentials = false;
                    var creden = new NetworkCredential(UserId, Password);
                    mailcl.Credentials = creden;
                }

                var msg = new MailMessage();
                msg.To.Add(eMailTo);
                msg.From = from;
                if (ReportType == (int)ServiceType.ClsXetNghiem)
                {
                    msg.Subject = string.Format("{0}: {1}-{2}", ReportConstant.TestResultTitle, tenBenhNhan, maTiepNhan);
                }
                else if (ReportType == (int)ServiceType.ClsSieuAm)
                {
                    msg.Subject = string.Format("{0}: {1}-{2}", ReportConstant.SupersonicResultTitle, tenBenhNhan, maTiepNhan);
                }
                else if (ReportType == (int)ServiceType.ClsXQuang)
                {
                    msg.Subject = string.Format("{0}: {1}-{2}", ReportConstant.XRayResultTitle, tenBenhNhan, maTiepNhan);
                }
                else if (ReportType == (int)ServiceType.ClsNoiSoi)
                {
                    msg.Subject = string.Format("{0}: {1}-{2}", ReportConstant.EndoscopicResultTitle, tenBenhNhan, maTiepNhan);
                }

                msg.Body = Regex.Replace(Body, @"\r\n?|\n", "<br />");
                msg.IsBodyHtml = true;
                msg.BodyEncoding = Encoding.UTF8;

                if (listAttachPath != null)
                {
                    //Convert thành image trước khi gửi
                    //   var list = PdfExtension.ConvertPdfToImage(pdfPath, duongDan, true, 450, MagickFormat.Jpeg);
                    foreach (var item in listAttachPath)
                    {
                        msg.Attachments.Add(new Attachment(item));
                    }
                }
                //  msg.Attachments.Add(at);
                mailcl.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK("Lỗi gửi mail", ex);
                return false;
            }
        }
    }
}
