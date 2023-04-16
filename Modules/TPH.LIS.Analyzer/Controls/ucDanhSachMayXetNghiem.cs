using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucDanhSachMayXetNghiem : UserControl
    {
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public string[] arrAnalyzerAllow = new string[] { };
        public event EventHandler LuoiCellFocusChanged;
        public bool isAdmin = false;
        public List<string> LstMayXNChon
        {
            get
            {
                var lst = new List<string>();
                if (gvMayXN.SelectedRowsCount > 0)
                {
                    foreach (var item in gvMayXN.GetSelectedRows())
                    {
                        if (gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                        {
                            lst.Add(gvMayXN.GetRowCellValue(item, colIDMayXn).ToString());
                        }
                    }
                }
                return lst;
            }
        }
        public string MayXnDangChon
        {
            get
            {
                if (gvMayXN.FocusedRowHandle > -1)
                {
                    return gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString();
                }
                return string.Empty;
            }
        }
        public ucDanhSachMayXetNghiem()
        {
            InitializeComponent();
        }
        public void Load_MayXetNghiem(DataTable dataDSMayXetNghiem)
        {
            if (arrAnalyzerAllow != null)
            {
                if (arrAnalyzerAllow.Count() > 0)
                {
                    var dataSource = dataDSMayXetNghiem ?? _iAnalyzerConfig.Data_h_mayxetnghiem();
                    if (isAdmin)
                    {
                        gcMayXN.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(dataSource, true);
                    }
                    else
                    {
                        var mayXetNghiem = from selectData in dataSource.AsEnumerable()
                                           where (arrAnalyzerAllow.Where(x => x.ToString().Equals(selectData["idmay"].ToString())).Any())
                                           select selectData;
                        if (mayXetNghiem.Any())
                        {
                            var data = mayXetNghiem.AsDataView().ToTable();

                            foreach (DataColumn dtc in data.Columns)
                            {
                                dtc.ColumnName = dtc.ColumnName.ToLower();
                            }
                            gcMayXN.DataSource = data;
                        }
                        else
                            gcMayXN.DataSource = null;
                    }
                }
            }
        }

        private void gvMayXN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.LuoiCellFocusChanged?.Invoke(this, new EventArgs());
        }

        private void gvMayXN_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            this.LuoiCellFocusChanged?.Invoke(this, new EventArgs());
        }
    }
}
