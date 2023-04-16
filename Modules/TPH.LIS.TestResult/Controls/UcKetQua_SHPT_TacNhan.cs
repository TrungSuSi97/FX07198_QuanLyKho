using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.TestResult.Model;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.Configuration.Services.SystemConfig;
using static TPH.LIS.Common.TestType;
using TPH.LIS.Configuration.Models;
using TPH.Controls;
using TPH.Language;

namespace TPH.LIS.TestResult.Controls
{
    public partial class ucKetQua_SHPT_TacNhan : UserControl
    {
        public ucKetQua_SHPT_TacNhan()
        {
            InitializeComponent();
            panel5.BackColor = CommonAppColors.ColorMainAppColor;
            lblTacNhan.ForeColor = label1.ForeColor = label7.ForeColor = CommonAppColors.ColorTextCaption;
        }
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly IPatientInformationService _patient = new PatientInformationService();
        private string CurrentMaTiepNhan = string.Empty;
        private string CurrentMaXn = string.Empty;
        public string CurrentuserID;
        public string[] CurrentuserWorkPlace;
        public string[] CurrentarrayAllowNhom;
        public string CurrentPCWorkPlace;
        public int idMayXN = -1;
        public bool DaXacNhan = false;
        public string GenBatThuong
        {
            get
            {
                List<string> lstbatThuong = new List<string>();
                if (dtgKetQuaType.RowCount > 0)
                {
                    for (int i = 0; i < dtgKetQuaType.RowCount; i++)
                    {
                        var flag = int.Parse((dtgKetQuaType[colKqGen_Flat.Name, i].Value ?? "0").ToString());
                        if (flag > 1)
                        {
                            lstbatThuong.Add(dtgKetQuaType[colKqGen_MaGen.Name, i].Value.ToString());
                        }
                    }
                }
                return string.Join(",", lstbatThuong);
            }
        }
        private void btnThemGenotype_Click(object sender, EventArgs e)
        {
            if (cboTacNhan.SelectedIndex > -1)
            {
                var maTacNhan = cboTacNhan.SelectedValue.ToString();
                var ketquaDinhTinh = cboKetQua.Text;
                var ketquaDinhLuong = txtKetQuaDinhLuong.Text;

                CapNhatKetQua(maTacNhan, ketquaDinhTinh, ketquaDinhLuong, false);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn " + (_isTacnhan ? "tác nhân" : "GEN"));
            }
        }
        private bool _isTacnhan = false;
        public bool IsTacNhan
        {
            get
            {
                return _isTacnhan;
            }
            set
            {
                _isTacnhan = value;
                Check_HienThi();
            }
        }
        private void Check_HienThi()
        {
            ucGroupHeaderTacNhanChiTiet.GroupCaption = _isTacnhan ? LanguageExtension.GetResourceValueFromValue("TÁC NHÂN", LanguageExtension.AppLanguage) : "GEN";
            lblTacNhan.Text = _isTacnhan ? LanguageExtension.GetResourceValueFromValue("Tác nhân", LanguageExtension.AppLanguage) : "GEN";
            colKqGen_MaGen.HeaderText = _isTacnhan
                ? LanguageExtension.GetResourceValueFromValue("Mã tác nhân", LanguageExtension.AppLanguage)
                : LanguageExtension.GetResourceValueFromValue("Mã GEN", LanguageExtension.AppLanguage);
            lblDVTDinhLuong.Visible = txtDonViTinh.Visible = _isTacnhan;
        }
        private void btnXoaGenotype_Click(object sender, EventArgs e)
        {
            if (dtgKetQuaType.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa kết quả Type đang chọn?"))
                {
                    var maGen = dtgKetQuaType.CurrentRow.Cells[colKqGen_MaGen.Name].Value.ToString();
                    var maxn = dtgKetQuaType.CurrentRow.Cells[colMaXn.Name].Value.ToString();
                    _xetnghiem.Delete_SHPT_Gen(new KETQUA_CLS_XETNGHIEM_SHPT_GEN
                    {
                        Matiepnhan = CurrentMaTiepNhan
                    ,
                        Maxn = maxn
                    ,
                        Magen = maGen
                    });

                    Load_KetQua_Gen( CurrentuserID, CurrentuserWorkPlace
                        , CurrentarrayAllowNhom, CurrentMaXn, CurrentMaTiepNhan, txtDonViTinh.Text);
                }
            }
        }
        private void CapNhatKetQua(string maTacNhan, string ketquaDinhTinh, string ketquaDinhLuong, bool forUpdate)
        {
            if (!string.IsNullOrEmpty(CurrentMaXn) && !string.IsNullOrEmpty(maTacNhan))
            {
                string maTiepNhan = CurrentMaTiepNhan;
                var objPatient = _patient.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });

