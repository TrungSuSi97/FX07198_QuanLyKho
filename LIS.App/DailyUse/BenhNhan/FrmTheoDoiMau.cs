using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Controls;
using TPH.LIS.Patient.Services;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmTheoDoiMau : FrmTemplate
    {
        public FrmTheoDoiMau()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMaBenhNhan.Text = string.Empty;
            txtSoHoSo.Text = string.Empty;
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DanhSach();
                e.Handled = true;
            }
        }
        /// <summary>
        /// Tìm bệnh nhân
        /// </summary>
        /// <param name="loai">1: Barcode - 2: Số hồ sơ - 3: Số phiếu - 4: Mã bệnh nhân</param>
        private string TimBenhNhan(int loai)
        {
            var f = new FrmTimBenhNhanTheoNgay();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            if (loai == 1)
                return f.Barcode;
            else if (loai == 2)
                return f.SoHoSo;
            else if (loai == 3)
                return f.SoPhieuYeuCau;
            else if (loai == 4)
                return f.MaBenhNhan;
            return string.Empty;
        }
        private void txtSoHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMaBenhNhan.Text = string.Empty;
            txtBarcode.Text = string.Empty;
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DanhSach();
                e.Handled = true;
            }
        }

        private void txtMaBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBarcode.Text = string.Empty;
            txtSoHoSo.Text = string.Empty;
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DanhSach();
                e.Handled = true;
            }
        }

        private void Load_DanhSach()
        {
            pnDSTheoDoiMau.Controls.Clear();
            pnDSTheoDoiMau.Visible = false;
            pnDSTheoDoiMau.Width = 1;
            if (string.IsNullOrEmpty(txtBarcode.Text) && string.IsNullOrEmpty(txtMaBenhNhan.Text) && string.IsNullOrEmpty(txtSoHoSo.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập thông tin cần xem!");
                return;
            }
            var data = _iPatient.Data_TheoDoiMau(txtMaBenhNhan.Text, string.Empty, txtBarcode.Text, txtSoHoSo.Text
                , string.Join(",", CommonAppVarsAndFunctions.BoPhanClsXetNghiem), (dtpNgayNhanMau.Checked ? dtpNgayNhanMau.Value : (DateTime?)null));
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    var lastYLocation = 0;
                    var distinctbarcode = data.DefaultView.ToTable(true, "Seq");
                    distinctbarcode.DefaultView.Sort = "Seq desc";
                    distinctbarcode = distinctbarcode.DefaultView.ToTable();
                    foreach (DataRow drSeq in distinctbarcode.Rows)
                    {
                        var dataSeq = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("Seq = '{0}'", drSeq["Seq"].ToString()));
                        var uc = new ucThongTinTheoDoiMauTheoBarcode();
                        uc.DataSource = dataSeq;
                        uc.BorderStyle = BorderStyle.FixedSingle;
                        pnDSTheoDoiMau.Controls.Add(uc);
                        uc.Location = new Point(0, lastYLocation + 1);
                        if (pnDSTheoDoiMau.Width < uc.Width)
                        {
                            pnDSTheoDoiMau.Width = uc.Width + 15;
                        }
                       // uc.BringToFront();
                    }
                    pnDSTheoDoiMau.Location = new Point((this.Width / 2) - (pnDSTheoDoiMau.Width / 2), groupControl3.Height + 1);
                    pnDSTheoDoiMau.Height = this.Height - (groupControl3.Height + 1);
                    pnDSTheoDoiMau.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
                    pnDSTheoDoiMau.Visible = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Load_DanhSach();
        }

        private void btnTimMaBN_Click(object sender, EventArgs e)
        {
            txtMaBenhNhan.Text = TimBenhNhan(4);
            pnDSTheoDoiMau.Controls.Clear();
            if (!string.IsNullOrEmpty(txtMaBenhNhan.Text))
                Load_DanhSach();
        }

        private void btnTimSHS_Click(object sender, EventArgs e)
        {
            txtSoHoSo.Text = TimBenhNhan(2);
            pnDSTheoDoiMau.Controls.Clear();
            if (!string.IsNullOrEmpty(txtSoHoSo.Text))
                Load_DanhSach();
        }

        private void btnTimBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = TimBenhNhan(1);
            pnDSTheoDoiMau.Controls.Clear();
            if (!string.IsNullOrEmpty(txtBarcode.Text))
                Load_DanhSach();
        }

        private void FrmTheoDoiMau_Load(object sender, EventArgs e)
        {
            //groupControl3.Appearance.BackColor = TPH.Controls.CommonAppColors.ColorMainAppColor;
        }
    }
}
