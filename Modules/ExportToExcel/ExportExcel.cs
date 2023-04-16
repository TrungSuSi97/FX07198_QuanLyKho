using DevExpress.Export;
using DevExpress.Export.Xl;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using COMExcel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace TPH.Excel
{
    public class ExportToExcel
    {
        private static bool NotInRangeFormatColumn(int[] arrFrom, int[] arrTo, int removeColumnCount, int checkValue)
        {
            for (int i = 0; i < arrFrom.Length; i++)
            {
                if (checkValue >= (arrFrom[i] - removeColumnCount) && checkValue <= (arrTo[i] - removeColumnCount))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Hàm xuất dữ liệu trên lưới ra file Excel
        /// </summary>
        /// <param name="dtgView">Truyền vào đối tượng DataDridView</param>
        private static void Export_DataTable(DataTable tb, bool isLandscape, int rowStart = 1, int colStart = 1 )
        {
            FrmMessageBox_Process frm = new FrmMessageBox_Process();
            try
            {
                frm.lblTitle.Text = "XUẤT EXCEL";
                frm.Msg = "Đang xuất excel.\nVui lòng chờ!";
                frm.lblMsg.Visible = true;
                frm.Max = tb.Rows.Count + tb.Columns.Count + tb.Columns.Count * tb.Rows.Count;
                frm.proBar.Visible = true;
                frm.TopMost = true;
                frm.proBar.Step = 1;

                frm.Show();

                
                int _totalRow = tb.Rows.Count;
                int _totalColumn = tb.Columns.Count;
                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // excel.Application.Workbooks.Add(true);
                int rowIndex = rowStart - 1;
                int colIndex = colStart - 1;
                string _step = string.Empty;
                string _Value = string.Empty;
                // write
                foreach (DataColumn col in tb.Columns)
                {
                    _step = string.Format(" Đang xuất tiêu đề \n Cột - {0} / {1}", colIndex, _totalColumn);
                    frm.Perform_Percent(_step);
                    colIndex++;

                    xlWorkSheet.Cells[1, colIndex] = string.IsNullOrWhiteSpace(col.Caption) ? col.ColumnName : col.Caption;

                    FormatSheet(xlWorkSheet, false, 3, 2, 11, "Arial", true, false,
                        Color.Black, excel.Cells[1, colIndex], excel.Cells[1, colIndex], false, 250);
                }

                rowIndex ++;
                _step = string.Empty;
                foreach (DataRow row in tb.Rows)
                {
                    _step = string.Format(" Dòng - {0} / {1}", +rowIndex, _totalRow);
                    frm.Perform_Percent(_step);
                    rowIndex++;
                    colIndex = colStart - 1;
                    foreach (DataColumn col in tb.Columns)
                    {
                        colIndex++;
                        if (row[col.ColumnName] is DateTime)
                        {
                            xlWorkSheet.Cells[rowIndex, colIndex] = Convert.ToDateTime(row[col.ColumnName].ToString());
                        }
                        else
                        {
                            _Value = row[col.ColumnName].ToString().TrimEnd();
                            if (_Value.Length > 0)
                            {
                                if (_Value.Substring(0, 1) == "=")
                                    _Value = "'" + _Value;
                            }
                            _Value = _Value.Replace("\r\n", "\n");
                            xlWorkSheet.Cells[rowIndex, colIndex] = _Value;

                        }
                    }
                }
                xlWorkSheet.Columns.WrapText = true;
                xlWorkSheet.Columns.VerticalAlignment = 2;
                xlWorkSheet.Rows.AutoFit();
                xlWorkSheet.Columns.AutoFit();

                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[tb.Rows.Count + 1, tb.Columns.Count]].Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
                if (tb.Columns.Count > 15 || isLandscape)
                {
                    try
                    {
                        xlWorkSheet.PageSetup.Orientation = COMExcel.XlPageOrientation.xlLandscape;
                        xlWorkSheet.PageSetup.TopMargin = 10;
                        xlWorkSheet.PageSetup.BottomMargin = 10;
                        xlWorkSheet.PageSetup.LeftMargin = 25;
                        xlWorkSheet.PageSetup.RightMargin = 25;

                        xlWorkSheet.PageSetup.Zoom = false;
                        xlWorkSheet.PageSetup.FitToPagesWide = 1;
                        xlWorkSheet.PageSetup.FitToPagesTall = false;
                    }
                    catch (Exception ex)
                    {
                        RecordError("Export_Excel_Error", ex.Message);
                    }
                }
                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                frm.Close();
            }
            catch (Exception ex)
            {
                Process[] proc = Process.GetProcessesByName("Excel");
                proc[0].Kill();
                RecordError("Export_Excel_Error", ex.Message);
                frm._isErr(string.Format("Có lỗi xảy ra trong quá trình xuất !\n{0}", ex.Message));
            }
        }
        /// <summary>
        /// Hàm xuất dữ liệu trên lưới ra file Excel
        /// </summary>
        /// <param name="dtgView">Truyền vào đối tượng DataDridView</param>
        public static void Export_DataTable(List<DataTable> LstTb, List<string> dataTitle, string reportTitle
            , List<string> lstSubTitle, List<string> HeaderLeft, List<string> HeaderRight, List<string> FooterLeft, List<string> FooterRight
            ,  int rowStart = 1, int colStart = 1)
        {
            FrmMessageBox_Process frm = new FrmMessageBox_Process();
            try
            {
                frm.lblTitle.Text = "XUẤT EXCEL";
                frm.Msg = "Đang xuất excel.\nVui lòng chờ!";
                frm.lblMsg.Visible = true;
           
                frm.proBar.Visible = true;
                frm.TopMost = true;
                frm.Show();

                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

              
                // excel.Application.Workbooks.Add(true);
                int rowIndex = rowStart - 1;
                int colIndex = colStart - 1;
                string _step = string.Empty;
                string _Value = string.Empty;
                int listCount = -1;
                int lstStartRow = -1;
                int maxColCount = 0;
                int countHeader = 0;
                int countSubtitle = 0;
                if (HeaderLeft != null)
                {
                    countHeader = HeaderLeft.Count;
                }
                if (HeaderRight != null)
                {
                    if (HeaderRight.Count > countHeader)
                        countHeader = HeaderRight.Count;
                }
                rowIndex = countHeader + 1;
                if (!string.IsNullOrEmpty(reportTitle))
                {
                    rowIndex++;
                    xlWorkSheet.Cells[rowIndex, colStart] = reportTitle;
                    rowIndex++;
                }
                if (lstSubTitle != null)
                {
                    countSubtitle = lstSubTitle.Count;
                }
                rowIndex += countSubtitle;
                foreach (DataTable tb in LstTb)
                {
                    if (tb == null) continue;

                    colIndex = colStart - 1;
                    rowIndex++;
                    listCount++;
                    if (dataTitle != null)
                    {
                        if (dataTitle.Count >= listCount)
                        {
                            var title = dataTitle[listCount];
                            if (!string.IsNullOrEmpty(title))
                            {
                                colIndex++;
                                xlWorkSheet.Cells[rowIndex, colIndex] = title;

                                FormatSheet(xlWorkSheet, true, 2, 1, 11, "Arial", true, false,
                                    Color.Black, excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex + 3], false);
                                colIndex = colStart - 1;
                            }
                            rowIndex++;
                        }
                    }
                    lstStartRow = rowIndex;
                    int _totalRow = tb.Rows.Count;
                    int _totalColumn = tb.Columns.Count;
                    frm.Max = tb.Rows.Count + tb.Columns.Count + tb.Columns.Count * tb.Rows.Count;
                    frm.proBar.Step = 1;
                    // write
                    foreach (DataColumn col in tb.Columns)
                    {
                        _step = string.Format(" Đang xuất tiêu đề \n Cột - {0} / {1}", colIndex, _totalColumn);
                        frm.Perform_Percent(_step);
                        colIndex++;

                        xlWorkSheet.Cells[rowIndex, colIndex] = string.IsNullOrWhiteSpace(col.Caption) ? col.ColumnName : col.Caption;

                        FormatSheet(xlWorkSheet, false, 3, 2, 11, "Arial", true, false,
                            Color.Black, excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, colIndex], false, 250);
                    }


                    _step = string.Empty;
                    foreach (DataRow row in tb.Rows)
                    {
                        _step = string.Format(" Dòng - {0} / {1}", +rowIndex, _totalRow);
                        frm.Perform_Percent(_step);
                        rowIndex++;
                        colIndex = colStart - 1;
                        foreach (DataColumn col in tb.Columns)
                        {
                            colIndex++;
                            if (row[col.ColumnName] is DateTime)
                            {
                                xlWorkSheet.Cells[rowIndex, colIndex] = Convert.ToDateTime(row[col.ColumnName].ToString());
                            }
                            else
                            {
                                _Value = row[col.ColumnName].ToString().TrimEnd();
                                if (_Value.Length > 0)
                                {
                                    if (_Value.Substring(0, 1) == "=")
                                        _Value = "'" + _Value;
                                }
                                _Value = _Value.Replace("\r\n", "\n");
                                xlWorkSheet.Cells[rowIndex, colIndex] = _Value;

                            }
                        }
                    }
                    if (colIndex > maxColCount)
                        maxColCount = colIndex;
                    xlWorkSheet.Range[xlWorkSheet.Cells[lstStartRow, colStart], xlWorkSheet.Cells[(tb.Rows.Count + lstStartRow), (tb.Columns.Count + colStart -1)]].Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
                }

                var currentEndRow = rowIndex;
                if (maxColCount == 0)
                    maxColCount = 10;
                var middleCol =  colStart + (int)((maxColCount - colStart) / 2);
                if (FooterLeft != null)
                {
                    rowIndex++;
                    colIndex = colStart;
                    foreach (var item in FooterLeft)
                    {
                        rowIndex++;
                        xlWorkSheet.Cells[rowIndex, colIndex] = item;
                        FormatSheet(xlWorkSheet, true, 2, 2, 11, "Arial", false, false, Color.Black, excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, (FooterRight != null ? middleCol : maxColCount)], false);
                    }
                }
                if (FooterRight != null)
                {
                    rowIndex = currentEndRow + 1;
                    colIndex = middleCol + 1;
                    foreach (var item in FooterRight)
                    {
                        rowIndex++;
                        xlWorkSheet.Cells[rowIndex, colIndex] = item;
                        FormatSheet(xlWorkSheet, true, 4, 2, 11, "Arial", false, false, Color.Black, excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, maxColCount], false);
                    }
                }
                if (HeaderLeft != null)
                {
                    var row = rowStart - 1;
                    var col = colStart;
                    foreach (var item in HeaderLeft)
                    {
                        row++;
                        xlWorkSheet.Cells[row, col] = item;
                        FormatSheet(xlWorkSheet, true, 3, 2, 11, "Arial", false, false, Color.Black, excel.Cells[row, col], excel.Cells[row, (HeaderRight != null ? middleCol : maxColCount)], false);
                    }
                }
                if (HeaderRight != null)
                {
                    var row = rowStart - 1;
                    var col = middleCol + 1;
                    foreach (var item in HeaderRight)
                    {
                        row++;
                        xlWorkSheet.Cells[row, col] = item;
                        FormatSheet(xlWorkSheet, true, 3, 2, 11, "Arial", false, false, Color.Black, excel.Cells[row, col], excel.Cells[row, maxColCount], false);
                    }
                }
                if (!string.IsNullOrEmpty(reportTitle))
                {
                    FormatSheet(xlWorkSheet, true, 3, 2, 16, "Arial", true, false, Color.Black, excel.Cells[countHeader + 2, colStart], excel.Cells[countHeader + 2, maxColCount], false);
                }
                if (lstSubTitle != null)
                {
                    rowIndex = countHeader + (string.IsNullOrEmpty(reportTitle) ? 0 : 3);
                    colIndex = colStart;
                    foreach (var item in lstSubTitle)
                    {
                        rowIndex++;
                        xlWorkSheet.Cells[rowIndex, colIndex] = item;
                        FormatSheet(xlWorkSheet, true, 3, 2, 11, "Arial", false, false, Color.Black, excel.Cells[rowIndex, colIndex], excel.Cells[rowIndex, maxColCount], false);
                    }
                    rowIndex++;
                }

                xlWorkSheet.Columns.WrapText = true;
                xlWorkSheet.Columns.VerticalAlignment = 2;
                xlWorkSheet.Rows.AutoFit();
                xlWorkSheet.Columns.AutoFit();


                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                frm.Close();
            }
            catch (Exception ex)
            {
                Process[] proc = Process.GetProcessesByName("Excel");
                proc[0].Kill();
                RecordError("Export_Excel_Error", ex.Message);
                frm._isErr(string.Format("Có lỗi xảy ra trong quá trình xuất !\n{0}", ex.Message));
            }
        }
        private static void Export_DataGrid(DataGridView dtgView, bool isLandscape, bool autoFit = true)
        {
            FrmMessageBox_Process frm = new FrmMessageBox_Process();
            try
            {
                string _step = string.Empty;
                string _Value = string.Empty;
                frm.lblTitle.Text = "XUẤT EXCEL";
                frm.Msg = "Đang xuất excel.\n Vui lòng chờ!";
                frm.lblMsg.Visible = true;
                frm.Max = dtgView.Rows.Count;
                frm.proBar.Visible = true;
                frm.TopMost = true;
                frm.proBar.Step = 1;

                frm.Show();

                int row = 0;
                int col = 0;
                int _totalRow = dtgView.RowCount;
                int _totalColumn = dtgView.Columns.Count;
                int _col_invisible = 0;
                bool _have_iscate = false;
                int _indexcate = 0;
                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.PageSetup.PaperSize = COMExcel.XlPaperSize.xlPaperA4;
                //dtgView.AllowUserToAddRows = false;
                foreach (DataGridViewColumn dgc in dtgView.Columns)
                {
                    string colname = (dgc.HeaderText == null || string.IsNullOrEmpty(dgc.HeaderText) ? "" : dgc.HeaderText.Trim());
                    if (dgc.Visible)
                    {
                        _step = string.Format(" Đang xuất tiêu đề " + "\n Cột - {0} / {1}", col, _totalColumn);
                        frm.Perform_Percent(_step);
                        col++;

                        var startCell = excel.Cells[1, col];
                        var endCell = excel.Cells[1, col];
                        xlWorkSheet.Cells[1, col] = colname;
                        FormatSheet(xlWorkSheet,
                            false, 3, 2, 11, "Arial", true, false,
                            Color.Black, startCell,
                            endCell, false, 250);
                    }
                    else
                    {
                        if (dgc.DataPropertyName.ToLower().TrimEnd().TrimStart().Equals("iscate", StringComparison.OrdinalIgnoreCase) ||
                            colname.TrimEnd().ToLower().TrimStart().Equals("iscate", StringComparison.OrdinalIgnoreCase))
                        {
                            _have_iscate = true;
                            _indexcate = dgc.Index;
                        }
                        _col_invisible++;
                    }
                }

                row = 1;
                _step = string.Empty;
                for (int rowIndex = 0; rowIndex < dtgView.Rows.Count; rowIndex++)
                {
                    _step = string.Format(" Dòng - {0} / {1}", rowIndex, _totalRow);
                    frm.Perform_Percent(_step);
                    row++;
                    col = 0;
                    for (int colIndex = 0; colIndex < dtgView.Columns.Count; colIndex++)
                    {
                        if (dtgView.Columns[colIndex].Visible == true)
                        {
                            col++;

                            if (dtgView[colIndex, rowIndex].Value is DateTime)
                            {
                                xlWorkSheet.Cells[row, col] = Convert.ToDateTime(dtgView[colIndex, rowIndex].Value.ToString());
                            }
                            else
                            {
                                _Value = dtgView[colIndex, rowIndex].Value == null ?
                                    string.Empty :
                                    dtgView[colIndex, rowIndex].Value.ToString();

                                if (_Value.Length > 0)
                                {
                                    if (_Value.Substring(0, 1) == "=" || dtgView.Columns[colIndex].DataPropertyName.Equals("MaTiepNhan", StringComparison.OrdinalIgnoreCase))
                                        _Value = "'" + _Value;
                                }
                                xlWorkSheet.Cells[row, col] = _Value.Replace("\r\n", "\n");
                            }

                            if (!string.IsNullOrEmpty(dtgView.Columns[colIndex].DefaultCellStyle.Format))
                                xlWorkSheet.Range[xlWorkSheet.Cells[row, col], xlWorkSheet.Cells[row, col]].NumberFormat = dtgView.Columns[colIndex].DefaultCellStyle.Format.Replace("N","").Replace("N","");
                        }
                    }
                    if (_have_iscate && dtgView[_indexcate, rowIndex].Value != null)
                    {
                        if ((bool)dtgView[_indexcate, rowIndex].Value)
                        {
                            FormatSheet(xlWorkSheet, false, 3, 2, 11, "Arial", true, false, Color.Black,
                                excel.Cells[row, 1], excel.Cells[row, col], false);
                        }
                    }
                }

                xlWorkSheet.Columns.WrapText = true;
                xlWorkSheet.Columns.VerticalAlignment = 2;
                xlWorkSheet.Rows.AutoFit();
                if (autoFit)
                {
                    xlWorkSheet.Columns.AutoFit();
                }
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dtgView.Rows.Count + 1, dtgView.Columns.Count - _col_invisible]].Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
                if (isLandscape || dtgView.Columns.Count > 15)
                {
                    try
                    {
                        xlWorkSheet.PageSetup.Orientation = COMExcel.XlPageOrientation.xlLandscape;

                        xlWorkSheet.PageSetup.TopMargin = 10;
                        xlWorkSheet.PageSetup.BottomMargin = 10;
                        xlWorkSheet.PageSetup.LeftMargin = 25;
                        xlWorkSheet.PageSetup.RightMargin = 25;

                        xlWorkSheet.PageSetup.Zoom = false;
                        xlWorkSheet.PageSetup.FitToPagesWide = 1;
                        xlWorkSheet.PageSetup.FitToPagesTall = false;
                    }
                    catch (Exception ex)
                    {
                        RecordError("Export_Excel_Error", ex.Message);
                    }

                }
                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                frm.Close();
            }
            catch (Exception ex)
            {
                Process[] proc = Process.GetProcessesByName("Excel");
                proc[0].Kill();
                RecordError("Export_Excel_Error", ex.Message.ToString());
                frm._isErr(string.Format("Có lỗi xảy ra trong quá trình xuất !\n{0}", ex.Message));
            }
        }
        public static void Export_NormalDataGrid(DataGridView dtgView
            , string[] CategoryHeaderName, int[] CategoryHeaderColumnIndexStart, int[] CategoryHeaderColumnIndexEnd
            , bool isLandscape, bool autoFit = true, string[] Tiltle = null, int fontSize = 10, bool fixWidth = false, bool checkRemoveColumn = false
            , string[] HeaderLeftVal = null
            , string[] HeaderRightVal = null
            , string[] FooterLeftVal = null
            , string[] FooterRightVal = null
            , bool widthBygrid = false)
        {
            FrmMessageBox_Process frm = new FrmMessageBox_Process();
            try
            {
                string _step = string.Empty;
                string _Value = string.Empty;
                frm.lblTitle.Text = "XUẤT EXCEL";
                frm.Msg = "Đang xuất excel.\n Vui lòng chờ!";
                frm.lblMsg.Visible = true;
                frm.Max = dtgView.Rows.Count;
                frm.proBar.Visible = true;
                frm.TopMost = true;
                frm.proBar.Step = 1;

                frm.Show();

                int row = 0;
                int col = 0;
                int _totalRow = dtgView.RowCount;
                int _totalColumn = dtgView.Columns.Count;
                int _col_invisible = 0;
                bool _have_iscate = false;
                int _indexcate = 0;
                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.PageSetup.PaperSize = COMExcel.XlPaperSize.xlPaperA4;

                row++;
                int rowAddCount = 1; //1 chp dòng tiêu đề
                //dtgView.AllowUserToAddRows = false;
                foreach (DataGridViewColumn dgc in dtgView.Columns)
                {
                    string colname = (dgc.HeaderText == null || string.IsNullOrEmpty(dgc.HeaderText) ? "" : dgc.HeaderText.Trim());
                    if (dgc.Visible)
                    {
                        _step = string.Format(" Đang xuất tiêu đề " + "\n Cột - {0} / {1}", col, _totalColumn);
                        frm.Perform_Percent(_step);
                        col++;

                        var startCell = excel.Cells[1, col];
                        var endCell = excel.Cells[1, col];
                        xlWorkSheet.Cells[row, col] = colname;
                        FormatSheet(xlWorkSheet,
                            false, 3, 2, 11, "Arial", true, false,
                            Color.Black, startCell,
                            endCell, false, (widthBygrid ? dgc.Width : 250));
                    }
                    else
                    {
                        if (dgc.DataPropertyName.ToLower().TrimEnd().TrimStart().Equals("iscate", StringComparison.OrdinalIgnoreCase) ||
                            colname.TrimEnd().ToLower().TrimStart().Equals("iscate", StringComparison.OrdinalIgnoreCase))
                        {
                            _have_iscate = true;
                            _indexcate = dgc.Index;
                        }
                        _col_invisible++;
                    }
                }

                //Định dạng header
                if (CategoryHeaderName != null)
                {
                    rowAddCount++;
                    int removeColumnCount = (checkRemoveColumn ? _col_invisible - 1 : 0);
                    var line = (COMExcel.Range)xlWorkSheet.Rows[row];
                    line.Insert();

                    row++;
                    int mincol = 0;
                    for (int ar = 0; ar < CategoryHeaderName.Length; ar++)
                    {
                        xlWorkSheet.Cells[1, CategoryHeaderColumnIndexStart[ar] - removeColumnCount] = CategoryHeaderName[ar];
                        FormatSheet(xlWorkSheet,
                            true, 3, 2, 11, "Arial", true, false,
                            Color.Black, excel.Cells[1, CategoryHeaderColumnIndexStart[ar] - removeColumnCount],
                           excel.Cells[1, CategoryHeaderColumnIndexEnd[ar] - removeColumnCount], true);
                        if (mincol < (CategoryHeaderColumnIndexStart[ar] - removeColumnCount))
                            mincol = CategoryHeaderColumnIndexStart[ar] - removeColumnCount;
                    }

                    for (int colC = 0; colC < dtgView.Columns.Count - _col_invisible; colC++)
                    {
                        if (xlWorkSheet.Range[xlWorkSheet.Cells[1, colC + 1], xlWorkSheet.Cells[1, colC + 1]].Value == null)
                        {
                            if (NotInRangeFormatColumn(CategoryHeaderColumnIndexStart, CategoryHeaderColumnIndexEnd, removeColumnCount, colC + 1))
                            {
                                xlWorkSheet.Cells[1, colC + 1] = xlWorkSheet.Cells[2, colC + 1];
                                xlWorkSheet.Cells[2, colC + 1] = null;

                                FormatSheet(xlWorkSheet,
                                true, 3, 2, 11, "Arial", true, false,
                                Color.Black, excel.Cells[1, colC + 1],
                               excel.Cells[2, colC + 1], true);
                            }
                        }
                    }
                }
                _step = string.Empty;
                for (int rowIndex = 0; rowIndex < dtgView.Rows.Count; rowIndex++)
                {
                    _step = string.Format(" Dòng - {0} / {1}", rowIndex, _totalRow);
                    frm.Perform_Percent(_step);
                    row++;
                    col = 0;
                    for (int colIndex = 0; colIndex < dtgView.Columns.Count; colIndex++)
                    {
                        if (dtgView.Columns[colIndex].Visible == true)
                        {
                            col++;

                            if (dtgView[colIndex, rowIndex].Value is DateTime)
                            {
                                xlWorkSheet.Cells[row, col] = Convert.ToDateTime(dtgView[colIndex, rowIndex].Value.ToString());
                            }
                            else
                            {
                                _Value = dtgView[colIndex, rowIndex].Value == null ?
                                    string.Empty :
                                    dtgView[colIndex, rowIndex].Value.ToString();

                                if (_Value.Length > 0)
                                {
                                    if (_Value.Substring(0, 1) == "=" || dtgView.Columns[colIndex].DataPropertyName.Equals("MaTiepNhan", StringComparison.OrdinalIgnoreCase))
                                        _Value = "'" + _Value;
                                }
                                _Value = _Value.Replace("\r\n", "\n");

                                xlWorkSheet.Cells[row, col] = _Value;
                                xlWorkSheet.Range[xlWorkSheet.Cells[row, col], xlWorkSheet.Cells[row, col]].WrapText = 1;
                            }
                            if (!string.IsNullOrEmpty(dtgView.Columns[colIndex].DefaultCellStyle.Format))
                                xlWorkSheet.Range[xlWorkSheet.Cells[row, col], xlWorkSheet.Cells[row, col]].NumberFormat = dtgView.Columns[colIndex].DefaultCellStyle.Format.Replace("N","");
                        }
                    }

                    if (_have_iscate && dtgView[_indexcate, rowIndex].Value != null)
                    {
                        if ((bool)dtgView[_indexcate, rowIndex].Value)
                        {
                            FormatSheet(xlWorkSheet, false, 3, 2, 11, "Arial", true, false, Color.Black,
                                excel.Cells[row, 1], excel.Cells[row, col], false);
                        }
                    }


                }
                xlWorkSheet.Columns.WrapText = true;
                xlWorkSheet.Columns.VerticalAlignment = 2;
                xlWorkSheet.Rows.AutoFit();
                if (autoFit)
                {
                    xlWorkSheet.Columns.AutoFit();
                }

                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dtgView.Rows.Count + rowAddCount, dtgView.Columns.Count - _col_invisible]].Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;

                if (FooterLeftVal != null)
                {
                    var rowA = 0;
                    for (int i = 0; i < FooterLeftVal.Length; i++)
                    {
                        rowA = dtgView.Rows.Count + rowAddCount + 1 + i;
                        xlWorkSheet.Cells[rowA, 1] = FooterLeftVal[i];

                        FormatSheet(xlWorkSheet, true, 2, 2, fontSize, "Arial", true, false, Color.Black,
                             xlWorkSheet.Cells[rowA, 1], xlWorkSheet.Cells[1 + i, 3], false);
                    }
                }

                if (FooterRightVal != null)
                {
                    var rowA = 0;
                    var colA = dtgView.Columns.Count - _col_invisible;
                    for (int i = 0; i < FooterRightVal.Length; i++)
                    {
                        rowA = dtgView.Rows.Count + rowAddCount + 1 + i;
                        xlWorkSheet.Cells[rowA, colA - 1] = FooterRightVal[i];

                        xlWorkSheet.Cells[rowA, colA] = HeaderRightVal[i];
                        FormatSheet(xlWorkSheet, false, 2, 2, fontSize, "Arial", true, false, Color.Black,
                         xlWorkSheet.Cells[rowA, colA - 1], xlWorkSheet.Cells[rowA, colA], false);
                    }
                }


                if (Tiltle != null)
                {

                    for (int i = 0; i < Tiltle.Length; i++)
                    {
                        var line = (COMExcel.Range)xlWorkSheet.Rows[1 + i];
                        line.Insert();
                        xlWorkSheet.Cells[1 + i, 1] = Tiltle[i];

                        FormatSheet(xlWorkSheet, true, 3, 2, fontSize, "Arial", true, false, Color.Black,
                          excel.Cells[1 + i, 1], excel.Cells[1 + i, dtgView.Columns.Count - _col_invisible], false, 0);
                    }
                    var line2 = (COMExcel.Range)xlWorkSheet.Rows[Tiltle.Length + 1];
                    line2.Insert();
                }
                if (HeaderLeftVal != null)
                {
                    for (int i = 0; i < HeaderLeftVal.Length; i++)
                    {
                        var line = (COMExcel.Range)xlWorkSheet.Rows[1 + i];
                        line.Insert();
                        xlWorkSheet.Cells[1 + i, 1] = HeaderLeftVal[i];

                        FormatSheet(xlWorkSheet, true, 2, 2, fontSize, "Arial", true, false, Color.Black,
                             xlWorkSheet.Cells[1 + i, 1], xlWorkSheet.Cells[1 + i, 3], false);
                    }
                }

                if (HeaderRightVal != null)
                {
                    for (int i = 0; i < HeaderRightVal.Length; i++)
                    {
                        if (HeaderLeftVal != null)
                        {
                            if (i + 1 > HeaderLeftVal.Length)
                            {
                                var line = (COMExcel.Range)xlWorkSheet.Rows[1 + i];
                                line.Insert();
                            }
                        }
                        else
                        {
                            var line = (COMExcel.Range)xlWorkSheet.Rows[1 + i];
                            line.Insert();
                        }

                        xlWorkSheet.Cells[1 + i, dtgView.Columns.Count - _col_invisible - 1] = HeaderRightVal[i];
                        FormatSheet(xlWorkSheet, false, 2, 2, fontSize, "Arial", true, false, Color.Black,
                         xlWorkSheet.Cells[1 + i, dtgView.Columns.Count - _col_invisible - 1], xlWorkSheet.Cells[1 + i, dtgView.Columns.Count - _col_invisible], false);
                    }
                }

                if (isLandscape || dtgView.Columns.Count > 15)
                {
                    xlWorkSheet.PageSetup.Orientation = COMExcel.XlPageOrientation.xlLandscape;
                }
                if (fixWidth)
                {
                    xlWorkSheet.PageSetup.TopMargin = 10;
                    xlWorkSheet.PageSetup.BottomMargin = 10;
                    xlWorkSheet.PageSetup.LeftMargin = 50;
                    xlWorkSheet.PageSetup.RightMargin = 50;

                    xlWorkSheet.PageSetup.Zoom = false;
                    xlWorkSheet.PageSetup.FitToPagesWide = 1;
                    xlWorkSheet.PageSetup.FitToPagesTall = false;
                    xlWorkSheet.PageSetup.CenterHorizontally = true;
                    try
                    {
                        xlWorkSheet.PageSetup.PaperSize = COMExcel.XlPaperSize.xlPaperA4;
                    }
                    catch (Exception ex)
                    {
                        RecordError("Export_Excel_Error", ex.Message.ToString());
                    }
                }

                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                frm.Close();
            }
            catch (Exception ex)
            {
                Process[] proc = Process.GetProcessesByName("Excel");
                proc[0].Kill();
                RecordError("Export_Excel_Error", ex.Message.ToString());
                frm._isErr(string.Format("Có lỗi xảy ra trong quá trình xuất !\n{0}", ex.Message));
            }
        }
        private static void Export_DataGridOutLook(OutlookStyleControls.OutlookGrid dtgView, bool isLandscape)
        {
            FrmMessageBox_Process frm = new FrmMessageBox_Process();
            try
            {
                string _step = string.Empty;
                string _Value = string.Empty;
                frm.lblTitle.Text = "XUẤT EXCEL";
                frm.Msg = "Đang xuất excel.\n Vui lòng chờ !";
                frm.lblMsg.Visible = true;
                frm.Max = dtgView.Rows.Count;
                frm.proBar.Visible = true;
                frm.TopMost = true;
                frm.proBar.Step = 1;

                frm.Show();

                int row = 0;
                int col = 0;
                int _totalRow = dtgView.RowCount;
                int _totalColumn = dtgView.Columns.Count;
                int _col_invisible = 0;
                bool _have_iscate = false;
                int _indexcate = 0;
                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                dtgView.AllowUserToAddRows = false;
                foreach (DataGridViewColumn dgc in dtgView.Columns)
                {
                    string colname = (dgc.HeaderText == null || string.IsNullOrEmpty(dgc.HeaderText) ? "" : dgc.HeaderText.Trim());
                    if (dgc.Visible)
                    {
                        _step = string.Format(" Đang xuất tiêu đề \n Cột - {0} / {1}", col, _totalColumn);
                        frm.Perform_Percent(_step);
                        col++;

                        xlWorkSheet.Cells[1, col] = colname;
                        FormatSheet(xlWorkSheet, false, 3, 2, 11, "Arial", true, false, Color.Black,
                            excel.Cells[1, col], excel.Cells[1, col], false);
                    }
                    else
                    {
                        if (dgc.DataPropertyName.ToLower().TrimEnd().TrimStart().Equals("iscate", StringComparison.OrdinalIgnoreCase) ||
                            colname.TrimEnd().ToLower().TrimStart().Equals("iscate", StringComparison.OrdinalIgnoreCase))
                        {
                            _have_iscate = true;
                            _indexcate = dgc.Index;
                        }
                        _col_invisible++;
                    }
                }
                row = 1;
                _step = string.Empty;

                for (int rowIndex = 0; rowIndex < dtgView.Rows.Count; rowIndex++)
                {
                    OutlookStyleControls.OutlookGridRow outrow = (OutlookStyleControls.OutlookGridRow)dtgView.Rows[rowIndex];
                    _step = string.Format(" Dòng - {0} / {1}", rowIndex, _totalRow);
                    frm.Perform_Percent(_step);
                    row++;
                    col = 0;
                    if (outrow.IsGroupRow)
                    {
                        col++;
                        xlWorkSheet.Cells[row, col] = outrow.GroupText;
                    }
                    else
                    {
                        for (int colIndex = 0; colIndex < dtgView.Columns.Count; colIndex++)
                        {
                            if (dtgView.Columns[colIndex].Visible == true)
                            {
                                col++;

                                if (dtgView[colIndex, rowIndex].Value is DateTime)
                                {
                                    xlWorkSheet.Cells[row, col] = Convert.ToDateTime(dtgView[colIndex, rowIndex].Value.ToString());
                                }
                                else
                                {
                                    _Value = dtgView[colIndex, rowIndex].Value == null ?
                                        string.Empty :
                                        dtgView[colIndex, rowIndex].Value.ToString();
                                    if (_Value.Length > 0)
                                    {
                                        if (_Value.Substring(0, 1) == "=" || dtgView.Columns[colIndex].DataPropertyName.Equals("MaTiepNhan", StringComparison.OrdinalIgnoreCase))
                                            _Value = "'" + _Value;
                                    }
                                    _Value = _Value.Replace("\r\n", "\n");
                                    xlWorkSheet.Cells[row, col] = _Value;

                                }
                                if (!string.IsNullOrEmpty(dtgView.Columns[colIndex].DefaultCellStyle.Format))
                                    xlWorkSheet.Range[xlWorkSheet.Cells[row, col], xlWorkSheet.Cells[row, col]].NumberFormat = dtgView.Columns[colIndex].DefaultCellStyle.Format.Replace("N","");
                            }
                        }
                    }

                    if (_have_iscate && dtgView[_indexcate, rowIndex].Value != null)
                    {
                        if ((bool)dtgView[_indexcate, rowIndex].Value)
                        {
                            FormatSheet(xlWorkSheet, true, 3, 2, 11, "Arial", true, false, Color.Black, excel.Cells[row, 1], excel.Cells[row, dtgView.ColumnCount - _col_invisible], false);
                        }
                    }
                    else if (outrow.IsGroupRow)
                        FormatSheet(xlWorkSheet, true, 3, 2, 11, "Arial", true, false, Color.Black, excel.Cells[row, 1], excel.Cells[row, dtgView.ColumnCount - _col_invisible], false);
                }

                xlWorkSheet.Columns.AutoFit();
                xlWorkSheet.Rows.AutoFit();
                xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dtgView.Rows.Count + 1, dtgView.Columns.Count - _col_invisible]].Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
                if (isLandscape || dtgView.Columns.Count > 15)
                {
                    xlWorkSheet.PageSetup.Orientation = COMExcel.XlPageOrientation.xlLandscape;
                }
                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                frm.Close();
            }
            catch (Exception ex)
            {
                Process[] proc = Process.GetProcessesByName("Excel");
                proc[0].Kill();
                RecordError("Export_Excel_Error", ex.Message);
                frm._isErr(string.Format("Có lỗi xảy ra trong quá trình xuất !\n{0}", ex.Message));
            }
        }
        public static void Export(DataGridView dtgView, bool autofix = true, bool isLandscape = false)
        {
            if (dtgView is OutlookStyleControls.OutlookGrid)
                Export_DataGridOutLook((OutlookStyleControls.OutlookGrid)dtgView, false);
            else
                Export_DataGrid(dtgView, isLandscape, autofix);
        }
        public static void Export(GridView gControl, string fileName = ""
            , int[,] arrCellMergeStar = null, int[,] arrCellMergeEnd = null
            , int[,] removeMerge = null)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = fileName;
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    gControl.RefreshData();
                    gControl.ResetCursor();
                    gControl.RefreshEditor(true);
                    //var exportOptions = new DevExpress.XtraPrinting.XlsExportOptions()
                    //{
                    //    ExportMode = DevExpress.XtraPrinting.XlsExportMode.SingleFile,
                    //    ShowGridLines = false
                    //};
                    //var exportOptionsType = new DevExpress.XtraPrinting.XlsExportOptionsEx()
                    //{
                    //    ExportType = DevExpress.Export.ExportType.WYSIWYG,
                    //};
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            var ex = new XlsExportOptionsEx();
                            ex.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                            ex.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                            ex.FitToPrintedPageWidth = false;
                            ex.ShowGridLines = true;
                            ex.CustomizeCell += Ex2_CustomizeCell;
                            gControl.OptionsPrint.AutoResetPrintDocument = true;
                            gControl.ExportToXls(exportFilePath, ex);
                            break;

                        case ".xlsx":
                            var ex2 = new XlsxExportOptionsEx();
                            ex2.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                            ex2.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                            ex2.FitToPrintedPageWidth = false;
                            ex2.ShowGridLines = true;
                            ex2.CustomizeCell += Ex2_CustomizeCell;
                            gControl.OptionsPrint.AutoResetPrintDocument = true;
                            gControl.ExportToXlsx(exportFilePath, ex2);
                            break;

                        case ".rtf":
                            gControl.ExportToRtf(exportFilePath);
                            break;

                        case ".pdf":
                            gControl.ExportToPdf(exportFilePath);
                            break;

                        case ".html":
                            gControl.ExportToHtml(exportFilePath);
                            break;

                        case ".mht":
                            gControl.ExportToMht(exportFilePath);
                            break;

                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            bool starApp = true;
                            if (arrCellMergeStar != null && arrCellMergeEnd != null)
                            {
                                COMExcel.Application ExcelObj = new COMExcel.Application();
                                //format excel
                                COMExcel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
                                     exportFilePath, 0, false, 5, string.Empty, string.Empty, true, COMExcel.XlPlatform.xlWindows, "\t",
                                     false, false, 0, true, false, false);

                                COMExcel.Sheets sheets = theWorkbook.Worksheets;
                                COMExcel.Worksheet worksheet = (COMExcel.Worksheet)sheets.get_Item(1);

                                if (removeMerge != null)
                                {
                                    for (int a = 0; a < removeMerge.Length / 2; a++)
                                    {
                                        worksheet.Range[worksheet.Cells[removeMerge[a, 0], removeMerge[a, 1]], worksheet.Cells[removeMerge[a, 0], arrCellMergeStar[a, 1]]].MergeCells = false;
                                        worksheet.Cells[removeMerge[a, 0], removeMerge[a, 1]] = null;
                                    }
                                }

                                for (int i = 0; i < arrCellMergeStar.Length / 2; i++)
                                {

                                    var starcellRow = arrCellMergeStar[i, 0];
                                    var starcellCol = arrCellMergeStar[i, 1];

                                    var endcellRow = arrCellMergeEnd[i, 0];
                                    var endcellCol = arrCellMergeEnd[i, 1];

                                    worksheet.Range[worksheet.Cells[starcellRow, starcellCol], worksheet.Cells[endcellRow, endcellCol]].MergeCells = true;
                                }

                                worksheet.Columns.AutoFit();
                                ExcelObj.DisplayAlerts = false;
                                // File.Delete(exportFilePath);
                                try
                                {
                                    theWorkbook.SaveAs(exportFilePath, COMExcel.XlFileFormat.xlWorkbookNormal, null, null, false, false, COMExcel.XlSaveAsAccessMode.xlShared, false, false, null, null, null);
                                }
                                catch (Exception ex)
                                {
                                    starApp = false;
                                    //   String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                    MessageBox.Show(ex.Message, "Không thể lưu file sau khi format!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ExcelObj.Visible = true;
                                }
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelObj);
                            }
                            //  Try to open the file and let windows decide how to open it.
                            if (starApp)
                                System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch (Exception ex)
                        {
                            //   String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static void Export(GridControl gControl, string fileName = ""
            , bool fixWraptext = false, int rowfix = -1, int colFix = -1
            , string[] Tiltle = null
             , int[] TiltleSize = null
            , string[] HeaderLeftVal = null
             , int[] HeaderLeftSize = null
            , string[] HeaderRightVal = null
              , int[] HeaderRightSize = null
            , string[] FooterLeftVal = null
               , int[] FooterLeftSize = null
            , string[] FooterRightVal = null
            , int[] FooterRightSize = null)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = fileName;
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            var ex = new XlsExportOptionsEx();
                            ex.ExportType = ExportType.WYSIWYG;
                            ex.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                            ex.TextExportMode = TextExportMode.Value;
                            ex.FitToPrintedPageWidth = false;
                            ex.ShowGridLines = true;
                            ex.CustomizeCell += Ex2_CustomizeCell;
                            gControl.MainView.OptionsPrint.AutoResetPrintDocument = true;
                            gControl.ExportToXls(exportFilePath, ex);
                            break;
                        case ".xlsx":
                            var ex2 = new XlsxExportOptionsEx();
                            ex2.ExportType = ExportType.WYSIWYG;
                            ex2.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                            ex2.TextExportMode = TextExportMode.Value;
                            ex2.FitToPrintedPageWidth = false;
                            ex2.ShowGridLines = true;
                            ex2.CustomizeCell += Ex2_CustomizeCell;
                            gControl.MainView.OptionsPrint.AutoResetPrintDocument = true;
                            gControl.ExportToXlsx(exportFilePath, ex2);
                            break;
                        case ".rtf":
                            gControl.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gControl.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gControl.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gControl.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            if ((fixWraptext && rowfix > 0 && colFix > 0) || FooterLeftVal != null || FooterRightVal != null || HeaderLeftVal != null || HeaderRightVal != null)
                            {
                                COMExcel.Application ExcelObj = new COMExcel.Application();
                                //format excel
                                COMExcel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
                                     exportFilePath, 0, false, 5, string.Empty, string.Empty, true, COMExcel.XlPlatform.xlWindows, "\t",
                                     false, false, 0, true, false, false);

                                COMExcel.Sheets sheets = theWorkbook.Worksheets;
                                COMExcel.Worksheet worksheet = (COMExcel.Worksheet)sheets.get_Item(1);

                                if ((fixWraptext && rowfix > 0 && colFix > 0))
                                    worksheet.Range[worksheet.Cells[rowfix, colFix], worksheet.Cells[rowfix, colFix]].WrapText = true;

                                COMExcel.Range last = worksheet.Cells.SpecialCells(COMExcel.XlCellType.xlCellTypeLastCell, Type.Missing);
                                COMExcel.Range range = worksheet.get_Range("A1", last);


                                var colLast = worksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, COMExcel.XlSearchOrder.xlByColumns, COMExcel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
                                var rowLast = worksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, COMExcel.XlSearchOrder.xlByRows, COMExcel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row; ;
                                var fontSize = 10;
                                if (FooterLeftVal != null)
                                {
                                    for (int i = 0; i < FooterLeftVal.Length; i++)
                                    {
                                        if (FooterLeftSize != null)
                                        {
                                            if (FooterLeftSize.Length > i)
                                            {
                                                fontSize = FooterLeftSize[i];
                                            }
                                        }
                                        worksheet.Cells[rowLast, 1] = FooterLeftVal[i];
                                        FormatSheet(worksheet, true, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                             worksheet.Cells[rowLast, 1], worksheet.Cells[1 + i, 3], false);
                                    }
                                }

                                if (FooterRightVal != null)
                                {
                                    for (int i = 0; i < FooterRightVal.Length; i++)
                                    {
                                        fontSize = 10;
                                        worksheet.Cells[rowLast, colLast - 1] = FooterRightVal[i];
                                        if (FooterRightSize != null)
                                        {
                                            if (FooterRightSize.Length > i)
                                            {
                                                fontSize = FooterRightSize[i];
                                            }
                                        }
                                        worksheet.Cells[rowLast, colLast] = HeaderRightVal[i];
                                        FormatSheet(worksheet, false, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                         worksheet.Cells[rowLast, colLast - 1], worksheet.Cells[rowLast, colLast], false);
                                    }
                                }
                                if (Tiltle != null)
                                {

                                    for (int i = 0; i < Tiltle.Length; i++)
                                    {
                                        var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                        line.Insert();
                                        fontSize = 10;
                                        worksheet.Cells[1 + i, 1] = Tiltle[i];
                                        if (TiltleSize != null)
                                        {
                                            if (TiltleSize.Length > i)
                                            {
                                                fontSize = TiltleSize[i];
                                            }
                                        }
                                        FormatSheet(worksheet, true, 3, 2, fontSize, "Arial", true, false, Color.Black,
                                          worksheet.Cells[1 + i, 1], worksheet.Cells[1 + i, colLast], false, 0);
                                    }
                                    var line2 = (COMExcel.Range)worksheet.Rows[Tiltle.Length + 1];
                                    line2.Insert();
                                }
                                if (HeaderLeftVal != null)
                                {
                                    for (int i = 0; i < HeaderLeftVal.Length; i++)
                                    {
                                        var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                        line.Insert();
                                        fontSize = 10;
                                        worksheet.Cells[1 + i, 1] = HeaderLeftVal[i];
                                        if (HeaderLeftSize != null)
                                        {
                                            if (HeaderLeftSize.Length > i)
                                            {
                                                fontSize = HeaderLeftSize[i];
                                            }
                                        }
                                        FormatSheet(worksheet, true, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                             worksheet.Cells[1 + i, 1], worksheet.Cells[1 + i, 3], false);
                                    }
                                }

                                if (HeaderRightVal != null)
                                {
                                    for (int i = 0; i < HeaderRightVal.Length; i++)
                                    {
                                        if (HeaderLeftVal != null)
                                        {
                                            if (i + 1 > HeaderLeftVal.Length)
                                            {
                                                var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                                line.Insert();
                                            }
                                        }
                                        else
                                        {
                                            var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                            line.Insert();
                                        }
                                        fontSize = 10;
                                        worksheet.Cells[1 + i, colLast - 1] = HeaderRightVal[i];
                                        if (HeaderRightSize != null)
                                        {
                                            if (HeaderRightSize.Length > i)
                                            {
                                                fontSize = HeaderRightSize[i];
                                            }
                                        }
                                        FormatSheet(worksheet, false, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                         worksheet.Cells[1 + i, colLast - 1], worksheet.Cells[1 + i, colLast], false);
                                    }
                                }

                                worksheet.Columns.AutoFit();
                                ExcelObj.DisplayAlerts = false;
                                // File.Delete(exportFilePath);
                                try
                                {
                                    theWorkbook.SaveAs(exportFilePath, COMExcel.XlFileFormat.xlWorkbookNormal, null, null, false, false, COMExcel.XlSaveAsAccessMode.xlShared, false, false, null, null, null);
                                }
                                catch
                                {
                                    var msg = string.Format("Không thể lưu các chỉnh sửa format!{0}Bạn hãy lưu lại trước khi đóng exel.", Environment.NewLine);
                                    MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                ExcelObj.Visible = true;
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelObj);
                            }
                            else
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static void Export_VS(GridControl gControl, string fileName = "", bool fixWraptext = false, int rowfix = -1, int colFix = -1
      , string[] Tiltle = null
       , int[] TiltleSize = null
      , string[] HeaderLeftVal = null
       , int[] HeaderLeftSize = null
      , string[] HeaderRightVal = null
        , int[] HeaderRightSize = null
      , string[] FooterLeftVal = null
         , int[] FooterLeftSize = null
      , string[] FooterRightVal = null
      , int[] FooterRightSize = null)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.FileName = fileName;
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            if (gControl.DefaultView.RowCount <= 65000)
                            {
                                var ex = new XlsExportOptionsEx();
                                ex.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                                ex.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                                ex.TextExportMode = TextExportMode.Value;

                                ex.FitToPrintedPageWidth = false;
                                ex.ShowGridLines = true;
                                ex.CustomizeCell += Ex2_CustomizeCell;
                                gControl.MainView.OptionsPrint.AutoResetPrintDocument = true;
                                gControl.ExportToXls(exportFilePath, ex);
                            }
                            else
                                MessageBox.Show("Không thể xuất excel định dạng .xls với số dòng > 65 000.\nHãy thử xuất với định dạng .xlsx ");
                            break;
                        case ".xlsx":
                            var ex2 = new XlsxExportOptionsEx();
                            ex2.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                            ex2.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                            ex2.TextExportMode = TextExportMode.Value;
                            ex2.FitToPrintedPageWidth = false;
                            ex2.ShowGridLines = true;
                            ex2.CustomizeCell += Ex2_CustomizeCell;
                            gControl.MainView.OptionsPrint.AutoResetPrintDocument = true;
                            gControl.ExportToXlsx(exportFilePath, ex2);
                            break;
                        case ".rtf":
                            gControl.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gControl.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gControl.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gControl.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            if ((fixWraptext && rowfix > 0 && colFix > 0) || FooterLeftVal != null || FooterRightVal != null || HeaderLeftVal != null || HeaderRightVal != null)
                            {
                                COMExcel.Application ExcelObj = new COMExcel.Application();
                                //format excel
                                COMExcel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
                                     exportFilePath, 0, false, 5, string.Empty, string.Empty, true, COMExcel.XlPlatform.xlWindows, "\t",
                                     false, false, 0, true, false, false);

                                COMExcel.Sheets sheets = theWorkbook.Worksheets;
                                COMExcel.Worksheet worksheet = (COMExcel.Worksheet)sheets.get_Item(1);

                                if ((fixWraptext && rowfix > 0 && colFix > 0))
                                    worksheet.Range[worksheet.Cells[rowfix, colFix], worksheet.Cells[rowfix, colFix]].WrapText = true;

                                COMExcel.Range last = worksheet.Cells.SpecialCells(COMExcel.XlCellType.xlCellTypeLastCell, Type.Missing);
                                COMExcel.Range range = worksheet.get_Range("A1", last);


                                var colLast = worksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, COMExcel.XlSearchOrder.xlByColumns, COMExcel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;
                                var rowLast = worksheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, COMExcel.XlSearchOrder.xlByRows, COMExcel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row; ;
                                var fontSize = 10;
                                if (FooterLeftVal != null)
                                {
                                    for (int i = 0; i < FooterLeftVal.Length; i++)
                                    {
                                        if (FooterLeftSize != null)
                                        {
                                            if (FooterLeftSize.Length > i)
                                            {
                                                fontSize = FooterLeftSize[i];
                                            }
                                        }
                                        worksheet.Cells[rowLast, 1] = FooterLeftVal[i];
                                        FormatSheet(worksheet, true, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                             worksheet.Cells[rowLast, 1], worksheet.Cells[1 + i, 3], false);
                                    }
                                }

                                if (FooterRightVal != null)
                                {
                                    for (int i = 0; i < FooterRightVal.Length; i++)
                                    {
                                        fontSize = 10;
                                        worksheet.Cells[rowLast, colLast - 1] = FooterRightVal[i];
                                        if (FooterRightSize != null)
                                        {
                                            if (FooterRightSize.Length > i)
                                            {
                                                fontSize = FooterRightSize[i];
                                            }
                                        }
                                        worksheet.Cells[rowLast, colLast] = HeaderRightVal[i];
                                        FormatSheet(worksheet, false, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                         worksheet.Cells[rowLast, colLast - 1], worksheet.Cells[rowLast, colLast], false);
                                    }
                                }
                                if (Tiltle != null)
                                {

                                    for (int i = 0; i < Tiltle.Length; i++)
                                    {
                                        var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                        line.Insert();
                                        fontSize = 10;
                                        worksheet.Cells[1 + i, 1] = Tiltle[i];
                                        if (TiltleSize != null)
                                        {
                                            if (TiltleSize.Length > i)
                                            {
                                                fontSize = TiltleSize[i];
                                            }
                                        }
                                        FormatSheet(worksheet, true, 3, 2, fontSize, "Arial", true, false, Color.Black,
                                          worksheet.Cells[1 + i, 1], worksheet.Cells[1 + i, colLast], false, 0);
                                    }
                                    var line2 = (COMExcel.Range)worksheet.Rows[Tiltle.Length + 1];
                                    line2.Insert();
                                }
                                if (HeaderLeftVal != null)
                                {
                                    for (int i = 0; i < HeaderLeftVal.Length; i++)
                                    {
                                        var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                        line.Insert();
                                        fontSize = 10;
                                        worksheet.Cells[1 + i, 1] = HeaderLeftVal[i];
                                        if (HeaderLeftSize != null)
                                        {
                                            if (HeaderLeftSize.Length > i)
                                            {
                                                fontSize = HeaderLeftSize[i];
                                            }
                                        }
                                        FormatSheet(worksheet, true, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                             worksheet.Cells[1 + i, 1], worksheet.Cells[1 + i, 3], false);
                                    }
                                }

                                if (HeaderRightVal != null)
                                {
                                    for (int i = 0; i < HeaderRightVal.Length; i++)
                                    {
                                        if (HeaderLeftVal != null)
                                        {
                                            if (i + 1 > HeaderLeftVal.Length)
                                            {
                                                var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                                line.Insert();
                                            }
                                        }
                                        else
                                        {
                                            var line = (COMExcel.Range)worksheet.Rows[1 + i];
                                            line.Insert();
                                        }
                                        fontSize = 10;
                                        worksheet.Cells[1 + i, colLast - 1] = HeaderRightVal[i];
                                        if (HeaderRightSize != null)
                                        {
                                            if (HeaderRightSize.Length > i)
                                            {
                                                fontSize = HeaderRightSize[i];
                                            }
                                        }
                                        FormatSheet(worksheet, false, 2, 2, fontSize, "Arial", true, false, Color.Black,
                                         worksheet.Cells[1 + i, colLast - 1], worksheet.Cells[1 + i, colLast], false);
                                    }

                                }

                                worksheet.Columns.AutoFit();
                                ExcelObj.DisplayAlerts = false;
                                // File.Delete(exportFilePath);
                                theWorkbook.SaveAs(exportFilePath, COMExcel.XlFileFormat.xlWorkbookNormal, null, null, false, false, COMExcel.XlSaveAsAccessMode.xlShared, false, false, null, null, null);
                                ExcelObj.Visible = true;
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(theWorkbook);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelObj);
                            }
                            else
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static void ExportToFileExisted(GridView gc, GridControl gControl, string fileName, int startCol, int startRow)
        {

        }
        private static void Ex2_CustomizeCell(CustomizeCellEventArgs e)
        {
            RecordError("Log", string.Format("Export: e.AreaType = {0}, e.ColumnFieldName = {1}, e.Value  = {2}  ", e.AreaType, e.ColumnFieldName, e.Value));
            if (e.AreaType == SheetAreaType.DataArea 
                && e.ColumnFieldName == "Text" )
            {
                e.Formatting.Alignment = new XlCellAlignment() { WrapText = true };
                e.Handled = true;
            }

        }

        public static void Export_Landscape(DataGridView dtgView)
        {
            Export_DataGrid(dtgView, true);
        }
        public static void Export(DataTable tb)
        {
            Export_DataTable(tb, false);
        }
        public static void Export_Landscape(DataTable tb)
        {
            Export_DataTable(tb, true);
        }
        /// <summary>
        /// Xuất dữ liệu ra sheet trên excel có sẵn
        /// </summary>
        /// <param name="sheet">Sheet thứ</param>
        /// <param name="row">Dòng thứ</param>
        /// <param name="column">Cột thứ</param>
        /// <param name="value">Giá trị</param>
        public static void Export(int sheet, int row, int column, string value)
        {
            string workbookPath = string.Empty;
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Excel file (*.xls)|*.xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbookPath = sfd.FileName;
                // Khởi động Excell
                COMExcel.Application exApp = new COMExcel.Application();

                //Mo file co san
                COMExcel.Workbook exBook = exApp.Workbooks.Open(workbookPath,
                         0, false, 5, string.Empty, string.Empty, false,
                         COMExcel.XlPlatform.xlWindows, string.Empty,
                         true, false, 0, true, false, false);
                // Get sheet.
                COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[sheet];

                exSheet.Activate();

                COMExcel.Range r = (COMExcel.Range)exSheet.Cells[row, column];

                r.Value2 = value;

                exApp.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

            }
        }
        /// <summary>
        /// Xuất dữ liệu ra sheet trên excel có sẵn
        /// </summary>
        /// <param name="sheet">Sheet thứ</param>
        /// <param name="dgv">DataGrid view</param>
        /// <param name="row">Dòng thứ</param>
        /// <param name="column">Cột thứ</param>
        /// <param name="value">Giá trị</param>
        public static void Export(int sheet, DataGridView dgv, int row, int column, int value)
        {
            string workbookPath = string.Empty;
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Excel file (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbookPath = sfd.FileName;
                // Khởi động Excell
                COMExcel.Application exApp = new COMExcel.Application();

                //Mo file co san
                COMExcel.Workbook exBook = exApp.Workbooks.Open(workbookPath,
                         0, false, 5, string.Empty, string.Empty, false,
                         COMExcel.XlPlatform.xlWindows, string.Empty,
                         true, false, 0, true, false, false);
                // Get sheet.
                COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[sheet];

                exSheet.Activate();

                COMExcel.Range r;
                //Duyệt qua từng dòng trên lưới
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    r = (COMExcel.Range)exSheet.Cells[dgv.Rows[i].Cells[row].Value, column];
                    //Gán giá trị
                    r.Value2 = dgv.Rows[i].Cells[value].Value;
                }

                exApp.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
        }
        /// <summary>
        /// Xuất dữ liệu ra sheet trên excel có sẵn
        /// </summary>
        /// <param name="sheet">Sheet thứ</param>
        /// <param name="dgv">DataGrid view</param>
        /// <param name="row">Dòng thứ</param>
        /// <param name="column">Cột thứ</param>
        /// <param name="value">Giá trị</param>
        public static void Export(int sheet, DataGridView dgv, int row, int[] columns, int[] values)
        {
            string workbookPath = string.Empty;
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Excel file (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbookPath = sfd.FileName;
                // Khởi động Excell
                COMExcel.Application exApp = new COMExcel.Application();

                //Mo file co san
                COMExcel.Workbook exBook = exApp.Workbooks.Open(workbookPath,
                         0, false, 5, string.Empty, string.Empty, false,
                         COMExcel.XlPlatform.xlWindows, string.Empty,
                         true, false, 0, true, false, false);
                // Get sheet.
                COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[sheet];

                //exSheet.Activate();
                //COMExcel.Range r;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int k = 0; k < values.Length; k++)
                    {
                        foreach (int j in columns)
                        {
                            exSheet.Cells[dgv.Rows[i].Cells[row].Value, j] = dgv.Rows[i].Cells[values[k]].Value;
                            k++;
                        }
                    }

                }

                exApp.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
        }
        /// <summary>
        /// Xuất dữ liệu ra trên 1 or hơn sheet
        /// </summary>
        /// <param name="sheet">Sheet thứ</param>
        /// <param name="dgv">DataGrid view</param>
        /// <param name="row">Dòng thứ</param>
        /// <param name="column">Cột thứ</param>
        /// <param name="value">Giá trị</param>
        public static void Export(int[] sheet, DataGridView[] dgv, int row, int[] columns, int[] values)
        {
            string workbookPath = string.Empty;
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Excel file (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbookPath = sfd.FileName;
                // Khởi động Excell
                COMExcel.Application exApp = new COMExcel.Application();

                //Mo file co san
                COMExcel.Workbook exBook = exApp.Workbooks.Open(workbookPath,
                         0, false, 5, string.Empty, string.Empty, false,
                         COMExcel.XlPlatform.xlWindows, string.Empty,
                         true, false, 0, true, false, false);
                // Get sheet.
                for (int n = 0; n < sheet.Length; n++)
                {
                    COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[sheet[n]];

                    for (int i = 0; i < dgv[n].RowCount; i++)
                    {
                        for (int k = 0; k < values.Length; k++)
                        {
                            foreach (int j in columns)
                            {
                                exSheet.Cells[dgv[n].Rows[i].Cells[row].Value, j] = dgv[n].Rows[i].Cells[values[k]].Value;
                                k++;
                            }
                        }

                    }
                }
                exApp.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
        }
        /// <summary>
        /// Xuất dữ liệu ra trên 1 or hơn sheet
        /// </summary>
        /// <param name="sheet">Sheet thứ</param>
        /// <param name="dgv">DataGrid view</param>
        /// <param name="row">Dòng thứ</param>
        /// <param name="column">Cột thứ</param>
        /// <param name="value">Giá trị</param>
        public static void Export(int[] sheet, DataGridView[] dgv, int position, int[] values)
        {
            string workbookPath = string.Empty;
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Excel file (*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                workbookPath = sfd.FileName;
                // Khởi động Excell
                COMExcel.Application exApp = new COMExcel.Application();

                //Mo file co san
                COMExcel.Workbook exBook = exApp.Workbooks.Open(workbookPath,
                         0, false, 5, string.Empty, string.Empty, false,
                         COMExcel.XlPlatform.xlWindows, string.Empty,
                         true, false, 0, true, false, false);
                // Get sheet.
                int _row = 0;
                int _column = 0;
                string _position = string.Empty;
                string[] info = new string[1];
                for (int n = 0; n < sheet.Length; n++)
                {
                    COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[sheet[n]];

                    for (int i = 0; i < dgv[n].RowCount; i++)
                    {

                        _position = dgv[n].Rows[i].Cells[position].Value.ToString();
                        info = _position.Split(new char[] { ';' });
                        _row = int.Parse(info[0]);
                        _column = int.Parse(info[1]);
                        for (int k = 0; k < values.Length; k++)
                        {
                            //int 
                            exSheet.Cells[_row, _column] = dgv[n].Rows[i].Cells[values[k]].Value;
                            //k++;
                        }

                    }
                }
                exApp.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
        }
        public static DataTable Import()
        {
            try
            {
                DataTable dtDataImport = new DataTable();

                OpenFileDialog sfd = new OpenFileDialog();
                sfd.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";
                COMExcel.Application ExcelObj = null;

                ExcelObj = new COMExcel.Application();
                int startRow = 2;
                if (sfd.ShowDialog() == DialogResult.OK)
                {

                    COMExcel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
                       sfd.FileName, 0, true, 5,
                        string.Empty, string.Empty, true, COMExcel.XlPlatform.xlWindows, "\t",
                        false, false, 0, true, false, false);
                    COMExcel.Sheets sheets = theWorkbook.Worksheets;
                    COMExcel.Worksheet worksheet = (COMExcel.Worksheet)sheets.get_Item(1);
                    COMExcel.Range xlRange = worksheet.UsedRange;
                    for (int c = 1; c <= xlRange.Columns.Count; c++)
                    {
                        dtDataImport.Columns.Add("Column" + c.ToString(), typeof(string));
                    }

                    for (int i = startRow; i <= xlRange.Rows.Count; i++)
                    {
                        DataRow dr = dtDataImport.NewRow();
                        for (int cl = 1; cl <= xlRange.Columns.Count; cl++)
                        {
                            dr["Column" + cl.ToString()] = (xlRange.Cells[i, cl]).Value ?? string.Empty;
                        }
                        dtDataImport.Rows.Add(dr);
                        dtDataImport.AcceptChanges();
                    }

                }
                return dtDataImport;
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Waring_OK(ex.Message);
                return new DataTable();
            }
        }
        static string[] ConvertToStringArray(System.Array values)
        {
            // create a new string array
            string[] theArray = new string[values.Length];

            // loop through the 2-D System.Array and populate the 1-D String Array
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = string.Empty;
                else
                    theArray[i - 1] = (string)values.GetValue(1, i).ToString();
            }

            return theArray;
        }

        public static void FormatSheet(COMExcel.Worksheet exWorkSheet,
            bool isMerge, int horizontalAlignment, int verticalAlignment,
            int fontSize, string fontName, bool isBold, bool isItalic,
            System.Drawing.Color fontColor, object startCell, object endCell)
        {
            if (isMerge)
            {
                exWorkSheet.get_Range(startCell, endCell).MergeCells = true;
            }
            exWorkSheet.get_Range(startCell, endCell).HorizontalAlignment = horizontalAlignment;
            exWorkSheet.get_Range(startCell, endCell).VerticalAlignment = verticalAlignment;
            exWorkSheet.get_Range(startCell, endCell).Font.Name = fontName;
            exWorkSheet.get_Range(startCell, endCell).Font.Size = fontSize;
            exWorkSheet.get_Range(startCell, endCell).Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (isBold)
            {
                exWorkSheet.get_Range(startCell, endCell).Font.Bold = true;
            }
            if (isItalic)
            {
                exWorkSheet.get_Range(startCell, endCell).Font.Italic = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exWorkSheet">COMExcel.WorkSheet</param>
        /// <param name="isMerge"></param>
        /// <param name="horizontalAlignment">2: Trái - 3: Giữa - 4: Phải</param>
        /// <param name="verticalAlignment">1: Trái - 2: Giữa - 3: Phải</param>
        /// <param name="fontSize"></param>
        /// <param name="fontName"></param>
        /// <param name="isBold"></param>
        /// <param name="isItalic"></param>
        /// <param name="fontColor"></param>
        /// <param name="startCell">Truyền vào Cell</param>
        /// <param name="endCell">Truyền vào Cell</param>
        /// <param name="boderCell">Đóng khung cell</param>
        public static void FormatSheet(COMExcel.Worksheet exWorkSheet,
            bool isMerge, int horizontalAlignment, int verticalAlignment,
            int fontSize, string fontName, bool isBold, bool isItalic,
            System.Drawing.Color fontColor, object startCell, object endCell, bool boderCell, int width = 0)
        {
            var log = string.Empty;
            try
            {
                log = "range";
                var range = (COMExcel.Range)exWorkSheet.Range[startCell, endCell];
                log = "isMerge";
                if (isMerge)
                {
                    range.MergeCells = true;
                }
                log = "range set";
                range.HorizontalAlignment = horizontalAlignment;
                range.VerticalAlignment = verticalAlignment;
                range.Font.Name = fontName;
                range.Font.Size = fontSize;
                log = "width set";
                if (width != 0)
                {
                    if (width > 255)
                    {
                        range.Cells.ColumnWidth = 47;
                    }
                    else
                    {
                        range.Cells.ColumnWidth = width / 8;
                    }
                }
                log = "range Color";

                range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
                if (boderCell)
                {
                    range.Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
                }
                else
                    range.Borders.LineStyle = COMExcel.XlLineStyle.xlLineStyleNone;
                log = " range.Font.Bold ";
                if (isBold)
                {
                    range.Font.Bold = true;
                }
                log = " range.Font.Italic ";
                if (isItalic)
                {
                    range.Font.Italic = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public static DataTable ReadAndGetData()
        {
            var f = new FrmReadExcelData();
            f.ShowDialog();
            return f.DataGetted;
        }
        private static void RecordError(string fileName, string msg)
        {
            try
            {
                FileStream fs = new FileStream(@"Logs\" + fileName + "_" + DateTime.Now.ToString("ddMMyy") + ".txt", FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);
                StreamWriter sw = new StreamWriter(fs);
                msg = "---------=====----------" + Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + Environment.NewLine + msg;
                sw.WriteLine(msg);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

                return;
            }

        }
    }
}
