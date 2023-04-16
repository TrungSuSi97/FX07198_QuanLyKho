using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode.Patient
{
    class C_Patient_DichVu_Khac
    {

        
        public C_Patient_DichVu_Khac()
        {
        }

        public DataTable Get_Patient_DVKhac(string _MaTiepNhan, string _DateIN, int _PrintType)
        {
            string strSQL = " select * from BenhNhan_TiepNhan t inner Join CLS_BenhNhan_DVKhac tx on t.MaTiepNhan = tx.MaTiepNhan where 1=1 ";
            if (_MaTiepNhan != "")
                strSQL += "\n and T.MaTiepNhan ='" + _MaTiepNhan + "'";
            if (_DateIN != "")
            {
                strSQL += "\n and T.NgayTiepNhan = '" + _DateIN + "'";
            }
            if (_PrintType == 1)
            {
                //Đã in
                strSQL += "\n and Tx.DaInKQKhac = 1";
            }
            else if (_PrintType == 2)
            {
                //Chưa in
                strSQL += "\n and Tx.DaInKQKhac = 0";
            }

            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
        private void Insert_Patient_DVKhac(string _MaTiepNhan)
        {
            if (LabServices_Helper.Check_NotExits("select * from CLS_BenhNhan_DVKhac where MaTiepNhan ='" + _MaTiepNhan + "'"))
            {
                string _strSQL = "insert into CLS_BenhNhan_DVKhac (MaTiepNhan) select '" + _MaTiepNhan + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
            }
        }
        public bool Delete_ChiDinhCLS_DVKhac(string _MaTiepNhan, string _MaXN)
        {
            try
            {
                string strSQL = "delete KetQua_CLS_DVKhac where MaTiepNhan ='" + _MaTiepNhan + "'" + (_MaXN == "" ? "" : " and MaDVKhac='" + _MaXN + "'");
                DataProvider.ExecuteNonQuery(CommandType.Text,strSQL);
                DataProvider.ExecuteNonQuery(CommandType.Text,"Delete CLS_BenhNhan_DVKhac where MaTiepNhan ='" + _MaTiepNhan + "' and (select count (*) from KetQua_CLS_DVKhac where  MaTiepNhan ='" + _MaTiepNhan + "') = 0");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Chỉ định CLS
        public void Insert_ChiDinhDVKhac(string MaTiepNhan, string MaDVKhac, string _serviceID, float _DonGia)
        {
            if (LabServices_Helper.Check_NotExits("select * from KetQua_CLS_DVKhac where MaTiepNhan = '" + MaTiepNhan.Trim() + "' and MaDVKhac = '" + MaDVKhac.Trim() + "'"))
            {
                Insert_Patient_DVKhac(MaTiepNhan);
                string strSQL = "";
                strSQL = "insert into KetQua_CLS_DVKhac ([MaTiepNhan],[MaDVKhac] ,[MaNhomCLS] ,[TenDVKhac],[KetQua]";
                strSQL += "\n,[GhiChu],[DeNghi],[GiaRieng],[GiaChuan],[MaPhanLoai])";
                strSQL += "\n select '" + MaTiepNhan + "' as MaTiepNhan, x.MaDVKhac,x.MaNhomCLS,x.TenDVKhac,x.MauKetQua\n" +
                ",x.GhiChu,x.DeNghi," + (_DonGia < 0 ? "d.GiaRieng" : _DonGia.ToString("N3")) + ",x.GiaChuan,'" + ServiceType.DvKhac.ToString() + "' from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac x inner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia d on (x.MaDVKhac = d.MaDichVu and d.MaDoiTuongDichVu='" + _serviceID + "') where x.MaDVKhac='" + MaDVKhac + "'\n" +
                " and x.MaDVKhac not in (select k.MaDVKhac from KetQua_CLS_DVKhac k where MaTiepNhan ='" + MaTiepNhan + "')";
                DataProvider.ExecuteNonQuery(CommandType.Text,strSQL);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Chỉ định dịch vụ đã được nhập trước !");
            }
        }
        //Get for CLS_KetQua
        public DataTable DuLieuIn_DVKhac(DataTable dtThongTin, int _Index, bool _LayMailTheBN, string _MaDVKhac)
        {
            DataTable dtData = new DataTable();
            string _MaTiepNhan = dtThongTin.Rows[_Index]["MaTiepNhan"].ToString().Trim();
            string _TGNhap = DateTime.Parse(dtThongTin.Rows[_Index]["ThoiGianNhap"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string _MaBN = dtThongTin.Rows[_Index]["MaBN"].ToString().Trim();
            string strSQL = "";
            strSQL = "declare @MaTiepNhan varchar(20) \n";
            strSQL += "declare @MaDVKhac varchar(20)\n";
            //strSQL += "declare @ThoiGianNhap datetime\n";
            ////Mã tiếp nhận đang kiểm tra
            strSQL += " set @MaTiepNhan='" + _MaTiepNhan + "'\n";
            ////Mã BN
            strSQL += " set @MaDVKhac=" + (_MaDVKhac == "" ? "NULL" : "'" + _MaDVKhac + "'") + "\n";
            ////Thoi Gian Nhập của MaTiepNhan đang xét
            //strSQL += " set @ThoiGianNhap='" + _TGNhap + "'\n";
            strSQL += " select t.MaTiepNhan, t.MaBN,t.SEQ,t.TenBN, t.ChanDoan,case when t.Tuoi > 1000 then year(t.NgayTiepNhan) - t.Tuoi else t.Tuoi end as Tuoi, case when t.GioiTinh = 'M' then N'Nam' when t.GioiTinh = 'F' then N'Nữ' else N'' end as GioiTinh \n";
            strSQL += "\n,t.DiaChi,t.Email as EmailBN, " + (_LayMailTheBN == true ? "t.Email" : "d.EmailDoiTuongDichVu") + " as MailTo,t.SDT,t.NgayTiepNhan\n";
            strSQL += "\n,k.DeNghi,k.Ketluan,k.NguoiXacNhan,k.KetLuan1,k.KetLuan2,k.KetLuan3,k.KetLuan4";
            strSQL += "\n,k.TenDVKhac,k.MaDVKhac,k.HinhAnh1,k.HinhAnh2,k.HinhAnh3,k.HinhAnh4";
            strSQL += "\n,CAST (null as Image) as HinhKQ,K.KetQua\n";
            strSQL += "\n,d.DiaChiDoiTuongDichVu,d.EmailDoiTuongDichVu,d.LamTieuDe,d.PhoneDoiTuongDichVu,D.TenDoiTuongDichVu\n";
            strSQL += "\n, cast (null as Image) as Barcode, nd.TenNhanVien as BSDVKhac";
            //,k.KetQuaHP, kt.TenKyThuat as TenKyThuatHP, m.TenMay as TenMayDVKhac \n";
            strSQL += "\nfrom BenhNhan_TiepNhan t inner join KetQua_CLS_DVKhac k on t.MaTiepNhan=k.MaTiepNhan\n";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD=nv.MaNhanVien\n";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu d on t.DoiTuongDichVu = d.MaDoiTuongDichVu\n";
           // strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.dm_MayDVKhac m on k.MayDVKhac = m.IDMay\n";
           // strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.dm_DVKhac_KyThuatHP kt on k.KyThuatHP = kt.MaKyThuat\n";
            strSQL += "\nleft join (select u.MaNguoiDung, n.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung u inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on u.MaNhanVien = n.MaNhanVien) as nd on  nd.MaNguoiDung = k.NguoiKy\n";
            strSQL += "where t.MaTiepNhan = @MaTiepNhan";
            if (_MaDVKhac != "")
            {
                strSQL += "\nand k.MaDVKhac = @MaDVKhac";
            }
            dtData = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
           // Get_HinhAnh(ref dtData, _MaTiepNhan);
            return dtData;
        }
        public DataTable DuLieuTienSu(string _MaBN)
        {
            string strSQL = "";
            //Lấy tất cả các xét nghiệm của bệnh nhân
            strSQL = "select A.MaDVKhac as MaChiDinh, A.TenDVKhac as TenChiDinh";
            strSQL += "\nfrom (";
            strSQL += "\nselect distinct MaDVKhac, TenDVKhac";
            strSQL += "\n from KetQua_CLS_DVKhac k inner join BenhNhan_TiepNhan t on k.MaTiepNhan = t.MaTiepNhan";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac n on n.MaNhomDVKhac = k.MaNhomDVKhac";
            strSQL += "\nwhere t.MaBN = '" + _MaBN + "'";
            strSQL += "\n) as A \nOrder by MaDVKhac, TenDVKhac";
            DataTable dtChiDinh = new DataTable();
            dtChiDinh = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            if (dtChiDinh.Rows.Count > 0)
            {
                RicherTextBox.RicherTextBox rc = new RicherTextBox.RicherTextBox();
                //Lấy danh sách lần tiếp nhận
                DataTable dtTiepNhan = new DataTable();
                strSQL = "select t.MaTiepNhan,t.NgayTiepNhan from BenhNhan_TiepNhan t inner join CLS_BenhNhan_DVKhac tx on t.MaTiepNhan = tx.MaTiepNhan where t.MaBN = '" + _MaBN + "'";
                dtTiepNhan = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                string _ColumnName = "", _MaTiepNhan = "", _MaXNKQ = "";
                DataTable dtResult = new DataTable();
                for (int i = 0; i < dtTiepNhan.Rows.Count; i++)
                {
                    _MaXNKQ = "";
                    _MaTiepNhan = dtTiepNhan.Rows[i]["MaTiepNhan"].ToString().Trim();
                    _ColumnName = _MaTiepNhan + "(" + ((DateTime)dtTiepNhan.Rows[i]["NgayTiepNhan"]).ToString("dd/MM/yyyy") + ")";
                    dtChiDinh.Columns.Add(_ColumnName);
                    strSQL = "select k.Ketluan as KetQua,k.MaDVKhac as MaChiDinh from KetQua_CLS_DVKhac k where k.MaTiepNhan = '" + _MaTiepNhan + "'";
                    dtResult = new DataTable();
                    dtResult = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                    for (int y = 0; y < dtResult.Rows.Count; y++)
                    {
                        _MaXNKQ = dtResult.Rows[y]["MaChiDinh"].ToString().Trim().ToLower();
                        for (int r = 0; r < dtChiDinh.Rows.Count; r++)
                        {
                            if (dtChiDinh.Rows[r]["MaChiDinh"].ToString().Trim().ToLower().Equals(_MaXNKQ))
                            {
                                rc.Rtf = dtResult.Rows[y]["KETQUA"].ToString().Trim();
                                dtChiDinh.Rows[r][_ColumnName] = rc.Text;
                                break;
                            }
                        }
                    }
                }
            }
            return dtChiDinh;
        }
        private void Get_HinhAnh(ref DataTable dtGet, string _MaTiepNhan)
        {
            string _MaDV = "";
            string _pathHinh= "";
            string _ColumnHinh = "";
            Image img;
            for (int i = 0; i < dtGet.Rows.Count; i++)
            {

                _MaDV = dtGet.Rows[i]["MaDVKhac"].ToString();
                _ColumnHinh = "NoiLuuHinhAnh";

                if (_ColumnHinh !="")
                {
                    _pathHinh = dtGet.Rows[i][_ColumnHinh].ToString();
                    if (_pathHinh != "" && File.Exists(_pathHinh))
                    {
                        img = Image.FromFile(_pathHinh);
                        dtGet.Rows[i]["HinhKQ"] = imageToByteArray(img);

                    }
                }
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public void In_Ket_DVKhac(DataTable dtThongTin, int index, bool _LayMailTheBN, string _MaDVKhac, bool _isPrint, string _PrinterName)
        {
            //DataTable dtPrint = DuLieuIn_DVKhac(dtThongTin, index, _LayMailTheBN, _MaDVKhac);
            //if (dtPrint.Rows.Count > 0)
            //{
            //    Reports.rpKQDienTim rp = new Reports.rpKQDienTim();
            //    FrmReport rV = new FrmReport();
            //    rV.Excute_Show_Print_Report(rp, dtPrint, "A", false, false, !_isPrint, _isPrint, _PrinterName, false);
            //}

        }
        public void In_Ket_DVDienTim(DataTable dtThongTin, int index, bool _LayMailTheBN, string _MaDVKhac, bool _isPrint, string _PrinterName, Image _img)
        {
            //DataTable dtPrint = DuLieuIn_DVKhac(dtThongTin, index, _LayMailTheBN, _MaDVKhac);
            //if (dtPrint.Rows.Count > 0)
            //{
            //    byte[] _imgarry ;
            //    MemoryStream ms = new MemoryStream();
            //    _img.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            //    _imgarry = ms.ToArray();
            //    ms.Dispose();
            //    foreach (DataRow dr in dtPrint.Rows)
            //    {
            //        dr["HinhKQ"] = _imgarry;
            //    }
            //    Reports.rpKQDienTim rp = new Reports.rpKQDienTim();
            //    FrmReport rV = new FrmReport();
            //    rV.Excute_Show_Print_Report(rp, dtPrint, "A", false, false, !_isPrint, _isPrint, _PrinterName, false);
            //}

        }
        public bool CapNhat_KQ_DVKhac(string _MaTiepNhan, string _MaDVKhac, string _KetQua,
            string _KetQua1, string _KetQua2, string _KetQua3, string _KetQua4,
            string _KetLuan, string _KetLuan1, string _KetLuan2, string _KetLuan3, string _KetLuan4,
            string _DeNghi, string _GhiChu,
            string _NguoiTH, string _NguoiKy)
        {
            string _strSQL = "update KetQua_CLS_DVKhac set KetQua = N'" + Utilities.ConvertSqlString(_KetQua) + "'";
            _strSQL += "\n, KetQua1=" + (_KetQua1 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetQua1) + "'");
            _strSQL += "\n, KetQua2=" + (_KetQua2 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetQua2) + "'");
            _strSQL += "\n, KetQua3=" + (_KetQua3 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetQua3) + "'");
            _strSQL += "\n, KetQua4=" + (_KetQua4 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetQua4) + "'");

            _strSQL += "\n, KetLuan=" + (_KetLuan == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetLuan) + "'");
            _strSQL += "\n, KetLuan1=" + (_KetLuan1 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetLuan1) + "'");
            _strSQL += "\n, KetLuan2=" + (_KetLuan2 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetLuan2) + "'");
            _strSQL += "\n, KetLuan3=" + (_KetLuan3 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetLuan3) + "'");
            _strSQL += "\n, KetLuan4= " + (_KetLuan4 == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetLuan4) + "'");
            _strSQL += "\n, DeNghi = " + (_DeNghi == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_DeNghi) + "'");
            _strSQL += "\n, GhiChu = " + (_GhiChu == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_GhiChu) + "'");
            _strSQL += "\n, UserNhapKQ ='" + Utilities.ConvertSqlString(_NguoiTH) + "', NguoiKy ='" + Utilities.ConvertSqlString(_NguoiKy) + "'";

            _strSQL += "\n,ThoiGianNhapKQ = isnull(ThoiGianNhapKQ,getdate()),ThoiGianSuaKQ  = case when ThoiGianNhapKQ is null then null else getdate() end ";

            _strSQL += "\n where MaTiepNhan = '" + _MaTiepNhan + "' and MaDVKhac='" + _MaDVKhac + "'";
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, _strSQL);
        }
        public void XacNhan_KQ_DVKhac(string _MaTiepNhan, string _MaDVKhac, string _TrangThai, bool _valid, string _NguoiXacNhan)
        {
            string _strSQL = "update KetQua_CLS_DVKhac set TrangThai = N'" + Utilities.ConvertSqlString(_TrangThai) + "', NguoiXacNhan='" + Utilities.ConvertSqlString(_NguoiXacNhan) + "', XacNhanKQ = " + (_valid == true ? "1" : "0") + ", ThoiGianXacNhan = getdate() where MaTiepNhan = '" + _MaTiepNhan + "' and MaDVKhac='" + _MaDVKhac + "'";
            _strSQL += ";Update CLS_BenhNhan_DVKhac set ValidKQKhac = (case when (select count(*) from KetQua_CLS_DVKhac where  MaTiepNhan = '" + _MaTiepNhan + "' and MaDVKhac='" + _MaDVKhac + "' and XacNhanKQ = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
            CapNhat_DuKetQua_DVKhac(_MaTiepNhan, _valid);
        }
        public void CapNhat_In_KQ_DVKhac(string _MaTiepNhan, string _NguoiLamDVKhac, string _MaDVKhac)
        {
            string _strSQL = " update KetQua_CLS_DVKhac set DaInKQKhac = 1, ThoigianIn = getdate()  where MaTiepNhan = '" + _MaTiepNhan + "'" + (_MaDVKhac == "" ? "" : " and MaDVKhac='" + _MaDVKhac + "'");
            _strSQL += ";update CLS_BenhNhan_DVKhac set ThoiGianInKhac = getdate(), UserInKhac='" + Utilities.ConvertSqlString(_NguoiLamDVKhac) + "',LanInDVKhac = LanInDVKhac + 1, DaInKQKhac = (case when (select count(*) from KetQua_CLS_DVKhac where  MaTiepNhan = '" + _MaTiepNhan + "' and MaDVKhac='" + _MaDVKhac + "' and DaInKQKhac = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + _MaTiepNhan + "'";

            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
        public void CapNhat_DuKetQua_DVKhac(string _MaTiepNhan, bool _DuKetQua)
        {
            string _strSQL = "";
            if (_DuKetQua)
            {
                _strSQL = "update CLS_BenhNhan_DVKhac set DuKQKhac = 1 where (select count(*) from KetQua_CLS_DVKhac where XacNhanKQ = 0 and MaTiepNhan = '" + _MaTiepNhan + "') = 0 and MaTiepNhan = '" + _MaTiepNhan + "'";
            }
            else
            {
                _strSQL = "update CLS_BenhNhan_DVKhac set DuKQKhac = 0 where MaTiepNhan = '" + _MaTiepNhan + "'";
            }
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
        public void CapNhat_HinhChon_DVKhac(string _MaTiepNhan, string _MaDVKhac, bool _h1, bool _h2, bool _h3, bool _h4, bool _h5)
        {
            string _strSQL = "update KetQua_CLS_DVKhac set Hinh1 = " + (_h1 == true ? "1" : "0") + ", Hinh2 = " + (_h2 == true ? "1" : "0") + ",Hinh3 = " + (_h3 == true ? "1" : "0") + ",Hinh4 = " + (_h4 == true ? "1" : "0") + ",Hinh5 = " + (_h5 == true ? "1" : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "' and MaDVKhac='" + _MaDVKhac + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
        public DataTable Load_DanhSach_ChiDinhDVKhac(string _MaTiepNhan)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select K.*, N.MauKQ, M.SoHinh from KetQua_CLS_DVKhac K inner join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac N on k.MaNhomCLS = N.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_DVKhac_MauKQ M on M.MauKQ = N.MauKQ where MatiepNhan='" + _MaTiepNhan + "'").Tables[0];
        }
        public DataTable Load_ChiDinh_DVKhac(string _MaTiepNhan, string _MaDVKhac)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select K.*, N.MauKQ, M.SoHinh from KetQua_CLS_DVKhac K inner join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac N on k.MaNhomCLS = N.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_DVKhac_MauKQ M on M.MauKQ = N.MauKQ where MatiepNhan='" + _MaTiepNhan + "' and MaDVKhac ='" + _MaDVKhac + "'").Tables[0];
        }
        public DataTable Load_ChiDinh_DVKhac(string _MaTiepNhan, string _MaDVKhac, string _LoaiMau)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select K.*, N.MauKQ, M.SoHinh from KetQua_CLS_DVKhac K inner join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac N on k.MaNhomCLS = N.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_DVKhac_MauKQ M on M.MauKQ = N.MauKQ where MatiepNhan='" + _MaTiepNhan + "' and MaDVKhac ='" + _MaDVKhac + "' and n.MauKQ ='" + _MaDVKhac + "'").Tables[0];
        }
        public DataTable Load_ChiDinh_DienTim(string _MaTiepNhan)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select K.*, N.MauKQ, M.SoHinh from KetQua_CLS_DVKhac K inner join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac N on k.MaNhomCLS = N.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_DVKhac_MauKQ M on M.MauKQ = N.MauKQ where MatiepNhan='" + _MaTiepNhan + "' and n.MauKQ ='DT'").Tables[0];
        }
        public DataTable Load_ChiDinh_DienTim(string _MaTiepNhan, string _MaDV)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select K.*, N.MauKQ, M.SoHinh from KetQua_CLS_DVKhac K inner join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac N on k.MaNhomCLS = N.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_DVKhac_MauKQ M on M.MauKQ = N.MauKQ where MatiepNhan='" + _MaTiepNhan + "' and MaDVKhac ='" + _MaDV + "' and n.MauKQ ='DT'").Tables[0];
        }
        public void CapNhat_SauChiDinh_DVKhac(string _MaTiepNhan, string _TenTruong, bool _Co, string _User)
        {
            string _strSQL = "update KetQua_CLS_DVKhac set " + _TenTruong + " = " + (_Co == true ? "1" + (_User != "" ? ",UserInKhac= case len(UserInKhac) > 0 then UserInKhac + ',' + '" + _User + "' else '" + _User + "' end , LanInDVKhac= LanInDVKhac + 1  " : "") : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
        public void CapNhat_ThuTien(string _MaTiepNhan, string _ChiDinh, bool _DaThu)
        {
            string _strSQL = "update KetQua_CLS_DVKhac set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _strSQL += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaDVKhac in (" + _ChiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
        public void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt, bool _DefaultChecked)
        {
            dt = new DataTable();
            string _strSQL = " select cast (" + (_DefaultChecked == true ? "1" : "0") + " as bit) as chon, MatiepNhan,cast(MaDVKhac as varchar(20)) as MaChiDinh, TenDVKhac as TenChiDinh,MaNhomDVKhac as MaNhomCLS, MaPhanLoai,GiaRieng, DaThuTien, UserNhapCD, N'SIÊU ÂM' as LoaiChiDinh from KetQua_CLS_DVKhac";
            if (_filter != "")
            {
                _strSQL += " where " + _filter;
            }
            _strSQL += " order by MaNhomDVKhac, MaDVKhac, TenDVKhac";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }


        public void Search_PatientDVKhac(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID, string _Category, DataGridView dtg, BindingNavigator bv)
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,tx.KetLuanDVKhac as KetLuan, tx.DuKQKhac as DuKQ,tx.DaInKQKhac as DaIn \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "inner join CLS_BenhNhan_DVKhac tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            strSQL += "inner join KetQua_CLS_DVKhac k on t.MaTiepNhan = k.MaTiepNhan \n";
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
                strSQL += " and tx.DuKQKhac = 1";
            }
            if (_Printed)
            {
                strSQL += " and tx.DaInKQKhac = 1";
            }
            if (_TestID != "")
            {
                strSQL += " and k.MaDVKhac = '" + _TestID + "' \n";
            }
            if (_Category != "")
            {
                strSQL += " and k.MaNhomDVKhac = '" + _Category + "' \n";
            }
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Update_ImagePath(string _Path,  string _MaTiepNhan, string _Ma)
        {
            string _strSQL = "update KetQua_CLS_DVKhac set NoiLuuHinhAnh = N'" + Utilities.ConvertSqlString(_Path) + "' where MaTiepNhan ='" + _MaTiepNhan + "' and MaDVKhac ='" + _Ma.Trim() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text,_strSQL);
        }
    }
}
