using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Common.Controls
{
    public partial class TextBoxWithdate : UserControl
    {
        public TextBoxWithdate()
        {
            InitializeComponent();
            this.KeyPress += UcSearchLookupEditor_KeyPress;
            this.PreviewKeyDown += UcSearchLookupEditor_PreviewKeyDown;
            txtValue.KeyPress += UcSearchLookupEditor_KeyPress;
            dtpNgay.KeyPress += UcSearchLookupEditor_KeyPress;
        }
        private bool _chiNgay = true;
        [Category("Custom")]
        public bool NgayGio
        {
            set
            {
                _chiNgay = value;
                if (_chiNgay)
                    txtValue.Mask = "00/00/0000";
                else
                    txtValue.Mask = "00:00 00/00/0000";
            }
            get { return _chiNgay; }
        }
        [Category("Custom")]
        public Control ControlBack { get; set; }
        [Category("Custom")]
        public Control ControlNext { get; set; }
        [Category("Custom")]
        public bool CatchEnterKey
        {
            get
            {
                return catchEnterKey;
            }

            set
            {
                catchEnterKey = value;
            }
        }
        [Category("Custom")]
        public bool CatchTabKey
        {
            get
            {
                return catchTabKey;
            }

            set
            {
                catchTabKey = value;
            }
        }
        private bool catchEnterKey = false;
        private bool catchTabKey = false;
        private void UcSearchLookupEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (CatchTabKey)
            {
                if (e.KeyData == Keys.Tab && ControlNext != null)
                {
                    ControlNext.Focus();
                    e.IsInputKey = true;
                }
                else if (e.KeyData == (Keys.Tab | Keys.Shift) && ControlBack != null)
                {
                    ControlBack.Focus();
                    e.IsInputKey = true;
                }
            }
        }

        private void UcSearchLookupEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (catchEnterKey && ControlNext != null)
            {
                ControlExtension.LeaveFocusNext(e, ControlNext);
            }
        }
        private DateTime CurrentValue = DateTime.MinValue;
        public void SetValue(DateTime? value)
        {
            if (_chiNgay)
                txtValue.Text = (value == null ? string.Empty : value.Value.ToString("ddMMyyyy"));
            else
                txtValue.Text = (value == null ? string.Empty : value.Value.ToString("HHmmddMMyyyy"));
            if (value == null)
                CurrentValue = DateTime.MinValue;
            else
                CurrentValue = value.Value;
        }
        public DateTime? GetValue()
        {
            var value = txtValue.Text.Replace("_", "").Replace(":", "").Replace(" ", "");
            return (string.IsNullOrEmpty(value) ? (DateTime?)null : (CurrentValue == DateTime.MinValue ? (DateTime?)null : CurrentValue));
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                if (_chiNgay)
                {
                    var arr = txtValue.Text.Replace("_", "");
                    if (arr.Length == 8)
                    {
                        var ngay = string.Format("{0}/{1}/{2}", arr.Substring(2, 2), arr.Substring(0, 2), arr.Substring(4, 4));
                        CurrentValue = DateTime.MinValue;
                        DateTime.TryParse(ngay,
                        System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                        System.Globalization.DateTimeStyles.None, out CurrentValue);

                        if (CurrentValue.Equals(DateTime.MinValue))
                        {
                            CustomMessageBox.MSG_Information_OK("Ngày không hợp lệ.");
                            txtValue.Focus();
                        }
                    }
                }
                else
                {
                    var arr = txtValue.Text.Replace("_", "").Replace(" ", "").Replace(":", "");
                    if (arr.Length == 12)
                    {
                        var ngay = string.Format("{0}/{1}/{2} {3}:{4}", arr.Substring(6, 2), arr.Substring(4, 2), arr.Substring(8, 4), arr.Substring(0, 2), arr.Substring(2, 2));
                        CurrentValue = DateTime.MinValue;
                        DateTime.TryParse(ngay,
                        System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                        System.Globalization.DateTimeStyles.None, out CurrentValue);

                        if (CurrentValue.Equals(DateTime.MinValue))
                        {
                            CustomMessageBox.MSG_Information_OK("Ngày giờ không hợp lệ.");
                            txtValue.Focus();
                        }
                    }
                }
            }
        }

        private void dtpNgay_CloseUp(object sender, EventArgs e)
        {
            if (!tempData.Equals(dtpNgay.Value))
            {
                if (_chiNgay)
                {
                    CurrentValue = dtpNgay.Value;
                    txtValue.Text = dtpNgay.Value.ToString("ddMMyyyy");
                }
                else
                {
                    CurrentValue = dtpNgay.Value;
                    txtValue.Text = dtpNgay.Value.ToString("HHmmddMMyyyy");
                }
            }
        }
        DateTime tempData = DateTime.MinValue;
        private void dtpNgay_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtValue.Text.Replace("_", "")))
            {
                tempData = dtpNgay.Value;
            }
        }
        private void TextBoxWithdate_Enter(object sender, EventArgs e)
        {
            txtValue.Focus();
            txtValue.SelectAll();
        }
    }
}
