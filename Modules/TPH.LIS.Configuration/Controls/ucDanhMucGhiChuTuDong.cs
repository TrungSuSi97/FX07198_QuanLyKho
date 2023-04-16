using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucGhiChuTuDong : UserControl
    {
        public ucDanhMucGhiChuTuDong()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public bool isAdmin = false;
        public string[] arrPhanQuyenNhom = new string[0];
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public event EventHandler BuutonThemMoiClick;
        public event EventHandler BuutonXoaClick;
        public event EventHandler LuoiChinhSua;
        public DataTable CurrentDataSource;
        private string prefixColumnName = "colghichu_";
        public void Load_Config(DataTable dataDMXN)
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_GHICHUTUDONG(), gvDanhSach, prefixColumnName, true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Id)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Maxn)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Tgnhap) });
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Id)].Width = 50;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Ghichu)].Width = 350;

                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Maxn)].AppearanceCell.BackColor = Color.LightPink;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Idmayxn)].AppearanceCell.BackColor = Color.LightPink;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Ketqua)].AppearanceCell.BackColor = Color.LightPink;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Loaigiatrisosanh)].AppearanceCell.BackColor = Color.LightPink;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Gioitinh)].AppearanceCell.BackColor = Color.LightPink;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Sosanhtuyetdoi)].AppearanceCell.BackColor = Color.LightPink;

                ucDanhSachXetNghiem1.arrPhanQuyenNhom = arrPhanQuyenNhom;
                ucDanhSachXetNghiem1.isAdmin = isAdmin;
                ucDanhSachXetNghiem1.AutoExpandAll = true;
                isCreatedGrid = true;
            }
            Load_DanhMucXetNghiem(dataDMXN);
            Load_DanhMucCauHinh();
        }
        public void Load_DanhMucXetNghiem(DataTable data)
        {
            ucDanhSachXetNghiem1.Load_DanhSach(data);
        }
        private void Load_DanhMucCauHinh()
        {
            var data = new DataTable();
            //Kiển tra load xét nghiệm theo đúng nhóm quyền được cấp.
            //Dựa vào xét nghiệm danh mục
            if (ucDanhSachXetNghiem1.CurrentDataSource != null)
            {
                var dataCheck = ucDanhSachXetNghiem1.CurrentDataSource;
                data = _systemConfigService.Data_dm_xetnghiem_ghichutudong(null, (radXemTatCaGhiChu.Checked ? string.Empty : ucDanhSachXetNghiem1.MaXnDangChon));

                CurrentDataSource = null;
                if (data != null)
                {
                    if (data.Rows.Count > 0 && !isAdmin)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var checkXN = data.Rows[i]["MaXN"].ToString();
                            var dtSearch = WorkingServices.SearchResult_OnDatatable(dataCheck, string.Format("MaXN = '{0}'", checkXN));
                            if (dtSearch.Rows.Count == 0)
                            {
                                data.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    CurrentDataSource = data.Copy();
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
            }
            gcDanhSach.DataSource = data;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachXetNghiem1.MaXnDangChon))
            {
                var objNew = new DM_XETNGHIEM_GHICHUTUDONG();
                objNew.Maxn = ucDanhSachXetNghiem1.MaXnDangChon;
                objNew.Nguoinhap = UserId;
                _systemConfigService.Insert_dm_xetnghiem_ghichutudong(objNew);
                Load_DanhMucCauHinh();
                gvDanhSach.FocusedRowHandle = gvDanhSach.RowCount - 1;
                //bubble the event up to the parent
                this.BuutonThemMoiClick?.Invoke(this, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var id = int.Parse(gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Id)).ToString());
                var maxn = gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Maxn)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa cài đặt ghi chú: {0}?", maxn)))
                {
                    var obj = _systemConfigService.Get_Info_dm_xetnghiem_ghichutudong(id);
                    if (_systemConfigService.Delete_dm_xetnghiem_ghichutudong(id) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = string.Format("Id_{0}_MaXN_{1}", id.ToString(), maxn),
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa ghi chú tự động: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_ghichutudong,
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
            var id = int.Parse(gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Id)).ToString());
            var maxn = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_GHICHUTUDONG>(x => x.Maxn)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_ghichutudong(id);
            var objSource = obj.Copy();
            DataRow row = gvDanhSach.GetDataRow(e.RowHandle);
            obj.Tgnhap = objSource.Tgnhap;
            obj = (DM_XETNGHIEM_GHICHUTUDONG)WorkingServices.Get_InfoForObject(obj, row);
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("Id_{0}_MaXN_{1}", id.ToString(), maxn),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_ghichutudong,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_ghichutudong(obj);
            //bubble the event up to the parent
            this.LuoiChinhSua?.Invoke(this, new EventArgs());
        }

        private void ucDanhSachXetNghiem1_LuoiCellFocusChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachXetNghiem1.MaXnDangChon))
            {
                Load_DanhMucCauHinh();
            }
        }

        private void radKieuXem_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                Load_DanhMucCauHinh();
        }
    }
}
