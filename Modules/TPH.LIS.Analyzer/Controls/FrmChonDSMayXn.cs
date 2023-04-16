using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class FrmChonDSMayXn : Form
    {
        public FrmChonDSMayXn()
        {
            InitializeComponent();
        }
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public List<string> lstMay = new List<string>();
        public bool isAdmin = false;
        public string[] arrAnalyzerAllow = new string[] { };
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (gvMayXN.SelectedRowsCount > 0)
            {
                foreach (var item in gvMayXN.GetSelectedRows())
                {
                    if (gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                        lstMay.Add(gvMayXN.GetRowCellValue(item, colIDMayXn).ToString());
                }
                this.Close();
            }
            else
                MessageBox.Show("Hãy chọn máy xét nghiệm.");
        }
        public void Load_MayXetNghiem(DataTable dataDSMayXetNghiem)
        {
            if (arrAnalyzerAllow != null)
            {
                if (arrAnalyzerAllow.Count() > 0)
                {
                    var dataSource = dataDSMayXetNghiem ?? _iAnalyzerConfig.Data_h_mayxetnghiem();
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            lstMay = new List<string>();
            this.Close();
        }

        private void FrmChonDSMayXn_Load(object sender, EventArgs e)
        {
            Load_MayXetNghiem(null);
        }
    }
}
