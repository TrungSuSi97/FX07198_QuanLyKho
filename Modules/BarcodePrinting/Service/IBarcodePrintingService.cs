using System.Collections.Generic;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Patient.Model;

namespace TPH.LIS.BarcodePrinting.Service
{
    public interface IBarcodePrintingService
    {
        string Printbarcode(DM_MAYTINH_MAYIN objCauHinh
           , BarcodeProperties barcodeInfo, List<KETQUA_CLS_XETNGHIEM> lstChiDinhXN = null);
        string Printbarcode(DM_MAYTINH_MAYIN objCauHinh
       ,List< BarcodeProperties> lstBarcodeInfo, List<KETQUA_CLS_XETNGHIEM> lstChiDinhXN = null);
    }
}
