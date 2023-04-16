using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Analyzer.Constants;
using TPH.LIS.Analyzer.Model;
using TPH.LIS.Analyzer.Repositories;
using TPH.LIS.Common;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucSamplePosition : UserControl
    {
        public ucSamplePosition()
        {
            InitializeComponent();
        }
        List<ucNumberPosOfAnalyzerPlate> lstPos = new List<ucNumberPosOfAnalyzerPlate>();
        IAnalyzerConfigRepository config = new AnalyzerConfigRepository();
        public string[] arrAnalyzerAllow = new string[] { };
        private DateTime _currentDate = DateTime.Now;
        private void ucSamplePosition_Load(object sender, EventArgs e)
        {

        }
        public void Load_CauHinh()
        {
            Load_MayXetNghiem();
            Load_DanhSach_XetNghiem();
        }
        public void Load_MayXetNghiem()
        {
            if (arrAnalyzerAllow != null)
            {
                if (arrAnalyzerAllow.Count() > 0)
                {
                    var mayXetNghiem = from selectData in config.Data_h_mayxetnghiem().AsEnumerable()
                                       where arrAnalyzerAllow.Contains(string.Format("{0}", selectData["idmay"].ToString()))
                                       select selectData;
                    if (mayXetNghiem.Any())
                    {
                        var data = mayXetNghiem.AsDataView().ToTable();

                        foreach (DataColumn dtc in data.Columns)
                        {
                            dtc.ColumnName = dtc.ColumnName.ToLower();
                        }
                        gcMayXN.DataSource = data;
                        gvMayXN.FocusedColumnChanged += GvMayXN_FocusedColumnChanged;
                        gvMayXN.FocusedRowChanged += GvMayXN_FocusedRowChanged;
                    }
                    else
                        gcMayXN.DataSource = null;
                }
            }
        }

        private void GvMayXN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSach_XetNghiem();
            Load_DanhSachTao();
        }

        private void GvMayXN_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            Load_DanhSach_XetNghiem();
        }

        public void Load_DanhSach_XetNghiem()
        {
            var idMay = string.Empty;
            if (gvMayXN.SelectedRowsCount > 0)
            {
                foreach (var item in gvMayXN.GetSelectedRows())
                {
                    if (gvMayXN.GetRowCellValue(item, colIDMayXn) != null)
                    {
                        idMay += (string.IsNullOrEmpty(idMay) ? "" : ",") + gvMayXN.GetRowCellValue(item, colIDMayXn).ToString();
                    }
                }
            }
            var data = config.Data_h_bangmamayxn_xetnghiem_forSelect(idMay, string.Empty, string.Empty, string.Empty);
            foreach (DataColumn dtc in data.Columns)
            {
                dtc.ColumnName = dtc.ColumnName.ToLower();
            }
            data.AcceptChanges();
            gcTestCode.DataSource = data;
            gvTestCode.ExpandAllGroups();
        }
        private void btnTaoPlate_Click(object sender, EventArgs e)
        {
            if (gvMayXN.FocusedRowHandle < 0)
                CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm.");
            else if (gvTestCode.FocusedRowHandle < 0)
                CustomMessageBox.MSG_Information_OK("Hãy chọn xét nghiệm");
            else if (string.IsNullOrEmpty(txtPlateCode.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập barcode của plate.");
            else if (string.IsNullOrEmpty(txtFirstNumberFix.Text))
                CustomMessageBox.MSG_Information_OK("Hãy nhập định giá trị đầu của vị trí.");
            else if (cboFirstRowOfNum.SelectedIndex == -1)
                CustomMessageBox.MSG_Information_OK("Hãy nhập định giá trị đầu của vị trí.");
            else
            {
                var numberOfColumn = 12;
                var numberOfRow = 8;

                var hRowStart = (int)Enum.Parse(typeof(GridColumnIndex), cboFirstRowOfNum.Text);
                var vColumnStart = (int)numFirstNumberFromNum.Value;
                int posCount = 0;
                var obj = new CHAYMAU_VITRIMAU();
                obj.Idlantao = config.ViTriChayMau_IdLanTao() + 1;
                obj.Insid = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                obj.Maxetnghiem = gvTestCode.GetFocusedRowCellValue(clTestCode).ToString();
                obj.Samples = (int)numSamples.Value;
                obj.Platecount = (int)numPlateNumber.Value;
                obj.Platecode = txtPlateCode.Text;
                obj.Ngaychaymau = dtpNgayTao.Value.Date;
                bool allowAdd = false;
                for (int r = 0; r < numberOfRow; r++)
                {
                    for (int i = 0; i < numberOfColumn; i++)
                    {
                        var horizontal = r + 1;
                        var vertical = i + 1;
                        obj.Runtype = (int)SampleRunType.None;
                        obj.Poscode = string.Empty;
                        obj.Vitringang = vertical;
                        obj.Vitridoc = horizontal;
                        obj.Valuedisplay = string.Empty;
                        if (!allowAdd)
                        {
                            if (horizontal >= hRowStart && vertical >= vColumnStart)
                            {
                                allowAdd = true;
                            }
                        }
                        if (allowAdd)
                        {
                            posCount++;
                            var posName = string.Format("{0}-{1}", txtFirstNumberFix.Text, (posCount < 10 ? "0" : "") + posCount.ToString());
                            obj.Poscode = posName;
                            obj.Runtype = (int)SampleRunType.Result;
                            obj.Valuedisplay = string.Format("{0}", (posCount < 10 ? "0" : "") + posCount.ToString());
                        }
                        config.Insert_ViTriChayMau_Plate(obj);
                    }
                }
                Load_DanhSachTao();
                if (gvDanhSachPlate.RowCount > 0)
                {
                    for (int a = 0; a < gvDanhSachPlate.RowCount; a++)
                    {
                        if (gvDanhSachPlate.GetRowCellValue(a, colIDLanTao) != null)
                        {
                            var idlanTao = gvDanhSachPlate.GetRowCellValue(a, colIDLanTao).ToString();
                            if (obj.Idlantao == int.Parse(idlanTao))
                            {
                                gvDanhSachPlate.FocusedRowHandle = a;
                                break;
                            }
                        }
                    }
                }
                cboviTri.Focus();
            }
        }
        private void Load_ChiTietPlate()
        {
            flpPlate.Controls.Clear();
            if (gvDanhSachPlate.GetFocusedRowCellValue(colIDLanTao) != null)
            {
                var data = config.Data_ViTriChayMau_Pos(int.Parse(gvDanhSachPlate.GetFocusedRowCellValue(colIDLanTao).ToString()));
                var dataPos = data.Clone();
                if (data.Rows.Count >0)
                {
                    var panel = new Panel();
                    panel.Size = pnMainPlate.Size;
                    pnMainPlate.Controls.Add(panel);
                    panel.Location = new Point(0, 0);
                    panel.BringToFront();
                    lstPos = new List<ucNumberPosOfAnalyzerPlate>();
                    foreach (DataRow dr in data.Rows)
                    {
                        var obj = config.GetInfo_VitriChayMua_Pos_ByRow(dr);
                        var uc = new ucNumberPosOfAnalyzerPlate();
                        uc.VPos = obj.Vitridoc;
                        uc.HPos = obj.Vitringang;
                        uc.SetPosInfo((obj.Valuedisplay ?? string.Empty).Trim(), (obj.Barcode ?? string.Empty).Trim());
                        uc.RunType = (SampleRunType)Enum.Parse(typeof(SampleRunType), obj.Runtype.ToString());
                        uc.Id = obj.Id;
                        uc.UpdateRuntype += UpdateRuntype;
                        uc.Name = obj.Id.ToString();
                        lstPos.Add(uc);
                        flpPlate.Controls.Add(lstPos[lstPos.Count - 1]);
                        if (uc.RunType == SampleRunType.Result)
                        {
                            dataPos.ImportRow(dr);
                        }
                    }
                    pnMainPlate.Controls.Remove(panel);
                    Count_SoluongMau();
                }
                cboviTri.DataSource = dataPos;
                cboviTri.ValueMember = "id";
                cboviTri.DisplayMember = "ValueDisplay";
            }
        }
        public void UpdateRuntype(object sender, EventArgs e)
        {
            var uc = (ucNumberPosOfAnalyzerPlate)sender;
            config.Update_ViTriChayMau_Pos_Runtype(new CHAYMAU_VITRIMAU() { Id = uc.Id, Runtype = (int)uc.RunType, Valuedisplay = uc.PosNo });
        }
        private void Load_DanhSachTao()
        {
            flpPlate.Controls.Clear();
            gvDanhSachPlate.FocusedColumnChanged -= GvDanhSachPlate_FocusedColumnChanged;
            gvDanhSachPlate.FocusedRowChanged -= GvDanhSachPlate_FocusedRowChanged;
            gvDanhSachPlate.FindFilterText = string.Empty;
            var Insid = int.Parse((gvMayXN.GetFocusedRowCellValue(colIDMayXn) ?? (object)"0").ToString());
            var Maxetnghiem = (gvTestCode.GetFocusedRowCellValue(clTestCode)??(object)string.Empty).ToString();
            var data = config.Data_VitriChayChaiMau_Plate(dtpDateSearch.Value.Date, dtpDateSearch.Value.Date, Insid, Maxetnghiem);
            gcDanhSachPlate.DataSource = data;
            gvDanhSachPlate.ExpandAllGroups();
            gvDanhSachPlate.FocusedColumnChanged += GvDanhSachPlate_FocusedColumnChanged;
            gvDanhSachPlate.FocusedRowChanged += GvDanhSachPlate_FocusedRowChanged;
        }

        private void GvDanhSachPlate_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDanhSachPlate.GetFocusedRowCellValue(colIDLanTao) != null)
            {
                Load_ChiTietPlate();
            }
        }

        private void GvDanhSachPlate_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (gvDanhSachPlate.GetFocusedRowCellValue(colIDLanTao) != null)
            {
                Load_ChiTietPlate();
            }
        }

        private void TaoPrfixPos()
        {
            txtFirstNumberFix.Text = string.Format("{0:ddMMyy}-P{1}", dtpNgayTao.Value, (int)numPlateNumber.Value);
        }
        private void btnTaoPrefix_Click(object sender, EventArgs e)
        {
            TaoPrfixPos();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtpNgayTao.Value = DateTime.Now;
        }

        private void numPlateNumber_ValueChanged(object sender, EventArgs e)
        {
            TaoPrfixPos();
        }

        private void txtFirstNumberFix_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuubarcode_Click(object sender, EventArgs e)
        {
            Update_Barcode();
        }
        private void Update_Barcode()
        {
            if (cboviTri.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(txtBarcodeXN.Text))
                {
                    var id = int.Parse(cboviTri.SelectedValue.ToString());
                    var barcode = txtBarcodeXN.Text;
                    var uc2 = flpPlate.Controls.Find(id.ToString(), true);
                    if (uc2 != null)
                    {
                        var u = (ucNumberPosOfAnalyzerPlate)uc2[0];
                        if(!string.IsNullOrEmpty(u.Barcode))
                        {
                            if(CustomMessageBox.MSG_Question_YesNo_GetNo("Vị trí đã có barcode.\nBạn có muốn thay thế barcode?"))
                            {
                                cboviTri.Focus();
                                return;
                            }
                        }
                        config.Update_ViTriChayMau_Pos(new CHAYMAU_VITRIMAU { Id = id, Barcode = barcode });
                        u.Barcode = barcode;
                        var uc = lstPos.Where(x => x.Id == id).First();
                        uc.Barcode = barcode;
                        Count_SoluongMau();
                        cboviTri.SelectedValue = id + 1;
                        txtBarcodeXN.Focus();
                        txtBarcodeXN.Text = string.Empty;
                    }
                }
            }
        }
        private void Count_SoluongMau()
        {
            var lstCount = lstPos.Where(x => !string.IsNullOrEmpty(x.Barcode));
            if(lstCount !=null)
            {
                numSamples.Value = lstCount.Count();
            }
        }
        private void btnLoadPlateList_Click(object sender, EventArgs e)
        {
            Load_DanhSachTao();
        }

        private void gvTestCode_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DanhSachTao();
        }

        private void txtBarcodeXN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Update_Barcode();
            }
        }

        private void txtPlateCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numPlateNumber);

        }

        private void numPlateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, cboFirstRowOfNum);
        }

        private void cboFirstRowOfNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, numFirstNumberFromNum);
        }

        private void numFirstNumberFromNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, btnTaoPrefix);
        }

        private void cboviTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.LeaveFocusNext(e, txtBarcodeXN);
        }
    }
}
