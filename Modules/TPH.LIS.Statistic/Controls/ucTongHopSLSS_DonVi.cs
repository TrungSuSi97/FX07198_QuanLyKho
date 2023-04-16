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

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopSLSS_DonVi : UserControl
    {
        public ucTongHopSLSS_DonVi()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var condit = getCondit();
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: Đơn vị tự đến.....", 8);
            condit.SumColumns = new List<string> { "NNCG6", "TGCDG6", "CDBG6", "NNCTSH", "TGCDTSH", "CDBTSH", "NNC17", "TGCD17", "CDB17" };
            var dataTD = _iStatistic.ThongXetNghiem_SLSS_DonVi_TuDen(condit);
            dataTD.Columns.Add("STT", typeof(int));
            dataTD = SetCaption(dataTD, bgvDonVi_TuDen);
            if (dataTD.Rows.Count > 0)
            {
                for (int i = 0; i < dataTD.Rows.Count; i++)
                {
                    dataTD.Rows[i]["STT"] = i + 1;
                }
            }
            gcDonVi_TuDen.DataSource = dataTD;
            bgvDonVi_TuDen.ExpandAllGroups();

            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu: Đon vị TG Chẩn đoán.....", 8);
            condit.SumColumns = new List<string> { "NNCG6", "TGCDG6", "CDBG6", "NNCTSH", "TGCDTSH", "CDBTSH", "NNC17", "TGCD17", "CDB17" };
            var dataTGCD = _iStatistic.ThongXetNghiem_SLSS_DonVi_TGChanDoan(condit);
            dataTGCD.Columns.Add("STT", typeof(int));
            dataTGCD = SetCaption(dataTGCD, bgvDonVi_TGCD);
            if (dataTGCD.Rows.Count > 0)
            {
                for (int i = 0; i < dataTGCD.Rows.Count; i++)
                {
                    dataTGCD.Rows[i]["STT"] = i + 1;
                }
            }
            gcDonVi_TGCD.DataSource = dataTGCD;
            bgvDonVi_TGCD.ExpandAllGroups();

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
            var dataTuDen = (DataTable)gcDonVi_TuDen.DataSource;
            var dataTGCD = (DataTable)gcDonVi_TGCD.DataSource;
            var condit = getCondit();
            Excel.ExportToExcel.Export_DataTable(new List<DataTable> { dataTuDen, dataTGCD }
            , new List<string> { "", ""}, string.Format("BÁO CÁO XÉT NGHIỆM THEO ĐƠN VỊ (TỔNG KẾT THÁNG {0}/{1})", condit.TuNgay.Month, condit.TuNgay.Year)
            , new List<string> { string.Format("Khoa XN-DTH báo cáo số liệu SLSS từ ngày {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}:", condit.TuNgay, condit.DenNgay) }
            , new List<string> { "BV PHỤ SẢN TP CẦN THƠ", "KHOA XÉT NGHIỆM - DTH" }
            , new List<string> { "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", "Độc Lập – Tự Do – Hạnh Phúc", string.Format("Cần Thơ, ngày {0:dd} tháng {0:MM} năm {0:yyyy}", DateTime.Now) }
            , new List<string> { "Người báo cáo: ________________________________    Chữ ký: ________________________________"
                                , "Người kiểm tra: ________________________________    Chữ ký: ________________________________"
                                , "Người tiếp nhận: _______________________________    Chữ ký: ________________________________"}
            , null
            );
        }

        private void ucTongHopSLSS_DonVi_Load(object sender, EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
