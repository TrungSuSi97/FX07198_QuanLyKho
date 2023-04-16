using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Data;
using TPH.LIS.Log;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Common.Extensions;
using System.Collections.Generic;

namespace TPH.LIS.App.AppCode.Patient
{
    class C_Patient
    {
       public readonly IWorkingLogService _workingLog = new WorkingLogService();
        public C_Patient()
        {
        }
        public bool InsertPatient_Reception(string maTiepNhan, string seq, string maBn, string tenBn, string sinhNhat, string tuoi,
            string coNgaySinh, string gioiTinh, string ngayTiepNhan, string khamLanDau,
            string userNhap, string maDonVi, string doiTuongDichVu, string diaChi, string email, string sdt,
            string tinhTrangBenh, string tienSuBenh, string maTinh, string maHuyen, string phuongXa, string soNha, string soBhyt, string ngayHetHanBhyt,
            string dvKhamBenh, string dvXetNghiem, string dvxQuang, string dvSieuAm, string dvNoiSoi, string dvDienTim, string dvKhac)
        {
            try
            {
                string strSql = " insert into BenhNhan_TiepNhan (MaTiepNhan, Seq, MaBN, TenBN, SinhNhat, Tuoi,\n" +
                " CoNgaySinh, GioiTinh, NgayTiepNhan, ThoiGianNhap, UserNhap, MaDonVi, DoiTuongDichVu,KhamLanDau,\n" +
                " DiaChi, Email, SDT, TinhTrangBenh, TienSuBenh, MaTinh, MaHuyen, PhuongXa, SoNha,SoBHYT,NgayHetHanBHYT,\n" +
                "DichVuKhamBenh,DichVuXetNghiem, DichVuXQuang,DichVuSieuAm, DichVuNoiSoi, DichVuDienTim, DichVuKhac )\n";
                strSql += " select '" + maTiepNhan + "'";
                strSql += "\n," + seq ;
                strSql += "\n,'" + maBn + "'";
                strSql += "\n,N'" + Utilities.ConvertSqlString(tenBn) + "'";
                strSql += "\n," + (sinhNhat == "" ? "NULL" : sinhNhat);
                strSql += "\n," + tuoi ;
                strSql += "\n," + coNgaySinh;
                strSql += "\n,'" + gioiTinh + "'";
                strSql += "\n,'" + ngayTiepNhan + "'";
                strSql += "\n,getdate()";
                strSql += "\n,'" + userNhap + "'";
                strSql += "\n," + (string.IsNullOrEmpty(maDonVi) ? "NULL" : "'" + maDonVi + "'");
                strSql += "\n," + (string.IsNullOrEmpty(doiTuongDichVu) ? "NULL" : "'" + doiTuongDichVu + "'");
                strSql += "\n," + (khamLanDau == "" ? "0" : khamLanDau);
                strSql += "\n," + (string.IsNullOrEmpty(diaChi) ? "NULL" : "N'" + Utilities.ConvertSqlString(diaChi) + "'"); 
                strSql += "\n," + (string.IsNullOrEmpty(email) ? "NULL" : "N'" + Utilities.ConvertSqlString(email) + "'");
                strSql += "\n," + (string.IsNullOrEmpty(sdt) ? "NULL" : "'" + sdt + "'");
                strSql += "\n," + (string.IsNullOrEmpty(tinhTrangBenh) ? "NULL" : "N'" + Utilities.ConvertSqlString(tinhTrangBenh) + "'");
                strSql += "\n," + (string.IsNullOrEmpty(tienSuBenh) ? "NULL" : "N'" + Utilities.ConvertSqlString(tienSuBenh) + "'"); 
                strSql += "\n," + (maTinh == "" ? "0" : maTinh);
                strSql += "\n," + (maHuyen == "" ? "0" : maHuyen);
                strSql += "\n," + (string.IsNullOrEmpty(phuongXa) ? "NULL" : "N'" + Utilities.ConvertSqlString(phuongXa) + "'");
                strSql += "\n," + (string.IsNullOrEmpty(soNha) ? "NULL" : "N'" + Utilities.ConvertSqlString(soNha) + "'"); 
                strSql += "\n,'" + Utilities.ConvertSqlString(soBhyt) + "'";
                strSql += "\n," + (string.IsNullOrEmpty(ngayHetHanBhyt) ? "NULL" : "'" + ngayHetHanBhyt + "'"); 
                strSql += "\n," + (dvKhamBenh == "" ? "0" : dvKhamBenh) ;
                strSql += "\n," + (dvXetNghiem == "" ? "0" : dvXetNghiem) ;
                strSql += "\n," + (dvxQuang == "" ? "0" : dvxQuang) ;
                strSql += "\n," + (dvSieuAm == "" ? "0" : dvSieuAm) ;
                strSql += "\n," + (dvNoiSoi == "" ? "0" : dvNoiSoi) ;
                strSql += "\n," + (dvDienTim == "" ? "0" : dvDienTim);
                strSql += "\n," + (dvKhac == "" ? "0" : dvKhac);
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePatient_Reception(string maTiepNhan, string maBn, string tenBn, string sinhNhat, string tuoi,
            string coNgaySinh, string gioiTinh, string ngayTiepNhan, string khamLanDau,
            string userCapNhat, string maDonVi, string doiTuongDichVu, string diaChi, string email, string sdt,
            string tinhTrangBenh, string tienSuBenh, string maTinh, string maHuyen, string phuongXa, string soNha, string soBhyt, string ngayHetHanBhyt,
            string dvKhamBenh, string dvXetNghiem, string dvxQuang, string dvSieuAm, string dvNoiSoi, string dvDienTim, string dvKhac)
        {
            try
            {
                string strSql = " update BenhNhan_TiepNhan set ";
                strSql += "\nTenBN = N'" + Utilities.ConvertSqlString(tenBn) + "'";
                strSql += "\n,SinhNhat=" + (sinhNhat == "" ? "NULL" : sinhNhat) + "";
                strSql += "\n,Tuoi=" + tuoi + "";
                strSql += "\n,CoNgaySinh = " + coNgaySinh;
                strSql += "\n,GioiTinh='" + gioiTinh + "'";
                strSql += "\n,NgayTiepNhan='" + ngayTiepNhan + "'";
                strSql += "\n,UserCapNhat='" + userCapNhat + "'";
                strSql += "\n,MaDonVi=" + (string.IsNullOrEmpty(maDonVi) ? "NULL" : "'" + maDonVi + "'");
                strSql += "\n,DoiTuongDichVu=" + (string.IsNullOrEmpty(doiTuongDichVu) ? "NULL" : "'" + doiTuongDichVu + "'");
                strSql += "\n,DiaChi=N'" + Utilities.ConvertSqlString(diaChi) + "'";
                strSql += "\n,Email=N'" + Utilities.ConvertSqlString(email) + "'";
                strSql += "\n,SDT='" + sdt + "'";
                strSql += "\n, MaBN='" + maBn + "'";
                strSql += "\n, TinhTrangBenh =N'" + Utilities.ConvertSqlString(tinhTrangBenh) + "'";
                strSql += "\n, TienSuBenh =N'" + Utilities.ConvertSqlString(tienSuBenh) + "'";
                strSql += "\n, MaTinh = " + (maTinh == "" ? "0" : maTinh);
                strSql += "\n, MaHuyen = " + (maHuyen == "" ? "0" : maHuyen);
                strSql += "\n, SoNha =N'" + Utilities.ConvertSqlString(soNha) + "'";
                strSql += "\n, PhuongXa =N'" + Utilities.ConvertSqlString(phuongXa) + "'";
                strSql += "\n, SoBHYT ='" + Utilities.ConvertSqlString(soBhyt) + "'";
                strSql += "\n, NgayHetHanBHYT =" + (ngayHetHanBhyt == "" ? "NULL" : "'" + ngayHetHanBhyt + "'");
                strSql += "\n, DichVuKhamBenh = " + (dvKhamBenh == "" ? "0" : dvKhamBenh);
                strSql += "\n, DichVuXetNghiem = " + (dvXetNghiem == "" ? "0" : dvXetNghiem);
                strSql += "\n, DichVuXQuang = " + (dvxQuang == "" ? "0" : dvxQuang);
                strSql += "\n, DichVuSieuAm = " + (dvSieuAm == "" ? "0" : dvSieuAm);
                strSql += "\n, DichVuNoiSoi = " + (dvNoiSoi == "" ? "0" : dvNoiSoi);
                strSql += "\n, DichVuDienTim = " + (dvDienTim == "" ? "0" : dvDienTim);
                strSql += "\n, DichVuKhac = " + (dvKhac == "" ? "0" : dvKhac);
                strSql += "\n, KhamLanDau = " + (khamLanDau == "" ? "0" : khamLanDau);
                strSql += " where MaTiepNhan='" + maTiepNhan + "'";
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1;
            }
            catch
            {
                return false;
            }
        }

        public bool Update_Patient_ChanDoanBSChiDinh(string MaTiepNhan, string ChanDoan, string MaBS)
        {
            try
            {
                string strSQL = "";
                strSQL = "Update BenhNhan_TiepNhan set ChanDoan =" + (ChanDoan == "" ? "NULL" : "N'" + Utilities.ConvertSqlString(ChanDoan) + "'");
                strSQL += "\n, BacSiCD =" + (MaBS == "" ? "NULL" : "'" + MaBS + "'");
                strSQL += " where MaTiepNhan='" + MaTiepNhan + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetPatient(string maTiepNhan)
        {
            string strSQL = " select * from BenhNhan_TiepNhan where MaTiepNhan ='" + Utilities.ConvertSqlString(maTiepNhan) + "'";
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
        public DataTable GetPatient_List_InDay(DateTime dt, string seq = "")
        {
            string strSQL = " select T.*, N.TenNhanVien as TenBacSiCD, D.TenDoiTuongDichVu as TenDoiTuongDichVu";
            strSQL += "\n from BenhNhan_TiepNhan T left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN n on n.MaNhanVien = t.BacSiCD ";
            strSQL += "\n left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = t.DoiTuongDichVu ";
            strSQL += "\n where NgayTiepNhan ='" + dt.ToString("yyyy/MM/dd") + "'";
            if (!string.IsNullOrEmpty(seq))
                strSQL += string.Format("\n and T.seq = '{0}'", seq);
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
        public string Get_SEQ_InDay(DateTime dt)
        {
            string _strSQL = " select Max(SEQ) as MaxSEQ from BenhNhan_TiepNhan where NgayTiepNhan = '" + dt.ToString("yyyy/MM/dd") + "'";
            DataTable dtMax = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];
            if (dtMax.Rows.Count > 0)
            {
                int _max = int.Parse(dtMax.Rows[0]["MaxSEQ"].ToString() == "" ? "1000" : dtMax.Rows[0]["MaxSEQ"].ToString());
                _max++;
                return _max.ToString();
            }
            else
            {
                return "1001";
            }
        }
        public bool Delete_Patient(string maTiepNhan)
        {
            try
            {
                string strSql = "delete KetQua_CLS_XetNghiem where MaTiepNhan ='" + maTiepNhan + "'";
                //Ghi log kết quả - XN
                ResultLog(maTiepNhan, LogActionId.Delete, string.Empty, string.Empty);
                //Xóa KetQua_CLS_XetNghiem
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                //ghi log benhnhan_cls_xetnghiem
                PatientCLSXNLog(maTiepNhan, LogActionId.Delete);
                strSql = string.Format("delete benhnhan_cls_xetnghiem where MaTiepNhan='{0}'", maTiepNhan);
                //xóa benhnhan_cls_xetnghiem
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                
                strSql = "delete BenhNhan_TiepNhan where MaTiepNhan ='" + maTiepNhan + "'";
                //ghi log Benh nhan
                PatientLog(maTiepNhan, LogActionId.Delete);
                //xóa
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void PatientLog(string maTiepNhan, LogActionId action)
        {
            _workingLog.WriteLog_BenhNhan_TiepNhan(action, CommonAppVarsAndFunctions.UserID, maTiepNhan);
        }
        public void PatientCLSXNLog(string maTiepNhan, LogActionId action)
        {
            _workingLog.WriteLog_BenhNhan_CLS_XetNghiem(action, CommonAppVarsAndFunctions.UserID, maTiepNhan);
        }
        public void ResultLog(string maTiepNhan, LogActionId action, string maXn, string maProfile)
        {
           
            _workingLog.WriteLog_KetQua_CLS_XetNghiem(action, CommonAppVarsAndFunctions.UserID, maTiepNhan, new List<string> { maXn }, maProfile);
        }

        public void CapNhat_GuiMail(string _MaTiepNhan, bool _Gui)
        {
            string strSQL = "update BenhNhan_TiepNhan set DaGuiMail = " + (_Gui == true ? "1" : "0") + ", TGGuiMail=getdate() where MaTiepNhan ='" + _MaTiepNhan + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
        }
        public void Print_BienLai(string _MaTiepNhan, bool _PrintDirect, string _PrinterName, bool _HavePriceOnly, string _DKXetNghiem, string _DKSieuAm, string _DKXQuang)
        {
            string _PriceCondit = "";
            if (_HavePriceOnly)
            {
                _PriceCondit += "\n and GiaRieng > 0";
            }

            DataTable dt = new DataTable();
            string _strSQL = " select A.*, T.TenBN, T.GioiTinh, T.Tuoi as NamSinh,T.NgayTiepNhan as DateIn, T.DiaChi,D.TenDoiTuongDichVu,N'' as TenDonVi  from (\n select cast (0 as bit) as chon,MatiepNhan, MaXN as MaChiDinh, TenXN as TenChiDinh,ThuTuIn , MaNhomCLS, MaPhanLoai,GiaRieng  as GiaRieng, cast (0 as bit) as TieuDe,N'Lần' as DVT, 1 as SL, N'XÉT NGHIỆM' as LoaiChiDinh from KetQua_CLS_XetNghiem";
            _strSQL += " where MaTiepNhan = '" + _MaTiepNhan + "'" + _PriceCondit + " " + _DKXetNghiem.Trim();
            _strSQL += "\n Union all \n";
            _strSQL += " select cast (0 as bit) as chon, MatiepNhan,cast(MaSoMau as varchar(20)) as MaChiDinh, TenMauSieuAm as TenChiDinh,cast(100 as int) as ThuTuIn,MaNhomSieuAm as MaNhomCLS, MaPhanLoai,GiaRieng as GiaRieng, cast (0 as bit) as TieuDe,N'Lần' as DVT, 1 as SL, N'SIÊU ÂM' as LoaiChiDinh from KetQua_CLS_SieuAm";
            _strSQL += " where MaTiepNhan = '" + _MaTiepNhan + "'" + _PriceCondit + " " + _DKSieuAm.Trim();
            _strSQL += "\n Union all \n";
            _strSQL += " select distinct cast (0 as bit) as chon, MatiepNhan,cast(k.MaVungChup as varchar(20)) as MaChiDinh, VC.TenVungChup as TenChiDinh,cast(100 as int) as ThuTuIn,k.MaKyThuatChup as MaNhomCLS, MaPhanLoai,GiaRieng as GiaRieng, cast (0 as bit) as TieuDe,N'Lần' as DVT, 1 as SL, N'X QUANG' as LoaiChiDinh from KetQua_CLS_XQuang k left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup\n ";
            _strSQL += " where MaTiepNhan = '" + _MaTiepNhan + "'" + _PriceCondit + " " + _DKXQuang.Trim();
            _strSQL += "\n ) as A inner join BenhNhan_TiepNhan T on t.MaTiepNhan = A.MaTiepNhan\n";
            _strSQL += "\n left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D on d.MaDoiTuongDichVu = T.DoiTuongDichVu";
            _strSQL += "\n order by ThuTuIn,MaNhomCLS, MaChiDinh, TenChiDinh";
            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];

            //Reports.rpInvoice_OLD rp = new Reports.rpInvoice_OLD();
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
        public void Get_PatientList(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, DataGridView dtg, BindingNavigator bv)
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,b.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , ThoiGianNhap,MaBN \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "left join KhamBenh_KetQua  as b on t.MaTiepNhan = b.MaTiepNhan \n";
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
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Search_Patient(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID
            , string _Name, string _Seq, DataGridView dtg, BindingNavigator bv, string maBN = ""
            , string sdt = "", string idCongDan = "", bool emailonly = false)
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,b.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,t.MaBN, t.IdCongdan \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D on t.DoiTuongDichVu = d.MaDoiTuongDichVu \n";
            strSQL += "left join KhamBenh_KetQua  as b on t.MaTiepNhan = b.MaTiepNhan \n";
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
            if (!string.IsNullOrEmpty(maBN))
            {
                strSQL += " and t.MaBN = '" + maBN + "'\n";
            }
            if (!string.IsNullOrEmpty(sdt))
            {
                strSQL += " and t.SDT = '" + sdt + "'\n";
            }
            if (!string.IsNullOrEmpty(idCongDan))
            {
                strSQL += string.Format(" and t.IdCongDan = '{0}'\n ", idCongDan);
            }
            if (emailonly)
                strSQL += "\n and t.Email is not null";
            DataTable dt = new DataTable();
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable LayThongtin_TiepNhan_TheoMaBN(string _MaBN)
        {
            DataTable dtNoiTru = new DataTable();
            string strSQL = "select top 1 * from BenhNhan_TiepNhan where MaBN ='" + _MaBN + "' order by NgayTiepNhan desc";
            dtNoiTru = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtNoiTru;
        }
        public DataTable LayThongtin_TiepNhan_TheoSoDienThoai(string sodienThoai)
        {
            DataTable dtSodienthoai = new DataTable();
            string strSQL = "select top 1 * from BenhNhan_TiepNhan where SDT ='" + sodienThoai + "' order by NgayTiepNhan desc";
            dtSodienthoai = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtSodienthoai;
        }
        public DataTable LayDanhSach_TiepNhan_TheoMaBN(string _MaBN)
        {
            DataTable dtNoiTru = new DataTable();
            string strSQL = "select t.*, nv.TenNhanVien from BenhNhan_TiepNhan t left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD = nv.MaNhanVien where MaBN ='" + _MaBN + "' order by NgayTiepNhan desc";
            dtNoiTru = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtNoiTru;
        }
        public DataTable LayDanhSach_NoiTru(string _MaBN, string _Name)
        {
            DataTable dtNoiTru = new DataTable();
            string strSQL = "";
            _Name = Utilities.ConvertSqlString(_Name);
            strSQL = "select A.* , ct.HinhBN, ct.QuocTich, ct.DanToc, ct.HocVan, ct.NgheNghiep, ct.NoiLamViec";
            strSQL += "\n from (";
            strSQL += "\n Select distinct t.NoiTru, t.MaBN, t.SoBHYT, t.TenBN, t.SinhNhat, ";
            strSQL += "\n t.Tuoi, t.CoNgaySinh, t.GioiTinh, t.DoiTuongDichVu, t.DiaChi, t.PhuongXa,T.SoNha,t.MaHuyen,T.MaTinh, ";
            strSQL += "\n  t.Email, t.SDT,t.TenDonVi,t.YeuCau,t.NhanXetBS,t.TGVaoVien,t.KhamLanDau ";
            strSQL += "\n from BenhNhan_TiepNhan t where 1 = 1";
            if (_MaBN != "")
            {
                strSQL += "\n and MaBN = '" + _MaBN + "'";
            }
            if (_Name != "")
            {
                strSQL += "  \n and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            strSQL += "\n ) as A left join BenhNhan_ThongTinChiTiet ct on A.MaBN = ct.MaBN order by A.TenBN ";
            dtNoiTru = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtNoiTru;
        }
        // Insert 
        public bool Insert_BenhNhan_ThongTinChiTiet(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec
                                   , string _quoctich)
        {
            string _strSQL = "insert into  BENHNHAN_THONGTINCHITIET (";
            _strSQL += Environment.NewLine + "dantoc";
            _strSQL += Environment.NewLine + "," + "hocvan";
            _strSQL += Environment.NewLine + "," + "mabn";
            _strSQL += Environment.NewLine + "," + "nghenghiep";
            _strSQL += Environment.NewLine + "," + "noilamviec";
            _strSQL += Environment.NewLine + "," + "quoctich";
            _strSQL += Environment.NewLine + ")";
            _strSQL += Environment.NewLine + "select ";
            _strSQL += Environment.NewLine + (_dantoc == "" ? "NULL" : "N'" + _dantoc + "'");
            _strSQL += Environment.NewLine + "," + (_hocvan == "" ? "NULL" : "N'" + _hocvan + "'");
            _strSQL += Environment.NewLine + "," + (_mabn == "" ? "''" : "'" + _mabn + "'");
            _strSQL += Environment.NewLine + "," + (_nghenghiep == "" ? "NULL" : "N'" + _nghenghiep + "'");
            _strSQL += Environment.NewLine + "," + (_noilamviec == "" ? "NULL" : "N'" + _noilamviec + "'");
            _strSQL += Environment.NewLine + "," + (_quoctich == "" ? "NULL" : "'" + _quoctich + "'");
            if (LabServices_Helper.Check_NotExits("select top 1 * from BenhNhan_ThongTinChiTiet where 1 = 1  and mabn =  " + (_mabn == "" ? "''" : "'" + _mabn + "'")))
            {
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
                Update_HinhChiTiet(_mabn, _hinhbn);
                return true;
            }
            else
            {
                Update_HinhChiTiet(_mabn, _hinhbn);
                return Update_BENHNHAN_THONGTINCHITIET(_dantoc, _hinhbn, _hocvan, _mabn, _nghenghiep, _noilamviec, _quoctich);
            }

        }

        // Update 
        public bool Update_BENHNHAN_THONGTINCHITIET(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec
                                   , string _quoctich)
        {
            string _strSQL = "Update BenhNhan_ThongTinChiTiet set " + Environment.NewLine;
            _strSQL += Environment.NewLine + "dantoc = " + (_dantoc == "" ? "NULL" : "N'" + _dantoc + "'");
            _strSQL += Environment.NewLine + ",hocvan = " + (_hocvan == "" ? "NULL" : "N'" + _hocvan + "'");
            _strSQL += Environment.NewLine + ",nghenghiep = " + (_nghenghiep == "" ? "NULL" : "N'" + _nghenghiep + "'");
            _strSQL += Environment.NewLine + ",noilamviec = " + (_noilamviec == "" ? "NULL" : "N'" + _noilamviec + "'");
            _strSQL += Environment.NewLine + ",quoctich = " + (_quoctich == "" ? "NULL" : "'" + _quoctich + "'");
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and mabn =  " + (_mabn == "" ? "''" : "'" + _mabn + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            return true;
        }

        // Delete 
        public bool Delete_BENHNHAN_THONGTINCHITIET(string _mabn)
        {
            string _strSQL = "Delete from BenhNhan_ThongTinChiTiet" + Environment.NewLine;
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and mabn =  " + (_mabn == "" ? "''" : "'" + _mabn + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            return true;
        }
        private void Update_HinhChiTiet(string _MaBenhNhan,Image img)
        {
            string strSQL = "update BenhNhan_ThongTinChiTiet set hinhbn = @hinhanh where MaBN ='"+ _MaBenhNhan +"'";
            DataProvider.ExcuteWithImage(strSQL, LabServices_Helper.BufferBinaryNotOpenfile(img), img == null);
        }
        public bool CheckFunction(string[] _array, string _check)
        {
            for (int c = 0; c < _array.Length; c++)
            {
                if (_array[c].Trim().ToLower() == _check.Trim().ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
