using System;
using System.ComponentModel;
using System.Drawing;
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
    public partial class ucSearchLookupEditor_NhomCLSXetNghiem : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_NhomCLSXetNghiem()
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

                    CheckShowPopUpBackControl();
                }
            }
        }

        private void UcSearchLookupEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
                CheckShowPopUpNextControl();
            }
        }

        private void CheckShowPopUpNextControl()
        {
            if (ControlNext != null)
            {
                if (ControlNext is ucSearchLookupEditor_DanhSachDichVu)
                {
                    ((ucSearchLookupEditor_DanhSachDichVu)ControlNext).ShowPopup();
                }
            }
        }
        private void CheckShowPopUpBackControl()
        {
            if (ControlBack != null)
            {
                if (ControlBack is ucSearchLookupEditor_LoaiDichVu)
                {
                    ((ucSearchLookupEditor_LoaiDichVu)ControlBack).ShowPopup();
                }
            }
        }
        public void ShowPopup()
        {
            lueNhomChiDinh.ShowPopup();
        }
        public void ClosePopup()
        {
            lueNhomChiDinh.ClosePopup();
        }
        [Category("Custom")]
        public event EventHandler NhomXetNghiem_EditValueChanged;

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
                return lueNhomChiDinh.EditValue;
            }

            set
            {
                lueNhomChiDinh.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueNhomChiDinh.Properties.ValueMember;
            }

            set
            {
                lueNhomChiDinh.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueNhomChiDinh.Properties.DisplayMember;
            }

            set
            {
                lueNhomChiDinh.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueNhomChiDinh.Properties.DataSource;
            }

            set
            {
                lueNhomChiDinh.Properties.DataSource = value;
            }
        }
        [Category("Custom")]
        public Color MauOngMau
        {
            get
            {
                if (gvLueNhomDichVu.GetFocusedRowCellValue(gcLueMaNhomDichVu) != null)
                {
                    var maMau = gvLueNhomDichVu.GetFocusedRowCellValue(gclueMauOngMau).ToString();
                    if (!string.IsNullOrEmpty(maMau))
                        return Color.FromArgb(int.Parse(maMau));
                }
                return Color.Empty;
            }
        }
        private void lueNhomChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                lueNhomChiDinh.ClosePopup();
                ControlNext.Focus();
                CheckShowPopUpNextControl();
            }
            else if (txtFind != null && lueNhomChiDinh.IsPopupOpen)
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
        private void lueNhomChiDinh_Properties_Popup(object sender, EventArgs e)
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
            if (gvLueNhomDichVu.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvLueNhomDichVu.FocusedRowHandle = 0;
            }
            lueNhomChiDinh.ClosePopup();
        }
        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (catchEnterKey)
                {
                    e.Handled = true;
                    txtFind.KeyPress -= TxtFind_KeyPress;
                    Check_SetValue();
                    if (ControlNext != null)
                    {
                        ControlNext.Focus();
                        CheckShowPopUpNextControl();
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
                    CheckShowPopUpNextControl();
                 
                }
                else if (e.KeyData == (Keys.Tab | Keys.Shift) && ControlBack != null)
                {
                    e.IsInputKey = true;
                    Check_SetValue();
                    ControlBack.Focus();
                    CheckShowPopUpBackControl();
                   
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
            lueNhomChiDinh.Focus(); 
            if (DropDownOnEnter)
                lueNhomChiDinh.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueNhomChiDinh.IsPopupOpen)
            {
                lueNhomChiDinh.ShowPopup();
            }
        }
        public void Load_DanhMucNhomDichVu()
        {
            lueNhomChiDinh.Properties.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(sysConfig.GetTestGroup(string.Empty, string.Empty), true);

            lueNhomChiDinh.Properties.ValueMember = "MaNhomCLS".ToLower();
            lueNhomChiDinh.Properties.DisplayMember = "TenNhomCLS".ToLower();
            lueNhomChiDinh.Properties.AutoHeight = false;
            lueNhomChiDinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }

        private void lueNhomChiDinh_EditValueChanged(object sender, EventArgs e)
        {
            NhomXetNghiem_EditValueChanged?.Invoke(sender, e);
        }
    }
}
