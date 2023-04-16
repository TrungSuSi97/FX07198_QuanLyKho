using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Patient.Model;

namespace TPH.LIS.Patient.Services
{
    public interface ITestResultInformationService
    {
        bool Insert_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo);
        bool Update_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo);
        bool Delete_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo);
        DataTable Data_ketqua_cls_xetnghiem(string matiepnhan, string maxn);
        DataTable Get_Data_ketqua_cls_xetnghiem(DataGridView dtg, BindingNavigator bv, string matiepnhan, string maxn);
        DataTable Get_Data_ketqua_cls_xetnghiem(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string matiepnhan, string maxn);
        KETQUA_CLS_XETNGHIEM Get_Info_ketqua_cls_xetnghiem(string matiepnhan, string maxn);
        KETQUA_CLS_XETNGHIEM Get_Info_ketqua_cls_xetnghiem(DataTable dt);
        bool UpdateTrangThaiDoiTacNhanMau(string maTiepNhan, string doiTacNhanMau, string maXN, DateTime ngayGui);
    }
}
