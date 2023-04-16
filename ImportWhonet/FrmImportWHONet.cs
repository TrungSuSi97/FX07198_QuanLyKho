using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
namespace ImportWhonet
{
    public partial class frmImportWHONet : Form
    {
        public frmImportWHONet()
        {
            InitializeComponent();
        }
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
        private void btnImport_Click(object sender, EventArgs e)
        {
            _bacteriumAntibioticService.ImportWHONet();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();
            diag.Filter = "WHONetDataFile|*.*";
            diag.Title = "TPH.LabIMS - Open WHONet datafile";

            var diagResult = diag.ShowDialog();

            if (diagResult == DialogResult.OK)
            {
                var fileName = diag.FileName;
                txtExportPath.Text = fileName;
            }
        }
    }
}
