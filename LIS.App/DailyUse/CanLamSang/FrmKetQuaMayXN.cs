using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.User.Constants;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmKetQuaMayXN : FrmTemplate
    {
        public FrmKetQuaMayXN()
        {
            InitializeComponent();
        }

        private void FrmKetQuaMayXN_Load(object sender, EventArgs e)
        {
            analyzerResult1.UserId = CommonAppVarsAndFunctions.UserID;
            analyzerResult1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            analyzerResult1.PcWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
            analyzerResult1.ClsXetNghiemDinhDangKetqua = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangKetqua;
            analyzerResult1.ClsXetNghiemKieuLayKetQuaMay = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuLayKetQuaMay;
            analyzerResult1.suDungLayTuDong = false;
            analyzerResult1.Load_CauHinh(CommonAppVarsAndFunctions.ServerTime);
            analyzerResult1.gioiHanBarcode = int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode);

            ucLayKetQuaMayTuDong1.UserId = CommonAppVarsAndFunctions.UserID;
            ucLayKetQuaMayTuDong1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucLayKetQuaMayTuDong1.PCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
            ucLayKetQuaMayTuDong1.clsXetNghiemDinhDangKetqua = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangKetqua;
            ucLayKetQuaMayTuDong1.ClsXetNghiemKieuLayKetQuaMay = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKieuLayKetQuaMay;
            ucLayKetQuaMayTuDong1.Load_Config();

            ucPCUpdateResultConfig1.UserId = CommonAppVarsAndFunctions.UserID;
            ucPCUpdateResultConfig1.arrAnalyzerAllow = CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem;
            ucPCUpdateResultConfig1.PCWorkPlace = CommonAppVarsAndFunctions.PCWorkPlace;
            ucPCUpdateResultConfig1.LoadConfig();

            if (!CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(
               CommonAppVarsAndFunctions.PhanQuyenQuanLy,
                UserConstant.PermissionManagementOfAnalyzerTest))
            {
                tabControl1.TabPages.Remove(tabPage3);
            }
        }

        private void FrmKetQuaMayXN_FormClosing(object sender, FormClosingEventArgs e)
        {
            analyzerResult1.StopTimer();
        }
    }
}
