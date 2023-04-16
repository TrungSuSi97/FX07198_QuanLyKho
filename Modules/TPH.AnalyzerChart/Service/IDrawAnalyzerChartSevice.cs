using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TPH.AnalyzerChart.Model;

namespace TPH.AnalyzerChart.Service
{
    public interface IDrawAnalyzerChartSevice
    {
        void DrawChartABX(Color _Color, string strHistoResult, Constants.enumLoaiXnVeHinh loaiXN, ref PictureBox pb);
        void DrawChartFromData(List<ChartInfo> chartInfo, ref PictureBox wbc, ref PictureBox rbc, ref PictureBox plt, ref PictureBox s10, ref PictureBox s90);
    }
}
