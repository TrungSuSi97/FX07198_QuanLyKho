using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Data;
using System.Collections.Generic;

namespace TPH.LIS.Common.Controls
{
    /// <summary>
    /// (eraghi)
    /// Extended CheckedListBox with binding facilities (Value property)
    /// </summary>
    [ToolboxBitmap(typeof(CheckedListBox))]
    public class CustomCheckedListBox : CheckedListBox
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomCheckedListBox()
        {
            this.CheckOnClick = true;
        }
        /// <summary>
        ///    Gets or sets the property to display for this CustomControls.CheckedListBox.
        ///
        /// Returns:
        ///     A System.String specifying the name of an object property that is contained
        ///     in the collection specified by the CustomControls.CheckedListBox.DataSource
        ///     property. The default is an empty string ("").
        /// </summary>
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string DisplayMember
        {
            get
            {
                return base.DisplayMember;
            }
            set
            {
                base.DisplayMember = value;

            }
        }
        /// <summary>
        ///    Gets or sets the property to display for this CustomControls.CheckedListBox.
        ///
        /// Returns:
        ///     A System.String specifying the name of an object property that is contained
        ///     in the collection specified by the CustomControls.CheckedListBox.DataSource
        ///     property. The default is an empty string ("").
        /// </summary>
        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataValueFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataValueFieldEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        public new string ValueMember
        {
            get
            {
                return base.ValueMember;
            }
            set
            {
                base.ValueMember = value;

            }
        }

        /// <summary>
        /// Gets or sets the data source for this CustomControls.CheckedListBox.
        /// Returns:
        ///    An object that implements the System.Collections.IList or System.ComponentModel.IListSource
        ///    interfaces, such as a System.Data.DataSet or an System.Array. The default
        ///    is null.
        ///
        ///Exceptions:
        ///  System.ArgumentException:
        ///    The assigned value does not implement the System.Collections.IList or System.ComponentModel.IListSource
        ///    interfaces.
        /// </summary>
        [DefaultValue("")]
        [AttributeProvider(typeof(IListSource))]
        [RefreshProperties(RefreshProperties.All)]
        [Browsable(true)]
        public new object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;

            }
        }
        /// <summary>
        /// Gets and sets an integer value based on checked items(bitwise)
        /// </summary>
        [Bindable(true), Browsable(true)]
        public string ItemValues(int indexChecked, string columnName)
        {
            string itemValue = "";
            ///Gets checked items in decimal mode from binary mode
                try
                {
                    DataTable dt = (DataTable)((ListBox)this).DataSource;
                    if (dt.Rows.Count > 0)
                    {
                        itemValue = dt.Rows[indexChecked][columnName].ToString();
                    }
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return itemValue;
        }
        public string ItemList(string columnName)
        {
            string itemValue = string.Empty;
            ///Gets checked items in decimal mode from binary mode
            try
            {
                DataTable dt = (DataTable)((ListBox)this).DataSource;
                if (dt != null)
                {
                    foreach (int indexChecked in this.CheckedIndices)
                    {
                        if (itemValue.Trim() == "")
                        {
                            itemValue += "'" + dt.Rows[indexChecked][columnName].ToString() + "'";
                        }
                        else
                        {
                            itemValue += ",'" + dt.Rows[indexChecked][columnName].ToString() + "'";
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemValue;
        }
        public List<string> ItemCheckedList(string columnName)
        {
            List<string> itemValue = new List<string>();
            ///Gets checked items in decimal mode from binary mode
            try
            {
                DataTable dt = (DataTable)((ListBox)this).DataSource;
                if (dt != null)
                {
                    foreach (int indexChecked in this.CheckedIndices)
                    {
                        itemValue.Add(dt.Rows[indexChecked][columnName].ToString());
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemValue;
        }
        public List<string> AllItemList2(string columnName)
        {
            List<string> itemValue = new List<string>();
            ///Gets checked items in decimal mode from binary mode
            try
            {
                DataTable dt = (DataTable)((ListBox)this).DataSource;
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        itemValue.Add(dr[columnName].ToString());
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemValue;
        }
        public string AllItemList(string columnName)
        {
            string itemValue = string.Empty;
            ///Gets checked items in decimal mode from binary mode
            try
            {
                DataTable dt = (DataTable)((ListBox)this).DataSource;
                if (dt != null)
                {
                    foreach (DataRow dr  in dt.Rows)
                    {
                        if (itemValue.Trim() == "")
                        {
                            itemValue += "'" + dr[columnName].ToString() + "'";
                        }
                        else
                        {
                            itemValue += ",'" + dr[columnName].ToString() + "'";
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemValue;
        }
        public void SetCheckedAllItem(bool isChecked)
        {
            string itemValue = string.Empty;
            ///Gets checked items in decimal mode from binary mode
            try
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    SetItemChecked(i, isChecked);
                }
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int _value;

        /// <summary>
        /// Gets and sets an integer value based on checked items(bitwise)
        /// </summary>
        [Bindable(true), Browsable(true)]
        public int Value
        {
            get
            {
                ///Gets checked items in decimal mode from binary mode

                try
                {
                    //each item in list has a number that is binary number in decimal mode
                    //this number represents that number
                    int poweredNumber = 1;
                    //loop in all items of list
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        //if item checked and the value doesn't contains poweredNumber then
                        //add poweredNumber to the value
                        if ((this.GetItemChecked(i)))
                            this._value |= poweredNumber;
                        //else if poweredNumber exists in the value remove from it
                        else if ((this._value & poweredNumber) != 0)
                            this._value -= poweredNumber;

                        //raise to the power
                        poweredNumber *= 2;
                    }
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                return this._value;
            }
            set
            {
                ///sets checked items from binary mode converted from decimal value

                this._value = value;
                try
                {
                    //each item in list has a number that is binary number in decimal mode
                    //this number represents that number
                    int poweredNumber = 1;
                    //loop in all items of list
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        //if poweredNumber exists in the value set checked on item
                        if ((this._value & poweredNumber) != 0)
                            this.SetItemCheckState(i, CheckState.Checked);
                        //else remove checked from item
                        else
                            this.SetItemCheckState(i, CheckState.Unchecked);

                        //raise to the power
                        poweredNumber *= 2;
                    }
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
