using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TPH.Data.HIS.HISDataCommon;
using TPH.Data.HIS.Models;
using TPH.Lab.BusinessService.Models;
using TPH.Lab.BusinessService.Services;
using TPH.Lab.Middleware.HISConnect.Models;
using TPH.Lab.Middleware.HISConnect.Services;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.WriteLog;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmCapNhatThongTin : FrmTemplate
    {
        public FrmCapNhatThongTin()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly IPatientInformationService _informationService = new PatientInformationService();
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly IGetHISService _iHisService = new GetHISService();
        private HISDataColumnNames hColumnNames;
        HisConnection hisInfo;
        HisProvider WorkingHis = HisProvider.NONE;
        private void btnTimHis_Click(object sender, EventArgs e)
        {
            Load_SoPhieu();
        }
        private void Load_SoPhieu()
        {
            if (!string.IsNullOrEmpty(txtSoPhieuYeuCau.Text))
            {
                var data = LoadOrderDetailFromHIS((WorkingHis == HisProvider.DH_API ? txtSoPhieuYeuCau.Text : string.Empty)
                            , true, null, dtpNgayChiDinh.Value
                            , null, false, string.Empty, (WorkingHis == HisProvider.DH_API ? txtSoPhieuYeuCau.Text : string.Empty)
                            , (WorkingHis == HisProvider.Vimes ? txtSoPhieuYeuCau.Text : string.Empty));
                LoadPatientListFromHIS(true, data.Copy());
                txtSoPhieuYeuCau.Focus();
                txtSoPhieuYeuCau.SelectAll();
            }
        }
        private DataTable LoadOrderDetailFromHIS(string soPhieuYeuCau, bool showMess, DataTable dataOrder = null, DateTime? TuNgayNgayChiDinh = null
    , DateTime? DenNgayNgayChiDinh = null, bool NoiTru = false, string giaytoId = "", string maBenhNhan = "", string soHoSo = "")
        {
            DataTable dt = new DataTable();

            if (dataOrder != null)
                dt = dataOrder;
            else
            {
                var paraList = new HisParaGetList();
                paraList.IDGiayto = giaytoId;
                paraList.MaBenhNhan = maBenhNhan;
                paraList.NgayChiDinh = TuNgayNgayChiDinh;
                paraList.TimTuNgayChiDinh = TuNgayNgayChiDinh;
                paraList.TimDenNgayChiDinh = DenNgayNgayChiDinh;
                paraList.SoPhieuChiDinh = soPhieuYeuCau;
                paraList.NoiTru = NoiTru;
                paraList.TrangThai = 2;
                paraList.MaBenhAn = soHoSo;
                var orderDetail = _iHisData.GetPatientOrderedDetail(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, CommonAppVarsAndFunctions.HisDataColumnsList, false, hColumnNames);
                if (orderDetail.Data != null)
                {
                    dt = orderDetail.Data;

                }
            }
            return dt;
        }
        private void LoadPatientListFromHIS(bool fromTextInput = false, DataTable dataInput = null)
        {
            if (hisInfo == null) return;
            var oderListData = new HISReturnBase();
            if (dataInput == null)
            {
                if (!fromTextInput)
                    txtSoPhieuYeuCau.Text = string.Empty;
                var paraList = new HisParaGetList();
                paraList.NgayChiDinh = DateTime.Now.Date;
                paraList.TimTuNgayChiDinh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                paraList.TimDenNgayChiDinh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                paraList.SoPhieuChiDinh = txtSoPhieuYeuCau.Text;
                paraList.TrangThai = 2;

                hColumnNames = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);

                oderListData = _iHisData.GetPatientOrderedList(this.hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, hColumnNames);
            }
            else
                oderListData.Data = dataInput;

            if (oderListData.Data != null)
            {
                var dt = oderListData.Data;
                if (dt.Rows.Count == 0)
                {
                    bvHisDanhSachBenhNhanCho.BindingSource = null;
                    dtgHisDanhSachBenhNhanCho.DataSource = null;
                }
                else
                {
                    if (WorkingHis == HisProvider.DH_DHG || dataInput != null)
                    {
                        for (var a = 0; a < dt.Columns.Count; a++)
                        {
                            if (dt.Columns[a].ColumnName.Equals(hColumnNames.chidinhMadichvu)
                                || dt.Columns[a].ColumnName.Equals(hColumnNames.chidinhMaloai)
                                || dt.Columns[a].ColumnName.Equals(hColumnNames.chidinhTendv)
                                || dt.Columns[a].ColumnName.Equals(hColumnNames.chidinhIdchidinh)
                                || dt.Columns[a].ColumnName.Equals(hColumnNames.chidinhIdChiTietChiDinh)
                                || dt.Columns[a].ColumnName.Equals(hColumnNames.chidinhidDichvuchidinh)
                                || dt.Columns[a].ColumnName.Trim().Equals("MaDichVuLIS", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals("MaProfileLIS", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals("LoaiDichVuLIS", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals(hColumnNames.chidinhidDichvuchidinhcaptren)
                                || dt.Columns[a].ColumnName.Trim().Equals("TenNhomCLS", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals("ThuTuIn", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals("SapXep", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals("ketqua", StringComparison.OrdinalIgnoreCase)
                                || dt.Columns[a].ColumnName.Trim().Equals("batthuong", StringComparison.OrdinalIgnoreCase)
                            )
                            {
                                dt.Columns.RemoveAt(a);
                                dt.AcceptChanges();
                                a--;
                            }
                        }
                    }
                    var columns = new string[dt.Columns.Count];

                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        columns[i] = dt.Columns[i].ColumnName;
                    }
                    dt = dt.DefaultView.ToTable(true, columns);
                    ControlExtension.BindDataToGrid(dt, ref dtgHisDanhSachBenhNhanCho, ref bvHisDanhSachBenhNhanCho);
                    if (WorkingHis == HisProvider.Vimes)
                    {
                        FormatGrid();
                    }
                    txtSoPhieuYeuCau.Focus();
                    txtSoPhieuYeuCau.SelectAll();
                }
            }
        }
        private void FormatGrid()
        {
            if (dtgHisDanhSachBenhNhanCho.RowCount > 0)
            {
                for (int i = 0; i < dtgHisDanhSachBenhNhanCho.RowCount; i++)
                {
                    var barcode = dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhBarcodexn.Name, i].Value.ToString();
                    if (string.IsNullOrEmpty(barcode) || barcode.Equals("0"))
                    {
                        dtgHisDanhSachBenhNhanCho.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
        }
        private void FrmCapNhatThongTin_Load(object sender, EventArgs e)
        {
            Load_HisProvider();

            Set_HisConfig(WorkingHis);
        }
        private void Load_HisProvider()
        {
            cboHISProvider.SelectedIndexChanged -= CboHISProvider_SelectedIndexChanged;
            var list = CommonData.GetEnumValuesAndDescriptions<HisProvider>().Where(x => CommonAppVarsAndFunctions.PCWorkPlaceOfHis.Contains(x.Key));
            cboHISProvider.DataSource = list.ToList();
            cboHISProvider.ValueMember = "Key";
            cboHISProvider.DisplayMember = "Value";
            cboHISProvider.SelectedIndex = 0;
            cboHISProvider.SelectedIndexChanged += CboHISProvider_SelectedIndexChanged;
            WorkingHis = (HisProvider)Enum.Parse(typeof(HisProvider), list.FirstOrDefault().Key.ToString());

            if (list.Count() == 1)
                cboHISProvider.Enabled = false;
        }
        private void CboHISProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkingHis = (HisProvider)Enum.Parse(typeof(HisProvider), cboHISProvider.SelectedValue.ToString());
            Set_HisConfig(WorkingHis);
        }
        int oldColMaBnIndex = -1;
        private void Set_HisConfig(HisProvider hisProvider)
        {
            dtgHisDanhSachBenhNhanCho.DataSource = null;
            if (WorkingHis == HisProvider.DH_DHG)
            {
                dtgHisDanhSachBenhNhanCho.Columns[col_DanhSach_chidinhNgaychidinh.Name].DefaultCellStyle.Format = "HH:mm:ss dd/MM/yyyy";
            }
            else if (WorkingHis == HisProvider.DBTG_HL7_FPT || WorkingHis == HisProvider.FPT_SP)
            {
                var dispIndex = col_DanhSanh_chidinhSophieuyeucau.DisplayIndex;
                col_DanhSanh_chidinhMabenhnhan.HeaderText = "Mã y tế";
                //Ghi lại index lúc design để khoi phục lại đúng khi chuyển HIS
                oldColMaBnIndex = col_DanhSanh_chidinhMabenhnhan.DisplayIndex;

                col_DanhSanh_chidinhMabenhnhan.DisplayIndex = dispIndex;
                if (dtgHisDanhSachBenhNhanCho.Columns.Contains(col_DanhSanh_chidinhSophieuyeucau))
                    dtgHisDanhSachBenhNhanCho.Columns.Remove(col_DanhSanh_chidinhSophieuyeucau);
                col_DanhSanh_chidinhTrangThaiChiDinh.Visible = false;
            }
            else
            {
                //trả lại các cột đã xóa hoặc ẩn do chuyển HIS.
                var dispMabnIndex = oldColMaBnIndex == -1 ? col_DanhSanh_chidinhMabenhnhan.DisplayIndex : oldColMaBnIndex;
                var soPhieuIndex = oldColMaBnIndex == -1 ? col_DanhSanh_chidinhMabenhnhan.DisplayIndex : col_DanhSanh_chidinhMabenhnhan.DisplayIndex;

                col_DanhSanh_chidinhMabenhnhan.HeaderText = "Mã bệnh nhân";
                col_DanhSanh_chidinhMabenhnhan.DisplayIndex = dispMabnIndex;

                if (!dtgHisDanhSachBenhNhanCho.Columns.Contains(col_DanhSanh_chidinhSophieuyeucau))
                {
                    dtgHisDanhSachBenhNhanCho.Columns.Add(col_DanhSanh_chidinhSophieuyeucau);
                    col_DanhSanh_chidinhMabenhnhan.DisplayIndex = soPhieuIndex;
                }

                col_DanhSanh_chidinhTrangThaiChiDinh.Visible = true;
            }

            hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => x.HisID == hisProvider).FirstOrDefault();
            hColumnNames = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
            Set_ColumnDataProperty(hisInfo);
        }
        private void Set_ColumnDataProperty(HisConnection hisInfo)
        {
            SetDataPropertyNameForDatagriviewColumnNormal(hisInfo, dtgHisDanhSachBenhNhanCho);
        }
        public void SetDataPropertyNameForDatagriviewColumnNormal(HisConnection hisInfo, CustomDatagridView dtg)
        {
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                DataGridViewColumn dgc = dtg.Columns[i];

                string[] arrColName = dgc.Name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                if (arrColName.Length > 2)
                {
                    if (dgc.Tag == null)
                        dgc.Tag = dgc.Visible;

                    var HisColumnsName = _iHisData.GetHisThongTinMappingCot(hisInfo, CommonAppVarsAndFunctions.HisDataColumnsList);
                    PropertyInfo[] fiCheck = HisColumnsName.GetType().GetProperties();
                    foreach (PropertyInfo f in fiCheck)
                    {
                        if (f.Name.Equals(arrColName[2], StringComparison.OrdinalIgnoreCase))
                        {
                            var obj = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null) == null ? string.Empty : HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null);
                            if (string.IsNullOrEmpty(obj.ToString()))
                            {
                                dgc.DataPropertyName = string.Empty;
                                dgc.Visible = false;
                            }
                            else
                            {
                                if (arrColName[2].Trim().Equals(hColumnNames.chidinhTrangThaiChiDinh, StringComparison.OrdinalIgnoreCase))
                                {
                                    if ((WorkingHis == HisProvider.AHoi || WorkingHis == HisProvider.PTT_SP || WorkingHis == HisProvider.HangMinh) && dgc.CellTemplate.GetType() != typeof(DataGridViewCheckBoxCell))
                                    {
                                        // DataGridViewColumn newCol = new DataGridViewCheckBoxColumn(); // add a column to the grid
                                        DataGridViewCell cell = new DataGridViewCheckBoxCell(); //Specify which type of cell in this column
                                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                                        var HeaderText = dgc.HeaderText;
                                        var colName = dgc.Name;
                                        var colVisible = dgc.Visible;
                                        var colWidth = dgc.Width;
                                        var tag = dgc.Tag;
                                        var displayIndex = dgc.DisplayIndex;
                                        dtgHisDanhSachBenhNhanCho.Columns.Remove(dgc);

                                        dgc = new DataGridViewColumn(cell);
                                        dgc.HeaderText = HeaderText;
                                        dgc.Name = colName;
                                        dgc.Visible = colVisible;
                                        dgc.Width = colWidth;
                                        dgc.Tag = tag;
                                        dtgHisDanhSachBenhNhanCho.Columns.Add(dgc);
                                        dgc.DisplayIndex = displayIndex;
                                        i--;
                                    }
                                }
                                dgc.DataPropertyName = HisColumnsName.GetType().GetProperty(f.Name).GetValue(HisColumnsName, null).ToString().ToLower();
                                dgc.Visible = (bool)dgc.Tag;
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dtgHisDanhSachBenhNhanCho.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin cho bệnh nhân?"))
                {
                    var lstMappingData = HISMappingService.GetInstance().GetMappingData(HisMappingCategory.All, (int)hisInfo.HisID);
                    for (int i = 0; i < dtgHisDanhSachBenhNhanCho.RowCount; i++)
                    {
                        var hisSoHoSo = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhMabenhan.Name, i].Value ?? string.Empty).ToString().Trim();
                        var strNgayVaoVien = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhNgayvaovien.Name, i].Value ?? string.Empty).ToString().Trim();
                        var ngayVaovien = string.IsNullOrEmpty(strNgayVaoVien) ? (DateTime?)null : DateTime.Parse(strNgayVaoVien);
                        var strNgayNhapVien = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhNgaynhapvien.Name, i].Value ?? string.Empty).ToString().Trim();
                        var ngayNhapvien = string.IsNullOrEmpty(strNgayNhapVien) ? (DateTime?)null : DateTime.Parse(strNgayNhapVien);
                        var hisSophieu = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhSophieuyeucau.Name, i].Value ?? string.Empty).ToString().Trim();
                        var hisMaKhoaHienThoi = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhMakhoahienthoi.Name, i].Value ?? string.Empty).ToString();
                        var hisTenKhoaHienThoi = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhTenkhoahienthoi.Name, i].Value ?? string.Empty).ToString();
                        var gioiTinh = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhGioitinh.Name, i].Value ?? string.Empty).ToString();
                        if (gioiTinh.Trim().Equals("nữ", StringComparison.OrdinalIgnoreCase) 
                            || gioiTinh.Equals("F", StringComparison.OrdinalIgnoreCase) 
                            || gioiTinh.Equals("0", StringComparison.OrdinalIgnoreCase))
                            gioiTinh = "F";
                        else if (gioiTinh.Trim().Equals("nam", StringComparison.OrdinalIgnoreCase) ||
                                 gioiTinh.Equals("m", StringComparison.OrdinalIgnoreCase) ||
                                 gioiTinh.Equals("1", StringComparison.OrdinalIgnoreCase))
                            gioiTinh = "M";
                        else
                            gioiTinh = string.Empty;
                        var diaChi = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhDiachi.Name, i].Value ?? string.Empty).ToString();
                        var soHoChieu = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhSoHoChieu.Name, i].Value ?? string.Empty).ToString();
                        var strNgayCapHoChieu = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhNgayCapHoChieu.Name, i].Value ?? string.Empty).ToString().Trim();
                        var ngayCapHoChieu = string.IsNullOrEmpty(strNgayCapHoChieu) ? (DateTime?)null : DateTime.Parse(strNgayCapHoChieu);
                        var ghiChuHoChieu = (dtgHisDanhSachBenhNhanCho[col_DanhSach_chidinhGhiChuHoChieu.Name, i].Value ?? string.Empty).ToString();
                        var namSinh = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhNamsinh.Name, i].Value ?? 0).ToString();
                        var strNgaySinh = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhSinhnhat.Name, i].Value ?? string.Empty).ToString().Trim();
                        var ngaySinh = string.IsNullOrEmpty(strNgaySinh) ? (DateTime?)null : DateTime.Parse(strNgaySinh);
                        var mappingCheck = new HISMapping();
                        var tenBn = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhTenbenhnhan.Name, i].Value ?? string.Empty).ToString();
                        var maBn = (dtgHisDanhSachBenhNhanCho[col_DanhSanh_chidinhMabenhnhan.Name, i].Value ?? string.Empty).ToString();
                        mappingCheck.HisProviderID = (int)hisInfo.HisID;
                        if (!string.IsNullOrEmpty(hisMaKhoaHienThoi))
                        {
                            mappingCheck.CategoryID = (int)HisMappingCategory.KhoaPhong;
                            mappingCheck.HISID = hisMaKhoaHienThoi;
                            mappingCheck.ItemName = hisTenKhoaHienThoi;
                            hisMaKhoaHienThoi = HISMappingService.GetInstance().GetAndAutoMapping(mappingCheck, lstMappingData).LISID;
                        }
                        var objPatient = new BENHNHAN_TIEPNHAN();
                        objPatient.Bn_id = hisSoHoSo;
                        objPatient.Mabn = maBn;
                        objPatient.Sophieuyeucau = hisSophieu;
                        objPatient.Makhoahienthoi = hisMaKhoaHienThoi;
                        objPatient.Tenkhoahienthoi = hisTenKhoaHienThoi;
                        objPatient.Tgvaovien = ngayVaovien;
                        objPatient.Ngaynhapvien = ngayNhapvien;
                        objPatient.Ngaycaphochieu = ngayCapHoChieu;
                        objPatient.Sohochieu = soHoChieu;
                        objPatient.Ghichuhochieu = ghiChuHoChieu;
                        objPatient.Tuoi = int.Parse(namSinh);
                        objPatient.Sinhnhat = ngaySinh;
                        objPatient.Tenbn = tenBn;
                        objPatient.Gioitinh = gioiTinh;
                        objPatient.Diachi = diaChi;

                        if (_iPatient.PatientLog(objPatient.Matiepnhan, string.Format("Manual Check update-SP:{0}", hisSophieu), LogActionId.Update) > -1)
                        {
                            if (_iPatient.UpdatePatientInfoADTInternal_Manual(objPatient))
                            {
                                LogService.RecordLogFile("ManualUpdateInfo", " ==> Cập nhật hoàn tất!", string.Format("Cập nhật tay thông tin bệnh nhân-SP:{0}", hisSophieu));
                            }
                            else
                                LogService.RecordLogFile("ManualUpdateInfo", " ==> Cập nhật thất bại", string.Format("Cập nhật tay thông tin bệnh nhân-SP:{0}", hisSophieu));
                        }
                    }
                }
                txtSoPhieuYeuCau.Focus();
                txtSoPhieuYeuCau.SelectAll();
            }
        }

        private void txtSoPhieuYeuCau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(char)Keys.Enter)
            {
                Load_SoPhieu();
                txtSoPhieuYeuCau.SelectAll();
            }
        }

        private void FrmCapNhatThongTin_Shown(object sender, EventArgs e)
        {
            txtSoPhieuYeuCau.Focus();
        }

        private void txtSoPhieuYeuCau_Enter(object sender, EventArgs e)
        {
            txtSoPhieuYeuCau.SelectAll();
        }

        private void txtSoPhieuYeuCau_Click(object sender, EventArgs e)
        {
            txtSoPhieuYeuCau.SelectAll();
        }
    }
}
