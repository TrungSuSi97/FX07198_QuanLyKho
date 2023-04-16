using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TPH.Common.Converter;
using TPH.Common.StringCryptography;
using TPH.LIS.Common;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Models;
using TPH.LIS.User.Models.Params;
using TPH.LIS.User.Repositories.Authorization;
using TPH.LIS.User.Services.UserManagement;

namespace TPH.LIS.User.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAuthorizationRepository _authorization;

        public AuthorizationService(): this(null)
        {

        }

        public AuthorizationService(AuthorizationRepository authorization)
        {
            _authorization = authorization ?? new AuthorizationRepository();
        }

        public bool CheckLogin(LoginParams loginParams)
        {
            loginParams.Password = EnDeCrypt.EncryptString(StringConverter.ToString(loginParams.Password), AuthorizationConstant.Clinic);
            return _authorization.CheckLogin(loginParams);
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminWorkPlace()
        {
            return _authorization.GetAdminWorkPlace();
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminAnaLyzer()
        {
            return _authorization.GetAdminAnaLyzer();
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetServiceTypesByLoginUser(string loginName)
        {
            return _authorization.GetUserPermissions(loginName, ServiceType.All, FunctionGroup.LoaiChucNang);
        }

        public IList<QL_NGUOIDUNG_PHANQUYEN> GetGroupServicePermissionByLoginUser(
            string loginName, ServiceType serviceType)
        {
            IList<QL_NGUOIDUNG_PHANQUYEN> result = loginName.Equals(UserConstant.Admin, StringComparison.OrdinalIgnoreCase) ?
                _authorization.GetGroupServiceCodeByAdmin() :
                  _authorization.GetUserPermissions(loginName, serviceType, FunctionGroup.Nhom);

            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetdepartmentPermissionByLoginUser(string loginName, ServiceType serviceType)
        {
            IList<QL_NGUOIDUNG_PHANQUYEN> result = loginName.Equals(UserConstant.Admin, StringComparison.OrdinalIgnoreCase) ?
                _authorization.GetDepartmentServiceCodeByAdmin() :
                  _authorization.GetUserPermissions(loginName, serviceType, FunctionGroup.BoPhan);

            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetUserWorkPlace(string loginName, ServiceType serviceType)
        {
            IList<QL_NGUOIDUNG_PHANQUYEN> result = loginName.Equals(UserConstant.Admin, StringComparison.OrdinalIgnoreCase) ?
                _authorization.GetAdminWorkPlace() :
                _authorization.GetUserPermissions(loginName, serviceType, FunctionGroup.KhuVuc);

            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetUserAnalyzer(string loginName)
        {
            IList<QL_NGUOIDUNG_PHANQUYEN> result = loginName.Equals(UserConstant.Admin, StringComparison.OrdinalIgnoreCase) ?
                _authorization.GetAdminAnaLyzer() :
                _authorization.GetUserPermissions(loginName, ServiceType.ClsXetNghiem, FunctionGroup.MayXetNghiem);

            return result;
        }
        public IList<QL_NGUOIDUNG_PHANQUYEN> GetUserPermissions(string loginName, ServiceType serviceType, FunctionGroup functionGroup)
        {
            IList<QL_NGUOIDUNG_PHANQUYEN> result = loginName.Equals(UserConstant.Admin, StringComparison.OrdinalIgnoreCase) ?
                _authorization.GetAdminPermissions(serviceType) :
                _authorization.GetUserPermissions(loginName, serviceType, functionGroup);

            return result;
        }
        private readonly IUserManagementService _user = new UserManagementService();
        public List<UserLogInPermission> DanhSachPhanQuyen(string LoginName)
        {
            var lst = new List<UserLogInPermission>();
            var data = new DataTable();
            if (LoginName.Equals(UserConstant.Admin, StringComparison.OrdinalIgnoreCase))
            {
                data = _user.Data_PhanQuyen_ChuaAddNhom("--None--");

            }
            else
            {
                data = _user.Data_DanhSach_QuyenUser(LoginName);
            }
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    var maPhanquyen = dr["MaPhanQuyen"].ToString();
                    var loaiPhanQuyen = dr["MaNhomQuyen"].ToString();
                    var heThong = dr["HeThong"].ToString();
                    var loaiDichVu = dr["MaLoaiDichVu"].ToString();
                    if (lst.Where(x => x.NhomQuyen.Equals(loaiPhanQuyen, StringComparison.OrdinalIgnoreCase)
                    && x.HeThong.Equals(heThong, StringComparison.OrdinalIgnoreCase)
                    && x.LoaiDichVu.Equals(loaiDichVu, StringComparison.OrdinalIgnoreCase)
                    ).Any())
                    {
                        var obj = lst.Where(x => x.NhomQuyen.Equals(loaiPhanQuyen) && x.HeThong.Equals(heThong, StringComparison.OrdinalIgnoreCase) && x.LoaiDichVu.Equals(loaiDichVu, StringComparison.OrdinalIgnoreCase)).First();
                        obj.DanhSachQuyen.Add(maPhanquyen);
                    }
                    else
                    {
                        lst.Add(new UserLogInPermission
                        {
                            HeThong = dr["HeThong"].ToString(),
                            NhomQuyen = loaiPhanQuyen,
                            LoaiDichVu = loaiDichVu,
                            DanhSachQuyen = new List<string>() { maPhanquyen }
                        });
                    }
                }
            }
            return lst;
        }
    }
}