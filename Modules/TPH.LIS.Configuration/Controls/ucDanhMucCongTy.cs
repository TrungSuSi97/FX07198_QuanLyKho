﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucCongTy : UserControl
    {
        public ucDanhMucCongTy()
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
        private string prefixColumnName = "coldm_";
        public void Load_Config()
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_CONGTY(), gvDanhSach, prefixColumnName, true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_CONGTY>(x => x.Macongty)
                    , ControlExtension.PropertyNameToLowerCase<DM_CONGTY>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_CONGTY>(x => x.Tgnhap) });
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_CONGTY>(x => x.Tgnhap)].UnboundType = DevExpress.Data.UnboundColumnType.DateTime;

                btnThemDanhMuc.Click += btnThem_Click;
                btnXoaDanhMuc.Click += btnXoa_Click;
                btnLamDanhSach.Click += btnLamMoi_Click;
                gvDanhSach.CellValueChanged += gvDanhSach_CellValueChanged;
            }
            Load_DanhMucCauHinh();
        }

        private void Load_DanhMucCauHinh()
        {
            var data = _systemConfigService.Data_dm_congty(string.Empty);

            CurrentDataSource = null;
            if (data != null)
            {
                CurrentDataSource = data.Copy();
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            }
            gcDanhSach.DataSource = data;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDanhMuc.Text))
            {
                var objNew = new DM_CONGTY();
                objNew.Macongty = txtMaDanhMuc.Text;
                objNew.Tencongty = txtTenDanhMuc.Text;
                objNew.Nguoinhap = UserId;
                _systemConfigService.Insert_dm_congty(objNew);
                Load_DanhMucCauHinh();
                gvDanhSach.FocusedRowHandle = gvDanhSach.RowCount - 1;
                //bubble the event up to the parent
                this.BuutonThemMoiClick?.Invoke(this, e);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã công ty.");
                txtMaDanhMuc.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var madanhmuc = gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_CONGTY>(x => x.Macongty)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa danh mục công ty: {0}?", madanhmuc)))
                {
                    var obj = _systemConfigService.Get_Info_dm_congty(madanhmuc);
                    if (_systemConfigService.Delete_dm_congty(madanhmuc) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = string.Format("Macongty_{0}", madanhmuc),
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa danh mục công ty: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.Dm_congty,
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
            var madanhmuc = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_CONGTY>(x => x.Macongty)).ToString();
            var obj = _systemConfigService.Get_Info_dm_congty(madanhmuc);
            var objSource = obj.Copy();
            DataRow row = gvDanhSach.GetDataRow(e.RowHandle);
            obj.Tgnhap = objSource.Tgnhap;
            obj = (DM_CONGTY)WorkingServices.Get_InfoForObject(obj, row);
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("Congty_{0}", madanhmuc),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.Dm_congty,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_congty(obj);
            //bubble the event up to the parent
            this.LuoiChinhSua?.Invoke(this, new EventArgs());
        }
    }
}
