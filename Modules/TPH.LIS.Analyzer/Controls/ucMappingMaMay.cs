using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Analyzer.Model;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Controls;
using TPH.LIS.Log.Services.WorkingLog;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucMappingMaMay : UserControl
    {
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public string[] arrAnalyzerAllow = new string[] { };
        public string[] arrPhanQuyenNhom = new string[0];
        public bool isAdmin = false;
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public ucMappingMaMay()
        {
            InitializeComponent();
        }
        public void LoadConfig()
        {
            if (!isCreatedGrid)
            {
                gvMaMayChiTiet.ColumnPanelRowHeight = 78;
                ControlExtension.CreateGridColumnWithObject(new H_BANGMAMAYXN(), gvMaMayChiTiet, "coldmmappingmamay", true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Maxn)
                    , ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Userd)
                    , ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Intime) });
                isCreatedGrid = true;
            }
            ucDanhSachMayXetNghiem1.LuoiCellFocusChanged -= UcDanhSachMayXetNghiem1_LuoiCellFocusChanged;
            ucDanhSachMayXetNghiem1.arrAnalyzerAllow = arrAnalyzerAllow;
            ucDanhSachMayXetNghiem1.isAdmin = isAdmin;
            ucDanhSachXetNghiem1.isAdmin = isAdmin;
            ucDanhSachXetNghiem1.arrPhanQuyenNhom = arrPhanQuyenNhom;
            ucDanhSachXetNghiem1.AutoExpandAll = true;
            ucDanhSachMayXetNghiem1.Load_MayXetNghiem(null);
            ucDanhSachMayXetNghiem1.LuoiCellFocusChanged += UcDanhSachMayXetNghiem1_LuoiCellFocusChanged;
            Load_DMMapping();
        }

        private void UcDanhSachMayXetNghiem1_LuoiCellFocusChanged(object sender, EventArgs e)
        {
            Load_DMMapping();
        }

        private void Load_DMMapping()
        {
            gcMaMayChiTiet.DataSource = null;
            ucDanhSachXetNghiem1.Load_DanhSach(new DataTable());
            if (!string.IsNullOrEmpty(ucDanhSachMayXetNghiem1.MayXnDangChon))
            {
                var data = _iAnalyzerConfig.Data_h_bangmamayxn(int.Parse(ucDanhSachMayXetNghiem1.MayXnDangChon), string.Empty);
                if (data != null)
                {
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
                gcMaMayChiTiet.DataSource = data;
                var dataXn = _systemConfigService.Data_dm_xetnghiem_NotInMappingMaMy(int.Parse(ucDanhSachMayXetNghiem1.MayXnDangChon));
                if (dataXn != null)
                {
                    var filter = (isAdmin ? string.Empty : string.Format("{0} in ('{1}')", ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Manhomcls), (arrPhanQuyenNhom == null ? "---NONE---" : string.Join("','", arrPhanQuyenNhom))));
                    if (!string.IsNullOrEmpty(filter))
                        dataXn = WorkingServices.SearchResult_OnDatatable(dataXn, filter);
                    ucDanhSachXetNghiem1.Load_DanhSach(dataXn);
                }
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachMayXetNghiem1.MayXnDangChon))
            {
                var idmay = int.Parse(ucDanhSachMayXetNghiem1.MayXnDangChon);
                if (!string.IsNullOrEmpty(ucDanhSachXetNghiem1.MaXnDangChon))
                {
                   var ok = _iAnalyzerConfig.Insert_h_bangmamayxn(new H_BANGMAMAYXN()
                    {
                        Maxn = ucDanhSachXetNghiem1.MaXnDangChon,
                        Idmay = idmay,
                        Userd = UserId
                    });
                    if (ok > -1)
                        Load_DMMapping();
                    else
                        CustomMessageBox.MSG_Information_OK("Xét nghiệm đã được khaa báo trước.");
                }
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (gvMaMayChiTiet.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa mapping xét nghiệm đang chọn?"))
                {
                    foreach (var item in gvMaMayChiTiet.GetSelectedRows())
                    {
                        if (gvMaMayChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Maxn)) != null)
                        {
                            var idMayXn = int.Parse(gvMaMayChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Idmay)).ToString());
                            var maXn = gvMaMayChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Maxn)).ToString();
                            var obj = _iAnalyzerConfig.Get_Info_h_bangmamayxn(idMayXn, maXn);
                            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                            {
                                Idhanhdong = (int)Log.LogActionId.Delete,
                                Madanhmuc = string.Format("IDMay_{0}_MaXn_{1}", idMayXn, maXn),
                                Nguoithuchien = UserId,
                                Noidung = string.Format("Xóa mapping: {0}", WorkingServices.GetDelete_Containt(obj)),
                                Idnhatky = Log.LogTableIds.H_bangmamayxn,
                                Pcthuchien = Environment.MachineName
                            });
                            _iAnalyzerConfig.Delete_h_bangmamayxn(idMayXn, maXn);
                        }
                    }
                    Load_DMMapping();
                }
            }
        }

        private void gvMaMayChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var idMay = int.Parse(gvMaMayChiTiet.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Idmay)).ToString());
            var maxn = gvMaMayChiTiet.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Maxn)).ToString();
            var obj = _iAnalyzerConfig.Get_Info_h_bangmamayxn(idMay, maxn);
            var objSource = obj.Copy();
            DataRow row = gvMaMayChiTiet.GetDataRow(e.RowHandle);
            obj.Intime = objSource.Intime;
            obj = (H_BANGMAMAYXN)WorkingServices.Get_InfoForObject(obj, row);
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("IdMay_{0}_MaXN_{1}", idMay.ToString(), maxn),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.H_bangmamayxn,
                Pcthuchien = Environment.MachineName
            });
            _iAnalyzerConfig.Update_h_bangmamayxn(obj);
        }

        private void btnCopyMapping_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachMayXetNghiem1.MayXnDangChon))
            {
                var f = new FrmChonDSMayXn();
                f.arrAnalyzerAllow = arrAnalyzerAllow;
                f.ShowDialog();
                if (f.lstMay.Count > 0)
                {
                    var lst = f.lstMay;
                    progressBar1.Maximum = lst.Count * gvMaMayChiTiet.RowCount + 3;
                    progressBar1.Value = 0;
                    progressBar1.Visible = true;
                    try
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Sao chép khai báo mapping từ máy: {0}{1}đến máy: {2} ", ucDanhSachMayXetNghiem1.MayXnDangChon, Environment.NewLine, string.Join(",", lst))))
                        {
                            foreach (var idTo in lst)
                            {
                                for (int i = 0; i < gvMaMayChiTiet.RowCount; i++)
                                {
                                    if (gvMaMayChiTiet.GetRowCellValue(i, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Maxn)) != null)
                                    {
                                        progressBar1.Value++;
                                        var idMayXn = int.Parse(gvMaMayChiTiet.GetRowCellValue(i, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Idmay)).ToString());
                                        var maXn = gvMaMayChiTiet.GetRowCellValue(i, ControlExtension.PropertyNameToLowerCase<H_BANGMAMAYXN>(x => x.Maxn)).ToString();
                                        var obj = _iAnalyzerConfig.Get_Info_h_bangmamayxn(idMayXn, maXn);
                                        obj.Userd = UserId;
                                        obj.Idmay = int.Parse(idTo);
                                        _iAnalyzerConfig.Insert_h_bangmamayxn(obj);
                                        _iAnalyzerConfig.Update_h_bangmamayxn(obj);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        progressBar1.Visible = false;
                        CustomMessageBox.MSG_Error_OK(ex.Message, ex);
                    }
                    progressBar1.Visible = false;
                }
            }
        }

        private void btnLoadDsanhSachMay_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }
}
