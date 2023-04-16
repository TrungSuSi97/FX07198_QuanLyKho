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
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.App.AppCode
{
    public partial class ucSearchLookupEditor_KyTen : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ucSearchLookupEditor_KyTen()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;
            this.Leave += UcSearchLookupEditor_Doctor_Leave;
        }

        private void UcSearchLookupEditor_Doctor_Leave(object sender, EventArgs e)
        {
            lueBSChiDinh.ClosePopup();
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
            lueBSChiDinh.ShowPopup();
        }
        public void ClosePopup()
        {
            lueBSChiDinh.ClosePopup();
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
                return lueBSChiDinh.EditValue;
            }

            set
            {
                lueBSChiDinh.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueBSChiDinh.Properties.ValueMember;
            }

            set
            {
                lueBSChiDinh.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueBSChiDinh.Properties.DisplayMember;
            }

            set
            {
                lueBSChiDinh.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueBSChiDinh.Properties.DataSource;
            }

            //set
            //{
            //    lueBSChiDinh.Properties.DataSource = value;
            //}
        }
        [Category("Custom")]
        public string GetDoctornameById(string doctorId)
        {
            if (lueBSChiDinh.Properties.DataSource == null)
                return string.Empty;
            else
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueBSChiDinh.Properties.DataSource, string.Format("MaNhanVien = '{0}'", doctorId.Trim()));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0]["TenNhanVien"].ToString();
                }
                else
                    return string.Empty;
            }
        }
        [Category("Custom")]
        public string GetSeletetedDoctorName()
        {
            if (lueBSChiDinh.EditValue == null)
                return string.Empty;
            else
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueBSChiDinh.Properties.DataSource, string.Format("MaNhanVien = '{0}'", lueBSChiDinh.EditValue.ToString().Trim()));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0]["TenNhanVien"].ToString();
                }
                else
                    return string.Empty;
            }
        }
        [Category("Custom")]
        public string GetSeletetedDoctorPosition()
        {
            if (lueBSChiDinh.EditValue == null)
                return string.Empty;
            else
            {
                var dataFound = WorkingServices.SearchResult_OnDatatable((DataTable)lueBSChiDinh.Properties.DataSource, string.Format("MaNhanVien = '{0}'", lueBSChiDinh.EditValue.ToString().Trim()));
                if (dataFound.Rows.Count > 0)
                {
                    return dataFound.Rows[0]["ChucVu"].ToString();
                }
                else
                    return string.Empty;
            }
        }
        private void lueBSChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
            else if (txtFind != null && lueBSChiDinh.IsPopupOpen)
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
            if (gvNguoiKyTen.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvNguoiKyTen.FocusedRowHandle = 0;
                lueBSChiDinh.ClosePopup();
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
            lueBSChiDinh.Focus();
            if (DropDownOnEnter)
                lueBSChiDinh.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueBSChiDinh.IsPopupOpen)
            {
                lueBSChiDinh.ShowPopup();
            }
        }
        IUserManagementService userManagement = new UserManagementService();
        public void Load_TruongKhoa()
        {
            if (EditValueChanged != null)
                lueBSChiDinh.EditValueChanged -= EditValueChanged;
            var data = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), true);
            lueBSChiDinh.Properties.DataSource = data;
            lueBSChiDinh.Properties.ValueMember = "MaNguoiDung";
            lueBSChiDinh.Properties.DisplayMember = "TenNhanVien";
            lueBSChiDinh.Properties.PopupFormMinSize = new Size(300, 200);
            lueBSChiDinh.Properties.AutoHeight = false;
            lueBSChiDinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (EditValueChanged != null)
                lueBSChiDinh.EditValueChanged += EditValueChanged;
        }
        public void Load_NguoiDungCungPhanQuyen()
        {
            if (EditValueChanged != null)
                lueBSChiDinh.EditValueChanged -= EditValueChanged;
            var data = userManagement.GetUsersKyTenCoPhanQuyen("", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.BoPhanClsXetNghiem, true), false);
            lueBSChiDinh.Properties.DataSource = data;
            lueBSChiDinh.Properties.ValueMember = "MaNguoiDung";
            lueBSChiDinh.Properties.DisplayMember = "TenNhanVien";
            lueBSChiDinh.Properties.PopupFormMinSize = new Size(300, 200);
            lueBSChiDinh.Properties.AutoHeight = false;
            lueBSChiDinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (EditValueChanged != null)
                lueBSChiDinh.EditValueChanged += EditValueChanged;
        }
        public void Load_LanhDao()
        {
            if (EditValueChanged != null)
                lueBSChiDinh.EditValueChanged -= EditValueChanged;
            var data = userManagement.DanhSachNguoiDungNhanVien();
            if(data != null)
            {
                if(data.Rows.Count >0)
                {
                    data = WorkingServices.SearchResult_OnDatatable(data, "KyTenLanhDao = true");
                }
            }
            lueBSChiDinh.Properties.DataSource = data;
            lueBSChiDinh.Properties.ValueMember = "MaNguoiDung";
            lueBSChiDinh.Properties.DisplayMember = "TenNhanVien";
            lueBSChiDinh.Properties.PopupFormMinSize = new Size(300, 200);
            lueBSChiDinh.Properties.AutoHeight = false;
            lueBSChiDinh.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            if (EditValueChanged != null)
                lueBSChiDinh.EditValueChanged += EditValueChanged;
        }
       
    }
}
