using System;
using System.Drawing;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Language;
using TPH.LIS.Common.Controls.CustomMsgBox;


namespace TPH.LIS.Common.Controls
{
    public partial class FrmMessageBox : TPHTemplateForm
    {
        public FrmMessageBox()
        {
            InitializeComponent();
            pnErrorButton.BackColor = CommonAppColors.ColorMainAppColor;
            pnNormalButton.BackColor = CommonAppColors.ColorMainAppColor;
        }
        public CustomMessageBoxConstants.DefaultButton btnDefault = CustomMessageBoxConstants.DefaultButton.Default;

        DialogResult diagResult = DialogResult.OK;
        private bool _isErrorWithDetailMode = false;
        public bool IsErrorWithDetailMode
        {
            get { return _isErrorWithDetailMode; }
            set { _isErrorWithDetailMode = value; }
        }

        private bool _isAlertMode = false;
        public bool IsAlertMode
        {
            get { return _isAlertMode; }
            set { _isAlertMode = value; }
        }

        private string _errorDetail = string.Empty;
        public string ErrorDetail
        {
            get { return _errorDetail; }
            set { _errorDetail = value; }
        }


        public DialogResult DiagResult
        {
            get { return diagResult; }
            set { diagResult = value; }
        }
        int msgIcon = -1;
        /// <summary>
        /// Flat for icon --> 
        /// 0: Asterisk - 1: Error - 2: Exclamation - 3: Hand
        /// - 4: Information - 5: Question - 6: Stop - 7: Warning - 8: Loading
        /// - Else: None
        /// </summary>
        public int MsgIcon
        {
            get { return msgIcon; }
            set { msgIcon = value; }
        }
        MessageBoxButtons msgBtn = MessageBoxButtons.OK;

        public MessageBoxButtons MsgBtn
        {
            get { return msgBtn; }
            set { msgBtn = value; }
        }

        string msgTitle = string.Empty;

        public string MsgTitle
        {
            get { return msgTitle; }
            set { msgTitle = value; }
        }
        string msgContent = string.Empty;

        public string MsgContent
        {
            get { return msgContent; }
            set
            {
                msgContent = value;
                lblMsgContent.Text = msgContent;
            }
        }

        DialogResult _msgResult = DialogResult.None;

        public DialogResult MsgResult
        {
            get { return _msgResult; }
            set { _msgResult = value; }
        }


        private void Check_ShowButton()
        {
            if (_isErrorWithDetailMode)
            {
                pnErrorButton.Visible = true;
                //pnMessContent.MaximumSize = new Size(422, 150);
                pnNormalButton.Visible = false;
            }
            else
            {
                pnErrorButton.Visible = false;
                //pnMessContent.MaximumSize = new Size(422, this.Height - pnNormalButton.Height);
                if (!_isAlertMode)
                {
                    pnNormalButton.Visible = true;

                    if (msgBtn == MessageBoxButtons.OKCancel)
                    {
                        pnNo.Visible = false;
                    }
                    else if (msgBtn == MessageBoxButtons.YesNo)
                    {
                        pnCancel.Visible = false;
                    }
                    else if (msgBtn == MessageBoxButtons.AbortRetryIgnore)
                    {
                        btnYes.Text = "Bỏ qua";
                        btnNo.Text = "Thử lại";
                        btnCancel.Text = "Dừng";
                    }
                    else if (msgBtn == MessageBoxButtons.RetryCancel)
                    {
                        btnYes.Text = "Thử lại";
                        pnNo.Visible = false;
                        btnCancel.Text = "Hủy bỏ";
                    }
                    else if (msgBtn == MessageBoxButtons.OK)
                    {
                        btnYes.Text = "Đóng";
                        pnCancel.Visible = false;
                        pnNo.Visible = false;
                    }
                }
                else
                    pnNormalButton.Visible = false;
            }
            this.Invalidate();
        }

