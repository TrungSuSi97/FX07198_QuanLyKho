using System;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinh_Config : FrmTemplate
    {
        public FrmCauHinh_Config()
        {
            InitializeComponent();
        }

        private void FrmCauHinh_Config_Load(object sender, EventArgs e)
        {
            ucConfig1.IsAdmin = CommonAppVarsAndFunctions.IsAdmin;
            ucConfig1.Load_ListConfigEnum();
          
        }
    }
}
