using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using TPH.LIS.Log.Services.WorkingLog;
using DevExpress.Xpo.DB.Helpers;
using System.IO;
using TPH.Common.Contants;
using DevExpress.Utils.DirectXPaint;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucBoPhan_Nhom : UserControl
    {
        public ucDanhMucBoPhan_Nhom()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public bool isAdmin = false;
        public string[] arrPhanQuyenNhom = new string[0];
        public string[] arrPhanQuyenBoPhan = new string[0];
        public DataTable CurrentDataSourceBoPhan;
        public DataTable CurrentDataSourceNhom;
        public event EventHandler LuoiBoPhanChinhSua;
        public event EventHandler LuoiNhomChinhSua;
        public event EventHandler BuutonThemMoiBoPhanClick;
        public event EventHandler BuutonThemMoiNhomClick;
        public event EventHandler BuutonXoaBoPhanClick;
        public event EventHandler BuutonXoaNhomClick;
        public void Load_Config()
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_BOPHAN(), gvDanhMucBoPhan, "coldmbophan_", true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Mabophan)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Thoigiannhap) });
                var gridCol = gvDanhMucBoPhan.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Logoiso)];
                var reItem = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
                reItem.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
                reItem.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                gridCol.ColumnEdit = reItem;
               
                var gridCol2 = gvDanhMucBoPhan.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Logoiso2)];
                var reItem2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
                reItem2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                reItem2.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
                gridCol2.ColumnEdit = reItem2;
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_NHOM(), gvDanhMucNhom, "coldmnhom_", true, true, true, true, true, true
                    ,new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Manhomcls)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Thoigiannhap) });
                isCreatedGrid = true;
            }
            Load_DMBoPhan();
            Load_DMNhom();
        }
        public void Load_DMBoPhan()
        {
            var data = _systemConfigService.Data_dm_xetnghiem_bophan((isAdmin ? string.Empty : (arrPhanQuyenBoPhan == null ? "---NONE---" : string.Join(",", arrPhanQuyenBoPhan))));
            CurrentDataSourceBoPhan = null;
            if (data != null)
            {
                CurrentDataSourceBoPhan = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcDanhMucBoPhan.DataSource = data;
            cboBoPhan.DataSource = data.Copy();
            cboBoPhan.ValueMember = "MaBoPhan";
            cboBoPhan.DisplayMember = "TenBoPhan";
            if (data.Rows.Count > 0)
                cboBoPhan.SelectedIndex = 0;
        }
        public void Load_DMNhom()
        {
            var data = _systemConfigService.Data_dm_xetnghiem_nhom((isAdmin ? string.Empty : (arrPhanQuyenNhom == null ? "---NONE---" : string.Join(",", arrPhanQuyenNhom))));
            CurrentDataSourceNhom = null;
            if (data != null)
            {
                CurrentDataSourceNhom = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcDanhMucNhom.DataSource = data;
        }
        private void btnLamMoiNhom_Click(object sender, EventArgs e)
        {
            Load_DMNhom();
        }
        private void btnLamMoiBoPhan_Click(object sender, EventArgs e)
        {
            Load_DMBoPhan();
        }
        private void gvDanhMucBoPhan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var mabophan = gvDanhMucBoPhan.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Mabophan)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_bophan(mabophan);
            var objSource = obj.Copy();
            DataRow row = gvDanhMucBoPhan.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_BOPHAN)WorkingServices.Get_InfoForObject(obj, row);
            obj.Thoigiannhap = objSource.Thoigiannhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = mabophan,
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_bophan,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_bophan(obj);
            //bubble the event up to the parent
            this.LuoiBoPhanChinhSua?.Invoke(this, new EventArgs());
        }
        private void gvDanhMucNhom_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var manhom = gvDanhMucNhom.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Manhomcls)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_nhom(manhom);
            var objSource = obj.Copy();
            DataRow row = gvDanhMucNhom.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_NHOM)WorkingServices.Get_InfoForObject(obj, row);
            obj.Thoigiannhap = objSource.Thoigiannhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = manhom,
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_nhom,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_nhom(obj);
            //bubble the event up to the parent
            this.LuoiNhomChinhSua?.Invoke(this, new EventArgs());
        }
        private void btnThemBoPhan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenBoPhan.Text))
            {
                if (!string.IsNullOrEmpty(txtTenBoPhan.Text))
                {
                    var objNew = new DM_XETNGHIEM_BOPHAN();
                    objNew.Mabophan = txtMaBoPhan.Text;
                    objNew.Tenbophan = txtTenBoPhan.Text;
                    objNew.Nguoinhap = UserId;
                    var ok = _systemConfigService.Insert_dm_xetnghiem_bophan(objNew);
                    if (ok.Id > 0)
                        Load_DMBoPhan();
                    this.BuutonThemMoiBoPhanClick?.Invoke(this, new EventArgs());
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập tên bộ phận.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã bộ phận.");
        }
        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            if (cboBoPhan.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(txtMaNhomCLS.Text))
                {
                    if (!string.IsNullOrEmpty(txtTenNhomCLS.Text))
                    {
                        var objNew = new DM_XETNGHIEM_NHOM();
                        objNew.Manhomcls = txtMaNhomCLS.Text;
                        objNew.Tennhomcls = txtTenNhomCLS.Text;
                        objNew.Mabophan = cboBoPhan.SelectedValue.ToString();
                        objNew.Thutuin = (int)numThuTuInNhom.Value;
                        objNew.Nguoinhap = UserId;
                        if (_systemConfigService.Insert_dm_xetnghiem_nhom(objNew) > 0)
                            Load_DMNhom();
                        this.BuutonThemMoiNhomClick?.Invoke(this, new EventArgs());
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Hãy nhập tên nhóm.");
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập mã nhóm.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn bộ phận.");
        }
        private void gc_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var grid = (GridControl)sender;
                ((ColumnView)grid.FocusedView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void txtMaBoPhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenBoPhan);
        }

        private void cboBoPhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtMaNhomCLS);
        }

        private void txtMaNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenNhomCLS);
        }

        private void txtTenNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numThuTuInNhom);
        }

        private void btnXoaBoPhan_Click(object sender, EventArgs e)
        {
            if (gvDanhMucBoPhan.FocusedRowHandle >-1)
            {
                var mabophan = gvDanhMucBoPhan.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Mabophan)).ToString();
                var tenbophan = gvDanhMucBoPhan.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BOPHAN>(x => x.Tenbophan)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa bộ phận: {0}?", mabophan)))
                {
                    if (_systemConfigService.Delete_dm_xetnghiem_bophan(mabophan) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = mabophan,
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa bộ phận: {0} - Tên: {1}", mabophan, tenbophan),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_bophan,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DMBoPhan();
                        this.BuutonXoaBoPhanClick?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (gvDanhMucNhom.FocusedRowHandle > -1)
            {
                var manhom = gvDanhMucNhom.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Manhomcls)).ToString();
                var tennhom = gvDanhMucNhom.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_NHOM>(x => x.Tennhomcls)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa nhóm: {0}?", manhom)))
                {
                    if (_systemConfigService.Delete_dm_xetnghiem_nhom(manhom) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = manhom,
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa nhóm: {0} - Tên: {1}", manhom, tennhom),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_nhom,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DMNhom();
                        this.BuutonXoaNhomClick?.Invoke(this, new EventArgs());
                    }
                }
            }
        }
    }
}
