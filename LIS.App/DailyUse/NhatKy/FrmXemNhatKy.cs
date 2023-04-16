using System;
using System.Windows.Forms;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.App.DailyUse.BenhNhan.Logs;
namespace TPH.LIS.App.DailyUse.NhatKy
{
    public partial class FrmXemNhatKy : FrmTemplate
    {
        public FrmXemNhatKy()
        {
            InitializeComponent();
        }
        readonly IWorkingLogService _logService = new WorkingLogService();

        TabControl tabLogContent;
        private void Check_Add_ChangeTab(string tabname, string tabtitle)
        {
            if (tabLogContent == null)
            {
                tabLogContent = new TabControl();
                splitContainer1.Panel2.Controls.Add(tabLogContent);
                tabLogContent.Dock = DockStyle.Fill;
                tabLogContent.BringToFront();
                //tabLogContent.TabPages.RemoveAt(0);
            }

            foreach (TabPage tab in tabLogContent.TabPages)
            {
                if (tab.Name.Equals(tabname))
                {
                    tabLogContent.SelectedTab = tab;
                    return;
                }
            }

            TabPage tabNew = new TabPage();
            tabNew.Name = tabname;
            tabNew.Text = tabtitle;
            bool allowAdd = false;
            switch (tabname)
            {
                case "nodThongTinBenhNhan":
                    ucLogThongTinHanhChinh ucThongTinHanhChinh = new ucLogThongTinHanhChinh();
                    tabNew.Controls.Add(ucThongTinHanhChinh);
                    ucThongTinHanhChinh.Dock = DockStyle.Fill;
                    allowAdd = true;
                    break;
                case "nodKetQuaXeNghiem":
                    ucLogCLS_KetQua_XetNghiem ucKetQuaXetNghiem = new ucLogCLS_KetQua_XetNghiem();
                    tabNew.Controls.Add(ucKetQuaXetNghiem);
                    ucKetQuaXetNghiem.Dock = DockStyle.Fill;
                    allowAdd = true;
                    break;
                case "nodDoiSIDKetQuaMay":
                    ucLogCLS_KetQuaMay_DoiSID ucDoiSidKetQuaMay = new ucLogCLS_KetQuaMay_DoiSID();
                    tabNew.Controls.Add(ucDoiSidKetQuaMay);
                    ucDoiSidKetQuaMay.Dock = DockStyle.Fill;
                    allowAdd = true;
                    break;
                case "nodNhatDangNhap":
                    ucLogLogin ucLogin = new ucLogLogin();
                    tabNew.Controls.Add(ucLogin);
                    ucLogin.Dock = DockStyle.Fill;
                    allowAdd = true;
                    break;
                case "nodKetQua_DanhSach":
                    ucLogCLS_KetQua_XetNghiem_DanhSach ucKQ_DS = new ucLogCLS_KetQua_XetNghiem_DanhSach();
                    tabNew.Controls.Add(ucKQ_DS);
                    ucKQ_DS.Dock = DockStyle.Fill;
                    allowAdd = true;
                    break;
                case "nodeNhatKyDanhMucXetNghiem":
                    ucNhatKyChinhSuaDanhMuc ucKQ_DM = new ucNhatKyChinhSuaDanhMuc();
                    ucKQ_DM.GetDataTable();
                    tabNew.Controls.Add(ucKQ_DM);
                    ucKQ_DM.Dock = DockStyle.Fill;
                    allowAdd = true;
                    break;
                default:
                    break;

            }
            if (allowAdd)
            {
                tabLogContent.TabPages.Add(tabNew);
                tabLogContent.SelectedTab = tabNew;
            }
        }

        private void Get_Log(string nodeName)
        {
            //if (nodeName.Equals("nodThongTinBenhNhan"))
            //{
            //    DataTable dt = _logService.ReadLog(LogTableIds.Benhnhan_tiepnhan, LogActionId.AllAction, string.Empty,
            //        string.Empty, string.Empty, dt);
            //}
        }
        private void treLoaiNhatKy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Check_Add_ChangeTab(treLoaiNhatKy.SelectedNode.Name, treLoaiNhatKy.SelectedNode.Text);
        }

        private void FrmXemNhatKy_Load(object sender, EventArgs e)
        {
            treLoaiNhatKy.ExpandAll();
        }

    }
}
