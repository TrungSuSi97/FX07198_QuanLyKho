using System.Data;
using System.Windows.Forms;
using TPH.Language;

namespace TPH.LIS.Statistic.Controls
{
    public partial class ucDashBoard_Department : UserControl
    {
        public ucDashBoard_Department()
        {
            InitializeComponent();
        }
        private DataTable dataSource = new DataTable();
        public string MaBoPhan = string.Empty;
        public string TenBoPhan
        {
           set { gbDetail.Text = value; }
            get { return gbDetail.Text; }
        }
        public DataTable SetDataSource
        {
            set
            {
                dataSource = value;
                if(dataSource !=null)
                {
                    if(dataSource.Rows.Count >0)
                    {
                        SetvalueToControl();
                    }
                    else
                    {
                        ClearAllControl();
                    }
                }
                else
                {
                    ClearAllControl();
                }
            }
        }
        private bool isLeftMode = true;
        public bool LeftMode
        {
            get { return isLeftMode; }
            set { isLeftMode = value; ChangeMode(); }
        }
        private void ChangeMode()
        {
            if(isLeftMode)
            {
                flowLayoutPanel1.Dock = DockStyle.Fill;
                this.Width = 325;
                this.Height = 430;
            }
            else
            {
                flowLayoutPanel1.Dock = DockStyle.None;
                this.Height = 165;
                this.Width = 967;
                flowLayoutPanel1.Width = 967;
                flowLayoutPanel1.Height = 165;
                flowLayoutPanel1.Anchor = AnchorStyles.Top;
            }
        }
        private void ClearAllControl()
        {
            txtChay2Chieu.Text = "0";
            txtYeuCauLayLai.Text = "0";
            txtCoKetQua.Text = "0";
            txtDaDuyet.Text = "0";
            txtDaIn.Text = "0";
            txtDaLayMau.Text = "0";
            txtDaNhanMau.Text = "0";
            txtGuiHTuDong.Text = "0";
           // txtTongSoBN.Text = "0";
        }
        private void SetvalueToControl()
        {
            foreach (DataRow dr in dataSource.Rows)
            {
                var dalaymau = dr["DaLayMau"].ToString();
                var daLayMauDu = dr["DaLayMauDu"].ToString();
                var daNhanMau = dr["DaNhanMau"].ToString();
                var daNhanMauDu = dr["DaNhanMauDu"].ToString();
                txtChay2Chieu.Text = dr["DaChayHaiChieu"].ToString();
                txtYeuCauLayLai.Text = dr["YeuCauLayLai"].ToString();
                txtCoKetQua.Text = dr["DaDuKetQua"].ToString();
                txtDaDuyet.Text = dr["DaDuyet"].ToString();
                txtDaIn.Text = dr["DaIn"].ToString();
                txtDaLayMau.Text = (int.Parse(dalaymau == "" ? "0" : dalaymau) + int.Parse(daLayMauDu == "" ? "0" : daLayMauDu)).ToString();
                txtDaNhanMau.Text = (int.Parse(daNhanMau == "" ? "0" : daNhanMau) + int.Parse(daNhanMauDu == "" ? "0" : daNhanMauDu)).ToString();
                txtGuiHTuDong.Text = dr["DaDownloadMiddleware"].ToString();
              //  txtTongSoBN.Text = dr["TongSoBenhNhan"].ToString(); ;
            }
        }

        private void ucDashBoard_Department_Load(object sender, System.EventArgs e)
        {
            LanguageExtension.LocalizeForm(this, string.Empty);
        }
        /*
m.[DaNhanMauDu]  m.[DaLayMauDu], m. [DaCoKetQua] , m. [DaDuyet] = t.SLDaDuyetKetQua
, m. [DaIn]  , m. [YeuCauLayLai]  , m. [DaNhanMau] , m. [DaLayMau] = t.DaLayMau
, m. [ChuaNhanMau], m. [ChuaLayMau]  , m. [DaDuKetQua] , m.DaChayHaiChieu, m.DaDownloadMiddleware 
, m.TongSoBenhNhan
 */
    }
}