        private void Check_ShowIcon()
        {
            if (_isErrorWithDetailMode)
            {
                iconCurrentChildForm.Image = imageList1.Images[1];
            }
            else
            {
                //==0 :Asterisk
                if (msgIcon == 0)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Asterisk;
                }
                //1:MessageBoxIcon.Error
                else if (msgIcon == 1)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Ban;
                }
                //2:MessageBoxIcon.Exclamation
                else if (msgIcon == 2)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Exclamation;
                }
                //3:MessageBoxIcon.Hand
                else if (msgIcon == 3)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.HandPaper;
                }
                //4:MessageBoxIcon.Information
                else if (msgIcon == 4)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Info;
                }
                //5: MessageBoxIcon.Question
                else if (msgIcon == 5)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Question;
                }
                //6: MessageBoxIcon.Stop
                else if (msgIcon == 6)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Stop;
                }
                //7: MessageBoxIcon.Warning
                else if (msgIcon == 7)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
                }
                //8: MessageBoxIcon.Loading
                else if (msgIcon == 8)
                {
                    iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Spinner;
                }
                else
                    iconCurrentChildForm.Visible = false;
            }
        }
        private DialogResult Get_Result(Button btn)
        {
            if (msgBtn == MessageBoxButtons.OK || msgBtn == MessageBoxButtons.OKCancel 
                || msgBtn == MessageBoxButtons.YesNo || msgBtn == MessageBoxButtons.YesNoCancel)
            {
                if (btn.Name == btnCancel.Name)
                    return DialogResult.Cancel;
                else if (btn.Name == btnNo.Name)
                    return DialogResult.No;
                else if (btn.Name == btnYes.Name)
                    return DialogResult.Yes;
                else
                    return DialogResult.None;
            }
            else if (msgBtn == MessageBoxButtons.AbortRetryIgnore)
            {
                if (btn.Name == btnCancel.Name)
                    return DialogResult.Abort;
                else if (btn.Name == btnNo.Name)
                    return DialogResult.Retry;
                else if (btn.Name == btnYes.Name)
                    return DialogResult.Ignore;
                else
                    return DialogResult.None;
            }
            else if (msgBtn == MessageBoxButtons.RetryCancel)
            {
                if (btn.Name == btnCancel.Name)
                    return DialogResult.Cancel;
                else if (btn.Name == btnNo.Name)
                    return DialogResult.None;
                else if (btn.Name == btnYes.Name)
                    return DialogResult.Retry;
                else
                    return DialogResult.None;
            }
            else
                return DialogResult.None;
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            Check_ShowIcon();
            Check_ShowButton();
            lblTitleChildForm.Text = msgTitle;
            lblMsgContent.Text = msgContent;
            if (IsErrorWithDetailMode && !string.IsNullOrEmpty(_errorDetail))
                txtDetail.Text = _errorDetail;
            else
                txtDetail.Visible = false;
            this.TopMost = true;
            LanguageExtension.LocalizeForm(this, string.Empty);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _msgResult = Get_Result(btnYes);
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            _msgResult = Get_Result(btnNo);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _msgResult = Get_Result(btnCancel);
            this.Close();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (btnDetail.Text.Trim().Replace("&", "").Equals("Chi tiết", StringComparison.OrdinalIgnoreCase))
            {
                btnDetail.Text = "     Ẩn chi tiết";
                this.AutoSize = false;
                this.Height += (txtDetail.Height + this.Padding.Bottom);
                txtDetail.Visible = true;
                this.CenterToScreen();
            }
            else
            {
                btnDetail.Text = "     &Chi tiết";
                btnDetail.Width = 73;

                txtDetail.Visible = false;
                this.Size = new Size(this.Width, this.Height - (txtDetail.Height + this.Padding.Bottom));
                this.CenterToScreen();
            }
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            diagResult = DialogResult.Ignore;
            this.Close();
        }

        private void FrmMessageBox_Shown(object sender, EventArgs e)
        {
            if (pnErrorButton.Visible)
                btnIgnore.Focus();
            else if (pnNormalButton.Visible)
            {
                if (btnYes.Visible && btnDefault == CustomMessageBoxConstants.DefaultButton.Accept)
                    btnYes.Focus();
                else if (btnNo.Visible && btnDefault == CustomMessageBoxConstants.DefaultButton.NotAccept)
                    btnNo.Focus();
            }
           LanguageExtension.LocalizeForm(this, string.Empty);
            this.AutoSize = false;

            if (pnNormalButton.Visible == false && pnErrorButton.Visible == false)
            {
                this.Height = pnContent.Height - this.pnNormalButton.Height - this.pnErrorButton.Height;
            }
            else
                this.Height = pnContent.Height + this.Padding.Bottom + pnNormalButton.Padding.Bottom;
            if (txtDetail.Visible)
            {
                btnDetail.Text = "     Ẩn chi tiết";
                this.Height += this.Padding.Bottom;
            }
            this.CenterToScreen();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblMsgContent.Text, TextDataFormat.UnicodeText);
        }

        private void btnCopyDetail_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblMsgContent.Text + Environment.NewLine + "|| ====== CHI TIẾT ====== ||" + Environment.NewLine + txtDetail.Text, TextDataFormat.UnicodeText);
        }
    }
}
