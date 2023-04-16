using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TPH.Data.Configuration;
using TPH.Lab.BusinessService.Models;
using TPH.WriteLog;

namespace TPH.Lab.BusinessService.Services
{
    public class HISMappingService : BaseService<HISMappingService>
    {
        private List<HISMapping> lisMapp = new List<HISMapping>();
        private bool isInitialized = false;
        private void CheckInitialized(int HisProviderID, bool forceRefresh)
        {
            if (!isInitialized || forceRefresh || lisMapp == null)
            {
                lisMapp = GetMappingData(HisMappingCategory.All, HisProviderID);
            }
        }
        public List<HISMapping> GetMappingData(HisMappingCategory categoryID, int HisProviderID)
        {
            LogService.RecordLogError("System", "HISMapping", null, 0
        , " Load danh mục mapping", "GetMappingData");
            var result = new List<HISMapping>();
            var conn = SqlDbConfigurationBase.GetConnection();
            using (SqlCommand commmand = new SqlCommand("selDanhSachMappingHIS", conn))
            {
                commmand.CommandType = System.Data.CommandType.StoredProcedure;
                var sqlpara = new SqlParameter[]
              {
                   new SqlParameter("@HisProviderID", HisProviderID)
                   ,new SqlParameter("@CategoryID", (int)categoryID)
              };
                commmand.Parameters.AddRange(sqlpara);
                using (SqlDataReader reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HISMapping info = new HISMapping();
                        info.HISID = GetDbReaderValue<string>(reader["HISID"]);
                        info.LISID = GetDbReaderValue<string>(reader["LISID"]);
                        info.HisProviderID = GetDbReaderValue<int>(reader["HisProviderID"]);
                        info.CategoryID = GetDbReaderValue<int>(reader["CategoryID"]);
                        info.ItemName = GetDbReaderValue<string>(reader["ItemName"]);
                        info.MasterID = GetDbReaderValue<string>(reader["MaCaptren"]);
                        info.NguoiNhap = GetDbReaderValue<string>(reader["NguoiNhap"]);
                        info.TGNhap = GetDbReaderValue<DateTime?>(reader["TGNhap"]);
                        result.Add(info);
                    }
                }
            }
            return result;
        }

        public HISMapping GetAndAutoMapping(HISMapping objCheck, List<HISMapping> lstList)
        {
            var objSearch = lstList.Where(x => x.CategoryID == objCheck.CategoryID && x.HISID == objCheck.HISID);
            if (objSearch != null)
            {
                if (objSearch.Count() > 0)
                {
                    return objSearch.First();
                }
                else
                {
                    return CheckMappingAndSync(objCheck, true);
                }
            }
            else
            {
                return CheckMappingAndSync(objCheck, true);
            }
        }

        public int Insert_Update_MappingData(HISMapping obj)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(obj.HISID) || !string.IsNullOrEmpty(obj.LISID))
            {
                LogService.RecordLogError("System", "HISMapping", null, 0
                , string.Format("[Insert_Update_MappingData] - Đồng bộ mapping HIS: HISID: {0} - ItemName: {1}", obj.HISID, obj.ItemName), "Insert_Update_MappingData");
                //  WriteLog.LogService.RecordLogFileFormat("[Insert_Update_MappingData] - Đồng bộ mapping HIS: HISID: {0} - ItemName: {1}", obj.HISID, obj.ItemName);
                var conn = SqlDbConfigurationBase.GetConnection();
                //InsUpdSync_MappingHis
                var sqlpara = new SqlParameter[]
               {
                   new SqlParameter("@HisProviderID",obj.HisProviderID)
                   ,new SqlParameter("@CategoryID", obj.CategoryID)
                   ,new SqlParameter("@HISID", string.IsNullOrEmpty(obj.HISID) ? (object)DBNull.Value : obj.HISID )
                   ,new SqlParameter("@LisID", string.IsNullOrEmpty(obj.LISID) ? (object)DBNull.Value : obj.LISID )
                   ,new SqlParameter("@itemName", string.IsNullOrEmpty( obj.ItemName) ? (object)DBNull.Value : obj.ItemName )
                   ,new SqlParameter("@MasterID", string.IsNullOrEmpty( obj.MasterID) ? (object)DBNull.Value : obj.MasterID )
                   ,new SqlParameter("@NguoiMapping", string.IsNullOrEmpty( obj.NguoiNhap) ? (object)DBNull.Value : obj.NguoiNhap )
               };

                var command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlpara);
                command.CommandText = "InsUpdSync_MappingHis";

                var i = command.ExecuteNonQuery();

                command.Dispose();

                return i;
            }
            return -1;
        }
        public HISMapping CheckMappingAndSync(HISMapping objCheck, bool forceRefresh)
        {
            LogService.RecordLogError("System", "HISMapping", null, 0
                , string.Format("[CheckMappingAndSync] - Kiểm tra đồng bộ và lấy giá trị LIS: HISID: {0} - ItemName: {1} - CategoryID: {2}", objCheck.HISID, objCheck.ItemName, objCheck.CategoryID), "CheckMappingAndSync");
            //WriteLog.LogService.RecordLogFileFormat("[CheckMappingAndSync] - Kiểm tra đồng bộ và lấy giá trị LIS: HISID: {0} - ItemName: {1}", objCheck.HISID, objCheck.ItemName);
            CheckInitialized(objCheck.HisProviderID, forceRefresh);

            if (lisMapp != null)
            {
                LogService.RecordLogError("System", "HISMapping", null, 0, " lisMapp != null - > Select lisMapp ", "CheckMappingAndSync");
                var returnObj = lisMapp.Where(x => x.CategoryID.Equals(objCheck.CategoryID) 
                && (x.HISID == null ? false : x.HISID.Equals(objCheck.HISID.Trim(), StringComparison.OrdinalIgnoreCase) 
                && x.HisProviderID == objCheck.HisProviderID 
                 ));
                if (returnObj != null)
                {
                    if (returnObj.Count() > 0)
                    {
                        LogService.RecordLogError("System", "HISMapping", null, 0, " returnObj != null - > Select returnObj.First() ", "CheckMappingAndSync");
                        return returnObj.First();
                    }
                    else
                    {
                        LogService.RecordLogError("System", "HISMapping", null, 0, " Danh mục chưa đồng bộ --> Thực hiện đồng bộ", "CheckMappingAndSync");
                        objCheck.LISID = objCheck.HISID;
                        //  _WriteLog.LogService.RecordLogFile(" Danh mục chưa đồng bộ --> Thực hiện đồng bộ");
                        if (Insert_Update_MappingData(objCheck) > -1)
                        {
                            return CheckMappingAndSync(objCheck, true);
                        }
                    }
                }
                else
                {
                    LogService.RecordLogError("System", "HISMapping", null, 0, " Danh mục chưa đồng bộ --> Thực hiện đồng bộ", "CheckMappingAndSync");
                    objCheck.LISID = objCheck.HISID;
                    //  _WriteLog.LogService.RecordLogFile(" Danh mục chưa đồng bộ --> Thực hiện đồng bộ");
                    if (Insert_Update_MappingData(objCheck) > -1)
                    {
                        return CheckMappingAndSync(objCheck, true);
                    }
                }
            }
            return null;
        }
    }
}
