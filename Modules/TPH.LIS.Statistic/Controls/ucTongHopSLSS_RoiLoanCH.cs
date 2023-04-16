using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Controls;
using DevExpress.XtraGrid.Views.Grid;
using TPH.Language;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopSLSS_RoiLoanCH : UserControl
    {
        public ucTongHopSLSS_RoiLoanCH()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var condit = getCondit();
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: SLSS Nội viện.....", 8);
            condit.SumColumns = new List<string> { "SoLuong" };
            var data = _iStatistic.ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_SoLuong(condit);
            if (data.Rows.Count > 0)
            {
                var sum = Convert.ToDouble(data.Compute("Sum(SoLuong)", string.Empty));
                var dr = data.NewRow();
                dr["SoLuong"] = sum;
                dr["NoiGui"] = "Tổng số";
                data.Rows.Add(dr);
            }
            data = SetCaption(data, gvNoiVien_SoLuong);
            gcNoiVien_SoLuong.DataSource = data;
            gvNoiVien_SoLuong.ExpandAllGroups();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: Nguy cơ cao Nội viện.....", 8);
            condit.SumColumns = new List<string> { "SoLuong", "Lan2", "ThamGiaChanDoan", "ChanDoanBenh" };
            var dataNCC = _iStatistic.ThongXetNghiem_SLSS_RLCH_XHH_NoiVien_NCC(condit);
            dataNCC = SetCaption(dataNCC, gvNoiVien_NCC);
            gcNoiVien_NCC.DataSource = dataNCC;
            gvNoiVien_NCC.ExpandAllGroups();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: SLSS Ngoại viện.....", 8);
            condit.SumColumns = new List<string> { "NguyCoCao", "Lan2", "ThamGiaChanDoan", "ChanDoanBenh", "ThucHien" };
            var dataNN = _iStatistic.ThongXetNghiem_SLSS_RLCH_XHH_NgoaiVien(condit);
            dataNN = SetCaption(dataNN, gvNgoaiVien);
            gcNgoaiVien.DataSource = dataNN;
            gvNgoaiVien.ExpandAllGroups();

            CustomMessageBox.CloseAlert();
        }
        private DataTable SetCaption(DataTable dataSource, GridView gv)
        {
            foreach (DataColumn dtc in dataSource.Columns)
            {
                var title = gv.Columns.Where(x => x.FieldName.Equals(dtc.ColumnName, StringComparison.OrdinalIgnoreCase));
                if (title.Any())
                {
                    dtc.Caption = title.First().Caption;
                }
            }
            return dataSource;
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (gcNgoaiVien.DataSource != null && gcNoiVien_SoLuong.DataSource != null && gcNoiVien_NCC.DataSource != null)
            {
                var DataSLNgoai = (DataTable)gcNgoaiVien.DataSource;
                var dataTinh = DataSLNgoai.DefaultView.ToTable(true, "TenTinh");
                var dataFinal = DataSLNgoai.Clone();
                dataFinal.Columns.Remove("TenTinh");
                var ThucHien = (double)0;
                var NguyCoCao = (double)0;
                var Lan2 = (double)0;
                var ThamGiaChanDoan = (double)0;
                var ChanDoanBenh = (double)0;

                foreach (DataRow drTinh in dataTinh.Rows)
                {

                    var dataFound = WorkingServices.SearchResult_OnDatatable(DataSLNgoai, string.Format("TenTinh = '{0}'", drTinh["TenTinh"]));
                    if (dataFound.Rows.Count > 0)
                    {
                        var tempThucHien = double.Parse(dataFound.Compute("Sum(ThucHien)", string.Empty).ToString());
                        var tempNguyCoCao = double.Parse(dataFound.Compute("Sum(NguyCoCao)", string.Empty).ToString());
                        var tempLan2 = double.Parse(dataFound.Compute("Sum(Lan2)", string.Empty).ToString());
                        var tempThamGiaChanDoan = double.Parse(dataFound.Compute("Sum(ThamGiaChanDoan)", string.Empty).ToString());
                        var tempChanDoanBenh = double.Parse(dataFound.Compute("Sum(ChanDoanBenh)", string.Empty).ToString());
                        var ro = dataFinal.NewRow();
                        ro["TenKhoaPhong"] = drTinh["TenTinh"];
                        ro["ThucHien"] = tempThucHien;
                        ro["NguyCoCao"] = tempNguyCoCao;
                        ro["Lan2"] = tempLan2;
                        ro["ThamGiaChanDoan"] = tempThamGiaChanDoan;
                        ro["ChanDoanBenh"] = tempChanDoanBenh;
                        dataFinal.Rows.Add(ro);
                        foreach (DataRow drK in dataFound.Rows)
                        {
                            var drAdd = dataFinal.NewRow();
                            foreach (DataColumn dtc in dataFinal.Columns)
                            {
                                drAdd[dtc.ColumnName] = drK[dtc.ColumnName];
                            }
                            dataFinal.Rows.Add(drAdd);
                        }

                        ThucHien += tempThucHien;
                        NguyCoCao += tempNguyCoCao;
                        Lan2 += tempLan2;
                        ThamGiaChanDoan += tempThamGiaChanDoan;
                        ChanDoanBenh += tempChanDoanBenh;
                    }
                }
                var roE = dataFinal.NewRow();
                roE["TenKhoaPhong"] = "Tổng";
                roE["ThucHien"] = ThucHien;
                roE["NguyCoCao"] = NguyCoCao;
                roE["Lan2"] = Lan2;
                roE["ThamGiaChanDoan"] = ThamGiaChanDoan;
                roE["ChanDoanBenh"] = ChanDoanBenh;
                dataFinal.Rows.Add(roE);
                var condit = getCondit();
                Excel.ExportToExcel.Export_DataTable(new List<DataTable> { (DataTable)gcNoiVien_SoLuong.DataSource, (DataTable)gcNoiVien_NCC.DataSource, dataFinal }
                , new List<string> { "I.     Mẫu SLSS Xã hội hóa nội viện", "", "II.    Mẫu SLSS Xã hội hóa Ngoại viện" }, string.Format("BÁO CÁO RỐI LOẠN CHUYỂN HÓA (TỔNG KẾT THÁNG {0}/{1})", condit.TuNgay.Month, condit.TuNgay.Year)
                , new List<string> { "Kính gửi: Trung Tâm Sàng lọc – Chẩn đoán Trước sinh & Sơ sinh", string.Format("Khoa XN-DTH báo cáo số liệu SLSS từ ngày {0:dd/MM/yyyy} đến {1:dd/MM/yyyy} ngày như sau:", condit.TuNgay, condit.DenNgay) }
                , new List<string> { "BV PHỤ SẢN TP CẦN THƠ", "KHOA XÉT NGHIỆM - DTH" }
                , new List<string> { "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", "Độc Lập – Tự Do – Hạnh Phúc", string.Format("Cần Thơ, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Now) }
                , new List<string> { "Người báo cáo: ________________________________    Chữ ký: ________________________________"
                                , "Người kiểm tra: ________________________________    Chữ ký: ________________________________"
                                , "Người tiếp nhận: _______________________________    Chữ ký: ________________________________"}
                , null
                );
            }
        }

        private void ucTongHopSLSS_RoiLoanCH_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
