using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Log.Model;

namespace TPH.LIS.Log.Repositories.WorkingLog
{
    public class WorkingLogRepository : IWorkingLogRepository
    {
        #region Thông tin bệnh nhân

        public object WriteLog_BenhNhan_TiepNhan(LogActionId actionId, string userAction, string maTiepNhan)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            return CallWriteLog(LogTableIds.Benhnhan_tiepnhan, actionId, userAction, condition,
                "Nhật ký dữ liệu thông tin tiếp nhận");
        }

        public object WriteLog_BenhNhan_CLS_XetNghiem(LogActionId actionId, string userAction, string maTiepNhan)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            return CallWriteLog(LogTableIds.Benhnhan_cls_xetnghiem.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu thông tin tiếp nhận xét nghiệm");
        }

        public object WriteLog_BenhNhan_CLS_SieuAm(LogActionId actionId, string userAction, string maTiepNhan)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            return CallWriteLog(LogTableIds.Benhnhan_cls_sieuam.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu thông tin tiếp nhận siêu âm");
        }

        public object WriteLog_BenhNhan_CLS_NoiSoi(LogActionId actionId, string userAction, string maTiepNhan)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            return CallWriteLog(LogTableIds.Benhnhan_cls_noisoi.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu thông tin tiếp nhận nội sôi");
        }

        public object WriteLog_BenhNhan_CLS_XQuang(LogActionId actionId, string userAction, string maTiepNhan)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            return CallWriteLog(LogTableIds.Benhnhan_cls_xquang.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu thông tin tiếp nhận X Quang");
        }

        public object WriteLog_BenhNhan_CLS_DVKhac(LogActionId actionId, string userAction, string maTiepNhan)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            return CallWriteLog(LogTableIds.Benhnnhan_cls_dvkhac.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu thông tin tiếp nhận Dịch vụ khác");
        }

        #endregion

        #region Kết quả + chỉ định CLS

        public object WriteLog_KetQua_CLS_XetNghiem(LogActionId actionId, string userAction, string maTiepNhan,
            List<string> maxetNghiem, string maProfile, List<NewValue> lstNewValue = null)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            if (maxetNghiem.Count > 0)
            {
                var mxnInlist = Utilities.ConvertStrinArryToInClauseSQL(maxetNghiem, true);
                if (!string.IsNullOrEmpty(mxnInlist))
                {
                    condition += string.Format("\n and (MaXN in ({0}) or (macaptren is not null and macaptren in (select x2.maxn_his from KetQua_CLS_XetNghiem x2 where x2.MaTiepNhan = '{1}' and x2.MaXN in ({0})))) ", mxnInlist, maTiepNhan);
                }
            }
            if (!string.IsNullOrEmpty(maProfile))
                condition += string.Format("\n and ProfileID = '{0}'", maProfile);

            return CallWriteLog(LogTableIds.Ketqua_cls_xetnghiem.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu chỉ định xét nghiệm", lstNewValue, maTiepNhan, (maxetNghiem == null ? string.Empty : string.Join(",", maxetNghiem)));
        }
        public object WriteLog_KetQua_CLS_XetNghiem_KetQua(LogActionId actionId, string userAction, string maTiepNhan,
        string maxetNghiem, List<NewValue> lstNewValue = null)
        {
            var strNewValue = string.Empty;
            if (lstNewValue != null)
                strNewValue = ConvertListNewToString(lstNewValue);
            var sqlPara = new SqlParameter[]
         {
                new SqlParameter("@HanhDongID", ((actionId == LogActionId.AllAction)?(object)DBNull.Value: actionId.ToString()))
                , new SqlParameter("@NguoiThuchien",string.IsNullOrEmpty(userAction)?(object)DBNull.Value: userAction)
                , new SqlParameter("@MaTiepNhan", maTiepNhan)
                , new SqlParameter("@MaDichVu", maxetNghiem)
                , new SqlParameter("@NewValue", string.IsNullOrEmpty(strNewValue)?(object)DBNull.Value: strNewValue)
         };

            return DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_GhiNhatKy_KetQuaXN", sqlPara);
        }
        public object WriteLog_KetQua_CLS_SieuAm(LogActionId actionId, string userAction, string maTiepNhan,
            string maSoMau)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            if (!string.IsNullOrEmpty(maSoMau))
                condition += string.Format("and MaSoMau = '{0}'", maSoMau);

