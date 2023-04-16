using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class frmPatient : frmTemplate
    {
        public frmPatient()
        {
            InitializeComponent();
        }
        DataTable dtPatient = new DataTable();
        DataTable dtCLS_ChiDinhXetNghiem = new DataTable();
        DataTable dtCLS_ChiDinhSieuAm = new DataTable();
        SqlDataAdapter daPatient = new SqlDataAdapter();
        DataTable dtService = new DataTable();
        C_Patient info = new C_Patient();
        C_Data data = new C_Data();
        C_Config config = new C_Config();
        bool _loading = false;

        DateTime dtDateInG = new DateTime();

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

        //Khai báo các biến kiểm tra giá trị cũ
        string MaTiepNhanOLD = "",
            SeqOLD = "",
            MaBNOLD = "",
            TenBNOLD = "",
            SinhNhatOLD = "",
            TuoiOLD = "",
            CoNgaySinhOLD = "",
            GioiTinhOLD = "",
            NgayTiepNhanOLD = "",
            ThoiGianNhapOLD = "",
            UserNhapOLD = "",
            MaKhoaPhongOLD = "",
            DoiTuongDichVuOLD = "",
            DiaChiOLD = "",
            EmailOLD = "",
            SDTOLD = "",
            ChanDoanOLD = "",
            BacSiCDOLD = "",
            BacSiKLOLD = "",
            KetLuanOLD = "";

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Load_Service()
        {
            data.Get_DichVu(cboService, "", ref dtService);
        }
        private void Load_CLSNhomXN()
        {
            data.Get_MaNhomCLS(cboNhomCLS, "");
        }
        private void Load_DMXetNghiem()
        {
            if (_loading == false)
            {
                data.Get_LISTest(cboCLS_XetNghiem, (cboNhomCLS.SelectedIndex == -1 ? "" : cboNhomCLS.SelectedValue.ToString().Trim()));
            }
        }
        private void Load_DMMauSieuAm()
        {
            data.Get_DMSieuAm(cboChiDinhSieuAm, " where GioiTinhSuDung = '" + (txtSex.Text == "" ? "A" : txtSex.Text == "?" ? "A" : txtSex.Text) + "'");
        }
        private void Load_BacSi()
        {
            data.Get_NhanVien(cboBSChiDinh);
        }
        private void Load_ChanDoan()
        {
            data.Get_ChanDoan(cboChanDoan);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (txtSEQ.BackColor == Color.Yellow)
            {
                MessageBox.Show("Bạn đang trong chế độ nhập mới!");
                txtSEQ.Focus();
            }
            else
            {
                ClearControl(true,false);
                dtpDateIn.Value = C_Ultilities.ServerDate();
                txtSEQ.ReadOnly = false;
                txtSEQ.BackColor = Color.Yellow;
                txtSEQ.Focus();
                lblWarning.Text = "ĐANG CHẾ ĐỘ NHẬP MỚI";
            }
        }
        private void ClearControl(bool _addNew, bool _getInter)
        {
            if (_getInter == true)
            {
                txtTenBN.DataBindings.Clear();
                txtAddress.DataBindings.Clear();
                txtPhone.DataBindings.Clear();
                txtEmail.DataBindings.Clear();
                cboService.DataBindings.Clear();
                cboBSChiDinh.DataBindings.Clear();
                txtChanDoan.DataBindings.Clear();
                cboChanDoan.DataBindings.Clear();
                txtAge.DataBindings.Clear();
                txtSex.DataBindings.Clear();
                chkAgeType.DataBindings.Clear();
                dtpBirthday.DataBindings.Clear();
                lblSex.Text = "";
            }
            else
            {
                if (_addNew == true)
                {
                    txtSEQ.DataBindings.Clear();
                    txtSEQ.Text = "";
                }

                txtMaTiepNhan.DataBindings.Clear();
                txtMaTiepNhan.Text = "";
                txtMSBenhNhan.DataBindings.Clear();
                txtMSBenhNhan.Text = "";
                txtTenBN.DataBindings.Clear();
                txtTenBN.Text = "";
                txtAddress.DataBindings.Clear();
                txtAddress.Text = "";
                txtPhone.DataBindings.Clear();
                txtPhone.Text = "";
                txtEmail.DataBindings.Clear();
                txtEmail.Text = "";
                cboService.DataBindings.Clear();
                cboService.SelectedIndex = -1;
                cboBSChiDinh.DataBindings.Clear();
                cboBSChiDinh.SelectedIndex = -1;
                txtChanDoan.DataBindings.Clear();
                txtChanDoan.Text = "";
                cboChanDoan.DataBindings.Clear();
                cboChanDoan.SelectedIndex = -1;
                txtAge.DataBindings.Clear();
                txtAge.Text = "";
                txtSex.DataBindings.Clear();
                txtSex.Text = "";
                chkAgeType.DataBindings.Clear();
                chkAgeType.Checked = false;
                dtpBirthday.DataBindings.Clear();
                dtpBirthday.Value = DateTime.Now;
                lblSex.Text = "";
               
            }
            MaTiepNhanOLD = "";
            SeqOLD = "";
            MaBNOLD = "";
            TenBNOLD = "";
            SinhNhatOLD = "";
            TuoiOLD = "";
            CoNgaySinhOLD = "False";
            GioiTinhOLD = "";
            NgayTiepNhanOLD = "";
            ThoiGianNhapOLD = "";
            UserNhapOLD = "";
            MaKhoaPhongOLD = "";
            DoiTuongDichVuOLD = "";
            DiaChiOLD = "";
            EmailOLD = "";
            SDTOLD = "";
            ChanDoanOLD = "";
            BacSiCDOLD = "";
            BacSiKLOLD = "";
            KetLuanOLD = "";

        }
        private void BindPatient(DataTable dt, bool _addNew, bool _inter)
        {
            ClearControl(_addNew, _inter);
            if (_inter == false)
            {
                if (_addNew == false)
                {
                    txtSEQ.DataBindings.Clear();
                    txtSEQ.DataBindings.Add("Text", dt, "SEQ");
                    txtSEQ.ReadOnly = true;
                    txtSEQ.BackColor = Color.White;
                }
                txtMaTiepNhan.DataBindings.Add("Text", dt, "MaTiepNhan");
                txtMSBenhNhan.DataBindings.Add("Text", dt, "MaBN");
            }
            lblWarning.Text = "";
            txtTenBN.DataBindings.Add("Text", dt, "TenBN");
            txtAddress.DataBindings.Add("Text", dt, "DiaChi");
            txtPhone.DataBindings.Add("Text", dt, "SDT");
            txtEmail.DataBindings.Add("Text", dt, "Email");
            txtAge.DataBindings.Add("Text", dt, "Tuoi");
            chkAgeType.DataBindings.Add("Checked", dt, "CoNgaySinh");
            dtpBirthday.DataBindings.Add("Value", dt, "SinhNhat", true, DataSourceUpdateMode.OnValidation, DateTime.Now);
            cboService.DataBindings.Add("SelectedValue", dt, "DoiTuongDichVu");
            cboBSChiDinh.DataBindings.Add("SelectedValue", dt, "BacSiCD");
            txtChanDoan.DataBindings.Add("Text", dt, "ChanDoan");
            txtSex.DataBindings.Add("Text", dt, "GioiTinh");
            if (_inter == false)
            {
                GetInfo();
            }
        }
        private void Load_TiepNhan(string _ID)
        {
            _loading = true;
            string _MaTiepNhan = info.MaTiepNhan(_ID, dtpDateIn.Value);
            dtPatient = new DataTable();
            dtPatient = info.GetPateint(_MaTiepNhan);
            BindPatient(dtPatient, false,false);
            data.Get_CLS_KetQua(dtgCLS_ChiDinhXN, bvCLS_ChiDinhXN, " MaTiepNhan ='" + info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'", ref dtCLS_ChiDinhXetNghiem);
            data.Get_CLS_KetQua_SieuAm(dtgChiDinhSieuAm, bvChiDinhSieuAm, " MaTiepNhan ='" + info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'", ref dtCLS_ChiDinhSieuAm);
            _loading = false;
        }
        private void InsertDichVuXN()
        {
            if (cboService.SelectedIndex != -1 && cboCLS_XetNghiem.SelectedIndex != -1)
            {
                bool Profile = false;
                if (txtProfile.Text == "*")
                {
                    Profile = true;
                }
                info.Insert_ChiDinhXetNghiem(info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), cboCLS_XetNghiem.SelectedValue.ToString().Trim(), cboService.SelectedValue.ToString().Trim(), Profile);
                data.Get_CLS_KetQua(dtgCLS_ChiDinhXN, bvCLS_ChiDinhXN, " MaTiepNhan ='" + info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'", ref dtCLS_ChiDinhXetNghiem);
                cboCLS_XetNghiem.DroppedDown = true;
            }
        }
        private void InsertDichVuSieuAm()
        {
            if (cboService.SelectedIndex != -1 && cboChiDinhSieuAm.SelectedIndex != -1)
            {
                info.Insert_ChiDinhSieuAm(info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), cboChiDinhSieuAm.SelectedValue.ToString().Trim(), cboService.SelectedValue.ToString().Trim());
                data.Get_CLS_KetQua_SieuAm(dtgChiDinhSieuAm, bvChiDinhSieuAm, " MaTiepNhan ='" + info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'", ref dtCLS_ChiDinhSieuAm);
                cboChiDinhSieuAm.DroppedDown = true;
            }
        }
        private void chkAgeType_CheckedChanged(object sender, EventArgs e)
        {
            dtpBirthday.Visible = chkAgeType.Checked;
            CheckSave();
            if (chkAgeType.Checked)
            {
                dtpBirthday.Focus();
            }
        }
        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (chkAgeType.Checked)
            {
                txtAge.Text = dtpBirthday.Value.Year.ToString();
            }
            CheckSave();
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.KeyNumber(e, false);
            ProcessServices.LeaveFocus(e, txtSex);
        }
        private void txtSex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                lblSex.Text = "Nữ";
            }
            else if (e.KeyCode == Keys.M)
            {
                lblSex.Text = "Nam";
            }
            else if (e.KeyCode == Keys.OemQuestion)
            {
                lblSex.Text = "Khác";
            }
            else
            {
                txtSex.Text = "";
                lblSex.Text = "";
                txtSex.Focus();
            }
        }
        private void txtSex_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, cboService);
        }
        private void cboService_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, txtAddress);
        }
        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, txtEmail);
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, txtPhone);
        }
        private void Insert_Update_Patient(bool _insert, bool _fromCheck)
        {
            string Seq = txtSEQ.Text, MaTiepNhan = info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value),
                MaBN = txtMSBenhNhan.Text,
                TenBN = txtTenBN.Text,
                SinhNhat = (chkAgeType.Checked == true ? dtpDateIn.Value.ToString("yyyy/MM/dd") : ""),
                Tuoi = txtAge.Text == "" ? "0" : txtAge.Text,
                CoNgaySinh = chkAgeType.Checked == true ? "1" : "0",
                GioiTinh = txtSex.Text,
                NgayTiepNhan = dtpDateIn.Value.ToString("yyyy/MM/dd"),
                UserNhap = frmMDIParent.UserID,
                MaKhoaPhong = "",
                DoiTuongDichVu = (cboService.SelectedIndex != -1 ? cboService.SelectedValue.ToString() : ""),
                DiaChi = txtAddress.Text,
                Email = txtEmail.Text,
                SDT = txtPhone.Text,
                ChanDoan = txtChanDoan.Text,
                BacSiCD = cboBSChiDinh.SelectedIndex == -1 ? "" : cboBSChiDinh.SelectedValue.ToString().Trim(),
                BacSiKL = "",
                KetLuan = "";

            if (_insert)
            {
                if (_fromCheck == true && (txtSEQ.Text == "" || cboService.SelectedIndex == -1))
                {
                    return;
                }
                else
                {
                    if (info.InsertPatient(MaTiepNhan, Seq, MaBN, TenBN, SinhNhat, Tuoi,
                    CoNgaySinh, GioiTinh, NgayTiepNhan, UserNhap, MaKhoaPhong,
                    DoiTuongDichVu, DiaChi, Email, SDT, ChanDoan, BacSiCD, BacSiKL, KetLuan) == false)
                    {
                        MessageBox.Show("Quá trình thêm mới bị lỗi", Warnings.CAPTION);
                    }
                    else
                    {
                        txtSEQ.BackColor = Color.White;
                        if (chkAutoSave.Checked && _fromCheck == true)
                        {
                            lblWarning.Text = "THÔNG TIN VỪA LƯU TỰ DỘNG";
                        }
                        else
                        {
                            lblWarning.Text = "THÔNG TIN ĐÃ ĐƯỢC LƯU";
                        }

                    }
                }
            }
            else
            {
                if (info.UpdatePatient(MaTiepNhan,MaBN, TenBN, SinhNhat, Tuoi, CoNgaySinh, GioiTinh, NgayTiepNhan,
                     UserNhap, MaKhoaPhong, DoiTuongDichVu, DiaChi, Email, SDT, ChanDoan, BacSiCD,
                     BacSiCD, KetLuan) == false)
                {
                    MessageBox.Show("Quá trình cập nhật bị lỗi", Warnings.CAPTION);
                }
                else
                {
                    if (chkAutoSave.Checked && _fromCheck == true)
                    {
                        lblWarning.Text = "THÔNG TIN VỪA LƯU TỰ DỘNG";
                    }
                    else
                    {
                        lblWarning.Text = "THÔNG TIN ĐÃ ĐƯỢC LƯU";
                    }
                }

            }
            timerAlertUpdate.Enabled = false;
            btnSave.BackColor = SystemColors.ButtonFace;
            dtPatient = info.GetPateint(MaTiepNhan);
            GetInfo();
            lblWarning.BackColor = Color.Transparent;
        }
        private void Get_InterInfo(string _MaBN)
        {
            DataTable dtInfoInter = new DataTable();
            dtInfoInter = info.LayThongtin_NoiTru(_MaBN);
            if (dtInfoInter.Rows.Count > 0)
            {
                BindPatient(dtInfoInter, false, true);
                txtTenBN.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboService.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Loại DV !", Warnings.CAPTION);
                cboService.Focus();
                cboService.DroppedDown = true;
            }
            else
            {
                Insert_Update_Patient((txtSEQ.BackColor == Color.Yellow ? true : false), false);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (txtSEQ.BackColor == Color.Yellow)
            {
                ClearControl(true,false);
                data.Get_CLS_KetQua(dtgCLS_ChiDinhXN, bvCLS_ChiDinhXN, " MaTiepNhan ='" + info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'", ref dtCLS_ChiDinhXetNghiem);
                txtSEQ.BackColor = Color.White;
            }
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            _loading = true;
            Check_Enable();
            Load_Service();
            Load_CLSNhomXN();
            Load_BacSi();
            Load_ChanDoan();
            Load_DMMauSieuAm();
            _loading = false;
            Load_DMXetNghiem();
            txtSearch.Focus();
            if (_MatiepNhanG != "")
            {
                dtpDateIn.Value = dtDateInG;
                txtSearch.Text = _MatiepNhanG;
                Load_TiepNhan(txtSearch.Text);
            }
        }

        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.KeyNumber(e, false);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtSEQ.BackColor == Color.Yellow)
                {
                    txtMSBenhNhan.Focus();
                }
            }
        }

        private void txtSEQ_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSEQ.BackColor == Color.Yellow)
            {
                txtMaTiepNhan.Text = dtpDateIn.Value.ToString("ddMMyyyy") + "-" + txtSEQ.Text;
                txtMSBenhNhan.Text = "DT" + dtpDateIn.Value.ToString("ddMMyyyy") + txtSEQ.Text;
            }
        }

        private void txtSEQ_Leave(object sender, EventArgs e)
        {
            if (txtSEQ.BackColor == Color.Yellow)
            {
                if (ProcessServices.NotCheckExits("select top 1 * from CLS_TiepNhan where MaTiepNhan='" + info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value) + "'") == false)
                {
                    MessageBox.Show("Số thứ tự : " + txtSEQ.Text + " đã tồn tại !\nNhập số khác", Warnings.CAPTION);
                    txtSEQ.Focus();
                    txtSEQ.SelectAll();
                }
            }
            else
            {
                Load_TiepNhan(txtSEQ.Text);
            }
        }
        private void GetInfo()
        {
            MaTiepNhanOLD = txtMaTiepNhan.Text;
            SeqOLD = txtSEQ.Text;
            MaBNOLD = txtMSBenhNhan.Text;
            TenBNOLD = txtTenBN.Text;
            SinhNhatOLD = dtpBirthday.Value.ToString("yyyy/MM/dd");
            TuoiOLD = txtAge.Text;
            CoNgaySinhOLD = chkAgeType.Checked.ToString();
            GioiTinhOLD = txtSex.Text;
            NgayTiepNhanOLD = "";
            ThoiGianNhapOLD = "";
            UserNhapOLD = "";
            MaKhoaPhongOLD = "";
            DoiTuongDichVuOLD = cboService.SelectedIndex == -1 ? "" : cboService.SelectedValue.ToString().Trim();
            DiaChiOLD = txtAddress.Text;
            EmailOLD = txtEmail.Text;
            SDTOLD = txtPhone.Text;
            ChanDoanOLD = txtChanDoan.Text;
            BacSiCDOLD = cboBSChiDinh.SelectedIndex == -1 ? "" : cboBSChiDinh.SelectedValue.ToString().Trim();
            BacSiKLOLD = "";
            KetLuanOLD = "";
        }
        private void CheckSave()
        {
            if (txtSEQ.Text == "")
            {
                return;
            }
            else if (_loading == true)
            {
                return;
            }
            else
            {
                if (txtSEQ.BackColor != Color.Yellow)
                {
                    lblWarning.Text = "";
                }
                if (TenBNOLD != txtTenBN.Text ||
                        SinhNhatOLD != dtpBirthday.Value.ToString("yyyy/MM/dd") ||
                        TuoiOLD != txtAge.Text ||
                        CoNgaySinhOLD != chkAgeType.Checked.ToString() ||
                        GioiTinhOLD != txtSex.Text ||
                        NgayTiepNhanOLD != "" ||
                        ThoiGianNhapOLD != "" ||
                        UserNhapOLD != "" ||
                        MaKhoaPhongOLD != "" ||
                        DoiTuongDichVuOLD != (cboService.SelectedIndex == -1 ? "" : cboService.SelectedValue.ToString().Trim()) ||
                        DiaChiOLD != txtAddress.Text ||
                        EmailOLD != txtEmail.Text ||
                        SDTOLD != txtPhone.Text ||
                        ChanDoanOLD != txtChanDoan.Text ||
                        BacSiCDOLD != (cboBSChiDinh.SelectedIndex == -1 ? "" : cboBSChiDinh.SelectedValue.ToString().Trim()) ||
                        BacSiKLOLD != "" ||
                        MaBNOLD != txtMSBenhNhan.Text ||
                        KetLuanOLD != "")
                {
                    if (chkAutoSave.Checked == false)
                    {
                        timerAlertUpdate.Enabled = true;
                        lblWarning.Text = "NHẤN LƯU ĐỂ CẬP NHẬT";
                    }
                    else
                        Insert_Update_Patient(txtSEQ.BackColor == Color.Yellow ? true : false, true);
                }
            }
        }
        private void txtAge_Leave(object sender, EventArgs e)
        {
            if (txtAge.Text != "")
            {
                int _a = int.Parse(txtAge.Text);
                if (_a < 1000)
                {
                    _a = DateTime.Now.Year - _a;
                }
                txtAge.Text = _a.ToString();
            }
            CheckSave();
        }

        private void txtTenBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, txtAge);
        }

        private void txtTenBN_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void txtSex_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void cboService_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void cboBSChiDinh_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void txtBSChiDinh_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void cboChanDoan_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void txtChanDoan_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }

        private void timerAlertUpdate_Tick(object sender, EventArgs e)
        {
            if (btnSave.BackColor != Color.LightBlue)
            {
                btnSave.BackColor = Color.LightBlue;
            }
            else
            {
                btnSave.BackColor = SystemColors.ButtonFace;
            }
        }

        private void btnXoaBN_Click(object sender, EventArgs e)
        {
            if (dtPatient.Rows.Count > 0)
            {
                if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN7")==false)
                {
                    if (info.Check_HaveResult(info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), ""))
                    {
                        MessageBox.Show("Bệnh nhân đã có KQ.\nBạn không thể xóa bệnh nhân này!");
                        return;
                    }
                }
                if (MessageBox.Show("Xoá bệnh nhân: " + txtMaTiepNhan.Text + " ?", Warnings.CAPTION, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    info.DeletePatient(info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value));
                    ClearControl(true,false);
                }
            }
        }

        private void chkAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoSave.Checked)
            {
                CheckSave();
            }                
            
        }

        private void txtBSChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, cboChanDoan);
        }

        private void cboNhomCLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DMXetNghiem();
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            InsertDichVuXN();
        }

        private void cboCLS_XetNghiem_Leave(object sender, EventArgs e)
        {
            cboCLS_XetNghiem.DroppedDown = false;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtSearch.Text != "")
                {
                    Load_TiepNhan(txtSearch.Text);
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.LightGreen;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void cboNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboCLS_XetNghiem.Focus();
                cboCLS_XetNghiem.DroppedDown = true;
            }
            else
            {
                cboNhomCLS.DroppedDown = true;
            }
        }

        private void cboNhomCLS_DropDownClosed(object sender, EventArgs e)
        {
            cboCLS_XetNghiem.Focus();
            cboCLS_XetNghiem.DroppedDown = true;
        }

        private void cboCLS_XetNghiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InsertDichVuXN();
            }
        }


        private void LockControl(bool _isBlock)
        {
            btnAddNew.Enabled = btnAddTest.Enabled = btnCancel.Enabled = btnSave.Enabled = btnXoaBN.Enabled = btnDeleteCLS.Enabled = !_isBlock;
            cboCLS_XetNghiem.Enabled = cboNhomCLS.Enabled = _isBlock;
            chkAutoSave.Checked = chkAutoSave.Enabled = !_isBlock;
        }
        private void Check_Enable()
        {
            LockControl(true);

            if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN1"))
            {
                btnAddNew.Enabled = btnCancel.Enabled = btnSave.Enabled = true;
            }
            if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN2"))
            {
                btnSave.Enabled = true;
                chkAutoSave.Enabled = true;
                chkAutoSave.Checked = config.ReadReg("AutoSave") == "" ? false : bool.Parse(config.ReadReg("AutoSave"));
            }
            if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN3"))
            {
                btnAddTest.Enabled = true;
                cboNhomCLS.Enabled = true;
                cboCLS_XetNghiem.Enabled = true;
            }
            if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN4"))
            {
                //Xóa chỉ định
                btnDeleteCLS.Enabled = true;
            }
            if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN5"))
            {
                btnXoaBN.Enabled = true;
            }
        }

        private void btnDeleteCLS_Click(object sender, EventArgs e)
        {
            btnAddNew.Focus();
            if (dtgCLS_ChiDinhXN.Rows.Count > 0)
            {
                int _total = 0, _uncheck = 0;
                string _matiepnhan = info.MaTiepNhan(txtSEQ.Text, dtpDateIn.Value);
                for (int i = 0; i < dtgCLS_ChiDinhXN.RowCount; i++)
                {
                    if ((bool)dtgCLS_ChiDinhXN["Chon", i].Value)
                    {
                        if (info.CheckFunction(frmMDIParent._aPhanQuyen, "TN7") == false)
                        {
                            if (info.Check_HaveResult(_matiepnhan, dtgCLS_ChiDinhXN["MaXN", i].Value.ToString().Trim()))
                            {
                                MessageBox.Show("Chỉ định ' " + dtgCLS_ChiDinhXN["TenXN", i].Value.ToString().Trim() + " ' đã có KQ.\nBạn không thể xóa chỉ định này!");
                                dtgCLS_ChiDinhXN["Chon", i].Value = false;
                                _uncheck++;
                            }
                        }
                        _total++;
                    }
                }
                if (_total > _uncheck)
                {
                    if (MessageBox.Show("Xoá chỉ định được chọn ?", Warnings.CAPTION, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dtgCLS_ChiDinhXN.RowCount; i++)
                        {
                            if ((bool)dtgCLS_ChiDinhXN["Chon", i].Value)
                            {
                                info.Delete_XNCLS(_matiepnhan, dtgCLS_ChiDinhXN["MaXN", i].Value.ToString().Trim());
                            }
                        }
                        data.Get_CLS_KetQua(dtgCLS_ChiDinhXN, bvCLS_ChiDinhXN, " MaTiepNhan ='" + _matiepnhan + "'", ref dtCLS_ChiDinhXetNghiem);
                    }
                }
            }
        }

        private void chkAutoSave_Click(object sender, EventArgs e)
        {
            config.WriteReg("AutoSave", (chkAutoSave.Checked == true ? "True" : "False"));
        }

        private void cboBSChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, cboChanDoan);
        }

        private void cboChanDoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProcessServices.LeaveFocus(e, cboCLS_XetNghiem);
        }

        private void txtSex_TextChanged(object sender, EventArgs e)
        {
            if (txtSex.Text=="F")
            {
                lblSex.Text = "Nữ";
            }
            else if (txtSex.Text == "M")
            {
                lblSex.Text = "Nam";
            }
            else if (txtSex.Text == "?")
            {
                lblSex.Text = "Khác";
            }
        }

        private void cboChiDinhSieuAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InsertDichVuSieuAm();
            }
        }

        private void btnAddSieuAm_Click(object sender, EventArgs e)
        {
            InsertDichVuSieuAm();
        }

        private void cboChiDinhSieuAm_Enter(object sender, EventArgs e)
        {
            Load_DMMauSieuAm();
        }

        private void txtMSBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtMSBenhNhan.Text != "")
                {
                    string _check = "";
                    if (txtMSBenhNhan.Text.Length > 2)
                    {
                        _check = txtMSBenhNhan.Text.Substring(0, 2);
                        if (_check != "DT")
                        {
                            txtMSBenhNhan.Text = "DT" + txtMSBenhNhan.Text;
                        }
                    }
                    Get_InterInfo(txtMSBenhNhan.Text);
                }
                else
                {
                    txtTenBN.Focus();
                }
            }
        }

        private void txtMSBenhNhan_Leave(object sender, EventArgs e)
        {
            CheckSave();
        }
    }
}
