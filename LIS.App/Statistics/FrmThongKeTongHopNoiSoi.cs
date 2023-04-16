using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.ThongKe
{
    public partial class FrmThongKeTongHopNoiSoi : FrmTemplate
    {
        public FrmThongKeTongHopNoiSoi()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        C_NhanVien nhanvien = new C_NhanVien();
        C_Patient pInfo = new C_Patient();
        C_Config config = new C_Config();
        C_NguoiDung user = new C_NguoiDung();
        
        //Qui ước : KetQua_CLS_NoiSoi : K - BenhNhan_TiepNhan : T - DichVu : D - NhanVien : N - NhanVienThucHien : TH - DM_NhomCLS_NS : C
        //K và T luôn join với nhau, thời gian luôn được chọn
        /// <summary>
        /// Lấy điều kiện thống kê
        /// </summary>
        /// <returns>Trả về chuỗi điều kiện bắt đầu từ where</returns>
        private string Get_Condit()
        {
            string _condit = "";
            //đều kiện where ảo
            _condit += " where 1=1 \n";
            //Lấy thời gian intime
            _condit += " and T.ThoiGianNhap between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' \n";

            //Kiểm tra điều kiện giá
            if (radHavePrice.Checked)
            {
                _condit += " and K.GiaRieng > 0\n";
            }
            else if (radNoPrice.Checked)
            {
                _condit += " and K.GiaRieng = 0\n";
            }

            //Nếu lấy theo chỉ định
            if (cboCLS_ChiDinh.SelectedIndex != -1)
            {

                //Ngược lại thì lấy theo XN được chọn
                _condit += " and K.MaSoMauNoiSoi ='" + cboCLS_ChiDinh.SelectedValue.ToString().Trim() + "'\n";
            }

            //Nếu chọn nhóm
            if (cboNhomCLS.SelectedIndex != -1)
            {
                _condit += " and K.MaNhomNoiSoi = '" + cboNhomCLS.SelectedValue.ToString().Trim() + "'\n";
            }

            //Nếu có lấy đối tượng dịch vụ thì kiểm tra
            if (cboDoiTuongDV.SelectedIndex != -1)
            {
                _condit += " and T.DoiTuongDichVu = '" + cboDoiTuongDV.SelectedValue.ToString().Trim() + "'\n";
            }

            //Nếu có lấy theo nhân viên
            if (cboNhanVien.SelectedIndex != -1)
            {
                _condit += " and T.BacSiCD = '" + cboNhanVien.SelectedValue.ToString().Trim() + "'\n";
            }

            //Nếu có lấy theo nhân viên thực hiện
            if (cboNhanVienThucHien.SelectedIndex != -1)
            {
                _condit += " and K.NguoiKy = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }
            if (radisPrint.Checked)
            {
                _condit += " and K.DaInKQ = 1";
            }
            else if (radNotPrint.Checked)
            {
                _condit += " and K.DaInKQ = 0";
            }
            return _condit;
        }
        private void btnTKTongHopXN_Click(object sender, EventArgs e)
        {
            txtTenNhomCLS.Focus();
            TK_NoiSoiThucHien();
        
        }

        //Lấy thống kê theo đối tượng dịch vụ

        private void ThongKeDoiTuongDichVu()
        {
            string _strSQL = "";
            _strSQL += " select D.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join BenhNhan_CLS_NoiSoi Tx on t.MaTiepNhan = tx.MaTiepNhan\n inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by D.TenDoiTuongDichVu, T.DoiTuongDichVu \n";
            _strSQL += " order by D.TenDoiTuongDichVu asc";
            DataTable dtResult = new DataTable();
            dtResult = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dtResult, ref dtgDoiTuongDichVu, ref bvDoiTuongDichVu);
        }

        //Lấy thống kê theo người thực hiện

        private void ThongKeNguoiThucHien()
        {
            string _strSQL = "";
            _strSQL += " select isnull(N.TenNhanVien, N'Chưa in') as TenNhanVien , isnull(Tx.UserInNoiSoi,'None') as UserInNoiSoi ,K.MaNhomNoiSoi, C.TenNhomNoiSoi,  Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, cast(0 as bit) as IsCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = tx.MaTiepNhan\n \n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = K.NguoiKy \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi C on K.MaNhomNoiSoi = C.MaNhomNoiSoi \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by N.TenNhanVien, Tx.UserInNoiSoi,K.MaNhomNoiSoi, C.TenNhomNoiSoi \n";
            _strSQL += " order by K.MaNhomNoiSoi,N.TenNhanVien asc";
            DataTable dtResult = new DataTable(), dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "TenNhomNoiSoi", "MaNhomNoiSoi", "TenNhanVien", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult, ref dtgNguoiThucHien, ref bvNguoiThuchien);
        }

        //Lấy thống kê tổng số xét nghiệm

        private void TK_NoiSoiThucHien()
        {
            string _strSQL = "";
            _strSQL += " Select K.MaSoMauNoiSoi, K.TenMauNoiSoi, K.MaNhomNoiSoi, C.TenNhomNoiSoi, Sum(GiaRieng) as TongTien, Count(MaSoMauNoiSoi) as SoLuong, cast(0 as bit) as IsCate \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join BenhNhan_CLS_NoiSoi Tx on t.MaTiepNhan = tx.MaTiepNhan\n inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi C on K.MaNhomNoiSoi = C.MaNhomNoiSoi \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by K.MaSoMauNoiSoi, K.TenMauNoiSoi, K.MaNhomNoiSoi, C.TenNhomNoiSoi \n";
            _strSQL += " order by  c.TenNhomNoiSoi, k.MaNhomNoiSoi,K.TenMauNoiSoi,  K.MaSoMauNoiSoi asc";
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();
            dtResult = dtTemp.Clone();

            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "TenNhomNoiSoi", "MaNhomNoiSoi", "TenMauNoiSoi", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult, ref dtgTongHopNoiSoi, ref bvTongHopNoiSoi);
        }

        private void FrmThongKeTongHopNS_Load(object sender, EventArgs e)
        {
            C_NhanVien nhanvien = new C_NhanVien();
            nhanvien.Get_NhanVien(cboNhanVien);
           // data.Get_NhanVien(cboNhanVienThucHien);
            user.Get_UserList(cboNhanVienThucHien, " and d.MaNguoiDung not in ('admin') and d.BoPhan in ('2','a')");
            sysConfig.Get_DoiTuongDichVu(cboDoiTuongDV, null);
            sysConfig.Get_NhomCLS_NoiSoi(cboNhomCLS, "");
            Get_ChiDinhCLS();

            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28, 0, 0, 0);
            dtpDateFrom.Value = date.AddMonths(-1);
            
        }

        private void Get_ChiDinhCLS()
        {
            sysConfig.Get_DMNoiSoi(cboCLS_ChiDinh, (cboNhomCLS.SelectedIndex == -1 ? "" : " and MaNhomNoiSoi = '" + cboNhomCLS.SelectedValue.ToString().Trim() + "'"), "");
        }

        private void cboNhomCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Get_ChiDinhCLS();
        }

        private void dtgTongHopNoiSoi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgTongHopNoiSoi);
        }

        private void btnXuatTKNS_Click(object sender, EventArgs e)
        {
            if (dtgTongHopNoiSoi.RowCount > 0)
            {
               Excel.ExportToExcel.Export(dtgTongHopNoiSoi);
            }
        }

        private void btnThongKeDoiTuongDV_Click(object sender, EventArgs e)
        {
            txtTenNhomCLS.Focus();
            ThongKeDoiTuongDichVu();
        }

        private void btnTKNguoiThucHien_Click(object sender, EventArgs e)
        {
            txtTenNhomCLS.Focus();
            ThongKeNguoiThucHien();
        }

        private void btnXuatThongKeDoiTuongDV_Click(object sender, EventArgs e)
        {
            if (dtgDoiTuongDichVu.RowCount > 0)
            {
               Excel.ExportToExcel.Export(dtgDoiTuongDichVu);
            }
        }

        private void btnXuatNguoiThucHien_Click(object sender, EventArgs e)
        {
            if (dtgNguoiThucHien.RowCount > 0)
            {
               Excel.ExportToExcel.Export(dtgNguoiThucHien);
            }
        }

        private void btnThongKeBN_Click(object sender, EventArgs e)
        {
            txtTenNhomCLS.Focus();
            ThongKeBenhNhan();
        }
        private void ThongKeBenhNhan()
        {
            string _strSQL = "";
            _strSQL += " select T.TenBN,T.Tuoi,T.DiaChi, Th.TenNhanVien as BSThucHien,t.ThoiGianNhap as NgayTiepNhan, Case when T.GioiTinh = 'M' then N'Nam' when T.GioiTinh = 'F' then N'Nữ' else N'?' end as GioiTinh, D.TenDoiTuongDichVu,N.TenNhanVien as BacSiCD, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaSoMauNoiSoi) as SoLuong,cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_NoiSoi tx on tx.MaTiepNhan = t.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN N on N.MaNhanVien = T.BacSiCD \n";
            _strSQL += " left join (select nd.MaNguoiDung,nv.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung nd inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nd.MaNhanVien = nv.MaNhanVien) as th on th.MaNguoiDung =  K.NguoiKy";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by T.MaTiepNhan,T.TenBN, T.Tuoi,T.DiaChi,D.TenDoiTuongDichVu,N.TenNhanVien,T.DoiTuongDichVu,T.GioiTinh, Th.TenNhanVien,t.ThoiGianNhap\n";
            _strSQL += " order by  T.MaTiepNhan,T.TenBN, D.TenDoiTuongDichVu asc";
            DataTable dtResult = new DataTable();
            dtResult = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dtResult, ref dtgBenhNhan, ref bvBenhNhan);
        }


        private void ThongKeTH_Chitiet_BenhNhan()
        {
            string _strSQL = "";
            _strSQL += " select K.NguoiKy as UserInNoiSoi , Th.TenNhanVien as NguoiThucHien,T.MaTiepNhan, T.TenBN,T.Tuoi,T.DiaChi, Case when T.GioiTinh = 'M' then N'Nam' when T.GioiTinh = 'F' then N'Nữ' else N'?' end as GioiTinh, D.TenDoiTuongDichVu,N.TenNhanVien as BacSiCD, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaSoMauNoiSoi) as SoLuong,cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_NoiSoi tx on tx.MaTiepNhan = t.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN N on N.MaNhanVien = T.BacSiCD \n";
            _strSQL += " left join (select nd.MaNguoiDung,nv.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung nd inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nd.MaNhanVien = nv.MaNhanVien) as th on th.MaNguoiDung =  K.NguoiKy ";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
           // _strSQL += " and Tx.DaInKQNoiSoi = 1";
            _strSQL += " group by K.NguoiKy, Th.TenNhanVien, T.MaTiepNhan,T.TenBN, T.Tuoi,T.DiaChi,D.TenDoiTuongDichVu,N.TenNhanVien,T.DoiTuongDichVu,T.GioiTinh\n";
            _strSQL += " order by  K.NguoiKy, T.MaTiepNhan,T.TenBN, D.TenDoiTuongDichVu asc";
            DataTable dtResult = new DataTable();
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "NguoiThucHien", "UserInNoiSoi", "TenBN", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult, ref dtgChiTietBN, ref bvChiTietBN);
        }

        private void ThongKeTH_ChiTiet_ChiDinh()
        {
            string _strSQL = "";
            _strSQL += " Select K.NguoiKy as UserInNoiSoi , Th.TenNhanVien as NguoiThucHien,K.MaSoMauNoiSoi, K.TenMauNoiSoi, K.MaNhomNoiSoi, C.TenNhomNoiSoi, Sum(GiaRieng) as TongTien, Count(MaSoMauNoiSoi) as SoLuong, cast(0 as bit) as IsCate \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_NoiSoi tx on tx.MaTiepNhan = t.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi C on K.MaNhomNoiSoi = C.MaNhomNoiSoi \n";
            _strSQL += " left join (select nd.MaNguoiDung,nv.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung nd inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nd.MaNhanVien = nv.MaNhanVien) as th on th.MaNguoiDung =  K.NguoiKy ";
            //Ghép với điều kiện
            _strSQL += Get_Condit();

            _strSQL += " group by K.NguoiKy, Th.TenNhanVien, K.MaSoMauNoiSoi, K.TenMauNoiSoi, K.MaNhomNoiSoi, C.TenNhomNoiSoi \n";
            _strSQL += " order by K.NguoiKy, K.TenMauNoiSoi,  K.MaSoMauNoiSoi asc";
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();
            dtResult = dtTemp.Clone();

            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "NguoiThucHien", "UserInNoiSoi", "TenMauNoiSoi", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult, ref dtgChiTietChiDinh, ref bvChiTietChiDinh);
        }

        private void btnExportTKBN_Click(object sender, EventArgs e)
        {
            if (dtgBenhNhan.RowCount > 0)
            {
               Excel.ExportToExcel.Export(dtgBenhNhan);
            }
        }

        private void dtgBenhNhan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgBenhNhan);
        }

        private void btnTKChiTietBN_Click(object sender, EventArgs e)
        {
            ThongKeTH_Chitiet_BenhNhan();
        }

        private void btnTKChiTietChiDinh_Click(object sender, EventArgs e)
        {
            ThongKeTH_ChiTiet_ChiDinh();
        }

        private void dtgChiTietBN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgChiTietBN);
        }

        private void dtgNguoiThucHien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgNguoiThucHien);
        }

        private void dtgChiTietChiDinh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgChiTietChiDinh);
        }

        private void btnXuatChiTietBN_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgChiTietBN);
        }

        private void btnXuatChiTietChiDinh_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgChiTietChiDinh);
        }
    }
}
