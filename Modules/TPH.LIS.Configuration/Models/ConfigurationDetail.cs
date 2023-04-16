using System;

namespace TPH.LIS.Configuration.Models
{
    using Data;
    using System.Data;
    using SystemConfig = System.Configuration.ConfigurationManager;
    using TPH.Common.Converter;
    using Constants;

    public class ConfigurationDetail
    {
        #region Gerneral
        public string LuuCauHinhTheoKhuVuc = CommonConfigConstant.AllComputer;
        public string CustomerID { get; set; }
        public bool IsAutoId { get; set; }
        public int BarcodeLapLai { get; set; }
        public bool ThietBiBatHinhNapLucKhoiDong { get; set; }
        public string BenhNhanKyTuMa { get; set; }
        public string BenhNhanSoKyTuBarCode { get; set; }
        public string BenhNhanCheDoSoThuTu { get; set; }
        public bool BenhNhanTuLuuThongTinNhapMoi { get; set; }
        public string TiepNhanHisSoLuongBarcodeToiThieu { get; set; }

        public bool ConnectHIS { get; set; }
        public bool ConnectHISWithConvertFont { get; set; }
        public bool SuDungBarcodeHIS { get; set; }
        public string PreffixMaTiepNhanHIS { get; set; }
        public string SuffixMaTiepNhanHIS { get; set; }
        //email config
        public string EmailUserId { get; set; }
        public string EmailPassword { get; set; }
        public string EmailMailFrom { get; set; }
        public string EmailMailBody { get; set; }
        public string EmailSmptServer { get; set; }
        public string EmailPdfPath { get; set; }
        public bool EmailUseSsl { get; set; }
        public string EmailPortNumber { get; set; }
        public string GioLamViecSang { get; set; }
        public string GioLamViecChieu { get; set; }
        public string GioNghiChieu { get; set; }
        public string GioLayMauHenQuaNgay { get; set; }
        public string GioNghiTrua { get; set; }
        public int NghiCuoiTuan { get; set; }
        public int KieuNhapChiDinhDichVu { get; set; }
        public int LayNguoiThucHien { get; set; }
        public string DatabaseThongKe { get; set; }
        public string DatabaseBloodBank { get; set; }
        public string DatabaseArchive { get; set; }
        public bool YeuCauChonKyTen { get; set; }
        public bool ChonInKhiDuyet { get; set; }
        public bool ChoPhepChonKyTenKhac { get; set; }
        public bool TestHISMode { get; set; }
        public bool TPHLabIMSWeb_TuDongGuiChiDinh { get; set; }
        #endregion
        #region Xét nghiệm
        public int ClsXetNghiemSoPhutLoadDSNhanMau { get; set; }
        public bool ClsXetNghiemChoChuKyGiongUserDangNhap { get; set; }
        public bool ClsXetNghiemThoiGianInKetQuaLanDau { get; set; }
        public int ClsXetNghiemPhieuInLeTenNhom { get; set; }
        public bool ClsXetNghiemPhieuInTenNhomInDam { get; set; }
        public bool ClsXetNghiemPhieuInTenNhomGachChan { get; set; }
        public bool ClsXetNghiemPhieuInTenNhomInNghieng { get; set; }
        public bool ClsXetNghiemInTuXacNhan { get; set; }
        public string ClsXetNghiemDinhDangKetqua { get; set; }
        public Common.EnumReportResultTemplatetype ClsXetNghiem_LoaiPhieuKetQua { get; set; }
        public Constants.EnumQuiTrinhLAB ClsXetNghiemXemQuiTrinh { get; set; }
        public bool ClsXetNghiemPhieuInTachTheoBoPhan { get; set; }
        public bool ClsXetNghiemPhieuInTachTheoNhom { get; set; }
        public bool ClsXetNghiemPhieuInBatThuongInDam { get; set; }
        public bool ClsXetNghiemPhieuInBatThuongGachChan { get; set; }
        public bool ClsXetNghiemPhieuInBatThuongInNghieng { get; set; }
        public bool ClsXetNghiemPhieuInChuKyCuoiTrang { get; set; }
        public bool ClsXetNghiemPhieuInTuTachPhieu { get; set; }
        public bool ClsXetNghiemXuatCotTheoTen { get; set; }
        public int ClsXetNghiemSoDongTrenPhieu { get; set; }
        public int ClsXetNghiemSoDongChuKy { get; set; }
        public int ClsXetNghiemSoKyTuTenXN { get; set; }
        public int ClsXetNghiemSoKyTuKQXN { get; set; }
        public int ClsXetNghiemSoKyTuDiaChi { get; set; }
        public int ClsXetNghiemSoKyTuChanDoan { get; set; }
        public bool ClsXetNghiemGhepTenBSKhoaPhong { get; set; }
        public int ClsXetNghiemTinhSoTemTheoNhom { get; set; }
        public bool ClsXetNghiemBacodeCoLoaiMau { get; set; }
        public string ClsXetNghiemDinhDangBarcode { get; set; }
        public string ClsXetNghiemLoaiMauKhongGhep { get; set; }
        public bool ClsXetNghiemXemKetQuaTheoNhom { get; set; }
        public bool ClsXetNghiemXacNhanDe { get; set; }
        public string ClsXetNghiemCanhLeBinhThuong { get; set; }
        public string ClsXetNghiemCanhLeBatThuongTren { get; set; }
        public string ClsXetNghiemCanhLeBatThuongDuoi { get; set; }
        public bool ClsXetNghiemFormKQMayTuDong { get; set; }
        public bool ClsXetNghiemChonKhuLayMau { get; set; }
        public bool ClsXetNghiemChoPhepSuaMayXN { get; set; }
        public Common.EnumLoaiKetNoiMay ClsXetNghiemLoaiKetNoiMay { get; set; }
        public Common.EnumKieuLayKetQuaMay ClsXetNghiemKieuLayKetQuaMay { get; set; }
        public bool ClsXetNghiemSuDungDanhSachChoTraKQ { get; set; }
        public string ClsXetNghiemModuleKichHoat { get; set; }
        public int ClsXetNghiemSoPhutLayMauNgoaiTru { get; set; }
        public string ClsXetNghiemKichCoHinhSHPT { get; set; }
        public bool ClsXetNghiemChiInKetQuaDaDuyet { get; set; }
        public bool ClsXetNghiemHienThiTrangThaiNhom { get; set; }
        public bool ClsXetNghiemHienThiTrangThaiBoPhan { get; set; }
        public bool ClsXetNghiemHienThiTrangThaiNhomTheoBoPhan { get; set; }
        public bool ClsXetNghiemHienThiDSBoLocHienThi { get; set; }
        public int ClsXetNghiemDoCaoLuoiThongTin { get; set; }
        public bool ClsXetNghiemReDownloadKhiXoaHangLoat { get; set; }
        public int ClsXetNghiemCanhLeKetQuaTrenLuoi { get; set; }
        public bool ClsXetNghiemUploadDaDuyet { get; set; }
        public bool ClsXetNghiemUploadDaIn { get; set; }
        public bool ClsXetNghiemUploadJSonArray { get; set; }
        public bool ClsXetNghiemPKQGhiChuDuoiXN { get; set; }
        public bool ClsXetNghiemPKQGhiChuGhepTenXN { get; set; }
        public bool ClsXetNghiemPKQGhiChuGhepKetLuan { get; set; }
        public string ClsXetNghiemDinhDangGhepDuyetKQ { get; set; }
        public string ClsXetNghiemDinhDangGhepNhapKQ { get; set; }
        public bool ClsXetNghiemCanhBaoNullCSBT { get; set; }
        public bool ClsXetNghiemKiemSoatChuyenMau { get; set; }
        public bool ClsXetNghiemDanhDauKyTuTem { get; set; }
        public bool ClsXetNghiemCanhBaoNhanTre { get; set; }
        public int ClsXetNghiemCanDuoiNhanTre { get; set; }
        public int ClsXetNghiemCanTrenNhanTre { get; set; }
        public string ClsXetNghiemDuongDanCanhBao { get; set; }
        public string ClsXetNghiemMauTrongKhoangTre { get; set; }
        public string ClsXetNghiemMauNgoaiKhoangTre { get; set; }

