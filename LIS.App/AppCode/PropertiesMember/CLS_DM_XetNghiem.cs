namespace TPH.LIS.App.AppCode.PropertiesMember
{
    public class LOAIMAU
    {
        string _loaimau;
        public string Loaimau
        {
            get { return _loaimau; }
            set { _loaimau = value; }
        }
        string _maloaimau;
        public string Maloaimau
        {
            get { return _maloaimau; }
            set { _maloaimau = value; }
        }
        public LOAIMAU() { }
        public LOAIMAU(string loaimau, string maloaimau)
        {
            this.Loaimau = loaimau;
            this.Maloaimau = maloaimau;
        }
    }

}
