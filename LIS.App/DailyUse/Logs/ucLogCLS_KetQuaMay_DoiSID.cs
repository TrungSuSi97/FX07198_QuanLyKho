using System;
using System.Windows.Forms;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Services;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Analyzer.Services;

namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{

    public partial class ucLogCLS_KetQuaMay_DoiSID : UserControl
    {
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        private readonly ITestResultInformationService _iResult = new TestResultInformationService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private string _fromBarcode;

        public string FromBarcode
        {
            get { return _fromBarcode; }
            set { _fromBarcode = value; }
        }
        private string _toBarcode;

        public string ToBarcode
        {
            get { return _toBarcode; }
            set { _toBarcode = value; }
        }

        private int _inId = -1;

        public int InId
        {
            get { return _inId; }
            set { _inId = value; }
        }

        private DateTime? _fromDate;

        public DateTime? FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }
        private DateTime? _toDate;

        public DateTime? ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }

        private string _testCode;

        public string TestCode
        {
            get { return _testCode; }
            set { _testCode = value; }
        }

        private bool _isProfileTest = false;

        public bool IsProfileTest
        {
            get { return _isProfileTest; }
            set { _isProfileTest = value; }
        }

        public ucLogCLS_KetQuaMay_DoiSID()
        {
            InitializeComponent();
        }
        private void Get_LogList()
        {
            bool isProfile = (txtProfile.Text == ProfileTestContant.ProfileChar);
            string testCode = (cboTestCode.SelectedIndex > -1 ? cboTestCode.SelectedValue.ToString().Trim() : string.Empty);
            int inId = (cboMayXetNghiem.SelectedIndex > -1 ? int.Parse(cboMayXetNghiem.SelectedValue.ToString()) : -1);

            Common.Extensions.ControlExtension.BindToGrid(_iLogService.ReadLog_instrumentSid(dtpFromDate.Value, dtpToDate.Value
                , testCode, isProfile, inId, txtFrombarcode.Text, txtTobarcode.Text),ref dtgLogList, ref bvList, false);
            dtgLogList.AutoResizeColumns();
        }
        private void Load_Config()
        {
            cboTestCode.ValueMember  = "MAXN";
            cboTestCode.DisplayMember = "MaGoTat";
            cboTestCode.LinkedColumnIndex1 = 0;
            cboTestCode.LinkedTextBox1 = txtProfile;
            sysConfig.GetSubclinicalTestAndProfile(cboTestCode, string.Empty, string.Empty);

            cboMayXetNghiem.ColumnNames = "IDMay,TenMay";
            cboMayXetNghiem.ColumnWidths = "30,200";
            cboMayXetNghiem.DisplayMember = "IDMay";
            cboMayXetNghiem.ValueMember = "IDMay";
            cboMayXetNghiem.DataSource = _iAnalyzerConfig.Data_h_mayxetnghiem();
            cboMayXetNghiem.SelectedIndex = -1;

            txtTobarcode.Text = _toBarcode;
            txtFrombarcode.Text = _fromBarcode;

            if (_fromDate != null)
                dtpFromDate.Value = DateTime.Parse(_fromDate.ToString());

            if (_toDate != null)
                dtpToDate.Value = DateTime.Parse(_toDate.ToString());

            if (_inId > 0)
                cboMayXetNghiem.SelectedValue = _inId;

            if(!string.IsNullOrEmpty(_testCode))
            {
                cboTestCode.SelectedValue = _testCode;
                txtProfile.Text = (_isProfileTest ? ProfileTestContant.ProfileChar : ProfileTestContant.TestChar);
            }
        }
      
        private void btnSearchLog_Click(object sender, EventArgs e)
        {
            Get_LogList();
        }

        private void ucLogThongTinHanhChinh_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpToDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59,59);
            Load_Config();
            Get_LogList(); 
        }
    }
}
