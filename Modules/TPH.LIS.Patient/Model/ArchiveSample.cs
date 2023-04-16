using System;

namespace TPH.LIS.Patient.Model
{
    public class ArchiveSample
    {
        public Int64 Idluumau { get; set; }

        public string Masotuluu { get; set; }

        public string Mahopluumau { get; set; }

        public string Barcode { get; set; }

        public string Maongmau { get; set; }

        public string Nguoiluu { get; set; }

        public string Pcthuchien { get; set; }
        public string LoaiMau { get; set; }
        DateTime _ngayluu = DateTime.Now;
        public DateTime Ngayluu
        {
            get { return _ngayluu; }
            set { _ngayluu = value; }
        }
        public DateTime? Ngayhuy{ get; set; }
        int _vitri = 0;
        public int Vitri
        {
            get { return _vitri; }
            set { _vitri = value; }
        }
        public string Mauongmau { get; set; }

    }
}
