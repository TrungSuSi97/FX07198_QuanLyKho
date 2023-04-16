using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Configuration;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Constants;

namespace TPH.LIS.App.AppCode
{
    public partial class ucNgonNguDanhMuc : UserControl
    {
        public ucNgonNguDanhMuc()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _iConfig = new SystemConfigService();
        public void Load_LoaiDanhMuc()
        {
            var lstLoaiDanhMuc = TPH.LIS.Configuration.Constants.LoaiDanhMucNgonNgu.ListLoaiDanhMucNgonNgu();
            cboLoaiDanHmuc.DataSource = lstLoaiDanhMuc;
            cboLoaiDanHmuc.ValueMember = "IDLoaiDnhMuc";
            cboLoaiDanHmuc.DisplayMember = "TenLoaiDanhMuc";
            cboLoaiDanHmuc.SelectedIndex = -1;
            cboLoaiDanHmuc.SelectedIndexChanged += CboLoaiDanHmuc_SelectedIndexChanged;
        }

        private void CboLoaiDanHmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhMucKhaiBaoNgonNgu();
            Load_DanhSach_NgonNguDanhMuc();
        }

        public void Load_NgonNgu()
        {
            gvNgonNgu.FocusedColumnChanged -= GvNgonNgu_FocusedColumnChanged;
            gvNgonNgu.FocusedRowChanged -= GvNgonNgu_FocusedRowChanged;
            var data = _iConfig.Data_dm_ngonngu(string.Empty);
            gcNgonNgu.DataSource = data;
            gvNgonNgu.FocusedColumnChanged += GvNgonNgu_FocusedColumnChanged;
            gvNgonNgu.FocusedRowChanged += GvNgonNgu_FocusedRowChanged;
            Load_DanhSach_NgonNguDanhMuc(); 
        }

