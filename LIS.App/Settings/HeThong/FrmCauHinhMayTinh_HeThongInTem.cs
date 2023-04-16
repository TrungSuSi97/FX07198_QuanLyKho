using System;
using System.Data;
using TPH.LIS.BarcodePrinting;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinhMayTinh_HeThongInTem : FrmTemplate
    {
        public FrmCauHinhMayTinh_HeThongInTem()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _iConfigurationService = new SystemConfigService();
        private void Load_DanhSach_Protocol()
        {
            sluGiaoThuc.DataSource = PrintingSystemProtocolList.Load_DanhSach_Protocol();
            sluGiaoThuc.ValueMember = "Protocol";
            sluGiaoThuc.DisplayMember = "Description";
        }
        private void Load_DanhSach_MayTinh()
        {

            var dtItems = _iConfigurationService.Data_dm_khuvuc_maytinh(string.Empty, string.Empty, string.Empty);
            foreach (DataRow dr in dtItems.Rows)
            {
                if (string.IsNullOrEmpty(dr["IDKhulayMau"].ToString()))
                {
                    dr["IDKhulayMau"] = dr["MaKhuVuc"];
                    dr["TenKhuLayMau"] = dr["TenKhuVuc"];
                }

            }
            dtItems.AcceptChanges();
            gcDanhSach_Barcode.DataSource = dtItems;
            gvDanhSach_Barcode.ExpandAllGroups();
        }
        private void DanhSach_MayXetNghiem()
        {
            var testingMachines = _iConfigurationService.GetTestingMachines();
            gcMayXN.DataSource = testingMachines;
            gvMayXN.ExpandAllGroups();
        }
        private void Load_DanhSach_CauHinh()
        {
            if (gvDanhSach_Barcode.FocusedRowHandle > -1)
            {
                var tenMayTinh = gvDanhSach_Barcode.GetFocusedRowCellValue(colMayTinh_TenMayTinh).ToString();
                var data = _iConfigurationService.Data_DanhSach_CauHinhMayInbarcode(tenMayTinh, 0, 2);
                gcCauHinh.DataSource = data;
                gvCauHinh.ExpandAllGroups();
            }
            else
                gcCauHinh.DataSource = null;
        }
        private void FrmCauHinhMayTinh_HeThongInTem_Load(object sender, EventArgs e)
        {
            Load_DanhSach_MayTinh();
            DanhSach_MayXetNghiem();
            Load_DanhSach_Protocol();
        }

        private void btnThemMay_Click(object sender, EventArgs e)
        {
            if (gvMayXN.FocusedRowHandle > -1 && gvDanhSach_Barcode.FocusedRowHandle > -1)
            {
                var idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colmayXN_IDMay).ToString());
                var tenMayTinh = gvDanhSach_Barcode.GetFocusedRowCellValue(colMayTinh_TenMayTinh).ToString();
                var obj = new DM_MAYTINH_MAYIN();
                obj.Tenmaytinh = tenMayTinh;
                obj.Idmay = idMay;
                _iConfigurationService.Insert_CauHinhMayInbarcode(obj);
                Load_DanhSach_CauHinh();
            }
        }

        private void btnXoaMay_Click(object sender, EventArgs e)
        {
            if(gvCauHinh.FocusedRowHandle >-1)
            {
                var idMay = int.Parse(gvCauHinh.GetFocusedRowCellValue(colCauHinh_IDMay).ToString());
                var tenMayTinh = gvCauHinh.GetFocusedRowCellValue(colCauHinh_TenMayTinh).ToString();
                var obj = new DM_MAYTINH_MAYIN();
                obj.Tenmaytinh = tenMayTinh;
                obj.Idmay = idMay;
                _iConfigurationService.Delete_CauHinhMayInBarcode(obj);
                Load_DanhSach_CauHinh();
            }
        }
        private void Update_CauHinhMayIn(int rowIndex)
        {
            var obj = new DM_MAYTINH_MAYIN();
            obj.Tenmaytinh = gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_TenMayTinh).ToString();
            obj.Idmay = int.Parse(gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_IDMay).ToString());
            obj.Giaothuc = gvCauHinh.GetRowCellValue(rowIndex, colCauhinh_GiaoThuc).ToString();
            obj.Ipmayin = gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_IPMayIn).ToString();
            obj.Duongdan = gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_DuongDan).ToString();
            obj.Taikhoan = gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_TaiKhoan).ToString();
            obj.Matkhau = gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_MatKhau).ToString();
            obj.SuDung = bool.Parse(gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_SuDung).ToString());
            obj.Cong = int.Parse(string.IsNullOrEmpty(gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_Cong).ToString()) ? "0" : gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_Cong).ToString());
            obj.HisId = gvCauHinh.GetRowCellValue(rowIndex, colCauHinh_HisID).ToString();
            obj.BanTiepNhan = gvCauHinh.GetRowCellValue(rowIndex, colBanTiepNhan).ToString();
            _iConfigurationService.Update_CauHinhMayInbarcode(obj);
        }

        private void gvCauHinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.RowHandle >-1)
            {
                Update_CauHinhMayIn(e.RowHandle);
            }
        }

        private void gvDanhSach_Barcode_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSach_CauHinh();
        }
    }
}
