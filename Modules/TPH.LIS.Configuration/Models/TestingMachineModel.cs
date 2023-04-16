using System.Reflection;

namespace TPH.LIS.Configuration.Models
{
    public class TestingMachineModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionType { get; set; }
        public string Protocol { get; set; }
        public bool IsAuto { get; set; }
    }
    #region h_mayxetnghiem_chitiet
    public class H_MAYXETNGHIEM_CHITIET
    {
        string _h_mayxetnghiem_chitiet = "{{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet";
        public string H_mayxetnghiem_chitiet
        {
            get { return _h_mayxetnghiem_chitiet; }
            set { _h_mayxetnghiem_chitiet = value; }
        }
        public int Idmayxn { get; set; }
        int _idphanloaimay = 0;
        public int Idphanloaimay
        {
            get { return _idphanloaimay; }
            set { _idphanloaimay = value; }
        }
        public string Tenhienthi { get; set; }
        public string IdBHYT { get; set; }
        public string Hisid { get; set; }
        public bool LuuKetQuaTrenIMS { get; set; }
        public bool IsNotStaticByModules { get; set; }

        public string GiaoThucBieuDo { get; set; }
        public H_MAYXETNGHIEM_CHITIET() { }
        public H_MAYXETNGHIEM_CHITIET(int idmayxn, int idphanloaimay, string tenhienthi, string idBHYT, string hisId)
        {
            this.Idmayxn = idmayxn;
            this.Idphanloaimay = idphanloaimay;
            this.Tenhienthi = tenhienthi;
            IdBHYT = idBHYT;
            Hisid = hisId;
        }
        public H_MAYXETNGHIEM_CHITIET Copy()
        {
            return (H_MAYXETNGHIEM_CHITIET)this.MemberwiseClone();
        }
        public bool Compare_Differences(H_MAYXETNGHIEM_CHITIET objCompare)
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
