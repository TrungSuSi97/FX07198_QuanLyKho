using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Log;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Services;
namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{

    public partial class ucLogLogin : UserControl
    {
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        public ucLogLogin()
        {
            InitializeComponent();
        }
        private void Get_LogList()
        {
            Log.LogActionId logId = Log.LogActionId.LoginIn;

            DataTable dtSearchResult = _iLogService.ReadLog_List(LogTableIds.Ql_nguoidung
                , logId, txtSearchValue.Text, string.Empty, string.Empty, dtpFromDate.Value, dtpToDate.Value, string.Empty);
            Common.Extensions.ControlExtension.BindToGrid(dtSearchResult, ref dtgLogList, ref bvList, false);
        }
        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            Get_LogList();
        }

        private void ucLogThongTinHanhChinh_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpToDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59,59);
        }
    }
}
