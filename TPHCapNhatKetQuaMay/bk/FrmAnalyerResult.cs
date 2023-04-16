using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Common.Constants;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.ResultConvert.Service;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Models;

namespace TPHCapNhatKetQuaMay
{
    public partial class FrmAnalyerResult : Form
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, "SOFTWARE\\TPH.TPHLIS\\Properties\\");

        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IResultConvertService _iResultConvert = new ResultConvertService();
        private ConfigurationDetail systemConfig;
        private string PCWorkPlace;
        int countToPause = 0;
        int countToResume = 0;
        private string runningText = "";
        private UserInfo loginInfo = new UserInfo();
        public static string[] PhanQuyenMayXetNghiem { get; set; }
        public FrmAnalyerResult()
        {
            InitializeComponent();
        }
        private void Get_LocalSetting()
        {
            var tgUpload = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_ScanWait);
            numTgUpload.Value = int.Parse(string.IsNullOrEmpty(tgUpload) ? "10" : tgUpload);

            var tgSoNgay = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_DayScan);
            numSoNgayCapNhat.Value = int.Parse(string.IsNullOrEmpty(tgSoNgay) ? "1" : tgSoNgay);

            var tgKQLoi = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_HourToGetErrorResult);
            nuGioHanGioKQLoi.Value = int.Parse(string.IsNullOrEmpty(tgKQLoi) ? "2" : tgKQLoi);

            var tgTuDung = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_StopRunAfter);
            nuTimeToPause.Value = int.Parse(string.IsNullOrEmpty(tgTuDung) ? "1440" : tgTuDung);

            var tgTGChayLai = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_StartAfterAutoStop);
            nuTimeToResume.Value = int.Parse(string.IsNullOrEmpty(tgTGChayLai) ? "1" : tgTGChayLai);

        }
        private void SaveLocalSetting()
        {
            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_ScanWait, numTgUpload.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_DayScan, numSoNgayCapNhat.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_HourToGetErrorResult, nuGioHanGioKQLoi.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_StopRunAfter, nuTimeToPause.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_StartAfterAutoStop, nuTimeToResume.Value.ToString());
        }
        private void Get_SystemConfig()
        {
            if (rkApp.GetValue("TPHAnalyzer") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                chkStartWithWindows.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                chkStartWithWindows.Checked = true;
            }
            chkMinisizeWihenStartWithWindows.Checked = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_MinimumsizeAutoStart).Equals("1");
            chkUploadWhenStart.Checked = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_StartUploadWhenStart).Equals("1");

            systemConfig = _systemConfigService.GetSystemConfigurationDetail();
            if (systemConfig.ClsXetNghiemFormKQMayTuDong)
            {
                MessageBox.Show("Hệ thống đang được cấu hình lấy kết quả tự động trên TPH.LabIMS!\nHãy chuyển cấu hình chạy trên ứng dụng riêng để tránh ảnh hưởng hệ thống.");
                Application.Exit();
            }
        }
        private void SetDungGioPhut()
        {
            dtpFromDate.Value = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
            dtpToDate.Value = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);
        }
        private int[] NhanKQQuaTuNoi()
        {
            var arrget = new int[1];
            if (systemConfig.ClsXetNghiemKieuLayKetQuaMay == EnumKieuLayKetQuaMay.TatCa)
            {
                return new int[] { CommonConstant.TrangThaiKqMayTuMayKhac, CommonConstant.TrangThaiKqMayNhanTuMiddleware };
            }
            else if (systemConfig.ClsXetNghiemKieuLayKetQuaMay == EnumKieuLayKetQuaMay.ChiTuPhanMemTrungGian)
                return new int[] { CommonConstant.TrangThaiKqMayNhanTuMiddleware };
            else
                return new int[] { CommonConstant.TrangThaiKqMayTuMayKhac };
        }
        private void Load_MayXetNghiem()
        {
            string allowanalyzer = Utilities.ArrayToSqlValue(PhanQuyenMayXetNghiem);
            var mayXetNghiem = from selectData in _iAnalyzerConfig.Data_h_mayxetnghiem().AsEnumerable()
                               where (loginInfo.IsAdmin ? true : allowanalyzer.Contains(string.Format("'{0}'", selectData["IDMay"].ToString())))
                               select selectData;

            chkMayXetNghiem.DataSource = mayXetNghiem.AsDataView().ToTable();
            chkMayXetNghiem.DisplayMember = "tenmay2";
            chkMayXetNghiem.ValueMember = "IDMay";
            chkAllAnalyzer.Checked = true;
        }

        private void CapNhat_TuDong_ChapNhan()
        {
            try
            {
                lblTrangThai.Text = "Đang cập nhật kết quả máy!\nTrạng thái: Chấp nhận";
                lblTrangThai.Refresh();
                //Lấy kết quả.
                //Ưu tiên cập nhật kết quả đã chấp nhận trước.
                var dtAnalyzerResult = _iAnalyzerResult.Data_Analyzer_Result(dtpFromDate.Value.Date, dtpToDate.Value, ""
                    , string.Format("{0}", TestingResultStatusConstant.ChapNhan)
                    , string.Empty, null, null
                    , loginInfo.IsAdmin ? null : loginInfo.LoginName
                    , chkCapNhat_KetChaySau.Checked
                    , NhanKQQuaTuNoi(), false, -1, -1, true);

                if (dtAnalyzerResult.Rows.Count > 0)
                {
                    var dtSid = dtAnalyzerResult.DefaultView.ToTable(true, new string[] { "sid", "NgayXN" });
                    _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResult, _iResultConvert.Data_DM_XetNghiem_BienDichKetQua(-1, string.Empty, -1)
                        , progressBarKetQuaMayTuDong, systemConfig.ClsXetNghiemDinhDangKetqua, loginInfo.LoginName
                        , PCWorkPlace, systemConfig.ClsXetNghiemKieuLayKetQuaMay, true);
                }
                if (chkCapNhat_KetQuaLoi.Checked)
                {
                    lblTrangThai.Text = "Đang cập nhật kết quả máy!\nTrạng thái: Chưa nhập SID \nhoặc Chưa nhập Xét nghiệm";
                    lblTrangThai.Refresh();
                    CapNhatTuDongLoi();
                }

                if (dtAnalyzerResult.Rows.Count == 0 && dtpToDate.Value.Date < DateTime.Now.Date)
                {
                    dtpToDate.Value = DateTime.Now;
                    dtpFromDate.Value = dtpToDate.Value.AddDays(-((int)numSoNgayCapNhat.Value - 1));
                    SetDungGioPhut();
                }
            }
            catch (Exception ex)
            {
                Stop();
                ErrorHandler.RecordError("Auto update Analyzer result", "AutoUpdate_AnalyzerResult", ex, 0, ex.Message, "CapNhat_TuDong_ChapNhan");
                Start();
            }
        }

        private void CapNhatTuDongLoi()
        {
            var dtAnalyzerResult = _iAnalyzerResult.Data_Analyzer_Result(dtpFromDate.Value, dtpToDate.Value, string.Empty,
              string.Format("{0},{1}", TestingResultStatusConstant.ChuaNhapThongTin, TestingResultStatusConstant.ChuaNhapChiDinh)
              , string.Empty, null, null
               , loginInfo.IsAdmin ? null : loginInfo.LoginName
              , chkCapNhat_KetChaySau.Checked
              , NhanKQQuaTuNoi()
              , false, -1, (int)nuGioHanGioKQLoi.Value, true);

            if (dtAnalyzerResult.Rows.Count > 0)
            {
                var dtSid = dtAnalyzerResult.DefaultView.ToTable(true, new string[] { "sid", "NgayXN" });
                _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResult, _iResultConvert.Data_DM_XetNghiem_BienDichKetQua(-1, string.Empty, -1)
                    , progressBarKetQuaMayTuDong, systemConfig.ClsXetNghiemDinhDangKetqua, loginInfo.LoginName, PCWorkPlace
                    , systemConfig.ClsXetNghiemKieuLayKetQuaMay, true);
            }
        }

        private void FrmAnalyerResult_Load(object sender, EventArgs e)
        {
            var callAuto = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_AutoRestart) == "1";
            var autoLoginName = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_UserBeforeRestart);
            ErrorHandler.RecordError("Auto update Analyzer result", "AutoUpdate_AnalyzerResult", null, 0, string.Format("Kiểm tra khởi động: Auto restart: {0} - User Login Before Restart: {1} ", callAuto, autoLoginName), "CapNhat_TuDong_ChapNhan");
            var f = new FrmLogIn();
            if (callAuto && !string.IsNullOrEmpty(autoLoginName))
            {
                f.txtUserID.Text = autoLoginName;
                f.callFromAuto = true;
                f.CheckAndLogIn();
                chkUploadWhenStart.Checked = true;
            }
            else
                f.ShowDialog();

            if (f.userLogInInfo != null)
            {
                loginInfo = f.userLogInInfo;
            }
            else
            {
                MessageBox.Show("Tài khoản đăng nhập không hợp lệ!");
                Application.Exit();
            }
            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_AutoRestart, "0");
            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_UserBeforeRestart, string.Empty);
            Get_LocalSetting();
            Get_SystemConfig();
            SetDungGioPhut();
            Load_MayXetNghiem();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void Start()
        {
            lblTrangThai.Text = "Đang chạy lấy kết quả tự động....";
            if (!timerResetUpload.Enabled)
            {
                timerResetUpload.Enabled = true;
                timerResetUpload.Start();
            }
            timerCount.Interval = (int)numTgUpload.Value * 1000;
            timerCount.Enabled = true;
            timerCount.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            pnDieuKienCapNhat.Enabled = false;
            gbDanhSachMayXN.Enabled = false;
            isPause = false;
            countToPause = 0;
            countToResume = 0;
            SaveLocalSetting();
        }
        private void timerCount_Tick(object sender, EventArgs e)
        {
            timerCount.Stop();
            timerCount.Enabled = false;

            CapNhat_TuDong_ChapNhan();
            lblTrangThai.Text = "Chờ cho lần cập nhật tiếp theo.";
            timerCount.Enabled = true;
            timerCount.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
        private void Stop()
        {
            timerResetUpload.Stop();
            timerResetUpload.Enabled = false;
            timerCount.Stop();
            timerCount.Enabled = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblTrangThai.Text = "Đang dừng.....";
            pnDieuKienCapNhat.Enabled = true;
            gbDanhSachMayXN.Enabled = true;
            countToPause = 0;
            countToResume = 0;
        }
        bool isPause = false;
        private void Pause()
        {
            timerCount.Stop();
            timerCount.Enabled = false;
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            lblTrangThai.Text = "Đang tạm ngưng.....";
            pnDieuKienCapNhat.Enabled = false;
            gbDanhSachMayXN.Enabled = false;
            countToResume = 0;
            isPause = true;
        }

        private void timerResetUpload_Tick(object sender, EventArgs e)
        {
            if (btnStart.Enabled == false && !isPause)
            {
                countToPause++;

                if (countToPause == (nuTimeToPause.Value * 60))
                {
                    Pause();
                    countToPause = 0;
                    countToResume = 0;
                }
            }
            else if (isPause)
            {
                countToResume++;
                if (countToResume == (nuTimeToResume.Value * 60))
                {
                    _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_AutoRestart, "1");
                    _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_UserBeforeRestart, loginInfo.LoginName);
                    Stop();

                    Application.Restart();
                    countToResume = 0;
                }
            }
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartWithWindows.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("TPHAnalyzer", Application.ExecutablePath);

                _registryExtension.WriteRegistry(UserConstant.RegistryLoginUsernameKQMay, loginInfo.LoginName);
                _registryExtension.WriteRegistry(UserConstant.RegistryUserPasswordKQMay, loginInfo.Password);

            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("TPHAnalyzer", false);
                _registryExtension.WriteRegistry(UserConstant.RegistryLoginUsernameKQMay, string.Empty);
                _registryExtension.WriteRegistry(UserConstant.RegistryUserPasswordKQMay, string.Empty);
            }
        }

        private void chkMinisizeWihenStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
        TPHAnalyzerCommon.TPHAnalyzer_MinimumsizeAutoStart,
        chkMinisizeWihenStartWithWindows.Checked ? "1" : "0");
        }

        private void chkUploadWhenStart_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_StartUploadWhenStart, chkUploadWhenStart.Checked ? "1" : "0");
        }

        private void FrmAnalyerResult_Shown(object sender, EventArgs e)
        {
            if (chkUploadWhenStart.Checked)
                Start();

            if (chkMinisizeWihenStartWithWindows.Checked && chkStartWithWindows.Checked)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void FrmAnalyerResult_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && (timerUpload.Enabled || timerResetUpload.Enabled))
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void FrmAnalyerResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStart.Enabled == false)
            {
                MessageBox.Show("Ứng dụng đang chạy!");
                e.Cancel = true;
            }
        }
    }
}
