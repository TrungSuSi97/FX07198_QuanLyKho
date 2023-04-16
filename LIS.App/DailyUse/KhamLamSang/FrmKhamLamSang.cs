using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.ThucThi.KhamLamSang
{
    public partial class FrmKhamLamSang : FrmTemplate
    {
        public FrmKhamLamSang()
        {
            InitializeComponent();
        }

        DateTime dtDateIn = new DateTime();
        C_KhamBenh_DonThuoc kb = new C_KhamBenh_DonThuoc();
        C_Patient pInfo = new C_Patient();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();

        DataTable dtDonThuoc = new DataTable();
        string _MaKhoa = "";

        public string MaKhoa
        {
            get { return _MaKhoa; }
            set { _MaKhoa = value; }
        }
        public DateTime DtDateIn
        {
            get { return dtDateIn; }
            set { dtDateIn = value; }
        }
        string _SoThuTu = "";

        public string SoThuTu
        {
            get { return _SoThuTu; }
            set { _SoThuTu = value; }
        }

        bool _FromKhamBenh = false;

        public bool FromKhamBenh
        {
            get { return _FromKhamBenh; }
            set { _FromKhamBenh = value; }
        }

        private string _MayInDonThuoc = "";

        public string MayInDonThuoc
        {
            get { return _MayInDonThuoc; }
            set { _MayInDonThuoc = value; }
        }

        private string _MaTiepNhanG = "";

        public string MaTiepNhanG
        {
            get { return _MaTiepNhanG; }
            set { _MaTiepNhanG = value; }
        }

        string _MaYeuCau_Current = "";
        string _MaTiepNhan_Current = "";
        string _MaKhoa_Current = "";
        bool _DaXacNhan = false;

        public bool DaXacNhan
        {
            get { return _DaXacNhan; }
            set { _DaXacNhan = value; }
        }

        bool _DaIn = false;

        public bool DaIn
        {
            get { return _DaIn; }
            set { _DaIn = value; }
        }
        // khai báo 1 hàm delegate
        public delegate void Re_FreshInfo(bool _RefreshList);
        // khai báo 1 kiểu hàm delegate
        public Re_FreshInfo Refresh_KhamBenhInfo;

        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        private void FrmKhamLamSang_Load(object sender, EventArgs e)
        {
            if (_FromKhamBenh)
            {
                pnLabel.Visible = false;
                btnClose.Visible = false;
            }

            Get_ObjectResult();
            Load_ConfigData();

        }
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
            _MaKhoa_Current = _DonVi;
            _MaTiepNhan_Current = _MaTiepNhan;
            _MaYeuCau_Current = _MaYeuCau;

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
            Load_DM_Thuoc();
            sysConfig.Get_DM_Thuoc_CachDung(CachDung, "");
        }

        private void Load_DM_Thuoc()
        {
            if (cboNhomThuoc.SelectedIndex == -1)
            {
                lstThuoc.View = View.Details;
                txtTenNhomThuoc.Text = "Tất cả thuốc";
            }
            else
                lstThuoc.View = View.List;
            string _MaGocThuoc = (cboNhomThuoc.SelectedIndex == -1 ? "" : cboNhomThuoc.SelectedValue.ToString().Trim());
            sysConfig.Get_DM_Thuoc_List(lstThuoc, imageList1, 4, "", _MaGocThuoc);
            sysConfig.GET_THUOC_VA_PROFILE(cboItem, txtItemName, _MaGocThuoc);
        }
        private void btnLuuKQKB_Click(object sender, EventArgs e)
        {
            Update_KhamBenh(true);
        }
        private void Update_KhamBenh(bool _Mess)
        {
            string _MaBacSi = (cboBacSi.SelectedIndex == -1 ? "" : cboBacSi.SelectedValue.ToString().Trim());

            if (kb.Update_KhamBenh_KetQua(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, _MaBacSi,
                  txtTenBacSi.Text, dtpNgayKham.Value, txtChanDoan.Text, txtDeNghi.Text, txtGhiChu.Text, chkTaiKham.Checked, dtpTaiKham.Value) &&
                  kb.Update_KhamCoBan(_MaTiepNhan_Current, _MaKhoa_Current, txtCanNang.Text, txtChieuCao.Text, txtHuyetAp.Text, txtMach.Text, txtNhipTho.Text,
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
            if (_MaTiepNhan_Current != "")
            {
                kb.Insert_KhamBenh_DonThuoc(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, _ID, _Profile, CommonAppVarsAndFunctions.DonViGui);
            }
        }
        private void Update_DonThuoc(string _MaThuoc, string _Sang, string _Trua, string _Chieu, string _Toi, string _CachDung, string _DonVi, string _GhiChu, string _SoLuong)
        {
            kb.Update_KhamBenh_DonThuoc(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, _MaThuoc, Utilities.ConvertSqlString(_CachDung), _Sang, _Trua, _Chieu, _Toi,Utilities.ConvertSqlString(_GhiChu), _SoLuong);
        }
        private void Load_DonThuoc()
        {
            kb.Get_KhamBenh_DonThuoc(dtgChiDinhThuoc, bvChiDinhThuoc, ref dtDonThuoc, _MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, "", "");
            btnCheckAll.Text = "Check";
            btnCheckAll.Image = imageList1.Images[0];
            Lock_Unlock_Control();
        }
        private void Lock_Unlock_Control()
        {
            bool _isLock = false;
            if (chkDaInYC.Checked || chkXacNhan.Checked)
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
            dtgChiDinhThuoc.ReadOnly = _isLock;
            if (chkXacNhan.Checked)
                btnValidResult.Text = "Hủy xác nhận";
            else
                btnValidResult.Text = "Xác nhận";

        }
        private void cboNhomThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DM_Thuoc();
                lstThuoc.Focus();
                e.Handled = true;
            }
        }

        private void dtgChiDinhThuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 1)
            {
                string _MaThuoc = ""; string _Sang = "";
                string _Trua = ""; string _Chieu = "";
                string _Toi = ""; string _CachDung = "";
                string _DonVi = ""; string _GhiChu = "";
                string _SoLuong = "";
                _MaThuoc = dtgChiDinhThuoc["MaThuoc", e.RowIndex].Value.ToString().Trim();
                _Sang = dtgChiDinhThuoc["Sang", e.RowIndex].Value.ToString().Trim();
                _Trua = dtgChiDinhThuoc["Trua", e.RowIndex].Value.ToString().Trim();
                _Chieu = dtgChiDinhThuoc["Chieu", e.RowIndex].Value.ToString().Trim();
                _Toi = dtgChiDinhThuoc["Toi", e.RowIndex].Value.ToString().Trim();
                _CachDung = (dtgChiDinhThuoc["CachDung", e.RowIndex].Value == null ? "" : dtgChiDinhThuoc["CachDung", e.RowIndex].Value.ToString().Trim());
                _DonVi = dtgChiDinhThuoc["DonViTinh", e.RowIndex].Value.ToString().Trim();
                _GhiChu = (dtgChiDinhThuoc["GhiChu", e.RowIndex].Value == null ? "" : dtgChiDinhThuoc["GhiChu", e.RowIndex].Value.ToString().Trim());
                _SoLuong = dtgChiDinhThuoc["SoLuong", e.RowIndex].Value.ToString().Trim();
                Update_DonThuoc(_MaThuoc, _Sang, _Trua, _Chieu, _Toi, _CachDung, _DonVi, _GhiChu, _SoLuong);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print_DonThuoc(true);
        }
        private void Print_DonThuoc(bool Print)
        {
            if (dtgChiDinhThuoc.RowCount > 0)
            {
                KiemTra_NgayTaiKham();
                if (kb.Print_DonThuoc(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, Print, _MayInDonThuoc))
                {
                    Update_PrintOut(true);
                }
            }
        }

        private void KiemTra_NgayTaiKham()
        {
            if (chkDaInYC.Checked == false && chkTaiKham.Checked == false)
            {
                if (dtgChiDinhThuoc.RowCount > 0)
                {
                    float _avgDay = 0;
                    float _sang = 0;
                    float _trua = 0;
                    float _chieu = 0;
                    float _toi = 0;
                    float _tong = 0;
                    for (int i = 0; i < dtgChiDinhThuoc.RowCount; i++)
                    {
                        _tong = WorkingServices.IsNumeric(dtgChiDinhThuoc[SoLuong.Name, i].Value.ToString()) ? float.Parse(dtgChiDinhThuoc[SoLuong.Name, i].Value.ToString()) : 0;
                        if (_tong > 0)
                        {
                            _sang = WorkingServices.IsNumeric(dtgChiDinhThuoc[Sang.Name, i].Value.ToString()) ? float.Parse(dtgChiDinhThuoc[Sang.Name, i].Value.ToString()) : 0;
                            _trua = WorkingServices.IsNumeric(dtgChiDinhThuoc[Trua.Name, i].Value.ToString()) ? float.Parse(dtgChiDinhThuoc[Trua.Name, i].Value.ToString()) : 0;
                            _chieu = WorkingServices.IsNumeric(dtgChiDinhThuoc[Chieu.Name, i].Value.ToString()) ? float.Parse(dtgChiDinhThuoc[Chieu.Name, i].Value.ToString()) : 0;
                            _toi = WorkingServices.IsNumeric(dtgChiDinhThuoc[Toi.Name, i].Value.ToString()) ? float.Parse(dtgChiDinhThuoc[Toi.Name, i].Value.ToString()) : 0;

                            float _tempAVGday = _tong / (_sang + _trua + _chieu + _toi);
                            if (_tempAVGday > _avgDay)
                                _avgDay = _tempAVGday;
                        }
                    }

                    if (_avgDay > 0)
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật ngày tái khám \" "+ dtpNgayKham.Value.AddDays((double)Math.Ceiling(_avgDay)).ToString("dd/MM/yyyy") +"\" ?"))
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

            //Mã thuốc gán vào item.name
            foreach (ListViewItem i in lstThuoc.Items)
            {
                if (i.Checked)
                {
                    Insert_DonThuoc(i.Name, false);
                    _haveCheck = true;
                }
            }
            Load_DonThuoc();
            if (!_haveCheck)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn thuốc!");
            }
        }

        private void lstThuoc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
        }

        private void lstThuoc_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (e.CurrentValue == CheckState.Checked)
            {
                lstThuoc.Items[e.Index].BackColor = Color.Yellow;
                lstThuoc.Items[e.Index].Selected = true;
            }
            else
            {
                lstThuoc.Items[e.Index].BackColor = Color.Transparent;
                lstThuoc.Items[e.Index].Selected = true;
            }

        }

        private void Delete_Thuoc()
        {
            if (dtgChiDinhThuoc.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các chỉ định thuốc được chọn?"))
                {
                    txtTenNhomThuoc.Focus();
                    for (int i = 0; i < dtgChiDinhThuoc.RowCount; i++)
                    {
                        if (dtgChiDinhThuoc[Select.Name, i].Value != null)
                        {
                            if ((bool)dtgChiDinhThuoc[Select.Name, i].Value)
                            {
                                kb.Delete_KhamBenh_DonThuoc(dtgChiDinhThuoc[MaThuoc.Name, i].Value.ToString(), _MaTiepNhan_Current, _MaYeuCau_Current, _MaKhoa_Current);
                            }
                        }
                    }
                    Load_DonThuoc();
                }
            }
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            Delete_Thuoc();
        }

        private void btnCheckItem_Click(object sender, EventArgs e)
        {
            Check_All_Item();
        }
        private void Check_All_Item()
        {
            txtTenNhomThuoc.Focus();
            bool _Check = false;
            if (btnCheckAll.Text == "Uncheck")
            {
                _Check = false;
                btnCheckAll.Text = "Check";
                btnCheckAll.Image = imageList1.Images[0];
            }
            else
            {
                _Check = true;
                btnCheckAll.Text = "Uncheck";
                btnCheckAll.Image = imageList1.Images[1];
            }
            if (dtgChiDinhThuoc.RowCount > 0)
            {
                for (int i = 0; i < dtgChiDinhThuoc.RowCount; i++)
                {
                    dtgChiDinhThuoc[Select.Name, i].Value = _Check;
                }
            }
        }
        private void Valid_Item(bool _isValid)
        {
            if (_MaTiepNhan_Current != "")
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes((_isValid ? "Xác " : "Hủy xác") + " nhận kết quả khám bệnh?"))
                {
                    if (kb.Update_KhamBenh_BenhNhan_Valid(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, _isValid, CommonAppVarsAndFunctions.UserID))
                    {
                        Load_KhamBenh_KetQua(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current);
                        Refresh_KhamBenhInfo(false);
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
            if (_MaTiepNhan_Current != "")
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes((chkDaInYC.Checked ? "Xác " : "Hủy xác") + " nhận in kết quả khám bệnh?"))
                {
                    Update_PrintOut(chkDaInYC.Checked);
                }
            }
        }
        private void Update_PrintOut(bool _isPrint)
        {
            if (kb.Update_KhamBenh_BenhNhan_In(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current, CommonAppVarsAndFunctions.UserID, _isPrint))
            {
                Load_KhamBenh_KetQua(_MaTiepNhan_Current, _MaKhoa_Current, _MaYeuCau_Current);
                Refresh_KhamBenhInfo(true);
            }
        }
        private void btnRefreshResult_Click(object sender, EventArgs e)
        {
            Load_DonThuoc();
        }

        private void cboItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboItem.SelectedIndex != -1)
                {
                    bool _isProfile = (bool)((DataTable)cboItem.DataSource).Rows[cboItem.SelectedIndex]["isProfile"];
                    string _ItemId = cboItem.SelectedValue.ToString().Trim();
                    Insert_DonThuoc(_ItemId, _isProfile);
                    Load_DonThuoc();
                }
            }
        }

        private void lstThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               
            }
        }
    }
}
