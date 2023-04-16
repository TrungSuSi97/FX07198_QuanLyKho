using System;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Controls;
using TPH.LIS.Configuration.Repositories.SystemConfig;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmLuuMau : FrmTemplate
    {
        public FrmLuuMau()
        {
            InitializeComponent();
        }
        public int SoLuongX = 10;
        public int SoLuongY = 10;
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        private readonly ISystemConfigService iSysconfig = new SystemConfigService();
        private void FrmLuuMau_Load(object sender, EventArgs e)
        {
            ucSearchLookupEditor_NhomCLSXetNghiem1.Load_DanhMucNhomDichVu();
            ucSearchLookupEditor_NhomCLSXetNghiem1.NhomXetNghiem_EditValueChanged += UcSearchLookupEditor_NhomCLSXetNghiem1_NhomXetNghiem_EditValueChanged;
            ucSearchLookupEditor_DanhSachTuLuuMau1.Load_CauHinh();
            ucSearchLookupEditor_DanhSachTuLuuMau1.EditValueChange += UcSearchLookupEditor_DanhSachTuLuuMau1_EditValueChange;
            txtRackSize.Text = String.Empty;
            ucSearchLookupEditor_DanhSachKhayLuuMau1.EditValueChange += UcSearchLookupEditor_DanhSachKhayLuuMau1_EditValueChange;
            ucRackLuuMau1.UserId = CommonAppVarsAndFunctions.UserID;
        }

        private void UcSearchLookupEditor_DanhSachKhayLuuMau1_EditValueChange(object sender, EventArgs e)
        {
            txtRackSize.Text = String.Empty;
            if(ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue != null)
            {
                int ngang = ucSearchLookupEditor_DanhSachKhayLuuMau1.GetNgang();
                int doc = ucSearchLookupEditor_DanhSachKhayLuuMau1.GetDoc();
                if(ngang > 0 && doc > 0)
                {
                    txtRackSize.Text = String.Format("{0}x{1}", ngang, doc);
                }
            }
        }

        private void UcSearchLookupEditor_DanhSachTuLuuMau1_EditValueChange(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue != null)
            {
                ucSearchLookupEditor_DanhSachKhayLuuMau1.Load_CauHinh(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString());
            }
            else
                ucSearchLookupEditor_DanhSachKhayLuuMau1.Load_CauHinh(String.Empty);

        }

        private void UcSearchLookupEditor_NhomCLSXetNghiem1_NhomXetNghiem_EditValueChanged(object sender, EventArgs e)
        {
            lblMauOngMau.BackColor = ucSearchLookupEditor_NhomCLSXetNghiem1.MauOngMau;
        }


        private void numViTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtBarcode);
        }
        private void btnThemMau_Click(object sender, EventArgs e)
        {
            ThemMau();
        }
        private void ThemMau()
        {
            if (ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue != null
                && ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue != null
                && !string.IsNullOrEmpty(txtBarcode.Text))
            {
                if (KiemTraVitri())
                {
                    var barcode = txtBarcode.Text;
                    if (!WorkingServices.IsNumeric(txtBarcode.Text))
                        barcode = WorkingServices.SplitSampleCode(barcode);
                    var maLoaiMau = (ucSearchLookupEditor_NhomCLSXetNghiem1.SelectedValue == null ? String.Empty : Chon_LoaiMauChinh(barcode, ucSearchLookupEditor_NhomCLSXetNghiem1.SelectedValue.ToString()));
                    if (string.IsNullOrEmpty(maLoaiMau))
                    {
                        lblMauOngMau.BackColor = Color.Empty;
                        if (!WorkingServices.IsNumeric(txtBarcode.Text.Substring(txtBarcode.Text.Length - 1, 1)))
                        {
                            maLoaiMau = txtBarcode.Text.Substring(txtBarcode.Text.Length - 1, 1);
                            var datamau = iSysconfig.MauOngMauTheoLoaiMau(maLoaiMau);
                            if (!string.IsNullOrEmpty(datamau))
                            {
                                var arr = datamau.Split(',');
                                if (arr.Length == 3)
                                {
                                    lblMauOngMau.BackColor = Color.FromArgb(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]));
                                }
                            }
                        }
                    }
                    var obj = new ArchiveSample();
                    obj.Mahopluumau = ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue.ToString();
                    obj.Masotuluu = ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString();
                    obj.Pcthuchien = Environment.MachineName;
                    obj.Nguoiluu = CommonAppVarsAndFunctions.UserID;
                    obj.Barcode = txtBarcode.Text;
                    obj.Vitri = (int)numViTri.Value;
                    obj.Maongmau = maLoaiMau;
                    if (!lblMauOngMau.BackColor.IsEmpty)
                        obj.Mauongmau = string.Format("{0},{1},{2}", lblMauOngMau.BackColor.R, lblMauOngMau.BackColor.G, lblMauOngMau.BackColor.B);
                    ucRackLuuMau1.ThemOngMau(obj);
                    if (numViTri.Value < (SoLuongX * SoLuongY))
                        numViTri.Value = numViTri.Value + 1;
                    txtBarcode.Focus();
                    txtBarcode.Text = string.Empty;
                }
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy nhập đủ thông tin: (Tủ lưu, Hộp lưu, Barcode)");
        }
        public string Chon_LoaiMauChinh(string barcode, string manhom)
        {
            var data = iPatient.OngMau_LoaiMauChinh(barcode, manhom);
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    if (data.Rows.Count == 1)
                    {
                        return data.Rows[0]["MaLoaiMauChinh"].ToString();
                    }
                    else
                    {
                        var f = new FrmChonLoaiMauLuu();
                        f.SetDataSource = data;
                        f.ShowDialog();
                        return f.MaLoaiChinh;
                    }
                }
            }
            CustomMessageBox.MSG_Information_OK("Không tìm thấy thông tin loại ống mẫu.");
            return string.Empty;
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && chkTuThemKhiQuetCode.Checked)
            {
                ThemMau();
                e.Handled = true;
            }
        }

        private void btnThemKhayMoi_Click(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue == null
                || ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue == null)
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập đủ thông tin: (Tủ lưu, Hộp lưu)!");
            }
            else if (!string.IsNullOrEmpty(txtBarcode.Text.Trim()))
            {
                CustomMessageBox.MSG_Information_OK("Vui lòng nhập khay mới trước khi quét Barcode!");
            }
            else
            {
                var kicthuoRack = txtRackSize.Text.Split('x');
                SoLuongX = int.Parse(kicthuoRack[0]);
                SoLuongY = int.Parse(kicthuoRack[1]);
                ucRackLuuMau1.SoLuongX = SoLuongX;
                ucRackLuuMau1.SoLuongY = SoLuongY;
                var vitri = ucRackLuuMau1.SetDanhSachOngMau(ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString(), ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue.ToString());
                numViTri.Value = (vitri + 1 > numViTri.Maximum ? 1 : vitri + 1);
                ucSearchLookupEditor_DanhSachTuLuuMau1.Enabled = false;
                ucSearchLookupEditor_DanhSachKhayLuuMau1.Enabled = false;
                txtRackSize.Enabled = false;
                txtBarcode.BackColor = Color.Yellow;
                txtBarcode.Focus();
                txtBarcode.Text = string.Empty;
            }
        }
        private bool KiemTraVitri()
        {
            var data = iPatient.ChiTiet_OngMauLuuTheoViTri(ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue.ToString(), ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString(), (int)numViTri.Value);
            if (data != null)
            {
                if (data.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    var barcode = data.Rows[0]["Barcode"].ToString();
                    CustomMessageBox.MSG_Information_OK(string.Format("Vị trí {0} trên họp {1} - tủ lưu {2} \nđã lưu trữ cho barcode code: {3}", (int)numViTri.Value
                        , ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue.ToString(), ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue.ToString(), barcode));
                    return false;
                }
            }
            return false;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            ucSearchLookupEditor_DanhSachTuLuuMau1.Enabled = true;
            ucSearchLookupEditor_DanhSachKhayLuuMau1.Enabled = true;
            txtRackSize.Enabled = true;
            ucSearchLookupEditor_DanhSachTuLuuMau1.SelectedValue = null;
            ucSearchLookupEditor_DanhSachKhayLuuMau1.SelectedValue = null;
            numViTri.Value = 1;
            txtBarcode.Text = string.Empty;
            txtBarcode.BackColor = Color.Empty;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var f = new FrmLuuMau_TimKiem();
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
