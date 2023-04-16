using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TPH.LIS.DigitalSignature.Models
{
    #region ThongTinFileKy
    public class THONGTINFILEKY
    {
        string _thongtinfileky = "ThongTinFileKy";
        public string Thongtinfileky
        {
            get { return _thongtinfileky; }
            set { _thongtinfileky = value; }
        }

        public long Id { get; set; }

        public string Matiepnhan { get; set; }

        public string Mahoso { get; set; }

        public string Mabn { get; set; }

        public string Sophieu { get; set; }

        public DateTime? Ngaytaophieu { get; set; }
        bool _trangthai = false;
        public bool Trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }

        public string Userky { get; set; }
        int _loaiky = -1;
        public int Loaiky
        {
            get { return _loaiky; }
            set { _loaiky = value; }
        }

        public DateTime Ngayky { get; set; }
        int _lanky = 0;
        public int Lanky
        {
            get { return _lanky; }
            set { _lanky = value; }
        }

        public string Pdffileid { get; set; }
        bool _daupload = false;
        public bool Daupload
        {
            get { return _daupload; }
            set { _daupload = value; }
        }

        public DateTime? Thoigianupload { get; set; }

        public int Solanupload { get; set; }

        public byte[] Pdfcontent { get; set; }
        public string MoTa { get; set; }
        public int LanInKQ { get; set; }
        public string PCName { get; set; }
        public string UserAction { get; set; }
        public string LoaiPhieu { get; set; }
        public int LoaiXetNghiem { get; set; }
        public string SoPhieuChiDinh { get; set; }
        public string TenFileHIS { get; set; }
        public string TenFileLIS { get; set; }
        public string DigitialTests { get; set; }
        public THONGTINFILEKY() { }
        public THONGTINFILEKY Copy()
        {
            return (THONGTINFILEKY)this.MemberwiseClone();
        }
        public bool Compare_Differences(THONGTINFILEKY objCompare)
        {
            PropertyInfo[] fiCheck = objCompare.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null && this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null).Equals(this.GetType().GetProperty(f.Name).GetValue(this, null)) == false)
                        return true;
                }
                else if (objCompare.GetType().GetProperty(f.Name).GetValue(objCompare, null) != null || this.GetType().GetProperty(f.Name).GetValue(this, null) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
    #endregion
}
