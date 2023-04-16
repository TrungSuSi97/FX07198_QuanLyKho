using System;
using System.ComponentModel;
using System.Windows.Forms;
using TPH.Report.Services;
using TPH.Report.Services.Impl;
using System.IO;
using TPH.Report.Models;
using DevExpress.XtraReports.UI;
using TPH.Report.Constants;

namespace TPH.Report.Controls
{
    public partial class ucCauHinhReport : UserControl
    {
        private readonly IReportService _report = new ReportServiceImpl();
        public string UserId = string.Empty;
        public EnumReportApp ReportApp = EnumReportApp.LabIMS;
        private ReportModel info = new ReportModel();
        public ucCauHinhReport()
        {
            InitializeComponent();
        }
        [Category("Custom")]
        public event EventHandler ReportAdded;
        [Category("Custom")]
        public event EventHandler ReloadReport;
        public void LoadDanhSachUngDung()
        {
            var bindSource = new BindingSource();
            bindSource.DataSource = ReportAppType.ListReportApp();
            cboUngDung.DataSource = bindSource;
            cboUngDung.ValueMember = "ID";
            cboUngDung.DisplayMember = "Name";
            cboUngDung.SelectedIndex = (int)ReportApp;
            cboUngDung.SelectedIndexChanged += CboUngDung_SelectedIndexChanged;

            Load_DanhSachReport();
        }
        private void CboUngDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhSachReport();
        }
        public void Load_DanhSachReport()
        {
            if (cboUngDung.SelectedIndex > -1)
            {
                cboReport.SelectedIndexChanged -= CboReport_SelectedIndexChanged;
                cboReport.DataSource = _report.Data_DanhSachReport(int.Parse(cboUngDung.SelectedValue.ToString()));
                cboReport.ValueMember = "ReportId";
                cboReport.DisplayMember = "ReportId";
                cboReport.SelectedIndex = -1;
                cboReport.SelectedIndexChanged += CboReport_SelectedIndexChanged;
            }
        }

        private void CboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Info();
        }
        private void Clear_info()
        {
            info = new ReportModel();
            txtDuongDanUpload.Text = string.Empty;
            txtNgayApDung.Text = string.Empty;
            txtNgayUpload.Text = string.Empty;
            txtNguoiApDung.Text = string.Empty;
            txtNguoiUpload.Text = string.Empty;
            txtTenDataSet.Text = string.Empty;
            txtTenDatatable.Text = string.Empty;
            btnDownloadFileSuDung.Enabled = false;
            btnDownloadFileGoc.Enabled = false;
            btnUploadFileGoc.Enabled = false;
            btnSuDungFile.Enabled = false;
        }
        private void Load_Info()
        {
            Clear_info();

            if(cboReport.SelectedIndex >-1)
            {
                var reportId = cboReport.SelectedValue.ToString();
                info = _report.Info_Report(reportId);
                if(!string.IsNullOrEmpty(info.ReportId))
                {
                    txtNgayApDung.Text = (info.NgayApDung == null ? string.Empty : info.NgayApDung.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    txtNgayUpload.Text = (info.NgaySua == null ? string.Empty : info.NgaySua.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    txtNguoiApDung.Text = info.NguoiApDung;
                    txtNguoiUpload.Text = info.NguoiSua;
                    txtTenDataSet.Text = info.TenDataset;
                    txtTenDatatable.Text = info.TenDatatable;
                    btnDownloadFileSuDung.Enabled = !string.IsNullOrEmpty(txtNgayApDung.Text);
                    btnDownloadFileGoc.Enabled = !string.IsNullOrEmpty(txtNgayUpload.Text);
                    btnSuDungFile.Enabled = !string.IsNullOrEmpty(txtNgayUpload.Text);

                    txtSubReport1_Name.Text = info.ReportSub1;
                    txtDataset_Sub1.Text = info.TenDataSetSub1;
                    txtDatatable_Sub1.Text = info.TenDatatableSub1;

                    txtSubReport2_Name.Text = info.ReportSub2;
                    txtDataset_Sub2.Text = info.TenDataSetSub2;
                    txtDatatable_Sub2.Text = info.TenDatatableSub2;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XtraReport (*.repx)|*.repx";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                txtDuongDanUpload.Text = openFileDialog1.FileName;
            }
        }

        private void txtDuongDanUpload_TextChanged(object sender, EventArgs e)
        {
            btnUploadFileGoc.Enabled = !string.IsNullOrEmpty(txtDuongDanUpload.Text);
        }
        private void UploadFile()
        {
            if (cboReport.SelectedIndex > -1 && !string.IsNullOrEmpty(txtDuongDanUpload.Text)
                && !string.IsNullOrEmpty(txtTenDataSet.Text) && !string.IsNullOrEmpty(txtTenDatatable.Text))
            {
                var reportId = cboReport.SelectedValue.ToString();
                var path = txtDuongDanUpload.Text;
                if (MessageBox.Show("Upload biểu mẫu report?", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_report.Update_ReportGoc(reportId, ReadFile(path)
                           , txtTenDataSet.Text, txtTenDatatable.Text, UserId, Environment.MachineName
                           , txtSubReport1_Name.Text, txtDataset_Sub1.Text, txtDatatable_Sub1.Text
                           , txtSubReport2_Name.Text, txtDataset_Sub2.Text, txtDatatable_Sub2.Text
                           ) > 0)
                    {
                        Load_Info();
                    }
                }
            }
        }
        public void Update_SuDung()
        {
            if (cboReport.SelectedIndex > -1)
            {
                var reportId = cboReport.SelectedValue.ToString();
                if (MessageBox.Show("Áp dụng biểu mẫu report?", "Report", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_report.Update_Report_ApDung(reportId, UserId) > 0)
                    {
                        Load_Info();
                    }
                }
            }
        }
        // Create a report from a stream. 
        private XtraReport CreateReportFromStream(MemoryStream stream)
        {
            XtraReport report = XtraReport.FromStream(stream, true);
            return report;
        }
        private void DownloadFile(byte[] file)
        {
            if (cboReport.SelectedIndex > -1)
            {
                var reportId = cboReport.SelectedValue.ToString();
                var saDiag = new SaveFileDialog();
                saDiag.FileName = reportId;
                saDiag.Filter ="XtraReport (*.repx)|*.repx";
                saDiag.DefaultExt = "repx";
                saDiag.ShowDialog();
                if(!string.IsNullOrEmpty(saDiag.FileName))
                {
                    ByteArrayToFile(saDiag.FileName, file);
                    MessageBox.Show("Download hoàn tất!");
                }
            }
        }
        private byte[] ReadFile(string filePath)
        {
            byte[] file;
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            return file;
        }
        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
        private void btnUploadFileGoc_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void btnSuDungFile_Click(object sender, EventArgs e)
        {
            Update_SuDung();
            ReloadReport?.Invoke(sender,e);

        }

        private void btnDownloadFileSuDung_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(info.ReportId))
            {
                DownloadFile(info.ReportSuDung);
            }
        }

        private void btnDownloadFileGoc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(info.ReportId))
            {
                DownloadFile(info.ReportGoc);
            }
        }

        private void txtTheReport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdReport.Text))
            {
                _report.Insert_Report(txtIdReport.Text, int.Parse(cboUngDung.SelectedValue.ToString()));
                Load_DanhSachReport();
                cboReport.SelectedValue = txtIdReport.Text;
                txtIdReport.Text = string.Empty;
                ReportAdded?.Invoke(sender, e);
                txtIdReport.Focus();
            }
        }
    }
}
