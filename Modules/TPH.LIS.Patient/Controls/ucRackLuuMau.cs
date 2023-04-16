using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.Common.Controls;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucRackLuuMau : UserControl 
    {
        public ucRackLuuMau()
        {
            InitializeComponent();
        }
        public int SoLuongX = 10;
        public int SoLuongY = 10;
        List<ucThongTinMauLuu> lstOngMau = new List<ucThongTinMauLuu>();
        
        private readonly IPatientInformationService iPatient = new PatientInformationService();
        public string UserId { get; set; }
        public int SetDanhSachOngMau(string tuLuu, string hopLuu)
        {
            flpOngMau.Controls.Clear();
            lstOngMau = new List<ucThongTinMauLuu>();
            lblSoRack.Text = string.Format("TỦ: {0} - HỘP: {1}", tuLuu, hopLuu);
            var soLuong = SoLuongX * SoLuongY;
            int width = 0;
            int height = 0;
            for (int i = 0; i < soLuong; i++)
            {
                var uc = new ucThongTinMauLuu();
                uc.Name = string.Format("OngMau_{0}", i);
                uc.ViTriOngMau = i + 1;
                uc.XoaLuuMau += Uc_XoaLuuMau;
                lstOngMau.Add(uc);
                width = uc.Width;
                height = uc.Height;
            }
            flpOngMau.MaximumSize = new Size(SoLuongX * (width + 10) + 25, SoLuongY * (height + 10) + 25);
            flpOngMau.Size = flpOngMau.MaximumSize;
            foreach (var item in lstOngMau)
            {
                flpOngMau.Controls.Add(item);
            }
            // +10 padding
            return Load_DanhSachMauDaLuu(string.Empty, tuLuu, hopLuu);
        }

        private void Uc_XoaLuuMau(object sender, EventArgs e)
        {
            var uc = (ucThongTinMauLuu)sender;
            if (!string.IsNullOrEmpty(uc.Barcode))
            {
                if (!uc.MauDaHuy)
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("xóa thông tin mẫu lưu:\nBarode:{0} - Vị trí: {1}", uc.Barcode, uc.ViTriOngMau)))
                    {
                        iPatient.XoaOngMauLuu(uc.IdMauLuu, UserId, Environment.MachineName);
                        uc.XoaHienThi();
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Không thể xóa thông tin lưu mẫu đã hủy!");
            }
        }

        public void ClearList()
        {
            flpOngMau.Controls.Clear();
            lstOngMau = new List<ucThongTinMauLuu>();
        }
        public int Load_DanhSachMauDaLuu(string Barcode, string MaSoTu, string MaSoHop)
        {
           // SetDanhSachOngMau(MaSoTu, MaSoHop);
            int maxVitri = 0;
            var data = iPatient.DanhSach_OngMauLuu(string.Empty, MaSoHop, MaSoTu);
            if(data !=null)
            {
                if (data.Rows.Count > 0)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        var obj = iPatient.Get_Info_mauxetnghiem_luumau_FromDatarow(dr);
                        SetTubeValue(obj, false);
                        if (obj.Vitri > maxVitri)
                            maxVitri = obj.Vitri;
                    }
                }
            }
            return maxVitri;
        }
        private void SetTubeValue(ArchiveSample obj, bool alert)
        {
            foreach (var item in lstOngMau)
            {
                if (item.ViTriOngMau == obj.Vitri)
                {
                    var colr = Color.LightGray;
                    if (!string.IsNullOrEmpty(obj.Mauongmau))
                    {
                        string[] split = obj.Mauongmau.Split(',');
                        if (split.Length == 3)
                        {
                            colr = Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
                        }
                    }
                    item.ThongTinOngMau(obj.Barcode, obj.Nguoiluu, colr, obj.Ngayluu, obj.Ngayhuy, obj.Maongmau);
                    item.IdMauLuu = obj.Idluumau;
                    if (alert)
                    {
                        item.SetAlarm(true);
                        flpOngMau.Controls[item.Name].Focus();
                    }
                }
                else
                {
                    if (alert)
                        item.SetAlarm(false);
                }
            }
        }
        public void ThemOngMau(ArchiveSample obj)
        {
            if (iPatient.ThemOngMauLuu(obj) > 0)
            {
                var id = iPatient.GetIDLuuMau(obj);
                obj.Idluumau = id;
                SetTubeValue(obj, true);
            }
        }
    }
}
