using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace TPH.LIS.BarcodePrinting
{
    public class PrintService
    {
        private int _pageIndex = 0;

        private List<Bitmap> _listPageImage = new List<Bitmap>();

        private PrintDocument _printDoc = new PrintDocument();

        private PrintPreviewDialog _previewDialog = new PrintPreviewDialog();
        private PrintController printController = new StandardPrintController();
        public PrintService(string printerName)
        {
            _printDoc.PrinterSettings.PrinterName = printerName;
            _printDoc.BeginPrint += printDoc_BeginPrint;
            _printDoc.EndPrint += printDoc_EndPrint;
            _printDoc.PrintPage += printDoc_PrintPage;
            _printDoc.PrintController = printController;
            _previewDialog.Document = _printDoc;
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_listPageImage[_pageIndex], new Point(0, 0));
            _pageIndex++;

            e.HasMorePages = (_pageIndex < _listPageImage.Count);
        }

        private void printDoc_EndPrint(object sender, PrintEventArgs e)
        {
            _pageIndex = 0;
        }

        private void printDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            _pageIndex = 0;
        }

        public void SetPages(List<Bitmap> listPageImage)
        {
            _listPageImage.Clear();
            _listPageImage.AddRange(listPageImage);
        }

        public void PrintPreview()
        {
            _previewDialog.ShowDialog();
        }

        public void Print()
        {
         
            _printDoc.Print();
        }
    }
}
