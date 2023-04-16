using System;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmCopyGiaDoiTuongDichVu : FrmTemplate
    {
        public FrmCopyGiaDoiTuongDichVu()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        public ServiceType svrType;
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cboTuDoiTuong.SelectedIndex > -1)
            {
                if (cboDenDoiTuong.SelectedIndex > -1)
                {
                    string tuDoiTuong = cboTuDoiTuong.SelectedValue.ToString();
                    string denDoituong = cboDenDoiTuong.SelectedValue.ToString();
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Chi tiết và giá sao chép từ đối tượng: {0}"
                        + Environment.NewLine + "đến đối tượng: {1}", txtTuDoiTuong.Text, txtDenDoiTuong.Text)))
                    {
                        bool copyOk = false;
                        if (svrType == ServiceType.ClsXetNghiem)
                            copyOk = sysConfig.Copy_GiaDichVu_ChiTiet_XN(tuDoiTuong, denDoituong) > -1;
                        else if (svrType == ServiceType.ClsXNViSinh)
                            copyOk = sysConfig.Copy_GiaDichVu_ChiTiet_ViSinh(tuDoiTuong, denDoituong) > -1;

                        if (copyOk)
                        {
                            CustomMessageBox.MSG_Information_OK("Sao chép hoàn tất!");
                        }
                        else
                            CustomMessageBox.MSG_Information_OK("Quá trình sao chép bị lỗi!");
                    }

                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn đối tượng cần sao chép!");
                    cboDenDoiTuong.Focus();
                    cboDenDoiTuong.DroppedDown = true;
                }
            }
            else
            { 
                CustomMessageBox.MSG_Information_OK("Hãy chọn đối tượng được sao chép!");
                cboTuDoiTuong.Focus();
                cboTuDoiTuong.DroppedDown = true;
            }
        }

        private void Load_DSDoiTuong()
        {
            sysConfig.Get_DoiTuongDichVu(cboTuDoiTuong, txtTuDoiTuong);
            sysConfig.Get_DoiTuongDichVu(cboDenDoiTuong, txtDenDoiTuong);
        }

        private void FrmCopyGiaDoiTuongDichVu_Load(object sender, EventArgs e)
        {
            Load_DSDoiTuong();
        }
    }
}
