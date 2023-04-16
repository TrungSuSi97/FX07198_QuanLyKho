using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Extensions;
using TPH.LIS.User.Constants;
using Transitions;

namespace TPH.LIS.App.ThucThi.CanLamSang.DVKhac
{
    public partial class FrmCLS_DVKhac_KetQua : FrmTemplate
    {
        public FrmCLS_DVKhac_KetQua()
        {
            InitializeComponent();
        }
        C_Patient_DichVu_Khac p_dvKhac = new C_Patient_DichVu_Khac();

        Frm_DVKhac_KQCoHinh fKQCoHinh = new Frm_DVKhac_KQCoHinh();
        Frm_DVKhac_KQKhongHinh fKQKhongHinh = new Frm_DVKhac_KQKhongHinh();
        C_Config config = new C_Config();
        PanelControl pnKQCoHinh = new PanelControl();
        PanelControl pnKQKhongHinh = new PanelControl();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        DataTable dtPatientList = new DataTable();

        int current_PanelShowing = -1;
        bool _loading = false;

        private void Add_SubForm()
        {
            pnKQCoHinh.Name = "pnCoHinh";
            pnKQKhongHinh.Name = "pnKhongHinh";
            fKQCoHinh.TopLevel = false;
            fKQCoHinh.pnLabel.Visible = false;
            fKQCoHinh.ControlBox = false;
            fKQCoHinh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fKQCoHinh.Dock = DockStyle.Fill;
            pnKQCoHinh.Controls.Add(fKQCoHinh);

            fKQCoHinh.Show();

            fKQKhongHinh.TopLevel = false;
            fKQKhongHinh.pnLabel.Visible = false;
            fKQKhongHinh.ControlBox = false;
            fKQKhongHinh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            fKQKhongHinh.Dock = DockStyle.Fill;
            pnKQKhongHinh.Controls.Add(fKQKhongHinh);
            fKQKhongHinh.Show();

            pnResult.Controls.Add(pnKQCoHinh);
            pnResult.Controls.Add(pnKQKhongHinh);

        }
        private int Change_Panel(int _NewID, int _OldID, PanelControl _pnHold)
        {
            PanelControl pnOld = switchwPanel(_OldID);
            PanelControl pnNew = switchwPanel(_NewID);
            Change_PaneShow(pnNew, pnOld, _pnHold);

            return _NewID;
        }
        private void Change_PaneShow(PanelControl _pnShow, PanelControl pnOLD, PanelControl _pnHold)
        {
            Transition t = new Transition(new TransitionType_EaseInEaseOut(700));

            _pnShow.Dock = DockStyle.None;
            _pnShow.Size = new System.Drawing.Size(_pnHold.DisplayRectangle.Width, _pnHold.DisplayRectangle.Height);
            if (pnOLD != _pnShow)
            {
                _pnShow.Left = -pnResult.Width;
                pnOLD.Dock = DockStyle.None;
                _pnShow.Visible = true;
                t.add(_pnShow, "Left", _pnHold.DisplayRectangle.Width / 2 - _pnShow.Width / 2);//
                t.add(pnOLD, "Left", -pnOLD.Width);
                t.run();
            }
        }
        private PanelControl switchwPanel(int _ID)
        {
            if (_ID == 0)
                return pnKQKhongHinh;
            else
                return pnKQCoHinh;
        }
        private void FrmCLS_DVKhac_KetQua_Load(object sender, EventArgs e)
        {
            Load_PatientList(false);
        }
        private void Load_PatientList(bool _Print)
        {
            _loading = true;
            if (_Print && !radPrinted.Checked)
                txtSEQ.Text = "";
            Load_ThongTin(txtSEQ.Text);
            if (dtgPatient.RowCount == 0)
            {
                txtSEQ.Text = "";
            }
            Load_DS_ChiDinh("");
            _loading = false;


        }
        private void Load_ThongTin(string _SoTT)
        {
            dtPatientList = new DataTable();
            int _PrintType = 0;
            if (radNotPrint.Checked)
                _PrintType = 2;
            else if (radPrinted.Checked)
                _PrintType = 1;
            dtPatientList = p_dvKhac.Get_Patient_DVKhac("", dtpDateIn.Value.ToString("yyyy-MM-dd"), _PrintType);
            ControlExtension.BindDataToGrid(dtPatientList, ref dtgPatient, ref bvPatient);
            BindPatient(bvPatient.BindingSource);
            if (_SoTT != "")
            {
                txtSEQ.Text = _SoTT;
                SelectRow();
            }
        }
        private void SelectRow()
        {
            if (txtSEQ.Text.Length >= 4)
            {
                LabServices_Helper.Select_Row(dtgPatient, bvPatient, "SEQ", txtSEQ.Text);
            }
        }

