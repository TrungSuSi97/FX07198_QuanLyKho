using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmDM_DoiTuongDichVu_Gia : FrmTemplate
    {
        public frmDM_DoiTuongDichVu_Gia()
        {
            InitializeComponent();
        }
        DM_THUOC_DAL thuocDAL = new DM_THUOC_DAL();
        
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        SqlDataAdapter daService = new SqlDataAdapter();
        DataTable dtDichVu = new DataTable();
        DataTable dtDichVu_XN = new DataTable();
        DataTable dtDichVu_XN_ChiTiet = new DataTable();
        DataTable dtDichVu_SA = new DataTable(); 
        DataTable dtDichVu_SA_ChiTiet = new DataTable();
        DataTable dtDichVu_XQuang = new DataTable();
        DataTable dtDichVu_XQuang_ChiTiet = new DataTable();
        DataTable dtDichVu_NoiSoi = new DataTable();
        DataTable dtDichVu_KhamBenh = new DataTable();
        DataTable dtDichVu_KhamBenh_ChiTiet = new DataTable();
        DataTable dtDichVu_Khac = new DataTable();
        DataTable dtDichVu_Thuoc = new DataTable();
        DataTable dtDichVu_ViSinh = new DataTable();

        DataTable dtDichVu_Khac_ChiTiet = new DataTable();
        DataTable dtDichVu_NoiSoi_ChiTiet = new DataTable();
        DataTable dtDichVu_Thuoc_ChiTiet = new DataTable();
        DataTable dtDichVu_ViSinh_ChiTiet = new DataTable();
        bool _Loading = false;
        private void frmDM_DoiTuongDichVu_Gia_Load(object sender, EventArgs e)
        {
            _Loading = true;
            Load_NhomDoiTuong();
            LoadDichVu(5);

            LoadMaNhomCLS(5);
            Load_Nhom_DMKhamBenh();
            LoadDMSieuAm();
            LoadDMNoiSoi();
            LoadDichVu_ChiTiet(5);
          //  LoadDMXetNghiem();
            LoadDMNhomDVKhac();
            Load_DMDVKhac();
            LoadDMNhomThuoc();
            LoadDMXQuang();
            _Loading = false;
            LoadDMXetNghiem();
            Load_DMThuoc();

            Check_AllowManange();

        }
        private void Check_AllowManange()
        {
            btnAddService.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                       UserConstant.PermissionManageCustomerObject);
            dtgService.ReadOnly = !CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                      UserConstant.PermissionManageCustomerObject);

            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionTestCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsXetNghiem).ToString()))
                tabControl1.TabPages.Remove(tabDvXetNghiem);
            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionXRayCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsXQuang).ToString()))
                tabControl1.TabPages.Remove(tabXQuang);
            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionEdoscopicCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsNoiSoi).ToString()))
                tabControl1.TabPages.Remove(tabNoiSoi);
            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionUltraSoundCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsSieuAm).ToString()))
                tabControl1.TabPages.Remove(tabDVSieuAm);
            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionMedicineCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.Duoc).ToString()))
                tabControl1.TabPages.Remove(tabThuoc);
            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionDiagnotiscCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.KhamBenh).ToString()))
                tabControl1.TabPages.Remove(tabKhamBenh);
            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, UserConstant.PermissionOtherCost) && !CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.DvKhac).ToString()))
                tabControl1.TabPages.Remove(tabDVKhac);
        }
        private void Load_NhomDoiTuong()
        {
            colNhomDoiTuong.DataSource = sysConfig.Get_NhomDoiTuongDichVu(false);
            colNhomDoiTuong.ValueMember = "MaNhomDoiTuong";
            colNhomDoiTuong.DisplayMember = "TenNhomDoiTuong";
        }
        /// <summary>
        /// Lấy thông tin dịch vụ
        /// </summary>
        /// <param name="_Type">1:Dịch vụ ; 2:Dịch vụ XN ; 3: Dịch vụ siêu âm; 4: Dịch vụ XQuang; 5: Tất cả; 6: Dịch vụ siêu âm; 7: Dịch vụ khám bệnh; 8: Dịch vụ khác; 9: Dịch vụ thuốc</param>
        private void LoadDichVu(int _Type)
        {
            //if (_Type == 1 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(ref daService, dtgService, bvService, "", ref dtDichVu);
            //}
            //if (_Type == 2 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgServiceXN,bvService_XN, "", ref dtDichVu_XN);
            //}
            //if (_Type == 3 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgDichVu_SA, bvDichVu_SA, "", ref dtDichVu_SA);
            //}
            //if (_Type == 4 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgDichVu_XQuang, bvDichVu_XQuang, "", ref dtDichVu_XQuang);
            //}
            //if (_Type == 6 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgDichVu_NoiSoi, bvDichVu_NoiSoi, "", ref dtDichVu_NoiSoi);
            //}
            //if (_Type == 7 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgDicVu_KB, bvDicVu_KB, "", ref dtDichVu_KhamBenh);
            //}
            //if (_Type == 8 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgDichVu_Khac, bvDichVu_Khac, "", ref dtDichVu_Khac);
            //}
            //if (_Type == 9 || _Type == 5)
            //{
            //    sysConfig.Get_DoiTuongDichVu(dtgDichVu_Thuoc, bvDichVu_Thuoc, "", ref dtDichVu_Thuoc);
            //}
        }
        /// <summary>
        /// Lấy chi tiết dịch vụ
        /// </summary>
        /// <param name="_Type">1:Chi tiet cho xét nghiệm ; 2: Chi tiết siêu âm</param>
        private void LoadDichVu_ChiTiet(int _Type)
        {
            if (_Type == 1 || _Type == 5)
            {
                string maDoiTuongDichVu = "";

                if (dtgServiceXN.RowCount > 0)
                {
                    if (dtgServiceXN.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgServiceXN.CurrentRow.Cells["XN_ServiceID"].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_XN(dtgServiceTest, bvServiceTest, maDoiTuongDichVu, string.Empty, ref dtDichVu_XN_ChiTiet);
                SearchData();
            }
            if (_Type == 2 || _Type == 5)
            {
                string maDoiTuongDichVu = "";
                if (dtgDichVu_SA.RowCount > 0)
                {
                    if (dtgDichVu_SA.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgDichVu_SA.CurrentRow.Cells["SA_ServiceID"].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_SieuAm(dtgDichVu_SA_ChiTiet, bvDichVu_SA_ChiTiet, maDoiTuongDichVu, string.Empty, ref dtDichVu_SA_ChiTiet);
            }

            if (_Type == 3 || _Type == 5)
            {
                string maDoiTuongDichVu = "";
                if (dtgDichVu_XQuang.RowCount > 0)
                {
                    if (dtgDichVu_XQuang.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgDichVu_XQuang.CurrentRow.Cells["MaDichVu_XQuang"].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_XQuang(dtgXQuang_ChiTiet, bvXQuang_ChiTiet, maDoiTuongDichVu, string.Empty, ref dtDichVu_XQuang_ChiTiet);
            }

            if (_Type == 6 || _Type == 5)
            {
                string maDoiTuongDichVu = "";
                if (dtgDichVu_NoiSoi.RowCount > 0)
                {
                    if (dtgDichVu_NoiSoi.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgDichVu_NoiSoi.CurrentRow.Cells[MaDichVu_ns.Name].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_NoiSoi(dtgNoiSoi, bvNoiSoi, maDoiTuongDichVu, string.Empty, ref dtDichVu_NoiSoi_ChiTiet);
            }

            if (_Type == 7 || _Type == 5)
            {
                string maDoiTuongDichVu = "";
                if (dtgDicVu_KB.RowCount > 0)
                {
                    if (dtgDicVu_KB.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgDicVu_KB.CurrentRow.Cells[MaDichVu_KB.Name].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_KhamBenh(dtgDicVu_KB_ChiTiet, bvDicVu_KB_ChiTiet, maDoiTuongDichVu, string.Empty, ref dtDichVu_KhamBenh_ChiTiet);
            }
            if (_Type == 8 || _Type == 5)
            {
                string maDoiTuongDichVu = "";
                if (dtgDichVu_Khac.RowCount > 0)
                {
                    if (dtgDichVu_Khac.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgDichVu_Khac.CurrentRow.Cells[MaDichVu_Khac.Name].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_Khac(dtgDichVu_Khac_ChiTiet, bvDichVu_Khac_ChiTiet, maDoiTuongDichVu, string.Empty, ref dtDichVu_Khac_ChiTiet);
            }
            if (_Type == 9 || _Type == 5)
            {
                string maDoiTuongDichVu = "";
                if (dtgDichVu_Thuoc.RowCount > 0)
                {
                    if (dtgDichVu_Thuoc.CurrentRow != null)
                    {
                        maDoiTuongDichVu = dtgDichVu_Thuoc.CurrentRow.Cells[MaDichVu_Thuoc.Name].Value.ToString().Trim();
                    }
                }
                sysConfig.Get_DichVu_Thuoc(dtgDichVu_ChiTiet_Thuoc, bvDV_ChiTietThuoc, maDoiTuongDichVu, string.Empty, ref dtDichVu_Thuoc_ChiTiet);
            }
        }
        /// <summary>
        /// Load thông tin nhóm CLS
        /// </summary>
        /// <param name="_Type">1:Load nhóm cho DV</param>
        private void LoadMaNhomCLS(int _Type)
        {
            if (_Type == 1 || _Type == 5)
            {
                sysConfig.GetTestGroup(cboMaNhomCLS_Service, "", string.Empty);
            }
        }
        private void Load_Nhom_DMKhamBenh()
        {
            sysConfig.Get_DM_KhamBenh_DichVu(cboDvKhamBenh, "", "");
        }
        private void LoadDMXetNghiem()
        {
            if (_Loading == false)
            {
                sysConfig.GetSubclinicalTestAndProfile(cboTest_Service, (cboMaNhomCLS_Service.SelectedIndex != -1 ? cboMaNhomCLS_Service.SelectedValue.ToString().Trim() : ""), string.Empty);
            }
        }
        private void LoadDMSieuAm()
        {
            sysConfig.Get_DMSieuAm(cboMauSieuAm, "", "");
        }
        private void LoadDMXQuang()
        {
            sysConfig.Get_DM_XQuang_VungChup(cboVungChup, "", "");
        }
        private void LoadDMNoiSoi()
        {
            sysConfig.Get_DMNoiSoi(cboMauNoiSoi, "", "");
        }
        private void LoadDMKhamBenh()
        {
            sysConfig.Get_DM_KhamBenh_NhomDichVu(cboDvKhamBenh, "");
        }
        private void LoadDMNhomDVKhac()
        {
            sysConfig.Get_DM_NHOMCLS_DVKHAC(cboNhomDVKhac, "");
        }
 
        private void Load_DMDVKhac()
        {
            if (_Loading == false)
            {
                sysConfig.Get_DM_DICHVUKHAC(cboYeuCauDVKhac, (cboNhomDVKhac.SelectedIndex != -1 ? " and MaNhomCLS ='" + cboNhomDVKhac.SelectedValue.ToString().Trim() + "'" : ""), "");
            }
        }
        private void LoadDMNhomThuoc()
        {
            DM_THUOC_NHOMTHUOC_DAL nhomThuocDAL = new DM_THUOC_NHOMTHUOC_DAL();
            nhomThuocDAL.Data_DM_Thuoc_NhomThuoc(cboNhomThuoc, "MaNhomThuoc", "MaNhomThuoc", "MaNhomThuoc,TenNhomThuoc", "50,150", null, -1, "");
        }
        private void Load_DMThuoc()
        {
            if (_Loading == false)
            {
                string _MaNhomThuoc = cboNhomThuoc.SelectedIndex == -1 ? "" : cboNhomThuoc.SelectedValue.ToString().Trim();
                thuocDAL.Data_DM_Thuoc_ForWork(cboThuoc, "MaVatTu", "MaVatTu", "MaVatTu, TenVatTu, DonViTinh", "50,50,150", null, 0, "", _MaNhomThuoc, "");
            }
        }

        private void AddNew_Service()
        {
            if (txtServiceID.Text != "")
            {
                if (DataProvider.ExecuteDataset(CommandType.Text, "select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu where MaDoiTuongDichVu ='" + txtServiceID.Text.Trim() + "'").Tables[0].Rows.Count > 0)
                {
                    CustomMessageBox.MSG_Information_OK("Mã dịch vụ đã có trước !\nHãy chọn mã khác.");
                    txtServiceID.Focus();
                    txtServiceID.SelectAll();
                }
                else
                {
                    string _strSQL = " insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu (MaDoiTuongDichVu, TenDoiTuongDichVu, EmailDoiTuongDichVu, PhoneDoiTuongDichVu, DiaChiDoiTuongDichVu, WebSiteDoiTuongDichVu, LamTieuDe)\n";
                    _strSQL += " select '" + txtServiceID.Text.Trim() + "'";
                    _strSQL += "," + (txtServiceName.Text == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(txtServiceName.Text) + "'");
                    _strSQL += "," + (txtEmail.Text == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(txtEmail.Text) + "'");
                    _strSQL += "," + (txtPhone.Text == "" ? "NULL" : "'" + txtPhone.Text + "'");
                    _strSQL += "," + (txtAddress.Text == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(txtAddress.Text) + "'");
                    _strSQL += "," + (txtWebSiteDichVu.Text == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(txtWebSiteDichVu.Text) + "'");
                    _strSQL += "," + (chkPrintHead.Checked == false ? "0" : "1");
                    DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
                    txtServiceID.Text = "";
                    txtEmail.Text = "";
                    txtServiceName.Text = "";
                    txtAddress.Text = "";
                    txtPhone.Text = "";
                    txtWebSiteDichVu.Text = "";
                    txtServiceID.Focus();
                    LoadDichVu(5);
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng nhập mã Dịch vụ!");
                txtServiceID.Focus();
            }
        }

        private void Delete_Service(string _MaDV)
        {
            sysConfig.Delete_DichVu(_MaDV);
        }
        private void Delete_TestDetail(string _MaDV, string _MaXN)
        {
            sysConfig.Delete_ChiTiet_XN(_MaDV, _MaXN);
        }
        private void Delete_ViSinh(string _MaDV, string _MaXN)
        {
           sysConfig.Delete_ChiTiet_ViSinh(_MaDV, _MaXN);
        }
        private void btnAddService_Click(object sender, EventArgs e)
        {
            AddNew_Service();
        }

        private void dtgService_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgService.RowCount > 0)
            {
                DataProvider.UpdateData(daService,ref dtDichVu, dtgService, "", "");
            }
        }

        private void btnRefreshLocation_Click(object sender, EventArgs e)
        {
            LoadDichVu(5);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            LoadDichVu(2);
        }

        private void dtgServiceXN_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(1);
        }

        private void cboMaNhomCLS_Service_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDMXetNghiem();
        }

        private void btnAddTest_Service_Click(object sender, EventArgs e)
        {
            if (cboTest_Service.SelectedIndex != -1 && dtgServiceXN.CurrentRow !=null )
            {
               sysConfig.Add_DichVu_ChiTiet_XN(dtgServiceXN.CurrentRow.Cells["XN_ServiceID"].Value.ToString().Trim(), cboTest_Service.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(1);
            }
        }

        private void btnAddAll_S_Test_Click(object sender, EventArgs e)
        {
            if ( dtgServiceXN.CurrentRow != null)
            {
               sysConfig.Add_DichVu_ChiTiet_XN(dtgServiceXN.CurrentRow.Cells["XN_ServiceID"].Value.ToString().Trim(), "");
                LoadDichVu_ChiTiet(1);
            }
        }

        private void btnAddChitiet_TcDV_Click(object sender, EventArgs e)
        {
            if (dtgServiceXN.RowCount > 0)
            {
                for (int i = 0; i < dtgServiceXN.RowCount; i++)
                {
                   sysConfig.Add_DichVu_ChiTiet_XN(dtgServiceXN.Rows[i].Cells["XN_ServiceID"].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(1);
            }
        }

        private void btnDeleteLTest_Click(object sender, EventArgs e)
        {
            if (dtgServiceXN.CurrentRow != null && dtgServiceTest.CurrentRow != null)
            {
                Delete_TestDetail(dtgServiceXN.CurrentRow.Cells["XN_ServiceID"].Value.ToString().Trim(), dtgServiceTest.CurrentRow.Cells["ServiceTest_MaXN"].Value.ToString().Trim());
                LoadDichVu_ChiTiet(1);
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (dtgService.CurrentRow != null)
            {
                Delete_Service(dtgService.CurrentRow.Cells["ServiceID"].Value.ToString().Trim());
            }
        }

        private void dtgDichVu_SA_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(2);
        }

        private void btnRefreshDV_SA_Click(object sender, EventArgs e)
        {
            LoadDichVu(3);
        }

        private void btnRefreshSieuAm_DV_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(2);
        }

        private void btnThemTatCaDVSieuAm_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_SA.RowCount > 0)
            {
                for (int i = 0; i < dtgDichVu_SA.RowCount; i++)
                {
                    sysConfig.Add_DichVu_ChiTiet_SieuAm(dtgDichVu_SA.Rows[i].Cells["SA_ServiceID"].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(2);
            }
        }

        private void btnThemTatCaMau_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_SA.CurrentRow != null)
            {
                sysConfig.Add_DichVu_ChiTiet_SieuAm(dtgDichVu_SA.CurrentRow.Cells["SA_ServiceID"].Value.ToString().Trim(), "");
                LoadDichVu_ChiTiet(2);
            }
        }

        private void btnThemMauSieuAm_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_SA.CurrentRow != null && cboMauSieuAm.SelectedIndex !=-1)
            {
                sysConfig.Add_DichVu_ChiTiet_SieuAm(dtgDichVu_SA.CurrentRow.Cells["SA_ServiceID"].Value.ToString().Trim(), cboMauSieuAm.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(2);
            }
        }

        private void btnXoa_SieuAmDV_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_SA_ChiTiet.CurrentRow != null)
            {
                sysConfig.Delete_ChiTiet_SieuAm(dtgDichVu_SA_ChiTiet.CurrentRow.Cells["SA_MaDichVu_ChiTiet"].Value.ToString().Trim(), dtgDichVu_SA_ChiTiet.CurrentRow.Cells["SA_MaSoMau_ChiTiet"].Value.ToString().Trim());
                LoadDichVu_ChiTiet(2);
            }
        }

        private void dtgServiceTest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_XN_Gia(dtgServiceXN.CurrentRow.Cells["XN_ServiceID"].Value.ToString().Trim(), dtgServiceTest.CurrentRow.Cells["ServiceTest_MaXN"].Value.ToString().Trim(), dtgServiceTest.CurrentRow.Cells["XNGiaRieng"].Value.ToString().Trim());
        }

        private void dtgDichVu_SA_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_SieuAm_Gia(dtgDichVu_SA_ChiTiet.CurrentRow.Cells["SA_MaDichVu_ChiTiet"].Value.ToString().Trim(), dtgDichVu_SA_ChiTiet.CurrentRow.Cells["SA_MaSoMau_ChiTiet"].Value.ToString().Trim(), dtgDichVu_SA_ChiTiet.CurrentRow.Cells["SA_GiaRieng"].Value.ToString().Trim());
        }

        private void btnThemDichVu_VC_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_XQuang.RowCount > 0)
            {
                for (int i = 0; i < dtgDichVu_XQuang.RowCount; i++)
                {
                    sysConfig.Add_DichVu_ChiTiet_XQuang(dtgDichVu_XQuang.Rows[i].Cells["MaDichVu_XQuang"].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(3);
            }
        }

        private void btnThemVungChup_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_XQuang.CurrentRow != null && cboVungChup.SelectedIndex != -1)
            {
                sysConfig.Add_DichVu_ChiTiet_XQuang(dtgDichVu_XQuang.CurrentRow.Cells["MaDichVu_XQuang"].Value.ToString().Trim(), cboVungChup.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(3);
            }
        }

        private void btnThemVungChup_All_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_XQuang.CurrentRow != null)
            {
                sysConfig.Add_DichVu_ChiTiet_XQuang(dtgDichVu_XQuang.CurrentRow.Cells[MaDichVu_XQuang.Name].Value.ToString().Trim(),"");
                LoadDichVu_ChiTiet(3);
            }
        }

        private void btnXoa_VungChup_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_XQuang.CurrentRow != null)
            {
                sysConfig.Delete_ChiTiet_XQuang(dtgXQuang_ChiTiet.CurrentRow.Cells["DichVu_VupChup_ChiTiet"].Value.ToString().Trim(), dtgXQuang_ChiTiet.CurrentRow.Cells["MaVungChup"].Value.ToString().Trim());
                LoadDichVu_ChiTiet(3);
            }
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(3);
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            LoadDichVu(4);
        }

        private void dtgDichVu_XQuang_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(3);
        }

        private void cboTest_Service_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnAddTest_Service_Click(sender, e);
        }

        private void dtgXQuang_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_XQuang_Gia(dtgXQuang_ChiTiet.CurrentRow.Cells["DichVu_VupChup_ChiTiet"].Value.ToString().Trim(),
                dtgXQuang_ChiTiet.CurrentRow.Cells["MaVungChup"].Value.ToString().Trim(), dtgXQuang_ChiTiet.CurrentRow.Cells["dtgXQuangChitiet_GR"].Value.ToString().Trim());
        }

        private void btnRefreshDVNoiSoi_Click(object sender, EventArgs e)
        {
            LoadDichVu(6);
        }

        private void btnRefreshNoiSoi_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(6);
        }

        private void btnDeleteNoiSoi_Click(object sender, EventArgs e)
        {
            if (dtgNoiSoi.CurrentRow != null)
            {
                sysConfig.Delete_ChiTiet_NoiSoi(dtgNoiSoi.CurrentRow.Cells[nsMaDichVu.Name].Value.ToString().Trim(), dtgNoiSoi.CurrentRow.Cells[nsMaSoMau.Name].Value.ToString().Trim());
                LoadDichVu_ChiTiet(6);
            }
        }

        private void btnThem_NoiSoi_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_NoiSoi.CurrentRow != null && cboMauNoiSoi.SelectedIndex != -1)
            {
                sysConfig.Add_DichVu_ChiTiet_NoiSoi(dtgDichVu_NoiSoi.CurrentRow.Cells[MaDichVu_ns.Name].Value.ToString().Trim(), cboMauNoiSoi.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(6);
            }
        }

        private void btnThemDV_NoiSoi_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_NoiSoi.RowCount > 0)
            {
                for (int i = 0; i < dtgDichVu_SA.RowCount; i++)
                {
                    sysConfig.Add_DichVu_ChiTiet_NoiSoi(dtgDichVu_NoiSoi.Rows[i].Cells[MaDichVu_ns.Name].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(6);
            }
        }

        private void btnThemmTatCaDV_NoiSoi_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_NoiSoi.RowCount > 0)
            {
                if (dtgDichVu_NoiSoi.CurrentRow != null)
                {
                    sysConfig.Add_DichVu_ChiTiet_NoiSoi(dtgDichVu_NoiSoi.CurrentRow.Cells[MaDichVu_ns.Name].Value.ToString().Trim(), "");
                    LoadDichVu_ChiTiet(6);
                }
            }
        }

        private void dtgDichVu_NoiSoi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(6);
        }

        private void dtgNoiSoi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_NoiSoi_Gia(dtgNoiSoi.CurrentRow.Cells[nsMaDichVu.Name].Value.ToString().Trim(), dtgNoiSoi.CurrentRow.Cells[nsMaSoMau.Name].Value.ToString().Trim(), (dtgNoiSoi.CurrentRow.Cells[nsGiaRieng.Name].Value == null ? "0" : dtgNoiSoi.CurrentRow.Cells[nsGiaRieng.Name].Value.ToString().Trim()));
        }

        private void cboDvKhamBenh_Enter(object sender, EventArgs e)
        {
            LoadDMKhamBenh();
        }

        private void btnThemKB_ChoDV_Click(object sender, EventArgs e)
        {
            if (dtgDicVu_KB.CurrentRow != null && cboDvKhamBenh.SelectedIndex != -1)
            {
                sysConfig.Add_DichVu_ChiTiet_KhamBenh(dtgDicVu_KB.CurrentRow.Cells[MaDichVu_KB.Name].Value.ToString().Trim(), cboDvKhamBenh.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(7);
            }
        }

        private void btnRefresh_DV_KB_Click(object sender, EventArgs e)
        {
            LoadDichVu(7);
        }

        private void btnThem_TCKb_ChoDV_Click(object sender, EventArgs e)
        {
            if (dtgDicVu_KB.RowCount > 0)
            {
                if (dtgDicVu_KB.CurrentRow != null)
                {
                    sysConfig.Add_DichVu_ChiTiet_KhamBenh(dtgDicVu_KB.CurrentRow.Cells[MaDichVu_KB.Name].Value.ToString().Trim(),"");
                    LoadDichVu_ChiTiet(7);
                }
            }
        }

        private void cboThemKB_TCDichVu_Click(object sender, EventArgs e)
        {
            if (dtgDicVu_KB.RowCount > 0)
            {
                for (int i = 0; i < dtgDicVu_KB.RowCount; i++)
                {
                    sysConfig.Add_DichVu_ChiTiet_KhamBenh(dtgDicVu_KB.Rows[i].Cells[MaDichVu_KB.Name].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(7);
            }
        }

        private void dtgDicVu_KB_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_KhamBenh_Gia(dtgDicVu_KB_ChiTiet.CurrentRow.Cells[MaDichDV_CT_KB.Name].Value.ToString().Trim(), dtgDicVu_KB_ChiTiet.CurrentRow.Cells[MaYeuCau.Name].Value.ToString().Trim(), dtgDicVu_KB_ChiTiet.CurrentRow.Cells[GiaRieng_KB.Name].Value.ToString().Trim());
        }

        private void btnRefreshDV_KB_ChiTiet_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(7);
        }

        private void btnDelete_DV_KB_Chitiet_Click(object sender, EventArgs e)
        {
            if (dtgDicVu_KB_ChiTiet.CurrentRow != null)
            {
                sysConfig.Delete_ChiTiet_KhamBenh(dtgDicVu_KB_ChiTiet.CurrentRow.Cells[MaDichDV_CT_KB.Name].Value.ToString().Trim(), dtgDicVu_KB_ChiTiet.CurrentRow.Cells[MaYeuCau.Name].Value.ToString().Trim());
                LoadDichVu_ChiTiet(7);
            }
        }

        private void dtgDicVu_KB_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(7);
        }

        private void btnRefresh_DichVu_DienTim_Click(object sender, EventArgs e)
        {
            LoadDichVu(8);
        }

        private void btnRefesh_DichVu_DienTim_ChiTiet_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(8);
        }

        private void btnThemTC_DVKhac_ChoTCDV_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_Khac.RowCount > 0)
            {
                for (int i = 0; i < dtgDichVu_Khac.RowCount; i++)
                {
                    sysConfig.Add_DichVu_ChiTiet_DVKhac(dtgDichVu_Khac.Rows[i].Cells[MaDichVu_Khac.Name].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(8);
            }
        }

        private void btnThemDVyeuCau_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_Khac.CurrentRow != null && cboYeuCauDVKhac.SelectedIndex != -1)
            {
                sysConfig.Add_DichVu_ChiTiet_DVKhac(dtgDichVu_Khac.CurrentRow.Cells[MaDichVu_Khac.Name].Value.ToString().Trim(), cboYeuCauDVKhac.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(8);
            }
        }

        private void btnThem_TCDVKhac_ChoDV_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_Khac.RowCount > 0)
            {
                if (dtgDichVu_Khac.CurrentRow != null)
                {
                    sysConfig.Add_DichVu_ChiTiet_DVKhac(dtgDichVu_Khac.CurrentRow.Cells[MaDichVu_Khac.Name].Value.ToString().Trim(), "");
                    LoadDichVu_ChiTiet(8);
                }
            }
        }

        private void cboNhomDVKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboYeuCauDVKhac);
        }

        private void cboYeuCauDVKhac_Enter(object sender, EventArgs e)
        {
            Load_DMDVKhac();
        }

        private void dtgDichVu_Khac_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(8);
        }

        private void cboYeuCauDVKhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnThemDVyeuCau_Click(sender, e);
            }
        }

        private void dtgDichVu_Khac_ChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_DVKhac_Gia(dtgDichVu_Khac.CurrentRow.Cells[MaDichVu_Khac.Name].Value.ToString().Trim(), dtgDichVu_Khac_ChiTiet[ctMaDichVuKhac.Name,e.RowIndex].Value.ToString().Trim(), dtgDichVu_Khac_ChiTiet[GiaRieng_DVkhac.Name,e.RowIndex].Value.ToString().Trim());
        }

        private void btnRefreshDV_Thuoc_Click(object sender, EventArgs e)
        {
            LoadDichVu(9);
        }

        private void btnRefresh_DV_ChiTiet_Thuoc_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(9);
        }

        private void btnDeleteDV_ChiTiet_Thuoc_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_ChiTiet_Thuoc.CurrentRow != null)
            {
                sysConfig.Delete_ChiTiet_Thuoc(dtgDichVu_ChiTiet_Thuoc.CurrentRow.Cells[MaDichVu_Thuoc_CT.Name].Value.ToString().Trim(), dtgDichVu_ChiTiet_Thuoc.CurrentRow.Cells[MaThuoc_CT.Name].Value.ToString().Trim());
                LoadDichVu_ChiTiet(9);
            }
        }

        private void dtgDichVu_ChiTiet_Thuoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sysConfig.Update_ChiTiet_Thuoc_Gia(dtgDichVu_ChiTiet_Thuoc.CurrentRow.Cells[MaDichVu_Thuoc_CT.Name].Value.ToString().Trim(), dtgDichVu_ChiTiet_Thuoc[MaThuoc_CT.Name, e.RowIndex].Value.ToString().Trim(), dtgDichVu_ChiTiet_Thuoc[GiaRieng_Thuoc.Name, e.RowIndex].Value.ToString().Trim());
        }

        private void bvThemTatCa_DV_Thuoc_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_Thuoc.RowCount > 0)
            {
                for (int i = 0; i < dtgDichVu_Thuoc.RowCount; i++)
                {
                    sysConfig.Add_DichVu_ChiTiet_Thuoc(dtgDichVu_Thuoc.Rows[i].Cells[MaDichVu_Thuoc.Name].Value.ToString().Trim(), "");
                }
                LoadDichVu_ChiTiet(9);
            }
        }

        private void btnThemTatCa_DVvaThuoc_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_Thuoc.RowCount > 0)
            {
                sysConfig.Add_DichVu_ChiTiet_Thuoc(dtgDichVu_Thuoc.CurrentRow.Cells[MaDichVu_Thuoc.Name].Value.ToString().Trim(), "");
                LoadDichVu_ChiTiet(9);
            }
        }

        private void btnThem_Thuoc_Click(object sender, EventArgs e)
        {
            if (dtgDichVu_Thuoc.RowCount > 0 && cboThuoc.SelectedIndex !=-1)
            {
                sysConfig.Add_DichVu_ChiTiet_Thuoc(dtgDichVu_Thuoc.CurrentRow.Cells[MaDichVu_Thuoc.Name].Value.ToString().Trim(), cboThuoc.SelectedValue.ToString().Trim());
                LoadDichVu_ChiTiet(9);
                cboThuoc.Focus();
                cboThuoc.DroppedDown = true;
            }
        }

        private void dtgDichVu_Thuoc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(9);
        }

        private void cboNhomThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DMThuoc();
        }

        private void cboNhomThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboThuoc);
        }

        private void cboThuoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThem_Thuoc);
        }

        private void txtServiceID_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtEmail);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtAddress);
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtPhone);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtWebSiteDichVu);
        }

        private void txtWebSiteDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnAddService);
        }

        private void btnRefreshLTest_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(1);
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        private void SearchData()
        {
            if (bvServiceTest.BindingSource != null)
            {
                bvServiceTest.BindingSource.Filter = string.Format("MaDichVu like '%{0}%' or tenxn like '%{0}%'", txtSearch.Text);
            }
        }

        private void btnCopyXN_Click(object sender, EventArgs e)
        {
            var f = new Settings.DanhMucCLS.FrmCopyGiaDoiTuongDichVu();
            f.svrType = ServiceType.ClsXetNghiem;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            LoadDichVu_ChiTiet(1);
        }

        private void dtgDoiTuong_ViSinh_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadDichVu_ChiTiet(10);
        }

        private void btnCopyGiaViSinh_Click(object sender, EventArgs e)
        {
            var f = new Settings.DanhMucCLS.FrmCopyGiaDoiTuongDichVu();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            LoadDichVu_ChiTiet(10);
        }

        private void btnLamMoiDichVu_ViSinh_Click(object sender, EventArgs e)
        {
            LoadDichVu_ChiTiet(10);
        }
    }
}
