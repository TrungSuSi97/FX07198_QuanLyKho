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
    public partial class Frm_DVKhac_KQCoHinh : FrmTemplate
    {
        public Frm_DVKhac_KQCoHinh()
        {
            InitializeComponent();
        }
        private string _MaTiepNhanCurrent = "";
        private string _MaDVKhacCurrent = "";
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        C_Config config = new C_Config();
        C_Patient_DichVu_Khac p_dvKhac = new C_Patient_DichVu_Khac();
        DataTable dtKetQua = new DataTable();
        Object[] objControl = new Object[20];
        private void CollectControls()
        {
            Set_BindingInfo();

            objControl[0] = rchResult1;
            objControl[1] = cboDoctorDo;
            objControl[2] = txtComment;
            objControl[3] = txtNote;
            objControl[4] = txtRecommend;
            objControl[5] = chkPrintedResult;
            objControl[6] = chkValidReult;
            objControl[7] = pbPic1;
            objControl[8] = pbPic2;
            objControl[9] = pbPic3;
            objControl[10] = pbPic4;
            objControl[11] = rchResult2;
            objControl[12] = rchResult3;
            objControl[13] = rchResult4;
            objControl[14] = txtCommenPic1;
            objControl[15] = txtCommenPic2;
            objControl[16] = txtCommenPic3;
            objControl[17] = txtCommenPic4;
            objControl[18] = txtResultmode;
            objControl[19] = txtReportMode;




        }
        private void Set_BindingInfo()
        {
            rchResult1.Tag = "KetQua1";
            rchResult2.Tag = "KetQua2";
            rchResult3.Tag = "KetQua3";
            rchResult4.Tag = "KetQua4";
            txtCommenPic1.Tag = "KetLuan1";
            txtCommenPic2.Tag = "KetLuan2";
            txtCommenPic3.Tag = "KetLuan3";
            txtCommenPic4.Tag = "KetLuan4";
            pbPic1.Tag = "HinhAnh1";
            pbPic2.Tag = "HinhAnh2";
            pbPic3.Tag = "HinhAnh3";
            pbPic4.Tag = "HinhAnh4";
            txtResultmode.Tag = "SoHinh";
            txtReportMode.Tag = "MauKQ";
            cboDoctorDo.Tag = "NguoiKy";
            txtComment.Tag = "KetLuan";
            txtNote.Tag = "GhiChu";
            txtRecommend.Tag = "DeNghi";
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

        private void txtResultmode_TextChanged(object sender, EventArgs e)
        {
            pnPicContent.Dock = DockStyle.Top;
            gbPic1.Dock = DockStyle.Top;
            gbPic1.Text = "Kết quả hình 1";
            gbPic1.Visible = false;
            gbPic2.Visible = false;
            gbPic3.Visible = false;
            gbPic4.Visible = false;

            if (txtResultmode.Text == "1" || txtResultmode.Text == "")
            {
                pnPicContent.Dock = DockStyle.Fill;
                gbPic1.Dock = DockStyle.Fill;
                gbPic1.Text = "";
                gbPic1.Visible = true;
            }
            else if (txtResultmode.Text == "2")
            {
                gbPic1.Visible = true;
                gbPic2.Visible = true;
            }
            else if (txtResultmode.Text == "3")
            {
                gbPic1.Visible = true;
                gbPic2.Visible = true;
                gbPic3.Visible = true;
            }
            else if (txtResultmode.Text == "4")
            {
                gbPic1.Visible = true;
                gbPic2.Visible = true;
                gbPic3.Visible = true;
                gbPic4.Visible = true;
            }
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
        private void chkPrintedResult_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AddImage(PictureBox pb)
        {
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            if (txtResultmode.Text != "1")
            {
                LabServices_Helper.Load_Image(pb, 320, 240);
            }
            else
            {
                LabServices_Helper.Load_Image(pb, 480, 360);
            }
        }

        private void RemoveImage(PictureBox pb)
        {
            pb.Image = null;
        }
        private void btnAddPic1_Click(object sender, EventArgs e)
        {
            AddImage(pbPic1);
        }

        private void btnAddPic2_Click(object sender, EventArgs e)
        {
            AddImage(pbPic2);
        }

        private void btnAddPic3_Click(object sender, EventArgs e)
        {
            AddImage(pbPic3);
        }

        private void btnAddPic4_Click(object sender, EventArgs e)
        {
            AddImage(pbPic4);
        }

        private void btnRemovePic1_Click(object sender, EventArgs e)
        {
            RemoveImage(pbPic1);
        }

        private void btnRemovePic2_Click(object sender, EventArgs e)
        {
            RemoveImage(pbPic2);
        }

        private void btnRemovePic3_Click(object sender, EventArgs e)
        {
            RemoveImage(pbPic3);
        }

        private void btnRemovePic4_Click(object sender, EventArgs e)
        {
            RemoveImage(pbPic4);
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
