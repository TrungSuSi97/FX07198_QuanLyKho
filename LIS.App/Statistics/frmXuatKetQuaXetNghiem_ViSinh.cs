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
using TPH.LIS.User.Enum;
using TPH.Controls;
using TPH.LIS.App.AppCode;

namespace TPH.LIS.App.ThongKe
{
    public partial class frmXuatKetQuaXetNghiem_ViSinh : FrmTemplate
    {
        public frmXuatKetQuaXetNghiem_ViSinh()
        {
            InitializeComponent();
            treLoaiThongKe.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IUserManagementService userConfig = new UserManagementService();
        private readonly IAnalyzerConfigService analyzer = new AnalyzerConfigService();
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
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
            Load_Loai();
            Load_LoaiMau();
        }
        private void Load_Loai()
        {
            var dt_vikhuan = _bacteriumAntibioticService.Get_dm_xetnghiem_vikhuan_loai();
            ucLoai.DataSource = dt_vikhuan;
            ucLoai.ValueMember = "MaPhanLoai";
            ucLoai.DisplayMember = "TenPL";
        }
        private void Load_LoaiMau()
        {
            var dt_loaimau = sysConfig.Data_dm_xetnghiem_loaimau(string.Empty,(ServiceType.ClsXNViSinh).ToString());
            ucLoaiMau.DataSource = dt_loaimau;
            ucLoaiMau.ValueMember = "MaLoaiMau";
            ucLoaiMau.DisplayMember = "TenLoaiMau";
        }
        private ExportCondition GetNormalCondit()
        {
            var statisticCondit = new ExportCondition();
            statisticCondit.ServerName = CommonAppVarsAndFunctions.sysConfig.DatabaseThongKe;
            statisticCondit.XuatTheoTen = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXuatCotTheoTen;
            statisticCondit.ThoiGianXuat = (radTGInKQDauTien.Checked ? EnumThoiGianXuat.ThoiGianInKetQuaDauTien : EnumThoiGianXuat.ThoiGianNhapBenhNhan);
            statisticCondit.TuNgay = dtpDateFrom.Value;
            statisticCondit.DenNgay = dtpDateTo.Value;
            statisticCondit.BoPhanXetNghiem = new System.Collections.Generic.List<string> { cboBoPhanXN.SelectedIndex > -1 ? cboBoPhanXN.SelectedValue.ToString() : string.Empty };
            statisticCondit.NhomXetNghiem = new System.Collections.Generic.List<string> { cboNhomCLS.SelectedIndex > -1 ? cboNhomCLS.SelectedValue.ToString() : string.Empty };
            statisticCondit.KhuVuc = new System.Collections.Generic.List<string> { cboKhuDieuTri.SelectedIndex > -1 ? cboKhuDieuTri.SelectedValue.ToString() : string.Empty };
            statisticCondit.KhoaPhong = new System.Collections.Generic.List<string> { cboDonvi.SelectedIndex > -1 ? cboDonvi.SelectedValue.ToString() : string.Empty };
            statisticCondit.BSChiDinh = new System.Collections.Generic.List<string> { cboBSChiDinh.SelectedIndex > -1 ? cboBSChiDinh.SelectedValue.ToString() : string.Empty };
            statisticCondit.DoiTuong = ucDoiTuong.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucDoiTuong.ListCheckedItem;
            statisticCondit.NhanVienXacNhanKetQua = new System.Collections.Generic.List<string> { cboNhanVienXacNhan.SelectedIndex > -1 ? cboNhanVienXacNhan.SelectedValue.ToString() : string.Empty };
            statisticCondit.KetQua = txtKetQua.Text;
            statisticCondit.GhiChu = txtGhiChu.Text;
            statisticCondit.XetNghiem = ucDSXetNghiem.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucDSXetNghiem.ListCheckedItem;
            statisticCondit.ProfileXetNghiem = ucProfile.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucProfile.ListCheckedItem;
            statisticCondit.MayXetNghiem = ucMayXetNghiem.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucMayXetNghiem.ListCheckedItem;
            statisticCondit.MaViKhuan = ucLoai.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucLoai.ListCheckedItem;
            statisticCondit.MaLoaiMau = ucLoaiMau.IsCheckedAll ? new System.Collections.Generic.List<string>() : ucLoaiMau.ListCheckedItem;
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
                case "nodWHONet":
                    var uc = new ucKetQua_KetQuaViSinh_WHONet();
                    uc.getCondit += new ucKetQua_KetQuaViSinh_WHONet.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc, tabNew);
                    allowAdd = true;
                    break;
                case "nodBYT":
                    var uc2 = new ucKetQua_KetQuaViSinh_BYT();
                    uc2.getCondit += new ucKetQua_KetQuaViSinh_BYT.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc2, tabNew);
                    allowAdd = true;
                    break;
                case "nodXuatThongTinBenhPham":
                    var uc3 = new ucKetQua_ViSinh_ThongTinMau();
                    uc3.getCondit += new ucKetQua_ViSinh_ThongTinMau.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc3, tabNew);
                    allowAdd = true;
                    break;
                case "nodBCTH":
                    var uc4 = new ucKetQua_KetQuaViSinh_BCTH();
                    uc4.getCondit += new ucKetQua_KetQuaViSinh_BCTH.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc4, tabNew);
                    allowAdd = true;
                    break;
                case "nodeXuatPhieuTienTrinhViSinh":
                    var uc5 = new ucKetQua_ViSinh_PhieuTienTrinh();
                    uc5.getCondit += new ucKetQua_ViSinh_PhieuTienTrinh.GetCondit(GetNormalCondit);
                    AddUserControlToTab(uc5, tabNew);
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
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    data = WorkingServices.SearchResult_OnDatatable(data, string.Format("{0} =  {1} "
                        , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaixetnghiem), (int)Common.TestType.EnumTestType.ViSinhNuoiCay));
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
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
        private void cboBoPhan_SelectedValueChanged(object sender, EventArgs e)
        {
           
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
