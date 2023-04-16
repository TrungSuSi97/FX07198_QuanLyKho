using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmNgonNguDanhMuc : FrmTemplate
    {
        public FrmNgonNguDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmNgonNguDanhMuc_Load(object sender, EventArgs e)
        {
            ucNgonNguDanhMuc1.Load_NgonNgu();
            ucNgonNguDanhMuc1.Load_LoaiDanhMuc();
            ucNgonNguDanhMuc1.Load_DanhMucKhaiBaoNgonNgu();
        }
    }
}
