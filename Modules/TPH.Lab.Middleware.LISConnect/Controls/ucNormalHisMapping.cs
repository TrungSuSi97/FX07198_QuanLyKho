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
using DevExpress.XtraGrid;
using TPH.Controls;

namespace TPH.Lab.Middleware.LISConnect.Controls
{
    public partial class ucNormalHisMapping : UserControl
    {
        public ucNormalHisMapping()
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
        }
        private void LoadDanhSachLIS()
        {
            gcDanhSachLIS.DataSource = null;
            var data = WorkingServices.ConvertToDataTable(hisMapping.GetMappingData(currentCategory, (int)currentHis));
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

                ucGroupHeader5.Text = "HIS CHƯA ĐƯỢC ĐỊNH NGHĨA";
                if (hisConnect != null)
                {
                    if (currentCategory != HisMappingCategory.All)
                    {
                        var hisColumns = _iHisConfig.DataHisThongTinMappingCot();
                        var HisColumnsName = GetHisColumnNameConfiguartion(hisConnect, hisColumns);

                        if (currentCategory == HisMappingCategory.ChanDoan)
                        {
                            hisCatgoryType = HISParaInfo.ChanDoan;
                            colHIS_HISID.FieldName = HisColumnsName.dmChanDoanMaChanDoan;
                            colHIS_ItemName.FieldName = HisColumnsName.dmChanDoanTenChanDoan;
                            colHIS_InternalPatient.Visible = false;
                            colHIS_MasterID.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC CHẨN ĐOÁN";

                        }
                        else if (currentCategory == HisMappingCategory.DoiTuong)
                        {
                            hisCatgoryType = HISParaInfo.Doituong;
                            colHIS_HISID.FieldName = HisColumnsName.dmDoiTuongDichVuMaDoiTuongDichVu;
                            colHIS_ItemName.FieldName = HisColumnsName.dmDoiTuongDichVuTenDoiTuongDichVu;
                            colHIS_InternalPatient.Visible = false;
                            colHIS_MasterID.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC ĐỐI TƯỢNG";

                        }
                        else if (currentCategory == HisMappingCategory.KhoaPhong)
                        {
                            hisCatgoryType = HISParaInfo.KhoaPhong;
                            colHIS_HISID.FieldName = HisColumnsName.dmKhoaPhongMaKhoa;
                            colHIS_ItemName.FieldName = HisColumnsName.dmKhoaPhongTenKhoa;
                            colHIS_InternalPatient.FieldName = HisColumnsName.dmKhoaPhongNoiTru;
                            colHIS_MasterID.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC KHOA";
                        }
                        else if (currentCategory == HisMappingCategory.Phong)
                        {
                            hisCatgoryType = HISParaInfo.Phong;
                            colHIS_HISID.FieldName = HisColumnsName.dmPhongMaPhong;
                            colHIS_ItemName.FieldName = HisColumnsName.dmPhongTenPhong;
                            colHIS_MasterID.FieldName = HisColumnsName.dmPhongMaKhoa;
                            colHIS_InternalPatient.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC PHÒNG";
                        }
                        else if (currentCategory == HisMappingCategory.MayXetNghiem)
                        {
                            hisCatgoryType = HISParaInfo.MayXN;
                            colHIS_HISID.FieldName = HisColumnsName.dmMayXNIdMay;
                            colHIS_ItemName.FieldName = HisColumnsName.dmMayXNTenMay;
                            colHIS_MasterID.FieldName = HisColumnsName.dmMayXNIdMayBHYT;
                            colHIS_MasterID.Caption = "Mã máy theo BHYT";
                            colHIS_InternalPatient.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC MÁY XÉT NGHIỆM";
                        }
                        else if (currentCategory == HisMappingCategory.NhanVien)
                        {
                            hisCatgoryType = HISParaInfo.BacSi;
                            colHIS_HISID.FieldName = HisColumnsName.dmNhanVienMaNhanVien;
                            colHIS_ItemName.FieldName = HisColumnsName.dmNhanVienTenNhanVien;
                            colHIS_MasterID.Visible = false;
                            colHIS_InternalPatient.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC NHÂN VIÊN";
                        }
                        else if (currentCategory == HisMappingCategory.SinhLy)
                        {
                            hisCatgoryType = HISParaInfo.SinhLy;
                            colHIS_HISID.FieldName = HisColumnsName.dmSinhLyMaSinhLy;
                            colHIS_ItemName.FieldName = HisColumnsName.dmSinhLyTenSinhLy;
                            colHIS_MasterID.Visible = false;
                            colHIS_InternalPatient.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC SINH LÝ";
                        }
                        else if (currentCategory == HisMappingCategory.CongTyHopDong)
                        {
                            hisCatgoryType = HISParaInfo.CongtyHopDong;
                            colHIS_HISID.FieldName = HisColumnsName.dmMaCongTyHD;
                            colHIS_ItemName.FieldName = HisColumnsName.dmTenCongTyHD;
                            colHIS_MasterID.Visible = false;
                            colHIS_InternalPatient.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC CÔNG TY HỢP ĐỒNG";
                        }
                        else if (currentCategory == HisMappingCategory.LoaiMau)
                        {
                            hisCatgoryType = HISParaInfo.LoaiMau;
                            colHIS_HISID.FieldName = HisColumnsName.dmLoaiMauMaLoaiMau;
                            colHIS_ItemName.FieldName = HisColumnsName.dmLoaiMauTenLoaiMau;
                            colHIS_MasterID.Visible = false;
                            colHIS_InternalPatient.Visible = false;
                            ucGroupHeader5.GroupCaption = "DANH MỤC LOẠI MẪU";
                        }
                    }
                    ControlExtension.SetLowerCaseForXGridColumns(gvDanhSachHIS);
                }
            }
            panel1.BackColor = panel2.BackColor = splitContainerControl1.BackColor = CommonAppColors.ColorMainAppFormColor;
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
                    var objUpdate = new HISMapping
                    {
                        LISID = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_LISID).ToString()
                         ,
                        HISID = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_HISID).ToString()
                         ,
                        ItemName = gvDanhSachLIS.GetRowCellValue(e.RowHandle, colLIS_TenDMLIS).ToString()
                         ,
                        CategoryID = (int)currentCategory
                         ,
                        HisProviderID = (int)currentHis
                         ,
                        NguoiNhap = UserId
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
                            Madanhmuc = objUpdate.LISID,
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Đổi mapping HIS ({0}): Mã HIS Mapping {1} => {2}", currentHis.ToString(), oldValueHIS, e.Value.ToString()),
                            Idnhatky = LIS.Log.LogTableIds.Dm_mappingHIS,
                            Pcthuchien = Environment.MachineName
                        });
                    }
                    hisMapping.Insert_Update_MappingData(objUpdate);
                }
            }
        }
        string oldValueHIS = string.Empty;
        private void gvDanhSachLIS_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
                oldValueHIS = (gvDanhSachLIS.GetRowCellValue(e.RowHandle, e.Column)??(string.Empty)).ToString();
        }

        private void btnDongBoLIS_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Đồng bộ danh mục HIS về LIS ?"))
                {
                    progressBar1.Maximum = gvDanhSachHIS.RowCount;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;
                    var mappingCheck = new HISMapping();
                    for (int i = 0; i < gvDanhSachHIS.RowCount; i++)
                    {
                        progressBar1.Value++;
                        var madmHIS = gvDanhSachHIS.GetRowCellValue(i, colHIS_HISID).ToString();
                        var tendmHIS = gvDanhSachHIS.GetRowCellValue(i, colHIS_ItemName).ToString();
                        var masterId = (gvDanhSachHIS.GetRowCellValue(i, colHIS_MasterID) ?? (string.Empty)).ToString();
                        mappingCheck.HisProviderID = (int)currentHis;
                        mappingCheck.CategoryID = (int)currentCategory;
                        mappingCheck.HISID = madmHIS;
                        mappingCheck.LISID = madmHIS;
                        mappingCheck.MasterID = masterId;
                        mappingCheck.ItemName = tendmHIS;
                        mappingCheck.NguoiNhap = UserId;
                        hisMapping.Insert_Update_MappingData(mappingCheck);
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
    }
}
