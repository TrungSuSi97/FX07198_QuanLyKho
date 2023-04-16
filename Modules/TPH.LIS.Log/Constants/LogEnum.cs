namespace TPH.LIS.Log
{
    //public class LogEnum
    //{
    public enum LogActionId
        {
            Delete = 1,
            Update = 2,
            LoginIn = 3,
            AllAction = 4
        }

    public class LogTableIds
    {
        public const string Benhnhan_cls_noisoi = "Benhnhan_cls_noisoi";
        public const string Benhnhan_cls_sieuam = "Benhnhan_cls_sieuam";
        public const string Benhnhan_cls_xetnghiem = "Benhnhan_cls_xetnghiem";
        public const string Benhnhan_cls_xquang = "Benhnhan_cls_xquang";
        public const string Benhnhan_thongtinchitiet = "Benhnhan_thongtinchitiet";
        public const string Benhnhan_tiepnhan = "Benhnhan_tiepnhan";
        public const string Benhnnhan_cls_dvkhac = "Benhnnhan_cls_dvkhac";
        public const string Cauhinh_hethong = "Cauhinh_hethong";
        public const string Cauhinh_phanloaichucnang = "Cauhinh_phanloaichucnang";
        public const string CauHinh_ThietBi = "CauHinh_ThietBi";
        public const string Cauhinh_tieudetrangin = "Cauhinh_tieudetrangin";
        public const string Cls_benhnhan_dvkhac = "Cls_benhnhan_dvkhac";
        public const string Dm_maynoisoi = "{{TPH_Standard}}_Dictionary.dbo.Dm_maynoisoi";
        public const string Dm_bophan = "{{TPH_Standard}}_Dictionary.dbo.Dm_bophan";
        public const string Dm_dichvu_chitiet = "{{TPH_Standard}}_Dictionary.dbo.Dm_dichvu_chitiet";
        public const string Dm_dichvu_nhom = "{{TPH_Standard}}_Dictionary.dbo.Dm_dichvu_nhom";
        public const string Dm_dichvukhac = "{{TPH_Standard}}_Dictionary.dbo.Dm_dichvukhac";
        public const string Dm_doituongdichvu = "{{TPH_Standard}}_Dictionary.dbo.Dm_doituongdichvu";
        public const string Dm_doituongdichvu_gia = "{{TPH_Standard}}_Dictionary.dbo.Dm_doituongdichvu_gia";
        public const string Dm_dvkhac_maukq = "{{TPH_Standard}}_Dictionary.dbo.Dm_dvkhac_maukq";
        public const string Dm_hanhchinh_quanhuyen = "{{TPH_Standard}}_Dictionary.dbo.Dm_hanhchinh_quanhuyen";
        public const string Dm_hanhchinh_tinhthanhpho = "{{TPH_Standard}}_Dictionary.dbo.Dm_hanhchinh_tinhthanhpho";
        public const string Dm_khambenh_chandoan = "{{TPH_Standard}}_Dictionary.dbo.Dm_khambenh_chandoan";
        public const string Dm_khambenh_dichvu = "{{TPH_Standard}}_Dictionary.dbo.Dm_khambenh_dichvu";
        public const string Dm_khambenh_nhomdichvu = "{{TPH_Standard}}_Dictionary.dbo.Dm_khambenh_nhomdichvu";
        public const string Dm_khoaphong = "{{TPH_Standard}}_Dictionary.dbo.Dm_khoaphong";
        public const string DM_MauNoiSoi = "{{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi";
        public const string Dm_mausieuam = "{{TPH_Standard}}_Dictionary.dbo.Dm_mausieuam";
        public const string Dm_mayxquang = "{{TPH_Standard}}_Dictionary.dbo.Dm_mayxquang";
        public const string Dm_nhomcls_dvkhac = "{{TPH_Standard}}_Dictionary.dbo.Dm_nhomcls_dvkhac";
        public const string Dm_nhomcls_noisoi = "{{TPH_Standard}}_Dictionary.dbo.Dm_nhomcls_noisoi";
        public const string Dm_nhomcls_sieuam = "{{TPH_Standard}}_Dictionary.dbo.Dm_nhomcls_sieuam";
        public const string Dm_noisoi_ketquahp = "{{TPH_Standard}}_Dictionary.dbo.Dm_noisoi_ketquahp";
        public const string Dm_noisoi_kythuathp = "{{TPH_Standard}}_Dictionary.dbo.Dm_noisoi_kythuathp";
        public const string Dm_thuoc = "{{TPH_Standard}}_Dictionary.dbo.Dm_thuoc";
        public const string Dm_thuoc_cachdung = "{{TPH_Standard}}_Dictionary.dbo.Dm_thuoc_cachdung";
        public const string Dm_thuoc_gocthuoc = "{{TPH_Standard}}_Dictionary.dbo.Dm_thuoc_gocthuoc";
        public const string Dm_thuoc_nhomthuoc = "{{TPH_Standard}}_Dictionary.dbo.Dm_thuoc_nhomthuoc";
        public const string Dm_thuoc_profile = "{{TPH_Standard}}_Dictionary.dbo.Dm_thuoc_profile";
        public const string Dm_thuoc_profile_chitiet = "{{TPH_Standard}}_Dictionary.dbo.Dm_thuoc_profile_chitiet";
        #region Using
        public const string Dm_xetnghiem = "Dm_xetnghiem";
        public const string Dm_xetnghiem_biendichketqua = "Dm_xetnghiem_biendichketqua";
        public const string Dm_xetnghiem_csbt = "Dm_xetnghiem_csbt";
        public const string Dm_xetnghiem_loaimau = "Dm_xetnghiem_loaimau";
        public const string Dm_xetnghiem_nhom = "Dm_xetnghiem_nhom";
        public const string Dm_xetnghiem_bophan = "Dm_xetnghiem_bophan";
        public const string Dm_xetnghiem_tinhtoan = "Dm_xetnghiem_tinhtoan";
        public const string Dm_xetnghiem_ghichutudong = "Dm_xetnghiem_ghichutudong";
        public const string Dm_xetnghiem_phuongphap = "Dm_xetnghiem_phuongphap";
        public const string Dm_xetnghiem_profile = "Dm_xetnghiem_profile";
        public const string Dm_xetnghiem_profile_chitiet = "Dm_xetnghiem_profile_chitiet";
        public const string Dm_xetnghiem_bo = "Dm_xetnghiem_bo";
        public const string Dm_xetnghiem_bo_chitiet = "Dm_xetnghiem_bo_chitiet";
        public const string Dm_mappingHIS = "Dm_mappingHIS";
        public const string Dm_xetnghiem_his = "Dm_xetnghiem_his";
        public const string H_bangmamayxn = "H_bangmamayxn";
        public const string Dm_sinhly = "Dm_sinhly";
        public const string Dm_congty = "Dm_congty";
        public const string DM_TULUUMAU = "DM_TULUUMAU";
        public const string DM_KHAYLUUMAU = "DM_KHAYLUUMAU";
        public const string Ql_nguoidungID = "Ql_nguoidung";
        #endregion
        public const string Dm_xquang_kythuatchup = "{{TPH_Standard}}_Dictionary.dbo.Dm_xquang_kythuatchup";
        public const string Dm_xquang_vungchup = "{{TPH_Standard}}_Dictionary.dbo.Dm_xquang_vungchup";
        public const string H_hostconfig = "{{TPH_Standard}}_System.dbo.H_hostconfig";
        public const string H_ketquamay = "{{TPH_Standard}}_Analyzer.dbo.H_ketquamay";
        public const string H_ketquamay_changelog = "{{TPH_Standard}}_Analyzer.dbo.H_ketquamay_changelog";
        public const string H_mayxetnghiem = "{{TPH_Standard}}_Dictionary.dbo.H_mayxetnghiem";
        public const string H_ordercancel = "{{TPH_Standard}}_Analyzer.dbo.H_ordercancel";
        public const string H_ordertest = "{{TPH_Standard}}_Analyzer.dbo.H_ordertest";
        public const string H_thongtinketquamay = "{{TPH_Standard}}_Analyzer.dbo.H_thongtinketquamay";
        public const string Hethong_nhatky = "{{TPH_Standard}}_Log.dbo.Hethong_nhatky";
        public const string Ketqua_cls_dvkhac = "Ketqua_cls_dvkhac";
        public const string Ketqua_cls_noisoi = "Ketqua_cls_noisoi";
        public const string Ketqua_cls_sieuam = "Ketqua_cls_sieuam";
        public const string ketqua_cls_xetnghiem_spht = "ketqua_cls_xetnghiem_spht";
        public const string Ketqua_cls_xetnghiem = "Ketqua_cls_xetnghiem";
        public const string Ketqua_cls_xetnghiem_nhatky = "Ketqua_cls_xetnghiem_nhatky";
        public const string Ql_nguoidung = "{{TPH_Standard}}_System.dbo.Ql_nguoidung";
        public const string ketqua_cls_xetnghiem_visinh = "ketqua_cls_xetnghiem_visinh";
        public const string ketqua_cls_xetnghiem_vikhuan = "ketqua_cls_xetnghiem_vikhuan";
        public const string ketqua_xetnghiem_khangsinhdo = "ketqua_xetnghiem_khangsinhdo";

        public const string Ketqua_cls_xquang = "Ketqua_cls_xquang";
        public const string Khambenh_benhnhan = "Khambenh_benhnhan";
        public const string Khambenh_donthuoc = "Khambenh_donthuoc";
        public const string Khambenh_ketqua = "Khambenh_ketqua";
        public const string Ql_dm_phanquyen = "{{TPH_Standard}}_System.dbo.Ql_dm_phanquyen";
  
        public const string Ql_nhanvien = "{{TPH_Standard}}_Dictionary.dbo.Ql_nhanvien";
        public const string Ql_nhanvien_chietkhau = "{{TPH_Standard}}_Dictionary.dbo.Ql_nhanvien_chietkhau";
        public const string Ql_nhanvien_hocvi = "{{TPH_Standard}}_Dictionary.dbo.Ql_nhanvien_hocvi";
        public const string Registryusing = "{{TPH_Standard}}_System.dbo.Registryusing";
        public const string Thuphi_thuoc = "Thuphi_thuoc";
        public const string Vt_dm_loaivt = "{{TPH_Standard}}_Dictionary.dbo.Vt_dm_loaivt";
        public const string Vt_dm_nhacungcap = "{{TPH_Standard}}_Dictionary.dbo.Vt_dm_nhacungcap";
        public const string Vt_dm_nhomvt = "{{TPH_Standard}}_Dictionary.dbo.Vt_dm_nhomvt";
        public const string Vt_dm_vattu = "{{TPH_Standard}}_Dictionary.dbo.Vt_dm_vattu";
        public const string Vt_donvitinh = "{{TPH_Standard}}_Dictionary.dbo.Vt_donvitinh";
        public const string Vt_nhacungcap_vattu = "{{TPH_Standard}}_Dictionary.dbo.Vt_nhacungcap_vattu";
        public const string Vt_nhapkho_chiettiet_thuoc = "Vt_nhapkho_chiettiet_thuoc";
        public const string Vt_nhapkho_phieunhap_thuoc = "Vt_nhapkho_phieunhap_thuoc";
        public const string Vt_xuatkho_chitiet_thuoc = "Vt_xuatkho_chitiet_thuoc";
        public const string Vt_xuatkho_phieuxuat_thuoc = "Vt_xuatkho_phieuxuat_thuoc";

        public const string p_payment = "p_payment";

    }

    public class LogFile
    {
        public const string ActionLog = "Action_";
    }
    // }
}
