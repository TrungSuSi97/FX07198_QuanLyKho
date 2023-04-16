using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Model;
using static TPH.LIS.BarcodePrinting.Constants.Loaibarcode;

namespace TPH.LIS.BarcodePrinting.Service.Impl
{
    public class BarcodePrintingService : IBarcodePrintingService
    {
        BarcodeToMiddleDatabase barcodeToMiddleData = new BarcodeToMiddleDatabase();
        BarcodeToBCRobo_MT barcodeToMT = new BarcodeToBCRobo_MT();
        private readonly Service.IBarcodeStandardInformation ibarcode = new Service.Impl.StandardBarcodeInformation();
        private static Dictionary<string, byte[]> dicRepoprt = new Dictionary<string, byte[]>();
        private string normalreportprinterName = string.Empty;
        public string Printbarcode(DM_MAYTINH_MAYIN objCauHinh, BarcodeProperties barcodeInfo, List<KETQUA_CLS_XETNGHIEM> lstChiDinhXN = null)
        {
            var error = "";
            if (objCauHinh != null)
            {
                //in qua hệ thống máy in theo cấu hình
                if (objCauHinh.Idmay > 0)
                {
                    //xác định giao thức
                    var protocol = objCauHinh.Giaothuc;
                    if (!string.IsNullOrEmpty(protocol))
                    {
                        barcodeInfo.LableMachineID = objCauHinh.Idmay;

                        if (protocol.Equals(PrintingSystemProtocolList.HEN))
                        {
                            barcodeToMiddleData.InsertNewBarcodeInfo(new List<BarcodeProperties> { barcodeInfo });
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.OLPASO))
                        {
                            barcodeToMiddleData.InsertNewBarcodeInfo(new List<BarcodeProperties> { barcodeInfo });
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.BCRoboMT))
                        {
                            error = barcodeToMT.InsertNewBarcodeInfo(barcodeInfo, objCauHinh, lstChiDinhXN);
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.BARTENDER))
                        {
                            PrintBarcodebartender(barcodeInfo);
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.TIEUCHUAN))
                        {
                            PrintBarcodeNormal(barcodeInfo, false);
                        }

