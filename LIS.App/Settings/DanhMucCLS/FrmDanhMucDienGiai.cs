using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmDanhMucDienGiai : Form
    {
        public FrmDanhMucDienGiai()
        {
            InitializeComponent();
        }
        private Color EditColor = Color.LightGreen;
        private Color AddNewColor = Color.LightPink;

        public string GenBatThuong
        {
            get;
            set;
        }
        public string MaXnChiDinh
        {
            get;
            set;
        }
        public int idChon = 0;
        public bool IsConFigMode
        {
            set
            {
                btnChon.Visible = !value;
                btnThem.Visible = value;
                btnXoa.Visible = value;
                btnSua.Visible = value;
                btnLuu.Visible = value;
            }
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        
        private void FrmDanhMucDienGiai_Load(object sender, EventArgs e)
        {
            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSach);
            ControlExtension.SetLowerCaseForXGridColumns(gvGenChild);
            ControlExtension.SetLowerCaseForXGridColumns(gvTestcodeMain);
            Load_Danhmuc();
            Load_KhaiBao();
            SetThongTinDienGiai();
            //gvGenChild.FocusedColumnChanged += GvGenChild_FocusedColumnChanged;
            //gvGenChild.FocusedRowChanged += GvGenChild_FocusedRowChanged;
            gvGenChild.RowCellClick += GvGenChild_RowCellClick;
      
        }

        private void GvGenChild_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView view = (GridView)sender;
            if (view.IsFocusedView)
            {
                var maxnCon = view.GetFocusedRowCellValue(colGen_MaGen);
                Load_KhaiBao(maxnCon);
                SetThongTinDienGiai();
            }
        }

        private void GvGenChild_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = (GridView)sender;
            if (view.IsFocusedView)
            {
                var maxnCon = view.GetFocusedRowCellValue(colGen_MaGen);
                Load_KhaiBao(maxnCon);
                SetThongTinDienGiai();
            }
        }

        private void GvGenChild_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GridView view = (GridView)sender;
            if (view.IsFocusedView)
            {
                var maxnCon = view.GetFocusedRowCellValue(colGen_MaGen);
                Load_KhaiBao(maxnCon);
                SetThongTinDienGiai();
            }
        }

        private void Load_Danhmuc()
        {
            //gvTestcodeMain.FocusedRowChanged -= GvTestcodeMain_FocusedRowChanged;
            //gvTestcodeMain.FocusedColumnChanged -= GvTestcodeMain_FocusedColumnChanged;
            var dataSet11 = sysConfig.DanhMuc_Gen_ChaCon();
            if (dataSet11 != null)
            {
                if (dataSet11.Tables.Count > 0)
                {
                    foreach (DataTable data in dataSet11.Tables)
                    {
                        WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                    }
                    if (!string.IsNullOrEmpty(MaXnChiDinh))
                    {
                        var table1 = dataSet11.Tables[0];
                        var table2 = WorkingServices.SearchResult_OnDatatable(dataSet11.Tables[1], string.Format("{0} = '{1}'", colDMXN_MaXetNghiem.FieldName, MaXnChiDinh));
                        var filterTable = WorkingServices.SearchResult_OnDatatable(dataSet11.Tables[0], string.Format("{0} = '{1}'", colDMXN_MaXetNghiem.FieldName, MaXnChiDinh));
                        dataSet11 = new DataSet();
                        filterTable.TableName = "TableMain";
                        table2.TableName = "TableSub";
                        dataSet11.Tables.Clear();
                        dataSet11.Tables.Add(filterTable);
                        dataSet11.Tables.Add(table2);
                    }
                }
            }
            DataColumn keyColumn = dataSet11.Tables[0].Columns["maxn"];
            DataColumn foreignKeyColumn = dataSet11.Tables[1].Columns["maxn"];
            dataSet11.Relations.Add("Gen", keyColumn, foreignKeyColumn, false);
            gcTestCode.DataSource = dataSet11.Tables[0];
            //gvTestcodeMain.FocusedRowChanged += GvTestcodeMain_FocusedRowChanged;
            //gvTestcodeMain.FocusedColumnChanged += GvTestcodeMain_FocusedColumnChanged;
        }

        private void GvTestcodeMain_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_KhaiBao();
            SetThongTinDienGiai();
        }

        private void GvTestcodeMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_KhaiBao();
            SetThongTinDienGiai();
        }

        private void Load_KhaiBao(object genValue = null)
        {
            if (genValue != null)
            {
                Load_KhaiBao_Gen(genValue.ToString());
            }
            else
            {
                gcDanhSach.DataSource = null;
                gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;
                if (gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem) != null)
                {
                    var data = sysConfig.Data_dm_diengiaketquagen_theoxetnghiem(gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem).ToString());
                    if (!string.IsNullOrEmpty(GenBatThuong))
                    {
                        if (data != null)
                        {
                            string filterString = string.Empty;
                            var arr = GenBatThuong.Split(',');
                            if (arr.Length == 1)
                            {
                                filterString = string.Format("MaXnThamGia = '{0}'", arr[0].ToString());
                            }
                            else
                            {
                                foreach (string item in arr)
                                {
                                    filterString += (string.IsNullOrEmpty(filterString) ? "" : " and ");
                                    filterString += string.Format("GhiChuDienGiai like '%{0}%'", arr[0].ToString());
                                }
                                filterString = string.Format("MaXnThamGia is null or MaXnThamGia = '' or ({0})", filterString);
                            }
                            data = WorkingServices.SearchResult_OnDatatable(data, filterString);
                        }
                    }
                    gcDanhSach.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
                gvDanhSach.ExpandAllGroups();
                gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
            }
        }
        private void Load_KhaiBao_Gen(string genValue)
        {
            gcDanhSach.DataSource = null;
            gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;
            if (!string.IsNullOrEmpty(genValue))
            {
                var data = sysConfig.Data_dm_diengiaketquagen_theoxetnghiem(gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem).ToString());
                data = WorkingServices.SearchResult_OnDatatable(data, string.Format("MaXnThamGia = '{0}'", genValue.ToString()));
                gcDanhSach.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gvDanhSach.ExpandAllGroups();
            gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
        }
        private void GvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            SetThongTinDienGiai();
        }

        private void GvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetThongTinDienGiai();
        }

        private void InsertDienGiai()
        {
            if (gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem) != null)
            {
                var maxn = gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem).ToString();
                GridView view = (GridView)gvTestcodeMain.GetDetailView(gvTestcodeMain.FocusedRowHandle, gvTestcodeMain.GetRelationIndex(gvTestcodeMain.FocusedRowHandle, "Gen"));
                var maxnCon = (view == null ? String.Empty : WorkingServices.ObjecToString(view.GetFocusedRowCellValue(colGen_MaGen)));
                if (!string.IsNullOrEmpty(txtMota.Text))
                {
                    var obj = new DM_DIENGIAKETQUAGEN()
                    {
                        Maxn = maxn,
                        Ghichudiengiai = txtMota.Text,
                        Loai = (radKetQuaBatThuong.Checked ? 1 : 0),
                        Giaithich = richGiaiThich.RtfText,
                        Tuvan = richTuVan.RtfText,
                        Phuongphap = richPhuongPhap.RtfText,
                        Gioihan = richGioiHan.RtfText,
                        Tailieuthamkhao = richTaiLieu.RtfText,
                        Nguoitao = CommonAppVarsAndFunctions.UserID,
                        Maxnthamgia = maxnCon,
                        Hinhdiengiai1 = pictureBox1.Image,
                        Hinhdiengiai2 = pictureBox2.Image

                };
                    if (sysConfig.Insert_dm_diengiaketquagen(obj) > -1)
                    {
                        Load_KhaiBao();
                        gvDanhSach.MoveLast();
                        SetThongTinDienGiai();
                        Lock_Unclock(false);
                    }
                }
            }
        }

        private void UpdateDienGiai()
        {
            if (gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem) != null)
            {
                var maxn = gvTestcodeMain.GetFocusedRowCellValue(colDMXN_MaXetNghiem).ToString();
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật diễn giải?"))
                    {
                        var obj = sysConfig.Get_Info_dm_diengiaketquagen(int.Parse(gvDanhSach.GetFocusedRowCellValue(colDSCauHinh_Id).ToString()));

                        obj.Ghichudiengiai = txtMota.Text;
                        obj.Loai = (radKetQuaBatThuong.Checked ? 1 : 0);
                        obj.Giaithich = richGiaiThich.RtfText;
                        obj.Tuvan = richTuVan.RtfText;
                        obj.Phuongphap = richPhuongPhap.RtfText;
                        obj.Gioihan = richGioiHan.RtfText;
                        obj.Tailieuthamkhao = richTaiLieu.RtfText;
                        obj.Nguoisua = CommonAppVarsAndFunctions.UserID;
                        obj.Hinhdiengiai1 = pictureBox1.Image;
                        obj.Hinhdiengiai2 = pictureBox2.Image;
                        if (sysConfig.Update_dm_diengiaketquagen(obj) > -1)
                        {
                            Load_KhaiBao();
                            gvDanhSach.FocusedRowHandle = gvDanhSach.LocateByValue("id", obj.Id);
                            SetThongTinDienGiai();
                            Lock_Unclock(false);
                        }
                    }
                }
            }
        }

        private void ClearInfo()
        {
            txtMota.BackColor = Color.White;
            radKetQuaThuong.Checked = true;
            txtMota.Text = String.Empty;
            richGiaiThich.RtfText = String.Empty;
            richTuVan.RtfText = String.Empty;
            richPhuongPhap.RtfText = String.Empty;
            richGioiHan.RtfText = String.Empty;
            richTaiLieu.RtfText = String.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }
        private void Lock_Unclock(bool isLock)
        {
            try
            {
                radKetQuaThuong.Enabled = !isLock;
                txtMota.Enabled = !isLock;
                richGiaiThich.Enabled = !isLock;
                richTuVan.Enabled = !isLock;
                richPhuongPhap.Enabled = !isLock;
                richGioiHan.Enabled = !isLock;
                richTaiLieu.Enabled = !isLock;
                btnEditGiaiThich.Enabled = !isLock;
                btnEditGioiHan.Enabled = !isLock;
                btnEditPhuongPhap.Enabled = !isLock;
                btnEditTaiLieu.Enabled = !isLock;
                btnEditTuVan.Enabled = !isLock;
                btnThemHinh1.Enabled = !isLock;
                btnThemHinh2.Enabled = !isLock;
                btnXoaHinh1.Enabled = !isLock;
                btnXoaHinh2.Enabled = !isLock;
            }
            catch
            { }
        }
        private void SetThongTinDienGiai()
        {
            ClearInfo();
            if (gvDanhSach.FocusedRowHandle >-1)
            {
                var obj = sysConfig.Get_Info_dm_diengiaketquagen(int.Parse(gvDanhSach.GetFocusedRowCellValue(colDSCauHinh_Id).ToString()));
                radKetQuaBatThuong.Checked = obj.Loai == 1;
                txtMota.Text = obj.Ghichudiengiai;
                richGiaiThich.RtfText = obj.Giaithich;
                richTuVan.RtfText = obj.Tuvan;
                richPhuongPhap.RtfText = obj.Phuongphap;
                richGioiHan.RtfText = obj.Gioihan;
                richTaiLieu.RtfText = obj.Tailieuthamkhao;
                pictureBox1.Image = obj.Hinhdiengiai1;
                pictureBox2.Image = obj.Hinhdiengiai2;
                Lock_Unclock(true);
            }
        }
        private void ShowRichEdit(RichEditControl rich)
        {
            var f = new FrmRichEdit();
            f.richEditControl.RtfText = rich.RtfText;
            f.ShowDialog();
            rich.RtfText = f.richEditControl.RtfText;
        }

        private void btnEditGiaiThich_Click(object sender, EventArgs e)
        {
            ShowRichEdit(richGiaiThich);
        }

        private void btnEditTuVan_Click(object sender, EventArgs e)
        {
            ShowRichEdit(richTuVan);
        }

        private void btnEditPhuongPhap_Click(object sender, EventArgs e)
        {
            ShowRichEdit(richPhuongPhap);
        }

        private void btnEditGioiHan_Click(object sender, EventArgs e)
        {
            ShowRichEdit(richGioiHan);
        }

        private void btnEditTaiLieu_Click(object sender, EventArgs e)
        {
            ShowRichEdit(richTaiLieu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearInfo();
            Lock_Unclock(false);
            txtMota.BackColor = AddNewColor;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMota.BackColor.Equals(AddNewColor))
            {
                InsertDienGiai();
            }
            else if (txtMota.BackColor.Equals(EditColor))
                UpdateDienGiai();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Lock_Unclock(false);
            txtMota.BackColor = EditColor;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!txtMota.BackColor.Equals(AddNewColor))
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khai báo diễn giải đang chọn?"))
                    {
                        sysConfig.Delete_dm_diengiaketquagen(int.Parse(gvDanhSach.GetFocusedRowCellValue(colDSCauHinh_Id).ToString()));
                        Load_KhaiBao();
                        SetThongTinDienGiai();
                    }
                }
            }
        }

        private void gvTestcodeMain_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Load_KhaiBao();
            SetThongTinDienGiai();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle >-1)
            {
                idChon = int.Parse(gvDanhSach.GetFocusedRowCellValue(colDSCauHinh_Id).ToString());
                this.Close();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn thông tin diễn giải.");
            }
        }

        private void gvGenChild_ShownEditor(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            if (view.IsFocusedView)
            {
                var maxnCon = view.GetFocusedRowCellValue(colGen_MaGen);
                Load_KhaiBao(maxnCon);
                SetThongTinDienGiai();
            }
        }

        private void btnThemHinh1_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadImage_ToPicturebox(pictureBox1);
        }

        private void btnThemHinh2_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadImage_ToPicturebox(pictureBox2);
        }

        private void btnXoaHinh1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void btnXoaHinh2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }
    }
}
