using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.Common.Controls;
using DevExpress.XtraGrid.Views.Grid;
using TPH.LIS.Common.Extensions;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopSLSS : UserControl
    {
        public ucTongHopSLSS()
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
            condit.SumColumns = new List<string> { "SLSS3Benh","SLSS3Benh_Moi" };
            var data = _iStatistic.ThongXetNghiem_SLSS_XHH_NoiVien_SoLuong(condit);
            if (data.Rows.Count > 0)
            {
                var dr = data.NewRow();
                dr["SLSS3Benh"] = Convert.ToDouble(data.Compute("Sum(SLSS3Benh)", string.Empty));
                dr["SLSS3Benh_Moi"] = Convert.ToDouble(data.Compute("Sum(SLSS3Benh_Moi)", string.Empty)); 
                dr["NoiGui"] = "Tổng số";
                data.Rows.Add(dr);
            }
            data = SetCaption(data, gvNoiVien_SoLuong);
            gcNoiVien_SoLuong.DataSource = data;
            gvNoiVien_SoLuong.ExpandAllGroups();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: Nguy cơ cao Nội viện.....", 8);
            condit.SumColumns = new List<string> { "SoLuong", "XetNghiemLan2","NguyCoCao" , "NCCLan2", "ThamGiaChanDoan", "ChanDoanBenh" };
            var dataNCC = _iStatistic.ThongXetNghiem_SLSS_XHH_NoiVien_NCC(condit);
            if (dataNCC.Rows.Count > 0)
            {
                var dr = dataNCC.NewRow();
                dr["SoLuong"] = Convert.ToDouble(dataNCC.Compute("Sum(SoLuong)", string.Empty));
                dr["XetNghiemLan2"] = Convert.ToDouble(dataNCC.Compute("Sum(XetNghiemLan2)", string.Empty));
                dr["NCCLan2"] = Convert.ToDouble(dataNCC.Compute("Sum(NCCLan2)", string.Empty));
                dr["ChanDoanBenh"] = Convert.ToDouble(dataNCC.Compute("Sum(ChanDoanBenh)", string.Empty));
                dr["ThamGiaChanDoan"] = Convert.ToDouble(dataNCC.Compute("Sum(ThamGiaChanDoan)", string.Empty));
                dr["NoiGui"] = "Tổng số";
                dataNCC.Rows.Add(dr);
            }
            dataNCC = SetCaption(dataNCC, gvNoiVien_NCC);
            gcNoiVien_NCC.DataSource = dataNCC;
            gvNoiVien_NCC.ExpandAllGroups();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: SLSS Nội viện.....", 8);
            condit.SumColumns = new List<string> { "SoLuong","NCCG6", "TGCDG6", "CDBG6", "NCCTSH", "TGCDTSH", "CDBTSH", "NCC17", "TGCD17", "CDB17" };
            var dataNV = _iStatistic.ThongXetNghiem_SLSS_MienPhi_NoiVien(condit);
            dataNV.Columns.Add("STT", typeof(int));
            dataNV = SetCaption(dataNV, bgvSLSSMienPhi);
            if(dataNV.Rows.Count >0)
            {
                dataNV.Columns["STT"].SetOrdinal(0);
                for (int i = 0; i < dataNV.Rows.Count; i++)
                {
                    dataNV.Rows[i]["STT"] = i + 1;
                }
            }
            gcSLSSMienPhiNoiVien.DataSource = dataNV;
            bgvSLSSMienPhi.ExpandAllGroups();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: SLSS Ngoại viện.....", 8);
            condit.SumColumns = new List<string> { "Goi2", "Goi3", "Goi4", "Goi5", "NCCG6", "TGCDG6", "CDBG6", "NCCTSH", "TGCDTSH", "CDBTSH", "NCC17", "TGCD17", "CDB17"};
            var dataNN = _iStatistic.ThongXetNghiem_SLSS_MienPhi_NgoaiVien(condit);
            dataNN.Columns.Add("STT", typeof(int));
            dataNN = SetCaption(dataNN, bgvSLSSMienPhiNgoaiVien);
            if (dataNN.Rows.Count > 0)
            {
                dataNN.Columns["STT"].SetOrdinal(0);
                for (int i = 0; i < dataNN.Rows.Count; i++)
                {
                    dataNN.Rows[i]["STT"] = i + 1;
                }
            }
            gcNgoaiVien.DataSource = dataNN;
            bgvSLSSMienPhiNgoaiVien.ExpandAllGroups();
            CustomMessageBox.CloseAlert();
        }
        private DataTable SetCaption(DataTable dataSource, GridView gv)
        {
            foreach (GridColumn item in gv.Columns)
            {
                if (dataSource.Columns.Contains(item.FieldName))
                {
                    dataSource.Columns[item.FieldName].Caption = item.Caption;
                    if (item.Visible)
                        dataSource.Columns[item.FieldName].SetOrdinal(item.VisibleIndex);
                }
            }

            return dataSource;
        }
        private DataTable SetCaption(DataTable dataSource, BandedGridView gv)
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
            if (gcNgoaiVien.DataSource != null && gcNoiVien_SoLuong.DataSource != null && gcNoiVien_NCC.DataSource != null && gcSLSSMienPhiNoiVien.DataSource != null)
            {
                var DataSLNgoai = (DataTable)gcNgoaiVien.DataSource;
                var dataTinh = DataSLNgoai.DefaultView.ToTable(true, "TenTinh");
                var dataFinal = DataSLNgoai.Clone();
                dataFinal.Columns.Remove("TenTinh");
                var Goi2 = (double)0;
                var Goi3 = (double)0;
                //var Goi4 = (double)0;
                var Goi5 = (double)0;
                var NCCG6 = (double)0;
                var TGCDG6 = (double)0;
                var CDBG6 = (double)0;
                var NCCTSH = (double)0;
                var TGCDTSH = (double)0;
                var CDBTSH = (double)0;
                var NCC17 = (double)0;
                var TGCD17 = (double)0;
                var CDB17 = (double)0;
                foreach (DataRow drTinh in dataTinh.Rows)
                {

                    var dataFound = WorkingServices.SearchResult_OnDatatable(DataSLNgoai, string.Format("TenTinh = '{0}'", drTinh["TenTinh"]));
                    if (dataFound.Rows.Count > 0)
                    {
                        //"Goi2", "Goi3", "Goi4", "Goi5", "NCCG6", "TGCDG6", "CDBG6", "NCCTSH", "TGCDTSH", "CDBTSH", "NCC17", "TGCD17", "CDB17"
                        var tempGoi2 = double.Parse(dataFound.Compute("Sum(Goi2)", string.Empty).ToString());
                        var tempGoi3 = double.Parse(dataFound.Compute("Sum(Goi3)", string.Empty).ToString());
                     //   var tempGoi4 = double.Parse(dataFound.Compute("Sum(Goi4)", string.Empty).ToString());
                        var tempGoi5 = double.Parse(dataFound.Compute("Sum(Goi5)", string.Empty).ToString());
                        var tempNCCG6 = double.Parse(dataFound.Compute("Sum(NCCG6)", string.Empty).ToString());
                        var tempTGCDG6 = double.Parse(dataFound.Compute("Sum(TGCDG6)", string.Empty).ToString());
                        var tempCDBG6 = double.Parse(dataFound.Compute("Sum(CDBG6)", string.Empty).ToString());
                        var tempNCCTSH = double.Parse(dataFound.Compute("Sum(NCCTSH)", string.Empty).ToString());
                        var tempTGCDTSH = double.Parse(dataFound.Compute("Sum(TGCDTSH)", string.Empty).ToString());
                        var tempCDBTSH = double.Parse(dataFound.Compute("Sum(CDBTSH)", string.Empty).ToString());
                        var tempNCC17 = double.Parse(dataFound.Compute("Sum(NCC17)", string.Empty).ToString());
                        var tempTGCD17 = double.Parse(dataFound.Compute("Sum(TGCD17)", string.Empty).ToString());
                        var tempCDB17 = double.Parse(dataFound.Compute("Sum(CDB17)", string.Empty).ToString());

                        var ro = dataFinal.NewRow();
                        ro["TenKhoaPhong"] = drTinh["TenTinh"];
                        ro["Goi2"] = tempGoi2;
                        ro["Goi3"] = tempGoi3;
                       // ro["Goi4"] = tempGoi4;
                        ro["Goi5"] = tempGoi5;
                        ro["NCCG6"] = tempNCCG6;
                        ro["TGCDG6"] = tempTGCDG6;
                        ro["CDBG6"] = tempCDBG6;
                        ro["NCCTSH"] = tempNCCTSH;
                        ro["TGCDTSH"] = tempTGCDTSH;
                        ro["CDBTSH"] = tempCDBTSH;
                        ro["NCC17"] = tempNCC17;
                        ro["TGCD17"] = tempTGCD17;
                        ro["CDB17"] = tempCDB17;

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
                        Goi2 += tempGoi2;
                        Goi3 += tempGoi3;
                        //Goi4 += tempGoi4;
                        Goi5 += tempGoi5;
                        NCCG6 += tempNCCG6;
                        TGCDG6 += tempTGCDG6;
                        CDBG6 += tempCDBG6;
                        NCCTSH += tempNCCTSH;
                        TGCDTSH += tempTGCDTSH;
                        CDBTSH += tempCDBTSH;
                        NCC17 += tempNCC17;
                        TGCD17 += tempTGCD17;
                        CDB17 += tempCDB17;
                    }
                }
                var roE = dataFinal.NewRow();
                roE["TenKhoaPhong"] = "Tổng";
                roE["Goi2"] = Goi2;
                roE["Goi3"] = Goi3;
               // roE["Goi4"] = Goi4;
                roE["Goi5"] = Goi5;
                roE["NCCG6"] = NCCG6;
                roE["TGCDG6"] = TGCDG6;
                roE["CDBG6"] = CDBG6;
                roE["NCCTSH"] = NCCTSH;
                roE["TGCDTSH"] = TGCDTSH;
                roE["CDBTSH"] = CDBTSH;
                roE["NCC17"] = NCC17;
                roE["TGCD17"] = TGCD17;
                roE["CDB17"] = CDB17;
                dataFinal.Rows.Add(roE);
                var condit = getCondit();
                Excel.ExportToExcel.Export_DataTable(new List<DataTable> {
                    (DataTable)gcNoiVien_SoLuong.DataSource
                    , (DataTable)gcNoiVien_NCC.DataSource
                    , (DataTable)gcSLSSMienPhiNoiVien.DataSource
                    , dataFinal }
                , new List<string> { "I.          Mẫu SLSS Xã hội hóa Nội viện", "", "II.         Mẫu SLSS Miễn phí", "III.        Mẫu SLSS xã hội hóa ngoại viện (XHH)" }
                , string.Format("BÁO CÁO SỐ LIỆU SÀNG LỌC SƠ SINH THÁNG {0} NĂM {1}", condit.TuNgay.Month, condit.TuNgay.Year)
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

        private void ucTongHopSLSS_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
