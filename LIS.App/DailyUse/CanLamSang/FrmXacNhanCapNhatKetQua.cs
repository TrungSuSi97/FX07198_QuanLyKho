using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Controls;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmXacNhanCapNhatKetQua : FrmTemplate
    {
        public FrmXacNhanCapNhatKetQua()
        {
            InitializeComponent();
        }
        public string KetQuaCu
        {
            get { return lblKetQuaCu.Text; }
            set { lblKetQuaCu.Text = value; }
        }
        public string KetQuaMoi
        {
            get { return lblKetQuaMoi.Text; }
            set { lblKetQuaMoi.Text = value; }
        }
        private void btnDongYThayDoi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnHuyThayDoi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void FrmXacNhanCapNhatKetQua_Load(object sender, EventArgs e)
        {

        }

        private void FrmXacNhanCapNhatKetQua_Shown(object sender, EventArgs e)
        {
            this.Height -= 25;
            btnDongYThayDoi.Focus();
        }
    }
}