        private void GvNgonNgu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSach_NgonNguDanhMuc();
        }

        private void GvNgonNgu_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DanhSach_NgonNguDanhMuc();
        }

        private void Them_NgonNgu()
        {
            if (!string.IsNullOrEmpty(txtIDNgonNguMoi.Text))
            {
                var obj = new DM_NGONNGU();
                obj.Idngonngu = txtIDNgonNguMoi.Text;
                _iConfig.Insert_dm_ngonngu(obj);
                Load_NgonNgu();
                txtIDNgonNguMoi.Focus();
                txtIDNgonNguMoi.SelectAll();
            }
        }
        private void Xoa_NgonNgu()
        {
            if(gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu) != null)
            {
                var idNgonNgu = gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu).ToString();
                if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa ngôn ngữ đang chọn?"))
                {
                    _iConfig.Delete_dm_ngonngu(new DM_NGONNGU { Idngonngu = idNgonNgu });
                    Load_NgonNgu();
                }
            }
        }
        public void Load_DanhMucKhaiBaoNgonNgu()
        {
            if (cboLoaiDanHmuc.SelectedIndex > -1)
            {
                var loaiDanhMuc = (EnumLoaiDanhMucNgonNgu)cboLoaiDanHmuc.SelectedValue;
                var data = _iConfig.Data_DSDanhMuc_KhaiBaoNgonNgu((int)loaiDanhMuc);
                gcDanhMuc.DataSource = data;
            }
            else
                gcDanhMuc.DataSource = null;
        }

        private void btnThemNgonNgu_Click(object sender, EventArgs e)
        {
            Them_NgonNgu();
        }

        private void btnXoaNgonNgu_Click(object sender, EventArgs e)
        {
            Xoa_NgonNgu();
        }

        private void gvNgonNgu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu) != null)
            {
                var idNgonNgu = gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu).ToString();
                var moTa = gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_MoTa).ToString();
                var obj = new DM_NGONNGU { Idngonngu = idNgonNgu, Mota = moTa };
                _iConfig.Update_dm_ngonngu(obj);
            }
        }
        private void Load_DanhSach_NgonNguDanhMuc()
        {
            if (gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu) != null)
            {
                var idNgonNgu = gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu).ToString();
                var loaiDanhMuc = (cboLoaiDanHmuc.SelectedIndex == -1 ? string.Empty : cboLoaiDanHmuc.SelectedValue.ToString());
                var data = _iConfig.Data_dm_ngonngu_danhmuc(loaiDanhMuc, string.Empty, idNgonNgu);
                gcDanhMucNgonNgu.DataSource = data;
                gvDanhMucNgonNgu.ExpandAllGroups();
            }
            else
                gcDanhMucNgonNgu.DataSource = null;
        }
        private void Add_DanhMuc_NgonNgu()
        {
            if (gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu) != null)
            {
                var idNgonNgu = gvNgonNgu.GetFocusedRowCellValue(colNgonNgu_IdNgonNgu).ToString();
                var loaiDanhMuc = (cboLoaiDanHmuc.SelectedIndex == -1 ? string.Empty : cboLoaiDanHmuc.SelectedValue.ToString());
                var data = _iConfig.Data_dm_ngonngu_danhmuc(loaiDanhMuc, string.Empty, idNgonNgu);
                if (gvDanhMuc.SelectedRowsCount > 0)
                {
                    foreach (var item in gvDanhMuc.GetSelectedRows())
                    {
                        if (gvDanhMuc.GetRowCellValue(item, colDanhMuc_MaDanhMuc) != null)
                        {
                            var obj = new DM_NGONNGU_DANHMUC { Iddanhmuc = loaiDanhMuc, Idngonngu = idNgonNgu, Madanhmuc = gvDanhMuc.GetRowCellValue(item, colDanhMuc_MaDanhMuc).ToString() };
                            _iConfig.Insert_dm_ngonngu_danhmuc(obj);
                        }
                    }
                    Load_DanhSach_NgonNguDanhMuc();
                }
            }
        }
        private void  Xoa_DanhMuc_NgonNgu()
        {
            if(gvDanhMucNgonNgu.SelectedRowsCount >0)
            {
                if(CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa danh mục được chọn?"))
                foreach (var item in gvDanhMucNgonNgu.GetSelectedRows())
                {
                    if (gvDanhMucNgonNgu.GetRowCellValue(item, colDanhMucNgonNgu_IdNgonNgu) != null)
                    {
                        var idNgonNgu = gvDanhMucNgonNgu.GetRowCellValue(item, colDanhMucNgonNgu_IdNgonNgu).ToString();
                        var idDanhmuc = gvDanhMucNgonNgu.GetRowCellValue(item, colDanhMucNgonNgu_IDDanhMuc).ToString();
                        var maDanhMuc = gvDanhMucNgonNgu.GetRowCellValue(item, colDanhMucNgonNgu_MaDanhMuc).ToString();
                        _iConfig.Delete_dm_ngonngu_danhmuc(new DM_NGONNGU_DANHMUC
                        {
                            Idngonngu = idNgonNgu,
                            Iddanhmuc = idDanhmuc,
                            Madanhmuc = maDanhMuc
                        });
                    }
                }
                Load_DanhSach_NgonNguDanhMuc();
            }
        }
        private void btnDanhSachNgonNgu_DanhMuc_Click(object sender, EventArgs e)
        {
            Load_DanhSach_NgonNguDanhMuc();
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            Xoa_DanhMuc_NgonNgu();
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            Add_DanhMuc_NgonNgu();
        }

        private void gvDanhMucNgonNgu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column == colDanhMucNgonNgu_NoiDung)
            {
                var idNgonNgu = gvDanhMucNgonNgu.GetRowCellValue(e.RowHandle, colDanhMucNgonNgu_IdNgonNgu).ToString();
                var idDanhmuc = gvDanhMucNgonNgu.GetRowCellValue(e.RowHandle, colDanhMucNgonNgu_IDDanhMuc).ToString();
                var maDanhMuc = gvDanhMucNgonNgu.GetRowCellValue(e.RowHandle, colDanhMucNgonNgu_MaDanhMuc).ToString();
                _iConfig.Update_dm_ngonngu_danhmuc(new DM_NGONNGU_DANHMUC
                {
                    Idngonngu = idNgonNgu,
                    Iddanhmuc = idDanhmuc,
                    Madanhmuc = maDanhMuc,
                    Noidung = gvDanhMucNgonNgu.GetRowCellValue(e.RowHandle, colDanhMucNgonNgu_NoiDung).ToString()
                });
            }
        }

        private void btnLoadDSngonNgu_Click(object sender, EventArgs e)
        {
            Load_NgonNgu();
        }
    }
}
