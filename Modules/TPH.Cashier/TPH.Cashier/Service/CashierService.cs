using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.Cashier.CashierContanst;
using TPH.Cashier.Model;
using TPH.Cashier.Respository;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Model;

namespace TPH.Cashier.Service
{
    public class CashierService : ICashierService
    {
        ICashierRespository _iCashier = new CashierRespository();

        public DataTable Data_DanhSachChiDinh_BL(string idBienLai, EnumThaoTacThuPhi bienlaiHoan, EnumChon HoanTien = EnumChon.TatCa, bool forDeleteAction = false, List<string> listMaDichVu = null)
        {
            return _iCashier.Data_DanhSachChiDinh_BL(idBienLai, bienlaiHoan, HoanTien,forDeleteAction, listMaDichVu);
        }
        #region Cập nhật thu/không thu tiền
        public bool CapNhat_IDBienlai(string _MaTiepNhan
             , List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu)
        {
          return  _iCashier.CapNhat_IDBienlai(_MaTiepNhan, lstSelctedItem, idBienlaiThu);
        }
       public bool CapNhat_ThuTien(string _MaTiepNhan, bool _thutien
                , List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu)
        {
            return _iCashier.CapNhat_ThuTien(_MaTiepNhan, _thutien
                , lstSelctedItem, idBienlaiThu);
        }

        #endregion
        #region Biên lai
        public string TaoBienLaiMoi(string maTiepNhan, string tenMayTinh, string thuNgan
              , decimal tongTien, decimal thanhToan, string ghiChu
              , EnumHinhThucThanhToan hinhThucThanhToan, EnumThaoTacThuPhi thaotac, string idBLHoan, string nguoiThuchien)
        {
            return _iCashier.TaoBienLaiMoi(maTiepNhan, tenMayTinh, thuNgan, tongTien, thanhToan
                , ghiChu, hinhThucThanhToan, thaotac, idBLHoan, nguoiThuchien);
        }

        public string TaoBienlaiThuTien(string maTiepNhan, List<CashierContanst.CashierItemSelected> lstSelctedItem
            , string tenMayTinh, string thuNgan
              , decimal tongTien, decimal thanhToan, string ghiChu
              , EnumHinhThucThanhToan hinhThucThanhToan, string nguoiThuchien, decimal chietKhau = 0, int phanTramChietKhau = 0, bool IsCalPhanTramChietKhau = false)
        {
            //1. Tạo biên lai mới
            var idBienlaiThu = _iCashier.TaoBienLaiMoi(maTiepNhan, tenMayTinh, thuNgan
                , tongTien, thanhToan, ghiChu, hinhThucThanhToan, EnumThaoTacThuPhi.ThuTien, string.Empty, nguoiThuchien,chietKhau, phanTramChietKhau, IsCalPhanTramChietKhau);
            if (!string.IsNullOrEmpty(idBienlaiThu))
            { 
                //2. tạo chi tiết thu
                if (_iCashier.Them_ChiTiet_BienLai_Thu(maTiepNhan, lstSelctedItem, idBienlaiThu))
                {
                    //3. Cập nhật IDBienLai cho các dịch vụ
                    if (_iCashier.CapNhat_IDBienlai(maTiepNhan, lstSelctedItem, idBienlaiThu))
                        return idBienlaiThu;
                    else
                    {
                        //4. Bị lỗi thì xóa hết thông tin
                        _iCashier.XoaBienLai(idBienlaiThu);
                        return string.Empty;
                    }
                }
                else
                {    //4. Bị lỗi thì xóa hết thông tin
                    _iCashier.XoaBienLai(idBienlaiThu);
                    return string.Empty;
                }

            }
            else
                return string.Empty;
        }

