using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Services;
namespace TPH.LIS.App.DailyUse.BenhNhan.Logs
{

    public partial class ucNhatKyChinhSuaDanhMuc : UserControl
    {
        private readonly IWorkingLogService _iLogService = new WorkingLogService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        public ucNhatKyChinhSuaDanhMuc()
        {
            InitializeComponent();
        }
        private void Get_LogList()
        {
            if (comboBox1.SelectedIndex > -1)
            {
                DataTable dtSearchResult = _iLogService.Data_HeThong_NhatKyDanhMucByMaDanhMuc(string.Empty, comboBox1.SelectedValue.ToString());
                if (checkBox1.Checked)
                {
                    if(dtSearchResult != null)
                    {
                        if(dtSearchResult.Rows.Count >0)
                        {

                            dtSearchResult = WorkingServices.SearchResult_OnDatatable_NoneSort(dtSearchResult, string.Format("ThoiGianThucHien >= '{0}' and ThoiGianThucHien <= '{1}'", dtpFromDate.Value, dtpToDate.Value));
                        }
                    }
                }
                if(dtSearchResult != null)
                {
                    dtSearchResult.Columns.Add("HanhDong", typeof(string));
                    if (dtSearchResult.Rows.Count >0)
                    {
                        foreach (DataRow item in dtSearchResult.Rows)
                        {
                            var idhanhDong = int.Parse(item["IdHanhDong"].ToString());
                            item["HanhDong"] = (idhanhDong.Equals((int)LogActionId.Delete) ? "Xóa" : (idhanhDong.Equals((int)LogActionId.Update) ? "Cập nhật" : "Khác"));
                        }
                        dtSearchResult.AcceptChanges();
                        dtSearchResult.DefaultView.Sort = "ThoiGianThucHien DESC";
                        dtSearchResult = dtSearchResult.DefaultView.ToTable();
                    }
                }
                ControlExtension.BindToGrid(dtSearchResult, ref dtgLogList, ref bvList, false);
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn danh mục");
        }
        public void GetDataTable()
        {
            var data = new DataTable();
            data.Columns.Add("TableID", typeof(string));
            data.Columns.Add("TableDetail", typeof(string));
            var dr = data.NewRow();
            dr["TableID"] = LogTableIds.Cauhinh_hethong;
            dr["TableDetail"] = "Cấu hình hệ thống";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem;
            dr["TableDetail"] = "Danh mục xét nghiệm";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_nhom;
            dr["TableDetail"] = "Danh mục nhóm xét nghiệm";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_bophan;
            dr["TableDetail"] = "Danh mục bộ phận xét nghiệm";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_bo;
            dr["TableDetail"] = "Danh mục bộ xét nghiệm";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_bo_chitiet;
            dr["TableDetail"] = "Danh mục chi tiết bộ xét nghiệm";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_profile;
            dr["TableDetail"] = "Danh mục profile";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_profile_chitiet;
            dr["TableDetail"] = "Danh mục chi tiết profile";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_tinhtoan;
            dr["TableDetail"] = "Danh mục xét nghiệm tính toán";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_csbt;
            dr["TableDetail"] = "Danh mục giới hạn tham chiếu";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_phuongphap;
            dr["TableDetail"] = "Danh mục QT/PP xét nghiệm";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_biendichketqua;
            dr["TableDetail"] = "Danh mục biên dịch kết quả máy";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.H_bangmamayxn;
            dr["TableDetail"] = "Danh mục mapping mã máy";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_sinhly;
            dr["TableDetail"] = "Danh mục sinh lý";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_congty;
            dr["TableDetail"] = "Danh mục công ty";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_mappingHIS;
            dr["TableDetail"] = "Danh mục mapping HIS (hành chính)";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Dm_xetnghiem_his;
            dr["TableDetail"] = "Danh mục mapping HIS (Dịch vụ)";
            data.Rows.Add(dr);
            dr = data.NewRow();
            dr["TableID"] = LogTableIds.Ql_nguoidungID;
            dr["TableDetail"] = "Danh mục người dùng";
            data.Rows.Add(dr);

            ControlExtension.BindDataToCobobox(data, ref comboBox1, "TableID", "TableDetail");
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
