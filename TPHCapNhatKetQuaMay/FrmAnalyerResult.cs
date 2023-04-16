using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.ResultConvert.Service;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Models;
using TPH.WriteLog;

namespace TPHCapNhatKetQuaMay
{
    public partial class FrmAnalyerResult : Form
    {
        private int borderSize = 2;
        private Size formSize;
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, "SOFTWARE\\TPH.TPHLIS\\Properties\\");

        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IResultConvertService _iResultConvert = new ResultConvertService();
        private readonly string _fileName = "AutoUpdate_AnalyzerResult";
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
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.DarkGray;//Border color
        }
        private void Get_SystemConfig()
        {
            chkStartWithWindows.Checked = rkApp.GetValue("TPHAnalyzer") != null;

            chkMinisizeWihenStartWithWindows.Checked = _registryExtension.ReadRegistry("TPHAnalyzer_MinimumsizeAutoStart").Equals("1");
            chkUploadWhenStart.Checked = _registryExtension.ReadRegistry("TPHAnalyzer_StartUploadWhenStart").Equals("1");

            systemConfig = _systemConfigService.GetSystemConfigurationDetail();
            var arrComputerAllow = (systemConfig.ClsXetNghiemMayDungToolKetQua ?? string.Empty).Split('|');
            if (!systemConfig.ClsXetNghiemFormKQMayTuDong && (arrComputerAllow.Where(x=> x.Trim().Equals(Environment.MachineName, StringComparison.OrdinalIgnoreCase)).Any())) return;
            MessageBox.Show("Máy tính chưa khai báo dùng tool lấy kết quả.");
            Application.Exit();
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
            chkDeKetQuaChuaDuyet.Checked = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_OverWriteInvalidResult) == "1";
            chkCapNhat_KetQuaLoi.Checked = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_GetErrorResults) == "1";
            chkDanhSachMayKhaiBaoTheoPC.Checked = _registryExtension.ReadRegistry(TPHAnalyzerCommon.TPHAnalyzer_AnalyzerWithPCConfig) == "1";
            chkDanhSachMayKhaiBaoTheoPC.CheckedChanged += ChkDanhSachMayKhaiBaoTheoPC_CheckedChanged;
        }

        private void ChkDanhSachMayKhaiBaoTheoPC_CheckedChanged(object sender, EventArgs e)
        {
            Load_MayXetNghiem();
        }

        private void SaveLocalSetting()
        {
            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_ScanWait, numTgUpload.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_DayScan, numSoNgayCapNhat.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_HourToGetErrorResult, nuGioHanGioKQLoi.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_StopRunAfter, nuTimeToPause.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_StartAfterAutoStop, nuTimeToResume.Value.ToString());

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_OverWriteInvalidResult, chkDeKetQuaChuaDuyet.Checked ? "1" : "0");

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_AnalyzerWithPCConfig, chkDanhSachMayKhaiBaoTheoPC.Checked ? "1" : "0");

            _registryExtension.WriteRegistry(TPHAnalyzerCommon.TPHAnalyzer_GetErrorResults, chkCapNhat_KetQuaLoi.Checked ? "1" : "0");

        }
        private void SetDungGioPhut()
        {
            dtpFromDate.Value = new DateTime(dtpFromDate.Value.Year, dtpFromDate.Value.Month, dtpFromDate.Value.Day, 0, 0, 0);
            dtpToDate.Value = new DateTime(dtpToDate.Value.Year, dtpToDate.Value.Month, dtpToDate.Value.Day, 23, 59, 59);
            LogService.RecordLogFile(_fileName,
                $"Thời gian cập nhật kết quả: Từ ngày {dtpFromDate.Value:yyyy/MM/dd} đến ngày {dtpToDate.Value:yyyy/MM/dd}");
        }
        private int[] NhanKQQuaTuNoi()
        {
            var arrget = new int[1];
            switch (systemConfig.ClsXetNghiemKieuLayKetQuaMay)
            {
                case EnumKieuLayKetQuaMay.TatCa:
                    return new int[] { CommonConstant.TrangThaiKqMayTuMayKhac, CommonConstant.TrangThaiKqMayNhanTuMiddleware };
                case EnumKieuLayKetQuaMay.ChiTuPhanMemTrungGian:
                    return new int[] { CommonConstant.TrangThaiKqMayNhanTuMiddleware };
                default:
                    return new int[] { CommonConstant.TrangThaiKqMayTuMayKhac };
            }
        }
        private void Load_MayXetNghiem()
        {
            var allowanalyzerTemp = (PhanQuyenMayXetNghiem == null ? string.Empty : Utilities.ArrayToSqlValue(PhanQuyenMayXetNghiem));
            var allowanalyzer = string.Empty;

            if (!string.IsNullOrEmpty(allowanalyzerTemp))
            {
                if (chkDanhSachMayKhaiBaoTheoPC.Checked)
                {
                    var dataAnalyxerConfigPC = WorkingServices.ConvertColumnNameToLower_Upper(_iAnalyzerConfig.Data_dm_maytinh_mayxetnghiem(PCWorkPlace, Environment.MachineName, null), true);
                    if (dataAnalyxerConfigPC != null)
                    {
                        if (dataAnalyxerConfigPC.Rows.Count > 0)
                        {
                            foreach (var idMay in allowanalyzerTemp)
                            {
                                bool isExists = false;
                                foreach (DataRow dr in dataAnalyxerConfigPC.Rows)
                                {
                                    var idmayConfigPc = dr["IdMayXetNghiem"].ToString();
                                    if (idmayConfigPc.Equals(idMay))
                                    {
                                        isExists = true;
                                        break;
                                    }
                                }
                                if (isExists)
                                    allowanalyzer += string.Format("'{0}',", idMay);
                            }
                        }
                    }
                }
                else
                    allowanalyzer = allowanalyzerTemp;
            }
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
            LogService.RecordLogFile(_fileName, "Call method CapNhat_TuDong_ChapNhan()");
            try
            {
                lblTrangThai.Text = "Đang cập nhật kết quả máy!\nTrạng thái: Chấp nhận";
                LogService.RecordLogFile(_fileName, lblTrangThai.Text);
                lblTrangThai.Refresh();
                //Lấy kết quả.
                //Ưu tiên cập nhật kết quả đã chấp nhận trước.
                LogService.RecordLogFile(_fileName, "Call method _iAnalyzerResult.Data_Analyzer_Result(...)");

                var dtAnalyzerResult = _iAnalyzerResult.Data_Analyzer_Result(dtpFromDate.Value.Date, dtpToDate.Value, ""
                    , string.Format("{0}", TestingResultStatusConstant.ChapNhan)
                    , string.Empty, null, null
                    , loginInfo.IsAdmin ? null : loginInfo.LoginName
                    , chkCapNhat_KetChaySau.Checked
                    , NhanKQQuaTuNoi(), false, -1, -1, true);



                LogService.RecordLogFile(_fileName, $"Có {dtAnalyzerResult.Rows.Count} kết quả để cập nhật");

                if (dtAnalyzerResult.Rows.Count > 0)
                {
                    //var dtSid = dtAnalyzerResult.DefaultView.ToTable(true, new string[] { "sid", "NgayXN" });
                    LogService.RecordLogFile(_fileName, "Call method _iAnalyzerResult.UpdateCLSResultFromDatatable(...)");
                    var iCount = 0;
                    _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResult, _systemConfigService.Data_dm_xetnghiem_biendichketqua(null)
                        , progressBarKetQuaMayTuDong,null, ref iCount, systemConfig.ClsXetNghiemDinhDangKetqua, loginInfo.LoginName
                        , PCWorkPlace, systemConfig.ClsXetNghiemKieuLayKetQuaMay, true, chkDeKetQuaChuaDuyet.Checked, chkCapNhat_KetChaySau.Checked, false, false);
                }

                if (!chkCapNhat_KetQuaLoi.Checked) return;
                lblTrangThai.Text = "Đang cập nhật kết quả máy!\nTrạng thái: Chưa nhập SID \nhoặc Chưa nhập Xét nghiệm";
                LogService.RecordLogFile(_fileName, lblTrangThai.Text);
                lblTrangThai.Refresh();
                CapNhatTuDongLoi();
            }
            catch (Exception ex)
            {
                Stop();
                LogService.RecordLogError("Auto update Analyzer result", _fileName, ex, 0, ex.Message, "CapNhat_TuDong_ChapNhan");
                Start();
            }
        }
        private List<string> lstIdMay = new List<string>();
        private void CapNhatTuDongLoi()
        {
            LogService.RecordLogFile(_fileName, "Call method CapNhatTuDongLoi()");
            LogService.RecordLogFile(_fileName, "Call method _iAnalyzerResult.Data_Analyzer_Result(...)");

            var dtAnalyzerResult = _iAnalyzerResult.Data_Analyzer_Result(dtpFromDate.Value, dtpToDate.Value, string.Empty,
                string.Format("{0},{1}", TestingResultStatusConstant.ChuaNhapThongTin, TestingResultStatusConstant.ChuaNhapChiDinh)
                , string.Join(",", lstIdMay.ToArray()),null, null
                , loginInfo.IsAdmin ? null : loginInfo.LoginName
                , chkCapNhat_KetChaySau.Checked
                , NhanKQQuaTuNoi()
                , false, -1, (int)nuGioHanGioKQLoi.Value, true);

            if (dtAnalyzerResult.Rows.Count <= 0) return;
            //var dtSid = dtAnalyzerResult.DefaultView.ToTable(true, new string[] { "sid", "NgayXN" });
            LogService.RecordLogFile(_fileName, "Call method _iAnalyzerResult.UpdateCLSResultFromDatatable(...)");
            var iCount = 0;
            _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResult, _systemConfigService.Data_dm_xetnghiem_biendichketqua(null)
                , progressBarKetQuaMayTuDong, null, ref iCount, systemConfig.ClsXetNghiemDinhDangKetqua, loginInfo.LoginName, PCWorkPlace
                , systemConfig.ClsXetNghiemKieuLayKetQuaMay, true, chkDeKetQuaChuaDuyet.Checked, chkCapNhat_KetChaySau.Checked, false, false);
        }
        private List<string> GetIDMayXn()
        {
            if (chkAllAnalyzer.Checked)
            {
                return chkMayXetNghiem.AllItemList2("IDMay");
            }
            else
                return chkMayXetNghiem.ItemCheckedList("IDMay");
        }
        private void FrmAnalyerResult_Load(object sender, EventArgs e)
        {
            var f = new FrmLogIn();
            f.ShowDialog();
            if (f.userLogInInfo != null)
            {
                loginInfo = f.userLogInInfo;
            }
            Get_LocalSetting();
            Get_SystemConfig();
            SetDungGioPhut();
            Load_MayXetNghiem();
            timer1.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LogService.RecordLogFile(_fileName, "Click THỰC HIỆN");
            Start();
        }
        void WriteOptionWhenStart()
        {
            var msg = new StringBuilder();
            msg.AppendFormat("Các lựa chọn cập nhật kết quả{0}", Environment.NewLine);
            msg.AppendFormat("_________________________________________________________{0}", Environment.NewLine);
            msg.AppendFormat("{0}: [{1:yyyy/MM/dd}] {2}: [{3:yyyy/MM/dd}]{4}", label13.Text, dtpFromDate.Value,
                label15.Text, dtpToDate.Value,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}", label5.Text, chkCapNhat_KetQuaLoi.Checked,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}", label6.Text, chkCapNhat_KetChaySau.Checked,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",lbl3.Text, numTgUpload.Value,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",lbl4.Text, numSoNgayCapNhat.Value,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",lbl5.Text, nuGioHanGioKQLoi.Value,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",lbl6.Text, nuTimeToPause.Value,
                Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",lbl7.Text, nuTimeToResume.Value, Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",chkStartWithWindows.Text, chkStartWithWindows.Checked, Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",chkMinisizeWihenStartWithWindows.Text, chkMinisizeWihenStartWithWindows.Checked, Environment.NewLine);
            msg.AppendFormat("{0}: [{1}]{2}",chkUploadWhenStart.Text, chkUploadWhenStart.Checked, Environment.NewLine);
            msg.AppendFormat("_________________________________________________________");
            LogService.RecordLogFile(_fileName, msg.ToString());
        }
        private void Start()
        {
            LogService.RecordLogFile(_fileName, "Call method Start()");

            WriteOptionWhenStart();

            lblTrangThai.Text = "Đang chạy lấy kết quả tự động....";
            LogService.RecordLogFile(_fileName, lblTrangThai.Text);

            if (!timerResetUpload.Enabled)
            {
                SaveLocalSetting();
                lstIdMay = GetIDMayXn();
                timerResetUpload.Start();
                LogService.RecordLogFile(_fileName, "timerResetUpload is start");
            }
            timerCount.Interval = (int)numTgUpload.Value * 1000;
            LogService.RecordLogFile(_fileName, $"timerCount = {timerCount.Interval}");
            timerCount.Start();
            LogService.RecordLogFile(_fileName, "timerCount is start");
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            pnDieuKienCapNhat.Enabled = false;
            gbDanhSachMayXN.Enabled = false;
            isPause = false;
            countToPause = 0;
            countToResume = 0;
            LogService.RecordLogFile(_fileName, "countToPause = 0; countToResume = 0");
        }
        private void timerCount_Tick(object sender, EventArgs e)
        {
            timerCount.Stop();
            try
            {
                CapNhat_TuDong_ChapNhan();
                lblTrangThai.Text = "Chờ cho lần cập nhật tiếp theo.";
                LogService.RecordLogFile(_fileName, lblTrangThai.Text);
            }
            catch (Exception ex)
            {
                LogService.RecordLogError("Auto update Analyzer result", _fileName, ex, 0, ex.Message, "timerCount_Tick");
            }
            finally
            {
                timerCount.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            LogService.RecordLogFile(_fileName, "Click DỪNG");
            Stop();
        }
        private void Stop()
        {
            LogService.RecordLogFile(_fileName, "Call method Stop()");

            timerResetUpload.Stop();

            LogService.RecordLogFile(_fileName, "timerResetUpload is stop");

            timerCount.Stop();
            LogService.RecordLogFile(_fileName, "timerCount is stop");

            btnStart.Enabled = true;
            btnStop.Enabled = false;

            lblTrangThai.Text = "Đang dừng.....";
            LogService.RecordLogFile(_fileName, lblTrangThai.Text);
            pnDieuKienCapNhat.Enabled = true;
            gbDanhSachMayXN.Enabled = true;
            countToPause = 0;
            countToResume = 0;
            LogService.RecordLogFile(_fileName, "countToPause = 0; countToResume = 0");
        }
        bool isPause = false;
        private void Pause()
        {
            LogService.RecordLogFile(_fileName, "Call method Pause()");
            timerCount.Stop();
            LogService.RecordLogFile(_fileName, "timerCount is stop");

            btnStart.Enabled = false;
            btnStop.Enabled = false;
            lblTrangThai.Text = "Đang tạm ngưng.....";
            LogService.RecordLogFile(_fileName, lblTrangThai.Text);
            pnDieuKienCapNhat.Enabled = false;
            gbDanhSachMayXN.Enabled = false;
            countToResume = 0;
            LogService.RecordLogFile(_fileName, "countToResume = 0");
            isPause = true;
        }

        private void timerResetUpload_Tick(object sender, EventArgs e)
        {
            if (!btnStart.Enabled && !isPause)
            {
                countToPause++;
                LogService.RecordLogFile(_fileName, $"countToPause = {countToPause}");

                if (countToPause != (nuTimeToPause.Value * 60)) return;
                Pause();
                countToPause = 0;
                countToResume = 0;
                LogService.RecordLogFile(_fileName, "countToPause = 0, countToResume = 0");
            }
            else if (isPause)
            {
                countToResume++;
                LogService.RecordLogFile(_fileName, $"countToResume = {countToResume}");
                if (countToResume != (nuTimeToResume.Value * 60)) return;
                Start();
                countToResume = 0;
                LogService.RecordLogFile(_fileName, "countToResume = 0");
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
        "TPHAnalyzer_MinimumsizeAutoStart",
        chkMinisizeWihenStartWithWindows.Checked ? "1" : "0");
        }

        private void chkUploadWhenStart_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry("TPHAnalyzer_StartUploadWhenStart", chkUploadWhenStart.Checked ? "1" : "0");
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
            if (FormWindowState.Minimized == this.WindowState &&  timerResetUpload.Enabled)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void FrmAnalyerResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnStart.Enabled != false) return;
            MessageBox.Show("Ứng dụng đang chạy!");
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            if (dtpToDate.Value.Date == DateTime.Now.Date) return;
            LogService.RecordLogFile(_fileName, "Qua ngày mới >>> thực hiện reset lại ngày");

            dtpToDate.Value = DateTime.Now;
            dtpFromDate.Value = dtpToDate.Value.AddDays(-((int) numSoNgayCapNhat.Value - 1));
            SetDungGioPhut();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Global variables;
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
