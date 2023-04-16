using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;

namespace TPH.LIS.App.ThongKe
{
    public partial class frmThongKeTongHopXQuang : FrmTemplate
    {
        public frmThongKeTongHopXQuang()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        C_NhanVien nhanvien = new C_NhanVien();
        C_Patient pInfo = new C_Patient();
        C_Config config = new C_Config();
        
        private void frmThongKeTongHop_Load(object sender, EventArgs e)
        {
            nhanvien.Get_NhanVien(cboNhanVien);
            nhanvien.Get_NhanVien(cboNhanVienThucHien);
            sysConfig.Get_DoiTuongDichVu(cboDoiTuongDV, null);
            sysConfig.Get_DM_XQuang_KyThuat(cboNhomCLS);
            
            Load_ChiDinhCLS();
            dtpDateFrom.Value = DateTime.Now.AddDays(-30);
        }
        private void Load_ChiDinhCLS()
        {
            sysConfig.Get_DM_XQuang_VungChup(cboCLS_ChiDinh, (cboNhomCLS.SelectedIndex == -1 ? "" : " and MaKyThuatChup = '" + cboNhomCLS.SelectedValue.ToString().Trim() + "'"), "");
        }
        private void cboNhomCLS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Load_ChiDinhCLS();
        }

        //Qui ước : KetQua_CLS_XQuang : K - BenhNhan_TiepNhan : T - DichVu : D - NhanVien : N - NhanVienThucHien : TH - {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom : C
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
                    _condit += " and K.MaVungChup ='" + cboCLS_ChiDinh.SelectedValue.ToString().Trim() + "'\n";
            }

            //Nếu chọn nhóm
            if (cboNhomCLS.SelectedIndex != -1)
            {
                _condit += " and K.MaKyThuatChup = '" + cboNhomCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and Tx.UserInXQuang = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        //Lấy thống kê tổng số xét nghiệm

        private void TK_XQuangThucHien()
        {
            string _strSQL = "";
            _strSQL += " Select K.MaVungChup, vc.TenVungChup, K.MaKyThuatChup, C.TenKyThuatChup,C.ThuTuIn, Sum(GiaRieng) as TongTien, Count(k.MaVungChup) as SoLuong, cast(0 as bit) as IsCate \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup C on K.MaKyThuatChup = C.MaKyThuatChup \n";
            _strSQL += "  inner join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup vc on vc.MaVungChup = k.MaVungChup \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by K.MaVungChup, vc.TenVungChup, K.MaKyThuatChup, C.TenKyThuatChup,C.ThuTuIn \n";
            _strSQL += " order by C.ThuTuIn asc,K.MaVungChup asc";
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();

            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "TenKyThuatChup", "MaKyThuatChup", "TenVungChup", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult,ref dtgTongHopXQuang, ref bvTongHopXQuang);
        }

        //Lấy thống kê theo đối tượng dịch vụ

        private void ThongKeDoiTuongDichVu()
        {
            string _strSQL = "";
            _strSQL += " select D.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan \n";
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
            _strSQL += " select K.MaKyThuatChup, C.TenKyThuatChup, N.TenNhanVien, Tx.UserInXQuang , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInXQuang \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup C on K.MaKyThuatChup = C.MaKyThuatChup \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by N.TenNhanVien, Tx.UserInXQuang,K.MaKyThuatChup, C.TenKyThuatChup \n";
            _strSQL += " order by k.MaKyThuatChup, N.TenNhanVien asc";
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();

            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "TenKyThuatChup", "MaKyThuatChup", "TenNhanVien", "TongTien", "SoLuong");

            ControlExtension.BindDataToGrid(dtResult, ref dtgNguoiThucHien, ref bvNguoiThuchien);
        }
        private void btnTKTongHopXN_Click(object sender, EventArgs e)
        {
            dtgTongHopXQuang.Focus();
            TK_XQuangThucHien();
        }

        private void dtgTongHopXQuang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int _stt = 0;
            int _sttcate = 0;
            for (int i = 0; i < dtgTongHopXQuang.RowCount; i++)
            {

                if ((bool)dtgTongHopXQuang.Rows[i].Cells["iscate"].Value == true)
                {
                    _stt = 0;
                    _sttcate++;
                    dtgTongHopXQuang.Rows[i].Cells["No1"].Value = LabServices_Helper.LaySTT(_sttcate, 1);
                    dtgTongHopXQuang.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(130, 231, 255);
                    dtgTongHopXQuang.Rows[i].DefaultCellStyle.ForeColor = Color.DarkBlue;
                }
                else
                {
                    _stt++;
                    dtgTongHopXQuang.Rows[i].Cells["No1"].Value = _stt;
                }
            }
        }

        private void btnXuatTKXN_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgTongHopXQuang);
        }

        private void btnThongKeDoiTuongDV_Click(object sender, EventArgs e)
        {
            ThongKeDoiTuongDichVu();
        }

        private void btnXuatThongKeDoiTuongDV_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgDoiTuongDichVu);
        }

        private void btnTKNguoiThucHien_Click(object sender, EventArgs e)
        {
            ThongKeNguoiThucHien();
        }

        private void btnXuatNguoiThucHien_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgNguoiThucHien);
        }

        private void ThongKeBenhNhan()
        {
            string _strSQL = "";
            _strSQL += " select T.TenBN,T.Tuoi,T.DiaChi, Case when T.GioiTinh = 'M' then N'Nam' when T.GioiTinh = 'F' then N'Nữ' else N'?' end as GioiTinh, D.TenDoiTuongDichVu,N.TenNhanVien as BacSiCD, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaVungChup) as SoLuong,cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_XQuang tx on tx.MaTiepNhan = t.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN N on N.MaNhanVien = T.BacSiCD \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " group by T.MaTiepNhan,T.TenBN, T.Tuoi,T.DiaChi,D.TenDoiTuongDichVu,N.TenNhanVien,T.DoiTuongDichVu,T.GioiTinh\n";
            _strSQL += " order by  T.MaTiepNhan,T.TenBN, D.TenDoiTuongDichVu asc";
            DataTable dtResult = new DataTable();
            dtResult = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dtResult, ref dtgBenhNhan, ref bvBenhNhan);
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
            if (dtgBenhNhan.RowCount > 0)
            {
                for (int i = 0; i < dtgBenhNhan.RowCount; i++)
                {
                    dtgBenhNhan["No2", i].Value = (i + 1).ToString();
                }
            }
        }

        private void btnThongKeBN_Click(object sender, EventArgs e)
        {
            txtProfile.Focus();
            ThongKeBenhNhan();
        }

        private void ThongKeTH_Chitiet_BenhNhan()
        {
            string _strSQL = "";
            _strSQL += " select tx.UserInXQuang , Th.TenNhanVien as NguoiThucHien,T.MaTiepNhan, T.TenBN,T.Tuoi,T.DiaChi, Case when T.GioiTinh = 'M' then N'Nam' when T.GioiTinh = 'F' then N'Nữ' else N'?' end as GioiTinh, D.TenDoiTuongDichVu,N.TenNhanVien as BacSiCD, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaVungChup) as SoLuong,cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_XQuang tx on tx.MaTiepNhan = t.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN N on N.MaNhanVien = T.BacSiCD \n";
            _strSQL += " left join (select nd.MaNguoiDung,nv.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung nd inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nd.MaNhanVien = nv.MaNhanVien) as th on th.MaNguoiDung = tx.UserInXQuang ";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " and Tx.DaInKQXN = 1";
            _strSQL += " group by tx.UserInXQuang, Th.TenNhanVien, T.MaTiepNhan,T.TenBN, T.Tuoi,T.DiaChi,D.TenDoiTuongDichVu,N.TenNhanVien,T.DoiTuongDichVu,T.GioiTinh\n";
            _strSQL += " order by  tx.UserInXQuang, T.MaTiepNhan,T.TenBN, D.TenDoiTuongDichVu asc";
            DataTable dtResult = new DataTable();
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "NguoiThucHien", "UserInXQuang", "TenBN", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult, ref dtgChiTietBN, ref bvChiTietBN);
        }

        private void ThongKeTH_ChiTiet_ChiDinh()
        {
            string _strSQL = "";
            _strSQL += " Select tx.UserInXQuang , Th.TenNhanVien as NguoiThucHien,K.MaVungChup, VC.TenVungChup, K.MaKyThuatChup, C.TenKyThuatChup, Sum(GiaRieng) as TongTien, Count(MaVungCHup) as SoLuong, cast(0 as bit) as IsCate \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_XQuang tx on tx.MaTiepNhan = t.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup C on K.MaKyThuatChup = C.MaKyThuatChup \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on K.MaVungChup = VC.MaVungChup \n";
            _strSQL += " left join (select nd.MaNguoiDung,nv.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung nd inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nd.MaNhanVien = nv.MaNhanVien) as th on th.MaNguoiDung = tx.UserInXQuang ";
            //Ghép với điều kiện
            _strSQL += Get_Condit();
            _strSQL += " and Tx.DaInKQXN = 1 \n";
            _strSQL += " group by tx.UserInXQuang, Th.TenNhanVien, K.MaVungChup, VC.TenVungChup, K.MaKyThuatChup, C.TenKyThuatChup \n";
            _strSQL += " order by tx.UserInXQuang, K.MaKyThuatChup,  K.MaVungChup asc";
            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();
            dtResult = dtTemp.Clone();

            LabServices_Helper.TachNhom_Datatable(dtTemp, ref dtResult, "NguoiThucHien", "UserInXQuang", "TenVungChup", "TongTien", "SoLuong");
            ControlExtension.BindDataToGrid(dtResult, ref dtgChiTietChiDinh, ref bvChiTietChiDinh);
        }
    }
}
