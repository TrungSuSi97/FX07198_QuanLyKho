using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.WriteLog;

namespace TPH.LIS.App.ThucThi.KhamLamSang
{
    public partial class FrmKhamBenh : FrmTemplate
    {
        public FrmKhamBenh()
        {
            InitializeComponent();
        }
        private DateTime dtDateInG = new DateTime();
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
        string _SoThuTu;
        string _MaKhoa = "KB";
        DateTime _dtDateIn = DateTime.Now;
        public delegate void delegate_Set_Info(DateTime dtIn, string _ID);
        private readonly ITestResultService _xetnghiem = new TestResultService();

        C_Patient pInfo = new C_Patient();
        C_Patient_KhamBenh khambenh = new C_Patient_KhamBenh();
        C_KhamBenh_DonThuoc kb = new C_KhamBenh_DonThuoc();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        DataTable dtDonThuoc = new DataTable();
        DataTable dtPatient = new DataTable();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        private void Load_ChiDinh_CLS()
        {
            if (txtSID.Text != "")
            {
                FrmChiDinhCLS fChiDinhCL = new FrmChiDinhCLS();
                fChiDinhCL.Set_info(txtSID.Text, _MaKhoa, txtServiceID.Text);
                fChiDinhCL.ShowDialog();
            }
        }
        private void Load_KhamBenh_KetQua_DonThuoc()
        {
            string _MaYeuCau = "";
            if (cboYeuCauKhamBenh.SelectedIndex != -1)
                _MaYeuCau = (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString());
            else
                _MaYeuCau = "";
            Load_KhamBenh_KetQua(txtSID.Text, _MaKhoa, _MaYeuCau);
        }

