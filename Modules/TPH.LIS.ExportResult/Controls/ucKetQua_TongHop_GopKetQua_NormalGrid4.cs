using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.ExportResult.Service;
using TPH.LIS.Common.Extensions;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using TPH.Language;
using TPH.LIS.Common.Controls;
using TPH.LIS.ExportResult.Models;

namespace TPH.LIS.ExportResult.Controls
{
    public partial class ucKetQua_TongHop_GopKetQua_NormalGrid4 : UserControl
    {
        public ucKetQua_TongHop_GopKetQua_NormalGrid4()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;
        private ExportCondition currentcondit;
        int designColumn = 17;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiem();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string[] title = new string[] { "SỔ XÉT NGHIỆM", string.Format("Từ ngày {0} đến ngày {1} ", currentcondit.TuNgay.ToString("dd/MM/yyyy"), currentcondit.DenNgay.ToString("dd/MM/yyyy")) };
            string[] headerLeft = null;// new string[] { "SỞ Y TẾ CẦN THƠ", "BVĐK HÒA HẢO - MEDIC CẦN THƠ", "KHOA XÉT NGHIỆM" };
            string[] headerRight = null;// new string[] { "MS: 14/BV 01" };
            Excel.ExportToExcel.Export_NormalDataGrid(dtgResultColumn, new string[] { "Tuổi" }
                , new int[] { 3 }, new int[] { 4 }, true, true, title, 10, true, false, headerLeft, headerRight, null, null, true);
        }
        private void ThongKeChiTietXetNghiem()
        {
            dtgResultColumn.DataSource = null;

            while (dtgResultColumn.Columns.Count > designColumn)
            {
                dtgResultColumn.Columns.RemoveAt(designColumn);
            }
            currentcondit = getCondit();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var dtTemp = _iexport.XuatKEtQuaThuongQui(currentcondit);
            var counBN = 0;
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu:\nTổng hợp danh sách bệnh nhân...");
                DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
                    new string[] { "NgayTiepNhan","Seq", "MaTiepNhan", "TenBN"
                    , "Tuoi","NamSinh","AgeNam","AgeNu", "GioiTinh","DiaChi","ChanDoan", "TenNhanVien"
                    ,"TenKhoaPhong","MaKhoaPhong","TenBacSiKLXN","TenDoiTuongDichVu","ThoiGianNhap"
                    ,"MaBN","SoBHYT","MaDoiTuongDichVu","TAT","TGLaymauMau","TGNhanmauMau","thoigianindautien","ThoiGianHenTraKQ","ThoiGianTraKQ","ThoiGianInXN","SoPhieuYeuCau"
                    });
                dtResult.Columns.Add("STT", typeof(int));
                dtResult.Columns.Add("YeuCau", typeof(string));
                var currentNhom = -1;
                string finishAddColumns = string.Empty;
                StringBuilder sbTestName = new StringBuilder();
                StringBuilder sbResult = new StringBuilder();
                int countI = 0;
                string maTiepNhan = string.Empty;
                bool newGroup = false;
                foreach (DataRow drSID in dtResult.Rows)
                {
                    counBN++;
                    newGroup = false;
                    maTiepNhan = drSID["MaTiepNhan"].ToString().Trim();
                    CustomMessageBox.ShowAlert(string.Format("Đang tổng hợp số liệu.\n    Mã tiếp nhận: {0}", maTiepNhan));
                    countI = 0;
                    currentNhom = -1;
                    finishAddColumns = string.Empty;
                    sbTestName = new StringBuilder();
                    sbResult = new StringBuilder();

                    var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                        .Where(row => row.Field<string>("MaTiepNhan").Trim().Equals(maTiepNhan))
                                    .Select(row => new
                                    {
                                        MaXN = row.Field<string>("MaXN"),
                                        TenXN = row.Field<string>("TenXN"),
                                        KetQua = row.Field<string>("KetQua"),
                                        SapXep = row.Field<int>("SapXep"),
                                        ThuTuIn = row.Field<int>("ThuTuIn"),
                                        TenNhom = row.Field<string>("TenNhomCLS")
                                    }).ToList().OrderBy(x => x.ThuTuIn).ThenBy(x => x.SapXep);
                 
                    foreach (var item in dmxn)
                    {
                        countI++;
                        if (currentNhom != item.ThuTuIn)
                        {
                            newGroup = true;
                            if (currentNhom != -1)
                            {
                                sbTestName.Append(Environment.NewLine);
                                sbResult.Append(Environment.NewLine);
                            }
                            sbTestName.AppendFormat("{0}:{1}", item.TenNhom, Environment.NewLine);
                            sbResult.AppendFormat("{0}:{1}", item.TenNhom, Environment.NewLine);
                            currentNhom = item.ThuTuIn;
                        }

                        // if(currentcondit.XuatTheoTen)
                        //{
                            sbTestName.AppendFormat("{0}{1}:{2}", (countI > 1 && !newGroup ? "; " : ""), item.TenXN.Trim(), (item.KetQua == null ? "  " : item.KetQua.Trim()));
                        //}
                        //else
                        //{
                        //    var maxn = item.MaXN.Trim().Split('_');
                        //    var maGhep = string.Empty;
                        //    if (maxn.Length > 1)
                        //    {
                        //        for (int i = 1; i < maxn.Length; i++)
                        //        {
                        //            maGhep += string.IsNullOrEmpty(maGhep) ? string.Format("{0}", maxn[i]) : string.Format("_{0}", maxn[i]);
                        //        }
                        //    }
                        //    sbTestName.AppendFormat("{0}{1}:{2}", (countI  > 1 && !newGroup ? "; " : ""), maGhep, (item.KetQua == null ? "  " : item.KetQua.Trim()));
                        //}
                       
                        newGroup = false;
                    }
                    drSID["STT"] = counBN;
                    drSID["YeuCau"] = sbTestName.ToString();
                }

                ControlExtension.BindDataToGrid(dtResult, ref dtgResultColumn, ref bvResultColumn);
                if (dtgResultColumn.Columns.Count > designColumn)
                {
                    var ct = new DataGridViewCellStyle();
                    ct.WrapMode = DataGridViewTriState.True;
                    this.dtgResultColumn.Columns[designColumn].DefaultCellStyle = ct;
                    dtgResultColumn.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
                dtgResultColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgResultColumn.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgResultColumn.AutoResizeRows();

            }
            CustomMessageBox.CloseAlert();
        }

        private void InsertNewColToGrid(GridView gridView,
    string fieldName, string title,
    int width = 70, int? minWidth = null, int? maxWidth = null, FormatType? formatType = null, string formatString = null, bool groupSummary = false)
        {
            GridColumn col = gridView.Columns.AddVisible(fieldName, title);
            if (formatType != null)
            {
                col.DisplayFormat.FormatType = formatType.Value;
                col.GroupFormat.FormatType = formatType.Value;
            }
            if (!string.IsNullOrEmpty(formatString))
            {
                col.DisplayFormat.FormatString = formatString;
                col.GroupFormat.FormatString = formatString;
            }
            if (groupSummary)
            {
                col.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, fieldName, formatString)});
            }
            col.OptionsColumn.AllowEdit = false;
            col.OptionsColumn.ReadOnly = true;
            col.Width = width;
            if (minWidth != null)
            {
                col.MinWidth = 10;
            }
            if (maxWidth != null)
            {
                col.MaxWidth = 500;
            }
            col.ColumnEdit = new RepositoryItemTextEdit();
        }

        private void ucKetQua_TongHop_GopKetQua_NormalGrid4_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
