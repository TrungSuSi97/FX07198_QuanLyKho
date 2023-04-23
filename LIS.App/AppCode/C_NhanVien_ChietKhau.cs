using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;

namespace TPH.LIS.App.AppCode
{
    class C_NhanVien
    {
        
        public C_NhanVien()
        {
        }
        public void Add_NhanVien(string maNhanVien, string nhanVien)
        {
            if (LabServices_Helper.Check_NotExits("select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN where MaNhanVien='" + maNhanVien + "'"))
            {
                var strSql = "insert into {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN (MaNhanVien, TenNhanVien)";
                strSql += " select '" + maNhanVien + "', N'" + Utilities.ConvertSqlString(nhanVien) + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Mã bác sĩ đã có !\nVui lòng nhập mã khác");
            }
        }

        public void Delete_NhanVien(string maNhanVien)
        {
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa nhân viên đang chọn ?")) return;
            var strSql = "Delete {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN where MaNhanVien = '" + maNhanVien + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Get_NhanVien(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where " + filter;
            }
            strSql += " order by TenNhanVien";

            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }
        public void Get_KhoaPhong(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where " + filter;
            }
            strSql += " order by MaKhoaPhong";

            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }
        public void Get_BoPhan(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where " + filter;
            }
            strSql += " order by MaBoPhan";

            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }
      
        public void Get_BoPhanXN(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_BOPHAN";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where " + filter;
            }
            strSql += " order by MaBoPhan";
            
            LabServices_Helper.BindContex(da, ref dt, strSql, ref dtg, ref bv);
        }
        public DataTable Get_NhanVien(DataGridView dtg, BindingNavigator bv, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where DaNghi = 0";
                strSql += "\and " + filter;
            }
            else
                strSql += "\n where DaNghi=0";

            strSql += "\n order by TenNhanVien";

            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql);

            if (dt == null || dt.Tables.Count <= 0) return null;

            var result = dt.Tables[0];
            ControlExtension.BindDataToGrid(result, ref dtg, ref bv);

            return result;
        }

        public void Get_NhanVien(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN";
            strSql += " where  DaNghi = 0 ";
            strSql += " order by TenNhanVien";

            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql);
            if (dt == null || dt.Tables.Count <= 0) return;

            ControlExtension.BindDataToCobobox(dt.Tables[0], ref cbo, "MaNhanVien", "MaNhanVien", "MaNhanVien,TenNhanVien", "100,250");
        }
        public void Get_KhuDieuTri(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN";
            strSql += " order by MaBoPhan";

            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql);
            if (dt == null || dt.Tables.Count <= 0) return;

            ControlExtension.BindDataToCobobox(dt.Tables[0], ref cbo, "MaBoPhan", "MaBoPhan", "MaBoPhan,TenBoPhan", "100,200");
        }
        public void Get_KhoaPhong(CustomComboBox cbo, string filter = "")
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG\n";
            if (!string.IsNullOrEmpty(filter))
            {
                strSql += string.Format("where {0}", filter);
            }
            strSql += " order by MaKhoaPhong";

            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql);
            if (dt == null || dt.Tables.Count <= 0) return;

            ControlExtension.BindDataToCobobox(dt.Tables[0], ref cbo, "MaKhoaPhong", "MaKhoaPhong", "MaKhoaPhong,TenKhoaPhong", "100,250");
        }
        public void Get_BoPhanXN(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_BOPHAN";
            strSql += " order by MaBoPhan";

            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql);
            if (dt == null || dt.Tables.Count <= 0) return;

            ControlExtension.BindDataToCobobox(dt.Tables[0], ref cbo, "MaBoPhan", "MaBoPhan", "MaBoPhan,TenBoPhan", "100,200");
        }
        public void Get_NhanVien_KB(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN";
            strSql += " where KhamChuaBenh = 1 and DaNghi = 0 ";
            strSql += " order by TenNhanVien";

            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql);

            if (dt == null || dt.Tables.Count <= 0) return;
            ControlExtension.BindDataToCobobox(dt.Tables[0], ref cbo, "MaNhanVien", "MaNhanVien", "MaNhanVien,TenNhanVien", "100,250");
        }
        public DataTable Get_NhanVien_KB()
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN";
            strSql += " where KhamChuaBenh = 1 and DaNghi = 0 ";
            strSql += " order by TenNhanVien";
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }

    class ChietKhau_TienCong
    {
        public void Get_CategoryTree(TreeView tre)
        {
            //first : load service category
            var services = DataProvider.ExecuteDataset(CommandType.Text,
                "select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where maphanloai='CLSXetNghiem'");
            if (services == null || services.Tables.Count == 0)
            {
                return;
            }

            var dtService = services.Tables[0];

            var strSql = "select * from (select MaNhomCLS, TenNhomCLS,'" + ServiceType.ClsXetNghiem +
                         "'  as  MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom";
            //strSql += "\nUnion all \nselect MaNhomSieuAm as MaNhomCLS, TenNhomSieuAm as TenNhomCLS,'" +
            //          ServiceType.ClsSieuAm + "' as  MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm";
            //strSql += "\nUnion all \nselect MaNhomNoiSoi as MaNhomCLS, TenNhomNoiSoi as TenNhomCLS,'" +
            //          ServiceType.ClsNoiSoi + "'  as  MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi";
            //strSql += "\nUnion all \nselect MaKyThuatChup as MaNhomCLS, TenKyThuatChup as TenNhomCLS,'" +
            //          ServiceType.ClsXQuang + "'  as  MaDichVu from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup";
            //strSql += "\nUnion all \nselect MaNhomDichVu as MaNhomCLS, TenNhomDichVu as TenNhomCLS,'" +
            //          ServiceType.KhamBenh + "'  as  MaDichVu from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu";
            //strSql += "\nUnion all \nselect MaNhomCLS as MaNhomCLS, TenNhomCLS as TenNhomCLS,'" + ServiceType.DvKhac +
            //          "' as  MaDichVu from {{TPH_Standard}}_Dictionary.dbo.) as A";
            strSql += ") as A";
            strSql += "\nOrder by A.MaDichVu, MaNhomCLS";
            var categories = DataProvider.ExecuteDataset(CommandType.Text, strSql);

            if (categories == null || categories.Tables.Count == 0)
            {
                return;
            }

            var dtCateGory = categories.Tables[0];
            foreach (DataRow dr in dtService.Rows)
            {
                var trn = new TreeNode
                {
                    Text = dr["TenPhanLoai"].ToString(),
                    Name = dr["MaPhanLoai"].ToString()
                };

                if (tre.ImageList != null)
                {
                    trn.ImageIndex = 2;
                }
                var drc = dtCateGory.Select("MaDichVu = '" + dr["MaPhanLoai"].ToString() + "'");
                if (drc.Length > 0)
                {
                    var dtTemp = drc.CopyToDataTable();
                    Get_CategoryFormSevice(dtTemp, trn);
                }

                tre.Nodes.Add(trn);
                tre.ExpandAll();
            }

        }

        private void Get_CategoryFormSevice(DataTable dataCategory, TreeNode fatherNode)
        {
            foreach (DataRow dr in dataCategory.Rows)
            {
                var node = new TreeNode
                {
                    Name = dr["MaNhomCLS"].ToString(),
                    Text = dr["TenNhomCLS"].ToString(),
                    Tag = dr["MaDichVu"].ToString(),
                    ImageIndex = 1
                };

                fatherNode.Nodes.Add(node);
            }
        }

        public int CapNhat_DanhMuc_ChiTiet()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật chi tiết dịch vụ chiết khấu ?"))
            {
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, "exec Update_ChietKhau_ChiTiet_List");
            }

            return -1;
        }
        public DataTable Get_DS_ChietKhau(DataGridView dtg, BindingNavigator bv, 
            string maNhanVien, string maLoaiDv, string maNhomDv)
        {
            var strSql = "exec List_ChietKhau_ChiTiet @MaLoaiDV = '" + maLoaiDv + "', @MaNhanVien ='" + maNhanVien.Trim() +
                         "', @MaNhom ='" + maNhomDv.Trim() + "'";
            var chitiet = DataProvider.ExecuteDataset(CommandType.Text, strSql);

            if (chitiet == null || chitiet.Tables.Count <= 0) return null;

            var result = chitiet.Tables[0];
            ControlExtension.BindDataToGrid(result, ref dtg, ref bv);

            return result;
        }
        public bool Update_ChietKhau_PhanTram(string maNhanVien, string maLoaiDv, string maNhomDv, string maDichVu, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            var strSql = string.Format("update QL_NhanVien_ChietKhau set ChietKhau ={0} where MaLoaiDichVu = '{1}'",
                        value, maLoaiDv.Trim());

            if (!string.IsNullOrWhiteSpace(maNhomDv))
            {
                strSql += string.Format("\n and MaNhom = '{0}'", maNhomDv);
            }
            if (!string.IsNullOrWhiteSpace(maNhanVien))
                strSql += string.Format("\n and MaNhanVien ='{1}'", maNhanVien);
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                strSql += string.Format("\n and MaDichVu ='{0}'", maDichVu);
            }

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > 0;
        }

        public bool Update_TienCong(string maNhanVien, string maLoaiDv, string maNhomDv, string maDichVu, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            var strSql = string.Format(
                "update QL_NhanVien_ChietKhau set TienCong = {0} where MaLoaiDichVu = '{1}'",
                value, maLoaiDv.Trim());
            
            if (!string.IsNullOrWhiteSpace(maNhomDv))
            {
                strSql += string.Format("\n and MaNhom = '{0}'", maNhomDv);
            }
            if (!string.IsNullOrWhiteSpace(maNhanVien))
                strSql += string.Format("\n and MaNhanVien ='{0}'", maNhanVien);
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                strSql += string.Format("\n and MaDichVu ='{0}'", maDichVu);
            }

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > 0;
        }

        public bool SaoChepChietKhau(string copyFrom, string copyTo, string maLoaiDv, string maNhomDv, string maDichVu)
        {
            var strSql = "declare @maloaidichvu varchar(20) \n";            
            strSql += "declare @copyfrombacsi varchar(30) \n";
            strSql += string.Format("set @copyfrombacsi = '{0}' \n", copyFrom);
            strSql += string.Format("set @maloaidichvu = '{0}' \n", maLoaiDv);
            if (!string.IsNullOrWhiteSpace(maNhomDv))
            {
                strSql += "declare @manhom varchar(15) \n";
                strSql += string.Format("set @manhom = '{0}' \n", maNhomDv);
            }                

            if (!string.IsNullOrWhiteSpace(copyTo))
            {
                strSql += "declare @copytobacsi varchar(30) \n";
                strSql += string.Format("set @copytobacsi = '{0}' \n", copyTo);
            }

            strSql += "DECLARE @copy_chietkhau TABLE(MaLoaiDichVu varchar(20), MaNhom varchar(15), MaDichVu varchar(15), TienCong money) \n";
            strSql += "insert into @copy_chietkhau \n";
            strSql += "select ck.MaLoaiDichVu, ck.MaNhom, ck.MaDichVu, ck.TienCong from QL_NhanVien_ChietKhau ck \n";
            strSql += "where ck.MaLoaiDichVu = @maloaidichvu and ck.MaNhom = @manhom and ck.MaNhanVien = @copyfrombacsi \n";
            strSql += "update ck \n";
            strSql += "set ck.tienCong = c.tiencong \n";
            strSql += "from QL_NhanVien_ChietKhau ck \n";
            strSql += "inner join @copy_chietkhau c \n";
            strSql += "on ck.MaLoaiDichVu = c.MaLoaiDichVu and ck.MaNhom = c.MaNhom and ck.madichvu = c.MaDichVu \n";
            strSql += "where ck.MaLoaiDichVu = @maloaidichvu \n";

            if (!string.IsNullOrWhiteSpace(maNhomDv))
            {
                strSql += "and ck.MaNhom = @manhom \n";
            }         

            if (!string.IsNullOrWhiteSpace(copyTo))
            {
                strSql += "and ck.MaNhanVien = @copytobacsi \n";
            }               
                                    
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > 0;
        }
    }
}