using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.App.ThucThi.BenhNhan;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.ThucThi.CanLamSang
{
    public partial class frmCLSKetQuaXQuang : FrmTemplate
    {

        C_Patient pInfo = new C_Patient();
        C_Patient_XQuang xquang = new C_Patient_XQuang();
        C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();
        DataTable dtPatient = new DataTable();
        DataTable dtKetQuaChup = new DataTable();
        C_Config config = new C_Config();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        DateTime dtDateInG = new DateTime();

        bool _Loading = false;
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);

        public DateTime DtDateInG
        {
            get { return dtDateInG; }
            set { dtDateInG = value; }
        }
        string _MatiepNhanG = "";

        public string MatiepNhanG
        {
            get { return _MatiepNhanG; }
            set { _MatiepNhanG = value; }
        }

        public frmCLSKetQuaXQuang()
        {
            InitializeComponent();
        }

        private void frmCLSKetQuaXQuang_Load(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, "PrinterResult", false);
            Load_MayXQuang();
            C_NguoiDung user = new C_NguoiDung();
            user.Get_UserSign(cboUsersign, ServiceType.ClsXQuang, " and d.MaNguoiDung not in ('admin')");
            if (_MatiepNhanG != "")
            {
                _Loading = true;
                txtSEQ.Text = _MatiepNhanG;
                dtpDateIn.Value = dtDateInG;
                _Loading = false;
            }
            Load_ThongTin();
        }
        private void Load_MayXQuang()
        {
            sysConfig.Get_DMMayXQuang(cboMayXQuang);

        }

        private void ClearControl()
        {
            txtSID.DataBindings.Clear();
            txtSID.Text = "";
            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = "";
            txtAddress.DataBindings.Clear();
            txtAddress.Text = "";
            txtPhone.DataBindings.Clear();
            txtPhone.Text = "";
            txtEmail.DataBindings.Clear();
            txtEmail.Text = "";
            txtAge.DataBindings.Clear();
            txtAge.Text = "";
            txtSex.DataBindings.Clear();
            txtSex.Text = "";
            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;
            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;
            lblSex.Text = "";
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = "";
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = "";
            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = "";
            txtLanIn.DataBindings.Clear();
            txtLanIn.Text = "";
            txtTGIn.DataBindings.Clear();
            txtTGIn.Text = "";
        }
        private void Load_ThongTin()
        {
            if (_Loading == false)
            {
                _Loading = true;
                string _TempSEQ = txtSEQ.Text;
                int _PrintType = 0;
                if (radNotPrint.Checked)
                    _PrintType = 2;
                else if (radPrinted.Checked)
                    _PrintType = 1;
                dtPatient = xquang.Get_Patient_XQuang("", dtpDateIn.Value.ToString("yyyy-MM-dd"), _PrintType);
                ControlExtension.BindDataToGrid(dtPatient, ref dtgPatient, ref bvPatient);
                BindPatient(bvPatient.BindingSource);
                if (dtgPatient.RowCount > 0)
                {
                    if (_TempSEQ != "")
                    {
                        txtSEQ.Text = _TempSEQ;
                        SelectRow_SEQ();
                    }
                }
                else
                {
                    txtSEQ.Text = "";
                    Load_DS_VungChup();
                }
                _Loading = false;
            }

        }
        private void SelectRow_SEQ()
        {
            bvPatient.BindingSource.Filter = string.Format("SEQ = {0} or TenBN like '%{0}%'", txtSEQ.Text);
        }
        private void Load_DS_VungChup()
        {
            string _MaTiepNhan = txtSID.Text;
            ControlExtension.BindDataToGrid(xquang.DuLieu_XQuang_DanhSach_KQVC(_MaTiepNhan), ref dtgVungChup, ref bvKetQua_XQuang);
            Bindata_VungChup();
        }
        private void Bindata_VungChup()
        {
            txtKetLuan.DataBindings.Clear();
            txtKetLuan.Text = "";
            txtKetLuan.DataBindings.Add("Text", bvKetQua_XQuang.BindingSource, "KetLuan");
            txtDeNghi.DataBindings.Clear();
            txtDeNghi.Text = "";
            txtDeNghi.DataBindings.Add("Text", bvKetQua_XQuang.BindingSource, "DeNghi");
            ricNoiDung.DataBindings.Clear();
            ricNoiDung.Rtf = null;
            ricNoiDung.DataBindings.Add("Rtf", bvKetQua_XQuang.BindingSource, "KetQua");

            cboUsersign.DataBindings.Clear();
            cboUsersign.SelectedIndex = -1;
            cboUsersign.DataBindings.Add("SelectedValue", bvKetQua_XQuang.BindingSource, "NguoiKy");

            chkDaInVC.DataBindings.Clear();
            chkDaInVC.Checked = false;
            chkDaInVC.DataBindings.Add("Checked", bvKetQua_XQuang.BindingSource, "DaInKQ");

            chkDaValidVC.DataBindings.Clear();
            chkDaValidVC.Checked = false;
            chkDaValidVC.DataBindings.Add("Checked", bvKetQua_XQuang.BindingSource, "XacNhanKQ");

            txtTenMayXQuang.DataBindings.Clear();
            txtTenMayXQuang.DataBindings.Add("Text", bvKetQua_XQuang.BindingSource, "MayXQuang");

        }
        private void BindPatient(BindingSource bs)
        {
            ClearControl();
            txtSID.DataBindings.Clear();
            txtSID.DataBindings.Add("Text", bs, "MaTiepNhan");
            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
            txtPhone.DataBindings.Add("Text", bs, "SDT");
            txtEmail.DataBindings.Add("Text", bs, "Email");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            txtSex.DataBindings.Add("Text", bs, "GioiTinh");
            txtLanIn.DataBindings.Add("Text", bs, "LanInXQuang");
            txtTGIn.DataBindings.Add("Text", bs, "ThoiGianInXQuang", true, DataSourceUpdateMode.Never, null, "dd/MM/yyyy HH:mm");
            txtChanDoan.DataBindings.Add("Text", bs, "ChanDoan");
            dtpBirthday.DataBindings.Add("Value", bs, "SinhNhat", true, DataSourceUpdateMode.OnValidation, DateTime.Now);
        }
        private void txtSEQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SelectRow_SEQ();
                e.Handled = true;
            }
        }

        private void txtSEQ_Enter(object sender, EventArgs e)
        {
            txtSEQ.BackColor = Color.LightGreen;
        }
        private void txtSEQ_Leave(object sender, EventArgs e)
        {
            txtSEQ.BackColor = Color.White;
        }


        private int _CanhLeKQ(string KQ)
        {
            //1: MiddleLeft ; 2:MiddleRight; 3:MiddleCente
            if (LabServices_Helper.IsNumeric(KQ))
            {
                return 2;
            }
            else
                return 1;
        }
        private Color _MauKQ(int _co, ref FontStyle fstyle)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            if (_co == 2)
            {
                fstyle = FontStyle.Bold;
                return Color.DarkBlue;
            }
            else if (_co == 3)
            {
                fstyle = FontStyle.Bold;
                return Color.Crimson;
            }
            else
            {
                fstyle = FontStyle.Regular;
                return Color.Black;
            }
        }

        private void btnLuuKetLuan_Click(object sender, EventArgs e)
        {
            if (dtgVungChup.CurrentRow != null)
            {
                xquang.CapNhat_KetLuan_XQuang(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), dtgVungChup.CurrentRow.Cells["MaVungChup"].Value.ToString().Trim(), txtKetLuan.Text);
            }
        }

        private void btnLuuDeNghi_Click(object sender, EventArgs e)
        {
            if (dtgVungChup.CurrentRow != null)
            {
                xquang.CapNhat_DeNghi_XQuang(ConfigurationDetail.Get_MaTiepNhan(txtSEQ.Text, dtpDateIn.Value), dtgVungChup.CurrentRow.Cells["MaVungChup"].Value.ToString().Trim(), txtDeNghi.Text);
            }
        }

        private void Valid_InValid(bool valid)
        {
            if (dtgVungChup.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes((valid == true ? "Xác nhận " : "Hủy xác nhận ") + "các kết quả?"))
                {
                    string maTiepNhan = txtSID.Text;
                    string validText = (valid ? Common.CommonConstant.IsValided : Common.CommonConstant.InValid);
                    string maVc = dtgVungChup.CurrentRow.Cells["MaVungChup"].Value.ToString().Trim();
                    xquang.XacNhan_KQ_XQuang(maTiepNhan, maVc, validText, valid, CommonAppVarsAndFunctions.UserID);
                    Refresh_Result();
                }
            }
        }


        private void btnValidResult_Click(object sender, EventArgs e)
        {
            Valid_InValid(true);
        }

        private void btnInValid_Click(object sender, EventArgs e)
        {
            Valid_InValid(false);
        }

        private void listPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryPrinterResult, 
                listPrinter.SelectedIndex.ToString());
            
        }
        private void btnRefreshResult_Click(object sender, EventArgs e)
        {
            Refresh_Result();
        }
        private void Refresh_Result()
        {
            int _Current_ResultIndex = -1;
            if (dtgVungChup.RowCount > 1)
            {
                _Current_ResultIndex = dtgVungChup.CurrentRow.Index;
            }
            Load_ThongTin();
            if (_Current_ResultIndex != -1)
                dtgVungChup.CurrentCell = dtgVungChup[TenVungChup.Name, _Current_ResultIndex];
        }
        private string _MaVungChup()
        {
            string _vc = "";
            for (int i = 0; i < dtgVungChup.RowCount; i++)
            {
                if (dtgVungChup["KhongIn", i].Value != null)
                {
                    if ((bool)dtgVungChup["KhongIn", i].Value)
                    {
                        _vc = (_vc == "" ? "'" + dtgVungChup["MaVungChup", i].Value + "'" : ",'" + dtgVungChup["MaVungChup", i].Value + "'");
                    }
                }
            }
            return _vc;
        }
        private void PrintResult(bool _Print, bool _Manual)
        {
            Save_Result(false);
            config.LoadPrintHeader("XQ");
            //Lấy mã vùng chụp
            string _VungChup = "";
            if (_Manual)
            {
                _VungChup = _MaVungChup();
            }
            DataTable dtPrint = new DataTable();
            dtPrint = xquang.DuLieuIn_XQuang(dtPatient, _VungChup, bvPatient.BindingSource.Position, false);
            if (dtPrint.Rows.Count > 0)
            {
                //progressPrint.Maximum = 6;
                //progressPrint.Visible = true;
                //progressPrint.Value = 0;
                //if (report.IsDisposed)
                //{
                //    progressPrint.Value++;
                //    report = new FrmReport();
                //}
                //string _PrinterName = "";
                //if (listPrinter.Items.Count > 0)
                //{
                //    if (listPrinter.SelectedIndex == -1)
                //    {
                //        listPrinter.SelectedIndex = 0;
                //    }
                //    progressPrint.Value++;
                //    _PrinterName = listPrinter.SelectedItem.ToString();
                //}
                //progressPrint.Value++;

                //Reports.rpKQXQuang rp = new Reports.rpKQXQuang();

                //if (report.Excute_Show_Print_Report(rp, dtPrint, "XQ", false, false, !_Print, _Print, _PrinterName, false))
                //{
                //    xquang.CapNhat_In_KQ_XQuang(txtSID.Text, (cboUsersign.SelectedIndex == -1 ? "" : cboUsersign.SelectedValue.ToString().Trim()));
                //}
                //report.Dispose();
                //progressPrint.Visible = false;
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Không có dữ liệu để in !");
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dtPatient.Rows.Count > 0)
            {
                PrintResult(false, true);
            }
        }

        private void frmCLSKetQuaXQuang_Activated(object sender, EventArgs e)
        {
            txtSEQ.Focus();
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            Load_ThongTin();
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(CommonAppVarsAndFunctions.LstPrinter, "PrinterResult", true);
            LabServices_Helper.LoadPrinterName(listPrinter, "PrinterResult", false);
        }

        private void btnSearchSEQ_Click(object sender, EventArgs e)
        {
            FrmTimBenhNhan frm = new FrmTimBenhNhan();
            frm.DtDateFromG = dtpDateIn.Value;
            frm.ServiceTypeID = ServiceType.ClsXQuang.ToString();
            frm.List = true;
            frm.ShowDialog();
            if (frm.ReturnSEQ != "")
            {
                _Loading = true;
                dtpDateIn.Value = frm.ReturnDateIn;
                txtSEQ.Text = frm.ReturnSEQ;
                radAllPrint.Checked = true;
                _Loading = false;
                //Load danh sách
                Load_ThongTin();
            }
            frm.Dispose();
        }

        private void chkDaValidVC_CheckedChanged(object sender, EventArgs e)
        {
            btnInValid.Visible = chkDaValidVC.Checked;
            btnValidResult.Visible = !chkDaValidVC.Checked;
            Check_Enable_Edit(chkDaValidVC.Checked);
        }

        private void Check_Enable_Edit(bool _Lock)
        {
            ricNoiDung.Enabled = !_Lock;
            btnLuuKetLuan.Enabled = txtKetLuan.Enabled = !_Lock;
            btnLuuDeNghi.Enabled = txtDeNghi.Enabled = !_Lock;
            cboMayXQuang.Enabled = !_Lock;
            cboUsersign.Enabled = !_Lock;
        }

        private void chkDaInVC_CheckedChanged(object sender, EventArgs e)
        {
            cboUsersign.Enabled = !chkDaInVC.Checked;
        }

        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPatient.RowCount > 0)
            {
                txtSEQ.Text = dtgPatient.CurrentRow.Cells[SEQ.Name].Value.ToString().Trim();
            }
            Load_DS_VungChup();
        }

        private void btnLuuKetQua_Click(object sender, EventArgs e)
        {
            Save_Result(true);
        }
        private void Save_Result(bool _ask)
        {
            if (dtgVungChup.RowCount > 0)
            {
                bool _ok = false;
                if (_ask)
                {
                    _ok = CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu kết quả chụp X-Quang?");
                }
                else
                    _ok = true;

                if (_ok)
                {
                    Set_User();
                    //Cập nhật Kết quả.
                    string _MaTiepNhan = txtSID.Text;
                    string _MaVungChup = dtgVungChup.CurrentRow.Cells["MaVungChup"].Value.ToString().Trim();
                    string _NguoiKy = (cboUsersign.SelectedIndex == -1 ? "" : cboUsersign.SelectedValue.ToString());
                    xquang.CapNhat_KQ_XQuang(_MaTiepNhan, _MaVungChup, ricNoiDung.Rtf, _NguoiKy, txtTenMayXQuang.Text);
                    //cap nhật kết luận
                    xquang.CapNhat_KetLuan_XQuang(_MaTiepNhan, _MaVungChup, txtKetLuan.Text);
                    //Cap nhat de nghi
                    xquang.CapNhat_DeNghi_XQuang(_MaTiepNhan, _MaVungChup, txtDeNghi.Text);
                }
            }
        }
        private void Set_User()
        {
            if (cboUsersign.SelectedIndex != -1)
            {
                CommonAppVarsAndFunctions.TempSignNameXQuang = txtSignName.Text;
                CommonAppVarsAndFunctions.TempSignIdXQuang = cboUsersign.SelectedValue.ToString().Trim();
            }
            else
            {
                CommonAppVarsAndFunctions.TempSignNameXQuang = "";
                CommonAppVarsAndFunctions.TempSignIdXQuang = "";

            }
        }
        private void cboMayXQuang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboMayXQuang.SelectedIndex != -1)
            {
                txtTenMayXQuang.Text = ((DataTable)cboMayXQuang.DataSource).Rows[cboMayXQuang.SelectedIndex]["TenMay"].ToString().Trim();
            }
            else
                txtTenMayXQuang.Text = "";
        }

        private void cboMayXQuang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboMayXQuang.SelectedIndex != -1)
                {
                    txtTenMayXQuang.Text = ((DataTable)cboMayXQuang.DataSource).Rows[cboMayXQuang.SelectedIndex]["TenMay"].ToString().Trim();
                }
                else
                    txtTenMayXQuang.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dtPatient.Rows.Count > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("In kết quả?"))
                {
                    PrintResult(true, true);
                }

            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Load_ThongTin();
        }
    }
}
