using System;
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
    public partial class UcDangNhapLayMau : UserControl
    {
        public UcDangNhapLayMau()
        {
            InitializeComponent();
            colDangXuat.DefaultCellStyle.NullValue = null;
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
        public void Load_DanhSach()
        {
            dtgDSDangKy.DataSource = null;
            if (cboKhuLayMau.SelectedIndex > -1)
            {
                objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau(cboKhuLayMau.SelectedValue.ToString());
                var data = _iPatient.DanhSach_LayMau_DangNhap(cboKhuLayMau.SelectedValue.ToString());
                if (data.Rows.Count > 0)
                {
                    if (!data.Columns.Contains("imgLogOut"))
                        data.Columns.Add("imgLogOut", typeof(byte[]));
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        data.Rows[i]["imgLogOut"] = GraphicSupport.ImageToByteArray(imageList1.Images[0]);
                    }
                }
                ControlExtension.BindDataToGrid(data, ref dtgDSDangKy, ref bvDSDangKy);
                ChoPhepUserDangNhapNhieuBan = objKhuLayMau.UserLayMauNhieuBan;

               
            }
        }
        private bool Add_PhienDangnhap(string maNguoiDung)
        {
            if (cboKhuLayMau.SelectedIndex > -1)
            {
                var allow = false;
                //Kiểm tra user chưa đăng ký
                var dataBan = _iPatient.DanhSach_LayMau_DangNhap(cboKhuLayMau.SelectedValue.ToString());
                var dataSearch = WorkingServices.SearchResult_OnDatatable(dataBan, string.Format("MaNguoiDung = '{0}'", maNguoiDung));
                if (dataSearch.Rows.Count > 0 && !ChoPhepUserDangNhapNhieuBan)
                {
                    CustomMessageBox.MSG_Information_OK(string.Format("User đang trong phiên làm việc khác:Khu lấy mẫu: {0}\nNgày đăng ký:{1}"
                        , dataSearch.Rows[0]["MaKhuLayMau"].ToString(), DateTime.Parse(dataSearch.Rows[0]["TGDangNhap"].ToString()).ToString("dd/MM/yyyy")));
                    return false;
                }
                else
                {
                    return _iPatient.Insert_LayMauThuCong_DangNhap(maNguoiDung, cboKhuLayMau.SelectedValue.ToString());
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
            if (cboKhuLayMau.SelectedIndex > -1)
            {
                var f = new frmIdentify();
                f.ShowDialog();
                if (f.Accepted)
                {
                    var maNguoiDung = f.UserID;
                    f.Dispose();
                    //Check user dang đăgn nhap
                    
                    //Thực hiện add
                    Add_PhienDangnhap(maNguoiDung);
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
                    var maKhuLayMau = dtgDSDangKy[colKhulayMau.Name, e.RowIndex].Value.ToString();
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Đăng xuất phiên làm việc?\n{0}-{1}", maNguoiDung, tenNguoiDung)))
                    {
                        _iPatient.Update_LayMauThuCong_LogOut(int.Parse(dtgDSDangKy[colIDDangNhap.Name, e.RowIndex].Value.ToString()));
                        Load_DanhSach();
                    }
                }
            }
        }
    }
}
