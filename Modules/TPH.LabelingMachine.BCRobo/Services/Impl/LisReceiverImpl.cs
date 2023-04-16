using System;
using System.Collections.Generic;
using TPH.LabelingMachine.BCRobo.Extensions;
using TPH.LabelingMachine.BCRobo.Models;

namespace TPH.LabelingMachine.BCRobo.Services.Impl
{
    public class LisReceiverImpl : ILisReceiver
    {
        private static LogExtension _logExtension = new LogExtension();

        public string SavePatientInfo(PatientInfo result)
        {
            _logExtension.WriteInfo(string.Format("SavePatientInfo: {0}", result));
            return string.Empty; 
            // Khi có lỗi trả về thông tin chi tiết lỗi hoặc mã lỗi, khi bình thường trả về thông tin rỗng hoặc empty
        }
        public string CancelPatientByOrderId(string orderId)
        {
            _logExtension.WriteInfo(string.Format("CancelPatientByOrderId: {0}", orderId));
            return string.Empty; 
            // Khi có lỗi trả về thông tin chi tiết lỗi hoặc mã lỗi, khi bình thường trả về thông tin rỗng hoặc empty
        }


        public string CancelPatient(CancelPatientReceiverRequest request)
        {
            _logExtension.WriteInfo(string.Format("CancelPatientReceiverRequest: request:{0} ", request));
            return string.Empty; // Khi có lỗi trả về thông tin chi tiết lỗi hoặc mã lỗi, khi bình thường trả về thông tin rỗng hoặc empty
        }

        public string CancelTest(CancelTestReceiverRequest request)
        {
            _logExtension.WriteInfo(string.Format("CancelTestReceiverRequest: request:{0} ", request));
            return string.Empty; // Khi có lỗi trả về thông tin chi tiết lỗi hoặc mã lỗi, khi bình thường trả về thông tin rỗng hoặc empty
        }

        public string UpdateTestStatus(UpdateStatusReceiverRequest request)
        {
            _logExtension.WriteInfo(string.Format("UpdateStatusReceiverRequest: request:{0} ", request));
            return string.Empty; // Khi có lỗi trả về thông tin chi tiết lỗi hoặc mã lỗi, khi bình thường trả về thông tin rỗng hoặc empty
        }

        public SamplingResultResponse GetSamplingResult(string sampleId)
        {
            var response = new SamplingResultResponse();
            try
            {
                _logExtension.WriteInfo(string.Format("Try to call GetSamplingResult - sampleId:{0}", sampleId));
                throw new Exception("Chức năng chưa được mở!");
            }
            catch (Exception ex)
            {
                _logExtension.WriteException(ex);
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SamplingHistoryResponse GetSamplingHistory(string patientId, string dateRequestFrom, string dateRequestTo)
        {
            var response = new SamplingHistoryResponse()
            {
                PatientId = patientId,
            };
            try
            {
                _logExtension.WriteInfo(string.Format("Try to call GetSamplingHistory - patientId:{0}, dateRequestFrom:{1}, dateRequestTo:{2}",
                    patientId, dateRequestFrom, dateRequestTo));
                throw new Exception("Chức năng chưa được mở!");
            }
            catch (Exception ex)
            {
                _logExtension.WriteException(ex);
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public SamplingTestResponse GetSamplingRequest(string sampleId)
        {
            var response = new SamplingTestResponse
            {
                Result = new PatientInfo
                {
                    PatientId = "PID0001",
                    HoTen = "Tên bệnh nhân",
                    NamSinh = 1980,
                    NgaySinh = "1980-06-30",
                    GioiTinh = "M",
                    Address = "111 Đường 222",
                    ListTestResult = new List<TestResult>
                    {
                        new TestResult()
                        {
                            MaDV = "GLU",
                            TenDichVu = "Glucose",
                            MaLoaiDV = "SH",
                            TenLoaiDV = "Sinh hóa",
                            KetQua = "10.1"
                        }
                    }
                }
            };

            return response;
        }

        public UserInfoResponse GetUserInfo(string userId)
        {
            var response = new UserInfoResponse
            {
                UserId = userId,
                UserName = userId + " - Name"
            };

            return response;
        }
    }
}