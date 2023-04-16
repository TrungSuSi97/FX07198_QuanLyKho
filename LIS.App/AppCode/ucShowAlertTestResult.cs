using System;
using System.Windows.Forms;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.App.AppCode
{
    public partial class ucShowAlertTestResult : UserControl
    {
        public ucShowAlertTestResult()
        {
            InitializeComponent();
        }
        private readonly ITestResultService _iResult = new TestResultService();
        string currentMatiepNhan = string.Empty;
        public void Get_DanhSachKetQua(string matiepNhan)
        {
            currentMatiepNhan = matiepNhan;
            var data = _iResult.DuLieuXetNghiemCanhBao(matiepNhan);
            ControlExtension.BindDataToGrid(data, ref dtgKetQuaXN, null);
        }

        private void btnLoadKetQua_Click(object sender, EventArgs e)
        {
            Get_DanhSachKetQua(currentMatiepNhan);
        }
    }
}
