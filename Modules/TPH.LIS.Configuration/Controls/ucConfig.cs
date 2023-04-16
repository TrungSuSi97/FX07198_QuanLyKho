using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using System.Data.SqlClient;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Common.Controls;
using TPH.LIS.Data;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucConfig : UserControl
    {
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        SqlDataAdapter daConfig = new SqlDataAdapter();
        DataTable dataConfig = new DataTable();
        public bool IsAdmin = false;
        public ucConfig()
        {
            InitializeComponent();
        }
        public void Load_ListConfigEnum()
        {
            var data = CauHinhConfig.ListCauHinhConfig();
            if (!IsAdmin)
                data = data.Where(x => x.Id.Equals((int)EnumCauHinhConfig.IDBarcode) == false).ToList();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            ControlExtension.BindDataToCobobox(bs, ref cboIDCauHinh, "Id", "NoiDung");
       
            cboIDCauHinh.SelectedIndexChanged += CboIDCauHinh_SelectedIndexChanged;
            if (data.Count == 1)
                cboIDCauHinh.SelectedIndex = 0;
        }

        private void CboIDCauHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Config();
        }

        public void Load_Config()
        {
            string idConfig = cboIDCauHinh.SelectedIndex > -1 ? cboIDCauHinh.SelectedValue.ToString() : string.Empty;
            _iSysConfig.Get_Data_config(dtgConfigList, bvConfigList, ref daConfig, ref dataConfig, string.Empty, idConfig);
        }
        private void Add_NewConfig()
        {
            if(cboIDCauHinh.SelectedIndex > -1)
            {
                //if (!string.IsNullOrEmpty(txtValue1.Text))
                //{
                    var obj = new CONFIG();
                    obj.Idconfig = int.Parse(cboIDCauHinh.SelectedValue.ToString());
                    obj.Value1 = txtValue1.Text;
                    obj.Value2 = txtValue2.Text;
                    obj.Description = txtDescription.Text;
                    var objInsert = _iSysConfig.Insert_config(obj);
                    if (objInsert.Id > -1)
                    {
                        Load_Config();
                        bvConfigList.BindingSource.MoveLast();
                        //txtValue1.Text = string.Empty;
                        txtValue2.Text = string.Empty;
                        txtDescription.Text = string.Empty;
                        txtValue2.Focus();
                    }

                //}
            }
        }
        private void Delete_Config()
        {
            if(dtgConfigList.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa cấu hình đang chọn?"))
                {
                    var id = dtgConfigList.CurrentRow.Cells[colID.Name].Value.ToString();
                    var objDelete = new CONFIG();
                    objDelete.Id = int.Parse(id);
                    if (_iSysConfig.Delete_config(objDelete))
                        Load_Config();
                }
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (bvConfigList.BindingSource != null)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                    bvConfigList.BindingSource.RemoveFilter();
                else
                {
                    var filter = string.Empty;
                    if (WorkingServices.IsNumeric(txtSearch.Text))
                        filter = string.Format("IDConfig = {0} ", txtSearch.Text);
                    filter += string.IsNullOrEmpty(filter) ? "" :
                        string.Format(" or Value1 =  '{0}' or Value2 = '{0}' or Description like '%{0}%'", WorkingServices.EscapeLikeValue(txtSearch.Text));
                    bvConfigList.BindingSource.Filter = filter;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Add_NewConfig();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_Config();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Config();
        }

        private void dtgConfigList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataProvider.UpdateData(daConfig, ref dataConfig, string.Empty, string.Empty);
        }
    }
}
