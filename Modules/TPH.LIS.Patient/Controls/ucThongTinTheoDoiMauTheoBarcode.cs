using System.Data;
using System.Windows.Forms;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucThongTinTheoDoiMauTheoBarcode : UserControl
    {
        public ucThongTinTheoDoiMauTheoBarcode()
        {
            InitializeComponent();
        }
        private DataTable _dataSource;
        public DataTable DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                Check_SetData();
            }
        }
        private void Check_SetData()
        {
            var totaHeight = 33 + 3;
            if (_dataSource != null)
            {
                if (_dataSource.Rows.Count > 0)
                {
                    lblBarcode.Text = _dataSource.Rows[0]["Seq"].ToString();

                    foreach (DataRow drSeq in _dataSource.Rows)
                    {
                        var uc = new ucThongTinTheoDoiMauTheoBoPhan();
                        var data = _dataSource.Clone();
                        data.ImportRow(drSeq);
                        uc.DataSource = data;
                        pnDSTheoDoi.Controls.Add(uc);
                        uc.Dock = DockStyle.Top;
                        uc.BringToFront();
                        uc.BorderStyle = BorderStyle.FixedSingle;
                        totaHeight += uc.Height;
                    }
                }
            }
            this.Height = totaHeight;
        }
    }
}
