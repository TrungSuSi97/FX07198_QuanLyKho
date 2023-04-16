using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TPH.Common.Converter;
using TPH.Common.StringCryptography;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Models;
using TPH.LIS.User.Models.Params;

namespace TPH.LIS.User.Repositories.Authorization
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        public bool CheckLogin(LoginParams loginParams)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@maNguoiDung", loginParams.Username),
                new SqlParameter("@matKhau",  loginParams.Password),
                new SqlParameter("@hethong",  loginParams.System),
                new SqlParameter("@ip",  loginParams.Ip)
            };

            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selUserLogin", para))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return false;
                }
                while (reader.Read())
                {
                    ((IDisposable)reader).Dispose();
                    return true;
                }
            }
            return false;
        }

        public bool ResetPassword(string loginName, string newPassword)
        {
            var sqlPara = new SqlParameter[]
                   {
                       new SqlParameter("@MaNguoiDung",loginName),
                       new SqlParameter("@MatKhau", EnDeCrypt.EncryptString(newPassword, AuthorizationConstant.Clinic) )
                   };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpNguoiDung_MatKhau", sqlPara) > -1;
        }

        public bool UpdatePassword(string loginName, string oldPassword, string newPassword)
        {
            //var isValid = CheckLogin(loginName, oldPassword);
            var isValid = CheckLogin(new LoginParams()
            {
                Username = loginName.Trim(),
                Password = oldPassword.Trim(),
                Ip = IpExtension.Ip(),
                System = string.Format("{0}-Upd Pass", CommonConstant.ApplicationName)
            });
            if (isValid)
            {
                return ResetPassword(loginName, newPassword);
            }
            return false;
        }
 
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetAllServiceTypes()
        {
            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen_DanhMucPhanLoaiChucNang"))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN("admin", StringConverter.ToString(reader["MaPhanLoai"])
                                , StringConverter.ToString(reader["MaLoaiDichVu"]), FunctionGroup.Nhom.ToString()));
                }
                ((IDisposable)reader).Dispose();
            }
            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminAnaLyzer()
        {
            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen_DanhMucMayXetNghiem"))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN("admin",reader["IDMay"].ToString()
                                , StringConverter.ToString(reader["tenmay"]), FunctionGroup.MayXetNghiem.ToString()));
                }
                ((IDisposable)reader).Dispose();
            }
            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetGroupServiceCodeByAdmin()
        {

            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();

            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen_DanhMucNhom"))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN("admin", StringConverter.ToString(reader["MaNhomDichVu"])
                        , StringConverter.ToString(reader["MaLoaiDichVu"]), FunctionGroup.Nhom.ToString()));
                }
                ((IDisposable)reader).Dispose();
            }

            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetDepartmentServiceCodeByAdmin()
        {
            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();

            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen_DanhMucBoPhanXetNghiem"))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN("admin", StringConverter.ToString(reader["MaBoPhan"])
                        , StringConverter.ToString(reader["MaLoaiDichVu"]), FunctionGroup.Nhom.ToString()));

                    // result.Add(StringConverter.ToString(reader["MaNhomCLS"]));
                }
                ((IDisposable)reader).Dispose();
            }

            return result;
        }

        public IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminPermissions(ServiceType serviceType)
        {
            var sqlPara = new SqlParameter[]
                   {
                       new SqlParameter("@MaLoaiDichVu", (serviceType == ServiceType.All?(object)DBNull.Value:serviceType.ToString()) )
                   };

            //var sqlQuery = "select * from {{TPH_Standard}}_System.dbo.ql_dm_phanquyen(nolock) where MaLoaiDichVu = '" + serviceType.ToString() + "' order by MaPhanQuyen";

            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen_DanhMucQuyen", sqlPara))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN("admin", StringConverter.ToString(reader["MaPhanQuyen"])
                     , StringConverter.ToString(reader["MaLoaiDichVu"]), FunctionGroup.PhanQuyen.ToString())); 
                }
                ((IDisposable)reader).Dispose();
            }

            return result;
        }

        public IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminWorkPlace()
        {
            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();

            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen_DanhMucKhuVuc"))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN("admin", StringConverter.ToString(reader["MaKhuVuc"])
                     , string.Empty, FunctionGroup.KhuVuc.ToString()));
                }
                ((IDisposable)reader).Dispose();
            }

            return result;
        }

        public IList<QL_NGUOIDUNG_PHANQUYEN> GetUserPermissions(string loginName, ServiceType serviceType, FunctionGroup functionGroup)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@MaNguoiDung", loginName),
                new SqlParameter("@MaNhomQuyen", (functionGroup == FunctionGroup.All?(object)DBNull.Value:functionGroup.ToString()) ),
                new SqlParameter("@MaLoaiDichVu", (serviceType == ServiceType.All?(object)DBNull.Value:serviceType.ToString()))
            };
            var result = new List<QL_NGUOIDUNG_PHANQUYEN>();

            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinh_PhanQuyen", sqlPara))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return result;
                }

                while (reader.Read())
                {
                    result.Add(new QL_NGUOIDUNG_PHANQUYEN(loginName, StringConverter.ToString(reader["MaPhanQuyen"])
                                 , StringConverter.ToString(reader["MaLoaiDichVu"]), StringConverter.ToString(reader["Manhomquyen"])));

                }
                ((IDisposable)reader).Dispose();
            }

            return result;
        }
    }
}