        public int ClsXetNghiemTuFocusBarcode { get; set; }
        public bool ClsXetNghiemHienTuyChon { get; set; }
        public bool ClsXetNghiemXuatPDFKhiIn { get; set; }
        public bool ClsXetNghiemSuDungChuKyLanhDao { get; set; }
        public int ClsXetNghiemCanhBaoTinhToanDuyetKQ { get; set; }

        public string ClsXetNghiemMayDungToolUpload { get; set; }
        public string ClsXetNghiemMayDungToolKetQua { get; set; }
        #endregion

        public string ClsSieuAmDuongDanLuuHinhAnh { get; set; }
        public string ClsSieuAmDuongDanLuuVideo { get; set; }
        public string ClsSieuAmKichCoXemHinh { get; set; }
        public string ClsNoiSoiDuongDanLuuHinhAnh { get; set; }
        public string ClsNoiSoiDuongDanLuuVideo { get; set; }
        public string ClsNoiSoiKichCoXemHinh { get; set; }
        public string ClsDienTimDuongDanKetQuaMay { get; set; }
        public string ClsDienTimDuongDanKetQua { get; set; }
        public string ClsDienTimKichCoKetQua { get; set; }
        public bool ClsXetNghiemSuDungSoHoSo { get; set; }
        public int ClsXetNghiemKieuCanhBaoKQ { get; set; }
        public string ClsXetNghiemMauCanhBaoKetQua { get; set; }
        public bool ClsXetNghiemChongioKyTQ { get; set; }
        public bool ClsXetNghiemChongioKySHPT { get; set; }
        public bool ClsXetnghiemLuuMauInTheoViTri { get; set; }
        public bool ClsXetNghiemChoDuyetQCFail { get; set; }
        public bool ClsXetNghiemKhongInQCFail { get; set; }
        public string ClsXetNghiemMauChuaKQ { get; set; }
        public string ClsXetNghiemMauDaCoKQ { get; set; }
        public string ClsXetNghiemMauDuKQ { get; set; }
        public string ClsXetNghiemMauDaDuyetKQ { get; set; }
        public string ClsXetNghiemMauDaInKQ { get; set; }
        public int ClsXetNghiemCachTinhTAT{ get; set; }
        public bool ClsXetNghiemTATDashboardTheoBoPhan { get; set; }
        public bool ClsXetNghiemTATDashboardBieuDo { get; set; }

