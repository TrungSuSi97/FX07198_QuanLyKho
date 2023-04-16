using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Patient.Services;

namespace TPH.LabIMS.ResultListScreen
{
    public partial class FrmList : Form
    {
      private IPatientInformationService _iPatient = new PatientInformationService();
        DataTable DataWating = new DataTable();

        public int limitRows = 10;
        int showing = 0;
        int currentDataMax = 0;
        public string KhoaPhong = string.Empty;
        public int waitForfrefresh = 15;
        public bool GiuBorder = false;
        public int soPhut = 5;
        int countingRefresh = 0;
        int stepX = 5;
        int startX = 0;
        int startY = 0;
        public int CoChuDong = 30;
        public int RowHeight = 80;
        public Color MauChuDong = Color.White;
        public FrmList()
        {
            InitializeComponent();
            dtgThongTin.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 32, FontStyle.Bold);
            dtgThongTin.DefaultCellStyle.Font = new Font("Arial", CoChuDong, FontStyle.Bold);
            dtgThongTin.DefaultCellStyle.ForeColor = MauChuDong;
            dtgThongTin.RowTemplate.Height = RowHeight;
        }

        private void Load_DanhSachCho()
        {
            timerLoadList.Stop();
            timerLoadList.Enabled = false;
            if(showing >= currentDataMax)
            {
                if (countingRefresh >= waitForfrefresh)
                {
                    dtgThongTin.DataSource = null;
                    bvList.BindingSource = null;
                    DataWating = _iPatient.DanhSach_ChoTraKetQua(false, true, KhoaPhong, soPhut);
                    currentDataMax = DataWating.Rows.Count;
                    showing = 0;
                    SplitDataTable();
                    countingRefresh = 0;
                }
                else
                    countingRefresh++;
            }
            else if(showing < currentDataMax)
            {
                dtgThongTin.DataSource = null;
                bvList.BindingSource = null;
                SplitDataTable();
            }
            timerLoadList.Enabled = true;
            timerLoadList.Start();
           
        }
        private void SplitDataTable()
        {
            if (currentDataMax > 0)
            {
                int countingCut = 0;
                DataTable dataShow = DataWating.Clone();
                for (int i = 0; i < DataWating.Rows.Count; i++)
                {
                    if (countingCut < limitRows)
                    {
                        dataShow.ImportRow(DataWating.Rows[i]);
                        DataWating.Rows.RemoveAt(i);
                        i--;
                        countingCut++;
                    }
                }

                currentDataMax = DataWating.Rows.Count;
                dtgThongTin.AutoGenerateColumns = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = dataShow;
                bvList.BindingSource = bs;
                dtgThongTin.DataSource = bs;
            }
        }

        private void Check_MoveFocus()
        {
            if(bvList.BindingSource == null)
            {
                Load_DanhSachCho();
            }
            else if (bvList.BindingSource.Position < bvList.BindingSource.Count - 1)
            {
                bvList.BindingSource.MoveNext();
            }
            else
            {
                Load_DanhSachCho();
            }
        }

        private void FrmList_Load(object sender, EventArgs e)
        {
            dtgThongTin.DefaultCellStyle.Font = new Font("Arial", CoChuDong, FontStyle.Bold);
            dtgThongTin.DefaultCellStyle.ForeColor = MauChuDong;
        }

        private void FrmList_Shown(object sender, EventArgs e)
        {
            timerLoadList.Tick += TimerLoadList_Tick;
            timerLoadList.Enabled = true;
            timerLoadList.Start();
            if(string.IsNullOrEmpty(lblKhoa_KhuVuc.Text))
            {
                lblTenBenhVien.Height += lblKhoa_KhuVuc.Height;
                lblKhoa_KhuVuc.Visible = false;
            }
            if(pnThongBao.Visible)
            {
                startX = pnThongBao.Width;
                startY = 4;
                lblThongBao.Location = new Point(startX, startY);
                timerThongBao.Enabled = true;
                timerThongBao.Start();
            }
            if (Screen.AllScreens.Length > 1)
            {
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
                if (GiuBorder)
                {
                    this.Text = string.Empty;
                    this.ControlBox = false;
                    this.FormBorderStyle = FormBorderStyle.FixedDialog;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                }
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void TimerLoadList_Tick(object sender, EventArgs e)
        {
            Check_MoveFocus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = string.Format("{0:dd/MM/yyyy}{1}{0:HH:mm:ss}", DateTime.Now, Environment.NewLine);
        }

        private void FrmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            timerLoadList.Stop();
            timerLoadList.Enabled = false;
        }

        private void timerThongBao_Tick(object sender, EventArgs e)
        {
            if((startX + lblThongBao.Width) <= 0)
            {
                startX = pnThongBao.Width;
            }
            startX -= stepX;
            lblThongBao.Location = new Point(startX, startY);
        }
    }
}
