using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Editors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraGrid.Views.Grid;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode
{
    public partial class ucSearchLookupEditor_LoaiMau : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_LoaiMau()
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
            lueLoaiMau.ShowPopup();
        }
        public void ClosePopup()
        {
            lueLoaiMau.ClosePopup();
        }
        [Category("Custom")]
        public EventHandler LoaiMau_EditValueChanged { get; set; }

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
                return lueLoaiMau.EditValue;
            }

            set
            {
                lueLoaiMau.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueLoaiMau.Properties.ValueMember;
            }

            set
            {
                lueLoaiMau.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueLoaiMau.Properties.DisplayMember;
            }

            set
            {
                lueLoaiMau.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueLoaiMau.Properties.DataSource;
            }

            set
            {
                lueLoaiMau.Properties.DataSource = value;
            }
        }
        private void lueLoaiMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    lueLoaiMau.ClosePopup();
                    ControlNext.Focus();
                    CheckShowPopUpNextControl();
                }
            }
        }
        TextEdit txtFind;
        GridView gridSearch;
        private void lueLoaiMau_Properties_Popup(object sender, EventArgs e)
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

            txtFind.KeyPress += TxtFind_KeyPress;
            txtFind.PreviewKeyDown += TxtFind_PreviewKeyDown;
        }
        private void Check_SetValue()
        {
            if (gvLueLoaiMau.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvLueLoaiMau.FocusedRowHandle = 0;
            }
            lueLoaiMau.ClosePopup();
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
        private void ucDevLookupEditor_Enter(object sender, EventArgs e)
        {
            lueLoaiMau.Focus();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueLoaiMau.IsPopupOpen)
            {
                lueLoaiMau.ShowPopup();
            }
        }
        public void Load_DanhMucLoaiMau(string loaiDichVu, string valueMember)
        {
            if (!string.IsNullOrEmpty(loaiDichVu))
            {
                lueLoaiMau.EditValueChanged -= LoaiMau_EditValueChanged;
                var data = sysConfig.Data_dm_xetnghiem_loaimau(string.Empty, loaiDichVu);
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                lueLoaiMau.Properties.DataSource = data;
                lueLoaiMau.Properties.ValueMember = valueMember.ToLower();
                lueLoaiMau.Properties.DisplayMember = "LoaiMau".ToLower();
                lueLoaiMau.Properties.AutoHeight = false;
                lueLoaiMau.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                lueLoaiMau.EditValueChanged += LoaiMau_EditValueChanged;
            }
            else
                lueLoaiMau.Properties.DataSource = null;

        }
        public void Load_DanhMucLoaiMau(string loaiDichVu)
        {
            if (!string.IsNullOrEmpty(loaiDichVu))
            {
                lueLoaiMau.EditValueChanged -= LoaiMau_EditValueChanged;
                var data = sysConfig.Data_dm_xetnghiem_loaimau(string.Empty, loaiDichVu);
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                lueLoaiMau.Properties.DataSource = data;
                lueLoaiMau.Properties.ValueMember = "MaLoaiMau".ToLower();
                lueLoaiMau.Properties.DisplayMember = "LoaiMau".ToLower();
                lueLoaiMau.Properties.AutoHeight = false;
                lueLoaiMau.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                lueLoaiMau.EditValueChanged += LoaiMau_EditValueChanged;
            }
            else
                lueLoaiMau.Properties.DataSource = null;

        }
    }
}
