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
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using DevExpress.Utils;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucTongHopBenhNhan_DoiTuong : UserControl
    {
        public ucTongHopBenhNhan_DoiTuong()
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
              //  colTongTienBN.Visible = value;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var c = 6;
            while (gvXnDoiTuong.Columns.Count > c)
            {
                gvXnDoiTuong.Columns.RemoveAt(c);
            }
            gcXnDoiTuong.DataSource = null;
            CustomMessageBox.ShowAlert("Đang tổng hợp số liệu.....");
            var condit = getCondit();
            var dtTemp = _iStatistic.ThongXetNghiemThucHien_DoiTuong(condit);
            CustomMessageBox.ShowAlert("Đang xử lý số liệu.....\n   Tính số lượng xét nhiệm.");
            var dataResult = dtTemp.DefaultView.ToTable(true, new string[] { "SapXep", "MaXN", "TenXN", "MaBoPhan", "ThuTuIn", "IsCate", "NguoiXacNhan", "NVThucHien", "TuNgay", "DenNgay" });
            dataResult.DefaultView.Sort = "MaBoPhan asc,NguoiXacNhan asc, ThuTuIn asc, SapXep asc , MaXN";

            var dataNhomDoiTuong = sysConfig.Get_NhomDoiTuongDichVu(true);
            var manhomdv = string.Empty;
            var tenhnhomDv = string.Empty;

            dataResult = dataResult.DefaultView.ToTable();

            foreach (DataRow drNh in dataNhomDoiTuong.Rows)
            {
                manhomdv = drNh["MaNhomDoiTuong"].ToString().Trim();
                tenhnhomDv = drNh["TenNhomDoiTuong"].ToString().Trim();

                dataResult.Columns.Add(manhomdv, typeof(double));
                ControlExtension.InsertNewColToGrid(gvXnDoiTuong, manhomdv, tenhnhomDv, 100, null, null, FormatType.Numeric, "{0:N0}", true);
            }
            dataResult.Columns.Add("SoLuong", typeof(double));

            double sum = 0;
            double slTemp = 0;
            foreach (DataRow dr in dataResult.Rows)
            {
                CustomMessageBox.ShowAlert(string.Format("Đang xử lý số liệu.....\n   Nhân viên xác nhận: {0) - Xét nghiệm: {1}.", dr["NguoiXacNhan"].ToString().Trim(), dr["MaXN"].ToString().Trim()));
                sum = 0;
                var dataSelect = WorkingServices.SearchResult_OnDatatable_NoneSort(dtTemp, string.Format("MaXn = '{0}' and NguoiXacNhan = '{1}'", dr["MaXN"].ToString().Trim(), dr["NguoiXacNhan"].ToString().Trim()));
                for (int i = 0; i < dataSelect.Rows.Count; i++)
                {
                    foreach (DataRow drNh in dataNhomDoiTuong.Rows)
                    {
                        slTemp = 0;
                        manhomdv = drNh["MaNhomDoiTuong"].ToString().Trim();
                        tenhnhomDv = drNh["TenNhomDoiTuong"].ToString().Trim();
                        if (dataSelect.Rows[i]["MaNhomDoiTuong"].ToString().Trim().Equals(manhomdv, StringComparison.OrdinalIgnoreCase))
                        {
                            slTemp = double.Parse(dataSelect.Rows[i]["SoLuong"].ToString().Equals("") ? "0" : dataSelect.Rows[i]["SoLuong"].ToString());
                            dr[manhomdv] = double.Parse(dr[manhomdv].ToString().Equals("") ? "0" : dr[manhomdv].ToString()) + slTemp;
                            sum += slTemp;
                            break;
                        }   
                    }
                }
                dr["SoLuong"] = sum;
            }
            dataResult.AcceptChanges();
            gcXnDoiTuong.DataSource = dataResult;
            gvXnDoiTuong.ExpandAllGroups();
            CustomMessageBox.CloseAlert();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel.Export(gcXnDoiTuong, string.Format("SoLuongXetnghiem_BenhNhan_DoiDuong_{0}", DateTime.Now.ToString("ddMMyyyyHHmmss")));
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            print(LoaiReport.DoiTuongBenhNhan, (DataTable)gcXnDoiTuong.DataSource);
        }
    }
}
