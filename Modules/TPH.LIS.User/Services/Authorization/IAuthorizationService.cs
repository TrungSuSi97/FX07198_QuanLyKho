using System.Collections.Generic;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Models;
using TPH.LIS.User.Models.Params;

namespace TPH.LIS.User.Services.Authorization
{
    public interface IAuthorizationService
    {
        bool CheckLogin(LoginParams loginParams);
        IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminWorkPlace();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminAnaLyzer();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetServiceTypesByLoginUser(string loginName);
        IList<QL_NGUOIDUNG_PHANQUYEN> GetGroupServicePermissionByLoginUser(string loginName, ServiceType serviceType);
        IList<QL_NGUOIDUNG_PHANQUYEN> GetdepartmentPermissionByLoginUser(string loginName, ServiceType serviceType);
        
        IList<QL_NGUOIDUNG_PHANQUYEN> GetUserWorkPlace(string loginName, ServiceType serviceType);
        IList<QL_NGUOIDUNG_PHANQUYEN> GetUserAnalyzer(string loginName);
        IList<QL_NGUOIDUNG_PHANQUYEN> GetUserPermissions(string loginName, ServiceType serviceType, FunctionGroup functionGroup);
        List<UserLogInPermission> DanhSachPhanQuyen(string LoginName);
    }
}
