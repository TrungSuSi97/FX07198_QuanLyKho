using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DirectX.Capture;
using DShowNET;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.ThucThi.CanLamSang
{
    public partial class frmCLSKQSieuAm : FrmTemplate
    {
        C_Patient _patientInfo = new C_Patient();
        C_BenhNhan_TiepNhan _data = new C_BenhNhan_TiepNhan();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        DataTable _dtPatient = new DataTable();
        C_Patient_SieuAm _sieuam = new C_Patient_SieuAm();
        C_Config _config = new C_Config();
        DateTime _dtDateInG = new DateTime();

        private IMediaEventEx _mediaEvent = null;
        const int WmGraphnotify = 0x8000 + 1;
        private Capture _capture = null;
        private Filters _filters;
        int _shotCount = 0;
        Panel _manche = new Panel();
        public DateTime DtDateInG
        {
            get { return _dtDateInG; }
            set { _dtDateInG = value; }
        }
        string _matiepNhanG = "";
        public string MatiepNhanG
        {
            get { return _matiepNhanG; }
            set { _matiepNhanG = value; }
        }
        int _indexImage = 0;
        bool _loading = false,
        _GrapimageSelected = true;

        int CaptureResult;
        bool _allowEdit = false;
        bool _allowInsert = false;
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        public frmCLSKQSieuAm()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Clean up any resources being used for Capture
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void Check_EnableControl()
        {
            btnClear5.Enabled =
                btnClear4.Enabled =
                    btnClear3.Enabled =
                        btnClear2.Enabled =
                            btnClear1.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA10");
            btnStart.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA9");
            btnSearchSEQ.Enabled = btnPreview.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA6");
            btnPrint.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA7");
            //Quyền nhập kết quả
            _allowInsert = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA1");
            //Quyền sửa kết quả
            _allowEdit = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA2");
        }

        private void ClearControl()
        {

            txtSID.DataBindings.Clear();
            txtSID.Text = string.Empty;
            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = string.Empty;
            txtAddress.DataBindings.Clear();
            txtAddress.Text = string.Empty;
            //txtPhone.DataBindings.Clear();
            //txtPhone.Text = string.Empty;
            //txtEmail.DataBindings.Clear();
            //txtEmail.Text = string.Empty;
            txtAge.DataBindings.Clear();
            txtAge.Text = string.Empty;
            txtSex.DataBindings.Clear();
            txtSex.Text = string.Empty;
            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;
            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;
            lblSex.Text = string.Empty;
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = string.Empty;
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = string.Empty;
            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = string.Empty;
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = string.Empty;
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = string.Empty;
        }

        private void SelectRow_SEQ()
        {
            if (txtSEQ.Text.Length >= 4)
            {
                LabServices_Helper.Select_Row(dtgPatient, bvPatient, "SEQ", txtSEQ.Text);
            }
        }
        private void Load_TiepNhan()
        {
            _loading = true;
            var tempSeq = txtSEQ.Text;
            var printType = 0;
            if (radNotPrint.Checked)
                printType = 2;
            else if (radPrinted.Checked)
                printType = 1;

            _dtPatient = _sieuam.Get_Patient_SieuAm(
                string.Empty, 
                dtpDateIn.Value.ToString("yyyy-MM-dd"), 
                printType);
            ControlExtension.BindDataToGrid(_dtPatient, ref dtgPatient, ref bvPatient);
            BindPatient(bvPatient.BindingSource);
            if (dtgPatient.RowCount > 0)
            {
                if (!string.IsNullOrWhiteSpace(tempSeq))
                {
                    txtSEQ.Text = tempSeq;
                    SelectRow_SEQ();
                }
            }
            else
            {
                txtSEQ.Text = string.Empty;
                Load_ChiDinhSieuAm();
            }

            _loading = false;
        }
        private void Load_ChiDinhSieuAm()
        {
            _manche.Size = Screen.PrimaryScreen.Bounds.Size;
            if (!splitKQ.Panel1.Controls.Contains(_manche))
            {
                splitKQ.Panel1.Controls.Add(_manche);
            }
            _manche.BringToFront();
            _manche.Dock = DockStyle.None;
            _manche.Visible = true;
            _data.Get_CLS_KetQua_SieuAm(cboChiDinhSieuAm, " MaTiepNhan = '" + txtSID.Text + "'");
            BindResult(cboChiDinhSieuAm);
            cboChiDinhSieuAm.SelectedIndex = -1;
            if (cboChiDinhSieuAm.Items.Count > 0)
            {
                cboChiDinhSieuAm.SelectedIndex = 0;
            }
            _manche.Visible = false; 
        }
        private void BindResult(CustomComboBox cbo)
        {
            ricTrang1.DataBindings.Clear();
            ricTrang1.Rtf = string.Empty;
            ricTrang1.DataBindings.Add("Rtf", cbo.DataSource, "NoiDung1");

            ricTrang2.DataBindings.Clear();
            ricTrang2.Rtf = string.Empty;
            ricTrang2.DataBindings.Add("Rtf", cbo.DataSource, "NoiDung2");

            ricKetLuan.DataBindings.Clear();
            ricKetLuan.Rtf = string.Empty;
            ricKetLuan.DataBindings.Add("Rtf", cbo.DataSource, "Ketluan");

            txtSoTrang.DataBindings.Clear();
            txtSoTrang.Text = "1";
            txtSoTrang.DataBindings.Add("Text", cbo.DataSource, "SoTrangIn");
            pbShot1.DataBindings.Clear();
            pbShot1.Image = null;
            pbShot1.DataBindings.Add("ImageLocation", cbo.DataSource, "Hinh1");
            pbShot2.DataBindings.Clear();
            pbShot2.Image = null;
            pbShot2.DataBindings.Add("ImageLocation", cbo.DataSource, "Hinh2");
            pbShot3.DataBindings.Clear();
            pbShot3.Image = null;
            pbShot3.DataBindings.Add("ImageLocation", cbo.DataSource, "Hinh3");
            pbShot4.DataBindings.Clear();
            pbShot4.Image = null;
            pbShot4.DataBindings.Add("ImageLocation", cbo.DataSource, "Hinh4");
            pbShot5.DataBindings.Clear();
            pbShot5.Image = null;
            pbShot5.DataBindings.Add("ImageLocation", cbo.DataSource, "Hinh5");

            txtHinh1.DataBindings.Clear();
            txtHinh1.Text = "0";
            txtHinh1.DataBindings.Add("Text", cbo.DataSource, "HinhIn1");
            txtHinh2.DataBindings.Clear();
            txtHinh2.Text = "0";
            txtHinh2.DataBindings.Add("Text", cbo.DataSource, "HinhIn2");

            cboUsersign.DataBindings.Clear();
            cboUsersign.SelectedIndex = -1;
            cboUsersign.DataBindings.Add("SelectedValue", cbo.DataSource, "NguoiKy");

            chkPrintted.DataBindings.Clear();
            chkPrintted.Checked = false;
            chkPrintted.DataBindings.Add("Checked", cbo.DataSource, "DaInKQ");

            chkValid.DataBindings.Clear();
            chkValid.Checked = false;
            chkValid.DataBindings.Add("Checked", cbo.DataSource, "XacNhanKQ");

            txtDeNghi.DataBindings.Clear();
            txtDeNghi.Text = string.Empty;
            txtDeNghi.DataBindings.Add("Text", cbo.DataSource, "DeNghi");

            dtpTaiKham.DataBindings.Clear();
            dtpTaiKham.DataBindings.Add(
                "Value", 
                cbo.DataSource,
                "HenTaiKham", 
                true, 
                DataSourceUpdateMode.Never,
                DateTime.Now.AddDays(7));
            dtpTaiKham.DataBindings.Add(
                "Checked", 
                cbo.DataSource, 
                "HenTaiKham", 
                true, 
                DataSourceUpdateMode.Never,
                false);
           
            cboMachineName.ComboBox.DataBindings.Clear();
            cboMachineName.ComboBox.DataBindings.Add("SelectedValue", cbo.DataSource, "MaySieuAm");
        }

        private void BindPatient(BindingSource bs)
        {
            ClearControl();

            txtSID.DataBindings.Clear();
            txtSID.DataBindings.Add("Text", bs, "MaTiepNhan");
            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
           // txtPhone.DataBindings.Add("Text", bs, "SDT");
           // txtEmail.DataBindings.Add("Text", bs, "Email");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            txtSex.DataBindings.Add("Text", bs, "GioiTinh");
            txtLanIn.DataBindings.Add("Text", bs, "LanInSieuAm");
            txtTGIn.DataBindings.Add(
                "Text",
                bs, 
                "ThoiGianInSieuAm",
                true,
                DataSourceUpdateMode.Never, 
                null, 
                "dd/MM/yyyy HH:mm");
            txtChanDoan.DataBindings.Add("Text", bs, "ChanDoan");
            dtpBirthday.DataBindings.Add(
                "Value", 
                bs, 
                "SinhNhat", 
                true,
                DataSourceUpdateMode.OnValidation, 
                DateTime.Now);
        }
        private void btnShot_Click(object sender, EventArgs e)
        {
            if (chkValid.Checked)
            {
                CustomMessageBox.MSG_Information_OK("Kết quả đã xác nhận !\nKhông thể thêm hình chụp.");
            }
            else
            {
                _justCap = false;
                _shotCount++;
                if (_shotCount > 5)
                {
                    _shotCount = 1;
                }
                _capture.GrapImg();
            }
        }

        private void frmKQSieuAm_Load(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, "PrintResult", false);
            sysConfig.Get_DMMaySA(cboMachineName.ComboBox);
            GetDevice_Capture();
            SetSizeModePictureBox();
            Check_EnableControl();
            Set_EventFocus();
            txtSEQ.Focus();
            if (_matiepNhanG != "")
            {

                txtSEQ.Text = _matiepNhanG;
                dtpDateIn.Value = _dtDateInG;
            }
            else
                Load_TiepNhan();

            C_NguoiDung user = new C_NguoiDung();
            user.Get_UserSign(cboUsersign, ServiceType.ClsSieuAm, " and d.MaNguoiDung not in ('admin')");
            Set_Sign();
        }
        private void Set_EventFocus()
        {
            LabServices_Helper.Set_Event_Focus(txtFindName);
            LabServices_Helper.Set_Event_Focus(txtSEQ);
            LabServices_Helper.Set_Event_Focus(txtDeNghi);
            LabServices_Helper.Set_Event_Focus(ricKetLuan);
            LabServices_Helper.Set_Event_Focus(ricTrang1);
            LabServices_Helper.Set_Event_Focus(radAllPrint);
            LabServices_Helper.Set_Event_Focus(radNotPrint);
            LabServices_Helper.Set_Event_Focus(radPrinted);
            LabServices_Helper.Set_Event_Focus(txtHinh1);
            LabServices_Helper.Set_Event_Focus(txtHinh2);
        }

        private void Set_Sign()
        {
            if (!string.IsNullOrWhiteSpace(CommonAppVarsAndFunctions.UserIDTamSieuAm))
            {
                cboUsersign.SelectedValue = CommonAppVarsAndFunctions.UserIDTamSieuAm;
            }
        }

        private void CheckLoad_Image()
        {
            var matiepnhan = txtSID.Text;
            var date = dtpDateIn.Value.ToString("ddMMyyyy");
            var year = dtpDateIn.Value.Year.ToString();
            var month = dtpDateIn.Value.Month.ToString();
            var path =
                string.Format(@"{0}\{1}\{2}\{3}\{4}\{5}_{6}",
                    CommonAppVarsAndFunctions.CaptureImagePath,
                    year,
                    month,
                    date,
                    matiepnhan,
                    matiepnhan,
                    cboChiDinhSieuAm.SelectedValue);

            if (System.IO.File.Exists(path + "_1.jpg"))
            {
                LoadImage(path + "_1", pbShot1);
            }
            else
            {
                pbShot1.Image = null;
            }
            if (System.IO.File.Exists(path + "_2.jpg"))
            {
                LoadImage(path + "_2", pbShot2);
            }
            else
            {
                pbShot2.Image = null;
            }
            if (System.IO.File.Exists(path + "_3.jpg"))
            {
                LoadImage(path + "_3", pbShot3);
            }
            else
            {
                pbShot3.Image = null;
            }
            if (System.IO.File.Exists(path + "_4.jpg"))
            {
                LoadImage(path + "_4", pbShot4);
            }
            else
            {
                pbShot4.Image = null;
            }
            if (System.IO.File.Exists(path + "_5.jpg"))
            {
                LoadImage(path + "_5", pbShot5);
            }
            else
            {
                pbShot5.Image = null;
            }
        }

        private void LoadImage(string imagePath, PictureBox pb)
        {
            var fullPath = imagePath + ".jpg";
            pb.Image = Image.FromFile(fullPath);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ShowImage(PictureBox pb)
        {
            if (pb.Image != null)
            {
                pnViewImage.BackgroundImage = pb.Image;
                pnViewImage.BackgroundImageLayout = ImageLayout.Stretch;
                pnPreview.Size = new System.Drawing.Size(480, 384);
                pnPreview.Location = new Point(this.Width / 2 - pnPreview.Width / 2, (this.Height / 2 - pnPreview.Height / 2)/2);
                pnPreview.BringToFront();
                pnPreview.Visible = true;
            }

        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            if (cboChiDinhSieuAm.SelectedIndex != -1)
            {
                string validText = (chkValid.Checked ?Common.CommonConstant.InValid  : Common.CommonConstant.IsValided);
                if (chkValid.Checked)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy xác nhận kết quả ?"))
                    {
                        _sieuam.XacNhan_KQ_SieuAm(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), cboChiDinhSieuAm.SelectedValue.ToString(), validText, false, CommonAppVarsAndFunctions.UserID);
                        Load_TiepNhan();
                    }
                }
                else
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận kết quả ?"))
                    {
                        btnSave_Click(sender, e);
                        _sieuam.XacNhan_KQ_SieuAm(txtSID.Text, cboChiDinhSieuAm.SelectedValue.ToString(), validText, true, CommonAppVarsAndFunctions.UserID);
                        Load_TiepNhan();
                    }
                }
                
            }
        }

        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectRow_SEQ();
                e.Handled = true;
            }
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            Load_TiepNhan();
        }

        private void dtpDateIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtSEQ);
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            if (txtSoTrang.Text.Equals("1"))
            {
                splitKQ.Panel2.Hide();
                splitKQ.SplitterPosition = splitKQ.Size.Width;

            }
            else if (txtSoTrang.Text.Equals("2"))
            {
                splitKQ.SplitterPosition = splitKQ.Size.Width / 2;
                splitKQ.Panel2.Show();
            }
        }

        private void Check_SelectPic(CheckBox chk)
        {
            chk.Checked = !chk.Checked;
        }

        private void pbShot1_MouseEnter(object sender, EventArgs e)
        {
            ShowImage(pbShot1);
        }

        private void pbShot2_MouseEnter(object sender, EventArgs e)
        {
            ShowImage(pbShot2);
        }

        private void pbShot3_MouseEnter(object sender, EventArgs e)
        {
            ShowImage(pbShot3);
        }

        private void pbShot4_MouseEnter(object sender, EventArgs e)
        {
            ShowImage(pbShot4);
        }

        private void pbShot5_MouseEnter(object sender, EventArgs e)
        {
            ShowImage(pbShot5);
        }

        private void cboChiDinhSieuAm_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cboChiDinhSieuAm.SelectedIndex != -1 && cboChiDinhSieuAm.SelectedValue != null)
            {
                //BindResult(cboChiDinhSieuAm);
                //CheckLoad_Image();
                if (!dtpTaiKham.Checked)
                {
                    DateTime dt = new DateTime(
                        dtpTaiKham.Value.Year, 
                        dtpTaiKham.Value.Month, 
                        dtpTaiKham.Value.Day, 
                        (DateTime.Now.Hour < 12 ? 12 : 5), 
                        0, 
                        0);
                    dtpTaiKham.Value = dt;
                    dtpTaiKham.Checked = false;
                }
            }
            else
            {
                //ricTrang1.DataBindings.Clear();
                //ricTrang1.Rtf = string.Empty;
                //ricTrang2.DataBindings.Clear();
                //ricTrang2.Rtf = string.Empty;
                //txtSoTrang.DataBindings.Clear();
                //txtSoTrang.Text = "2";
                
                //cboMaySieuAm.DataBindings.Clear();
                //cboMaySieuAm.SelectedIndex = -1;

                //pbShot1.Image = null;
                //pbShot2.Image = null;
                //pbShot3.Image = null;
                //pbShot4.Image = null;
                //pbShot5.Image = null;

                //pbShot1.DataBindings.Clear();
                //pbShot2.DataBindings.Clear();
                //pbShot3.DataBindings.Clear();
                //pbShot4.DataBindings.Clear();
                //pbShot5.DataBindings.Clear();

                //pbShot1.ImageLocation = "";
                //pbShot2.ImageLocation = "";
                //pbShot3.ImageLocation = "";
                //pbShot4.ImageLocation = "";
                //pbShot5.ImageLocation = "";

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_Result();
        }

        private void Save_Result()
        {
            if (cboChiDinhSieuAm.SelectedIndex != -1)
            {
                RichTextBox rcT = new RichTextBox();
                rcT.Rtf = ricKetLuan.Rtf;
                Find_ReplaceComment(ricKetLuan.Text, ricKetLuan.Text.ToUpper(), 0, rcT);
                ricKetLuan.Rtf = rcT.Rtf;
                _sieuam.CapNhat_KQ_SieuAm(txtSID.Text, cboChiDinhSieuAm.SelectedValue.ToString(),
                    ricTrang1.Rtf, ricTrang2.Rtf, ricKetLuan.Rtf,
                    CommonAppVarsAndFunctions.UserID,
                    (cboMachineName.ComboBox.SelectedIndex == -1 ? string.Empty : cboMachineName.ComboBox.SelectedValue.ToString()),
                    (cboUsersign.SelectedIndex == -1 ? string.Empty : cboUsersign.SelectedValue.ToString().Trim()),
                    txtDeNghi.Text, (dtpTaiKham.Checked ? dtpTaiKham.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty));
            }
        }

        private void Find_ReplaceComment(string Find, string Replace, int startIndex, RichTextBox rt)
        {
            int starIndex = -1;
            starIndex = rt.Text.IndexOf(Find, startIndex, StringComparison.Ordinal);

            if (starIndex != -1)
            {
                rt.Select(starIndex, Find.Length);
                rt.SelectedText = Replace;
               //Find_ReplaceComment(Find, Replace, _starIndex, rt);
            }
        }

        private void PrintResult(DataTable dtInfo, int index, bool isPrint)
        {
            Set_User();
            Save_Result();
            if (cboUsersign.SelectedIndex == -1 || 
                (txtHinh1.Text.Equals("0") && txtHinh2.Text.Equals("0")))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập đủ thông tin hình in và người ký tên!");
            }
            else
            {
                DataTable dtPrint = new DataTable();
                string maSoMau = (cboChiDinhSieuAm.SelectedIndex != -1 ? cboChiDinhSieuAm.SelectedValue.ToString() : string.Empty);
                dtPrint = _sieuam.DuLieuIn_SieuAm(dtInfo, index, false, maSoMau);
                if (dtPrint.Rows.Count > 0)
                {
                    ImageConverter ic = new ImageConverter();
                    byte[] barcode = (byte[])ic.ConvertTo(
                        Code128Rendering.MakeBarcodeImage(dtPrint.Rows[0]["SEQ"].ToString().Trim(), 1, true), 
                        typeof(byte[]));
                    for (int i = 0; i < dtPrint.Rows.Count; i++)
                    {
                        dtPrint.Rows[i]["Barcode"] = barcode;
                    }
                    progressPrint.Maximum = 6;
                    progressPrint.Visible = true;
                    progressPrint.Value = 0;
                    //FrmReport report = new FrmReport();
                    //string printerName = string.Empty;
                    //if (listPrinter.Items.Count > 0)
                    //{
                    //    if (listPrinter.SelectedIndex == -1)
                    //    {
                    //        listPrinter.SelectedIndex = 0;
                    //    }
                    //    progressPrint.Value++;
                    //    printerName = listPrinter.SelectedItem.ToString();
                    //}
                    //progressPrint.Value++;

                    //Reports.rpKQSieuAm rp = new Reports.rpKQSieuAm();

                    //if (report.Excute_Show_Print_Report(rp, dtPrint, "SA", false, false, !isPrint, isPrint, printerName, false))
                    //{
                    //    _sieuam.CapNhat_In_KQ_SieuAm(txtSID.Text, (cboUsersign.SelectedIndex == -1 ? "" : cboUsersign.SelectedValue.ToString().Trim()), maSoMau);
                    //}
                    //report.Dispose();
                    //progressPrint.Value++;
                    //Load_TiepNhan();
                    ////Nếu số dòng bệnh nhân bang 0 thì cellenter không thực hiện nên gọi load
                    //if (dtgPatient.RowCount == 0)
                    //{
                    //    Load_ChiDinhSieuAm();
                    //}
                    //progressPrint.Visible = false;
                }
                else
                {
                   CustomMessageBox.MSG_Information_OK("Không có dữ liệu để in !");
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PrintResult(_dtPatient, bvPatient.BindingSource.Position, false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_dtPatient.Rows.Count > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả?"))
                {
                    PrintResult(_dtPatient, bvPatient.BindingSource.Position, true);
                }
            }
        }

        private void chkAgeType_CheckedChanged(object sender, EventArgs e)
        {
            dtpBirthday.Visible = chkAgeType.Checked;
        }
        #region  Grabber Image
      
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            
        }
        private string GetRecordFile()
        {
            string date = dtpDateIn.Value.ToString("ddMMyyyy");
            string patientFolder = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
            string saveVideoFolder = string.Format(@"{0}\{1}\{2}", CommonAppVarsAndFunctions.VideoOuptPath, date, patientFolder);
            string saveVideoFilePath = string.Format(@"{0}\{1}_{2}.avi", saveVideoFolder, patientFolder, cboChiDinhSieuAm.SelectedValue);
            
            if (LabServices_Helper.CheckExistsFolder(saveVideoFolder) == false)
            {
                LabServices_Helper.CreateFolder(saveVideoFolder);
            }
            if (System.IO.File.Exists(saveVideoFilePath))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Video đã có. \nLưu đè video mới ?"))
                {
                    LabServices_Helper.DeleteFile(saveVideoFilePath);
                }
            }

            return saveVideoFilePath;
        }
        //Hàm để lưu và gán hình sau khi grab
        private void SaveImage(PictureBox pb, string no)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SaveCapture (SaveImage), new object[] { pb, no });

                return;
            }

            string date = dtpDateIn.Value.ToString("ddMMyyyy");
            string year = dtpDateIn.Value.Year.ToString();
            string month = dtpDateIn.Value.Month.ToString();
            string patientFolder = txtSID.Text;
            string maSoMau = cboChiDinhSieuAm.SelectedValue.ToString();
            string saveImageFolder = string.Format(@"{0}\{1}\{2}\{3}\{4}", CommonAppVarsAndFunctions.CaptureImagePath, year, month, date, patientFolder);
            string saveImageFilePath = string.Format(@"{0}\{1}_{2}_{3}.jpg", saveImageFolder, patientFolder, maSoMau, no);

            bool overwrite = false;

            if (LabServices_Helper.CheckExistsFolder(saveImageFolder) == false)
            {
                LabServices_Helper.CreateFolder(saveImageFolder);
            }

            if (System.IO.File.Exists(saveImageFilePath))
            {
                if (overwrite)
                {
                    UpdateAndSaveImage(pb, saveImageFilePath, patientFolder,maSoMau, no, overwrite);
                }
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hình ảnh đã lưu trước. \nLưu đè hình mới ?"))
                {
                    UpdateAndSaveImage(pb, saveImageFilePath, patientFolder,maSoMau, no, overwrite);
                }
            }
            else
            {
                UpdateAndSaveImage(pb, saveImageFilePath, patientFolder, maSoMau, no, false);
            }
        }

        private void UpdateAndSaveImage(
            PictureBox pb, 
            string savePath, 
            string matiepdoan,
            string maSoMau, 
            string no, 
            bool overwrite)
        {
            try
            {
                ImageFormat imf = ImageFormat.Jpeg;
                if (overwrite)
                {
                    pb.Image.Dispose();
                    LabServices_Helper.DeleteFile(savePath);
                }
                pb.Image.Save(savePath, imf);
                _sieuam.Update_ImagePath(savePath, no, matiepdoan, maSoMau);
                pb.ImageLocation = savePath;
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "frmCLSKQSieuAm - UpdateAndSaveImage", CommonAppVarsAndFunctions.UserID);
            }
        }

        //Hàm xóa hình
        private void Delete_Image(PictureBox pb, string no)
        {
            if (cboChiDinhSieuAm.SelectedIndex != -1)
            {
                string folder = txtSID.Text;
                string path = pb.ImageLocation;
                string maSoMau = cboChiDinhSieuAm.SelectedValue.ToString();
                if (LabServices_Helper.CheckExistsFileName(path))
                {
                    try
                    {
                        pb.Image.Dispose();
                        pb.Image = null;
                        LabServices_Helper.DeleteFile(path);
                        _sieuam.Update_ImagePath(string.Empty, no, maSoMau, folder);
                        pb.ImageLocation = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        ErrorService.GetFrameworkErrorMessage(ex, "frmCLSKQSieuAm - Delete_Image", CommonAppVarsAndFunctions.UserID);
                    }
                }
            }
        }

        private void SetImage_WhenGrabDone(Bitmap b, PictureBox pb)
        {
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = (Image)b;
        }

        private void SetSizeModePictureBox()
        {
            pbShot1.SizeMode = PictureBoxSizeMode.Zoom;
            pbShot2.SizeMode = PictureBoxSizeMode.Zoom;
            pbShot3.SizeMode = PictureBoxSizeMode.Zoom;
            pbShot4.SizeMode = PictureBoxSizeMode.Zoom;
            pbShot5.SizeMode = PictureBoxSizeMode.Zoom;
            pbCapture.SizeMode = PictureBoxSizeMode.Zoom;
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private void frmKQSieuAm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capture != null)
            {
                if (_capture.PreviewWindow != null)
                {
                    CustomMessageBox.MSG_Waring_OK("HÃY TẮT THIẾT BỊ TRƯỚC KHI ĐÓNG FORM !");
                    e.Cancel = true;
                }
                else
                {
                    _capture.DisposeSampleGrabber();
                    _capture.Dispose();
                }
            }
        }

        private void frmKQSieuAm_Activated(object sender, EventArgs e)
        {
            txtSEQ.Focus();
        }

        private void btnGet1_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 1;
            _GrapimageSelected = true;
            _capture.GrapImg();
        }

        private void btnGet2_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 2;
            _GrapimageSelected = true;
            _capture.GrapImg();
        }

        private void btnGet3_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 3;
            _GrapimageSelected = true;
            _capture.GrapImg();
        }

        private void btnGet4_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 4;
            _GrapimageSelected = true;
            _capture.GrapImg();
        }

        private void btnGet5_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 5;
            _GrapimageSelected = true;
            _capture.GrapImg();
        }
        private void btnClear1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pbShot1.ImageLocation))
            {
                Delete_Image(pbShot1, "1");
            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pbShot2.ImageLocation))
            {
                Delete_Image(pbShot2, "2");
            }
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pbShot3.ImageLocation))
            {
                Delete_Image(pbShot3, "3");
            }
        }
        private void btnClear4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pbShot4.ImageLocation))
            {
                Delete_Image(pbShot4, "4");
            }
        }
        private void btnClear5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pbShot5.ImageLocation))
            {
                Delete_Image(pbShot5, "5");
            }
        }

        private void btnDanhSachBN_Click(object sender, EventArgs e)
        {

        }

        private void btnInValid_Click(object sender, EventArgs e)
        {
            if (cboChiDinhSieuAm.SelectedIndex != -1)
            {

            }
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrinterResult, 
                listPrinter.SelectedIndex.ToString());
        }

        bool _record = false;

        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRecord.Text != "Dừng ghi")
                {
                    _capture.Filename = GetRecordFile();
                    _capture.Start();
                    btnRecord.Text = "Dừng ghi";
                    dtRecord = DateTime.Now;
                    pnRecord.Visible = true;
                    timerRecord.Start();
                }
                else
                {
                    timerRecord.Stop();
                    pnRecord.Visible = false;
                    _capture.Stop();
                    btnRecord.Text = "Ghi hình";
                }
            }
            catch (Exception ex)
            {
                _capture.Stop();
                btnRecord.Text = "Record";
                ErrorService.GetFrameworkErrorMessage(ex, "btnRecord_Click - Frm KQCLS Capture Device", CommonAppVarsAndFunctions.UserID);
            }

        }
        #region "Capture Image"
        // Media events are sent to use as windows messages
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                // If this is a windows media message
                case WmGraphnotify:

                    DsEvCode eventCode;
                    int p1, p2;
                    int hr;
                    hr = _mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);

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
                        _mediaEvent.FreeEventParams(eventCode, p1, p2);

                        // check for additional events
                        hr = _mediaEvent.GetEvent(out eventCode, out p1, out p2, 0);
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
        public void GetDevice_Capture()
        {
            try
            {
                _filters = new Filters();
            }
            catch
            {
                _filters = null;
                return;
            }
            string aliasName = "";
            Filter f;
            // Load video devices
            Filter videoDevice = null;
            if (_capture != null)
                videoDevice = _capture.VideoDevice;
            dropDevice.Tag = -1;
            ToolStripMenuItem mnuItem;
            if (_filters.VideoInputDevices.Count > 0)
            {
                for (int c = 0; c < _filters.VideoInputDevices.Count; c++)
                {
                    f = _filters.VideoInputDevices[c];

                    DataTable dtDevice = _config.Get_CauHinhCaptureSA(Environment.MachineName.Trim(), f.Name);
                    if (dtDevice.Rows.Count > 0)
                    {
                        aliasName = dtDevice.Rows[0]["TenMay"].ToString();
                    }
                    else
                    {
                        aliasName = string.Empty;
                    }
                    mnuItem = new ToolStripMenuItem((string.IsNullOrWhiteSpace(aliasName) ? f.Name : aliasName), imageList1.Images[6]);
                    mnuItem.Name = (string.IsNullOrWhiteSpace(aliasName) ? f.Name : aliasName);
                    mnuItem.Tag = f;
                    dropDevice.DropDownItems.Add(mnuItem);
                    mnuItem.Click += new EventHandler(mnuItem_Click);
                }
                if (_filters.VideoInputDevices.Count == 1)
                {
                    mnuItem_Click(dropDevice.DropDownItems[0], new EventArgs());
                }
            }
        }
        private void mnuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            dropDevice.Tag = dropDevice.DropDownItems.IndexOf(item);
            SelectDevice(item.Tag as Filter);
            dropDevice.Text = item.Name;
            foreach (ToolStripMenuItem i in dropDevice.DropDownItems)
            {
                i.Image = imageList1.Images[6];
            }
            item.Image = imageList1.Images[4];
        }
        public bool Check_Device(DataTable dtCheck, string deviceName, ref string configPara)
        {
            string checkName = string.Empty;
            deviceName = deviceName.Trim().ToLower();
            for (int i = 0; i < dtCheck.Rows.Count; i++)
            {
                checkName = dtCheck.Rows[i]["DeviceName"].ToString().Trim().ToLower();
                if (checkName.Equals(deviceName))
                {
                    configPara = dtCheck.Rows[i]["Para1"].ToString().Trim();
                    return true;
                }
            }
            return false;
        }
        private bool _sampleGrabber = false;
        private bool SampleGrabber
        {
            get { return this._sampleGrabber; }
            set
            {
                if ((this._capture != null) && (this._capture.AllowSampleGrabber))
                {
                    this._sampleGrabber = value;
                }
                else
                {
                    this._sampleGrabber = false;
                }
                if (this._sampleGrabber)
                {

                    if (this._capture != null)
                    {
                        this._capture.FrameEvent2 += new Capture.HeFrame(this.CaptureDone);
                    }
                }
                else
                {
                    if (this._capture != null)
                    {
                        this._capture.DisableEvent();
                        this._capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone);
                    }
                }
            }
        }
        private delegate void SaveCapture(PictureBox pb, string _no);
        bool _justCap = false;
        public void CaptureDone(System.Drawing.Bitmap e)
        {
            if (_justCap == false)
            {
                _justCap = true;
                if (pbShot1.ImageLocation == ""  || _indexImage == 1)
                {
                    SetImage_WhenGrabDone(e, pbShot1);
                    SaveImage(pbShot1, "1");
                    _indexImage = 0;
 
                }
                else if (pbShot2.ImageLocation == ""  || _indexImage == 2)
                {
                    SetImage_WhenGrabDone(e, pbShot2);
                    SaveImage(pbShot2, "2");
                    _indexImage = 0;
                }
                else if (pbShot3.ImageLocation == ""  || _indexImage == 3)
                {
                    SetImage_WhenGrabDone(e, pbShot3);
                    SaveImage(pbShot3, "3");
                    _indexImage = 0;
                }
                else if (pbShot4.ImageLocation == ""  || _indexImage == 4)
                {
                    SetImage_WhenGrabDone(e, pbShot4);
                    SaveImage(pbShot4, "4");
                    _indexImage = 0;
                }
                //else if ((pbShot5.ImageLocation == "" && _shotCount == 5) || _indexImage == 5)
                //{
                //    SetImage_WhenGrabDone(e, pbShot5);
                //    SaveImage(pbShot5, "5");
                //    _indexImage = 0;
                //}
            }
            // Show only the selected frame ...
            // If you want to capture all frames, then remove the next line
            //this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone); 
        }
        string[] _ConfigPara;
        private void Set_ConfigFromData(Filter dev)
        {
            if ((dropDevice.Tag == null ? -1 : (int)dropDevice.Tag) > -1)
            {
                string _ComputerName = Environment.MachineName;
                DataTable dtDevice = _config.Get_CauHinhCaptureSA(_ComputerName, dev.Name);

                if (dtDevice.Rows.Count > 0)
                {
                    if (dtDevice.Rows[0]["DeviceAlias"] == DBNull.Value)
                    {
                        cboMachineName.ComboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        cboMachineName.ComboBox.SelectedValue = dtDevice.Rows[0]["DeviceAlias"].ToString().Trim();
                    }
                    string config = string.Empty;
                    if (_CheckNeedConfig(dev.Name))
                    {
                        if (Check_Device(dtDevice, dev.Name, ref config))
                        {
                            _ConfigPara = config.Split(';');
                            Set_Config_ForCapture();
                        }
                    }

                }
            }
        }
        private void Set_Config_ForCapture()
        {
            if (_ConfigPara.Length > 2)
            {
                if (_ConfigPara[0] != "None")
                {
                    if (_capture != null)
                    {
                        if (this._capture.dxUtils != null)
                        {
                            if (this._capture.dxUtils.VideoDecoderAvail)
                            {
                                try
                                {
                                    AnalogVideoStandard a = (AnalogVideoStandard)Enum.Parse(typeof(AnalogVideoStandard), _ConfigPara[0]);
                                    this._capture.dxUtils.VideoStandard = a;
                                }
                                catch (Exception ex)
                                {
                                    // MessageBox.Show("Lỗi set config standard\n" + ex.ToString());
                                    this._capture.dxUtils.VideoStandard = AnalogVideoStandard.None;
                                }
                            }
                            else
                            {
                                this._capture.dxUtils.VideoStandard = AnalogVideoStandard.None;
                            }
                        }
                    }
                }
                if (_ConfigPara[1] != "None")
                {
                    _capture.VideoSource = _capture.VideoSources[int.Parse(_ConfigPara[1])];
                }
                if (WorkingServices.IsNumeric(_ConfigPara[2]))
                {
                    _capture.FrameRate = int.Parse(_ConfigPara[2]);
                }

                if (_ConfigPara.Length > 4)
                {
                    if (WorkingServices.IsNumeric(_ConfigPara[3]) && WorkingServices.IsNumeric(_ConfigPara[4]))
                    {
                        try
                        {
                            _capture.FrameSize = new System.Drawing.Size(int.Parse(_ConfigPara[3]), int.Parse(_ConfigPara[4]));
                        }
                        catch
                        {
                            LabServices_Helper.RecordError("Set framesize error", "Current :" + _capture.FrameSize.ToString() + Environment.NewLine + "Set: " + _ConfigPara[3] + ":" + _ConfigPara[4]);
                        }
                    }
                }

                if (_ConfigPara.Length > 5)
                {
                    Filter f;
                    for (int c = 0; c < _filters.VideoCompressors.Count; c++)
                    {
                        f = (Filter)_filters.VideoCompressors[c];
                        if (f.Name == _ConfigPara[5])
                        {
                            _capture.VideoCompressor = f;
                        }
                    }
                }
            }
        }
        public void StartCapture(PictureBox pb)
        {
            if ((dropDevice.Tag == null ? -1 : (int)dropDevice.Tag) > -1)
            {
                if (_capture.PreviewWindow == null)
                {
                    _capture.AllowSampleGrabber = true;
                    _capture.PreviewWindow = pb;
                    Start_Grabber();
                    btnStart.Text = "Dừng";
                    btnShot.Enabled = true;
                    btnRecord.Enabled = true;
                }
                else
                {
                    if (timerRecord.Enabled == false)
                    {
                        btnShot.Enabled = false;
                        btnRecord.Enabled = false;
                        btnStart.Text = "Bắt đầu";
                        _capture.PreviewWindow = null;
                        _capture.AllowSampleGrabber = false;
                        Start_Grabber();
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Bạn phải dừng ghi hình trước !");
                        return;
                    }
                }
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

                if (_capture != null)
                {
                    _capture.Dispose();
                    _capture = null;
                }

                // Get new video device
                videoDevice = dv;
                bool AudioViaPci = false;

                // Create capture object
                if ((videoDevice != null) || (audioDevice != null))
                {
                    _capture = new Capture(videoDevice, audioDevice, AudioViaPci);
                    Set_ConfigFromData(dv);
                    this._capture.FrameEvent2 += new Capture.HeFrame(this.CaptureDone);
                    _capture.RecFileMode = DirectX.Capture.Capture.RecFileModeType.Avi;
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "Select capture device", CommonAppVarsAndFunctions.UserID);
            }
        }
        private bool _CheckNeedConfig(string _DeviceName)
        {
            for (int i = 0; i < 5; i++)
            {
                string _dvName = CommonAppVarsAndFunctions.ArrayVideoCardActive[i];
                if (_DeviceName.Trim().Equals(_dvName))
                {
                    return false;
                }
            }

            //nếu kiểm tra xong ma ko thấy có thì ghi vào mảng
            for (int i = 0; i < 5; i++)
            {
                if (CommonAppVarsAndFunctions.ArrayVideoCardActive[i] == string.Empty || CommonAppVarsAndFunctions.ArrayVideoCardActive[i] == null)
                {
                    CommonAppVarsAndFunctions.ArrayVideoCardActive[i] = _DeviceName;
                    break;
                }
            }
            return true;

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartCapture(pbCapture);
        }
        #endregion

        private void txtHinh2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }
        int _curentImgRecord = 0;
        DateTime dtRecord = DateTime.Now;
        private void timerRecord_Tick(object sender, EventArgs e)
        {
            if (_curentImgRecord != 2)
            {
                TimeSpan ts = DateTime.Now - dtRecord;
                lblRecordTime.Text = ts.Minutes.ToString("N0") + ":" + ts.Seconds.ToString("N0");
                pbRecordStatus.SizeMode = PictureBoxSizeMode.StretchImage;
                pbRecordStatus.Image = imageList1.Images[2];
                _curentImgRecord = 2;
            }
            else
            {
                TimeSpan ts = DateTime.Now - dtRecord;
                lblRecordTime.Text = ts.Minutes.ToString("N0") + ":" + ts.Seconds.ToString("N0");
                pbRecordStatus.SizeMode = PictureBoxSizeMode.StretchImage;
                pbRecordStatus.Image = imageList1.Images[3];
                _curentImgRecord = 3;
            }
        }

        private void txtHinh1_Leave(object sender, EventArgs e)
        {
            if (cboChiDinhSieuAm.SelectedIndex != -1)
            {
                _sieuam.Update_ImagePrintChoice(txtHinh1.Text, txtHinh2.Text, txtSID.Text, cboChiDinhSieuAm.SelectedValue.ToString());
            }
        }

        private void txtHinh2_Leave(object sender, EventArgs e)
        {
            if (cboChiDinhSieuAm.SelectedIndex != -1)
            {
                _sieuam.Update_ImagePrintChoice(txtHinh1.Text, txtHinh2.Text, txtSID.Text, cboChiDinhSieuAm.SelectedValue.ToString());
            }
        }

        private void txtHinh1_KeyUp(object sender, KeyEventArgs e)
        {
            if (WorkingServices.IsNumeric(txtHinh1.Text))
            {
                if (double.Parse(txtHinh1.Text) > 5)
                {
                    CustomMessageBox.MSG_Information_OK("Nhập giá trị từ 1 đến 5");
                    txtHinh1.Text = "1";
                    txtHinh1.SelectAll();
                }
            }
        }

        private void txtHinh2_KeyUp(object sender, KeyEventArgs e)
        {
            if (WorkingServices.IsNumeric(txtHinh2.Text))
            {
                if (double.Parse(txtHinh2.Text) > 5)
                {
                    CustomMessageBox.MSG_Information_OK("Nhập giá trị từ 1 đến 5");
                    txtHinh2.Text = "1";
                    txtHinh2.SelectAll();
                }
            }
        }

        private void pbShot1_MouseLeave(object sender, EventArgs e)
        {
            pnPreview.Visible = false;
        }

        private void pbShot2_MouseLeave(object sender, EventArgs e)
        {
            pnPreview.Visible = false;
        }

        private void pbShot3_MouseLeave(object sender, EventArgs e)
        {
            pnPreview.Visible = false;
        }

        private void pbShot5_MouseLeave(object sender, EventArgs e)
        {
            pnPreview.Visible = false;
        }

        private void pbShot4_MouseLeave(object sender, EventArgs e)
        {
            pnPreview.Visible = false;
        }

        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            FrmTimBenhNhan frm = new FrmTimBenhNhan();
            frm.DtDateFromG = dtpDateIn.Value;
            frm.ServiceTypeID = ServiceType.ClsSieuAm.ToString();
            frm.List = true;
            frm.ShowDialog();
            if (frm.ReturnSEQ != "")
            {
              // ngày giờ trước để nếu có thay d6ỉ thì load danh sách trước
                dtpDateIn.Value = frm.ReturnDateIn; 
            //Gán giá trị trả về
                txtSEQ.Text = frm.ReturnSEQ;
                radAllPrint.Checked = true;
            //Load danh sách
                Load_TiepNhan();  
            }

            frm.Dispose();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string _userName = "", _userID = "";
            if (btnSign.Text == "Chữ ký khác")
            {
                frmIdentify frm = new frmIdentify();
                frm.pnMenu.Visible = true;
                frm.AdjustForm();
                frm.ShowDialog();
                _userID = frm.UserID;
                _userName = frm.UserName;

                if (_userID != "")
                {
                    btnSign.Text = "Bỏ chữ ký";
                    CommonAppVarsAndFunctions.UserIDTamSieuAm = _userID;
                    CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm = _userName;
                    lblSignOtherName.Text = _userName;
                }
            }
            else
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bỏ sử dụng chữ ký?"))
                {
                    btnSign.Text = "Chữ ký khác";
                    CommonAppVarsAndFunctions.UserIDTamSieuAm = "";
                    CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm = "";
                    lblSignOtherName.Text = string.Empty;
                }
            }
        }

        private void chkChuKyDangNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuKyDangNhap.Checked)
            {
                CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm = CommonAppVarsAndFunctions.UserName;
                CommonAppVarsAndFunctions.UserIDTamSieuAm = CommonAppVarsAndFunctions.UserID;
                btnSign.Enabled = false;
            }
            else
            {
                CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm = "";
                CommonAppVarsAndFunctions.UserIDTamSieuAm = "";
                btnSign.Enabled = true;
            }
        }

        private void cboUsersign_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Set_User();
        }
        private void Set_User()
        {
            if (cboUsersign.SelectedIndex != -1)
            {
                CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm = txtSignName.Text;
                CommonAppVarsAndFunctions.UserIDTamSieuAm = cboUsersign.SelectedValue.ToString().Trim();
            }
            else
            {
                CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm = "";
                CommonAppVarsAndFunctions.UserIDTamSieuAm = "";

            }
        }

        private void chkPrintted_CheckedChanged(object sender, EventArgs e)
        {
            cboUsersign.Enabled = !chkPrintted.Checked;

        }

        private void ricKetLuan_Load(object sender, EventArgs e)
        {

        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {
            lblSex.Text = LabServices_Helper.GetSexToLable(txtSex.Text);
        }

        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPatient.RowCount > 0)
            {
                txtSEQ.Text = dtgPatient.CurrentRow.Cells[SEQ.Name].Value.ToString().Trim();
            }
            Load_ChiDinhSieuAm();
            var matiepNhan = dtgPatient.CurrentRow != null ? dtgPatient.CurrentRow.Cells[MaTiepNhan.Name].Value.ToString().Trim() : "NULL";
            ucShowAlertTestResult1.Get_DanhSachKetQua(matiepNhan);
            gpKetQuaXetNghiem.Visible = ucShowAlertTestResult1.dtgKetQuaXN.RowCount > 0;
        }

        private void btnRefreshResult_Click(object sender, EventArgs e)
        {
            
        }

        private void chkValid_CheckedChanged(object sender, EventArgs e)
        {
            btnValid.ImageKey = (chkValid.Checked ? "Invalid.png" : "Valid.png");
            btnValid.Text = (chkValid.Checked ? "Hủy X.Nhận" : "Xác nhận");
            btnValid.Enabled = (chkValid.Checked ? CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA5") : CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, "SA4"));
            ricKetLuan.Enabled = !chkValid.Checked;
            ricTrang1.Enabled = !chkValid.Checked;
            pnImageFunction.Enabled = !chkValid.Checked;
        }

        private void ricTrang1_Load(object sender, EventArgs e)
        {

        }

        private void radNotPrint_Click(object sender, EventArgs e)
        {
            Load_TiepNhan();
            Load_ChiDinhSieuAm();
        }

        private void dtpTaiKham_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Load_TiepNhan();
        }

        private void txtFindName_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtFindName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LabServices_Helper.Filter_BindingSource(dtgPatient, bvPatient, _dtPatient, "TenBN", txtFindName.Text);
            }
        }
        int _odlKLWidth = 0;
        private void ricKetLuan_Enter(object sender, EventArgs e)
        {
            ricKetLuan.Height = 85;
            _odlKLWidth = ricKetLuan.Width;
            ricKetLuan.Width = ricKetLuan.Width + 74;
        }

        private void ricKetLuan_Leave(object sender, EventArgs e)
        {
            ricKetLuan.Height = 85;
            ricKetLuan.Width = _odlKLWidth;
        }

        private void txtHinh1_Click(object sender, EventArgs e)
        {
            txtHinh1.SelectAll();
        }

        private void txtLanIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtHinh2_Click(object sender, EventArgs e)
        {
            txtHinh2.SelectAll();
        }



    }
}
