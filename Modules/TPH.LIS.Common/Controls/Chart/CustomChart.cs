using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using TPH.LIS.Common.Chart;

namespace TPH.LIS.Common.Controls.Chart
{
    public partial class CustomChart : UserControl
    {
        public CustomChart()
        {
            InitializeComponent();
         //  // DrawChart(DefaultDraw());
        }
       
        private Size chartSize = new Size(1024, 768);
        private string xName = "X";
        private string yName = "Y";
        private string chartTile = "TPH Custom Chart";
        private string chartSubTile = "TPH Custom Chart subtitle";
        private Color lineColorX = Color.Blue;
        private Color lineColorY = Color.Blue;
        private Color lineColorMerge = Color.Red;
        private Color lineColorPointVal = Color.Blue;
        private Brush nameXColor = Brushes.Red;
        private Brush nameYColor = Brushes.Red;
        private Brush pointValueColor = Brushes.Black;
        private Brush breakPointColor = Brushes.Black;
        private Brush axisNameColor = Brushes.Black;
        private int lineXWeight = 3;
        private int lineYWeight = 3;
        private int lineMergeWeight = 1;
        private int leftPadding = 60;
        private int rightPadding = 30;
        private int topPadding = 30;
        private int bottomPadding = 60;
        private int arrowWidth = 5;
        private int arrowDistance = 5;
        private int autoAddHeight = 100;
        private int autoAddWidth = 200;
        private Font breakPointFont = new Font("Arial", 9, FontStyle.Regular);
        private Font valuePoint = new Font("Arial", 9, FontStyle.Regular);
        private Font axisNameFont = new Font("Arial", 9, FontStyle.Regular);
        private bool drawHorizotalDottedLine = false;

        private int maXDrawOfX = 0;
        private int maXDrawOfY = 0;
        private double maXValueOfY = 0;
        private int avgOfX = 0;
        private int avgOfY = 0;
        private float percentOfY = 0;
        private List<PointInfo> currentSource;

        private int HeSoNhan = 100;

