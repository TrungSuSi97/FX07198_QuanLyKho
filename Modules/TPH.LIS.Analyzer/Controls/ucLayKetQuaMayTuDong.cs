using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common;
using TPH.WriteLog;
using TPH.LIS.ResultConvert.Service;
using System.Threading;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucLayKetQuaMayTuDong : UserControl
    {
        public ucLayKetQuaMayTuDong()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        private readonly IResultConvertService _iResultConvert = new ResultConvertService();
        public string[] arrAnalyzerAllow = null;
        public string UserId = string.Empty;
        public string clsXetNghiemDinhDangKetqua = "{N}";
        public string PCWorkPlace = string.Empty;
        public EnumKieuLayKetQuaMay ClsXetNghiemKieuLayKetQuaMay = EnumKieuLayKetQuaMay.TatCa;
        public void Load_Config()
        {
            ControlExtension.SetLowerCaseForXGridColumns(gvMayXN);
            Load_DanhSach_MayXnTheoMayTinh();
        }
        private void Load_DanhSach_MayXnTheoMayTinh()
        {
            //Load danh sách máy xét nghiệm theo phân quyền trước

            if (arrAnalyzerAllow != null)
            {
                if (arrAnalyzerAllow.Count() > 0)
                {
                    string allowanalyzer = Utilities.ArrayToSqlValue(arrAnalyzerAllow);
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

                        var dataAnalyxerConfigPC = WorkingServices.ConvertColumnNameToLower_Upper(_iAnalyzerConfig.Data_dm_maytinh_mayxetnghiem(PCWorkPlace, Environment.MachineName, null), true);
                        if (dataAnalyxerConfigPC != null)
                        {
                            if (dataAnalyxerConfigPC.Rows.Count > 0)
                            {
                                for (int i = 0; i < gvMayXN.RowCount; i++)
                                {
                                    var idMay = gvMayXN.GetRowCellValue(i, colIDMayXn).ToString();
                                    foreach (DataRow dr in dataAnalyxerConfigPC.Rows)
                                    {
                                        var idmayConfigPc = dr["IdMayXetNghiem"].ToString();
                                        if (idmayConfigPc.Equals(idMay))
                                        {
                                            gvMayXN.SelectRow(i);
                                            break;
                                        }
                                    }
                                }
                                for (int r = 0; r < gvMayXN.RowCount; r++)
                                {
                                    if(!gvMayXN.IsRowSelected(r))
                                    {
                                        gvMayXN.DeleteRow(r);
                                        r--;
                                    }

                                }
                            }
                        }
                    }
                    else
                        gcMayXN.DataSource = null;
                }
            }
        }
        private bool DangLayKetQua = false;
        List<string> lstDSMayCapNhatTuDong = new List<string>();
        private void btnThuHien_Click(object sender, EventArgs e)
        {
            if (gvMayXN.SelectedRowsCount > 0)
            {
                if (tmLayKetQuaTuDong.Enabled)
                {
                    Stop();
                }
                else
                {
                    foreach (var item in gvMayXN.GetSelectedRows())
                    {
                        if (gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                            lstDSMayCapNhatTuDong.Add(gvMayXN.GetRowCellValue(item, colIDMayXn).ToString());
                    }
                    if (lstDSMayCapNhatTuDong.Count > 0)
                    {
                        SetMess("Đang chạy");
                        lblStastus.Text = "";
                        tmLayKetQuaTuDong.Interval = 7000;
                        tmLayKetQuaTuDong.Enabled = true;
                        tmLayKetQuaTuDong.Start();
                    }
                }
            }
        }
        public void Stop()
        {
            if (tmLayKetQuaTuDong.Enabled)
            {
                tmLayKetQuaTuDong.Stop();
                timerwaitManual.Stop();
                if (taskUpdateReult != null)
                    taskUpdateReult.Dispose();
                tmLayKetQuaTuDong.Enabled = false;
                btnThucHien.Text = "Thực hiện";
                SetMess("Đang dừng");
            }
        }
        private void KiemTraChayNhatTuDong()
        {
            if (!DangLayKetQua)
            {
                DangLayKetQua = true;
                var maMayXN = string.Join(",", lstDSMayCapNhatTuDong);
                taskUpdateReult =  Task.Factory.StartNew(delegate { LayKetQuaMayTuDong(maMayXN); });
            }
        }
        AutoResetEvent LockUpdateManual;
        int iNumManual = 0;
        int iCountManual = 0;
        private System.Timers.Timer timerwaitManual = new System.Timers.Timer();
        Task taskUpdateReult;
        private void TimerwaitManual_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (iNumManual < iCountManual)
            {
                timerwaitManual.Interval = 20;
                LockUpdateManual.Set();
            }
        }
        private void LayKetQuaMayTuDong(string lstMayXnAllow)
        {
            try
            {
                iNumManual = 0;
                iCountManual = 0;
                LockUpdateManual = new AutoResetEvent(false);
                timerwaitManual.Elapsed += TimerwaitManual_Elapsed;

                SetMess("Đang đọc dữ liệu kết quả máy");
                var dtAnalyzerResult = _iAnalyzerResult.Data_Analyzer_Result(dtpNgayXN.Value.Date.AddDays(-1), dtpNgayXN.Value.Date, String.Empty
             , string.Format("{0}", TestingResultStatusConstant.ChapNhan), lstMayXnAllow, null, null
             , UserId.Trim().Equals("admin", StringComparison.OrdinalIgnoreCase) ? null : UserId
             , true, new int[] { CommonConstant.TrangThaiKqMayTuMayKhac, CommonConstant.TrangThaiKqMayNhanTuMiddleware
             , CommonConstant.TrangThaiKqMayGoiDiMiddleware }, false, -1, -1, true, -1);

                if (dtAnalyzerResult.Rows.Count > 0)
                {
                    SetMess("Đang xử lý kết quả máy");
                    var dtSid = dtAnalyzerResult.DefaultView.ToTable(true, new string[] { "sid", "NgayXN" });
                    iCountManual = dtAnalyzerResult.Rows.Count + dtSid.Rows.Count + 1;
                    timerwaitManual.Start();
                    LogService.RecordLogFile("AutoUpdate_AnalyzerResult_Form", "LayKetQuaMayTuDong => UpdateCLSResultFromDatatable(...)");
                    _iAnalyzerResult.UpdateCLSResultFromDatatable(dtAnalyzerResult, _isSysConfig.Data_dm_xetnghiem_biendichketqua(null)
                        , progressBar1, LockUpdateManual, ref iNumManual, clsXetNghiemDinhDangKetqua, UserId
                        , PCWorkPlace, ClsXetNghiemKieuLayKetQuaMay, true, false, true, chkXacNhanKetQuaTuDong.Checked, chkChiKetQuaThuong.Checked);
                }
            }
            catch (Exception ex)
            {
                LogService.RecordLogFile("AutoUpdate_AnalyzerResult_Form", string.Format("LayKetQuaMayTuDong => Lỗi:\n{0}", ex.ToString()));
            }
            finally
            {
                SetMess("Chờ cho lần chạy tiếp theo.");
                timerwaitManual.Stop();
                timerwaitManual.Elapsed -= TimerwaitManual_Elapsed;
                LockUpdateManual = null;
                DangLayKetQua = false;
            }
        }
        private void timergetResult_Tick(object sender, EventArgs e)
        {
            KiemTraChayNhatTuDong();
        }

        private void gvMayXN_ShowingEditor(object sender, CancelEventArgs e)
        {
            //Luôn khóa không cho check
                e.Cancel = true;
        }
        private void SetMess(string mess)
        {
            if(lblStastus.InvokeRequired)
                lblStastus.Invoke(new EventHandler(delegate
                {
                    lblStastus.Text = mess;
                }));
            else
                lblStastus.Text = mess;
        }
    }
}