        private void ClearControl()
        {
            txtSID.DataBindings.Clear();
            txtSID.Text = "";
            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = "";
            txtAddress.DataBindings.Clear();
            txtAddress.Text = "";
            txtAge.DataBindings.Clear();
            txtAge.Text = "";
            txtSex.DataBindings.Clear();
            txtSex.Text = "";
            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;
            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;
            lblSex.Text = "";
            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = "";
        }
        private void BindPatient(BindingSource bs)
        {
            ClearControl();
            txtSID.DataBindings.Clear();
            txtSID.DataBindings.Add("Text", bs, "MaTiepNhan");
            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            txtSex.DataBindings.Add("Text", bs, "GioiTinh");
            txtChanDoan.DataBindings.Add("Text", bs, "ChanDoan");
            dtpBirthday.DataBindings.Add("Value", bs, "SinhNhat", true, DataSourceUpdateMode.OnValidation, DateTime.Now);
        }

        private void Load_DS_ChiDinh(string _CurrentValue)
        {
            ControlExtension.BindDataToGrid(p_dvKhac.Load_DanhSach_ChiDinhDVKhac(txtSID.Text), ref dtgDSDichVu, ref bvDSDichVu);
            if (_CurrentValue != "")
            {
                LabServices_Helper.Select_Row(dtgDSDichVu, bvDSDichVu, "MaDVKhac", _CurrentValue);
            }
        }

        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPatient.RowCount > 0)
            {
                Load_DS_ChiDinh("");
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Load_PatientList(false);
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            if (_loading == false)
                Load_PatientList(false);
        }

        private void dtgDSDichVu_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Check_Show_WorkForm();

        }
        private void Check_Show_WorkForm()
        {
            if (dtgDSDichVu.RowCount > 0)
            {
                if (_loading == false)
                {
                    int _NewPanelID = 0;
                    string _maDV = dtgDSDichVu.CurrentRow.Cells[MaDVKhac.Name].Value.ToString().Trim();
                    string _SoHinh = dtgDSDichVu.CurrentRow.Cells[SoHinh.Name].Value.ToString().Trim();
                    _NewPanelID = int.Parse(_SoHinh);
                    current_PanelShowing = Change_Panel(_NewPanelID, current_PanelShowing, pnResult);
                    if (_NewPanelID == 0)
                    {
                        fKQKhongHinh.Load_Result(txtSID.Text, _maDV);
                    }
                    else
                    {
                        fKQCoHinh.Load_Result(txtSID.Text, _maDV);
                    }
                }
            }
        }
        private void FrmCLS_DVKhac_KetQua_Shown(object sender, EventArgs e)
        {
            pnKQCoHinh.Size = new System.Drawing.Size(pnResult.DisplayRectangle.Width, pnResult.DisplayRectangle.Height);
            pnKQKhongHinh.Size = new System.Drawing.Size(pnResult.DisplayRectangle.Width, pnResult.DisplayRectangle.Height);
            _loading = true;
            Add_SubForm();
            Load_PatientList(false);
            LabServices_Helper.LoadPrinterName(listPrinter, "OrtherPrinter", false);
            _loading = false;
            Check_Show_WorkForm();
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryOrtherPrinter, listPrinter.SelectedIndex.ToString());
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(CommonAppVarsAndFunctions.LstPrinter, "", true);
            LabServices_Helper.LoadPrinterName(listPrinter, "OrtherPrinter", false);
        }
    }
}
