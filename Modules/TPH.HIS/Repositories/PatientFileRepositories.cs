using System;
using System.Text;
using TPH.LIS.Data;
using System.Data;
using System.Drawing;
using TPH.LIS.Common.Extensions;
using System.Data.SqlClient;

namespace TPH.HIS.Repositories
{
    public class PatientFileRepositories : IPatientFileRepositories
    {
      public  DataTable LichSuChanDoan(string pid)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("select ChanDoan, nv.TenNhanVien +  ' (' + convert(nvarchar(10), NgayTiepNhan, 103) + ') - ID: '+ MaTiepNhan  as BacSi");
            sqlQuery.AppendLine("from benhnhan_tiepnhan tn left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on tn.BacSiCD = nv.MaNhanVien ");
            sqlQuery.AppendFormat("where mabn = '{0}' and len(tn.MaBN) > 0 and tn.MaBN is not null", pid);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];
        }
        public DataTable LichSuDonThuoc(string pid)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine("select th.*, cd.TenCachDung");
            sqlQuery.AppendLine(",nv.TenNhanVien + ' (' + convert(nvarchar(10), NgayTiepNhan, 103) + ') - ID: ' + tn.MaTiepNhan  + ' - ' + dv.TenYeuCau as BacSi");
            sqlQuery.AppendLine("from khambenh_donthuoc th");
            sqlQuery.AppendLine("inner join benhnhan_tiepnhan tn on th.MaTiepNhan = tn.MaTiepNhan");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on tn.BacSiCD = nv.MaNhanVien");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu dv on dv.MaYeuCau = th.MaYeuCau");
            sqlQuery.AppendLine("left join dm_thuoc_cachdung cd on cd.ID = th.CachDung");
            sqlQuery.AppendFormat("\nwhere tn.MaBN = '{0}' and len(tn.MaBN) > 0 and tn.MaBN is not null", pid);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];
        }
        public DataTable LichSuXetNghiem(string pid)
        {
            //StringBuilder sqlQuery = new StringBuilder();
            ////Lấy tất cả các xét nghiệm của bệnh nhân
            //sqlQuery.AppendLine("select A.MaXN as MaChiDinh, A.TenXN as TenChiDinh, TenNhomCLS, A.ThuTuNhom, a.ThuTuIn,a.SapXep");
            //sqlQuery.AppendLine("from(");
            //sqlQuery.AppendLine("select distinct k.MaXN, k.TenXN, k.ThuTuIn, n.ThuTuIn as ThuTuNhom, TenNhomCLS, xn.SapXep ");
            //sqlQuery.AppendLine(" from KetQua_CLS_XetNghiem k inner join BenhNhan_TiepNhan t on k.MaTiepNhan = t.MaTiepNhan inner join BenhNhan_CLS_XetNghiem tx on t.MaTiepNhan = tx.MaTiepNhan");
            //sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on n.MaNhomCLS = k.MaNhomCLS left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem xn on xn.MaXn = k.Maxn");
            //sqlQuery.AppendFormat("\nwhere t.MaBN = '{0}'", pid);
            //sqlQuery.AppendLine(") as A \nOrder by ThuTuNhom,SapXep, MaXN, TenXN");
            //DataTable dtChiDinh = new DataTable();
            //dtChiDinh = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];
            //string strSQL = string.Empty;
            //if (dtChiDinh.Rows.Count > 0)
            //{
            //    //Lấy danh sách lần tiếp nhận
            //    DataTable dtTiepNhan = new DataTable();
            //    strSQL = "select t.MaTiepNhan,t.NgayTiepNhan from BenhNhan_TiepNhan t inner join BenhNhan_CLS_XetNghiem tx on t.MaTiepNhan = tx.MaTiepNhan  where t.MaBN = '" + pid + "' and len(t.MaBN) > 0 and t.MaBN is not null order by t.ThoiGianNhap desc";
            //    dtTiepNhan = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            //    string _ColumnName = "", _ColumnNameFlat = "", _MaTiepNhan = "", _MaXNKQ = "";
            //    DataTable dtResult = new DataTable();
            //    for (int i = 0; i < dtTiepNhan.Rows.Count; i++)
            //    {
            //        _MaXNKQ = "";
            //        _MaTiepNhan = dtTiepNhan.Rows[i]["MaTiepNhan"].ToString().Trim();
            //        _ColumnName = _MaTiepNhan;
            //        _ColumnNameFlat = _ColumnName + "_RFlat";
            //        dtChiDinh.Columns.Add(_ColumnName);
            //        dtChiDinh.Columns.Add(_ColumnNameFlat);

            //        strSQL = "select k.KetQua ,k.Flat ,k.MaXN as MaChiDinh from KetQua_CLS_XetNghiem k  where k.MaTiepNhan = '" + _MaTiepNhan + "'";
            //        dtResult = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            //        for (int y = 0; y < dtResult.Rows.Count; y++)
            //        {
            //            _MaXNKQ = dtResult.Rows[y]["MaChiDinh"].ToString().Trim().ToLower();
            //            for (int r = 0; r < dtChiDinh.Rows.Count; r++)
            //            {
            //                if (dtChiDinh.Rows[r]["MaChiDinh"].ToString().Trim().ToLower().Equals(_MaXNKQ))
            //                {
            //                    dtChiDinh.Rows[r][_ColumnName] = dtResult.Rows[y]["KetQua"].ToString().Trim();
            //                    dtChiDinh.Rows[r][_ColumnNameFlat] = dtResult.Rows[y]["Flat"];
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
            //dtChiDinh.Columns["TenNhomCLS"].Caption = "Tên nhóm";
            //dtChiDinh.Columns["TenChiDinh"].Caption = "Tên xét nghiệm";
            //return dtChiDinh;

            StringBuilder sqlQuery = new StringBuilder();
            //Lấy tất cả các xét nghiệm của bệnh nhân
            sqlQuery.AppendFormat("Exec selTienSu_XetNghiem_DanhSachCacLanXetNghiem @MaBN = '{0}'", string.IsNullOrEmpty(pid) ? "NULL" : pid);
            DataTable dtChiDinh = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];
            string strSQL = string.Empty;
            if (dtChiDinh.Rows.Count > 0)
            {
                //Lấy danh sách lần tiếp nhận
                DataTable dtTiepNhan = new DataTable();
                strSQL = string.Format("Exec selTienSu_XetNghiem_DanhSachCacLan_TiepNhan @MaBN = '{0}'", pid);
                dtTiepNhan = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                string _ColumnName = "", _ColumnNameFlat = "", _MaTiepNhan = "", _MaXNKQ = "";
                DateTime tgNhap;
                DataTable dtResult = new DataTable();
                for (int i = 0; i < dtTiepNhan.Rows.Count; i++)
                {
                    tgNhap = DateTime.Parse(dtTiepNhan.Rows[i]["ThoiGianNhap"].ToString().Trim());
                    _MaXNKQ = "";
                    _MaTiepNhan = dtTiepNhan.Rows[i]["MaTiepNhan"].ToString().Trim();
                    _ColumnName = string.Format("{0}.({1})", _MaTiepNhan, tgNhap.ToString("HH:mm"));
                    _ColumnNameFlat = _ColumnName + "_RFlat";
                    dtChiDinh.Columns.Add(_ColumnName);
                    dtChiDinh.Columns.Add(_ColumnNameFlat);

                    strSQL = string.Format("Exec selTienSu_XetNghiem_DanhSachKetQua @MaTiepNhan ='{0}'", _MaTiepNhan);
                    dtResult = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
                    for (int y = 0; y < dtResult.Rows.Count; y++)
                    {
                        _MaXNKQ = dtResult.Rows[y]["MaChiDinh"].ToString().Trim().ToLower();
                        for (int r = 0; r < dtChiDinh.Rows.Count; r++)
                        {
                            if (dtChiDinh.Rows[r]["MaChiDinh"].ToString().Trim().ToLower().Equals(_MaXNKQ))
                            {
                                dtChiDinh.Rows[r][_ColumnName] = dtResult.Rows[y]["KetQua"].ToString().Trim();
                                dtChiDinh.Rows[r][_ColumnNameFlat] = dtResult.Rows[y]["Flat"];
                                break;
                            }
                        }
                    }
                }
            }
            dtChiDinh.Columns["TenNhomCLS"].Caption = "Tên nhóm";
            dtChiDinh.Columns["TenChiDinh"].Caption = "Tên xét nghiệm";
            return dtChiDinh;
        }
        public DataTable LichSuXetNghiemViSinh(string pid)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
            "selTienSu_XetNghiemViSinh"
            , new SqlParameter[]
            {
                 new SqlParameter("@MaBN",pid)
            });
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        public DataTable LichSuSieuAm(string pid, bool kieuluoi)
        {
            StringBuilder sqlQuery = new StringBuilder();
            if (kieuluoi)
            {
                var dataResultReturn = new DataTable();
                sqlQuery.Append(" select tn.MaTiepNhan, tn.Seq, tn.NgayTiepNhan,th.MaSoMau, th.TenMauSieuAm, th.Ketluan,kql.IDMota, kql.TenMota, kql.NoiDung ");
                sqlQuery.Append("\n ,th.HinhIn1, th.HinhIn2, cast(null as image) as HinhKetQua1, cast(null as image) as HinhKetQua2");
                sqlQuery.Append("\n , nv.TenNhanVien + ' (' + convert(nvarchar(10), th.ThoigianIn, 103) + ') - ID: ' + tn.MaTiepNhan as BacSi");
                sqlQuery.Append("\n from ketqua_cls_sieuam th inner join benhnhan_tiepnhan tn on th.MaTiepNhan = tn.MaTiepNhan");
                sqlQuery.Append("\n inner join ketqua_cls_sieuam_luoi kql on kql.MaTiepNhan = th.MaTiepNhan and kql.MaSoMauSieuAm = th.MaSoMau ");
                sqlQuery.Append("\n left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on th.NguoiKy = nv.MaNhanVien");
                sqlQuery.AppendFormat("\n where tn.MaBN = '{0}' and len(tn.MaBN) > 0 and tn.MaBN is not null", pid);
                var dataSieuAm = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];

                if (dataSieuAm.Rows.Count > 0)
                {
                    var distinctDanhSach = dataSieuAm.DefaultView.ToTable(true, new string[] { "MaTiepNhan", "Seq","NgayTiepNhan" });
                    distinctDanhSach.DefaultView.Sort = "NgayTiepNhan,Seq ";
                    distinctDanhSach = distinctDanhSach.DefaultView.ToTable();

                    dataResultReturn = dataSieuAm.DefaultView.ToTable(true, new string[] { "MaSoMau", "TenMauSieuAm", "IDMota", "TenMota" });
                    dataResultReturn.DefaultView.Sort = "MaSoMau,IDMota";
                    dataResultReturn = dataResultReturn.DefaultView.ToTable();
                    var maTiepNhanCurrent = string.Empty;
                    var masoMauCurrent = string.Empty;
                    string addedColumnName = string.Empty;
                    foreach(DataRow dr in distinctDanhSach.Rows)
                    {
                        maTiepNhanCurrent = dr["MaTiepNhan"].ToString();
                        addedColumnName = string.Format("col{0}", maTiepNhanCurrent.Replace(".", ""));
                        dataResultReturn.Columns.Add(addedColumnName);
                        dataResultReturn.Columns[addedColumnName].Caption = string.Format("Ngày: {0} ({1})", DateTime.Parse(dr["NgayTiepNhan"].ToString()).ToString("dd/MM/yyyy"), dr["Seq"].ToString());
                        var dataDulieuTheotiepNhan = WorkingServices.SearchResult_OnDatatable_NoneSort(dataSieuAm, string.Format(" matiepnhan = '{0}'", maTiepNhanCurrent));
                        foreach (DataRow drresult in dataResultReturn.Rows)
                        {
                            var masoMau = drresult["MaSoMau"].ToString();
                            var idMota = drresult["IDMota"].ToString();

                            var dataKetQuaSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(dataDulieuTheotiepNhan, string.Format(" MaSoMau = {0} and IdMota = {1}", masoMau, idMota));
                            if (dataKetQuaSearch.Rows.Count > 0)
                            {
                                drresult[addedColumnName] = dataKetQuaSearch.Rows[0]["NoiDung"];
                            }
                        }
                    }
                }
                return dataResultReturn;
            }
            else
            {
                sqlQuery.AppendLine(" select th.TenMauSieuAm, th.Ketluan, th.NoiDung1, th.Hinh1, th.Hinh2, th.Hinh3, th.Hinh4, th.Hinh5, ");
                sqlQuery.AppendLine("th.HinhIn1, th.HinhIn2, cast(null as image) as HinhKetQua1, cast(null as image) as HinhKetQua2");
                sqlQuery.AppendLine(", nv.TenNhanVien + ' (' + convert(nvarchar(10), th.ThoigianIn, 103) + ') - ID: ' + tn.MaTiepNhan as BacSi");
                sqlQuery.AppendLine("from ketqua_cls_sieuam th");
                sqlQuery.AppendLine("inner");
                sqlQuery.AppendLine("join benhnhan_tiepnhan tn on th.MaTiepNhan = tn.MaTiepNhan");
                sqlQuery.AppendLine("left");
                sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on th.NguoiKy = nv.MaNhanVien");
                sqlQuery.AppendFormat("where tn.MaBN = '{0}' and len(tn.MaBN) > 0 and tn.MaBN is not null", pid);
                var dataSieuAm = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];

                if (dataSieuAm.Rows.Count > 0)
                {
                    string imagepath = string.Empty;
                    foreach (DataRow dr in dataSieuAm.Rows)
                    {
                        //Xử lý hình in 1
                        if (int.Parse(dr["HinhIn1"].ToString()) > 0)
                        {
                            imagepath = dr[string.Format("{0}{1}", "Hinh", dr["HinhIn1"].ToString())].ToString();
                            if (!string.IsNullOrEmpty(imagepath))
                            {
                                if (System.IO.File.Exists(imagepath))
                                {
                                    dr["HinhKetQua1"] = GraphicSupport.ImageToByteArray(Image.FromFile(imagepath));
                                }

                            }
                        }
                        //Xử lý hình in 2
                        if (int.Parse(dr["HinhIn2"].ToString()) > 0)
                        {
                            imagepath = dr[string.Format("{0}{1}", "Hinh", dr["HinhIn2"].ToString())].ToString();
                            if (!string.IsNullOrEmpty(imagepath))
                            {
                                if (System.IO.File.Exists(imagepath))
                                {
                                    dr["HinhKetQua2"] = GraphicSupport.ImageToByteArray(Image.FromFile(imagepath));
                                }
                            }
                        }
                        ////Xử lý kết luận
                        for (int i = 24; i < 72; i++)
                        {
                            dr["Ketluan"] = dr["Ketluan"].ToString().Replace(@"f0\fs" + i.ToString(), @"f0\fs24");
                            dr["NoiDung1"] = dr["NoiDung1"].ToString().Replace(@"f0\fs" + i.ToString(), @"f0\fs24");
                        }
                    }
                }

                dataSieuAm.AcceptChanges();
                return dataSieuAm;
            }
        }
        public DataTable LichSuNoiSoi(string pid)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(" select th.TenMauNoiSoi, th.Ketluan, th.NoiDung1, th.Hinh1, th.Hinh2, th.Hinh3, th.Hinh4, th.Hinh5, ");
            sqlQuery.AppendLine("th.HinhIn1, th.HinhIn2, cast(null as image) as HinhKetQua1, cast(null as image) as HinhKetQua2");
            sqlQuery.AppendLine(", nv.TenNhanVien + ' (' + convert(nvarchar(10), th.ThoigianIn, 103) + ') - ID: ' + tn.MaTiepNhan as BacSi");
            sqlQuery.AppendLine("from ketqua_cls_noisoi th");
            sqlQuery.AppendLine("inner");
            sqlQuery.AppendLine("join benhnhan_tiepnhan tn on th.MaTiepNhan = tn.MaTiepNhan");
            sqlQuery.AppendLine("left");
            sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on th.NguoiKy = nv.MaNhanVien");
            sqlQuery.AppendFormat("where tn.MaBN = '{0}' and len(tn.MaBN) > 0 and tn.MaBN is not null", pid);
            var dataNoiSoi = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];

            if (dataNoiSoi.Rows.Count > 0)
            {
                string imagepath = string.Empty;
                foreach (DataRow dr in dataNoiSoi.Rows)
                {
                    //Xử lý hình in 1
                    if (int.Parse(dr["HinhIn1"].ToString()) > 0)
                    {
                        imagepath = dr[string.Format("{0}{1}", "Hinh", dr["HinhIn1"].ToString())].ToString();
                        if (!string.IsNullOrEmpty(imagepath))
                        {
                            if (System.IO.File.Exists(imagepath))
                            {
                                dr["HinhKetQua1"] = GraphicSupport.ImageToByteArray(Image.FromFile(imagepath));
                            }
                        }
                    }
                    //Xử lý hình in 2
                    if (int.Parse(dr["HinhIn2"].ToString()) > 0)
                    {
                        imagepath = dr[string.Format("{0}{1}", "Hinh", dr["HinhIn2"].ToString())].ToString();
                        if (!string.IsNullOrEmpty(imagepath))
                        {
                            if (System.IO.File.Exists(imagepath))
                            {
                                dr["HinhKetQua2"] = GraphicSupport.ImageToByteArray(Image.FromFile(imagepath));
                            }
                        }
                    }
                    ////Xử lý kết luận
                    for (int i = 24; i < 72; i++)
                    {
                        dr["Ketluan"] = dr["Ketluan"].ToString().Replace(@"f0\fs" + i.ToString(), @"f0\fs24");
                        dr["NoiDung1"] = dr["NoiDung1"].ToString().Replace(@"f0\fs" + i.ToString(), @"f0\fs24");
                    }
                }
            }

            dataNoiSoi.AcceptChanges();
            return dataNoiSoi;
        }
        public DataTable LichSuXQuang(string pid)
        {

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(" select vc.TenVungChup, th.Ketluan, th.KetQua");
            sqlQuery.AppendLine(", ltrim(isnull(nv.TenNhanVien,'') + ' (' + convert(nvarchar(10), isnull(th.ThoigianIn, tn.NgayTiepNhan), 103) + ') - ID: ' + tn.MaTiepNhan) as BacSi");
            sqlQuery.AppendLine("from ketqua_cls_xquang th");
            sqlQuery.AppendLine("inner");
            sqlQuery.AppendLine("join benhnhan_tiepnhan tn on th.MaTiepNhan = tn.MaTiepNhan");
            sqlQuery.AppendLine("left");
            sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup vc on vc.MaVungChup = th.MaVungChup");
            sqlQuery.AppendLine("left");
            sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on th.NguoiKy = nv.MaNhanVien");
            sqlQuery.AppendFormat("where tn.MaBN = '{0}' and len(tn.MaBN) > 0 and tn.MaBN is not null", pid);
            var dataXQuang= DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString()).Tables[0];

            if (dataXQuang.Rows.Count > 0)
            {
                foreach (DataRow dr in dataXQuang.Rows)
                {
                    ////Xử lý kết quả
                    for (int i = 24; i < 72; i++)
                    {
                        dr["Ketluan"] = dr["Ketluan"].ToString().ToUpper();
                        dr["KetQua"] = dr["KetQua"].ToString().Replace(@"f0\fs" + i.ToString(), @"f0\fs24");
                    }
                }
            }
            dataXQuang.AcceptChanges();
            return dataXQuang;
        }
        public DataTable LichSuDienTim(string pid) { return new DataTable(); }
    }
}
