using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class UcAddEditControl : UserControl
    {
        public UcAddEditControl()
        {
            InitializeComponent();
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnCancel.Click += btnCancel_Click;
            btnSave.Click += btnSave_Click;

        }



        private string _buttonAddText = "&Thêm mới";

        [Category("CustomButtonText")]
        public string ButtonAddText
        {
            get { return _buttonAddText; }
            set
            {
                _buttonAddText = value;
                btnAdd.Text = value;
            }
        }


        private string _buttonEditText = "&Chỉnh sửa";

        [Category("CustomButtonText")]
        public string ButtonEditText
        {
            get { return _buttonEditText; }
            set
            {
                _buttonEditText = value;
                btnEdit.Text = value;
            }
        }


        private string _buttonDeleteText = "&Xoá dữ liệu";

        [Category("CustomButtonText")]
        public string ButtonDeleteText
        {
            get { return _buttonDeleteText; }
            set
            {
                _buttonDeleteText = value;
                btnDelete.Text = value;
            }
        }


        private string _buttonCancelText = "&Hủy lệnh ";

        [Category("CustomButtonText")]
        public string ButtonCancelText
        {
            get { return _buttonCancelText; }
            set
            {
                _buttonCancelText = value;
                btnCancel.Text = value;
            }
        }


        private string _buttonSaveText = "&Lưu dữ liệu";

        [Category("CustomButtonText")]
        public string ButtonSaveText
        {
            get { return _buttonSaveText; }
            set
            {
                _buttonSaveText = value;
                btnSave.Text = value;
            }
        }

        public event EventHandler ButtonAddClick;

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            //bubble the event up to the parent
            if (this.ButtonAddClick != null)
            {
                this.ButtonAddClick(this, e);
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnAdd.Enabled = false;
            }
        }

        public event EventHandler ButtonEditClick;

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            //bubble the event up to the parent
            if (this.ButtonEditClick != null)
            {
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = true;
                this.ButtonEditClick(this, e);
            }
        }

        public event EventHandler ButtonDeleteClick;

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            this.ButtonDeleteClick?.Invoke(this, e);
        }

        public event EventHandler ButtonCancelClick;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.ButtonCancelClick != null)
            {
                this.ButtonCancelClick(this, e);
                //SetStatusButtonNormal();
            }
        }

        public event EventHandler ButtonSaveClick;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            this.ButtonSaveClick?.Invoke(this, e);
        }
        public void SetStatusButtonNormal()
        {
            btnCancel.Enabled = false; 
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
        }
        public void SetStatusButtonFunction(bool isAdmin, bool checkFunction)
        {
            if (isAdmin || checkFunction)
            {
                SetStatusButtonNormal();
            }
            else
            {
                btnCancel.Enabled =
                    btnSave.Enabled =
                        btnAdd.Enabled =
                            btnEdit.Enabled =
                                btnDelete.Enabled = false;
            }
        }
        public void Set_FocusAdd()
        {
            btnAdd.Focus();
        }
        public void Set_FocusEdit()
        {
            btnEdit.Focus();
        }
        public void Set_FocusDelete()
        {
            btnDelete.Focus();
        }
        public void Set_FocusSave()
        {
            btnSave.Focus();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
