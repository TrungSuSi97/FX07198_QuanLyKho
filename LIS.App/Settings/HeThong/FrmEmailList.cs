using System;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmEmailList : FrmTemplate
    {
        public FrmEmailList()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private void btnThemEmail_Click(object sender, EventArgs e)
        {
            var obj = new DM_EMAIL();
            obj.Email = txtEmail.Text;
            sysConfig.Insert_dm_email(obj);
            Load_DanhSachEmail();
            txtEmail.Text = "";
            txtEmail.Focus();
        }
        private void Load_DanhSachEmail()
        {
            var danhSach = sysConfig.Data_dm_email(string.Empty);
            ControlExtension.BindDataToGrid(danhSach, ref dtgEmailList, ref bvEmailList);
        }

        private void XoaEmail()
        {
            if (dtgEmailList.CurrentRow != null)
            {
                var email = dtgEmailList.CurrentRow.Cells[colEmail.Name].Value.ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa email: {0}", email)))
                {
                    if (sysConfig.Delete_dm_email(new DM_EMAIL(email, null)))
                        Load_DanhSachEmail();
                }
            }
        }

        private void FrmEmailList_Load(object sender, EventArgs e)
        {
            Load_DanhSachEmail();
            txtEmail.Focus();
        }

        private void btnDeleteMail_Click(object sender, EventArgs e)
        {
            XoaEmail();
        }
    }
}
