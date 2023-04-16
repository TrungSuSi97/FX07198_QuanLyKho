using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq.Expressions;
using System.Management;
using System.Windows.Forms;
using OutlookStyleControls;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.LIS.Common.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.Data;
using System.Reflection;
using System.ComponentModel;

namespace TPH.LIS.Common.Extensions
{
    public class ControlExtension
    {
        private static readonly RegistryExtension registryExtension = new RegistryExtension(0, CommonConstant.RegistrySubKey);
        public static string PropertyName<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return body.Member.Name;
        }
        public static string PropertyNameToLowerCase<T>(Expression<Func<T, object>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }

            return body.Member.Name.ToLower();
        }
        public static string GetDescription<T>(Expression<Func<T, object>> fieldName)
        {
            string result = string.Empty;
            var body = fieldName.Body as MemberExpression;

            if (body == null)
            {
                body = ((UnaryExpression)fieldName.Body).Operand as MemberExpression;
            }
            object[] descriptionAttrs = body.Member.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (descriptionAttrs.Length > 0)
            {
                DescriptionAttribute description = (DescriptionAttribute)descriptionAttrs[0];
                result = (description.Description);
            }

            return result;
        }
        public static void SelectAll_CtrlA(object sender, KeyEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txtBox = sender as TextBox;
                if (txtBox != null && e.Control == true && e.KeyCode == Keys.A)
                {
                    txtBox.SelectAll();
                    e.Handled = true;
                }
            }
        }
        public static string LoadOpenFileDialog_GetOneFile(string filter)
        {
            string fileName = string.Empty;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Multiselect = false;
            fdlg.Filter = filter;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                fileName = fdlg.FileName;
            }
            fdlg.Dispose();
            return fileName;
        }

        public static Image LoadImage()
        {
            Image img = null;
            string filePath = LoadOpenFileDialog_GetOneFile("(*.jpg)|*.jpg");
            if (!string.IsNullOrEmpty(filePath))
            {
                img = Image.FromFile(filePath);
            }
            return img;
        }

        public static void LoadImage_ToPicturebox(PictureBox pb)
        {
            string filePath = LoadOpenFileDialog_GetOneFile("(*.jpg)|*.jpg");
            if (!string.IsNullOrEmpty(filePath))
            {
                pb.Image = Image.FromFile(filePath);
               // pb.ImageLocation = filePath;
            }
        }
        public static void LoadImage_ToPicturebox(PictureBox pb, Size reSize)
        {
            string filePath = LoadOpenFileDialog_GetOneFile("(*.jpg)|*.jpg|(*.png)|*.png");
            if (!string.IsNullOrEmpty(filePath))
            {
                var img = Image.FromFile(filePath);
                var img2 = GraphicSupport.ResizeImage_NoAutoScale(img, reSize);
                pb.Image = img2;
            }
        }
        public static void SetLowerCaseForXGridColumns(GridView gv)
        {
            foreach (GridColumn item in gv.Columns)
            {
                item.FieldName = item.FieldName.ToLower();
            }
            foreach (GridGroupSummaryItem itm in gv.GroupSummary)
            {
                itm.FieldName = itm.FieldName.ToLower();
            }
        }
        public static void BindDataToGrid(
            object dataTable,
            ref DataGridView dataGridView,
            ref BindingNavigator bindingNavigator, bool autoGenerateColumns)
        {
            if (dataGridView != null)
            {
                dataGridView.AutoGenerateColumns = autoGenerateColumns;
                var bindingSource = new BindingSource();
                if (bindingNavigator != null)
                {
                    bindingSource.DataSource = dataTable;
                    dataGridView.DataSource = bindingSource;
                    bindingNavigator.BindingSource = bindingSource;
                }
                else
                    dataGridView.DataSource = dataTable;
            }
        }

        public static void BindDataToGrid(
        object dataTable,
        ref CustomDatagridView dataGridView,
        BindingNavigator bindingNavigator)
        {
            dataGridView.AutoGenerateColumns = false;
            if (bindingNavigator != null)
            {
                var bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView.DataSource = bindingSource;
                bindingNavigator.BindingSource = bindingSource;
            }
            else
                dataGridView.DataSource = dataTable;
        }
        public static void BindDataToGrid(
        object dataTable,
        ref DataGridView dataGridView,
        BindingNavigator bindingNavigator)
        {
            dataGridView.AutoGenerateColumns = false;
            if (bindingNavigator != null)
            {
                var bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView.DataSource = bindingSource;
                bindingNavigator.BindingSource = bindingSource;
            }
            else
                dataGridView.DataSource = dataTable;
        }
        public static void BindToGrid(object dt, ref CustomDatagridView dtg, ref CustomBindingNavigator bv,
            bool autoGenerateColumns)
        {
            
            dtg.AutoGenerateColumns = autoGenerateColumns;
            if (bv != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dtg.DataSource = bs;
                bv.BindingSource = bs;
            }
            else
                dtg.DataSource = dt;
        }

        public static void BindToGrid(object dt, DataGridView dtg, BindingNavigator bv = null)
        {
            dtg.AutoGenerateColumns = false;
            if (bv != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dtg.DataSource = bs;
                bv.BindingSource = bs;
            }
            else
                dtg.DataSource = dt;
        }
        public static void BindToGrid(DataTable dt, ref CustomDatagridView dtg, ref BindingNavigator bv)
        {
            dtg.AutoGenerateColumns = false;

            if (bv != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dtg.DataSource = bs;
                bv.BindingSource = bs;
            }
            else
                dtg.DataSource = dt;
        }
        public static void BindDataToGrid(DataTable dt, ref CustomDatagridView dtg, ref BindingNavigator bv)
        {
            dtg.AutoGenerateColumns = false;

            if (bv != null)
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;
                dtg.DataSource = bindingSource;
                bv.BindingSource = bindingSource;
            }
            else
                dtg.DataSource = dt;
        }
        public static void BindDataToGrid(
            DataTable dataTable,
            ref DataGridView datagridView,
            ref CustomBindingNavigator bindingNavigator)
        {
            datagridView.AutoGenerateColumns = false;

            if (bindingNavigator != null)
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                datagridView.DataSource = bindingSource;
                bindingNavigator.BindingSource = bindingSource;
            }
            else
                datagridView.DataSource = dataTable;
        }
        public static void BindDataToGrid(DataTable dataTable,
   ref DataGridView datagridView,
   ref BindingNavigator bindingNavigator)
        {
            var bindingSource = new BindingSource();
            datagridView.AutoGenerateColumns = false;
            bindingSource.DataSource = dataTable;
            bindingNavigator.BindingSource = bindingSource;
            datagridView.DataSource = bindingSource;
        }
        public static void BindDataToGrid(
                DataTable dataTable,
                ref CustomDatagridView dataGridView,
                ref CustomBindingNavigator bindingNavigator, bool autoGenerateColumns)
        {
            var bindingSource = new BindingSource();
            dataGridView.AutoGenerateColumns = autoGenerateColumns;
            bindingSource.DataSource = dataTable;
            dataGridView.DataSource = bindingSource;
            bindingNavigator.BindingSource = bindingSource;
        }
        public static void BindDataToGrid(DataTable dataTable,
           ref CustomDatagridView datagridView,
           ref CustomBindingNavigator bindingNavigator)
        {
            var bindingSource = new BindingSource();
            datagridView.AutoGenerateColumns = false;
            bindingSource.DataSource = dataTable;
            bindingNavigator.BindingSource = bindingSource;
            datagridView.DataSource = bindingNavigator.BindingSource;
        }

        public static void BindDataToCobobox(
            DataTable dt,
            ref CustomComboBox cbo,
            string valueMember,
            string displayMember)
        {
            cbo.DataSource = dt;
            cbo.ValueMember = valueMember;
            cbo.DisplayMember = displayMember;
            cbo.SelectedIndex = -1;
        }

        public static void BindDataToCobobox(DataTable dt, ref CustomComboBox cbo, string valueMember,
            string displayMember, string displayColumn, string columnWidth)
        {
            cbo.DataSource = dt;
            cbo.ValueMember = valueMember;
            cbo.DisplayMember = displayMember;
            cbo.ColumnNames = displayColumn;
            cbo.ColumnWidths = columnWidth;
            cbo.SelectedIndex = -1;
        }
        public static void BindDataToCobobox(DataTable dt, ref CustomComboBox cbo, string valueMember,
            string displayMember, string displayColumn, string columnWidth, TextBox txt, int linkIndex)
        {
            cbo.DataSource = dt;
            cbo.ValueMember = valueMember;
            cbo.DisplayMember = displayMember;
            cbo.ColumnNames = displayColumn;
            cbo.ColumnWidths = columnWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = linkIndex;
            }
            cbo.SelectedIndex = -1;

        }
        public static void BindDataToCobobox(
            DataTable dataTable,
            ref System.Windows.Forms.ComboBox comboBox,
            string valueMember,
            string displayMember)
        {
            comboBox.DataSource = dataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
            comboBox.SelectedIndex = -1;
        }
        public static void BindDataToCobobox(object dt, ref System.Windows.Forms.ComboBox cbo, string valueMember, string displayMember)
        {
            cbo.DataSource = dt;
            cbo.ValueMember = valueMember;
            cbo.DisplayMember = displayMember;
            cbo.SelectedIndex = -1;
        }
        public static void Check_Uncheck_Datagrid(DataGridView dtg, DataGridViewColumn dgc, bool isCheck)
        {
            if (dtg.RowCount > 0)
            {
                if (dtg is OutlookGrid)
                {
                    for (int i = 0; i < dtg.RowCount; i++)
                    {
                        if (!((OutlookGridRow)dtg.Rows[i]).IsGroupRow)
                            dtg[dgc.Name, i].Value = isCheck;
                    }
                }
                else
                {
                    for (int i = 0; i < dtg.RowCount; i++)
                    {

                        dtg[dgc.Name, i].Value = isCheck;
                    }
                }

            }
        }

        /// <summary>
        /// Hàm đọc tất cả máy in trong máy tính lên ListBox
        /// </summary>
        /// <param name="lstPrinter">ListBox</param>
        /// <param name="registryKey">Key tren regedit</param>
        /// <param name="mainlstPrinter">Danh sách máy in chính </param>
        public static void LoadPrinterName(ListBox lstPrinter, string registryKey, ListBox mainlstPrinter)
        {
            try
            {
                if (mainlstPrinter != null)
                {
                    if (PrinterSettings.InstalledPrinters.Count > 0)
                    {
                        lstPrinter.Items.Clear();
                        foreach (string printerName in PrinterSettings.InstalledPrinters)
                        {
                            if (Printer_Online(printerName))
                            {
                                lstPrinter.Items.Add(printerName);
                            }
                        }

                    }
                }
                else
                {
                    lstPrinter.Items.Clear();
                    lstPrinter.Items.AddRange(mainlstPrinter.Items);
                    var totalPrinters = lstPrinter.Items.Count;
                    if (totalPrinters > 0)
                    {
                        var registryValue = registryExtension.ReadRegistry(registryKey);

                        int index = String.IsNullOrEmpty(registryValue)
                            ? 0
                            : (Int32.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                        if (index < lstPrinter.Items.Count)
                        {
                            lstPrinter.SelectedIndex = String.IsNullOrEmpty(registryValue)
                                ? 0
                                : (Int32.Parse(registryValue) >= totalPrinters ? 0 : NumberConverter.ToInt(registryValue));
                        }
                        else
                        {
                            lstPrinter.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "LoadPrinterName", true, String.Empty);
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
                        if (Printer_Online(printerName))
                        {
                            if (isNormalPrinter)
                            {
                                var page = new PaperSize();
                                var settings = new PrinterSettings();
                                settings.PrinterName = printerName;
                                var ppSizes = settings.PaperSizes;
                                foreach (PaperSize pp in ppSizes)
                                {
                                    if (pp.PaperName.Contains("A4") || pp.PaperName.Contains("Letter"))
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

                        }
                    }
                    if (lstPrinter.InvokeRequired)
                    {
                        lstPrinter.Invoke(new MethodInvoker(delegate
                        {
                            var totalPrinters = lstPrinter.Items.Count;
                            if (totalPrinters > 0)
                            {
                                var registryValue = registryExtension.ReadRegistry(registryKey);

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
                            var registryValue = registryExtension.ReadRegistry(registryKey);

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
                if (!ex.Message.Contains("Cannot access a disposed object"))
                    ErrorService.GetFrameworkErrorMessage(ex, "Load Printer", string.Empty);
            }
        }

        public static void LoadPrinterName(System.Windows.Forms.ComboBox cboPrinter)
        {
            try
            {
                if (PrinterSettings.InstalledPrinters.Count > 0)
                {
                    foreach (string printerName in PrinterSettings.InstalledPrinters)
                    {
                        if (Printer_Online(printerName))
                        {
                            cboPrinter.Items.Add(printerName);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorService.GetFrameworkErrorMessage(ex, "LoadPrinterName", true, String.Empty);
            }
        }
        private static bool Printer_Online(string printerName)
        {

            // Set management scope
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            string printerN = String.Empty;
            foreach (var o in searcher.Get())
            {
                var printer = (ManagementObject)o;
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
        public static bool LeaveFocusNext(KeyPressEventArgs e, Control controlNext)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return false;

            controlNext.Focus();
            if (controlNext is CustomComboBox)
            {
                ((CustomComboBox)controlNext).DroppedDown = true;
            }
            else if (controlNext is TextBox)
            {
                if (((TextBox)controlNext).Multiline == false)
                {
                    ((TextBox)controlNext).SelectAll();
                }
            }

            e.Handled = true;
            return true;
        }
        public static void LeaveFocusNext(PreviewKeyDownEventArgs e, Control controlNext, Control controlBack)
        {
            if (e.KeyData == Keys.Tab)
            {
                controlNext.Focus();
                e.IsInputKey = true;
            }
            else if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
                if (controlBack != null)
                {
                    controlBack.Focus();
                    e.IsInputKey = true;
                }
            }
        }
        /// <summary>
        /// Hàm này chỉ cho phép nhập số vào TextBox
        /// 44: ,
        /// 46: .decimals
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        /// <param name="_decimal">False: số nguyên, True: Số thực</param>
        public static void KeyNumber(KeyPressEventArgs e, bool _decimal)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (_decimal == false)
                {
                    if (!Char.IsNumber(e.KeyChar) && (int)e.KeyChar != 8 && ((char)e.KeyChar).ToString() != "-")
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (!Char.IsNumber(e.KeyChar) && (int)e.KeyChar != 44 && (int)e.KeyChar != 46 && (int)e.KeyChar != 8 && ((char)e.KeyChar).ToString() != "-")
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        public static DataTable SetData_PropertyType(System.Reflection.PropertyInfo[] minfo, DataTable dtSource )
        {
            DataTable dtbeCloned = dtSource.Clone();
            //Check insert column not visilble
            foreach (System.Reflection.PropertyInfo infA in minfo)
            {
                if (!Check_Exists_Column(dtSource, infA.Name))
                {
                    dtSource.Columns.Add(infA.Name, infA.GetType());
                    dtbeCloned.Columns.Add(infA.Name, infA.GetType());

                }
                else if (infA.PropertyType == typeof(bool) || infA.PropertyType == typeof(bool?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(bool);
                }
                else if (infA.PropertyType == typeof(DateTime) || infA.PropertyType == typeof(DateTime?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(DateTime);
                }
                else if (infA.PropertyType == typeof(float) || infA.PropertyType == typeof(float?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(float);
                }
                else if (infA.PropertyType == typeof(int) || infA.PropertyType == typeof(int?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(int);
                }
                else if (infA.PropertyType == typeof(long) || infA.PropertyType == typeof(long?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(long);
                }
                else if (infA.PropertyType == typeof(double) || infA.PropertyType == typeof(double?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(double);
                }
                else if (infA.PropertyType == typeof(decimal) || infA.PropertyType == typeof(decimal?))
                {
                    dtbeCloned.Columns[infA.Name].DataType = typeof(decimal);
                }

            }
            dtbeCloned.AcceptChanges();
            //add data
            DataRow dr = dtbeCloned.NewRow();
            foreach (DataColumn dtc in dtbeCloned.Columns)
            {
                if (dtc.DataType == typeof(bool))
                {
                    dr[dtc.ColumnName] = (dtSource.Rows[0][dtc.ColumnName].ToString() == "1");
                }
                else if (dtc.DataType == typeof(DateTime))
                {
                    if (dtSource.Rows[0][dtc.ColumnName].ToString() == "")
                        dr[dtc.ColumnName] = DBNull.Value;
                    else
                        dr[dtc.ColumnName] = DateTime.Parse(dtSource.Rows[0][dtc.ColumnName].ToString());
                }
                else if (dtc.DataType == typeof(float))
                {
                    if (dtSource.Rows[0][dtc.ColumnName].ToString() == "")
                        dr[dtc.ColumnName] = DBNull.Value;
                    else
                        dr[dtc.ColumnName] = float.Parse(dtSource.Rows[0][dtc.ColumnName].ToString());
                }
                else if (dtc.DataType == typeof(int))
                {
                    if (dtSource.Rows[0][dtc.ColumnName].ToString() == "")
                        dr[dtc.ColumnName] = DBNull.Value;
                    else
                        dr[dtc.ColumnName] = int.Parse(dtSource.Rows[0][dtc.ColumnName].ToString());
                }
                else if (dtc.DataType == typeof(long))
                {
                    if (dtSource.Rows[0][dtc.ColumnName].ToString() == "")
                        dr[dtc.ColumnName] = DBNull.Value;
                    else
                        dr[dtc.ColumnName] = long.Parse(dtSource.Rows[0][dtc.ColumnName].ToString());
                }
                else if (dtc.DataType == typeof(double))
                {
                    if (dtSource.Rows[0][dtc.ColumnName].ToString() == "")
                        dr[dtc.ColumnName] = DBNull.Value;
                    else
                        dr[dtc.ColumnName] = double.Parse(dtSource.Rows[0][dtc.ColumnName].ToString());
                }
                else if (dtc.DataType == typeof(decimal))
                {
                    if (dtSource.Rows[0][dtc.ColumnName].ToString() == "")
                        dr[dtc.ColumnName] = DBNull.Value;
                    else
                        dr[dtc.ColumnName] = decimal.Parse(dtSource.Rows[0][dtc.ColumnName].ToString());
                }
                else
                    dr[dtc.ColumnName] = dtSource.Rows[0][dtc.ColumnName];
            }
            dtbeCloned.Rows.Add(dr);
            return dtbeCloned;
        }
        public static bool Check_Exists_Column(DataTable dt, string Columnname)
        {
            foreach (DataColumn dtc in dt.Columns)
            {
                if (dtc.ColumnName.Equals(Columnname, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public static int CreateGridColumnWithObject(object objInfo, GridView gridView, string preFixColumnname
            , bool captionWithDescription, bool onlyAddWithDescription, bool invisibleColumnNoneCaption, bool allowEdit
            , bool autoSetColorColumn = false, bool grayBackColorReadonly = false
            , string[] readOnlyColumn = null, string[] allowEditColumn = null)
        {
            PropertyInfo[] fiCheck = objInfo.GetType().GetProperties();
            int count = -1;
            int visible = 0;
            foreach (PropertyInfo f in fiCheck)
            {
                var prop = objInfo.GetType().GetProperty(f.Name);
                if (objInfo.GetType().GetProperty(f.Name) != null)
                {
                    var caption = f.Name;
                    var isVisiable = true;
                    if (prop.GetCustomAttributes(false) == null)
                    {
                        if (!invisibleColumnNoneCaption && (!onlyAddWithDescription || captionWithDescription))
                            continue;
                        else if (invisibleColumnNoneCaption)
                            isVisiable = false;
                    }
                    else if (prop.GetCustomAttributes(false).Length == 0)
                    {
                        if (!invisibleColumnNoneCaption && (!onlyAddWithDescription || captionWithDescription))
                            continue;
                        else if (invisibleColumnNoneCaption)
                            isVisiable = false;
                    }
                    else if (captionWithDescription)
                    {
                        caption = ((DescriptionAttribute)prop.GetCustomAttributes(false)[0]).Description;
                    }
                    if (isVisiable)
                        visible++;
                    if (!IsExistsColumn(f.Name, gridView))
                    {
                        count++;
                        bool isAllowEdit = allowEdit;
                        if(readOnlyColumn != null)
                        {
                            if(readOnlyColumn.Length >0)
                            {
                                foreach (var item in readOnlyColumn)
                                {
                                    if (item.Equals(f.Name, StringComparison.OrdinalIgnoreCase))
                                    {
                                        isAllowEdit = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (allowEditColumn != null)
                        {
                            if (allowEditColumn.Length > 0)
                            {
                                foreach (var item in allowEditColumn)
                                {
                                    if (item.Equals(f.Name, StringComparison.OrdinalIgnoreCase))
                                    {
                                        isAllowEdit = true;
                                        break;
                                    }
                                }
                            }
                        }

                        InsertNewColToGrid(gridView, preFixColumnname + f.Name.ToLower(), caption, 125
                            , formatType: GetObjectType(prop.PropertyType), formatString: (prop.PropertyType == typeof(DateTime) ? "dd/MM/yyyy" : string.Empty)
                            , bound: GetUnboundColumnTypeType(prop.PropertyType), visible: isVisiable, allowEdit: isAllowEdit, indexVisible: visible, autoSetColorColumn: autoSetColorColumn
                            , dataFieldName: f.Name.ToLower(), grayBackColorReadonly: grayBackColorReadonly);
                    }
                }
            }
            return count;
        }
       public static bool IsExistsColumn(string fieldName, GridView gridView)
        {
            foreach (GridColumn item in gridView.Columns)
            {
                if (item.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
        public static FormatType GetObjectType(Type conversion)
        {
            if (conversion == typeof(int) || conversion == typeof(long) || conversion == typeof(double)
                 || conversion == typeof(float) || conversion == typeof(decimal))
                return FormatType.Numeric;
            else if (conversion == typeof(DateTime))
                return FormatType.DateTime;
            return FormatType.None;
        }
        public static UnboundColumnType GetUnboundColumnTypeType(Type conversion)
        {
            if (conversion == typeof(int) || conversion == typeof(long))
                return UnboundColumnType.Integer;
            else if (conversion == typeof(double) || conversion == typeof(float) || conversion == typeof(decimal))
                return UnboundColumnType.Decimal;
            else if (conversion == typeof(DateTime))
                return UnboundColumnType.DateTime;
            else if (conversion == typeof(bool))
                return UnboundColumnType.Boolean;
            else if (conversion == typeof(string))
                return UnboundColumnType.String;
            return UnboundColumnType.Bound;
        }
        public static void InsertNewColToGrid(GridView gridView,
            string colNameName, string title,
            int width = 70, int? minWidth = null, int? maxWidth = null
            , FormatType? formatType = null, string formatString = null
            , bool groupSummary = false, UnboundColumnType bound = UnboundColumnType.Bound
            , bool visible = true, bool allowEdit = false, int indexVisible = 1, bool autoSetColorColumn = false, string dataFieldName = "", bool grayBackColorReadonly = false)
        {
            var col = new GridColumn(); //gridView.Columns.AddVisible(fieldName, title);
            col.Name = colNameName;
            col.FieldName = string.IsNullOrEmpty(dataFieldName) ? colNameName : dataFieldName;
            col.Caption = title;
            col.UnboundType = bound;
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, colNameName, formatString)});
            }
            if (!allowEdit)
            {
                col.OptionsColumn.AllowEdit = false;
                col.OptionsColumn.ReadOnly = true;
            }
            col.Width = width;
            if (minWidth != null)
            {
                col.MinWidth = 10;
            }
            if (maxWidth != null)
            {
                col.MaxWidth = 500;
            }
            if (bound == UnboundColumnType.DateTime)
                col.ColumnEdit = new RepositoryItemDateEdit();
            else if (bound == UnboundColumnType.String)
            {
                if (dataFieldName.Length >= 3)
                {
                    if (autoSetColorColumn && (dataFieldName.ToLower().Substring(0, 3).Equals("mau") || dataFieldName.ToLower().Contains("colorof")))
                    {
                        var coledit = new RepositoryItemColorPickEdit();
                        coledit.StoreColorAsInteger = true;
                        col.ColumnEdit = coledit;
                    }
                    else
                        col.ColumnEdit = new RepositoryItemTextEdit();
                }
                else
                    col.ColumnEdit = new RepositoryItemTextEdit();
            }
            
            col.Visible = visible;
            if (visible)
            {
                col.VisibleIndex = indexVisible;
            }
            if (grayBackColorReadonly && !allowEdit)
            {
                col.AppearanceCell.BackColor = Color.LightGray;
                col.AppearanceCell.Options.UseBackColor = true;
            }
            gridView.Columns.Add(col);

        }
        public static void Set_CountNumber(DataGridView dtg, string columnname)
        {
            if (dtg.RowCount > 0)
            {
                for (int i = 0; i < dtg.RowCount; i++)
                {
                    dtg[columnname, i].Value = (i + 1).ToString();
                }
            }
           
        }
        public static void Check_SetColorForCheckBoxAndRadio(object sender, Color? colorOnchecked )
        {
            if (sender is RadioButton)
            {
                var obj = (RadioButton)sender;
                obj.BackColor = obj.Checked ? (colorOnchecked.HasValue? colorOnchecked.Value: Color.Yellow) : Color.Empty;
            }
            else if (sender is CheckBox)
            {
                var obj = (CheckBox)sender;
                obj.BackColor = obj.Checked ? (colorOnchecked.HasValue ? colorOnchecked.Value : Color.Yellow) : Color.Empty;
            }
        }
        public static void Set_CheckBox_Radio_CheckedEven(object objIn)
        {
            if (objIn is RadioButton)
            {
                var obj = (RadioButton)objIn;
                obj.CheckedChanged += Object_CheckedChanged;
            }
            else if (objIn is CheckBox)
            {
                var obj = (CheckBox)objIn;
                obj.CheckedChanged += Object_CheckedChanged;
            }
        }
        public static void Object_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                var obj = (RadioButton)sender;
                obj.BackColor = obj.Checked ? Color.Yellow : Color.Empty;
            }
            else if (sender is CheckBox)
            {
                var obj = (CheckBox)sender;
                obj.BackColor = obj.Checked ? Color.Yellow : Color.Empty;
            }
        }
    }
}