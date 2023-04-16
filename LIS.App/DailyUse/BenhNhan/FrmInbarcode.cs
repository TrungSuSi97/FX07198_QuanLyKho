using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmInbarcode : FrmTemplate
    {
        public FrmInbarcode()
        {
            InitializeComponent();
        }
        int tuSo = 0;
        int denSo = 0;
        int printingNumder = 0;
        BarcodeProperties barcode = new BarcodeProperties();
        bool pause = false;
        int count = 0;
        int tongSo = 0;
        private void radInLai_CheckedChanged(object sender, EventArgs e)
        {
            var obj = (RadioButton)sender;
            if (obj.Checked)
                obj.BackColor = Color.Yellow;
            else
                obj.BackColor = Color.Empty;
            pnTemMoi.Visible = radTemMoi.Checked;
            pnInLai.Visible = radInLai.Checked;
        }
        private void StartInTem()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thực hiện in barcode?"))
            {
                if (radInLai.Checked)
                {
                    tuSo = (int)numTuSo.Value;
                    denSo = (int)numDenSo.Value;
                    tongSo = denSo - tuSo + 1;
                }
                else
                {
                    tuSo = int.Parse(CommonAppVarsAndFunctions.sysConfig.GenerateSeqWithNotMaxLimit(((int)numSLKhach.Value) - 1));
                    denSo = tuSo + (((int)numSLKhach.Value) - 1);
                    tongSo = denSo - tuSo + 1;
                }
                printingNumder = tuSo;
                barcode.NumberOfCopy = (int)numSLTem.Value;
                barcode.LoaiTem =  BarcodePrinting.Constants.Loaibarcode.EnumLoaiBarcode.KhamSucKhoe;
                timer1.Enabled = true;
                timer1.Start();

                btnIntem.Enabled = false;
                btnTamDung.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pause)
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
            else
            {
                timer1.Stop();

                if (printingNumder <= denSo)
                {
                    lblBarcodeDangIn.Text = string.Format("Đang in barcode: {0}", printingNumder);
                    barcode.TenBarcode = barcode.SoBarcode = printingNumder.ToString();
                    barcode.NamSinh = "0";
                    barcode.DanhSachTube = new List<BarcodeTubeDetail>() { new BarcodeTubeDetail() { Barcode = barcode.SoBarcode, TubeCount = (int)numSLTem.Value } };
                    var objPrintInfo = new DM_MAYTINH_MAYIN();
                    PrintBarcodeHelper.PrintBarcode(objPrintInfo, new List<BarcodeProperties>() { barcode }, null);
                    lblBarcodeDangIn.Text = string.Format("Hoàn thành in barcode: {0}!", printingNumder);
                    count++;
                    lblTongSo.Text = string.Format("Đã in: {0}/{1}", count, tongSo);
                }
                if (printingNumder >= denSo)
                {
                    CustomMessageBox.MSG_Information_OK("In barcode hoàn tất!");
                    Reset_FinishPrint();
                }
                else
                {
                    if (printingNumder < denSo)
                    {
                        printingNumder++;
                    }
                    timer1.Start();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy in code?"))
            {
                Reset_FinishPrint();
            }
        }
        private void Reset_FinishPrint()
        {
            timer1.Stop();
            timer1.Enabled = false;
            tuSo = 0;
            denSo = 0;
            printingNumder = 0;
            count = 0;
            lblBarcodeDangIn.Text = string.Empty;
            btnIntem.Enabled = true;
            btnTamDung.Enabled = false;
            btnHuy.Enabled = false;
            pause = false;
            btnTamDung.Text = "Tạm dừng";
        }
        private void btnTamDung_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                pause = false;
                btnTamDung.Text = "Tạm dừng";
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                btnTamDung.Text = "Tiếp tục";
                pause = true;
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void btnIntem_Click(object sender, EventArgs e)
        {
            StartInTem();
        }

        private void FrmInbarcode_Load(object sender, EventArgs e)
        {

        }
    }
}
