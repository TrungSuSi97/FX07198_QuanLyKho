using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.App.AppCode.Config
{
    internal class C_VatTu_Config
    {

//Loại vật tư
        public void Get_DM_LoaiVT(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from VT_DM_LoaiVT where 0=0 \n";
            strSql += filter;
            strSql += " order by TenLoaiVT,MaLoaiVT";
            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }

        public void Get_DM_LoaiVT(CustomComboBox cbo)
        {
            var strSql = " select * from VT_DM_LoaiVT where 0=0 \n";
            strSql += " order by TenLoaiVT,MaLoaiVT";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaLoaiVT", "MaLoaiVT");
            cbo.ColumnNames = "MaLoaiVT,TenLoaiVT";
            cbo.ColumnWidths = "50,250";
        }

        public void Get_DM_LoaiVT(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from VT_DM_LoaiVT where 0=0 \n";
            strSql += filter;
            strSql += " order by TenLoaiVT,MaLoaiVT";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaLoaiVT", "MaLoaiVT");
            cbo.ColumnNames = "MaLoaiVT,TenLoaiVT";
            cbo.ColumnWidths = "50,250";
        }

        public void Get_DM_VatTu_TheoLoai(CustomComboBox cbo, string maLoai)
        {
            var strSql =
                " select v.MaVatTu,v.TenVatTu from VT_DM_VatTu v inner join VT_DM_LoaiVT l on v.MaLoaiVT = l.MaLoaiVT where 0=0 \n";
            strSql += maLoai;
            strSql += " order by TenVatTu,MaVatTu";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaVatTu", "MaVatTu");
            cbo.ColumnNames = "MaVatTu,TenVatTu";
            cbo.ColumnWidths = "50,250";
        }

        public void Insert_LoaiVT(string maLoaiVt, string tenLoaiVt)
        {
            if (
                !LabServices_Helper.Check_NotExits("select top 1 * from VT_DM_LoaiVT where MaLoaiVT = '" + maLoaiVt.Trim() +
                                                "'")) return;
            var strSql = " insert into VT_DM_LoaiVT (MaLoaiVT, TenLoaiVT)\n";
            strSql += " select '" + maLoaiVt + "',N'" + Utilities.ConvertSqlString(tenLoaiVt) + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Delete_LoaiVT(string maLoaiVt)
        {
            if (
                LabServices_Helper.Check_NotExits("select top 1  * from VT_DM_LoaiVT where MaLoaiVT = '" + maLoaiVt.Trim() +
                                               "'"))
            {
                var strSql = "delete from VT_DM_VatTu where MaLoaiVT = '" + maLoaiVt.Trim() + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                CustomMessageBox.MSG_Information_OK("Xóa hoàn tất!");
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("KHÔNG THỂ XÓA !\nLoại vật tư đang được sử dụng.");
            }
        }

        //Don vi tinh

        public void Get_DM_DonViTinh(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from VT_DonViTinh where 0=0 \n";
            strSql += filter;
            strSql += " order by UnitName";
            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }

        public void Get_DM_DonViTinh(CustomComboBox cbo)
        {
            var dt = new DataTable();
            var strSql = " select * from VT_DonViTinh where 0=0 \n";
            strSql += " order by UnitName";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "UnitName", "UnitName", "UnitName", "150");
            cbo.ColumnNames = "UnitName";
            cbo.ColumnWidths = "50";
        }

        //Nhóm vật tư
        public void Get_DM_NhomVT(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from VT_DM_NhomVT where 0=0 \n";
            strSql += filter;
            strSql += " order by TenNhomVT,MaNhomVT";
            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }

        public void Get_DM_NhomVT(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from VT_DM_NhomVT where 0=0 \n";
            strSql += filter;
            strSql += " order by TenNhomVT,MaNhomVT";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomVT", "MaNhomVT");
            cbo.ColumnNames = "MaNhomVT,TenNhomVT";
            cbo.ColumnWidths = "50,250";
        }

        public void Insert_NhomVT(string maNhomVt, string tenNhomVt, string nhomDvcls)
        {
            if (
                !LabServices_Helper.Check_NotExits("select top 1 * from VT_DM_NhomVT where MaNhomVT = '" + maNhomVt.Trim() +
                                                "'")) return;
            var strSql = " insert into VT_DM_NhomVT (MaNhomVT, TenNhomVT,MaPhanLoai)\n";
            strSql += " select '" + maNhomVt + "',N'" + Utilities.ConvertSqlString(tenNhomVt) + "'," +
                      (string.IsNullOrWhiteSpace(nhomDvcls) ? "NULL" : nhomDvcls);
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Delete_NhomVT(string maNhomVt)
        {
            if (
                LabServices_Helper.Check_NotExits("select top 1  * from VT_DM_NhomVT where MaNhomVT = '" + maNhomVt.Trim() +
                                               "'"))
            {
                var strSql = "delete from VT_DM_VatTu where MaNhomVT = '" + maNhomVt.Trim() + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                CustomMessageBox.MSG_Information_OK("Xóa hoàn tất!");
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("KHÔNG THỂ XÓA !\nNhóm vật tư đang được sử dụng.");
            }
        }

        //Danh muc vat tu

        public void Get_DM_VatTu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from VT_DM_VatTu where 0=0 \n";
            strSql += filter;
            strSql += " order by TenVatTu,MaVatTu";
            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }

        public void Get_DM_VatTu(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from VT_DM_VatTu where 0=0 \n";
            strSql += filter;
            strSql += " order by TenVatTu,MaVatTu";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaVatTu", "MaVatTu");
            cbo.ColumnNames = "MaVatTu,TenVatTu";
            cbo.ColumnWidths = "50,250";
        }

        public bool Insert_VatTu(string maVatTu, string tenVatTu,
            string maLoaiVt, string maNhomVt, string quiCachDongGoi, string donViTinh, string slDongGoi,
            string dvtDongGoi,
            string coHsd, string xuatTheoQcdg, string sldgTieuHao, string dvtTieuHao, string slCoTheDung, string tieuHao)
        {
            if (
                LabServices_Helper.Check_NotExits("select top 1 * from VT_DM_VatTu where MaVatTu = '" + maVatTu.Trim() +
                                               "'"))
            {
                try
                {
                    var strSql =
                        " insert into VT_DM_VatTu (MaVatTu, TenVatTu, MaLoaiVT, MaNhomVT, QuiCachDongGoi, DonViTinh, SLDongGoi,\n";
                    strSql += " DVTDongGoi, CoHSD, XuatTheoQCDG, SLDGTieuHao, DVTTieuHao, SLCoTheDung, TieuHao)\n";
                    strSql += " select '" + maVatTu + "',N'" + Utilities.ConvertSqlString(tenVatTu) + "'," +
                              (string.IsNullOrWhiteSpace(maLoaiVt) ? "NULL" : "'" + maLoaiVt + "'") + "," +
                              (string.IsNullOrWhiteSpace(maNhomVt) ? "NULL" : "'" + maNhomVt + "'");
                    strSql += ",'" + quiCachDongGoi + "',N'" + donViTinh + "'," + slDongGoi + ",\n";
                    strSql += "N'" + dvtDongGoi + "'," + coHsd + "," + xuatTheoQcdg + "," + sldgTieuHao + ",N'" +
                              dvtTieuHao + "'," + slCoTheDung + "," + tieuHao;
                    DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            CustomMessageBox.MSG_Waring_OK("Mã vật tư đã tồn tại !\nVui lòng nhập mã khác.");
            return false;
        }

        public bool Update_VatTu(string maVatTu, string tenVatTu,
            string maLoaiVt, string maNhomVt, string quiCachDongGoi, string donViTinh, string slDongGoi,
            string dvtDongGoi,
            string coHsd, string xuatTheoQcdg, string sldgTieuHao, string dvtTieuHao, string slCoTheDung, string tieuHao)
        {
            if (
                LabServices_Helper.Check_NotExits("select top 1 * from VT_DM_VatTu where MaVatTu = '" + maVatTu.Trim() +
                                               "'") == false)
            {
                try
                {
                    var strSql = " Update VT_DM_VatTu set \n";
                    strSql += " TenVatTu=N'" + Utilities.ConvertSqlString(tenVatTu) + "',MaNhomVT=" +
                              (string.IsNullOrWhiteSpace(maNhomVt) ? "NULL" : "'" + maNhomVt + "'") + ",MaLoaiVT=" +
                              (string.IsNullOrWhiteSpace(maLoaiVt) ? "NULL" : "'" + maLoaiVt + "'");
                    strSql += " ,QuiCachDongGoi='" + quiCachDongGoi + "',DonViTinh=N'" + donViTinh + "',SLDongGoi=" +
                              slDongGoi + "\n";
                    strSql += " ,DVTDongGoi=N'" + dvtDongGoi + "',CoHSD=" + coHsd + ",XuatTheoQCDG=" + xuatTheoQcdg +
                              "\n";
                    strSql += " ,SLDGTieuHao=" + sldgTieuHao + ", DVTTieuHao=N'" + dvtTieuHao + "',SLCoTheDung=" +
                              slCoTheDung + ",TieuHao=" + tieuHao;
                    strSql += "\n where MaVatTu= '" + maVatTu + "'";
                    DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                    CustomMessageBox.MSG_Information_OK("Cập nhật thông tin thành công !");
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            CustomMessageBox.MSG_Waring_OK("Vật tư đã bị xóa hoặc không tồn tại !");
            return false;
        }

        public void Delete_VatTu(string maVatTu)
        {
            if (
                LabServices_Helper.Check_NotExits("select top 1  * from VT_DM_VatTu where MaVatTu = '" + maVatTu.Trim() +
                                               "'"))
            {
                var strSql = "delete from VT_DM_VatTu where MaVatTu = '" + maVatTu.Trim() + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                CustomMessageBox.MSG_Information_OK("Xóa hoàn tất!");
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("KHÔNG THỂ XÓA !\nVật tư đang được sử dụng.");
            }
        }
    }
}