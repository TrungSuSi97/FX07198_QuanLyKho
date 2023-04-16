using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;
using BarcodeLib;
using TPH.LIS.BarcodePrinting.Barcode;
using System.Collections.Generic;

namespace TPH.LIS.BarcodePrinting
{
    public class StandardBarcodeService
    {
        private static StandardBarcodeService _barcodeService = null;

        public const string DefaultSettingsFileName = @"Barcode\PageSettings.xml";
        public const string DefaultSettingsFileNameOld = "PageSettings.xml";

        public static StandardBarcodeService GetInstance()
        {
            if (_barcodeService == null)
            {
                _barcodeService = new StandardBarcodeService();
            }

            return _barcodeService;
        }

        private StandardBarcodeService()
        {
        }
        public string PrintBarcode(BarcodePageSetting settings, BarcodeProperties barcodeInfo)
        {
            try
            {
                if (settings == null)
                    settings = LoadSettingsDefaultFileConfig();
                var printService = new PrintService(settings.BarcodePrinterName);
                for (int i = 0; i < barcodeInfo.DanhSachTube.Count; i++)
                {
                    var tubeInfo = barcodeInfo.DanhSachTube[i];
                    settings.TextTopLine1Value = SetDataToProerties(settings.FirstLineFontSetting.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextTopLine2Value = SetDataToProerties(settings.SecondLineFontSetting.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextBottomLine1Value = SetDataToProerties(settings.DescriptionFontSetting.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.BarcodeText = SetDataToProerties(settings.DescriptionFontSetting.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextRightLineValue1 = SetDataToProerties(settings.RightSideFontSetting1.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextRightLineValue2 = SetDataToProerties(settings.RightSideFontSetting2.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextRightLineValue3 = SetDataToProerties(settings.RightSideFontSetting3.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextRightLineValue4 = SetDataToProerties(settings.RightSideFontSetting4.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextRightLineValue5 = SetDataToProerties(settings.RightSideFontSetting5.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextRightLineValue6 = SetDataToProerties(settings.RightSideFontSetting6.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLeftLineValue1 = SetDataToProerties(settings.LeftSideFontSetting1.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLeftLineValue2 = SetDataToProerties(settings.LeftSideFontSetting2.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLeftLineValue3 = SetDataToProerties(settings.LeftSideFontSetting3.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLeftLineValue4 = SetDataToProerties(settings.LeftSideFontSetting4.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLeftLineValue5 = SetDataToProerties(settings.LeftSideFontSetting5.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLeftLineValue6 = SetDataToProerties(settings.LeftSideFontSetting6.DataSource ?? string.Empty, barcodeInfo, tubeInfo);
                    settings.TextLineValue5 = SetDataToProerties(settings.FifthFontSetting.DataSource ?? string.Empty, barcodeInfo, tubeInfo);

                    var singlePage = GenerateBitmapBarCode(settings, tubeInfo.Barcode, settings.TextTopLine1Value, settings.TextTopLine2Value
                        , settings.TextLineValue5
                        , settings.TextRightLineValue1, settings.TextRightLineValue2, settings.TextRightLineValue3, settings.TextRightLineValue4
                        , settings.TextRightLineValue5, settings.TextRightLineValue6, settings.TextLeftLineValue1, settings.TextLeftLineValue2
                        , settings.TextLeftLineValue3, settings.TextLeftLineValue4, settings.TextLeftLineValue5, settings.TextLeftLineValue6
                        , false, settings.TextBottomLine1Value);

                    List<Bitmap> bitmapPages = new List<Bitmap>();
                    bitmapPages.Add(singlePage);

                    for (int p = 1; p < settings.StampsPerPage; p++)
                    {
                        var extraPage = GenerateBitmapBarCode(settings, settings.BarcodeText, settings.TextTopLine1Value, settings.TextTopLine2Value
                            , settings.TextLineValue5
                        , settings.TextRightLineValue1, settings.TextRightLineValue2, settings.TextRightLineValue3, settings.TextRightLineValue4
                        , settings.TextRightLineValue5, settings.TextRightLineValue6, settings.TextLeftLineValue1, settings.TextLeftLineValue2
                        , settings.TextLeftLineValue3, settings.TextLeftLineValue4, settings.TextLeftLineValue5, settings.TextLeftLineValue6
                        , false, settings.TextBottomLine1Value);

                        bitmapPages.Add(extraPage);
                    }

                    for (int copy = 0; copy < barcodeInfo.DanhSachTube[i].TubeCount; copy++)
                    {
                        printService.SetPages(bitmapPages);
                        printService.Print();
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string SetDataToProerties(string dataKey, BarcodeProperties barcodeInfo, BarcodeTubeDetail tubeInfo)
        {
           var data = dataKey.Replace(BarcodeKeyContansts.NgayNhap, barcodeInfo.NgayTiepNhan.ToString("dd/MM/yyyy"))
                .Replace(BarcodeKeyContansts.MaTiepNhan, barcodeInfo.Sid)
                .Replace(BarcodeKeyContansts.TenBN, barcodeInfo.PatientName)
                .Replace(BarcodeKeyContansts.MaBN, barcodeInfo.PatientID)
                .Replace(BarcodeKeyContansts.MaKhoaPhong, barcodeInfo.MaKhoaPhong)
                .Replace(BarcodeKeyContansts.GioiTinh, barcodeInfo.GioiTinh)
                .Replace(BarcodeKeyContansts.NamSinh, barcodeInfo.NamSinh)
                .Replace(BarcodeKeyContansts.SoTT, barcodeInfo.SoTT)
                .Replace(BarcodeKeyContansts.SoGiuong, barcodeInfo.SoGiuong)
                .Replace(BarcodeKeyContansts.SoBHYT, barcodeInfo.SoBHYT)
                .Replace(BarcodeKeyContansts.MaBSChiDinh, barcodeInfo.MaBSChiDinh)
                .Replace(BarcodeKeyContansts.MaDoiTuongDichVu, barcodeInfo.MaDoiTuongDichVu)
                .Replace(BarcodeKeyContansts.NgaySinh, barcodeInfo.NgaySinh_DateTime == null ? barcodeInfo.NgaySinh : barcodeInfo.NgaySinh_DateTime.Value.ToString("dd/MM/yyy"))
                .Replace(BarcodeKeyContansts.SoPhieuChiDinh, barcodeInfo.SoPhieuChiDinh)
                .Replace(BarcodeKeyContansts.SoHoSo, barcodeInfo.SoHoSo)
                .Replace(BarcodeKeyContansts.TenGioiTinh, barcodeInfo.GioiTinh == "F" ? "Nữ" : (barcodeInfo.GioiTinh == "M" ? "Nam" : ""))
                .Replace(BarcodeKeyContansts.SoBarcode, tubeInfo.Barcode)
                .Replace(BarcodeKeyContansts.TenBarcode, tubeInfo.BarcodeName)
                .Replace(BarcodeKeyContansts.NgayLayMau, tubeInfo.NgayLayMau == null ? string.Empty : tubeInfo.NgayLayMau.Value.ToString("dd/MM/yyy"))
                .Replace(BarcodeKeyContansts.GioLayMau, tubeInfo.NgayLayMau == null ? string.Empty : tubeInfo.NgayLayMau.Value.ToString("HH:mm"))
                .Replace(BarcodeKeyContansts.MaOngMau, tubeInfo.Tubecode)
                .Replace(BarcodeKeyContansts.TenOngMau, tubeInfo.Tubename)
                .Replace(BarcodeKeyContansts.MaNhomOngMau, tubeInfo.TubeCate)
                .Replace(BarcodeKeyContansts.TenNhomOngMau, tubeInfo.TubeCateName)
                .Replace(BarcodeKeyContansts.NguoiLayMau, tubeInfo.NguoiLayMau)
                .Replace(BarcodeKeyContansts.NhomXetNghiem, tubeInfo.NhomXetNghiem)
                .Replace(BarcodeKeyContansts.BoPhanXetNghiem, tubeInfo.BoPhanXetNghiem);
            if(data.Contains("(") && dataKey.Contains(")"))
            {
                data = data.Replace("()", "").Replace("( )", "").Replace("(  )", "");
            }

            if (data.Contains("[") && dataKey.Contains("]"))
            {
                data = data.Replace("[]", "").Replace("[ ]", "").Replace("[  ]", "");
            }
            return data;
        }
        public void SaveSettings(BarcodePageSetting settings, string fileName)
        {
            using (FileStream fileStream = File.Create(fileName))
            {
                string data = BarcodePageSetting.Serialize(settings);
                byte[] rawData = UTF8Encoding.UTF8.GetBytes(data);
                fileStream.Write(rawData, 0, rawData.Length);
            }
        }
        public BarcodePageSetting LoadSettings(string fileName)
        {
            BarcodePageSetting result = null;
            if (File.Exists(fileName))
            {
                using (TextReader readFileStream = new StreamReader(fileName))
                {
                    string data = readFileStream.ReadToEnd();
                    result = BarcodePageSetting.Deserialize(data);
                }
            }

            return result;
        }
        public BarcodePageSetting LoadSettingsDefaultFileConfig()
        {
            BarcodePageSetting result = null;
            var settingFile = File.Exists(DefaultSettingsFileName) ? DefaultSettingsFileName : (File.Exists(DefaultSettingsFileNameOld) ? DefaultSettingsFileNameOld : string.Empty);
            if (!string.IsNullOrEmpty(settingFile))
            {
                using (TextReader readFileStream = new StreamReader(settingFile))
                {
                    string data = readFileStream.ReadToEnd();
                    result = BarcodePageSetting.Deserialize(data);
                }
            }
            return result;
        }
        private double CalculateStampSize(double pageWidth, int numberOfStampPerPage)
        {
            double result = (pageWidth / numberOfStampPerPage);
            return result;
        }

        private double CalculateStampLeft(double pageWidth, int stampIndex, int numberOfStampPerPage)
        {
            double result = CalculateStampSize(pageWidth, numberOfStampPerPage) * stampIndex;
            return result;
        }

        private FontStyle GetFontStyle(FontSetting settings)
        {
            FontStyle style = FontStyle.Regular;
            if (settings != null)
            {
                style = style | (settings.IsBold ? FontStyle.Bold : FontStyle.Regular);
                style = style | (settings.IsItalic ? FontStyle.Italic : FontStyle.Regular);
            }

            return style;
        }

        private Font GetFont(FontSetting settings, float generalFontSize,string fontName)
        {
            Font font = new Font(fontName,
                (settings != null ? (float)settings.FontSize : generalFontSize),
                GetFontStyle(settings),
                GraphicsUnit.World);

            return font;
        }

        private double ConvertFromMmToPixelDot(double valueMm, double dpi)
        {
            return (valueMm * dpi) / 25.4;
        }

        public Bitmap GenerateBitmapBarCode(BarcodePageSetting settings,
            string barcode, string firstLineBarLabel, string secondLineBarLabel, string FifthLineValue
            , string RightSideLabel1
            , string RightSideLabel2 = ""
            , string RightSideLabel3 = ""
            , string RightSideLabel4 = ""
            , string RightSideLabel5 = ""
            , string RightSideLabel6 = ""
            , string LeftSideLabel1 = ""
            , string LeftSideLabel2 = ""
            , string LeftSideLabel3 = ""
            , string LeftSideLabel4 = ""
            , string LeftSideLabel5 = ""
            , string LeftSideLabel6 = ""
            , bool showRectMargin = false
            , string description = null
            )
        {
            double dpi = Convert.ToInt32(settings.DPI);

            //do rong mm cho tung chu khoang tu 2.75 - 3
            double barcodeCharRatio = Convert.ToDouble(settings.MMPerChar); //number of char per mm

            double barcodePageW = ConvertFromMmToPixelDot(settings.PaperSizeW, dpi);
            double barcodePageH = ConvertFromMmToPixelDot(settings.PaperSizeH, dpi);

            double marginLeft = ConvertFromMmToPixelDot(settings.MarginLeft, dpi);
            double marginRight = ConvertFromMmToPixelDot(settings.MarginRight, dpi);
            double marginTop = ConvertFromMmToPixelDot(settings.MarginTop, dpi);
            double marginBottom = ConvertFromMmToPixelDot(settings.MarginBottom, dpi);
            double leftSideWidth = ConvertFromMmToPixelDot(settings.LeftWidth, dpi);
            double rightSideWidth = ConvertFromMmToPixelDot(settings.RightWidth, dpi);

            //float fontSize = (float)settings.FontSize;
            //Font fontUse = new Font("Verdana", fontSize, FontStyle.Regular, GraphicsUnit.World);
            Font fontFirstLine = GetFont(settings.FirstLineFontSetting, (float)settings.FontSize, settings.FontName);
            Font fontSecondLine = GetFont(settings.SecondLineFontSetting, (float)settings.FontSize, settings.FontName);
            Font fontFifthLine = GetFont(settings.FifthFontSetting, (float)settings.FontSize, settings.FontName);
            Font fontDescriptionLine = GetFont(settings.DescriptionFontSetting, (float)settings.FontSize, settings.FontName);
            Font fontSideText = GetFont(settings.RightSideFontSetting1, (float)settings.FontSize, settings.FontName);

            //StringFormat stringFormatGeneral = new StringFormat();
            //stringFormatGeneral.Alignment = settings.HorizontalAlign;

            int numberOfStampPerPage = settings.StampsPerPage;

            var b = new BarcodeLib.Barcode();
            b.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            //            b.IncludeLabel = true;
            b.LabelPosition = LabelPositions.BOTTOMLEFT;
            b.Alignment = AlignmentPositions.LEFT;

            TYPE type = settings.BarcodeType; //BarcodeLib.TYPE.CODE128;

            Bitmap bmpOut = new Bitmap((int)barcodePageW, (int)barcodePageH);
            bmpOut.SetResolution((int)dpi, (int)dpi);

            using (Graphics canvas = Graphics.FromImage(bmpOut))
            {
                Pen previewRectPen = new Pen(Color.DarkRed, 1);
                previewRectPen.DashStyle = DashStyle.Dash;

                canvas.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)barcodePageW, (int)barcodePageH);

                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.SmoothingMode = SmoothingMode.AntiAlias;
                canvas.TextRenderingHint = TextRenderingHint.AntiAlias;

                SizeF stringSize = new SizeF();

                string strDraw = string.Empty;

                for (int stampIndex = 0; stampIndex < numberOfStampPerPage; stampIndex++)
                {
                    double offsetTop = marginTop;
                    double offsetLeft = CalculateStampLeft(barcodePageW, stampIndex, numberOfStampPerPage);
                    double stampSize = CalculateStampSize(barcodePageW, numberOfStampPerPage);

                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(
                            previewRectPen,
                            new Rectangle(
                                new Point((int)offsetLeft, 0),
                                new Size((int)stampSize, (int)(barcodePageH))));
                    }

                    var barcodeText = barcode.Trim();


                    double leftIndent1st = 0;
                    double leftIndent2nd = 0;
                    double leftIndent5th = 0;
                    double leftIndentDesc = 0;
                    double rightIndent1st = 0;
                    double rightIndent2nd = 0;
                    double rightIndent5th = 0;
                    double rightIndentDesc = 0;
                    if (settings.FirstLineFontSetting != null)
                    {
                        if (!settings.FirstLineFontSetting.HideLabel)
                        {
                            leftIndent1st += ConvertFromMmToPixelDot(settings.FirstLineFontSetting.LeftIndent, dpi);
                            rightIndent1st += ConvertFromMmToPixelDot(settings.FirstLineFontSetting.RightIndent, dpi);
                        }
                    }

                    if (settings.SecondLineFontSetting != null)
                    {
                        if (!settings.SecondLineFontSetting.HideLabel)
                        {
                            leftIndent2nd += ConvertFromMmToPixelDot(settings.SecondLineFontSetting.LeftIndent, dpi);
                            rightIndent2nd += ConvertFromMmToPixelDot(settings.SecondLineFontSetting.RightIndent, dpi);
                        }
                    }

                    if (settings.DescriptionFontSetting != null)
                    {
                        if (!settings.DescriptionFontSetting.HideLabel)
                        {
                            leftIndentDesc += ConvertFromMmToPixelDot(settings.DescriptionFontSetting.LeftIndent, dpi);
                            rightIndentDesc += ConvertFromMmToPixelDot(settings.DescriptionFontSetting.RightIndent, dpi);
                        }
                    }
                    if (settings.FifthFontSetting != null)
                    {
                        if (!settings.FifthFontSetting.HideLabel)
                        {
                            leftIndent5th += ConvertFromMmToPixelDot(settings.FifthFontSetting.LeftIndent, dpi);
                            rightIndent5th += ConvertFromMmToPixelDot(settings.FifthFontSetting.RightIndent, dpi);
                        }
                    }
                    //Vẽ dòng 1
                    bool alreadyAddTopOfset = false;
                    int lastoffsetTopHeight = 0;
                    var drawStartPoint = new Point();
                    var drawSize = new Size();
                    int ofsetTopDrawing = (int)offsetTop;
                    double ofsetTopDrawingRowForBarcode = offsetTop;
                    var lastLeftEndPoint = new Point(0, (int)offsetTop);
                    if (settings.LeftSideFontSetting1 != null)
                    {
                        if (!settings.LeftSideFontSetting1.HideLabel)
                        {
                            strDraw = LeftSideLabel1;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.LeftSideFontSetting1, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.LeftSideFontSetting1;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            lastLeftEndPoint = new Point(drawStartPoint.X + drawSize.Width, drawStartPoint.Y);
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                        }
                    }

                    if (settings.RightSideFontSetting1 != null)
                    {
                        if (!settings.RightSideFontSetting1.HideLabel)
                        {
                            strDraw = RightSideLabel1;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.RightSideFontSetting1, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.RightSideFontSetting1;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + (stampSize - marginRight - ConvertFromMmToPixelDot(fontSetting.Width - leftPadding, dpi))), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                        }
                    }

                    if (settings.FirstLineFontSetting != null)
                    {
                        if (!settings.FirstLineFontSetting.HideLabel)
                        {
                            strDraw = string.IsNullOrEmpty(firstLineBarLabel) ? " " : firstLineBarLabel;
                            stringSize = canvas.MeasureString(strDraw, fontFirstLine);
                            var fontSetting = settings.FirstLineFontSetting;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = lastLeftEndPoint; // new Point((int)((stampSize / 2) - (ConvertFromMmToPixelDot(fontSetting.Width, dpi) / 2) + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            ofsetTopDrawingRowForBarcode += lastoffsetTopHeight;
                        }
                    }

                    //Vẽ dòng 2
                      lastLeftEndPoint = new Point(0, (int)offsetTop);
                    alreadyAddTopOfset = false;
                    ofsetTopDrawing = (int)offsetTop;
                    if (settings.LeftSideFontSetting2 != null)
                    {
                        if (!settings.LeftSideFontSetting2.HideLabel)
                        {
                            strDraw = LeftSideLabel2;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.LeftSideFontSetting2, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.LeftSideFontSetting2;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            lastLeftEndPoint = new Point(drawStartPoint.X + drawSize.Width, drawStartPoint.Y);
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                        }
                    }

                    if (settings.RightSideFontSetting2 != null)
                    {
                        if (!settings.RightSideFontSetting2.HideLabel)
                        {
                            strDraw = RightSideLabel2;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.RightSideFontSetting2, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.RightSideFontSetting2;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + (stampSize - marginRight - ConvertFromMmToPixelDot(fontSetting.Width - leftPadding, dpi))), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                        }
                    }

                    if (settings.SecondLineFontSetting != null)
                    {
                        if (!settings.SecondLineFontSetting.HideLabel)
                        {
                            strDraw = string.IsNullOrEmpty(secondLineBarLabel) ? " " : secondLineBarLabel;
                            var fontSetting = settings.SecondLineFontSetting;
                            stringSize = canvas.MeasureString(strDraw, fontSecondLine);
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = lastLeftEndPoint; // new Point((int)((stampSize / 2) - (ConvertFromMmToPixelDot(fontSetting.Width, dpi) / 2) + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            ofsetTopDrawingRowForBarcode += lastoffsetTopHeight;
                        }
                    }

                    #region  Vẽ chuỗi 2 cạnh hình barcode
                    int maxWidthLeft = 0;
                    int maxWidthRight = 0;
                    double maxpaddingLeft = 0;
                    double maxpaddingRight = 0;
                    //dòng 3
                    alreadyAddTopOfset = false;

                    ofsetTopDrawing = (int)offsetTop;
                    if (settings.LeftSideFontSetting3 != null)
                    {
                        if (!settings.LeftSideFontSetting3.HideLabel)
                        {
                            strDraw = LeftSideLabel3;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.LeftSideFontSetting3, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.LeftSideFontSetting3;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthLeft < fontSetting.Width)
                                maxWidthLeft = fontSetting.Width;

                            if (maxpaddingLeft < leftPadding)
                                maxpaddingLeft = leftPadding;
                        }
                    }

                    if (settings.RightSideFontSetting3 != null)
                    {
                        if (!settings.RightSideFontSetting3.HideLabel)
                        {
                            strDraw = RightSideLabel3;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.RightSideFontSetting3, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.RightSideFontSetting3;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            var rightPadding = ConvertFromMmToPixelDot(fontSetting.RightIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + (stampSize - marginRight - ConvertFromMmToPixelDot(fontSetting.Width - leftPadding, dpi))), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthRight < fontSetting.Width)
                                maxWidthRight = fontSetting.Width;
                            if (maxpaddingRight < rightPadding)
                                maxpaddingRight = rightPadding;
                        }
                    }
                    //dòng 4
                    alreadyAddTopOfset = false;
                    ofsetTopDrawing = (int)offsetTop;
                    if (settings.LeftSideFontSetting4 != null)
                    {
                        if (!settings.LeftSideFontSetting4.HideLabel)
                        {
                            strDraw = LeftSideLabel4;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.LeftSideFontSetting4, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.LeftSideFontSetting4;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthLeft < fontSetting.Width)
                                maxWidthLeft = fontSetting.Width;
                            if (maxpaddingLeft < leftPadding)
                                maxpaddingLeft = leftPadding;
                        }
                    }
                    if (settings.RightSideFontSetting4 != null)
                    {
                        if (!settings.RightSideFontSetting4.HideLabel)
                        {
                            strDraw = RightSideLabel4;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.RightSideFontSetting4, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.RightSideFontSetting4;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            var rightPadding = ConvertFromMmToPixelDot(fontSetting.RightIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + (stampSize - marginRight - ConvertFromMmToPixelDot(fontSetting.Width - leftPadding, dpi))), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthRight < fontSetting.Width)
                                maxWidthRight = fontSetting.Width;
                            if (maxpaddingRight < rightPadding)
                                maxpaddingRight = rightPadding;
                        }
                    }
                    //dòng 5
                    double ofsetTopDrawingRowForBottom = offsetTop;
                    lastLeftEndPoint = new Point(0, (int)offsetTop);
                    alreadyAddTopOfset = false;
                    ofsetTopDrawing = (int)offsetTop;
                    if (settings.LeftSideFontSetting5 != null)
                    {
                        if (!settings.LeftSideFontSetting5.HideLabel)
                        {
                            strDraw = LeftSideLabel5;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.LeftSideFontSetting5, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.LeftSideFontSetting5;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            lastLeftEndPoint = new Point(drawStartPoint.X + drawSize.Width, drawStartPoint.Y);
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthLeft < fontSetting.Width)
                                maxWidthLeft = fontSetting.Width;
                            if (maxpaddingLeft < leftPadding)
                                maxpaddingLeft = leftPadding;
                        }
                    }

                    if (settings.RightSideFontSetting5 != null)
                    {
                        if (!settings.RightSideFontSetting5.HideLabel)
                        {
                            strDraw = RightSideLabel5;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.RightSideFontSetting5, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.RightSideFontSetting5;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            var rightPadding = ConvertFromMmToPixelDot(fontSetting.RightIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + (stampSize - marginRight - ConvertFromMmToPixelDot(fontSetting.Width - leftPadding, dpi))), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthRight < fontSetting.Width)
                                maxWidthRight = fontSetting.Width;
                            if (maxpaddingRight < rightPadding)
                                maxpaddingRight = rightPadding;
                        }
                    }
                    if (settings.FifthFontSetting != null)
                    {
                        if (!settings.FifthFontSetting.HideLabel)
                        {
                            strDraw = FifthLineValue;
                            var fontSetting = settings.FifthFontSetting;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.FifthFontSetting, (float)settings.FontSize, settings.FontName));
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = lastLeftEndPoint; //new Point((int)((stampSize / 2) - (ConvertFromMmToPixelDot(fontSetting.Width, dpi) / 2) + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            var multi = CalculateMultiplyHeight(stringSize, drawSize);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height: drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && ((drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (drawSize.Height == 0 ? (int)stringSize.Height : drawSize.Height) * multi;
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            ofsetTopDrawingRowForBottom += lastoffsetTopHeight;
                            alreadyAddTopOfset = true;
                        }
                    }
                    //dòng 6
                      lastLeftEndPoint = new Point(0, (int)offsetTop);
                    alreadyAddTopOfset = false;
                    ofsetTopDrawing = (int)offsetTop;
                    if (settings.LeftSideFontSetting6 != null)
                    {
                        if (!settings.LeftSideFontSetting5.HideLabel)
                        {
                            strDraw = LeftSideLabel6;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.LeftSideFontSetting6, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.LeftSideFontSetting6;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            lastLeftEndPoint = new Point(drawStartPoint.X + drawSize.Width, drawStartPoint.Y);
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi);
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi);
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthLeft < fontSetting.Width)
                                maxWidthLeft = fontSetting.Width;
                            if (maxpaddingLeft < leftPadding)
                                maxpaddingLeft = leftPadding;
                        }
                    }

                    if (settings.RightSideFontSetting6 != null)
                    {
                        if (!settings.RightSideFontSetting5.HideLabel)
                        {
                            strDraw = RightSideLabel6;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.RightSideFontSetting5, (float)settings.FontSize, settings.FontName));
                            var fontSetting = settings.RightSideFontSetting6;
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            var rightPadding = ConvertFromMmToPixelDot(fontSetting.RightIndent, dpi);
                            drawStartPoint = new Point((int)(offsetLeft + (stampSize - marginRight - ConvertFromMmToPixelDot(fontSetting.Width - leftPadding, dpi))), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi);
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi);
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            if (maxWidthRight < fontSetting.Width)
                                maxWidthRight = fontSetting.Width;
                            if (maxpaddingRight < rightPadding)
                                maxpaddingRight = rightPadding;
                        }
                    }
                    if (settings.DescriptionFontSetting != null)
                    {
                        if (!settings.DescriptionFontSetting.HideLabel)
                        {
                            strDraw = string.IsNullOrEmpty(description) ? barcodeText : description;
                            var fontSetting = settings.DescriptionFontSetting;
                            stringSize = canvas.MeasureString(strDraw, GetFont(settings.DescriptionFontSetting, (float)settings.FontSize, settings.FontName));
                            var leftPadding = ConvertFromMmToPixelDot(fontSetting.LeftIndent, dpi);
                            drawStartPoint = new Point(lastLeftEndPoint.X, (int)ofsetTopDrawingRowForBottom); //new Point((int)((stampSize / 2) - (ConvertFromMmToPixelDot(fontSetting.Width, dpi) / 2) + marginLeft + leftPadding), ofsetTopDrawing);
                            drawSize = new Size((int)ConvertFromMmToPixelDot(fontSetting.Width, dpi), (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi));
                            DrawValue(fontSetting, settings.HorizontalAlign, canvas, strDraw, drawStartPoint, drawSize, showRectMargin, previewRectPen, leftPadding, settings.FontName);
                            if (!alreadyAddTopOfset && fontSetting.MergeRow == 0)
                            {
                                lastoffsetTopHeight = (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi);
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            else if (alreadyAddTopOfset && (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi) > lastoffsetTopHeight)
                            {
                                offsetTop -= lastoffsetTopHeight;
                                lastoffsetTopHeight = (int)ConvertFromMmToPixelDot(fontSetting.Height, dpi);
                                offsetTop += lastoffsetTopHeight;
                                alreadyAddTopOfset = true;
                            }
                            alreadyAddTopOfset = true;
                        }
                    }
                    #endregion

                    //Vẽ barcode

                    double barcodeW = ConvertFromMmToPixelDot((double)barcodeText.Length * barcodeCharRatio, dpi);
                    double barcodeH = ConvertFromMmToPixelDot(settings.BarCodeHeight, dpi);

                    var imageBarCodeRaw = b.Encode(type,
                        barcodeText,
                        b.ForeColor, b.BackColor, (int)barcodeW, (int)barcodeH);
                    offsetTop = ofsetTopDrawingRowForBarcode;
                    Bitmap bitmapBarCode = new Bitmap(imageBarCodeRaw);
                    bitmapBarCode.SetResolution((int)dpi, (int)dpi);
                    Rectangle barcodePaneRect = new Rectangle();
                    Point startPoint = new Point(0, 0);

                    maxWidthLeft = (int)ConvertFromMmToPixelDot(maxWidthLeft, dpi);
                    maxWidthRight = (int)ConvertFromMmToPixelDot(maxWidthRight, dpi);
                    //  maxWidthLeft = (int)ConvertFromMmToPixelDot(maxWidthLeft, dpi);

                    drawStartPoint = new Point((int)(maxWidthLeft + marginLeft + maxpaddingLeft), (int)ofsetTopDrawingRowForBarcode);
                    drawSize = new Size((int)(stampSize - (maxWidthLeft + marginLeft + maxpaddingLeft) - (maxWidthRight + marginRight + maxpaddingRight)), bitmapBarCode.Height);
                    barcodePaneRect = new Rectangle(drawStartPoint, drawSize);

                    switch (settings.BarcodeAlign)
                    {
                        case StringAlignment.Near:
                            canvas.DrawImage(bitmapBarCode,new PointF((float)(offsetLeft + maxWidthLeft + marginLeft + maxpaddingLeft),(float)ofsetTopDrawingRowForBarcode));
                            break;

                        case StringAlignment.Center:
                            canvas.DrawImage(bitmapBarCode, new PointF((float)((stampSize / 2) - (bitmapBarCode.Width / 2) + offsetLeft + marginLeft), (float)ofsetTopDrawingRowForBarcode));
                            break;
                        case StringAlignment.Far:

                            canvas.DrawImage(bitmapBarCode,
                                new PointF((float)(offsetLeft + stampSize - maxWidthRight - maxpaddingRight - bitmapBarCode.Width), (float)ofsetTopDrawingRowForBarcode));
                            break;
                    }
                    // for debug only
                    if (showRectMargin)
                    {
                        canvas.DrawRectangle(previewRectPen, barcodePaneRect);
                    }
                }

                canvas.Save();
            }

            return bmpOut;
        }
        private int CalculateMultiplyHeight(SizeF sizeString, Size sizedraw)
        {
            if (sizeString.Width > sizedraw.Width)
            {
                var heightMulti = (sizeString.Width / sizedraw.Width).ToString().Split('.')[0].Split(',')[0];
                return int.Parse(heightMulti) + 1;
            }
            else
                return 1;
        }
        private void DrawValue(FontSetting fontSetting, StringAlignment deFaultAlign
            , Graphics canvas, string strDraw, Point drawPoint, Size drawSize
           ,  bool showLine, Pen previewPen, double leftIndent, string fontName)
        {
            var recDraw = new Rectangle(
                        drawPoint,
                        drawSize);

            Font font = GetFont(fontSetting, (float)fontSetting.FontSize, fontName);
            var stringSize = canvas.MeasureString(strDraw, font);
            GraphicsState state = canvas.Save();
            if (fontSetting.TextRotate == 90 || fontSetting.TextRotate == -90)
            {
                var drawRotatePoint = new PointF();
                canvas.ResetTransform();
              
                var fSetting = fontSetting != null ?
                                          new StringFormat() { Alignment = fontSetting.Align } :
                                          new StringFormat() { Alignment = deFaultAlign };
                stringSize = canvas.MeasureString(strDraw, font);
                float xBorder = 0;
                if (fSetting.Alignment == StringAlignment.Near)
                {
                    drawRotatePoint = new PointF(drawPoint.X  + (fontSetting.TextRotate == 90 ? (stringSize.Height) : 0)
                        , (drawPoint.Y + (fontSetting.TextRotate == -90 ? stringSize.Width : 0)));
                    xBorder = drawPoint.X;

                }
                else if (fSetting.Alignment == StringAlignment.Center)
                {
                    drawRotatePoint = new PointF((drawPoint.X + drawSize.Width) / 2f + ((stringSize.Height / 2) * (Math.Abs(fontSetting.TextRotate) / fontSetting.TextRotate))
                        , (drawPoint.Y + (fontSetting.TextRotate == -90 ? stringSize.Width : 0)));
                    xBorder = (drawPoint.X + drawSize.Width) / 2f - stringSize.Height / 2;
                }
                else
                {
                    //far
                    drawRotatePoint = new PointF(drawPoint.X + drawSize.Width - (fontSetting.TextRotate == -90 ? (stringSize.Height) : 0)
                        , (drawPoint.Y + (fontSetting.TextRotate == -90 ? stringSize.Width : 0)));
                    xBorder = drawPoint.X + drawSize.Width - stringSize.Height;
                }

                canvas.TranslateTransform(drawRotatePoint.X, drawRotatePoint.Y);
                canvas.RotateTransform((float)fontSetting.TextRotate);
                // Draw the text at the origin.
                canvas.DrawString(strDraw, font, new SolidBrush(Color.Black), 0, 0);
              
                // Restore the graphics state.
                canvas.Restore(state);
                if (fontSetting.Border)
                {
                    //draw first line
                    canvas.DrawRectangle(
                        new Pen(Color.Black, 2)
                       , (xBorder > 0 ? xBorder - 1 : xBorder), (fontSetting.TextRotate == -90 ? drawRotatePoint.Y - stringSize.Width : drawRotatePoint.Y) - 1
                       , stringSize.Height + 1, stringSize.Width + 1);
                }
            }
            else
            {
                var realDrawPoint = new Point(drawPoint.X, (stringSize.Height < drawSize.Height? drawPoint.Y + ((drawSize.Height - (int)stringSize.Height) / 2) : drawPoint.Y));

                canvas.DrawString(strDraw, font,
                                  new SolidBrush(Color.Black),
                                new Rectangle(realDrawPoint, drawSize),
                                      (fontSetting != null ?
                                          new StringFormat() { Alignment = fontSetting.Align } :
                                          new StringFormat() { Alignment = deFaultAlign }));
                if (fontSetting.Border)
                {
                    //draw first line
                    canvas.DrawRectangle(
                        new Pen(Color.Black, 2)
                       , realDrawPoint.X, realDrawPoint.Y - 1
                       , (stringSize.Width < drawSize.Width ? drawSize.Width: stringSize.Width) + 1, stringSize.Height + 1);
                }
            }

            
            if (showLine)
            {
                //draw first line
                canvas.DrawRectangle(
                    previewPen, recDraw);
            }
        }
    }
}
