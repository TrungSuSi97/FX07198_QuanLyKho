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
    public partial class ucSearchLookupEditor_AntibioticPanel : UserControl
    {
        private readonly IBacteriumAntibioticService sysConfig = new BacteriumAntibioticService();
        public ucSearchLookupEditor_AntibioticPanel()
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
                    CheckShowPopUpBackControl();
                }
            }
        }

        private void UcSearchLookupEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && catchEnterKey)
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
        private void CheckShowPopUpBackControl()
        {
            if (ControlBack != null)
            {
                if (ControlBack is ucSearchLookupEditor_NhomDichVu)
                {
                    ((ucSearchLookupEditor_NhomDichVu)ControlBack).ShowPopup();
                }
            }
        }
        public void ShowPopup()
        {
            lueAntibioticPanel.ShowPopup();
        }
        public void ClosePopup()
        {
            lueAntibioticPanel.ClosePopup();
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
                return lueAntibioticPanel.EditValue;
            }

            set
            {
                lueAntibioticPanel.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueAntibioticPanel.Properties.ValueMember;
            }

            set
            {
                lueAntibioticPanel.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueAntibioticPanel.Properties.DisplayMember;
            }

            set
            {
                lueAntibioticPanel.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueAntibioticPanel.Properties.DataSource;
            }

            set
            {
                lueAntibioticPanel.Properties.DataSource = value;
            }
        }
        public DataRowView SelectedDataRowView
        {
            get
            {
                return (DataRowView)lueAntibioticPanel.GetSelectedDataRow();
            }
        }
        private void lueChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && catchEnterKey)
            {
                if (ChiDinh_Keypress != null)
                {
                    TimeSpan ts = DateTime.Now - lasTimeShow;

                    if (ts.TotalSeconds > 1)
                    {
                        e.Handled = true;
                        txtFind.KeyPress -= TxtFind_KeyPress;
                        lueAntibioticPanel.ClosePopup();
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

            var btFindLCI = (SimpleButton)GetPopUpButtonLayoutItem(Form, "btFind").Control;
            btFindLCI.Text = "Tìm";
            var btClearLCI = (SimpleButton)GetPopUpButtonLayoutItem(Form, "btClear").Control;
            btClearLCI.Text = "Xóa chọn";

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
            if (gvLueAntibitocPanel.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvLueAntibitocPanel.FocusedRowHandle = 0;
                lueAntibioticPanel.ClosePopup();
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
                            gvLueAntibitocPanel.Focus();
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
                        if (grid != null)
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
            lueAntibioticPanel.Focus();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueAntibioticPanel.IsPopupOpen)
            {
                lueAntibioticPanel.ShowPopup();
            }
        }
        public void Load_AntibioticPanel(string maBoKhangSinh, string maViKhuan = null)
        {
            var data = new DataTable();
            if (!string.IsNullOrEmpty(maViKhuan))
            {
                //Lấy dm_xetnghiem_visinh_bo theo vi khuan
                data = sysConfig.Data_dm_xetnghiem_visinh_bo_by_mvk(maViKhuan);
            }
            else
            {
                data = sysConfig.Data_dm_xetnghiem_visinh_bo(maBoKhangSinh);
            }
            lueAntibioticPanel.Properties.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            lueAntibioticPanel.Properties.ValueMember = "MaBoKhangSinh".ToLower();
            lueAntibioticPanel.Properties.DisplayMember = "TenBoKhangSinh".ToLower();
            lueAntibioticPanel.Properties.PopupFormMinSize = new Size(300, 200);
            lueAntibioticPanel.Properties.AutoHeight = false;
            lueAntibioticPanel.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        private void lueAntibioticPanel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lueAntibioticPanel_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
