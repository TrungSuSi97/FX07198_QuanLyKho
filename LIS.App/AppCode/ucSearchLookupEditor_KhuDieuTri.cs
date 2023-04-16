using System;
using System.ComponentModel;
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

namespace TPH.LIS.App.AppCode
{
    public partial class ucSearchLookupEditor_KhuDieuTri : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_KhuDieuTri()
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
                return lueKhuDieuTri.EditValue;
            }

            set
            {
                lueKhuDieuTri.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueKhuDieuTri.Properties.ValueMember;
            }

            set
            {
                lueKhuDieuTri.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueKhuDieuTri.Properties.DisplayMember;
            }

            set
            {
                lueKhuDieuTri.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueKhuDieuTri.Properties.DataSource;
            }

            //set
            //{
            //    lueKhuDieuTri.Properties.DataSource = value;
            //}
        }
        private void lueKhuDieuTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
            else if (txtFind != null && lueKhuDieuTri.IsPopupOpen)
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
        private void lueKhuDieuTri_Properties_Popup(object sender, EventArgs e)
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
            if (gvKhuDieuTri.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvKhuDieuTri.FocusedRowHandle = 0;
                lueKhuDieuTri.ClosePopup();
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
            lueKhuDieuTri.Focus();
            if (DropDownOnEnter)
                lueKhuDieuTri.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueKhuDieuTri.IsPopupOpen)
            {
                lueKhuDieuTri.ShowPopup();
            }
        }
        public void Load_DieuTri()
        {
            var data = sysConfig.Data_dm_bophan(string.Empty, string.Empty);
            lueKhuDieuTri.Properties.DataSource = data;
            lueKhuDieuTri.Properties.ValueMember = "MaBoPhan";
            lueKhuDieuTri.Properties.DisplayMember = "TenBoPhan";
            lueKhuDieuTri.Properties.AutoHeight = false;
            lueKhuDieuTri.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lueKhuDieuTri.KeyPress += lueKhuDieuTri_KeyPress;
        }
        private void lueKhuDieuTri_EditValueChanged(object sender, EventArgs e)
        {
            EditValueChange?.Invoke(sender, e);
        }
    }
}
