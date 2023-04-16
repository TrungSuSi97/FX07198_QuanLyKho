using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucAnalyzerAlarmList : UserControl
    {
        public ucAnalyzerAlarmList()
        {
            InitializeComponent();
            label1.BackColor = CommonAppColors.ColorMainAppColor;
            label1.ForeColor = CommonAppColors.ColorTextCaption;
        }
        DataTable dataSource;
        public DataTable DataSource
        {
            get { return dataSource; }
            set
            {
                var totalHeight = 27;
                //    pnListContaint.Controls.Clear();
                dataSource = value;
                List<string> lstbarcode = new List<string>();
                if (dataSource != null)
                {
                    if (dataSource.Rows.Count > 0)
                    {
                        var distinSeq = dataSource.DefaultView.ToTable(true, "Barcode");
                        foreach (DataRow drSeq in distinSeq.Rows)
                        {
                            var barcode = drSeq["Barcode"].ToString();
                            lstbarcode.Add(barcode);
                            var dataChiTiet = WorkingServices.SearchResult_OnDatatable(dataSource, string.Format("Barcode = '{0}'", barcode));
                            var getControl = pnListContaint.Controls[barcode];
                            ucCoCanhBaoTuMayTheoSeq uc;
                            if (getControl != null)
                            {
                                uc = (ucCoCanhBaoTuMayTheoSeq)pnListContaint.Controls[barcode];
                            }
                            else
                            {
                                uc = new ucCoCanhBaoTuMayTheoSeq();
                                if (!pnListContaint.IsDisposed && !this.IsDisposed)
                                {
                                    pnListContaint.Controls.Add(uc);
                                    uc.Dock = DockStyle.Top;
                                    uc.BringToFront();
                                    uc.mainControl = pnListContaint;
                                }
                            }
                            uc.Name = barcode;
                            uc.DataSource = dataChiTiet;

                            totalHeight += uc.Height;
                        }
                        this.Height = totalHeight;
                        this.Visible = true;
                        //Xóa các control không có trogn dữ liệu
                        foreach (Control ctrl in pnListContaint.Controls)
                        {
                            if (ctrl is ucCoCanhBaoTuMayTheoSeq)
                            {
                                var uc = (ucCoCanhBaoTuMayTheoSeq)ctrl;
                                if (!lstbarcode.Contains(uc.Name))
                                    pnListContaint.Controls.Remove(ctrl);
                            }
                        }
                    }
                    else
                    {
                        pnListContaint.Controls.Clear();
                        this.Visible = false;
                    }
                }
                else
                {
                    pnListContaint.Controls.Clear();
                    this.Visible = false;
                }
            }
        }
        private void CreateAndShowData()
        {
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
