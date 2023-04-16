using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Components;
namespace ClinicManagementSystem
{
    public partial class frmEmailConfig : Form
    {
        DataProvider dp = new DataProvider();
        RegKeys reg = new RegKeys(0, frmMDIParent.subkey);
        public frmEmailConfig()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "update CauHinh set SMTPServer =N'" + ProcessServices.ConvertString(txtSMTPServer.Text) + "' \n";
            strSQL += ",MailFrom = N'" + ProcessServices.ConvertString(txtEmailAddress.Text) + "'\n";
            strSQL += ",UserEmail = N'" + ProcessServices.ConvertString(txtUserID.Text) + "'\n";
            strSQL += ",PasswordEmail = N'" + ProcessServices.ConvertString(txtPassword.Text) + "'\n";
            strSQL += ",Body = N'" + ProcessServices.ConvertString(txtBody.Text) + "'\n";
            strSQL += ",Credential = " + (chkCredential.Checked == true ? "1" : "0");
            strSQL += " where ID=1";
            dp.ExecuteQuery(strSQL);
            reg.WriteRegistry("PDFPath", txtPath.Text);
            this.Close();
        }

        private void Load_EmailConfig()
        {
            string strSQL = "select * from CauHinh where ID=1";
            DataTable dt = new DataTable();
            dt = dp.ExcuteDataSet(strSQL).Tables[0];
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
            txtPath.Text = reg.ReadRegistry("PDFPath");
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
    }
}
