using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucLuoiKetQuaMay : UserControl
    {
        private IAnalyzerResultService _iAnalyzer = new AnalyzerResultService();
        private IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public ucLuoiKetQuaMay()
        {
            InitializeComponent();
        }
        public int IDMayXN = 0;
        public string TenMayXN = string.Empty;
        public string UserLogIn = string.Empty;
        public bool repeatBarcode = false;
        public int dayScan = 8;
        public DataTable TestCodeWithAnalyzer = new DataTable();
        private DataTable DataResult = new DataTable();
        int countLimit = 25;
        int counting = 0;

        public void Stop_Timer()
        {
            counting = 0;
            timerAutorefresh.Stop();
            timerAutorefresh.Enabled = false;
        }
        public void Start_Timer(int startAt = 0)
        {
            counting = startAt;
            timerAutorefresh.Enabled = true;
            timerAutorefresh.Start();
        }
        private void Load_DataConfig()
        {
            TestCodeWithAnalyzer = _iAnalyzerConfig.Data_h_bangmamayxn(IDMayXN, string.Empty);
            ResetShowInformation();
        }
        public void SetAnalyzerInfo(int idMayXN
             , string tenMayXN
             , string userLogin
             , bool barcodeLaplai
             , int soNgayScan)
        {
            IDMayXN = idMayXN;
            TenMayXN = tenMayXN;
            UserLogIn = userLogin;
            repeatBarcode = barcodeLaplai;
            dayScan = soNgayScan;
            lblMayXN.Text = string.Format("Máy XN: {0} - {1}", idMayXN, tenMayXN);
        }
        private void AddFirstDataColumns()
        {
            if (!DataResult.Columns.Contains("sid"))
                DataResult.Columns.Add("sid", typeof(string));
            if (!DataResult.Columns.Contains("seq"))
                DataResult.Columns.Add("seq", typeof(string));
            if (!DataResult.Columns.Contains("idlist"))
                DataResult.Columns.Add("idlist", typeof(string));
        }
        private void ResetShowInformation()
        {
            DataResult = new DataTable();
            AddFirstDataColumns();
            var currentColumnName = string.Empty;
            for (int i = 0; i < gvAnalyzerResult.Columns.Count; i++)
            {
                currentColumnName = gvAnalyzerResult.Columns[i].Name;
                if (currentColumnName.Equals(colSeq.Name) || currentColumnName.Equals(colSID.Name)
                    || currentColumnName.Equals(colIDList.Name) || currentColumnName.Equals(colnum.Name)
                    )
                {
                    continue;
                }
                else
                {
                    gvAnalyzerResult.Columns.RemoveAt(i);
                    i--;
                }
               
            }
        }
        public void ReadAndSetDataToGrid()
        {
            try
            {
                counting = 0;

                Load_DataConfig();
                var dataFromAnalyzer = _iAnalyzer.Data_KetQuaMayChoGhepCode(IDMayXN, CommonConstant.TrangThaiKqMayChoGhepCode);
                CreateColumns();
                var dataTogrid = DataResult.Clone();
                if (dataFromAnalyzer.Rows.Count > 0)
                {
                    var distincSeq = dataFromAnalyzer.DefaultView.ToTable(true, new string[] { "SEQ" });
                    var seq = string.Empty;

                    foreach (DataRow drS in distincSeq.Rows)
                    {
                        seq = drS["SEQ"].ToString();
                        var dataResultOfSEQ = WorkingServices.SearchResult_OnDatatable_NoneSort(dataFromAnalyzer, string.Format("SEQ = '{0}'", seq));
                        dataResultOfSEQ.DefaultView.Sort = "MaXN, thoigianluu desc";
                        dataResultOfSEQ = dataResultOfSEQ.DefaultView.ToTable();
                        AddResultToData(dataResultOfSEQ, seq, ref dataTogrid);
                    }
                }
                var bs = new BindingSource();
                bs.DataSource = dataTogrid;
                gcAnalyzerResult.DataSource = bs;
                bvAnalyzerResult.BindingSource = bs;

                counting = 0;
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, string.Format("SetDataToGrid() - IDMay: {0}", IDMayXN), UserLogIn);
            }
        }
        private void AddResultToData(DataTable DataResult, string Seq, ref DataTable dataTogrid)
        {
            var idlist = string.Empty;
            var testcode = string.Empty;
            DataRow drR = dataTogrid.NewRow();
            drR["seq"] = Seq;
            List<string> lstTestcodeadded = new List<string>();
            for (int i = 0; i < DataResult.Rows.Count; i++)
            {
                var drD = DataResult.Rows[i];
                testcode = drD["MaMay"].ToString().Trim();
                if (!lstTestcodeadded.Contains(testcode))
                {
                    drR[testcode] = drD["KetQua"].ToString().Trim();
                    idlist += string.IsNullOrEmpty(idlist) ? "" : ",";
                    idlist += drD["ID"].ToString().Trim();
                    DataResult.Rows.RemoveAt(i);
                    i--;
                    DataResult.AcceptChanges();
                    lstTestcodeadded.Add(testcode);
                }
            }
            drR["idlist"] = idlist;
            dataTogrid.Rows.Add(drR);
            if (DataResult.Rows.Count>0)
            {
                AddResultToData(DataResult, Seq, ref dataTogrid);
            }
        }
        private void CreateColumns()
        {
            var testcode = string.Empty;
            var testwithId = string.Empty;
            foreach (DataRow r in TestCodeWithAnalyzer.Rows)
            {
                testcode = r["MaMay"].ToString().Trim();
                if (!DataResult.Columns.Contains(testcode))
                {
                    DataResult.Columns.Add(testcode, typeof(string));
                    DataResult.Columns.Add(testwithId, typeof(string));
                    InsertNewColToGrid(gvAnalyzerResult, testcode, testcode, 80, null, null, FormatType.None);
                }
            }
            colSID.VisibleIndex = 0;
            colSeq.VisibleIndex = 1;
        }
        private void InsertNewColToGrid(GridView gridView, string fieldName, string title, int width = 70, int? minWidth = null
            , int? maxWidth = null, FormatType? formatType = null, bool visible = true, string formatString = null
            , bool groupSummary = false)
        {
            int visbileIndex = gridView.Columns.Count;
            GridColumn col = gridView.Columns.AddVisible(fieldName, title);
            col.Visible = visible;
            col.VisibleIndex = visbileIndex + 1;
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
            col.OptionsColumn.AllowEdit = true;
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var totalRows = gvAnalyzerResult.RowCount;
                if (totalRows > 0)
                {
                    var updateSeq = string.Empty;

                    for (var i = 0; i < totalRows; i++)
                    {
                        if (gvAnalyzerResult.GetRowCellValue(i, colSID) != null)
                        {
                            var sid = gvAnalyzerResult.GetRowCellValue(i, colSID).ToString().Trim().Replace("\r", "").Replace("\n", "");
                            if (string.IsNullOrEmpty(sid)) continue;


                            var seq = gvAnalyzerResult.GetRowCellValue(i, colSeq).ToString();
                            var maTiepNhan = _iAnalyzer.Lay_MatiepNhan(repeatBarcode, dayScan, sid);
                            var idList = gvAnalyzerResult.GetRowCellValue(i, colIDList).ToString();

                            _iAnalyzer.CapNhat_MaTiepNhan(seq, sid, maTiepNhan, idList, CommonConstant.TrangThaiKqMayTuMayKhac);
                        }
                    }
                    ReadAndSetDataToGrid();
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, string.Format("btnSave_Click() - IDMay: {0}", IDMayXN), UserLogIn);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy các kết quả trên lưới?"))
            {
                try
                {
                    var totalRows = gvAnalyzerResult.RowCount;
                    if (totalRows > 0)
                    {
                        var updateSeq = string.Empty;

                        for (var i = 0; i < totalRows; i++)
                        {
                            var seq = gvAnalyzerResult.GetRowCellValue(i, colSeq).ToString();
                            var idList = gvAnalyzerResult.GetRowCellValue(i, colIDList).ToString();
                            _iAnalyzer.CapNhat_MaTiepNhan(seq, seq, string.Empty, idList, CommonConstant.TrangThaiKqMayTuMayKhac);
                        }
                        ReadAndSetDataToGrid();
                    }
                }
                catch (Exception ex)
                {
                    ErrorService.GetFrameworkErrorMessage(ex, string.Format("btnCancel_Click() - IDMay: {0}", IDMayXN), UserLogIn);
                }
            }
        }

        private void btnLoadDanhSach_Click(object sender, EventArgs e)
        {
            ReadAndSetDataToGrid();
        }

        private void btnXoaDongDangChon_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy kết quả đang chọn trên lưới?"))
            {
                try
                {
                    var totalRows = gvAnalyzerResult.SelectedRowsCount;
                    if (totalRows > 0)
                    {
                        var updateSeq = string.Empty;
                        var seq = gvAnalyzerResult.GetFocusedRowCellValue(colSeq).ToString();
                        var idList = gvAnalyzerResult.GetFocusedRowCellValue(colIDList).ToString();
                        _iAnalyzer.CapNhat_MaTiepNhan(seq, seq, string.Empty, idList, CommonConstant.TrangThaiKqMayTuMayKhac);
                        ReadAndSetDataToGrid();
                    }
                }
                catch (Exception ex)
                {
                    ErrorService.GetFrameworkErrorMessage(ex, string.Format("btnXoaDongDangChon_Click() - IDMay: {0}", IDMayXN), UserLogIn);
                }
            }
        }

        private void timerAutorefresh_Tick(object sender, EventArgs e)
        {
            lblAutorefresh.Text = (countLimit - counting).ToString();
           
            if (counting == countLimit)
            {
                timerAutorefresh.Stop();
                ReadAndSetDataToGrid();
                counting = 0;
                timerAutorefresh.Start();
            }
            else
            {
                counting++;
            }
        }

        private void gvAnalyzerResult_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            counting = 0;
        }

        private void gvAnalyzerResult_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            counting = 0;
        }

        private void gvAnalyzerResult_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            counting = 0;
        }
    }
}
