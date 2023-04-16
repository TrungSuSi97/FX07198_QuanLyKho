using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.ThucThi.CanLamSang.DVKhac
{
    public partial class Frm_DVKhac_KQKhongHinh : FrmTemplate
    {
        public Frm_DVKhac_KQKhongHinh()
        {
            InitializeComponent();
        }
        private string _MaTiepNhanCurrent = "";
        private string _MaDVKhacCurrent = "";
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        C_Config config = new C_Config();
        C_Patient_DichVu_Khac p_dvKhac = new C_Patient_DichVu_Khac();
        DataTable dtKetQua = new DataTable();
        Object[] objControl = new Object[7];
        private void CollectControls()
        {
            Set_BindingInfo();

            objControl[0] = rchResult;
            objControl[1] = cboDoctorDo;
            objControl[2] = txtComment;
            objControl[3] = txtNote;
            objControl[4] = txtRecomend;
            objControl[5] = chkPrintedResult;
            objControl[6] = chkValidReult;
        }
        private void Set_BindingInfo()
        {
            rchResult.Tag = "KetQua";
            cboDoctorDo.Tag = "NguoiKy";
            txtComment.Tag = "KetLuan";
            txtNote.Tag = "GhiChu";
            txtRecomend.Tag = "DeNghi";
            chkPrintedResult.Tag = "DaInKQ";
            chkValidReult.Tag = "XacNhanKQ";
        }


        private void Frm_DVKhac_KQKhongHinh_Load(object sender, EventArgs e)
        {
            CollectControls();

            Load_Doctor();
        }
        private void Load_Doctor()
        {
            C_NguoiDung user = new C_NguoiDung();
            user.Get_UserSign(cboDoctorDo, ServiceType.DvKhac, " and d.MaNguoiDung not in ('admin')");
        }
        public void BindData(BindingSource bs)
        {
            LabServices_Helper.Bind_Data_ToControl(objControl, bs);
        }
        private void ClearControl()
        {
            LabServices_Helper.ResetControl(objControl);
        }
        public void Load_Result(string _MaTiepNhan, string _MaDVKhac)
        {
            _MaTiepNhanCurrent = _MaTiepNhan;
            _MaDVKhacCurrent = _MaDVKhac;
            dtKetQua = p_dvKhac.Load_ChiDinh_DVKhac(_MaTiepNhan, _MaDVKhac);
            BindingSource bs = new BindingSource();
            bs.DataSource = dtKetQua;
            BindData(bs);
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            Valid_inValidreslt();
        }
        private void Valid_inValidreslt()
        {
            bool allow = false;
            if (chkValidReult.Checked)
            {
                allow = CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy xác nhận kết quả ?");
            }
            else
            {
                allow = CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận kết quả ?");
            }
            if (allow)
            {
                string validText = (chkValidReult.Checked
                    ? Common.CommonConstant.InValid
                    : Common.CommonConstant.IsValided);
                p_dvKhac.XacNhan_KQ_DVKhac(_MaTiepNhanCurrent, _MaDVKhacCurrent, validText, !chkValidReult.Checked,
                    CommonAppVarsAndFunctions.UserID);
            }
        }
    }
}
