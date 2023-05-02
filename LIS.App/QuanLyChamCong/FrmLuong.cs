using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.User.Models;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.QuanLyChamCong
{
    public partial class FrmLuong : FrmTemplateCommon
    {
        public FrmLuong()
        {
            InitializeComponent();
        }
        private readonly IUserManagementService _IUserService = new UserManagementService();

        private void FrmLuong_Load(object sender, EventArgs e)
        {

        }

        private void btnCalLuong_Click(object sender, EventArgs e)
        {
            TinhToanLuong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
        private void TinhToanLuong()
        {


        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadLuoiLuong()
        {
            gcLuong.DataSource = null;
            UserLuongModel model = new UserLuongModel();

        }
    }
}
