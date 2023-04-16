using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TPH.HIS.Model;
using TPH.LIS.Data;
namespace TPH.HIS.Repositories
{
    public class OrderedRepositories : IOrderedRepositories
    {
        public List<SeviceOrderedInformation> orderedServices(string condit)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select cast (0 as bit) as isChecked, A.*, D.TenPhanLoai, D.ThuTuIn as ThuTuPhanLoai, T.[MaBN] as MaBenhNhan , T.[SoBHYT], T.[NgayHetHanBHYT], T.[TenBN] as TenBenhNhan");
            sqlQuery.AppendLine(", T.[SinhNhat], T.[Tuoi] as NamSinh, T.[CoNgaySinh], T.[GioiTinh], T.[NgayTiepNhan], T.[ThoiGianNhap], T.[UserNhap]");
            sqlQuery.AppendLine(", dt.MaDoiTuongDichVu, dt.TenDoiTuongDichVu, T.[DiaChi], T.[SoNha], T.[PhuongXa], T.[MaHuyen], T.[MaTinh]");
            sqlQuery.AppendLine(" from(");
            sqlQuery.AppendLine("select STT, RSoPhieuYeuCau, Sapxep, cast(0 as bit) as chon, MatiepNhan, x.MaXN as MaChiDinh");
            sqlQuery.AppendLine(", x.TenXN as TenChiDinh, x.ThuTuIn, x.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
            sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, ProfileID as MaProfile, XNChinh as ChiDinhCha, DaThuTien");
            sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, LoaiMau, TienCong");
            sqlQuery.AppendLine("from KetQua_CLS_XetNghiem x inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on x.MaNhomCLS = n.MaNhomCLS");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaSoMau as varchar(20)) as MaChiDinh");
            sqlQuery.AppendLine(", TenMauSieuAm as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomSieuAm as MaNhomChiDinh, n.TenNhomSieuAm as TenNhomChiDinh");
            sqlQuery.AppendLine(" , MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe");
            sqlQuery.AppendLine(" , XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong");
            sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong");
            sqlQuery.AppendLine("from KetQua_CLS_SieuAm x left join{{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm n on x.MaNhomSieuAm = n.MaNhomSieuAm");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(" Union all");
            sqlQuery.AppendLine("select distinct 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon");
            sqlQuery.AppendLine(", MatiepNhan, cast(k.MaVungChup as varchar(20)) as MaChiDinh, VC.TenVungChup as TenChiDinh, cast(100 as int) as ThuTuIn");
            sqlQuery.AppendLine(", k.MaKyThuatChup as MaNhomChiDinh, n.TenKyThuatChup as TenNhomChiDinh, MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa");
            sqlQuery.AppendLine(", null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau");
            sqlQuery.AppendLine(", 0 as TienCong");
            sqlQuery.AppendLine("from KetQua_CLS_XQuang k left");
            sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup n on n.MaKyThuatChup = vc.MaKyThuatChup");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaSoMauNoiSoi as varchar(20)) as MaChiDinh");
            sqlQuery.AppendLine(", TenMauNoiSoi as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomNoiSoi as MaNhomChiDinh, n.TenNhomNoiSoi as TenNhomChiDinh, MaPhanLoai");
            sqlQuery.AppendLine(", GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien");
            sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong");
            sqlQuery.AppendLine("from KetQua_CLS_NoiSoi x left join{{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi n on x.MaNhomNoiSoi = n.MaNhomNoiSoi");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan");
            sqlQuery.AppendLine(", cast(MaYeuCau as varchar(20)) as MaChiDinh, TenYeuCau as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomDichVu as MaNhomChiDinh");
            sqlQuery.AppendLine(", n.TenNhomDichVu as TenNhomChiDinh, MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile");
            sqlQuery.AppendLine(", cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong");
            sqlQuery.AppendLine("from KhamBenh_KetQua x left join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu n on x.MaNhomDichVu = n.MaNhomDichVu");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(" Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaDVKhac as varchar(20)) as MaChiDinh");
            sqlQuery.AppendLine(", TenDVKhac as TenChiDinh, cast(101 as int) as ThuTuIn, n.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
            sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong");
            sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong");
            sqlQuery.AppendLine("from KetQua_CLS_DVKhac x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac n  on x.MaNhomCLS = n.MaNhomCLS");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan");
            sqlQuery.AppendLine(", cast(MaThuoc as varchar(20)) as MaChiDinh, TenThuoc as TenChiDinh, cast(102 as int) as ThuTuIn");
            sqlQuery.AppendLine(" , n.MaNhomThuoc as MaNhomChiDinh, n.TenNhomThuoc as TenNhomChiDinh, MaPhanLoai, DonGia as GiaRieng, cast(0 as bit) as TieuDe, DaXuatKho as DaKkoa");
            sqlQuery.AppendLine(", null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, Soluong as SoLuong, Soluong * DonGia as ThanhTien, 'A' as LoaiMau");
            sqlQuery.AppendLine(", 0 as TienCong");
            sqlQuery.AppendLine("from ThuPhi_Thuoc x left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on x.MaGocThuoc = g.MaGocThuoc");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc n on g.MaGocThuoc = n.MaNhomThuoc");
            sqlQuery.AppendFormat("where {0}", condit.ToUpper().Replace("GIARIENG", "DonGia"));
            sqlQuery.AppendFormat(" Union all ");
            sqlQuery.AppendLine("");
            sqlQuery.AppendFormat(" select 0 as STT, null as RSoPhieuYeuCau,0, cast(0 as bit) as chon, MatiepNhan");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(",MaYeuCau as  MaChiDinh, TenYeuCau as TenChiDinh,cast(100 as int) as ThuTuIn");
            sqlQuery.AppendLine(",x.MaNhomYeuCau as MaNhomChiDinh,n.TenNhomYeuCau as TenNhomChiDinh, MaPhanLoai,GiaRieng, cast (0 as bit) as TieuDe");
            sqlQuery.AppendLine(",cast ( case when isnull(isnull(KetQuaSoi,KetQuaCay),KetQuaNhuom) is not null then 1 else 0 end as bit) as DaKkoa");
            sqlQuery.AppendFormat(",null as ProfileID,cast(0 as bit) as ChiDinhCha, DaThuTien,cast(1 as int) as SoLuong");
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong ");
            sqlQuery.AppendLine("from ketqua_cls_xetnghiem_visinh x");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhomyeucauvisinh n on x.MaNhomYeuCau = n.MaNhomYeuCau");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(") as A left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = A.MaPhanLoai");
            sqlQuery.AppendLine("Inner join BenhNhan_TiepNhan T on T.MaTiepNhan = A.MaTiepNhan");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu dt on T.DoiTuongDichVu = dt.MaDoiTuongDichVu");
            sqlQuery.AppendLine("order by D.ThuTuIn, D.MaPhanLoai, A.ThuTuIn, A.Sapxep, MaNhomChiDinh, MaChiDinh, TenChiDinh");

