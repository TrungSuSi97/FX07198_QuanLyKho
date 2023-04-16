using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TPH.LIS.Patient.Model
{
    public class GuiMauNoiBoModel
    {
        public long Idgui { get; set; }

        public string Matiepnhan { get; set; }

        public string Madichvu { get; set; }

        public string Manhomdichvu { get; set; }

        DateTime _tggui = DateTime.Now;
        public DateTime Tggui
        {
            get { return _tggui; }
            set { _tggui = value; }
        }

        public string Nguoigui { get; set; }

        public string Pcgui { get; set; }

        public string Khuvucguiid { get; set; }

        public string Khuvucnhanid { get; set; }

        public string Pcnhan { get; set; }

        public string Nguoinhan { get; set; }
        bool _danhanmau = false;
        public bool Danhanmau
        {
            get { return _danhanmau; }
            set { _danhanmau = value; }
        }

        public string Maongmau { get; set; }

        public DateTime? Tgnhan { get; set; }

        //hủy gủi, nhận mẫu 
        DateTime _tgthuchien = DateTime.Now;
        public DateTime Tgthuchien
        {
            get { return _tgthuchien; }
            set { _tgthuchien = value; }
        }

        public string Pcthuchien { get; set; }

        public string Nguoithuchien { get; set; }

        public string Lydo { get; set; }

        public string Idlydo { get; set; }
        public int Idloaithuchien { get; set; }
        public string Tennhomchidinh { get; set; }
    }
    
}