                        else if (protocol.Equals(PrintingSystemProtocolList.TIEUCHUAN2))
                        {
                            var printItem = new BarcodeProperties();
                            var tempError = string.Empty;
                            bool addedColumn1 = false;

                            var item = barcodeInfo;
                            printItem = item.CopyInfo();
                            printItem.DanhSachTube = new List<BarcodeTubeDetail>();
                            BarcodeTubeDetail tubeNew = null;
                            printItem.NumberOfCopy = 1;

                            if (item.DanhSachTube.Count > 0)
                            {
                                foreach (var itemDS in item.DanhSachTube)
                                {
                                    for (int y = 0; y < item.NumberOfCopy; y++)
                                    {
                                        if (addedColumn1)
                                        {
                                            var fiCheck = itemDS.GetType().GetProperties();
                                            foreach (var itemProp in fiCheck)
                                            {
                                                var propSet = tubeNew.GetType().GetProperty(itemProp.Name + "2");
                                                if (propSet != null)
                                                {
                                                    propSet.SetValue(propSet, itemProp.GetValue(itemProp, null), null);
                                                }
                                            }
                                            printItem.DanhSachTube.Add(tubeNew);
                                            addedColumn1 = false;
                                            tubeNew = null;
                                        }
                                        else
                                        {
                                            tubeNew = new BarcodeTubeDetail();
                                            tubeNew = itemDS.CopyInfo();
                                            addedColumn1 = true;
                                        }
                                    }
                                }
                                if (tubeNew != null)
                                {
                                    printItem.DanhSachTube.Add(tubeNew);
                                }
                                tempError = PrintBarcodeNormal(printItem, true);
                            }
                        }
                        else
                            MessageBox.Show("Giao thức in chưa hỗ trợ!");
                    }
                    else
                        MessageBox.Show("Máy tính chưa khai báo giao thức máy in!");
                }
                else
                {
                    //in qua bartender
                    PrintBarcodeNormal(barcodeInfo, false);
                }
            }
            else
            {
                //in qua bartender
                PrintBarcodeNormal(barcodeInfo, false);
            }
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(string.Format("LỖI GỬI CHỈ ĐỊNH ĐẾN HỆ THỐNG IN BARCODE:\n{0}", error));
            return error;
        }
        public string Printbarcode(DM_MAYTINH_MAYIN objCauHinh
       , List<BarcodeProperties> lstBarcodeInfo, List<KETQUA_CLS_XETNGHIEM> lstChiDinhXN = null)
        {
            var error = "";
            if (objCauHinh != null)
            {
                //in qua hệ thống máy in theo cấu hình
                if (objCauHinh.Idmay > 0)
                {
                    //xác định giao thức
                    var protocol = objCauHinh.Giaothuc;
                    if (!string.IsNullOrEmpty(protocol))
                    {
                        if (protocol.Equals(PrintingSystemProtocolList.HEN))
                        {
                            barcodeToMiddleData.InsertNewBarcodeInfo(lstBarcodeInfo);
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.OLPASO))
                        {
                            barcodeToMiddleData.InsertNewBarcodeInfo(lstBarcodeInfo);
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.BCRoboMT))
                        {
                            var item = lstBarcodeInfo.First();
                            item.LableMachineID = objCauHinh.Idmay;
                            error = barcodeToMT.InsertNewBarcodeInfo(item, objCauHinh, lstChiDinhXN);
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.TIEUCHUAN))
                        {
                            foreach (var item in lstBarcodeInfo)
                            {
                                item.LableMachineID = objCauHinh.Idmay;
                                var tempError = PrintBarcodeNormal(item, false);
                                if (!string.IsNullOrEmpty(tempError))
                                    error += ((string.IsNullOrEmpty(error) ? Environment.NewLine : "") + tempError);
                            }
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.TIEUCHUANVS))
                        {
                            foreach (var item in lstBarcodeInfo)
                            {
                                item.LableMachineID = objCauHinh.Idmay;
                                var tempError = PrintBarcodeNormal(item, false);
                                if (!string.IsNullOrEmpty(tempError))
                                    error += ((string.IsNullOrEmpty(error) ? Environment.NewLine : "") + tempError);
                            }
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.TIEUCHUAN2))
                        {
                            var printItem = new BarcodeProperties();
                            var tempError = string.Empty;
                            bool addedColumn1 = false;
                            for (int i = 0; i < lstBarcodeInfo.Count; i++)
                            {
                                var item = lstBarcodeInfo[i];
                                printItem = item.CopyInfo();
                                printItem.DanhSachTube = new List<BarcodeTubeDetail>();
                                BarcodeTubeDetail tubeNew = null;
                                printItem.NumberOfCopy = 1;

                                if (item.DanhSachTube.Count > 0)
                                {
                                    foreach (var itemDS in item.DanhSachTube)
                                    {
                                        for (int y = 0; y < item.NumberOfCopy; y++)
                                        {
                                            if (addedColumn1)
                                            {
                                                var fiCheck = itemDS.GetType().GetProperties();
                                                foreach (var itemProp in fiCheck)
                                                {
                                                    var propSet = tubeNew.GetType().GetProperty(itemProp.Name + "2");
                                                    if (propSet != null)
                                                    {
                                                        propSet.SetValue(tubeNew, itemDS.GetType().GetProperty(itemProp.Name).GetValue(itemDS, null), null);
                                                    }
                                                }

                                                printItem.DanhSachTube.Add(tubeNew);
                                                addedColumn1 = false;
                                                tubeNew = null;
                                            }
                                            else
                                            {
                                                tubeNew = new BarcodeTubeDetail();
                                                tubeNew = itemDS.CopyInfo();
                                                addedColumn1 = true;
                                            }
                                        }
                                    }
                                    if (tubeNew != null)
                                    {
                                        printItem.DanhSachTube.Add(tubeNew);
                                    }
                                    tempError = PrintBarcodeNormal(printItem, true);
                                }
                            }
                        }
                        else if (protocol.Equals(PrintingSystemProtocolList.BARTENDER))
                        {
                            foreach (var item in lstBarcodeInfo)
                            {
                                item.LableMachineID = objCauHinh.Idmay;
                                var tempError = PrintBarcodebartender(item);
                                if (!string.IsNullOrEmpty(tempError))
                                    error += ((string.IsNullOrEmpty(error) ? Environment.NewLine : "") + tempError);
                            }
                        }
                        else
                            MessageBox.Show("Giao thức in chưa hỗ trợ!");
                    }
                    else
                        MessageBox.Show("Máy tính chưa khai báo giao thức máy in!");
                }
                else
                {
                    foreach (var item in lstBarcodeInfo)
                    {
                        item.LableMachineID = objCauHinh.Idmay;
                        PrintBarcodeNormal(item, false);
                    }
                }
            }
            else
            {
                foreach (var item in lstBarcodeInfo)
                {
                    item.LableMachineID = (objCauHinh == null ? 0 : objCauHinh.Idmay);
                    PrintBarcodeNormal(item, false);
                }
            }
            if (!string.IsNullOrEmpty(error))
                MessageBox.Show(string.Format("LỖI GỬI CHỈ ĐỊNH ĐẾN HỆ THỐNG IN BARCODE:\n{0}", error));
            return error;
        }
        private string PrintBarcodebartender(BarcodeProperties barcodeInfo)
        {
            if (barcodeInfo.InGhepLoaiMau)
            {
                foreach (var item in barcodeInfo.DanhSachTube)
                {
                    if (!string.IsNullOrEmpty(barcodeInfo.LoaiMauKhongInLenTem))
                    {
                        var arrMauKhongGhep = barcodeInfo.LoaiMauKhongInLenTem.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                        if (arrMauKhongGhep.Contains(item.Tubecode))
                        {
                            if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                                item.Barcode = item.BarcodeName = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", "").Trim();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                                item.Barcode = item.BarcodeName = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", string.IsNullOrEmpty(item.Tubecode) ? "" : item.Tubecode.Trim()).Trim();
                        }
                    }
                    else if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                        item.Barcode = item.BarcodeName = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", string.IsNullOrEmpty(item.Tubecode) ? "" : item.Tubecode.Trim()).Trim();
                }
            }
            return BarcodeBatenderService.Print(barcodeInfo);
        }
        private string PrintBarcodeNormal(BarcodeProperties barcodeInfo, bool splitColumn)
        {
            //            select N'' as HoTen, N'' as GioTinh, getdate() as SinhNhat, 1990 as NamSinh
            //, N'' as MaKhoaPhong, N'' as Buong, N'' as Giuong
            //, N'' as Tubecode,N'' as TubeCate,N'' as TubeCateName,N'' as Tubename
            //, 0 as TubeCount,N'' as NguoiLayMau , getdate() as NgayLayMau,N'' as NhomXetNghiem
            //, N'' as BoPhanXetNghiem ,N'' as Barcode,N'' as BarcodeName
            //, N'' KyTuDanhDau
            string message = string.Empty;
            var dataPrint = new DataTable();
            dataPrint.Columns.Add("HoTen", typeof(string));
            dataPrint.Columns.Add("GioTinh", typeof(string));
            dataPrint.Columns.Add("SinhNhat", typeof(DateTime));
            dataPrint.Columns.Add("NamSinh", typeof(int));
            dataPrint.Columns.Add("MaKhoaPhong", typeof(string));
            dataPrint.Columns.Add("Buong", typeof(string));
            dataPrint.Columns.Add("Giuong", typeof(string));
            dataPrint.Columns.Add("Tubecode", typeof(string));
            dataPrint.Columns.Add("Tubename", typeof(string));
            dataPrint.Columns.Add("TubeCate", typeof(string));
            dataPrint.Columns.Add("TubeCateName", typeof(string));
            dataPrint.Columns.Add("NguoiLayMau", typeof(string));
            dataPrint.Columns.Add("NgayLayMau", typeof(DateTime));
            dataPrint.Columns.Add("TgNhapBN", typeof(DateTime));
            dataPrint.Columns.Add("NgayTiepNhan", typeof(DateTime));
            dataPrint.Columns.Add("NhomXetNghiem", typeof(string));
            dataPrint.Columns.Add("BoPhanXetNghiem", typeof(string));
            dataPrint.Columns.Add("Barcode", typeof(string));
            dataPrint.Columns.Add("BarcodeName", typeof(string));
            dataPrint.Columns.Add("KyTuDanhDau", typeof(string));
            dataPrint.Columns.Add("MaSoMau", typeof(string));

            dataPrint.Columns.Add("Tubecode2", typeof(string));
            dataPrint.Columns.Add("Tubename2", typeof(string));
            dataPrint.Columns.Add("TubeCate2", typeof(string));
            dataPrint.Columns.Add("TubeCateName2", typeof(string));
            dataPrint.Columns.Add("NguoiLayMau2", typeof(string));
            dataPrint.Columns.Add("NgayLayMau2", typeof(DateTime));
            dataPrint.Columns.Add("TgNhapBN2", typeof(DateTime));
            dataPrint.Columns.Add("NhomXetNghiem2", typeof(string));
            dataPrint.Columns.Add("BoPhanXetNghiem2", typeof(string));
            dataPrint.Columns.Add("Barcode2", typeof(string));
            dataPrint.Columns.Add("BarcodeName2", typeof(string));
            dataPrint.Columns.Add("KyTuDanhDau2", typeof(string));
            dataPrint.Columns.Add("MaSoMau2", typeof(string));
            if (barcodeInfo.InGhepLoaiMau)
            {
                foreach (var item in barcodeInfo.DanhSachTube)
                {
                    if (barcodeInfo.InGhepLoaiMau)
                    {
                        if (!string.IsNullOrEmpty(barcodeInfo.LoaiMauKhongInLenTem))
                        {
                            var arrMauKhongGhep = barcodeInfo.LoaiMauKhongInLenTem.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                            if (arrMauKhongGhep.Contains(item.Tubecode))
                            {
                                if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                                    item.Barcode = item.BarcodeName = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", "").Trim();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                                    item.Barcode = item.BarcodeName = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", string.IsNullOrEmpty(item.Tubecode) ? "" : item.Tubecode.Trim()).Trim();
                            }
                            if (splitColumn)
                            {
                                if (arrMauKhongGhep.Contains(item.Tubecode2))
                                {
                                    if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                                        item.Barcode2 = item.BarcodeName2 = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", "").Trim();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                                        item.Barcode2 = item.BarcodeName2 = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", string.IsNullOrEmpty(item.Tubecode2) ? "" : item.Tubecode2.Trim()).Trim();
                                }
                            }
                        }
                        else if (!string.IsNullOrEmpty(barcodeInfo.DinhDangTemGhepLoaiMau))
                        {
                            item.Barcode = item.BarcodeName = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", string.IsNullOrEmpty(item.Tubecode) ? "" : item.Tubecode.Trim()).Trim();
                            if (splitColumn)
                            {
                                item.Barcode2 = item.BarcodeName2 = barcodeInfo.DinhDangTemGhepLoaiMau.Replace("{ID}", barcodeInfo.SoBarcode).Replace("{T}", string.IsNullOrEmpty(item.Tubecode2) ? "" : item.Tubecode2.Trim()).Trim();
                            }
                        }
                    }

                    var data = dataPrint.Clone();
                    var row = data.NewRow();
                    row = SetDataRowninfo(row, barcodeInfo, item);
                    data.Rows.Add(row);
                    message += PrintNormalBarcodeMechine(barcodeInfo, data, item.TubeCount, message);
                }
            }
            else
            {
                var data = dataPrint.Clone();
                var itemmFirst = barcodeInfo.DanhSachTube.FirstOrDefault();
                var row = data.NewRow();
                row = SetDataRowninfo(row, barcodeInfo, itemmFirst);
                data.Rows.Add(row);
                int subTubceCount = 0;
                foreach (var item in barcodeInfo.DanhSachTube)
                {
                    subTubceCount += item.TubeCount;
                }
                message += PrintNormalBarcodeMechine(barcodeInfo, data, subTubceCount, message);
            }

            return message;
        }
        private DataRow SetDataRowninfo(DataRow row, BarcodeProperties barcodeInfo, BarcodeTubeDetail itemTube)
        {
            row["HoTen"] = barcodeInfo.PatientName;
            row["GioTinh"] = barcodeInfo.GioiTinh;
            row["SinhNhat"] = barcodeInfo.NgaySinh_DateTime ?? (object)DBNull.Value;
            row["NamSinh"] = int.Parse(string.IsNullOrEmpty(barcodeInfo.NamSinh) ? "0" : barcodeInfo.NamSinh);
            row["MaKhoaPhong"] = barcodeInfo.MaKhoaPhong;
            row["Buong"] = barcodeInfo.SoPhong;
            row["Giuong"] = barcodeInfo.SoGiuong;
            row["NgayTiepNhan"] = barcodeInfo.NgayTiepNhan;
            row["TgNhapBN"] = barcodeInfo.TgNhapBN;

            row["Tubecode"] = itemTube.Tubecode;
            row["Tubename"] = itemTube.Tubename;
            row["TubeCate"] = itemTube.TubeCate;
            row["TubeCateName"] = itemTube.TubeCateName;
            row["NguoiLayMau"] = itemTube.NguoiLayMau;
            row["NgayLayMau"] = itemTube.NgayLayMau ?? (object)DBNull.Value;
            row["NhomXetNghiem"] = itemTube.NhomXetNghiem;
            row["BoPhanXetNghiem"] = itemTube.BoPhanXetNghiem;
            row["Barcode"] = itemTube.Barcode;
            row["BarcodeName"] = itemTube.BarcodeName;
            row["KyTuDanhDau"] = itemTube.KyTuDanhDau;
            row["MaSoMau"] = itemTube.MaSoMau;

            row["Tubecode2"] = itemTube.Tubecode2;
            row["Tubename2"] = itemTube.Tubename2;
            row["TubeCate2"] = itemTube.TubeCate2;
            row["TubeCateName2"] = itemTube.TubeCateName2;
            row["NguoiLayMau2"] = itemTube.NguoiLayMau2;
            row["NgayLayMau2"] = itemTube.NgayLayMau2 ?? (object)DBNull.Value;
            row["TgNhapBN2"] = itemTube.TgNhapBN2;
            row["NhomXetNghiem2"] = itemTube.NhomXetNghiem2;
            row["BoPhanXetNghiem2"] = itemTube.BoPhanXetNghiem2;
            row["Barcode2"] = itemTube.Barcode2;
            row["BarcodeName2"] = itemTube.BarcodeName2;
            row["KyTuDanhDau2"] = itemTube.KyTuDanhDau2;
            row["MaSoMau2"] = itemTube.MaSoMau2;

           return row;
        }
        private string PrintNormalBarcodeMechine(BarcodeProperties barcodeInfo, DataTable data, int TubeCount, string message)
        {
            byte[] barcodeReport = null;
            if (dicRepoprt.ContainsKey(barcodeInfo.LoaiTem.ToString()))
            {
                if (dicRepoprt[barcodeInfo.LoaiTem.ToString()] == null)
                {
                    ibarcode.GetReport_SuDung_TheoCauHinh(Environment.MachineName, (int)barcodeInfo.LoaiTem, ref normalreportprinterName, ref barcodeReport);
                    dicRepoprt[barcodeInfo.LoaiTem.ToString()] = barcodeReport;
                }
                else
                    barcodeReport = dicRepoprt[barcodeInfo.LoaiTem.ToString()];
            }
            else
            {
                ibarcode.GetReport_SuDung_TheoCauHinh(Environment.MachineName, (int)barcodeInfo.LoaiTem, ref normalreportprinterName, ref barcodeReport);
                if (!dicRepoprt.ContainsKey(barcodeInfo.LoaiTem.ToString()))
                    dicRepoprt.Add(barcodeInfo.LoaiTem.ToString(), barcodeReport);
            }
            if (barcodeReport != null)
            {
                var report = CreateReportFromStream(barcodeReport);

                data.TableName = "CustomSqlQuery";
                var dataSet = new DataSet("IMSDataSet");
                dataSet.Tables.Add(data);
                report.DataSource = dataSet;

                var rpt = new ReportPrintTool(report);
                rpt.PrinterSettings.PrinterName = normalreportprinterName;
                rpt.PrinterSettings.Copies = (short)TubeCount;
               
                try
                {
                    WriteLog.LogService.RecordLogFile("BarcodePrinting", string.Format("Inbarcode: {0} - Máy in: {1} - Copy: {2}", barcodeInfo.SoBarcode, normalreportprinterName, TubeCount));
                    rpt.Print();
                    WriteLog.LogService.RecordLogFile("BarcodePrinting", string.Format("Inbarcode - Finished: {0} - Máy in: {1} - Copy: {2}", barcodeInfo.SoBarcode, normalreportprinterName, TubeCount));
                }
                catch (Exception ex)
                {
                    WriteLog.LogService.RecordLogFile(String.Format("Lỗi khi in barcode: {0} \n{1}", barcodeInfo.SoBarcode, ex.Message));
                    message += (string.IsNullOrEmpty(message) ? "" : "\n") + ex.Message;
                }
            }
            else
                message += (string.IsNullOrEmpty(message) ? "" : "\n") + "Report chưa khai báo";

            return message;
        }
        public XtraReport CreateReportFromStream(byte[] byteArray)
        {
            MemoryStream stream = new MemoryStream(byteArray);
            var report = XtraReport.FromStream(stream, true);
            return report;
        }
    }
}
