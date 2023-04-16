using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.BarcodePrinting;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.BarcodePrinting.Service;
using TPH.LIS.BarcodePrinting.Service.Impl;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Model;
using TPH.WriteLog;

namespace TPH.LIS.App.AppCode
{
    public class PrintBarcodeHelper
    {
        private static readonly IBarcodePrintingService _iBarcodeService = new BarcodePrintingService();
        private static readonly TestResult.Services.ITestResultService _iTestResult = new TestResult.Services.TestResultService();

        private static void PrintToNormalSystem(List<BENHNHAN_TIEPNHAN> lstBnInfo
            , int indexTrangThaiLayMau, DM_MAYTINH_MAYIN objPrintInfo
            , bool isRePrint = false, List<string> lstLoaiMau = null
            , List<KETQUA_CLS_XETNGHIEM> lstKetQua = null, DateTime? thoigianLaymau = null, object lblMess = null)
        {
            var lstBarcode = new List<BarcodeProperties>();
            var error = "";
            var soHoso = string.Empty;
            foreach (var bnInfo in lstBnInfo)
            {
                var currentdate = thoigianLaymau ?? CommonAppVarsAndFunctions.ServerTime;
                int soluongTem = 0;
                var barcode = new BarcodeProperties();
                barcode.NamSinh = bnInfo.Tuoi.ToString();
                barcode.NgaySinh_DateTime = bnInfo.Sinhnhat;
                barcode.TenBarcode = barcode.SoBarcode = bnInfo.Seq;
                barcode.NgayTiepNhan = bnInfo.Ngaytiepnhan;
                barcode.PatientName = bnInfo.Tenbn;
                barcode.Sid = bnInfo.Matiepnhan;
                barcode.SoTT = bnInfo.Sott.ToString();
                barcode.GioiTinh = bnInfo.Gioitinh;
                barcode.GioChiDinh = (currentdate).ToString();
                barcode.GioChiDinh_DateTime = currentdate;
                barcode.MaKhoaPhong = bnInfo.Madonvi;
                barcode.PatientID = bnInfo.Mabn;
                barcode.DinhDangTemGhepLoaiMau = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDinhDangBarcode;
                barcode.SoGiuong = bnInfo.Giuong;
                barcode.SoTemToiThieu = int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu);
                barcode.InGhepLoaiMau = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemBacodeCoLoaiMau;
                barcode.LoaiMauKhongInLenTem = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemLoaiMauKhongGhep;
                barcode.MaDoiTuongDichVu = bnInfo.Doituongdichvu;
                barcode.MaKhoaPhong = bnInfo.Madonvi;
                barcode.MaBSChiDinh = bnInfo.Bacsicd;
                barcode.SoPhieuChiDinh = string.IsNullOrEmpty(bnInfo.Sophieuyeucau) ? bnInfo.Seq : bnInfo.Sophieuyeucau;
                barcode.SoHoSo = bnInfo.Bn_id;
                barcode.TgNhapBN = bnInfo.Thoigiannhap;
                soHoso = string.IsNullOrEmpty(soHoso) ? bnInfo.Bn_id : soHoso;
                barcode.LableMachineID = (objPrintInfo == null ? 0 : (objPrintInfo.Giaothuc == null ? 0 : objPrintInfo.Idmay));
                //if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemBacodeCoLoaiMau)
                //{
                    if (isRePrint)
                    {
                        var dataBarcode = _iTestResult.SoLuongMau_Data(bnInfo.Matiepnhan, false, CommonAppVarsAndFunctions.IDLayLoaiMau, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDanhDauKyTuTem);
                        if (dataBarcode.Rows.Count > 0)
                        {
                            var f = new frmChonMauInCode();
                            f.dataIn = dataBarcode;
                            f.ShowDialog();

                            if (f.dataReturn != null && f.numberOfCopy > 0)
                            {
                                if (f.dataReturn.Rows.Count > 0)
                                {
                                    var dataLabel = string.Empty;
                                    var dateLayMau = CommonAppVarsAndFunctions.ServerTime;
                                    barcode.DanhSachTube = new List<BarcodeTubeDetail>();
                                    foreach (DataRow dr in f.dataReturn.Rows)
                                    {
                                        if (!string.IsNullOrEmpty(dr["thoigianlaymau"].ToString()))
                                            dateLayMau = DateTime.Parse(dr["thoigianlaymau"].ToString());
                                        var obj = new BarcodeTubeDetail();
                                        obj.Barcode = barcode.SoBarcode;
                                        obj.BarcodeName = barcode.TenBarcode;
                                        obj.NgayLayMau = dateLayMau;
                                        obj.TgNhapBN = bnInfo.Thoigiannhap;
                                        obj.NguoiLayMau = CommonAppVarsAndFunctions.UserID;
                                        obj.Tubecode = dr["LoaiMau"].ToString().Trim();
                                        obj.TubeCount = f.numberOfCopy;// int.Parse(dr["SL"].ToString());
                                        obj.Tubename = dr["TenNhomLoaiMau"].ToString().Trim();
                                        obj.NhomXetNghiem = dr["MaNhomCLS"].ToString().Trim();
                                        obj.BoPhanXetNghiem = dr["MaBoPhan"].ToString().Trim();
                                        obj.KyTuDanhDau = dr["KyTuDanhDau"].ToString().Trim();
                                        obj.TubeCate = dr["LoaiMau"].ToString().Trim();
                                        if (objPrintInfo != null)
                                        {
                                            if (!string.IsNullOrEmpty(objPrintInfo.Giaothuc))
                                            {
                                                if (objPrintInfo.Giaothuc.Trim().Equals(PrintingSystemProtocolList.HEN))
                                                {
                                                    obj.TubeCate = dr["IDTube1"].ToString().Trim();
                                                    obj.Tubename = dr["MaNhomCLS"].ToString().Trim();
                                                    obj.Tubecode = dr["MaBoPhan"].ToString().Trim();
                                                }
                                                else if (objPrintInfo.Giaothuc.Trim().Equals(PrintingSystemProtocolList.BCRoboMT))
                                                {
                                                    obj.TubeCate = dr["IDTube2"].ToString().Trim();
                                                }
                                                else if (objPrintInfo.Giaothuc.Trim().Equals(PrintingSystemProtocolList.OLPASO))
                                                {
                                                    obj.TubeCate = dr["IDTube3"].ToString().Trim();
                                                    obj.Tubename = dr["MaNhomCLS"].ToString().Trim();
                                                    obj.Tubecode = dr["MaBoPhan"].ToString().Trim();
                                                }
                                            }
                                        }

                                        barcode.DanhSachTube.Add(obj);
                                        soluongTem += f.numberOfCopy;
                                    }

                                    lstBarcode.Add(barcode);
                                }
                            }
                        }
                    }
                    else
                    {
                        var giaoThuc = (objPrintInfo == null ? string.Empty : (objPrintInfo.Giaothuc == null ? string.Empty : objPrintInfo.Giaothuc));
                        if (!(giaoThuc.Equals(PrintingSystemProtocolList.BCRoboMT)))
                        {
                            var dataBarcode = _iTestResult.SoLuongMau_Data(bnInfo.Matiepnhan, isRePrint, CommonAppVarsAndFunctions.IDLayLoaiMau, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDanhDauKyTuTem);
                            if (dataBarcode.Rows.Count > 0)
                            {
                                //Khi in tự động bỏ loại mẫu cấu hình không in tem tự động
                                for (int i = 0; i < dataBarcode.Rows.Count; i++)
                                {
                                    if (dataBarcode.Rows[i]["IntemTuDong"].ToString() == "0")
                                    {
                                        dataBarcode.Rows.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                            if (lstLoaiMau != null)
                            {
                                var x = from d in dataBarcode.AsEnumerable()
                                        join r in lstLoaiMau on d.Field<string>("LoaiMau") equals r
                                        select d;
                                if (x.FirstOrDefault() != null)
                                    dataBarcode = x.ToList().CopyToDataTable();
                                else
                                    dataBarcode = new DataTable();
                            }
                            //select A.Chon, A.thoigianlaymau, A.nguoilaymau, a.TenNhomLoaiMau, a.MaNhomLoaiMau as LoaiMau,A.MaNhomCLS, a.ThuTu, count(a.LoaiMau) as SL
                            soluongTem = (indexTrangThaiLayMau == 3 ? 0 : int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu));
                            barcode.NumberOfCopy = int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu);
                            DateTime? dateLayMau = (DateTime?)null;
                            //In sau khi select ko có dữ liệu cần ghép
                            if (dataBarcode.Rows.Count > 0)
                            {
                                barcode.DanhSachTube = new List<BarcodeTubeDetail>();
                                foreach (DataRow dr in dataBarcode.Rows)
                                {
                                    if (!string.IsNullOrEmpty(dr["thoigianlaymau"].ToString()))
                                        dateLayMau = DateTime.Parse(dr["thoigianlaymau"].ToString());
                                    else
                                        dateLayMau = dateLayMau ?? CommonAppVarsAndFunctions.ServerTime;
                                    barcode.NgayTiepNhan = dateLayMau.Value;
                                    barcode.NumberOfCopy = 1;
                                    var obj = new BarcodeTubeDetail();
                                    obj.Barcode = barcode.SoBarcode;
                                    obj.BarcodeName = barcode.TenBarcode;
                                    obj.NgayLayMau = dateLayMau;
                                    obj.TgNhapBN = bnInfo.Thoigiannhap;
                                    obj.NguoiLayMau = CommonAppVarsAndFunctions.UserID;
                                    obj.Tubecode = dr["LoaiMau"].ToString().Trim();
                                    obj.Tubename = dr["TenNhomLoaiMau"].ToString().Trim();
                                    obj.TubeCount = int.Parse(dr["SL"].ToString());
                                    obj.NhomXetNghiem = dr["MaNhomCLS"].ToString().Trim();
                                    obj.KyTuDanhDau = dr["KyTuDanhDau"].ToString().Trim();
                                    obj.BoPhanXetNghiem = dr["MaBoPhan"].ToString().Trim();
                                    obj.TubeCate = dr["LoaiMau"].ToString().Trim();
                                    if (objPrintInfo != null)
                                    {
                                        if (!string.IsNullOrEmpty(objPrintInfo.Giaothuc))
                                        {
                                            if (objPrintInfo.Giaothuc.Trim().Equals(PrintingSystemProtocolList.HEN))
                                            {
                                                obj.TubeCate = dr["IDTube1"].ToString().Trim();
                                                obj.Tubename = dr["MaNhomCLS"].ToString().Trim();
                                                obj.Tubecode = dr["MaBoPhan"].ToString().Trim();
                                            }
                                            else if (objPrintInfo.Giaothuc.Trim().Equals(PrintingSystemProtocolList.BCRoboMT))
                                            {
                                                obj.TubeCate = dr["IDTube2"].ToString().Trim();
                                            }
                                            else if (objPrintInfo.Giaothuc.Trim().Equals(PrintingSystemProtocolList.OLPASO))
                                            {
                                                obj.TubeCate = dr["IDTube3"].ToString().Trim();
                                                obj.Tubename = dr["MaNhomCLS"].ToString().Trim();
                                                obj.Tubecode = dr["MaBoPhan"].ToString().Trim();
                                            }
                                        }
                                    }
                                    soluongTem += obj.TubeCount;
                                    barcode.DanhSachTube.Add(obj);
                                }
                                if (int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu) > 0)
                                {
                                    //thêm tem cho phiếu chỉ định (không có loại mẫu)
                                    dateLayMau = (dateLayMau != null ? dateLayMau.Value : bnInfo.Thoigiannhap);
                                    barcode.DanhSachTube.Add(new BarcodeTubeDetail
                                    {
                                        TgNhapBN = bnInfo.Thoigiannhap,
                                        NgayLayMau = dateLayMau,
                                        NguoiLayMau = CommonAppVarsAndFunctions.UserID,
                                        TubeCount = int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu)
                                    });
                                }
                            }
                            else
                            {
                                barcode.DanhSachTube = new List<BarcodeTubeDetail>();
                                //thêm tem cho phiếu chỉ định (không có loại mẫu)
                                if (int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu) > 0)
                                {
                                    dateLayMau = (dateLayMau != null ? dateLayMau.Value : bnInfo.Thoigiannhap);
                                    barcode.DanhSachTube.Add(new BarcodeTubeDetail
                                    {
                                        Barcode = barcode.SoBarcode,
                                        Barcode2 = barcode.SoBarcode,
                                        TgNhapBN = bnInfo.Thoigiannhap,
                                        NgayLayMau = dateLayMau,
                                        NguoiLayMau = CommonAppVarsAndFunctions.UserID,
                                        TubeCount = int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu)
                                    });
                                }
                            }
                        }
                        lstBarcode.Add(barcode);
                    }
                    CustomMessageBox.CloseAlert();
                //}
                //else
                //{
                //    if (isRePrint)
                //    {
                //        var f = new DailyUse.BenhNhan.FrmPrintbarcodeTemp();
                //        f.txtMaTiepNhan.Text = bnInfo.Matiepnhan;
                //        f.ShowDialog();
                //    }
                //    else
                //    {
                //        soluongTem = _iTestResult.SoLuongMau(bnInfo.Matiepnhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemTinhSoTemTheoNhom) + int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu);
                //        barcode.DanhSachTube = new List<BarcodeTubeDetail>();
                //        barcode.DanhSachTube.Add(new BarcodeTubeDetail
                //        {
                //            TgNhapBN = bnInfo.Thoigiannhap,
                //            Barcode = bnInfo.Seq,
                //            BarcodeName = bnInfo.Seq,
                //            TubeCount = soluongTem
                //        });
                //        lstBarcode.Add(barcode);
                //    }
                //}
            }
            if (lstBarcode.Count() > 0)
            {
                CheckShowMess(string.Format("Thực hiện gửi dữ liệu đến máy in: {0}\nSố hồ sơ: {1} ", (objPrintInfo == null ? "Normal" : objPrintInfo.Giaothuc ?? "Normal"), soHoso ?? "NONE"), lblMess);
                Task.Factory.StartNew(() =>
                     PrintBarcode(objPrintInfo, lstBarcode, lstKetQua));
                CheckShowMess("", lblMess);
                CustomMessageBox.CloseAlert();
            }
        }
        public static void PrintBarcode(DM_MAYTINH_MAYIN objPrintInfo, List<BarcodeProperties> lstBarcode, List<KETQUA_CLS_XETNGHIEM> lstKetQua)
        {
            var error = _iBarcodeService.Printbarcode(objPrintInfo, lstBarcode, lstKetQua);
            if (!string.IsNullOrEmpty(error))
                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, error);
        }
        public static void CheckShowMess(string mess, object lblMess = null)
        {
            if (lblMess != null)
            {
                if (lblMess is Label)
                {
                    ((Label)lblMess).Text = mess;
                }
                else if (lblMess is TextBox)
                {
                    ((TextBox)lblMess).Text = mess;
                }
                else
                    CustomMessageBox.ShowAlert(mess);
            }
            else
                CustomMessageBox.ShowAlert(mess);
        }
        public static void PrintBarcode(List<BENHNHAN_TIEPNHAN> lstBnInfo, int indexTrangThaiLayMau, DM_MAYTINH_MAYIN objPrintInfo, bool isRePrint = false, List<string> lstLoaiMau = null
            , List<KETQUA_CLS_XETNGHIEM> lstXetNghiem = null, DateTime? thoigianLaymau = null, object lblMess = null)
        {
            PrintToNormalSystem(lstBnInfo, indexTrangThaiLayMau, objPrintInfo, isRePrint, lstLoaiMau, lstXetNghiem, thoigianLaymau, lblMess);
        }
    }
}