            return CallWriteLog(LogTableIds.Ketqua_cls_sieuam.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu chỉ định siêu âm");
        }
        public object WriteLog_p_payment(LogActionId actionId, string userAction, string maTiepNhan,
        string maSoMau)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);

            return CallWriteLog(LogTableIds.p_payment.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu p_payment");
        }

        public object WriteLog_KetQua_CLS_NoiSoi(LogActionId actionId, string userAction, string maTiepNhan,
            string maSoMauNoiSoi)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            if (!string.IsNullOrEmpty(maSoMauNoiSoi))
                condition += string.Format("and MaSoMauNoiSoi = '{0}'", maSoMauNoiSoi);

            return CallWriteLog(LogTableIds.Benhnhan_cls_noisoi.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu chỉ định nội soi");
        }

        public object WriteLog_KetQua_CLS_XQuang(LogActionId actionId, string userAction, string maTiepNhan,
            string maKyThuatChup, string maVungChup)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            if (!string.IsNullOrEmpty(maKyThuatChup))
                condition += string.Format("and MaKyThuatChup = '{0}'", maKyThuatChup);
            if (!string.IsNullOrEmpty(maVungChup))
                condition += string.Format("and MaSoMauNoiSoi = '{0}'", maVungChup);

            return CallWriteLog(LogTableIds.Ketqua_cls_xquang.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu chỉ định X Quang");
        }

        public object WriteLog_KetQua_CLS_DVKhac(LogActionId actionId, string userAction, string maTiepNhan,
            string maDvKhac, string maVungChup)
        {
            string condition = string.Format("  MaTiepNhan = '{0}' ", maTiepNhan);
            if (!string.IsNullOrEmpty(maDvKhac))
                condition += string.Format("and MaDVKhac = '{0}'", maDvKhac);

            return CallWriteLog(LogTableIds.Ketqua_cls_dvkhac.ToString(), actionId, userAction, condition,
                "Nhật ký dữ liệu chỉ định dịch vụ khác");
        }
        public int WriteLog_KetQua_XetNghiem_Duyet(string maTiepNhan, string barcode, string soHoSo, string maBn, List<NhatKy_DuyetKetQua_ChiTiet> lstlog)
        {
            var xmlString = WorkingServices.ObjectToXMLGeneric(lstlog);

            var sqlPara = new SqlParameter[]
                     {
                         new SqlParameter("@MaTiepNhan", maTiepNhan)
                       , new SqlParameter("@Barcode", (string.IsNullOrEmpty(barcode)?(object)DBNull.Value: barcode))
                       , new SqlParameter("@SoHoSo", (string.IsNullOrEmpty(soHoSo)?(object)DBNull.Value: soHoSo))
                       , new SqlParameter("@MaBenhNhan", (string.IsNullOrEmpty(maBn)?(object)DBNull.Value: maBn))
                       , new SqlParameter("@NoiDung", xmlString)
                     };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insNhatKy_DuyetKetQua", sqlPara);
        }
        #endregion
        #region Kết quả máy xét nghiệm - thay đổi SID
        public int WriteLog_ChangeInstrumentSid(string fromSid, string toSid, DateTime fromDate, DateTime toDate, string userAction)
        {
            string excuteSql = "insert {{TPH_Standard}}_Analyzer.dbo.h_ketquamay_ChangeLog (TuNgayXN,TuSID,Maxn, Idmay,ThanhNgayXN,ThanhSID, UserID)";
            excuteSql += string.Format("\nselect NgayXN, SID ,Maxn, Idmay,'{0}','{1}','{2}' from {{TPH_Standard}}_Analyzer.dbo.h_ketquamay  where NgayXN = '{3}' and SID = '{4}'"
                , toDate.ToString("yyyy-MM-dd"), toSid, userAction, fromDate.ToString("yyyy-MM-dd"), fromSid);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, excuteSql);
        }
        public object WriteLog_DanhMucMapping_XetNghiem(LogActionId actionId, string userAction, string maXn, string idMayXN)
        {
            string condition = string.Format("  MaXn = '{0}' ", maXn);
            if (!string.IsNullOrEmpty(idMayXN))
                condition += string.Format(" and idmay = '{0}' ", idMayXN);
            return CallWriteLog(LogTableIds.H_bangmamayxn.ToString(), actionId, userAction, condition,
                "Nhật ký mapping mã máy");
        }
        #endregion
        #region Ghi nhật ký đăng nhập
        public int WriteLog_Login(string userAction)
        {
            string condition = string.Format("  MaNguoiDung = '{0}' ", userAction);
            return (int)CallWriteLog(LogTableIds.Ql_nguoidung.ToString(), LogActionId.LoginIn, userAction, condition, "Đăng nhập hệ thống");
        }
        #endregion
        private object CallWriteLog(string tableId, LogActionId actionId, string userAction, string condition,
            string desription, List<NewValue> lstNewValue = null, string matiepNhan = "", string maDichVu = "")
        {
            var strNewValue = string.Empty;
            if (lstNewValue != null)
                strNewValue = ConvertListNewToString(lstNewValue);

            var sqlPara = new SqlParameter[]
         {
             new SqlParameter("@NhatKyID", tableId)
                , new SqlParameter("@HanhDongID", ((actionId == LogActionId.AllAction)?(object)DBNull.Value: actionId.ToString()))
                , new SqlParameter("@NguoiThuchien",string.IsNullOrEmpty(userAction)?(object)DBNull.Value: userAction)
                , new SqlParameter("@DieuKien", string.IsNullOrEmpty(condition)?(object)DBNull.Value: condition)
                , new SqlParameter("@MoTa", string.IsNullOrEmpty(desription)?(object)DBNull.Value: desription)
                , new SqlParameter("@NewValue", string.IsNullOrEmpty(strNewValue)?(object)DBNull.Value: strNewValue)
                , new SqlParameter("@MaTiepNhan", string.IsNullOrEmpty(matiepNhan)?(object)DBNull.Value:matiepNhan)
                , new SqlParameter("@MaDichVu", string.IsNullOrEmpty(maDichVu)?(object)DBNull.Value: maDichVu)
         };

            return DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "sp_ghinhatky", sqlPara);
        }
        #region Log in kết quả
        public int NhatKy_InKetQua(string matiepNhan, string BSKyTen, string NguoiIn, string NhomXetNghiem, string XnChon
            , int LanIn, string PCThucHien)
        {
           //  @NguoiIn varchar(25)
           //, @BSKyTen varchar(25)
           //, @MaTiepNhan varchar(20) 
           //, @NhomXetNghiem varchar(350)
           //, @XnChon varchar(max)
           //, @LanIn int
           //, @PCThucHien nvarchar(100)
            var sqlPara = new SqlParameter[]
         {
             new SqlParameter("@NguoiIn", NguoiIn)
                , new SqlParameter("@BSKyTen",BSKyTen )
                , new SqlParameter("@MaTiepNhan",matiepNhan)
                , new SqlParameter("@NhomXetNghiem", NhomXetNghiem)
                , new SqlParameter("@XnChon", XnChon)
                , new SqlParameter("@LanIn", LanIn)
                , new SqlParameter("@PCThucHien", PCThucHien)
         };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insNhatKy_InKetQuaXN", sqlPara);
        }
        public DataTable DataNhatKy_InKetQua(string maTiepNhan)
        {
            var sqlPara = new SqlParameter[]
                  {
                      new SqlParameter("@MaTiepNhan",maTiepNhan)
                  };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNhatKy_InKetQuaXN", sqlPara).Tables[0];
        }
        #endregion
        #region Đọc log
        public DataTable ReadLog_List(string tableId, LogActionId actionId, string userAction,
            string desription, DateTime fromDate, DateTime toDate, string matiepnhan)
        {
            //string querySQL = "select * from {{TPH_Standard}}_Log.dbo.hethong_nhatky where " + string.Format(" NhatKyID = '{0}'", tableId);
            //querySQL += string.Format("\n and ThoiGian between '{0}' and '{1}'", fromDate.ToString("yyyy-MM-dd HH:mm:ss"), toDate.ToString("yyyy-MM-dd HH:mm:ss"));
            //if (actionId != LogActionId.AllAction)
            //    querySQL += " and " + string.Format(" HanhDongID = '{0}'", actionId);
            //if (!string.IsNullOrEmpty(userAction))
            //    querySQL += " and " + string.Format(" NguoiThuchien = '{0}'", userAction);
            //if (!string.IsNullOrEmpty(desription))
            //    querySQL += " and " + string.Format(" MoTa  like N'%{0}%'", desription);

            //querySQL += "\nUnion all\n" + querySQL.Replace(" {{TPH_Standard}}_Log.dbo.hethong_nhatky ", " {{TPH_Standard}}_Log.dbo.hethong_nhatky_archive ");

            //@HanhDongID int
            //,@nhatKyID varchar (100)
            //, @mota nvarchar(100)
            //, @fromDate datetime
            //, @toDate datetime

            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@HanhDongID", ((actionId == LogActionId.AllAction)?(object)DBNull.Value: actionId.ToString()))
                , new SqlParameter("@nhatKyID", tableId)
                , new SqlParameter("@userAction",string.IsNullOrEmpty(userAction)?(object)DBNull.Value: userAction)
                , new SqlParameter("@mota", string.IsNullOrEmpty(desription)?(object)DBNull.Value: desription)
                , new SqlParameter("@fromDate", fromDate)
                , new SqlParameter("@toDate", toDate)
                , new SqlParameter("@matiepnhan", matiepnhan)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sp_DocNhatKy", sqlPara).Tables[0];
        }
        public DataTable ReadLog_Detail(string logId)
        {
            // string querySQL = "select * from {{TPH_Standard}}_Log.dbo.hethong_nhatky where " + string.Format(" ID = {0}", logId);
            DataTable dtTemp = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sp_DocNhatKy_ChiTet", new SqlParameter[] {
            new SqlParameter("@ID", long.Parse(logId) )}).Tables[0];
            DataTable dtResult = new DataTable();
            if (dtTemp.Rows.Count > 0)
            {
                var xmlData = dtTemp.Rows[0]["NoiDung"].ToString();
                if (!string.IsNullOrEmpty(xmlData))
                {
                    StringReader theReader = new StringReader(xmlData);
                    DataSet theDataSet = new DataSet();
                    theDataSet.ReadXml(theReader);
                    dtResult = theDataSet.Tables[0];
                }
            }
            return dtResult;
        }
        public DataTable ReadLog_instrumentSid(DateTime actionFromDate, DateTime actionToDate, string testcode,bool isProfile, int inID, string fromSid, string toSid)
        {
            string querySQL = string.Format("select * from {{TPH_Standard}}_Analyzer.dbo.h_ketquamay_ChangeLog where TGDoi between '{0}' and '{1}'", actionFromDate.ToString("yyyy-MM-dd HH:mm:ss"), actionToDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (!string.IsNullOrEmpty(testcode))
            {
                if (isProfile)
                {
                    string.Format("\n and maxn in (select MaXN from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet where ProfileID = '{0}')", testcode);
                }
                else
                querySQL += string.Format("\n and maxn = '{0}'", testcode);
            }
            if (inID > 0)
                querySQL += string.Format("\n and Idmay = '{0}'", inID);
            if (!string.IsNullOrEmpty(testcode))
                querySQL += string.Format("\n and TuSID = '{0}'", fromSid);
            if (!string.IsNullOrEmpty(toSid))
                querySQL += string.Format("\n and ThanhSID = '{0}'", toSid);

            return DataProvider.ExecuteDataset(CommandType.Text, querySQL).Tables[0];
        }
        #endregion

        public string ConvertListNewToString(List<NewValue> lst)
        {
            var lstString = string.Empty;
            foreach (var item in lst)
            {
                lstString += string.IsNullOrEmpty(lstString) ? "" : "^||^";
                lstString += string.Format("{0}|=>|{1}", item.colmnName, item.newValue);
            }
            return lstString;
        }
        public List<NewValue> ConvertStringToNewList(string str)
        {
            var lst = new List<NewValue>();
            var arr = str.Split(new string[] { "^||^" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arr)
            {
                var arrSub = item.Split(new string[] { "|=>|" }, StringSplitOptions.RemoveEmptyEntries);
                if(arrSub.Length ==2)
                {
                    lst.Add(new NewValue
                    {
                        colmnName = arrSub[0]
                        ,
                        newValue = arrSub[1]
                    });
                }
            }
            return lst;
        }
        #region HeThong_NhatKyDanhMuc
        public int Insert_HeThong_NhatKyDanhMuc(HETHONG_NHATKYDANHMUC objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@IdHanhDong", objInfo.Idhanhdong),
                        WorkingServices.GetParaFromOject("@IDNhatKy", objInfo.Idnhatky),
                        WorkingServices.GetParaFromOject("@NguoiThucHien", objInfo.Nguoithuchien),
                        WorkingServices.GetParaFromOject("@PcThucHien", objInfo.Pcthuchien),
                        WorkingServices.GetParaFromOject("@NoiDung", objInfo.Noidung),
                        WorkingServices.GetParaFromOject("@MaDanhMuc", objInfo.Madanhmuc)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_HeThong_NhatKyDanhMuc", para);
        }
        public DataTable Data_HeThong_NhatKyDanhMucById(long id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@Id", id)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_HeThong_NhatKyDanhMuc_ById", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable Data_HeThong_NhatKyDanhMucByDate(DateTime fromdate, DateTime todate, string IDNhatKy)
        {

            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@fromdate",WorkingServices.StartOfDay(fromdate.Date) ),
                        WorkingServices.GetParaFromOject("@todate", WorkingServices.EndOfDay(fromdate.Date)),
                        WorkingServices.GetParaFromOject("@IDNhatKy", IDNhatKy)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_HeThong_NhatKyDanhMuc_ByDate", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable Data_HeThong_NhatKyDanhMucByMaDanhMuc(string MaDanhMuc, string IDNhatKy)
        {
            var para = new SqlParameter[] {
                             WorkingServices.GetParaFromOject("@MaDanhMuc", MaDanhMuc),
                        WorkingServices.GetParaFromOject("@IDNhatKy", IDNhatKy)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_HeThong_NhatKyDanhMuc_ByMaDanhMuc", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        #endregion
    }
}
