using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TPH.HIS.Services;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using TPH.LIS.Common.Extensions;

namespace TPH.HIS.Controls
{
    public partial class ucLichSuKhangSinhDo : UserControl
    {
        private readonly IPatientFileServices patientFile = new PatientFileServices();
        public ucLichSuKhangSinhDo()
        {
            InitializeComponent();
        }
        public void Get_Data(string pid)
        {
            gcKhangDinhDo.DataSource = null;
            var c = 5;
            while (bgvKSD.Columns.Count > c)
            {
                bgvKSD.Columns.RemoveAt(c);
            }
            var d = 1;
            while (bgvKSD.Bands.Count > d)
            {
                bgvKSD.Bands.RemoveAt(d);
            }

            var data = patientFile.LichSuXetNghiemViSinh(pid);
            //group theo yeu cau và kỹ thuật
            //Lấy data kháng sinh đồ yêu cầu và kỹ thuật

            var dataKSD = data.DefaultView.ToTable(true, "MaYeuCau", "TenYeuCau", "KyThuat", "MaKhangSinh", "TenKhangSinh");
            //Lấy danh sách các ngày xét nghiệm
            var dataNgayXetNghiem = data.DefaultView.ToTable(true, "NgayTiepNhan", "MaTiepNhan", "Seq");

            foreach (DataRow drNgay in dataNgayXetNghiem.Rows)
            {
                //tạo GridBand theo ngày
                GridBand bandUngroupped = new GridBand();
                bandUngroupped = new GridBand();
                bandUngroupped.Caption = string.Format("{1} ({0})", DateTime.Parse(drNgay["NgayTiepNhan"].ToString()).ToString("dd/MM/yyyy"), drNgay["Seq"].ToString());
                bgvKSD.Bands.Add(bandUngroupped);
                bandUngroupped.AppearanceHeader.Font = new Font("Arial", 10, FontStyle.Bold);
                bandUngroupped.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                bandUngroupped.AppearanceHeader.TextOptions.WordWrap = WordWrap.NoWrap;
                bandUngroupped.AppearanceHeader.Options.UseTextOptions = true;
                //lấy thông tin vi khuẩn theo ngày
                var dataKetQuaTheoNgay = WorkingServices.SearchResult_OnDatatable(data, string.Format("MaTiepNhan = '{0}'", drNgay["MaTiepNhan"].ToString()));
                if (dataKetQuaTheoNgay.Rows.Count > 0)
                {
                    var dataViKhuan = dataKetQuaTheoNgay.DefaultView.ToTable(true, "MaPhanLoai", "TenPhanLoai", "LoaiKetQua", "LanXetNghiem");
                    foreach (DataRow drViKhuan in dataViKhuan.Rows)
                    {


                        var dataKhongCoKetQua = new DataTable();
                        var maPhanLoai = drViKhuan["MaPhanLoai"].ToString();
                        var tenPhanLoai = drViKhuan["TenPhanLoai"].ToString();
                        var lanXetNghiem = int.Parse(drViKhuan["LanXetNghiem"].ToString());
                        var loaiKetQua = int.Parse(drViKhuan["LoaiKetQua"].ToString());

                        //trường hợp nuôi cấy không có vi khuẩn
                        //Loại kết quả == 1
                        if (loaiKetQua == 1)
                        {
                            tenPhanLoai = string.Empty;
                            dataKhongCoKetQua = WorkingServices.SearchResult_OnDatatable(dataKetQuaTheoNgay, "LoaiKetQua = 1");
                            dataKhongCoKetQua = dataKhongCoKetQua.DefaultView.ToTable(true, "MaYeuCau", "KetQuaViSinh");
                        }

                        //Thêm 1 cột cho vi khuẩn
                        var colNameKq = string.Format("[KQ_{0}.{1}.{2}]", drNgay["MaTiepNhan"].ToString(), drViKhuan["MaPhanLoai"].ToString(), lanXetNghiem);

                        dataKSD.Columns.Add(colNameKq, typeof(string));
                        var col = InsertNewColToGrid(bgvKSD, colNameKq
                            , tenPhanLoai
                            , 150 , 25, 150);
                        bgvKSD.Columns[bgvKSD.Columns.Count - 1].OwnerBand = bandUngroupped;
                        var maViKhuan = drViKhuan["MaPhanLoai"].ToString();
                        //duyệt danh sách kháng sinh đồ lấy kết quả
                        foreach (DataRow drKSD in dataKSD.Rows)
                        {
                            var maYeuCau = drKSD["MaYeuCau"].ToString().Trim();
                            var maKhangSinh = drKSD["MaKhangSinh"].ToString();
                            var maKyThuat = drKSD["KyThuat"].ToString();
                            //  var maTiepNhan = drKSD["MaTiepNhan"].ToString();
                            if (loaiKetQua == 1)
                            {
                                foreach (DataRow drKhongKS in dataKhongCoKetQua.Rows)
                                {
                                    var maYeuCauKKS = drKhongKS["MaYeuCau"].ToString().Trim();
                                    var ketquaViSinh = drKhongKS["KetQuaViSinh"].ToString();
                                    if(maYeuCau.Equals(maYeuCauKKS, StringComparison.OrdinalIgnoreCase))
                                    {
                                        drKSD[colNameKq] = ketquaViSinh;
                                    }
                                }
                            }
                            else
                            {
                                //lấy thông tin kháng sinh đồ theo vi khuẩn
                                var thongTinKetQua = WorkingServices.SearchResult_OnDatatable(dataKetQuaTheoNgay
                                    , string.Format("MaPhanLoai = '{0}' and MaYeuCau = '{1}' and MaKhangSinh = '{2}' and KyThuat = '{3}' and LanXetNghiem = {4}"
                                    , maViKhuan, maYeuCau, maKhangSinh, maKyThuat, lanXetNghiem));
                                if (thongTinKetQua.Rows.Count > 0)
                                {
                                    var SIR = thongTinKetQua.Rows[0]["KetQuaSRI"].ToString();
                                    var duongKinh = thongTinKetQua.Rows[0]["KetQuaDinhLuong"].ToString();
                                    var ketqua = SIR;
                                    if (!string.IsNullOrEmpty(duongKinh) && !duongKinh.Trim().Equals(SIR.Trim(), StringComparison.OrdinalIgnoreCase) && chkGhepDuongKinh.Checked)
                                        ketqua += string.Format("({0})", duongKinh);
                                    drKSD[colNameKq] = ketqua;
                                }
                            }
                        }
                    }
                }
            }
            gcKhangDinhDo.DataSource = dataKSD;
            bgvKSD.ExpandAllGroups();
        }
        private GridColumn InsertNewColToGrid(GridView gridView, string fieldName, string title, int width = 70
            , int? minWidth = null, int? maxWidth = null, FormatType? formatType = null, string formatString = null
            , bool groupSummary = false)
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
            col.OptionsColumn.AllowSort = DefaultBoolean.False;
            col.OptionsColumn.ShowCaption = !string.IsNullOrEmpty(title);
            col.OptionsColumn.AllowMerge = (string.IsNullOrEmpty(title) ? DefaultBoolean.True : DefaultBoolean.Default);
            return col;
        }

