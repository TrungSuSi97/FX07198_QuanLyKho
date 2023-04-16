using System;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmViSinh_ChonMauNhapNhanh : FrmTemplate
    {
        public string NoiDung = string.Empty;
        public FrmViSinh_ChonMauNhapNhanh()
        {
            InitializeComponent();
        }
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
        private void FrmViSinh_ChonMauNhapNhanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (dtgDS.CurrentRow != null)
                {
                    NoiDung = txtChiTiet.Text;
                    this.Close();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn mẫu nhập nhanh.");
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                this.Close();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dtgDS.CurrentRow != null)
            {
                NoiDung = txtChiTiet.Text;
                this.Close();
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn mẫu nhập nhanh.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Load_DS()
        {
            var data = _bacteriumAntibioticService.Data_dm_visinh_maunhapnhanh(string.Empty);
            ControlExtension.BindDataToGrid(data, ref dtgDS, ref bvDS);
        }

        private void FrmViSinh_ChonMauNhapNhanh_Load(object sender, EventArgs e)
        {
            Load_DS();
        }

        private void txtTimGotat_KeyUp(object sender, KeyEventArgs e)
        {
            txtTimNoiDung.Text = string.Empty;
            bvDS.BindingSource.Filter = string.Format("GoTat like '%{0}%'", txtTimGotat.Text);
        }

        private void txtTimNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            txtTimGotat.Text = string.Empty;
            bvDS.BindingSource.Filter = string.Format("NoiDung like '%{0}%'", txtTimNoiDung.Text);
        }

        private void dtgDS_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtChiTiet.Text = dtgDS.CurrentRow.Cells[colNoiDung.Name].Value.ToString();
        }

        private void FrmViSinh_ChonMauNhapNhanh_Shown(object sender, EventArgs e)
        {
            txtTimGotat.Focus();
        }

        private void txtTimGotat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(dtgDS.RowCount == 1)
                {
                    btnChon.PerformClick();
                }
            }
        }
    }
}
