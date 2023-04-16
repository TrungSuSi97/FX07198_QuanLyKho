using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{

    public partial class ucLogCLS_KetQua_XetNghiem_DanhSach : UserControl
    {
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        private readonly ITestResultInformationService _iResult = new TestResultInformationService();
        public ucLogCLS_KetQua_XetNghiem_DanhSach()
        {
            InitializeComponent();
        }
        public string MaTiepNhan
        {
            set { txtSearchValue.Text = value; }
            get { return txtSearchValue.Text; }
        }
        public string MaXN
        {
            set { txtSearchXN.Text = value; }
            get { return txtSearchXN.Text; }
        }
        public DateTime FromDate
        {
            set { dtpFromDate.Value = WorkingServices.StartOfDay(value); }
        }
        public DateTime ToDate
        {
            set { dtpToDate.Value = WorkingServices.EndOfDay(value); }
        }
        public void Get_LogList()
        {
            ControlExtension.SetLowerCaseForXGridColumns(gvKetQua);
            Log.LogActionId logId = Log.LogActionId.AllAction;
            if (radDelete.Checked)
                logId = Log.LogActionId.Delete;
            else if (radUpdate.Checked)
                logId = Log.LogActionId.Update;
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            DataTable dtSearchResult = _iLogService.ReadLog_List(LogTableIds.Ketqua_cls_xetnghiem
                , logId, string.Empty, string.Empty, string.Empty, dtpFromDate.Value, dtpToDate.Value, string.Empty);
            string condit = string.Empty;
            if (!string.IsNullOrEmpty(txtSearchValue.Text))
            {
                condit = string.Format("NoiDung like '%<MaTiepNhan>{0}%'", txtSearchValue.Text);
                condit += string.Format(" or NoiDung like '%{0}</MaTiepNhan>%'", txtSearchValue.Text);
                dtSearchResult = WorkingServices.SearchResult_OnDatatable_NoneSort(dtSearchResult, condit);
            }
            if (!string.IsNullOrEmpty(txtSearchXN.Text))
            {
                condit = string.Format("NoiDung like '%<TenXN>{0}</TenXN>%'", txtSearchXN.Text);

                condit += string.Format("or NoiDung like '%<MaXN>{0}</MaXN>%'", txtSearchXN.Text);
                dtSearchResult = WorkingServices.SearchResult_OnDatatable_NoneSort(dtSearchResult, condit);
            }
            dtSearchResult.DefaultView.Sort = "ThoiGian asc";
            dtSearchResult = dtSearchResult.DefaultView.ToTable();
            var dataDetail = new DataTable();
            var iTotal = dtSearchResult.Rows.Count;
            var iRuning = 0;
            foreach (DataRow drId in dtSearchResult.Rows)
            {
                iRuning++;
                CustomMessageBox.ShowAlert(string.Format("Đang xử lý số liệu {0}/{1}", iRuning, iTotal));
                var Id = drId["ID"].ToString();
                var lstNewvalue = _iLogService.ConvertStringToNewList(drId["GiaTriMoi"].ToString());
                if (lstNewvalue.Count > 0)
                {
                    var data = _iLogService.ReadLog_Detail(Id);
                    if (data.Rows.Count > 0)
                    {
                        if (dataDetail.Rows.Count == 0)
                        {
                            dataDetail = new DataTable();
                            foreach (DataColumn dtcD in data.Columns)
                            {
                                var typeName = dtcD.DataType.FullName;
                                dataDetail.Columns.Add(dtcD.ColumnName, Type.GetType(typeName));
                            }
                            dataDetail.Columns.Add("KetQuaMoi", typeof(string));
                            dataDetail.Columns.Add("NguoiThucHien", typeof(string));
                            dataDetail.Columns.Add("ThoiGian", typeof(DateTime));
                        }

                        foreach (DataRow drsource in data.Rows)
                        {
                            if (data.Columns.Contains("ThoiGianNhapKQ"))
                            {
                                var tgNhaketqua = drsource["ThoiGianNhapKQ"].ToString();
                                if (!string.IsNullOrEmpty(tgNhaketqua) || radDelete.Checked || radAllAction.Checked)
                                {
                                    foreach (DataColumn dtc in data.Columns)
                                    {
                                        var allow = true;
                                        foreach (DataColumn item in dataDetail.Columns)
                                        {
                                            if (item.ColumnName.Trim().Equals(dtc.ColumnName.Trim(), StringComparison.OrdinalIgnoreCase))
                                            {
                                                allow = false;
                                                break;
                                            }

                                        }
                                        if (allow)
                                        {
                                            dataDetail.Columns.Add(dtc.ColumnName, Type.GetType(dtc.DataType.FullName));
                                  
                                        }
                                    }
                                    var drAdd = dataDetail.NewRow();
                                    foreach (DataColumn dtc2 in data.Columns)
                                    {
                                        drAdd[dtc2.ColumnName] = drsource[dtc2.ColumnName];
                                    }

                                    drAdd["NguoiThucHien"] = drId["NguoiThucHien"].ToString();
                                    drAdd["ThoiGian"] = drId["ThoiGian"];

                                    var find = lstNewvalue.Where(x => x.colmnName == "CLSXN_KetQua");
                                    if (find.Any())
                                        drAdd["KetQuaMoi"] = find.First().newValue ?? string.Empty;

                                    dataDetail.Rows.Add(drAdd);
                                }
                            }
                        }
                    }
                }
            }
            dataDetail = WorkingServices.ConvertColumnNameToLower_Upper(dataDetail, true);
            gcKetQua.DataSource = dataDetail;
            CustomMessageBox.CloseAlert();
        }
        private DataTable Change_FormatDataType(KETQUA_CLS_XETNGHIEM obj, DataTable dtReception)
        {
            System.Reflection.PropertyInfo[] minfo = typeof(KETQUA_CLS_XETNGHIEM).GetProperties();
            return ControlExtension.SetData_PropertyType(minfo, dtReception);
        }
     
        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            Get_LogList();
        }

        private void ucLogThongTinHanhChinh_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtpToDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59,59);
        }

        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Get_LogList();
                e.Handled=true;
            }
        }

        private void txtSearchXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Get_LogList();
                e.Handled = true;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcKetQua, string.Format("NhatKyXetNghiem_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }
    }
}