        private void bgvKSD_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.Name.Contains("KQ_"))
            {
                string tempValue = string.Empty;
                GridView view = sender as GridView;

                if (view.GetRowCellValue(e.RowHandle, e.Column) != null)
                {
                    tempValue = view.GetRowCellValue(e.RowHandle, e.Column).ToString().Trim();
                    if (!string.IsNullOrEmpty(tempValue))
                    {
                        FontStyle fs = new FontStyle();
                        var color = _MauKQ(tempValue, ref fs);
                        Font font = new Font("Arial", 10, fs);

                        e.Appearance.Font = font;
                        e.Appearance.ForeColor = color;
                        e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                }
            }
        }
        private Color _MauKQ(string co, ref FontStyle fstyle)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            if (co.Contains("S"))
            {
                fstyle = FontStyle.Bold;
                return Color.Blue;
            }
            else if (co.Contains("R"))
            {
                fstyle = FontStyle.Bold;
                return Color.Red;
            }
            else
            {
                fstyle = FontStyle.Regular;
                return Color.Black;
            }
        }

        private void bgvKSD_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.OptionsColumn.AllowMerge == DefaultBoolean.True)
            {
                string text1 = view.GetRowCellDisplayText(e.RowHandle1, e.Column);
                string text2 = view.GetRowCellDisplayText(e.RowHandle2, e.Column);
                e.Merge = (text1 == text2);
                e.Handled = true;
            }
            else
                e.Handled = true;
        }
    }
}
