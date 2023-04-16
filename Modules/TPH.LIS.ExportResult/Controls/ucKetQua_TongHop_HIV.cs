using System;
using System.Collections.Generic;
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
    public partial class ucKetQua_TongHop_HIV : UserControl
    {
        public ucKetQua_TongHop_HIV()
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
            condit.LoaiXetNghiem = new List<Common.TestType.EnumTestType> { Common.TestType.EnumTestType.HIV };
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            
            var dtTemp = _iexport.XuatKEtQuaThuongQui(condit);

            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                CustomMessageBox.ShowAlert("Đang xử lý số liệu:\nTổng hợp danh sách ...");

                DataTable dtResult = WorkingServices.DataTable_DistinctValue(dtTemp,
            new string[] { "NgayTiepNhan","Seq", "MaTiepNhan", "TenBN"
                    , "Tuoi","NamSinh","NamSinhNam","NamSinhNu", "GioiTinh","DiaChi","ChanDoan", "TenNhanVien"
                    ,"TenKhoaPhong","MaKhoaPhong","TenBacSiKLXN","TenDoiTuongDichVu","ThoiGianNhap"
                    ,"MaBN","SoBHYT","MaDoiTuongDichVu","TAT","TGLaymauMau","TGNhanmauMau"
                    ,"ThoiGianInDauTien","ThoiGianHenTraKQ","ThoiGianTraKQ","ThoiGianInXN","DoiTuong","TenLoaiMau","SinhPham"
            });
                dtResult.Columns.Add("STT", typeof(int));
                dtResult.Columns.Add("XetNghiem", typeof(string));
                dtResult.Columns.Add("KetLuan", typeof(string));

                string finishAddColumns = string.Empty;
                StringBuilder sbTestName = new StringBuilder();
                StringBuilder sbResult = new StringBuilder();
                int countI = 0;
                string maTiepNhan = string.Empty;

                var valKetqua = string.Empty;
                var ketLuan = string.Empty;
                var ketQua = string.Empty;
                var countPatient = 0;
                foreach (DataRow drSID in dtResult.Rows)
                {
                    countPatient ++;
                    maTiepNhan = drSID["MaTiepNhan"].ToString().Trim();
                    CustomMessageBox.ShowAlert(string.Format("Đang tổng hợp số liệu.\n    Mã tiếp nhận: {0}", maTiepNhan));
                    countI++;
                    finishAddColumns = string.Empty;
                    sbTestName = new StringBuilder();
                    sbResult = new StringBuilder();
                    valKetqua = string.Empty;
                    ketLuan = string.Empty;
                    ketQua = string.Empty;

                    var dmxn = dtTemp.AsEnumerable().Cast<DataRow>()
                        .Where(row => row.Field<string>("MaTiepNhan").Trim().Equals(maTiepNhan))
                                    .Select(row => new
                                    {
                                        MaXN = row.Field<string>("MaXN"),
                                        TenXN = row.Field<string>("TenXN"),
                                        KetQua = row.Field<string>("KetQua"),
                                        SapXep = row.Field<int>("SapXep"),
                                        ThuTuIn = row.Field<int>("ThuTuIn"),
                                        TenNhom = row.Field<string>("TenNhomCLS"),
                                        SinhPham = row.Field<string>("SinhPham")
                                    }).ToList().OrderBy(x => x.ThuTuIn).ThenBy(x => x.SapXep);
                 
                    foreach (var item in dmxn)
                    {
                      
                        valKetqua = item.KetQua == null ? string.Empty : item.KetQua;
                        ketQua += string.IsNullOrEmpty(ketLuan) ? "" : ", ";
                        ketLuan += string.IsNullOrEmpty(ketLuan) ? "" : ", ";
                        ketQua += string.Format("{0}: {0}", item.SinhPham, valKetqua);

                        if (WorkingServices.IsNumeric(valKetqua.Replace("<", "").Replace(">", "").Trim()))
                        {
                            double valIn = -1;
                            if (double.TryParse(valKetqua.Replace("<", "").Replace(">", "").Trim(), out valIn))
                            {
                                if (valIn > 1)
                                    ketLuan += string.Format("*", valKetqua);
                                else
                                    ketLuan += "Âm tính";
                            }
                            else
                                ketLuan += string.Format("{0}", valKetqua);
                        }
                        else
                            ketLuan += string.Format("{0}", valKetqua);
                    }
                    drSID["STT"] = countPatient;
                    drSID["XetNghiem"] = ketQua;
                    drSID["KetLuan"] = ketLuan;
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

        private void ucKetQua_TongHop_HIV_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
