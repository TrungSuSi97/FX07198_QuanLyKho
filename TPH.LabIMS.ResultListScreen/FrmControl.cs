using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;

namespace TPH.LabIMS.ResultListScreen
{
    public partial class FrmControl : Form
    {
        public FrmControl()
        {
            InitializeComponent();
        }

        private readonly RegistryExtension _registryExtension = new RegistryExtension(0,"TPH.LabIMS\\ShowResultList");
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        private void chkTaCaKhoa_CheckedChanged(object sender, EventArgs e)
        {
            txtKhoa.Enabled = chkTaCaKhoa.Checked;
            cboKhoa.Enabled = !chkTaCaKhoa.Checked;
            if (chkTaCaKhoa.Checked)
                cboKhoa.SelectedIndex = -1;
        }
        private void Load_Config()
        {
            var objConfig = sysConfig.GetSystemConfigurationDetail();
            if (objConfig.ClsXetNghiemSuDungDanhSachChoTraKQ)
            {
                var data = sysConfig.Get_Header_Config("A");
                if (data.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(data.Rows[0]["tieude1"].ToString()))
                        txtTenBenhVien.Text = data.Rows[0]["tieude1"].ToString();
                    //if (!string.IsNullOrEmpty(data.Rows[0]["tieude2"].ToString()))
                    //    txtKhoa.Text = data.Rows[0]["tieude2"].ToString();
                    if (!string.IsNullOrEmpty(data.Rows[0]["reportlogo"].ToString()))
                        pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])data.Rows[0]["reportlogo"]));
                }
                var dataLocation = sysConfig.GetLocation(string.Empty, string.Empty);
                cboKhoa.DataSource = dataLocation;
                cboKhoa.ValueMember = "MaKhoaPhong";
                cboKhoa.DisplayMember = "TenKhoaPhong";
                cboKhoa.SelectedIndex = -1;

                var maKhoa = _registryExtension.ReadRegistry(ResultListScreenConstants.KhoaHienThi);

                if (!string.IsNullOrEmpty(maKhoa))
                {
                    chkTaCaKhoa.Checked = false;
                    cboKhoa.SelectedValue = maKhoa;
                }
                else
                {
                    chkTaCaKhoa.Checked = true;
                }

                var soDong = _registryExtension.ReadRegistry(ResultListScreenConstants.SoDongHienThi);
                if (!string.IsNullOrEmpty(soDong))
                    numSoDong.Value = int.Parse(soDong);

                chkHienThiThoiGian.Checked = _registryExtension.ReadRegistry(ResultListScreenConstants.HienThiGio) == "1";
                txtThongBao.Text = _registryExtension.ReadRegistry(ResultListScreenConstants.ThongBao);
                txtTenBang.Text = _registryExtension.ReadRegistry(ResultListScreenConstants.TenBangHienThi);
                txtKhoa.Text = _registryExtension.ReadRegistry(ResultListScreenConstants.TenKhoaHienThi);
                pnMauTenDV.BackColor = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuTieuDe)) ? System.Drawing.Color.Transparent : System.Drawing.ColorTranslator.FromHtml(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuTieuDe)));
                numCoChuBenhVien.Value = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuTieuDe)) ? 28 : int.Parse(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuTieuDe)));
                chkGiuBoder.Checked = _registryExtension.ReadRegistry(ResultListScreenConstants.GiuBorder) == "1";
                pnMauChuDong.BackColor = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuDong)) ? System.Drawing.Color.Transparent : System.Drawing.ColorTranslator.FromHtml(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuDong)));
                numCoChuDong.Value = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuDong)) ? 30 : int.Parse(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuDong)));
                numDoCaoCuaDong.Value = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.DoCaoDong)) ? 80 : int.Parse(_registryExtension.ReadRegistry(ResultListScreenConstants.DoCaoDong)));
                pnMauNenTieuDe.BackColor = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.MauNenTieuDe)) ? System.Drawing.Color.Transparent : System.Drawing.ColorTranslator.FromHtml(_registryExtension.ReadRegistry(ResultListScreenConstants.MauNenTieuDe)));

                numCoChuKhoa.Value = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuKhoa)) ? 25 : int.Parse(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuKhoa)));
                pnMauChuKhoa.BackColor = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuKhoa)) ? Color.Black : System.Drawing.ColorTranslator.FromHtml(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuKhoa)));

                numCoChuTenBang.Value = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuTenBang)) ? 25 : int.Parse(_registryExtension.ReadRegistry(ResultListScreenConstants.CoChuTenBang)));
                pnMauChuTenBang.BackColor = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuTenBang)) ? Color.Empty : System.Drawing.ColorTranslator.FromHtml(_registryExtension.ReadRegistry(ResultListScreenConstants.MauChuTenBang)));
                pnMauNenTenBang.BackColor = (string.IsNullOrEmpty(_registryExtension.ReadRegistry(ResultListScreenConstants.MauNenTenBang)) ? Color.FromArgb(42, 149, 219) : System.Drawing.ColorTranslator.FromHtml(_registryExtension.ReadRegistry(ResultListScreenConstants.MauNenTenBang)));
            }
            else
            {
                MessageBox.Show("Chức năng hiển thị danh sách chưa được kích hoạt!");
                this.Close();
            }
        }
        private void LuuCauHinh()
        {
            _registryExtension.WriteRegistry(ResultListScreenConstants.KhoaHienThi, cboKhoa.SelectedIndex > -1 ? cboKhoa.SelectedValue.ToString() : string.Empty);
            _registryExtension.WriteRegistry(ResultListScreenConstants.SoDongHienThi, numSoDong.Value.ToString());
            _registryExtension.WriteRegistry(ResultListScreenConstants.HienThiGio, chkHienThiThoiGian.Checked ? "1" : "0");
            _registryExtension.WriteRegistry(ResultListScreenConstants.ThongBao, txtThongBao.Text);
            _registryExtension.WriteRegistry(ResultListScreenConstants.TenBangHienThi, txtTenBang.Text);
            _registryExtension.WriteRegistry(ResultListScreenConstants.TenKhoaHienThi, txtKhoa.Text);
            _registryExtension.WriteRegistry(ResultListScreenConstants.MauChuTieuDe, System.Drawing.ColorTranslator.ToHtml(pnMauTenDV.BackColor));
            _registryExtension.WriteRegistry(ResultListScreenConstants.CoChuTieuDe, ((int)numCoChuBenhVien.Value).ToString());
            _registryExtension.WriteRegistry(ResultListScreenConstants.GiuBorder, chkGiuBoder.Checked ? "1" : "0");
            _registryExtension.WriteRegistry(ResultListScreenConstants.MauChuDong, System.Drawing.ColorTranslator.ToHtml(pnMauChuDong.BackColor));
            _registryExtension.WriteRegistry(ResultListScreenConstants.CoChuDong, ((int)numCoChuDong.Value).ToString());
            _registryExtension.WriteRegistry(ResultListScreenConstants.DoCaoDong, ((int)numDoCaoCuaDong.Value).ToString());
            _registryExtension.WriteRegistry(ResultListScreenConstants.MauNenTieuDe, System.Drawing.ColorTranslator.ToHtml(pnMauNenTieuDe.BackColor));

            _registryExtension.WriteRegistry(ResultListScreenConstants.CoChuKhoa, ((int)numCoChuKhoa.Value).ToString());
            _registryExtension.WriteRegistry(ResultListScreenConstants.MauChuKhoa, System.Drawing.ColorTranslator.ToHtml(pnMauChuKhoa.BackColor));

            _registryExtension.WriteRegistry(ResultListScreenConstants.CoChuTenBang, ((int)numCoChuTenBang.Value).ToString());
            _registryExtension.WriteRegistry(ResultListScreenConstants.MauChuTenBang, System.Drawing.ColorTranslator.ToHtml(pnMauChuTenBang.BackColor));
            _registryExtension.WriteRegistry(ResultListScreenConstants.MauNenTenBang, System.Drawing.ColorTranslator.ToHtml(pnMauNenTenBang.BackColor));
        }
        FrmList f = new FrmList();
        private void btnMoDanhSach_Click(object sender, EventArgs e)
        {
            LuuCauHinh();
            if (!f.IsDisposed)
                f.Close();
            f = 
                new FrmList { CoChuDong = (int)numCoChuDong.Value,
                MauChuDong = pnMauChuDong.BackColor, RowHeight = (int)numDoCaoCuaDong.Value
            };
            f.KhoaPhong = cboKhoa.SelectedIndex > -1 ? cboKhoa.SelectedValue.ToString() : string.Empty;
            f.limitRows = (int)numSoDong.Value;
            f.lblTime.Visible = chkHienThiThoiGian.Checked;
            f.lblDanhSachDaCoKetQua.Text = txtTenBang.Text;
            f.lblDanhSachDaCoKetQua.Font = new Font(f.lblDanhSachDaCoKetQua.Font.FontFamily, (int)numCoChuTenBang.Value, FontStyle.Bold);
            f.lblDanhSachDaCoKetQua.ForeColor = pnMauChuTenBang.BackColor;
            f.lblDanhSachDaCoKetQua.BackColor = pnMauNenTenBang.BackColor;
            f.lblTenBenhVien.Text = txtTenBenhVien.Text;
            f.lblTenBenhVien.ForeColor = pnMauTenDV.BackColor;
            f.lblTenBenhVien.Font = new Font(f.lblTenBenhVien.Font.FontFamily, (int)numCoChuBenhVien.Value, FontStyle.Bold);
            f.lblKhoa_KhuVuc.Text = (chkTaCaKhoa.Checked ? txtKhoa.Text : cboKhoa.Text);
            f.lblKhoa_KhuVuc.Font = new Font(f.lblKhoa_KhuVuc.Font.FontFamily, (int)numCoChuKhoa.Value, FontStyle.Bold);
            f.lblKhoa_KhuVuc.ForeColor = pnMauChuKhoa.BackColor;
            f.pnLogo.Image = pictureBox1.Image;
            f.waitForfrefresh = (int)numLamMoi.Value;
            f.pnThongBao.Visible = !string.IsNullOrEmpty(txtThongBao.Text.Trim());
            f.lblThongBao.Text = txtThongBao.Text;
            f.soPhut = (int)numSauKhiIn.Value;
            f.GiuBorder = chkGiuBoder.Checked;
            f.pnTitle.BackColor = pnMauNenTieuDe.BackColor;
            f.Show();
        }
        private void FrmControl_Load(object sender, EventArgs e)
        {
            Load_Config();
        }

        private void pnMauTenDV_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauTenDV.BackColor = colorPick.Color;
            }
        }

        private void pnMauChuDong_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauChuDong.BackColor = colorPick.Color;
            }
        }

        private void pnMauNenTieuDe_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauNenTieuDe.BackColor = colorPick.Color;
            }
        }

        private void pnMauChuKhoa_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnMauChuKhoa_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauChuKhoa.BackColor = colorPick.Color;
            }
        }

        private void pnMauChuTenBang_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauChuTenBang.BackColor = colorPick.Color;
            }
        }

        private void pnMauNenTenBang_Click(object sender, EventArgs e)
        {
            var colorPick = new ColorDialog();
            colorPick.ShowDialog();
            if (colorPick.Color != null)
            {
                pnMauNenTenBang.BackColor = colorPick.Color;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
