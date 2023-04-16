using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Model;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonDichVu : FrmTemplate
    {
        public FrmChonDichVu()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public BENHNHAN_TIEPNHAN objBenhnhanTiepnhan;
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly ITestResultService testService = new TestResultService();
        private C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        private C_Patient_SieuAm p_sieuam = new C_Patient_SieuAm();
        private C_Patient_XQuang p_xquang = new C_Patient_XQuang();
        private C_Patient_NoiSoi p_noisoi = new C_Patient_NoiSoi();
        private C_Patient_KhamBenh p_khambenh = new C_Patient_KhamBenh();
        private C_Patient_DichVu_Khac p_dvkhac = new C_Patient_DichVu_Khac();
        private THUPHI_THUOC_DAL thuphiThuocDAL = new THUPHI_THUOC_DAL();

        private int kieuNhapChiDinh = 1;
        /// <summary>
        /// Kiểu nhập chỉ định 1: Chọn trên lưới dạng cột - 2: Chọn trên danh sách dạng cây
        /// </summary>
        public int KieuNhapChiDinh
        {
            get
            {
                return kieuNhapChiDinh;
            }

            set
            {
                kieuNhapChiDinh = value;
                pnMainInput_WithListView.Visible = (kieuNhapChiDinh == 1);
                pnMainInput_WithTreeView.Visible = (kieuNhapChiDinh == 2);
                this.WindowState = FormWindowState.Normal;
            }
        }
        public string MaLoaiDichVu { get; set; }
        public string MaMhomDichVu { get; set; }
        public int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }
        public void ListViewItem_SetSpacing(ListView listview, short leftPadding, short topPadding)
        {
            const int LVM_FIRST = 0x1000;
            const int LVM_SETICONSPACING = LVM_FIRST + 53;
            SendMessage(listview.Handle, LVM_SETICONSPACING, IntPtr.Zero, (IntPtr)MakeLong(leftPadding, topPadding));
        }
        private void FrmChonDichVu_Load(object sender, EventArgs e)
        {
            Load_Config();
        }
        private void Load_Config()
        {
            string conditLoaiDichVu = string.Format("and EnumID in ({0}) and EnumID not in ({1})", CommonAppVarsAndFunctions.ListEnumLoaiDichVu(), string.Format("{0},{1}", (int)ServiceType.TiepNhan, (int)ServiceType.ThuNgan)); 
            if (kieuNhapChiDinh == (int)EnumKieuNhapChiDinh.ListViewInput)
            {
                var dataDMPhaLoaiDichVu = sysConfig.GetSubclinical(conditLoaiDichVu);
                foreach (DataRow dr in dataDMPhaLoaiDichVu.Rows)
                {
                    GroupControl grp = new GroupControl();

                    grp.Text = dr["TenPhanLoai"].ToString();
                    grp.Name = string.Format("grp{0}", dr["MaPhanLoai"].ToString());
                    grp.AppearanceCaption.FontStyleDelta = FontStyle.Bold;
                    AddGroupToGroupBox(grp, dr["MaPhanLoai"].ToString());
                    pnItemList_WithListView.Controls.Add(grp);
                    grp.Dock = DockStyle.Top;
                    grp.BringToFront();
                    grp.AutoSize = true;
                }
            }
            else if (kieuNhapChiDinh == (int)EnumKieuNhapChiDinh.TreeViewInput)
            {
                cboLoaiDichVu.SelectedIndexChanged -= cboLoaiDichVu_SelectedIndexChanged;
                sysConfig.GetSubclinical(cboLoaiDichVu, conditLoaiDichVu);
                cboLoaiDichVu.SelectedIndexChanged += cboLoaiDichVu_SelectedIndexChanged;
                if (MaLoaiDichVu != null)
                    cboLoaiDichVu.SelectedValue = MaLoaiDichVu;
            }
        }
        private bool AddGroupToGroupBox(GroupControl grp, string maloaiDichvu)
        {
            bool haveAdd = false;
            //get category
            var dataCategory = sysConfig.Load_Nhom_TheoDVCLS(maloaiDichvu, string.Empty);
            if (dataCategory.Rows.Count > 0)
            {
                ListView lst = new ListView();
                int totalAddCount = 0;
                foreach (DataRow dr in dataCategory.Rows)
                {
                    if (!maloaiDichvu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase) || totalAddCount == 0)
                    {
                        lst = new ListView();
                        lst.LargeImageList = imageList1;
                        lst.SmallImageList = imageList1;
                        lst.CheckBoxes = true;
                        lst.Columns.Add("Id", 300, HorizontalAlignment.Left);

                        lst.Font = new Font("Arial", 10, FontStyle.Bold);
                        lst.Name = string.Format("lst{0}_{1}", maloaiDichvu, dr["MaNhomDichVu"].ToString());
                    }
                    else if(maloaiDichvu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        grp.Controls.Clear();
                    }
                    haveAdd = SetItemToListView(lst, maloaiDichvu, dr["MaNhomDichVu"].ToString(), false);
                    if (haveAdd || totalAddCount >0)
                    {
                        totalAddCount++;
                        lst.MultiSelect = false;
                        lst.ItemChecked += lstSelectedItem_ItemChecked;


                        ListViewItem_SetSpacing(lst, 64 + 32, 110 + 16);

                        grp.Controls.Add(lst);
                        
                        if (lst.Items.Count < 8)
                        {
                            lst.Height = lst.Items.Count * 22;
                            grp.Height += lst.Height;
                        }
                        else
                        {
                            lst.Height = 140;
                            grp.Height += 150;
                        }
                        lst.Dock = DockStyle.Top;

                        if (!maloaiDichvu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            totalAddCount = -1;
                            Label lbl = new Label();
                            lbl.AutoSize = false;
                            lbl.BackColor = Color.WhiteSmoke;
                            lbl.Text = dr["TenNhomDichVu"].ToString().ToUpper();
                            lbl.Font = new Font(lbl.Font.FontFamily, 11, FontStyle.Bold);
                            lbl.TextAlign = ContentAlignment.MiddleLeft;
                            lbl.ForeColor = Color.Blue;
                            grp.Controls.Add(lbl);
                            lbl.Dock = DockStyle.Top;
                            lbl.BringToFront();
                            grp.Height += lbl.Height;
                        }

                        
                        lst.BringToFront();
                        lst.View = View.List;
                    }
                }
                if (maloaiDichvu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    lst = new ListView();
                    lst.LargeImageList = imageList1;
                    lst.SmallImageList = imageList1;
                    lst.CheckBoxes = true;
                    lst.Columns.Add("Id", 300, HorizontalAlignment.Left);
                    lst.Font = new Font("Arial", 10, FontStyle.Bold);
                    lst.Name = string.Format("lst{0}_{1}", maloaiDichvu, "Profile");
                    haveAdd = SetItemToListView(lst, maloaiDichvu, string.Empty, true);
                    if (haveAdd)
                    {


     

                        lst.MultiSelect = false;
                        lst.ItemChecked += lstSelectedItem_ItemChecked;

                        ListViewItem_SetSpacing(lst, 64 + 32, 110 + 16);

                        grp.Controls.Add(lst);
                        if (lst.Items.Count < 8)
                        {
                            lst.Height = lst.Items.Count * 22;
                            grp.Height += lst.Height;
                        }
                        else
                        {
                            lst.Height = 140;
                            grp.Height += 150;
                        }
                        lst.Dock = DockStyle.Top;
                        lst.SendToBack();
                        lst.View = View.List;

                        Label lbl = new Label();
                        lbl.AutoSize = false;
                        lbl.BackColor = Color.WhiteSmoke;
                        lbl.Text = "Profile".ToUpper();
                        lbl.Font = new Font(lbl.Font.FontFamily, 11, FontStyle.Bold);
                        lbl.TextAlign = ContentAlignment.MiddleLeft;
                        lbl.ForeColor = Color.Blue;
                        grp.Controls.Add(lbl);
                        lbl.Dock = DockStyle.Top;
                        lbl.SendToBack();
                        grp.Height += lbl.Height;

                    }
                }
            }
            return haveAdd;
        }
        private bool SetItemToListView(ListView lst, string maloaiDichvu, string maNhomDichvu, bool isLodProfile)
        {
            bool haveAdd = false;
            DataTable data = new DataTable();
            if (isLodProfile)
            {
                data = sysConfig.Data_dm_xetnghiem_profile(string.Empty);
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        ListViewItem item = new ListViewItem(new string[] { string.Format("[+] {0}", dr["ProfileName"].ToString()) });
                        item.Name = string.Format("item|_|{0}|_|{1}|_|{2}", dr["ProfileID"].ToString()
                            , ProfileTestContant.ProfileChar, maloaiDichvu);
                        item.ImageIndex = 3;
                        
                        lst.Items.Add(item);
                    }

                    haveAdd = true;
                }
                else
                    haveAdd = false;
            }
            else
            {
                data = Load_ChiDinhDichVu(maloaiDichvu, maNhomDichvu);
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        ListViewItem item = new ListViewItem(new string[] { string.Format("[-] {0}", dr["TenDichVu"].ToString()) });
                        item.Name = string.Format("item|_|{0}|_|{1}|_|{2}", dr["MaDichVu"].ToString()
                            , (string.IsNullOrEmpty(dr["IsProfile"].ToString()) ? ProfileTestContant.TestChar : dr["IsProfile"].ToString())
                            , maloaiDichvu);
                        if(maloaiDichvu.Equals(ServiceType.ClsXetNghiem.ToString()))
                            item.ImageIndex = 3;
                        else if (maloaiDichvu.Equals(ServiceType.ClsSieuAm.ToString()))
                            item.ImageIndex = 4;
                        lst.Items.Add(item);
                    }
                    haveAdd = true;
                }
                else
                    haveAdd = false;
            }


            return haveAdd;
        }
        private void cboLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_NhomDichVu();
        }
        private void Load_NhomDichVu()
        {
            if (cboLoaiDichVu.SelectedIndex != -1)
            {
                cboNhomDichVu.SelectedValueChanged -= cboNhomDichVu_SelectedIndexChanged;
                cboNhomDichVu.DataBindings.Clear();
                cboNhomDichVu.DataSource = new DataTable();
                //if (cboLoaiDichVu.SelectedValue.ToString()
                //    .Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
                //{
                //    txtSoLuong.Enabled = true;
                //}
                //else
                //{
                //    txtSoLuong.Enabled = false;
                //    lblDVT.Text = string.Empty;
                //}
                string bophanXN = string.Empty;

              var data =  sysConfig.Load_Nhom_TheoDVCLS(cboLoaiDichVu.SelectedValue.ToString(), !string.IsNullOrEmpty(bophanXN) ? string.Format(" and MaBoPhan ='{0}'", bophanXN) : "");
                ControlExtension.BindDataToCobobox(data, ref cboNhomDichVu, "MaNhomDichVu", "TenNhomDichVu", "MaNhomDichVu,TenNhomDichVu", "50, 250" );
                cboNhomDichVu.SelectedValueChanged += cboNhomDichVu_SelectedIndexChanged;
                if (MaMhomDichVu != null)
                    cboNhomDichVu.SelectedValue = MaMhomDichVu;
                SetDataToTreeView();
            }
        }
        private void cboNhomDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDataToTreeView();
        }
        private DataTable Load_ChiDinhDichVu(string loaiDichVuCLS, string nhomDichVuCLS)
        {
            if (!string.IsNullOrEmpty(loaiDichVuCLS))
            {
                string doiTuongDv = (objBenhnhanTiepnhan != null ? (objBenhnhanTiepnhan.Doituongdichvu == null ? string.Empty : objBenhnhanTiepnhan.Doituongdichvu) : string.Empty);
                string sex = (objBenhnhanTiepnhan != null ? (objBenhnhanTiepnhan.Gioitinh == null ? string.Empty : objBenhnhanTiepnhan.Gioitinh) : string.Empty);
                string dv = loaiDichVuCLS;
                string nhom = nhomDichVuCLS;

                string boPhan = string.Empty;

                return sysConfig.Load_ChiDinhCLS(null, dv, nhom, sex, doiTuongDv, !string.IsNullOrEmpty(boPhan) ? string.Format(" and mabophan = '{0}'", boPhan) : "");
            }
            else
                return new DataTable();
        }
        private void SetDataToTreeView()
        {
            treItems.Nodes.Clear();
            if (cboLoaiDichVu.SelectedIndex > -1)
            {
                DataTable data = Load_ChiDinhDichVu(cboLoaiDichVu.SelectedValue.ToString(), (cboNhomDichVu.SelectedIndex > -1 ? cboNhomDichVu.SelectedValue.ToString() : string.Empty));

                DataTable dataCategory = data.DefaultView.ToTable(true, new string[] { "MaNhomDichVu", "TenNhomDichVu" });
                foreach (DataRow drCate in dataCategory.Rows)
                {
                    TreeNode parentNode = new TreeNode();
                    parentNode.ImageIndex = 0;
                    parentNode.Name = string.Format("cate_{0}", drCate["MaNhomDichVu"].ToString());
                    parentNode.Text = drCate["TenNhomDichVu"].ToString().ToUpper();
                    var categorytest = WorkingServices.SearchResult_OnDatatable(data, "MaNhomDichVu = '" + drCate["MaNhomDichVu"].ToString() + "'");
                    foreach (DataRow dr in categorytest.Rows)
                    {
                        AddNodeToTree(parentNode, string.Format("item|_|{0}|_|{1}|_|{2}", dr["MaDichVu"].ToString(), (string.IsNullOrEmpty(dr["IsProfile"].ToString()) ? ProfileTestContant.TestChar : dr["IsProfile"].ToString()), cboLoaiDichVu.SelectedValue.ToString())
                            , dr["TenDichVu"].ToString().ToUpper());
                    }
                    treItems.Nodes.Add(parentNode);
                }
                treItems.CheckBoxes = true;
                treItems.ExpandAll();
            }
        }
        private void AddNodeToTree(TreeNode parentNode, string nodeName, string nodeText)
        {
            TreeNode node = new TreeNode();
            node.Name = nodeName;
            node.Text = nodeText;
            parentNode.Nodes.Add(node);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddTest_Click(object sender, EventArgs e)
        {
            CustomMessageBox.ShowAlert("Đang thêm chỉ định.");
            Check_InsertItem(lstSelectedItem);
            CustomMessageBox.CloseAlert();
            if (lstSelectedItem.Items.Count > 0)
            {
                this.Close();
            }
            else
                CustomMessageBox.MSG_Information_OK("Không có chỉ định được chọn!");
        }
        private void Check_InsertItem(TreeNode node, ref int HaveInsertCount)
        {
            foreach (TreeNode item in node.Nodes)
            {
                if (item.Checked)
                {
                    InsertItem(item.Name);
                    item.Checked = false;
                    HaveInsertCount++;
                }
                Check_InsertItem(item, ref HaveInsertCount);
            }
        }
        private void Check_InsertItem(ListView list)
        {
            if (list.Items.Count > 0)
            {
                foreach (ListViewItem item in list.Items)
                {
                    InsertItem(item.Name);
                }
            }
        }
        private void InsertItem(string itemName)
        {
            var name = itemName.Split(new string[] { "|_|" }, StringSplitOptions.None);
            //1: madichvu
            //2: profile
            //3: maloaidichvu
            var madichvu = name[1];
            var profileChar = name[2];
            ServiceType dv = (ServiceType)Enum.Parse(typeof(ServiceType), name[3].Trim());
            if (dv == ServiceType.ClsXetNghiem)
            {
                InsertDichVuXn(madichvu, profileChar);
            }
            //else if (dv == ServiceType.ClsXNViSinh)
            //{
            //    InsertDichVuXnViSinh();
            //}
            else if (dv == ServiceType.ClsSieuAm)
            {
                InsertDichVuSieuAm(madichvu);
            }
            else if (dv == ServiceType.ClsXQuang)
            {
                InsertDicVuXQuang(madichvu);
            }
            else if (dv == ServiceType.ClsNoiSoi)
            {
                InsertDichVuNoiSoi(madichvu);
            }
            else if (dv == ServiceType.KhamBenh)
            {
                InsertDichVuKhamBenh(madichvu);
            }
            else if (dv == ServiceType.DvKhac)
            {
                InsertDichVuKhac(madichvu);
            }
            else if (dv == ServiceType.Duoc)
            {
                InsertDichVuThuoc(madichvu);
            }
        }
        private void InsertDichVuXn(string maxn, string profileChar)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                string _sampleID = objBenhnhanTiepnhan.Matiepnhan;
                string _maxn = maxn;
                bool profile = (profileChar == ProfileTestContant.ProfileChar);
                if (testService.CheckTonTaiChiDinh(_sampleID, _maxn, profile))
                {
                    CustomMessageBox.CloseAlert();
                    CustomMessageBox.MSG_Information_OK(string.Format("Chỉ định [{0}] đã được nhập", _maxn));
                    return;
                }

                var objChiDinh = new Lab.BusinessService.Models.XetNghiemInfo();
                objChiDinh.maxn = _maxn;
                objChiDinh.xetnghiemProfile = profile;
                objChiDinh.Dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                objChiDinh.Khuvucnhanid = CommonAppVarsAndFunctions.PCWorkPlace;
                objChiDinh.Khuvucthuchienid = CommonAppVarsAndFunctions.PCWorkPlace;
                testService.InsertTest(objBenhnhanTiepnhan, objChiDinh);
            }
        }
        private void InsertDichVuSieuAm(string maSomau)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_sieuam.Insert_ChiDinhSieuAm(objBenhnhanTiepnhan.Matiepnhan,
                    maSomau, objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDichVuNoiSoi(string maSomau)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_noisoi.Insert_ChiDinhNoiSoi(objBenhnhanTiepnhan.Matiepnhan,
                    maSomau, objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDicVuXQuang(string maVungChup)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_xquang.Insert_ChiDinhXQuang(objBenhnhanTiepnhan.Matiepnhan,
                    maVungChup.Trim(), objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDichVuKhamBenh(string maDichVu)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_khambenh.Insert_ChiDinh_DichVu(objBenhnhanTiepnhan.Matiepnhan,
                    maDichVu.Trim(), objBenhnhanTiepnhan.Doituongdichvu.Trim(), "KB",
                    dongia);
            }
        }
        private void InsertDichVuKhac(string maDichVu)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                float dongia = float.Parse(string.IsNullOrWhiteSpace(txtDonGia.Text) ? "-1" : txtDonGia.Text);
                p_dvkhac.Insert_ChiDinhDVKhac(objBenhnhanTiepnhan.Matiepnhan,
                    maDichVu.Trim(), objBenhnhanTiepnhan.Doituongdichvu.Trim(), dongia);
            }
        }
        private void InsertDichVuThuoc(string maThuoc)
        {
            if (!string.IsNullOrEmpty(objBenhnhanTiepnhan.Doituongdichvu))
            {
                string _DoiTuongDV = objBenhnhanTiepnhan.Doituongdichvu;
                int soluong = int.Parse(txtSoLuong.Text == string.Empty ? "0" : txtSoLuong.Text);
                float dongia = float.Parse(txtDonGia.Text == string.Empty ? "-1" : txtDonGia.Text);
                if (soluong > 0)
                {
                    thuphiThuocDAL.Insert_ThuPhi_Thuoc(maThuoc, objBenhnhanTiepnhan.Matiepnhan, _DoiTuongDV, soluong, dongia, false);
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập số lượng.!");
            }
        }
        private void treItems_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //TreeNode node = (TreeNode)sender;
            //if(node.Name.Substring(0,5).Equals("cate_") && node.Checked)
            //{
            //    node.Checked = false;
            //}
        }
        private void lstSelectedItem_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //ListView lst = (ListView)sender;
            //if (lst.SelectedItems.Count > 0)
            //{
            //    if (lst.SelectedItems[0].BackColor == Color.LightBlue)
            //    {
            //        lst.SelectedItems[0].BackColor = Color.Empty;
            //        lst.SelectedItems[0].ForeColor = Color.Empty;
            //    }
            //    else
            //    {
            //        lst.SelectedItems[0].BackColor = Color.LightBlue;
            //        lst.SelectedItems[0].ForeColor = Color.DarkRed;
            //    }
            //}
        }
        private void lstSelectedItem_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ListView lst = (ListView)sender;
            foreach (ListViewItem itm in lst.Items)
            {
                if (itm.Checked)
                {
                    itm.BackColor = Color.LightBlue;

                }
                else
                    itm.BackColor = Color.Empty;

                Check_AddItem(itm, itm.Checked);
            }
            ListViewItem_SetSpacing(lstSelectedItem, 64 + 32, 110 + 16);
        }
        private void Check_AddItem(ListViewItem item, bool isAdd)
        {
            foreach (ListViewItem itemV in lstSelectedItem.Items)
            {
                if (item.Name.Equals(itemV.Name))
                {
                    lstSelectedItem.Items.Remove(itemV);
                    break;
                }
            }
            if (isAdd)
            {
                var addItm = (ListViewItem)item.Clone();
                addItm.Name = item.Name;
                addItm.BackColor = Color.Empty;
                lstSelectedItem.Items.Add(addItm);
                lstSelectedItem.Sort();
            }
        }
        private void btnCLose_TreeView_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnThemChiDInh_Treeview_Click(object sender, EventArgs e)
        {
            CustomMessageBox.ShowAlert("Đang thêm chỉ định.");
            int HaveInsertCount = 0;
            foreach (TreeNode item in treItems.Nodes)
            {
                Check_InsertItem(item, ref HaveInsertCount);
            }
            CustomMessageBox.CloseAlert();
            if (HaveInsertCount > 0)
                this.Close();
            else
                CustomMessageBox.MSG_Information_OK("Không có chỉ định được chọn!");
        }
        private void FrmChonDichVu_Shown(object sender, EventArgs e)
        {
            if (kieuNhapChiDinh == (int)EnumKieuNhapChiDinh.TreeViewInput)
                cboLoaiDichVu.Focus();
        }
    }
}
