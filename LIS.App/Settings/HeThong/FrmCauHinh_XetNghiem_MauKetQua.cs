using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.Report.Constants;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinh_XetNghiem_MauKetQua : FrmTemplate
    {
        public FrmCauHinh_XetNghiem_MauKetQua()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _iSystconfig = new SystemConfigService();
        private readonly IReportService _iReport = new ReportServiceImpl();
        DataTable dataDMMauIn = new DataTable();
        SqlDataAdapter daDMMauIn = new SqlDataAdapter();
        private void FrmCauHinh_XetNghiem_MauKetQua_Load(object sender, EventArgs e)
        {
            Load_NgonNgu();
            Load_ConstantMauIn();
            Load_DinhDangHienThi();
            Load_ConstantViTri();
            Load_DSMauIn();
            Load_DanhSachMauChon();
            ucCauHinhReport1.UserId = CommonAppVarsAndFunctions.UserID;
            ucCauHinhReport1.LoadDanhSachUngDung();
            LoadDanhSachReport();
            ucCauHinhReport1.ReportAdded += UcCauHinhReport1_ReportAdded;
            ucCauHinhReport1.ReloadReport += ucCauHinhReport1_ReloadReport;

        }
        public void Load_NgonNgu()
        {
            var data = _iSystconfig.Data_dm_ngonngu(string.Empty);
            cboNgonNgu.DataSource = data;
            cboNgonNgu.ValueMember = "Idngonngu";
            cboNgonNgu.DisplayMember = "Mota";
        }
        private void UcCauHinhReport1_ReportAdded(object sender, EventArgs e)
        {
            LoadDanhSachReport();
        }

        public void LoadDanhSachReport()
        {
            var data = _iReport.Data_DanhSachReport((int)EnumReportApp.LabIMS);
            cboReport.DataSource = data.Copy();
            cboReport.ValueMember = "ReportId";
            cboReport.DisplayMember = "ReportId";
            cboReport.SelectedIndex = -1;

            cboMauChon_IDReport.DataSource = data.Copy();
            cboMauChon_IDReport.ValueMember = "ReportId";
            cboMauChon_IDReport.DisplayMember = "ReportId";
            cboMauChon_IDReport.SelectedIndex = -1;
        }
        private void Load_ConstantMauIn()
        {

        }
        private void Load_ConstantViTri()
        {
            cboViTri.DataSource = ReportResultPositionConstant.ReportResultPositionConstantList.ToList();
            cboViTri.DisplayMember = "Value";
            cboViTri.ValueMember = "Key";
            colViTri_Mavitri.DataSource = ReportResultPositionConstant.ReportResultPositionConstantList.ToList();
            colViTri_Mavitri.DisplayMember = "Value";
            colViTri_Mavitri.ValueMember = "Key";
        }
        private void Load_DinhDangHienThi()
        {
            DataTable DataHienThi = new DataTable();
            DataHienThi.Columns.Add("Key", typeof(int));
            DataHienThi.Columns.Add("Value", typeof(string));

            DataRow dr = DataHienThi.NewRow();
            dr["Key"] = 0;
            dr["Value"] = "Bình thường";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 1;
            dr["Value"] = "Bình thường + gạch chân";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 2;
            dr["Value"] = "In đậm";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 3;
            dr["Value"] = "In đậm + gạch chân";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 4;
            dr["Value"] = "In nghiêng";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 5;
            dr["Value"] = "In nghiêng + gạch chân";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 6;
            dr["Value"] = "In đậm + nghiêng";
            DataHienThi.Rows.Add(dr);

            dr = DataHienThi.NewRow();
            dr["Key"] = 7;
            dr["Value"] = "In đậm + nghiêng + gạch chân";
            DataHienThi.Rows.Add(dr);

            colViTri_HienThiTen.DataSource = DataHienThi.Copy();
            colViTri_HienThiTen.DisplayMember = "Value";
            colViTri_HienThiTen.ValueMember = "Key";


            colViTri_HienThiKetQua.DataSource = DataHienThi.Copy();
            colViTri_HienThiKetQua.DisplayMember = "Value";
            colViTri_HienThiKetQua.ValueMember = "Key";

            colViTri_HienThiKQBatThuong.DataSource = DataHienThi.Copy();
            colViTri_HienThiKQBatThuong.DisplayMember = "Value";
            colViTri_HienThiKQBatThuong.ValueMember = "Key";
        }
        private void Load_DSMauIn()
        {
            dtgMauIn.CellEnter -= dtgMauIn_CellEnter;
            dtgMauIn.DataBindingComplete -= DtgMauIn_DataBindingComplete;
            _iSystconfig.Get_Data_dm_xetnghiem_mauphieuin(dtgMauIn, bvMauIn, ref daDMMauIn, ref dataDMMauIn, string.Empty);

            cboMauChon_PhieuIn.DataSource = dataDMMauIn.Copy();
            cboMauChon_PhieuIn.ValueMember = "IDMauKetQua";
            cboMauChon_PhieuIn.DisplayMember = "MoTa";
            cboMauChon_PhieuIn.SelectedIndex = -1;

            dtgMauIn.CellEnter += dtgMauIn_CellEnter;
            Load_DSViTri();
            if (dtgMauIn.CurrentRow != null)
                Load_DanhMucXetNghiem(dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString().Trim());
            dtgMauIn.DataBindingComplete += DtgMauIn_DataBindingComplete;
        }

        private void DtgMauIn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dtUpdate = dataDMMauIn.GetChanges(DataRowState.Modified);
            var dtDelete = dataDMMauIn.GetChanges(DataRowState.Deleted);
            var dtAddNew = dataDMMauIn.GetChanges(DataRowState.Added);
            if (dtUpdate != null || dtDelete != null || dtAddNew != null)
            {
                DataProvider.UpdateData(daDMMauIn, ref dataDMMauIn, dtgMauIn, string.Empty, string.Empty);
            }
        }

        private void Add_MauIn()
        {
            if (!string.IsNullOrEmpty(txtIdMau.Text) && !string.IsNullOrEmpty(txtTenMau.Text) && cboReport.SelectedIndex > -1)
            {
                var objInsert = new DM_XETNGHIEM_MAUPHIEUIN();
                objInsert.Idmauketqua = txtIdMau.Text.Trim();
                objInsert.Mota = txtTenMau.Text.Trim();
                objInsert.Idreport = cboReport.SelectedValue.ToString();
                objInsert.Chiacot = chkPhieuChiaCot.Checked;

                var returnVal = _iSystconfig.Insert_dm_xetnghiem_mauphieuin(objInsert);
                if (returnVal.Id == -1)
                {
                    CustomMessageBox.MSG_Information_OK(returnVal.Name);
                }
                else
                {
                    Load_DSMauIn();
                    bvMauIn.BindingSource.Position = bvMauIn.BindingSource.Find("IDMauKetQua", objInsert.Idmauketqua);
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập đủ thông tin mẫu in");
            }
        }
        private void Delete_mauIn()
        {
            if (dtgMauIn.CurrentRow != null)
            {
                var objDelete = new DM_XETNGHIEM_MAUPHIEUIN();
                objDelete.Idmauketqua = dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString();
                objDelete.Mota = dtgMauIn.CurrentRow.Cells[colMauKetQua_MoTa.Name].Value.ToString();
                if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Xóa mẫu in đang chọn?"))
                {
                    _iSystconfig.Delete_dm_xetnghiem_mauphieuin(objDelete);
                    Load_ConstantMauIn();
                    Load_DSMauIn();
                    Load_DanhMucXetNghiem(objDelete.Idmauketqua);
                }
            }
        }
        private void btnThemMauPhieu_Click(object sender, EventArgs e)
        {
            Add_MauIn();
        }

        private void btnXoaMauIn_Click(object sender, EventArgs e)
        {
            Delete_mauIn();
        }

        private void btnLoaXetNghiem_Click(object sender, EventArgs e)
        {
            if (dtgMauIn.CurrentRow != null)
                Load_DanhMucXetNghiem(dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString().Trim());
        }
        void SearchXetNghiem()
        {
            chkChonXnAdd.Checked = false;
            if (bvXetNghiem.BindingSource != null)
            {
                bvXetNghiem.BindingSource.Filter = (string.IsNullOrEmpty(txtTimXetnghiem.Text) ? string.Empty : string.Format("maxn like '{0}' or tenxn like '%{0}%' or MaNhomCLS like '{0}'", WorkingServices.EscapeLikeValue(txtTimXetnghiem.Text)));
            }
        }
        private void Load_DanhMucXetNghiem(string idMauketQua)
        {
            var data = _iSystconfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
            if (dtgViTri.RowCount > 0)
            {
                var dataVitri = (DataTable)((BindingSource)dtgViTri.DataSource).DataSource;
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var maxn = data.Rows[0]["Maxn"].ToString();
                            if (WorkingServices.SearchResult_OnDatatable(dataVitri, string.Format("Maxetnghiem = '{0}'", maxn)).Rows.Count > 0)
                            {
                                data.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
            ControlExtension.BindDataToGrid(data, ref dgvXetnghiem, ref bvXetNghiem);
            SearchXetNghiem();
        }

        private void Add_ViTri()
        {
            if (dtgMauIn.CurrentRow != null && dgvXetnghiem.CurrentRow != null && cboViTri.SelectedIndex > -1)
            {
                var Idmauketqua = dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString();
                for (int i = 0; i < dgvXetnghiem.RowCount; i++)
                {
                    var checkColumn = dgvXetnghiem[colChonXnAdd.Name, i].Value ?? (object)false;
                    if ((bool)checkColumn)
                    {
                        var objInsert = new DM_XETNGHIEM_MAUPHIEUIN_VITRI();
                        objInsert.Idmauketqua = Idmauketqua;
                        objInsert.Mavitri = cboViTri.SelectedValue.ToString();
                        objInsert.Maxetnghiem = dgvXetnghiem[colXetNghiem_MaXetNghiem.Name, i].Value.ToString();
                        _iSystconfig.Insert_dm_xetnghiem_mauphieuin_vitri(objInsert);
                        if (cboViTri.SelectedIndex < cboViTri.Items.Count - 1 && objInsert.Mavitri != ReportResultPositionConstant.KQ_None_Column)
                            cboViTri.SelectedIndex++;
                    }
                }
                Load_DanhMucXetNghiem(Idmauketqua);
            }
        }

        private void btnThemmViTri_Click(object sender, EventArgs e)
        {
            Add_ViTri();
            Load_DSViTri();
        }

        private void Load_DSViTri()
        {
            if (dtgMauIn.CurrentRow != null)
            {
                _iSystconfig.Get_Data_dm_xetnghiem_mauphieuin_vitri(dtgViTri, bvViTri, dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString(), string.Empty, string.Empty);
                chkCheck.Checked = false;
            }
        }

        private void btnXoaViTri_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Xóa vị trí in của xét nghiệm được chọn?"))
            {
                for (int i = 0; i < dtgViTri.Rows.Count; i++)
                {
                    var chon = dtgViTri[colCheck.Name, i].Value;
                    var isChon = chon == null ? false : (bool)chon;
                    if (isChon)
                    {
                        var objDelete = new DM_XETNGHIEM_MAUPHIEUIN_VITRI();
                        objDelete.Idmauketqua = dtgViTri[colViTri_IDMauKetQua.Name, i].Value.ToString();
                        objDelete.Maxetnghiem = dtgViTri[colViTri_MaXetNghiem.Name, i].Value.ToString();
                        _iSystconfig.Delete_dm_xetnghiem_mauphieuin_vitri(objDelete);
                    }
                }
                Load_DSViTri();
                Load_DanhMucXetNghiem(dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString());
            }
        }

        private void dtgMauIn_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_DSViTri();
            if (dtgMauIn.CurrentRow != null)
            {
                string idMau = dtgMauIn.CurrentRow.Cells[colMauKetQua_IDMauKetQua.Name].Value.ToString().Trim();
                var chiaCot = bool.Parse(dtgMauIn.CurrentRow.Cells[colMauPhieuIn_ChiaCot.Name].Value.ToString().Trim());
                Load_DanhMucXetNghiem(idMau);
                if (!chiaCot)
                    cboViTri.SelectedIndex = 0;
                cboViTri.Enabled = chiaCot;
                //    string mess = string.Empty;
                //    if (idMau == ReportResultTemplateConstant.Mau_BYT_29BV01)
                //    {
                //        //Mẫu phiếu huyết tủy đồ
                //        mess = "*** Qui ước đặt vị trí cho mẫu Huyết - Tủy đồ:" + Environment.NewLine;
                //        mess += "\t1. Trang 1: Đặt tất cả có mã bên trái => KQ_L_G_(số thứ tự)" + Environment.NewLine;
                //        mess += "\t2. Trang 2: Đặt tất cả có mã bên phải => KQ_R_G_(số thứ tự)";
                //    }
                //    else if (idMau == ReportResultTemplateConstant.Mau_BYT_28BV01)
                //    {
                //        //Mẫu phiếu huyết tủy đồ
                //        mess = "*** Qui ước đặt vị trí cho mẫu Huyết học:" + Environment.NewLine;
                //        mess += "\t1. Trong lưới [Tến bào máu ngoại vi]: XN bên trái => KQ_L_G_(số thứ tự (Max: 30)) - XN bên phải => KQ_R_G_(số thứ tự (Max: 30))" + Environment.NewLine;
                //        mess += "\t2. Ngoài lưới [Đông máu]: XN bên trái => KQ_L_O_(số thứ tự (Max: 5))  - XN bên phải => KQ_R_O_(số thứ tự (Max: 5)) " + Environment.NewLine;
                //        mess += "\t3. Ngoài lưới [Nhóm máu]: XN bên trái: KQ_L_O_6 - XN bên phải: KQ_R_O_6" + Environment.NewLine;
                //        mess += "\t3. Lưu ý: Tính toán tổng dòng hiển thị ngoài và trong lưới không quá 29 dòng";
                //    }

                //    lblMessge.Text = mess;
            }
        }

        private void txtTimXetnghiem_TextChanged(object sender, EventArgs e)
        {
            SearchXetNghiem();
        }

        private void dtgViTri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var objUpdate = new DM_XETNGHIEM_MAUPHIEUIN_VITRI();
            objUpdate.Idmauketqua = dtgViTri[colViTri_IDMauKetQua.Name, e.RowIndex].Value.ToString();
            objUpdate.Maxetnghiem = dtgViTri[colViTri_MaXetNghiem.Name, e.RowIndex].Value.ToString();
            objUpdate.Mavitri = dtgViTri[colViTri_Mavitri.Name, e.RowIndex].Value.ToString();
            objUpdate.Luonhienthi = bool.Parse(dtgViTri[colViTri_LuonHienThi.Name, e.RowIndex].Value.ToString());
            objUpdate.Noicot = bool.Parse(dtgViTri[colViTri_NoiCot.Name, e.RowIndex].Value.ToString());
            objUpdate.Hienthiten = int.Parse(dtgViTri[colViTri_HienThiTen.Name, e.RowIndex].Value.ToString());
            objUpdate.Hienthiketqua = int.Parse(dtgViTri[colViTri_HienThiKetQua.Name, e.RowIndex].Value.ToString());
            objUpdate.Hienthikqbatthuong = int.Parse(dtgViTri[colViTri_HienThiKQBatThuong.Name, e.RowIndex].Value.ToString());
            _iSystconfig.Update_dm_xetnghiem_mauphieuin_vitri(objUpdate);
        }

        private void dtgMauIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //var objUpdate = new DM_XETNGHIEM_MAUPHIEUIN();
            //objUpdate.Idmauketqua = dtgMauIn[colMauKetQua_IDMauKetQua.Name, e.RowIndex].Value.ToString();
            //objUpdate.Mota = dtgMauIn[colMauKetQua_MoTa.Name, e.RowIndex].Value.ToString();
            //objUpdate.Vitrisapxeptrai = int.Parse(dtgMauIn[colBieuMauSapXepTrai.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colBieuMauSapXepTrai.Name, e.RowIndex].Value.ToString());
            //objUpdate.Vitrisapxepphai = int.Parse(dtgMauIn[colBieuMauSapXepPhai.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colBieuMauSapXepPhai.Name, e.RowIndex].Value.ToString());
            //objUpdate.Vitrisapxeptraigioihan = int.Parse(dtgMauIn[colBieuMauVitriSapXepTraiGioiHan.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colBieuMauVitriSapXepTraiGioiHan.Name, e.RowIndex].Value.ToString());
            //objUpdate.Vitrisapxepphaigioihan = int.Parse(dtgMauIn[colBieuMauVitriSapXepPhaiGioiHan.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colBieuMauVitriSapXepPhaiGioiHan.Name, e.RowIndex].Value.ToString());

            //objUpdate.Vitrisapxeptraingoai = int.Parse(dtgMauIn[colMauPhieuIn_SapXepTraiTuDongNgoai.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colMauPhieuIn_SapXepTraiTuDongNgoai.Name, e.RowIndex].Value.ToString());
            //objUpdate.Vitrisapxepphaingoai = int.Parse(dtgMauIn[colMauPhieuIn_SapXepPhaiTuDongNgoai.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colMauPhieuIn_SapXepPhaiTuDongNgoai.Name, e.RowIndex].Value.ToString());
            //objUpdate.Vitrisapxeptraigioihanngoai = int.Parse(dtgMauIn[colMauPhieuIn_SapXepTraiDenDongNgoai.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colMauPhieuIn_SapXepTraiDenDongNgoai.Name, e.RowIndex].Value.ToString());
            //objUpdate.Vitrisapxepphaigioihanngoai = int.Parse(dtgMauIn[colMauPhieuIn_SapXepPhaiDenDongNgoai.Name, e.RowIndex].Value.ToString() == "" ? "-1" : dtgMauIn[colMauPhieuIn_SapXepPhaiDenDongNgoai.Name, e.RowIndex].Value.ToString());

            //objUpdate.Thutuin = int.Parse(dtgMauIn[colThuTuIn.Name, e.RowIndex].Value.ToString() == "" ? "0" : dtgMauIn[colThuTuIn.Name, e.RowIndex].Value.ToString());

            //objUpdate.Tenctm = dtgMauIn[colMauPhieuIn_TenCTM.Name, e.RowIndex].Value.ToString();
            //objUpdate.Tendm = dtgMauIn[colMauPhieuIn_TenDM.Name, e.RowIndex].Value.ToString();
            //objUpdate.Tennm = dtgMauIn[colMauPhieuIn_TenNhomMau.Name, e.RowIndex].Value.ToString();

            //IdReport varchar(100), ChiaCot bit, KyTenTheoLuoi bit, TachBsChiDinh bit,
            //TachNhomIn bit,TachTuDong bit, GhepTenXnGhiChu bit, GhiChuDuoiXn bit,
            //GhepGhiChuKhoaVaoChung bit, DinhDangGhepNhapKQ varchar(15),
            //DinhDangGhepDuyetKQ varchar(15),LeKQDuoiNguong int,LeKQTrenNguong int,
            //LeKQTrongNguong int,LeNhom int,BatThuongGachChan bit, BatThuongInDam bit,
            //BatThuongInNghieng bit,ThoiGianInLanDau bit

            //  _iSystconfig.Update_dm_xetnghiem_mauphieuin(objUpdate);
        }

        private void btnRefreshMau_Click(object sender, EventArgs e)
        {
            Load_DSMauIn();
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            ControlExtension.Check_Uncheck_Datagrid(dtgViTri, colCheck, chkCheck.Checked);
        }

        private void chkChonXnAdd_CheckedChanged(object sender, EventArgs e)
        {
            ControlExtension.Check_Uncheck_Datagrid(dgvXetnghiem, colChonXnAdd, chkChonXnAdd.Checked);
        }
        #region Mẫu chọn
        DataTable dataDMMauChon = new DataTable();
        SqlDataAdapter daDMMauChon = new SqlDataAdapter();
        private void Load_DanhSachMauChon()
        {
            _iSystconfig.Get_Data_dm_xetnghiem_mauphieuin_tuychon(dtgDSMauChon, bvDSMauChon, ref daDMMauChon, ref dataDMMauChon, string.Empty);
        }
        #endregion

        private void btnXoaMauChon_Click(object sender, EventArgs e)
        {
            if (dtgDSMauChon.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa mẫu đang chọn?"))
                {
                    var idMauChon = dtgDSMauChon.CurrentRow.Cells[colMauChon_IDMauChon.Name].Value.ToString();
                    _iSystconfig.Delete_dm_xetnghiem_mauphieuin_tuychon(new DM_XETNGHIEM_MAUPHIEUIN_TUYCHON() { Idmauchon = idMauChon });
                    Load_DanhSachMauChon();
                }
            }
        }

        private void dtgDSMauChon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dtUpdate = dataDMMauChon.GetChanges(DataRowState.Modified);
            var dtDelete = dataDMMauChon.GetChanges(DataRowState.Deleted);
            var dtAddNew = dataDMMauChon.GetChanges(DataRowState.Added);
            if (dtUpdate != null || dtDelete != null || dtAddNew != null)
            {
                DataProvider.UpdateData(daDMMauChon, ref dataDMMauChon, dtgDSMauChon, string.Empty, string.Empty);
            }
        }
        private void AddMauChon()
        {
            if (!string.IsNullOrEmpty(txtIDMauChon.Text))
            {
                if (cboMauChon_PhieuIn.SelectedIndex > -1)
                {
                    if (cboMauChon_IDReport.SelectedIndex > -1)
                    {
                        if (cboMauChon_Form.SelectedIndex > -1)
                        {
                            var obj = new DM_XETNGHIEM_MAUPHIEUIN_TUYCHON();
                            obj.Idmauchon = txtIDMauChon.Text;
                            obj.Idmauketqua = cboMauChon_PhieuIn.SelectedValue.ToString();
                            obj.Idformsudung = cboMauChon_Form.SelectedIndex;
                            obj.Idreport = cboMauChon_IDReport.SelectedValue.ToString();
                            obj.Tenmauchon = txtTenMauChon.Text;
                            obj.MaNgonNgu = (cboNgonNgu.SelectedIndex > -1 ? cboNgonNgu.SelectedValue.ToString() : string.Empty);
                            _iSystconfig.Insert_dm_xetnghiem_mauphieuin_tuychon(obj);
                            Load_DanhSachMauChon();
                        }
                    }
                }
            }
        }

        private void btnThemMauChon_Click(object sender, EventArgs e)
        {
            AddMauChon();
        }

        private void btnmauChon_LamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhSachMauChon();
        }

        private void ucCauHinhReport1_ReloadReport(object sender, EventArgs e)
        {
            CommonAppVarsAndFunctions.RefreshReport = true;
        }
    }
}
