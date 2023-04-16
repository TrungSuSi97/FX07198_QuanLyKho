using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using GraphicSupport = TPH.LIS.Common.Extensions.GraphicSupport;

namespace TPH.LIS.App.CauHinh.HeThong
{
    public partial class frmPrintHeader : FrmTemplate
    {
        public frmPrintHeader()
        {
            InitializeComponent();
        }
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        SqlDataAdapter daHeader = new SqlDataAdapter();
        DataTable dtHeader = new DataTable();
        
        private void frmPrintHeader_Load(object sender, EventArgs e)
        {
            Load_Header();
        }
        private void Load_Header()
        {
            string _ID = "";

            data.Get_Header_Config(daHeader, dtgHeader, bvHeader, _ID, ref dtHeader);
        }

        private void dtgHeader_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgHeader.RowCount > 0)
            {
                DataProvider.UpdateData(daHeader, ref dtHeader, dtgHeader, "", "");
            }
        }

        private void frmPrintHeader_FormClosing(object sender, FormClosingEventArgs e)
        {
            C_Config config = new C_Config();
            config.LoadPrintHeader(CommonAppVarsAndFunctions.NhomIn);
        }

        private void btnAddHeader_Click(object sender, EventArgs e)
        {
            if (txtHeaderID.Text.Trim() != "")
            {
                data.Insert_Header(txtHeaderID.Text, txtDescription.Text);
                txtHeaderID.Text = "";
                txtDescription.Text = "";
                CustomMessageBox.MSG_Waring_OK("Thêm mới hoàn tất !");
                Load_Header();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập mã tiêu đề !");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_Header();
        }

        private void btnAddLogo_Click(object sender, EventArgs e)
        {
            if (dtgHeader.CurrentRow != null)
            {
                string whereCondit = String.Empty;
                if (CustomMessageBox.MSG_Question_YesNo_GetNo("Cập nhật cho tất cả?"))
                {
                    whereCondit = string.Format(" Where MaDonVi = '{0}'",
                        dtgHeader.CurrentRow.Cells[MaDonVi.Name].Value.ToString());
                }
                else
                    whereCondit = "";

                ControlExtension.LoadImage_ToPicturebox(pblogo);
                if (pblogo.Image != null || !string.IsNullOrEmpty(pblogo.ImageLocation))
                {
                    if (pblogo.Image != null)
                        DataProvider.ExcuteWithImage("Update {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn set ReportLogo = @HinhAnh " + whereCondit,
                            GraphicSupport.ImageToByteArray(pblogo.Image), false);
                    else
                    {
                        DataProvider.ExcuteWithImage("Update {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn set ReportLogo = @HinhAnh " + whereCondit,
                            File.ReadAllBytes(pblogo.ImageLocation), false);
                    }
                    Load_Header();
                }
            }
        }

        private void btnRemoveImge_Click(object sender, EventArgs e)
        {
            if (dtgHeader.CurrentRow != null)
            {
                string whereCondit = String.Empty;

                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa logo ?"))
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetNo("Cập nhật cho tất cả?"))
                    {
                        whereCondit = string.Format(" Where MaDonVi = '{0}'",
                            dtgHeader.CurrentRow.Cells[MaDonVi.Name].Value.ToString());
                    }
                    else
                        whereCondit = "";

                    pblogo.Image = null;
                    DataProvider.ExecuteQuery("Update {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn set ReportLogo = null " + whereCondit);
                    Load_Header();
                }
            }
        }

        private void dtgHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dtgHeader.CurrentRow != null)
            {
                if (dtgHeader.CurrentRow.Cells[ReportLogo.Name].Value != DBNull.Value)
                    pblogo.Image =
                        GraphicSupport.ImageFromByteArray(
                            (byte[]) dtgHeader.CurrentRow.Cells[ReportLogo.Name].Value);
                else
                    pblogo.Image = null;
            }
        }
    }
}
