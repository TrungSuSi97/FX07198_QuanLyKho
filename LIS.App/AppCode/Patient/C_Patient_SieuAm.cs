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
    class C_Patient_SieuAm : C_Patient
    {

        
        public C_Patient_SieuAm()
        {
        }

        public DataTable Get_Patient_SieuAm(string _MaTiepNhan, string _DateIN, int _PrintType)
        {
            string sqlQuery = " select * from BenhNhan_TiepNhan t inner Join BenhNhan_CLS_SieuAm tx on t.MaTiepNhan = tx.MaTiepNhan where 1=1 ";
            if (_MaTiepNhan != "")
                sqlQuery += "\n and T.MaTiepNhan ='" + _MaTiepNhan + "'";
            if (_DateIN != "")
            {
                sqlQuery += "\n and T.NgayTiepNhan = '" + _DateIN + "'";
            }
            if (_PrintType == 1)
            {
                //Đã in
                sqlQuery += "\n and Tx.DaInKQSieuAm = 1";
            }
            else if (_PrintType == 2)
            {
                //Chưa in
                sqlQuery += "\n and Tx.DaInKQSieuAm = 0";
            }

            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        private void Insert_Patient_SieuAm(string _MaTiepNhan)
        {
            if (LabServices_Helper.Check_NotExits("select * from BenhNhan_CLS_SieuAm where MaTiepNhan ='" + _MaTiepNhan + "'"))
            {
                string _sqlQuery = "insert into BenhNhan_CLS_SieuAm (MaTiepNhan) select '" + _MaTiepNhan + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
            }
        }
        public bool Delete_ChiDinhCLS_SieuAm(string _MaTiepNhan, string _MaXN)
        {
            try
            {
                string sqlQuery = "delete KetQua_CLS_SieuAm where MaTiepNhan ='" + _MaTiepNhan + "'" + (_MaXN == "" ? "" : " and MaSoMau='" + _MaXN + "'");
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
                DataProvider.ExecuteNonQuery(CommandType.Text, "Delete BenhNhan_CLS_SieuAm where MaTiepNhan ='" + _MaTiepNhan + "' and (select count (*) from KetQua_CLS_SieuAm where  MaTiepNhan ='" + _MaTiepNhan + "') = 0");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Chỉ định CLS
        public void Insert_ChiDinhSieuAm(string MaTiepNhan, string MaSoMau, string _serviceID, float _DonGia)
        {
            if (
                LabServices_Helper.Check_NotExits("select * from KetQua_CLS_SieuAm where MaTiepNhan = '" +
                                               MaTiepNhan.Trim() + "' and MaSoMau = '" + MaSoMau.Trim() + "'"))
            {
                Insert_Patient_SieuAm(MaTiepNhan);
                string sqlQuery = "";
                sqlQuery =
                    "insert into KetQua_CLS_SieuAm (MaTiepNhan, MaSoMau, TenMauSieuAm, TenChiDinh, TieuDePhieuKetQua" +
                    "\n, Ketluan, DeNghi, SoLuongHinh, SoTrangIn, NoiDung1, NoiDung2, GiaChuan, GiaRieng,MaNhomSieuAm, MAPHANLOAI)";
                sqlQuery += "\n select '" + MaTiepNhan +
                          "' as MaTiepNhan, x.MaSoMau, TenMauSieuAm,x.TenChiDinh,x.TieuDePhieuKetQua\n" +
                          ",x.KetluanMacDinh,x.DeNghi,x.SoLuongHinh,x.SoTrangIn,x.NoiDung1,x.NoiDung2,x.GiaChuan," +
                          (_DonGia < 0 ? "d.GiaRieng" : _DonGia.ToString("N3")) + ",x.MaNhomSieuAm, '" +
                          ServiceType.ClsSieuAm.ToString() + "'";
                sqlQuery +=
                    "\nfrom {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm x inner join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia d on (cast(x.MaSoMau as varchar(20)) = d.MaDichVu  and d.MaDoiTuongDichVu='" +
                    _serviceID + "' and d.MaLoaiDichVu='ClsSieuAm') where x.MaSoMau=" + MaSoMau + "\n" +
                    " and x.MaSoMau not in (select k.MaSoMau from KetQua_CLS_SieuAm k where MaTiepNhan ='" +
                    MaTiepNhan + "')";
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Chỉ định siêu âm đã được nhập trước !");
            }
        }

        //Get for CLS_KetQua
        public DataTable DuLieuIn_SieuAm(DataTable dtThongTin, int _Index, bool _LayMailTheBN, string _MaSoMau)
        {
            DataTable dtData = new DataTable();
            string _MaTiepNhan = dtThongTin.Rows[_Index]["MaTiepNhan"].ToString().Trim();
            string _TGNhap = DateTime.Parse(dtThongTin.Rows[_Index]["ThoiGianNhap"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            string _MaBN = dtThongTin.Rows[_Index]["MaBN"].ToString().Trim();
            string sqlQuery = "";
            sqlQuery = "declare @MaTiepNhan varchar(20) \n";
            sqlQuery += "declare @MaSoMau int\n";
            //sqlQuery += "declare @ThoiGianNhap datetime\n";
            ////Mã tiếp nhận đang kiểm tra
            sqlQuery += " set @MaTiepNhan='" + _MaTiepNhan + "'\n";
            ////Mã BN
            sqlQuery += " set @MaSoMau=" + (_MaSoMau == "" ? "0" : _MaSoMau) + "\n";
            ////Thoi Gian Nhập của MaTiepNhan đang xét
            //sqlQuery += " set @ThoiGianNhap='" + _TGNhap + "'\n";
            sqlQuery += " select t.MaTiepNhan, t.MaBN,t.SEQ,t.TenBN, t.ChanDoan,case when t.Tuoi > 1000 then year(t.NgayTiepNhan) - t.Tuoi else t.Tuoi end as Tuoi, case when t.GioiTinh = 'M' then N'Nam' when t.GioiTinh = 'F' then N'Nữ' else N'' end as GioiTinh \n";
            sqlQuery += ",t.DiaChi,t.Email as EmailBN, " + (_LayMailTheBN == true ? "t.Email" : "d.EmailDoiTuongDichVu") + " as MailTo,t.SDT,t.NgayTiepNhan, nv.TenNhanVien as BSChiDinh\n";
            sqlQuery += ",k.DeNghi,k.Ketluan,k.NguoiXacNhan,k.NoiDung1,k.NoiDung2\n";
            sqlQuery += ",k.SoLuongHinh,k.SoTrangIn,k.TenMauSieuAm,k.TieuDePhieuKetQua,k.MaSoMau\n";
            sqlQuery += ",k.Hinh1,k.Hinh2,k.Hinh3,k.Hinh4,k.Hinh5,k.Hinh6, k.HinhIn1, k.HinhIn2, k.HenTaiKham\n";
            sqlQuery += ",CAST (null as Image) as HinhKQ1,CAST (null as Image) as HinhKQ2,CAST (null as Image) as HinhKQ3\n";
            sqlQuery += ",CAST (null as Image) as HinhKQ4,CAST (null as Image) as HinhKQ5\n";
            sqlQuery += ",d.DiaChiDoiTuongDichVu,d.EmailDoiTuongDichVu,d.LamTieuDe,d.PhoneDoiTuongDichVu,D.TenDoiTuongDichVu\n";
            sqlQuery += ", m.TenMay as TenMaySieuAm, cast (null as Image) as Barcode\n";
            sqlQuery += "\n,H.[TenPhieuIn],H.[TieuDe1],H.[TieuDe2]";
            sqlQuery += "\n,H.[TieuDe3],H.[TieuDe4],H.[TieuDe5],H.[TieuDe6],H.[NguoiKyTen],H.[ChucVu]";
            sqlQuery += "\n,H.[InMau],H.[ReportLogo], cast(case when H.[ReportLogo]  is null then 1 else 0 end as bit) as NullReportLogo  ";
            sqlQuery += "from BenhNhan_TiepNhan t inner join KetQua_CLS_SieuAm k on t.MaTiepNhan=k.MaTiepNhan\n";
            sqlQuery += "left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD=nv.MaNhanVien\n";
            sqlQuery += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu d on t.DoiTuongDichVu = d.MaDoiTuongDichVu\n";
            sqlQuery += "left join {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm m on k.MaySieuAm = m.IDMay\n";
            sqlQuery += "\nleft join {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn(nolock) h on h.MaDonVi = 'SA'";
            sqlQuery += "where t.MaTiepNhan = @MaTiepNhan";
            if (_MaSoMau != "")
            {
                sqlQuery += "\nand k.MaSoMau = @MaSoMau";
            }
            dtData = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            Get_HinhAnh(ref dtData, _MaTiepNhan);
            return dtData;
        }
        public DataTable DuLieuTienSu(string _MaBN)
        {
            string sqlQuery = "";
            //Lấy tất cả các xét nghiệm của bệnh nhân
            sqlQuery = "select A.MaSoMau as MaChiDinh, A.TenMauSieuAm as TenChiDinh";
            sqlQuery += "\nfrom (";
            sqlQuery += "\nselect distinct MaSoMau, TenMauSieuAm";
            sqlQuery += "\n from KetQua_CLS_SieuAm k inner join BenhNhan_TiepNhan t on k.MaTiepNhan = t.MaTiepNhan";
            sqlQuery += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm n on n.MaNhomSieuAm = k.MaNhomSieuAm";
            sqlQuery += "\nwhere t.MaBN = '" + _MaBN + "'";
            sqlQuery += "\n) as A \nOrder by MaSoMau, TenMauSieuAm";
            DataTable dtChiDinh = new DataTable();
            dtChiDinh = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            if (dtChiDinh.Rows.Count > 0)
            {
                RicherTextBox.RicherTextBox rc = new RicherTextBox.RicherTextBox();
                //Lấy danh sách lần tiếp nhận
                DataTable dtTiepNhan = new DataTable();
                sqlQuery = "select t.MaTiepNhan,t.NgayTiepNhan from BenhNhan_TiepNhan t inner join BenhNhan_CLS_SieuAm tx on t.MaTiepNhan = tx.MaTiepNhan where t.MaBN = '" + _MaBN + "'";
                dtTiepNhan = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
                string _ColumnName = "", _MaTiepNhan = "", _MaXNKQ = "";
                DataTable dtResult = new DataTable();
                for (int i = 0; i < dtTiepNhan.Rows.Count; i++)
                {
                    _MaXNKQ = "";
                    _MaTiepNhan = dtTiepNhan.Rows[i]["MaTiepNhan"].ToString().Trim();
                    _ColumnName = _MaTiepNhan + "(" + ((DateTime)dtTiepNhan.Rows[i]["NgayTiepNhan"]).ToString("dd/MM/yyyy") + ")";
                    dtChiDinh.Columns.Add(_ColumnName);
                    sqlQuery = "select k.Ketluan as KetQua,k.MaSoMau as MaChiDinh from KetQua_CLS_SieuAm k where k.MaTiepNhan = '" + _MaTiepNhan + "'";
                    dtResult = new DataTable();
                    dtResult = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
                    for (int y = 0; y < dtResult.Rows.Count; y++)
                    {
                        _MaXNKQ = dtResult.Rows[y]["MaChiDinh"].ToString().Trim().ToLower();
                        for (int r = 0; r < dtChiDinh.Rows.Count; r++)
                        {
                            if (dtChiDinh.Rows[r]["MaChiDinh"].ToString().Trim().ToLower().Equals(_MaXNKQ))
                            {
                                rc.Rtf = dtResult.Rows[y]["KetQua"].ToString().Trim();
                                dtChiDinh.Rows[r][_ColumnName] =rc.Text ;
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

                _MaSA = dtGet.Rows[i]["MaSoMau"].ToString();
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
        public void CapNhat_KQ_SieuAm(string _MaTiepNhan, string _MaSoMau, string _KetQua1, string _KetQua2, string _KetLuan, string _NguoiTH, string _MaySieuAm, string _NguoiKy, string _DeNghi, string _NgayTaiKham)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set NoiDung1 = N'" + Utilities.ConvertSqlString(_KetQua1) + "'";
            _sqlQuery += "\n, NoiDung2=N'" + Utilities.ConvertSqlString(_KetQua2) + "'";
            _sqlQuery += "\n, KetLuan=N'" + Utilities.ConvertSqlString(_KetLuan) + "'";
            _sqlQuery += "\n, DeNghi=" + (_DeNghi == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(_DeNghi) + "'");
            _sqlQuery += "\n, HenTaiKham=" + (_NgayTaiKham == "" ? "NULL" : "'" + _NgayTaiKham + "'");
            _sqlQuery += "\n, NguoiNhapKQ ='" + Utilities.ConvertSqlString(_NguoiTH) + "'";
            _sqlQuery += "\n, NguoiKy ='" + Utilities.ConvertSqlString(_NguoiKy) + "'";
            _sqlQuery += "\n, MaySieuAm = " + (_MaySieuAm == "" ? "0" : _MaySieuAm) ;
            _sqlQuery += "\n, ThoiGianNhapKQ = getdate()";
            _sqlQuery += "\n where MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMau=" + _MaSoMau;
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
        public void XacNhan_KQ_SieuAm(string _MaTiepNhan, string _MaSoMau, string _TrangThai, bool _valid, string _NguoiXacNhan)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set TrangThai = N'" + Utilities.ConvertSqlString(_TrangThai) + "', NguoiXacNhan='" + Utilities.ConvertSqlString(_NguoiXacNhan) + "', XacNhanKQ = " + (_valid == true ? "1" : "0") + ", ThoiGianXacNhan = getdate() where MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMau='" + _MaSoMau + "'";
            _sqlQuery += ";Update BenhNhan_CLS_SieuAm set ValidKQSieuAm = (case when (select count(*) from KetQua_CLS_SieuAm where  MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMau='" + _MaSoMau + "' and XacNhanKQ = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
            CapNhat_DuKetQua_SieuAm(_MaTiepNhan, _valid);
        }
        public void CapNhat_In_KQ_SieuAm(string _MaTiepNhan, string _NguoiLamSieuAm, string _MaSoMau)
        {
            string _sqlQuery = " update KetQua_CLS_SieuAm set DaInKQ = 1, ThoigianIn = getdate()  where MaTiepNhan = '" + _MaTiepNhan + "'" + (_MaSoMau == "" ? "" : " and MaSoMau=" + _MaSoMau);
            _sqlQuery += ";update BenhNhan_CLS_SieuAm set ThoiGianInSieuAm = getdate(), UserInSieuAm='" + Utilities.ConvertSqlString(_NguoiLamSieuAm) + "',LanInSieuAm = LanInSieuAm + 1, DaInKQSieuAm = (case when (select count(*) from KetQua_CLS_SieuAm where  MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMau='" + _MaSoMau + "' and DaInKQ = 0) = 0 then 1 else 0 end) where MaTiepNhan = '" + _MaTiepNhan + "'";

            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
        public void CapNhat_DuKetQua_SieuAm(string _MaTiepNhan, bool _DuKetQua)
        {
            string _sqlQuery = "";
            if (_DuKetQua)
            {
                _sqlQuery = "update BenhNhan_CLS_SieuAm set DuKQSieuAm = 1 where (select count(*) from KetQua_CLS_SieuAm where XacNhanKQ = 0 and MaTiepNhan = '" + _MaTiepNhan + "') = 0 and MaTiepNhan = '" + _MaTiepNhan + "'";
            }
            else
            {
                _sqlQuery = "update BenhNhan_CLS_SieuAm set DuKQSieuAm = 0 where MaTiepNhan = '" + _MaTiepNhan + "'";
            }
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
        public void CapNhat_HinhChon_SieuAm(string _MaTiepNhan, string _MaSoMau, bool _h1, bool _h2, bool _h3, bool _h4, bool _h5)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set Hinh1 = " + (_h1 == true ? "1" : "0") + ", Hinh2 = " + (_h2 == true ? "1" : "0") + ",Hinh3 = " + (_h3 == true ? "1" : "0") + ",Hinh4 = " + (_h4 == true ? "1" : "0") + ",Hinh5 = " + (_h5 == true ? "1" : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "' and MaSoMau='" + _MaSoMau + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
        public DataTable Load_ChiDinhSieuAm(string _MaTiepNhan)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select * from KetQua_CLS_SieuAm where MatiepNhan='" + _MaTiepNhan + "'").Tables[0];
        }
        public void CapNhat_SauChiDinh_SieuAm(string _MaTiepNhan, string _TenTruong, bool _Co, string _User)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set " + _TenTruong + " = " + (_Co == true ? "1" + (_User != "" ? ",UserInSieuAm= case len(UserInSieuAm) > 0 then UserInSieuAm + ',' + '" + _User + "' else '" + _User + "' end , LanInSieuAm= LanInSieuAm + 1  " : "") : "0") + " where MaTiepNhan = '" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
        public void CapNhat_ThuTien(string _MaTiepNhan, string _ChiDinh, bool _DaThu)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set DaThuTien = " + (_DaThu == true ? "1" : "0");
            _sqlQuery += "\nWhere MatiepNhan = '" + _MaTiepNhan + "' and MaSoMau in (" + _ChiDinh + ")";
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
        public void Get_DanhSachChiDinh(DataGridView dtg, BindingNavigator bv, string _filter, ref DataTable dt, bool _DefaultChecked)
        {
            dt = new DataTable();
            string _sqlQuery = " select cast (" + (_DefaultChecked == true ? "1" : "0") + " as bit) as chon, MatiepNhan,cast(MaSoMau as varchar(20)) as MaChiDinh, TenMauSieuAm as TenChiDinh,MaNhomSieuAm as MaNhomCLS, MaPhanLoai,GiaRieng, DaThuTien, UserNhapCD, N'SIÊU ÂM' as LoaiChiDinh from KetQua_CLS_SieuAm";
            if (_filter != "")
            {
                _sqlQuery += " where " + _filter;
            }
            _sqlQuery += " order by MaNhomSieuAm, MaSoMau, TenMauSieuAm";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }


        public void Search_PatientSieuAm(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID, string _Category,bool nhapTheoDanhSach, DataGridView dtg, BindingNavigator bv)
        {
            string sqlQuery = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            sqlQuery += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,tx.KetLuanSieuAm as KetLuan, tx.DuKQSieuAm as DuKQ,tx.DaInKQSieuAm as DaIn \n";
            sqlQuery += "from BenhNhan_TiepNhan t \n";
            sqlQuery += "inner join BenhNhan_CLS_SieuAm tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            sqlQuery += "inner join KetQua_CLS_SieuAm k on t.MaTiepNhan = k.MaTiepNhan \n";
            sqlQuery += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D on t.DoiTuongDichVu = d.MaDoiTuongDichVu \n";
            sqlQuery += "where t.NgayTiepNhan between '" + _dtDateFrom.ToString("yyyy-MM-dd 00:00:00.00") + "' and '" + _dtDateTo.ToString("yyyy-MM-dd 00:00:00.00") + "'";
            if (_ServiceID != "")
            {
                sqlQuery += " and t.DoiTuongDichVu='" + _ServiceID.Trim() + "'";
            }
            if (_Seq != "")
            {
                sqlQuery += " and t.SEQ = '" + _Seq.Trim() + "'";
            }
            if (_Name != "")
            {
                sqlQuery += " and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            if (_FullRsult)
            {
                sqlQuery += " and tx.DuKQSieuAm = 1";
            }
            if (_Printed)
            {
                sqlQuery += " and tx.DaInKQSieuAm = 1";
            }
            if (_TestID != "")
            {
                sqlQuery += " and k.MaSoMau = '" + _TestID + "' \n";
            }
            if (_Category != "")
            {
                sqlQuery += " and k.MaNhomSieuAm = '" + _Category + "' \n";
            }
            if (nhapTheoDanhSach)
                sqlQuery += "\n and NguonNhap ='" + InputSourceEnum.ByList.ToString() + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Update_ImagePath(string _Path, string _No,string _MaTiepNhan, string _MaSoMau)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set Hinh" + _No + " = N'" + Utilities.ConvertSqlString(_Path) + "' where MaTiepNhan ='" + _MaTiepNhan + "' and MaSoMau =" + _MaSoMau.Trim();
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }

        public void Update_ImagePrintChoice(string _Img1, string _Img2, string _MaTiepNhan, string _MaSoMau)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set HinhIn1 = " + (_Img1 == "" ? "0" : _Img1) + ", HinhIn2 = " + (_Img2 == "" ? "0" : _Img2) + " where MaTiepNhan ='" + _MaTiepNhan + "' and MaSoMau =" + _MaSoMau.Trim();
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }

        public void Update_VideoPath(string _Path, string _MaTiepNhan, string _MaSoMau)
        {
            string _sqlQuery = "update KetQua_CLS_SieuAm set VideoClip = N'" + Utilities.ConvertSqlString(_Path) + "' where MaTiepNhan ='" + _MaTiepNhan + "' and MaSoMau =" + _MaSoMau.Trim();
            DataProvider.ExecuteNonQuery(CommandType.Text, _sqlQuery);
        }
    }
}