        public string TaoBienLaiHoanTien(string maTiepNhan, List<CashierContanst.CashierItemSelected> lstSelctedItem
       , string tenMayTinh, string thuNgan
         , decimal tongTien, decimal thanhToan, string ghiChu, string IdBienlai, string nguoiThuchien)
        {
            //1. Lấy thông tin biên lai 
            var obj = _iCashier.Get_Info_p_payment(IdBienlai);
            //2. Tạo biên lai hoàn
            var idBienlaiHoan = _iCashier.TaoBienLaiMoi(maTiepNhan, tenMayTinh, thuNgan
                , tongTien, thanhToan, ghiChu
                ,(EnumHinhThucThanhToan)Enum.Parse(typeof(EnumHinhThucThanhToan), obj.Hinhthucthanhtoan.ToString())
                , EnumThaoTacThuPhi.HoanTien, IdBienlai, nguoiThuchien);
            if (!string.IsNullOrEmpty(idBienlaiHoan))
            {
                // 3.Insert dịch vụ hoàn tiền vào danh sách
                if (_iCashier.Them_ChiTiet_BienLai_Hoan(maTiepNhan, idBienlaiHoan, IdBienlai, lstSelctedItem))
                    return idBienlaiHoan;
                else
                {
                    //3.Bị lỗi thì xóa hết thông tin
                    _iCashier.XoaBienLai(idBienlaiHoan);
                    return string.Empty;
                }
            }
            // else
            return idBienlaiHoan;
        }
       public bool CapNhat_ThuTien_ChiTiet_BienLai(string IDBienLaiThu
            , List<CashierContanst.CashierItemSelected> lstSelctedItem)
        {
            return _iCashier.CapNhat_ThuTien_ChiTiet_BienLai(IDBienLaiThu, lstSelctedItem);
        }
        public bool CapNhat_ThuTien_BienLai(string IDBienLaiThu)
        {
            return _iCashier.CapNhat_ThuTien_BienLai(IDBienLaiThu);
        }
        public bool CapNhat_ThanhToan_ChoBL(string idBienLaithu, decimal thanhToan)
        {
            return _iCashier.CapNhat_ThanhToan_ChoBL(idBienLaithu, thanhToan);
        }
        public DataTable Data_p_payment(string id, string matiepNhan, DateTime? tuNgayThangToan, DateTime? denNgayThanhToan, string userThuNgan)
        {

            return _iCashier.Data_p_payment(id, matiepNhan,tuNgayThangToan,denNgayThanhToan,userThuNgan);
        }

        public P_PAYMENT Get_Info_p_payment(string id)
        {
            return _iCashier.Get_Info_p_payment(id);
        }
        public bool XoaBienLaiVaHoanTien(string IdBienLaiThu)
        {
            return _iCashier.XoaBienLaiVaHoanTien(IdBienLaiThu);
        }
        public bool XoaChiTietBienLaiVaHoanTien(string IdBienLai, string maDichVu)
        {
            return _iCashier.XoaChiTietBienLaiVaHoanTien(IdBienLai, maDichVu);
        }
        public bool TinhToanLaiTienThu(string IdBienLai, EnumThaoTacThuPhi thaotac)
        {
            return _iCashier.TinhToanLaiTienThu(IdBienLai, thaotac);
        }
        #endregion
        #region P_Payment_Lock
        public decimal Lay_IDKetChuyen()
        {
            return _iCashier.Lay_IDKetChuyen();
        }
        public bool Update_Lock_payment(decimal idKetChuyen, string thuNgan, DateTime ngayThu)
        {
            return _iCashier.Update_Lock_payment(idKetChuyen, thuNgan, ngayThu);
        }
        public BaseModel Insert_p_payment_lock(P_PAYMENT_LOCK objInfo)
        {
            return _iCashier.Insert_p_payment_lock(objInfo);
        }

        public bool Update_p_payment_lock(P_PAYMENT_LOCK objInfo)
        {

            return _iCashier.Update_p_payment_lock(objInfo);
        }

        public bool Delete_p_payment_lock(P_PAYMENT_LOCK objInfo)
        {

            return _iCashier.Delete_p_payment_lock(objInfo);
        }

        public DataTable Data_p_payment_lock(string idketchuyen)
        {

            return _iCashier.Data_p_payment_lock(idketchuyen);
        }

        public DataTable Get_Data_p_payment_lock(DataGridView dtg, BindingNavigator bv, string idketchuyen)
        {

            return _iCashier.Get_Data_p_payment_lock(dtg, bv, idketchuyen);
        }

        public DataTable Get_Data_p_payment_lock(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idketchuyen)
        {

            return _iCashier.Get_Data_p_payment_lock(dtg, bv, ref sqlDataAdapter, ref dtData, idketchuyen);
        }

        public DataTable Get_Data_p_payment_lock(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idketchuyen)
        {

            return _iCashier.Get_Data_p_payment_lock(cbo, _ValueColumn, _DisplayColumn, ColumnsName, ColumnsWidth, txt, LinkColumnIndex, idketchuyen);
        }

        public P_PAYMENT_LOCK Get_Info_p_payment_lock(string idketchuyen)
        {

            return _iCashier.Get_Info_p_payment_lock(idketchuyen);
        }

        #endregion
        public DataTable DanhSachXetNghiemDaDuyet(string maTiepNhan, string lstMaXN)
        {
            return _iCashier.DanhSachXetNghiemDaDuyet(maTiepNhan, lstMaXN);
        }
        public int CapNhat_InBL(string idBienLai, string userIn, bool dain)
        {
            return _iCashier.CapNhat_InBL(idBienLai, userIn, dain);
        }
    }
}
