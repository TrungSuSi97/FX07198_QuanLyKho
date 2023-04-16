using System;
using System.Collections.Generic;
using System.Text;
using DataGridViewToExcel;
using System.Windows.Forms;
using CarlosAg.ExcelXmlWriter;
using System.Diagnostics;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Data;
using DataAccessLayer;
using Components;
using System.Drawing;
using System.Threading;
using System.ComponentModel;

namespace LabSoftProfessional
{
    public partial class FrmExportExcel : Form
    {
        public FrmExportExcel()
        {
            InitializeComponent();
        }
        private string _sMsg;

        public string Msg
        {
            get { return _sMsg; }
            set { _sMsg = value; }
        }
        private string _caption;

        public string FormCaption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        private int _Max;

        public int Max
        {
            get { return _Max; }
            set { _Max = value; }
        }
        object dataExport = new object();

        public object DataExport
        {
            get { return dataExport; }
            set { dataExport = value; }
        }

        bool cancel = false;
       
        private void Export(DataTable tb)
        {
           try
            {
                proBar.Maximum = tb.Rows.Count + tb.Columns.Count;
                proBar.Visible = true;
                proBar.Step = 1;

                int rowIndex = 0;
                int colIndex = 0;
                int _totalRow = tb.Rows.Count;
                int _totalColumn = tb.Columns.Count;
                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                // excel.Application.Workbooks.Add(true);

                string _step = "";
                string _Value = "";
                // write
                foreach (DataColumn col in tb.Columns)
                {
                    _step = " Đang xuất tiêu đề " + "\n Cột - " + colIndex.ToString() + " / " + _totalColumn.ToString();
                    Perform_Percent(_step);
                    colIndex++;
                    if (col.Caption == "")
                    {
                        xlWorkSheet.Cells[1, colIndex] = col.ColumnName;
                    }
                    else
                    {
                        xlWorkSheet.Cells[1, colIndex] = col.Caption;
                    }
                    FormatSheet(xlWorkSheet, false, 2, 2, 11, "Arial", true, false, Color.Black, excel.Cells[1, colIndex], excel.Cells[1, colIndex], false);
                }

                rowIndex = 1;
                _step = "";
                foreach (DataRow row in tb.Rows)
                {
                    _step =  rowIndex.ToString() + " / " + _totalRow.ToString() + " dòng"; ;
                    Perform_Percent(_step);
                    rowIndex++;
                    colIndex = 0;
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

                            if (_Value.IndexOf("=") == 0)
                                _Value = "'" + _Value;

                            xlWorkSheet.Cells[rowIndex, colIndex] = _Value.Replace("\r\n", "\n");
                        }
                    }
                }
                xlWorkSheet.Columns.AutoFit();
                xlWorkSheet.Rows.AutoFit();
                xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[tb.Rows.Count + 1, tb.Columns.Count]).Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                this.Close();
            }
            catch (Exception ex)
            {
                Error_Code error = new Error_Code();
                error.GetErr_Framework(ex, "Export DataTable");
                this.Close();
            }
        }
        private void Export(DataGridView dtgView)
        {
            try
            {
                string _step = "";
                string _Value = "";
                Msg = "Đang xuất excel.\n Vui lòng chờ !";
                lblMsg.Visible = true;
                proBar.Maximum = dtgView.Rows.Count + dtgView.Columns.Count;
                proBar.Visible = true;
                proBar.Step = 1;
                int row = 0;
                int col = 0;
                int _totalRow = dtgView.RowCount;
                int _totalColumn = dtgView.Columns.Count;
                int _col_invisible = 0;
                bool _have_iscate = false;
                COMExcel.Application excel = new COMExcel.Application();
                COMExcel.Workbook xlWorkBook;
                COMExcel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excel.Workbooks.Add(misValue);
                xlWorkSheet = (COMExcel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                dtgView.AllowUserToAddRows = false;

                foreach (DataGridViewColumn dgc in dtgView.Columns)
                {
                    if (dgc.Visible == true)
                    {
                        _step = " Đang xuất tiêu đề " + "\n Cột - " + col.ToString() + " / " + _totalColumn.ToString();
                        Perform_Percent(_step);
                        col++;

                        xlWorkSheet.Cells[1, col] = dgc.HeaderText.Trim();
                        FormatSheet(xlWorkSheet, false, 2, 2, 11, "Arial", true, false, Color.Black, excel.Cells[1, col], excel.Cells[1, col], false);
                    }
                    else
                    {
                        if (dgc.Name.ToLower().TrimEnd().TrimStart() == "iscate" || dgc.HeaderText.TrimEnd().ToLower().TrimStart() == "iscate")
                        {
                            _have_iscate = true;
                        }
                        _col_invisible++;
                        proBar.Value++;
                    }
                }
                row = 1;
                _step = "";
                for (int rowIndex = 0; rowIndex < dtgView.Rows.Count; rowIndex++)
                {
                    _step = rowIndex.ToString() + " / " + _totalRow.ToString() + " dòng";
                    Perform_Percent(_step);
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
                                _Value = dtgView[colIndex, rowIndex].Value == null ? "" : dtgView[colIndex, rowIndex].Value.ToString();
                                if (_Value.Length > 0)
                                {
                                    if (_Value.Substring(0, 1) == "=")
                                        _Value = "'" + _Value;
                                }
                                xlWorkSheet.Cells[row, col] = _Value.Replace("\r\n", "\n");
                            }
                        }
                    }
                    if (_have_iscate == true)
                    {
                        if ((bool)dtgView["iscate", rowIndex].Value == true)
                        {
                            FormatSheet(xlWorkSheet, false, 2, 2, 11, "Arial", true, false, Color.Black, excel.Cells[row, 1], excel.Cells[row, col], false);
                        }
                    }
                }
                xlWorkSheet.Columns.AutoFit();
                xlWorkSheet.Rows.AutoFit();
                xlWorkSheet.get_Range(xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[dtgView.Rows.Count + 1, dtgView.Columns.Count - _col_invisible]).Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;

                excel.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                this.Close();
            }
            catch (Exception ex)
            {
                Error_Code error = new Error_Code();
                error.GetErr_Framework(ex, "Export Datagridview");
                this.Close();
            }
        }

        private void FormatSheet(COMExcel.Worksheet _exWorkSheet, bool _isMerge, int _HorizontalAlignment, int _VerticalAlignment, int _FontSize, string _FontName, bool _isBold, bool _isItalic, System.Drawing.Color _FontColor, object _startCell, object _endCell)
        {
            if (_isMerge == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).MergeCells = true;
            }
            _exWorkSheet.get_Range(_startCell, _endCell).HorizontalAlignment = _HorizontalAlignment;
            _exWorkSheet.get_Range(_startCell, _endCell).VerticalAlignment = _VerticalAlignment;
            _exWorkSheet.get_Range(_startCell, _endCell).Font.Name = _FontName;
            _exWorkSheet.get_Range(_startCell, _endCell).Font.Size = _FontSize;
            _exWorkSheet.get_Range(_startCell, _endCell).Font.Color = System.Drawing.ColorTranslator.ToOle(_FontColor);
            if (_isBold == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).Font.Bold = true;
            }
            if (_isItalic == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).Font.Italic = true;
            }
        }
        /// <summary>
        /// Format Sheet
        /// </summary>
        /// <param name="_exWorkSheet">COMExcel.WorkSheet</param>
        /// <param name="_isMerge"></param>
        /// <param name="_HorizontalAlignment">1: Trái - 2: Giữa - 3: Phải</param>
        /// <param name="_VerticalAlignment">1: Trái - 2: Giữa - 3: Phải</param>
        /// <param name="_FontSize"></param>
        /// <param name="_FontName"></param>
        /// <param name="_isBold"></param>
        /// <param name="_isItalic"></param>
        /// <param name="_FontColor"></param>
        /// <param name="_startCell">Truyền vào Cell</param>
        /// <param name="_endCell">Truyền vào Cell</param>
        /// <param name="_BoderCell">Đóng khung cell</param>
        private void FormatSheet(COMExcel.Worksheet _exWorkSheet, bool _isMerge, int _HorizontalAlignment, int _VerticalAlignment, int _FontSize, string _FontName, bool _isBold, bool _isItalic, System.Drawing.Color _FontColor, object _startCell, object _endCell, bool _BoderCell)
        {
            if (_isMerge == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).MergeCells = true;
            }
            _exWorkSheet.get_Range(_startCell, _endCell).HorizontalAlignment = _HorizontalAlignment;
            _exWorkSheet.get_Range(_startCell, _endCell).VerticalAlignment = _VerticalAlignment;
            _exWorkSheet.get_Range(_startCell, _endCell).Font.Name = _FontName;
            _exWorkSheet.get_Range(_startCell, _endCell).Font.Size = _FontSize;
            _exWorkSheet.get_Range(_startCell, _endCell).Font.Color = System.Drawing.ColorTranslator.ToOle(_FontColor);
            if (_BoderCell == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).Borders.LineStyle = COMExcel.XlLineStyle.xlContinuous;
            }
            if (_isBold == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).Font.Bold = true;
            }
            if (_isItalic == true)
            {
                _exWorkSheet.get_Range(_startCell, _endCell).Font.Italic = true;
            }
        }
        DateTime dtenable = DateTime.Now;
        TimeSpan ts;
        private void Perform_Percent(string _working)
        {
            ts = DateTime.Now - dtenable;
            proBar.Value++;
            lblStepWorking.Text = _working;
            lblTime.Text = ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            lblPercent.Text = ((int)(((double)proBar.Value / proBar.Maximum) * 100)).ToString() + " %";
        }
        private void FrmExportExcel_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xuất dữ liệu qua Excel ?", Warnings.CAPTION, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Thread exportT = new Thread(new ThreadStart(Check_Export));
                exportT.Priority = ThreadPriority.Highest;
                exportT.Start();
            }
            else
            {
                this.Close();
            }
        }
        private void Check_Export()
        {
            if (InvokeRequired)
            {
                if (dataExport is DataTable)
                {
                    proBar.Invoke(new MethodInvoker(delegate
                {
                    Export((DataTable)dataExport);

                }));
                }
                else if (dataExport is DataGridView)
                {
                    proBar.Invoke(new MethodInvoker(delegate
                 {
                     Export((DataGridView)dataExport);
                 }));
                }

            }
        }

    }
}