using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhSachXetNghiem : UserControl
    {
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        public event EventHandler LuoiCellFocusChanged;
        public bool isAdmin = false;
        public bool isKhongSD = false;

        public string[] arrPhanQuyenNhom = new string[0];
        public bool UseCheckBox
        {
            set
            {
                if (value)
                {
                    gvDanhSach.OptionsSelection.MultiSelect = true;
                    gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                    gvDanhSach.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
                    gvDanhSach.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
                }
                else
                {
                    gvDanhSach.OptionsSelection.MultiSelect = false;
                    gvDanhSach.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
                    gvDanhSach.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
                    gvDanhSach.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
                }
            }
        }
        public bool AutoExpandAll { set; get; }
        public void ExpandAll()
        {
            gvDanhSach.ExpandAllGroups();
        }
        public DataTable CurrentDataSource;
        public List<string> LstMaXnChon
        {
            get
            {
                var lst = new List<string>();
                if (gvDanhSach.SelectedRowsCount >0)
                {
                    foreach (var item in gvDanhSach.GetSelectedRows())
                    {
                        if (gvDanhSach.GetRowCellValue(item, colMaXn) != null)
                        {
                            lst.Add(gvDanhSach.GetRowCellValue(item, colMaXn).ToString());
                        }
                    }
                }
                return lst;
            }
        }
        public string MaXnDangChon
        {
            get
            {
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    return gvDanhSach.GetFocusedRowCellValue(colMaXn).ToString();
                }
                return string.Empty;
            }
        }
        public ucDanhSachXetNghiem()
        {
            InitializeComponent();
        }
        public void Load_DanhSach(DataTable dataSource)
        {
            if (!((gvDanhSach.ActiveFilterCriteria ?? string.Empty).ToString().Equals("''")))
                gvDanhSach.ActiveFilterEnabled = false;
            var data = new DataTable();
            CurrentDataSource = null;
            if (dataSource == null)
            {
                data = _systemConfigService.Data_dm_xetnghiem(string.Join(",", arrPhanQuyenNhom), !isAdmin, string.Empty);
            }
            else
                data = dataSource.Copy();

            if (data != null)
            {
                CurrentDataSource = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            data = isKhongSD ? WorkingServices.SearchResult_OnDatatable(data, "KhongSD = TRUE") : data;
            gcDanhSach.DataSource = data;
            if (AutoExpandAll)
                gvDanhSach.ExpandAllGroups();
            if (data != null)
            {
                if (data.Columns.Count > 0)
                {
                    if (!((gvDanhSach.ActiveFilterCriteria ?? string.Empty).ToString().Equals("''")))
                        gvDanhSach.ActiveFilterEnabled = true;
                }
            }

        }

        private void gvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            this.LuoiCellFocusChanged?.Invoke(this, new EventArgs());
        }

        private void gvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.LuoiCellFocusChanged?.Invoke(this, new EventArgs());
        }
    }
}
