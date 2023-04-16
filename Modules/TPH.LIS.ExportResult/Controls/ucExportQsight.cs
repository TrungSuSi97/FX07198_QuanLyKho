using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;
using TPH.LIS.ExportResult.Service;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucExportQsight : UserControl
    {
        public ucExportQsight()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;
  
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiemTheoNgay();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (gvXetNghiemExport.RowCount > 0)
            {
               Excel.ExportToExcel.Export(gvXetNghiemExport, string.Format("Export_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")), null, null, null);
            }
        }
        private void ThongKeChiTietXetNghiemTheoNgay()
        {

            gcXetNghiemExport.DataSource = null;

            var condit = getCondit();
            if (condit.MayXetNghiem != null)
            {
                if (condit.MayXetNghiem.Count == 0 && condit.NhomXetNghiem.Count == 0)
                    CustomMessageBox.MSG_Information_OK("Hãy chọn máy hoặc nhóm xét nghiệm.");
                else
                {
                    CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
                    var dtTemp = _iexport.DanhSachExport_SangLoc_SoSinh(condit);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        CustomMessageBox.ShowAlert("Đang xử lý số liệu.....");
                        DataTable dtPatient = WorkingServices.DataTable_DistinctValue(dtTemp,
                            new string[] { "MaTiepNhan" });
                        DataTable dtTestWithSepcialCode = WorkingServices.DataTable_DistinctValue(dtTemp,
                            new string[] { "MaXN", "KyHieu" });

                        var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                                        .Select(row => new
                                        {
                                            MaXN = row.Field<string>("MaXN"),
                                            KyHieu = row.Field<string>("KyHieu")
                                        }).Distinct().ToList();
                        DataTable dataResult = dtTemp.Clone();
                        CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Thêm các cột cho thống kê.");
                        foreach (var item in dmxn)
                        {
                            dataResult.Columns.Add(item.MaXN.ToLower(), typeof(string));
                            var ColKl = string.Format("kl_{0}", item.MaXN).ToLower(); ;
                            dataResult.Columns.Add(ColKl, typeof(string));
                        }
                        string finishAddColumns = string.Empty;
                        var ngayTiepNhan = string.Empty;
                        string tenXn = string.Empty;
                        CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Tổng hợp kết quả xét nghiệm.");
                        foreach (DataRow dr in dtPatient.Rows)
                        {
                            var dtResulbyPatient = WorkingServices.SearchResult_OnDatatable(dtTemp, string.Format("MaTiepNhan = '{0}'", dr["MaTiepNhan"].ToString()));
                            if (dtResulbyPatient.Rows.Count > 0)
                            {
                                var drAdd = dataResult.NewRow();
                                foreach (DataColumn dtcP in dataResult.Columns)
                                {
                                    if (dtResulbyPatient.Columns.Contains(dtcP.ColumnName))
                                    {
                                        //if (dtcP.ColumnName.Equals("diachi", StringComparison.OrdinalIgnoreCase))
                                        //{
                                        //    var strArr = dtResulbyPatient.Rows[0][dtcP.ColumnName].ToString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                                        //    drAdd[dtcP.ColumnName] = (strArr.Length > 0 ? strArr[0] : string.Empty);
                                        //}
                                        //else
                                            drAdd[dtcP.ColumnName] = dtResulbyPatient.Rows[0][dtcP.ColumnName];
                                    }
                                }
                                var kqTang = string.Empty;
                                var kqGiam = string.Empty;
                                foreach (DataRow drK in dtResulbyPatient.Rows)
                                {
                                    var colName = drK["MaXN"].ToString().ToLower();
                                    if (dataResult.Columns.Contains(colName))
                                    {
                                        drAdd[colName] = drK["KetQua"].ToString();
                                        drAdd[string.Format("kl_{0}", colName)] = drK["GhiChu"].ToString();
                                        if (!string.IsNullOrEmpty(drK["Tang"].ToString()))
                                            kqTang += (string.IsNullOrEmpty(kqTang) ? "" : ",") + drK["Tang"].ToString();
                                        if (!string.IsNullOrEmpty(drK["Giam"].ToString()))
                                            kqGiam += (string.IsNullOrEmpty(kqGiam) ? "" : ",") + drK["Giam"].ToString();
                                    }
                                }
                                drAdd["Tang"] = (string.IsNullOrEmpty(kqTang) ? "" : "Tăng :" + kqTang);
                                drAdd["Giam"] = (string.IsNullOrEmpty(kqGiam) ? "" : "Giảm :" + kqGiam);
                                dataResult.Rows.Add(drAdd);
                            }
                        }
                        dataResult = WorkingServices.ConvertColumnNameToLower_Upper(dataResult, true);
                        gcXetNghiemExport.DataSource = dataResult;
                        gvXetNghiemExport.ExpandAllGroups();
                    }
                    CustomMessageBox.CloseAlert();
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm.");
            }
        }
        public void AddColumnResult()
        {
            var lstCol = new List<string>() { "SLSS_ALA^^Ala","SLSS_ARG^^Arg","SLSS_CIT^^Cit","SLSS_GLN^^Gln","SLSS_GLU^^Glu","SLSS_GLY^^Gly","SLSS_LEU^^Leu"
                ,"SLSS_MET^^Met","SLSS_ORN^^Orn","SLSS_PHE^^Phe","SLSS_PRO^^Pro","SLSS_TYR^^Tyr","SLSS_VAL^^Val","SLSS_C0^^C0","SLSS_C2^^C2","SLSS_C3^^C3","SLSS_C3C4^^C3DC\\C4OH","SLSS_C4^^C4","SLSS_C4C5^^C4DC/C5OH","SLSS_C5^^C5"
                ,"SLSS_C51^^C5:1","SLSS_C5C6^^C5DC/C6OH","SLSS_C6^^C6","SLSS_C6DC^^C6DC","SLSS_C8^^C8","SLSS_C81^^C8:1","SLSS_C10^^C10","SLSS_C101^^C10:1","SLSS_C102^^C10:2","SLSS_C12^^C12"
                ,"SLSS_C121^^C12:1","SLSS_C14^^C14","SLSS_C141^^C14:1","SLSS_C142^^C14:2","SLSS_C14OH^^C14:OH","SLSS_C16^^C16","SLSS_C161^^C16:1","SLSS_C16OH^^C16OH","SLSS_C161OH^^C16:1OH"
                ,"SLSS_C18^^C18","SLSS_C181^^C18:1","SLSS_C182^^C18:2","SLSS_C18OH^^C18OH","SLSS_C181OH^^C18:1OH","SLSS_C182OH^^C18:2OH","SLSS_C20^^C20","SLSS_C22^^C22","SLSS_C24^^C24"
                ,"SLSS_C26^^C26","SLSS_ADO^^ADO","SLSS_D-ADO^^D-ADO","SLSS_C200-LPC^^C20:0-LPC","SLSS_C220-LPC^^C24:0-LPC","SLSS_C240-LPC^^C24:0-LPC","SLSS_C260-LPC^^C26:0-LPC","SLSS_LVPT^^(Leu+Val)/(Phe+Tyr)"
                ,"SLSS_Cit_Arg^^Cit/Arg","SLSS_Cit_Phe^^Cit/Phe","SLSS_C0C18_Cit^^(C0+C2+C3+C16+C18:1+C18)/Cit","SLSS_C141C121^^C14:1/C12:1","SLSS_LeuPhe^^Leu/Phe","SLSS_MetLeu^^Met/Leu"
                ,"SLSS_MetPhe^^Met/Phe","SLSS_PheTyr^^Phe/Tyr","SLSS_TyrLeu^^Tyr/Leu","SLSS_TyrMet^^Tyr/Met","SLSS_ValPhe^^Val/Phe","SLSS_C3Met^^C3/Met","SLSS_C3C2^^C3/C2","SLSS_C3C16^^C3/C16"
                ,"SLSS_C3C4C8^^C3DC/C4OH/C8","SLSS_C0C16C18^^C0/(C16+C18)","SLSS_C4C5C8^^C4DC/C5OH/C8","SLSS_C8C10^^C8/C10","SLSS_C8C2^^C8/C2","SLSS_C5C6C8^^C5DC/C6OH/C8","SLSS_C16C181C2^^(C16+C18:1)/C2"
                ,"NGAYIN^^NGAY XN","NHANXETSANGLOC^^NHAN XET","GIAM^^GIAM", "TANG^^TANG", "KETLUANSANGLOC^^KET LUAN","DENGHISANGLOC^^DE NGHI","NGUOIXACNHAN^^NGUOI XN","SEQ^^BARCODE TPH","TraKQSLTaiNha^^Trả KQ SLSS tại nhà^^150"};
            int startvisibleindex = 28;
            foreach (var item in lstCol)
            {
                var col = item.Split(new string[] { "^^" }, StringSplitOptions.RemoveEmptyEntries);
                startvisibleindex++;
                InsertNewColToGrid(gvXetNghiemExport, col[0], col[1], (col.Length > 2 ? int.Parse(col[2]) : 100), visibleindex: startvisibleindex);
            }
            for (int i = 0; i < gvXetNghiemExport.Columns.Count; i++)
            {
                gvXetNghiemExport.Columns[i].FieldName = gvXetNghiemExport.Columns[i].FieldName.ToLower();
            }
        }
        private void InsertNewColToGrid(GridView gridView, string fieldName, string title, int width = 70
            , int? minWidth = null, int? maxWidth = null, FormatType? formatType = null, string formatString = null
            , bool groupSummary = false, int visibleindex = -1, bool useColumnEdit = false)
        {
            GridColumn col = new GridColumn();
            col.FieldName = fieldName;
            col.Caption = title;
            col.UnboundType = DevExpress.Data.UnboundColumnType.Bound;
            if (visibleindex > -1)
                col.VisibleIndex = visibleindex;
            if (formatType != null)
            {
                col.DisplayFormat.FormatType = formatType.Value;
                col.GroupFormat.FormatType = formatType.Value;
            }
            if (!string.IsNullOrEmpty(formatString))
            {
                col.DisplayFormat.FormatString = formatString;
                col.GroupFormat.FormatString = formatString;
            }
            if (groupSummary)
            {
                col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] 
                {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, formatString)
                });
            }
            col.OptionsColumn.AllowEdit = false;
            col.OptionsColumn.ReadOnly = true;
            col.Width = width;
            if (minWidth != null)
            {
                col.MinWidth = 10;
            }
            if (maxWidth != null)
            {
                col.MaxWidth = 500;
            }
            if (useColumnEdit)
                col.ColumnEdit = new RepositoryItemTextEdit();
            gridView.Columns.Add(col);
        }

        private void ucExportQsight_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
