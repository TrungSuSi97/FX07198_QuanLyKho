using System;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;

using System.Data;
using System.Linq;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Services.UserManagement;
using TPH.LIS.Statistic.Controls;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Constants;
using System.Drawing;
using TPH.LIS.Analyzer.Services;
using System.Collections.Generic;
using TPH.Controls;
using TPH.LIS.App.AppCode;

namespace TPH.LIS.App.ThongKe
{
    public partial class frmThongKeTongHopXN : FrmTemplate
    {
        public frmThongKeTongHopXN()
        {
            InitializeComponent();
            treLoaiThongKe.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IUserManagementService userConfig = new UserManagementService();
        private readonly IAnalyzerConfigService analyzer = new AnalyzerConfigService();
        //C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        //C_NhanVien nhanvien = new C_NhanVien();
        //C_Patient pInfo = new C_Patient();
        //C_Config config = new C_Config();
        private void frmThongKeTongHop_Load(object sender, EventArgs e)
        {
            treLoaiThongKe.ExpandAll();
            // cboKhuDieuTri.SelectedIndexChanged -= cboKhuDieuTri_SelectedIndexChanged;
            ControlExtension.BindDataToCobobox(sysConfig.Data_ql_nhanvien(string.Empty, string.Empty), ref cboBSChiDinh, "MaNhanVien", "MaNhanVien", "MaNhanVien,TenNhanVien", "50,250", null, -1);
            ControlExtension.BindDataToCobobox(sysConfig.Data_ql_nhanvien(string.Empty, string.Empty), ref cboNhanVienXacNhan, "MaNhanVien", "MaNhanVien", "MaNhanVien,TenNhanVien", "50,250", null, -1);
            //   sysConfig.Get_Data_dm_bophan(cboKhuDieuTri, "MaBoPhan", "MaBoPhan", "MaBoPhan,TenBoPhan", "50,250", null, -1, string.Empty, string.Empty);

            ControlExtension.BindDataToCobobox(sysConfig.Data_dm_xetnghiem_bophan((CommonAppVarsAndFunctions.IsAdmin ? string.Empty : (CommonAppVarsAndFunctions.BoPhanClsXetNghiem == null ? "---NONE---" : string.Join(",", CommonAppVarsAndFunctions.BoPhanClsXetNghiem)))),ref  cboBoPhanXN, "MaBoPhan", "MaBoPhan", "MaBoPhan,TenBoPhan", "50,250", null, -1);
            ControlExtension.BindDataToCobobox(userConfig.GetUsersByConditions(string.Empty), ref cboNhanVienNhap, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung,TenNhanVien", "50,150", null, -1);
            sysConfig.Get_DoiTuongDichVu(cboDoiTuongDV, null);
            gcKhoaChiDinh.DataSource = sysConfig.GetLocation(string.Empty, string.Empty,string.Empty);
            gvKhoaChiDinh.ExpandAllGroups();
            Load_Donvi();
            sysConfig.GetTestGroup(cboNhomCLS, Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem));
            Load_ChiDinhCLS();
            dtpDateFrom.Value = AppCode.DateTimeConverter.StartOfDay(CommonAppVarsAndFunctions.ServerTime);
            dtpDateTo.Value = AppCode.DateTimeConverter.EndOfDay(CommonAppVarsAndFunctions.ServerTime);
            Load_MayXetNghiem();
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeBaoCaoRoiLoanChuyenHoa", true)[0]);
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeBaoCaoSLSS", true)[0]);
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeBCSLSS_DonVi", true)[0]); 
        }
        private EnumThoiGianThongKe LayThoiGianThongKe()
        {
            if (radTGInKQDauTien.Checked)
                return EnumThoiGianThongKe.ThoiGianInKetQuaDauTien;
            else if (radThoiGianNhanMau.Checked)
                return EnumThoiGianThongKe.ThoiGianNhanMau;
            else
                return EnumThoiGianThongKe.ThoiGianNhapBenhNhan;
        }
        private List<string> LayKhoaChiDinh()
        {
            var _listKhoaChiDinh = new List<string>();
            if (gvKhoaChiDinh.SelectedRowsCount <= 0) return new List<string>();
            foreach (var i in gvKhoaChiDinh.GetSelectedRows())
            {
                if (gvKhoaChiDinh.GetRowCellValue(i, colMaKhoaChiDinh) == null) continue;
                _listKhoaChiDinh.Add(gvKhoaChiDinh.GetRowCellValue(i, colMaKhoaChiDinh).ToString());
            }
            return _listKhoaChiDinh;
        }
        private NormalStatisticCondit GetNormalCondit()
        {
            var statisticCondit = new NormalStatisticCondit();
            statisticCondit.ServerName = CommonAppVarsAndFunctions.sysConfig.DatabaseThongKe;
            statisticCondit.ThoiGianThongKe = LayThoiGianThongKe();
            statisticCondit.TuNgay = dtpDateFrom.Value;
            statisticCondit.DenNgay = dtpDateTo.Value;
            statisticCondit.BoPhanXetNghiem = cboBoPhanXN.SelectedIndex > -1 ? (new List<string> { cboBoPhanXN.SelectedValue.ToString() }): CommonAppVarsAndFunctions.BoPhanClsXetNghiem.ToList();
            statisticCondit.NhomXetNghiem = cboNhomCLS.SelectedIndex > -1 ? (new List<string> {  cboNhomCLS.SelectedValue.ToString() }) : CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            //statisticCondit.KhuVuc = cboKhuDieuTri.SelectedIndex > -1 ? (new System.Collections.Generic.List<string> {  cboKhuDieuTri.SelectedValue.ToString() }) : CommonAppVarsAndFunctions.PhanQuyenKhuVuc.ToList();
            statisticCondit.KhoaPhong = LayKhoaChiDinh();
            statisticCondit.BSChiDinh = new List<string> { cboBSChiDinh.SelectedIndex > -1 ? cboBSChiDinh.SelectedValue.ToString() : string.Empty };
            statisticCondit.NhanVienNhapChiDinh = new List<string> { cboNhanVienNhap.SelectedIndex > -1 ? cboNhanVienNhap.SelectedValue.ToString() : string.Empty };
            statisticCondit.NhanVienXacNhanKetQua = new List<string> { cboNhanVienXacNhan.SelectedIndex > -1 ? cboNhanVienXacNhan.SelectedValue.ToString() : string.Empty };
            statisticCondit.DoiTuong = new List<string> { cboDoiTuongDV.SelectedIndex > -1 ? cboDoiTuongDV.SelectedValue.ToString() : string.Empty };
            statisticCondit.KetQua = txtKetQua.Text;
            statisticCondit.GhiChu = txtGhiChu.Text;
            statisticCondit.XetNghiem = ucDSXetNghiem.IsCheckedAll ? new List<string>() : ucDSXetNghiem.ListCheckedItem;
            statisticCondit.ProfileXetNghiem = ucProfile.IsCheckedAll ? new List<string>() : ucProfile.ListCheckedItem;
            statisticCondit.MayXetNghiem = ucMayXetNghiem.IsCheckedAll ? new List<string>() : ucMayXetNghiem.ListCheckedItem;
            statisticCondit.XetNghiemCoKetQua = chkChiCoKetQua.Checked;
            statisticCondit.XetNghiemDaXacNhan = chkChiXNDaXacNhan.Checked;
            var loaiXN = EnumDieuKienXetNghiem.TatCa;
            if (radXNChiSo.Checked)
                loaiXN = EnumDieuKienXetNghiem.XetNghiemChiSo;
            else if (radXNDichVu.Checked)
                loaiXN = EnumDieuKienXetNghiem.XetNghiemDichVu;
            statisticCondit.LoaiXetNghiem = loaiXN;
            return statisticCondit;
        }

        TPHTabControl tabStatistic;
        private void Check_Add_ChangeTab(string tabname, string tabtitle)
        {
            if (tabStatistic == null)
            {
                tabStatistic = new TPHTabControl();
                splitContainer2.Panel2.Controls.Add(tabStatistic);
                tabStatistic.Dock = DockStyle.Fill;
                tabStatistic.BringToFront();
                tabStatistic.Appearance = TabAppearance.FlatButtons;
                tabStatistic.ItemSize = new Size(0, 1);
                tabStatistic.SizeMode = TabSizeMode.Fixed;
                tabStatistic.BackColor = CommonAppColors.ColorMainAppFormColor;
            }
            ucGroupHeaderTabHeader.GroupCaption = tabtitle;
            foreach (TabPage tab in tabStatistic.TabPages)
            {
                if (tab.Name.Equals(tabname))
                {
                    tabStatistic.SelectedTab = tab;
                    return;
                }
            }
            tabStatistic.SelectedIndexChanged -= TabStatistic_SelectedIndexChanged;
            var tabNew = new TabPage
            {
                BackColor = CommonAppColors.ColorMainAppFormColor, Name = tabname, Text = tabtitle
            };
            bool allowAdd = false;
            switch (tabname)
            {
                case "nodTongHopBenhNhan":
                    var uc = new ucTongHopBenhNhan();
                    uc.getCondit += new ucTongHopBenhNhan.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc, tabNew);
                    uc.ShowMoney = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy,User.Constants.UserConstant.PermissionTestCost);
                    allowAdd = true;
                    break;
                case "nodTongHopXetNghiem":
                    var uc2 = new ucTongHopXetNghiem();
                    uc2.getCondit += new ucTongHopXetNghiem.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc2, tabNew);
                    uc2.ShowMoney = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, User.Constants.UserConstant.PermissionTestCost);
                    allowAdd = true;
                    break;
                case "nodChiTietXetNghiemTheoCot":
                    var uc3 = new ucTongHopBenhNhan_ChiTietXetNghiem();
                    uc3.getCondit += new ucTongHopBenhNhan_ChiTietXetNghiem.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc3, tabNew);
                    allowAdd = true;
                    break;
                case "nodTongHopXnTuMayTheoBenhNhan":
                    var uc4 = new ucTongHopXetNghiemTheoMay_BenhNhan();
                    uc4.getCondit += new ucTongHopXetNghiemTheoMay_BenhNhan.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc4, tabNew);
                    allowAdd = true;
                    break;
                case "nodTongHopXetNghiemTheoNgay":
                    var uc5 = new ucTongHopXetNghiem_TheoNgay();
                    uc5.getCondit += new ucTongHopXetNghiem_TheoNgay.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc5, tabNew);
                    allowAdd = true;
                    break;
                case "nodTongHopXetNghiemMay":
                    var uc6 = new ucTongHopXetNghiemTuMay();
                    uc6.getCondit += new ucTongHopXetNghiemTuMay.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc6, tabNew);
                    allowAdd = true;
                    break;
                case "nodTonghoptheoBSChiDinh":
                    var uc7 = new ucTongHopXetNghiem_BacSiChiDinh();
                    uc7.getCondit += new ucTongHopXetNghiem_BacSiChiDinh.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc7, tabNew);
                    uc7.ShowMoney = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenQuanLy, User.Constants.UserConstant.PermissionTestCost);
                    allowAdd = true;
                    break;
                case "nodTongHopMayTheoDoiTuong":
                    var uc8 = new ucTongHopXetNghiem_May_DoiTuong();
                    uc8.getCondit += new ucTongHopXetNghiem_May_DoiTuong.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc8, tabNew);
                    allowAdd = true;
                    break;
                case "nodTongHopTheoDoiTuong":
                    var uc9 = new ucTongHopXetNghiem_May_DoiTuong_TatCa();
                    uc9.getCondit += new ucTongHopXetNghiem_May_DoiTuong_TatCa.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc9, tabNew);
                    allowAdd = true;
                    break;
                case "nodeTongHopTAT":
                    var uc10 = new ucThongKeTAT();
                    uc10.getCondit += new ucThongKeTAT.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc10, tabNew);
                    allowAdd = true;
                    break;
                case "nodeBaoCaoRoiLoanChuyenHoa":
                    var uc11 = new ucTongHopSLSS_RoiLoanCH();
                    uc11.getCondit += new ucTongHopSLSS_RoiLoanCH.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc11, tabNew);
                    allowAdd = true;
                    break;
                case "nodeBaoCaoSLSS":
                    var uc12 = new ucTongHopSLSS();
                    uc12.getCondit += new ucTongHopSLSS.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc12, tabNew);
                    allowAdd = true;
                    break;
                case "nodeBCSLSS_DonVi":
                    var uc13 = new ucTongHopSLSS_DonVi();
                    uc13.getCondit += new ucTongHopSLSS_DonVi.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc13, tabNew);
                    allowAdd = true;
                    break;
                default:
                    break;
            }
            if (allowAdd)
            {
                tabStatistic.TabPages.Add(tabNew);
                tabStatistic.SelectedTab = tabNew;
            }

            tabStatistic.SelectedIndexChanged += TabStatistic_SelectedIndexChanged;
        }

        private void TabStatistic_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tab = ((TabControl)sender).SelectedTab;
            foreach (TreeNode nod in treLoaiThongKe.Nodes)
            {
                if (Check_SelectNode(nod, tab.Name))
                    break;
            }
        }
        private bool Check_SelectNode(TreeNode main, string nodeFindName)
        {
            foreach (TreeNode nod in main.Nodes)
            {
                if (nod.Name.Equals(nodeFindName))
                {
                    treLoaiThongKe.AfterSelect -= treLoaiThongKe_AfterSelect;
                    treLoaiThongKe.SelectedNode = nod;
                    Check_SetBackColorForTreeView();
                    treLoaiThongKe.AfterSelect += treLoaiThongKe_AfterSelect;
                    return true;
                }
            }
            return false;
        }

        private void AddUserControlToTab(UserControl uc, TabPage tabnew)
        {
            LabServices_Helper.SetControlColor(uc);
            tabnew.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void treLoaiThongKe_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Check_Add_ChangeTab(treLoaiThongKe.SelectedNode.Name, treLoaiThongKe.SelectedNode.Text);
            Check_SetBackColorForTreeView();
        }
        public TreeNode previousSelectedNode = null;
        private void Check_SetBackColorForTreeView()
        {
            treLoaiThongKe.SelectedNode.BackColor = Color.LightBlue;
            treLoaiThongKe.SelectedNode.ForeColor = Color.White;
            if (previousSelectedNode != null)
            {
                previousSelectedNode.BackColor = treLoaiThongKe.BackColor;
                previousSelectedNode.ForeColor = treLoaiThongKe.ForeColor;
            }
            previousSelectedNode = treLoaiThongKe.SelectedNode;
        }
        private void Load_MayXetNghiem()
        {
            string allowanalyzer = Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem);
            var mayXetNghiem = from selectData in analyzer.Data_h_mayxetnghiem().AsEnumerable()
                               where allowanalyzer.Contains(string.Format("'{0}'", selectData["idmay"].ToString()))
                               select selectData;
            if (mayXetNghiem.Any())
            {
                var data2 = mayXetNghiem.AsDataView().ToTable();
                var dt = data2.Clone();
                dt.Columns["IDMay"].DataType = typeof(string);
                dt.Load(data2.CreateDataReader(), LoadOption.OverwriteChanges);
                ucMayXetNghiem.DataSource = dt;
                ucMayXetNghiem.DisplayMember = "tenmay2";
                ucMayXetNghiem.ValueMember = "IDMay";
                ucMayXetNghiem.IsCheckedAll = true;
            }
        }
        private void Load_KhuVuc()
        {
            var data = sysConfig.Data_dm_khuvuc(string.Empty);
            
        }
        private void Load_Donvi(string maBophan = "")
        {
          //  sysConfig.GetLocation(cboDonvi, "MaKhoaPhong", "MaKhoaPhong", "MaKhoaPhong,TenKhoaPhong", "100,250", null, 1, maBophan);
        }
        private void Load_ChiDinhCLS()
        {
            var data = new DataTable();
            //var filter = " and KhongSD = 1 ";
            if (cboNhomCLS.SelectedIndex != -1)
            {
                data = sysConfig.Data_dm_xetnghiem(string.Join(",",  new string[1] { cboNhomCLS.SelectedValue.ToString() }), !CommonAppVarsAndFunctions.IsAdmin, string.Empty);  
            }
            else
            {
                data = sysConfig.Data_dm_xetnghiem(string.Join(",", CommonAppVarsAndFunctions.NhomClsXetNghiem ?? new string[1] { "---NONE---" }), !CommonAppVarsAndFunctions.IsAdmin, string.Empty);
            }

            ucDSXetNghiem.DataSource = data;
            ucDSXetNghiem.ValueMember = "MaXn";
            ucDSXetNghiem.DisplayMember = "TenXN";
            ucDSXetNghiem.IsCheckedAll = true;
            var data2 = sysConfig.Data_dm_xetnghiem_profile(string.Empty);
            ucProfile.DataSource = data2;
            ucProfile.ValueMember = "ProfileID";
            ucProfile.DisplayMember = "ProfileName";
            ucProfile.IsCheckedAll = true;

        }
        private void cboNhomCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_ChiDinhCLS();
        }
        private void cboBoPhanXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboCLS_ChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboNhanVienThucHien_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboNhanVienNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboKhuDieuTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboDonvi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }
    }
}
