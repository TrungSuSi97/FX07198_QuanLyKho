using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Analyzer.Services;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucCoCanhBaoTuMayTheoSeq : UserControl
    {
        public ucCoCanhBaoTuMayTheoSeq()
        {
            InitializeComponent();
        }
        public Control mainControl = null;
        public List<string> lstId = new List<string>();
        DataTable dataSource;
        public DataTable DataSource
        {
            get { return dataSource; }
            set
            {
                lstId = new List<string>();
                dataSource = value;
                var lstIDMay = new List<string>();
                if (dataSource != null)
                {
                    if (!pnDanhSachMay.IsDisposed && !this.IsDisposed)
                    {
                        if (dataSource.Rows.Count > 0)
                        {
                            lblbarcode.Text = dataSource.Rows[0]["Barcode"].ToString();
                            this.Name = lblbarcode.Text;
                            var distinctIdMay = dataSource.DefaultView.ToTable(true, "IdMayXetNghiem");
                            var totalHeight = 21;
                            foreach (DataRow drIdMay in distinctIdMay.Rows)
                            {
                                var idMay = drIdMay["IdMayXetNghiem"].ToString();
                                lstIDMay.Add(idMay);
                                var dataChiTiet = WorkingServices.SearchResult_OnDatatable(dataSource, string.Format("IdMayXetNghiem = {0}", idMay));

                                ucCoCanhBaoTheoMay uc;
                                var ctrlOld = pnDanhSachMay.Controls[idMay];
                                if (ctrlOld == null)
                                {
                                    uc = new ucCoCanhBaoTheoMay();
                                    pnDanhSachMay.Controls.Add(uc);
                                    uc.Dock = DockStyle.Top;
                                    uc.BringToFront();
                                }
                                else
                                {
                                    uc = (ucCoCanhBaoTheoMay)ctrlOld;
                                }
                                uc.Name = idMay;
                                uc.DataSource = dataChiTiet;
                                totalHeight += uc.Height;
                            }
                            this.Height = totalHeight;
                            //xóa control không có id
                            foreach (Control item in pnDanhSachMay.Controls)
                            {
                                var uc = (ucCoCanhBaoTheoMay)item;
                                if (!lstIDMay.Contains(uc.Name))
                                    pnDanhSachMay.Controls.Remove(item);
                            }
                            foreach (DataRow drID in dataSource.Rows)
                            {
                                lstId.Add(drID["id"].ToString());
                            }
                        }
                    }
                }
            }
        }
        private readonly IAnalyzerResultService _iAnalyzer = new AnalyzerResultService();
        private void btnUpdateDaXem_Click(object sender, EventArgs e)
        {
            if (lstId.Count > 0)
            {
                _iAnalyzer.Update_DaXemCoTuMay(lstId);
                if (mainControl != null)
                {
                    mainControl.Controls.Remove(this);
                }
            }
        }
    }
}
