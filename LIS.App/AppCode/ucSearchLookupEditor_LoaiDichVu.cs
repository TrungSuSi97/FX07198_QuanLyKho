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
    public partial class ucSearchLookupEditor_LoaiDichVu : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_LoaiDichVu()
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
                
                    CheckShowPopUpNextControl();
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
            if (catchEnterKey && ControlNext != null)
            {
                if (ControlExtension.LeaveFocusNext(e, ControlNext))
                    CheckShowPopUpNextControl();
            }
        }
        private void CheckShowPopUpNextControl()
        {
            if (ControlNext != null)
            {
                if (ControlNext is ucSearchLookupEditor_NhomDichVu)
                {
                    ((ucSearchLookupEditor_NhomDichVu)ControlNext).ShowPopup();
                }
            }
        }

        public void ShowPopup()
        {
            lueLoaiChiDinh.ShowPopup();
        }
        public void ClosePopup()
        {
            lueLoaiChiDinh.ClosePopup();
        }
        [Category("Custom")]
        public EventHandler LoaiChiDinh_EditValueChanged { get; set; }

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
                return lueLoaiChiDinh.EditValue;
            }

            set
            {
                lueLoaiChiDinh.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueLoaiChiDinh.Properties.ValueMember;
            }

            set
            {
                lueLoaiChiDinh.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueLoaiChiDinh.Properties.DisplayMember;
            }

            set
            {
                lueLoaiChiDinh.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueLoaiChiDinh.Properties.DataSource;
            }

            set
            {
                lueLoaiChiDinh.Properties.DataSource = value;
            }
        }
        private void lueLoaiChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                if (ControlExtension.LeaveFocusNext(e, ControlNext))
                    CheckShowPopUpNextControl();  
            }
            else if (txtFind != null && lueLoaiChiDinh.IsPopupOpen)
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
        private void lueLoaiChiDinh_Properties_Popup(object sender, EventArgs e)
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

            txtFind.KeyPress += TxtFind_KeyPress;
            txtFind.PreviewKeyDown += TxtFind_PreviewKeyDown;
        }
        private void Check_SetValue()
        {
            if (gvLueLoaiDichVu.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvLueLoaiDichVu.FocusedRowHandle = 0;
                lueLoaiChiDinh.ClosePopup();
            }
        }
        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (catchEnterKey)
                {
                    Check_SetValue();
                    if (ControlExtension.LeaveFocusNext(new KeyPressEventArgs((char)Keys.Enter), ControlNext))
                        CheckShowPopUpNextControl();
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
                    CheckShowPopUpNextControl();
                    
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
        [Category("Custom")]
          public bool DropDownOnEnter = false;
        private void ucDevLookupEditor_Enter(object sender, EventArgs e)
        {
            lueLoaiChiDinh.Focus();
            if (DropDownOnEnter)
                lueLoaiChiDinh.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueLoaiChiDinh.IsPopupOpen)
            {
                lueLoaiChiDinh.ShowPopup();
            }
        }
        public void Load_DanhMucLoaiDichVu()
        {
            lueLoaiChiDinh.EditValueChanged -= LoaiChiDinh_EditValueChanged;
            string conditLoaiDichVu = string.Format("and EnumID in ({0}) and EnumID not in ({1},{2})", CommonAppVarsAndFunctions.ListEnumLoaiDichVu(), (int)User.Enum.ServiceType.TiepNhan, (int)User.Enum.ServiceType.ClsXNViSinh);
            var data = sysConfig.GetSubclinical(conditLoaiDichVu);
            lueLoaiChiDinh.Properties.DataSource = data;

            lueLoaiChiDinh.Properties.ValueMember = "MaPhanLoai";
            lueLoaiChiDinh.Properties.DisplayMember = "TenPhanLoai";
            lueLoaiChiDinh.Properties.AutoHeight = false;
            lueLoaiChiDinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            lueLoaiChiDinh.EditValueChanged += LoaiChiDinh_EditValueChanged;
        }

    }
}
