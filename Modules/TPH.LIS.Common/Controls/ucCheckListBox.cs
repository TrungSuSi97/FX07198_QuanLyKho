using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class ucCheckListBox : UserControl
    {
        public ucCheckListBox()
        {
            InitializeComponent();
        }
        [Category("Custom Event")]
        public event EventHandler ListSelectedIndexChanged;
        [Category("Custom Event")]
        public event EventHandler CheckboAllCheckedChanged;
        [Category("Custom Event")]
        public event EventHandler TextBoxSearchTextChanged;

        private DataTable dtSource;
        [Category("Custom properties")]
        public DataTable DataSource
        {
            get
            {
                return dtSource;
            }
            set
            {
                dtSource = value;
                chkItemList.DataSource = dtSource;
            }
        }
        private string valueMember = string.Empty;
        [Category("Custom properties")]
        public string ValueMember
        {
            get
            {
                return valueMember;
            }
            set
            {
                valueMember = value;
                chkItemList.ValueMember = valueMember;
            }
        }
        private string displayMember = string.Empty;
        [Category("Custom properties")]
        public string DisplayMember
        {
            get
            {
                return displayMember;
            }
            set
            {
                displayMember = value;
                chkItemList.DisplayMember = displayMember;
            }
        }
        [Category("Custom properties")]
        public string CheckedItemList
        {
            get
            {
                if (chkCheckAll.Checked)
                {
                    return chkItemList.AllItemList(valueMember);
                }
                else
                    return chkItemList.ItemList(valueMember);
            }
        }
        [Category("Custom properties")]
        public List<string> ListCheckedItem
        {
            get
            {
                if (chkCheckAll.Checked)
                {
                    return chkItemList.AllItemList2(valueMember);
                }
                else
                    return chkItemList.ItemCheckedList(valueMember);
            }
        }
        [Category("Custom properties")]
        public bool IsCheckedAll
        {
            get { return chkCheckAll.Checked; }
            set { chkCheckAll.Checked = value; }
        }
        [Category("Custom properties")]
        public string ListCaption
        {
            get { return ucGroupHeader1.GroupCaption; }
            set { ucGroupHeader1.GroupCaption = value; }
        }
        [Category("Custom properties")]
        public bool ValueIsNumberType = false;

        /// <summary>
        /// DataTable đang hiển thị trên checkbox
        /// </summary>
        public DataTable GetCurrentDisplayData
        {
            get { return (DataTable)chkItemList.DataSource; }
        }
        /// <summary>
        /// Danh sách index các item được check
        /// </summary>
        public CheckedListBox.CheckedIndexCollection GetCheckedIndices
        {
            get { return chkItemList.CheckedIndices; }
        }
        protected void chkItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkCheckAll.Checked = false;
            ListSelectedIndexChanged?.Invoke(sender, e);
        }
        private void SearchValue()
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                chkItemList.DataSource = dtSource;
                chkCheckAll.Checked = true;
            }
            else
            {
                string searchFilter = string.Empty;
                if (ValueIsNumberType)
                    searchFilter = string.Format("{0} = {1} or {2} like '%{2}%'", valueMember, Extensions.WorkingServices.EscapeLikeValue(txtSearch.Text.Trim()), displayMember);
                else
                    searchFilter = string.Format("{0} = '{1}' or {2} like '%{1}%'", valueMember, Extensions.WorkingServices.EscapeLikeValue(txtSearch.Text.Trim()), displayMember);
                DataTable dtTemp = Extensions.WorkingServices.SearchResult_OnDatatable_NoneSort(DataSource, searchFilter);
                chkItemList.DataSource = dtTemp;

                chkCheckAll.Checked = false;
                chkItemList.SetCheckedAllItem(true);
            }
            chkItemList.ValueMember = valueMember;
            chkItemList.DisplayMember = displayMember;
        }
        protected void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckAll.Checked && !string.IsNullOrEmpty(txtSearch.Text))
                txtSearch.Text = string.Empty;
            CheckboAllCheckedChanged?.Invoke(sender, e);
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchValue();
            TextBoxSearchTextChanged?.Invoke(sender, e);
        }
    }
}
