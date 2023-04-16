using System;
using System.Data;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.App.ThongKe
{
    public partial class FrmLuongTieuThu : FrmTemplate
    {
        public FrmLuongTieuThu()
        {
            InitializeComponent();
        }
        
        C_VatTu_Config vattu = new C_VatTu_Config();
        private void TKLuongTieuThu_HoaChatXN()
        {
            txtTenVatTu_XN.Focus();
            string strSQL = "";
            strSQL = "declare @DateFrom  as DateTime";
            strSQL += ",@DateTo as DateTime";
            strSQL += "\nSet @DateFrom = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd 00:00:00.00") + "'";
            strSQL += "\nSet @DateTo = '" + dtpDateTo.Value.ToString("yyyy-MM-dd 23:59:59.00") + "'";
            strSQL += "\nselect count(*) as SoLuong, count(*) * x.TieuHao as LuongTieuThu, MaXN , x.DVTTieuHao, x.MaVatTu, v.TenVatTu";
            strSQL += "\nfrom KetQua_CLS_XetNghiem x ";
            strSQL += "\ninner join BenhNhan_CLS_XetNghiem b ";
            strSQL += "\non x.MaTiepNhan = b.MaTiepNhan";
            strSQL += "\ninner join VT_DM_VatTu v on v.MaVatTu = x.MaVatTu";
            strSQL += "\n inner join BenhNhan_TiepNhan t on t.MaTiepNhan = x.MaTiepNhan";
            strSQL += "\nwhere t.NgayTiepNhan between @DateFrom and  @DateTo ";
            if (cboVatTu_XN.SelectedIndex != -1)
            {
                strSQL += "\nand x.MaVatTu = '" + cboVatTu_XN.SelectedValue.ToString().Trim() + "'";
            }
            strSQL += "\n group by MaXN , x.DVTTieuHao, x.MaVatTu, v.TenVatTu,x.TieuHao";

            ControlExtension.BindDataToGrid(DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0], ref dtgHCXN, ref bvHCXN);
            LabServices_Helper.DanhDauNhom_STT(dtgHCXN);
        }

        private void btnHC_XN_Click(object sender, EventArgs e)
        {
            TKLuongTieuThu_HoaChatXN();
        }

        private void Load_VatTu()
        {
            //Hoa chat XN
            vattu.Get_DM_VatTu_TheoLoai(cboVatTu_XN, " and l.HCXetNghiem = 1");
            cboVatTu_XN.LinkedTextBox1 = txtTenVatTu_XN;
            cboVatTu_XN.LinkedColumnIndex1 = 1;
        }
        private void FrmLuongTieuThu_Load(object sender, EventArgs e)
        {
            Load_VatTu();
        }

        private void btnXuatHCXN_Click(object sender, EventArgs e)
        {
           Excel.ExportToExcel.Export(dtgHCXN);
        }
    }
}
