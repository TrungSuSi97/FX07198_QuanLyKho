using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.Product.Model;
using TPH.Product.Repositories;
using TPH.Product.Services;

namespace TPH.LIS.App.QuanLyHangHoa
{
    public partial class FrmHangHoa : FrmTemplateCommon 
    {
        public FrmHangHoa()
        {
            InitializeComponent();
        }
        private readonly IProductService _iProduct = new ProductService();

        private void btnThemHH_Click(object sender, EventArgs e)
        {
            _iProduct.ThemDM(txtMaDM.Text, txtTenDM.Text);
            LoadLuoiDMHH();
        }

        private void btnXoaHH_Click(object sender, EventArgs e)
        {
            if (gvdmhanghoa.FocusedRowHandle > -1)
            {
                var maNv = gvdmhanghoa.GetFocusedRowCellValue(colMaDM).ToString();
                if (!string.IsNullOrEmpty(maNv))
                {
                    _iProduct.XoaDM(maNv);
                    LoadLuoiDMHH();
                }
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            _iProduct.ThemDonVi(txtMaDV.Text, txtTenDV.Text);
            LoadLuoiDMDV();
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (gvdmdonvi.FocusedRowHandle > -1)
            {
                var maNv = gvdmdonvi.GetFocusedRowCellValue(colMaDV).ToString();
                if (!string.IsNullOrEmpty(maNv))
                {
                    _iProduct.XoaDonVi(maNv);
                    LoadLuoiDMDV();
                }
            }
        }
        private void LoadLuoiDMHH()
        {
            gcdmhanghoa.DataSource = null;
            gcdmhanghoa.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDMHH(string.Empty), true);
        }
        private void LoadLuoiDMDV()
        {
            gcdmdonvi.DataSource = null;
            gcdmdonvi.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDMDV(string.Empty), true);
        }

        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            LoadLuoiDMHH();
            LoadLuoiDMDV();
            Load_DMHH();
            Load_DMDV();
            LoadLuoiHH();
        }

        private void Load_DMHH()
        {
            ucSearchLookupEditor_DanhMucHangHoa1.Load_DanhMucHH();
            ucSearchLookupEditor_DanhMucHangHoa1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhMucHangHoa1.CatchTabKey = true;
            repositoryItemGridLookUpEditDanhmuc.DataSource =
                WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDMHH(string.Empty), true);
        }
        private void Load_DMDV()
        {
            ucSearchLookupEditor_DanhMucDonVi1.Load_DanhMucDV();
            ucSearchLookupEditor_DanhMucDonVi1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhMucDonVi1.CatchTabKey = true;
            repositoryItemGridLookUpEditDonVi.DataSource =
              WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetDMDV(string.Empty), true);
        }

        private void gvdmhanghoa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var madm = StringConverter.ToString(gvdmhanghoa.GetRowCellValue(e.RowHandle, colMaDM));
                var tendm = StringConverter.ToString(gvdmhanghoa.GetRowCellValue(e.RowHandle, colTenDM));
                _iProduct.SuaDM(madm, tendm);
            }
        }

        private void gvdmdonvi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var madm = StringConverter.ToString(gvdmdonvi.GetRowCellValue(e.RowHandle, colMaDV));
                var tendm = StringConverter.ToString(gvdmdonvi.GetRowCellValue(e.RowHandle, colTenDV));
                _iProduct.SuaDonVi(madm, tendm);
            }
        }

        private void btnThemItem_Click(object sender, EventArgs e)
        {
            ThemItem();
            LoadLuoiHH();
        }

        private void btnXoaItem_Click(object sender, EventArgs e)
        {
            XoaItem();
            LoadLuoiHH();
        }

        private void btnRefreshItem_Click(object sender, EventArgs e)
        {
            LoadLuoiHH();
        }
        private void LoadLuoiHH()
        {
            gcHH.DataSource = null;
            gcHH.DataSource = WorkingServices.ConvertColumnNameToLower_Upper(_iProduct.GetItems(new ItemModel()), true);
        }
        private void ThemItem()
        {
            if (!WorkingServices.IsNumeric(txtGia.Text.Trim()))
            {
                CustomMessageBox.MSG_Information_OK(LanguageExtension.GetResourceValueFromKey("VuilongnhapgialasoCHAMCAM", LanguageExtension.AppLanguage));
                return;
            }
            var model = new ItemModel();
            model.ItemCode = txtMaHH.Text.Trim();
            model.ItemName = txtTenHH.Text.Trim();
            model.Cost = NumberConverter.ToDecimal(txtGia.Text.Trim());
            model.MaDonVi = StringConverter.ToString(ucSearchLookupEditor_DanhMucDonVi1.SelectedValue);
            model.MaDanhMuc = StringConverter.ToString(ucSearchLookupEditor_DanhMucHangHoa1.SelectedValue);
            _iProduct.ThemItem(model);
        }
        private void XoaItem()
        {
            var model = new ItemModel();
            model.ItemCode = StringConverter.ToString(gvHH.GetFocusedRowCellValue(colItemCode));
            _iProduct.XoaItem(model);

        }

        private void gvHH_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var model = new ItemModel();
                model.ItemCode = gvHH.GetRowCellValue(e.RowHandle, colItemCode).ToString();
                model.ItemName = gvHH.GetRowCellValue(e.RowHandle, colItemName).ToString();
                model.MaDonVi = StringConverter.ToString(gvHH.GetRowCellValue(e.RowHandle, colMaDV));
                model.MaDanhMuc = StringConverter.ToString(gvHH.GetRowCellValue(e.RowHandle, colMaDM));
                model.Cost = NumberConverter.ToDecimal(gvHH.GetRowCellValue(e.RowHandle, colGia));
                _iProduct.SuaItem(model);
            }
        }
    }
}
