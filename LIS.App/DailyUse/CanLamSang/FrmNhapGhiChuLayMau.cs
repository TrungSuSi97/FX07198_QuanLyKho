using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Controls;
using TPH.LIS.Common.Controls;
using TPH.LIS.Patient.Services;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmNhapGhiChuLayMau : FrmTemplate
    {
        public FrmNhapGhiChuLayMau()
        {
            InitializeComponent();
        }
        private readonly IPatientInformationService ipatient = new PatientInformationService();
        public List<string> lstDSXetNghiem { get; set; }
        public string MaTiepNhan { get; set; }
        public string NoiDung { get { return txtNoiDung.TextValue; } set { txtNoiDung.TextValue = value; } }    
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoiDung.TextValue))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetNo("Xóa các ghi chú đang chọn?"))
                    return;
                foreach (var item in lstDSXetNghiem)
                {
                    ipatient.Delete_xetnghiem_ghichu_laymau(new Patient.Model.XETNGHIEM_GHICHU_LAYMAU()
                    {
                        Matiepnhan = MaTiepNhan,
                        Maxn = item,
                        Noidungghichu = txtNoiDung.TextValue,
                        Nguoighichu = CommonAppVarsAndFunctions.UserID,
                        Pcthuchien = Environment.MachineName
                    });
                }
            }
            else
            {
                foreach (var item in lstDSXetNghiem)
                {
                    ipatient.Insert_xetnghiem_ghichu_laymau(new Patient.Model.XETNGHIEM_GHICHU_LAYMAU()
                    {
                        Matiepnhan = MaTiepNhan,
                        Maxn = item,
                        Noidungghichu = txtNoiDung.TextValue,
                        Nguoighichu = CommonAppVarsAndFunctions.UserID,
                        Pcthuchien = Environment.MachineName
                    });
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void FrmXacNhanCapNhatKetQua_Load(object sender, EventArgs e)
        {

        }

        private void FrmXacNhanCapNhatKetQua_Shown(object sender, EventArgs e)
        {
            this.Height -= 25;
            txtNoiDung.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
