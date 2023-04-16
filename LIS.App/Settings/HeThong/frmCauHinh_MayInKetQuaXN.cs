using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using static TPH.LIS.Common.RepportPaper;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class frmCauHinh_MayInKetQuaXN : FrmTemplate
    {
        private readonly ISystemConfigService _isyConfig = new SystemConfigService();
        public frmCauHinh_MayInKetQuaXN()
        {
            InitializeComponent();
        }
        int controlCount = 0;
        private ucPrinterForReport AddPrinterConfig()
        {
            controlCount++;
            var uc = new ucPrinterForReport();
            uc.Name = string.Format("ucPrinterForReport{0}", controlCount);
            pnUserControl.Controls.Add(uc);
            uc.Dock = DockStyle.Top;
            uc.Padding = new Padding(1);
            uc.ControlCount = controlCount;
            uc.ButtonDeleteClick += Uc_ButtonDeleteClick;
            uc.BringToFront();
            return uc;
        }

        private void Uc_ButtonDeleteClick(object sender, EventArgs e)
        {
            DeleteConfig();
        }

        private void Load_PrinterConfig()
        {
            var datacConfig = _isyConfig.Data_cauhinh_mayinketqua(Environment.MachineName, string.Empty, string.Empty);
            if (datacConfig.Rows.Count > 0)
            {
                foreach (DataRow dr in datacConfig.Rows)
                {
                    var uc = AddPrinterConfig();
                    var objOld = new  CAUHINH_MAYINKETQUA(txtPcName.Text, dr["PrinterName"].ToString(), dr["ReportTemplateID"].ToString(), dr["PaperSizeType"].ToString());
                    uc.PrinterName = objOld.Printername;
                    uc.ReportTemplate = objOld.Reporttemplateid;
                    uc.PaperSize = (ReportPaperSize)Enum.Parse(typeof(ReportPaperSize), objOld.Papersizetype);
                    uc.Tag = objOld;
                }
            }
        }
        private void SaveConfig()
        {
            if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Lưu lại cấu hình máy in?"))
            {
                foreach (Control ctrl in pnUserControl.Controls)
                {
                    if (ctrl is ucPrinterForReport)
                    {
                        var uc = (ucPrinterForReport)ctrl;
                        var obj = new CAUHINH_MAYINKETQUA(txtPcName.Text, uc.PrinterName, uc.ReportTemplate, uc.PaperSize.ToString());
                        if (string.IsNullOrEmpty(obj.Printername) || string.IsNullOrEmpty(obj.Reporttemplateid))
                            CustomMessageBox.MSG_Information_OK("Không thể lưu các cấu hình không có thông tin tên máy in và loại mẫu! ");
                        else
                        {
                            if (uc.Tag == null)
                                _isyConfig.Insert_cauhinh_mayinketqua(obj);
                            else
                                _isyConfig.Update_cauhinh_mayinketqua(obj, (CAUHINH_MAYINKETQUA)uc.Tag);
                        }
                    }
                }
                pnUserControl.Controls.Clear();
                controlCount = 0;
                Load_PrinterConfig();
            }
        }
        private void DeleteConfig()
        {
            foreach (Control ctrl in pnUserControl.Controls)
            {
                if (ctrl is ucPrinterForReport)
                {
                    var uc = (ucPrinterForReport)ctrl;
                    if (uc.isDelete && uc.Tag != null)
                        _isyConfig.Delete_cauhinh_mayinketqua((CAUHINH_MAYINKETQUA)uc.Tag);
                   //Tách ra có mục đích 
                    if (uc.isDelete)
                        pnUserControl.Controls.Remove(ctrl);
                }
            }
        }
        private void btnAddSetup_Click(object sender, EventArgs e)
        {
            AddPrinterConfig();
        }

        private void frmCauHinh_MayInKetQuaXN_Load(object sender, EventArgs e)
        {
            txtPcName.Text = Environment.MachineName;
            Load_PrinterConfig();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }
    }
}
