using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Repositories;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmNhatkyTuChoi_Huy : FrmTemplate
    {
        private readonly IPatientInformationRepository _iPatient = new PatientInformationRepository();
        public FrmNhatkyTuChoi_Huy()
        {
            InitializeComponent();
        }
        public string findBarcode = string.Empty;
        public DateTime? tuNgay;
        private void btnXemNhatKy_Click(object sender, EventArgs e)
        {
            Load_NhatKyMau();
        }

        private void Load_NhatKyMau()
        {
            var data = _iPatient.Data_nhatky_mauxetnghiem(string.Empty, txtBarcode.Text, txtNguoiThucHien.Text
                , (!string.IsNullOrEmpty(txtBarcode.Text) ? (DateTime?)null : dtpTuNgay.Value)
                , (!string.IsNullOrEmpty(txtBarcode.Text) ? (DateTime?)null : WorkingServices.EndOfDay(dtpDenNgay.Value))
                , chkNhatKyXemChiTiet.Checked, string.Join(",", CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList()));
            data.Columns.Add("HanhDong", typeof(string));
            data.Columns.Add("TinhTrangMauMoi", typeof(string));
            foreach (DataRow dr in data.Rows)
            {
                var dateTiemAction = DateTime.Parse(dr["ThoiGianThucHien"].ToString());
                dr["ThoiGianThucHien"] = dateTiemAction.AddMilliseconds(-dateTiemAction.Millisecond);

                var idHanhDong = int.Parse(dr["IdThucHien"].ToString());
                if (idHanhDong == (int)TrangThaiThongTinXetNghiem.HuyLayMau)
                {
                    dr["HanhDong"] = "HỦY LẤY MẪU";
                }
                else if (idHanhDong == (int)TrangThaiThongTinXetNghiem.HuyNhanMau)
                {
                    dr["HanhDong"] = "BỎ DUYỆT NHẬN MẪU";
                }
                else if (idHanhDong == (int)TrangThaiThongTinXetNghiem.TuChoiMau)
                {
                    dr["HanhDong"] = "TỪ CHỐI/YÊU CẦU LẤY LẠI";
                }
                else if (idHanhDong == (int)TrangThaiThongTinXetNghiem.OpenOrder)
                {
                    dr["HanhDong"] = "OPEN ORDER";
                }
                else if (idHanhDong == (int)TrangThaiThongTinXetNghiem.HoanDichVu)
                {
                    dr["HanhDong"] = "HOÀN DỊCH VỤ";
                }
                else if (idHanhDong == (int)TrangThaiThongTinXetNghiem.TinhTrangMau)
                {
                    dr["HanhDong"] = "ĐỔI TÌNH TRẠNG MẪU";
                    dr["TinhTrangMauMoi"] = dr["LyDo"].ToString();
                    dr["LyDo"] = string.Empty;
                }
            }
            data.AcceptChanges();
            gcNhatKy.DataSource = data;
            gvNhatKy.ExpandAllGroups();
            LoadNhatKyDoiGio();
        }
        private void LoadNhatKyDoiGio()
        {
            var data = _iPatient.Data_NhatKy_DoiGioThaoTacMau((!string.IsNullOrEmpty(txtBarcode.Text) ? (DateTime?)null : dtpTuNgay.Value)
              , (!string.IsNullOrEmpty(txtBarcode.Text) ? (DateTime?)null : WorkingServices.EndOfDay(dtpDenNgay.Value))
              , txtBarcode.Text, txtNguoiThucHien.Text);
            gcNhatKyDoiThoiGian.DataSource = data;
            gvNhatKyDoiThoiGian.ExpandAllGroups();
        }
        private void Check_Expand_NhatKy()
        {
            if (chkNhatKyXemChiTiet.Checked)
                gvNhatKy.ExpandAllGroups();
            else
            {
                gvNhatKy.CollapseAllGroups();
                gvNhatKy.ExpandGroupLevel(0);
                gvNhatKy.ExpandGroupLevel(1);
            }
        }
        private void FrmNhatkyTuChoi_Huy_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            if (!string.IsNullOrEmpty(findBarcode))
            {
                if (tuNgay != null)
                    dtpTuNgay.Value = tuNgay.Value;
                txtBarcode.Text = findBarcode;
                Load_NhatKyMau();
            }
        }
        private void Check_Expand_YeuCauLayLai()
        {
            if (chkChiTiet_YeuCauLayLai.Checked)
                gvYeuCauLayLai.ExpandAllGroups();
            else
            {
                gvYeuCauLayLai.CollapseAllGroups();
                gvYeuCauLayLai.ExpandGroupLevel(0);
            }
        }
        private void chkChiTiet_YeuCauLayLai_CheckedChanged(object sender, EventArgs e)
        {
            Check_Expand_YeuCauLayLai();
        }

        private void Check_Expand_BoDuyetNhanMau()
        {
            if (chkChiTiet_BoDuyetNhanMau.Checked)
                gvBoDuyetNhanMau.ExpandAllGroups();
            else
            {
                gvBoDuyetNhanMau.CollapseAllGroups();
                gvBoDuyetNhanMau.ExpandGroupLevel(0);
            }
        }
        private void chkChiTiet_BoDuyetNhanMau_CheckedChanged(object sender, EventArgs e)
        {
            Check_Expand_BoDuyetNhanMau();
        }
        private void Check_Expand_ChuaLayMau()
        {
            if (chkChiTietChuaLayMau.Checked)
                gvBoLayMau.ExpandAllGroups();
            else
            {
                gvBoLayMau.CollapseAllGroups();
                gvBoLayMau.ExpandGroupLevel(0);
            }
        }
        private void chkChiTietChuaLayMau_CheckedChanged(object sender, EventArgs e)
        {
            Check_Expand_ChuaLayMau();
        }

        private void FrmNhatkyTuChoi_Huy_Shown(object sender, EventArgs e)
        {
            chkNhatKyXemChiTiet.CheckedChanged += chkNhatKyXemChiTiet_CheckedChanged;
            txtBarcode.Focus();
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_NhatKyMau();
            }
        }

        private void chkNhatKyXemChiTiet_CheckedChanged(object sender, EventArgs e)
        {
            Load_NhatKyMau();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcNhatKy);
        }
    }
}
