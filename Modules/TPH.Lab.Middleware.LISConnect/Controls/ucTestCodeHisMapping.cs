using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Data.HIS.HISDataCommon;
using TPH.Lab.BusinessService.Models;
using TPH.Data.HIS.Models;
using System.Reflection;
using TPH.Lab.Middleware.LISConnect.DataAccesses;
using TPH.LIS.Common.Extensions;
using TPH.Lab.BusinessService.Services;
using TPH.Lab.Middleware.Helpers.Enum;
using TPH.LIS.Common.Controls;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Configuration.Services.SystemConfig;
using DevExpress.XtraGrid;
using TPH.Controls;

namespace TPH.Lab.Middleware.LISConnect.Controls
{
    public partial class ucTestCodeHisMapping : UserControl
    {
        public ucTestCodeHisMapping()
        {
            InitializeComponent();
        }
        private readonly IConnectHISDataAccess _iHisConfig = new ConnectHISDataAccess();
        private HisConnection hisConnect;
        public HisProvider currentHis = HisProvider.Default;
        public HisMappingCategory currentCategory = HisMappingCategory.All;
        private HISParaInfo hisCatgoryType = HISParaInfo.XetNghiem;
        private readonly HISMappingService hisMapping = new HISMappingService();
        private IWorkingLogService _logService = new WorkingLogService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        public string UserId = string.Empty;
        public HisMappingCategory CategoryMappingHIS
        {
            set
            {
                currentCategory = value;
                SetDataPropertyNameForDatagriviewColumn();
            }
        }
        public string AutoFilterMaDichVu
        {
            set
            {
                gvDanhSachLIS.SetRowCellValue(GridControl.AutoFilterRowHandle, colLIS_HISID, value);
            }
        }
        public void LoadCauHinh()
        {
            SetDataPropertyNameForDatagriviewColumn();
            ControlExtension.SetLowerCaseForXGridColumns(gvDanhSachLIS);
            LoadDanhSachLIS();
            ucDanhSachXetNghiem1.AutoExpandAll = true;
            ucDanhSachXetNghiem1.isAdmin = true;
            ucDanhSachXetNghiem1.Load_DanhSach(null);
            Load_danhmucprofile();
            panel1.BackColor = panel2.BackColor = splitContainer1.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        public void Load_danhmucprofile()
        {
            var data = _systemConfigService.Data_dm_xetnghiem_profile(string.Empty);
            if (data != null)
            {
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcDanhSachProfile.DataSource = data;
        }
        private void LoadDanhSachLIS()
        {
            var data = WorkingServices.ConvertToDataTable(XetNghiemHISService.GetInstance().GetListHisMapping_All());
            if(data != null)
            {
                if(data.Rows.Count > 0)
                {
                    data = WorkingServices.SearchResult_OnDatatable(data, string.Format("HisProviderId = {0}", (int)currentHis));
                    data.Columns.Add("SortColumn", typeof(string));
                    if(data.Rows.Count >0)
                    {
                        foreach (DataRow dr in data.Rows)
                        {
                            dr["SortColumn"] = string.IsNullOrEmpty(dr["macaptren"].ToString()) ? dr["madichvu"].ToString() : string.Format("{0}_{1}", dr["macaptren"].ToString(), dr["madichvu"].ToString());
                        }
                        data.DefaultView.Sort = "loaidvHIS,nhomxn,SortColumn";
                        data = data.DefaultView.ToTable();
                    }
                }
            }
            data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcDanhSachLIS.DataSource = data;
        }
        private void LoadDanhSachHIS()
        {
            gcDanhSachHIS.DataSource = null;
            var obj = _iHisConfig.DanhMucHIS(hisCatgoryType, hisConnect, _iHisConfig.DataHisThongTinHam());
            if (obj.Data != null)
            {
                var data = WorkingServices.ConvertColumnNameToLower_Upper(obj.Data, true);
                gcDanhSachHIS.DataSource = obj.Data;
            }
            else
            {
                if (!string.IsNullOrEmpty(obj.Message))
                {
                    CustomMessageBox.MSG_Information_OK(obj.Message);
                }
                else
                    CustomMessageBox.MSG_Information_OK("Có lỗi khi lấy danh mục từ HIS");
            }
        }
        private HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            var function = from item in hisColumns
                           where item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
                return function.FirstOrDefault();
            return null;
        }
        private void SetDataPropertyNameForDatagriviewColumn()
        {
            var hisConnectList = _iHisConfig.DataHisThongTin();
            if (hisConnectList != null)
            {
                hisConnect = hisConnectList.Where(x => ((int)x.HisID).Equals((int)currentHis)).FirstOrDefault();
                if (hisConnect != null)
                {

                    var hisColumns = _iHisConfig.DataHisThongTinMappingCot();
                    var HisColumnsName = GetHisColumnNameConfiguartion(hisConnect, hisColumns);

                    hisCatgoryType = HISParaInfo.XetNghiem;
                    colHIS_HISID.FieldName = HisColumnsName.dmDichvuMadichvu;
                    colHIS_ItemName.FieldName = HisColumnsName.dmDichvuTendichvu;
                    colHIS_LoaiDichVu.FieldName = HisColumnsName.dmDichvuLoaiDichVu;
                    colHIS_MasterID.FieldName = HisColumnsName.dmDichvuMaCapTren;
                    ControlExtension.SetLowerCaseForXGridColumns(gvDanhSachHIS);
                }
            }
        }

        private void btnLamMoidanhSachLIS_Click(object sender, EventArgs e)
        {
            LoadDanhSachLIS();
        }

        private void btnLoadDSHIS_Click(object sender, EventArgs e)
        {
            LoadDanhSachHIS();
        }

        private void gvDanhSachLIS_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.OptionsColumn.ReadOnly == false && e.Column.OptionsColumn.AllowEdit)
            {
                if (!oldValueHIS.Equals(e.Value.ToString()))
                {
                    var logDefine = "";
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        //Kiểm tra profile và mã xn có tồn tại không
                        if (e.Column == colLIS_ProfileId)
                        {
                            if (!_systemConfigService.CheckExists_dm_xetnghiem_profile(e.Value.ToString()))
                            {
                                CustomMessageBox.MSG_Error_OK("Mã profile không tồn tại.");
                                return;
                            }
                            logDefine = "Đổi mapping HIS ({0}): Mã Profile {1} => {2}";
                        }
                        else if (e.Column == colLIS_LISID)
                        {

                            if (!_systemConfigService.CheckExists_dm_xetnghiem(e.Value.ToString()))
                            {
                                CustomMessageBox.MSG_Error_OK("Mã xét nghiệm không tồn tại.");
                                return;
                            }
                            logDefine = "Đổi mapping HIS ({0}): Mã xét nghiệm {1} => {2}";
                        }
                        else if(e.Column == colLIS_IsProfile)
                        {
                            logDefine = "Đổi mapping HIS ({0}): Loại profile {1} => {2}";
                        }
                        else if (e.Column == colLis_ThongSoCon)
                        {
                            logDefine = "Đổi mapping HIS ({0}): Thông số con {1} => {2}";
                        }
                    }
                    var objUpdate = new XetNghiemMapping
                    {
                        Hisproviderid = (int)currentHis
                   ,
                        Isprofile = bool.Parse(gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_IsProfile).ToString())
                   ,
                        Madichvu = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_HISID).ToString()
                   ,
                        Maprofilelis = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_ProfileId).ToString()
                   ,
                        Maxnlis = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_LISID).ToString()
                   ,
                        Nguoinhap = UserId
                   ,
                        Thongsocon = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLis_ThongSoCon).ToString()
                    };
                    if (string.IsNullOrEmpty(gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_NguoiNhap).ToString()))
                    {
                        gvDanhSachLIS.SetRowCellValue(e.RowHandle, colLIS_NguoiNhap, UserId);
                    }
                    else
                    {
                   
                        //Ghi log chỉnh sửa
                        _logService.Insert_HeThong_NhatKyDanhMuc(new LIS.Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)LIS.Log.LogActionId.Update,
                            Madanhmuc = objUpdate.Madichvu,
                            Nguoithuchien = UserId,
                            Noidung = string.Format(logDefine, currentHis.ToString(), oldValueHIS, e.Value.ToString()),
                            Idnhatky = LIS.Log.LogTableIds.Dm_xetnghiem_his,
                            Pcthuchien = Environment.MachineName
                        });

                    }

                    XetNghiemHISService.GetInstance().UpdateMappingXetNghiem(objUpdate);
                }
            }
        }
        string oldValueHIS = string.Empty;
        private void gvDanhSachLIS_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
                oldValueHIS = gvDanhSachLIS.GetRowCellValue(e.RowHandle, e.Column).ToString();
        }

        private void btnDongBoLIS_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu danh mục dịch vụ HIS về LIS ?"))
                {
                    progressBar1.Maximum = gvDanhSachHIS.RowCount;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;

                    var mappingCheck = new XetNghiemHISInfo();
                    for (int i = 0; i < gvDanhSachHIS.RowCount; i++)
                    {
                        mappingCheck = new XetNghiemHISInfo();
                        progressBar1.Value++;
                        var madmHIS = gvDanhSachHIS.GetRowCellValue(i, colHIS_HISID).ToString();
                        var tendmHIS = gvDanhSachHIS.GetRowCellValue(i, colHIS_ItemName).ToString();
                        var masterId = (gvDanhSachHIS.GetRowCellValue(i, colHIS_MasterID) ?? (string.Empty)).ToString();
                        var loaidvHIS = (gvDanhSachHIS.GetRowCellValue(i, colHIS_LoaiDichVu) ?? (string.Empty)).ToString();
                        mappingCheck.HisProviderID = (int)currentHis;
                        mappingCheck.madichvu = madmHIS;
                        mappingCheck.macaptren = masterId;
                        mappingCheck.tendichvu = tendmHIS;
                        mappingCheck.loaidvHIS = loaidvHIS;
                        mappingCheck.NguoiNhap = UserId;
                        XetNghiemHISService.GetInstance().SyncXetNghiem(mappingCheck);
                    }
                    progressBar1.Visible = false;
                    LoadDanhSachLIS();
                }
            }
            catch (Exception ex)
            {
                progressBar1.Visible = false;
                CustomMessageBox.MSG_Error_OK(ex.Message, ex);
            }

        }

        private void btnMappingHIS_Click(object sender, EventArgs e)
        {
            if(gvDanhSachHIS.FocusedRowHandle >-1 && gvDanhSachLIS.FocusedRowHandle >-1)
            {
                gvDanhSachLIS.SetRowCellValue(gvDanhSachLIS.FocusedRowHandle, colLIS_HISID, gvDanhSachHIS.GetFocusedRowCellValue(colHIS_HISID));
            }
        }

        private void txtMaDVHIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtMaCapTrenHIS);
        }

        private void txtMaCapTrenHIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenDVHis);
        }

        private void txtTenDVHis_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemDVHis);
        }

        private void btnThemDVHis_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMaDVHIS.Text))
            {
                if (!string.IsNullOrEmpty(txtTenDVHis.Text))
                {
                    var mappingCheck = new XetNghiemHISInfo();
                    mappingCheck.HisProviderID = (int)currentHis;
                    mappingCheck.madichvu = txtMaDVHIS.Text;
                    mappingCheck.macaptren = txtMaCapTrenHIS.Text;
                    mappingCheck.tendichvu = txtTenDVHis.Text;
                    mappingCheck.loaidvHIS = txtLoaiHIS.Text;
                    mappingCheck.NguoiNhap = UserId;
                    XetNghiemHISService.GetInstance().SyncXetNghiem(mappingCheck);
                    LoadDanhSachLIS();
                    gvDanhSachLIS.FocusedRowHandle = gvDanhSachLIS.LocateByValue(colLIS_HISID.FieldName, txtMaDVHIS.Text);
                    txtMaDVHIS.Text = String.Empty;
                    txtTenDVHis.Text = String.Empty;
                    txtMaDVHIS.Focus();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập tên dịch vụ.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã dịch vụ.");
        }

        private void txtMaDVHIS_Enter(object sender, EventArgs e)
        {
            if(sender is TextBox)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
