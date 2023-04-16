using System;
using System.Data;
using System.Windows.Forms;
using TPH.Controls;
using TPH.LIS.Patient.Constants;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucThongTinTheoDoiMauTheoBoPhan : UserControl
    {
        public ucThongTinTheoDoiMauTheoBoPhan()
        {
            InitializeComponent();
        }
        private DataTable _dataSource;
        public DataTable DataSource
        {
            get { return _dataSource; }
            set {
                _dataSource = value;
                CheckAndSetDataInfo();
            }
        }
        private void CheckAndSetDataInfo()
        {
            SetAllDataToWait();
            if (_dataSource != null)
            {
                if (_dataSource.Rows.Count > 0)
                {
                    //mội bộ phận 1 row
                    var dr = _dataSource.Rows[0];
                    pbNhapChiDinh.Image = imageList1.Images[4];
                    var tgNhap = DateTime.Parse(dr["ThoiGianNhap"].ToString());
                    lblTiepNhan.Text = string.Format("{0}\n{1}", lblTiepNhan.Text, tgNhap.ToString("HH:mm:ss\ndd/MM/yyyy"));
                    ucGroupHeader1.GroupCaption = String.Format("BỘ PHẬN: {0}", dr["TenBoPhan"].ToString());
                    var status = (enumTrangThaiLayMau)Enum.Parse(typeof(enumTrangThaiLayMau), dr["TrangThaiLayMau"].ToString());

                    if (status == enumTrangThaiLayMau.KhongXacDinh || status == enumTrangThaiLayMau.ChuaLayMau || status == enumTrangThaiLayMau.ChuaThucHien)
                    {
                        pbLayMau.Image = imageList1.Images[1];
                    }
                    else
                    {
                        if (status == enumTrangThaiLayMau.YeuCauLayLai)
                        {
                            pbLayMau.Image = imageList1.Images[2];
                        }
                        else
                        {
                            pbLayMau.Image = imageList1.Images[0];
                        }
                        if (!string.IsNullOrEmpty(dr["ThoiGianLayMau"].ToString()))
                        {
                            var tgLayMau = DateTime.Parse(dr["ThoiGianLayMau"].ToString());
                            lblLayMau.Text = string.Format("{0}\n{1}", lblLayMau.Text, tgLayMau.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }

                    var statusNM = (enumTrangThaiNhanMau)Enum.Parse(typeof(enumTrangThaiNhanMau), dr["TrangThaiNhanMau"].ToString());
                    if (statusNM == enumTrangThaiNhanMau.KhongXacDinh || statusNM == enumTrangThaiNhanMau.ChuaNhanMau || statusNM == enumTrangThaiNhanMau.ChuaThucHien)
                    {
                        pbNhanMau.Image = imageList1.Images[1];
                    }
                    else
                    {
                        if (statusNM == enumTrangThaiNhanMau.YeuCauLayLai)
                        {
                            pbNhanMau.Image = imageList1.Images[2];
                        }
                        else
                        {
                            pbNhanMau.Image = imageList1.Images[0];
                        }
                        if (!string.IsNullOrEmpty(dr["ThoiGianNhanMau"].ToString()))
                        {
                            var tgNhanMau = DateTime.Parse(dr["ThoiGianNhanMau"].ToString());
                            lblNhanMau.Text = string.Format("{0}\n{1}", lblNhanMau.Text, tgNhanMau.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }

                    if (bool.Parse(dr["DaChuyenMau"].ToString()))
                    {
                        pbChuyenMau.Image = imageList1.Images[0];
                        if (!string.IsNullOrEmpty(dr["ThoiGianChuyenMau"].ToString()))
                        {
                            var tgChuyenMau = DateTime.Parse(dr["ThoiGianChuyenMau"].ToString());
                            lblChuyenMau.Text = string.Format("{0}\n{1}", lblChuyenMau.Text, tgChuyenMau.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }

                    if (bool.Parse(dr["DaCoKetQua"].ToString()))
                    {
                        pbDaCoKetQua.Image = imageList1.Images[0];
                        if (!string.IsNullOrEmpty(dr["TGCoKetQua"].ToString()))
                        {
                            var tgCoKQ = DateTime.Parse(dr["TGCoKetQua"].ToString());
                            lblDCoKetQua.Text = string.Format("{0}\n{1}", lblDCoKetQua.Text, tgCoKQ.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }

                    if (bool.Parse(dr["DaDuKetQua"].ToString()))
                    {
                        pbDaDuKetQua.Image = imageList1.Images[0];
                        if (!string.IsNullOrEmpty(dr["ThoiGianDuKetQua"].ToString()))
                        {
                            var tgDuKQ = DateTime.Parse(dr["ThoiGianDuKetQua"].ToString());
                            lblDaDu.Text = string.Format("{0}\n{1}", lblDaDu.Text, tgDuKQ.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }
                    if (bool.Parse(dr["DaXacNhanKetQua"].ToString()))
                    {
                        pbDaDuyet.Image = imageList1.Images[0];
                        if (!string.IsNullOrEmpty(dr["ThoiGianXacNhan"].ToString()))
                        {
                            var tgDuyetKQ = DateTime.Parse(dr["ThoiGianXacNhan"].ToString());
                            lblDaDuyet.Text = string.Format("{0}\n{1}", lblDaDuyet.Text, tgDuyetKQ.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }

                    if (bool.Parse(dr["DaInKetQua"].ToString()))
                    {
                        pbDaIn.Image = imageList1.Images[0];
                        if (!string.IsNullOrEmpty(dr["ThoiGianInLanDau"].ToString()))
                        {
                            var tgin = DateTime.Parse(dr["ThoiGianInLanDau"].ToString());
                            lblDaIn.Text = string.Format("{0}\n{1}", lblDaIn.Text, tgin.ToString("HH:mm:ss\ndd/MM/yyyy"));
                        }
                    }

                    if (!string.IsNullOrEmpty(dr["TgChuyenKQLanDau"].ToString()))
                    {
                        pbGuiKetQua.Image = imageList1.Images[0];
                        var tgGui = DateTime.Parse(dr["TgChuyenKQLanDau"].ToString());
                        lblGuiKetQua.Text = string.Format("{0}\n{1}", lblGuiKetQua.Text, tgGui.ToString("HH:mm:ss\ndd/MM/yyyy"));
                    }

                    if (!string.IsNullOrEmpty(dr["TgNhanKQLanDau"].ToString()))
                    {
                        pbNhanKetQua.Image = imageList1.Images[6];
                        var tgNhan = DateTime.Parse(dr["TgNhanKQLanDau"].ToString());
                        lblNhanKetQua.Text = string.Format("{0}\n{1}", lblNhanKetQua.Text, tgNhan.ToString("HH:mm:ss\ndd/MM/yyyy"));
                    }
                    //, bx.TgChuyenKQLanDau, bx.NguoiChuyenKQ, bx.TgNhanKQLanDau, bx.NguoiNhanketQua, bp.ThoiGianInLanDau, bp.UserInLanDau, bp.DaInKetQua
                }
            }
        }
        private void SetAllDataToWait()
        {
            lblTiepNhan.Text = "Nhập chỉ định".ToUpper();
            lblLayMau.Text = "Lấy mẫu".ToUpper();
            lblChuyenMau.Text = "Chuyển mẫu".ToUpper();
            lblNhanMau.Text = "Nhận mẫu".ToUpper();
            lblDCoKetQua.Text = "Đã có kết quả".ToUpper();
            lblDaDu.Text = "Đã đủ kết quả".ToUpper();
            lblDaDuyet.Text = "Đã duyệt".ToUpper();

            lblDaIn.Text = "Đã in".ToUpper();
            lblGuiKetQua.Text = "Đã gửi kết quả".ToUpper();
            lblNhanKetQua.Text = "Đã nhận kết quả".ToUpper();


            pbNhapChiDinh.Image = imageList1.Images[3];
            pbLayMau.Image = imageList1.Images[1];
            pbChuyenMau.Image = imageList1.Images[1];
            pbNhanMau.Image = imageList1.Images[1];
            pbDaCoKetQua.Image = imageList1.Images[1];
            pbDaDuKetQua.Image = imageList1.Images[1];

            pbDaDuyet.Image = imageList1.Images[1];
            pbDaIn.Image = imageList1.Images[1];
            pbGuiKetQua.Image = imageList1.Images[1];
            pbNhanKetQua.Image = imageList1.Images[5];
        }
    }
}
