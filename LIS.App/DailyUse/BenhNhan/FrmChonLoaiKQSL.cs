using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Analyzer.Services;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmChonLoaiKQSL : Form
    {
        public FrmChonLoaiKQSL()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        public DM_LOAIIMPORT objReturn;
        public List<DM_LOAIIMPORT_MAPPING> lstObjMapping;
        public int IdMay = 0;
        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (cboLoaiImport.SelectedIndex > -1)
            {
                objReturn = new DM_LOAIIMPORT();
                objReturn = _systemConfigService.Get_Info_dm_loaiimport(cboLoaiImport.SelectedValue.ToString());
                lstObjMapping = new  List<DM_LOAIIMPORT_MAPPING>();
                lstObjMapping = _systemConfigService.Get_ListInfo_dm_loaiimport_mapping(cboLoaiImport.SelectedValue.ToString());
                if (lueLoaiMau.EditValue == null)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm");
                    return;
                }
                else
                    IdMay = int.Parse(lueLoaiMau.EditValue.ToString());
                this.Close();
            }
        }
        public void Load_MayXetNghiem()
        {
            if (CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem != null)
            {
                if (CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem.Count() > 0)
                {
                    string allowanalyzer = Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.PhanQuyenMayXetNghiem);
                    var mayXetNghiem = from selectData in _iAnalyzerConfig.Data_h_mayxetnghiem().AsEnumerable()
                                       where allowanalyzer.Contains(string.Format("'{0}'", selectData["idmay"].ToString()))
                                       select selectData;
                    if (mayXetNghiem.Any())
                    {
                        var data = mayXetNghiem.AsDataView().ToTable();

                        foreach (DataColumn dtc in data.Columns)
                        {
                            dtc.ColumnName = dtc.ColumnName.ToLower();
                        }
                        lueLoaiMau.Properties.DataSource = data;
                        lueLoaiMau.Properties.ValueMember = "idmay";
                        lueLoaiMau.Properties.DisplayMember = "tenmay";
                    }
                    else
                        lueLoaiMau.Properties.DataSource = null;
                }
            }
        }
        private void Load_DSImport()
        {
            var data = _systemConfigService.Data_dm_loaiimport(string.Empty);
            cboLoaiImport.DataSource = data;
            cboLoaiImport.ValueMember = "MaImPort";
            cboLoaiImport.DisplayMember = "TenImport";
            cboLoaiImport.SelectedIndex = -1;
        }
        private void FrmChonLoaiKQSL_Load(object sender, EventArgs e)
        {
            Load_DSImport();
            Load_MayXetNghiem();
        }

        private void lueLoaiMau_Properties_Popup(object sender, EventArgs e)
        {

        }

        private void lueLoaiMau_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
