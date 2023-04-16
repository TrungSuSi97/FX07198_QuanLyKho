using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.HIS.Services;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Controls;
using TPH.LIS.User.Enum;
using DevExpress.XtraGrid.Columns;
using TPH.LIS.Common.Chart;
using System.Collections.Generic;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmHoSoBenhAn : FrmTemplate
    {
        private readonly IPatientFileServices _patientFiles = new PatientFileServices();
        private IPatientInformationService _patientInformation = new PatientInformationService();
        public FrmHoSoBenhAn()
        {
            InitializeComponent();
        }
        public ServiceType loaiDvXem = ServiceType.None;
        public string maBienhNhanTim = string.Empty;

        private void Load_DSBenhNhan()
        {
            if (string.IsNullOrEmpty(txtSearchName.Text) && string.IsNullOrEmpty(txtSearchPID.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập thông tin Mã BN.");
            }
            else
            { 
                dtgPatientList.CellEnter -= dtgPatientList_CellEnter;
                LabServices_Helper.BindToGrid(_patientInformation.LayDanhSach_NoiTru(txtSearchPID.Text, txtSearchName.Text), ref dtgPatientList, ref bvPatientList, false);
                Bind_InterInfo(bvPatientList.BindingSource);
                Load_DanhSachTiepNhan_NoiTru();
                dtgPatientList.CellEnter += dtgPatientList_CellEnter;
            }
        }
        private void Load_DanhSachTiepNhan_NoiTru()
        {
            if (dtgPatientList.RowCount > 0)
            {
                string _MaBN = dtgPatientList.CurrentRow.Cells["MaBN"].Value.ToString().Trim();
                LabServices_Helper.BindToGrid(_patientInformation.LayDanhSach_TiepNhan_TheoMaBN(_MaBN), ref dtgReceptionList, ref bvReceptionList);
                Bind_ReptionInfo(bvReceptionList.BindingSource);
            }
            switchTab(tabThongTin.SelectedTab, false);
        }
        /// <summary>
        /// Lấy danh sách kết quả tiền sử 
        /// </summary>
        /// <param name="_MaBN">Mã BN</param>
        /// <param name="_Type">1: Xét nghiệm - 2: Siêu âm - 3: X-Quang</param>
        private void Load_TienSu(string _MaBN, int _Type)
        {
            DataTable dtHistory = new DataTable();
            if (_Type == 1)
            {

                var data = _patientFiles.LichSuXetNghiem(_MaBN);


                var distinctCatePrint = data.DefaultView.ToTable(true, new string[] { "ThuTuNhom", "TenNhomCLS" });
                distinctCatePrint.DefaultView.Sort = "ThuTuNhom asc";

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string catePrint = data.Rows[i]["TenNhomCLS"].ToString().Trim();
                    var currentIndex = 0;
                    for (int a = 0; a < distinctCatePrint.Rows.Count; a++)
                    {
                        if (catePrint.Trim().Equals(distinctCatePrint.Rows[a]["TenNhomCLS"].ToString().Trim()))
                        {
                            currentIndex = a + 1;
                            break;
                        }
                    }
                    data.Rows[i]["TenNhomCLS"] = string.Format("[{0}] - {1}", Utilities.LayStt(currentIndex, 1), catePrint.Trim().ToUpper());
                }
                data.AcceptChanges();

                grdMainXetnghiem.OptionsBehavior.AutoPopulateColumns = true;
                gcXetNghiem.DataSource = data;
                grdMainXetnghiem.PopulateColumns();
                grdMainXetnghiem.Columns["TenNhomCLS"].GroupIndex = 0;
                grdMainXetnghiem.Columns["MaChiDinh"].Visible = false;
                grdMainXetnghiem.ExpandAllGroups();
                grdMainXetnghiem.BestFitColumns();

                for (int i = 0; i < grdMainXetnghiem.Columns.Count; i++)
                {
                    if (grdMainXetnghiem.Columns[i].Name.Contains("_RFlat"))
                        grdMainXetnghiem.Columns[i].Visible = false;
                }
                grdMainXetnghiem.OptionsBehavior.Editable = false;
                grdMainXetnghiem.Columns["TenChiDinh"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                grcolNhom.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                grcolSapXep.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                grdMainXetnghiem.Columns["ThuTuNhom"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                grdMainXetnghiem.Columns["SapXep"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                grdMainXetnghiem.Columns["ThuTuNhom"].Visible = false;
                grdMainXetnghiem.Columns["ThuTuIn"].Visible = false;
                grdMainXetnghiem.Columns["SapXep"].Visible = false;
                //grcolNhom.VisibleIndex = -1;
                //grcolSapXep.VisibleIndex = -1;
            }
            else if (_Type == 2)
            {
                bool luoi = radKetQuaSieuAm_Luoi.Checked;
                pnUltraSoundGirid.Visible = luoi;
                pnUltraSoundfreeText.Visible = !luoi;
                var data = _patientFiles.LichSuSieuAm(_MaBN, luoi);
                if (luoi)
                {
                    //xóa các cột cũ
                    for (int i = 0; i < gvUltraSound_Grid.Columns.Count; i++)
                    {
                        if (i > 1)
                        {
                            gvUltraSound_Grid.Columns.RemoveAt(i);
                            i--;
                        }
                    }
                    //add các cột mới
                    foreach (DataColumn dtc in data.Columns)
                    {
                        var colName = dtc.ColumnName;
                        if (!colName.Equals("MaSoMau", StringComparison.OrdinalIgnoreCase)
                            && !colName.Equals("TenMauSieuAm", StringComparison.OrdinalIgnoreCase)
                            && !colName.Equals("TenMauSieuAm", StringComparison.OrdinalIgnoreCase)
                            && !colName.Equals("IDMota", StringComparison.OrdinalIgnoreCase)
                            && !colName.Equals("TenMota", StringComparison.OrdinalIgnoreCase))
                        {
                            gvUltraSound_Grid.Columns.AddField(colName);
                            gvUltraSound_Grid.Columns[gvUltraSound_Grid.Columns.Count - 1].Visible = true;
                            gvUltraSound_Grid.Columns[gvUltraSound_Grid.Columns.Count - 1].Caption = dtc.Caption;
                            gvUltraSound_Grid.Columns[gvUltraSound_Grid.Columns.Count - 1].ColumnEdit = repositoryItemMemoEdit1;
                        }
                    }

                    gcUltraSound_Grid.DataSource = data;
                    gvUltraSound_Grid.ExpandAllGroups();
                    gvUltraSound_Grid.OptionsBehavior.Editable = false;
                    gvUltraSound_Grid.BestFitColumns();
                }
                else
                {
                    gcUltrasound.DataSource = data;
                    grdUltrasound.ExpandAllGroups();
                    grdUltrasound.OptionsBehavior.Editable = false;
                    grdUltrasound.BestFitColumns();
                }
            }
            else if (_Type == 3)
            {
                //siêu nội soi
                gcEdoscopic.DataSource = _patientFiles.LichSuNoiSoi(_MaBN);
                grdEdoscopic.ExpandAllGroups();
                grdEdoscopic.OptionsBehavior.Editable = false;
                grdEdoscopic.BestFitColumns();
            }
            else if (_Type == 4)
            {
                //X-quang
                gcXRay.DataSource = _patientFiles.LichSuXQuang(_MaBN);
                grdXRay.ExpandAllGroups();
                grdXRay.OptionsBehavior.Editable = false;
                grdXRay.BestFitColumns();
            }
            else if (_Type == 5)
            {
                gcChanDoan.DataSource = _patientFiles.LichSuChanDoan(_MaBN);
                grdLichSuChanDoan.ExpandAllGroups();
                grdLichSuChanDoan.OptionsBehavior.Editable = false;
                grdLichSuChanDoan.BestFitColumns();
            }
            else if (_Type == 6)
            {
                gcPrescribe.DataSource = _patientFiles.LichSuDonThuoc(_MaBN);
                grdPrescribe.ExpandAllGroups();
                grdPrescribe.OptionsBehavior.Editable = false;
                grdPrescribe.BestFitColumns();
            }
            else if (_Type == 7)
            {
                ucLichSuKhangSinhDo1.Get_Data(_MaBN);
            }
        }


        private void Clear_OldColumn(DevExpress.XtraGrid.GridControl grd, int clearFromIndex)
        {
            //foreach (DevExpress.XtraGrid.Columns.GridColumn cl in ((DevExpress.XtraGrid.Views.Grid.GridView)grd.MainView).Columns)
            //{
            //    if (cl.VisibleIndex >= clearFromIndex)
            //    {
            //        ((DevExpress.XtraGrid.Views.Grid.GridView)grd.MainView).Columns.RemoveAt(cl.VisibleIndex);
            //    }
            //}
            for (int i = clearFromIndex; i > ((DevExpress.XtraGrid.Views.Grid.GridView)grd.MainView).Columns.Count - 1; i++)
            {
                ((DevExpress.XtraGrid.Views.Grid.GridView)grd.MainView).Columns.RemoveAt(i);
                i--;
            }
        }
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            Load_DSBenhNhan();
        }

        private void Bind_InterInfo(BindingSource bs)
        {
            // cboDanToc.DataBindings.Clear();
            txtDanToc.DataBindings.Clear();
            txtNgheNghiep.DataBindings.Clear();
            cboQuanHuyen.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            cboTinh.DataBindings.Clear();
            chkAgeType.DataBindings.Clear();
            dtpBirthday.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            txtDanToc.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtHocVan.DataBindings.Clear();
            txtNgheNghiep.DataBindings.Clear();
            txtNoiLamViec.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtPhuongXa.DataBindings.Clear();
            txtQuanHuyen.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            lblPatientID.DataBindings.Clear();
            txtTenBN.DataBindings.Clear();
            txtTinh.DataBindings.Clear();
            pbPatientImage.DataBindings.Clear();


            txtDanToc.DataBindings.Add("Text", bs, "DanToc", true, DataSourceUpdateMode.Never, "");
            txtNgheNghiep.DataBindings.Add("Text", bs, "NgheNghiep", true, DataSourceUpdateMode.Never, "");
            cboQuanHuyen.DataBindings.Add("SelectedValue", bs, "MaHuyen", true, DataSourceUpdateMode.Never, "");
            txtQuocTich.DataBindings.Add("Text", bs, "QuocTich", true, DataSourceUpdateMode.Never, "");
            cboTinh.DataBindings.Add("SelectedValue", bs, "MaTinh", true, DataSourceUpdateMode.Never, "");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            dtpBirthday.DataBindings.Add("Value", bs, "SinhNat", true, DataSourceUpdateMode.Never, DateTime.Now);
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            txtEmail.DataBindings.Add("Text", bs, "Email");
            txtHocVan.DataBindings.Add("Text", bs, "HocVan");
            txtNoiLamViec.DataBindings.Add("Text", bs, "NoiLamViec");
            txtPhone.DataBindings.Add("Text", bs, "SDT");
            txtPhuongXa.DataBindings.Add("Text", bs, "PhuongXa");
            lblPatientID.DataBindings.Add("Text", bs, "MaBN");
            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            pbPatientImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPatientImage.DataBindings.Add("Image", bs, "HinhBN", true, DataSourceUpdateMode.Never, imageList1.Images[0]);
        }

        private void Bind_ReptionInfo(BindingSource bs)
        {
            lblRecptionID.DataBindings.Clear();
            dtpDateIn.DataBindings.Clear();
            cboSend_Location.DataBindings.Clear();
            cboSend_Diagnostic.DataBindings.Clear();
            cboDiagnostic.DataBindings.Clear();
            txtDoctorComment.DataBindings.Clear();
            txtDiagnostic.DataBindings.Clear();

            lblRecptionID.DataBindings.Add("Text", bs, "MaTiepNhan");
            dtpDateIn.DataBindings.Add("Value", bs, "NgayTiepNhan", true, DataSourceUpdateMode.Never, DateTime.Now);
            cboSend_Location.DataBindings.Add("SelectedValue", bs, "MaDonVi", true, DataSourceUpdateMode.Never, "");
            txtDiagnostic.DataBindings.Add("Text", bs, "ChanDoan");
            txtDoctorComment.DataBindings.Add("Text", bs, "NhanXetBS");

        }
        private void txtSearchPID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DSBenhNhan();
                txtSearchName.Focus();
            }
        }

        private void txtSearchName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_DSBenhNhan();
                btnSearchPatient.Focus();
            }
        }

        private void dtgPatientList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            pnPatientInfo.Enabled = false;
            Load_DanhSachTiepNhan_NoiTru();
        }

        private void btnTienSuXetNghiem_Click(object sender, EventArgs e)
        {
            Load_TienSu(lblPatientID.Text.Trim(), 1);
        }

        private void btnTienSuSieuAm_Click(object sender, EventArgs e)
        {
            Load_TienSu(lblPatientID.Text.Trim(), 2);
        }

        private void Save_ThongTinChiTiet()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin ?"))
            {
                if (_patientInformation.Insert_BenhNhan_ThongTinChiTiet(txtDanToc.Text, pbPatientImage.Image, txtHocVan.Text
                      , lblPatientID.Text, txtNgheNghiep.Text, txtNoiLamViec.Text, txtQuocTich.Text))
                {
                    txtSearchPID.Text = lblPatientID.Text;
                    Load_DSBenhNhan();
                }
                
            }
        }

        private void FrmHoSoBenhAn_Load(object sender, EventArgs e)
        {
            if (loaiDvXem != ServiceType.None)
            {
                Check_RemoveUuseTab(new ServiceType[] { loaiDvXem });
                if (!string.IsNullOrEmpty(maBienhNhanTim))
                {
                    lblTitle.Text = "XEM LỊCH SỬ KẾT QUẢ";
                    txtSearchPID.Text = maBienhNhanTim;
                    Load_DSBenhNhan();
                    tabThongTin.SelectedIndex = 1;
                }
            }
            else
            {
                Check_RemoveUuseTab(CommonAppVarsAndFunctions.arrLoaiDichVu);
            }
            pnChart.Location = new Point( tabTest.Width - pnChart.Width - 10, tabTest.Height - pnChart.Height - 35 ); 
        }
        private void Check_RemoveUuseTab(ServiceType[] arrAllowList)
        {
            string inList = string.Empty;
            for (int i = 0; i < arrAllowList.Length; i++)
            {
                inList += string.Format("-{0}", arrAllowList[i].ToString());
            }
            foreach (TabPage tab in tabThongTin.TabPages)
            {
                if (tab.Tag != null)
                {
                    if (!inList.Contains(string.Format("-{0}", tab.Tag.ToString())))
                    {
                        tabThongTin.TabPages.RemoveByKey(tab.Name);
                    }
                }
            }
        }

        private void pnPatientInfo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switchTab(tabThongTin.SelectedTab, false);
        }
        private void switchTab(TabPage tabselected, bool forceRefresh)
        {
            if (tabTest.Name == tabselected.Name)
            {
                if (!(tabTest.Tag == null ? string.Empty : tabTest.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabTest.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 1);
                }
            }
            else if (tabUltraSound.Name == tabselected.Name)
            {
                if (!(tabUltraSound.Tag == null ? string.Empty : tabUltraSound.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabUltraSound.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 2);
                }
            }
            else if (tabEdoscopy.Name == tabselected.Name)
            {
                if (!(tabEdoscopy.Tag == null ? string.Empty : tabEdoscopy.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabEdoscopy.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 3);
                }
            }
            else if (tabXRay.Name == tabselected.Name)
            {
                if (!(tabXRay.Tag == null ? string.Empty : tabXRay.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabXRay.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 4);
                }
            }
            else if (tabDiagnostic.Name == tabselected.Name)
            {
                if (!(tabDiagnostic.Tag == null ? string.Empty : tabDiagnostic.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabDiagnostic.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 5);
                }
            }
            else if (tabPrescribe.Name == tabselected.Name)
            {
                if (!(tabPrescribe.Tag == null ? string.Empty : tabPrescribe.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabPrescribe.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 6);
                }
            }
            else if (tabLichSuKSD.Name == tabselected.Name)
            {
                if (!(tabLichSuKSD.Tag == null ? string.Empty : tabLichSuKSD.Tag.ToString()).Equals(lblPatientID.Text) || forceRefresh)
                {
                    tabLichSuKSD.Tag = lblPatientID.Text;
                    Load_TienSu(lblPatientID.Text, 7);
                }
            }
        }
        private void grdMainXetnghiem_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (!e.Column.Name.Contains("_RFlat"))
            {
                string tempValue = string.Empty;
                string colFLatname = string.Format("{0}{1}", e.Column.Name, "_RFlat");
                GridView view = sender as GridView;
                var col = view.Columns.ColumnByName(colFLatname);
                if (col != null)
                {
                    if (view.GetRowCellValue(e.RowHandle, col) != null)
                    {
                        tempValue = view.GetRowCellValue(e.RowHandle, col).ToString().Trim();
                        if (!string.IsNullOrEmpty(tempValue))
                        {
                            int flag = int.Parse(tempValue);
                            FontStyle fs = new FontStyle();
                            var color = _MauKQ(flag, ref fs);
                            Font font = new Font("Arial", 10, fs);

                            e.Appearance.Font = font;
                            e.Appearance.ForeColor = color;
                        }
                    }
                }
            }
        }
        private Color _MauKQ(int co, ref FontStyle fstyle)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            switch (co)
            {
                case 2:
                    fstyle = FontStyle.Bold;
                    return Color.Blue;

                case 3:
                    fstyle = FontStyle.Bold;
                    return Color.Red;

                default:
                    fstyle = FontStyle.Regular;
                    return Color.Black;
            }
        }

        private void btnRefreshTest_Click(object sender, EventArgs e)
        {
            switchTab(tabTest, true);
        }

        private void btnRefreshDiagnostic_Click(object sender, EventArgs e)
        {
            switchTab(tabDiagnostic, true);
        }

        private void btnRefreshPrescribe_Click(object sender, EventArgs e)
        {
            switchTab(tabPrescribe, true);
        }

        private void btnRefreshUltraSound_Click(object sender, EventArgs e)
        {
            switchTab(tabUltraSound, true);
        }

        private void btnRefreshEdoscopic_Click(object sender, EventArgs e)
        {
            switchTab(tabEdoscopy, true);
        }

        private void btnRefreshXRay_Click(object sender, EventArgs e)
        {
            switchTab(tabXRay, true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Save_ThongTinChiTiet();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadImage_ToPicturebox(pbPatientImage);
        }

        private void btnReMoveImage_Click(object sender, EventArgs e)
        {
            pbPatientImage.Image = null;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnPatientInfo.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (pnPatientInfo.Enabled)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy thao tác ?"))
                {
                    if(dtgPatientList.CurrentRow!=null)
                        txtSearchPID.Text = lblPatientID.Text;
                    Load_DSBenhNhan();
                }
            }
        }

        private void radKetQuaSieuAm_Luoi_CheckedChanged(object sender, EventArgs e)
        {
            if (radKetQuaSieuAm_Luoi.Checked)
            {
                radKetQuaSieuAm_Luoi.BackColor = Color.Yellow;
            }
            else
                radKetQuaSieuAm_Luoi.BackColor = Color.Empty;
            switchTab(tabUltraSound, true);

        }

        private void radKetQuaSieuAm_VanBan_CheckedChanged(object sender, EventArgs e)
        {
            if (radKetQuaSieuAm_VanBan.Checked)
            {
                radKetQuaSieuAm_VanBan.BackColor = Color.Yellow;
            }
            else
                radKetQuaSieuAm_VanBan.BackColor = Color.Empty;
            switchTab(tabUltraSound, true);
        }

        private void btnXemBieuDo_Click(object sender, EventArgs e)
        {
            pnChart.Size = new Size(459, 356);
        }

        private void btnDongBieuDo_Click(object sender, EventArgs e)
        {
            pnChart.Size = new Size(0, 0);
        }

        private void grdMainXetnghiem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            customChart1.ClearImage();
            customChart1.ChartSubTile = string.Empty;
            customChart1.ChartTile = string.Empty;

            if (grdMainXetnghiem.GetFocusedRowCellValue(grcolMaXN) != null)
            { 
              var lst = new List<PointInfo>();
                customChart1.ChartSubTile = grdMainXetnghiem.GetFocusedRowCellValue(grcolTenXN).ToString();
                foreach (GridColumn col in grdMainXetnghiem.Columns)
                {
                    if (!string.IsNullOrEmpty(grdMainXetnghiem.GetFocusedRowCellValue(col).ToString()))
                    {
                        if (col.FieldName.Contains(".") && col.Visible)
                        {
                            if (WorkingServices.IsNumeric(grdMainXetnghiem.GetFocusedRowCellValue(col).ToString()))
                            {
                                var poitb = new PointInfo();
                                poitb.YValue = double.Parse(grdMainXetnghiem.GetFocusedRowCellValue(col).ToString());
                                poitb.XValue = col.FieldName.Replace(".", Environment.NewLine);
                                lst.Add(poitb);
                            }
                            else
                            {
                                var poitb = new PointInfo();
                                poitb.XValue = col.FieldName.Replace(".", Environment.NewLine);
                                var ketQua = grdMainXetnghiem.GetFocusedRowCellValue(col).ToString();
                                if (ketQua.ToLower().Trim().Contains("âm tính") || ketQua.ToLower().Trim().Contains("neg"))
                                {
                                    poitb.YValue = -1;
                                }
                                else if (ketQua.ToLower().Trim().Contains("dương tính") || ketQua.ToLower().Trim().Contains("pos"))
                                {
                                    poitb.YValue = 1;
                                }
                                else if (ketQua.ToLower().Trim().Contains("upnormal") || ketQua.ToLower().Trim().Contains("bất thường"))
                                {
                                    poitb.YValue = 1;
                                }
                                else if (ketQua.ToLower().Trim().Contains("normal") || ketQua.ToLower().Trim().Contains("bình thường"))
                                {
                                    poitb.YValue = 0;
                                }
                                else
                                {
                                    poitb.YValue = 0;
                                }

                                lst.Add(poitb);
                            }
                        }
                    }
                }
                //xử lý cho danh sách ngược lại do đang sắp giảm dần
                var lstDraw = new List<PointInfo>();
                if (lst.Count > 0)
                {
                    for (int i = lst.Count; i > 0; i--)
                    {
                        lstDraw.Add(lst[i - 1]);
                    }
                    customChart1.DrawChart(lstDraw);
                }
            }
        }

        private void btnPhongToBieuDo_Click(object sender, EventArgs e)
        {
            var f = new FrmZoomImage();
            f.pbImage.Image = customChart1.GetChart();
            f.ShowDialog();
        }

        private void btnXemLichSuKSD_Click(object sender, EventArgs e)
        {
            ucLichSuKhangSinhDo1.Get_Data(lblPatientID.Text);
        }
    }
}
