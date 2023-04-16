using System.Collections.Generic;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Models;
using TPH.LIS.User.Models.Params;

namespace TPH.LIS.User.Repositories.Authorization
{
    public interface IAuthorizationRepository
    {
        bool CheckLogin(LoginParams loginParams);

        bool ResetPassword(string loginName, string newPassword);

        bool UpdatePassword(string loginName, string oldPassword, string newPassword);
       
        IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminWorkPlace();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminAnaLyzer();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetAllServiceTypes();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetGroupServiceCodeByAdmin();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetDepartmentServiceCodeByAdmin();
        IList<QL_NGUOIDUNG_PHANQUYEN> GetAdminPermissions(ServiceType serviceType);

        IList<QL_NGUOIDUNG_PHANQUYEN> GetUserPermissions(string loginName, ServiceType serviceType, FunctionGroup functionGroup);
    }
}
