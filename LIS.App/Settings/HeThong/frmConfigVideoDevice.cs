using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DirectX.Capture;
using DShowNET;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

// DsEvCode

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class frmConfigVideoDevice : FrmTemplate
    {
        public frmConfigVideoDevice()
        {
            InitializeComponent();
        }
        C_Config config = new C_Config();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private IMediaEventEx mediaEvent = null;
        private int CaptureResult;
        const int WM_GRAPHNOTIFY = 0x8000 + 1;
        private Capture capture = null;
        private Filters filters;

        int _shotCount = 0;
        // Media events are sent to use as windows messages
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // If this is a windows media message
                case WM_GRAPHNOTIFY:

					DsEvCode eventCode;
                    int p1, p2;
                    int hr;
                    hr = mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);

                    while (hr == 0)
                    {
                        // Handle the event.
                        switch (eventCode)
                        {
							case DsEvCode.ErrorAbort:
                                CaptureResult = p1;
                                break;
							case DsEvCode.FullScreenLost:
                                break;
                            default:
                                break;
                        }
                        // Release parms
                        mediaEvent.FreeEventParams(eventCode, p1, p2);

                        // check for additional events
                        hr = mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);
                    }
                    break;

                // All other messages
                default:
                    try
                    {
                        // unhandled window message
                        base.WndProc(ref m);
                    }
                    catch
                    {
                       // Debug.WriteLine("Fatal exception catching a message with WndProc()");
                    }
                    break;
            }
        }

        private void frmConfigVideoDevice_Load(object sender, EventArgs e)
        {
            try
            {
                chkAutoCofig.Checked = CommonAppVarsAndFunctions.AutoconfigCapture;
                GetStandard();
                GetDevice();
                C_BenhNhan_TiepNhan dtd = new C_BenhNhan_TiepNhan();
                data.Get_CauHinh_PhanLoaiChucNang(cboCategory, "and MaPhanLoai in ('ClsSieuAm','ClsNoiSoi')");
                txtRecordPath.Text = Environment.CurrentDirectory + @"\TestVideo.avi";
            }
            catch (Exception ex)
            {
                LabServices_Helper.RecordError(ex.Message);
            }
        }

        private void Load_LoaiMay_Theo_DV()
        {
            if (cboCategory.SelectedIndex != -1)
            {
                if (cboCategory.SelectedValue.ToString().Trim() == "ClsSieuAm")
                {
                    sysConfig.Get_DMMaySA(cboDeviceAlias);
                }
                else if (cboCategory.SelectedValue.ToString().Trim() == "ClsNoiSoi")
                {
                    sysConfig.Get_DMMayNS(cboDeviceAlias);
                }
            }
        }
        private bool sampleGrabber = false;
        private bool SampleGrabber
        {
            get { return this.sampleGrabber; }
            set
            {
                if ((this.capture != null) && (this.capture.AllowSampleGrabber))
                {
                    this.sampleGrabber = value;
                }
                else
                {
                    this.sampleGrabber = false;
                }
                if (this.sampleGrabber)
                {

                    if (this.capture != null)
                    {
                        this.capture.FrameEvent2 += new Capture.HeFrame(this.CaptureDone);
                    }
                }
                else
                {
                    if (this.capture != null)
                    {
                        this.capture.DisableEvent();
                        this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone);
                    }
                }
            }
        } 
        public void Get_DeviceConfig()
        {
            GetStandard();
            GetCaptureSource();
            GetCompressor();
            GetFrameRate();
            GetFrameSize();
        }
        public void GetStandard()
        {
            if (capture != null)
            {
                if (this.capture.dxUtils != null)
                {
                    AnalogVideoStandard currentStandard = this.capture.dxUtils.VideoStandard;
                    AnalogVideoStandard availableStandards = this.capture.dxUtils.AvailableVideoStandards;
                    int mask = 1;
                    int item = 0;
                    int curritem = -1;
                    while (mask <= (int)AnalogVideoStandard.PAL_N_COMBO)
                    {
                        int avs = mask & (int)availableStandards;
                        if (avs != 0)
                        {
                            this.cboVideostandard.Items.Add(((AnalogVideoStandard)avs).ToString());
                            if (currentStandard == (AnalogVideoStandard)avs)
                            {
                                curritem = item;
                            }
                            item++;
                        }
                        mask *= 2;
                    }
                    this.cboVideostandard.Enabled = (this.cboVideostandard.Items.Count > 1);
                    if (curritem >= 0)
                    {
                        this.cboVideostandard.SelectedIndex = curritem;
                    }
                    else
                    {
                        if (this.cboVideostandard.Items.Count > 0)
                        {
                            this.cboVideostandard.SelectedIndex = 0;
                        }
                    }
                }
            }
        }
        public void GetDevice()
        {
            try
            {
                filters = new Filters();
            }
            catch
            {
                filters = null;
                return;
            }
            Filter f;
            // Load video devices
            Filter videoDevice = null;
            if (capture != null)
                videoDevice = capture.VideoDevice;
            ListViewItem item = null;
            if (filters.VideoInputDevices.Count > 0)
            {
                for (int c = 0; c < filters.VideoInputDevices.Count; c++)
                {
                    f = filters.VideoInputDevices[c];
                    item = new ListViewItem(f.Name);
                    item.Tag = f;
                    lstDeviceList.Items.Add(item);
                }
            }
        }
        public void GetCaptureSource()
        {
            // Load video sources
            Source s;
            Source current;
            capture.VideoSources = null;
            current = capture.VideoSource;
            for (int c = 0; c < capture.VideoSources.Count; c++)
            {
                s = capture.VideoSources[c];
                cboSignalSource.Items.Add(s.Name);
            }
            if (current != null)
            {
                capture.VideoSource = current;
                cboSignalSource.Text = current.Name;
            }

        }
        public void GetFrameRate()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Rate");
            dt.Columns.Add("RateName");
            dt.Columns.Add("Resolution");

            int frameRate = (int)(capture.FrameRate * 1000);

            DataRow dr = dt.NewRow();

            dr["Rate"] = "15";
            dr["RateName"] = "15 fps";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Rate"] = "24";
            dr["RateName"] = "24 fps (Film)";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Rate"] = "25";
            dr["RateName"] = "25 fps (PAL)";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Rate"] = "29";
            dr["RateName"] = "29.970 fps (NTSC)";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Rate"] = "30";
            dr["RateName"] = "30 fps ~(NTSC)";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Rate"] = "59";
            dr["RateName"] = "59.994 fps (2xNTSC)";
            dt.Rows.Add(dr);

            cboFramRate.DataSource = dt;
            cboFramRate.ValueMember = "Rate";
            cboFramRate.DisplayMember = "RateName";
            cboFramRate.SelectedValue = ((int)capture.FrameRate).ToString();
        }
        public void GetFrameSize()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Resolution");


            DataRow dr = dt.NewRow();
            dr["Resolution"] = "160 x 120";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Resolution"] = "320 x 240";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Resolution"] = "640 x 480";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Resolution"] = "800 x 600";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Resolution"] = "1024 x 768";
            dt.Rows.Add(dr);

            cboFrameSize.DataSource = dt;
            cboFrameSize.ValueMember = "Resolution";
            cboFrameSize.DisplayMember = "Resolution";
            string _CurrentFrameSize = capture.FrameSize.Width.ToString() + " x " + capture.FrameSize.Height.ToString();
            cboFrameSize.SelectedValue = _CurrentFrameSize;
        }
        public void GetCompressor()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VCompressors", typeof(Filter));
            dt.Columns.Add("VCompressorsName", typeof(string));
            DataRow dr = dt.NewRow();
            for (int c = 0; c < filters.VideoCompressors.Count; c++)
            {
                dr = dt.NewRow();
                dr["VCompressors"] = (Filter)filters.VideoCompressors[c];
                dr["VCompressorsName"] = filters.VideoCompressors[c].Name;
                dt.Rows.Add(dr);
            }
            cboVideoCompressor.DataSource = dt;
            cboVideoCompressor.ValueMember = "VCompressors";
            cboVideoCompressor.DisplayMember = "VCompressorsName";
            if (capture.VideoCompressor == null)
            {
                cboVideoCompressor.SelectedIndex = -1;
            }
            else
            {
                cboVideoCompressor.SelectedValue = capture.VideoCompressor;
            }
        }
        public void Set_DeviceConfig()
        {

            SetStandard();
            SetFrameRate();
            SetFrameSize();
            SetAudio();
            SetVCompressor();
        }
        public void SetVideoSource()
        {
            this.capture.VideoSources = null;
            capture.VideoSource = capture.VideoSources[cboSignalSource.SelectedIndex];
        }
        public void SetStandard()
        {
            if (cboVideostandard.SelectedIndex != -1)
            {
                if (capture != null)
                {
                    if (this.capture.dxUtils != null)
                    {
                        if (this.capture.dxUtils.VideoDecoderAvail)
                        {
                            try
                            {
                                AnalogVideoStandard a = (AnalogVideoStandard)Enum.Parse(typeof(AnalogVideoStandard), this.cboVideostandard.Text);
                                this.capture.dxUtils.VideoStandard = a;
                            }
                            catch (Exception ex)
                            {
                               CustomMessageBox.MSG_Information_OK("Lỗi set config standard\n" + ex.ToString());
                                this.capture.dxUtils.VideoStandard = AnalogVideoStandard.None;
                            }
                        }
                        else
                        {
                            this.capture.dxUtils.VideoStandard = AnalogVideoStandard.None;
                        }
                    }
                }
            }
        }
        public void SetFrameRate()
        {
            try
            {
                if (cboFramRate.SelectedIndex != -1)
                {
                    capture.FrameRate = int.Parse(cboFramRate.SelectedValue.ToString());
                }
            }
            catch
            { }
        }
        public void SetFrameSize()
        {
            try
            {
                if (cboFrameSize.SelectedIndex != -1)
                {
                    string[] _frSize = cboFrameSize.SelectedValue.ToString().Split('x');
                    capture.FrameSize = new Size(int.Parse(_frSize[0].Trim()), int.Parse(_frSize[1].Trim()));
                }
            }
            catch
            { }
        }
        public void SetVCompressor()
        {
            try
            {
                if (cboVideoCompressor.SelectedIndex != -1)
                {
                    capture.VideoCompressor = (Filter)cboVideoCompressor.SelectedValue;
                }
            }
            catch
            { }
        }
        public void SetAudio()
        {
            if (capture.AudioDevice != null)
            {
                capture.AudioSamplingRate = 44100;          // 44.1 kHz
                capture.AudioSampleSize = 16;               // 16-bit
                try
                {
                    capture.AudioChannels = 2;                  // Mono
                }
                catch
                {
                    capture.AudioChannels = 1;                  // Mono
                }
            }
        }
        public void SelectDevice(Filter dv)
        {
            try
            {
                // Get current devices and dispose of capture object
                // because the video and audio device can only be changed
                // by creating a new Capture object.
                Filter videoDevice = null;
                Filter audioDevice = null;

                // Dispose sample grabber data
                this.SampleGrabber = false;

                if (capture != null)
                {
                    capture.Dispose();
                    capture = null;
                }

                // Get new video device
                videoDevice = dv;
                bool AudioViaPci = false;

                // Create capture object
                if ((videoDevice != null) || (audioDevice != null))
                {
                    capture = new Capture(videoDevice, audioDevice, AudioViaPci);
                    Get_DeviceConfig();
                    this.capture.FrameEvent2 += new Capture.HeFrame(this.CaptureDone);
                    capture.RecFileMode = DirectX.Capture.Capture.RecFileModeType.Avi;
                }

            }
            catch (Exception ex)
            {
               CustomMessageBox.MSG_Information_OK("Video device not supported.\n\n" + ex.Message + "\n\n" + ex.ToString());
            }
        }
        public void CaptureDone(System.Drawing.Bitmap e)
        {
            if (pictureBox1.Image == null && _shotCount == 1)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = e;
            }
            else if (pictureBox2.Image == null && _shotCount == 2)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = e;
            }
            else if (pictureBox3.Image == null && _shotCount == 3)
            {
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.Image = e;
            }
            else if (pictureBox4.Image == null && _shotCount == 4)
            {
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.Image = e;
            }
            // Show only the selected frame ...
            // If you want to capture all frames, then remove the next line
            //this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone); 
        }
        public void StartCapture(PanelControl pn)
        {
            if (lstDeviceList.SelectedItems.Count > 0)
            {
                if (capture.PreviewWindow == null)
                {
                    Set_DeviceConfig();
                    capture.AllowSampleGrabber = true;
                    capture.PreviewWindow = pn;
                    Start_Grabber();
                    btnStart.Text = "Stop Preview";
                }
                else
                {
                    btnStart.Text = "Preview";
                    capture.PreviewWindow = null;
                    capture.AllowSampleGrabber = false;
                    Start_Grabber();
                }
                this.Text = "- Đang bắt hình ảnh -";
            }
        }
        public void Start_Grabber()
        {
            if (this.SampleGrabber)
            {
                this.SampleGrabber = false;
            }
            else
            {
                this.SampleGrabber = true;
            }
        }
        private void lstDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDeviceList.SelectedItems.Count > 0)
            {
                SelectDevice(lstDeviceList.SelectedItems[0].Tag as Filter);
                Set_ConfigFromData();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartCapture(pnVideo);
        }

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            _shotCount++;
            if (_shotCount > 6)
            { 
                _shotCount = 1; 
            }
            capture.GrapImg();
        }

        public void AutoGet_SaveConfig()
        {
            string _ComputerName = Environment.MachineName;

            DataTable dtDevice = config.Get_CauHinhCaptureSA(_ComputerName);
            
            if (dtDevice.Rows.Count > 0)
            {
                Filter dev;
                bool Default = false;
                GetDevice();
                string[] _ConfigPara;
                string _config = "";
                if (lstDeviceList.Items.Count > 0)
                {
                    for (int i = 0; i < lstDeviceList.Items.Count; i++)
                    {
                        dev = lstDeviceList.Items[i].Tag as Filter;
                        if (Check_Device(dtDevice, dev.Name, ref _config))
                        {
                            SelectDevice(dev);
                            _ConfigPara = _config.Split(';');
                            if (_ConfigPara.Length > 2)
                            {
                                cboVideostandard.Text = _ConfigPara[0];
                                cboSignalSource.SelectedIndex = (_ConfigPara[1] != "None" ? int.Parse(_ConfigPara[1]) : -1);
                                cboFramRate.SelectedValue = _ConfigPara[2];
                                if (_ConfigPara.Length > 4)
                                {
                                    cboFrameSize.SelectedValue = _ConfigPara[3] + " x " + _ConfigPara[4];
                                }
                                if (_ConfigPara.Length > 5)
                                {
                                    cboVideoCompressor.Text = _ConfigPara[5];
                                }
                                //Set cau hinh
                                Set_DeviceConfig();
                            }
                        }
                    }
                }
            }
        }

        private void Set_ConfigFromData()
        {
            if (lstDeviceList.SelectedItems.Count > 0)
            {
                string _ComputerName = Environment.MachineName;
                Filter dev;
                dev = lstDeviceList.SelectedItems[0].Tag as Filter;
                DataTable dtDevice = config.Get_CauHinhCaptureSA(_ComputerName, dev.Name);

                if (dtDevice.Rows.Count > 0)
                {
                    string[] _ConfigPara;
                    string _config = "";
                    if (Check_Device(dtDevice, dev.Name, ref _config))
                    {
                        _ConfigPara = _config.Split(';');
                        if (_ConfigPara.Length > 2)
                        {
                            cboVideostandard.Text = _ConfigPara[0];
                            cboSignalSource.SelectedIndex = (_ConfigPara[1] != "None" ? int.Parse(_ConfigPara[1]) : -1);
                            cboFramRate.SelectedValue = _ConfigPara[2];
                            if (_ConfigPara.Length > 4)
                            {
                                cboFrameSize.SelectedValue = _ConfigPara[3] + " x " + _ConfigPara[4];
                            }
                            if (_ConfigPara.Length > 5)
                            {
                                cboVideoCompressor.Text = _ConfigPara[5];
                            }
                        }      
                        
                        if (dtDevice.Rows[0]["MaPhanLoai"] == DBNull.Value)
                        {
                            cboCategory.SelectedIndex = -1;
                        }
                        else
                        {
                            cboCategory.SelectedValue = dtDevice.Rows[0]["MaPhanLoai"].ToString().Trim();
                            Load_LoaiMay_Theo_DV();    
                        }

                        if (dtDevice.Rows[0]["DeviceAlias"] == DBNull.Value)
                        {
                            cboDeviceAlias.SelectedIndex = -1;
                        }
                        else
                        {
                            cboDeviceAlias.SelectedValue = dtDevice.Rows[0]["DeviceAlias"].ToString().Trim();
                        }

               
                    }

                }
            }
        }

        public bool Check_Device(DataTable dtCheck, string _DeviceName, ref string _configPara)
        {
            string _CheckName = "";
            _DeviceName = _DeviceName.Trim().ToLower();
            for (int i = 0; i < dtCheck.Rows.Count; i++)
            {
                _CheckName = dtCheck.Rows[i]["DeviceName"].ToString().Trim().ToLower();
                if (_CheckName.Equals(_DeviceName))
                {
                    _configPara = dtCheck.Rows[i]["Para1"].ToString().Trim();
                    return true;
                }
            }
            return false;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Save_Config(false);
        }

        private void Save_Config(bool _Auto)
        {
            if (chkWebcam.Checked == false && (cboSignalSource.SelectedIndex == -1 || cboVideostandard.SelectedIndex == -1))
            {
                CustomMessageBox.MSG_Waring_OK("Hãy chọn ngõ vào và chuẩn video cho thiết bị");
                return;
            }
            else if (cboCategory.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Waring_OK("Hãy chọn nhóm !");
                cboCategory.Focus();
                return;
            }
            else if (cboDeviceAlias.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Waring_OK("Hãy chọn máy !");
                cboDeviceAlias.Focus();
                return;
            }
            if (lstDeviceList.SelectedItems.Count > 0 && cboFramRate.SelectedIndex != -1 && cboFrameSize.SelectedIndex != -1)
            {
                string _Log = "";
                try
                {
                    _Log = "Get _Standard";

                    string _Standard = (cboVideostandard.Text != "" ? cboVideostandard.Text : "None");
                    _Log +=Environment.NewLine + " _Standard: " + _Standard;
                    _Log += Environment.NewLine + "Get _Source";
                    string _Source = (cboSignalSource.SelectedIndex != -1 ? cboSignalSource.SelectedIndex.ToString() : "None");
                    _Log += Environment.NewLine + " _Source: " + _Source;
                    _Log += Environment.NewLine + "Get _VCompress";
                    string _VCompress = (cboVideoCompressor.SelectedIndex != -1 ? cboVideoCompressor.Text : "None");
                    _Log += Environment.NewLine + " _VCompress: " + _VCompress;
                    _Log += Environment.NewLine + "Get _VideoCardName";
                    string _VideoCardName = ((Filter)lstDeviceList.SelectedItems[0].Tag).Name;
                    _Log += Environment.NewLine + " _VideoCardName: " + _VideoCardName;
                    _Log += Environment.NewLine + "Get _frameRate";
                    string _frameRate = cboFramRate.SelectedValue.ToString().Trim();
                    _Log += Environment.NewLine + " _frameRate: " + _frameRate;
                    _Log += Environment.NewLine + "Get _frameSize";
                    string _frameSize = cboFrameSize.SelectedValue.ToString();
                    _Log += Environment.NewLine + " _frameSize: " + _frameSize;
                    _Log += Environment.NewLine + "Get _MachineName";
                    string _MachineName = (cboDeviceAlias.SelectedIndex != -1 ? cboDeviceAlias.SelectedValue.ToString().Trim() : "");
                    _Log += Environment.NewLine + " _MachineName: " + _MachineName;
                    _Log += Environment.NewLine + "Get _CategoryName";
                    string _CategoryName = cboCategory.SelectedValue.ToString();
                    _Log += Environment.NewLine + " _CategoryName: " + _CategoryName;
                    _Log += Environment.NewLine + "Call Insert_Update_CauHinhCapture";
                    config.Insert_Update_CauHinhCapture(Environment.MachineName,_VideoCardName, _Standard, _Source, _frameRate, _frameSize, _VCompress, _MachineName, _CategoryName, true);
                    _Log += Environment.NewLine + "Call Insert_Update_CauHinhCapture Finish !";
                    _Log += Environment.NewLine + "Call Set_DeviceConfig";
                    Set_DeviceConfig();
                    _Log += Environment.NewLine + "Call Set_DeviceConfig finish!";
                    _Log += Environment.NewLine + "--------- End save config ----------";
                }
                catch (Exception ex)
                {
                    LabServices_Helper.RecordError("Save_CaptureError", _Log);
                    if (_Auto == false)
                    {
                       CustomMessageBox.MSG_Information_OK("Quá trình lưu cấu hình lại bị lỗi !\n Bạn hãy Restart máy tính lại ");
                    }
                }
            }
            else
            {
               CustomMessageBox.MSG_Information_OK("Vui lòng chọn đủ thông số trước khi lưu");
            }
        }

        private void chkAutoCofig_CheckedChanged(object sender, EventArgs e)
        {
            config.Check_AutoSetConfig_Capture(chkAutoCofig.Checked);
        }

        private void chkAutoCofig_Click(object sender, EventArgs e)
        {
            CommonAppVarsAndFunctions.AutoconfigCapture = chkAutoCofig.Checked;
        }

        private void chkWebcam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCapture.Text != "Stop")
                {
                    SetVCompressor();
                    wmpPlayer.URL = "";
                    capture.Filename = txtRecordPath.Text;
                    capture.Start();
                    btnCapture.Text = "Stop";
                }
                else
                {
                    capture.Stop();
                    btnCapture.Text = "Record";
                    wmpPlayer.URL = txtRecordPath.Text;
                    wmpPlayer.Ctlcontrols.play();
                }
            }
            catch (Exception ex)
            {
                capture.Stop();
                btnCapture.Text = "Record";
                wmpPlayer.URL = "";
                ErrorService.GetFrameworkErrorMessage(ex, "btnCapture_Click - frmConfig capture device", CommonAppVarsAndFunctions.UserID);
            }
        }

        private void cboCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_LoaiMay_Theo_DV();
        }

        private void cboCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_LoaiMay_Theo_DV();
                LabServices_Helper.LeaveFocusNext(e, cboDeviceAlias);
            }
        }

    }
}
