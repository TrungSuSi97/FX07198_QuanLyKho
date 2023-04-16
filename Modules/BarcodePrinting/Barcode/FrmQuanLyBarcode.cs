using System;
using System.IO;
using System.Windows.Forms;
using TPH.LIS.BarcodePrinting.Constants;

namespace TPH.LIS.BarcodePrinting.Barcode
{
    public partial class FrmQuanLyBarcode : Form
    {
        public FrmQuanLyBarcode()
        {
            InitializeComponent();
        }
        private readonly Service.IBarcodeStandardInformation ibarcode = new Service.Impl.StandardBarcodeInformation();
        public string userDangNhap = string.Empty;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XtraReport (*.repx)|*.repx";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                txtDuongDanTem.Text = openFileDialog1.FileName;
            }
        }
        private void Insert_TemMoi()
        {
            if (!string.IsNullOrEmpty(txtDuongDanTem.Text))
            {
                if (MessageBox.Show("Thêm mới Tem ?", "Cấu hình tem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var i = ibarcode.Insert_ThongTinbarcode(userDangNhap, Environment.MachineName, ReadFile(txtDuongDanTem.Text)
                        , txtTenMauBarcode.Text, int.Parse(cboLoaiMauBarcode.SelectedValue.ToString()));
                    if (i > -1)
                    {
                        Load_DanhSach_Report();
                        txtDuongDanTem.Text = string.Empty;
                    }
                }
            }
        }
        private void Update_ThongTinTem()
        {
            if (dtgMauBarcode.CurrentRow != null)
            {
                if (MessageBox.Show("Cập nhật thông tin Tem ?", "Cấu hình tem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = int.Parse(dtgMauBarcode.CurrentRow.Cells[colMauarcode_ID.Name].Value.ToString());
                    var i = ibarcode.Update_ThongTinbarcode(id, txtTenMauBarcode.Text, int.Parse(cboLoaiMauBarcode.SelectedValue.ToString()), userDangNhap, Environment.MachineName);
                    if (i > -1)
                    {
                        if (!string.IsNullOrEmpty(txtDuongDanTem.Text))
                        {
                            ibarcode.Update_NoiDungTem(id, ReadFile(txtDuongDanTem.Text));
                        }
                        Load_DanhSach_Report();
                    }
                }
            }
        }
        private void XoaBarcode()
        {
            if (dtgMauBarcode.CurrentRow != null)
            {
                if (MessageBox.Show("Xóa thông tin Tem ?", "Cấu hình tem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = int.Parse(dtgMauBarcode.CurrentRow.Cells[colMauarcode_ID.Name].Value.ToString());
                    if (ibarcode.Delete_Report(id) > -1)
                        Load_DanhSach_Report();
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
        private void Load_DanhSach_Report()
        {
            dtgMauBarcode.CellEnter -= DtgMauBarcode_CellEnter;
            var data = ibarcode.Data_DanhSachThongTin(string.Empty);
            var bs = new BindingSource();
            bs.DataSource = data;
            dtgMauBarcode.AutoGenerateColumns = false;
            bvMauBarcode.BindingSource = bs;
            dtgMauBarcode.DataSource = bs;
            dtgMauBarcode.CellEnter += DtgMauBarcode_CellEnter; ;
            BindThongTinMau();
            Load_DanhSach_MayTinh();
        }
        private void Load_DanhSach_MayTinh()
        {
            if(dtgMauBarcode.CurrentRow != null)
            {
                var id = int.Parse(dtgMauBarcode.CurrentRow.Cells[colMauarcode_ID.Name].Value.ToString());
                var data = ibarcode.Data_TemBarcode_MayTinh(id, txtTimMayTinh.Text);
                var bs = new BindingSource();
                bs.DataSource = data;
                dtgDanhSach.AutoGenerateColumns = false;
                bvDanhSach.BindingSource = bs;
                dtgDanhSach.DataSource = bs;
            }
        }
        private void DtgMauBarcode_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            BindThongTinMau();
            Load_DanhSach_MayTinh(); 
        }
        private void BindThongTinMau()
        {
            txtTenMauBarcode.Text = string.Empty;
            txtDuongDanTem.Text = string.Empty;
            if (dtgMauBarcode.CurrentRow != null)
            {
                txtTenMauBarcode.Text = dtgMauBarcode.CurrentRow.Cells[colMauarcode_TenMau.Name].Value.ToString();
                cboLoaiMauBarcode.SelectedValue = int.Parse(dtgMauBarcode.CurrentRow.Cells[colMauBarcode_LoaiBarcode.Name].Value.ToString());
            }
        }
        private void Load_DanhSachLoaibarcode()
        {
            var data = Loaibarcode.ListLoaibarcode();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            cboLoaiMauBarcode.DataSource = bs;
            cboLoaiMauBarcode.ValueMember = "IdLoaiBarcode";
            cboLoaiMauBarcode.DisplayMember = "TenLoaiBarcode";
        }
  
        private void Clear_ThongTinMayTinh()
        {
            txtMayTinh.Text = string.Empty;
            txtTenMayIn.Text = string.Empty;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Update_ThongTinTem();
        }

        private void btnXoaTem_Click(object sender, EventArgs e)
        {
            XoaBarcode();
        }

        private void btnDownloadTem_Click(object sender, EventArgs e)
        {
            if (dtgMauBarcode.CurrentRow != null)
            {
                if (MessageBox.Show("Download Tem ?", "Cấu hình tem", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = int.Parse(dtgMauBarcode.CurrentRow.Cells[colMauarcode_ID.Name].Value.ToString());
                    var data = ibarcode.Data_DanhSachThongTin(id.ToString());
                    if (data.Rows.Count > 0)
                    {
                        var dataByte = (byte[])(data.Rows[0]["NoiDungTem"] == DBNull.Value ? null : data.Rows[0]["NoiDungTem"]);
                        var saDiag = new SaveFileDialog();
                        saDiag.FileName = string.Format("Tembarcode_{0}", id.ToString());
                        saDiag.Filter = "XtraReport (*.repx)|*.repx";
                        saDiag.DefaultExt = "repx";
                        saDiag.ShowDialog();
                        if (!string.IsNullOrEmpty(saDiag.FileName))
                        {
                            ByteArrayToFile(saDiag.FileName, dataByte);
                            MessageBox.Show("Download hoàn tất!");
                        }
                    }
                }
            }
        }

        private void btnThemTem_Click(object sender, EventArgs e)
        {
            Insert_TemMoi();
        }

        private void FrmQuanLyBarcode_Load(object sender, EventArgs e)
        {
            Load_DanhSachLoaibarcode();
            Load_DanhSach_Report();
            txtMayTinh.Text = Environment.MachineName;
        }

        private void txtTimMayTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                Load_DanhSach_MayTinh();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            Load_DanhSach_MayTinh();
        }

        private void btnThemMayTinh_Click(object sender, EventArgs e)
        {
            if (dtgMauBarcode.CurrentRow != null)
            {
                if (!string.IsNullOrEmpty(txtMayTinh.Text) && !string.IsNullOrEmpty(txtTenMayIn.Text))
                {
                    var id = int.Parse(dtgMauBarcode.CurrentRow.Cells[colMauarcode_ID.Name].Value.ToString());
                    ibarcode.Insert_TemBarcode_MayTinh(id, txtMayTinh.Text, txtTenMayIn.Text, userDangNhap, Environment.MachineName);
                    Clear_ThongTinMayTinh();
                    Load_DanhSach_MayTinh();
                    bvDanhSach.BindingSource.Position = bvDanhSach.BindingSource.Find("TenMayTinh", txtMayTinh.Text);
                }
            }
        }

        private void dtgDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == colTenMayIn.Index)
                {
                    var id = int.Parse(dtgDanhSach.CurrentRow.Cells[colId.Name].Value.ToString());
                    var tenMayTinh = dtgDanhSach.CurrentRow.Cells[colTenMayTinh.Name].Value.ToString();
                    var tenMayin = dtgDanhSach.CurrentRow.Cells[colTenMayIn.Name].Value.ToString();
                    ibarcode.Update_TemBarcode_MayTinh(id, tenMayTinh, tenMayin, userDangNhap, Environment.MachineName);
                    dtgDanhSach.CurrentRow.Cells[colNguoiSua.Name].Value = userDangNhap;
                    dtgDanhSach.CurrentRow.Cells[colPcSua.Name].Value = Environment.MachineName;
                    dtgDanhSach.CurrentRow.Cells[colTgSua.Name].Value = DateTime.Now;
                }
            }
        }

        private void btnXoaMayTinh_Click(object sender, EventArgs e)
        {
            if(dtgDanhSach.CurrentRow != null)
            {
                if (MessageBox.Show("Xóa thông tin máy tính đang chọn?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var id = int.Parse(dtgDanhSach.CurrentRow.Cells[colId.Name].Value.ToString());
                    var tenMayTinh = dtgDanhSach.CurrentRow.Cells[colTenMayTinh.Name].Value.ToString();
                    ibarcode.Delete_TemBarcode_MayTinh(id, tenMayTinh);
                    Load_DanhSach_MayTinh();
                }
            }
        }

        private void txtMayTinh_Enter(object sender, EventArgs e)
        {
            txtMayTinh.SelectAll();
        }

        private void txtMayTinh_Click(object sender, EventArgs e)
        {
            txtMayTinh.SelectAll();
        }
    }
}
