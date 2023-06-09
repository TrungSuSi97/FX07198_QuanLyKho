using System;
using System.Windows.Forms;
using TPH.LIS.BarcodePrinting.Configurations;

namespace TPH.LIS.BarcodePrinting.Barcode
{
    public partial class frmPrintBarcode : Form
    {
        public frmPrintBarcode()
        {
            InitializeComponent();
        }
        BarTender.Application btApp;
        BarTender.Format btFormat;
        BarTender.Messages btMsgs;
        private string _pid;

        public string PID
        {
            get { return _pid; }
            set { _pid = value; }
        }
        private string _age;

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
	
        private string _barcode;

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }
        private string _pName = "";

        public string PName
        {
            get { return _pName; }
            set { _pName = value; }
        }
        private string _printerName;

        public string PrinterName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }
        private int _printCopy = 1;

        public int PrintCopy
        {
            get { return _printCopy; }
            set { _printCopy = value; }
        }
        private string _barcodeLable;

        public string BarcodeLable
        {
            get { return _barcodeLable; }
            set { _barcodeLable = value; }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _departmentID = string.Empty;
        public string DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
        private string _soTT = string.Empty;
        public string SoTT
        {
            get { return _soTT; }
            set { _soTT = value; }
        }
        private void frmPrintBarcode_Load(object sender, EventArgs e)
        {
            label1.Text = "Đang in barcode: " + _barcode;
            btApp = new BarTender.Application();

            string fileparth = System.IO.Path.GetFullPath(string.Format(@"Barcode\{0}", AppSettings.BarcodeName));
            btFormat = btApp.Formats.Open(fileparth, false, "");
            btFormat.SetNamedSubStringValue("Barcode", _barcode);
            btFormat.SetNamedSubStringValue("NameLable", _pName);
            btFormat.SetNamedSubStringValue("BarcodeLable", _barcodeLable);
            btFormat.SetNamedSubStringValue("Date", _date);
            btFormat.SetNamedSubStringValue("Age", _age);
            btFormat.SetNamedSubStringValue("DepartmentID", _departmentID);
            btFormat.SetNamedSubStringValue("SoTT", SoTT);
            //btFormat.PrintSetup.
            btFormat.PrintSetup.IdenticalCopiesOfLabel = _printCopy;
            btFormat.PrintOut(true, false);

            //btFormat.Print("Barcode", true, -1, out btMsgs);
            
            //btFormat.PrintPreview.Show();
            btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
            
            this.Close();
        }

        private void frmPrintBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp);
        }
    }
}