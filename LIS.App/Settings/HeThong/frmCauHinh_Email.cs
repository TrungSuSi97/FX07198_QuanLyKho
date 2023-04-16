using System;
using System.Data;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Constants;

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class frmEmailConfig : Form
    {

        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        public frmEmailConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "update {{TPH_Standard}}_System.dbo.CauHinh set SMTPServer =N'" + Utilities.ConvertSqlString(txtSMTPServer.Text) + "' \n";
            strSQL += ",MailFrom = N'" + Utilities.ConvertSqlString(txtEmailAddress.Text) + "'\n";
            strSQL += ",UserEmail = N'" + Utilities.ConvertSqlString(txtUserID.Text) + "'\n";
            strSQL += ",PasswordEmail = N'" + Utilities.ConvertSqlString(txtPassword.Text) + "'\n";
            strSQL += ",Body = N'" + Utilities.ConvertSqlString(txtBody.Text) + "'\n";
            strSQL += ",Credential = " + (chkCredential.Checked == true ? "1" : "0");
            strSQL += " where ID=1";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
            _registryExtension.WriteRegistry(UserConstant.RegistryPdfPath, txtPath.Text);

            this.Close();
        }

        private void Load_EmailConfig()
        {
            string strSQL = "select * from {{TPH_Standard}}_System.dbo.CauHinh where ID=1";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            txtSMTPServer.DataBindings.Clear();
            txtSMTPServer.DataBindings.Add("Text", dt, "SMTPServer");
            txtEmailAddress.DataBindings.Clear();
            txtEmailAddress.DataBindings.Add("Text", dt, "MailFrom");
            txtUserID.DataBindings.Clear();
            txtUserID.DataBindings.Add("Text", dt, "UserEmail");
            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add("Text", dt, "PasswordEmail");
            txtBody.DataBindings.Clear();
            txtBody.DataBindings.Add("Text", dt, "Body");
            chkCredential.DataBindings.Clear();
            chkCredential.DataBindings.Add("Checked", dt, "Credential");
            txtPath.Text = _registryExtension.ReadRegistry(UserConstant.RegistryPdfPath);
        }

        private void frmEmailConfig_Load(object sender, EventArgs e)
        {
            Load_EmailConfig();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCredential_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = txtUserID.Enabled = chkCredential.Checked;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browse = new FolderBrowserDialog();
            browse.ShowDialog();
            if (browse.SelectedPath != string.Empty)
            {
                txtPath.Text = browse.SelectedPath;
            }
        }

        private void txtSMTPServer_Enter(object sender, EventArgs e)
        {
            if (txtSMTPServer.Text == "")
            {
                //smtp.gmail.com
                //smtp.live.com
                //smtp.mail.yahoo.com
                if (txtEmailAddress.Text.ToLower().Contains("gmail.com"))
                    txtSMTPServer.Text = "smtp.gmail.com";
                else if (txtEmailAddress.Text.ToLower().Contains("live.com") || txtEmailAddress.Text.ToLower().Contains("hotmail.com"))
                    txtSMTPServer.Text = "smtp.live.com";
                else if (txtEmailAddress.Text.ToLower().Contains("yahoo.com"))
                    txtSMTPServer.Text = "smtp.mail.yahoo.com";
            }
        }
    }
}
