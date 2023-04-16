using System;
using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    #region dm_hentraketqua
    public class DM_HENTRAKETQUA
    {
        string _dm_hentraketqua = "dm_hentraketqua";
        public string Dm_hentraketqua
        {
            get { return _dm_hentraketqua; }
            set { _dm_hentraketqua = value; }
        }

        public int Id { get; set; }

        public string Madanhmuc { get; set; }

        public string Loaidanhmuc { get; set; }

        public bool Danhmucnhom { get; set; }

        public string Ngaytrongtuan { get; set; }

        public DateTime Giobatdau { get; set; }

        public DateTime Gioketthuc { get; set; }
        int _thoigianthuchien = 0;
        public int Thoigianthuchien
        {
            get { return _thoigianthuchien; }
            set { _thoigianthuchien = value; }
        }
        bool _traquangay = false;
        public bool Traquangay
        {
            get { return _traquangay; }
            set { _traquangay = value; }
        }

        public int Ngaythuchien { get; set; }
        public DateTime? Giotratrongngay { get; set; }
        public DateTime Giotraquangay { get; set; }
        public string MaKhoaPhong { get; set; }
        public int SoPhutCC { get; set; }
        public string MaPhong { get; set; }
        public string MaKhuDieuTri { get; set; }
        public DM_HENTRAKETQUA() { }
        public DM_HENTRAKETQUA(int id, string madanhmuc, string loaidanhmuc, bool danhmucnhom, string ngaytrongtuan, DateTime giobatdau, DateTime gioketthuc, int thoigianthuchien, bool traquangay, int ngaythuchien
        , DateTime giotraquangay, DateTime giotratrongngay)
        {
            this.Id = id;
            this.Madanhmuc = madanhmuc;
            this.Loaidanhmuc = loaidanhmuc;
            this.Danhmucnhom = danhmucnhom;
            this.Ngaytrongtuan = ngaytrongtuan;
            this.Giobatdau = giobatdau;
            this.Gioketthuc = gioketthuc;
            this.Thoigianthuchien = thoigianthuchien;
            this.Traquangay = traquangay;
            this.Ngaythuchien = ngaythuchien;
            this.Giotraquangay = giotraquangay;
            this.Giotratrongngay = giotratrongngay;
        }
    }
    #endregion
    #region dm_ngaynghi
    public class DM_NGAYNGHI
    {
        string _dm_ngaynghi = "{{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI";
        public string Dm_ngaynghi
        {
            get { return _dm_ngaynghi; }
            set { _dm_ngaynghi = value; }
        }

        public DateTime Ngaynghi { get; set; }

        public string Ghichu { get; set; }

        public int SoNgayNghi
        {
            get
            {
                return soNgayNghi;
            }

            set
            {
                soNgayNghi = value;
            }
        }

        private int soNgayNghi = 1;

        public DM_NGAYNGHI() { }
        public DM_NGAYNGHI(DateTime ngaynghi, string ghichu)
        {
            this.Ngaynghi = ngaynghi;
            this.Ghichu = ghichu;
        }
        public DM_NGAYNGHI Copy()
        {
            return (DM_NGAYNGHI)this.MemberwiseClone();
        }
        public bool Compare_Differences(DM_NGAYNGHI objCompare)
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
