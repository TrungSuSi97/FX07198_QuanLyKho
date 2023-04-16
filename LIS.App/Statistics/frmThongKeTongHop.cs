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
    public partial class frmThongKeTongHop : FrmTemplate
    {
        public frmThongKeTongHop()
        {
            InitializeComponent();
        }

        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        C_Patient pInfo = new C_Patient();
        C_Config config = new C_Config();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        //Qui ước : KetQua_CLS_XetNghiem : K - BenhNhan_TiepNhan : T - DichVu : D - NhanVien : N - NhanVienThucHien : TH - {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom : C
        //K và T luôn join với nhau, thời gian luôn được chọn
        /// <summary>
        /// Lấy điều kiện thống kê
        /// </summary>
        /// <returns>Trả về chuỗi điều kiện bắt đầu từ where</returns>
        private string Get_Condit_XN()
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

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and Tx.UserInXN = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }

        //Qui ước : KetQua_CLS_SieuAm : K - BenhNhan_TiepNhan : T - DichVu : D - NhanVien : N - NhanVienThucHien : TH - DM_NhomCLS_SA : C
        //K và T luôn join với nhau, thời gian luôn được chọn
        /// <summary>
        /// Lấy điều kiện thống kê
        /// </summary>
        /// <returns>Trả về chuỗi điều kiện bắt đầu từ where</returns>
        private string Get_Condit_SieuAm()
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

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and Tx.UserInSieuAm = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        //Qui ước : KetQua_CLS_NoiSoi : K - BenhNhan_TiepNhan : T - DichVu : D - NhanVien : N - NhanVienThucHien : TH - DM_NhomCLS_NS : C
        //K và T luôn join với nhau, thời gian luôn được chọn
        /// <summary>
        /// Lấy điều kiện thống kê
        /// </summary>
        /// <returns>Trả về chuỗi điều kiện bắt đầu từ where</returns>
        private string Get_Condit_NoiSoi()
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

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and Tx.UserInNoiSoi = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }

        //Qui ước : KetQua_CLS_XQuang : K - BenhNhan_TiepNhan : T - DichVu : D - NhanVien : N - NhanVienThucHien : TH - DM_NhomCLS_XQuang : C
        //K và T luôn join với nhau, thời gian luôn được chọn
        /// <summary>
        /// Lấy điều kiện thống kê
        /// </summary>
        /// <returns>Trả về chuỗi điều kiện bắt đầu từ where</returns>
        private string Get_Condit_XQuang()
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

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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

        private string Get_Condit_DVKhac()
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

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and Tx.UserInKhac = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        private string Get_Condit_Thuoc()
        {
            string _condit = "";
            //đều kiện where ảo
            _condit += " where 1=1 \n";
            //Lấy thời gian intime
            _condit += " and T.ThoiGianNhap between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' \n";

            //Kiểm tra điều kiện giá
            if (radHavePrice.Checked)
            {
                _condit += " and K.DonGia > 0\n";
            }
            else if (radNoPrice.Checked)
            {
                _condit += " and K.DonGia = 0\n";
            }

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and T.UserNhap = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        private string Get_Condit_Thuoc_Without_DVCLS()
        {
            string _condit = "";
            //đều kiện where ảo
            _condit += " where 1=1 \n";
            //Lấy thời gian intime
            _condit += " and T.ThoiGianNhap between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' \n";

            //Kiểm tra điều kiện giá
            if (radHavePrice.Checked)
            {
                _condit += " and K.DonGia > 0\n";
            }
            else if (radNoPrice.Checked)
            {
                _condit += " and K.DonGia = 0\n";
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
                _condit += " and T.UserNhap = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        private string Get_Condit_XuatKho_Thuoc_Without_DVCLS()
        {
            string _condit = "";
            //đều kiện where ảo
            _condit += " where 1=1 \n";
            //Lấy thời gian intime
            _condit += " and T.ThoiGianNhap between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' \n";

            //Kiểm tra điều kiện giá
            if (radHavePrice.Checked)
            {
                _condit += " and K.DonGia > 0\n";
            }
            else if (radNoPrice.Checked)
            {
                _condit += " and K.DonGia = 0\n";
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
                _condit += " and p.NguoiNhap = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        private string Get_Condit_DVKhamBenh()
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

            //Nếu chọn nhóm
            if (cboDichVuCLS.SelectedIndex != -1)
            {
                _condit += " and D.MaPhanLoai = '" + cboDichVuCLS.SelectedValue.ToString().Trim() + "'\n";
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
                _condit += " and Tx.UserIn = '" + cboNhanVienThucHien.SelectedValue.ToString().Trim() + "'\n";
            }

            return _condit;
        }
        private void TK_TongHopThucHien()
        {
            string _strSQL = " select * from (\n";
            _strSQL += " Select  K.MaNhomCLS as MaNhom, C.TenNhomCLS as TenNhom, Sum(GiaRieng) as TongTien, cast(Count(MaXN)  as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XetNghiem K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan  \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom C on K.MaNHomCLS = C.MaNhomCLS \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_XN();
            _strSQL += " group by K.MaNhomCLS, C.TenNhomCLS, D.TenPhanLoai, k.MaPhanLoai \n";

            _strSQL += " Union all \n";

            _strSQL += " Select K.MaNhomSieuAm as MaNhom, C.TenNhomSieuAm as TenNhom, Sum(GiaRieng) as TongTien, cast(Count(MaSoMau) as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu, k.MaPhanLoai as MaDichVu \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_SieuAm K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_SieuAm tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm C on K.MaNhomSieuAm = C.MaNhomSieuAm \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_SieuAm();
            _strSQL += " group by K.MaNhomSieuAm, C.TenNhomSieuAm, D.TenPhanLoai, k.MaPhanLoai \n";
            //Thống kê nội soi
            _strSQL += " Union all \n";
            _strSQL += " Select K.MaNhomNoiSoi as MaNhom, C.TenNhomNoiSoi as TenNhom, Sum(GiaRieng) as TongTien, cast(Count(MaSoMauNoiSoi) as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu, k.MaPhanLoai as MaDichVu \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi C on K.MaNhomNoiSoi = C.MaNhomNoiSoi \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_NoiSoi();
            _strSQL += " group by K.MaNhomNoiSoi, C.TenNhomNoiSoi, D.TenPhanLoai, k.MaPhanLoai \n";
           
            //XQuang 
            _strSQL += " Union all \n";
            _strSQL += " Select  K.MaKyThuatChup as MaNhom, C.TenKyThuatChup as TenNhom, Sum(GiaRieng) as TongTien, cast(Count(MaVungChup)  as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup C on K.MaKyThuatChup = C.MaKyThuatChup \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_XQuang();
            _strSQL += " group by K.MaKyThuatChup, C.TenKyThuatChup, D.TenPhanLoai, k.MaPhanLoai \n";

            //DV Kham benh
            _strSQL += " Union all \n";
            _strSQL += " Select K.MaNhomDichVu as MaNhom, C.TenNhomDichVu as TenNhom, Sum(GiaRieng) as TongTien, cast(Count(MaYeuCau) as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu, k.MaPhanLoai as MaDichVu \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KhamBenh_KetQua  K on T.MaTiepNhan = K.MaTiepNhan inner join KhamBenh_BenhNhan tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu C on K.MaNhomDichVu = C.MaNhomDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_DVKhamBenh();
            _strSQL += " group by K.MaNhomDichVu, C.TenNhomDichVu, D.TenPhanLoai, k.MaPhanLoai \n";

            //DV Khác
            _strSQL += " Union all \n";
            _strSQL += " Select K.MaNhomCLS as MaNhom, C.TenNhomCLS as TenNhom, Sum(GiaRieng) as TongTien, cast(Count(MaDVKhac) as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu, k.MaPhanLoai as MaDichVu \n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_DVKhac K on T.MaTiepNhan = K.MaTiepNhan inner join CLS_BenhNhan_DVKhac tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac C on K.MaNhomCLS = C.MaNhomCLS \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_DVKhac();
            _strSQL += " group by K.MaNhomCLS, C.TenNhomCLS, D.TenPhanLoai, k.MaPhanLoai \n";
            //Thống kê thuốc
            _strSQL += " Union all \n";

            _strSQL += " Select  N.MaNhomThuoc as MaNhom, N.TenNhomThuoc as TenNhom, Sum(ThanhTien) as TongTien, cast(Count(MaThuoc)  as money)  as SoLuong, cast(0 as bit) as IsCate, D.TenPhanLoai as DichVu ,k.MaPhanLoai as MaDichVu\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join ThuPhi_Thuoc K on T.MaTiepNhan = K.MaTiepNhan ";
            _strSQL += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc G on K.MaGocThuoc = G.MaGocThuoc";
            _strSQL += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc N on N.MaNhomThuoc = G.MaNhomThuoc";
            _strSQL += "\n left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_Thuoc();
            _strSQL += " group by N.MaNhomThuoc, N.TenNhomThuoc, D.TenPhanLoai, k.MaPhanLoai \n";
            _strSQL += " ) as A\n";

            _strSQL += " order by a.MaDichVu asc ,a.MaNhom";

            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();
            dtResult = dtTemp.Clone();

            string _MaDichVu = "";
            int _inCate = 0;
            double _TongThucHien = 0;
            double _TongTien = 0;

            if (dtTemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    DataRow dr = dtResult.NewRow();
                    if (_MaDichVu != dtTemp.Rows[i]["MaDichVu"].ToString().TrimEnd().ToLower())
                    {
                        if (dtResult.Rows.Count > 0)
                        {
                            dtResult.Rows[_inCate]["TongTien"] = _TongTien.ToString("N3");
                            dtResult.Rows[_inCate]["SoLuong"] = _TongThucHien.ToString("N0");
                        }
                        _MaDichVu = dtTemp.Rows[i]["MaDichVu"].ToString().TrimEnd().ToLower();
                        dr["TenNhom"] = dtTemp.Rows[i]["DichVu"].ToString().TrimEnd();
                        dr["iscate"] = true;
                        dtResult.Rows.Add(dr);
                        _inCate = dtResult.Rows.Count - 1;

                        dr = dtResult.NewRow();
                        dr["MaNhom"] = dtTemp.Rows[i]["MaNhom"].ToString().TrimEnd();
                        dr["TenNhom"] = dtTemp.Rows[i]["TenNhom"].ToString().TrimEnd().ToUpper();
                        dr["SoLuong"] = dtTemp.Rows[i]["SoLuong"].ToString().TrimEnd();
                        dr["TongTien"] = dtTemp.Rows[i]["TongTien"].ToString().TrimEnd();
                        dr["iscate"] = false;
                        _TongThucHien = double.Parse(dtTemp.Rows[i]["SoLuong"].ToString());
                        _TongTien = double.Parse(dtTemp.Rows[i]["TongTien"].ToString());
                        dtResult.Rows.Add(dr);
                    }
                    else
                    {
                        dr["MaNhom"] = dtTemp.Rows[i]["MaNhom"].ToString().TrimEnd();
                        dr["TenNhom"] = dtTemp.Rows[i]["TenNhom"].ToString().TrimEnd();
                        dr["SoLuong"] = dtTemp.Rows[i]["SoLuong"].ToString().TrimEnd();
                        dr["TongTien"] = dtTemp.Rows[i]["TongTien"].ToString().TrimEnd();
                        dr["iscate"] = false;
                        _TongThucHien += double.Parse(dtTemp.Rows[i]["SoLuong"].ToString());
                        _TongTien += double.Parse(dtTemp.Rows[i]["TongTien"].ToString());
                        dtResult.Rows.Add(dr);
                    }

                }
                if (dtResult.Rows.Count > 0)
                {
                    dtResult.Rows[_inCate]["TongTien"] = _TongTien.ToString("N0");
                    dtResult.Rows[_inCate]["SoLuong"] = _TongThucHien.ToString("N0");
                }
            }
            ControlExtension.BindDataToGrid(dtResult, ref dtgTongHopThucHien, ref bvTongHopThuHien);
        }


        //Lấy thống kê theo đối tượng dịch vụ

        private void ThongKeDoiTuongDichVu()
        {
            string _strSQL = "select * from (\n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XetNghiem K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_XN();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai,k.MaPhanLoai \n";

            _strSQL += " Union all \n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_SieuAm K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_SieuAm tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_SieuAm();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai, k.MaPhanLoai \n";

            //Nội soi
            _strSQL += " Union all \n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_NoiSoi();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai, k.MaPhanLoai \n";

            //XQuang
            _strSQL += " Union all \n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_XQuang();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai, k.MaPhanLoai \n";
            //DV Khám bệnh
            _strSQL += " Union all \n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KhamBenh_KetQua K on T.MaTiepNhan = K.MaTiepNhan inner join KhamBenh_BenhNhan tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            _strSQL += Get_Condit_DVKhamBenh();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai, k.MaPhanLoai \n";
            //DV Khác
            _strSQL += " Union all \n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.GiaRieng) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_DVKhac K on T.MaTiepNhan = K.MaTiepNhan inner join CLS_BenhNhan_DVKhac tx on T.MaTiepNhan = tx.MaTiepNhan\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_DVKhac();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai, k.MaPhanLoai \n";

            //Thuốc
            _strSQL += " Union all \n";
            _strSQL += " select D1.TenDoiTuongDichVu, T.DoiTuongDichVu , Sum(K.ThanhTien) as TongTien, Count(distinct K.MaTiepNhan) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join ThuPhi_Thuoc K on T.MaTiepNhan = K.MaTiepNhan \n";
            _strSQL += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc G on K.MaGocThuoc = G.MaGocThuoc";
            _strSQL += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc N on N.MaNhomThuoc = G.MaNhomThuoc";
            _strSQL += "\n left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai";
            _strSQL += " \nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D1 on D1.MaDoiTuongDichVu = T.DoiTuongDichVu \n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_Thuoc();
            _strSQL += " group by D1.TenDoiTuongDichVu, T.DoiTuongDichVu,D.TenPhanLoai, k.MaPhanLoai \n";
            _strSQL += " ) as A\n";
            _strSQL += " order by A.MaDichVu, A.TenDoiTuongDichVu asc";


            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();
            dtResult = dtTemp.Clone();

            string _MaDichVu = "";
            int _inCate = 0;
            double _TongThucHien = 0;
            double _TongTien = 0;

            if (dtTemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    DataRow dr = dtResult.NewRow();
                    if (_MaDichVu != dtTemp.Rows[i]["MaDichVu"].ToString().TrimEnd().ToLower())
                    {
                        if (dtResult.Rows.Count > 0)
                        {
                            dtResult.Rows[_inCate]["TongTien"] = _TongTien.ToString("N3");
                            dtResult.Rows[_inCate]["SoLuong"] = _TongThucHien.ToString("N0");
                        }
                        _MaDichVu = dtTemp.Rows[i]["MaDichVu"].ToString().TrimEnd().ToLower();
                        dr["TenDoiTuongDichVu"] = dtTemp.Rows[i]["DichVu"].ToString().TrimEnd();
                        dr["iscate"] = true;
                        dtResult.Rows.Add(dr);
                        _inCate = dtResult.Rows.Count - 1;

                        dr = dtResult.NewRow();
                        dr["DoiTuongDichVu"] = dtTemp.Rows[i]["DoiTuongDichVu"].ToString().TrimEnd();
                        dr["TenDoiTuongDichVu"] = dtTemp.Rows[i]["TenDoiTuongDichVu"].ToString().TrimEnd().ToUpper();
                        dr["SoLuong"] = dtTemp.Rows[i]["SoLuong"].ToString().TrimEnd();
                        dr["TongTien"] = dtTemp.Rows[i]["TongTien"].ToString().TrimEnd();
                        dr["iscate"] = false;
                        _TongThucHien = double.Parse(dtTemp.Rows[i]["SoLuong"].ToString());
                        _TongTien = double.Parse(dtTemp.Rows[i]["TongTien"].ToString());
                        dtResult.Rows.Add(dr);
                    }
                    else
                    {
                        dr["DoiTuongDichVu"] = dtTemp.Rows[i]["DoiTuongDichVu"].ToString().TrimEnd();
                        dr["TenDoiTuongDichVu"] = dtTemp.Rows[i]["TenDoiTuongDichVu"].ToString().TrimEnd();
                        dr["SoLuong"] = dtTemp.Rows[i]["SoLuong"].ToString().TrimEnd();
                        dr["TongTien"] = dtTemp.Rows[i]["TongTien"].ToString().TrimEnd();
                        dr["iscate"] = false;
                        _TongThucHien += double.Parse(dtTemp.Rows[i]["SoLuong"].ToString());
                        _TongTien += double.Parse(dtTemp.Rows[i]["TongTien"].ToString());
                        dtResult.Rows.Add(dr);
                    }

                }
                if (dtResult.Rows.Count > 0)
                {
                    dtResult.Rows[_inCate]["TongTien"] = _TongTien.ToString("N0");
                    dtResult.Rows[_inCate]["SoLuong"] = _TongThucHien.ToString("N0");
                }
            }

            ControlExtension.BindDataToGrid(dtResult, ref dtgDoiTuongDichVu, ref bvDoiTuongDichVu);
        }

        //Lấy thống kê theo người thực hiện

        private void ThongKeNguoiThucHien()
        {
            string _strSQL = "select * from ( \n";
            _strSQL += " select N.TenNhanVien, Tx.UserInXN as UserTH, Sum(K.GiaRieng) as TongTien, cast(Count(distinct K.MaTiepNhan)  as money)  as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XetNghiem K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan\n \n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInXN \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_XN();
            _strSQL += " group by N.TenNhanVien, Tx.UserInXN,D.TenPhanLoai, k.MaPhanLoai\n";

            _strSQL += "Union all \n";

            _strSQL += " select N.TenNhanVien, Tx.UserInSieuAm as UserTH , Sum(K.GiaRieng) as TongTien,cast( Count(distinct K.MaTiepNhan) as money)  as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_SieuAm K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_SieuAm tx on T.MaTiepNhan = tx.MaTiepNhan\n\n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInSieuAm \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_SieuAm();
            _strSQL += " group by N.TenNhanVien, Tx.UserInSieuAm ,D.TenPhanLoai, k.MaPhanLoai\n";

            //noi soi
            _strSQL += "Union all \n";

            _strSQL += " select N.TenNhanVien, Tx.UserInNoiSoi as UserTH , Sum(K.GiaRieng) as TongTien,cast( Count(distinct K.MaTiepNhan) as money)  as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_NoiSoi K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = tx.MaTiepNhan\n\n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInNoiSoi \n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_NoiSoi();
            _strSQL += " group by N.TenNhanVien, Tx.UserInNoiSoi ,D.TenPhanLoai, k.MaPhanLoai\n";

            //XQuang

            _strSQL += "Union all \n";

            _strSQL += " select N.TenNhanVien, Tx.UserInXQuang as UserTH, Sum(K.GiaRieng) as TongTien,cast( Count(distinct K.MaTiepNhan) as money) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_XQuang K on T.MaTiepNhan = K.MaTiepNhan  inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan\n \n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInXQuang\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_XQuang();
            _strSQL += " group by N.TenNhanVien, Tx.UserInXQuang,D.TenPhanLoai, k.MaPhanLoai\n";
            //DV Khám bệnh
            _strSQL += "Union all \n";
            _strSQL += " select N.TenNhanVien, Tx.UserIn as UserTH, Sum(K.GiaRieng) as TongTien,cast( Count(distinct K.MaTiepNhan) as money) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KhamBenh_KetQua K on T.MaTiepNhan = K.MaTiepNhan  inner join KhamBenh_BenhNhan tx on T.MaTiepNhan = tx.MaTiepNhan\n \n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserIn\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_DVKhamBenh();
            _strSQL += " group by N.TenNhanVien, Tx.UserIn,D.TenPhanLoai, k.MaPhanLoai\n";
            //DVKhac
            _strSQL += "Union all \n";
            _strSQL += " select N.TenNhanVien, Tx.UserInKhac as UserTH, Sum(K.GiaRieng) as TongTien,cast( Count(distinct K.MaTiepNhan) as money) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join KetQua_CLS_DVKhac K on T.MaTiepNhan = K.MaTiepNhan  inner join CLS_BenhNhan_DVKhac tx on T.MaTiepNhan = tx.MaTiepNhan\n ";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = Tx.UserInKhac\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_DVKhac();
           // _strSQL +="\n and Tx.UserInKhac is not null"
            _strSQL += " group by N.TenNhanVien, Tx.UserInKhac,D.TenPhanLoai, k.MaPhanLoai\n";
            //Thuoc
            _strSQL += "Union all \n";
            _strSQL += " select N.TenNhanVien, T.UserNhap as UserTH, Sum(K.ThanhTien) as TongTien,cast( Count(distinct K.MaTiepNhan) as money) as SoLuong, D.TenPhanLoai as DichVu , k.MaPhanLoai as MaDichVu, cast (0 as bit) as isCate\n";
            _strSQL += " from BenhNhan_TiepNhan T inner join ThuPhi_Thuoc K on T.MaTiepNhan = K.MaTiepNhan \n";
            _strSQL += " left join (Select d.MaNguoiDung, NV.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung d inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on nv.MaNhanVien = d.MaNhanVien) as N on N.MaNguoiDung = T.UserNhap\n";
            _strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            //Ghép với điều kiện
            _strSQL += Get_Condit_Thuoc();
            _strSQL += " group by N.TenNhanVien, T.UserNhap,D.TenPhanLoai, k.MaPhanLoai\n";

            _strSQL += " ) as A\n";
            _strSQL += "\n where A.UserTH is not null";
            _strSQL += " order by A.MaDichVu, A.TenNhanVien";

            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            DataTable dtResult = new DataTable();
            dtResult = dtTemp.Clone();
            string _MaDichVu = "";
            int _inCate = 0;
            double _TongThucHien = 0;
            double _TongTien = 0;

            if (dtTemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    DataRow dr = dtResult.NewRow();
                    if (_MaDichVu != dtTemp.Rows[i]["MaDichVu"].ToString().TrimEnd().ToLower())
                    {
                        if (dtResult.Rows.Count > 0)
                        {
                            dtResult.Rows[_inCate]["TongTien"] = _TongTien.ToString("N3");
                            dtResult.Rows[_inCate]["SoLuong"] = _TongThucHien.ToString("N0");
                        }
                        _MaDichVu = dtTemp.Rows[i]["MaDichVu"].ToString().TrimEnd().ToLower();
                        dr["TenNhanVien"] = dtTemp.Rows[i]["DichVu"].ToString().TrimEnd();
                        dr["iscate"] = true;
                        dtResult.Rows.Add(dr);
                        _inCate = dtResult.Rows.Count - 1;

                        dr = dtResult.NewRow();
                        dr["UserTH"] = dtTemp.Rows[i]["UserTH"].ToString().TrimEnd();
                        dr["TenNhanVien"] = dtTemp.Rows[i]["TenNhanVien"].ToString().TrimEnd().ToUpper();
                        dr["SoLuong"] = dtTemp.Rows[i]["SoLuong"].ToString().TrimEnd();
                        dr["TongTien"] = dtTemp.Rows[i]["TongTien"].ToString().TrimEnd();
                        dr["iscate"] = false;
                        _TongThucHien = double.Parse(dtTemp.Rows[i]["SoLuong"].ToString());
                        _TongTien = double.Parse(dtTemp.Rows[i]["TongTien"].ToString());
                        dtResult.Rows.Add(dr);
                    }
                    else
                    {
                        dr["UserTH"] = dtTemp.Rows[i]["UserTH"].ToString().TrimEnd();
                        dr["TenNhanVien"] = dtTemp.Rows[i]["TenNhanVien"].ToString().TrimEnd();
                        dr["SoLuong"] = dtTemp.Rows[i]["SoLuong"].ToString().TrimEnd();
                        dr["TongTien"] = dtTemp.Rows[i]["TongTien"].ToString().TrimEnd();
                        dr["iscate"] = false;
                        _TongThucHien += double.Parse(dtTemp.Rows[i]["SoLuong"].ToString());
                        _TongTien += double.Parse(dtTemp.Rows[i]["TongTien"].ToString());
                        dtResult.Rows.Add(dr);
                    }

                }
                if (dtResult.Rows.Count > 0)
                {
                    dtResult.Rows[_inCate]["TongTien"] = _TongTien.ToString("N0");
                    dtResult.Rows[_inCate]["SoLuong"] = _TongThucHien.ToString("N0");
                }
            }
            ControlExtension.BindDataToGrid(dtResult, ref dtgNguoiThucHien, ref bvNguoiThuchien);
        }

        private void frmThongKeTongHop_Load(object sender, EventArgs e)
        {
            C_NhanVien nhanvien = new C_NhanVien();
            nhanvien.Get_NhanVien(cboNhanVien);
            nhanvien.Get_NhanVien(cboNhanVienThucHien);
            sysConfig.Get_DoiTuongDichVu(cboDoiTuongDV, null);
            data.Get_CauHinh_PhanLoaiChucNang(cboDichVuCLS, "");
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28, 0, 0, 0);
            dtpDateFrom.Value = date.AddMonths(-1);
            tabControl1.TabPages.Remove(tabChietKhau);
            tabControl1.TabPages.Remove(tabThuocXuat);

            if (cboDichVuCLS.Items.Count > 0)
            {
                cboDichVuCLS.SelectedValue = "CLSXetNghiem";
            }
        }

        private void btnTKTongHopXN_Click(object sender, EventArgs e)
        {
            txtTenNhomCLS.Focus();
            TK_TongHopThucHien();
        }

        private void dtgTongHopThucHien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgTongHopThucHien);
        }

        private void btnXuatTH_Click(object sender, EventArgs e)
        {
            if (dtgTongHopThucHien.RowCount > 0)
            {
               Excel.ExportToExcel.Export(dtgTongHopThucHien);
            }
        }

        private void dtgDoiTuongDichVu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgDoiTuongDichVu);
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

        private void dtgNguoiThucHien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgNguoiThucHien);
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

        private void Thongke_TongHop_BacSiThucHien()
        {

            string _DateFrom = dtpDateFrom.Value.ToString("yyyy/MM/dd 00:00:00");
            string _DateTo = dtpDateTo.Value.ToString("yyyy/MM/dd 23:59:59");

            for (int i = 3; i <= dtgBacSiTongHop.ColumnCount; i++)
            {
                if (i < dtgBacSiTongHop.ColumnCount - 1)
                {
                    dtgBacSiTongHop.Columns.RemoveAt(i + 1);
                    i--;
                }
            }

            DataTable dtChiDinh = new DataTable();
            dtChiDinh =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "exec Thongke_BS_SL_ChiDinh  @DateFrom = '" + _DateFrom + "' ,@DateTo = '" + _DateTo + "'").Tables[0
                    ];
            DataTable dtNoiSoi = new DataTable();
            dtNoiSoi =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "exec Thongke_BS_SL_NoiSoi @DateFrom = '" + _DateFrom + "' ,@DateTo = '" + _DateTo + "'").Tables[0];
            DataTable dtSieuAm = new DataTable();
            dtSieuAm =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "exec Thongke_BS_SL_SieuAm @DateFrom = '" + _DateFrom + "' ,@DateTo = '" + _DateTo + "'").Tables[0];
            DataTable dtKhamBenh = new DataTable();
            dtKhamBenh =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "exec Thongke_BS_SL_KhamBenh @DateFrom = '" + _DateFrom + "' ,@DateTo = '" + _DateTo + "'").Tables[0
                    ];
            DataTable dtDVKhac = new DataTable();
            dtDVKhac =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "exec Thongke_BS_SL_DVKhac @DateFrom = '" + _DateFrom + "' ,@DateTo = '" + _DateTo + "'").Tables[0];

            DataTable dtKetQuaThongKe = new DataTable();
            //Lấy danh sách BS trước
            dtKetQuaThongKe =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "select MaNhanVien, TenNhanVien from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN where ThongKe = 1 and DaNghi = 0 order by TenNhanVien")
                    .Tables[0];
            //Thống kê số lượng chỉ định
            Add_ValueTK(ref dtKetQuaThongKe, dtChiDinh, "SLChiDinh", "CHỈ ĐỊNH 10%", false);
            // Thống kê số lượng nội soi
            Add_ValueTK(ref dtKetQuaThongKe, dtNoiSoi, "SLNoiSoi", "SỐ CA NS", false);
            // Thống kê số lượng siêu âm
            Add_ValueTK(ref dtKetQuaThongKe, dtSieuAm, "", "", true);
            // Thống kê số lượng DVKhác
            Add_ValueTK(ref dtKetQuaThongKe, dtDVKhac, "", "", true);
            // Thống kê số lượng khám bệnh
            Add_ValueTK(ref dtKetQuaThongKe, dtNoiSoi, "SLKhamBenh", "SỐ CA KB", false);

            ControlExtension.BindDataToGrid(dtKetQuaThongKe, ref dtgBacSiTongHop,ref bvBacSiTongHop);
        }

        private void Add_ValueTK(ref DataTable dtResult, DataTable dtValue, string _CotAdd,string _CotText,  bool _CoNhom)
        {
            //Duyệt và thêm giá trị
            string _MaNhanVien = "";
            string _MaNhanVienCheck = "";
            if (!_CoNhom)
            {
                //Thêm cột thống kê
                dtResult.Columns.Add(_CotAdd, typeof(string));
                dtgBacSiTongHop.Columns.Add(_CotAdd, _CotText);
                dtgBacSiTongHop.Columns[_CotAdd].DataPropertyName = _CotAdd;
                dtResult.AcceptChanges();

                foreach (DataRow dr in dtResult.Rows)
                {
                    _MaNhanVien = dr["MaNhanVien"].ToString().Trim().ToLower();
                    for (int i = 0; i < dtValue.Rows.Count; i++)
                    {
                        _MaNhanVienCheck = dtValue.Rows[i]["MaNhanVien"].ToString().Trim().ToLower();
                        if (_MaNhanVienCheck.Equals(_MaNhanVien))
                        {
                            dr[_CotAdd] = dtValue.Rows[i]["SoLuong"].ToString();
                            dtValue.Rows.RemoveAt(i);
                            dtValue.AcceptChanges();
                            break;
                        }
                    }
                }
            }
            else
            { 
                //Thêm cột theo nhóm
                //Lấy disticnt danh sách nhóm

                DataTable dtNhom = LabServices_Helper.DataTable_DistinctValue(dtValue, "MaNhomChiDinh", "MaNhomChiDinh", "TenNhomChiDinh");
                
                //dùng vòng lập để gán và thêm cột
                foreach (DataRow dr in dtNhom.Rows)
                {
                    _CotAdd = dr["MaNhomChiDinh"].ToString();
                    _CotText = dr["TenNhomChiDinh"].ToString();
                    //Thêm cột thống kê
                    dtResult.Columns.Add(_CotAdd, typeof(string));
                    dtgBacSiTongHop.Columns.Add(_CotAdd, _CotText);
                    dtgBacSiTongHop.Columns[_CotAdd].DataPropertyName = _CotAdd;
                    dtResult.AcceptChanges();

                    foreach (DataRow dr2 in dtResult.Rows)
                    {
                        _MaNhanVien = dr2["MaNhanVien"].ToString().Trim().ToLower();
                        for (int i = 0; i < dtValue.Rows.Count; i++)
                        {
                            _MaNhanVienCheck = dtValue.Rows[i]["MaNhanVien"].ToString().Trim().ToLower();
                            if (_MaNhanVienCheck.Equals(_MaNhanVien))
                            {
                                dr2[_CotAdd] = dtValue.Rows[i]["SoLuong"].ToString();
                                dtValue.Rows.RemoveAt(i);
                                dtValue.AcceptChanges();
                                break;
                            }
                        }
                    }

                }
            }
            dtResult.AcceptChanges();
        }

        private void btnThongkeBSTongHop_Click(object sender, EventArgs e)
        {
            txtTenNhomCLS.Focus();
            Thongke_TongHop_BacSiThucHien();
        }

        private void btnXuatTKBSTongHop_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgBacSiTongHop);
        }

        private void dtgBacSiTongHop_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgBacSiTongHop);
        }

        private void Convert_DataOrintTK_BSTongHop()
        {
            if(dtgBacSiTongHop.RowCount>0)
            {
                DataTable dtSource = ((DataTable)((BindingSource)bvBacSiTongHop.BindingSource).DataSource);
                DataTable dtPrint = new DataTable();
                dtPrint.Columns.Add("MaNhanVien",typeof(string));
                dtPrint.Columns.Add("TenNhanVien",typeof(string));
                dtPrint.Columns.Add("SoLuong",typeof(string));
                dtPrint.Columns.Add("TongTien",typeof(string));
            }
        }

        private void btnExport_Statistic_NhanVien_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgStatistic_NhanVien);
        }

        private void btnStatistics_NhanVien_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            strSQL = "";
            strSQL = "select Nv.TenNhanVien, sum(A.SoLuong) as SoLuong, sum(A.TongTien) as TongTien from ";
            strSQL += "\n(";
            strSQL += "\nselect t.BacSiCD,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_XetNghiem k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_XN();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_NoiSoi k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_NoiSoi();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_SieuAm k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_SieuAm tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_SieuAm();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_XQuang k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_XQuang();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KhamBenh_KetQua k on t.MaTiepNhan = k.MaTiepNhan  inner join KhamBenh_BenhNhan tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_DVKhamBenh();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_DVKhac k on t.MaTiepNhan = k.MaTiepNhan  inner join CLS_BenhNhan_DVKhac tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_DVKhac();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.SoLuong*k.DonGia) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join ThuPhi_Thuoc k on t.MaTiepNhan = k.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_Thuoc();
            strSQL += "\ngroup by t.BacSiCD";
            strSQL += "\n) as A";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on A.BacSiCD = nv.MaNhanVien";
            strSQL += "\ngroup by nv.TenNhanVien";

            DataTable dtKetQua = new DataTable();
            dtKetQua = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dtKetQua, ref dtgStatistic_NhanVien, ref bvStatistics_NhanVien);
        }
        private void ThongKe_ChiTiet_BS_DichVu()
        {
            string strSQL = "";
            strSQL = "";
            strSQL = "select Nv.TenNhanVien,A.BacSiCD, A.TenPhanLoai, sum(A.SoLuong) as SoLuong, sum(A.TongTien) as TongTien from ";
            strSQL += "\n(";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_XetNghiem k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_XN();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_NoiSoi k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_NoiSoi();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_SieuAm k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_SieuAm tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_SieuAm();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_XQuang k on t.MaTiepNhan = k.MaTiepNhan  inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_XQuang();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KhamBenh_KetQua k on t.MaTiepNhan = k.MaTiepNhan  inner join KhamBenh_BenhNhan tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_DVKhamBenh();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,   Count(distinct t.MaTiepNhan) as SoLuong, sum(k.giarieng) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join KetQua_CLS_DVKhac k on t.MaTiepNhan = k.MaTiepNhan  inner join CLS_BenhNhan_DVKhac tx on T.MaTiepNhan = tx.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_DVKhac();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\nunion all";
            strSQL += "\nselect t.BacSiCD, D.TenPhanLoai,  Count(distinct t.MaTiepNhan) as SoLuong, sum(k.SoLuong*k.DonGia) as TongTien from BenhNhan_TiepNhan T";
            strSQL += "\ninner join ThuPhi_Thuoc k on t.MaTiepNhan = k.MaTiepNhan";
            strSQL += " left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = k.MaPhanLoai\n";
            strSQL += Get_Condit_Thuoc();
            strSQL += "\ngroup by t.BacSiCD, D.TenPhanLoai";
            strSQL += "\n) as A";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on A.BacSiCD = nv.MaNhanVien";
            strSQL += "\ngroup by nv.TenNhanVien,A.BacSiCD, A.TenPhanLoai";
            strSQL += "\nOrder by A.BacSiCD";

            DataTable dtTemp = new DataTable();
            dtTemp = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];

            DataTable dtResult = new DataTable();
            LabServices_Helper.CreateDataTable(ref dtResult, 
                new string[] { "MaNV", "TenNhanVien", "TenDoiTuongDichVu", "SoLuong", "TongTien" }, 
                new string[] { "MaNV", "TenNhanVien", "TenDoiTuongDichVu", "SoLuong", "TongTien" },
                new string[] { "string", "string", "string", "string", "string" });
            string _MaBS = "";
            DataRow drR = dtResult.NewRow();
            foreach (DataRow dr in dtTemp.Rows)
            {
                if (_MaBS != dr["BacSiCD"].ToString())
                {
                    if (_MaBS != "")
                    {
                        dtResult.Rows.Add(drR);
                        drR = dtResult.NewRow();
                    }
                    _MaBS = dr["BacSiCD"].ToString();
                    drR["MaNV"] = dr["BacSiCD"];
                    drR["TenNhanVien"] = dr["TenNhanVien"];
                    drR["TenDoiTuongDichVu"] = dr["TenPhanLoai"].ToString();
                    drR["SoLuong"] = string.Format("{0:# ###.####}", double.Parse(dr["SoLuong"].ToString()));
                    drR["TongTien"] = string.Format("{0:# ###.####}", double.Parse(dr["TongTien"].ToString()));
                }
                else
                {
                    drR["TenDoiTuongDichVu"] = drR["TenDoiTuongDichVu"].ToString() + "\n" + dr["TenPhanLoai"].ToString();
                    drR["SoLuong"] = drR["SoLuong"].ToString() + "\n" + string.Format("{0:# ###.####}", double.Parse(dr["SoLuong"].ToString()));
                    drR["TongTien"] = drR["TongTien"].ToString() + "\n" + string.Format("{0:# ###.####}", double.Parse(dr["TongTien"].ToString()));
                }
            }
            if (dtTemp.Rows.Count > 0)
            {
                dtResult.Rows.Add(drR);
            }
            ControlExtension.BindDataToGrid(dtResult, ref dtgBS_ChiTetDV, ref bvBS_ChiTietDV); 
            LabServices_Helper.DanhDauNhom_STT(dtgBS_ChiTetDV);
            dtgBS_ChiTetDV.AutoResizeColumns();
            dtgBS_ChiTetDV.AutoResizeRows();
           
        }
        private void cboDichVuCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboNhanVien);
        }

        private void cboNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboNhanVienThucHien);
        }

        private void cboNhanVienThucHien_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboDoiTuongDV);
        }

        private void cboDoiTuongDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, radPriceAll);
        }

        private void dtgStatistic_NhanVien_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LabServices_Helper.DanhDauNhom_STT(dtgStatistic_NhanVien);
        }

        private void btnThongKe_BS_ChiTet_Click(object sender, EventArgs e)
        {
            ThongKe_ChiTiet_BS_DichVu();
        }

        private void btnThongKe_ThuPhi_Thuoc_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            strSQL = "select K.MaThuoc, K.TenThuoc, K.DonGia,K.DonViTinh";
            strSQL += "\n,sum(K.SoLuong) as SoLuong";
            strSQL += "\n,Sum(case when K.DaThuTien = 1 then K.SoLuong else 0 end *K.DonGia) as TongTienDT ";
            strSQL += "\n,Sum(case when K.DaThuTien = 1 then 0 else K.SoLuong end *K.DonGia) as TongTienCT ";
            strSQL += "\nfrom ";
            strSQL += "\nBenhNhan_TiepNhan t inner join ThuPhi_Thuoc K on t.MaTiepNhan = K.MaTiepNhan";
            strSQL += Get_Condit_Thuoc_Without_DVCLS();
            strSQL += "\ngroup by K.MaThuoc, K.TenThuoc, K.DonGia, K.DonViTinh";

            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtgTP_Thuoc, ref bvThuPhi_thuoc);
            LabServices_Helper.DanhDauNhom_STT(dtgTP_Thuoc);
            dtgTP_Thuoc.AutoResizeColumns();
        }

        private void btnExport_ThuPhi_Thuoc_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgTP_Thuoc);
        }

        private void btnXuat_BS_ChiTet_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgBS_ChiTetDV);
        }

        private void btnExport_XuatKho_Thuoc_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgXuatKho_Thuoc);
        }

        private void btnThongKe_XuatKho_Thuoc_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            strSQL = "select K.MaThuoc, K.TenThuoc, K.DonGia, K.DonViTinh";
            strSQL += "\n,sum(K.SoLuong) as SoLuong";
            strSQL += "\n,Sum( K.SoLuong *K.DonGia) as TongTien";
            strSQL += "\nfrom ";
            strSQL += "\nBenhNhan_TiepNhan t inner join VT_XuatKho_PhieuXuat_Thuoc p  on t.MaTiepNhan = p.MaTiepNhan";
            strSQL += "\ninner join VT_XuatKho_ChiTiet_Thuoc K on p.MaPhieuXuat = K.MaPhieuXuat";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on g.MaGocThuoc = K.MaGocThuoc";
            strSQL += Get_Condit_Thuoc_Without_DVCLS();
            strSQL += "\ngroup by K.MaThuoc, K.TenThuoc, K.DonGia, K.DonViTinh";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtgXuatKho_Thuoc, ref bvXuatKho_Thuoc);
            LabServices_Helper.DanhDauNhom_STT(dtgXuatKho_Thuoc);
            dtgXuatKho_Thuoc.AutoResizeColumns();
        }
    }
}
