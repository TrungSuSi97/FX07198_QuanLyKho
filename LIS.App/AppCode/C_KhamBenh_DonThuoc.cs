using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode
{
    class C_KhamBenh_DonThuoc
    {
        
        public C_KhamBenh_DonThuoc()
        {
        }


        // BẢNG KhamBenh_BenhNhan
        // Getdata 
        public void Get_KhamBenh_BenhNhan(DataGridView dtg, BindingNavigator bv, string _DateIN, string maTiepNhan, int _PrintType)
        {
            DataTable dt = new DataTable();
            string strSQL = "select * from BenhNhan_TiepNhan t inner join  KhamBenh_BenhNhan k on t.MaTiepNhan = k.MaTiepNhan where 1 = 1";
            if (maTiepNhan != "")
                strSQL += "\n and T.MaTiepNhan = '" + Utilities.ConvertSqlString(maTiepNhan) + "'";
            if (_DateIN != "")
            {
                strSQL += "\n and T.NgayTiepNhan = '" + _DateIN + "'";
            }
            if (_PrintType == 1)
            {
                //Đã in
                strSQL += "\n and K.DaInKQKham = 1";
            }
            else if (_PrintType == 2)
            {
                //Chưa in
                strSQL += "\n and k.DaInKQKham = 0";
            }
            strSQL += " order by NgayTiepNhan";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_KhamBenh_BenhNhan(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt)
        {
            dt = new DataTable();
            string _strSQL = " select * from KhamBenh_BenhNhan where 0=0 ";
            _strSQL += _filter;
            _strSQL += " order by matiepnhan";
            LabServices_Helper.BindContex(da, ref dt, _strSQL, ref dtg, ref bv);
        }
        public void Get_KhamBenh_BenhNhan(CustomComboBox cbo, string _filter, ref DataTable dt)
        {
            dt = new DataTable();
            string _strSQL = " select * from KhamBenh_BenhNhan where 1 = 1";
            if (_filter != "")
            {
                _strSQL += _filter;
            }
            _strSQL += " order by matiepnhan";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            cbo.ColumnNames = "matiepnhan";
            cbo.ColumnWidths = "50";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "matiepnhan", "matiepnhan");
        }
        public void Get_KhamBenh_BenhNhan(CustomComboBox cbo, string _filter)
        {
            string _strSQL = " select * from KhamBenh_BenhNhan where 1 = 1";
            if (_filter != "")
            {
                _strSQL += _filter;
            }
            _strSQL += " order by matiepnhan";
            DataTable dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            cbo.ColumnNames = "matiepnhan";
            cbo.ColumnWidths = "50";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "matiepnhan", "matiepnhan");
        }

        // Get KhamBenh_KetQua
        public string SQL_KhamBenh_KetQua(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau)
        {
            string _strSQL = "";
            _strSQL = " select k.*,T.[CanNang],T.[ChieuCao],T.[HuyetAp],T.[Mach],T.[NhipTho],T.[NhietDo] from KhamBenh_KetQua k inner join KhamBenh_BenhNhan t on (k.MaTiepNhan = T.MaTiepNhan and k.MaDonVi = T.MaDonvi) ";
            _strSQL += "\nwhere K.MaTiepNhan = '" + _MaTiepNhan + "' and K.MaDonVi='" + _MaDonVi + "' and K.MaYeuCau ='" + _MaYeuCau + "'";
            return _strSQL;
        }
        public DataTable Data_KhamBenh_KetQua(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_KhamBenh_KetQua(_MaTiepNhan, _MaDonVi, _MaYeuCau)).Tables[0];
        }

        // Insert KhamBenh_BenhNhan
        public bool Insert_KhamBenh_BenhNhan(string _MaTiepNhan, string _MaDonVi)
        {
            try
            {
                string _strSQL = " INSERT INTO [KhamBenh_BenhNhan]";
                _strSQL += Environment.NewLine + "([MaTiepNhan]";
                _strSQL += Environment.NewLine + " ,[MaDonVi]";
                _strSQL += Environment.NewLine + ",[TGNhap])";
                _strSQL += Environment.NewLine + " Select ";
                _strSQL += Environment.NewLine + "'" + _MaTiepNhan + "'";
                _strSQL += Environment.NewLine + ",'" + _MaDonVi + "'";
                _strSQL += Environment.NewLine + ",getdate()";
                _strSQL += ";";
                _strSQL += Environment.NewLine + "INSERT INTO [KhamBenh_KetQua]";
                _strSQL += Environment.NewLine + "([MaTiepNhan]";
                _strSQL += Environment.NewLine + ",[MaDonVi]";
                _strSQL += Environment.NewLine + ",[TGNhap])";
                _strSQL += Environment.NewLine + " Select ";
                _strSQL += Environment.NewLine + "'" + _MaTiepNhan + "'";
                _strSQL += Environment.NewLine + ",'" + _MaDonVi + "'";
                _strSQL += Environment.NewLine + ",getdate()";
                if (LabServices_Helper.Check_NotExits("select top 1 * from KhamBenh_BenhNhan where [MaTiepNhan]='" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "'"))
                {
                    return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        // Update BenhNhan
        public bool Update_KhamBenh_BenhNhan_Valid(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, bool _Valid, string _UserValid)
        {
            bool _ok = false;
            string _strSQL = "";
            _strSQL = "Update KhamBenh_KetQua set";
            _strSQL += "\nXacNhanKQ = " + (_Valid == true ? "1" : "0");
            _strSQL += Environment.NewLine + ",[TGXacNhan]= " + (_Valid == false ? "[TGXacNhan]" : "getdate()");
            _strSQL += "\nwhere MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "' and MaYeuCau ='" + _MaYeuCau.Trim() + "'";
            _ok = (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
            if (_ok)
            {
                //check update for all
                _strSQL = "Update KhamBenh_BenhNhan set ";
                _strSQL += Environment.NewLine + "[ValidKQKham]=";
                if (_Valid)
                {
                    _strSQL += "case when (select count(*) from KhamBenh_KetQua where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "' and XacNhanKQ = 0)= 0 then 1 else 0 end ";
                }
                else
                    _strSQL += "0";

                _strSQL += Environment.NewLine + ",[ThoiGianValid]= " + (_Valid == false ? "[ThoiGianValid]" : "getdate()");
                _strSQL += Environment.NewLine + " where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "'";
                _ok = (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
            }
            return _ok;
        }

        public bool Update_KhamBenh_BenhNhan_In(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, string _UserIn, bool _DaIn)
        {
            string _strSQL = "";
            _strSQL = "Update KhamBenh_KetQua set";
            _strSQL += "\nDaInKQ = " + (_DaIn == true ? "1" : "0");
            _strSQL += Environment.NewLine + ",[TGIn]= " + (_DaIn == false ? "[TGIn]" : "getdate()");
            _strSQL += "\nwhere MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "' and MaYeuCau ='" + _MaYeuCau.Trim() + "'";
            if ((bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL))
            {
                //check update for all
                _strSQL = "Update KhamBenh_BenhNhan set " + Environment.NewLine;
                _strSQL += Environment.NewLine + "[DaInKQKham]= ";
                if (_DaIn)
                {
                    _strSQL += "case when (select count(*) from KhamBenh_KetQua where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "' and DaInKQ = 0)= 0 then 1 else 0 end ";
                }
                else
                    _strSQL += "0";
                _strSQL += Environment.NewLine + ",[ThoiGianIn]=" + (_DaIn == false ? "[ThoiGianIn]" : "getdate()");
                _strSQL += Environment.NewLine + ",[UserIn]=" + (_DaIn == true ? "[UserIn]" : "'" + _UserIn + "'");
                _strSQL += Environment.NewLine + ",[LanIn]=" + (_DaIn == true ? "[LanIn]" : "[LanIn] + 1");
                _strSQL += Environment.NewLine + " where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "'";
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
            }
            return false;
        }
        public bool Update_KhamCoBan(string _MaTiepNhan, string _MaDonVi, string _CanNang,
          string _ChieuCao, string _HuyetAp, string _Mach, string _NhipTho, string _NhietDo)
        {

            string _strSQL = " UPDATE KhamBenh_BenhNhan set [CanNang] = " + (_CanNang == "" ? "NULL" : _CanNang);
            _strSQL += Environment.NewLine + ",[ChieuCao] = " + (_ChieuCao == "" ? "NULL" : _ChieuCao);
            _strSQL += Environment.NewLine + ",[HuyetAp] = " + (_HuyetAp == "" ? "NULL" : "N'" + _HuyetAp + "'");
            _strSQL += Environment.NewLine + ",[Mach] = " + (_Mach == "" ? "NULL" : "N'" + _Mach + "'");
            _strSQL += Environment.NewLine + ",[NhipTho] = " + (_NhipTho == "" ? "NULL" : "N'" + _NhipTho + "'");
            _strSQL += Environment.NewLine + ",[NhietDo] =" + (_NhietDo == "" ? "NULL" : "N'" + _NhietDo + "'");
            _strSQL += Environment.NewLine + " Where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "'";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);

        }
        //Update Ket Qua
        public bool Update_KhamBenh_KetQua(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, string _MaBacSi, string _BSDieuTri, DateTime _NgayDieuTri, string _ChanDoan, string _DeNghi, string _GhiChu,
            bool _HenTaiKham, DateTime _NgayTaiKham)
        {
            string _strSQL = " UPDATE [KhamBenh_KetQua]";
            _strSQL += Environment.NewLine + "SET [BSDieuTri] = " + (_BSDieuTri == "" ? "NULL" : "N'" + _BSDieuTri + "'");
            _strSQL += Environment.NewLine + ",[MaBacSi] = " + (_MaBacSi == "" ? "NULL" : "'" + _MaBacSi + "'");
            _strSQL += Environment.NewLine + ",[NgayDieuTri] = '" + _NgayDieuTri.ToString("yyyy-MM-dd") + "'";
            _strSQL += Environment.NewLine + ",[ChanDoan] = " + (_ChanDoan == "" ? "NULL" : "N'" + Utils.ConvertString(_ChanDoan) + "'");
            _strSQL += Environment.NewLine + ",[DeNghi] = " + (_DeNghi == "" ? "NULL" : "N'" + _DeNghi + "'");
            _strSQL += Environment.NewLine + ",[GhiChu] = " + (_GhiChu == "" ? "NULL" : "N'" + _GhiChu + "'");
            _strSQL += Environment.NewLine + ",[HentaiKham] = " + (_HenTaiKham == true ? "1" : "0");
            _strSQL += Environment.NewLine + ",[NgayTaiKham] = " + (_HenTaiKham == false ? "NULL" : "'" + _NgayTaiKham.ToString("yyyy-MM-dd") + "'");
            _strSQL += Environment.NewLine + " Where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "' and MaYeuCau ='" + _MaYeuCau + "'";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
        }
        // Delete 
        public bool Delete_KhamBenh_BenhNhan(string _MaTiepNhan)
        {
            string _strSQL = "Delete from KhamBenh_BenhNhan" + Environment.NewLine;
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and matiepnhan =  " + (_MaTiepNhan == "" ? "''" : "'" + _MaTiepNhan + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
        }

        // BẢNG KhamBenh_DonThuoc
        // Getdata 
        public string SQL_KhamBenh_DonThuoc(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, string _NhomThuoc, string _MaThuoc)
        {
            string _strSQL = " select * from KhamBenh_DonThuoc where MaTiepNhan ='" + _MaTiepNhan + "' and MaDonVi ='" + _MaDonVi + "' and  MaYeuCau ='" + _MaYeuCau + "'";
            if (_NhomThuoc != "")
            {
                _strSQL += "\n and NhomThuoc = '" + _NhomThuoc + "'";
            }
            if (_MaThuoc != "")
            {
                _strSQL += "\n and MaThuoc in(" + _MaThuoc + ")";
            }
            return _strSQL;
        }
        public DataTable Data_KhamBenh_DonThuoc(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, string _NhomThuoc, string _MaThuoc)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_KhamBenh_DonThuoc(_MaTiepNhan, _MaDonVi, _MaYeuCau, _NhomThuoc, _MaThuoc)).Tables[0];
        }
        public void Get_KhamBenh_DonThuoc(DataGridView dtg, BindingNavigator bv, ref DataTable dt, string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, string _NhomThuoc, string _MaThuoc)
        {
            dt = new DataTable();
            dt = Data_KhamBenh_DonThuoc(_MaTiepNhan, _MaDonVi, _MaYeuCau, _NhomThuoc, _MaThuoc);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable Get_KhamBenh_DonThuoc(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, string _NhomThuoc, string _MaThuoc)
        {
            return Data_KhamBenh_DonThuoc(_MaTiepNhan, _MaDonVi, _MaYeuCau, _NhomThuoc, _MaThuoc);
        }

        public void Get_KhamBenh_DonThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt)
        {
            dt = new DataTable();
            string _strSQL = " select * from KhamBenh_DonThuoc where 0=0 ";
            _strSQL += _filter;
            _strSQL += " order by matiepnhan,tenthuoc";
            LabServices_Helper.BindContex(da, ref dt, _strSQL, ref dtg, ref bv);
        }
        public DataTable Get_KhamBenh_DonThuoc_History(string maBN, string _MaTiepNhan = "")
        {
            DataTable dt = new DataTable();
            string _strSQL = " select k.TGNhap as NgayTiepNhan,t.*, t.gia * t.soluong as ThanhTien,c.TenCachDung, (select TienThanhToan from khambenh_benhnhan b where b.MaTiepNhan = t.MaTiepNhan) as  TienThanhToan, Convert(varchar,k.TGNhap,103)  + N' - Thanh toán: ' +  FORMAT((select TienThanhToan from khambenh_benhnhan b where b.MaTiepNhan = t.MaTiepNhan), '###,###,###.##' ) as MaTiepNhanThanhTien from KhamBenh_DonThuoc t inner join benhnhan_tiepnhan b on t.matiepnhan=b.MaTiepNhan inner join KhamBenh_KetQua k on b.MaTiepNhan=k.MaTiepNhan left join{{TPH_Standard}}_Dictionary.dbo.dm_Thuoc_CachDung c on t.CachDung=c.ID \n";
            _strSQL += string.Format("where b.MaBN='{0}'\n", maBN);
            if (!string.IsNullOrEmpty(_MaTiepNhan))
            {
                _strSQL += string.Format("and t.MaTiepNhan <>'{0}'\n", _MaTiepNhan);
            }
            _strSQL += "\n order by k.TGNhap DESC";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            return dt;
        }
        public bool Update_ThanhToan(string maTiepnhan, double thantoan)
        {
            var sqlQuery = string.Format("update khambenh_benhnhan set TienThanhToan = {0}", thantoan);
            sqlQuery += string.Format(", ThanhTien = (select sum(t.gia * t.soluong) from KhamBenh_DonThuoc t where t.Matiepnhan ='{0}') where Matiepnhan ='{0}'", maTiepnhan);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery) > -1;
        }
        // Insert 
        public bool Insert_KhamBenh_DonThuoc(string _matiepnhan, string _madonvi, string _mayeucau, string _ID, bool _Profile, string madonviThucHien)
        {
            string _strSQL = "", alias = (_Profile == true ? "P" : "T");
            _strSQL += Environment.NewLine + "  INSERT INTO KhamBenh_DonThuoc";
            _strSQL += Environment.NewLine + "(	[MaTiepNhan],[MaDonVi],[MaYeuCau] ,[MaThuoc]";
            _strSQL += Environment.NewLine + ",[TenThuoc],[MaVatTu],[MaGocThuoc]";
            _strSQL += Environment.NewLine + ",[DonViTinh],[CachDung]";
            _strSQL += Environment.NewLine + ",[Sang],[Trua],[Chieu]";
            _strSQL += Environment.NewLine + ",[Toi],[SoLuong],[Gia],[TGNhap] )";
            _strSQL += Environment.NewLine + "SELECT '" + _matiepnhan + "'";
            _strSQL += Environment.NewLine + ",'" + _madonvi + "','" + _mayeucau + "',T.[MaThuoc]";
            _strSQL += Environment.NewLine + ",T.[TenThuoc],T.[MaVatTu],T.[MaGocThuoc],[DonViTinh]";
            _strSQL += Environment.NewLine + "," + alias + ".[CachDung]," + alias + ".[Sang]," + alias + ".[Trua]," + alias + ".[Chieu]," + alias + ".[Toi]";
            _strSQL += Environment.NewLine + ", cast(case when isnumeric(isnull(" + alias + ".[Sang],'0')) = 1 then isnull(" + alias + ".[Sang],'0') else 0 end  as float)";
            _strSQL += " + cast(case when isnumeric(isnull(" + alias + ".[Trua],'0')) = 1 then isnull(" + alias + ".[Trua],'0') else 0 end  as float)";
            _strSQL += " + cast(case when isnumeric(isnull(" + alias + ".[Chieu],'0')) = 1 then isnull(" + alias + ".[Chieu],'0') else 0 end  as float)";
            _strSQL += " + cast(case when isnumeric(isnull(" + alias + ".[Toi],'0')) = 1 then isnull(" + alias + ".[Toi],'0') else 0 end  as float) as SoLuong";
            _strSQL += ", T.Gia";
            _strSQL += Environment.NewLine + " ,GETDATE()";
            _strSQL += Environment.NewLine + "FROM";
            if (_Profile)
            {
                _strSQL += Environment.NewLine + "DM_Thuoc_Profile_ChiTiet P inner join{{TPH_Standard}}_Dictionary.dbo.dm_Thuoc T on (P.MaThuoc = T.MaThuoc and P.MaProfile = '" + _ID + "')";
                _strSQL += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia d on(d.MaDichVu = T.MaThuoc and d.MaDoiTuongDichVu = (select top 1 DoiTuongDichVu from benhnhan_tiepnhan where matiepnhan = '" + _matiepnhan + "')";
                _strSQL += "\n and d.MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'";
                if (CommonAppVarsAndFunctions.IsAdmin == false)
                    _strSQL += string.Format("\n and d.MaDonVi = '{0}'", string.IsNullOrEmpty(madonviThucHien) ? CommonConstant.DefaultLocationID : madonviThucHien);
                _strSQL += ") \n where T.MaThuoc not in (select MaThuoc from KhamBenh_DonThuoc where MaTiepNhan = '" + _matiepnhan + "' and MaDonVi ='" + _madonvi + "' and MaYeuCau ='" + _mayeucau + "')";
            }
            else
            {
                _strSQL += Environment.NewLine + "DM_Thuoc T";
                _strSQL += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia d on(d.MaDichVu = T.MaThuoc and d.MaDoiTuongDichVu = (select top 1 DoiTuongDichVu from benhnhan_tiepnhan where matiepnhan = '" + _matiepnhan + "')";
                _strSQL += "\n and d.MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'";
                if (CommonAppVarsAndFunctions.IsAdmin == false)
                    _strSQL += string.Format("\n and d.MaDonVi = '{0}'", string.IsNullOrEmpty(madonviThucHien) ? CommonConstant.DefaultLocationID : madonviThucHien);

                _strSQL += ")\n Where T.MaThuoc = '" + _ID + "'";
                _strSQL += "\n and T.MaThuoc not in (select MaThuoc from KhamBenh_DonThuoc where MaTiepNhan = '" + _matiepnhan + "' and MaDonVi ='" + _madonvi + "' and MaYeuCau ='" + _mayeucau + "')";
            }

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL) > -1;
        }

        // Update 
        public bool Update_KhamBenh_DonThuoc(string _matiepnhan, string _madonvi, string _MaYeuCau, string _mathuoc, string _cachdung,
            string _sang, string _trua, string _chieu, string _toi, string _GhiChu, string _SoLuong)
        {
            string _strSQL = "Update KhamBenh_DonThuoc set " + Environment.NewLine;
            _strSQL += Environment.NewLine + "cachdung = " + (_cachdung == "" ? "NULL" : "'" + _cachdung + "'");
            _strSQL += Environment.NewLine + ",sang = " + (_sang == "" ? "NULL" : "'" + _sang + "'");
            _strSQL += Environment.NewLine + ",trua = " + (_trua == "" ? "NULL" : "'" + _trua + "'");
            _strSQL += Environment.NewLine + ",chieu = " + (_chieu == "" ? "NULL" : "'" + _chieu + "'");
            _strSQL += Environment.NewLine + ",toi = " + (_toi == "" ? "NULL" : "'" + _toi + "'");
            _strSQL += Environment.NewLine + ",GhiChu = " + (_GhiChu == "" ? "NULL" : "N'" + _GhiChu + "'");
            _strSQL += Environment.NewLine + ",SoLuong = " + (_SoLuong == "" ? "0" : _SoLuong);
            _strSQL += Environment.NewLine + ",tgcapnhat= getdate()";
            _strSQL += Environment.NewLine + " where mathuoc ='" + _mathuoc + "'";
            _strSQL += Environment.NewLine + " and matiepnhan = '" + _matiepnhan + "'";
            _strSQL += Environment.NewLine + " and madonvi =  '" + _madonvi + "'";
            _strSQL += Environment.NewLine + " and mayeucau =  '" + _MaYeuCau + "'";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
        }

        // Delete 
        public bool Delete_KhamBenh_DonThuoc(string _mathuoc, string _matiepnhan, string _MaYeuCau, string _madonvi)
        {
            string _strSQL = "Delete from KhamBenh_DonThuoc" + Environment.NewLine;
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and mathuoc =  " + (_mathuoc == "" ? "''" : "'" + _mathuoc + "'");
            _strSQL += Environment.NewLine + " and matiepnhan =  " + (_matiepnhan == "" ? "''" : "'" + _matiepnhan + "'");
            _strSQL += Environment.NewLine + " and mayeucau =  " + (_MaYeuCau == "" ? "''" : "'" + _MaYeuCau + "'");
            _strSQL += Environment.NewLine + " and madonvi =  '" + _madonvi + "'";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
        }
        //In đơn thuốc
        public bool Print_DonThuoc(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau, bool _PrintDirect, string _PrinterName)
        {
            DataTable dt = new DataTable();
            string _strSQL = "select t.MaTiepNhan,t.MaBN, t.TenBN,t.DiaChi,t.Tuoi,t.SinhNhat, t.CoNgaySinh,case when t.GioiTinh = 'F' then N'Nữ' when t.GioiTinh ='M' then N'Nam' else '' end as GioiTinh,t.Email";
            _strSQL += "\n,t.GioiTinh,t.MaDonVi, t.SDT,t.SoBHYT";
            _strSQL += "\n,t.TenDonVi,t.NgayTiepNhan, kq.BSDieuTri,k.CanNang, kq.ChanDoan,";
            _strSQL += "\n kq.DeNghi, kq.NgayDieuTri,kq.NgayTaiKham, kq.HentaiKham";
            _strSQL += "\n,A.*";
            _strSQL += "\nfrom (";
            _strSQL += "\nselect d.MaTiepNhan, d.MaDonVi,d.MaYeuCau, d.MaThuoc,d.TenThuoc, d.SoLuong, d.Sang,d.Trua,d.Chieu,d.Toi,";
            _strSQL += "\nd.DonViTinh,cd.TenCachDung, N'Ngày ' + LOWER(cd.TenCachDung) + ' ' ";
            _strSQL += "\n+ cast (sum(case when Sang is null or len (rtrim(d.Sang))=0 then 0 else 1 end +";
            _strSQL += "\ncase when d.Trua is null or len (rtrim(d.Trua))=0 then 0 else 1 end + ";
            _strSQL += "\ncase when d.Chieu is null or len (rtrim(d.Chieu))=0 then 0 else 1 end + ";
            _strSQL += "\ncase when d.Toi is null or len (rtrim(d.Toi))=0 then 0 else 1 end) as varchar(5)) + ";
            _strSQL += "\nN' lần'";
            _strSQL += "\nas ChiDinhDung";
            _strSQL += "\nfrom KhamBenh_DonThuoc d left join{{TPH_Standard}}_Dictionary.dbo.dm_Thuoc_CachDung cd on d.CachDung=cd.ID ";
            _strSQL += "\ngroup by d.MaTiepNhan, d.MaDonVi,d.MaYeuCau,d.MaThuoc,d.TenThuoc,SoLuong, Sang,Trua,Chieu,Toi,DonViTinh,cd.TenCachDung";
            _strSQL += "\n) as A";
            _strSQL += "\ninner join KhamBenh_KetQua kq on( kq.MaDonVi = A.MaDonVi  and kq.MaTiepNhan=A.MaTiepNhan and kq.MaYeuCau =A.MaYeuCau)";
            _strSQL += "\ninner join KhamBenh_BenhNhan k on (A.MaTiepNhan = k.MaTiepNhan and k.MaDonVi = A.MaDonVi)";
            _strSQL += "\ninner join BenhNhan_TiepNhan t on t.MaTiepNhan = k.MaTiepNhan";
            _strSQL += "\nwhere k.MaTiepNhan = '" + _MaTiepNhan + "' and k.MaDonVi ='" + _MaDonVi + "' and kq.MaYeuCau ='" + _MaYeuCau + "'";

            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];

            //Reports.rpDonThuoc rp = new Reports.rpDonThuoc();
            //FrmReport frm = new FrmReport();
            //frm.crViewer.ReportSource = rp;
            //frm.PrinterName = _PrinterName;
            //return frm.Excute_Show_Print_Report(rp, dt, "TT", false, false, !_PrintDirect, _PrintDirect, _PrinterName, false);
            return false;
        }
    }
}
