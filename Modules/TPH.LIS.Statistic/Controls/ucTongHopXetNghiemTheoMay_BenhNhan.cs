using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Extensions;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopXetNghiemTheoMay_BenhNhan : UserControl
    {
        public ucTongHopXetNghiemTheoMay_BenhNhan()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiem();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcCTXN, string.Format("ChiTiet_MayXetnghiem_BenhNhan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }
        private void ThongKeChiTietXetNghiem()
        {
            var c = 4;
            while (gvCTXN.Columns.Count > c)
            {
                gvCTXN.Columns.RemoveAt(c);
            }
            gcCTXN.DataSource = null;

            var condit = getCondit();
            condit.SumColumns = new List<string>() { "SL" };
            var dtTemp = _iStatistic.ThongKeXetNghiemMay_TheoKetQuaXN(condit);

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp, new[] { "MaXN", "TenXN", "MaNhomCLS", "TenNhomCLS"});

                var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                                .Select(row => new
                                {
                                    IdMayXetNghiem = row.Field<string>("IDMayXetNghiem"),
                                    TenMayXN = row.Field<string>("Tenmay") 
                                }).Distinct().ToList();

                foreach (var item in dmxn)
                {
                    var IdMayXN = string.Format("IDMayXN_{0}", item.IdMayXetNghiem.Trim()).ToUpper();
                    InsertNewColToGrid(gvCTXN, IdMayXN, item.TenMayXN, 100, null, null, FormatType.Numeric, "{0:N0}", true);
                    if (dtResult.Columns.Contains(IdMayXN))
                        continue;
                    dtResult.Columns.Add(IdMayXN, typeof(double));
                }

            //    InsertNewColToGrid(gvCTXN, "TenNhanVien", "Bác sĩ chỉ định", 250);

                string maXnMain = string.Empty;
                string maXNDetail = string.Empty;
                string tenXn = string.Empty;

                foreach (DataRow dr in dtResult.Rows)
                {
                    tenXn = string.Empty;
                    maXnMain = dr["MaXN"].ToString().Trim();

                    DataTable dtTempResultDetail = dtTemp.Clone();
                    dtTemp.Select("MaXN = '" + maXnMain + "'").CopyToDataTable(dtTempResultDetail, LoadOption.OverwriteChanges);

                    for (int i = 0; i < dtTempResultDetail.Rows.Count; i++)
                    {
                        var IDmayXN = string.Format("IDMayXN_{0}", dtTempResultDetail.Rows[i]["IDMayXetNghiem"].ToString()).Trim().ToUpper();
                        dr[IDmayXN] = double.Parse(dtTempResultDetail.Rows[i]["SL"].ToString());
                    }

                    dtResult.AcceptChanges();
                }
                gcCTXN.DataSource = dtResult;
                gvCTXN.ExpandAllGroups();
            }
        }
      
        private void InsertNewColToGrid(GridView gridView, string fieldName, string title,
    int width = 70, int? minWidth = null, int? maxWidth = null, FormatType? formatType = null, string formatString = null, bool groupSummary = false)
        {
            GridColumn col = gridView.Columns.AddVisible(fieldName, title);
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
                col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, formatString)});
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
            col.ColumnEdit = new RepositoryItemTextEdit();
        }

        private void ucTongHopXetNghiemTheoMay_BenhNhan_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
