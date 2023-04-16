using System;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmAddLISTest : Form
    {
        public frmAddLISTest()
        {
            InitializeComponent();
        }

        
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveNewTest()
        {
            if (string.IsNullOrWhiteSpace(txtTestCode.Text))
            {
                MessageBox.Show(ErrorMessageConstant.ErrorPleaseInputTestCode, Warnings.CAPTION, MessageBoxButtons.OK);
                txtTestCode.Focus();
            }
            else if (cboMaNhomCLS.SelectedIndex == -1)
            {
                MessageBox.Show(ErrorMessageConstant.ErrorPleaseChooseGroup, Warnings.CAPTION, MessageBoxButtons.OK);
                cboMaNhomCLS.Focus();
                cboMaNhomCLS.DroppedDown = true;
            }
            else
            {
                var sampleType = cboSampleType.SelectedIndex == -1
                    ? "NULL"
                    : "'" + cboSampleType.SelectedValue.ToString().Trim() + "'";

                _systemConfigService.AddNewTestType(txtTestCode.Text, txtTestName.Text,
                    cboMaNhomCLS.SelectedValue.ToString(),
                    txtUnit.Text, txtNormalRange.Text, txtLowerLimit.Text, txtUpperLimit.Text, txtPrice.Text,
                    chkBoldResult.Checked, chkBoldResult.Checked, chkTestHead.Checked, txtCriteria.Text, sampleType,
                    lblTTin.Text);

                txtTestCode.Focus();
                txtTestCode.SelectAll();
            }
        }
        private void Clear()
        {
            txtTestCode.Text = string.Empty;
            txtTestName.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtUpperLimit.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtNormalRange.Text = string.Empty;
            txtLowerLimit.Text = string.Empty;
            cboMaNhomCLS.SelectedIndex = -1;

            txtTestCode.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void LoadMaNhomCls()
        {
            var testGroups = _systemConfigService.GetTestGroup(string.Empty);

            ControlExtension.BindDataToCobobox(testGroups, ref cboMaNhomCLS, "MaNhomCLS", "TenNhomCLS");
        }

        private void frmAddLISTest_Load(object sender, EventArgs e)
        {
            LoadMaNhomCls();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SaveNewTest();
        }

        private void cboMaNhomCLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhomCLS.SelectedIndex != -1)
            {
                lblTTin.DataBindings.Clear();
                lblTTin.DataBindings.Add("Text", cboMaNhomCLS.DataSource, "ThuTuIn");
            }
            else
            {
                lblTTin.DataBindings.Clear();
                lblTTin.Text = string.Empty;
            }
        }

        private void txtTestCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtTestName);
        }

        private void txtTestName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboMaNhomCLS);
        }

        private void cboMaNhomCLS_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtNormalRange);
        }

        private void txtNormalRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtUnit);
        }

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtLowerLimit);
        }

        private void txtUpperLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            ControlExtension.LeaveFocusNext(e, txtCriteria);
        }

        private void txtLowerLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            ControlExtension.LeaveFocusNext(e, txtUpperLimit);
        }

        private void txtCriteria_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtPrice);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            ControlExtension.LeaveFocusNext(e, btnAddNew);
        }
    }
}