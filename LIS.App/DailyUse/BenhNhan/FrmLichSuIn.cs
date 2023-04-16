using System;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log.Services.WorkingLog;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmLichSuIn : FrmTemplate
    {
        private readonly IWorkingLogService workingLog = new WorkingLogService();
        public string MaTiepNhan = string.Empty;
        public FrmLichSuIn()
        {
            InitializeComponent();
        }
        private void Load_DanhSachInKQ()
        {
            var data = workingLog.DataNhatKy_InKetQua(MaTiepNhan);
            ControlExtension.BindDataToGrid(data, ref dataGridView1, ref bindingNavigator1);
        }

        private void FrmLichSuIn_Load(object sender, EventArgs e)
        {
            Load_DanhSachInKQ();
        }
    }
}
