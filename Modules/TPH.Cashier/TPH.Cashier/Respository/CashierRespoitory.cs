using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Cashier.CashierContanst;
using TPH.Cashier.Model;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Model;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.Cashier.Respository
{
    public class CashierRespository : ICashierRespository
    {
        public DataTable Data_DanhSachChiDinh_BL(string idBienLai, EnumThaoTacThuPhi bienlaiHoan, EnumChon HoanTien = EnumChon.TatCa, bool forDeleteAction = false, List<string> listMaDichVu = null)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("select cast(0 as bit) as chon, t.SEQ, cast(null as Image) as barcode, case when T.GioiTinh = 'F' then N'Nữ' else N'Nam' end as GT, T.[MaBN], T.[SoBHYT]");
            //sb.Append(" \n, T.MatiepNhan, T.[NgayHetHanBHYT], T.[TenBN], T.[SinhNhat], T.[Tuoi]");
            //sb.Append(" \n, T.[CoNgaySinh], T.[GioiTinh], T.[NgayTiepNhan], T.[ThoiGianNhap], T.[UserNhap]");
            //sb.Append(" \n, T.[DoiTuongDichVu], T.[DiaChi], T.[SoNha], T.[PhuongXa], T.[MaHuyen], T.[MaTinh], N'' as DocSoTien");
            //sb.Append(" \n, (select top 1 ReportLogo from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where MaDonVi = 'BL') as ReportLogo");
            //sb.Append(" \n, p.NgayThanhToan, p.ChietKhau, p.Conlai, p.ThanhToan, p.MayTinh, p.ThuNgan, p.NguoiTao");
            //sb.Append(" \n, d.MaDichVu, d.TenDichVu, d.ThuTuInNhom,d.ThuTuInDichVu, d.MaNhomDichVu, d.TenNhomDichVu");
            //sb.Append(" \n, d.MaPhanLoai, d.DonGia");
            //sb.Append(" \n, d.DonViTinh, d.SoLuong, d.ThanhTien");
            //sb.Append(" \n, Upper(C.TenPhanLoai) as TenPhanLoai, c.ThuTuIn as ThuTuInLoai, c.PhongKham");
            //if (bienlaiHoan == EnumThaoTacThuPhi.HoanTien)
            //{
            //    sb.Append(" \n, d.IDBienLaiHoan,  cast (1 as bit) as  DaThuTien, cast (1 as bit) as DaHoanTien");
            //    sb.Append("\nfrom p_payment_return_detail d");
            //}
            //else
            //{
            //    sb.Append("\n, d.DaThuTien, d.DaHoanTien");
            //    sb.Append("\nfrom p_payment_income_detail d");
            //}

            //sb.AppendFormat(" \nInner join p_payment p on  p.ID = {0}", (bienlaiHoan == EnumThaoTacThuPhi.HoanTien ? "d.IDBienLaiHoan" : "d.IDBienLaiThu"));
            //sb.Append(" \nInner join BenhNhan_TiepNhan T on T.MaTiepNhan = p.MaTiepNhan");
            //sb.Append(" \n left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang c on c.MaPhanLoai = d.MaPhanLoai");

            //sb.AppendFormat(" \nwhere p.ID = {0}", idBienLai);

            //if (bienlaiHoan == EnumThaoTacThuPhi.ThuTien)
            //{
            //    if (HoanTien == EnumChon.CoGiaTri)
            //    {
            //        sb.AppendFormat("\n and d.DaHoanTien = 1");
            //    }
            //    else if (HoanTien == EnumChon.KhongGiaTri)
            //    {
            //        sb.AppendFormat("\n and d.DaThuTien = 1");
            //    }
            //}
            //sb.Append(" \norder by  c.ThuTuIn, D.ThuTuInNhom, D.ThuTuInDichVu, d.MaNhomDichVu, d.MaDichVu");

            //var dt = DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    var sumMoney = (decimal)dt.Compute("sum(ThanhTien)", string.Empty);
            //    var readMoney = VNCurrency.ToString(sumMoney);
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        dr["DocSoTien"] = readMoney;
            //    }
            //}
            //return dt;
            var sqlPara = new SqlParameter[]
        {
                WorkingServices.GetParaFromOject("@IdBienLai",idBienLai)
                , WorkingServices.GetParaFromOject("@HoanTien",(bienlaiHoan == EnumThaoTacThuPhi.HoanTien))
                , WorkingServices.GetParaFromOject("@DaThucHienHoan",(HoanTien == EnumChon.CoGiaTri))
                , WorkingServices.GetParaFromOject("@LstMaXN",listMaDichVu == null ? null: string.Join(",",listMaDichVu))
        };
            var dt = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selThuPhi_ChiTietBienLai", sqlPara).Tables[0];
            if (dt.Rows.Count > 0)
            {
                var sumMoney = (decimal)dt.Compute("sum(ThanhTien)", string.Empty);
                var readMoney = VNCurrency.ToString(sumMoney);
                foreach (DataRow dr in dt.Rows)
                {
                    dr["DocSoTien"] = readMoney;
                }
            }
            return TinhToanChiDan(dt);
        }
        private DataTable TinhToanChiDan(DataTable dataSource)
        {
            DataTable datResult = dataSource.Copy();
            var dataTheoLoaiDichVu = dataSource.DefaultView.ToTable(true, new string[] { "MaPhanLoai" });
            foreach (DataRow drPhanLoai in dataTheoLoaiDichVu.Rows)
            {
                var dataNhomUuTien = WorkingServices.SearchResult_OnDatatable_NoneSort(dataSource, string.Format("MaPhanLoai = '{0}' and MucDoUuTien > -1", drPhanLoai["MaPhanLoai"].ToString()));
                if (dataNhomUuTien.Rows.Count > 0)
                {
                    dataNhomUuTien.DefaultView.Sort = "MucDoUuTien asc";
                    dataNhomUuTien = dataNhomUuTien.DefaultView.ToTable();

                    SetData_From_ChiDan(drPhanLoai["MaPhanLoai"].ToString(), dataNhomUuTien.Rows[0]["ChiDan"].ToString()
                        , dataNhomUuTien.Rows[0]["MucDoUuTien"].ToString(), ref datResult);
                }
                else
                {
                    dataNhomUuTien = WorkingServices.SearchResult_OnDatatable_NoneSort(dataSource, string.Format("MaPhanLoai = '{0}'", drPhanLoai["MaPhanLoai"].ToString()));
                    SetData_From_ChiDan(drPhanLoai["MaPhanLoai"].ToString(), dataNhomUuTien.Rows[0]["ChiDan"].ToString()
                        , dataNhomUuTien.Rows[0]["MucDoUuTien"].ToString(), ref datResult);
                }
            }
            return datResult;
        }
        private void SetData_From_ChiDan(string maLoai, string ChiDan, string thutuUutien, ref DataTable result)
        {
            int uutienCheck = int.Parse(string.IsNullOrEmpty(thutuUutien) ? "-1" : thutuUutien);

            foreach (DataRow dr in result.Rows)
            {
                int uutienR = int.Parse(string.IsNullOrEmpty(dr["MucDoUuTien"].ToString().Trim()) ? "-1" : dr["MucDoUuTien"].ToString().Trim());

                if (uutienR > uutienCheck)
                {
                    if (dr["MaPhanLoai"].ToString().Trim().Equals(maLoai.Trim()))
                    {
                        dr["PhongKham"] = ChiDan;
                    }
                }
            }
        }
        #region Tạo chi tiết biên lai
        public bool Them_ChiTiet_BienLai_Thu(string _MaTiepNhan
            , List<CashierItemSelected> lstSelctedItem, string idBienlaiThu, int phanTramChietKhau = 0, bool IsCalPhanTramChietKhau = false)
        {
            if (lstSelctedItem != null && lstSelctedItem.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into [p_payment_income_detail] ([IDBienLaiThu],[MaPhanLoai],[MaDichVu],[TenDichVu],[DonGia],[SoLuong],[ThanhTien],[GhiChu],[DonViTinh], [MaNhomDichVu], [TenNhomDichVu], [ThuTuInNhom], [ThuTuInDichVu],[PhanTramChietKhau],[IsCalPhanTramChietKhau],[ThucTra])");
                int count = 0;
                foreach (var item in lstSelctedItem)
                {
                    double thanhTien = item.ItemCost * item.ItemCount;
                    if (count > 0)
                        sb.Append("\nunion all");
                    count++;
                    sb.AppendFormat("\nselect {0} as IDBienLaiThu, '{1}' as MaPhanLoai, '{2}' as MaDichVu, N'{3}' as TenDichVu , {4} as DonGia, {5} as SoLuong, ({4} * {5}) as ThanhTien, {6} as GhiChu, {7} as DonViTinh, {8} as MaNhomDichVu, {9} as TenNhomDichVu, {10} as  ThuTuInNhom, {11} as ThuTuInDichVu,{12} as PhanTramChietKhau,{13} as IsCalPhanTramChietKhau,{14} as ThucTra"
                        , idBienlaiThu
                        , item.ItemCatagory
                        , item.ItemId
                        , Utilities.ConvertSqlString(item.ItemName)
                        , item.ItemCost
                        , item.ItemCount
                        , item.ItemNote == null ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(item.ItemNote))
                        , item.ItemUnit == null ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(item.ItemUnit))
                        , item.TestGruopId == null ? "NULL" : string.Format("'{0}'", Utilities.ConvertSqlString(item.TestGruopId))
                        , item.TestGroupName == null ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(item.TestGroupName))
                        , item.GroupSort
                        , item.ItemSort
                        , phanTramChietKhau
                        , IsCalPhanTramChietKhau ? 1 : 0
                        , IsCalPhanTramChietKhau ? thanhTien - ((thanhTien * phanTramChietKhau) / 100) : thanhTien
                        );
                }
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public bool Them_ChiTiet_BienLai_Hoan(string maTiepNhan, string IdBienLaiHoan, string IDBienLaiThu
            , List<CashierContanst.CashierItemSelected> lstSelctedItem)
        {
            if (lstSelctedItem != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Insert into p_payment_return_detail (IDBienLaiHoan, MaPhanLoai, MaDichVu, IDBienLaiThu, TenDichVu, DonGia, SoLuong, ThanhTien, GhiChu, DonViTinh, MaNhomDichVu, TenNhomDichVu, ThuTuInNhom, ThuTuInDichVu,PhanTramChietKhau,IsCalPhanTramChietKhau,ThucTra)");
                sb.AppendFormat("select {0} as IDBienLaiHoan, MaPhanLoai, MaDichVu, {1} as IDBienLaiThu, TenDichVu, DonGia, SoLuong, ThanhTien, GhiChu, DonViTinh, MaNhomDichVu, TenNhomDichVu, ThuTuInNhom, ThuTuInDichVu,PhanTramChietKhau,IsCalPhanTramChietKhau,ThucTra from p_payment_income_detail"
                   , IdBienLaiHoan, IDBienLaiThu);
                sb.AppendFormat("\n where IDBienLaiThu = {0}", IDBienLaiThu);
                string instr = string.Empty;
                foreach (var item in lstSelctedItem)
                {
                    instr += string.IsNullOrEmpty(instr) ? "'" : ",'";
                    instr += string.Format("{0}_{1}", item.ItemCatagory.Trim(), item.ItemId.Trim());
                    instr += "'";
                }
                sb.AppendFormat("\n and rtrim(MaPhanLoai) + '_' + rtrim(MaDichVu) in ({0}) ", instr);

                if (DataProvider.ExecuteQuery(sb.ToString()))
                {
                    sb = new StringBuilder();
                    sb.AppendFormat("update p_payment_income_detail set DaHoanTien = 1 , IDBienLaiHoan = {0}", IdBienLaiHoan);
                    sb.AppendFormat("\n where IDBienLaiThu = {0}", IDBienLaiThu);
                    sb.AppendFormat("\n and rtrim(MaPhanLoai) + '_' + rtrim(MaDichVu) in ({0}) ", instr);
                    if (DataProvider.ExecuteQuery(sb.ToString()))
                        return CapNhat_ThuTien(maTiepNhan, false, lstSelctedItem, IDBienLaiThu);
                }
                else
                    return false;
            }
            return false;
        }


        #endregion
        #region Cập nhật thu/không thu tiền
        public bool CapNhat_IDBienlai(string _MaTiepNhan
            , List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu)
        {
            string maChiDinhXn = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string maChiDinhSa = (lstSelctedItem == null ? string.Empty :
                string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)));
            string maChiDinhXq = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string maChiDinhNs = (lstSelctedItem == null ? string.Empty :
                string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)));
            string maChiDinhKb = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string maChiDinhDvKhac = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string chiDinhThuoc = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");

            bool okXn = true, okSa = true, okXquang = true, okNs = true, okKb = true, okdvkhac = true, okThuoc = true;

            if (!string.IsNullOrEmpty(maChiDinhXn.Trim()))
                okXn = CapNhat_IDBLThuTien_XetNghiem(_MaTiepNhan, maChiDinhXn, idBienlaiThu);
            if (!string.IsNullOrEmpty(maChiDinhSa.Trim()))
                okSa = CapNhat_IDBLThuTien_SieuAm(_MaTiepNhan, maChiDinhSa, idBienlaiThu);
            if (!string.IsNullOrEmpty(maChiDinhXq.Trim()))
                okXquang = CapNhat_IDBLThuTien_XQuang(_MaTiepNhan, maChiDinhXq, idBienlaiThu);
            if (!string.IsNullOrEmpty(maChiDinhNs.Trim()))
                okNs = CapNhat_IDBLThuTien_NoiSoi(_MaTiepNhan, maChiDinhNs, idBienlaiThu);
            if (!string.IsNullOrEmpty(maChiDinhKb.Trim()))
                okKb = CapNhat_IDBLThuTien_KhamBenh(_MaTiepNhan, maChiDinhKb, idBienlaiThu);
            if (!string.IsNullOrEmpty(maChiDinhDvKhac.Trim()))
                okdvkhac = CapNhat_IDBLThuTien_DvKhac(_MaTiepNhan, maChiDinhDvKhac, idBienlaiThu);
            if (!string.IsNullOrEmpty(chiDinhThuoc.Trim()))
                okThuoc = Update_IDBLThuTien_Thuoc(_MaTiepNhan, chiDinhThuoc, idBienlaiThu);

            if (okXn && okSa && okXquang && okNs && okKb && okdvkhac && okThuoc)
                return true;
            else
                return false;
        }
        //Cập nhật id biên lai cho dịch vụ
        private bool CapNhat_IDBLThuTien_XetNghiem(string maTiepNhan, string chiDinh, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update KetQua_CLS_XetNghiem set  IDBienLai = {0}", idBienlaiThu);
            _sqlQuery += "\nWhere MatiepNhan = '" + maTiepNhan + "' and MaXN in (" + chiDinh + ")";
            if ((int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > 0)
            {
                _sqlQuery = string.Format("update KetQua_CLS_XetNghiem set  IDBienLai = {0}", idBienlaiThu);
                _sqlQuery += "\nWhere MatiepNhan = '" + maTiepNhan + "' and ProfileID in (select distinct ProfileID from KetQua_CLS_XetNghiem where MaXN in  (" + chiDinh + "))";
                _sqlQuery += "\n and MaXN not in (" + chiDinh + ")";
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
            }
            return false;
        }
        private bool CapNhat_IDBLThuTien_SieuAm(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update KetQua_CLS_SieuAm set  IDBienLai = {0}", idBienlaiThu);
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaSoMau in (" + _ChiDinh + ")";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_IDBLThuTien_NoiSoi(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update KetQua_CLS_NoiSoi set IDBienLai = {0}", idBienlaiThu);
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi in (" + _ChiDinh + ")";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_IDBLThuTien_XQuang(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update KetQua_CLS_XQuang set IDBienLai = {0}", idBienlaiThu);
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaVungChup in (" + _ChiDinh + ")";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_IDBLThuTien_KhamBenh(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update KhamBenh_KetQua set IDBienLai = {0}", idBienlaiThu);
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaYeuCau in (" + _ChiDinh + ")";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_IDBLThuTien_DvKhac(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update KetQua_CLS_DVKhac set IDBienLai = {0}", idBienlaiThu);
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaDVKhac in (" + _ChiDinh + ")";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool Update_IDBLThuTien_Thuoc(string _MaTiepNhan, string _MaThuoc, string idBienlaiThu)
        {
            string _sqlQuery = string.Format("update THUPHI_THUOC set IDBienLai = {0} where MaThuoc in ({1})", idBienlaiThu, _MaThuoc);
            _sqlQuery += string.Format("\nand MaTiepNhan = '{0}'", _MaTiepNhan);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        //Cập nhật trạng thái thu tiền cho dịch vụ

        public bool CapNhat_ThuTien(string _MaTiepNhan, bool _thutien, List<CashierContanst.CashierItemSelected> lstSelctedItem, string idBienlaiThu)
        {
            string maChiDinhXn = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string maChiDinhSa = (lstSelctedItem == null ? string.Empty :
                string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)));
            string maChiDinhXq = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string maChiDinhNs = (lstSelctedItem == null ? string.Empty :
                string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)));
            string maChiDinhKb = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string maChiDinhDvKhac = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");
            string chiDinhThuoc = (lstSelctedItem == null ? string.Empty :
                string.Format("'{0}'", string.Join(",", lstSelctedItem.Where(x => x.ItemCatagory.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase)).Select(x => x.ItemId)).Replace(",", "','"))).Replace("''", "");

            bool okXn = true, okSa = true, okXquang = true, okNs = true, okKb = true, okdvkhac = true, okThuoc = true;

            if (!string.IsNullOrEmpty(maChiDinhXn.Trim()))
                okXn = CapNhat_ThuTien_XetNghiem(_MaTiepNhan, maChiDinhXn, idBienlaiThu, _thutien);
            if (!string.IsNullOrEmpty(maChiDinhSa.Trim()))
                okSa = CapNhat_ThuTien_SieuAm(_MaTiepNhan, maChiDinhSa, idBienlaiThu, _thutien);
            if (!string.IsNullOrEmpty(maChiDinhXq.Trim()))
                okXquang = CapNhat_ThuTien_XQuang(_MaTiepNhan, maChiDinhXq, idBienlaiThu, _thutien);
            if (!string.IsNullOrEmpty(maChiDinhNs.Trim()))
                okNs = CapNhat_ThuTien_NoiSoi(_MaTiepNhan, maChiDinhNs, idBienlaiThu, _thutien);
            if (!string.IsNullOrEmpty(maChiDinhKb.Trim()))
                okKb = CapNhat_ThuTien_KhamBenh(_MaTiepNhan, maChiDinhKb, idBienlaiThu, _thutien);
            if (!string.IsNullOrEmpty(maChiDinhDvKhac.Trim()))
                okdvkhac = CapNhat_ThuTien_DvKhac(_MaTiepNhan, maChiDinhDvKhac, idBienlaiThu, _thutien);
            if (!string.IsNullOrEmpty(chiDinhThuoc.Trim()))
                okThuoc = Update_ThuTien_Thuoc(_MaTiepNhan, chiDinhThuoc, idBienlaiThu, _thutien);

            if (okXn && okSa && okXquang && okNs && okKb && okdvkhac && okThuoc)
            {
                if (_thutien)
                    return CapNhatThuTienBenhNhan(_MaTiepNhan, true);
                else
                    return KiemTraDaThuTienChoBenhNhan(_MaTiepNhan, false);
            }
            else
                return false;
        }
        private bool CapNhatThuTienBenhNhan(string matiepnhan, bool thuTien)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update benhnhan_tiepnhan set dathutien = {0} where MatiepNhan = '{1}'", (thuTien ? "1" : "0"), Utilities.ConvertSqlString(matiepnhan));
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString()) > -1;
        }
        private bool KiemTraDaThuTienChoBenhNhan(string matiepnhan, bool thuTien)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Update benhnhan_tiepnhan set DaThuTien = {0} where (select count(*) from ketqua_cls_xetnghiem where MatiepNhan = '{1}' and DaThuTien = {0}) =  (select count(*) from ketqua_cls_xetnghiem where MatiepNhan = '{0}')", (thuTien ? "1" : "0"), Utilities.ConvertSqlString(matiepnhan));
            sb.AppendFormat("\n and (select count(*) from ketqua_cls_sieuam where MatiepNhan = '{1}' and DaThuTien = {0}) =  (select count(*) from ketqua_cls_sieuam where MatiepNhan = '{0}')", (thuTien ? "1" : "0"), Utilities.ConvertSqlString(matiepnhan));
            sb.AppendFormat("\n and (select count(*) from ketqua_cls_noisoi where MatiepNhan = '{1}' and DaThuTien = {0}) =  (select count(*) from ketqua_cls_noisoi where MatiepNhan = '{0}')", (thuTien ? "1" : "0"), Utilities.ConvertSqlString(matiepnhan));
            sb.AppendFormat("\n and (select count(*) from ketqua_cls_xquang where MatiepNhan = '{1}' and DaThuTien = {0}) =  (select count(*) from ketqua_cls_xquang where MatiepNhan = '{0}')", (thuTien ? "1" : "0"), Utilities.ConvertSqlString(matiepnhan));
            sb.AppendFormat("\n and (select count(*) from khambenh_ketqua where MatiepNhan = '{1}' and DaThuTien = {0}) =  (select count(*) from khambenh_ketqua where MatiepNhan = '{0}')", (thuTien ? "1" : "0"), Utilities.ConvertSqlString(matiepnhan));
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString()) > -1;
        }
        private bool CapNhat_ThuTien_XetNghiem(string maTiepNhan, string chiDinh, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = "update KetQua_CLS_XetNghiem set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += "\nWhere MatiepNhan = '" + maTiepNhan + "' and MaXN in (" + chiDinh + ")";
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
            if ((int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1)
            {
                _sqlQuery = "update KetQua_CLS_XetNghiem set DaThuTien = " + (_DaThu == true ? "1" : "0");
                _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
                _sqlQuery += "\nWhere MatiepNhan = '" + maTiepNhan + "' and ProfileID in (select distinct ProfileID from KetQua_CLS_XetNghiem where MaXN in  (" + chiDinh + "))";
                _sqlQuery += "\n and MaXN not in (" + chiDinh + ")";
                _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
            }
            return false;
        }
        private bool CapNhat_ThuTien_SieuAm(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaSoMau in (" + _ChiDinh + ")";
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_ThuTien_NoiSoi(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = "update KetQua_CLS_NoiSoi set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi in (" + _ChiDinh + ")";
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_ThuTien_XQuang(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = "update KetQua_CLS_XQuang set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaVungChup in (" + _ChiDinh + ")";
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_ThuTien_KhamBenh(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = "update KhamBenh_KetQua set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaYeuCau in (" + _ChiDinh + ")";
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool CapNhat_ThuTien_DvKhac(string _MaTiepNhan, string _ChiDinh, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = "update KetQua_CLS_DVKhac set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaDVKhac in (" + _ChiDinh + ")";
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        private bool Update_ThuTien_Thuoc(string _MaTiepNhan, string _MaThuoc, string idBienlaiThu, bool _DaThu)
        {
            string _sqlQuery = string.Format("update THUPHI_THUOC set DaThuTien = {0} where MaThuoc in ({1})", (_DaThu == true ? "1" : "0"), _MaThuoc);
            _sqlQuery += string.Format("\n, IDBienLai = {0}", (_DaThu ? idBienlaiThu : "0"));
            _sqlQuery += string.Format("\nand MaTiepNhan = '{0}'", _MaTiepNhan);
            _sqlQuery += string.Format("\n and IDBienLai = {0}", idBienlaiThu);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery) > -1;
        }
        #endregion
        #region  Biên Lai
        public string TaoBienLaiMoi(string maTiepNhan, string tenMayTinh, string thuNgan
            , decimal tongTien, decimal thanhToan, string ghiChu, EnumHinhThucThanhToan hinhThucThanhToan
            , EnumThaoTacThuPhi thaotac, string idBLHoan, string nguoiThuchien, decimal chietKhau = 0, int phanTramChietKhau = 0, bool IsCalPhanTramChietKhau = false)
        {
            var id = DateTime.Parse(DataProvider.ExecuteDataset(CommandType.Text, "select getdate() as SvrDate").Tables[0].Rows[0]["SvrDate"].ToString()).ToString("ddMMyyyyHHmmss");
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into p_payment ([ID],[MaTiepNhan],[NgayThanhToan],[ThanhToan],[ConLai],[TongTien],[GhiChu],[ThaoTac],[HinhThucThanhToan],[IdBLHoan],[NguoiTao],[ThuNgan],[MayTinh],[ChietKhau],[PhanTramChietKhau],[IsCalPhanTramChietKhau])");
            sb.AppendFormat("\n select {0},'{1}',getdate(),{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}"
                , id, maTiepNhan
                , thanhToan
                , (tongTien - thanhToan - chietKhau)
                , tongTien
                , (string.IsNullOrEmpty(ghiChu) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(ghiChu)))
                , (int)thaotac
                , (int)hinhThucThanhToan
                , (string.IsNullOrEmpty(idBLHoan) ? "NULL" : idBLHoan)
                , (string.IsNullOrEmpty(nguoiThuchien) ? "NULL" : string.Format("'{0}'", Utilities.ConvertSqlString(nguoiThuchien)))
                , (string.IsNullOrEmpty(thuNgan) ? "NULL" : string.Format("'{0}'", Utilities.ConvertSqlString(thuNgan)))
                , (string.IsNullOrEmpty(tenMayTinh) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(tenMayTinh)))
                , chietKhau, phanTramChietKhau, IsCalPhanTramChietKhau ? 1 : 0);
            if (DataProvider.ExecuteQuery(sb.ToString()))
                return id;
            else
                return string.Empty;
        }
        public bool CapNhat_ThuTien_ChiTiet_BienLai(string IDBienLaiThu
            , List<CashierContanst.CashierItemSelected> lstSelctedItem)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update p_payment_income_detail set DaThuTien = 1");
            string instr = string.Empty;
            foreach (var item in lstSelctedItem)
            {
                instr += string.IsNullOrEmpty(instr) ? "'" : ",'";
                instr += string.Format("{0}_{1}", item.ItemCatagory.Trim(), item.ItemId.Trim());
                instr += "'";
            }
            sb.AppendFormat("\n where IDBienLaiThu = {0}", IDBienLaiThu);
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool CapNhat_ThuTien_BienLai(string IDBienLaiThu)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update p_payment set DaThuTien = 1");
            sb.AppendFormat("\n where id = {0}", IDBienLaiThu);
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool CapNhat_ThanhToan_ChoBL(string idBienLaithu, decimal thanhToan)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update p_payment set ThanhToan = {0}, ConLai = TongTien - {0} where id = {1}", thanhToan, idBienLaithu);
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool XoaBienLai(string IdBienLai)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete p_payment where id = {0}", IdBienLai);
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_p_payment(string id, string matiepNhan, DateTime? tuNgayThangToan, DateTime? denNgayThanhToan, string userThuNgan)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select *,bn.seq as barcode, case when ThaoTac = {0} then N'THU TIỀN' else N'HOÀN TIỀN' end as TenThaoTac  from p_payment p inner join benhnhan_tiepnhan bn on bn.MaTiepNhan = p.MaTiepNhan  where 1=1", (int)EnumThaoTacThuPhi.ThuTien);
            if (!string.IsNullOrEmpty(id))
                sb.AppendFormat("\n and  p.id = {0}", id);
            if (!string.IsNullOrEmpty(matiepNhan))
                sb.AppendFormat("\n and  p.MaTiepNhan = '{0}'", matiepNhan);
            if (tuNgayThangToan != null && denNgayThanhToan != null)
                sb.AppendFormat("\n and p.NgayThanhToan between '{0}' and '{1}'", tuNgayThangToan.Value.ToString("yyyy-MM-dd 00:00:00.00"), denNgayThanhToan.Value.ToString("yyyy-MM-dd 23:59:59.99"));
            if (!string.IsNullOrEmpty(userThuNgan))
                sb.AppendFormat("\n and  p.ThuNgan = '{0}'", userThuNgan);

            return sb.ToString();
        }
        public DataTable Data_p_payment(string id, string matiepNhan, DateTime? tuNgayThangToan, DateTime? denNgayThanhToan, string userThuNgan)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_p_payment(id, matiepNhan, tuNgayThangToan, denNgayThanhToan, userThuNgan)).Tables[0];
            return dtData;
        }
        public P_PAYMENT Get_Info_p_payment(string id)
        {
            DataTable dt = Data_p_payment(id, string.Empty, null, null, string.Empty);
            P_PAYMENT obj = new P_PAYMENT();
            if (dt.Rows.Count > 0)

            {
                obj.Id = NumberConverter.To<Int64>(dt.Rows[0]["id"]);
                obj.Matiepnhan = StringConverter.ToString(dt.Rows[0]["matiepnhan"]);
                obj.Ngaythanhtoan = (DateTime)dt.Rows[0]["ngaythanhtoan"];
                obj.Thanhtoan = (decimal)dt.Rows[0]["thanhtoan"];
                obj.Conlai = (decimal)dt.Rows[0]["conlai"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["ghichu"].ToString()))
                    obj.Ghichu = StringConverter.ToString(dt.Rows[0]["ghichu"]);
                obj.Thaotac = NumberConverter.To<int>(dt.Rows[0]["thaotac"]);
                obj.Hinhthucthanhtoan = NumberConverter.To<int>(dt.Rows[0]["hinhthucthanhtoan"]);
                obj.Tongtien = (decimal)dt.Rows[0]["tongtien"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["idblhoan"].ToString()))
                    obj.Idblhoan = NumberConverter.To<int>(dt.Rows[0]["idblhoan"]);
                obj.Maytinh = StringConverter.ToString(dt.Rows[0]["maytinh"]);
                obj.Thungan = StringConverter.ToString(dt.Rows[0]["thungan"]);
            }
            return obj;
        }
        public bool XoaBienLaiVaHoanTien(string IdBienLaiThu)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete p_payment_return_detail where idBienLaiHoan = (select ID from p_payment where IdBLHoan = {0}) ", IdBienLaiThu);
            if (DataProvider.ExecuteQuery(sb.ToString()))
            {
                sb = new StringBuilder();
                sb.AppendFormat("Delete p_payment where IdBLHoan = {0} ", IdBienLaiThu);
                if (DataProvider.ExecuteQuery(sb.ToString()))
                {
                    sb = new StringBuilder();
                    sb.AppendFormat("Delete p_payment_income_detail where IDBienLaiThu = {0} ", IdBienLaiThu);
                    if (DataProvider.ExecuteQuery(sb.ToString()))
                    {
                        sb = new StringBuilder();
                        sb.AppendFormat("Delete p_payment where ID = {0} ", IdBienLaiThu);
                        return DataProvider.ExecuteQuery(sb.ToString());
                    }
                }
            }
            return false;
        }
        public bool XoaChiTietBienLaiVaHoanTien(string IdBienLai, string maDichVu)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete p_payment_return_detail where idBienLaiHoan = (select ID from p_payment where IdBLHoan = {0}) and MaDichVu = '{1}' ", IdBienLai, maDichVu);
            if (DataProvider.ExecuteQuery(sb.ToString()))
            {
                sb = new StringBuilder();
                sb.AppendFormat("Delete p_payment where IdBLHoan = {0} and (select  count (*) from p_payment_return_detail where idBienLaiHoan = (select ID from p_payment where IdBLHoan = {0})) = 0 ", IdBienLai);
                if (DataProvider.ExecuteQuery(sb.ToString()))
                {
                    sb = new StringBuilder();
                    sb.AppendFormat("Delete p_payment_income_detail where IDBienLaiThu = {0} and MaDichVu = '{1}' ", IdBienLai, maDichVu);
                    if (DataProvider.ExecuteQuery(sb.ToString()))
                    {
                        sb = new StringBuilder();
                        sb.AppendFormat("Delete p_payment where ID = {0} and (select  count (*) from p_payment_income_detail where IDBienLaiThu = {0}) = 0 ", IdBienLai);
                        return DataProvider.ExecuteQuery(sb.ToString());
                    }
                }
            }
            return false;
        }

        public bool TinhToanLaiTienThu(string IdBienLai, EnumThaoTacThuPhi thaotac)
        {
            StringBuilder sb = new StringBuilder();
            if (thaotac == EnumThaoTacThuPhi.ThuTien)
            {
                sb.Append("update p_payment ");
                sb.AppendFormat("\nset TongTien = (select sum(thanhtien) from p_payment_income_detail d where d.IDBienLaiThu = {0})", IdBienLai);
                sb.AppendFormat("\n, ThanhToan = (select sum(thanhtien) from p_payment_income_detail d where d.IDBienLaiThu = {0})", IdBienLai);
                sb.AppendFormat("\nwhere ID = {0}", IdBienLai);
            }
            else
            {
                sb.Append("\nupdate p_payment");
                sb.AppendFormat("\nset TongTien = (select sum(thanhtien) from p_payment_return_detail d where d.IDBienLaiHoan = {0})", IdBienLai);
                sb.AppendFormat("\n, ThanhToan = (select sum(thanhtien) from p_payment_income_detail d where d.IDBienLaiThu = {0})", IdBienLai);
                sb.AppendFormat("\nwhere ID = {0}", IdBienLai);
            }
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        #endregion
        #region P_Payment_Lock
        public decimal Lay_IDKetChuyen()
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT cast(CONVERT(float, GETDATE())* 1000000 as decimal) as idketchuyen");
            var data = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];
            return NumberConverter.To<decimal>(data.Rows[0]["idketchuyen"]);
        }
        public bool Update_Lock_payment(decimal idKetChuyen, string thuNgan, DateTime ngayThu)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendFormat("Update P_PAYMENT set DaKetChuyen = 1, IDKetChuyen = {0}", idKetChuyen);
            sqlQuery.AppendLine();
            sqlQuery.AppendFormat("where ThuNgan = '{0}' and NgayThanhToan between  '{1} 00:00:00' and '{1} 23:59:59'", thuNgan, ngayThu.ToString("yyyy-MM-dd"));
            return DataProvider.ExecuteQuery(sqlQuery.ToString());
        }
        public BaseModel Insert_p_payment_lock(P_PAYMENT_LOCK objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("insert into  P_PAYMENT_LOCK (");
            sqlQuery.Append("\nIdketchuyen");
            sqlQuery.Append("\n,Thoigianketchuyen");
            sqlQuery.Append("\n,Maytinh");
            sqlQuery.Append("\n,Thungan");
            sqlQuery.Append("\n,Tongtienthu");
            sqlQuery.Append("\n,Tongno");
            sqlQuery.Append("\n,Tongtienhoan");
            sqlQuery.Append("\n,Tongthucthu");
            sqlQuery.Append("\n,Ngaythutien");
            sqlQuery.Append("\n,Tongsobienlaithu");
            sqlQuery.Append("\n,Tongsobienlaihoan");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", objInfo.Idketchuyen.ToString());
            sqlQuery.AppendFormat("\n ,{0}", "'" + objInfo.Thoigianketchuyen.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Maytinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Maytinh.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Thungan.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (string.IsNullOrEmpty(objInfo.Tongtienthu.ToString()) ? "0" : objInfo.Tongtienthu.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (string.IsNullOrEmpty(objInfo.Tongno.ToString()) ? "0" : objInfo.Tongno.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (string.IsNullOrEmpty(objInfo.Tongtienhoan.ToString()) ? "0" : objInfo.Tongtienhoan.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (string.IsNullOrEmpty(objInfo.Tongthucthu.ToString()) ? "0" : objInfo.Tongthucthu.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", "'" + objInfo.Ngaythutien.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tongsobienlaithu < 0 ? "0" : objInfo.Tongsobienlaithu.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tongsobienlaihoan < 0 ? "0" : objInfo.Tongsobienlaihoan.ToString()));

            if (!DataProvider.CheckExisted("select top 1 * from p_payment_lock where Idketchuyen =  " + objInfo.Idketchuyen.ToString()))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã bị trùng"
                };
            }
        }
        public bool Update_p_payment_lock(P_PAYMENT_LOCK objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update P_PAYMENT_LOCK set");
            sb.AppendFormat("\n Idketchuyen = {0}", objInfo.Idketchuyen.ToString());
            sb.AppendFormat("\n, Thoigianketchuyen = {0}", "'" + objInfo.Thoigianketchuyen.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sb.AppendFormat("\n, Maytinh = {0}", (objInfo.Maytinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Maytinh.ToString()) + "'"));
            sb.AppendFormat("\n, Thungan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Thungan.ToString()) + "'");
            sb.AppendFormat("\n, Tongtienthu = {0}", (string.IsNullOrEmpty(objInfo.Tongtienthu.ToString()) ? "0" : objInfo.Tongtienthu.ToString()));
            sb.AppendFormat("\n, Tongno = {0}", (string.IsNullOrEmpty(objInfo.Tongno.ToString()) ? "0" : objInfo.Tongno.ToString()));
            sb.AppendFormat("\n, Tongtienhoan = {0}", (string.IsNullOrEmpty(objInfo.Tongtienhoan.ToString()) ? "0" : objInfo.Tongtienhoan.ToString()));
            sb.AppendFormat("\n, Tongthucthu = {0}", (string.IsNullOrEmpty(objInfo.Tongthucthu.ToString()) ? "0" : objInfo.Tongthucthu.ToString()));
            sb.AppendFormat("\n, Ngaythutien = {0}", "'" + objInfo.Ngaythutien.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sb.AppendFormat("\n, Tongsobienlaithu = {0}", (objInfo.Tongsobienlaithu < 0 ? "0" : objInfo.Tongsobienlaithu.ToString()));
            sb.AppendFormat("\n, Tongsobienlaihoan = {0}", (objInfo.Tongsobienlaihoan < 0 ? "0" : objInfo.Tongsobienlaihoan.ToString()));
            sb.Append("\nwhere Idketchuyen =  " + objInfo.Idketchuyen.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool Delete_p_payment_lock(P_PAYMENT_LOCK objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete p_payment_lock");
            sb.AppendFormat("\n where Idketchuyen = {0}", objInfo.Idketchuyen.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_p_payment_lock(string idketchuyen)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from p_payment_lock where 1=1");
            if (!string.IsNullOrEmpty(idketchuyen))
                sb.AppendFormat("\n and  idketchuyen = {0}", "'" + idketchuyen + "'");
            return sb.ToString();
        }
        public DataTable Data_p_payment_lock(string idketchuyen)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_p_payment_lock(idketchuyen)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_p_payment_lock(DataGridView dtg, BindingNavigator bv, string idketchuyen)
        {
            DataTable dtData = new DataTable();
            dtData = Data_p_payment_lock(idketchuyen);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_p_payment_lock(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idketchuyen)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_p_payment_lock(idketchuyen), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_p_payment_lock(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idketchuyen)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_p_payment_lock(idketchuyen);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public P_PAYMENT_LOCK Get_Info_p_payment_lock(string idketchuyen)
        {
            DataTable dt = Data_p_payment_lock(idketchuyen);
            P_PAYMENT_LOCK obj = new P_PAYMENT_LOCK();
            if (dt.Rows.Count > 0)
            {
                obj.Idketchuyen = NumberConverter.To<decimal>(dt.Rows[0]["idketchuyen"]);
                obj.Thoigianketchuyen = (DateTime)dt.Rows[0]["thoigianketchuyen"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["maytinh"].ToString()))
                    obj.Maytinh = StringConverter.ToString(dt.Rows[0]["maytinh"]);
                obj.Thungan = StringConverter.ToString(dt.Rows[0]["thungan"]);
                obj.Tongtienthu = NumberConverter.To<decimal>(dt.Rows[0]["tongtienthu"]);
                obj.Tongno = NumberConverter.To<decimal>(dt.Rows[0]["tongno"]);
                obj.Tongtienhoan = NumberConverter.To<decimal>(dt.Rows[0]["tongtienhoan"]);
                obj.Tongthucthu = NumberConverter.To<decimal>(dt.Rows[0]["tongthucthu"]);
                obj.Ngaythutien = (DateTime)dt.Rows[0]["ngaythutien"];
                obj.Tongsobienlaithu = NumberConverter.To<int>(dt.Rows[0]["tongsobienlaithu"]);
                obj.Tongsobienlaihoan = NumberConverter.To<int>(dt.Rows[0]["tongsobienlaihoan"]);
            }
            return obj;
        }


        #endregion
        public DataTable DanhSachXetNghiemDaDuyet(string maTiepNhan, string lstMaXN)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                , WorkingServices.GetParaFromOject("@lstMaXN",lstMaXN)
              };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_XetNghiemDaDuyet", sqlPara).Tables[0];
        }
        public int CapNhat_InBL(string idBienLai, string userIn, bool dain)
        {
            var i = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updInBienLai",
                new SqlParameter("@ID", idBienLai),
                new SqlParameter("@dain", dain),
                new SqlParameter("@userinbl", userIn));
            return i;
        }
    }
}
