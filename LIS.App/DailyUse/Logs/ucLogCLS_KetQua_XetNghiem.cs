using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log;
using TPH.LIS.Log.Constants;

namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{

    public partial class ucLogCLS_KetQua_XetNghiem : UserControl
    {
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        private readonly ITestResultInformationService _iResult = new TestResultInformationService();
        public ucLogCLS_KetQua_XetNghiem()
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
        public int Get_LogList()
        {
            dtgLogList.CellEnter -= dtgLogList_CellEnter;
            Log.LogActionId logId = Log.LogActionId.AllAction;
            if (radDelete.Checked)
                logId = Log.LogActionId.Delete;
            else if (radUpdate.Checked)
                logId = Log.LogActionId.Update;
            DataTable dtSearchResult = _iLogService.ReadLog_List(LogTableIds.Ketqua_cls_xetnghiem
                , logId, string.Empty, string.Empty, string.Empty, dtpFromDate.Value, dtpToDate.Value, txtSearchValue.Text);
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
            ControlExtension.BindToGrid(dtSearchResult, ref dtgLogList, ref bvList, false);
            dtgLogList.CellEnter += dtgLogList_CellEnter;
            Load_LogDetail();
            return dtgLogList.RowCount;
        }
        private void dtgLogList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_LogDetail();
        }
        private void Load_LogDetail()
        {
            if (dtgLogList.CurrentRow != null)
            {
                string logId = dtgLogList.CurrentRow.Cells[ID.Name].Value.ToString().Trim();
                DataTable dt = Change_FormatDataType(new KETQUA_CLS_XETNGHIEM(), _iLogService.ReadLog_Detail(logId));

                KETQUA_CLS_XETNGHIEM objInfo = _iResult.Get_Info_ketqua_cls_xetnghiem(dt);
                BindData_ThongTin(objInfo);

                //Binding gia moi

                txtKetQuaMoi.Text = string.Empty;
                txtIDMayXnMoi.Text = string.Empty;
                txtGhiChuMoi.Text = string.Empty;
                var lstNew = _iLogService.ConvertStringToNewList(dtgLogList.CurrentRow.Cells[colGiaTriMoi.Name].Value.ToString());
                if (lstNew.Count > 0)
                {
                    foreach (var item in lstNew)
                    {
                        if (item.colmnName == ColumnConstants.KetQuaXn_KetQua)
                        {
                            txtKetQuaMoi.Text = item.newValue;
                        }
                        else if (item.colmnName == ColumnConstants.KetQuaXn_IDMay)
                        {
                            txtIDMayXN.Text = item.newValue;
                        }
                        else if (item.colmnName == ColumnConstants.KetQuaXn_GhiChu)
                        {
                            txtGhiChuMoi.Text = item.newValue;
                        }
                    }
                }
            }
        }
        private DataTable Change_FormatDataType(KETQUA_CLS_XETNGHIEM obj, DataTable dtReception)
        {
            System.Reflection.PropertyInfo[] minfo = typeof(KETQUA_CLS_XETNGHIEM).GetProperties();
            return ControlExtension.SetData_PropertyType(minfo, dtReception);
        }
        private void BindData_ThongTin(KETQUA_CLS_XETNGHIEM objKetQua)
        {
            Clear_BindingAndvalues();

            txtMaXN.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Maxn), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtKetQua.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Ketqua), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtTenXN.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Tenxn), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtIDMayXN.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Idmayxetnghiem), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtUserNhap.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Usernhapcd), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtTGNhap.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Thoigiannhap), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty, "HH:mm:ss dd/MM/yyyy");

            txtTGCapNhatKQ.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Thoigiannhapkq), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty, "HH:mm:ss dd/MM/yyyy");

            txtLasUpdateTime.DataBindings.Add("Text", objKetQua,
    ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Thoigiansuakq), true,
    DataSourceUpdateMode.OnPropertyChanged, string.Empty, "HH:mm:ss dd/MM/yyyy");

            txtGhiChu.DataBindings.Add("Text", objKetQua,
                ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Ghichu), true,
                DataSourceUpdateMode.OnPropertyChanged, string.Empty);

            txtMaTiepNhan.DataBindings.Add("Text", objKetQua,
                 ControlExtension.PropertyName<KETQUA_CLS_XETNGHIEM>(x => x.Matiepnhan), true,
                 DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }

        private void Clear_BindingAndvalues()
        {

            txtMaXN.DataBindings.Clear();
            txtMaXN.Text = string.Empty;

            txtTenXN.DataBindings.Clear();
            txtTenXN.Text = string.Empty;

            txtKetQua.DataBindings.Clear();
            txtKetQua.Text = string.Empty;           

            txtGhiChu.DataBindings.Clear();
            txtGhiChu.Text = string.Empty;

            txtTGCapNhatKQ.DataBindings.Clear();
            txtTGCapNhatKQ.Text = string.Empty;

            txtLasUpdateTime.DataBindings.Clear();

            txtLasUpdateTime.Text = string.Empty;

            txtIDMayXN.DataBindings.Clear();
            txtIDMayXN.Text = string.Empty;


            txtUserNhap.DataBindings.Clear();
            txtUserNhap.Text = string.Empty;

            txtTGNhap.DataBindings.Clear();
            txtTGNhap.Text = string.Empty;

            txtMaTiepNhan.DataBindings.Clear();
            txtMaTiepNhan.Text = string.Empty;

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
    }
}
