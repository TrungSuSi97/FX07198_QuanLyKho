using System;
using System.ComponentModel;
using System.Reflection;

namespace TPH.LIS.Analyzer.Model
{
    [Serializable()]
    public class H_MAYXETNGHIEM
    {
        int _idmay;
        public int Idmay
        {
            get { return _idmay; }
            set { _idmay = value; }
        }
        string _loaiketnoi;
        public string Loaiketnoi
        {
            get { return _loaiketnoi; }
            set { _loaiketnoi = value; }
        }
        string _protocol;
        public string Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }
        string _tenmay;
        public string Tenmay
        {
            get { return _tenmay; }
            set { _tenmay = value; }
        }
        bool _tudongvalid;
        public bool Tudongvalid
        {
            get { return _tudongvalid; }
            set { _tudongvalid = value; }
        }
        public H_MAYXETNGHIEM() { }
        public H_MAYXETNGHIEM(int idmay, string loaiketnoi, string protocol, string tenmay, bool tudongvalid)
        {
            this._idmay = idmay;
            this._loaiketnoi = loaiketnoi;
            this._protocol = protocol;
            this._tenmay = tenmay;
            this._tudongvalid = tudongvalid;
        }
    }
    #region h_bangmamayxn
    public class H_BANGMAMAYXN
    {
        [Description("ID máy xét nghiệm")]
        public int Idmay { get; set; }
        [Description("Mã xét nghiệm IMS")]
        public string Maxn { get; set; }
        [Description("Mã xét nghiệm máy")]
        public string Mamay { get; set; }
        [Description("Mã download (nếu có)")]
        public string Mamay2 { get; set; }
        [Description("Mã ống mẫu (Tube)")]
        public string Tube { get; set; }
        [Description("Mã trung giang")]
        public string Matrunggian { get; set; }
        [Description("Ghép mã loại mẫu")]
        public bool Orthernmr { get; set; } = false;
        [Description("Tự nhập chỉ định BN")]
        public bool Chothem { get; set; } = false;
        [Description("Mã XN cha")]
        public string Mastertest { get; set; }
        [Description("Loại mẫu")]
        public string Loaimau { get; set; }
        [Description("Cận dưới")]
        public float? Canduoi { get; set; }
        [Description("Cận trên")]
        public float? Cantren { get; set; }
        [Description("Lấy trong khoảng cận")]
        public bool Inside { get; set; } = false;
        [Description("Không download chỉ định")]
        public bool Camdown { get; set; } = false;
        [Description("QC out")]
        public bool Qcout { get; set; } = false;
        [Description("Lấy kết quả >")]
        public bool Valhigher { get; set; } = false;
        [Description("Lấy kết quả <")]
        public bool Vallower { get; set; } = false;
        [Description("Giá trị cận dưới")]
        public float? Lowlimit { get; set; }
        [Description("Đổi giá trị cận dưới")]
        public string Lowvalue { get; set; }
        [Description("Giá trị cận trên")]
        public float? Highlimit { get; set; }
        [Description("Đổi giá trị cận trên")]
        public string Highvalue { get; set; }
        [Description("Làm tròn")]
        public int? Lamtron { get; set; }
        [Description("Lấy định lượng")]
        public bool Dinhluong { get; set; } = true;
        [Description("Lấy định tính")]
        public bool Dinhtinh { get; set; } = true;
        public string Testcode_old { get; set; }
        [Description("Hệ số nhân")]
        public float Heso { get; set; } = 0;
        [Description("ĐK chặn KQ ( |: Field - ^:Component)")]
        public string Dieukien { get; set; }
        [Description("Lấy kết quả cờ")]
        public bool Getflag { get; set; } = false;
        [Description("Lấy log10 QC")]
        public bool Laylog10qc { get; set; } = false;
        [Description("Không làm tròn QC")]
        public bool Khonglamtronqc { get; set; } = false;
        [Description("Thống kê")]
        public bool Stat { get; set; } = true;
        public bool Lonnho { get; set; } = false;
        [Description("Người nhập")]
        public string Userd { get; set; }
        [Description("TG nhập")]
        public DateTime? Intime { get; set; }
        public H_BANGMAMAYXN() { }
        public H_BANGMAMAYXN Copy()
        {
            return (H_BANGMAMAYXN)this.MemberwiseClone();
        }
    }
    #endregion
    public class H_HOSTCONFIG
    {
        string _comport;
        public string Comport
        {
            get { return _comport; }
            set { _comport = value; }
        }
        int? _idmay;
        public int? Idmay
        {
            get { return _idmay; }
            set { _idmay = value; }
        }
        string _ipaddress;
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }
        string _ipport;
        public string Ipport
        {
            get { return _ipport; }
            set { _ipport = value; }
        }
        string _loai;
        public string Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }
        string _mayxn;
        public string Mayxn
        {
            get { return _mayxn; }
            set { _mayxn = value; }
        }
        string _pcname;
        public string Pcname
        {
            get { return _pcname; }
            set { _pcname = value; }
        }
        int _portid;
        public int Portid
        {
            get { return _portid; }
            set { _portid = value; }
        }
        string _protocol;
        public string Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }
        string _setting;
        public string Setting
        {
            get { return _setting; }
            set { _setting = value; }
        }
        public H_HOSTCONFIG() { }
        public H_HOSTCONFIG(string comport, int? idmay, string ipaddress, string ipport, string loai, string mayxn, string pcname, int portid, string protocol, string setting)
        {
            this._comport = comport;
            this._idmay = idmay;
            this._ipaddress = ipaddress;
            this._ipport = ipport;
            this._loai = loai;
            this._mayxn = mayxn;
            this._pcname = pcname;
            this._portid = portid;
            this._protocol = protocol;
            this._setting = setting;
        }
    }
    public class H_KETQUAMAY
    {
        int _congketnoi;
        public int Congketnoi
        {
            get { return _congketnoi; }
            set { _congketnoi = value; }
        }
        string _donvi;
        public string Donvi
        {
            get { return _donvi; }
            set { _donvi = value; }
        }
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        int _idmay;
        public int Idmay
        {
            get { return _idmay; }
            set { _idmay = value; }
        }
        string _ketqua;
        public string Ketqua
        {
            get { return _ketqua; }
            set { _ketqua = value; }
        }
        string _ketquagoc;
        public string Ketquagoc
        {
            get { return _ketquagoc; }
            set { _ketquagoc = value; }
        }
        string _mamay;
        public string Mamay
        {
            get { return _mamay; }
            set { _mamay = value; }
        }
        string _maxn;
        public string Maxn
        {
            get { return _maxn; }
            set { _maxn = value; }
        }
        DateTime _ngayxn;
        public DateTime Ngayxn
        {
            get { return _ngayxn; }
            set { _ngayxn = value; }
        }
        string _pid;
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        string _seq;
        public string Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }
        string _sid;
        public string Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        DateTime? _thoigiantumay;
        public DateTime? Thoigiantumay
        {
            get { return _thoigiantumay; }
            set { _thoigiantumay = value; }
        }
        string _trangthai;
        public string Trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; }
        }
        string _userdelete;
        public string Userdelete
        {
            get { return _userdelete; }
            set { _userdelete = value; }
        }
        string _uservalid;
        public string Uservalid
        {
            get { return _uservalid; }
            set { _uservalid = value; }
        }
        public H_KETQUAMAY() { }
        public H_KETQUAMAY(int congketnoi, string donvi, int id, int idmay, string ketqua, string ketquagoc, string mamay, string maxn, DateTime ngayxn, string pid
        , string seq, string sid, DateTime? thoigiantumay, string trangthai, string userdelete, string uservalid)
        {
            this._congketnoi = congketnoi;
            this._donvi = donvi;
            this._id = id;
            this._idmay = idmay;
            this._ketqua = ketqua;
            this._ketquagoc = ketquagoc;
            this._mamay = mamay;
            this._maxn = maxn;
            this._ngayxn = ngayxn;
            this._pid = pid;
            this._seq = seq;
            this._sid = sid;
            this._thoigiantumay = thoigiantumay;
            this._trangthai = trangthai;
            this._userdelete = userdelete;
            this._uservalid = uservalid;
        }
    }
    public class H_THONGTINKETQUAMAY
    {
        int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        int? _idmay;
        public int? Idmay
        {
            get { return _idmay; }
            set { _idmay = value; }
        }
        DateTime _intime;
        public DateTime Intime
        {
            get { return _intime; }
            set { _intime = value; }
        }
        DateTime? _ngayxn;
        public DateTime? Ngayxn
        {
            get { return _ngayxn; }
            set { _ngayxn = value; }
        }
        string _pcname;
        public string Pcname
        {
            get { return _pcname; }
            set { _pcname = value; }
        }
        string _sid;
        public string Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        public H_THONGTINKETQUAMAY() { }
        public H_THONGTINKETQUAMAY(int id, int? idmay, DateTime intime, DateTime? ngayxn, string pcname, string sid)
        {
            this._id = id;
            this._idmay = idmay;
            this._intime = intime;
            this._ngayxn = ngayxn;
            this._pcname = pcname;
            this._sid = sid;
        }
    }
}
