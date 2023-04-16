using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Configuration.Models;
using TPH.Controls;
using DevExpress.XtraEditors;

namespace TPH.LIS.App.AppCode
{
    public partial class ucPatientInformation : UserControl
    {
        public ucPatientInformation()
        {
            InitializeComponent();
        }
        public string MaTiepNhan = string.Empty;
        private readonly IPatientInformationService informationService = new PatientInformationService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        
        private BENHNHAN_TIEPNHAN objBenhnhanTiepnhan;

        public DataTable DataShowConfig()
        {
            var data = new DataTable();
            data.Columns.Add("IdHienThi", typeof(string));
            data.Columns.Add("MoTa", typeof(string));
            data.Columns.Add("SapXep", typeof(int));
            data.Columns.Add("HienThi", typeof(string));
            data.Columns.Add("DoRong", typeof(int));

            var dataRow = data.NewRow();
            dataRow["IdHienThi"] = "pnNgay";
            dataRow["MoTa"] = "Ngày tiếp nhận - BHYT";
            dataRow["SapXep"] = 1;
            dataRow["HienThi"] = pnNgay.Visible;
            dataRow["DoRong"] = pnNgay.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = "pnSoPhieu";
            dataRow["MoTa"] = "Số hS - Số phiếu";
            dataRow["SapXep"] = 2;
            dataRow["HienThi"] = pnSoPhieu.Visible;
            dataRow["DoRong"] = pnSoPhieu.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = "pnMaTiepNhan";
            dataRow["MoTa"] = "SID - Mã BN";
            dataRow["SapXep"] = 3;
            dataRow["HienThi"] = pnMaTiepNhan.Visible;
            dataRow["DoRong"] = pnMaTiepNhan.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = "pnHoTen";
            dataRow["MoTa"] = "Họ tên";
            dataRow["SapXep"] = 4;
            dataRow["HienThi"] = pnHoTen.Visible;
            dataRow["DoRong"] = pnHoTen.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnGioiTinh.Name;
            dataRow["MoTa"] = "Giới tinh - năm sinh";
            dataRow["SapXep"] = 5;
            dataRow["HienThi"] = pnGioiTinh.Visible;
            dataRow["DoRong"] = pnGioiTinh.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnDiaChi.Name;
            dataRow["MoTa"] = "Địa chỉ";
            dataRow["SapXep"] = 5;
            dataRow["HienThi"] = pnDiaChi.Visible;
            dataRow["DoRong"] = pnDiaChi.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnDoiTuong.Name;
            dataRow["MoTa"] = "Đối tượng";
            dataRow["SapXep"] = 6;
            dataRow["HienThi"] = pnDoiTuong.Visible;
            dataRow["DoRong"] = pnDoiTuong.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnEmail.Name;
            dataRow["MoTa"] = "Email - Điện thoại";
            dataRow["SapXep"] = 7;
            dataRow["HienThi"] = pnEmail.Visible;
            dataRow["DoRong"] = pnEmail.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnBS.Name;
            dataRow["MoTa"] = "1 Bác Sĩ chỉ định";
            dataRow["SapXep"] = 8;
            dataRow["HienThi"] = pnBS.Visible;
            dataRow["DoRong"] = pnBS.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnListBSChiDinh.Name;
            dataRow["MoTa"] = "Nhiều Bác Sĩ chỉ định";
            dataRow["SapXep"] = 9;
            dataRow["HienThi"] = pnListBSChiDinh.Visible;
            dataRow["DoRong"] = pnListBSChiDinh.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnBacSiDienThoai.Name;
            dataRow["MoTa"] = "1 Bác Sĩ chỉ định - SDT";
            dataRow["SapXep"] = 10;
            dataRow["HienThi"] = pnBacSiDienThoai.Visible;
            dataRow["DoRong"] = pnBacSiDienThoai.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnKhoaPhong.Name;
            dataRow["MoTa"] = "1 Khoa phòng";
            dataRow["SapXep"] = 11;
            dataRow["HienThi"] = pnKhoaPhong.Visible;
            dataRow["DoRong"] = pnKhoaPhong.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnListKhoaChiDinh.Name;
            dataRow["MoTa"] = "Nhiều Khoa phòng";
            dataRow["SapXep"] = 12;
            dataRow["HienThi"] = pnListKhoaChiDinh.Visible;
            dataRow["DoRong"] = pnListKhoaChiDinh.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnKhoaHienThoi.Name;
            dataRow["MoTa"] = "Khoa hiện thời";
            dataRow["SapXep"] = 13;
            dataRow["HienThi"] = pnKhoaHienThoi.Visible;
            dataRow["DoRong"] = pnKhoaHienThoi.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnPhong.Name;
            dataRow["MoTa"] = "Phòng";
            dataRow["SapXep"] = 14;
            dataRow["HienThi"] = pnPhong.Visible;
            dataRow["DoRong"] = pnPhong.Width;
            data.Rows.Add(dataRow);

            dataRow = data.NewRow();
            dataRow["IdHienThi"] = pnChanDoan.Name;
            dataRow["MoTa"] = "Chẩn đoán - Cấp cứu";
            dataRow["SapXep"] = 15;
            dataRow["HienThi"] = pnChanDoan.Visible;
            dataRow["DoRong"] = pnChanDoan.Width;
            data.Rows.Add(dataRow);
            
            return data;
        }

