using System;
using System.Drawing;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmTinhTrangLyDo : FrmTemplate
    {
        public FrmTinhTrangLyDo()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private void SetEnable(bool isEnable)
        {
            txtMaTinhTrang.ReadOnly = !isEnable;
            txtNoiDung.ReadOnly = !isEnable;

        }
        private void AddNew()
        {
            SetEnable(true);
            txtNoiDung.Tag = null;
            txtMaTinhTrang.Text = "";
            txtNoiDung.Text = "";
            txtMaTinhTrang.BackColor = Color.Yellow;
            txtMaTinhTrang.Focus();
        }
        private void Edit()
        {
            SetEnable(true);
            txtMaTinhTrang.BackColor = Color.LightGreen;
            txtMaTinhTrang.Focus();
        }
        private void Save()
        {
            var obj = new DM_TINHTRANGMAU();
            if(txtMaTinhTrang.BackColor == Color.Yellow)
            {
                obj.Matinhtrang = txtMaTinhTrang.Text;
                obj.Tinhtrangmau = txtNoiDung.Text;
                obj.Loaixetnghiem = 0;
                var ok =_isSysConfig.Insert_dm_tinhtrangmau(obj);
                if (!string.IsNullOrEmpty(ok.Name))
                    CustomMessageBox.MSG_Information_OK(ok.Name);
                else
                    Load_DanhSach();
            }
            else if (txtMaTinhTrang.BackColor == Color.LightGreen)
            {
                obj = _isSysConfig.Get_Info_dm_tinhtrangmau(txtMaTinhTrang.Tag.ToString());
                obj.Matinhtrang = txtMaTinhTrang.Text;
                obj.Tinhtrangmau = txtNoiDung.Text;
                if (_isSysConfig.Update_dm_tinhtrangmau(obj))
                    Load_DanhSach();                
            }
        
        }
        private void Delete()
        {
            if(gvMayXN.SelectedRowsCount >0)
            {
                foreach (var item in gvMayXN.GetSelectedRows())
                {
                    var id = gvMayXN.GetRowCellValue(item, colTinhTrang_ID);
                    if(id != null)
                    {
                        _isSysConfig.Delete_dm_tinhtrangmau(new DM_TINHTRANGMAU { Id = int.Parse(id.ToString()) });
                    }
                }
                Load_DanhSach();
            }
        }
        private void Load_DanhSach()
        {
            var data = _isSysConfig.Data_DanhMucTinhTrangMau(0);
            gcMayXN.DataSource = data;
        }
        private void SetInfo(int rowIndex)
        {
            txtMaTinhTrang.BackColor = Color.Empty;
            SetEnable(false);
            if (gvMayXN.GetRowCellValue(rowIndex, colTinhTrang_MaTinhTrang) != null)
            {
                txtMaTinhTrang.Tag = gvMayXN.GetRowCellValue(rowIndex, colTinhTrang_ID).ToString();
                txtNoiDung.Text = gvMayXN.GetRowCellValue(rowIndex, colTinhTrang_TinhTrangMau).ToString();
                txtMaTinhTrang.Text = gvMayXN.GetRowCellValue(rowIndex, colTinhTrang_MaTinhTrang).ToString();
            }
        }

        private void gvMayXN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetInfo(e.FocusedRowHandle);
        }

        private void btnchinhSua_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void FrnTinhTrangLyDo_Load(object sender, EventArgs e)
        {
            Load_DanhSach();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_DanhSach();
        }
    }
}
