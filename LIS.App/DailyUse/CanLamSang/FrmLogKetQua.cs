using System;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmLogKetQua : FrmTemplate
    {
        public FrmLogKetQua()
        {
            InitializeComponent();
        }
        public string MaTiepNhan = string.Empty;
        public string MaXn = string.Empty;
        public DateTime FromDate = DateTime.Now;
        public DateTime ToDate = DateTime.Now;
        public int Load_Log()
        {
            ucLogCLS_KetQua_XetNghiem1.MaTiepNhan = MaTiepNhan;
            ucLogCLS_KetQua_XetNghiem1.MaXN = MaXn;
            ucLogCLS_KetQua_XetNghiem1.FromDate = FromDate;
            ucLogCLS_KetQua_XetNghiem1.ToDate = ToDate;
            return ucLogCLS_KetQua_XetNghiem1.Get_LogList();
        }

        private void FrmLogKetQua_Load(object sender, EventArgs e)
        {

        }
    }
}
