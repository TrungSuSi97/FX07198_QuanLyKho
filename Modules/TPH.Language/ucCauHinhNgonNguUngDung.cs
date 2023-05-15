using System;
using System.Windows.Forms;
using TPH.Language.Services;
using TPH.Language.Services.Impl;
using TPH.Language.Models;

namespace TPH.Language
{
    public partial class ucCauHinhNgonNguUngDung : UserControl
    {
        public ucCauHinhNgonNguUngDung()
        {
            InitializeComponent();
        }
        private readonly IAppLanguage ilanguage = new AppLanguage();
        public void Load_DanhSachTuNgu()
        {
            if (!DesignMode)
            {
                var data = ilanguage.Data_HeThong_NgonNgu(null, string.Empty);
                BindingSource bs = new BindingSource();
                bs.DataSource = data;
                dtgDanhSach.AutoGenerateColumns = false;
                bvDanhSach.BindingSource = bs;
                dtgDanhSach.DataSource = bs;
                TimCauHinh();
            }
        }
        private void ThemTuNgu()
        {
            if(!string.IsNullOrEmpty(txtNoiDung.Text))
            {
                if(!string.IsNullOrEmpty(txtId.Text))
                {
                    var obj = new HETHONG_NGONNGU()
                    {
                        Idtungu = txtId.Text,
                        Defaultlang = txtNoiDung.Text,
                        Vn = (chkTieNgVietBangMacDinh.Checked?txtNoiDung.Text: string.Empty)
                    };
                    ilanguage.Insert_HeThong_NgonNgu(obj);
                    Load_DanhSachTuNgu();
                    bvDanhSach.BindingSource.Position = bvDanhSach.BindingSource.Find(colIdTuNgu.DataPropertyName, txtId.Text);
                }
            }
        }
        private void XoaTuNgu()
        {
            if (dtgDanhSach.CurrentRow != null)
            {
                if (MessageBox.Show(LanguageExtension.GetResourceValueFromValue("Xóa từ ngữ đang chọn?", string.Empty), LanguageExtension.GetResourceValueFromValue("Xác nhận", string.Empty), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ilanguage.Delete_HeThong_NgonNgu(int.Parse(dtgDanhSach.CurrentRow.Cells[colId.Name].Value.ToString()));
                    Load_DanhSachTuNgu();
                }
            }
        }

        private void dtgDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >-1)
            {
                var objNew = new  HETHONG_NGONNGU();
                objNew.Id = int.Parse(dtgDanhSach[colId.Name, e.RowIndex].Value.ToString());
                objNew.Idtungu = dtgDanhSach[colIdTuNgu.Name, e.RowIndex].Value.ToString();
                objNew.Defaultlang = dtgDanhSach[colDefaultLang.Name, e.RowIndex].Value.ToString();
                objNew.Vn = dtgDanhSach[colVN.Name, e.RowIndex].Value.ToString();
                objNew.Eng = dtgDanhSach[colEN.Name, e.RowIndex].Value.ToString();
                ilanguage.Update_HeThong_NgonNgu(objNew);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemTuNgu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaTuNgu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhSachTuNgu();
        }

        private void txtNoiDung_KeyUp(object sender, KeyEventArgs e)
        {
            txtId.Text = LanguageExtension.GetID(txtNoiDung.Text);
        }

        private void txtTimNoiDung_TextChanged(object sender, EventArgs e)
        {
            TimCauHinh();
        }
        private void TimCauHinh()
        {
            if (bvDanhSach.BindingSource != null)
            {
                if (string.IsNullOrEmpty(txtTimNoiDung.Text))
                    bvDanhSach.BindingSource.Filter = string.Empty;
                else
                    bvDanhSach.BindingSource.Filter = string.Format("IdTuNgu = '{0}' or DefaultLang like '%{0}%' or VN like '%{0}%' or ENG like '%{0}%'", EscapeLikeValue(txtTimNoiDung.Text));
            }
        }
        private void txtNoiDung_Enter(object sender, EventArgs e)
        {
            txtNoiDung.SelectAll();
        }

        private void txtNoiDung_Click(object sender, EventArgs e)
        {
            txtNoiDung.SelectAll();
        }
        private string EscapeLikeValue(string valueWithoutWildcards)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void btnNapLaiThuVienheThong_Click(object sender, EventArgs e)
        {
            LanguageExtension.CheckGetConfig(true);
        }

        private void txtTimNoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimCauHinh();
                e.Handled = true;
            }
        }
    }
}
