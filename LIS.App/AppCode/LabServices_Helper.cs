using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.Controls;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Constants;
using Transitions;

namespace TPH.LIS.App.AppCode
{
    /// <summary>
    /// Lớp này chứa các hàm thường dùng kho code form
    /// </summary>
    public class LabServices_Helper
    {
        public static void gvMau_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            if (e.RowHandle > -1)
                return;
            else if (e.RowHandle != GridControl.InvalidRowHandle)
            {
                if (e.RowHeight < 35)
                    e.RowHeight = 35;
            }
        }
        private static readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        public LabServices_Helper() { }
        /// <summary>
        /// Hàm đọc tất cả máy in trong máy tính lên ListBox
        /// </summary>
        /// <param name="lstPrinter">ListBox</param>
        public static void LoadPrinterName(ListBox lstPrinter, string registryKey, bool isFormMain)
        {
            try
            {
                if (isFormMain)
                {
                    if (PrinterSettings.InstalledPrinters.Count > 0)
                    {
                        lstPrinter.Items.Clear();
                        foreach (string printerName in PrinterSettings.InstalledPrinters)
                        {
                            if (Printer_Ok(printerName))
                            {
                                lstPrinter.Items.Add(printerName);
                            }
                        }
                    }
                }
                else
                {
                    lstPrinter.Items.Clear();
                    lstPrinter.Items.AddRange(CommonAppVarsAndFunctions.LstPrinter.Items);
                    var totalPrinters = lstPrinter.Items.Count;
                    if (totalPrinters > 0)
                    {
                        var registryValue = _registryExtension.ReadRegistry(registryKey);

                        if (WorkingServices.IsNumeric(registryValue))
                        {
                            int index = string.IsNullOrEmpty(registryValue)
                                ? 0
                                : (int.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                            if (index < lstPrinter.Items.Count)
                            {
                                lstPrinter.SelectedIndex = string.IsNullOrEmpty(registryValue)
                                    ? 0
                                    : (int.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                            }
                            else
                            {
                                lstPrinter.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            lstPrinter.SelectedItem = registryValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "Load Printer", CommonAppVarsAndFunctions.UserID);
            }
        }

        public static void LoadPrinterNameNormal(ListBox lstPrinter, string registryKey, bool isNormalPrinter)
        {
            try
            {
                if (lstPrinter.InvokeRequired)
                {
                    lstPrinter.Invoke(new MethodInvoker(delegate { lstPrinter.Items.Clear(); }));
                }
                else
                    lstPrinter.Items.Clear();
                if (PrinterSettings.InstalledPrinters.Count > 0)
                {
                    foreach (string printerName in PrinterSettings.InstalledPrinters)
                    {
                        //if (Printer_Ok(printerName))
                        //{
                        if (isNormalPrinter)
                        {
                            var page = new PaperSize();
                            var settings = new PrinterSettings();
                            settings.PrinterName = printerName;
                            var ppSizes = settings.PaperSizes;
                            foreach (PaperSize pp in ppSizes)
                            {
                                if (pp.PaperName.Contains("A4") || pp.PaperName.Contains("Letter") || pp.PaperName.Contains("A5"))
                                {
                                    if (lstPrinter.InvokeRequired)
                                    {
                                        lstPrinter.Invoke(new MethodInvoker(delegate { lstPrinter.Items.Add(printerName); }));
                                    }
                                    else
                                        lstPrinter.Items.Add(printerName);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (lstPrinter.InvokeRequired)
                            {
                                lstPrinter.Invoke(new MethodInvoker(delegate { lstPrinter.Items.Add(printerName); }));
                            }
                            else
                                lstPrinter.Items.Add(printerName);
                        }

                        //}
                    }
                    if (lstPrinter.InvokeRequired)
                    {
                        lstPrinter.Invoke(new MethodInvoker(delegate
                        {
                            var totalPrinters = lstPrinter.Items.Count;
                            if (totalPrinters > 0)
                            {
                                var registryValue = _registryExtension.ReadRegistry(registryKey);

                                if (WorkingServices.IsNumeric(registryValue))
                                {
                                    int index = string.IsNullOrEmpty(registryValue)
                                        ? 0
                                        : (int.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                                    if (index < lstPrinter.Items.Count)
                                    {
                                        lstPrinter.SelectedIndex = string.IsNullOrEmpty(registryValue)
                                            ? 0
                                            : (int.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                                    }
                                    else
                                    {
                                        lstPrinter.SelectedIndex = 0;
                                    }
                                }
                                else
                                {
                                    lstPrinter.SelectedItem = registryValue;
                                }
                            }
                        }
                        ));
                    }
                    else
                    {
                        var totalPrinters = lstPrinter.Items.Count;
                        if (totalPrinters > 0)
                        {
                            var registryValue = _registryExtension.ReadRegistry(registryKey);

                            if (WorkingServices.IsNumeric(registryValue))
                            {
                                int index = string.IsNullOrEmpty(registryValue)
                                    ? 0
                                    : (int.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                                if (index < lstPrinter.Items.Count)
                                {
                                    lstPrinter.SelectedIndex = string.IsNullOrEmpty(registryValue)
                                        ? 0
                                        : (int.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                                }
                                else
                                {
                                    lstPrinter.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                lstPrinter.SelectedItem = registryValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "Load Printer", CommonAppVarsAndFunctions.UserID);
            }
        }
        //Show form in panel
        public static void ShowSubForm(Form frmCheck, Panel parentpanel, bool isReload)
        {
            if (parentpanel.Controls.Count > 0)
            {
                for (int i = 0; i < parentpanel.Controls.Count; i++)
                {
                    if (parentpanel.Controls[i].Name != "pn" + frmCheck.Name)
                    {
                        parentpanel.Controls[i].Visible = false;
                    }
                    else
                    {
                        if (isReload)
                        {
                            parentpanel.Controls.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            parentpanel.Controls[i].Visible = true;
                            parentpanel.Controls[i].BringToFront();
                            frmCheck.Dispose();
                            return;
                        }
                    }
                }
            }
            parentpanel.AutoScroll = true;
            frmCheck.TopLevel = false;
            Panel pnTemp = new Panel();
            parentpanel.Controls.Add(pnTemp);
            pnTemp.Dock = DockStyle.Fill;

            Panel pnS = new Panel();
            pnS.Name = "pn" + frmCheck.Name;
            pnS.Controls.Add(frmCheck);

            parentpanel.Controls.Add(pnS);
            frmCheck.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmCheck.Dock = DockStyle.Fill;
            frmCheck.Show();
            pnS.Dock = DockStyle.Fill;

            pnTemp.Visible = false;
            parentpanel.Controls.Remove(pnTemp);
        }

        private void Change_Panel_Show(Panel pnShow, Panel pnOld, Panel pnParent)
        {
            var t = new Transition(new TransitionType_EaseInEaseOut(700));
            pnOld.Dock = DockStyle.None;
            pnShow.Left = -pnShow.Width;
            pnShow.Dock = DockStyle.None;
            pnShow.Size = pnParent.Size;
            pnShow.Visible = true;
            t.add(pnShow, "Left", pnParent.Width / 2 - pnShow.Width / 2);
            t.add(pnOld, "Left", -pnOld.Width);
            t.run();
            pnOld = pnShow;
        }
        public static void SetControlColor(Control mainControl)
        {
            int DPIscale = GetWindowsScaling();
            foreach (Control item in mainControl.Controls)
            {
                if (item is ucGroupHeader)
                {
                    var obj = (ucGroupHeader)item;
                    obj.BackColor = CommonAppColors.ColorMainAppColor;
                    obj.ForeColor = CommonAppColors.ColorTextCaption;

                }
                else if (item is GridControl)
                {
                    var gc = (GridControl)item;
                    gc.LookAndFeel.UseDefaultLookAndFeel = false;
                    gc.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
                }
                else if (item is TPHNormalButton )
                {
                    if (item.BackColor == SystemColors.Control || item.BackColor == Color.FromArgb(204, 204, 204))
                    {
                        item.BackColor = CommonAppColors.ColorButtonBackColor;
                        item.ForeColor = CommonAppColors.ColorButtonForceColor;
                        var btn = (TPHNormalButton)item;
                        if(string.IsNullOrEmpty(btn.Text) && btn.Image != null)
                        {
                            btn.ImageAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                }
                if (item.Controls.Count >0)
                {
                    LabServices_Helper.SetControlColor(item);
                }
             //   SetFont(item, DPIscale);
            }
        }
        private static void SetFont(Control item, int DPIscale)
        {
            if (!string.IsNullOrEmpty(item.Text) && DPIscale > 100)
            {
                var font = new Font(item.Font.FontFamily, item.Font.Size - ((((float)DPIscale / 100) * item.Font.Size) - item.Font.Size), item.Font.Style);
                item.Font = font;
            }
        }
        public static int GetWindowsScaling()
        {
            return (int)Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LogPixels", 96);
            // return (int)(96 / (float)currentDPI);
        }
        private void Add_FormToPanel(Panel pnParent, Panel pnHold, FrmTemplate frm)
        {
            frm.pnLabel.Visible = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.ControlBox = false;
            frm.TopLevel = false;
            frm.Text = string.Empty;
            pnHold.Size = pnParent.Size;
            pnHold.Controls.Add(frm);
            pnHold.Dock = DockStyle.Fill;
            pnParent.Controls.Add(pnHold);
            frm.SendToBack();
            frm.Show();
            pnHold.Visible = false;
        }
        public static string Get_PrinterSelected(ListBox lst)
        {
            string printerName = string.Empty;
            if (lst.Items.Count > 0)
            {
                if (lst.SelectedIndex == -1)
                {
                    lst.SelectedIndex = 0;
                }
                printerName = lst.SelectedItem.ToString();
            }

            return printerName;
        }
        /// <summary>
        /// Hàm cắt đi dấu nháy trong chuổi
        /// </summary>
        /// <param name="inputStringConverter">Chuổi ký tự truyền vào</param>
        /// <returns>Chuổi ký tự trả về</returns>
        public static string ConvertString(string inputStringConverter)
        {
            //var result = string.Empty;
            //var totalChars = inputStringConverter.Length;
            //for (int i = 0; i < totalChars; i++)
            //{
            //    if (string.IsNullOrWhiteSpace(inputStringConverter[i].ToString()))
            //    {
            //        result += "''";
            //    }
            //    else
            //    {
            //        result += inputStringConverter[i].ToString();
            //    }
            //}

            return inputStringConverter.Trim().Replace("'", "''");
        }

        public static bool IsNumeric(string text)
        {
            return string.IsNullOrEmpty(text) ? false :
                    Regex.IsMatch(text, @"^\s*\-?\d+(\.\d+)?\s*$");
        }
        private static bool Printer_Ok(string printerName)
        {

            // Set management scope
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            string printerN = string.Empty;
            foreach (ManagementObject printer in searcher.Get())
            {
                printerN = printer["Name"].ToString();
                if (printerN.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                {
                    if (printer["WorkOffline"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
   
        /// <summary>
        /// Hàm ghi ra file log báo lỗi chương trình
        /// </summary>
        /// <param name="msg">Câu thông báo lỗi</param>
        public static void RecordError(string msg)
        {
            try
            {
                FileStream fs = new FileStream(@"Logs\Err_" + DateTime.Now.ToString("ddMMyy") + ".txt", FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);
                StreamWriter sw = new StreamWriter(fs);
                msg = "---------=====----------" + Environment.NewLine + msg;
                sw.WriteLine(msg);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

                return;
            }

        }
        public static void RecordError(string fileName, string msg)
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
        public static void RecordErrorXML(string fileName, string msg)
        {
            try
            {
                FileStream fs = new FileStream(@"Error\" + fileName + "_" + DateTime.Now.ToString("ddMMyy") + ".xml", FileMode.OpenOrCreate);
                fs.Seek(0, SeekOrigin.End);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(msg);
                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {

                return;
            }

        }
        /// <summary>
        /// Hàm định dạng font màu cột trên lưới
        /// </summary>
        /// <param name="dgvDataGridView">DataGridView</param>
        /// <param name="rowIndex">Row</param>
        /// <param name="cellIndex">Cell</param>
        /// <param name="_cForeColor">ForeColor</param>
        /// <param name="fontName">FontName</param>
        /// <param name="fontSize">Size</param>
        /// <param name="fontStyle">FontStyle</param>
        public static void FormatObjectGridView(
            DataGridView dgvDataGridView,
            int rowIndex,
            int cellIndex,
            Color foreColor,
            string fontName,
            int fontSize,
            FontStyle fontStyle)
        {
            dgvDataGridView.Rows[rowIndex].Cells[cellIndex].Style.ForeColor = foreColor;
            Font s = new Font(fontName, fontSize, fontStyle);
            DataGridViewCellStyle x = new DataGridViewCellStyle();
            x.Font = s;
            dgvDataGridView.Rows[rowIndex].DefaultCellStyle = x;
        }
        /// <summary>
        /// Hàm định dạng font màu cột trên lưới có canh lề
        /// </summary>
        /// <param name="dgvDataGridView">DataGridView</param>
        /// <param name="rowIndex">Row</param>
        /// <param name="cellIndex">Cell</param>
        /// <param name="foreColor">ForeColor</param>
        /// <param name="fontName">FontName</param>
        /// <param name="fontSize">Size</param>
        /// <param name="fontStyle">FontStyle</param>
        /// <param name="align">DataGridViewContentAlignment 1: MiddleLeft ; 2:MiddleRight; 3:MiddleCenter</param>
        public static void FormatObjectGridView_Cell(
            DataGridView dgvDataGridView,
            int rowIndex,
            int cellIndex,
            Color foreColor,
            string fontName,
            float fontSize,
            FontStyle fontStyle,
            int align,
            bool lockCell)
        {

            if (string.IsNullOrWhiteSpace(fontName))
            {
                fontName = dgvDataGridView.Font.Name;
            }
            if (fontSize == 0)
            {
                fontSize = dgvDataGridView.Font.Size;
            }

            Font s = new Font(fontName, fontSize, fontStyle);
            DataGridViewCellStyle x = new DataGridViewCellStyle();
            x.Font = s;
            if (align == 2)
            {
                x.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (align == 3)
            {
                x.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                x.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            x.ForeColor = foreColor;
            if (lockCell)
            {
                x.BackColor = Color.LightGray;
            }
            else
            {
                x.BackColor = Color.White;
            }
            dgvDataGridView.Rows[rowIndex].Cells[cellIndex].Style = x;
            dgvDataGridView.Rows[rowIndex].Cells[cellIndex].ReadOnly = lockCell;
            dgvDataGridView.AutoResizeRow(rowIndex);
        }

        public static void FormatObjectGridView_Cell(DataGridView dgvDataGridView, int _nRow, string _nCellName, Color _cForeColor,
   string _fontName, float _iSize, FontStyle _fontStyle, int _align)
        {
            dgvDataGridView.Rows[_nRow].Cells[_nCellName].Style.ForeColor = _cForeColor;
            if (_fontName == "")
            {
                _fontName = dgvDataGridView.Font.Name;
            }
            if (_iSize == 0)
            {
                _iSize = dgvDataGridView.Font.Size;
            }

            Font s = new Font(_fontName, _iSize, _fontStyle);
            DataGridViewCellStyle x = new DataGridViewCellStyle();
            x.Font = s;
            if (_align == 2)
            {
                x.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (_align == 3)
            {
                x.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            else
            {
                x.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            dgvDataGridView.Rows[_nRow].Cells[_nCellName].Style = x;
            dgvDataGridView.AutoResizeRow(_nRow);
        }
        public static void FormatObjectGridView(DataGridView dgvDataGridView, int _nRow, Color _cForeColor,
            string _fontName, int _iSize, FontStyle _fontStyle)
        {
            Font s = new Font(_fontName, _iSize, _fontStyle);
            DataGridViewCellStyle x = new DataGridViewCellStyle();
            x.Font = s;
            x.BackColor = _cForeColor;
            dgvDataGridView.Rows[_nRow].DefaultCellStyle = x;
            dgvDataGridView.AutoResizeRow(_nRow);
        }
        /// <summary>
        /// Hàm định dạng font màu cột trên lưới có canh lề
        /// </summary>
        /// <param name="dgvDataGridView">DataGridView</param>
        /// <param name="_nRow">Row</param>
        /// <param name="_cForeColor">ForeColor</param>
        /// <param name="_fontName">FontName</param>
        /// <param name="_iSize">Size</param>
        /// <param name="_fontStyle">FontStyle</param>
        /// <param name="_align">DataGridViewContentAlignment</param>
        public static void FormatObjectGridView_Row(DataGridView dgvDataGridView, int _nRow, Color _cForeColor,
            string _fontName, int _iSize, FontStyle _fontStyle, DataGridViewContentAlignment _align)
        {
            Font s = new Font(_fontName, _iSize, _fontStyle);
            DataGridViewCellStyle x = new DataGridViewCellStyle();
            x.Font = s;
            x.Alignment = _align;
            dgvDataGridView.Rows[_nRow].DefaultCellStyle = x;
            dgvDataGridView.Rows[_nRow].DefaultCellStyle.ForeColor = _cForeColor;
        }
        public static void FormatObjectGridView(DataGridView dgvDataGridView, int _nRow, int _nCell, Color _cForeColor, Color _cSelectionBackColor,
            string _fontName, int _iSize, FontStyle _fontStyle)
        {
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.ForeColor = _cForeColor;
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.SelectionBackColor = _cSelectionBackColor;
            Font s = new Font(_fontName, _iSize, _fontStyle);
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.Font = s;
        }
        public static void FormatObjectGridView(DataGridView dgvDataGridView, int _nRow, int _nCell, Color _cForeColor, Color _cSelectionBackColor,
            Color _cSelectionForeColor, string _fontName, int _iSize, FontStyle _fontStyle)
        {
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.ForeColor = _cForeColor;
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.SelectionBackColor = _cSelectionBackColor;
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.SelectionForeColor = _cSelectionForeColor;
            Font s = new Font(_fontName, _iSize, _fontStyle);
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.Font = s;
        }
        public static void FormatObjectGridView(DataGridView dgvDataGridView, int _nRow, int _nCell, Color _cForeColor,
            Color _cSelectionBackColor, Color _cSelectionForeColor, Color _cBackColor, string _fontName, int _iSize, FontStyle _fontStyle)
        {
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.ForeColor = _cForeColor;
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.SelectionBackColor = _cSelectionBackColor;
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.SelectionForeColor = _cSelectionForeColor;
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.BackColor = _cBackColor;
            Font s = new Font(_fontName, _iSize, _fontStyle);
            dgvDataGridView.Rows[_nRow].Cells[_nCell].Style.Font = s;
        }

        /// <summary>
        /// Hàm cho phép nhập giới tính
        /// 77: M 109: m
        /// 70: F 102: f
        /// 63: ? 8  : Backspace
        /// </summary>
        /// <param name="e"></param>
        public static void KeyPressGender(KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 77 && (int)e.KeyChar != 109 &&
                (int)e.KeyChar != 70 && (int)e.KeyChar != 102 &&
                (int)e.KeyChar != 63 && (int)e.KeyChar != 8)
                e.Handled = true;
        }

        /// <summary>
        /// Hàm cho phép nhập giới tính
        /// 77: M 109: m
        /// 70: F 102: f
        /// 97: a 65: A  8  : Backspace
        /// </summary>
        /// <param name="e"></param>
        public static void KeyPressGender_SieuAm(KeyPressEventArgs e)
        {
            if ((int)e.KeyChar != 77 && (int)e.KeyChar != 109 &&
                (int)e.KeyChar != 70 && (int)e.KeyChar != 102 &&
                (int)e.KeyChar != 97 && (int)e.KeyChar != 65 && (int)e.KeyChar != 8)
                e.Handled = true;
        }

        /// <summary>
        /// Hàm bẫy lỗi dữ liệu trên DataGridView
        /// </summary>
        /// <param name="e"></param>
        public static void DataError(DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            CustomMessageBox.MSG_Waring_OK("Lỗi dữ liệu, kiểm tra lại kiểu dữ liệu !");
        }

        public static void Bind_Data_ToControl(Object[] obj, BindingSource bs)
        {
            foreach (object subObj in obj)
            {
                CheckAndSetBindData(subObj, bs);
            }
        }
        /// <summary>
        /// Kiềm tra vào gán bind data cho các control theo thẻ tag đã gán trước.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bs"></param>
        public static void CheckAndSetBindData(object obj, BindingSource bs)
        {
            if (obj is TextBox)
            {
                TextBox txt = (TextBox)obj;
                string _binddata = txt.Tag.ToString();
                txt.DataBindings.Clear();
                txt.Text = "";
                txt.DataBindings.Add("Text", bs, _binddata);
                txt.AccessibleName = txt.Text;
                obj = txt;
            }
            else if (obj is Label)
            {
                ((Label)obj).DataBindings.Clear();
                ((Label)obj).Text = "";
                ((Label)obj).DataBindings.Add("Text", bs, ((Label)obj).Tag.ToString().Trim());
            }
            else if (obj is ComboBox || obj is CustomComboBox)
            {
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).DataBindings.Clear();
                    ((ComboBox)obj).SelectedIndex = -1;
                    ((ComboBox)obj).DataBindings.Add("SelectedValue", bs, ((ComboBox)obj).Tag.ToString().Trim(), true, DataSourceUpdateMode.Never, "");
                    if (((ComboBox)obj).SelectedIndex != -1)
                    {
                        ((ComboBox)obj).AccessibleName = ((ComboBox)obj).SelectedValue.ToString().Trim();
                    }
                    else
                    {
                        ((ComboBox)obj).AccessibleName = "";
                    }

                }
                else
                {
                    ((CustomComboBox)obj).DataBindings.Clear();
                    ((CustomComboBox)obj).SelectedIndex = -1;
                    ((CustomComboBox)obj).DataBindings.Add("SelectedValue", bs, ((CustomComboBox)obj).Tag.ToString().Trim(), true, DataSourceUpdateMode.Never, "");
                    if (((CustomComboBox)obj).SelectedIndex != -1)
                    {
                        ((CustomComboBox)obj).AccessibleName = ((CustomComboBox)obj).SelectedValue.ToString().Trim();
                    }
                    else
                    {
                        ((CustomComboBox)obj).AccessibleName = "";
                    }
                }
            }
            else if (obj is CheckBox)
            {
                ((CheckBox)obj).DataBindings.Clear();
                ((CheckBox)obj).Checked = false;
                ((CheckBox)obj).DataBindings.Add("Checked", bs, ((CheckBox)obj).Tag.ToString().Trim());
                ((CheckBox)obj).AccessibleName = ((CheckBox)obj).Checked.ToString();
            }
            else if (obj is RadioButton)
            {
                ((RadioButton)obj).DataBindings.Clear();
                ((RadioButton)obj).Checked = false;
                ((RadioButton)obj).DataBindings.Add("Checked", bs, ((RadioButton)obj).Tag.ToString().Trim());
                ((RadioButton)obj).AccessibleName = ((RadioButton)obj).Checked.ToString();
            }
            else if (obj is DateTimePicker)
            {

                ((DateTimePicker)obj).DataBindings.Clear();
                ((DateTimePicker)obj).DataBindings.Add("Value", bs, ((DateTimePicker)obj).Tag.ToString().Trim(), true, DataSourceUpdateMode.Never, DateTime.Now);
                ((DateTimePicker)obj).AccessibleName = ((DateTimePicker)obj).Value.ToString();
            }
        }


        /// <summary>
        /// Reset các control
        /// </summary>
        /// <param name="obj"></param>
        public static void ResetControl(object[] objIn)
        {
            foreach (object obj in objIn)
            {
                if (obj is TextBox)
                {
                    TextBox txt = (TextBox)obj;
                    txt.DataBindings.Clear();
                    txt.Text = "";
                    txt.AccessibleName = "";
                }
                else if (obj is Label)
                {
                    ((Label)obj).DataBindings.Clear();
                    ((Label)obj).Text = "";
                }
                else if (obj is ComboBox || obj is CustomComboBox)
                {
                    if (obj is ComboBox)
                    {
                        ((ComboBox)obj).DataBindings.Clear();
                        ((ComboBox)obj).SelectedIndex = -1;
                    }
                    else
                    {
                        ((CustomComboBox)obj).DataBindings.Clear();
                        ((CustomComboBox)obj).SelectedIndex = -1;

                    }
                }
                else if (obj is CheckBox)
                {
                    ((CheckBox)obj).DataBindings.Clear();
                    ((CheckBox)obj).Checked = false;
                }
                else if (obj is RadioButton)
                {
                    ((RadioButton)obj).DataBindings.Clear();
                }
                else if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).DataBindings.Clear();
                    ((DateTimePicker)obj).Value = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Check changed value for control
        /// </summary>
        /// <param name="objIn"></param>
        public static bool Check_ChangedValue_Control(object[] objIn, Control control)
        {
            foreach (object obj in objIn)
            {
                if (((Control)obj).Name == control.Name)
                {
                    if (obj is TextBox)
                    {
                        TextBox txt = (TextBox)obj;
                        if (txt.AccessibleName != null)
                        {

                            if (txt.Text.Trim() != txt.AccessibleName.ToString().Trim())
                            {
                                txt.AccessibleName = txt.Text.Trim();
                                return true;
                            }
                        }
                        else
                        {
                            if (txt.Text.Trim() != "")
                            {
                                txt.AccessibleName = txt.Text.Trim();
                                return true;
                            }
                        }
                    }
                    else if (obj is Label)
                    {
                        Label lbl = ((Label)obj);
                        if (lbl.AccessibleName != null)
                        {
                            if (lbl.Text.Trim() != lbl.AccessibleName.ToString().Trim())
                            {
                                lbl.AccessibleName = lbl.Text.Trim();
                                return true;
                            }
                        }
                        else
                        {
                            if (lbl.Text.Trim() != "")
                            {
                                lbl.AccessibleName = lbl.Text.Trim();
                                return true;
                            }
                        }

                    }
                    else if (obj is ComboBox || obj is CustomComboBox)
                    {
                        if (obj is ComboBox)
                        {
                            ComboBox cbo = ((ComboBox)obj);
                            if (cbo.AccessibleName != null)
                            {
                                //Nếu selectedindex khác -1 thì kiểm tra giá trị chọn
                                if (cbo.SelectedIndex != -1)
                                {
                                    if (cbo.SelectedValue.ToString().Trim() != cbo.AccessibleName.ToString().Trim())
                                    {
                                        cbo.AccessibleName = cbo.SelectedValue.ToString();
                                        return true;
                                    }
                                }
                                //Nếu selectindex là -1 thì coi như giá trị chọn là ""
                                else if (cbo.AccessibleName.ToString().Trim() != "")
                                {
                                    cbo.AccessibleName = "";
                                    return true;
                                }
                            }
                            else
                            {
                                if (cbo.SelectedIndex != -1)
                                {
                                    cbo.AccessibleName = cbo.SelectedValue.ToString();
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            CustomComboBox cbo = ((CustomComboBox)obj);
                            if (cbo.AccessibleName != null)
                            {
                                //Nếu selectedindex khác -1 thì kiểm tra giá trị chọn
                                if (cbo.SelectedIndex != -1)
                                {
                                    if (cbo.SelectedValue.ToString().Trim() != cbo.AccessibleName.ToString().Trim())
                                    {
                                        cbo.AccessibleName = cbo.SelectedValue.ToString();
                                        return true;
                                    }
                                }
                                //Nếu selectindex là -1 thì coi như giá trị chọn là ""
                                else if (cbo.AccessibleName.ToString().Trim() != "")
                                {
                                    cbo.AccessibleName = "";
                                    return true;
                                }
                            }
                            else
                            {
                                if (cbo.SelectedIndex != -1)
                                {
                                    cbo.AccessibleName = cbo.SelectedValue.ToString();
                                    return true;
                                }
                            }
                        }
                    }
                    else if (obj is CheckBox || obj is RadioButton)
                    {
                        //Nếu là check box hoặc radio button thì luôn có sự thay đổi
                        //Nhớ đặt kiểm tra sự thay đổi trogn sự kiện click hoặc checked change
                        //Do control chỉ có thuộc tính true hoặc false
                        return true;
                    }
                    else if (obj is DateTimePicker)
                    {
                        DateTimePicker dtp = ((DateTimePicker)obj);
                        if (dtp.AccessibleName != null)
                        {
                            if (dtp.Value.ToString() != dtp.AccessibleName.ToString())
                            {
                                dtp.AccessibleName = dtp.Value.ToString();
                                return true;
                            }
                        }
                        else if (dtp.Enabled == true)
                        {
                            return true;
                        }
                    }

                    //Nếu đúng control cần kiềm tra mà không thấy sự thay đổi thì trả về false
                    return false;
                }
            }
            //Nếu hết vòng lập mà không thấy control cần tìm thì trả về ghi log lại và trả về false
            RecordError("Control_CheckChanged", "Not in list check" + Environment.NewLine + "Control Name: " + control.Name);
            return false;
        }
        /// <summary>
        /// Hàm trả về chuỗi giới tính
        /// </summary>
        /// <param name="sex">Truyền vào mã giới tính</param>
        /// <returns>Trả về giới tính</returns>
        public static string GetSexToLable(string sex)
        {
            string sexCaption;
            if (sex.Equals("M", StringComparison.OrdinalIgnoreCase))
                sexCaption = "Nam";
            else if (sex.Equals("F", StringComparison.OrdinalIgnoreCase))
                sexCaption = "Nữ";
            else
                sexCaption = "Chưa rõ";

            return sexCaption;
        }
        /// <summary>
        /// Hàm Load image lên PictureBox
        /// </summary>
        /// <param name="pbx">Đối tượng PictureBox</param>
        /// <param name="s">Chuỗi Binary</param>
        public static void LoadImage(PictureBox pbx, string s)
        {
            try
            {
                byte[] bArr = BinaryToString.FromBase64(s);
                ImageConverter imc = new ImageConverter();
                pbx.Image = (Image)imc.ConvertFrom(bArr);
            }
            catch
            {
                pbx.Image = null;
            }
        }
        /// <summary>
        /// Hàm Load image lên PictureBox
        /// </summary>
        /// <param name="pbx">Đối tượng PictureBox</param>
        /// <param name="s">Chuỗi Binary</param>
        public static void LoadImage(PictureBox pbx, object image)
        {
            try
            {
                //byte[] bArr = BinaryToString.FromBase64(s);
                //byte[] bArr = b;
                ImageConverter imc = new ImageConverter();
                pbx.Image = (Image)imc.ConvertFrom(image);
            }
            catch
            {
                pbx.Image = null;
            }
        }
        public static void Load_Image(PictureBox pb)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file (*.Bmp,*.Jpg,*.Gif)|*.Bmp;*.Jpg;*.Gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb.Image = Image.FromFile(ofd.FileName);
                ofd.Dispose();
            }
        }

        public static void Load_Image(PictureBox pb, float NewWidth, float NewHeight)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file (*.Bmp,*.Jpg,*.Gif)|*.Bmp;*.Jpg;*.Gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pb.Image = ResizeWithSameRatio(Image.FromFile(ofd.FileName), NewWidth, NewHeight);
                ofd.Dispose();
            }
        }
        //Resize Image
        public static Image ResizeWithSameRatio(Image image, float Newwidth, float Newheight)
        {
            // the colour for letter boxing, can be a parameter
            var brush = new SolidBrush(Color.Transparent);

            // target scaling factor
            float scale = Math.Min(Newwidth / image.Width, Newheight / image.Height);

            // target image
            var bmp = new Bitmap((int)Newwidth, (int)Newheight);
            var graph = Graphics.FromImage(bmp);

            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);

            // fill the background and then draw the image in the 'centre'
            graph.FillRectangle(brush, new RectangleF(0, 0, Newwidth, Newheight));
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graph.DrawImage(image, new Rectangle(((int)Newwidth - scaleWidth) / 2, ((int)Newheight - scaleHeight) / 2, scaleWidth, scaleHeight));

            return bmp;
        }
        static byte[] bBff;
        /// <summary>
        /// Hàm đọc file ảnh lên PictureBox và dịch ra Binary
        /// </summary>
        /// <param name="pbx"></param>
        /// <returns></returns>
        public static byte[] BufferBinary(PictureBox pbx)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file (*.Bmp,*.Jpg,*.Gif)|*.Bmp;*.Jpg;*.Gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbx.Image = Image.FromFile(ofd.FileName);
                bBff = new byte[0];
                ImageConverter ic = new ImageConverter();
                bBff = (byte[])ic.ConvertTo(pbx.Image, bBff.GetType());
            }
            return bBff;
        }

        public static byte[] BufferBinaryNotOpenfile(PictureBox pbx)
        {
            bBff = new byte[0];
            ImageConverter ic = new ImageConverter();
            bBff = (byte[])ic.ConvertTo(pbx.Image, bBff.GetType());
            return bBff;
        }
        public static byte[] BufferBinaryNotOpenfile(Image img)
        {
            bBff = new byte[0];
            ImageConverter ic = new ImageConverter();
            bBff = (byte[])ic.ConvertTo(img, bBff.GetType());
            return bBff;
        }
        /// <summary>
        /// Hàm di chuyển control sang control khác khi nhấn enter
        /// </summary>
        /// <param name="e">KeyPressEventArgs Event e</param>
        /// <param name="_controlNext">Control Object</param>
        public static void LeaveFocusNext(KeyPressEventArgs e, Control _controlNext, Control _controlBack, Control _currentControl)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _controlNext.Focus();
                if (_controlNext is CustomComboBox)
                {
                    ((CustomComboBox)_controlNext).DroppedDown = true;
                }
                else if (_controlNext is TextBox)
                {
                    ((TextBox)_controlNext).SelectAll();
                }
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Up)
            {
                _controlBack.Focus();
                if (_currentControl is CustomComboBox)
                {
                    if (((CustomComboBox)_currentControl).Text != "")
                    {
                        return;
                    }
                }
                if (_controlBack is CustomComboBox)
                {
                    ((CustomComboBox)_controlBack).DroppedDown = true;
                }
                else if (_controlBack is TextBox)
                {
                    ((TextBox)_controlBack).SelectAll();
                }
                e.Handled = true;
            }

        }
        public static void LeaveFocusUpDown(KeyEventArgs e, Control _ControlBack, Control _ControlNext, Control _currentControl, Control _ControlBackForDisable, Control _ControlNextForDisable)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (_ControlBack.Enabled)
                {
                    LeaveFocusUpDown(e, _ControlBack, _ControlNext, _currentControl);
                }
                else
                {
                    LeaveFocusUpDown(e, _ControlBackForDisable, _ControlNext, _currentControl);
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (_ControlNext.Enabled)
                {
                    LeaveFocusUpDown(e, _ControlBack, _ControlNext, _currentControl);
                }
                else
                {
                    LeaveFocusUpDown(e, _ControlBack, _ControlNextForDisable, _currentControl);
                }
            }
        }
        public static void LeaveFocusUpDown(KeyEventArgs e, Control _ControlBack, Control _ControlNext, Control _currentControl)
        {
            if (e.KeyCode == Keys.Up)
            {

                if (_currentControl is CustomComboBox || _currentControl is ComboBox)
                {
                    return;
                }
                else
                {
                    _ControlBack.Focus();
                    if (_ControlBack is CustomComboBox)
                    {
                        ((CustomComboBox)_ControlBack).DroppedDown = true;
                    }
                    else if (_ControlBack is TextBox)
                    {
                        if (((TextBox)_ControlBack).Multiline == false)
                        {
                            ((TextBox)_ControlBack).SelectAll();
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (_currentControl is CustomComboBox || _currentControl is ComboBox)
                {
                    return;
                }
                else
                {
                    _ControlNext.Focus();
                    if (_ControlNext is CustomComboBox)
                    {
                        ((CustomComboBox)_ControlNext).DroppedDown = true;
                    }
                    else if (_ControlNext is TextBox)
                    {
                        if (((TextBox)_ControlNext).Multiline == false)
                        {
                            ((TextBox)_ControlNext).SelectAll();
                        }
                    }
                }
            }
        }

        public static void LeaveFocusNext(KeyPressEventArgs e, Control _controlNext, Control _ControlNextForDisable)
        {
            if (_controlNext.Enabled)
            {
                LeaveFocusNext(e, _controlNext);
            }
            else
            {
                LeaveFocusNext(e, _ControlNextForDisable);
            }
        }
        public static void LeaveFocusNext(KeyPressEventArgs e, Control _controlNext)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                _controlNext.Focus();
                if (_controlNext is CustomComboBox)
                {
                    ((CustomComboBox)_controlNext).DroppedDown = true;
                }
                else if (_controlNext is TextBox)
                {
                    if (((TextBox)_controlNext).Multiline == false)
                    {
                        ((TextBox)_controlNext).SelectAll();
                    }
                }
                e.Handled = true;
            }
        }
        public static bool IsKeyEnter(KeyPressEventArgs e)
        {
            return e.KeyChar == (char)Keys.Enter;
        }
        /// <summary>
        /// Tạo nhấp nháy trên button
        /// </summary>
        /// <param name="c"></param>
        /// <param name="f"></param>
        public static void Action(Control c, bool f)
        {
            f = !f;
            if (f == false)
            {
                c.BackColor = Color.BlueViolet;
            }
            else
            {
                c.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Hàm doubel click Header to Frozen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static bool b;
        public static void FrozenGridView(DataGridView dgv, DataGridViewCellMouseEventArgs e)
        {
            b = !b;
            if (b)
                dgv.Columns[e.ColumnIndex].Frozen = true;
            else
                dgv.Columns[e.ColumnIndex].Frozen = false;
        }
        private static int _age;
        public static int ConvertBirthYear(string _number)
        {
            if (string.IsNullOrEmpty(_number)) _age = 0;
            if (int.Parse(_number) < 1000 && int.Parse(_number) != 0)
                _age = DateTime.Now.Year - int.Parse(_number);
            else
                _age = int.Parse(_number);
            return _age;
        }
        public static bool IsNumeric(object o)
        {
            if (o is IConvertible)
            {
                TypeCode tc = ((IConvertible)o).GetTypeCode();
                if (TypeCode.Char <= tc && tc <= TypeCode.Decimal)
                    return true;
            }
            return false;
        }
        public static DataTable DataTable_DistinctValue(DataTable dtSource, string _sortColumn, string[] _coloumns)
        {
            DataView view = new DataView(dtSource);
            if (!string.IsNullOrEmpty(_sortColumn))
                view.Sort = _sortColumn + " asc";
            return view.ToTable(true, _coloumns);
        }
        public static DataTable DataTable_DistinctValue(DataTable dtSource, string _coloumn)
        {
            DataView view = new DataView(dtSource);
            return view.ToTable(true, _coloumn);
        }

        public static DataTable DataTable_DistinctValue(DataTable dtSource, string[] _coloumn)
        {
            DataView view = new DataView(dtSource);
            return view.ToTable(true, _coloumn);
        }

        public static DataTable DataTable_DistinctValue(DataTable dtSource, string _sortColumn, string _coloumn1, string _column2)
        {
            DataView view = new DataView(dtSource);
            view.Sort = _sortColumn + " asc";
            return view.ToTable(true, _coloumn1, _column2);
        }

        public static void Set_Event_Focus(object _enterobject)
        {
            if (_enterobject is TextBox)
            {
                TextBox txt = (TextBox)_enterobject;
                txt.Enter += new EventHandler(SetColor_Enter);
                txt.Leave += new EventHandler(SetColor_Leave);
            }
            else if (_enterobject is CheckBox)
            {
                CheckBox chk = (CheckBox)_enterobject;
                chk.Enter += new EventHandler(SetColor_Enter);
                chk.Leave += new EventHandler(SetColor_Leave);
            }
            else if (_enterobject is RadioButton)
            {
                RadioButton rad = (RadioButton)_enterobject;
                rad.Enter += new EventHandler(SetColor_Enter);
                rad.Leave += new EventHandler(SetColor_Leave);
            }
            else if (_enterobject is CustomComboBox)
            {
                CustomComboBox cbo = (CustomComboBox)_enterobject;
                cbo.Enter += new EventHandler(SetColor_Enter);
                cbo.Leave += new EventHandler(SetColor_Leave);
            }
            else if (_enterobject is ComboBox)
            {
                ComboBox cbo = (ComboBox)_enterobject;
                cbo.Enter += new EventHandler(SetColor_Enter);
                cbo.Leave += new EventHandler(SetColor_Leave);
            }
            else if (_enterobject is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)_enterobject;
                dtp.Enter += new EventHandler(SetColor_Enter);
                dtp.Leave += new EventHandler(SetColor_Leave);
            }
            else if (_enterobject is RicherTextBox.RicherTextBox)
            {
                RicherTextBox.RicherTextBox dtp = (RicherTextBox.RicherTextBox)_enterobject;
                dtp.Enter += new EventHandler(SetColor_Enter);
                dtp.Leave += new EventHandler(SetColor_Leave);
            }
        }
        public static void SetColor_Enter(object _enterobject, EventArgs e)
        {
            if (_enterobject is TextBox)
            {
                TextBox txt = (TextBox)_enterobject;
                txt.BackColor = Color.Cornsilk;
                txt.SelectAll();
            }
            else if (_enterobject is CheckBox)
            {
                CheckBox chk = (CheckBox)_enterobject;
                chk.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is RadioButton)
            {
                RadioButton rad = (RadioButton)_enterobject;
                rad.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is CustomComboBox)
            {
                CustomComboBox cbo = (CustomComboBox)_enterobject;
                cbo.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is ComboBox)
            {
                ComboBox cbo = (ComboBox)_enterobject;
                cbo.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)_enterobject;
                dtp.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is RicherTextBox.RicherTextBox)
            {
                RicherTextBox.RicherTextBox dtp = (RicherTextBox.RicherTextBox)_enterobject;
                dtp.BackColor = Color.Cornsilk;
            }
        }
        public static void SetColor_Leave(object _enterobject, EventArgs e)
        {
            if (_enterobject is TextBox)
            {
                TextBox txt = (TextBox)_enterobject;
                txt.BackColor = Color.White;
            }
            else if (_enterobject is CheckBox)
            {
                CheckBox chk = (CheckBox)_enterobject;
                chk.BackColor = Color.Transparent;
            }
            else if (_enterobject is RadioButton)
            {
                RadioButton rad = (RadioButton)_enterobject;
                rad.BackColor = Color.Transparent;
            }
            else if (_enterobject is CustomComboBox)
            {
                CustomComboBox cbo = (CustomComboBox)_enterobject;
                cbo.BackColor = Color.White;
            }
            else if (_enterobject is ComboBox)
            {
                ComboBox cbo = (ComboBox)_enterobject;
                cbo.BackColor = Color.White;
            }
            else if (_enterobject is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)_enterobject;
                dtp.BackColor = Color.White;
            }
            else if (_enterobject is RicherTextBox.RicherTextBox)
            {
                RicherTextBox.RicherTextBox dtp = (RicherTextBox.RicherTextBox)_enterobject;
                dtp.BackColor = Color.White;
            }
        }
        public static void SetColor_Enter(ref object _enterobject)
        {
            if (_enterobject is TextBox)
            {
                TextBox txt = (TextBox)_enterobject;
                txt.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is CheckBox)
            {
                CheckBox chk = (CheckBox)_enterobject;
                chk.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is CustomComboBox)
            {
                CustomComboBox cbo = (CustomComboBox)_enterobject;
                cbo.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is ComboBox)
            {
                ComboBox cbo = (ComboBox)_enterobject;
                cbo.BackColor = Color.Cornsilk;
            }
            else if (_enterobject is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)_enterobject;
                dtp.BackColor = Color.Cornsilk;
            }
        }
        public static void SetColor_Leave(ref object _enterobject)
        {
            if (_enterobject is TextBox)
            {
                TextBox txt = (TextBox)_enterobject;
                txt.BackColor = Color.White;
            }
            else if (_enterobject is CheckBox)
            {
                CheckBox chk = (CheckBox)_enterobject;
                chk.BackColor = Color.Transparent;
            }
            else if (_enterobject is CustomComboBox)
            {
                CustomComboBox cbo = (CustomComboBox)_enterobject;
                cbo.BackColor = Color.White;
            }
            else if (_enterobject is ComboBox)
            {
                ComboBox cbo = (ComboBox)_enterobject;
                cbo.BackColor = Color.White;
            }
            else if (_enterobject is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)_enterobject;
                dtp.BackColor = Color.White;
            }
        }


        public static void BindContex(SqlDataAdapter da,
            ref DataTable dt, string _strSQL, ref DataGridView dtg, ref BindingNavigator bv)
        {
            DataProvider.SelInsUpdDelODBC(da, _strSQL, dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bv.BindingSource = bs;
            dtg.AutoGenerateColumns = false;
            dtg.DataSource = bs;

        }
        public static void BindContex(SqlDataAdapter da, ref DataTable dt, string _strSQL, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref BindingNavigator bv)
        {
            DataProvider.SelInsUpdDelODBC(da, _strSQL, dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bv.BindingSource = bs;
            dtg.AutoGenerateColumns = false;
            dtg.DataSource = bs;

        }
        public static void BindToGrid(DataTable dt, ref DataGridView dtg, ref BindingNavigator bv)
        {
            BindingSource bs = new BindingSource();
            dtg.AutoGenerateColumns = false;
            bs.DataSource = dt;
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }
        public static void BindToGrid(DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref BindingNavigator bv)
        {
            BindingSource bs = new BindingSource();
            dtg.AutoGenerateColumns = false;
            bs.DataSource = dt;
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }

        //Custom
        public static void BindContex(SqlDataAdapter da, ref DataTable dt, string _strSQL, ref DataGridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            DataProvider.SelInsUpdDelODBC(da, _strSQL, dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bv.BindingSource = bs;
            dtg.AutoGenerateColumns = false;
            dtg.DataSource = bs;

        }
        public static void BindToGrid(
            DataTable dt,
            ref DataGridView dtg,
            ref TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            BindingSource bs = new BindingSource();
            dtg.AutoGenerateColumns = false;
            bs.DataSource = dt;
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }
        public static void BindToGrid(DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg,
            ref TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            BindingSource bs = new BindingSource();
            dtg.AutoGenerateColumns = false;
            bs.DataSource = dt;
            bv.BindingSource = bs;
            dtg.DataSource = bs;

        }

        public static void BindToGrid(DataTable dt, ref DataGridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, bool _AutoGenerateColumns)
        {
            BindingSource bs = new BindingSource();
            dtg.AutoGenerateColumns = _AutoGenerateColumns;
            bs.DataSource = dt;
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }
        public static void BindToGrid(DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, bool _AutoGenerateColumns)
        {
            BindingSource bs = new BindingSource();
            dtg.AutoGenerateColumns = _AutoGenerateColumns;
            bs.DataSource = dt;
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }



        public static void ColumnToArry(DataTable dt, string _columnName, ref string[] _array)
        {
            _array = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _array[i] = dt.Rows[i][_columnName].ToString();
            }
        }
        public static void Select_Row(DataGridView dtg, BindingNavigator bv, string _ColumnFind, string _FindString)
        {
            if (dtg.RowCount > 0)
            {
                int a = 0;
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    string _CompareText = dtg[_ColumnFind, i].Value.ToString().Trim();
                    if (_FindString.ToLower().Trim().Equals(_CompareText.ToLower()))
                    {
                        a = i;
                        break;
                    }
                    a = 0;
                }
                bv.BindingSource.Position = a;
            }
        }
        public static void Filter_BindingSource(DataGrid dtg, BindingNavigator bv, DataTable dtSource, string _ColumnSearch, string _SearchValue)
        {
            _SearchValue = Utils.ConvertString(_SearchValue.ToLower());
            BindingSource bs = new BindingSource();
            bs.DataSource = dtSource;
            bs.Filter = _ColumnSearch + " like '%" + _SearchValue + "' OR " + _ColumnSearch + " like '" + _SearchValue + "%'";
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }
        public static void Filter_BindingSource(TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv, DataTable dtSource, string _ColumnSearch, object _SearchValue)
        { BindingSource bs = new BindingSource();
            bs.DataSource = dtSource;
            if (_SearchValue is string)
            {
                string _value = Utils.ConvertString(((string)_SearchValue).ToLower());
                bs.Filter = _ColumnSearch + " like '%" + _value + "%' OR " + _ColumnSearch + " like '" + _value + "%'";
            }
            else if (_SearchValue is bool)
            {
                bool _value = (bool)_SearchValue;
                bs.Filter = _ColumnSearch + " = " + (true ? "True" : "False");
            }
            dtg.DataSource = bs;
            bv.BindingSource = bs;
        }
        public static bool Check_NotExits(string _strSQL)
        {
            if (DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        public static void CreateDataTable(ref DataTable dt, string[] _Name, string[] _CapTion, string[] _type)
        {
            for (int i = 0; i < _Name.Length; i++)
            {
                DataColumn col = new DataColumn();
                col.ColumnName = _Name[i];
                col.Caption = _CapTion[i];
                if (_type[i].ToLower() == "datetime")
                {
                    col.DataType = typeof(DateTime);
                }
                else if (_type[i].ToLower() == "int")
                {
                    col.DataType = typeof(int);
                }
                else if (_type[i].ToLower() == "long")
                {
                    col.DataType = typeof(long);
                }
                else if (_type[i].ToLower() == "double")
                {
                    col.DataType = typeof(double);
                }
                else if (_type[i].ToLower() == "bool")
                {
                    col.DataType = typeof(bool);
                }
                else
                    col.DataType = typeof(string);

                dt.Columns.Add(col);
            }
        }

        public static void ConvertTest_Result(DataTable dtSource, ref DataTable dtResult, ref DataGridView dtg, string[] _Name
            , string _colID, string _colTestNameSource, string _colResultNameSource, string _colCategoryNameSource, string _colTestCode
            , string _colTestNameResult, string _colTestResultName, bool _LayChiDinh, bool _dangCot, string sortColumns
            ,ref string[] CategoryHeaderName, ref int[] CategoryHeaderColumnIndexStart,ref int[] CategoryHeaderColumnIndexEnd, bool headerBytestname, bool baocaoKetqua)
        {
            if (dtSource.Rows.Count > 0)
            {
                DataTable dt = dtSource.Copy();
                DataRow dr = dtResult.NewRow();
                string _cID = "", _cKetQuavaTen = "", _cKetQua = "", _cNhomketQua = "";
                int j = 0;
                string currentCategoryName = string.Empty;
                int currentArrayIndex = -1;
                int currentEndingIndex = -1;
                //Tính toán bổ sung cho dạng cột
                if (_dangCot)
                {
                    DataTable dtDistinct = DataTable_DistinctValue(dt, sortColumns, new string[] { _colTestCode, _colTestNameSource, _colCategoryNameSource });
                    DataTable dtCategory = DataTable_DistinctValue(dtDistinct, _colCategoryNameSource, new string[] { _colCategoryNameSource });
                    CategoryHeaderName = new string[dtCategory.Rows.Count];
                    CategoryHeaderColumnIndexStart = new int[dtCategory.Rows.Count];
                    CategoryHeaderColumnIndexEnd = new int[dtCategory.Rows.Count];

                    for (int r = 0; r < dtCategory.Rows.Count; r++)
                    {
                        CategoryHeaderName[r] = dtCategory.Rows[r]["TenNhomCLS"].ToString();
                    }

                    for (int b = _Name.Length; b < dtg.Columns.Count; b++)
                    {
                        dtg.Columns.RemoveAt(b);
                    }

                    dtResult.Columns.Remove(_colTestNameResult);
                    dtResult.AcceptChanges();
                    var columnName = string.Empty;
                    var columNanmeData = string.Empty;
                    for (int a = 0; a < dtDistinct.Rows.Count; a++)
                    {
                        columnName = StringConverter.ToString(dtDistinct.Rows[a][_colTestCode]);
                        columNanmeData = string.Format("[{0}]", columnName);

                        if (!string.IsNullOrEmpty(columnName) && !dtResult.Columns.Contains(columNanmeData))
                        {
                            dtResult.Columns.Add(columNanmeData, typeof(string));
                            dtResult.Columns[columNanmeData].Caption = columnName;

                            dtg.Columns.Add(columnName, columnName);
                            dtg.Columns[columnName].DataPropertyName = columNanmeData;
                            if (headerBytestname)
                              dtg.Columns[columnName].HeaderText = dtDistinct.Rows[a][_colTestNameSource].ToString().Trim();
                            else
                            {
                                var arrC = columnName.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arrC.Length > 1)
                                {
                                    var header = string.Empty;
                                    for (int i = 1; i < arrC.Length; i++)
                                        header += (string.IsNullOrEmpty(header) ? "" : "_") + arrC[i];

                                    dtg.Columns[columnName].HeaderText = header;
                                }
                                else
                                    dtg.Columns[columnName].HeaderText = columnName;
                            }

                            currentEndingIndex = dtg.Columns[columnName].Index;

                            if (!currentCategoryName.Equals(dtDistinct.Rows[a][_colCategoryNameSource].ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                currentCategoryName = dtDistinct.Rows[a][_colCategoryNameSource].ToString().Trim();
                                var cateIndex = FindIndexInArry(CategoryHeaderName, currentCategoryName);

                                CategoryHeaderColumnIndexEnd[cateIndex] = CategoryHeaderColumnIndexStart[cateIndex] = currentEndingIndex;

                                if (currentArrayIndex > -1)
                                    CategoryHeaderColumnIndexEnd[currentArrayIndex] = dtg.Columns[columnName].Index - 1;
                                currentArrayIndex = cateIndex;
                            }

                            CategoryHeaderColumnIndexEnd[currentArrayIndex] = currentEndingIndex;
                        }

                    }
                }
                else
                {
                    for (int b = _Name.Length; b < dtg.Columns.Count; b++)
                    {
                        dtg.Columns.RemoveAt(b);
                    }
                    //dtg.Columns.Add(_colTestNameResult, "Xét nghiệm chỉ định");
                    //dtg.Columns[_colTestNameResult].DataPropertyName = _colTestNameResult;
                    //dtg.Columns[_colTestNameResult].Width = 300;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        dr = dtResult.NewRow();
                    }

                    _cID = dt.Rows[i][_colID].ToString().Trim().ToLower(); ;
                    _cKetQuavaTen = "";
                    _cKetQua = "";
                    _cNhomketQua = "";
                    //vòng lập gán các giá trị tuong ứng tên trong mảng cho cac truong không ghép
                    for (int y = 0; y < _Name.Length; y++)
                    {
                        if (_Name[y] != _colTestNameResult && _Name[y] != _colResultNameSource && _Name[y] != _colTestCode)
                        {
                            dr[_Name[y].ToString()] = dtSource.Rows[i][_Name[y].ToString()].ToString().Trim();
                        }
                    }
                    var manhomCLS = "";
                    //vòng lập gán các giá trị tuong ứng  cho cac truong ghép
                    for (j = i; j < dt.Rows.Count; j++)
                    {
                        //Neu cung 1 ID thi cong testcode lai
                        if (_cID == dt.Rows[j][_colID].ToString().Trim())
                        {
                            if (_dangCot)
                            {
                                dr["[" + dt.Rows[j][_colTestCode].ToString().Trim() + "]"] = dtSource.Rows[j][_colResultNameSource].ToString().Trim();
                            }
                            else
                            {
                                if (_LayChiDinh)//Neu xem chi dinh
                                {
                                    var list = string.Format("{0}", dt.Rows[j][_colTestNameSource].ToString().Trim());
                                    if (!dt.Rows[j]["MaNhomCLS"].ToString().Equals(manhomCLS))
                                    {
                                        if (string.IsNullOrEmpty(manhomCLS))
                                        {
                                            manhomCLS = dt.Rows[j]["MaNhomCLS"].ToString();
                                            _cKetQuavaTen += string.Format("{0}: {1}", manhomCLS, list);
                                        }
                                        else
                                        {
                                            manhomCLS = dt.Rows[j]["MaNhomCLS"].ToString();
                                            _cKetQuavaTen += string.Format("\r\n{0}: {1}", manhomCLS, list);
                                        }
                                    }
                                    else
                                    {
                                        _cKetQuavaTen += string.Format(", {0}", list);
                                    }
                                    
                                }
                                else//Xem ket qua
                                {
                                    if (baocaoKetqua)
                                    {
                                        var testname = string.Format("{0}", dt.Rows[j][_colTestNameSource].ToString().Trim());
                                        var retsultname = string.Format("{0}", dt.Rows[j][_colResultNameSource].ToString().Trim());
                                       
                                        _cKetQua += (string.IsNullOrEmpty(_cKetQuavaTen) ? "" : "\r\n") + string.Format("{0}", retsultname);
                                        _cNhomketQua += (string.IsNullOrEmpty(_cKetQuavaTen) ? "" : "\r\n") + string.Format("{0}", dt.Rows[j]["MaNhomCLS"].ToString());
                                        _cKetQuavaTen += (string.IsNullOrEmpty(_cKetQuavaTen) ? "" : "\r\n") + string.Format("{0}", testname);

                                    }
                                    else
                                    {
                                        var list = string.Format("{0}:{1}", dt.Rows[j][_colTestNameSource].ToString().Trim(), dtSource.Rows[j][_colResultNameSource].ToString().Trim());
                                        if (!dt.Rows[j]["MaNhomCLS"].ToString().Equals(manhomCLS))
                                        {
                                            if (string.IsNullOrEmpty(manhomCLS))
                                            {
                                                manhomCLS = dt.Rows[j]["MaNhomCLS"].ToString();
                                                _cKetQuavaTen += string.Format("{0}: {1}", manhomCLS, list);
                                            }
                                            else
                                            {
                                                manhomCLS = dt.Rows[j]["MaNhomCLS"].ToString();
                                                _cKetQuavaTen += string.Format("\r\n{0}: {1}", manhomCLS, list);
                                            }
                                        }
                                        else
                                        {
                                            _cKetQuavaTen += string.Format(", {0}", list);
                                        }
                                    }
                                    //_cKetQua += string.Format("{0}:{1}, ", dt.Rows[j][_colTestNameSource].ToString().Trim(), dtSource.Rows[j][_colResultNameSource].ToString().Trim());
                                }
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                    i = j - 1;

                    if (_dangCot == false)
                    {
                        if (baocaoKetqua)
                        {
                            dr[_colTestNameResult] = _cKetQuavaTen;
                            dr[_colTestResultName] = _cKetQua;
                            dr["MaNhomCLS"] = _cNhomketQua;
                        }
                        else
                            dr[_colTestNameResult] = _cKetQuavaTen; //_cKetQua.Substring(0, _cKetQua.Length - 2);
                    }

                    dtResult.Rows.Add(dr);
                }
            }
        }

        /// <summary>
        /// Đánh dấu nhóm trên lưới ; DataPropertyName = "No1" cho STT ; DataPropertyName = "iscate" cho cờ là nhóm chính
        /// </summary>
        /// <param name="dtg">DataGridView</param>
        public static void DanhDauNhom_STT(DataGridView dtg)
        {
            int _stt = 0;
            int _sttcate = 0;
            int _indexCate = -1;
            int _indexNo = -1;
            foreach (DataGridViewColumn dgc in dtg.Columns)
            {
                if (dgc.DataPropertyName.ToLower().Trim() == "iscate")
                {
                    _indexCate = dgc.Index;
                }
                else if (dgc.DataPropertyName.ToLower().Trim() == "no1")
                {
                    _indexNo = dgc.Index;
                }

            }
            if (_indexNo != -1 && _indexCate != -1)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    if ((dtg.Rows[i].Cells[_indexCate].Value == null ? false : (bool)dtg.Rows[i].Cells[_indexCate].Value) == true)
                    {
                        _stt = 0;
                        _sttcate++;
                        dtg.Rows[i].Cells[_indexNo].Value = LabServices_Helper.LaySTT(_sttcate, 1);
                        dtg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(130, 231, 255);
                        dtg.Rows[i].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        _stt++;
                        dtg.Rows[i].Cells[_indexNo].Value = _stt;
                    }
                }
            }
            else if (_indexNo != -1)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    _stt++;
                    dtg.Rows[i].Cells[_indexNo].Value = _stt;
                }
            }
            else if (_indexCate != -1)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    if ((bool)dtg.Rows[i].Cells[_indexCate].Value == true)
                    {
                        dtg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(130, 231, 255);
                        dtg.Rows[i].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                }
            }
            else
                return;
        }
        public static int FindIndexInArry(string[] arrayIn, string searchString)
        {
            for (int i = 0; i < arrayIn.Length; i++)
            {
                if (arrayIn[i].Equals(searchString, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            return -1;
        }
        /// <summary>
        /// Lấy số thứ tự
        /// </summary>
        /// <param name="_num">số tt cần chuyển</param>
        /// <param name="_loai">1: ABC - 2: LA Mã</param>
        /// <returns></returns>
        public static string LaySTT(int _num, int _loai)
        {
            if (_loai == 1)
            {
                switch (_num)
                {
                    case 1:
                        return "A";
                    case 2:
                        return "B";
                    case 3:
                        return "C";
                    case 4:
                        return "D";
                    case 5:
                        return "E";
                    case 6:
                        return "F";
                    case 7:
                        return "G";
                    case 8:
                        return "H";
                    case 9:
                        return "I";
                    case 10:
                        return "J";
                    case 11:
                        return "K";
                    case 12:
                        return "L";
                    case 13:
                        return "M";
                    case 14:
                        return "N";
                    case 15:
                        return "O";
                }
            }
            else if (_loai == 2)
            {
                switch (_num)
                {
                    case 1:
                        return "I";
                    case 2:
                        return "II";
                    case 3:
                        return "III";
                    case 4:
                        return "IV";
                    case 5:
                        return "V";
                    case 6:
                        return "VI";
                    case 7:
                        return "VII";
                    case 8:
                        return "VIII";
                    case 9:
                        return "IX";
                    case 10:
                        return "X";
                    case 11:
                        return "XI";
                    case 12:
                        return "XII";
                    case 13:
                        return "XIII";
                    case 14:
                        return "XIV";
                    case 15:
                        return "XV";
                }
            }
            return "";
        }

        public static void TachNhom_Datatable(DataTable dtSource, ref DataTable dtResult, string _TencotCotChinh, string _MaCotChinh, string _Cotgan_Cho_CotChinh, string _CotTongTien, string _CotTongSoluong)
        {
            try
            {
                dtResult = dtSource.Clone();
                foreach (DataColumn cl in dtResult.Columns)
                {
                    if (cl.DataType == typeof(int) || cl.DataType == typeof(Int32))
                    {
                        cl.DataType = typeof(double);
                    }
                }
                string _ID = "";
                int _inCate = 0;
                double _TongXN = 0;
                double _TongTien = 0;

                if (dtSource.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSource.Rows.Count; i++)
                    {
                        DataRow dr = dtResult.NewRow();
                        if (_ID != dtSource.Rows[i][_MaCotChinh].ToString().TrimEnd().ToLower())
                        {
                            if (dtResult.Rows.Count > 0)
                            {
                                if (_CotTongTien != "")
                                {
                                    dtResult.Rows[_inCate][_CotTongTien] = _TongTien.ToString("N0");
                                }
                                if (_CotTongSoluong != "")
                                {
                                    dtResult.Rows[_inCate][_CotTongSoluong] = _TongXN.ToString("N0");
                                }
                            }

                            _ID = dtSource.Rows[i][_MaCotChinh].ToString().TrimEnd().ToLower();
                            dr[_Cotgan_Cho_CotChinh] = dtSource.Rows[i][_TencotCotChinh].ToString().TrimEnd();
                            dr["iscate"] = true;
                            dtResult.Rows.Add(dr);
                            _inCate = dtResult.Rows.Count - 1;

                            dr = dtResult.NewRow();

                            dr.ItemArray = dtSource.Rows[i].ItemArray;
                            dr["iscate"] = false;

                            if (_CotTongTien != "")
                            {
                                _TongXN = double.Parse(dtSource.Rows[i][_CotTongSoluong].ToString());
                            }
                            if (_CotTongSoluong != "")
                            {
                                _TongTien = double.Parse(dtSource.Rows[i][_CotTongTien].ToString());
                            }
                            dtResult.Rows.Add(dr);
                        }
                        else
                        {
                            dr.ItemArray = dtSource.Rows[i].ItemArray;

                            dr["iscate"] = false;

                            if (_CotTongTien != "")
                            {
                                _TongXN += double.Parse(dtSource.Rows[i][_CotTongSoluong].ToString());
                            }
                            if (_CotTongSoluong != "")
                            {
                                _TongTien += double.Parse(dtSource.Rows[i][_CotTongTien].ToString());
                            }
                            dtResult.Rows.Add(dr);
                        }

                    }
                    if (dtResult.Rows.Count > 0)
                    {
                        if (_CotTongTien != "")
                        {
                            dtResult.Rows[_inCate][_CotTongTien] = _TongTien.ToString("N0");
                        }
                        if (_CotTongSoluong != "")
                        {
                            dtResult.Rows[_inCate][_CotTongSoluong] = _TongXN.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "TachNhom_Datatable", CommonAppVarsAndFunctions.UserID);
            }
        }

        public static void TachNhom_Datatable(DataTable dtSource, ref DataTable dtResult, string _TencotCotChinh, string _MaCotChinh, string _Cotgan_Cho_CotChinh, string _CotTongTien, string _CotTongSoluong, string _CotHeSo)
        {
            try
            {


                dtResult = dtSource.Clone();
                foreach (DataColumn cl in dtResult.Columns)
                {
                    if (cl.DataType == typeof(int) || cl.DataType == typeof(Int32))
                    {
                        cl.DataType = typeof(double);
                    }
                }
                string _ID = "";
                int _inCate = 0;
                double _TongXN = 0;
                double _HeSo = 0;
                double _TongTien = 0;

                if (dtSource.Rows.Count > 0)
                {
                    for (int i = 0; i < dtSource.Rows.Count; i++)
                    {
                        DataRow dr = dtResult.NewRow();
                        if (_ID != dtSource.Rows[i][_MaCotChinh].ToString().TrimEnd().ToLower())
                        {
                            if (dtResult.Rows.Count > 0)
                            {
                                if (_CotTongTien != "")
                                {
                                    dtResult.Rows[_inCate][_CotTongTien] = _TongTien.ToString("N0");
                                }
                                if (_CotTongSoluong != "")
                                {
                                    dtResult.Rows[_inCate][_CotTongSoluong] = _TongXN.ToString("N0");
                                }
                                if (_CotHeSo != "")
                                {
                                    dtResult.Rows[_inCate][_CotHeSo] = _HeSo.ToString("N0");
                                }
                            }

                            _ID = dtSource.Rows[i][_MaCotChinh].ToString().TrimEnd().ToLower();
                            dr[_Cotgan_Cho_CotChinh] = dtSource.Rows[i][_TencotCotChinh].ToString().TrimEnd();
                            dr["iscate"] = true;
                            dtResult.Rows.Add(dr);
                            _inCate = dtResult.Rows.Count - 1;

                            dr = dtResult.NewRow();

                            dr.ItemArray = dtSource.Rows[i].ItemArray;
                            dr["iscate"] = false;

                            if (_CotTongSoluong != "")
                            {
                                _TongXN = double.Parse(dtSource.Rows[i][_CotTongSoluong].ToString());
                            }
                            if (_CotHeSo != "")
                            {
                                _HeSo = double.Parse(dtSource.Rows[i][_CotHeSo].ToString());
                            }
                            if (_CotTongTien != "")
                            {
                                _TongTien = double.Parse(dtSource.Rows[i][_CotTongTien].ToString());
                            }
                            dtResult.Rows.Add(dr);
                        }
                        else
                        {
                            dr.ItemArray = dtSource.Rows[i].ItemArray;

                            dr["iscate"] = false;

                            if (_CotTongSoluong != "")
                            {
                                _TongXN += double.Parse(dtSource.Rows[i][_CotTongSoluong].ToString());
                            }
                            if (_CotHeSo != "")
                            {
                                _HeSo += double.Parse(dtSource.Rows[i][_CotHeSo].ToString());
                            }
                            if (_CotTongTien != "")
                            {
                                _TongTien += double.Parse(dtSource.Rows[i][_CotTongTien].ToString());
                            }
                            dtResult.Rows.Add(dr);
                        }

                    }
                    if (dtResult.Rows.Count > 0)
                    {
                        if (_CotTongTien != "")
                        {
                            dtResult.Rows[_inCate][_CotTongTien] = _TongTien.ToString("N0");
                        }
                        if (_CotTongSoluong != "")
                        {
                            dtResult.Rows[_inCate][_CotTongSoluong] = _TongXN.ToString("N0");
                        }
                        if (_CotHeSo != "")
                        {
                            dtResult.Rows[_inCate][_CotHeSo] = _HeSo.ToString("N0");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "TachNhom_Datatable", CommonAppVarsAndFunctions.UserID);
            }
        }

        /// <summary>
        /// So sánh chuỗi cho trường hợp đặt nhiều điều kiện
        /// </summary>
        /// <param name="_Orgrial">Chuỗi điều kiện</param>
        /// <param name="_BeingCompare">Chuỗi muốn so sánh</param>
        /// <param name="_splitChar">Ký tự cắt trong chuỗi điều kiện</param>
        /// <returns>False: Không tìm thấy chuỗi khớp - True: Tìm thấy chuỗi khớp</returns>
        public static bool Compare_Criteria(string _Orgrial, string _BeingCompare, char _splitChar)
        {
            if (_Orgrial.Length > 0)
            {
                string[] _arrayOrignal = _Orgrial.Split(_splitChar);
                if (_arrayOrignal.Length > 0)
                {
                    for (int i = 0; i < _arrayOrignal.Length; i++)
                    {
                        if (_arrayOrignal[i].Trim().ToLower() == _BeingCompare.ToLower().Trim())
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public static void Select_FoundRow(DataGridView dtg, string _ColumnFind, string _TextFind)
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dtg.Rows)
            {
                if (row.Cells[_ColumnFind].Value.ToString().Equals(_TextFind))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            if (rowIndex >= 0)
            {
                dtg.Rows[rowIndex].Selected = true;
                dtg.FirstDisplayedScrollingRowIndex = rowIndex;
            }

        }

        #region Folders and Files
        public static bool CheckExistsFolder(string _FoderPath)
        {
            return System.IO.Directory.Exists(_FoderPath);
        }
        public static bool CheckExistsFileName(string _FoderPath, string _FileName)
        {
            return System.IO.File.Exists(_FoderPath + "\\" + _FileName);
        }
        public static bool CheckExistsFileName(string _FilePath)
        {
            return System.IO.File.Exists(_FilePath);
        }
        public static void CreateFolder(string _FoderPath)
        {
            System.IO.Directory.CreateDirectory(_FoderPath);
        }
        public static void DeleteFile(string _FoderPath, string _FileName)
        {
            System.IO.File.Delete(_FoderPath + "\\" + _FileName);
        }
        public static void DeleteFile(string _FilePath)
        {
            System.IO.File.Delete(_FilePath);
        }
        #endregion
    }

    public class Utils
    {
        /// <summary>
        /// Hàm cắt đi dấu nháy trong chuổi
        /// </summary>
        /// <param name="Str">Chuổi ký tự truyền vào</param>
        /// <returns>Chuổi ký tự trả về</returns>
        public static string ConvertString(string Str)
        {
            string strConvert = "";
            for (int i = 1; i <= Str.Length; i++)
            {
                if (Strings.Mid(Str, i, 1).Equals("'"))
                {
                    strConvert += "''";
                }
                else
                {
                    strConvert += Strings.Mid(Str, i, 1);
                }
            }

            return strConvert;
        }
        /// <summary>
        /// Hàm dùng để chuyển tuổi ra năm
        /// </summary>
        /// <param name="_age"></param>
        /// <returns></returns>
        public static string ConvertBirthYear(string _age)
        {
            if (string.IsNullOrEmpty(_age)) _age = "0";
            if (int.Parse(_age) < 1000 && int.Parse(_age) != 0)
                _age = (DateTime.Now.Year - int.Parse(_age)).ToString();

            return _age;
        }
        public static string ChuyenTVKhongDau(string strVietNamese)
        {
            string FindText = "áàảãạâấầẩẫậăắằẳẵặđèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1, index2;
            while ((index = strVietNamese.IndexOfAny(FindText.ToCharArray())) != -1)
            {
                index2 = FindText.IndexOf(strVietNamese[index]);
                strVietNamese = strVietNamese.Replace(strVietNamese[index], ReplText[index2]);
            }
            return strVietNamese;
        }
        /// <summary>
        /// _TypeCOnvert=1 (Convert from UNI), _TypeCOnvert=2 (Convert from VNI), _TypeCOnvert=3 (Convert from ABC)
        /// </summary>
        /// <param name="_Source"></param>
        /// <param name="_TypeConvert"></param>
        /// <returns></returns>
        public static string ConvertStringText(string _Source, int _TypeConvert)
        {
            string _ConvertResult = "";
            string _Temp = "";
            if (string.IsNullOrEmpty(_Source))
                return "";
            #region UNI
            if (_TypeConvert == 1)
            {
                for (int i = 1; i <= _Source.Length; i++)
                {
                    _Temp = Strings.Mid(_Source, i, 1);
                    switch (_Temp)
                    {
                        case "á"://1
                            _ConvertResult += "a";
                            break;
                        case "à"://2
                            _ConvertResult += "a";
                            break;
                        case "ả"://3
                            _ConvertResult += "a";
                            break;
                        case "ã"://4
                            _ConvertResult += "a";
                            break;
                        case "ạ"://5
                            _ConvertResult += "a";
                            break;
                        case "ă"://6
                            _ConvertResult += "a";
                            break;
                        case "ắ"://7
                            _ConvertResult += "a";
                            break;
                        case "ằ"://8
                            _ConvertResult += "a";
                            break;
                        case "ẳ"://9
                            _ConvertResult += "a";
                            break;
                        case "ẵ"://10
                            _ConvertResult += "a";
                            break;
                        case "ặ"://11
                            _ConvertResult += "a";
                            break;
                        case "â"://12
                            _ConvertResult += "a";
                            break;
                        case "ấ"://13
                            _ConvertResult += "a";
                            break;
                        case "ầ"://14
                            _ConvertResult += "a";
                            break;
                        case "ẩ"://15
                            _ConvertResult += "a";
                            break;
                        case "ẫ"://16
                            _ConvertResult += "a";
                            break;
                        case "ậ"://17
                            _ConvertResult += "a";
                            break;
                        case "é"://18
                            _ConvertResult += "e";
                            break;
                        case "è"://19
                            _ConvertResult += "e";
                            break;
                        case "ẻ"://20
                            _ConvertResult += "e";
                            break;
                        case "ẽ"://21
                            _ConvertResult += "e";
                            break;
                        case "ẹ"://22
                            _ConvertResult += "e";
                            break;
                        case "ê"://23
                            _ConvertResult += "e";
                            break;
                        case "ế"://24
                            _ConvertResult += "e";
                            break;
                        case "ề"://25
                            _ConvertResult += "e";
                            break;
                        case "ể"://26
                            _ConvertResult += "e";
                            break;
                        case "ễ"://27
                            _ConvertResult += "e";
                            break;
                        case "ệ"://28
                            _ConvertResult += "e";
                            break;
                        case "ó"://29
                            _ConvertResult += "o";
                            break;
                        case "ò"://30
                            _ConvertResult += "o";
                            break;
                        case "ỏ"://31
                            _ConvertResult += "o";
                            break;
                        case "õ"://32
                            _ConvertResult += "o";
                            break;
                        case "ọ"://33
                            _ConvertResult += "o";
                            break;
                        case "ô"://34
                            _ConvertResult += "o";
                            break;
                        case "ố"://35
                            _ConvertResult += "o";
                            break;
                        case "ồ"://36
                            _ConvertResult += "o";
                            break;
                        case "ổ"://37
                            _ConvertResult += "o";
                            break;
                        case "ỗ"://38
                            _ConvertResult += "o";
                            break;
                        case "ộ"://39
                            _ConvertResult += "o";
                            break;
                        case "ơ"://40
                            _ConvertResult += "o";
                            break;
                        case "ớ"://41
                            _ConvertResult += "o";
                            break;
                        case "ờ"://42
                            _ConvertResult += "o";
                            break;
                        case "ở"://43
                            _ConvertResult += "o";
                            break;
                        case "ỡ"://44
                            _ConvertResult += "o";
                            break;
                        case "ợ"://45
                            _ConvertResult += "o";
                            break;
                        case "ú"://46
                            _ConvertResult += "u";
                            break;
                        case "ù"://47
                            _ConvertResult += "u";
                            break;
                        case "ủ"://48
                            _ConvertResult += "u";
                            break;
                        case "ũ"://49
                            _ConvertResult += "u";
                            break;
                        case "ụ"://50
                            _ConvertResult += "u";
                            break;
                        case "ư"://51
                            _ConvertResult += "u";
                            break;
                        case "ứ"://52
                            _ConvertResult += "u";
                            break;
                        case "ừ"://53
                            _ConvertResult += "u";
                            break;
                        case "ử"://54
                            _ConvertResult += "u";
                            break;
                        case "ữ"://55
                            _ConvertResult += "u";
                            break;
                        case "ự"://56
                            _ConvertResult += "u";
                            break;
                        case "ý"://57
                            _ConvertResult += "y";
                            break;
                        case "ỳ"://58
                            _ConvertResult += "y";
                            break;
                        case "ỷ"://59
                            _ConvertResult += "y";
                            break;
                        case "ỹ"://60
                            _ConvertResult += "y";
                            break;
                        case "ỵ"://61
                            _ConvertResult += "y";
                            break;
                        case "Á"://62
                            _ConvertResult += "A";
                            break;
                        case "À"://63
                            _ConvertResult += "A";
                            break;
                        case "Ả"://64
                            _ConvertResult += "A";
                            break;
                        case "Ã"://65
                            _ConvertResult += "A";
                            break;
                        case "Ạ"://66
                            _ConvertResult += "A";
                            break;
                        case "Ă"://67
                            _ConvertResult += "A";
                            break;
                        case "Ắ"://68
                            _ConvertResult += "A";
                            break;
                        case "Ằ"://69
                            _ConvertResult += "A";
                            break;
                        case "Ẳ"://70
                            _ConvertResult += "A";
                            break;
                        case "Ẵ"://71
                            _ConvertResult += "A";
                            break;
                        case "Ặ"://72
                            _ConvertResult += "A";
                            break;
                        case "Â"://73
                            _ConvertResult += "A";
                            break;
                        case "Ấ"://74
                            _ConvertResult += "A";
                            break;
                        case "Ầ"://75
                            _ConvertResult += "A";
                            break;
                        case "Ẩ"://76
                            _ConvertResult += "A";
                            break;
                        case "Ẫ"://77
                            _ConvertResult += "A";
                            break;
                        case "Ậ"://78
                            _ConvertResult += "A";
                            break;
                        case "É"://79
                            _ConvertResult += "E";
                            break;
                        case "È"://80
                            _ConvertResult += "E";
                            break;
                        case "Ẻ"://81
                            _ConvertResult += "E";
                            break;
                        case "Ẽ"://82
                            _ConvertResult += "E";
                            break;
                        case "Ẹ"://83
                            _ConvertResult += "E";
                            break;
                        case "Ê"://84
                            _ConvertResult += "E";
                            break;
                        case "Ế"://85
                            _ConvertResult += "E";
                            break;
                        case "Ề"://86
                            _ConvertResult += "E";
                            break;
                        case "Ể"://87
                            _ConvertResult += "E";
                            break;
                        case "Ễ"://88
                            _ConvertResult += "E";
                            break;
                        case "Ệ"://89
                            _ConvertResult += "E";
                            break;
                        case "Ó"://90
                            _ConvertResult += "O";
                            break;
                        case "Ò"://91
                            _ConvertResult += "O";
                            break;
                        case "Ỏ"://92
                            _ConvertResult += "O";
                            break;
                        case "Õ"://93
                            _ConvertResult += "O";
                            break;
                        case "Ọ"://94
                            _ConvertResult += "O";
                            break;
                        case "Ô"://95
                            _ConvertResult += "O";
                            break;
                        case "Ố"://96
                            _ConvertResult += "O";
                            break;
                        case "Ồ"://97
                            _ConvertResult += "O";
                            break;
                        case "Ổ"://98
                            _ConvertResult += "O";
                            break;
                        case "Ỗ"://99
                            _ConvertResult += "O";
                            break;
                        case "Ộ"://100
                            _ConvertResult += "O";
                            break;
                        case "Ơ"://101
                            _ConvertResult += "O";
                            break;
                        case "Ớ"://102
                            _ConvertResult += "O";
                            break;
                        case "Ờ"://103
                            _ConvertResult += "O";
                            break;
                        case "Ở"://104
                            _ConvertResult += "O";
                            break;
                        case "Ỡ"://105
                            _ConvertResult += "O";
                            break;
                        case "Ợ"://106
                            _ConvertResult += "O";
                            break;
                        case "Ú"://107
                            _ConvertResult += "U";
                            break;
                        case "Ù"://108
                            _ConvertResult += "U";
                            break;
                        case "Ủ"://109
                            _ConvertResult += "U";
                            break;
                        case "Ũ"://110
                            _ConvertResult += "U";
                            break;
                        case "Ụ"://111
                            _ConvertResult += "U";
                            break;
                        case "Ư"://112
                            _ConvertResult += "U";
                            break;
                        case "Ứ"://113
                            _ConvertResult += "U";
                            break;
                        case "Ừ"://114
                            _ConvertResult += "U";
                            break;
                        case "Ử"://115
                            _ConvertResult += "U";
                            break;
                        case "Ữ"://116
                            _ConvertResult += "U";
                            break;
                        case "Ự"://117
                            _ConvertResult += "U";
                            break;
                        case "Ý"://118
                            _ConvertResult += "U";
                            break;
                        case "Ỳ"://119
                            _ConvertResult += "Y";
                            break;
                        case "Ỷ"://120
                            _ConvertResult += "Y";
                            break;
                        case "Ỹ"://121
                            _ConvertResult += "Y";
                            break;
                        case "í"://122
                            _ConvertResult += "i";
                            break;
                        case "ì"://123
                            _ConvertResult += "i";
                            break;
                        case "ỉ"://124
                            _ConvertResult += "i";
                            break;
                        case "ĩ"://125
                            _ConvertResult += "i";
                            break;
                        case "ị"://126
                            _ConvertResult += "i";
                            break;
                        case "Ỵ"://127
                            _ConvertResult += "Y";
                            break;
                        case "Í"://128
                            _ConvertResult += "I";
                            break;
                        case "Ì"://129
                            _ConvertResult += "I";
                            break;
                        case "Ỉ"://130
                            _ConvertResult += "I";
                            break;
                        case "Ĩ"://131
                            _ConvertResult += "I";
                            break;
                        case "Ị"://132
                            _ConvertResult += "I";
                            break;
                        case "Đ"://133
                            _ConvertResult += "D";
                            break;
                        case "đ"://134
                            _ConvertResult += "d";
                            break;
                        default:
                            _ConvertResult += _Temp;
                            break;
                    }
                }

                return _ConvertResult;
            }
            #endregion

            #region VNI
            else if (_TypeConvert == 2)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Pos", typeof(int));
                dt.Columns.Add("Source", typeof(string));
                dt.Columns.Add("Convert", typeof(string));
                //134 row
                dt.Rows.Add(1, "aù", "a");
                dt.Rows.Add(2, "aø", "a");
                dt.Rows.Add(3, "aû", "a");
                dt.Rows.Add(4, "aõ", "a");
                dt.Rows.Add(5, "aï", "a");
                dt.Rows.Add(6, "aê", "a");
                dt.Rows.Add(7, "aé", "a");
                dt.Rows.Add(8, "aè", "a");
                dt.Rows.Add(9, "aú", "a");
                dt.Rows.Add(10, "aü", "a");
                dt.Rows.Add(11, "aë", "a");
                dt.Rows.Add(12, "aâ", "a");
                dt.Rows.Add(13, "aá", "a");
                dt.Rows.Add(14, "aà", "a");
                dt.Rows.Add(15, "aå", "a");
                dt.Rows.Add(16, "aã", "a");
                dt.Rows.Add(17, "aä", "a");
                dt.Rows.Add(18, "eù", "e");
                dt.Rows.Add(19, "eø", "e");
                dt.Rows.Add(20, "eû", "e");
                dt.Rows.Add(21, "eõ", "e");
                dt.Rows.Add(22, "eï", "e");
                dt.Rows.Add(23, "eâ", "e");
                dt.Rows.Add(24, "eá", "e");
                dt.Rows.Add(25, "eà", "e");
                dt.Rows.Add(26, "eå", "e");
                dt.Rows.Add(27, "eã", "e");
                dt.Rows.Add(28, "eä", "e");
                dt.Rows.Add(29, "où", "o");
                dt.Rows.Add(30, "oø", "o");
                dt.Rows.Add(31, "oû", "o");
                dt.Rows.Add(32, "oõ", "o");
                dt.Rows.Add(33, "oï", "o");
                dt.Rows.Add(34, "oâ", "o");
                dt.Rows.Add(35, "oá", "o");
                dt.Rows.Add(36, "oà", "o");
                dt.Rows.Add(37, "oå", "o");
                dt.Rows.Add(38, "oã", "o");
                dt.Rows.Add(39, "oä", "o");
                dt.Rows.Add(40, "ô", "o");
                dt.Rows.Add(41, "ôù", "o");
                dt.Rows.Add(42, "ôø", "o");
                dt.Rows.Add(43, "ôû", "o");
                dt.Rows.Add(44, "ôõ", "o");
                dt.Rows.Add(45, "ôï", "o");
                dt.Rows.Add(46, "uù", "u");
                dt.Rows.Add(47, "uø", "u");
                dt.Rows.Add(48, "uû", "u");
                dt.Rows.Add(49, "uõ", "u");
                dt.Rows.Add(50, "uï", "u");
                dt.Rows.Add(51, "ö", "u");
                dt.Rows.Add(52, "öù", "u");
                dt.Rows.Add(53, "öø", "u");
                dt.Rows.Add(54, "öû", "u");
                dt.Rows.Add(55, "öõ", "u");
                dt.Rows.Add(56, "öï", "u");
                dt.Rows.Add(57, "yù", "y");
                dt.Rows.Add(58, "yø", "y");
                dt.Rows.Add(59, "yû", "y");
                dt.Rows.Add(60, "yõ", "y");
                dt.Rows.Add(61, "î", "y");
                dt.Rows.Add(62, "AÙ", "A");
                dt.Rows.Add(63, "AØ", "A");
                dt.Rows.Add(64, "AÛ", "A");
                dt.Rows.Add(65, "AÕ", "A");
                dt.Rows.Add(66, "AÏ", "A");
                dt.Rows.Add(67, "AÊ", "A");
                dt.Rows.Add(68, "AÉ", "A");
                dt.Rows.Add(69, "AÈ", "A");
                dt.Rows.Add(70, "AÚ", "A");
                dt.Rows.Add(71, "AÜ", "A");
                dt.Rows.Add(72, "AË", "A");
                dt.Rows.Add(73, "AÂ", "A");
                dt.Rows.Add(74, "AÁ", "A");
                dt.Rows.Add(75, "AÀ", "A");
                dt.Rows.Add(76, "AÅ", "A");
                dt.Rows.Add(77, "AÃ", "A");
                dt.Rows.Add(78, "AÄ", "A");
                dt.Rows.Add(79, "EÙ", "E");
                dt.Rows.Add(80, "EØ", "E");
                dt.Rows.Add(81, "EÛ", "E");
                dt.Rows.Add(82, "EÕ", "E");
                dt.Rows.Add(83, "EÏ", "E");
                dt.Rows.Add(84, "EÂ", "E");
                dt.Rows.Add(85, "EÁ", "E");
                dt.Rows.Add(86, "EÀ", "E");
                dt.Rows.Add(87, "EÅ", "E");
                dt.Rows.Add(88, "EÃ", "E");
                dt.Rows.Add(89, "EÄ", "E");
                dt.Rows.Add(90, "OÙ", "O");
                dt.Rows.Add(91, "OØ", "O");
                dt.Rows.Add(92, "OÛ", "O");
                dt.Rows.Add(93, "OÕ", "O");
                dt.Rows.Add(94, "OÏ", "O");
                dt.Rows.Add(95, "OÂ", "O");
                dt.Rows.Add(96, "OÁ", "O");
                dt.Rows.Add(97, "OÀ", "O");
                dt.Rows.Add(98, "OÅ", "O");
                dt.Rows.Add(99, "OÃ", "O");
                dt.Rows.Add(100, "OÄ", "O");
                dt.Rows.Add(101, "Ô", "O");
                dt.Rows.Add(102, "ÔÙ", "O");
                dt.Rows.Add(103, "ÔØ", "O");
                dt.Rows.Add(104, "ÔÛ", "O");
                dt.Rows.Add(105, "ÔÕ", "O");
                dt.Rows.Add(106, "ÔÏ", "O");
                dt.Rows.Add(107, "UÙ", "U");
                dt.Rows.Add(108, "UØ", "U");
                dt.Rows.Add(109, "UÛ", "U");
                dt.Rows.Add(110, "UÕ", "U");
                dt.Rows.Add(111, "UÏ", "U");
                dt.Rows.Add(112, "Ö", "U");
                dt.Rows.Add(113, "ÖÙ", "U");
                dt.Rows.Add(114, "ÖØ", "U");
                dt.Rows.Add(115, "ÖÛ", "U");
                dt.Rows.Add(116, "ÖÕ", "U");
                dt.Rows.Add(117, "ÖÏ", "U");
                dt.Rows.Add(118, "YÙ", "Y");
                dt.Rows.Add(119, "YØ", "Y");
                dt.Rows.Add(120, "YÛ", "Y");
                dt.Rows.Add(121, "YÕ", "Y");
                dt.Rows.Add(122, "í", "i");
                dt.Rows.Add(123, "ì", "i");
                dt.Rows.Add(124, "æ", "i");
                dt.Rows.Add(125, "ó", "i");
                dt.Rows.Add(126, "ò", "i");
                dt.Rows.Add(127, "Î", "Y");
                dt.Rows.Add(128, "Í", "I");
                dt.Rows.Add(129, "Ì", "I");
                dt.Rows.Add(130, "Æ", "I");
                dt.Rows.Add(131, "Ó", "I");
                dt.Rows.Add(132, "Ò", "I");
                dt.Rows.Add(133, "Ñ", "D");
                dt.Rows.Add(134, "ñ", "d");

                string _SourceTemp = _Source;
                string _Char = "";
                int _Pos = 0;

                do
                {
                    if (_SourceTemp.Length >= 2)
                    {
                        _Char = Strings.Mid(_SourceTemp, 1, 2);
                        _Pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                _Pos = i;
                                break;
                            }
                        }

                        if (_Pos > 0)
                        {
                            _ConvertResult += dt.Rows[_Pos - 1][2].ToString();
                            _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 2);
                        }
                        else
                        {
                            _Char = Strings.Mid(_SourceTemp, 1, 1);
                            _Pos = 0;
                            for (int i = 1; i <= 134; i++)
                            {
                                if (_Char == dt.Rows[i - 1][1].ToString())
                                {
                                    _Pos = i;
                                    break;
                                }
                            }
                            if (_Pos > 0)
                            {
                                _ConvertResult += dt.Rows[_Pos - 1][2].ToString();
                                _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                            }
                            else
                            {
                                _Char = Strings.Mid(_SourceTemp, 1, 1);
                                _ConvertResult += _Char;
                                _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                            }
                        }

                    }
                    else
                    {
                        _Char = Strings.Mid(_SourceTemp, 1, 1);
                        _Pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                _Pos = i;
                                break;
                            }
                        }
                        if (_Pos > 0)
                        {
                            _ConvertResult += dt.Rows[_Pos - 1][2].ToString();
                            _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                        }
                        else
                        {
                            _Char = Strings.Mid(_SourceTemp, 1, 1);
                            _ConvertResult += _Char;
                            _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                        }
                    }

                } while (_SourceTemp.Length > 0);

                return _ConvertResult;

            }
            #endregion

            #region ABC
            else if (_TypeConvert == 3)
            {
                for (int i = 1; i <= _Source.Length; i++)
                {
                    _Temp = Strings.Mid(_Source, i, 1);
                    switch (_Temp)
                    {
                        case "¸"://1
                            _ConvertResult += "a";
                            break;
                        case "µ"://2
                            _ConvertResult += "a";
                            break;
                        case "¶"://3
                            _ConvertResult += "a";
                            break;
                        case "·"://4
                            _ConvertResult += "a";
                            break;
                        case "¹"://5
                            _ConvertResult += "a";
                            break;
                        case "¨"://6
                            _ConvertResult += "a";
                            break;
                        case "¾"://7
                            _ConvertResult += "a";
                            break;
                        case "»"://8
                            _ConvertResult += "a";
                            break;
                        case "¼"://9
                            _ConvertResult += "a";
                            break;
                        case "½"://10
                            _ConvertResult += "a";
                            break;
                        case "Æ"://11
                            _ConvertResult += "a";
                            break;
                        case "©"://12
                            _ConvertResult += "a";
                            break;
                        case "Ê"://13
                            _ConvertResult += "a";
                            break;
                        case "Ç"://14
                            _ConvertResult += "a";
                            break;
                        case "È"://15
                            _ConvertResult += "a";
                            break;
                        case "É"://16
                            _ConvertResult += "a";
                            break;
                        case "Ë"://17
                            _ConvertResult += "a";
                            break;
                        case "Ð"://18
                            _ConvertResult += "e";
                            break;
                        case "Ì"://19
                            _ConvertResult += "e";
                            break;
                        case "Î"://20
                            _ConvertResult += "e";
                            break;
                        case "Ï"://21
                            _ConvertResult += "e";
                            break;
                        case "Ñ"://22
                            _ConvertResult += "e";
                            break;
                        case "ª"://23
                            _ConvertResult += "e";
                            break;
                        case "Õ"://24
                            _ConvertResult += "e";
                            break;
                        case "Ò"://25
                            _ConvertResult += "e";
                            break;
                        case "Ó"://26
                            _ConvertResult += "e";
                            break;
                        case "Ô"://27
                            _ConvertResult += "e";
                            break;
                        case "Ö"://28
                            _ConvertResult += "e";
                            break;
                        case "ã"://29
                            _ConvertResult += "o";
                            break;
                        case "ß"://30
                            _ConvertResult += "o";
                            break;
                        case "á"://31
                            _ConvertResult += "o";
                            break;
                        case "â"://32
                            _ConvertResult += "o";
                            break;
                        case "ä"://33
                            _ConvertResult += "o";
                            break;
                        case "«"://34
                            _ConvertResult += "o";
                            break;
                        case "è"://35
                            _ConvertResult += "o";
                            break;
                        case "å"://36
                            _ConvertResult += "o";
                            break;
                        case "æ"://37
                            _ConvertResult += "o";
                            break;
                        case "ç"://38
                            _ConvertResult += "o";
                            break;
                        case "é"://39
                            _ConvertResult += "o";
                            break;
                        case "¬"://40
                            _ConvertResult += "o";
                            break;
                        case "í"://41
                            _ConvertResult += "o";
                            break;
                        case "ê"://42
                            _ConvertResult += "o";
                            break;
                        case "ë"://43
                            _ConvertResult += "o";
                            break;
                        case "ì"://44
                            _ConvertResult += "o";
                            break;
                        case "î"://45
                            _ConvertResult += "o";
                            break;
                        case "ó"://46
                            _ConvertResult += "u";
                            break;
                        case "ï"://47
                            _ConvertResult += "u";
                            break;
                        case "ñ"://48
                            _ConvertResult += "u";
                            break;
                        case "ò"://49
                            _ConvertResult += "u";
                            break;
                        case "ô"://50
                            _ConvertResult += "u";
                            break;
                        case "­"://51
                            _ConvertResult += "u";
                            break;
                        case "ø"://52
                            _ConvertResult += "u";
                            break;
                        case "õ"://53
                            _ConvertResult += "u";
                            break;
                        case "ö"://54
                            _ConvertResult += "u";
                            break;
                        case "÷"://55
                            _ConvertResult += "u";
                            break;
                        case "ù"://56
                            _ConvertResult += "u";
                            break;
                        case "ý"://57
                            _ConvertResult += "y";
                            break;
                        case "ú"://58
                            _ConvertResult += "y";
                            break;
                        case "û"://59
                            _ConvertResult += "y";
                            break;
                        case "ü"://60
                            _ConvertResult += "y";
                            break;
                        case "þ"://61
                            _ConvertResult += "y";
                            break;
                        case "¡"://67
                            _ConvertResult += "A";
                            break;
                        case "¢"://73
                            _ConvertResult += "A";
                            break;
                        case "£"://84
                            _ConvertResult += "E";
                            break;
                        case "¤"://95
                            _ConvertResult += "O";
                            break;
                        case "¥"://101
                            _ConvertResult += "O";
                            break;
                        case "Ý"://122
                            _ConvertResult += "i";
                            break;
                        case "×"://123
                            _ConvertResult += "i";
                            break;
                        case "Ø"://124
                            _ConvertResult += "i";
                            break;
                        case "Ü"://125
                            _ConvertResult += "i";
                            break;
                        case "Þ"://126
                            _ConvertResult += "i";
                            break;
                        case "§"://133
                            _ConvertResult += "D";
                            break;
                        case "®"://134
                            _ConvertResult += "d";
                            break;
                        default:
                            _ConvertResult += _Temp;
                            break;
                    }
                }
                return _ConvertResult;
            }
            #endregion

            else
            {
                return "Wrong type !";
            }
        }
        /// <summary>
        /// _TypeCOnvert=1 (Convert from UNI), _TypeCOnvert=2 (Convert from VNI), _TypeCOnvert=3 (Convert from ABC)
        /// _outputType=1 (Convert to UNI), _outputType=2 (Convert to VNI), _outputType=3 (Convert to ABC)
        /// </summary>
        /// <param name="_Source"></param>
        /// <param name="_TypeConvert"></param>
        /// <param name="_outputType"></param>
        /// <returns></returns>
        public static string ConvertStringText(string _Source, int _TypeConvert, int _outputType)
        {
            if (string.IsNullOrEmpty(_Source.Trim()))
                return string.Empty;
            string _ConvertResult = "";
            string _Temp = "";

            #region UNI
            if (_TypeConvert == 1)
            {
                for (int i = 1; i <= _Source.Length; i++)
                {
                    _Temp = Strings.Mid(_Source, i, 1);
                    switch (_Temp)
                    {
                        case "á"://1
                            _ConvertResult += _outputType == 2 ? "aù" : "¸";
                            break;
                        case "à"://2
                            _ConvertResult += _outputType == 2 ? "aø" : "µ";
                            break;
                        case "ả"://3
                            _ConvertResult += _outputType == 2 ? "aû" : "¶";
                            break;
                        case "ã"://4
                            _ConvertResult += _outputType == 2 ? "aõ" : "·";
                            break;
                        case "ạ"://5
                            _ConvertResult += _outputType == 2 ? "aï" : "¹";
                            break;
                        case "ă"://6
                            _ConvertResult += _outputType == 2 ? "aê" : "¨";
                            break;
                        case "ắ"://7
                            _ConvertResult += _outputType == 2 ? "aé" : "¾";
                            break;
                        case "ằ"://8
                            _ConvertResult += _outputType == 2 ? "aè" : "»";
                            break;
                        case "ẳ"://9
                            _ConvertResult += _outputType == 2 ? "aú" : "¼";
                            break;
                        case "ẵ"://10
                            _ConvertResult += _outputType == 2 ? "aü" : "½";
                            break;
                        case "ặ"://11
                            _ConvertResult += _outputType == 2 ? "aë" : "Æ";
                            break;
                        case "â"://12
                            _ConvertResult += _outputType == 2 ? "aâ" : "©";
                            break;
                        case "ấ"://13
                            _ConvertResult += _outputType == 2 ? "aá" : "Ê";
                            break;
                        case "ầ"://14
                            _ConvertResult += _outputType == 2 ? "aà" : "Ç";
                            break;
                        case "ẩ"://15
                            _ConvertResult += _outputType == 2 ? "aû" : "È";
                            break;
                        case "ẫ"://16
                            _ConvertResult += _outputType == 2 ? "aã" : "É";
                            break;
                        case "ậ"://17
                            _ConvertResult += _outputType == 2 ? "aä" : "Ë";
                            break;
                        case "é"://18
                            _ConvertResult += _outputType == 2 ? "eù" : "Ð";
                            break;
                        case "è"://19
                            _ConvertResult += _outputType == 2 ? "eø" : "Ì";
                            break;
                        case "ẻ"://20
                            _ConvertResult += _outputType == 2 ? "eû" : "Î";
                            break;
                        case "ẽ"://21
                            _ConvertResult += _outputType == 2 ? "eõ" : "Ï";
                            break;
                        case "ẹ"://22
                            _ConvertResult += _outputType == 2 ? "eï" : "Ñ";
                            break;
                        case "ê"://23
                            _ConvertResult += _outputType == 2 ? "eâ" : "ª";
                            break;
                        case "ế"://24
                            _ConvertResult += _outputType == 2 ? "eá" : "Õ";
                            break;
                        case "ề"://25
                            _ConvertResult += _outputType == 2 ? "eà" : "Ò";
                            break;
                        case "ể"://26
                            _ConvertResult += _outputType == 2 ? "eå" : "Ó";
                            break;
                        case "ễ"://27
                            _ConvertResult += _outputType == 2 ? "eã" : "Ô";
                            break;
                        case "ệ"://28
                            _ConvertResult += _outputType == 2 ? "eä" : "Ö";
                            break;
                        case "ó"://29
                            _ConvertResult += _outputType == 2 ? "où" : "ã";
                            break;
                        case "ò"://30
                            _ConvertResult += _outputType == 2 ? "oø" : "ß";
                            break;
                        case "ỏ"://31
                            _ConvertResult += _outputType == 2 ? "oû" : "á";
                            break;
                        case "õ"://32
                            _ConvertResult += _outputType == 2 ? "oõ" : "â";
                            break;
                        case "ọ"://33
                            _ConvertResult += _outputType == 2 ? "oï" : "ä";
                            break;
                        case "ô"://34
                            _ConvertResult += _outputType == 2 ? "oâ" : "«";
                            break;
                        case "ố"://35
                            _ConvertResult += _outputType == 2 ? "oá" : "è";
                            break;
                        case "ồ"://36
                            _ConvertResult += _outputType == 2 ? "oà" : "å";
                            break;
                        case "ổ"://37
                            _ConvertResult += _outputType == 2 ? "oå" : "æ";
                            break;
                        case "ỗ"://38
                            _ConvertResult += _outputType == 2 ? "oã" : "ç";
                            break;
                        case "ộ"://39
                            _ConvertResult += _outputType == 2 ? "oä" : "é";
                            break;
                        case "ơ"://40
                            _ConvertResult += _outputType == 2 ? "ô" : "¬";
                            break;
                        case "ớ"://41
                            _ConvertResult += _outputType == 2 ? "ôù" : "í";
                            break;
                        case "ờ"://42
                            _ConvertResult += _outputType == 2 ? "ôø" : "ê";
                            break;
                        case "ở"://43
                            _ConvertResult += _outputType == 2 ? "ôû" : "ë";
                            break;
                        case "ỡ"://44
                            _ConvertResult += _outputType == 2 ? "ôõ" : "ì";
                            break;
                        case "ợ"://45
                            _ConvertResult += _outputType == 2 ? "ôï" : "î";
                            break;
                        case "ú"://46
                            _ConvertResult += _outputType == 2 ? "uù" : "ó";
                            break;
                        case "ù"://47
                            _ConvertResult += _outputType == 2 ? "uø" : "ï";
                            break;
                        case "ủ"://48
                            _ConvertResult += _outputType == 2 ? "uû" : "ñ";
                            break;
                        case "ũ"://49
                            _ConvertResult += _outputType == 2 ? "uõ" : "ò";
                            break;
                        case "ụ"://50
                            _ConvertResult += _outputType == 2 ? "uõ" : "ô";
                            break;
                        case "ư"://51
                            _ConvertResult += _outputType == 2 ? "ö" : "­";
                            break;
                        case "ứ"://52
                            _ConvertResult += _outputType == 2 ? "uù" : "ø";
                            break;
                        case "ừ"://53
                            _ConvertResult += _outputType == 2 ? "öø" : "õ";
                            break;
                        case "ử"://54
                            _ConvertResult += _outputType == 2 ? "uû" : "ö";
                            break;
                        case "ữ"://55
                            _ConvertResult += _outputType == 2 ? "öõ" : "÷";
                            break;
                        case "ự"://56
                            _ConvertResult += _outputType == 2 ? "öï" : "ù";
                            break;
                        case "ý"://57
                            _ConvertResult += _outputType == 2 ? "yù" : "ý";
                            break;
                        case "ỳ"://58
                            _ConvertResult += _outputType == 2 ? "yø" : "ú";
                            break;
                        case "ỷ"://59
                            _ConvertResult += _outputType == 2 ? "yû" : "û";
                            break;
                        case "ỹ"://60
                            _ConvertResult += _outputType == 2 ? "yõ" : "ü";
                            break;
                        case "ỵ"://61
                            _ConvertResult += _outputType == 2 ? "î" : "y";
                            break;
                        case "Á"://62
                            _ConvertResult += _outputType == 2 ? "AÙ" : "A1";
                            break;
                        case "À"://63
                            _ConvertResult += _outputType == 2 ? "AØ" : "A2";
                            break;
                        case "Ả"://64
                            _ConvertResult += _outputType == 2 ? "AÛ" : "A3";
                            break;
                        case "Ã"://65
                            _ConvertResult += _outputType == 2 ? "AÕ" : "A4";
                            break;
                        case "Ạ"://66
                            _ConvertResult += _outputType == 2 ? "AÏ" : "A5";
                            break;
                        case "Ă"://67
                            _ConvertResult += _outputType == 2 ? "AÊ" : "¡";// 
                            break;
                        case "Ắ"://68
                            _ConvertResult += _outputType == 2 ? "AÉ" : "¡1";
                            break;
                        case "Ằ"://69
                            _ConvertResult += _outputType == 2 ? "AÈ" : "¡2";
                            break;
                        case "Ẳ"://70
                            _ConvertResult += _outputType == 2 ? "AÚ" : "¡3";
                            break;
                        case "Ẵ"://71
                            _ConvertResult += _outputType == 2 ? "AÜ" : "¡4";
                            break;
                        case "Ặ"://72
                            _ConvertResult += _outputType == 2 ? "AË" : "¡5";
                            break;
                        case "Â"://73
                            _ConvertResult += _outputType == 2 ? "AÂ" : "¢";
                            break;
                        case "Ấ"://74
                            _ConvertResult += _outputType == 2 ? "AÁ" : "¢1";
                            break;
                        case "Ầ"://75
                            _ConvertResult += _outputType == 2 ? "AÀ" : "¢2";
                            break;
                        case "Ẩ"://76
                            _ConvertResult += _outputType == 2 ? "AÅ" : "¢3";
                            break;
                        case "Ẫ"://77
                            _ConvertResult += _outputType == 2 ? "AÃ" : "¢4";
                            break;
                        case "Ậ"://78
                            _ConvertResult += _outputType == 2 ? "AÄ" : "¢5";
                            break;
                        case "É"://79
                            _ConvertResult += _outputType == 2 ? "EÙ" : "E1";
                            break;
                        case "È"://80
                            _ConvertResult += _outputType == 2 ? "EØ" : "E2";
                            break;
                        case "Ẻ"://81
                            _ConvertResult += _outputType == 2 ? "EÛ" : "E3";
                            break;
                        case "Ẽ"://82
                            _ConvertResult += _outputType == 2 ? "EÕ" : "E4";
                            break;
                        case "Ẹ"://83
                            _ConvertResult += _outputType == 2 ? "EÏ" : "E5";
                            break;
                        case "Ê"://84
                            _ConvertResult += _outputType == 2 ? "EÂ" : "£";
                            break;
                        case "Ế"://85
                            _ConvertResult += _outputType == 2 ? "EÁ" : "£1";
                            break;
                        case "Ề"://86
                            _ConvertResult += _outputType == 2 ? "EÀ" : "£2";
                            break;
                        case "Ể"://87
                            _ConvertResult += _outputType == 2 ? "EÅ" : "£3";
                            break;
                        case "Ễ"://88
                            _ConvertResult += _outputType == 2 ? "EÃ" : "£4";
                            break;
                        case "Ệ"://89
                            _ConvertResult += _outputType == 2 ? "EÄ" : "£5";
                            break;
                        case "Ó"://90
                            _ConvertResult += _outputType == 2 ? "OÙ" : "O1";
                            break;
                        case "Ò"://91
                            _ConvertResult += _outputType == 2 ? "OØ" : "O2";
                            break;
                        case "Ỏ"://92
                            _ConvertResult += _outputType == 2 ? "OÛ" : "O3";
                            break;
                        case "Õ"://93
                            _ConvertResult += _outputType == 2 ? "OÕ" : "O4";
                            break;
                        case "Ọ"://94
                            _ConvertResult += _outputType == 2 ? "OÏ" : "O5";
                            break;
                        case "Ô"://95
                            _ConvertResult += _outputType == 2 ? "OÂ" : "¤";
                            break;
                        case "Ố"://96
                            _ConvertResult += _outputType == 2 ? "OÁ" : "¤1";
                            break;
                        case "Ồ"://97
                            _ConvertResult += _outputType == 2 ? "OÀ" : "¤2";
                            break;
                        case "Ổ"://98
                            _ConvertResult += _outputType == 2 ? "OÅ" : "¤3";
                            break;
                        case "Ỗ"://99
                            _ConvertResult += _outputType == 2 ? "OÃ" : "¤4";
                            break;
                        case "Ộ"://100
                            _ConvertResult += _outputType == 2 ? "OÄ" : "¤5";
                            break;
                        case "Ơ"://101
                            _ConvertResult += _outputType == 2 ? "Ô" : "¥";
                            break;
                        case "Ớ"://102
                            _ConvertResult += _outputType == 2 ? "ÔÙ" : "¥1";
                            break;
                        case "Ờ"://103
                            _ConvertResult += _outputType == 2 ? "ÔØ" : "¥2";
                            break;
                        case "Ở"://104
                            _ConvertResult += _outputType == 2 ? "ÔÛ" : "¥3";
                            break;
                        case "Ỡ"://105
                            _ConvertResult += _outputType == 2 ? "ÔÕ" : "¥4";
                            break;
                        case "Ợ"://106
                            _ConvertResult += _outputType == 2 ? "ÔÏ" : "¥5";
                            break;
                        case "Ú"://107
                            _ConvertResult += _outputType == 2 ? "UÙ" : "U1";
                            break;
                        case "Ù"://108
                            _ConvertResult += _outputType == 2 ? "UØ" : "U2";
                            break;
                        case "Ủ"://109
                            _ConvertResult += _outputType == 2 ? "UÛ" : "U3";
                            break;
                        case "Ũ"://110
                            _ConvertResult += _outputType == 2 ? "UÕ" : "U4";
                            break;
                        case "Ụ"://111
                            _ConvertResult += _outputType == 2 ? "UÏ" : "U5";
                            break;
                        case "Ư"://112
                            _ConvertResult += _outputType == 2 ? "Ö" : "¦";
                            break;
                        case "Ứ"://113
                            _ConvertResult += _outputType == 2 ? "UÙ" : "¦1";
                            break;
                        case "Ừ"://114
                            _ConvertResult += _outputType == 2 ? "ÖØ" : "¦2";
                            break;
                        case "Ử"://115
                            _ConvertResult += _outputType == 2 ? "UÛ" : "¦3";
                            break;
                        case "Ữ"://116
                            _ConvertResult += _outputType == 2 ? "UÕ" : "¦4";
                            break;
                        case "Ự"://117
                            _ConvertResult += _outputType == 2 ? "ÖÏ" : "¦5";
                            break;
                        case "Ý"://118
                            _ConvertResult += _outputType == 2 ? "YÙ" : "Y1";
                            break;
                        case "Ỳ"://119
                            _ConvertResult += _outputType == 2 ? "YØ" : "Y2";
                            break;
                        case "Ỷ"://120
                            _ConvertResult += _outputType == 2 ? "YÛ" : "Y3";
                            break;
                        case "Ỹ"://121
                            _ConvertResult += _outputType == 2 ? "YÕ" : "Y4";
                            break;
                        case "í"://122
                            _ConvertResult += _outputType == 2 ? "í" : "Ý";
                            break;
                        case "ì"://123
                            _ConvertResult += _outputType == 2 ? "ì" : "×";
                            break;
                        case "ỉ"://124
                            _ConvertResult += _outputType == 2 ? "æ" : "Ø";
                            break;
                        case "ĩ"://125
                            _ConvertResult += _outputType == 2 ? "ó" : "Ü";
                            break;
                        case "ị"://126
                            _ConvertResult += _outputType == 2 ? "ò" : "Þ";
                            break;
                        case "Ỵ"://127
                            _ConvertResult += _outputType == 2 ? "Î" : "Y5";
                            break;
                        case "Í"://128
                            _ConvertResult += _outputType == 2 ? "Í" : "I1";
                            break;
                        case "Ì"://129
                            _ConvertResult += _outputType == 2 ? "Ì" : "I2";
                            break;
                        case "Ỉ"://130
                            _ConvertResult += _outputType == 2 ? "Æ" : "I3";
                            break;
                        case "Ĩ"://131
                            _ConvertResult += _outputType == 2 ? "Ó" : "I4";
                            break;
                        case "Ị"://132
                            _ConvertResult += _outputType == 2 ? "Ò" : "I5";
                            break;
                        case "Đ"://133
                            _ConvertResult += _outputType == 2 ? "Ñ" : "§";
                            break;
                        case "đ"://134
                            _ConvertResult += _outputType == 2 ? "ñ" : "®";
                            break;
                        default:
                            _ConvertResult += _Temp;
                            break;
                    }
                }

                return _ConvertResult;
            }
            #endregion

            #region VNI
            else if (_TypeConvert == 2)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Pos", typeof(int));
                dt.Columns.Add("Source", typeof(string));
                dt.Columns.Add("Convert", typeof(string));
                dt.Columns.Add("ConvertABC", typeof(string));
                //134 row
                dt.Rows.Add(1, "aù", "á", "¸");
                dt.Rows.Add(2, "aø", "à", "µ");
                dt.Rows.Add(3, "aû", "ả", "¶");
                dt.Rows.Add(4, "aõ", "ã", "•");
                dt.Rows.Add(5, "aï", "ạ", "¹");
                dt.Rows.Add(6, "aê", "ă", "¨");
                dt.Rows.Add(7, "aé", "ắ", "¾");
                dt.Rows.Add(8, "aè", "ằ", "»");
                dt.Rows.Add(9, "aú", "ẳ", "¼");
                dt.Rows.Add(10, "aü", "ẵ", "½");
                dt.Rows.Add(11, "aë", "ặ", "Æ");
                dt.Rows.Add(12, "aâ", "â", "©");
                dt.Rows.Add(13, "aá", "ấ", "Ê");
                dt.Rows.Add(14, "aà", "ầ", "Ç");
                dt.Rows.Add(15, "aå", "ả", "È");
                dt.Rows.Add(16, "aã", "ẫ", "É");
                dt.Rows.Add(17, "aä", "ậ", "Ë");
                dt.Rows.Add(18, "eù", "é", "Ð");
                dt.Rows.Add(19, "eø", "è", "Ì");
                dt.Rows.Add(20, "eû", "ẻ", "Î");
                dt.Rows.Add(21, "eõ", "ẽ", "Ï");
                dt.Rows.Add(22, "eï", "ẹ", "Ñ");
                dt.Rows.Add(23, "eâ", "ê", "ª");
                dt.Rows.Add(24, "eá", "ế", "Õ");
                dt.Rows.Add(25, "eà", "ề", "Ò");
                dt.Rows.Add(26, "eå", "ể", "Ó");
                dt.Rows.Add(27, "eã", "ễ", "Ô");
                dt.Rows.Add(28, "eä", "ệ", "Ö");
                dt.Rows.Add(29, "où", "ó", "ã");
                dt.Rows.Add(30, "oø", "ò", "ß");
                dt.Rows.Add(31, "oû", "ỏ", "á");
                dt.Rows.Add(32, "oõ", "õ", "â");
                dt.Rows.Add(33, "oï", "ọ", "ä");
                dt.Rows.Add(34, "oâ", "ô", "«");
                dt.Rows.Add(35, "oá", "ố", "è");
                dt.Rows.Add(36, "oà", "ồ", "å");
                dt.Rows.Add(37, "oå", "ổ", "æ");
                dt.Rows.Add(38, "oã", "ỗ", "ç");
                dt.Rows.Add(39, "oä", "ộ", "é");
                dt.Rows.Add(40, "ô", "ơ", "¬");
                dt.Rows.Add(41, "ôù", "ớ", "í");
                dt.Rows.Add(42, "ôø", "ờ", "ê");
                dt.Rows.Add(43, "ôû", "ở", "ë");
                dt.Rows.Add(44, "ôõ", "ỡ", "ì");
                dt.Rows.Add(45, "ôï", "ợ", "î");
                dt.Rows.Add(46, "uù", "ú", "ó");
                dt.Rows.Add(47, "uø", "ù", "ï");
                dt.Rows.Add(48, "uû", "ủ", "ñ");
                dt.Rows.Add(49, "uõ", "ũ", "ò");
                dt.Rows.Add(50, "uï", "ụ", "ô");
                dt.Rows.Add(51, "ö", "ư", "­");
                dt.Rows.Add(52, "öù", "ứ", "ø");
                dt.Rows.Add(53, "öø", "ừ", "õ");
                dt.Rows.Add(54, "öû", "ử", "ö");
                dt.Rows.Add(55, "öõ", "ữ", "÷");
                dt.Rows.Add(56, "öï", "ự", "ù");
                dt.Rows.Add(57, "yù", "ý", "ý");
                dt.Rows.Add(58, "yø", "ỳ", "ú");
                dt.Rows.Add(59, "yû", "ỷ", "û");
                dt.Rows.Add(60, "yõ", "ỹ", "ü");
                dt.Rows.Add(61, "î", "ỵ", "þ");
                dt.Rows.Add(62, "AÙ", "Á", "A1");
                dt.Rows.Add(63, "AØ", "À", "A2");
                dt.Rows.Add(64, "AÛ", "Ả", "A3");
                dt.Rows.Add(65, "AÕ", "Ã", "A4");
                dt.Rows.Add(66, "AÏ", "Ạ", "A5");
                dt.Rows.Add(67, "AÊ", "Ă", "¡");
                dt.Rows.Add(68, "AÉ", "Ắ", "¡1");
                dt.Rows.Add(69, "AÈ", "Ằ", "¡2");
                dt.Rows.Add(70, "AÚ", "Ẳ", "¡3");
                dt.Rows.Add(71, "AÜ", "Ẵ", "¡4");
                dt.Rows.Add(72, "AË", "Ă", "¡");
                dt.Rows.Add(73, "AÂ", "Â", "¢");
                dt.Rows.Add(74, "AÁ", "Ấ", "¢1");
                dt.Rows.Add(75, "AÀ", "Ầ", "¢2");
                dt.Rows.Add(76, "AÅ", "Ẩ", "¢3");
                dt.Rows.Add(77, "AÃ", "Ẫ", "¢4");
                dt.Rows.Add(78, "AÄ", "Â", "¢5");
                dt.Rows.Add(79, "EÙ", "É", "E1");
                dt.Rows.Add(80, "EØ", "È", "E2");
                dt.Rows.Add(81, "EÛ", "Ẻ", "E3");
                dt.Rows.Add(82, "EÕ", "Ẽ", "E4");
                dt.Rows.Add(83, "EÏ", "Ẹ", "E5");
                dt.Rows.Add(84, "EÂ", "Ê", "£");
                dt.Rows.Add(85, "EÁ", "Ế", "£1");
                dt.Rows.Add(86, "EÀ", "Ề", "£2");
                dt.Rows.Add(87, "EÅ", "Ể", "£3");
                dt.Rows.Add(88, "EÃ", "Ễ", "£4");
                dt.Rows.Add(89, "EÄ", "Ệ", "£5");
                dt.Rows.Add(90, "OÙ", "Ó", "O1");
                dt.Rows.Add(91, "OØ", "Ò", "O2");
                dt.Rows.Add(92, "OÛ", "Ỏ", "O3");
                dt.Rows.Add(93, "OÕ", "Õ", "O4");
                dt.Rows.Add(94, "OÏ", "Ọ", "O5");
                dt.Rows.Add(95, "OÂ", "Ô", "¥");
                dt.Rows.Add(96, "OÁ", "Ố", "¤1");
                dt.Rows.Add(97, "OÀ", "Ồ", "¤2");
                dt.Rows.Add(98, "OÅ", "Ổ", "¤3");
                dt.Rows.Add(99, "OÃ", "Ỗ", "¤4");
                dt.Rows.Add(100, "OÄ", "Ộ", "¤5");
                dt.Rows.Add(101, "Ô", "Ơ", "¥");
                dt.Rows.Add(102, "ÔÙ", "Ớ", "¥1");
                dt.Rows.Add(103, "ÔØ", "Ờ", "¥2");
                dt.Rows.Add(104, "ÔÛ", "Ở", "¥3");
                dt.Rows.Add(105, "ÔÕ", "Ỡ", "¥4");
                dt.Rows.Add(106, "ÔÏ", "Ợ", "¥5");
                dt.Rows.Add(107, "UÙ", "Ú", "U1");
                dt.Rows.Add(108, "UØ", "Ù", "U2");
                dt.Rows.Add(109, "UÛ", "Ủ", "U3");
                dt.Rows.Add(110, "UÕ", "Ũ", "U4");
                dt.Rows.Add(111, "UÏ", "Ụ", "U5");
                dt.Rows.Add(112, "Ö", "Ư", "¦");
                dt.Rows.Add(113, "ÖÙ", "Ứ", "¦1");
                dt.Rows.Add(114, "ÖØ", "Ừ", "¦2");
                dt.Rows.Add(115, "ÖÛ", "Ử", "¦3");
                dt.Rows.Add(116, "ÖÕ", "Ữ", "¦4");
                dt.Rows.Add(117, "ÖÏ", "Ự", "¦5");
                dt.Rows.Add(118, "YÙ", "Ý", "Y1");
                dt.Rows.Add(119, "YØ", "Ỳ", "Y2");
                dt.Rows.Add(120, "YÛ", "Ỷ", "Y3");
                dt.Rows.Add(121, "YÕ", "Ỹ", "Y4");
                dt.Rows.Add(122, "í", "í", "Ý");
                dt.Rows.Add(123, "ì", "ì", "×");
                dt.Rows.Add(124, "æ", "ỉ", "Ø");
                dt.Rows.Add(125, "ó", "ĩ", "Ü");
                dt.Rows.Add(126, "ò", "ị", "Þ");
                dt.Rows.Add(127, "Î", "Ỵ", "Y5");
                dt.Rows.Add(128, "Í", "Í", "I1");
                dt.Rows.Add(129, "Ì", "Ì", "I2");
                dt.Rows.Add(130, "Æ", "Ỉ", "I3");
                dt.Rows.Add(131, "Ó", "Ĩ", "I4");
                dt.Rows.Add(132, "Ò", "Ị", "I5");
                dt.Rows.Add(133, "Ñ", "Đ", "§");
                dt.Rows.Add(134, "ñ", "đ", "®");

                string _SourceTemp = _Source;
                string _Char = "";
                int _Pos = 0;

                do
                {
                    if (_SourceTemp.Length >= 2)
                    {
                        _Char = Strings.Mid(_SourceTemp, 1, 2);
                        _Pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                _Pos = i;
                                break;
                            }
                        }

                        if (_Pos > 0)
                        {
                            _ConvertResult += _outputType == 1 ? dt.Rows[_Pos - 1][2].ToString() : dt.Rows[_Pos - 1][3].ToString();
                            _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 2);
                        }
                        else
                        {
                            _Char = Strings.Mid(_SourceTemp, 1, 1);
                            _Pos = 0;
                            for (int i = 1; i <= 134; i++)
                            {
                                if (_Char == dt.Rows[i - 1][1].ToString())
                                {
                                    _Pos = i;
                                    break;
                                }
                            }
                            if (_Pos > 0)
                            {
                                _ConvertResult += _outputType == 1 ? dt.Rows[_Pos - 1][2].ToString() : dt.Rows[_Pos - 1][3].ToString();
                                _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                            }
                            else
                            {
                                _Char = Strings.Mid(_SourceTemp, 1, 1);
                                _ConvertResult += _Char;
                                _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                            }
                        }

                    }
                    else
                    {
                        _Char = Strings.Mid(_SourceTemp, 1, 1);
                        _Pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                _Pos = i;
                                break;
                            }
                        }
                        if (_Pos > 0)
                        {
                            _ConvertResult += _outputType == 1 ? dt.Rows[_Pos - 1][2].ToString() : dt.Rows[_Pos - 1][3].ToString();
                            _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                        }
                        else
                        {
                            _Char = Strings.Mid(_SourceTemp, 1, 1);
                            _ConvertResult += _Char;
                            _SourceTemp = Strings.Right(_SourceTemp, _SourceTemp.Length - 1);
                        }
                    }

                } while (_SourceTemp.Length > 0);

                return _ConvertResult;

            }
            #endregion

            #region ABC
            else if (_TypeConvert == 3)
            {
                for (int i = 1; i <= _Source.Length; i++)
                {
                    _Temp = Strings.Mid(_Source, i, 1);
                    switch (_Temp)
                    {
                        case "¸"://1
                            _ConvertResult += _outputType == 1 ? "á" : "aù";
                            break;
                        case "µ"://2
                            _ConvertResult += _outputType == 1 ? "à" : "aø";
                            break;
                        case "¶"://3
                            _ConvertResult += _outputType == 1 ? "ả" : "aû";
                            break;
                        case "•"://4
                            _ConvertResult += _outputType == 1 ? "ã" : "aõ";
                            break;
                        case "¹"://5
                            _ConvertResult += _outputType == 1 ? "ạ" : "aï";
                            break;
                        case "¨"://6
                            _ConvertResult += _outputType == 1 ? "ă" : "aê";
                            break;
                        case "¾"://7
                            _ConvertResult += _outputType == 1 ? "ắ" : "aé";
                            break;
                        case "»"://8
                            _ConvertResult += _outputType == 1 ? "ằ" : "aè";
                            break;
                        case "¼"://9
                            _ConvertResult += _outputType == 1 ? "ẳ" : "aú";
                            break;
                        case "½"://10
                            _ConvertResult += _outputType == 1 ? "ẵ" : "aü";
                            break;
                        case "Æ"://11
                            _ConvertResult += _outputType == 1 ? "ặ" : "aë";
                            break;
                        case "©"://12
                            _ConvertResult += _outputType == 1 ? "â" : "aâ";
                            break;
                        case "Ê"://13
                            _ConvertResult += _outputType == 1 ? "ấ" : "aá";
                            break;
                        case "Ç"://14
                            _ConvertResult += _outputType == 1 ? "ầ" : "aà";
                            break;
                        case "È"://15
                            _ConvertResult += _outputType == 1 ? "ẩ" : "aå";
                            break;
                        case "É"://16
                            _ConvertResult += _outputType == 1 ? "a" : "aã";
                            break;
                        case "Ë"://17
                            _ConvertResult += _outputType == 1 ? "ậ" : "aä";
                            break;
                        case "Ð"://18
                            _ConvertResult += _outputType == 1 ? "é" : "eù";
                            break;
                        case "Ì"://19
                            _ConvertResult += _outputType == 1 ? "è" : "eø";
                            break;
                        case "Î"://20
                            _ConvertResult += _outputType == 1 ? "ẻ" : "eû";
                            break;
                        case "Ï"://21
                            _ConvertResult += _outputType == 1 ? "ẽ" : "eõ";
                            break;
                        case "Ñ"://22
                            _ConvertResult += _outputType == 1 ? "ẹ" : "eï";
                            break;
                        case "ª"://23
                            _ConvertResult += _outputType == 1 ? "ê" : "eâ";
                            break;
                        case "Õ"://24
                            _ConvertResult += _outputType == 1 ? "ế" : "eá";
                            break;
                        case "Ò"://25
                            _ConvertResult += _outputType == 1 ? "ề" : "eà";
                            break;
                        case "Ó"://26
                            _ConvertResult += _outputType == 1 ? "ể" : "eå";
                            break;
                        case "Ô"://27
                            _ConvertResult += _outputType == 1 ? "ễ" : "eã";
                            break;
                        case "Ö"://28
                            _ConvertResult += _outputType == 1 ? "ệ" : "eä";
                            break;
                        case "ã"://29
                            _ConvertResult += _outputType == 1 ? "ó" : "où";
                            break;
                        case "ß"://30
                            _ConvertResult += _outputType == 1 ? "ò" : "oø";
                            break;
                        case "á"://31
                            _ConvertResult += _outputType == 1 ? "ỏ" : "oû";
                            break;
                        case "â"://32
                            _ConvertResult += _outputType == 1 ? "õ" : "oõ";
                            break;
                        case "ä"://33
                            _ConvertResult += _outputType == 1 ? "ọ" : "oï";
                            break;
                        case "«"://34
                            _ConvertResult += _outputType == 1 ? "ô" : "oâ";
                            break;
                        case "è"://35
                            _ConvertResult += _outputType == 1 ? "ố" : "oá";
                            break;
                        case "å"://36
                            _ConvertResult += _outputType == 1 ? "ồ" : "oà";
                            break;
                        case "æ"://37
                            _ConvertResult += _outputType == 1 ? "ổ" : "oå";
                            break;
                        case "ç"://38
                            _ConvertResult += _outputType == 1 ? "ỗ" : "oã";
                            break;
                        case "é"://39
                            _ConvertResult += _outputType == 1 ? "ộ" : "oä";
                            break;
                        case "¬"://40
                            _ConvertResult += _outputType == 1 ? "ơ" : "ô";
                            break;
                        case "í"://41
                            _ConvertResult += _outputType == 1 ? "ớ" : "ôù";
                            break;
                        case "ê"://42
                            _ConvertResult += _outputType == 1 ? "ờ" : "ôø";
                            break;
                        case "ë"://43
                            _ConvertResult += _outputType == 1 ? "ở" : "ôû";
                            break;
                        case "ì"://44
                            _ConvertResult += _outputType == 1 ? "ỡ" : "ôõ";
                            break;
                        case "î"://45
                            _ConvertResult += _outputType == 1 ? "ợ" : "ôï";
                            break;
                        case "ó"://46
                            _ConvertResult += _outputType == 1 ? "ú" : "uù";
                            break;
                        case "ï"://47
                            _ConvertResult += _outputType == 1 ? "ù" : "uø";
                            break;
                        case "ñ"://48
                            _ConvertResult += _outputType == 1 ? "ủ" : "uû";
                            break;
                        case "ò"://49
                            _ConvertResult += _outputType == 1 ? "ũ" : "uõ";
                            break;
                        case "ô"://50
                            _ConvertResult += _outputType == 1 ? "ụ" : "uï";
                            break;
                        case "­"://51
                            _ConvertResult += _outputType == 1 ? "ư" : "ö";
                            break;
                        case "ø"://52
                            _ConvertResult += _outputType == 1 ? "ứ" : "öù";
                            break;
                        case "õ"://53
                            _ConvertResult += _outputType == 1 ? "ừ" : "öø";
                            break;
                        case "ö"://54
                            _ConvertResult += _outputType == 1 ? "ử" : "ö";
                            break;
                        case "÷"://55
                            _ConvertResult += _outputType == 1 ? "ữ" : "öõ";
                            break;
                        case "ù"://56
                            _ConvertResult += _outputType == 1 ? "ự" : "öï";
                            break;
                        case "ý"://57
                            _ConvertResult += _outputType == 1 ? "ý" : "yù";
                            break;
                        case "ú"://58
                            _ConvertResult += _outputType == 1 ? "ỳ" : "yø";
                            break;
                        case "û"://59
                            _ConvertResult += _outputType == 1 ? "ỷ" : "yû";
                            break;
                        case "ü"://60
                            _ConvertResult += _outputType == 1 ? "ỹ" : "yõ";
                            break;
                        case "þ"://61
                            _ConvertResult += _outputType == 1 ? "ỵ" : "î";
                            break;
                        case "¡"://67
                            _ConvertResult += _outputType == 1 ? "Ă" : "AÊ";
                            break;
                        case "¢"://73
                            _ConvertResult += _outputType == 1 ? "Â" : "AÂ";
                            break;
                        case "£"://84
                            _ConvertResult += _outputType == 1 ? "Ê" : "EÂ";
                            break;
                        case "¤"://95
                            _ConvertResult += _outputType == 1 ? "Ô" : "OÂ";
                            break;
                        case "¥"://101
                            _ConvertResult += _outputType == 1 ? "O" : "Ô";
                            break;
                        case "Ý"://122
                            _ConvertResult += _outputType == 1 ? "í" : "í";
                            break;
                        case "×"://123
                            _ConvertResult += _outputType == 1 ? "ì" : "ì";
                            break;
                        case "Ø"://124
                            _ConvertResult += _outputType == 1 ? "ỉ" : "æ";
                            break;
                        case "Ü"://125
                            _ConvertResult += _outputType == 1 ? "ĩ" : "ó";
                            break;
                        case "Þ"://126
                            _ConvertResult += _outputType == 1 ? "ị" : "ò";
                            break;
                        case "§"://133
                            _ConvertResult += _outputType == 1 ? "Đ" : "Ñ";
                            break;
                        case "®"://134
                            _ConvertResult += _outputType == 1 ? "đ" : "ñ";
                            break;
                        default:
                            _ConvertResult += _Temp;
                            break;
                    }
                }
                return _ConvertResult;
            }
            #endregion

            else
            {
                return "Wrong type !";
            }
        }
        /// <summary>
        /// Lấy số thứ tự
        /// </summary>
        /// <param name="_num">số tt cần chuyển</param>
        /// <param name="_loai">1: ABC - 2: LA Mã</param>
        /// <returns></returns>
        public static string LaySTT(int _num, int _loai)
        {
            if (_loai == 1)
            {
                switch (_num)
                {
                    case 1:
                        return "A";
                    case 2:
                        return "B";
                    case 3:
                        return "C";
                    case 4:
                        return "D";
                    case 5:
                        return "E";
                    case 6:
                        return "F";
                    case 7:
                        return "G";
                    case 8:
                        return "H";
                    case 9:
                        return "I";
                    case 10:
                        return "J";
                    case 11:
                        return "K";
                    case 12:
                        return "L";
                    case 13:
                        return "M";
                    case 14:
                        return "N";
                    case 15:
                        return "O";
                }
            }
            else if (_loai == 2)
            {
                switch (_num)
                {
                    case 1:
                        return "I";
                    case 2:
                        return "II";
                    case 3:
                        return "III";
                    case 4:
                        return "IV";
                    case 5:
                        return "V";
                    case 6:
                        return "VI";
                    case 7:
                        return "VII";
                    case 8:
                        return "VIII";
                    case 9:
                        return "IX";
                    case 10:
                        return "X";
                    case 11:
                        return "XI";
                    case 12:
                        return "XII";
                    case 13:
                        return "XIII";
                    case 14:
                        return "XIV";
                    case 15:
                        return "XV";
                }
            }
            return "";
        }
    }

    public static class DateTimeConverter
    {
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
    }
    
}

