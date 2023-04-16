using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using TPH.Common.Extensions;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Constants;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.WriteLog;
using TPH.LIS.TestResult.Model;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucInTuDong : UserControl
    {
        public ucInTuDong()
        {
            InitializeComponent();
            pnCHonKyTen.BackColor = TPH.Controls.CommonAppColors.ColorMainAppColor;
            label46.ForeColor = TPH.Controls.CommonAppColors.ColorTextCaption;
        }

        private const string PrinterReg = "PrinterAutoPrintNormal";
        private const string PrinterShareJob = "PrinterAutoPrintShareJob";
        private const string AutoPrintTimer = "AutoPrintTimer";
        private const string AutoPrintOnlyCategoryValid = "AutoPrintOnlyCategoryValid";
        private const string AutoPrintWithUserValid = "AutoPrintWithUserValid";
        private int _lastIndexPrinter = -1;
        private string _listKhoaChiDinh = string.Empty;
        private string _listKhoaHienThoi = string.Empty;
        private string _listKhuDieuTri = string.Empty;
        private string _listDoiTuong = string.Empty;
        private string _listBoPhan = string.Empty;
        private string _listNhom = string.Empty;
        private readonly  ITestResultService _iResultService = new TestResultService();
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private DieuKienInTuDong _dieuKienIn = new DieuKienInTuDong();
        public delegate void PrintResult(string matiepnhan, bool title, string userSign, bool showMess
            , bool inCoQuiDoi, string printerName, bool inMau, bool chiInCoKetQua, DataTable dataReportType
            , ToolStripProgressBar progressPrint, bool userValidTheoUserDangNhap);
        public event PrintResult printResult;
        public string TrangThai { get; set; }
        bool workingPrint = false;
        public bool SuDungKhoaHienThoi
        {
            set { spliKhoaPhong.Panel2Collapsed = !value; }
            get { return !spliKhoaPhong.Panel2Collapsed; }
        }
        public void SetDateForForm(DateTime currentDate)
        {
            var days = (dtpToDate.Value - dtpFromDate.Value).Days;
            dtpFromDate.Value = WorkingServices.StartOfDay(currentDate.AddDays(-days));
            dtpToDate.Value = WorkingServices.EndOfDay(currentDate);
        }
        public string UserSign
        {
            get { return cboNguoiKyTen.SelectedIndex > -1 ? cboNguoiKyTen.SelectedValue.ToString() : string.Empty; }
            set { cboNguoiKyTen.SelectedValue = value; }
        }
        public string UserLogin { get; set; }
        private void LayKhoaChiDinh()
        {
            _listKhoaChiDinh = string.Empty;
            if (gvKhoaChiDinh.SelectedRowsCount <= 0) return;
            foreach (var i in gvKhoaChiDinh.GetSelectedRows())
            {
                if (gvKhoaChiDinh.GetRowCellValue(i, colMaKhoaChiDinh) == null) continue;
                _listKhoaChiDinh += string.IsNullOrEmpty(_listKhoaChiDinh) ? "" : ",";
                _listKhoaChiDinh += gvKhoaChiDinh.GetRowCellValue(i, colMaKhoaChiDinh).ToString();
            }
        }
        private void LayKhoaHienThoi()
        {
            _listKhoaHienThoi = string.Empty;
            if (gvKhoaHienThoi.SelectedRowsCount <= 0) return;
            foreach (var i in gvKhoaHienThoi.GetSelectedRows())
            {
                if (gvKhoaHienThoi.GetRowCellValue(i, colMaKhoaHienThoi) == null) continue;
                _listKhoaHienThoi += string.IsNullOrEmpty(_listKhoaHienThoi) ? "" : ",";
                _listKhoaHienThoi += gvKhoaHienThoi.GetRowCellValue(i, colMaKhoaHienThoi).ToString();
            }
        }
        private void LayDoiTuong()
        {
            _listDoiTuong = string.Empty;
            if (gvDoiTuong.SelectedRowsCount <= 0) return;
            foreach (var i in gvDoiTuong.GetSelectedRows())
            {
                if (gvDoiTuong.GetRowCellValue(i, colDoiTuong_MaDoiTuong) == null) continue;
                _listDoiTuong += string.IsNullOrEmpty(_listDoiTuong) ? "" : ",";
                _listDoiTuong += gvDoiTuong.GetRowCellValue(i, colDoiTuong_MaDoiTuong).ToString();
            }
        }
        public void Load_Config(string lisBophanAllow, string lisNhomAllow, DataTable dataUserkyten)
        {
            _listBoPhan = lisBophanAllow;
            _listNhom = lisNhomAllow;

            ControlExtension.BindDataToCobobox(dataUserkyten, ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen, 1);
            cboNguoiKyTen.SelectedValue = UserSign;
            var dataBoPhan = _sysConfig.Data_dm_bophan(string.Empty, string.Empty);
            gcKhuVuc.DataSource = dataBoPhan;
            var dataDoiTuong = _sysConfig.Get_DoiTuongDichVu(string.Empty);
            gcDoiTuong.DataSource = dataDoiTuong;
            Task.Factory.StartNew(delegate { ControlExtension.LoadPrinterNameNormal(listPrinter, PrinterReg, true); });
        
            chkChiaTaiMayIn.Checked = _registryExtension.ReadRegistry(PrinterShareJob) == "1";
            chkChiaTaiMayIn.CheckedChanged += ChkChiaTaiMayIn_CheckedChanged;

            radXacNhanTheoNhom.Checked = _registryExtension.ReadRegistry(AutoPrintOnlyCategoryValid) == "1";
            radXacNhanTheoNhom.CheckedChanged += RadXacNhanTheoNhom_CheckedChanged;

            chkInTheoUserDangDuyet.Checked = _registryExtension.ReadRegistry(AutoPrintWithUserValid) == "1";
            chkInTheoUserDangDuyet.CheckedChanged += ChkInTheoUserDangDuyet_CheckedChanged;
            txtThoiGianScan.Text = _registryExtension.ReadRegistry(AutoPrintTimer);
            txtThoiGianScan.TextChanged += TxtThoiGianScan_TextChanged;
            txtThoiGianScan.Text = string.IsNullOrEmpty(txtThoiGianScan.Text) ? "10" : txtThoiGianScan.Text;
        }

        private void ChkInTheoUserDangDuyet_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(AutoPrintWithUserValid, chkInTheoUserDangDuyet.Checked ? "1" : "0");
        }

        private void RadXacNhanTheoNhom_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(AutoPrintOnlyCategoryValid, radXacNhanTheoNhom.Checked ? "1" : "0");
        }
        private void Load_KhoaPhong()
        {
            if (gvKhuVuc.SelectedRowsCount > 0)
            {
                var maBophan = new List<string>();
                foreach (var item in gvKhuVuc.GetSelectedRows())
                {
                    if (gvKhuVuc.GetRowCellValue(item, colKhuVuc_maBoPhan) != null)
                    {
                        maBophan.Add(gvKhuVuc.GetRowCellValue(item, colKhuVuc_maBoPhan).ToString());
                    }
                }
                var data = _sysConfig.GetLocation( string.Empty, string.Empty, Utilities.ConvertStrinArryToInClauseSQL(maBophan, true));
                gcKhoaChiDinh.DataSource = data;
                gvKhoaChiDinh.ExpandAllGroups();
                gcKhoaHienThoi.DataSource = data.Copy();
                gvKhoaHienThoi.ExpandAllGroups();
            }
            else
            {
                gcKhoaChiDinh.DataSource = null;
                gcKhoaHienThoi.DataSource = null;
            }
        }
        private void TxtThoiGianScan_TextChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(AutoPrintTimer, txtThoiGianScan.Text);
        }

        private void ChkChiaTaiMayIn_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(PrinterShareJob, (chkChiaTaiMayIn.Checked ? "1" : "0"));
        }

        private void timerAutoPrint_Tick(object sender, EventArgs e)
        {
            if (!workingPrint)
            {
                timerAutoPrint.Stop();
                Action action = AutoPrint;
                Task.Factory.StartNew(() =>
                {
                    lblAutoPrintStatus.Invoke(action);
                });
                timerAutoPrint.Start();
            }
        }

        private void LayDieuKienIn()
        {
            _dieuKienIn =
                new DieuKienInTuDong
                {
                    XacNhanBenhNhan = chkInDaXacNhanTatCa.Checked
                    ,
                    XacNhanTheoKhoa = radXacNhanDuTheoKhoa.Checked
                    ,
                    ChiInCoKetQua = chkChiInXetNghiemCoKetQua.Checked
                    ,
                    ListKhoaChiDinh = _listKhoaChiDinh
                    ,
                    ListKhoaHienthoi = _listKhoaHienThoi
                    ,
                    ListAllowBoPhan = _listBoPhan
                    ,
                    ListAllowDoiTuong = _listDoiTuong
                    ,
                    PCName = Environment.MachineName
                    ,
                    TuNgay = dtpFromDate.Value
                    ,
                    DenNgay = dtpToDate.Value
                    ,
                    SoPhutDaKiemTra = 3
                    ,
                    DungChoCapNhat = false
                    ,
                    UserValid = (chkInTheoUserDangDuyet.Checked ? UserLogin : string.Empty)
                    ,
                    XacNhanTheoNhom = radXacNhanTheoNhom.Checked
                    ,
                    ListAllowNhom = _listNhom
                    ,
                    showMessage = false
                };
        }
        private List<PatientPrintedList> lstDSDaIn = new List<PatientPrintedList>();
        private void RemovePrintCheckedList()
        {
            if (lstDSDaIn.Count > 0)
            {
                var dateCheck = DateTime.Now.AddMinutes(-3);
                lstDSDaIn.RemoveAll(x => x.TgIn <= dateCheck);
            }
        }
        private void AddPrintCheckedList(string matiepnhan)
        {
            lstDSDaIn.Add(new PatientPrintedList { MaTiepNhan = matiepnhan, TgIn = DateTime.Now });
            lblLogLoaiTru.Invoke((Action)(() =>
            {
                lblLogLoaiTru.Text = string.Format("Loại trừ các code: {0}", string.Join(", ", lstDSDaIn.Select(x => x.MaTiepNhan).ToList()));
            }));
        }
        private bool CheckExistsPrintCheckedList(string matiepnhan)
        {
            return lstDSDaIn.Where(x => x.MaTiepNhan.Equals(matiepnhan)).Any();
        }
        private void AutoPrint()
        {
            workingPrint = true;
            lblAutoPrintStatus.Invoke((Action)(() =>
            {
                lblAutoPrintStatus.Text = "Lấy danh sách in tự động.";
            }));
            var dataInTuDong = _iResultService.DanhSachBenhNhanInTuDong(_dieuKienIn);
            if (dataInTuDong != null)
            {
                if (dataInTuDong.Rows.Count > 0)
                {
                    RemovePrintCheckedList();
                    workingPrint = true;
                    var printerName = string.Empty;
                    if (listPrinter.Items.Count > 0 && string.IsNullOrEmpty(printerName))
                    {
                        if (listPrinter.SelectedIndex == -1)
                        {
                            listPrinter.SelectedIndex = 0;
                        }

                        printerName = listPrinter.SelectedItem.ToString();

                        if (chkChiaTaiMayIn.Checked)
                        {
                            if (listPrinter.SelectedIndex < listPrinter.Items.Count - 1)
                            {
                                _lastIndexPrinter = listPrinter.SelectedIndex + 1;
                                listPrinter.SelectedIndex = _lastIndexPrinter;
                            }
                            else
                            {
                                _lastIndexPrinter = 0;
                                listPrinter.SelectedIndex = _lastIndexPrinter;
                            }
                        }
                    }
                    var userSign = cboNguoiKyTen.SelectedIndex > -1
                        ? cboNguoiKyTen.SelectedValue.ToString().Trim()
                        : string.Empty;
                    LogService.RecordLogFile("InTuDong", string.Format("Record count: {0}", dataInTuDong.Rows.Count));
                    for (var i = 0; i < dataInTuDong.Rows.Count; i++)
                    {
                        var matiepnhan = dataInTuDong.Rows[i]["MaTiepNhan"].ToString();
                        LogService.RecordLogFile("InTuDong", string.Format("Thực hiện in: {0}", matiepnhan));
                        if (CheckExistsPrintCheckedList(matiepnhan))
                        {
                            lblAutoPrintStatus.Invoke((Action) (() =>
                            {
                                lblAutoPrintStatus.Text =
                                    string.Format(
                                        $"{LanguageExtension.GetResourceValueFromValue("Mã tiếp nhận đã in lần trước in: {0}", LanguageExtension.AppLanguage)}",
                                        matiepnhan);
                            }));
                      
                            LogService.RecordLogFile("InTuDong", string.Format("Mã tiếp nhận đã in lần trước in: {0}", matiepnhan));
                        }
                        else
                        {
                            AddPrintCheckedList(matiepnhan);
                            lblAutoPrintStatus.Text = string.Format($"{LanguageExtension.GetResourceValueFromValue("Đang in: {0}", LanguageExtension.AppLanguage)}", matiepnhan);
                            var dataIdMauKq = _iResultService.DataIDMauKetQua(matiepnhan, _listBoPhan);
                            printResult?.Invoke(matiepnhan, chkPrintTitle.Checked, userSign, true, false, printerName, false,
                                    chkChiInXetNghiemCoKetQua.Checked, dataIdMauKq, new ToolStripProgressBar(), chkInTheoUserDangDuyet.Checked);
                            lblAutoPrintStatus.Invoke((Action)(() =>
                            {
                                lblAutoPrintStatus.Text = string.Format($"{LanguageExtension.GetResourceValueFromValue("Đã in: {0}", LanguageExtension.AppLanguage)}", matiepnhan);
                            }));
                          
                            LogService.RecordLogFile("InTuDong", string.Format("Hoàn tất in: {0}", matiepnhan));
                        }
                    }
                }
                else
                {
                    lblAutoPrintStatus.Invoke((Action)(() =>
                    {
                        lblAutoPrintStatus.Text =
                            LanguageExtension.GetResourceValueFromValue(
                                "Lấy danh sách in tự động. \nKhông có danh sách cần in!",
                                LanguageExtension.AppLanguage);
                    }));
                
                    //if (dtpAutoPrintDateIn.Value.Date < DateTime.Now.Date)
                    //    dtpAutoPrintDateIn.Value = dtpAutoPrintDateIn.Value.AddDays(1);
                }
            }
            else
            {
                lblAutoPrintStatus.Invoke((Action)(() =>
                {
                    lblAutoPrintStatus.Text = LanguageExtension.GetResourceValueFromValue(
                        "Lấy danh sách in tự động. \nKhông có danh sách cần in!",
                        LanguageExtension.AppLanguage);
                }));
            }
            workingPrint = false;
        }
        public event EventHandler BatInTuDonClick;
        
        private void btnBatInTuDong_Click(object sender, EventArgs e)
        {
            if (!timerAutoPrint.Enabled)
            {
                LayKhoaChiDinh();
                LayKhoaHienThoi();
                LayDoiTuong();
                if(string.IsNullOrEmpty(_listKhoaChiDinh) && string.IsNullOrEmpty(_listKhoaHienThoi))
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn khoa!");
                    return;
                }

                TrangThai = LanguageExtension.GetResourceValueFromValue(
                    "Đang chạy",
                    LanguageExtension.AppLanguage); //"Đang chạy";
                timerAutoPrint.Interval = int.Parse(txtThoiGianScan.Text) * 1000;
                LayDieuKienIn();
                LockUnlock(true);
                timerAutoPrint.Tick += timerAutoPrint_Tick;
                timerAutoPrint.Start();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("In tự động đang chạy.");
            }
            BatInTuDonClick?.Invoke(this, e);
        }

        private void LockUnlock(bool isLock)
        {
            pnFunction.Enabled = !isLock;
            cboNguoiKyTen.Enabled = !isLock;
            btnDSMayin.Enabled = !isLock;
            btnXoaMayIn.Enabled = !isLock;
            btnBatInTuDong.Enabled = !isLock;
            splitContainerCondit.Enabled = !isLock;
            btnTatinTuDong.Enabled = isLock;
            pbDangChay.Visible = isLock;
            lblAutoPrintStatus.Text = string.Empty;
        }
        private void txtThoiGianScan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }
        public event EventHandler BatTatinTuDongClick;
        private void btnTatinTuDong_Click(object sender, EventArgs e)
        {
            if (timerAutoPrint.Enabled)
            {
                TrangThai = "";
                timerAutoPrint.Tick -= timerAutoPrint_Tick;
                timerAutoPrint.Stop();
                LockUnlock(false);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("In tự động đã tắt.");
            }

            BatTatinTuDongClick?.Invoke(this, e);
        }

        private void btnXoaMayIn_Click(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count <= 0) return;
            if (listPrinter.SelectedIndex > -1)
            {
                listPrinter.Items.RemoveAt(listPrinter.SelectedIndex);
            }
        }
        private void btnDSMayin_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadPrinterNameNormal(listPrinter, PrinterReg, true);
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrinter.Items.Count <= 0) return;
            if (listPrinter.SelectedItem != null)
            {
                _registryExtension.WriteRegistry(
                    PrinterReg,
                    listPrinter.SelectedItem.ToString());
            }
        }

        private void gvKhuVuc_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Load_KhoaPhong();
        }

        private void chkInDaXacNhanTatCa_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
