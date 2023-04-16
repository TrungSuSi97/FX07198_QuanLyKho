using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Analyzer.Model;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucPCUpdateResultConfig : UserControl
    {
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public string PCWorkPlace = string.Empty;
        public string[] arrAnalyzerAllow = null;
        public string UserId = string.Empty;
        public ucPCUpdateResultConfig()
        {
            InitializeComponent();
        }
        public void LoadConfig()
        {
            ControlExtension.SetLowerCaseForXGridColumns(gvDSMayTinh);
            ControlExtension.SetLowerCaseForXGridColumns(gvMayXN);
            ControlExtension.SetLowerCaseForXGridColumns(gvMayXnKhaiBao);
            LoadDanhSachMayTinh_KhuVuc();
            Load_MayXetNghiem();
        }
        private void LoadDanhSachMayTinh_KhuVuc()
        {
            var data = _isSysConfig.Data_dm_khuVu_maytinh(PCWorkPlace, string.Empty);
            gcDanhSachMayTinh.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gvDSMayTinh.ExpandAllGroups();
            gvDSMayTinh.FocusedRowHandle =  gvDSMayTinh.LocateByValue(colTenMayTinh.FieldName, Environment.MachineName);
        }
        private void Load_MayXetNghiem()
        {
            if (arrAnalyzerAllow != null)
            {
                if (arrAnalyzerAllow.Count() > 0)
                {
                    string allowanalyzer = Utilities.ArrayToSqlValue(arrAnalyzerAllow);
                    var mayXetNghiem = from selectData in _iAnalyzerConfig.Data_h_mayxetnghiem().AsEnumerable()
                                       where allowanalyzer.Contains(string.Format("'{0}'", selectData["idmay"].ToString()))
                                       select selectData;
                    if (mayXetNghiem.Any())
                    {
                        var data = mayXetNghiem.AsDataView().ToTable();

                        foreach (DataColumn dtc in data.Columns)
                        {
                            dtc.ColumnName = dtc.ColumnName.ToLower();
                        }
                        gcMayXN.DataSource = data;
                    }
                    else
                        gcMayXN.DataSource = null;
                }
            }
        }
        private void Load_DanhSach_MayXnTheoMayTinh()
        {
            gcMayXnKhaiBao.DataSource = null;
            if (gvDSMayTinh.FocusedRowHandle > -1)
            {
                var maKhuVuc = WorkingServices.ObjecToString(gvDSMayTinh.GetFocusedRowCellValue(colMaKhuVuc));
                var maytinh = WorkingServices.ObjecToString(gvDSMayTinh.GetFocusedRowCellValue(colTenMayTinh));
                var data = WorkingServices.ConvertColumnNameToLower_Upper(_iAnalyzerConfig.Data_dm_maytinh_mayxetnghiem(maKhuVuc, maytinh, null), true);
                gcMayXnKhaiBao.DataSource = data;
                gvMayXnKhaiBao.ExpandAllGroups();
            }
        }

        private void ThemCauHinhMayXn()
        {
            if (gvDSMayTinh.FocusedRowHandle > -1 && gvMayXN.SelectedRowsCount > 0)
            {
                var obj = new DM_MAYTINH_MAYXETNGHIEM();
                obj.Makhuvuc= WorkingServices.ObjecToString(gvDSMayTinh.GetFocusedRowCellValue(colMaKhuVuc));
                obj.Tenmaytinh = WorkingServices.ObjecToString(gvDSMayTinh.GetFocusedRowCellValue(colTenMayTinh));
                obj.Nguoinhap = UserId;
                foreach (var item in gvMayXN.GetSelectedRows())
                {
                    if (item > -1)
                    {
                        obj.Idmayxetnghiem = int.Parse(WorkingServices.ObjecToString(gvMayXN.GetRowCellValue(item, colIDMayXn)));
                        if (_iAnalyzerConfig.Insert_dm_maytinh_mayxetnghiem(obj) < 0)
                        {
                            CustomMessageBox.MSG_Information_OK(string.Format("ID máy : {0} đã tồn tại.", obj.Idmayxetnghiem));
                        }
                    }
                }
                Load_DanhSach_MayXnTheoMayTinh();
            }
        }
        private void XoaCauHinhMayXn()
        {
            if (gvMayXnKhaiBao.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa cấu hình máy xét nghiệm đang chọn?"))
                {
                    var obj = new DM_MAYTINH_MAYXETNGHIEM();
                    foreach (var item in gvMayXnKhaiBao.GetSelectedRows())
                    {
                        if (item > -1)
                        {
                            if (gvMayXnKhaiBao.GetRowCellValue(item, colMayXnKhaiBao_IdMay) != null)
                            {
                                obj.Makhuvuc = WorkingServices.ObjecToString(gvMayXnKhaiBao.GetRowCellValue(item, colMayXnKhaiBao_Makhuvuc));
                                obj.Tenmaytinh = WorkingServices.ObjecToString(gvMayXnKhaiBao.GetRowCellValue(item, colMayXnKhaiBao_TenMayTinh));
                                obj.Idmayxetnghiem = int.Parse(WorkingServices.ObjecToString(gvMayXnKhaiBao.GetRowCellValue(item, colMayXnKhaiBao_IdMay)));
                                _iAnalyzerConfig.Delete_dm_maytinh_mayxetnghiem(obj.Makhuvuc, obj.Tenmaytinh, obj.Idmayxetnghiem);
                            }
                        }
                    }
                    Load_DanhSach_MayXnTheoMayTinh();
                }
            }
        }
        private void gvDSMayTinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSach_MayXnTheoMayTinh();
        }

        private void gvDSMayTinh_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DanhSach_MayXnTheoMayTinh();
        }

        private void btnThemMayXn_Click(object sender, EventArgs e)
        {
            ThemCauHinhMayXn();
        }

        private void btnXoamayXetNghiem_Click(object sender, EventArgs e)
        {
            XoaCauHinhMayXn();
        }
    }
}
