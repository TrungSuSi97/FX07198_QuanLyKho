using DevExpress.Utils.Extensions;
using DevExpress.Utils.Svg;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.Data.HIS.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.PrintedForm;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Services.TestMethod;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
//using TPH.ViettelSignCertificate.Models.Requests;
//using TPH.ViettelSignCertificate.Services.Impl;
//using TPH.ViettelSignCertificate.Services;
using static System.Net.WebRequestMethods;
using DevExpress.XtraPrinting.Drawing;

namespace TPH.LIS.App
{
    public partial class FrmPreViewReport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private readonly IPrintedFormService _printedFromService = new PrintedFormService();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly ITestMethodService _testMethodService = new TestMethodService();
        //private readonly IDigitalSignature _digSign = new DigitalSignatureService();
        //private readonly ISignCertificate _signCertificate = new SignCertificateImpl();
        private readonly IConnectHISService _iHISService = new ConnectHISService();
        //public THONGTINFILEKY _objSign = new THONGTINFILEKY();
        private HisConnection labIMSWebConfigInfo;

        public FrmPreViewReport()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }
        private string exportPdfPath = string.Empty;
        private string userSign = string.Empty;
        string _maTiepNhan = "";
        private bool printWithConvertUnit = false;
        public bool PrintWithConvertUnit
        {
            get
            {
                return printWithConvertUnit;
            }
            set
            {
                printWithConvertUnit = value;
            }
        }
        public bool InMau
        {
            get;
            set;
        }
        public string TieuDe6
        {
            get;
            set;
        }
        public string TieuDe5
        {
            get;
            set;
        }
        public string TieuDe4
        {
            get;
            set;
        }

        public string TieuDe3
        {
            get;
            set;
        }

        public string TieuDe2
        {
            get;
            set;
        }

        public string TieuDe1
        {
            get;
            set;
        }

        public string TenPhieuKq
        {
            get;
            set;
        }
        public string ChucVu
        {
            get;
            set;
        }

        public string NguoiKy
        {
            get;
            set;
        }
        public string ChungChiHanhNghe
        {
            get;
            set;
        }
        public string PhuTrachXetNghiem
        {
            get;
            set;
        }
        public string PrinterName
        {
            get;
            set;
        }

        public bool Email
        {
            get;
            set;
        }

        public bool Pdf
        {
            get;
            set;
        }

        public int ReportType
        {
            get;
            set;
        }
        public bool Print
        {
            get;
            set;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string PdfPath
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string MailTo
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }
        public bool EmailUseSsl { get; set; }
        public string MailFrom
        {
            get;
            set;
        }
        public string MailPortNumber { get; set; }
        public string SMTPServer { get; set; }

        public bool EndWithPrinted
        {
            get;
            set;
        }
        public string SampleID { get; set; }
        public string TenBN { get; set; }

        public string ExportPdfPath
        {
            get
            {
                return exportPdfPath;
            }

            set
            {
                exportPdfPath = value;
            }
        }

        public string UserSign
        {
            get
            {
                return userSign;
            }

            set
            {
                userSign = value;
            }
        }

        public int SoTTLayMau { get; set; }
        public bool InGiohen { get; set; }
        public bool ClsXetNghiemPhieuInBatThuongInDam { get; set; }
        public bool ClsXetNghiemPhieuInBatThuongInNghieng { get; set; }
        public bool ClsXetNghiemPhieuInBatThuongGachChan { get; set; }
        public bool ClsXetNghiemPhieuInTachTheoBoPhan { get; set; }
        public bool ClsXetNghiemPhieuInTachTheoNhom { get; set; }
        public bool ClsXetNghiemPhieuInTenNhomInDam { get; set; }
        public bool ClsXetNghiemPhieuInTenNhomInNghieng { get; set; }
        public bool ClsXetNghiemPhieuInTenNhomGachChan { get; set; }
        public int ClsXetNghiemPhieuInLeTenNhom { get; set; }
        public int ClsXetNghiemCanhLeBatThuongDuoi { get; set; }
        public int ClsXetNghiemCanhLeBatThuongTren { get; set; }
        public int ClsXetNghiemCanhLeBinhThuong { get; set; }
        public bool ClsXetNghiemPhieuInChuKyCuoiTrang { get; set; }
        public string idNgonNgu { get; internal set; }
        public string HisPatientId { get; internal set; }
        public string HisOrderID { get; internal set; }
        public string Seq { get; internal set; }
        public string MaTiepNhan { get; internal set; }
        public DateTime? TGIn { get; internal set; }
        public bool ViewPdfAfterPrint { get; internal set; }
        public bool DungChuKySo { get; internal set; }
        public KieuKySo LoaiKy { get; internal set; }
        public string IdChuKySo { get; internal set; }
        public string MoTa { get; internal set; }
        public bool DaUpload { get; internal set; }
        public int LoaiXetNghiem { get; internal set; }
        public bool SignDigitalSuccess { get; set; }
        public DateTime DateSignDigital { get; set; }
        public string TenFileHIS { get; set; }
        public string conditSomeTestPrint { get; set; }
        public int LanIn { get; internal set; }
        public string HISReportFormID = "9999999";
        public List<int> lstLoaiXnIn = new List<int>();

        public void PrintHeaderResult(XtraReport rp, string headerId)
        {
            if (rp == null)
                return;
            GetHeaderValue(headerId);
            foreach (var para in rp.Parameters)
            {
                if (para.Name.Equals("DongTieuDe1", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TieuDe1 == null ? "" : TieuDe1);
                }
                else if (para.Name.Equals("DongTieuDe2", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TieuDe2 == null ? "" : TieuDe2);
                }
                else if (para.Name.Equals("DongTieuDe3", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TieuDe3 == null ? "" : TieuDe3);
                }
                else if (para.Name.Equals("DongTieuDe4", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TieuDe4 == null ? "" : TieuDe4);
                }
                else if (para.Name.Equals("DongTieuDe5", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TieuDe5 == null ? "" : TieuDe5);
                }
                else if (para.Name.Equals("DongTieuDe6", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TieuDe6 == null ? "" : TieuDe6);
                }
                else if (para.Name.Equals("SoTTLayMau", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = SoTTLayMau;
                }
                else if (para.Name.Equals("InGiohen", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = InGiohen;
                }
                else if (para.Name.Equals("InDam", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInBatThuongInDam);
                }
                else if (para.Name.Equals("InNghieng", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInBatThuongInNghieng);
                }
                else if (para.Name.Equals("GachChan", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInBatThuongGachChan);
                }
                else if (para.Name.Equals("PhieuInTheoNhomIn", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInTachTheoBoPhan);
                }
                else if (para.Name.Equals("PhieuInTheoNhom", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInTachTheoNhom);
                }
                // nhóm
                else if (para.Name.Equals("TenNhomInDam", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInTenNhomInDam);
                }
                else if (para.Name.Equals("TenNhomInNghieng", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInTenNhomInNghieng);
                }
                else if (para.Name.Equals("TenNhomGachChan", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInTenNhomGachChan);
                }
                else if (para.Name.Equals("TenNhomCanhLe", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ClsXetNghiemPhieuInLeTenNhom);
                }
                //kết quả
                else if (para.Name.Equals("CanhLeKetQuaDuoi", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = ClsXetNghiemCanhLeBatThuongDuoi;
                }
                else if (para.Name.Equals("CanhLeKetQuaTren", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = ClsXetNghiemCanhLeBatThuongTren;
                }
                else if (para.Name.Equals("CanhLeKetQuaBinhThuong", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = ClsXetNghiemCanhLeBinhThuong;
                }
                else if (para.Name.Equals("KyTenCuoiMoiTrang", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = ClsXetNghiemPhieuInChuKyCuoiTrang;
                }
                //ký tên
                else if (para.Name.Equals("PhuTrach", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (PhuTrachXetNghiem);
                }

                if (headerId.Equals(DepartementConstant.ShortNameSupersonic, StringComparison.OrdinalIgnoreCase) &&
                   para.Name.Equals("NguoiKyTen", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (
                        (string.IsNullOrWhiteSpace(CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm)
                            ? (NguoiKy == null ? "" : NguoiKy)
                            : CommonAppVarsAndFunctions.TenNguoiKyTamSieuAm));
                }
                else if (headerId.Equals(DepartementConstant.ShortNameTest, StringComparison.CurrentCultureIgnoreCase) &&
                    para.Name.Equals("NguoiKyTen", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (NguoiKy ?? (CommonAppVarsAndFunctions.TempSignIdXetNghiem ?? ""));
                }
                else if (headerId.Equals(DepartementConstant.ShortNameXRay, StringComparison.InvariantCultureIgnoreCase) &&
                    para.Name.Equals("NguoiKyTen", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (
                        (string.IsNullOrWhiteSpace(CommonAppVarsAndFunctions.TempSignIdXQuang)
                            ? (NguoiKy == null ? "" : NguoiKy)
                            : CommonAppVarsAndFunctions.TempSignNameXQuang));
                }
                else if (headerId.Equals(DepartementConstant.ShortNameEndoscopic, StringComparison.CurrentCultureIgnoreCase) &&
                    para.Name.Equals("NguoiKyTen", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (
                        (string.IsNullOrWhiteSpace(CommonAppVarsAndFunctions.TempSignIdNoiSoi)
                            ? (NguoiKy == null ? "" : NguoiKy)
                            : CommonAppVarsAndFunctions.TempSignNameNoiSoi));
                }
                else
                {
                    if (para.Name.Equals("NguoiKyTen", StringComparison.OrdinalIgnoreCase))
                    {
                        para.Value = (NguoiKy == null ? "" : NguoiKy);
                    }
                }
                if (para.Name.Equals("ChucVu", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ChucVu == null ? "" : ChucVu);
                }
                else if (para.Name.Equals("TenPhieuIn", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TenPhieuKq == null ? "" : TenPhieuKq);
                }
                else if (para.Name.Equals("ColorPrint", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (InMau);
                }
                else if (para.Name.Equals("PrintWithConvertUnit", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (PrintWithConvertUnit);
                }
                else if (para.Name.Equals("chungchihanhnghe", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (ChungChiHanhNghe == null ? "" : ChungChiHanhNghe);
                }

                //thông tin phiếu BHYT
                else if (para.Name.Equals("TenCTM", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TenCTM == null ? "" : TenCTM);
                }
                else if (para.Name.Equals("TenNhomMau", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TenNM == null ? "" : TenNM);
                }
                else if (para.Name.Equals("TenDM", StringComparison.OrdinalIgnoreCase))
                {
                    para.Value = (TenDM == null ? "" : TenDM);
                }
                para.Visible = false;
            }
        }
        string TenCTM = string.Empty;
        string TenNM = string.Empty;
        string TenDM = string.Empty;
        bool haveAction = false;
        private void GetHeaderValue(string headerId)
        {
            var printedHeader = _printedFromService.GetPrintedHeaderByDepartementWithUserPrint((string.IsNullOrEmpty(userSign) ? CommonAppVarsAndFunctions.UserID : userSign), headerId);

            if (printedHeader == null) return;

            TieuDe1 = string.IsNullOrWhiteSpace(printedHeader.TieuDe1) ? "" : printedHeader.TieuDe1.Trim();
            TieuDe2 = string.IsNullOrWhiteSpace(printedHeader.TieuDe2) ? "" : printedHeader.TieuDe2.Trim();
            TieuDe3 = string.IsNullOrWhiteSpace(printedHeader.TieuDe3) ? "" : printedHeader.TieuDe3.Trim();
            TieuDe4 = string.IsNullOrWhiteSpace(printedHeader.TieuDe4) ? "" : printedHeader.TieuDe4.Trim();
            TieuDe5 = string.IsNullOrWhiteSpace(printedHeader.TieuDe5) ? "" : printedHeader.TieuDe5.Trim();
            TieuDe6 = string.IsNullOrWhiteSpace(printedHeader.TieuDe6) ? "" : printedHeader.TieuDe6.Trim();

            NguoiKy = string.IsNullOrWhiteSpace(printedHeader.ChuKy) ? "" : printedHeader.ChuKy.Trim();
            ChucVu = string.IsNullOrWhiteSpace(printedHeader.ChucVu) ? "" : printedHeader.ChucVu.Trim();
            TenPhieuKq = string.IsNullOrWhiteSpace(printedHeader.TenPhieuIn) ? "" : printedHeader.TenPhieuIn.Trim();
            ChungChiHanhNghe = string.IsNullOrWhiteSpace(printedHeader.ChungChiHanhNghe) ? "" : printedHeader.ChungChiHanhNghe.Trim();
            PhuTrachXetNghiem = string.IsNullOrWhiteSpace(printedHeader.PhuTrach) ? "" : printedHeader.PhuTrach.Trim();
            //InMau = printedHeader.PrintInColor;
        }
        //public bool ShowReport(XtraReport report, DataTable dataSource,bool print, string printerName, string headerId, string dataSetName, string datatableName, string reportTemplateID = "")
        //{
        //    if (report == null)
        //    {
        //        CustomMessageBox.MSG_Information_OK("Biểu mẫu in chưa được khai báo.");
        //        return false;
        //    }

        //    dataSource.TableName = datatableName;
        //    var dataSet = new DataSet(dataSetName);
        //    dataSet.Tables.Add(dataSource.Copy());
        //    PrintHeaderResult(report, headerId);
        //    report.DataSource = dataSet;
        //    report.RequestParameters = false;
        //    if (print)
        //    {
        //        if (string.IsNullOrEmpty(printerName))
        //        {
        //            CustomMessageBox.MSG_Information_OK("Hãy chọn máy in.");
        //            return false;
        //        }
        //        else
        //        {
        //            var rpt = new ReportPrintTool(report);
        //            rpt.PrinterSettings.PrinterName = printerName;
        //            rpt.Print();
        //            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXuatPDFKhiIn)
        //            {
        //                Task.Factory.StartNew(() =>
        //                {
        //                    insertFileToDB(report, dataSource, reportTemplateID);
        //                });
        //            }
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        documentViewer1.DocumentSource = report;

        //        this.ShowDialog();

        //        if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXuatPDFKhiIn)
        //        {
        //            if (haveAction)
        //            {
        //                Task.Factory.StartNew(() =>
        //                {
        //                    insertFileToDB(report, dataSource, reportTemplateID);
        //                });
        //            }
        //        }
        //        return haveAction;
        //    }
        //}
        private string reportShowingTemplateID = "";
        private DataTable reportShowingdataSource = new DataTable();
        public bool ShowReport(XtraReport report, DataTable dataSource
            , bool print, string printerName, string headerId
            , string dataSetName, string datatableName, string reportTemplateID = "", bool exportPdf = false
            , List<string> pdfPathList = null, bool isInChiDinh= false
            , int copy = 1)
        {
            if (report == null)
            {
                CustomMessageBox.MSG_Information_OK("Biểu mẫu in chưa được khai báo.");
                return false;
            }

            dataSource.TableName = datatableName;
            var dataSet = new DataSet(dataSetName);
            dataSet.Tables.Add(dataSource.Copy());
            PrintHeaderResult(report, headerId);
            report.DataSource = dataSet;
            report.RequestParameters = false;
            if (print)
            {
                if (string.IsNullOrEmpty(printerName))
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn máy in.");
                    return false;
                }
                else
                {
                    var rpt = new ReportPrintTool(report);
                    rpt.PrinterSettings.PrinterName = printerName;
                    rpt.PrinterSettings.Copies = (short)copy;
                    rpt.Print();
                    if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXuatPDFKhiIn && !isInChiDinh)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            insertFileToDB(report, dataSource, reportTemplateID);
                        });
                    }
                    return true;
                }
            }
            else
            {
                reportShowingTemplateID = reportTemplateID;
                reportShowingdataSource = dataSource;
                if (exportPdf)
                {
                    if (pdfPathList == null)
                        pdfPathList = new List<string>();
                    pdfPathList.Add(ExportPDF(report));
                    return true;
                }
                else
                {
                    documentViewer1.DocumentSource = report;
                    this.ShowDialog();
                    return haveAction;
                }
            }
        }
        public string ExportPDF(XtraReport report)
        {
            var fileNametempexportPdf = string.Format(@"{0}\{1}.pdf", CommonAppVarsAndFunctions.sysConfig.EmailPdfPath, SampleID);
            if (!Directory.Exists(CommonAppVarsAndFunctions.sysConfig.EmailPdfPath))
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Đường dẫn xuất file không tồn tại:{0}{1}", Environment.NewLine, CommonAppVarsAndFunctions.sysConfig.EmailPdfPath));
                return string.Empty;
            }
            var exportPdfOpt = new PdfExportOptions();
            exportPdfOpt.DocumentOptions.Application = "TPH.LabIMS";
            exportPdfOpt.DocumentOptions.Author = CommonAppVarsAndFunctions.UserID;
            exportPdfOpt.PdfACompatibility = PdfACompatibility.PdfA3b;

            report.ExportToPdf(fileNametempexportPdf, exportPdfOpt);
            return fileNametempexportPdf;
        }
        private void rbExportPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = (XtraReport)documentViewer1.DocumentSource;
            var path = WorkingServices.OpenSaveDiaglog("PDF file|*.pdf", "pdf");
            if (!string.IsNullOrEmpty(path))
            {
                var pdfOption = new DevExpress.XtraPrinting.PdfExportOptions();

                report.ExportToPdf(path);
                haveAction = true;
                this.Close();
            }
        }

        private void rbExportXLS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = (XtraReport)documentViewer1.DocumentSource;
            var path = WorkingServices.OpenSaveDiaglog("Excel XLS file|*.xls", "xls");
            if (!string.IsNullOrEmpty(path))
            {
                report.ExportToXls(path);
                haveAction = true;
                this.Close();
            }
        }

        private void rbExportXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = (XtraReport)documentViewer1.DocumentSource;
            var path = WorkingServices.OpenSaveDiaglog("Excel XLSX file|*.xlsx", "xlsx");
            if (!string.IsNullOrEmpty(path))
            {
                report.ExportToXlsx(path);
                haveAction = true;
                this.Close();
            }
        }

        private void rbExportRTF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = (XtraReport)documentViewer1.DocumentSource;
            var path = WorkingServices.OpenSaveDiaglog("Document RTF file|*.rtf", "rtf");
            if (!string.IsNullOrEmpty(path))
            {
                report.ExportToRtf(path);
                haveAction = true;
                this.Close();
            }
        }

        private void rbExportIMG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = (XtraReport)documentViewer1.DocumentSource;
            var path = WorkingServices.OpenSaveDiaglog("JPG file|*.jpg|PNG file|*.png", "jpg");
            if (!string.IsNullOrEmpty(path))
            {
                var exportOption = new DevExpress.XtraPrinting.ImageExportOptions();
                exportOption.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage;
                report.ExportToImage(path, exportOption);
                haveAction = true;
                this.Close();
            }
        }
        private bool PrintFromPreview()
        {
            var printDialog1 = new System.Windows.Forms.PrintDialog { AllowSomePages = true };
            if (!string.IsNullOrWhiteSpace(PrinterName))
                printDialog1.PrinterSettings.PrinterName = PrinterName;

            if (printDialog1.ShowDialog() != DialogResult.OK) return false;

            var report = (XtraReport)documentViewer1.DocumentSource;
            int numberCopy = printDialog1.PrinterSettings.Copies;
            var collate = printDialog1.PrinterSettings.Collate;

            var rpt = new ReportPrintTool(report);
            rpt.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PrinterName;
            rpt.PrinterSettings.Collate = collate;
            rpt.PrinterSettings.Copies = (short)numberCopy;

            rpt.PrinterSettings.PrintToFile = printDialog1.PrinterSettings.PrintToFile;
            rpt.PrinterSettings.Duplex = printDialog1.PrinterSettings.Duplex;
            rpt.PrinterSettings.PrintRange = printDialog1.PrinterSettings.PrintRange;
            rpt.Print();

            return true;

        }

        private void rbPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            haveAction = PrintFromPreview();
            if (haveAction)
                this.Close();
        }
        #region Xử lý file PDF
        public List<string> lstIDChiDinhHis = null;
        private void GetThongTinFileKySo(DataTable dataSource, string reportTemplateID, byte[] file)
        {
            //var MaTiepNhan = TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["MaTiepNhan"]);
            //var Seq = TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["Seq"]);
            //var ThoiGianInKQ = TPH.Common.Converter.DateTimeConverter.ToDateTime(dataSource.Rows[0]["NgayInKQ"]);
            //var LanInBP = TPH.Common.Converter.NumberConverter.ToInt(dataSource.Rows[0]["LanInBP"]);
            //var SoPhieuYeuCau = TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["SoPhieuYeuCau"]);
            //var SoHoSo = TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["BN_ID"]);
            //var mabn = TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["mabn"]);
            //var soPhieuChiDinh = (dataSource.Columns.Contains("RSoPhieuYeuCau") ? TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["RSoPhieuYeuCau"]) : TPH.Common.Converter.StringConverter.ToString(dataSource.Rows[0]["SoPhieuYeuCau"]));
          
            //if (lstIDChiDinhHis == null)
            //{
            //    lstIDChiDinhHis = new List<string>();
            //    foreach (DataRow dr in dataSource.Rows)
            //    {
            //        if (!lstIDChiDinhHis.Where(x => x.Equals(dr["IdChiDinhHis"].ToString(), StringComparison.OrdinalIgnoreCase)).Any())
            //            lstIDChiDinhHis.Add(dr["IdChiDinhHis"].ToString());
            //    }
            //}
            ////create pdf file
            //_objSign.LoaiPhieu = reportTemplateID;
            //_objSign.Ngayky = ThoiGianInKQ == DateTime.MinValue ? DateTime.Now : ThoiGianInKQ;
            //_objSign.Lanky = 1;
            //_objSign.Pdffileid = _digSign.GetFileIDFromPdfFile(file);
            //_objSign.Pdfcontent = file;
            //_objSign.Pdffileid = SampleID;
            //_objSign.Mahoso = SoHoSo;
            //_objSign.Matiepnhan = MaTiepNhan;
            //_objSign.Sophieu = Seq;
            //_objSign.SoPhieuChiDinh = soPhieuChiDinh;
            //_objSign.Mabn = mabn;
            //_objSign.Loaiky = (int)LoaiKy;
            //_objSign.Trangthai = true;
            //_objSign.Ngaytaophieu = CommonAppVarsAndFunctions.ServerTime;
            //_objSign.Userky = UserSign;
            //_objSign.MoTa = string.Join("^", lstIDChiDinhHis);
            //_objSign.LanInKQ = LanInBP;
            //_objSign.PCName = Environment.MachineName;
            //_objSign.UserAction = CommonAppVarsAndFunctions.UserID;
            //_objSign.SoPhieuChiDinh = soPhieuChiDinh;
            //_objSign.Daupload = DaUpload;
            //_objSign.LoaiXetNghiem = LoaiXetNghiem;
            //_objSign.TenFileHIS = TenFileHIS;
            //_objSign.DigitialTests = conditSomeTestPrint.Replace("'", "");
            //_objSign.TenFileLIS = Guid.NewGuid().ToString();
        }
        public string MaPhieuIn { get; set; }
        private void insertFileToDB(XtraReport report = null, DataTable dataSource = null, string reportTemplateID = "")
        {
            //byte[] file = GetPDFByte(report);

            //GetThongTinFileKySo(dataSource, reportTemplateID, file);
            //_digSign.InsertSignature(_objSign);
            //if (CommonAppVarsAndFunctions.sysConfig.TPHLabIMSWeb_TuDongGuiChiDinh)
            //{
            //    //Không dùng task vì hàm cha đã được gọi task rồi
            //    UploadFileLenLabIMSWeb(_objSign.Matiepnhan, file, reportTemplateID, reportTemplateID);
            //}
        }
        #endregion

        private void UploadFileLenLabIMSWeb(string maTiepNhan, byte[] file, string maLoaiMau, string tenLoaiMau)
        {
            var labIMSWebConfig = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals((int)TPH.Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)).FirstOrDefault();
            var fileContent = Convert.ToBase64String(file);
            var donViNhanMau = JsonConvert.DeserializeObject<dynamic>(labIMSWebConfig.UserName);
            var xnDetail = new Dictionary<string, object>
                                {
                                    {"ReceptionCodeByInputBranch", maTiepNhan},
                                    {"InputByBranch", donViNhanMau.Value},
                                    {"SampleType", maLoaiMau},
                                    {"SampleTypeName", tenLoaiMau},
                                    {"File", fileContent}
                                };
            _iHISService.UploadFileKetQua(labIMSWebConfig, xnDetail);
        }

        private void FrmPreViewReport_Load(object sender, EventArgs e)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuSuDung)
            {
                pnSignature.Visible = true;
                GetCertificate();
            }
            else
                pnSignature.Visible = false;

            LanguageExtension.LocalizeForm(this, string.Empty);

        }
        Dictionary<string, X509Certificate2> dicCert = new Dictionary<string, X509Certificate2>();
        X509Store store;
        public void GetCertificate()
        {
            // Get a certificate from a Windows Store
            if (store == null)
                store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            // Display a dialog box to select a certificate from the Windows Store
            X509Certificate2Collection selectedCertificates = store.Certificates;

            // Get the first certificate that has a primary key
            foreach (var certificate in selectedCertificates)
            {
                if (certificate.HasPrivateKey && certificate.NotAfter.Date >= DateTime.Now.Date)
                {
                    var arrCn = certificate.Subject.Split(',');
                    var strCn = string.Empty;
                    var cnList = arrCn.ToList().Where(x => x.Contains("CN="));
                    if (cnList.Any())
                    {
                        strCn = cnList.FirstOrDefault().Replace("CN=", "");//.Replace("-", "").Replace(",", "").Replace("@", "").Trim();
                    }
                    if (!strCn.Equals("localhost") && !strCn.Equals("3b55232c-6594-4c8b-833b-7758d9e385ac") && !strCn.Equals(Environment.UserName))
                    {
                        WriteLog.LogService.RecordLogFile("Certificate", certificate.ToString(), "GetCertificate");
                        dicCert.Add(strCn, certificate);
                        lstCert.Items.Add(strCn);
                    }
                }
            }
            lstCert.ItemAutoHeight = true;
        }

        private void btnKyTen_Click(object sender, EventArgs e)
        {
            //if (lstCert.SelectedIndex > -1)
            //{
            //    if (IsCheckLackingTests(MaTiepNhan, TenFileHIS))
            //        return;
            //    var cert = dicCert[lstCert.SelectedValue.ToString()];

            //    var report = (XtraReport)documentViewer1.DocumentSource;
            //    byte[] file = GetPDFByte(report);
            //    var Seq = TPH.Common.Converter.StringConverter.ToString(reportShowingdataSource.Rows[0]["Seq"]);
            //    //var fileNametempexportPdf = string.Format("TemExportPdf_{0}.pdf", Seq);
            //    var fileNametempexportPdfSigned = string.Empty;//string.Format("TemExportPdf_{0}_Signed.pdf", Seq);
            //    System.Drawing.Image imgSignature = null;
            //    if (!string.IsNullOrEmpty(reportShowingdataSource.Rows[0]["signpicture"].ToString()))
            //    {
            //        imgSignature = System.Drawing.Image.FromStream(new MemoryStream((byte[])reportShowingdataSource.Rows[0]["signpicture"]));
            //    }
            //    //  var stream = SetReportDegitalSignInfo(report, cert, imgSignature);
            //    var stream = DigitalSignature.CertificateHelper.SignPDF(cert, new MemoryStream(file), lstCert.SelectedValue.ToString()
            //       , imgSignature, fileNametempexportPdfSigned,
            //       left: CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLeTrai, bottom: CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLeDuoi
            //       , right: CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLePhai, height: CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuDoCaoRec);
            //    if (stream != null)
            //    {
            //        InsertVaUpdateThongTinKySo(stream.ToArray());
            //        ShowPhieuDaKy();
            //        haveAction = true;
            //        this.Close();
            //    }
            //}
        }
        private MemoryStream SetReportDegitalSignInfo(XtraReport report, X509Certificate2 cert, System.Drawing.Image imgSignature)
        {
            PdfSignatureOptions signatureOptions = report.ExportOptions.Pdf.SignatureOptions;
            signatureOptions.Certificate = cert;
            signatureOptions.ImageSource = new ImageSource(imgSignature, false);
            signatureOptions.Reason = "Approved";
            signatureOptions.Location = "VietName";
            signatureOptions.ContactInfo = "andrew.fuller@example.com";

            using (var ms = new MemoryStream())
            {
                report.ExportToPdf(ms);
                return ms;
            }
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowPhieuDaKy()
        {
            //if (ViewPdfAfterPrint)
            //{
            //    var f = new FrmViewPDFSigned();
            //    f.Barcode = Seq;
            //    f.NgayLuu = _objSign.Ngayky;
            //    f.ShowDialog();
            //}
        }
        private void InsertVaUpdateThongTinKySo(byte[] sPdfDecoded)
        {
            //GetThongTinFileKySo(reportShowingdataSource, reportShowingTemplateID, sPdfDecoded);
            //_digSign.InsertSignature(_objSign);
            ////Ghi file xong update lại trong xetnghiem_kyso;
            ////Chỗ nay phải tách sp ra để ko nhầm cái cũ
            ////Update xong phải ghi logs lại lần cũ
            //_digSign.UpdateXetNghiemKySo(_objSign);
        }
        #region Ký số HSM
        private void DigitalSignedByHSM(bool print = false)
        {
            //var logContent = string.Empty;
            //WriteLog.LogService.RecordLogFile("KySo", "url");
            //var url = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLinkAPI;
            //WriteLog.LogService.RecordLogFile("KySo", "username");
            //var username = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuTaiKhoan;
            //WriteLog.LogService.RecordLogFile("KySo", "password");
            //var password = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuMatKhau;
            //WriteLog.LogService.RecordLogFile("KySo", "serial");
            //var serial = IdChuKySo; // CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuSerial;
            //WriteLog.LogService.RecordLogFile("KySo", "digest");
            //var digest = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuSHA;
            //WriteLog.LogService.RecordLogFile("KySo", "username");
            ////CustomMessageBox.MSG_Information_OK(string.Format("DigitalSignedBy"));
            //logContent += string.Format("url: {0}, username: {1}, password: {2}, serial: {3}, digest: {4}"
            //    , url, username, TPH.Common.StringCryptography.EnDeCrypt.EncryptString(password, AuthorizationConstant.Clinic), serial, digest);
            //if (string.IsNullOrWhiteSpace(url) ||
            //    string.IsNullOrWhiteSpace(username) ||
            //    string.IsNullOrWhiteSpace(password) ||
            //    string.IsNullOrWhiteSpace(serial))
            //{
            //    MessageBox.Show("Vui lòng cấu hình thông tin Chữ ký số!");
            //    return;
            //}
            //var report = (XtraReport)documentViewer1.DocumentSource;
            //var pdfData = GetPDFByte(report);

            //if (pdfData != null)
            //{
            //    var fileContent = Convert.ToBase64String(pdfData);
            //    if (string.IsNullOrWhiteSpace(fileContent))
            //    {
            //        WriteLog.LogService.RecordLogFile("KySo", "Not HaveContent");
            //        MessageBox.Show("Nội dung file cần ký không hợp lệ!");
            //        return;
            //    }
            //    // Kiếm các xn đã ký trước và so với xn hiện tại xem thiếu gì không
            //    // Nếu thiếu thì cho chọn Y/N và show ra các xn thiếu, chỉ lấy xn con.
            //    //Nếu tồn tại tenfileHIS thì check
            //    WriteLog.LogService.RecordLogFile("KySo", " Kiếm các xn đã ký trước và so với xn hiện tại xem thiếu gì không? - Nếu thiếu thì cho chọn Y/N và show ra các xn thiếu, chỉ lấy xn con.");
            //    if (IsCheckLackingTests(MaTiepNhan, TenFileHIS))
            //        return;
            //    //sign
            //    try
            //    {
            //        WriteLog.LogService.RecordLogFile("KySo", "ngayKy");
            //        var ngayKy = C_Ultilities.ServerDate();
            //        logContent += string.Format("=====Sending File To Viettel=====: {0}\n", ngayKy.ToString("dd/MM/yyyy HH:MM:ss:fff"));

            //        var result = _signCertificate.SignPdfBase64RectangleText(new SignPdfBase64RectangleTextRequest
            //        {
            //            ApiUrl = url,
            //            AppCode = username,
            //            Password = password,
            //            SerialNumber = serial,
            //            DigestAlgorithm = digest,
            //            FileContent = fileContent,
            //            DisplayRectangle = new BaseSignFilePositionRequest
            //            {
            //                HeightRectangle = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuDoCaoRec,
            //                WidthRectangle = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuDoRongRec,
            //                MarginTopOfRectangle = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLeTren,
            //                MarginBottomOfRectangle = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLeDuoi,
            //                MarginLeftOfRectangle = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLeTrai,
            //                MarginRightOfRectangle = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLePhai,
            //                LocateSign = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuViTri,
            //                FontSize = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuCoChu,
            //                FormatRectangleText = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuDinhDang,
            //                DateFormat = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuDinhDangNgayGio,
            //                NumberPageSign = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuTrangKy,
            //                Contact = string.Empty,
            //                Reason = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuLyDo,
            //                Location = CommonAppVarsAndFunctions.sysConfig.ChuKyDienTuNoiKy
            //            }
            //        });

            //        if (result.Code == 0)
            //        {
            //            SignDigitalSuccess = true;
            //            DateSignDigital = ngayKy;

            //            var sPdfDecoded = Convert.FromBase64String(result.FileContent);

            //            if (print)
            //                PrintPDF(sPdfDecoded);
            //            //xác nhận sau in
            //            WriteLog.LogService.RecordLogFile("KySo", "xác nhận sau in:ReportType");
            //            EndWithPrinted = true;
            //            switch (ReportType)
            //            {
            //                case (int)ServiceType.ClsXetNghiem:
            //                    _testMethodService.UpdatePrintedInfoOfTestResult(_maTiepNhan, CommonAppVarsAndFunctions.UserID);
            //                    break;
            //                    //case (int)ServiceType.ClsSieuAm:
            //                    //    _testMethodService.UpdatePrintedInfoOfSupersonicResult(_maTiepNhan, CommonAppVarsAndFunctions.UserID,
            //                    //        _maSoMau);
            //                    //    break;
            //                    //case (int)ServiceType.ClsXQuang:
            //                    //    _testMethodService.UpdatePrintedInfoOfXRayResult(_maTiepNhan, CommonAppVarsAndFunctions.UserID);
            //                    //    break;
            //            }
            //            WriteLog.LogService.RecordLogFile("KySo", "signedFilePath");
            //            InsertVaUpdateThongTinKySo(sPdfDecoded);
            //            ShowPhieuDaKy();
            //            this.Close();
            //            haveAction = true;
            //        }
            //        else
            //        {
            //            if (result.Message.Contains("timed out"))
            //                MessageBox.Show(string.Format("Lỗi trong quá trình ký: {0}\nVui lòng liên hệ phòng CNTT hỗ trợ.", result.Message));
            //            else
            //                MessageBox.Show(string.Format("Lỗi trong quá trình ký: {0}", result.Message));
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorService.GetFrameworkErrorMessage(ex, "btnInChuKySo_Click", CommonAppVarsAndFunctions.UserID);
            //        CustomMessageBox.MSG_Information_OK(ex.ToString());
            //    }
            //    finally
            //    {
            //        WriteLog.LogService.RecordLogFile("DigitalSigned", logContent, "DigitalSignedBy()");
            //        if (!print)
            //        {
            //            CustomMessageBox.ShowAlert("File kết quả được xuất thành công!");
            //            System.Threading.Thread.Sleep(1200);
            //            CustomMessageBox.CloseAlert();
            //        }
            //    }
            //}
        }
        private bool IsCheckLackingTests(string maTiepNhan, string tenFileHIS)
        {
            //var dtKySo = _digSign.GetDataKySoByTenFileHIS(maTiepNhan, tenFileHIS);
            //if (dtKySo.Rows.Count > 0)
            //{
            //    //số code truyền đang ký
            //    var tempConditSomeTestPrint = conditSomeTestPrint.Replace("'", "");
            //    List<string> lstTestsDangKy = tempConditSomeTestPrint.Split(',').ToList();

            //    //số code đã ký
            //    var lstTestsDaKy = new List<string>();
            //    foreach (DataRow dr in dtKySo.Rows)
            //        lstTestsDaKy.Add(StringConverter.ToString(dr["MaXN"]));

            //    List<string> lstLackingTests = lstTestsDaKy.Except(lstTestsDangKy).ToList();
            //    if (lstLackingTests.Count > 0)
            //    {
            //        string message = string.Empty;
            //        string lackingTests = string.Join(",", lstLackingTests);
            //        message += "Các xét nghiệm ký số đang thiếu:\n";
            //        message += string.Format("\"{0}\"\n", lackingTests);
            //        message += "Bạn có muốn tiếp tục ký số không?";

            //        //Yes la tiep tuc ký, No là Không ký
            //        return CustomMessageBox.MSG_Question_YesNo_GetNo(message);
            //    }
            //}
            return false;
        }
        private byte[] GetPDFByte(XtraReport report = null)
        {
            if (report == null)
                report = (XtraReport)documentViewer1.DocumentSource;

            byte[] file;
            var exportPdfOpt = new PdfExportOptions();
            exportPdfOpt.DocumentOptions.Application = "TPH.LabIMS";
            exportPdfOpt.DocumentOptions.Author = CommonAppVarsAndFunctions.UserID;
            exportPdfOpt.PdfACompatibility = PdfACompatibility.PdfA3b;
            exportPdfOpt.PdfUACompatibility = PdfUACompatibility.PdfUA1;
            using (MemoryStream ms = new MemoryStream())
            {
                report.ExportToPdf(ms, exportPdfOpt);
                file = ms.ToArray();
            }
            return file;
        }
        private void PrintPDF(byte[] content)
        {
            var pdfviewer = new PdfViewer();
            Stream stream = new MemoryStream(content);
            pdfviewer.LoadDocument(stream);
            var printoption = new DevExpress.Pdf.PdfPrinterSettings();
            printoption.Settings.PrinterName = PrinterName;
            pdfviewer.Print(printoption);
        }
        #endregion

        private void chkXemLaiFileKySo_CheckedChanged(object sender, EventArgs e)
        {
            ViewPdfAfterPrint = true;
        }
    }
}
