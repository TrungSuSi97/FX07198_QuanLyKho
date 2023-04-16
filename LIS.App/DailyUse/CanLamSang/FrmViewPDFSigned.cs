using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.DigitalSignature.Service.Impl;
using TPH.LIS.DigitalSignature.Service;
using System.IO;
using TPH.LIS.Common.Controls;
using DevExpress.XtraGauges.Core.SHP;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmViewPDFSigned : FrmTemplate
    {
        public FrmViewPDFSigned()
        {
            InitializeComponent();
        }
        public string Barcode = string.Empty;
        public DateTime NgayLuu = DateTime.Now;
        private readonly IDigitalSignature digiSign = new DigitalSignatureService();
        private void btnXemFile_Click(object sender, EventArgs e)
        {
            gvDanhSach.FocusedColumnChanged -= gvDanhSach_FocusedColumnChanged;
            gvDanhSach.FocusedRowChanged -= gvDanhSach_FocusedRowChanged;
            var data = digiSign.GetFileListDB(txtBarcode.Text, txtmaBN.Text, dtpNgayIn.Value.Date);
            gcDanhSach.DataSource = data;
            gvDanhSach.FocusedRowChanged += gvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged += gvDanhSach_FocusedColumnChanged;
            LoadPDFInfo();
        }
        private void gvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadPDFInfo();
        }
        private void gvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            LoadPDFInfo();
        }
        private void LoadPDFInfo()
        {
            if (gvDanhSach.GetFocusedRowCellValue(colID) != null)
            {
                var id = long.Parse(gvDanhSach.GetFocusedRowCellValue(colID).ToString());
                var isArchive = bool.Parse(gvDanhSach.GetFocusedRowCellValue(colArchive).ToString());
                var pdfContent = digiSign.Get_Info_ThongTinFileKy(digiSign.GetFileInfoByID(id, isArchive).Rows[0]);

                pdfViewer1.LoadDocument(new MemoryStream(pdfContent.Pdfcontent));
                var lst = digiSign.GetSignatureInfoInPdf(pdfContent.Pdfcontent);
                pnSignInfo.Controls.Clear();
                pnSignInfo.AutoScroll = true;
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        var lb = new Label();
                        lb.Font = new Font(lb.Font, FontStyle.Bold);
                        lb.ForeColor = Color.DarkBlue;
                        lb.Text = item;
                        pnSignInfo.Controls.Add(lb);
                        lb.Dock = DockStyle.Top;
                    }
                }
            }
        }
        private void SavePDF()
        {
            if (gvDanhSach.GetFocusedRowCellValue(colID) != null)
            {
                var id = long.Parse(gvDanhSach.GetFocusedRowCellValue(colID).ToString());
                var isArchive = bool.Parse(gvDanhSach.GetFocusedRowCellValue(colArchive).ToString());
                var pdfContent = digiSign.Get_Info_ThongTinFileKy(digiSign.GetFileInfoByID(id, isArchive).Rows[0]);
                SaveFileDialog diag = new SaveFileDialog();
                diag.FileName = String.Format("{0}_ID_{1}.pdf", gvDanhSach.GetFocusedRowCellValue(colMaTiepNhan).ToString(), id);
                diag.Filter = "PDF|*.pdf";
                if (diag.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(diag.FileName, pdfContent.Pdfcontent);
                }
            }
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                var txt = (TextBox)sender;
                if (!string.IsNullOrEmpty(txt.Text))
                {
                    btnXemFile_Click(sender, e);
                    e.Handled = true;
                }
            }

        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtmaBN.Text))
                txtmaBN.Text = string.Empty;
        }

        private void txtmaBN_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
                txtBarcode.Text = string.Empty;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Upload lại các file đang chọn?"))
                {
                    foreach (var item in gvDanhSach.GetSelectedRows())
                    {
                        if (gvDanhSach.GetRowCellValue(item, colID) != null)
                        {
                            var id = long.Parse(gvDanhSach.GetRowCellValue(item, colID).ToString());
                            var isArchive = bool.Parse(gvDanhSach.GetRowCellValue(item, colArchive).ToString());
                            digiSign.UpdateReUpload(id, isArchive);
                        }
                    }
                    gvDanhSach.ClearSelection();
                }
            }
        }

        private void btnInFile_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.GetFocusedRowCellValue(colID) != null)
            {
                pdfViewer1.Print();
            }
        }

        private void btnDownLoadPDF_Click(object sender, EventArgs e)
        {
            SavePDF();
        }

        private void FrmViewPDFFiles_Load(object sender, EventArgs e)
        {
            if (this.TopLevelControl != this)
            {
                pnMenu.Visible = false;
            }
            btnInFile.Enabled = CommonAppVarsAndFunctions.IsAdmin;
            if (!string.IsNullOrEmpty(Barcode))
            {
                txtBarcode.Text = Barcode;
                dtpNgayIn.Value = NgayLuu;
                btnXemFile_Click(sender, e);
            }
        }

        private void FrmViewPDFFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            gvDanhSach.FocusedColumnChanged -= gvDanhSach_FocusedColumnChanged;
            gvDanhSach.FocusedRowChanged -= gvDanhSach_FocusedRowChanged;
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            txt.SelectAll();
        }

        private void dtpNgayIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnXemFile_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