            var returnlist = new List<SeviceOrderedInformation>();

            var ds = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString());
            returnlist = ds.Tables[0].AsEnumerable().Select(dataRow => new SeviceOrderedInformation
            {
                isChecked = bool.Parse(dataRow["isChecked"].ToString()),
                chon = bool.Parse(dataRow["chon"].ToString()),
                stt = int.Parse(string.IsNullOrEmpty(dataRow["stt"].ToString())?"0": dataRow["stt"].ToString()),
                SapXep = int.Parse(dataRow["SapXep"].ToString()),
                ThuTuIn = int.Parse(dataRow["ThuTuIn"].ToString()),
                MaTiepNhan = dataRow["MaTiepNhan"].ToString(),
                MaBenhNhan = dataRow["MaBenhNhan"].ToString(),
                SoBHYT = dataRow["SoBHYT"].ToString(),
                NgayHetHanBHYT = (string.IsNullOrEmpty(dataRow["NgayHetHanBHYT"].ToString()) ? (DateTime?)null: DateTime.Parse(dataRow["NgayHetHanBHYT"].ToString())),
                TenBenhNhan = dataRow["TenBenhNhan"].ToString(),
                NamSinh = int.Parse(dataRow["NamSinh"].ToString()),
                SinhNhat = (string.IsNullOrEmpty(dataRow["SinhNhat"].ToString())? (DateTime?)null : DateTime.Parse(dataRow["SinhNhat"].ToString())),
                CoNgaySinh = bool.Parse(dataRow["CoNgaySinh"].ToString()),
                GioiTinh = dataRow["GioiTinh"].ToString(),
                NgayTiepNhan = DateTime.Parse(dataRow["NgayTiepNhan"].ToString()),
                ThoiGianNhap = DateTime.Parse(dataRow["ThoiGianNhap"].ToString()),
                UserNhap = dataRow["UserNhap"].ToString(),
                MaDoiTuongDichVu = dataRow["MaDoiTuongDichVu"].ToString(),
                TenDoiTuongDichVu = dataRow["TenDoiTuongDichVu"].ToString(),
                SoNha = dataRow["SoNha"].ToString(),
                PhuongXa = dataRow["PhuongXa"].ToString(),
                MaHuyen = dataRow["MaHuyen"].ToString(),
                MaTinh = dataRow["MaTinh"].ToString(),
                DiaChi = dataRow["DiaChi"].ToString(),
                RSoPhieuYeuCau = dataRow["RSoPhieuYeuCau"].ToString(),
                MaChiDinh = dataRow["MaChiDinh"].ToString(),
                TenChiDinh = dataRow["TenChiDinh"].ToString(),
                MaNhomChiDinh = dataRow["MaNhomChiDinh"].ToString(),
                TenNhomChiDinh = dataRow["TenNhomChiDinh"].ToString(),
                MaPhanLoai = dataRow["MaPhanLoai"].ToString(),
                TenPhanLoai = dataRow["TenPhanLoai"].ToString(),
                ThuTuPhanLoai = int.Parse(dataRow["ThuTuPhanLoai"].ToString()),
                GiaRieng = double.Parse(dataRow["GiaRieng"].ToString()),
                DaKkoa = bool.Parse(dataRow["DaKkoa"].ToString()),
                MaProfile = dataRow["MaProfile"].ToString(),
                ChiDinhCha = bool.Parse(dataRow["ChiDinhCha"].ToString()),
                LoaiMau = dataRow["LoaiMau"].ToString(),
                TienCong = double.Parse(dataRow["TienCong"].ToString()),
                DaThuTien = bool.Parse(dataRow["DaThuTien"].ToString()),
                SoLuong = int.Parse(dataRow["SoLuong"].ToString()),
            }).ToList();

            return returnlist;
        }


    }
}
