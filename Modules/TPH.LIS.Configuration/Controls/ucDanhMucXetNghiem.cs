using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using DevExpress.XtraGrid.Columns;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;
using TPH.LIS.Log.Services.WorkingLog;
using DevExpress.XtraEditors.Repository;
using TPH.Controls;
using TPH.Excel;
using DevExpress.ClipboardSource.SpreadsheetML;
using System.IO;
using TPH.Common.Contants;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucXetNghiem : UserControl
    {
        public ucDanhMucXetNghiem()
        {
            InitializeComponent();
            
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public string UserId = string.Empty;

        bool isCreatedGrid = false;
        public bool isAdmin = false;
        public string[] arrPhanQuyenNhom = new string[0];

        public event EventHandler ButtonDMLoaiMauClick;
        public event EventHandler ButtonLuuXNMoiClick;
        public event EventHandler ButtonXoaXNClick;
        public event EventHandler LuoiDMChinhSua;
        private string TableName = "TPHDMXetNghiem";
        public DataTable CurrentDataSource;
        public void GetDanhMuc()
        {
            var data = _systemConfigService.Data_dm_xetnghiem(string.Join(",", arrPhanQuyenNhom), !isAdmin, string.Empty);
            CurrentDataSource = null;
            if (data != null)
            {
                CurrentDataSource = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            CurrentDataSource.TableName = TableName;
            gcDanhMucXetNghiem.DataSource = data;
            gvDanhMucXetNghiem.ExpandAllGroups();

        }
        public void Load_Nhom()
        {
            var subclinicalTestGroup = _systemConfigService.Data_dm_xetnghiem_nhom(isAdmin ? string.Empty : string.Join(",", arrPhanQuyenNhom));
            cboMaNhomCLS.DataSource = subclinicalTestGroup;
            cboMaNhomCLS.ValueMember = ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Manhomcls);
            cboMaNhomCLS.DisplayMember = ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Tennhomcls);
            cboMaNhomCLS.SelectedIndex = -1;
            lblTTin.DataBindings.Clear();
            lblTTin.DataBindings.Add("Text", cboMaNhomCLS.DataSource, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Thutuin));
            cboMaNhomCLS.SelectedIndexChanged += CboMaNhomCLS_SelectedIndexChanged;
        }
        public void Load_LoaiMau()
        {
            var testGroups = _systemConfigService.Data_dm_xetnghiem_loaimau(string.Empty, string.Empty);
            ControlExtension.BindDataToCobobox(testGroups, ref cboSampleType, "MaLoaiMau", "TenLoaiMau");
            var data = testGroups.DefaultView.ToTable(false, "MaLoaiMau", "TenLoaiMau");
            data.Columns["MaLoaiMau"].Caption = "Mã loại mẫu";
            data.Columns["TenLoaiMau"].Caption = "Tên loại mẫu";
            DataRow dr = data.NewRow();
            dr["MaLoaiMau"] = DBNull.Value;
            dr["TenLoaiMau"] = "---NONE---";
            data.Rows.InsertAt(dr, 0);
            var gridCol = gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaimau)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cbo.DataSource = data;
            cbo.ValueMember = "MaLoaiMau";
            cbo.DisplayMember = "TenLoaiMau";
            cbo.NullValuePrompt = "--NONE--";
            gridCol.ColumnEdit = cbo;

            var gridCol2 = gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaimau2)];
            var cbo2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cbo2.DataSource = data;
            cbo2.ValueMember = "MaLoaiMau";
            cbo2.DisplayMember = "TenLoaiMau";
            cbo2.NullValuePrompt = "--NONE--";
            gridCol2.ColumnEdit = cbo2;

            var gridCol3 = gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaimauphu)];
            var cbo3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cbo3.DataSource = data;
            cbo3.ValueMember = "MaLoaiMau";
            cbo3.DisplayMember = "TenLoaiMau";
            cbo3.NullValuePrompt = "--NONE--";
            gridCol3.ColumnEdit = cbo3;
        }
        private void Load_LoaiXetNghiem()
        {
            var gridCol = gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaixetnghiem)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            var dataSource = WorkingServices.ConvertToDataTable(TestType.ListTestType());
            dataSource.Columns["TestTypeID"].Caption = "ID";
            dataSource.Columns["TestTypeName"].Caption = "Tên loại xét nghiệm";
            cbo.DataSource = dataSource;
            cbo.ValueMember = "TestTypeID";
            cbo.DisplayMember = "TestTypeName";
            gridCol.ColumnEdit = cbo;
        }
        private void Load_ConstantMauInSHPT()
        {
            var gridCol = gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Mauinshpt)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            var dataSource = WorkingServices.ConvertToDataTable(ReportMicrobiologyTemplateConstant.ListReportType().ToList());
            dataSource.Columns["ReportID"].Caption = "ID";
            dataSource.Columns["ReportName"].Caption = "Tên loại mẫu";
            cbo.DataSource = dataSource;
            cbo.ValueMember = "ReportID";
            cbo.DisplayMember = "ReportName";
            gridCol.ColumnEdit = cbo;

        }
        public void Load_Config()
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM(), gvDanhMucXetNghiem, "coldm_", true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Maxn)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Thoigiannhap) });
                gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Noikiemtrachatluong)].ColumnEdit = new RepositoryItemRichTextEdit();
                gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Noikiemtrachatluong)].Width = 350;
                gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Tenxnshptheso)].Width = 250;
                gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Tenxnshpt)].Width = 350;
                gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Shptgenname)].Width = 150;
                var gridCol1 = gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Csbt)];
                var itm = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                gridCol1.ColumnEdit = itm;
                Load_ConstantMauInSHPT();
                clTenNhomCLS.GroupIndex = 0;

                isCreatedGrid = true;
                pnThemXetNghiem.BackColor = CommonAppColors.ColorMainAppFormColor;
            }
            Load_Nhom();
            Load_LoaiMau();
            Load_LoaiXetNghiem();
        }
        private void CboMaNhomCLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhomCLS.SelectedIndex > -1)
            {
                if (string.IsNullOrEmpty(txtTestCode.Text))
                    txtTestCode.Text = string.Format("{0}_", cboMaNhomCLS.SelectedValue.ToString().Trim());
                else if (txtTestCode.Text.Contains("_"))
                {
                    var split = txtTestCode.Text.Trim().Split('_');
                    txtTestCode.Text = txtTestCode.Text.Replace(split[0], string.Format("{0}", cboMaNhomCLS.SelectedValue.ToString().Trim()));
                }
                else
                    txtTestCode.Text = string.Format("{0}_{1}", cboMaNhomCLS.SelectedValue.ToString().Trim(), txtTestCode.Text);
            }
            else
            {
                txtTestCode.Text = string.Empty;
            }
        }
        private bool TestCodeIsusing(string testCode)
        {
            var testResult = _systemConfigService.XetNghiemDangDung(testCode);
            return testResult != null && testResult.Rows.Count > 0;
        }
        private void Update_XetNghiem(int index)
        {
            var maxn = gvDanhMucXetNghiem.GetRowCellValue(index, clTestCode).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem(maxn);
            var objSource = obj.Copy();
            DataRow row = gvDanhMucXetNghiem.GetDataRow(index);
            // object val = row["<YourFieldName>", DataRowVersion.Original];
            obj = (DM_XETNGHIEM)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM(), row);
            obj.Thoigiannhap = objSource.Thoigiannhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = maxn,
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem(obj);
            //bubble the event up to the parent
            this.LuoiDMChinhSua?.Invoke(this, new EventArgs());
        }
        private void btnDongThemMoi_Click(object sender, EventArgs e)
        {
            pnThemXetNghiem.Visible = false;
        }

        private void btnThemXetNghiem_Click(object sender, EventArgs e)
        {
            pnThemXetNghiem.Visible = true;
        }

        private void gvDanhMucXetNghiem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Update_XetNghiem(e.RowHandle);
        }

        private void btnLamMoiDanhSach_Click(object sender, EventArgs e)
        {
            GetDanhMuc();
        }

        private void btnXoaXetNghiem_Click(object sender, EventArgs e)
        {
            if(gvDanhMucXetNghiem.FocusedRowHandle>-1)
            {
                var maxn = gvDanhMucXetNghiem.GetFocusedRowCellValue(clTestCode).ToString();
                var tenXN = gvDanhMucXetNghiem.GetFocusedRowCellValue(clTestName).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa xét nghiệm: {0} ?", maxn) ))
                {
                    if (!TestCodeIsusing(maxn))
                    {
                        var obj = _systemConfigService.Get_Info_dm_xetnghiem(maxn);
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = maxn,
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa xét nghiệm: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem,
                            Pcthuchien = Environment.MachineName
                        });
                        _systemConfigService.Delete_dm_xetnghiem(maxn);
                        GetDanhMuc();
                        //bubble the event up to the parent
                        this.ButtonXoaXNClick?.Invoke(this, e);
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Xét nghiệm đã được sử dụng, không thể xóa.");
                }
            }
        }

        private void btnCallCharacterMap_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("charmap.exe");
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(string.Format("Lỗi gọi character map:{0}{1}", Environment.NewLine, ex.Message));
            }
        }

        private void btnLuuXetNghiem_Click(object sender, EventArgs e)
        {
            if (cboMaNhomCLS.SelectedIndex > -1)
            {
                if (cboSampleType.SelectedIndex > -1)
                {
                    if (!string.IsNullOrEmpty(txtTestCode.Text))
                    {
                        var obj = new DM_XETNGHIEM();
                        obj.Maxn = txtTestCode.Text;
                        obj.Tenxn = txtTestName.Text;
                        obj.Manhomcls = cboMaNhomCLS.SelectedValue.ToString();
                        obj.Loaimau = cboSampleType.SelectedValue.ToString();
                        obj.Csbt = txtNormalRange.Text;
                        obj.Nguongduoi = WorkingServices.ValueString_FloatNull(txtLowerLimit.Text);
                        obj.Nguongtren = WorkingServices.ValueString_FloatNull(txtUpperLimit.Text);
                        obj.Giachuan = WorkingServices.ValueString_Int_Zero(txtPrice.Text);
                        obj.Dkdanhgia = txtCriteria.Text;
                        obj.Sapxep = WorkingServices.ValueString_Int_Zero(txtSapXep.Text);
                        obj.Thutuin = WorkingServices.ValueString_Int_Zero(lblTTin.Text);
                        obj.Indam = chkBoldName.Checked;
                        obj.Indamkq = chkBoldResult.Checked;
                        obj.Khongdanhgia = chkKhongDanhGia.Checked;
                        obj.Xnchinh = chkXNCha.Checked;
                        obj.Khongsd = chkXnDichVu.Checked;
                        obj.Donvi = txtUnit.Text;
                        obj.Nguoinhap = UserId;
                        if (_systemConfigService.Insert_dm_xetnghiem(obj) > 0)
                        {
                            GetDanhMuc();
                            //bubble the event up to the parent
                            this.ButtonLuuXNMoiClick?.Invoke(this, e);
                            gvDanhMucXetNghiem.FocusedRowHandle = gvDanhMucXetNghiem.LocateByValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Maxn), obj.Maxn);
                            txtTestCode.Focus();
                        }
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Hãy nhập mã xét nghiệm");
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn loại mẫu");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn nhóm xét nghiệm");
        }

        private void txtSapXep_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            ControlExtension.LeaveFocusNext(e, cboMaNhomCLS);
        }

        private void cboMaNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTestCode);
        }

        private void txtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTestName);
        }

        private void txtTestName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboSampleType);
        }

        private void cboSampleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtUnit);
        }

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtLowerLimit);
        }

        private void txtLowerLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            ControlExtension.LeaveFocusNext(e, txtUpperLimit);
        }

        private void txtUpperLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            ControlExtension.LeaveFocusNext(e, txtNormalRange);
        }

        private void chkXNCha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, chkXnDichVu);
        }

        private void chkKhongDanhGia_KeyPress(object sender, KeyPressEventArgs e)
        {
      
            ControlExtension.LeaveFocusNext(e, chkBoldName);
        }

        private void chkBoldName_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            ControlExtension.LeaveFocusNext(e, chkBoldResult);
        }

        private void chkXnDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, chkKhongDanhGia);
        }

        private void txtCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPrice);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            ControlExtension.LeaveFocusNext(e, chkXNCha);
        }

        private void btnXoaThongTin_Click(object sender, EventArgs e)
        {
            txtCriteria.Text = string.Empty;
            txtLowerLimit.Text = string.Empty;
            txtNormalRange.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtSapXep.Text = "1000";
            txtTestCode.Text = string.Empty;
            txtTestName.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtUpperLimit.Text = string.Empty;
            chkBoldName.Checked = false;
            chkBoldResult.Checked = false;
            chkKhongDanhGia.Checked = false;
            chkXNCha.Checked = false;
            chkXnDichVu.Checked = false;
        }

        private void btnQuanLyLoaiMau_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            this.ButtonDMLoaiMauClick?.Invoke(this, e);
        }

        private void gcDanhMucXetNghiem_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var grid = (GridControl)sender;
                if (gvDanhMucXetNghiem.FocusedColumn != gvDanhMucXetNghiem.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Noikiemtrachatluong)])
                {
                    ((ColumnView)grid.FocusedView).FocusedRowHandle++;
                    e.Handled = true;
                }
            }
        }

        private void btnXuatExcelDanhmucXN_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gvDanhMucXetNghiem);
        }
    }
}
