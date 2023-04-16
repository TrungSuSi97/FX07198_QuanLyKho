using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.ThucThi.CanLamSang
{
    public partial class FrmDienTim : FrmTemplate
    {
        public FrmDienTim()
        {
            InitializeComponent();
        }
        
        C_Config config = new C_Config();
        C_Patient_DichVu_Khac p_dvKhac = new C_Patient_DichVu_Khac();
        DataTable dtPatientList = new DataTable();
        DataTable dtResult = new DataTable();
        bool _loading = false;
        private void btnZoomImage_Click(object sender, EventArgs e)
        {
            if (gbPInfo.Visible)
            {
                gbPInfo.Visible = false;
                btnZoomImage.Text = "Thu nhỏ";
            }
            else
            {
                gbPInfo.Visible = true;
                btnZoomImage.Text = "Phóng to";
            }
        }

        private void FrmDienTim_Load(object sender, EventArgs e)
        {
            Load_PatientList(false);
        }
        private void ClearControl()
        {
            txtSID.DataBindings.Clear();
            txtSID.Text = "";
            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = "";
            txtAddress.DataBindings.Clear();
            txtAddress.Text = "";
            txtAge.DataBindings.Clear();
            txtAge.Text = "";
            txtSex.DataBindings.Clear();
            txtSex.Text = "";
            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;
            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;
            lblSex.Text = "";
            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = "";
        }
        private void BindPatient(BindingSource bs)
        {
            ClearControl();
            txtSID.DataBindings.Clear();
            txtSID.DataBindings.Add("Text", bs, "MaTiepNhan");
            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            txtSex.DataBindings.Add("Text", bs, "GioiTinh");
            txtChanDoan.DataBindings.Add("Text", bs, "ChanDoan");
            dtpBirthday.DataBindings.Add("Value", bs, "SinhNhat", true, DataSourceUpdateMode.OnValidation, DateTime.Now);
        }
        private void Load_ChiDinh()
        {
            dtResult = p_dvKhac.Load_ChiDinh_DienTim(txtSID.Text);
            cboOrderList.LinkedColumnIndex1 = 1;
            cboOrderList.LinkedTextBox1 = txtOrderList;
            ControlExtension.BindDataToCobobox(dtResult, ref cboOrderList, "MaDVKhac", "MaDVKhac", "MaDVKhac,TenDVKhac", "50,250");

            pbImageResult.DataBindings.Clear();
            pbImageResult.DataBindings.Add("ImageLocation", dtResult, "NoiLuuHinhAnh");

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.DataBindings.Add("Text", dtResult, "GhiChu");

            cboUsersign.DataBindings.Clear();
            cboUsersign.DataBindings.Add("SelectedValue", dtResult, "NguoiKy");

            chkPrintted.DataBindings.Clear();
            chkPrintted.DataBindings.Add("Checked", dtResult, "DaInKQ");

            rchResult.DataBindings.Clear();
            rchResult.DataBindings.Add("Rtf", dtResult, "KetQua");
            if (dtResult.Rows.Count == 1)
                cboOrderList.SelectedIndex = 0;
        }
        private void Load_PatientList(bool _Print)
        {
            _loading = true;
            if (_Print && !radPrinted.Checked)
                txtSEQ.Text = "";
            Load_ThongTin(txtSEQ.Text);
            if (dtgPatient.RowCount == 0)
            {
                txtSEQ.Text = "";
            }
            Load_ChiDinh();
            _loading = false;


        }
        private void Load_ThongTin(string _SoTT)
        {
            dtPatientList = new DataTable();
            int _PrintType = 0;
            if (radNotPrint.Checked)
                _PrintType = 2;
            else if (radPrinted.Checked)
                _PrintType = 1;
            dtPatientList = p_dvKhac.Get_Patient_DVKhac("", dtpDateIn.Value.ToString("yyyy-MM-dd"), _PrintType);
            ControlExtension.BindDataToGrid(dtPatientList, ref dtgPatient, ref bvPatient);
            BindPatient(bvPatient.BindingSource);
            if (_SoTT != "")
            {
                txtSEQ.Text = _SoTT;
                SelectRow();
            }
        }
        private void SelectRow()
        {
            if (txtSEQ.Text.Length >= 4)
            {
                LabServices_Helper.Select_Row(dtgPatient, bvPatient, "SEQ", txtSEQ.Text);
            }
        }
        private string Get_ImageFolderName(DateTime _DateIn, string _MatiepNhan)
        {
            string _year = _DateIn.Year.ToString();
            string _date = _DateIn.ToString("ddMMyyyy");
            string _storefolder = _MatiepNhan;
            string _path = CommonAppVarsAndFunctions.EcgResultPath + @"\" + _year + @"\" + _date + @"\" + _storefolder;
            return _path;
        }
        private string Get_ImageFileName(DateTime _DateIn, string _MatiepNhan, string _IDDichVu)
        {
            string _year = _DateIn.Year.ToString();
            string _date = _DateIn.ToString("ddMMyyyy");
            string _storefolder = _MatiepNhan;
            string _fileName = _storefolder + "_" +_IDDichVu;
            string _path = CommonAppVarsAndFunctions.EcgResultPath + @"\" + _year + @"\" + _date + @"\" + _storefolder + @"\" + _fileName+ ".jpg";
            return _path;
        }

        private void Get_Image_FromECG_Device()
        {
            string _FolderSave = CommonAppVarsAndFunctions.EcgInsPath;
            if (Check_Exits_Folder(_FolderSave))
            {
                string _seq = (txtSID.Text.Split('-'))[1];
                string _FileName = _seq + "_" + dtpDateIn.Value.ToString("yyyyMMdd");
                string[] _arrFileFound = new string[3];
                int _arrCount = -1;
                string _result = "";
                //1001_20150103164805.txt : text
                //1001_20150103164805_6CH.bmp : image
                //1001_20150103164805_AVE.bmp :image
                DirectoryInfo dri = new System.IO.DirectoryInfo(_FolderSave);
                FileInfo[] fl = dri.GetFiles();
                if (fl.Length > 0)
                {
                    string _TempFileName = "";

                    //Kiểm tra và doc file có định dạng giống với số thứ tự và ngày
                    for (int i = 0; i < fl.Length; i++)
                    {
                        _TempFileName = fl[i].Name;
                        string[] _FilePart = _TempFileName.Split('_');
                        if (_FilePart.Length > 1)
                        {
                            string _CheckName = _FilePart[0] + "_" + _FilePart[1].Substring(0, 8);
                            if (_CheckName.Equals(_FileName))
                            {
                                if (_FilePart.Length == 2)
                                {
                                    //text file
                                    _result = Read_Result(fl[i]);
                                   // Backup_ECG_Result(_FolderSave, fl[i].Name);
                                }
                                else if (_FilePart.Length == 3)
                                {
                                    if (_FilePart[2].ToLower() == "6ch.bmp")
                                    {
                                        Image img = Image.FromFile(_FolderSave + @"\" + fl[i].Name);
                                        pb6CH.Image = img;
                                      //  Backup_ECG_Result(_FolderSave, fl[i].Name);
                                    }
                                    else if (_FilePart[2].ToLower() == "ave.bmp")
                                    {
                                        Image img = Image.FromFile(_FolderSave + @"\" + fl[i].Name);
                                        pbAVE.Image = img;
                                      ///  Backup_ECG_Result(_FolderSave, fl[i].Name);
                                    }
                                }
                            }
                        }
                    }
                    rchResult.Text = _result;
                    if (pb6CH.Image != null && pbAVE.Image != null && _result != "")
                    {
                        pbImageResult.Image.Dispose();
                        Image_Combine();
                    }
                }
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Nơi lưu hình ảnh trên máy không tồn tại!");
            }
        }
        private void Backup_ECG_Result(string _CurrentFolder, string _fileName)
        {
            if (!LabServices_Helper.CheckExistsFolder(_CurrentFolder + @"\Backup"))
            {
                LabServices_Helper.CreateFolder(_CurrentFolder + @"\Backup");
            }
            if (LabServices_Helper.CheckExistsFolder(_CurrentFolder + @"\Backup"))
            {
                File.Move(_CurrentFolder + @"\" + _fileName, _CurrentFolder + @"\Backup\" + _fileName);
            }
        }
        private void Image_Combine()
        {

            Rectangle cropArea = new Rectangle(new Point(10,70), new Size(992, 667));
            var Temp6CH = GraphicSupport.ResizeImage_NoAutoScale(GraphicSupport.CropImage((Bitmap)pb6CH.Image, cropArea), new Size(1024, 588));
            cropArea = new Rectangle(new Point(15, 568), new Size(992, 180));
            var TempAVE = GraphicSupport.ResizeImage_NoAutoScale(GraphicSupport.CropImage((Bitmap)pbAVE.Image, cropArea), new Size(1024, 180));

            Bitmap bmp = new Bitmap(1024, 768);
            Graphics grp = Graphics.FromImage(bmp);
            grp.DrawImage(Temp6CH, new Point(0, 0));
            grp.DrawImage(TempAVE, new Point(0, Temp6CH.Height));
            grp.Dispose();
            pbImageResult.Image = bmp;
        }
        private string Read_Result(FileInfo fi)
        {
            string _result = "";
            using (StreamReader sr = fi.OpenText())
            {
                int _readNext = 0;
                int _finishReadnext = 0;

                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (_readNext != 0 && _finishReadnext < _readNext)
                    {
                        if (_result == "")
                            _result = s.Replace("\0", "");
                        else
                            _result += Environment.NewLine + s.Replace("\0", "");
                        _finishReadnext++;
                    }
                    else if (_GetString(s, ref _readNext))
                    {
                        if (_result == "")
                            _result = s.Replace("\0", "");
                        else
                            _result += Environment.NewLine + s.Replace("\0", "");
                    }
                }
            }
            return _result;
        }
        private bool _GetString(string s,ref int readnext)
        {
            if (s.Contains("Heart Rate") ||
                s.Contains("PR Int.") ||
                s.Contains("QRS Int.") ||
                s.Contains("QT/QTc Int.") ||
                s.Contains("P/QRS/T Axis") ||
                s.Contains("RV5/SV1 Value") ||
                s.Contains("RV5+SV1 Value") ||
                s.Contains("Req.Doctor") ||
                s.Contains(" 1100") ||
                s.Contains(" 9110")
                )
            {
                readnext = 0;
                return true;

            }
            else if (s.Contains("Minnesota"))
            {
                readnext = 3;
                return true;
            }
            else
            {
                readnext = 0;
                return false;
            }
        }
        private void Save_Image(Image img, string _fileName)
        {
            img.Save(_fileName);
        }

        private bool Check_Exits_File( string _fileName)
        {
           return System.IO.File.Exists(_fileName);
        }
        private bool Check_Exits_Folder(string _foldername)
        {
            return System.IO.Directory.Exists(_foldername);
        }

        private string SaveImage(PictureBox pb, string _No, bool _askOverWrite)
        {
            string _MaDichVu = cboOrderList.SelectedValue.ToString();
            string _saveImageFolder = Get_ImageFolderName(dtpDateIn.Value, txtSID.Text);
            string _saveImageFilePath = Get_ImageFileName(dtpDateIn.Value, txtSID.Text, _MaDichVu);


            bool _overwrite = false;

            if (LabServices_Helper.CheckExistsFolder(_saveImageFolder) == false)
            {
                LabServices_Helper.CreateFolder(_saveImageFolder);
            }

            if (System.IO.File.Exists(_saveImageFilePath))
            {
                if (_askOverWrite)
                {
                    if (_overwrite)
                    {
                        UpdateAndSaveImage(pb, _saveImageFilePath, _overwrite);
                    }
                    else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hình ảnh đã lưu trước. \nLưu đè hình mới ?"))
                    {
                        UpdateAndSaveImage(pb, _saveImageFilePath, _overwrite);
                    }

                }
                else
                    UpdateAndSaveImage(pb, _saveImageFilePath, true);
            }
            else
            {
                UpdateAndSaveImage(pb, _saveImageFilePath, false);
            }
            return _saveImageFilePath;
        }

        private void UpdateAndSaveImage(PictureBox pb, string _SavePath, bool _Overwrite)
        {
            try
            {

                ImageFormat imf = ImageFormat.Jpeg;
                Bitmap bmp = new Bitmap(pb.Image);
               // Graphics grp = Graphics.FromImage(bmp);
               // grp.DrawImage((Bitmap)pb.Image, new Point(0, 0));
              //  grp.Dispose();
                pb.Image.Dispose();
                if (_Overwrite)
                {
                    LabServices_Helper.DeleteFile(_SavePath);
                }
                bmp.Save(_SavePath, imf);
                pb.Image = bmp;
                pb.ImageLocation = _SavePath;
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, this.Name + " - UpdateAndSaveImage", CommonAppVarsAndFunctions.UserID);
            }
        }

        //Hàm xóa hình
        private void Delete_Image(PictureBox pb, string _filename)
        {
            if (cboOrderList.SelectedIndex != -1)
            {
                if (LabServices_Helper.CheckExistsFileName(_filename))
                {
                    try
                    {
                        pb.Image.Dispose();
                        pb.Image = null;
                        LabServices_Helper.DeleteFile(_filename);
                        pb.ImageLocation = "";
                    }
                    catch (Exception ex)
                    {
                        ErrorService.GetFrameworkErrorMessage(ex, this.Name + " - Delete_Image", CommonAppVarsAndFunctions.UserID);
                    }
                }
            }
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            //if (txtSID.Text != "")
            //{
                Get_Image_FromECG_Device();
            //}
        }

        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_ChiDinh();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Load_PatientList(false);
        }

        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            FrmTimBenhNhan frm = new FrmTimBenhNhan();
            frm.DtDateFromG = dtpDateIn.Value;
            frm.ServiceTypeID = ServiceType.ClsDienTim.ToString();
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
               // Load_TiepNhan();
            }

            frm.Dispose();
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            Load_PatientList(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print_Result(true);
        }

        private void Print_Result(bool _isPrint)
        {
            if (dtPatientList.Rows.Count > 0 && txtSID.Text != "" && cboOrderList.SelectedIndex != -1)
            {
                SaveResult(false);
                string _PrinterName = "";
                if (listPrinter.Items.Count > 0)
                {
                    if (listPrinter.SelectedIndex == -1)
                    {
                        listPrinter.SelectedIndex = 0;
                    }
                    _PrinterName = listPrinter.SelectedItem.ToString();
                }
                p_dvKhac.In_Ket_DVDienTim(dtPatientList, bvPatient.BindingSource.Position, true, cboOrderList.SelectedValue.ToString().Trim(), _isPrint, _PrinterName, pbImageResult.Image);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print_Result(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveResult(true);
        }
        private void SaveResult(bool _askOverWrite)
        {
            if (txtSID.Text != "" && cboOrderList.SelectedIndex != -1)
            {
                string _MaDichVu = cboOrderList.SelectedValue.ToString().Trim();
                string _userSign = (cboUsersign.SelectedIndex == -1 ? "" : cboUsersign.SelectedValue.ToString());
                string _FolderSave = SaveImage(pbImageResult, _MaDichVu, _askOverWrite);
                p_dvKhac.Update_ImagePath(_FolderSave, txtSID.Text, _MaDichVu);
                p_dvKhac.CapNhat_KQ_DVKhac(txtSID.Text, _MaDichVu, rchResult.Rtf, "", "", "", "", "", "", "", "", "", "", txtGhiChu.Text, CommonAppVarsAndFunctions.UserID, _userSign);

            }
        }
    }
}
