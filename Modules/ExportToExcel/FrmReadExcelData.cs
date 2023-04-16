using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using COMExcel = Microsoft.Office.Interop.Excel;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
namespace TPH.Excel
{
    public partial class FrmReadExcelData : Form
    {
        public FrmReadExcelData()
        {
            InitializeComponent();
        }
        public DataTable DataGetted { get; set; }
        public bool TextFileMode = false;
        private void btnReadFile_Click(object sender, EventArgs e)
        {
            CheckImportData();
        }
        private void CheckImportData()
        {
            if(!string.IsNullOrEmpty(txtPath.Text))
            {
                var fileInfo = new FileInfo(txtPath.Text);
                if(fileInfo.Extension == ".txt")
                {
                    ImportTxt(txtPath.Text);
                }
                else
                    Import(txtPath.Text);
            }
        }
        private void ImportTxt(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                CustomMessageBox.ShowAlert("Loading data....");
                TextFileMode = true;
                tabDataSheet.TabPages.Clear();
                DataTable dtDataImport = new DataTable();
                if (!string.IsNullOrEmpty(txtKyTuTachChuoi.Text))
                {
                    var fileContent = File.ReadAllLines(fileName);
                    int iCount = -1;
                    foreach (string line in fileContent)
                    {
                        iCount++;
                        var arr = line.Split(new string[] { txtKyTuTachChuoi.Text }, StringSplitOptions.None);
                        if (iCount == 0)
                        {
                            if (arr.Length > 0)
                            {
                                for (int c = 0; c < arr.Length; c++)
                                {
                                    dtDataImport.Columns.Add("Column" + c.ToString(), typeof(string));
                                    dtDataImport.Columns[c].Caption = string.Format("CỘT {0}", c);
                                }
                            }
                        }
                        DataRow dr = dtDataImport.NewRow();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            dr["Column" + i.ToString()] = arr[i];
                        }
                        dtDataImport.Rows.Add(dr);
                        dtDataImport.AcceptChanges();
                    }
                }
                TabPage tb = new TabPage();
                tb.Name = "TextData";
                tb.Text = "TextData";
                DataGridView dtg = new DataGridView();
                dtg.Name = string.Format("dtg{0}", tb.Name);
                tb.Controls.Add(dtg);
                dtg.Dock = DockStyle.Fill;
                dtg.DataSource = dtDataImport;
                tabDataSheet.TabPages.Add(tb);
                CustomMessageBox.CloseAlert();
            }
        }
        private void Import(string FileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(FileName))
                {
                    CustomMessageBox.ShowAlert("Đang nhập dữ liệu....");
                    tabDataSheet.TabPages.Clear();
                    TextFileMode = false;
                    Workbook wbook = new Workbook();
                    wbook.LoadDocument(FileName);
                    foreach (Worksheet exWorksheet in wbook.Worksheets)
                    {


                        CellRange range = exWorksheet.GetUsedRange();

                        DataTable dtDataImport = exWorksheet.CreateDataTable(range, true);
                        DataTableExporter exporter = exWorksheet.CreateDataTableExporter(range, dtDataImport, true);
                        exporter.CellValueConversionError += exporter_CellValueConversionError;
                        exporter.Options.ConvertEmptyCells = true;

                        exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = false;

                        exporter.Export();
                        CustomMessageBox.CloseAlert();
                        dtDataImport.AcceptChanges();

                        TabPage tb = new TabPage();
                        tb.Name = exWorksheet.Name;
                        tb.Text = exWorksheet.Name;
                        DataGridView dtg = new DataGridView();
                        dtg.Name = string.Format("dtg{0}", tb.Name);
                        BindingNavigator bv = new BindingNavigator(true);
                        bv.Name = string.Format("bv{0}", tb.Name);
                        bv.Items.RemoveByKey("bindingNavigatorDeleteItem");
                        bv.Items.RemoveByKey("bindingNavigatorAddNewItem");
                        bv.Items.RemoveByKey("bindingNavigatorSeparator2");
                        tb.Controls.Add(bv);
                        tb.Controls.Add(dtg);
                        dtg.BringToFront();
                        bv.Dock = DockStyle.Bottom;
                        dtg.Dock = DockStyle.Fill;
                        BindingSource bs = new BindingSource();
                        bs.DataSource = dtDataImport;
                        bv.BindingSource = bs;
                        dtg.DataSource = bs;
                        tabDataSheet.TabPages.Add(tb);
                        CustomMessageBox.CloseAlert();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.CloseAlert();
                CustomMessageBox.MSG_Waring_OK(ex.Message);
            }
        }

        private static void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            MessageBox.Show("Error in cell " + e.Cell.GetReferenceA1());
            e.DataTableValue = null;
            e.Action = DataTableExporterAction.Continue;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "Excel file (*.xls, *.xlsx) - Text file(*.txt)|*.xls;*.xlsx;*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = sfd.FileName;

                CheckImportData();
            }
        }

        private void txtPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                CheckImportData();
            }
        }
        private DataTable GetDataFromTab()
        {
            var dataResult = new DataTable();
            var tab = tabDataSheet.SelectedTab;
            var dtg = tab.Controls.Find(string.Format("dtg{0}", tab.Name), true)[0];
            if (dtg is DataGridView)
            {
                var dtgSource = (DataGridView)dtg;
                var dataSource = ((BindingSource)dtgSource.DataSource).DataSource as DataTable;
                //if (TextFileMode)
                //{
                dataResult = dataSource;
                //}
                //else
                //{
                //    var drHeader = dataSource.Rows[((int)numRowHeader.Value) - 1];
                //    foreach (var itm in drHeader.ItemArray)
                //    {
                //        dataResult.Columns.Add(itm.ToString().Trim(), typeof(string));
                //    }
                //    for (int i = (int)numRowHeader.Value; i < dataSource.Rows.Count; i++)
                //    {
                //        var dr = dataSource.Rows[i];
                //        var drnew = dataResult.NewRow();
                //        for (int y = 0; y < dataSource.Columns.Count; y++)
                //        {
                //            drnew[y] = dr[y];
                //        }
                //        dataResult.Rows.Add(drnew);
                //    }
                //    dataResult.AcceptChanges();
                //}
            }
            return dataResult;
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataGetted = GetDataFromTab();
            this.Close();
        }

        private void btnExportXML_Click(object sender, EventArgs e)
        {
            var data = GetDataFromTab();
            if (data != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "XML file|*.xml";
                saveFileDialog1.Title = "Save an XML file";
                saveFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    data.TableName = "ExportXML";
                    data.WriteXml(saveFileDialog1.FileName);
                }
            }
        }
    }
}
