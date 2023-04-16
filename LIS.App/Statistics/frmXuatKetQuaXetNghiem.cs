using System;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
using System.Data;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Services.UserManagement;
using TPH.LIS.ExportResult.Controls;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.ExportResult.Constants;
using System.Drawing;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Configuration.Models;
using TPH.Controls;
using TPH.LIS.App.AppCode;

namespace TPH.LIS.App.ThongKe
{
    public partial class frmXuatKetQuaXetNghiem : FrmTemplate
    {
        public frmXuatKetQuaXetNghiem()
        {
            InitializeComponent();
            treLoaiThongKe.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IUserManagementService userConfig = new UserManagementService();
        private readonly IAnalyzerConfigService analyzer = new AnalyzerConfigService();
        private void frmXuatKetQuaXetNghiem_Load(object sender, EventArgs e)
        {
            treLoaiThongKe.ExpandAll();
            cboKhuDieuTri.SelectedIndexChanged -= cboKhuDieuTri_SelectedIndexChanged;
            ControlExtension.BindDataToCobobox(sysConfig.Data_ql_nhanvien(string.Empty, string.Empty), ref cboBSChiDinh, "MaNhanVien", "MaNhanVien", "MaNhanVien,TenNhanVien", "50,250", null, -1);
            ControlExtension.BindDataToCobobox(sysConfig.Data_ql_nhanvien(string.Empty, string.Empty), ref cboNhanVienXacNhan, "MaNhanVien", "MaNhanVien", "MaNhanVien,TenNhanVien", "50,250", null, -1);
            sysConfig.Get_Data_dm_bophan(cboKhuDieuTri, "MaBoPhan", "MaBoPhan", "MaBoPhan,TenBoPhan", "50,250", null, -1, string.Empty, string.Empty);
            ControlExtension.BindDataToCobobox(sysConfig.Data_dm_xetnghiem_bophan((CommonAppVarsAndFunctions.IsAdmin ? string.Empty : (CommonAppVarsAndFunctions.BoPhanClsXetNghiem == null ? "---NONE---" : string.Join(",", CommonAppVarsAndFunctions.BoPhanClsXetNghiem)))), ref cboBoPhanXN, "MaBoPhan", "MaBoPhan", "MaBoPhan,TenBoPhan", "50,250", null, -1);
            var dataDoiTuong = sysConfig.Get_DoiTuongDichVu(string.Empty);
            ucDoiTuong.DataSource = dataDoiTuong;
            ucDoiTuong.ValueMember = "MaDoiTuongDichVu";
            ucDoiTuong.DisplayMember = "TenDoiTuongDichVu";
            cboKhuDieuTri.SelectedIndexChanged += cboKhuDieuTri_SelectedIndexChanged;
            Load_Donvi();
            sysConfig.GetTestGroup(cboNhomCLS, "");
            Load_ChiDinhCLS();
            dtpDateFrom.Value = AppCode.DateTimeConverter.StartOfDay(CommonAppVarsAndFunctions.ServerTime);
            dtpDateTo.Value = AppCode.DateTimeConverter.EndOfDay(CommonAppVarsAndFunctions.ServerTime);
            Load_MayXetNghiem();
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeImmulite1000", true)[0]);
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeAutoDelfia_double", true)[0]);
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeAutoDelfia_Plgf", true)[0]);

            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeGSP", true)[0]);
            treLoaiThongKe.Nodes.Remove(treLoaiThongKe.Nodes.Find("nodeQSight", true)[0]);
        }


        private ExportCondition GetNormalCondit()
        {
            var statisticCondit = new ExportCondition();
            statisticCondit.ServerName = CommonAppVarsAndFunctions.sysConfig.DatabaseThongKe;
            statisticCondit.XuatTheoTen = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXuatCotTheoTen;
            statisticCondit.ThoiGianXuat = (radTGInKQDauTien.Checked ? EnumThoiGianXuat.ThoiGianInKetQuaDauTien : EnumThoiGianXuat.ThoiGianNhapBenhNhan);
            statisticCondit.TuNgay = dtpDateFrom.Value;
            statisticCondit.DenNgay = dtpDateTo.Value;
            statisticCondit.BoPhanXetNghiem = cboBoPhanXN.SelectedIndex > -1 ? new System.Collections.Generic.List<string> { cboBoPhanXN.SelectedValue.ToString() } : new System.Collections.Generic.List<string>() { };// new System.Collections.Generic.List<string> { cboBoPhanXN.SelectedIndex > -1 ? cboBoPhanXN.SelectedValue.ToString() : string.Empty };
            statisticCondit.NhomXetNghiem = cboNhomCLS.SelectedIndex > -1 ? new System.Collections.Generic.List<string> { cboNhomCLS.SelectedValue.ToString() } : new System.Collections.Generic.List<string>() { }; //new System.Collections.Generic.List<string> { cboNhomCLS.SelectedIndex > -1 ? cboNhomCLS.SelectedValue.ToString() : string.Empty };
            statisticCondit.KhuVuc = new System.Collections.Generic.List<string> { cboKhuDieuTri.SelectedIndex > -1 ? cboKhuDieuTri.SelectedValue.ToString() : string.Empty };
            statisticCondit.KhoaPhong = new System.Collections.Generic.List<string> { cboDonvi.SelectedIndex > -1 ? cboDonvi.SelectedValue.ToString() : string.Empty };
            statisticCondit.BSChiDinh = new System.Collections.Generic.List<string> { cboBSChiDinh.SelectedIndex > -1 ? cboBSChiDinh.SelectedValue.ToString() : string.Empty };
            statisticCondit.DoiTuong = ucDoiTuong.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucDoiTuong.ListCheckedItem;
            statisticCondit.NhanVienXacNhanKetQua = cboNhanVienXacNhan.SelectedIndex > -1 ? new System.Collections.Generic.List<string> { cboNhanVienXacNhan.SelectedValue.ToString() } : new System.Collections.Generic.List<string>() {};
            statisticCondit.KetQua = txtKetQua.Text;
            statisticCondit.GhiChu = txtGhiChu.Text;
            statisticCondit.XetNghiem = ucDSXetNghiem.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucDSXetNghiem.ListCheckedItem;
            statisticCondit.ProfileXetNghiem = ucProfile.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucProfile.ListCheckedItem;
            statisticCondit.MayXetNghiem = ucMayXetNghiem.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucMayXetNghiem.ListCheckedItem;
            statisticCondit.XetNghiemCoKetQua = chkChiCoKetQua.Checked;
            statisticCondit.XetNghiemDaXacNhan = chkChiXNDaXacNhan.Checked;
            statisticCondit.XetNghiemChuaCoKetQua = chkNotresult.Checked;
            var loaiXN = EnumDieuKienXetNghiem.TatCa;
            if (radXNChiSo.Checked)
                loaiXN = EnumDieuKienXetNghiem.XetNghiemChiSo;
            else if (radXNDichVu.Checked)
                loaiXN = EnumDieuKienXetNghiem.XetNghiemDichVu;
            statisticCondit.LoaiDichVu = loaiXN;
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
            TabPage tabNew = new TabPage();
            tabNew.BackColor = CommonAppColors.ColorMainAppFormColor;
            tabNew.Name = tabname;
            tabNew.Text = tabtitle;
            bool allowAdd = false;
            switch (tabname)
            {
                case "nodChiTietXetNghiemTheoCot":
                    var uc = new ucKetQua_ChiTietXetNghiem();
                    uc.getCondit += new ucKetQua_ChiTietXetNghiem.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc, tabNew);
                
                    allowAdd = true;
                    break;
                case "nodTongHopXetNghiem":
                    var uc2 = new ucKetQua_TongHop_NormalGrid();
                    uc2.getCondit += new ucKetQua_TongHop_NormalGrid.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc2, tabNew);

                    allowAdd = true;
                    break;
                case "nodTongHopGopKetQua":
                    var uc3 = new ucKetQua_TongHop_GopKetQua();
                    uc3.getCondit += new ucKetQua_TongHop_GopKetQua.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc3, tabNew);

