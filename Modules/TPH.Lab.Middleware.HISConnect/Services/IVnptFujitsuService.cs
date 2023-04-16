using System.Collections.Generic;
using TPH.Data.HIS.Models;
using TPH.Lab.Middleware.HISConnect.Models.Vft;
using TPH.LIS.Common.Model;

namespace TPH.Lab.Middleware.HISConnect.Services
{
    public interface IVnptFujitsuService
    { 
        string DangNhap(HisConnection hisConnect);
        IList<VftTestingModel> DanhMucXetNghiem(HisConnection hisConnect);
        IList<BaseModel> DanhMucBacSi(HisConnection hisConnect);
        IList<BaseModel> DanhMucKhoa(HisConnection hisConnect);
        IList<BaseModel> DanhMucPhong(HisConnection hisConnect);
        IList<BaseModel> DanhMucDoiTuong(HisConnection hisConnect);
        IList<VftDiseaseInfo> DanhMucChanDoan(HisConnection hisConnect);
        IList<VftOrderInfo> DownloadChiDinh(DownloadOrderParams requestParams, HisConnection hisConnect);
        IList<VftOrderInfo> DownloadChiTietChiDinh(string soPhieuYeuCau, HisConnection hisConnect);
        BaseModel CapNhatTrangThaiChiDinh(List<UpdateOrderStatusParams> updateInfo, HisConnection hisConnect);
        BaseModel UploadKetQuaChiDinh(List<UploadOrderParams> resultInfo, HisConnection hisConnect);
    }
}
