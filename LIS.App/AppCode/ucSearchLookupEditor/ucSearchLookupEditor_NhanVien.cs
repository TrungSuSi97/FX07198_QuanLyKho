using System;
using System.ComponentModel;
using System.Drawing;
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

namespace TPH.LIS.App.AppCode
{
    public partial class ucSearchLookupEditor_NhanVien : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_NhanVien()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;
            this.Leave += UcSearchLookupEditor_Doctor_Leave;
        }

        private void UcSearchLookupEditor_Doctor_Leave(object sender, EventArgs e)
        {
            lueNhanVien.ClosePopup();
        }

        [Category("Custom")]
        public event EventHandler EditValueChanged;
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
            lueNhanVien.ShowPopup();
        }
        public void ClosePopup()
        {
            lueNhanVien.ClosePopup();
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
                return lueNhanVien.EditValue;
            }

            set
            {
                lueNhanVien.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueNhanVien.Properties.ValueMember;
            }

            set
            {
                lueNhanVien.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueNhanVien.Properties.DisplayMember;
            }

            set
            {
                lueNhanVien.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueNhanVien.Properties.DataSource;
            }

            //set
            //{
            //    lueBSChiDinh.Properties.DataSource = value;
            //}
        }
        [Category("Custom")]
        public string GetDoctorIdByName(string doctorName)
        {
            if (lueNhanVien.Properties.DataSource == null)
                return string.Empty;
            else
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueNhanVien.Properties.DataSource, string.Format("TenNhanVien = '{0}'", doctorName.Trim()));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0]["MaNhanVien"].ToString();
                }
                else
                    return string.Empty;
            }
        }
        [Category("Custom")]
        public string GetDoctorLocation
        {
            get
            {
                if (lueNhanVien.Properties.DataSource == null || SelectedValue == null)
                    return string.Empty;
                else
                {
                    var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueNhanVien.Properties.DataSource, string.Format("MaNhanVien = '{0}'", SelectedValue.ToString()));
                    if (dataFound.Rows.Count > 0)
                    {
                        return dataFound.Rows[0]["MaKhoaPhong"].ToString();
                    }
                    else
                        return string.Empty;
                }
            }
        }
        [Category("Custom")]
        public string GetDoctorRoom
        {
            get
            {
                if (lueNhanVien.Properties.DataSource == null || SelectedValue == null)
                    return string.Empty;
                else
                {
                    var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueNhanVien.Properties.DataSource, string.Format("MaNhanVien = '{0}'", SelectedValue.ToString()));
                    if (dataFound.Rows.Count > 0)
                    {
                        return dataFound.Rows[0]["MaPhong"].ToString();
                    }
                    else
                        return string.Empty;
                }
            }
        }
        private void lueBSChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
            else if (txtFind != null && lueNhanVien.IsPopupOpen)
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
        private void lueBSChiDinh_Properties_Popup(object sender, EventArgs e)
        {
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

            txtFind.KeyDown += TxtFind_KeyDown;
            txtFind.PreviewKeyDown += TxtFind_PreviewKeyDown;
        }



        private void Check_SetValue()
        {
            if (gvBS.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvBS.FocusedRowHandle = 0;
                lueNhanVien.ClosePopup();
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
            lueNhanVien.Focus(); 
            if (DropDownOnEnter)
                lueNhanVien.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueNhanVien.IsPopupOpen)
            {
                lueNhanVien.ShowPopup();
            }
        }
        public void Load_NhanVien()
        {
            if (EditValueChanged != null)
                lueNhanVien.EditValueChanged -= EditValueChanged;
            var data = sysConfig.Data_ql_nhanvien(string.Empty, string.Empty);
            lueNhanVien.Properties.DataSource = data;
            lueNhanVien.Properties.ValueMember = "MaNhanVien";
            lueNhanVien.Properties.DisplayMember = "TenNhanVien";
            lueNhanVien.Properties.PopupFormMinSize = new Size(300, 200);
            lueNhanVien.Properties.AutoHeight = false;
            lueNhanVien.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (EditValueChanged != null)
                lueNhanVien.EditValueChanged += EditValueChanged;
        }
        public void Load_CongTacVien()
        {
            if (EditValueChanged != null)
                lueNhanVien.EditValueChanged -= EditValueChanged;
            var data = sysConfig.Data_ql_nhanvien(string.Empty, "CTV,BSCT");
            gcLueMaBS.Caption = "Mã CTV";
            gcLueTebBS.Caption = "Tên CTV";
            lueNhanVien.Properties.DataSource = data;
            lueNhanVien.Properties.ValueMember = "MaNhanVien";
            lueNhanVien.Properties.DisplayMember = "TenNhanVien";
            lueNhanVien.Properties.PopupFormMinSize = new Size(300, 200);
            lueNhanVien.Properties.AutoHeight = false;
            lueNhanVien.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (EditValueChanged != null)
                lueNhanVien.EditValueChanged += EditValueChanged;
        }
        public void Load_NhanVienNhanMau()
        {
            if (EditValueChanged != null)
                lueNhanVien.EditValueChanged -= EditValueChanged;
            User.Services.UserManagement.IUserManagementService user = new User.Services.UserManagement.UserManagementService();
            var data = user.Get_NhanVien_NhanMau(string.Empty);
            lueNhanVien.Properties.DataSource = data;
            lueNhanVien.Properties.ValueMember = "MaNhanVien";
            lueNhanVien.Properties.DisplayMember = "TenNhanVien";
            lueNhanVien.Properties.PopupFormMinSize = new Size(300, 200);
            lueNhanVien.Properties.AutoHeight = false;
            lueNhanVien.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (EditValueChanged != null)
                lueNhanVien.EditValueChanged += EditValueChanged;
        }
    }
}
