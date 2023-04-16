using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.App.ThucThi.CanLamSang;
using TPH.LIS.App.ThucThi.KhamLamSang;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmTimBenhNhan : FrmTemplate
    {
        C_Patient info = new C_Patient();
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        DataTable dtService = new DataTable();
        bool _List = false;
        public TestType.EnumTestType[] _arrLoaiXetNghiem;
        public bool List
        {
            get { return _List; }
            set { _List = value; }
        }

        private string _ServiceTypeID = string.Empty;

        public string ServiceTypeID
        {
            get { return _ServiceTypeID; }
            set { _ServiceTypeID = value; }
        }

        DateTime dtDateFromG = new DateTime();

        public DateTime DtDateFromG
        {
            get { return dtDateFromG; }
            set { dtDateFromG = value; }
        }

        private string _returnSEQ = "";

        public string ReturnSEQ
        {
            get { return _returnSEQ; }
            set { _returnSEQ = value; }
        }

        private DateTime _returnDateIn = CommonAppVarsAndFunctions.ServerTime;

        public DateTime ReturnDateIn
        {
            get { return _returnDateIn; }
            set { _returnDateIn = value; }
        }

        private string loadWithUser = string.Empty;

        public string LoadWithUser
        {
            get { return loadWithUser; }
            set { loadWithUser = value; }
        }
        public int OpenFrom { get; set; }
        public string MaBenhNhan { get; set; }
        public bool AddNew { get; set; }

        public FrmTimBenhNhan()
        {
            InitializeComponent();
        }
        bool _AllowResult_XN = false, _AllowResult_SieuAm = false, _AllowResult_XQuang = false, _AllowResult_NoiSoi = false, _AllowViewInfo = false;
        bool _AllKhamBenh = false;
        private bool KhongChonDieuKien()
        {
            if (
                !string.IsNullOrEmpty(txtName.Text) ||
                !string.IsNullOrEmpty(txtSoDienThoai.Text) ||
                !string.IsNullOrEmpty(txtMaBN.Text) ||
                !string.IsNullOrEmpty(txtSeq.Text) ||
                !string.IsNullOrEmpty(txtSoDienThoai.Text) ||
                !string.IsNullOrEmpty(txtSoPhieuHIS.Text) ||
                cboDichVuCLS.SelectedIndex > -1 ||
                cboNhomCLS.SelectedIndex > -1 ||
                cboService.SelectedIndex > -1 ||
                cboCLS_ChiDinh.SelectedIndex > -1 ||
                chkTimTheoNgay.Checked ||
                chkPrinted.Checked ||
                chkFullResult.Checked ||
                chkValid.Checked ||
                chkNhapTheoDanhSach.Checked || cboNguonNhap.SelectedIndex > -1
                )
            {
                return false;
            }
            else
                return true;
        }
        private void LoadList()
        {
            if (KhongChonDieuKien())
                CustomMessageBox.MSG_Information_OK("Hãy chọn điều kiện tìm kiếm.");
            else
            {
                gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;
                bool _isProfile = (txtProfile.Text == "*" ? true : false);
                string _TestID = (cboCLS_ChiDinh.SelectedIndex == -1 ? "" : cboCLS_ChiDinh.SelectedValue.ToString().Trim());
                string _Category = (cboNhomCLS.SelectedIndex == -1 ? "" : cboNhomCLS.SelectedValue.ToString().Trim());
                DataTable dataResult = new DataTable();
                if (_arrLoaiXetNghiem == null)
                {
                    dataResult = _patient.TimBenhNhan(
                        new Patient.Model.SearchPatientCondit
                        {
                            tungay = (chkTimTheoNgay.Checked ? dtpDateFrom.Value.Date : (DateTime?)null),
                            denngay = (chkTimTheoNgay.Checked ? dtpDateTo.Value.Date : (DateTime?)null),
                            maDoiTuong = WorkingServices.ValueCombobox(cboService),
                            tenBN = txtName.Text,
                            barcode = txtSeq.Text,
                            maBN = txtMaBN.Text,
                            sdt = txtSoDienThoai.Text,
                            idCongDan = txtIDCongDan.Text,
                            sophieuHis = txtSoPhieuHIS.Text,
                            soHoSo = txtSohoSo.Text,
                            khuTiepNhan = string.Empty,
                            nguonnhap = WorkingServices.ValueCombobox(cboNguonNhap)
                        });
                    gcDanhSach.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(dataResult, true);
                    gvDanhSach.ExpandAllGroups();
                }
                else
                {
                    string _IDDichVuCLS = (cboDichVuCLS.SelectedValue ?? string.Empty).ToString().Trim();
                    //if (_IDDichVuCLS.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
                    //{
                    //ID = 1 tìm BN Xét Nghiệm
                    dataResult = _patient.TimBenhNhanXetNghiem(
                        new Patient.Model.SearchPatientCondit_XN
                        {
                            tungay = (chkTimTheoNgay.Checked ? dtpDateFrom.Value.Date : (DateTime?)null),
                            denngay = (chkTimTheoNgay.Checked ? dtpDateTo.Value.Date : (DateTime?)null),
                            maDoiTuong = WorkingServices.ValueCombobox(cboService),
                            tenBN = txtName.Text,
                            barcode = txtSeq.Text,
                            maBN = txtMaBN.Text,
                            sdt = txtSoDienThoai.Text,
                            idCongDan = txtIDCongDan.Text,
                            sophieuHis = txtSoPhieuHIS.Text,
                            khuTiepNhan = string.Empty,
                            daNhanMau = enumThucHien.TatCa,
                            daLayMau = enumThucHien.TatCa,
                            daTraKQ = enumThucHien.TatCa,
                            daDuKQ = (chkFullResult.Checked ? enumThucHien.DaThucHien : enumThucHien.TatCa),
                            dainKQ = (chkPrinted.Checked ? enumThucHien.DaThucHien : enumThucHien.TatCa),
                            daXacNhanKQ = (chkValid.Checked ? enumThucHien.DaThucHien : enumThucHien.TatCa),
                            testType = _arrLoaiXetNghiem,
                            nguonnhap = WorkingServices.ValueCombobox(cboNguonNhap),
                            soHoSo = txtSohoSo.Text
                        }
                        );
                    gcDanhSach.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(dataResult, true);
                    gvDanhSach.ExpandAllGroups();
                    //}
                    //else if (_IDDichVuCLS.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
                    //{
                    //    //ID = 2 tìm BN Siêu Âm
                    //    C_Patient_SieuAm sieuam = new C_Patient_SieuAm();
                    //    sieuam.Search_PatientSieuAm(dtpDateFrom.Value, dtpDateTo.Value, (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text, txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category, chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                    //}
                    //else if (_IDDichVuCLS.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
                    //{
                    //    //ID = 2 tìm BN x quang
                    //    C_Patient_XQuang xquang = new C_Patient_XQuang();
                    //    xquang.Search_PatientXQuang(dtpDateFrom.Value, dtpDateTo.Value, (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text, txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category, chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                    //}
                    //else if (_IDDichVuCLS.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
                    //{
                    //    //ID = 2 tìm BN noi soi
                    //    C_Patient_NoiSoi noisoi = new C_Patient_NoiSoi();
                    //    noisoi.Search_PatientNoiSoi(dtpDateFrom.Value, dtpDateTo.Value, (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text, txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category, chkNhapTheoDanhSach.Checked, dtgPatient, bvPatient);
                    //}
                    //else if (_IDDichVuCLS.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
                    //{
                    //    //ID = 5 tìm bệnh nhân khám bệnh
                    //    C_Patient_KhamBenh khambenh = new C_Patient_KhamBenh();
                    //    khambenh.Search_PatientKhamBenh(dtpDateFrom.Value, dtpDateTo.Value
                    //        , (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString().Trim() : ""), txtName.Text
                    //        , txtSeq.Text, chkFullResult.Checked, chkPrinted.Checked, _TestID, _Category, chkNhapTheoDanhSach.Checked
                    //        , loadWithUser, dtgPatient, bvPatient, txtMaBN.Text, txtSoDienThoai.Text);
                    //}
                }
                Load_DS_ChiDinh();
                gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
            }
        }

        private void GvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DS_ChiDinh();
        }

        private void GvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DS_ChiDinh();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void frmSearchPatient_Load(object sender, EventArgs e)
        {
            //Kiem tra va set gia tri tuong ung cho tung loai dich vu
            sysConfig.Get_DoiTuongDichVu(cboService, "", ref dtService);
            data.Get_CauHinh_PhanLoaiChucNang(cboDichVuCLS, string.Format(" and EnumID in ({0},{1})", (int)ServiceType.ClsXetNghiem, (int)ServiceType.KhamBenh));

            _AllowResult_SieuAm = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenSieuAm, UserConstant.PermissionUltrasoundViewResult);
            _AllowResult_XN = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestViewResult);
            _AllowResult_XQuang = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXQuang, UserConstant.PermissionXRayViewResult);
            _AllowViewInfo = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, UserConstant.PermissionReceptionViewPatientInfo);
            _AllowResult_NoiSoi = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenNoiSoi, UserConstant.PermissionEdoscopicViewResult);
            _AllKhamBenh = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamPatientFromOtherDoctors);

            btnKQXetNghiem.Enabled = _AllowResult_XN;
            var datanguonHap = InputSourceType.DanhSachInput();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datanguonHap;

            cboNguonNhap.DataSource = bindingSource1;
            cboNguonNhap.ValueMember = "ID";
            cboNguonNhap.DisplayMember = "Description";
            cboNguonNhap.ColumnNames = "ID,Description";
            cboNguonNhap.ColumnWidths = "25,150";
            cboNguonNhap.SelectedIndex = -1;

            //btnKQSieuAm.Enabled = _AllowResult_SieuAm;
            //btnKQXQuang.Enabled = _AllowResult_XQuang;
            //btnViewInfo.Enabled = _AllowViewInfo;
            //btnXemKQNoiSoi.Enabled = _AllowResult_NoiSoi;
            //btnKhamBenh.Enabled = _AllKhamBenh;

            if (OpenFrom == 1)
            {
                //btnTiepNhan.Visible = true;
                btnKQXetNghiem.Visible = false;
                //btnKQSieuAm.Visible = false;
                btnViewInfo.Visible = true;
                //btnKhamBenh.Visible = false;
                ucChiTietChiDinh1.HienThiKetQua = false;
            }
            else if (OpenFrom == 2)
            {
                //btnTiepNhan.Visible = false;
                //btnKQSieuAm.Visible = false;
                btnKQXetNghiem.Visible = true;
                btnViewInfo.Visible = false;
                //btnKhamBenh.Visible = false;
                ucChiTietChiDinh1.HienThiKetQua = true;
            }
            else if (OpenFrom == 3)
            {
                //btnTiepNhan.Visible = false;
                btnKQXetNghiem.Visible = false;
                btnViewInfo.Visible = false;
                //btnKhamBenh.Visible = true;
                ucChiTietChiDinh1.HienThiKetQua = false;
            }
            else
                ucChiTietChiDinh1.HienThiKetQua = false;

          //  lblSoPhieuHis.Visible = txtSoPhieuHIS.Visible = colSoPhieu.Visible = CommonAppVarsAndFunctions.sysConfig.ConnectHIS;

            dtpDateFrom.ValueChanged -= dtpDateFrom_ValueChanged;
            dtpDateTo.ValueChanged -= dtpDateTo_ValueChanged;

            dtpDateFrom.Value = dtpDateTo.Value.AddMonths(-6);
            dtpDateTo.Value = CommonAppVarsAndFunctions.ServerTime;

            dtpDateFrom.ValueChanged += dtpDateFrom_ValueChanged;
            dtpDateTo.ValueChanged += dtpDateTo_ValueChanged;

            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSach);

            toolStripSeparator6.Visible = toolStripSeparator2.Visible = btnViewInfo.Visible = btnKQXetNghiem.Visible = this.TopLevelControl != this;
            pnMenu.Visible = !btnViewInfo.Visible;
            if (btnKQXetNghiem.Visible)
                toolStripSeparator2.Visible = btnKQXetNghiem.Visible = _AllowResult_XN;
            if (btnViewInfo.Visible)
                toolStripSeparator6.Visible = btnViewInfo.Visible = _AllowViewInfo;

        }
        private void btnKQXetNghiem_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle >-1)
            {
                frmParent fm = (frmParent)this.TopLevelControl;
                if (fm != null)
                {
                    frmCLSKetQuaXN frm = new frmCLSKetQuaXN();
                    if (fm.CloseChild(frm))
                    {
                        frm = new frmCLSKetQuaXN();
                    }
                    frm.DtDateInG = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colNgayTiepNhan).ToString());
                    frm.MatiepNhanG = gvDanhSach.GetFocusedRowCellValue(colBarcode).ToString();
                    fm.ShowForm(frm);
                }
                else
                {
                    _returnSEQ = gvDanhSach.GetFocusedRowCellValue(colBarcode).ToString();
                    _returnDateIn = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colNgayTiepNhan).ToString());
                }
                if (_List)
                {
                    this.Close();
                }
            }
        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {

            if (this.TopLevelControl != this)
            {
                frmParent fm = (frmParent)this.TopLevelControl;
                var frm = new FrmTiepNhanBenhNhan();
                if (fm.CloseChild(frm))
                {
                    frm = new FrmTiepNhanBenhNhan();
                }
                frm.DtDateInG = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colNgayTiepNhan).ToString());
                frm.MatiepNhanG = gvDanhSach.GetFocusedRowCellValue(colBarcode).ToString();
                fm.ShowForm(frm);
            }
            else
            {
                _returnSEQ = gvDanhSach.GetFocusedRowCellValue(colBarcode).ToString();
                _returnDateIn = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colNgayTiepNhan).ToString());
            }
            if (_List)
            {
                this.Close();
            }
        }

        private void btnKQSieuAm_Click(object sender, EventArgs e)
        {
            //if (dtgPatient.CurrentRow != null)
            //{
               
            //    frmMDIParent fm = (frmMDIParent)this.TopLevelControl;
            //    if (fm != null)
            //    {
            //        frmCLSKQSieuAm frm = new frmCLSKQSieuAm();
            //        if (fm.CloseChild(frm))
            //        {
            //            frm = new frmCLSKQSieuAm();
            //        }
               
            //    frm.DtDateInG = DateTime.Parse(dtgPatient.CurrentRow.Cells["DateIn"].Value.ToString().Trim());
            //    frm.MatiepNhanG = dtgPatient.CurrentRow.Cells["SEQ"].Value.ToString().Trim();
            //    fm.ShowForm(frm);
            //    }
            //    else
            //    {
            //        _returnSEQ = dtgPatient.CurrentRow.Cells[SEQ.Name].Value.ToString();
            //        _returnDateIn = DateTime.Parse(dtgPatient.CurrentRow.Cells[NgayTiepNhan.Name].Value.ToString());
            //    }
            //    if (_List)
            //    {
            //        this.Close();
            //    }
            //}
        }

        private void btnKQXQuang_Click(object sender, EventArgs e)
        {
            //if (dtgPatient.CurrentRow != null)
            //{
            //    frmCLSKetQuaXQuang frm = new frmCLSKetQuaXQuang();
            //    frmMDIParent fm = (frmMDIParent)this.TopLevelControl;

            //    if (fm.CloseChild(frm))
            //    {
            //        frm = new frmCLSKetQuaXQuang();
            //    }
            //    frm.DtDateInG = DateTime.Parse(dtgPatient.CurrentRow.Cells["DateIn"].Value.ToString().Trim());
            //    frm.MatiepNhanG = dtgPatient.CurrentRow.Cells["SEQ"].Value.ToString().Trim();
            //    fm.ShowForm(frm);
            //    if (_List)
            //    {
            //        this.Close();
            //    }
            //}
        }

        private void Load_NhomCD_TheoDV()
        {
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                //pnFunction.Enabled = true;
                string _IDDVCLS = cboDichVuCLS.SelectedValue.ToString().Trim();
                data.Load_Nhom_TheoDVCLS(cboNhomCLS, _IDDVCLS);
                Load_ChiDinhCLS();

                if (_IDDVCLS.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //btnKQSieuAm.Enabled = false;
                    //btnKQXQuang.Enabled = false;
                    //btnXemKQNoiSoi.Enabled = false;
                    btnKQXetNghiem.Enabled = _AllowResult_XN;
                }
                else if (_IDDVCLS.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //btnKQSieuAm.Enabled = _AllowResult_SieuAm;
                    //btnKQXQuang.Enabled = false;
                    btnKQXetNghiem.Enabled = false;
                    //btnXemKQNoiSoi.Enabled = false;
                }
                else if (_IDDVCLS.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
                {

                    //btnKQSieuAm.Enabled = false;
                    //btnKQXQuang.Enabled = _AllowResult_XQuang;
                    btnKQXetNghiem.Enabled = false;
                    //btnXemKQNoiSoi.Enabled = false;
                }

                else if (_IDDVCLS.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
                {

                    //btnKQSieuAm.Enabled = false;
                    //btnKQXQuang.Enabled = false;
                    btnKQXetNghiem.Enabled = false;
                    //btnXemKQNoiSoi.Enabled = _AllowResult_NoiSoi;
                }

            }
            else
            {
                //pnFunction.Enabled = false;
                //btnKQSieuAm.Enabled = _AllowResult_SieuAm;
                //btnKQXQuang.Enabled = _AllowResult_XQuang;
                btnKQXetNghiem.Enabled = _AllowResult_XN;
                //btnXemKQNoiSoi.Enabled = _AllowResult_NoiSoi;
            }
        }
        private void Load_ChiDinhCLS()
        {
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                string _dv = cboDichVuCLS.SelectedValue.ToString().Trim();
                string _nhom = (cboNhomCLS.SelectedIndex == -1 ? "" : cboNhomCLS.SelectedValue.ToString().Trim());
                data.Load_ChiDinhCLS(cboCLS_ChiDinh, _dv, _nhom, "", "");
            }
        }
        private void Bind_ResultData(DataTable dt)
        {
 
        }

        private void cboDichVuCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_NhomCD_TheoDV();
        }
        private void cboNhomCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_ChiDinhCLS();
            LoadList();
        }

        private void cboDichVuCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                Load_NhomCD_TheoDV();
                cboNhomCLS.Focus();
                return;
            }
        }

        private void cboNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_ChiDinhCLS();
                cboCLS_ChiDinh.Focus();
                return;
            }
        }

        private void dtgPatient_DoubleClick(object sender, EventArgs e)
        {
            //if (dtgPatient.RowCount > 0)
            //{
            //    if (List)
            //    {
            //        _returnSEQ = dtgPatient.CurrentRow.Cells[SEQ.Name].Value.ToString();
            //        _returnDateIn = DateTime.Parse(dtgPatient.CurrentRow.Cells[NgayTiepNhan.Name].Value.ToString());
            //        this.Close();
            //    }
            //    else
            //    {
            //        if (_ServiceTypeID.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            //        {
            //            btnKQXetNghiem_Click(sender, e);
            //        }
            //        else if (_ServiceTypeID.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            //        {
            //            btnKQSieuAm_Click(sender, e);
            //        }
            //        else if (_ServiceTypeID.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            //        {
            //            btnKQXQuang_Click(sender, e);
            //        }
            //        else
            //        {
            //            _returnSEQ = dtgPatient.CurrentRow.Cells[SEQ.Name].Value.ToString();
            //            _returnDateIn = DateTime.Parse(dtgPatient.CurrentRow.Cells[NgayTiepNhan.Name].Value.ToString());
            //          //  this.Close();
            //        }
            //    }
            //}
        }

        private void cboCLS_ChiDinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadList();
        }

        private void pnContaint_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Load_DS_ChiDinh()
        {
            string matiepnhan = (gvDanhSach.FocusedRowHandle > -1 ? gvDanhSach.GetFocusedRowCellValue(colMaTiepNhan).ToString() : "--NULL--");
            ucChiTietChiDinh1.Get_ChiTietChiDinh(matiepnhan, CommonAppVarsAndFunctions.arrLoaiDichVu);
        }
        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_DS_ChiDinh();
        }

        private void gvChiDinh_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name.Equals("colNo"))
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            //LoadList();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
           // LoadList();
        }

        private void btnKhamBenh_Click(object sender, EventArgs e)
        {
            //frmMDIParent fm = (frmMDIParent)this.TopLevelControl;
            //if (fm != null)
            //{
            //    FrmKhamBenh frm = new FrmKhamBenh();
            //    if (fm.CloseChild(frm))
            //    {
            //        frm = new FrmKhamBenh();
            //    }
            //    frm.DtDateInG = DateTime.Parse(dtgPatient.CurrentRow.Cells["DateIn"].Value.ToString().Trim());
            //    frm.MatiepNhanG = dtgPatient.CurrentRow.Cells["SEQ"].Value.ToString().Trim();
            //    fm.ShowForm(frm);
            //}
            //else
            //{
            //    _returnSEQ = dtgPatient.CurrentRow.Cells[SEQ.Name].Value.ToString();
            //    _returnDateIn = DateTime.Parse(dtgPatient.CurrentRow.Cells[NgayTiepNhan.Name].Value.ToString());
            //}
            //if (_List)
            //{
            //    this.Close();
            //}
        }

        private void btnTiepNhan_Click(object sender, EventArgs e)
        {
            //AddNew = true;
            //var maBN = "";
            //txtName.Focus();
            //for (int i = 0; i < dtgPatient.RowCount; i++)
            //{
            //    if(dtgPatient.Rows[i].Cells[Chon.Name].Value!=null && (bool)dtgPatient.Rows[i].Cells[Chon.Name].Value)
            //    {
            //        maBN = dtgPatient.Rows[i].Cells[MaBN.Name].Value.ToString().Trim();
            //        break;
            //    }
            //}

            //frmMDIParent fm = (frmMDIParent)this.TopLevelControl;
            //if (fm != null)
            //{
            //    var frm = new FrmTiepNhanBenhNhan();
            //    if (fm.CloseChild(frm))
            //    {
            //        frm = new FrmTiepNhanBenhNhan();
            //    }
            //    frm.MaBenhNhan = maBN;
            //    frm.AddNew = AddNew;
            //    fm.ShowForm(frm);
            //}
            //else
            //{
            //    if (dtgPatient.RowCount > 0)
            //    {
            //        MaBenhNhan = maBN;
            //    }
            //}
            //if (_List)
            //{
            //    this.Close();
            //}
        }

        private void dtgPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    txtSeq.Focus();
            //    for (int i = 0; i < dtgPatient.RowCount; i++)
            //    {
            //        if (i != e.RowIndex)
            //        {
            //            dtgPatient.Rows[i].Cells[0].Value = false;
            //        }
            //    }
            //}
        }

        private void dieukien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(sender is TextBox)
                {
                    var txt = (TextBox)sender;
                    if(txt.Name == txtSeq.Name)
                    {
                        txt.Text = WorkingServices.GetBarcodeInString(txt.Text, int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode));
                    }
                }
                LoadList();
            }
        }

        private void FrmTimBenhNhan_Shown(object sender, EventArgs e)
        {
            txtMaBN.Focus();
        }

        private void chkTimTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFrom.Enabled = dtpDateTo.Enabled = chkTimTheoNgay.Checked;
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (_List)
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    _returnSEQ = gvDanhSach.GetFocusedRowCellValue(colBarcode).ToString();
                    _returnDateIn = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colNgayTiepNhan).ToString());
                    this.Close();
                }
            }
        }

        private void chkTimTheoNgay_Click(object sender, EventArgs e)
        {
            gcDanhSach.DataSource = null;
            bvPatient.BindingSource = null;
        }

        private void cboService_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadList();
        }

        private void txtSeq_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void chkFullResult_Click(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