        public string ClsXetNghiemMau_MauDuThaoTac { get; set; }
        public string ClsXetNghiemMau_MauThaoTacChuaDu { get; set; }
        public string ClsXetNghiemMau_MauChuaThaoTac { get; set; }
        public string ClsXetNghiemMau_MauYeuCauLayLai { get; set; }
        public bool ClsXetNghiemPhanBietMauTheobarcode { get; set; }
        public bool ClsXetNghiemInCoTienSu { get; set; }
        public string DefaultCustomerCodePrefix
        {
            get
            {
                return SystemConfig.AppSettings["DefaultCustomerCodePrefix"];
            }
        }
        public int DefaultMinLengthOfBarcode
        {
            get
            {
                return NumberConverter.ToInt(SystemConfig.AppSettings["DefaultMinLengthOfBarcode"]);
            }
        }
        public string SignalR_HostName { get; set; }
        public int SignalR_Port { get; set; }
        public string SignalR_Username { get; set; }
        #region Chu ky dien tu
        public bool ChuKyDienTuSuDung { get; set; }
        public string ChuKyDienTuLinkAPI { get; set; }
        public string ChuKyDienTuTaiKhoan { get; set; }
        public string ChuKyDienTuMatKhau { get; set; }
        public string ChuKyDienTuSerial { get; set; }
        public string ChuKyDienTuSHA { get; set; }
        public string ChuKyDienTuNoiLuuPDF { get; set; }
        public bool ChuKyDienTuXacNhanUser { get; set; }
        public int ChuKyDienTuUserTimeOut { get; set; }
        public string ChuKyDienTuDinhDang { get; set; }
        public string ChuKyDienTuDinhDangNgayGio { get; set; }
        public string ChuKyDienTuLyDo { get; set; }
        public string ChuKyDienTuNoiKy { get; set; }
        public int ChuKyDienTuViTri { get; set; }
        public int ChuKyDienTuTrangKy { get; set; }
        public int ChuKyDienTuDoRongRec { get; set; }
        public int ChuKyDienTuDoCaoRec { get; set; }
        public int ChuKyDienTuLeTrai { get; set; }
        public int ChuKyDienTuLePhai { get; set; }
        public int ChuKyDienTuLeTren { get; set; }
        public int ChuKyDienTuLeDuoi { get; set; }
        public int ChuKyDienTuCoChu { get; set; }
        public bool ClsXetNghiemKiemTraMayXNKhiIn { get; set; }
        public bool ClsXetNghiemHenTheoXetNghiem { get; set; }
        #endregion

