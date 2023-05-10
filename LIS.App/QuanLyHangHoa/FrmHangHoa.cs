using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
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
        }

        private void Load_DMHH()
        {
            ucSearchLookupEditor_DanhMucHangHoa1.Load_DanhMucHH();
            ucSearchLookupEditor_DanhMucHangHoa1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhMucHangHoa1.CatchTabKey = true;
        }
        private void Load_DMDV()
        {
            ucSearchLookupEditor_DanhMucDonVi1.Load_DanhMucDV();
            ucSearchLookupEditor_DanhMucDonVi1.CatchEnterKey = true;
            ucSearchLookupEditor_DanhMucDonVi1.CatchTabKey = true;
        }

        private void gvdmhanghoa_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                var madm = StringConverter.ToString(gvdmhanghoa.GetRowCellValue(e.RowHandle, colMaDM));
                var tendm = StringConverter.ToString(gvdmhanghoa.GetRowCellValue(e.RowHandle, colTenDM));
                _iProduct.SuaDM(madm,tendm);
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
    }
}
