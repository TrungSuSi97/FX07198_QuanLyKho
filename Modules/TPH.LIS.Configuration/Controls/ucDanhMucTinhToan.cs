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
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Constants;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Extensions;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucTinhToan : UserControl
    {
        public ucDanhMucTinhToan()
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
        private string prefixColumnName = "coldmtinhtoan_";

        public void Load_Config(DataTable dataDMXN)
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_TINHTOAN(), gvDanhSach, prefixColumnName, true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Id)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Tgnhap) });
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Id)].Width = 50;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn1)].Width = 75;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn2)].Width = 75;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn3)].Width = 75;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn4)].Width = 75;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn5)].Width = 75;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Congthuctinh)].Width = 250;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Dieukienlaycongthuc)].Width = 150;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)].Width = 150;
                isCreatedGrid = true;
            }
            LoadLoaiTinhToan();
            Load_DanhMucXetNghiem(dataDMXN);
            Load_DMTinhToan();
        }
        public void LoadLoaiTinhToan()
        {
            var data = LoaiTinhToan.DataLoaiTinhToan();
            lueLoaiTinhToan.Properties.DataSource = data;
            lueLoaiTinhToan.Properties.ValueMember = "Id";
            lueLoaiTinhToan.Properties.DisplayMember = "NoiDung";
            var gridCol = gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)];
            var cbo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            cbo.DataSource = data;
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "NoiDung";
            cbo.NullValuePrompt = "--NONE--";
            gridCol.ColumnEdit = cbo;

        }
        public void Load_DanhMucXetNghiem(DataTable data)
        {
           ucSearchLookupEditor_DanhSachXetNghiem1.Load_DanhMuc((arrPhanQuyenNhom == null ? "--NONE---" : string.Join(",", arrPhanQuyenNhom)), !isAdmin, data);
        }
        private void Load_DMTinhToan()
        {
            var data = new DataTable();
            //Kiển tra load xét nghiệm theo đúng nhóm quyền được cấp.
            //Dựa vào xét nghiệm danh mục
            if (ucSearchLookupEditor_DanhSachXetNghiem1.DataSource != null)
            {
                var dataCheck = (DataTable)ucSearchLookupEditor_DanhSachXetNghiem1.DataSource;
                data = _systemConfigService.Data_dm_xetnghiem_tinhtoan(null);

                CurrentDataSource = null;
                if (data != null)
                {
                    data.Columns.Add("tenloaitinhtoan", typeof(string));
                    if (data.Rows.Count > 0)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            var maLoaiTinhToan = data.Rows[i][ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Cachtinhtoan)].ToString();
                            if (maLoaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQua))
                                data.Rows[i]["tenloaitinhtoan"] = "Tính toán kết quả";
                            else if (maLoaiTinhToan.Equals(CommonConfigConstant.DuyetKetQua))
                                data.Rows[i]["tenloaitinhtoan"] = "Cảnh báo duyệt kết quả - Định lượng";
                            else if (maLoaiTinhToan.Equals(CommonConfigConstant.DuyetKetQuaDinhTinh))
                                data.Rows[i]["tenloaitinhtoan"] = "Cảnh báo duyệt kết quả - Định tính";
                            else if (maLoaiTinhToan.Equals(CommonConfigConstant.TinhToanKetQuaSoSanh))
                                data.Rows[i]["tenloaitinhtoan"] = "Tính toán kết quả (so sánh) - Định tính";
                            else
                                data.Rows[i]["tenloaitinhtoan"] = "Chưa khai báo";

                            if (!isAdmin)
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
                    }
                    CurrentDataSource = data.Copy();
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
            }
            gcDanhSach.DataSource = data;
            gvDanhSach.ExpandAllGroups();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_DanhSachXetNghiem1.SelectedValue != null)
            {
                if (lueLoaiTinhToan.EditValue != null)
                {
                    var objNew = new DM_XETNGHIEM_TINHTOAN();
                    objNew.Maxn = ucSearchLookupEditor_DanhSachXetNghiem1.SelectedValue.ToString();
                    objNew.Nguoinhap = UserId;
                    objNew.Cachtinhtoan = lueLoaiTinhToan.EditValue.ToString();
                    if (_systemConfigService.Insert_dm_xetnghiem_tinhtoan(objNew) > 0)
                    {
                        Load_DMTinhToan();
                        gvDanhSach.FocusedRowHandle = gvDanhSach.RowCount - 1;
                        //bubble the event up to the parent
                        this.BuutonThemMoiClick?.Invoke(this, new EventArgs());
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn loại tính toán.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn xét nghiệm.");
        }

        private void gvDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var id = int.Parse(gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Id)).ToString());
            var maxn = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_tinhtoan(id);
            var objSource = obj.Copy();
            DataRow row = gvDanhSach.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_TINHTOAN)WorkingServices.Get_InfoForObject(obj, row);
            obj.Tgnhap = objSource.Tgnhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("Id_{0}_MaXN_{1}",id.ToString(), maxn),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_tinhtoan,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_tinhtoan(obj);
            //bubble the event up to the parent
            this.LuoiChinhSua?.Invoke(this, new EventArgs());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.FocusedRowHandle > -1)
            {
                var id = int.Parse(gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Id)).ToString());
                var maxn = gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_TINHTOAN>(x => x.Maxn)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa tính toán: {0}?", maxn)))
                {
                    var obj = _systemConfigService.Get_Info_dm_xetnghiem_tinhtoan(id);
                    if (_systemConfigService.Delete_dm_xetnghiem_tinhtoan(id) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = string.Format("Id_{0}_MaXN_{1}", id.ToString(), maxn),
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa tính toán: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_tinhtoan,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DMTinhToan();
                        this.BuutonXoaClick?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DMTinhToan();
        }
    }
}