        public string Get_MaBenhNhan(DateTime dateIn, double maxPidSeq)
        {
            string numberIncreament = string.Format("{0:yy}000000", dateIn);
            if (maxPidSeq > double.Parse(numberIncreament))
            {
                numberIncreament = string.Format("{0}", maxPidSeq + 1);
            }
            else
            {
                numberIncreament = string.Format("{0}", (double.Parse(numberIncreament) + 1));
            }
            return string.Format("{0}.{1}",
                (string.IsNullOrEmpty(BenhNhanKyTuMa) ? "BN" : BenhNhanKyTuMa),
                numberIncreament);
        }
        public static bool CheckFunction(string[] arrayAllow, string checkFunction)
        {
            if (arrayAllow != null)
            {
                for (int c = 0; c < arrayAllow.Length; c++)
                {
                    if (arrayAllow[c].Trim().Equals(checkFunction.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static string Get_MaTiepNhan(string stt, DateTime dtp)
        {
            if (stt.Contains(string.Format("{0}.", dtp.ToString("yyMMdd"))) || stt.Split('.').Length == 2)
            {
                return stt;
            }
            else
            {
                return string.Format("{0}.{1}", dtp.ToString("yyMMdd"),
                    stt.Trim());
            }
        }
        public static string GetNextReceptionTimesID()
        {
            //check Barcode from config table
            var objData = DataProvider.ExecuteScalar(CommandType.StoredProcedure, "selIDTiepNhanAuto");
            //Chưa có data hoặc lấy bị lỗi
            if (objData == null)
            {
                return string.Empty;
            }

            var id = objData.ToString();
            return (string.IsNullOrEmpty(id) ? "1" : id);
        }

        public string GenerateSeq(DateTime dateIn)
        {
            return GenerateSeqWithNotMaxLimit();
        }

        public string GenerateSeqWithNotMaxLimit(int numberOfCode = 0)
        {
            //check Barcode from config table
            var objData = DataProvider.ExecuteScalar(CommandType.StoredProcedure, "selBarcodeAuto");
            //Chưa có data hoặc lấy bị lỗi
            if (objData == null)
            {
                return string.Empty;
            }
            int currentId = 0;
            currentId = NumberConverter.ToInt(objData);
            var minId = "1";
            var maxId = "9";
            var lengthOfBarcode = !string.IsNullOrEmpty(BenhNhanSoKyTuBarCode)
                ? NumberConverter.ToInt(BenhNhanSoKyTuBarCode)
                : DefaultMinLengthOfBarcode;

            for (var i = 0; i < lengthOfBarcode - 1; i++)
            {
                minId += "0";
                maxId += "9";
            }

            var minBarcode = NumberConverter.ToInt(minId);
            var maxBarcode = NumberConverter.ToInt(maxId);
            if (BarcodeLapLai == 0)
                maxBarcode = currentId + 2 + numberOfCode; //công 2 để barcode sau khi cộng 1 vaò luôn < hơn max
            currentId = ((currentId + numberOfCode + 1) < minBarcode || (currentId + numberOfCode + 1) >= maxBarcode ? minBarcode : currentId) + 1 + numberOfCode;

            if (currentId > 0)
            {
                DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpBarcodeAuto", new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@BarcodeValue", currentId) });
            }

            return string.Format("{0}", currentId - numberOfCode);// - numberOfCode để trả về giá trị bắt đăù của dãy code
        }
    }
}
