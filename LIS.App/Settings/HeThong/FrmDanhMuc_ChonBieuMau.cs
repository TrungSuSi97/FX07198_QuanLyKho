using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using static TPH.LIS.Common.TemplateInput;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmDanhMuc_ChonBieuMau : FrmTemplate
    {
        public FrmDanhMuc_ChonBieuMau()
        {
            InitializeComponent();
        }
        DataTable dataBieuMau = new DataTable();
        public EnumTemplateInput[] LoaiBieuMau { get; set; }
        public string[,] noidungChon { get; set; }
        public bool FromResult = false;

        private readonly ISystemConfigService _iSystemConfig = new SystemConfigService();

        private void FrmDanhMuc_ChonBieuMau_Load(object sender, EventArgs e)
        {
            Load_DanhSachLoaiBieuMau();
            //  cboLoaiBieuMau.SelectedValue = (int)LoaiBieuMau;
            gbInfo.Visible = !FromResult;
            pnChon.Visible = FromResult;
            gvMau.OptionsSelection.MultiSelect = FromResult;
            Load_DanhSachBieuMau();
        }
        private void Load_DanhSachLoaiBieuMau()
        {
            cboLoaiBieuMau.SelectedIndexChanged -= cboLoaiBieuMau_SelectedIndexChanged;

            BindingSource bs = new BindingSource();
            bs.DataSource = ListTemplateInput();

            cboLoaiBieuMau.DataSource = bs;
            cboLoaiBieuMau.ValueMember = "TemplateInputID";
            cboLoaiBieuMau.DisplayMember = "TemplateInputName";
            cboLoaiBieuMau.SelectedIndex = -1;
            cboLoaiBieuMau.SelectedIndexChanged += cboLoaiBieuMau_SelectedIndexChanged;

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = ListTemplateInput();
        }
        private void Load_DanhSachBieuMau()
        {
            if (FromResult)
            {
                if (LoaiBieuMau.Length > 1)
                {
                    string[] strLoaiBieuMau = new string[LoaiBieuMau.Length];
                    for (int i = 0; i < LoaiBieuMau.Length; i++)
                    {
                        strLoaiBieuMau[i] = ((int)LoaiBieuMau[i]).ToString();
                    }
                    dataBieuMau = _iSystemConfig.Data_dm_mauchon(strLoaiBieuMau);
                    dataBieuMau.Columns.Add("NhomBieuMau", typeof(string));
                    foreach (DataRow dr in dataBieuMau.Rows)
                    {
                        var idTemplate = int.Parse(dr["IDLoaiMau"].ToString());
                        var lstNhom = ListTemplateInput().Where(x => x.TemplateInputID == idTemplate);
                        if(lstNhom.Any())
                        {
                            dr["NhomBieuMau"] = lstNhom.First().TemplateInputName;
                        }
                    }
                    dataBieuMau.AcceptChanges();
                    gcMau.DataSource = dataBieuMau;
                }
            }
            else
            {

                dataBieuMau = _iSystemConfig.Data_dm_mauchon(cboLoaiBieuMau.SelectedIndex > -1 ? new string[] { cboLoaiBieuMau.SelectedValue.ToString() } : new string[] { });
                dataBieuMau.Columns.Add("NhomBieuMau", typeof(string));
                foreach (DataRow dr in dataBieuMau.Rows)
                {
                    var idTemplate = int.Parse(dr["IDLoaiMau"].ToString());
                    var lstNhom = ListTemplateInput().Where(x => x.TemplateInputID == idTemplate);
                    if (lstNhom.Any())
                    {
                        dr["NhomBieuMau"] = lstNhom.First().TemplateInputName;
                    }

                }
                dataBieuMau.AcceptChanges();
                gcMau.DataSource = dataBieuMau;
            }

            gvMau.ExpandAllGroups();
        }

        private void cboLoaiBieuMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DanhSachBieuMau();
        }

        private void btnXoaMau_Click(object sender, EventArgs e)
        {
            if (gvMau.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa mẫu đang chọn ?"))
                {
                    foreach (int i in gvMau.GetSelectedRows())
                    {
                        if (gvMau.GetRowCellValue(i, colIDMau) != null)
                        {
                            _iSystemConfig.Delete_dm_mauchon(new DM_MAUCHON(int.Parse(gvMau.GetRowCellValue(i, colIDMau).ToString()), 0, string.Empty));
                        }
                    }
                    Load_DanhSachBieuMau();
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Không có mẫu được chọn!");
            }
        }

        private void btnThemMau_Click(object sender, EventArgs e)
        {
            if (cboLoaiBieuMau.SelectedIndex > -1)
            {
                var obj = new DM_MAUCHON();
                obj.Idloaimau = int.Parse(cboLoaiBieuMau.SelectedValue.ToString());
                _iSystemConfig.Insert_dm_mauchon(obj);
                Load_DanhSachBieuMau();
                var currentID = -1;
                var rowIndex = -1;
                if (gvMau.RowCount > 0)
                {
                    for (int i = 0; i < gvMau.RowCount; i++)
                    {
                        if (gvMau.GetRowCellValue(i, colIDMau) != null)
                        {
                            var checkVal = int.Parse(gvMau.GetRowCellValue(i, colIDMau).ToString());
                            if (checkVal > currentID)
                            {
                                currentID = checkVal;
                                rowIndex = i;
                            }
                        }
                    }
                    if (currentID > -1 && rowIndex > -1)
                    {
                        gvMau.FocusedRowHandle = rowIndex;
                    }
                }
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn loại biểu mẫu!");
                cboLoaiBieuMau.Focus();
            }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (gvMau.SelectedRowsCount >0)
            {
                DataTable dataCheked = dataBieuMau.Clone();
                foreach (int i in gvMau.GetSelectedRows())
                {
                    if (gvMau.GetRowCellValue(i, colIDMau) != null)
                    {
                        DataRow dr = dataCheked.NewRow();
                        dr["IDLoaiMau"] = int.Parse(gvMau.GetRowCellValue(i, colIDLoaiMau).ToString());
                        dr["NoiDung"] = gvMau.GetRowCellValue(i, colNoiDung).ToString();
                        dataCheked.Rows.Add(dr);
                    }
                }
                if (dataCheked.Rows.Count > 0)
                {
                    noidungChon = new string[dataCheked.Rows.Count, 2];
                    for (int a = 0; a < dataCheked.Rows.Count; a++)
                    {
                        noidungChon[a, 0] = dataCheked.Rows[a]["IdLoaiMau"].ToString();
                        noidungChon[a, 1] = dataCheked.Rows[a]["NoiDung"].ToString();
                    }
                    this.Close();
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Không có mẫu nào được chọn!");
                }
            }
        }
        private void gvMau_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

        }

        private void gvMau_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvMau.GetRowCellValue(e.FocusedRowHandle, colIDMau) != null)
            {
                ricKetLuan.Rtf = gvMau.GetRowCellValue(e.FocusedRowHandle, colNoiDung).ToString();
            }
        }

        private void btnLưuNoiDung_Click(object sender, EventArgs e)
        {
            if(gvMau.RowCount > 0)
            {
                var id = int.Parse(gvMau.GetFocusedRowCellValue(colIDMau).ToString());
                var idLoaiMau = gvMau.GetFocusedRowCellValue(colIDLoaiMau).ToString();
                var noidung = ricKetLuan.Rtf;
                var objUpdate = new DM_MAUCHON();
                objUpdate.Id = id;
                objUpdate.Idloaimau = int.Parse(idLoaiMau);
                objUpdate.Noidung = noidung;
                _iSystemConfig.Update_dm_mauchon(objUpdate);
                Load_DanhSachBieuMau();

                if (gvMau.RowCount > 0)
                {
                    for (int i = 0; i < gvMau.RowCount; i++)
                    {
                        if (gvMau.GetRowCellValue(i, colIDMau) != null)
                        {
                            var checkVal = int.Parse(gvMau.GetRowCellValue(i, colIDMau).ToString());
                            if (checkVal == id)
                            {
                                gvMau.FocusedRowHandle = i;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
