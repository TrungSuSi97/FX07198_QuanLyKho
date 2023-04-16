using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmCheDoCopy_HenTraKQ : Form
    {
        public FrmCheDoCopy_HenTraKQ()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _sysConfig = new SystemConfigService();

        public List<string> lstMaXn = new List<string>();
        public bool NhomCLS = false;
        private void Load_NhomDichVu()
        {
            var loaidichvu = "ClsXetNghiem";
            var data = _sysConfig.Load_Nhom_TheoDVCLS(loaidichvu, string.Empty);
            lueNhomDichVu.Properties.DataSource = data;
            lueNhomDichVu.Properties.ValueMember = "MaNhomDichVu".ToLower();
            lueNhomDichVu.Properties.DisplayMember = "TenNhomDichVu".ToLower();
            lueNhomDichVu.Properties.AutoHeight = true;
            lueNhomDichVu.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        }
        private void Load_DSDichVu()
        {
            var loaidichvu = "ClsXetNghiem";
            var nhomdichvu = lueNhomDichVu.EditValue == null ? string.Empty : lueNhomDichVu.EditValue.ToString();

            var data = _sysConfig.Load_ChiDinhCLS(null, loaidichvu, nhomdichvu, string.Empty, string.Empty, string.Empty, false, true);

            ControlExtension.BindDataToGrid(data, ref dtgDichVu, bvDichVu);
        }
        private void FrmCheDoCopy_HenTraKQ_Load(object sender, EventArgs e)
        {
            Load_NhomDichVu();
            Load_DSDichVu();
            lueNhomDichVu.EditValueChanged += LueNhomDichVu_EditValueChanged;
        }

        private void LueNhomDichVu_EditValueChanged(object sender, EventArgs e)
        {
            Load_DSDichVu();
        }

        private void Check_UnceckAll(bool isCheck)
        {
            ControlExtension.Check_Uncheck_Datagrid(dtgDichVu,colChon , isCheck);
        }

        private void radCopyCacXetNghiemDuocChon_CheckedChanged(object sender, EventArgs e)
        {
            dtgDichVu.Enabled = lueNhomDichVu.Enabled = radCopyCacXetNghiemDuocChon.Checked;
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if(radCopyXetNghiemCungNhom.Checked)
            {
                NhomCLS = true;
                this.Close();
            }
            else if (radCopyCacXetNghiemDuocChon.Checked)
            {
                lstMaXn = new List<string>();
                for (int i = 0; i < dtgDichVu.RowCount ; i++)
                {
                    if (dtgDichVu[colChon.Name, i].Value != null)
                    {
                        var checkedCol = (bool)dtgDichVu[colChon.Name, i].Value;
                        if (checkedCol)
                        {
                            lstMaXn.Add(dtgDichVu[colDichVu_MaDichVu.Name, i].Value.ToString());
                        }
                    }
                }
                if (lstMaXn.Count > 0)
                    this.Close();
                else
                    MessageBox.Show("Hãy chọn chế độ và giá trị tương ứng!");
            }
            else
                MessageBox.Show("Hãy chọn chế độ và giá trị tương ứng!");
        }

        private void btnHuyLenh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            Check_UnceckAll(true);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            Check_UnceckAll(false);
        }
    }
}
