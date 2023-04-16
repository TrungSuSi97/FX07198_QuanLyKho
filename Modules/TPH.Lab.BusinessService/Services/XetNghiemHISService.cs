namespace TPH.Lab.BusinessService.Services
{
    using Data;
    using Data.Configuration;
    using LIS.Common.Extensions;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    public class XetNghiemHISService : BaseService<XetNghiemHISService>
    {
        private List<XetNghiemHISInfo> mappingData = new List<XetNghiemHISInfo>();
        private Dictionary<string, XetNghiemInfo> mappingDataLISTestCode = new Dictionary<string, XetNghiemInfo>();
        private bool isInitializedMappingTest = false;
        private bool isInitialized2 = false;
        private DataTable dataAll = new DataTable();
        public List<XetNghiemHISInfo> GetListHisMapping_All()
        {
            WriteLog.LogService.RecordLogFileFormat("Load danh mục lên thư viện: ", "ALL");
            var result = new List<XetNghiemHISInfo>();

            var conn = SqlDbConfigurationBase.GetConnection();
            using (SqlCommand commmand = new SqlCommand("selDanhMuc_XnHis", conn))
            {
                commmand.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        XetNghiemHISInfo info = new XetNghiemHISInfo();
                        info.isprofile = GetDbReaderValue<bool>(reader["isprofile"]);
                        info.id = GetDbReaderValue<int>(reader["id"]);
                        info.madichvu = GetDbReaderValue<string>(reader["madichvu2"]);
                        info.macaptren = GetDbReaderValue<string>(reader["macaptren"]);
                        info.maxn = GetDbReaderValue<string>(reader["MaXn"]);
                        info.tendichvu = GetDbReaderValue<string>(reader["tendichvu"]);
                        info.loaidvHIS = GetDbReaderValue<string>(reader["loaixn"]);
                        info.nhomxn = GetDbReaderValue<string>(reader["nhomxn"]);
                        info.maprofile = GetDbReaderValue<string>(reader["lis_profileid"]);
                        info.thongsocon = GetDbReaderValue<string>(reader["thongsocon"]);
                        info.HisProviderID = GetDbReaderValue<int>(reader["HisProviderID"]);
                        info.LoaiXetNghiem = GetDbReaderValue<int>(reader["LoaiXetNghiem"]);
                        info.NguoiNhap = GetDbReaderValue<string>(reader["NguoiNhap"]);
                        info.TgNhap = GetDbReaderValue<DateTime?>(reader["TGNhap"]);
                        result.Add(info);
                    }
                    //  reader.Close();
                }
            }
            return result;
        }
        public DataTable GetData_HisMapping_All(bool refresh)
        {
            if (!isInitialized2 || refresh)
            {
                var conn = SqlDbConfigurationBase.GetConnection();

                dataAll = SqlDb.ExecuteDataset(conn, CommandType.StoredProcedure, "selDanhMuc_XnHis").Tables[0];

                isInitialized2 = true;
            }
            return dataAll;
        }
        private List<XetNghiemInfo> GetAllDataXN()
        {
            var result = new List<XetNghiemInfo>();

            var conn = SqlDbConfigurationBase.GetConnection();
            using (SqlCommand commmand = new SqlCommand("selDanhMuc_XetNghiem_Profile", conn))
            {
                commmand.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        XetNghiemInfo info = new XetNghiemInfo();
                        info.maxn = GetDbReaderValue<string>(reader["MaXN"]);
                        result.Add(info);
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public void LoadDictionaryDMXetNghiem()
        {
            if (mappingDataLISTestCode != null)
                mappingDataLISTestCode.Clear();
            var listData = GetAllDataXN();

            foreach (var item in listData)
            {
                if (mappingDataLISTestCode != null)
                {
                    if (!mappingDataLISTestCode.ContainsKey(item.maxn))
                    {
                        mappingDataLISTestCode.Add(item.maxn, item);
                    }
                }
            }
            isInitialized2 = true;
        }
        public void LoadDictionaryMappingTest()
        {
            if (mappingData != null)
                mappingData.Clear();
            mappingData = GetListHisMapping_All();
            isInitializedMappingTest = true;
        }

        private void CheckInitializedMapping(bool refresh)
        {
            if (!isInitializedMappingTest || refresh)
            {
                LoadDictionaryMappingTest();
            }
        }
        private void CheckInitializedDMXetNghiem()
        {
            if (!isInitialized2)
            {
                LoadDictionaryDMXetNghiem();
            }
        }
        public XetNghiemInfo GetMappingXN(string maxn)
        {
            CheckInitializedDMXetNghiem();
            if (mappingDataLISTestCode.Keys.Where(x => x.Equals(maxn)).Any())
            {
                var result = mappingDataLISTestCode[maxn];
                return result;
            }
            else
            {
                isInitialized2 = false;
                CheckInitializedDMXetNghiem();
                if (mappingDataLISTestCode.Keys.Where(x => x.Equals(maxn)).Any())
                {
                    var result = mappingDataLISTestCode[maxn];
                    return result;
                }
                else
                    return null;
            }
        }
        public XetNghiemHISInfo GetMapping(string madichvu, int hisProviderID, bool refresh)
        {
            CheckInitializedMapping(refresh);
            var result = mappingData.Where(x => (string.IsNullOrEmpty(x.madichvu) ? false : x.madichvu.Trim().Equals(madichvu, StringComparison.OrdinalIgnoreCase)) && x.HisProviderID == hisProviderID);
            if (result != null)
            {
                if (result.Count() > 0)
                {
                    return result.First();
                }
            }
            return null;
        }
        public void SyncXetNghiem(XetNghiemHISInfo info)
        {
            WriteLog.LogService.RecordLogFileFormat("Đồng bộ xét nghiệm HIS: Mã dịch vụ: {0}", info.madichvu);

            var conn = SqlDbConfigurationBase.GetConnection();
            SqlDb.ExecuteNonQuery(
                 conn, CommandType.StoredProcedure, "InsUpdSync_DMXetNghiem_HIS",
                 new SqlParameter[]
                 {
                    new SqlParameter("@tendichvu", info.tendichvu),
                    new SqlParameter("@donvitinh", info.donvitinh),
                    new SqlParameter("@macaptren", info.macaptren),
                    new SqlParameter("@madichvu", info.madichvu),
                    new SqlParameter("@loaixn", info.loaidvHIS),
                    new SqlParameter("@HisProviderID", info.HisProviderID)
                 });

            LoadDictionaryMappingTest();
        }
        public void UpdateMappingXetNghiem(XetNghiemMapping objInfo)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            SqlDb.ExecuteNonQuery(
                 conn, CommandType.StoredProcedure, "upd_DMXetNghiem_HIS_Mapping",
                new SqlParameter[]{WorkingServices.GetParaFromOject("@MaxnLIS", objInfo.Maxnlis),
                WorkingServices.GetParaFromOject("@MaprofileLIS", objInfo.Maprofilelis),
                WorkingServices.GetParaFromOject("@IsProfile", objInfo.Isprofile),
                WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap),
                WorkingServices.GetParaFromOject("@thongsocon", objInfo.Thongsocon),
                WorkingServices.GetParaFromOject("@madichvu", objInfo.Madichvu),
                WorkingServices.GetParaFromOject("@HisProviderID", objInfo.Hisproviderid)});
        }
    }
}
