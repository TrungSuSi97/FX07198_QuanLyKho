using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Common.Converter;
using TPH.LIS.Data;
using TPH.LIS.DigitalSignature.Models;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common;
using System.Security.Cryptography.X509Certificates;

namespace TPH.LIS.DigitalSignature.Service.Impl
{
    public class DigitalSignatureService : IDigitalSignature
    {
        public int InsertSignature(THONGTINFILEKY obj)
        {
            var sqlPara = new[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", obj.Matiepnhan)
                ,WorkingServices.GetParaFromOject("@MaHoSo", obj.Mahoso)
                ,WorkingServices.GetParaFromOject("@MaBn", obj.Mabn)
                ,WorkingServices.GetParaFromOject("@SoPhieu", obj.Sophieu)
                ,WorkingServices.GetParaFromOject("@NgayTaoPhieu", obj.Ngaytaophieu ?? ServerDate())
                ,WorkingServices.GetParaFromOject("@TrangThai", obj.Trangthai)
                ,WorkingServices.GetParaFromOject("@UserKy", obj.Userky)
                ,WorkingServices.GetParaFromOject("@LoaiKy", obj.Loaiky)
                ,WorkingServices.GetParaFromOject("@NgayKy", obj.Ngayky)
                ,WorkingServices.GetParaFromOject("@LanKy", obj.Lanky)
                ,WorkingServices.GetParaFromOject("@PdfFileID", obj.Pdffileid)
                ,WorkingServices.GetParaFromOject("@PDFContent", obj.Pdfcontent)
                ,WorkingServices.GetParaFromOject("@MoTa", obj.MoTa)
                ,WorkingServices.GetParaFromOject("@LanKQ", obj.LanInKQ)
                ,WorkingServices.GetParaFromOject("@pcname", obj.PCName)
                ,WorkingServices.GetParaFromOject("@useraction", obj.UserAction)
                ,WorkingServices.GetParaFromOject("@loaiPhieu", obj.LoaiPhieu)
                ,WorkingServices.GetParaFromOject("@DaUpload", obj.Daupload)
                ,WorkingServices.GetParaFromOject("@LoaiXetNghiem", obj.LoaiXetNghiem)
                ,WorkingServices.GetParaFromOject("@SoPhieuChiDinh", obj.SoPhieuChiDinh)
                ,WorkingServices.GetParaFromOject("@TenFileHIS", obj.TenFileHIS)
                ,WorkingServices.GetParaFromOject("@TenFileLIS", obj.TenFileLIS)
            };
            if (obj.LoaiXetNghiem == (int)TestType.EnumTestType.Covid19 || obj.LoaiXetNghiem == (int)TestType.EnumTestType.KhangNguyenCovid)
                return (int)DataProvider.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "insChuKySo_ThemThongTinFileKy_CKS_LanMot", sqlPara);
            else
                return (int)DataProvider.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "insChuKySo_ThemThongTinFileKy", sqlPara);
        }
        public int InsertSignature_KSLD(THONGTINFILEKY obj)
        {
            var sqlPara = new[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", obj.Matiepnhan)
                ,WorkingServices.GetParaFromOject("@MaHoSo", obj.Mahoso)
                ,WorkingServices.GetParaFromOject("@MaBn", obj.Mabn)
                ,WorkingServices.GetParaFromOject("@SoPhieu", obj.Sophieu)
                ,WorkingServices.GetParaFromOject("@NgayTaoPhieu", obj.Ngaytaophieu ?? ServerDate())
                ,WorkingServices.GetParaFromOject("@TrangThai", obj.Trangthai)
                ,WorkingServices.GetParaFromOject("@UserKy", obj.Userky)
                ,WorkingServices.GetParaFromOject("@LoaiKy", obj.Loaiky)
                ,WorkingServices.GetParaFromOject("@NgayKy", obj.Ngayky)
                ,WorkingServices.GetParaFromOject("@LanKy", obj.Lanky)
                ,WorkingServices.GetParaFromOject("@PdfFileID", obj.Pdffileid)
                ,WorkingServices.GetParaFromOject("@PDFContent", obj.Pdfcontent)
                ,WorkingServices.GetParaFromOject("@MoTa", obj.MoTa)
                ,WorkingServices.GetParaFromOject("@LanKQ", obj.LanInKQ)
                ,WorkingServices.GetParaFromOject("@pcname", obj.PCName)
                ,WorkingServices.GetParaFromOject("@useraction", obj.UserAction)
                ,WorkingServices.GetParaFromOject("@loaiPhieu", obj.LoaiPhieu)
                ,WorkingServices.GetParaFromOject("@DaUpload", obj.Daupload)
                ,WorkingServices.GetParaFromOject("@LoaiXetNghiem", obj.LoaiXetNghiem)
                ,WorkingServices.GetParaFromOject("@SoPhieuChiDinh", obj.SoPhieuChiDinh)
                ,WorkingServices.GetParaFromOject("@TenFileHIS", obj.TenFileHIS)
                ,WorkingServices.GetParaFromOject("@TenFileLIS", obj.TenFileLIS)
            };
            return (int)DataProvider.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "insChuKySo_ThemThongTinFileKy", sqlPara);
        }
        public int UpdateDaKy_KSLD(THONGTINFILEKY obj)
        {
          var sqlPara = new[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", obj.Matiepnhan)
                ,WorkingServices.GetParaFromOject("@PdfFileID", obj.Pdffileid)
                ,WorkingServices.GetParaFromOject("@LoaiXetNghiem", obj.LoaiXetNghiem)
            };
            return (int)DataProvider.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "updChuKySo_DaKy_KSLD", sqlPara);
        }
        public DataTable GetFileFromDB(string maTiepNhan, bool CKS2 = false)
        {
            //var sqlQuery = string.Empty;
            //if (CKS2)
            //{
            //    sqlQuery = "SELECT * FROM [DigitalSignature].[dbo].[ThongTinFileKy]";
            //    sqlQuery += string.Format("\n where MaTiepNhan = '{0}'", maTiepNhan);
            //    sqlQuery += string.Format("\n order by NgayKy desc");
            //}
            //else
            //{
            //    //Lấy dòng có NgayKy gan nhất và chưa upload
            //    sqlQuery = "SELECT * FROM [DigitalSignature].[dbo].[ThongTinFileKy_CKS_LanMot]";
            //    sqlQuery += string.Format("\n where MaTiepNhan = '{0}'", maTiepNhan);
            //    sqlQuery += string.Format("\n AND DaKyCKS_LD = {0}", 0);
            //    sqlQuery += string.Format("\n order by NgayKy desc");
            //}
            var sqlPara = new[]
           {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
            };

            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selGetFileFromDB", sqlPara).Tables[0];
            return data ?? null;
        }

        public DataTable GetFileListDB(string barcode, string mabn, DateTime ngayIn)
        {
            var sqlPara = new[]
           {
                WorkingServices.GetParaFromOject("@Barcode", barcode),
                WorkingServices.GetParaFromOject("@MaBn", mabn),
                WorkingServices.GetParaFromOject("@NgayIn", ngayIn.Date)
            };

            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selGetFileListByBarcode", sqlPara).Tables[0];
            return data ?? null;
        }
        public DataTable GetFileInfoByID(long id, bool fromArchive)
        {
            var sqlPara = new[]
           {
                WorkingServices.GetParaFromOject("@Id", id),
                 WorkingServices.GetParaFromOject("@isArchive", fromArchive)
            };

            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selGetFileInfoById", sqlPara).Tables[0];
            return data ?? null;
        }
        public static DateTime ServerDate()
        {
            string strSQL = "Select Getdate() as ServerDate";
            var dt = DataProvider.ExecuteScalar(CommandType.Text, strSQL);

            DateTime svrDate = (DateTime)dt;
            return svrDate;
        }
        public List<THONGTINFILEKY> DanhSachUpload()
        {
            var lst = new List<THONGTINFILEKY>();
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuKySo_DanhSachUpload");
            if (data == null) return lst;

            var dataTable = data.Tables[0];
            foreach (DataRow dr in dataTable.Rows)
            {
                lst.Add(Get_Info_ThongTinFileKy(dr));
            }
            return lst;
        }
        public THONGTINFILEKY Get_Info_ThongTinFileKy(DataRow dr)
        {
            return (THONGTINFILEKY)WorkingServices.Get_InfoForObject(new THONGTINFILEKY(), dr);
        }
        public int UpdateDaUpload(long id)
        {
            var sqlPara = new[]
                {
                        WorkingServices.GetParaFromOject("@ID", id)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updChuKySo_CapNhatDaUpload", sqlPara);
        }
        public int UpdateReUpload(long id, bool isArchive)
        {
            var sqlPara = new[]
                {
                      WorkingServices.GetParaFromOject("@ID", id),
                 WorkingServices.GetParaFromOject("@isArchive", isArchive)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updChuKySo_CapNhatReUpload", sqlPara);
        }
        public string ReWritePdf(string fullPath, string sampleId = "", bool digiSign = false)
        {
            var newValue = "_Final.pdf";
            if (!string.IsNullOrEmpty(sampleId))
            {
                var obj = DataProvider.ExecuteScalar(CommandType.StoredProcedure,
                    "selCountTimeUpl", WorkingServices.GetParaFromOject("@sampleId", sampleId));
                var number = 1;
                if (obj != null && !DBNull.Value.Equals(obj))
                {
                    number = NumberConverter.ToInt(obj) + 1;
                }

                newValue = $"_{number}.pdf";
            }

            var neFilename = fullPath.ToLower().Replace(".pdf", newValue);
            if (!digiSign)
            {
                using (var reader = new PdfReader(fullPath))
                {
                    var document = new Document();
                    var copy = new PdfCopy(document, new FileStream(neFilename, FileMode.Create));
                    document.Open();

                    for (var pagenumber = 1; pagenumber <= reader.NumberOfPages; pagenumber++)
                    {
                        if (reader.NumberOfPages >= pagenumber)
                        {
                            copy.AddPage(copy.GetImportedPage(reader, pagenumber));
                        }
                        else
                        {
                            break;
                        }

                    }
                    //    reader.IsRebuilt();
                    copy.Close();
                    document.Close();
                }
                File.Delete(fullPath);
            }
            else
            {
                File.Copy(fullPath, neFilename);
                File.Delete(fullPath);
            }
            return neFilename;
        }
        public List<string> GetSignatureInfoInPdf(byte[] pfdContent)
        {
            PdfReader pdf = new PdfReader(pfdContent);
            AcroFields acroFields = pdf.AcroFields;
            List<string> names = acroFields.GetSignatureNames();
            var lst = new List<string>();
            foreach (var name in names)
            {
              var info = acroFields.GetSignatureDictionary(name);
                if(info != null)
                    lst.Add(String.Format("Đã ký số bởi: {0}", name));
            }
            return lst;
        }
        public string GetFileIDFromPdfFile(string fullPath)
        {
            var sb = new StringBuilder();
            var pdfReader = new PdfReader(fullPath);
            var id = pdfReader.Trailer.GetAsArray(PdfName.ID);
            foreach (var item in id)
            {
                sb.Append("<");
                foreach (var b in ((PdfString)item).GetBytes())
                    sb.Append(string.Format("{0:X}", b));
                sb.Append(">");
            }
            pdfReader.Close();
            return sb.ToString();
        }
        public string GetFileIDFromPdfFile(byte[] content)
        {
            var sb = new StringBuilder();
            var pdfReader = new PdfReader(content);
            var id = pdfReader.Trailer.GetAsArray(PdfName.ID);
            foreach (var item in id)
            {
                sb.Append("<");
                foreach (var b in ((PdfString)item).GetBytes())
                    sb.Append(string.Format("{0:X}", b));
                sb.Append(">");
            }
            pdfReader.Close();
            return sb.ToString();
        }
        //Lấy id file ký
        public DataTable GetDataKySo(string maTiepNhan, string conditSomeTestPrint, bool isVSNC)
        {
            var sqlPara = new[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@ConditSomeTestPrint", conditSomeTestPrint),
                WorkingServices.GetParaFromOject("@IsVSNC", isVSNC)
            };

            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDataKySo", sqlPara);
            return data.Tables.Count > 0 ? data.Tables[0] : new DataTable();
        }
        public DataTable GetDataKySoByTenFileHIS(string maTiepNhan, string tenFileHIS)
        {
            var sqlPara = new[]
           {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@TenFileHIS", tenFileHIS)
            };

            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDataKySoByTenFileHIS", sqlPara);
            return data.Tables.Count > 0 ? data.Tables[0] : new DataTable();
        }
        public int UpdateXetNghiemKySo(THONGTINFILEKY obj)
        {
            var sqlPara = new[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", obj.Matiepnhan),
                WorkingServices.GetParaFromOject("@DigitialTests", obj.DigitialTests),
                WorkingServices.GetParaFromOject("@TenFileHIS", obj.TenFileHIS),
                WorkingServices.GetParaFromOject("@TenFileLIS", obj.TenFileLIS),
                WorkingServices.GetParaFromOject("@LoaiXetNghiem", obj.LoaiXetNghiem)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiemKySo", sqlPara);
        }
    }
}
