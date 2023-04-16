namespace TPH.Cashier.CashierContanst
{
    public class CashierCommonConstant
    {
    }
    public class CashierItemSelected
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCatagory { get; set; }
        public bool IsProfile { get; set; }
        public string ProfileId { get; set; }
        public double ItemCost { get; set; }
        public int ItemCount { get; set; }
        public string ItemNote { get; set; }
        public string ItemUnit { get; set; }

        public string TestGruopId { get; set; }
        public string TestGroupName { get; set; }
        public int GroupSort { get; set; }
        public int ItemSort { get; set; }
        public string MaChiDan { get; set; }

    }
    public enum EnumHinhThucThanhToan
    {
        TienMat = 0,
        ChuyenKhoan = 1
    }
    public enum EnumThaoTacThuPhi
    {
        ThuTien = 0,
        HoanTien = 1
    }


    public enum EnumChon
    {
        TatCa = 0,
        CoGiaTri = 1,
        KhongGiaTri = 2
    }

}
