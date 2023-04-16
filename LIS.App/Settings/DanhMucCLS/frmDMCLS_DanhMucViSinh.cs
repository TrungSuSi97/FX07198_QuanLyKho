using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using TPH.Common.Converter;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.LIS.Common;
using TPH.Excel;

namespace TPH.LIS.App.Settings.DanhMucCLS.ViSinh
{
    public partial class frmDMCLS_DanhMucViSinh : FrmTemplate
    {
        public frmDMCLS_DanhMucViSinh()
        {
            InitializeComponent();
        }
        DataTable dataBacterium = new DataTable();
        DataTable dataAntibiotic = new DataTable();
        DataTable dataBacteriumAntibiotic = new DataTable();

        DataTable dtViKhuan = new DataTable();
        bool _isLoading = false;
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private void frmDMCLS_DanhMucViSinh_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            Load_DanhSachKhangSinhNhom();
            Load_DanhSachKhangSinh();

            Load_DonViPhanLoai();
            Load_kyThuat();
            Load_ToChucBreakpoint();
            Load_LoaiKetQua();
            _isLoading = false;
            Load_DanhSach_BangKhangSinh();
            Load_DanhSachPhanLoaiViKhuan();
            Load_DanhMucKhaoSat();
            Load_KhangKhangSinh();
            Load_cboPanel_Site_INF();

            ucSearchLookupEditor_MayXN1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucSearchLookupEditor_MayXN1.Load_MayXN((int)PhanLoaiMayXN.EnumLoaiMayXN.ViSinh, true);
            ucSearchLookupEditor_MayXN1.EditValueChange += UcSearchLookupEditor_MayXN1_EditValueChange;
            ucSearchLookupEditor_MayXN2.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucSearchLookupEditor_MayXN2.Load_MayXN((int)PhanLoaiMayXN.EnumLoaiMayXN.ViSinh, true);
            Load_DanhSachLoaiMau();
            Load_DanhSach_LoaiMau_QuyTrinh();
            setSelectedTab(false);

            //cboPanel_ToChuc.DropDownStyle = ComboBoxStyle.DropDownList;
            //gvBoKS_DanhSachKS.OptionsView.ShowAutoFilterRow = true;
            //gvBoKS_DanhSachKS.OptionsFilter.AllowFilterEditor = DevExpress.Utils.DefaultBoolean.False;
            //colCompanyName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.BeginsWith;
        }

        private void Load_cboPanel_Site_INF()
        {
            cboPanel_Site_INF.DataSource = _bacteriumAntibioticService.Get_DM_Site_INF();
            cboPanel_Site_INF.ColumnNames = "SiteInfection";
            cboPanel_Site_INF.ColumnWidths = "200";
            cboPanel_Site_INF.DisplayMember = "SiteInfection";
            cboPanel_Site_INF.ValueMember = "SiteInfection";
            cboPanel_Site_INF.SelectedIndex = -1;
        }

        private void UcSearchLookupEditor_MayXN1_EditValueChange(object sender, EventArgs e)
        {
            Load_DanhSach_LoaiMau_QuyTrinh();
        }
        private void Load_DanhSachLoaiMau()
        {
            var data = _systemConfigService.Data_LoaiMau_GetDM(string.Empty, false, new[] { ServiceType.ClsXNViSinh.ToString() });
            gcLoaiMau.DataSource = data;
        }
        private void Load_DanhSach_LoaiMau_QuyTrinh()
        {
            var idMay = (ucSearchLookupEditor_MayXN1.SelectedValue ?? string.Empty).ToString();
            var data = _bacteriumAntibioticService.Data_dm_xetnghiem_visinh_quytrinh_loaimau(string.Empty, idMay);
            gcQuyTrinh_LoaiMau.DataSource = data;
        }
        private void Insert_QuyTrinh_LoaiMau()
        {
            if (ucSearchLookupEditor_MayXN1.SelectedValue != null)
            {
                if (gvLoaiMau.SelectedRowsCount > 0)
                {
                    var sR = gvLoaiMau.GetSelectedRows();
                    foreach (var i in sR)
                    {
                        if (gvLoaiMau.GetRowCellValue(i, colLoaiMau_MaLoaiMau) == null) continue;
                        var obj = new DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU
                        {
                            Maloaimau = gvLoaiMau.GetRowCellValue(i, colLoaiMau_MaLoaiMau).ToString(),
                            Idmayxn = int.Parse(ucSearchLookupEditor_MayXN1.SelectedValue.ToString()),
                            Quytrinh = txtQuyTrinhLoaiMau.Text
                        };
                        _bacteriumAntibioticService.Insert_dm_xetnghiem_visinh_quytrinh_loaimau(obj);
                    }
                    Load_DanhSach_LoaiMau_QuyTrinh();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn loại mẫu!");
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm!");
            }
        }
        public void Delete_Quytrinh_LoaiMau()
        {
            if (gvQuyTrinh_LoaiMau.GetFocusedRowCellValue(colQuyTrinh_LoaiMau_MaLoaiMau) != null)
            {
                var maLoaiMau = gvQuyTrinh_LoaiMau.GetFocusedRowCellValue(colQuyTrinh_LoaiMau_MaLoaiMau).ToString();
                var idMayXn = int.Parse(gvQuyTrinh_LoaiMau.GetFocusedRowCellValue(colQuyTrinh_LoaiMau_IdMayXN).ToString());
                var obj = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_visinh_quytrinh_loaimau(maLoaiMau, idMayXn.ToString());
                _bacteriumAntibioticService.Delete_dm_xetnghiem_visinh_quytrinh_loaimau(obj);
                Load_DanhSach_LoaiMau_QuyTrinh();
            }
        }
        public void Update_QuyTrinh_LoaiMau(int index)
        {
            if (gvQuyTrinh_LoaiMau.GetRowCellValue(index, colQuyTrinh_LoaiMau_MaLoaiMau) == null) return;
            var maLoaiMau = gvQuyTrinh_LoaiMau.GetRowCellValue(index, colQuyTrinh_LoaiMau_MaLoaiMau).ToString();
            var idMayXn = int.Parse(gvQuyTrinh_LoaiMau.GetRowCellValue(index, colQuyTrinh_LoaiMau_IdMayXN).ToString());
            var obj = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_visinh_quytrinh_loaimau(maLoaiMau, idMayXn.ToString());
            obj.Quytrinh = gvQuyTrinh_LoaiMau.GetRowCellValue(index, colQuyTrinh_LoaiMau_QuyTrinh).ToString();
            obj.Datchungnhan = bool.Parse(gvQuyTrinh_LoaiMau.GetRowCellValue(index, colQuyTrinh_LoaiMau_DatChungNhan).ToString());
            _bacteriumAntibioticService.Update_dm_xetnghiem_visinh_quytrinh_loaimau(obj);
        }
        private void gvQuyTrinh_LoaiMau_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Update_QuyTrinh_LoaiMau(e.RowHandle);
        }
        #region Danh sách nhóm kháng sinh

        DM_XETNGHIEM_NHOMKHANGSINH _objInfoNhomKhangSinh;
        private void Xoa_ThongTinKhangSinhNhom()
        {
            txtKhangSinhNhomMa.ForeColor = SystemColors.WindowText;
            txtKhangSinhNhomMa.DataBindings.Clear();
            txtKhangSinhNhomTen.DataBindings.Clear();
            txtKhangSinhNhomThuTuIn.DataBindings.Clear();
            txtKhangSinhNhomMa.Text = string.Empty;
            txtKhangSinhNhomTen.Text = string.Empty;
            txtKhangSinhNhomThuTuIn.Text = string.Empty;
            grbKhangSinhNhomThongTin.Enabled = false;
            grbKhangSinhDanhSach.Enabled = true;
        }

        private void BindData_ThongTinKhangSinhNhom()
        {
            txtKhangSinhNhomMa.DataBindings.Add("Text", _objInfoNhomKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtKhangSinhNhomTen.DataBindings.Add("Text", _objInfoNhomKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Tennhomkhangsinh), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtKhangSinhNhomThuTuIn.DataBindings.Add("Text", _objInfoNhomKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Thutuin), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }
        private void Load_ThongTinKhangSinhNhom()
        {
            if (dtgKhangSinhNhomDanhSach.CurrentRow == null) return;
            _objInfoNhomKhangSinh = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_nhomkhangsinh(dtgKhangSinhNhomDanhSach.CurrentRow.Cells[MaNhomKhangSinh.Name].Value.ToString().Trim());

            Xoa_ThongTinKhangSinhNhom();
            BindData_ThongTinKhangSinhNhom();
        }
        private void Load_DanhSachKhangSinhNhom()
        {
            //ucAddEditKhangSinhNhom.SetStatusButtonNormal();
            var checkFunction = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
                CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionCategoriesManagementOfVS);
            ucAddEditKhangSinhNhom.SetStatusButtonFunction(CommonAppVarsAndFunctions.IsAdmin, checkFunction);
            var dt = _bacteriumAntibioticService.Get_Data_dm_xetnghiem_nhomkhangsinh(dtgKhangSinhNhomDanhSach, bvKhangSinhNhomDanhSach, string.Empty);
            ControlExtension.BindDataToCobobox(dt.Copy(), ref cboKhangSinhNhom
                , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                , string.Format("{0},{1}", ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Tennhomkhangsinh)), "50, 250", txtKhangSinhTimTenNhom, 1);

