using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TPH.LIS.BarcodePrinting
{
    public class BarcodePageSetting
    {
        public string FontName { get; set; } = "Arial";
        public double PaperSizeW { get; set; }
        public double PaperSizeH { get; set; }
        public double DPI { get; set; }
        public int StampsPerPage { get; set; }

        public double MarginLeft { get; set; }
        public double MarginRight { get; set; }
        public double MarginTop { get; set; }
        public double MarginBottom { get; set; }

        public double MMPerChar { get; set; }

        public double FontSize { get; set; }

        public double BarCodeHeight { get; set; }
        public double RightWidth { get; set; }
        public double LeftWidth { get; set; }
        public StringAlignment HorizontalAlign { get; set; }

        public FontSetting FirstLineFontSetting { get; set; }
        public FontSetting SecondLineFontSetting { get; set; }
        public FontSetting FifthFontSetting { get; set; }
        public FontSetting DescriptionFontSetting { get; set; }
        public FontSetting RightSideFontSetting1 { get; set; }
        public FontSetting RightSideFontSetting2 { get; set; }
        public FontSetting RightSideFontSetting3 { get; set; }
        public FontSetting RightSideFontSetting4 { get; set; }
        public FontSetting RightSideFontSetting5 { get; set; }
        public FontSetting RightSideFontSetting6 { get; set; }
        public FontSetting LeftSideFontSetting1 { get; set; }
        public FontSetting LeftSideFontSetting2 { get; set; }
        public FontSetting LeftSideFontSetting3 { get; set; }
        public FontSetting LeftSideFontSetting4 { get; set; }
        public FontSetting LeftSideFontSetting5 { get; set; }
        public FontSetting LeftSideFontSetting6 { get; set; }
        public StringAlignment BarcodeAlign { get; set; }
        public string BarcodePrinterName { get; set; }
        public string TextTopLine1Value { get; set; }
        public string TextTopLine2Value { get; set; }
        public string TextBottomLine1Value { get; set; }

        public string TextRightLineValue1 { get; set; }
        public string TextRightLineValue2 { get; set; }
        public string TextRightLineValue3 { get; set; }
        public string TextRightLineValue4 { get; set; }
        public string TextRightLineValue5 { get; set; }
        public string TextRightLineValue6 { get; set; }
        public string TextLeftLineValue1 { get; set; }
        public string TextLeftLineValue2 { get; set; }
        public string TextLeftLineValue3 { get; set; }
        public string TextLeftLineValue4 { get; set; }
        public string TextLineValue5 { get; set; }
        public string TextLeftLineValue5 { get; set; }
        public string TextLeftLineValue6 { get; set; }
        public string BarcodeText { get; set; }
        public BarcodeLib.TYPE BarcodeType { get; set; }
        public static string Serialize(BarcodePageSetting info)
        {
            string result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(BarcodePageSetting));
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = UTF8Encoding.UTF8;
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter xmlTextWriter = XmlWriter.Create(memoryStream, settings))
                {
                    serializer.Serialize(xmlTextWriter, info);
                }

                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return result;
        }

        public static BarcodePageSetting Deserialize(string value)
        {
            BarcodePageSetting result = null;

            XmlSerializer serializer = new XmlSerializer(typeof(BarcodePageSetting));
            using (MemoryStream readStream = new MemoryStream(UTF8Encoding.UTF8.GetBytes(value)))
            {
                XmlReader reader = new XmlTextReader(readStream);
                result = (BarcodePageSetting)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
