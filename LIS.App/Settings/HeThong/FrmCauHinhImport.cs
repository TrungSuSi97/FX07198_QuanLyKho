using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.Patient.Model;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinhImport : FrmTemplate
    {
        public FrmCauHinhImport()
        {
            InitializeComponent();
        }
        SqlDataAdapter daLoaiImport = new SqlDataAdapter();
        DataTable dtLoaiImport = new DataTable();
        SqlDataAdapter daMappingImport = new SqlDataAdapter();
        DataTable dtMappingImport = new DataTable();
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private void Load_DS_LoaiImport()
        {
            dtgLoaiImport.CellEnter -= DtgLoaiImport_CellEnter;
            _systemConfigService.Get_Data_dm_loaiimport(dtgLoaiImport, bvLoaiImport, ref daLoaiImport, ref dtLoaiImport, string.Empty);
            dtgLoaiImport.CellEnter += DtgLoaiImport_CellEnter;
            Load_Mapping();
        }

        private void DtgLoaiImport_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_Mapping();
        }

        private void Insert_LoaiImport()
        {
            if(!string.IsNullOrEmpty(txtLoaiImport_maimport.Text))
            {
                var obj = new DM_LOAIIMPORT();
                obj.Maimport = txtLoaiImport_maimport.Text;
                obj.Tenimport = txtLoaiImport_tenImport.Text;
                obj.Dongbatdau = (int)numLoaimport_DongDuLieu.Value;
                obj.Dongtieude = (int)numloaiImport_Header.Value;
                obj.Loaiimport = (int)numLoaimImport_IdLoai.Value;
                _systemConfigService.Insert_dm_loaiimport(obj);
                Load_DS_LoaiImport();
            }
        }
        private void Insert_mapping()
        {
            if (dtgLoaiImport.CurrentRow != null)
            {
                if(lueLoaiMau.EditValue != null)
                {
                    var obj = new DM_LOAIIMPORT_MAPPING();
                    obj.Maimport = dtgLoaiImport.CurrentRow.Cells[colLoaiImport_MaImPort.Name].Value.ToString();
                    obj.Liscolumn = lueLoaiMau.EditValue.ToString();
                    obj.Excelcolumn = txtMapping_Excel.Text;
                    obj.Loaixetnghiem = false;
                    obj.Ketluancuaxn = txtKetLuanCuaXN.Text;
                    obj.Maxnlis = txtMaXN.Text;
                    _systemConfigService.Insert_dm_loaiimport_mapping(obj);
                    Load_Mapping();
                }
            }
        }
        private void Load_Mapping()
        {
            dtgMapping.DataSource = null;
            bvMapping.BindingSource = null;
            if (dtgLoaiImport.CurrentRow != null)
            {
                var maloaiImport = dtgLoaiImport.CurrentRow.Cells[colLoaiImport_MaImPort.Name].Value.ToString();
                _systemConfigService.Get_Data_dm_loaiimport_mapping(dtgMapping, bvMapping, ref daMappingImport, ref dtMappingImport, maloaiImport, string.Empty);
            }
        }
        private void btnThemLoaiImport_Click(object sender, EventArgs e)
        {
            Insert_LoaiImport();
        }

        private void btnLoaiImport_DanhSach_Click(object sender, EventArgs e)
        {
            Load_DS_LoaiImport();
        }

        private void FrmCauHinhImport_Load(object sender, EventArgs e)
        {
            Load_DS_LoaiImport();
            var di = WorkingServices.GetPorpetiesAndDescriptionList(new PatientImportInfo());
            lueLoaiMau.Properties.DataSource = di.ToList();
            lueLoaiMau.Properties.ValueMember = "Key";
            lueLoaiMau.Properties.DisplayMember = "Value";
        }

        private void btnMappingDanhSach_Click(object sender, EventArgs e)
        {
            Load_Mapping();
        }

        private void dtgLoaiImport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dtUpdate = dtLoaiImport.GetChanges(DataRowState.Modified);
            var dtDelete = dtLoaiImport.GetChanges(DataRowState.Deleted);
            if (dtUpdate != null || dtDelete != null )
            {
                DataProvider.UpdateData(daLoaiImport, ref dtLoaiImport, dtgLoaiImport, string.Empty, string.Empty);
            }
        }

        private void btnLoaiImport_Xoa_Click(object sender, EventArgs e)
        {
            if (dtgLoaiImport.CurrentRow != null)
            {
                if (dtgMapping.RowCount == 0)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa dữ liệu đang chọn?"))
                    {
                        var maloaiImport = dtgLoaiImport.CurrentRow.Cells[colLoaiImport_MaImPort.Name].Value.ToString();
                        _systemConfigService.Delete_dm_loaiimport(new DM_LOAIIMPORT() { Maimport = maloaiImport });
                        Load_DS_LoaiImport();
                    }
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Hãy xóa mapping trước");
                }
            }
        }

        private void btnXoaMapping_Click(object sender, EventArgs e)
        {
            if (dtgMapping.CurrentRow != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa dữ liệu đang chọn?"))
                {
                    var maloaiReport = dtgMapping.CurrentRow.Cells[colMpping_maImport.Name].Value.ToString();
                    var maLis = dtgMapping.CurrentRow.Cells[colMapping_LisColumn.Name].Value.ToString();
                    var id = dtgMapping.CurrentRow.Cells[colMapping_Id.Name].Value.ToString();
                    _systemConfigService.Delete_dm_loaiimport_mapping(new DM_LOAIIMPORT_MAPPING() { Maimport = maloaiReport, Liscolumn = maLis, Id = int.Parse(id) });
                    Load_Mapping();
                }
            }
        }

        private void btnMapping_Them_Click(object sender, EventArgs e)
        {
            Insert_mapping();
        }

        private void lueLoaiMau_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lueLoaiMau_Properties_Popup(object sender, EventArgs e)
        {

        }

        private void dtgMapping_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dtUpdate = dtMappingImport.GetChanges(DataRowState.Modified);
            var dtDelete = dtMappingImport.GetChanges(DataRowState.Deleted);
            if (dtUpdate != null || dtDelete != null)
            {
                DataProvider.UpdateData(daMappingImport, ref dtMappingImport, dtgMapping, string.Empty, string.Empty);
            }
        }
    }
}
