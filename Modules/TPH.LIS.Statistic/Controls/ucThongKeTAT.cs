using System;
using System.Data;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucThongKeTAT : UserControl
    {
        public ucThongKeTAT()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        public string TenBV = string.Empty;
        public string TenSYT = string.Empty;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (chk_GroupTAT_BN.Checked)
            {
                var condit = getCondit();
                CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....", 8);
                var data = _iStatistic.ThongKeXetNghiem_TAT(condit);

                #region test
                //var data_1 = data.Copy();
                DataTable dtResult = WorkingServices.DataTable_DistinctValue(data,
                    new string[] { "NgayTiepNhan","Barcode", "TenBN"
                    ,"NamSinh","GioiTinh","TenDoiTuongDichVu","TenKhoaPhong","MaBoPhanKhoaPhong"
                    ,"ThoiGianNhap","NgayLayMau"
                    ,"ThoiGianChuyenMau","NgayNhanMau","ThoiGianDuKQ"
                    ,"ThoiGianXacNhanKQ","TgChuyenKQLanDau","TgNhanKQLanDau","ThoiGianInDauTien"
                    ,"T73","T80","TATHen"
                    });
                var dtResult_1 = dtResult.Copy();

                string[] ColumnsRemoveAndAdd =
                {
                    "ThoiGianNhap","NgayLayMau"
                    ,"ThoiGianChuyenMau","NgayNhanMau","ThoiGianDuKQ"
                    ,"ThoiGianXacNhanKQ","TgChuyenKQLanDau","TgNhanKQLanDau","ThoiGianInDauTien"
                    ,"T73","T80","TATHen"
                };
                foreach (var column in ColumnsRemoveAndAdd)
                {
                    if (dtResult.Columns.Contains(column))
                        dtResult.Columns.Remove(column);
                }
                //Đã group các cột lại
                dtResult = dtResult.DefaultView.ToTable(true, new string[]
                {
                    "NgayTiepNhan","Barcode", "TenBN"
                    ,"NamSinh","GioiTinh","TenDoiTuongDichVu","TenKhoaPhong","MaBoPhanKhoaPhong"
                });
                dtResult.Columns.Add("ThoiGianNhap", typeof(DateTime));
                dtResult.Columns.Add("NgayLayMau", typeof(DateTime));
                dtResult.Columns.Add("ThoiGianChuyenMau", typeof(DateTime));
                dtResult.Columns.Add("NgayNhanMau", typeof(DateTime));
                dtResult.Columns.Add("ThoiGianDuKQ", typeof(DateTime));
                dtResult.Columns.Add("ThoiGianXacNhanKQ", typeof(DateTime));
                dtResult.Columns.Add("TgChuyenKQLanDau", typeof(DateTime));
                dtResult.Columns.Add("TgNhanKQLanDau", typeof(DateTime));
                dtResult.Columns.Add("ThoiGianInDauTien", typeof(DateTime));
                dtResult.Columns.Add("T73",typeof(int));
                dtResult.Columns.Add("T80",typeof(int));
                dtResult.Columns.Add("TATHen",typeof(int));

                foreach (DataRow drTemp in dtResult.Rows)
                {
                    var barcode = drTemp["Barcode"].ToString();
                    var dataDate = WorkingServices.SearchResult_OnDatatable(dtResult_1,
                        string.Format("Barcode = '{0}'", barcode));
                    if (dataDate.Rows.Count > 0)
                    {
                        var ThoiGianNhap = dataDate.Compute("MAX(ThoiGianNhap)", "ThoiGianNhap is not null");
                        var NgayLayMau = dataDate.Compute("MAX(NgayLayMau)", "NgayLayMau is not null");
                        var ThoiGianChuyenMau = dataDate.Compute("MAX(ThoiGianChuyenMau)", "ThoiGianChuyenMau is not null");
                        var NgayNhanMau = dataDate.Compute("MAX(NgayNhanMau)", "NgayNhanMau is not null");
                        var ThoiGianDuKQ = dataDate.Compute("MAX(ThoiGianDuKQ)", "ThoiGianDuKQ is not null");
                        var ThoiGianXacNhanKQ = dataDate.Compute("MAX(ThoiGianXacNhanKQ)", "ThoiGianXacNhanKQ is not null");
                        var TgChuyenKQLanDau = dataDate.Compute("MAX(TgChuyenKQLanDau)", "TgChuyenKQLanDau is not null");
                        var TgNhanKQLanDau = dataDate.Compute("MAX(TgNhanKQLanDau)", "TgNhanKQLanDau is not null");
                        var ThoiGianInDauTien = dataDate.Compute("MAX(ThoiGianInDauTien)", "ThoiGianInDauTien is not null");

                        var tatNoiTru = dataDate.Compute("MAX(T73)", "T73 is not null");
                        var tatNgoaiTru = dataDate.Compute("MAX(T80)", "T80 is not null");
                        var tatHen = dataDate.Compute("MAX(TATHen)", "TATHen is not null");

                        if (!string.IsNullOrEmpty(ThoiGianNhap?.ToString()))
                            drTemp["ThoiGianNhap"] = (DateTime)ThoiGianNhap;
                        if (!string.IsNullOrEmpty(NgayLayMau?.ToString()))
                            drTemp["NgayLayMau"] = (DateTime)NgayLayMau;
                        if (!string.IsNullOrEmpty(ThoiGianChuyenMau?.ToString()))
                            drTemp["ThoiGianChuyenMau"] = (DateTime)ThoiGianChuyenMau;
                        if (!string.IsNullOrEmpty(NgayNhanMau?.ToString()))
                            drTemp["NgayNhanMau"] = (DateTime)NgayNhanMau;
                        if (!string.IsNullOrEmpty(ThoiGianDuKQ?.ToString()))
                            drTemp["ThoiGianDuKQ"] = (DateTime)ThoiGianDuKQ;
                        if (!string.IsNullOrEmpty(ThoiGianXacNhanKQ?.ToString()))
                            drTemp["ThoiGianXacNhanKQ"] = (DateTime)ThoiGianXacNhanKQ;
                        if (!string.IsNullOrEmpty(TgChuyenKQLanDau?.ToString()))
                            drTemp["TgChuyenKQLanDau"] = (DateTime)TgChuyenKQLanDau;
                        if (!string.IsNullOrEmpty(TgNhanKQLanDau?.ToString()))
                            drTemp["TgNhanKQLanDau"] = (DateTime)TgNhanKQLanDau;
                        if (!string.IsNullOrEmpty(ThoiGianInDauTien?.ToString()))
                            drTemp["ThoiGianInDauTien"] = (DateTime)ThoiGianInDauTien;

                        var maBoPhanKhoaPhong = drTemp["MaBoPhanKhoaPhong"].ToString();

                        if (!string.IsNullOrEmpty(tatNoiTru?.ToString()) && maBoPhanKhoaPhong.Equals("NT"))
                            drTemp["T73"] = (int)tatNoiTru;
                        if (!string.IsNullOrEmpty(tatNgoaiTru?.ToString()) && maBoPhanKhoaPhong.Equals("NGT"))
                            drTemp["T80"] = (int)tatNgoaiTru;
                        if (!string.IsNullOrEmpty(tatHen?.ToString()))
                            drTemp["TATHen"] = (int)tatHen;
                    }
                }


                //var dtResult = dtResult_1.Copy();
                //dtResult.Columns.Remove("TGLaymauMau");
                //dtResult.Columns.Remove("ThoiGianInXN");
                //dtResult = dtResult.DefaultView.ToTable(true, new string[]
                //{
                //    "NgayTiepNhan", "Seq", "MaTiepNhan", "TenBN"
                //    , "Tuoi", "NamSinh", "AgeNam", "AgeNu", "NamSinhNam", "NamSinhNu", "GioiTinh"
                //    , "DiaChi"
                //    , "ChanDoan"
                //    , "TenNhanVien", "NgheNghiep", "CoBHYT", "DanToc"
                //    , "TenKhoaPhong", "MaKhoaPhong", "TenBacSiKLXN", "TenDoiTuongDichVu", "ThoiGianNhap"
                //    , "MaBN", "SoBHYT", "MaDoiTuongDichVu", "TAT"
                //    , "TGNhanmauMau"
                //    , "ThoiGianHenTraKQ", "ThoiGianTraKQ"
                //});
                //dtResult.Columns.Add("TGLaymauMau", typeof(DateTime));
                //dtResult.Columns.Add("ThoiGianInXN", typeof(DateTime));

                //foreach (DataRow drTemp in dtResult.Rows)
                //{
                //    var matiepnhan = drTemp["MaTiepNhan"].ToString();
                //    var dataDate = WorkingServices.SearchResult_OnDatatable(dtResult_1,
                //        string.Format("MatiepNhan = '{0}'", matiepnhan));
                //    if (dataDate.Rows.Count > 0)
                //    {
                //        var tgIn = dataDate.Compute("MAX(ThoiGianInXN)", "ThoiGianInXN is not null");
                //        var tgLayMau = dataDate.Compute("MIN(TGLaymauMau)", "TGLaymauMau is not null");
                //        if (tgIn != null)
                //        {
                //            if (!string.IsNullOrEmpty(tgIn.ToString()))
                //                drTemp["ThoiGianInXN"] = (DateTime)tgIn;
                //        }
                //        if (tgLayMau != null)
                //        {
                //            if (!string.IsNullOrEmpty(tgLayMau.ToString()))
                //                drTemp["TGLaymauMau"] = (DateTime)tgLayMau;
                //        }

                //    }
                //}

                #endregion

                gcKetQua.DataSource = dtResult;
                bandedGridView1.ExpandAllGroups();

                //var danhsachKhoaXN = dtResult.DefaultView.ToTable(true, "MaBoPhan");
                //string dsKhoaXN = string.Empty;
                //foreach (DataRow drBp in danhsachKhoaXN.Rows)
                //{
                //    if (!string.IsNullOrEmpty(drBp["MaBoPhan"].ToString()))
                //    {
                //        dsKhoaXN += (string.IsNullOrEmpty(dsKhoaXN) ? "" : ", ");
                //        dsKhoaXN += drBp["MaBoPhan"].ToString();
                //    }
                //}
                //lblKhoa.Text = string.Format("{0}", dsKhoaXN);
                lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
                CustomMessageBox.CloseAlert();
            }
            else
            {
                var condit = getCondit();
                CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....", 8);
                var data = _iStatistic.ThongKeXetNghiem_TAT(condit);
                gcKetQua.DataSource = data;
                bandedGridView1.ExpandAllGroups();

                var danhsachKhoaXN = data.DefaultView.ToTable(true, "MaBoPhan");
                string dsKhoaXN = string.Empty;
                foreach (DataRow drBp in danhsachKhoaXN.Rows)
                {
                    if (!string.IsNullOrEmpty(drBp["MaBoPhan"].ToString()))
                    {
                        dsKhoaXN += (string.IsNullOrEmpty(dsKhoaXN) ? "" : ", ");
                        dsKhoaXN += drBp["MaBoPhan"].ToString();
                    }
                }
                lblKhoa.Text = string.Format("{0}", dsKhoaXN);
                lblNgayBaoCao.Text = string.Format(LanguageExtension.GetResourceValueFromValue("Từ ngày {0} đến ngày {1}",
                        LanguageExtension.AppLanguage), condit.TuNgay.ToString("dd/MM/yyyy HH:mm:ss"), condit.DenNgay.ToString("dd/MM/yyyy HH:mm:ss"));
                CustomMessageBox.CloseAlert();
            }
            
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(gcKetQua, string.Format("ThongKeTAT_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss"))
                , false, -1, -1, new string[]
                 {lblTitle.Text, lblNgayBaoCao.Text}, new int[] { 16, 13 },
                 new string[] { TenSYT, TenBV,  lblKhoa.Text});
        }

        private void ucThongKeTAT_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
