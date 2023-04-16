using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
namespace TPH.Controls
{
    public class TPHChart: Chart
    {
        private void macs()
        {
            BackColor = AppearanceStyle.LightItemBackground;
            foreach (Series item in base.Series)
            {
                if (item.ChartType == SeriesChartType.Doughnut || item.ChartType == SeriesChartType.Pie)
                {
                    item.LabelForeColor = Color.White;
                    item.BorderWidth = 1;
                    item.BorderColor = AppearanceStyle.LightItemBackground;
                }
                else
                {
                    item.LabelForeColor = AppearanceStyle.LightTextColor;
                }
            }
            foreach (ChartArea chartArea in base.ChartAreas)
            {
                chartArea.BackColor = AppearanceStyle.LightItemBackground;
                chartArea.AxisX.LabelStyle.ForeColor = AppearanceStyle.LightTextColor;
                chartArea.AxisX.LineColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 30);
                chartArea.AxisX.LineWidth = 2;
                chartArea.AxisX.MajorTickMark.LineColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 30);
                chartArea.AxisX.MajorTickMark.LineWidth = 2;
                chartArea.AxisX.MajorGrid.LineColor = AppearanceStyle.LightItemBackground;
                chartArea.AxisY.MinorGrid.LineColor = AppearanceStyle.LightActiveBackground;
                chartArea.AxisY.LabelStyle.ForeColor = AppearanceStyle.LightTextColor;
                chartArea.AxisY.LineColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 30);
                chartArea.AxisY.LineWidth = 2;
                chartArea.AxisY.MajorTickMark.LineColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 30);
                chartArea.AxisY.MajorTickMark.LineWidth = 2;
                chartArea.AxisY.MajorGrid.LineColor = AppearanceStyle.LightActiveBackground;
                chartArea.AxisY.MinorGrid.LineColor = AppearanceStyle.LightActiveBackground;
            }
            foreach (Legend legend in base.Legends)
            {
                legend.BackColor = AppearanceStyle.LightItemBackground;
                legend.ForeColor = AppearanceStyle.LightTextColor;
                legend.Font = new Font(legend.Font.FontFamily, 8.5f);
            }
            foreach (Title title in base.Titles)
            {
                if (AppearanceStyle.theme == uuufteme.Dark)
                {
                    title.ForeColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 30);
                }
                else
                {
                    title.ForeColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 10);
                }
                title.Font = new Font("Verdana", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                title.Alignment = ContentAlignment.MiddleLeft;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            macs();
        }
    }
}