        private void Load_DanhSach_ChiDinh()
        {
            dtPatient = new DataTable();
            int _PrintType = 0;
            if (radNotPrint.Checked)
                _PrintType = 2;
            else if (radPrinted.Checked)
                _PrintType = 1;

            string loadWithUser = string.Empty;
            //if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamPatientFromOtherDoctors))
            //    loadWithUser = CommonAppVarsAndFunctions.UserID;
            khambenh.Get_KhamBenh_BenhNhan_List(dtgPatient, bvPatient, dtpDateIn.Value.ToString("yyyy-MM-dd"), _PrintType, loadWithUser);
            //Load_KhamBenh(false, false);
            SearchPatient();
        }
        void SearchPatient()
        {
            if (bvPatient.BindingSource != null)
            {
                bvPatient.BindingSource.Filter = string.Format("matiepnhan like '%{0}' or TenBN like '%{0}%'", txtSEQ.Text);
            }
        }
        object[] ctrInfo = new object[18];
        private void Set_Info_BindColumn()
        {
            //dtpDateIn.Tag = "NgayTiepNhan";
            //txtSEQ.Tag = "SEQ";
            txtSID.Tag = "MaTiepNhan";
            txtTenBN.Tag = "TenBN";
            txtAge.Tag = "Tuoi";
            txtAddress.Tag = "DiaChi";
            chkAgeType.Tag = "CoNgaySinh";
            dtpBirthday.Tag = "SinhNhat";
            txtSex.Tag = "GioiTinh";
            txtTinhTrang.Tag = "TinhTrangBenh";
            txtTienSu.Tag = "TienSuBenh";
            radFirstTime.Tag = "KhamLanDau";
            chkDaIn.Tag = "DaInKQKham";
            chkDaXacNhan.Tag = "ValidKQKham";
            txtLanIn.Tag = "LanIn";
            txtTGIn.Tag = "ThoiGianIn";
            txtServiceID.Tag = "DoiTuongDichVu";
            txtDoctorSend.Tag = "TenNhanVien";
            txtMSBenhNhan.Tag = "MaBN";
        }
        private void Get_ObjectInfo()
        {
            Set_Info_BindColumn();
            //ctrInfo[0] = txtSEQ;
            ctrInfo[0] = txtSID;
            ctrInfo[1] = txtAge;
            ctrInfo[2] = chkAgeType;
            ctrInfo[3] = dtpBirthday;
            ctrInfo[4] = txtTenBN;
            ctrInfo[5] = txtAddress;
            ctrInfo[6] = txtSex;
            ctrInfo[7] = txtTinhTrang;
            ctrInfo[8] = txtTienSu;
            ctrInfo[9] = radFirstTime;
            ctrInfo[10] = chkDaIn;
            ctrInfo[11] = chkDaXacNhan;
            ctrInfo[12] = txtLanIn;
            ctrInfo[13] = txtTGIn;
            ctrInfo[14] = txtServiceID;
            ctrInfo[15] = txtDoctorSend;
            ctrInfo[16] = txtMSBenhNhan;
        }
        private void Load_KhamBenh_FromDelegate(bool _RefreshList)
        {
            if (_RefreshList)
            {
                Load_DanhSach_ChiDinh();
            }
            else
            {
                Load_KhamBenh(false, true);
            }
        }
        private bool Load_KhamBenh(bool _FromClick, bool _InfoOnly)
        {
            string _MaTiepNhan = "";
            if (dtgPatient.RowCount > 0)
            {
                _MaTiepNhan = dtgPatient.CurrentRow.Cells[MaTiepNhan.Name].Value.ToString().Trim();
            }

            dtPatient = khambenh.Data_BenhNhan_KhamBenh(_MaTiepNhan, _MaKhoa);
            BindingSource bs = new BindingSource();
            bs.DataSource = dtPatient;
            for (int i = 0; i < ctrInfo.Length; i++)
            {
                LabServices_Helper.CheckAndSetBindData(ctrInfo[i], bs);
            }
            if (!_InfoOnly)
            {
                Load_YeuCauKham(_MaTiepNhan, _MaKhoa);
                if (dtPatient.Rows.Count < 1)
                {
                    if (_FromClick)
                    {
                        CustomMessageBox.MSG_Information_OK("Không có thông tin bệnh nhân");
                    }
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
        private void Load_YeuCauKham(string _MaTiepNhan, string _DonVi)
        {
            cboYeuCauKhamBenh.SelectedIndex = -1;
            khambenh.Get_DanhSach_YeuCauKhamBenh(cboYeuCauKhamBenh, txtTenYeuCauKhamBenh, _MaTiepNhan, _DonVi, -1);
            Load_KhamBenh_KetQua_DonThuoc();
        }
        private void Set_InfoID(DateTime dtIn, string _ID)
        {
            _SoThuTu = _ID;
            _dtDateIn = dtIn;

        }

        private void btnTimBN_Click(object sender, EventArgs e)
        {
            FrmTimBenhNhan frm = new FrmTimBenhNhan();
            frm.LoadWithUser = (CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamPatientFromOtherDoctors) ? string.Empty : CommonAppVarsAndFunctions.UserID);
            frm.DtDateFromG = dtpDateIn.Value;
            frm.OpenFrom = 3;
            frm.List = true;
            frm.ShowDialog();
            if (!string.IsNullOrWhiteSpace(frm.ReturnSEQ))
            {
                //txtSearch.Text = frm.ReturnSEQ;
                dtpDateIn.Value = frm.ReturnDateIn;
                Load_DanhSach_ChiDinh();
                //Get_ThongTin_BenhNhan(ConfigurationDetail.Get_MaTiepNhan(frm.ReturnSEQ, frm.ReturnDateIn));
                bvPatient.BindingSource.Position = bvPatient.BindingSource.Find("Seq", frm.ReturnSEQ);
            }
            frm.Dispose();
        }
        private void FrmKhamBenh_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MatiepNhanG))
            {
                txtSEQ.Text = MatiepNhanG;
                dtpDateIn.Value = DtDateInG;
            }

