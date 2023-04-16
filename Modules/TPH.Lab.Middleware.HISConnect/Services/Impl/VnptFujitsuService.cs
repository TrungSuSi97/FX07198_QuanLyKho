using System;
using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json.Linq;
using TPH.Common.Converter;
using TPH.Lab.Middleware.HISConnect.Constant;
using TPH.Lab.Middleware.HISConnect.Extensions;
using TPH.Lab.Middleware.HISConnect.Models.Vft;
using TPH.LIS.Common.Model;
using TPH.Data.HIS.Models;
using System.Text;

namespace TPH.Lab.Middleware.HISConnect.Services.Impl
{
    public class VnptFujitsuService : IVnptFujitsuService
    {
        private const string ErrorTokenInvalid = "Lấy token bị lỗi!";
        private const int ItemPerPage = 500;
        public Dictionary<string, dynamic> CreateDictionary(string functionParaNames, string functionParaListMapping, object objPara)
        {
            var paraReturn = new Dictionary<string, dynamic>();
            var arrFuction = functionParaNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var arrMapping = functionParaListMapping.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (objPara != null)
            {
                if (arrFuction.Length == arrMapping.Length)
                {
                    PropertyInfo[] fiCheck = objPara.GetType().GetProperties();
                    for (int i = 0; i < arrFuction.Length; i++)
                    {
                        var value = objPara.GetType().GetProperty(arrMapping[i]).GetValue(objPara, null);
                        if (value != null)
                            paraReturn.Add(arrFuction[i], value);
                    }
                    return paraReturn;
                }
            }
            return paraReturn;
        }
        public string CreateParaLog(object objPara, string FunctionName, string LogGroup)
        {
            StringBuilder sb = new StringBuilder();
            if (objPara != null)
            {
                PropertyInfo[] fiCheck = objPara.GetType().GetProperties();
                foreach (var item in fiCheck)
                {
                    var val = objPara.GetType().GetProperty(item.Name).GetValue(objPara, null);
                    if (val != null)
                    {
                        if (!string.IsNullOrEmpty(sb.ToString()))
                            sb.Append(", ");
                        sb.AppendFormat("@{0}={1}", item.Name, val == null ? "NULL" : string.Format("'{0}'", val));
                    }
                }
            }
            var sblog = new StringBuilder();
            sblog.AppendFormat("[{0}] - Gọi store [exec/select {1} ( ", LogGroup.ToUpper(), FunctionName.ToUpper());
            sblog.Append(sb.ToString());
            sblog.Append(")]");
            WriteLog.LogService.RecordLogFile(sblog.ToString());

            return sblog.ToString();
        }
        public string DangNhap(HisConnection hisConnect)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(VnptFujitsuConst.ApiToken))
                {
                    return VnptFujitsuConst.ApiToken;
                }

                var param = new Dictionary<string, dynamic>()
                {
                    {"api", VnptFujitsuConst.ActionLogin},
                    {
                        "params", new Dictionary<string, dynamic>()
                        {
                            { "username", hisConnect.UserName},
                            {"password",hisConnect.PassWord},
                        }
                    }
                };

                var drawData = WebExtension.Post(string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName, param);

                if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
                {
                    return string.Empty;
                }

