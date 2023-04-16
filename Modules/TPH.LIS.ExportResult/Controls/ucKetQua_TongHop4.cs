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
    public partial class ucKetQua_TongHop4 : UserControl
    {
        public ucKetQua_TongHop4()
        {
            InitializeComponent();
        }
        private readonly IExportResultService _iexport = new ExportResultService();
        public delegate ExportCondition GetCondit();
        public event GetCondit getCondit;

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeChiTietXetNghiem();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcCTXN, string.Format("ChiTietXetnghiem_BenhNhan_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }
        private void ThongKeChiTietXetNghiem()
        {
            gcCTXN.DataSource = null;

            var condit = getCondit();
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var dtTemp = _iexport.XuatKEtQuaThuongQui(condit);

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu:\nTổng hợp danh sách bệnh nhân...");
                DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
                    new string[] { "NgayTiepNhan","Seq", "MaTiepNhan", "TenBN"
                    , "Tuoi","NamSinh","AgeNam","AgeNu", "GioiTinh","DiaChi","ChanDoan", "TenNhanVien"
                    ,"TenKhoaPhong","MaKhoaPhong","TenBacSiKLXN","TenDoiTuongDichVu","ThoiGianNhap"
                    ,"MaBN","SoBHYT","MaDoiTuongDichVu","TAT","TGLaymauMau","TGNhanmauMau","ThoiGianInDauTien","ThoiGianHenTraKQ","ThoiGianTraKQ","ThoiGianInXN","SoPhieuYeuCau"
                    });
                dtResult.Columns.Add("STT", typeof(int));
                dtResult.Columns.Add("YeuCau", typeof(string));
                dtResult.Columns.Add("KetQuaXetNghiem", typeof(string));
                var currentNhom = -1;
                string finishAddColumns = string.Empty;
                StringBuilder sbTestName = new StringBuilder();
                StringBuilder sbResult = new StringBuilder();
                int countI = 0;
                int countPatient = 0;
                string maTiepNhan = string.Empty;
                bool newGroup = false;
                foreach (DataRow drSID in dtResult.Rows)
                {
                    countPatient++;
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

                         if(condit.XuatTheoTen)
                        {
                            sbTestName.AppendFormat("{0}{1}", (countI > 1 && !newGroup ? "; " : ""), item.TenXN.Trim());
                        }
                        else
                        {
                            var maxn = item.MaXN.Trim().Split('_');
                            var maGhep = string.Empty;
                            if (maxn.Length > 1)
                            {
                                for (int i = 1; i < maxn.Length; i++)
                                {
                                    maGhep += string.IsNullOrEmpty(maGhep) ? string.Format("{0}", maxn[i]) : string.Format("_{0}", maxn[i]);
                                }
                            }
                            sbTestName.AppendFormat("{0}{1}", (countI  > 1 && !newGroup ? "; " : ""), maGhep);
                        }
                        sbResult.AppendFormat("{0}{1}", (countI > 1 && !newGroup ? "; " : ""), item.KetQua == null ?"  ": item.KetQua.Trim());
                        newGroup = false;
                    }
                    drSID["STT"] = countPatient;
                    drSID["YeuCau"] = sbTestName.ToString();
                    drSID["KetQuaXetNghiem"] = sbResult.ToString();
                }

                gcCTXN.DataSource = dtResult;

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

        private void ucKetQua_TongHop4_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
