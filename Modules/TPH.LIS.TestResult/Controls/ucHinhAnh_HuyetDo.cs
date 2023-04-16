using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.TestResult.Services;
//using TPH.LIS.Common.Constants;
using TPH.AnalyzerChart.Service;
using TPH.AnalyzerChart.Service.Impl;
using TPH.AnalyzerChart.Model;
using System.IO;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucHinhAnh_HuyetDo : UserControl
    {
        public ucHinhAnh_HuyetDo()
        {
            InitializeComponent();
        }
        private readonly ITestResultService _iTesreult = new TestResultService();
        private readonly IDrawAnalyzerChartSevice _iDrawAnlyzerChart = new DrawAnalyzerChart();
        public void VeBieuDo(string maTiepNhan, string idMay, string protocol)
        {
            var data = _iTesreult.Data_HinhAnh_TuMay(maTiepNhan, idMay);
            if(data.Rows.Count >0)
            {
                var listObj = new List<ChartInfo>();
                foreach(DataRow dr in data.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["MaMay"].ToString()))
                    {
                        var obj = new ChartInfo();
                        obj.MaMay = dr["MaMay"].ToString();
                        obj.ChuoiHinhAnh = dr["GiaTriChuoi"].ToString();
                        obj.IdMay = int.Parse(idMay);
                        obj.MaTiepNhan = dr["matiepnhan"].ToString();
                        obj.GiaoThuc = dr["GiaoThucBieuDo"].ToString();
                        obj.HinhAnh = string.IsNullOrEmpty(dr["giatrihinhanh"].ToString()) ? null : Image.FromStream(new MemoryStream((byte[])dr["giatrihinhanh"]));
                        listObj.Add(obj);
                    }
                }
                if (listObj.Any())
                    _iDrawAnlyzerChart.DrawChartFromData(listObj, ref pbWBC, ref pbRBC, ref pbPLT, ref pbS10Catter, ref pbS90Catter);
            }
        }
        public void Xoa_BieuDo()
        {
            pbPLT.Image = null;
            pbRBC.Image = null;
            pbWBC.Image = null;
            pbS10Catter.Image = null;
            pbS90Catter.Image = null;

            pbPLT.Visible = false;
            pbRBC.Visible = false;
            pbWBC.Visible = false;
            pbS10Catter.Visible = false;
            pbS90Catter.Visible = false;
        }
    }
}
