﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmNgonNguPhanMem : FrmTemplate
    {
        public FrmNgonNguPhanMem()
        {
            InitializeComponent();
        }

        private void FrmNgonNguPhanMem_Load(object sender, EventArgs e)
        {
            ucCauHinhNgonNguUngDung1.Load_DanhSachTuNgu();
        }
    }
}
