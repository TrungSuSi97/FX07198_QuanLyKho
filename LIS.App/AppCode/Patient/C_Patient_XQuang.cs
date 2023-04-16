using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Patient.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode.Patient
{
    class C_Patient_XQuang : C_Patient
    {
        
        public C_Patient_XQuang()
        {
        }

        public DataTable Get_Patient_XQuang(string _MaTiepNhan, string _DateIN, int _PrintType)
        {
            string strSQL = " select * from BenhNhan_TiepNhan t inner Join BenhNhan_CLS_XQuang tx on t.MaTiepNhan = tx.MaTiepNhan where 1=1";
            if (_MaTiepNhan != "")
                strSQL += "\n and T.MaTiepNhan ='" + _MaTiepNhan + "'";
            if (_DateIN != "")
            {
                strSQL += "\n and T.NgayTiepNhan = '" + _DateIN + "'";
            }
            if (_PrintType == 1)
            {
                //Đã in
                strSQL += "\n and Tx.DaInKQXQuang = 1";
            }
            else if (_PrintType == 2)
            {
                //Chưa in
                strSQL += "\n and Tx.DaInKQXQuang = 0";
            }
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
        private void Insert_Patient_XQuang(string _MaTiepNhan)
        {
            if (LabServices_Helper.Check_NotExits("select * from BenhNhan_CLS_XQuang where MaTiepNhan ='" + _MaTiepNhan + "'"))
            {
                string _strSQL = "insert into BenhNhan_CLS_XQuang (MaTiepNhan) select '" + _MaTiepNhan + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            }
        }
        public void Insert_ChiDinhXQuang(string MaTiepNhan, string MaVungChup, string _serviceID, float _DonGia)
        {
            if (LabServices_Helper.Check_NotExits("select * from KetQua_CLS_XQuang where MaTiepNhan = '" + MaTiepNhan.Trim() + "' and MaVungChup = '" + MaVungChup.Trim() + "'"))
            {
                Insert_Patient_XQuang(MaTiepNhan);
                string _strSQL = "insert into KetQua_CLS_XQuang (MaTiepNhan, MaKyThuatChup, MaVungChup,KetQUa, ThuTuInVungChup,  \n" +
                    " ThuTuInKyThuat, ThoiGianNhapChiDinh,DeNghi,KetLuan,GiaRieng, GiaChuan,MaPhanLoai )\n";
                _strSQL += " select '" + MaTiepNhan.Trim() + "' as MaTiepNhan, VC.MaKyThuatChup,VC.MaVungChup,VC. MauKetQua, vc.ThuTuIn as ThuTuInVungChup,  \n" +
                    "KT.ThuTuIn as ThuTuInKyThuat, getdate(), VC.DeNghiMacDinh as DeNghi, VC.KetLuanMacDinh as KetLuan," + (_DonGia < 0 ? "dv.GiaRieng" : _DonGia.ToString("N3")) + ", VC.GiaChuan,'" + ServiceType.ClsXQuang.ToString() + "'";
                _strSQL +="\nfrom {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC "+
                    "inner join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup KT on KT.MaKyThuatChup = VC.MaKyThuatChup \n" +
                    "inner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia DV on (DV.MaDichVu = VC.MaVungChup and DV.MaDoiTuongDichVu ='" + _serviceID.Trim() + "' and dv.MaLoaiDichVu='ClsXQuang') \n" +
                    "where VC.MaVungChup = '" + MaVungChup.Trim() + "' \n" +
                    "order by vc.ThuTuIn";
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Vùng chụp đã nhập trước !");
            }
        }
        public bool Delete_ChiDinhCLS_XQuang(string _MaTiepNhan, string _MaXN)
        {
            try
            {
                string strSQL = "delete KetQua_CLS_XQuang where MaTiepNhan ='" + _MaTiepNhan + "'" + (_MaXN == "" ? "" : " and MaVungChup='" + _MaXN + "'");
                DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
                DataProvider.ExecuteNonQuery(CommandType.Text, "Delete BenhNhan_CLS_XQuang where MaTiepNhan ='" + _MaTiepNhan + "' and (select count (*) from KetQua_CLS_XQuang where  MaTiepNhan ='" + _MaTiepNhan + "') = 0");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable DuLieuIn_XQuang(DataTable dtThongTin, string _MaVungChup, int _Index, bool _LayMailTheBN)
        {
            DataTable dtData = new DataTable();
            string _MaTiepNhan = dtThongTin.Rows[_Index]["MaTiepNhan"].ToString().Trim();
            string _TGNhap = DateTime.Parse(dtThongTin.Rows[_Index]["ThoiGianNhap"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string _MaBN = dtThongTin.Rows[_Index]["MaBN"].ToString().Trim();
            string strSQL = "";
            strSQL = "declare @MaTiepNhan varchar(20) \n";

        //    strSQL += "declare @MaVungChup varchar(30)\n";

            //strSQL += "declare @ThoiGianNhap datetime\n";
            ////Mã tiếp nhận đang kiểm tra
            strSQL += " set @MaTiepNhan='" + _MaTiepNhan + "'\n";

          //  strSQL += " set @MaVungChup='" + _MaVungChup + "'\n";

            strSQL += " select t.MaTiepNhan, t.MaBN,t.TenBN, t.ChanDoan,case when t.Tuoi > 1000 then year(t.NgayTiepNhan) - t.Tuoi else t.Tuoi end as Tuoi, case when t.GioiTinh = 'M' then N'Nam' when t.GioiTinh = 'F' then N'Nữ' else N'' end as GioiTinh \n";
            strSQL += ",t.DiaChi,t.Email as EmailBN, " + (_LayMailTheBN == true ? "t.Email" : "d.EmailDoiTuongDichVu") + " as MailTo,d.LamTieuDe,t.SDT,t.NgayTiepNhan\n";
            strSQL += ",TX.KetLuanXQuang,nv.TenNhanVien as BsChiDinh  \n";
            strSQL += ",k.KetLuan, k.DeNghi, k.KetQua,k.MaVungChup, k.MaKyThuatChup, k.XacNhanKQ,k.TrangThai, k.XacNhanKQ, k.NguoiXacNhan\n";
            strSQL += ",VC.TenVungChup,KT.TenKyThuatChup\n";
            strSQL += "from BenhNhan_TiepNhan t inner join KetQua_CLS_XQuang k on t.MaTiepNhan=k.MaTiepNhan\n";
            strSQL += "inner join BenhNhan_CLS_XQuang TX on TX.MaTiepNhan = T.MaTiepNhan \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD=nv.MaNhanVien\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu d on t.DoiTuongDichVu = d.MaDoiTuongDichVu\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup KT on k.MaKyThuatChup = KT.MaKyThuatChup\n";
            strSQL += "where t.MaTiepNhan = @MaTiepNhan";
            strSQL += (_MaVungChup.Trim().Length > 0 ? "\n and k.MaVungChup in (" + _MaVungChup + ")" : "");
            strSQL += "\norder by KT.ThuTuIn,k.ThuTuInVungChup\n";
            dtData = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtData;
        }
        public DataTable DuLieu_XQuang_DanhSach_KQVC(string _MaTiepNhan)
        {
            DataTable dt = new DataTable();

            string _strSQL = " select cast (0 as bit) as chon, MatiepNhan,k.MaVungChup, VC.TenVungChup,k.MaKyThuatChup,kt.TenKyThuatChup MaPhanLoai, k.* from KetQua_CLS_XQuang k left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup kt on kt.MaKyThuatCHup = k.MaKyThuatChup\n ";
            _strSQL += " where MatiepNhan = '" + _MaTiepNhan + "'";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];

            return dt;

        }
        public DataTable DuLieuTienSu(string _MaBN)
        {
            string strSQL = "";
            //Lấy tất cả các xét nghiệm của bệnh nhân
            strSQL = "select A.MaVungChup as MaChiDinh, A.TenVungChup as TenChiDinh";
            strSQL += "\nfrom (";
            strSQL += "\nselect distinct k.MaVungChup, n.TenVungChup";
            strSQL += "\n from KetQua_CLS_XQuang k inner join BenhNhan_TiepNhan t on k.MaTiepNhan = t.MaTiepNhan";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup n on n.MaVungChup = k.MaVungChup";
            strSQL += "\nwhere t.MaBN = '" + _MaBN + "'";
            strSQL += "\n) as A \nOrder by MaVungChup, TenVungChup";
            DataTable dtChiDinh = new DataTable();
            dtChiDinh = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            if (dtChiDinh.Rows.Count > 0)
            {
                RicherTextBox.RicherTextBox rc = new RicherTextBox.RicherTextBox();
                //Lấy danh sách lần tiếp nhận
                DataTable dtTiepNhan = new DataTable();
                strSQL = "select t.MaTiepNhan,t.NgayTiepNhan from BenhNhan_TiepNhan t inner join BenhNhan_CLS_XQuang tx on t.MaTiepNhan = tx.MaTiepNhan where t.MaBN = '" + _MaBN + "'";
                dtTiepNhan = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                string _ColumnName = "", _MaTiepNhan = "", _MaChiDinh_KQ = "";
                DataTable dtResult = new DataTable();
                for (int i = 0; i < dtTiepNhan.Rows.Count; i++)
                {
                    _MaChiDinh_KQ = "";
                    _MaTiepNhan = dtTiepNhan.Rows[i]["MaTiepNhan"].ToString().Trim();
                    _ColumnName = _MaTiepNhan + "(" + ((DateTime)dtTiepNhan.Rows[i]["NgayTiepNhan"]).ToString("dd/MM/yyyy") + ")";
                    dtChiDinh.Columns.Add(_ColumnName);
                    strSQL = "select k.KetQua,k.MaVungChup as MaChiDinh from KetQua_CLS_XQuang k where k.MaTiepNhan = '" + _MaTiepNhan + "'";
                    dtResult = new DataTable();
                    dtResult = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                    for (int y = 0; y < dtResult.Rows.Count; y++)
                    {
                        _MaChiDinh_KQ = dtResult.Rows[y]["MaChiDinh"].ToString().Trim().ToLower();
                        for (int r = 0; r < dtChiDinh.Rows.Count; r++)
                        {
                            if (dtChiDinh.Rows[r]["MaChiDinh"].ToString().Trim().ToLower().Equals(_MaChiDinh_KQ))
                            {
                                dtChiDinh.Rows[r][_ColumnName] = dtResult.Rows[y]["KetQua"].ToString().Trim();
                                break;
                            }
                        }
                    }
                }
            }
            return dtChiDinh;
        }

        public DataTable DuLieu_XQuang_DanhSachVC(string _MaTiepNhan)
        {
            DataTable dt = new DataTable();
            string _strSQL = " select cast (0 as bit) as chon, MatiepNhan,k.MaVungChup, VC.TenVungChup,k.MaKyThuatChup,kt.TenKyThuatChup MaPhanLoai from KetQua_CLS_XQuang k left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup kt on kt.MaKyThuatCHup = k.MaKyThuatChup\n ";
            _strSQL += " where MatiepNhan = '" + _MaTiepNhan + "'";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            return dt;

        }
        public void CapNhat_In_KQ_XQuang(string _MaTiepNhan, string _NguoiLamXQuang)
        {
            string _strSQL = "update BenhNhan_CLS_XQuang set ThoiGianInXQuang = getdate(), UserInXQuang='" + Utilities.ConvertSqlString(_NguoiLamXQuang) + "',LanInXQuang = LanInXQuang + 1, DaInKQXQuang = 1 where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_DuKQ_XQuang(string _MaTiepNhan)
        {
            string strSQL = " Update BenhNhan_CLS_XQuang set DuKQXQuang = 1 , ThoiGianDuKQXQuang = getdate() \n";
            strSQL += " where MaTiepNhan='" + _MaTiepNhan + "'\n";
            strSQL += "and (select COUNT(*) from KetQua_CLS_XQuang where MaTiepNhan='" + _MaTiepNhan + "' \n";
            strSQL += "and (KetQua is null or LEN(rtrim(ketqua)) = 0)) = 0";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
        }
        public void CapNhat_Valid_XQuang(string _MaTiepNhan)
        {
            string strSQL = " Update BenhNhan_CLS_XQuang set ValidKQXQuang = 1 , ThoiGianValidXQuang = getdate() \n";
            strSQL += " where MaTiepNhan='" + _MaTiepNhan + "'\n";
            strSQL += "and (select COUNT(*) from KetQua_CLS_XQuang where MaTiepNhan='" + _MaTiepNhan + "' \n";
            strSQL += "and XacNhanKQ = 0) = 0";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
        }
        public void CapNhat_KQ_XQuang(string _MaTiepNhan, string _MaVungChup, string _KetQua, string _NguoiKy, string _MayXQuang)
        {
            string _strSQL = "update KetQua_CLS_XQuang set KetQua = N'" + Utilities.ConvertSqlString(_KetQua) + "'";
            _strSQL += "\n,NguoiKy = " + (_NguoiKy.Trim() == "" ? "NULL" : "'" + _NguoiKy.Trim() + "'");
            _strSQL += "\n, ThoiGianNhapKQ = isnull(ThoiGianNhapKQ,getdate())";
            _strSQL += "\n, UserNhapKQ  = isnull(UserNhapKQ,'" + CommonAppVarsAndFunctions.UserID + "')";
            _strSQL += "\n,ThoiGianSuaKQ = case when ThoiGianNhapKQ is not null then getdate() else NULL end";
            _strSQL += "\n, UserSuaKQ  = case when UserNhapKQ is not null then '" + CommonAppVarsAndFunctions.UserID + "' else NULL end";
            _strSQL += "\n, MayXQuang =" + (_MayXQuang == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_MayXQuang) + "'");
            _strSQL +="\nwhere MaTiepNhan = '" + _MaTiepNhan + "' and MaVungChup='" + _MaVungChup + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_KetLuan_XQuang(string _MaTiepNhan, string _MaVungChup, string _KetLuan)
        {
            string _strSQL = "update KetQua_CLS_XQuang set KetLuan = N'" + Utilities.ConvertSqlString(_KetLuan) + "'  where MaTiepNhan = '" + _MaTiepNhan + "' and MaVungChup='" + _MaVungChup + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_DanhGia_XQuang(string _MaTiepNhan,string _DanhGia)
        {
            string _strSQL = "update BenhNhan_CLS_XQuang set KetLuanXQuang = N'" + Utilities.ConvertSqlString(_DanhGia) + "'  where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_DeNghi_XQuang(string _MaTiepNhan, string _MaVungChup, string _DeNghi)
        {
            string _strSQL = "update KetQua_CLS_XQuang set DeNghi = N'" + Utilities.ConvertSqlString(_DeNghi) + "'  where MaTiepNhan = '" + _MaTiepNhan + "' and MaVungChup='" + _MaVungChup + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void XacNhan_KQ_XQuang(string _MaTiepNhan, string _MaVungChup, string _TrangThai, bool _valid, string _NguoiKhaoSat)
        {
            string _strSQL = "update KetQua_CLS_XQuang set TrangThai = N'" + Utilities.ConvertSqlString(_TrangThai) + "', NguoiXacNhan='" + Utilities.ConvertSqlString(_NguoiKhaoSat) + "', XacNhanKQ = " + (_valid == true ? "1" : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "' and MaVungChup='" + _MaVungChup + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_SauChiDinh_XQuang(string _MaTiepNhan, string _TenTruong, bool _Co, string _User)
        {
            string _strSQL = "update BenhNhan_CLS_XQuang set " + _TenTruong + " = " + (_Co == true ? "1" + (_User != "" ? ",UserInXQuang= case len(UserInXQuang) > 0 then UserInXQuang + ',' + '" + _User + "' else '" + _User + "' end , LanInXQuang= LanInXQuang + 1  " : "") : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }

        public void CapNhat_ThuTien(string _MaTiepNhan, string _ChiDinh, bool _DaThu)
        {
            string _strSQL = "update KetQua_CLS_XQuang set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _strSQL += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaVungChup in (" + _ChiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt, bool _DefaultChecked)
        {
            dt = new DataTable();
            string _strSQL = "select * from (\n select distinct cast (" + (_DefaultChecked == true ? "1" : "0") + " as bit) as chon, MatiepNhan,cast(k.MaVungChup as varchar(20)) as MaChiDinh, VC.TenVungChup as TenChiDinh, k.MaKyThuatChup as MaNhomCLS, MaPhanLoai,GiaRieng,  DaThuTien, UserNhapCD,vc.ThuTuIn as ThuTuInVungChup,ThuTuInKyThuat, N'X QUANG' as LoaiChiDinh from KetQua_CLS_XQuang k left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup \n ";
            if (_filter != "")
            {
                _strSQL += " where " + _filter;
            }
            _strSQL += " \n) as A";
            _strSQL += " order by ThuTuInKyThuat,ThuTuInVungChup,MaNhomCLS,MaChiDinh";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Search_PatientXQuang(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID,string _Category,bool nhapTheoDanhSach, DataGridView dtg, BindingNavigator bv)
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,tx.KetLuanXQuang as KetLuan, tx.DuKQXQuang as DuKQ,tx.DaInKQXQuang as DaIn \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "inner join BenhNhan_CLS_XQuang tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            strSQL += "inner join KetQua_CLS_XQuang k on t.MaTiepNhan = k.MaTiepNhan \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D on t.DoiTuongDichVu = d.MaDoiTuongDichVu \n";
            strSQL += "where t.NgayTiepNhan between '" + _dtDateFrom.ToString("yyyy-MM-dd 00:00:00.00") + "' and '" + _dtDateTo.ToString("yyyy-MM-dd 00:00:00.00") + "'";
            if (_ServiceID != "")
            {
                strSQL += " and t.DoiTuongDichVu='" + _ServiceID.Trim() + "'";
            }
            if (_Seq != "")
            {
                strSQL += " and t.SEQ = '" + _Seq.Trim() + "'";
            }
            if (_Name != "")
            {
                strSQL += " and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            if (_FullRsult)
            {
                strSQL += " and tx.DuKQXQuang = 1";
            }
            if (_Printed)
            {
                strSQL += " and tx.DaInKQXQuang = 1";
            }
            if (_TestID != "")
            {
                strSQL += " and k.MaVungChup = '" + _TestID + "' \n";
            }
            if (_Category != "")
            {
                strSQL += " and k.MaKyThuatChup = '" + _Category + "' \n";
            }
            if (nhapTheoDanhSach)
                strSQL += "\n and NguonNhap ='" + InputSourceEnum.ByList.ToString() + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

    }
}
