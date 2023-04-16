using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.Controls;
using TPH.LIS.Analyzer.Services;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucGhepBarcode : UserControl
    {
        private IAnalyzerResultService _iAnalyzer = new AnalyzerResultService();
        private IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public string userLogin = string.Empty;
        public bool repeatBarcode = false;
        public int dayScan = 8;
        List<ucLuoiKetQuaMay> lstKQMay;
        public ucGhepBarcode()
        {
            InitializeComponent();

            panel1.BackColor = CommonAppColors.ColorMainAppColor;
            panel1.ForeColor = CommonAppColors.ColorTextCaption;
        }

        public void Stop_refreshTimer()
        {
            if(lstKQMay!=null)
            {
                foreach( var uc in lstKQMay)
                {
                    uc.Stop_Timer();
                }
            }
        }
        public void Load_AllConfig()
        {
            Load_DanhSachMayCauHinhLuoi();
            Load_MayXN();
        }
        private void Load_DanhSachMayCauHinhLuoi()
        {
            var data = _iAnalyzerConfig.DataDanhMucMayXN_GhepCode(userLogin);
            ucAnalyzer.DataSource = data;
            ucAnalyzer.DisplayMember = "Tenmay2";
            ucAnalyzer.ValueMember = "IDMay";

            ucAnalyzer.CheckboAllCheckedChanged -= ucAnalyzer_CheckboAllCheckedChanged;
            ucAnalyzer.IsCheckedAll = true;
            ucAnalyzer.CheckboAllCheckedChanged += ucAnalyzer_CheckboAllCheckedChanged;
        }
        private void Load_MayXN()
        {
            pnDSMay.Refresh();
            int count = 0;
            pnDSMay.Controls.Clear();
            lstKQMay = new List<Analyzer.Controls.ucLuoiKetQuaMay>();
            var lstCheckedItem = ucAnalyzer.ListCheckedItem;
           
            if (lstCheckedItem.Count > 0)
            {
                int heightForGrid = (lstCheckedItem.Count > 2 ? -1 : pnDSMay.Height / lstCheckedItem.Count);
                var datasource = ucAnalyzer.DataSource;
                foreach (string IdMay in lstCheckedItem)
                {
                    foreach (DataRow drM in datasource.Rows)
                    {
                        if (drM["IDMay"].ToString().Equals(IdMay))
                        {
                            var ls = new ucLuoiKetQuaMay();
                            ls.SetAnalyzerInfo(int.Parse(drM["IDMay"].ToString())
                                , drM["TenMay"].ToString(), userLogin
                                , repeatBarcode, dayScan);
                            ls.ReadAndSetDataToGrid();
                            ls.Start_Timer(0 - count);
                            lstKQMay.Add(ls);
                            pnDSMay.Controls.Add(ls);
                            ls.Dock = DockStyle.Top;
                            ls.Height = (heightForGrid == -1 ? ls.Height : heightForGrid);
                            ls.BringToFront();
                            count += 2;
                        }
                    }
                }
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_AllConfig();
        }

        private void ucAnalyzer_ListSelectedIndexChanged(object sender, EventArgs e)
        {
            Load_MayXN();
        }

        private void ucAnalyzer_CheckboAllCheckedChanged(object sender, EventArgs e)
        {
            Load_MayXN();
        }
    }
}
