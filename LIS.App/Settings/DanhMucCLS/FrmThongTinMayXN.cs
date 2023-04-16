using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.Settings.DanhMucCLS
{
    public partial class FrmThongTinMayXN : FrmTemplate
    {
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private SqlDataAdapter daDsMay;
        private DataTable dataDsMayXN;

        public FrmThongTinMayXN()
        {
            InitializeComponent();
        }
        private void Load_DsMayXN()
        {
            _isSysConfig.Get_Data_h_mayxetnghiem_chitiet(dtgDSMayXN, bvDSMayXN, ref daDsMay, ref dataDsMayXN, string.Empty);
        }
        private void Load_DS_PhanLoaiMay()
        {
            colLoaiMayXn.DataSource = PhanLoaiMayXN.ListPhanLoaiMayXN().ToList();
            colLoaiMayXn.ValueMember = "IDLoai";
            colLoaiMayXn.DisplayMember = "TenPhanLoaiMay";

        }
        private void dtgDSMayXN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           // DataProvider.UpdateData(daDsMay, ref dataDsMayXN, string.Empty, string.Empty);
        }

        private void FrmThongTinMayXN_Load(object sender, EventArgs e)
        {
            Load_DS_PhanLoaiMay();

            Load_DsMayXN();
        }

        private void dtgDSMayXN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var idMayXN = dtgDSMayXN[colIdMayXn.Name, e.RowIndex].Value.ToString();
                var objMayXn = _isSysConfig.Get_Info_h_mayxetnghiem_chitiet(idMayXN);
                objMayXn.IdBHYT = dtgDSMayXN[colIDBHYT.Name, e.RowIndex].Value.ToString();
                objMayXn.Tenhienthi = dtgDSMayXN[colTenHienThi.Name, e.RowIndex].Value.ToString();
                objMayXn.Idphanloaimay = int.Parse(dtgDSMayXN[colLoaiMayXn.Name, e.RowIndex].Value.ToString());
                objMayXn.LuuKetQuaTrenIMS = bool.Parse(dtgDSMayXN[colLuuKetQuaTrenIMS.Name, e.RowIndex].Value.ToString());
                objMayXn.IsNotStaticByModules = bool.Parse(dtgDSMayXN[colisNotStaticByModules.Name, e.RowIndex].Value.ToString());
                objMayXn.GiaoThucBieuDo = dtgDSMayXN[colGiaoThucBieuDo.Name, e.RowIndex].Value.ToString();
                _isSysConfig.Update_h_mayxetnghiem_chitiet(objMayXn);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgDSMayXN);
        }
    }
}
