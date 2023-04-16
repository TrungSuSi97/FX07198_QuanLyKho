using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.App.AppCode
{
    class C_Report
    {
        public C_Report()
        {
        }
        public void Report_CLS_DanhsachXN_ThuongQui(DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID, string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID, bool _isTestProfile, string _NhomCLS, bool _ChiDinh, bool _KhongXNChinh, bool _dangCot, DataGridView dtg, BindingNavigator bv
            , ref string[] CategoryHeaderName, ref int[] CategoryHeaderColumnIndexStart, ref int[] CategoryHeaderColumnIndexEnd
            , string bophanXN = "", bool khongdanhgia = false, bool resultIsnull = false, string profileId = "", bool xuatCotTheoten = false
            , string khuDieuTri = "", string nguoinhap = "", string nguoixacnhan = "", bool baocaoketQua = false
            )
        {


            DataTable dtResult = new DataTable();
            var dtSource = Get_DataReport(_dtDateFrom, _dtDateTo, _Seq, _Name
            , _ServiceID, _FullRsult, _Printed, _TestID, _isTestProfile
            , _NhomCLS, _ChiDinh, _KhongXNChinh, bophanXN
            , khongdanhgia, resultIsnull, profileId, khuDieuTri, nguoinhap , nguoixacnhan);

            //Tạo table chứa dữ liệu
            //NgayTienNhan, SEQ,MaTiepNhan,TenBenhNhan,TenDoiTuong,GioTinh,Tuoi,ChanDoan,KetLuan, XetNghiem

            string[] _colName = new string[22] { "NgayTiepNhan", "SEQ", "MaTiepNhan", "MaBN", "TenBN", "DiaChi", "TenDoiTuongDichVu", "MaDoiTuongDichVu", "AgeNam", "AgeNu","Tuoi","NamSinh" ,"ChanDoan", "KetLuan", "XetNghiem", "MaNhomCLS", "SoBHYT", "TenBacSiKLXN", "TenNhanVien", "TenKhoaPhong","NhanVienXacNhan", "KetQua" };
            string[] _colCaption = new string[22] { "Ngày tiếp nhận", "Số TT", "Mã tiếp nhận", "Mã bệnh nhân", "Tên bệnh nhân", "Địa chỉ", "Đối tượng dịch vụ", "ĐT", "Nam", "Nữ","Tuổi","NamSinh" ,"Chẩn đoán", "Đánh giá", "Xét nghiệm","Nhóm XN", "Số BHYT", "Người đọc", "Người gửi", "Nơi gửi","Người đọc", "Kết quả" };
            string[] _colDataType = new string[22] { "datetime", "string", "string", "string", "string", "string", "string", "string", "string", "string", "string", "string", "string","namSinh", "string", "string", "string", "string", "string", "string", "string", "string" };
            LabServices_Helper.CreateDataTable(ref dtResult, _colName, _colCaption, _colDataType);

            //Vòng lập kiểm tra và gán dữ liệu

            LabServices_Helper.ConvertTest_Result(dtSource
                , ref dtResult, ref dtg, _colName, "MaTiepNhan", "TenXN", "KetQua"
                , "TenNhomCLS", "MaXN", "XetNghiem", "KetQua"
                , _ChiDinh, _dangCot, "ThuTuIn, SapXep,MaXN",ref CategoryHeaderName
                ,ref CategoryHeaderColumnIndexStart,ref CategoryHeaderColumnIndexEnd, xuatCotTheoten, baocaoketQua);
            ControlExtension.BindDataToGrid(dtResult, ref dtg, ref bv);

        }
        public void Report_CLS_DanhSachXN_TheoNhom(
            DataGridView dtg, BindingNavigator bv
            , DateTime _dtDateFrom, DateTime _dtDateTo, string _ServiceID
            , string _Name, string _Seq, bool _FullRsult, bool _Printed, string _TestID, bool _isTestProfile
            , string _NhomCLS, bool _ChiDinh, bool _KhongXNChinh, bool _dangCot, string bophanXN = "", bool khongdanhgia = false
            , bool resultIsNotnull = false, string profileId = ""
            , bool xuatCotTheoten = false, string khuDieuTri ="", string nguoinhap = "", string nguoixacnhan = "")
        {
            dtg.Columns.Clear();
            var dtSource = Get_DataReport(_dtDateFrom, _dtDateTo, _Seq, _Name
                                        , _ServiceID, _FullRsult, _Printed, _TestID, _isTestProfile
                                        , _NhomCLS, _ChiDinh, _KhongXNChinh, bophanXN
                                        , khongdanhgia, resultIsNotnull, profileId , khuDieuTri, nguoinhap, nguoixacnhan);

            DataTable dtResult = new DataTable();
            string[] _colName = new string[9] { "STT", "MaTiepNhan", "TenBN", "AgeNam", "AgeNu", "DiaChi", "SoBHYT", "ChanDoan", "TenKhoaPhong"};
            string[] _colCaption = new string[9] { "Số TT", "Mã tiếp nhận", "Họ tên người bệnh", "Nam", "Nữ", "Địa chỉ", "Có BHYT", "Chẩn đoán", "Nơi gửi" };
            string[] _colDataType = new string[9] { "int", "string", "string", "string", "string", "string", "string", "string", "string" };
            LabServices_Helper.CreateDataTable(ref dtResult, _colName, _colCaption, _colDataType);

            //Importdanh sách bệnh nhân vào kết quả
            var dtSourceDistinct = dtSource.DefaultView.ToTable(true, new string[] { "MaTiepNhan", "TenBN", "AgeNam", "AgeNu", "DiaChi", "SoBHYT", "ChanDoan", "TenKhoaPhong", "TenBacSiKLXN", "TenNhanVien" });


            var dataCategory = dtSource.DefaultView.ToTable(true, new string[] { "MaNhomCLS", "TenNhomCLS", "ThuTuIn" });
            dataCategory.Columns["ThuTuIn"].DataType = typeof(int);
            dataCategory.DefaultView.Sort = "ThuTuIn ASC";
            dataCategory = dataCategory.DefaultView.ToTable();
            if (dataCategory.Rows.Count > 0)
            {
                int rowCount = dataCategory.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    //Thêm cột nhóm vào trước
                    DataColumn col = new DataColumn();
                    col.ColumnName = dataCategory.Rows[i]["ManhomCLS"].ToString();
                    col.Caption = dataCategory.Rows[i]["TenNhomCLS"].ToString();
                    col.DataType = typeof(string);
                    dtResult.Columns.Add(col);
                }
            }

            _colName = new string[2] { "TenBacSiKLXN", "TenNhanVien" };
            _colCaption = new string[2] { "Người đọc", "Người gửi" };
            _colDataType = new string[2] { "string", "string" };
            LabServices_Helper.CreateDataTable(ref dtResult, _colName, _colCaption, _colDataType);       

            for (int a = 0; a < dtSourceDistinct.Rows.Count; a++)
            {
                DataRow drD = dtSourceDistinct.Rows[a];

                DataRow drR = dtResult.NewRow();
                drR["STT"] = a + 1;
                foreach (DataColumn dcR in dtResult.Columns)
                {
                    if (dtSourceDistinct.Columns.Contains(dcR.ColumnName))
                    {
                        drR[dcR.ColumnName] = drD[dcR.ColumnName];
                    }
                  
                }
                drR["TenBacSiKLXN"] = "CN. Phạm Thị Nhan";
                //Convert data theoNhom
                if (dataCategory.Rows.Count > 0)
                {
                    for (int b = 0; b < dataCategory.Rows.Count; b++)
                    {
                        string testResulInGroup = string.Empty;

                        DataRow drC = dataCategory.Rows[b];
                        var patientData = WorkingServices.SearchResult_OnDatatable_NoneSort(dtSource
                            , string.Format(" MatiepNhan = '{0}' and MaNhomCLS = '{1}'"
                            , drD["MatiepNhan"].ToString(), drC["MaNhomCLS"].ToString()));
                        if (patientData.Rows.Count > 0)
                        {
                            for (int c = 0; c < patientData.Rows.Count; c++)
                            {
                                var list = string.Empty;
                                if (xuatCotTheoten)
                                    list = string.Format("{0}: ({1})", patientData.Rows[c]["TenXN"].ToString().Trim(), dtSource.Rows[c]["KetQua"].ToString().Trim());
                                else
                                {
                                    var arrC = patientData.Rows[c]["MaXn"].ToString().Trim().Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                                    if (arrC.Length > 1)
                                    {
                                        var header = string.Empty;
                                        for (int i = 1; i < arrC.Length; i++)
                                            header += (string.IsNullOrEmpty(header) ? "" : "_") + arrC[i];

                                        list = string.Format("{0}: ({1})", header, dtSource.Rows[c]["KetQua"].ToString().Trim());  
                                    }
                                    else
                                        list = string.Format("{0}: ({1})", patientData.Rows[c]["MaXn"].ToString().Trim(), dtSource.Rows[c]["KetQua"].ToString().Trim());
                                }
                                testResulInGroup += (string.IsNullOrEmpty(testResulInGroup) ? "" : ";" ) + list;
                            }
                        }
                        drR[drC["MaNhomCLS"].ToString()] = testResulInGroup;
                    }
                }
                dtResult.Rows.Add(drR);
            }
            
            foreach (DataColumn dcR in dtResult.Columns)
            {
                var col = new DataGridViewTextBoxColumn();

                col.HeaderText = dcR.Caption;
                col.Name = dcR.ColumnName;
                col.DataPropertyName = dcR.ColumnName;
                dtg.Columns.Add(col);
            }
            dtg.Columns["MaTiepNhan"].Visible = false;
            ControlExtension.BindDataToGrid(dtResult, ref dtg, ref bv);
        }
        public DataTable Get_DataReport(DateTime _dtDateFrom, DateTime _dtDateTo, string _Seq, string _Name
            , string _ServiceID, bool _FullRsult, bool _Printed, string _TestID, bool _isTestProfile
            , string _NhomCLS, bool _ChiDinh, bool _KhongXNChinh, string bophanXN = ""
            , bool khongdanhgia = false, bool resultIsNotnull = false, string profileId = ""
            , string khuDieuTri="", string nguoinhap = "", string nguoixacnhan = "" )
        {
            string strSQL = "select cast (0 as bit) as Chon, n.ThuTuIn as ThuTuIn ";
            strSQL += "\n,dx.SapXep as SapXep, t.MaTiepNhan, t.Seq, t.TenBN";
            strSQL += "\n,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh";
            strSQL += "\n,t.Email as EmailBenhNhan, tx.DuKQXN,tx.DaInKQXN,t.ChanDoan,t.DiaChi \n";
            strSQL += "\n,year(t.NgayTiepNhan) - t.Tuoi as Tuoi, t.Tuoi as NamSinh, case when t.GioiTinh = 'm' then year(t.NgayTiepNhan) - t.Tuoi else null end as AgeNam";
            strSQL += "\n,l.TenKhoaPhong, l.MaKhoaPhong, nv.TenNhanVien, (select NguoiKyTen from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where MaDonVi = 'XN' )  as TenBacSiKLXN";
            strSQL += "\n, nvTH.TenNhanVien as NhanVienXacNhan, case when t.GioiTinh = 'F' then year(t.NgayTiepNhan) - t.Tuoi else null end as AgeNu ,tx.KetLuanXN as KetLuan";
            strSQL += "\n, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap, t.MaBN, t.SoBHYT, t.DoiTuongDichVu as MaDoiTuongDichVu";
            strSQL += "\n, k.TenXN, k.MaXN, K.KetQua, K.MaNhomCLS, isnull(n.TenNhomCLS, N'Nhóm khác') as  TenNhomCLS\n";
            strSQL += "from BenhNhan_TiepNhan t(nolock) ";
            strSQL += "\ninner join BenhNhan_CLS_XetNghiem tx(nolock) on t.MaTiepNhan = tx.MaTiepNhan  \n";
            strSQL += "inner join KetQua_CLS_XetNghiem k(nolock) on t.MaTiepNhan = k.MaTiepNhan \n";
            strSQL += "inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dx on k.maxn=dx.maxn\n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D(nolock) on t.DoiTuongDichVu = d.MaDoiTuongDichVu \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom  as n(nolock) on k.MaNhomCLS = n.MaNhomCLS \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG  as l(nolock) on t.MaDonVi = l.MaKhoaPhong \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN  as nv(nolock) on t.BacSiCD = nv.MaNhanVien \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN  as nvKl(nolock) on tx.BacSiKLXN = nvKl.MaNhanVien \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN  as nvTH(nolock) on k.NguoiXacNhan = nvTH.MaNhanVien \n";
            strSQL += "where t.ThoiGianNhap between '" + _dtDateFrom.ToString("yyyy-MM-dd HH:mm:ss.000") + "' and '" + _dtDateTo.ToString("yyyy-MM-dd HH:mm:ss.999") + "' and dx.KhongXuatKQ = 0";
            if (!string.IsNullOrEmpty(khuDieuTri))
            {
                strSQL += " and l.mabophan='" + khuDieuTri.Trim() + "'\n";
            }

            if (!string.IsNullOrEmpty(bophanXN))
            {
                strSQL += string.Format(" and K.MaNhomCLS in(select MaNhomCLS from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom where mabophan='{0}')\n", bophanXN);
            }

            if (_ServiceID != "")
            {
                strSQL += " and t.DoiTuongDichVu='" + _ServiceID.Trim() + "'";
            }
            if (_Seq != "")
            {
                strSQL += " and t.SEQ = '" + _Seq.Trim() + "' ";
            }
            if (_Name != "")
            {
                strSQL += " and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            if (_FullRsult)
            {
                strSQL += " and tx.DuKQXN = 1";
            }

            if (_Printed)
            {
                strSQL += " and tx.DaInKQXN = 1";
            }

            if (resultIsNotnull)
                strSQL += "\n and (case when k.XNChinh  = 1 then (select count (*) from ketqua_cls_xetnghiem kq2 where (kq2.ProfileID = isnull(k.ProfileID, '-NULL-') or kq2.IdChiDinhHis = isnull(k.IdChiDinhHis, '-NULL-')) and kq2.MaTiepNhan = k.MaTiepNhan and kq2.KetQua is not null) when k.KetQua is null or rtrim(k.KetQua) ='' then 0 else 1 end ) > 0 ";

            if (_TestID != "")
            {
                if (_isTestProfile)
                {
                    strSQL += " and k.MaXN in (select MaXN from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet p where p.ProfileID in (" + _TestID + ")) \n";
                }
                else
                {
                    strSQL += " and k.MaXN in (" + _TestID + ") \n";
                }
            }
            if(!string.IsNullOrEmpty(nguoinhap))
                strSQL +=string.Format( " and t.UserNhap ='{0}' \n", nguoinhap);
            if (!string.IsNullOrEmpty(nguoixacnhan))
                strSQL += string.Format(" and k.NguoiXacNhan ='{0}' \n", nguoixacnhan);
            if (_NhomCLS != "")
            {
                strSQL += " and k.MaNhomCLS  in (" + _NhomCLS + ")\n";
            }

            if (_KhongXNChinh)
            {
                strSQL += " and dx.XNChinh = 0 ";
            }

            if (!string.IsNullOrEmpty(profileId))
            {
                strSQL += " and k.MaXN in (select MaXN from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet p where p.ProfileID in ('" + profileId + "')) ";
            }

            strSQL += "\n Order by t.MaTiepNhan,n.ThuTuIn,dx.SapXep, k.MaXN";
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
    }
}
