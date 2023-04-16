using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.CauHinh.DanhMucKhamBenh
{
    public partial class FrmDanhMucThuoc : FrmTemplate
    {
        public FrmDanhMucThuoc()
        {
            InitializeComponent();
        }

        DM_THUOC_DAL thuocDAL = new DM_THUOC_DAL();

        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        SqlDataAdapter daGocThuoc = new SqlDataAdapter();
        DataTable dtGocThuoc = new DataTable();
        SqlDataAdapter daNhomThuoc = new SqlDataAdapter();
        DataTable dtNhomThuoc = new DataTable();
        SqlDataAdapter daThuoc = new SqlDataAdapter();
        DataTable dtThuoc = new DataTable();
        SqlDataAdapter daProfile = new SqlDataAdapter();
        DataTable dtProfile = new DataTable();
        private void FrmDanhMucThuoc_Load(object sender, EventArgs e)
        {
            Load_CachDung();
            Load_DonViTinh();

            Load_NhomThuoc();
            Load_GocThuoc_Thuoc("");
            Load_Profile();
            tabControl1.TabPages.Remove(tabPage3);
        }

        private void Load_CachDung()
        {
            sysConfig.Get_DM_Thuoc_CachDung(cboCachDung, "");
            sysConfig.Get_DM_Thuoc_CachDung(CachDung, "");
            sysConfig.Get_DM_Thuoc_CachDung(PCachDung, "");
        }
        private void Load_DonViTinh()
        {
            C_VatTu_Config vattu = new C_VatTu_Config();
            vattu.Get_DM_DonViTinh(cboDonVi);
        }
        private void Load_GocThuoc(string _MaNhomThuoc)
        {
            sysConfig.Get_DM_Thuoc_GocThuoc(daGocThuoc, dtgDMGocThuoc, bvDMGocThuoc, (_MaNhomThuoc == "" ? "" : " and MaNhomThuoc ='" + _MaNhomThuoc + "'"), ref dtGocThuoc);
            Load_GocThuoc_Profile();
            Load_GocThuoc_Thuoc("");
        }

        private void Load_NhomThuoc()
        {
            sysConfig.Get_DM_Thuoc_NhomThuoc(daNhomThuoc, dtgDMNhomThuoc,bvDMNhomThuoc ,"", ref dtNhomThuoc);
            sysConfig.Get_DM_Thuoc_NhomThuoc(cboNhomThuoc);
            sysConfig.Get_DM_Thuoc_NhomThuoc(cboPNhomThuoc);
            
        }
        private void Load_GocThuoc_Thuoc(string _MaNhomThuoc)
        {
            DataTable dtThuoc_GocThuoc = new DataTable();
            sysConfig.Get_DM_Thuoc_GocThuoc(dtgGoc_Thuoc, bvNhom_Thuoc, (_MaNhomThuoc == "" ? "" : " and MaNhomThuoc ='" + _MaNhomThuoc + "'"), ref dtThuoc_GocThuoc);
        }
        private void Load_GocThuoc_Profile()
        {
            string _MaNhomThuoc = (cboPNhomThuoc.SelectedIndex == -1 ? "" : cboPNhomThuoc.SelectedValue.ToString().Trim());
            sysConfig.Get_DM_Thuoc_GocThuoc(cboPGocThuoc, (_MaNhomThuoc == "" ? "" : " and MaNhomThuoc ='" + _MaNhomThuoc + "'"));
        }
        private void Load_Thuoc()
        {
            if (dtgGoc_Thuoc.CurrentRow.Index != -1)
            {
                string _MaGocThuoc = dtgGoc_Thuoc.CurrentRow.Cells[Thuoc_MaGoc.Name].Value.ToString().Trim();
                dtThuoc = thuocDAL.Data_DM_Thuoc("", _MaGocThuoc);
                ControlExtension.BindDataToGrid(dtThuoc, ref dtgDMThuoc, ref bvDMThuoc);
                Clear_Control();
                BindData_Thuoc(bvDMThuoc.BindingSource);
                Set_ReadOnly_Thuoc(true, false);
                Load_Thuoc_Profile();
            }
        }
        private void Load_Thuoc_Profile()
        {
            string _MaGoc = (cboPGocThuoc.SelectedIndex == -1 ? "" : cboPGocThuoc.SelectedValue.ToString().Trim());
           sysConfig.Get_DM_Thuoc(cboPThuoc, _MaGoc);
        }

        private void Load_Profile()
        {
           sysConfig.Get_DM_THUOC_PROFILE(daProfile, dtgProfile, bvProfile, "", ref dtProfile);
        }
        private void Load_Profile_Thuoc()
        {
            string _MaProfile = "";
            DataTable dtProfileThuoc = new DataTable();
            if (dtgProfile.RowCount > 0)
            {
                _MaProfile = dtgProfile.CurrentRow.Cells["MaProfile"].Value.ToString().Trim();
            }
            else
            {
                _MaProfile = "";
            }
           sysConfig.Get_DM_THUOC_PROFILE_CHITIET(dtgProfileThuoc, bvProfileThuoc," and MaProfile ='" + _MaProfile + "'", ref dtProfileThuoc);
        }
        private void Set_ReadOnly_Thuoc(bool _ReadOnly, bool _Add)
        {
            if (_Add)
            {
                txtMaThuoc.ReadOnly = false;
                txtMaThuoc.BackColor = Color.Yellow;
                btnHuy.Enabled = true;
            }
            else
            {
                txtMaThuoc.ReadOnly = true;
                txtMaThuoc.BackColor = Color.LightBlue;
                btnHuy.Enabled = !_ReadOnly;
            }
            txtTenThuoc.ReadOnly = _ReadOnly;
            txtSang.ReadOnly = _ReadOnly;
            txtTrua.ReadOnly = _ReadOnly;
            txtChieu.ReadOnly = _ReadOnly;
            txtToi.ReadOnly = _ReadOnly;
            txtSapXep.ReadOnly = _ReadOnly;
            txtGoTat.ReadOnly = _ReadOnly;
            txtGia.ReadOnly = _ReadOnly;
            cboCachDung.Enabled = !_ReadOnly;
            cboDonVi.Enabled = !_ReadOnly;
            cboDonViTinhChiTiet.Enabled = !_ReadOnly;
            cboDonViTinhQuiCach.Enabled = !_ReadOnly;
            chkCoHanSuDung.Enabled = !_ReadOnly;
            chkXuatTheoQuiCachDongGoi.Enabled = !_ReadOnly;
            txtSLQuiCach.ReadOnly = _ReadOnly;
            txtSLChiTietQuiCach.ReadOnly = _ReadOnly;

        }

        private void BindData_Thuoc(BindingSource bs)
        {
            txtMaThuoc.DataBindings.Add("Text", bs, "MaThuoc");
            txtGoTat.DataBindings.Add("Text", bs, "GoTat");
            txtTenThuoc.DataBindings.Add("Text", bs, "TenThuoc");
            txtSang.DataBindings.Add("Text", bs, "Sang");
            txtTrua.DataBindings.Add("Text", bs, "Trua");
            txtChieu.DataBindings.Add("Text", bs, "Chieu");
            txtToi.DataBindings.Add("Text", bs, "Toi");
            txtSapXep.DataBindings.Add("Text", bs, "SapXep");
            txtGia.DataBindings.Add("Text", bs, "Gia");
            cboCachDung.DataBindings.Add("SelectedValue", bs, "CachDung");
            cboDonVi.DataBindings.Add("SelectedValue", bs, "DonViTinh");
            cboDonViTinhQuiCach.DataBindings.Add("SelectedValue", bs, "DVTQuiCachCap1");
            cboDonViTinhChiTiet.DataBindings.Add("SelectedValue", bs, "DVTQuiCachCap2");
            txtSLChiTietQuiCach.DataBindings.Add("Text", bs, "SLQuiCachCap2");
            txtSLQuiCach.DataBindings.Add("Text", bs, "SLQuiCachCap1");

            chkXuatTheoQuiCachDongGoi.DataBindings.Add("Checked", bs, "XuatTheoQCDG");
            chkCoHanSuDung.DataBindings.Add("Checked", bs, "CoHSD");
        }

        private void Clear_Control()
        {
            txtGoTat.DataBindings.Clear();
            txtGoTat.Text = "";
            txtMaThuoc.DataBindings.Clear();
            txtMaThuoc.Text = "";
            txtTenThuoc.DataBindings.Clear();
            txtTenThuoc.Text = "";
            txtSang.DataBindings.Clear();
            txtSang.Text = "";
            txtTrua.DataBindings.Clear();
            txtTrua.Text = "";
            txtChieu.DataBindings.Clear();
            txtChieu.Text = "";
            txtToi.DataBindings.Clear();
            txtToi.Text = "";
            txtSapXep.DataBindings.Clear();
            txtSapXep.Text = "1";
            txtGia.DataBindings.Clear();
            txtGia.Text = "0";

            txtSLChiTietQuiCach.DataBindings.Clear();
            txtSLChiTietQuiCach.Text = "";
            txtSLQuiCach.DataBindings.Clear();
            txtSLQuiCach.Text = "";

            chkCoHanSuDung.DataBindings.Clear();
            chkCoHanSuDung.Checked = false;

            chkXuatTheoQuiCachDongGoi.DataBindings.Clear();
            chkXuatTheoQuiCachDongGoi.Checked = false;

            cboCachDung.DataBindings.Clear();
            cboCachDung.SelectedIndex = -1;
            cboDonVi.DataBindings.Clear();
            cboDonVi.SelectedIndex = -1;

            cboDonViTinhQuiCach.DataBindings.Clear();
            cboDonViTinhQuiCach.SelectedIndex = -1;

            cboDonViTinhChiTiet.DataBindings.Clear();
            cboDonViTinhChiTiet.SelectedIndex = -1;

        }

        private void dtgDMNhomThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daNhomThuoc, ref dtNhomThuoc, dtgDMNhomThuoc, "", "");
        }

        private void btnThemGocThuoc_Click(object sender, EventArgs e)
        {
            if (txtMaGocThuoc.Text != "")
            {
               sysConfig.Insert_GocThuoc(txtMaGocThuoc.Text, txtTenGocThuoc.Text, txtGoc_MaNhomThuoc.Text, txtThuTuInGoc.Text);
                Load_GocThuoc(txtGoc_MaNhomThuoc.Text.Trim());
                txtMaGocThuoc.Text = "";
                txtTenGocThuoc.Text = "";
                txtThuTuInGoc.Text = "0";
                txtMaGocThuoc.Focus();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã gốc thuốc");
            }
        }

        private void btnRefreshNhomThuoc_Click(object sender, EventArgs e)
        {
            Load_NhomThuoc();
        }
        private void btnRefreshDM_GocThuoc_Click(object sender, EventArgs e)
        {
            Load_GocThuoc(txtGoc_MaNhomThuoc.Text.Trim());
        }
        private void btnDeleteGocThuoc_Click(object sender, EventArgs e)
        {
            if (dtgDMGocThuoc.RowCount > 0)
            {
                string _MaGocThuoc = dtgDMGocThuoc.CurrentRow.Cells[MaGocThuoc.Name].Value.ToString().Trim();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa gốc thuốc \"" + _MaGocThuoc.ToUpper() + "\" đang chọn?"))
                {
                    if (LabServices_Helper.Check_NotExits("select top 1 MaGocThuoc from DM_Thuoc where MaGocThuoc = '" + _MaGocThuoc + "'") == false)
                    {
                        CustomMessageBox.MSG_Waring_OK("Gốc thuốc đang sử dụng, không thể xóa!");
                    }
                    else
                    {
                        dtgDMGocThuoc.Rows.RemoveAt(dtgDMGocThuoc.CurrentRow.Index);
                    }
                }
            }
        }

        private void dtgDMNhomThuoc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string _MaNhomThuoc = dtgDMNhomThuoc.CurrentRow.Cells[MaNhomThuoc.Name].Value.ToString().Trim();
                Load_GocThuoc(_MaNhomThuoc);
                txtGoc_MaNhomThuoc.Text = _MaNhomThuoc;
            }
        }

        private void btnThemNhomThuoc_Click(object sender, EventArgs e)
        {
            if (txtMaNhomThuoc.Text != "")
            {
               sysConfig.Insert_NhomThuoc(txtMaNhomThuoc.Text, txtTenNhomThuoc.Text);
                Load_NhomThuoc();
                txtMaNhomThuoc.Text = "";
                txtTenNhomThuoc.Text = "";
                txtMaNhomThuoc.Focus();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã nhóm thuốc");
            }
        }

        private void txtThuTuInNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, txtTenGocThuoc);
        }

        private void txtMaGocThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtThuTuInGoc);
        }

        private void txtMaNhomThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenNhomThuoc);
        }

        private void txtTenNhomThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemNhomThuoc);
        }

        private void txtTenGocThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemGocThuoc);
        }

        private void cboGocThuoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboNhomThuoc.SelectedIndex != -1)
            {
                Load_GocThuoc_Thuoc(cboNhomThuoc.SelectedValue.ToString());
            }
            else
            {
                Load_GocThuoc_Thuoc("");
            }
        }

        private void cboGocThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboNhomThuoc.SelectedIndex != -1)
                {
                    Load_GocThuoc_Thuoc(cboNhomThuoc.SelectedValue.ToString());
                }
                else
                {
                    Load_GocThuoc_Thuoc("");
                }
            }
        }

        private void btnCachDung_Click(object sender, EventArgs e)
        {
            FrmCachDungThuoc frm = new FrmCachDungThuoc();
            frm.ShowDialog();
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (dtgGoc_Thuoc.CurrentRow.Index != -1)
            {
                Clear_Control();
                Set_ReadOnly_Thuoc(false, true);
                btnHuy.Enabled = true;
                txtMaThuoc.Focus();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Insert_Update_Thuoc();
        }

        private void Insert_Update_Thuoc()
        {  if (dtgGoc_Thuoc.CurrentRow.Index != -1)
            {
            bool _isUpdate = (txtMaThuoc.BackColor == Color.LightBlue);
            DM_THUOC thuoc = new DM_THUOC();
                thuoc.Magocthuoc = dtgGoc_Thuoc.CurrentRow.Cells[Thuoc_MaGoc.Name].Value.ToString().Trim();

                thuoc.Cachdung = cboCachDung.SelectedValue.ToString();

                if (txtMaThuoc.Text == "")
                {
                    CustomMessageBox.MSG_Information_OK("Vui lòng nhập mã thuốc !");
                    txtMaThuoc.Focus();
                    return;
                }
                else if (cboDonVi.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn đơn vị tính !");
                    cboDonVi.Focus();
                    return;
                }
                else if (cboCachDung.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn đơn cách dùng !");
                    cboCachDung.Focus();
                    return;
                }
                else
                {
                    if (_isUpdate)
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetNo("Cập nhật thông tin vừa sửa?"))
                        {
                            return;
                        }
                        else
                        {
                            btnHuy.Enabled = false;
                        }
                    }

                    thuoc.Cachdung = cboCachDung.SelectedValue.ToString();
                    thuoc.Chieu = txtChieu.Text;
                    thuoc.Cohsd = chkCoHanSuDung.Checked;
                    thuoc.Donvitinh = cboDonVi.SelectedValue.ToString();
                    thuoc.Dvtquicachcap1 = (cboDonViTinhQuiCach.SelectedIndex == -1 ? "" : cboDonViTinhQuiCach.SelectedValue.ToString());
                    thuoc.Dvtquicachcap2 = (cboDonViTinhChiTiet.SelectedIndex == -1 ? "" : cboDonViTinhChiTiet.SelectedValue.ToString());
                    thuoc.Gia = decimal.Parse(txtGia.Text == "" ? "0" : txtGia.Text);
                    thuoc.Gotat = txtGoTat.Text;
                    thuoc.Mathuoc = txtMaThuoc.Text;
                    thuoc.Mavattu = "";
                    thuoc.Sang = txtSang.Text;
                    thuoc.Sapxep = int.Parse(txtSapXep.Text == "" ? "0" : txtSapXep.Text);
                    thuoc.Slquicachcap1 = int.Parse(txtSLQuiCach.Text == "" ? "0" : txtSLQuiCach.Text);
                    thuoc.Slquicachcap2 = int.Parse(txtSLChiTietQuiCach.Text == "" ? "0" : txtSLChiTietQuiCach.Text);
                    thuoc.Tenthuoc = txtTenThuoc.Text;
                    thuoc.Toi = txtToi.Text;
                    thuoc.Trua = txtTrua.Text;
                    thuoc.Xuattheoqcdg = chkXuatTheoQuiCachDongGoi.Checked;
                    

                    if (thuocDAL.Insert_Update_DM_THUOC(thuoc, _isUpdate) > -1)
                    {
                        Load_Thuoc();

                        if (_isUpdate == false)
                        {
                            //  CustomMessageBox.MSG_Information_OK("Thêm mới hoàn thành !");
                            Set_ReadOnly_Thuoc(false, true);
                            Clear_Control();
                            txtMaThuoc.Focus();
                            btnHuy.Enabled = true;
                        }
                    }
                    else
                    {
                        if (_isUpdate == false)
                        {
                            CustomMessageBox.MSG_Information_OK("Thêm mới không hoàn thành !");
                            txtMaThuoc.Focus();
                            txtMaThuoc.SelectAll();
                        }
                        else
                        {
                            CustomMessageBox.MSG_Information_OK("Cập nhật không hoàn thành !");
                        }
                    }

                }
            }

 
        }
        private void txtSapXep_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Set_ReadOnly_Thuoc(false, false);
            btnHuy.Enabled = true;
        }

        private void dtgNhom_Thuoc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_Thuoc();
        }

        private void btnLamMoiThuoc_Click(object sender, EventArgs e)
        {
            Load_Thuoc();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (txtMaThuoc.BackColor == Color.Yellow)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy thêm mới ?"))
                {
                    Load_Thuoc();
                }
            }
            else
            {
                Load_Thuoc();
            }
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            if (dtgDMThuoc.RowCount > 0)
            {
                string _MaThuoc = dtgDMThuoc.CurrentRow.Cells[MaThuoc.Name].Value.ToString().Trim();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa thuốc \"" + _MaThuoc + "\" ?"))
                {
                   sysConfig.Delete_Thuoc(_MaThuoc);
                    Load_Thuoc();
                }
            }
        }

        private void txtMaThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtGoTat);
        }

        private void txtGoTat_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboDonVi);
        }

        private void cboDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboCachDung);
        }

        private void cboCachDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtTenThuoc);
        }

        private void txtTenThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtSang);
        }

        private void txtSang_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            LabServices_Helper.LeaveFocusNext(e, txtTrua);
        }

        private void txtTrua_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            LabServices_Helper.LeaveFocusNext(e, txtChieu);
        }

        private void txtChieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            LabServices_Helper.LeaveFocusNext(e, txtToi);
        }

        private void txtToi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            LabServices_Helper.LeaveFocusNext(e, txtSapXep);
        }

        private void cboPGocThuoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_Thuoc_Profile();
           
        }

        private void cboPNhomThuoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_GocThuoc_Profile();
           
        }

        private void btnThemProfile_Click(object sender, EventArgs e)
        {
            if (txtMaProfile.Text != "")
            {
               sysConfig.Insert_DM_Thuoc_Profile(txtMaProfile.Text, txtTenProfile.Text);
                Load_Profile();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã profile");
                txtMaProfile.Focus();
            }

        }

        private void dtgProfile_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_Profile_Thuoc();
        }

        private void btnLamMoiProfile_Click(object sender, EventArgs e)
        {
            Load_Profile();
        }

        private void btnLamMoiProfileThuoc_Click(object sender, EventArgs e)
        {
            Load_Profile_Thuoc();
        }

        private void btnThemThuocProfile_Click(object sender, EventArgs e)
        {
            if (cboPThuoc.SelectedIndex != -1 && dtgProfile.RowCount > 0)
            {
                string _MaThuoc = cboPThuoc.SelectedValue.ToString().Trim();
                string _MaProfile = dtgProfile.CurrentRow.Cells["MaProfile"].Value.ToString().Trim();
               sysConfig.Insert_DM_Thuoc_Profile_ChiTiet(_MaProfile, _MaThuoc);
                Load_Profile_Thuoc();
                
            }
        }

        private void cboPThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnThemThuocProfile_Click(sender, e);
            }
        }

        private void btnDelProfile_Click(object sender, EventArgs e)
        {
            if (dtgProfile.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa profile đang chọn ?"))
                {
                    string _MaProfile = dtgProfile.CurrentRow.Cells["MaProfile"].Value.ToString().Trim();
                   sysConfig.Delete_DM_THUOC_PROFILE(_MaProfile);
                    Load_Profile();
                }
            }
        }

        private void btnDelNhomThuoc_Click(object sender, EventArgs e)
        {
            if (dtgDMNhomThuoc.RowCount > 0)
            {
                string _MaNhomThuoc = dtgDMNhomThuoc.CurrentRow.Cells[MaNhomThuoc.Name].Value.ToString().Trim();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa nhóm thuốc \"" + _MaNhomThuoc.ToUpper() + "\" đang chọn?"))
                {
                    if (LabServices_Helper.Check_NotExits("select MaNhomThuoc from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where MaNhomThuoc = '" + _MaNhomThuoc + "'") == false)
                    {
                        CustomMessageBox.MSG_Information_OK("Gốc thuốc đang sử dụng, không thể xóa!");
                    }
                    else
                    {
                        dtgDMNhomThuoc.Rows.RemoveAt(dtgDMNhomThuoc.CurrentRow.Index);
                    }
                }
            }
        }

        private void btnDelProfileThuoc_Click(object sender, EventArgs e)
        {
            if (dtgProfileThuoc.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa profile đang chọn ?"))
                {
                    string _MaProfile = dtgProfileThuoc.CurrentRow.Cells["PMaProfile"].Value.ToString().Trim();
                    string _MaThuoc = dtgProfileThuoc.CurrentRow.Cells["PMaThuoc"].Value.ToString().Trim();
                   sysConfig.Delete_DM_THUOC_PROFILE_CHITIET(_MaProfile, _MaThuoc);
                    Load_Profile_Thuoc();
                }
            }
        }

        private void dtgGocThuoc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daGocThuoc, ref dtGocThuoc, dtgDMGocThuoc, "", "");
        }

        private void dtgProfile_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daProfile, ref dtProfile, dtgProfile, "", "");
        }

        private void btnLamMoiNhom_Thuoc_Click(object sender, EventArgs e)
        {
            if (cboNhomThuoc.SelectedIndex != -1)
            {
                Load_GocThuoc_Thuoc(cboNhomThuoc.SelectedValue.ToString());
            }
            else
            {
                Load_GocThuoc_Thuoc("");
            }
        }

        private void cboPNhomThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_GocThuoc_Profile();
                cboPGocThuoc.Focus();
            }
        }

        private void cboPGocThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_Thuoc_Profile();
                cboPThuoc.Focus();
            }
        }

        private void dtgProfileThuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgProfileThuoc.RowCount > 0)
            {
                string _MaProfile = dtgProfileThuoc[PMaProfile.Name, e.RowIndex].Value.ToString().Trim();
                string _MaThuoc = dtgProfileThuoc[PMaThuoc.Name, e.RowIndex].Value.ToString().Trim();
                string _CachDung = dtgProfileThuoc[PCachDung.Name, e.RowIndex].Value.ToString().Trim();
                string _Sang = dtgProfileThuoc[pSang.Name, e.RowIndex].Value.ToString().Trim();
                string _Trua = dtgProfileThuoc[PTrua.Name, e.RowIndex].Value.ToString().Trim();
                string _Chieu = dtgProfileThuoc[PChieu.Name, e.RowIndex].Value.ToString().Trim();
                string _Toi = dtgProfileThuoc[PToi.Name, e.RowIndex].Value.ToString().Trim();
               sysConfig.Update_DM_THUOC_PROFILE_CHITIET(_MaProfile, _MaThuoc, _CachDung, _Sang, _Trua, _Chieu, _Toi);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }


    }
}
