namespace TPH.Lab.Middleware.HISConnect.DataAccesses
{
    using System.Data;
    using Data.HIS.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class GetHISDataAccess_DaiHocCanTho : IGetHISDataAccess_DaiHocCanTho
    {
        private IGetHISDataAccessBase _iHisAccessBase = new GetHISDataAccessBase();
        public HISDataColumnNames GetHisColumnNameConfiguartion(HisConnection hisConnect, List<HISDataColumnNames> hisColumns)
        {
            var function = from item in hisColumns
                           where item.HisID == hisConnect.HisID
                           select item;
            if (function != null)
                return function.FirstOrDefault();
            return null;
        }
        public DataTable DanhMucBacSi(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucBacSi(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucChanDoan(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucChanDoan(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucDoiTuong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucDoiTuong(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucKhoaPhong(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucKhoaPhong(hisConnect, hisFunction, null);
        }
        public DataTable DanhMucXetNghiem(HisConnection hisConnect, List<HisFunctionConfig> hisFunction)
        {
            return _iHisAccessBase.DanhMucXetNghiem(hisConnect, hisFunction, null);
        }
        public DataTable GetPatientOrderedList(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientOrderedList(hisConnect, hisFunction, paraInfo);
        }
        public DataTable GetPatientOrderedDetail(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, HisParaGetList paraInfo)
        {
            return _iHisAccessBase.GetPatientOrderedDetail(hisConnect, hisFunction, paraInfo);
        }
        public int LISCheck(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisParaGetList> paraInfoList)
        {
            return _iHisAccessBase.LISCheck(hisConnect, hisFunction, paraInfoList);
        }
        public int TransferResultToHIS(HisConnection hisConnect, List<HisFunctionConfig> hisFunction, List<HisResultBase> paraInfoList)
        {
            return _iHisAccessBase.TransferResultToHIS(hisConnect, hisFunction, paraInfoList);
        }

        /*
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly HISStoreProcedure factory = ObjectHelper<HISStoreProcedure>.GetObjectFacroty();

        /// <summary>
        /// LISCheck
        /// </summary>
        /// <param name="info">[sp_LIS_Check]  @SoPhieuYeuCau as varchar(20), @MaDichVu varchar(50),  @stt int, @DaLayMau Tinyint</param>
        /// <returns>int</returns>
        public int LISCheck(DaiHocCanTho_OrderInfo info)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            int i = 0;
            if(!string.IsNullOrEmpty(factory.StoreLISCheck))
            {
                if (info.OrderTest.Count > 0)
                {
                    foreach (var item in info.OrderTest)
                    {
                        //[sp_LIS_Check]  @SoPhieuYeuCau as varchar(20), @MaDichVu varchar(50),  @stt int, @DaLayMau Tinyint
                        WriteLog.LogService.RecordLogFileFormat("Gọi store [exec {0} @SoPhieuYeuCau='{1}',@MaDichVu='{2}',@stt={3},@DaLayMau={4}] xác nhận lấy chỉ định",
                            factory.StoreLISCheck, info.SoPhieuYeuCau, item.TestCode, item.OrderNumber, item.SampleGetted);
                        i = SqlDb.ExecuteNonQuery
                         (
                             conn, CommandType.StoredProcedure, factory.StoreLISCheck,
                             new SqlParameter[]
                             {
                            new SqlParameter("@SoPhieuYeuCau", info.SoPhieuYeuCau),
                            new SqlParameter("@MaDichVu", item.TestCode),
                            new SqlParameter("@stt", item.OrderNumber),
                            new SqlParameter("@DaLayMau", item.SampleGetted)
                             }
                         );

                        if (i > 0)
                        {
                            WriteLog.LogService.RecordLogFileFormat("Cập nhật xác nhận LIS đã lấy chỉ định: {0}", i);
                        }
                        else
                        {
                            WriteLog.LogService.RecordLogFileFormat("Không có thông tin HIS cập nhật LIS lấy chỉ định");
                        }
                    }
                }
            }

            return i;
        }
        public DataTable LISOrderList(DaiHocCanTho_OrderInfo info)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            //exec sp_LIS_Order @SoPhieuYeuCau as varchar(20),@ngaychidinh datetime
            WriteLog.LogService.RecordLogFileFormat("Gọi store [exec {0} @tungay='{1:yyyy-MM-dd}',@denngay='{2:yyyy-MM-dd}', @trangthai = {3}] lấy danh sách chờ xét nghiệm từ HIS",
                factory.StoreLISOrderList, info.OrderDate, info.OrderDateTo, info.LisGetStatus);
            DataSet ds = SqlDb.ExecuteDataset
             (
                 conn, CommandType.StoredProcedure, factory.StoreLISOrderList,
                 new SqlParameter[]
                 {
                    new SqlParameter("@tungay", info.OrderDate.Date),
                    new SqlParameter("@denngay", info.OrderDateTo.Date),
                    new SqlParameter("@trangthai", info.LisGetStatus)
                 }
             );

            if (ds.Tables.Count > 0)
            {
                WriteLog.LogService.RecordLogFileFormat("Có dữ liệu danh sách chờ từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count);
                return ds.Tables[0];
            }
            else
            {
                WriteLog.LogService.RecordLogFileFormat("Không có dữ liệu danh sách chờ từ HIS trả về");
                return null;
            }
        }
        /// <summary>
        /// LISOrder
        /// </summary>
        /// <param name="info">exec sp_LIS_Order @SoPhieuYeuCau as varchar(20),@ngaychidinh datetime</param>
        /// <returns>DataTable</returns>
        public DataTable LISOrder(DaiHocCanTho_OrderInfo info)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            var selectedStoreProcedure = (info.InternalPatient ? factory.StoreLISOrderNoiTru : factory.StoreLISOrder);
            //exec sp_LIS_Order @SoPhieuYeuCau as varchar(20),@ngaychidinh datetime
            WriteLog.LogService.RecordLogFileFormat("Gọi store [exec {0} @SoPhieu='{1}'] lấy chỉ định từ HIS",
                selectedStoreProcedure, info.SoPhieuYeuCau);
            DataSet ds = SqlDb.ExecuteDataset
             (
                 conn, CommandType.StoredProcedure, selectedStoreProcedure,
                 new SqlParameter[]
                 {
                    new SqlParameter("@SoPhieu", info.SoPhieuYeuCau)
                 }
             );

            if (ds.Tables.Count > 0)
            {
                WriteLog.LogService.RecordLogFileFormat("Có dữ liệu chỉ định xét nghiệm từ HIS trả về, tổng cộng là: {0} records", ds.Tables[0].Rows.Count);
                return ds.Tables[0];
            }
            else
            {
                WriteLog.LogService.RecordLogFileFormat("Không có dữ liệu chỉ định xét nghiệm từ HIS trả về");
                return null;
            }
        }
        /// <summary>
        /// LISResult
        /// </summary>
        /// <param name="info">[sp_LIS_Result]  @SoPhieuYeuCau as varchar(17), @MaDichVu varchar(50), @KetQua varchar(30),@ChiSoBinhThuong varchar(50),@BatThuong bit, @stt tinyint,@KLChung nvarchar(1000), @User nvarchar (50), @upd bit,@sopKq nvarchar(50)</param>
        /// <returns>int</returns>
        public int LISResult(DaiHocCanTho_OrderInfo info)
        {
            var conn = SqlDbConfigurationBase.GetConnection();
            int i = 0;
            if (info.resultInfo.Count > 0)
            {
                foreach (var item in info.resultInfo)
                {
                    //[sp_LIS_Result]  @SoPhieuYeuCau as varchar(17), @iddichvuchidinh varchar(50), @MaDichVu varchar(50), @KetQua varchar(30),
                    //@ChiSoBinhThuong varchar(50),@BatThuong bit, @stt tinyint,@KLChung nvarchar(1000), @User nvarchar (50), @upd bit,@sopKq nvarchar(50)

                    WriteLog.LogService.RecordLogFileFormat("Thực thi insert kết quả về HIS:" +
                        "insert into KetQuaXetNghiem (" +
                        "CLS_SOPHIEU, CLS_CHIDINH_ID, CLS_CHIDINH_CHITIET_CLS_ID, BANGKE_ID" +
                        ", BANGKE_CHIPHI_ID, IDBENH, IDNHOMCHUCNANGCLS, IDLOAICHUCNANGCLS, CLS_TENLOAICLS" +
                        ", CLS_KQ_NGAYLAP, IDNHOMNOIDUNGCLS, IDNOIDUNGCLS, KETQUA1, KETQUA2, KETQUA3, CreatedDate)" +

                        "select @KetQuaXetNghiemId = {0}, @CLS_SOPHIEU= {1}, @CLS_CHIDINH_ID= {2}, @CLS_CHIDINH_CHITIET_CLS_ID= {3}, @BANGKE_ID= {4}" +
                        ", @BANGKE_CHIPHI_ID= {5}, @IDBENH= {6}, @IDNHOMCHUCNANGCLS= {7}, @IDLOAICHUCNANGCLS= {8}, @CLS_TENLOAICLS= {9}" +
                        ", @CLS_KQ_NGAYLAP= {10}, @IDNHOMNOIDUNGCLS= {11}, @IDNOIDUNGCLS= {12}, @KETQUA1= {13}, @KETQUA2= {14}, @KETQUA3= {15}, @CreatedDate = {16}"
                        
                        , "Tự động", item.CLS_SOPHIEU, item.CLS_CHIDINH_ID, item.CLS_CHIDINH_CHITIET_CLS_ID, item.BANGKE_ID
                        , item.BANGKE_CHIPHI_ID, item.IDBENH, item.IDNHOMCHUCNANGCLS, item.IDLOAICHUCNANGCLS, item.CLS_TENLOAICLS
                        , item.CLS_KQ_NGAYLAP.ToString("yyyy-MM-dd HH:mm:ss"), "(select top 1 IDNHOMNOIDUNGCLS from QLBN_DM_CLS_NOIDUNG where IDNOIDUNGCLS = @IDNOIDUNGCLS)", item.IDNOIDUNGCLS, item.KETQUA1, item.KETQUA2, item.KETQUA3, item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"));

                    i = SqlDb.ExecuteNonQuery
                     (
                         conn, CommandType.Text, factory.StoreLISResult,
                         new SqlParameter[]
                         {
                            new SqlParameter("@CLS_SOPHIEU", item.CLS_SOPHIEU),
                            new SqlParameter("@CLS_CHIDINH_ID", item.CLS_CHIDINH_ID),
                            new SqlParameter("@CLS_CHIDINH_CHITIET_CLS_ID", item.CLS_CHIDINH_CHITIET_CLS_ID),
                            new SqlParameter("@BANGKE_ID", item.BANGKE_ID),
                            new SqlParameter("@BANGKE_CHIPHI_ID", item.BANGKE_CHIPHI_ID),
                            new SqlParameter("@IDBENH", item.IDBENH),
                            new SqlParameter("@IDNHOMCHUCNANGCLS", item.IDNHOMCHUCNANGCLS),
                            new SqlParameter("@IDLOAICHUCNANGCLS", item.IDLOAICHUCNANGCLS),
                            new SqlParameter("@CLS_TENLOAICLS", item.CLS_TENLOAICLS),
                            new SqlParameter("@CLS_KQ_NGAYLAP", item.CLS_KQ_NGAYLAP.ToString("yyyy-MM-dd HH:mm:ss")),
                            new SqlParameter("@IDNOIDUNGCLS", item.IDNOIDUNGCLS),
                            new SqlParameter("@KETQUA1", item.KETQUA1),
                            new SqlParameter("@KETQUA2", item.KETQUA2),
                            new SqlParameter("@KETQUA3", item.KETQUA3),
                            new SqlParameter("@CreatedDate", item.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"))
                         }
                     );

                    if (i > 0)
                    {
                        WriteLog.LogService.RecordLogFileFormat("HIS lưu kết quả LIS đầy lên thành công: {0}", i);
                    }
                    else
                    {
                        WriteLog.LogService.RecordLogFileFormat("Không có giá trị nào được lưu");
                    }
                }
            }
            return i;
        }
        */
    }
}