            ControlExtension.BindDataToCobobox(dt.Copy(), ref cboKhangSinhNhom
                , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                , string.Format("{0},{1}", ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Tennhomkhangsinh)), "50, 250", txtKhangSinhTimTenNhom, 1);

       
            cboQuiTrinh_DMKS_Nhom.SelectedIndexChanged -= CboQuiTrinh_DMKS_Nhom_SelectedIndexChanged;
            ControlExtension.BindDataToCobobox(dt.Copy(), ref cboQuiTrinh_DMKS_Nhom
                 , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                 , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                 ,
                 string.Format("{0},{1}",
                     ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh)
                     , ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Tennhomkhangsinh)), "50, 250",
                 null, 1);
            cboQuiTrinh_DMKS_Nhom.SelectedIndexChanged += CboQuiTrinh_DMKS_Nhom_SelectedIndexChanged;

        }



        private void ThemMoi_KhangSinhNhom()
        {
            Xoa_ThongTinKhangSinhNhom();

            _objInfoNhomKhangSinh = new DM_XETNGHIEM_NHOMKHANGSINH();
            BindData_ThongTinKhangSinhNhom();

            grbKhangSinhNhomThongTin.Enabled = true;
            grbKhangSinhDanhSach.Enabled = false;

            txtKhangSinhNhomThuTuIn.Text = "1000";

            txtKhangSinhNhomMa.ForeColor = Color.DarkRed;
            txtKhangSinhNhomMa.Focus();
        }
        private void ChinhSua_KhangSinhNhom()
        {
            if (dtgKhangSinhNhomDanhSach.CurrentRow != null)
            {
                grbKhangSinhNhomThongTin.Enabled = true;
                grbKhangSinhDanhSach.Enabled = false;

                txtKhangSinhNhomMa.ForeColor = Color.Blue;
                txtKhangSinhNhomMa.Focus();
            }
        }
        private void Luu_KhangSinhNhom()
        {
            if (string.IsNullOrEmpty(txtKhangSinhNhomMa.Text))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập mã nhóm kháng sinh!");
                txtKhangSinhNhomMa.Focus();
            }
            else if (string.IsNullOrEmpty(txtKhangSinhNhomTen.Text))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập tên nhóm kháng sinh!");
                txtKhangSinhNhomTen.Focus();
            }
            else if (string.IsNullOrEmpty(txtKhangSinhNhomThuTuIn.Text))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập thứ tự in nhóm kháng sinh!");
                txtKhangSinhNhomThuTuIn.Focus();
            }
            else
            {
                if (txtKhangSinhNhomMa.ForeColor == Color.DarkRed)
                {
                    _objInfoNhomKhangSinh.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                    if (_bacteriumAntibioticService.Insert_dm_xetnghiem_nhomkhangsinh(_objInfoNhomKhangSinh))
                    {
                        Load_DanhSachKhangSinhNhom();
                    }
                }
                else if (grbKhangSinhNhomThongTin.Enabled)
                {
                    var objOld = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_nhomkhangsinh(dtgKhangSinhNhomDanhSach.CurrentRow.Cells[MaNhomKhangSinh.Name].Value.ToString().Trim());
                    _objInfoNhomKhangSinh.Nguoisua = CommonAppVarsAndFunctions.UserID;
                    if (!_bacteriumAntibioticService.Update_dm_xetnghiem_nhomkhangsinh(_objInfoNhomKhangSinh, objOld))
                        return;
                    Load_DanhSachKhangSinhNhom();
                    bvKhangSinhNhomDanhSach.BindingSource.Position = bvKhangSinhNhomDanhSach.BindingSource.Find(ControlExtension.PropertyName<DM_XETNGHIEM_NHOMKHANGSINH>(x => x.Manhomkhangsinh), txtKhangSinhNhomMa.Text);
                }
            }
        }
        private void Xoa_KhangSinhNhom()
        {
            if (dtgKhangSinhNhomDanhSach.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xoá danh mục nhóm kháng sinh đang chọn?"))
                {
                    DM_XETNGHIEM_NHOMKHANGSINH objDelete = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_nhomkhangsinh(dtgKhangSinhNhomDanhSach.CurrentRow.Cells[MaNhomKhangSinh.Name].Value.ToString().Trim());
                    if (_bacteriumAntibioticService.Delete_dm_xetnghiem_nhomkhangsinh(objDelete))
                    {
                        Xoa_ThongTinKhangSinhNhom();
                        Load_DanhSachKhangSinhNhom();
                    }
                }
            }
        }

        private void dtgKhangSinhNhomDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_ThongTinKhangSinhNhom();
        }

        private void ucAddEditKhangSinhNhom_ButtonAddClick(object sender, EventArgs e)
        {
            ThemMoi_KhangSinhNhom();

        }

        private void ucAddEditKhangSinhNhom_ButtonCancelClick(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Huỷ thao tác?"))
            {
                Load_DanhSachKhangSinhNhom();
            }
        }
        private void ucAddEditKhangSinhNhom_ButtonDeleteClick(object sender, EventArgs e)
        {
            Xoa_KhangSinhNhom();
        }

        private void ucAddEditKhangSinhNhom_ButtonEditClick(object sender, EventArgs e)
        {
            ChinhSua_KhangSinhNhom();
        }

        private void ucAddEditKhangSinhNhom_ButtonSaveClick(object sender, EventArgs e)
        {
            Luu_KhangSinhNhom();
        }
        private void btnKhangSinhNhomLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhSachKhangSinhNhom();
        }

        private void txtKhangSinhMaNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKhangSinhNhomThuTuIn);
        }

        private void txtKhangSinhNhomThuTuIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKhangSinhNhomTen);
        }

        private void txtKhangSinhMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboKhangSinhNhom);
        }

        private void cboKhangSinhNhom_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKhangSinhTen);
        }

        private void txtKhangSinhTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKhangSinhSapXep);
        }
        #endregion
        #region Danh sách kháng sinh

        DM_XETNGHIEM_KHANGSINH _objInfoKhangSinh;
        private void Xoa_ThongTinKhangSinh()
        {
            txtKhangSinhMa.ForeColor = SystemColors.WindowText;
            txtKhangSinhMa.DataBindings.Clear();
            txtKhangSinhTen.DataBindings.Clear();
            txtKhangSinhSapXep.DataBindings.Clear();
            cboKhangSinhNhom.DataBindings.Clear();
            txtKhangSinhMa.Text = string.Empty;
            txtKhangSinhTen.Text = string.Empty;
            txtKhangSinhSapXep.Text = string.Empty;
            cboKhangSinhNhom.SelectedIndex = -1;
            grbKhangSinhThongTin.Enabled = false;
            grbKhangSinhDanhSach.Enabled = true;
        }
        private void BindData_ThongTinKhangSinh()
        {
            txtKhangSinhMa.DataBindings.Add("Text", _objInfoKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_KHANGSINH>(x => x.Makhangsinh), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtKhangSinhTen.DataBindings.Add("Text", _objInfoKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_KHANGSINH>(x => x.Tenkhangsinh), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtKhangSinhSapXep.DataBindings.Add("Text", _objInfoKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_KHANGSINH>(x => x.Sapxep), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            cboKhangSinhNhom.DataBindings.Add("SelectedValue", _objInfoKhangSinh,
        ControlExtension.PropertyName<DM_XETNGHIEM_KHANGSINH>(x => x.Manhomkhangsinh), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }
        private void ThemMoi_KhangSinh()
        {
            Xoa_ThongTinKhangSinh();
            grbKhangSinhDanhSach.Enabled = false;
            _objInfoKhangSinh = new DM_XETNGHIEM_KHANGSINH();
            BindData_ThongTinKhangSinh();
            txtKhangSinhSapXep.Text = "1000";
            grbKhangSinhThongTin.Enabled = true;
            txtKhangSinhMa.ForeColor = Color.DarkRed;
            txtKhangSinhMa.Focus();
        }
        private void ChinhSua_KhangSinh()
        {
            if (gvKhangSinh.RowCount <= 0) return;
            if (gvKhangSinh.GetFocusedRow() == null) return;
            grbKhangSinhDanhSach.Enabled = false;
            grbKhangSinhThongTin.Enabled = true;
            txtKhangSinhMa.ForeColor = Color.Blue;
            txtKhangSinhMa.Focus();
        }
        private void Luu_KhangSinh()
        {
            if (string.IsNullOrEmpty(txtKhangSinhMa.Text))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập mã kháng sinh!");
                txtKhangSinhMa.Focus();
            }
            else if (cboKhangSinhNhom.SelectedIndex < 0)
            {
                CustomMessageBox.MSG_Error_OK("Hãy chọn nhóm kháng sinh!");
                cboKhangSinhNhom.Focus();
            }
            else if (string.IsNullOrEmpty(txtKhangSinhTen.Text))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập tên kháng sinh!");
                txtKhangSinhNhomTen.Focus();
            }
            else if (string.IsNullOrEmpty(txtKhangSinhSapXep.Text))
            {
                CustomMessageBox.MSG_Error_OK("Hãy nhập thứ tự sắp xếp!");
                txtKhangSinhSapXep.Focus();
            }
            else
            {
                if (txtKhangSinhMa.ForeColor == Color.DarkRed)
                {
                    _objInfoKhangSinh.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                    if (!_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(_objInfoKhangSinh)) return;
                    Load_DanhSachKhangSinh();
                    grbKhangSinhDanhSach.Enabled = true;
                }
                else if (grbKhangSinhThongTin.Enabled)
                {
                    if (gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh) == null) return;
                    string guidelineType = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_GuideLine).ToString();
                    string potency = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_Potency).ToString();
                    var objOld =
                        _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khangsinh(
                            gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh).ToString().Trim(),
                            string.Empty, guidelineType, potency);
                    _objInfoKhangSinh.Nguoisua = CommonAppVarsAndFunctions.UserID;
                    if (!_bacteriumAntibioticService.Update_dm_xetnghiem_khangsinh(_objInfoKhangSinh, objOld)) return;
                    Load_DanhSachKhangSinh();
                    grbKhangSinhDanhSach.Enabled = true;
                }
            }
        }
        private void Xoa_KhangSinh()
        {
            if (gvKhangSinh.RowCount <= 0) return;
            if (gvKhangSinh.GetFocusedRow() == null) return;
            if (gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh) == null) return;
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xoá danh mục kháng sinh đang chọn?")) return;
            string guidelineType = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_GuideLine).ToString();
            string potency = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_Potency).ToString();
            var objKhangSinh =
                _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khangsinh(
                    gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh).ToString().Trim(),
                    string.Empty, guidelineType, potency);
            objKhangSinh.Nguoinhap = CommonAppVarsAndFunctions.UserID;
            if (!_bacteriumAntibioticService.Delete_dm_xetnghiem_khangsinh(objKhangSinh)) return;
            Xoa_ThongTinKhangSinh();
            Load_DanhSachKhangSinh();
        }
        private void Load_DanhSachKhangSinh()
        {
            //ucAddEditKhangSinh.SetStatusButtonNormal();
            var checkFunction = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
              CommonAppVarsAndFunctions.PhanQuyenQuanLy,
              UserConstant.PermissionCategoriesManagementOfVS);
            ucAddEditKhangSinhNhom.SetStatusButtonFunction(CommonAppVarsAndFunctions.IsAdmin, checkFunction);
            var dt = _bacteriumAntibioticService.Data_dm_xetnghiem_khangsinh(string.Empty, string.Empty);
            gcKsVKChon.DataSource = dt.Copy();
            gvKsVKChon.ExpandAllGroups();
            var maNhom = (cboKhangSinhTimNhom.SelectedIndex > -1 ? string.Format("MaNhomKhangSinh = '{0}'", cboKhangSinhTimNhom.SelectedValue.ToString().Trim()) : string.Empty);
            if (!string.IsNullOrEmpty(txtKhangSinhTimTenVaMa.Text))
            {
                if (!string.IsNullOrEmpty(maNhom))
                    maNhom += string.Format(" and (MaKhangSinh = '{0}' or TenKhangSinh like '%{0}%')", txtKhangSinhTimTenVaMa.Text);
                else
                    maNhom += string.Format(" MaKhangSinh = '{0}' or TenKhangSinh like '%{0}%'", txtKhangSinhTimTenVaMa.Text);
            }
            dt = WorkingServices.SearchResult_OnDatatable_NoneSort(dt, maNhom);

            gcKhangSinh.DataSource = dt;
            gvKhangSinh.ExpandAllGroups();


            Load_DanhSachKSDKhangSinh();
            Load_DanhSach_QuiTrinh_KhangSinh();
        }
        private void CboQuiTrinh_DMKS_Nhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhSach_QuiTrinh_KhangSinh();
        }
        private void Load_DanhSach_QuiTrinh_KhangSinh()
        {
            var dt = _bacteriumAntibioticService.Data_dm_xetnghiem_khangsinh(string.Empty, string.Empty);
            var maNhom = (cboQuiTrinh_DMKS_Nhom.SelectedIndex > -1
                ? string.Format("MaNhomKhangSinh = '{0}'", cboQuiTrinh_DMKS_Nhom.SelectedValue.ToString().Trim())
                : string.Empty);
            if (!string.IsNullOrEmpty(txtQuiTrinh_DMKS_TimTenKS.Text))
            {
                if (!string.IsNullOrEmpty(maNhom))
                    maNhom += string.Format(" and (MaKhangSinh = '{0}' or TenKhangSinh like '%{0}%')",
                        txtQuiTrinh_DMKS_TimTenKS.Text);
                else
                    maNhom += string.Format(" MaKhangSinh = '{0}' or TenKhangSinh like '%{0}%'",
                        txtQuiTrinh_DMKS_TimTenKS.Text);
            }

            dt = WorkingServices.SearchResult_OnDatatable_NoneSort(dt, maNhom);

            gcQuiTrinh_DMKS.DataSource = dt;
            gvQuiTrinh_DMKS.ExpandAllGroups();

        }
        private void Load_DanhSachKSDKhangSinh()
        {
            var dt = _bacteriumAntibioticService.Data_dm_xetnghiem_khangsinh(string.Empty, string.Empty);
            gcBoKS_DanhSachKS.DataSource = dt;

        }
        private void Load_ThongTinKhangSinh()
        {
            if (gvKhangSinh.RowCount > 0)
            {
                if (gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh) != null)
                {
                    string maKhangSinh = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh).ToString();
                    string guidelineType = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_GuideLine).ToString();
                    string potency = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_Potency).ToString();

                    _objInfoKhangSinh = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khangsinh(maKhangSinh,
                        string.Empty, guidelineType, potency);
                    Xoa_ThongTinKhangSinh();
                    BindData_ThongTinKhangSinh();
                }
                else
                    Xoa_ThongTinKhangSinh();
            }
        }

        private void ogvKhangSinhDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_ThongTinKhangSinh();
        }

        private void ucAddEditKhangSinh_ButtonAddClick(object sender, EventArgs e)
        {
            ThemMoi_KhangSinh();
        }

        private void ucAddEditKhangSinh_ButtonCancelClick(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Huỷ thao tác?"))
            {
                Load_DanhSachKhangSinh();
            }
        }
        private void ucAddEditKhangSinh_ButtonDeleteClick(object sender, EventArgs e)
        {
            Xoa_KhangSinh();
        }

        private void ucAddEditKhangSinh_ButtonEditClick(object sender, EventArgs e)
        {
            ChinhSua_KhangSinh();
        }

        private void ucAddEditKhangSinh_ButtonSaveClick(object sender, EventArgs e)
        {
            Luu_KhangSinh();
        }
        private void btnKhangSinhLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhSachKhangSinh();
        }
        private void txtKhangSinhTimTenVaMa_KeyUp(object sender, KeyEventArgs e)
        {
            Load_DanhSachKhangSinh();
        }

        #endregion
        #region Phân loại vi khuẩn
        DM_XETNGHIEM_VIKHUAN _objInfoPhanLoaiViKhuan;
        private void Load_DonViPhanLoai()
        {
            cboViKhuanPhanLoaiDonVi.DataSource = Enum.GetValues(typeof(BacteriumCategory))
              .Cast<Enum>()
              .Select(value => new
              {
                  (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute).Description,
                  val = value.ToString(),
                  valint = value
              })
              .OrderBy(item => item.valint)
              .ToList();
            cboViKhuanPhanLoaiDonVi.DisplayMember = "Description";
            cboViKhuanPhanLoaiDonVi.ValueMember = "val";
            cboViKhuanPhanLoaiDonVi.SelectedIndex = -1;
        }
        private void Load_kyThuat()
        {
            var lstKyThuat = Enum.GetValues(typeof(BioTestMethod))
                 .Cast<Enum>()
                 .Select(value => new
                 {
                     (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString())
                     , typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute).Description,
                     val = value.ToString(),
                     valint = (int)(BioTestMethod)value
                 })
                 .OrderBy(item => item.valint)
                 .ToList();
            cboKyThuat.DataSource = lstKyThuat;
            cboKyThuat.DisplayMember = "Description";
            cboKyThuat.ValueMember = "val";
            cboKyThuat.SelectedIndex = -1;

            cboPanel_KyThuat.DataSource = lstKyThuat;
            cboPanel_KyThuat.DisplayMember = "Description";
            cboPanel_KyThuat.ValueMember = "val";
            cboPanel_KyThuat.SelectedIndex = -1;

            cboQuiTrinh_KyThuat.DataSource = lstKyThuat;
            cboQuiTrinh_KyThuat.DisplayMember = "Description";
            cboQuiTrinh_KyThuat.ValueMember = "val";
            cboQuiTrinh_KyThuat.SelectedIndex = -1;

            cboQuiTrinh_KyThuat.SelectedIndexChanged += CboQuiTrinh_KyThuat_SelectedIndexChanged;

            cboKyThuat_IP.DataSource = lstKyThuat;
            cboKyThuat_IP.DisplayMember = "Description";
            cboKyThuat_IP.ValueMember = "val";
            cboKyThuat_IP.SelectedIndex = -1;
        }

        private void Load_ToChucBreakpoint()
        {
            var lstToChuc = Enum.GetValues(typeof(ToChucBreakpoint))
                 .Cast<Enum>()
                 .Select(value => new
                 {
                     (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString())
                     , typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute).Description,
                     val = value.ToString(),
                     valint = (int)(ToChucBreakpoint)value
                 })
                 .OrderBy(item => item.valint)
                 .ToList();
            cboPanel_ToChuc.DataSource = lstToChuc;
            cboPanel_ToChuc.DisplayMember = "Description";
            cboPanel_ToChuc.ValueMember = "val";
            cboPanel_ToChuc.SelectedIndex = -1;

            //cboPanel_ToChuc.SelectedIndexChanged += cboPanel_ToChuc_SelectedIndexChanged;
        }

        private void CboQuiTrinh_KyThuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhSach_QuiTrinh();
        }
        private void Load_LoaiKetQua()
        {
            cboLoaiKetQua.DataSource = Enum.GetValues(typeof(LoaiKetQuaViKhuan))
              .Cast<Enum>()
              .Select(value => new
              {
                  (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString())
                  , typeof(System.ComponentModel.DescriptionAttribute)) as System.ComponentModel.DescriptionAttribute).Description,
                  val = value.ToString(),
                  valint = (int)(LoaiKetQuaViKhuan)value
              })
              .OrderBy(item => item.valint)
              .ToList();
            cboLoaiKetQua.DisplayMember = "Description";
            cboLoaiKetQua.ValueMember = "valint";
            cboLoaiKetQua.SelectedIndex = 0;
        }
        private void Xoa_ThongTinPhanLoaiViKhuan()
        {
            txtViKhuanMaPhanLoai.ForeColor = SystemColors.WindowText;
            Xoa_BinddingPhanLoaiViKhuan();
            txtViKhuanMaPhanLoai.Text = string.Empty;
            txtViKhuanTenPhanLoai.Text = string.Empty;
            txtViKhuanSapXep.Text = string.Empty;
            cboViKhuanPhanLoaiDonVi.SelectedIndex = -1;
            cboViKhuanPhanLoaiCapTren.SelectedIndex = -1;
            txtViKhuanDanhPhap.Text = string.Empty;
            txtViKhuanTenThuongGoi.Text = string.Empty;

            grbViKhuanThongTin.Enabled = false;
            treViKhuanDanhSachPhanLoai.Enabled = true;
            cboLoaiKetQua.SelectedValue = 0;
        }

        private void Xoa_BinddingPhanLoaiViKhuan()
        {
            txtViKhuanMaPhanLoai.DataBindings.Clear();
            txtViKhuanTenPhanLoai.DataBindings.Clear();
            txtViKhuanSapXep.DataBindings.Clear();
            cboViKhuanPhanLoaiDonVi.DataBindings.Clear();
            cboViKhuanPhanLoaiCapTren.DataBindings.Clear();
            txtViKhuanDanhPhap.DataBindings.Clear();
            txtViKhuanTenThuongGoi.DataBindings.Clear();
            cboLoaiKetQua.DataBindings.Clear();
        }
        private void BindData_ThongTinPhanLoaiViKhuan()
        {
            txtViKhuanMaPhanLoai.DataBindings.Add("Text", _objInfoPhanLoaiViKhuan,
        ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Maphanloai), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtViKhuanTenPhanLoai.DataBindings.Add("Text", _objInfoPhanLoaiViKhuan,
        ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Tenphanloai), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtViKhuanSapXep.DataBindings.Add("Text", _objInfoPhanLoaiViKhuan,
        ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Thutusapxep), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtViKhuanDanhPhap.DataBindings.Add("Text", _objInfoPhanLoaiViKhuan,
        ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Danhphap), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            txtViKhuanTenThuongGoi.DataBindings.Add("Text", _objInfoPhanLoaiViKhuan,
        ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Tenthuonggoi), true,
        DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            cboViKhuanPhanLoaiDonVi.SelectedValue = (_objInfoPhanLoaiViKhuan.Donviphanloai == null ? string.Empty : _objInfoPhanLoaiViKhuan.Donviphanloai);
            Load_DanhSachPhanLoaiCaptren();
            cboViKhuanPhanLoaiCapTren.SelectedValue = (_objInfoPhanLoaiViKhuan.Maphanloaicha == null ? string.Empty : _objInfoPhanLoaiViKhuan.Maphanloaicha);
            cboLoaiKetQua.SelectedValue = _objInfoPhanLoaiViKhuan.Loaiketqua;
        }
        private void Load_ThongTinPhanLoaiViKhuan()
        {
            if (treViKhuanDanhSachPhanLoai.SelectedNode != null)
            {
                string maLoaiVK = (treViKhuanDanhSachPhanLoai.SelectedNode.Name == null ? "-none-" : treViKhuanDanhSachPhanLoai.SelectedNode.Name);

                _objInfoPhanLoaiViKhuan = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_vikhuan(maLoaiVK);
                Xoa_ThongTinPhanLoaiViKhuan();
                BindData_ThongTinPhanLoaiViKhuan();

            }
        }
        private void Load_DanhSachPhanLoaiCaptren()
        {
            string donViCapTren = string.Empty;
            if (cboViKhuanPhanLoaiDonVi.SelectedIndex > -1)
            {
                if (!cboViKhuanPhanLoaiDonVi.SelectedValue.ToString().Equals(BacteriumCategory.order.ToString(), StringComparison.OrdinalIgnoreCase))
                {

                    if (cboViKhuanPhanLoaiDonVi.SelectedValue.ToString().Equals(BacteriumCategory.family.ToString(), StringComparison.OrdinalIgnoreCase))
                        donViCapTren = BacteriumCategory.order.ToString();
                    else if (cboViKhuanPhanLoaiDonVi.SelectedValue.ToString().Equals(BacteriumCategory.genus.ToString(), StringComparison.OrdinalIgnoreCase))
                        donViCapTren = BacteriumCategory.family.ToString();
                    else
                        donViCapTren = BacteriumCategory.genus.ToString();
                }
                else
                    donViCapTren = "none";

                DataTable dtMainSource = _bacteriumAntibioticService.Data_dm_xetnghiem_vikhuan(string.Empty, string.Empty, donViCapTren);
                ControlExtension.BindDataToCobobox(dtMainSource, ref cboViKhuanPhanLoaiCapTren, "MaPhanLoai", "MaPhanLoai", "MaPhanLoai, TenPhanLoai", "50, 250", txtViKhuanPhanLoaiCapTren, 1);
            }
        }
        private void Load_DanhSachPhanLoaiViKhuan(bool fromSearch = false)
        {
            ucAddEditViKhuan.SetStatusButtonNormal();
            DataTable dtMainSource = new DataTable();
            if (fromSearch && !string.IsNullOrEmpty(txtViKhuanTimMaVaTen.Text))
            {
                dtMainSource = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}' or MaPhanLoai = '{0}' or TenphanLoai like '%{0}%'", WorkingServices.EscapeLikeValue(txtViKhuanTimMaVaTen.Text)));
            }
            else
            {
                dtViKhuan = _bacteriumAntibioticService.Data_dm_xetnghiem_vikhuan(string.Empty);
                dtMainSource = dtViKhuan.Copy();
            }
            treViKhuanDanhSachPhanLoai.Nodes.Clear();
            treViKhuanDanhSachPhanLoai.ImageList = imageListBacteria;
            TreeNode mainNode = new TreeNode();
            mainNode.SelectedImageIndex = 5;
            mainNode.ImageIndex = 5;
            DataTable dtSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(dtMainSource, "MaPhanLoaiCha is null or MaPhanLoaiCha = ''");
            AddTreeView_PhanLoaiViKhuan(dtMainSource, dtSearch, ref mainNode);
            treViKhuanDanhSachPhanLoai.Nodes.Add(mainNode);
            treViKhuanDanhSachPhanLoai.ExpandAll();
            treViKhuanDanhSachPhanLoai.Enabled = true;

            if (!fromSearch)
                Load_DanhSachKSDPhanLoaiViKhuan();
        }

        private void AddTreeView_PhanLoaiViKhuan(DataTable dtMainSource, DataTable dtSource, ref TreeNode treNode)
        {
            bool nullSource = false;
            int iCount = -1;
            if (dtSource.Rows.Count == 0 && dtMainSource.Rows.Count > 0)
            {
                dtSource = dtMainSource.Copy();
                nullSource = true;
            }
            foreach (DataRow dr in dtSource.Rows)
            {
                iCount++;
                TreeNode node = new TreeNode();
                string maPhaLoai = dr[ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Maphanloai)].ToString().Trim();
                string donViPhanLoai = dr[ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Donviphanloai)].ToString().Trim();
                node.Name = maPhaLoai;
                node.Text = dr[ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Tenphanloai)].ToString().Trim();
                node.Tag = donViPhanLoai;
                if (donViPhanLoai.Equals(BacteriumCategory.order.ToString(), StringComparison.OrdinalIgnoreCase))
                    node.ImageIndex = 0;
                else if (donViPhanLoai.Equals(BacteriumCategory.family.ToString(), StringComparison.OrdinalIgnoreCase))
                    node.ImageIndex = 1;
                else if (donViPhanLoai.Equals(BacteriumCategory.genus.ToString(), StringComparison.OrdinalIgnoreCase))
                    node.ImageIndex = 2;
                else
                    node.ImageIndex = 3;
                node.SelectedImageIndex = 4;
                if (nullSource && dtMainSource.Rows.Count > 0)
                {
                    dtMainSource.Rows.RemoveAt(iCount);
                    iCount--;
                    dtMainSource.AcceptChanges();
                }
                DataTable dtSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(dtMainSource, string.Format("MaPhanLoaiCha = '{0}'", maPhaLoai));
                if (dtSearch.Rows.Count > 0)
                    AddTreeView_PhanLoaiViKhuan(dtMainSource, dtSearch, ref node);

                treNode.Nodes.Add(node);
            }
        }
        private void ThemMoi_PhanLoaiViKhuan()
        {
            Xoa_ThongTinPhanLoaiViKhuan();

            _objInfoPhanLoaiViKhuan = new DM_XETNGHIEM_VIKHUAN();
            BindData_ThongTinPhanLoaiViKhuan();

            grbViKhuanThongTin.Enabled = true;
            treViKhuanDanhSachPhanLoai.Enabled = false;

            txtViKhuanSapXep.Text = "1000";
            txtViKhuanMaPhanLoai.ForeColor = Color.DarkRed;
            cboViKhuanPhanLoaiDonVi.Focus();
        }
        private void ChinhSua_PhanLoaiViKhuan()
        {
            if (treViKhuanDanhSachPhanLoai.SelectedNode != null)
            {
                grbViKhuanThongTin.Enabled = true;
                treViKhuanDanhSachPhanLoai.Enabled = false;

                txtViKhuanMaPhanLoai.ForeColor = Color.Blue;
                txtViKhuanMaPhanLoai.Focus();
            }
        }
        private void Luu_PhanLoaiViKhuan()
        {
            string phanloai = string.Empty;
            if (cboViKhuanPhanLoaiDonVi.SelectedIndex < 0)
            {
                CustomMessageBox.MSG_Error_OK("Hãy chọn đơn vị phân loại!");
                cboViKhuanPhanLoaiDonVi.Focus();
            }
            else
            {
                phanloai = cboViKhuanPhanLoaiDonVi.Text.Trim();
                if (cboViKhuanPhanLoaiCapTren.SelectedIndex < 0 && !cboViKhuanPhanLoaiDonVi.SelectedValue.ToString().Equals(BacteriumCategory.order.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    CustomMessageBox.MSG_Error_OK("Hãy chọn phân loại cha!");
                    cboViKhuanPhanLoaiCapTren.Focus();
                }
                else if (string.IsNullOrEmpty(txtViKhuanMaPhanLoai.Text))
                {
                    CustomMessageBox.MSG_Error_OK(string.Format("Hãy nhập mã {0}!", phanloai));
                    txtViKhuanMaPhanLoai.Focus();
                }
                else if (string.IsNullOrEmpty(txtViKhuanTenPhanLoai.Text))
                {
                    CustomMessageBox.MSG_Error_OK(string.Format("Hãy nhập tên {0}!", phanloai));
                    txtViKhuanTenPhanLoai.Focus();
                }
                else if (string.IsNullOrEmpty(txtViKhuanSapXep.Text))
                {
                    CustomMessageBox.MSG_Error_OK("Hãy nhập thứ tự in!");
                    txtViKhuanSapXep.Focus();
                }
                else
                {
                    Xoa_BinddingPhanLoaiViKhuan();
                    _objInfoPhanLoaiViKhuan.Donviphanloai = cboViKhuanPhanLoaiDonVi.SelectedValue.ToString().Trim();
                    _objInfoPhanLoaiViKhuan.Maphanloaicha = cboViKhuanPhanLoaiCapTren.SelectedIndex > -1 ? cboViKhuanPhanLoaiCapTren.SelectedValue.ToString().Trim() : string.Empty;
                    _objInfoPhanLoaiViKhuan.Loaiketqua = int.Parse(cboLoaiKetQua.SelectedValue.ToString());
                    if (txtViKhuanMaPhanLoai.ForeColor == Color.DarkRed)
                    {
                        _objInfoPhanLoaiViKhuan.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                        if (_bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(_objInfoPhanLoaiViKhuan))
                        {
                            Load_DanhSachPhanLoaiViKhuan();
                        }
                    }
                    else if (grbViKhuanThongTin.Enabled)
                    {
                        DM_XETNGHIEM_VIKHUAN objOld = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_vikhuan(treViKhuanDanhSachPhanLoai.SelectedNode.Name.Trim());
                        _objInfoPhanLoaiViKhuan.Nguoisua = CommonAppVarsAndFunctions.UserID;
                        if (_bacteriumAntibioticService.Update_dm_xetnghiem_vikhuan(_objInfoPhanLoaiViKhuan, objOld))
                        {
                            Load_DanhSachPhanLoaiViKhuan();
                            // bvPhanLoaiViKhuanDanhSach.BindingSource.Position = bvPhanLoaiViKhuanDanhSach.BindingSource.Find(ControlExtension.PropertyName<DM_XETNGHIEM_VIKHUAN>(x => x.Manhomkhangsinh), txtViKhuanMaPhanLoai.Text);
                        }
                    }
                }
            }
        }
        private void Xoa_PhanLoaiViKhuan()
        {
            if (treViKhuanDanhSachPhanLoai.SelectedNode != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xoá danh mục phân loại?"))
                {
                    DM_XETNGHIEM_VIKHUAN objDelete = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_vikhuan(treViKhuanDanhSachPhanLoai.SelectedNode.Name.Trim());
                    if (_bacteriumAntibioticService.Delete_dm_xetnghiem_vikhuan(objDelete))
                    {
                        Xoa_ThongTinPhanLoaiViKhuan();
                        Load_DanhSachPhanLoaiViKhuan();
                    }
                }
            }
        }

        private void ucAddEditViKhuan_ButtonAddClick(object sender, EventArgs e)
        {
            ThemMoi_PhanLoaiViKhuan();
        }

        private void ucAddEditViKhuan_ButtonCancelClick(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Huỷ thao tác?"))
            {
                Load_DanhSachPhanLoaiViKhuan();
            }
        }

        private void ucAddEditViKhuan_ButtonDeleteClick(object sender, EventArgs e)
        {
            Xoa_PhanLoaiViKhuan();
        }

        private void ucAddEditViKhuan_ButtonEditClick(object sender, EventArgs e)
        {
            ChinhSua_PhanLoaiViKhuan();
        }

        private void ucAddEditViKhuan_ButtonSaveClick(object sender, EventArgs e)
        {
            Luu_PhanLoaiViKhuan();
        }

        private void cboViKhuanPhanLoaiDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboViKhuanPhanLoaiCapTren);
        }

        private void cboViKhuanPhanLoaiCapTren_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtViKhuanMaPhanLoai);
        }

        private void txtViKhuanMaPhanLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtViKhuanTenPhanLoai);
        }

        private void txtViKhuanTenPhanLoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboViKhuanPhanLoaiDonVi.SelectedIndex > -1)
                {
                    if (cboViKhuanPhanLoaiDonVi.SelectedValue.ToString().Equals(BacteriumCategory.species.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        txtViKhuanDanhPhap.Text = (string.IsNullOrEmpty(txtViKhuanPhanLoaiCapTren.Text) ? "" :
                            txtViKhuanPhanLoaiCapTren.Text.First().ToString().ToUpper() + String.Join("", txtViKhuanPhanLoaiCapTren.Text.Skip(1)))
                            + " " + txtViKhuanTenPhanLoai.Text.ToLower();
                    }
                    else
                        txtViKhuanSapXep.Focus();
                }
                else
                    txtViKhuanTenThuongGoi.Focus();
            }

        }

        private void txtViKhuanDanhPhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtViKhuanTenThuongGoi);
        }

        private void txtViKhuanTenThuongGoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtViKhuanSapXep);
        }

        private void cboViKhuanPhanLoaiDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
                Load_DanhSachPhanLoaiCaptren();
        }

        private void btnViKhuanLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhSachPhanLoaiViKhuan();
        }
        private void treViKhuanDanhSachPhanLoai_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Load_ThongTinPhanLoaiViKhuan();
        }
        private void txtViKhuanTimMaVaTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DanhSachPhanLoaiViKhuan(true);
                e.Handled = true;
            }
        }
        #endregion
        #region Kháng sinh đồ

        DM_XETNGHIEM_VIKHUAN_KHANGSINH _objInfoKhangSinhDo = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();
        private void Load_DanhSachKSDPhanLoaiViKhuan(bool fromSearch = false)
        {
            gcKSD_ViKhuan.DataSource = null;
            gcBKS_ViKhuan.DataSource = null;
            if (dtViKhuan.Rows.Count > 0)
            {
                DataTable dtMainSource = new DataTable();
                //  dtMainSource = dtViKhuan.Copy();

                var colMaOrder = string.Format("MaPhanLoai_{0}", BacteriumCategory.order.ToString());
                var colTenOrder = string.Format("TenPhanLoai_{0}", BacteriumCategory.order.ToString());


                var colMafamily = string.Format("MaPhanLoai_{0}", BacteriumCategory.family.ToString());
                var colTenfamily = string.Format("TenPhanLoai_{0}", BacteriumCategory.family.ToString());


                var colMagenus = string.Format("MaPhanLoai_{0}", BacteriumCategory.genus.ToString());
                var colTengenus = string.Format("TenPhanLoai_{0}", BacteriumCategory.genus.ToString());


                var colMaspecies = string.Format("MaPhanLoai_{0}", BacteriumCategory.species.ToString());
                var colTenspecies = string.Format("TenPhanLoai_{0}", BacteriumCategory.species.ToString());
                //Phan loai chi
                dtMainSource.Columns.Add(colMaOrder);
                dtMainSource.Columns.Add(colTenOrder);
                //Phan loai chi
                dtMainSource.Columns.Add(colMafamily);
                dtMainSource.Columns.Add(colTenfamily);
                //Phan loai họ
                dtMainSource.Columns.Add(colMagenus);
                dtMainSource.Columns.Add(colTengenus);
                //Phan loai họ
                dtMainSource.Columns.Add(colMaspecies);
                dtMainSource.Columns.Add(colTenspecies);

                DataTable dtSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, "MaPhanLoaiCha is null or MaPhanLoaiCha = ''");
                string maBo = string.Empty;
                string tenBo = string.Empty;
                string maHo = string.Empty;
                string tenHo = string.Empty;
                string maChi = string.Empty;
                string tenChi = string.Empty;
                string maLoai = string.Empty;
                string tenLoai = string.Empty;

                foreach (DataRow drOrder in dtSearch.Rows)
                {
                    maBo = drOrder["MaPhanLoai"].ToString();
                    tenBo = drOrder["TenPhanLoai"].ToString();
                    var drSource = dtMainSource.NewRow();
                    drSource[colMaOrder] = maBo;
                    drSource[colTenOrder] = tenBo;
                    //lấy toàn bộ con của bộ
                    var dataFamily = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maBo));
                    if (dataFamily.Rows.Count > 0)
                    {
                        foreach (DataRow drFamily in dataFamily.Rows)
                        {
                            maHo = drFamily["MaPhanLoai"].ToString();
                            tenHo = drFamily["TenPhanLoai"].ToString();
                            drSource = dtMainSource.NewRow();
                            drSource[colMaOrder] = maBo;
                            drSource[colTenOrder] = tenBo;
                            drSource[colMafamily] = maHo;
                            drSource[colTenfamily] = tenHo;

                            var dataGenus = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maHo));
                            if (dataGenus.Rows.Count > 0)
                            {
                                foreach (DataRow drGenus in dataGenus.Rows)
                                {
                                    maChi = drGenus["MaPhanLoai"].ToString();
                                    tenChi = drGenus["TenPhanLoai"].ToString();
                                    drSource = dtMainSource.NewRow();
                                    drSource[colMaOrder] = maBo;
                                    drSource[colTenOrder] = tenBo;
                                    drSource[colMafamily] = maHo;
                                    drSource[colTenfamily] = tenHo;
                                    drSource[colMagenus] = maChi;
                                    drSource[colTengenus] = tenChi;
                                    var dataSpices = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maChi));
                                    if (dataSpices.Rows.Count > 0)
                                    {
                                        foreach (DataRow drSpices in dataSpices.Rows)
                                        {
                                            maLoai = drSpices["MaPhanLoai"].ToString();
                                            tenLoai = drSpices["TenPhanLoai"].ToString();
                                            drSource = dtMainSource.NewRow();
                                            drSource[colMaOrder] = maBo;
                                            drSource[colTenOrder] = tenBo;
                                            drSource[colMafamily] = maHo;
                                            drSource[colTenfamily] = tenHo;
                                            drSource[colMagenus] = maChi;
                                            drSource[colTengenus] = tenChi;
                                            drSource[colMaspecies] = maLoai;
                                            drSource[colTenspecies] = tenLoai;
                                            dtMainSource.Rows.Add(drSource);
                                        }
                                    }
                                    else
                                        dtMainSource.Rows.Add(drSource);

                                }
                            }
                            else
                                dtMainSource.Rows.Add(drSource);

                        }
                    }
                    else
                        dtMainSource.Rows.Add(drSource);
                }
                gcKSD_ViKhuan.DataSource = dtMainSource;
                gcBKS_ViKhuan.DataSource = dtMainSource;
                gvKSD_ViKhuan.ExpandAllGroups();
                gvBKS_ViKhuan.ExpandAllGroups();
            }
        }
        private void Load_KhangSinhDoDanhSach()
        {
            string maLoaiVK = "-none-";
            if (gvKSD_ViKhuan.GetFocusedRowCellValue(colKSD_ViKhuan_MaPhanLoai_species) != null)
            {
                maLoaiVK = gvKSD_ViKhuan.GetFocusedRowCellValue(colKSD_ViKhuan_MaPhanLoai_species).ToString().Trim();
            }
            gcKhangDinhDo.DataSource = _bacteriumAntibioticService.Data_dm_xetnghiem_vikhuan_khangsinh(maLoaiVK, string.Empty, string.Empty);
            gvKhangSinhDo.ExpandAllGroups();
        }
        private void Them_KhangSinhDo_KhangSinh()
        {
            if (gvKsVKChon.SelectedRowsCount > 0)
            {
                string maLoaiVK = "-none-";
                if (gvKSD_ViKhuan.GetFocusedRowCellValue(colKSD_ViKhuan_MaPhanLoai_species) != null)
                {
                    maLoaiVK = gvKSD_ViKhuan.GetFocusedRowCellValue(colKSD_ViKhuan_MaPhanLoai_species).ToString().Trim();
                }
                if (maLoaiVK == "-none-")
                {
                    CustomMessageBox.MSG_Information_OK("Chỉ cho phép tạo kháng sinh đồ cho đơn vị phân loại: Loài!");
                }
                else if (cboKyThuat.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn kỹ thuật!");
                }
                else
                {
                    foreach (var item in gvKsVKChon.GetSelectedRows())
                    {
                        if (gvKsVKChon.GetRowCellValue(item, colKsVKChon_MaKhangSinh) != null)
                        {
                            _objInfoKhangSinhDo = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();
                            _objInfoKhangSinhDo.Makhangsinh = gvKsVKChon.GetRowCellValue(item, colKsVKChon_MaKhangSinh).ToString();
                            _objInfoKhangSinhDo.Guideline = string.Format("{0}{1}", (radCLSI.Checked ? "CLSI" : "EUCST"), dtpGuideLineYear.Value.ToString("yy"));
                            _objInfoKhangSinhDo.Mavikhuan = maLoaiVK;
                            _objInfoKhangSinhDo.Kythuat = cboKyThuat.SelectedValue.ToString();
                            //  _objInfoKhangSinhDo.CLSI_1_EUTSC_2 = (radCLSI.Checked ? 1 : 2);
                            // _objInfoKhangSinhDo.Year = int.Parse(dtpGuideLineYear.Value.ToString("yy"));
                            _objInfoKhangSinhDo.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                            _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan_khangsinh(_objInfoKhangSinhDo);
                        }
                    }
                    gcKsVKChon.Refresh();
                    Load_KhangSinhDoDanhSach();
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn kháng sinh!");
            }
        }
        private void Xoa_KhangSinhDo()
        {
            if (gvKhangSinhDo.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xoá kháng sinh của Vi Khuẩn đang chọn?"))
                {
                    var intList = gvKhangSinhDo.GetSelectedRows();
                    foreach (int i in intList)
                    {
                        if (gvKhangSinhDo.GetRowCellValue(i, colKSD_MaKhangSinh) != null)
                        {
                            _objInfoKhangSinhDo = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();
                            _objInfoKhangSinhDo.Makhangsinh = gvKhangSinhDo.GetRowCellValue(i, colKSD_MaKhangSinh).ToString().Trim();
                            _objInfoKhangSinhDo.Mavikhuan = gvKhangSinhDo.GetRowCellValue(i, colKSD_MaViKhuan).ToString().Trim();
                            _objInfoKhangSinhDo.Kythuat = gvKhangSinhDo.GetRowCellValue(i, colKSD_KyThuat).ToString().Trim();
                            _bacteriumAntibioticService.Delete_dm_xetnghiem_vikhuan_khangsinh(_objInfoKhangSinhDo);
                        }
                    }
                    Load_KhangSinhDoDanhSach();
                }
            }
        }
        private void CapNhat_KhangSinhDo(int rowIndex)
        {
            if (gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaKhangSinh) != null)
            {
                _objInfoKhangSinhDo = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();
                _objInfoKhangSinhDo.Makhangsinh =
                    gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaKhangSinh).ToString().Trim();
                _objInfoKhangSinhDo.Guideline =
                    gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_GuideLine).ToString().Trim();
                _objInfoKhangSinhDo.Mavikhuan =
                    gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaViKhuan).ToString().Trim();
                _objInfoKhangSinhDo.Nguoisua = CommonAppVarsAndFunctions.UserID;
                _objInfoKhangSinhDo.Donvitinh =
                    gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_DonViTinh).ToString().Trim();
                _objInfoKhangSinhDo.Mabangkhangsinh =
                   gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaNhomKhangSinh).ToString().Trim();
                _objInfoKhangSinhDo.Kythuat =
                  gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_KyThuat).ToString().Trim();
                _objInfoKhangSinhDo.Mabangkhangsinh =
        gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_MaNhomKhangSinh).ToString().Trim();
                //còn kỹ thuật
                if (!string.IsNullOrEmpty(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanKhang).ToString().Trim()))
                    _objInfoKhangSinhDo.Cankhang =
                        float.Parse(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanKhang).ToString().Trim());
                if (!string.IsNullOrEmpty(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanNhay).ToString().Trim()))
                    _objInfoKhangSinhDo.Cannhay =
                        float.Parse(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanNhay).ToString().Trim());
                if (
                    !string.IsNullOrEmpty(
                        gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianTren).ToString().Trim()))
                    _objInfoKhangSinhDo.Cantrunggiantren =
                        float.Parse(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianTren).ToString().Trim());
                if (
                    !string.IsNullOrEmpty(
                        gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianDuoi).ToString().Trim()))
                    _objInfoKhangSinhDo.Cantrunggianduoi =
                        float.Parse(gvKhangSinhDo.GetRowCellValue(rowIndex, colKSD_CanTrungGianDuoi).ToString().Trim());
                if (_bacteriumAntibioticService.Update_dm_xetnghiem_vikhuan_khangsinh(_objInfoKhangSinhDo))
                {
                    gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_NguoiSua, CommonAppVarsAndFunctions.UserID);
                    gvKhangSinhDo.SetRowCellValue(rowIndex, colKSD_GioSua, DateTime.Now);
                }
            }
        }
        private void btnKSDTimKS_Click(object sender, EventArgs e)
        {
            Load_DanhSachKSDKhangSinh();
        }
        private void txtKSDTimMaVaTenKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            Load_DanhSachKSDKhangSinh();
            e.Handled = true;
        }
        private void treKSDViKhuan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Load_KhangSinhDoDanhSach();
        }

        private void btnKSDThem_Click(object sender, EventArgs e)
        {
            Them_KhangSinhDo_KhangSinh();
        }

        private void btnKSDXoa_Click(object sender, EventArgs e)
        {
            Xoa_KhangSinhDo();
        }
        private void gvKhangSinhDo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gvKhangSinhDo.CellValueChanged -= gvKhangSinhDo_CellValueChanged;
            CapNhat_KhangSinhDo(e.RowHandle);
            gvKhangSinhDo.CellValueChanged += gvKhangSinhDo_CellValueChanged;
        }
        private void gvKSD_ViKhuan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_KhangSinhDoDanhSach();
        }
        #endregion
        #region Khảo sát
        private void Xoa_ThongTin_KhaoSat()
        {
            txtKhaoSatMa.Text = string.Empty;
            txtKhaoSatTen.Text = string.Empty;
            txtKhaoSatMaCOn.Text = string.Empty;
            chkKhaoSatProfile.Checked = false;
        }
        private void ThemMoi_KhaoSat()
        {
            Xoa_ThongTin_KhaoSat();
            grdKhaoSat.Enabled = false;
            pnThongTinKhaoSat.Enabled = true;
            txtKhaoSatMa.ForeColor = Color.DarkRed;
            txtKhaoSatMa.Focus();
        }
        private void ChinhSua_KhaoSat()
        {
            if (gvKhaoSat.SelectedRowsCount > 0)
            {
                grdKhaoSat.Enabled = false;
                pnThongTinKhaoSat.Enabled = true;
                txtKhaoSatMa.ForeColor = Color.Blue;
                txtKhaoSatMa.Focus();
            }
        }
        private void BindData_ThongTinKhaoSat()
        {
            Xoa_ThongTin_KhaoSat();
            if (gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat) != null)
            {
                var objInfo = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe(gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat).ToString());
                txtKhaoSatMa.Text = objInfo.Makhaosat;
                txtKhaoSatTen.Text = objInfo.Tenkhaosat;
                txtKhaoSatMaCOn.Text = objInfo.Makhaosatcon;
                chkKhaoSatProfile.Checked = objInfo.Khaosatprofile;
                ucAddEditKhaoSat.SetStatusButtonNormal();
                pnThongTinKhaoSat.Enabled = false;
            }
        }
        private void Load_DanhMucKhaoSat()
        {
            gvKhaoSat.FocusedRowChanged -= gvKhaoSat_FocusedRowChanged;
            pnThongTinKhaoSat.Enabled = true;
            grdKhaoSat.Enabled = true;
            grdKhaoSat.DataSource = _bacteriumAntibioticService.Data_dm_xetnghiem_khaosatdaithe(string.Empty);
            gvKetQuaKhaoSat.ExpandAllGroups();
            gvKetQuaKhaoSat.BestFitColumns();
            gvKhaoSat.FocusedRowChanged += gvKhaoSat_FocusedRowChanged;
            BindData_ThongTinKhaoSat();
            Load_DanhMucKetQuaKhaoSat();
        }
        private void Luu_KhaoSat()
        {
            bool isInsert = txtKhaoSatMa.ForeColor == Color.DarkRed;
            if (string.IsNullOrEmpty(txtKhaoSatMa.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã khảo sát!");
            else if (string.IsNullOrEmpty(txtKhaoSatTen.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập tên khảo sát!");
            else if (chkKhaoSatProfile.Checked && string.IsNullOrEmpty(txtKhaoSatMaCOn.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập nhập mã con của profile này.");
            else
            {
                if (isInsert)
                {
                    if (_bacteriumAntibioticService.Insert_dm_xetnghiem_khaosatdaithe(new DM_XETNGHIEM_KHAOSATDAITHE(
                        txtKhaoSatMa.Text, txtKhaoSatTen.Text, txtKhaoSatMaCOn.Text, chkKhaoSatProfile.Checked)))
                        Load_DanhMucKhaoSat();
                }
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thay đổi?"))
                {
                    var oldObject = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe(gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat).ToString());
                    if (_bacteriumAntibioticService.Update_dm_xetnghiem_khaosatdaithe(new DM_XETNGHIEM_KHAOSATDAITHE(
                        txtKhaoSatMa.Text, txtKhaoSatTen.Text, txtKhaoSatMaCOn.Text, chkKhaoSatProfile.Checked), oldObject))
                        Load_DanhMucKhaoSat();
                }
            }

        }
        private void Xoa_KhaoSat()
        {
            if (gvKhaoSat.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khảo sát đang chọn?"))
                {
                    if (_bacteriumAntibioticService.Delete_dm_xetnghiem_khaosatdaithe(_bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe(gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat).ToString())))
                        Load_DanhMucKhaoSat();
                }
            }
        }
        private void gvKhaoSat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindData_ThongTinKhaoSat();
            Load_DanhMucKetQuaKhaoSat();
        }
        private void ucAddEditKhaoSat_ButtonAddClick(object sender, EventArgs e)
        {
            ThemMoi_KhaoSat();
        }

        private void ucAddEditKhaoSat_ButtonDeleteClick(object sender, EventArgs e)
        {
            Xoa_KhaoSat();
        }

        private void ucAddEditKhaoSat_ButtonCancelClick(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Huỷ thao tác?"))
            {
                Load_DanhMucKhaoSat();
            }
        }

        private void ucAddEditKhaoSat_ButtonEditClick(object sender, EventArgs e)
        {
            ChinhSua_KhaoSat();
        }

        private void ucAddEditKhaoSat_ButtonSaveClick(object sender, EventArgs e)
        {
            Luu_KhaoSat();
        }

        private void txtKhaoSatMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKhaoSatTen);
        }

        private void txtKhaoSatTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, chkKhaoSatProfile);
        }

        private void chkKhaoSatProfile_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKhaoSatMaCOn);
        }
        #endregion
        #region Kết quả khảo sát
        private void Xoa_ThongTin_KetQuaKhaoSat()
        {
            txtKhaoSatKetQua.Text = string.Empty;
        }
        private void ThemMoi_KetQuaKhaoSat()
        {
            Xoa_ThongTin_KetQuaKhaoSat();
            grdKetQuaKhaoSat.Enabled = false;
            pnKetQuaKhaoSat.Enabled = true;
            txtKhaoSatKetQua.ForeColor = Color.DarkRed;
            txtKhaoSatKetQua.Focus();
        }
        private void ChinhSua_KetQuaKhaoSat()
        {
            if (gvKhaoSat.SelectedRowsCount > 0)
            {
                grdKetQuaKhaoSat.Enabled = false;
                pnKetQuaKhaoSat.Enabled = true;
                txtKhaoSatKetQua.ForeColor = Color.Blue;
                txtKhaoSatKetQua.Focus();
            }
        }
        private void BindData_ThongTinKetQuaKhaoSat()
        {
            Xoa_ThongTin_KetQuaKhaoSat();
            if (gvKetQuaKhaoSat.SelectedRowsCount > 0)
            {
                var objInfo = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(gvKetQuaKhaoSat.GetRowCellValue(gvKetQuaKhaoSat.FocusedRowHandle, colKSKqMaKetqua).ToString());
                txtKhaoSatKetQua.Text = objInfo.Ketquakhaosat;
                ucAddEditKhaoSat.SetStatusButtonNormal();
                pnKetQuaKhaoSat.Enabled = false;
            }
        }
        private void Load_DanhMucKetQuaKhaoSat()
        {
            if (gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat) != null)
            {
                gvKetQuaKhaoSat.FocusedRowChanged -= gvKetQuaKhaoSat_FocusedRowChanged;
                pnKetQuaKhaoSat.Enabled = false;
                grdKetQuaKhaoSat.Enabled = true;
                grdKetQuaKhaoSat.DataSource = _bacteriumAntibioticService.Data_dm_xetnghiem_khaosatdaithe_ketqua(string.Empty
                    , gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat).ToString());
                gvKetQuaKhaoSat.ExpandAllGroups();
                gvKetQuaKhaoSat.BestFitColumns();
                gvKetQuaKhaoSat.FocusedRowChanged += gvKetQuaKhaoSat_FocusedRowChanged;
                BindData_ThongTinKetQuaKhaoSat();
            }
        }
        private void Luu_KetQuaKhaoSat()
        {
            bool isInsert = txtKhaoSatKetQua.ForeColor == Color.DarkRed;
            if (string.IsNullOrEmpty(txtKhaoSatKetQua.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập kết quả khảo sát!");
            else
            {
                if (isInsert)
                {
                    var objKhaoSat = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe(gvKhaoSat.GetRowCellValue(gvKhaoSat.FocusedRowHandle, coldmksMaKhaoSat).ToString());
                    if (_bacteriumAntibioticService.Insert_dm_xetnghiem_khaosatdaithe_ketqua(new DM_XETNGHIEM_KHAOSATDAITHE_KETQUA
                        (-1, objKhaoSat.Makhaosat, txtKhaoSatKetQua.Text)))
                        Load_DanhMucKetQuaKhaoSat();
                }
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thay đổi?"))
                {
                    var oldObject = _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(gvKetQuaKhaoSat.GetRowCellValue(gvKetQuaKhaoSat.FocusedRowHandle, colKSKqMaKetqua).ToString());
                    if (_bacteriumAntibioticService.Update_dm_xetnghiem_khaosatdaithe_ketqua(new DM_XETNGHIEM_KHAOSATDAITHE_KETQUA
                        (oldObject.Autoid, oldObject.Makhaosat, txtKhaoSatKetQua.Text), oldObject))
                        Load_DanhMucKetQuaKhaoSat();
                }
            }

        }
        private void Xoa_KetQuaKhaoSat()
        {
            if (gvKetQuaKhaoSat.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kết quả khảo sát đang chọn?"))
                {
                    if (_bacteriumAntibioticService.Delete_dm_xetnghiem_khaosatdaithe_ketqua(
                         _bacteriumAntibioticService.Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(
                             gvKetQuaKhaoSat.GetRowCellValue(gvKetQuaKhaoSat.FocusedRowHandle, colKSKqMaKetqua).ToString())))
                        Load_DanhMucKetQuaKhaoSat();
                }
            }
        }

        private void ucAddEditKetQuaKhaoSat_ButtonAddClick(object sender, EventArgs e)
        {
            ThemMoi_KetQuaKhaoSat();
        }

        private void ucAddEditKetQuaKhaoSat_ButtonCancelClick(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Huỷ thao tác?"))
            {
                Load_DanhMucKetQuaKhaoSat();
            }
        }

        private void ucAddEditKetQuaKhaoSat_ButtonDeleteClick(object sender, EventArgs e)
        {
            Xoa_KetQuaKhaoSat();
        }

        private void ucAddEditKetQuaKhaoSat_ButtonEditClick(object sender, EventArgs e)
        {
            ChinhSua_KetQuaKhaoSat();
        }

        private void ucAddEditKetQuaKhaoSat_ButtonSaveClick(object sender, EventArgs e)
        {
            Luu_KetQuaKhaoSat();
        }

        private void gvKetQuaKhaoSat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindData_ThongTinKetQuaKhaoSat();
        }

        private void btnRefreshKhaoSat_Click(object sender, EventArgs e)
        {
            Load_DanhMucKhaoSat();
        }
        #endregion
        #region Danh mục bảng kháng sinh
        private void Load_DanhSach_BangKhangSinh()
        {
            var dataBangKS = _bacteriumAntibioticService.Data_dm_xetnghiem_visinh_bo(string.Empty);
            gcBangKhangSinh.DataSource = dataBangKS;
        }
        private void Insert_BangKhangSinh()
        {
            if (string.IsNullOrEmpty(txtBoKhangSinh_MaBo.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã bảng kháng sinh!");
            }
            else if (string.IsNullOrEmpty(txtBoKhangSinh_TenBo.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập tên bảng kháng sinh!");
            }
            else
            {
                var obj = new DM_XETNGHIEM_VISINH_BO();
                obj.Mabokhangsinh = txtBoKhangSinh_MaBo.Text;
                obj.Tenbokhangsinh = txtBoKhangSinh_TenBo.Text;
                var ok = _bacteriumAntibioticService.Insert_dm_xetnghiem_visinh_bo(obj);
                if (ok.Id == -1)
                {
                    CustomMessageBox.MSG_Information_OK(ok.Name);
                }
                else
                {
                    txtBoKhangSinh_MaBo.Text = string.Empty;
                    txtBoKhangSinh_TenBo.Text = string.Empty;
                    Load_DanhSach_BangKhangSinh();
                }
            }
        }
        private void Update_BangKhangSinhDo(int rowIndex)
        {
            if (gvBangKhangSinh.GetRowCellValue(rowIndex, colBangKhangSinh_MaBangKhangSinh) != null)
            {
                var objUpdate = new DM_XETNGHIEM_VISINH_BO();
                objUpdate.Mabokhangsinh = gvBangKhangSinh.GetRowCellValue(rowIndex, colBangKhangSinh_MaBangKhangSinh).ToString();
                objUpdate.Tenbokhangsinh = gvBangKhangSinh.GetRowCellValue(rowIndex, colBangKhangSinh_TenBangKhangSinh).ToString();
                if (_bacteriumAntibioticService.Update_dm_xetnghiem_visinh_bo(objUpdate))
                {
                    Load_DanhSach_BangKhangSinh();
                }
            }
        }
        private void Delete_BangKhangSinhDo()
        {
            if (gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_MaBangKhangSinh) != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa bảng kháng sinh đang chọn?"))
                {
                    var objUpdate = new DM_XETNGHIEM_VISINH_BO();
                    objUpdate.Mabokhangsinh = gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_MaBangKhangSinh).ToString();
                    objUpdate.Tenbokhangsinh = gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_TenBangKhangSinh).ToString();
                    if (_bacteriumAntibioticService.Delete_dm_xetnghiem_visinh_bo(objUpdate))
                    {
                        Load_DanhSach_BangKhangSinh();
                    }
                }
            }
        }
        private void btnbangKhangSinh_ThemBang_Click(object sender, EventArgs e)
        {
            Insert_BangKhangSinh();
        }
        private void btnbangKhangSinh_XoaBang_Click(object sender, EventArgs e)
        {
            Delete_BangKhangSinhDo();
        }
        private void gvBangKhangSinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Update_BangKhangSinhDo(e.RowHandle);
        }
        #endregion
        #region Danh mục bảng kháng sinh - chi tiết kháng sinh
        private void btnBangKhangSinh_ThemKS_Click(object sender, EventArgs e)
        {
            CustomMessageBox.ShowAlert("Đang import Antibiotic Panel...");
            Insert_ChiTietBangKhangSinh();
            CustomMessageBox.CloseAlert();

        }

        private void Insert_ChiTietBangKhangSinh()
        {
            if (gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_MaBangKhangSinh) == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn mã bảng kháng sinh!");
                return;
            }
            if (gvBoKS_DanhSachKS.SelectedRowsCount == 0)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn mã kháng sinh!");
                return;
            }
            if (gvBKS_ViKhuan.SelectedRowsCount == 0)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn mã loài!");
                return;
            }
            if (cboPanel_ToChuc.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn tổ chức!");
                return;
            }
            if (cboPanel_KyThuat.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn kỹ thuật!");
                return;
            }

            //đếm số dòng được check
            //lấy array dòng được check
            var arrKsChecked = gvBoKS_DanhSachKS.GetSelectedRows();
            var arrChecked = gvBKS_ViKhuan.GetSelectedRows();
            List<string> lstVSNotBreak = new List<string>();
            foreach (var iKsRow in arrKsChecked)
            {
                if (gvBoKS_DanhSachKS.GetRowCellValue(iKsRow, colBoKS_MaKhangSinh) == null) continue;
                foreach (var iRow in arrChecked)
                {
                    //phải kiểm tra giá trị lấy ra theo index có bị null không vì các dòng group có index < 0 nên sẽ null 
                    if (gvBKS_ViKhuan.GetRowCellValue(iRow, colBKS_ViKhuan_MaLoai) == null) continue;

                    var maboKhangSinh = gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_MaBangKhangSinh).ToString();
                    var maKhangSinh = gvBoKS_DanhSachKS.GetRowCellValue(iKsRow, colBoKS_MaKhangSinh).ToString().Trim();
                    var potency = string.Empty;
                    if (gvBoKS_DanhSachKS.GetRowCellValue(iKsRow, colBoKS_Potency) != null)
                    {
                        potency = gvBoKS_DanhSachKS.GetRowCellValue(iKsRow, colBoKS_Potency).ToString().Trim();
                    }

                    var maViKhuan = gvBKS_ViKhuan.GetRowCellValue(iRow, colBKS_ViKhuan_MaLoai).ToString().Trim();
                    var guideline = string.Empty;
                    var guideLineType = cboPanel_ToChuc.SelectedValue.ToString().Trim();
                    var gionhap = DateTime.Now;
                    var nguoinhap = CommonAppVarsAndFunctions.UserID;
                    var kyThuat = cboPanel_KyThuat.SelectedValue.ToString().ToUpper();
                    //Nếu kỹ thuật là MIC và etest thì không lấy potency
                    if (kyThuat.Equals("MIC", StringComparison.OrdinalIgnoreCase) ||
                        kyThuat.Equals("ETEST", StringComparison.OrdinalIgnoreCase))
                        potency = string.Empty;
                    //Kiểm tra qua 2 bảng vikhuan_khangsinh và khangsinh lấy ra BP
                    var dt = _bacteriumAntibioticService.Get_Info_KS_KSD(maViKhuan, maKhangSinh, kyThuat, guideline,
                        potency, guideLineType);

                    var objInfo = new DM_XETNGHIEM_KHANGSINH_BO_CHITIET();
                    objInfo.Gionhap = gionhap;
                    objInfo.Nguoinhap = nguoinhap;
                    objInfo.Mabokhangsinh = maboKhangSinh;
                    objInfo.Potency = string.Empty;
                    objInfo.Siteinfection = string.Empty;
                    objInfo.Mavikhuan = maViKhuan;
                    objInfo.Makhangsinh = maKhangSinh;
                    objInfo.Kythuat = kyThuat;

                    //Nếu dấu không duoc check
                    if (!chkBreakpoint.Checked)
                    {
                   
                        if (dt.Rows.Count > 0)
                        {
                            #region Insert vào khi không check checkbox
                            if (dt.Columns.Contains("MaViKhuan") && dt.Rows.Count > 0)
                            {
                                for (var i = 0; i < dt.Rows.Count; i++)
                                {
                                    objInfo.Guideline = StringConverter.ToString(dt.Rows[i]["GuideLine"]);

                                    //là bảng vikhuan_khangsinh
                                    if (NumberConverter.To<float>(dt.Rows[i]["CanNhay"]) == 0)
                                        objInfo.Cannhay = null;
                                    else
                                        objInfo.Cannhay = NumberConverter.To<float>(dt.Rows[i]["CanNhay"]);
                                    //objInfo.CanNhay= NumberConverter.To<float>(dt.Rows[i]["CanNhay"]) == 0 ? null : NumberConverter.To<float>(dt.Rows[i]["CanNhay"]);
                                    if (NumberConverter.To<float>(dt.Rows[i]["CanKhang"]) == 0)
                                        objInfo.Cankhang = null;
                                    else
                                        objInfo.Cankhang = NumberConverter.To<float>(dt.Rows[i]["CanKhang"]);
                                    if (NumberConverter.To<float>(dt.Rows[i]["CanTrungGianDuoi"]) == 0)
                                        objInfo.Cantrunggianduoi = null;
                                    else
                                        objInfo.Cantrunggianduoi = NumberConverter.To<float>(dt.Rows[i]["CanTrungGianDuoi"]);
                                    if (NumberConverter.To<float>(dt.Rows[i]["CanTrungGianTren"]) == 0)
                                        objInfo.Cantrunggiantren = null;
                                    else
                                        objInfo.Cantrunggiantren = NumberConverter.To<float>(dt.Rows[i]["CanTrungGianTren"]);

                                    //Nếu kỹ thuật là DISK thì lấy potency
                                    if (objInfo.Kythuat.Equals("DISK", StringComparison.OrdinalIgnoreCase))
                                        objInfo.Potency = StringConverter.ToString(dt.Rows[i]["Potency"]);

                                    objInfo.Siteinfection = StringConverter.ToString(dt.Rows[i]["SiteInfection"]);
                                    var ok = _bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
                                    if (ok.Id == -1)
                                        CustomMessageBox.MSG_Information_OK(ok.Name);
                                    else
                                        Load_DanhSach_ChiTietBangKhangSinh();
                                }

                            }
                            else if (dt.Columns.Contains("MaNhomKhangSinh") && dt.Rows.Count > 0)
                            {
                                float? CLSI_DR = null;
                                var CLSI_DI = string.Empty;
                                float? CLSI_DS = null;
                                float? CLSI_MIC_R = null;
                                float? CLSI_MIC_S = null;
                                //objInfo.MaViKhuan = string.Empty;
                                //objInfo.Potency = potency;
                                //là bảng kháng sinh
                                objInfo.Makhangsinh = StringConverter.ToString(dt.Rows[0]["MaKhangSinh"]);
                                objInfo.Guideline = StringConverter.ToString(dt.Rows[0]["GuideLineType"]);
                                var objInfo2 = objInfo.Copy();
                                if (!string.IsNullOrEmpty(dt.Rows[0]["CLSI_DR"].ToString()))
                                    CLSI_DR = NumberConverter.To<float>(dt.Rows[0]["CLSI_DR"]);
                                //if (!string.IsNullOrEmpty(dt.Rows[0]["CLSI_DI"].ToString()))
                                CLSI_DI = StringConverter.ToString(dt.Rows[0]["CLSI_DI"]);
                                if (!string.IsNullOrEmpty(dt.Rows[0]["CLSI_DS"].ToString()))
                                    CLSI_DS = NumberConverter.To<float>(dt.Rows[0]["CLSI_DS"]);
                                if (!string.IsNullOrEmpty(dt.Rows[0]["CLSI_MIC_R"].ToString()))
                                    CLSI_MIC_R = NumberConverter.To<float>(dt.Rows[0]["CLSI_MIC_R"]);
                                if (!string.IsNullOrEmpty(dt.Rows[0]["CLSI_MIC_S"].ToString()))
                                    CLSI_MIC_S = NumberConverter.To<float>(dt.Rows[0]["CLSI_MIC_S"]);
                                //Insert DISK
                                if ((CLSI_DR != null || CLSI_DS != null) && kyThuat == "DISK")
                                {
                                    //Kỹ thuật DISK mới có Potency
                                    objInfo.Kythuat = "DISK";
                                    objInfo.Potency = potency;
                                    objInfo.Cannhay = CLSI_DS;
                                    objInfo.Cankhang = CLSI_DR;
                                    if (!string.IsNullOrEmpty(CLSI_DI))
                                    {
                                        var t_d = CLSI_DI.Split('-');
                                        if (!string.IsNullOrEmpty(t_d[0]))
                                            objInfo.Cantrunggianduoi = float.Parse(t_d[0]);
                                        if (!string.IsNullOrEmpty(t_d[1]))
                                            objInfo.Cantrunggiantren = float.Parse(t_d[1]);
                                    }
                                    _bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
                                }
                                //Insert MIC
                                if ((CLSI_MIC_R != null || CLSI_MIC_S != null) && (kyThuat == "MIC" || kyThuat == "ETEST"))
                                {
                                    objInfo2.Kythuat = kyThuat;
                                    objInfo2.Cannhay = CLSI_MIC_S;
                                    objInfo2.Cankhang = CLSI_MIC_R;
                                    _bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo2);
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            lstVSNotBreak.Add(maKhangSinh);

                            continue;
                        }
                    }
                    // Nếu được check
                    else if (chkBreakpoint.Checked)
                    {
                        var siteInfection = StringConverter.ToString(cboPanel_Site_INF.SelectedValue);
                        objInfo.Guideline = string.Format("{0}{1}",
                                StringConverter.ToString(cboPanel_ToChuc.SelectedValue)
                                , dtpBKS_GuideLineYear.Value.ToString("yy").Trim());
                        objInfo.Siteinfection = siteInfection;
                        //Lấy cái BP ra so sánh, nếu SF = với SF chọn thì đã có BP này
                        if (dt.Rows.Count > 0)
                        {
                            //Loop kiem tra cái dt có cái nào chứa SF chưa
                            for (var i = 0; i < dt.Rows.Count; i++)
                            {
                                var siteIFWhonet = StringConverter.ToString(dt.Rows[i]["SiteInfection"]);
                                if (siteInfection.Equals(siteIFWhonet, StringComparison.OrdinalIgnoreCase))
                                {
                                    CustomMessageBox.MSG_Information_OK(string.Format("Mã kháng sinh \"{0}\" đã có trong WHONET!", objInfo.Makhangsinh));
                                    //return;
                                }
                                else
                                {
                                    _bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
                                }
                            }
                        }
                        //ngược lại thì insert vào
                        else
                        {
                            _bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
                        }
                    }


                    //else if (chkBreakpoint.Checked)
                    //{
                    //    #region Insert vào khi checkbox được check
                    //    //Ở đây phải check luôn cái SF xem đã ton tai chưa
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        CustomMessageBox.MSG_Information_OK(FormDanhMucViSinhConstant.CoBP_WHONET);
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        objInfo.GuideLine = string.Format("{0}{1}", StringConverter.ToString(cboPanel_ToChuc.SelectedValue)
                    //        , dtpBKS_GuideLineYear.Value.ToString("yy").Trim());
                    //        objInfo.SiteInfection = StringConverter.ToString(cboPanel_Site_INF.SelectedValue);
                    //        _bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh_bo_chitiet(objInfo);
                    //    }
                    //    #endregion
                    //}
                }
            }
            if(lstVSNotBreak.Count >0)
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Không có Breakpoint cho mã kháng sinh {0}", string.Join(", ", lstVSNotBreak)));
            }
            Load_DanhSach_ChiTietBangKhangSinh();
        }
        private void Delete_ChiBangKhangSinh()
        {
            if (gvBosKS_ChiTiet.SelectedRowsCount <= 0) return;
            var icount = gvBosKS_ChiTiet.GetSelectedRows();
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các kháng sinh được chọn khỏi danh sách?")) return;
            foreach (var i in icount)
            {
                if (string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(i, "MaBoKhangSinh").ToString())) continue;
                var maboKhangSinh = gvBosKS_ChiTiet.GetRowCellValue(i, "MaBoKhangSinh").ToString();
                var maKhangSinh = gvBosKS_ChiTiet.GetRowCellValue(i, "MaKhangSinh").ToString();
                var maViKhuan = gvBosKS_ChiTiet.GetRowCellValue(i, "MaViKhuan").ToString();
                var kyThuat = gvBosKS_ChiTiet.GetRowCellValue(i, "KyThuat").ToString();
                var guideLine = gvBosKS_ChiTiet.GetRowCellValue(i, "GuideLine").ToString();
                var siteInfection = gvBosKS_ChiTiet.GetRowCellValue(i, "SiteInfection").ToString();


                var ok = _bacteriumAntibioticService.Delete_dm_xetnghiem_khangsinh_bo_chitiet(new DM_XETNGHIEM_KHANGSINH_BO_CHITIET(
                    maboKhangSinh, maKhangSinh, maViKhuan, kyThuat, guideLine, null, null, null, null, new DateTime(), "", null, "", "", siteInfection));
            }
            Load_DanhSach_ChiTietBangKhangSinh();
        }
        private void Load_DanhSach_ChiTietBangKhangSinh()
        {
            gcBosKS_ChiTiet.DataSource = null;
            if (chkXemTatCaChiTietPanel.Checked)
            {
                var data = _bacteriumAntibioticService.Data_dm_xetnghiem_khangsinh_bo_chitiet(string.Empty, string.Empty);
                gcBosKS_ChiTiet.DataSource = data;
            }
            else
            {
                if (gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_MaBangKhangSinh) != null)
                {
                    var maboKhangSinh = gvBangKhangSinh.GetFocusedRowCellValue(colBangKhangSinh_MaBangKhangSinh).ToString();
                    var data = _bacteriumAntibioticService.Data_dm_xetnghiem_khangsinh_bo_chitiet(maboKhangSinh, string.Empty);
                    gcBosKS_ChiTiet.DataSource = data;
                }
            }
        }
        private void btnBangKhangSinh_XoaKS_Click(object sender, EventArgs e)
        {
            Delete_ChiBangKhangSinh();
        }
        private void gvBangKhangSinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSach_ChiTietBangKhangSinh();
        }
        #endregion


        SqlDataAdapter daKhangkhangSinh = new SqlDataAdapter();
        DataTable dataKhangKhangSinh = new DataTable();
        private void btnDeleteKhangKhangSinh_Click(object sender, EventArgs e)
        {
            if (dtgKhangKhangSinh.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kháng kháng sinh đang chọn?"))
                {
                    bvKhangKhangSinh.BindingSource.RemoveCurrent();
                }
            }
        }
        private void Load_KhangKhangSinh()
        {
            dtgKhangKhangSinh.DataBindingComplete -= dtgKhangKhangSinh_DataBindingComplete;
            _bacteriumAntibioticService.Get_Data_dm_xetnghiem_khangkhangsinh(dtgKhangKhangSinh, bvKhangKhangSinh, ref daKhangkhangSinh, ref dataKhangKhangSinh, string.Empty);
            dtgKhangKhangSinh.DataBindingComplete += dtgKhangKhangSinh_DataBindingComplete;
        }
        private void ThemKhangKhangSinh()
        {
            if (string.IsNullOrEmpty(txtKhangKhangSinh.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã kháng kháng sinh.");
                txtKhangKhangSinh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenKhangKhangSinh.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập tên kháng kháng sinh.");
                txtKhangKhangSinh.Focus();
                return;
            }
            var obj = new DM_XETNGHIEM_KHANGKHANGSINH();
            obj.Makhangkhangsinh = txtKhangKhangSinh.Text;
            obj.Tenkhangkhangsinh = txtKhangKhangSinh.Text;

            var ok = _bacteriumAntibioticService.Insert_dm_xetnghiem_khangkhangsinh(obj);
            if (ok.Id > -1)
            {
                txtKhangKhangSinh.Text = txtTenKhangKhangSinh.Text = string.Empty;
                txtKhangKhangSinh.Focus();
                Load_KhangKhangSinh();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK(ok.Name);
            }

        }
        private void dtgKhangKhangSinh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daKhangkhangSinh, ref dataKhangKhangSinh, string.Empty, string.Empty);
        }

        private void btnThemKhangKhangSinh_Click(object sender, EventArgs e)
        {
            ThemKhangKhangSinh();
        }

        private void btnLoad_KhangKhangSinh_Click(object sender, EventArgs e)
        {
            Load_KhangKhangSinh();
        }

        private void btnThemLoaiMau_Click(object sender, EventArgs e)
        {
            Insert_QuyTrinh_LoaiMau();
        }

        private void btnXoaLoaiMau_Click(object sender, EventArgs e)
        {
            Delete_Quytrinh_LoaiMau();
        }

        private void btnQuiTrinh_Them_Click(object sender, EventArgs e)
        {
            if (cboQuiTrinh_KyThuat.SelectedIndex > -1)
            {
                if (ucSearchLookupEditor_MayXN2.SelectedValue != null)
                {
                    if (gvQuiTrinh_DMKS.SelectedRowsCount > 0)
                    {
                        var sR = gvQuiTrinh_DMKS.GetSelectedRows();
                        foreach (var i in sR)
                        {
                            if (gvQuiTrinh_DMKS.GetRowCellValue(i, colQuiTrinh_DMKS_MaKhangSinh) != null)
                            {
                                var obj = new DM_XETNGHIEM_VISINH_QUITRINH
                                {
                                    Makhangsinh = gvQuiTrinh_DMKS.GetRowCellValue(i, colQuiTrinh_DMKS_MaKhangSinh).ToString(),
                                    Kythuat = cboQuiTrinh_KyThuat.SelectedValue.ToString(),
                                    Idmayxn = int.Parse(ucSearchLookupEditor_MayXN2.SelectedValue.ToString()),
                                    Quytrinh = txtQuyTrinhKhangSinh.Text
                                };
                                var baseObj = _bacteriumAntibioticService.Insert_dm_visinh_quitrinh(obj);
                            }
                        }
                        Load_DanhSach_QuiTrinh();
                    }
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn máy xn.");
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn kỹ thuật.");
            }
        }
        private void Load_DanhSach_QuiTrinh()
        {
            var kyThuat = cboQuiTrinh_KyThuat.SelectedIndex > -1
                    ? cboQuiTrinh_KyThuat.SelectedValue.ToString()
                    : string.Empty;
            var idMay = (ucSearchLookupEditor_MayXN1.SelectedValue ?? string.Empty).ToString();
            var data = _bacteriumAntibioticService.Data_dm_visinh_quitrinh(string.Empty, kyThuat, idMay);
            gcQuiTrinh.DataSource = data;
            gvQuiTrinh.ExpandAllGroups();
        }
        private void Update_QuiTrinh(int rowIndex)
        {
            var obj = new DM_XETNGHIEM_VISINH_QUITRINH
            {
                Makhangsinh = gvQuiTrinh.GetRowCellValue(rowIndex, colQuiTrinh_KS_MaKhangSinh).ToString(),
                Kythuat = gvQuiTrinh.GetRowCellValue(rowIndex, colQuiTrinh_KS_KyThuat).ToString(),
                Idmayxn = int.Parse(gvQuiTrinh.GetRowCellValue(rowIndex, colQuyTrinh_KS_IDMay).ToString()),
                Quytrinh = gvQuiTrinh.GetRowCellValue(rowIndex, colQuiTrinh_KS_QuiTrinh).ToString(),
                Phuongphap = gvQuiTrinh.GetRowCellValue(rowIndex, colQuiTrinh_KS_PhuongPhap).ToString(),
                Datchungnhan = bool.Parse(gvQuiTrinh.GetRowCellValue(rowIndex, colQuiTrinh_KS_DatChuongNhan).ToString())
            };
            _bacteriumAntibioticService.Update_dm_visinh_quitrinh(obj);
        }

        private void btnQuiTrinh_Xoa_Click(object sender, EventArgs e)
        {
            if (
                CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa cấu hình quy trình của kháng sinh đang chọn?"))
            {
                bool haveDelete = false;
                foreach (var selectedRow in gvQuiTrinh.GetSelectedRows())
                {
                    if (gvQuiTrinh.GetRowCellValue(selectedRow, colQuiTrinh_KS_MaKhangSinh) != null)
                    {
                        var obj = new DM_XETNGHIEM_VISINH_QUITRINH
                        {
                            Makhangsinh = gvQuiTrinh.GetRowCellValue(selectedRow, colQuiTrinh_KS_MaKhangSinh).ToString(),
                            Kythuat = gvQuiTrinh.GetRowCellValue(selectedRow, colQuiTrinh_KS_KyThuat).ToString(),
                            Idmayxn = int.Parse(gvQuiTrinh.GetRowCellValue(selectedRow, colQuyTrinh_KS_IDMay).ToString())
                        };

                        if (_bacteriumAntibioticService.Delete_dm_visinh_quitrinh(obj))
                        {
                            haveDelete = true;
                        }
                    }
                }
                Load_DanhSach_QuiTrinh();
            }
        }

        private void gvQuiTrinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvQuiTrinh.GetRowCellValue(e.RowHandle, colQuiTrinh_KS_MaKhangSinh) != null)
            {
                Update_QuiTrinh(e.RowHandle);
            }
        }

        private void btnQuiTrinh_DMKS_DS_Click(object sender, EventArgs e)
        {
            Load_DanhSach_QuiTrinh_KhangSinh();
        }

        private void gvQuyTrinh_LoaiMau_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Update_QuyTrinh_LoaiMau(e.RowHandle);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseData();
        }

        string pathVKPL = "";
        string pathKS = "";
        string pathKSD = "";
        private void BrowseData()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse Text File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOleDbPath.Text = openFileDialog1.FileName;
                file = txtOleDbPath.Text;
                if (radVKPL.Checked)
                {
                    pathVKPL = txtOleDbPath.Text;
                    dataBacterium = DatatableFromTextFile(txtOleDbPath.Text);
                    gcVKPL.DataSource = dataBacterium;
                    //ControlExtension.BindDataToGrid(dataBacterium, ref dtgBacterium, ref bvBacterium, true);
                }
                else if (radKS.Checked)
                {
                    pathKS = txtOleDbPath.Text;
                    dataAntibiotic = DatatableFromTextFile(txtOleDbPath.Text);
                    gcKS.DataSource = dataAntibiotic;
                    //ControlExtension.BindDataToGrid(dataAntibiotic, ref dtgAntibiotic, ref bvAntibiotic, true);
                }
                else if (radVKKSD.Checked)
                {
                    pathKSD = txtOleDbPath.Text;
                    dataBacteriumAntibiotic = DatatableFromTextFile(txtOleDbPath.Text);
                    gcKSD.DataSource = dataBacteriumAntibiotic;
                    //ControlExtension.BindDataToGrid(dataBacteriumAntibiotic, null, ref bvAntibioticBacterium, true);
                }
            }

        }

        #region Class Helper
        public string file;

        public DataTable DatatableFromTextFile(string location, char delimiter = '\t')
        {
            DataTable result;

            string[] LineArray = File.ReadAllLines(location);
            result = FromDataTable(LineArray, delimiter);
            return result;

        }

        private DataTable FromDataTable(string[] LineArray, char delimiter)
        {
            DataTable dt = new DataTable();
            AddColumnToTable(LineArray, delimiter, ref dt);
            AddRowToTable(LineArray, delimiter, ref dt);
            return dt;
        }

        private void AddRowToTable(string[] calueCollection, char delimiter, ref DataTable dt)
        {
            //for (int i = 1; i < calueCollection.Length; i++)
            for (var row = 1; row < calueCollection.Length; row++)
            {
                var values = XuLyRow(calueCollection[row], delimiter).ToArray();
                var dr = dt.NewRow();
                for (var col = 0; col < values.Length; col++)
                {
                    dr[col] = values[col];
                }
                dt.Rows.Add(dr);
            }
        }
        private List<string> XuLyRow(string rowInput, char delimiter)
        {
            var countTab = rowInput.Split('\t').Length - 1;
            var lstResult = new List<string>();
            var tempResult = string.Empty;
            var count = 0;
            var indexNext = 0;
            var check = true;
            for (var str = 0; str < rowInput.Length; str++)
            {
                //Nếu đến dấu " thứ 2 thì bỏ qua , nếu không nó sẽ cộng /t vào
                if (count == 2)
                {
                    count = 0;
                    countTab--;
                    continue;
                }
                if (rowInput[str].Equals(delimiter) && check)
                {
                    lstResult.Add(tempResult);
                    tempResult = string.Empty;
                    countTab--;
                }
                else if (rowInput[str].Equals('"'))
                {
                    count++;

                    if (count == 1)
                    {
                        //Lấy index đầu
                        indexNext = str + 1;
                        check = false;
                    }
                    else if (count == 2)
                    {
                        //Cắt chuỗi trong ngoặc ""
                        tempResult = rowInput.Substring(indexNext, str - indexNext);
                        var cTab = tempResult.Split('\t').Length - 1;
                        countTab -= cTab;
                        indexNext = 0;
                        lstResult.Add(tempResult);
                        tempResult = string.Empty;
                        check = true;
                        continue;
                    }
                }
                else
                {
                    tempResult += rowInput[str];
                }
                //Nếu hết \t và index là cuối , thì add chuỗi cuối vào list
                if (countTab == 0 && str == rowInput.Length - 1)
                    lstResult.Add(tempResult);
            }
            return lstResult;
        }
        private void AddColumnToTable(string[] ColumnCollection, char delimiter, ref DataTable dt)
        {
            string[] columns = ColumnCollection[0].Split(delimiter);
            foreach (string columnName in columns)
            {
                DataColumn dc = new DataColumn(columnName, typeof(string));
                dt.Columns.Add(dc);
            }
        }
        #endregion

        private void btnImportViKHuan_Click(object sender, EventArgs e)
        {
            CustomMessageBox.ShowAlert("Đang import vi khuẩn...");
            ImportDataViKhuan();
            CustomMessageBox.CloseAlert();
        }

        #region Import vi khuẩn theo Viện lấy All
        private void ImportDataViKhuan()
        {
            if (gvVKPL.RowCount > 0)
            {
                dataBacterium = GetDataTableFromGridView(gvVKPL);

                //Import vi khuẩn
                var objVK = new DM_XETNGHIEM_VIKHUAN();
                //Kiểm tra Insert các bộ, họ chung
                objVK.Maphanloai = "BA";
                objVK.Tenphanloai = "Bộ dùng chung";
                objVK.Donviphanloai = BacteriumCategory.order.ToString();
                objVK.Nguoinhap = "Import";
                objVK.insertWithMess = false;
                _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);

                //Insert các họ dùng chung
                objVK.Maphanloai = "HA";
                objVK.Maphanloaicha = "BA";
                objVK.Tenphanloai = "Họ dùng chung";
                objVK.Donviphanloai = BacteriumCategory.family.ToString();
                objVK.Nguoinhap = "Import";
                objVK.insertWithMess = false;
                _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);


                //Insert các họ
                var dataDistinctHo = dataBacterium.DefaultView.ToTable(true, new string[] { "ORG_GROUP" });
                foreach (DataRow drC in dataDistinctHo.Rows)
                {
                    var MaHo = string.Format("FAMILY_{0}", StringConverter.ToString(drC["ORG_GROUP"]));
                    var TenHo = StringConverter.ToString(drC["ORG_GROUP"]);
                    if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
                    {
                        MaHo = "FAMILY_KXD";
                        TenHo = "Không xác định";
                    }
                    else if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && !string.IsNullOrEmpty(TenHo))
                    {
                        MaHo = TenHo.Substring(0, 20);
                    }
                    else if (!string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
                    {
                        TenHo = MaHo;
                    }
                    objVK.Maphanloaicha = "BA";
                    objVK.Maphanloai = MaHo;
                    objVK.Tenphanloai = TenHo;
                    objVK.Donviphanloai = BacteriumCategory.family.ToString();
                    objVK.Nguoinhap = "Import";
                    objVK.insertWithMess = false;

                    //Insert các mẫu chung
                    //objVK.Status = StringConverter.ToString(drC["STATUS"]);
                    //objVK.Common = StringConverter.ToString(drC["COMMON"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                    //objVK.SUB_Group = StringConverter.ToString(drC["SUB_GROUP"]);
                    //objVK.Genus_Code = StringConverter.ToString(drC["GENUS_CODE"]);
                    //objVK.SCT_Code = StringConverter.ToString(drC["SCT_CODE"]);
                    //objVK.SCT_Text = StringConverter.ToString(drC["SCT_TEXT"]);

                    _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);
                }


                //Insert các chi
                var dataDistinctChi = dataBacterium.DefaultView.ToTable(true, new string[] { "GENUS_CODE", "GENUS", "ORG_GROUP" });
                foreach (DataRow drC in dataDistinctChi.Rows)
                {
                    var MaChi = string.Format("GENUS_{0}", StringConverter.ToString(drC["GENUS_CODE"]));
                    var TenChi = StringConverter.ToString(drC["GENUS"]);
                    if (string.IsNullOrEmpty(drC["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(TenChi))
                    {
                        MaChi = "GENUS_KXD";
                        TenChi = "Không xác định";
                    }
                    else if (string.IsNullOrEmpty(drC["GENUS_CODE"].ToString()) && !string.IsNullOrEmpty(TenChi))
                    {
                        MaChi = TenChi.Substring(0, 20);
                    }
                    else if (!string.IsNullOrEmpty(drC["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(TenChi))
                    {
                        TenChi = MaChi;
                    }

                    var MaHo = string.Format("FAMILY_{0}", StringConverter.ToString(drC["ORG_GROUP"]));
                    var TenHo = StringConverter.ToString(drC["ORG_GROUP"]);
                    if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
                    {
                        MaHo = "FAMILY_KXD";
                        TenHo = "Không xác định";
                    }
                    else if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && !string.IsNullOrEmpty(TenHo))
                    {
                        MaHo = TenHo.Substring(0, 20);
                    }
                    else if (!string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
                    {
                        TenHo = MaHo;
                    }

                    objVK.Maphanloaicha = string.IsNullOrEmpty(MaHo) ? "HA" : MaHo;
                    objVK.Maphanloai = MaChi;
                    objVK.Tenphanloai = TenChi;
                    objVK.Donviphanloai = BacteriumCategory.genus.ToString();
                    objVK.Nguoinhap = "Import";
                    objVK.insertWithMess = false;

                    //Insert các mẫu chung
                    //objVK.Status = StringConverter.ToString(drC["STATUS"]);
                    //objVK.Common = StringConverter.ToString(drC["COMMON"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                    //objVK.SUB_Group = StringConverter.ToString(drC["SUB_GROUP"]);
                    //objVK.Genus_Code = StringConverter.ToString(drC["GENUS_CODE"]);
                    //objVK.SCT_Code = StringConverter.ToString(drC["SCT_CODE"]);
                    //objVK.SCT_Text = StringConverter.ToString(drC["SCT_TEXT"]);
                    _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);
                }

                //Insert các vi khuẩn
                foreach (DataRow drVk in dataBacterium.Rows)
                {
                    var maLoai = StringConverter.ToString(drVk["ORG"]);
                    //if (status.ToUpper() != "C") continue;
                    if (string.IsNullOrEmpty(maLoai)) continue;

                    var maChi = string.Format("GENUS_{0}", StringConverter.ToString(drVk["GENUS_CODE"]));
                    var tenChi = drVk["GENUS"].ToString();
                    if (string.IsNullOrEmpty(drVk["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(tenChi))
                    {
                        maChi = "GENUS_KXD";
                        tenChi = "Không xác định";
                    }
                    else if (string.IsNullOrEmpty(drVk["GENUS_CODE"].ToString()) && !string.IsNullOrEmpty(tenChi))
                    {
                        maChi = tenChi.Substring(0, 20);
                    }
                    else if (!string.IsNullOrEmpty(drVk["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(tenChi))
                    {
                        tenChi = maChi;
                    }

                    var thuongGoi = StringConverter.ToString(drVk["ORG_CLEAN"]);
                    var danhPhap = StringConverter.ToString(drVk["ORGANISM"]);
                    var gram = StringConverter.ToString(drVk["GRAM"]);
                    var orgGroup = StringConverter.ToString(drVk["ORG_GROUP"]);

                    objVK.Maphanloai = maLoai;

                    objVK.Tenphanloai = StringConverter.ToString(drVk["SCT_TEXT"]);
                    if (string.IsNullOrEmpty(objVK.Tenphanloai))
                        objVK.Tenphanloai = StringConverter.ToString(drVk["ORGANISM"]);

                    objVK.Danhphap = danhPhap;
                    objVK.Tenthuonggoi = thuongGoi;
                    objVK.Maphanloaicha = maChi;
                    objVK.Gram = gram;
                    objVK.Org_group = orgGroup;

                    objVK.Donviphanloai = BacteriumCategory.species.ToString();
                    objVK.Nguoinhap = "Import";
                    objVK.insertWithMess = false;

                    //Insert các mẫu chung
                    objVK.Status = StringConverter.ToString(drVk["STATUS"]);
                    objVK.Common = StringConverter.ToString(drVk["COMMON"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                    objVK.Sub_group = StringConverter.ToString(drVk["SUB_GROUP"]);
                    objVK.Genus_code = StringConverter.ToString(drVk["GENUS_CODE"]);
                    objVK.Sct_code = StringConverter.ToString(drVk["SCT_CODE"]);
                    objVK.Sct_text = StringConverter.ToString(drVk["SCT_TEXT"]);
                    _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);
                    //làm cái count import ở day
                }
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Vui lòng import dữ liệu...");
            }
        }
        #endregion

        #region Import Vi khuẩn
        //private void ImportDataViKhuan()
        //{
        //    if (gvVKPL.RowCount > 0)
        //    {
        //        dataBacterium = GetDataTableFromGridView(gvVKPL);

        //        //Import vi khuẩn
        //        var objVK = new DM_XETNGHIEM_VIKHUAN();
        //        //Kiểm tra Insert các bộ, họ chung
        //        objVK.Maphanloai = "BA";
        //        objVK.Tenphanloai = "Bộ dùng chung";
        //        objVK.Donviphanloai = BacteriumCategory.order.ToString();
        //        objVK.Nguoinhap = "Import";
        //        objVK.insertWithMess = false;
        //        _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);

        //        //Insert các họ dùng chung
        //        objVK.Maphanloai = "HA";
        //        objVK.Maphanloaicha = "BA";
        //        objVK.Tenphanloai = "Họ dùng chung";
        //        objVK.Donviphanloai = BacteriumCategory.family.ToString();
        //        objVK.Nguoinhap = "Import";
        //        objVK.insertWithMess = false;
        //        _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);

        //        //Insert các họ
        //        var dataDistinctHo = dataBacterium.DefaultView.ToTable(true, new string[] { "ORG_GROUP" });
        //        foreach (DataRow drC in dataDistinctHo.Rows)
        //        {
        //            var MaHo = string.Format("FAMILY_{0}", drC["ORG_GROUP"].ToString());
        //            var TenHo = StringConverter.ToString(drC["ORG_GROUP"]);
        //            if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
        //            {
        //                MaHo = "FAMILY_KXD";
        //                TenHo = "Không xác định";
        //            }
        //            else if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && !string.IsNullOrEmpty(TenHo))
        //            {
        //                MaHo = TenHo.Substring(0, 20);
        //            }
        //            else if (!string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
        //            {
        //                TenHo = MaHo;
        //            }
        //            objVK.Maphanloaicha = "BA";
        //            objVK.Maphanloai = MaHo;
        //            objVK.Tenphanloai = TenHo;
        //            objVK.Donviphanloai = BacteriumCategory.family.ToString();
        //            objVK.Nguoinhap = "Import";
        //            objVK.insertWithMess = false;
        //            _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);
        //        }


        //        //Insert các chi
        //        var dataDistinctChi = dataBacterium.DefaultView.ToTable(true, new string[] { "GENUS_CODE", "GENUS", "ORG_GROUP" });
        //        foreach (DataRow drC in dataDistinctChi.Rows)
        //        {
        //            var MaChi = string.Format("GENUS_{0}", drC["GENUS_CODE"].ToString());
        //            var TenChi = StringConverter.ToString(drC["GENUS"]);
        //            if (string.IsNullOrEmpty(drC["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(TenChi))
        //            {
        //                MaChi = "GENUS_KXD";
        //                TenChi = "Không xác định";
        //            }
        //            else if (string.IsNullOrEmpty(drC["GENUS_CODE"].ToString()) && !string.IsNullOrEmpty(TenChi))
        //            {
        //                MaChi = TenChi.Substring(0, 20);
        //            }
        //            else if (!string.IsNullOrEmpty(drC["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(TenChi))
        //            {
        //                TenChi = MaChi;
        //            }

        //            var MaHo = string.Format("FAMILY_{0}", drC["ORG_GROUP"].ToString());
        //            var TenHo = StringConverter.ToString(drC["ORG_GROUP"]);
        //            if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
        //            {
        //                MaHo = "FAMILY_KXD";
        //                TenHo = "Không xác định";
        //            }
        //            else if (string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && !string.IsNullOrEmpty(TenHo))
        //            {
        //                MaHo = TenHo.Substring(0, 20);
        //            }
        //            else if (!string.IsNullOrEmpty(drC["ORG_GROUP"].ToString()) && string.IsNullOrEmpty(TenHo))
        //            {
        //                TenHo = MaHo;
        //            }

        //            objVK.Maphanloaicha = string.IsNullOrEmpty(MaHo) ? "HA" : MaHo;
        //            objVK.Maphanloai = MaChi;
        //            objVK.Tenphanloai = TenChi;
        //            objVK.Donviphanloai = BacteriumCategory.genus.ToString();
        //            objVK.Nguoinhap = "Import";
        //            objVK.insertWithMess = false;
        //            _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);
        //        }

        //        //Insert các vi khuẩn
        //        foreach (DataRow drVk in dataBacterium.Rows)
        //        {
        //            var maLoai = StringConverter.ToString(drVk["ORG"]);
        //            var status = StringConverter.ToString(drVk["STATUS"]);
        //            if (status.ToUpper() != "C") continue;
        //            if (string.IsNullOrEmpty(maLoai)) continue;

        //            var maChi = string.Format("GENUS_{0}", drVk["GENUS_CODE"].ToString());
        //            var tenChi = drVk["GENUS"].ToString();
        //            if (string.IsNullOrEmpty(drVk["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(tenChi))
        //            {
        //                maChi = "GENUS_KXD";
        //                tenChi = "Không xác định";
        //            }
        //            else if (string.IsNullOrEmpty(drVk["GENUS_CODE"].ToString()) && !string.IsNullOrEmpty(tenChi))
        //            {
        //                maChi = tenChi.Substring(0, 20);
        //            }
        //            else if (!string.IsNullOrEmpty(drVk["GENUS_CODE"].ToString()) && string.IsNullOrEmpty(tenChi))
        //            {
        //                tenChi = maChi;
        //            }

        //            var thuongGoi = StringConverter.ToString(drVk["ORG_CLEAN"]);
        //            var danhPhap = StringConverter.ToString(drVk["ORGANISM"]);
        //            var gram = StringConverter.ToString(drVk["GRAM"]);
        //            var orgGroup = StringConverter.ToString(drVk["ORG_GROUP"]);

        //            objVK.Maphanloai = maLoai;

        //            objVK.Tenphanloai = StringConverter.ToString(drVk["SCT_TEXT"]);
        //            if (string.IsNullOrEmpty(objVK.Tenphanloai))
        //                objVK.Tenphanloai = StringConverter.ToString(drVk["ORGANISM"]);

        //            objVK.Danhphap = danhPhap;
        //            objVK.Tenthuonggoi = thuongGoi;
        //            objVK.Maphanloaicha = maChi;
        //            objVK.Gram = gram;
        //            objVK.Org_Group = orgGroup;

        //            objVK.Donviphanloai = BacteriumCategory.species.ToString();
        //            objVK.Nguoinhap = "Import";
        //            objVK.insertWithMess = false;
        //            _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan(objVK);
        //            //làm cái count import ở day
        //        }
        //    }
        //    else
        //    {
        //        CustomMessageBox.MSG_Waring_OK("Vui lòng import dữ liệu...");
        //    }
        //}

        #endregion 

        private void btnImportKhangSinh_Click(object sender, EventArgs e)
        {
            CustomMessageBox.ShowAlert("Đang import kháng sinh...");
            var qImported = ImportKhangSinh();
            CustomMessageBox.CloseAlert();
            CustomMessageBox.MSG_Information_OK(string.Format("Đã import {0} kháng sinh", qImported));
        }

        int Get_WhoNetCode()
        {
            if (radWHONet6.Checked)
                return 6;
            else if (radWHONet7.Checked)
                return 7;
            else if (radWHONet8.Checked)
                return 8;
            else
                return 5;
        }

        #region Import kháng sinh theo Viện lấy All
        private int ImportKhangSinh()
        {
            var quantityImported = 0;
            if (gvKS.RowCount <= 0) return quantityImported;

            dataAntibiotic = GetDataTableFromGridView(gvKS);




            var whonetVersion = Get_WhoNetCode();
            //import các nhóm kháng sinh
            var distinctNhomKs = dataAntibiotic.DefaultView.ToTable(true, new[] { "CLSI_ORDER", "CLASS" });
            foreach (DataRow drN in distinctNhomKs.Rows)
            {
                var objNhomKs = new DM_XETNGHIEM_NHOMKHANGSINH();

                var maNhomKs = StringConverter.ToString(drN["CLSI_ORDER"]);
                var tenNhomKs = StringConverter.ToString(drN["CLASS"]);
                if (string.IsNullOrEmpty(maNhomKs) && string.IsNullOrEmpty(tenNhomKs))
                {
                    maNhomKs = "KXD";
                    tenNhomKs = "Không xác định";
                }
                else if (string.IsNullOrEmpty(maNhomKs) && !string.IsNullOrEmpty(tenNhomKs))
                {
                    maNhomKs = tenNhomKs.Substring(0, tenNhomKs.Length > 20 ? 20 : tenNhomKs.Length);
                }
                else if (!string.IsNullOrEmpty(maNhomKs) && string.IsNullOrEmpty(tenNhomKs))
                {
                    tenNhomKs = maNhomKs;
                }
                objNhomKs.insertWithMess = false;
                objNhomKs.Manhomkhangsinh = maNhomKs;
                objNhomKs.Tennhomkhangsinh = tenNhomKs;
                objNhomKs.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                _bacteriumAntibioticService.Insert_dm_xetnghiem_nhomkhangsinh(objNhomKs);
            }
            //import danh sách kháng sinh
            foreach (DataRow drN in dataAntibiotic.Rows)
            {
                //if (string.IsNullOrEmpty(StringConverter.ToString(drN["HUMAN"]))) continue;

                var objKs = new DM_XETNGHIEM_KHANGSINH();
                var rowIndex = (int)dataAntibiotic.Rows.IndexOf(drN);

                var maKs = StringConverter.ToString(drN["WHON5_CODE"]);
                if (string.IsNullOrEmpty(maKs)) continue;

                var maNhomKs = StringConverter.ToString(drN["CLSI_ORDER"]);
                var tenNhomKs = StringConverter.ToString(drN["CLASS"]);
                if (string.IsNullOrEmpty(maNhomKs) && string.IsNullOrEmpty(tenNhomKs))
                {
                    maNhomKs = "KXD";
                }
                else if (string.IsNullOrEmpty(maNhomKs) && !string.IsNullOrEmpty(tenNhomKs))
                {
                    maNhomKs = tenNhomKs.Substring(0, tenNhomKs.Length > 20 ? 20 : tenNhomKs.Length);
                }

                var tenKS = StringConverter.ToString(drN["ANTIBIOTIC"]);
                var maKSOld = StringConverter.ToString(drN["WHON5_CODE"]);

                //var CLSI_DI = StringConverter.ToString(drN["CLSI20_DI"]);
                //var CLSI_DS = StringConverter.ToString(drN["CLSI20_DS"]);
                //var CLSI_DR = StringConverter.ToString(drN["CLSI20_DR"]);
                //var CLSI_MIC_R = StringConverter.ToString(drN["CLSI20_MR"]);
                //var CLSI_MIC_S = StringConverter.ToString(drN["CLSI20_MS"]);

                objKs.Potency = StringConverter.ToString(drN["POTENCY"]);

                //objKs.CLSI_DI = CLSI_DI;
                //if (!string.IsNullOrEmpty(CLSI_DS) && WorkingServices.IsNumeric(CLSI_DS))
                //    objKs.CLSI_DS = float.Parse(CLSI_DS);
                //if (!string.IsNullOrEmpty(CLSI_DR) && WorkingServices.IsNumeric(CLSI_DR))
                //    objKs.CLSI_DR = float.Parse(CLSI_DR);
                //if (!string.IsNullOrEmpty(CLSI_MIC_R) && WorkingServices.IsNumeric(CLSI_MIC_R))
                //    objKs.CLSI_MIC_R = float.Parse(CLSI_MIC_R);
                //if (!string.IsNullOrEmpty(CLSI_MIC_S) && WorkingServices.IsNumeric(CLSI_MIC_S))
                //    objKs.CLSI_MIC_S = float.Parse(CLSI_MIC_S);

                objKs.Whon4_code = StringConverter.ToString(drN["WHON4_CODE"]);
                objKs.Who_code = StringConverter.ToString(drN["WHO_CODE"]);
                objKs.Din_code = StringConverter.ToString(drN["DIN_CODE"]);
                objKs.Jac_code = StringConverter.ToString(drN["JAC_CODE"]);
                objKs.User_code = StringConverter.ToString(drN["USER_CODE"]);
                objKs.Guidelines = StringConverter.ToString(drN["GUIDELINES"]);
                if (!string.IsNullOrEmpty(StringConverter.ToString(drN["ABX_NUMBER"])))
                    objKs.Abx_number = float.Parse(StringConverter.ToString(drN["ABX_NUMBER"]));
                objKs.Betalactam = StringConverter.ToString(drN["BETALACTAM"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                objKs.Subclass = StringConverter.ToString(drN["SUBCLASS"]);
                objKs.Prof_class = StringConverter.ToString(drN["PROF_CLASS"]);
                objKs.Human = StringConverter.ToString(drN["HUMAN"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                objKs.Veterinary = StringConverter.ToString(drN["VETERINARY"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                objKs.Animal_gp = StringConverter.ToString(drN["ANIMAL_GP"]).Equals("X", StringComparison.OrdinalIgnoreCase);
                objKs.Who_import = StringConverter.ToString(drN["WHO_IMPORT"]).Equals("X", StringComparison.OrdinalIgnoreCase);

                //objKs.LOINCCOMP = StringConverter.ToString(drN["LOINCCOMP"]);
                //objKs.LOINCGEN = StringConverter.ToString(drN["LOINCGEN"]);
                //objKs.LOINCDISK = StringConverter.ToString(drN["LOINCDISK"]);
                //objKs.LOINCMIC = StringConverter.ToString(drN["LOINCMIC"]);
                //objKs.LOINCETEST = StringConverter.ToString(drN["LOINCETEST"]);
                //objKs.LOINCSLOW = StringConverter.ToString(drN["LOINCSLOW"]);
                //objKs.LOINCAFB = StringConverter.ToString(drN["LOINCAFB"]);
                //objKs.LOINCSBT = StringConverter.ToString(drN["LOINCSBT"]);
                //objKs.LOINCMLC = StringConverter.ToString(drN["LOINCMLC"]);

                objKs.insertWithMess = false;
                objKs.Manhomkhangsinh = maNhomKs;
                objKs.Makhangsinh = maKs;
                objKs.Tenkhangsinh = tenKS;
                objKs.Whonetversion = whonetVersion;
                objKs.OldWHONetCode = maKSOld;
                objKs.Nguoinhap = CommonAppVarsAndFunctions.UserID;
                //objKS.GuideLineType = drN["GUIDELINES"].ToString();
                //_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(objKS);
                var CLSI = StringConverter.ToString(drN["CLSI"]);
                if (!string.IsNullOrEmpty(CLSI))
                    CLSI = "CLSI";
                var EUCAST = StringConverter.ToString(drN["EUCAST"]);
                if (!string.IsNullOrEmpty(EUCAST))
                    EUCAST = "EUCST";
                var SFM = StringConverter.ToString(drN["SFM"]);
                if (!string.IsNullOrEmpty(SFM))
                    SFM = "SFM";
                var SRGA = StringConverter.ToString(drN["SRGA"]);
                if (!string.IsNullOrEmpty(SRGA))
                    SRGA = "SRGA";
                var BSAC = StringConverter.ToString(drN["BSAC"]);
                if (!string.IsNullOrEmpty(BSAC))
                    BSAC = "BSAC";
                var DIN = StringConverter.ToString(drN["DIN"]);
                if (!string.IsNullOrEmpty(DIN))
                    DIN = "DIN";
                var NEO = StringConverter.ToString(drN["NEO"]);
                if (!string.IsNullOrEmpty(NEO))
                    NEO = "NEODK";
                var AFA = StringConverter.ToString(drN["AFA"]);
                if (!string.IsNullOrEmpty(AFA))
                    AFA = "AFA";
                var guideLineTypes = new List<string>() { CLSI, EUCAST, SFM, SRGA, BSAC, DIN, NEO, AFA };
                //Lấy ra các String nào co giá trị.
                guideLineTypes = (from item in guideLineTypes
                                  where !string.IsNullOrEmpty(item)
                                  select item).ToList();
                quantityImported += Insert_list_dm_xetnghiem_khangsinh(guideLineTypes, objKs, drN, dataAntibiotic, rowIndex);

                //if (_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(objKS))
                //{
                //    quantityImported++;
                //}
            }
            return quantityImported;
        }
        #endregion

        #region Import kháng sinh cũ
        //private int ImportKhangSinh()
        //{
        //    var quantityImported = 0;
        //    if (gvKS.RowCount <= 0) return quantityImported;

        //    dataAntibiotic = GetDataTableFromGridView(gvKS);
        //    var whonetVersion = Get_WhoNetCode();
        //    //import các nhóm kháng sinh
        //    var distinctNhomKs = dataAntibiotic.DefaultView.ToTable(true, new string[] { "CLSI_ORDER", "CLASS" });
        //    foreach (DataRow drN in distinctNhomKs.Rows)
        //    {
        //        var objNhomKs = new DM_XETNGHIEM_NHOMKHANGSINH();

        //        var maNhomKs = StringConverter.ToString(drN["CLSI_ORDER"]);
        //        var tenNhomKs = StringConverter.ToString(drN["CLASS"]);
        //        if (string.IsNullOrEmpty(maNhomKs) && string.IsNullOrEmpty(tenNhomKs))
        //        {
        //            maNhomKs = "KXD";
        //            tenNhomKs = "Không xác định";
        //        }
        //        else if (string.IsNullOrEmpty(maNhomKs) && !string.IsNullOrEmpty(tenNhomKs))
        //        {
        //            maNhomKs = tenNhomKs.Substring(0, tenNhomKs.Length > 20 ? 20 : tenNhomKs.Length);
        //        }
        //        else if (!string.IsNullOrEmpty(maNhomKs) && string.IsNullOrEmpty(tenNhomKs))
        //        {
        //            tenNhomKs = maNhomKs;
        //        }
        //        objNhomKs.insertWithMess = false;
        //        objNhomKs.Manhomkhangsinh = maNhomKs;
        //        objNhomKs.Tennhomkhangsinh = tenNhomKs;
        //        _bacteriumAntibioticService.Insert_dm_xetnghiem_nhomkhangsinh(objNhomKs);
        //    }
        //    //import danh sách kháng sinh
        //    foreach (DataRow drN in dataAntibiotic.Rows)
        //    {
        //        if (string.IsNullOrEmpty(StringConverter.ToString(drN["HUMAN"]))) continue;

        //        var objKs = new DM_XETNGHIEM_KHANGSINH();

        //        var maKs = StringConverter.ToString(drN["WHON5_CODE"]);
        //        if (string.IsNullOrEmpty(maKs)) continue;

        //        var maNhomKs = StringConverter.ToString(drN["CLSI_ORDER"]);
        //        var tenNhomKs = StringConverter.ToString(drN["CLASS"]);
        //        if (string.IsNullOrEmpty(maNhomKs) && string.IsNullOrEmpty(tenNhomKs))
        //        {
        //            maNhomKs = "KXD";
        //        }
        //        else if (string.IsNullOrEmpty(maNhomKs) && !string.IsNullOrEmpty(tenNhomKs))
        //        {
        //            maNhomKs = tenNhomKs.Substring(0, tenNhomKs.Length > 20 ? 20 : tenNhomKs.Length);
        //        }

        //        var tenKS = StringConverter.ToString(drN["ANTIBIOTIC"]);
        //        var maKSOld = StringConverter.ToString(drN["WHON5_CODE"]);
        //        var CLSI_DI = string.IsNullOrEmpty(StringConverter.ToString(drN["CLSI20_DI"])) ? null : StringConverter.ToString(drN["CLSI20_DI"]);
        //        var CLSI_DS = StringConverter.ToString(drN["CLSI20_DS"]);
        //        var CLSI_DR = StringConverter.ToString(drN["CLSI20_DR"]);
        //        var CLSI_MIC_R = StringConverter.ToString(drN["CLSI20_MR"]);
        //        var CLSI_MIC_S = StringConverter.ToString(drN["CLSI20_MS"]);
        //        objKs.Potency = string.IsNullOrEmpty(StringConverter.ToString(drN["Potency"])) ? string.Empty : StringConverter.ToString(drN["Potency"]);

        //        objKs.CLSI_DI = CLSI_DI;
        //        if (!string.IsNullOrEmpty(CLSI_DS) && WorkingServices.IsNumeric(CLSI_DS))
        //            objKs.CLSI_DS = float.Parse(CLSI_DS);
        //        if (!string.IsNullOrEmpty(CLSI_DR) && WorkingServices.IsNumeric(CLSI_DR))
        //            objKs.CLSI_DR = float.Parse(CLSI_DR);
        //        if (!string.IsNullOrEmpty(CLSI_MIC_R) && WorkingServices.IsNumeric(CLSI_MIC_R))
        //            objKs.CLSI_MIC_R = float.Parse(CLSI_MIC_R);
        //        if (!string.IsNullOrEmpty(CLSI_MIC_S) && WorkingServices.IsNumeric(CLSI_MIC_S))
        //            objKs.CLSI_MIC_S = float.Parse(CLSI_MIC_S);

        //        objKs.insertWithMess = false;
        //        objKs.Manhomkhangsinh = maNhomKs;
        //        objKs.Makhangsinh = maKs;
        //        objKs.Tenkhangsinh = tenKS;
        //        objKs.WHONetVersion = whonetVersion;
        //        objKs.OldWHONetCode = maKSOld;
        //        //objKS.GuideLineType = drN["GUIDELINES"].ToString();
        //        //_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(objKS);

        //        var CLSI = drN["CLSI"].ToString();
        //        if (!string.IsNullOrEmpty(CLSI))
        //            CLSI = "CLSI20";
        //        //var EUCAST = drN["EUCAST"].ToString();
        //        //if (!string.IsNullOrEmpty(EUCAST))
        //        //    EUCAST = "EUCAST";
        //        //var SFM = drN["SFM"].ToString();
        //        //if (!string.IsNullOrEmpty(SFM))
        //        //    SFM = "SFM";
        //        //var SRGA = drN["SRGA"].ToString();
        //        //if (!string.IsNullOrEmpty(SRGA))
        //        //    SRGA = "SRGA";
        //        //var BSAC = drN["BSAC"].ToString();
        //        //if (!string.IsNullOrEmpty(BSAC))
        //        //    BSAC = "BSAC";
        //        //var DIN = drN["DIN"].ToString();
        //        //if (!string.IsNullOrEmpty(DIN))
        //        //    DIN = "DIN";
        //        //var NEO = drN["NEO"].ToString();
        //        //if (!string.IsNullOrEmpty(NEO))
        //        //    NEO = "NEO";
        //        //var AFA = drN["AFA"].ToString();
        //        //if (!string.IsNullOrEmpty(AFA))
        //        //    AFA = "AFA";
        //        //var guideLineTypes = new List<string>() { CLSI, EUCAST, SFM, SRGA, BSAC, DIN, NEO, AFA };
        //        var guideLineTypes = new List<string>() { CLSI };
        //        quantityImported += Insert_list_dm_xetnghiem_khangsinh(guideLineTypes, objKs);

        //        //if (_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(objKS))
        //        //{
        //        //    quantityImported++;
        //        //}
        //    }
        //    return quantityImported;
        //}

        //private int Insert_list_dm_xetnghiem_khangsinh(IEnumerable<string> guideLineTypes, DM_XETNGHIEM_KHANGSINH objKS)
        //{
        //    var count = 0;
        //    foreach (var item in guideLineTypes.Where(item => !string.IsNullOrEmpty((item))))
        //    {
        //        objKS.GuideLineType = item;
        //        if (_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(objKS))
        //            count++;
        //    }
        //    return count;
        //}
        #endregion

        private int Insert_list_dm_xetnghiem_khangsinh(IEnumerable<string> guideLineTypes, DM_XETNGHIEM_KHANGSINH objKS
            , DataRow drN, DataTable dataAntibiotic, int rowIndex)
        {
            var count = 0;
            var dataAntibioticImport = dataAntibiotic.Copy();
            //Bỏ cột CLSI_ORDER để lấy CLSI chính xác
            dataAntibioticImport.Columns.Remove("CLSI_ORDER");
            dataAntibioticImport.Columns.Remove("DIN_CODE");
            string[] columnDelete = { "CLSI", "EUCAST", "SFM", "SRGA", "BSAC", "DIN", "NEO", "AFA" };
            foreach (var ColName in columnDelete.Where(ColName => dataAntibioticImport.Columns.Contains(ColName)))
            {
                dataAntibioticImport.Columns.Remove(ColName);
            }
            foreach (var item in guideLineTypes)
            {

                #region Lấy các cột bắt đầu có chữ như item
                var uploadtable = dataAntibioticImport.Copy();
                var removeColumns = dataAntibioticImport.Columns.Cast<DataColumn>()
                   .Where(c => !c.ColumnName.StartsWith(item.ToString(), StringComparison.InvariantCultureIgnoreCase));

                foreach (var colToRemove in removeColumns)
                    uploadtable.Columns.Remove(colToRemove.ColumnName);
                #endregion
                //Lấy dòng hiện tại
                //uploadtable = uploadtable.Rows[rowIndex].Table;

                while (uploadtable.Columns.Count > 0)
                {
                    var DR = StringConverter.ToString(uploadtable.Rows[rowIndex][0]);
                    var DI = StringConverter.ToString(uploadtable.Rows[rowIndex][1]);
                    var DS = StringConverter.ToString(uploadtable.Rows[rowIndex][2]);
                    var MIC_S = StringConverter.ToString(uploadtable.Rows[rowIndex][3]);
                    var MIC_R = StringConverter.ToString(uploadtable.Rows[rowIndex][4]);

                    //Lay tên các cột remove
                    string[] columnsName =
                    {
                        uploadtable.Columns[0].ColumnName, uploadtable.Columns[1].ColumnName ,
                        uploadtable.Columns[2].ColumnName,uploadtable.Columns[3].ColumnName,uploadtable.Columns[4].ColumnName
                    };
                    //Nếu Năm đó không có KSD thì cho GL là rỗng bỏ qua
                    if (string.IsNullOrEmpty(DR) && string.IsNullOrEmpty(DI) && string.IsNullOrEmpty(DS)
                        && string.IsNullOrEmpty(MIC_S) && string.IsNullOrEmpty(MIC_R))
                    {
                        //foreach (var ColName in columnsName.Where(ColName => uploadtable.Columns.Contains(ColName)))
                        //{
                        //    uploadtable.Columns.Remove(ColName);
                        //}
                        //continue;
                        objKS.Guidelinetype = string.Empty;
                        objKS.Guidelineyear = 0000;
                    }
                    else
                    {
                        objKS.Guidelinetype = columnsName[0].Substring(0, columnsName[0].Length - 3);
                        var twoDigit = int.Parse(objKS.Guidelinetype.Substring(objKS.Guidelinetype.Length - 2, 2));
                        if (twoDigit > 95)
                        {
                            objKS.Guidelineyear = twoDigit + 1900;
                        }
                        else
                        {
                            objKS.Guidelineyear = twoDigit + 2000;
                        }
                    }

                    if (!string.IsNullOrEmpty(DR) && WorkingServices.IsNumeric(DR))
                        objKS.Clsi_dr = float.Parse(DR);
                    objKS.Clsi_di = DI;
                    if (!string.IsNullOrEmpty(DS) && WorkingServices.IsNumeric(DS))
                        objKS.Clsi_ds = float.Parse(DS);
                    if (!string.IsNullOrEmpty(MIC_S) && WorkingServices.IsNumeric(MIC_S))
                        objKS.Clsi_mic_s = float.Parse(MIC_S);
                    if (!string.IsNullOrEmpty(MIC_R) && WorkingServices.IsNumeric(MIC_R))
                        objKS.Clsi_mic_r = float.Parse(MIC_R);

                    foreach (var ColName in columnsName.Where(ColName => uploadtable.Columns.Contains(ColName)))
                    {
                        uploadtable.Columns.Remove(ColName);
                    }

                    if (_bacteriumAntibioticService.Insert_dm_xetnghiem_khangsinh(objKS))
                        count++;
                }
            }
            return count;
        }

        private void btnImportKSD_Click(object sender, EventArgs e)
        {
            //if (!CheckLogicImportKsd()) return;
            CustomMessageBox.ShowAlert("Đang import kháng sinh đồ...");
            ImportKsd();
            CustomMessageBox.CloseAlert();
        }

        private bool CheckLogicImportKsd()
        {
            if (gvKSD.RowCount <= 0)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng Import dữ liệu!");
                return false;
            }
            if (chkBxCLSI.Checked == false && chkBxEUCST.Checked == false)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn GuideLines để Import Danh mục kháng sinh đồ!");
                return false;
            }
            if (cboKyThuat_IP.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng chọn Kỹ thuật!");
                return false;
            }
            if (chkBxCLSI.Checked)
            {
                var check = false;
                var gl_CLSI = string.Format("CLSI{0}", dtpGuideLineYear_IP.Value.ToString("yy"));
                dataBacteriumAntibiotic = GetDataTableFromGridView(gvKSD);
                foreach (DataRow drKSD in dataBacteriumAntibiotic.Rows)
                {
                    if (gl_CLSI != drKSD["GUIDELINES"].ToString()) continue;
                    check = true;
                    break;
                }
                if (check == false)
                {
                    CustomMessageBox.MSG_Information_OK(string.Format(
                        "File Import kháng sinh đồ chưa có GuideLine {0}!", gl_CLSI));
                    return false;
                }
            }
            else if (chkBxEUCST.Checked)
            {
                var check = false;
                var gl_EUCST = string.Format("EUCST{0}", dtpGuideLineYear_IP.Value.ToString("yy"));
                dataBacteriumAntibiotic = GetDataTableFromGridView(gvKSD);
                foreach (DataRow drKSD in dataBacteriumAntibiotic.Rows)
                {
                    if (gl_EUCST != drKSD["GUIDELINES"].ToString()) continue;
                    check = true;
                    break;
                }
                if (check == false)
                {
                    CustomMessageBox.MSG_Information_OK(string.Format(
                        "File Import kháng sinh đồ chưa có GuideLine {0}!", gl_EUCST));
                    return false;
                }
            }
            if (cboKyThuat_IP.SelectedIndex != -1)
            {
                var check = false;
                var kyThuat = cboKyThuat_IP.SelectedValue.ToString();
                foreach (DataRow drKSD in dataBacteriumAntibiotic.Rows)
                {
                    if (kyThuat.ToUpper() != drKSD["TESTMETHOD"].ToString().ToUpper()) continue;
                    check = true;
                    break;
                }
                if (check == false)
                {
                    CustomMessageBox.MSG_Information_OK(string.Format(
                        "File Import kháng sinh đồ chưa có Kỹ thuật {0}!", kyThuat));
                    return false;
                }
            }
            return true;
        }

        #region Import ksd theo Viện
        private void ImportKsd()
        {
            if (gvKSD.RowCount <= 0) return;
            //MaKhangSinh, ORG_CODE as MaLoaiViKhuan, DISK_R, DISK_I, DISK_S, MIC_R, MIC_S
            //R: Kháng - S: Nhạy - I: Trung gian 
            dataBacteriumAntibiotic = GetDataTableFromGridView(gvKSD);

            //if (chkBxCLSI.Checked)
            //    gl_CLSI = string.Format("CLSI{0}", dtpGuideLineYear_IP.Value.ToString("yy"));
            //if (chkBxEUCST.Checked)
            //    gl_EUCST = string.Format("EUCST{0}", dtpGuideLineYear_IP.Value.ToString("yy"));
            //var kyThuat = cboKyThuat_IP.SelectedValue.ToString().ToUpper();

            foreach (DataRow drKSD in dataBacteriumAntibiotic.Rows)
            {

                var guideLines = StringConverter.ToString(drKSD["GUIDELINES"]);
                var testMethod = StringConverter.ToString(drKSD["TESTMETHOD"]);

                //if ((guideLines != gl_CLSI && guideLines != gl_EUCST)
                //    || kyThuat != testMethod.ToUpper()
                //    || breakpointType.ToUpper() == "ANIMAL") continue;
                //if (kyThuat != testMethod.ToUpper()) continue;
                //if (breakpointType.ToUpper() == "ANIMAL") continue;

                var objKSD = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();

                var twoDigit = int.Parse(guideLines.Substring(guideLines.Length - 2, 2));
                if (twoDigit > 95)
                {
                    objKSD.Guidelineyear = twoDigit + 1900;
                }
                else
                {
                    objKSD.Guidelineyear = twoDigit + 2000;
                }


                objKSD.Breakpoint_type = StringConverter.ToString(drKSD["BREAKPOINT_TYPE"]);
                objKSD.Host = StringConverter.ToString(drKSD["HOST"]);
                objKSD.Ref_table = StringConverter.ToString(drKSD["REF_TABLE"]);
                objKSD.Ref_seq = StringConverter.ToString(drKSD["REF_SEQ"]);
                objKSD.Whon5_test = StringConverter.ToString(drKSD["WHON5_TEST"]);


                var maKS = StringConverter.ToString(drKSD["WHON5_CODE"]);
                var maVK = StringConverter.ToString(drKSD["ORG_CODE"]);
                var DISK_R = StringConverter.ToString(drKSD["DISK_R"]);
                var DISK_I = StringConverter.ToString(drKSD["DISK_I"]);
                var DISK_S = StringConverter.ToString(drKSD["DISK_S"]);
                var MIC_R = StringConverter.ToString(drKSD["MIC_R"]);
                var MIC_S = StringConverter.ToString(drKSD["MIC_S"]);

                objKSD.Guideline = guideLines;
                //objKSD.Whonetid = drKSD["WHONetID"].ToString();
                //objKSD.Potency = string.IsNullOrEmpty(drKSD["POTENCY"].ToString()) ? string.Empty : drKSD["POTENCY"].ToString(); 
                //objKSD.SiteInfection = string.IsNullOrEmpty(drKSD["SITE_INF"].ToString()) ? string.Empty : drKSD["SITE_INF"].ToString();

                objKSD.Potency = StringConverter.ToString(drKSD["POTENCY"]);
                objKSD.Siteinfection = StringConverter.ToString(drKSD["SITE_INF"]);

                objKSD.Makhangsinh = maKS;
                objKSD.insertWithMess = false;
                objKSD.Mavikhuan = maVK;
                objKSD.Kythuat = testMethod.ToUpper();
                if (testMethod.Equals("DISK", StringComparison.OrdinalIgnoreCase))
                {
                    objKSD.Kythuat = "DISK";
                    if (!string.IsNullOrEmpty(DISK_R) && WorkingServices.IsNumeric(DISK_R))
                        objKSD.Cankhang = float.Parse(DISK_R);

                    var arrI = DISK_I.Split('-');
                    if (arrI.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(arrI[0]) && WorkingServices.IsNumeric(arrI[0]))
                            objKSD.Cantrunggianduoi = float.Parse(arrI[0]);
                    }

                    if (arrI.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(arrI[1]) && WorkingServices.IsNumeric(arrI[1]))
                            objKSD.Cantrunggiantren = float.Parse(arrI[1]);
                    }

                    if (!string.IsNullOrEmpty(DISK_S) && WorkingServices.IsNumeric(DISK_S))
                        objKSD.Cannhay = float.Parse(DISK_S);
                }
                else
                {
                    if (!string.IsNullOrEmpty(MIC_R) && WorkingServices.IsNumeric(MIC_R))
                        objKSD.Cankhang = float.Parse(MIC_R);

                    if (!string.IsNullOrEmpty(MIC_S) && WorkingServices.IsNumeric(MIC_S))
                        objKSD.Cannhay = float.Parse(MIC_S);
                }
                _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan_khangsinh(objKSD);
            }
        }
        #endregion


        #region import kháng sinh đồ cũ
        //private void ImportKsd()
        //{
        //    if (gvKSD.RowCount <= 0) return;
        //    //MaKhangSinh, ORG_CODE as MaLoaiViKhuan, DISK_R, DISK_I, DISK_S, MIC_R, MIC_S
        //    //R: Kháng - S: Nhạy - I: Trung gian 
        //    dataBacteriumAntibiotic = GetDataTableFromGridView(gvKSD);
        //    var gl_CLSI = string.Empty;
        //    var gl_EUCST = string.Empty;

        //    if (chkBxCLSI.Checked)
        //        gl_CLSI = string.Format("CLSI{0}", dtpGuideLineYear_IP.Value.ToString("yy"));
        //    if (chkBxEUCST.Checked)
        //        gl_EUCST = string.Format("EUCST{0}", dtpGuideLineYear_IP.Value.ToString("yy"));
        //    var kyThuat = cboKyThuat_IP.SelectedValue.ToString().ToUpper();

        //    foreach (DataRow drKSD in dataBacteriumAntibiotic.Rows)
        //    {

        //        var breakpointType = StringConverter.ToString(drKSD["BREAKPOINT_TYPE"]);
        //        var guideLines = StringConverter.ToString(drKSD["GUIDELINES"]);
        //        var testMethod = StringConverter.ToString(drKSD["TESTMETHOD"]);

        //        if ((guideLines != gl_CLSI && guideLines != gl_EUCST)
        //            || kyThuat != testMethod.ToUpper()
        //            || breakpointType.ToUpper() == "ANIMAL") continue;
        //        //if (kyThuat != testMethod.ToUpper()) continue;
        //        //if (breakpointType.ToUpper() == "ANIMAL") continue;

        //        var objKSD = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();
        //        //var maKS = drKSD["WHON5_CODE"].ToString();
        //        //var maVK = drKSD["ORG_CODE"].ToString();
        //        //var DISK_R = drKSD["DISK_R"].ToString();
        //        //var DISK_I = drKSD["DISK_I"].ToString();
        //        //var DISK_S = drKSD["DISK_S"].ToString();
        //        //var MIC_R = drKSD["MIC_R"].ToString();
        //        //var MIC_S = drKSD["MIC_S"].ToString();

        //        var maKS = StringConverter.ToString(drKSD["WHON5_CODE"]);
        //        var maVK = StringConverter.ToString(drKSD["ORG_CODE"]);
        //        var DISK_R = StringConverter.ToString(drKSD["DISK_R"]);
        //        var DISK_I = StringConverter.ToString(drKSD["DISK_I"]);
        //        var DISK_S = StringConverter.ToString(drKSD["DISK_S"]);
        //        var MIC_R = StringConverter.ToString(drKSD["MIC_R"]);
        //        var MIC_S = StringConverter.ToString(drKSD["MIC_S"]);

        //        objKSD.Guideline = guideLines;
        //        //objKSD.Whonetid = drKSD["WHONetID"].ToString();
        //        //objKSD.Potency = string.IsNullOrEmpty(drKSD["POTENCY"].ToString()) ? string.Empty : drKSD["POTENCY"].ToString(); 
        //        //objKSD.SiteInfection = string.IsNullOrEmpty(drKSD["SITE_INF"].ToString()) ? string.Empty : drKSD["SITE_INF"].ToString();

        //        objKSD.Potency = StringConverter.ToString(drKSD["POTENCY"]);
        //        objKSD.SiteInfection = StringConverter.ToString(drKSD["SITE_INF"]);

        //        objKSD.Makhangsinh = maKS;
        //        objKSD.insertWithMess = false;
        //        objKSD.Mavikhuan = maVK;
        //        objKSD.Kythuat = testMethod;
        //        if (testMethod.Equals("DISK", StringComparison.OrdinalIgnoreCase))
        //        {
        //            objKSD.Kythuat = "DISK";
        //            if (!string.IsNullOrEmpty(DISK_R) && WorkingServices.IsNumeric(DISK_R))
        //                objKSD.Cankhang = float.Parse(DISK_R);

        //            var arrI = DISK_I.Split('-');
        //            if (arrI.Length > 0)
        //            {
        //                if (!string.IsNullOrEmpty(arrI[0]) && WorkingServices.IsNumeric(arrI[0]))
        //                    objKSD.Cantrunggianduoi = float.Parse(arrI[0]);
        //            }

        //            if (arrI.Length > 1)
        //            {
        //                if (!string.IsNullOrEmpty(arrI[1]) && WorkingServices.IsNumeric(arrI[1]))
        //                    objKSD.Cantrunggiantren = float.Parse(arrI[1]);
        //            }

        //            if (!string.IsNullOrEmpty(DISK_S) && WorkingServices.IsNumeric(DISK_S))
        //                objKSD.Cannhay = float.Parse(DISK_S);
        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(MIC_R) && WorkingServices.IsNumeric(MIC_R))
        //                objKSD.Cankhang = float.Parse(MIC_R);

        //            if (!string.IsNullOrEmpty(MIC_S) && WorkingServices.IsNumeric(MIC_S))
        //                objKSD.Cannhay = float.Parse(MIC_S);
        //        }
        //        _bacteriumAntibioticService.Insert_dm_xetnghiem_vikhuan_khangsinh(objKSD);
        //    }
        //}
        #endregion


        private DataTable GetDataTableFromGridView(GridView view)
        {
            var dt = new DataTable();
            foreach (GridColumn c in view.Columns)
                dt.Columns.Add(c.FieldName, c.ColumnType);
            for (var r = 0; r < view.RowCount; r++)
            {
                var rowValues = new object[dt.Columns.Count];
                for (var c = 0; c < dt.Columns.Count; c++)
                    rowValues[c] = view.GetRowCellValue(r, dt.Columns[c].ColumnName);
                dt.Rows.Add(rowValues);
            }
            return dt;
        }

        private void tabImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabImport.SelectedTab == tabImportBacterium)
            {
                radVKPL.Checked = true;
                txtOleDbPath.Text = pathVKPL;
                setSelectedTab(false);
            }
            else if (tabImport.SelectedTab == tabImportKhangSinh)
            {
                radKS.Checked = true;
                txtOleDbPath.Text = pathKS;
                setSelectedTab(false);
            }
            else if (tabImport.SelectedTab == tabImportKSD)
            {
                radVKKSD.Checked = true;
                txtOleDbPath.Text = pathKSD;
                setSelectedTab(true);
                chkBxCLSI.Checked = false;
                chkBxEUCST.Checked = false;
            }
        }

        private void setSelectedTab(bool res)
        {
            dtpGuideLineYear_IP.Enabled = res;
            chkBxCLSI.Enabled = res;
            chkBxCLSI.Checked = res;
            chkBxEUCST.Enabled = res;
            chkBxEUCST.Checked = res;
            cboKyThuat_IP.Enabled = res;
        }

        private void radVKKSD_CheckedChanged(object sender, EventArgs e)
        {
            tabImport.SelectedIndexChanged -= tabImport_SelectedIndexChanged;
            if (radVKPL.Checked)
            {
                tabImport.SelectedTab = tabImportBacterium;
                txtOleDbPath.Text = pathVKPL;
            }
            else if (radKS.Checked)
            {
                tabImport.SelectedTab = tabImportKhangSinh;
                txtOleDbPath.Text = pathKS;
            }
            else if (radVKKSD.Checked)
            {
                tabImport.SelectedTab = tabImportKSD;
                txtOleDbPath.Text = pathKSD;
            }
            tabImport.SelectedIndexChanged += tabImport_SelectedIndexChanged;
        }

        private void tabBangKhangSinh_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void gvBosKS_ChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            gvBosKS_ChiTiet.CellValueChanged -= gvBosKS_ChiTiet_CellValueChanged;
            CapNhat_BosKS_ChiTiet(e.RowHandle);
            gvBosKS_ChiTiet.CellValueChanged += gvBosKS_ChiTiet_CellValueChanged;
        }

        private void CapNhat_BosKS_ChiTiet(int rowIndex)
        {
            if (gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_MaBang) == null) return;
            var objInfo = new DM_XETNGHIEM_KHANGSINH_BO_CHITIET();
            objInfo.Mabokhangsinh = gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_MaBang).ToString().Trim();
            objInfo.Makhangsinh = gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_MaKhangSinh).ToString().Trim();
            objInfo.Mavikhuan = gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_MaVK).ToString().Trim();
            objInfo.Kythuat = gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_KyThuat).ToString().Trim();
            objInfo.Guideline = gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_GuideLine).ToString().Trim();
            objInfo.Hienthiphieu = NumberConverter.ToBool(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_HienThiPhieu));
            objInfo.Mabangkhangsinh = gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_MaBangKhangSinh).ToString().Trim();
            //var canNhay = string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanNhay).ToString().Trim()) ? null
            //    : gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanNhay).ToString().Trim();
            if (!string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanNhay).ToString().Trim()))
                objInfo.Cannhay = float.Parse(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanNhay).ToString().Trim());
            if (!string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanKhang).ToString().Trim()))
                objInfo.Cankhang = float.Parse(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanKhang).ToString().Trim());
            if (!string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanTrungGianTren).ToString().Trim()))
                objInfo.Cantrunggiantren = float.Parse(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanTrungGianTren).ToString().Trim());
            if (!string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanTrungGianDuoi).ToString().Trim()))
                objInfo.Cantrunggianduoi = float.Parse(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_CanTrungGianDuoi).ToString().Trim());

            objInfo.Giosua = DateTime.Now;
            objInfo.Nguoisua = CommonAppVarsAndFunctions.UserID;
            objInfo.Potency = string.IsNullOrEmpty(gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_Potency).ToString().Trim()) ? string.Empty
                : gvBosKS_ChiTiet.GetRowCellValue(rowIndex, colBosKS_ChiTiet_Potency).ToString().Trim();

            if (!_bacteriumAntibioticService.Update_dm_xetnghiem_khangsinh_bo_chitiet(objInfo)) return;
            gvBosKS_ChiTiet.SetRowCellValue(rowIndex, colBosKS_ChiTiet_NguoiSua, CommonAppVarsAndFunctions.UserID);
            gvBosKS_ChiTiet.SetRowCellValue(rowIndex, colBosKS_ChiTiet_GioSua, DateTime.Now);


        }

        private void chkBreakpoint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBreakpoint.Checked)
            {
                label31.Visible = label15.Visible = dtpBKS_GuideLineYear.Visible = cboPanel_Site_INF.Visible = true;
            }
            else
            {
                label31.Visible = label15.Visible = dtpBKS_GuideLineYear.Visible = cboPanel_Site_INF.Visible = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gcBosKS_ChiTiet);
        }

        private void gvKhangSinh_RowClick(object sender, RowClickEventArgs e)
        {
            Load_ThongTinKhangSinh();
        }

        private void btnLamMoiDSBang_Click(object sender, EventArgs e)
        {
            Load_DanhSach_BangKhangSinh();
        }

        private void chkXemTatCaChiTietPanel_CheckedChanged(object sender, EventArgs e)
        {
            if(chkXemTatCaChiTietPanel.Checked)
            {
                colBosKS_ChiTiet_MaBang.GroupIndex = 0;
            }
            else
                colBosKS_ChiTiet_MaBang.GroupIndex = -1;
            Load_DanhSach_ChiTietBangKhangSinh();
        }
    }
}

