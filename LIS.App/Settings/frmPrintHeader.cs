using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ClinicManagementSystem
{
    public partial class frmPrintHeader : frmTemplate
    {
        public frmPrintHeader()
        {
            InitializeComponent();
        }
        C_Data data = new C_Data();
        SqlDataAdapter daHeader = new SqlDataAdapter();
        DataTable dtHeader = new DataTable();
        DataProvider dp = new DataProvider();
        private void frmPrintHeader_Load(object sender, EventArgs e)
        {
            Load_Header();
        }
        private void Load_Header()
        {
            string _ID = "";
            if (radXNChung.Checked)
            {
                _ID = "A";
            }
            else if (radHuyetHoc.Checked)
            {
                _ID = "HH";
            }
            else if (radSinhHoa.Checked)
            {
                _ID = "SH";
            }
            else if (radMienDich.Checked)
            {
                _ID = "MD";
            }
            else if (radViSinh.Checked)
            {
                _ID = "VS";
            }
            else if (radSieuAm.Checked)
            {
                _ID = "SA";
            }
            else if (radXQuang.Checked)
            {
                _ID = "XQ";
            }

            if (_ID != "")
            {
                data.Get_Header_Config(daHeader, dtgHeader, bvHeader, _ID, ref dtHeader);
               
            }
        }

        private void dtgHeader_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgHeader.RowCount > 0)
            {
                dp.UpdateData(daHeader, ref dtHeader, dtgHeader, "", "");
                dtgHeader.AutoResizeColumns();
            }
        }

        private void radXNChung_CheckedChanged(object sender, EventArgs e)
        {
            if (radXNChung.Checked)
            {
                Load_Header();
            }
        }

        private void radSinhHoa_CheckedChanged(object sender, EventArgs e)
        {
            if (radSinhHoa.Checked)
            {
                Load_Header();
            }
        }

        private void radHuyetHoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radHuyetHoc.Checked)
            {
                Load_Header();
            }
        }

        private void radMienDich_CheckedChanged(object sender, EventArgs e)
        {
            if (radMienDich.Checked)
            {
                Load_Header();
            }
        }

        private void radViSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (radViSinh.Checked)
            {
                Load_Header();
            }
        }

        private void radSieuAm_CheckedChanged(object sender, EventArgs e)
        {
            if (radSieuAm.Checked)
            {
                Load_Header();
            }
        }

        private void radXQuang_CheckedChanged(object sender, EventArgs e)
        {
            if (radXQuang.Checked)
            {
                Load_Header();
            }
        }
    }
}
