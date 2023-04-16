using DevExpress.XtraCharts;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucDashBoard_Department_Chart : UserControl
    {
        public ucDashBoard_Department_Chart()
        {
            InitializeComponent();
        }
        private DataTable dataSource = new DataTable();
        public string MaBoPhan = string.Empty;
        public string TenBoPhan
        {
           set { gbDetail.Text = value; }
            get { return gbDetail.Text; }
        }
        public DataTable SetDataSource
        {
            set
            {
                dataSource = value;
                if(dataSource !=null)
                {
                    if(dataSource.Rows.Count >0)
                    {
                        SetvalueToControl();
                    }
                    else
                    {
                        ClearAllControl();
                    }
                }
                else
                {
                    ClearAllControl();
                }
            }
        }
        private bool isLeftMode = true;
        public bool LeftMode
        {
            get { return isLeftMode; }
            set { isLeftMode = value; ChangeMode(); }
        }
        private void ChangeMode()
        {
            //if(isLeftMode)
            //{
            //    flowLayoutPanel1.Dock = DockStyle.Fill;
            //    this.Width = 325;
            //    this.Height = 430;
            //}
            //else
            //{
            //    flowLayoutPanel1.Dock = DockStyle.None;
            //    this.Height = 165;
            //    this.Width = 967;
            //    flowLayoutPanel1.Width = 967;
            //    flowLayoutPanel1.Height = 165;
            //    flowLayoutPanel1.Anchor = AnchorStyles.Top;
            //}
        }
        private void ClearAllControl()
        {
            panel2.Controls.Clear();
        }
        private void SetvalueToControl()
        {
            if (dataSource == null) return;
            if (dataSource.Rows.Count > 0)
            {
                var dalaymau = dataSource.Rows[0]["DaLayMau"].ToString();
                var daLayMauDu = dataSource.Rows[0]["DaLayMauDu"].ToString();
                var daNhanMau = dataSource.Rows[0]["DaNhanMau"].ToString();
                var daNhanMauDu = dataSource.Rows[0]["DaNhanMauDu"].ToString();
                dataSource.Rows[0]["DaLayMau"] = (int.Parse(dalaymau == "" ? "0" : dalaymau) + int.Parse(daLayMauDu == "" ? "0" : daLayMauDu)).ToString();
                dataSource.Rows[0]["DaNhanMau"] = (int.Parse(daNhanMau == "" ? "0" : daNhanMau) + int.Parse(daNhanMauDu == "" ? "0" : daNhanMauDu)).ToString();
                dataSource.Columns.Remove("DaLayMauDu");
                dataSource.Columns.Remove("DaNhanMauDu");
                dataSource.Columns.Remove("ChuaNhanMau");
          
              
                // Create an empty chart.
                ChartControl pieChart = new ChartControl();

                // Create a pie series.
                Series series1 = new Series("TATDepartment", ViewType.Pie);

                // Bind the series to data.
                series1.DataSource = DataPoint.GetDataPoints(dataSource);
                series1.ArgumentDataMember = "Argument";
                series1.ValueDataMembers.AddRange(new string[] { "Value" });
                // Add the series to the chart.
                pieChart.Series.Add(series1);

                // Format the the series labels.
                series1.Label.TextPattern = "{A}: {V:N0}";

                // Format the series legend items.
                series1.LegendTextPattern = "{A}";
                pieChart.Legend.Direction = LegendDirection.LeftToRight;
                pieChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
                pieChart.Legend.AlignmentVertical = LegendAlignmentVertical.Top;

                SeriesTitle title = new SeriesTitle();
                title.Text = "Tổng số: {TV:#.##} mẫu";
                title.Alignment = System.Drawing.StringAlignment.Center;
                title.Dock = ChartTitleDockStyle.Bottom;
                ((PieSeriesView)series1.View).Titles.Clear();
                ((PieSeriesView)series1.View).Titles.Add(title);
               
             //  series1.Titles.Add(new ChartTitle() { Lines = new string[] { "Tổng số: {TV:#.##} mẫu" }, Dock = ChartTitleDockStyle.Bottom });
             // Adjust the position of series labels. 
             ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

                // Detect overlapping of series labels.
                ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

                // Access the view-type-specific options of the series.
                PieSeriesView myView = (PieSeriesView)series1.View;

                // Specify a data filter to explode points.
                myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
                    DataFilterCondition.GreaterThanOrEqual, 9));
                myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
                    DataFilterCondition.NotEqual, "Others"));
                myView.ExplodeMode = PieExplodeMode.UseFilters;
                myView.ExplodedDistancePercentage = 30;
                myView.RuntimeExploding = true;

                // Customize the legend.
                pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                // Add the chart to the form.
                pieChart.Dock = DockStyle.Fill;
                panel2.Controls.Add(pieChart);


                foreach (DataRow dr in dataSource.Rows)
                {
                    txtChay2Chieu.Text = dr["DaChayHaiChieu"].ToString();
                    txtGuiHTuDong.Text = dr["DaDownloadMiddleware"].ToString();
                    //  txtTongSoBN.Text = dr["TongSoBenhNhan"].ToString(); ;
                }
            }
        }
        public class DataPoint
        {
            public string Argument { get; set; }
            public double Value { get; set; }

            public static List<DataPoint> GetDataPoints(DataTable dataSourceIn)
            {
                var lst = new List<DataPoint>();
                foreach (DataColumn dtc in dataSourceIn.Columns)
                {
                    if (!dtc.ColumnName.Equals("Ngay", System.StringComparison.OrdinalIgnoreCase)
                        && !dtc.ColumnName.Equals("BoPhan", System.StringComparison.OrdinalIgnoreCase)
                        && !dtc.ColumnName.Equals("DaChayHaiChieu", System.StringComparison.OrdinalIgnoreCase)
                        && !dtc.ColumnName.Equals("DaDownloadMiddleware", System.StringComparison.OrdinalIgnoreCase)
                        && !dtc.ColumnName.Equals("TongSoBenhNhan", System.StringComparison.OrdinalIgnoreCase)
                        && !dtc.ColumnName.Equals("MaBoPhan", System.StringComparison.OrdinalIgnoreCase)
                        && !dtc.ColumnName.Equals("TenBoPhan", System.StringComparison.OrdinalIgnoreCase)
                        )
                    {
                        var value = dataSourceIn.Rows[0][dtc.ColumnName].ToString().Trim();
                        var point = new DataPoint()
                        {
                            Argument = GetColumnName(dtc.ColumnName),
                            Value = (string.IsNullOrEmpty(value) ? 0 : double.Parse(value))
                        };
                        lst.Add(point);
                    }
                }

                return lst;
            }
            private static string GetColumnName(string columnIn)
            {
                return columnIn.Replace("DaLayMauDu", "Đã lấy mẫu đủ").Replace("DaNhanMauDu", "Đã nhận mẫu đủ")
                     .Replace("DaLayMau", "Đã lấy mẫu").Replace("DaNhanMau", "Đã nhận mẫu")
                     .Replace("YeuCauLayLai", "Yêu cầu lấy lại").Replace("DaDuKetQua", "Đã đủ kết quả")
                     .Replace("ChuaLayMau", "Chờ lấy mẫu").Replace("ChoNhanMau", "Chờ nhận mẫu").Replace("DaCoKetQua", "Có kết quả (Chưa đủ)")
                     .Replace("DaIn", "Đã in").Replace("DaDuyet", "Đã duyệt")
                     .Replace("DaChayHaiChieu", "Đang chạy 2 chiều").Replace("DaDownloadMiddleware", "Đã gửi middleware");
            }
        }

        private void ucDashBoard_Department_Chart_Load(object sender, System.EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
