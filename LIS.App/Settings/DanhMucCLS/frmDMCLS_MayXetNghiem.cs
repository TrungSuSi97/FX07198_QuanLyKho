using System;
using System.Data;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.CauHinh.DanhMucCLS
{
    public partial class frmDMCLS_MayXetNghiem : FrmTemplate
    {
        public frmDMCLS_MayXetNghiem()
        {
            InitializeComponent();
        }

        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();

        private void frmDMCLS_MayXetNghiem_Load(object sender, EventArgs e)
        {
            Load_LoaiKetNoi();
            Load_DM_MayXetNghiem();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            Add_New();
        }

        private void Load_DM_MayXetNghiem()
        {
            var testingMachines = _systemConfigService.GetTestingMachines();

            ControlExtension.BindDataToGrid(testingMachines, ref dtgMayXetNghiem, ref bvMayXetNghiem, false);
        }

        private void Add_New()
        {
            if (string.IsNullOrEmpty(txtIDMay.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã máy.");
            }
            else if (cboLoaiKetNoi.SelectedIndex == -1)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn loại kết nối.");
            }
            else
            {
                var testingMachineInfo = new TestingMachineModel()
                {
                    Id = NumberConverter.ToInt(txtIDMay.Text),
                    Name = txtTenMay.Text,
                    Protocol = txtProtocol.Text,
                    ConnectionType = cboLoaiKetNoi.SelectedValue.ToString(),
                    IsAuto = chkTuValid.Checked
                };

                if (_systemConfigService.AddNewTestingMachine(testingMachineInfo).Id == -1)
                {
                    txtIDMay.Focus();
                    txtIDMay.SelectAll();
                }
                else
                    Load_DM_MayXetNghiem();
            }
        }

        private void Update(int rowIndex)
        {
            if (dtgMayXetNghiem.RowCount > 0)
            {
                var testingMachineInfo = new TestingMachineModel()
                {
                    Id = NumberConverter.ToInt(dtgMayXetNghiem[IDMay.Name, rowIndex].Value.ToString()),
                    Name = dtgMayXetNghiem[TenMay.Name, rowIndex].Value.ToString(),
                    Protocol = dtgMayXetNghiem[Protocol.Name, rowIndex].Value.ToString(),
                    ConnectionType = dtgMayXetNghiem[LoaiKetNoi.Name, rowIndex].Value.ToString(),
                    IsAuto = (bool)dtgMayXetNghiem[Tudongvalid.Name, rowIndex].Value
                };
                _systemConfigService.UpdateTestingMachine(testingMachineInfo);
            }
        }

        private void Load_LoaiKetNoi()
        {
            DataTable dtLoaiKetNoi = Data_Loai_KetNoi();
            LoaiKetNoi.DataSource = dtLoaiKetNoi.Copy();
            LoaiKetNoi.DisplayMember = "TenLoaiKetNoi";
            LoaiKetNoi.ValueMember = "MaLoaiKetNoi";
            ControlExtension.BindDataToCobobox(dtLoaiKetNoi, ref cboLoaiKetNoi, "MaLoaiKetNoi", "TenLoaiKetNoi",
                "MaloaiKetNoi, tenLoaiKetNoi", "50, 150", null, -1);
        }

        private DataTable Data_Loai_KetNoi()
        {
            var dt = new DataTable();
            dt.Columns.Add("MaLoaiKetNoi", typeof(string));
            dt.Columns.Add("TenLoaiKetNoi", typeof(string));

            var dr = dt.NewRow();
            dr["MaLoaiKetNoi"] = "COM";
            dr["TenLoaiKetNoi"] = "COM Port";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["MaLoaiKetNoi"] = "LAN";
            dr["TenLoaiKetNoi"] = "LAN (IP)";
            dt.Rows.Add(dr);

            return dt;
        }

        private void btnXoaMay_Click(object sender, EventArgs e)
        {
            if (dtgMayXetNghiem.RowCount <= 0) return;
            var testingMachineInfo = new TestingMachineModel()
            {
                Id =
                    NumberConverter.ToInt(
                        dtgMayXetNghiem[IDMay.Name, bvMayXetNghiem.BindingSource.Position].Value.ToString()),
                Name = dtgMayXetNghiem[TenMay.Name, bvMayXetNghiem.BindingSource.Position].Value.ToString()
            };

            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa máy xét nghiệm: " + testingMachineInfo.Name + " ?"))
            {
                _systemConfigService.DeleteTestingMachine(testingMachineInfo);
                Load_DM_MayXetNghiem();
            }
        }

        private void dtgMayXetNghiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Update(e.RowIndex);
        }

        private void txtIDMay_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            LabServices_Helper.LeaveFocusNext(e, txtTenMay);
        }

        private void txtTenMay_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, txtProtocol);
        }

        private void txtProtocol_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, cboLoaiKetNoi);
        }

        private void cboLoaiKetNoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            LabServices_Helper.LeaveFocusNext(e, btnThemMoi);
        }
    }
}