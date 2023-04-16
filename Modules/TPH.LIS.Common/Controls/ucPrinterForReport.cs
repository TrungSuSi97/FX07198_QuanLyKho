using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using static TPH.LIS.Common.RepportPaper;

namespace TPH.LIS.Common.Controls
{
    public partial class ucPrinterForReport : UserControl
    {

        public ucPrinterForReport()
        {
            InitializeComponent();
            ControlExtension.LoadPrinterName(cboPrinterName);
            Load_ConstantMauIn();
            Load_ConstantPaperSize();
            btnSave.Click += ButtonSaveClick;

        }
        private void Load_ConstantMauIn()
        {
            cboReportType.DataSource = ReportResultTemplateConstant.ReportResultTemplateConstantList.Where(x => !x.Key.Equals(ReportResultTemplateConstant.Mau_TC_ThongThuong) && !x.Key.Equals(ReportResultTemplateConstant.Mau_TC_ViSinh_TQ)).ToList();
            cboReportType.DisplayMember = "value";
            cboReportType.ValueMember = "Key";
            cboReportType.SelectedIndex = -1;
        }
        private void Load_ConstantPaperSize()
        {
            cboPaperSize.DataSource = RepportPaper.ListReportPaperSize().ToList();
            cboPaperSize.DisplayMember = "PaperName";
            cboPaperSize.ValueMember = "PaperID";
            cboPaperSize.SelectedIndex = -1;
        }
        [Category("Custom event")]
        public event EventHandler ButtonSaveClick;
        [Category("Custom event")]
        public event EventHandler ButtonDeleteClick;
        [Category("Custom Properties")]
        private string printerName = string.Empty;

        public string PrinterName
        {
            get
            {
                return printerName;
            }

            set
            {
                printerName = value;
                cboPrinterName.Text = printerName;
            }
        }

        [Category("Custom Properties")]
        private ReportPaperSize paperSize = ReportPaperSize.None;

        public ReportPaperSize PaperSize
        {
            get
            {
                return paperSize;
            }

            set
            {
                paperSize = value;
                cboPaperSize.SelectedValue = paperSize;
            }
        }

        [Category("Custom Properties")]
        private string reportTemplate = string.Empty;

        public string ReportTemplate
        {
            get
            {
                return reportTemplate;
            }

            set
            {
                reportTemplate = value;
                cboReportType.SelectedValue = reportTemplate;
            }
        }

        public bool isDelete = false;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Xóa cấu hình máy in ?"))
            {
                isDelete = true;
                ButtonDeleteClick(sender, e);
            }
        }

        private void cboPrinterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            printerName = cboPrinterName.Text;
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReportType.SelectedIndex > -1)
                reportTemplate = cboReportType.SelectedValue.ToString();
            else
                reportTemplate = string.Empty;
        }
        public int ControlCount
        {
            get { return int.Parse(lblCount.Text); }
            set { lblCount.Text = value.ToString(); }
        }
        private void cboPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaperSize.SelectedIndex > -1)
            {
                var obj = cboPaperSize.SelectedValue;
                if (obj is RepportPaper)
                    paperSize = ((RepportPaper)obj).PaperID;
                else
                    paperSize = (ReportPaperSize)obj;
            }
            else
                paperSize = ReportPaperSize.None;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
