using DevExpress.Xpo.DB.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.Log.Services.WorkingLog;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucLoaiMau : UserControl
    {
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public ucLoaiMau()
        {
            InitializeComponent();
        }
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public void Load_Config()
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_LOAIMAU(), gvDanhSachLoaiMauChay, "colDMLoaiMau_", true, true, true, true, true, true
                     , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Maloaimau)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Tgnhap) });
                isCreatedGrid = true;

            }
            var data = _systemConfigService.Data_CauHinh_PhanLoaiChucNang("and EnumID in (1,15,16,17,18)");
            cboPhanLoai.DataSource = data.Copy();
            cboPhanLoai.ValueMember = "MaPhanLoai";
            cboPhanLoai.DisplayMember = "TenPhanLoai";

            cboPhanLoaiMauNhan.DataSource = data;
            cboPhanLoaiMauNhan.ValueMember = "MaPhanLoai";
            cboPhanLoaiMauNhan.DisplayMember = "TenPhanLoai";

            Load_DanhSachOngMau();
            Load_List_LoaiMau();
            Load_DanhSachLoaiMauChinh();
        }
        #region Loại mẫu chạy
        private void Load_List_LoaiMau()
        {
            var data = _systemConfigService.Data_dm_xetnghiem_loaimau(string.Empty, string.Empty);
            data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcDanhSachLoaiMauChay.DataSource = data;
        }
        private void Them_LoaiMau()
        {
            if (txtMaLoaiMau.BackColor == Color.Yellow || txtMaLoaiMau.BackColor == Color.LightGreen)
            {
                if (cboLoaiMauNhan.SelectedIndex < 0)
                    CustomMessageBox.MSG_Information_OK("Hãy chọn ống mẫu!");
                else if (cboLoaiMauChinh.SelectedIndex < 0)
                    CustomMessageBox.MSG_Information_OK("Hãy chọn phân loại chính!");
                else if (string.IsNullOrEmpty(txtMaLoaiMau.Text))
                    CustomMessageBox.MSG_Information_OK("Hãy nhập mã loại mẫu!");
                else if (cboPhanLoai.SelectedIndex < 0)
                    CustomMessageBox.MSG_Information_OK("Hãy chọn phân loại mẫu!");
                else
                {
                    DM_XETNGHIEM_LOAIMAU loaimau = new DM_XETNGHIEM_LOAIMAU();
                    if (txtMaLoaiMau.BackColor == Color.Yellow)
                        loaimau.Maloaimau = txtMaLoaiMau.Text;
                    else
                        loaimau.Maloaimau = txtMaLoaiMau.Tag.ToString();
                    loaimau.Loaimau = txtTenLoaiMau.Text;
                    loaimau.Loaidvcls = cboPhanLoai.SelectedValue.ToString();
                    loaimau.Manhomloaimau = cboLoaiMauNhan.SelectedValue.ToString();
                    loaimau.Maloaimauchinh = cboLoaiMauChinh.SelectedValue.ToString();

                    if (_systemConfigService.Insert_dm_xetnghiem_loaimau(loaimau) > -1)
                    {
                        Load_List_LoaiMau();
                        gvDanhSachLoaiMauChay.FocusedRowHandle = gvDanhSachLoaiMauChay.LocateByValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Maloaimau), loaimau.Maloaimau);
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Loại mẫu đã tồn tại.");
                }
            }
        }
        private void Delete_LoaiMau()
        {
            if (gvDanhSachLoaiMauChay.FocusedRowHandle > -1)
            {
                var maloaiMau = gvDanhSachLoaiMauChay.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Maloaimau)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa loại mẫu đang chọn?"))
                {
                    _systemConfigService.Delete_dm_xetnghiem_loaimau(maloaiMau);
                    Load_List_LoaiMau();
                }
            }
        }

        private void txtMaLoaiMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenLoaiMau);
        }

        private void txtTenLoaiMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtThuTu);
        }
        private void txtThuTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, true);
            if (e.KeyChar == (char)Keys.Enter)
            {
               btnThemLoaiMau_Click(sender, e);
                e.Handled = true;
            }
        }

        private void pnmauNhanMau_Click(object sender, EventArgs e)
        {
            ColorDialog cl = new ColorDialog();
            cl.ShowDialog();
            if (cl.Color != null)
            {
                pnmauNhanMau.BackColor = cl.Color;
                txtSlColor.Text = string.Format("{0},{1},{2}", pnmauNhanMau.BackColor.R, pnmauNhanMau.BackColor.G, pnmauNhanMau.BackColor.B);
            }
        }

        private void txtSlColor_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSlColor.Text))
            {
                string[] split = txtSlColor.Text.Split(',');
                if (split.Length == 3)
                {
                    if (WorkingServices.IsNumeric(split[0]) && WorkingServices.IsNumeric(split[1]) && WorkingServices.IsNumeric(split[2]))
                    {
                        pnmauNhanMau.BackColor = Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                    }
                    else
                        pnmauNhanMau.BackColor = Color.Empty;
                }
                else
                    pnmauNhanMau.BackColor = Color.Empty;
            }
            else
                pnmauNhanMau.BackColor = Color.Empty;
        }
        private void gvDanhSachLoaiMauChay_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var maLoaiMau = gvDanhSachLoaiMauChay.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Maloaimau)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_loaimau(maLoaiMau);
            var objSource = obj.Copy();
            DataRow row = gvDanhSachLoaiMauChay.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_LOAIMAU)WorkingServices.Get_InfoForObject(obj, row);
            obj.Tgnhap = objSource.Tgnhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("MaLoaiMau_{0}", maLoaiMau),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_loaimau,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_loaimau(obj);
        }
        private void btnLamMoiLoaiMau_Click(object sender, EventArgs e)
        {
            Load_List_LoaiMau();
        }

        private void btnThemLoaiMau_Click(object sender, EventArgs e)
        {
            Them_LoaiMau();
        }

        private void btnXoaLoaiMau_Click(object sender, EventArgs e)
        {
            Delete_LoaiMau();
        }
        #endregion
        #region  Ống mẫu
        private void Load_DanhSachOngMau()
        {
            pnLoaiMauNhan.Enabled = false;
            dtgLoaiMauNhan.CellEnter -= dtgLoaiMauNhan_CellEnter;
            var data = _systemConfigService.Get_Data_dm_xetnghiem_loaimau_nhom(dtgLoaiMauNhan, bvLoaiMauNhan, string.Empty);
            ControlExtension.BindDataToCobobox(data.Copy(), ref cboLoaiMauNhan, "MaNhomLoaiMau", "TenNhomLoaiMau");
            var gridCol = gvDanhSachLoaiMauChay.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Manhomloaimau)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            var dataShow = data.DefaultView.ToTable(true, "MaNhomLoaiMau", "TenNhomLoaiMau");
            dataShow.Columns["MaNhomLoaiMau"].Caption = "Mã ống mẫu";
            dataShow.Columns["TenNhomLoaiMau"].Caption = "Tên ống mẫu";
            cbo.DataSource = dataShow;
            cbo.ValueMember = "MaNhomLoaiMau";
            cbo.DisplayMember = "TenNhomLoaiMau";
            cbo.NullValuePrompt = "--NONE--";
            gridCol.ColumnEdit = cbo;
            dtgLoaiMauNhan.CellEnter += dtgLoaiMauNhan_CellEnter;

        }
        private void Save_OngMau()
        {
            if (pnLoaiMauNhan.Enabled)
            {
                if (string.IsNullOrEmpty(txtMaLoaiMauNhan.Text))
                    CustomMessageBox.MSG_Information_OK("Hãy nhập mã loại mẫu nhận!");
                else if (cboPhanLoaiMauNhan.SelectedIndex == -1)
                    CustomMessageBox.MSG_Information_OK("Hãy chọn phân loại mẫu nhận!");
                else
                {
                    var obj = new DM_XETNGHIEM_LOAIMAU_NHOM();
                    obj.Manhomloaimau = txtMaLoaiMauNhan.Text;
                    obj.Tennhomloaimau = txtTenLoaiMauNhan.Text;
                    obj.Hienthinhan = chkHienThiNhanMau.Checked;
                    obj.Loaidvcls = cboPhanLoaiMauNhan.SelectedValue.ToString();
                    obj.Thutu = int.Parse(txtThuTuMauNhan.Text == "" ? "0" : txtThuTuMauNhan.Text);
                    obj.Id1 = txtHenID.Text;
                    obj.Id2 = txtBCRoboID.Text;
                    obj.Id3 = txtOlpasoID.Text;
                    obj.Maunhanmau = txtSlColor.Text;
                    obj.ThuTuUuTienLay = int.Parse(txtThuTuUuTienLay.Text == "" ? "1" : txtThuTuUuTienLay.Text);
                    obj.TuInBarCodeKhiQuet = int.Parse(txtTuInBarcodeKhiQuet.Text == "" ? "0" : txtTuInBarcodeKhiQuet.Text);

                    if (txtMaLoaiMauNhan.BackColor == Color.LightGreen)
                        _systemConfigService.Update_dm_xetnghiem_loaimau_nhom(obj);
                    else
                        _systemConfigService.Insert_dm_xetnghiem_loaimau_nhom(obj);
                    Load_DanhSachOngMau();
                    bvLoaiMauNhan.BindingSource.Position = bvLoaiMauNhan.BindingSource.Find("MaNhomLoaiMau", obj.Manhomloaimau);
                }
            }
        }
        private void Clear_ThongTinOngMau()
        {
            txtMaLoaiMauNhan.Text = string.Empty;
            txtMaLoaiMauNhan.BackColor = Color.Empty;
            txtMaLoaiMauNhan.ReadOnly = false;

            txtTenLoaiMauNhan.Text = "";
            txtThuTuMauNhan.Text = "";
            txtThuTuUuTienLay.Text = "1";
            txtSlColor.Text = "";
            txtTuInBarcodeKhiQuet.Text = "0";
            cboPhanLoaiMauNhan.SelectedIndex = -1;
            txtHenID.Text = string.Empty;
            txtBCRoboID.Text = string.Empty;
            txtOlpasoID.Text = string.Empty;
        }
        private void SetThongTinOngMau()
        {
            Clear_ThongTinOngMau();
            pnLoaiMauNhan.Enabled = false;

            if (dtgLoaiMauNhan.CurrentRow != null)
            {
                txtMaLoaiMauNhan.Text = dtgLoaiMauNhan.CurrentRow.Cells[colMaLoaiMauNhan.Name].Value.ToString();
                txtTenLoaiMauNhan.Text = dtgLoaiMauNhan.CurrentRow.Cells[coltenLoaiMauNhan.Name].Value.ToString();
                txtThuTuMauNhan.Text = dtgLoaiMauNhan.CurrentRow.Cells[colLoiamUaNhan_ThuTu.Name].Value.ToString();
                txtSlColor.Text = dtgLoaiMauNhan.CurrentRow.Cells[colLoaiMuaNhan_MauChon.Name].Value.ToString();
                txtThuTuUuTienLay.Text = dtgLoaiMauNhan.CurrentRow.Cells[colThuTuUuTienLay.Name].Value.ToString();
                cboPhanLoaiMauNhan.SelectedValue = dtgLoaiMauNhan.CurrentRow.Cells[colLoaiMauNhan_PhanLoai.Name].Value.ToString();
                txtTuInBarcodeKhiQuet.Text = dtgLoaiMauNhan.CurrentRow.Cells[colTuInBarcodeKhiQuet.Name].Value.ToString();
                txtHenID.Text = dtgLoaiMauNhan.CurrentRow.Cells[colNhomLoaiMauID1.Name].Value.ToString();
                txtBCRoboID.Text = dtgLoaiMauNhan.CurrentRow.Cells[colNhomLoaiMauID2.Name].Value.ToString();
                txtOlpasoID.Text = dtgLoaiMauNhan.CurrentRow.Cells[colNhomLoaiMauID3.Name].Value.ToString();
            }
        }
        private void StartAddNew_MauNhan()
        {
            Clear_ThongTinOngMau();
            pnLoaiMauNhan.Enabled = true;

            txtMaLoaiMauNhan.BackColor = Color.Yellow;
            txtMaLoaiMauNhan.Focus();
        }
        private void StartEdit_MauNhan()
        {
            pnLoaiMauNhan.Enabled = true;
            txtMaLoaiMauNhan.ReadOnly = true;

            txtMaLoaiMauNhan.BackColor = Color.LightGreen;
            txtMaLoaiMauNhan.Focus();
        }
  

        private void txtMaLoaiMauNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenLoaiMauNhan);
        }

        private void txtTenLoaiMauNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, chkHienThiNhanMau);
        }

        private void chkHienThiNhanMau_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtThuTuMauNhan);
        }

        private void txtThuTuMauNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtThuTuUuTienLay);
        }

        private void btnLoaiMuNhan_Click(object sender, EventArgs e)
        {
            StartAddNew_MauNhan();
        }

        private void btnSuaMauNhan_Click(object sender, EventArgs e)
        {
            StartEdit_MauNhan();
        }

        private void btnLuuMauNhan_Click(object sender, EventArgs e)
        {
            Save_OngMau();
        }

        private void btnXoaMauNhan_Click(object sender, EventArgs e)
        {
            if (dtgLoaiMauNhan.CurrentRow != null)
            {
                var maNhomLoaiMau = dtgLoaiMauNhan.CurrentRow.Cells[colMaLoaiMauNhan.Name].Value.ToString();
                var tenNhomLoaiMau = dtgLoaiMauNhan.CurrentRow.Cells[coltenLoaiMauNhan.Name].Value.ToString();
                var obj = new DM_XETNGHIEM_LOAIMAU_NHOM();
                obj.Manhomloaimau = maNhomLoaiMau;
                obj.Tennhomloaimau = tenNhomLoaiMau;
                if(CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa loại mẫu nhận: {0} ?", tenNhomLoaiMau)))
                {
                    _systemConfigService.Delete_dm_xetnghiem_loaimau_nhom(obj);
                    Load_DanhSachOngMau();
                }
            }
        }

        private void dtgLoaiMauNhan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetThongTinOngMau();
        }

        private void btnXuatMauNhan_Click(object sender, EventArgs e)
        {
         //  Excel.ExportToExcel.Export(dtgLoaiMauNhan);
        }
        private void btnLoad_DSMauNhan_Click(object sender, EventArgs e)
        {
            Load_DanhSachOngMau();
        }

        #endregion

        private void txtThuTuUuTienLay_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTuInBarcodeKhiQuet);
        }

        private void txtTuInBarcodeKhiQuet_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboPhanLoaiMauNhan);
        }
        DataTable dataLoaiMauChinh = new DataTable();
        SqlDataAdapter daLoaMauChinh = new SqlDataAdapter();
        private void Load_DanhSachLoaiMauChinh()
        {
            var curretnValue = cboLoaiMauChinh.SelectedValue ?? string.Empty; ;
            _systemConfigService.Get_Data_dm_xetnghiem_loaimauchinh(dtgLoaiMauChinh, bvLoaiMauChinh, ref daLoaMauChinh, ref dataLoaiMauChinh, string.Empty);
            cboLoaiMauChinh.DataSource = dataLoaiMauChinh.Copy();
            cboLoaiMauChinh.ValueMember = "MaLoaiMauChinh";
            cboLoaiMauChinh.DisplayMember = "TenLoaiMauChinh";

            cboLoaiMauChinh.SelectedValue = curretnValue;

            var gridCol = gvDanhSachLoaiMauChay.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_LOAIMAU>(x => x.Maloaimauchinh)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            var dataShow = dataLoaiMauChinh.DefaultView.ToTable(true, "MaLoaiMauChinh", "TenLoaiMauChinh");
            dataShow.Columns["MaLoaiMauChinh"].Caption = "Mã loại mẫu chính";
            dataShow.Columns["TenLoaiMauChinh"].Caption = "Tên loại mẫu chính";
            cbo.DataSource = dataShow;
            cbo.ValueMember = "MaLoaiMauChinh";
            cbo.DisplayMember = "TenLoaiMauChinh";
            cbo.NullValuePrompt = "--NONE--";
            gridCol.ColumnEdit = cbo;

        }

        private void btnLayDSLoaiMauChinh_Click(object sender, EventArgs e)
        {
            Load_DanhSachLoaiMauChinh();
        }

        private void dtgLoaiMauChinh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DataProvider.UpdateData(daLoaMauChinh, ref dataLoaiMauChinh, string.Empty, string.Empty))
            {
                bvLoaiMauChinh.Focus();
                Load_DanhSachLoaiMauChinh();
            }
        }

        private void btnXoaLoaiMauChinh_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa dòng loại mẫu chính đang chọn ?"))
            {
                dtgLoaiMauChinh.Rows.RemoveAt(dtgLoaiMauChinh.CurrentRow.Index);
            }
        }
        private void Start_Add()
        {
            cboLoaiMauNhan.DataBindings.Clear();
            cboLoaiMauNhan.SelectedIndex = -1;
            txtMaLoaiMau.DataBindings.Clear();
            txtTenLoaiMau.DataBindings.Clear();
            txtMaLoaiMau.Enabled = true;
            txtTenLoaiMau.Enabled = true;
            txtMaLoaiMau.Text = "";
            txtTenLoaiMau.Text = "";
            cboPhanLoai.Enabled = true;
            cboLoaiMauNhan.Enabled = true;
            cboLoaiMauChinh.Enabled = true;
            txtMaLoaiMau.BackColor = Color.Yellow;
            txtMaLoaiMau.Focus();
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Start_Add();
        }
    }
}
