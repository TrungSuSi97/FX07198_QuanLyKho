using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode.Config
{
    internal class C_NguoiDung
    {
        public void Get_UserList(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select d.*, n.TenNhanVien, n.DaNghi from {{TPH_Standard}}_System.dbo.QL_NguoiDung d";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on d.MaNhanVien = n.MaNhanVien where  d.MaNguoiDung not in ('admin')\n";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += "  and d.MaNguoiDung = '" + filter + "'";
            }

            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }

        public void Get_UserList(CustomComboBox cbo, string filter)
        {
            DataTable dt = new DataTable();
            var strSql = " select d.*, n.TenNhanVien, n.DaNghi from {{TPH_Standard}}_System.dbo.QL_NguoiDung d";
            strSql += "\n inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on d.MaNhanVien = n.MaNhanVien where 1=1 \n";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNguoiDung", "MaNguoiDung");
        }

        public void Get_UserSign(CustomComboBox cbo, ServiceType enuServiceType, string filter)
        {
            DataTable dt = new DataTable();
            var strSql = " select distinct d.MaNhanVien, d.MaNguoiDung, n.TenNhanVien, n.DaNghi from {{TPH_Standard}}_System.dbo.QL_NguoiDung d";
            strSql +=
                "\n inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on d.MaNhanVien = n.MaNhanVien inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen dv on d.MaNguoiDung = dv.MaNguoiDung";
            strSql += "\n where dv.MaLoaiDichVu = '" + enuServiceType.ToString()+ "'";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNguoiDung", "MaNguoiDung");
        }

        public void Get_UserSign(CustomComboBox cbo, ServiceType enuServiceType, string filter, TextBox txt)
        {
            DataTable dt = new DataTable();
            var strSql = " select distinct d.MaNhanVien, d.MaNguoiDung, n.TenNhanVien, n.DaNghi from {{TPH_Standard}}_System.dbo.QL_NguoiDung d";
            strSql +=
                "\n inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on d.MaNhanVien = n.MaNhanVien inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen dv on d.MaNguoiDung = dv.MaNguoiDung";
            strSql += "\nwhere 1=1 \n";
           strSql += "\n and dv.MaLoaiDichVu = '" + enuServiceType.ToString()+ "'";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNguoiDung", "MaNguoiDung", "MaNhanVien, TenNhanVien", "50,150");
        }

        public void Get_Group_UserSign(CustomComboBox cbo, ServiceType enuServiceType, string filter)
        {
            DataTable dt = new DataTable();
            var strSql = " select distinct d.MaNhanVien, d.MaNguoiDung, n.TenNhanVien, n.DaNghi from {{TPH_Standard}}_System.dbo.QL_NguoiDung d";
            strSql +=
                "\n inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on d.MaNhanVien = n.MaNhanVien" +
                "\n inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_nhomphanquyen nh on nh.MaNguoiDung = d.MaNhanVien" +
                "\n inner join {{TPH_Standard}}_System.dbo.ql_dm_nhomphanquyen_chitiet nhct on nh.MaNhomPhanQuyen = nhct.MaNhomPhanQuyen" +
                "\n inner join {{TPH_Standard}}_System.dbo.ql_dm_phanquyen dmpq on dmpq.MaPhanQuyen = nhct.MaPhanQuyen" +
                "\n ";
            strSql += "\n where dmpq.MaLoaiDichVu = '" + enuServiceType.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNguoiDung", "MaNguoiDung");
        }

        public DataTable Get_User(string userId)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    " select d.*, n.TenNhanVien, n.DaNghi from {{TPH_Standard}}_System.dbo.QL_NguoiDung d left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on d.MaNhanVien = n.MaNhanVien where d.MaNguoiDung='" +
                    userId.Trim() + "'").Tables[0];
        }
        public DataTable CheckUserExist(string userId)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    " select MaNguoiDung,MatKhau from {{TPH_Standard}}_System.dbo.QL_NguoiDung where MaNguoiDung='" +
                    userId.Trim() + "'").Tables[0];
        }
        public bool Update_Password(string userId, string oldPassWord, string newPassword)
        {
            bool f = false;
            string pass = Utilities.ConvertSqlString(EnDeCrypt.EncryptString(newPassword, "clinic"));
            var strSql = "Update {{TPH_Standard}}_System.dbo.QL_NguoiDung set MatKhau = N'" +
                         pass +
                         "' where MaNguoiDung ='" + userId + "'";

            if ((int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > 0)
            {
                f = true;

                //Update for Chemical
                //strSql = string.Format("Update {0}..tbl_user set Password=@password where UserID=@userid", CommonAppVarsAndFunctions.TPHFBlood_DB);

                //DataProvider.ExecuteNonQuery(
                //    CommandType.Text,
                //    strSql,
                //     new SqlParameter[] {
                //        new SqlParameter("@password",pass),
                //        new SqlParameter("@userid",userId)
                //    });
            }
            return f;
        }

        public bool Reset_Password(string userId, string newPassword)
        {
            var strSql = "Update {{TPH_Standard}}_System.dbo.QL_NguoiDung set MatKhau = N'" +
                         Utilities.ConvertSqlString(EnDeCrypt.EncryptString(newPassword, "clinic")) +
                         "' where MaNguoiDung ='" + userId + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            return true;
        }

        public bool Check_Login(string userId, string password)
        {
            var dt = CheckUserExist(userId);
            if (dt == null || dt.Rows.Count <= 0) return false;

            return EnDeCrypt.DecryptString(dt.Rows[0]["MatKhau"].ToString().Trim(), "clinic").Equals(password);
        }

        public bool Check_Login(string userId, string password, ref string userName, ref string nhomIn, ref bool admin)
        {
            var dt = Get_User(userId);
            if (dt.Rows == null || dt.Rows.Count <= 0)
                return false;

            if (EnDeCrypt.DecryptString(dt.Rows[0]["MatKhau"].ToString().Trim(), "clinic").Equals(password))
            {
                userName = string.IsNullOrWhiteSpace(dt.Rows[0]["TenNhanVien"].ToString().Trim())
                    ? dt.Rows[0]["MaNguoiDung"].ToString().Trim()
                    : dt.Rows[0]["TenNhanVien"].ToString().Trim();
                admin = (bool) dt.Rows[0]["IsAdmin"];
                nhomIn = string.IsNullOrWhiteSpace(dt.Rows[0]["BoPhan"].ToString().Trim())
                    ? "A"
                    : dt.Rows[0]["BoPhan"].ToString().Trim();
                return true;
            }

            userName = string.Empty;
            return false;
        }

        public DataTable DanhSachDV_User(string userId)
        {
            var strSql =
                "select dv.MaPhanLoai,dv.MaNhap, dv.TenPhanLoai from QL_NguoiDung_LoaiDichVu u inner join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang dv on dv.MaPhanLoai = u.MaLoaiDichVu where u.MaNguoiDung ='" +
                userId.Trim() + "'";
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}