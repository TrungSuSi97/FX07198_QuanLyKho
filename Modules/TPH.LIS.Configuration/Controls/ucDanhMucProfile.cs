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
    public partial class ucDanhMucProfile : UserControl
    {
        public ucDanhMucProfile()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public bool isAdmin = false;
        public string[] arrPhanQuyenNhom = new string[0];
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public event EventHandler BuutonThemMoiProfileClick;
        public event EventHandler BuutonXoaProfileClick;
        public event EventHandler LuoiProfileChinhSua;
        public DataTable CurrentDataSource;
        public void Load_Config()
        {
            if (!isCreatedGrid)
            {
                ucDanhSachXetNghiem1.UseCheckBox = true;
                ucDanhSachXetNghiem1.AutoExpandAll = true;
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_PROFILE(), gvProfile, "coldmprofile_", true, true, true, true, true, true
                    ,new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profileid)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Tgnhap) });
                gvProfile.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profileid)].OptionsColumn.AllowEdit = true;
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_PROFILE_CHITIET(), gvProfileChiTiet, "coldmprofilect_", true, true, true, false, true, true
                    , allowEditColumn: new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Soluongxn) });
                gvProfileChiTiet.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Soluongxn)].OptionsColumn.ReadOnly = false;
                gvProfileChiTiet.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Soluongxn)].OptionsColumn.AllowEdit = true;
                isCreatedGrid = true;
            }
            Load_DMProfile();
        }
        private void Load_DMProfile()
        {
            gvProfile.FocusedColumnChanged -= GvProfile_FocusedColumnChanged;
            gvProfile.FocusedRowChanged -= GvProfile_FocusedRowChanged;
            var data = _systemConfigService.Data_dm_xetnghiem_profile(string.Empty);
            CurrentDataSource = null;
            if (data != null)
            {
                CurrentDataSource = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcProfile.DataSource = data;
            gvProfile.FocusedColumnChanged += GvProfile_FocusedColumnChanged;
            gvProfile.FocusedRowChanged += GvProfile_FocusedRowChanged;
            Load_DMProfileChiTiet();
        }

        private void GvProfile_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DMProfileChiTiet();
        }

        private void GvProfile_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DMProfileChiTiet();
        }

        private void Load_DMProfileChiTiet()
        {
            gcProfileChiTiet.DataSource = null;
            ucDanhSachXetNghiem1.Load_DanhSach(new DataTable());
            if (gvProfile.FocusedRowHandle > -1)
            {
                var maprofile = gvProfile.GetRowCellValue(gvProfile.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profileid)).ToString();
                var data = _systemConfigService.Data_dm_xetnghiem_profile_chitiet(maprofile, string.Empty);
                if (data != null)
                {
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
                gcProfileChiTiet.DataSource = data;
                var dataXn = _systemConfigService.Data_dm_xetnghiem_NotInProfile(maprofile);
                if(dataXn != null)
                {
                    var filter = (isAdmin ? string.Empty : string.Format("{0} in ('{1}')", ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Manhomcls), (arrPhanQuyenNhom == null ? "---NONE---" : string.Join("','", arrPhanQuyenNhom))));
                    if (!string.IsNullOrEmpty(filter))
                        dataXn = WorkingServices.SearchResult_OnDatatable(dataXn, filter);
                    ucDanhSachXetNghiem1.Load_DanhSach(dataXn);
                }
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (gvProfile.FocusedRowHandle > -1)
            {
                var maprofile = gvProfile.GetRowCellValue(gvProfile.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profileid)).ToString();
                var lst = ucDanhSachXetNghiem1.LstMaXnChon;
                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        _systemConfigService.Insert_dm_xetnghiem_profile_chitiet(new DM_XETNGHIEM_PROFILE_CHITIET()
                        {
                            Maxn = item,
                            Profileid = maprofile,
                            Nguoinhap = UserId
                        });
                    }
                    Load_DMProfileChiTiet();
                }
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if(gvProfileChiTiet.SelectedRowsCount >0)
            {
                if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chi tiết xét nghiệm đang chọn?"))
                {
                    foreach (var item in gvProfileChiTiet.GetSelectedRows())
                    {
                        if (gvProfileChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Maxn)) != null)
                        {
                            var maProfile = gvProfileChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Profileid)).ToString();
                            var maXn = gvProfileChiTiet.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Maxn)).ToString();
                            var obj = _systemConfigService.Get_Info_dm_xetnghiem_profile_chitiet(maProfile, maXn);
                            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                            {   
                                Idhanhdong = (int)Log.LogActionId.Delete,
                                Madanhmuc = string.Format("ProfileID_{0}_MaXn_{1}", maProfile, maXn),
                                Nguoithuchien = UserId,
                                Noidung = string.Format("Xóa profile chi tiết: {0}", WorkingServices.GetDelete_Containt(obj)),
                                Idnhatky = Log.LogTableIds.Dm_xetnghiem_profile_chitiet,
                                Pcthuchien = Environment.MachineName
                            });
                            _systemConfigService.Delete_dm_xetnghiem_profile_chitiet(maProfile, maXn);
                        }
                    }
                    Load_DMProfileChiTiet();
                }
            }
        }

        private void btnThemProfile_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMaNhomCLS.Text))
            {
                if(!string.IsNullOrEmpty(txtTenNhomCLS.Text))
                {
                    var objNew = new DM_XETNGHIEM_PROFILE();
                    objNew.Profileid = txtMaNhomCLS.Text;
                    objNew.Profilename = txtTenNhomCLS.Text;
                    objNew.Profileslss = checkBox1.Checked;
                    objNew.Nguoinhap = UserId;
                    _systemConfigService.Insert_dm_xetnghiem_profile(objNew);
                    Load_DMProfile();
                    this.BuutonThemMoiProfileClick?.Invoke(this, e);
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập tên profile.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã profile.");
        }

        private void btnXoaProfile_Click(object sender, EventArgs e)
        {
            if (gvProfile.FocusedRowHandle > -1)
            {
                if (gvProfileChiTiet.RowCount == 0)
                {
                    var maprofile = gvProfile.GetRowCellValue(gvProfile.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profileid)).ToString();
                    var tenprofile = gvProfile.GetRowCellValue(gvProfile.FocusedRowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profilename)).ToString();
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa profile: {0}?", maprofile)))
                    {
                        var obj = _systemConfigService.Get_Info_dm_xetnghiem_profile(maprofile);
                        _systemConfigService.Delete_dm_xetnghiem_profile(maprofile);
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = maprofile,
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa profile: {0}", WorkingServices.GetDelete_Containt(obj)) ,
                            Idnhatky = Log.LogTableIds.Dm_xetnghiem_profile,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DMProfile();
                        this.BuutonXoaProfileClick?.Invoke(this, e);
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy xóa chi tiết trước.");
            }
        }

        private void btnLamMoiProfile_Click(object sender, EventArgs e)
        {
            Load_DMProfile();
        }

        private void gvProfile_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var id = gvProfile.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE>(x => x.Profileid)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_profile(id);
            var objSource = obj.Copy();
            DataRow row = gvProfile.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_PROFILE)WorkingServices.Get_InfoForObject(obj, row);
            obj.Tgnhap = objSource.Tgnhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = id,
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_profile,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_profile(obj);
            //bubble the event up to the parent
            this.LuoiProfileChinhSua?.Invoke(this, new EventArgs());
        }

        private void gvProfileChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var id = gvProfileChiTiet.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Profileid)).ToString();
            var iddetail = gvProfileChiTiet.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_PROFILE_CHITIET>(x => x.Maxn)).ToString();
            var obj = _systemConfigService.Get_Info_dm_xetnghiem_profile_chitiet(id, iddetail);
            var objSource = obj.Copy();
            DataRow row = gvProfileChiTiet.GetDataRow(e.RowHandle);
            obj = (DM_XETNGHIEM_PROFILE_CHITIET)WorkingServices.Get_InfoForObject(obj, row);
            obj.Tgnhap = objSource.Tgnhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = id,
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_xetnghiem_profile_chitiet,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_xetnghiem_profile_chitiet(obj);
            //bubble the event up to the parent
            this.LuoiProfileChinhSua?.Invoke(this, new EventArgs());
        }
    }
}
