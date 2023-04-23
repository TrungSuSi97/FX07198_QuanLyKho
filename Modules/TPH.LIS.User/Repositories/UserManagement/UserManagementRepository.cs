using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Model;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;
using TPH.LIS.User.Models;

namespace TPH.LIS.User.Repositories.UserManagement
{
    public class UserManagementRepository : IUserManagementRepository
    {
        #region người dùng
        public DataTable DanhSachNhanVien()
        {
            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_Nhanvien"))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }

            return new DataTable();
        }
        public DataTable DanhSachNguoiDungNhanVien()
        {
            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNguoiDungNhanVien"))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }

            return new DataTable();
        }
        private bool KiemTraTonTaiUser(string maNguoiDung)
        {
            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_UserKhongNhanvien", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaNguoiDung", maNguoiDung) }))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0].Rows.Count > 0;
                }
            }
            return false;
        }
        public UserInfo GetUserInfoByLoginName(string loginName)
        {
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selUserInfo"
                , new SqlParameter[] { WorkingServices.GetParaFromOject("@maNguoiDung", loginName) }))
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                while (reader.Read())
                {
                    return new UserInfo()
                    {
                        Username = StringConverter.ToString(reader["TenNhanVien"]),
                        LoginName = StringConverter.ToString(reader["MaNguoiDung"]),
                        Departement = StringConverter.ToString(reader["BoPhan"]),
                        IsAdmin = NumberConverter.ToBool(reader["IsAdmin"]),
                        Password = StringConverter.ToString(reader["MatKhau"]).Trim(),
                        StaffID = StringConverter.ToString(reader["MaNhanVien"]).Trim(),
                        MaNhomNhanVien = StringConverter.ToString(reader["MaNhomNhanVien"]).Trim(),
                        TenNhomNhanVien = StringConverter.ToString(reader["TenNhomNhanVien"]).Trim(),
                        MaBoPhan = StringConverter.ToString(reader["MaBoPhan"]).Trim(),
                        TenBoPhan = StringConverter.ToString(reader["TenBoPhan"]).Trim()
                    };
                }
            }

            return null;
        }
        public DataTable GetAllUsers()
        {

            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_AllUser"))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }

            return new DataTable();
        }
        public DataTable GetAllUsers_CoPhanQuyen(string AppCode)
        {

            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_UserCoQuyenTrenApp", new SqlParameter[] { WorkingServices.GetParaFromOject("@PhanHe", AppCode) }))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }

            return new DataTable();
        }
        public DataTable GetUsersKyTenCoPhanQuyen(string MaNguoiDung, string lstPhanQuyenBP, bool kyten, bool doichieuSHPT = false)
        {
            var sqlPara = new SqlParameter[]{WorkingServices.GetParaFromOject("@lstPhanQuyenBP", lstPhanQuyenBP.Replace("'","")),
                WorkingServices.GetParaFromOject("@MaNguoiDung", MaNguoiDung),
                WorkingServices.GetParaFromOject("@kyten", kyten),
                WorkingServices.GetParaFromOject("@doichieuSHPT", doichieuSHPT)};

            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_UserCoPhanQuyen", sqlPara))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }

            return new DataTable();
        }
        public DataTable GetUsersByConditions(string MaNguoiDung, bool kyten, bool doichieuSHPT = false)
        {
            var sqlPara = new SqlParameter[]{
                WorkingServices.GetParaFromOject("@MaNguoiDung", MaNguoiDung),
                WorkingServices.GetParaFromOject("@kyten", kyten),
                WorkingServices.GetParaFromOject("@doichieuSHPT", doichieuSHPT)};

            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_UserKhongKiemTraPhanQuyen", sqlPara))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }

            return new DataTable();
        }

        public BaseModel Insert_ql_nguoidung(QL_NGUOIDUNG objInfo)
        {
            var sqlPara = new SqlParameter[]{WorkingServices.GetParaFromOject("@maNguoiDung", objInfo.Manguoidung),
                WorkingServices.GetParaFromOject("@maNhanVien", objInfo.Manhanvien),
                WorkingServices.GetParaFromOject("@truc", objInfo.Truc),
                WorkingServices.GetParaFromOject("@bophan", objInfo.Bophan),
                WorkingServices.GetParaFromOject("@admin", objInfo.Isadmin),
                WorkingServices.GetParaFromOject("@matKhau", objInfo.Matkhau),
                WorkingServices.GetParaFromOject("@nguoitao", objInfo.Nguoitao)};
            if (!KiemTraTonTaiUser(objInfo.Manguoidung))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insUser", sqlPara),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã người dũng đã có."
                };
            }
        }
        public bool Update_ql_nguoidung(QL_NGUOIDUNG objInfo)
        {
            var sqlPara = new SqlParameter[]{WorkingServices.GetParaFromOject("@MaNguoiDung", objInfo.Manguoidung),
                WorkingServices.GetParaFromOject("@MaNhanVien", objInfo.Manhanvien),
                WorkingServices.GetParaFromOject("@Truc", objInfo.Truc),
                WorkingServices.GetParaFromOject("@BoPhan", objInfo.Bophan),
                WorkingServices.GetParaFromOject("@IsAdmin", objInfo.Isadmin),
                WorkingServices.GetParaFromOject("@NhanMau", objInfo.Nhanmau),
                WorkingServices.GetParaFromOject("@IDKhuLayMau", objInfo.Idkhulaymau),
                WorkingServices.GetParaFromOject("@KyTen", objInfo.Kyten),
                WorkingServices.GetParaFromOject("@DoiChieuSHPT", objInfo.DoiChieuSHPT),
                WorkingServices.GetParaFromOject("@Nguoisua", objInfo.Nguoisua),
                WorkingServices.GetParaFromOject("@DungKySo", objInfo.Dungkyso),
                WorkingServices.GetParaFromOject("@MaSoChuKySo", objInfo.Masochukyso),
                WorkingServices.GetParaFromOject("@KyTenLanhDao", objInfo.Kytenlanhdao),
                WorkingServices.GetParaFromOject("@Signpicture", objInfo.Signpicture, isImage:true)

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_ql_nguoidung", sqlPara) > -1;
        }
        public bool Delete_ql_nguoidung(QL_NGUOIDUNG objInfo, string useraction)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delUser", new SqlParameter[] { WorkingServices.GetParaFromOject("@maNguoiDung", objInfo.Manguoidung), WorkingServices.GetParaFromOject("@nguoiXoa", useraction) }) > -1;
        }
        public DataTable Get_NhanVien_NhanMau(string userLogIn)
        {
            var strSql = " select nv.MaNhanVien, nv.TenNhanVien, MaNguoiDung from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv inner join {{TPH_Standard}}_System.dbo.QL_NguoiDung nd on nv.MaNhanVien = nd.MaNhanVien";
            strSql += string.Format(" where nv.DaNghi = 0 and (nd.NhanMau = 1 or nd.MaNguoiDung  = '{0}') ", userLogIn);
            strSql += " order by nv.TenNhanVien";
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
        private string SQLSelect_Data_ql_nguoidung(string manguoidung)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_System.dbo.QL_NguoiDung where 1=1";
            if (!string.IsNullOrEmpty(manguoidung))
                sqlQuery += string.Format("\n and  manguoidung = {0}", "'" + manguoidung + "'");
            return sqlQuery;
        }
        public DataTable Data_ql_nguoidung(string manguoidung)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_ql_nguoidung(manguoidung)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_ql_nguoidung(DataGridView dtg, BindingNavigator bv, string manguoidung)
        {
            DataTable dtData = new DataTable();
            dtData = Data_ql_nguoidung(manguoidung);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_ql_nguoidung(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manguoidung)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_ql_nguoidung(manguoidung), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_ql_nguoidung(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manguoidung)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_ql_nguoidung(manguoidung);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public QL_NGUOIDUNG Get_Info_ql_nguoidung(string manguoidung)
        {
            DataTable dt = Data_ql_nguoidung(manguoidung);
            QL_NGUOIDUNG objInfo = new QL_NGUOIDUNG();
            if (dt.Rows.Count > 0)
            {
                var drInfo = dt.Rows[0];
                objInfo.Manguoidung = StringConverter.ToString(drInfo["manguoidung"]);
                if (!string.IsNullOrEmpty(drInfo["manhanvien"].ToString()))
                    objInfo.Manhanvien = StringConverter.ToString(drInfo["manhanvien"]);
                objInfo.Truc = NumberConverter.To<bool>(drInfo["truc"]);
                if (!string.IsNullOrEmpty(drInfo["bophan"].ToString()))
                    objInfo.Bophan = StringConverter.ToString(drInfo["bophan"]);
                objInfo.Isadmin = NumberConverter.To<bool>(drInfo["isadmin"]);
                if (!string.IsNullOrEmpty(drInfo["matkhau"].ToString()))
                    objInfo.Matkhau = StringConverter.ToString(drInfo["matkhau"]);
                if (!string.IsNullOrEmpty(drInfo["signpicture"].ToString()))
                    objInfo.Signpicture = Image.FromStream(new MemoryStream((byte[])drInfo["signpicture"]));
                objInfo.Nhanmau = NumberConverter.To<bool>(drInfo["nhanmau"]);
                if (!string.IsNullOrEmpty(drInfo["idkhulaymau"].ToString()))
                    objInfo.Idkhulaymau = StringConverter.ToString(drInfo["idkhulaymau"]);
                objInfo.Kyten = NumberConverter.To<bool>(drInfo["kyten"]);
                objInfo.DoiChieuSHPT = NumberConverter.To<bool>(drInfo["doichieushpt"]);
                if (!string.IsNullOrEmpty(drInfo["nguoitao"].ToString()))
                    objInfo.Nguoitao = StringConverter.ToString(drInfo["nguoitao"]);
                objInfo.Tgtao = (DateTime)drInfo["tgtao"];
                if (!string.IsNullOrEmpty(drInfo["nguoisua"].ToString()))
                    objInfo.Nguoisua = StringConverter.ToString(drInfo["nguoisua"]);
                if (!string.IsNullOrEmpty(drInfo["tgsua"].ToString()))
                    objInfo.Tgsua = (DateTime)drInfo["tgsua"];
                objInfo.Dungkyso = NumberConverter.To<bool>(drInfo["dungkyso"]);
                if (!string.IsNullOrEmpty(drInfo["masochukyso"].ToString()))
                    objInfo.Masochukyso = StringConverter.ToString(drInfo["masochukyso"]);
            }
            return objInfo;
        }
        public void Update_User_SinatureImage(string userID, Image img)
        {
            var byteImg = GraphicSupport.ImageToByteArray(img);
            string strSQL = "Update {{TPH_Standard}}_System.dbo.QL_NguoiDung set SignPicture=@HinhAnh where MaNguoiDung='" + userID + "'";
            DataProvider.ExcuteWithImage(strSQL, byteImg, img == null);
        }
        #endregion
        #region Phân quyền   
        public bool CopyPermissioin(string fromUser, string tosuer)
        {
            var sqlPara = new SqlParameter[] {
                new SqlParameter("@fromUser", fromUser)
                , new SqlParameter("@toUser", tosuer)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insPhanQuyen_Copy", sqlPara) > 0;

        }
        public DataTable DataDanhSachLoaiChuNang(string allowIDList)
        {
            var sqlQuery = string.Format("select p.MaPhanLoai as MaQuyen, p.TenPhanLoai as TenQuyen,p.MaPhanLoai as MaLoaiDichVu from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang p where EnumID in  (6,9,11,14,{0}) and KhongSuDung = 0", allowIDList);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachNhom(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaNhomCLS as MaQuyen, p.TenNhomCLS as TenQuyen, '{0}' as  MaLoaiDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom p", ServiceType.ClsXetNghiem.ToString());
            sqlQuery += string.Format("\nwhere exists (select top 1 * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where MaNguoiDung = '{0}' and MaLoaiDichVu = '{1}')"
                , maNguoiDung, ServiceType.ClsXetNghiem.ToString());
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaNhomSieuAm as MaQuyen, p.TenNhomSieuAm as TenQuyen, '{0}' as  MaLoaiDichVu from  {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm p", ServiceType.ClsSieuAm.ToString());
            sqlQuery += string.Format("\nwhere exists (select top 1 * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where MaNguoiDung = '{0}' and MaLoaiDichVu = '{1}')"
                , maNguoiDung, ServiceType.ClsSieuAm.ToString());
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaNhomNoiSoi as MaQuyen, p.TenNhomNoiSoi as TenQuyen, '{0}' as  MaLoaiDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi p ", ServiceType.ClsNoiSoi.ToString());
            sqlQuery += string.Format("\nwhere exists (select top 1 * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where MaNguoiDung = '{0}' and MaLoaiDichVu = '{1}')"
                , maNguoiDung, ServiceType.ClsNoiSoi.ToString());
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaKyThuatChup as MaQuyen, p.TenKyThuatChup as TenQuyen, '{0}' as  MaLoaiDichVu from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup p ", ServiceType.ClsXQuang.ToString());
            sqlQuery += string.Format("\nwhere exists (select top 1 * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where MaNguoiDung = '{0}' and MaLoaiDichVu = '{1}')"
                , maNguoiDung, ServiceType.ClsXQuang.ToString());
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaNhomCLS as MaQuyen, p.TenNhomCLS as TenQuyen, '{0}' as  MaLoaiDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac p ", ServiceType.DvKhac.ToString());
            sqlQuery += string.Format("\nwhere exists (select top 1 * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where MaNguoiDung = '{0}' and MaLoaiDichVu = '{1}')"
                , maNguoiDung, ServiceType.DvKhac.ToString());

            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachMayXetNghiem()
        {
            var sqlQuery = string.Format("select cast(p.idmay as varchar(5)) as MaQuyen, p.tenmay as TenQuyen, '{0}' as  MaLoaiDichVu  from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem p", ServiceType.ClsXetNghiem.ToString());
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachPhanQuyen(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaPhanQuyen as MaQuyen, p.MoTa  + '(' + p.MaPhanQuyen  + ')' as TenQuyen, p.MaLoaiDichVu from {{TPH_Standard}}_System.dbo.ql_dm_phanquyen p where MaLoaiDichVu in (select MaLoaiDichVu from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where MaNhomQuyen = '{0}' and MaNguoiDung = '{1}')"
                , FunctionGroup.LoaiChucNang.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }

        public DataTable DataDanhSachKhuVuc(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaKhuVuc as MaQuyen, p.TenKhuVuc as TenQuyen, '{0}' as  MaLoaiDichVu  from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC p", ServiceType.ClsXetNghiem.ToString());

            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }

        public DataTable DataDanhSachBoPhan(string maNguoiDung, bool isAdmin = false)
        {
            var sqlQuery = string.Format("select p.MaBoPhan as MaQuyen, p.TenBoPhan as TenQuyen, '{0}' as  MaLoaiDichVu  from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_BOPHAN p", ServiceType.ClsXetNghiem.ToString());
            if (!isAdmin)
                sqlQuery += string.Format(" and p.MaBoPhan in (select q.MaPhanQuyen from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q where q.MaNhomQuyen = '{0}' and q.MaNguoiDung = '{1}')", FunctionGroup.BoPhan.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachQuyenMayXetNghiem(string maNguoiDung)
        {
            var sqlQuery = string.Format("select cast(p.idmay as varchar(5)) as MaQuyen, p.tenmay as TenQuyen, q.MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaNguoiDung = '{1}' and cast(p.idmay as varchar(5)) = q.MaPhanQuyen) ", FunctionGroup.MayXetNghiem.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachQuyenLoaiChucNang(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaPhanLoai as MaQuyen, p.TenPhanLoai as TenQuyen, q.MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaNguoiDung = '{1}' and p.MaPhanLoai = q.MaPhanQuyen)"
                , FunctionGroup.LoaiChucNang.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachQuyenNhom(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaNhomCLS as MaQuyen, p.TenNhomCLS as TenQuyen,q. MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaLoaiDichVu = '{1}' and MaNguoiDung = '{2}' and p.MaNhomCLS = q.MaPhanQuyen)"
                , FunctionGroup.Nhom.ToString(), ServiceType.ClsXetNghiem.ToString(), maNguoiDung);
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaNhomSieuAm as MaQuyen, p.TenNhomSieuAm as TenQuyen,q. MaLoaiDichVu, q.MaNhomQuyen from  {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaLoaiDichVu = '{1}' and MaNguoiDung = '{2}' and p.MaNhomSieuAm = q.MaPhanQuyen)"
                , FunctionGroup.Nhom.ToString(), ServiceType.ClsSieuAm.ToString(), maNguoiDung);
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaNhomNoiSoi as MaQuyen, p.TenNhomNoiSoi as TenQuyen,q. MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaLoaiDichVu = '{1}' and MaNguoiDung = '{2}' and p.MaNhomNoiSoi = q.MaPhanQuyen)"
               , FunctionGroup.Nhom.ToString(), ServiceType.ClsNoiSoi.ToString(), maNguoiDung);
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaKyThuatChup as MaQuyen, p.TenKyThuatChup as TenQuyen,q. MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaLoaiDichVu = '{1}' and MaNguoiDung = '{2}' and p.MaKyThuatChup = q.MaPhanQuyen)"
             , FunctionGroup.Nhom.ToString(), ServiceType.ClsXQuang.ToString(), maNguoiDung);
            sqlQuery += "\nunion all";
            sqlQuery += string.Format("\nselect p.MaNhomCLS as MaQuyen, p.TenNhomCLS as TenQuyen,q. MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaLoaiDichVu = '{1}' and MaNguoiDung = '{2}' and p.MaNhomCLS = q.MaPhanQuyen)"
              , FunctionGroup.Nhom.ToString(), ServiceType.DvKhac.ToString(), maNguoiDung);

            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachQuyenKhuVuc(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaKhuVuc as MaQuyen, p.TenKhuVuc as TenQuyen, q.MaLoaiDichVu, q.MaNhomQuyen  from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaNguoiDung = '{1}' and p.MaKhuVuc = q.MaPhanQuyen)"
                , FunctionGroup.KhuVuc.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachQuyenBoPhan(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaBoPhan as MaQuyen, p.TenBoPhan as TenQuyen, q.MaLoaiDichVu, q.MaNhomQuyen  from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_BOPHAN p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaNguoiDung = '{1}' and p.MaBoPhan = q.MaPhanQuyen)"
                , FunctionGroup.BoPhan.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public DataTable DataDanhSachQuyenChucNang(string maNguoiDung)
        {
            var sqlQuery = string.Format("select p.MaPhanQuyen as MaQuyen, p.MoTa + '(' + p.MaPhanQuyen  + ')' as TenQuyen, q.MaLoaiDichVu, q.MaNhomQuyen from {{TPH_Standard}}_System.dbo.ql_dm_phanquyen p inner join {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen q on (q.MaNhomQuyen = '{0}' and q.MaNguoiDung = '{1}' and p.MaPhanQuyen = q.MaPhanQuyen)"
                , FunctionGroup.PhanQuyen.ToString(), maNguoiDung);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        #endregion
        #region ql_nguoidung_phanquyen
        public BaseModel Insert_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen (";
            sqlQuery += "\nManguoidung";
            sqlQuery += "\n,Maphanquyen";
            sqlQuery += "\n,Maloaidichvu";
            sqlQuery += "\n,Manhomquyen";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Manguoidung.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Maphanquyen.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Maloaidichvu == null ? "'0'" : "'" + Utilities.ConvertSqlString(objInfo.Maloaidichvu.ToString()) + "'"));
            sqlQuery += string.Format("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomquyen.ToString()).ToString() + "'");
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where Manguoidung =  " + "'" + Utilities.ConvertSqlString(objInfo.Manguoidung.ToString()).ToString() + "'" + " and Maphanquyen =  " + "'" + Utilities.ConvertSqlString(objInfo.Maphanquyen.ToString()).ToString() + "'" + " and Maloaidichvu =  " + (objInfo.Maloaidichvu == null ? "'0'" : "'" + Utilities.ConvertSqlString(objInfo.Maloaidichvu.ToString()) + "'") + " and Manhomquyen =  " + "'" + Utilities.ConvertSqlString(objInfo.Manhomquyen.ToString()).ToString() + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã bị trùng"
                };
            }
        }

        public bool Update_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo)
        {
            string sqlQuery = "Update {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen set";
            sqlQuery += string.Format("\n Manguoidung = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manguoidung.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Maphanquyen = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maphanquyen.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Maloaidichvu = {0}", (objInfo.Maloaidichvu == null ? "'0'" : "'" + Utilities.ConvertSqlString(objInfo.Maloaidichvu.ToString()) + "'"));
            sqlQuery += string.Format("\n, Manhomquyen = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomquyen.ToString()).ToString() + "'");
            sqlQuery += "\nwhere 1 = 1  and Manguoidung =  " + "'" + Utilities.ConvertSqlString(objInfo.Manguoidung.ToString()).ToString() + "'" + " and Maphanquyen =  " + "'" + Utilities.ConvertSqlString(objInfo.Maphanquyen.ToString()).ToString() + "'" + " and Maloaidichvu =  " + (objInfo.Maloaidichvu == null ? "'0'" : "'" + Utilities.ConvertSqlString(objInfo.Maloaidichvu.ToString()) + "'") + " and Manhomquyen =  " + "'" + Utilities.ConvertSqlString(objInfo.Manhomquyen.ToString()).ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_ql_nguoidung_phanquyen(QL_NGUOIDUNG_PHANQUYEN objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += string.Format("\n and Manguoidung = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manguoidung.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n and Maphanquyen = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maphanquyen.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n and Maloaidichvu = {0}", (objInfo.Maloaidichvu == null ? "'0'" : "'" + Utilities.ConvertSqlString(objInfo.Maloaidichvu.ToString()) + "'"));
            sqlQuery += string.Format("\n and Manhomquyen = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomquyen.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_System.dbo.ql_nguoidung_phanquyen where 1=1";
            if (!string.IsNullOrEmpty(manguoidung))
                sqlQuery += string.Format("\n and  manguoidung = {0}", "'" + manguoidung + "'");
            if (!string.IsNullOrEmpty(maphanquyen))
                sqlQuery += string.Format("\n and  maphanquyen = {0}", "'" + maphanquyen + "'");
            if (!string.IsNullOrEmpty(maloaidichvu))
                sqlQuery += string.Format("\n and  maloaidichvu = {0}", "'" + maloaidichvu + "'");
            if (!string.IsNullOrEmpty(manhomquyen))
                sqlQuery += string.Format("\n and  manhomquyen = {0}", "'" + manhomquyen + "'");
            return sqlQuery;
        }
        public DataTable Data_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_ql_nguoidung_phanquyen(DataGridView dtg, BindingNavigator bv, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            DataTable dtData = new DataTable();
            dtData = Data_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_ql_nguoidung_phanquyen(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_ql_nguoidung_phanquyen(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public QL_NGUOIDUNG_PHANQUYEN Get_Info_ql_nguoidung_phanquyen(string manguoidung, string maphanquyen, string maloaidichvu, string manhomquyen)
        {
            DataTable dt = Data_ql_nguoidung_phanquyen(manguoidung, maphanquyen, maloaidichvu, manhomquyen);
            QL_NGUOIDUNG_PHANQUYEN obj = new QL_NGUOIDUNG_PHANQUYEN();
            if (dt.Rows.Count > 0)
            {
                obj.Manguoidung = dt.Rows[0]["manguoidung"].ToString();
                obj.Maphanquyen = dt.Rows[0]["maphanquyen"].ToString();
                obj.Maloaidichvu = dt.Rows[0]["maloaidichvu"].ToString();
                obj.Manhomquyen = dt.Rows[0]["manhomquyen"].ToString();
            }
            return obj;
        }
        #endregion
        #region Nhóm phân quyền
        public int Insert_NhomPhanQuyen(string maNhomPhanQuyen, string tenNhomPhanQuyen, string heThong)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuyen", maNhomPhanQuyen)
                , new SqlParameter("@TenNhomPhanQUyen", tenNhomPhanQuyen)
            , new SqlParameter("@HeThong", heThong)};
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insNhomPhanQuyen", sqlPara);
        }
        public int Update_NhomPhanQuyen(string maNhomPhanQuyen, string tenNhomPhanQuyen, string heThong)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuyen", maNhomPhanQuyen)
                , new SqlParameter("@TenNhomPhanQUyen", tenNhomPhanQuyen) , new SqlParameter("@HeThong", heThong)};
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updNhomPhanQuyen", sqlPara);
        }
        public int Delete_NhomPhanQuyen(string maNhomPhanQuyen, string heThong)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuyen", maNhomPhanQuyen), new SqlParameter("@HeThong", heThong) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delNhomPhanQuyen", sqlPara);
        }
        public DataTable Data_NhomPhanQuyen(string heThong)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNhomPhanQuyen", new SqlParameter("@HeThong", heThong));
            return ds == null ? null : ds.Tables[0];
        }
        #endregion
        #region Chi tiết nhóm quyền
        public int Insert_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen, string maPhanQuyen, string maNhomQuyen)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuyen", maNhomPhanQuyen)
                , new SqlParameter("@MaPhanQuyen", maPhanQuyen)
                , new SqlParameter("@MaNhomQuyen", maNhomQuyen)};
            return (int)(DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insNhomPhanQuyen_ChiTiet", sqlPara) ?? 0);
        }
        public int Delete_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen, string maPhanQuyen, string maNhomQuyen)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuyen", maNhomPhanQuyen)
                , new SqlParameter("@MaPhanQuyen", maPhanQuyen)
                , new SqlParameter("@MaNhomQuyen", maNhomQuyen) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delNhomPhanQuyen_ChiTiet", sqlPara);
        }
        public DataTable Data_NhomPhanQuyen_ChiTiet(string maNhomPhanQuyen)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuen", maNhomPhanQuyen) };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNhomPhanQuyenChiTiet", sqlPara);
            return ds == null ? null : ds.Tables[0];
        }
        public DataTable Data_PhanQuyen_ChuaAddNhom(string maNhomPhanQuyen)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuen", maNhomPhanQuyen) };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selPhanQuyen_ChuaAddNhom", sqlPara);
            return ds == null ? null : ds.Tables[0];
        }
        #endregion
        #region Phân quyền cho user
        public DataTable Data_DanhSach_QuyenUser(string maNguoiDung)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNguoiDung", maNguoiDung) };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selPhanQuyen_DaCap_User_TheoNhomPhanQuyen", sqlPara);
            return ds == null ? null : ds.Tables[0];
        }
        public int Insert_PhanQuyen_QuyenUser(string maNhomPhanQuyen, string maNguoiDung)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@MaNhomPhanQuyen", maNhomPhanQuyen), new SqlParameter("@MaNguoiDung", maNguoiDung) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insPhanQuyen_CapQuyenUser_TheoNhom", sqlPara);
        }
        public int Delete_PhanQuyen_QuyenUser(string maNguoiDung, string maPhanQuyen, string maNhomQuyen, string maLoaiDichVu)
        {
            //create proc delPhanQuyen_DaCap_User
            //@MaNguoiDung varchar(20)
            //, @MaPhanQuyen varchar(20)
            // , @MaNhomQuyen varchar(20)
            // , @MaLoaiDichVu varchar(20)

            var sqlPara = new SqlParameter[] {
                new SqlParameter("@MaNguoiDung", maNguoiDung)
                , new SqlParameter("@MaPhanQuyen", maPhanQuyen)
                , new SqlParameter("@MaNhomQuyen", maNhomQuyen)
                 , new SqlParameter("@MaLoaiDichVu", maLoaiDichVu)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delPhanQuyen_DaCap_User", sqlPara);
        }
        public DataTable GetUsersKyTenCoPhanQuyenQC()
        {
            using (var users = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNguoiDung_DanhSachCoQuyenQC"))
            {
                if (users != null && users.Tables.Count > 0)
                {
                    return users.Tables[0];
                }
            }
            return new DataTable();
        }
        #endregion
        #region ql_nguoidung_nhomphanquyen
        public int Insert_ql_nguoidung_nhomphanquyen(QL_NGUOIDUNG_NHOMPHANQUYEN objInfo)
        {
            if (CheckExists_ql_nguoidung_nhomphanquyen(objInfo.Manguoidung, objInfo.Manhomphanquyen)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNguoiDung", objInfo.Manguoidung),
                        WorkingServices.GetParaFromOject("@MaNhomPhanQuyen", objInfo.Manhomphanquyen),
                        WorkingServices.GetParaFromOject("@NguoiCap", objInfo.Nguoicap),
                        WorkingServices.GetParaFromOject("@Hethong", objInfo.Hethong)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_ql_nguoidung_nhomphanquyen", para);
        }
        public int Delete_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNguoiDung", manguoidung),
                        WorkingServices.GetParaFromOject("@MaNhomPhanQuyen", manhomphanquyen)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_ql_nguoidung_nhomphanquyen", para);
        }
        public DataTable Data_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNguoiDung", manguoidung),
                        WorkingServices.GetParaFromOject("@MaNhomPhanQuyen", manhomphanquyen)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_ql_nguoidung_nhomphanquyen", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public QL_NGUOIDUNG_NHOMPHANQUYEN Get_Info_ql_nguoidung_nhomphanquyen(DataRow drInfo)
        {
            return (QL_NGUOIDUNG_NHOMPHANQUYEN)WorkingServices.Get_InfoForObject(new QL_NGUOIDUNG_NHOMPHANQUYEN(), drInfo);
        }
        public QL_NGUOIDUNG_NHOMPHANQUYEN Get_Info_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            DataTable dt = Data_ql_nguoidung_nhomphanquyen(manguoidung, manhomphanquyen);
            QL_NGUOIDUNG_NHOMPHANQUYEN obj = new QL_NGUOIDUNG_NHOMPHANQUYEN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_ql_nguoidung_nhomphanquyen(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_ql_nguoidung_nhomphanquyen(string manguoidung, string manhomphanquyen)
        {
            return Data_ql_nguoidung_nhomphanquyen(manguoidung, manhomphanquyen).Rows.Count > 0;
        }

        #endregion

        #region Chấm công
        public bool Insert_User_ChamCong(string maNhanVien)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", maNhanVien),
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "FX_ins_User_ChamCong", para) > 0;

        }
        public bool User_ChamCongRaVe(string maNhanVien)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", maNhanVien),
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "FX_upd_User_ChamCongRaVe", para) > 0;
        }

        public DataTable DanhSachChamCong(string maNhanVien)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", maNhanVien)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_DanhSachChamCong", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable DuLieuChamCong(string maNhanVien, string maBP, string maCV)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", maNhanVien),
                        WorkingServices.GetParaFromOject("@MaBoPhan", maBP),
                        WorkingServices.GetParaFromOject("@MaChucVu", maCV)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "FX_sel_DuLieuChamCong", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion
    }
}
