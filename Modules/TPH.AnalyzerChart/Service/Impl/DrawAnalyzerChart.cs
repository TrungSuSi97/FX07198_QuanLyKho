using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.AnalyzerChart.Constants;
using TPH.AnalyzerChart.Model;

namespace TPH.AnalyzerChart.Service.Impl
{
    public class DrawAnalyzerChart : IDrawAnalyzerChartSevice
    {
        #region Vẽ biểu đồ cho máy abx

        private static Graphics G;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Color"></param>
        /// <param name="strHistoResult"></param>
        /// <param name="pb"></param>
        public void DrawChartABX(Color _Color, string strHistoResult, Constants.enumLoaiXnVeHinh loaiXN
            , ref PictureBox pb)
        {
            Size s = new Size(211, 151);
            Bitmap bmp = new Bitmap(s.Width, s.Height);
            int XStart = 10, XEnd = 170, YStart = 10, YEnd = 100;
            float Xcu = XStart, Ycu = XEnd, X = 0, Y = 0, Dx = 0;
            byte[] bytes;
            G = Graphics.FromImage(bmp);
            G.Clear(Color.White);
            // G.FillRectangles(new SolidBrush(Color.LightGray), new Rectangle[] { new Rectangle(0, 0, bmp.Width, bmp.Height) });
            #region Draw line X, Y

            Pen lineXY = new Pen(Color.Blue, 1);
            lineXY.StartCap = LineCap.Flat;
            lineXY.EndCap = LineCap.Flat;
            lineXY.DashStyle = DashStyle.Solid;

            Pen line = new Pen(_Color, 1);
            line.StartCap = LineCap.Flat;
            line.EndCap = LineCap.Flat;
            line.DashStyle = DashStyle.Solid;

            Pen lineDot;
            Brush brush = new SolidBrush(Color.Blue);

            G.DrawLine(lineXY, XStart - 1, YEnd + 1, s.Width, YEnd + 1);
            G.DrawLine(lineXY, XStart - 1, YStart, XStart - 1, YEnd + 1);
            #endregion
            #region Vẽ khung biểu đồ
            //vẽ tọa độ trên trục X
            if (loaiXN == Constants.enumLoaiXnVeHinh.WBC)
            {
                lineDot = new Pen(Color.MediumTurquoise, 1);
                lineDot.DashStyle = DashStyle.Dash;
                //vẽ tọa độ 50
                G.DrawLine(new Pen(_Color, 1), XStart + 20, YEnd - 4, XStart + 20, YEnd + 4);
                //vẽ tọa độ chính 100-->400
                for (int i = 1; i <= 4; i++)
                {
                    G.DrawLine(new Pen(_Color, 1), XStart + (i * 40), YEnd - 4, XStart + (i * 40), YEnd + 4);
                }
                G.DrawString("50  100       200       300       400", new Font("Arial", 8), brush, XStart + 13, YEnd + 7);

                G.DrawString("WBC", new Font("Arial", 8, FontStyle.Bold), brush, s.Width - 35, 7);

                //2 đường gạch đứt
                G.DrawLine(lineDot, 42, YStart, 42, YEnd);
                G.DrawLine(lineDot, 54, YStart, 54, YEnd);
            }
            else if (loaiXN == Constants.enumLoaiXnVeHinh.RBC)
            {
                //vẽ tọa độ 30
                G.DrawLine(new Pen(_Color, 1), XStart + 25, YEnd - 4, XStart + 25, YEnd + 4);
                //vẽ tọa độ chính 50-->200
                for (int i = 1; i <= 4; i++)
                {
                    G.DrawLine(new Pen(_Color, 1), XStart + (i * 40), YEnd - 4, XStart + (i * 40), YEnd + 4);
                }
                G.DrawString("30             100                     200", new Font("Arial", 8), brush, XStart + 18, YEnd + 7);
                G.DrawString("RBC", new Font("Arial", 8, FontStyle.Bold), brush, s.Width - 32, 7);
            }
            else if (loaiXN == Constants.enumLoaiXnVeHinh.PLT)
            {
                lineDot = new Pen(Color.Violet, 1);
                lineDot.DashStyle = DashStyle.Dash;
                //tọa độ 5--30, 6 khoảng đều nhau
                for (int i = 1; i <= 6; i++)
                {
                    G.DrawLine(new Pen(_Color, 1), (float)(XStart + (i * 26.7)), YEnd - 4, (float)(XStart + (i * 26.7)), YEnd + 4);
                }
                G.DrawString("2    5     10              20              30", new Font("Arial", 8), brush, XStart + 6, YEnd + 7);
                G.DrawString("PLT", new Font("Arial", 8, FontStyle.Bold), brush, s.Width - 30, 7);
                //vẽ đường gạch đứt
                G.DrawLine(lineDot, (float)(XStart + (5 * 26.7)), YStart, (float)(XStart + (5 * 26.7)), YEnd);
            }
            #endregion

            #region vẽ tô màu biểu đồ
            if (strHistoResult != "")
            {
                Dx = (((float)XEnd - (float)XStart) / 128);
                Encoding enc = Encoding.GetEncoding("Windows-1258",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());
                bytes = enc.GetBytes(strHistoResult);
                for (int j = 0; j < 127; j++)
                {
                    X = XStart + (j * Dx);

                    Y = YEnd - (int)((Convert.ToInt32(bytes[j]) - 32) * 0.385);
                    if (j > 0)
                    {
                        G.DrawLine(line, Xcu, Ycu, X, Y);
                        //Tô màu
                        G.DrawLine(line, X, Y, X, YEnd);
                        G.DrawLine(line, (X + Xcu) / 2, (Y + Ycu) / 2, (X + Xcu) / 2, YEnd);
                    }

                    Xcu = X;
                    Ycu = Y;
                }
            }
            #endregion
            G.Dispose();
            pb.Image = bmp;
        }

