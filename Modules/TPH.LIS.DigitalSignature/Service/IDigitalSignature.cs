using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.LIS.DigitalSignature.Models;

namespace TPH.LIS.DigitalSignature.Service
{
    public interface IDigitalSignature
    {
        int InsertSignature(THONGTINFILEKY obj);
        int InsertSignature_KSLD(THONGTINFILEKY obj);
        int UpdateDaKy_KSLD(THONGTINFILEKY obj);
        DataTable GetFileListDB(string barcode, string mabn, DateTime ngayIn);
        DataTable GetFileInfoByID(long id, bool fromArchive);
        THONGTINFILEKY Get_Info_ThongTinFileKy(DataRow dr);
        List<THONGTINFILEKY> DanhSachUpload();
        int UpdateDaUpload(long id);

        int UpdateReUpload(long id, bool isArchive);

        string ReWritePdf(string fullPath, string sampleId = "", bool digiSign = false);
        List<string> GetSignatureInfoInPdf(byte[] pfdContent);
        string GetFileIDFromPdfFile(string fullPath);
        string GetFileIDFromPdfFile(byte[] content);
        DataTable GetFileFromDB(string maTiepNhan,bool CKS2 = false);
        //ID File ký số
        DataTable GetDataKySo(string maTiepNhan, string conditSomeTestPrint, bool isVSNC);
        DataTable GetDataKySoByTenFileHIS(string maTiepNhan, string tenFileHIS);

        int UpdateXetNghiemKySo(THONGTINFILEKY obj);
    }
}
