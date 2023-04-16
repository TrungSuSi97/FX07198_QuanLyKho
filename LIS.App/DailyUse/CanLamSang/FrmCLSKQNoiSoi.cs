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
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.ThucThi.CanLamSang
{
    public partial class frmCLSKQNoiSoi : FrmTemplate
    {
        C_Patient pInfo = new C_Patient();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        DataTable dtPatient = new DataTable();
        C_Patient_NoiSoi NoiSoi = new C_Patient_NoiSoi();
        C_Config config = new C_Config();
        DateTime dtDateInG = new DateTime();

        private IMediaEventEx mediaEvent = null;
        const int WM_GRAPHNOTIFY = 0x8000 + 1;
        private Capture capture = null;
        private Filters filters;
        int _shotCount = 0;
        int CaptureResult;
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        public DateTime DtDateInG
        {
            get { return dtDateInG; }
            set { dtDateInG = value; }
        }
        string _MatiepNhanG = "";

        public string MatiepNhanG
        {
            get { return _MatiepNhanG; }
            set { _MatiepNhanG = value; }
        }
        int _indexImage = 0;
        bool _loading = false,
        _GrapimageSelected = true;

        bool _AllowEdit = false;
        bool _AllowInsert = false;
        public frmCLSKQNoiSoi()
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
            btnClear5.Enabled = btnClear4.Enabled = btnClear3.Enabled = btnClear2.Enabled = btnClear1.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS10");
            btnStart.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS9");
            btnSearchSEQ.Enabled = btnPreview.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS6");
            btnPrint.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS7");
            //Quyền nhập kết quả
            _AllowInsert = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS1");
            //Quyền sửa kết quả
            _AllowEdit = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS2");
        }
        private void ClearControl()
        {

            txtSID.DataBindings.Clear();
            txtSID.Text = "";
            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = "";
            txtAddress.DataBindings.Clear();
            txtAddress.Text = "";
            txtPhone.DataBindings.Clear();
            txtPhone.Text = "";
            txtEmail.DataBindings.Clear();
            txtEmail.Text = "";
            txtAge.DataBindings.Clear();
            txtAge.Text = "";
            txtSex.DataBindings.Clear();
            txtSex.Text = "";
            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;
            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;
            lblSex.Text = "";
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = "";
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = "";
            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = "";
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = "";
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = "";
            //cboKetQuaHP.DataBindings.Clear();
            //cboKetQuaHP.SelectedIndex = -1;
            //cboKyThuatHp.DataBindings.Clear();
            //cboKyThuatHp.SelectedIndex = -1;
        }
        private void SelectRow_SEQ()
        {
            bvPatient.BindingSource.Filter = string.Format("SEQ = {0} or TenBN like '%{0}%'", txtSEQ.Text);
        }
        private void Load_TiepNhan()
        {
            _loading = true;
            string _TempSEQ = txtSEQ.Text;
            int _PrintType = 0;
            if (radNotPrint.Checked)
                _PrintType = 2;
            else if (radPrinted.Checked)
                _PrintType = 1;
            dtPatient = NoiSoi.Get_Patient_NoiSoi("", dtpDateIn.Value.ToString("yyyy-MM-dd"), _PrintType);
            ControlExtension.BindDataToGrid(dtPatient, ref dtgPatient, ref bvPatient);
            BindPatient(bvPatient.BindingSource);
            if (dtgPatient.RowCount > 0)
            {
                if (_TempSEQ != "")
                {
                    txtSEQ.Text = _TempSEQ;
                    SelectRow_SEQ();
                }
            }
            else
            {
                txtSEQ.Text = "";
                Load_ChiDinhNoiSoi();
            }
            _loading = false;

        }
        private void Load_ChiDinhNoiSoi()
        {
            data.Get_CLS_KetQua_NoiSoi(cboChiDinh, " MaTiepNhan = '" + txtSID.Text + "'");
            BindResult(cboChiDinh);
            cboChiDinh.SelectedIndex = -1;
            if (cboChiDinh.Items.Count > 0)
            {
                cboChiDinh.SelectedIndex = 0;
            }
                
        }
        private void BindResult(CustomComboBox cbo)
        {
            ricTrang1.DataBindings.Clear();
            ricTrang1.Rtf = "";
            ricTrang1.DataBindings.Add("Rtf", cbo.DataSource, "NoiDung1");

            ricTrang2.DataBindings.Clear();
            ricTrang2.Rtf = "";
            ricTrang2.DataBindings.Add("Rtf", cbo.DataSource, "NoiDung2");

            ricKetLuan.DataBindings.Clear();
            ricKetLuan.Rtf = "";
            ricKetLuan.DataBindings.Add("Rtf", cbo.DataSource, "Ketluan");

            //txtSoTrang.DataBindings.Clear();
            //txtSoTrang.Text = "1";
            //txtSoTrang.DataBindings.Add("Text", cbo.DataSource, "SoTrangIn");
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

            cboMayNoiSoi.DataBindings.Clear();
            cboMayNoiSoi.SelectedIndex = -1;
            cboMayNoiSoi.DataBindings.Add("SelectedValue", cbo.DataSource, "MayNoiSoi");

            cboKyThuatHp.DataBindings.Clear();
            cboKyThuatHp.SelectedIndex = -1;
            cboKyThuatHp.DataBindings.Add("SelectedValue", cbo.DataSource, "KyThuatHP");

            txtKetQuaHP.DataBindings.Clear();
            txtKetQuaHP.Text = "";
            txtKetQuaHP.DataBindings.Add("Text", cbo.DataSource, "KetQuaHP");

            txtDeNghi.DataBindings.Clear();
            txtDeNghi.Text = "";
            txtDeNghi.DataBindings.Add("Text", cbo.DataSource, "DeNghi");


        }
        private void BindPatient(BindingSource bs)
        {
            ClearControl();

            txtSID.DataBindings.Clear();
            txtSID.DataBindings.Add("Text", bs, "MaTiepNhan");

            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
            txtPhone.DataBindings.Add("Text", bs, "SDT");
            txtEmail.DataBindings.Add("Text", bs, "Email");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            //txtComment.DataBindings.Add("Text", dt, "KetLuan");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            //chkDuKQ.DataBindings.Add("Checked", dt, "DuKQXN");
            //chkDaXacNhan.DataBindings.Add("Checked", dt, "ValidKQXN");
            //chkDaIn.DataBindings.Add("Checked", dt, "DaInKQXN");
            txtSex.DataBindings.Add("Text", bs, "GioiTinh");
            txtLanIn.DataBindings.Add("Text", bs, "LanInNoiSoi");
            txtTGIn.DataBindings.Add("Text", bs, "ThoiGianInNoiSoi", true, DataSourceUpdateMode.Never, null, "dd/MM/yyyy HH:mm");
            txtChanDoan.DataBindings.Add("Text", bs, "ChanDoan");
            dtpBirthday.DataBindings.Add("Value", bs, "SinhNhat", true, DataSourceUpdateMode.OnValidation, DateTime.Now);
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
                capture.GrapImg();
            }
        }
        private void frmKQNoiSoi_Load(object sender, EventArgs e)
        { 
            Check_EnableControl();
            GetDevice_Capture();

            LabServices_Helper.LoadPrinterName(listPrinter, "PrintResult", false);
            sysConfig.Get_DMMayNS(cboMayNoiSoi);
            sysConfig.Get_DM_NoiSoi_KyThuatHP(cboKyThuatHp, txtKyThuatHP);
            sysConfig.Get_DM_NoiSoi_KetQuaHP(cboKetQuaHP, txtKetQuaHP);
            SetSizeModePictureBox();
         
            txtSEQ.Focus();
            if (_MatiepNhanG != "")
            {

                txtSEQ.Text = _MatiepNhanG;
                dtpDateIn.Value = dtDateInG;
            }
            else
                Load_TiepNhan();

            C_NguoiDung user = new C_NguoiDung();
            user.Get_UserSign(cboUsersign, ServiceType.ClsNoiSoi, " and d.MaNguoiDung not in ('admin')");
            Set_Sign();

        }
        private void Set_Sign()
        {
            if (CommonAppVarsAndFunctions.UserIDTamSieuAm != "")
            {
                cboUsersign.SelectedValue = CommonAppVarsAndFunctions.UserIDTamSieuAm;
            }
        }
        private void CheckLoad_Image()
        {
            string _matiepnhan = txtSID.Text;
            string _date = dtpDateIn.Value.ToString("ddMMyyyy");
            string _year = dtpDateIn.Value.Year.ToString();
            string _month = dtpDateIn.Value.Month.ToString();
            string _path = CommonAppVarsAndFunctions.CaptureImagePathNs + @"\" + _year + @"\" + _month + @"\" + _date + @"\" + _matiepnhan + @"\" + _matiepnhan + "_" + cboChiDinh.SelectedValue.ToString();
            if (System.IO.File.Exists(_path + "_1.jpg"))
            {
                LoadImage(_path + "_1", pbShot1);
            }
            else
            {
                pbShot1.Image = null;
            }
            if (System.IO.File.Exists(_path + "_2.jpg"))
            {
                LoadImage(_path + "_2", pbShot2);
            }
            else
            {
                pbShot2.Image = null;
            }
            if (System.IO.File.Exists(_path + "_3.jpg"))
            {
                LoadImage(_path + "_3", pbShot3);
            }
            else
            {
                pbShot3.Image = null;
            }
        }
        private void LoadImage(string _path, PictureBox pb)
        {
            string _dir = _path + ".jpg";
            pb.Image = Image.FromFile(_dir);
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
            if (cboChiDinh.SelectedIndex != -1)
            {
                string validText = (chkValid.Checked ? Common.CommonConstant.InValid:Common.CommonConstant.IsValided  );
                if (chkValid.Checked)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy xác nhận kết quả ?"))
                    {
                        NoiSoi.XacNhan_KQ_NoiSoi(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), cboChiDinh.SelectedValue.ToString(), validText, false, CommonAppVarsAndFunctions.UserID);
                        Load_TiepNhan();
                    }
                }
                else
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận kết quả ?"))
                    {
                        btnSave_Click(sender, e);
                        NoiSoi.XacNhan_KQ_NoiSoi(txtSID.Text, cboChiDinh.SelectedValue.ToString(), validText, true, CommonAppVarsAndFunctions.UserID);
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
            }
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            Load_TiepNhan();
        }

        private void txtSEQ_Enter(object sender, EventArgs e)
        {
            txtSEQ.BackColor = Color.LightGreen;
        }

        private void txtSEQ_Leave(object sender, EventArgs e)
        {
            txtSEQ.BackColor = Color.White;
        }

        private void dtpDateIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtSEQ);
        }

        private void txtSoTrang_TextChanged(object sender, EventArgs e)
        {
            //if (txtSoTrang.Text == "1")
            //{
                splitKQ.Panel2.Hide();
                splitKQ.SplitterPosition = splitKQ.Size.Width;

            //}
            //else if (txtSoTrang.Text == "2")
            //{
            //    splitKQ.SplitterPosition = splitKQ.Size.Width / 2;
            //    splitKQ.Panel2.Show();
            //}
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

        private void cboChiDinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChiDinh.SelectedIndex != -1 && cboChiDinh.SelectedValue != null)
            {
                //BindResult(cboChiDinh);
                //CheckLoad_Image();
            }
            else
            {
                //ricTrang1.DataBindings.Clear();
                //ricTrang1.Rtf = "";
                //ricTrang2.DataBindings.Clear();
                //ricTrang2.Rtf = "";
                ////txtSoTrang.DataBindings.Clear();
                ////txtSoTrang.Text = "2";
                
                //cboMayNoiSoi.DataBindings.Clear();
                //cboMayNoiSoi.SelectedIndex = -1;

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
            if (cboChiDinh.SelectedIndex != -1)
            {
                RichTextBox rcT = new RichTextBox();
                rcT.Rtf = ricKetLuan.Rtf;
                Find_ReplaceComment(ricKetLuan.Text, ricKetLuan.Text.ToUpper(), 0, rcT);
                ricKetLuan.Rtf = rcT.Rtf;
                string _KyThuatHP = (cboKyThuatHp.SelectedIndex == -1 ? "" : cboKyThuatHp.SelectedValue.ToString().Trim());
                string _KetQuaHP = txtKetQuaHP.Text;
                string _deNghi = txtDeNghi.Text;
                NoiSoi.CapNhat_KQ_NoiSoi(txtSID.Text, cboChiDinh.SelectedValue.ToString(), ricTrang1.Rtf, ricTrang2.Rtf, ricKetLuan.Rtf, CommonAppVarsAndFunctions.UserID, (cboMayNoiSoi.SelectedIndex == -1 ? "" : cboMayNoiSoi.SelectedValue.ToString()), (cboUsersign.SelectedIndex == -1 ? "" : cboUsersign.SelectedValue.ToString().Trim()), _KyThuatHP, _KetQuaHP, _deNghi);
            }
        }

        private void Find_ReplaceComment(string Find, string Replace, int startIndex, RichTextBox rt)
        {
            int _starIndex = -1;
            _starIndex = rt.Text.IndexOf(Find, startIndex, StringComparison.Ordinal);

            if (_starIndex != -1)
            {
                rt.Select(_starIndex, Find.Length);
                rt.SelectedText = Replace;
               //Find_ReplaceComment(Find, Replace, _starIndex, rt);
            }
        }

        private void PrintResult(DataTable dtInfo, int _index, bool _Print)
        {
            Set_User();
            Save_Result();
            if (cboUsersign.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên!");
                return;
            }
            else if ((txtHinh1.Text == "" || txtHinh1.Text == "0") && (txtHinh2.Text == "" || txtHinh2.Text == "0"))
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn hình in!");
                return;
            }
            DataTable dtPrint = new DataTable();
            string _MaSoMau = (cboChiDinh.SelectedIndex != -1 ? cboChiDinh.SelectedValue.ToString() : "");
            dtPrint = NoiSoi.DuLieuIn_NoiSoi(dtInfo, _index, false, _MaSoMau);
            if (dtPrint.Rows.Count > 0)
            {
                progressPrint.Maximum = 6;
                progressPrint.Visible = true;
                progressPrint.Value = 0;
                //FrmReport report = new FrmReport();
                //string _PrinterName = "";
                //if (listPrinter.Items.Count > 0)
                //{
                //    if (listPrinter.SelectedIndex == -1)
                //    {
                //        listPrinter.SelectedIndex = 0;
                //    }
                //    progressPrint.Value++;
                //   _PrinterName = listPrinter.SelectedItem.ToString();
                //}
                //progressPrint.Value++;

                //Reports.rpKQNoiSoi rp = new Reports.rpKQNoiSoi();

                //if (report.Excute_Show_Print_Report(rp, dtPrint, "NS", false, false, !_Print, _Print, _PrinterName, false))
                //{
                //    NoiSoi.CapNhat_In_KQ_NoiSoi(txtSID.Text, (cboUsersign.SelectedIndex == -1 ? "" : cboUsersign.SelectedValue.ToString().Trim()), _MaSoMau);
                //}
                //report.Dispose();
                //progressPrint.Value++;
                Load_TiepNhan();
                //Nếu số dòng bệnh nhân bang 0 thì cellenter không thực hiện nên gọi load
                if (dtgPatient.RowCount == 0)
                {
                    Load_ChiDinhNoiSoi();
                }
                progressPrint.Visible = false;
            }
            else
            {
               CustomMessageBox.MSG_Information_OK("Không có dữ liệu để in !");
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PrintResult(dtPatient, bvPatient.BindingSource.Position, false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtPatient.Rows.Count > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả?"))
                {
                    PrintResult(dtPatient, bvPatient.BindingSource.Position, true);
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
            string _date = dtpDateIn.Value.ToString("ddMMyyyy");
            string _patientFolder = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
            string _saveVideoFolder = CommonAppVarsAndFunctions.VideoOuptPathNs + @"\" + _date + @"\" + _patientFolder;
            string _saveVideoFilePath = _saveVideoFolder + @"\" + _patientFolder + "_" + cboChiDinh.SelectedValue.ToString() + ".avi";
            if (LabServices_Helper.CheckExistsFolder(_saveVideoFolder) == false)
            {
                LabServices_Helper.CreateFolder(_saveVideoFolder);
            }
            if (System.IO.File.Exists(_saveVideoFilePath))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Video đã có. \nLưu đè video mới ?"))
                {
                    LabServices_Helper.DeleteFile(_saveVideoFilePath);
                }
            }
            return _saveVideoFilePath;
        }
        //Hàm để lưu và gán hình sau khi grab
        private void SaveImage(PictureBox pb, string _No)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SaveCapture (SaveImage), new object[] { pb, _No });
                return;
            }
            string _MaSoMau = cboChiDinh.SelectedValue.ToString();
            string _date = dtpDateIn.Value.ToString("ddMMyyyy");
            string _year = dtpDateIn.Value.Year.ToString();
            string _month = dtpDateIn.Value.Month.ToString();
            string _patientFolder = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
            string _saveImageFolder = CommonAppVarsAndFunctions.CaptureImagePathNs + @"\" + _year + @"\" + _month + @"\" + _date + @"\" + _patientFolder;
            string _saveImageFilePath = _saveImageFolder + @"\" + _patientFolder + "_" +  _MaSoMau + "_" + _No + ".jpg";

            bool _overwrite = false;

            if (LabServices_Helper.CheckExistsFolder(_saveImageFolder) == false)
            {
                LabServices_Helper.CreateFolder(_saveImageFolder);
            }

            if (System.IO.File.Exists(_saveImageFilePath))
            {
                if (_overwrite)
                {
                    UpdateAndSaveImage(pb, _saveImageFilePath, _patientFolder,_MaSoMau, _No, _overwrite);
                }
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hình ảnh đã lưu trước. \nLưu đè hình mới ?"))
                {
                    UpdateAndSaveImage(pb, _saveImageFilePath, _patientFolder,_MaSoMau, _No, _overwrite);
                }
            }
            else
            {
                UpdateAndSaveImage(pb, _saveImageFilePath, _patientFolder,_MaSoMau, _No, false);
            }
        }

        private void UpdateAndSaveImage(PictureBox pb, string _SavePath, string _Matiepdoan,string _MaSoMau, string _No, bool _Overwrite)
        {
            try
            {
                ImageFormat imf = ImageFormat.Jpeg;
                if (_Overwrite)
                {
                    pb.Image.Dispose();
                    LabServices_Helper.DeleteFile(_SavePath);
                }
                int _currentHeight = pb.Image.Height;
                int _Currentwidth = pb.Image.Width;
                Rectangle cropArea = new Rectangle(new Point(14, 0), new Size((int)(_Currentwidth - (_Currentwidth * 0.35)), _currentHeight));
                var Temp =  GraphicSupport.CropImage((Bitmap)pb.Image, cropArea);
                pb.Image.Dispose();
                pb.Image = Temp;
                pb.Image.Save(_SavePath, imf);
                NoiSoi.Update_ImagePath(_SavePath, _No, _Matiepdoan, _MaSoMau);
                pb.ImageLocation = _SavePath;
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, " frmCLSKQNoiSoi - UpdateAndSaveImage", CommonAppVarsAndFunctions.UserID);
            }
        }

        //Hàm xóa hình
        private void Delete_Image(PictureBox pb, string _No)
        {
            if (cboChiDinh.SelectedIndex != -1)
            {
                string _Folder = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
                string _path = pb.ImageLocation;
                string _MaSoMau = cboChiDinh.SelectedValue.ToString();
                if (LabServices_Helper.CheckExistsFileName(_path))
                {
                    try
                    {
                        pb.Image.Dispose();
                        pb.Image = null;
                        LabServices_Helper.DeleteFile(_path);
                        NoiSoi.Update_ImagePath("", _No, _Folder, _MaSoMau);
                        pb.ImageLocation = "";
                    }
                    catch (Exception ex)
                    {
                        ErrorService.GetFrameworkErrorMessage(ex, "frmCLSKQNoiSoi - Delete_Image", CommonAppVarsAndFunctions.UserID);
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
        private void frmKQNoiSoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
            {
                if (capture.PreviewWindow != null)
                {
                    CustomMessageBox.MSG_Waring_OK("HÃY TẮT THIẾT BỊ TRƯỚC KHI ĐÓNG FORM !");
                    e.Cancel = true;
                }
                else
                {
                    capture.DisposeSampleGrabber();
                    capture.Dispose();
                }
            }
        }

        private void frmKQNoiSoi_Activated(object sender, EventArgs e)
        {
            txtSEQ.Focus();
        }

        private void btnGet1_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 1;
            _GrapimageSelected = true;
            capture.GrapImg();
        }

        private void btnGet2_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 2;
            _GrapimageSelected = true;
            capture.GrapImg();
        }

        private void btnGet3_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 3;
            _GrapimageSelected = true;
            capture.GrapImg();
        }

        private void btnGet4_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 4;
            _GrapimageSelected = true;
            capture.GrapImg();
        }

        private void btnGet5_Click(object sender, EventArgs e)
        {
            _justCap = false;
            _indexImage = 5;
            _GrapimageSelected = true;
            capture.GrapImg();
        }
        private void btnClear1_Click(object sender, EventArgs e)
        {
            if (pbShot1.ImageLocation != "")
            {
                Delete_Image(pbShot1, "1");
            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            if (pbShot2.ImageLocation != "")
            {
                Delete_Image(pbShot2, "2");
            }
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            if (pbShot3.ImageLocation != "")
            {
                Delete_Image(pbShot3, "3");
            }
        }
        private void btnClear4_Click(object sender, EventArgs e)
        {
            if (pbShot4.ImageLocation != "")
            {
                Delete_Image(pbShot4, "4");
            }
        }
        private void btnClear5_Click(object sender, EventArgs e)
        {
            if (pbShot5.ImageLocation != "")
            {
                Delete_Image(pbShot5, "5");
            }
        }

        private void btnDanhSachBN_Click(object sender, EventArgs e)
        {

        }

        private void btnInValid_Click(object sender, EventArgs e)
        {
            if (cboChiDinh.SelectedIndex != -1)
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
                    capture.Filename = GetRecordFile();
                    capture.Start();
                    btnRecord.Text = "Dừng ghi";
                    dtRecord = DateTime.Now;
                    pnRecord.Visible = true;
                    timerRecord.Start();
                }
                else
                {
                    timerRecord.Stop();
                    pnRecord.Visible = false;
                    capture.Stop();
                    btnRecord.Text = "Ghi hình";
                }
            }
            catch (Exception ex)
            {
                capture.Stop();
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
        public void GetDevice_Capture()
        {
            string _log = "";
            _log = "StartcaptureDevice";
            try
            {
                _log += Environment.NewLine + " -- Create new filter";
                filters = new Filters();
            }
            catch (Exception ex)
            {
                _log += Environment.NewLine + " -- Create new filter fail";
                filters = null;
              //  CustomMessageBox.MSG_Error_OK(ex, "Get filter");
                return;
            }
            string _AliasName = "";
            Filter f;
            // Load video devices
            Filter videoDevice = null;
            _log += Environment.NewLine + " -- Check capture";
            if (capture != null)
            {
                _log += Environment.NewLine + " -- Capture not null";
                videoDevice = capture.VideoDevice;
            }
            else
            {
                _log += Environment.NewLine + " -- Capture is null";
            }
            ListViewItem item = null;
           // MessageBox.Show("Có: " + filters.VideoInputDevices.Count.ToString());
            if (filters.VideoInputDevices.Count > 0)
            {
                for (int c = 0; c < filters.VideoInputDevices.Count; c++)
                {
                    f = filters.VideoInputDevices[c];

                    DataTable dtDevice = config.Get_CauHinhCaptureNS(Environment.MachineName.Trim(), f.Name);
                    if (dtDevice.Rows.Count > 0)
                    {
                        _AliasName = dtDevice.Rows[0]["TenMay"].ToString();
                    }
                    else
                    {
                        _AliasName = "";
                    }
                    item = new ListViewItem((_AliasName == "" ? f.Name : _AliasName));
                    item.Tag = f;
                    lstDeviceList.Items.Add(item);
                }
            }
            LabServices_Helper.RecordError("Get_Filter_NS", _log);
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
        private delegate void SaveCapture(PictureBox pb, string _no);
        bool _justCap = false;
        public void CaptureDone(System.Drawing.Bitmap e)
        {
            if (_justCap == false)
            {
                _justCap = true;
                if ((pbShot1.ImageLocation == "") || _indexImage == 1)
                {
                    SetImage_WhenGrabDone(e, pbShot1);
                    SaveImage(pbShot1, "1");
                    _indexImage = 0;
 
                }
                else if ((pbShot2.ImageLocation == "") || _indexImage == 2)
                {
                    SetImage_WhenGrabDone(e, pbShot2);
                    SaveImage(pbShot2, "2");
                    _indexImage = 0;
                }
                else if ((pbShot3.ImageLocation == "") || _indexImage == 3)
                {
                    SetImage_WhenGrabDone(e, pbShot3);
                    SaveImage(pbShot3, "3");
                    _indexImage = 0;
                }
                else if ((pbShot4.ImageLocation == "") || _indexImage == 4)
                {
                    SetImage_WhenGrabDone(e, pbShot4);
                    SaveImage(pbShot4, "4");
                    _indexImage = 0;
                }
                else if ((pbShot5.ImageLocation == "") || _indexImage == 5)
                {
                    SetImage_WhenGrabDone(e, pbShot5);
                    SaveImage(pbShot5, "5");
                    _indexImage = 0;
                }
            }
            // Show only the selected frame ...
            // If you want to capture all frames, then remove the next line
            //this.capture.FrameEvent2 -= new Capture.HeFrame(this.CaptureDone); 
        }
        string[] _ConfigPara;
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
                    if (dtDevice.Rows[0]["DeviceAlias"] == DBNull.Value)
                    {
                        cboMayNoiSoi.SelectedIndex = -1;
                    }
                    else
                    {
                        cboMayNoiSoi.SelectedValue = dtDevice.Rows[0]["DeviceAlias"].ToString().Trim();

                    }
                    string _config = "";
                    if (_CheckNeedConfig(dev.Name))
                    {
                        if (Check_Device(dtDevice, dev.Name, ref _config))
                        {
                            _ConfigPara = _config.Split(';');
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
                    if (capture != null)
                    {
                        if (this.capture.dxUtils != null)
                        {
                            if (this.capture.dxUtils.VideoDecoderAvail)
                            {
                                try
                                {
                                    AnalogVideoStandard a = (AnalogVideoStandard)Enum.Parse(typeof(AnalogVideoStandard), _ConfigPara[0]);
                                    this.capture.dxUtils.VideoStandard = a;
                                }
                                catch (Exception ex)
                                {
                                    // MessageBox.Show("Lỗi set config standard\n" + ex.ToString());
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
                if (_ConfigPara[1] != "None")
                {
                    capture.VideoSource = capture.VideoSources[int.Parse(_ConfigPara[1])];
                }
                if (LabServices_Helper.IsNumeric(_ConfigPara[2]))
                {
                    capture.FrameRate = int.Parse(_ConfigPara[2]);
                }

                if (_ConfigPara.Length > 4)
                {
                    if (LabServices_Helper.IsNumeric(_ConfigPara[3]) && LabServices_Helper.IsNumeric(_ConfigPara[4]))
                    {
                        try
                        {
                            capture.FrameSize = new System.Drawing.Size(int.Parse(_ConfigPara[3]), int.Parse(_ConfigPara[4]));
                        }
                        catch
                        {
                            LabServices_Helper.RecordError("Set framesize error", "Current :" + capture.FrameSize.ToString() + Environment.NewLine + "Set: " + _ConfigPara[3] + ":" + _ConfigPara[4]);
                        }
                    }
                }

                if (_ConfigPara.Length > 5)
                {
                    Filter f;
                    for (int c = 0; c < filters.VideoCompressors.Count; c++)
                    {
                        f = (Filter)filters.VideoCompressors[c];
                        if (f.Name == _ConfigPara[5])
                        {
                            capture.VideoCompressor = f;
                        }
                    }
                }
            }
        }
        public void StartCapture(PictureBox pb)
        {
            if (lstDeviceList.SelectedItems.Count > 0)
            {
                if (capture.PreviewWindow == null)
                {
                    capture.AllowSampleGrabber = true;
                    capture.PreviewWindow = pb;
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
                        capture.PreviewWindow = null;
                        capture.AllowSampleGrabber = false;
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
                    Set_ConfigFromData();
                    this.capture.FrameEvent2 += new Capture.HeFrame(this.CaptureDone);
                    capture.RecFileMode = DirectX.Capture.Capture.RecFileModeType.Avi;
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
        private void lstDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDeviceList.SelectedItems.Count > 0)
            {
                SelectDevice(lstDeviceList.SelectedItems[0].Tag as Filter);
            }
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
            if (cboChiDinh.SelectedIndex != -1)
            {
                NoiSoi.Update_ImagePrintChoice(txtHinh1.Text, txtHinh2.Text, txtSID.Text, cboChiDinh.SelectedValue.ToString());
            }
        }

        private void txtHinh2_Leave(object sender, EventArgs e)
        {
            if (cboChiDinh.SelectedIndex != -1)
            {
                NoiSoi.Update_ImagePrintChoice(txtHinh1.Text, txtHinh2.Text, txtSID.Text, cboChiDinh.SelectedValue.ToString());
            }
        }

        private void txtHinh1_KeyUp(object sender, KeyEventArgs e)
        {
            if (LabServices_Helper.IsNumeric(txtHinh1.Text))
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
            if (LabServices_Helper.IsNumeric(txtHinh2.Text))
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
            frm.ServiceTypeID = ServiceType.ClsNoiSoi.ToString();
            frm.List = true;
            frm.ShowDialog();
            if (frm.ReturnSEQ != "")
            {
              // ngày giờ trước để nếu có thay đổi thì load danh sách trước
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
                    lblSignOtherName.Text = "";
                }
            }
        }

        private void chkChuKyDangNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuKyDangNhap.Checked)
            {
                CommonAppVarsAndFunctions.TempSignNameNoiSoi = CommonAppVarsAndFunctions.UserName;
                CommonAppVarsAndFunctions.TempSignIdNoiSoi = CommonAppVarsAndFunctions.UserID;
                btnSign.Enabled = false;
            }
            else
            {
                CommonAppVarsAndFunctions.TempSignNameNoiSoi = "";
                CommonAppVarsAndFunctions.TempSignIdNoiSoi = "";
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
                CommonAppVarsAndFunctions.TempSignNameNoiSoi = txtSignName.Text;
                CommonAppVarsAndFunctions.TempSignIdNoiSoi = cboUsersign.SelectedValue.ToString().Trim();
            }
            else
            {
                CommonAppVarsAndFunctions.TempSignNameNoiSoi = "";
                CommonAppVarsAndFunctions.TempSignIdNoiSoi = "";

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
            Load_ChiDinhNoiSoi();
        }

        private void btnRefreshResult_Click(object sender, EventArgs e)
        {
            Load_TiepNhan();
        }

        private void chkValid_CheckedChanged(object sender, EventArgs e)
        {
            btnValid.ImageKey = (chkValid.Checked ? "Invalid.png" : "Valid.png");
            btnValid.Text = (chkValid.Checked ? "Hủy X.Nhận" : "Xác nhận");
            btnValid.Enabled = (chkValid.Checked ? CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS5") : CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, "NS4"));
            ricKetLuan.Enabled = !chkValid.Checked;
            ricTrang1.Enabled = !chkValid.Checked;
            pnImageFunction.Enabled = !chkValid.Checked;
            cboKetQuaHP.Enabled = !chkValid.Checked;
            txtKetQuaHP.ReadOnly = chkValid.Checked;
            txtDeNghi.ReadOnly = chkValid.Checked;
            cboKyThuatHp.Enabled = !chkValid.Checked;
        }

        private void ricTrang1_Load(object sender, EventArgs e)
        {

        }

        private void radNotPrint_Click(object sender, EventArgs e)
        {
            Load_TiepNhan();
            Load_ChiDinhNoiSoi();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!pnCaptureMain.Visible)
            {
                if (lstDeviceList.SelectedItems.Count > 0)
                {
                    string[] _Panelsize = CommonAppVarsAndFunctions.PreviewCaptureNs.Split('x');
                    pnCaptureMain.Size = new System.Drawing.Size(int.Parse(_Panelsize[0]) + 10, int.Parse(_Panelsize[1]) + 5);
                    pnCaptureMain.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - pnCaptureMain.Width / 2 , (Screen.PrimaryScreen.WorkingArea.Height / 2 - pnCaptureMain.Height / 2) / 2);
                    pnCaptureMain.BringToFront();
                    pnCaptureMain.Visible = true;
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn thiết bị!");
            }
        }

        private void btnHideCaptureMain_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                if (capture.PreviewWindow != null)
                {
                    CustomMessageBox.MSG_Waring_OK("HÃY TẮT THIẾT BỊ TRƯỚC KHI ĐÓNG !");
                }
                else
                {
                    pnCaptureMain.Visible = false;
                }
            }
            else
                pnCaptureMain.Visible = false;
        }
    }
}
