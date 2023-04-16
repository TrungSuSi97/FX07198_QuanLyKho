using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Model;
using TPH.LIS.TestResult.Services;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmChiDinhCLS : FrmTemplate
    {
        public FrmChiDinhCLS()
        {
            InitializeComponent();
        }
        bool _FromKhamBenh = false;

        public bool FromKhamBenh
        {
            get { return _FromKhamBenh; }
            set { _FromKhamBenh = value; }
        }

        DateTime dtDateIn = new DateTime();

        public DateTime DtDateIn
        {
            get { return dtDateIn; }
            set { dtDateIn = value; }
        }

        string _SoTT = "";

        public string SoTT
        {
            get { return _SoTT; }
            set { _SoTT = value; }
        }
        string _MaYeuCau_Current = "";
        string _MaTiepNhan_Current = "";
        string _MaKhoa_Current = "";
        string _Sex_Current = "";
        string _Age_Current = "";
        string _SeriviceID_Current = "";
        C_Patient pInfo = new C_Patient();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        ITestResultService _xetnghiem = new TestResultService();

        C_NhanVien nhanvien = new C_NhanVien();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        C_Patient_SieuAm p_sieuam = new C_Patient_SieuAm();
       
        C_Patient_XQuang p_xquang = new C_Patient_XQuang();
        C_Patient_NoiSoi p_NoiSoi = new C_Patient_NoiSoi();

        DataTable dtBenhNhan = new DataTable();
        DataTable dtCLS_ChiDinh_XN = new DataTable();
        DataTable dtCLS_ChiDinh_SieuAm = new DataTable();
        DataTable dtCLS_ChiDinh_XQuang = new DataTable();
        DataTable dtCLS_ChiDinh_NoiSoi = new DataTable();
        private void FrmChiDinhCLS_Load(object sender, EventArgs e)
        {
            Collect_ControlToBindData();
            Get_NhommXQuang();
            Get_NhomSieuAm();
            Get_NhomXN();
            Get_NhomNoiSoi();
            data.Get_ChanDoan(cboChanDoan);
            nhanvien.Get_NhanVien(cboBSChiDinh);
            sysConfig.Get_DoiTuongDichVu(cboService, txtServiceName);
            CheckEnable_Function();
            Load_BenhNhan();
            Load_ChiDinh_XetNghiem();
            Load_ChiDinh_XQuang();
            Load_ChiDinh_SieuAm();
            Load_ChiDinh_NoiSoi();
        }

        private void Load_BenhNhan()
        {
            Set_info(_MaTiepNhan_Current, _MaKhoa_Current, _SeriviceID_Current);
        }

        private void Load_ChiDinh_XetNghiem()
        {
            _xetnghiem.Get_DanhSachChiDinh(dtgChiDinhXN, bvChiDinhXN, " MaTiepNhan ='" + _MaTiepNhan_Current + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtCLS_ChiDinh_XN, false);
        }
        private void Load_ChiDinh_SieuAm()
        {
            p_sieuam.Get_DanhSachChiDinh(dtgChiDinhSA, bvChiDinhSA, " MaTiepNhan ='" + _MaTiepNhan_Current + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtCLS_ChiDinh_SieuAm, false);
        }
        private void Load_ChiDinh_NoiSoi()
        {
            p_NoiSoi.Get_DanhSachChiDinh(dtgChiDinh_NS, bvChiDinhNoiSoi, " MaTiepNhan ='" + _MaTiepNhan_Current + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtCLS_ChiDinh_NoiSoi, false);
        }
        private void Load_ChiDinh_XQuang()
        {
            p_xquang.Get_DanhSachChiDinh(dtgChiDinhXRay, bvChiDinhXRay, " MaTiepNhan ='" + _MaTiepNhan_Current + "'" + (chkHaveCost.Checked == true ? " and GiaRieng > 0" : ""), ref dtCLS_ChiDinh_XQuang, false);
        }

        public void Set_info(string _MaTiepNhan, string _MaKhoa, string _SeriviceID)
        {
            _MaTiepNhan_Current = _MaTiepNhan;
            _MaKhoa_Current = _MaKhoa;
            _SeriviceID_Current = _SeriviceID;
            cboService.SelectedValue = _SeriviceID_Current;

        }
        object[] objControl = new object[9];


        private void Collect_ControlToBindData()
        {
            txtChanDoan.Tag = "ChanDoan";
            cboBSChiDinh.Tag = "BacSiCD";
            objControl[8] = txtChanDoan;
            objControl[8] = cboBSChiDinh;
        }
        private void BindData(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            for (int i = 0; i < objControl.Length; i++)
            {
                LabServices_Helper.CheckAndSetBindData(objControl[i], bs);
            }
        }

        bool _NhapChiDinh = false, _XoaChiDinh = false;
        bool _InBienLai = false;
        private void CheckEnable_Function()
        {
            //TN: Nhập chỉ định -->TN3
            _NhapChiDinh = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, "TN3");
            //TN: Xóa chỉ định -->TN4
            _XoaChiDinh = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, "TN4");
            //TN: In biên lai --> TN9
            _InBienLai = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenTiepNhan, "TN9");
            //Quyền nhập chỉ định
            cboBSChiDinh.Enabled = _NhapChiDinh;
            txtBacSiCD.Enabled = _NhapChiDinh;
            cboChanDoan.Enabled = _NhapChiDinh;
            txtChanDoan.Enabled = _NhapChiDinh;
            gbChiDinh.Visible = _NhapChiDinh;
            //Quyền xóa chỉ định
            btnXoaChiDinh_XN.Enabled = btnXoaChiDinh_SieuAm.Enabled = btnXoaChiDinh_XQuang.Enabled = btnXoaChiDinhNoiSoi.Enabled = _XoaChiDinh;
        }
        private void Update_ChanDoanBSChiDinh()
        {
            pInfo.Update_Patient_ChanDoanBSChiDinh(_MaTiepNhan_Current, txtChanDoan.Text, (cboBSChiDinh.SelectedIndex == -1 ? "" : cboBSChiDinh.SelectedValue.ToString().Trim()));
        }

        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_BenhNhan();
            }
        }

        #region Combobox NhomCLS SelectionChangeCommitted
        private void cboNhomCLS_XN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_ChiDinh_XN();
        }
        private void cboNhomCLS_SieuAm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_ChiDinh_SieuAm();
        }
        private void cboNhomCLS_NoiSoi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_ChiDinh_NoiSoi();
        }
        private void cboNhomCLS_XQuang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_ChiDinh_XQuang();
        }

        #endregion

        private void Get_NhomXN()
        {
            sysConfig.GetSubclinical(cboNhomCLS_XN, "");
        }
        private void Get_NhomSieuAm()
        {
            sysConfig.Get_NhomCLS_SieuAm(cboNhomCLS_SieuAm, "");
        }
        private void Get_NhommXQuang()
        {
            sysConfig.Get_DM_XQuang_KyThuat(cboNhomCLS_XQuang);
        }
        private void Get_NhomNoiSoi()
        {
            sysConfig.Get_NhomCLS_NoiSoi(cboNhomNS, "");
        }
        private void Get_ChiDinh_XN()
        {
            string _Nhom = (cboNhomCLS_XN.SelectedIndex == -1 ? "" : cboNhomCLS_XN.SelectedValue.ToString().Trim());
            data.Load_ChiDinhCLS(cboChiDinhCLS_XN, "1", _Nhom, _Sex_Current, "");
        }
        private void Get_ChiDinh_SieuAm()
        {
            string _Nhom = (cboNhomCLS_SieuAm.SelectedIndex == -1 ? "" : cboNhomCLS_SieuAm.SelectedValue.ToString().Trim());

            data.Load_ChiDinhCLS(cboChiDinhCLS_SieuAm, "2", _Nhom, _Sex_Current,"");
        }
        private void Get_ChiDinh_NoiSoi()
        {
            string _Nhom = (cboNhomNS.SelectedIndex == -1 ? "" : cboNhomNS.SelectedValue.ToString().Trim());

            data.Load_ChiDinhCLS(cboChiDinhNS, "4", _Nhom, _Sex_Current, "");
        }
        private void Get_ChiDinh_XQuang()
        {
            string _Nhom = (cboNhomCLS_XQuang.SelectedIndex == -1 ? "" : cboNhomCLS_XQuang.SelectedValue.ToString().Trim());
            data.Load_ChiDinhCLS(cboChiDinhCLS_XQuang, "3", _Nhom, _Sex_Current, "");
        }

        private void InsertDichVuXN()
        {

            if (cboService.SelectedIndex != -1 && cboChiDinhCLS_XN.SelectedIndex != -1)
            {
                var objPatient = new BENHNHAN_TIEPNHAN();
                objPatient.Matiepnhan = _MaTiepNhan_Current;
                objPatient.Tuoi = int.Parse(_Age_Current == "" ? "0" : _Age_Current);
                objPatient.Gioitinh = _Sex_Current;
                objPatient.Doituongdichvu = cboService.SelectedValue.ToString().Trim();

                bool Profile = false;
                if (txtProfile.Text == "*")
                {
                    Profile = true;
                }

                var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
                objChiDinh.maxn = cboChiDinhCLS_XN.SelectedValue.ToString().Trim();
                objChiDinh.xetnghiemProfile = Profile;
                objChiDinh.Dongia = float.Parse(txtDonGiaXetNghiem.Text == "" ? "0" : txtDonGiaXetNghiem.Text); ;
                objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;

                _xetnghiem.InsertTest(objPatient, objChiDinh);

                Load_ChiDinh_XetNghiem();
                cboChiDinhCLS_XN.DroppedDown = true;
            }
        }
        private void InsertDichVuSieuAm()
        {
            if (cboService.SelectedIndex != -1 && cboChiDinhCLS_SieuAm.SelectedIndex != -1)
            {
                float dongia = float.Parse(txtDongiaSieuAm.Text == "" ? "0" : txtDongiaSieuAm.Text);
                p_sieuam.Insert_ChiDinhSieuAm(_MaTiepNhan_Current, cboChiDinhCLS_SieuAm.SelectedValue.ToString().Trim(), cboService.SelectedValue.ToString().Trim(), dongia);

                Load_ChiDinh_SieuAm();
                cboChiDinhCLS_SieuAm.DroppedDown = true;
            }
        }
        private void InsertDichVuNoiSoi()
        {
            if (cboService.SelectedIndex != -1 && cboChiDinhNS.SelectedIndex != -1)
            {
                float dongia = float.Parse(txtDonGiaNoiSoi.Text == "" ? "0" : txtDonGiaNoiSoi.Text);
                p_NoiSoi.Insert_ChiDinhNoiSoi(_MaTiepNhan_Current, cboChiDinhNS.SelectedValue.ToString().Trim(), cboService.SelectedValue.ToString().Trim(), dongia);
                // Load_DS_ChiDinh();
                Load_ChiDinh_NoiSoi();
                cboChiDinhNS.DroppedDown = true;
               
            }
        }
        private void InsertDicVuXQuang()
        {
            if (cboService.SelectedIndex != -1 && cboChiDinhCLS_XQuang.SelectedIndex != -1)
            {
                float dongia = float.Parse(txtDOnGiaXQuang.Text == "" ? "0" : txtDOnGiaXQuang.Text);
                p_xquang.Insert_ChiDinhXQuang(_MaTiepNhan_Current, cboChiDinhCLS_XQuang.SelectedValue.ToString().Trim(), cboService.SelectedValue.ToString().Trim(), dongia);
               // Load_DS_ChiDinh();
                Load_ChiDinh_XQuang();
                cboChiDinhCLS_XQuang.DroppedDown = true;
            }
        }
        private void btnNhapChiDinh_XN_Click(object sender, EventArgs e)
        {
            if (cboChiDinhCLS_XN.SelectedIndex != -1)
            {
                InsertDichVuXN();
                Load_ChiDinh_XetNghiem();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn chỉ định xét nghiệm");
                cboChiDinhCLS_XN.Focus();
                cboChiDinhCLS_XN.DroppedDown = true;
            }
        }
        private void btnNhapChiDinh_SieuAm_Click(object sender, EventArgs e)
        {
            if (cboChiDinhCLS_SieuAm.SelectedIndex != -1)
            {
                InsertDichVuSieuAm();
                Load_ChiDinh_SieuAm();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn chỉ định siêu âm");
                cboChiDinhCLS_SieuAm.Focus();
                cboChiDinhCLS_SieuAm.DroppedDown = true;
            }
        }

        private void btnNhapChiDinh_XQuang_Click(object sender, EventArgs e)
        {
            if (cboChiDinhCLS_XQuang.SelectedIndex != -1)
            {
                InsertDicVuXQuang();
                Load_ChiDinh_XQuang();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn chỉ định X-Quang");
                cboChiDinhCLS_XQuang.Focus();
                cboChiDinhCLS_XQuang.DroppedDown = true;
            }
        }

        private void cboNhomCLS_XN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboNhomCLS_XN_SelectionChangeCommitted(sender, e);
                ControlExtension.LeaveFocusNext(e, cboChiDinhCLS_XN);
            }
        }
        private void cboNhomCLS_SieuAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboNhomCLS_SieuAm_SelectionChangeCommitted(sender, e);
                ControlExtension.LeaveFocusNext(e, cboChiDinhCLS_SieuAm);
            }
        }

        private void cboNhomCLS_XQuang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboNhomCLS_XQuang_SelectionChangeCommitted(sender, e);
                ControlExtension.LeaveFocusNext(e, cboChiDinhCLS_XQuang);
            }
        }

        private void cboChiDinhCLS_XN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnNhapChiDinh_XN_Click(sender, e);
                e.Handled = true;
            }
        }
        private void cboChiDinhCLS_SieuAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnNhapChiDinh_SieuAm_Click(sender, e);
                e.Handled = true;
            }
        }
        private void cboChiDinhCLS_XQuang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnNhapChiDinh_XQuang_Click(sender, e);
                e.Handled = true;
            }
        }
        private void cboChanDoan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Update_ChanDoanBSChiDinh();
        }

        private void cboChanDoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Update_ChanDoanBSChiDinh();
                cboBSChiDinh.Focus();
                e.Handled = true;
            }
        }

        private void cboBSChiDinh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Update_ChanDoanBSChiDinh();
        }

        private void cboBSChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Update_ChanDoanBSChiDinh();
                //cboDichVuCLS.Focus();
                e.Handled = true;
            }
        }
        private void btnXoaChiDinh_XN_Click(object sender, EventArgs e)
        {
            txtBacSiCD.Focus();
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chỉ định Xét Nghiệm được chọn ?"))
            {
                string _MaTiepNhan = _MaTiepNhan_Current;
                for (int i = 0; i < dtgChiDinhXN.RowCount; i++)
                {
                    if (dtgChiDinhXN["xnChon", i].Value != null)
                    {
                        if ((bool)dtgChiDinhXN["xnChon", i].Value)
                        {
                            if ((bool)dtgChiDinhXN[XNChinh.Name, i].Value)
                            {
                                if (_xetnghiem.Check_HaveResult_For_XNChinh(_MaTiepNhan, dtgChiDinhXN[ProfileID.Name, i].Value.ToString()))
                                {
                                    if(CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Xét nghiệm:\"" + dtgChiDinhXN[XnChiDinh.Name, i].Value.ToString() + "\" đã có kết quả!\nBạn chắc chắn muốn xóa?"))
                                    {
                                        _xetnghiem.Delete_ChiDinhCLS_XN(_MaTiepNhan, dtgChiDinhXN[xnMaChiDinh.Name, i].Value.ToString().Trim(), "", CommonAppVarsAndFunctions.UserID);
                                    }
                                }
                                else
                                {
                                    _xetnghiem.Delete_ChiDinhCLS_XN(_MaTiepNhan, dtgChiDinhXN[xnMaChiDinh.Name, i].Value.ToString().Trim()
                                        , dtgChiDinhXN[ProfileID.Name, i].Value.ToString(), CommonAppVarsAndFunctions.UserID);
                                }
                            }
                            else
                            {
                                if (_xetnghiem.Check_HaveResult_XN(_MaTiepNhan_Current, dtgChiDinhXN[xnMaChiDinh.Name, i].Value.ToString()))
                                {
                                    CustomMessageBox.MSG_Information_OK("Xét nghiệm:\"" + dtgChiDinhXN[XnChiDinh.Name, i].Value.ToString() + "\" đã có kết quả!\nKhông thể xóa.");
                                }
                                else
                                {
                                    _xetnghiem.Delete_ChiDinhCLS_XN(_MaTiepNhan, dtgChiDinhXN[xnMaChiDinh.Name, i].Value.ToString().Trim(),"", CommonAppVarsAndFunctions.UserID);
                                }
                            }
                        }
                    }
                }
                Load_ChiDinh_XetNghiem();
            }
        }

        private void btnXoaChiDinh_SieuAm_Click(object sender, EventArgs e)
        {
            txtBacSiCD.Focus();
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chỉ định Siêu Âm được chọn ?"))
            {
                string _MaTiepNhan = _MaTiepNhan_Current;
                for (int i = 0; i < dtgChiDinhSA.RowCount; i++)
                {
                    if (dtgChiDinhSA[saChon.Name, i].Value != null)
                    {
                        if ((bool)dtgChiDinhSA[saChon.Name, i].Value)
                        {
                            p_sieuam.Delete_ChiDinhCLS_SieuAm(_MaTiepNhan, dtgChiDinhSA["saMaChiDinh", i].Value.ToString().Trim());
                        }
                    }
                }
                Load_ChiDinh_SieuAm();
            }
        }

        private void btnXoaChiDinh_XQuang_Click(object sender, EventArgs e)
        {
            txtBacSiCD.Focus();
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chỉ định X-Quang được chọn ?"))
            {
                string _MaTiepNhan = _MaTiepNhan_Current;
                for (int i = 0; i < dtgChiDinhXRay.RowCount; i++)
                {
                    if (dtgChiDinhXRay[xChon.Name, i].Value != null)
                    {
                        if ((bool)dtgChiDinhXRay[xChon.Name, i].Value)
                        {
                            p_xquang.Delete_ChiDinhCLS_XQuang(_MaTiepNhan, dtgChiDinhXRay[xMaChiDinh.Name, i].Value.ToString().Trim());
                        }
                    }
                }
                Load_ChiDinh_XQuang();
            }
        }

        private void chkHaveCost_Click(object sender, EventArgs e)
        {
            Set_info(_MaTiepNhan_Current, _MaKhoa_Current, _SeriviceID_Current);
        }

        private void cboChiDinhCLS_SieuAm_Enter(object sender, EventArgs e)
        {
            if (cboChiDinhCLS_SieuAm.Items.Count == 0)
            {
                Get_ChiDinh_SieuAm();
            }
        }

        private void cboChiDinhCLS_XN_Enter(object sender, EventArgs e)
        {
            if (cboChiDinhCLS_XN.Items.Count == 0)
            {
                Get_ChiDinh_XN();
            }
        }

        private void cboChiDinhCLS_XQuang_Enter(object sender, EventArgs e)
        {
            if (cboChiDinhCLS_XQuang.Items.Count == 0)
            {
                Get_ChiDinh_XQuang();
            }
        }

        private void dtgChiDinhXN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((dtgChiDinhXN[XNChinh.Name, e.RowIndex].Value.ToString() == "" ? false : (bool)dtgChiDinhXN[XNChinh.Name, e.RowIndex].Value))
                {
                    bool IsCheck = ((dtgChiDinhXN[xnChon.Name, e.RowIndex].Value.ToString() == "" ? false : (bool)dtgChiDinhXN[xnChon.Name, e.RowIndex].Value));
                    string _ProfileID = dtgChiDinhXN[ProfileID.Name, e.RowIndex].Value.ToString();
                    for (int i = 0; i < dtgChiDinhXN.RowCount; i++)
                    {
                        if (dtgChiDinhXN[ProfileID.Name, i].Value.ToString().Equals(_ProfileID))
                        {
                            dtgChiDinhXN[xnChon.Name, i].Value = IsCheck;
                        }
                    }
                    Load_ChiDinh_NoiSoi();
                }
            
        }

        private void btnXoaCDNoiSOi_Click(object sender, EventArgs e)
        {
            txtBacSiCD.Focus();
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chỉ định nội soi được chọn ?"))
            {
                string _MaTiepNhan = _MaTiepNhan_Current;
                for (int i = 0; i < dtgChiDinh_NS.RowCount; i++)
                {
                    if (dtgChiDinh_NS[nsChon.Name, i].Value != null)
                    {
                        if ((bool)dtgChiDinh_NS[nsChon.Name, i].Value)
                        {
                            p_NoiSoi.Delete_ChiDinhCLS_NoiSoi(_MaTiepNhan, dtgChiDinh_NS[nsMaChiDinh.Name, i].Value.ToString().Trim());
                        }
                    }
                }
                Load_ChiDinh_NoiSoi();
            }
        }

        private void cboNhomNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboNhomCLS_NoiSoi_SelectionChangeCommitted(sender, e);
                ControlExtension.LeaveFocusNext(e, cboChiDinhNS);
            }
        }

        private void btnNhapCDNS_Click(object sender, EventArgs e)
        {
            if (cboChiDinhNS.SelectedIndex != -1)
            {
                InsertDichVuNoiSoi();
            }
        }

        private void cboChiDinhNS_Enter(object sender, EventArgs e)
        {
            if (cboChiDinhNS.Items.Count == 0)
            {
                Get_ChiDinh_NoiSoi();
            }
        }

        private void cboChiDinhNS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                InsertDichVuNoiSoi();
                e.Handled = true;
            }
        }
    }
}
