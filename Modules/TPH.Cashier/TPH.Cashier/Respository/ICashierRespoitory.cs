using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.Cashier.CashierContanst;
using TPH.Cashier.Model;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;

namespace TPH.Cashier.Respository
{
    public interface ICashierRespository
    {
        DataTable Data_DanhSachChiDinh_BL(string idBienLai, EnumThaoTacThuPhi bienlaiHoan, EnumChon HoanTien = EnumChon.TatCa, bool forDeleteAction = false, List<string> listMaDichVu = null);
        bool Them_ChiTiet_BienLai_Thu(string _MaTiepNhan
            , List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu, int phanTramChietKhau = 0, bool IsCalPhanTramChietKhau = false);
        bool Them_ChiTiet_BienLai_Hoan(string maTiepNhan, string IdBienLaiHoan, string IDBienLaiThu
           , List<CashierContanst.CashierItemSelected> lstSelctedItem);
        #region Cập nhật thu/không thu tiền
        bool CapNhat_IDBienlai(string _MaTiepNhan
            , List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu);
        bool CapNhat_ThuTien(string _MaTiepNhan, bool _thutien
                , List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu);
        #endregion
        #region Biên lai
        string TaoBienLaiMoi(string maTiepNhan, string tenMayTinh, string thuNgan
            , decimal tongTien, decimal thanhToan, string ghiChu
            , EnumHinhThucThanhToan hinhThucThanhToan, EnumThaoTacThuPhi thaotac, string idBLHoan, string nguoiThuchien, decimal chietKhau = 0, int phanTramChietKhau = 0, bool IsCalPhanTramChietKhau = false);
        bool CapNhat_ThuTien_ChiTiet_BienLai(string IDBienLaiThu
            , List<CashierContanst.CashierItemSelected> lstSelctedItem);
        bool CapNhat_ThuTien_BienLai(string IDBienLaiThu);

        bool CapNhat_ThanhToan_ChoBL(string idBienLaithu, decimal thanhToan);
        bool XoaBienLai(string IdBienLai);
        DataTable Data_p_payment(string id, string matiepNhan, DateTime? tuNgayThangToan, DateTime? denNgayThanhToan, string userThuNgan);
        P_PAYMENT Get_Info_p_payment(string id);
        bool XoaBienLaiVaHoanTien(string IdBienLaiThu);
        bool XoaChiTietBienLaiVaHoanTien(string IdBienLai, string maDichVu);
        bool TinhToanLaiTienThu(string IdBienLai, EnumThaoTacThuPhi thaotac);

        #endregion
        #region P_Payment_Lock
        decimal Lay_IDKetChuyen();
        bool Update_Lock_payment(decimal idKetChuyen, string thuNgan, DateTime ngayThu);
        BaseModel Insert_p_payment_lock(P_PAYMENT_LOCK objInfo);
        bool Update_p_payment_lock(P_PAYMENT_LOCK objInfo);
        bool Delete_p_payment_lock(P_PAYMENT_LOCK objInfo);
        DataTable Data_p_payment_lock(string idketchuyen);
        DataTable Get_Data_p_payment_lock(DataGridView dtg, BindingNavigator bv, string idketchuyen);
        DataTable Get_Data_p_payment_lock(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idketchuyen);
        DataTable Get_Data_p_payment_lock(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idketchuyen);
        P_PAYMENT_LOCK Get_Info_p_payment_lock(string idketchuyen);
        #endregion
        DataTable DanhSachXetNghiemDaDuyet(string maTiepNhan, string lstMaXN);
        int CapNhat_InBL(string idBienLai, string userIn, bool dain);

    }
}
