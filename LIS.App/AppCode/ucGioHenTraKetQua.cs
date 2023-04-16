using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.User.Constants;
using TPH.LIS.Patient.Services;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Extensions;
using TPH.LIS.TestResult.Services;
using TPH.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using DevExpress.XtraReports.UI;
using TPH.Report.Services;
using TPH.Report.Services.Impl;
using TPH.LIS.Common;
using TPH.Report.Constants;
using TPH.Report.Models;

namespace TPH.LIS.App.AppCode
{
    public partial class ucGioHenTraKetQua : UserControl
    {
        public ucGioHenTraKetQua()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ITestResultService _iTestResult = new TestResultService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private Image logo;
        private static XtraReport ticketReport;
        private static ReportModel resultReportInfo;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        public bool UseFind
        {
            get { return pnFind.Visible; }
            set { pnFind.Visible = value; }
        }
        public bool ChoPhepTim
        {
            get { return pnSearch.Visible; }
            set { pnSearch.Visible = value; }
        }
        public int SoTTLayMau = 0;
        public DateTime? ThoiGianLayMau;
        public bool InGioHen = false;
        public DataTable DataReturn = new DataTable();
        private void btnXemDanhSach_Click(object sender, EventArgs e)
        {
            SoTTLayMau = 0;
            ThoiGianLayMau = null;
            Load_DanhSachHenTraKetQua(false, string.Empty, txtSoHoSo.Text, (string.IsNullOrEmpty(txtSoHoSo.Text) ? (DateTime?)null : dtpNgayTiepNhan.Value.Date), txtBarcode.Text);
        }
        public void ClearDanhSach()
        {
            gcDanhSach.DataSource = null;
        }
        public void Load_DanhSachHenTraKetQua(bool fromAuto, string maTiepNhan, string soHoSo, DateTime? ngayTiepnhan, string barcode)
        {
            gcDanhSach.DataSource = null;
            if (fromAuto)
            {
                txtSoHoSo.Text = soHoSo;
                txtBarcode.Text = barcode;
                if (ngayTiepnhan != null)
                    dtpNgayTiepNhan.Value = ngayTiepnhan.Value;
            }
            if (string.IsNullOrEmpty(maTiepNhan) && string.IsNullOrEmpty(barcode) && string.IsNullOrEmpty(soHoSo))
            {
                return;
            }
            DataReturn = _iPatient.Calculate_TraKetQua(maTiepNhan, soHoSo, ngayTiepnhan, barcode
                , CommonAppVarsAndFunctions.sysConfig.GioLamViecSang
                , CommonAppVarsAndFunctions.sysConfig.GioNghiTrua
                , CommonAppVarsAndFunctions.sysConfig.GioLamViecChieu
                , CommonAppVarsAndFunctions.sysConfig.GioNghiChieu
                , CommonAppVarsAndFunctions.sysConfig.NghiCuoiTuan
                , new User.Enum.ServiceType[] { User.Enum.ServiceType.ClsXetNghiem }, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHenTheoXetNghiem);
            DataReturn.DefaultView.Sort = "BanLayMau, Seq, GioTraKQ ASC";
            DataReturn = DataReturn.DefaultView.ToTable(true,
                new string[]{ "Seq", "BanLayMau", "TenNhom", "GioTraKQ", "SoHoSo"
                , "ThoiGianLayMau", "MaBoPhan", "TenBoPhan", "Barcode","Logo","XetNghiem","HenTraKQ","MaTiepNhan","TenBN"
                ,"TenNguoiLayMau","MaNhom","SapXep","ThuTuIn"
                ,"ThoiGianCoKetQua","BacSiCD","GioiTinh"
                ,"SoBHYT","MaBN","ChanDoan","DiaChi"
                ,"Tuoi","SoTuoi","CoNgaySinh","SinhNhat","TenBSChiDinh","TenKhoaPhong","XNGui","LoaiXetNghiem","NoiHenTra"
                ,"DSTenNhomNghiem","DSMaNhomNghiem","TenKhuLayMau","TraQuangay"});
            DataReturn.Columns.Add("NgayHen", typeof(DateTime));
            foreach (DataRow dr in DataReturn.Rows)
            {
                dr["NgayHen"] = (string.IsNullOrEmpty(dr["GioTraKQ"].ToString())) ? DateTime.Now.Date : DateTime.Parse(dr["GioTraKQ"].ToString()).Date;
            }
            gcDanhSach.DataSource = DataReturn;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemHenTheoXetNghiem)
            {
                colDanhSach_TenNhomCLS.GroupIndex = -1;
                colDanhSach_TenNhomCLS.VisibleIndex = 1;
                colDanhSach_TenNhomCLS.Caption = "Xét nghiệm";
            }
            else
            {
                colDanhSach_TenNhomCLS.GroupIndex = 2;
                colDanhSach_TenNhomCLS.Caption = "Nhóm";
            }
            gvDanhSach.ExpandAllGroups();
        }

