using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
using TPH.LIS.Analyzer.Services;

namespace TPH.LIS.App.AppCode
{
    public partial class ucSearchLookupEditor_MayXN : UserControl
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public ucSearchLookupEditor_MayXN()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;
        }
        public string[] arrAnalyzerAllow = new string[] { };
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
                return lueMayXN.EditValue;
            }
            set
            {
                lueMayXN.EditValue = value;
            }
        }
        [Category("Custom")]
        public string ValueMember
        {
            get
            {
                return lueMayXN.Properties.ValueMember;
            }

            set
            {
                lueMayXN.Properties.ValueMember = value;
            }
        }
        [Category("Custom")]
        public string DisplayMember
        {
            get
            {
                return lueMayXN.Properties.DisplayMember;
            }

            set
            {
                lueMayXN.Properties.DisplayMember = value;
            }
        }
        [Category("Custom")]
        public object DataSource
        {
            get
            {
                return lueMayXN.Properties.DataSource;
            }

            //set
            //{
            //    lueKhuDieuTri.Properties.DataSource = value;
            //}
        }
        private void lueMayXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null && e.KeyChar == (char)Keys.Enter)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
            else if (txtFind != null && lueMayXN.IsPopupOpen)
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
        private void lueMayXN_Properties_Popup(object sender, EventArgs e)
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
            if (gvMayXN.RowCount == 1 && !string.IsNullOrEmpty(txtFind.Text))
            {
                gvMayXN.FocusedRowHandle = 0;
                lueMayXN.ClosePopup();
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
            lueMayXN.Focus();
            if (DropDownOnEnter)
                lueMayXN.ShowPopup();
        }
        private void ucDevLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!lueMayXN.IsPopupOpen)
            {
                lueMayXN.ShowPopup();
            }
        }
        public void Load_MayXN(int idLoaiMay = -1, bool getIdZero  = false)
        {
            if (arrAnalyzerAllow != null)
            {
                if (arrAnalyzerAllow.Count() > 0)
                {
                    string allowanalyzer = Utilities.ArrayToSqlValue(arrAnalyzerAllow);
                    var data = _iAnalyzerConfig.Data_h_mayxetnghiem(loaiMay: idLoaiMay);
              
                    var mayXetNghiem = from selectData in data.AsEnumerable()
                                       where allowanalyzer.Contains(string.Format("'{0}'", selectData["idmay"].ToString()))
                                       select selectData;
                    var dataShow =(mayXetNghiem.Any()? mayXetNghiem.CopyToDataTable(): data.Clone()) ;
                    if (getIdZero)
                    {
                        var dr = dataShow.NewRow();
                        dr["idmay"] = 0;
                        dr["tenmay"] = "---None---";
                        dataShow.Rows.Add(dr);
                    }
                    lueMayXN.Properties.DataSource = dataShow;
                    lueMayXN.Properties.ValueMember = "idmay";
                    lueMayXN.Properties.DisplayMember = "tenmay";
                    lueMayXN.Properties.AutoHeight = false;
                    lueMayXN.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    lueMayXN.KeyPress += lueMayXN_KeyPress;
                }
            }
        }
        private void lueMayXN_EditValueChanged(object sender, EventArgs e)
        {
            EditValueChange?.Invoke(sender, e);
        }
    }
}
