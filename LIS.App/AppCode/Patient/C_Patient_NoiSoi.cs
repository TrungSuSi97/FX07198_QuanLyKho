using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Patient.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode.Patient
{
    class C_Patient_NoiSoi : C_Patient
    {

        
        public C_Patient_NoiSoi()
        {
        }

        public DataTable Get_Patient_NoiSoi(string _MaTiepNhan, string _DateIN, int _PrintType)
        {
            string strSQL = " select * from BenhNhan_TiepNhan t inner Join BenhNhan_CLS_NoiSoi tx on t.MaTiepNhan = tx.MaTiepNhan where 1=1 ";
            if (_MaTiepNhan != "")
                strSQL += "\n and T.MaTiepNhan ='" + _MaTiepNhan + "'";
            if (_DateIN != "")
            {
                strSQL += "\n and T.NgayTiepNhan = '" + _DateIN + "'";
            }
            if (_PrintType == 1)
            {
                //Đã in
                strSQL += "\n and Tx.DaInKQNoiSoi = 1";
            }
            else if (_PrintType == 2)
            {
                //Chưa in
                strSQL += "\n and Tx.DaInKQNoiSoi = 0";
            }

            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
        private void Insert_Patient_NoiSoi(string _MaTiepNhan)
        {
            if (LabServices_Helper.Check_NotExits("select * from BenhNhan_CLS_NoiSoi where MaTiepNhan ='" + _MaTiepNhan + "'"))
            {
                string _strSQL = "insert into BenhNhan_CLS_NoiSoi (MaTiepNhan) select '" + _MaTiepNhan + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            }
        }
        public bool Delete_ChiDinhCLS_NoiSoi(string _MaTiepNhan, string _MaXN)
        {
            try
            {
                string strSQL = "delete KetQua_CLS_NoiSoi where MaTiepNhan ='" + _MaTiepNhan + "'" + (_MaXN == "" ? "" : " and MaSoMauNoiSoi='" + _MaXN + "'");
                DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
                DataProvider.ExecuteNonQuery(CommandType.Text, "Delete BenhNhan_CLS_NoiSoi where MaTiepNhan ='" + _MaTiepNhan + "' and (select count (*) from KetQua_CLS_NoiSoi where  MaTiepNhan ='" + _MaTiepNhan + "') = 0");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Chỉ định CLS
        public void Insert_ChiDinhNoiSoi(string MaTiepNhan, string MaSoMauNoiSoi, string _serviceID, float _DonGia)
        {
            if (
                LabServices_Helper.Check_NotExits("select * from KetQua_CLS_NoiSoi where MaTiepNhan = '" +
                                               MaTiepNhan.Trim() + "' and MaSoMauNoiSoi = '" + MaSoMauNoiSoi.Trim() +
                                               "'"))
            {
                Insert_Patient_NoiSoi(MaTiepNhan);
                string strSQL = "";
                strSQL =
                    "insert into KetQua_CLS_NoiSoi (MaTiepNhan, MaSoMauNoiSoi, TenMauNoiSoi, TenChiDinh, TieuDePhieuKetQua" +
                    "\n, Ketluan, DeNghi, SoLuongHinh, SoTrangIn, NoiDung1, NoiDung2, GiaChuan, GiaRieng,MaNhomNoiSoi, MaPhanLoai)";
                strSQL += "\n select '" + MaTiepNhan +
                          "' as MaTiepNhan, x.MaSoMauNoiSoi, TenMauNoiSoi,x.TenChiDinh,x.TieuDePhieuKetQua\n" +
                          ",x.KetluanMacDinh,x.DeNghi,x.SoLuongHinh,x.SoTrangIn,x.NoiDung1,x.NoiDung2,x.GiaChuan," +
                           (_DonGia < 0 ? "d.GiaRieng" : _DonGia.ToString("N3")) + ",x.MaNhomNoiSoi,'" + ServiceType.ClsNoiSoi.ToString() + "'" +
                          " from  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi x inner join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia d on (cast(x.MaSoMauNoiSoi as varchar(20)) = d.MaDichVu and d.MaDoiTuongDichVu='" +
                          _serviceID + "' and d.MaLoaiDichVu='ClsNoiSoi') where x.MaSoMauNoiSoi=" + MaSoMauNoiSoi + "\n" +
                          " and x.MaSoMauNoiSoi not in (select k.MaSoMauNoiSoi from KetQua_CLS_NoiSoi k where MaTiepNhan ='" +
                          MaTiepNhan + "')";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Chỉ định nội soi đã được nhập trước !");
            }
        }
        //Get for CLS_KetQua
        public DataTable DuLieuIn_NoiSoi(DataTable dtThongTin, int _Index, bool _LayMailTheBN, string _MaSoMauNoiSoi)
        {
            DataTable dtData = new DataTable();
            string _MaTiepNhan = dtThongTin.Rows[_Index]["MaTiepNhan"].ToString().Trim();
            string _TGNhap = DateTime.Parse(dtThongTin.Rows[_Index]["ThoiGianNhap"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string _MaBN = dtThongTin.Rows[_Index]["MaBN"].ToString().Trim();
            string strSQL = "";
            strSQL = "declare @MaTiepNhan varchar(20) \n";
            strSQL += "declare @MaSoMauNoiSoi int\n";
            //strSQL += "declare @ThoiGianNhap datetime\n";
            ////Mã tiếp nhận đang kiểm tra
            strSQL += " set @MaTiepNhan='" + _MaTiepNhan + "'\n";
            ////Mã BN
            strSQL += " set @MaSoMauNoiSoi=" + (_MaSoMauNoiSoi == "" ? "0" : _MaSoMauNoiSoi) + "\n";
            ////Thoi Gian Nhập của MaTiepNhan đang xét
            //strSQL += " set @ThoiGianNhap='" + _TGNhap + "'\n";
            strSQL += " select t.MaTiepNhan, t.MaBN,t.SEQ,t.TenBN, t.ChanDoan,case when t.Tuoi > 1000 then year(t.NgayTiepNhan) - t.Tuoi else t.Tuoi end as Tuoi, case when t.GioiTinh = 'M' then N'Nam' when t.GioiTinh = 'F' then N'Nữ' else N'' end as GioiTinh \n";
            strSQL += ",t.DiaChi,t.Email as EmailBN, " + (_LayMailTheBN == true ? "t.Email" : "d.EmailDoiTuongDichVu") + " as MailTo,t.SDT,t.NgayTiepNhan\n";
            strSQL += ",k.DeNghi,k.Ketluan,k.NguoiXacNhan,k.NoiDung1,k.NoiDung2\n";
            strSQL += ",k.SoLuongHinh,k.SoTrangIn,k.TenMauNoiSoi,k.TieuDePhieuKetQua,k.MaSoMauNoiSoi\n";
            strSQL += ",k.Hinh1,k.Hinh2,k.Hinh3,k.Hinh4,k.Hinh5,k.Hinh6, k.HinhIn1, k.HinhIn2\n";
            strSQL += ",CAST (null as Image) as HinhKQ1,CAST (null as Image) as HinhKQ2,CAST (null as Image) as HinhKQ3\n";
            strSQL += ",CAST (null as Image) as HinhKQ4,CAST (null as Image) as HinhKQ5\n";
            strSQL += ",d.DiaChiDoiTuongDichVu,d.EmailDoiTuongDichVu,d.LamTieuDe,d.PhoneDoiTuongDichVu,D.TenDoiTuongDichVu\n";
            strSQL += ", m.TenMay as TenMayNoiSoi, cast (null as Image) as Barcode, nd.TenNhanVien as BSNoiSoi,k.KetQuaHP, kt.TenKyThuat as TenKyThuatHP \n";
            strSQL += "from BenhNhan_TiepNhan t inner join KetQua_CLS_NoiSoi k on t.MaTiepNhan=k.MaTiepNhan\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD=nv.MaNhanVien\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu d on t.DoiTuongDichVu = d.MaDoiTuongDichVu\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_MayNoiSoi m on k.MayNoiSoi = m.IDMay\n";
            strSQL += "left join DM_NoiSoi_KyThuatHP kt on k.KyThuatHP = kt.MaKyThuat\n";
            strSQL += "left join (select u.MaNguoiDung, n.TenNhanVien from {{TPH_Standard}}_System.dbo.QL_NguoiDung u inner join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on u.MaNhanVien = n.MaNhanVien) as nd on  nd.MaNguoiDung = k.NguoiKy\n";
            strSQL += "where t.MaTiepNhan = @MaTiepNhan";
            if (_MaSoMauNoiSoi != "")
            {
                strSQL += "\nand k.MaSoMauNoiSoi = @MaSoMauNoiSoi";
            }
            dtData = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            Get_HinhAnh(ref dtData, _MaTiepNhan);
            return dtData;
        }
        public DataTable DuLieuTienSu(string _MaBN)
        {
            string strSQL = "";
            //Lấy tất cả các xét nghiệm của bệnh nhân
            strSQL = "select A.MaSoMauNoiSoi as MaChiDinh, A.TenMauNoiSoi as TenChiDinh";
            strSQL += "\nfrom (";
            strSQL += "\nselect distinct MaSoMauNoiSoi, TenMauNoiSoi";
            strSQL += "\n from KetQua_CLS_NoiSoi k inner join BenhNhan_TiepNhan t on k.MaTiepNhan = t.MaTiepNhan";
            strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi n on n.MaNhomNoiSoi = k.MaNhomNoiSoi";
            strSQL += "\nwhere t.MaBN = '" + _MaBN + "'";
            strSQL += "\n) as A \nOrder by MaSoMauNoiSoi, TenMauNoiSoi";
            DataTable dtChiDinh = new DataTable();
            dtChiDinh = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            if (dtChiDinh.Rows.Count > 0)
            {
                RicherTextBox.RicherTextBox rc = new RicherTextBox.RicherTextBox();
                //Lấy danh sách lần tiếp nhận
                DataTable dtTiepNhan = new DataTable();
                strSQL = "select t.MaTiepNhan,t.NgayTiepNhan from BenhNhan_TiepNhan t inner join BenhNhan_CLS_NoiSoi tx on t.MaTiepNhan = tx.MaTiepNhan where t.MaBN = '" + _MaBN + "'";
                dtTiepNhan = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                string _ColumnName = "", _MaTiepNhan = "", _MaXNKQ = "";
                DataTable dtResult = new DataTable();
                for (int i = 0; i < dtTiepNhan.Rows.Count; i++)
                {
                    _MaXNKQ = "";
                    _MaTiepNhan = dtTiepNhan.Rows[i]["MaTiepNhan"].ToString().Trim();
                    _ColumnName = _MaTiepNhan + "(" + ((DateTime)dtTiepNhan.Rows[i]["NgayTiepNhan"]).ToString("dd/MM/yyyy") + ")";
                    dtChiDinh.Columns.Add(_ColumnName);
                    strSQL = "select k.Ketluan as KetQua,k.MaSoMauNoiSoi as MaChiDinh from KetQua_CLS_NoiSoi k where k.MaTiepNhan = '" + _MaTiepNhan + "'";
                    dtResult = new DataTable();
                    dtResult = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                    for (int y = 0; y < dtResult.Rows.Count; y++)
                    {
                        _MaXNKQ = dtResult.Rows[y]["MaChiDinh"].ToString().Trim().ToLower();
                        for (int r = 0; r < dtChiDinh.Rows.Count; r++)
                        {
                            if (dtChiDinh.Rows[r]["MaChiDinh"].ToString().Trim().ToLower().Equals(_MaXNKQ))
                            {
                                rc.Rtf = dtResult.Rows[y]["KetQua"].ToString().Trim();
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
            string _MaSA = "";
            string _patChoice1 = "", _patChoice2 = "";
            string _ColumnChoice1 = "", _ColumnChoice2 = "";
            Image img;
            for (int i = 0; i < dtGet.Rows.Count; i++)
            {

                _MaSA = dtGet.Rows[i]["MaSoMauNoiSoi"].ToString();
                _ColumnChoice1 = "Hinh" + dtGet.Rows[i]["HinhIn1"].ToString();
                _ColumnChoice2 = "Hinh" + dtGet.Rows[i]["HinhIn2"].ToString();

                if (_ColumnChoice1 != "Hinh0" && _ColumnChoice1 != "Hinh")
                {
                    _patChoice1 = dtGet.Rows[i][_ColumnChoice1].ToString();
                    if (_patChoice1 != "" && File.Exists(_patChoice1))
                    {
                        img = Image.FromFile(_patChoice1);
                        dtGet.Rows[i]["HinhKQ1"] = imageToByteArray(img);

                    }
                }
                if (_ColumnChoice2 != "Hinh0" && _ColumnChoice2 != "Hinh")
                {
                    _patChoice2 = dtGet.Rows[i][_ColumnChoice2].ToString();
                    if (_patChoice2 != "" && File.Exists(_patChoice1))
                    {
                        img = Image.FromFile(_patChoice2);
                        dtGet.Rows[i]["HinhKQ2"] = imageToByteArray(img);
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
        public void CapNhat_KQ_NoiSoi(string _MaTiepNhan, string _MaSoMauNoiSoi, string _KetQua1, string _KetQua2, string _KetLuan, string _NguoiTH, string _MayNoiSoi, string _NguoiKy, string _MaKyThuatHP, string _KetQuaHP, string _DeNghi)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set NoiDung1 = N'" + Utilities.ConvertSqlString(_KetQua1) + "', NoiDung2=N'" + Utilities.ConvertSqlString(_KetQua2) + "', KetLuan=N'" + Utilities.ConvertSqlString(_KetLuan) + "'";
            _strSQL += "\n, NguoiNhapKQ ='" + Utilities.ConvertSqlString(_NguoiTH) + "', NguoiKy ='" + Utilities.ConvertSqlString(_NguoiKy) + "'";
            _strSQL += "\n,MayNoiSoi = " + (_MayNoiSoi == "" ? "0" : _MayNoiSoi);
            _strSQL += "\n,KyThuatHP = " + (_MaKyThuatHP == "" ? "0" : "'" + _MaKyThuatHP + "'");
            _strSQL += "\n,KetQuaHP = " + (_KetQuaHP == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_KetQuaHP) + "'");
            _strSQL += "\n,DeNghi = " + (_DeNghi == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_DeNghi) + "'");
            _strSQL += "\n,ThoiGianNhapKQ = getdate()";
            _strSQL += "\n where MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi=" + _MaSoMauNoiSoi;
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void XacNhan_KQ_NoiSoi(string _MaTiepNhan, string _MaSoMauNoiSoi, string _TrangThai, bool _valid, string _NguoiXacNhan)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set TrangThai = N'" + Utilities.ConvertSqlString(_TrangThai) + "', NguoiXacNhan='" + Utilities.ConvertSqlString(_NguoiXacNhan) + "', XacNhanKQ = " + (_valid == true ? "1" : "0") + ", ThoiGianXacNhan = getdate() where MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi='" + _MaSoMauNoiSoi + "'";
            _strSQL += ";Update BenhNhan_CLS_NoiSoi set ValidKQNoiSoi = (case when (select count(*) from KetQua_CLS_NoiSoi where  MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi='" + _MaSoMauNoiSoi + "' and XacNhanKQ = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            CapNhat_DuKetQua_NoiSoi(_MaTiepNhan, _valid);
        }
        public void CapNhat_In_KQ_NoiSoi(string _MaTiepNhan, string _NguoiLamNoiSoi, string _MaSoMauNoiSoi)
        {
            string _strSQL = " update KetQua_CLS_NoiSoi set DaInKQ = 1, ThoigianIn = getdate()  where MaTiepNhan = '" + _MaTiepNhan + "'" + (_MaSoMauNoiSoi == "" ? "" : " and MaSoMauNoiSoi=" + _MaSoMauNoiSoi);
            _strSQL += ";update BenhNhan_CLS_NoiSoi set ThoiGianInNoiSoi = getdate(), UserInNoiSoi='" + Utilities.ConvertSqlString(_NguoiLamNoiSoi) + "',LanInNoiSoi = LanInNoiSoi + 1, DaInKQNoiSoi = (case when (select count(*) from KetQua_CLS_NoiSoi where  MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi='" + _MaSoMauNoiSoi + "' and DaInKQ = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + _MaTiepNhan + "'";

            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_DuKetQua_NoiSoi(string _MaTiepNhan, bool _DuKetQua)
        {
            string _strSQL = "";
            if (_DuKetQua)
            {
                _strSQL = "update BenhNhan_CLS_NoiSoi set DuKQNoiSoi = 1 where (select count(*) from KetQua_CLS_NoiSoi where XacNhanKQ = 0 and MaTiepNhan = '" + _MaTiepNhan + "') = 0 and MaTiepNhan = '" + _MaTiepNhan + "'";
            }
            else
            {
                _strSQL = "update BenhNhan_CLS_NoiSoi set DuKQNoiSoi = 0 where MaTiepNhan = '" + _MaTiepNhan + "'";
            }
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_HinhChon_NoiSoi(string _MaTiepNhan, string _MaSoMauNoiSoi, bool _h1, bool _h2, bool _h3, bool _h4, bool _h5)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set Hinh1 = " + (_h1 == true ? "1" : "0") + ", Hinh2 = " + (_h2 == true ? "1" : "0") + ",Hinh3 = " + (_h3 == true ? "1" : "0") + ",Hinh4 = " + (_h4 == true ? "1" : "0") + ",Hinh5 = " + (_h5 == true ? "1" : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi='" + _MaSoMauNoiSoi + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public DataTable Load_ChiDinhNoiSoi(string _MaTiepNhan)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select * from KetQua_CLS_NoiSoi where MatiepNhan='" + _MaTiepNhan + "'").Tables[0];
        }
        public void CapNhat_SauChiDinh_NoiSoi(string _MaTiepNhan, string _TenTruong, bool _Co, string _User)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set " + _TenTruong + " = " + (_Co == true ? "1" + (_User != "" ? ",UserInNoiSoi= case len(UserInNoiSoi) > 0 then UserInNoiSoi + ',' + '" + _User + "' else '" + _User + "' end , LanInNoiSoi= LanInNoiSoi + 1  " : "") : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void CapNhat_ThuTien(string _MaTiepNhan, string _ChiDinh, bool _DaThu)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _strSQL += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaSoMauNoiSoi in (" + _ChiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
        public void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt, bool _DefaultChecked)
        {
            dt = new DataTable();
            string _strSQL = " select cast (" + (_DefaultChecked == true ? "1" : "0") + " as bit) as chon, MatiepNhan,cast(MaSoMauNoiSoi as varchar(20)) as MaChiDinh, TenMauNoiSoi as TenChiDinh,MaNhomNoiSoi as MaNhomCLS, MaPhanLoai,GiaRieng, DaThuTien, UserNhapCD, N'SIÊU ÂM' as LoaiChiDinh from KetQua_CLS_NoiSoi";
            if (_filter != "")
            {
                _strSQL += " where " + _filter;
            }
            _strSQL += " order by MaNhomNoiSoi, MaSoMauNoiSoi, TenMauNoiSoi";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }


        public void Search_PatientNoiSoi(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID, string _Category,bool nhapTheoDanhSach, DataGridView dtg, BindingNavigator bv)
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,tx.KetLuanNoiSoi as KetLuan, tx.DuKQNoiSoi as DuKQ,tx.DaInKQNoiSoi as DaIn \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "inner join BenhNhan_CLS_NoiSoi tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            strSQL += "inner join KetQua_CLS_NoiSoi k on t.MaTiepNhan = k.MaTiepNhan \n";
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
                strSQL += " and tx.DuKQNoiSoi = 1";
            }
            if (_Printed)
            {
                strSQL += " and tx.DaInKQNoiSoi = 1";
            }
            if (_TestID != "")
            {
                strSQL += " and k.MaSoMauNoiSoi = '" + _TestID + "' \n";
            }
            if (_Category != "")
            {
                strSQL += " and k.MaNhomNoiSoi = '" + _Category + "' \n";
            }
            if (nhapTheoDanhSach)
                strSQL += "\n and NguonNhap ='" + InputSourceEnum.ByList.ToString() + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Update_ImagePath(string _Path, string _No, string _MaTiepNhan, string _MaSoMau)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set Hinh" + _No + " = N'" + Utilities.ConvertSqlString(_Path) + "' where MaTiepNhan ='" + _MaTiepNhan + "' and MaSoMauNoiSoi =" + _MaSoMau.Trim();
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }

        public void Update_ImagePrintChoice(string _Img1, string _Img2, string _MaTiepNhan, string _MaSoMau)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set HinhIn1 = " + (_Img1 == "" ? "0" : _Img1) + ", HinhIn2 = " + (_Img2 == "" ? "0" : _Img2) + " where MaTiepNhan ='" + _MaTiepNhan + "' and MaSoMauNoiSoi =" + _MaSoMau.Trim();
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }

        public void Update_VideoPath(string _Path, string _MaTiepNhan, string _MaSoMau)
        {
            string _strSQL = "update KetQua_CLS_NoiSoi set VideoClip = N'" + Utilities.ConvertSqlString(_Path) + "' where MaTiepNhan ='" + _MaTiepNhan + "' and MaSoMauNoiSoi =" + _MaSoMau.Trim();
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
        }
    }
}
