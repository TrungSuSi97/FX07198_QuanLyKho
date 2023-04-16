using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common;
using DevExpress.XtraGrid;
using System.Threading;
using TPH.LIS.ResultConvert.Service;
using TPH.LIS.Common.Controls;
using TPH.LIS.Data;
using DevExpress.XtraGrid.Views.Grid;
using TPH.WriteLog;
using System.Threading.Tasks;
using TPH.Common.Extensions;
using TPH.LIS.User.Constants;
using TPH.Controls;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class AnalyzerResult : UserControl
    {
        public AnalyzerResult()
        {
            InitializeComponent();
            pnLayKetQuaTuDong.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnThaoTac.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnNgayTiepNhan.BackColor = CommonAppColors.ColorMainAppFormColor;
        }
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly IResultConvertService _iResultConvert = new ResultConvertService();
        public string UserId = string.Empty;
        public string ClsXetNghiemDinhDangKetqua = string.Empty;
        public string PcWorkPlace = string.Empty;
        public EnumKieuLayKetQuaMay ClsXetNghiemKieuLayKetQuaMay = EnumKieuLayKetQuaMay.TatCa;
        private bool layKetQuaSau = true;
        public string[] arrAnalyzerAllow = { };
        public int gioiHanBarcode = 10;
        private bool _bioticMode = false;
        public bool suDungLayTuDong = false;
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        private DateTime _currentDate = DateTime.Now;
        public bool BioticMode
        {
            get => _bioticMode;
            set
            {
                _bioticMode = value;
                ChangeMode();
            }
        }

        private void ChangeMode()
        {
            colKetQuaMay_dekhangkhangsinh.Visible = _bioticMode;
            colKetQuaMay_ketquadekhangkhangsinh.Visible = _bioticMode;
            colKetQuaMay_makhangsinh.Visible = _bioticMode;
            colKetQuaMay_MaKhangSinh_Lis.Visible = _bioticMode;
            colKetQuaMay_MaLoaiMau.Visible = _bioticMode;
            colKetQuaMay_MaLoaiMauMay.Visible = _bioticMode;
            colKetQuaMay_MaViKhuan.Visible = _bioticMode;
            colKetQuaMay_Mavikhuan_Lis.Visible = _bioticMode;
            colKetQuaMay_MIC.Visible = _bioticMode;
            colKetQuamay_tenkhangsinh.Visible = _bioticMode;
            colKetQuaMay_TenLoaiMau.Visible = _bioticMode;
            colKetQuaMay_TenViKhuan.Visible = _bioticMode;
            if (_bioticMode)
            {
                pnXetNghiem.Visible = false;
                pnThaoTac.Dock = DockStyle.Top;
                pnThaoTac.BringToFront();
            }
            else
            {
                pnXetNghiem.Visible = true;
                pnThaoTac.Dock = DockStyle.Bottom;
                pnXetNghiem.BringToFront();
            }
        }

        private void Load_MayXetNghiem()
        {
            if (arrAnalyzerAllow == null) return;
            if (arrAnalyzerAllow.Length <= 0) return;
            var allowanalyzer = Utilities.ArrayToSqlValue(arrAnalyzerAllow);
            var mayXetNghiem = from selectData in _iAnalyzerConfig.Data_h_mayxetnghiem().AsEnumerable()
                where allowanalyzer.Contains(string.Format("'{0}'", selectData["idmay"].ToString()))
                select selectData;
            if (mayXetNghiem.Any())
            {
                var data = mayXetNghiem.AsDataView().ToTable();

                foreach (DataColumn dtc in data.Columns)
                {
                    dtc.ColumnName = dtc.ColumnName.ToLower();
                }
                gcMayXN.DataSource = data;
            }
            else
                gcMayXN.DataSource = null;
        }

        private void Load_DanhSach_XetNghiem()
        {
            var idMay = string.Empty;
            if (gvMayXN.SelectedRowsCount >0)
            {
                foreach (var item in gvMayXN.GetSelectedRows())
                {
                    if(gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                    {
                        idMay += (string.IsNullOrEmpty(idMay) ? "" : ",") + gvMayXN.GetRowCellValue(item, colIDMayXn).ToString();
                    }
                }
            }
            var data = _iAnalyzerConfig.Data_h_bangmamayxn_xetnghiem_forSelect(idMay, string.Empty, string.Empty, string.Empty);
            foreach (DataColumn dtc in data.Columns)
            {
                dtc.ColumnName = dtc.ColumnName.ToLower();
            }
            data.AcceptChanges();
            gcTestCode.DataSource = data;
            gvTestCode.ExpandAllGroups();
        }
        private void Load_Stattus()
        {
            /*--0::Chưa map mã
            --1::Chấp nhận
            --2::Xem lại
            --3::Chưa nhập SID
            --4::Chưa nhập XN
            --5::Đã cập nhật kết quả
            --6::XN đã có kết quả
            --7::Đã in kết quả
             */
            var data = _iAnalyzerConfig.Data_Status();
            gcTrangThai.DataSource = data;

        }
        public void Load_CauHinh(DateTime servertime)
        {
            _currentDate = servertime;
            dtpNgayXNTuDong.Value = servertime;
            timerAutoChangeDate.Tick += TimerAutoChangeDate_Tick;
            timerAutoChangeDate.Enabled = true;
            timerAutoChangeDate.Start();
            dtpDenNgayChiDinh.Value = servertime;
            dtpTuNgayChiDinh.Value = servertime;
            for (int i = 0; i < gvTestingResultMachine.Columns.Count; i++)
            {
                var col = gvTestingResultMachine.Columns[i];
                col.FieldName = col.FieldName.ToLower().Trim();
            }
            Load_Stattus();
            Load_MayXetNghiem();
            Load_DanhSach_XetNghiem();
            pnLayKetQuaTuDong.Visible = suDungLayTuDong;

            chkCapNhatKetQuaLanChaySau.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryGetLastedResultForAuto).Equals("1");
            chkCapNhatKetQuaChuaDuyet.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryOverWriteResultNotValidForAuto).Equals("1");
            chkLayKetQuaTrangThaiLoi.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryReGetResultStatusErrorForAuto).Equals("1");
            chkCapNhatKetQuaChuaDuyet.CheckedChanged += ChkCapNhatKetQuaChuaDuyet_CheckedChanged;
            chkCapNhatKetQuaLanChaySau.CheckedChanged += ChkCapNhatKetQuaLanChaySau_CheckedChanged;
            chkLayKetQuaTrangThaiLoi.CheckedChanged += ChkLayKetQuaTrangThaiLoi_CheckedChanged;
        }

        private void ChkLayKetQuaTrangThaiLoi_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
             UserConstant.RegistryReGetResultStatusErrorForAuto,
             chkLayKetQuaTrangThaiLoi.Checked ? "1" : "0");
        }

        public void StopTimer()
        {
            if (tmLayKetQuaTuDong.Enabled)
            {
                tmLayKetQuaTuDong.Stop();
                tmLayKetQuaTuDong.Enabled = false;
            }
        }
        private void ChkCapNhatKetQuaLanChaySau_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
           UserConstant.RegistryGetLastedResultForAuto,
           chkCapNhatKetQuaLanChaySau.Checked ? "1" : "0");
        }

        private void ChkCapNhatKetQuaChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
      UserConstant.RegistryOverWriteResultNotValidForAuto,
      chkCapNhatKetQuaChuaDuyet.Checked ? "1" : "0");
        }

        private void TimerAutoChangeDate_Tick(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddSeconds(1);
            if (_currentDate.Hour == 0 && _currentDate.Minute == 0 && _currentDate.Second < 2)
            {
                dtpDenNgayChiDinh.Value = _currentDate;
                dtpTuNgayChiDinh.Value = _currentDate;
            }

            if (tmLayKetQuaTuDong.Enabled)
            {
                btnLayKetQuaTuDong.BackColor = (btnLayKetQuaTuDong.BackColor == Color.Yellow ? Color.Empty : Color.Yellow);
            }
        }
        public void Load_DanhSachKetQua()
        {
            var barcode = txtBarcode.Text;
            var maMayXN = string.Empty;
            if (gvMayXN.SelectedRowsCount > 0)
            {
                foreach (var item in gvMayXN.GetSelectedRows())
                {
                    if (gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                        maMayXN += (string.IsNullOrEmpty(maMayXN) ? "" : ",") + gvMayXN.GetRowCellValue(item, colIDMayXn).ToString();
                }
            }
            else
                maMayXN = Utilities.ArrayToSqlValue(arrAnalyzerAllow);
            var maXn = string.Empty;
            if (gvTestCode.SelectedRowsCount > 0)
            {
                foreach (var item in gvTestCode.GetSelectedRows())
                {
                    if (gvTestCode.GetRowCellValue(item, clTestCode) != null)
                        maXn += (string.IsNullOrEmpty(maXn) ? "" : ",") + gvTestCode.GetRowCellValue(item, clTestCode).ToString();
                }
            }
          
            var trangThai = string.Empty;
            if (gvTrangThai.SelectedRowsCount > 0)
            {
                foreach (var item in gvTrangThai.GetSelectedRows())
                {
                    if (gvTrangThai.GetRowCellValue(item, colIdTrangThai) != null)
                        trangThai += (string.IsNullOrEmpty(trangThai) ? "" : ",") + gvTrangThai.GetRowCellValue(item, colIdTrangThai).ToString().Trim();
                }
            }

            var nhomXn = string.Empty;

            var status_id = new int[] { CommonConstant.TrangThaiKqMayTuMayKhac, CommonConstant.TrangThaiKqMayNhanTuMiddleware, CommonConstant.TrangThaiKqMayGoiDiMiddleware };
            //if (radOtherMachine.Checked)
            //    status_id = new int[] { CommonConstant.TrangThaiKqMayTuMayKhac };
            //else if (radSendInfinity.Checked)
            //    status_id = new int[] { CommonConstant.TrangThaiKqMayGoiDiMiddleware };
            //else if (radReceiveInfinity.Checked)
            //    status_id = new int[] { CommonConstant.TrangThaiKqMayNhanTuMiddleware };

            var results = _iAnalyzerResult.Data_Analyzer_Result(dtpTuNgayChiDinh.Value.Date, dtpDenNgayChiDinh.Value.Date, barcode
                , trangThai, maMayXN,
               new string[] { nhomXn }, maXn
               , UserId.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) ? null : UserId
               , layKetQuaSau, status_id, chkHISTORY.Checked, -1, -1, false, -1);
            if (results != null)
            {
                foreach (DataColumn dtc in results.Columns)
                {
                    dtc.ColumnName = dtc.ColumnName.ToLower();
                }
            }
            gcTestingResultMachine.DataSource = results;
            gvTestingResultMachine.ExpandAllGroups();
            colTestingResultTime.SortMode = ColumnSortMode.Value;
            if (layKetQuaSau)
                colTestingResultTime.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            else
                colTestingResultTime.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }
        private System.Timers.Timer timerwaitManual = new System.Timers.Timer();
        private int iNumManual = 0;
        private int iCountManual = 0;
        AutoResetEvent LockUpdateManual;
        private void TimerwaitManual_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (iNumManual < iCountManual)
            {
                if (isCancel || !workingUpdateManual)
                    Stop_updateManual();
                else if (!isCancel && !isPause)
                {
                    pnUpdate.Invoke(new EventHandler(delegate
                    {
                        lblUpdateSatus.Text = string.Format("{0:0.##}%", ((double)iNumManual / iCountManual) * 100);
                    }));
                    timerwaitManual.Interval = 20;
                    LockUpdateManual.Set();
                }
            }
            else
                Stop_updateManual();
        }
        private void Stop_updateManual()
        {
            _threadUpdateManual.Abort();
            timerwaitManual.Stop();

            pnUpdate.Invoke(new EventHandler(delegate
            {
                Load_DanhSachKetQua();
                //Load_ChiTietXN();
                lblUpdateSatus.Text = "0%";
                pnUpdate.Visible = false;
                btnLayKetQua.Enabled = true;
            }));
            isCancel = false;
        }
        private void btnCancelUpdateManual_Click(object sender, EventArgs e)
        {
            isPause = true;
            isCancel = CustomMessageBox.MSG_Question_YesNo_GetYes("Dừng cập nhật kết quả?");
            isPause = false;
        }
        private bool isCancel = false;
        private bool isPause = false;
        private Thread _threadUpdateManual = null;
        private bool workingUpdateManual = false;
        protected void StartThreadUpdateManual()
        {
            iNumManual = 0;
            iCountManual = 0;
            timerwaitManual.Interval = 150;
            LockUpdateManual = new AutoResetEvent(false);
            timerwaitManual.Elapsed += TimerwaitManual_Elapsed;
            _threadUpdateManual = new Thread(new ThreadStart(Update_AnalyzerResult_ForTest));
            _threadUpdateManual.Start();
            timerwaitManual.Start();

            btnLayKetQua.Enabled = false;
        }
        private void Update_AnalyzerResult_ForTest()
        {
            if (gvTestingResultMachine.RowCount > 0)
            {
                workingUpdateManual = true;
                pnUpdate.Invoke(new EventHandler(delegate
                {
                    pnUpdate.Size = gcTestingResultMachine.Size;
                    pnUpdate.Location = gcTestingResultMachine.Location;
                    pnUpdate.Visible = true;
                }));

                var data = (DataView)gvTestingResultMachine.DataSource;
                var dtSid = data.ToTable(true, new string[] { "sid", "NgayXN" });
                iCountManual = data.Count + dtSid.Rows.Count;

                _iAnalyzerResult.UpdateCLSResultFromDataView((DataView)gvTestingResultMachine.DataSource,
                     _isSysConfig.Data_dm_xetnghiem_biendichketqua(null)
                     , progressBarKetQuaMay, LockUpdateManual, ref iNumManual
                     , ClsXetNghiemDinhDangKetqua, UserId, PcWorkPlace, ClsXetNghiemKieuLayKetQuaMay, false, chkCapNhatKetQuaChuaDuyet.Checked, true, false, false);

                workingUpdateManual = false;
            }
        }
        private void btnDanhSachChiDinh_Click(object sender, EventArgs e)
        {
            Load_DanhSachKetQua();
        }
        private void btnLayKetQua_Click(object sender, EventArgs e)
        {
            StartThreadUpdateManual();
        }
        private void btnDoiBarcode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBarcode.Text)
                && gvTestingResultMachine.RowCount > 0)
            {
                if (gvTestingResultMachine.SelectedRowsCount > 0)
                {
                    var f = new FrmDoiBarcode {UserID = UserId};
                    var IDList = string.Empty;
                    var ngayXetNghiem =string.Empty;
                    foreach (var i in gvTestingResultMachine.GetSelectedRows())
                    {
                        if (gvTestingResultMachine.GetRowCellValue(i, colKetQuaMay_ID) != null)
                        {
                            if (string.IsNullOrEmpty(ngayXetNghiem))
                            {
                                ngayXetNghiem = (gvTestingResultMachine.GetRowCellValue(i, colDate) == null ? string.Empty : gvTestingResultMachine.GetRowCellValue(i, colDate).ToString());
                            }
                            var id = gvTestingResultMachine.GetRowCellValue(i, colKetQuaMay_ID);
                            if (id != null)
                                IDList += (string.IsNullOrEmpty(IDList) ? "" : ",") + id.ToString();
                        }
                    }

                    f.IDList = IDList;
                    f.OldCode = txtBarcode.Text;
                    f.OldDate = TPH.Common.Converter.DateTimeConverter.ToDateTime(ngayXetNghiem);

                    f.ShowDialog();
                    if (!string.IsNullOrWhiteSpace(f.NewCode))
                    {
                        txtBarcode.Text = f.NewCode;
                        //dtpFromDate.Value = dtpToDate.Value = f.NewDate;
                    }
                    Load_DanhSachKetQua();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn những dòng cần đổi barcode.");
            }
        }
        private void btnDoiTrangThai_Click(object sender, EventArgs e)
        {
            if (gvTestingResultMachine.RowCount > 0)
            {
                if (gvTestingResultMachine.GetSelectedRows().Length > 0)
                {
                    var frm = new FrmDoiTrangThaiKetQua();
                    frm.ShowDialog();
                    string changeStatus = frm.StatusSelected;
                    int iCount = 0;
                    if (!string.IsNullOrEmpty(changeStatus))
                    {
                        CustomMessageBox.ShowAlert("Đang thực hiện đổi trạng thái.");
                        var sbUpdateTrangThai = new StringBuilder();
                        foreach (int i in gvTestingResultMachine.GetSelectedRows())
                        {
                            var autoId = gvTestingResultMachine.GetRowCellValue(i, colKetQuaMay_ID);
                            //Cập nhật => đã 
                            if (autoId != null)
                            {
                                if (iCount == 100)
                                {
                                    DataProvider.ExecuteQuery(sbUpdateTrangThai.ToString());
                                    sbUpdateTrangThai = new StringBuilder();
                                    iCount = 0;
                                }
                                else
                                    iCount++;
                                sbUpdateTrangThai.Append(string.IsNullOrEmpty(sbUpdateTrangThai.ToString()) ? string.Empty : ";\n");
                                sbUpdateTrangThai.Append(_iAnalyzerResult.Update_KQMay_TrangThai(autoId.ToString(), changeStatus));
                            }
                        }
                        if (!string.IsNullOrEmpty(sbUpdateTrangThai.ToString()))
                            DataProvider.ExecuteQuery(sbUpdateTrangThai.ToString());
                        Load_DanhSachKetQua();
                        CustomMessageBox.CloseAlert();
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Không có dòng kết quả nào được chọn!");
            }
        }
        private void gcTestingResultMachine_DoubleClick(object sender, EventArgs e)
        {
            if (gvTestingResultMachine.RowCount <= 0) return;
            if (gvTestingResultMachine.GetRowCellValue(gvTestingResultMachine.FocusedRowHandle, colSampleID) != null)
            {
                var seq = gvTestingResultMachine.GetRowCellValue(gvTestingResultMachine.FocusedRowHandle, colSampleID).ToString();
                txtBarcode.Text = seq;
                Load_DanhSachKetQua();
            }
        }
        private void gvTestingResultMachine_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (view.GetRowCellValue(e.RowHandle, colStatus.FieldName) != null)
                {
                    var statusValue = view.GetRowCellValue(e.RowHandle, colStatus.FieldName).ToString();
                    var ketQuahinh = bool.Parse(view.GetRowCellValue(e.RowHandle, colKetQuaMay_HinhAnh.FieldName) == null ? "false" : view.GetRowCellValue(e.RowHandle, colKetQuaMay_HinhAnh.FieldName).ToString());
                    var loaiketqua = view.GetRowCellValue(e.RowHandle, ccolKetQuaMay_LoaiKetQua.FieldName).ToString();
                    if (statusValue.Equals(TestingResultStatusConstant.XemLai))
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                    else if (ketQuahinh)
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                    }
                    else if (loaiketqua.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    {
                        e.Appearance.BackColor = Color.LightPink;
                    }
                }
                //if (view.GetRowCellValue(e.RowHandle, colStatus.FieldName) != null && e.Column == colKetQuaMay_icon)
                //{
                //    try
                //    {
                //        var isFlag = bool.Parse(view.GetRowCellValue(e.RowHandle, colKetQua_XnCo.FieldName).ToString());
                //        var statusValue = view.GetRowCellValue(e.RowHandle, colStatus.FieldName).ToString();
                //        var chapNhan = statusValue.Equals(TestingResultStatusConstant.ChapNhan);
                //        var dacapnhat = statusValue.Equals(TestingResultStatusConstant.DaCapNhatKetQua);
                //        var xemlai = statusValue.Equals(TestingResultStatusConstant.XemLai);
                //        var chuamap = statusValue.Equals(TestingResultStatusConstant.ChuaNhapMa) || statusValue.Equals(TestingResultStatusConstant.ChuaNhapChiDinh) || statusValue.Equals(TestingResultStatusConstant.ChuaNhapThongTin);
                //        if (isFlag)
                //        {
                //            e.Appearance.ForeColor = Color.DarkOrange;
                //        }
                //        //if (chuamap)
                //        //    view.SetRowCellValue(e.RowHandle, colKetQuaMay_icon, imageList1.Images[1]);
                //        //else if (isFlag)
                //        //    view.SetRowCellValue(e.RowHandle, colKetQuaMay_icon, imageList1.Images[2]);
                //        //else if (xemlai)
                //        //    view.SetRowCellValue(e.RowHandle, colKetQuaMay_icon, imageList1.Images[5]);
                //        //else if (chapNhan)
                //        //    view.SetRowCellValue(e.RowHandle, colKetQuaMay_icon, imageList1.Images[3]);
                //        //else if (dacapnhat)
                //        //    view.SetRowCellValue(e.RowHandle, colKetQuaMay_icon, imageList1.Images[4]);
                //        //else
                //        //    view.SetRowCellValue(e.RowHandle, colKetQuaMay_icon, imageList1.Images[0]);
                //    }
                //    catch (Exception ex)
                //    {
                //        CustomMessageBox.MSG_Information_OK(ex.Message);
                //    }
                //}
            }
        }
        private void gvTestingResultMachine_DoubleClick(object sender, EventArgs e)
        {
            if (gvTestingResultMachine.RowCount <= 0) return;
            if (gvTestingResultMachine.GetRowCellValue(gvTestingResultMachine.FocusedRowHandle, colSampleID) != null)
            {
                var seq = gvTestingResultMachine.GetRowCellValue(gvTestingResultMachine.FocusedRowHandle, colSampleID).ToString();
                txtBarcode.Text = seq;
                Load_DanhSachKetQua();
            }
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtBarcode.Text = WorkingServices.GetBarcodeInString(txtBarcode.Text, gioiHanBarcode);
                Load_DanhSachKetQua();
            }
        }
        private void txtBarcode_MouseClick(object sender, MouseEventArgs e)
        {
            txtBarcode.SelectAll();
        }
        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        #region Lấy kết quả máy tự động
        private bool DangLayKetQua = false;
        List<string> lstDSMayCapNhatTuDong = new List<string>();
        private void btnLayKetQuaTuDong_Click(object sender, EventArgs e)
        {
            if (tmLayKetQuaTuDong.Enabled)
            {
                tmLayKetQuaTuDong.Stop();
                tmLayKetQuaTuDong.Enabled = false;
                btnLayKetQuaTuDong.Text = "Lấy KQ tự động";
                btnLayKetQuaTuDong.BackColor = Color.Empty;
                chkCapNhatKetQuaChuaDuyet.Enabled = true;
                chkCapNhatKetQuaLanChaySau.Enabled = true;
                chkLayKetQuaTrangThaiLoi.Enabled = true;
                dtpNgayXNTuDong.Enabled = true;
            }
            else
            {
                var f = new FrmChonDSMayXn();
                f.gcMayXN.DataSource = gcMayXN.DataSource;
                f.ShowDialog();
                lstDSMayCapNhatTuDong = f.lstMay;
                if (lstDSMayCapNhatTuDong.Count > 0)
                {
                    chkCapNhatKetQuaChuaDuyet.Enabled = false;
                    chkCapNhatKetQuaLanChaySau.Enabled = false;
                    chkLayKetQuaTrangThaiLoi.Enabled = false;
                    dtpNgayXNTuDong.Enabled = false;
                    btnLayKetQuaTuDong.Text = "Đang lấy KQ tự động";
                    tmLayKetQuaTuDong.Interval = 10000;
                    tmLayKetQuaTuDong.Enabled = true;

                    tmLayKetQuaTuDong.Start();
                }
            }
        }
        private void KiemTraChayCapNhatTuDong()
        {
            if (!DangLayKetQua)
            {
                DangLayKetQua = true;
                var maMayXN = string.Empty;
                if (gvMayXN.SelectedRowsCount > 0)
                {
                    foreach (var item in gvMayXN.GetSelectedRows())
                    {
                        if (gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                            maMayXN += (string.IsNullOrEmpty(maMayXN) ? "" : ",") + gvMayXN.GetRowCellValue(item, colIDMayXn).ToString();
                    }
                }
                else
                    maMayXN = Utilities.ArrayToSqlValue(arrAnalyzerAllow);

                Task.Factory.StartNew(delegate { LayKetQuaMayTuDong(maMayXN); });
            }
        }
        private void LayKetQuaMayTuDong(string lstMayXnAllow)
        {
            try
            {
                //Lưu ý option cập nhật đè kết quả chưa duyệt
                //Nếu đè mà lấy kết quả lần chạy sau thì cho sort thời gian chạy sau nằm dưới, nếu chỉ chọn lấy kết quả sau thì cho sort thời gian chạy sau nằm trên
                //=> vì cơ hế kiểm tra kết quả sẽ vô hiệu hóa khi cho cập nhật đè kq chưa đạt.
                var dataBienDich = _isSysConfig.Data_dm_xetnghiem_biendichketqua(null);
                var dtAnalyzerResult = _iAnalyzerResult.Data_Analyzer_Result(dtpNgayXNTuDong.Value.Date, dtpNgayXNTuDong.Value.Date, string.Empty
                  , string.Format("{0}", TestingResultStatusConstant.ChapNhan), lstMayXnAllow, null, null
                  , UserId.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) ? null : UserId
                  , (chkCapNhatKetQuaLanChaySau.Checked ? (chkCapNhatKetQuaChuaDuyet.Checked ? false : true) : false)
                  , new int[] { CommonConstant.TrangThaiKqMayTuMayKhac
                  , CommonConstant.TrangThaiKqMayNhanTuMiddleware, CommonConstant.TrangThaiKqMayGoiDiMiddleware }, false, -1, -1, true, -1);

                if (dtAnalyzerResult.Rows.Count > 0)
                {
                    LogService.RecordLogFile("AutoUpdate_AnalyzerResult_Form", "LayKetQuaMayTuDong => UpdateCLSResultFromDatatable(...)");
                    int icount = 0;
                    _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResult, dataBienDich
                        , progressBarKetQuaMayTuDong,null,ref icount, ClsXetNghiemDinhDangKetqua, UserId
                        , PcWorkPlace, ClsXetNghiemKieuLayKetQuaMay, true,  chkCapNhatKetQuaChuaDuyet.Checked, chkCapNhatKetQuaLanChaySau.Checked, false, false);
                }
                if (chkLayKetQuaTrangThaiLoi.Checked)
                {
                    var dtAnalyzerResultError = _iAnalyzerResult.Data_Analyzer_Result(dtpNgayXNTuDong.Value.Date, dtpNgayXNTuDong.Value.Date, string.Empty
                        , string.Format("{0},{1}", TestingResultStatusConstant.ChuaNhapThongTin, TestingResultStatusConstant.ChuaNhapChiDinh)
                        , lstMayXnAllow, null, null
                        , UserId.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) ? null : UserId
                        , (chkCapNhatKetQuaLanChaySau.Checked ? (chkCapNhatKetQuaChuaDuyet.Checked ? false : true) : false)
                        , new int[] { CommonConstant.TrangThaiKqMayTuMayKhac, CommonConstant.TrangThaiKqMayNhanTuMiddleware, CommonConstant.TrangThaiKqMayGoiDiMiddleware }, false, -1, -1, true, -1);

                    if (dtAnalyzerResultError.Rows.Count > 0)
                    {
                        LogService.RecordLogFile("AutoUpdate_AnalyzerResult_Form", "LayKetQuaMayTuDong => UpdateCLSResultFromDatatable(...)");
                        var iCount = 0;
                        _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResultError, dataBienDich
                            , progressBarKetQuaMayTuDong,null, ref iCount, ClsXetNghiemDinhDangKetqua, UserId
                            , PcWorkPlace, ClsXetNghiemKieuLayKetQuaMay, true,  chkCapNhatKetQuaChuaDuyet.Checked, chkCapNhatKetQuaLanChaySau.Checked, false, false);
                    }
                }
                if (dtpNgayXNTuDong.Value.Date < _currentDate.Date)
                    dtpNgayXNTuDong.Value = _currentDate;
                DangLayKetQua = false;
            }
            catch (Exception ex)
            {
                LogService.RecordLogFile("AutoUpdate_AnalyzerResult_Form", string.Format("LayKetQuaMayTuDong => Lỗi:\n{0}", ex.ToString()));
            }
            finally
            {
                DangLayKetQua = false;
            }
        }
        private void tmLayKetQuaTuDong_Tick(object sender, EventArgs e)
        {
            KiemTraChayCapNhatTuDong();
        }
        public void ReCalculateSpliter()
        {
            splitContainer1.SplitterDistance = btnDoiTrangThai.Location.X + btnDoiTrangThai.Width + 5;
        }
        #endregion

        private void AnalyzerResult_DpiChangedAfterParent(object sender, EventArgs e)
        {
            ReCalculateSpliter();
        }
    }
}
