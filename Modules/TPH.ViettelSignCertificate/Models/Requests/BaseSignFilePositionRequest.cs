using TPH.ViettelSignCertificate.Constants;
using TPH.ViettelSignCertificate.Enums;

namespace TPH.ViettelSignCertificate.Models.Requests
{
    public class BaseSignFilePositionRequest
    {
        public int LocateSign { get; set; } = (int) LocationOfRectangle.LOCATE_SIGN_DEFAULT;
        public int NumberPageSign { get; set; } = 1;
        public int WidthRectangle { get; set; } = 200;
        public int HeightRectangle { get; set; } = 200;
        public int MarginTopOfRectangle { get; set; } = 10;
        public int MarginBottomOfRectangle { get; set; } = 10;
        public int MarginLeftOfRectangle { get; set; } = 10;
        public int MarginRightOfRectangle { get; set; } = 10;
        public string FormatRectangleText { get; set; } = FormatRectangleTextConstant.SIGN_TEXT_FORMAT_DEFAULT;
        public string Contact { get; set; }
        public string Reason { get; set; }
        public string Location { get; set; }
        public string OrganizationUnit { get; set; }
        public string Organization { get; set; }
        public string DisplayText { get; set; }
        public string SignDate { get; set; }
        public string DateFormat { get; set; } = SignDateFormatConstant.DATE_FORMAT_STRING_DEFAULT;
        public string FontPath { get; set; } = SignFontPathConstant.FONT_PATH_DEFAULT;
        public int FontSize { get; set; } = 11;
    }
}
