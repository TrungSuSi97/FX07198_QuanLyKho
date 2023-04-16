using System;
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
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucSearchLookupEditor_DanhSachTuLuuMau : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_DanhSachTuLuuMau()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;
            this.Leave += UcSearchLookupEditor_Location_Leave;
        }

        private void UcSearchLookupEditor_Location_Leave(object sender, EventArgs e)
        {
            lueDanhSach.ClosePopup();
        }

        private void UcSearchLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (CatchTabKey)
            {
                if (e.KeyData == Keys.Tab && ControlNext != null)
                {
                    ControlNext.Focus();
                    e.IsInputKey = true;
                }
                else if (e.KeyData == (Keys.Tab | Keys.Shift) && ControlBack != null)
                {
                    ControlBack.Focus();
                    e.IsInputKey = true;
                }
            }
        }

        private void UcSearchLookupEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
        }
        [Category("Custom")]
        public event EventHandler EditValueChange;
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
                return lueDanhSach.EditValue;
            }

            set
            {
                lueDanhSach.EditValue = value;
            }
        }
        [Category("Custom")]
        public string SelectedText
        {
            get
            {
                if (lueDanhSach.Properties.DataSource == null || lueDanhSach.EditValue == null)
                    return null;
                else
                {
                    var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueDanhSach.Properties.DataSource, string.Format("{0} = '{1}'", lueDanhSach.Properties.ValueMember, lueDanhSach.EditValue.ToString().Trim()));
                    if (dataFound.Rows.Count > 0)
                    {
                        return dataFound.Rows[0][lueDanhSach.Properties.DisplayMember].ToString();
                    }
                    else
                        return string.Empty;
                }
            }

            set
            {
                if (value == null)
                    lueDanhSach.EditValue = null;
                else
                {
                    var selectValue = GetObjectIdByName(value.ToString());
                    if (!string.IsNullOrEmpty(selectValue))
                        lueDanhSach.EditValue = selectValue;
                    else
                        lueDanhSach.EditValue = null;
                }
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueDanhSach.Properties.ValueMember;
            }

            set
            {
                lueDanhSach.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueDanhSach.Properties.DisplayMember;
            }

            set
            {
                lueDanhSach.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueDanhSach.Properties.DataSource;
            }

            //set
            //{
            //    lueDonVi.Properties.DataSource = value;
            //}
        }
        [Category("Custom")]
        public string GetObjectIdByName(string objectName)
        {
            if (lueDanhSach.Properties.DataSource == null)
                return string.Empty;
            else
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueDanhSach.Properties.DataSource, string.Format("{0} = '{1}'", lueDanhSach.Properties.DisplayMember, objectName.Trim()));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0][lueDanhSach.Properties.ValueMember].ToString();
                }
                else
                    return string.Empty;
            }
        }
        private void lueDonVi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
        }
        TextEdit txtFind;
        GridView gridSearch;
        private void lueDonVi_Properties_Popup(object sender, EventArgs e)
        {
            IPopupControl popup = sender as IPopupControl;
            PopupBaseForm Form = popup.PopupWindow as PopupBaseForm;

            var btFindLCI = (SimpleButton)GetPopUpButtonLayoutItem(Form, "btFind").Control;
            btFindLCI.Text = "Tìm";
            var btClearLCI = (SimpleButton)GetPopUpButtonLayoutItem(Form, "btClear").Control;
            btClearLCI.Text = "Xóa chọn";

            txtFind = (TextEdit)GetPopUpButtonLayoutItem(Form, "teFind").Control;
            GetPopUpGridViewLayoutItem(Form, ref gridSearch);
            //SearchLookUpEdit currentLook = (SearchLookUpEdit)sender;
            //PopupSearchLookUpEditForm currentPopup = (currentLook as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            //currentPopup.Size = new Size(140, 180);

            txtFind.KeyDown += TxtFind_KeyDown;
            txtFind.PreviewKeyDown += TxtFind_PreviewKeyDown;
        }
        private void Check_SetValue()
        {
            if (gvDanhSach.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvDanhSach.FocusedRowHandle = 0;
                lueDanhSach.ClosePopup();
            }
        }
        private void TxtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (catchEnterKey)
                {
                    Check_SetValue();
                    ControlExtension.LeaveFocusNext(new KeyPressEventArgs((char)Keys.Enter), ControlNext);
                }
            }
        }
        private void TxtFind_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (CatchTabKey)
            {
                if (e.KeyData == Keys.Tab && ControlNext != null)
                {
                    Check_SetValue();
                    ControlNext.Focus();
                    e.IsInputKey = true;
                }
                else if (e.KeyData == (Keys.Tab | Keys.Shift) && ControlBack != null)
                {
                    Check_SetValue();
                    ControlBack.Focus();
                    e.IsInputKey = true;
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
            lueDanhSach.Focus();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueDanhSach.IsPopupOpen)
            {
                lueDanhSach.ShowPopup();
            }
        }
        public void Load_CauHinh()
        {
            gcLueId.FieldName = ControlExtension.PropertyNameToLowerCase<DM_TULUUMAU>(x => x.Matuluu);
            gcLueId.Caption = ControlExtension.GetDescription<DM_TULUUMAU>(x => x.Matuluu);
            gcLueName.FieldName = ControlExtension.PropertyNameToLowerCase<DM_TULUUMAU>(x => x.Tentuluu);
            gcLueName.Caption = ControlExtension.GetDescription<DM_TULUUMAU>(x => x.Tentuluu);
            var data = sysConfig.Data_dm_tuluumau(String.Empty);
            lueDanhSach.Properties.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            lueDanhSach.Properties.ValueMember = ControlExtension.PropertyNameToLowerCase<DM_TULUUMAU>(x => x.Matuluu);
            lueDanhSach.Properties.DisplayMember = ControlExtension.PropertyNameToLowerCase<DM_TULUUMAU>(x => x.Tentuluu);
            lueDanhSach.Properties.AutoHeight = false;
            lueDanhSach.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lueDanhSach.KeyPress += lueDonVi_KeyPress;
        }
        private void lueDonVi_EditValueChanged(object sender, EventArgs e)
        {
            EditValueChange?.Invoke(sender, e);
        }
    }
}
