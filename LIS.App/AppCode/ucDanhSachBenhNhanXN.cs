using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Common;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.Common.Controls;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.Patient.Services;
using TPH.LIS.User.Enum;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Configuration.Models;
using TPH.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using TPH.Language;

namespace TPH.LIS.App.AppCode
{
    public partial class ucDanhSachBenhNhanXN : UserControl
    {
        public ucDanhSachBenhNhanXN()
        {
            InitializeComponent();
            gbDSBenhNhan.Appearance.BackColor = CommonAppColors.ColorMainAppFormColor;
            gbDSBenhNhan.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
            pnSearcBarcode.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        /// <summary>
        /// Sự kiện khi lưới thay đổi cell focus
        /// </summary>
        [Category("Custom")]
        public event EventHandler DataGridview_DsBenhNhan_CellEnter;

        [Category("Custom")]
        public event EventHandler DoiNhomXN;
        /// <summary>
        /// Sự kiện khi lưới thay đổi cell focus
        /// </summary>
        [Category("Custom")]
        public event EventHandler InTheoDanhSach_Click;
        /// <summary>
        /// Sự kiện click button tùy chọn
        /// </summary>
        [Category("Custom")]
        public event EventHandler Button_TuyChon_Click;
        [Category("Custom")]
        public event EventHandler BeforeReload_DSBenhNhan;
        public DataTable ThongTinBNDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return WorkingServices.SearchResult_OnDatatable_NoneSort(dataDSBenhNhan, string.Format("MaTiepNhan = '{0}'", WorkingServices.EscapeLikeValue(MaTiepNhanDangChon)));
                }
                return null;
            }
        }
        public string MaTiepNhanDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return (gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan) ?? string.Empty).ToString();
                }
                return string.Empty;
            }
        }
        public string BarcodeDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return (gvDanhSach.GetFocusedRowCellValue(colDS_Barcode) ?? string.Empty).ToString();
                }
                return string.Empty;
            }
        }

        public DateTime NgayTiepNhanDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan).ToString());
                }
                return DateTime.Now;
            }
        }
        public string MaBnDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return (gvDanhSach.GetFocusedRowCellValue(colDS_MaBN) ?? string.Empty).ToString();
                }
                return string.Empty;
            }
        }
        public int HisIdDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return int.Parse((gvDanhSach.GetFocusedRowCellValue(colDS_HisProviderID) ?? "0").ToString());
                }
                return 0;
            }
        }
        public bool RowIsChecked
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return gvDanhSach.IsRowSelected(gvDanhSach.FocusedRowHandle);
                }
                return false;
            }
        }


        private DataTable dataDSBenhNhan = new DataTable();
        [Category("Custom")]
        public bool ShowCheckChon
        {
            get { return gvDanhSach.OptionsSelection.ShowCheckBoxSelectorInColumnHeader == DevExpress.Utils.DefaultBoolean.True; }
            set
            {
                gvDanhSach.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = (value ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False);
                gvDanhSach.OptionsSelection.MultiSelect = value;
                gvDanhSach.OptionsSelection.MultiSelectMode = (value ? DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect : DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect);
            }
        }
        [Category("Custom")]
        public bool DungUploadHIS
        {
            get { return btnUploadHisBN.Visible; }
            set
            {
                btnUploadHisBN.Visible = value;
            }
        }
        [Category("Custom")]
        public bool DungInDanhSach
        {
            get { return btnInTheoDS.Visible; }
            set
            {
                btnInTheoDS.Visible = value;
            }
        }
        [Category("Custom")]
        public bool ShowTuyChon
        {
            get
            {
                return btnSettingResult.Visible;
            }
            set
            {
                btnSettingResult.Visible = value;
            }
        }
        public DateTime NgayNhanMau
        {
            set { dtpDateIn.Value = value; }
            get { return dtpDateIn.Value; }
        }
        public string Barcode
        {
            set { txtSEQ.Text = value; }
            get { return txtSEQ.Text; }
        }
        /// <summary>
        /// Danh sách bệnh nhân 
        /// </summary>
        public DataTable DataDSBenhNhan
        {
            get { return dataDSBenhNhan; }
        }
        private List<string> lstDanhSachNhomPhanQuyen = new List<string>();
        private List<string> lstDanhSachNhom = new List<string>();
        /// <summary>
        /// List Danh sách nhóm phân quyền của user hoặc nhóm được chọn
        /// </summary>
        public List<string> LstDanhSachNhom
        {
            get
            {
                return lstDanhSachNhom;
            }
            set
            {
                lstDanhSachNhomPhanQuyen = value;
                lstDanhSachNhom = value;
            }
        }
        public bool DSViSinh = false;
        /// <summary>
        /// Danh sách loại xét nghiệm
        /// </summary>
        public TestType.EnumTestType[] ArrLoaiXetNghiem = new TestType.EnumTestType[] {
            TestType.EnumTestType.ThongThuong
            , TestType.EnumTestType.ViSinh_TQ
            , TestType.EnumTestType.HuyetDo
            , TestType.EnumTestType.HIV };
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IMicrobilogyTestResultService _microbiologyTesresult = new MicrobilogyTestResultService();
        object dtgCurrent;
        public void SetFosToSeq()
        {
            txtSEQ.Focus();
        }
        public void SetFosToDataGrid()
        {
            gvDanhSach.Focus();
        }
        public void Load_CauHinh()
        {
            dtpDateIn.Value = CommonAppVarsAndFunctions.ServerTime;
            var objCauHinhLuoiKQ = _isSysConfig.lstThongTinHienThi(HienthiConstants.DanhSachBNKQXetNghiem);
            if (objCauHinhLuoiKQ != null)
            {
                if (objCauHinhLuoiKQ.Count > 0)
                {
                    foreach (GridColumn item in gvDanhSach.Columns)
                    {
                        var colFind = objCauHinhLuoiKQ.Where(x => x.Idhienthi.Equals(item.Name, StringComparison.OrdinalIgnoreCase));
                        if (colFind.Any())
                        {
                            var colInfo = colFind.First();
                            item.Visible = colInfo.Hienthi;
                            item.Caption = colInfo.Mota;
                            item.Width = colInfo.Dorong;
                            if (colInfo.Hienthi && colInfo.Sapxep > 0)
                            {
                                item.VisibleIndex = colInfo.Sapxep;
                            }
                        }
                        item.FieldName = item.FieldName.ToLower();
                    }
                }
            }
            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSach);

            if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo)
            {
                radDSXemTheoBarcode.TextAlign = ContentAlignment.MiddleLeft;
                radDSXemTheoBarcode.Text = "BARCODE";
            }
            var CoNhanMau = QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);

            radDSTheoNgayNhanMau.Visible = CoNhanMau;
            radDSTheoNgayNhanMau.Checked = true;
            rdNgayNhapChiDinh.Visible = !CoNhanMau;
            rdNgayNhapChiDinh.Checked = !CoNhanMau;

            ucSearchLookupEditor_KhuDieuTri1.Load_DieuTri();
            ucSearchLookupEditor_KhuDieuTri1.SelectedValue = null;
            ucSearchLookupEditor_KhuDieuTri1.EditValueChange += UcSearchLookupEditor_KhuDieuTri1_EditValueChange;

            ucSearchLookupEditor_Location1.Load_DonVi();
            ucSearchLookupEditor_Location1.SelectedValue = null;
            ucSearchLookupEditor_Location1.EditValueChange += UcSearchLookupEditor_Location1_EditValueChange;
            LoadTrangThai();
            btnUploadHisBN.Visible = (CommonAppVarsAndFunctions.sysConfig.ConnectHIS
                && CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionReUploadResultToHis));
        }
        private void LoadTrangThai()
        {
            var data = CommonConstant.DanhSachTrangThai();
            lueTrangThaiKetQua.Properties.DataSource = data;
            lueTrangThaiKetQua.Properties.ValueMember = "ID";
            lueTrangThaiKetQua.Properties.DisplayMember = "Description";
            lueTrangThaiKetQua.EditValue = "";
            lueTrangThaiKetQua.KeyPress += lueTrangThaiKetQua_KeyPress;
            lueTrangThaiKetQua.EditValueChanged += lueTrangThaiKetQua_EditValueChanged;
        }
        private void lueTrangThaiKetQua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                FindPatient();
        }
        private void lueTrangThaiKetQua_EditValueChanged(object sender, EventArgs e)
        {
            FindPatient();
        }
        private void UcSearchLookupEditor_KhuVuc1_EditValueChange(object sender, EventArgs e)
        {
            FindPatient();
        }
        private void btnUploadHisBN_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Chuyển kết quả bệnh nhân được chọn về HIS?"))
                {
                    txtSEQ.Focus();
                    var selectedRows = gvDanhSach.GetSelectedRows();
                    foreach (int i in selectedRows)
                    {
                        if (gvDanhSach.GetRowCellValue(i, colDS_MaTiepNhan) != null)
                        {
                            var matiepNhan = gvDanhSach.GetRowCellValue(i, colDS_MaTiepNhan).ToString().Trim();
                            if (DSViSinh)
                                _iHisData.CapNhat_ChuaUploadVS(matiepNhan, string.Empty);
                            else
                                _iHisData.CapNhat_ChuaUpload(matiepNhan, string.Empty);
                            gvDanhSach.UnselectRow(i);
                        }
                    }
                    FindPatient();
                }
            }
        }
        private void UcSearchLookupEditor_Location1_EditValueChange(object sender, EventArgs e)
        {
            FindPatient();
        }

        private void UcSearchLookupEditor_KhuDieuTri1_EditValueChange(object sender, EventArgs e)
        {
            var maKhuDieuTri = ucSearchLookupEditor_KhuDieuTri1.SelectedValue == null ? string.Empty : ucSearchLookupEditor_KhuDieuTri1.SelectedValue.ToString();
            ucSearchLookupEditor_Location1.EditValueChange -= UcSearchLookupEditor_Location1_EditValueChange;
            ucSearchLookupEditor_Location1.Load_DonVi(maKhuDieuTri);
            ucSearchLookupEditor_Location1.SelectedValue = null;
            FindPatient();
            ucSearchLookupEditor_Location1.EditValueChange += UcSearchLookupEditor_Location1_EditValueChange;
        }
        public void Load_DSBenhNhan()
        {
            FindPatient();
        }
        private void FindPatient()
        {
            BeforeReload_DSBenhNhan?.Invoke(btnDSBenhNhan, EventArgs.Empty);
            if (WorkingServices.IsNumeric(txtSEQ.Text) && !DSViSinh)
            {
                gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;
                Load_DSThongTin(txtSEQ.Text);
                gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
                gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    if (!radDSXemTheoBarcode.Checked)
                        FilterPatient_Data();
                    else
                    {
                        gvDanhSach.Focus();
                        DataGridview_DsBenhNhan_CellEnter?.Invoke(gvDanhSach, new EventArgs());
                    }
                }
                else
                {
                    DataGridview_DsBenhNhan_CellEnter?.Invoke(gvDanhSach, new EventArgs());
                }
                txtSEQ.SelectAll();
            }
            else
            {
                FilterPatient_Data();
            }
        }
        private void GvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                dtgCurrent = gvDanhSach.GetRow(gvDanhSach.FocusedRowHandle);
                DataGridview_DsBenhNhan_CellEnter?.Invoke(sender, e);
            }
            else
            {
                dtgCurrent = null;
                DataGridview_DsBenhNhan_CellEnter?.Invoke(sender, e);
            }
        }

        private void GvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                if (dtgCurrent == null)
                {
                    dtgCurrent = gvDanhSach.GetRow(gvDanhSach.FocusedRowHandle);
                    DataGridview_DsBenhNhan_CellEnter?.Invoke(sender, e);
                }
                else if (dtgCurrent != gvDanhSach.GetRow(gvDanhSach.FocusedRowHandle))
                {
                    dtgCurrent = gvDanhSach.GetRow(gvDanhSach.FocusedRowHandle);
                    DataGridview_DsBenhNhan_CellEnter?.Invoke(sender, e);
                }
            }
            else
            {
                dtgCurrent = null;
                DataGridview_DsBenhNhan_CellEnter?.Invoke(sender, e);
            }
        }

        private void FilterPatient_Data()
        {
            string filter = string.Empty;
            gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;

            if (!string.IsNullOrEmpty(txtSEQ.Text))
            {
                if (dataDSBenhNhan.Rows.Count == 0)
                {

                    Load_DSThongTin(txtSEQ.Text);
                }
                if (WorkingServices.IsNumeric(txtSEQ.Text))
                {
                    filter = string.Format("SEQ = '{0}' or ", WorkingServices.EscapeLikeValue(txtSEQ.Text));
                }

                filter += string.Format("TenBN like '%{0}%' or MaBN like '%{0}%'", WorkingServices.EscapeLikeValue(txtSEQ.Text));
                var data = WorkingServices.ConvertColumnNameToLower_Upper(WorkingServices.SearchResult_OnDatatable(dataDSBenhNhan, filter), true);
                gcDanhSach.DataSource = data;
                gvDanhSach.ExpandAllGroups();
                Set_MauTrangThai();
            }
            else
            {
                Load_DSThongTin(txtSEQ.Text);
            }
            DataGridview_DsBenhNhan_CellEnter?.Invoke(gvDanhSach, new EventArgs());
            gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
        }
        private void Load_DSThongTin(string seq)
        {
            dtgCurrent = null;
            string trangThai = WorkingServices.ObjecToString(lueTrangThaiKetQua.EditValue);
            dataDSBenhNhan = new DataTable();
            var printType = enumThucHien.TatCa;
            var maKhoaPhong = (ucSearchLookupEditor_Location1.SelectedValue ?? string.Empty).ToString();
            var maKhudieuTri = (ucSearchLookupEditor_KhuDieuTri1.SelectedValue ?? string.Empty).ToString();
            if (radDSXemTheoBarcode.Checked)
            {
                if (!string.IsNullOrEmpty(seq))
                {
                    if (WorkingServices.IsNumeric(seq))
                    {
                        if (DSViSinh)
                        {
                            dataDSBenhNhan = _xetnghiem.Get_Patient_XNViSinh(radDSXemTheoBarcode.Checked ? seq : string.Empty
                            , string.Empty, printType
                            , enumThucHien.TatCa, enumThucHien.TatCa
                            , CommonAppVarsAndFunctions.UserWorkPlace
                            , ArrLoaiXetNghiem.ToList()
                            , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                            , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                            , string.Empty
                            , Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                            , maKhoaPhong
                            , maKhudieuTri
                            , string.Join(",", lstDanhSachNhom));
                        }
                        else
                        {
                            dataDSBenhNhan = _xetnghiem.Get_Patient_XN_TheoBarcode(radDSXemTheoBarcode.Checked ? seq : string.Empty
                               , string.Empty, printType
                               , enumThucHien.TatCa, enumThucHien.TatCa
                               , CommonAppVarsAndFunctions.UserWorkPlace
                               , ArrLoaiXetNghiem.ToList()
                               , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                               , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                               , string.Empty
                               , Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                               , maKhoaPhong
                               , maKhudieuTri
                               , string.Join(",", lstDanhSachNhom));
                        }
                    }
                }
            }
            else
            {
                if (radDSTheoNgayNhanMau.Checked)
                {
                    if (DSViSinh)
                    {
                        dataDSBenhNhan = _xetnghiem.Get_Patient_XNViSinh((WorkingServices.IsNumeric(seq) ? seq : string.Empty)
                         , dtpDateIn.Value.ToString("yyyy-MM-dd"), printType
                         , enumThucHien.TatCa, enumThucHien.TatCa
                         , CommonAppVarsAndFunctions.UserWorkPlace, ArrLoaiXetNghiem.ToList()
                         , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                         , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                         , string.Empty, Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                         , maKhoaPhong
                         , maKhudieuTri
                         , string.Join(",", lstDanhSachNhom));
                    }
                    else
                    {
                        dataDSBenhNhan = _xetnghiem.Get_Patient_XN_TheoNgayNhanMau(string.Empty
                          , dtpDateIn.Value.ToString("yyyy-MM-dd"), printType
                          , enumThucHien.TatCa, enumThucHien.TatCa
                          , CommonAppVarsAndFunctions.UserWorkPlace, ArrLoaiXetNghiem.ToList()
                          , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                          , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                          , string.Empty, Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                          , maKhoaPhong
                          , maKhudieuTri
                          , string.Join(",", lstDanhSachNhom));

                    }
                }
                else
                {

                    if (DSViSinh)
                    {
                        dataDSBenhNhan = _xetnghiem.Get_Patient_XNViSinh(string.Empty
                            , dtpDateIn.Value.ToString("yyyy-MM-dd"), printType
                            , enumThucHien.TatCa, enumThucHien.TatCa
                            , CommonAppVarsAndFunctions.UserWorkPlace, ArrLoaiXetNghiem.ToList()
                            , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                            , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                            , seq, Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                            , maKhoaPhong
                            , maKhudieuTri
                            , string.Join(",", lstDanhSachNhom));
                    }
                    else
                    {
                        dataDSBenhNhan = _xetnghiem.Get_Patient_XN_TheoNgayTiepNhan(string.Empty
                           , dtpDateIn.Value.ToString("yyyy-MM-dd"), printType
                           , enumThucHien.TatCa, enumThucHien.TatCa
                           , CommonAppVarsAndFunctions.UserWorkPlace, ArrLoaiXetNghiem.ToList()
                           , QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                           , QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                           , seq, Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, false)
                           , maKhoaPhong
                           , maKhudieuTri
                           , string.Join(",", lstDanhSachNhom));
                    }
                }

            }
            //Bỏ vị trí đầu cho tất cả
            if (!string.IsNullOrEmpty(trangThai))
            {
                if (QuiTrinhLAB.GetTrangThaiNhanMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh)
                )
                {
                    dataDSBenhNhan = WorkingServices.SearchResult_OnDatatable(dataDSBenhNhan,
                        string.Format("TrangThaiMau = '{0}'", trangThai));
                }
                else
                {
                    if (trangThai.Equals("G"))
                    {
                        dataDSBenhNhan = WorkingServices.SearchResult_OnDatatable(dataDSBenhNhan,
                            QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig
                                .ClsXetNghiemXemQuiTrinh)
                                ? "TrangThaiMau = 'C'"
                                : "TrangThaiMau is null");
                    }
                    else
                    {
                        dataDSBenhNhan = WorkingServices.SearchResult_OnDatatable(dataDSBenhNhan,
                            string.Format("TrangThaiMau = '{0}'", trangThai));
                    }
                }
            }

            gcDanhSach.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(dataDSBenhNhan,true);
            gvDanhSach.ExpandAllGroups();
            Set_MauTrangThai();
        }

        public void UnCheckCurrentRow()
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                gvDanhSach.UnselectRow(gvDanhSach.FocusedRowHandle);
            }
        }
        private void Set_MauTrangThai()
        {

            //if (dtgPatient.RowCount <= 0) return;
            //for (var i = 0; i < dtgPatient.RowCount; i++)
            //{

            //}
        }
        private void txtSEQ_Enter(object sender, EventArgs e)
        {
            txtSEQ.SelectAll();
            txtSEQ.BackColor = CommonAppColors.ColorButtonForceColorHover;
        }
        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSEQ.Text = WorkingServices.GetBarcodeInString(txtSEQ.Text, int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode));
                FindPatient();
                txtSEQ.SelectAll();
                e.Handled = true;
            }
        }

        private void dtpDateIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && (radDSTheoNgayNhanMau.Checked || rdNgayNhapChiDinh.Checked))
            {
                FindPatient();
                e.Handled = true;
            }
        }

        private void radDSTheoNgayNhanMau_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSTheoNgayNhanMau.Checked)
            {
                radDSTheoNgayNhanMau.BackColor = CommonAppColors.ColorCheckedSelectedBackColor; 
                dtpDateIn.Focus();
                FindPatient();
            }
            else
                radDSTheoNgayNhanMau.BackColor = Color.Empty;
        }

        private void radDSXemTheoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateIn.Enabled = radDSTheoNgayNhanMau.Checked || rdNgayNhapChiDinh.Checked;
            if (radDSXemTheoBarcode.Checked)
            {
                radDSXemTheoBarcode.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
                FindPatient();
            }
            else
                radDSXemTheoBarcode.BackColor = Color.Empty;
        }

        private void btnChonNhom_Click(object sender, EventArgs e)
        {
            ChonNhomXN();

        }
        private void ChonNhomXN()
        {
            //var f = new DailyUse.CanLamSang.FrmChonNhomNhanMau();
            //f.ShowDialog();
            //bool isAll = false;
            //if (f.lstNhomNhanMau.Count > 0)
            //    lstDanhSachNhom = f.lstNhomNhanMau;
            //else
            //{
            //    isAll = true;
            //    lstDanhSachNhom = lstDanhSachNhomPhanQuyen;
            //}

            //Set_DSNhomVaoTitle(isAll);
            //DoiNhomXN?.Invoke(btnChonNhom, new EventArgs());
            //btnDSBenhNhan_Click(btnChonNhom, new EventArgs());
        }
        private void Set_DSNhomVaoTitle(bool isAll)
        {
            if (!isAll)
            {
                lblNhomChon.Text = string.Format("{0}", string.Join(",", lstDanhSachNhom));
            }
            else
            {
                lblNhomChon.Text = LanguageExtension.GetResourceValueFromValue(
                    "NHÓM: TẤT CẢ",
                    LanguageExtension.AppLanguage); //"TẤT CẢ";
            }
        }

        private void btnDSBenhNhan_Click(object sender, EventArgs e)
        {
            FindPatient();
        }

        private void btnSettingResult_Click(object sender, EventArgs e)
        {
            Button_TuyChon_Click?.Invoke(sender, e);
        }

        private void txtSEQ_Click(object sender, EventArgs e)
        {
            txtSEQ.SelectAll();
            //txtSEQ.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
        }
        private void txtSEQ_Leave(object sender, EventArgs e)
        {
            // txtSEQ.BackColor = Color.Empty;
        }

        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            //var frm = new FrmTimBenhNhan
            //{
            //    DtDateFromG = dtpDateIn.Value,
            //    ServiceTypeID = ServiceType.ClsXetNghiem.ToString(),
            //    _arrLoaiXetNghiem = ArrLoaiXetNghiem,
            //    List = true,
            //    OpenFrom = 2,
            //    BorderSize = 1,
            //    pnMenu = {Visible = true}
            //};
            //frm.AdjustForm();
            //frm.ShowDialog();
            
            //if (!string.IsNullOrWhiteSpace(frm.ReturnSEQ))
            //{
            //    txtSEQ.Text = frm.ReturnSEQ;
            //    dtpDateIn.Value = frm.ReturnDateIn;
            //    if (!radDSXemTheoBarcode.Checked)
            //    {
            //        radDSXemTheoBarcode.Checked = true;
            //    }
            //    FindPatient();
            //    if (gvDanhSach.FocusedRowHandle > -1)
            //    {
            //        GvDanhSach_FocusedRowChanged(gvDanhSach, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gvDanhSach.FocusedRowHandle));
            //    }
            //}
            //frm.Dispose();
        }
        public void SetMenuContext(ContextMenuStrip menu)
        {
            gcDanhSach.ContextMenuStrip = menu;
        }
        private void btnInTheoDS_Click(object sender, EventArgs e)
        {
            InTheoDanhSach_Click?.Invoke(sender, e);
        }

        private void rdNgayNhapChiDinh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNgayNhapChiDinh.Checked)
            {
                rdNgayNhapChiDinh.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
                dtpDateIn.Focus();
                FindPatient();
            }
            else
                rdNgayNhapChiDinh.BackColor = Color.Empty;
        }

        private void gvDanhSach_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
  
            if (e.RowHandle < 0) return;
            if (e.Column == colDS_Barcode)
            {
                var view = sender as GridView;
                var trangThai = view.GetRowCellValue(e.RowHandle, colDS_TrangThai).ToString();
                if (trangThai.Equals("F", StringComparison.OrdinalIgnoreCase))
                {
                    e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDuKQ) ? colDS_Barcode.AppearanceCell.BackColor :
                     ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDuKQ));
                }
                else if (trangThai.Equals("H", StringComparison.OrdinalIgnoreCase))
                {
                    e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaCoKQ) ? colDS_Barcode.AppearanceCell.BackColor :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaCoKQ));
                }
                else if (trangThai.Equals("V", StringComparison.OrdinalIgnoreCase))
                {
                    e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaDuyetKQ) ? colDS_Barcode.AppearanceCell.BackColor :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaDuyetKQ));
                }
                else if (trangThai.Equals("P", StringComparison.OrdinalIgnoreCase))
                {
                    e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaInKQ) ? colDS_Barcode.AppearanceCell.BackColor :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauDaInKQ));
                }
                else if (trangThai.Equals("G", StringComparison.OrdinalIgnoreCase))
                {
                    e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauChuaKQ) ? colDS_Barcode.AppearanceCell.BackColor :
                    ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauChuaKQ));
                }
            }
        }

        private void pnSearcBarcode_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
