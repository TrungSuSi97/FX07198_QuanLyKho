using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Patient.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode.Patient
{
    class C_Patient_KhamBenh
    {
        
        public C_Patient_KhamBenh()
        {
        }
        public string SQLSelectPatient(string _MaTiepNhan, string _MaDonVi)
        {
            string strSQL = "";
            strSQL = "select T.MaTiepNhan, T.Seq, T.NoiTru, T.MaBN, T.SoBHYT, T.NgayHetHanBHYT";
            strSQL += "\n, T.TenBN, T.SinhNhat, T.Tuoi, T.CoNgaySinh, T.GioiTinh, T.NgayTiepNhan";
            strSQL += "\n, T.ThoiGianNhap, T.UserNhap, T.DoiTuongDichVu, T.DiaChi, T.SoNha";
            strSQL += "\n, T.PhuongXa, T.MaHuyen, T.MaTinh, T.Email, T.SDT, T.DaGuiMail, T.TGGuiMail";
            strSQL += "\n, T.DichVuKhamBenh, T.DichVuXetNghiem, T.DichVuXQuang, T.DichVuSieuAm";
            strSQL += "\n, T.DichVuNoiSoi, T.DichVuDienTim, T.DichVuKhac, T.KhamLanDau, T.TGVaoVien";
            strSQL += "\n, T.YeuCau, T.MaDonVi, T.TenDonVi, T.TienSuBenh, T.TinhTrangBenh, T.NhanXetBS";
            strSQL += "\n, T.UserCapNhat, T.BacSiCD, T.ChanDoan";
            strSQL += "\n, K.MaDonVi, K.ValidKB, K.DaInKB, K.ThoiGianValidKB, K.ThoiGianInKB, K.UserInKB, K.LanInKB";
            strSQL += "\n from BenhNhan_TiepNhan T inner join KhamBenh_BenhNhan K on T.MaTiepNhan = K.MaTiepNhan";
            strSQL += "\n Where t.MaTiepNhan = '" + _MaTiepNhan + "'";
            if (_MaDonVi != "")
            {
                strSQL += "\n and K.MaDonVi = '" + _MaDonVi + "'";
            }
            return strSQL;
        }
        public void Search_PatientKhamBenh(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID, string _Category, bool nhapTheoDanhSach, string loadWithUser, DataGridView dtg, BindingNavigator bv, string maBN = "", string sdt = "")
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq,t.MaBN, t.TenBN,t.SDT,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,k.ChanDoan as KetLuan, cast(0 as bit) as DuKQ,tx.DaInKQKham as DaIn \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "inner join KhamBenh_BenhNhan tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            strSQL += "inner join KhamBenh_KetQua k on t.MaTiepNhan = k.MaTiepNhan \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D on t.DoiTuongDichVu = d.MaDoiTuongDichVu \nwhere 0=0\n";
            if (string.IsNullOrEmpty(_Seq) && string.IsNullOrEmpty(maBN) && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(_Name))
            {
                strSQL += "and t.NgayTiepNhan between '" + _dtDateFrom.ToString("yyyy-MM-dd 00:00:00.00") + "' and '" + _dtDateTo.ToString("yyyy-MM-dd 00:00:00.00") + "'";
            }

            if (!string.IsNullOrEmpty(_Seq))
            {
                strSQL += " and t.SEQ = '" + _Seq.Trim() + "'\n";
            }
            if (!string.IsNullOrEmpty(maBN))
            {
                strSQL += " and t.MaBN = '" + maBN + "'\n";
            }
            if (!string.IsNullOrEmpty(sdt))
            {
                strSQL += " and t.SDT = '" + sdt + "'\n";
            }
            if (!string.IsNullOrEmpty(_Name))
            {
                strSQL += " and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            if (_ServiceID != "")
            {
                strSQL += " and t.DoiTuongDichVu='" + _ServiceID.Trim() + "'";
            }
            if (_FullRsult)
            {
                //  strSQL += " and tx.DuKQNoiSoi = 1";
            }
            if (_Printed)
            {
                strSQL += " and tx.DaInKQKham = 1";
            }
            if (_TestID != "")
            {
                strSQL += " and k.MaYeuCau = '" + _TestID + "' \n";
            }
            if (_Category != "")
            {
                strSQL += " and k.MaNhomDichVu = '" + _Category + "' \n";
            }
            if (nhapTheoDanhSach)
                strSQL += "\n and NguonNhap ='" + InputSourceEnum.ByList.ToString() + "'";
            if (!string.IsNullOrEmpty(loadWithUser))
                strSQL += " and T.BacSiCD = '" + loadWithUser + "' \n";

            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_KhamBenh_BenhNhan_List(DataGridView dtg, BindingNavigator bv, string dateIN, int printType, string loadWithUser)
        {
            DataTable dt = new DataTable();
            string strSQL = "select t.*, k.*, n.TenNhanVien from BenhNhan_TiepNhan t inner join KhamBenh_BenhNhan k on t.MaTiepNhan = k.MaTiepNhan";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on n.ManhanVien = t.BacSiCD";
            strSQL += "\nwhere 1 = 1";
            if (dateIN != "")
            {
                strSQL += "\n and T.NgayTiepNhan = '" + dateIN + "'";
            }
            if (printType == 1)
            {
                //Đã in
                strSQL += "\n and K.DaInKQKham = 1";
            }
            else if (printType == 2)
            {
                //Chưa in
                strSQL += "\n and k.DaInKQKham = 0";
            }
            strSQL += string.IsNullOrEmpty(CommonAppVarsAndFunctions.DonViGui) ? string.Empty : string.Format("\n and  t.MaDonViNhap = '{0}'", CommonAppVarsAndFunctions.DonViGui);

            if (!string.IsNullOrEmpty(loadWithUser))
                strSQL += string.Format("\n and T.BacSiCD = '{0}'", loadWithUser);

            strSQL += " order by NgayTiepNhan";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        //Get thông tin khám bệnh
        public DataTable Data_BenhNhan_KhamBenh(string _MaTiepNhan, string _MaKhoa)
        {
            string _strSQL = "";
            _strSQL = "Select T.*, k.[TGNhap],k.[ValidKQKham],k.[DaInKQKham],k.[ThoiGianValid],k.[ThoiGianIn],k.[UserIn],k.[LanIn],k.[CanNang],k.[ChieuCao],k.[HuyetAp] ,k.[Mach],k.[NhipTho], n.TenNhanVien";
            _strSQL += "\n,k.[NhietDo],k.[UserValidKQKham]";
            _strSQL += "\nfrom BenhNhan_TiepNhan t inner join  KhamBenh_BenhNhan k on t.MaTiepNhan = k.MaTiepNhan";
            _strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on n.ManhanVien = t.BacSiCD";
            _strSQL +="\nwhere 1 = 1";
            _strSQL += "\n and k.MaTiepNhan = '" + _MaTiepNhan + "' and K.MaDonVi = '" + _MaKhoa + "'";
            return DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
        }
        public void CapNhat_ThuTien(string _MaTiepNhan, string _ChiDinh, bool _DaThu)
        {
            string _strSQL = "update KhamBenh_KetQua set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _strSQL += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaYeuCau in (" + _ChiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
        public bool Insert_ChiDinh_DichVu(string _MaTiepNhan, string _MaChiDinh, string _MaDoiTuongDichVu, string _MaDonVi, float _DonGia)
        {
            bool _InsertOk = false;
            if (LabServices_Helper.Check_NotExits("Select * from KhamBenh_BenhNhan where MaTiepNhan = '" + _MaTiepNhan + "' and MaDonVi ='" + _MaDonVi + "'"))
            {
                _InsertOk = Insert_KhamBenh(_MaTiepNhan, _MaDonVi);
            }
            else
                _InsertOk = true;
            //After check - insert
            //Insertorder
            if (_InsertOk)
            {
                if (
                    LabServices_Helper.Check_NotExits("Select * from KhamBenh_KetQua where MaTiepNhan = '" + _MaTiepNhan +
                                                   "'  and MaDonVi ='" + _MaDonVi + "' and MaYeuCau ='" + _MaChiDinh +
                                                   "'"))
                {
                    string strSql = string.Empty;
                    try
                    {
                        strSql =
                            "Insert KhamBenh_KetQua ([MaTiepNhan],[MaYeuCau],[MaDonVi],[TenYeuCau],[MaNhomDichVu],[GhiChu],[DeNghi],[GiaChuan],[GiaRieng], [MaPhanLoai])";
                        strSql += "\n select '" + _MaTiepNhan + "' as MaTiepNhan, y.MaYeuCau, '" + _MaDonVi +
                                  "',Y.TenYeuCau,Y.MaNhomDichVu,Y.GhiChuMacDinh, Y.DeNghiMacDinh, Y.GiaChuan," +
                                  (_DonGia < 0 ? "0.GiaRieng" : _DonGia.ToString("N3")) + ",'" + ServiceType.KhamBenh.ToString() + "'";
                        strSql +=
                            "\n from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu Y inner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia O on (O.MaDichVu = y.MaYeuCau and O.MaDoiTuongDichVu = '" +
                            _MaDoiTuongDichVu + "' and o.MaLoaiDichVu ='KhamBenh' )";
                        strSql += "\n where Y.MaYeuCau = '" + _MaChiDinh + "'";
                        return (int) DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1;
                    }
                    catch (SqlException ex)
                    {
                        return ErrorService.GetSQLErrorMessage(ex, strSql, CommonAppVarsAndFunctions.UserID);
                    }
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Yêu cầu đã nhập trước!");
                    return false;
                }
            }
            else
                return false;
        }

        public bool Delete_ChiDinh_KhamBenh(string _MaTiepNhan, string _MaDonVi, string _MaYeuCau)
        {
            string strSql = "";
            try
            {

                strSql = "Delete KhamBenh_KetQua where MaTiepNhan = '" + _MaTiepNhan + "'  and MaDonVi ='" + _MaDonVi +
                         "' and MaYeuCau ='" + _MaYeuCau + "'";
                if ((int) DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1)
                    return (int) DataProvider.ExecuteNonQuery(CommandType.Text,
                        "Delete KhamBenh_BenhNhan where MaTiepNhan ='" + _MaTiepNhan +
                        "' and (select count (*) from KhamBenh_KetQua  where  MaTiepNhan ='" + _MaTiepNhan +
                        "' and MaDonVi ='" + _MaDonVi + "') = 0 and MaDonVi ='" + _MaDonVi + "'") > -1;
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                return ErrorService.GetSQLErrorMessage(ex, strSql, CommonAppVarsAndFunctions.UserID);
            }
        }

        public bool Insert_KhamBenh(string _MaTiepNhan, string _MaDonVi)
        {
            string _strSQL = "insert into KhamBenh_BenhNhan(MaTiepNhan, MaDonVi)";
            _strSQL += "\nselect '" + _MaTiepNhan + "' as MaTiepNhan," + (_MaDonVi == "" ? "NULL" : "'" + _MaDonVi + "' as MaDonVi");
           return (bool)DataProvider.ExecuteScalar(CommandType.Text,_strSQL);
        }
        // Update BenhNhan

      

        //Update Ket Qua
        public bool Update_KhamBenh_BenhNhan_TongQuat(string _MaTiepNhan, string _MaDonVi, string _MaBacSi, string _BSDieuTri, DateTime _NgayDieuTri, string _CanNang,
          string _ChieuCao, string _HuyetAp, string _Mach, string _NhipTho, string _NhietDo, string _ChanDoan, string _LoiDan, string _GhiChu,
            bool _HenTaiKham, DateTime _NgayTaiKham)
        {

            string _strSQL = " UPDATE [KhamBenh_BenhNhan]";
            _strSQL += Environment.NewLine + "SET [BSDieuTri] = " + (_BSDieuTri == "" ? "NULL" : "N'" + _BSDieuTri + "'");
            _strSQL += Environment.NewLine + ",[MaBacSi] = " + (_MaBacSi == "" ? "NULL" : "'" + _MaBacSi + "'");
            _strSQL += Environment.NewLine + ",[NgayDieuTri] = '" + _NgayTaiKham.ToString("yyyy-MM-dd") + "'";
            _strSQL += Environment.NewLine + ",[CanNang] = " + (_CanNang == "" ? "NULL" : _CanNang);
            _strSQL += Environment.NewLine + ",[ChieuCao] = " + (_ChieuCao == "" ? "NULL" : _ChieuCao);
            _strSQL += Environment.NewLine + ",[HuyetAp] = " + (_HuyetAp == "" ? "NULL" : "N'" + _HuyetAp + "'");
            _strSQL += Environment.NewLine + ",[Mach] = " + (_Mach == "" ? "NULL" : "N'" + _Mach + "'");
            _strSQL += Environment.NewLine + ",[NhipTho] = " + (_NhipTho == "" ? "NULL" : "N'" + _NhipTho + "'");
            _strSQL += Environment.NewLine + ",[NhietDo] =" + (_NhietDo == "" ? "NULL" : "N'" + _NhietDo + "'");
            _strSQL += Environment.NewLine + ",[ChanDoan] = " + (_ChanDoan == "" ? "NULL" : "N'" + _ChanDoan + "'");
            _strSQL += Environment.NewLine + ",[LoiDan] = " + (_LoiDan == "" ? "NULL" : "N'" + _LoiDan + "'");
            _strSQL += Environment.NewLine + ",[GhiChu] = " + (_GhiChu == "" ? "NULL" : "N'" + _GhiChu + "'");
            _strSQL += Environment.NewLine + ",[HentaiKham] = " + (_HenTaiKham == true ? "1" : "0");
            _strSQL += Environment.NewLine + ",[NgayTaiKham] = " + (_HenTaiKham == false ? "NULL" : "'" + _NgayTaiKham.ToString("yyyy-MM-dd") + "'");
            _strSQL += Environment.NewLine + " Where MatiepNhan = '" + _MaTiepNhan + "' and MaDonVi = '" + _MaDonVi + "'";
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
        //Danh sách yêu cầu khám bệnh
        public void Get_DanhSach_YeuCauKhamBenh(CustomComboBox cbo, TextBox txt, string _MaTiepNhan, string _MaDonVi, int _CurrentIndex)
        {
            string strSQL = "Select * from KhamBenh_KetQua where MaTiepNhan = '" + _MaTiepNhan + "'  and MaDonVi ='" + _MaDonVi + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaYeuCau", "MaYeuCau", "MaYeuCau,TenYeuCau", "50,200");
            if (txt != null)
            {
                cbo.LinkedColumnIndex1 = 1;
                cbo.LinkedTextBox1 = txt;
            }
            if (dt.Rows.Count > 0)
                if (_CurrentIndex == -1)
                {
                    cbo.SelectedIndex = 0;
                }
                else
                    cbo.SelectedIndex = _CurrentIndex;
        }
        // BẢNG KhamBenh_DonThuoc
        // Getdata 
        public string SQL_KhamBenh_DonThuoc(string _MaTiepNhan, string _MaDonVi, string _NhomThuoc, string _MaThuoc)
        {
            string _strSQL = " select * from KhamBenh_DonThuoc where MaTiepNhan ='" + _MaTiepNhan + "' and MaDonVi ='" + _MaDonVi + "'";
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
        public DataTable Data_KhamBenh_DonThuoc(string _MaTiepNhan, string _MaDonVi, string _NhomThuoc, string _MaThuoc)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_KhamBenh_DonThuoc(_MaTiepNhan, _MaDonVi, _NhomThuoc, _MaThuoc)).Tables[0];
        }
        public void Get_KhamBenh_DonThuoc(DataGridView dtg, BindingNavigator bv, ref DataTable dt, string _MaTiepNhan, string _MaDonVi, string _NhomThuoc, string _MaThuoc)
        {
            dt = new DataTable();
            dt = Data_KhamBenh_DonThuoc(_MaTiepNhan, _MaDonVi, _NhomThuoc, _MaThuoc);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_KhamBenh_DonThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt)
        {
            dt = new DataTable();
            string _strSQL = " select * from KhamBenh_DonThuoc where 0=0 ";
            _strSQL += _filter;
            _strSQL += " order by matiepnhan,tenthuoc";
            LabServices_Helper.BindContex(da, ref dt, _strSQL, ref dtg, ref bv);
        }

        // Insert 
        public bool Insert_KhamBenh_DonThuoc(string _matiepnhan, string _madonvi, string _ID, bool _Profile)
        {
            string _strSQL = "", alias = (_Profile == true ? "P" : "T");
            _strSQL += Environment.NewLine + "  INSERT INTO KhamBenh_DonThuoc";
            _strSQL += Environment.NewLine + "(	[MaTiepNhan]";
            _strSQL += Environment.NewLine + ",[MaDonVi]";
            _strSQL += Environment.NewLine + " ,[MaThuoc]";
            _strSQL += Environment.NewLine + ",[TenThuoc]";
            _strSQL += Environment.NewLine + ",[MaVatTu]";
            _strSQL += Environment.NewLine + ",[MaNhomThuoc]";
            _strSQL += Environment.NewLine + ",[DonViTinh]";
            _strSQL += Environment.NewLine + ",[CachDung]";
            _strSQL += Environment.NewLine + ",[Sang]";
            _strSQL += Environment.NewLine + ",[Trua]";
            _strSQL += Environment.NewLine + ",[Chieu]";
            _strSQL += Environment.NewLine + ",[Toi]";
            _strSQL += Environment.NewLine + ",[SoLuong]";
            _strSQL += Environment.NewLine + ",[TGNhap] )";
            _strSQL += Environment.NewLine + "SELECT '" + _matiepnhan + "'";
            _strSQL += Environment.NewLine + ",'" + _madonvi + "'";
            _strSQL += Environment.NewLine + ",T.[MaThuoc]";
            _strSQL += Environment.NewLine + ",T.[TenThuoc]";
            _strSQL += Environment.NewLine + ",T.[MaVatTu]";
            _strSQL += Environment.NewLine + ",T.[MaNhomThuoc]";
            _strSQL += Environment.NewLine + ",[DonViTinh]";
            _strSQL += Environment.NewLine + "," + alias + ".[CachDung]";
            _strSQL += Environment.NewLine + "," + alias + ".[Sang]";
            _strSQL += Environment.NewLine + "," + alias + ".[Trua]";
            _strSQL += Environment.NewLine + "," + alias + ".[Chieu]";
            _strSQL += Environment.NewLine + "," + alias + ".[Toi]";
            _strSQL += Environment.NewLine + ",0";
            _strSQL += Environment.NewLine + " ,GETDATE()";
            _strSQL += Environment.NewLine + "FROM";
            if (_Profile)
            {
                _strSQL += Environment.NewLine + "DM_Thuoc_Profile_ChiTiet P inner join {{TPH_Standard}}_Dictionary.dbo.dm_Thuoc T on P.MaThuoc = T.MaThuoc and P.MaProfile = '" + _ID + "'";
            }
            else
            {
                _strSQL += Environment.NewLine + "DM_Thuoc T where MaThuoc = '" + _ID + "'";
            }
            _strSQL += Environment.NewLine + " and " + alias + ".MaThuoc not in (select MaThuoc from KhamBenh_DonThuoc where MaTiepNhan = '" + _matiepnhan + "' and MaDonVi ='" + _madonvi + "')";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text,_strSQL);
        }

        // Update 
        public bool Update_KhamBenh_DonThuoc(string _matiepnhan, string _madonvi, string _mathuoc, string _cachdung,
            string _sang, string _trua, string _chieu, string _toi, string _GhiChu, string _SoLuong)
        {
            string _strSQL = "Update KhamBenh_DonThuoc set " + Environment.NewLine;
            _strSQL += Environment.NewLine + "cachdung = " + (_cachdung == "" ? "NULL" : "'" + _cachdung + "'");
            _strSQL += Environment.NewLine + ",sang = " + (_sang == "" ? "NULL" : "'" + _sang + "'");
            _strSQL += Environment.NewLine + ",trua = " + (_trua == "" ? "NULL" : "'" + _trua + "'");
            _strSQL += Environment.NewLine + ",chieu = " + (_chieu == "" ? "NULL" : "'" + _chieu + "'");
            _strSQL += Environment.NewLine + ",toi = " + (_trua == "" ? "NULL" : "'" + _toi + "'");
            _strSQL += Environment.NewLine + ",GhiChu = " + (_GhiChu == "" ? "NULL" : "N'" + _GhiChu + "'");
            _strSQL += Environment.NewLine + ",SoLuong = " + (_SoLuong == "" ? "0" : _SoLuong);
            _strSQL += Environment.NewLine + ",tgcapnhat= getdate()";
            _strSQL += Environment.NewLine + " where mathuoc ='" + _mathuoc + "'";
            _strSQL += Environment.NewLine + " and matiepnhan = '" + _matiepnhan + "'";
            _strSQL += Environment.NewLine + " and madonvi =  '" + _madonvi + "'";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text,_strSQL);
        }

        // Delete 
        public bool Delete_KhamBenh_DonThuoc(string _mathuoc, string _matiepnhan)
        {
            string _strSQL = "Delete from KhamBenh_DonThuoc" + Environment.NewLine;
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and mathuoc =  " + (_mathuoc == "" ? "''" : "'" + _mathuoc + "'");
            _strSQL += Environment.NewLine + " and matiepnhan =  " + (_matiepnhan == "" ? "''" : "'" + _matiepnhan + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text,_strSQL);
        }
        //In đơn thuốc
        public void Print_DonThuoc(string _MaTiepNhan, string _MaDonVi, bool _PrintDirect, string _PrinterName)
        {
            DataTable dt = new DataTable();
            string _strSQL = "select t.MaBN, t.TenBN,t.DiaChi,t.Tuoi,t.SinhNhat, t.CoNgaySinh,case when t.GioiTinh = 'F' then N'Nữ' when t.GioiTinh ='M' then N'Nam' else '' end as GioiTinh,t.Email";
            _strSQL += "\n,t.GioiTinh,t.MaDonVi, t.SDT,t.SoBHYT";
            _strSQL += "\n,t.TenDonVi,t.NgayTiepNhan, kq.BSDieuTri,kq.CanNang, kq.ChanDoan,";
            _strSQL += "\n kq.LoiDan, kq.NgayDieuTri,kq.NgayTaiKham, kq.HentaiKham";
            _strSQL += "\n,A.*";
            _strSQL += "\nfrom (";
            _strSQL += "\nselect d.MaTiepNhan, d.MaDonVi,d.MaThuoc,d.TenThuoc, d.SoLuong, d.Sang,d.Trua,d.Chieu,d.Toi,";
            _strSQL += "\nd.DonViTinh,cd.TenCachDung, N'Ngày ' + LOWER(cd.TenCachDung) + ' ' ";
            _strSQL += "\n+ cast (sum(case when Sang = null then 0 else 1 end +";
            _strSQL += "\ncase when d.Trua = null then 0 else 1 end + ";
            _strSQL += "\ncase when d.Chieu = null then 0 else 1 end + ";
            _strSQL += "\ncase when d.Toi = null then 0 else 1 end) as varchar(5)) + ";
            _strSQL += "\nN' lần'";
            _strSQL += "\nas ChiDinhDung";
            _strSQL += "\nfrom KhamBenh_DonThuoc d left join {{TPH_Standard}}_Dictionary.dbo.dm_Thuoc_CachDung cd on d.CachDung=cd.ID";
            _strSQL += "\ngroup by d.MaTiepNhan, d.MaDonVi,d.MaThuoc,d.TenThuoc,SoLuong, Sang,Trua,Chieu,Toi,DonViTinh,cd.TenCachDung";
            _strSQL += "\n) as A";
            _strSQL += "\ninner join KhamBenh_BenhNhan k on (A.MaTiepNhan = k.MaTiepNhan and k.MaDonVi = A.MaDonVi)";
            _strSQL += "\ninner join BenhNhan_TiepNhan t on t.MaTiepNhan = k.MaTiepNhan";
            _strSQL += "\ninner join KhamBenh_KetQua kq on( kq.MaDonVi = k.MaDonVi  and kq.MaTiepNhan=k.MaTiepNhan)";
            _strSQL += "\nwhere k.MaTiepNhan = '" + _MaTiepNhan + "' and k.MaDonVi ='" + _MaDonVi + "'";

            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];

            //Reports.rpDonThuoc rp = new Reports.rpDonThuoc();
            //rp.SetDataSource(dt);

            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe1Logo"]).Text = CommonAppVarsAndFunctions.TieuDe1;
            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe2Logo"]).Text = CommonAppVarsAndFunctions.TieuDe2;
            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe3Logo"]).Text = CommonAppVarsAndFunctions.TieuDe3;
            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe4Logo"]).Text = CommonAppVarsAndFunctions.TieuDe4;

            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe1"]).Text = CommonAppVarsAndFunctions.TieuDe1;
            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe2"]).Text = CommonAppVarsAndFunctions.TieuDe2;
            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe3"]).Text = CommonAppVarsAndFunctions.TieuDe3;
            //((TextObject)rp.hdLogo.ReportObjects["txtTieuDe4"]).Text = CommonAppVarsAndFunctions.TieuDe4;
            //FrmReport frm = new FrmReport();
            //frm.crViewer.ReportSource = rp;
            //frm.PrinterName = _PrinterName;
            //if (_PrintDirect)
            //{
            //    frm.Excute_Show_Print_Report(rp, dt, "A", false, false, !_PrintDirect, _PrintDirect, _PrinterName, false);
            //    frm.Dispose();
            //}
            //else
            //{
            //    frm.Show();
            //}
        }
        public DataTable Check_Get_Patient(string _MaTiepNhan, string _MaDonVi, bool _AutoInsert)
        {
            DataTable dtResult = new DataTable();
            //Nếu bệnh nhân chưa nhập khám bệnh thì insert vào 
            if (LabServices_Helper.Check_NotExits("select MaTiepNhan from KhamBenh_BenhNhan where MaTeipNhan = '" + _MaTiepNhan + "'" + (_MaDonVi == "" ? "" : " and MaDonVi = '" + _MaDonVi + "'")))
            {
                if (_AutoInsert)
                    Insert_KhamBenh(_MaTiepNhan, _MaDonVi);
                else if (
                    CustomMessageBox.MSG_Question_YesNo_GetYes("Bệnh nhân chưa nhập khám bệnh?\nNhập thông tin khám bệnh?"))
                    Insert_KhamBenh(_MaTiepNhan, _MaDonVi);
                else
                    return DataProvider.ExecuteDataset(CommandType.Text, SQLSelectPatient("", "")).Tables[0];
            }

            return DataProvider.ExecuteDataset(CommandType.Text, SQLSelectPatient(_MaTiepNhan, _MaDonVi)).Tables[0];
        }
        public void Get_Patient(object[] _objControl, ref DataTable dtPatientKhamBenh, string _MaTiepNhan, string _MaDonVi, bool _AuToInsert)
        {
            dtPatientKhamBenh = Check_Get_Patient(_MaTiepNhan, _MaDonVi, _AuToInsert);
            BindingSource bs = new BindingSource();
            bs.DataSource =  dtPatientKhamBenh;
            foreach (object obj in _objControl)
            {
                LabServices_Helper.CheckAndSetBindData(obj, bs);
            }
        }
        public string SQLSelectKhamBenh_KetQua(string _MaKhamBenh)
        {
            string _strSQL = "";
            _strSQL = "select * from KhamBenh_KetQua";
            _strSQL += "\n Where MaKhamBenh ='" + _MaKhamBenh + "'";
            return _strSQL;
        }

        public string SQLSelectKhamBenh_DonThuoc(string _MaKhamBenh)
        {
            string _strSQL = "";
            _strSQL = "select * from KhamBenh_DonThuoc";
            _strSQL += "\n Where MaKhamBenh ='" + _MaKhamBenh + "'";
            return _strSQL;
        }

        public void Get_Patient_DonThuoc(ref DataTable dtPatientDonThuoc, string _MaTiepNhan, string _MaDonVi)
        {
            
        }
    }
}
