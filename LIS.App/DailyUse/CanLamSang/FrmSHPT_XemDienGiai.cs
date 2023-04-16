using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmSHPT_XemDienGiai : Form
    {
        public FrmSHPT_XemDienGiai()
        {
            InitializeComponent();
        }
        public DataTable DataSource;

        private void SetDataToControl()
        {
            if(DataSource != null)
            {
                if(DataSource.Rows.Count > 0)
                {
                    var obj = (DM_DIENGIAKETQUAGEN)WorkingServices.Get_InfoForObject(new DM_DIENGIAKETQUAGEN(), DataSource.Rows[0]);
                    richGiaiThich.RtfText = obj.Giaithich;
                    richTuVan.RtfText = obj.Tuvan;
                    richPhuongPhap.RtfText = obj.Phuongphap;
                    richGioiHan.RtfText = obj.Gioihan;
                    richTaiLieu.RtfText = obj.Tailieuthamkhao;
                    pictureBox1.Image = obj.Hinhdiengiai1;
                    pictureBox2.Image = obj.Hinhdiengiai2;
                }
            }
        }

        private void FrmSHPT_XemDienGiai_Load(object sender, EventArgs e)
        {
            SetDataToControl();
        }
    }
}