        [Category("Custom")]
        public Size ChartSize
        {
            get
            {
                return chartSize;
            }

            set
            {
                chartSize = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public string XName
        {
            get
            {
                return xName;
            }

            set
            {
                xName = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public string YName
        {
            get
            {
                return yName;
            }

            set
            {
                yName = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public string ChartTile
        {
            get
            {
                return chartTile;
            }

            set
            {
                chartTile = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public string ChartSubTile
        {
            get
            {
                return chartSubTile;
            }

            set
            {
                chartSubTile = value;
                lblLabelSub.Text = chartSubTile;
                lblLabelSub.Visible = !string.IsNullOrEmpty(chartSubTile);
            }
        }
        [Category("Custom")]
        public Color LineColorX
        {
            get
            {
                return lineColorX;
            }

            set
            {
                lineColorX = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color LineColorY
        {
            get
            {
                return lineColorY;
            }

            set
            {
                lineColorY = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int LineXWeight
        {
            get
            {
                return lineXWeight;
            }

            set
            {
                lineXWeight = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int LineYWeight
        {
            get
            {
                return lineYWeight;
            }

            set
            {
                lineYWeight = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int LeftPadding
        {
            get
            {
                return leftPadding;
            }

            set
            {
                leftPadding = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int RightPadding
        {
            get
            {
                return rightPadding;
            }

            set
            {
                rightPadding = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int TopPadding
        {
            get
            {
                return topPadding;
            }

            set
            {
                topPadding = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int BottomPadding
        {
            get
            {
                return bottomPadding;
            }

            set
            {
                bottomPadding = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int ArrowWidth
        {
            get
            {
                return arrowWidth;
            }

            set
            {
                arrowWidth = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int ArrowDistance
        {
            get
            {
                return arrowDistance;
            }

            set
            {
                arrowDistance = value;
            }
        }
        [Category("Custom")]
        public int AutoAddHeight
        {
            get
            {
                return autoAddHeight;
            }

            set
            {
                autoAddHeight = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int AutoAddWidth
        {
            get
            {
                return autoAddWidth;
            }

            set
            {
                autoAddWidth = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color NameXColor
        {
            get
            {
                return ((SolidBrush)nameXColor).Color;
            }

            set
            {
                nameXColor = new SolidBrush(value); 
               // DrawChart(DefaultDraw());
            }
        }
      
        [Category("Custom")]
        public Color LineColorMerge
        {
            get
            {
                return lineColorMerge;
            }

            set
            {
                lineColorMerge = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color LineColoroPointVal
        {
            get
            {
                return lineColorPointVal;
            }

            set
            {
                lineColorPointVal = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public int LineMergeWeight
        {
            get
            {
                return lineMergeWeight;
            }

            set
            {
                lineMergeWeight = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Font BreakPointFont
        {
            get
            {
                return breakPointFont;
            }

            set
            {
                breakPointFont = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Font ValuePoint
        {
            get
            {
                return valuePoint;
            }

            set
            {
                valuePoint = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color PointValueColor
        {
            get
            {
                return ((SolidBrush)pointValueColor).Color;
            }

            set
            {
                pointValueColor = new SolidBrush(value);
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color BreakPointColor
        {
            get
            {
                return ((SolidBrush)breakPointColor).Color;
            }

            set
            {
                breakPointColor = new SolidBrush(value);
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color NameYColor
        {
            get
            {
                return ((SolidBrush)nameYColor).Color;
            }

            set
            {
                nameYColor = new SolidBrush(value);
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Color AxisNameColor
        {
            get
            {
                return ((SolidBrush)axisNameColor).Color;
            }

            set
            {
                axisNameColor = new SolidBrush(value);
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public Font AxisNameFont
        {
            get
            {
                return axisNameFont;
            }

            set
            {
                axisNameFont = value;
               // DrawChart(DefaultDraw());
            }
        }
        [Category("Custom")]
        public bool DrawHorizotalDottedLine
        {
            get
            {
                return drawHorizotalDottedLine;
            }

            set
            {
                drawHorizotalDottedLine = value;
               // DrawChart(DefaultDraw());
            }
        }
        public Image GetChart()
        {
            return pbChart.Image;
        }
        public void ClearImage()
        {
            pbChart.Image = null;
        }
        private Graphics SetGraphicOption(Bitmap drawAreas)
        {
            Graphics grChart = Graphics.FromImage(drawAreas);
            grChart.CompositingQuality = CompositingQuality.HighQuality;
            grChart.CompositingMode = CompositingMode.SourceOver;
            return grChart;
        }
        public void DrawChart(List<PointInfo> chartInfo)
        {
            if (!string.IsNullOrEmpty(ChartTile))
            {
                lblLabelMain.Text = ChartTile;
                lblLabelMain.Visible = true;
            }
            else
                lblLabelMain.Visible = false;

            if (!string.IsNullOrEmpty(ChartSubTile))
            {
                lblLabelSub.Text = ChartSubTile;
                lblLabelSub.Visible = true;
            }
            else
                lblLabelSub.Visible = false;

            Bitmap drawAreas = new Bitmap(ChartSize.Width + AutoAddWidth, ChartSize.Height + AutoAddHeight);
            pbChart.Image = drawAreas;
            Graphics grChart = SetGraphicOption(drawAreas);
            CalculateMaxAndAvgPoint(chartInfo, drawAreas);
            //Vẽ trục x 
            Pen mypenX = new Pen(LineColorX, LineXWeight);
            Point xStartPoint = new Point(LeftPadding - 5, drawAreas.Height - BottomPadding);// -5 cho kéo dài phần đầu ra 
            Point xEndPoint = new Point(drawAreas.Width - RightPadding, drawAreas.Height - BottomPadding);

            Point xRealEndPoint = new Point(drawAreas.Width - RightPadding, drawAreas.Height - BottomPadding);

            Point xStartPointArrowUp = new Point(xEndPoint.X - ArrowWidth, xEndPoint.Y - (ArrowDistance / 2));
            Point xEndPointArrowUp = xEndPoint;

            Point xStartPointArrowDown = new Point(xEndPoint.X - ArrowWidth, xEndPoint.Y + (ArrowDistance / 2));
            Point xEndPointArrowDown = xEndPoint;

            grChart.DrawLine(mypenX, xStartPoint, xEndPoint);
            grChart.DrawLine(mypenX, xStartPointArrowUp, xEndPointArrowUp);
            grChart.DrawLine(mypenX, xStartPointArrowDown, xEndPointArrowDown);

            //Vẽ tên trục X
            if (!string.IsNullOrEmpty(XName))
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                var size = grChart.MeasureString(XName, axisNameFont, 250, format);

                grChart.DrawString(XName, axisNameFont, axisNameColor
                    , xEndPoint.X - size.Width/2
                    , xEndPoint.Y + 10
                    , format);
            }

            //Vẽ trục Y
            Pen mypenY = new Pen(LineColorY, LineYWeight);
            Point yStartPoint = new Point(LeftPadding, drawAreas.Height - BottomPadding);
            Point yRealStartPoint = new Point(LeftPadding, drawAreas.Height - (BottomPadding - 5)); // - 5 cho nó kéo dài phần đầu ra ngoài 1 chút

            Point yEndPoint = new Point(LeftPadding, TopPadding);

            Point yStartPointArrowLeft = new Point(yEndPoint.X - (ArrowDistance / 2), yEndPoint.Y + ArrowWidth);
            Point yEndPointArrowLeft = yEndPoint;

            Point yStartPointArrowRight = new Point(yEndPoint.X + (ArrowDistance / 2), yEndPoint.Y + ArrowWidth);
            Point yEndPointArrowRight = yEndPoint;

            grChart.DrawLine(mypenY, yRealStartPoint, yEndPoint);
            grChart.DrawLine(mypenY, yStartPointArrowLeft, yEndPointArrowLeft);
            grChart.DrawLine(mypenY, yStartPointArrowRight, yEndPointArrowRight);

            //Vẽ tên trục Y
            if (!string.IsNullOrEmpty(YName))
            {
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                var size = grChart.MeasureString(YName, axisNameFont, 250, format);

                grChart.DrawString(YName, axisNameFont, axisNameColor
                    , yEndPoint.X - size.Width
                    , yEndPoint.Y 
                    , format);
            }

            DrawBreakPoint(chartInfo, drawAreas);
        }
        private void DrawHorizotalDottedLineonChart(Point startPoint, Point endPoint, Bitmap drawAreas)
        {
            Graphics grChart = SetGraphicOption(drawAreas);
            var drawPen = new Pen(lineColorX, 1);
            float[] dashValues = { 5, 2, 15, 4 };
            drawPen.DashPattern = dashValues;
            drawPen.DashStyle = DashStyle.Dash;
            grChart.DrawLine(drawPen, startPoint, endPoint);
        }
        public void DrawBreakPoint(List<PointInfo> chartInfo, Bitmap drawAreas)
        {
            Graphics grChart = SetGraphicOption(drawAreas);

            //Draw x breakpoint
            Pen mypenX = new Pen(LineColorX, LineYWeight);
            var iX = -1;

            foreach (var item in chartInfo)
            {
                iX++;

                Point xStartPoint = new Point(LeftPadding + (avgOfX * (iX + 1)), drawAreas.Height - BottomPadding - 3);
                Point xEndPoint = new Point(LeftPadding + (avgOfX * (iX + 1)), drawAreas.Height - BottomPadding + 3);

                grChart.DrawLine(mypenX, xStartPoint, xEndPoint);

                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                var size = grChart.MeasureString(item.XValue, breakPointFont, avgOfX, format);

                grChart.DrawString(item.XValue, breakPointFont, breakPointColor
                    , LeftPadding + (avgOfX * (iX + 1)) - size.Width / 8
                    , (drawAreas.Height - BottomPadding) + size.Height
                    , format);
            }

            //draw Y break point
            Pen mypenY = new Pen(LineColorY, LineYWeight);

            for (int iY = 0; iY <= chartInfo.Count; iY++)
            {
                var breakPointY = (avgOfY * (iY + 1));

                var positionY = drawAreas.Height - BottomPadding - (int)((iY + 1) * avgOfY * percentOfY);

                Point yStartPoint = new Point(LeftPadding - 3, positionY);
                Point yEndPoint = new Point(LeftPadding + 3, positionY);

                grChart.DrawLine(mypenY, yStartPoint, yEndPoint);
                //vẽ giá trị
                string strYValue = ((float)breakPointY / HeSoNhan).ToString();
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                var size = grChart.MeasureString(strYValue, breakPointFont, avgOfX, format);

                grChart.DrawString(strYValue, breakPointFont, breakPointColor, LeftPadding - 55
                    , positionY - (size.Height / 8), format);

                Point xEndPoint = new Point(drawAreas.Width, positionY);
                DrawHorizotalDottedLineonChart(yStartPoint, xEndPoint, drawAreas);

            }

            DrawPoint(chartInfo, drawAreas);
        }

        private void DrawPoint(List<PointInfo> chartInfo, Bitmap drawAreas)
        {
            Graphics grChart = SetGraphicOption(drawAreas);
            //Draw point
            Point lastPoint = new Point(0, 0);
            int xCount = -1;
            foreach (var itemPoint in chartInfo)
            {
                xCount++;
                var positionY = drawAreas.Height - BottomPadding - itemPoint.YValueDraw;
                var positionX = LeftPadding + (avgOfX * (xCount + 1));
                var newPoint = new Point(positionX, positionY);
                Pen mypenPoint = new Pen(lineColorPointVal, 8);

                //vẽ giá trị
                Pen mypenMergePoint = new Pen(lineColorMerge, 2);
                string strYValue = (itemPoint.YValue / HeSoNhan).ToString();
                StringFormat format = new StringFormat();
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;
                var size = grChart.MeasureString(strYValue, valuePoint, avgOfX, format);
                grChart.DrawString(strYValue, valuePoint, pointValueColor, positionX
                 , positionY - size.Height, format);

                if (lastPoint.X != 0 || lastPoint.Y != 0)
                {
                    //điểm mới thấp hơn điểm cũ
                    lastPoint = new Point(lastPoint.X + 4, lastPoint.Y);
                    var temNewpoint = new Point(newPoint.X - 4, newPoint.Y);
                    grChart.DrawLine(mypenMergePoint, lastPoint, temNewpoint);

                    Rectangle r = new Rectangle(lastPoint.X - 4, lastPoint.Y - 4, 8, 8);
                    grChart.DrawEllipse(mypenPoint, r);
                }
                Rectangle r2 = new Rectangle(newPoint.X - 4, newPoint.Y - 4, 8, 8);
                grChart.DrawEllipse(mypenPoint, r2);

                lastPoint = newPoint;
            }
        }

        private void CalculateMaxAndAvgPoint(List<PointInfo> chartInfo, Bitmap drawArrea)
        {
            maXValueOfY = -1000000000;
            if (chartInfo.Count > 0)
            {
                bool isDecimal = false;
                int decimals = 1;
                bool lessThanOne = false;
                List<string> containtY = new List<string>();

                foreach (var item in chartInfo)
                {
                    double d = item.YValue;
                    bool is_integer = unchecked(d == (int)d);
                    if (!is_integer)
                    {
                        if (d < 1)
                        {
                            lessThanOne = true;
                            isDecimal = true;
                            string[] a = d.ToString().Split(new char[] { '.' });
                            if (decimals < a[1].Length)
                                decimals = a[1].Length;
                        }
                    }
                    if (item.YValue > maXValueOfY)
                        maXValueOfY = item.YValue;
                }

                if (lessThanOne && maXValueOfY < 10)
                {
                    HeSoNhan = 1000;
                }
                else
                    HeSoNhan = 1;
                //tính toán lại max value vìkhi nhân hệ số sẽ sai.
                maXValueOfY = -1000000000;
                foreach (var item2 in chartInfo)
                {
                    item2.YValue = item2.YValue * HeSoNhan;
                    if (item2.YValue > maXValueOfY)
                        maXValueOfY = item2.YValue;
                }

                avgOfY = (int)(maXValueOfY / chartInfo.Count);
                maXDrawOfY = (int)(maXValueOfY + avgOfY);

                //tính toán cho tương ứng với pixel cả biểu đồ
                //Y dựa vào height
                //Phải ép kiễu float khôgn thì các giá trị lớn sẽ không vẽ được
                percentOfY = (drawArrea.Height - BottomPadding - AutoAddHeight) / (float)(maXDrawOfY == 0 ? 1 : maXDrawOfY);
                maXValueOfY = (int)(maXValueOfY * percentOfY);

                avgOfX = ChartSize.Width / chartInfo.Count;
                maXDrawOfX = drawArrea.Width - RightPadding;

                //X dựa vào width
                //percentOfX = (100 * maXDrawOfX) / ChartSize.Width;
                //convert lại các giá trị sau khi có dữ liệu tỉ lệ
                foreach (var item in chartInfo)
                {
                    item.YValueDraw = (int)(item.YValue * percentOfY);
                }

            }
        }
        public enum CustomChartEnumPosition
        {
            Top = 1,
            Bottom = 2,
            Left = 3,
            Right = 4
        }
        private List<PointInfo> DefaultDraw()
        {
            if (currentSource == null)
            {
                var random = new Random(10);
                var lst = new List<PointInfo>();
                for (int i = 1; i <= 10; i++)
                {
                    var poitb = new PointInfo();
                    poitb.XName = string.Format("X{0}", i);
                    poitb.YName = string.Format("Y{0}", i);
                    poitb.YValue = random.Next(15, 50000);
                    poitb.XValue = string.Format("190721\n(12234{0})", i);
                    lst.Add(poitb);
                }
                return lst;
            }
            else
                return currentSource;
      
        }
    }

}
