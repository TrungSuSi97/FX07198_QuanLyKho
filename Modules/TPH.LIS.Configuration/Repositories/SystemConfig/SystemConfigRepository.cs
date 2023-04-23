using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Model;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.User.Enum;
using StringConverter = TPH.Common.Converter.StringConverter;

namespace TPH.LIS.Configuration.Repositories.SystemConfig
{
    public class SystemConfigRepository : ISystemConfigRepository
    {
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
        #region Cấu hình hệ thống
        public ConfigurationDetail GetSystemConfigurationDetail(string withLocationID = "")
        {
            using (var reader = DataProvider.ExecuteReader(CommandType.StoredProcedure, "selCauHinhHeThong"
                , new SqlParameter[] {
                    WorkingServices.GetParaFromOject("@PCname",string.IsNullOrEmpty(withLocationID)? CommonConfigConstant.AllComputer: withLocationID)
                  , WorkingServices.GetParaFromOject("@LocationID", withLocationID) }))
            {
                if (!reader.HasRows)
                {
                    ((IDisposable)reader).Dispose();
                    return null;
                }
                ConfigurationDetail config = new ConfigurationDetail();
                while (reader.Read())
                {

                    foreach (
                        PropertyInfo minfo in
                            typeof(ConfigurationDetail).GetProperties())
                    {
                        if (minfo.Name.Equals(StringConverter.ToString(reader["MaCauHinh"]).Trim(),
                            StringComparison.OrdinalIgnoreCase))
                        {
                            if (minfo.GetSetMethod() != null)
                            {
                                if (minfo.PropertyType == typeof(bool))
                                    minfo.SetValue(config
                                        , (NumberConverter.ToInt(reader["GiaTri"]) == 1)
                                        , null);
                                else if (minfo.PropertyType == typeof(Common.EnumReportResultTemplatetype))
                                    minfo.SetValue(config
                                        , (Common.EnumReportResultTemplatetype)Enum.Parse(typeof(Common.EnumReportResultTemplatetype), reader["GiaTri"].ToString())
                                        , null);
                                else if (minfo.PropertyType == typeof(Common.EnumKieuLayKetQuaMay))
                                    minfo.SetValue(config
                                        , (Common.EnumKieuLayKetQuaMay)Enum.Parse(typeof(Common.EnumKieuLayKetQuaMay), reader["GiaTri"].ToString())
                                        , null);
                                else if (minfo.PropertyType == typeof(Common.EnumLoaiKetNoiMay))
                                    minfo.SetValue(config
                                        , (Common.EnumLoaiKetNoiMay)Enum.Parse(typeof(Common.EnumLoaiKetNoiMay), reader["GiaTri"].ToString())
                                        , null);
                                else if (minfo.PropertyType == typeof(EnumQuiTrinhLAB))
                                    minfo.SetValue(config
                                        , (EnumQuiTrinhLAB)Enum.Parse(typeof(EnumQuiTrinhLAB), reader["GiaTri"].ToString())
                                        , null);
                                else if (reader["GiaTri"] != null)
                                {
                                    if (!string.IsNullOrEmpty(reader["GiaTri"].ToString()))
                                    {
                                        minfo.SetValue(config
                                            , Convert.ChangeType(reader["GiaTri"], minfo.PropertyType)
                                            , null);
                                    }
                                }
                            }
                        }
                    }
                }
                ((IDisposable)reader).Dispose();
                return config;
            }
        }
        public void InsertUpdateConfiguationDetail(ConfigurationDetail objconfig)
        {
            string strSQL = String.Empty;
            string configID = string.Empty;
            string configValue = string.Empty;
            PropertyInfo[] fiCheck = objconfig.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                configID = f.Name;
                configValue = (f.GetValue(objconfig, null) == null
                    ? string.Empty
                    : f.GetValue(objconfig, null).ToString());

                if (f.PropertyType == typeof(bool))
                {
                    configValue = (configValue.Equals("true", StringComparison.OrdinalIgnoreCase) ? "1" : "0");
                }
                else if (f.PropertyType == typeof(Common.EnumReportResultTemplatetype))
                    configValue = ((int)((Common.EnumReportResultTemplatetype)Enum.Parse(typeof(Common.EnumReportResultTemplatetype), configValue))).ToString();

                SaveConfig_WithConfigID(configID, objconfig.LuuCauHinhTheoKhuVuc, configValue);
            }
        }
        public int SaveConfig_WithConfigID(string maCauHinh, string mayTinh, string giaTri)
        {
            string strSQL = "begin tran upd1";
            strSQL += "\nif exists (Select * from {{TPH_Standard}}_System.dbo.cauhinh_hethong where MaCauHinh = '" + maCauHinh + "' and MayTinh = '" + mayTinh + "')";
            strSQL += "\nbegin";
            strSQL += "\nUpdate {{TPH_Standard}}_System.dbo.cauhinh_hethong set GiaTri = " +
                      (string.IsNullOrEmpty(giaTri)
                          ? "NULL"
                          : "N'" + Utilities.ConvertSqlString(giaTri) + "'");
            strSQL += "\nwhere MaCauHinh = '" + maCauHinh + "' and MayTinh = '" + mayTinh + "'";
            strSQL += "\nend";
            strSQL += "\nelse";
            strSQL += "\nbegin";
            strSQL += "\nInsert into {{TPH_Standard}}_System.dbo.cauhinh_hethong (MaCauHinh,MayTinh, GiaTri) values ('" + maCauHinh + "','" +
                      mayTinh + "', " +
                      (string.IsNullOrEmpty(giaTri)
                          ? "NULL"
                          : "N'" + Utilities.ConvertSqlString(giaTri) + "'") + ")";
            strSQL += "\nend";
            strSQL += "\nCOMMIT TRANSACTION upd1";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSQL);
        }
        public void AddNewTest(string code, string name, string group, string unit,
            string normal, string lower, string upper, string price, string boldName,
            string boldResult, string mainTest, string criteria, string sampleType
            , string printNo, string orderNo, bool ignoreCheckResult)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem (khongsd,MaXN, TenXN, MaNhomCLS, DonVi, CSBT, NguongDuoi, " +
                           "NguongTren, GiaChuan, InDam, InDamKQ, XNChinh, DKDanhGia, LoaiMau, ThuTuIn,SapXep,KhongDanhGia)" +
                           "\n select 1,'" + code + "',N'" + Utilities.ConvertSqlString(name) + "','" + group + "',N'" + unit +
                           "',N'" + normal + "'," + lower + "\n ," + upper + "," +
                           price + "\n," + boldName + "," + boldResult + "," + mainTest +
                           "," + criteria + "," + sampleType + "," + printNo
                           + "," + (string.IsNullOrEmpty(orderNo) ? "1000" : orderNo)
                           + "," + (ignoreCheckResult ? "1" : "0");

            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public bool Check_ExistsMaXN(string MaXN)
        {
            var sqlQuery = string.Format("select MaXN from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem where MaXN = '{0}'", MaXN);
            return DataProvider.CheckExisted(sqlQuery);
        }
        public int Check_UpdateSoftware(string pcName, string fileVersion, string appName)
        {
            var splitVersion = fileVersion.Split('.');
            if (splitVersion.Length == 4)
            {
                fileVersion = string.Format("{0}.{1:00}.{2:00}.{3}", splitVersion[0], int.Parse(splitVersion[1]), int.Parse(splitVersion[2]), splitVersion[3]);
            }
            SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@pcName", pcName)
                    , new SqlParameter("@version", fileVersion)
                    , new SqlParameter("@appFileName", appName)
                };
            var dataA = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selCheckUpdateSoftwareByApp", para);
            if (dataA != null)
            {
                var data = dataA.Tables[0];
                if (data.Rows.Count > 0)
                {
                    return int.Parse(data.Rows[0]["NeedUpdate"].ToString());
                }
                else
                {
                    para = new SqlParameter[]
                   {
                    new SqlParameter("@pcName", pcName),
                     new SqlParameter("@AppName", appName)
                   };
                    DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insPcUpdateSoftware", para);
                }
            }

            return 0;
        }
        public int Update_PcLogin(string pcName, string versionId, string ip, string appName)
        {
            SqlParameter[] para = new SqlParameter[]
               {
                    new SqlParameter("@pcName", pcName),
                     new SqlParameter("@versionID", versionId),
                    new SqlParameter("@IP", ip),
                    new SqlParameter("@Appname", appName)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updPcLoginWithIP", para);
        }

        public int Update_PcLogin_FileInfo(string pcName, string fileInfo)
        {
            SqlParameter[] para = new SqlParameter[]
               {
                    new SqlParameter("@pcName", pcName),
                     new SqlParameter("@FileInfo", fileInfo)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updPcFileInfo", para);
        }

        #endregion
        //================================|||=====================================
        #region Cấu hình danh mục loại dịch vụ
        public DataTable Data_CauHinh_PhanLoaiChucNang(string filter)
        {
            var sqlQuery = string.Format(" select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang where 0=0 \n {0} order by TenPhanLoai", filter);
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public void Get_CauHinh_PhanLoaiChucNang(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = Data_CauHinh_PhanLoaiChucNang(filter);
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaPhanLoai", "TenPhanLoai");
        }
        public void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, string filter)
        {
            var dt = Data_CauHinh_PhanLoaiChucNang(filter);
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaPhanLoai", "MaNhap");
        }
        public void Get_CauHinh_PhanLoaiChucNang(CustomComboBox cbo, TextBox txt, string filter)
        {
            var dt = Data_CauHinh_PhanLoaiChucNang(filter);
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaPhanLoai", "MaNhap", "MaPhanLoai, MaNhap, TenPhanLoai",
                "50,50, 150", txt, 2);
        }
        #endregion
        //================================|||=====================================
        #region Load danh sách tổng hợp
        public DataTable Load_Nhom_TheoDVCLS(string loaiDichVu, string filter = "")
        {
            DataTable dataNhom = new DataTable();
            if (loaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = GetTestGroup(string.Empty, filter);
            }
            else if (loaiDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = Get_NhomCLS_SieuAm(null, string.Empty);
            }
            else if (loaiDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = Get_DM_XQuang_KyThuat(null);
            }
            else if (loaiDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = Get_NhomCLS_NoiSoi(null, string.Empty);
            }
            else if (loaiDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = Get_DM_KhamBenh_NhomDichVu(null, string.Empty, null);
            }
            else if (loaiDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = Get_DM_NHOMCLS_DVKHAC(null, string.Empty);
            }
            else if (loaiDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                dataNhom = Get_DM_Thuoc_NhomThuoc(null);
            }
            //else if (loaiDichVu.Equals(ServiceType.ClsXNViSinh.ToString(), StringComparison.OrdinalIgnoreCase))
            //{
            //    dataNhom = _bacteriumAntibioticService.Data_dm_xetnghiem_nhomyeucauvisinh(string.Empty);
            //}
            dataNhom = ConvertColumnName_DanhMucDichVu(dataNhom);
            return dataNhom;
        }
        public DataTable Load_ChiDinhCLS(CustomComboBox cbo, string loaiDichVu, string nhomCd, string sex
            , string maDoiTuongDv, string filter = "", bool ForClick = true, bool forConfig = false)
        {
            var data = new DataTable();
            if (loaiDichVu.Equals(ServiceType.ClsXetNghiem.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                if (forConfig)
                {
                    data = GetSubclinicalTest_NoProfile(nhomCd);
                }
                else
                {
                    if (ForClick)
                        data = GetSubclinicalTest_NoProfile(nhomCd);
                    else
                        data = GetSubclinicalTestAndProfile(cbo, nhomCd, maDoiTuongDv, filter);
                }
            }
            else if (loaiDichVu.Equals(ServiceType.ClsSieuAm.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                data = Get_DMSieuAm(cbo,
                      (string.IsNullOrWhiteSpace(sex)
                          ? string.Empty
                          : sex == "?"
                              ? string.Empty
                              : " and (GioiTinhSuDung = '" + sex + "'  or GioiTinhSuDung = 'A')") +
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomSieuAm = '" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (loaiDichVu.Equals(ServiceType.ClsXQuang.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                data = Get_DM_XQuang_VungChup(cbo,
                     (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaKyThuatChup = '" + nhomCd + "'"),
                     maDoiTuongDv);
            }
            else if (loaiDichVu.Equals(ServiceType.ClsNoiSoi.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                data = Get_DMNoiSoi(cbo,
                      (string.IsNullOrWhiteSpace(sex)
                          ? string.Empty
                          : sex == "?"
                              ? string.Empty
                              : " and (GioiTinhSuDung = '" + sex + "' or GioiTinhSuDung = 'A')") +
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomNoiSoi = '" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (loaiDichVu.Equals(ServiceType.KhamBenh.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                data = Get_DM_KhamBenh_DichVu(cbo, nhomCd, string.Empty, null, maDoiTuongDv);
            }
            else if (loaiDichVu.Equals(ServiceType.DvKhac.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                data = Get_DM_DICHVUKHAC(cbo,
                      (string.IsNullOrWhiteSpace(nhomCd) ? string.Empty : " and MaNhomCLS ='" + nhomCd + "'"),
                      maDoiTuongDv);
            }
            else if (loaiDichVu.Equals(ServiceType.Duoc.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                data = Data_DM_Thuoc_ForWork(cbo, "MaVatTu", "MaVatTu",
                     "MaVatTu, TenVatTu, TonKho, DonViTinh, GiaRieng", "50,150,30,40,50", null, 0, string.Empty,
                     nhomCd, maDoiTuongDv);
            }
            //else if (loaiDichVu.Equals(ServiceType.ClsXNViSinh.ToString(), StringComparison.OrdinalIgnoreCase))
            //{
            //    data = _bacteriumAntibioticService.Get_Data_dm_xetnghiem_yeucauvisinh(cbo, "MaYeuCau", "MaYeuCau", "MaYeuCau,TenYeuCau, MaNhomYeuCau", "50,250,50", null, -1, string.Empty, nhomCd);
            //}
            else
            {
                data = new DataTable();
            }
            return ConvertColumnName_DanhMucDichVu(data);
        }
        public DataTable ConvertColumnName_DanhMucDichVu(DataTable _danhSachChiDinh)
        {
            //ConvertColumnsName
            if (!_danhSachChiDinh.Columns.Contains("IsProfile"))
            {
                _danhSachChiDinh.Columns.Add("IsProfile", typeof(string));
                foreach (DataRow dr in _danhSachChiDinh.Rows)
                {
                    dr["IsProfile"] = ProfileTestContant.TestChar;
                }
            }

            foreach (DataColumn dc in _danhSachChiDinh.Columns)
            {
                if (dc.ColumnName.Equals("MaXN", StringComparison.OrdinalIgnoreCase)
                    || dc.ColumnName.Equals("MaYeuCau", StringComparison.OrdinalIgnoreCase)
                    || dc.ColumnName.Equals("MaVungChup", StringComparison.OrdinalIgnoreCase)
                    || dc.ColumnName.Equals("MaSoMau", StringComparison.OrdinalIgnoreCase)
                    || dc.ColumnName.Equals("MaSoMauNoiSoi", StringComparison.OrdinalIgnoreCase)
                    || dc.ColumnName.Equals("madvkhac", StringComparison.OrdinalIgnoreCase)
                    || dc.ColumnName.Equals("MaVatTu", StringComparison.OrdinalIgnoreCase)
                    )
                    dc.ColumnName = "MaDichVu".ToLower();
                else if (dc.ColumnName.Equals("TenXN", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenYeuCau", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenVungChup", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenMauSieuAm", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenMauNoiSoi", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("tendvkhac", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenVatTu", StringComparison.OrdinalIgnoreCase)
                     )
                    dc.ColumnName = "TenDichVu".ToLower();
                else if (dc.ColumnName.Equals("MaNhomCLS", StringComparison.OrdinalIgnoreCase)
                       || dc.ColumnName.Equals("MaNhomSieuAm", StringComparison.OrdinalIgnoreCase)
                       || dc.ColumnName.Equals("MaNhomNoiSoi", StringComparison.OrdinalIgnoreCase)
                       || dc.ColumnName.Equals("MaNhomThuoc", StringComparison.OrdinalIgnoreCase)
                       || dc.ColumnName.Equals("MaKyThuatChup", StringComparison.OrdinalIgnoreCase)
                       || dc.ColumnName.Equals("manhomcls", StringComparison.OrdinalIgnoreCase)
                       || dc.ColumnName.Equals("MaNhomDichVu", StringComparison.OrdinalIgnoreCase)
                         || dc.ColumnName.Equals("MaNhomYeuCau", StringComparison.OrdinalIgnoreCase)
                       )
                    dc.ColumnName = "MaNhomDichVu".ToLower();
                else if (dc.ColumnName.Equals("TenNhomCLS", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomSieuAm", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomNoiSoi", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomThuoc", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenKyThuatChup", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("tennhomcls", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomDichVu", StringComparison.OrdinalIgnoreCase)
                      || dc.ColumnName.Equals("TenNhomYeuCau", StringComparison.OrdinalIgnoreCase)
                     )
                    dc.ColumnName = "TenNhomDichVu".ToLower();
                else if (dc.ColumnName.Equals("MaGoTat", StringComparison.OrdinalIgnoreCase) || dc.ColumnName.Equals("GoTat", StringComparison.OrdinalIgnoreCase))
                    dc.ColumnName = "magotat".ToLower();
            }
            return _danhSachChiDinh;
        }
        #endregion
        //================================|||=====================================
        #region Chưa phân loại
        public DataTable GetTestGroup(string filter, string filter2 = "")
        {
            var sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom(nolock) where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " and  MaNhomCLS in (" + (filter.Contains("'") ? string.Format("{0}", filter) : string.Format("'{0}'", filter)) + ")";
            }
            sqlQuery += " order by  MaNhomCLS,ThuTuIn";

            using (var testGroups = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery))
            {
                if (testGroups != null && testGroups.Tables.Count > 0)
                {
                    return testGroups.Tables[0];
                }
            }
            return null;
        }
        public DataTable GetSubclinical(string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.cauhinh_phanloaichucnang(nolock) where 1=1 ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += filter;
            }

            sqlQuery += " order by  TenPhanLoai";

            using (var testGroups = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery))
            {
                if (testGroups != null && testGroups.Tables.Count > 0)
                {
                    return testGroups.Tables[0];
                }
            }

            return null;
        }
        public DataTable GetSubclinical(ref SqlDataAdapter da, ref DataTable data, string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.cauhinh_phanloaichucnang(nolock) where 1=1 ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += filter;
            }

            sqlQuery += " order by  TenPhanLoai";

            DataProvider.SelInsUpdDelODBC(sqlQuery, ref da, ref data);

            return data;
        }
        public DataTable GetSubclinicalTest_NoProfile(string filter)
        {
            var strSql = "select x.ManhomCLS,cast(0 as bit) as tudongchon,'" + ProfileTestContant.TestChar + "' as IsProfile, x.MAXN,x.MaGoTat,x.TenXN as TenXN, x.GiaChuan as GiaRieng, x.SapXep, 'B' as sortGroup, n.TenNhomCLS from  {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem x";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on n.MaNhomCLS = x.ManhomCLS";
            strSql += "\nwhere x.khongsd = 1 " +
                       (string.IsNullOrWhiteSpace(filter) ? string.Empty : " and x.MaNhomCLS in (" + (filter.Contains("'") ? filter : (string.Format("'{0}'", filter))) + ")");
            strSql += " order by x.ThuTuIn, x.SapXep, x.MAXN, x.TenXN, x.MaNhomCLS";

            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
        public DataTable GetData_Profile_SLSS()
        {
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_Profile_SLSS").Tables[0];
        }
        public DataTable GetSubclinicalTestAndProfile(CustomComboBox cbo, string maNhom, string maDoiTuongDv, string filter2 = "", bool checkMagoTat = true)
        {
            var strSql = "select A.*, isnull (n.TenNhomCLS, N'---') as TenNhomCLS from (";
            strSql += "\nselect ManhomCLS,cast(0 as bit) as tudongchon,'" + ProfileTestContant.TestChar + "' as IsProfile, MAXN,MaGoTat, ltrim(TenXN) as TenXN,GiaChuan as GiaRieng,SapXep, cast (2 as int) as ShowOrder, LoaiXetNghiem from  {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem where 1 =1 " + (checkMagoTat ? " and magotat is not null " : "") +
                       (string.IsNullOrWhiteSpace(maNhom) ? string.Empty : " and MaNhomCLS ='" + maNhom + "'");
            if (!string.IsNullOrWhiteSpace(filter2))
            {
                strSql += filter2 + "\n";
            }
            strSql += " union all \n" +
                       "select ManhomCLS,tudongchon,'" + ProfileTestContant.ProfileChar + "' as IsProfile,ProfileID as MaXN,ProfileID as MaGoTat, '" + ProfileTestContant.ProfileChar + " '  + ltrim(ProfileName) as TenXN,0,0, cast (1 as int) as ShowOrder, cast(0 as int) LoaiXetNghiem from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile where 0=0 \n";
            if (!string.IsNullOrWhiteSpace(maNhom))
            {
                strSql += " and MaNhomCLS ='" + maNhom + "'";
            }

            strSql += " union all \n" +
                   "select '' as ManhomCLS,cast(0 as bit) as tudongchon,'" + ProfileTestContant.GroupChar + "' as IsProfile,MaBoXetNghiem as MaXN,MaBoXetNghiem as MaGoTat, '" + ProfileTestContant.GroupChar + " '  + ltrim(TenBoXetNghiem) as TenXN,0,0, cast (0 as int) as ShowOrder, cast(0 as int) LoaiXetNghiem from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_BO \n";

            strSql += "\n) as A left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on a.MaNhomCLS=n.MaNhomCLS\n";

            //strSql += " order by A.SapXep,A.isProfile,A.MaXN";
            strSql += " order by A.ShowOrder, A.MaXN";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                if (!string.IsNullOrWhiteSpace(maDoiTuongDv))
                {
                    cbo.ColumnNames = "IsProfile,MaGoTat,TenXN,MaXN";
                    cbo.ColumnWidths = "0,90,350";
                }
                else
                {
                    cbo.ColumnNames = "IsProfile,MaGoTat,TenXN,MaXN";
                    cbo.ColumnWidths = "0,90,200";
                }

                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaXN", "MaGoTat");
            }

            return dt;
        }
        public void Addrange(ListViewItem it, ListViewGroup grp, DataRow item, int indexNormal)
        {
            it.Text = item["TenThuoc"].ToString();
            if (it.Text.ToLower().Contains("sổ"))
            {
                it.ImageIndex = (indexNormal + 1);
            }
            else if (it.Text.ToLower().Contains("khám"))
            {
                it.ImageIndex = (indexNormal + 2);
            }
            else if (it.Text.ToLower().Contains("tiêm") || item["TenNhomThuoc"].ToString().ToLower().Contains("ngừa"))
            {
                it.ImageIndex = (indexNormal + 3);
            }
            else if (it.Text.ToLower().Contains("siêu âm"))
            {
                it.ImageIndex = (indexNormal + 4);
            }
            else if (it.Text.ToLower().Contains("điện tim"))
            {
                it.ImageIndex = (indexNormal + 5);
            }
            else
            {
                it.ImageIndex = indexNormal;
            }

            it.Name = item["MaThuoc"].ToString();
            // it.Tag = (bool)item["SeriumType"];
            it.Group = grp;
        }
        public DataTable GetTestCaculate(string filter)
        {
            var sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_TinhToan(nolock)";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += filter;
            }
            sqlQuery += " order by MaXN";

            using (var profiles = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery))
            {
                if (profiles != null && profiles.Tables.Count > 0)
                {
                    return profiles.Tables[0];
                }
            }

            return null;
        }
        public void GetTestCaculate(ref SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_TinhToan";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where " + filter;
            }
            strSql += " order by MaXN, GioiTinh ASC";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable GetTestingMachines()
        {
            var sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem";

            using (var testGroups = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery))
            {
                if (testGroups != null && testGroups.Tables.Count > 0)
                {
                    return testGroups.Tables[0];
                }
            }

            return null;
        }
        public BaseModel AddNewTestingMachine(TestingMachineModel testingMachineInfo)
        {
            var sqlQueryCheckExisted = "Select * from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem where idmay = '" + testingMachineInfo.Id + "'";
            if (DataProvider.CheckExisted(sqlQueryCheckExisted))
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã máy đã tồn tại ! \nHãy nhập mã máy khác."
                };
            }

            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem (";
            sqlQuery += "\nidmay,loaiketnoi,protocol,tenmay,tudongvalid)";
            sqlQuery += "\nValues (@idmay,@loaiketnoi,@protocol,@tenmay,@tudongvalid)";
            var param = new SqlParameter[]
            {
                new SqlParameter("@Idmay", testingMachineInfo.Id),
                new SqlParameter("@Loaiketnoi", testingMachineInfo.ConnectionType),
                new SqlParameter("@Protocol", testingMachineInfo.Protocol),
                new SqlParameter("@Tenmay", testingMachineInfo.Name),
                new SqlParameter("@Tudongvalid", testingMachineInfo.IsAuto)
            };

            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery, param),
                Name = string.Empty
            };
        }
        public BaseModel UpdateTestingMachine(TestingMachineModel testingMachineInfo)
        {
            var sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem set";
            sqlQuery +=
                "\nloaiketnoi = @loaiketnoi,protocol = @protocol,tenmay = @tenmay,tudongvalid = @tudongvalid where idmay = @idmay";
            var param = new SqlParameter[]
            {
                new SqlParameter("@Idmay", testingMachineInfo.Id),
                new SqlParameter("@Loaiketnoi", testingMachineInfo.ConnectionType),
                new SqlParameter("@Protocol", testingMachineInfo.Protocol),
                new SqlParameter("@Tenmay", testingMachineInfo.Name),
                new SqlParameter("@Tudongvalid", testingMachineInfo.IsAuto)
            };

            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery, param),
                Name = string.Empty
            };
        }
        public bool DeleteTestingMachine(TestingMachineModel testingMachineInfo)
        {
            var param = new SqlParameter[]
            {
                new SqlParameter("@Idmay", testingMachineInfo.Id)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, "delete {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem where Idmay = @Idmay ", param) > -1;
        }
        public DataTable GetTestingMachines(string Id, string testingCode, string testingMachineCode)
        {
            var sqlQuery = "select m.*,x.TenXN from {{TPH_Standard}}_Dictionary.dbo.h_bangmamayxn m inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem x on m.maxn=x.maxn where 1=1";
            if (!string.IsNullOrWhiteSpace(Id))
            {
                sqlQuery += "\n and m.IDMay = " + Id;
            }
            if (!string.IsNullOrWhiteSpace(testingCode))
            {
                sqlQuery += "\n and m.Maxn = '" + testingCode + "'";
            }
            if (!string.IsNullOrWhiteSpace(testingMachineCode))
            {
                sqlQuery += "\n and m.Mamay = '" + testingMachineCode + "'";
            }
            sqlQuery += "\norder by x.sapxep";
            using (var testGroups = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery))
            {
                if (testGroups != null && testGroups.Tables.Count > 0)
                {
                    return testGroups.Tables[0];
                }
            }

            return null;
        }

        public DataTable GetNormalRange(string maxn, int? idMay)
        {

            using (var profiles = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDmXetNghiem_CSBinhThuong", new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaXn",maxn)
                , WorkingServices.GetParaFromOject("@IdMay", idMay)
            }))
            {
                if (profiles != null && profiles.Tables.Count > 0)
                {
                    return profiles.Tables[0];
                }
            }
            return null;
        }
        public List<DM_XETNGHIEM_CSBT> ListNormalRange(DataTable dataNormalRange)
        {
            var lst = new List<DM_XETNGHIEM_CSBT>();
            if (dataNormalRange.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataNormalRange.Rows)
                {
                    lst.Add((DM_XETNGHIEM_CSBT)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_CSBT(), dataRow));
                }
            }
            return lst;

        }

        #endregion
        public DataTable GetDM_XetNghiem_CauHinhMaMayXn(int idMayXN)
        {
            var sqlPara = new SqlParameter[]
            {
               new SqlParameter("@idMayXN", idMayXN)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDMXetNghiem_CauHinhMaMayXN", sqlPara).Tables[0];
        }
        #region dm_xetnghiem
        public int Insert_dm_xetnghiem(DM_XETNGHIEM objInfo)
        {
            if (CheckExists_dm_xetnghiem(objInfo.Maxn)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", objInfo.Autoid),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@magotat", objInfo.Magotat),
                        WorkingServices.GetParaFromOject("@TenXN", objInfo.Tenxn),
                        WorkingServices.GetParaFromOject("@MaNhomCLS", objInfo.Manhomcls),
                        WorkingServices.GetParaFromOject("@CSBT", objInfo.Csbt),
                        WorkingServices.GetParaFromOject("@DonVi", objInfo.Donvi),
                        WorkingServices.GetParaFromOject("@NguongTren", objInfo.Nguongtren),
                        WorkingServices.GetParaFromOject("@NguongDuoi", objInfo.Nguongduoi),
                        WorkingServices.GetParaFromOject("@SapXep", objInfo.Sapxep),
                        WorkingServices.GetParaFromOject("@InDam", objInfo.Indam),
                        WorkingServices.GetParaFromOject("@InDamKQ", objInfo.Indamkq),
                        WorkingServices.GetParaFromOject("@KichCoChu", objInfo.Kichcochu),
                        WorkingServices.GetParaFromOject("@KichCoKQ", objInfo.Kichcokq),
                        WorkingServices.GetParaFromOject("@CanhLe", objInfo.Canhle),
                        WorkingServices.GetParaFromOject("@GiaChuan", objInfo.Giachuan),
                        WorkingServices.GetParaFromOject("@ThuTuIn", objInfo.Thutuin),
                        WorkingServices.GetParaFromOject("@XNChinh", objInfo.Xnchinh),
                        WorkingServices.GetParaFromOject("@KhongSuDung", objInfo.Khongsudung),
                        WorkingServices.GetParaFromOject("@LoaiMau", objInfo.Loaimau),
                        WorkingServices.GetParaFromOject("@ThoiGianNhap", objInfo.Thoigiannhap),
                        WorkingServices.GetParaFromOject("@MaCapTren", objInfo.Macaptren),
                        WorkingServices.GetParaFromOject("@DKDanhGia", objInfo.Dkdanhgia),
                        WorkingServices.GetParaFromOject("@LoaiXN", objInfo.Loaixn),
                        WorkingServices.GetParaFromOject("@TGCoKetQua", objInfo.Tgcoketqua),
                        WorkingServices.GetParaFromOject("@HeSoXN", objInfo.Hesoxn),
                        WorkingServices.GetParaFromOject("@MaVatTu", objInfo.Mavattu),
                        WorkingServices.GetParaFromOject("@HeSoQuiDoi", objInfo.Hesoquidoi),
                        WorkingServices.GetParaFromOject("@KetQuaQuiDoi", objInfo.Ketquaquidoi),
                        WorkingServices.GetParaFromOject("@DonViQuiDoi", objInfo.Donviquidoi),
                        WorkingServices.GetParaFromOject("@CSBTQuiDoi", objInfo.Csbtquidoi),
                        WorkingServices.GetParaFromOject("@lamtron", objInfo.Lamtron),
                        WorkingServices.GetParaFromOject("@KetQuaMacDinh", objInfo.Ketquamacdinh),
                        WorkingServices.GetParaFromOject("@KhongSD", objInfo.Khongsd),
                        WorkingServices.GetParaFromOject("@KhongIn", objInfo.Khongin),
                        WorkingServices.GetParaFromOject("@giabenhnhan", objInfo.Giabenhnhan),
                        WorkingServices.GetParaFromOject("@BYTTenXN", objInfo.Byttenxn),
                        WorkingServices.GetParaFromOject("@LoaiXetNghiem", objInfo.Loaixetnghiem),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@QuiTrinh", objInfo.Quitrinh),
                        WorkingServices.GetParaFromOject("@KhongXuatKQ", objInfo.Khongxuatkq),
                        WorkingServices.GetParaFromOject("@BatCanhBaoBatThuong", objInfo.Batcanhbaobatthuong),
                        WorkingServices.GetParaFromOject("@NoiKiemTraChatLuong", objInfo.Noikiemtrachatluong),
                        WorkingServices.GetParaFromOject("@CuoiTrangIn", objInfo.Cuoitrangin),
                        WorkingServices.GetParaFromOject("@MauInSHPT", objInfo.Mauinshpt),
                        WorkingServices.GetParaFromOject("@SHPTGenName", objInfo.Shptgenname),
                        WorkingServices.GetParaFromOject("@ThemTem", objInfo.Themtem),
                        WorkingServices.GetParaFromOject("@HenTraVaoketQua", objInfo.Hentravaoketqua),
                        WorkingServices.GetParaFromOject("@KhongDanhGia", objInfo.Khongdanhgia),
                        WorkingServices.GetParaFromOject("@AnKetQuaKhiIn", objInfo.Anketquakhiin),
                        WorkingServices.GetParaFromOject("@datchungnhan", objInfo.Datchungnhan),
                        WorkingServices.GetParaFromOject("@LoaiMauPhu", objInfo.Loaimauphu),
                        WorkingServices.GetParaFromOject("@TenXNSHPT", objInfo.Tenxnshpt),
                        WorkingServices.GetParaFromOject("@TenXNSHPTHeSo", objInfo.Tenxnshptheso),
                        WorkingServices.GetParaFromOject("@HenTraKQ", objInfo.Hentrakq),
                        WorkingServices.GetParaFromOject("@CoHinhAnh", objInfo.Cohinhanh),
                        WorkingServices.GetParaFromOject("@MauTenBatThuongTren", objInfo.Mautenbatthuongtren),
                        WorkingServices.GetParaFromOject("@MauTenBatThuongDuoi", objInfo.Mautenbatthuongduoi),
                        WorkingServices.GetParaFromOject("@TinhTem", objInfo.Tinhtem),
                        WorkingServices.GetParaFromOject("@LoaiMau2", objInfo.Loaimau2),
                        WorkingServices.GetParaFromOject("@XnCo", objInfo.Xnco),
                        WorkingServices.GetParaFromOject("@XNGui", objInfo.Xngui),
                        WorkingServices.GetParaFromOject("@LoaiOngMau2", objInfo.Loaiongmau2),
                        WorkingServices.GetParaFromOject("@XnDacBiet", objInfo.Xndacbiet),
                        WorkingServices.GetParaFromOject("@CanTrenCanhBao", objInfo.Cantrencanhbao),
                        WorkingServices.GetParaFromOject("@CanDuoiCanhBao", objInfo.Canduoicanhbao),
                        WorkingServices.GetParaFromOject("@GioiHanCanhBao", objInfo.Gioihancanhbao),
                        WorkingServices.GetParaFromOject("@DinhTinhCanhBao", objInfo.Dinhtinhcanhbao),
                        WorkingServices.GetParaFromOject("@KyTuDanhDau", objInfo.Kytudanhdau),
                        WorkingServices.GetParaFromOject("@KyHieu", objInfo.Kyhieu),
                        WorkingServices.GetParaFromOject("@DanhDauNhanMau", objInfo.Danhdaunhanmau),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@Kiemtramaychay", objInfo.Kiemtramaychay)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem", para);
        }
        public int Update_dm_xetnghiem(DM_XETNGHIEM objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", objInfo.Autoid),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@magotat", objInfo.Magotat),
                        WorkingServices.GetParaFromOject("@TenXN", objInfo.Tenxn),
                        WorkingServices.GetParaFromOject("@MaNhomCLS", objInfo.Manhomcls),
                        WorkingServices.GetParaFromOject("@CSBT", objInfo.Csbt),
                        WorkingServices.GetParaFromOject("@DonVi", objInfo.Donvi),
                        WorkingServices.GetParaFromOject("@NguongTren", objInfo.Nguongtren),
                        WorkingServices.GetParaFromOject("@NguongDuoi", objInfo.Nguongduoi),
                        WorkingServices.GetParaFromOject("@SapXep", objInfo.Sapxep),
                        WorkingServices.GetParaFromOject("@InDam", objInfo.Indam),
                        WorkingServices.GetParaFromOject("@InDamKQ", objInfo.Indamkq),
                        WorkingServices.GetParaFromOject("@KichCoChu", objInfo.Kichcochu),
                        WorkingServices.GetParaFromOject("@KichCoKQ", objInfo.Kichcokq),
                        WorkingServices.GetParaFromOject("@CanhLe", objInfo.Canhle),
                        WorkingServices.GetParaFromOject("@GiaChuan", objInfo.Giachuan),
                        WorkingServices.GetParaFromOject("@ThuTuIn", objInfo.Thutuin),
                        WorkingServices.GetParaFromOject("@XNChinh", objInfo.Xnchinh),
                        WorkingServices.GetParaFromOject("@KhongSuDung", objInfo.Khongsudung),
                        WorkingServices.GetParaFromOject("@LoaiMau", objInfo.Loaimau),
                        WorkingServices.GetParaFromOject("@MaCapTren", objInfo.Macaptren),
                        WorkingServices.GetParaFromOject("@DKDanhGia", objInfo.Dkdanhgia),
                        WorkingServices.GetParaFromOject("@LoaiXN", objInfo.Loaixn),
                        WorkingServices.GetParaFromOject("@TGCoKetQua", objInfo.Tgcoketqua),
                        WorkingServices.GetParaFromOject("@HeSoXN", objInfo.Hesoxn),
                        WorkingServices.GetParaFromOject("@MaVatTu", objInfo.Mavattu),
                        WorkingServices.GetParaFromOject("@HeSoQuiDoi", objInfo.Hesoquidoi),
                        WorkingServices.GetParaFromOject("@KetQuaQuiDoi", objInfo.Ketquaquidoi),
                        WorkingServices.GetParaFromOject("@DonViQuiDoi", objInfo.Donviquidoi),
                        WorkingServices.GetParaFromOject("@CSBTQuiDoi", objInfo.Csbtquidoi),
                        WorkingServices.GetParaFromOject("@lamtron", objInfo.Lamtron),
                        WorkingServices.GetParaFromOject("@KetQuaMacDinh", objInfo.Ketquamacdinh),
                        WorkingServices.GetParaFromOject("@KhongSD", objInfo.Khongsd),
                        WorkingServices.GetParaFromOject("@KhongIn", objInfo.Khongin),
                        WorkingServices.GetParaFromOject("@giabenhnhan", objInfo.Giabenhnhan),
                        WorkingServices.GetParaFromOject("@BYTTenXN", objInfo.Byttenxn),
                        WorkingServices.GetParaFromOject("@LoaiXetNghiem", objInfo.Loaixetnghiem),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@QuiTrinh", objInfo.Quitrinh),
                        WorkingServices.GetParaFromOject("@KhongXuatKQ", objInfo.Khongxuatkq),
                        WorkingServices.GetParaFromOject("@BatCanhBaoBatThuong", objInfo.Batcanhbaobatthuong),
                        WorkingServices.GetParaFromOject("@NoiKiemTraChatLuong", objInfo.Noikiemtrachatluong),
                        WorkingServices.GetParaFromOject("@CuoiTrangIn", objInfo.Cuoitrangin),
                        WorkingServices.GetParaFromOject("@MauInSHPT", objInfo.Mauinshpt),
                        WorkingServices.GetParaFromOject("@SHPTGenName", objInfo.Shptgenname),
                        WorkingServices.GetParaFromOject("@ThemTem", objInfo.Themtem),
                        WorkingServices.GetParaFromOject("@HenTraVaoketQua", objInfo.Hentravaoketqua),
                        WorkingServices.GetParaFromOject("@KhongDanhGia", objInfo.Khongdanhgia),
                        WorkingServices.GetParaFromOject("@AnKetQuaKhiIn", objInfo.Anketquakhiin),
                        WorkingServices.GetParaFromOject("@datchungnhan", objInfo.Datchungnhan),
                        WorkingServices.GetParaFromOject("@LoaiMauPhu", objInfo.Loaimauphu),
                        WorkingServices.GetParaFromOject("@TenXNSHPT", objInfo.Tenxnshpt),
                        WorkingServices.GetParaFromOject("@TenXNSHPTHeSo", objInfo.Tenxnshptheso),
                        WorkingServices.GetParaFromOject("@HenTraKQ", objInfo.Hentrakq),
                        WorkingServices.GetParaFromOject("@CoHinhAnh", objInfo.Cohinhanh),
                        WorkingServices.GetParaFromOject("@MauTenBatThuongTren", objInfo.Mautenbatthuongtren),
                        WorkingServices.GetParaFromOject("@MauTenBatThuongDuoi", objInfo.Mautenbatthuongduoi),
                        WorkingServices.GetParaFromOject("@TinhTem", objInfo.Tinhtem),
                        WorkingServices.GetParaFromOject("@LoaiMau2", objInfo.Loaimau2),
                        WorkingServices.GetParaFromOject("@XnCo", objInfo.Xnco),
                        WorkingServices.GetParaFromOject("@XNGui", objInfo.Xngui),
                        WorkingServices.GetParaFromOject("@LoaiOngMau2", objInfo.Loaiongmau2),
                        WorkingServices.GetParaFromOject("@XnDacBiet", objInfo.Xndacbiet),
                        WorkingServices.GetParaFromOject("@CanTrenCanhBao", objInfo.Cantrencanhbao),
                        WorkingServices.GetParaFromOject("@CanDuoiCanhBao", objInfo.Canduoicanhbao),
                        WorkingServices.GetParaFromOject("@GioiHanCanhBao", objInfo.Gioihancanhbao),
                        WorkingServices.GetParaFromOject("@DinhTinhCanhBao", objInfo.Dinhtinhcanhbao),
                        WorkingServices.GetParaFromOject("@KyTuDanhDau", objInfo.Kytudanhdau),
                        WorkingServices.GetParaFromOject("@KyHieu", objInfo.Kyhieu),
                        WorkingServices.GetParaFromOject("@DanhDauNhanMau", objInfo.Danhdaunhanmau),
                        WorkingServices.GetParaFromOject("@Kiemtramaychay", objInfo.Kiemtramaychay)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem", para);
        }
        public int Delete_dm_xetnghiem(string maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", maxn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem", para);
        }
        public DM_XETNGHIEM Get_Info_dm_xetnghiem(DataRow drInfo)
        {
            return (DM_XETNGHIEM)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM(), drInfo);
        }
        public DM_XETNGHIEM Get_Info_dm_xetnghiem(string maxn)
        {
            DataTable dt = Data_dm_xetnghiem(string.Empty, false, maxn);
            DM_XETNGHIEM obj = new DM_XETNGHIEM();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem(string maxn)
        {
            return Data_dm_xetnghiem(string.Empty, false, maxn).Rows.Count > 0;
        }
        public DataTable Data_dm_xetnghiem(string phanquyenNhom, bool checkQuyenNhom, string maxn)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@PhanQuyenNhom", phanquyenNhom),
                    WorkingServices.GetParaFromOject("@CheckQuyenNhom", checkQuyenNhom),
                    WorkingServices.GetParaFromOject("@MaXn", maxn)

                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem", sqlPara).Tables[0];
        }
        public DataTable Data_dm_xetnghiem_NotInProfile(string profileID)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@ProfileID", profileID)
                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_NotInProfile", sqlPara).Tables[0];
        }
        public DataTable Data_dm_xetnghiem_NotInMappingMaMy(int idMayXn)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@idMay", idMayXn)
                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_NotInMappingMaMay", sqlPara).Tables[0];
        }
        public DataTable XetNghiemDangDung(string testCode)
        {

            using (var testGroups = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_DangSuDung", WorkingServices.GetParaFromOject("@maxn", testCode)))
            {
                if (testGroups != null && testGroups.Tables.Count > 0)
                {
                    return testGroups.Tables[0];
                }
            }

            return null;
        }
        public DataTable GetDM_XetNghiem_CoNhomCLSVaProfile(bool chiXNDichVu)
        {
            var sqlPara = new SqlParameter[]
            {
               new SqlParameter("@ChiXnDichVu", chiXNDichVu)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDMXetNghiem_CoNhomCLSVaProfile", sqlPara).Tables[0];
        }
        #endregion
        #region dm_xetnghiem_nhom
        public int Insert_dm_xetnghiem_nhom(DM_XETNGHIEM_NHOM objInfo)
        {
            if (CheckExists_dm_xetnghiem_nhom(objInfo.Manhomcls)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhomCLS", objInfo.Manhomcls),
                        WorkingServices.GetParaFromOject("@TenNhomCLS", objInfo.Tennhomcls),
                        WorkingServices.GetParaFromOject("@ThuTuIn", objInfo.Thutuin),
                        WorkingServices.GetParaFromOject("@ThoiGianNhap", objInfo.Thoigiannhap),
                        WorkingServices.GetParaFromOject("@nhomin", objInfo.Nhomin),
                        WorkingServices.GetParaFromOject("@ghichu", objInfo.Ghichu),
                        WorkingServices.GetParaFromOject("@MaBoPhan", objInfo.Mabophan),
                        WorkingServices.GetParaFromOject("@SoTem", objInfo.Sotem),
                        WorkingServices.GetParaFromOject("@NhomTem", objInfo.Nhomtem),
                        WorkingServices.GetParaFromOject("@HeThong", objInfo.Hethong),
                        WorkingServices.GetParaFromOject("@TGThucHien", objInfo.Tgthuchien),
                        WorkingServices.GetParaFromOject("@MauOngMauLuu", objInfo.Mauongmauluu),
                        WorkingServices.GetParaFromOject("@BaoGioChuyenMau", objInfo.Baogiochuyenmau),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_nhom", para);
        }
        public int Update_dm_xetnghiem_nhom(DM_XETNGHIEM_NHOM objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhomCLS", objInfo.Manhomcls),
                        WorkingServices.GetParaFromOject("@TenNhomCLS", objInfo.Tennhomcls),
                        WorkingServices.GetParaFromOject("@ThuTuIn", objInfo.Thutuin),
                        WorkingServices.GetParaFromOject("@nhomin", objInfo.Nhomin),
                        WorkingServices.GetParaFromOject("@ghichu", objInfo.Ghichu),
                        WorkingServices.GetParaFromOject("@MaBoPhan", objInfo.Mabophan),
                        WorkingServices.GetParaFromOject("@SoTem", objInfo.Sotem),
                        WorkingServices.GetParaFromOject("@NhomTem", objInfo.Nhomtem),
                        WorkingServices.GetParaFromOject("@HeThong", objInfo.Hethong),
                        WorkingServices.GetParaFromOject("@TGThucHien", objInfo.Tgthuchien),
                        WorkingServices.GetParaFromOject("@MauOngMauLuu", objInfo.Mauongmauluu),
                        WorkingServices.GetParaFromOject("@BaoGioChuyenMau", objInfo.Baogiochuyenmau)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_nhom", para);
        }
        public int Delete_dm_xetnghiem_nhom(string manhomcls)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhomCLS", manhomcls)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_nhom", para);
        }
        public DataTable Data_dm_xetnghiem_nhom(string manhomcls)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhomCLS", manhomcls)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_nhom", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_NHOM Get_Info_dm_xetnghiem_nhom(DataRow drInfo)
        {
            return (DM_XETNGHIEM_NHOM)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_NHOM(), drInfo);
        }
        public DM_XETNGHIEM_NHOM Get_Info_dm_xetnghiem_nhom(string manhomcls)
        {
            DataTable dt = Data_dm_xetnghiem_nhom(manhomcls);
            DM_XETNGHIEM_NHOM obj = new DM_XETNGHIEM_NHOM();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_nhom(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_nhom(string manhomcls)
        {
            return Data_dm_xetnghiem_nhom(manhomcls).Rows.Count > 0;
        }
        #endregion
        #region dm_xetnghiem_profile
        public int Insert_dm_xetnghiem_profile(DM_XETNGHIEM_PROFILE objInfo)
        {
            if (CheckExists_dm_xetnghiem_profile(objInfo.Profileid)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", objInfo.Profileid),
                        WorkingServices.GetParaFromOject("@ProfileName", objInfo.Profilename),
                        WorkingServices.GetParaFromOject("@MaNhomCLS", objInfo.Manhomcls),
                        WorkingServices.GetParaFromOject("@TGCoKetQua", objInfo.Tgcoketqua),
                        WorkingServices.GetParaFromOject("@tudongchon", objInfo.Tudongchon),
                        WorkingServices.GetParaFromOject("@ProfileSLSS", objInfo.Profileslss),
                        WorkingServices.GetParaFromOject("@Nguoinhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_profile", para);
        }
        public int Update_dm_xetnghiem_profile(DM_XETNGHIEM_PROFILE objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", objInfo.Profileid),
                        WorkingServices.GetParaFromOject("@ProfileName", objInfo.Profilename),
                        WorkingServices.GetParaFromOject("@MaNhomCLS", objInfo.Manhomcls),
                        WorkingServices.GetParaFromOject("@TGCoKetQua", objInfo.Tgcoketqua),
                        WorkingServices.GetParaFromOject("@tudongchon", objInfo.Tudongchon),
                        WorkingServices.GetParaFromOject("@ProfileSLSS", objInfo.Profileslss)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_profile", para);
        }
        public int Delete_dm_xetnghiem_profile(string profileid)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", profileid)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_profile", para);
        }
        public DataTable Data_dm_xetnghiem_profile(string profileid)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", profileid)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_profile", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_PROFILE Get_Info_dm_xetnghiem_profile(DataRow drInfo)
        {
            return (DM_XETNGHIEM_PROFILE)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_PROFILE(), drInfo);
        }
        public DM_XETNGHIEM_PROFILE Get_Info_dm_xetnghiem_profile(string profileid)
        {
            DataTable dt = Data_dm_xetnghiem_profile(profileid);
            DM_XETNGHIEM_PROFILE obj = new DM_XETNGHIEM_PROFILE();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_profile(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_profile(string profileid)
        {
            return Data_dm_xetnghiem_profile(profileid).Rows.Count > 0;
        }
        #endregion
        #region dm_xetnghiem_profile_chitiet
        public int Insert_dm_xetnghiem_profile_chitiet(DM_XETNGHIEM_PROFILE_CHITIET objInfo)
        {
            if (CheckExists_dm_xetnghiem_profile_chitiet(objInfo.Profileid, objInfo.Maxn)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", objInfo.Profileid),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@TGCoKetQua", objInfo.Tgcoketqua),
                        WorkingServices.GetParaFromOject("@SoLuongXN", objInfo.Soluongxn),
                        WorkingServices.GetParaFromOject("@Nguoinhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_profile_chitiet", para);
        }
        public int Update_dm_xetnghiem_profile_chitiet(DM_XETNGHIEM_PROFILE_CHITIET objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", objInfo.Profileid),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@TGCoKetQua", objInfo.Tgcoketqua),
                        WorkingServices.GetParaFromOject("@SoLuongXN", objInfo.Soluongxn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_profile_chitiet", para);
        }
        public int Delete_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", profileid),
                        WorkingServices.GetParaFromOject("@MaXN", maxn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_profile_chitiet", para);
        }
        public DataTable Data_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ProfileID", profileid),
                        WorkingServices.GetParaFromOject("@MaXN", maxn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_profile_chitiet", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_PROFILE_CHITIET Get_Info_dm_xetnghiem_profile_chitiet(DataRow drInfo)
        {
            return (DM_XETNGHIEM_PROFILE_CHITIET)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_PROFILE_CHITIET(), drInfo);
        }
        public DM_XETNGHIEM_PROFILE_CHITIET Get_Info_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {
            DataTable dt = Data_dm_xetnghiem_profile_chitiet(profileid, maxn);
            DM_XETNGHIEM_PROFILE_CHITIET obj = new DM_XETNGHIEM_PROFILE_CHITIET();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_profile_chitiet(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_profile_chitiet(string profileid, string maxn)
        {
            return Data_dm_xetnghiem_profile_chitiet(profileid, maxn).Rows.Count > 0;
        }

        #endregion
        #region dm_xetnghiem_tinhtoan
        public int Insert_dm_xetnghiem_tinhtoan(DM_XETNGHIEM_TINHTOAN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaXN1", objInfo.Maxn1),
                        WorkingServices.GetParaFromOject("@MaXN2", objInfo.Maxn2),
                        WorkingServices.GetParaFromOject("@MaXN3", objInfo.Maxn3),
                        WorkingServices.GetParaFromOject("@MaXN4", objInfo.Maxn4),
                        WorkingServices.GetParaFromOject("@MaXN5", objInfo.Maxn5),
                        WorkingServices.GetParaFromOject("@GioiTinh", objInfo.Gioitinh),
                        WorkingServices.GetParaFromOject("@DieuKienLayCongThuc", objInfo.Dieukienlaycongthuc),
                        WorkingServices.GetParaFromOject("@CongThucTinh", objInfo.Congthuctinh),
                        WorkingServices.GetParaFromOject("@LamTron", objInfo.Lamtron),
                        WorkingServices.GetParaFromOject("@DieuKienLon", objInfo.Dieukienlon),
                        WorkingServices.GetParaFromOject("@GiaTriThayTheLon", objInfo.Giatrithaythelon),
                        WorkingServices.GetParaFromOject("@DieuKienNho", objInfo.Dieukiennho),
                        WorkingServices.GetParaFromOject("@GiaTriThayTheNho", objInfo.Giatrithaythenho),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@CachTinhToan", objInfo.Cachtinhtoan),
                        WorkingServices.GetParaFromOject("@LayTrongKhoang", objInfo.Laytrongkhoang),
                        WorkingServices.GetParaFromOject("@NoiDungThongBao", objInfo.Noidungthongbao),
                        WorkingServices.GetParaFromOject("@SoSanhCanDuoi", objInfo.Sosanhcanduoi),
                        WorkingServices.GetParaFromOject("@SoSanhCanTren", objInfo.Sosanhcantren),
                        WorkingServices.GetParaFromOject("@ThongBaoCanDuoi", objInfo.Thongbaocanduoi),
                        WorkingServices.GetParaFromOject("@ThongBaoCanTren", objInfo.Thongbaocantren)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_tinhtoan", para);
        }
        public int Update_dm_xetnghiem_tinhtoan(DM_XETNGHIEM_TINHTOAN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", objInfo.Id),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaXN1", objInfo.Maxn1),
                        WorkingServices.GetParaFromOject("@MaXN2", objInfo.Maxn2),
                        WorkingServices.GetParaFromOject("@MaXN3", objInfo.Maxn3),
                        WorkingServices.GetParaFromOject("@MaXN4", objInfo.Maxn4),
                        WorkingServices.GetParaFromOject("@MaXN5", objInfo.Maxn5),
                        WorkingServices.GetParaFromOject("@GioiTinh", objInfo.Gioitinh),
                        WorkingServices.GetParaFromOject("@DieuKienLayCongThuc", objInfo.Dieukienlaycongthuc),
                        WorkingServices.GetParaFromOject("@CongThucTinh", objInfo.Congthuctinh),
                        WorkingServices.GetParaFromOject("@LamTron", objInfo.Lamtron),
                        WorkingServices.GetParaFromOject("@DieuKienLon", objInfo.Dieukienlon),
                        WorkingServices.GetParaFromOject("@GiaTriThayTheLon", objInfo.Giatrithaythelon),
                        WorkingServices.GetParaFromOject("@DieuKienNho", objInfo.Dieukiennho),
                        WorkingServices.GetParaFromOject("@GiaTriThayTheNho", objInfo.Giatrithaythenho),
                        WorkingServices.GetParaFromOject("@CachTinhToan", objInfo.Cachtinhtoan),
                        WorkingServices.GetParaFromOject("@LayTrongKhoang", objInfo.Laytrongkhoang),
                        WorkingServices.GetParaFromOject("@NoiDungThongBao", objInfo.Noidungthongbao),
                        WorkingServices.GetParaFromOject("@SoSanhCanDuoi", objInfo.Sosanhcanduoi),
                        WorkingServices.GetParaFromOject("@SoSanhCanTren", objInfo.Sosanhcantren),
                        WorkingServices.GetParaFromOject("@ThongBaoCanDuoi", objInfo.Thongbaocanduoi),
                        WorkingServices.GetParaFromOject("@ThongBaoCanTren", objInfo.Thongbaocantren),
                        WorkingServices.GetParaFromOject("@Masinhly", objInfo.Masinhly)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_tinhtoan", para);
        }
        public int Delete_dm_xetnghiem_tinhtoan(int id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", id)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_tinhtoan", para);
        }
        public DataTable Data_dm_xetnghiem_tinhtoan(int? id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", id)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_tinhtoan", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_TINHTOAN Get_Info_dm_xetnghiem_tinhtoan(DataRow drInfo)
        {
            return (DM_XETNGHIEM_TINHTOAN)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_TINHTOAN(), drInfo);
        }
        public DM_XETNGHIEM_TINHTOAN Get_Info_dm_xetnghiem_tinhtoan(int id)
        {
            DataTable dt = Data_dm_xetnghiem_tinhtoan(id);
            DM_XETNGHIEM_TINHTOAN obj = new DM_XETNGHIEM_TINHTOAN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_tinhtoan(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_tinhtoan(int id)
        {
            return Data_dm_xetnghiem_tinhtoan(id).Rows.Count > 0;
        }

        #endregion
        #region dm_xetnghiem_csbt
        public int Insert_dm_xetnghiem_csbt(DM_XETNGHIEM_CSBT objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@IDMayXn", objInfo.Idmayxn),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@LoaiTuoi", objInfo.Loaituoi),
                        WorkingServices.GetParaFromOject("@GioiTinh", objInfo.Gioitinh),
                        WorkingServices.GetParaFromOject("@TuTuoi", objInfo.Tutuoi),
                        WorkingServices.GetParaFromOject("@DenTuoi", objInfo.Dentuoi),
                        WorkingServices.GetParaFromOject("@CSBT", objInfo.Csbt),
                        WorkingServices.GetParaFromOject("@NguongTren", objInfo.Nguongtren),
                        WorkingServices.GetParaFromOject("@NguongDuoi", objInfo.Nguongduoi),
                        WorkingServices.GetParaFromOject("@DonVi", objInfo.Donvi),
                        WorkingServices.GetParaFromOject("@HeSoQuiDoi", objInfo.Hesoquidoi),
                        WorkingServices.GetParaFromOject("@DonViQuiDoi", objInfo.Donviquidoi),
                        WorkingServices.GetParaFromOject("@CSBTQuiDoi", objInfo.Csbtquidoi),
                        WorkingServices.GetParaFromOject("@LamTronSauQuiDoi", objInfo.Lamtronsauquidoi),
                        WorkingServices.GetParaFromOject("@DieuKienDanhGia", objInfo.Dieukiendanhgia),
                        WorkingServices.GetParaFromOject("@CanTrenCanhBao", objInfo.Cantrencanhbao),
                        WorkingServices.GetParaFromOject("@CanDuoiCanhBao", objInfo.Canduoicanhbao),
                        WorkingServices.GetParaFromOject("@GioiHanCanhBao", objInfo.Gioihancanhbao),
                        WorkingServices.GetParaFromOject("@DinhTinhCanhBao", objInfo.Dinhtinhcanhbao),
                        WorkingServices.GetParaFromOject("@CSBTCanNang", objInfo.Csbtcannang),
                        WorkingServices.GetParaFromOject("@CSBTTuCanNang", objInfo.Csbttucannang),
                        WorkingServices.GetParaFromOject("@CSBTDenCanNang", objInfo.Csbtdencannang),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@Masinhly", objInfo.Masinhly)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_csbt", para);
        }
        public int Update_dm_xetnghiem_csbt(DM_XETNGHIEM_CSBT objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", objInfo.Autoid),
                        WorkingServices.GetParaFromOject("@IDMayXn", objInfo.Idmayxn),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@LoaiTuoi", objInfo.Loaituoi),
                        WorkingServices.GetParaFromOject("@GioiTinh", objInfo.Gioitinh),
                        WorkingServices.GetParaFromOject("@TuTuoi", objInfo.Tutuoi),
                        WorkingServices.GetParaFromOject("@DenTuoi", objInfo.Dentuoi),
                        WorkingServices.GetParaFromOject("@CSBT", objInfo.Csbt),
                        WorkingServices.GetParaFromOject("@NguongTren", objInfo.Nguongtren),
                        WorkingServices.GetParaFromOject("@NguongDuoi", objInfo.Nguongduoi),
                        WorkingServices.GetParaFromOject("@DonVi", objInfo.Donvi),
                        WorkingServices.GetParaFromOject("@HeSoQuiDoi", objInfo.Hesoquidoi),
                        WorkingServices.GetParaFromOject("@DonViQuiDoi", objInfo.Donviquidoi),
                        WorkingServices.GetParaFromOject("@CSBTQuiDoi", objInfo.Csbtquidoi),
                        WorkingServices.GetParaFromOject("@LamTronSauQuiDoi", objInfo.Lamtronsauquidoi),
                        WorkingServices.GetParaFromOject("@DieuKienDanhGia", objInfo.Dieukiendanhgia),
                        WorkingServices.GetParaFromOject("@CanTrenCanhBao", objInfo.Cantrencanhbao),
                        WorkingServices.GetParaFromOject("@CanDuoiCanhBao", objInfo.Canduoicanhbao),
                        WorkingServices.GetParaFromOject("@GioiHanCanhBao", objInfo.Gioihancanhbao),
                        WorkingServices.GetParaFromOject("@DinhTinhCanhBao", objInfo.Dinhtinhcanhbao),
                        WorkingServices.GetParaFromOject("@CSBTCanNang", objInfo.Csbtcannang),
                        WorkingServices.GetParaFromOject("@CSBTTuCanNang", objInfo.Csbttucannang),
                        WorkingServices.GetParaFromOject("@CSBTDenCanNang", objInfo.Csbtdencannang),
                        WorkingServices.GetParaFromOject("@Masinhly", objInfo.Masinhly)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_csbt", para);
        }
        public int Delete_dm_xetnghiem_csbt(int autoid)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", autoid)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_csbt", para);
        }
        public DataTable Data_dm_xetnghiem_csbt(int? autoid, string maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", autoid),WorkingServices.GetParaFromOject("@MaXN", maxn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_csbt", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_CSBT Get_Info_dm_xetnghiem_csbt(DataRow drInfo)
        {
            return (DM_XETNGHIEM_CSBT)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_CSBT(), drInfo);
        }
        public DM_XETNGHIEM_CSBT Get_Info_dm_xetnghiem_csbt(int autoid)
        {
            DataTable dt = Data_dm_xetnghiem_csbt(autoid, string.Empty);
            DM_XETNGHIEM_CSBT obj = new DM_XETNGHIEM_CSBT();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_csbt(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_csbt(int autoid)
        {
            return Data_dm_xetnghiem_csbt(autoid, string.Empty).Rows.Count > 0;
        }
        #endregion
        #region dm_xetnghiem_biendichketqua
        public int Insert_dm_xetnghiem_biendichketqua(DM_XETNGHIEM_BIENDICHKETQUA objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@IDMay", objInfo.Idmay),
                        WorkingServices.GetParaFromOject("@MaXNMay", objInfo.Maxnmay),
                        WorkingServices.GetParaFromOject("@LoaiBienDich", objInfo.Loaibiendich),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@DinhDang", objInfo.Dinhdang)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_biendichketqua", para);
        }
        public int Update_dm_xetnghiem_biendichketqua(DM_XETNGHIEM_BIENDICHKETQUA objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", objInfo.Autoid),
                        WorkingServices.GetParaFromOject("@IDMay", objInfo.Idmay),
                        WorkingServices.GetParaFromOject("@MaXNMay", objInfo.Maxnmay),
                        WorkingServices.GetParaFromOject("@LoaiBienDich", objInfo.Loaibiendich),
                        WorkingServices.GetParaFromOject("@KQMay", objInfo.Kqmay),
                        WorkingServices.GetParaFromOject("@KQBienDich", objInfo.Kqbiendich),
                        WorkingServices.GetParaFromOject("@SoSanhTuyetDoi", objInfo.Sosanhtuyetdoi),
                        WorkingServices.GetParaFromOject("@DieuKienCanDuoi", objInfo.Dieukiencanduoi),
                        WorkingServices.GetParaFromOject("@GiaTriCanDuoi", objInfo.Giatricanduoi),
                        WorkingServices.GetParaFromOject("@DieuKienCanTren", objInfo.Dieukiencantren),
                        WorkingServices.GetParaFromOject("@GiaTriCanTren", objInfo.Giatricantren),
                        WorkingServices.GetParaFromOject("@LamTron", objInfo.Lamtron),
                        WorkingServices.GetParaFromOject("@GiaTriTinh", objInfo.Giatritinh),
                        WorkingServices.GetParaFromOject("@PhepTinh", objInfo.Pheptinh),
                        WorkingServices.GetParaFromOject("@DinhDang", objInfo.Dinhdang),
                        WorkingServices.GetParaFromOject("@LayKhoangTrong", objInfo.Laykhoangtrong)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_biendichketqua", para);
        }
        public int Delete_dm_xetnghiem_biendichketqua(int autoid)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", autoid)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_biendichketqua", para);
        }
        public DataTable Data_dm_xetnghiem_biendichketqua(int? autoid)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", autoid)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_biendichketqua", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_BIENDICHKETQUA Get_Info_dm_xetnghiem_biendichketqua(DataRow drInfo)
        {
            return (DM_XETNGHIEM_BIENDICHKETQUA)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_BIENDICHKETQUA(), drInfo);
        }
        public DM_XETNGHIEM_BIENDICHKETQUA Get_Info_dm_xetnghiem_biendichketqua(int autoid)
        {
            DataTable dt = Data_dm_xetnghiem_biendichketqua(autoid);
            DM_XETNGHIEM_BIENDICHKETQUA obj = new DM_XETNGHIEM_BIENDICHKETQUA();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_biendichketqua(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_biendichketqua(int autoid)
        {
            return Data_dm_xetnghiem_biendichketqua(autoid).Rows.Count > 0;
        }
        #endregion
        //================================|||=====================================
        #region Nhân viên
        public DataTable Data_dm_nhomnhanvien()
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhomNhanVien", string.Empty)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_nhomnhanvien", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public BaseModel Insert_ql_nhanvien(QL_NHANVIEN objInfo)
        {
            if (CheckExists_ql_nhanvien(objInfo.Manhanvien))
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã bị trùng"
                };
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", objInfo.Manhanvien),
                        WorkingServices.GetParaFromOject("@TenNhanVien", objInfo.Tennhanvien),
                        WorkingServices.GetParaFromOject("@DiaChi", objInfo.Diachi),
                        WorkingServices.GetParaFromOject("@DienThoai", objInfo.Dienthoai),
                        WorkingServices.GetParaFromOject("@ChucVu", objInfo.Chucvu),
                        WorkingServices.GetParaFromOject("@DaNghi", objInfo.Danghi),
                        WorkingServices.GetParaFromOject("@KhamChuaBenh", objInfo.Khamchuabenh),
                        WorkingServices.GetParaFromOject("@GuiChiDinh", objInfo.Guichidinh),
                        WorkingServices.GetParaFromOject("@ThongKe", objInfo.Thongke),
                        WorkingServices.GetParaFromOject("@his_id", objInfo.His_id),
                        WorkingServices.GetParaFromOject("@chungchihanhnghe", objInfo.Chungchihanhnghe),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@NhomNhanVien", objInfo.Nhomnhanvien),
                        WorkingServices.GetParaFromOject("@MaKhoaPhong", objInfo.Makhoaphong),
                        WorkingServices.GetParaFromOject("@MaPhong", objInfo.Maphong)
                        };
            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_ql_nhanvien", para),
                Name = string.Empty
            };
        }
        public bool Update_ql_nhanvien(QL_NHANVIEN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", objInfo.Manhanvien),
                        WorkingServices.GetParaFromOject("@TenNhanVien", objInfo.Tennhanvien),
                        WorkingServices.GetParaFromOject("@DiaChi", objInfo.Diachi),
                        WorkingServices.GetParaFromOject("@DienThoai", objInfo.Dienthoai),
                        WorkingServices.GetParaFromOject("@ChucVu", objInfo.Chucvu),
                        WorkingServices.GetParaFromOject("@DaNghi", objInfo.Danghi),
                        WorkingServices.GetParaFromOject("@KhamChuaBenh", objInfo.Khamchuabenh),
                        WorkingServices.GetParaFromOject("@GuiChiDinh", objInfo.Guichidinh),
                        WorkingServices.GetParaFromOject("@ThongKe", objInfo.Thongke),
                        WorkingServices.GetParaFromOject("@NguoiSua", objInfo.Nguoisua),
                        WorkingServices.GetParaFromOject("@NhomNhanVien", objInfo.Nhomnhanvien),
                        WorkingServices.GetParaFromOject("@MaKhoaPhong", objInfo.Makhoaphong),
                        WorkingServices.GetParaFromOject("@MaPhong", objInfo.Maphong),
                        WorkingServices.GetParaFromOject("@MaBoPhan", objInfo.MaBoPhan)

                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_ql_nhanvien", para) > -1;
        }
        public bool Delete_ql_nhanvien(QL_NHANVIEN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", objInfo.Manhanvien)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_ql_nhanvien", para) > -1;
        }
        private string SQLSelect_Data_ql_nhanvien(string manhanvien)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN where 1=1";
            if (!string.IsNullOrEmpty(manhanvien))
                sqlQuery += string.Format("\n and  manhanvien = {0}", "'" + manhanvien + "'");
            return sqlQuery;
        }
        public DataTable Data_ql_nhanvien(string manhanvien, string manhomNhanvien)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhanVien", manhanvien),
                        WorkingServices.GetParaFromOject("@MaNhomNhanVien", manhomNhanvien)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_ql_nhanvien", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }

        public QL_NHANVIEN Get_Info_ql_nhanvien(string manhanvien, string manhomNhanvien)
        {
            DataTable dt = Data_ql_nhanvien(manhanvien, manhomNhanvien);
            QL_NHANVIEN obj = new QL_NHANVIEN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_ql_nhanvien(dt.Rows[0]);
            }
            return obj;

        }
        public QL_NHANVIEN Get_Info_ql_nhanvien(DataRow drInfo)
        {
            var objInfo = new QL_NHANVIEN();
            objInfo.Manhanvien = StringConverter.ToString(drInfo["manhanvien"]);
            if (!string.IsNullOrEmpty(drInfo["tennhanvien"].ToString()))
                objInfo.Tennhanvien = StringConverter.ToString(drInfo["tennhanvien"]);
            if (!string.IsNullOrEmpty(drInfo["diachi"].ToString()))
                objInfo.Diachi = StringConverter.ToString(drInfo["diachi"]);
            if (!string.IsNullOrEmpty(drInfo["dienthoai"].ToString()))
                objInfo.Dienthoai = StringConverter.ToString(drInfo["dienthoai"]);
            if (!string.IsNullOrEmpty(drInfo["chucvu"].ToString()))
                objInfo.Chucvu = StringConverter.ToString(drInfo["chucvu"]);
            objInfo.Danghi = NumberConverter.To<bool>(drInfo["danghi"]);
            objInfo.Khamchuabenh = NumberConverter.To<bool>(drInfo["khamchuabenh"]);
            objInfo.Guichidinh = NumberConverter.To<bool>(drInfo["guichidinh"]);
            objInfo.Tgnhap = (DateTime)drInfo["tgnhap"];
            objInfo.Thongke = NumberConverter.To<bool>(drInfo["thongke"]);
            if (!string.IsNullOrEmpty(drInfo["his_id"].ToString()))
                objInfo.His_id = StringConverter.ToString(drInfo["his_id"]);
            if (!string.IsNullOrEmpty(drInfo["chungchihanhnghe"].ToString()))
                objInfo.Chungchihanhnghe = StringConverter.ToString(drInfo["chungchihanhnghe"]);
            if (!string.IsNullOrEmpty(drInfo["nguoinhap"].ToString()))
                objInfo.Nguoinhap = StringConverter.ToString(drInfo["nguoinhap"]);
            if (!string.IsNullOrEmpty(drInfo["nguoisua"].ToString()))
                objInfo.Nguoisua = StringConverter.ToString(drInfo["nguoisua"]);
            if (!string.IsNullOrEmpty(drInfo["ngaysua"].ToString()))
                objInfo.Ngaysua = (DateTime)drInfo["ngaysua"];
            if (!string.IsNullOrEmpty(drInfo["nhomnhanvien"].ToString()))
                objInfo.Nhomnhanvien = StringConverter.ToString(drInfo["nhomnhanvien"]);
            if (!string.IsNullOrEmpty(drInfo["MaKhoaPhong"].ToString()))
                objInfo.Makhoaphong = StringConverter.ToString(drInfo["MaKhoaPhong"]);
            if (!string.IsNullOrEmpty(drInfo["MaPhong"].ToString()))
                objInfo.Maphong = StringConverter.ToString(drInfo["MaPhong"]);
            if (!string.IsNullOrEmpty(drInfo["MaBoPhan"].ToString()))
                objInfo.MaBoPhan = StringConverter.ToString(drInfo["MaBoPhan"]);
            return objInfo;
        }
        public bool CheckExists_ql_nhanvien(string manhanvien)
        {
            return Data_ql_nhanvien(manhanvien, string.Empty).Rows.Count > 0;
        }
        #endregion
        //================================|||=====================================
        #region Bộ phận
        public BaseModel Insert_dm_bophan(DM_BOPHAN objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN (";
            sqlQuery += "\nMabophan";
            sqlQuery += "\n,Tenbophan";
            sqlQuery += "\n,Maphanloai";
            sqlQuery += "\n,Khongsudung";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabophan.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Tenbophan == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenbophan.ToString()) + "'"));
            sqlQuery += string.Format("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Maphanloai.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (bool.Parse(objInfo.Khongsudung.ToString()) ? "1" : "0"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN where 1 = 1  and Mabophan =  " + "'" + Utilities.ConvertSqlString(objInfo.Mabophan.ToString()).ToString() + "'"))
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

        public bool Update_dm_bophan(DM_BOPHAN objInfo)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN set";
            sqlQuery += string.Format("\n Mabophan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabophan.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Tenbophan = {0}", (objInfo.Tenbophan == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenbophan.ToString()) + "'"));
            sqlQuery += string.Format("\n, Maphanloai = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maphanloai.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Khongsudung = {0}", (bool.Parse(objInfo.Khongsudung.ToString()) ? "1" : "0"));
            sqlQuery += "\nwhere Mabophan =  " + "'" + Utilities.ConvertSqlString(objInfo.Mabophan.ToString()).ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_dm_bophan(DM_BOPHAN objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN";
            sqlQuery += string.Format("\n where Mabophan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabophan.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_dm_bophan(string mabophan, string maphanloai)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_BOPHAN where 1=1";
            if (!string.IsNullOrEmpty(mabophan))
                sqlQuery += string.Format("\n and  mabophan = {0}", "'" + mabophan + "'");
            if (!string.IsNullOrEmpty(maphanloai))
                sqlQuery += string.Format("\n and  maphanloai = {0}", "'" + maphanloai + "'");
            return sqlQuery;
        }
        public DataTable Data_dm_bophan(string mabophan, string maphanloai)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_bophan(mabophan, maphanloai)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_bophan(DataGridView dtg, BindingNavigator bv, string mabophan, string maphanloai)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_bophan(mabophan, maphanloai);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_bophan(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabophan, string maphanloai)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_bophan(mabophan, maphanloai), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_bophan(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabophan, string maphanloai)
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
            DataTable dtData = Data_dm_bophan(mabophan, maphanloai);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_BOPHAN Get_Info_dm_bophan(string mabophan, string maphanloai)
        {
            DataTable dt = Data_dm_bophan(mabophan, maphanloai);
            DM_BOPHAN obj = new DM_BOPHAN();
            if (dt.Rows.Count > 0)

            {
                obj.Mabophan = dt.Rows[0]["mabophan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenbophan"].ToString()))
                    obj.Tenbophan = dt.Rows[0]["tenbophan"].ToString();
                obj.Maphanloai = dt.Rows[0]["maphanloai"].ToString();
                obj.Khongsudung = (bool)dt.Rows[0]["khongsudung"];
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region Khoa phòng
        public BaseModel AddNewLocation(LocationDepartmentModel locationInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG (";
            sqlQuery += "\nMakhoaphong";
            sqlQuery += "\n,Tenkhoaphong";
            sqlQuery += "\n,Khongsudung";
            sqlQuery += "\n,Diachi";
            sqlQuery += "\n,Email";
            sqlQuery += "\n,Dienthoai";
            sqlQuery += "\n,Website";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n" + "'" + locationInfo.Makhoaphong.ToString() + "'";
            sqlQuery += "\n," + (locationInfo.Tenkhoaphong == null ? "NULL" : "N'" + locationInfo.Tenkhoaphong.ToString() + "'");
            sqlQuery += "\n," + (bool.Parse(locationInfo.Khongsudung.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (locationInfo.Diachi == null ? "NULL" : "N'" + locationInfo.Diachi.ToString() + "'");
            sqlQuery += "\n," + (locationInfo.Email == null ? "NULL" : "N'" + locationInfo.Email.ToString() + "'");
            sqlQuery += "\n," + (locationInfo.Dienthoai == null ? "NULL" : "N'" + locationInfo.Dienthoai.ToString() + "'");
            sqlQuery += "\n," + (locationInfo.Website == null ? "NULL" : "N'" + locationInfo.Website.ToString() + "'");
            if (
                DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG where 1 = 1  and Makhoaphong =  " + "'" +
                                          locationInfo.Makhoaphong.ToString() + "'"))
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã khoa phòng đã tồn tại ! \nHãy nhập mã máy khác."
                };
            }
            else
            {

                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery),
                    Name = string.Empty
                };
            }
        }
        public BaseModel UpdateLocation(LocationDepartmentModel objInfo, string maKhoaPhongOld)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG set";
            sqlQuery += "\n Makhoaphong = '" + objInfo.Makhoaphong.ToString() + "'";
            sqlQuery += "\n, Tenkhoaphong = " +
                       (objInfo.Tenkhoaphong == null ? "NULL" : "N'" + objInfo.Tenkhoaphong.ToString() + "'");
            sqlQuery += "\n, Khongsudung = " + (bool.Parse(objInfo.Khongsudung.ToString()) ? "1" : "0");
            sqlQuery += "\n, Diachi = " + (objInfo.Diachi == null ? "NULL" : "N'" + objInfo.Diachi.ToString() + "'");
            sqlQuery += "\n, Email = " + (objInfo.Email == null ? "NULL" : "N'" + objInfo.Email.ToString() + "'");
            sqlQuery += "\n, Dienthoai = " +
                       (objInfo.Dienthoai == null ? "NULL" : "N'" + objInfo.Dienthoai.ToString() + "'");
            sqlQuery += "\n, Website = " + (objInfo.Website == null ? "NULL" : "N'" + objInfo.Website.ToString() + "'");
            sqlQuery += "\nwhere Makhoaphong = '" + maKhoaPhongOld.Trim() + "'";
            if (
                DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG where Makhoaphong =  '" +
                                          objInfo.Makhoaphong.ToString() + "'"))
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã khoa phòng đã tồn tại ! \nHãy nhập mã máy khác."
                };
            }
            else
            {

                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery),
                    Name = string.Empty
                };
            }
        }
        public bool DeleteLocation(LocationDepartmentModel objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Makhoaphong = " + "'" + objInfo.Makhoaphong.ToString() + "'";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery) > 0;
        }
        private string SQLSelect_Data_DM_KhoaPhong(string makhoaphong, string tenKhoaPhong)
        {
            string strSql = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHOAPHONG where 1=1";
            if (!string.IsNullOrEmpty(makhoaphong))
                strSql += "\n and  makhoaphong = '" + makhoaphong + "'";
            if (!string.IsNullOrEmpty(tenKhoaPhong))
                strSql += "\n and  Tenkhoaphong like '%" + tenKhoaPhong + "%'";
            return strSql;
        }
        public DataTable GetLocation(string makhoaphong, string tenKhoaPhong)
        {
            using (var data = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_DM_KhoaPhong(makhoaphong, tenKhoaPhong)))
            {
                if (data != null && data.Tables.Count > 0)
                {
                    return data.Tables[0];
                }
            }
            return null;
        }
        public DataTable GetLocation(DataGridView dtg, BindingNavigator bv, string makhoaphong, string tenKhoaPhong)
        {
            var dtData = new DataTable();
            dtData = GetLocation(makhoaphong, tenKhoaPhong);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }

        public DataTable GetLocation(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, TextBox txt, int linkColumnIndex, string makhoaphong)
        {
            var dtData = GetLocation(makhoaphong, string.Empty);
            if (cbo != null)
            {
                ControlExtension.BindDataToCobobox(dtData.Copy(), ref cbo, valueColumn, displayColumn, columnsName,
                    columnsWidth, txt, linkColumnIndex);
            }
            return dtData;
        }
        public LocationDepartmentModel Get_Info_LocationDepartment(string makhoaphong)
        {
            DataTable dt = GetLocation(makhoaphong, String.Empty);
            LocationDepartmentModel obj = new LocationDepartmentModel();
            if (dt.Rows.Count > 0)
            {
                obj.Makhoaphong = dt.Rows[0]["makhoaphong"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenkhoaphong"].ToString()))
                    obj.Tenkhoaphong = dt.Rows[0]["tenkhoaphong"].ToString();
                obj.Khongsudung = (bool)dt.Rows[0]["khongsudung"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["diachi"].ToString()))
                    obj.Diachi = dt.Rows[0]["diachi"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["email"].ToString()))
                    obj.Email = dt.Rows[0]["email"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["dienthoai"].ToString()))
                    obj.Dienthoai = dt.Rows[0]["dienthoai"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["website"].ToString()))
                    obj.Website = dt.Rows[0]["website"].ToString();
            }
            return obj;
        }

        #endregion
        //================================|||=====================================
        #region dm_khuvuc
        public BaseModel Insert_dm_khuvuc(DM_KHUVUC objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC (";
            sqlQuery += "\nMakhuvuc";
            sqlQuery += "\n,Tenkhuvuc";
            sqlQuery += "\n,Codebatdau";
            sqlQuery += "\n,Codeketthuc";
            sqlQuery += "\n,Kytuphanbiet";
            sqlQuery += "\n,Inbarcode";
            sqlQuery += "\n,Vitrikytu";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Tenkhuvuc == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenkhuvuc.ToString()) + "'"));
            sqlQuery += string.Format("\n ,{0}", (objInfo.Codebatdau < 0 ? "-1" : objInfo.Codebatdau.ToString()));
            sqlQuery += string.Format("\n ,{0}", (objInfo.Codeketthuc < 0 ? "-1" : objInfo.Codeketthuc.ToString()));
            sqlQuery += string.Format("\n ,{0}", (objInfo.Kytuphanbiet == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Kytuphanbiet.ToString()) + "'"));
            sqlQuery += string.Format("\n ,{0}", (bool.Parse(objInfo.Inbarcode.ToString()) ? "1" : "0"));
            sqlQuery += string.Format("\n ,{0}", (objInfo.Vitrikytu < 0 ? "1" : objInfo.Vitrikytu.ToString()));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC where Makhuvuc =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() + "'"))
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
        public bool Update_dm_khuvuc(DM_KHUVUC objInfo)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC set";
            sqlQuery += string.Format("\n Makhuvuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Tenkhuvuc = {0}", (objInfo.Tenkhuvuc == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenkhuvuc.ToString()) + "'"));
            sqlQuery += string.Format("\n, Codebatdau = {0}", (objInfo.Codebatdau < 0 ? "-1" : objInfo.Codebatdau.ToString()));
            sqlQuery += string.Format("\n, Codeketthuc = {0}", (objInfo.Codeketthuc < 0 ? "-1" : objInfo.Codeketthuc.ToString()));
            sqlQuery += string.Format("\n, Kytuphanbiet = {0}", (objInfo.Kytuphanbiet == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Kytuphanbiet.ToString()) + "'"));
            sqlQuery += string.Format("\n, Inbarcode = {0}", (bool.Parse(objInfo.Inbarcode.ToString()) ? "1" : "0"));
            sqlQuery += string.Format("\n, Vitrikytu = {0}", (objInfo.Vitrikytu < 0 ? "1" : objInfo.Vitrikytu.ToString()));
            sqlQuery += "\nwhere Makhuvuc =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }
        public bool Delete_dm_khuvuc(DM_KHUVUC objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += string.Format("\n and Makhuvuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }
        private string SQLSelect_Data_dm_khuvuc(string makhuvuc)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC where 1=1";
            if (!string.IsNullOrEmpty(makhuvuc))
                sqlQuery += string.Format("\n and  makhuvuc = {0}", "'" + makhuvuc + "'");
            return sqlQuery;
        }
        public DataTable Data_dm_khuvuc(string makhuvuc)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_khuvuc(makhuvuc)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_khuvuc(DataGridView dtg, BindingNavigator bv, string makhuvuc)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_khuvuc(makhuvuc);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_khuvuc(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string makhuvuc)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_khuvuc(makhuvuc), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_khuvuc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string makhuvuc)
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
            DataTable dtData = Data_dm_khuvuc(makhuvuc);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_KHUVUC Get_Info_dm_khuvuc(string makhuvuc)
        {
            DataTable dt = Data_dm_khuvuc(makhuvuc);
            DM_KHUVUC obj = new DM_KHUVUC();
            if (dt.Rows.Count > 0)
            {
                obj = (DM_KHUVUC)WorkingServices.Get_InfoForObject(obj, dt.Rows[0]);
            }
            return obj;
        }
        public DM_KHUVUC Get_Info_dm_khuvuc(DataRow dr)
        {
            return (DM_KHUVUC)WorkingServices.Get_InfoForObject(new DM_KHUVUC(), dr);
        }

        #endregion
        //================================|||=====================================
        #region KhuVuc-MayTinh
        public BaseModel Insert_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH (";
            sqlQuery += "\nMakhuvuc";
            sqlQuery += "\n,Tenmaytinh";
            sqlQuery += "\n,Mota, IDKhuLayMau";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            sqlQuery += string.Format("\n ,{0}", (objInfo.Idkhulaymau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH where Makhuvuc = '"
                + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()).ToString() +
                "' and Tenmaytinh =  N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()).ToString()
                + "' and IDKhuLayMau  " + (objInfo.Idkhulaymau == null ? "is NULL" : " = '" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'")))
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
        public bool Update_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update  {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH set");
            sb.AppendFormat("\n  Makhuvuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc ?? String.Empty) + "'");
            sb.AppendFormat("\n, Tenmaytinh = {0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh ?? String.Empty) + "'");
            sb.AppendFormat("\n, Mota = {0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota ?? String.Empty) + "'"));
            sb.AppendFormat("\n, Hisproviderid = {0}", (objInfo.Hisproviderid < 0 ? "0" : objInfo.Hisproviderid.ToString()));
            sb.AppendFormat("\n, Idkhulaymau = {0}", (objInfo.Idkhulaymau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'"));
            sb.Append("\nwhere Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_khuvuc_maytinh(DM_KHUVUC_MAYTINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH");
            sb.AppendFormat("\n where Id = {0}", objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {
            string sqlQuery = "select m.*, K.tenkhuvuc,lm.TenKhuLayMau, mt.MaKhuVucChinh, k.IDLayLoaiMau, k.XacNhanVaoKetQua from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH m left join {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC k on m.makhuvuc = k.makhuvuc inner join {{TPH_Standard}}_Dictionary.dbo.DM_MAYTINH mt on mt.tenmaytinh =  m.tenmaytinh";
            sqlQuery += "\n left join {{TPH_Standard}}_Dictionary.dbo.dm_khulaymau lm on lm.IDKhuLayMau = m.IDKhuLaymau where 1=1";
            if (!string.IsNullOrEmpty(id))
                sqlQuery += string.Format("\n and  id = {0}", id);
            if (!string.IsNullOrEmpty(makhuvuc))
                sqlQuery += string.Format("\n and  m.makhuvuc = {0}", "'" + makhuvuc + "'");
            if (!string.IsNullOrEmpty(tenmaytinh))
                sqlQuery += string.Format("\n and  m.tenmaytinh = {0}", "'" + tenmaytinh + "'");
            return sqlQuery;
        }
        public DataTable Data_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_khuvuc_maytinh(DataGridView dtg, BindingNavigator bv, string id, string makhuvuc, string tenmaytinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_khuvuc_maytinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id, string makhuvuc, string tenmaytinh)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_khuvuc_maytinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string makhuvuc, string tenmaytinh)
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
            DataTable dtData = Data_dm_khuvuc_maytinh(id, makhuvuc, tenmaytinh);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_KHUVUC_MAYTINH Get_Info_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {
            DataTable dt = Data_dm_khuvuc_maytinh(id, string.Empty, tenmaytinh);
            DM_KHUVUC_MAYTINH obj = new DM_KHUVUC_MAYTINH();
            if (dt.Rows.Count > 0)
            {
                obj = (DM_KHUVUC_MAYTINH)WorkingServices.Get_InfoForObject(new DM_KHUVUC_MAYTINH(), dt.Rows[0]);
            }
            return obj;
        }
        public DM_KHUVUC_MAYTINH Get_Info_dm_khuvuc_maytinh(DataRow dr)
        {
            return (DM_KHUVUC_MAYTINH)WorkingServices.Get_InfoForObject(new DM_KHUVUC_MAYTINH(), dr);
        }
        public DataTable DataThongTinKhuVucTheomayTinh(string pcName)
        {
            SqlParameter[] para = new SqlParameter[] { WorkingServices.GetParaFromOject("@PCname", pcName) };
            DataSet ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selThongTinKhuVuc_TheoMayTinh", para);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;

        }
        public List<DM_KHUVUC_MAYTINH> Get_LstInfo_dm_khuvuc_maytinh(string id, string makhuvuc, string tenmaytinh)
        {
            DataTable dt = Data_dm_khuvuc_maytinh(id, string.Empty, tenmaytinh);
            var objLst = new List<DM_KHUVUC_MAYTINH>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = Get_Info_dm_khuvuc_maytinh(dt.Rows[0]);
                    objLst.Add(obj);
                }
            }
            return objLst;
        }
        public List<DM_KHUVUC_MAYTINH> Get_LstInfo_dm_khuvuc_maytinh(string tenmaytinh)
        {
            DataTable dt = DataThongTinKhuVucTheomayTinh(tenmaytinh);
            var objLst = new List<DM_KHUVUC_MAYTINH>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = Get_Info_dm_khuvuc_maytinh(dt.Rows[0]);
                    objLst.Add(obj);
                }
            }
            return objLst;
        }
        public int[] GetPCHisWorking(string tenmaytinh, string makhuvuc)
        {
            DataTable dt = Data_dm_khuvuc_maytinh(string.Empty, makhuvuc, tenmaytinh);
            var returnLis = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                returnLis[i] = int.Parse(dt.Rows[i]["HisProviderID"].ToString());
            }
            return returnLis;
        }
        public DataTable Data_dm_khuVu_maytinh(string makhuvuc, string tenmaytinh)
        {
            //selDanhSach_MayTinh_KhuVuc
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", makhuvuc),
                        WorkingServices.GetParaFromOject("@TenMayTinh", tenmaytinh)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_MayTinh_KhuVuc", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion
        //================================|||=====================================
        #region DM_XetNghiem_mauphieuin
        public BaseModel Insert_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN (";
            sqlQuery += "\nIdmauketqua";
            sqlQuery += "\n,Mota";
            sqlQuery += "\n,IdReport";
            sqlQuery += "\n,ChiaCot";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Idmauketqua.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            sqlQuery += string.Format("\n ,{0}", (string.IsNullOrEmpty(objInfo.Idreport) ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Idreport) + "'"));
            sqlQuery += string.Format("\n ,{0}", (objInfo.Chiacot == true ? "1" : "0"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN where Idmauketqua =  '" + Utilities.ConvertSqlString(objInfo.Idmauketqua.ToString()).ToString() + "'"))
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
                    Name = "Phiếu đã tồn tại."
                };
            }
        }

        public bool Update_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN set");
            sb.AppendFormat("\n  Mota = {0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            // sb.AppendFormat("\n, Hinhphieukq = {0}", (string.IsNullOrEmpty(objInfo.Hinhphieukq.Trim()) ? "NULL" : "N'" + objInfo.Hinhphieukq + "'"));
            sb.AppendFormat("\n, Vitrisapxeptrai = {0}", (objInfo.Vitrisapxeptrai < 0 ? "-1" : objInfo.Vitrisapxeptrai.ToString()));
            sb.AppendFormat("\n, Vitrisapxepphai = {0}", (objInfo.Vitrisapxepphai < 0 ? "-1" : objInfo.Vitrisapxepphai.ToString()));
            sb.AppendFormat("\n, Vitrisapxeptraigioihan = {0}", (objInfo.Vitrisapxeptraigioihan < 0 ? "-1" : objInfo.Vitrisapxeptraigioihan.ToString()));
            sb.AppendFormat("\n, Vitrisapxepphaigioihan = {0}", (objInfo.Vitrisapxepphaigioihan < 0 ? "-1" : objInfo.Vitrisapxepphaigioihan.ToString()));
            sb.AppendFormat("\n, Vitrisapxeptraingoai = {0}", (objInfo.Vitrisapxeptraingoai < 0 ? "-1" : objInfo.Vitrisapxeptraingoai.ToString()));
            sb.AppendFormat("\n, Vitrisapxepphaingoai = {0}", (objInfo.Vitrisapxepphaingoai < 0 ? "-1" : objInfo.Vitrisapxepphaingoai.ToString()));
            sb.AppendFormat("\n, Vitrisapxeptraigioihanngoai = {0}", (objInfo.Vitrisapxeptraigioihanngoai < 0 ? "-1" : objInfo.Vitrisapxeptraigioihanngoai.ToString()));
            sb.AppendFormat("\n, Vitrisapxepphaigioihanngoai = {0}", (objInfo.Vitrisapxepphaigioihanngoai < 0 ? "-1" : objInfo.Vitrisapxepphaigioihanngoai.ToString()));
            sb.AppendFormat("\n, Tenctm = {0}", (objInfo.Tenctm == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenctm.ToString()) + "'"));
            sb.AppendFormat("\n, Tendm = {0}", (objInfo.Tendm == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tendm.ToString()) + "'"));
            sb.AppendFormat("\n, Tennm = {0}", (objInfo.Tennm == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennm.ToString()) + "'"));
            sb.AppendFormat("\n, Thutuin = {0}", (objInfo.Thutuin < 0 ? "0" : objInfo.Thutuin.ToString()));
            sb.AppendFormat("\n, Idreport = {0}", (objInfo.Idreport == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Idreport.ToString()) + "'"));
            sb.AppendFormat("\n, Chiacot = {0}", (bool.Parse(objInfo.Chiacot.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Kytentheoluoi = {0}", (bool.Parse(objInfo.Kytentheoluoi.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tachbschidinh = {0}", (bool.Parse(objInfo.Tachbschidinh.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tachnhomin = {0}", (bool.Parse(objInfo.Tachnhomin.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Gheptenxnghichu = {0}", (bool.Parse(objInfo.Gheptenxnghichu.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Ghichuduoixn = {0}", (bool.Parse(objInfo.Ghichuduoixn.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Ghepghichukhoavaochung = {0}", (bool.Parse(objInfo.Ghepghichukhoavaochung.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Dinhdangghepnhapkq = {0}", (objInfo.Dinhdangghepnhapkq == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Dinhdangghepnhapkq.ToString()) + "'"));
            sb.AppendFormat("\n, Dinhdangghepduyetkq = {0}", (objInfo.Dinhdangghepduyetkq == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Dinhdangghepduyetkq.ToString()) + "'"));
            sb.AppendFormat("\n, Lekqduoinguong = {0}", (objInfo.Lekqduoinguong < 0 ? "0" : objInfo.Lekqduoinguong.ToString()));
            sb.AppendFormat("\n, Lekqtrennguong = {0}", (objInfo.Lekqtrennguong < 0 ? "0" : objInfo.Lekqtrennguong.ToString()));
            sb.AppendFormat("\n, Lekqtrongnguong = {0}", (objInfo.Lekqtrongnguong < 0 ? "0" : objInfo.Lekqtrongnguong.ToString()));
            sb.AppendFormat("\n, Lenhom = {0}", (objInfo.Lenhom < 0 ? "0" : objInfo.Lenhom.ToString()));
            sb.AppendFormat("\n, Batthuonggachchan = {0}", (bool.Parse(objInfo.Batthuonggachchan.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Batthuongindam = {0}", (bool.Parse(objInfo.Batthuongindam.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Batthuonginnghieng = {0}", (bool.Parse(objInfo.Batthuonginnghieng.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Thoigianinlandau = {0}", (bool.Parse(objInfo.Thoigianinlandau.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tachtudong = {0}", (bool.Parse(objInfo.Tachtudong.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tachbophan = {0}", (bool.Parse(objInfo.Tachbophan.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tennhomgachchan = {0}", (bool.Parse(objInfo.Tennhomgachchan.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tennhomindam = {0}", (bool.Parse(objInfo.Tennhomindam.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Tennhominnghieng = {0}", (bool.Parse(objInfo.Tennhominnghieng.ToString()) ? "1" : "0"));
            sb.Append("\nwhere Idmauketqua = '" + Utilities.ConvertSqlString(objInfo.Idmauketqua.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_xetnghiem_mauphieuin(DM_XETNGHIEM_MAUPHIEUIN objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN";
            sqlQuery += string.Format("\nwhere Idmauketqua = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idmauketqua.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_dm_xetnghiem_mauphieuin(string idmauketqua)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN where 1=1";
            if (!string.IsNullOrEmpty(idmauketqua))
                sqlQuery += string.Format("\n and  idmauketqua = {0}", "'" + idmauketqua + "'");
            sqlQuery += "\n order by ThuTuIn, idmauketqua asc";
            return sqlQuery;
        }

        public DataTable Data_dm_xetnghiem_mauphieuin(string idmauketqua)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_mauphieuin(idmauketqua)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin(DataGridView dtg, BindingNavigator bv, string idmauketqua)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_mauphieuin(idmauketqua);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauketqua)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_mauphieuin(idmauketqua), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauketqua)
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
            DataTable dtData = Data_dm_xetnghiem_mauphieuin(idmauketqua);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DataTable DSMauPhieuIn_ThaoTac()
        {
            var dtData = Data_dm_xetnghiem_mauphieuin(string.Empty);
            return dtData;
        }
        public DM_XETNGHIEM_MAUPHIEUIN Get_Info_dm_xetnghiem_mauphieuin(DataRow drMauKetQua)
        {
            DM_XETNGHIEM_MAUPHIEUIN obj = new DM_XETNGHIEM_MAUPHIEUIN();
            obj.Idmauketqua = drMauKetQua["idmauketqua"].ToString();
            if (!string.IsNullOrEmpty(drMauKetQua["mota"].ToString()))
                obj.Mota = drMauKetQua["mota"].ToString();
            if (!string.IsNullOrEmpty(drMauKetQua["hinhphieukq"].ToString()))
                obj.Hinhphieukq = (Image)drMauKetQua["hinhphieukq"];
            obj.Vitrisapxeptrai = int.Parse(drMauKetQua["vitrisapxeptrai"].ToString());
            obj.Vitrisapxepphai = int.Parse(drMauKetQua["vitrisapxepphai"].ToString());
            obj.Vitrisapxeptraigioihan = int.Parse(drMauKetQua["vitrisapxeptraigioihan"].ToString());
            obj.Vitrisapxepphaigioihan = int.Parse(drMauKetQua["vitrisapxepphaigioihan"].ToString());
            obj.Vitrisapxeptraingoai = int.Parse(drMauKetQua["vitrisapxeptraingoai"].ToString());
            obj.Vitrisapxepphaingoai = int.Parse(drMauKetQua["vitrisapxepphaingoai"].ToString());
            obj.Vitrisapxeptraigioihanngoai = int.Parse(drMauKetQua["vitrisapxeptraigioihanngoai"].ToString());
            obj.Vitrisapxepphaigioihanngoai = int.Parse(drMauKetQua["vitrisapxepphaigioihanngoai"].ToString());
            if (!string.IsNullOrEmpty(drMauKetQua["tenctm"].ToString()))
                obj.Tenctm = drMauKetQua["tenctm"].ToString();
            if (!string.IsNullOrEmpty(drMauKetQua["tendm"].ToString()))
                obj.Tendm = drMauKetQua["tendm"].ToString();
            if (!string.IsNullOrEmpty(drMauKetQua["tennm"].ToString()))
                obj.Tennm = drMauKetQua["tennm"].ToString();
            obj.Thutuin = int.Parse(drMauKetQua["thutuin"].ToString());
            obj.Idreport = drMauKetQua["idreport"].ToString();
            obj.Chiacot = (bool)drMauKetQua["chiacot"];
            obj.Kytentheoluoi = (bool)drMauKetQua["kytentheoluoi"];
            obj.Tachbschidinh = (bool)drMauKetQua["tachbschidinh"];
            obj.Tachnhomin = (bool)drMauKetQua["tachnhomin"];
            obj.Gheptenxnghichu = (bool)drMauKetQua["gheptenxnghichu"];
            obj.Ghichuduoixn = (bool)drMauKetQua["ghichuduoixn"];
            obj.Ghepghichukhoavaochung = (bool)drMauKetQua["ghepghichukhoavaochung"];
            obj.Dinhdangghepnhapkq = drMauKetQua["dinhdangghepnhapkq"].ToString();
            obj.Dinhdangghepduyetkq = drMauKetQua["dinhdangghepduyetkq"].ToString();
            obj.Lekqduoinguong = int.Parse(drMauKetQua["lekqduoinguong"].ToString());
            obj.Lekqtrennguong = int.Parse(drMauKetQua["lekqtrennguong"].ToString());
            obj.Lekqtrongnguong = int.Parse(drMauKetQua["lekqtrongnguong"].ToString());
            obj.Lenhom = int.Parse(drMauKetQua["lenhom"].ToString());
            obj.Batthuonggachchan = (bool)drMauKetQua["batthuonggachchan"];
            obj.Batthuongindam = (bool)drMauKetQua["batthuongindam"];
            obj.Batthuonginnghieng = (bool)drMauKetQua["batthuonginnghieng"];
            obj.Thoigianinlandau = (bool)drMauKetQua["thoigianinlandau"];
            obj.Tachtudong = (bool)drMauKetQua["tachtudong"];
            obj.Tachbophan = (bool)drMauKetQua["tachbophan"];
            obj.Tennhomgachchan = NumberConverter.To<bool>(drMauKetQua["tennhomgachchan"]);
            obj.Tennhomindam = NumberConverter.To<bool>(drMauKetQua["tennhomindam"]);
            obj.Tennhominnghieng = NumberConverter.To<bool>(drMauKetQua["tennhominnghieng"]);
            return obj;
        }
        public DM_XETNGHIEM_MAUPHIEUIN Get_Info_dm_xetnghiem_mauphieuin(string idmauketqua)
        {
            DataTable dt = Data_dm_xetnghiem_mauphieuin(idmauketqua);
            DM_XETNGHIEM_MAUPHIEUIN obj = new DM_XETNGHIEM_MAUPHIEUIN();
            if (dt.Rows.Count > 0)
            {
                return Get_Info_dm_xetnghiem_mauphieuin(dt.Rows[0]);
            }
            return obj;
        }

        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_mauphieuin_vitri
        public BaseModel Insert_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_VITRI (";
            sqlQuery += "\nIdmauketqua";
            sqlQuery += "\n,Mavitri";
            sqlQuery += "\n,Maxetnghiem";
            sqlQuery += "\n,Mota";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Idmauketqua.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Mavitri.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Maxetnghiem.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_VITRI where Maxetnghiem = '" + Utilities.ConvertSqlString(objInfo.Maxetnghiem.ToString()).ToString() + "'"))
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
                    Name = "Xét nghiệm đã cài đặt cho mẫu"
                };
            }
        }

        public bool Update_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_VITRI set";
            sqlQuery += string.Format("\n Mavitri = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mavitri.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Mota = {0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            sqlQuery += string.Format("\n, Luonhienthi = {0}", objInfo.Luonhienthi ? "1" : "0");
            sqlQuery += string.Format("\n, Noicot = {0}", objInfo.Noicot ? "1" : "0");
            sqlQuery += string.Format("\n, Indamten = {0}", objInfo.Indamten ? "1" : "0");
            sqlQuery += string.Format("\n, Hienthiten = {0}", (objInfo.Hienthiten < 0 ? "0" : objInfo.Hienthiten.ToString()));
            sqlQuery += string.Format("\n, Hienthiketqua = {0}", (objInfo.Hienthiketqua < 0 ? "0" : objInfo.Hienthiketqua.ToString()));
            sqlQuery += string.Format("\n, Hienthikqbatthuong = {0}", (objInfo.Hienthikqbatthuong < 0 ? "0" : objInfo.Hienthikqbatthuong.ToString()));
            sqlQuery += "\nwhere Maxetnghiem = '" + Utilities.ConvertSqlString(objInfo.Maxetnghiem.ToString()).ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_dm_xetnghiem_mauphieuin_vitri(DM_XETNGHIEM_MAUPHIEUIN_VITRI objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_VITRI";
            sqlQuery += string.Format("\n where Maxetnghiem = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maxetnghiem.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem)
        {
            string sqlQuery = "select vt.*, m.Mota as TenMau, xn.TenXN from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_VITRI vt  left join {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN m on vt.idmauketqua = m.idmauketqua left join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem xn on vt.maxetnghiem  = xn.maxn where 1=1";
            if (!string.IsNullOrEmpty(idmauketqua))
                sqlQuery += string.Format("\n and  vt.idmauketqua = {0}", "'" + idmauketqua + "'");
            if (!string.IsNullOrEmpty(mavitri))
                sqlQuery += string.Format("\n and  vt.mavitri = {0}", "'" + mavitri + "'");
            if (!string.IsNullOrEmpty(maxetnghiem))
                sqlQuery += string.Format("\n and  vt.maxetnghiem = {0}", "'" + maxetnghiem + "'");
            return sqlQuery;
        }
        public DataTable Data_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(DataGridView dtg, BindingNavigator bv, string idmauketqua, string mavitri, string maxetnghiem)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauketqua, string mavitri, string maxetnghiem)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_vitri(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauketqua, string mavitri, string maxetnghiem)
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
            DataTable dtData = Data_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_MAUPHIEUIN_VITRI Get_Info_dm_xetnghiem_mauphieuin_vitri(string idmauketqua, string mavitri, string maxetnghiem)
        {
            DataTable dt = Data_dm_xetnghiem_mauphieuin_vitri(idmauketqua, mavitri, maxetnghiem);
            DM_XETNGHIEM_MAUPHIEUIN_VITRI obj = new DM_XETNGHIEM_MAUPHIEUIN_VITRI();
            if (dt.Rows.Count > 0)

            {
                obj.Maxetnghiem = dt.Rows[0]["maxetnghiem"].ToString();
                obj.Idmauketqua = dt.Rows[0]["idmauketqua"].ToString();
                obj.Mavitri = dt.Rows[0]["mavitri"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["mota"].ToString()))
                    obj.Mota = dt.Rows[0]["mota"].ToString();
                obj.Luonhienthi = (bool)dt.Rows[0]["luonhienthi"];
                obj.Noicot = (bool)dt.Rows[0]["noicot"];
                obj.Indamten = (bool)dt.Rows[0]["indamten"];
                obj.Hienthiten = int.Parse(dt.Rows[0]["hienthiten"].ToString());
                obj.Hienthiketqua = int.Parse(dt.Rows[0]["Hienthiketqua"].ToString());
                obj.Hienthikqbatthuong = int.Parse(dt.Rows[0]["hienthikqbatthuong"].ToString());
            }
            return obj;
        }

        #endregion
        #region dm_xetnghiem_mauphieuin_tuychon
        public BaseModel Insert_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo)
        {
            string sqlQuery = "insert into {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_TUYCHON (";
            sqlQuery += "Idmauchon";
            sqlQuery += ",Tenmauchon";
            sqlQuery += ",Idmauketqua";
            sqlQuery += ",Idformsudung";
            sqlQuery += ",Idreport,MaNgonNgu";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "@Idmauchon";
            sqlQuery += ",@Tenmauchon";
            sqlQuery += ",@Idmauketqua";
            sqlQuery += ",@Idformsudung";
            sqlQuery += ",@Idreport,@MaNgonNgu";
            if (!DataProvider.CheckExisted(string.Format("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem_mauphieuin_tuychon where Idmauchon = '{0}'", objInfo.Idmauchon)))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery, new SqlParameter[] {
                    WorkingServices.GetParaFromOject("@Idmauchon", objInfo.Idmauchon),
                    WorkingServices.GetParaFromOject("@Tenmauchon", objInfo.Tenmauchon),
                    WorkingServices.GetParaFromOject("@Idmauketqua", objInfo.Idmauketqua),
                    WorkingServices.GetParaFromOject("@Idformsudung", objInfo.Idformsudung),
                    WorkingServices.GetParaFromOject("@Idreport", objInfo.Idreport),
                    WorkingServices.GetParaFromOject("@MaNgonNgu", objInfo.MaNgonNgu)
                    }),
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
        public bool Update_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_MAUPHIEUIN_TUYCHON set";
            sqlQuery += string.Format("\n Tenmauchon = {0}", (objInfo.Tenmauchon == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenmauchon.ToString()) + "'"));
            sqlQuery += string.Format("\n, Idmauketqua = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idmauketqua.ToString()) + "'");
            sqlQuery += string.Format("\n, Idformsudung = {0}", (objInfo.Idformsudung < 0 ? "0" : objInfo.Idformsudung.ToString()));
            sqlQuery += string.Format("\n, Idreport = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idreport.ToString()) + "'");
            sqlQuery += string.Format("\n, MaNgonNgu = {0}", "'" + Utilities.ConvertSqlString(objInfo.MaNgonNgu.ToString()) + "'");
            sqlQuery += "\nwhere Idmauchon =  '" + Utilities.ConvertSqlString(objInfo.Idmauchon.ToString()) + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_dm_xetnghiem_mauphieuin_tuychon(DM_XETNGHIEM_MAUPHIEUIN_TUYCHON objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem_mauphieuin_tuychon";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += string.Format("\n and Idmauchon = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idmauchon.ToString()) + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_dm_xetnghiem_mauphieuin_tuychon(string idmauchon)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem_mauphieuin_tuychon where 1=1";
            if (!string.IsNullOrEmpty(idmauchon))
                sqlQuery += string.Format("\n and  idmauchon = {0} ", "'" + idmauchon + "'");
            return sqlQuery;
        }
        public DataTable Data_dm_xetnghiem_mauphieuin_tuychon_CoMauCha(string idmauchon)
        {
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSachMauReport_TuyChon", WorkingServices.GetParaFromOject("@IdMaTuyChon", idmauchon)).Tables[0];
        }
        public DataTable Data_dm_xetnghiem_mauphieuin_tuychon(string idmauchon)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_mauphieuin_tuychon(idmauchon)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(DataGridView dtg, BindingNavigator bv, string idmauchon)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_mauphieuin_tuychon(idmauchon);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmauchon)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_mauphieuin_tuychon(idmauchon), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_mauphieuin_tuychon(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmauchon)
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
            DataTable dtData = Data_dm_xetnghiem_mauphieuin_tuychon(idmauchon);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_MAUPHIEUIN_TUYCHON Get_Info_dm_xetnghiem_mauphieuin_tuychon(string idmauchon)
        {
            DataTable dt = Data_dm_xetnghiem_mauphieuin_tuychon(idmauchon);
            DM_XETNGHIEM_MAUPHIEUIN_TUYCHON obj = new DM_XETNGHIEM_MAUPHIEUIN_TUYCHON();
            if (dt.Rows.Count > 0)

            {
                obj.Idmauchon = dt.Rows[0]["idmauchon"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenmauchon"].ToString()))
                    obj.Tenmauchon = dt.Rows[0]["tenmauchon"].ToString();
                obj.Idmauketqua = dt.Rows[0]["idmauketqua"].ToString();
                obj.Idformsudung = int.Parse(dt.Rows[0]["idformsudung"].ToString());
                obj.Idreport = dt.Rows[0]["idreport"].ToString();
                obj.MaNgonNgu = dt.Rows[0]["MaNgonNgu"].ToString();
            }
            return obj;
        }
        //================================|||=====================================
        #endregion
        //================================|||=====================================
        #region cauhinh_mayinketqua
        public BaseModel Insert_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo)
        {
            string sqlQuery = "insert into  {{TPH_Standard}}_Dictionary.dbo.CAUHINH_MAYINKETQUA (";
            sqlQuery += "\nPcname";
            sqlQuery += "\n,Printername";
            sqlQuery += "\n,Reporttemplateid";
            sqlQuery += "\n,Papersizetype";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += string.Format("\n {0}", "N'" + Utilities.ConvertSqlString(objInfo.Pcname.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", "N'" + Utilities.ConvertSqlString(objInfo.Printername.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Reporttemplateid.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n ,{0}", (objInfo.Papersizetype == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Papersizetype.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.CAUHINH_MAYINKETQUA where Pcname = N'" + Utilities.ConvertSqlString(objInfo.Pcname.ToString()).ToString() + "' and Printername =  N'" + Utilities.ConvertSqlString(objInfo.Printername.ToString()).ToString() + "' and Reporttemplateid =  '" + Utilities.ConvertSqlString(objInfo.Reporttemplateid.ToString()).ToString() + "'"))
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
                    Name = "Trùng cấu hình"
                };
            }
        }

        public bool Update_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfoNew, CAUHINH_MAYINKETQUA objInfoOld)
        {
            string sqlQuery = "Update {{TPH_Standard}}_Dictionary.dbo.CAUHINH_MAYINKETQUA set";
            sqlQuery += string.Format("\n Pcname = {0}", "N'" + Utilities.ConvertSqlString(objInfoNew.Pcname.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Printername = {0}", "N'" + Utilities.ConvertSqlString(objInfoNew.Printername.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Reporttemplateid = {0}", "'" + Utilities.ConvertSqlString(objInfoNew.Reporttemplateid.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n, Papersizetype = {0}", (objInfoNew.Papersizetype == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfoNew.Papersizetype.ToString()) + "'"));
            sqlQuery += "\nwhere  Pcname =  N'" + Utilities.ConvertSqlString(objInfoOld.Pcname.ToString()).ToString() + "'" + " and Printername =  " + "N'" + Utilities.ConvertSqlString(objInfoOld.Printername.ToString()).ToString() + "'" + " and Reporttemplateid =  " + "'" + Utilities.ConvertSqlString(objInfoOld.Reporttemplateid.ToString()).ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_cauhinh_mayinketqua(CAUHINH_MAYINKETQUA objInfo)
        {
            string sqlQuery = "Delete {{TPH_Standard}}_Dictionary.dbo.CAUHINH_MAYINKETQUA";
            sqlQuery += string.Format("\n where Pcname = {0}", "N'" + Utilities.ConvertSqlString(objInfo.Pcname.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n and Printername = {0}", "N'" + Utilities.ConvertSqlString(objInfo.Printername.ToString()).ToString() + "'");
            sqlQuery += string.Format("\n and Reporttemplateid = {0}", "'" + Utilities.ConvertSqlString(objInfo.Reporttemplateid.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid)
        {
            string sqlQuery = "select * from {{TPH_Standard}}_Dictionary.dbo.CAUHINH_MAYINKETQUA where 1=1";
            if (!string.IsNullOrEmpty(pcname))
                sqlQuery += string.Format("\n and  pcname = {0}", "'" + pcname + "'");
            if (!string.IsNullOrEmpty(printername))
                sqlQuery += string.Format("\n and  printername = {0}", "'" + printername + "'");
            if (!string.IsNullOrEmpty(reporttemplateid))
                sqlQuery += string.Format("\n and  reporttemplateid = {0}", "'" + reporttemplateid + "'");
            return sqlQuery;
        }
        public DataTable Data_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_cauhinh_mayinketqua(pcname, printername, reporttemplateid)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_cauhinh_mayinketqua(DataGridView dtg, BindingNavigator bv, string pcname, string printername, string reporttemplateid)
        {
            DataTable dtData = new DataTable();
            dtData = Data_cauhinh_mayinketqua(pcname, printername, reporttemplateid);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_cauhinh_mayinketqua(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string pcname, string printername, string reporttemplateid)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_cauhinh_mayinketqua(pcname, printername, reporttemplateid), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_cauhinh_mayinketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string pcname, string printername, string reporttemplateid)
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
            DataTable dtData = Data_cauhinh_mayinketqua(pcname, printername, reporttemplateid);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public CAUHINH_MAYINKETQUA Get_Info_cauhinh_mayinketqua(string pcname, string printername, string reporttemplateid)
        {
            DataTable dt = Data_cauhinh_mayinketqua(pcname, printername, reporttemplateid);
            CAUHINH_MAYINKETQUA obj = new CAUHINH_MAYINKETQUA();
            if (dt.Rows.Count > 0)

            {
                obj.Pcname = dt.Rows[0]["pcname"].ToString();
                obj.Printername = dt.Rows[0]["printername"].ToString();
                obj.Reporttemplateid = dt.Rows[0]["reporttemplateid"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["papersizetype"].ToString()))
                    obj.Papersizetype = dt.Rows[0]["papersizetype"].ToString();
            }
            return obj;
        }
        public List<CAUHINH_MAYINKETQUA> ListCauHinhMayIn(string tenmaytinh)
        {
            DataTable dt = Data_cauhinh_mayinketqua(tenmaytinh, string.Empty, string.Empty);
            List<CAUHINH_MAYINKETQUA> obj = new List<CAUHINH_MAYINKETQUA>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add
                        (
                        new CAUHINH_MAYINKETQUA
                        {
                            Pcname = dr["pcname"].ToString(),
                            Printername = dr["printername"].ToString(),
                            Reporttemplateid = dr["reporttemplateid"].ToString(),
                            Papersizetype = dr["papersizetype"].ToString(),
                        }
                        );
                }
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region Danh mục cho siêu âm
        //Data for MaNhomCLS_SieuAm
        public void Get_NhomCLS_SieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from  {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm where 0=0";
            strSql += filter;
            strSql += " order by MaNhomSieuAm";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindToGrid(dt, dtg, bv);
        }

        public void Get_NhomCLS_SieuAm(ref SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm where 0=0";
            strSql += filter;
            strSql += " order by MaNhomSieuAm";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_NhomCLS_SieuAm(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm where 0=0";
            strSql += filter;
            strSql += " order by MaNhomSieuAm";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomSieuAm", "TenNhomSieuAm");
        }

        public DataTable Get_NhomCLS_SieuAm(ComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm where 0=0";
            strSql += filter;
            strSql += " order by MaNhomSieuAm";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomSieuAm", "TenNhomSieuAm");
            }
            return dt;
        }

        public DataTable Get_NhomCLS_SieuAm(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from  {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm where 0=0";
            strSql += filter;
            strSql += " order by MaNhomSieuAm";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                cbo.ColumnNames = "MaNhomSieuAm,TenNhomSieuAm";
                cbo.ColumnWidths = "50,150";
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomSieuAm", "MaNhomSieuAm");
            }
            return dt;
        }

        //DM_MauSieuAm
        public void Get_DMSieuAm(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm ";
            strSql += filter;
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindToGrid(dt, dtg, bv);
        }
        public DataTable Get_DMSieuAm(string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm ";
            strSql += filter;
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

        }
        public int Insert_MaySieuAm(string tenMay)
        {
            var strSql = " insert into {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm (TenMay) values(N'" + tenMay + "')";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }
        public DataTable Get_DMSieuAm(CustomComboBox cbo, string filter, string maDoiTuongDv)
        {
            var strSql = "Select A.*, isnull(dv.GiaRieng, 0) as  GiaRieng, n.TenNhomSieuAm from (";
            strSql +=
                "\n select [MaSoMau],case when len([GoTat]) > 0 then [GoTat] else cast([MaSoMau] as varchar(10)) end as GoTat\n";
            strSql += ",[TenMauSieuAm],[TenChiDinh],[TieuDePhieuKetQua]\n";
            strSql += ",[GioiTinhSuDung],[ChanDoanMacDinh],[KetluanMacDinh]\n";
            strSql += ",[DeNghi]\n";
            strSql += " ,[SoLuongHinh]\n";
            strSql += ",[SoTrangIn]\n";
            strSql += ",[NoiDung1]\n";
            strSql += ",[NoiDung2]\n";
            strSql += ",[GiaChuan], MaNhomSieuAm ";
            strSql += "\nfrom {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm ";
            strSql += "\nwhere 1=1 ";
            strSql += filter;
            strSql += "\n) as A";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia dv on (dv.MaDichVu = cast(A.MaSoMau as varchar(15)) and dv.MaDichVu = '" +
                      maDoiTuongDv.Trim() + "') ";
            strSql += "\n left join  {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm n on a.MaNhomSieuAm = n.MaNhomSieuAm";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                if (!string.IsNullOrWhiteSpace(maDoiTuongDv))
                {
                    cbo.ColumnNames = "GoTat,TenMauSieuAm,GiaRieng";
                    cbo.ColumnWidths = "50,150, 50";
                }
                else
                {
                    cbo.ColumnNames = "GoTat,TenMauSieuAm";
                    cbo.ColumnWidths = "50,150";
                }
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaSoMau", "GoTat");
            }
            return dt;
        }
        public void Get_DMMaySA(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by TenMay";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DMMaySA(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm ";
            strSql += " order by TenMay";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "IDMay", "TenMay", "IDMay,TenMay", "15,150");

        }
        public void Get_DMMaySA(ComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm ";
            strSql += " order by TenMay";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "IDMay", "TenMay");

        }

        public int Insert_Update_DMSieuAm(string maNhomSieuAm, string maSoMau, string goTat, string tenMauSieuAm,
            string tenChiDinh, string tieuDePhieuKetQua, string gioiTinhSuDung, string chanDoanMacDinh,
            string ketluanMacDinh, string deNghi, string soLuongHinh, string soTrangIn, string noiDung1, string noiDung2,
            bool insert)
        {
            try
            {
                var strSql = "";
                if (insert)
                {
                    strSql =
                        "insert into {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm(MaNhomSieuAm,GoTat, TenMauSieuAm, TenChiDinh, TieuDePhieuKetQua, GioiTinhSuDung, ChanDoanMacDinh, KetluanMacDinh, DeNghi, SoLuongHinh, SoTrangIn, NoiDung1, NoiDung2)";
                    strSql += "\n select '" + maNhomSieuAm + "','" + goTat + "', N'" + tenMauSieuAm + "',N'" +
                              tenChiDinh + "',N'" + tieuDePhieuKetQua +
                              "','" + (string.IsNullOrWhiteSpace(gioiTinhSuDung) ? "A" : gioiTinhSuDung) + "',N'" +
                              Utilities.ConvertSqlString(chanDoanMacDinh) + "',N'" +
                              Utilities.ConvertSqlString(ketluanMacDinh) + "',N'" + deNghi + "'," +
                              (string.IsNullOrWhiteSpace(soLuongHinh) ? "0" : soLuongHinh) + "," +
                              (string.IsNullOrWhiteSpace(soTrangIn) ? "0" : soTrangIn) +
                              ",N'" + Utilities.ConvertSqlString(noiDung1) + "',N'" +
                              Utilities.ConvertSqlString(noiDung2) + "'";
                }
                else
                {
                    strSql = "update {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm set MaNhomSieuAm ='" + maNhomSieuAm + "', GoTat = '" + goTat +
                             "',TenMauSieuAm= N'" + tenMauSieuAm + "',TenChiDinh= N'" + tenChiDinh +
                             "',TieuDePhieuKetQua= N'" + tieuDePhieuKetQua +
                             "',GioiTinhSuDung='" + (string.IsNullOrWhiteSpace(gioiTinhSuDung) ? "A" : gioiTinhSuDung) +
                             "',ChanDoanMacDinh=N'" + Utilities.ConvertSqlString(chanDoanMacDinh) +
                             "',KetluanMacDinh=N'" + Utilities.ConvertSqlString(ketluanMacDinh) + "',DeNghi=N'" +
                             deNghi + "',SoLuongHinh=" + (string.IsNullOrWhiteSpace(soLuongHinh) ? "0" : soLuongHinh) +
                             ",SoTrangIn=" +
                             (string.IsNullOrWhiteSpace(soTrangIn) ? "0" : soTrangIn) +
                             ",NoiDung1=N'" + Utilities.ConvertSqlString(noiDung1) + "',NoiDung2=N'" +
                             Utilities.ConvertSqlString(noiDung2) + "' where MaSoMau = " + maSoMau;
                }
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            }
            catch
            {
                return -1;
            }
        }
        #endregion
        //================================|||=====================================
        #region Danh mục nội soi
        public void Get_NhomCLS_NoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi where 0=0";
            strSql += filter;
            strSql += " order by MaNhomNoiSoi";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_NhomCLS_NoiSoi(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi where 0=0";
            strSql += filter;
            strSql += " order by MaNhomNoiSoi";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public DataTable Get_NhomCLS_NoiSoi(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi where 0=0";
            strSql += filter;
            strSql += " order by MaNhomNoiSoi";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomNoiSoi", "TenNhomNoiSoi");
            return dt;
        }

        public DataTable Get_NhomCLS_NoiSoi(ComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi where 0=0";
            strSql += filter;
            strSql += " order by MaNhomNoiSoi";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomNoiSoi", "TenNhomNoiSoi");
            return dt;
        }

        public DataTable Get_NhomCLS_NoiSoi(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi where 0=0";
            strSql += filter;
            strSql += " order by MaNhomNoiSoi";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                cbo.ColumnNames = "MaNhomNoiSoi,TenNhomNoiSoi";
                cbo.ColumnWidths = "50,150";
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomNoiSoi", "MaNhomNoiSoi");
            }
            return dt;
        }

        //DM_MauNoiSoi
        public void Get_DMNoiSoi(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            var strSql = " select * from  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi ";
            strSql += filter;
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable Get_DMNoiSoi(string filter)
        {
            var strSql = " select * from  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi ";
            strSql += filter;
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

        }
        public void Insert_MayNoiSoi(string tenMay)
        {
            var strSql = " insert into {{TPH_Standard}}_Dictionary.dbo.DM_MayNoiSoi (TenMay) values(N'" + tenMay + "')";
            DataProvider.ExecuteDataset(CommandType.Text, strSql);
        }
        public DataTable Get_DMNoiSoi(CustomComboBox cbo, string filter, string maDoiTuongDv)
        {
            var strSql = "Select A.*,isnull(dv.GiaRieng, 0) as  GiaRieng, n.TenNhomNoiSoi from (";
            strSql +=
                "\nselect [MaSoMauNoiSoi],case when len([GoTat]) > 0 then [GoTat] else cast([MaSoMauNoiSoi] as varchar(10)) end as GoTat\n";
            strSql += ",[TenMauNoiSoi],[TenChiDinh],[TieuDePhieuKetQua]\n";
            strSql += ",[GioiTinhSuDung],[ChanDoanMacDinh],[KetluanMacDinh]\n";
            strSql += ",[DeNghi]\n";
            strSql += " ,[SoLuongHinh]\n";
            strSql += ",[SoTrangIn]\n";
            strSql += ",[NoiDung1]\n";
            strSql += ",[NoiDung2]\n";
            strSql += ",[GiaChuan],MaNhomNoiSoi from  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi  where 1=1";
            strSql += filter;
            strSql += "\n) as A";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia dv on (dv.MaDichVu = A.MaSoMauNoiSoi and dv.MaDichVu = '" +
                      maDoiTuongDv.Trim() + "') ";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi n on a.MaNhomNoiSoi = n.MaNhomNoiSoi";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                if (string.IsNullOrWhiteSpace(maDoiTuongDv))
                {
                    cbo.ColumnNames = "GoTat,TenMauNoiSoi";
                    cbo.ColumnWidths = "50,150";
                }
                else
                {
                    cbo.ColumnNames = "GoTat,TenMauNoiSoi, GiaRieng";
                    cbo.ColumnWidths = "50,150,50";
                }
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaSoMauNoiSoi", "GoTat");
            }
            return dt;
        }

        public void Get_DMMayNS(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MayNoiSoi where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by TenMay";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DMMayNS(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_MayNoiSoi ";
            strSql += " order by TenMay";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "IDMay", "TenMay", "IDMay,TenMay", "30,150");
        }

        public void Get_DM_NoiSoi_KyThuatHP(CustomComboBox cbo, TextBox txt)
        {
            var strSql = "Select * from {{TPH_Standard}}_Dictionary.dbo.DM_NoiSoi_KyThuatHP where 1=1";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (txt != null)
            {
                cbo.LinkedColumnIndex1 = 1;
                cbo.LinkedTextBox1 = txt;
            }
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaKyThuat", "MaKyThuat", "MaKyThuat,TenkyThuat", "50,150");

        }

        public void Get_DM_NoiSoi_KyThuatHP(CustomDatagridView dtg, BindingNavigator bv,
            ref SqlDataAdapter da, ref DataTable dt)
        {
            var strSql = "Select * from DM_NoiSoi_KyThuatHP where 1=1";
            dt = new DataTable();
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_NoiSoi_KetQuaHP(CustomComboBox cbo, TextBox txt)
        {
            var strSql = "Select * from DM_NoiSoi_KetQuaHP where 1=1";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (txt != null)
            {
                cbo.LinkedColumnIndex1 = 1;
                cbo.LinkedTextBox1 = txt;
            }
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaKetQua", "MaKetQua", "MaKetQua,GiaTri", "50,150");

        }

        public void Get_DM_NoiSoi_KetQuaHP(CustomDatagridView dtg, BindingNavigator bv,
            ref SqlDataAdapter da, ref DataTable dt)
        {
            var strSql = "Select * from DM_NoiSoi_KetQuaHP where 1=1";
            dt = new DataTable();
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public bool Insert_Update_DMNoiSoi(string maNhomNoiSoi, string maSoMauNoiSoi, string goTat, string tenMauNoiSoi,
            string tenChiDinh, string tieuDePhieuKetQua, string gioiTinhSuDung, string chanDoanMacDinh,
            string ketluanMacDinh, string deNghi, string soLuongHinh, string soTrangIn, string noiDung1, string noiDung2,
            bool insert)
        {
            try
            {
                var strSql = "";
                if (insert)
                {
                    strSql =
                        "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi(MaNhomNoiSoi,GoTat, TenMauNoiSoi, TenChiDinh, TieuDePhieuKetQua, GioiTinhSuDung, ChanDoanMacDinh, KetluanMacDinh, DeNghi, SoLuongHinh, SoTrangIn, NoiDung1, NoiDung2)";
                    strSql += "\n select '" + maNhomNoiSoi + "','" + goTat + "', N'" + tenMauNoiSoi + "',N'" +
                              tenChiDinh + "',N'" + tieuDePhieuKetQua +
                              "','" + (string.IsNullOrWhiteSpace(gioiTinhSuDung) ? "A" : gioiTinhSuDung) + "',N'" +
                              Utilities.ConvertSqlString(chanDoanMacDinh) + "',N'" +
                              Utilities.ConvertSqlString(ketluanMacDinh) + "',N'" + deNghi + "'," +
                              (string.IsNullOrWhiteSpace(soLuongHinh) ? "0" : soLuongHinh) + "," +
                              (string.IsNullOrWhiteSpace(soTrangIn) ? "0" : soTrangIn) +
                              ",N'" + Utilities.ConvertSqlString(noiDung1) + "',N'" +
                              Utilities.ConvertSqlString(noiDung2) + "'";
                }
                else
                {
                    strSql = "Update  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi set MaNhomNoiSoi ='" + maNhomNoiSoi + "', GoTat = '" + goTat +
                             "',TenMauNoiSoi= N'" + tenMauNoiSoi + "',TenChiDinh= N'" + tenChiDinh +
                             "',TieuDePhieuKetQua= N'" + tieuDePhieuKetQua +
                             "',GioiTinhSuDung='" + (string.IsNullOrWhiteSpace(gioiTinhSuDung) ? "A" : gioiTinhSuDung) +
                             "',ChanDoanMacDinh=N'" + Utilities.ConvertSqlString(chanDoanMacDinh) +
                             "',KetluanMacDinh=N'" + Utilities.ConvertSqlString(ketluanMacDinh) + "',DeNghi=" +
                             (string.IsNullOrWhiteSpace(deNghi) ? "NULL" : " N'" + deNghi + "'") + ",SoLuongHinh=" +
                             (string.IsNullOrWhiteSpace(soLuongHinh) ? "0" : soLuongHinh) + ",SoTrangIn=" +
                             (string.IsNullOrWhiteSpace(soTrangIn) ? "0" : soTrangIn) +
                             ",NoiDung1=N'" + Utilities.ConvertSqlString(noiDung1) + "',NoiDung2=N'" +
                             Utilities.ConvertSqlString(noiDung2) + "' where MaSoMauNoiSoi = " + maSoMauNoiSoi;
                }
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        //================================|||=====================================
        #region Danh mục thuốc
        public void Get_DM_Thuoc_GocThuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by MaGocThuoc,ThuTuIn";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_Thuoc_GocThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where 0=0 \n";
            strSql += filter;
            strSql += " order by MaGocThuoc,ThuTuIn";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DM_Thuoc_GocThuoc(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by MaGocThuoc,ThuTuIn";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaGocThuoc", "TenGocThuoc");
        }

        public void Get_DM_Thuoc_GocThuoc(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by  MaGocThuoc,ThuTuIn";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "MaGocThuoc,TenGocThuoc";
            cbo.ColumnWidths = "35,150";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaGocThuoc", "MaGocThuoc");
        }

        public bool Insert_GocThuoc(string maGocThuoc, string tenGocThuoc, string maNhomThuoc, string thuTuIn)
        {
            if (
                !DataProvider.CheckExisted("select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where MaGocThuoc = '" + maGocThuoc +
                                               "'"))
            {
                var strSql = "insert into {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc (MaGocThuoc, TenGocThuoc, MaNhomThuoc, ThuTuIn)";
                strSql += "\nSelect '" + Utilities.ConvertSqlString(maGocThuoc) + "', N'" +
                          Utilities.ConvertSqlString(tenGocThuoc) + "','" +
                          Utilities.ConvertSqlString(maNhomThuoc) + "'," + (thuTuIn == "" ? "0" : thuTuIn);
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Information_OK("Mã gốc thuốc đã tồn tại !\nHãy nhập mã khác.");
            return false;
        }

        //Nhóm thuốc
        public void Get_DM_Thuoc_NhomThuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by MaNhomThuoc";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_Thuoc_NhomThuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc where 0=0 \n";
            strSql += filter;
            strSql += " order by MaNhomThuoc";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public DataTable Get_DM_Thuoc_NhomThuoc(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where MaNhomThuoc = '" + filter + "'";
            }
            strSql += " order by MaNhomThuoc";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomThuoc", "TenNhomThuoc");
            return dt;
        }

        public DataTable Get_DM_Thuoc_NhomThuoc(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc ";
            strSql += " order by  MaNhomThuoc";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                cbo.ColumnNames = "MaNhomThuoc,TenNhomThuoc";
                cbo.ColumnWidths = "35,150";
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomThuoc", "MaNhomThuoc");
            }
            return dt;
        }

        public bool Insert_NhomThuoc(string maNhomThuoc, string tenNhomThuoc)
        {
            if (
                !DataProvider.CheckExisted("select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc where MaNhomThuoc = '" + maNhomThuoc +
                                               "'"))
            {
                var strSql = "insert into {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc (MaNhomThuoc,TenNhomThuoc)";
                strSql += "\nSelect '" + Utilities.ConvertSqlString(maNhomThuoc) + "', N'" +
                          Utilities.ConvertSqlString(tenNhomThuoc) + "'";
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Information_OK("Mã nhóm thuốc đã tồn tại !\nHãy nhập mã khác.");
            return false;
        }

        //Thuốc
        public void Get_DM_Thuoc(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql =
                " select T.[MaThuoc],T.[TenThuoc],T.[MaVatTu],T.[MaGocThuoc],T.[DonViTinh],T.[CachDung],T.[Sang],T.[Trua],T.[Chieu],T.[Toi]";
            strSql += "\n,T.GoTat,T.SapXep";
            strSql += "\n from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T ";
            strSql += "\n where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += "\n " + filter;
            }
            strSql += " order by T.SapXep,T.MaThuoc";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_Thuoc(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc where 0=0 \n";
            strSql += filter;
            strSql += " order by SapXep,MaThuoc";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DM_Thuoc(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where MaThuoc = '" + filter + "'";
            }
            strSql += " order by SapXep,MaThuoc";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaThuoc", "TenThuoc");
        }

        public void Get_DM_Thuoc(CustomComboBox cbo, string filter)
        {
            var strSql =
                " select T.*, G.MaNhomThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on t.MaGocThuoc = g.MaGocThuoc where 1=1 ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += Environment.NewLine + filter;
            }
            strSql += " order by  SapXep,MaThuoc";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "MaThuoc,TenThuoc, DonViTinh";
            cbo.ColumnWidths = "35,150, 50";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaThuoc", "GoTat");
        }

        public void Get_DM_Thuoc_List(ListView lst, ImageList iml, int indexNormal, string itemdId, string categoryId)
        {
            var strSql =
                "select T.*,N.TenGocthuoc, NT.TenNhomThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc N on T.MaGocThuoc = N.MaGocThuoc inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc NT on NT.MaNhomThuoc = N.MaNhomThuoc   where 1=1";
            if (!string.IsNullOrWhiteSpace(categoryId))
            {
                strSql += "\n and NT.MaNhomThuoc = '" + categoryId.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(itemdId))
            {
                strSql += "\n and MaThuoc = '" + itemdId.Trim() + "'";
            }
            var dtIt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            lst.BeginUpdate();
            lst.Clear();
            lst.SmallImageList = iml;
            lst.LargeImageList = iml;
            //lst.CheckBoxes = true;
            // lst.MultiSelect = true;
            //  lst.View = View.Details;
            lst.ShowGroups = true;
            lst.LabelWrap = true;
            lst.AutoArrange = false;
            lst.Alignment = ListViewAlignment.Left;
            lst.MultiSelect = false;

            var groupId = string.Empty;

            var grp = new ListViewGroup();
            var clh = new ColumnHeader();
            //Tạo 3 cột 
            lst.Columns.Add(string.Empty, 250, HorizontalAlignment.Center);
            //Đặt biến để add
            //Biến đếm
            foreach (DataRow item in dtIt.Rows)
            {
                if (groupId != item["MaGocThuoc"].ToString().Trim())
                {
                    if (!string.IsNullOrWhiteSpace(groupId))
                    {
                        grp = new ListViewGroup();
                    }

                    groupId = item["MaGocThuoc"].ToString().Trim();
                    grp.Header = item["TenGocThuoc"].ToString();
                    grp.Name = item["MaGocThuoc"].ToString();
                    grp.HeaderAlignment = HorizontalAlignment.Left;
                    lst.Groups.Add(grp);
                }

                var itemAdd = new ListViewItem();
                Addrange(itemAdd, grp, item, indexNormal);

                lst.Items.Add(itemAdd);
            }

            lst.EndUpdate();
        }
        public DataTable Get_DM_Thuoc_List(string itemdId, string categoryId, string _MaTiepNhan = "", string _MaDonVi = "", string _MaYeuCau = "")
        {
            var strSql =
                "select T.*,N.TenGocthuoc, NT.TenNhomThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc N on T.MaGocThuoc = N.MaGocThuoc inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc NT on NT.MaNhomThuoc = N.MaNhomThuoc \n";
            strSql += "where t.MaThuoc not in(select mathuoc from KhamBenh_DonThuoc where MaTiepNhan = '" + _MaTiepNhan + "' and MaDonVi ='" + _MaDonVi + "' and  MaYeuCau ='" + _MaYeuCau + "')\n";
            if (!string.IsNullOrWhiteSpace(categoryId))
            {
                strSql += "\n and NT.MaNhomThuoc = '" + categoryId.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(itemdId))
            {
                strSql += "\n and MaThuoc = '" + itemdId.Trim() + "'";
            }
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

        }
        //private void Addrange(ListViewItem it, ListViewGroup grp, DataRow item, int indexNormal)
        //{
        //    it.Text = item["TenThuoc"].ToString();
        //    if (it.Text.ToLower().Contains("sổ"))
        //    {
        //        it.ImageIndex = (indexNormal + 1);
        //    }
        //    else if (it.Text.ToLower().Contains("khám"))
        //    {
        //        it.ImageIndex = (indexNormal + 2);
        //    }
        //    else if (it.Text.ToLower().Contains("tiêm") || item["TenNhomThuoc"].ToString().ToLower().Contains("ngừa"))
        //    {
        //        it.ImageIndex = (indexNormal + 3);
        //    }
        //    else if (it.Text.ToLower().Contains("siêu âm"))
        //    {
        //        it.ImageIndex = (indexNormal + 4);
        //    }
        //    else if (it.Text.ToLower().Contains("điện tim"))
        //    {
        //        it.ImageIndex = (indexNormal + 5);
        //    }
        //    else
        //    {
        //        it.ImageIndex = indexNormal;
        //    }

        //    it.Name = item["MaThuoc"].ToString();
        //    // it.Tag = (bool)item["SeriumType"];
        //    it.Group = grp;
        //}
        public bool Insert_Update_Thuoc(string maThuoc, string tenThuoc, string maVatTu,
            string maGocThuoc, string donViTinh, string cachDung, string sang, string trua,
            string chieu, string toi, string goTat, string sapXep, string gia, bool update)
        {
            tenThuoc = Utilities.ConvertSqlString(tenThuoc);
            donViTinh = Utilities.ConvertSqlString(donViTinh);
            cachDung = Utilities.ConvertSqlString(cachDung);
            var strSql = "";
            if (update)
            {
                strSql = "update {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc set TenThuoc=N'" + tenThuoc + "',MaVatTu = '" + maVatTu + "', GoTat ='" +
                         goTat + "',SapXep = " + (string.IsNullOrWhiteSpace(sapXep) ? "0" : sapXep);
                strSql += "\n,DonViTinh=N'" + donViTinh + "',CachDung=N'" + cachDung + "',Sang=N'" + sang +
                          "',Trua = N'" + sang + "',Chieu = N'" + sang + "',Toi = N'" + sang + "', Gia = " +
                          (string.IsNullOrWhiteSpace(gia) ? "0" : gia);
                strSql += "where MaThuoc='" + maThuoc + "' and MaGocThuoc = '" + maGocThuoc + "'";
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            if (!DataProvider.CheckExisted("select MaThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc where MaThuoc = '" + maThuoc + "'"))
            {
                strSql =
                    "insert into {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc (MaThuoc, TenThuoc, MaVatTu, MaGocThuoc, DonViTinh, CachDung, Sang, Trua, Chieu, Toi,GoTat,SapXep)";
                strSql += "\nselect '" + maThuoc + "',N'" + tenThuoc + "','" + maVatTu + "','" + maGocThuoc +
                          "',N'" + donViTinh + "',N'" + cachDung + "',N'" + sang + "',N'" + trua + "'";
                strSql += "\n,'" + chieu + "','" + toi + "','" + goTat + "'," +
                          (string.IsNullOrWhiteSpace(sapXep) ? "0" : sapXep);
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Waring_OK("Mã thuốc đã tồn tại !\nHãy chọn mã khác.");

            return false;
        }
        public bool Delete_Thuoc(string maThuoc)
        {
            var strSql = "";
            strSql = "Delete from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc where MaThuoc = '" + maThuoc + "'";
            //Kiểm tra thuốc đã được sử dụng trước khi xóa
            if (
                !DataProvider.CheckExisted("select top 1 * from KhamBenh_DonThuoc where MaThuoc = '" + maThuoc +
                                               "'"))
            {
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Waring_OK("Thuốc đã sử dụng !\n Không thể xóa.");
            return false;
        }
        private string SQL_Select_Data_DMThuoc_ForIn_Output(string manhacungcap, string manhomthuoc)
        {
            var strSql =
                "\nselect t.MaThuoc as MaVatTu, t.TenThuoc as TenVatTu,CoHSD, case when t.XuatTheoQCDG = 1 then t.DVTQuiCachCap1 else T.DonViTinh end as DonViTinh , v.MaLoaiVatTu, v.MaNhaCungCap from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t inner join VT_NhaCungCap_VatTu v on (v.MaVatTu = t.MaThuoc and MaLoaiVatTu = 'THUOC')";
            strSql += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on t.MaGocThuoc = g.MaGocThuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(manhacungcap))
            {
                strSql += "\nand v.MaNhaCungCap = '" + manhacungcap.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(manhomthuoc))
            {
                strSql += "\n and g.MaNhomThuoc = '" + manhomthuoc + "'";
            }

            return strSql;
        }

        private string SQL_Select_Data_DMThuoc_ForWork(string manhacungcap, string manhomthuoc, string maDoiTuongDv)
        {
            var strSql = "Select A.*,isnull(C.TonKho,0) as TonKho, isnull(dv.GiaRieng, 0) as  GiaRieng, n.TenNhomThuoc from (";
            strSql +=
                "\nselect t.MaThuoc as MaVatTu, t.TenThuoc as TenVatTu,CoHSD, case when t.XuatTheoQCDG = 1 then t.DVTQuiCachCap1 else T.DonViTinh end as DonViTinh,g.MaNhomThuoc  from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t ";
            strSql += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on t.MaGocThuoc = g.MaGocThuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(manhacungcap))
            {
                strSql += "\nand v.MaNhaCungCap = '" + manhacungcap.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(manhomthuoc))
            {
                strSql += "\n and g.MaNhomThuoc = '" + manhomthuoc + "'";
            }
            strSql += "\n) as A";
            strSql += "\nLeft join ( ";
            strSql += "\nSelect sum(B.TonKho - B.SLX) as TonKho, B.MaVatTu";
            strSql += "\nfrom (";
            strSql += "\n\t select 0 as TonKho, sum(soluong) as SLX, MaThuoc as MaVatTu  from ThuPhi_Thuoc";
            strSql += "\n\t Group by MaThuoc";
            strSql += "\n\t union ";
            strSql +=
                "\n\t select sum(case when XuatTheoQCDG = 1 then SoLuongTheoQuiCach else SoLuongNhap end) as TonKho , 0 as SLX, MaVatTu as MaVatTu";
            strSql += "\n\t from VT_NhapKho_ChietTiet_Thuoc";
            strSql += "\n\t Group by MaVatTu";
            strSql += "\n\t ) as B Group by B.MaVatTu";
            strSql += "\n) as C on A.MaVatTu = C.MaVatTu";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia dv on (dv.MaDichVu = A.MaVatTu and dv.MaDoiTuongDichVu = '" +
                      maDoiTuongDv.Trim() + "') ";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc n on a.MaNhomThuoc = n.MaNhomThuoc";

            return strSql;
        }
        public DataTable Data_DM_Thuoc_ForWork(CustomComboBox cbo, string valueColumn, string displayColumn,
 string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
 string maNhaCungCap, string manhomThuoc, string doiTuongDv)
        {
            var dt =
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_DMThuoc_ForWork(maNhaCungCap, manhomThuoc, doiTuongDv)).Tables[0];
            if (cbo != null)
            {
                ControlExtension.BindDataToCobobox(dt, ref cbo, valueColumn, displayColumn, columnsName, columnsWidth,
                    txt, linkColumnIndex);
            }
            return dt;
        }

        public void Data_DM_Thuoc_ForInput(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
            string maNhaCungCap, string manhomThuoc)
        {
            cbo.ValueMember = valueColumn;
            cbo.DisplayMember = displayColumn;
            cbo.ColumnNames = columnsName;
            cbo.ColumnWidths = columnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = linkColumnIndex;
            }
            var dt =
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_DMThuoc_ForIn_Output(maNhaCungCap, manhomThuoc)).Tables[0];
            cbo.DataSource = dt;
            cbo.SelectedIndex = -1;
        }
        //Cách dùng
        public void Get_DM_Thuoc_CachDung(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where ID = '" + filter + "'";
            }
            strSql += " order by TenCachDung";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public DataTable Get_DM_Thuoc_CachDung()
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung ";
            strSql += " order by  TenCachDung";
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

        }
        public void Get_DM_Thuoc_CachDung(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung where 0=0 \n";
            strSql += filter;
            strSql += " order by TenCachDung";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DM_Thuoc_CachDung(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where ID = '" + filter + "'";
            }
            strSql += " order by TenCachDung";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "TenCachDung", "TenCachDung");
        }

        public void Get_DM_Thuoc_CachDung(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where ID = '" + filter + "'";
            }
            strSql += " order by  TenCachDung";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "TenCachDung";
            cbo.ColumnWidths = "150";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "ID", "TenCachDung");
        }

        public void Get_DM_Thuoc_CachDung(DataGridViewComboBoxColumn cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung ";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += " where ID = '" + filter + "'";
            }
            strSql += " order by  TenCachDung";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.DataSource = dt;
            cbo.ValueMember = "ID";
            cbo.DisplayMember = "TenCachDung";
            //  cbo.DisplayIndex = -1;
        }


        // BẢNG {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile
        // Getdata 
        public void Get_DM_THUOC_PROFILE(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by maprofile,tenprofile";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_THUOC_PROFILE(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile where 0=0 ";
            strSql += filter;
            strSql += " order by maprofile,tenprofile";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DM_THUOC_PROFILE(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by maprofile,tenprofile";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "maprofile,tenprofile";
            cbo.ColumnWidths = "50,150";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "maprofile", "maprofile");
        }

        public void Get_DM_THUOC_PROFILE(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by maprofile,tenprofile";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "maprofile,tenprofile";
            cbo.ColumnWidths = "50,150";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "maprofile", "maprofile");
        }

        // Insert 
        public bool Insert_DM_Thuoc_Profile(string maprofile, string tenprofile)
        {
            var strSql = "insert into  {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile (";
            strSql += Environment.NewLine + "maprofile";
            strSql += Environment.NewLine + "," + "tenprofile";
            strSql += Environment.NewLine + ")";
            strSql += Environment.NewLine + "select ";
            strSql += Environment.NewLine + (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'");
            strSql += Environment.NewLine + "," +
                      (string.IsNullOrWhiteSpace(tenprofile) ? "NULL" : "N'" + tenprofile + "'");
            if (
                !DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile where 1 = 1  and maprofile =  " +
                                               (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'")))
            {
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Waring_OK("Mã profile trùng !\nHãy chọn mã khác.");
            return false;
        }

        // Update 
        public bool Update_DM_THUOC_PROFILE(string maprofile, string tenprofile)
        {
            var strSql = "Update {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile set " + Environment.NewLine;
            strSql += Environment.NewLine + "tenprofile = " +
                      (string.IsNullOrWhiteSpace(tenprofile) ? "NULL" : "N'" + tenprofile + "'");
            strSql += Environment.NewLine + " where 1=1 ";
            strSql += Environment.NewLine + " and maprofile =  " +
                      (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
        }

        // Delete 
        public bool Delete_DM_THUOC_PROFILE(string maprofile)
        {
            var strSql = "Delete from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile" + Environment.NewLine;
            strSql += Environment.NewLine + " where 1=1 ";
            strSql += Environment.NewLine + " and maprofile =  " +
                      (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
        }

        // BẢNG {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_ChiTiet
        // Getdata 
        public void Get_DM_THUOC_PROFILE_CHITIET(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql =
                " select p.*, T.TenThuoc from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_CHITIET p inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T on P.Mathuoc = T.MaThuoc where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by mathuoc";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_THUOC_PROFILE_CHITIET(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv,
            string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_CHITIET  where 0=0 ";
            strSql += filter;
            strSql += " order by mathuoc";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DM_THUOC_PROFILE_CHITIET(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql =
                " select p.*, T.TenThuoc from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_CHITIET p inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T on P.Mathuoc = T.MaThuoc where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by mathuoc";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "mathuoc";
            cbo.ColumnWidths = "50";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "mathuoc", "mathuoc");
        }

        public void Get_DM_THUOC_PROFILE_CHITIET(CustomComboBox cbo, string filter)
        {
            var strSql =
                " select p.*, T.TenThuoc from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_CHITIET p inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T on P.Mathuoc = T.MaThuoc where 1 = 1";
            if (filter != "")
            {
                strSql += filter;
            }
            strSql += " order by mathuoc";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "mathuoc";
            cbo.ColumnWidths = "50";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "mathuoc", "mathuoc");
        }

        // Insert 
        public bool Insert_DM_Thuoc_Profile_ChiTiet(string maprofile, string mathuoc)
        {
            var strSql = "insert into  {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_CHITIET (";
            strSql += Environment.NewLine + "maprofile";
            strSql += Environment.NewLine + "," + "mathuoc";
            strSql += Environment.NewLine + "," + "CachDung";
            strSql += Environment.NewLine + "," + "Sang";
            strSql += Environment.NewLine + "," + "Trua";
            strSql += Environment.NewLine + "," + "Chieu";
            strSql += Environment.NewLine + "," + "Toi";
            strSql += Environment.NewLine + ")";
            strSql += Environment.NewLine + "select ";
            strSql += Environment.NewLine + (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'");
            strSql += Environment.NewLine + "," + (string.IsNullOrWhiteSpace(mathuoc) ? "''" : "'" + mathuoc + "'");
            strSql += Environment.NewLine + ",T.CachDung";
            strSql += Environment.NewLine + ",T.Sang";
            strSql += Environment.NewLine + ",T.Trua";
            strSql += Environment.NewLine + ",T.Chieu";
            strSql += Environment.NewLine + ",T.Toi";
            strSql += Environment.NewLine + " From {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T where T.MaThuoc ='" + mathuoc + "'";
            if (
                !DataProvider.CheckExisted(
                    "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_ChiTiet where 1 = 1  and maprofile =  " +
                    (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'") + " and mathuoc =  " +
                    (string.IsNullOrWhiteSpace(mathuoc) ? "''" : "'" + mathuoc + "'")))
            {
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Waring_OK("Thuốc đã nhập trước cho profile này !\nHãy chọn thuốc khác.");
            return false;
        }

        // Update 
        public bool Update_DM_THUOC_PROFILE_CHITIET(string maprofile, string mathuoc, string cachDung, string sang,
            string trua, string chieu, string toi)
        {
            var strSql = "Update {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_ChiTiet set " + Environment.NewLine;
            strSql += Environment.NewLine + " CachDung =  " +
                      (string.IsNullOrWhiteSpace(cachDung) ? "NULL" : "'" + cachDung.Trim() + "'");
            strSql += Environment.NewLine + ", Sang =  " +
                      (string.IsNullOrWhiteSpace(sang) ? "NULL" : "'" + sang.Trim() + "'");
            strSql += Environment.NewLine + ", Trua =  " +
                      (string.IsNullOrWhiteSpace(trua) ? "NULL" : "'" + trua.Trim() + "'");
            strSql += Environment.NewLine + ", Chieu =  " +
                      (string.IsNullOrWhiteSpace(chieu) ? "NULL" : "'" + chieu.Trim() + "'");
            strSql += Environment.NewLine + ", Toi =  " +
                      (string.IsNullOrWhiteSpace(mathuoc) ? "NULL" : "'" + toi.Trim() + "'");
            strSql += Environment.NewLine + " where maprofile =  " +
                      (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'");
            strSql += Environment.NewLine + " and mathuoc =  " +
                      (string.IsNullOrWhiteSpace(mathuoc) ? "''" : "'" + mathuoc + "'");

            return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
        }

        // Delete 
        public bool Delete_DM_THUOC_PROFILE_CHITIET(string maprofile, string mathuoc)
        {
            var strSql = "Delete from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_ChiTiet" + Environment.NewLine;
            strSql += Environment.NewLine + " where 1=1 ";
            strSql += Environment.NewLine + " and maprofile =  " +
                      (string.IsNullOrWhiteSpace(maprofile) ? "''" : "'" + maprofile + "'");
            strSql += Environment.NewLine + " and mathuoc =  " +
                      (string.IsNullOrWhiteSpace(mathuoc) ? "''" : "'" + mathuoc + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
        }

        public void GET_THUOC_VA_PROFILE(CustomComboBox cbo, TextBox txt, string nhomThuoc)
        {
            var strSql =
                "Select cast(0 as int) as SortOrder , 'P' as Profile, cast (1 as bit) as IsProfile, TenProfile as ItemName, MaProfile as ItemCode ";
            strSql += "\nfrom {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile";
            strSql += "\nunion all";
            strSql +=
                "\nSelect cast(1 as int) as SortOrder , 'T' as Profile, cast (0 as bit) as IsProfile, TenThuoc as ItemName, MaThuoc as ItemCode ";
            strSql += "\nfrom {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc";
            if (!string.IsNullOrWhiteSpace(nhomThuoc))
            {
                strSql += "\nwhere MaGocThuoc ='" + nhomThuoc + "'";
            }
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (txt != null)
            {
                cbo.LinkedColumnIndex1 = 2;
                cbo.LinkedTextBox1 = txt;
            }
            ControlExtension.BindDataToCobobox(dt, ref cbo, "Itemcode", "ItemCode", "Profile,ItemCode,ItemName", "30,50,150");
        }
        #endregion
        //================================|||=====================================
        #region Danh mục khám bệnh
        public bool Insert_DM_KhamBenh_NhomDichVu(string maNhom, string tenNhom, string thuTuIn)
        {
            if (
                !DataProvider.CheckExisted("select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu where MaNhomDichVu ='" +
                                               maNhom.Trim() + "'"))
            {
                string strSql = string.Empty;

                strSql = "insert into {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu ([MaNhomDichVu] ,[TenNhomDichVu] ,[ThuTuIn])";
                strSql += "\n Values('" + maNhom + "',N'" + Utilities.ConvertSqlString(tenNhom) + "'," +
                          (thuTuIn == "" ? "0" : thuTuIn) + ")";
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1;
            }
            else
            {
                CustomMessageBox.MSG_Error_OK("Mã nhóm đã tồn tại!\nHãy chọn mã nhóm khác");
                return false;
            }
        }
        //Lấy danh sách nhóm lên lưới
        public void Get_DM_KhamBenh_NhomDichVu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu where 0=0";
            strSql += filter;
            strSql += " order by MaNhomDichVu";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }
        //Lấy danh sách lên combobox
        public DataTable Get_DM_KhamBenh_NhomDichVu(ComboBox cbo, string filter)
        {
            DataTable dt = new DataTable();
            string strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu where 0=0";
            strSql += filter;
            strSql += " order by TenNhomDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomDichVu", "TenNhomDichVu");
            return dt;
        }

        public DataTable Get_DM_KhamBenh_NhomDichVu(CustomComboBox cbo, string filter, TextBox txt)
        {
            var dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu where 0=0";
            strSql += filter;
            strSql += " order by MaNhomDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaNhomDichVu", "MaNhomDichVu", "MaNhomDichVu,TenNhomDichVu",
                    "50,200");
            return dt;
        }
        //Thêm mới dịch vụ yêu cầu
        public bool Insert_KhamBenh_DichVu(string maNhomDichVu, string maYeuCau, string tenYeucau, string ghiChuMacDinh,
            string deNghiMacDinh, string giaChuan)
        {
            if (
                !DataProvider.CheckExisted("select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu where MaNhomDichVu ='" +
                                               maYeuCau.Trim() + "'"))
            {
                string strSql = string.Empty;
                strSql =
                    "insert into {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu ([MaYeuCau],[MaNhomDichVu],[TenYeuCau],[GhiChuMacDinh],[DeNghiMacDinh],[GiaChuan])";
                strSql += "\n Values('" + maYeuCau + "','" + maNhomDichVu + "',N'" + Utilities.ConvertSqlString(tenYeucau) +
                          "',N'" + Utilities.ConvertSqlString(ghiChuMacDinh)
                          + "',N'" + Utilities.ConvertSqlString(deNghiMacDinh) + "'," +
                          (string.IsNullOrWhiteSpace(giaChuan) ? "0" : giaChuan) + ")";
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1;

            }

            CustomMessageBox.MSG_Error_OK("Mã dịch vụ đã tồn tại!\nHãy chọn mã nhóm khác");
            return false;
        }
        //Lấy danh sách yêu cầu lên lưới
        public void Get_DM_KhamBenh_DichVu(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            string maNhom, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu where 0=0";
            if (string.IsNullOrWhiteSpace(maNhom))
                strSql += " and MaNhomDichVu = '" + maNhom.Trim() + "'";
            strSql += filter;
            strSql += " order by MaYeuCau";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }
        //Lấy danh sách yêu cầu lên combobox
        public void Get_DM_KhamBenh_DichVu(ComboBox cbo, string maNhom, string filter)
        {
            DataTable dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu where 0=0";
            if (!string.IsNullOrWhiteSpace(maNhom))
                strSql += " and MaNhomDichVu = '" + maNhom.Trim() + "'";
            strSql += filter;
            strSql += " order by MaYeuCau";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaYeuCau", "TenYeuCau");
        }
        public DataTable Get_DM_KhamBenh_DichVu(CustomComboBox cbo, string maNhom, string filter, TextBox txt,
            string maDoiTuongDv)
        {
            var dt = new DataTable();
            var strSql = "select A.*, isnull(dv.GiaRieng, 0) as  GiaRieng, n.TenNhomDichVu from (";
            strSql += "\n select * from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu where 0=0";
            if (!string.IsNullOrWhiteSpace(maNhom))
                strSql += " and MaNhomDichVu = '" + maNhom.Trim() + "'";
            strSql += filter;
            strSql += "\n) as A";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia dv on (dv.MaDichVu = A.MaYeuCau and dv.MaDichVu = '" +
                      maDoiTuongDv.Trim() + "')";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu n on a.MaNhomDichVu = n.MaNhomDichVu";
            strSql += " order by A.MaYeuCau";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                if (string.IsNullOrWhiteSpace(maDoiTuongDv))
                {
                    ControlExtension.BindDataToCobobox(dt, ref cbo, "MaYeuCau", "MaYeuCau", "MaYeuCau,TenYeuCau",
                        "50,200");
                }
                else
                    ControlExtension.BindDataToCobobox(dt, ref cbo, "MaYeuCau", "MaYeuCau",
                        "MaYeuCau,TenYeuCau,GiaRieng",
                        "50,200,50");
            }
            return dt;
        }
        #endregion
        //================================|||=====================================
        #region Danh mục XQuang
        //Danh mục KyThuatChup
        public void Get_DM_XQuang_KyThuat(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup where 0=0 \n";
            strSql += filter;
            strSql += " order by ThuTuIn,TenKyThuatChup";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DM_XQuang_KyThuat(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup where 0=0 \n";
            strSql += filter;
            strSql += " order by ThuTuIn,TenKyThuatChup";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public DataTable Get_DM_XQuang_KyThuat(CustomComboBox cbo)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup where 0=0 \n";
            strSql += " order by ThuTuIn,TenKyThuatChup";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaKyThuatChup", "TenKyThuatChup");
                cbo.ColumnNames = "MaKyThuatChup,TenKyThuatChup";
                cbo.ColumnWidths = "50,250";
            }
            return dt;
        }
        //Danh mục Vùng Chụp
        public void Get_DM_XQuang_VungChup(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where 0=0 \n";
            strSql += filter;
            strSql += " order by ThuTuIn, TenVungChup";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DM_XQuang_VungChup(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where 0=0 \n";
            strSql += filter;
            strSql += " order by ThuTuIn, TenVungChup";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }
        public DataTable Get_DM_XQuang_VungChup(CustomComboBox cbo, string filter, string maDoiDuongDv)
        {
            string strSql = "";
            strSql += "select A.*, dv.GiaRieng, n.TenKyThuatChup from (";
            strSql += "\n select * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where 0=0 \n";
            strSql += filter;
            strSql += ") as A";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia dv on (dv.MaDoiTuongDichVu = '" + maDoiDuongDv +
                       "' and dv.MaDichVu = A.MaVungChup )";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup n on n.MaKyThuatChup = a.MaKyThuatChup";
            strSql += "\n order by ThuTuIn, TenVungChup";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                if (!string.IsNullOrWhiteSpace(maDoiDuongDv))
                {
                    cbo.ColumnNames = "MaVungChup,TenVungChup, GiaRieng";
                    cbo.ColumnWidths = "50,250, 50";
                }
                else
                {
                    cbo.ColumnNames = "MaVungChup,TenVungChup";
                    cbo.ColumnWidths = "50,250";
                }
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaVungChup", "MaVungChup");
            }
            return dt;
        }
        //Danh mục chi tiết vùng chụp
        public void Get_DM_XQuang_VungChup_ChiTiet(DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from DM_XQuang_VungChup_ChiTiet where 0=0 \n";
            strSql += filter;
            strSql += " order by ThuTuInVungChup, ThuTuSapXep, TenChiTiet";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_XQuang_VungChup_ChiTiet(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv,
            string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from DM_XQuang_VungChup_ChiTiet where 0=0 \n";
            strSql += filter;
            strSql += " order by  ThuTuInVungChup, ThuTuSapXep, TenChiTiet";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }
        public void Get_DM_XQuang_VungChup_ChiTiet(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from DM_XQuang_VungChup_ChiTiet where 0=0 \n";
            strSql += filter;
            strSql += "\n order by  ThuTuInVungChup, ThuTuSapXep, TenChiTiet";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaChiTiet", "TenChiTiet");
            cbo.ColumnNames = "MaVungChup,MaChiTiet,TenChiTiet";
            cbo.ColumnWidths = "50,50,250";
        }
        //Danh mục KyThuatChup
        //Insert
        public void Insert_KyThuat(string maKyThuat, string tenKyThuat, string thuTuIn)
        {
            if (
                !DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup where MaKyThuatChup ='" +
                                               maKyThuat.Trim() + "'"))
            {
                var strSql = "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup (MaKyThuatChup, TenKyThuatChup, ThuTuIn)\n";
                strSql += " select '" + Utilities.ConvertSqlString(maKyThuat.Trim()) + "',N'" +
                           Utilities.ConvertSqlString(tenKyThuat.Trim()) + "', " +
                           (string.IsNullOrWhiteSpace(thuTuIn.Trim()) ? "1" : thuTuIn.Trim());
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Mã kỹ thuật chụp đã có. \nVui lòng chọn mã khác!");
            }
        }
        //Update dùng Binding context
        //Delete
        public void Delete_KyThuat(string maKyThuat)
        {
            if (
                !DataProvider.CheckExisted("select top 1  * from KetQua_CLS_XQuang where MaKyThuatChup = '" +
                                               maKyThuat.Trim() + "'"))
            {
                var strSql = "delete from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup where MaKyThuatChup = '" + maKyThuat.Trim() + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                CustomMessageBox.MSG_Information_OK("Xóa hoàn tất!");
            }
            else
            {
                CustomMessageBox.MSG_Error_OK("KHÔNG THỂ XÓA !\nKỹ thuật chụp đang được sử dụng.");
            }
        }
        //Vùng chụp
        //Insert
        public void Insert_VungChup(string maKyThuat, string maVungChup, string tenVungChup, string thuTuIn,
            string phim, string soLuongPhim, string thuoc, string soLuongThuoc, string ketLuanMacDinh,
            string deNghiMacDinh, string giaChuan)
        {
            if (
                !DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where MaVungChup ='" +
                                               maVungChup.Trim() + "'"))
            {
                var strSql =
                    "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup (MaKyThuatChup,MaVungChup,TenVungChup, ThuTuIn, Phim, SoLuongPhim, Thuoc, SoLuongThuoc, KetLuanMacDinh, DeNghiMacDinh, GiaChuan )\n";
                strSql += " select  '" + Utilities.ConvertSqlString(maKyThuat.Trim()) + "','" +
                           Utilities.ConvertSqlString(maVungChup.Trim()) + "',N'" +
                           Utilities.ConvertSqlString(tenVungChup) + "', " + (string.IsNullOrWhiteSpace(thuTuIn) ? "1" : thuTuIn);
                strSql += "\n,'" + Utilities.ConvertSqlString(phim) + "'," + (string.IsNullOrWhiteSpace(soLuongPhim) ? "1" : soLuongPhim) +
                           ", '" + Utilities.ConvertSqlString(thuoc) + "', " +
                           (string.IsNullOrWhiteSpace(soLuongThuoc) ? "1" : soLuongThuoc) + ", N'" +
                           Utilities.ConvertSqlString(ketLuanMacDinh) + "', N'" +
                           Utilities.ConvertSqlString(deNghiMacDinh) + "', " + (string.IsNullOrWhiteSpace(giaChuan) ? "0" : giaChuan);
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Mã vùng chụp đã có. \nVui lòng chọn mã khác!");
            }
        }

        //Update 
        public void Update_VungChup(string maKyThuat, string maVungChup, string tenVungChup, string thuTuIn,
            string phim, string soLuongPhim, string thuoc, string soLuongThuoc, string ketLuanMacDinh,
            string deNghiMacDinh, string giaChuan)
        {
            if (
                !DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where MaVungChup ='" +
                                               maVungChup.Trim() + "'") == false)
            {
                var strSql = "Update {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup set \n";
                strSql += "  MaKyThuatChup='" + Utilities.ConvertSqlString(maKyThuat.Trim()) + "',TenVungChup=N'" +
                           Utilities.ConvertSqlString(tenVungChup) + "',ThuTuIn= " +
                           (string.IsNullOrWhiteSpace(thuTuIn) ? "1" : thuTuIn);
                strSql += "\n,Phim=N'" + Utilities.ConvertSqlString(phim) + "',SoLuongPhim=" +
                           (string.IsNullOrWhiteSpace(soLuongPhim) ? "1" : soLuongPhim) + ", Thuoc='" + Utilities.ConvertSqlString(thuoc) +
                           "',SoLuongThuoc= " + (string.IsNullOrWhiteSpace(soLuongThuoc) ? "1" : soLuongThuoc) + ",KetLuanMacDinh= N'" +
                           Utilities.ConvertSqlString(ketLuanMacDinh) + "',DeNghiMacDinh= N'" +
                           Utilities.ConvertSqlString(deNghiMacDinh) + "',GiaChuan= " +
                           (giaChuan == "" ? "0" : giaChuan);
                strSql += " where MaVungChup='" + Utilities.ConvertSqlString(maVungChup.Trim()) + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Mã vùng chụp chưa tồn tại !");
            }
        }
        //Delete
        public void Delete_VungChup(string maKyThuat, string maVungChup)
        {
            if (
                !DataProvider.CheckExisted("select top 1  * from KetQua_CLS_XQuang where MaKyThuatChup = '" +
                                               maKyThuat + "' and MaVungChup ='" + maVungChup + "'"))
            {
                var strSql = "delete from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where MaKyThuatChup = '" + maKyThuat +
                                 "' and MaVungChup ='" + maVungChup + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                CustomMessageBox.MSG_Information_OK("Xóa hoàn tất!");
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("KHÔNG THỂ XÓA !\nVùng chụp đang được sử dụng.");
            }
        }
        //Vùng chụp - Kết quả
        public bool Update_MauKetQua(string maVungChup, string rtfMauKetQua)
        {
            string strSql = string.Empty;
            strSql = "update {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup set MauKetQua =" +
                                (string.IsNullOrWhiteSpace(rtfMauKetQua)
                                    ? "NULL"
                                    : "N'" + Utilities.ConvertSqlString(rtfMauKetQua) + "'");
            strSql += "\nwhere MaVungChup = '" + maVungChup.Trim() + "'";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1;

        }
        //May XQuang
        public void Insert_MayXQuang(string tenMay)
        {
            var strSql = "insert into DM_MayXQuang (TenMay) values(N'" + tenMay + "')";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Get_DMMayXQuang(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from DM_MayXQuang where 1=1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by TenMay";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DMMayXQuang(CustomComboBox cbo)
        {
            var strSql = " select * from DM_MayXQuang ";
            strSql += " order by TenMay";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "IDMay", "TenMay", "IDMay,TenMay", "15,150");
        }
        #endregion
        //================================|||=====================================
        #region Danh mục dich vụ khác
        public void Get_DM_DICHVUKHAC(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where 1 = 1";
            if (filter != "")
            {
                strSql += filter;
            }
            strSql += " order by madvkhac,tendvkhac";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_DICHVUKHAC(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where 0=0 ";
            strSql += filter;
            strSql += " order by madvkhac,tendvkhac";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public void Get_DM_DICHVUKHAC(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by madvkhac,tendvkhac";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            cbo.ColumnNames = "madvkhac,tendvkhac";
            cbo.ColumnWidths = "50,150";
            ControlExtension.BindDataToCobobox(dt, ref cbo, "madvkhac", "madvkhac");
        }

        public DataTable Get_DM_DICHVUKHAC(CustomComboBox cbo, string filter, string maDoiTuongDv)
        {
            var strSql = "select A.*, isnull(dv.GiaRieng, 0) as  GiaRieng, n.tennhomcls from (";
            strSql += "\n select * from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += "\n) as A";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia dv on (dv.MaDichVu = A.MaDVKhac and dv.MaDichVu = '" +
                      maDoiTuongDv.Trim() + "')";
            strSql += "\n left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac n on n.manhomcls = a.manhomcls";
            strSql += " order by A.madvkhac,A.tendvkhac";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                if (string.IsNullOrWhiteSpace(maDoiTuongDv))
                {
                    ControlExtension.BindDataToCobobox(dt, ref cbo, "madvkhac", "madvkhac", "madvkhac,tendvkhac",
                        "50,150");
                }
                else
                    ControlExtension.BindDataToCobobox(dt, ref cbo, "madvkhac", "madvkhac",
                        "madvkhac,tendvkhac,GiaRieng",
                        "50,150,50");
            }
            return dt;
        }
        // Insert 
        public bool Insert_DM_DichVuKhac(string denghi, string ghichu, string giachuan, string madvkhac,
            string manhomcls, string mauketqua
            , string tendvkhac, string thutuin)
        {
            var strSql = "insert into  {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac (";
            strSql += Environment.NewLine + "denghi";
            strSql += Environment.NewLine + "," + "ghichu";
            strSql += Environment.NewLine + "," + "giachuan";
            strSql += Environment.NewLine + "," + "madvkhac";
            strSql += Environment.NewLine + "," + "manhomcls";
            strSql += Environment.NewLine + "," + "mauketqua";
            strSql += Environment.NewLine + "," + "tendvkhac";
            strSql += Environment.NewLine + "," + "thutuin";
            strSql += Environment.NewLine + ")";
            strSql += Environment.NewLine + "select ";
            strSql += Environment.NewLine +
                      (string.IsNullOrWhiteSpace(denghi) ? "NULL" : "N'" + Utilities.ConvertSqlString(denghi) + "'");
            strSql += Environment.NewLine + "," +
                      (string.IsNullOrWhiteSpace(ghichu) ? "NULL" : "N'" + Utilities.ConvertSqlString(ghichu) + "'");
            strSql += Environment.NewLine + "," + (string.IsNullOrWhiteSpace(giachuan) ? "0" : giachuan);
            strSql += Environment.NewLine + "," + (string.IsNullOrWhiteSpace(madvkhac) ? "''" : "'" + madvkhac + "'");
            strSql += Environment.NewLine + "," +
                      (string.IsNullOrWhiteSpace(manhomcls) ? "NULL" : "'" + manhomcls + "'");
            strSql += Environment.NewLine + "," +
                      (string.IsNullOrWhiteSpace(mauketqua) ? "NULL" : "N'" + Utilities.ConvertSqlString(mauketqua) + "'");
            strSql += Environment.NewLine + "," +
                      (string.IsNullOrWhiteSpace(tendvkhac) ? "NULL" : "N'" + Utilities.ConvertSqlString(tendvkhac) + "'");
            strSql += Environment.NewLine + "," + (string.IsNullOrWhiteSpace(thutuin) ? "0" : thutuin);
            if (
                !DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where 1 = 1  and madvkhac =  " +
                                               (string.IsNullOrWhiteSpace(madvkhac) ? "''" : "'" + madvkhac + "'")))
            {
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }

            CustomMessageBox.MSG_Waring_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
            return false;
        }

        // Update 
        public bool Update_DM_DICHVUKHAC(string denghi, string ghichu, string giachuan, string madvkhac,
            string manhomcls, string mauketqua
            , string nguoisua, string tendvkhac, string thutuin)
        {
            var strSql = "Update {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac set " + Environment.NewLine;
            strSql += Environment.NewLine + "denghi = " +
                      (string.IsNullOrWhiteSpace(denghi) ? "NULL" : "N'" + Utilities.ConvertSqlString(denghi) + "'");
            strSql += Environment.NewLine + ",ghichu = " +
                      (string.IsNullOrWhiteSpace(ghichu) ? "NULL" : "N'" + Utilities.ConvertSqlString(ghichu) + "'");
            strSql += Environment.NewLine + ",giachuan = " + (string.IsNullOrWhiteSpace(giachuan) ? "0" : giachuan);
            strSql += Environment.NewLine + ",manhomcls = " +
                      (string.IsNullOrWhiteSpace(manhomcls) ? "NULL" : "'" + manhomcls + "'");
            strSql += Environment.NewLine + ",mauketqua = " +
                      (string.IsNullOrWhiteSpace(mauketqua) ? "NULL" : "N'" + Utilities.ConvertSqlString(mauketqua) + "'");
            strSql += Environment.NewLine + ",nguoisua = " +
                      (string.IsNullOrWhiteSpace(nguoisua) ? "NULL" : "'" + nguoisua + "'");
            strSql += Environment.NewLine + ",tendvkhac = " +
                      (string.IsNullOrWhiteSpace(tendvkhac) ? "NULL" : "N'" + Utilities.ConvertSqlString(tendvkhac) + "'");
            strSql += Environment.NewLine + ",tgsua = getdate()";
            strSql += Environment.NewLine + ",thutuin = " + (string.IsNullOrWhiteSpace(thutuin) ? "0" : thutuin);
            strSql += Environment.NewLine + " where 1=1 ";
            strSql += Environment.NewLine + " and madvkhac =  " +
                      (string.IsNullOrWhiteSpace(madvkhac) ? "''" : "'" + madvkhac + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
        }

        // Delete 
        public bool Delete_DM_DICHVUKHAC(string madvkhac)
        {
            var strSql = "Delete from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac" + Environment.NewLine;
            strSql += Environment.NewLine + " where 1=1 ";
            strSql += Environment.NewLine + " and madvkhac =  " +
                      (string.IsNullOrWhiteSpace(madvkhac) ? "''" : "'" + madvkhac + "'");
            return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
        }

        // BẢNG {{TPH_Standard}}_Dictionary.dbo.
        // Getdata 
        public void Get_DM_NHOMCLS_DVKHAC(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by manhomcls,tennhomcls";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Get_DM_NHOMCLS_DVKHAC(SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac where 0=0 ";
            strSql += filter;
            strSql += " order by manhomcls,tennhomcls";
            DataProvider.SelInsUpdDelODBC(strSql, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public DataTable Get_DM_NHOMCLS_DVKHAC(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by manhomcls,tennhomcls";
            dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                cbo.ColumnNames = "manhomcls,tennhomcls";
                cbo.ColumnWidths = "50,150";
                ControlExtension.BindDataToCobobox(dt, ref cbo, "manhomcls", "manhomcls");
            }
            return dt;
        }

        public DataTable Get_DM_NHOMCLS_DVKHAC(CustomComboBox cbo, string filter)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac where 1 = 1";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                strSql += filter;
            }
            strSql += " order by manhomcls,tennhomcls";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (cbo != null)
            {
                cbo.ColumnNames = "manhomcls,tennhomcls";
                cbo.ColumnWidths = "50,150";
                ControlExtension.BindDataToCobobox(dt, ref cbo, "manhomcls", "manhomcls");
            }
            return dt;
        }

        // Insert 
        public bool Insert_DM_NhomCLS_DVKhac(string manhomcls, string tennhomcls, string mauKq)
        {
            var strSql = "insert into  {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac (";
            strSql += Environment.NewLine + "manhomcls";
            strSql += Environment.NewLine + "," + "tennhomcls";
            strSql += Environment.NewLine + "," + "thoigiannhap";
            strSql += Environment.NewLine + "," + "MauKQ";
            strSql += Environment.NewLine + ")";
            strSql += Environment.NewLine + "select ";
            strSql += Environment.NewLine + (string.IsNullOrWhiteSpace(manhomcls) ? "''" : "'" + manhomcls + "'");
            strSql += Environment.NewLine + "," +
                      (string.IsNullOrWhiteSpace(tennhomcls) ? "N''" : "N'" + tennhomcls + "'");
            strSql += Environment.NewLine + ",getdate()";
            strSql += Environment.NewLine + "," + (mauKq == "" ? "Null" : "'" + mauKq + "'");
            if (
                !DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac where 1 = 1  and manhomcls =  " +
                                               (manhomcls == "" ? "''" : "'" + manhomcls + "'")))
            {
                return (bool)DataProvider.ExecuteScalar(CommandType.Text, strSql);
            }
            CustomMessageBox.MSG_Waring_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
            return false;
        }


        public DataTable Data_DS_MauKQ()
        {
            var strSql = "select * from DM_DVKhac_MauKQ";
            return DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public void GET_DS_MAU_KQ(CustomComboBox cbo, TextBox txt)
        {
            if (txt != null)
            {
                cbo.LinkedColumnIndex1 = 1;
                cbo.LinkedTextBox1 = txt;
            }

            ControlExtension.BindDataToCobobox(Data_DS_MauKQ(), ref cbo, "MauKQ", "TenMau", "MauKQ,TenMau", "50,150");
        }

        public void GET_DS_MAU_KQ(DataGridViewComboBoxColumn cbo)
        {
            cbo.DataSource = Data_DS_MauKQ();
            cbo.ValueMember = "MauKQ";
            cbo.DisplayMember = "TenMau";

        }
        #endregion
        //================================|||=====================================
        #region dm_xetngnghiem_phuongphap
        //================================|||=====================================
        public int Insert_dm_xetngnghiem_phuongphap(DM_XETNGNGHIEM_PHUONGPHAP objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetngnghiem_phuongphap", para);
        }
        public int Update_dm_xetngnghiem_phuongphap(DM_XETNGNGHIEM_PHUONGPHAP objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", objInfo.Autoid),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@IDMayXN", objInfo.Idmayxn),
                        WorkingServices.GetParaFromOject("@QuiTrinh", objInfo.Quitrinh),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@NguoiSua", objInfo.Nguoisua),
                        WorkingServices.GetParaFromOject("@datchungnhan", objInfo.Datchungnhan),
                        WorkingServices.GetParaFromOject("@NoiKiemTraChatLuong", objInfo.Noikiemtrachatluong)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetngnghiem_phuongphap", para);
        }
        public int Delete_dm_xetngnghiem_phuongphap(int autoid)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", autoid)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetngnghiem_phuongphap", para);
        }
        public DataTable Data_dm_xetngnghiem_phuongphap(int? autoid, string maxn, int? idMayXn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@AutoID", autoid),
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                        WorkingServices.GetParaFromOject("@idMayXn", idMayXn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetngnghiem_phuongphap", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGNGHIEM_PHUONGPHAP Get_Info_dm_xetngnghiem_phuongphap(DataRow drInfo)
        {
            return (DM_XETNGNGHIEM_PHUONGPHAP)WorkingServices.Get_InfoForObject(new DM_XETNGNGHIEM_PHUONGPHAP(), drInfo);
        }
        public DM_XETNGNGHIEM_PHUONGPHAP Get_Info_dm_xetngnghiem_phuongphap(int autoid)
        {
            DataTable dt = Data_dm_xetngnghiem_phuongphap(autoid, string.Empty, null);
            DM_XETNGNGHIEM_PHUONGPHAP obj = new DM_XETNGNGHIEM_PHUONGPHAP();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetngnghiem_phuongphap(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetngnghiem_phuongphap(int autoid)
        {
            return Data_dm_xetngnghiem_phuongphap(autoid, string.Empty, null).Rows.Count > 0;
        }

        #endregion
        #region DM_XetNghiem_canhbao
        public int Insert_dm_xetnghiem_canhbao(string maxn, string idLocaichucNang)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_canhbao (MaXN, IDLoaiDichVu)");
            sb.AppendFormat("\nvalues ('{0}',{1})", maxn, idLocaichucNang);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int Update_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_canhbao set MaXN, IDLoaiDichVu");
            sb.AppendFormat("\nMaXN = '{0}' ", maxn);
            sb.AppendFormat("\n,IDLoaiDichVu = {0}", idLocaichucNang);
            sb.AppendFormat("\nWhere ID = {0}", id);

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        private string SQLSelect_Data_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_canhbao where 1=1");
            if (id > 0)
                sb.AppendFormat("\n and ID = {0}", id);
            if (!string.IsNullOrEmpty(maxn))
                sb.AppendFormat("\n and MaXN = '{0}'", maxn);
            if (!string.IsNullOrEmpty(idLocaichucNang))
                sb.AppendFormat("\n and IDLoaiDichVu = {0}", idLocaichucNang);
            return sb.ToString();
        }
        public DataTable Data_dm_xetnghiem_canhbao(int id, string maxn, string idLocaichucNang)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_canhbao(id, maxn, idLocaichucNang)).Tables[0];
            return dtData;
        }

        //================================|||=====================================
        #endregion
        //================================|||=====================================
        #region Quản lý đối tượng
        //Nhóm đối tượng Dich vụ
        public DataTable Get_NhomDoiTuongDichVu(bool checkUsing)
        {
            var data = DataProvider.ExecuteDataset(CommandType.Text, string.Format("select * from {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_nhom {0} order by SapXep asc ", (checkUsing ? " where MaNhomDoiTuong in (select distinct nhomdoituong from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu)" : ""))).Tables[0];
            if (!checkUsing)
            {
                var dr = data.NewRow();
                dr["MaNhomDoiTuong"] = string.Empty;
                dr["TenNhomDoiTuong"] = "---Chọn nhóm---";
                data.Rows.Add(dr);
            }
            return data;
        }
        //Đối tượng dịch vụ
        public void Get_DoiTuongDichVu(DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where MaDoiTuongDichVu = '" + filter + "'";
            }
            sqlQuery += " order by SapXepDoiTuong, MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DoiTuongDichVu(ref SqlDataAdapter da, DataGridView dtg, BindingNavigator bv, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where MaDoiTuongDichVu = '" + filter + "'";
            }
            sqlQuery += " order by SapXepDoiTuong, MaDoiTuongDichVu";

            DataProvider.SelInsUpdDelODBC(sqlQuery, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }
        public void Get_DoiTuongDichVu(ComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where MaDoiTuongDichVu = '" + filter + "'";
            }
            sqlQuery += " order by SapXepDoiTuong, MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaDoiTuongDichVu", "TenDoiTuongDichVu");
        }
        public DataTable Get_DoiTuongDichVu(string filter)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where MaDoiTuongDichVu = '" + filter + "'";
            }
            sqlQuery += " order by SapXepDoiTuong, MaDoiTuongDichVu";
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }
        public void Get_DoiTuongDichVu(CustomComboBox cbo, string filter, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where MaDoiTuongDichVu = '" + filter + "'";
            }
            sqlQuery += " order by SapXepDoiTuong, MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaDoiTuongDichVu", "MaDoiTuongDichVu", "MaDoiTuongDichVu,TenDoiTuongDichVu", "100,250");
        }
        public void Get_DoiTuongDichVu(CustomComboBox cbo, TextBox txt)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  order by SapXepDoiTuong, MaDoiTuongDichVu";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            if (txt != null)
            {
                cbo.LinkedColumnIndex1 = 1;
                cbo.LinkedTextBox1 = txt;
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaDoiTuongDichVu", "MaDoiTuongDichVu", "MaDoiTuongDichVu,TenDoiTuongDichVu", "100,250");
            }
            else
            {
                ControlExtension.BindDataToCobobox(dt, ref cbo, "MaDoiTuongDichVu", "MaDoiTuongDichVu", "MaDoiTuongDichVu,TenDoiTuongDichVu", "100,250");
            }
        }
        public string Get_Default_DoiTuongDV()
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  where ChonMacDinh = 1 order by SapXepDoiTuong, MaDoiTuongDichVu";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if ((bool)dr["ChonMacDinh"])
                {
                    return dr["MaDoiTuongDichVu"].ToString().Trim();
                }
            }

            return string.Empty;
        }
        public void Get_DichVu_XN(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenXN, x.MaNhomCLS,x.GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem x on c.MaDichVu=x.MaXN";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by ThuTuIn,c.MaDichVu,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_SieuAm(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenMauSieuAm, x.GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm x on c.MaDichVu=cast(x.MaSoMau as varchar(15))";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.ClsSieuAm.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by TenMauSieuAm,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_XQuang(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenVungChup, x.GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup x on c.MaDichVu=x.MaVungChup";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.ClsXQuang.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by TenVungChup,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_NoiSoi(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenMauNoiSoi, x.GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi x on c.MaDichVu= cast(x.MaSoMauNoiSoi as varchar(15))";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.ClsNoiSoi.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by TenMauNoiSoi,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_KhamBenh(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenYeuCau, x.GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu x on c.MaDichVu=x.MaYeuCau";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.KhamBenh.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by TenYeuCau,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_Khac(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenDVKhac, x.GiaChuan, x.MaNhomCLS from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac x on c.MaDichVu=x.MaDVKhac";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.DvKhac.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by TenDVKhac,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_Thuoc(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenThuoc, x.Gia as GiaChuan, g.MaNhomThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc x on c.MaDichVu=x.MaThuoc inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on x.MaGocThuoc = g.MaGocThuoc";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }

            sqlQuery += " order by x.TenThuoc,c.MaDichVu,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Get_DichVu_ViSinh(DataGridView dtg, BindingNavigator bv, string maDoiTuongDichVu, string maDichVu, ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery =
                " select C.*, x.TenYeuCau, x.GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia c inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_yeucauvisinh x on c.MaDichVu = x.MaYeuCau";
            sqlQuery += "\n where c.MaLoaiDichVu = '" + ServiceType.ClsXNViSinh.ToString() + "'";
            if (!string.IsNullOrWhiteSpace(maDoiTuongDichVu))
            {
                sqlQuery += " and c.MaDoiTuongDichVu = '" + maDoiTuongDichVu + "'";
            }
            if (!string.IsNullOrWhiteSpace(maDichVu))
            {
                sqlQuery += " and c.MaDichVu = '" + maDichVu + "'";
            }
            sqlQuery += " order by TenYeuCau,c.MaDoiTuongDichVu";
            dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        //Thêm dịch vụ vào giá
        public void Add_DichVu_ChiTiet_XN(string maDichVu, string maXetNghiem)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDichVu +
                              "', MaXN , '" + ServiceType.ClsXetNghiem.ToString() + "'  as MaLoaiDichVu, GiaChuan from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem where MaXN not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDichVu + "'  and MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "' )" + (string.IsNullOrWhiteSpace(maXetNghiem) ? string.Empty : " and MAXN ='" + maXetNghiem + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);

        }
        public int Copy_DichVu_ChiTiet_XN(string tuMaDoiTuong, string denMaDoiTuong)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                          "select '" + denMaDoiTuong +
                          "', MaDichVu , '" + ServiceType.ClsXetNghiem.ToString() + "'  as MaLoaiDichVu, GiaRieng" +
                          "\n from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia" +
                          "\n where MaDoiTuongDichVu='" + tuMaDoiTuong + "'  and MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "' ";
            sqlQuery += "\n and MaDichVu not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                          denMaDoiTuong + "'  and MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "' )";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public int Copy_GiaDichVu_ChiTiet_XN(string tuMaDoiTuong, string denMaDoiTuong)
        {
            if (Copy_DichVu_ChiTiet_XN(tuMaDoiTuong, denMaDoiTuong) > -1)
            {
                return Copy_DoiTuongDichVu_Gia(tuMaDoiTuong, denMaDoiTuong, ServiceType.ClsXetNghiem);
            }
            else
                return -1;
        }
        //Thêm dịch vụ vi sinh vào giá
        public void Add_DichVu_ChiTiet_ViSinh(string maDichVu, string maXetNghiem)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDichVu +
                              "', MaYeuCau , '" + ServiceType.ClsXNViSinh.ToString() + "'  as MaLoaiDichVu, GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_yeucauvisinh where MaYeuCau not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDichVu + "'  and MaLoaiDichVu = '" + ServiceType.ClsXNViSinh.ToString() + "' )" + (string.IsNullOrWhiteSpace(maXetNghiem) ? string.Empty : " and MaYeuCau ='" + maXetNghiem + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);

        }
        public int Copy_DichVu_ChiTiet_ViSinh(string tuMaDoiTuong, string denMaDoiTuong)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                          "select '" + denMaDoiTuong +
                          "', MaDichVu , '" + ServiceType.ClsXNViSinh.ToString() + "'  as MaLoaiDichVu, GiaRieng" +
                          "\n from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia" +
                          "\n where MaDoiTuongDichVu='" + denMaDoiTuong + "'  and MaLoaiDichVu = '" + ServiceType.ClsXNViSinh.ToString() + "' ";
            sqlQuery += "\n and MaDichVu not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                          denMaDoiTuong + "'  and MaLoaiDichVu = '" + ServiceType.ClsXNViSinh.ToString() + "' )";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public int Copy_GiaDichVu_ChiTiet_ViSinh(string tuMaDoiTuong, string denMaDoiTuong)
        {
            if (Copy_DichVu_ChiTiet_XN(tuMaDoiTuong, denMaDoiTuong) > -1)
            {
                return Copy_DoiTuongDichVu_Gia(tuMaDoiTuong, denMaDoiTuong, ServiceType.ClsXNViSinh);
            }
            else
                return -1;
        }
        public int Copy_DoiTuongDichVu_Gia(string tuMaDoiTuong, string denMaDoiTuong, ServiceType svrType)
        {
            var sqlQuery = "declare @TuMaDoiTuongDichVu varchar(15)";
            sqlQuery += "\n declare @DenMaDoiTuongDichVu varchar(15)";
            sqlQuery += "\n declare @MaLoaiDichVu varchar(50)";
            sqlQuery += string.Format("\n set @TuMaDoiTuongDichVu = '{0}'", tuMaDoiTuong);
            sqlQuery += string.Format("\n set @DenMaDoiTuongDichVu =  '{0}'", denMaDoiTuong);
            sqlQuery += string.Format("\n set @MaLoaiDichVu =  '{0}'", svrType.ToString());
            sqlQuery += "\n update g1 set g1.GiaRieng = g2.GiaRieng";
            sqlQuery += "\n from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia g1 ";
            sqlQuery += "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia g2";
            sqlQuery += "\n on (g1.MaDichVu = g2.MaDichVu ";
            sqlQuery += "\n and g1.MaLoaiDichVu = g2.MaLoaiDichVu";
            sqlQuery += "\n and g2.MaDoiTuongDichVu = @TuMaDoiTuongDichVu)";
            sqlQuery += "\n where";
            sqlQuery += "\n g1.MaDoiTuongDichVu = @DenMaDoiTuongDichVu";
            sqlQuery += "\n and ";
            sqlQuery += "\n g1.MaLoaiDichVu = @MaLoaiDichVu";
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);

        }
        public void Add_DichVu_ChiTiet_SieuAm(string maDoiTuongDichVu, string maDichVu)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDoiTuongDichVu +
                              "', MaSoMau , '" + ServiceType.ClsSieuAm.ToString() + "'  as MaLoaiDichVu, GiaChuan from {{TPH_Standard}}_Dictionary.dbo.DM_MauSieuAm where cast(MaSoMau as varchar(15)) not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDoiTuongDichVu + "'  and MaLoaiDichVu = '" + ServiceType.ClsSieuAm.ToString() + "' )" + (string.IsNullOrWhiteSpace(maDichVu) ? string.Empty : " and MaSoMau =" + maDichVu);
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Add_DichVu_ChiTiet_NoiSoi(string maDoiTuongDichVu, string maDichVu)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDoiTuongDichVu +
                              "', MaSoMauNoiSoi , '" + ServiceType.ClsNoiSoi.ToString() + "'  as MaLoaiDichVu , GiaChuan from  {{TPH_Standard}}_Dictionary.dbo.DM_MauNoiSoi where cast(MaSoMauNoiSoi as varchar(15)) not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDoiTuongDichVu + "' and MaLoaiDichVu = '" + ServiceType.ClsNoiSoi.ToString() + "' )" + (string.IsNullOrWhiteSpace(maDichVu) ? string.Empty : " and MaSoMauNoiSoi =" + maDichVu);
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Add_DichVu_ChiTiet_XQuang(string maDoiTuongDichVu, string maDichVu)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDoiTuongDichVu +
                              "', MaVungChup, '" + ServiceType.ClsXQuang.ToString() + "'  as MaLoaiDichVu , GiaChuan from {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup where cast(MaVungChup as varchar(15))  not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDoiTuongDichVu + "' and MaLoaiDichVu = '" + ServiceType.ClsXQuang.ToString() + "' )" + (string.IsNullOrWhiteSpace(maDichVu) ? string.Empty : " and MaDichVu ='" + maDichVu + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Add_DichVu_ChiTiet_KhamBenh(string maDoiTuongDichVu, string maDichVu)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDoiTuongDichVu +
                              "', MaYeuCau, '" + ServiceType.KhamBenh.ToString() + "'  as MaLoaiDichVu, GiaChuan from {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_dichvu where cast(MaYeuCau as varchar(15)) not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDoiTuongDichVu + "' and MaLoaiDichVu = '" + ServiceType.KhamBenh.ToString() + "' )" + (string.IsNullOrWhiteSpace(maDichVu) ? string.Empty : " and MaYeuCau ='" + maDichVu + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Add_DichVu_ChiTiet_DVKhac(string maDoiTuongDichVu, string maDichVu)
        {
            var sqlQuery = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                              "select '" + maDoiTuongDichVu +
                              "', MaDVKhac, '" + ServiceType.DvKhac.ToString() + "'  as MaLoaiDichVu , GiaChuan from {{TPH_Standard}}_Dictionary.dbo.dm_dichvukhac where MaDVKhac cast(as varchar(15)) not in (select MaDichVu from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDoiTuongDichVu + "' and MaLoaiDichVu = '" + ServiceType.DvKhac.ToString() + "' )" + (string.IsNullOrWhiteSpace(maDichVu) ? string.Empty : " and MaDVKhac ='" + maDichVu + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);

        }
        public void Add_DichVu_ChiTiet_Thuoc(string maDoiTuongDichVu, string maDichVu)
        {
            var sqlQuery =
                "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia ([MaDoiTuongDichVu],[MaDichVu],[MaLoaiDichVu],[GiaRieng])\n" +
                "select '" + maDoiTuongDichVu +
                "', MaThuoc , '" + ServiceType.Duoc.ToString() + "'" + " as MaLoaiDichVu, Gia";
            sqlQuery += "\nfrom {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc where MaThuoc not in (select MaThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" +
                              maDoiTuongDichVu + "' and MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'" + ")" + (string.IsNullOrWhiteSpace(maDichVu) ? string.Empty : " and MaThuoc ='" + maDichVu + "'");
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);

        }
        public void Delete_DichVu(string maDichVu)
        {
            if (
                !DataProvider.CheckExisted("select top 1 * from BenhNhan_TiepNhan where DoiTuongDichVu = '" +
                                               maDichVu + "'"))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bạn có chắc xoá DV: " + maDichVu))
                {
                    var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu where MaDoiTuongDichVu='" + maDichVu + "'";
                    DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
                }
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Dịch vụ đã sử dụng. \nKhông thể xoá !");
            }
        }
        public void Delete_ChiTiet_XN(string maDichVu, string maXetNghiem)
        {
            if (
                CustomMessageBox.MSG_Question_YesNo_GetNo(("Bạn có chắc xoá XN : " + maXetNghiem + " ra khỏi DV: " +
                                                            maDichVu)))
                return;
            else
            {
                var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" +
                               maXetNghiem +
                               "' and MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "' ";
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }

        }
        public void Delete_ChiTiet_SieuAm(string maDichVu, string maSoMau)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn có chắc xoá mẫu siêu âm : " + maSoMau + " ra khỏi DV: " + maDichVu))
                return;
            var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maSoMau +
                              "' and MaLoaiDichVu = '" + ServiceType.ClsSieuAm.ToString() + "' ";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Delete_ChiTiet_NoiSoi(string maDichVu, string maSoMau)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn có chắc xoá mẫu nội soi : " + maSoMau + " ra khỏi DV: " + maDichVu))
                return;
            var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" +
                           maSoMau + "' and MaLoaiDichVu = '" + ServiceType.ClsNoiSoi.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Delete_ChiTiet_XQuang(string maDichVu, string maVungChup)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn có chắc xoá vùng chụp : " + maVungChup + " ra khỏi DV: " + maDichVu))
                return;
            var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" +
                              maVungChup + "'  and MaLoaiDichVu = '" + ServiceType.ClsXQuang.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Delete_ChiTiet_KhamBenh(string maDichVu, string maYeuCau)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn có chắc xoá dịch vụ khám bệnh : " + maYeuCau + " ra khỏi DV: " + maDichVu))
                return;
            var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maYeuCau +
                              "' and MaLoaiDichVu = '" + ServiceType.KhamBenh.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Delete_ChiTiet_DVKhac(string maDichVu, string maDvKhac)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn có chắc xoá dịch vụ : " + maDvKhac + " ra khỏi DV: " + maDichVu))
                return;
            var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maDvKhac +
                              "' and MaLoaiDichVu = '" + ServiceType.DvKhac.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Delete_ChiTiet_Thuoc(string maDichVu, string maThuoc)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetNo("Bạn có chắc xoá thuốc : " + maThuoc + " ra khỏi DV: " + maDichVu))
                return;
            var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maThuoc + "' and MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Delete_ChiTiet_ViSinh(string maDichVu, string maXetNghiem)
        {
            if (
                CustomMessageBox.MSG_Question_YesNo_GetNo(("Bạn có chắc xoá XN : " + maXetNghiem + " ra khỏi DV: " +
                                                            maDichVu)))
                return;
            else
            {
                var sqlQuery = " delete {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia where MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" +
                               maXetNghiem +
                               "' and MaLoaiDichVu = '" + ServiceType.ClsXNViSinh.ToString() + "' ";
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }

        }
        public void Update_ChiTiet_XN_Gia(string maDichVu, string maXetNghiem, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) + " where  MaDoiTuongDichVu='" +
                              maDichVu + "' and MaDichVu='" + maXetNghiem + "' and MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_XN_Gia(string maDichVu, string maXetNghiem, int phanTram)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maXetNghiem + "' and MaLoaiDichVu = '" + ServiceType.ClsXetNghiem.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_SieuAm_Gia(string maDichVu, string maSoMau, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) + " where  MaDoiTuongDichVu='" +
                              maDichVu + "' and MaDichVu= '" + maSoMau + "' and MaLoaiDichVu = '" + ServiceType.ClsSieuAm.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_SieuAm_Gia(string maDichVu, string maSoMau, int phanTram)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu= '" + maSoMau + "' and MaLoaiDichVu = '" + ServiceType.ClsSieuAm.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_NoiSoi_Gia(string maDichVu, string maSoMau, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) + " where  MaDoiTuongDichVu='" +
                              maDichVu + "' and MaDichVu= '" + maSoMau + "' and MaLoaiDichVu = '" + ServiceType.ClsNoiSoi.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_NoiSoi_Gia(string maDichVu, string maSoMau, int phanTram)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu= '" + maSoMau + "' and MaLoaiDichVu = '" + ServiceType.ClsNoiSoi.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_XQuang_Gia(string maDichVu, string maVungChup, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) + " where  MaDoiTuongDichVu='" +
                              maDichVu + "' and MaDichVu='" + maVungChup + "' and MaLoaiDichVu = '" + ServiceType.ClsXQuang.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_XQuang_Gia(string maDichVu, string maVungChup, int phanTram)
        {
            var sqlQuery = "update DichVu_XQuang set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maVungChup + "' and MaLoaiDichVu = '" + ServiceType.ClsXQuang.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_KhamBenh_Gia(string maDichVu, string maYeuCau, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) +
                              " where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maYeuCau + "' and MaLoaiDichVu = '" + ServiceType.KhamBenh.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_KhamBenh_Gia(string maDichVu, string maYeuCau, int phanTram)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maYeuCau + "' and MaLoaiDichVu = '" + ServiceType.KhamBenh.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_DVKhac_Gia(string maDichVu, string maDvKhac, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) + " where  MaDoiTuongDichVu='" +
                              maDichVu + "' and MaDichVu='" + maDvKhac + "' and MaLoaiDichVu = '" + ServiceType.DvKhac.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_DVKhac_Gia(string maDichVu, string maDvKhac, int phanTram)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maDvKhac + "' and MaLoaiDichVu = '" + ServiceType.DvKhac.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_Thuoc_Gia(string maDichVu, string maThuoc, string gia)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = " + (string.IsNullOrWhiteSpace(gia) ? "0" : gia) + " where  MaDoiTuongDichVu='" +
                              maDichVu + "' and MaDichVu='" + maThuoc + "' and MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        public void Update_ChiTiet_Thuoc_Gia(string maDichVu, string maThuoc, int phanTram)
        {
            var sqlQuery = "update {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu_Gia set GiaRieng = (GiaRieng * " + (phanTram.ToString()) +
                              ")/100  where  MaDoiTuongDichVu='" + maDichVu + "' and MaDichVu='" + maThuoc + "' and MaLoaiDichVu = '" + ServiceType.Duoc.ToString() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }
        #endregion
        //================================|||=====================================
        #region Quản lý chân đoán
        //Chan doan
        public void Add_ChanDoan(string maChanDoan, string chanDoan)
        {
            if (!DataProvider.CheckExisted("select * from {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan where MaChanDoan='" + maChanDoan + "'"))
            {
                var sqlQuery = "insert into {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan (MaChanDoan, TenChanDoan)";
                sqlQuery += " select '" + maChanDoan + "', N'" + Utilities.ConvertSqlString(chanDoan) + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }
            else
            {
                CustomMessageBox.MSG_Waring_OK("Mã chẩn đoán đã có !\nVui lòng nhập mã khác");
            }
        }

        public void Add_ChanDoan(string maChanDoan)
        {
            if (!CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa chẩn đoán đang chọn ?")) return;
            var sqlQuery = "Delete ChanDoan  MaChanDoan ='" + maChanDoan.Trim() + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery);
        }

        public void Get_ChanDoan(ref SqlDataAdapter sqlDataAdapter, DataGridView dtg, BindingNavigator bv, string filter,
            ref DataTable dtData)
        {
            dtData = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan";
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sqlQuery += " where " + filter;
            }
            sqlQuery += " order by TenChanDoan";
            DataProvider.SelInsUpdDelODBC(sqlQuery, ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
        }

        public void Get_ChanDoan(CustomComboBox cbo, TextBox txtLink)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.DM_KhamBenh_ChanDoan";
            sqlQuery += " order by TenChanDoan";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            ControlExtension.BindDataToCobobox(dt, ref cbo, "MaChanDoan", "MaChanDoan", "MaChanDoan,TenChanDoan", "100,250", txtLink, 1);
        }
        #endregion
        //================================|||=====================================
        #region Quả lý mẫu để chọn
        public BaseModel Insert_dm_mauchon(DM_MAUCHON objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_MAUCHON (");
            sqlQuery.Append("\nIdloaimau");
            sqlQuery.Append("\n,Noidung");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", objInfo.Idloaimau.ToString());
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Noidung == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Noidung.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_MAUCHON where Id =  " + objInfo.Id.ToString()))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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
        public bool Update_dm_mauchon(DM_MAUCHON objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_MAUCHON set");
            sb.AppendFormat("\n Noidung = {0}", (objInfo.Noidung == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Noidung.ToString()) + "'"));
            sb.Append("\nwhere  Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool Delete_dm_mauchon(DM_MAUCHON objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_MAUCHON");
            sb.AppendFormat("\n where Id = {0}", objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_dm_mauchon(string[] id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_MAUCHON  ");
            if (id.Length > 0)
                sb.AppendFormat("\n where idloaimau in ({0})", Utilities.ConvertStrinArryToInClauseSQL(id, false));
            sb.Append("order by IdLoaiMau, Id");
            return sb.ToString();
        }
        public DataTable Data_dm_mauchon(string[] id)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_mauchon(id)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_mauchon(DataGridView dtg, BindingNavigator bv, string[] id)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_mauchon(id);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_mauchon(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string[] id)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_mauchon(id), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_mauchon(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string[] id)
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
            DataTable dtData = Data_dm_mauchon(id);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_MAUCHON Get_Info_dm_mauchon(string[] id)
        {
            DataTable dt = Data_dm_mauchon(id);
            DM_MAUCHON obj = new DM_MAUCHON();
            if (dt.Rows.Count > 0)

            {
                obj.Id = NumberConverter.To<int>(dt.Rows[0]["id"]);
                obj.Idloaimau = NumberConverter.To<int>(dt.Rows[0]["idloaimau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["noidung"].ToString()))
                    obj.Noidung = StringConverter.ToString(dt.Rows[0]["noidung"]);
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region dm_hentraketqua
        public BaseModel Insert_dm_hentraketqua(DM_HENTRAKETQUA objInfo)
        {
            var sqlPara = new SqlParameter[]
          {
                WorkingServices.GetParaFromOject("@Madanhmuc",objInfo.Madanhmuc),
                WorkingServices.GetParaFromOject("@Loaidanhmuc",objInfo.Loaidanhmuc),
                WorkingServices.GetParaFromOject("@Danhmucnhom",objInfo.Danhmucnhom),
                WorkingServices.GetParaFromOject("@Ngaytrongtuan",objInfo.Ngaytrongtuan),
                WorkingServices.GetParaFromOject("@Giobatdau",objInfo.Giobatdau.ToString("HH:mm:00")),
                WorkingServices.GetParaFromOject("@Gioketthuc",objInfo.Gioketthuc.ToString("HH:mm:59")),
                WorkingServices.GetParaFromOject("@Thoigianthuchien",objInfo.Thoigianthuchien),
                WorkingServices.GetParaFromOject("@Traquangay",objInfo.Traquangay),
                WorkingServices.GetParaFromOject("@Ngaythuchien",objInfo.Ngaythuchien),
                WorkingServices.GetParaFromOject("@Giotraquangay",objInfo.Giotraquangay.ToString("HH:mm:00")),
                WorkingServices.GetParaFromOject("@Giotratrongngay",objInfo.Giotratrongngay== null?string.Empty: objInfo.Giotratrongngay.Value.ToString("HH:mm:00")),
                WorkingServices.GetParaFromOject("@MaKhoaPhong",objInfo.MaKhoaPhong),
                WorkingServices.GetParaFromOject("@SoPhutCC",objInfo.SoPhutCC),
                WorkingServices.GetParaFromOject("@MaKhuDieuTri",objInfo.MaKhuDieuTri),
                WorkingServices.GetParaFromOject("@MaPhong",objInfo.MaPhong)
          };
            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insDanhMuc_HenTraKetQua", sqlPara),
                Name = string.Empty
            };
        }
        public bool Update_dm_hentraketqua(DM_HENTRAKETQUA objInfo)
        {
            //@Id int,
            //@Madanhmuc varchar(25),
            //@Loaidanhmuc varchar(25),
            //@Danhmucnhom bit,
            //@Ngaytrongtuan varchar(25),
            //@Giobatdau varchar(15),
            //@Gioketthuc varchar(15),
            //@Thoigianthuchien int,
            //@Traquangay bit,
            //@Ngaythuchien int,
            //@Giotraquangay varchar(15),
            //@Giotratrongngay varchar(15),
            //@MaKhoaPhong varchar(25),
            //@SoPhutCC int,
            //@MaKhuDieuTri varchar(25),
            //@MaPhong varchar(25)
            var sqlPara = new SqlParameter[]
          {
                WorkingServices.GetParaFromOject("@Id",objInfo.Id),
                WorkingServices.GetParaFromOject("@Madanhmuc",objInfo.Madanhmuc),
                WorkingServices.GetParaFromOject("@Loaidanhmuc",objInfo.Loaidanhmuc),
                WorkingServices.GetParaFromOject("@Danhmucnhom",objInfo.Danhmucnhom),
                WorkingServices.GetParaFromOject("@Ngaytrongtuan",objInfo.Ngaytrongtuan),
                WorkingServices.GetParaFromOject("@Giobatdau",objInfo.Giobatdau.ToString("HH:mm:00")),
                WorkingServices.GetParaFromOject("@Gioketthuc",objInfo.Gioketthuc.ToString("HH:mm:59")),
                WorkingServices.GetParaFromOject("@Thoigianthuchien",objInfo.Thoigianthuchien),
                WorkingServices.GetParaFromOject("@Traquangay",objInfo.Traquangay),
                WorkingServices.GetParaFromOject("@Ngaythuchien",objInfo.Ngaythuchien),
                WorkingServices.GetParaFromOject("@Giotraquangay",objInfo.Giotraquangay.ToString("HH:mm:00")),
                WorkingServices.GetParaFromOject("@Giotratrongngay",objInfo.Giotratrongngay== null?string.Empty: objInfo.Giotratrongngay.Value.ToString("HH:mm:00")),
                WorkingServices.GetParaFromOject("@MaKhoaPhong",objInfo.MaKhoaPhong),
                WorkingServices.GetParaFromOject("@SoPhutCC",objInfo.SoPhutCC),
                WorkingServices.GetParaFromOject("@MaKhuDieuTri",objInfo.MaKhuDieuTri),
                WorkingServices.GetParaFromOject("@MaPhong",objInfo.MaPhong)
          };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpDanhMuc_HenTraKetQua", sqlPara) > -1;
        }
        public bool Delete_dm_hentraketqua(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_HENTRAKETQUA");
            sb.AppendFormat("\n where Id = {0}", id);
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public DataTable Data_dm_hentraketqua(string id, string maloaiDichVu, string maNhom)
        {
            DataTable dtData = new DataTable();
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@id",id),
                WorkingServices.GetParaFromOject("@maloaiDichVu",maloaiDichVu),
                WorkingServices.GetParaFromOject("@maNhom",maNhom)
            };
            dtData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_HenTraKetQua", sqlPara).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_hentraketqua(DataGridView dtg, BindingNavigator bv, string id, string maloaiDichVu, string maNhom)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_hentraketqua(id, maloaiDichVu, maNhom);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_hentraketqua(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id, string maloaiDichVu, string maNhom)
        {
            var sqlPara = new SqlParameter[]
           {
                WorkingServices.GetParaFromOject("@id",id),
                WorkingServices.GetParaFromOject("@maloaiDichVu",maloaiDichVu),
                WorkingServices.GetParaFromOject("@maNhom",maNhom)
           };
            DataProvider.SelInsUpdDelODBC("selDanhMuc_HenTraKetQua", sqlPara, ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_hentraketqua(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName
            , string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id, string maloaiDichVu, string maNhom)
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
            DataTable dtData = Data_dm_hentraketqua(id, maloaiDichVu, maNhom);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_HENTRAKETQUA Get_Info_dm_hentraketqua(string id)
        {
            DataTable dt = Data_dm_hentraketqua(id, string.Empty, string.Empty);
            DM_HENTRAKETQUA obj = new DM_HENTRAKETQUA();
            if (dt.Rows.Count > 0)
            {
                obj.Id = NumberConverter.To<int>(dt.Rows[0]["id"]);
                obj.Madanhmuc = StringConverter.ToString(dt.Rows[0]["madanhmuc"]);
                obj.Loaidanhmuc = StringConverter.ToString(dt.Rows[0]["loaidanhmuc"]);
                obj.Danhmucnhom = NumberConverter.To<bool>(dt.Rows[0]["danhmucnhom"]);
                obj.Ngaytrongtuan = StringConverter.ToString(dt.Rows[0]["ngaytrongtuan"]);
                obj.Giobatdau = DateTime.ParseExact(dt.Rows[0]["giobatdau"].ToString(), "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
                obj.Gioketthuc = DateTime.ParseExact(dt.Rows[0]["gioketthuc"].ToString(), "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
                obj.Thoigianthuchien = NumberConverter.To<int>(dt.Rows[0]["thoigianthuchien"]);
                obj.Traquangay = NumberConverter.To<bool>(dt.Rows[0]["traquangay"]);
                obj.Ngaythuchien = NumberConverter.To<int>(dt.Rows[0]["ngaythuchien"]);
                obj.Giotraquangay = DateTime.ParseExact(dt.Rows[0]["giotraquangay"].ToString(), "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
                if (!string.IsNullOrEmpty(dt.Rows[0]["GioTraTrongNgay"].ToString()))
                    obj.Giotratrongngay = DateTime.ParseExact(dt.Rows[0]["GioTraTrongNgay"].ToString(), "HH:mm:ss", null, System.Globalization.DateTimeStyles.None);
                obj.MaKhoaPhong = StringConverter.ToString(dt.Rows[0]["MaKhoaPhong"]);
                obj.MaKhuDieuTri = StringConverter.ToString(dt.Rows[0]["MaKhuDieuTri"]);
                obj.MaPhong = StringConverter.ToString(dt.Rows[0]["MaPhong"]);
                obj.SoPhutCC = NumberConverter.To<int>(dt.Rows[0]["SoPhutCC"]);
            }
            return obj;
        }
        public bool Copy_CauHinhHenTraKQ(string loaiDanhMuc, int id, List<string> denMaXn, bool cheDoNhom)
        {
            var sqlPara = new SqlParameter[]
                 {
                    new SqlParameter("@LoaiDanhMuc", loaiDanhMuc)
                    ,new SqlParameter("@id",id )
                    ,new SqlParameter("@MaXnTo", Utilities.ConvertStrinArryToInClauseSQLForSplitString(denMaXn))
                    ,new SqlParameter("@CheDoNhom", cheDoNhom)
                 };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
             , "insCopyCauHinh_HenTraKetQua"
             , sqlPara) > -1;
        }
        #endregion
        //================================|||=====================================
        #region dm_ngaynghi
        //================================|||=====================================
        public BaseModel Insert_dm_ngaynghi(DM_NGAYNGHI objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI (");
            sqlQuery.Append("\nNgaynghi");
            sqlQuery.Append("\n,Ghichu");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + objInfo.Ngaynghi.ToString("yyyy-MM-dd") + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Ghichu == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ghichu.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI where 1 = 1  and Ngaynghi =  " + "'" + objInfo.Ngaynghi.ToString("yyyy-MM-dd") + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_ngaynghi(DM_NGAYNGHI objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI set");
            sb.AppendFormat("\n Ngaynghi = {0}", "'" + objInfo.Ngaynghi.ToString("yyyy-MM-dd") + "'");
            sb.AppendFormat("\n, Ghichu = {0}", (objInfo.Ghichu == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ghichu.ToString()) + "'"));
            sb.Append("\nwhere Ngaynghi =  " + "'" + objInfo.Ngaynghi.ToString("yyyy-MM-dd") + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_ngaynghi(DM_NGAYNGHI objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI");
            sb.AppendFormat("\n where Ngaynghi = {0}", "'" + objInfo.Ngaynghi.ToString("yyyy-MM-dd") + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public DataTable Data_dm_ngaynghi_benhnhan(string matiepnhan)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from {{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI where NgayNghi >= (select NgayTiepNhan from benhnhan_tiepnhan where MaTiepNhan = '{0}')", matiepnhan);
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        private string SQLSelect_Data_dm_ngaynghi(string ngaynghi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_NGAYNGHI where 1=1");
            if (!string.IsNullOrEmpty(ngaynghi))
                sb.AppendFormat("\n and  ngaynghi = {0}", "'" + ngaynghi + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_ngaynghi(string ngaynghi)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_ngaynghi(ngaynghi)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_ngaynghi(DataGridView dtg, BindingNavigator bv, string ngaynghi)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_ngaynghi(ngaynghi);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_ngaynghi(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string ngaynghi)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_ngaynghi(ngaynghi), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_ngaynghi(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string ngaynghi)
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
            DataTable dtData = Data_dm_ngaynghi(ngaynghi);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_NGAYNGHI Get_Info_dm_ngaynghi(string ngaynghi)
        {
            DataTable dt = Data_dm_ngaynghi(ngaynghi);
            DM_NGAYNGHI obj = new DM_NGAYNGHI();
            if (dt.Rows.Count > 0)

            {
                obj.Ngaynghi = (DateTime)dt.Rows[0]["ngaynghi"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["ghichu"].ToString()))
                    obj.Ghichu = StringConverter.ToString(dt.Rows[0]["ghichu"]);
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bophan
        public BaseModel Insert_dm_xetnghiem_bophan(DM_XETNGHIEM_BOPHAN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoPhan", objInfo.Mabophan),
                        WorkingServices.GetParaFromOject("@TenBoPhan", objInfo.Tenbophan),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)};


            if (!CheckExists_dm_xetnghiem_bophan(objInfo.Mabophan))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_bophan", para),
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

        public int Update_dm_xetnghiem_bophan(DM_XETNGHIEM_BOPHAN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoPhan", objInfo.Mabophan),
                        WorkingServices.GetParaFromOject("@TenBoPhan", objInfo.Tenbophan),
                        WorkingServices.GetParaFromOject("@SapXep", objInfo.Sapxep),
                        WorkingServices.GetParaFromOject("@KhongSD", objInfo.Khongsd),
                        WorkingServices.GetParaFromOject("@TenPhieuIn", objInfo.Tenphieuin),
                        WorkingServices.GetParaFromOject("@LogoISO", objInfo.Logoiso, isImage: true),
                        WorkingServices.GetParaFromOject("@SoBieuMau", objInfo.Sobieumau),
                        WorkingServices.GetParaFromOject("@NgayHieuLuc", objInfo.Ngayhieuluc),
                        WorkingServices.GetParaFromOject("@ChuKyMacDinh", objInfo.Chukymacdinh),
                        WorkingServices.GetParaFromOject("@ChucVuMacDinh", objInfo.Chucvumacdinh),
                        WorkingServices.GetParaFromOject("@SoPhienBan", objInfo.Sophienban),
                        WorkingServices.GetParaFromOject("@TenBieuMau", objInfo.Tenbieumau),
                        WorkingServices.GetParaFromOject("@ThongTinISO", objInfo.Thongtiniso),
                        WorkingServices.GetParaFromOject("@LogoISO2", objInfo.Logoiso2, isImage: true),
                        WorkingServices.GetParaFromOject("@GhiChuDuoiKetQua", objInfo.Ghichuduoiketqua),
                        WorkingServices.GetParaFromOject("@CoChuKyUserValid", objInfo.Cochukyuservalid),
                        WorkingServices.GetParaFromOject("@HISID", objInfo.Hisid),
                        WorkingServices.GetParaFromOject("@PhieuInCoNhom", objInfo.Phieuinconhom),
                        WorkingServices.GetParaFromOject("@ChiThongTinTrang1", objInfo.Chithongtintrang1),
                        WorkingServices.GetParaFromOject("@ChucVucKyKhoa", objInfo.Chucvuckykhoa),
                        WorkingServices.GetParaFromOject("@TenNguoiKyKhoa", objInfo.Tennguoikykhoa),
                        WorkingServices.GetParaFromOject("@KhongCheckISOLogo1", objInfo.Khongcheckisologo1),
                        WorkingServices.GetParaFromOject("@KhongCheckISOLogo2", objInfo.Khongcheckisologo2),
                        WorkingServices.GetParaFromOject("@ghichuphieuin", objInfo.Ghichuphieuin),
                        WorkingServices.GetParaFromOject("@TachPhieuTheoBSChiDinh", objInfo.Tachphieutheobschidinh),
                        WorkingServices.GetParaFromOject("@TachPhieuTheoOngMau", objInfo.Tachphieutheoongmau),
                        WorkingServices.GetParaFromOject("@TachPhieuTheoNhomIn", objInfo.Tachphieutheonhomin),
                        WorkingServices.GetParaFromOject("@GhepTenXnGhiChu", objInfo.Gheptenxnghichu),
                        WorkingServices.GetParaFromOject("@GhepGhiChuKhoa", objInfo.Ghepghichukhoa),
                        WorkingServices.GetParaFromOject("@DinhDangGhepDuyetKQ", objInfo.Dinhdangghepduyetkq),
                        WorkingServices.GetParaFromOject("@DinhDangGhepNhapKQ", objInfo.Dinhdangghepnhapkq)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_bophan", para);
        }
        public int Delete_dm_xetnghiem_bophan(string mabophan)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoPhan", mabophan)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_bophan", para);
        }
        public DataTable Data_dm_xetnghiem_bophan(string mabophan)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoPhan", mabophan)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_bophan", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_BOPHAN Get_Info_dm_xetnghiem_bophan(DataRow drInfo)
        {
            return (DM_XETNGHIEM_BOPHAN)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_BOPHAN(), drInfo);

        }
        public DM_XETNGHIEM_BOPHAN Get_Info_dm_xetnghiem_bophan(string mabophan)
        {
            DataTable dt = Data_dm_xetnghiem_bophan(mabophan);
            DM_XETNGHIEM_BOPHAN obj = new DM_XETNGHIEM_BOPHAN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_bophan(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_bophan(string mabophan)
        {
            return Data_dm_xetnghiem_bophan(mabophan).Rows.Count > 0;
        }
        public DataTable Data_dm_xetnghiem_bophan_withCategory(string category)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaNhomCLS", category)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_bophan_tunhom", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion
        //================================|||=====================================
        #region {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet
        //================================|||=====================================
        public BaseModel Insert_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet (");
            sqlQuery.Append("\nIdmayxn");
            sqlQuery.Append("\n,Idphanloaimay");
            sqlQuery.Append("\n,Tenhienthi");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", objInfo.Idmayxn.ToString());
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Idphanloaimay < 0 ? "0" : objInfo.Idphanloaimay.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tenhienthi == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenhienthi.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet where 1 = 1  and Idmayxn =  " + objInfo.Idmayxn.ToString()))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet set");
            sb.AppendFormat("\n Idmayxn = {0}", objInfo.Idmayxn.ToString());
            sb.AppendFormat("\n, Idphanloaimay = {0}", (objInfo.Idphanloaimay < 0 ? "0" : objInfo.Idphanloaimay.ToString()));
            sb.AppendFormat("\n, Tenhienthi = {0}", (objInfo.Tenhienthi == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenhienthi.ToString()) + "'"));
            sb.AppendFormat("\n, Idbhyt = {0}", (objInfo.IdBHYT == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.IdBHYT.ToString()) + "'"));
            sb.AppendFormat("\n, Hisid = {0}", (objInfo.Hisid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Hisid.ToString()) + "'"));
            sb.AppendFormat("\n, LuuKetQuaTrenIMS = {0}", objInfo.LuuKetQuaTrenIMS ? "1" : "0");
            sb.AppendFormat("\n, isNotStaticByModules = {0}", objInfo.IsNotStaticByModules ? "1" : "0");
            sb.AppendFormat("\n, GiaoThucBieuDo = {0}", (objInfo.GiaoThucBieuDo == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.GiaoThucBieuDo.ToString()) + "'"));
            sb.Append("\nwhere Idmayxn = " + objInfo.Idmayxn.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_h_mayxetnghiem_chitiet(H_MAYXETNGHIEM_CHITIET objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet");
            sb.AppendFormat("\n where 1=1 ");
            sb.AppendFormat("\n and Idmayxn = {0}", objInfo.Idmayxn.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_h_mayxetnghiem_chitiet(string idmayxn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ct.*, m.tenmay from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet ct inner join  {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem m on ct.Idmayxn = m.idmay where 1=1");
            if (!string.IsNullOrEmpty(idmayxn))
                sb.AppendFormat("\n and  ct.idmayxn = {0}", idmayxn);
            return sb.ToString();
        }
        public DataTable Data_h_mayxetnghiem_chitiet(string idmayxn)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_h_mayxetnghiem_chitiet(idmayxn)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_h_mayxetnghiem_chitiet(DataGridView dtg, BindingNavigator bv, string idmayxn)
        {
            DataTable dtData = new DataTable();
            dtData = Data_h_mayxetnghiem_chitiet(idmayxn);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_h_mayxetnghiem_chitiet(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idmayxn)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_h_mayxetnghiem_chitiet(idmayxn), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_h_mayxetnghiem_chitiet(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idmayxn)
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
            DataTable dtData = Data_h_mayxetnghiem_chitiet(idmayxn);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public H_MAYXETNGHIEM_CHITIET Get_Info_h_mayxetnghiem_chitiet(string idmayxn)
        {
            DataTable dt = Data_h_mayxetnghiem_chitiet(idmayxn);
            H_MAYXETNGHIEM_CHITIET obj = new H_MAYXETNGHIEM_CHITIET();
            if (dt.Rows.Count > 0)
            {
                obj.Idmayxn = NumberConverter.To<int>(dt.Rows[0]["idmayxn"]);
                obj.Idphanloaimay = NumberConverter.To<int>(dt.Rows[0]["idphanloaimay"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenhienthi"].ToString()))
                    obj.Tenhienthi = StringConverter.ToString(dt.Rows[0]["tenhienthi"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["IDBHYT"].ToString()))
                    obj.IdBHYT = StringConverter.ToString(dt.Rows[0]["IDBHYT"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["hisid"].ToString()))
                    obj.Hisid = StringConverter.ToString(dt.Rows[0]["hisid"]);
                obj.LuuKetQuaTrenIMS = bool.Parse(dt.Rows[0]["LuuKetQuaTrenIMS"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["GiaoThucBieuDo"].ToString()))
                    obj.GiaoThucBieuDo = StringConverter.ToString(dt.Rows[0]["GiaoThucBieuDo"]);

            }
            return obj;
        }

        public DataTable Data_h_mayxetnghiem_chitiet_theo_phanloai(int idphanloai)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem_chitiet ");
            if (idphanloai > -1)
                sb.AppendFormat("\n where idphanloaimay = {0}", idphanloai);
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }
        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bo
        public int Insert_dm_xetnghiem_bo(DM_XETNGHIEM_BO objInfo)
        {
            if (CheckExists_dm_xetnghiem_bo(objInfo.Maboxetnghiem)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", objInfo.Maboxetnghiem),
                        WorkingServices.GetParaFromOject("@TenBoXetNghiem", objInfo.Tenboxetnghiem),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_bo", para);
        }
        public int Update_dm_xetnghiem_bo(DM_XETNGHIEM_BO objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", objInfo.Maboxetnghiem),
                        WorkingServices.GetParaFromOject("@TenBoXetNghiem", objInfo.Tenboxetnghiem)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_bo", para);
        }
        public int Delete_dm_xetnghiem_bo(string maboxetnghiem)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", maboxetnghiem)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_bo", para);
        }
        public DataTable Data_dm_xetnghiem_bo(string maboxetnghiem)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", maboxetnghiem)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_bo", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_BO Get_Info_dm_xetnghiem_bo(DataRow drInfo)
        {
            return (DM_XETNGHIEM_BO)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_BO(), drInfo);
        }
        public DM_XETNGHIEM_BO Get_Info_dm_xetnghiem_bo(string maboxetnghiem)
        {
            DataTable dt = Data_dm_xetnghiem_bo(maboxetnghiem);
            DM_XETNGHIEM_BO obj = new DM_XETNGHIEM_BO();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_bo(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_bo(string maboxetnghiem)
        {
            return Data_dm_xetnghiem_bo(maboxetnghiem).Rows.Count > 0;
        }

        #endregion
        //================================|||=====================================
        #region dm_xetnghiem_bo_chitiet
        public int Insert_dm_xetnghiem_bo_chitiet(DM_XETNGHIEM_BO_CHITIET objInfo)
        {
            if (CheckExists_dm_xetnghiem_bo_chitiet(objInfo.Maboxetnghiem, objInfo.Machidinh, objInfo.Xnprofile)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", objInfo.Maboxetnghiem),
                        WorkingServices.GetParaFromOject("@MaChiDinh", objInfo.Machidinh),
                        WorkingServices.GetParaFromOject("@XNProfile", objInfo.Xnprofile),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_bo_chitiet", para);
        }
        public int Update_dm_xetnghiem_bo_chitiet(DM_XETNGHIEM_BO_CHITIET objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", objInfo.Maboxetnghiem),
                        WorkingServices.GetParaFromOject("@MaChiDinh", objInfo.Machidinh),
                        WorkingServices.GetParaFromOject("@XNProfile", objInfo.Xnprofile)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_bo_chitiet", para);
        }
        public int Delete_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", maboxetnghiem),
                        WorkingServices.GetParaFromOject("@MaChiDinh", machidinh),
                        WorkingServices.GetParaFromOject("@XNProfile", xnprofile)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_bo_chitiet", para);
        }
        public DataTable Data_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaBoXetNghiem", maboxetnghiem),
                        WorkingServices.GetParaFromOject("@MaChiDinh", machidinh),
                        WorkingServices.GetParaFromOject("@XNProfile", xnprofile)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_bo_chitiet", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_BO_CHITIET Get_Info_dm_xetnghiem_bo_chitiet(DataRow drInfo)
        {
            return (DM_XETNGHIEM_BO_CHITIET)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_BO_CHITIET(), drInfo);
        }
        public DM_XETNGHIEM_BO_CHITIET Get_Info_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {
            DataTable dt = Data_dm_xetnghiem_bo_chitiet(maboxetnghiem, machidinh, xnprofile);
            DM_XETNGHIEM_BO_CHITIET obj = new DM_XETNGHIEM_BO_CHITIET();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_bo_chitiet(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_bo_chitiet(string maboxetnghiem, string machidinh, bool xnprofile)
        {
            return Data_dm_xetnghiem_bo_chitiet(maboxetnghiem, machidinh, xnprofile).Rows.Count > 0;
        }

        #endregion
        //================================|||=====================================
        #region Loại mẫu
        public int Insert_dm_xetnghiem_loaimau(DM_XETNGHIEM_LOAIMAU objInfo)
        {
            if (CheckExists_dm_xetnghiem_loaimau(objInfo.Maloaimau)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaLoaiMau", objInfo.Maloaimau),
                        WorkingServices.GetParaFromOject("@LoaiMau", objInfo.Loaimau),
                        WorkingServices.GetParaFromOject("@MaLoaiMauChinh", objInfo.Maloaimauchinh),
                        WorkingServices.GetParaFromOject("@HISID", objInfo.Hisid),
                        WorkingServices.GetParaFromOject("@LoaiDvCLS", objInfo.Loaidvcls),
                        WorkingServices.GetParaFromOject("@MaNhomLoaiMau", objInfo.Manhomloaimau),
                        WorkingServices.GetParaFromOject("@ThuTu", objInfo.Thutu),
                        WorkingServices.GetParaFromOject("@WHONETID", objInfo.Whonetid),
                        WorkingServices.GetParaFromOject("@IntemTuDong", objInfo.Intemtudong),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_loaimau", para);
        }
        public int Update_dm_xetnghiem_loaimau(DM_XETNGHIEM_LOAIMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaLoaiMau", objInfo.Maloaimau),
                        WorkingServices.GetParaFromOject("@LoaiMau", objInfo.Loaimau),
                        WorkingServices.GetParaFromOject("@MaLoaiMauChinh", objInfo.Maloaimauchinh),
                        WorkingServices.GetParaFromOject("@HISID", objInfo.Hisid),
                        WorkingServices.GetParaFromOject("@LoaiDvCLS", objInfo.Loaidvcls),
                        WorkingServices.GetParaFromOject("@MaNhomLoaiMau", objInfo.Manhomloaimau),
                        WorkingServices.GetParaFromOject("@ThuTu", objInfo.Thutu),
                        WorkingServices.GetParaFromOject("@WHONETID", objInfo.Whonetid),
                        WorkingServices.GetParaFromOject("@IntemTuDong", objInfo.Intemtudong)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_loaimau", para);
        }
        public int Delete_dm_xetnghiem_loaimau(string maloaimau)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaLoaiMau", maloaimau)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_loaimau", para);
        }
        public DataTable Data_dm_xetnghiem_loaimau(string maloaimau, string LoaiDvCLS)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaLoaiMau", maloaimau),
                        WorkingServices.GetParaFromOject("@Loaidvcls", LoaiDvCLS)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_loaimau", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_LOAIMAU Get_Info_dm_xetnghiem_loaimau(DataRow drInfo)
        {
            return (DM_XETNGHIEM_LOAIMAU)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_LOAIMAU(), drInfo);
        }
        public DM_XETNGHIEM_LOAIMAU Get_Info_dm_xetnghiem_loaimau(string maloaimau)
        {
            DataTable dt = Data_dm_xetnghiem_loaimau(maloaimau, string.Empty);
            DM_XETNGHIEM_LOAIMAU obj = new DM_XETNGHIEM_LOAIMAU();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_loaimau(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_loaimau(string maloaimau)
        {
            return Data_dm_xetnghiem_loaimau(maloaimau, string.Empty).Rows.Count > 0;
        }
        public string MauOngMauTheoLoaiMau(string maloaimau)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaLoaiMau", maloaimau),
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selMauOngMau_TheoLoaiMau", para);
            if (ds == null) return string.Empty;
            var data = ds.Tables[0];
            if (data.Rows.Count > 0)
                return data.Rows[0]["MauNhanMau"].ToString();
            return string.Empty;
        }
        public DataTable Data_LoaiMau_GetDM(string maloaimau, bool hienthinhan, string[] phanLoaiMau)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaLoaiMau", maloaimau),
                        WorkingServices.GetParaFromOject("@Hienthinhan", hienthinhan),
                        WorkingServices.GetParaFromOject("@phanLoaiMau", ((phanLoaiMau??new string[]{ }).Length > 0 ?string.Join(",",phanLoaiMau) : string.Empty))
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMucXetNghiem_LoaiMau", para);
            if (ds != null)
                return ds.Tables[0];
            return null;
        }
        #endregion
        #region Loại mẫu nhận
        public BaseModel Insert_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU_NHOM (");
            sqlQuery.Append("\nManhomloaimau");
            sqlQuery.Append("\n,Tennhomloaimau");
            sqlQuery.Append("\n,Thutu");
            sqlQuery.Append("\n,Hienthinhan");
            sqlQuery.Append("\n,Loaidvcls");
            sqlQuery.Append("\n,Maunhanmau");
            sqlQuery.Append("\n,ThuTuUuTienLayMau");
            sqlQuery.Append("\n,TuInBarCodeKhiQuet");
            sqlQuery.Append("\n,ID1");
            sqlQuery.Append("\n,ID2");
            sqlQuery.Append("\n,ID3");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomloaimau.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tennhomloaimau == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennhomloaimau.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Thutu < 0 ? "0" : objInfo.Thutu.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (bool.Parse(objInfo.Hienthinhan.ToString()) ? "1" : "0"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Loaidvcls == null ? "'ClsXetNghiem'" : "'" + Utilities.ConvertSqlString(objInfo.Loaidvcls.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Maunhanmau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Maunhanmau.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.ThuTuUuTienLay < 1 ? "1" : objInfo.ThuTuUuTienLay.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.TuInBarCodeKhiQuet < 1 ? "0" : objInfo.TuInBarCodeKhiQuet.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Id1 == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Id1) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Id2 == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Id2) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Id3 == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Id3) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU_NHOM where Manhomloaimau =  " + "'" + Utilities.ConvertSqlString(objInfo.Manhomloaimau.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU_NHOM set");
            sb.AppendFormat("\n Manhomloaimau = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomloaimau.ToString()) + "'");
            sb.AppendFormat("\n, Tennhomloaimau = {0}", (objInfo.Tennhomloaimau == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennhomloaimau.ToString()) + "'"));
            sb.AppendFormat("\n, Thutu = {0}", (objInfo.Thutu < 0 ? "0" : objInfo.Thutu.ToString()));
            sb.AppendFormat("\n, Hienthinhan = {0}", (bool.Parse(objInfo.Hienthinhan.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Loaidvcls = {0}", (objInfo.Loaidvcls == null ? "'ClsXetNghiem'" : "'" + Utilities.ConvertSqlString(objInfo.Loaidvcls.ToString()) + "'"));
            sb.AppendFormat("\n, Maunhanmau = {0}", (objInfo.Maunhanmau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Maunhanmau.ToString()) + "'"));
            sb.AppendFormat("\n, ThuTuUuTienLayMau = {0}", (objInfo.ThuTuUuTienLay < 1 ? "1" : objInfo.ThuTuUuTienLay.ToString()));
            sb.AppendFormat("\n, TuInBarCodeKhiQuet = {0}", (objInfo.TuInBarCodeKhiQuet < 1 ? "0" : objInfo.TuInBarCodeKhiQuet.ToString()));
            sb.AppendFormat("\n, ID1 = {0}", (objInfo.Id1 == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Id1) + "'"));
            sb.AppendFormat("\n, ID2 = {0}", (objInfo.Id2 == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Id2) + "'"));
            sb.AppendFormat("\n, ID3 = {0}", (objInfo.Id3 == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Id3) + "'"));

            sb.Append("\nwhere Manhomloaimau =  " + "'" + Utilities.ConvertSqlString(objInfo.Manhomloaimau.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_xetnghiem_loaimau_nhom(DM_XETNGHIEM_LOAIMAU_NHOM objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU_NHOM");
            sb.AppendFormat("\n where Manhomloaimau = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomloaimau.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_xetnghiem_loaimau_nhom(string manhomloaimau, bool hienthinhan, string phanLoaiMau)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU_NHOM where 1=1");
            if (!string.IsNullOrEmpty(manhomloaimau))
                sb.AppendFormat("\n and  manhomloaimau = {0}", "'" + manhomloaimau + "'");
            if (hienthinhan)
                sb.Append("\nand HienThiNhan = 1 ");
            if (!string.IsNullOrEmpty(phanLoaiMau.Trim()))
                sb.AppendFormat("\n and  LoaiDvCLS = {0}", "'" + phanLoaiMau + "'");
            if (hienthinhan)
                sb.Append("\n Order by ThuTu asc");
            else
                sb.Append("\n Order by LoaiDvCLS,manhomloaimau asc");
            return sb.ToString();
        }
        public DataTable Data_dm_xetnghiem_loaimau_nhom(string manhomloaimau, bool hienthinhan, string phanLoaiMau)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_loaimau_nhom(manhomloaimau, hienthinhan, phanLoaiMau)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_loaimau_nhom(DataGridView dtg, BindingNavigator bv, string manhomloaimau)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_loaimau_nhom(manhomloaimau, false, string.Empty);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_loaimau_nhom(DataGridView dtg, BindingNavigator bv
            , ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manhomloaimau)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_loaimau_nhom(manhomloaimau, false, string.Empty), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_loaimau_nhom(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manhomloaimau)
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
            DataTable dtData = Data_dm_xetnghiem_loaimau_nhom(manhomloaimau, false, string.Empty);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_LOAIMAU_NHOM Get_Info_dm_xetnghiem_loaimau_nhom(string manhomloaimau)
        {
            DataTable dt = Data_dm_xetnghiem_loaimau_nhom(manhomloaimau, false, string.Empty);
            DM_XETNGHIEM_LOAIMAU_NHOM obj = new DM_XETNGHIEM_LOAIMAU_NHOM();
            if (dt.Rows.Count > 0)

            {
                obj.Manhomloaimau = StringConverter.ToString(dt.Rows[0]["manhomloaimau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tennhomloaimau"].ToString()))
                    obj.Tennhomloaimau = StringConverter.ToString(dt.Rows[0]["tennhomloaimau"]);
                obj.Thutu = NumberConverter.To<int>(dt.Rows[0]["thutu"]);
                obj.Hienthinhan = NumberConverter.To<bool>(dt.Rows[0]["hienthinhan"]);
                obj.Loaidvcls = StringConverter.ToString(dt.Rows[0]["loaidvcls"]);
                obj.ThuTuUuTienLay = NumberConverter.To<int>(dt.Rows[0]["ThuTuUuTienLayMau"]);
                obj.TuInBarCodeKhiQuet = NumberConverter.To<int>(dt.Rows[0]["TuInBarCodeKhiQuet"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["maunhanmau"].ToString()))
                    obj.Maunhanmau = StringConverter.ToString(dt.Rows[0]["maunhanmau"]);
            }
            return obj;
        }
        #endregion
        #region dm_xetnghiem_loaimauchinh
        public BaseModel Insert_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAUCHINH (");
            sqlQuery.Append("\nMaloaimauchinh");
            sqlQuery.Append("\n,Tenloaimauchinh");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Maloaimauchinh.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenloaimauchinh.ToString()) + "'");
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAUCHINH where Maloaimauchinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Maloaimauchinh.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAUCHINH set");
            sb.AppendFormat("\n Maloaimauchinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maloaimauchinh.ToString()) + "'");
            sb.AppendFormat("\n, Tenloaimauchinh = {0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenloaimauchinh.ToString()) + "'");
            sb.Append("\nwhere Maloaimauchinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Maloaimauchinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_xetnghiem_loaimauchinh(DM_XETNGHIEM_LOAIMAUCHINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAUCHINH");
            sb.AppendFormat("\n where Maloaimauchinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maloaimauchinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_xetnghiem_loaimauchinh(string maloaimauchinh)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAUCHINH where 1=1");
            if (!string.IsNullOrEmpty(maloaimauchinh))
                sb.AppendFormat("\n and  maloaimauchinh = {0}", "'" + maloaimauchinh + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_xetnghiem_loaimauchinh(string maloaimauchinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_loaimauchinh(maloaimauchinh)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_loaimauchinh(DataGridView dtg, BindingNavigator bv, string maloaimauchinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_loaimauchinh(maloaimauchinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_loaimauchinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maloaimauchinh)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_loaimauchinh(maloaimauchinh), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_loaimauchinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maloaimauchinh)
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
            DataTable dtData = Data_dm_xetnghiem_loaimauchinh(maloaimauchinh);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_LOAIMAUCHINH Get_Info_dm_xetnghiem_loaimauchinh(string maloaimauchinh)
        {
            DataTable dt = Data_dm_xetnghiem_loaimauchinh(maloaimauchinh);
            DM_XETNGHIEM_LOAIMAUCHINH obj = new DM_XETNGHIEM_LOAIMAUCHINH();
            if (dt.Rows.Count > 0)
            {
                obj.Maloaimauchinh = StringConverter.ToString(dt.Rows[0]["maloaimauchinh"]);
                obj.Tenloaimauchinh = StringConverter.ToString(dt.Rows[0]["tenloaimauchinh"]);
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region dm_khulaymau
        public BaseModel Insert_dm_khulaymau(DM_KHULAYMAU objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_KHULAYMAU (");
            sqlQuery.Append("\nIdkhulaymau");
            sqlQuery.Append("\n,Tenkhulaymau");
            sqlQuery.Append("\n,Makhuvuc");
            sqlQuery.Append("\n,Sophutconglaymau");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tenkhulaymau == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenkhulaymau.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Sophutconglaymau < 0 ? "0" : objInfo.Sophutconglaymau.ToString()));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_khulaymau where Idkhulaymau =  " + "'" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_khulaymau(DM_KHULAYMAU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_KHULAYMAU set");
            sb.AppendFormat("\n Idkhulaymau = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'");
            sb.AppendFormat("\n, Tenkhulaymau = {0}", (objInfo.Tenkhulaymau == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenkhulaymau.ToString()) + "'"));
            sb.AppendFormat("\n, Makhuvuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhuvuc.ToString()) + "'");
            sb.AppendFormat("\n, Sophutconglaymau = {0}", (objInfo.Sophutconglaymau < 0 ? "0" : objInfo.Sophutconglaymau.ToString()));
            sb.AppendFormat("\n, TemBarcode = {0}", "N'" + Utilities.ConvertSqlString(objInfo.TemBarcode.ToString()) + "'");
            sb.Append("\nwhere 1 = 1  and Idkhulaymau =  " + "'" + Utilities.ConvertSqlString(objInfo.Idkhulaymau.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_khulaymau(DM_KHULAYMAU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_KHULAYMAU");
            sb.AppendFormat("\n where Idkhulaymau = '{0}'", objInfo.Idkhulaymau.ToString());
            sb.AppendFormat("\n; update {{TPH_Standard}}_Dictionary.dbo.dm_khuvuc_maytinh set Idkhulaymau = null  where Idkhulaymau = '{0}'", objInfo.Idkhulaymau.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_dm_khulaymau(string idkhulaymau, string makhuvuc)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHULAYMAU where 1=1");
            if (!string.IsNullOrEmpty(idkhulaymau))
                sb.AppendFormat("\n and  idkhulaymau = '{0}'", idkhulaymau);
            if (!string.IsNullOrEmpty(makhuvuc))
                sb.AppendFormat("\n and  Makhuvuc = '{0}'", makhuvuc);
            return sb.ToString();
        }
        public DataTable Data_dm_khulaymau(string idkhulaymau, string makhuvuc)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_khulaymau(idkhulaymau, makhuvuc)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_khulaymau(DataGridView dtg, BindingNavigator bv, string idkhulaymau, string makhuvuc)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_khulaymau(idkhulaymau, makhuvuc);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_khulaymau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idkhulaymau, string makhuvuc)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_khulaymau(idkhulaymau, makhuvuc), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_khulaymau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idkhulaymau, string makhuvuc)
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
            DataTable dtData = Data_dm_khulaymau(idkhulaymau, makhuvuc);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_KHULAYMAU Get_Info_dm_khulaymau(string idkhulaymau)
        {
            DataTable dt = Data_dm_khulaymau(idkhulaymau, string.Empty);
            DM_KHULAYMAU obj = new DM_KHULAYMAU();
            if (dt.Rows.Count > 0)
            {
                obj.Idkhulaymau = StringConverter.ToString(dt.Rows[0]["idkhulaymau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenkhulaymau"].ToString()))
                    obj.Tenkhulaymau = StringConverter.ToString(dt.Rows[0]["tenkhulaymau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["makhuvuc"].ToString()))
                    obj.Makhuvuc = StringConverter.ToString(dt.Rows[0]["makhuvuc"]);
                obj.Sophutconglaymau = NumberConverter.To<int>(dt.Rows[0]["sophutconglaymau"]);
                obj.Gioihanlaymau = NumberConverter.To<int>(dt.Rows[0]["Gioihanlaymau"]);
                obj.Tulaymaukhitiepnhan = NumberConverter.To<bool>(dt.Rows[0]["Tulaymaukhitiepnhan"]);
                obj.Sophutgioihanlaymau = NumberConverter.To<int>(dt.Rows[0]["sophutgioihanlaymau"]);
                obj.SoGioLoadHis = NumberConverter.To<int>(dt.Rows[0]["SoGioLoadHis"]);
                obj.GioHanChuyenMau = NumberConverter.To<int>(dt.Rows[0]["GioHanChuyenMau"]);
                obj.TuChonChiDinh = bool.Parse(dt.Rows[0]["TuChonChiDinh"].ToString());
                obj.CoPhieuHen = bool.Parse(dt.Rows[0]["CoPhieuHen"].ToString());
                obj.NhapDanhSachUserLayMau = bool.Parse(dt.Rows[0]["NhapDanhSachUserLayMau"].ToString());
                obj.UserLayMauNhieuBan = bool.Parse(dt.Rows[0]["UserLayMauNhieuBan"].ToString());
                obj.InGiohen = bool.Parse(dt.Rows[0]["InGiohen"].ToString());
                obj.CoTemInSan = bool.Parse(dt.Rows[0]["CoTemInSan"].ToString());
                obj.TemBarcode = StringConverter.ToString(dt.Rows[0]["TemBarcode"]);
                obj.ChonNguoiLayMau = bool.Parse(dt.Rows[0]["ChonNguoiLayMau"].ToString());
                obj.TuThemChiDinhVaoBarcodeGanNhat = bool.Parse(dt.Rows[0]["TuThemChiDinhVaoBarcodeGanNhat"].ToString());
                obj.KhongChoTiepNhanNhieuLan = bool.Parse(dt.Rows[0]["KhongChoTiepNhanNhieuLan"].ToString());
            }
            return obj;
        }
        public DM_KHULAYMAU Get_Info_dm_khulaymau_Theomaytinh(string pcName)
        {
            var sqlpara = new SqlParameter[]
            {
                new SqlParameter("@PcName", pcName)
            };

            DataTable dt = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selThongTinMayTinh_KhuLayMau", sqlpara).Tables[0];
            DM_KHULAYMAU obj = new DM_KHULAYMAU();
            if (dt.Rows.Count > 0)

            {
                obj.Idkhulaymau = StringConverter.ToString(dt.Rows[0]["idkhulaymau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenkhulaymau"].ToString()))
                    obj.Tenkhulaymau = StringConverter.ToString(dt.Rows[0]["tenkhulaymau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["makhuvuc"].ToString()))
                    obj.Makhuvuc = StringConverter.ToString(dt.Rows[0]["makhuvuc"]);
                obj.Sophutconglaymau = NumberConverter.To<int>(dt.Rows[0]["sophutconglaymau"]);
                obj.Gioihanlaymau = NumberConverter.To<int>(dt.Rows[0]["Gioihanlaymau"]);
                obj.Tulaymaukhitiepnhan = NumberConverter.To<bool>(dt.Rows[0]["tulaymaukhitiepnhan"]);
                obj.Sophutgioihanlaymau = NumberConverter.To<int>(dt.Rows[0]["sophutgioihanlaymau"]);
                obj.SoGioLoadHis = NumberConverter.To<int>(dt.Rows[0]["SoGioLoadHis"]);
                obj.GioHanChuyenMau = NumberConverter.To<int>(dt.Rows[0]["GioHanChuyenMau"]);
                obj.TuChonChiDinh = bool.Parse(dt.Rows[0]["TuChonChiDinh"].ToString());
                obj.CoPhieuHen = bool.Parse(dt.Rows[0]["CoPhieuHen"].ToString());
                obj.NhapDanhSachUserLayMau = bool.Parse(dt.Rows[0]["NhapDanhSachUserLayMau"].ToString());
                obj.UserLayMauNhieuBan = bool.Parse(dt.Rows[0]["UserLayMauNhieuBan"].ToString());
                obj.InGiohen = bool.Parse(dt.Rows[0]["InGiohen"].ToString());
                obj.CoTemInSan = bool.Parse(dt.Rows[0]["CoTemInSan"].ToString());
                obj.TemBarcode = StringConverter.ToString(dt.Rows[0]["TemBarcode"]);
                obj.ChonNguoiLayMau = bool.Parse(dt.Rows[0]["ChonNguoiLayMau"].ToString());
                obj.TuThemChiDinhVaoBarcodeGanNhat = bool.Parse(dt.Rows[0]["TuThemChiDinhVaoBarcodeGanNhat"].ToString());
                obj.KhongChoTiepNhanNhieuLan = bool.Parse(dt.Rows[0]["KhongChoTiepNhanNhieuLan"].ToString());
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region Tình trạng mẫu
        public DataTable Data_DanhMucTinhTrangMau(int LoaiXetNghiem)
        {
            var sqlPara = new SqlParameter[] { new SqlParameter("@LoaiXetNghiem", LoaiXetNghiem) };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_TinhTrangMau", sqlPara);
            return ds.Tables[0];
        }
        public BaseModel Insert_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_TINHTRANGMAU (");
            sqlQuery.Append("\nTinhtrangmau");
            sqlQuery.Append("\n,Loaixetnghiem");
            sqlQuery.Append("\n,Matinhtrang");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat(" {0}", (objInfo.Tinhtrangmau == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tinhtrangmau.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Loaixetnghiem < 0 ? "0" : objInfo.Loaixetnghiem.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Matinhtrang == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Matinhtrang.ToString()) + "'"));
            if (!DataProvider.CheckExisted(string.Format("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_tinhtrangmau where Matinhtrang = '{0}'", objInfo.Matinhtrang.ToString())))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_TINHTRANGMAU set");
            sb.AppendFormat("\n Tinhtrangmau = {0}", (objInfo.Tinhtrangmau == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tinhtrangmau.ToString()) + "'"));
            sb.AppendFormat("\n, Loaixetnghiem = {0}", (objInfo.Loaixetnghiem < 0 ? "0" : objInfo.Loaixetnghiem.ToString()));
            sb.AppendFormat("\n, Matinhtrang = {0}", (objInfo.Matinhtrang == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Matinhtrang.ToString()) + "'"));
            sb.Append("\nwhere Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_tinhtrangmau(DM_TINHTRANGMAU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_tinhtrangmau");
            sb.AppendFormat("\n where Id = {0}", objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_tinhtrangmau(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_tinhtrangmau where 1=1");
            if (!string.IsNullOrEmpty(id))
                sb.AppendFormat("\n and  id = {0}", id);
            return sb.ToString();
        }
        public DataTable Data_dm_tinhtrangmau(string id)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_tinhtrangmau(id)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_tinhtrangmau(DataGridView dtg, BindingNavigator bv, string id)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_tinhtrangmau(id);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_tinhtrangmau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_tinhtrangmau(id), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_tinhtrangmau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id)
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
            DataTable dtData = Data_dm_tinhtrangmau(id);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_TINHTRANGMAU Get_Info_dm_tinhtrangmau(string id)
        {
            DataTable dt = Data_dm_tinhtrangmau(id);
            DM_TINHTRANGMAU obj = new DM_TINHTRANGMAU();
            if (dt.Rows.Count > 0)

            {
                obj.Id = NumberConverter.To<int>(dt.Rows[0]["id"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tinhtrangmau"].ToString()))
                    obj.Tinhtrangmau = StringConverter.ToString(dt.Rows[0]["tinhtrangmau"]);
                obj.Loaixetnghiem = NumberConverter.To<int>(dt.Rows[0]["loaixetnghiem"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["matinhtrang"].ToString()))
                    obj.Matinhtrang = StringConverter.ToString(dt.Rows[0]["matinhtrang"]);
            }
            return obj;
        }

        #endregion
        //================================|||=====================================
        #region dm_email
        public BaseModel Insert_dm_email(DM_EMAIL objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_EMAIL (");
            sqlQuery.Append("\nEmail");
            sqlQuery.Append("\n,Madonvi");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Email.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Madonvi == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Madonvi.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_EMAIL where 1 = 1  and Email =  " + "'" + Utilities.ConvertSqlString(objInfo.Email.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_email(DM_EMAIL objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_EMAIL set");
            sb.AppendFormat("\n Email = {0}", "'" + Utilities.ConvertSqlString(objInfo.Email.ToString()) + "'");
            sb.AppendFormat("\n, Madonvi = {0}", (objInfo.Madonvi == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Madonvi.ToString()) + "'"));
            sb.Append("\nwhere 1 = 1  and Email =  " + "'" + Utilities.ConvertSqlString(objInfo.Email.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_email(DM_EMAIL objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.DM_EMAIL");
            sb.AppendFormat("\n where 1=1 ");
            sb.AppendFormat("\n and Email = {0}", "'" + Utilities.ConvertSqlString(objInfo.Email.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_email(string email)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.DM_EMAIL where 1=1");
            if (!string.IsNullOrEmpty(email))
                sb.AppendFormat("\n and  email = {0}", "'" + email + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_email(string email)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_email(email)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_email(DataGridView dtg, BindingNavigator bv, string email)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_email(email);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_email(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string email)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_email(email), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_email(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string email)
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
            DataTable dtData = Data_dm_email(email);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_EMAIL Get_Info_dm_email(string email)
        {
            DataTable dt = Data_dm_email(email);
            DM_EMAIL obj = new DM_EMAIL();
            if (dt.Rows.Count > 0)

            {
                obj.Email = StringConverter.ToString(dt.Rows[0]["email"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["madonvi"].ToString()))
                    obj.Madonvi = StringConverter.ToString(dt.Rows[0]["madonvi"]);
            }
            return obj;
        }
        #endregion
        //================================|||=====================================
        #region Tieu de trang in
        public void Get_Header_Config(SqlDataAdapter da, DataGridView dtg,
           BindingNavigator bv, string headerId,
           ref DataTable dt)
        {
            dt = new DataTable();
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where 1=1";
            if (!string.IsNullOrWhiteSpace(headerId))
            {
                sqlQuery += " and MaDonVi = '" + headerId + "'";
            }
            DataProvider.SelInsUpdDelODBC(sqlQuery, ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv, false);
        }

        public DataTable Get_Header_Config(string headerId)
        {
            var sqlQuery = " select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where 1=1";
            if (!string.IsNullOrWhiteSpace(headerId))
            {
                sqlQuery += " and MaDonVi = '" + headerId + "'";
            }
            return DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
        }

        public Image Load_Logo(string maDonVi)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("MaDonVi", maDonVi)
            };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLogoBV", sqlPara);
            if (data != null)
            {
                if (data.Tables[0].Rows.Count > 0)
                {
                    if (data.Tables[0].Rows[0]["ReportLogo"] != DBNull.Value)
                    {
                        return Image.FromStream(new MemoryStream((byte[])data.Tables[0].Rows[0]["ReportLogo"]));
                    }
                    else
                        return null;
                }

                else
                    return null;
            }
            return null;
        }
        #endregion

        #region LICENSE
        public DataSet GetApplicationLicense(string computerName, string applicationName, string serial)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@pcName", computerName),
                new SqlParameter("@appName",  StringConverter.ToString(applicationName)),
                new SqlParameter("@serial", StringConverter.ToString(serial))
            };

            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selAppLicense", para);
        }
        public bool CheckExistApplicationLicense(string computerName, string applicationName)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@pcName", computerName),
                new SqlParameter("@appName", applicationName)
            };

            var result = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selExistAppLicense", para).Tables[0];

            return result != null && result.Rows.Count > 0;
        }
        public bool InsertSerialKey(string computerName, string applicationName, string serialNumber)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@pcName", computerName),
                new SqlParameter("@appName", applicationName),
                new SqlParameter("@serial",  StringConverter.ToString(serialNumber))
            };

            if (!CheckExistApplicationLicense(computerName, applicationName))
            {
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insAppLicense", para) > -1;
            }
            else
            {
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updAppLicense", para) > -1;
            }
        }

        public bool UpdateSerialKey(string computerName, string applicationName, string serialNumber, string keyNumber)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@pcName", computerName),
                new SqlParameter("@appName", applicationName),
                new SqlParameter("@serial", serialNumber),
                new SqlParameter("@keyNumber", keyNumber)
            };

            if (!CheckExistApplicationLicense(computerName, applicationName))
            {
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insAppSerialKey", para) > -1;
            }
            else
            {
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updAppSerialKey", para) > -1;
            }
        }
        #endregion LICENSE

        #region Cấu hình máy in barcode
        public int Insert_CauHinhMayInbarcode(DM_MAYTINH_MAYIN obj)
        {
            SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@TenMayTinh", obj.Tenmaytinh),
                    new SqlParameter("@IDMay", obj.Idmay)
                };
            var iCount = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insCauHinh_MayInBarcode", para);
            if (iCount < 1)
                CustomMessageBox.MSG_Information_OK("Máy in đã được khai báo trước.");
            return iCount;
        }
        public int Update_CauHinhMayInbarcode(DM_MAYTINH_MAYIN obj)
        {
            SqlParameter[] para = new SqlParameter[]
              {
                    new SqlParameter("@TenMayTinh", obj.Tenmaytinh),
                    new SqlParameter("@IDMay", obj.Idmay),
                    new SqlParameter("@GiaoThuc", obj.Giaothuc),
                    new SqlParameter("@IPMayIn", obj.Ipmayin),
                    new SqlParameter("@DuongDan", obj.Duongdan),
                    new SqlParameter("@Cong", obj.Cong),
                    new SqlParameter("@TaiKhoan", obj.Taikhoan),
                    new SqlParameter("@MatKhau", obj.Matkhau),
                    new SqlParameter("@SuDung", obj.SuDung),
                    new SqlParameter("@HisId", obj.HisId),
                    new SqlParameter("@BanTiepNhan", obj.BanTiepNhan)
              };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpCauHinh_MayInbarcode", para);
        }
        public int Delete_CauHinhMayInBarcode(DM_MAYTINH_MAYIN obj)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TenMayTinh", obj.Tenmaytinh),
                new SqlParameter("@IDMay", obj.Idmay)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delCauHinh_MayInBarcode", para);
        }
        public DataTable Data_DanhSach_CauHinhMayInbarcode(string tenMayTinh, int idMay, int suDung)
        {
            SqlParameter[] para = new SqlParameter[]
               {
                    new SqlParameter("@TenMayTinh", tenMayTinh),
                    new SqlParameter("@IDMay", idMay),
                    new SqlParameter("@SuDung", suDung)
               };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selCauHinh_MayInBarcode", para).Tables[0];
        }

        public DM_MAYTINH_MAYIN Get_info_CauHinh_MaInbarcode(string tenMayTinh, int idMay, int suDung)
        {
            var dt = Data_DanhSach_CauHinhMayInbarcode(tenMayTinh, idMay, suDung);
            DM_MAYTINH_MAYIN obj = new DM_MAYTINH_MAYIN();
            if (dt.Rows.Count > 0)
            {
                return Get_info_CauHinh_MaInbarcode(dt.Rows[0]);
            }
            return obj;
        }
        public DM_MAYTINH_MAYIN Get_info_CauHinh_MaInbarcode(DataRow dr)
        {
            DM_MAYTINH_MAYIN obj = new DM_MAYTINH_MAYIN();
            obj.Tenmaytinh = StringConverter.ToString(dr["tenmaytinh"]);
            obj.Idmay = NumberConverter.To<int>(dr["idmay"]);
            if (!string.IsNullOrEmpty(dr["giaothuc"].ToString()))
                obj.Giaothuc = StringConverter.ToString(dr["giaothuc"]);
            if (!string.IsNullOrEmpty(dr["ipmayin"].ToString()))
                obj.Ipmayin = StringConverter.ToString(dr["ipmayin"]);
            if (!string.IsNullOrEmpty(dr["duongdan"].ToString()))
                obj.Duongdan = StringConverter.ToString(dr["duongdan"]);
            obj.Cong = NumberConverter.To<int>(dr["cong"]);
            if (!string.IsNullOrEmpty(dr["taikhoan"].ToString()))
                obj.Taikhoan = StringConverter.ToString(dr["taikhoan"]);
            if (!string.IsNullOrEmpty(dr["matkhau"].ToString()))
                obj.Matkhau = StringConverter.ToString(dr["matkhau"]);
            obj.HisId = StringConverter.ToString(dr["HisId"]);
            if (!string.IsNullOrEmpty(dr["BanTiepNhan"].ToString()))
                obj.BanTiepNhan = StringConverter.ToString(dr["BanTiepNhan"]);
            return obj;
        }
        #endregion

        #region Máy tính
        public BaseModel Insert_dm_maytinh(DM_MAYTINH objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_MAYTINH (");
            sqlQuery.Append("\nTenmaytinh");
            sqlQuery.Append("\n,Mota");
            sqlQuery.Append("\n,Makhuvucchinh");
            sqlQuery.Append("\n,Chonkhuvuc");
            sqlQuery.Append("\n,Versionid");
            sqlQuery.Append("\n,Thoigianlogingannhat");
            sqlQuery.Append("\n,Yeucaucapnhat");
            sqlQuery.Append("\n,Ip");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Makhuvucchinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Makhuvucchinh.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (bool.Parse(objInfo.Chonkhuvuc.ToString()) ? "1" : "0"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Versionid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Versionid.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Thoigianlogingannhat == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianlogingannhat.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (bool.Parse(objInfo.Yeucaucapnhat.ToString()) ? "1" : "0"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Ip == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Ip.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_maytinh where Tenmaytinh =  " + "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Máy tính đã khai báo."
                };
            }
        }

        public bool Update_dm_maytinh(DM_MAYTINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_MAYTINH set");
            sb.AppendFormat("\n Tenmaytinh = {0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()) + "'");
            sb.AppendFormat("\n, Mota = {0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            sb.AppendFormat("\n, Makhuvucchinh = {0}", (objInfo.Makhuvucchinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Makhuvucchinh.ToString()) + "'"));
            sb.AppendFormat("\n, Chonkhuvuc = {0}", (bool.Parse(objInfo.Chonkhuvuc.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Versionid = {0}", (objInfo.Versionid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Versionid.ToString()) + "'"));
            sb.AppendFormat("\n, Thoigianlogingannhat = {0}", (objInfo.Thoigianlogingannhat == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianlogingannhat.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Yeucaucapnhat = {0}", (bool.Parse(objInfo.Yeucaucapnhat.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Ip = {0}", (objInfo.Ip == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Ip.ToString()) + "'"));
            sb.Append("\nwhere 1 = 1  and Tenmaytinh =  " + "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_maytinh(DM_MAYTINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_maytinh");
            sb.AppendFormat("\n where Tenmaytinh = {0}", "N'" + Utilities.ConvertSqlString(objInfo.Tenmaytinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_maytinh(string tenmaytinh, string khulamviec)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_maytinh ");
            if (!string.IsNullOrEmpty(tenmaytinh))
                sb.AppendFormat("\n where  tenmaytinh = {0}", "'" + tenmaytinh + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_maytinh(string tenmaytinh, string khulamviec)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_maytinh(tenmaytinh, khulamviec)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_maytinh(DataGridView dtg, BindingNavigator bv, string tenmaytinh, string khulamviec)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_maytinh(tenmaytinh, khulamviec);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_maytinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string tenmaytinh, string khulamviec)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_maytinh(tenmaytinh, khulamviec), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_maytinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string tenmaytinh, string khulamviec)
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
            DataTable dtData = Data_dm_maytinh(tenmaytinh, khulamviec);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_MAYTINH Get_Info_dm_maytinh(string tenmaytinh)
        {
            DataTable dt = Data_dm_maytinh(tenmaytinh, string.Empty);
            DM_MAYTINH obj = new DM_MAYTINH();
            if (dt.Rows.Count > 0)

            {
                obj.Tenmaytinh = StringConverter.ToString(dt.Rows[0]["tenmaytinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["mota"].ToString()))
                    obj.Mota = StringConverter.ToString(dt.Rows[0]["mota"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["makhuvucchinh"].ToString()))
                    obj.Makhuvucchinh = StringConverter.ToString(dt.Rows[0]["makhuvucchinh"]);
                obj.Chonkhuvuc = NumberConverter.To<bool>(dt.Rows[0]["chonkhuvuc"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["versionid"].ToString()))
                    obj.Versionid = StringConverter.ToString(dt.Rows[0]["versionid"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianlogingannhat"].ToString()))
                    obj.Thoigianlogingannhat = (DateTime)dt.Rows[0]["thoigianlogingannhat"];
                obj.Yeucaucapnhat = NumberConverter.To<bool>(dt.Rows[0]["yeucaucapnhat"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ip"].ToString()))
                    obj.Ip = StringConverter.ToString(dt.Rows[0]["ip"]);
            }
            return obj;
        }
        #endregion

        #region Ghi chú tự động
        public int Insert_dm_xetnghiem_ghichutudong(DM_XETNGHIEM_GHICHUTUDONG objInfo)
        {
            var para = new SqlParameter[] {

                        WorkingServices.GetParaFromOject("@MaxN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_xetnghiem_ghichutudong", para);
        }
        public int Update_dm_xetnghiem_ghichutudong(DM_XETNGHIEM_GHICHUTUDONG objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", objInfo.Id),

                        WorkingServices.GetParaFromOject("@IDMayXN", objInfo.Idmayxn),
                        WorkingServices.GetParaFromOject("@KetQua", objInfo.Ketqua),
                        WorkingServices.GetParaFromOject("@SoSanhTuyetDoi", objInfo.Sosanhtuyetdoi),
                        WorkingServices.GetParaFromOject("@GhiChu", objInfo.Ghichu),
                        WorkingServices.GetParaFromOject("@LoaiGiaTriSoSanh", objInfo.Loaigiatrisosanh),
                        WorkingServices.GetParaFromOject("@Gioitinh", objInfo.Gioitinh)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_xetnghiem_ghichutudong", para);
        }
        public int Delete_dm_xetnghiem_ghichutudong(int id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_xetnghiem_ghichutudong", para);
        }
        public DataTable Data_dm_xetnghiem_ghichutudong(int? id, string Maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id),
                        WorkingServices.GetParaFromOject("@MaxN", Maxn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_ghichutudong", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_XETNGHIEM_GHICHUTUDONG Get_Info_dm_xetnghiem_ghichutudong(DataRow drInfo)
        {
            return (DM_XETNGHIEM_GHICHUTUDONG)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_GHICHUTUDONG(), drInfo);
        }
        public DM_XETNGHIEM_GHICHUTUDONG Get_Info_dm_xetnghiem_ghichutudong(int id)
        {
            DataTable dt = Data_dm_xetnghiem_ghichutudong(id, string.Empty);
            DM_XETNGHIEM_GHICHUTUDONG obj = new DM_XETNGHIEM_GHICHUTUDONG();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_ghichutudong(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_xetnghiem_ghichutudong(int id)
        {
            return Data_dm_xetnghiem_ghichutudong(id, string.Empty).Rows.Count > 0;
        }

        #endregion
        #region Cài đặt hiển thị
        public List<HienThiModel> lstThongTinHienThi(string idLoaihienThi)
        {
            var lstRerurn = new List<HienThiModel>();
            var data = DataThongTinHienThi(idLoaihienThi, string.Empty);
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    lstRerurn.Add(InfoThongTinHienThiTuDataRow(dr));
                }
            }
            return lstRerurn;
        }
        public HienThiModel InfoThongTinHienthi(string idLoaiHienthi, string idHienThi)
        {
            var data = DataThongTinHienThi(idLoaiHienthi, idHienThi);
            if (data != null)
            {
                return InfoThongTinHienThiTuDataRow(data.Rows[0]);
            }
            return null;
        }
        public HienThiModel InfoThongTinHienThiTuDataRow(DataRow dr)
        {
            var obj = new HienThiModel();
            obj.Idhienthi = StringConverter.ToString(dr["idhienthi"]);
            obj.Idloaihienthi = StringConverter.ToString(dr["idloaihienthi"]);
            if (!string.IsNullOrEmpty(dr["mota"].ToString()))
                obj.Mota = StringConverter.ToString(dr["mota"]);
            obj.Dorong = NumberConverter.To<int>(dr["dorong"]);
            obj.Hienthi = NumberConverter.To<bool>(dr["hienthi"]);
            obj.Sapxep = NumberConverter.To<int>(dr["sapxep"]);
            return obj;
        }
        public DataTable DataThongTinHienThi(string idLoaiHienthi, string idHienThi)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@idHienThi",string.IsNullOrEmpty(idHienThi )?(object)DBNull.Value: idHienThi)
                , new SqlParameter("@idLoaiHienThi",string.IsNullOrEmpty(idLoaiHienthi )?(object)DBNull.Value: idLoaiHienthi)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selCauHinh_HienThi", sqlPara);
            if (ds != null)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public int InsertThongTinHienThi(HienThiModel hienThiModel)
        {
            var sqlPara = new SqlParameter[]
          {
                new SqlParameter("@idHienThi",string.IsNullOrEmpty(hienThiModel.Idhienthi )?(object)DBNull.Value: hienThiModel.Idhienthi)
                , new SqlParameter("@idLoaiHienThi",string.IsNullOrEmpty(hienThiModel.Idloaihienthi )?(object)DBNull.Value: hienThiModel.Idloaihienthi)
                , new SqlParameter("@MoTa",string.IsNullOrEmpty(hienThiModel.Mota )?(object)DBNull.Value: hienThiModel.Mota)
                , new SqlParameter("@DoRong",hienThiModel.Dorong)
                , new SqlParameter("@HienThi",hienThiModel.Hienthi)
                , new SqlParameter("@SapXep",hienThiModel.Sapxep)
                , new SqlParameter("@ChiThem",hienThiModel.ChiThem)
          };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insCauHinh_HienThi", sqlPara);
        }
        public int UpdateThongTinHienThi(HienThiModel hienThiModel)
        {
            var sqlPara = new SqlParameter[]
          {
                new SqlParameter("@idHienThi",string.IsNullOrEmpty(hienThiModel.Idhienthi )?(object)DBNull.Value: hienThiModel.Idhienthi)
                , new SqlParameter("@idLoaiHienThi",string.IsNullOrEmpty(hienThiModel.Idloaihienthi )?(object)DBNull.Value: hienThiModel.Idloaihienthi)
                , new SqlParameter("@MoTa",string.IsNullOrEmpty(hienThiModel.Mota )?(object)DBNull.Value: hienThiModel.Mota)
                , new SqlParameter("@DoRong",hienThiModel.Dorong)
                , new SqlParameter("@HienThi",hienThiModel.Hienthi)
                , new SqlParameter("@SapXep",hienThiModel.Sapxep)
          };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updCauHinh_HienThi", sqlPara);
        }
        public int DeleteThongTinHienThi(string idLoaiHienthi, string idHienThi)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@idHienThi",string.IsNullOrEmpty(idHienThi )?(object)DBNull.Value: idHienThi)
                , new SqlParameter("@idLoaiHienThi",string.IsNullOrEmpty(idLoaiHienthi )?(object)DBNull.Value: idLoaiHienthi)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delCauHinh_HienThi", sqlPara);
        }
        #endregion
        #region dm_nhomphong
        public BaseModel Insert_dm_nhomphong(DM_NHOMPHONG objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_NHOMPHONG (");
            sqlQuery.Append("\nManhomphong");
            sqlQuery.Append("\n,Tennhomphong");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tennhomphong == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennhomphong.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_nhomphong where Manhomphong =  " + "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_nhomphong(DM_NHOMPHONG objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_NHOMPHONG set");
            sb.AppendFormat("\n Manhomphong = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'");
            sb.AppendFormat("\n, Tennhomphong = {0}", (objInfo.Tennhomphong == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennhomphong.ToString()) + "'"));
            sb.Append("\nwhere Manhomphong =  " + "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_nhomphong(DM_NHOMPHONG objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_nhomphong");
            sb.AppendFormat("\n where Manhomphong = {0}", "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_nhomphong(string manhomphong)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_nhomphong where 1=1");
            if (!string.IsNullOrEmpty(manhomphong))
                sb.AppendFormat("\n and  manhomphong = {0}", "'" + manhomphong + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_nhomphong(string manhomphong)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_nhomphong(manhomphong)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_nhomphong(DataGridView dtg, BindingNavigator bv, string manhomphong)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_nhomphong(manhomphong);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_nhomphong(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string manhomphong)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_nhomphong(manhomphong), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_nhomphong(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string manhomphong)
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
            DataTable dtData = Data_dm_nhomphong(manhomphong);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_NHOMPHONG Get_Info_dm_nhomphong(string manhomphong)
        {
            DataTable dt = Data_dm_nhomphong(manhomphong);
            DM_NHOMPHONG obj = new DM_NHOMPHONG();
            if (dt.Rows.Count > 0)
            {
                obj.Manhomphong = StringConverter.ToString(dt.Rows[0]["manhomphong"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tennhomphong"].ToString()))
                    obj.Tennhomphong = StringConverter.ToString(dt.Rows[0]["tennhomphong"]);
            }
            return obj;
        }
        #endregion
        #region dm_phong
        public BaseModel Insert_dm_phong(DM_PHONG objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_PHONG (");
            sqlQuery.Append("\nMaphong");
            sqlQuery.Append("\n,Makhoaphong");
            sqlQuery.Append("\n,Tenphong");
            sqlQuery.Append("\n,Manhomphong");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Maphong.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Makhoaphong.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tenphong == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenphong.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Manhomphong == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_phong where 1 = 1  and Maphong =  " + "'" + Utilities.ConvertSqlString(objInfo.Maphong.ToString()) + "'" + " and Makhoaphong =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhoaphong.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_phong(DM_PHONG objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_PHONG set");
            sb.AppendFormat("\n Makhoaphong = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhoaphong.ToString()) + "'");
            sb.AppendFormat("\n, Tenphong = {0}", (objInfo.Tenphong == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenphong.ToString()) + "'"));
            sb.AppendFormat("\n, Manhomphong = {0}", (objInfo.Manhomphong == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Manhomphong.ToString()) + "'"));
            sb.Append("\nwhere Maphong =  " + "'" + Utilities.ConvertSqlString(objInfo.Maphong.ToString()) + "'" + " and Makhoaphong =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhoaphong.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_phong(DM_PHONG objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_phong");
            sb.AppendFormat("\n where 1=1 ");
            sb.AppendFormat("\n and Maphong = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maphong.ToString()) + "'");
            sb.AppendFormat("\n and Makhoaphong = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhoaphong.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_phong(string maphong, string makhoaphong, string manhomphong)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_phong where 1=1");
            if (!string.IsNullOrEmpty(maphong))
                sb.AppendFormat("\n and  maphong = {0}", "'" + maphong + "'");
            if (!string.IsNullOrEmpty(makhoaphong))
                sb.AppendFormat("\n and  makhoaphong = {0}", "'" + makhoaphong + "'");
            if (!string.IsNullOrEmpty(manhomphong))
                sb.AppendFormat("\n and  manhomphong = {0}", "'" + manhomphong + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_phong(string maphong, string makhoaphong, string manhomphong)
        {
            var para = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaPhong",maphong ),
                WorkingServices.GetParaFromOject("@MaKhoa",makhoaphong )
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_DanhSachPhong", para).Tables[0];
        }
        public DataTable Get_Data_dm_phong(DataGridView dtg, BindingNavigator bv, string maphong, string makhoaphong, string manhomphong)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_phong(maphong, makhoaphong, manhomphong);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_phong(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maphong, string makhoaphong, string manhomphong)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_phong(maphong, makhoaphong, manhomphong), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_phong(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maphong, string makhoaphong, string manhomphong)
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
            DataTable dtData = Data_dm_phong(maphong, makhoaphong, manhomphong);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_PHONG Get_Info_dm_phong(string maphong, string makhoaphong, string manhomphong)
        {
            DataTable dt = Data_dm_phong(maphong, makhoaphong, manhomphong);
            DM_PHONG obj = new DM_PHONG();
            if (dt.Rows.Count > 0)

            {
                obj.Maphong = StringConverter.ToString(dt.Rows[0]["maphong"]);
                obj.Makhoaphong = StringConverter.ToString(dt.Rows[0]["makhoaphong"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenphong"].ToString()))
                    obj.Tenphong = StringConverter.ToString(dt.Rows[0]["tenphong"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["manhomphong"].ToString()))
                    obj.Manhomphong = StringConverter.ToString(dt.Rows[0]["manhomphong"]);
            }
            return obj;
        }
        #endregion
        #region config
        public BaseModel Insert_config(CONFIG objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_System.dbo.CONFIG (");
            sqlQuery.Append("\nIdconfig");
            sqlQuery.Append("\n,Value1");
            sqlQuery.Append("\n,Value2");
            sqlQuery.Append("\n,Description");
            sqlQuery.Append("\n,Flat");
            sqlQuery.Append("\n,Nattest");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", objInfo.Idconfig.ToString());
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Value1 == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Value1.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Value2 == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Value2.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Description == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Description.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Flat < 0 ? "-1" : objInfo.Flat.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (bool.Parse(objInfo.Nattest.ToString()) ? "1" : "0"));
            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                Name = string.Empty
            };
        }

        public bool Update_config(CONFIG objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_System.dbo.CONFIG set");
            sb.AppendFormat("\n  Idconfig = {0}", objInfo.Idconfig.ToString());
            sb.AppendFormat("\n, Value1 = {0}", (objInfo.Value1 == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Value1.ToString()) + "'"));
            sb.AppendFormat("\n, Value2 = {0}", (objInfo.Value2 == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Value2.ToString()) + "'"));
            sb.AppendFormat("\n, Description = {0}", (objInfo.Description == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Description.ToString()) + "'"));
            sb.AppendFormat("\n, Flat = {0}", (objInfo.Flat < 0 ? "-1" : objInfo.Flat.ToString()));
            sb.AppendFormat("\n, Nattest = {0}", (bool.Parse(objInfo.Nattest.ToString()) ? "1" : "0"));
            sb.Append("\nwhere Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_config(CONFIG objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_System.dbo.config");
            sb.AppendFormat("\n where Id = {0}", objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_config(string id, string idConfig)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_System.dbo.config where 1 = 1");
            if (!string.IsNullOrEmpty(id))
                sb.AppendFormat("\n and id = {0}", id);
            if (!string.IsNullOrEmpty(idConfig))
                sb.AppendFormat("\n and idConfig = {0}", idConfig);
            sb.Append("\n order by ID asc");
            return sb.ToString();
        }
        public DataTable Data_config(string id, string idConfig)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_config(id, idConfig)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_config(DataGridView dtg, BindingNavigator bv, string id, string idConfig)
        {
            DataTable dtData = new DataTable();
            dtData = Data_config(id, idConfig);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_config(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter
            , ref DataTable dtData, string id, string idConfig)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_config(id, idConfig), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_config(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn
            , string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex
            , string id, string idConfig)
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
            DataTable dtData = Data_config(id, idConfig);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public CONFIG Get_Info_config(string id)
        {
            DataTable dt = Data_config(id, string.Empty);
            CONFIG obj = new CONFIG();
            if (dt.Rows.Count > 0)
            {
                obj.Id = NumberConverter.To<int>(dt.Rows[0]["id"]);
                obj.Idconfig = NumberConverter.To<int>(dt.Rows[0]["idconfig"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["value1"].ToString()))
                    obj.Value1 = StringConverter.ToString(dt.Rows[0]["value1"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["value2"].ToString()))
                    obj.Value2 = StringConverter.ToString(dt.Rows[0]["value2"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["description"].ToString()))
                    obj.Description = StringConverter.ToString(dt.Rows[0]["description"]);
                obj.Flat = NumberConverter.To<int>(dt.Rows[0]["flat"]);
                obj.Nattest = NumberConverter.To<bool>(dt.Rows[0]["nattest"]);
            }
            return obj;
        }
        #endregion
        #region dm_loaiimport
        public BaseModel Insert_dm_loaiimport(DM_LOAIIMPORT objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into {{TPH_Standard}}_Dictionary.dbo.DM_LOAIIMPORT (");
            sqlQuery.Append("\nMaimport");
            sqlQuery.Append("\n,Tenimport");
            sqlQuery.Append("\n,Dongtieude");
            sqlQuery.Append("\n,Dongbatdau");
            sqlQuery.Append("\n,Loaiimport");
            sqlQuery.Append("\n,Noidong");
            sqlQuery.Append("\n,Cotindexnoidong");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Maimport.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tenimport == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenimport.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Dongtieude < 0 ? "1" : objInfo.Dongtieude.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Dongbatdau < 0 ? "2" : objInfo.Dongbatdau.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Loaiimport < 0 ? "1" : objInfo.Loaiimport.ToString()));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Noidong ? "1" : "0"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Cotindexnoidong == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Cotindexnoidong.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_loaiimport where Maimport =  " + "'" + Utilities.ConvertSqlString(objInfo.Maimport.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_loaiimport(DM_LOAIIMPORT objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_LOAIIMPORT set");
            sb.AppendFormat("\n Tenimport = {0}", (objInfo.Tenimport == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenimport.ToString()) + "'"));
            sb.AppendFormat("\n, Dongtieude = {0}", (objInfo.Dongtieude < 0 ? "1" : objInfo.Dongtieude.ToString()));
            sb.AppendFormat("\n, Dongbatdau = {0}", (objInfo.Dongbatdau < 0 ? "2" : objInfo.Dongbatdau.ToString()));
            sb.AppendFormat("\n, Loaiimport = {0}", (objInfo.Loaiimport < 0 ? "1" : objInfo.Loaiimport.ToString()));
            sb.AppendFormat("\n, Noidong = {0}", (objInfo.Noidong ? "1" : "0"));
            sb.AppendFormat("\n Cotindexnoidong = {0}", (objInfo.Cotindexnoidong == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Cotindexnoidong.ToString()) + "'"));
            sb.Append("\nwhere Maimport =  " + "'" + Utilities.ConvertSqlString(objInfo.Maimport.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_loaiimport(DM_LOAIIMPORT objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_loaiimport");
            sb.AppendFormat("\n where  Maimport = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maimport.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_loaiimport(string maimport)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_loaiimport where 1=1");
            if (!string.IsNullOrEmpty(maimport))
                sb.AppendFormat("\n and  maimport = {0}", "'" + maimport + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_loaiimport(string maimport)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_loaiimport(maimport)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_loaiimport(DataGridView dtg, BindingNavigator bv, string maimport)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_loaiimport(maimport);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_loaiimport(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maimport)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_loaiimport(maimport), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_loaiimport(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maimport)
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
            DataTable dtData = Data_dm_loaiimport(maimport);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_LOAIIMPORT Get_Info_dm_loaiimport(string maimport)
        {
            DataTable dt = Data_dm_loaiimport(maimport);
            DM_LOAIIMPORT obj = new DM_LOAIIMPORT();
            if (dt.Rows.Count > 0)
            {
                obj.Maimport = StringConverter.ToString(dt.Rows[0]["maimport"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenimport"].ToString()))
                    obj.Tenimport = StringConverter.ToString(dt.Rows[0]["tenimport"]);
                obj.Dongtieude = NumberConverter.To<int>(dt.Rows[0]["dongtieude"]);
                obj.Dongbatdau = NumberConverter.To<int>(dt.Rows[0]["dongbatdau"]);
                obj.Loaiimport = NumberConverter.To<int>(dt.Rows[0]["loaiimport"]);
                obj.Noidong = bool.Parse(dt.Rows[0]["Noidong"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["Cotindexnoidong"].ToString()))
                    obj.Cotindexnoidong = StringConverter.ToString(dt.Rows[0]["Cotindexnoidong"]);
            }
            return obj;
        }
        public BaseModel Insert_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into {{TPH_Standard}}_Dictionary.dbo.DM_LOAIIMPORT_MAPPING (");
            sqlQuery.Append("\nMaimport");
            sqlQuery.Append("\n,Liscolumn");
            sqlQuery.Append("\n,Excelcolumn");
            sqlQuery.Append("\n,Loaixetnghiem");
            sqlQuery.Append("\n,Ketluancuaxn");
            sqlQuery.Append("\n,Maxnlis");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Maimport.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Liscolumn.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Excelcolumn == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Excelcolumn.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (bool.Parse(objInfo.Loaixetnghiem.ToString()) ? "1" : "0"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Ketluancuaxn == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluancuaxn.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Maxnlis == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Maxnlis.ToString()) + "'"));

            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                Name = string.Empty
            };

        }

        public bool Update_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_LOAIIMPORT_MAPPING set");
            sb.AppendFormat("\n Maimport = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maimport.ToString()) + "'");
            sb.AppendFormat("\n, Liscolumn = {0}", "'" + Utilities.ConvertSqlString(objInfo.Liscolumn.ToString()) + "'");
            sb.AppendFormat("\n, Excelcolumn = {0}", (objInfo.Excelcolumn == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Excelcolumn.ToString()) + "'"));
            sb.AppendFormat("\n, Loaixetnghiem = {0}", (bool.Parse(objInfo.Loaixetnghiem.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Ketluancuaxn = {0}", (objInfo.Ketluancuaxn == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluancuaxn.ToString()) + "'"));
            sb.AppendFormat("\n, Maxnlis = {0}", (objInfo.Maxnlis == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Maxnlis.ToString()) + "'"));
            sb.Append("\nwhere Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_loaiimport_mapping(DM_LOAIIMPORT_MAPPING objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_loaiimport_mapping");
            sb.Append("\nwhere Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_loaiimport_mapping(string maimport, string liscolumn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_loaiimport_mapping where 1=1");
            if (!string.IsNullOrEmpty(maimport))
                sb.AppendFormat("\n and  maimport = {0}", "'" + maimport + "'");
            if (!string.IsNullOrEmpty(liscolumn))
                sb.AppendFormat("\n and  liscolumn = {0}", "'" + liscolumn + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_loaiimport_mapping(string maimport, string liscolumn)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_loaiimport_mapping(maimport, liscolumn)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_loaiimport_mapping(DataGridView dtg, BindingNavigator bv, string maimport, string liscolumn)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_loaiimport_mapping(maimport, liscolumn);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_loaiimport_mapping(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maimport, string liscolumn)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_loaiimport_mapping(maimport, liscolumn), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_loaiimport_mapping(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maimport, string liscolumn)
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
            DataTable dtData = Data_dm_loaiimport_mapping(maimport, liscolumn);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_LOAIIMPORT_MAPPING Get_Info_dm_loaiimport_mapping(string maimport, string liscolumn)
        {
            DataTable dt = Data_dm_loaiimport_mapping(maimport, liscolumn);
            DM_LOAIIMPORT_MAPPING obj = new DM_LOAIIMPORT_MAPPING();
            if (dt.Rows.Count > 0)
            {
                obj.Id = NumberConverter.To<int>(dt.Rows[0]["id"]);
                obj.Maimport = StringConverter.ToString(dt.Rows[0]["maimport"]);
                obj.Liscolumn = StringConverter.ToString(dt.Rows[0]["liscolumn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["excelcolumn"].ToString()))
                    obj.Excelcolumn = StringConverter.ToString(dt.Rows[0]["excelcolumn"]);
                obj.Loaixetnghiem = NumberConverter.To<bool>(dt.Rows[0]["loaixetnghiem"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluancuaxn"].ToString()))
                    obj.Ketluancuaxn = StringConverter.ToString(dt.Rows[0]["ketluancuaxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["maxnlis"].ToString()))
                    obj.Maxnlis = StringConverter.ToString(dt.Rows[0]["maxnlis"]);
            }
            return obj;
        }
        public List<DM_LOAIIMPORT_MAPPING> Get_ListInfo_dm_loaiimport_mapping(string maimport)
        {
            DataTable dt = Data_dm_loaiimport_mapping(maimport, string.Empty);
            var LstObj = new List<DM_LOAIIMPORT_MAPPING>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new DM_LOAIIMPORT_MAPPING();
                    obj.Id = NumberConverter.To<int>(dr["id"]);
                    obj.Maimport = StringConverter.ToString(dr["maimport"]);
                    obj.Liscolumn = StringConverter.ToString(dr["liscolumn"]);
                    if (!string.IsNullOrEmpty(dr["excelcolumn"].ToString()))
                        obj.Excelcolumn = StringConverter.ToString(dr["excelcolumn"]);
                    obj.Loaixetnghiem = NumberConverter.To<bool>(dr["loaixetnghiem"]);
                    if (!string.IsNullOrEmpty(dr["ketluancuaxn"].ToString()))
                        obj.Ketluancuaxn = StringConverter.ToString(dr["ketluancuaxn"]);
                    if (!string.IsNullOrEmpty(dr["maxnlis"].ToString()))
                        obj.Maxnlis = StringConverter.ToString(dr["maxnlis"]);
                    LstObj.Add(obj);
                }
            }
            return LstObj;
        }

        #endregion
        #region dm_doituongbenhnhan
        public int Insert_dm_doituongbenhnhan(DM_DOITUONGBENHNHAN objInfo)
        {
            if (CheckExists_dm_doituongbenhnhan(objInfo.Madoituongbn)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaDoiTuongBN", objInfo.Madoituongbn),
                        WorkingServices.GetParaFromOject("@TenDoiTuongBN", objInfo.Tendoituongbn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_doituongbenhnhan", para);
        }
        public int Update_dm_doituongbenhnhan(DM_DOITUONGBENHNHAN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaDoiTuongBN", objInfo.Madoituongbn),
                        WorkingServices.GetParaFromOject("@TenDoiTuongBN", objInfo.Tendoituongbn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_doituongbenhnhan", para);
        }
        public int Delete_dm_doituongbenhnhan(string madoituongbn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaDoiTuongBN", madoituongbn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_doituongbenhnhan", para);
        }
        public DataTable Data_dm_doituongbenhnhan(string madoituongbn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaDoiTuongBN", madoituongbn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_doituongbenhnhan", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_DOITUONGBENHNHAN Get_Info_dm_doituongbenhnhan(DataRow drInfo)
        {
            var objInfo = new DM_DOITUONGBENHNHAN();
            objInfo.Madoituongbn = StringConverter.ToString(drInfo["madoituongbn"]);
            if (!string.IsNullOrEmpty(drInfo["tendoituongbn"].ToString()))
                objInfo.Tendoituongbn = StringConverter.ToString(drInfo["tendoituongbn"]);
            return objInfo;
        }
        public DM_DOITUONGBENHNHAN Get_Info_dm_doituongbenhnhan(string madoituongbn)
        {
            DataTable dt = Data_dm_doituongbenhnhan(madoituongbn);
            DM_DOITUONGBENHNHAN obj = new DM_DOITUONGBENHNHAN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_doituongbenhnhan(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_doituongbenhnhan(string madoituongbn)
        {
            return Data_dm_doituongbenhnhan(madoituongbn).Rows.Count > 0;
        }

        #endregion
        #region Ngôn ngữ
        public BaseModel Insert_dm_ngonngu(DM_NGONNGU objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_NGONNGU (");
            sqlQuery.Append("\nIdngonngu");
            sqlQuery.Append("\n,Mota");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_ngonngu where 1 = 1  and Idngonngu =  " + "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_ngonngu(DM_NGONNGU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_NGONNGU set");
            sb.AppendFormat("\n Idngonngu = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            sb.AppendFormat("\n, Mota = {0}", (objInfo.Mota == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Mota.ToString()) + "'"));
            sb.Append("\nwhere 1 = 1  and Idngonngu =  " + "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_ngonngu(DM_NGONNGU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_ngonngu");
            sb.AppendFormat("\n where 1=1 ");
            sb.AppendFormat("\n and Idngonngu = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_ngonngu(string idngonngu)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_ngonngu where 1=1");
            if (!string.IsNullOrEmpty(idngonngu))
                sb.AppendFormat("\n and  idngonngu = {0}", "'" + idngonngu + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_ngonngu(string idngonngu)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_ngonngu(idngonngu)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_ngonngu(DataGridView dtg, BindingNavigator bv, string idngonngu)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_ngonngu(idngonngu);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_ngonngu(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string idngonngu)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_ngonngu(idngonngu), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_ngonngu(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string idngonngu)
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
            DataTable dtData = Data_dm_ngonngu(idngonngu);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_NGONNGU Get_Info_dm_ngonngu(string idngonngu)
        {
            DataTable dt = Data_dm_ngonngu(idngonngu);
            DM_NGONNGU obj = new DM_NGONNGU();
            if (dt.Rows.Count > 0)

            {
                obj.Idngonngu = StringConverter.ToString(dt.Rows[0]["idngonngu"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["mota"].ToString()))
                    obj.Mota = StringConverter.ToString(dt.Rows[0]["mota"]);
            }
            return obj;
        }
        public BaseModel Insert_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  {{TPH_Standard}}_Dictionary.dbo.DM_NGONNGU_DANHMUC (");
            sqlQuery.Append("\nIddanhmuc");
            sqlQuery.Append("\n,Madanhmuc");
            sqlQuery.Append("\n,Idngonngu");
            sqlQuery.Append("\n,Noidung");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Iddanhmuc.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Madanhmuc.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Noidung == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Noidung.ToString()) + "'"));

            if (!DataProvider.CheckExisted("select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_ngonngu_danhmuc where Iddanhmuc =  " + "'" + Utilities.ConvertSqlString(objInfo.Iddanhmuc.ToString()) + "'" + " and Madanhmuc =  " + "'" + Utilities.ConvertSqlString(objInfo.Madanhmuc.ToString()) + "'" + " and Idngonngu =  " + "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
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

        public bool Update_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update {{TPH_Standard}}_Dictionary.dbo.DM_NGONNGU_DANHMUC set");
            sb.AppendFormat("\n Iddanhmuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Iddanhmuc.ToString()) + "'");
            sb.AppendFormat("\n, Madanhmuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Madanhmuc.ToString()) + "'");
            sb.AppendFormat("\n, Idngonngu = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            sb.AppendFormat("\n, Noidung = {0}", (objInfo.Noidung == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Noidung.ToString()) + "'"));
            sb.Append("\nwhere 1 = 1  and Iddanhmuc =  " + "'" + Utilities.ConvertSqlString(objInfo.Iddanhmuc.ToString()) + "'" + " and Madanhmuc =  " + "'" + Utilities.ConvertSqlString(objInfo.Madanhmuc.ToString()) + "'" + " and Idngonngu =  " + "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_ngonngu_danhmuc(DM_NGONNGU_DANHMUC objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete {{TPH_Standard}}_Dictionary.dbo.dm_ngonngu_danhmuc");
            sb.AppendFormat("\n where 1=1 ");
            sb.AppendFormat("\n and Iddanhmuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Iddanhmuc.ToString()) + "'");
            sb.AppendFormat("\n and Madanhmuc = {0}", "'" + Utilities.ConvertSqlString(objInfo.Madanhmuc.ToString()) + "'");
            sb.AppendFormat("\n and Idngonngu = {0}", "'" + Utilities.ConvertSqlString(objInfo.Idngonngu.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from {{TPH_Standard}}_Dictionary.dbo.dm_ngonngu_danhmuc where 1=1");
            if (!string.IsNullOrEmpty(iddanhmuc))
                sb.AppendFormat("\n and  iddanhmuc = {0}", "'" + iddanhmuc + "'");
            if (!string.IsNullOrEmpty(madanhmuc))
                sb.AppendFormat("\n and  madanhmuc = {0}", "'" + madanhmuc + "'");
            if (!string.IsNullOrEmpty(idngonngu))
                sb.AppendFormat("\n and  idngonngu = {0}", "'" + idngonngu + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_ngonngu_danhmuc(DataGridView dtg, BindingNavigator bv, string iddanhmuc, string madanhmuc, string idngonngu)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_ngonngu_danhmuc(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string iddanhmuc, string madanhmuc, string idngonngu)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_ngonngu_danhmuc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string iddanhmuc, string madanhmuc, string idngonngu)
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
            DataTable dtData = Data_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_NGONNGU_DANHMUC Get_Info_dm_ngonngu_danhmuc(string iddanhmuc, string madanhmuc, string idngonngu)
        {
            DataTable dt = Data_dm_ngonngu_danhmuc(iddanhmuc, madanhmuc, idngonngu);
            DM_NGONNGU_DANHMUC obj = new DM_NGONNGU_DANHMUC();
            if (dt.Rows.Count > 0)

            {
                obj.Iddanhmuc = StringConverter.ToString(dt.Rows[0]["iddanhmuc"]);
                obj.Madanhmuc = StringConverter.ToString(dt.Rows[0]["madanhmuc"]);
                obj.Idngonngu = StringConverter.ToString(dt.Rows[0]["idngonngu"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["noidung"].ToString()))
                    obj.Noidung = StringConverter.ToString(dt.Rows[0]["noidung"]);
            }
            return obj;
        }
        public DataTable Data_DSDanhMuc_KhaiBaoNgonNgu(int idLoaiDanhMuc)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_KhaiBaoNgonNgu", new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@LoaiDanhMuc", idLoaiDanhMuc)
            });
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        #endregion
        #region dm_congtacvien
        public int Insert_dm_congtacvien(DM_CONGTACVIEN objInfo)
        {
            if (CheckExists_dm_congtacvien(objInfo.Macongtacvien)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTacVien", objInfo.Macongtacvien),
                        WorkingServices.GetParaFromOject("@TenCongTacVien", objInfo.Tencongtacvien),
                        WorkingServices.GetParaFromOject("@DiaChiCongTacVien", objInfo.Diachicongtacvien),
                        WorkingServices.GetParaFromOject("@DienThoaiCongTacVien", objInfo.Dienthoaicongtacvien),
                        WorkingServices.GetParaFromOject("@EmailCongTacVien", objInfo.Emailcongtacvien),
                        WorkingServices.GetParaFromOject("@CongTacVienChietKhau", objInfo.Congtacvienchietkhau),
                        WorkingServices.GetParaFromOject("@NgungCongTac", objInfo.Ngungcongtac),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@GioNhap", objInfo.Gionhap),
                        WorkingServices.GetParaFromOject("@NguoiSua", objInfo.Nguoisua),
                        WorkingServices.GetParaFromOject("@GioSua", objInfo.Giosua)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_congtacvien", para);
        }
        public int Update_dm_congtacvien(DM_CONGTACVIEN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTacVien", objInfo.Macongtacvien),
                        WorkingServices.GetParaFromOject("@TenCongTacVien", objInfo.Tencongtacvien),
                        WorkingServices.GetParaFromOject("@DiaChiCongTacVien", objInfo.Diachicongtacvien),
                        WorkingServices.GetParaFromOject("@DienThoaiCongTacVien", objInfo.Dienthoaicongtacvien),
                        WorkingServices.GetParaFromOject("@EmailCongTacVien", objInfo.Emailcongtacvien),
                        WorkingServices.GetParaFromOject("@CongTacVienChietKhau", objInfo.Congtacvienchietkhau),
                        WorkingServices.GetParaFromOject("@NgungCongTac", objInfo.Ngungcongtac),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@GioNhap", objInfo.Gionhap),
                        WorkingServices.GetParaFromOject("@NguoiSua", objInfo.Nguoisua),
                        WorkingServices.GetParaFromOject("@GioSua", objInfo.Giosua)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_congtacvien", para);
        }
        public int Delete_dm_congtacvien(string macongtacvien)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTacVien", macongtacvien)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_congtacvien", para);
        }
        public DataTable Data_dm_congtacvien(string macongtacvien)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTacVien", macongtacvien)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_congtacvien", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_CONGTACVIEN Get_Info_dm_congtacvien(DataRow drInfo)
        {
            var objInfo = new DM_CONGTACVIEN();
            return (DM_CONGTACVIEN)WorkingServices.Get_InfoForObject(objInfo, drInfo);
        }
        public DM_CONGTACVIEN Get_Info_dm_congtacvien(string macongtacvien)
        {
            DataTable dt = Data_dm_congtacvien(macongtacvien);
            DM_CONGTACVIEN obj = new DM_CONGTACVIEN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_congtacvien(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_congtacvien(string macongtacvien)
        {
            return Data_dm_congtacvien(macongtacvien).Rows.Count > 0;
        }
        #endregion
        #region dm_sinhly
        public int Insert_dm_sinhly(DM_SINHLY objInfo)
        {
            if (CheckExists_dm_sinhly(objInfo.Masinhly)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaSinhLy", objInfo.Masinhly),
                        WorkingServices.GetParaFromOject("@TenSinhLy", objInfo.Tensinhly),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_sinhly", para);
        }
        public int Update_dm_sinhly(DM_SINHLY objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaSinhLy", objInfo.Masinhly),
                        WorkingServices.GetParaFromOject("@TenSinhLy", objInfo.Tensinhly)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_sinhly", para);
        }
        public int Delete_dm_sinhly(string masinhly)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaSinhLy", masinhly)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_sinhly", para);
        }
        public DataTable Data_dm_sinhly(string masinhly)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaSinhLy", masinhly)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_sinhly", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_SINHLY Get_Info_dm_sinhly(DataRow drInfo)
        {
            return (DM_SINHLY)WorkingServices.Get_InfoForObject(new DM_SINHLY(), drInfo);
        }
        public DM_SINHLY Get_Info_dm_sinhly(string masinhly)
        {
            DataTable dt = Data_dm_sinhly(masinhly);
            DM_SINHLY obj = new DM_SINHLY();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_sinhly(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_sinhly(string masinhly)
        {
            return Data_dm_sinhly(masinhly).Rows.Count > 0;
        }
        #endregion
        #region DanhSachMayXetNghiem
        public DataTable Data_DanhSachMayXetNghiem()
        {
            var sqlPara = new SqlParameter[]
                   {
                    WorkingServices.GetParaFromOject("@withEmpty", false)
                    , WorkingServices.GetParaFromOject("@withZero", false)
                    , WorkingServices.GetParaFromOject("@loaiMay", -1)
                   };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_MayXN", sqlPara);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion
        #region dm_congty
        public int Insert_dm_congty(DM_CONGTY objInfo)
        {
            if (CheckExists_dm_congty(objInfo.Macongty)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTy", objInfo.Macongty),
                        WorkingServices.GetParaFromOject("@TenCongTy", objInfo.Tencongty),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_congty", para);
        }
        public int Update_dm_congty(DM_CONGTY objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTy", objInfo.Macongty),
                        WorkingServices.GetParaFromOject("@TenCongTy", objInfo.Tencongty)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_congty", para);
        }
        public int Delete_dm_congty(string macongty)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTy", macongty)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_congty", para);
        }
        public DataTable Data_dm_congty(string macongty)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaCongTy", macongty)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_congty", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_CONGTY Get_Info_dm_congty(DataRow drInfo)
        {
            return (DM_CONGTY)WorkingServices.Get_InfoForObject(new DM_CONGTY(), drInfo);
        }
        public DM_CONGTY Get_Info_dm_congty(string macongty)
        {
            DataTable dt = Data_dm_congty(macongty);
            DM_CONGTY obj = new DM_CONGTY();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_congty(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_congty(string macongty)
        {
            return Data_dm_congty(macongty).Rows.Count > 0;
        }

        #endregion
        #region dm_khayluumau
        public int Insert_dm_khayluumau(DM_KHAYLUUMAU objInfo)
        {
            if (CheckExists_dm_khayluumau(objInfo.Makhayluumau)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhayLuuMau", objInfo.Makhayluumau),
                        WorkingServices.GetParaFromOject("@MaTuLuu", objInfo.Matuluu),
                        WorkingServices.GetParaFromOject("@TenKhaiLuuMau", objInfo.Tenkhailuumau),
                        WorkingServices.GetParaFromOject("@KichThuocNgang", objInfo.Kichthuocngang),
                        WorkingServices.GetParaFromOject("@KichThuocDoc", objInfo.Kichthuocdoc),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_khayluumau", para);
        }
        public int Update_dm_khayluumau(DM_KHAYLUUMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhayLuuMau", objInfo.Makhayluumau),
                        WorkingServices.GetParaFromOject("@MaTuLuu", objInfo.Matuluu),
                        WorkingServices.GetParaFromOject("@TenKhaiLuuMau", objInfo.Tenkhailuumau),
                        WorkingServices.GetParaFromOject("@KichThuocNgang", objInfo.Kichthuocngang),
                        WorkingServices.GetParaFromOject("@KichThuocDoc", objInfo.Kichthuocdoc)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_khayluumau", para);
        }
        public int Delete_dm_khayluumau(string makhayluumau)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhayLuuMau", makhayluumau)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_khayluumau", para);
        }
        public DataTable Data_dm_khayluumau(string matuluumau, string makhayluumau)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTuLuuMau", matuluumau),
                        WorkingServices.GetParaFromOject("@MaKhayLuuMau", makhayluumau)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_khayluumau", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_KHAYLUUMAU Get_Info_dm_khayluumau(DataRow drInfo)
        {
            return (DM_KHAYLUUMAU)WorkingServices.Get_InfoForObject(new DM_KHAYLUUMAU(), drInfo);
        }
        public DM_KHAYLUUMAU Get_Info_dm_khayluumau(string makhayluumau)
        {
            DataTable dt = Data_dm_khayluumau(string.Empty, makhayluumau);
            DM_KHAYLUUMAU obj = new DM_KHAYLUUMAU();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_khayluumau(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_khayluumau(string makhayluumau)
        {
            return Data_dm_khayluumau(string.Empty, makhayluumau).Rows.Count > 0;
        }
        #endregion
        #region dm_tuluumau
        public int Insert_dm_tuluumau(DM_TULUUMAU objInfo)
        {
            if (CheckExists_dm_tuluumau(objInfo.Matuluu)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTuLuu", objInfo.Matuluu),
                        WorkingServices.GetParaFromOject("@TenTuLuu", objInfo.Tentuluu),
                        WorkingServices.GetParaFromOject("@HangCungCap", objInfo.Hangcungcap),
                        WorkingServices.GetParaFromOject("@KhoaXetNghiem", objInfo.Khoaxetnghiem),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_tuluumau", para);
        }
        public int Update_dm_tuluumau(DM_TULUUMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTuLuu", objInfo.Matuluu),
                        WorkingServices.GetParaFromOject("@TenTuLuu", objInfo.Tentuluu),
                        WorkingServices.GetParaFromOject("@HangCungCap", objInfo.Hangcungcap),
                        WorkingServices.GetParaFromOject("@KhoaXetNghiem", objInfo.Khoaxetnghiem)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_tuluumau", para);
        }
        public int Delete_dm_tuluumau(string matuluu)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTuLuu", matuluu)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_tuluumau", para);
        }
        public DataTable Data_dm_tuluumau(string matuluu)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTuLuu", matuluu)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_tuluumau", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_TULUUMAU Get_Info_dm_tuluumau(DataRow drInfo)
        {
            return (DM_TULUUMAU)WorkingServices.Get_InfoForObject(new DM_TULUUMAU(), drInfo);
        }
        public DM_TULUUMAU Get_Info_dm_tuluumau(string matuluu)
        {
            DataTable dt = Data_dm_tuluumau(matuluu);
            DM_TULUUMAU obj = new DM_TULUUMAU();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_tuluumau(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_tuluumau(string matuluu)
        {
            return Data_dm_tuluumau(matuluu).Rows.Count > 0;
        }

        #endregion
        #region dm_khuvuc_xnkhongthuchien
        public int Insert_dm_khuvuc_xnkhongthuchien(DM_KHUVUC_XNKHONGTHUCHIEN objInfo)
        {
            if (CheckExists_dm_khuvuc_xnkhongthuchien(objInfo.Makhuvuc, objInfo.Maxn, objInfo.Makhuvucnhan)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", objInfo.Makhuvuc),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaKhuVucNhan", objInfo.Makhuvucnhan),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                        WorkingServices.GetParaFromOject("@PcNhap", objInfo.Pcnhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_khuvuc_xnkhongthuchien", para);
        }
        public int Update_dm_khuvuc_xnkhongthuchien(DM_KHUVUC_XNKHONGTHUCHIEN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", objInfo.Makhuvuc),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaKhuVucNhan", objInfo.Makhuvucnhan),
                        WorkingServices.GetParaFromOject("@PcNhap", objInfo.Pcnhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_khuvuc_xnkhongthuchien", para);
        }
        public int Delete_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan, string Nguoixoa, string Pcxoa)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", makhuvuc),
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                        WorkingServices.GetParaFromOject("@MaKhuVucNhan", makhuvucnhan),
                        WorkingServices.GetParaFromOject("@Nguoixoa", Nguoixoa),
                        WorkingServices.GetParaFromOject("@Pcxoa", Pcxoa)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_khuvuc_xnkhongthuchien", para);

        }
        public DataTable Data_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", makhuvuc),
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                        WorkingServices.GetParaFromOject("@MaKhuVucNhan", makhuvucnhan)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_khuvuc_xnkhongthuchien", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_KHUVUC_XNKHONGTHUCHIEN Get_Info_dm_khuvuc_xnkhongthuchien(DataRow drInfo)
        {
            return (DM_KHUVUC_XNKHONGTHUCHIEN)WorkingServices.Get_InfoForObject(new DM_KHUVUC_XNKHONGTHUCHIEN(), drInfo);
        }
        public DM_KHUVUC_XNKHONGTHUCHIEN Get_Info_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan)
        {
            DataTable dt = Data_dm_khuvuc_xnkhongthuchien(makhuvuc, maxn, makhuvucnhan);
            DM_KHUVUC_XNKHONGTHUCHIEN obj = new DM_KHUVUC_XNKHONGTHUCHIEN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_khuvuc_xnkhongthuchien(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_khuvuc_xnkhongthuchien(string makhuvuc, string maxn, string makhuvucnhan)
        {
            return Data_dm_khuvuc_xnkhongthuchien(makhuvuc, maxn, makhuvucnhan).Rows.Count > 0;
        }

        #endregion

        #region DM diễn giải
        public DataSet DanhMuc_Gen_ChaCon()
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_Gen_ChaCon");
            if (ds == null) return null;
            return ds;
        }
        public int Insert_dm_diengiaketquagen(DM_DIENGIAKETQUAGEN objInfo)
        {
            if (CheckExists_dm_diengiaketquagen(objInfo.Id)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaXnThamGia", objInfo.Maxnthamgia),
                        WorkingServices.GetParaFromOject("@NguoiTao", objInfo.Nguoitao),
                        WorkingServices.GetParaFromOject("@GiaiThich", objInfo.Giaithich),
                        WorkingServices.GetParaFromOject("@TuVan", objInfo.Tuvan),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@TaiLieuThamKhao", objInfo.Tailieuthamkhao),
                        WorkingServices.GetParaFromOject("@Gioihan", objInfo.Gioihan),
                        WorkingServices.GetParaFromOject("@Loai", objInfo.Loai),
                        WorkingServices.GetParaFromOject("@GhiChuDienGiai", objInfo.Ghichudiengiai),
                        WorkingServices.GetParaFromOject("@HinhDienGiai1", objInfo.Hinhdiengiai1, isImage: true),
                        WorkingServices.GetParaFromOject("@HinhDienGiai2", objInfo.Hinhdiengiai2, isImage: true)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_diengiaketquagen", para);
        }
        public int Update_dm_diengiaketquagen(DM_DIENGIAKETQUAGEN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", objInfo.Id),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaXnThamGia", objInfo.Maxnthamgia),
                        WorkingServices.GetParaFromOject("@NguoiSua", objInfo.Nguoisua),
                        WorkingServices.GetParaFromOject("@GiaiThich", objInfo.Giaithich),
                        WorkingServices.GetParaFromOject("@TuVan", objInfo.Tuvan),
                        WorkingServices.GetParaFromOject("@PhuongPhap", objInfo.Phuongphap),
                        WorkingServices.GetParaFromOject("@TaiLieuThamKhao", objInfo.Tailieuthamkhao),
                        WorkingServices.GetParaFromOject("@Gioihan", objInfo.Gioihan),
                        WorkingServices.GetParaFromOject("@Loai", objInfo.Loai),
                        WorkingServices.GetParaFromOject("@GhiChuDienGiai", objInfo.Ghichudiengiai),
                        WorkingServices.GetParaFromOject("@HinhDienGiai1", objInfo.Hinhdiengiai1, isImage: true),
                        WorkingServices.GetParaFromOject("@HinhDienGiai2", objInfo.Hinhdiengiai2, isImage: true)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_dm_diengiaketquagen", para);
        }
        public int Delete_dm_diengiaketquagen(int id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_diengiaketquagen", para);
        }
        public DataTable Data_dm_diengiaketquagen(int? id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_diengiaketquagen", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable Data_dm_diengiaketquagen_theoxetnghiem(string maXn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", maXn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_diengiaketquagen_theoxetnghiem", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_DIENGIAKETQUAGEN Get_Info_dm_diengiaketquagen(DataRow drInfo)
        {
            return (DM_DIENGIAKETQUAGEN)WorkingServices.Get_InfoForObject(new DM_DIENGIAKETQUAGEN(), drInfo);
        }
        public DM_DIENGIAKETQUAGEN Get_Info_dm_diengiaketquagen(int id)
        {
            DataTable dt = Data_dm_diengiaketquagen(id);
            DM_DIENGIAKETQUAGEN obj = new DM_DIENGIAKETQUAGEN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_diengiaketquagen(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_diengiaketquagen(int id)
        {
            return Data_dm_diengiaketquagen(id).Rows.Count > 0;
        }
        #endregion
    }
}