﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class FrmDoiTrangThaiKetQua : Form
    {
        public FrmDoiTrangThaiKetQua()
        {
            InitializeComponent();
        }
        public string StatusSelected { get; set; }
        private void Load_DanhSachTrangThai()
        {
            cboStatusList.DataSource = TestingResultStatusConstant.TestingResultStatusConstantList
                  .Where(x => x.Value.Equals(TestingResultStatusConstant.ChapNhan)
            || x.Value.Equals(TestingResultStatusConstant.XemLai)).ToList();
            cboStatusList.ValueMember = "Value";
            cboStatusList.DisplayMember = "Key";
            cboStatusList.SelectedIndex = -1;
        }
        private void FrmDoiTrangThaiKetQua_Load(object sender, EventArgs e)
        {
            Load_DanhSachTrangThai();
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cboStatusList.SelectedIndex > -1)
            {
                StatusSelected = cboStatusList.SelectedValue.ToString();
                this.Close();
            }
            else
                Common.Controls.CustomMessageBox.MSG_Information_OK("Hãy chọn trạng thái muốn thay đổi!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StatusSelected = string.Empty;
            this.Close();
        }
    }
}
