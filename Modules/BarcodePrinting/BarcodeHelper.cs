using TPH.LIS.BarcodePrinting.Barcode;
using System.Drawing;

namespace TPH.LIS.BarcodePrinting
{
    public class BarcodeHelper
    {
        public static byte[] TextToBarcode(string Barcode)
        {
            var ic = new ImageConverter();
            var imgBarcode =
                (byte[])
                    ic.ConvertTo(
                        Code128Rendering.MakeBarcodeImage(
                            Barcode, 1, true), typeof(byte[]));
            return imgBarcode;
        }
    }
}
