using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Data;
//Tạo ra combobox có nhiều cột
namespace MultiColumnComboBox
{
    public class MultiColumnComboBox : ComboBox
    {
        private bool PressedKey = false;
        private bool _AutoComplete;
        private bool _AutoDropdown;
        private Color _BackColorEven = Color.White;
        private Color _BackColorOdd = Color.FromArgb(255, 241, 250, 255);
        private string _ColumnNameString = "";
        private int _ColumnWidthDefault = 75;
        private string _ColumnWidthString = "";
        private int _LinkedColumnIndex;
        private TextBox _LinkedTextBox;
        private int _LinkedColumnIndex2;
        private TextBox _LinkedTextBox2;

        private int _TotalWidth = 0;
        private int _ValueMemberColumnIndex = 0;
        DataTable dtData = new DataTable();

        private Collection<string> _ColumnNames = new Collection<string>();
        private Collection<int> _ColumnWidths = new Collection<int>();

        public MultiColumnComboBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;

            // If all of your boxes will be RightToLeft, uncomment 
            // the following line to make RTL the default.
            //RightToLeft = RightToLeft.Yes;

            // Remove the Context Menu to disable pasting 
            ContextMenu = new ContextMenu();
        }

        public event System.EventHandler OpenSearchForm;

        public bool AutoComplete
        {
            get
            {
                return _AutoComplete;
            }
            set
            {
                _AutoComplete = value;
            }
        }

        public bool AutoDropdown
        {
            get
            {
                return _AutoDropdown;
            }
            set
            {
                _AutoDropdown = value;
            }
        }

        public Color BackColorEven
        {
            get
            {
                return _BackColorEven;
            }
            set
            {
                _BackColorEven = value;
            }
        }

        public Color BackColorOdd
        {
            get
            {
                return _BackColorOdd;
            }
            set
            {
                _BackColorOdd = value;
            }
        }

        public Collection<string> ColumnNameCollection
        {
            get
            {
                return _ColumnNames;
            }
        }

        public string ColumnNames
        {
            get
            {
                return _ColumnNameString;
            }

            set
            {
                // If the column string is blank, leave it blank.
                // The default width will be used for all columns.
                if (!Convert.ToBoolean(value.Trim().Length))
                {
                    _ColumnNameString = "";
                }
                else if (value != null)
                {
                    char[] delimiterChars = { ',', ';', ':' };
                    string[] columnNames = value.Split(delimiterChars);

                    if (!DesignMode)
                    {
                        _ColumnNames.Clear();
                    }

                    // After splitting the string into an array, iterate
                    // through the strings and check that they're all valid.
                    foreach (string s in columnNames)
                    {
                        // Does it have length?
                        if (Convert.ToBoolean(s.Trim().Length))
                        {
                            if (!DesignMode)
                            {
                                _ColumnNames.Add(s.Trim());
                            }
                        }
                        else // The value is blank
                        {
                            throw new NotSupportedException("Column names can not be blank.");
                        }
                    }
                    _ColumnNameString = value;
                }
            }
        }

        public Collection<int> ColumnWidthCollection
        {
            get
            {
                return _ColumnWidths;
            }
        }

        public int ColumnWidthDefault
        {
            get
            {
                return _ColumnWidthDefault;
            }
            set
            {
                _ColumnWidthDefault = value;
            }
        }

