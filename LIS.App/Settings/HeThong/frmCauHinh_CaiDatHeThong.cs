using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Enum;
using DevExpress.XtraGrid.Columns;
using TPH.LIS.App.Settings.HeThong;
using System.Collections.Generic;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Log;
using System.Drawing;
using TPH.Controls;
using TPH.Common.Converter;

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class frmCauHinh_CaiDatHeThong : FrmTemplate
    {
        public frmCauHinh_CaiDatHeThong()
        {
            InitializeComponent();
            tabConfig.Appearance = TabAppearance.FlatButtons;
            tabConfig.ItemSize = new Size(0, 1);
            tabConfig.SizeMode = TabSizeMode.Fixed;
        }

        private ISystemConfigService _sysConfig = new SystemConfigService();
        private ConfigurationDetail _objConfigurationDetail = new ConfigurationDetail();

        private void Get_Lis_InsertOrderMode()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = KieuNhapChiDinh.ListKieuNhapChiDinh();
            ControlExtension.BindDataToCobobox(bs, ref cboKieuNhapChiDinh, "Id", "NoiDung");
        }
        private void Get_List_BarcodeType()
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID", typeof (string));
            DataRow dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.AutoBarcode;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ManualBarcode;
            data.Rows.Add(dr);

            ControlExtension.BindDataToCobobox(data, ref cboBarcodeMode, "ID", "ID", "ID", "100");
        }
        private void Get_List_ImageSize()
        {
            DataTable data = new DataTable();
            data.Columns.Add("ID", typeof (string));
            DataRow dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize320X240;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize640X480;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize800X600;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize1024X768;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize1280X768;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize1280X1024;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize1366X768;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize1600X900;
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["ID"] = SystemStypeConstant.ImageSize1600X1200;
            data.Rows.Add(dr);

            ControlExtension.BindDataToCobobox(data, ref cboDienTim_ImageCropSize, "ID", "ID", "ID", "150");
            ControlExtension.BindDataToCobobox(data.Copy(), ref cboNoiSoi_ImageSize, "ID", "ID", "ID", "150");
            ControlExtension.BindDataToCobobox(data.Copy(), ref cboSieuAm_ImageSize, "ID", "ID", "ID", "150");
        }
        private void Get_LAB_QuiTrinh()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = QuiTrinhLAB.ListQuiTrinhLAB();
            ControlExtension.BindDataToCobobox(bs, ref cboQuiTrinh, "Id", "NoiDung");
        }
        private void Get_LAB_UserThucHien()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = NguoiThucHien.ListNguoiThucHien();
            ControlExtension.BindDataToCobobox(bs, ref cboNguoiThucHien, "Id", "NoiDung");
        }
        private void Get_SystemConfig()
        {
            _objConfigurationDetail = _sysConfig.GetSystemConfigurationDetail();

            #region Gerneral
            txtRabbit_HostName.Text = _objConfigurationDetail.SignalR_HostName;
            numRabbit_Port.Value = _objConfigurationDetail.SignalR_Port;
            txtBarcodeChar.Text = _objConfigurationDetail.BenhNhanSoKyTuBarCode;
            cboBarcodeMode.SelectedValue = _objConfigurationDetail.BenhNhanCheDoSoThuTu;
            txtCharBeforePID.Text = _objConfigurationDetail.BenhNhanKyTuMa;
            numBarcodeLapLai.Value = _objConfigurationDetail.BarcodeLapLai;
            chkInfoAutoSaveInNewMode.Checked = _objConfigurationDetail.BenhNhanTuLuuThongTinNhapMoi;
            txtHisSoluongBarcodeToiThieu.Text = _objConfigurationDetail.TiepNhanHisSoLuongBarcodeToiThieu;
            chkKetNoiHis.Checked = _objConfigurationDetail.ConnectHIS;
            txtStatisticDatabase.Text = _objConfigurationDetail.DatabaseThongKe;
            txtxBloodBankDatabase.Text = _objConfigurationDetail.DatabaseBloodBank;
            txtArchiveDatabase.Text = _objConfigurationDetail.DatabaseArchive;
            txtArchiveDatabase.Text = _objConfigurationDetail.DatabaseArchive;
            txtSoPhieuHIS_Preffix.Text = _objConfigurationDetail.PreffixMaTiepNhanHIS;
            txtSoPhieuHIS_Suffix.Text = _objConfigurationDetail.SuffixMaTiepNhanHIS;
            chkConvertVNI.Checked = _objConfigurationDetail.ConnectHISWithConvertFont;
            chkSuDungBarcodeHIS.Checked = _objConfigurationDetail.SuDungBarcodeHIS;
            chkChiTiepNhanBenhNhanTest.Checked = _objConfigurationDetail.TestHISMode;
            cboAutoSendOrderToTPHLabIMSWeb.Checked = _objConfigurationDetail.TPHLabIMSWeb_TuDongGuiChiDinh;
            #endregion
            #region Xét nghiệm

            radExportColumnWithName.Checked = _objConfigurationDetail.ClsXetNghiemXuatCotTheoTen;
            cboKieuNhapChiDinh.SelectedValue = _objConfigurationDetail.KieuNhapChiDinhDichVu;
            radKQMayTuDongTuIMS.Checked = _objConfigurationDetail.ClsXetNghiemFormKQMayTuDong;
            radXetNghiemTGInDauTien.Checked = _objConfigurationDetail.ClsXetNghiemThoiGianInKetQuaLanDau;
            radSignSameLogin.Checked = _objConfigurationDetail.ClsXetNghiemChoChuKyGiongUserDangNhap;
            radXemKetQuaTheoNhom.Checked = _objConfigurationDetail.ClsXetNghiemXemKetQuaTheoNhom;
            radBarcodeCoLoaiMau.Checked = _objConfigurationDetail.ClsXetNghiemBacodeCoLoaiMau;
            txtDinhDangTem.Text = _objConfigurationDetail.ClsXetNghiemDinhDangBarcode;
            txtLoaiMauKhongGhep.Text = _objConfigurationDetail.ClsXetNghiemLoaiMauKhongGhep;
            radValidWhenPrint.Checked = _objConfigurationDetail.ClsXetNghiemInTuXacNhan;
            radAnalyzerConnectTypeNormal.Checked = _objConfigurationDetail.ClsXetNghiemLoaiKetNoiMay == EnumLoaiKetNoiMay.ThongThuong;
            radAnalyzerResultFromAll.Checked = _objConfigurationDetail.ClsXetNghiemKieuLayKetQuaMay == EnumKieuLayKetQuaMay.TatCa;
            radAnalyzerResultFromMiddleware.Checked = _objConfigurationDetail.ClsXetNghiemKieuLayKetQuaMay == EnumKieuLayKetQuaMay.ChiTuPhanMemTrungGian;
            radXacNhanDe.Checked = _objConfigurationDetail.ClsXetNghiemXacNhanDe;
            cboQuiTrinh.SelectedValue = (int)_objConfigurationDetail.ClsXetNghiemXemQuiTrinh;
            txtDinhDanhgGhep.Text = _objConfigurationDetail.ClsXetNghiemDinhDangKetqua;
            chkChonKhuLayMau.Checked = _objConfigurationDetail.ClsXetNghiemChonKhuLayMau;
            chkChoPhepThayDoiMayXN.Checked = _objConfigurationDetail.ClsXetNghiemChoPhepSuaMayXN;
            chkChoPhepHienThiDSChoTraKQ.Checked = _objConfigurationDetail.ClsXetNghiemSuDungDanhSachChoTraKQ;
            SetModuleKichHoat();
            txtKichCoHinhSHPT.Text = _objConfigurationDetail.ClsXetNghiemKichCoHinhSHPT;
            chkChiInKetQuaDaDuyet.Checked = _objConfigurationDetail.ClsXetNghiemChiInKetQuaDaDuyet;
            numDSNhanMau.Value = (_objConfigurationDetail.ClsXetNghiemSoPhutLoadDSNhanMau > 0 ? _objConfigurationDetail.ClsXetNghiemSoPhutLoadDSNhanMau : 5);
            chkHienThiBoPhan.Checked = _objConfigurationDetail.ClsXetNghiemHienThiTrangThaiBoPhan;
            chkHienThiNhom.Checked = _objConfigurationDetail.ClsXetNghiemHienThiTrangThaiNhom;
            radGroupNhomTheoBoPhan.Checked = _objConfigurationDetail.ClsXetNghiemHienThiTrangThaiNhomTheoBoPhan;
            chkHienThiDanhSachBoLoc.Checked = _objConfigurationDetail.ClsXetNghiemHienThiDSBoLocHienThi;
            numDoCaoLuoi.Value = _objConfigurationDetail.ClsXetNghiemDoCaoLuoiThongTin;
            chkResetKhiXaoHangLoat.Checked = _objConfigurationDetail.ClsXetNghiemReDownloadKhiXoaHangLoat;
            radTimTheoSoHoSo.Checked = _objConfigurationDetail.ClsXetNghiemSuDungSoHoSo;
            chkUploadHIS_DaDuyet.Checked = _objConfigurationDetail.ClsXetNghiemUploadDaDuyet;
            chkUploadHIS_DaIn.Checked = _objConfigurationDetail.ClsXetNghiemUploadDaIn;
            cboNguoiThucHien.SelectedValue = _objConfigurationDetail.LayNguoiThucHien;
            radChonKyTen.Checked = _objConfigurationDetail.YeuCauChonKyTen;
            radKyTenInLaiKhacLanTruoc.Checked = _objConfigurationDetail.ChoPhepChonKyTenKhac;
            radChonInKhiDuyet.Checked = _objConfigurationDetail.ChonInKhiDuyet;
            SetCanhLe(_objConfigurationDetail.ClsXetNghiemCanhLeKetQuaTrenLuoi);
            SetLoaiCanhbaoKQ(_objConfigurationDetail.ClsXetNghiemKieuCanhBaoKQ);
            pnMauCanhBao.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauCanhBaoKetQua) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauCanhBaoKetQua));
            radCanhBaoNullCSBT.Checked = _objConfigurationDetail.ClsXetNghiemCanhBaoNullCSBT;

            pnMauChuaKetQua.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauChuaKQ) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauChuaKQ));
            pnMauDaCoKQ.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauDaCoKQ) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauDaCoKQ));
            pnMauDuKQ.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauDuKQ) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauDuKQ));
            pnMauDaDuyet.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauDaDuyetKQ) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauDaDuyetKQ));
            pnMauDaInKQ.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauDaInKQ) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauDaInKQ));
            numTinhTAT.Value = (_objConfigurationDetail.ClsXetNghiemCachTinhTAT == 0 ? 1 : _objConfigurationDetail.ClsXetNghiemCachTinhTAT); ;
            //ClsXetNghiemTATDashboardTheoBoPhan
            radTATDashboardTheoBP.Checked = _objConfigurationDetail.ClsXetNghiemTATDashboardTheoBoPhan;
            chkDashboardBieuDo.Checked = _objConfigurationDetail.ClsXetNghiemTATDashboardBieuDo;
            chkThemKyTuTrenDanhDauTem.Checked = _objConfigurationDetail.ClsXetNghiemDanhDauKyTuTem;
            chkLuonHienThiTuyChon.Checked = _objConfigurationDetail.ClsXetNghiemHienTuyChon;
            nuAutoFocus.Value = _objConfigurationDetail.ClsXetNghiemTuFocusBarcode;
            chkKiemSoatChuyenMau.Checked = _objConfigurationDetail.ClsXetNghiemKiemSoatChuyenMau;
            chkBaoDongMauNhanTre.Checked = _objConfigurationDetail.ClsXetNghiemCanhBaoNhanTre;
            numTuKhoangBD.Value = _objConfigurationDetail.ClsXetNghiemCanDuoiNhanTre;
            numDenKhoangBD.Value = _objConfigurationDetail.ClsXetNghiemCanTrenNhanTre;
            pnMautrongKhoanBaoDong.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauTrongKhoangTre) ? System.Drawing.Color.Yellow : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauTrongKhoangTre));
            pnMauNgoaiKhoangBaoDong.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMauNgoaiKhoangTre) ? System.Drawing.Color.Red : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMauNgoaiKhoangTre));
            txtDuongDanAmThanhCanhBao.Text = _objConfigurationDetail.ClsXetNghiemDuongDanCanhBao;
            chkXuatPDFKhiIn.Checked = _objConfigurationDetail.ClsXetNghiemXuatPDFKhiIn;
            chkSuDungChuKyLanhDao.Checked = _objConfigurationDetail.ClsXetNghiemSuDungChuKyLanhDao;
            chkChoPhepChonGioKyThuongQuy.Checked = _objConfigurationDetail.ClsXetNghiemChongioKyTQ;
            chkChoPhepChonGioKySHPT.Checked = _objConfigurationDetail.ClsXetNghiemChongioKySHPT;
            radLuuMau_TheoViTri.Checked = _objConfigurationDetail.ClsXetnghiemLuuMauInTheoViTri;
            chkKhongInKetQuaQCFail.Checked = _objConfigurationDetail.ClsXetNghiemKhongInQCFail;
            chkChoPhepDuyetKetQuaQCFail.Checked = _objConfigurationDetail.ClsXetNghiemChoDuyetQCFail;

            pnDuyetMau_TatCa.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMau_MauDuThaoTac) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMau_MauDuThaoTac));
            pnDuyetMau_ChuaThucHien.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMau_MauChuaThaoTac) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMau_MauChuaThaoTac));
            pnDuyetMau_ChuaDu.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMau_MauThaoTacChuaDu) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMau_MauThaoTacChuaDu));
            pnDuyetMau_YeuCauLayLai.BackColor = (string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemMau_MauYeuCauLayLai) ? System.Drawing.Color.Empty : System.Drawing.ColorTranslator.FromHtml(_objConfigurationDetail.ClsXetNghiemMau_MauYeuCauLayLai));
            chkLayNhanMauTheoBarcode.Checked = _objConfigurationDetail.ClsXetNghiemPhanBietMauTheobarcode;
            chkInKQTienSu.Checked = _objConfigurationDetail.ClsXetNghiemInCoTienSu;

            txtMayDuocMoToolUploadHIS.Text = _objConfigurationDetail.ClsXetNghiemMayDungToolUpload;
            txtMayDuocMoToolKetQua.Text = _objConfigurationDetail.ClsXetNghiemMayDungToolKetQua;
            chkKiemTraMayKhiIn.Checked = _objConfigurationDetail.ClsXetNghiemKiemTraMayXNKhiIn;
            radTinhHenGioTheoXn.Checked = _objConfigurationDetail.ClsXetNghiemHenTheoXetNghiem;
            #endregion
            #region Email

            txtEmailAddress.Text = _objConfigurationDetail.EmailMailFrom;
            txtSMTPServer.Text = _objConfigurationDetail.EmailSmptServer;
            chkCredential.Checked = _objConfigurationDetail.EmailUseSsl;
            txtUserID.Text = _objConfigurationDetail.EmailUserId;
            txtPassword.Text = _objConfigurationDetail.EmailPassword;
            txtPathForPDF.Text = _objConfigurationDetail.EmailPdfPath;
            txtEmailBody.Text = _objConfigurationDetail.EmailMailBody;
            txtEmailPort.Text = _objConfigurationDetail.EmailPortNumber;
            #endregion
            #region Siêu âm

            txtSieuAm_PathImage.Text = _objConfigurationDetail.ClsSieuAmDuongDanLuuHinhAnh;
            txtSieuAm_PathVideo.Text = _objConfigurationDetail.ClsSieuAmDuongDanLuuVideo;
            cboSieuAm_ImageSize.SelectedValue = _objConfigurationDetail.ClsSieuAmKichCoXemHinh;
            #endregion
            #region Nội soi

            txtNoiSoi_PathImage.Text = _objConfigurationDetail.ClsNoiSoiDuongDanLuuHinhAnh;
            txtNoiSoi_PathVideo.Text = _objConfigurationDetail.ClsNoiSoiDuongDanLuuVideo;
            cboNoiSoi_ImageSize.SelectedValue = _objConfigurationDetail.ClsNoiSoiKichCoXemHinh;
            #endregion
            #region Hình điện tim
            txtECGResultPath.Text = _objConfigurationDetail.ClsDienTimDuongDanKetQuaMay;
            txtECGLastestResult.Text = _objConfigurationDetail.ClsDienTimDuongDanKetQua;
            cboDienTim_ImageCropSize.SelectedValue = _objConfigurationDetail.ClsDienTimKichCoKetQua;
            #endregion

            #region Chu ky dien tu
            chkDungKySo.Checked = _objConfigurationDetail.ChuKyDienTuSuDung;
            txtChuKySoLinkAPI.Text = _objConfigurationDetail.ChuKyDienTuLinkAPI;
            txtChuKySoTaiKhoan.Text = _objConfigurationDetail.ChuKyDienTuTaiKhoan;
            txtChuKySoMatKhau.Text = _objConfigurationDetail.ChuKyDienTuMatKhau;
            txtChuKySoSerial.Text = _objConfigurationDetail.ChuKyDienTuSerial;
            txtChuKySoSHA.Text = _objConfigurationDetail.ChuKyDienTuSHA;
            txtChuKySoNoiLuuPDFDaXacThuc.Text = _objConfigurationDetail.ChuKyDienTuNoiLuuPDF;
            numChuKySoTimeOut.Value = _objConfigurationDetail.ChuKyDienTuUserTimeOut;
            chkChuKySoXacThucUserKyten.Checked = _objConfigurationDetail.ChuKyDienTuXacNhanUser;

            txtChuKySoBottom.Text = _objConfigurationDetail.ChuKyDienTuLeDuoi.ToString();
            txtChuKySoTop.Text = _objConfigurationDetail.ChuKyDienTuLeTren.ToString();
            txtChuKySoLeft.Text = _objConfigurationDetail.ChuKyDienTuLeTrai.ToString();
            txtChuKySoRight.Text = _objConfigurationDetail.ChuKyDienTuLePhai.ToString();
            txtChuKySoCoChu.Text = _objConfigurationDetail.ChuKyDienTuCoChu.ToString();
            cboChuKySoViTriKy.SelectedValue = _objConfigurationDetail.ChuKyDienTuViTri;
            txtChuKySoDoCao.Text = _objConfigurationDetail.ChuKyDienTuDoCaoRec.ToString();
            txtChuKySoDoRong.Text = _objConfigurationDetail.ChuKyDienTuDoRongRec.ToString();

            txtChuKySoLyDo.Text = _objConfigurationDetail.ChuKyDienTuLyDo;
            txtChuKySoDinhDang.Text = _objConfigurationDetail.ChuKyDienTuDinhDang;
            txtChuKySoDinhDangNgayGio.Text = _objConfigurationDetail.ChuKyDienTuDinhDangNgayGio;
            txtChuKySoDiaDiem.Text = _objConfigurationDetail.ChuKyDienTuNoiKy;

            #endregion

        }
        private int GetLoaiCanhbaoKQ()
        {
            // 0: Không dùng -1: Dòng - 2: Tên Xn -3: Kết quả
            if (radCanhBaoTheoDong.Checked)
                return 1;
            else if (radCanhBaoTheoTen.Checked)
                return 2;
            else if (radCanhBaoTheoKQ.Checked)
                return 3;
            else
                return 0;
        }
        private void SetLoaiCanhbaoKQ(int idLoai)
        {
            // 0: Không dùng -1: Dòng - 2: Tên Xn -3: Kết quả
            if (idLoai == 1)
                radCanhBaoTheoDong.Checked = true;
            else if (idLoai == 2)
                radCanhBaoTheoTen.Checked = true;
            else if (idLoai == 3)
                radCanhBaoTheoKQ.Checked = true;
            else
                radCanhBao_KhongDung.Checked = true;
        }
        private void CalculatebarcodeRange()
        {
            if (!string.IsNullOrEmpty(txtBarcodeChar.Text))
            {
                if (WorkingServices.IsNumeric(txtBarcodeChar.Text))
                {
                    int numberOfChar = int.Parse(txtBarcodeChar.Text);
                    if (numberOfChar > 1)
                    {
                        txtMinimumBarcode.Text = "1";
                        txtMaximumBarcode.Text = "9";
                        for (int i = 1; i < numberOfChar; i++)
                        {
                            txtMinimumBarcode.Text += "0";
                            txtMaximumBarcode.Text += "9";
                        }
                    }
                }
            }
        }

        private void txtBarcodeChar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void txtBarcodeChar_KeyUp(object sender, KeyEventArgs e)
        {
            CalculatebarcodeRange();
        }

        private void txtBarcodeChar_TextChanged(object sender, EventArgs e)
        {
            CalculatebarcodeRange();
        }

        private void frmCauHinh_CaiDatHeThong_Load(object sender, EventArgs e)
        {
            HightLightButton(btnCaiDatChung);
            foreach (TabPage tab in tabConfig.TabPages)
            {
                tab.BackColor = CommonAppColors.ColorMainAppFormColor;

            }
            Get_LAB_QuiTrinh();
            LoadSignPosition();
            Get_LAB_UserThucHien();
            Get_List_BarcodeType();
            Get_List_ImageSize();
            Get_Lis_InsertOrderMode();
            Get_SystemConfig();
            if (!CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsXetNghiem).ToString()))
            {
                tabConfig.TabPages.Remove(tabXetNghiem);
                btnXetNghiem1.Visible = btnXetNghiem2.Visible = false;
            }
            if (!CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsSieuAm).ToString()))
            {
                tabConfig.TabPages.Remove(tabSieuAm);
                btnSieuAm.Visible = false;
            }
            if (!CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsNoiSoi).ToString()))
            {
                tabConfig.TabPages.Remove(tabNoiSoi);
                btnNoiSoi.Visible = false;
            }
            if (!CommonAppVarsAndFunctions.ListEnumLoaiDichVu().Contains(((int)ServiceType.ClsDienTim).ToString()))
            {
                tabConfig.TabPages.Remove(tabDienTim);
                btnDienTim.Visible = false;
            }
            LoaDanhSachLoaiHienThi();
           
        }
        private IWorkingLogService _logService = new WorkingLogService();
        private void LoadSignPosition()
        {
            var positions = new DataTable();
            positions.Columns.Add("key", typeof(int));
            positions.Columns.Add("value", typeof(string));
            var dr = positions.NewRow();
            dr["key"] = 1;
            dr["value"] = "TOP - LEFT";
            positions.Rows.Add(dr);
            dr = positions.NewRow();
            dr["key"] = 2;
            dr["value"] = "TOP - RIGHT";
            positions.Rows.Add(dr);
            dr = positions.NewRow();
            dr["key"] = 3;
            dr["value"] = "BOTTOM - LEFT";
            positions.Rows.Add(dr);
            dr = positions.NewRow();
            dr["key"] = 4;
            dr["value"] = "BOTTOM - RIGHT";
            positions.Rows.Add(dr);
            dr = positions.NewRow();
            dr["key"] = 5;
            dr["value"] = "USER DEFINE";
            positions.Rows.Add(dr);

            cboChuKySoViTriKy.DataSource = positions;
            cboChuKySoViTriKy.DisplayMember = "Value";
            cboChuKySoViTriKy.ValueMember = "Key";
            cboChuKySoViTriKy.SelectedValue = 5;
        }
        private void btnLuCauHinh_Click(object sender, EventArgs e)
        {
            var currentConfig = _sysConfig.GetSystemConfigurationDetail();

            _objConfigurationDetail.LuuCauHinhTheoKhuVuc = CommonConfigConstant.AllComputer;
            #region Gerneral
            _objConfigurationDetail.BenhNhanSoKyTuBarCode = txtBarcodeChar.Text;
            _objConfigurationDetail.BenhNhanCheDoSoThuTu = cboBarcodeMode.SelectedValue.ToString();
            _objConfigurationDetail.BenhNhanKyTuMa = txtCharBeforePID.Text;
            _objConfigurationDetail.BarcodeLapLai = (int)numBarcodeLapLai.Value;
            _objConfigurationDetail.BenhNhanTuLuuThongTinNhapMoi = chkInfoAutoSaveInNewMode.Checked;
            _objConfigurationDetail.TiepNhanHisSoLuongBarcodeToiThieu = txtHisSoluongBarcodeToiThieu.Text;
            _objConfigurationDetail.ConnectHIS = chkKetNoiHis.Checked;
            _objConfigurationDetail.DatabaseThongKe = txtStatisticDatabase.Text;
            _objConfigurationDetail.DatabaseBloodBank = txtxBloodBankDatabase.Text;
            _objConfigurationDetail.DatabaseArchive = txtArchiveDatabase.Text;
            _objConfigurationDetail.DatabaseArchive = txtArchiveDatabase.Text;
            _objConfigurationDetail.PreffixMaTiepNhanHIS = txtSoPhieuHIS_Preffix.Text;
            _objConfigurationDetail.SuffixMaTiepNhanHIS = txtSoPhieuHIS_Suffix.Text;
            _objConfigurationDetail.ConnectHISWithConvertFont = chkConvertVNI.Checked;
            _objConfigurationDetail.SuDungBarcodeHIS = chkSuDungBarcodeHIS.Checked;
            _objConfigurationDetail.TestHISMode = chkChiTiepNhanBenhNhanTest.Checked;
            _objConfigurationDetail.TPHLabIMSWeb_TuDongGuiChiDinh = cboAutoSendOrderToTPHLabIMSWeb.Checked;
            #endregion
            #region Xét nghiệm
            _objConfigurationDetail.ClsXetNghiemXuatCotTheoTen = radExportColumnWithName.Checked;
            _objConfigurationDetail.ClsXetNghiemFormKQMayTuDong = radKQMayTuDongTuIMS.Checked;
            _objConfigurationDetail.ClsXetNghiemChonKhuLayMau = chkChonKhuLayMau.Checked;
            _objConfigurationDetail.ClsXetNghiemSoPhutLoadDSNhanMau = (int)numDSNhanMau.Value;

            _objConfigurationDetail.KieuNhapChiDinhDichVu = int.Parse(cboKieuNhapChiDinh.SelectedValue.ToString());
            _objConfigurationDetail.ClsXetNghiemXemKetQuaTheoNhom = radXemKetQuaTheoNhom.Checked;
            _objConfigurationDetail.ClsXetNghiemBacodeCoLoaiMau = radBarcodeCoLoaiMau.Checked;
            _objConfigurationDetail.ClsXetNghiemTinhSoTemTheoNhom = 5;
            _objConfigurationDetail.ClsXetNghiemDinhDangBarcode = txtDinhDangTem.Text;
            _objConfigurationDetail.ClsXetNghiemLoaiMauKhongGhep = txtLoaiMauKhongGhep.Text;
            _objConfigurationDetail.ClsXetNghiemInTuXacNhan = radValidWhenPrint.Checked;
            _objConfigurationDetail.ClsXetNghiemLoaiKetNoiMay = radAnalyzerConnectTypeNormal.Checked ? EnumLoaiKetNoiMay.ThongThuong : EnumLoaiKetNoiMay.CoPhanMemTrungGian;
            _objConfigurationDetail.ClsXetNghiemKieuLayKetQuaMay = radAnalyzerResultFromAll.Checked ? EnumKieuLayKetQuaMay.TatCa : (radAnalyzerResultFromMiddleware.Checked ? EnumKieuLayKetQuaMay.ChiTuPhanMemTrungGian : EnumKieuLayKetQuaMay.ChiTuMayThongThuong);
            _objConfigurationDetail.ClsXetNghiemXacNhanDe = radXacNhanDe.Checked;
            _objConfigurationDetail.ClsXetNghiemXemQuiTrinh = (EnumQuiTrinhLAB)Enum.Parse(typeof(EnumQuiTrinhLAB), cboQuiTrinh.SelectedValue.ToString());
            _objConfigurationDetail.ClsXetNghiemDinhDangKetqua = txtDinhDanhgGhep.Text;
            _objConfigurationDetail.ClsXetNghiemChoPhepSuaMayXN = chkChoPhepThayDoiMayXN.Checked;
            _objConfigurationDetail.ClsXetNghiemSuDungDanhSachChoTraKQ = chkChoPhepHienThiDSChoTraKQ.Checked;
            _objConfigurationDetail.ClsXetNghiemModuleKichHoat = GetModuleKichHoat();
            _objConfigurationDetail.ClsXetNghiemKichCoHinhSHPT = txtKichCoHinhSHPT.Text;
            _objConfigurationDetail.ClsXetNghiemChiInKetQuaDaDuyet = chkChiInKetQuaDaDuyet.Checked;

            _objConfigurationDetail.ClsXetNghiemHienThiTrangThaiBoPhan = chkHienThiBoPhan.Checked;
            _objConfigurationDetail.ClsXetNghiemHienThiTrangThaiNhom = chkHienThiNhom.Checked;
            _objConfigurationDetail.ClsXetNghiemHienThiTrangThaiNhomTheoBoPhan = radGroupNhomTheoBoPhan.Checked;
            _objConfigurationDetail.ClsXetNghiemDoCaoLuoiThongTin = (int)numDoCaoLuoi.Value;
            _objConfigurationDetail.ClsXetNghiemHienThiDSBoLocHienThi = chkHienThiDanhSachBoLoc.Checked;
            _objConfigurationDetail.ClsXetNghiemReDownloadKhiXoaHangLoat = chkResetKhiXaoHangLoat.Checked;
            _objConfigurationDetail.ClsXetNghiemSuDungSoHoSo = radTimTheoSoHoSo.Checked;
            _objConfigurationDetail.ClsXetNghiemUploadDaDuyet = chkUploadHIS_DaDuyet.Checked;
            _objConfigurationDetail.ClsXetNghiemUploadDaIn = chkUploadHIS_DaIn.Checked;
            _objConfigurationDetail.ClsXetNghiemCanhLeKetQuaTrenLuoi = GetCanhLe();
            _objConfigurationDetail.LayNguoiThucHien = int.Parse(cboNguoiThucHien.SelectedValue.ToString());

            _objConfigurationDetail.ChoPhepChonKyTenKhac = radKyTenInLaiKhacLanTruoc.Checked;
            _objConfigurationDetail.YeuCauChonKyTen = radChonKyTen.Checked;
            _objConfigurationDetail.ChonInKhiDuyet = radChonInKhiDuyet.Checked;
            _objConfigurationDetail.ClsXetNghiemKieuCanhBaoKQ = GetLoaiCanhbaoKQ();
            _objConfigurationDetail.ClsXetNghiemMauCanhBaoKetQua = System.Drawing.ColorTranslator.ToHtml(pnMauCanhBao.BackColor);
            _objConfigurationDetail.ClsXetNghiemCanhBaoNullCSBT = radCanhBaoNullCSBT.Checked;

            _objConfigurationDetail.ClsXetNghiemMauDaInKQ = System.Drawing.ColorTranslator.ToHtml(pnMauDaInKQ.BackColor);
            _objConfigurationDetail.ClsXetNghiemMauDaDuyetKQ = System.Drawing.ColorTranslator.ToHtml(pnMauDaDuyet.BackColor);
            _objConfigurationDetail.ClsXetNghiemMauDuKQ = System.Drawing.ColorTranslator.ToHtml(pnMauDuKQ.BackColor);
            _objConfigurationDetail.ClsXetNghiemMauDaCoKQ = System.Drawing.ColorTranslator.ToHtml(pnMauDaCoKQ.BackColor);
            _objConfigurationDetail.ClsXetNghiemMauChuaKQ = System.Drawing.ColorTranslator.ToHtml(pnMauChuaKetQua.BackColor);
            _objConfigurationDetail.ClsXetNghiemCachTinhTAT = (int)numTinhTAT.Value;
            _objConfigurationDetail.ClsXetNghiemTATDashboardTheoBoPhan = radTATDashboardTheoBP.Checked;
            _objConfigurationDetail.ClsXetNghiemTATDashboardBieuDo = chkDashboardBieuDo.Checked;
            _objConfigurationDetail.ClsXetNghiemDanhDauKyTuTem = chkThemKyTuTrenDanhDauTem.Checked;
            _objConfigurationDetail.ClsXetNghiemTuFocusBarcode = (int)nuAutoFocus.Value;
            _objConfigurationDetail.ClsXetNghiemHienTuyChon = chkLuonHienThiTuyChon.Checked;
            _objConfigurationDetail.ClsXetNghiemKiemSoatChuyenMau = chkKiemSoatChuyenMau.Checked;

            _objConfigurationDetail.ClsXetNghiemCanhBaoNhanTre = chkBaoDongMauNhanTre.Checked;
            _objConfigurationDetail.ClsXetNghiemCanDuoiNhanTre = (int)numTuKhoangBD.Value;
            _objConfigurationDetail.ClsXetNghiemCanTrenNhanTre = (int)numDenKhoangBD.Value;
            _objConfigurationDetail.ClsXetNghiemMauTrongKhoangTre = System.Drawing.ColorTranslator.ToHtml(pnMautrongKhoanBaoDong.BackColor);
            _objConfigurationDetail.ClsXetNghiemMauTrongKhoangTre = System.Drawing.ColorTranslator.ToHtml(pnMauNgoaiKhoangBaoDong.BackColor);
            _objConfigurationDetail.ClsXetNghiemDuongDanCanhBao = txtDuongDanAmThanhCanhBao.Text;
            _objConfigurationDetail.ClsXetNghiemXuatPDFKhiIn = chkXuatPDFKhiIn.Checked;
            _objConfigurationDetail.ClsXetNghiemSuDungChuKyLanhDao = chkSuDungChuKyLanhDao.Checked;
            _objConfigurationDetail.ClsXetNghiemThoiGianInKetQuaLanDau = radXetNghiemTGInDauTien.Checked;
            _objConfigurationDetail.ClsXetNghiemChongioKyTQ = chkChoPhepChonGioKyThuongQuy.Checked;
            _objConfigurationDetail.ClsXetNghiemChongioKySHPT = chkChoPhepChonGioKySHPT.Checked;
            _objConfigurationDetail.ClsXetnghiemLuuMauInTheoViTri = radLuuMau_TheoViTri.Checked;
            _objConfigurationDetail.ClsXetNghiemKhongInQCFail = chkKhongInKetQuaQCFail.Checked;
            _objConfigurationDetail.ClsXetNghiemChoDuyetQCFail = chkChoPhepDuyetKetQuaQCFail.Checked;

            _objConfigurationDetail.ClsXetNghiemMau_MauDuThaoTac = System.Drawing.ColorTranslator.ToHtml(pnDuyetMau_TatCa.BackColor);
            _objConfigurationDetail.ClsXetNghiemMau_MauChuaThaoTac = System.Drawing.ColorTranslator.ToHtml(pnDuyetMau_ChuaThucHien.BackColor);
            _objConfigurationDetail.ClsXetNghiemMau_MauThaoTacChuaDu = System.Drawing.ColorTranslator.ToHtml(pnDuyetMau_ChuaDu.BackColor);
            _objConfigurationDetail.ClsXetNghiemMau_MauYeuCauLayLai = System.Drawing.ColorTranslator.ToHtml(pnDuyetMau_YeuCauLayLai.BackColor);
            _objConfigurationDetail.ClsXetNghiemPhanBietMauTheobarcode = chkLayNhanMauTheoBarcode.Checked;
            _objConfigurationDetail.ClsXetNghiemInCoTienSu = chkInKQTienSu.Checked;

            _objConfigurationDetail.ClsXetNghiemMayDungToolUpload = txtMayDuocMoToolUploadHIS.Text;
            _objConfigurationDetail.ClsXetNghiemMayDungToolKetQua = txtMayDuocMoToolKetQua.Text;
            _objConfigurationDetail.ClsXetNghiemKiemTraMayXNKhiIn = chkKiemTraMayKhiIn.Checked;
            _objConfigurationDetail.ClsXetNghiemHenTheoXetNghiem = radTinhHenGioTheoXn.Checked;

            #endregion
            #region Email

            _objConfigurationDetail.EmailMailFrom = txtEmailAddress.Text;
            _objConfigurationDetail.EmailSmptServer = txtSMTPServer.Text;
            _objConfigurationDetail.EmailUseSsl = chkCredential.Checked;
            _objConfigurationDetail.EmailUserId = txtUserID.Text;
            _objConfigurationDetail.EmailPassword = txtPassword.Text;
            _objConfigurationDetail.EmailPdfPath = txtPathForPDF.Text;
            _objConfigurationDetail.EmailMailBody = txtEmailBody.Text;
            _objConfigurationDetail.EmailPortNumber = txtEmailPort.Text;
            #endregion
            #region Siêu âm

            _objConfigurationDetail.ClsSieuAmDuongDanLuuHinhAnh = txtSieuAm_PathImage.Text;
            _objConfigurationDetail.ClsSieuAmDuongDanLuuVideo = txtSieuAm_PathVideo.Text;
            _objConfigurationDetail.ClsSieuAmKichCoXemHinh = cboSieuAm_ImageSize.SelectedValue.ToString();
            #endregion
            #region Nội soi

            _objConfigurationDetail.ClsNoiSoiDuongDanLuuHinhAnh = txtNoiSoi_PathImage.Text;
            _objConfigurationDetail.ClsNoiSoiDuongDanLuuVideo = txtNoiSoi_PathVideo.Text;
            _objConfigurationDetail.ClsNoiSoiKichCoXemHinh = cboNoiSoi_ImageSize.SelectedValue.ToString();
            #endregion
            #region Hình điện tim
            _objConfigurationDetail.ClsDienTimDuongDanKetQuaMay = txtECGResultPath.Text;
            _objConfigurationDetail.ClsDienTimDuongDanKetQua = txtECGLastestResult.Text;
            _objConfigurationDetail.ClsDienTimKichCoKetQua = cboDienTim_ImageCropSize.SelectedValue.ToString();
            #endregion
            #region Chu ky dien tu

            var vitriKy = NumberConverter.ToInt(cboChuKySoViTriKy.SelectedValue);
            _objConfigurationDetail.ChuKyDienTuSuDung = chkDungKySo.Checked;
            _objConfigurationDetail.ChuKyDienTuLinkAPI = txtChuKySoLinkAPI.Text;
            _objConfigurationDetail.ChuKyDienTuTaiKhoan = txtChuKySoTaiKhoan.Text;
            _objConfigurationDetail.ChuKyDienTuMatKhau = txtChuKySoMatKhau.Text;
            _objConfigurationDetail.ChuKyDienTuSerial = txtChuKySoSerial.Text;
            _objConfigurationDetail.ChuKyDienTuSHA = txtChuKySoSHA.Text;
            _objConfigurationDetail.ChuKyDienTuNoiLuuPDF = txtChuKySoNoiLuuPDFDaXacThuc.Text;
            _objConfigurationDetail.ChuKyDienTuUserTimeOut = NumberConverter.ToInt(numChuKySoTimeOut.Value);
            _objConfigurationDetail.ChuKyDienTuXacNhanUser = chkChuKySoXacThucUserKyten.Checked;

            _objConfigurationDetail.ChuKyDienTuLeDuoi =
                int.Parse(string.IsNullOrEmpty(txtChuKySoBottom.Text) ? "-1" : txtChuKySoBottom.Text);
            _objConfigurationDetail.ChuKyDienTuLeTren =
                int.Parse(string.IsNullOrEmpty(txtChuKySoTop.Text) ? "-1" : txtChuKySoTop.Text);
            _objConfigurationDetail.ChuKyDienTuLeTrai =
                int.Parse(string.IsNullOrEmpty(txtChuKySoLeft.Text) ? "-1" : txtChuKySoLeft.Text);
            _objConfigurationDetail.ChuKyDienTuLePhai =
                int.Parse(string.IsNullOrEmpty(txtChuKySoRight.Text) ? "-1" : txtChuKySoRight.Text);
            _objConfigurationDetail.ChuKyDienTuCoChu =
                int.Parse(string.IsNullOrEmpty(txtChuKySoCoChu.Text) ? "-1" : txtChuKySoCoChu.Text);
            _objConfigurationDetail.ChuKyDienTuViTri = vitriKy;
            _objConfigurationDetail.ChuKyDienTuDoCaoRec =
                int.Parse(string.IsNullOrEmpty(txtChuKySoDoCao.Text) ? "-1" : txtChuKySoDoCao.Text);
            _objConfigurationDetail.ChuKyDienTuDoRongRec =
                int.Parse(string.IsNullOrEmpty(txtChuKySoDoRong.Text) ? "-1" : txtChuKySoDoRong.Text);

            _objConfigurationDetail.ChuKyDienTuLyDo = txtChuKySoLyDo.Text;
            _objConfigurationDetail.ChuKyDienTuDinhDang = txtChuKySoDinhDang.Text;
            _objConfigurationDetail.ChuKyDienTuDinhDangNgayGio = txtChuKySoDinhDangNgayGio.Text;
            _objConfigurationDetail.ChuKyDienTuNoiKy = txtChuKySoDiaDiem.Text;

            #endregion
            _objConfigurationDetail.SignalR_HostName = txtRabbit_HostName.Text;
            _objConfigurationDetail.SignalR_Port = (int)numRabbit_Port.Value;
            _logService.Insert_HeThong_NhatKyDanhMuc(
                new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = "CauHinhHeThong",
                Nguoithuchien = CommonAppVarsAndFunctions.UserID,
                Noidung = WorkingServices.GetUpdate_Differences(_objConfigurationDetail, currentConfig),
                Idnhatky = LogTableIds.Cauhinh_hethong,
                Pcthuchien = Environment.MachineName
            });
            _sysConfig.InsertUpdateConfiguationDetail(_objConfigurationDetail);
            CommonAppVarsAndFunctions.sysConfig = _sysConfig.GetSystemConfigurationDetail();
            CustomMessageBox.MSG_Information_OK("Lưu hoàn tất!");
        }
        private string GetModuleKichHoat()
        {
            var chuoiModule = new List<string>();
            if (chkModulehuyetTuyeDo.Checked)
                chuoiModule.Add(((int)IMSModule.XetNghiemHuyetTuyDo).ToString());
            if (chkModuleSangLoc.Checked)
                chuoiModule.Add(((int)IMSModule.XetNghiemSangLoc).ToString());
            if (chkModuleSHPT.Checked)
                chuoiModule.Add(((int)IMSModule.XetNghiemSHPT).ToString());
            if (chkModuleThuongQuy.Checked)
                chuoiModule.Add(((int)IMSModule.XetNghiemThuongQuy).ToString());
            if (chkModuleVSNuoiCay.Checked)
                chuoiModule.Add(((int)IMSModule.XetNghiemViSinhNuoicay).ToString());
            if (chkThuPhi.Checked)
                chuoiModule.Add(((int)IMSModule.ThuPhi).ToString());
            if (chkSieuAm.Checked)
                chuoiModule.Add(((int)IMSModule.SieuAm).ToString());
            if (chkNoiSoi.Checked)
                chuoiModule.Add(((int)IMSModule.NoiSoi).ToString());
            if (chkXQuang.Checked)
                chuoiModule.Add(((int)IMSModule.XQuang).ToString());
            return string.Join(",", chuoiModule);
        }
        private void SetModuleKichHoat()
        {
            if(!string.IsNullOrEmpty(_objConfigurationDetail.ClsXetNghiemModuleKichHoat))
            {
                var arr = _objConfigurationDetail.ClsXetNghiemModuleKichHoat.Split(',');
                if(arr.Length >0)
                {
                    foreach (var m in arr)
                    {
                        if(!string.IsNullOrEmpty(m))
                        {
                            var module = (IMSModule)Enum.Parse(typeof(IMSModule), m);
                            if (module == IMSModule.XetNghiemHuyetTuyDo)
                                chkModulehuyetTuyeDo.Checked = true;
                            else if (module == IMSModule.XetNghiemSangLoc)
                                chkModuleSangLoc.Checked = true;
                            else if (module == IMSModule.XetNghiemSHPT)
                                chkModuleSHPT.Checked = true;
                            else if (module == IMSModule.XetNghiemThuongQuy)
                                chkModuleThuongQuy.Checked = true;
                            else if (module == IMSModule.XetNghiemViSinhNuoicay)
                                chkModuleVSNuoiCay.Checked = true;
                            else if (module == IMSModule.ThuPhi)
                                chkThuPhi.Checked = true;
                            else if (module == IMSModule.SieuAm)
                                chkSieuAm.Checked = true;
                            else if (module == IMSModule.NoiSoi)
                                chkNoiSoi.Checked = true;
                            else if (module == IMSModule.XQuang)
                                chkXQuang.Checked = true;

                        }
                    }
                }
            }
        }
        private int GetCanhLe()
        {
            int le = 0;
            if (radTatCaCanhTrai.Checked)
                le = 0;
            else if (radTatCaCanhGiua.Checked)
                le = 1;
            else if (radTaCaCanhPhai.Checked)
                le = 2;
            else if (radCanhChuTraiSoPhai.Checked)
                le = 3;
            else if (radCanhSoTraiChuPhai.Checked)
                le = 4;
            return le;
        }
        private void SetCanhLe(int le)
        {
            if (le == 1)
                radTatCaCanhGiua.Checked = true;
            else if (le == 2)
                radTaCaCanhPhai.Checked = true;
            else if (le == 3)
                radCanhChuTraiSoPhai.Checked = true;
            else if (le == 4)
                radCanhSoTraiChuPhai.Checked = true;
            else
                radTatCaCanhTrai.Checked = true;
        }
      
        private void chkCredential_CheckedChanged(object sender, EventArgs e)
        {
            txtUserID.Enabled = txtPassword.Enabled = chkCredential.Checked;
        }

        private void btnBrowsePDF_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtPathForPDF.Text = dialog.SelectedPath;
                _objConfigurationDetail.EmailPdfPath = txtPathForPDF.Text;
            }
        }

        private void btnSieuAm_BrowsePathImage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtSieuAm_PathImage.Text = dialog.SelectedPath;
            }
        }

        private void btnSieuAm_BrowsePathVideo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtSieuAm_PathVideo.Text = dialog.SelectedPath;
            }
        }

        private void btnNoiSoi_BrowsePathImage_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtNoiSoi_PathImage.Text = dialog.SelectedPath;
            }
        }

        private void btnNoiSoi_BrowsePathVideo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtNoiSoi_PathVideo.Text = dialog.SelectedPath;
            }
        }

        private void btnBrowseECGResultPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtECGResultPath.Text = dialog.SelectedPath;
            }
        }

        private void btnBrowseECGResultLastest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtECGLastestResult.Text = dialog.SelectedPath;
            }
        }

        private void txtHisSoluongBarcodeToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void txtHisThoiGianLayDuLieuUpload_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }

        private void chkKetNoiHis_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radBarcodeCoLoaiMau_CheckedChanged(object sender, EventArgs e)
        {
            txtDinhDangTem.Enabled = radBarcodeCoLoaiMau.Checked;
            txtLoaiMauKhongGhep.Enabled = radBarcodeCoLoaiMau.Checked;
        }
    
        private void tabTiepNhan_Click(object sender, EventArgs e)
        {

        }

        private void chkHienThiNhom_CheckedChanged(object sender, EventArgs e)
        {
            pnGroupNhom.Enabled = chkHienThiNhom.Checked;
        }

        private void btnLayCauHinhMacDinh_Click(object sender, EventArgs e)
        {
            if (cboCaiDatHienThi.SelectedIndex > -1)
            {
                var loaiHienThi = cboCaiDatHienThi.SelectedValue.ToString();
                if (loaiHienThi.Equals(HienthiConstants.LuoiKQThuongQui))
                {
                    var uc = new AppCode.ucKetQuaThuongQuy();
                    foreach (GridColumn item in uc.gvKetQua.Columns)
                    {
                        _sysConfig.InsertThongTinHienThi(
                            new HienThiModel
                            {
                                Idloaihienthi = loaiHienThi,
                                Idhienthi = item.Name,
                                Dorong = item.Width,
                                Hienthi = item.Visible,
                                Mota = item.Caption,
                                Sapxep = item.VisibleIndex,
                                ChiThem = chkChiThemCauHinh.Checked
                            });
                    }
                }
                else if (loaiHienThi.Equals(HienthiConstants.LuoiThongTinNhom))
                {
                    var uc = new AppCode.ucKetQuaThuongQuy();
                    foreach (GridColumn item in uc.gvNhomCLS.Columns)
                    {
                        _sysConfig.InsertThongTinHienThi(
                            new HienThiModel
                            {
                                Idloaihienthi = loaiHienThi,
                                Idhienthi = item.Name,
                                Dorong = item.Width,
                                Hienthi = item.Visible,
                                Mota = item.Caption,
                                Sapxep = item.VisibleIndex,
                                ChiThem = chkChiThemCauHinh.Checked
                            });
                    }
                }
                else if (loaiHienThi.Equals(HienthiConstants.LuoiThongTinBoPhan))
                {
                    var uc = new AppCode.ucKetQuaThuongQuy();
                    foreach (GridColumn item in uc.gvBoPhan.Columns)
                    {
                        _sysConfig.InsertThongTinHienThi(
                            new HienThiModel
                            {
                                Idloaihienthi = loaiHienThi,
                                Idhienthi = item.Name,
                                Dorong = item.Width,
                                Hienthi = item.Visible,
                                Mota = item.Caption,
                                Sapxep = item.VisibleIndex,
                                ChiThem = chkChiThemCauHinh.Checked
                            });
                    }
                }
                else if (loaiHienThi.Equals(HienthiConstants.ThongTinBenhNhan))
                {
                    var uc = new AppCode.ucPatientInformation();
                    var dataConfig = uc.DataShowConfig();
                    foreach (DataRow drInfo in dataConfig.Rows)
                    {
                        _sysConfig.InsertThongTinHienThi(
                            new HienThiModel
                            {
                                Idloaihienthi = loaiHienThi,
                                Idhienthi = drInfo["Idhienthi"].ToString(),
                                Dorong = int.Parse(drInfo["Dorong"].ToString()),
                                Hienthi = bool.Parse(drInfo["Hienthi"].ToString()),
                                Mota = drInfo["Mota"].ToString(),
                                Sapxep = int.Parse(drInfo["Sapxep"].ToString()),
                                ChiThem = chkChiThemCauHinh.Checked
                            });
                    }
                }
                else if (loaiHienThi.Equals(HienthiConstants.DanhSachBNKQXetNghiem))
                {
                    var uc = new AppCode.ucDanhSachBenhNhanXN();
                    foreach (GridColumn item in uc.gvDanhSach.Columns)
                    {
                        _sysConfig.InsertThongTinHienThi(
                            new HienThiModel
                            {
                                Idloaihienthi = loaiHienThi,
                                Idhienthi = item.Name,
                                Dorong = item.Width,
                                Hienthi = item.Visible,
                                Mota = item.Caption,
                                Sapxep = item.VisibleIndex,
                                ChiThem = chkChiThemCauHinh.Checked
                            });
                    }
                }
                //else if (loaiHienThi.Equals(HienthiConstants.DanhSachBNLayMau))
                //{
                //    var uc = new DailyUse.BenhNhan.FrmLayMau();
                //    foreach (GridColumn item in uc.gvDanhSach.Columns)
                //    {
                //        _sysConfig.InsertThongTinHienThi(
                //            new HienThiModel
                //            {
                //                Idloaihienthi = loaiHienThi,
                //                Idhienthi = item.Name,
                //                Dorong = item.Width,
                //                Hienthi = item.Visible,
                //                Mota = item.Caption,
                //                Sapxep = item.VisibleIndex,
                //                ChiThem = chkChiThemCauHinh.Checked
                //            });
                //    }
                //}
                else if (loaiHienThi.Equals(HienthiConstants.DanhSachBNNhanMau))
                {
                    var uc = new DailyUse.CanLamSang.FrmCLSXetNghiem_DuyetNhanMau();
                    foreach (GridColumn item in uc.gvDanhSach.Columns)
                    {
                        _sysConfig.InsertThongTinHienThi(
                            new HienThiModel
                            {
                                Idloaihienthi = loaiHienThi,
                                Idhienthi = item.Name,
                                Dorong = item.Width,
                                Hienthi = item.Visible,
                                Mota = item.Caption,
                                Sapxep = item.VisibleIndex,
                                ChiThem = chkChiThemCauHinh.Checked
                            });
                    }
                }
                DanhSachCauHinh();
            }
        }
        private void LoaDanhSachLoaiHienThi()
        {
            var bs = new BindingSource();
            bs.DataSource = HienthiConstants.HienthiConstantList;
            cboCaiDatHienThi.DataSource = bs;
            cboCaiDatHienThi.ValueMember = "Key";
            cboCaiDatHienThi.DisplayMember = "Value";
            cboCaiDatHienThi.SelectedIndex = -1;
            cboCaiDatHienThi.SelectedIndexChanged += CboCaiDatHienThi_SelectedIndexChanged;
        }

        private void CboCaiDatHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            DanhSachCauHinh();
        }

        private void DanhSachCauHinh()
        {
            if (cboCaiDatHienThi.SelectedIndex > -1)
            {
                var loaiHienThi = cboCaiDatHienThi.SelectedValue.ToString();
                var dataCauHinh = _sysConfig.DataThongTinHienThi(loaiHienThi, string.Empty);
                ControlExtension.BindDataToGrid(dataCauHinh, ref dtgCauHinhHienTai, ref bvDSCauHinhHienThi);
            }
            else
            {
                dtgCauHinhHienTai.DataSource = null;
                bvDSCauHinhHienThi.BindingSource = null;
            }
        }

        private void dtgCauHinhHienTai_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >-1)
            {
                _sysConfig.UpdateThongTinHienThi(
                    new HienThiModel
                    {
                        Idloaihienthi = dtgCauHinhHienTai[colIdLoai.Name,e.RowIndex].Value.ToString(),
                        Idhienthi = dtgCauHinhHienTai[colIdhienthi.Name, e.RowIndex].Value.ToString(),
                        Dorong = int.Parse(dtgCauHinhHienTai[colDoRong.Name, e.RowIndex].Value.ToString()),
                        Hienthi = bool.Parse(dtgCauHinhHienTai[colChoPhepHienTh.Name, e.RowIndex].Value.ToString()),
                        Mota = dtgCauHinhHienTai[coltenHienThi.Name, e.RowIndex].Value.ToString(),
                        Sapxep = int.Parse(dtgCauHinhHienTai[colSapXepHienThi.Name, e.RowIndex].Value.ToString())
                    });
            }
        }

        private void pnMauCanhBao_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauCanhBao.BackColor = colorPick.Color;
            }
        }

        private void pnMauChuaKetQua_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauChuaKetQua.BackColor = colorPick.Color;
            }
        }

        private void pnMauDaCoKQ_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauDaCoKQ.BackColor = colorPick.Color;
            }
        }

        private void pnMauDuKQ_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauDuKQ.BackColor = colorPick.Color;
            }

        }
        private void pnMauDaDuyet_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauDaDuyet.BackColor = colorPick.Color;
            }
        }

        private void pnMauDaInKQ_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauDaInKQ.BackColor = colorPick.Color;
            }
        }

        private void btnCauHinhImportExcel_Click(object sender, EventArgs e)
        {
            var f = new FrmCauHinhImport();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
        }

        private void btnBrowseDuongDanCanhBao_Click(object sender, EventArgs e)
        {
            var dialog = WorkingServices.FolderBrowseDiaglog();
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtDuongDanAmThanhCanhBao.Text = dialog.SelectedPath;
            }
        }
        private void chkModuleSangLoc_CheckedChanged(object sender, EventArgs e)
        {
            btnCauHinhImportExcel.Visible = chkModuleSangLoc.Checked;
        }
        private void frmCauHinh_CaiDatHeThong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.M)
            {
                var f = new FrmPasswordActiveModule();
                f.ShowDialog();
                gbModule.Enabled = f.Accept;

                chkModulehuyetTuyeDo.AutoCheck = chkModuleSangLoc.AutoCheck = chkModuleSHPT.AutoCheck = chkModuleThuongQuy.AutoCheck = chkModuleVSNuoiCay.AutoCheck = f.Accept;

            }
        }

        private void btnCaiDatChung_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedIndex = 0;
            HightLightButton((Button)sender);
        }

        private void btnXetNghiem1_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedIndex = 1;
            HightLightButton((Button)sender);
        }

        private void btnXetNghiem2_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedIndex = 2;
            HightLightButton((Button)sender);
        }

        private void btnSieuAm_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedIndex = 3;
            HightLightButton((Button)sender);
        }

        private void btnNoiSoi_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedIndex = 4;
            HightLightButton((Button)sender);
        }

        private void btnDienTim_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedIndex = 5;
            HightLightButton((Button)sender);
        }

        private void pnMautrongKhoanBaoDong_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMautrongKhoanBaoDong.BackColor = colorPick.Color;
            }
        }

        private void pnMauNgoaiKhoangBaoDong_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauNgoaiKhoangBaoDong.BackColor = colorPick.Color;
            }
        }

        private void btnXOaCauHinhHienThi_Click(object sender, EventArgs e)
        {
            if (cboCaiDatHienThi.SelectedIndex > -1)
            {
                var loaiHienThi = cboCaiDatHienThi.SelectedValue.ToString();
                _sysConfig.DeleteThongTinHienThi(loaiHienThi, string.Empty);
                DanhSachCauHinh();
            }
        }
        private void pnChonMau(Panel sender)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                sender.BackColor = colorPick.Color;
            }
        }

        private void pnDuyetMau_ChuaThucHien_Click(object sender, EventArgs e)
        {
            pnChonMau((Panel)sender);
        }

        private void btnKySo_Click(object sender, EventArgs e)
        {
            tabConfig.SelectedTab = TabKySo;
            HightLightButton((Button)sender);
        }
    }
}
