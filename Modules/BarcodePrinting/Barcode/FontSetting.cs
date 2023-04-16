using System;
using System.Drawing;
using System.Text;

namespace TPH.LIS.BarcodePrinting
{
    public class FontSetting : ICloneable
    {
        public int FontSize { get; set; }
        public double LeftIndent { get; set; }
        public double RightIndent { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public StringAlignment Align { get; set; }
        public bool HideLabel { get; set; }
        public string SampleText { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int MergeRow { get; set; } = 0;
        public float TextRotate { get; set; } = 0;
        public string DataSource { get; set; }
        public bool Border { get; set; }
        public FontSetting()
        {
            this.FontSize = 10;
            this.Align = StringAlignment.Near;
        }

        public void CopyValue(FontSetting setting)
        {
            this.FontSize = setting.FontSize;
            this.LeftIndent = setting.LeftIndent;
            this.RightIndent = setting.RightIndent;
            this.IsBold = setting.IsBold;
            this.IsItalic = setting.IsItalic;
            this.Align = setting.Align;
            this.SampleText = setting.SampleText;
            this.HideLabel = setting.HideLabel;
            this.Width = setting.Width;
            this.Height = setting.Height;
            this.MergeRow = setting.MergeRow;
            this.TextRotate = setting.TextRotate;
            this.DataSource = setting.DataSource;
            this.Border = setting.Border;
        }

        public object Clone()
        {
            return new FontSetting()
            {
                FontSize = this.FontSize,
                LeftIndent = this.LeftIndent,
                RightIndent = this.RightIndent,
                IsBold = this.IsBold,
                IsItalic = this.IsItalic,
                Align = this.Align,
                SampleText = this.SampleText,
                HideLabel = this.HideLabel,
                Width = this.Width,
                Height = this.Height,
                MergeRow = this.MergeRow,
                TextRotate = this.TextRotate,
                DataSource = this.DataSource,
                Border = this.Border
        };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("FontSize: {0}|", FontSize);
            builder.AppendFormat("LeftIndent: {0}|", LeftIndent);
            builder.AppendFormat("RightIndent: {0}|", RightIndent);
            builder.AppendFormat("IsBold: {0}|", IsBold);
            builder.AppendFormat("IsItalic: {0}|", IsItalic);
            builder.AppendFormat("Align: {0}|", Align);
            builder.AppendFormat("SampleText: {0}|", SampleText);
            builder.AppendFormat("HideLabel:{0}|", HideLabel);
            builder.AppendFormat("Width: {0}|", Width);
            builder.AppendFormat("Height:{0}|", Height);
            builder.AppendFormat("MergeRow:{0}|", MergeRow);
            builder.AppendFormat("TextRotate:{0}|", TextRotate);
            builder.AppendFormat("DataSource:{0}|", DataSource);
            builder.AppendFormat("Border:{0}", Border);
            return builder.ToString();
        }
    }
}
