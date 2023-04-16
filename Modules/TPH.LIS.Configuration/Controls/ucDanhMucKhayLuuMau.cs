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
    public partial class ucDanhMucKhayLuuMau : UserControl
    {
        public ucDanhMucKhayLuuMau()
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
        private string prefixColumnName = "coldmkhayluumau_";

        public void Load_Config(DataTable dataDMXN)
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_KHAYLUUMAU(), gvDanhSach, prefixColumnName, true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Matuluu)
                    , ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Gionhap) });
                isCreatedGrid = true;
            }
            Load_TuLuuMau(dataDMXN);
            Load_DMKhayLuuMau();
        }
        public void Load_TuLuuMau(DataTable data)
        {
            ucSearchLookupEditor_DanhSachTuLuuMau1.Load_CauHinh();
        }
        private void Load_DMKhayLuuMau()
        {
            var  data = WorkingServices.ConvertColumnNameToLower_Upper(_systemConfigService.Data_dm_khayluumau(string.Empty, string.Empty), true);
            CurrentDataSource = data;
            gcDanhSach.DataSource = data;
            gvDanhSach.ExpandAllGroups();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue != null)
            {
                if (!string.IsNullOrEmpty(txtMaDanhMuc.Text))
                {
                    var objNew = new DM_KHAYLUUMAU();
                objNew.Matuluu = ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString();
                objNew.Makhayluumau = txtMaDanhMuc.Text;
                objNew.Tenkhailuumau = txtTenDanhMuc.Text;
                objNew.Kichthuocdoc = (int)numDoc.Value;
                objNew.Kichthuocngang = (int)numNgang.Value;
                objNew.Nguoinhap = UserId;
                if (_systemConfigService.Insert_dm_khayluumau(objNew) > 0)
                {
                    Load_DMKhayLuuMau();
                    gvDanhSach.FocusedRowHandle = gvDanhSach.RowCount - 1;
                    txtMaDanhMuc.Text = String.Empty;
                    txtTenDanhMuc.Text = String.Empty;
                    numDoc.Value = 0;
                    numNgang.Value = 0;
                    txtMaDanhMuc.Focus();
                    //bubble the event up to the parent
                    this.BuutonThemMoiClick?.Invoke(this, new EventArgs());
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy nhập mã khay lưu mẫu.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn tủ lưu mẫu.");
        }

        private void gvDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var Makhayluumau = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Makhayluumau)).ToString();
            var maxn = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Matuluu)).ToString();
            var obj = _systemConfigService.Get_Info_dm_khayluumau(Makhayluumau);
            var objSource = obj.Copy();
            DataRow row = gvDanhSach.GetDataRow(e.RowHandle);
            obj = (DM_KHAYLUUMAU)WorkingServices.Get_InfoForObject(obj, row);
            obj.Gionhap = objSource.Gionhap;
            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
            {
                Idhanhdong = (int)Log.LogActionId.Update,
                Madanhmuc = string.Format("Makhayluumau_{0}_MaXN_{1}", Makhayluumau, maxn),
                Nguoithuchien = UserId,
                Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                Idnhatky = Log.LogTableIds.DM_KHAYLUUMAU,
                Pcthuchien = Environment.MachineName
            });
            _systemConfigService.Update_dm_khayluumau(obj);
            //bubble the event up to the parent
            this.LuoiChinhSua?.Invoke(this, new EventArgs());
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.FocusedRowHandle > -1)
            {
                var Makhayluumau = gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Makhayluumau)).ToString();
                var maxn = gvDanhSach.GetFocusedRowCellValue(ControlExtension.PropertyNameToLowerCase<DM_KHAYLUUMAU>(x => x.Matuluu)).ToString();
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xóa khay lưu mẫu: {0}?", maxn)))
                {
                    var obj = _systemConfigService.Get_Info_dm_khayluumau(Makhayluumau);
                    if (_systemConfigService.Delete_dm_khayluumau(Makhayluumau) > 0)
                    {
                        _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                        {
                            Idhanhdong = (int)Log.LogActionId.Delete,
                            Madanhmuc = string.Format("Makhayluumau_{0}_MaXN_{1}", Makhayluumau, maxn),
                            Nguoithuchien = UserId,
                            Noidung = string.Format("Xóa khay lưu mẫu: {0}", WorkingServices.GetDelete_Containt(obj)),
                            Idnhatky = Log.LogTableIds.DM_KHAYLUUMAU,
                            Pcthuchien = Environment.MachineName
                        });
                        Load_DMKhayLuuMau();
                        this.BuutonXoaClick?.Invoke(this, new EventArgs());
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DMKhayLuuMau();
        }

        private void txtMaDanhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTenDanhMuc);
        }

        private void txtTenDanhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numNgang);
        }

        private void numNgang_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numDoc);
        }
    }
}
