using System;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Log.Constants;
using TPH.LIS.Log.Services.PatientLog;

namespace TPH.LIS.App.ActionLog
{
    public partial class FrmDeleteCustomer : FrmTemplate
    {
        public FrmDeleteCustomer()
        {
            InitializeComponent();
        }

        private readonly IPatientLogService _patientLogService = new PatientLogService(); 

        private void FrmDeleteCustomer_Load(object sender, EventArgs e)
        {
        }

        private void dtgPatient_DataBindingComplete(
            object sender, 
            DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn cl in dtgPatient.Columns)
            {
                cl.ReadOnly = true;
            }
        }

        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            FindDeletedCustomers();
        }

        private void FindDeletedCustomers()
        {
            dtgPatient.DataBindings.Clear();
            dtgPatient.Refresh();

            var deletedCustomers = _patientLogService.GetDeletedPatients(
                dtpDateFrom.Value.ToString("yyyy-MM-dd 00:00:00.00"),
                dtpDateTo.Value.ToString("yyyy-MM-dd 23:59:59.00"),
                txtSeq.Text);

            if (deletedCustomers == null || 
                deletedCustomers.Rows == null || 
                deletedCustomers.Rows.Count == 0)
            {
                CustomMessageBox.MSG_Information_OK(PatientLogConstant.ErrorDontFindAnyPatientByCondion);
            }

            ControlExtension.BindDataToGrid(deletedCustomers.Copy(), ref dtgPatient, ref bvPatient);
        }

        private void txtSeq_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
            if (LabServices_Helper.IsKeyEnter(e))
            {
                FindDeletedCustomers();
            }
        }
    }
}