                    allowAdd = true;
                    break;
                case "nodDanhSachChiDinh":
                    var uc4 = new ucChiDinh_TongHop();
                    uc4.getCondit += new ucChiDinh_TongHop.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc4, tabNew);
                    allowAdd = true;
                    break;
                case "nodDanhSachChiDinh2":
                    var uc5 = new ucChiDinh_TongHop_ThuongQui();
                    uc5.getCondit += new ucChiDinh_TongHop_ThuongQui.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc5, tabNew);
                    allowAdd = true;
                    break;
                case "nodBaoCaoHIV":
                    var uc6 = new ucKetQua_TongHop_HIV();
                    uc6.getCondit += new ucKetQua_TongHop_HIV.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc6, tabNew);
                    allowAdd = true;
                    break;
                case "nodTongHop3":
                    var uc7 = new ucKetQua_TongHop3_NormalGrid();
                    uc7.getCondit += new ucKetQua_TongHop3_NormalGrid.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc7, tabNew);
                    allowAdd = true;
                    break;
                case "nodTongHop4":
                    var uc8 = new ucKetQua_TongHop_GopKetQua_NormalGrid4();
                    uc8.getCondit += new ucKetQua_TongHop_GopKetQua_NormalGrid4.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc8, tabNew);
                    allowAdd = true;
                    break;
                case "nodeSoLayNhanMau":
                    var uc9 = new ucKetQua_TongHop_MauXN_Thuong();
                    uc9.getCondit += new ucKetQua_TongHop_MauXN_Thuong.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc9, tabNew);
                    allowAdd = true;
                    break;
                case "nodeSoGiaoNhanMau":
                    var uc10 = new ucMauXetNghiem_GiaoNhanMau();
                    uc10.getCondit += new ucMauXetNghiem_GiaoNhanMau.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc10, tabNew);
                    allowAdd = true;
                    break;
                case "nodeTuChoiMau":
                    var uc11 = new ucMauXetNghiem_SoTuChoiMau();
                    uc11.getCondit += new ucMauXetNghiem_SoTuChoiMau.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc11, tabNew);
                    allowAdd = true;
                    break;
                case "nodeGiaoNhanKetQua":
                    var uc12 = new ucMauXetNghiem_SoGiaoNhanKQ();
                    uc12.getCondit += new ucMauXetNghiem_SoGiaoNhanKQ.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc12, tabNew);
                    allowAdd = true;
                    break;
                case "nodeImmulite1000":
                    var uc13 = new ucExportImmulite();
                    uc13.getCondit += new ucExportImmulite.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc13, tabNew);
                    allowAdd = true;
                    break;
                case "nodeAutoDelfia_double":
                    var uc14 = new ucExportAutoDelfia();
                    uc14.getCondit += new ucExportAutoDelfia.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc14, tabNew);
                    allowAdd = true;
                    break;
                case "nodeAutoDelfia_Plgf":
                    var uc15 = new ucExportAutoDelfia_PLGF();
                    uc15.getCondit += new ucExportAutoDelfia_PLGF.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc15, tabNew);
                    allowAdd = true;
                    break;
                case "nodeGSP":
                    var uc16 = new ucExportGSP();
                    uc16.getCondit += new ucExportGSP.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc16, tabNew);
                    allowAdd = true;
                    break;
                case "nodeQSight":
                    var uc17 = new ucExportQsight();
                    uc17.getCondit += new ucExportQsight.GetCondit(GetNormalCondit);
                    uc17.AddColumnResult();
                    AddUserControlToTab(uc17, tabNew);
                    allowAdd = true;
                    break;
                //nodeQSight
                //nodeGSP
                //nodeAutoDelfia_Plgf
                //case "nodeGiaoNhanKetQuaXN":
                //    var uc12 = new ucMauXetNghiem_SoTuChoiMau();
                //    uc12.getCondit += new ucMauXetNghiem_SoTuChoiMau.GetCondit(GetNormalCondit);
                //    AddUserControlToTab(uc12, tabNew);
                //    allowAdd = true;
                //    break;

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
            var mayXetNghiem = analyzer.Data_h_mayxetnghiem();

            DataTable dt = mayXetNghiem.Clone();
            dt.Columns["IDMay"].DataType = typeof(string);
            dt.Load(mayXetNghiem.CreateDataReader(), LoadOption.OverwriteChanges);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (!string.IsNullOrEmpty(dr["moduleid"].ToString()))
            //        dr["IDMay"] = string.Format("{0}_{1}", dr["IDMay"].ToString(), dr["moduleid"].ToString());
            //}
            ucMayXetNghiem.DataSource = dt;
            ucMayXetNghiem.DisplayMember = "tenmay2";
            ucMayXetNghiem.ValueMember = "IDMay";
            ucMayXetNghiem.IsCheckedAll = true;
        }
        private void Load_KhuVuc()
        {
            var data = sysConfig.Data_dm_khuvuc(string.Empty);
            
        }
        private void Load_Donvi(string maBophan = "")
        {
            sysConfig.GetLocation(cboDonvi, "MaKhoaPhong", "MaKhoaPhong", "MaKhoaPhong,TenKhoaPhong", "100,250", null, 1,
                string.Empty, maBophan);
        }
        private void Load_ChiDinhCLS()
        {
            var data = sysConfig.Data_dm_xetnghiem(string.Join(",", CommonAppVarsAndFunctions.NhomClsXetNghiem ?? new string[1] { "---NONE---" }), !CommonAppVarsAndFunctions.IsAdmin, string.Empty);
            ucDSXetNghiem.DataSource = data;
            ucDSXetNghiem.ValueMember = "MaXn";
            ucDSXetNghiem.DisplayMember = "TenXN";
            ucDSXetNghiem.IsCheckedAll = true;

            var data2 = sysConfig.Data_dm_xetnghiem_profile(string.Empty);
            ucProfile.DataSource = data2;
            ucProfile.ValueMember = "ProfileID";
            ucProfile.DisplayMember = "ProfileName";
            ucProfile.IsCheckedAll = true;

            // Bộ phận xét nghiệm
            cboBoPhanXN.DataSource = sysConfig.Data_dm_xetnghiem_bophan(string.Empty);
            cboBoPhanXN.ValueMember = "MaBoPhan";
            cboBoPhanXN.DisplayMember = "MaBoPhan";
            cboBoPhanXN.ColumnNames = "MaBoPhan,TenBoPhan";
            cboBoPhanXN.ColumnWidths = "50,250";
            cboBoPhanXN.SelectedIndex = -1;
        }
        private void cboNhomCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_ChiDinhCLS();
        }       
        private void cboBoPhanXN_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboKhuDieuTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void cboDonvi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtGhiChu);
        }

        private void chkChiCoKetQua_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChiCoKetQua.Checked)
                chkNotresult.Checked = false;
        }

        private void chkNotresult_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotresult.Checked)
                chkChiCoKetQua.Checked = false;
        }

        private void cboKhuDieuTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhuDieuTri.SelectedValue != null)
            {
                Load_Donvi(cboKhuDieuTri.SelectedValue.ToString());
            }
            else
            {
                Load_Donvi();
            }
        }
    }
}
