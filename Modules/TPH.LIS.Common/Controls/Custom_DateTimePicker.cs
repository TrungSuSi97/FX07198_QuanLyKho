using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomDateTimePicker : DateTimePicker
    {
        public CustomDateTimePicker()
        {
            if (_isStartDate)
            {
                _isEndDate = false;
                this.Value = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 0, 0, 0);
            }
            else if (_isEndDate)
            {
                _isStartDate = false;
                this.Value = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, 23, 59, 59);
            }
            InitializeComponent();

        }
        [Category ("Custom")]
        private bool _allowMoveFocus =false;
        public bool AllowMoveFocus
        {
            get { return _allowMoveFocus; }
            set { _allowMoveFocus = value; }
        }
        [Category("Custom")]
        private bool _isStartDate = false;
        public bool IsStartDate
        {
            get { return _isStartDate; }
            set { _isStartDate = value; }
        }
        [Category("Custom")]
        private bool _isEndDate = false;
        public bool IsEndDate
        {
            get { return _isEndDate; }
            set { _isEndDate = value; }
        }

        private bool _justKeyUp = false;
        private bool _justUncheck = false;
        private bool _justMoveKey = false;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                _justKeyUp = false;
            }
            else if (e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left || e.KeyChar == (char)Keys.Up || e.KeyChar == (char)Keys.Down)
            {
                _justKeyUp = false;
                _justMoveKey = true;
            }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _justKeyUp = false;
            _justUncheck = true;
            _justMoveKey = false;
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            _justKeyUp = false;
            _justUncheck = true;
            _justMoveKey = false;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                _justKeyUp = false;
                _justMoveKey = true;
            }
            else
            {
                _justMoveKey = false;
                _justKeyUp = true;
            }
        }
        
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            if (_allowMoveFocus )
            {
                if (_justKeyUp && _justMoveKey == false)
                {
                    _justKeyUp = false;
                    SendKeys.Send("{RIGHT}");
                    _justMoveKey = false;
                }
                else if (_justUncheck)
                { 
                    if (Checked && _justMoveKey == false)
                    {
                        this.Focus();
                        _justKeyUp = false;
                        _justUncheck = false;
                       
                        SendKeys.Send("{RIGHT}");
                        _justMoveKey = false;
                    }
                }
                else if (!Checked)
                {
                    _justUncheck = true;
                    _justMoveKey = false;
                }
                else if (Checked)
                {
                    this.Focus();
                    SendKeys.Send("{RIGHT}");
                    _justMoveKey = false;
                }
            }
            else
                _justMoveKey = false;
        }
    }
}
