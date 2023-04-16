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
using TPH.LIS.App.AppCode.Config;

namespace TPH.LIS.App.AppCode
{
    public partial class ucSearchLookupEditor_Provice : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_Provice()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;

        }
        public event EventHandler SeletedValueChanged;
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
        public void ShowPopup()
        {
            lueTinh.ShowPopup();
        }
        public void ClosePopup()
        {
            lueTinh.ClosePopup();
        }
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
                return lueTinh.EditValue;
            }

            set
            {
                lueTinh.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueTinh.Properties.ValueMember;
            }

            set
            {
                lueTinh.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueTinh.Properties.DisplayMember;
            }

            set
            {
                lueTinh.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueTinh.Properties.DataSource;
            }

            //set
            //{
            //    lueTinh.Properties.DataSource = value;
            //}
        }
        [Category("Custom")]
        public string GetObjectIdByName(string objectName)
        {
            if (lueTinh.Properties.DataSource == null)
                return string.Empty;
            else
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueTinh.Properties.DataSource, string.Format("TenTinh = '{0}'", objectName.Trim()));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0]["AutoID"].ToString();
                }
                else
                    return string.Empty;
            }
        }
        private void lueTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
            else if (txtFind != null && lueTinh.IsPopupOpen)
            {
                if (!txtFind.Focused)
                {
                    txtFind.Focus();
                    txtFind.Text += e.KeyChar.ToString();
                    txtFind.SelectionStart = txtFind.Text.Length;
                }
            }
        }
        TextEdit txtFind;
        GridView gridSearch;
        private void lueTinh_Properties_Popup(object sender, EventArgs e)
        {
            IPopupControl popup = sender as IPopupControl;
            PopupBaseForm Form = popup.PopupWindow as PopupBaseForm;

            var btFindLCI = (SimpleButton)GetPopUpButtonLayoutItem(Form, "btFind").Control;
            btFindLCI.Text = CommonAppVarsAndFunctions.LangMessageConstant.Tim;
            var btClearLCI = (SimpleButton)GetPopUpButtonLayoutItem(Form, "btClear").Control;
            btClearLCI.Text = CommonAppVarsAndFunctions.LangMessageConstant.Xoachon;

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
            if (gvTinh.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvTinh.FocusedRowHandle = 0;
                lueTinh.ClosePopup();
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
        [Category("Custom")]
          public bool DropDownOnEnter = false;
        private void ucDevLookupEditor_Enter(object sender, EventArgs e)
        {
            lueTinh.Focus();
            if (DropDownOnEnter)
                lueTinh.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueTinh.IsPopupOpen)
            {
                lueTinh.ShowPopup();
            }
        }
        public void Load_Tinh()
        {
            C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
            var dataS = data.Get_TinhTP(string.Empty);

            lueTinh.Properties.DataSource = dataS;
            lueTinh.Properties.ValueMember = "AutoID";
            lueTinh.Properties.DisplayMember = "TenTinh";
            lueTinh.Properties.AutoHeight = false;
            lueTinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        private void lueTinh_EditValueChanged(object sender, EventArgs e)
        {
            SeletedValueChanged?.Invoke(sender, e);

        }
    }
}
