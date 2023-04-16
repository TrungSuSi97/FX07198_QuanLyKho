using System;
using System.Windows.Forms;
using TPH.Language;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class FrmDoiBarcode : Form
    {
        private readonly IAnalyzerResultService _iAnalyzerResult = new AnalyzerResultService();
        public FrmDoiBarcode()
        {
            InitializeComponent();
        }
        private string _OldCode = "";

        public string OldCode
        {
            get { return _OldCode; }
            set { _OldCode = value; }
        }
        private string _NewCode = "";

        public string NewCode
        {
            get { return _NewCode; }
            set { _NewCode = value; }
        }

        DateTime _OldDate;

        public DateTime OldDate
        {
            get { return _OldDate; }
            set { _OldDate = value; }
        }
        DateTime _NewDate;

        public DateTime NewDate
        {
            get { return _NewDate; }
            set { _NewDate = value; }
        }
        public string UserID = "";
        public string IDList = string.Empty;
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFromBarcode.Text) || string.IsNullOrEmpty(txtToBarcode.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập đủ thông tin chuyển đổi barcode!");
            }
            else
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Đổi số barcode kết quả máy từ ngày:{0} - Số: {1}\nThành ngày: {2} - Số: {3}", dtpFromDate.Value.ToString("dd/MM/yyyy"), txtFromBarcode.Text, dtpToDate.Value.ToString("dd/MM/yyyy"), txtToBarcode.Text)))
                {
                    if (_iAnalyzerResult.Update_KQMay_Barcode(txtFromBarcode.Text, dtpFromDate.Value, txtToBarcode.Text, dtpToDate.Value, UserID, IDList) > -1)
                    {
                        this.Close();
                        _NewCode = txtToBarcode.Text;
                        _NewDate = dtpToDate.Value;
                    }
                }
            }
        }

        private void FrmDoiBarcode_Load(object sender, EventArgs e)
        {

            if (_OldCode != "")
            {
                dtpFromDate.Value = _OldDate;
                txtFromBarcode.Text = _OldCode;
                txtToBarcode.Focus();
            }
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
        private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtFromBarcode);
        }

        private void txtFromBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, dtpToDate);
        }

        private void dtpToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtToBarcode);
        }

        private void txtToBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnChange_Click(sender, e);
            }
        }
    }
}
