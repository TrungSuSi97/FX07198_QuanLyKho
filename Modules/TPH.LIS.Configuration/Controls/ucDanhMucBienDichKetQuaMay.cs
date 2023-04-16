using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Constants;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucBienDichKetQuaMay : UserControl
    {
        public ucDanhMucBienDichKetQuaMay()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public bool isAdmin = false;
        public string[] arrPhanQuyenMayXN = new string[0];
        public string UserId = string.Empty;
        public string DinhDang = string.Empty;
        bool isCreatedGrid = false;
        public event EventHandler BuutonThemMoiClick;
        public event EventHandler BuutonXoaClick;
        public event EventHandler LuoiChinhSua;
        public DataTable CurrentDataSource;
        private string prefixColumnName = "coldmbiendich_";
        public void Load_Config()
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_BIENDICHKETQUA(), gvDanhSach, prefixColumnName, true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Autoid)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Loaibiendich)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Tgnhap) });
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Autoid)].Width = 50;

           
                btnLamMoi.Click += btnLamMoi_Click;
                btnThem.Click += btnThem_Click;
                btnXoa.Click += btnXoa_Click;
                gvDanhSach.CellValueChanged += gvDanhSach_CellValueChanged;
                isCreatedGrid = true;
            }
            Load_LoaiBienDich();
            gvDanhSach.BestFitColumns();
            Load_DanhMucCauHinh();
        }

        private void Load_LoaiBienDich()
        {
            var data = LoaiBienDich.DataLoaiBienDich();
            cboLoaiBienDich.DataSource = data;
            cboLoaiBienDich.ValueMember = "Id";
            cboLoaiBienDich.DisplayMember = "NoiDung";

            var gridCol = gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Loaibiendich)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cbo.DataSource = data.Copy();
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "NoiDung";
            cbo.NullValuePrompt = "--NONE--";
            gridCol.ColumnEdit = cbo;
            gridCol.GroupIndex = 0;
            gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Idmay)].GroupIndex = 1;
        }
        private void Load_DanhMucCauHinh()
        {
            var data = new DataTable();

            data = _systemConfigService.Data_dm_xetnghiem_biendichketqua(null);

            CurrentDataSource = null;
            if (data != null)
            {
                if (data.Rows.Count > 0 && !isAdmin)
                {
                    if (arrPhanQuyenMayXN == null)
                        data = data.Clone();
                    else
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var checkIdMay = data.Rows[i][ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Idmay)].ToString();

                            if (!arrPhanQuyenMayXN.Where(x => x.Equals(checkIdMay)).Any())
                            {
                                data.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                CurrentDataSource = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }

            gcDanhSach.DataSource = data;
            gvDanhSach.ExpandAllGroups();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboLoaiBienDich.SelectedIndex > -1)
            {
                if (numIdMayXN.Value > 0)
                {
                    var objNew = new DM_XETNGHIEM_BIENDICHKETQUA();
                    objNew.Loaibiendich = int.Parse(cboLoaiBienDich.SelectedValue.ToString());
                    objNew.Idmay = (int)numIdMayXN.Value;
                    objNew.Maxnmay = txtMaXNMay.Text;
                    objNew.Dinhdang = DinhDang;
                    objNew.Nguoinhap = UserId;
                    _systemConfigService.Insert_dm_xetnghiem_biendichketqua(objNew);
                    Load_DanhMucCauHinh();
                    gvDanhSach.FocusedRowHandle = gvDanhSach.RowCount - 1;
                    //bubble the event up to the parent
                    this.BuutonThemMoiClick?.Invoke(this, e);
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập id máy xét nghiệm");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn loại biên dịch");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var id = int.Parse(gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Autoid)).ToString());
                var maxnMay = gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Maxnmay)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa cài đặt biên dịch: {0}?", string.Format("Id_{0}_MaXNMay_{1}", id.ToString(), maxnMay))))
                {
                    var obj = _systemConfigService.Get_Info_dm_xetnghiem_biendichketqua(id);
                    if (_systemConfigService.Delete_dm_xetnghiem_biendichketqua(id) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = string.Format("Id_{0}_MaXNMay_{1}", id.ToString(), maxnMay),
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa biên dịch: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_biendichketqua,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DanhMucCauHinh();
                        this.BuutonXoaClick?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhMucCauHinh();
        }

        private void gvDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var id = int.Parse(gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Autoid)).ToString());
            var maxnMay = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BIENDICHKETQUA>(x => x.Maxnmay)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_biendichketqua(id);
            var objSource = obj.Copy();
            DataRow row = gvDanhSach.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_BIENDICHKETQUA)WorkingServices.Get_InfoForObject(obj, row);
            obj.Tgnhap = objSource.Tgnhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("Id_{0}_MaXNMay_{1}", id.ToString(), maxnMay),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_biendichketqua,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_biendichketqua(obj);
            //bubble the event up to the parent
            this.LuoiChinhSua?.Invoke(this, new EventArgs());
        }
      
    }
}
