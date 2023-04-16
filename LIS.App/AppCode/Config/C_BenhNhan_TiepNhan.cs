using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode.Config
{
    internal class C_BenhNhan_TiepNhan
    {
        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        //Danh mục dich vụ CLS
        public void Get_DichVuCLS(DataGridView dtg, BindingNavigator bv, string filter, 
            ref DataTable dt)
        {
            if (dt == null) throw new ArgumentNullException("dt");
            var sqlQuery = string.Format(" select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where 0=0 \n {0}  order by Ma", filter);
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Load_Nhom_TheoDVCLS(CustomComboBox cbo, string nhomDichVu, string filter = "")
        {
            if (nhomDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.GetTestGroup(cbo, string.Empty, filter);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.Get_NhomCLS_SieuAm(cbo, string.Empty);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.Get_DM_XQuang_KyThuat(cbo);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.Get_NhomCLS_NoiSoi(cbo, string.Empty);
            }
            else if (nhomDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.Get_DM_KhamBenh_NhomDichVu(cbo, string.Empty, null);
            }
            else if (nhomDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.Get_DM_NHOMCLS_DVKHAC(cbo, string.Empty);
            }
            else if (nhomDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                sysConfig.Get_DM_Thuoc_NhomThuoc(cbo);
            }
        }
        public DataTable Load_Nhom_TheoDVCLS(string nhomDichVu, string filter = "")
        {
            DataTable dataNhom = new DataTable();
            if (nhomDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.GetTestGroup(string.Empty, filter);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.Get_NhomCLS_SieuAm(null, string.Empty);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.Get_DM_XQuang_KyThuat(null);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.Get_NhomCLS_NoiSoi(null, string.Empty);
            }
            else if (nhomDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.Get_DM_KhamBenh_NhomDichVu(null, string.Empty, null);
            }
            else if (nhomDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.Get_DM_NHOMCLS_DVKHAC(null, string.Empty);
            }
            else if (nhomDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = sysConfig.Get_DM_Thuoc_NhomThuoc(null);
            }
            dataNhom = ConvertColumnsName_Nhom(dataNhom);
            return dataNhom;
        }
        private DataTable ConvertColumnsName_Nhom(DataTable _danhSachChiDinh)
        {
            foreach (DataColumn dc in _danhSachChiDinh.Columns)
            {
                if (dc.ColumnName.Equals("MaNhomCLS", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("MaNhomSieuAm", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("MaNhomNoiSoi", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("MaNhomThuoc", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("MaKyThuatChup", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("manhomcls", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("MaNhomDichVu", StringComparison.OrdinalIgnoreCase)
                      )
                    dc.ColumnName = "MaNhomDichVu".ToLower();
                else if (dc.ColumnName.Equals("TenNhomCLS", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomSieuAm", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomNoiSoi", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomThuoc", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenKyThuatChup", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("tennhomcls", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomDichVu", StringComparison.OrdinalIgnoreCase)
                     )
                    dc.ColumnName = "TenNhomDichVu".ToLower();
            }
            return _danhSachChiDinh;
        }
        public DataTable Load_ChiDinhCLS(
            CustomComboBox cbo, string nhomDichVu, string nhomCd, string sex, string maDoiTuongDv, string filter = "")
        {
            if (nhomDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.GetSubclinicalTestAndProfile(cbo, nhomCd, maDoiTuongDv, filter);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DMSieuAm(cbo,
                      (string.IsNullOrWhiteSpace(sex)
                          ? string.Empty
                          : sex == "?"
                              ? string.Empty
                              : " and (GioiTinhSuDung = '" + sex + "'  or GioiTinhSuDung = 'A')") +
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomSieuAm = '" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DM_XQuang_VungChup(cbo,
                     (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaKyThuatChup = '" + nhomCd + "'"),
                     maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DMNoiSoi(cbo,
                      (string.IsNullOrWhiteSpace(sex)
                          ? string.Empty
                          : sex == "?"
                              ? string.Empty
                              : " and (GioiTinhSuDung = '" + sex + "' or GioiTinhSuDung = 'A')") +
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomNoiSoi = '" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DM_KhamBenh_DichVu(cbo, nhomCd, string.Empty, null, maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DM_DICHVUKHAC(cbo,
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomCLS ='" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var thuocDal = new DM_THUOC_DAL();
                return thuocDal.Data_DM_Thuoc_ForWork(cbo, "MaVatTu", "MaVatTu",
                     "MaVatTu, TenVatTu, TonKho, DonViTinh, GiaRieng", "50,150,30,40,50", null, 0, string.Empty,
                     nhomCd, maDoiTuongDv);
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable Load_ChiDinhCLSForClick(
    CustomComboBox cbo, string nhomDichVu, string nhomCd, string sex, string maDoiTuongDv, string filter = "")
        {
            if (nhomDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.GetSubclinicalTest_NoProfile(nhomCd);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DMSieuAm(cbo,
                      (string.IsNullOrWhiteSpace(sex)
                          ? string.Empty
                          : sex == "?"
                              ? string.Empty
                              : " and (GioiTinhSuDung = '" + sex + "'  or GioiTinhSuDung = 'A')") +
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomSieuAm = '" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DM_XQuang_VungChup(cbo,
                     (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaKyThuatChup = '" + nhomCd + "'"),
                     maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DMNoiSoi(cbo,
                      (string.IsNullOrWhiteSpace(sex)
                          ? string.Empty
                          : sex == "?"
                              ? string.Empty
                              : " and (GioiTinhSuDung = '" + sex + "' or GioiTinhSuDung = 'A')") +
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomNoiSoi = '" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DM_KhamBenh_DichVu(cbo, nhomCd, string.Empty, null, maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sysConfig.Get_DM_DICHVUKHAC(cbo,
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomCLS ='" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (nhomDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                var thuocDal = new DM_THUOC_DAL();
                return thuocDal.Data_DM_Thuoc_ForWork(cbo, "MaVatTu", "MaVatTu",
                     "MaVatTu, TenVatTu, TonKho, DonViTinh, GiaRieng", "50,150,30,40,50", null, 0, string.Empty,
                     nhomCd, maDoiTuongDv);
            }
            else
            {
                return new DataTable();
            }
        }
        public void Get_CauHinh_PhanLoaiChucNang(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = string.Format(" select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where 0=0 \n {0} order by TenPhanLoai", filter);
            LabServices_Helper.BindContex(da, ref dt, sqlQuery, ref dtg, ref bv);
        }

        public void Get_CauHinh_PhanLoaiChucNang(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = string.Format(" select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where 0=0 \n {0} order by TenPhanLoai", filter);
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaPhanLoai", "TenPhanLoai");
        }

        public void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, string filter)
        {
            var sqlQuery = string.Format(" select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where 0=0  \n {0} order by TenPhanLoai", filter);
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaPhanLoai", "MaNhap");
        }
        public void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo,TextBox  txt, string filter)
        {
            var sqlQuery = string.Format(" select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where 0=0  \n {0} order by TenPhanLoai", filter);
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaPhanLoai", "MaNhap", "MaPhanLoai, MaNhap, TenPhanLoai",
                "50,50, 150", txt, 2);
        }
     

        //Chan doan
        public void Add_ChanDoan(string maChanDoan, string chanDoan)
        {
            if (LabServices_Helper.Check_NotExits("select * from {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan where MaChanDoan='" + maChanDoan + "'"))
            {
                var sqlQuery = "insert into {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan (MaChanDoan, TenChanDoan)";
                sqlQuery += " select '" + maChanDoan + "', N'" + Utilities.ConvertSqlString(chanDoan) + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Mã chẩn đoán đã có !\nVui lòng nhập mã khác");
            }
        }

        public void Add_ChanDoan(string maChanDoan)
        {
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chẩn đoán đang chọn ?")) return;
            var sqlQuery = "Delete ChanDoan  MaChanDoan ='" + maChanDoan.Trim() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }

        public void Get_ChanDoan(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            sqlQuery += " order by TenChanDoan";
            LabServices_Helper.BindContex(da, ref dt, sqlQuery, ref dtg, ref bv);
        }

        public void Get_ChanDoan(CustomComboBox cbo)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan";
            sqlQuery += " order by TenChanDoan";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaChanDoan", "MaChanDoan", "MaChanDoan,TenChanDoan", "100,250");
        }

        //Danh mục Tỉnh Thành Phố 
        public void Get_TinhTP(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_HanhChinh_TinhThanhPho where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by TenTinh";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_TinhTP(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            string sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_HanhChinh_TinhThanhPho where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by TenTinh";
            LabServices_Helper.BindContex(da, ref dt, sqlQuery, ref dtg, ref bv);
        }

        public void Get_TinhTP(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_HanhChinh_TinhThanhPho";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where AutoID = " + filter;
            }
            sqlQuery += " order by TenTinh";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "AutoID", "TenTinh");
        }

        public void Get_TinhTP(CustomComboBox cbo, string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_HanhChinh_TinhThanhPho where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by TenTinh";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "AutoID", "MaNhap");
        }
        public DataTable Get_TinhTP(string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_HanhChinh_TinhThanhPho where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by TenTinh";
           return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }

        //Danh mục Quận Huyện
        public void Get_QuanHuyen(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_HanhChinh_QuanHuyen where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by QuanHuyen";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable Get_QuanHuyen(string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_HanhChinh_QuanHuyen where 0=0 \n";
            if (!string.IsNullOrEmpty(filter))
                sqlQuery += "And MaTinh = " + filter.ToLower().Replace ("and matinh =","");
            sqlQuery += " order by QuanHuyen";
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public void Get_QuanHuyen(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt) 
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_HanhChinh_QuanHuyen where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by QuanHuyen";
            LabServices_Helper.BindContex(da, ref dt, sqlQuery, ref dtg, ref bv);
        }

        public void Get_QuanHuyen(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_HanhChinh_QuanHuyen where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by QuanHuyen";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "AutoID", "QuanHuyen");
        }

        public void Get_QuanHuyen(CustomComboBox cbo, string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_HanhChinh_QuanHuyen where 0=0 \n";
            sqlQuery += filter;
            sqlQuery += " order by QuanHuyen";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "AutoID", "MaNhap");
        }

        //Data for Group
        public void Get_Group(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from tbl_Group";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where GroupID = '" + filter + "'";
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_Group_Test(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from tbl_Group_Test";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where GroupID = '" + filter + "'";
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_Group(ComboBox cbo, string headerId, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from tbl_Group";
            if (!string.IsNullOrWhiteSpace(headerId))
            {
                sqlQuery += " where GroupID = '" + headerId + "'";
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];

            ControlExtension.BindDataToCobobox(dt, ref cbo, "GroupID", "GroupName");
        }

        //Tieu de phieu in

        public void Insert_Header(string headerId, string description)
        {
            if (LabServices_Helper.Check_NotExits("select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where MaDonVi = '" + headerId.Trim() + "'"))
            {
                var sqlQuery = "insert into {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn (MaDonVi, Description) values('" + headerId.Trim() + "',N'" +
                                  Utilities.ConvertSqlString(description.Trim()) + "')";
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }
            else
            {
              CustomMessageBox.MSG_Error_OK("Mã tiêu đề đã tồn tại!\nHãy nhập mã khác.");
            }
        }

        public void Get_Header_Config(SqlDataAdapter da, DataGridView dtg, 
            BindingNavigator bv, string headerId,
            ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where 1=1";
            if (!string.IsNullOrWhiteSpace(headerId))
            {
                sqlQuery += " and MaDonVi = '" + headerId + "'";
            }
            LabServices_Helper.BindContex(da, ref dt, sqlQuery, ref dtg, ref bv);
        }

        public DataTable Get_Header_Config(string headerId)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where 1=1";
            if (!string.IsNullOrWhiteSpace(headerId))
            {
                sqlQuery += " and MaDonVi = '" + headerId + "'";
            }
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }

        public void Get_Department(CustomComboBox cbo)
        {
            using (var dt = new DataTable())
            {
                dt.Columns.Add("MaBoPhan", typeof (string));
                dt.Columns.Add("TenBoPhan", typeof (string));
                DataRow dr = dt.NewRow();
                dr["MaBoPhan"] = "A";
                dr["TenBoPhan"] = "Dùng chung";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaBoPhan"] = "HH";
                dr["TenBoPhan"] = "Huyết học";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaBoPhan"] = "SH";
                dr["TenBoPhan"] = "Sinh hóa";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaBoPhan"] = "MD";
                dr["TenBoPhan"] = "Miễn dịch";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaBoPhan"] = "VS";
                dr["TenBoPhan"] = "Vi sinh";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaBoPhan"] = "SA";
                dr["TenBoPhan"] = "Siêu âm";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaBoPhan"] = "XQ";
                dr["TenBoPhan"] = "X-Quang";
                dt.Rows.Add(dr);

                cbo.DataSource = dt;
            }
            cbo.ValueMember = "MaBoPhan";
            cbo.DisplayMember = "MaBoPhan";
            cbo.SelectedIndex = -1;
        }

        //Khu vực QL User

        //Get for CLS_KetQua
        public void Get_CLS_KetQua(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            var sqlQuery = " select cast (0 as bit) as chon, * from KetQua_CLS_XetNghiem";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            sqlQuery += " order by ThuTuIn,MaNhomCLS, MaXN, TenXN";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_CLS_KetQua_SieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            var sqlQuery = " select cast (0 as bit) as chon, * from KetQua_CLS_SieuAm";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_CLS_KetQua_SieuAm(CustomComboBox cbo, string filter)
        {
            var sqlQuery =
                " select cast (0 as bit) as chon, k.*, m.GoTat from KetQua_CLS_SieuAm k left join {{TPH_Standard}}_Dictionary.dbo.dm_MauSieuAm m on k.MaSoMau = m.MaSoMau";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MasoMau", "GoTat");
        }

        public void Get_CLS_KetQua_NoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select cast (0 as bit) as chon, * from KetQua_CLS_NoiSoi";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_CLS_KetQua_NoiSoi(CustomComboBox cbo, string filter)
        {
            var sqlQuery = " select cast (0 as bit) as chon, * from KetQua_CLS_NoiSoi";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaSoMauNoiSoi", "MaSoMauNoiSoi", "MaSoMauNoiSoi,TenMauNoiSoi",
                "50,250");
        }
    }
}