        private void SetShowWithConfig()
        {
            var objCauHinhHienThi = sysConfig.lstThongTinHienThi(HienthiConstants.ThongTinBenhNhan);
            if (objCauHinhHienThi != null)
            {
                if (objCauHinhHienThi.Count > 0)
                {
                    foreach (var item in objCauHinhHienThi)
                    {
                        var ctlFind = this.Controls.Find(item.Idhienthi, true);
                        if (ctlFind.Any())
                        {
                            var ctlInfo = ctlFind.First();
                            if (ctlInfo is PanelControl)
                            {
                                var itm = (PanelControl)ctlInfo;
                                itm.Visible = item.Hienthi;
                                itm.Width = item.Dorong;
                                if (item.Hienthi && item.Sapxep > 0)
                                {
                                    itm.BringToFront();
                                }
                            }
                        }
                    }
                }
            }
        }

        [Category("ShowInformation")]
        public bool ShowNgayTiepNhan
        {
            set { pnNgay.Visible = value; }
            get { return pnNgay.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowDoiTuong
        {
            set { pnDoiTuong.Visible = value; }
            get { return pnDoiTuong.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowHoTen
        {
            set { pnHoTen.Visible = value; }
            get { return pnHoTen.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowKhoaPhong
        {
            set { pnKhoaPhong.Visible = value; }
            get { return pnKhoaPhong.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowDiachi
        {
            set { pnDiaChi.Visible = value; }
            get { return pnDiaChi.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowSexAge
        {
            set { pnGioiTinh.Visible = value; }
            get { return pnGioiTinh.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowEmail
        {
            set { pnEmail.Visible = value; }
            get { return pnEmail.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowChanDoan
        {
            set { pnChanDoan.Visible = value; }
            get { return pnChanDoan.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowBSChiDinh
        {
            set { pnBS.Visible = value; }
            get { return pnBS.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowListBSChiDinh
        {
            set { pnListBSChiDinh.Visible = value; }
            get { return pnListBSChiDinh.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowListKhoaPhong
        {
            set { pnListKhoaChiDinh.Visible = value; }
            get { return pnListKhoaChiDinh.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowSoPhieu
        {
            set { pnSoPhieu.Visible = value; }
            get { return pnSoPhieu.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowMaTiepNhan
        {
            set { pnMaTiepNhan.Visible = value; }
            get { return pnMaTiepNhan.Visible; }
        }

        [Category("ShowInformation")]
        public bool ShowBS_SDT
        {
            set { pnBacSiDienThoai.Visible = value; }
            get { return pnBacSiDienThoai.Visible; }
        }
        [Category("ShowInformation")]
        public bool ChoPhepChonNgay
        {
            set { dtpDateIn.Enabled = value; }
            get { return dtpDateIn.Enabled; }
        }

        [Category("ShowInformation")]
        public bool ShowKhoaHienThoi
        {
            set { pnKhoaHienThoi.Visible = value; }
            get { return pnKhoaHienThoi.Visible; }
        }
        [Category("ShowInformation")]
        public bool ShowPhong
        {
            set { pnPhong.Visible = value; }
            get { return pnPhong.Visible; }
        }
        private int dataIndex = -1;
        public int DataIndex
        {
            get { return dataIndex; }
            set
            {
                dataIndex = value;
            }
        }
        public DataTable DataSource { get; set; }
        public void LoadInfomationByBarcode(string barcode)
        {
            var matiepNhanTim = informationService.Get_MaTiepNhanByBarcode(barcode);
            if (!string.IsNullOrEmpty(matiepNhanTim))
            {
                LoadInformation(matiepNhanTim);
            }
            else
            {
                MaTiepNhan = string.Empty;
                 ClearControl();
            }
        }
        public void LoadInformation(string matiepnhan)
        {
            MaTiepNhan = matiepnhan;
        
            dataIndex = 0;
            if (!string.IsNullOrEmpty(matiepnhan))
            {
                DataSource = informationService.Data_BenhNhan_TiepNhan(matiepnhan, null);
                BindDataInfomation();
            }
            else
            {
                DataSource = new DataTable();
                ClearControl();
            }
        }
        public void Load_DanhMucCauHinh()
        {
            SetShowWithConfig();
            Load_DM_DoiTuongDichVu();
            Load_BacSi();
            Load_Donvi();
        }
  
        private void BindDataInfomation()
        {
            ClearControl();
            if (dataIndex > -1 && DataSource.Rows.Count > 0)
            {
                objBenhnhanTiepnhan = informationService.Get_Info_BenhNhan_TiepNhan(DataSource.Rows[dataIndex]);
                dtpDateIn.Value = objBenhnhanTiepnhan.Ngaytiepnhan;
                MaTiepNhan = objBenhnhanTiepnhan.Matiepnhan ?? string.Empty;
                txtMaTiepNhan.Text = objBenhnhanTiepnhan.Matiepnhan ?? string.Empty;
                txtSEQ.Text = objBenhnhanTiepnhan.Seq ?? string.Empty;
                txtNamSinh.Text = objBenhnhanTiepnhan.Tuoi.ToString();
                txtSoBHYT.Text = objBenhnhanTiepnhan.Sobhyt ?? string.Empty;
                txtSoPhieu.Text = objBenhnhanTiepnhan.Sophieuyeucau ?? string.Empty;
                txtSoHoSo.Text = objBenhnhanTiepnhan.Bn_id ?? string.Empty;
                txtChanDoan.Text = objBenhnhanTiepnhan.Chandoan ?? string.Empty;
                txtDiaChi.Text = objBenhnhanTiepnhan.Diachi ?? string.Empty;
                txtEmail.Text = objBenhnhanTiepnhan.Email ?? string.Empty;
                txtDienThoai2.Text = objBenhnhanTiepnhan.Sdt ?? string.Empty;
                txtMSBenhNhan.Text = objBenhnhanTiepnhan.Mabn ?? string.Empty;
                txtTenBN.Text = objBenhnhanTiepnhan.Tenbn ?? string.Empty;
                txtGioiTinh.Text = objBenhnhanTiepnhan.Gioitinh ?? string.Empty;
                cboBSChiDinh.SelectedValue = objBenhnhanTiepnhan.Bacsicd ?? string.Empty;
                cboDonvi.SelectedValue = objBenhnhanTiepnhan.Madonvi ?? string.Empty;
                cboService.SelectedValue = objBenhnhanTiepnhan.Doituongdichvu ?? string.Empty;
                chkCoSinhNhat.Checked = objBenhnhanTiepnhan.Congaysinh;
                if (objBenhnhanTiepnhan.Congaysinh)
                    dtpSinhNhat.Value = (DateTime)objBenhnhanTiepnhan.Sinhnhat;
                txtlistBSChiDinh.Text = objBenhnhanTiepnhan.TenBScd ?? string.Empty;
                txtListKhoaChiDinh.Text = objBenhnhanTiepnhan.Tendonvi ?? string.Empty;
                chkCapCuu.Checked = objBenhnhanTiepnhan.Capcuu;
                txtDienThoai.Text = objBenhnhanTiepnhan.Sdt ?? string.Empty;
                txtKhoaHienThoi.Text = objBenhnhanTiepnhan.Tenkhoahienthoi ?? string.Empty;
                cboBSChiDinh2.SelectedValue = objBenhnhanTiepnhan.Bacsicd ?? string.Empty;
                txtPhong.Text = objBenhnhanTiepnhan.Tenphong ?? string.Empty;
            }
        }
        public void ClearControl()
        {
            txtSEQ.Text = string.Empty;
            txtMaTiepNhan.Text = string.Empty;
            txtMSBenhNhan.Text = string.Empty;
            txtTenBN.Text = string.Empty;
            txtSoBHYT.Text = string.Empty;
            txtSoPhieu.Text = string.Empty;
            txtSoHoSo.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai2.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboService.SelectedIndex = -1;
            txtDTDichVu.Text = string.Empty;
            cboBSChiDinh.DataBindings.Clear();
            cboBSChiDinh.SelectedIndex = -1;
            txtBSChiDinh.Text = string.Empty;
            cboDonvi.DataBindings.Clear();
            cboDonvi.SelectedIndex = -1;
            txtDonVi.Text = string.Empty;
            txtChanDoan.Text = string.Empty;
            txtNamSinh.Text = "0";
            txtGioiTinh.Text = string.Empty;
            chkCoSinhNhat.Checked = false;
            dtpSinhNhat.Value = DateTime.Now;
            lblGioiTinh.Text = string.Empty;
            txtlistBSChiDinh.Text = string.Empty;
            txtListKhoaChiDinh.Text = string.Empty;
            chkCapCuu.Checked = false;
            txtDienThoai.Text = string.Empty;
            txtKhoaHienThoi.Text = string.Empty;
            cboBSChiDinh2.DataBindings.Clear();
            cboBSChiDinh2.SelectedIndex = -1;
            txtPhong.Text = string.Empty;
        }
        private void Load_DM_DoiTuongDichVu()
        {
            if (cboService.DataSource == null)
            {
                C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
                DataTable dtService = new DataTable();
                sysConfig.Get_DoiTuongDichVu(cboService, string.Empty, ref dtService);
            }
        }
        private void Load_BacSi()
        {
            if (cboBSChiDinh.DataSource == null || cboBSChiDinh2.DataSource == null)
            {
                var data = sysConfig.Data_ql_nhanvien(string.Empty, string.Empty);
                ControlExtension.BindDataToCobobox(data, ref cboBSChiDinh, "MaNhanVien", "MaNhanVien", "MaNhanVien, TenNhanVien", "25, 150", txtBSChiDinh, 1);
                ControlExtension.BindDataToCobobox(data.Copy(), ref cboBSChiDinh2, "MaNhanVien", "MaNhanVien", "MaNhanVien, TenNhanVien", "25, 150", txtBacSi_2, 1);
            }
        }
        private void Load_Donvi()
        {
            if (cboDonvi.DataSource == null)
            {
                sysConfig.GetLocation(cboDonvi, "MaKhoaPhong", "MaKhoaPhong", "MaKhoaPhong,TenKhoaPhong", "100,250", txtDonVi, 1, string.Empty, string.Empty);
            }
        }

        private void chkCapCuu_CheckedChanged(object sender, EventArgs e)
        {
            chkCapCuu.BackColor = chkCapCuu.Checked ? Color.Yellow : Color.Empty;
        }

        private void txtGioiTinh_TextChanged(object sender, EventArgs e)
        {
            lblGioiTinh.Text = LabServices_Helper.GetSexToLable(txtGioiTinh.Text);
        }
    }
}