                var objChiDinh = new KETQUA_CLS_XETNGHIEM_SHPT_GEN();
                objChiDinh.Matiepnhan = CurrentMaTiepNhan;
                objChiDinh.Maxn = CurrentMaXn;
                objChiDinh.Magen = maTacNhan;
                objChiDinh.Ketquadinhluong = ketquaDinhLuong;
                objChiDinh.Ketquadinhtinh = ketquaDinhTinh;
                objChiDinh.Nguoinhap = CurrentuserID;
                objChiDinh.Nguoisua = CurrentuserID;

                bool allowUpdate = false;

                var isExists = _xetnghiem.Check_ExistsSHPT_Gen(objChiDinh.Matiepnhan, objChiDinh.Maxn, objChiDinh.Magen);
                if (isExists)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin tác nhân?"))
                    {
                        allowUpdate = true;
                    }
                }
                else
                    allowUpdate = true;

                if (allowUpdate)
                {
                    _xetnghiem.Insert_Update_SHPT_Gen(objChiDinh);

                }
                Load_KetQua_Gen(CurrentuserID, CurrentuserWorkPlace
                    , CurrentarrayAllowNhom, CurrentMaXn, CurrentMaTiepNhan, txtDonViTinh.Text);
            }
        }
        private void Load_TacNhan(string maXNCha)
        {
            if (!string.IsNullOrEmpty(maXNCha))
            {
                var data = _isSysConfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        data = WorkingServices.SearchResult_OnDatatable(data, string.Format("{0} =  '{1}' and {2} = '{3}' "
                            , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Loaimau), (_isTacnhan ? (int)EnumTestType.SHPTTacNhan : (int)EnumTestType.SHPTGen)
                            , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Macaptren), maXNCha));
                    }
                    ControlExtension.BindDataToCobobox(data, ref cboTacNhan, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Maxn), ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM>(x => x.Tenxn));
                }
            }
            else
            {
                cboTacNhan.DataSource = null;
            }
        }
        private void dtgKetQuaType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtgKetQuaType.RowCount > 0)
            {
                for (int i = 0; i < dtgKetQuaType.RowCount; i++)
                {
                    var flat = int.Parse(dtgKetQuaType[colKqGen_Flat.Name, i].Value.ToString());
                    FontStyle fs = new FontStyle();
                    var color = LabResultService.MauKQ(flat, ref fs);
                    Font font = new Font("Arial", 10, fs);
                    dtgKetQuaType[colKetQua_Gen.Name, i].Style.Font = font;
                    dtgKetQuaType[colKetQua_Gen.Name, i].Style.ForeColor = color;
                }
            }
        }

        private void dtgKetQuaType_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var maTacNhan = dtgKetQuaType[colKqGen_MaGen.Name, e.RowIndex].Value.ToString();
            var ketquaDinhTinh = dtgKetQuaType[colKetQua_Gen.Name, e.RowIndex].Value.ToString();
            var ketquaDinhLuong = dtgKetQuaType[colKetQua_DinhLuong.Name, e.RowIndex].Value.ToString();
            CapNhatKetQua(maTacNhan, ketquaDinhTinh, ketquaDinhLuong, true);
        }
        public void Load_KetQua_Gen(string userID
           , string[] userWorkPlace, string[] arrayAllowNhom, string maXNCha, string maTiepNhan, string donViTinh)
        {
            CurrentMaTiepNhan = maTiepNhan;
            CurrentMaXn = maXNCha;
            string CurrentuserID = userID;
            string[] CurrentuserWorkPlace = userWorkPlace;
            string[] CurrentarrayAllowNhom = arrayAllowNhom;
            txtDonViTinh.Text = donViTinh;
            if (!string.IsNullOrEmpty(maXNCha))
            {
                var dataChitiet_gen = _xetnghiem.Data_SHPT_Gen(maTiepNhan, maXNCha, string.Empty);
                ControlExtension.BindDataToGrid(dataChitiet_gen, ref dtgKetQuaType, ref bvKetQuaType);
                Load_TacNhan(maXNCha);
            }
            else
            {
                dtgKetQuaType.DataSource = null;
                bvKetQuaType.BindingSource = null;
            }

            btnThemGenotype.Enabled = !DaXacNhan;
            dtgKetQuaType.ReadOnly = DaXacNhan;
            btnXoaGenotype.Enabled = !DaXacNhan;
        }
        private void cboTacNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboKetQua);
        }

        private void cboKetQua_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtKetQuaDinhLuong);
        }

        private void txtKetQuaDinhLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnThemGenotype);
        }

        private void ucKetQua_SHPT_TacNhan_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                LanguageExtension.LocalizeForm(this, string.Empty);
        }
    }
}
