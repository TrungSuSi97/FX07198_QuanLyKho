using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.Data.HIS.HISDataCommon;
using TPH.Data.HIS.Models;
using TPH.Lab.BusinessService.Models;
using TPH.Lab.BusinessService.Services;
using TPH.Lab.Middleware.LISConnect.DataAccesses;
using TPH.Lab.Middleware.LISConnect.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Constants;
using TPH.LIS.TestResult.Services;
using TPH.WriteLog;

namespace UploadKetQua_HIS
{
    public partial class frmUploadKEtQua : Form
    {
        private int borderSize = 2;
        private Size formSize;
        public frmUploadKEtQua()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.DarkGray;//Border color
        }
        private readonly IConnectHISService _iHISData = new ConnectHISService();
        IConnectHISDataAccess _iHisConfig;
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();

        private List<HISDataColumnNames> hisDataClumnsList;
        private List<HisFunctionConfig> hisFunctionConfigList;
        private List<HisConnection> hisConnectList;
        private ConfigurationDetail systemConfig;
        private DieuKienInTuDong _dieuKienIn = new DieuKienInTuDong();
        private readonly ITestResultService _iResultService = new TestResultService();
        private HisProvider currentHIS = HisProvider.Vimes;
        private HisFunctionID objHisFunctionID = new HisFunctionID();
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, "SOFTWARE\\TPH.TPHLIS\\Properties\\");
        bool uploading = false;
        int countToUpload = 0;
        int limitCount = 0;
        string logname = "Error_Upload_";
        string runningText = "RUNNING";
        string startText = "START";
        bool runningADT = false;
        public int runnningCount = 0;
        List<Task> lstTask = new List<Task>();
        string TaskOrThread = "Task";

        private List<HisConnection> HisConnectList
        {
            get
            {
                if (hisConnectList == null)
                {
                    if (_iHisConfig == null)
                        _iHisConfig = new ConnectHISDataAccess();
                    hisConnectList = _iHisConfig.DataHisThongTin();
                }
                return hisConnectList;
            }
            set
            {
                hisConnectList = value;
            }
        }
        private List<HisFunctionConfig> HisFunctionConfigList
        {
            get
            {
                if (hisFunctionConfigList == null)
                {
                    if (_iHisConfig == null)
                        _iHisConfig = new ConnectHISDataAccess();
                    hisFunctionConfigList = _iHisConfig.DataHisThongTinHam();
                }
                return hisFunctionConfigList;
            }
            set
            {
                hisFunctionConfigList = value;
            }
        }
        private List<HISDataColumnNames> HisDataColumnsList
        {
            get
            {
                if (hisDataClumnsList == null)
                {
                    if (_iHisConfig == null)
                        _iHisConfig = new ConnectHISDataAccess();
                    hisDataClumnsList = _iHisConfig.DataHisThongTinMappingCot();
                }
                return hisDataClumnsList;
            }
            set
            {
                hisDataClumnsList = value;
            }
        }
        private List<PatientCheckLIS> lstUploadedList = new List<PatientCheckLIS>();
        private void CountDSloaiTruUpload()
        {
            if (lblDanhSachLoaiTruUpload.InvokeRequired)
            {
                lblGreneralStatus.Invoke((Action)(() =>
                {
                    lblDanhSachLoaiTruUpload.Text = string.Format("Đã hoàn thành (Đếm trong 30s) : {0}", lstUploadedList.Count());
                }));
            }
            else
                lblDanhSachLoaiTruUpload.Text = string.Format("Đã hoàn thành (Đếm trong 30s): {0}", lstUploadedList.Count());
        }
        private void RemoveUploadedList()
        {
            if (lstUploadedList.Count > 0)
            {
                var dateCheck = DateTime.Now.AddSeconds(-30);
                lstUploadedList.RemoveAll(x => x.LastUpdateTime <= dateCheck);
            }
            CountDSloaiTruUpload();
        }
        private void AddUploadedList(string maTiepNhan)
        {
            lstUploadedList.Add(new PatientCheckLIS { LisCode = maTiepNhan, LastUpdateTime = DateTime.Now });
            CountDSloaiTruUpload();
        }
        private bool CheckExistsUploadedList(string matiepNhan)
        {
            return lstUploadedList.Where(x => x.LisCode.Equals(matiepNhan)).Any();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Check_StartStop();
        }
        private void Check_StartStop()
        {
            limitCount = 0;
            if (timerUpload.Enabled)
            {
                btnStart.Text = startText;
                btnStart.ForeColor = Color.Blue;
                numTgUpload.Enabled = true;
                btnStart.BackColor = SystemColors.Control;
                radGiamDan.Enabled = true;
                radTangDan.Enabled = true;

                timerUpload.Stop();
                timerUpload.Enabled = false;
                uploading = false;
                countToUpload = 0;

            }
            else
            {
                lstUploadedList = new List<PatientCheckLIS>();
                SaveLocalSetting();
                uploading = false;
                countToUpload = 0;

                timerUpload.Interval = 1000;
                btnStart.Text = runningText;
                btnStart.ForeColor = Color.Red;
                timerUpload.Enabled = true;
                timerUpload.Start();
                numTgUpload.Enabled = false;
                radGiamDan.Enabled = false;
                radTangDan.Enabled = false;
            }
        }
        List<string> lstDanhSachVuaTraChoTask = new List<string>();
        private void ScanDanhSachUpload()
        {
            try
            {
                SetUploadStatus("Load danh sách trả kết quả về HIS");
                RemoveUploadedList();
                var dataList = _iHISData.DataUploadToHisList(string.Empty, systemConfig.ClsXetNghiemUploadDaDuyet, systemConfig.ClsXetNghiemUploadDaIn);
                if (dataList != null)
                {
                    if (dataList.Rows.Count > 0)
                    {
                        dataList.DefaultView.Sort = string.Format("ThoiGianNhap {0}", (radTangDan.Checked ? "asc" : "desc"));
                        dataList = dataList.DefaultView.ToTable();
                        int rowsCount = dataList.Rows.Count;
                        int currentRows = 0;
                        foreach (DataRow drP in dataList.Rows)
                        {
                            var matiepNhan = drP["MaTiepNhan"].ToString();
                            currentRows++;

                            SetUploadStatus(string.Format("Load chi tiết upload của bệnh nhân:{0}/{1}\nMã tiếp nhận: {2}", currentRows, rowsCount, matiepNhan));

                            var bnInfo = _iHISData.GetDataUploadToHIS(new GetUploadCondit
                            {
                                userID = "Uploader",
                                matiepnhan = matiepNhan,
                                onlyValid = systemConfig.ClsXetNghiemUploadDaDuyet,
                                onlyPrinted = systemConfig.ClsXetNghiemUploadDaIn,
                                arrCatePrint = null,
                                arrtestCodePrint = null,
                                arrTestTypeID = new string[] { },
                                frombackup = false,
                                manualUpload = true,
                                forStatus = false
                            });
                            if (bnInfo != null)
                            {
                                if (bnInfo.ChiDinh.Count > 0)
                                {
                                    lstDanhSachVuaTraChoTask.Add(bnInfo.Matiepnhan);
                                    if (chkDaLuong.Checked)
                                        StartUploadTask(bnInfo);
                                    else
                                        Transfer(bnInfo);
                                }
                            }
                        }
                    }
                }
                SetUploadStatus("Upload file về HIS");
                var data = _iHISData.DataUploadFileList();
                if (data.Rows.Count > 0)
                {
                    var distinctData = data.DefaultView.ToTable(true, "Matiepnhan", "HisProviderId");
                    foreach (DataRow drF in distinctData.Rows)
                    {
                        var bnInfo = new BenhNhanInfoForHIS();
                        bnInfo.Hisproviderid = int.Parse(drF["HisProviderId"].ToString());
                        var hisReturn = (HisProvider)Enum.Parse(typeof(HisProvider), bnInfo.Hisproviderid.ToString());
                        if (HisFunctionConfigList != null)
                        {
                            var functionFileHIS = HisFunctionConfigList.Where(x => x.HisID.Equals(hisReturn));
                            if (functionFileHIS != null)
                            {
                                if (functionFileHIS.Any())
                                {
                                    var functionFile = functionFileHIS.Where(x => (x.FunctionID ?? string.Empty).Equals(objHisFunctionID.PhieuTraKetQuaXetNghiem));
                                    if (functionFile != null)
                                    {
                                        if (functionFile.Any())
                                        {
                                            if (!string.IsNullOrEmpty(functionFile.FirstOrDefault().FunctionName))
                                            {
                                                System.Threading.Thread.Sleep(150);
                                                bnInfo.Matiepnhan = drF["Matiepnhan"].ToString();
                                                TransferFileResult(bnInfo);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                SetUploadStatus("Chờ cho lần upload tiếp theo.");
            }
            catch (Exception ex)
            {
                LogService.RecordLogError("Auto Upload HIS", "HISUploader", ex, 0, ex.Message, "ScanDanhSachUpload");
            }
        }
        private void TransferFileResult(BenhNhanInfoForHIS info)
        {
            try
            {
                lblGreneralStatus.Invoke((Action)(() =>
                {
                    lblTskStatus.Text = string.Format("{0} đang chạy: {1} - {2}", TaskOrThread, lstDanhSachVuaTraChoTask.Count, info.Matiepnhan);
                }));
                var hisReturn = (HisProvider)Enum.Parse(typeof(HisProvider), info.Hisproviderid.ToString());
                var hisInfo = HisConnectList.Where(x => x.HisID.Equals(hisReturn)).FirstOrDefault();

                LogService.RecordLogFile("HISUploader", string.Format("HISProvider: {0}-{1}\nMã tiếp nhận: {2}"
                    , hisReturn, hisReturn.ToString(), info.Matiepnhan), "Auto upload file to HIS: Transfer");
                _iHISData.UploadFileToHis(hisInfo, HisFunctionConfigList, info, true);
                AddUploadedList(info.Matiepnhan);
                RemoveFinishList(info.Matiepnhan);

            }
            catch (Exception ex)
            {
                AddUploadedList(info.Matiepnhan);
                RemoveFinishList(info.Matiepnhan);
                LogService.RecordLogError("HISUploader", logname, ex, 0, ex.Message, "Auto upload to HIS: Transfer");
            }
        }
        private void RemoveFinishList(string maTiepNhan)
        {
            ActionRemoveFinishList(maTiepNhan);
            lblGreneralStatus.Invoke((Action)(() =>
            {
                lblTskStatus.Text = string.Format("{0} đang chạy: {1}", TaskOrThread, lstDanhSachVuaTraChoTask.Count);
            }));
        }
        public void ActionRemoveFinishList(string maTiepNhan)
        {
            int index = lstDanhSachVuaTraChoTask.IndexOf(maTiepNhan);
            if (index > -1)
            {
                lstDanhSachVuaTraChoTask.RemoveAt(index);
                ActionRemoveFinishList(maTiepNhan);
            }
        }
        private void SetUploadStatus(string mess)
        {
            if (lblGreneralStatus.InvokeRequired)
            {
                lblGreneralStatus.Invoke((Action)(() =>
                {
                    lblGreneralStatus.Text = mess;
                }));
            }
            else
                lblGreneralStatus.Text = mess;
        }
        private void StartUploadTask(BenhNhanInfoForHIS bnInfo)
        {
            Task.Factory.StartNew(delegate { Transfer(bnInfo); });
        }
        private void Transfer(BenhNhanInfoForHIS info)
        {
            try
            {
                lblGreneralStatus.Invoke((Action)(() =>
                {
                    lblTskStatus.Text = string.Format("{0} đang chạy: {1}", TaskOrThread, lstDanhSachVuaTraChoTask.Count);
                }));
                var hisReturn = (HisProvider)Enum.Parse(typeof(HisProvider), info.Hisproviderid.ToString());
                var hisInfo = HisConnectList.Where(x => x.HisID.Equals(hisReturn)).FirstOrDefault();
                LogService.RecordLogFile("HISUploader", string.Format("HISProvider: {0}-{1}\nMã tiếp nhận: {2}"
                    , hisReturn, hisReturn.ToString(), info.Matiepnhan), "Auto upload to HIS: Transfer");
                _iHISData.LISTransferResult(hisInfo, HisFunctionConfigList, info);
                AddUploadedList(info.Matiepnhan);
                RemoveFinishList(info.Matiepnhan);
            }
            catch (Exception ex)
            {
                AddUploadedList(info.Matiepnhan);
                RemoveFinishList(info.Matiepnhan);
                LogService.RecordLogError("HISUploader", logname, ex, 0, ex.Message, "Auto upload to HIS: Transfer");
            }
        }

        private void timerUpload_Tick(object sender, EventArgs e)
        {
            btnStart.BackColor = (btnStart.BackColor == SystemColors.Control ? Color.Yellow : SystemColors.Control);
            var currentTime = DateTime.Now.TimeOfDay;

            bool allow = true;
            if (allow)
            {
                if (!uploading && countToUpload >= numTgUpload.Value)
                {
                    uploading = true;
                    countToUpload = 0;
                    ScanDanhSachUpload();
                    uploading = false;
                    countToUpload = 0;
                }
                else if (!uploading)
                {
                    countToUpload++;
                    lblStatusCount.Text = string.Format("Chờ cho lần upload tiếp theo: {0}s", numTgUpload.Value - countToUpload);
                }
            }
        }
        DateTime lastDeleteDate = DateTime.Now;
        private void Check_ChangeDate()
        {
            if (dtpGetADTTodate.Value.Date < DateTime.Now.Date)
            {
                dtpGetADTTodate.Value = DateTime.Now.Date;
                dtpGetADTFromDate.Value = DateTime.Now.Date.AddDays(-double.Parse(numGetADTDays.Value.ToString()));
            }

            if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 0 && lastDeleteDate != DateTime.Now.Date)
            {
                if (runnningCount == 1)
                {
                    lastDeleteDate = DateTime.Now;
                    DeleteLog();
                }
                else
                    txtXoaLogMess.Text = "Không tự xóa log do tool ở thứ tự > 1";
            }
        }
        private void DeleteLog()
        {
            if (!string.IsNullOrEmpty(txtLogFolder.Text))
                WorkingServices.EmptyFolderContents(txtLogFolder.Text, (int)numNgayXoaLog.Value, txtXoaLogMess);
            //LogService.DeleLogFile(logname, 15);
            //LogService.DeleLogFile("TPH.Lab.Middleware", 15);
        }

        private void frmUploadKEtQua_Load(object sender, EventArgs e)
        {
            Get_LocalSetting();
            DeleteLog();
            systemConfig = _systemConfigService.GetSystemConfigurationDetail();
            var arrComputerAllow = (systemConfig.ClsXetNghiemMayDungToolUpload ?? string.Empty).Split('|');
            if (!arrComputerAllow.Where(x => x.Trim().Equals(Environment.MachineName, StringComparison.OrdinalIgnoreCase)).Any())
            {
                MessageBox.Show("Máy tính chưa khai báo dùng tool uplaod kết quả về HIS.");
                Application.Exit();
            }
            else
            {
                if (rkApp.GetValue(TPHUploadHISCommon.TPHUploadHIS_StartWithWindows) == null)
                {
                    // The value doesn't exist, the application is not set to run at startup
                    chkStartWithWindows.Checked = false;
                }
                else
                {
                    // The value exists, the application is set to run at startup
                    chkStartWithWindows.Checked = true;
                }

                chkMinisizeWihenStartWithWindows.Checked = _registryExtension.ReadRegistry(TPHUploadHISCommon.TPHUploadHIS_MinimumsizeAutoStart).Equals("1");
                chkUploadWhenStart.Checked = _registryExtension.ReadRegistry(TPHUploadHISCommon.TPHUploadHIS_StartUploadWhenStart).Equals("1");
                chkDaLuong.Checked = _registryExtension.ReadRegistry(TPHUploadHISCommon.TPHUploadHIS_UploadWithMultiThread).Equals("1");
            }
        }
        private void chkDaLuong_CheckedChanged(object sender, EventArgs e)
        {
            TaskOrThread = (chkDaLuong.Checked ? "Task" : "Process");
            _registryExtension.WriteRegistry(TPHUploadHISCommon.TPHUploadHIS_UploadWithMultiThread, chkDaLuong.Checked ? "1" : "0");
        }
        private void Get_LocalSetting()
        {
            var tgUpload = _registryExtension.ReadRegistry(TPHUploadHISCommon.TPHUploadHIS_ScanWait);
            numTgUpload.Value = int.Parse(string.IsNullOrEmpty(tgUpload) ? "10" : tgUpload);
        }
        private void SaveLocalSetting()
        {
            _registryExtension.WriteRegistry(TPHUploadHISCommon.TPHUploadHIS_ScanWait, numTgUpload.Value.ToString());
        }
        private void frmUploadKEtQua_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerUpload.Enabled)
            {
                CustomMessageBox.MSG_Information_OK("Tiến trình upload kết quả về HIS đang chạy!");
                e.Cancel = true;
            }
            else if (runningADT)
            {
                CustomMessageBox.MSG_Information_OK("Tiến trình kiểm tra cập nhật thông tin đang chạy!");
                e.Cancel = true;
            }
        }

        private void frmUploadKEtQua_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && timerUpload.Enabled)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal; 
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }
        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartWithWindows.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue(TPHUploadHISCommon.TPHUploadHIS_StartWithWindows, Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue(TPHUploadHISCommon.TPHUploadHIS_StartWithWindows, false);
            }
        }

        private void chkMinisizeWihenStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
          TPHUploadHISCommon.TPHUploadHIS_MinimumsizeAutoStart,
          chkMinisizeWihenStartWithWindows.Checked ? "1" : "0");
        }

        private void frmUploadKEtQua_Shown(object sender, EventArgs e)
        {
            lblTitle.Text += string.Format(" - THỨ TỰ: {0}", runnningCount);
            this.Text += string.Format(" - THỨ TỰ: {0}", runnningCount);
            if (chkUploadWhenStart.Checked)
            {
                if (runnningCount == 1)
                {
                    this.Location = new Point(10, 10);
                    if (chkUploadWhenStart.Checked)
                        Check_StartStop();

                    if (chkMinisizeWihenStartWithWindows.Checked && chkStartWithWindows.Checked)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
                else if (runnningCount == 2)
                {
                    this.Location = new Point(30, 50);
                    tabControl1.SelectedIndex = 1;
                    numGetADTDays.Value = 1;
                    numGetADTInterval.Value = 10 * 60;
                    btnCapNhatThongTin_Click(btnGetADTStart, new EventArgs());
                }
            }
        }
        private void chkUploadWhenStart_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(TPHUploadHISCommon.TPHUploadHIS_StartUploadWhenStart, chkUploadWhenStart.Checked ? "1" : "0");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (lstDanhSachVuaTraChoTask.Count == 0)
                Application.Exit();
            else
                CustomMessageBox.MSG_Information_OK("Quá trình upload đang chạy.\nHãy chờ đến khi hoàn tất!");
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
        #region Cập nhật thông tin theo danh sách từ HIS
        HisProvider lastHisID = HisProvider.NONE;
        private bool callBreak = false;
        bool updating = false;
        public void SetDataPropertyNameForDatagriviewColumnNormal(HisConnection hisInfo, CustomDatagridView dtg)
        {
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn dgc = dtg.Columns[i];

                string[] arrColName = dgc.Name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (arrColName.Length > 2)
                {
                    if (dgc.Tag == null)
                        dgc.Tag = dgc.Visible;

                    var HisColumnsName = _iHISData.GetHisThongTinMappingCot(hisInfo, hisDataClumnsList);
                    //  HisColumnsName.chidinhTenkhoaphong
                    PropertyInfo[] fiCheck = HisColumnsName.GetType().GetProperties();
                    foreach (PropertyInfo f in fiCheck)
                    {
                        if (f.Name.Equals(arrColName[2], StringComparison.OrdinalIgnoreCase))
                        {
                            var obj = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null) == null ? string.Empty : HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null);
                            if (string.IsNullOrEmpty(obj.ToString()))
                            {
                                dgc.DataPropertyName = string.Empty;
                                dgc.Visible = false;
                            }
                            else
                            {
                                dgc.DataPropertyName = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null).ToString().ToLower();

                                dgc.Visible = (bool)dgc.Tag;
                            }
                            break;
                        }
                    }
                }
            }
        }
        private void SetThongTinHis(HisConnection hisInfo)
        {
            if (lastHisID != hisInfo.HisID)
            {
                lastHisID = hisInfo.HisID;
                SetDataPropertyNameForDatagriviewColumnNormal(hisInfo, dtgGetADT_HISInfo);
            }
        }
        List<HISMapping> lstMappingData = new List<HISMapping>();

        HISMapping mappingCheck = new HISMapping();
        bool firstRun = true;
        private void LoadDaSachNoiTuHIS()
        {
            var hisInfo = HisConnectList.Where(x => x.HisID.Equals(currentHIS)).FirstOrDefault();
            hisInfo.WriteLogToAPI = false;
            var hColumnNames = _iHISData.GetHisThongTinMappingCot(hisInfo, HisDataColumnsList);
            SetThongTinHis(hisInfo);

            var paraList = new HisParaGetList();
            paraList.TimTuNgayChiDinh = dtpGetADTFromDate.Value.Date;
            paraList.TimDenNgayChiDinh = dtpGetADTTodate.Value.Date;
            var hisReturnBase = _iHISData.GetPatientInformationDetail(hisInfo, HisFunctionConfigList, paraList);
            if (hisReturnBase.Data != null)
            {
                var data = hisReturnBase.Data;
                SetCheckADTStatus("Sắp xếp lại theo ngày nhập viện giảm dần.. ");
                data.DefaultView.Sort = string.Format("{0} desc", (string.IsNullOrEmpty(hColumnNames.chidinhNgaynhapvien) ? hColumnNames.chidinhNgayvaovien : hColumnNames.chidinhNgaynhapvien));
                data = data.DefaultView.ToTable();
                SetCheckADTStatus("Sắp xếp hoàn thành.. ");
                ControlExtension.BindDataToGrid(data, ref dtgGetADT_HISInfo, ref bvGetADTPatient);
                SetCheckADTStatus("Hoàn thành load danh sách. ");
            }
            lstMappingData = HISMappingService.GetInstance().GetMappingData(HisMappingCategory.All, (int)hisInfo.HisID);

            mappingCheck = new HISMapping { HisProviderID = (int)hisInfo.HisID };
            RemoveADTCheckedList();
            CountDSloaiTruADT();
            firstRun = true;
        }
        private void CapNhatADTTheoThongTin()
        {
            if (dtgGetADT_HISInfo.CurrentRow != null)
            {
                var hisSoHoSo = (dtgGetADT_HISInfo.CurrentRow.Cells[col_DanhSach_chidinhMabenhan.Name].Value ?? string.Empty).ToString().Trim();
                var strNgayVaoVien = (dtgGetADT_HISInfo.CurrentRow.Cells[col_DanhSach_chidinhNgayvaovien.Name].Value ?? string.Empty).ToString().Trim();
                var ngayVaovien = string.IsNullOrEmpty(strNgayVaoVien) ? (DateTime?)null : DateTime.Parse(strNgayVaoVien);
                var strNgayNhapVien = (dtgGetADT_HISInfo.CurrentRow.Cells[col_DanhSach_chidinhNgaynhapvien.Name].Value ?? string.Empty).ToString().Trim();
                var ngayNhapvien = string.IsNullOrEmpty(strNgayNhapVien) ? (DateTime?)null : DateTime.Parse(strNgayNhapVien);
                var hisSophieu = (dtgGetADT_HISInfo.CurrentRow.Cells[col_DanhSach_chidinhSophieuyeucau.Name].Value ?? string.Empty).ToString().Trim();
                var hisMaKhoaHienThoi = (dtgGetADT_HISInfo.CurrentRow.Cells[col_DanhSach_chidinhMakhoahienthoi.Name].Value ?? string.Empty).ToString();
                var hisTenKhoaHienThoi = (dtgGetADT_HISInfo.CurrentRow.Cells[col_DanhSach_chidinhTenkhoahienthoi.Name].Value ?? string.Empty).ToString();
                if (!CheckExistsADTCheckedList(hisSoHoSo, hisSophieu, hisMaKhoaHienThoi, (DateTime)ngayNhapvien))
                {
                    AddADTCheckedList(hisSoHoSo, hisSophieu, hisMaKhoaHienThoi, (DateTime)ngayNhapvien);

                    LogService.RecordLogFile("AutoUpdateInfo", string.Format("Số hồ sơ HIS {0} - Số phiếu {1}", hisSoHoSo, hisSophieu), "Tự động cập nhật khoa hiện thời và ngày nhập viện");
                    //  SetCheckADTStatus(mess);
                    var mappingCheck = new HISMapping();
                    mappingCheck.HisProviderID = (int)currentHIS;
                    if (!string.IsNullOrEmpty(hisMaKhoaHienThoi))
                    {
                        mappingCheck.CategoryID = (int)HisMappingCategory.KhoaPhong;
                        mappingCheck.HISID = hisMaKhoaHienThoi;
                        mappingCheck.ItemName = hisTenKhoaHienThoi;
                        hisMaKhoaHienThoi = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                    }
                    var objPatient = new BENHNHAN_TIEPNHAN();
                    objPatient.Bn_id = hisSoHoSo;
                    objPatient.Sophieuyeucau = hisSophieu;
                    objPatient.Makhoahienthoi = hisMaKhoaHienThoi;
                    objPatient.Tenkhoahienthoi = hisTenKhoaHienThoi;
                    objPatient.Tgvaovien = ngayVaovien;
                    objPatient.Ngaynhapvien = ngayNhapvien;
                    if (_iPatient.PatientLog(objPatient.Matiepnhan, "Auto Check", LogActionId.Update) > -1)
                    {
                        if (_iPatient.UpdatePatientInfoADT(objPatient))
                        {
                            LogService.RecordLogFile("AutoUpdateInfo", " ==> Cập nhật hoàn tất!", "Tự động cập nhật khoa hiện thời và ngày vào viện");
                        }
                        else
                            LogService.RecordLogFile("AutoUpdateInfo", " ==> Cập nhật thất bại", "Tự động cập nhật khoa hiện thời và ngày vào viện");
                    }
                    SetCheckADTStatus(string.Format("Hoàn tất kiểm tra thông tin: Số HS: {0} - Số phiếu: {1} ", hisSoHoSo, hisSophieu));
                }
                else
                {
                    SetCheckADTStatus(string.Format("Thông tin đã kiểm tra lần trước: Số HS: {0} - Số phiếu: {1} ", hisSoHoSo, hisSophieu));
                }
            }
            CountDSloaiTruADT();
        }
        private void TimerUpdateEachrow_Tick(object sender, EventArgs e)
        {
            if (!updating)
            {
                if (bvGetADTPatient.BindingSource.Position < bvGetADTPatient.BindingSource.Count - 1)
                {
                    timerGetADT.Stop();
                    updating = true;
                    if (callBreak)
                        StopTimerUpdate();
                    //Dùng binding navigator nếu move next sẽ lost dòng đầu
                    if (!firstRun)
                        bvGetADTPatient.BindingSource.MoveNext();
                    else
                        firstRun = false;

                    SetCheckADTStatus(string.Format("Kiểm tra thông tin dòng: {0}", bvGetADTPatient.BindingSource.Position));
                    lblGetADTStatus.Refresh();
                    CapNhatADTTheoThongTin();
                    timerGetADT.Start();
                    updating = false;
                }
                else
                {
                    SetCheckADTStatus("Đã dừng!");
                    StopTimerUpdate();
                    if (!callBreak)
                    {
                        SetCheckADTStatus("Chờ load danh sách tiếp theo...");
                        timerGetADT.Enabled = true;
                        timerGetADT.Start();
                    }
                }
            }
        }
        private void StopTimerUpdate()
        {
            timerUpdateEachrow.Stop();
            timerUpdateEachrow.Enabled = false;
            timerUpdateEachrow.Tick -= TimerUpdateEachrow_Tick;
            updating = false;
        }
        private void TimerGetADT_Tick(object sender, EventArgs e)
        {
            timerGetADT.Enabled = false;
            timerGetADT.Stop();
            LoadDaSachNoiTuHIS();
            if (dtgGetADT_HISInfo.RowCount > 0)
            {
                SetCheckADTStatus("Bắt đầu kiểm tra thông tin.");
                updating = false;
                timerUpdateEachrow.Interval = 250;
                timerUpdateEachrow.Tick += TimerUpdateEachrow_Tick;
                timerUpdateEachrow.Enabled = true;
                timerUpdateEachrow.Start();
            }
            else
            {
                timerGetADT.Enabled = true;
                timerGetADT.Start();
                SetCheckADTStatus("Không có thông tin.\nChờ cho lần tiếp theo...");
            }
        }
        private List<PatientCheckLIS> lstADTCheckedList = new List<PatientCheckLIS>();

        private void SetCheckADTStatus(string mess)
        {
            if (lblGetADTStatus.InvokeRequired)
            {
                lblGetADTStatus.Invoke((Action)(() =>
                {
                    lblGetADTStatus.Text = mess;
                }));
            }
            else
                lblGetADTStatus.Text = mess;
        }
        private void RemoveADTCheckedList()
        {
            if (lstUploadedList.Count > 0)
            {
                var dateCheck = DateTime.Now.AddMinutes(-(int)numADTKhoangCachLanKiemTra.Value);
                lstADTCheckedList.RemoveAll(x => x.NgayNhapVien.Date <= dtpGetADTFromDate.Value.Date);
            }
        }
        private void AddADTCheckedList(string sohoso, string sophieu, string maKhoaHienThoi, DateTime ngayNhapVien)
        {
            lstADTCheckedList.Add(new PatientCheckLIS { SoHoSo = sohoso,SoPhieu = sophieu,MaKhoaHienthoi = maKhoaHienThoi, NgayNhapVien = ngayNhapVien, LastUpdateTime = DateTime.Now });
        }
        private bool CheckExistsADTCheckedList(string sohoso, string sophieu, string maKhoaHienThoi, DateTime ngayNhapVien)
        {
            var obj = lstADTCheckedList.Where(x => x.SoHoSo.Equals(sohoso) && x.SoPhieu.Equals(sophieu));
            if (obj.Any())
            {
                var objDetail = obj.First();
                if (!objDetail.MaKhoaHienthoi.Equals(maKhoaHienThoi, StringComparison.OrdinalIgnoreCase)
                   || !objDetail.NgayNhapVien.Equals(ngayNhapVien))
                {
                    lstADTCheckedList.RemoveAll(x => x.MaKhoaHienthoi.Equals(maKhoaHienThoi, StringComparison.OrdinalIgnoreCase) && x.SoHoSo.Equals(sohoso, StringComparison.OrdinalIgnoreCase));
                    return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
        private void CountDSloaiTruADT()
        {
            lblDanhSachLoaiTruADT.Text = string.Format("Danh sách loại trừ: {0}", lstADTCheckedList.Count());
        }
        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (timerGetADT.Enabled)
            {
                runningADT = false;
                btnGetADTStart.BackColor = SystemColors.ButtonFace;
                SetCheckADTStatus("Đã dừng!");
                callBreak = true;
                StopTimerUpdate();
                pnADTConfig.Enabled = true;
                timerGetADT.Stop();
                timerGetADT.Enabled = false;
                timerGetADT.Tick -= TimerGetADT_Tick;
                btnXemDanhSach.Enabled = true;
                bnCapNhatADT.Enabled = true;
            }
            else
            {
                if (timerUpload.Enabled)
                {
                    CustomMessageBox.MSG_Information_OK("Quá trình upload kết quả đang chạy.\nHãy mở thêm ứng dụng để chạy tiến trình này.");
                }
                else
                {
                    runningADT = true;
                    lstADTCheckedList = new List<PatientCheckLIS>();
                    dtpGetADTFromDate.Value = dtpGetADTTodate.Value.AddDays(-double.Parse(numGetADTDays.Value.ToString()));
                    callBreak = false;
                    pnADTConfig.Enabled = false;
                    timerGetADT.Interval =  ((int)numGetADTInterval.Value) * 1000;
                    timerGetADT.Tick += TimerGetADT_Tick;
                    timerGetADT.Enabled = true;
                    timerGetADT.Start();
                    SetCheckADTStatus("Đang chạy...");
                    btnXemDanhSach.Enabled = false;
                    bnCapNhatADT.Enabled = false;
                }
            }
        }
        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            LoadDaSachNoiTuHIS();
        }

        private void bnCapNhatADT_Click(object sender, EventArgs e)
        {
            CapNhatADTTheoThongTin();
        }

        private void txtSearchBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (bvGetADTPatient.BindingSource != null)
            {
                if (!string.IsNullOrEmpty(txtSearchBN.Text))
                    bvGetADTPatient.BindingSource.Filter = string.Format("{1} like '%{0}%' or {2} = '{0}' or {3} = '{0}'", txtSearchBN.Text, col_DanhSanh_chidinhTenbenhnhan.DataPropertyName
                        , col_DanhSach_chidinhSophieuyeucau.DataPropertyName, col_DanhSach_chidinhMabenhan.DataPropertyName);
                else
                    bvGetADTPatient.BindingSource.Filter = string.Empty;
            }
        }
        #endregion


        private void btnCleanLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa log?", "UploadHIS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                DeleteLog();
        }

        private void tmTime_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Check_ChangeDate();
            if(runningADT)
            {
                btnGetADTStart.BackColor = (btnGetADTStart.BackColor == Color.Yellow ? Color.Empty : Color.Yellow);
            }
        }

        private void dtgDangSachKQ_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            LogService.RecordLogFile("Grid_Error", e.Exception.Message, lblTitle.Text);
        }

        private void txtSearchBN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