        public string ColumnWidths
        {
            get
            {
                return _ColumnWidthString;
            }

            set
            {
                // If the column string is blank, leave it blank.
                // The default width will be used for all columns.
                if (!Convert.ToBoolean(value.Trim().Length))
                {
                    _ColumnWidthString = "";
                }
                else if (value != null)
                {
                    char[] delimiterChars = { ',', ';', ':' };
                    string[] columnWidths = value.Split(delimiterChars);
                    string invalidValue = "";
                    int invalidIndex = -1;
                    int idx = 1;
                    int intValue;

                    // After splitting the string into an array, iterate
                    // through the strings and check that they're all integers
                    // or blanks
                    foreach (string s in columnWidths)
                    {
                        // If it has length, test if it's an integer
                        if (Convert.ToBoolean(s.Trim().Length))
                        {
                            // It's not an integer. Flag the offending value.
                            if (!int.TryParse(s, out intValue))
                            {
                                invalidIndex = idx;
                                invalidValue = s;
                            }
                            else // The value was okay. Increment the item index.
                            {
                                idx++;
                            }
                        }
                        else // The value is a space. Use the default width.
                        {
                            idx++;
                        }
                    }

                    // If an invalid value was found, raise an exception.
                    if (invalidIndex > -1)
                    {
                        string errMsg;

                        errMsg = "Invalid column width '" + invalidValue + "' located at column " + invalidIndex.ToString();
                        throw new ArgumentOutOfRangeException(errMsg);
                    }
                    else // The string is fine
                    {
                        _ColumnWidthString = value;

                        // Only set the values of the collections at runtime.
                        // Setting them at design time doesn't accomplish 
                        // anything and causes errors since the collections 
                        // don't exist at design time.
                        if (!DesignMode)
                        {
                            _ColumnWidths.Clear();
                            foreach (string s in columnWidths)
                            {
                                // Initialize a column width to an integer
                                if (Convert.ToBoolean(s.Trim().Length))
                                {
                                    _ColumnWidths.Add(Convert.ToInt32(s));
                                }
                                else // Initialize the column to the default
                                {
                                    _ColumnWidths.Add(_ColumnWidthDefault);
                                }
                            }

                            // If the column is bound to data, set the column widths
                            // for any columns that aren't explicitly set by the 
                            // string value entered by the programmer
                            if (DataManager != null)
                            {
                                InitializeColumns();
                            }
                        }
                    }
                }
            }
        }

        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawVariable)
                {
                    throw new NotSupportedException("Needs to be DrawMode.OwnerDrawVariable");
                }
                base.DrawMode = value;
            }
        }

        public new ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
            set
            {
                if (value != ComboBoxStyle.DropDown)
                {
                    throw new NotSupportedException("ComboBoxStyle.DropDown is the only supported style");
                }
                base.DropDownStyle = value;
            }
        }
        public int LinkedColumnIndex2
        {
            get { return _LinkedColumnIndex2; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("A column index can not be negative");
                }
                _LinkedColumnIndex2 = value;
            }
        }


        public int LinkedColumnIndex
        {
            get
            {
                return _LinkedColumnIndex;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("A column index can not be negative");
                }
                _LinkedColumnIndex = value;
            }
        }

        public TextBox LinkedTextBox
        {
            get
            {
                return _LinkedTextBox;
            }
            set
            {
                _LinkedTextBox = value;

                if (_LinkedTextBox != null)
                {
                    // Set any default properties of the Linked Textbox here
                    // _LinkedTextBox.ReadOnly = true;
                    _LinkedTextBox.TabStop = false;
                }
            }
        }
        public TextBox LinkedTextBox2
        {
            get { return _LinkedTextBox2; }
            set
            {
                _LinkedTextBox2 = value;

                if (_LinkedTextBox2 != null)
                {
                    // Set any default properties of the Linked Textbox here
                    // _LinkedTextBox.ReadOnly = true;
                    _LinkedTextBox2.TabStop = false;
                }
            }
        }
        public int TotalWidth
        {
            get
            {
                return _TotalWidth;
            }
        }
        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);

            InitializeColumns();
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            if (DesignMode)
                return;

            e.DrawBackground();

            Rectangle boundsRect = e.Bounds;
            int lastRight = 0;

            Color brushForeColor;
            if ((e.State & DrawItemState.Selected) == 0)
            {
                // Item is not selected. Use BackColorOdd & BackColorEven
                Color backColor;

                backColor = Convert.ToBoolean(e.Index % 2) ? _BackColorOdd : _BackColorEven;
                using (SolidBrush brushBackColor = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brushBackColor, e.Bounds);
                }
                brushForeColor = Color.Black;
            }
            else
            {
                // Item is selected. Use ForeColor = White
                brushForeColor = Color.White;
            }

            using (Pen linePen = new Pen(SystemColors.GrayText))
            {
                using (SolidBrush brush = new SolidBrush(brushForeColor))
                {
                    if (!Convert.ToBoolean(_ColumnNames.Count))
                    {
                        e.Graphics.DrawString(Convert.ToString(Items[e.Index]), Font, brush, boundsRect);
                    }
                    else
                    {
                        // If the ComboBox is displaying a RightToLeft language, draw it this way.
                        if (RightToLeft.Equals(RightToLeft.Yes))
                        {
                            // Define a StringFormat object to make the string display RTL.
                            StringFormat rtl = new StringFormat();
                            rtl.Alignment = StringAlignment.Near;
                            rtl.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                            // Draw the strings in reverse order from high column index to zero column index.
                            for (int colIndex = _ColumnNames.Count - 1; colIndex >= 0; colIndex--)
                            {
                                if (Convert.ToBoolean(_ColumnWidths[colIndex]))
                                {
                                    string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], _ColumnNames[colIndex]));

                                    boundsRect.X = lastRight;
                                    boundsRect.Width = (int)_ColumnWidths[colIndex];
                                    lastRight = boundsRect.Right;

                                    // Draw the string with the RTL object.
                                    e.Graphics.DrawString(item, Font, brush, boundsRect, rtl);

                                    if (colIndex > 0)
                                    {
                                        e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                                    }
                                }
                            }
                        }
                        // If the ComboBox is displaying a LeftToRight language, draw it this way.
                        else
                        {
                            // Display the strings in ascending order from zero to the highest column.
                            for (int colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
                            {
                                if (Convert.ToBoolean(_ColumnWidths[colIndex]))
                                {
                                    string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], _ColumnNames[colIndex]));

                                    boundsRect.X = lastRight;
                                    boundsRect.Width = (int)_ColumnWidths[colIndex];
                                    lastRight = boundsRect.Right;
                                    e.Graphics.DrawString(item, Font, brush, boundsRect);

                                    if (colIndex < _ColumnNames.Count - 1)
                                    {
                                        e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            e.DrawFocusRectangle();
        }
        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);

            if (_TotalWidth > 0)
            {
                if (Items.Count > MaxDropDownItems)
                {
                    // The vertical scrollbar is present. Add its width to the total.
                    // If you don't then RightToLeft languages will have a few characters obscured.
                    this.DropDownWidth = _TotalWidth + SystemInformation.VerticalScrollBarWidth;
                }
                else
                {
                    this.DropDownWidth = _TotalWidth;
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Use the Delete or Escape Key to blank out the ComboBox and
            // allow the user to type in a new value
            try
            {
                if (((e.KeyCode == Keys.Delete) ||
                    (e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.Space) || (e.KeyCode == Keys.Back)) && this.SelectedText == "")
                {
                    SelectedIndex = -1;
                    Text = "";
                    if (_LinkedTextBox != null)
                    {
                        _LinkedTextBox.Text = "";
                    }
                    if (_LinkedTextBox2 != null)
                    {
                        _LinkedTextBox2.Text = "";
                    }
                }
                else if (e.KeyCode == Keys.F3)
                {
                    // Fire the OpenSearchForm Event
                    if (OpenSearchForm != null)
                    {
                        OpenSearchForm(this, System.EventArgs.Empty);
                    }
                }
            }
            catch
            {

            }
        }


        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            //AUTOCOMPLETING

            //WARNING: With VB.Net 2003 there is a strange behaviour. This event is raised not just when any key is pressed
            //but also when the Me.Text property changes. Particularly, it happens when you write in a fast way (for example
            //you press 2 keys and the event is raised 3 times). To manage this we have added a boolean variable PressedKey that
            //is set to true in the OnKeyPress Event

            string sTypedText = null;
            int iFoundIndex = 0;
            object oFoundItem = null;
            string sFoundText = null;
            string sAppendText = null;

            Debug.WriteLine("OnKeyUp " + this.Text);
            if (e.KeyCode != Keys.Escape)
            {

                if (this.DroppedDown == false)
                {
                    this.DroppedDown = true;
                }

            }
            if (PressedKey)
            {
                //Ignoring alphanumeric chars
                switch (e.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Right:
                    case Keys.Up:
                    case Keys.Delete:
                    case Keys.Down:
                    case Keys.End:
                    case Keys.Home:
                    case Keys.Enter:
                        return;
                }

                //Get the Typed Text and Find it in the list
                sTypedText = this.Text;
                if (e.KeyCode != Keys.Back)
                {
                    iFoundIndex = this.FindString(sTypedText);
                }
                else
                {
                    iFoundIndex = this.FindStringExact(sTypedText);
                }

                //If we found the Typed Text in the list then Autocomplete
                if (iFoundIndex >= 0 && !string.IsNullOrEmpty(this.Text))
                {

                    //Get the Item from the list (Return Type depends if Datasource was bound
                    // or List Created)
                    oFoundItem = this.Items[iFoundIndex];

                    //Use the ListControl.GetItemText to resolve the Name in case the Combo
                    // was Data bound
                    sFoundText = this.GetItemText(oFoundItem);

                    //Append then found text to the typed text to preserve case
                    sAppendText = sFoundText.Substring(sTypedText.Length);
                    this.Text = sTypedText; // +sAppendText;

                    //Select the Appended Text
                    this.SelectionStart = sTypedText.Length;
                   // this.SelectionLength = sAppendText.Length;

                    if (e.KeyCode == Keys.Enter)
                    {
                        iFoundIndex = this.FindStringExact(this.Text);
                        this.SelectedIndex = iFoundIndex;
                        SendKeys.Send(Constants.vbTab);
                        e.Handled = true;
                    }
                }
                else
                {
                    //Forcing SelectedItem to Nothing if we can't autocomplete
                    this.SelectedIndex = -1;
                    this.SelectedItem = null;
                    if (_LinkedTextBox != null)
                    {
                        _LinkedTextBox.Text = "";
                    }
                    if (_LinkedTextBox2 != null)
                    {
                        _LinkedTextBox2.Text = "";
                    }
                }
                if (e.KeyCode == Keys.F4) this.SelectAll();
            }
            PressedKey = false;
        }
        #region OnKeyPress
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            PressedKey = true;
            base.OnKeyPress(e);

        }
        #endregion

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e); //Added after version 1.3 on 01/31/2008

            if (_LinkedTextBox != null && SelectedItem != null)
            {
                if (_LinkedColumnIndex < _ColumnNames.Count)
                {
                    _LinkedTextBox.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames[_LinkedColumnIndex]));
                }
            }
            else if (_LinkedTextBox != null)
            {
                _LinkedTextBox.Text = "";
            }
            //LinktextBox2
            if (_LinkedTextBox2 != null && SelectedItem != null)
            {
                if (_LinkedColumnIndex2 < _ColumnNames.Count)
                {
                    _LinkedTextBox2.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames[_LinkedColumnIndex2]));
                }
            }
            else if (_LinkedTextBox2 != null)
            {
                _LinkedTextBox2.Text = "";
            }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (_LinkedTextBox != null && SelectedItem != null)
            {
                if (_LinkedColumnIndex < _ColumnNames.Count)
                {
                    _LinkedTextBox.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames[_LinkedColumnIndex]));
                }
            }
            else if (_LinkedTextBox != null)
            {
                _LinkedTextBox.Text = "";
            }
            //LinkedTextBox2
            if (_LinkedTextBox2 != null && SelectedItem != null)
            {
                if (_LinkedColumnIndex2 < _ColumnNames.Count)
                {
                    _LinkedTextBox2.Text = Convert.ToString(FilterItemOnProperty(SelectedItem, _ColumnNames[_LinkedColumnIndex2]));
                }
            }
            else if (_LinkedTextBox2 != null)
            {
                _LinkedTextBox2.Text = "";
            }

        }

        protected override void OnValueMemberChanged(EventArgs e)
        {
            base.OnValueMemberChanged(e);

            InitializeValueMemberColumn();
        }

        private void InitializeColumns()
        {
            dtData = (DataTable)DataSource;
            if (!Convert.ToBoolean(_ColumnNameString.Length))
            {
                PropertyDescriptorCollection propertyDescriptorCollection = DataManager.GetItemProperties();

                _TotalWidth = 0;
                _ColumnNames.Clear();
                if (_LinkedTextBox != null)
                    _LinkedTextBox.Text = "";
                if (_LinkedTextBox2 != null)
                    _LinkedTextBox2.Text = "";
                for (int colIndex = 0; colIndex < propertyDescriptorCollection.Count; colIndex++)
                {
                    _ColumnNames.Add(propertyDescriptorCollection[colIndex].Name);
                    // If the index is greater than the collection of explicitly
                    // set column widths, set any additional columns to the default
                    if (colIndex >= _ColumnWidths.Count)
                    {
                        _ColumnWidths.Add(_ColumnWidthDefault);
                    }
                    _TotalWidth += _ColumnWidths[colIndex];
                }
            }
            else
            {
                _TotalWidth = 0;

                for (int colIndex = 0; colIndex < _ColumnNames.Count; colIndex++)
                {
                    // If the index is greater than the collection of explicitly
                    // set column widths, set any additional columns to the default
                    if (colIndex >= _ColumnWidths.Count)
                    {
                        _ColumnWidths.Add(_ColumnWidthDefault);
                    }
                    _TotalWidth += _ColumnWidths[colIndex];
                }

            }

            // Check to see if the programmer is trying to display a column
            // in the linked textbox that is greater than the columns in the 
            // ComboBox. I handle this error by resetting it to zero.
            if (_LinkedColumnIndex >= _ColumnNames.Count)
            {
                _LinkedColumnIndex = 0; // Or replace this with an OutOfBounds Exception
            }
            if (_LinkedColumnIndex2 >= _ColumnNames.Count)
            {
                _LinkedColumnIndex2 = 0; // Or replace this with an OutOfBounds Exception
            }
        }

        private void InitializeValueMemberColumn()
        {
            int colIndex = 0;
            foreach (String columnName in _ColumnNames)
            {
                if (String.Compare(columnName, ValueMember, true, CultureInfo.CurrentUICulture) == 0)
                {
                    _ValueMemberColumnIndex = colIndex;
                    break;
                }
                colIndex++;
            }
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.DroppedDown == false)
                this.DroppedDown = true;
        }
    }
}
