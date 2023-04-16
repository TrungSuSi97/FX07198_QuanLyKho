using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucCoCanhBaoTheoMay : UserControl
    {
        public ucCoCanhBaoTheoMay()
        {
            InitializeComponent();
        }
        public DataTable DataSource
        {
            get { return dtgContent.DataSource == null ? new DataTable() : (DataTable)dtgContent.DataSource; }
            set {

                dtgContent.AutoGenerateColumns = false;
                dtgContent.DataSource = value;
                if (value.Rows.Count > 0)
                {
                    lblThongTinMay.Text = string.Format("{0}",value.Rows[0]["tenmay"].ToString());
                    for(int i=0; i< dtgContent.RowCount; i++)
                    {
                        dtgContent[colID.Name, i].Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dtgContent.Refresh();
                  //  dtgContent.CurrentCell = dtgContent[colNoiDung.Name, 0];
                }
                else
                    lblThongTinMay.Text = string.Empty;
                this.Height = (dtgContent.RowCount * 25) + 45;
            }
        }
    }
}
