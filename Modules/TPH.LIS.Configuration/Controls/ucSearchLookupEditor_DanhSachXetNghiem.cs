﻿using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraGrid.Views.Grid;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Common;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucSearchLookupEditor_DanhSachXetNghiem : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private DataTable InternalSource = null;
        public ucSearchLookupEditor_DanhSachXetNghiem()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;

        }

        private void UcSearchLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (CatchTabKey)
            {
                if (e.KeyData == Keys.Tab && ControlNext != null)
                {
                    e.IsInputKey = true;
                    ControlNext.Focus();
                   
                }
                else if (e.KeyData == (Keys.Tab | Keys.Shift) && ControlBack != null)
                {
                    e.IsInputKey = true;
                    ControlBack.Focus();
                }
            }
        }

        private void UcSearchLookupEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && catchEnterKey )
            {
                if (ChiDinh_Keypress != null)
                {
                    e.Handled = true;
                    txtFind.KeyPress -= TxtFind_KeyPress;
                    ChiDinh_Keypress(sender, new KeyPressEventArgs((char)Keys.Enter));
                }
                else if (ControlNext != null)
                    ControlExtension.LeaveFocusNext(e, ControlNext);
            }
        }
        public void ShowPopup()
        {
            lueChiDinh.ShowPopup();
        }
        public void ClosePopup()
        {
            lueChiDinh.ClosePopup();
        }
        [Category("Custom")]
        public EventHandler ChiDinh_EditValueChanged { get; set; }
        public KeyPressEventHandler ChiDinh_Keypress { get; set; }
        [Category("Custom")]
        public Control ControlBack { get; set; }
        [Category("Custom")]
        public Control ControlNext { get; set; }
        [Category("Custom")]
        public bool CatchEnterKey
        {
            get
            {
                return catchEnterKey;
            }

            set
            {
                catchEnterKey = value;
            }
        }
        [Category("Custom")]
        public bool CatchTabKey
        {
            get
            {
                return catchTabKey;
            }

            set
            {
                catchTabKey = value;
            }
        }
        private bool catchEnterKey = false;
        private bool catchTabKey = false;
        [Category("Custom")]
        public object SelectedValue
        {
            get
            {
                return lueChiDinh.EditValue;
            }

            set
            {
                lueChiDinh.EditValue = value;
            }
        }
        public string GetProfileChar
        {
            get
            {
                if (InternalSource == null || SelectedValue == null)
                    return string.Empty;
                else
                {
                    var dataFound = WorkingServices.SearchResult_OnDatatable(InternalSource, string.Format("MaXN = '{0}'", SelectedValue.ToString()));
                    if (dataFound.Rows.Count > 0)
                    {
                        return dataFound.Rows[0]["IsProfile"].ToString();
                    }
                    else
                        return string.Empty;
                }
            }
        }
        public string LoaiXetNghiem
        {
            get
            {
                if (InternalSource == null || SelectedValue == null)
                    return string.Empty;
                else
                {
                    //LoaiXetNghiem
                    var dataFound = WorkingServices.SearchResult_OnDatatable(InternalSource, string.Format("MaXN = '{0}'", SelectedValue.ToString()));
                    if (dataFound.Rows.Count > 0)
                    {
                        return dataFound.Rows[0]["LoaiXetNghiem"].ToString();
                    }
                    else
                        return string.Empty;
                }
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueChiDinh.Properties.ValueMember;
            }

            set
            {
                lueChiDinh.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueChiDinh.Properties.DisplayMember;
            }

            set
            {
                lueChiDinh.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueChiDinh.Properties.DataSource;
            }

            set
            {
                lueChiDinh.Properties.DataSource = value;
            }
        }
        public DataRowView SelectedDataRowView
        {
            get
            {
                return (DataRowView)lueChiDinh.GetSelectedDataRow();
            }
        }
        private void lueChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && catchEnterKey)
            {
                if (ChiDinh_Keypress != null)
                { TimeSpan ts = DateTime.Now - lasTimeShow;

                    if (ts.TotalSeconds > 1)
                    {
                        e.Handled = true;
                        txtFind.KeyPress -= TxtFind_KeyPress;
                        lueChiDinh.ClosePopup();
                        ChiDinh_Keypress(sender, new KeyPressEventArgs((char)Keys.Enter));
                    }
    
                }
                else if (ControlNext != null)
                    ControlExtension.LeaveFocusNext(e, ControlNext);
            }
        }
        TextEdit txtFind;
        GridView gridSearch;
        bool popUpShowing = false;
        DateTime lasTimeShow = DateTime.Now;
        private void lueChiDinh_Properties_Popup(object sender, EventArgs e)
        {
            popUpShowing = true;
            IPopupControl popup = sender as IPopupControl;
            PopupBaseForm Form = popup.PopupWindow as PopupBaseForm;

            //var btFindLCI = GetPopUpButtonLayoutItem(Form, "btFind");
            //btFindLCI.Visibility = LayoutVisibility.Never;
            //var btClearLCI = GetPopUpButtonLayoutItem(Form, "btClear");
            //btClearLCI.Visibility = LayoutVisibility.Never;

            txtFind = (TextEdit)GetPopUpButtonLayoutItem(Form, "teFind").Control;
            GetPopUpGridViewLayoutItem(Form, ref gridSearch);
            //SearchLookUpEdit currentLook = (SearchLookUpEdit)sender;
            //PopupSearchLookUpEditForm currentPopup = (currentLook as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            //currentPopup.Size = new Size(140, 180);
            lasTimeShow = DateTime.Now;
            txtFind.KeyPress += TxtFind_KeyPress;
           
            popUpShowing = false;
        }
        private void Check_SetValue()
        {
            if (gvLueChiDinhDichVu.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvLueChiDinhDichVu.FocusedRowHandle = 0;
                lueChiDinh.ClosePopup();
            }
        }

        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (catchEnterKey && popUpShowing == false)
                {
                    TimeSpan ts = DateTime.Now - lasTimeShow;

                    if (ts.TotalSeconds > 1)
                    {
                        e.Handled = true;
                        txtFind.KeyPress -= TxtFind_KeyPress;
                        Check_SetValue();
                        if (ChiDinh_Keypress != null)
                        {
                            gvLueChiDinhDichVu.Focus();
                            ChiDinh_Keypress(sender, e);
                        }
                        else if (ControlNext != null)
                            ControlExtension.LeaveFocusNext(new KeyPressEventArgs((char)Keys.Enter), ControlNext);
                    }
                }
            }
        }
        private void TxtFind_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (CatchTabKey)
            {
                if (e.KeyData == Keys.Tab && ControlNext != null)
                {
                    e.IsInputKey = true;
                    Check_SetValue();
                    ControlNext.Focus();
                }
                else if (e.KeyData == (Keys.Tab | Keys.Shift) && ControlBack != null)
                {
                    e.IsInputKey = true;
                    Check_SetValue();
                    ControlBack.Focus();
                }
            }
        }
        LayoutControlItem GetPopUpButtonLayoutItem(PopupBaseForm Form, string buttonName)
        {
            foreach (Control FormC in Form.Controls)
            {
                if (FormC is SearchEditLookUpPopup)
                {
                    SearchEditLookUpPopup SearchPopup = FormC as SearchEditLookUpPopup;
                    foreach (Control SearchPopupC in SearchPopup.Controls)
                    {
                        if (SearchPopupC is LayoutControl)
                        {
                            LayoutControl FormLayout = SearchPopupC as LayoutControl;
                            Control Button = FormLayout.GetControlByName(buttonName);
                          
                            if (Button != null)
                            {
                                return FormLayout.GetItemByControl(Button);
                            }

                        }
                    }
                }
            }
            return null;
        }
        GridView GetPopUpGridViewLayoutItem(PopupBaseForm Form, ref GridView grid)
        {
            foreach (Control FormC in Form.Controls)
            {
                if (FormC is SearchEditLookUpPopup)
                {
                    SearchEditLookUpPopup SearchPopup = FormC as SearchEditLookUpPopup;
                    foreach (var SearchPopupC in SearchPopup.Controls)
                    {
                        if(grid !=null)
                        {
                            break;
                        }
                        SearchControlGrid(SearchPopup, ref grid);
                    }
                }
            }
            return null;
        }
        public void SearchControlGrid(Control ctrl, ref GridView grid)
        {
            foreach (var SearchPopupC in ctrl.Controls)
            {
                if (SearchPopupC is GridControl)
                {
                    grid = (GridView)((GridControl)SearchPopupC).DefaultView;
                    return;
                }
                SearchControlGrid((Control)SearchPopupC, ref grid);
            }
           
        }
        private void ucDevLookupEditor_Enter(object sender, EventArgs e)
        {
            lueChiDinh.Focus();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueChiDinh.IsPopupOpen)
            {
                lueChiDinh.ShowPopup();
            }
        }
        public void Load_DanhMuc(string categoryIn, bool checkAllowGroup, DataTable dataSoureIn)
        {
            var data = dataSoureIn;
            if (dataSoureIn == null)
            {
                data = sysConfig.Data_dm_xetnghiem(categoryIn, checkAllowGroup, string.Empty);
                if (data != null)
                    InternalSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            else
                InternalSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            lueChiDinh.Properties.DataSource = InternalSource;
            lueChiDinh.Properties.ValueMember = "MaXN".ToLower();
            lueChiDinh.Properties.DisplayMember = "TenXN".ToLower();
            lueChiDinh.Properties.AutoHeight = false;
            lueChiDinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;

            gvLueChiDinhDichVu.KeyPress += lueChiDinh_KeyPress;
        }
        private void lueChiDinh_EditValueChanged(object sender, EventArgs e)
        {
            ChiDinh_EditValueChanged?.Invoke(sender, e);
        }

        private void lueChiDinh_Popup(object sender, EventArgs e)
        {
            gvLueChiDinhDichVu.ExpandAllGroups();
        }
    }
}
