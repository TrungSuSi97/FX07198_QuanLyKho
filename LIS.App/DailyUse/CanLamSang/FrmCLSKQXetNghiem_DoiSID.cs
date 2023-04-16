using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClinicManagementSystem
{
    public partial class FrmCLSKQXetNghiem_DoiSID : FrmTemplate
    {
        public FrmCLSKQXetNghiem_DoiSID()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFromBarcode.Text) || string.IsNullOrEmpty(txtToBarcode.Text))
            {
                Warnings.MSG_INFORMATION("Hãy nhập đủ thông tin chuyển đổi barcode!");
            }
            else
            {
                if (Warnings.MSG_QUESTION_GET_YES(string.Format("Đổi số barcode kết quả máy từ ngày:{0} - Số: {1}\nThành ngày: {2} - Số: {3}", dtpFromDate.Value.ToString("dd/MM/yyyy"), txtFromBarcode.Text, dtpToDate.Value.ToString("dd/MM/yyyy"), txtToBarcode.Text)))
                {
                    CLS_KetQuaMay_DAL kmay = new CLS_KetQuaMay_DAL();
                    if (kmay.Update_KQMay_Barcode(txtFromBarcode.Text, dtpFromDate.Value, txtToBarcode.Text, dtpToDate.Value) > -1)
                        this.Close();
                }
            }
        }
    }
}