        private DataTable SetNoiHenTraKQ(DataTable dataIn, string noihentra)
        {
            foreach (DataRow dr in dataIn.Rows)
            {
                dr["NoiHenTra"] = noihentra;
            }
            return dataIn;
        }
        public void LoadCauHinh()
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterReturnResultTime, false);
            logo = _iSysConfig.Load_Logo("XN");
            listPrinter.SelectedItem = _registryExtension.ReadRegistry(UserConstant.RegistryPrinterReturnResultTime);
            listPrinter.SelectedIndexChanged += listPrinter_SelectedIndexChanged;
            var copy = WorkingServices.ValueString_Int_Zero(_registryExtension.ReadRegistry(UserConstant.RegistryCopyOfReturnResultTime));
            numCopy.Value = (copy < 1 ? 1 : copy);
            numCopy.ValueChanged += NumCopy_ValueChanged;
        }
        private void NumCopy_ValueChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                       UserConstant.RegistryCopyOfReturnResultTime,
                       numCopy.Value.ToString());
        }
        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterReturnResultTime, true);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            InPhieuHen(false);
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            InPhieuHen(true);
        }
        public void InPhieuHen(bool preview)
        {
            if (gvDanhSach.RowCount <= 0) return;
            var dtPrint = (DataTable)gcDanhSach.DataSource;
            dtPrint.AcceptChanges();
            if (dtPrint.Rows.Count == 0) return;

            if (ThoiGianLayMau != null)
            {
                dtPrint = WorkingServices.SearchResult_OnDatatable(dtPrint, string.Format("ThoiGianLayMau >= '{0}'", ThoiGianLayMau.Value));
            }
            if (dtPrint.Rows.Count == 0) return;
            var ic = new ImageConverter();
            var barcode =
                (byte[])
                    ic.ConvertTo(
                        Code128Rendering.MakeBarcodeImage(dtPrint.Rows[0]["SoHoSo"].ToString().Trim(), 1, true),
                        typeof(byte[]));
            var logoAdd = GraphicSupport.ImageToByteArray(logo);
            if (!dtPrint.Columns.Contains("SoTT"))
            {
                dtPrint.Columns.Add("SoTT", typeof(int));
            }
            foreach (DataRow dr in dtPrint.Rows)
            {
                dr["barcode"] = barcode;
                dr["Logo"] = logoAdd;
                dr["SoTT"] = SoTTLayMau;
            }

            if (resultReportInfo == null)
            {
                resultReportInfo = _reportInfo.Info_Report(ReportConstants.PhieuHen);
            }

            if (resultReportInfo.ReportSuDung == null)
                return;

            var dataRealPrint = WorkingServices.SearchResult_OnDatatable_NoneSort(dtPrint, "HenTraKQ = true");
            var havePrint = false;
            if (dataRealPrint.Rows.Count > 0)
            {
                var coTienSan = false;
                var coGuiMau = false;
                var ngaytraTienSan = DateTime.MinValue;
                var ngaytraGuiMau = DateTime.MinValue;
                var SFLT1 = false;
                var ngaySFLT1 = DateTime.MinValue;
                var PLGF = false;
                var ngayPLGF = DateTime.MinValue;
                var tQ = false;
                var ngaytQ = DateTime.MinValue;
                LayCacCoLoaiXN(dataRealPrint, ref coTienSan, ref coGuiMau
                    , ref ngaytraTienSan, ref ngaytraGuiMau, ref SFLT1, ref ngaySFLT1, ref PLGF, ref ngayPLGF, ref tQ, ref ngaytQ);

                var ruleTienSan = false;
                var gioRuleTienSan = ngaytraTienSan;
                var ruleTQ = false;
                var gioRuleTQ = ngaytQ;
                var ruleGuiMau = false;
                var gioRuleGuimau = ngaytraGuiMau;
                //    //Kiểm tra chỉ có tiển sản hoặc ts + plgf và có bs chỉ định thì trả về phòng 26
                //    var dataTienSan = WorkingServices.SearchResult_OnDatatable(dataRealPrint, string.Format("LoaiXetNghiem = {0}", (int)TestType.EnumTestType.TienSan));
                //    if (dataTienSan.Rows.Count > 0 && !string.IsNullOrEmpty(dataRealPrint.Rows[0]["BacSiCD"].ToString()))
                //    {
                //        foreach (DataRow dr in dataRealPrint.Rows)
                //        {
                //            dr["NoiHenTra"] = "Phòng 26";
                //        }
                //    }

                //    if (PLGF && !SFLT1)
                //    {
                //        ruleTienSan = true;
                //        if (coTienSan && ngaytraTienSan > ngayPLGF)
                //            gioRuleTienSan = ngaytraTienSan;
                //        else
                //            gioRuleTienSan = ngayPLGF;

                //        foreach (DataRow dr in dataRealPrint.Rows)
                //        {
                //            var loaiNX = int.Parse(dr["LoaiXetNghiem"].ToString());
                //            if(loaiNX == (int)TestType.EnumTestType.PLGF ||  loaiNX == (int)TestType.EnumTestType.TienSan)
                //            {
                //                dr["LoaiXetNghiem"] = (int)TestType.EnumTestType.TienSan;
                //                dr["GioTraKQ"] = gioRuleTienSan;
                //            }
                //        }
                //    }
                //    else if (PLGF && SFLT1)
                //    {
                //        gioRuleTQ = (ngayPLGF < ngaySFLT1 ? ngaySFLT1 : ngayPLGF);
                //        gioRuleTQ = (gioRuleTQ < ngaytQ ? ngaytQ : ngaytQ);

                //        foreach (DataRow dr in dataRealPrint.Rows)
                //        {
                //            var loaiNX = int.Parse(dr["LoaiXetNghiem"].ToString());
                //            if (loaiNX == (int)TestType.EnumTestType.PLGF || loaiNX == (int)TestType.EnumTestType.SFLT1)
                //            {
                //                dr["LoaiXetNghiem"] = (int)TestType.EnumTestType.ThongThuong;
                //                dr["GioTraKQ"] = gioRuleTQ;
                //            }
                //        }
                //    }

                //    if (gioRuleTienSan > gioRuleGuimau && gioRuleTienSan > gioRuleTQ
                //        && (gioRuleGuimau > gioRuleTQ || gioRuleGuimau == DateTime.MinValue))
                //    {
                //        //Lấy theo giờ tiền sản vỉ giờ tiền sản đang lớn nhất nên đưa vào phiếu in sẽ lấy theo giờ tiền sản
                //        var dataFinal = XuLyNoiHen(dataRealPrint);
                //        dataFinal.DefaultView.Sort = "GioTraKQ asc";
                //        dataFinal = dataFinal.DefaultView.ToTable();
                //        var hPrint = InPhieu(dataFinal, preview);
                //        if (!havePrint)
                //            havePrint = hPrint;
                //    }
                //    else if (gioRuleTienSan < gioRuleGuimau && gioRuleTienSan > gioRuleTQ)
                //    {
                //        //tách tiền sản ra riêng
                //        var dataSan = WorkingServices.SearchResult_OnDatatable_NoneSort(dataRealPrint
                //                      , string.Format("LoaiXetNghiem in ({0})", (int)TestType.EnumTestType.TienSan));
                //        if (dataSan.Rows.Count > 0)
                //        {
                //            var dataFinal = XuLyNoiHen(dataSan);
                //            dataFinal.DefaultView.Sort = "GioTraKQ asc";
                //            dataFinal = dataFinal.DefaultView.ToTable();
                //            var hPrint = InPhieu(dataFinal, preview);
                //            if (!havePrint)
                //                havePrint = hPrint;
                //        }

                //        var dataTQ = WorkingServices.SearchResult_OnDatatable_NoneSort(dataRealPrint
                //                          , string.Format("LoaiXetNghiem not in ({0})", (int)TestType.EnumTestType.TienSan));
                //        if (dataTQ.Rows.Count > 0)
                //        {
                //            var dataFinal = XuLyNoiHen(dataTQ);
                //            dataFinal.DefaultView.Sort = "GioTraKQ asc";
                //            dataFinal = dataFinal.DefaultView.ToTable();
                //            var hPrint = InPhieu(dataFinal, preview);
                //            if (!havePrint)
                //                havePrint = hPrint;
                //        }
                //    }
                //    else
                //    {
                //        var dataFinal = XuLyNoiHen(dataRealPrint);
                //        dataFinal.DefaultView.Sort = "GioTraKQ asc";
                //        dataFinal = dataFinal.DefaultView.ToTable();
                //        var hPrint = InPhieu(dataFinal, preview);
                //        if (!havePrint)
                //            havePrint = hPrint;
                //    }
                //}
                //else
                //    havePrint = true;


                dataRealPrint.DefaultView.Sort = "GioTraKQ asc";
                dataRealPrint = dataRealPrint.DefaultView.ToTable();
                var hPrint = InPhieu(dataRealPrint, preview);
                if (!havePrint)
                    havePrint = hPrint;
            }
            //#endregion

            if (!havePrint) return;
            Check_Update_HenTraKetQua(dtPrint);
            var lstMatiepnhan = new List<string>();
            foreach (DataRow drM in dtPrint.Rows)
            {
                if (!lstMatiepnhan.Contains(drM["MaTiepNhan"].ToString()))
                    lstMatiepnhan.Add(drM["MaTiepNhan"].ToString());
            }
        }
        private void LayCacCoLoaiXN(DataTable dataIn, ref bool coTienSan, ref bool coGuiMau
            , ref DateTime ngaytraTienSan, ref DateTime ngaytraGuiMau, ref bool SFLT1
            , ref DateTime ngaySFLT1, ref bool PLGF, ref DateTime ngayPLGF
            , ref bool tQ, ref DateTime ngaytQ)
        {
            coTienSan = false;
            coGuiMau = false;
            ngaytraTienSan = DateTime.MinValue;
            ngaytraGuiMau = DateTime.MinValue;
            SFLT1 = false;
            ngaySFLT1 = DateTime.MinValue;
            PLGF = false;
            ngayPLGF = DateTime.MinValue;
            tQ = false;
            ngaytQ = DateTime.MinValue;
            dataIn.DefaultView.Sort = "LoaiXetNghiem,XNGui,GioTraKQ asc ";
            dataIn = dataIn.DefaultView.ToTable();
            foreach (DataRow drL in dataIn.Rows)
            {
                var loaiXn = drL["LoaiXetNghiem"].ToString();
                if (int.Parse(loaiXn) == (int)TestType.EnumTestType.TienSan)
                {
                    coTienSan = true;
                    ngaytraTienSan = DateTime.Parse(drL["GioTraKQ"].ToString());
                }
                else if (int.Parse(loaiXn) == (int)TestType.EnumTestType.SFLT1)
                {
                    SFLT1 = true;
                    ngaySFLT1 = DateTime.Parse(drL["GioTraKQ"].ToString());
                }
                else if (int.Parse(loaiXn) == (int)TestType.EnumTestType.PLGF)
                {
                    PLGF = true;
                    ngayPLGF = DateTime.Parse(drL["GioTraKQ"].ToString());
                }
                else if (bool.Parse(drL["XNGui"].ToString()))
                {
                    coGuiMau = true;
                    ngaytraGuiMau = DateTime.Parse(drL["GioTraKQ"].ToString());
                }
                else
                {
                    tQ = true;
                    ngaytQ = DateTime.Parse(drL["GioTraKQ"].ToString());
                }
            }
        }
        private DataTable XuLyNoiHen(DataTable dataIn)
        {
            var lstLoaiXn = new List<TestType.EnumTestType>();
            var distinctLoaiXn = dataIn.DefaultView.ToTable(true, "LoaiXetNghiem");
            foreach (DataRow drL in distinctLoaiXn.Rows)
            {
                lstLoaiXn.Add((TestType.EnumTestType)Enum.Parse(typeof(TestType.EnumTestType), drL["LoaiXetNghiem"].ToString()));
            }
            var maBSCD = dataIn.Rows[0]["BacSiCD"].ToString();
            var xnGui = false;
            foreach (DataRow drG in dataIn.Rows)
            {
                if (bool.Parse(drG["XNGui"].ToString()))
                {
                    xnGui = true;
                    break;
                }
            }
            if (lstLoaiXn.Count == 1)
            {
                if (lstLoaiXn.Contains(TestType.EnumTestType.TienSan) && xnGui == false)
                {
                    if (string.IsNullOrEmpty(maBSCD))
                    {
                        dataIn = SetNoiHenTraKQ(dataIn, "Phòng 07");
                    }
                    else
                    {
                        dataIn = SetNoiHenTraKQ(dataIn, "Phòng 26");
                    }
                }
            }
            else if (lstLoaiXn.Contains(TestType.EnumTestType.NIPT))
            {
                if (string.IsNullOrEmpty(maBSCD))
                {
                    dataIn = SetNoiHenTraKQ(dataIn, "Phòng 07");
                }
                else
                {
                    dataIn = SetNoiHenTraKQ(dataIn, "Phòng 26");
                }
            }
            return dataIn;
        }
        private bool InPhieu(DataTable dataRealPrint, bool preview)
        {
            var crv = new FrmPreViewReport();
            crv.SampleID = string.Format("PhieuHenKQXN_SHS{0}", (string.IsNullOrEmpty(dataRealPrint.Rows[0]["SoHoSo"].ToString().Trim()) ? dataRealPrint.Rows[0]["Seq"].ToString().Trim() : dataRealPrint.Rows[0]["SoHoSo"].ToString().Trim()));
            crv.TenBN = dataRealPrint.Rows[0]["TenBN"].ToString().Trim();
            crv.SoTTLayMau = SoTTLayMau;
            crv.InGiohen = !InGioHen;
            var printerName = string.Empty;
            if (listPrinter.Items.Count > 0)
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }
                printerName = listPrinter.SelectedItem.ToString();
            }
            var havePrint = false;
            var dataNoitra = dataRealPrint.DefaultView.ToTable(true, "NoiHenTra");
            foreach (DataRow dr in dataNoitra.Rows)
            {
                var data = WorkingServices.SearchResult_OnDatatable_NoneSort(dataRealPrint, string.Format("NoiHenTra = '{0}'", dr["NoiHenTra"]));

                //Lấy tất các các nhóm XN
                var lstNhom = new List<string>();
                var lstMaNhom = new List<string>();
                foreach (DataRow drI in data.Rows)
                {
                    if (!lstMaNhom.Contains(drI["MaNhom"].ToString()))
                    {
                        lstMaNhom.Add(drI["MaNhom"].ToString());
                        lstNhom.Add(drI["TenNhom"].ToString());
                    }
                }
                var strTenNhom = string.Join(",", lstNhom);
                var strMaNhom = string.Join(",", lstMaNhom);
                foreach (DataRow drN in data.Rows)
                {
                    drN["DSTenNhomNghiem"] = strTenNhom;
                    drN["DSMaNhomNghiem"] = strMaNhom;
                }
                ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                var print = crv.ShowReport(ticketReport, data, !preview, printerName, "XN", resultReportInfo.TenDataset, resultReportInfo.TenDatatable
                    , copy: (int)numCopy.Value);
                if (!havePrint)
                    havePrint = print;
            }
            return havePrint;
        }
        public void Check_Update_HenTraKetQua(DataTable dtPrint)
        {
            //Cập nhật cho cả nhóm trước khi cập nhật từng test
            var dt = WorkingServices.SearchResult_OnDatatable_NoneSort(dtPrint, "XetNghiem = false");
            if (dt.Rows.Count > 0)
                Update_henTraKQ(dt);

            dt = WorkingServices.SearchResult_OnDatatable_NoneSort(dtPrint, "XetNghiem = true");
            if (dt.Rows.Count > 0)
                Update_henTraKQ(dt);
        }
        private void Update_henTraKQ(DataTable dtPrint)
        {
            foreach (DataRow dr in dtPrint.Rows)
            {
                if (!string.IsNullOrEmpty(dr["GioTraKQ"].ToString()))
                {
                    var thoiGianCoKetqua = dr["ThoiGianCoKetQua"].ToString();
                    string matiepNhan = dr["MaTiepNhan"].ToString();
                    string maNhom = dr["MaNhom"].ToString();
                    var tgtra = DateTime.Parse(dr["GioTraKQ"].ToString());
                    var isXetNghiem = bool.Parse(dr["XetNghiem"].ToString());
                    string gioTra = string.Format("Trả KQ: {0}", tgtra.ToString("HH:mm dd/MM/yyyy"));
                    _iTestResult.CapNhat_GhiChuHenTraKQ(matiepNhan, (isXetNghiem ? maNhom : string.Empty)
                        , (isXetNghiem ? string.Empty : maNhom), true, gioTra, tgtra, thoiGianCoKetqua);
                }
            }
        }

        private void txtSoHoSo_TextChanged(object sender, EventArgs e)
        {
            txtBarcode.Text = string.Empty;
        }

        private void txtSoHoSo_Enter(object sender, EventArgs e)
        {
            txtSoHoSo.SelectAll();
        }

        private void txtSoHoSo_Click(object sender, EventArgs e)
        {
            txtSoHoSo.SelectAll();
        }

        private void txtSoHoSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtSoHoSo.Text))
                {
                    btnXemDanhSach_Click(sender, e);
                    e.Handled = true;
                }
            }
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            txtSoHoSo.Text = string.Empty;
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtBarcode.Text))
                {
                    btnXemDanhSach_Click(sender, e);
                    e.Handled = true;
                }
            }
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count > 0)
            {
                _registryExtension.WriteRegistry(
                    UserConstant.RegistryPrinterReturnResultTime,
                    listPrinter.SelectedItem.ToString());
            }
        }
    }
}
