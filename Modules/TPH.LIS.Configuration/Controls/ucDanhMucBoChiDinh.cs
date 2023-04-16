using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Controls;
using TPH.LIS.Log.Services.WorkingLog;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucBoChiDinh : UserControl
    {
        public ucDanhMucBoChiDinh()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public bool isAdmin = false;
        public string[] arrPhanQuyenNhom = new string[0];
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public event EventHandler BuutonThemMoiBoClick;
        public event EventHandler BuutonXoaBoClick;
        public event EventHandler LuoiBoChinhSua;
        public DataTable CurrentDataSource;
        public void Load_Config(DataTable dataDMXN)
        {
            if (!isCreatedGrid)
            {
                ucDanhSachXetNghiem1.UseCheckBox = true;
                ucDanhSachXetNghiem1.AutoExpandAll = true;
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_BO(), gvBo, "coldmboxn_", true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Tgnhap) });
                gvBo.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)].OptionsColumn.ReadOnly = true;
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_BO_CHITIET(), gvBoChiTiet, "coldmboxnct_", true, true, true, false, true, true);
                isCreatedGrid = true;
            }
            Load_DanhMucXetNghiem(dataDMXN);
            Load_DMBo();
        }
        private void Load_DMBo()
        {
            gvBo.FocusedColumnChanged -= GvBo_FocusedColumnChanged;
            gvBo.FocusedRowChanged -= GvBo_FocusedRowChanged;
            var data = _systemConfigService.Data_dm_xetnghiem_bo(string.Empty);
            CurrentDataSource = null;
            if (data != null)
            {
                CurrentDataSource = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcBo.DataSource = data;
            gvBo.FocusedColumnChanged += GvBo_FocusedColumnChanged;
            gvBo.FocusedRowChanged += GvBo_FocusedRowChanged;
            Load_DMBoChiTiet();
        }
        public void Load_DanhMucXetNghiem(DataTable data)
        {
            ucDanhSachXetNghiem1.isKhongSD = true;
            ucDanhSachXetNghiem1.Load_DanhSach(data);
        }
        public void Load_danhmucprofile(DataTable dataProfile)
        {
            var data = new DataTable();
            if (dataProfile == null)
            {
                data = _systemConfigService.Data_dm_xetnghiem_profile(string.Empty);
            }
            else
                data = dataProfile.Copy();

            if (data != null)
            {
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcDanhSachProfile.DataSource = data;

        }
        private void GvBo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DMBoChiTiet();
        }

        private void GvBo_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DMBoChiTiet();
        }

        private void Load_DMBoChiTiet()
        {
            gcBoChiTiet.DataSource = null;
            if (gvBo.FocusedRowHandle > -1)
            {
                var maboXN = gvBo.GetRowCellValue(gvBo.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)).ToString();
                var data = _systemConfigService.Data_dm_xetnghiem_bo_chitiet(maboXN, string.Empty, false);
                if (data != null)
                {
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
                gcBoChiTiet.DataSource = data;
            }
        }
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (gvBo.FocusedRowHandle > -1)
            {
                var maprofile = gvBo.GetRowCellValue(gvBo.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)).ToString();
                var lst = ucDanhSachXetNghiem1.LstMaXnChon;
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        _systemConfigService.Insert_dm_xetnghiem_bo_chitiet(new DM_XETNGHIEM_BO_CHITIET()
                        {
                            Machidinh = item,
                            Maboxetnghiem = maprofile,
                            Xnprofile = false,
                            Nguoinhap = UserId
                        });
                    }
                    Load_DMBoChiTiet();
                }
            }
        }
        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (gvBoChiTiet.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chi tiết xét nghiệm đang chọn?"))
                {
                    foreach (var item in gvBoChiTiet.GetSelectedRows())
                    {
                        if (gvBoChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO_CHITIET>(x => x.Machidinh)) != null)
                        {
                            var maBo = gvBoChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO_CHITIET>(x => x.Maboxetnghiem)).ToString();
                            var maXn = gvBoChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO_CHITIET>(x => x.Machidinh)).ToString();
                            var profile = bool.Parse(gvBoChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO_CHITIET>(x => x.Xnprofile)).ToString());
                            var obj = _systemConfigService.Get_Info_dm_xetnghiem_bo_chitiet(maBo, maXn, profile);
                            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                            {
                                Idhanhdong = (int)Log.LogActionId.Delete,
                                Madanhmuc = string.Format("MaBoXN_{0}_MaDV_{1}", maBo, maXn),
                                Nguoithuchien = UserId,
                                Noidung = string.Format("Xóa bộ xn chi tiết: {0}", WorkingServices.GetDelete_Containt(obj)),
                                Idnhatky = Log.LogTableIds.Dm_xetnghiem_bo_chitiet,
                                Pcthuchien = Environment.MachineName
                            });
                            _systemConfigService.Delete_dm_xetnghiem_bo_chitiet(maBo, maXn, profile);
                        }
                    }
                    Load_DMBoChiTiet();
                }
            }
        }

        private void btnThemBo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNhomCLS.Text))
            {
                if (!string.IsNullOrEmpty(txtTenNhomCLS.Text))
                {
                    var objNew = new DM_XETNGHIEM_BO();
                    objNew.Maboxetnghiem = txtMaNhomCLS.Text;
                    objNew.Tenboxetnghiem = txtTenNhomCLS.Text;
                    objNew.Nguoinhap = UserId;
                    _systemConfigService.Insert_dm_xetnghiem_bo(objNew);
                    Load_DMBo();
                    this.BuutonThemMoiBoClick?.Invoke(this, e);
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập tên bộ xét nghiệm.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã bộ xét nghiệm.");
        }

        private void btnXoaBo_Click(object sender, EventArgs e)
        {
            if (gvBo.FocusedRowHandle > -1)
            {
                if (gvBoChiTiet.RowCount == 0)
                {
                    var maprofile = gvBo.GetRowCellValue(gvBo.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)).ToString();
                    var tenprofile = gvBo.GetRowCellValue(gvBo.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Tenboxetnghiem)).ToString();
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa bộ xét nghiệm: {0}?", maprofile)))
                    {
                        var obj = _systemConfigService.Get_Info_dm_xetnghiem_bo(maprofile);
                        _systemConfigService.Delete_dm_xetnghiem_bo(maprofile);
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = maprofile,
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa bộ xét nghiệm: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_bo,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DMBo();
                        this.BuutonXoaBoClick?.Invoke(this, e);
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy xóa chi tiết trước.");
            }
        }

        private void btnLamMoiBo_Click(object sender, EventArgs e)
        {
            Load_DMBo();
        }

        private void gvBo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var id = gvBo.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_bo(id);
            var objSource = obj.Copy();
            DataRow row = gvBo.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_BO)WorkingServices.Get_InfoForObject(obj, row);
            obj.Tgnhap = objSource.Tgnhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = id,
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_bo,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_bo(obj);
            //bubble the event up to the parent
            this.LuoiBoChinhSua?.Invoke(this, new EventArgs());
        }

        private void gvBoChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }

        private void btnThemProfile_Click(object sender, EventArgs e)
        {
            if (gvBo.FocusedRowHandle > -1)
            {
                var maprofile = gvBo.GetRowCellValue(gvBo.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_BO>(x => x.Maboxetnghiem)).ToString();
                if (gvDanhSachProfile.SelectedRowsCount > 0)
                {

                    foreach (var item in gvDanhSachProfile.GetSelectedRows())
                    {
                        if (gvDanhSachProfile.GetRowCellValue(item, colMaprofile) != null)
                        {
                            var madv = gvDanhSachProfile.GetRowCellValue(item, colMaprofile).ToString();
                            _systemConfigService.Insert_dm_xetnghiem_bo_chitiet(new DM_XETNGHIEM_BO_CHITIET()
                            {
                                Machidinh = madv,
                                Maboxetnghiem = maprofile,
                                Xnprofile = true,
                                Nguoinhap = UserId
                            });
                        }
                    }
                    Load_DMBoChiTiet();
                }

            }
        }
    }
}
