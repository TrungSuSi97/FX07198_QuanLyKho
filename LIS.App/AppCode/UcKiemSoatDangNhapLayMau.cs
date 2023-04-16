using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.ThucThi;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.AppCode
{
    public partial class UcKiemSoatDangNhapLayMau : UserControl
    {
        public UcKiemSoatDangNhapLayMau()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        public string SetMaKhuLayMau
        {
            set {
                cboKhuLayMau.SelectedValue = value;
            }
        }
        public bool Lock_KhuLayMau
        {
            set
            {
                cboKhuLayMau.Enabled = !value;
            }
            get
            {
                return !cboKhuLayMau.Enabled;
            }
        }
        public bool ChoPhepUserDangNhapNhieuBan = false;
        public void Load_DataKhuLayMau(DataTable dmKhuLayMau)
        {
            cboKhuLayMau.DataSource = dmKhuLayMau;
            cboKhuLayMau.ValueMember = "IDKhulayMau";
            cboKhuLayMau.DisplayMember = "TenKhuLayMau";
            cboKhuLayMau.SelectedIndex = -1;
            cboKhuLayMau.SelectedIndexChanged += CboKhuLayMau_SelectedIndexChanged;
        }

        private void CboKhuLayMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhSach();
           
        }

        public void AddBan()
        {
            var lst = LstBanDaDangKy();
            int soBan = 200;
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));

            var dataRow = dt.NewRow();
            for (int i = 1; i <= soBan; i++)
            {
                if (!lst.Contains(i.ToString()))
                {
                    dataRow = dt.NewRow();
                    dataRow["id"] = i;
                    dt.Rows.Add(dataRow);
                }
            }
            cboChonBan.DataSource = dt;
            cboChonBan.DisplayMember = "ID";
            cboChonBan.ValueMember = "ID";
        }
        private List<string> LstBanDaDangKy()
        {
            var lst = new List<string>();
            if(dtgDSDangKy.RowCount >0)
            {
                for (int i = 0; i < dtgDSDangKy.RowCount; i++)
                {
                    var tamDung = bool.Parse(dtgDSDangKy[colTamDungVal.Name, i].Value.ToString());
                    lst.Add(dtgDSDangKy[colSoBan.Name, i].Value.ToString());
                    dtgDSDangKy[colDangXuat.Name, i].Value = GraphicSupport.ImageToByteArray(imageList1.Images[0]);
                    dtgDSDangKy[colTamDung.Name, i].Value = GraphicSupport.ImageToByteArray((tamDung? imageList1.Images[2]: imageList1.Images[3]));
                }
            }
            return lst;
        }
        public void Load_DanhSach()
        {
            dtgDSDangKy.DataSource = null;
            if (cboKhuLayMau.SelectedIndex > -1)
            {
                objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau(cboKhuLayMau.SelectedValue.ToString());
                var data = _iPatient.DanhSach_LayMau_DaDangKySoBan(string.Empty, -1, cboKhuLayMau.SelectedValue.ToString(), true);
                ControlExtension.BindDataToGrid(data, ref dtgDSDangKy, ref bvDSDangKy);
                ChoPhepUserDangNhapNhieuBan = objKhuLayMau.UserLayMauNhieuBan;
                AddBan();
            }
        }
        private bool Add_PhienDangnhap(int soBan, string maNguoiDung)
        {
            if (cboKhuLayMau.SelectedIndex > -1)
            {
                var allow = false;
                //Kiểm tra user chưa đăng ký
                var dataNV = _iPatient.DanhSach_LayMau_DaDangKySoBan(maNguoiDung, -1, string.Empty, true);
                var dataBan = _iPatient.DanhSach_LayMau_DaDangKySoBan(string.Empty, soBan, cboKhuLayMau.SelectedValue.ToString(), true);
                if (dataNV.Rows.Count > 0 && !ChoPhepUserDangNhapNhieuBan)
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("User đang trong phiên làm việc khác:\nBàn:{0} - Khu lấy mẫu: {1}\nNgày đăng ký:{2}"
                        , dataNV.Rows[0]["BanDangKy"].ToString(), dataNV.Rows[0]["MaKhuLayMau"].ToString(), DateTime.Parse(dataNV.Rows[0]["TGDangNhap"].ToString()).ToString("dd/MM/yyyy")));
                    return false;
                }
                else if (dataBan.Rows.Count > 0)
                {
                    //kiểm tra bàn chưa đang ký.
                    CustomMessageBox.MSG_Information_OK(string.Format("Bàn đang đăng ký trong phiên làm việc khác:\nBàn:{0} - Khu lấy mẫu: {1}\nNgày đăng ký:{2}"
                          , dataNV.Rows[0]["BanDangKy"].ToString(), dataNV.Rows[0]["MaKhuLayMau"].ToString(), DateTime.Parse(dataNV.Rows[0]["TGDangNhap"].ToString()).ToString("dd/MM/yyyy")));
                    return false;
                }
                else
                {
                    return _iPatient.Insert_LayMauDangKyBan(maNguoiDung, soBan, cboKhuLayMau.SelectedValue.ToString(), Environment.MachineName);
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn khu lấy mẫu.");
            }
            return false;
        }
        private void btnThemCaMoi_Click(object sender, EventArgs e)
        {
            if (cboChonBan.SelectedIndex > -1)
            {
                var f = new frmIdentify();
                f.ShowDialog();
                if (f.Accepted)
                {
                    var maNguoiDung = f.UserID;
                    f.Dispose();
                    //Check user dang đăgn nhap
                    
                    //Thực hiện add
                    Add_PhienDangnhap(int.Parse(cboChonBan.Text), maNguoiDung);
                    Load_DanhSach();
                    bvDSDangKy.BindingSource.Position = bvDSDangKy.BindingSource.Find("MaNguoiDung", maNguoiDung);
                }
            }
        }

        private void dtgDSDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnLoadDanhSach_Click(object sender, EventArgs e)
        {
            Load_DanhSach();
        }

        private void dtgDSDangKy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == colDangXuat.Index)
                {
                    var maNguoiDung = dtgDSDangKy[colMaNguoiDung.Name, e.RowIndex].Value.ToString();
                    var tenNguoiDung = dtgDSDangKy[colTenNhanVien.Name, e.RowIndex].Value.ToString();
                    var maBan = dtgDSDangKy[colSoBan.Name, e.RowIndex].Value.ToString();
                    var maKhuLayMau = dtgDSDangKy[colKhulayMau.Name, e.RowIndex].Value.ToString();
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Đăng xuất phiên làm việc?\n{0}-{1} - Bàn: {2}", maNguoiDung, tenNguoiDung, maBan)))
                    {
                        _iPatient.Update_LayMauLogOut(maNguoiDung,int.Parse(maBan), maKhuLayMau, Environment.MachineName);
                        dtpNgayLamViec.Focus();
                        Load_DanhSach();
                    }
                }
                else if (e.ColumnIndex == colTamDung.Index)
                {
                    var maBan = dtgDSDangKy[colSoBan.Name, e.RowIndex].Value.ToString();
                    var maNguoiDung = dtgDSDangKy[colMaNguoiDung.Name, e.RowIndex].Value.ToString();
                    var tenNguoiDung = dtgDSDangKy[colTenNhanVien.Name, e.RowIndex].Value.ToString();
                    var tamDung = bool.Parse(dtgDSDangKy[colTamDungVal.Name, e.RowIndex].Value.ToString());
                    var maKhuLayMau = dtgDSDangKy[colKhulayMau.Name, e.RowIndex].Value.ToString();
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("{3} cấp số cho bàn:{0}?\n{1}-{2}", maBan, maNguoiDung, tenNguoiDung, (tamDung ? "Tiếp tục" : "Tạm dừng"))))
                    {
                        _iPatient.Update_LayMauTamDung(maNguoiDung, int.Parse(maBan), maKhuLayMau, !tamDung);
                        dtpNgayLamViec.Focus();
                        Load_DanhSach();
                    }
                }
            }
        }

        private void btnstCapSoBan_Click(object sender, EventArgs e)
        {
            if (cboKhuLayMau.SelectedIndex > -1)
            {
                var data = _iPatient.LayMau_LaySoBan(cboKhuLayMau.SelectedValue.ToString());
                if(data !=null)
                {
                    if(data.Rows.Count >0)
                    {
                        var soBan = data.Rows[0]["SoBanKeTiep"].ToString();
                        var taiKhoan = data.Rows[0]["MaNguoiDung"].ToString();
                        MessageBox.Show(string.Format("Bàn kế tiếp:{0}\nUser: {1}", soBan, taiKhoan));
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Chưa có bàn đăng ký lấy mẫu.");
                    }
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn khu lấy mẫu.");
            }
        }

        private void dtpNgayLamViec_ValueChanged(object sender, EventArgs e)
        {
            if(cboKhuLayMau.SelectedIndex>-1)
            {
                Load_DanhSach();
            }
        }
    }
}
