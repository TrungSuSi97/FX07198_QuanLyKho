using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Statistic.Models;
using TPH.LIS.Statistic.Service;
using TPH.LIS.App.AppCode;
using TPH.LIS.Statistic.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopBenhNhan_KhoaPhong : UserControl
    {
        public ucTongHopBenhNhan_KhoaPhong()
        {
            InitializeComponent();
        }
        private readonly IStatisticService _iStatistic = new StatisticService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public delegate NormalStatisticCondit GetCondit();
        public event GetCondit getCondit;
        public delegate void PrintReport(LoaiReport id, DataTable dataSource);
        public event PrintReport print;
        public bool ShowMoney
        {
            get
            {
                return false;// colTongTienBN.Visible;
            }
            set
            {
                //colTongTienBN.Visible = value;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var c = 5;
            while (bandedGridView1.Columns.Count > c)
            {
                bandedGridView1.Columns.RemoveAt(c);
            }
            c = 1;
            while (bandedGridView1.Bands.Count > c)
            {
                bandedGridView1.Bands.RemoveAt(c);
            }
            gcThongKeTheoKhoa.DataSource = null;

            gridBand1.Width = 415;
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var condit = getCondit();
            var dtTemp = _iStatistic.TK_XetNghiem_BenhNhan_ThucHien_Khoa(condit);
            CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Tính số lượng khoa phòng.");
            var dataResult = dtTemp.DefaultView.ToTable(true, new string[] { "MaBoPhan", "TenBoPhan", "MaKhoaPhong", "TenKhoaPhong", "IsCate", "TuNgay", "DenNgay" });
            dataResult.DefaultView.Sort = "MaBoPhan desc,MaKhoaPhong asc";

            var dataNhomDoiTuong = sysConfig.Get_NhomDoiTuongDichVu(true);
            var manhomdv = string.Empty;
            var tenhnhomDv = string.Empty;

            dataResult = dataResult.DefaultView.ToTable();
            dataResult.Columns.Add("STT", typeof(int));
            GridBand bandUngroupped = new GridBand();
            bandUngroupped.Caption = "Số lượng theo bệnh nhân";
            bandedGridView1.Bands.Add(bandUngroupped);
            CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Thêm các cột cho thống kê.");
            //Add đối tượng cho bn
            foreach (DataRow drNh in dataNhomDoiTuong.Rows)
            {
                manhomdv = string.Format("{0}_{1}", drNh["MaNhomDoiTuong"].ToString().Trim(), "BN");
                tenhnhomDv = drNh["TenNhomDoiTuong"].ToString().Trim();

                dataResult.Columns.Add(manhomdv, typeof(double));
                ControlExtension.InsertNewColToGrid(bandedGridView1, manhomdv, tenhnhomDv, 100, null, null, FormatType.Numeric, "{0:N0}", true);
                bandedGridView1.Columns[bandedGridView1.Columns.Count - 1].OwnerBand = bandUngroupped;
            }
            dataResult.Columns.Add("SoLuong_BN", typeof(double));
            ControlExtension.InsertNewColToGrid(bandedGridView1, "SoLuong_BN", "Số lượng BN", 100, null, null, FormatType.Numeric, "{ 0:N0}", true);
            bandedGridView1.Columns[bandedGridView1.Columns.Count - 1].OwnerBand = bandUngroupped;
            //Add đối tượng cho test
            GridBand bandUngroupped2 = new GridBand();
            bandUngroupped2.Caption = "Số lượng theo xét nghiệm";
            bandedGridView1.Bands.Add(bandUngroupped2);
            foreach (DataRow drNh in dataNhomDoiTuong.Rows)
            {
                manhomdv = string.Format("{0}_{1}", drNh["MaNhomDoiTuong"].ToString().Trim(), "XN");
                tenhnhomDv = drNh["TenNhomDoiTuong"].ToString().Trim();

                dataResult.Columns.Add(manhomdv, typeof(double));
                ControlExtension.InsertNewColToGrid(bandedGridView1, manhomdv, tenhnhomDv, 100, null, null, FormatType.Numeric, "{0:N0}", true);
                bandedGridView1.Columns[bandedGridView1.Columns.Count - 1].OwnerBand = bandUngroupped2;
            }
            dataResult.Columns.Add("SoLuong_XN", typeof(double));
            ControlExtension.InsertNewColToGrid(bandedGridView1, "SoLuong_XN", "Số lượng XN", 100, null, null, FormatType.Numeric, "{0:N0}", true);
            bandedGridView1.Columns[bandedGridView1.Columns.Count - 1].OwnerBand = bandUngroupped2;
            dataResult.AcceptChanges();
            double sumBN = 0, sumXN = 0;
            int rowsCount = 0;
            foreach (DataRow dr in dataResult.Rows)
            {
                rowsCount++;
                sumBN = 0;
                sumXN = 0;
                var boPhan = dr["MaBoPhan"].ToString().Trim();
                var tenKhoaPhong = dr["TenKhoaPhong"].ToString().Trim();

                CustomMessageBox.ShowAlert(string.Format("Đang xử lý số liệu.....\n   Bộ phận {0) - Khoa: {1}.", boPhan, tenKhoaPhong));

                var dataSelect = WorkingServices.SearchResult_OnDatatable_NoneSort(dtTemp, string.Format("MaKhoaPhong = '{0}' and {1} "
                    , dr["MaKhoaPhong"].ToString().Trim()
                    , (string.IsNullOrEmpty(boPhan) ? " MaBoPhan is null" : string.Format("MaBoPhan = '{0}'", boPhan))));
        
                foreach (DataRow drNh in dataNhomDoiTuong.Rows)
                {
                    var manhomdvBN = string.Format("{0}_{1}", drNh["MaNhomDoiTuong"].ToString().Trim(), "BN");
                    var manhomdvXN = string.Format("{0}_{1}", drNh["MaNhomDoiTuong"].ToString().Trim(), "XN");
                    tenhnhomDv = drNh["TenNhomDoiTuong"].ToString().Trim();

                    var dataCount = WorkingServices.SearchResult_OnDatatable_NoneSort(dataSelect, string.Format("MaNhomDoiTuong = '{0}'", drNh["MaNhomDoiTuong"].ToString().Trim()));
                    if (dataCount.Rows.Count > 0)
                    {
                        var distincMatiepNhanCount = dataCount.DefaultView.ToTable(true, "MaTiepNhan");
                        dr[manhomdvBN] = distincMatiepNhanCount.Rows.Count;
                        dr[manhomdvXN] = (double)dataCount.Compute("sum (SoLuong)", " SoLuong > 0");
                    }
                    else
                    {
                        dr[manhomdvBN] = 0;
                        dr[manhomdvXN] = 0;
                    }
                    sumBN += (double)dr[manhomdvBN]; ;
                    sumXN += (double)dr[manhomdvXN];

                }
                dr["SoLuong_BN"] = sumBN;
                dr["SoLuong_XN"] = sumXN;
                dr["STT"] = rowsCount;
            }
            dataResult.AcceptChanges();
            gcThongKeTheoKhoa.DataSource = dataResult;
            bandedGridView1.ExpandAllGroups();
            CustomMessageBox.CloseAlert();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gcThongKeTheoKhoa, string.Format("SoLuongXetnghiem_BenhNhan_Khoa{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            print(LoaiReport.KhoaPhong, (DataTable)gcThongKeTheoKhoa.DataSource);
        }
    }
}