            ControlExtension.LoadPrinterName(listPrinter, UserConstant.RegistryKhamBenhPrinter, CommonAppVarsAndFunctions.LstPrinter);
            Get_ObjectInfo();
            Get_ObjectResult();
            Load_ConfigData();
            Enable_Function();
        }
        private void Enable_Function()
        {
            btnPrint.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamPrintPrescription);
            btnValidResult.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamValidResult);
            btnValidResult.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissioOfExamnInValidResult);
            btnLuuKQKB.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamInsertResult);
            btnDeleteItem.Enabled = gbDonThuoc.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamInsertPrescription);
            gvToaThuoc.Columns["SoLuong"].OptionsColumn.ReadOnly= 
                gvToaThuoc.Columns["Sang"].OptionsColumn.ReadOnly= 
                gvToaThuoc.Columns["Trua"].OptionsColumn.ReadOnly =
                gvToaThuoc.Columns["Chieu"].OptionsColumn.ReadOnly=
                gvToaThuoc.Columns["Toi"].OptionsColumn.ReadOnly=
                gvToaThuoc.Columns["CachDung"].OptionsColumn.ReadOnly=
                gvToaThuoc.Columns["GhiChu"].OptionsColumn.ReadOnly

                = !CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenKhamBenh, UserConstant.PermissionOfExamInsertPrescription);
        }
        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryKhamBenhPrinter, listPrinter.SelectedIndex.ToString());
            //  fKhamLamSang.MayInDonThuoc = listPrinter.SelectedItem.ToString();

        }
        private void radFirstTime_CheckedChanged(object sender, EventArgs e)
        {
            radReturn.Checked = !radFirstTime.Checked;
        }
        private void FrmKhamBenh_Shown(object sender, EventArgs e)
        {
            Load_DanhSach_ChiDinh();
        }
        private void FrmKhamBenh_SizeChanged(object sender, EventArgs e)
        {
        }
        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Load_DanhSach_ChiDinh();
        }

        private void dtgPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Load_KhamBenh(true, false);
        }

        private void cboYeuCauKhamBenh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_KhamBenh_KetQua_DonThuoc();
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            Load_DanhSach_ChiDinh();
        }

        private void radAllPrint_Click(object sender, EventArgs e)
        {
            Load_DanhSach_ChiDinh();
        }

        private void chkDaXacNhan_CheckedChanged(object sender, EventArgs e)
        {
            chkXacNhan.Checked = chkDaXacNhan.Checked;
            chkDaInYC.Checked = chkDaIn.Checked;
        }

        private void chkDaIn_Click(object sender, EventArgs e)
        {
            Update_Print_NotPrint();
        }
        private void Update_Print_NotPrint()
        {

        }

        private void txtSEQ_KeyUp(object sender, KeyEventArgs e)
        {
            //SelectRow();
        }
        private void SelectRow()
        {
            if (txtSEQ.Text.Length >= 4)
            {
                LabServices_Helper.Select_Row(dtgPatient, bvPatient, "SEQ", txtSEQ.Text);
            }
        }
        #region KhamBenh
        public void Insert_KhamBenh(string _MaTiepNhan, string _DonVi)
        {
            kb.Insert_KhamBenh_BenhNhan(_MaTiepNhan, _DonVi);
        }

        object[] ctrResult = new object[16];
        private void Set_Result_BindColumn()
        {
            txtTenBacSi.Tag = "BSDieuTri";
            cboBacSi.Tag = "MaBacSi";
            txtGhiChu.Tag = "GhiChu";
            dtpNgayKham.Tag = "NgayDieuTri";
            txtCanNang.Tag = "CanNang";
            txtChieuCao.Tag = "ChieuCao";
            txtHuyetAp.Tag = "HuyetAp";
            txtMach.Tag = "Mach";
            txtNhipTho.Tag = "NhipTho";
            txtNhietDo.Tag = "NhietDo";
            txtChanDoan.Tag = "ChanDoan";
            txtDeNghi.Tag = "DeNghi";
            chkTaiKham.Tag = "HentaiKham";
            dtpTaiKham.Tag = "NgayTaiKham";
            chkDaInYC.Tag = "DaInKQ";
            chkXacNhan.Tag = "XacNhanKQ";
        }
        private void Get_ObjectResult()
        {
            Set_Result_BindColumn();
            ctrResult[0] = dtpNgayKham;
            ctrResult[1] = cboBacSi;
            ctrResult[2] = txtTenBacSi;
            ctrResult[3] = txtChanDoan;
            ctrResult[4] = txtDeNghi;
            ctrResult[5] = txtChieuCao;
            ctrResult[6] = txtCanNang;
            ctrResult[7] = txtHuyetAp;
            ctrResult[8] = txtMach;
            ctrResult[9] = txtNhipTho;
            ctrResult[10] = txtNhietDo;
            ctrResult[11] = chkTaiKham;
            ctrResult[12] = dtpTaiKham;
            ctrResult[13] = txtGhiChu;
            ctrResult[14] = chkDaInYC;
            ctrResult[15] = chkXacNhan;
        }

        /// <summary>
        /// Lấy thông Khám Bệnh - Kê Đơn
        /// </summary>
        /// <param name="_MaTiepNhan"></param>
        /// <param name="_DonVi"></param>
        public void Load_KhamBenh_KetQua(string _MaTiepNhan, string _DonVi, string _MaYeuCau)
        {
            _MaKhoa = _DonVi;
            txtSID.Text = _MaTiepNhan;

            dtpNgayKham.Value = DateTime.Now;
            dtpTaiKham.Value = DateTime.Now;

            DataTable dtResult = new DataTable();
            dtResult = kb.Data_KhamBenh_KetQua(_MaTiepNhan, _DonVi, _MaYeuCau);
            BindingSource bs = new BindingSource();
            bs.DataSource = dtResult;
            cboChanDoan.SelectedIndex = -1;
            for (int i = 0; i < ctrResult.Length; i++)
            {
                LabServices_Helper.CheckAndSetBindData(ctrResult[i], bs);
            }
            Load_DonThuoc();
        }

        private void Load_ConfigData()
        {
            Load_BacSi();
            Load_ChanDoan();
            Load_DM_NhomThuoc();
        }
        private void Load_ChanDoan()
        {
            data.Get_ChanDoan(cboChanDoan);
        }
        private void Load_BacSi()
        {
            C_NguoiDung user = new C_NguoiDung();
            user.Get_UserSign(cboBacSi, ServiceType.KhamBenh, " and d.MaNguoiDung not in ('admin')", txtTenBacSi);
        }
        private void Load_DM_NhomThuoc()
        {
            sysConfig.Get_DM_Thuoc_NhomThuoc(cboNhomThuoc);
            var tb = sysConfig.Get_DM_Thuoc_CachDung();

            repositoryItemLookUpEdit1.DataSource = tb;
            repositoryItemLookUpEdit1.ValueMember = "ID";
            repositoryItemLookUpEdit1.DisplayMember = "TenCachDung";
            
        }

        private void Load_DM_Thuoc()
        {
            string _MaGocThuoc = (cboNhomThuoc.SelectedIndex == -1 ? "" : cboNhomThuoc.SelectedValue.ToString().Trim());

            string _MaYeuCau = (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString());

            var tb = sysConfig.Get_DM_Thuoc_List("", _MaGocThuoc, txtSID.Text, _MaKhoa, _MaYeuCau);
            gcThuoc.DataSource = tb;
            gvThuoc.ExpandAllGroups();
        }
        private void btnLuuKQKB_Click(object sender, EventArgs e)
        {
            Update_KhamBenh(true);
        }
        private void Update_KhamBenh(bool _Mess)
        {
            string _MaBacSi = (cboBacSi.SelectedIndex == -1 ? "" : cboBacSi.SelectedValue.ToString().Trim());

            if (kb.Update_KhamBenh_KetQua(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), _MaBacSi,
                  txtTenBacSi.Text, dtpNgayKham.Value, txtChanDoan.Text, txtDeNghi.Text, txtGhiChu.Text, chkTaiKham.Checked, dtpTaiKham.Value) &&
                  kb.Update_KhamCoBan(txtSID.Text, _MaKhoa, txtCanNang.Text, txtChieuCao.Text, txtHuyetAp.Text, txtMach.Text, txtNhipTho.Text,
                  txtNhietDo.Text))
            {
                if (_Mess)
                {
                    CustomMessageBox.MSG_Information_OK("Lưu hoàn tất!");
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Lưu thất bại!");
            }
        }
        private void Insert_DonThuoc(string _ID, bool _Profile)
        {
            if (txtSID.Text != "")
            {
                kb.Insert_KhamBenh_DonThuoc(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), _ID, _Profile, CommonAppVarsAndFunctions.DonViGui);
            }
        }
        private void Update_DonThuoc(string _MaThuoc, string _Sang, string _Trua, string _Chieu, string _Toi, string _CachDung, string _DonVi, string _GhiChu, string _SoLuong)
        {
            kb.Update_KhamBenh_DonThuoc(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), _MaThuoc, Utilities.ConvertSqlString(_CachDung), _Sang, _Trua, _Chieu, _Toi, Utilities.ConvertSqlString(_GhiChu), _SoLuong);
        }
        private void Load_DonThuoc()
        {
            string _MaYeuCau = (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString());

            dtDonThuoc = kb.Get_KhamBenh_DonThuoc(txtSID.Text, _MaKhoa, _MaYeuCau, "", "");
            // Declare an object variable.

            var sumObject = dtDonThuoc.Compute("Sum(ThanhTien)", "");
            txtTotal.Text = string.Format("{0:###,###,###,###.###}", (string.IsNullOrEmpty(sumObject.ToString()) ? 0 : double.Parse(sumObject.ToString())));
            if (dtDonThuoc.Rows.Count > 0)
                txtThanhToan.Text = string.Format("{0:###,###,###,###.###}", double.Parse(dtDonThuoc.Rows[0]["TienThanhToan"].ToString()));
            else
                txtThanhToan.Text = "0";

            gcToaThuoc.DataSource = dtDonThuoc;
            //gvToaThuoc.ExpandAllGroups();
            Lock_Unlock_Control();
            Load_DM_Thuoc();
        }
        private void Load_DonThuocHistory()
        {
            var dt = kb.Get_KhamBenh_DonThuoc_History(txtMSBenhNhan.Text, txtSID.Text);
            gcToaThuocHistory.DataSource = dt;
            gvToaThuocHistory.ExpandAllGroups();
        }
        private void Lock_Unlock_Control()
        {
            bool _isLock = false;
            if (chkDaInYC.Checked || chkDaXacNhan.Checked)
            {
                _isLock = true;
            }
            else
                _isLock = false;

            dtpNgayKham.Enabled = !_isLock;
            dtpTaiKham.Enabled = !_isLock;
            cboBacSi.Enabled = !_isLock;
            cboChanDoan.Enabled = !_isLock;
            btnThemThuoc.Enabled = !_isLock;
            txtCanNang.Enabled = !_isLock;
            txtChanDoan.Enabled = !_isLock;
            txtChieuCao.Enabled = !_isLock;
            txtDeNghi.Enabled = !_isLock;
            txtGhiChu.Enabled = !_isLock;
            txtHuyetAp.Enabled = !_isLock;
            txtMach.Enabled = !_isLock;
            txtNhietDo.Enabled = !_isLock;
            txtNhipTho.Enabled = !_isLock;
            chkTaiKham.Enabled = !_isLock;
            btnLuuKQKB.Enabled = !_isLock;
            btnDeleteItem.Enabled = !_isLock;

            gvToaThuoc.Columns["SoLuong"].OptionsColumn.ReadOnly =
            gvToaThuoc.Columns["Sang"].OptionsColumn.ReadOnly =
            gvToaThuoc.Columns["Trua"].OptionsColumn.ReadOnly =
            gvToaThuoc.Columns["Chieu"].OptionsColumn.ReadOnly =
            gvToaThuoc.Columns["Toi"].OptionsColumn.ReadOnly =
            gvToaThuoc.Columns["CachDung"].OptionsColumn.ReadOnly =
            gvToaThuoc.Columns["GhiChu"].OptionsColumn.ReadOnly = _isLock;

            if (chkDaXacNhan.Checked)
                btnValidResult.Text = "Hủy xác nhận";
            else
                btnValidResult.Text = "Xác nhận";
            btnLuuThanhToan.Enabled = !chkDaXacNhan.Checked;
            txtThanhToan.ReadOnly = chkDaXacNhan.Checked;

        }
        private void cboNhomThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DM_Thuoc();
                e.Handled = true;
            }
        }
        private void UpdateResult(int rowIndex)
        {
            if (gvToaThuoc.RowCount == 0)
                return;

            try
            {
                var _MaThuoc = gvToaThuoc.GetRowCellValue(rowIndex, colMaThuoc) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colMaThuoc).ToString().Trim()
                    : string.Empty;
                var _Sang = gvToaThuoc.GetRowCellValue(rowIndex, colSang) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colSang).ToString().Trim()
                    : string.Empty;
                var _Trua = gvToaThuoc.GetRowCellValue(rowIndex, colTrua) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colTrua).ToString().Trim()
                    : string.Empty;
                var _Chieu = gvToaThuoc.GetRowCellValue(rowIndex, colChieu) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colChieu).ToString().Trim()
                    : string.Empty;
                var _Toi = gvToaThuoc.GetRowCellValue(rowIndex, colToi) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colToi).ToString().Trim()
                    : string.Empty;
                var _CachDung = gvToaThuoc.GetRowCellValue(rowIndex, colCachDung) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colCachDung).ToString().Trim()
                    : string.Empty;
                var _DonVi = gvToaThuoc.GetRowCellValue(rowIndex, colDonviTinh) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colDonviTinh).ToString()
                    : string.Empty;
                var _GhiChu = gvToaThuoc.GetRowCellValue(rowIndex, colGhiChu) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colGhiChu).ToString().Trim()
                    : string.Empty;
                var _SoLuong = gvToaThuoc.GetRowCellValue(rowIndex, colSoLuong) != null
                    ? gvToaThuoc.GetRowCellValue(rowIndex, colSoLuong).ToString()
                    : string.Empty;

                Update_DonThuoc(_MaThuoc, _Sang, _Trua, _Chieu, _Toi, _CachDung, _DonVi, _GhiChu, _SoLuong);
            }
            catch (Exception ex)
            {
                LogService.RecordLogError(ex.Message);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print_DonThuoc(true);
        }
        private void Print_DonThuoc(bool Print)
        {
            if (gvToaThuoc.RowCount > 0)
            {
                string _printerName = "";
                if (listPrinter.SelectedItem != null)
                {
                    _printerName = listPrinter.SelectedItem.ToString();
                }
                KiemTra_NgayTaiKham();
                if (kb.Print_DonThuoc(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), Print, _printerName))
                {
                    Update_PrintOut(true);
                }
            }
        }

        private void KiemTra_NgayTaiKham()
        {
            if (chkDaInYC.Checked == false && chkTaiKham.Checked == false)
            {
                if (gvToaThuoc.RowCount > 0)
                {
                    float _avgDay = 0;
                    float _sang = 0;
                    float _trua = 0;
                    float _chieu = 0;
                    float _toi = 0;
                    float _tong = 0;
                    for (int i = 0; i < gvToaThuoc.RowCount; i++)
                    {
                        _tong = WorkingServices.IsNumeric(gvToaThuoc.GetRowCellValue(i, colSoLuong)) ? float.Parse(gvToaThuoc.GetRowCellValue(i, colSoLuong).ToString()) : 0;
                        if (_tong > 0)
                        {
                            _sang = WorkingServices.IsNumeric(gvToaThuoc.GetRowCellValue(i, colSang)) ? float.Parse(gvToaThuoc.GetRowCellValue(i, colSang).ToString()) : 0;
                            _trua = WorkingServices.IsNumeric(gvToaThuoc.GetRowCellValue(i, colTrua)) ? float.Parse(gvToaThuoc.GetRowCellValue(i, colTrua).ToString()) : 0;
                            _chieu = WorkingServices.IsNumeric(gvToaThuoc.GetRowCellValue(i, colChieu)) ? float.Parse(gvToaThuoc.GetRowCellValue(i, colChieu).ToString()) : 0;
                            _toi = WorkingServices.IsNumeric(gvToaThuoc.GetRowCellValue(i, colToi)) ? float.Parse(gvToaThuoc.GetRowCellValue(i, colToi).ToString()) : 0;

                            float _tempAVGday = _tong / (_sang + _trua + _chieu + _toi);
                            if (_tempAVGday > _avgDay)
                                _avgDay = _tempAVGday;
                        }
                    }

                    if (_avgDay > 0)
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật ngày tái khám \" " + dtpNgayKham.Value.AddDays((double)Math.Ceiling(_avgDay)).ToString("dd/MM/yyyy") + "\" ?"))
                        {
                            chkTaiKham.Checked = true;
                            dtpTaiKham.Value = dtpNgayKham.Value.AddDays((double)Math.Ceiling(_avgDay));
                            Update_KhamBenh(false);
                        }
                    }

                }
            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            Print_DonThuoc(false);
        }

        private void cboNhomThuoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_DM_Thuoc();
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            bool _haveCheck = false;
            foreach (int i in gvThuoc.GetSelectedRows())
            {
                _haveCheck = true;
                var maThuoc = gvThuoc.GetRowCellValue(i, colMaThuoc2) != null ? gvThuoc.GetRowCellValue(i, colMaThuoc2).ToString() : string.Empty;

                if (!string.IsNullOrEmpty(maThuoc))
                {
                    Insert_DonThuoc(maThuoc, false);
                    gvThuoc.UnselectRow(i);
                }
            }

            if (!_haveCheck)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn thuốc!");
            }
            else
            {
                Load_DonThuoc();
            }
        }

        private void lstThuoc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }
        private void Delete_Thuoc()
        {
            if (gvToaThuoc.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các chỉ định thuốc được chọn?"))
                {
                    cboNhomThuoc.Focus();

                    foreach (int i in gvToaThuoc.GetSelectedRows())
                    {
                        kb.Delete_KhamBenh_DonThuoc(gvToaThuoc.GetRowCellValue(i, colMaThuoc).ToString(), txtSID.Text, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), _MaKhoa);
                    }
                    Load_DonThuoc();
                }
            }
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            Delete_Thuoc();
        }
        private void Valid_Item(bool _isValid)
        {
            if (txtSID.Text != "")
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes((_isValid ? "Xác " : "Hủy xác") + " nhận kết quả khám bệnh?"))
                {
                    if (kb.Update_KhamBenh_BenhNhan_Valid(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), _isValid, CommonAppVarsAndFunctions.UserID))
                    {
                        Load_KhamBenh_KetQua(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()));
                        Load_KhamBenh(false, false);
                    }
                }
            }
        }
        private void btnValidResult_Click(object sender, EventArgs e)
        {
            Valid_Item(btnValidResult.Text == "Xác nhận");
        }

        private void chkDaInYC_Click(object sender, EventArgs e)
        {
            if (txtSID.Text != "")
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes((chkDaInYC.Checked ? "Xác " : "Hủy xác") + " nhận in kết quả khám bệnh?"))
                {
                    Update_PrintOut(chkDaInYC.Checked);
                }
            }
        }
        private void Update_PrintOut(bool _isPrint)
        {
            if (kb.Update_KhamBenh_BenhNhan_In(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()), CommonAppVarsAndFunctions.UserID, _isPrint))
            {
                Load_KhamBenh_KetQua(txtSID.Text, _MaKhoa, (cboYeuCauKhamBenh.SelectedIndex == -1 ? "" : cboYeuCauKhamBenh.SelectedValue.ToString()));
                Load_KhamBenh(false, true);
            }
        }
        private void btnRefreshResult_Click(object sender, EventArgs e)
        {
            Load_DonThuoc();
        }


        #endregion

        private void custom_Button1_Click(object sender, EventArgs e)
        {
            Load_ChiDinh_CLS();
        }

        private void mnuChiDinhCLS_Click(object sender, EventArgs e)
        {
            Load_ChiDinh_CLS();
        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {
            if (txtSex.Text.Trim().Equals("F", StringComparison.OrdinalIgnoreCase))
                lblSex.Text = "Nữ";
            else if (txtSex.Text.Trim().Equals("M", StringComparison.OrdinalIgnoreCase))
                lblSex.Text = "Nam";
            else
                lblSex.Text = "?";
        }

        private void txtSEQ_Enter(object sender, EventArgs e)
        {
            Load_DanhSach_ChiDinh();
        }

        private void txtSEQ_Click(object sender, EventArgs e)
        {
            txtSEQ.SelectAll();
        }

        private void txtSEQ_TextChanged(object sender, EventArgs e)
        {
            SearchPatient();
        }

        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_KhamBenh(true, false);
            Load_DonThuocHistory();
        }

        private void btnKqetQuaXN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSID.Text))
            {
                PrintResult(dtPatient, 0);
            }
        }

        private void PrintResult(DataTable dtInfo, int index)
        {
            var dtPrint = _xetnghiem.DuLieuIn_XN(dtInfo, index, false
                , CommonAppVarsAndFunctions.TempSignIdXetNghiem
                , string.Empty
                , true, DateTime.Now
                , CommonAppVarsAndFunctions.UserWorkPlace
                ,  string.Empty
                , false, new TestType.EnumTestType[] { TestType.EnumTestType.ThongThuong, TestType.EnumTestType.HuyetDo }
                , Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, true), CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemThoiGianInKetQuaLanDau);


            string printerName = "";
            if (listPrinter.SelectedItem != null)
            {
                printerName = listPrinter.SelectedItem.ToString();
            }

            if (dtPrint != null && dtPrint.Rows.Count > 0)
            {
                var ic = new ImageConverter();
                var barcode =
                    (byte[])
                        ic.ConvertTo(
                            Code128Rendering.MakeBarcodeImage(
                                string.Format("{0:yyMMdd}{1}",
                                    DateTime.Parse(dtPrint.Rows[0]["NgayTiepNhan"].ToString()),
                                    dtPrint.Rows[0]["SEQ"].ToString().Trim()), 1, true),
                            typeof(byte[]));
                for (var i = 0; i < dtPrint.Rows.Count; i++)
                {
                    dtPrint.Rows[i]["Barcode"] = barcode;
                }

                DataTable dtPrintTemp = dtPrint.Copy();

                //if (_report.IsDisposed)
                //{
                //    progressPrint.Value++;
                //    _report = new FrmReport();
                //}
                //_report.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();

                //var rp = new ReportClass();

                //rp = new Reports.rpKQXetNghiem();
                //dtPrint = WorkingServices.SearchResult_OnDatatable(dtPrintTemp, "MaNhomCLS not in ('VS') and isnull(ProfileID,'') not in ('HD')");



                //_report.SampleID = string.Format("Ketqua_{0}", dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
                //_report.Excute_Show_Print_Report(rp, dtPrint, "XN", false, false, true, false, printerName, true);

                //rp = new Reports.rpKQXetNghiem_HuyetDo();
                //dtPrint = WorkingServices.SearchResult_OnDatatable(dtPrintTemp, "ProfileID = 'HD'");

                //if (dtPrint.Rows.Count > 0)
                //{
                //    if (_report.IsDisposed)
                //    {
                //        progressPrint.Value++;
                //        _report = new FrmReport();
                //    }
                //    _report.SampleID = string.Format("Ketqua_HuyetDo_{0}", dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
                //    _report.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();
                //    _report.Excute_Show_Print_Report(rp, dtPrint, "XN", false, false, true, false, printerName, true);

                //}
                //rp = new Reports.rpKQXetNghiem_ViSinh_TQ();
                //dtPrint = WorkingServices.SearchResult_OnDatatable(dtPrintTemp, "MaNhomCLS = 'VS'");

                //if (dtPrint.Rows.Count > 0)
                //{

                //    if (_report.IsDisposed)
                //    {
                //        progressPrint.Value++;
                //        _report = new FrmReport();
                //    }
                //    _report.SampleID = string.Format("Ketqua_Visinh_{0}", dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
                //    _report.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();
                //    _report.Excute_Show_Print_Report(rp, dtPrint, "XN", false, false, true, false, printerName, true);
                //}
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Không có dữ liệu để xem !");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuThanhToan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSID.Text))
            {
                kb.Update_ThanhToan(txtSID.Text, double.Parse(string.IsNullOrEmpty(txtThanhToan.Text.Trim()) ? "0" : txtThanhToan.Text.Trim().Replace(",", "")));
            }
        }

        private void txtThanhToan_Leave(object sender, EventArgs e)
        {
            txtThanhToan.Text = string.IsNullOrEmpty(txtThanhToan.Text.Trim()) ? "0" : string.Format("{0:###,###,###,###.###}", double.Parse(txtThanhToan.Text.Trim().Replace(",", "")));
        }

        private void gvToaThuoc_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name.Equals("colNo"))
            {
                e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gcToaThuoc_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gcToaThuoc.FocusedView as ColumnView).FocusedRowHandle++;
                (gcToaThuoc.FocusedView as ColumnView).ShowEditor();
                e.Handled = true;
            }
        }

        private void gvToaThuoc_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("SoLuong", StringComparison.OrdinalIgnoreCase) || e.Column.FieldName.Equals("Sang", StringComparison.OrdinalIgnoreCase) || 
                e.Column.FieldName.Equals("Trua", StringComparison.OrdinalIgnoreCase) || e.Column.FieldName.Equals("Chieu", StringComparison.OrdinalIgnoreCase) || 
                e.Column.FieldName.Equals("Toi", StringComparison.OrdinalIgnoreCase) || e.Column.FieldName.Equals("CachDung", StringComparison.OrdinalIgnoreCase) ||
                e.Column.FieldName.Equals("GhiChu", StringComparison.OrdinalIgnoreCase))
            {
                UpdateResult(e.RowHandle);
            }
        }
    }
}
