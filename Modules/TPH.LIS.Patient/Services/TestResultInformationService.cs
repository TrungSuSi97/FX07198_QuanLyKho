using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Repositories;

namespace TPH.LIS.Patient.Services
{
    public class TestResultInformationService : ITestResultInformationService
    {

        private readonly ITestResultInformationRepository _iketqua_cls_xetnghiem_service; 
        public TestResultInformationService() : this(null) { }
        public TestResultInformationService(TestResultInformationRepository ketqua_cls_xetnghiem_repository)
        {
            _iketqua_cls_xetnghiem_service = ketqua_cls_xetnghiem_repository ?? new TestResultInformationRepository();
        }
        public bool Insert_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo)
        {
            return _iketqua_cls_xetnghiem_service.Insert_ketqua_cls_xetnghiem(objInfo);
        }
        public bool Update_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo)
        {

            return _iketqua_cls_xetnghiem_service.Update_ketqua_cls_xetnghiem(objInfo);
        }
        public bool Delete_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo)
        {

            return _iketqua_cls_xetnghiem_service.Delete_ketqua_cls_xetnghiem(objInfo);
        }
        public DataTable Data_ketqua_cls_xetnghiem(string matiepnhan, string maxn)
        {

            return _iketqua_cls_xetnghiem_service.Data_ketqua_cls_xetnghiem(matiepnhan, maxn);
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem(DataGridView dtg, BindingNavigator bv, string matiepnhan, string maxn)
        {

            return _iketqua_cls_xetnghiem_service.Get_Data_ketqua_cls_xetnghiem(dtg, bv, matiepnhan, maxn);
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string matiepnhan, string maxn)
        {

            return _iketqua_cls_xetnghiem_service.Get_Data_ketqua_cls_xetnghiem(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, matiepnhan, maxn);
        }
        public KETQUA_CLS_XETNGHIEM Get_Info_ketqua_cls_xetnghiem(string matiepnhan, string maxn)
        {

            return _iketqua_cls_xetnghiem_service.Get_Info_ketqua_cls_xetnghiem(matiepnhan, maxn);
        }
        public KETQUA_CLS_XETNGHIEM Get_Info_ketqua_cls_xetnghiem(DataTable dt)
        {

            return _iketqua_cls_xetnghiem_service.Get_Info_ketqua_cls_xetnghiem(dt);
        }
        public bool UpdateTrangThaiDoiTacNhanMau(string maTiepNhan, string doiTacNhanMau, string maXN, DateTime ngayGui)
        {
            return _iketqua_cls_xetnghiem_service.UpdateTrangThaiDoiTacNhanMau(maTiepNhan, doiTacNhanMau, maXN, ngayGui);
        }
    }
}
