using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Data.HIS.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmTiepNhanBenhNhan : FrmTemplate
    {
        public FrmTiepNhanBenhNhan()
        {
            InitializeComponent();
        }
        private BENHNHAN_TIEPNHAN objBenhnhanTiepnhan;
        private BENHNHAN_TIEPNHAN objBenhnhanTiepnhanOld;
        private BENHNHAN_CLS_XETNGHIEM objBenhNhanClsXetNghiem;
        private readonly IPatientInformationService informationService = new PatientInformationService();
        private readonly ITestResultService testService = new TestResultService();
        private readonly IMicrobilogyTestResultService _microbilogyTestResultService = new MicrobilogyTestResultService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IConnectHISService _iHISService = new ConnectHISService();

        private HisConnection labIMSWebConfigInfo;
        private C_Patient_SieuAm p_sieuam = new C_Patient_SieuAm();
        private C_Patient_XQuang p_xquang = new C_Patient_XQuang();
        private C_Patient_NoiSoi p_noisoi = new C_Patient_NoiSoi();
        private C_Patient_KhamBenh p_khambenh = new C_Patient_KhamBenh();
        private C_Patient_DichVu_Khac p_dvkhac = new C_Patient_DichVu_Khac();
        private THUPHI_THUOC_DAL thuphiThuocDAL = new THUPHI_THUOC_DAL();

        private bool _isBinding = false;
        private bool _loading;
        //Biến để biết đang trong che do nhap mới
        private bool _isAddMode = false;
        //Biến để biết đang trong che do chỉnh sửa
        private bool _isEditMode = false;

        public string MaBenhNhan { get; set; }
        public bool AddNew { get; set; }
        public string MatiepNhanG { get; set; }
        public DateTime? DtDateInG { get; set; }

        public static void LeaveFocusNext(KeyPressEventArgs e, Control controlNext)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            controlNext.Focus();
            if (controlNext is CustomComboBox)
            {
                ((CustomComboBox)controlNext).DroppedDown = true;
            }
            else if (controlNext is TextBox)
            {
                if (((TextBox)controlNext).Multiline == false)
                {
                    ((TextBox)controlNext).SelectAll();
                }
            }
            else if (controlNext is SearchLookUpEdit)
                ((SearchLookUpEdit)controlNext).ShowPopup();

            e.Handled = true;
        }
        public static void LeaveFocusNext(PreviewKeyDownEventArgs e, Control controlNext, Control controlBack)
        {
            if (e.KeyData == Keys.Tab)
            {
                controlNext.Focus();
                if (controlNext is SearchLookUpEdit)
                    ((SearchLookUpEdit)controlNext).ShowPopup();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                if (controlBack != null)
                {
                    controlBack.Focus();
                    if (controlBack is SearchLookUpEdit)
                        ((SearchLookUpEdit)controlBack).ShowPopup();
                    e.IsInputKey = true;
                }
            }
        }
        #region Thao tach với thông tin bệnh nhân
        private void Check_Enable()
        {
            Lock_UnlockControl(true);

            var allow = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionInsertPatient);
            ucAddEditControl1.btnAdd.Enabled = allow;
            btnIntemTiepNhan.Enabled = allow;

            ucAddEditControl1.btnEdit.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionEditPatient);
            ucAddEditControl1.btnDelete.Enabled = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeletePatient);
            ucChiTietChiDinh1.HienThiXoaChiDinh = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionDeleteOrder);
            if (CommonAppVarsAndFunctions.sysConfig.KieuNhapChiDinhDichVu > 0)
            {
                btnChiDinh.Visible = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionInsertOrder);
                gbNhapChiDinh.Visible = false;
            }
            else
            {
                btnChiDinh.Visible = false;
                gbNhapChiDinh.Visible = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionInsertOrder);
            }
            btnThuPhiDichVu.Visible = ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionPintInvoice);
        }
        private void Clear_BindingInformation()
        {
            radReturn.DataBindings.Clear();
            radReturn.Checked = false;
            radFirstTime.Checked = true;

            txtSEQ.DataBindings.Clear();
            txtSEQ.Text = string.Empty;

            txtMaTiepNhan.DataBindings.Clear();
            txtMaTiepNhan.Text = string.Empty;

            txtMSBenhNhan.DataBindings.Clear();
            txtMSBenhNhan.Text = string.Empty;

            txtSoBHYT.DataBindings.Clear();
            txtSoBHYT.Text = string.Empty;

            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = string.Empty;

            txtAge.DataBindings.Clear();
            txtAge.Text = string.Empty;

            dtpSinhNhat.EditValue = null;
            dtpNgaycapHC.EditValue = null;
            txtAddress.DataBindings.Clear();
            txtAddress.Text = string.Empty;

            ucSearchLookupEditor_Provice1.DataBindings.Clear();
            ucSearchLookupEditor_Provice1.SelectedValue = null;

            ucSearchLookupEditor_Location1.DataBindings.Clear();
            ucSearchLookupEditor_Location1.SelectedValue = null;

            ucSearchLookupEditor_Doctor1.DataBindings.Clear();
            ucSearchLookupEditor_Doctor1.SelectedValue = null;

            ucSearchLookupEditor_Object1.DataBindings.Clear();
            ucSearchLookupEditor_Object1.SelectedValue = null;

            ucSearchLookupEditor_Gender1.DataBindings.Clear();
            ucSearchLookupEditor_Gender1.SelectedValue = null;

            txtPhone.DataBindings.Clear();
            txtPhone.Text = string.Empty;
            cboEmail.SelectedIndex = -1;

            txtEmail.DataBindings.Clear();
            txtEmail.Text = string.Empty;


            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = string.Empty;
            cboChanDoan.SelectedIndex = -1;

            txtIdCongDan.DataBindings.Clear();
            txtIdCongDan.Text = string.Empty;

            txtSophieu.DataBindings.Clear();
            txtSophieu.Text = string.Empty;

            cboDTBN.SelectedIndex = -1;
            txtDoiTuong.DataBindings.Clear();
            txtDoiTuong.Text = string.Empty;
            chkCapCuu.DataBindings.Clear();
            chkCapCuu.Checked = false;

            chkNoitru.DataBindings.Clear();
            chkNoitru.Checked = false;
            numCanNang.Value = 0;

        }

        private void Clear_BindingOrder()
        {
            //Clear chỉ định
            ucSearchLookupEditor_NhomDichVu1.SelectedValue = string.Empty;
            ucSearchLookupEditor_DanhSachDichVu1.SelectedValue = string.Empty;

        }
        private void Clear_BindingOrderDetail()
        {
            //Clear chi tiết chỉ định
            ucChiTietChiDinh1.SetNullDataGridControl();
        }

        private void Lock_UnlockControl(bool isLock)
        {
            radReturn.Enabled = !isLock;

            radFirstTime.Enabled = !isLock;

            dtpSinhNhat.Enabled = !isLock;

            ucSearchLookupEditor_Gender1.Enabled = !isLock;

            txtAddress.ReadOnly = isLock;

            ucSearchLookupEditor_Provice1.Enabled = !isLock;

            ucSearchLookupEditor_Location1.Enabled = !isLock;

            ucSearchLookupEditor_Doctor1.Enabled = !isLock;

            ucSearchLookupEditor_Object1.Enabled = !isLock;
            ucSearchLookupEditor_SinhLy1.Enabled = !isLock;
            txtSEQ.ReadOnly = isLock;

            txtSoBHYT.ReadOnly = isLock;

            txtTenBN.ReadOnly = isLock;

            txtPhone.ReadOnly = isLock;

            txtEmail.ReadOnly = isLock;
            cboEmail.Enabled = !isLock;

            txtChanDoan.ReadOnly = isLock;

            txtMSBenhNhan.ReadOnly = isLock;

            txtAge.ReadOnly = isLock;
            cboChanDoan.Enabled = !isLock;
            txtIdCongDan.ReadOnly = isLock;
            cboDTBN.Enabled = !isLock;

            dtpNgaycapHC.Enabled = !isLock;
            txtQuocTich.ReadOnly = isLock;
            ucSearchLookupEditor_CongTacVien.Enabled = !isLock;
            ucSearchLookupEditor_Room1.Enabled = !isLock;
            numCanNang.Enabled = !isLock;
        }
        private void StartAddNew()
        {
            if (txtSEQ.ForeColor == Color.Red)
            {
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.Bandangtrongchedonhapmoi);
                txtTenBN.Focus();
            }
            else
            {
                dtpDateIn.ValueChanged -= dtpDateIn_ValueChanged;
                dtpDateIn.Value = C_Ultilities.ServerDate();

                gvPatient.FindFilterText = string.Empty;
                Clear_BindingInformation();
                Get_ThongTin_BenhNhan("NULL", false);
                Lock_UnlockControl(false);
                gcPatient.Enabled = false;
                gcLichSuTiepNhan.Enabled = false;
                LoadDSBenhNhan();
                ucSearchLookupEditor_Object1.SelectedValue = CommonAppVarsAndFunctions.DefaultObject;
                // ucSearchLookupEditor_Doctor1.SelectedValue = CommonAppVarsAndFunctions.DefaultDoctor;

                if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu))
                {
                    if (CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode.ToString()))
                    {
                        if (string.IsNullOrEmpty(txtSEQ.Text))
                        {
                            txtSEQ.Text = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpDateIn.Value);
                            //txtMSBenhNhan.Text = txtSEQ.Text;
                            txtMaTiepNhan.Text = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
                        }
                        txtSEQ.ReadOnly = true;
                        //gcSearchBN.Visible = true;
                        txtTenBN.Focus();
                    }
                    else
                    {
                        txtSEQ.ReadOnly = false;
                        // txtMSBenhNhan.Text = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpDateIn.Value);
                        txtSEQ.Focus();
                    }
                }
                else
                {
                    // txtMSBenhNhan.Text = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpDateIn.Value);
                    txtSEQ.Focus();
                }
                txtSEQ.ForeColor = Color.Red;
                dtpDateIn.ValueChanged += dtpDateIn_ValueChanged;
                //if (!string.IsNullOrEmpty(_objectID))
                //{
                //    cboService.SelectedValue = _objectID;
                //}
                //if (!string.IsNullOrEmpty(_address))
                //{
                //    txtAddress.Text = _address;
                //}
                //if (!string.IsNullOrEmpty(_locationID))
                //{
                //    cboDonvi.SelectedValue = _locationID;
                //}
                //if (!string.IsNullOrEmpty(_doctorID))
                //{
                //    cboBSChiDinh.SelectedValue = _doctorID;
                //}

                lblWarning.Text = CommonAppVarsAndFunctions.LangMessageConstant.DANGCHEDONHAPMOI_Upper;
                _isAddMode = true;
            }
        }
        private string Get_MaBenhNhan()
        {
            if (txtSEQ.ForeColor != Color.Red)
                return string.Empty;
            var currentPidSeq = informationService.Get_MaBnNhanGanNhat();
            return CommonAppVarsAndFunctions.sysConfig.Get_MaBenhNhan(dtpDateIn.Value, currentPidSeq);
        }
        private void Get_DanhSach_TiepNhan()
        {
            var data = informationService.Data_BenhNhan_TiepNhan(string.Empty,
                  new[] { string.Format("NgayTiepNhan = '{0:yyyy-MM-dd}'", dtpDateIn.Value),
                    string.Format("MaKhuVuc in({0})", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.UserWorkPlace, true)) });
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            gcPatient.DataSource = bs;
        }
        private void Get_ThongTin_BenhNhan(string matiepnhan, bool setControl)
        {
            _isBinding = true;
            BENHNHAN_TIEPNHAN objTiepNhan = null;

            if (!string.Equals(matiepnhan, "NULL", StringComparison.OrdinalIgnoreCase))
            {
                objTiepNhan = informationService.Get_Info_BenhNhan_TiepNhan(matiepnhan,
                    new[] { string.Format("NgayTiepNhan = '{0}'", dtpDateIn.Value.ToString("yyyy-MM-dd")) });
            }

            objBenhnhanTiepnhan = objTiepNhan ?? new BENHNHAN_TIEPNHAN();
            objBenhnhanTiepnhanOld = objBenhnhanTiepnhan.Copy();
            BindData_ThongTin_BenhNhan();
            ucChiTietChiDinh1.Get_ChiTietChiDinh(matiepnhan, null);
            if (setControl)
            {
                ucAddEditControl1.SetStatusButtonNormal();
                Check_Enable();
                //Chế độ his nên không có số phiếu - cần thì mở
                //if (!string.IsNullOrEmpty(txtSoPhieuChiDinh.Text))
                //{
                //    ucAddEditControl1.btnDelete.Enabled = false;
                //}
            }
            _isBinding = false;
        }
        private void Get_LichSuTiepNhan(string mabenhnhan)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = informationService.LayDanhSach_LichSuNoiTru(mabenhnhan, string.Empty);
            gcLichSuTiepNhan.DataSource = bs;
            bvLichSuTiepNhan.BindingSource = bs;
        }
        private void BindData_ThongTin_BenhNhan()
        {
            Clear_BindingInformation();
            txtMaTiepNhan.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Matiepnhan), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtSEQ.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Seq), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtAge.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tuoi), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtSoBHYT.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Sobhyt), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtChanDoan.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Chandoan), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtAddress.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Diachi), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtEmail.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Email), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtPhone.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Sdt), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMSBenhNhan.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Mabn), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtTenBN.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tenbn), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtIdCongDan.DataBindings.Add("Text", objBenhnhanTiepnhan,
            ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Idcongdan), true,
            DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            ucSearchLookupEditor_Gender1.SelectedValue = objBenhnhanTiepnhan.Gioitinh;

            ucSearchLookupEditor_Doctor1.SelectedValue = objBenhnhanTiepnhan.Bacsicd;


            ucSearchLookupEditor_Provice1.SelectedValue = objBenhnhanTiepnhan.Matinh == null ? -1 : objBenhnhanTiepnhan.Matinh.Value;

            ucSearchLookupEditor_Location1.SelectedValue = objBenhnhanTiepnhan.Madonvi;

            ucSearchLookupEditor_Object1.SelectedValue = objBenhnhanTiepnhan.Doituongdichvu;
            ucSearchLookupEditor_SinhLy1.SelectedValue = objBenhnhanTiepnhan.Masinhly;

            //chkAgeType.DataBindings.Add("Checked", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Congaysinh), true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            dtpSinhNhat.EditValue = objBenhnhanTiepnhan.Sinhnhat;
            dtpNgaycapHC.EditValue = objBenhnhanTiepnhan.Ngaycaphochieu;
            //dtpBirthday.DataBindings.Add("Value", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Sinhnhat), true,
            //    DataSourceUpdateMode.OnPropertyChanged, DateTime.Now);

            //radReturn.DataBindings.Add("Checked", objBenhnhanTiepnhan,
            //   ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.TaiKham), true,
            //   DataSourceUpdateMode.Never, false);

            txtSophieu.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Sophieuyeucau), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtDoiTuong.DataBindings.Add("Text", objBenhnhanTiepnhan,
            ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Doituong), true,
            DataSourceUpdateMode.OnPropertyChanged, string.Empty);


            chkNoitru.DataBindings.Add("Checked", objBenhnhanTiepnhan,
             ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Noitru), true,
             DataSourceUpdateMode.Never, false);

            chkCapCuu.DataBindings.Add("Checked", objBenhnhanTiepnhan,
          ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Capcuu), true,
          DataSourceUpdateMode.Never, false);
            txtQuocTich.Text = objBenhnhanTiepnhan.Quoctich;
            ucSearchLookupEditor_Room1.SelectedValue = objBenhnhanTiepnhan.Masophong;
            ucSearchLookupEditor_CongTacVien.SelectedValue = objBenhnhanTiepnhan.MaCongTacVien;
            numCanNang.Value = (decimal)objBenhnhanTiepnhan.Cannang;
            //txtBSChiDinh.DataBindings.Add("Text", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Bacsicd), true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            //txtDonVi.DataBindings.Add("Text", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tendonvi), true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            //cboChanDoan.DataBindings.Add("SelectedValue", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Chandoan), true,
            //    DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            //cboQuanHuyen.DataBindings.Add("SelectedValue", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Mahuyen), true,
            //    DataSourceUpdateMode.OnPropertyChanged, null);
            //cboTinh.DataBindings.Add("SelectedValue", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Matinh), true,
            //    DataSourceUpdateMode.OnPropertyChanged, null);
            //cboPrinters.DataBindings.Add("SelectedValue", objBenhnhanTiepnhan,
            //    ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Mamayin), true,
            //    DataSourceUpdateMode.OnPropertyChanged, CommonConstant.DefaultHisBarcodePrinterId);
            //cboPrinters.SelectedValue = objBenhnhanTiepnhan.Mamayin;
        }
        /// <summary>
        /// Lấy thông tin nội trú
        /// </summary>
        /// <param name="_MaBN"></param>
        /// <param name="getType">1: số đt - 2: id công dân - khác: mã bn </param>
        private void Get_InterInfo(string _MaBN, int getType)
        {
            DataTable dtInfoInter = new DataTable();
            if (getType == 1)
                dtInfoInter = informationService.LayThongtin_TiepNhan_TheoSoDienThoai(_MaBN);
            else if (getType == 2)
                dtInfoInter = informationService.LayThongtin_TiepNhan_IdCongDan(_MaBN);
            else
                dtInfoInter = informationService.LayThongtin_TiepNhan_TheoMaBN(_MaBN);

            if (dtInfoInter.Rows.Count > 0)
            {
                var objInterInfo = informationService.Get_Info_BenhNhan_TiepNhan(dtInfoInter.Rows[0]["MaTiepNhan"].ToString(), new string[] { });
                Set_ThongTinTheoMaBN(objInterInfo, getType == 1);
                //if (getType == 1)
                //    objBenhnhanTiepnhan.Mabn = objInterInfo.Mabn;
            }
        }
        public void Set_ThongTinTheoMaBN(BENHNHAN_TIEPNHAN objInfo, bool setmaBN)
        {
            txtTenBN.Text = objInfo.Tenbn;
            txtAge.Text = objInfo.Tuoi.ToString("N0").Replace(",", "").Replace(".", "");
            //if (objInfo.Sinhnhat != null)
            //    dtpBirthday.Value = objInfo.Sinhnhat.Value;
            dtpSinhNhat.EditValue = objInfo.Sinhnhat;
            ucSearchLookupEditor_Gender1.SelectedValue = objInfo.Gioitinh;
            txtAddress.Text = objInfo.Diachi;
            txtPhone.Text = objInfo.Sdt;
            txtSoBHYT.Text = objInfo.Sobhyt;
            objBenhnhanTiepnhan.Tiensubenh = objInfo.Tinhtrangbenh; //lấy lần bệnh trước cho và tiền sử
            ucSearchLookupEditor_Object1.SelectedValue = objInfo.Doituongdichvu;
            objBenhnhanTiepnhan.Phuongxa = objInfo.Phuongxa;
            txtIdCongDan.Text = objInfo.Idcongdan;
            radReturn.Checked = true;
            if (setmaBN)
                txtMSBenhNhan.Text = objInfo.Mabn;
        }
        private void Check_Update_Alert()
        {
            if (objBenhnhanTiepnhan == null || txtSEQ.ForeColor == Color.Red)
                return;
            if (objBenhnhanTiepnhan.Compare_Differences(objBenhnhanTiepnhanOld) && !_loading && !string.IsNullOrEmpty(txtSEQ.Text))
            {
                lblWarning.Text = CommonAppVarsAndFunctions.LangMessageConstant.NHANLUUDECAPNHAT_Upper;
            }
        }
        private void Save_Update_Manual()
        {
            if (objBenhnhanTiepnhan == null) return;
            if (string.IsNullOrEmpty(objBenhnhanTiepnhan.Seq))
            {
                CustomMessageBox.MSG_Error_OK(CommonAppVarsAndFunctions.LangMessageConstant.Haynhapbarcode);
                txtSEQ.Focus();
            }
            else if (string.IsNullOrEmpty(txtAge.Text) || NumberConverter.ToInt(txtAge.Text) <= 0)
            {
                CustomMessageBox.MSG_Error_OK(CommonAppVarsAndFunctions.LangMessageConstant.Haynhaptuoi);
                txtAge.Focus();
            }
            else if (string.IsNullOrEmpty(StringConverter.ToString(ucSearchLookupEditor_Gender1.SelectedValue)))
            {
                CustomMessageBox.MSG_Error_OK(CommonAppVarsAndFunctions.LangMessageConstant.Haynhapgioitinh);
                ucSearchLookupEditor_Gender1.Focus();
            }
            else if (string.IsNullOrEmpty(StringConverter.ToString(ucSearchLookupEditor_Object1.SelectedValue)))
            {
                CustomMessageBox.MSG_Error_OK(CommonAppVarsAndFunctions.LangMessageConstant.Haynhapdoituongdichvu);
                ucSearchLookupEditor_Object1.Focus();
            }
            else if (string.IsNullOrEmpty(StringConverter.ToString(ucSearchLookupEditor_Doctor1.SelectedValue)))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập Bác Sĩ chỉ định.");
                ucSearchLookupEditor_Doctor1.Focus();
            }
            else
            {
                string curentMatiepNhan = string.Empty;
                objBenhnhanTiepnhan.Khamlandau = radFirstTime.Checked;
                objBenhnhanTiepnhan.Capcuu = chkCapCuu.Checked;
                objBenhnhanTiepnhan.Noitru = chkNoitru.Checked;
                objBenhnhanTiepnhan.MaCongTacVien = (ucSearchLookupEditor_CongTacVien.SelectedValue ?? (object)string.Empty).ToString();
                objBenhnhanTiepnhan.Ngaycaphochieu = (DateTime?)dtpNgaycapHC.EditValue;
                objBenhnhanTiepnhan.Masophong = (ucSearchLookupEditor_Room1.SelectedValue ?? (object)string.Empty).ToString();
                objBenhnhanTiepnhan.Quoctich = txtQuocTich.Text;
                objBenhnhanTiepnhan.Sinhnhat = (DateTime?)dtpSinhNhat.EditValue;
                objBenhnhanTiepnhan.Congaysinh = !(objBenhnhanTiepnhan.Sinhnhat == null);
                if (objBenhnhanTiepnhan.Sinhnhat != null)
                    objBenhnhanTiepnhan.Tuoi = objBenhnhanTiepnhan.Sinhnhat.Value.Year;
                objBenhnhanTiepnhan.Masinhly = (ucSearchLookupEditor_SinhLy1.SelectedValue ?? string.Empty).ToString();
                objBenhnhanTiepnhan.Tensinhly = ucSearchLookupEditor_SinhLy1.SelectedText;
                objBenhnhanTiepnhan.Cannang = (float)numCanNang.Value;
                if (txtSEQ.ForeColor == Color.Red)
                {
                    if (string.IsNullOrEmpty(txtMSBenhNhan.Text))
                        txtMSBenhNhan.Text = Get_MaBenhNhan();

                    objBenhnhanTiepnhan.Hisproviderid = 0;
                    Insert_NewPatient(ref curentMatiepNhan);
                    var findPos = gvPatient.LocateByValue(colMaTiepNhan.FieldName, curentMatiepNhan);
                    gvPatient.FocusedRowHandle = findPos;
                    Get_ThongTin_BenhNhan(objBenhnhanTiepnhan.Matiepnhan, true);

                    lblWarning.Text = CommonAppVarsAndFunctions.LangMessageConstant.DATHEMMOITHANHCONGCHAM_Upper;
                    if (btnChiDinh.Visible)
                        btnChiDinh.Focus();
                    else if (gbNhapChiDinh.Visible)
                    {
                        ucSearchLookupEditor_LoaiDichVu1.Focus();
                        ucSearchLookupEditor_LoaiDichVu1.ShowPopup();
                    }
                    txtSEQ.ForeColor = Color.Black;
                }
                else
                {
                    curentMatiepNhan = objBenhnhanTiepnhan.Matiepnhan;
                    Update_Patient();
                    informationService.InsertBenhNhan(objBenhnhanTiepnhan.Mabn, objBenhnhanTiepnhan.Matiepnhan);
                    Get_DanhSach_TiepNhan();
                    var findPos = gvPatient.LocateByValue(colMaBenhNhan.FieldName, curentMatiepNhan);
                    gvPatient.FocusedRowHandle = findPos;
                    Get_ThongTin_BenhNhan(objBenhnhanTiepnhan.Matiepnhan, true);
                    lblWarning.Text = CommonAppVarsAndFunctions.LangMessageConstant.THONGTINDADUOCLUU_Upper;
                    txtSEQ.ForeColor = Color.Black;
                }
                exitAddEditMode();
            }
        }
        private void exitAddEditMode()
        {
            _isAddMode = false;
            _isEditMode = false;
        }
        private void Insert_NewPatient(ref string matiepnahn)
        {
            objBenhnhanTiepnhan.Ngaytiepnhan = dtpDateIn.Value;
            objBenhnhanTiepnhan.Seq = txtSEQ.Text;
            objBenhnhanTiepnhan.Nguonnhap = InputSourceEnum.Normal.ToString();
            objBenhnhanTiepnhan.Matiepnhan = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
            matiepnahn = objBenhnhanTiepnhan.Matiepnhan;
            objBenhnhanTiepnhan.Usernhap = CommonAppVarsAndFunctions.UserID;
            objBenhnhanTiepnhan.Thoigiannhap = DateTime.Now;
            // objBenhnhanTiepnhan.Mamayin = NumberConverter.To<byte>(cboPrinters.SelectedValue);
            objBenhnhanTiepnhan.Makhuvuc = CommonAppVarsAndFunctions.PCWorkPlace;

            if (ucSearchLookupEditor_Gender1.SelectedValue != null)
                objBenhnhanTiepnhan.Gioitinh = ucSearchLookupEditor_Gender1.SelectedValue.ToString();

            if (ucSearchLookupEditor_Doctor1.SelectedValue != null)
                objBenhnhanTiepnhan.Bacsicd = ucSearchLookupEditor_Doctor1.SelectedValue.ToString();

            if (ucSearchLookupEditor_Location1.SelectedValue != null)
                objBenhnhanTiepnhan.Madonvi = ucSearchLookupEditor_Location1.SelectedValue.ToString();

            if (ucSearchLookupEditor_Object1.SelectedValue != null)
                objBenhnhanTiepnhan.Doituongdichvu = ucSearchLookupEditor_Object1.SelectedValue.ToString();

            var insertSuccess = informationService.Insert_BenhNhan_TiepNhan(objBenhnhanTiepnhan, true);
            //----------------------
            if (insertSuccess)
            {
                GuiThongTinTiepNhanDenLabIMSWeb(objBenhnhanTiepnhan.Copy());
            }
            //----------------------
            objBenhnhanTiepnhanOld = objBenhnhanTiepnhan.Copy();
            informationService.InsertBenhNhan(objBenhnhanTiepnhan.Mabn, objBenhnhanTiepnhan.Matiepnhan);

            lblWarning.Text = string.Empty;
            txtSEQ.BackColor = Color.Empty;
            txtSEQ.ForeColor = Color.Empty;
            gcPatient.Enabled = true;
            gcLichSuTiepNhan.Enabled = true;


            Get_DanhSach_TiepNhan();
            exitAddEditMode();
            ucAddEditControl1.SetStatusButtonNormal();
            btnChiDinh.Focus();

        }
        private void Update_Patient()
        {
            string oldDoiTuong = string.IsNullOrEmpty(objBenhnhanTiepnhanOld.Doituongdichvu) ? "" : objBenhnhanTiepnhanOld.Doituongdichvu;
            objBenhnhanTiepnhan.Usercapnhat = CommonAppVarsAndFunctions.UserID;

            if (ucSearchLookupEditor_Gender1.SelectedValue != null)
                objBenhnhanTiepnhan.Gioitinh = ucSearchLookupEditor_Gender1.SelectedValue.ToString();

            if (ucSearchLookupEditor_Doctor1.SelectedValue != null)
                objBenhnhanTiepnhan.Bacsicd = ucSearchLookupEditor_Doctor1.SelectedValue.ToString();

            if (ucSearchLookupEditor_Location1.SelectedValue != null)
                objBenhnhanTiepnhan.Madonvi = ucSearchLookupEditor_Location1.SelectedValue.ToString();

            if (ucSearchLookupEditor_Object1.SelectedValue != null)
                objBenhnhanTiepnhan.Doituongdichvu = ucSearchLookupEditor_Object1.SelectedValue.ToString();

            // objBenhnhanTiepnhan.Mamayin = NumberConverter.To<byte>(cboPrinters.SelectedValue);
            var updateSuccess = informationService.Update_BenhNhan_TiepNhan(objBenhnhanTiepnhan);
            //----------------------
            if (updateSuccess)
            {
                GuiThongTinTiepNhanDenLabIMSWeb(objBenhnhanTiepnhan.Copy());
            }
            //----------------------

            objBenhnhanTiepnhanOld = objBenhnhanTiepnhan.Copy();
            if (!oldDoiTuong.Equals(string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu) ? "" : objBenhnhanTiepnhan.Doituongdichvu, StringComparison.OrdinalIgnoreCase))
                testService.UpdateGiaDichVuXN(objBenhnhanTiepnhan.Matiepnhan);
            informationService.InsertBenhNhan(objBenhnhanTiepnhan.Mabn, objBenhnhanTiepnhan.Matiepnhan);
            lblWarning.Text = "";
            gcPatient.Enabled = true;

            Get_DanhSach_TiepNhan();

        }
        private void Delete_Patient()
        {
            if (objBenhnhanTiepnhan == null) return;

            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionReceptionDeletePatient))
            {
                if (testService.Check_HaveResult_XN(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), ""))
                {
                    CustomMessageBox.MSG_Waring_OK(CommonAppVarsAndFunctions.LangMessageConstant.BenhnhandacoKQ);
                    return;
                }
            }

            if (!CustomMessageBox.MSG_Question_YesNo_GetYes(
                $"{CommonAppVarsAndFunctions.LangMessageConstant.XoabenhnhanLA}: {txtMaTiepNhan.Text}?")) return;
            var matiepnhan = objBenhnhanTiepnhan.Matiepnhan;
            if (informationService.Delete_BenhNhan_TiepNhan(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), CommonAppVarsAndFunctions.UserID))
                informationService.DeletePatientWithoutElement(matiepnhan, CommonAppVarsAndFunctions.UserID, Environment.MachineName);
            Clear_BindingInformation();
            Lock_UnlockControl(true);
            Get_DanhSach_TiepNhan();
            lblWarning.Text = string.Empty;
        }

        #endregion

        #region Thao tác thêm chỉ định
        private void Load_DanhMucLoaiDichVu()
        {
            ucSearchLookupEditor_LoaiDichVu1.LoaiChiDinh_EditValueChanged = ucSearchLookupEditor_LoaiDichVu1_EditValueChanged;
            ucSearchLookupEditor_LoaiDichVu1.Load_DanhMucLoaiDichVu();

            ucSearchLookupEditor_LoaiDichVu1.CatchEnterKey = true;
            ucSearchLookupEditor_LoaiDichVu1.CatchTabKey = true;
            ucSearchLookupEditor_LoaiDichVu1.ControlNext = ucSearchLookupEditor_NhomDichVu1;
            ucSearchLookupEditor_LoaiDichVu1.ControlBack = ucAddEditControl1;
            ucSearchLookupEditor_LoaiDichVu1.SelectedValue = ServiceType.ClsXetNghiem.ToString();

            Load_DanhMucNhomDichVu();
        }
        private void Load_DanhMucNhomDichVu()
        {
            if (ucSearchLookupEditor_LoaiDichVu1.SelectedValue != null)
            {
                ucSearchLookupEditor_NhomDichVu1.NhomChiDinh_EditValueChanged = ucSearchLookupEditor_NhomDichVu1_EditValueChanged;
                var loaiDichvu = ucSearchLookupEditor_LoaiDichVu1.SelectedValue.ToString();
                ServiceType dv = (ServiceType)Enum.Parse(typeof(ServiceType), loaiDichvu);

                ucSearchLookupEditor_NhomDichVu1.Load_DanhMucNhomDichVu(loaiDichvu);

                ucSearchLookupEditor_NhomDichVu1.CatchEnterKey = true;
                ucSearchLookupEditor_NhomDichVu1.CatchTabKey = true;
                ucSearchLookupEditor_NhomDichVu1.ControlNext = ucSearchLookupEditor_DanhSachDichVu1;
                ucSearchLookupEditor_NhomDichVu1.ControlBack = ucAddEditControl1;

                pnSoLuong.Visible = (dv == ServiceType.Duoc);
            }
            else
                ucSearchLookupEditor_NhomDichVu1.DataSource = null;

            Load_DanhmucDichVu();
        }
        private void Load_DanhmucDichVu()
        {
            if (ucSearchLookupEditor_LoaiDichVu1.SelectedValue != null)
            {
                var loaiDichVu = ucSearchLookupEditor_LoaiDichVu1.SelectedValue.ToString();
                var nhomdichVu = (ucSearchLookupEditor_NhomDichVu1.SelectedValue != null ? ucSearchLookupEditor_NhomDichVu1.SelectedValue.ToString() : string.Empty);

                var doiTuongDv = (objBenhnhanTiepnhan != null ? (objBenhnhanTiepnhan.Doituongdichvu == null ? string.Empty : objBenhnhanTiepnhan.Doituongdichvu) : string.Empty);
                var sex = (objBenhnhanTiepnhan != null ? (objBenhnhanTiepnhan.Gioitinh == null ? string.Empty : objBenhnhanTiepnhan.Gioitinh) : string.Empty);

                ucSearchLookupEditor_DanhSachDichVu1.ChiDinh_Keypress = ucSearchLookupEditor_DanhSachDichVu1_KeyPress;
                ucSearchLookupEditor_DanhSachDichVu1.ChiDinh_EditValueChanged = ucSearchLookupEditor_DanhSachDichVu1_EditValueChanged;

                ucSearchLookupEditor_DanhSachDichVu1.Load_DanhMucDichVu(loaiDichVu, nhomdichVu, doiTuongDv, sex);

                ucSearchLookupEditor_DanhSachDichVu1.CatchEnterKey = true;
                ucSearchLookupEditor_DanhSachDichVu1.CatchTabKey = true;
                //ucSearchLookupEditor_DanhSachDichVu1.ControlNext = btnThemChiDinh;
                ucSearchLookupEditor_DanhSachDichVu1.ControlBack = ucSearchLookupEditor_NhomDichVu1;
            }
        }

        private void InsertItem()
        {
            if (txtSEQ.ForeColor == Color.Red && CommonAppVarsAndFunctions.sysConfig.BenhNhanTuLuuThongTinNhapMoi)
            {
                Save_Update_Manual();
            }
            else if (ucAddEditControl1.btnSave.Enabled)
            {
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.Hayluuthongtinbenhnhantruockhinhapchidinh);
                ucAddEditControl1.Focus();
                ucAddEditControl1.btnSave.Focus();
            }

            //if (ucSearchLookupEditor_LoaiDichVu1.SelectedValue == null)
            //    return;
            //else if (ucSearchLookupEditor_DanhSachDichVu1.SelectedValue == null
            //    || ucSearchLookupEditor_DanhSachDichVu1.SelectedDataRowView == null 
            //    || gvPatient.RowCount <= 0)
            //    return;

            if (ucSearchLookupEditor_LoaiDichVu1.SelectedValue == null
               || ucSearchLookupEditor_DanhSachDichVu1.SelectedValue == null
               || ucSearchLookupEditor_DanhSachDichVu1.SelectedDataRowView == null
               || gvPatient.RowCount <= 0)
                return;

            //1: madichvu
            //2: profile
            var maloaidichvu = ucSearchLookupEditor_LoaiDichVu1.SelectedValue.ToString();
            var madichvu = ucSearchLookupEditor_DanhSachDichVu1.SelectedValue.ToString();

            ServiceType dv = (ServiceType)Enum.Parse(typeof(ServiceType), maloaidichvu.Trim());
            var themChiDinhThanhCong = false;

            if (dv == ServiceType.ClsXetNghiem)
            {
                var profileChar = ucSearchLookupEditor_DanhSachDichVu1.SelectedDataRowView.Row["isprofile"].ToString();
                var loaiXetnghiem = ucSearchLookupEditor_DanhSachDichVu1.LoaiXetNghiem;

                var enumLoaiXn = (TestType.EnumTestType)Enum.Parse(typeof(TestType.EnumTestType), loaiXetnghiem);
                if (enumLoaiXn == TestType.EnumTestType.ChiDinhTruyenMau)
                {
                    informationService.Insert_BenhNhan_TuMau(objBenhnhanTiepnhan, false);
                }
                //Xử lý insert bộ dịch vụ
                if (profileChar == ProfileTestContant.GroupChar)
                {
                    var dataChiTietBo = sysConfig.Data_dm_xetnghiem_bo_chitiet(madichvu, string.Empty, false);
                    if (dataChiTietBo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dataChiTietBo.Rows)
                        {
                            var isProfile = bool.Parse(dr["XNProfile"].ToString());
                            var maChiDinh = dr["MaChiDinh"].ToString();
                            var pChar = isProfile ? ProfileTestContant.ProfileChar : ProfileTestContant.TestChar;
                            themChiDinhThanhCong = InsertDichVuXn(maChiDinh, pChar);
                        }
                    }
                }
                else
                {
                    themChiDinhThanhCong = InsertDichVuXn(madichvu, profileChar);
                }
                if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhapCD)
                {
                    informationService.Update_ThoiGianThucHienXN(objBenhnhanTiepnhan.Matiepnhan);
                    informationService.Update_ThoiGianThucHienXN_Nhom(objBenhnhanTiepnhan.Matiepnhan, (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                }
            }
            else if (dv == ServiceType.ClsSieuAm)
            {
                InsertDichVuSieuAm(madichvu);
            }
            else if (dv == ServiceType.ClsXQuang)
            {
                InsertDicVuXQuang(madichvu);
            }
            else if (dv == ServiceType.ClsNoiSoi)
            {
                InsertDichVuNoiSoi(madichvu);
            }
            else if (dv == ServiceType.KhamBenh)
            {
                InsertDichVuKhamBenh(madichvu);
            }
            else if (dv == ServiceType.DvKhac)
            {
                InsertDichVuKhac(madichvu);
            }
            else if (dv == ServiceType.Duoc)
            {
                InsertDichVuThuoc(madichvu);
            }

            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                ucChiTietChiDinh1.Get_ChiTietChiDinh(objBenhnhanTiepnhan.Matiepnhan, null);
                if (themChiDinhThanhCong)
                {
                    ThemChiDinhTrenLabIMSWeb(madichvu,
                        objBenhnhanTiepnhan.Matiepnhan,
                        objBenhnhanTiepnhan.Doituongdichvu);
                }
            }

            if (gbNhapChiDinh.Visible)
            {
                ucSearchLookupEditor_LoaiDichVu1.Focus();
                ucSearchLookupEditor_DanhSachDichVu1.Focus();
                ucSearchLookupEditor_DanhSachDichVu1.ShowPopup();
            }

            informationService.Update_TrangThaiLayMau(objBenhnhanTiepnhan.Matiepnhan);
        }
        private bool InsertDichVuXn(string maxn, string profileChar)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                string _sampleID = objBenhnhanTiepnhan.Matiepnhan;
                string _maxn = maxn;
                bool profile = (profileChar == ProfileTestContant.ProfileChar);
                if (testService.CheckTonTaiChiDinh(_sampleID, _maxn, profile))
                {
                    CustomMessageBox.CloseAlert();
                    CustomMessageBox.MSG_Information_OK(string.Format("{0} [{1}] {2}",
                        profile ? "Profile" : CommonAppVarsAndFunctions.LangMessageConstant.Chidinh,
                        _maxn, CommonAppVarsAndFunctions.LangMessageConstant.Daduocnhap));
                    return false;
                }

                var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
                objChiDinh.maxn = _maxn;
                objChiDinh.xetnghiemProfile = profile;
                objChiDinh.Dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                objChiDinh.nguoiNhap = CommonAppVarsAndFunctions.UserID;
                return testService.InsertTest(objBenhnhanTiepnhan, objChiDinh);
            }
            else
                CustomMessageBox.MSG_Question_YesNo_GetYes(CommonAppVarsAndFunctions.LangMessageConstant.Haynhapdoituongdichvu);

            return false;
        }
        private void InsertDichVuSieuAm(string maSomau)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_sieuam.Insert_ChiDinhSieuAm(objBenhnhanTiepnhan.Matiepnhan,
                    maSomau, objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDichVuNoiSoi(string maSomau)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_noisoi.Insert_ChiDinhNoiSoi(objBenhnhanTiepnhan.Matiepnhan,
                    maSomau, objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDicVuXQuang(string maVungChup)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_xquang.Insert_ChiDinhXQuang(objBenhnhanTiepnhan.Matiepnhan,
                    maVungChup.Trim(), objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDichVuKhamBenh(string maDichVu)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_khambenh.Insert_ChiDinh_DichVu(objBenhnhanTiepnhan.Matiepnhan,
                    maDichVu.Trim(), objBenhnhanTiepnhan.Doituongdichvu.Trim(), "KB",
                    dongia);
            }
        }
        private void InsertDichVuKhac(string maDichVu)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_dvkhac.Insert_ChiDinhDVKhac(objBenhnhanTiepnhan.Matiepnhan,
                    maDichVu.Trim(), objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDichVuThuoc(string maThuoc)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                string _DoiTuongDV = objBenhnhanTiepnhan.Doituongdichvu;
                int soluong = int.Parse(txtSoLuong.Text == string.Empty ? "0" : txtSoLuong.Text);
                float dongia = float.Parse(txtDonGia.Text == string.Empty ? "-1" : txtDonGia.Text);
                if (soluong > 0)
                {
                    thuphiThuocDAL.Insert_ThuPhi_Thuoc(maThuoc, objBenhnhanTiepnhan.Matiepnhan, _DoiTuongDV, soluong, dongia, false);
                }
                else
                    CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.Haynhapsoluong);
            }
        }
        #endregion

        #region Load danh mục
        private void Load_DoiTuongBN()
        {
            cboDTBN.DataSource = sysConfig.Data_dm_doituongbenhnhan(string.Empty);
            cboDTBN.ValueMember = "MaDoiTuongBN";
            cboDTBN.DisplayMember = "MaDoiTuongBN";
            cboDTBN.ColumnNames = "MaDoiTuongBN,TenDoiTuongBN";
            cboDTBN.ColumnWidths = "25,150";
            cboDTBN.LinkedColumnIndex = 1;
            cboDTBN.LinkedTextBox = txtDoiTuong;
            cboDTBN.SelectedIndex = -1;
        }
        private void Load_GioiTinh()
        {
            ucSearchLookupEditor_Gender1.Load_GioiTinh();
            ucSearchLookupEditor_Gender1.CatchEnterKey = true;
            ucSearchLookupEditor_Gender1.CatchTabKey = true;
            ucSearchLookupEditor_Gender1.ControlNext = numCanNang;
            ucSearchLookupEditor_Gender1.ControlBack = dtpSinhNhat;
        }
        private void Load_Tinh()
        {
            ucSearchLookupEditor_Provice1.Load_Tinh();
            ucSearchLookupEditor_Provice1.CatchEnterKey = true;
            ucSearchLookupEditor_Provice1.CatchTabKey = true;
            ucSearchLookupEditor_Provice1.ControlNext = txtAddress;
            ucSearchLookupEditor_Provice1.ControlBack = ucSearchLookupEditor_Gender1;
        }
        private void Load_DoiTuong()
        {
            ucSearchLookupEditor_Object1.Load_DoiTuong();
            ucSearchLookupEditor_Object1.CatchEnterKey = true;
            ucSearchLookupEditor_Object1.CatchTabKey = true;
            ucSearchLookupEditor_Object1.ControlNext = ucSearchLookupEditor_Doctor1;
            ucSearchLookupEditor_Object1.ControlBack = txtEmail;
        }
        private void Load_DonVi()
        {
            ucSearchLookupEditor_Location1.Load_DonVi();
            ucSearchLookupEditor_Location1.CatchEnterKey = true;
            ucSearchLookupEditor_Location1.CatchTabKey = true;
            ucSearchLookupEditor_Location1.ControlNext = ucSearchLookupEditor_Room1;
            ucSearchLookupEditor_Location1.ControlBack = ucSearchLookupEditor_CongTacVien;

            ucSearchLookupEditor_Location1.EditValueChange += UcSearchLookupEditor_Location1_EditValueChange;

        }

        private void UcSearchLookupEditor_Location1_EditValueChange(object sender, EventArgs e)
        {
            var makhoaphong = (ucSearchLookupEditor_Location1.SelectedValue ?? (object)"-NONE-").ToString();
            ucSearchLookupEditor_Room1.Load_Phong(makhoaphong);
            ucSearchLookupEditor_Room1.CatchEnterKey = true;
            ucSearchLookupEditor_Room1.CatchTabKey = true;
            ucSearchLookupEditor_Room1.ControlNext = cboChanDoan;
            ucSearchLookupEditor_Room1.ControlBack = ucSearchLookupEditor_Location1;
        }

        private void Load_BacSi()
        {
            ucSearchLookupEditor_Doctor1.EditValueChanged += UcSearchLookupEditor_Doctor1_EditValueChanged;
            ucSearchLookupEditor_Doctor1.Load_BacSi();
            ucSearchLookupEditor_Doctor1.CatchEnterKey = true;
            ucSearchLookupEditor_Doctor1.CatchTabKey = true;
            ucSearchLookupEditor_Doctor1.ControlNext = ucSearchLookupEditor_CongTacVien;
            ucSearchLookupEditor_Doctor1.ControlBack = ucSearchLookupEditor_Object1;
            ucSearchLookupEditor_CongTacVien.EditValueChanged += UcSearchLookupEditor_CongTacVien_ValuedChanged;
            ucSearchLookupEditor_CongTacVien.Load_CongTacVien();
            ucSearchLookupEditor_CongTacVien.CatchEnterKey = true;
            ucSearchLookupEditor_CongTacVien.CatchTabKey = true;
            ucSearchLookupEditor_CongTacVien.ControlNext = ucSearchLookupEditor_Location1;
            ucSearchLookupEditor_CongTacVien.ControlBack = ucSearchLookupEditor_Doctor1;

        }

        private void UcSearchLookupEditor_CongTacVien_ValuedChanged(object sender, EventArgs e)
        {
            //if (ucSearchLookupEditor_CongTacVien.Enabled)
            //{
            //    if (ucSearchLookupEditor_CongTacVien.SelectedValue != null)
            //    {
            //        var locationId = ucSearchLookupEditor_CongTacVien.GetDoctorLocation;
            //        ucSearchLookupEditor_Location1.SelectedValue = locationId;

            //        var room = ucSearchLookupEditor_CongTacVien.GetDoctorRoom;
            //        ucSearchLookupEditor_Room1.SelectedValue = room;
            //    }
            //    else
            //    {
            //        if (ucSearchLookupEditor_Doctor1.SelectedValue != null)
            //        {
            //            var locationId = ucSearchLookupEditor_Doctor1.GetDoctorLocation;
            //            ucSearchLookupEditor_Location1.SelectedValue = locationId;
            //            var room = ucSearchLookupEditor_Doctor1.GetDoctorRoom;
            //            ucSearchLookupEditor_Room1.SelectedValue = room;
            //        }
            //        else
            //        {
            //            ucSearchLookupEditor_Location1.SelectedValue = null;
            //            ucSearchLookupEditor_Room1.SelectedValue = null;
            //        }

            //    }
            //}
        }

        private void UcSearchLookupEditor_Doctor1_EditValueChanged(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_Doctor1.Enabled)
            {
                if (ucSearchLookupEditor_Doctor1.SelectedValue != null)
                {
                    var locationId = ucSearchLookupEditor_Doctor1.GetDoctorLocation;
                    ucSearchLookupEditor_Location1.SelectedValue = locationId;

                    var room = ucSearchLookupEditor_Doctor1.GetDoctorRoom;
                    ucSearchLookupEditor_Room1.SelectedValue = room;
                }
                else
                {
                    ucSearchLookupEditor_Location1.SelectedValue = null;
                    ucSearchLookupEditor_Room1.SelectedValue = null;
                }
            }
        }

        private void Load_ChanDoan()
        {
            sysConfig.Get_ChanDoan(cboChanDoan, txtChanDoan);
        }
        #endregion
        private void FrmTiepNhanBenhNhan_Load(object sender, EventArgs e)
        {
            Check_Enable();
            gcSearchBN.Size = new Size(614, 172);
            ControlExtension.SetLowerCaseForXGridColumns(gvSearchBN);
            if (CommonAppVarsAndFunctions.sysConfig.KieuNhapChiDinhDichVu == (int)EnumKieuNhapChiDinh.ComboboxInput)
            {
                Load_DanhMucLoaiDichVu();
            }
            Load_DoiTuongBN();
            Load_GioiTinh();
            Load_DoiTuong();
            Load_DonVi();
            Load_BacSi();
            Load_Tinh();
            Load_ChanDoan();
            Load_EmailList();
            Load_SinhLy();


            txtSEQ.MaxLength = int.Parse(string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode) ? "6" : CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);
            labIMSWebConfigInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals((int)TPH.Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)).FirstOrDefault();
            if (gvPatient.RowCount <= 0)
                ucAddEditControl1.btnEdit.Enabled = false;
        }
        private void btnChiDinh_Click(object sender, EventArgs e)
        {
            if (objBenhnhanTiepnhan == null) return;
            if (txtSEQ.ForeColor == Color.Red)
            {
                CustomMessageBox.MSG_Error_OK(CommonAppVarsAndFunctions.LangMessageConstant.ChiDinh_Error);
            }
            else
            {
                FrmChonDichVu f = new FrmChonDichVu();
                f.KieuNhapChiDinh = CommonAppVarsAndFunctions.sysConfig.KieuNhapChiDinhDichVu;
                f.objBenhnhanTiepnhan = objBenhnhanTiepnhan;
                f.ShowDialog();
                ucChiTietChiDinh1.Get_ChiTietChiDinh(objBenhnhanTiepnhan.Matiepnhan, null);
            }
        }
        private void btnThuPhiDichVu_Click(object sender, EventArgs e)
        {
            var f = new ThucThi.BenhNhan.FrmThuPhiDichVu();
            f.BorderSize = 1;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
        }
        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            //Nếu trong chế độ nhập mới
            if (txtSEQ.ForeColor == Color.Red && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu))
            {
                if (!CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode))
                {
                    txtSEQ.Text = CommonAppVarsAndFunctions.sysConfig.GenerateSeq(dtpDateIn.Value);
                    txtMaTiepNhan.Text = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
                }
                else
                {
                    txtMaTiepNhan.Text = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
                    txtSEQ.Focus();
                }
            }
            //Chê do thường
            else if (txtSEQ.ForeColor != Color.Red)
            {
                Get_DanhSach_TiepNhan();
            }
            //Nếu tìm barcode 
            else if (txtSEQ.Text != "" && txtSEQ.ForeColor != Color.Red)
            {
                Get_ThongTin_BenhNhan(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), true);

            }
            //Vo hiệu hóa Chỉnh sửa nếu không có bệnh nhân và Không là chế độ nhập mới
            if (gvPatient.RowCount <= 0 && !_isAddMode)
            {
                ucAddEditControl1.btnEdit.Enabled = false;
                Clear_BindingInformation();
                Clear_BindingOrder();
                Clear_BindingOrderDetail();
            }
        }
        private void ucAddEditControl1_ButtonAddClick(object sender, EventArgs e)
        {
            StartAddNew();
        }
        private void ucAddEditControl1_ButtonCancelClick(object sender, EventArgs e)
        {
            if (txtSEQ.ForeColor == Color.Red)
            {
                Clear_BindingInformation();
                txtSEQ.ForeColor = Color.Black;
                lblWarning.Text = "";
                gcPatient.Enabled = true;
                gcLichSuTiepNhan.Enabled = true;

                Get_DanhSach_TiepNhan();
                Get_ThongTin_BenhNhan("", true);
            }
            else if (objBenhnhanTiepnhan != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(CommonAppVarsAndFunctions.LangMessageConstant.Huythaotacchinhsuathongtin))
                {
                    Get_ThongTin_BenhNhan(objBenhnhanTiepnhan.Matiepnhan, true);
                }
            }
            if (gvPatient.RowCount <= 0)
                ucAddEditControl1.btnEdit.Enabled = false;
            exitAddEditMode();
            lblWarning.Text = "";
            dtpDateIn.Enabled = true;
        }
        private void btnLoadDanhSachTiepNhan_Click(object sender, EventArgs e)
        {
            Get_DanhSach_TiepNhan();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //  Search_BenhNhan();
        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAge.Text))
            {
                int _a = int.Parse(txtAge.Text);
                if (_a < 1000)
                {
                    _a = dtpDateIn.Value.Year - _a;
                }
                txtAge.Text = _a.ToString();
            }
            // Check_Update_Alert();
        }
        private void ucAddEditControl1_ButtonSaveClick(object sender, EventArgs e)
        {
            Save_Update_Manual();
            dtpDateIn.Enabled = true;
        }
        private void ucAddEditControl1_ButtonEditClick(object sender, EventArgs e)
        {
            lblWarning.Text = CommonAppVarsAndFunctions.LangMessageConstant.DANGCHEDOCHINHSUA_Upper;
            _isEditMode = true;
            Lock_UnlockControl(false);
            txtSEQ.ReadOnly = true;
            dtpDateIn.Enabled = false;
            txtTenBN.Focus();
        }
        private void FrmTiepNhanBenhNhan_Shown(object sender, EventArgs e)
        {
            splitContainer1.SplitterPosition = btnTimBenhNhan.Location.X + btnTimBenhNhan.Width + 5;
            if (DtDateInG != null && !string.IsNullOrEmpty(MatiepNhanG))
            {
                dtpDateIn.ValueChanged -= dtpDateIn_ValueChanged;

                dtpDateIn.Value = DtDateInG.Value;
                Get_DanhSach_TiepNhan();
                gvPatient.FocusedRowHandle = gvPatient.LocateByValue(colSEQ.FieldName, MatiepNhanG);
                dtpDateIn.ValueChanged += dtpDateIn_ValueChanged;
            }
            else
            {
                Get_DanhSach_TiepNhan();
            }
        }
        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            if (e.KeyChar == (char)Keys.Enter && txtSEQ.ReadOnly == false)
            {
                if (txtSEQ.ForeColor == Color.Red && !string.IsNullOrEmpty(txtSEQ.Text))
                {
                    txtMaTiepNhan.Text = ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
                    txtMSBenhNhan.Text = Get_MaBenhNhan();
                    txtMSBenhNhan.Focus();
                    e.Handled = true;
                }
            }
        }
        private void txtSEQ_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (txtSEQ.ForeColor == Color.Red && !string.IsNullOrEmpty(txtSEQ.Text))
                {
                    if (!CommonAppVarsAndFunctions.sysConfig.BenhNhanCheDoSoThuTu.Equals(SystemStypeConstant.AutoBarcode.ToString()))
                    {

                        txtMSBenhNhan.Text = Get_MaBenhNhan();
                    }

                }
                txtMSBenhNhan.Focus();
                e.IsInputKey = true;
            }
        }
        private void txtMSBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtSEQ.ForeColor == Color.Red && !string.IsNullOrEmpty(txtSEQ.Text))
                {
                    if (!string.IsNullOrEmpty(txtMSBenhNhan.Text))
                    {
                        Get_InterInfo(txtMSBenhNhan.Text, 3);
                    }

                }
                txtTenBN.Focus();
                e.Handled = true;
            }
        }
        private void txtMSBenhNhan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (txtSEQ.ForeColor == Color.Red && !string.IsNullOrEmpty(txtSEQ.Text))
                {
                    if (!string.IsNullOrEmpty(txtMSBenhNhan.Text))
                    {
                        // Get_InterInfo(txtMSBenhNhan.Text, 3);
                    }
                }
                txtTenBN.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                txtSEQ.Focus();
                e.IsInputKey = true;
            }
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboDTBN.Focus();
                e.Handled = true;
            }
        }
        private void txtPhone_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                cboDTBN.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                txtAddress.Focus();
                e.IsInputKey = true;
            }
        }
        private void txtSoBHYT_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtAge);
        }
        private void txtSoBHYT_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtAge, txtTenBN);
        }
        private void txtTenBN_KeyPress(object sender, KeyPressEventArgs e)
        {

            LeaveFocusNext(e, txtSoBHYT);

        }
        private void txtTenBN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtSoBHYT, txtMSBenhNhan);
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpSinhNhat.Focus();
                // e.Handled = true;
            }
        }
        private void txtAge_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                dtpSinhNhat.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                txtSoBHYT.Focus();
                e.IsInputKey = true;
            }
        }


        private void dtpBirthday_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Gender1);
        }

        private void dtpSinhNhat_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Gender1, txtAge);
        }

        private void ucSearchLookupEditor_Gender1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Provice1);
        }

        private void ucSearchLookupEditor_Gender1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Provice1, ucSearchLookupEditor_Gender1);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtPhone);
        }

        private void txtAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtPhone, dtpNgaycapHC);
        }

        private void ucSearchLookupEditor_Location1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Doctor1);
        }

        private void ucSearchLookupEditor_Location1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Doctor1, ucSearchLookupEditor_Object1);
        }

        private void ucSearchLookupEditor_Doctor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtChanDoan);
        }

        private void ucSearchLookupEditor_Doctor1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtChanDoan, ucSearchLookupEditor_Location1);
        }
        private void txtChanDoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ucAddEditControl1.Focus();
                ucAddEditControl1.Set_FocusSave();
                e.Handled = true;
            }
        }
        private void txtChanDoan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                ucAddEditControl1.Focus();
                ucAddEditControl1.Set_FocusSave();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                cboChanDoan.Focus();
                e.IsInputKey = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Object1);
        }

        private void txtEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                ucSearchLookupEditor_Object1.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                ucSearchLookupEditor_SinhLy1.Focus();
                e.IsInputKey = true;
            }
        }
        private void btnIntemTiepNhan_Click(object sender, EventArgs e)
        {
            if (objBenhnhanTiepnhan != null)
            {
                if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Matiepnhan))
                {
                    FrmPrintbarcodeTemp f = new FrmPrintbarcodeTemp();
                    f.txtMaTiepNhan.Text = objBenhnhanTiepnhan.Matiepnhan;
                    f.txtSoLuongTem.Text = "1";
                    f.PrintBarcode();
                }
            }
        }

        private void ucSearchLookupEditor_LoaiDichVu1_EditValueChanged(object sender, EventArgs e)
        {
            Load_DanhMucNhomDichVu();
        }

        private void ucSearchLookupEditor_NhomDichVu1_EditValueChanged(object sender, EventArgs e)
        {
            Load_DanhmucDichVu();
        }

        private void ucSearchLookupEditor_DanhSachDichVu1_EditValueChanged(object sender, EventArgs e)
        {
            if (pnSoLuong.Visible && ucSearchLookupEditor_DanhSachDichVu1.SelectedValue != null)
            {
                var data = ucSearchLookupEditor_DanhSachDichVu1.SelectedDataRowView;
                lblDVT.Text = data.Row["DonViTinh"].ToString();
            }
            else
                lblDVT.Text = string.Empty;

        }
        private void btnThemChiDinh_Click(object sender, EventArgs e)
        {
            //Nếu không phải trong chế độ nhập mới hay sửa thì cho thêm
            if (_isAddMode)
            {
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.BandangtrongchedonhapmoiPlsSaveBefore);
                return;
            }
            if (_isEditMode)
            {
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.Bandangtrongchedochinhsua);
                return;
            }
            InsertItem();
        }
        private void ucSearchLookupEditor_DanhSachDichVu1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && ucSearchLookupEditor_DanhSachDichVu1.SelectedValue != null)
            {
                if (pnSoLuong.Visible)
                {
                    txtSoLuong.Focus();
                }
                else
                {
                    InsertItem();
                }
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InsertItem();
                e.Handled = true;
            }
        }

        private void gvLueChiDinhDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (pnSoLuong.Visible)
                {
                    txtSoLuong.Focus();
                }
                else
                {
                    InsertItem();
                }
                e.Handled = true;
            }
        }

        private void gvPatient_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gvPatient.RowCount == 0) return;

            string maTiepNhan = TPH.Common.Converter.StringConverter.ToString(gvPatient.GetRowCellValue(e.RowHandle, colMaTiepNhan));
            string mabenhnhan = TPH.Common.Converter.StringConverter.ToString(gvPatient.GetRowCellValue(e.RowHandle, colMaBenhNhan));
            Get_ThongTin_BenhNhan(maTiepNhan, true);
            if (gcLichSuTiepNhan.Visible)
                Get_LichSuTiepNhan(mabenhnhan);
        }

        private void btnTimBenhNhan_Click(object sender, EventArgs e)
        {
            FrmTimBenhNhan frm = new FrmTimBenhNhan();
            frm.DtDateFromG = dtpDateIn.Value;
            frm.WindowState = FormWindowState.Normal;
            frm.List = true;
            frm.BorderSize = 1;
            frm.pnMenu.Visible = true;
            frm.AdjustForm();
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.ReturnSEQ))
            {
                var matiepNhan = ConfigurationDetail.Get_MaTiepNhan(frm.ReturnSEQ, frm.ReturnDateIn);
                if (txtSEQ.ForeColor == Color.Red)
                {
                    txtTenBN.Focus();
                    var objInterInfo = informationService.Get_Info_BenhNhan_TiepNhan(matiepNhan, new string[] { });
                    Set_ThongTinTheoMaBN(objInterInfo, true);
                }
                else
                {
                    dtpDateIn.Value = frm.ReturnDateIn;
                    Get_ThongTin_BenhNhan(matiepNhan, true);
                }
                frm.Dispose();
            }
        }
        private void txtIdCongDan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                dtpNgaycapHC.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                txtQuocTich.Focus();
                e.IsInputKey = true;
            }
        }

        private void txtIdCongDan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dtpNgaycapHC.Focus();
                e.Handled = true;
            }
        }

        private void btnThemBs_Click(object sender, EventArgs e)
        {
            var f = new CauHinh.NhanVien.frmNhanVien_ChanDoan();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            var oldval = ucSearchLookupEditor_Doctor1.SelectedValue;
            Load_BacSi();
            ucSearchLookupEditor_Doctor1.Focus();
            ucSearchLookupEditor_Doctor1.SelectedValue = oldval;
        }

        private void cboChanDoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboChanDoan.SelectedIndex == -1)
                {
                    txtChanDoan.Focus();
                    e.Handled = true;
                }
                else
                {
                    ucAddEditControl1.Focus();
                    ucAddEditControl1.Set_FocusSave();
                    e.Handled = true;
                }
            }
        }

        private void cboChanDoan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (cboChanDoan.SelectedIndex == -1)
                {
                    txtChanDoan.Focus();
                }
                else
                {
                    ucAddEditControl1.Focus();
                    ucAddEditControl1.Set_FocusSave();
                }
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                ucSearchLookupEditor_Doctor1.Focus();
                e.IsInputKey = true;
            }
        }

        private void ucAddEditControl1_ButtonDeleteClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSophieu.Text))
            {
                Delete_Patient();
            }
            else
                CustomMessageBox.MSG_Information_OK(CommonAppVarsAndFunctions.LangMessageConstant.KhongthexoabenhnhantiepnhantuHIS);
        }

        private void radReturn_Click(object sender, EventArgs e)
        {
            if (txtSEQ.ForeColor == Color.Red)
            {
                txtMSBenhNhan.Focus();
                txtMSBenhNhan.SelectAll();
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
            txtAddress.Text = textInfo.ToTitleCase(txtAddress.Text);
        }

        private void txtSEQ_Leave(object sender, EventArgs e)
        {

        }

        private void btnConfigEmail_Click(object sender, EventArgs e)
        {
            var f = new Settings.HeThong.FrmEmailList();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            Load_EmailList();
        }
        private void Load_EmailList()
        {
            cboEmail.DataSource = sysConfig.Data_dm_email(string.Empty);
            cboEmail.DisplayMember = "Email";
            cboEmail.ValueMember = "Email";
            cboEmail.SelectedIndex = -1;
        }

        private void Load_SinhLy()
        {
            ucSearchLookupEditor_SinhLy1.Load_DanhMuc();
            ucSearchLookupEditor_SinhLy1.CatchEnterKey = true;
            ucSearchLookupEditor_SinhLy1.CatchTabKey = true;
            ucSearchLookupEditor_SinhLy1.ControlNext = cboEmail;
            ucSearchLookupEditor_SinhLy1.ControlBack = txtDoiTuong;
        }

        private void cboEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboEmail.SelectedIndex > -1)
                {
                    txtEmail.Text = cboEmail.SelectedValue.ToString();
                    LeaveFocusNext(e, ucSearchLookupEditor_Object1);
                }
                else
                    LeaveFocusNext(e, txtEmail);
            }
        }
        private void cboEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (cboEmail.SelectedIndex > -1)
                {
                    txtEmail.Text = cboEmail.SelectedValue.ToString();
                    ucSearchLookupEditor_Object1.Focus();
                }
                else
                    txtEmail.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                ucSearchLookupEditor_SinhLy1.Focus();
                e.IsInputKey = true;
            }
        }
        private void cboDTBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtDoiTuong.Text))
                    txtDoiTuong.Focus();
                else
                    ucSearchLookupEditor_SinhLy1.Focus();
            }
        }
        private void cboDTBN_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtDoiTuong.Text))
                    txtDoiTuong.Focus();
                else
                    ucSearchLookupEditor_SinhLy1.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                txtPhone.Focus();
                e.IsInputKey = true;
            }
        }
        private void txtDoiTuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ucSearchLookupEditor_SinhLy1.Focus();
                e.Handled = true;
            }
        }
        private void txtDoiTuong_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_SinhLy1, cboDTBN);
        }
        private void GuiThongTinTiepNhanDenLabIMSWeb(BENHNHAN_TIEPNHAN benhnhanTiepnhanInfo)
        {
            if (CommonAppVarsAndFunctions.sysConfig.TPHLabIMSWeb_TuDongGuiChiDinh)
            {
                //objBenhnhanTiepnhan
                Task.Run(() =>
                {
                    try
                    {
                        var donViNhanMau = JsonConvert.DeserializeObject<dynamic>(labIMSWebConfigInfo.UserName);

                        var thongTinTiepNhan = new Dictionary<string, object>
                    {
                        {"ReceptionDate", benhnhanTiepnhanInfo.Ngaytiepnhan},
                        {"ReceptionCodeByInputBranch", benhnhanTiepnhanInfo.Matiepnhan},
                        {"InputByBranch", donViNhanMau.Value},
                        {"SendByBranch", donViNhanMau.Value},
                        {"ReceiveByBranch", donViNhanMau.Value},
                        {"PatientCodeByInputBranch", benhnhanTiepnhanInfo.Mabn},
                        {"PatientName", benhnhanTiepnhanInfo.Tenbn},
                        {"Birthday", benhnhanTiepnhanInfo.Ngaytiepnhan},
                        {"Gender", benhnhanTiepnhanInfo.Gioitinh},
                        {"PersonalId", benhnhanTiepnhanInfo.Idcongdan},
                        {"Passport", benhnhanTiepnhanInfo.Sohochieu},
                        {"PassportIssuedDate", benhnhanTiepnhanInfo.Ngaycaphochieu},
                        {"Phone", benhnhanTiepnhanInfo.Sdt},
                        {"Email", benhnhanTiepnhanInfo.Email},
                        {"Address", benhnhanTiepnhanInfo.Diachi},
                        {"Diagnose", benhnhanTiepnhanInfo.Chandoan},
                        {"ServiceType", benhnhanTiepnhanInfo.Doituongdichvu},
                        {"PatientType", benhnhanTiepnhanInfo.Doituong},
                    };

                        _iHISService.ThemTiepNhanVaChiDinh(labIMSWebConfigInfo, thongTinTiepNhan);
                    }
                    catch (Exception ex)
                    {
                        WriteLog.LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "GuiThongTinTiepNhanDenLabIMSWeb_", ex);
                    }
                });
            }
        }
        private void ThemChiDinhTrenLabIMSWeb(string maXN, string maTiepNhan, string doiTuongDV)
        {
            if (CommonAppVarsAndFunctions.sysConfig.TPHLabIMSWeb_TuDongGuiChiDinh)
            {
                Task.Run(() =>
                {
                    try
                    {
                        var qR = from q in (List<SeviceOrderedInformation>)ucChiTietChiDinh1.gcChiDinh.DataSource
                                 where q.MaChiDinh.ToLower().Trim().Equals(maXN.ToLower().Trim())
                                 select q;

                        var profileId = string.Empty;
                        var isProfile = false;
                        if (qR != null && qR.Count() > 0)
                        {
                            profileId = qR.FirstOrDefault().MaProfile;
                            //isProfile = qR.FirstOrDefault().MaProfile;
                        }

                        var donViNhanMau = JsonConvert.DeserializeObject<dynamic>(labIMSWebConfigInfo.UserName);
                        var xnDetail = new Dictionary<string, object>
                                {
                                    {"ReceptionCodeByInputBranch", maTiepNhan},
                                    {"InputByBranch", donViNhanMau.Value},
                                    {"TestingCode", maXN},
                                    {"ServiceType", doiTuongDV},
                                    {"ProfileId", profileId},
                                    {"IsProfile", isProfile},
                                };

                        _iHISService.ThemChiDinh(labIMSWebConfigInfo, xnDetail);
                    }
                    catch (Exception ex)
                    {
                        WriteLog.LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "GuiThongTinTiepNhanDenLabIMSWeb_", ex);
                    }
                });
            }
        }

        BaseEdit editor;
        private void gvSearchBN_ShownEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            editor = view.ActiveEditor;
            editor.DoubleClick += editorSearch_DoubleClick;
        }
        private void gvSearchBN_HiddenEditor(object sender, EventArgs e)
        {
            editor.DoubleClick -= editorSearch_DoubleClick;
            editor = null;
        }
        void editorSearch_DoubleClick(object sender, EventArgs e)
        {
            if (txtSEQ.ForeColor == Color.Red)
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow || info.InRowCell)
                {
                    if (info.RowHandle > -1)
                    {
                        var mabn = gvSearchBN.GetFocusedRowCellValue(colSearch_maBn).ToString();
                        if (!string.IsNullOrEmpty(mabn))
                        {
                            txtMSBenhNhan.Text = mabn;
                            Get_InterInfo(mabn, 3);
                            txtSoBHYT.Focus();
                        }
                    }
                }
            }
        }

        private void txtTenBN_Enter(object sender, EventArgs e)
        {

        }
        private void LoadDSBenhNhan()
        {
            var data = informationService.DanhSachBenhNhan(string.Empty);
            WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcSearchBN.DataSource = data;
        }

        private void txtTenBN_Leave(object sender, EventArgs e)
        {
            if (!gcSearchBN.Focused)
                gcSearchBN.Visible = false;
        }

        private void txtTenBN_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (gcSearchBN.Visible)
                {
                    e.Handled = true;
                    gcSearchBN.Focus();
                }
            }
            else
            {
                if (txtSEQ.ForeColor == Color.Red)
                {
                    if (!string.IsNullOrEmpty(txtTenBN.Text))
                    {
                        if (!gcSearchBN.Visible)
                        {
                            gcSearchBN.Visible = true;
                        }
                        colSearch_TenBn.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(DevExpress.XtraGrid.Columns.ColumnFilterType.Custom, string.Format("{0} like '%{1}%'", colSearch_TenBn.FieldName, WorkingServices.EscapeLikeValue(txtTenBN.Text)));
                    }
                    else
                        colSearch_TenBn.ClearFilter();
                }
            }
        }

        private void gcSearchBN_Leave(object sender, EventArgs e)
        {
            if (!txtTenBN.Focused)
                gcSearchBN.Visible = false;
        }

        private void gcSearchBN_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (gvSearchBN.FocusedRowHandle < 1)
                {
                    txtTenBN.Focus();
                }
            }
            GridView view = (sender as GridControl).FocusedView as GridView;
            if (view == null) return;
            if (e.KeyCode == Keys.Enter && view.FocusedRowHandle > -1)
            {
                if (view.ActiveEditor != null) return; //Prevent record deletion when an in-place editor is invoked
                e.Handled = true;
                var mabn = gvSearchBN.GetFocusedRowCellValue(colSearch_maBn).ToString();
                if (!string.IsNullOrEmpty(mabn))
                {
                    txtMSBenhNhan.Text = mabn;
                    Get_InterInfo(mabn, 3);
                    txtSoBHYT.Focus();
                }
            }

        }

        private void txtQuocTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtIdCongDan);
        }

        private void txtQuocTich_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtIdCongDan, ucSearchLookupEditor_Gender1);

        }

        private void dtpSinhNhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Gender1);
        }

        private void dtpSinhNhat_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, ucSearchLookupEditor_Gender1, txtAge);
        }

        private void numCanNang_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtQuocTich);
        }

        private void numCanNang_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtQuocTich, ucSearchLookupEditor_Gender1);
        }

        private void ucSearchLookupEditor_SinhLy1_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtEmail);
        }

        private void ucSearchLookupEditor_SinhLy1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtEmail, cboDTBN);
        }

        private void dtpNgaycapHC_KeyPress(object sender, KeyPressEventArgs e)
        {
            LeaveFocusNext(e, txtAddress);
        }

        private void dtpNgaycapHC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            LeaveFocusNext(e, txtAddress, txtIdCongDan);
        }
    }
}