        public static void DrawChartCeDiff
          (Color _Color, string strHistoResult, Constants.enumLoaiXnVeHinh loaiXN, ref PictureBox pb)
        {
            Size s = new Size(211, 151);
            Bitmap bmp = new Bitmap(s.Width, s.Height);

            int XStart = 10, XEnd = s.Width - 11, YStart = 10, YEnd = s.Height - 20;
            //170, 100;
            float Xcu = XStart, Ycu = XEnd, X = 0, Y = 0, Dx = 0;
            string[] arrValues;
            G = Graphics.FromImage(bmp);
            G.Clear(Color.White);
            //G.FillRectangles(new SolidBrush(Color.LightGray), new Rectangle[] { new Rectangle(0, 0, bmp.Width, bmp.Height) });
            #region Draw line X, Y
            Pen lineXY = new Pen(Color.Blue, 1);
            lineXY.StartCap = LineCap.Flat;
            lineXY.EndCap = LineCap.Flat;
            lineXY.DashStyle = DashStyle.Solid;

            Pen lineGraph = new Pen(_Color, 1);
            lineGraph.StartCap = LineCap.Flat;
            lineGraph.EndCap = LineCap.Flat;
            lineGraph.DashStyle = DashStyle.Solid;


            Pen lineDot;
            Brush brush = new SolidBrush(Color.Blue);

            G.DrawLine(lineXY, XStart - 1, YEnd + 1, s.Width, YEnd + 1);
            G.DrawLine(lineXY, XStart - 1, YStart, XStart - 1, YEnd + 1);
            float maxValue = 1;
            #endregion
            #region Vẽ khung biểu đồ
            //vẽ tọa độ trên trục X
            lineDot = new Pen(Color.MediumTurquoise, 1);
            lineDot.DashStyle = DashStyle.Dash;
            if (loaiXN == enumLoaiXnVeHinh.WBC)
            {
                maxValue = 250;
                G.DrawString("WBC", new Font("Arial", 8, FontStyle.Bold), brush, s.Width - 38, 7);
                //2 đường gạch đứt
                //var Xof25 = (int)(((float)XEnd * 25) / (float)maxValue);
                //G.DrawLine(lineDot, Xof25, YStart, Xof25, YEnd);
                //var Xof35 = (int)(((float)XEnd * 35) / (float)maxValue);
                //G.DrawLine(lineDot, Xof35, YStart, Xof35, YEnd);
                //var Xof45 = (int)(((float)XEnd * 45) / (float)maxValue);
                //G.DrawLine(lineDot, Xof45, YStart, Xof45, YEnd);
                //var Xof50 = (int)(((float)XEnd * 50) / (float)maxValue);
                //G.DrawLine(lineDot, Xof50, YStart, Xof50, YEnd);
                //var Xof100 = (int)(((float)XEnd * 100) / (float)maxValue);
                //G.DrawLine(lineDot, Xof100, YStart, Xof100, YEnd);
                //var Xof125 = (int)(((float)XEnd * 125) / (float)maxValue);
                //G.DrawLine(lineDot, Xof125, YStart, Xof125, YEnd);
                //var Xof150 = (int)(((float)XEnd * 150) / (float)maxValue);
                //G.DrawLine(lineDot, Xof150, YStart, Xof150, YEnd);
                //var Xof200 = (int)(((float)XEnd * 200) / (float)maxValue);
                //G.DrawLine(lineDot, Xof200, YStart, Xof200, YEnd);
                var Xof250 = (int)(((float)XEnd * 250) / (float)maxValue);
                G.DrawString(string.Format("{0}fL", maxValue), new Font("Arial", 8), brush, Xof250 - 20, YEnd + 5);
                G.DrawLine(lineDot, Xof250, YStart, Xof250, YEnd);
            }
            else if (loaiXN == enumLoaiXnVeHinh.RBC)
            {
                maxValue = 200;
                G.DrawString("RBC", new Font("Arial", 8, FontStyle.Bold), brush, s.Width - 37, 7);
                var Xof200 = (int)(((float)XEnd * 200) / (float)maxValue);
                G.DrawString(string.Format("{0}fL", maxValue), new Font("Arial", 8), brush, Xof200 - 20, YEnd + 5);
                G.DrawLine(lineDot, Xof200, YStart, Xof200, YEnd);
            }
            else if (loaiXN == enumLoaiXnVeHinh.PLT)
            {
                maxValue = 400;
                G.DrawString("PLT", new Font("Arial", 8, FontStyle.Bold), brush, s.Width - 35, 7);
                //vẽ đường gạch đứt
                var Xof300 = (int)(((float)XEnd * 300) / (float)maxValue);
                G.DrawString(string.Format("{0}fL", ((maxValue - 100) / 10)), new Font("Arial", 8), brush, Xof300 - 15, YEnd + 5);
                G.DrawLine(lineDot, Xof300, YStart, Xof300, YEnd);
            }
            #endregion

            #region vẽ tô màu biểu đồ
            if (strHistoResult != "")
            {
                arrValues = strHistoResult.Split('\\');
                Dx = (((float)XEnd - (float)XStart) / 255);
                for (int j = 0; j < 255; j++)
                {
                    X = XStart + (j * Dx);
                    // * 0.385
                    Y = YEnd - (int)(Convert.ToInt32(arrValues[j]));
                    if (j > 0)
                    {
                        G.DrawLine(lineGraph, Xcu, Ycu, X, Y);
                        //Tô màu
                        G.DrawLine(lineGraph, X, Y, X, YEnd);
                        G.DrawLine(lineGraph, (X + Xcu) / 2, (Y + Ycu) / 2, (X + Xcu) / 2, YEnd);
                    }

                    Xcu = X;
                    Ycu = Y;
                }
            }
            #endregion
            G.Dispose();
            pb.Image = bmp;
        }
        #endregion
        #region Get Image from base64
        public void BrawChartFrombase(string strHistoResult, Constants.enumLoaiXnVeHinh loaiXN, ref PictureBox pb)
        {
            pb.Image = ImgFromBase64(strHistoResult);
        }
        #endregion
        #region Convert base64 to bmp
        public Image ImgFromBase64(string baseString)
        {
            var byteArray = Convert.FromBase64String(baseString);
            return (Bitmap)((new ImageConverter()).ConvertFrom(byteArray));
        }
        #endregion
        #region Draw chart from data
        public void DrawChartFromData(List<ChartInfo> chartInfo
            , ref PictureBox wbc, ref PictureBox rbc, ref PictureBox plt
            , ref PictureBox s10, ref PictureBox s90)
        {
            if (chartInfo.Any())
            {
                var protocol = chartInfo.First().GiaoThuc;
                switch (protocol)
                {
                    case GiaoThucVeHinh.ELITE580:
                    case GiaoThucVeHinh.NCC51:
                        foreach (var item in chartInfo)
                        {
                            var maXn = GetLoaiVeHinh(item.MaMay);
                            var img = ImgFromBase64(item.ChuoiHinhAnh);
                            if (maXn == enumLoaiXnVeHinh.WBC)
                            {
                                wbc.Visible = true;
                                wbc.Image = img;
                            }
                            else if (maXn == enumLoaiXnVeHinh.RBC)
                            {
                                rbc.Visible = true;
                                rbc.Image = img;
                            }
                            else if (maXn == enumLoaiXnVeHinh.PLT)
                            {
                                plt.Visible = true;
                                plt.Image = img;
                            }
                            else if (maXn == enumLoaiXnVeHinh.S10Catter)
                            {
                                s10.Visible = true;
                                s10.Image = img;
                            }
                            else if (maXn == enumLoaiXnVeHinh.S90Catter)
                            {
                                s90.Visible = true;
                                s90.Image = img;
                            }
                        }
                        break;
                    case GiaoThucVeHinh.ABX:
                        foreach (var item in chartInfo)
                        {
                            var maXn = GetLoaiVeHinh(item.MaMay);
                            if (maXn == enumLoaiXnVeHinh.WBC)
                            {
                                wbc.Visible = true;
                                DrawChartABX(Color.Green, item.ChuoiHinhAnh, maXn, ref wbc);
                            }
                            else if (maXn == enumLoaiXnVeHinh.RBC)
                            {
                                rbc.Visible = true;
                                DrawChartABX(Color.Red, item.ChuoiHinhAnh, maXn, ref rbc);
                            }
                            else if (maXn == enumLoaiXnVeHinh.PLT)
                            {
                                plt.Visible = true;
                                DrawChartABX(Color.Blue, item.ChuoiHinhAnh, maXn, ref plt);
                            }
                        }
                        break;
                    case GiaoThucVeHinh.CELLDIFF:
                        foreach (var item in chartInfo)
                        {
                            var maXn = GetLoaiVeHinh(item.MaMay);
                            if (maXn == enumLoaiXnVeHinh.WBC)
                            {
                                wbc.Visible = true;
                                DrawChartCeDiff(Color.Green, item.ChuoiHinhAnh, maXn, ref wbc);
                            }
                            else if (maXn == enumLoaiXnVeHinh.RBC)
                            {
                                rbc.Visible = true;
                                DrawChartCeDiff(Color.Red, item.ChuoiHinhAnh, maXn, ref rbc);
                            }
                            else if (maXn == enumLoaiXnVeHinh.PLT)
                            {
                                plt.Visible = true;
                                DrawChartCeDiff(Color.Blue, item.ChuoiHinhAnh, maXn, ref plt);
                            }
                        }
                        break;
                    default:
                        return;
                }
            }
        }
        public void GetImageFromData()
        {

        }
        public enumLoaiXnVeHinh GetLoaiVeHinh(string maxnMay)
        {
            if (maxnMay.ToLower().Contains(AnalyzerChartConstants.RBC_Histogram.ToLower()))
                return enumLoaiXnVeHinh.RBC;
            else if (maxnMay.ToLower().Contains(AnalyzerChartConstants.WBC_Histogram.ToLower()))
                return enumLoaiXnVeHinh.WBC;
            else if (maxnMay.ToLower().Contains(AnalyzerChartConstants.PLT_Histogram.ToLower()))
                return enumLoaiXnVeHinh.PLT;
            else if (maxnMay.ToLower().Contains(AnalyzerChartConstants.S10_DDIFFCattergram.ToLower()))
                return enumLoaiXnVeHinh.S10Catter;
            else if (maxnMay.ToLower().Contains(AnalyzerChartConstants.S90_DDIFFCattergram.ToLower()))
                return enumLoaiXnVeHinh.S90Catter;
            else
                return enumLoaiXnVeHinh.None;
        }
        #endregion
    }
}
