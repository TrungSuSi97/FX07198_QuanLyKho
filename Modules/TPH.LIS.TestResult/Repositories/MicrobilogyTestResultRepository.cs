using System;
using System.Data;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Constants;
using System.Data.SqlClient;
using System.Text;
using TPH.Common.Converter;
using TPH.LIS.Common.Model;
using DevExpress.XtraPrinting;

namespace TPH.LIS.Patient.Repositories
{
    public class MicrobilogyTestResultRepository : IMicrobiologyTestResultRepository
    {
        public bool Update_ketqua_cls_xetnghiem_visinh_kqViSinh(string maTiepNhan, string maYeuCau
            , string userUpdate, string ketQua
            , bool ghiLog, string ghiChu, string loaiMauNhan)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@MaTiepNhan", maTiepNhan)
                , new SqlParameter("@MaYeuCau",maYeuCau)
                , new SqlParameter("@userUpdate", userUpdate)
                , new SqlParameter("@KetQua", ketQua)
                , new SqlParameter("@GhiLog", ghiLog)
                , new SqlParameter("@GhiChu", ghiChu)
                , new SqlParameter("@LoaiMauNhan", loaiMauNhan)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_KetQua", sqlPara) > -1;
        }

        public bool Update_Ketqua_Cls_XetNghiem_ViSinh_LoaiMauNhan(string loaiMauNhan, string maTiepNhan, string maYeuCau, string nguoinhap, bool ghiLog)
        {
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@MaTiepNhan", maTiepNhan)
                , new SqlParameter("@MaYeuCau",maYeuCau)
                , new SqlParameter("@userUpdate", nguoinhap)
                , new SqlParameter("@LoaiMauNhan", loaiMauNhan)
                , new SqlParameter("@GhiLog", ghiLog)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_LoaiMauNhan", sqlPara) > -1;
        }
        public int Update_ketqua_cls_xetnghiem_visinh_XacNhan(string maTiepNhan, string lstMaYeuCau, string userUpdate, bool XacNhan
            , bool xacNhanDe, bool kiemTraUser, string PCValid
           )
        {
            var sqlPara = new SqlParameter[]
                  {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                , WorkingServices.GetParaFromOject("@MaYeuCau",lstMaYeuCau)
                , WorkingServices.GetParaFromOject("@XacNhan", XacNhan?"1":"0")
                , WorkingServices.GetParaFromOject("@NguoiXacNhan", userUpdate)
                , WorkingServices.GetParaFromOject("@XacNhanDe", xacNhanDe?"1":"0")
                , WorkingServices.GetParaFromOject("@CheckUserOverwrite", kiemTraUser?"1":"0")
                , WorkingServices.GetParaFromOject("@PCValid", PCValid)
                  };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_ChiDinh_XacNhanKetQua", sqlPara);
        }
        public bool Update_ketqua_cls_xetnghiem_visinh_yeucau_DaIn(string userIn, string maTiepNhan
            , string maYeuCau, bool daIn, string chuKy, bool xacNhanKhiIn)
        {
            var sqlPara = new SqlParameter[]
                   {
                        new SqlParameter("@MaTiepNhan", maTiepNhan)
                        , new SqlParameter("@MaYeuCau",maYeuCau)
                        , new SqlParameter("@DaIn", daIn)
                        , new SqlParameter("@NguoiIn", userIn)
                        , new SqlParameter("@KyTen", chuKy)
                        , new SqlParameter("@XacNhanKhiIn", xacNhanKhiIn)
                   };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_ChiDinh_DaInKetQua", sqlPara) > -1;
        }
        public bool Delete_ketqua_cls_xetnghiem_visinh(string maTiepNhan, string maYeuCau)
        {
            if (Delete_ViKhuan(maTiepNhan, maYeuCau, string.Empty))
            {
                string strSql = "Delete ketqua_cls_xetnghiem_visinh";
                strSql += string.Format("\nwhere  Matiepnhan = '{0}'", maTiepNhan);
                if (!string.IsNullOrEmpty(maYeuCau))
                    strSql += string.Format("\n and MaYeuCau = '{0}'", maYeuCau);
                if (DataProvider.ExecuteQuery(strSql))
                    return DataProvider.ExecuteQuery("Delete BenhNhan_CLS_XetNghiem where MaTiepNhan ='" + maTiepNhan + "' and (select count (*) from KetQua_CLS_XetNghiem where  MaTiepNhan ='" + maTiepNhan + "') = 0 and (select count (*) from ketqua_cls_xetnghiem_visinh where  MaTiepNhan ='" + maTiepNhan + "') = 0");
                else
                    return false;

            }
            else
                return false;
        }
        public DataTable Data_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau
            , bool checkDaLayMau, bool checkDaNhanMau)
        {
            var sqlPara = new SqlParameter[]
                   {
                        new SqlParameter("@MaTiepNhan", matiepnhan)
                        , new SqlParameter("@MaYeuCau",mayeucau)
                        , new SqlParameter("@CheckDaLayMau", checkDaLayMau)
                        , new SqlParameter("@CheckDaNhanMau", checkDaNhanMau)
                   };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_KetQua", sqlPara);
            if (ds != null)
                return ds.Tables[0];

            return null;
        }
        public DataTable Data_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau
       , bool checkDaLayMau, bool checkDaNhanMau, string lstMaNhomPhanQuyen)
        {
            var sqlPara = new SqlParameter[]
                   {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                        , WorkingServices.GetParaFromOject("@MaYeuCau",mayeucau)
                        , WorkingServices.GetParaFromOject("@CheckDaLayMau", checkDaLayMau)
                        , WorkingServices.GetParaFromOject("@CheckDaNhanMau", checkDaNhanMau)
                        , WorkingServices.GetParaFromOject("@LstMaNhomPhanQuyen", lstMaNhomPhanQuyen)

                   };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_KetQua", sqlPara);
            if (ds != null)
                return ds.Tables[0];

            return null;
        }
        public KETQUA_CLS_XETNGHIEM_VISINH Get_Info_ketqua_cls_xetnghiem_visinh(DataRow drInfo)
        {
            var obj = (KETQUA_CLS_XETNGHIEM_VISINH)WorkingServices.Get_InfoForObject(new KETQUA_CLS_XETNGHIEM_VISINH(), drInfo);
            
            return obj;
        }
        public KETQUA_CLS_XETNGHIEM_VISINH Get_Info_ketqua_cls_xetnghiem_visinh(string matiepnhan, string mayeucau)
        {
            DataTable dt = Data_ketqua_cls_xetnghiem_visinh(matiepnhan, mayeucau, false, false);
            KETQUA_CLS_XETNGHIEM_VISINH obj = new KETQUA_CLS_XETNGHIEM_VISINH();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_ketqua_cls_xetnghiem_visinh(dt.Rows[0]);
            }
            return obj;
        }
        public void Search_DanhSachViSinh(DateTime dtDateFrom, DateTime dtDateTo, string serviceId, string patientName, string seq, bool fullRsult
            , bool printed, string testId, string category, bool nhapTheoDanhSach, DataGridView dtg, BindingNavigator bv)
        {
            string strSQL = "select distinct cast (0 as bit) as Chon, t.MaTiepNhan, t.Seq, t.TenBN,case when t.GioiTinh = 'm' then N'Nam' when t.GioiTinh = 'f' then N'Nữ' else '' end as GioiTinh,t.Email as EmailBenhNhan,t.ChanDoan,t.DiaChi \n";
            strSQL += ",t.Tuoi,d.LamTieuDe, D.TenDoiTuongDichVu, d.EmailDoiTuongDichVu,T.NgayTiepNhan , t.ThoiGianNhap,MaBN,tx.KetLuanViSinh as KetLuan, tx.DuKQViSinh as DuKQ,tx.DaInKQViSinh as DaIn \n";
            strSQL += "from BenhNhan_TiepNhan t \n";
            strSQL += "inner join BenhNhan_CLS_XetNghiem tx on T.MaTiepNhan = Tx.MatiepNhan \n";
            strSQL += "inner join KETQUA_CLS_XETNGHIEM_VISINH k on t.MaTiepNhan = k.MaTiepNhan \n";
            strSQL += "left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu  as D on t.DoiTuongDichVu = d.MaDoiTuongDichVu \n";
            strSQL += "where t.NgayTiepNhan between '" + dtDateFrom.ToString("yyyy-MM-dd 00:00:00.00") + "' and '" + dtDateTo.ToString("yyyy-MM-dd 00:00:00.00") + "'";
            if (serviceId != "")
            {
                strSQL += " and t.DoiTuongDichVu='" + serviceId.Trim() + "'";
            }
            if (seq != "")
            {
                strSQL += " and t.SEQ = " + seq.Trim();
            }
            if (patientName != "")
            {
                strSQL += " and (t.tenBN like N'%" + patientName.Trim() + "%' or t.tenBN like N'%" + patientName.Trim() + "' or t.tenBN like N'" + patientName.Trim() + "%' or t.tenBN = N'" + patientName.Trim() + "')";
            }
            if (fullRsult)
            {
                strSQL += " and tx.DuKQViSinh = 1";
            }
            if (printed)
            {
                strSQL += " and tx.DaInKQViSinh = 1";
            }
            if (testId != "")
            {
                strSQL += " and k.MaYeuCau = '" + testId + "' \n";
            }
            if (category != "")
            {
                strSQL += " and k.MaNhomYeuCau = '" + category + "' \n";
            }
            if (nhapTheoDanhSach)
                strSQL += "\n and t.NguonNhap ='" + InputSourceEnum.ByList.ToString() + "'";
            ControlExtension.BindDataToGrid(DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0], ref dtg, ref bv);
        }
        public DataTable Get_DanhSachBenhNhanViSinh(DateTime fromDate, DateTime toDate, string maDonVi, string doiTuongDichVu, string maTiepNhan, string hoTen, int DaIn
            , bool checkDaLayMau, bool checkDaNhanMau)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@maTiepNhan",maTiepNhan ),
                new SqlParameter("@fromDate", fromDate.Date),
                new SqlParameter("@toDate",toDate.Date ),
                new SqlParameter("@hoTen",hoTen),
                new SqlParameter("@maDonVi", maDonVi),
                new SqlParameter("@doiTuongDichVu",doiTuongDichVu),
                new SqlParameter("@DaIn", DaIn),
                new SqlParameter("@checkDaLayMau",checkDaLayMau ),
                new SqlParameter("@checkDaNhanMau", checkDaNhanMau )
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_BenhNhan_KQXnViSinh", para).Tables[0];
        }
        private void Insert_Patient_XN(string maTiepNhan)
        {
            if (!DataProvider.CheckExisted("select * from BenhNhan_CLS_XetNghiem(nolock) where MaTiepNhan ='" + maTiepNhan + "'"))
            {
                string _strSQL = "insert into BenhNhan_CLS_XetNghiem (MaTiepNhan) select '" + maTiepNhan + "'";
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
            }
        }
        #region Bacterium
        public bool Insert_ketqua_cls_xetnghiem_vikhuan(string maTiepNhan, string maYeuCau
          , string maPhanLoaiViKhuan, string nguoiNhap, string kyThuat, int lanXetnghiem, string maBoKhangSinh)
        {
            var sqlPara = new SqlParameter[]
                  {
                        new SqlParameter("@MaTiepNhan", maTiepNhan)
                        , new SqlParameter("@MaYeuCau",maYeuCau)
                        , new SqlParameter("@MaPhanLoai", maPhanLoaiViKhuan)
                        , new SqlParameter("@MaPhanLoaiMay", (object)DBNull.Value)
                        , new SqlParameter("@TenPhanLoaiMay", (object)DBNull.Value)
                        , new SqlParameter("@TestKitID", (object)DBNull.Value)
                        , new SqlParameter("@NguoiNhap", nguoiNhap)
                        , new SqlParameter("@idMayXn", 0)
                        , new SqlParameter("@LanXetNghiem", lanXetnghiem)
                        , new SqlParameter("@KyThuat", kyThuat)
                  };
            var sqlParaChecked = new SqlParameter[]
                  {
                        new SqlParameter("@MaTiepNhan", maTiepNhan)
                        , new SqlParameter("@MaYeuCau",maYeuCau)
                        , new SqlParameter("@MaPhanLoai", maPhanLoaiViKhuan)
                        , new SqlParameter("@LanXetNghiem", lanXetnghiem)
                  };
            if (!DataProvider.CheckExisted(CommandType.StoredProcedure, "selViSinh_KetQuaViKhuan", sqlParaChecked))
            {

                if ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_ViKhuan", sqlPara) > -1)
                {
                    DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updViSinh_KetQua_KhaoSat_NgoaiNhiem"
                        , new SqlParameter[] {  WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                        , WorkingServices.GetParaFromOject("@MaYeuCau",maYeuCau)});

                    return Insert_ketqua_xetnghiem_khangsinhdo(maTiepNhan, maYeuCau
                        , maPhanLoaiViKhuan, nguoiNhap, kyThuat, lanXetnghiem, maBoKhangSinh);
                }
                else
                    return false;
            }
            else
            {
                DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updViSinh_KetQua_KhaoSat_NgoaiNhiem"
                        , new SqlParameter[] {  WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                        , WorkingServices.GetParaFromOject("@MaYeuCau",maYeuCau)});
                return Insert_ketqua_xetnghiem_khangsinhdo(maTiepNhan, maYeuCau
                    , maPhanLoaiViKhuan, nguoiNhap, kyThuat, lanXetnghiem, maBoKhangSinh);

            }
        }
        private bool Insert_ketqua_xetnghiem_khangsinhdo(string maTiepNhan, string maYeuCau
              , string maViKhuan, string nguoiNhap, string kyThuat, int lanXetnghiem, string maBoKhangSinh)
        {
            /*
             * @MaTiepNhan varchar (20)
            ,@MaYeuCau varchar (25)
            ,@MaViKhuan varchar(20)
            ,@MaKhangSinh varchar(20)
            ,@MaKhangSinhMay varchar(20)
            ,@TenKhangSinhMay nvarchar(150)
            ,@KetQuaSIR varchar(20)
            ,@KetQuadinhluong varchar(20)
            ,@KyThuat varchar(20)
            ,@NguoiNhap varchar(20)
            ,@TestKitKS varchar(20)
            */
            var sqlPara = new SqlParameter[]
               {
                    new SqlParameter("@MaTiepNhan", maTiepNhan)
                    , new SqlParameter("@MaYeuCau",maYeuCau)
                    , new SqlParameter("@MaViKhuan", maViKhuan)
                    , new SqlParameter("@MaKhangSinh", (object)DBNull.Value)
                    , new SqlParameter("@MaKhangSinhMay", (object)DBNull.Value)
                    , new SqlParameter("@TenKhangSinhMay", (object)DBNull.Value)
                    , new SqlParameter("@KetQuaSIR", (object)DBNull.Value)
                    , new SqlParameter("@KetQuadinhluong", (object)DBNull.Value)
                    , new SqlParameter("@KyThuat", kyThuat)
                    , new SqlParameter("@NguoiNhap", nguoiNhap)
                    , new SqlParameter("@TestKitKS", (object)DBNull.Value)
                    , new SqlParameter("@LanXetNghiem", lanXetnghiem)
                    , new SqlParameter("@MaBoKhangSinh", maBoKhangSinh)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangSinhDo", sqlPara) > -1;
        }
        public bool Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(string matiepNhan, string maYeuCau, string maVikhuan, string maKhangsinh, string kyThuat, string nguoinhap)
        {
            //@MaTiepNhan varchar (20)
            //,@MaYeuCau varchar (25)
            //, @MaViKhuan varchar(20)
            //, @MaKhangSinh varchar(20)
            //, @KyThuat varchar(20)
            //, @NguoiNhap varchar(20)
            var sqlPara = new SqlParameter[]
                {
                    new SqlParameter("@MaTiepNhan", matiepNhan)
                    , new SqlParameter("@MaYeuCau", maYeuCau)
                    , new SqlParameter("@MaViKhuan", maVikhuan)
                    , new SqlParameter("@MaKhangSinh", maKhangsinh)
                    , new SqlParameter("@KyThuat", kyThuat)
                    , new SqlParameter("@NguoiNhap", string.IsNullOrEmpty(nguoinhap) ? (object)DBNull.Value: nguoinhap)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangSinhDo_KhongViKhuan", sqlPara) > -1;
        }
        public bool Update_KetQua_Gram(string maTiepNhan, string maYeuCau, string ketquagram)
        {
            SqlParameter[] para = new SqlParameter[] {
                new SqlParameter("@MaTiepNhan",maTiepNhan)
            ,new SqlParameter("@MaXN",maYeuCau)
            ,new SqlParameter("@KetQuaGram",string.IsNullOrEmpty(ketquagram) ?(object)DBNull.Value:ketquagram  )};
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_ViSinh_Gram", para) > -1;

        }

        public bool Delete_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan)
        {
            if (Delete_KhangSinh(maTiepNhan, maYeuCau, maViKhuan, string.Empty, string.Empty))
            {
                string strSql = string.Format("delete ketqua_cls_xetnghiem_vikhuan where MaTiepNhan = '{0}'", maTiepNhan);
                if (!string.IsNullOrEmpty(maYeuCau))
                    strSql += string.Format("\n and MaYeuCau = '{0}'", maYeuCau);
                if (!string.IsNullOrEmpty(maViKhuan))
                    strSql += string.Format("\n and MaPhanLoai = '{0}'", maViKhuan);
                return DataProvider.ExecuteQuery(strSql);
            }
            else
                return false;
        }
        public bool Delete_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat)
        {
            string strSql = string.Format("delete KETQUA_XETNGHIEM_KHANGSINHDO where MaTiepNhan = '{0}'", maTiepNhan);
            if (!string.IsNullOrEmpty(maYeuCau))
                strSql += string.Format("\n and MaYeuCau = '{0}'", maYeuCau);
            if (!string.IsNullOrEmpty(maViKhuan))
                strSql += string.Format("\n and MaPhanLoai = '{0}'", maViKhuan);
            if (!string.IsNullOrEmpty(maKhangSinh))
                strSql += string.Format("\n and Makhangsinh = '{0}'", maKhangSinh);
            if (!string.IsNullOrEmpty(maKhangSinh))
                strSql += string.Format("\n and KyThuat = '{0}'", kyThuat);
            return DataProvider.ExecuteQuery(strSql);
        }
        public bool Delete_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat, int lanXN, string siteINF)
        {
            string strSql = string.Format("delete KETQUA_XETNGHIEM_KHANGSINHDO where MaTiepNhan = '{0}'", maTiepNhan);
            if (!string.IsNullOrEmpty(maYeuCau))
                strSql += string.Format("\n and MaYeuCau = '{0}'", maYeuCau);
            if (!string.IsNullOrEmpty(maViKhuan))
                strSql += string.Format("\n and MaPhanLoai = '{0}'", maViKhuan);
            if (!string.IsNullOrEmpty(maKhangSinh))
                strSql += string.Format("\n and Makhangsinh = '{0}'", maKhangSinh);
            if (!string.IsNullOrEmpty(maKhangSinh))
                strSql += string.Format("\n and KyThuat = '{0}'", kyThuat);
            if (lanXN > 0)
                strSql += string.Format("\n and LanXetNghiem = {0}", lanXN);
            if (!siteINF.Equals("null"))
                strSql += string.Format("\n and SiteInfection = '{0}'", siteINF);

            return DataProvider.ExecuteQuery(strSql);
        }
        public DataTable Get_DanhSach_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, int lanXetNghiem)
        {
            var sqlPara = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                        WorkingServices.GetParaFromOject("@MaYeuCau", maYeuCau),
                        WorkingServices.GetParaFromOject("@MaPhanLoai", maViKhuan),
                        WorkingServices.GetParaFromOject("@LanXetNghiem", lanXetNghiem)
            };

            var dataSet = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                               , "sel_Ketqua_cls_xetnghiem_vikhuan"
                               , sqlPara);
            if (dataSet != null)
                return dataSet.Tables[0];
            else
                return null;
        }
        public DataTable Get_DanhSach_KhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, int lanXN, string kyThuat)
        {
            var sqlPara = new SqlParameter[]
                         {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@MaYeuCau", maYeuCau)
                    , WorkingServices.GetParaFromOject("@MaPhanLoaiViKhuan", maViKhuan)
                    , WorkingServices.GetParaFromOject("@MaKhangSinh", string.IsNullOrEmpty( maKhangSinh) ? (object)DBNull.Value: maKhangSinh)
                    , WorkingServices.GetParaFromOject("@LanXn", lanXN)
                    , WorkingServices.GetParaFromOject("@KyThuat", kyThuat)
                         };
            var dataSet = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                      , "selXetNghiem_DanhSachKQKhangSinh"
                      , sqlPara);
            if (dataSet != null)
                return dataSet.Tables[0];
            else
                return null;
        }
        public bool Update_KetQuaViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, bool mic, string ketQuaESBL, string KetQuaBetaLactamases)
        {
            string strSql = "update ketqua_cls_xetnghiem_vikhuan set";
            strSql += string.Format("\n[ESBL] = {0}", string.IsNullOrEmpty(ketQuaESBL) ? "0" : "1");
            strSql += string.Format("\n,[MIC] = {0}", mic ? "1" : "0");
            strSql += string.Format("\n,[KetQuaESBL] ={0}", (string.IsNullOrEmpty(ketQuaESBL) ? "NULL" : "N'" + Utilities.ConvertSqlString(ketQuaESBL) + "'"));
            strSql += string.Format("\n,[KetQuaBetaLactamases] ={0}", (string.IsNullOrEmpty(KetQuaBetaLactamases) ? "NULL" : "N'" + Utilities.ConvertSqlString(KetQuaBetaLactamases) + "'"));
            strSql += string.Format("\n,[BetaLactamases] = {0}", (string.IsNullOrEmpty(KetQuaBetaLactamases) ? "0" : "1"));
            strSql += string.Format("\n where MaTiepNhan = '{0}'", maTiepNhan);
            strSql += string.Format("\n and MaYeuCau = '{0}'", maYeuCau);
            strSql += string.Format("\n and MaPhanLoai = '{0}'", maViKhuan);
            return DataProvider.ExecuteQuery(strSql);
        }
        public bool Update_KetQuaKhangSinh(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat
             , string ketQuaSRI, string ketQuaDinhLuong, int coKetQua, string nguoiThucHien, int lanXN, string idCard = "", int idMay = 0
             , string SRI = "", string Site_Infection = "")
        {
            var sqlPara = new[]
                {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                        , WorkingServices.GetParaFromOject("@MaYeuCau", maYeuCau)
                        , WorkingServices.GetParaFromOject("@MaViKhuan", maViKhuan)
                        , WorkingServices.GetParaFromOject("@MaKhangSinh", maKhangSinh)
                        , WorkingServices.GetParaFromOject("@KyThuat", kyThuat)
                        , WorkingServices.GetParaFromOject("@KetQuaSIR", ketQuaSRI)
                        , WorkingServices.GetParaFromOject("@KetQuadinhluong", ketQuaDinhLuong)
                        , WorkingServices.GetParaFromOject("@Flag", coKetQua)
                        , WorkingServices.GetParaFromOject("@NguoiNhap", string.IsNullOrEmpty(nguoiThucHien) ? (object)DBNull.Value : nguoiThucHien)
                        , WorkingServices.GetParaFromOject("@TestKitKS", idCard)
                        , WorkingServices.GetParaFromOject("@idMayXn", idMay)
                        , WorkingServices.GetParaFromOject("@LanXN", lanXN)
                        , WorkingServices.GetParaFromOject("@SRI", SRI)
                        , WorkingServices.GetParaFromOject("@SiteInfection", Site_Infection)
                };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpCapNhat_Ketqua_KhangSinhDo", sqlPara) > -1;
        }
        public int Update_GhiChu_QuyTrinh_PhuongPhap(string maTiepNhan, string maYeuCau, string maViKhuan, string maKhangSinh, string kyThuat
            , string ghiChu, string quyTrinh, string phuongPhap)
        {
            //udpViSinh_ghiChuQuiTrinhPhuongPhap

            var sqlPara = new SqlParameter[]
          {
                    new SqlParameter("@MaTiepNhan", maTiepNhan)
                    , new SqlParameter("@MaYeuCau",maYeuCau)
                    , new SqlParameter("@MaViKhuan", maViKhuan)
                    , new SqlParameter("@MaKhangSinh", maKhangSinh)
                    , new SqlParameter("@KyThuat", kyThuat)
                    , new SqlParameter("@GhiChu", ghiChu)
                    , new SqlParameter("@QuyTrinh", quyTrinh)
                     , new SqlParameter("@PhuongPhap", phuongPhap)
          };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_ghiChuQuiTrinhPhuongPhap", sqlPara);
        }
        #endregion
        #region Ket qua dai the
        public bool Insert_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Matiepnhan",objInfo.Matiepnhan),
                WorkingServices.GetParaFromOject("@Mayeucau",objInfo.Mayeucau),
                WorkingServices.GetParaFromOject("@Makhaosat",objInfo.Makhaosat)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insViSinh_KetQua_KhaoSat", sqlPara) > 0;
        }
        public bool Update_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            var sqlPara = new SqlParameter[]
                 {
                    WorkingServices.GetParaFromOject("@Matiepnhan",objInfo.Matiepnhan),
                    WorkingServices.GetParaFromOject("@Mayeucau",objInfo.Mayeucau),
                    WorkingServices.GetParaFromOject("@Makhaosat",objInfo.Makhaosat),
                    WorkingServices.GetParaFromOject("@Ketquakhaosat",objInfo.Ketquakhaosat),
                    WorkingServices.GetParaFromOject("@NguoiThucHien", objInfo.Nguoisuaketqua)
                 };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updViSinh_KetQua_KhaoSat", sqlPara) > 0;
        }

        public bool Delete_ketqua_cls_xetnghiem_khaosatdaithe(KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Matiepnhan",objInfo.Matiepnhan),
                WorkingServices.GetParaFromOject("@Mayeucau",objInfo.Mayeucau),
                WorkingServices.GetParaFromOject("@Makhaosat",objInfo.Makhaosat)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delViSinh_KetQua_KhaoSat", sqlPara) > 0;
        }
        private string SQLSelect_Data_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string Mayeucau)
        {
            string sqlQuery = "select * from ketqua_cls_xetnghiem_khaosatdaithe where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                sqlQuery += "\n and  matiepnhan = '" + matiepnhan + "'";
            if (!string.IsNullOrEmpty(Mayeucau))
                sqlQuery += "\n and Mayeucau = '" + Mayeucau + "'";
            if (!string.IsNullOrEmpty(makhaosat))
                sqlQuery += "\n and  makhaosat = '" + makhaosat + "'";
            return sqlQuery;
        }
        public DataTable Data_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string Mayeucau)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_ketqua_cls_xetnghiem_khaosatdaithe(matiepnhan, makhaosat, Mayeucau)).Tables[0];
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem_khaosatdaithe(DataGridView dtg, BindingNavigator bv, string matiepnhan, string makhaosat, string Mayeucau)
        {
            DataTable dtData = new DataTable();
            dtData = Data_ketqua_cls_xetnghiem_khaosatdaithe(matiepnhan, makhaosat, Mayeucau);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE Get_Info_ketqua_cls_xetnghiem_khaosatdaithe(string matiepnhan, string makhaosat, string Mayeucau)
        {
            DataTable dt = Data_ketqua_cls_xetnghiem_khaosatdaithe(matiepnhan, makhaosat, Mayeucau);
            KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE obj = new KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE();
            if (dt.Rows.Count > 0)
            {
                obj = (KETQUA_CLS_XETNGHIEM_KHAOSATDAITHE)WorkingServices.Get_InfoForObject(obj, dt.Rows[0]);
            }
            return obj;
        }
        #endregion
        #region Du lieu in
        public DataTable DuLieuIn(string maTiepNhan, string maChiDinh, string maViKhuan, bool inKQSoiNhuom, bool inKQNam
      , bool inKQCay, bool inTatCa, string nguoiKy, string kyThuat)
        {
            var sqlPara = new SqlParameter[]
                 {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@inKQSoiNhuom", inKQSoiNhuom?"1":"0")
                    , WorkingServices.GetParaFromOject("@inKQNam", inKQNam ? "1":"0")
                    , WorkingServices.GetParaFromOject("@inKQCay", inKQCay ? "1":"0")
                    , WorkingServices.GetParaFromOject("@inTatCa", inTatCa ? "1":"0")
                    , WorkingServices.GetParaFromOject("@nguoiKy", string.IsNullOrEmpty(nguoiKy) ? (object)DBNull.Value: nguoiKy)
                    , WorkingServices.GetParaFromOject("@maChiDinh", string.IsNullOrEmpty(maChiDinh) ? (object)DBNull.Value: maChiDinh)
                    , WorkingServices.GetParaFromOject("@maViKhuan", string.IsNullOrEmpty(maViKhuan) ? (object)DBNull.Value: maViKhuan)
                     , WorkingServices.GetParaFromOject("@kyThuat", string.IsNullOrEmpty(kyThuat) ? (object)DBNull.Value: kyThuat)
                 };
            var dataSet = DataProvider.ExecuteDataset(CommandType.StoredProcedure
               , "selKetQuaXetNghiem_ViSinh"
               , sqlPara);
            if (dataSet != null)
                return dataSet.Tables[0];
            else
                return null;
        }
        #endregion
        #region ketqua_cls_xetnghiem_visinh_khangkhangsinh
        public BaseModel Insert_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo)
        {
            var para = new SqlParameter[]
                   {
                        new SqlParameter("@MaTiepNhan",objInfo.Matiepnhan)
                        ,new SqlParameter("@MaYeuCau",objInfo.Mayeucau)
                        ,new SqlParameter("@MaPhanLoai",objInfo.Maphanloai)
                        ,new SqlParameter("@Makhangkhangsinh",objInfo.Makhangkhangsinh)
                        ,new SqlParameter("@Ketqua",objInfo.Ketqua),new SqlParameter("@Ketquachu",objInfo.Ketquachu)
                        ,new SqlParameter("@Nguoinhap",objInfo.Nguoinhap)
                   };

            if (!DataProvider.CheckExisted("select top 1 * from ketqua_cls_xetnghiem_visinh_khangkhangsinh where Matiepnhan = '" + Utilities.ConvertSqlString(objInfo.Matiepnhan.ToString()) + "' and Mayeucau = '" + Utilities.ConvertSqlString(objInfo.Mayeucau.ToString()) + "' and Maphanloai = '" + Utilities.ConvertSqlString(objInfo.Maphanloai.ToString()) + "' and Makhangkhangsinh = '" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangKhangSinh", para),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Cơ chế kháng kháng sinh đã nhập trước."
                };
            }
        }
        public bool Update_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo)
        {
            var para = new SqlParameter[]
          {
                        new SqlParameter("@MaTiepNhan",objInfo.Matiepnhan)
                        ,new SqlParameter("@MaYeuCau",objInfo.Mayeucau)
                        ,new SqlParameter("@MaPhanLoai",objInfo.Maphanloai)
                        ,new SqlParameter("@Makhangkhangsinh",objInfo.Makhangkhangsinh)
                        ,new SqlParameter("@Ketqua",objInfo.Ketqua)
                        ,new SqlParameter("@Ketquachu",objInfo.Ketquachu)
                        ,new SqlParameter("@Nguoisua",objInfo.Nguoisua)
          };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_KhangKhangSinh", para) > -1;
        }
        public bool Delete_ketqua_cls_xetnghiem_visinh_khangkhangsinh(KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete ketqua_cls_xetnghiem_visinh_khangkhangsinh");
            sb.AppendFormat("\n where Matiepnhan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Matiepnhan.ToString()) + "'");
            sb.AppendFormat("\n and Mayeucau = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mayeucau.ToString()) + "'");
            sb.AppendFormat("\n and Maphanloai = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maphanloai.ToString()) + "'");
            sb.AppendFormat("\n and Makhangkhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'");

            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ketqua_cls_xetnghiem_visinh_khangkhangsinh where 1=1");
            if (!string.IsNullOrEmpty(matiepnhan))
                sb.AppendFormat("\n and  matiepnhan = {0}", "'" + matiepnhan + "'");
            if (!string.IsNullOrEmpty(mayeucau))
                sb.AppendFormat("\n and  mayeucau = {0}", "'" + mayeucau + "'");
            if (!string.IsNullOrEmpty(maphanloai))
                sb.AppendFormat("\n and  maphanloai = {0}", "'" + maphanloai + "'");
            if (!string.IsNullOrEmpty(makhangkhangsinh))
                sb.AppendFormat("\n and  makhangkhangsinh = {0}", "'" + makhangkhangsinh + "'");
            return sb.ToString();
        }
        public DataTable Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(matiepnhan, mayeucau, maphanloai, makhangkhangsinh)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(DataGridView dtg, BindingNavigator bv, string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(matiepnhan, mayeucau, maphanloai, makhangkhangsinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH Get_Info_ketqua_cls_xetnghiem_visinh_khangkhangsinh(string matiepnhan, string mayeucau, string maphanloai, string makhangkhangsinh)
        {
            DataTable dt = Data_ketqua_cls_xetnghiem_visinh_khangkhangsinh(matiepnhan, mayeucau, maphanloai, makhangkhangsinh);
            KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH obj = new KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH();
            if (dt.Rows.Count > 0)
            {
                obj = (KETQUA_CLS_XETNGHIEM_VISINH_KHANGKHANGSINH)WorkingServices.Get_InfoForObject(obj, dt.Rows[0]);
            }
            return obj;
        }
        public bool Insert_ketqua_cls_xetnghiem_vikhuan_amtinh(string maTiepNhan, string maYeuCau,
      string maPhanLoaiViKhuan
      , string nguoiNhap, string kyThuat, int lanXetnghiem)
        {
            var sqlParaChecked = new[]
                {
                        new SqlParameter("@MaTiepNhan", maTiepNhan)
                        , new SqlParameter("@MaYeuCau",maYeuCau)
                        , new SqlParameter("@MaPhanLoai", maPhanLoaiViKhuan)
                        , new SqlParameter("@LanXetNghiem", lanXetnghiem)
                };
            var sqlPara = new[]
                {
                        new SqlParameter("@MaTiepNhan", maTiepNhan)
                        , new SqlParameter("@MaYeuCau",maYeuCau)
                        , new SqlParameter("@MaPhanLoai", maPhanLoaiViKhuan)
                        , new SqlParameter("@MaPhanLoaiMay", (object)DBNull.Value)
                        , new SqlParameter("@TenPhanLoaiMay", (object)DBNull.Value)
                        , new SqlParameter("@TestKitID", (object)DBNull.Value)
                        , new SqlParameter("@NguoiNhap", nguoiNhap)
                        , new SqlParameter("@idMayXn", 0)
                        , new SqlParameter("@LanXetNghiem", lanXetnghiem)
                        , new SqlParameter("@KyThuat", kyThuat)
                };
            if (!DataProvider.CheckExisted(CommandType.StoredProcedure, "selViSinh_KetQuaViKhuan", sqlParaChecked))
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_ViKhuan", sqlPara) > 0;
            //Nếu không insert được trả về false
            return false;
        }

        public bool Insert_Ketqua_xetnghiem_khangsinhdo_khongvikhuan(string matiepNhan, string maYeuCau
           , string maVikhuan, string maKhangsinh, string kyThuat, string nguoinhap, int lanXN)
        {
            //@MaTiepNhan varchar (20)
            //,@MaYeuCau varchar (25)
            //, @MaViKhuan varchar(20)
            //, @MaKhangSinh varchar(20)
            //, @KyThuat varchar(20)
            //, @NguoiNhap varchar(20)
            var sqlPara = new SqlParameter[]
                {
                    new SqlParameter("@MaTiepNhan", matiepNhan)
                    , new SqlParameter("@MaYeuCau", maYeuCau)
                    , new SqlParameter("@MaViKhuan", maVikhuan)
                    , new SqlParameter("@MaKhangSinh", maKhangsinh)
                    , new SqlParameter("@KyThuat", kyThuat)
                    , new SqlParameter("@NguoiNhap", string.IsNullOrEmpty(nguoinhap) ? (object)DBNull.Value: nguoinhap)
                    , new SqlParameter("@LanXetNghiem", lanXN)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_KhangSinhDo_KhongViKhuan", sqlPara) > -1;
        }

        public bool Check_Existed_dm_xetnghiem_khangsinh_bo_chitiet(string maBoKhangSinh, string maViKhuan,
        string kyThuat)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT TOP 1 * FROM {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem_khangsinh_bo_chitiet WHERE MaBoKhangSinh = N'{0}' AND MaViKhuan= N'{1}' AND KyThuat = N'{2}'", maBoKhangSinh, maViKhuan, kyThuat);
            return DataProvider.CheckExisted(sb.ToString());
        }
        public DataTable DanhSach_TheDinhDanh(string maTiepNhan, string maYeuCau)
        {
            var sqlPara = new SqlParameter[]
                  {
                     WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@MaYeuCau", maYeuCau)

                  };
            var dataSet = DataProvider.ExecuteDataset(CommandType.StoredProcedure
               , "selXetNghiem_ViSinh_TheDinhDanh"
               , sqlPara);
            if (dataSet != null)
                return dataSet.Tables[0];
            else
                return null;
        }
        public bool CapNhat_MauViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, string maMau, int lanXN)
        {
            var sqlPara = new SqlParameter[]
            {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@MaYeuCau", maYeuCau)
                    , WorkingServices.GetParaFromOject("@MaViKhuan", maViKhuan)
                    , WorkingServices.GetParaFromOject("@Mau", maMau)
                    , WorkingServices.GetParaFromOject("@LanXetNghiem", lanXN)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_ViSinh_MauViKhuan", sqlPara) > -1;
        }
        public bool CapNhat_GhiChu_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, string ghiChu, string nguoiNhap, int lanXN)
        {
            var sqlPara = new SqlParameter[]
                        {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@MaYeuCau", maYeuCau)
                    , WorkingServices.GetParaFromOject("@MaPhanLoai", maViKhuan)
                    , WorkingServices.GetParaFromOject("@GhiChu", ghiChu)
                    , WorkingServices.GetParaFromOject("@NguoiNhapGhiChu", nguoiNhap)
                    , WorkingServices.GetParaFromOject("@LanXetNghiem", lanXN)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updViSinh_ViKhuan_GhiChu", sqlPara) > -1;
        }
        public int CapNhat_ThongTinMayXN_ViKhuan(string maTiepNhan, string maYeuCau, string maViKhuan, int idMayXn, int lanXetNghiem = 1)
        {

            var para = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                    ,WorkingServices.GetParaFromOject("@MaYeuCau",maYeuCau)
                    ,WorkingServices.GetParaFromOject("@MaViKhuan",maViKhuan)
                    ,WorkingServices.GetParaFromOject("@IdMayXn",idMayXn )
                    ,WorkingServices.GetParaFromOject("@LanXN", lanXetNghiem)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_ViSinh_ThongTinMay_ViKhuan", para);
        }
        public int CapNhat_ThongTinQuyTrinh_LoaiMau(string maTiepNhan, string maYeuCau, int idMayXn)
        {

            var para = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                    ,WorkingServices.GetParaFromOject("@MaYeuCau",maYeuCau)
                    ,WorkingServices.GetParaFromOject("@QuyTrinh",(object)DBNull.Value)
                    ,WorkingServices.GetParaFromOject("@IdMayXn",idMayXn )
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_ViSinh_QuyTrinh", para);
        }
        #endregion
        #region Phiếu tiến trình

        public bool Insert_Update_ViSinh_PhieuTienTrinh(string maTiepNhan, string maXN, string maSoMau, string nguoiThucHien
            , DateTime thoiGianThucHien, string noiDung, string nguoiSua, int AutoID = -100)
        {
            //Có ID thì cho sửa
            if (AutoID > 0)
            {
                var sqlupd = new[] {
                    WorkingServices.GetParaFromOject("@AutoID", AutoID),
                    WorkingServices.GetParaFromOject("@nguoiThucHien", nguoiThucHien),
                    WorkingServices.GetParaFromOject("@thoiGianThucHien", thoiGianThucHien),
                    WorkingServices.GetParaFromOject("@noiDung", noiDung),
                    WorkingServices.GetParaFromOject("@nguoiSua", nguoiSua)
                };
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ViSinh_upd_PhieuTienTrinh", sqlupd) > 0;
            }
            else
            {
                var sqlIns = new[] {
                WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@maXN", maXN),
                WorkingServices.GetParaFromOject("@maSoMau", maSoMau),
                WorkingServices.GetParaFromOject("@nguoiThucHien", nguoiThucHien),
                WorkingServices.GetParaFromOject("@thoiGianThucHien", thoiGianThucHien),
                WorkingServices.GetParaFromOject("@noiDung", noiDung)};
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ViSinh_ins_PhieuTienTrinh", sqlIns) > 0;
            }
        }

        public DataTable Get_PhieuTienTrinh(string maTiepNhan, string maYeuCau, string maSoMau)
        {
            var sqlQuery = new[] {
                WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@maXN", maYeuCau),
                WorkingServices.GetParaFromOject("@maSoMau", maSoMau)};
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "ViSinh_sel_PhieuTienTrinh", sqlQuery).Tables[0];
        }
        public bool Delete_PhieuTienTrinh(string ids)
        {
            var sqlPara = new SqlParameter[] { WorkingServices.GetParaFromOject("@AutoID", ids) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ViSinh_del_PhieuTienTrinh", sqlPara) > 0;
        }
        public DataTable DuLieuInPhieuTienTrinh(string maTiepNhan, bool inTieuDe, string maSoMau)
        {
            var sqlPara = new SqlParameter[]
                {
                    new SqlParameter("@MaTiepNhan", maTiepNhan)
                    , new SqlParameter("@InTieuDe", inTieuDe ? "1" : "0")
                    ,new SqlParameter("@MaSoMau",maSoMau)
                };
            var dataSet = DataProvider.ExecuteDataset(CommandType.StoredProcedure
               , "ViSinh_selKetQuaXetNghiem_PhieuTienTrinh"
               , sqlPara);
            if (dataSet != null)
                return dataSet.Tables[0];
            else
                return null;
        }
        public DataTable Data_ketqua_cls_xetnghiem_visinh_phieutientrinh(string matiepnhan, string mayeucau
          , bool checkDaLayMau, bool checkDaNhanMau)
        {
            var sqlPara = new SqlParameter[]
                   {
                        new SqlParameter("@MaTiepNhan", matiepnhan)
                        , new SqlParameter("@MaYeuCau",mayeucau)
                        , new SqlParameter("@CheckDaLayMau", checkDaLayMau)
                        , new SqlParameter("@CheckDaNhanMau", checkDaNhanMau)
                   };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_KetQua_PhieuTienTrinh", sqlPara);
            if (ds != null)
                return ds.Tables[0];

            return null;
        }
        #endregion
    }
}
