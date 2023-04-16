using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log;

namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{

    public partial class ucLogThongTinHanhChinh : UserControl
    {
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        public ucLogThongTinHanhChinh()
        {
            InitializeComponent();
        }
        private void Get_LogList()
        {
            Log.LogActionId logId = Log.LogActionId.AllAction;
            if (radDelete.Checked)
                logId = Log.LogActionId.Delete;
            else if (radUpdate.Checked)
                logId = Log.LogActionId.Update;
            DataTable dtSearchResult = _iLogService.ReadLog_List(LogTableIds.Benhnhan_tiepnhan
                , logId, string.Empty, string.Empty, string.Empty, dtpFromDate.Value, dtpToDate.Value, string.Empty);
            if (!string.IsNullOrEmpty(txtSearchValue.Text))
            {
                string searchCondit1 = string.Format("<MaTiepNhan>{0}</MaTiepNhan>", txtSearchValue.Text);
                string searchCondit2 = string.Format("<TenBN>{0}", txtSearchValue.Text);
                string searchCondit3 = string.Format("{0}</TenBN>", txtSearchValue.Text);
                string searchCondit4 = string.Format("<Seq>{0}</Seq>", txtSearchValue.Text);
                dtSearchResult = WorkingServices.SearchResult_OnDatatable_NoneSort(dtSearchResult, "NoiDung like '%" + searchCondit1 + "%' or NoiDung like '%" + searchCondit2 + "%' or NoiDung like '%" + searchCondit3 + "%'or NoiDung like '%" + searchCondit4 + "%'");
            }
            Common.Extensions.ControlExtension.BindToGrid(dtSearchResult, ref dtgLogList, ref bvList, false);
        }
        private void dtgLogList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgLogList.CurrentRow != null)
            {
                string logId = dtgLogList.CurrentRow.Cells[ID.Name].Value.ToString().Trim();
                DataTable dt = Change_FormatDataType(new BENHNHAN_TIEPNHAN(), _iLogService.ReadLog_Detail(logId));
                BENHNHAN_TIEPNHAN objBenhNhan = _iPatient.Get_Info_BenhNhan_TiepNhan(dt);
                BindData_ThongTin_BenhNhan(objBenhNhan);
            }
        }
        private DataTable Change_FormatDataType(BENHNHAN_TIEPNHAN obj, DataTable dtReception)
        {
            System.Reflection.PropertyInfo[] minfo = typeof(BENHNHAN_TIEPNHAN).GetProperties();
            return ControlExtension.SetData_PropertyType(minfo, dtReception);
        }
        private void BindData_ThongTin_BenhNhan(BENHNHAN_TIEPNHAN objBenhnhanTiepnhan)
        {
            Clear_BindingAndvalues();

            dtpDateIn.DataBindings.Add("Value", objBenhnhanTiepnhan,
              ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Ngaytiepnhan), true,
              DataSourceUpdateMode.Never, DateTime.Now);

            txtMaTiepNhan.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Matiepnhan), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtSEQ.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Seq), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtAge.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tuoi), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtAddress.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Diachi), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtEmail.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Email), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtPhone.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Sdt), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtMSBenhNhan.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Mabn), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtTenBN.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tenbn), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtSex.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Gioitinh), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtBSChiDinh.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Bacsicd), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtChanDoan.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Chandoan), true,
                DataSourceUpdateMode.Never, string.Empty);

            txtDTDichVu.DataBindings.Add("Text", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Doituongdichvu), true,
                DataSourceUpdateMode.Never, string.Empty);

            chkAgeType.DataBindings.Add("Checked", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Congaysinh), true,
                DataSourceUpdateMode.Never, string.Empty);

            dtpBirthday.DataBindings.Add("Value", objBenhnhanTiepnhan,
                ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Sinhnhat), true,
                DataSourceUpdateMode.Never, DateTime.Now);

            txtUserNhap.DataBindings.Add("Text", objBenhnhanTiepnhan,
              ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Usernhap), true,
              DataSourceUpdateMode.Never, string.Empty);

            txtTGNhap.DataBindings.Add("Text", objBenhnhanTiepnhan,
              ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Thoigiannhap), true,
              DataSourceUpdateMode.Never, string.Empty, "dd/MM/yyyy HH:mm:ss");


            txtMakhoaChiDinh.DataBindings.Add("Text", objBenhnhanTiepnhan,
               ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Madonvi), true,
               DataSourceUpdateMode.Never, string.Empty);

            txtTenKhoaChiDinh.DataBindings.Add("Text", objBenhnhanTiepnhan,
              ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tendonvi), true,
              DataSourceUpdateMode.Never, string.Empty);

            txtMaKhoaHienThoi.DataBindings.Add("Text", objBenhnhanTiepnhan,
               ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Makhoahienthoi), true,
               DataSourceUpdateMode.Never, string.Empty);

            txtTenKhoaHienThoi.DataBindings.Add("Text", objBenhnhanTiepnhan,
              ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Tenkhoahienthoi), true,
              DataSourceUpdateMode.Never, string.Empty);
            //txtUserSua.DataBindings.Add("Text", objBenhnhanTiepnhan,
            //  ControlExtension.PropertyName<BENHNHAN_TIEPNHAN>(x => x.Usercapnhat), true,
            //  DataSourceUpdateMode.Never, string.Empty);
        }

        private void Clear_BindingAndvalues()
        {

            dtpDateIn.DataBindings.Clear();

            txtMaTiepNhan.DataBindings.Clear();
            txtMaTiepNhan.Text = string.Empty;

            txtSEQ.DataBindings.Clear();
            txtSEQ.Text = string.Empty;
            txtSEQ.ReadOnly = true;

            txtAge.DataBindings.Clear();
            txtAge.Text = string.Empty;

            txtBSChiDinh.DataBindings.Clear();
            txtBSChiDinh.Text = string.Empty;

            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = string.Empty;

            txtAddress.DataBindings.Clear();
            txtAddress.Text = string.Empty;

            txtEmail.DataBindings.Clear();
            txtEmail.Text = string.Empty;

            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Clear();

            txtMSBenhNhan.DataBindings.Clear();
            txtMSBenhNhan.Text = string.Empty;

            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = string.Empty;

            txtSex.DataBindings.Clear();
            txtSex.Text = string.Empty;

            txtBSChiDinh.DataBindings.Clear();
            txtBSChiDinh.Text = string.Empty;

            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = string.Empty;

            txtDTDichVu.DataBindings.Clear();
            txtDTDichVu.Text = string.Empty;

            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;

            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;

            txtUserNhap.DataBindings.Clear();
            txtUserNhap.Text = string.Empty;

            txtTGNhap.DataBindings.Clear();
            txtTGNhap.Text = string.Empty;


            txtMakhoaChiDinh.DataBindings.Clear();
            txtMakhoaChiDinh.Text = string.Empty;

            txtTenKhoaChiDinh.DataBindings.Clear();
            txtTenKhoaChiDinh.Text = string.Empty;

            txtMaKhoaHienThoi.DataBindings.Clear();
            txtMaKhoaHienThoi.Text = string.Empty;

            txtTenKhoaHienThoi.DataBindings.Clear();
            txtTenKhoaHienThoi.Text = string.Empty;

            //txtUserSua.DataBindings.Clear();
            //txtUserSua.Text = string.Empty;
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
    }
}
