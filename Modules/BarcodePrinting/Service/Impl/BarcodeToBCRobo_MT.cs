using TPH.LIS.BarcodePrinting.Barcode;
using System;
using System.Collections.Generic;
using TPH.LabelingMachine.BCRobo.Models;
using TPH.LabelingMachine.BCRobo.Services.Impl;
using TPH.LIS.Patient.Model;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.BarcodePrinting.Service.Impl
{
    public class BarcodeToBCRobo_MT
    {
        //private readonly IClientService _iBCRobo = new ClientServiceImpl();
        public string InsertNewBarcodeInfo(BarcodeProperties objLis, DM_MAYTINH_MAYIN objCauHinh, List<KETQUA_CLS_XETNGHIEM> lstChiDinhXN)
        {
            var bcRobo = new ClientServiceImpl(objCauHinh.Duongdan);
            string returnString = "BarcodeToBCRobo_MT - Không có danh sách chỉ định";
            if (lstChiDinhXN != null)
            {
             
                if (lstChiDinhXN.Count > 0)
                {
                    returnString = string.Empty;
                    var objBCRoboPatient = new PatientInfo();
                    objBCRoboPatient.Address = objLis.DiaChi;
                    objBCRoboPatient.Bed = objLis.SoGiuong;
                    objBCRoboPatient.CapCuu = objLis.CapCuu;
                    objBCRoboPatient.ChanDoan = objLis.ChanDoan;
                    objBCRoboPatient.Comment = objLis.Comment;
                    objBCRoboPatient.DateReceiving = objLis.DateReceiving;
                    objBCRoboPatient.DoctorName = objLis.TenBSChiDinh;
                    objBCRoboPatient.GioChiDinh_DateTime = objLis.GioChiDinh_DateTime;
                    objBCRoboPatient.GioiTinh = objLis.GioiTinh;
                    objBCRoboPatient.HoTen = objLis.PatientName;
                    objBCRoboPatient.InPatient = objLis.NoiTru;
                    objBCRoboPatient.InsureNumber = objLis.SoBHYT;
                    objBCRoboPatient.KSK = objLis.BN_KSK;
                    objBCRoboPatient.LocationName = objLis.TenKhoaPhong;
                    objBCRoboPatient.MaBSChiDinh = objLis.MaBSChiDinh;
                    objBCRoboPatient.MaDoiTuong = objLis.MaDoiTuongDichVu;
                    objBCRoboPatient.MaKhoaPhong = objLis.MaKhoaPhong;
                    objBCRoboPatient.MaYTe = objLis.MaYTe;
                    objBCRoboPatient.NgaySinh = objLis.NgaySinh;
                    objBCRoboPatient.NamSinh = int.Parse(objLis.NamSinh);
                    objBCRoboPatient.NgaySinh_DateTime = objLis.NgaySinh_DateTime;
                    objBCRoboPatient.ObjectName = objLis.TenDoiTuongDichVu;
                    objBCRoboPatient.OrderCode = objLis.SoPhieuChiDinh;
                    objBCRoboPatient.OrderId = string.Format("TPH{0}_{1}", objLis.NgayTiepNhan.ToString("ddMMyy"), (string.IsNullOrEmpty(objLis.SoHoSo) ? objLis.SoBarcode : objLis.SoHoSo));
                    objBCRoboPatient.PatientId = objLis.PatientID;
                    objBCRoboPatient.Sequence = (string.IsNullOrEmpty(objLis.SoHoSo) ? objLis.SoBarcode : objLis.SoHoSo);
                    objBCRoboPatient.SttPatient = objLis.SoTT;
                    objBCRoboPatient.SampleId = string.Format("{0}-{1}", objLis.NgayTiepNhan.ToString("ddMMyy"), (string.IsNullOrEmpty(objLis.SoHoSo)?objLis.SoBarcode: objLis.SoHoSo));
                    objBCRoboPatient.ReceptionLocationId = objCauHinh.BanTiepNhan;
                    objBCRoboPatient.ReceptionLocationName = objCauHinh.BanTiepNhan;
                    objBCRoboPatient.ListAdditionalInfo = new List<PatientInfoAdditionalInfo> {
                        new PatientInfoAdditionalInfo {Key="RECEPTION_TABLE", Value = objCauHinh.BanTiepNhan }
                            };
                    foreach (var item in lstChiDinhXN)
                    {
                        objBCRoboPatient.DateGet = objLis.GioChiDinh_DateTime;
                        objBCRoboPatient.UserGet = item.Usernhapcd;
                        objBCRoboPatient.TypeName = item.Loaimau;
                        objBCRoboPatient.ListTestResult.Add(new TestResult {
                         
                            CLSYeuCau_ID = item.Idchitiethis,
                            DistinctSID = item.Stt,
                            MaBenhNhan = objLis.PatientID,
                            MaCapTren = item.Profileid,
                            TenDichVu = item.Tenxn,
                            MaDV = item.Maxn,
                            TestTypeId = item.BCRoBoTypeID,
                            TestTypeName = item.TenNhomLoaimau,
                            TenLoaiDV = item.TenNhomCLS,
                            NormalRange = item.Csbt,
                            OrderDetailID = item.Maxn_his,
                            OrderID = string.IsNullOrEmpty(item.Rsophieuyeucau) ? objLis.SoHoSo : item.Rsophieuyeucau
                            
                        });   
                    }
                    try
                    {
                        bcRobo.CancelPatientByOrderId(objBCRoboPatient.OrderId);
                    }
                    catch (Exception ex)
                    {
                        returnString += Environment.NewLine + ex.Message;
                    }
                     returnString += bcRobo.SavePatientInfo(objBCRoboPatient);
                }
            }
            return returnString;
        }
    }
}
