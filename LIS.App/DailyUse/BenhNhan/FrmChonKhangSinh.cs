using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonKhangSinh : FrmTemplate
    {
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
        public List<string> lstDSKhangSinh = new List<string>();
        public string kyThuat = string.Empty;
        public FrmChonKhangSinh()
        {
            InitializeComponent();
        }
        private void Load_DanhSachKhangSinh()
        {
            DataTable dt = _bacteriumAntibioticService.Data_dm_xetnghiem_khangsinh(string.Empty, string.Empty);
            gcKhangSinh.DataSource = dt;
            gvKhangSinh.ExpandAllGroups();
        }
        private void btnChonKhangSinh_Click(object sender, EventArgs e)
        {
            if (cboKyThuat.SelectedIndex > -1)
            {
                kyThuat = cboKyThuat.SelectedValue.ToString();
                if (gvKhangSinh.SelectedRowsCount > 0)
                {
                    foreach (var item in gvKhangSinh.GetSelectedRows())
                    {
                        if (gvKhangSinh.GetRowCellValue(item, colKhangSinh_MaKhangSinh) != null)
                            lstDSKhangSinh.Add(gvKhangSinh.GetRowCellValue(item, colKhangSinh_MaKhangSinh).ToString());
                    }
                    this.Close();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn kháng sinh.");
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn kỹ thuật.");
            }
        }
        private void FrmChonKhangSinh_Load(object sender, EventArgs e)
        {
            Load_DanhSachKhangSinh();
            Load_kyThuat();
        }
        private void Load_kyThuat()
        {
            cboKyThuat.DataSource = Enum.GetValues(typeof(BioTestMethod))
              .Cast<Enum>()
              .Select(value => new
              {
                  (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                  val = value.ToString(),
                  valint = value
              })
              .OrderBy(item => item.valint)
              .ToList();
            cboKyThuat.DisplayMember = "Description";
            cboKyThuat.ValueMember = "val";
            cboKyThuat.SelectedIndex = -1;
        }
    }
}