                dynamic jsonResponse = JObject.Parse(drawData.Name);
                var token = StringConverter.ToString(jsonResponse.UUID);
                if (!string.IsNullOrWhiteSpace(token))
                {
                    VnptFujitsuConst.ApiToken = token;

                    return token;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }
            return string.Empty;
        }

        public IList<VftTestingModel> DanhMucXetNghiem(HisConnection hisConnect)
        {
            var result = new List<VftTestingModel>();

            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<VftTestingModel>();
                }

                GetTesting(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetService, token, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }
        public IList<BaseModel> DanhMucBacSi(HisConnection hisConnect)
        {
            var result = new List<BaseModel>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<BaseModel>();
                }

                GetDoctors(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetDoctor, token, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }

        public IList<BaseModel> DanhMucKhoa(HisConnection hisConnect)
        {
            var result = new List<BaseModel>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<BaseModel>();
                }

                GetDepartments(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetDepartment, token, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }
        public IList<BaseModel> DanhMucPhong(HisConnection hisConnect)
        {
            var result = new List<BaseModel>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<BaseModel>();
                }

                GetRoms(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetRoom, token, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }
        public IList<BaseModel> DanhMucDoiTuong(HisConnection hisConnect)
        {
            var result = new List<BaseModel>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<BaseModel>();
                }

                GetObjects(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetObject, token, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }

        public IList<VftDiseaseInfo> DanhMucChanDoan(HisConnection hisConnect)
        {
            var result = new List<VftDiseaseInfo>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<VftDiseaseInfo>();
                }

                GetDiseases(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetDisease, token, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }

        public IList<VftOrderInfo> DownloadChiDinh(DownloadOrderParams requestParams, HisConnection hisConnect)
        {
            var result = new List<VftOrderInfo>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<VftOrderInfo>();
                }

                DownloadOrder(result, (string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), VnptFujitsuConst.ActionGetOrders, token, requestParams, 0);
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }

        public IList<VftOrderInfo> DownloadChiTietChiDinh(string soPhieuYeuCau, HisConnection hisConnect)
        {
            var result = new List<VftOrderInfo>();
            try
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new List<VftOrderInfo>();
                }

                var param = new Dictionary<string, dynamic>()
                {
                    {"api", VnptFujitsuConst.ActionGetOrderDetail},
                    {"uuid", token},
                    {
                        "params", new Dictionary<string, dynamic>()
                        {
                            {"so_phieu_yeu_cau", soPhieuYeuCau}
                        }
                    }
                };

                var drawData = SendRequestTo3Rd((string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), param);

                if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
                {
                    return result;
                }

                dynamic jsonResponse = JObject.Parse(drawData.Name);

                if (jsonResponse != null && jsonResponse.items != null)
                {
                    foreach (var service in jsonResponse.items)
                    {
                        result.Add(new VftOrderInfo()
                        {
                            DiaChi = StringConverter.ToString(service.DIACHI),
                            GioiTinh = NumberConverter.ToInt(service.GIOITINH),
                            MaBacSi = NumberConverter.ToInt(service.MABACSI),
                            MaBenhNhan = StringConverter.ToString(service.MABENHNHAN),
                            MaChanDoan = NumberConverter.ToInt(service.MACHANDOAN),
                            MaDoiTuong = NumberConverter.ToInt(service.MADOITUONG),
                            MaKhoaPhong = NumberConverter.ToInt(service.MAKHOAPHONG),
                            NamSinh = NumberConverter.ToInt(service.NAMSINH),
                            NgayChiDinh = StringConverter.ToString(service.NGAYCHIDINH),
                            SinhNhat = StringConverter.ToString(service.SINHNHAT),
                            SoPhieuYeuCau = StringConverter.ToString(service.SOPHIEUYEUCAU),
                            SoTheBhyt = StringConverter.ToString(service.SOTHEBHYT),
                            TenBacSi = StringConverter.ToString(service.TENBACSI),
                            TenBenhNhan = StringConverter.ToString(service.TENBENHNHAN),
                            TenChanDoan = StringConverter.ToString(service.CHANDOAN),
                            TenDoiTuong = StringConverter.ToString(service.TENDOITUONG),
                            IdChiDinhDichVu = StringConverter.ToString(service.IDDICHVUCHIDINH),
                            MaDichVu = StringConverter.ToString(service.MADICHVU),
                            TenDichVu = StringConverter.ToString(service.TENDV),
                            TenKhoaPhong = StringConverter.ToString(service.TENKHOAPHONG),
                        });
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }

        public BaseModel CapNhatTrangThaiChiDinh(List<UpdateOrderStatusParams> updateInfo, HisConnection hisConnect)
        {
            var result = new BaseModel();
            try
            {
                foreach (var item in updateInfo)
                {
                    var token = DangNhap(hisConnect);
                    if (string.IsNullOrWhiteSpace(token))
                    {
                        return new BaseModel()
                        {
                            Id = MessageCodeConst.SystemErrorCode,
                            Name = ErrorTokenInvalid
                        };
                    }

                    var param = new Dictionary<string, dynamic>()
                {
                    {"api", VnptFujitsuConst.ActionUpdateOrderStatus},
                    {"uuid", token},
                    {
                        "params", new Dictionary<string, dynamic>()
                        {
                            {"so_phieu_chi_dinh", item.SoPhieuYeuCau},
                            {"iddichvuchidinh", item.IdChiDinhDichVu},
                            {"trang_thai", item.TrangThai}
                        }
                    }
                };

                    var drawData = SendRequestTo3Rd((string.IsNullOrEmpty(hisConnect.ServerName) ? VnptFujitsuConst.DefaultVftPostUrl : hisConnect.ServerName), param);
                    drawData.Id = drawData.Id == MessageCodeConst.VnptUploadSuccessCode
                        ? MessageCodeConst.SuccessCode
                        : drawData.Id;

                }
                return result;
            }
            catch (Exception ex)
            {
                WriteLog.LogService.RecordLogFile(ex.Message);
            }

            return result;
        }

        public BaseModel UploadKetQuaChiDinh(List<UploadOrderParams> resultInfo, HisConnection hisConnect)
        {
            var basereturn = new BaseModel();
            foreach (var item in resultInfo)
            {
                var token = DangNhap(hisConnect);
                if (string.IsNullOrWhiteSpace(token))
                {
                    return new BaseModel()
                    {
                        Id = MessageCodeConst.SystemErrorCode,
                        Name = ErrorTokenInvalid
                    };
                }
                //?sophieuyeucau = test & iddichvuchidinh = 12321 & madichvu = 131 & 
                //ketqua = 12312 & chisobinhthuong = bt & batthuong = 1 & klchung = bt & 
                //user_name = tuannm & upl = 1 & sopkq = 1
                var param = new Dictionary<string, dynamic>()
            {
                {"api", VnptFujitsuConst.ActionUploadOrder},
                {"uuid", token},
                {
                    "params", new Dictionary<string, dynamic>()
                    {
                        {"so_phieu_yeu_cau", item.SoPhieuYeuCau},
                        {"iddichvuchidinh", string.IsNullOrWhiteSpace(item.IdDichVuChiDinh) ? "NULL" : item.IdDichVuChiDinh },
                        {"madichvu", string.IsNullOrWhiteSpace(item.MaDichVu) ? "NULL" : item.MaDichVu},
                        {"ketqua", string.IsNullOrWhiteSpace(item.KetQua) ? "NULL" :  item.KetQua},
                        {"chisobinhthuong", string.IsNullOrWhiteSpace(item.BinhThuong) ? "NULL" : item.BinhThuong},
                        {"batthuong", string.IsNullOrWhiteSpace(item.BatThuong) ? "NULL" : item.BatThuong},
                        {"klchung", string.IsNullOrWhiteSpace(item.KetLuan) ? "NULL" : item.KetLuan},
                        {"user_name", string.IsNullOrWhiteSpace(item.Username) ? "NULL" : item.Username},
                        {"upl", string.IsNullOrWhiteSpace(item.SoLanUpload) ? "NULL" : item.SoLanUpload},
                        {"sopkq", string.IsNullOrWhiteSpace(item.SoBarcode) ? "NULL" : item.SoBarcode}
                    }
                }
            };

                WriteLog.LogService.RecordLogFile("===Send request to 3rd ===\r\n");
                WriteLog.LogService.RecordLogFile(string.Format("\tURL:{0}\r\n", VnptFujitsuConst.VftUploadKetQuaUrl));

                var drawData = WebExtension.Post(VnptFujitsuConst.VftUploadKetQuaUrl, param);

                drawData.Id = drawData.Id == MessageCodeConst.VnptUploadSuccessCode
                    ? MessageCodeConst.SuccessCode
                    : drawData.Id;

            }
            return basereturn;
        }
        private IList<VftTestingModel> GetTesting(IList<VftTestingModel> result, string url, string action, string token, int pageIndex)
        {
            var drawData = SendRequestTo3Rd(url, action, token, pageIndex * ItemPerPage);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new VftTestingModel()
                    {
                        Id = NumberConverter.ToInt(service.ID),
                        Name = StringConverter.ToString(service.NAME),
                        Code = StringConverter.ToString(service.CODE),
                        Unit = StringConverter.ToString(service.UNIT_NAME),
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    GetTesting(result, url, action, token, pageIndex + 1);
                }
            }

            return result;
        }
        private IList<BaseModel> GetDoctors(IList<BaseModel> result, string url, string action, string token, int pageIndex)
        {
            var drawData = SendRequestTo3Rd(url, action, token, pageIndex * ItemPerPage);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new BaseModel()
                    {
                        Id = NumberConverter.ToInt(service.EMPL_ID),
                        Name = StringConverter.ToString(service.EMPL_NAME),
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    GetDoctors(result, url, action, token, pageIndex + 1);
                }
            }

            return result;
        }
        private IList<BaseModel> GetDepartments(IList<BaseModel> result, string url, string action, string token, int pageIndex)
        {
            var drawData = SendRequestTo3Rd(url, action, token, pageIndex * ItemPerPage);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new BaseModel()
                    {
                        Id = NumberConverter.ToInt(service.DEPT_ID),
                        Name = StringConverter.ToString(service.DEPT_NAME),
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    GetDepartments(result, url, action, token, pageIndex + 1);
                }
            }

            return result;
        }

        private IList<BaseModel> GetRoms(IList<BaseModel> result, string url, string action, string token, int pageIndex)
        {
            var drawData = SendRequestTo3Rd(url, action, token, pageIndex * ItemPerPage);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new BaseModel()
                    {
                        Id = NumberConverter.ToInt(service.ROOM_ID),
                        Name = StringConverter.ToString(service.ROOM_NAME),
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    GetRoms(result, url, action, token, pageIndex + 1);
                }
            }

            return result;
        }

        private IList<BaseModel> GetObjects(IList<BaseModel> result, string url, string action, string token, int pageIndex)
        {
            var drawData = SendRequestTo3Rd(url, action, token, pageIndex * ItemPerPage);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new BaseModel()
                    {
                        Id = NumberConverter.ToInt(service.ID),
                        Name = StringConverter.ToString(service.NAME),
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    GetObjects(result, url, action, token, pageIndex + 1);
                }
            }

            return result;
        }

        private IList<VftDiseaseInfo> GetDiseases(IList<VftDiseaseInfo> result, string url, string action, string token, int pageIndex)
        {
            var drawData = SendRequestTo3Rd(url, action, token, pageIndex * ItemPerPage);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new VftDiseaseInfo()
                    {
                        Id = NumberConverter.ToInt(service.ID),
                        Name = StringConverter.ToString(service.VVIET),
                        Cicd10 = StringConverter.ToString(service.CICD10)
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    GetDiseases(result, url, action, token, pageIndex + 1);
                }
            }

            return result;
        }
        private IList<VftOrderInfo> DownloadOrder(IList<VftOrderInfo> result, string url, string action, string token, DownloadOrderParams requestParams, int pageIndex)
        {
            var offset = pageIndex * ItemPerPage;
            var param = new Dictionary<string, dynamic>()
            {
                {"api", action},
                {"uuid", token},
                {
                    "params", new Dictionary<string, dynamic>()
                    {
                        {"limit", ItemPerPage},
                        {
                            "so_phieu_yeu_cau",
                            string.IsNullOrWhiteSpace(requestParams.SoPhieuYeuCau)
                                ? "NULL"
                                : requestParams.SoPhieuYeuCau
                        },
                        {
                            "ho_ten",
                            string.IsNullOrWhiteSpace(requestParams.HoTenBenhNhan)
                                ? "NULL"
                                : requestParams.HoTenBenhNhan
                        },
                        {"tu_ngay", string.IsNullOrWhiteSpace(requestParams.TuNgay) ? "NULL" : requestParams.TuNgay},
                        {"den_ngay", string.IsNullOrWhiteSpace(requestParams.DenNgay) ? "NULL" : requestParams.DenNgay},
                        {
                            "trang_thai", requestParams.TrangThai
                        }
                    }
                }
            };

            if (offset != 0)
            {
                param["params"].Add("offset", offset + 1);
            }

            var drawData = SendRequestTo3Rd(url, param);

            if (drawData.Id != MessageCodeConst.SuccessCode || string.IsNullOrEmpty(drawData.Name))
            {
                return result;
            }

            dynamic jsonResponse = JObject.Parse(drawData.Name);

            if (jsonResponse != null && jsonResponse.items != null)
            {
                foreach (var service in jsonResponse.items)
                {
                    result.Add(new VftOrderInfo()
                    {
                        DiaChi = StringConverter.ToString(service.DIACHI),
                        GioiTinh = NumberConverter.ToInt(service.GIOITINH),
                        MaBacSi = NumberConverter.ToInt(service.MABACSI),
                        MaBenhNhan = StringConverter.ToString(service.MABENHNHAN),
                        MaChanDoan = NumberConverter.ToInt(service.MACHANDOAN),
                        MaDoiTuong = NumberConverter.ToInt(service.MADOITUONG),
                        MaKhoaPhong = NumberConverter.ToInt(service.MAKHOAPHONG),
                        NamSinh = NumberConverter.ToInt(service.NAMSINH),
                        NgayChiDinh = StringConverter.ToString(service.NGAYCHIDINH),
                        SinhNhat = StringConverter.ToString(service.SINHNHAT),
                        SoPhieuYeuCau = StringConverter.ToString(service.SOPHIEUYEUCAU),
                        SoTheBhyt = StringConverter.ToString(service.SOTHEBHYT),
                        TenBacSi = StringConverter.ToString(service.TENBACSI),
                        TenBenhNhan = StringConverter.ToString(service.TENBENHNHAN),
                        TenChanDoan = StringConverter.ToString(service.CHANDOAN),
                        TenDoiTuong = StringConverter.ToString(service.TENDOITUONG),
                        TenKhoaPhong = StringConverter.ToString(service.TENKHOAPHONG),
                    });
                }

                if (NumberConverter.To<bool>(jsonResponse.hasMore))
                {
                    DownloadOrder(result, url, action, token, requestParams, pageIndex + 1);
                }
            }

            return result;
        }

        private BaseModel SendRequestTo3Rd(string url, string action, string token, int offset)
        {
            WriteLog.LogService.RecordLogFile("===Send request to 3rd ===\r\n");
            WriteLog.LogService.RecordLogFile(string.Format("\tURL:{0}\r\n", url));

            var param = new Dictionary<string, dynamic>()
            {
                {"api", action},
                {"uuid", token},
                {
                    "params", new Dictionary<string, dynamic>()
                    {
                        {"limit", ItemPerPage}
                    }
                }
            };

            if (offset != 0)
            {
                param["params"].Add("offset", offset + 1);
            }

            var drawData = WebExtension.Post(url, param);

            WriteLog.LogService.RecordLogFile(string.Format("\tRESPONSE:{0}\r\n", drawData.Name));

            return drawData;
        }


        private BaseModel SendRequestTo3Rd(string url, Dictionary<string, dynamic> param)
        {
            WriteLog.LogService.RecordLogFile("===Send request to 3rd ===\r\n");
            WriteLog.LogService.RecordLogFile(string.Format("\tURL:{0}\r\n", url));

            var drawData = WebExtension.Post(url, param);

            WriteLog.LogService.RecordLogFile(string.Format("\tRESPONSE:{0}\r\n", drawData.Name));

            return drawData;
        }
    }
}