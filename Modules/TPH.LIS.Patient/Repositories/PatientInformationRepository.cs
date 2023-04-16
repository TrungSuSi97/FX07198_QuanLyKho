using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Data;
using TPH.LIS.Log;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Model;
using TPH.LIS.User.Enum;

namespace TPH.LIS.Patient.Repositories
{
    public class PatientInformationRepository : IPatientInformationRepository
    {
        public readonly IWorkingLogService _workingLog = new WorkingLogService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();
        #region Thông tin bệnh nhân
        public DataTable DanhSachBenhNhan(string maBn)
        {
            var para = new SqlParameter[]
                {
                      WorkingServices.GetParaFromOject("@MaBn", maBn)
                };

            var dtData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_BenhNhan", para);
            if (dtData == null)
                return null;
            else
                return dtData.Tables[0];
        }
        public int InsertBenhNhan(string maBn, string maTiepNhan)
        {
            var para = new SqlParameter[]
                   {
                      WorkingServices.GetParaFromOject("@MaBn", maBn),
                      WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                   };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_BenhNhanThongTin", para);
        }
        public int DeleteBenhNhan(string maBn)
        {
            var para = new SqlParameter[]
                   {
                      WorkingServices.GetParaFromOject("@MaBn", maBn)
                   };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_BenhNhan", para);
        }
        #endregion
        #region Thông tin tiếp nhận
        public bool Insert_BenhNhan_TiepNhan(BENHNHAN_TIEPNHAN objInfo, bool showmMess)
        {
            var para = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@MaTiepNhan",objInfo.Matiepnhan),
                WorkingServices.GetParaFromOject("@Seq", WorkingServices.ConvertObjectForSQPara(objInfo.Seq)),
                WorkingServices.GetParaFromOject("@NoiTru",WorkingServices.ConvertObjectForSQPara(objInfo.Noitru)),
                WorkingServices.GetParaFromOject("@MaBN ",WorkingServices.ConvertObjectForSQPara(objInfo.Mabn)),
                WorkingServices.GetParaFromOject("@SoBHYT",WorkingServices.ConvertObjectForSQPara(objInfo.Sobhyt)),
                WorkingServices.GetParaFromOject("@NgayHetHanBHYT",objInfo.Ngayhethanbhyt,false, true),
                WorkingServices.GetParaFromOject("@TenBN ",WorkingServices.ConvertObjectForSQPara(objInfo.Tenbn)),
                WorkingServices.GetParaFromOject("@SinhNhat",objInfo.Sinhnhat,false, true),
                WorkingServices.GetParaFromOject("@Tuoi",WorkingServices.ConvertObjectForSQPara(objInfo.Tuoi)),
                WorkingServices.GetParaFromOject("@CoNgaySinh",WorkingServices.ConvertObjectForSQPara(objInfo.Congaysinh)),
                WorkingServices.GetParaFromOject("@GioiTinh",WorkingServices.ConvertObjectForSQPara(objInfo.Gioitinh)),
                WorkingServices.GetParaFromOject("@NgayTiepNhan",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaytiepnhan, true)),
                WorkingServices.GetParaFromOject("@UserNhap",WorkingServices.ConvertObjectForSQPara(objInfo.Usernhap)),
                WorkingServices.GetParaFromOject("@DoiTuongDichVu",WorkingServices.ConvertObjectForSQPara(objInfo.Doituongdichvu)),
                WorkingServices.GetParaFromOject("@DiaChi",WorkingServices.ConvertObjectForSQPara(objInfo.Diachi)),
                WorkingServices.GetParaFromOject("@SoNha",WorkingServices.ConvertObjectForSQPara(objInfo.Sonha)),
                WorkingServices.GetParaFromOject("@PhuongXa",WorkingServices.ConvertObjectForSQPara(objInfo.Phuongxa)),
                WorkingServices.GetParaFromOject("@MaHuyen",WorkingServices.ConvertObjectForSQPara(objInfo.Mahuyen)),
                WorkingServices.GetParaFromOject("@MaTinh",WorkingServices.ConvertObjectForSQPara(objInfo.Matinh)),
                WorkingServices.GetParaFromOject("@Email",WorkingServices.ConvertObjectForSQPara(objInfo.Email)),
                WorkingServices.GetParaFromOject("@SDT",WorkingServices.ConvertObjectForSQPara(objInfo.Sdt)),
                WorkingServices.GetParaFromOject("@DaGuiMail",WorkingServices.ConvertObjectForSQPara(objInfo.Daguimail)),
                WorkingServices.GetParaFromOject("@TGGuiMail",WorkingServices.ConvertObjectForSQPara(objInfo.Tgguimail)),
                WorkingServices.GetParaFromOject("@DichVuKhamBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvukhambenh)),
                WorkingServices.GetParaFromOject("@DichVuXetNghiem",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvuxetnghiem)),
                WorkingServices.GetParaFromOject("@DichVuXQuang",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvuxquang)),
                WorkingServices.GetParaFromOject("@DichVuSieuAm",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvusieuam)),
                WorkingServices.GetParaFromOject("@DichVuNoiSoi",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvunoisoi)),
                WorkingServices.GetParaFromOject("@DichVuDienTim",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvudientim)),
                WorkingServices.GetParaFromOject("@DichVuKhac",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvukhac)),
                WorkingServices.GetParaFromOject("@KhamLanDau",WorkingServices.ConvertObjectForSQPara(objInfo.Khamlandau)),
                WorkingServices.GetParaFromOject("@TGVaoVien",WorkingServices.ConvertObjectForSQPara(objInfo.Tgvaovien)),
                WorkingServices.GetParaFromOject("@YeuCau",WorkingServices.ConvertObjectForSQPara(objInfo.Yeucau)),
                WorkingServices.GetParaFromOject("@MaDonVi",WorkingServices.ConvertObjectForSQPara(objInfo.Madonvi)),
                WorkingServices.GetParaFromOject("@TenDonVi",WorkingServices.ConvertObjectForSQPara(objInfo.Tendonvi)),
                WorkingServices.GetParaFromOject("@TienSuBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Tiensubenh)),
                WorkingServices.GetParaFromOject("@TinhTrangBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Tinhtrangbenh)),
                WorkingServices.GetParaFromOject("@NhanXetBS",WorkingServices.ConvertObjectForSQPara(objInfo.Nhanxetbs)),
                WorkingServices.GetParaFromOject("@UserCapNhat",WorkingServices.ConvertObjectForSQPara(objInfo.Usercapnhat)),
                WorkingServices.GetParaFromOject("@BacSiCD",WorkingServices.ConvertObjectForSQPara(objInfo.Bacsicd)),
                WorkingServices.GetParaFromOject("@ChanDoan",WorkingServices.ConvertObjectForSQPara(objInfo.Chandoan)),
                WorkingServices.GetParaFromOject("@Sent",WorkingServices.ConvertObjectForSQPara(objInfo.Sent)),
                WorkingServices.GetParaFromOject("@nguonnhap",WorkingServices.ConvertObjectForSQPara(objInfo.Nguonnhap)),
                WorkingServices.GetParaFromOject("@datesent",WorkingServices.ConvertObjectForSQPara(objInfo.Datesent)),
                WorkingServices.GetParaFromOject("@chietkhau",WorkingServices.ConvertObjectForSQPara(objInfo.Chietkhau)),
                WorkingServices.GetParaFromOject("@SoPhieuYeuCau",WorkingServices.ConvertObjectForSQPara(objInfo.Sophieuyeucau)),
                WorkingServices.GetParaFromOject("@mamayin",WorkingServices.ConvertObjectForSQPara(objInfo.Mamayin)),
                WorkingServices.GetParaFromOject("@ngaydk",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaydk)),
                WorkingServices.GetParaFromOject("@allowdownload",WorkingServices.ConvertObjectForSQPara(objInfo.Allowdownload)),
                WorkingServices.GetParaFromOject("@makhuvuc",WorkingServices.ConvertObjectForSQPara(objInfo.Makhuvuc)),
                WorkingServices.GetParaFromOject("@dotkham_id",WorkingServices.ConvertObjectForSQPara(objInfo.Dotkham_id)),
                WorkingServices.GetParaFromOject("@chuyenkhoa_id",WorkingServices.ConvertObjectForSQPara(objInfo.Chuyenkhoa_id)),
                WorkingServices.GetParaFromOject("@giayto_id",WorkingServices.ConvertObjectForSQPara(objInfo.Giayto_id)),
                WorkingServices.GetParaFromOject("@bn_id",WorkingServices.ConvertObjectForSQPara(objInfo.Bn_id)),
                WorkingServices.GetParaFromOject("@manoicapthebhyt",WorkingServices.ConvertObjectForSQPara(objInfo.Manoicapthebhyt)),
                WorkingServices.GetParaFromOject("@manoidangkythebhyt",WorkingServices.ConvertObjectForSQPara(objInfo.Manoidangkythebhyt)),
                WorkingServices.GetParaFromOject("@Giuong",WorkingServices.ConvertObjectForSQPara(objInfo.Giuong)),
                WorkingServices.GetParaFromOject("@Buong",WorkingServices.ConvertObjectForSQPara(objInfo.Buong)),
                WorkingServices.GetParaFromOject("@capcuu",WorkingServices.ConvertObjectForSQPara(objInfo.Capcuu)),
                WorkingServices.GetParaFromOject("@IdCongDan",WorkingServices.ConvertObjectForSQPara(objInfo.Idcongdan)),
                WorkingServices.GetParaFromOject("@DaThuTien",WorkingServices.ConvertObjectForSQPara(objInfo.Dathutien)),
                WorkingServices.GetParaFromOject("@TongThanhTien",WorkingServices.ConvertObjectForSQPara(objInfo.Tongthanhtien)),
                WorkingServices.GetParaFromOject("@DoiTuong",WorkingServices.ConvertObjectForSQPara(objInfo.Doituong)),
                WorkingServices.GetParaFromOject("@HisProviderID",WorkingServices.ConvertObjectForSQPara(objInfo.Hisproviderid)),
                WorkingServices.GetParaFromOject("@ABO",WorkingServices.ConvertObjectForSQPara(objInfo.Abo)),
                WorkingServices.GetParaFromOject("@Rh",WorkingServices.ConvertObjectForSQPara(objInfo.Rh)),
                WorkingServices.GetParaFromOject("@MaDonViHopDong",WorkingServices.ConvertObjectForSQPara(objInfo.Madonvihopdong)),
                WorkingServices.GetParaFromOject("@TenDonviHopDong",WorkingServices.ConvertObjectForSQPara(objInfo.Tendonvihopdong)),
                WorkingServices.GetParaFromOject("@MaSoPhong",WorkingServices.ConvertObjectForSQPara(objInfo.Masophong)),
                WorkingServices.GetParaFromOject("@TenPhong",WorkingServices.ConvertObjectForSQPara(objInfo.Tenphong)),
                WorkingServices.GetParaFromOject("@UuTien",WorkingServices.ConvertObjectForSQPara(objInfo.Uutien)),
                WorkingServices.GetParaFromOject("@BenhKemtheo",WorkingServices.ConvertObjectForSQPara(objInfo.Benhkemtheo)),
                WorkingServices.GetParaFromOject("@MaKhoaHienThoi",WorkingServices.ConvertObjectForSQPara(objInfo.Makhoahienthoi)),
                WorkingServices.GetParaFromOject("@TenKhoaHienThoi",WorkingServices.ConvertObjectForSQPara(objInfo.Tenkhoahienthoi)),
                WorkingServices.GetParaFromOject("@NoiCongTac",WorkingServices.ConvertObjectForSQPara(objInfo.Noicongtac)),
                WorkingServices.GetParaFromOject("@KhamSucKhoe",WorkingServices.ConvertObjectForSQPara(objInfo.Khamsuckhoe)),
                WorkingServices.GetParaFromOject("@NgayNhapVien",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaynhapvien)),
                WorkingServices.GetParaFromOject("@QuocTich",WorkingServices.ConvertObjectForSQPara(objInfo.Quoctich)),
                WorkingServices.GetParaFromOject("@MaCongTacVien",WorkingServices.ConvertObjectForSQPara(objInfo.MaCongTacVien)),
                WorkingServices.GetParaFromOject("@NgayCapHoChieu",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaycaphochieu)),
                WorkingServices.GetParaFromOject("@MaSinhLy",WorkingServices.ConvertObjectForSQPara(objInfo.Masinhly)),
                WorkingServices.GetParaFromOject("@TenSinhLy",WorkingServices.ConvertObjectForSQPara(objInfo.Tensinhly)),
                WorkingServices.GetParaFromOject("@ChieuCao",WorkingServices.ConvertObjectForSQPara(objInfo.Chieucao)),
                WorkingServices.GetParaFromOject("@CanNang",WorkingServices.ConvertObjectForSQPara(objInfo.Cannang))
                };
            
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insInsert_BenhNhanTiepNhan", para) > -1;

        }
        public bool Insert_BenhNhan_TuMau(BENHNHAN_TIEPNHAN objInfo, bool showmMess)
        {
            var para = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@MaTiepNhan",objInfo.Matiepnhan),
                WorkingServices.GetParaFromOject("@Seq", WorkingServices.ConvertObjectForSQPara(objInfo.Seq)),
                WorkingServices.GetParaFromOject("@NoiTru",WorkingServices.ConvertObjectForSQPara(objInfo.Noitru)),
                WorkingServices.GetParaFromOject("@MaBN ",WorkingServices.ConvertObjectForSQPara(objInfo.Mabn)),
                WorkingServices.GetParaFromOject("@SoBHYT",WorkingServices.ConvertObjectForSQPara(objInfo.Sobhyt)),
                WorkingServices.GetParaFromOject("@NgayHetHanBHYT",objInfo.Ngayhethanbhyt,false, true),
                WorkingServices.GetParaFromOject("@TenBN ",WorkingServices.ConvertObjectForSQPara(objInfo.Tenbn)),
                WorkingServices.GetParaFromOject("@SinhNhat",objInfo.Sinhnhat,false, true),
                WorkingServices.GetParaFromOject("@Tuoi",WorkingServices.ConvertObjectForSQPara(objInfo.Tuoi)),
                WorkingServices.GetParaFromOject("@CoNgaySinh",WorkingServices.ConvertObjectForSQPara(objInfo.Congaysinh)),
                WorkingServices.GetParaFromOject("@GioiTinh",WorkingServices.ConvertObjectForSQPara(objInfo.Gioitinh)),
                WorkingServices.GetParaFromOject("@NgayTiepNhan",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaytiepnhan, true)),
                WorkingServices.GetParaFromOject("@UserNhap",WorkingServices.ConvertObjectForSQPara(objInfo.Usernhap)),
                WorkingServices.GetParaFromOject("@DoiTuongDichVu",WorkingServices.ConvertObjectForSQPara(objInfo.Doituongdichvu)),
                WorkingServices.GetParaFromOject("@DiaChi",WorkingServices.ConvertObjectForSQPara(objInfo.Diachi)),
                WorkingServices.GetParaFromOject("@SoNha",WorkingServices.ConvertObjectForSQPara(objInfo.Sonha)),
                WorkingServices.GetParaFromOject("@PhuongXa",WorkingServices.ConvertObjectForSQPara(objInfo.Phuongxa)),
                WorkingServices.GetParaFromOject("@MaHuyen",WorkingServices.ConvertObjectForSQPara(objInfo.Mahuyen)),
                WorkingServices.GetParaFromOject("@MaTinh",WorkingServices.ConvertObjectForSQPara(objInfo.Matinh)),
                WorkingServices.GetParaFromOject("@Email",WorkingServices.ConvertObjectForSQPara(objInfo.Email)),
                WorkingServices.GetParaFromOject("@SDT",WorkingServices.ConvertObjectForSQPara(objInfo.Sdt)),
                WorkingServices.GetParaFromOject("@DaGuiMail",WorkingServices.ConvertObjectForSQPara(objInfo.Daguimail)),
                WorkingServices.GetParaFromOject("@TGGuiMail",WorkingServices.ConvertObjectForSQPara(objInfo.Tgguimail)),
                WorkingServices.GetParaFromOject("@DichVuKhamBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvukhambenh)),
                WorkingServices.GetParaFromOject("@DichVuXetNghiem",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvuxetnghiem)),
                WorkingServices.GetParaFromOject("@DichVuXQuang",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvuxquang)),
                WorkingServices.GetParaFromOject("@DichVuSieuAm",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvusieuam)),
                WorkingServices.GetParaFromOject("@DichVuNoiSoi",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvunoisoi)),
                WorkingServices.GetParaFromOject("@DichVuDienTim",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvudientim)),
                WorkingServices.GetParaFromOject("@DichVuKhac",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvukhac)),
                WorkingServices.GetParaFromOject("@KhamLanDau",WorkingServices.ConvertObjectForSQPara(objInfo.Khamlandau)),
                WorkingServices.GetParaFromOject("@TGVaoVien",WorkingServices.ConvertObjectForSQPara(objInfo.Tgvaovien)),
                WorkingServices.GetParaFromOject("@YeuCau",WorkingServices.ConvertObjectForSQPara(objInfo.Yeucau)),
                WorkingServices.GetParaFromOject("@MaDonVi",WorkingServices.ConvertObjectForSQPara(objInfo.Madonvi)),
                WorkingServices.GetParaFromOject("@TenDonVi",WorkingServices.ConvertObjectForSQPara(objInfo.Tendonvi)),
                WorkingServices.GetParaFromOject("@TienSuBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Tiensubenh)),
                WorkingServices.GetParaFromOject("@TinhTrangBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Tinhtrangbenh)),
                WorkingServices.GetParaFromOject("@NhanXetBS",WorkingServices.ConvertObjectForSQPara(objInfo.Nhanxetbs)),
                WorkingServices.GetParaFromOject("@UserCapNhat",WorkingServices.ConvertObjectForSQPara(objInfo.Usercapnhat)),
                WorkingServices.GetParaFromOject("@BacSiCD",WorkingServices.ConvertObjectForSQPara(objInfo.Bacsicd)),
                WorkingServices.GetParaFromOject("@ChanDoan",WorkingServices.ConvertObjectForSQPara(objInfo.Chandoan)),
                WorkingServices.GetParaFromOject("@Sent",WorkingServices.ConvertObjectForSQPara(objInfo.Sent)),
                WorkingServices.GetParaFromOject("@nguonnhap",WorkingServices.ConvertObjectForSQPara(objInfo.Nguonnhap)),
                WorkingServices.GetParaFromOject("@datesent",WorkingServices.ConvertObjectForSQPara(objInfo.Datesent)),
                WorkingServices.GetParaFromOject("@chietkhau",WorkingServices.ConvertObjectForSQPara(objInfo.Chietkhau)),
                WorkingServices.GetParaFromOject("@SoPhieuYeuCau",WorkingServices.ConvertObjectForSQPara(objInfo.Sophieuyeucau)),
                WorkingServices.GetParaFromOject("@mamayin",WorkingServices.ConvertObjectForSQPara(objInfo.Mamayin)),
                WorkingServices.GetParaFromOject("@ngaydk",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaydk)),
                WorkingServices.GetParaFromOject("@allowdownload",WorkingServices.ConvertObjectForSQPara(objInfo.Allowdownload)),
                WorkingServices.GetParaFromOject("@makhuvuc",WorkingServices.ConvertObjectForSQPara(objInfo.Makhuvuc)),
                WorkingServices.GetParaFromOject("@dotkham_id",WorkingServices.ConvertObjectForSQPara(objInfo.Dotkham_id)),
                WorkingServices.GetParaFromOject("@chuyenkhoa_id",WorkingServices.ConvertObjectForSQPara(objInfo.Chuyenkhoa_id)),
                WorkingServices.GetParaFromOject("@giayto_id",WorkingServices.ConvertObjectForSQPara(objInfo.Giayto_id)),
                WorkingServices.GetParaFromOject("@bn_id",WorkingServices.ConvertObjectForSQPara(objInfo.Bn_id)),
                WorkingServices.GetParaFromOject("@manoicapthebhyt",WorkingServices.ConvertObjectForSQPara(objInfo.Manoicapthebhyt)),
                WorkingServices.GetParaFromOject("@manoidangkythebhyt",WorkingServices.ConvertObjectForSQPara(objInfo.Manoidangkythebhyt)),
                WorkingServices.GetParaFromOject("@Giuong",WorkingServices.ConvertObjectForSQPara(objInfo.Giuong)),
                WorkingServices.GetParaFromOject("@Buong",WorkingServices.ConvertObjectForSQPara(objInfo.Buong)),
                WorkingServices.GetParaFromOject("@capcuu",WorkingServices.ConvertObjectForSQPara(objInfo.Capcuu)),
                WorkingServices.GetParaFromOject("@IdCongDan",WorkingServices.ConvertObjectForSQPara(objInfo.Idcongdan)),
                WorkingServices.GetParaFromOject("@DaThuTien",WorkingServices.ConvertObjectForSQPara(objInfo.Dathutien)),
                WorkingServices.GetParaFromOject("@TongThanhTien",WorkingServices.ConvertObjectForSQPara(objInfo.Tongthanhtien)),
                WorkingServices.GetParaFromOject("@DoiTuong",WorkingServices.ConvertObjectForSQPara(objInfo.Doituong)),
                WorkingServices.GetParaFromOject("@HisProviderID",WorkingServices.ConvertObjectForSQPara(objInfo.Hisproviderid)),
                WorkingServices.GetParaFromOject("@ABO",WorkingServices.ConvertObjectForSQPara(objInfo.Abo)),
                WorkingServices.GetParaFromOject("@Rh",WorkingServices.ConvertObjectForSQPara(objInfo.Rh)),
                WorkingServices.GetParaFromOject("@MaDonViHopDong",WorkingServices.ConvertObjectForSQPara(objInfo.Madonvihopdong)),
                WorkingServices.GetParaFromOject("@TenDonviHopDong",WorkingServices.ConvertObjectForSQPara(objInfo.Tendonvihopdong)),
                WorkingServices.GetParaFromOject("@MaSoPhong",WorkingServices.ConvertObjectForSQPara(objInfo.Masophong)),
                WorkingServices.GetParaFromOject("@TenPhong",WorkingServices.ConvertObjectForSQPara(objInfo.Tenphong)),
                WorkingServices.GetParaFromOject("@UuTien",WorkingServices.ConvertObjectForSQPara(objInfo.Uutien)),
                WorkingServices.GetParaFromOject("@BenhKemtheo",WorkingServices.ConvertObjectForSQPara(objInfo.Benhkemtheo)),
                WorkingServices.GetParaFromOject("@MaKhoaHienThoi",WorkingServices.ConvertObjectForSQPara(objInfo.Makhoahienthoi)),
                WorkingServices.GetParaFromOject("@TenKhoaHienThoi",WorkingServices.ConvertObjectForSQPara(objInfo.Tenkhoahienthoi)),
                WorkingServices.GetParaFromOject("@NoiCongTac",WorkingServices.ConvertObjectForSQPara(objInfo.Noicongtac)),
                WorkingServices.GetParaFromOject("@KhamSucKhoe",WorkingServices.ConvertObjectForSQPara(objInfo.Khamsuckhoe)),
                WorkingServices.GetParaFromOject("@NgayNhapVien",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaynhapvien)),
                WorkingServices.GetParaFromOject("@SoHoChieu",WorkingServices.ConvertObjectForSQPara(objInfo.Sohochieu)),
                WorkingServices.GetParaFromOject("@GhiChuHoChieu",WorkingServices.ConvertObjectForSQPara(objInfo.Ghichuhochieu)),
                WorkingServices.GetParaFromOject("@NgayCapHoChieu",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaycaphochieu)),
                WorkingServices.GetParaFromOject("@SoLanTruyen",WorkingServices.ConvertObjectForSQPara(objInfo.SoLanTruyen)),
                WorkingServices.GetParaFromOject("@LyDoTruyenMau",WorkingServices.ConvertObjectForSQPara(objInfo.LyDoTruyenMau))
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "LabBlood_ins_BenhNhanDuTru_ChiDinh_HIS", para) > -1;

        }
        /// <summary>
        /// Hàm insert, update, delete bệnh nhân
        /// </summary>
        /// <param name="objInfo">Object thông tin</param>
        /// <param name="actionFlag">I: Insert - U: Update - D: Delete</param>
        /// <returns></returns>
        public int InsUpdDelAnaPathPatient(BENHNHAN_TIEPNHAN objInfo, string actionFlag)
        {
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@SID",objInfo.Matiepnhan),
                            WorkingServices.GetParaFromOject("@SoLoMau",string.Empty),
                            WorkingServices.GetParaFromOject("@RoomName",objInfo.Tenphong),
                            WorkingServices.GetParaFromOject("@Comment",objInfo.Ghichuhochieu),
                            WorkingServices.GetParaFromOject("@DoctorGet",string.Empty),
                            WorkingServices.GetParaFromOject("@Download",false),
                            WorkingServices.GetParaFromOject("@SIDGPB",objInfo.Matiepnhan),
                            WorkingServices.GetParaFromOject("@DateReturnResult",null),
                            WorkingServices.GetParaFromOject("@Status",1),
                            WorkingServices.GetParaFromOject("@PrintTime",null),
                            WorkingServices.GetParaFromOject("@STypeID",string.Empty),
                            WorkingServices.GetParaFromOject("@DoctorID",objInfo.Bacsicd),
                            WorkingServices.GetParaFromOject("@CurrentLocationName",objInfo.Tenkhoahienthoi),
                            WorkingServices.GetParaFromOject("@PrintCount",0),
                            WorkingServices.GetParaFromOject("@ReceiveDate",null),
                            WorkingServices.GetParaFromOject("@ChildAge",false),
                            WorkingServices.GetParaFromOject("@BHYTTuNgay",null),
                            WorkingServices.GetParaFromOject("@UserUpdateTest",string.Empty),
                            WorkingServices.GetParaFromOject("@FullResult",false),
                            WorkingServices.GetParaFromOject("@AddtionDiagnostic",string.Empty),
                            WorkingServices.GetParaFromOject("@SampleStatus",string.Empty),
                            WorkingServices.GetParaFromOject("@DateGet",objInfo.Ngaydk),
                            WorkingServices.GetParaFromOject("@ObjectID",objInfo.Doituongdichvu),
                            WorkingServices.GetParaFromOject("@PatientName",objInfo.Tenbn),
                            WorkingServices.GetParaFromOject("@UserReceiveResult",string.Empty),
                            WorkingServices.GetParaFromOject("@Phone",objInfo.Sdt),
                            WorkingServices.GetParaFromOject("@Invoice",objInfo.Sott),
                            WorkingServices.GetParaFromOject("@InsuranceEXPDate",objInfo.Ngayhethanbhyt),
                            WorkingServices.GetParaFromOject("@SoLam",1),
                            WorkingServices.GetParaFromOject("@FullTime",null),
                            WorkingServices.GetParaFromOject("@Organization",objInfo.Tendonvihopdong),
                            WorkingServices.GetParaFromOject("@PassportID",objInfo.Sohochieu),
                            WorkingServices.GetParaFromOject("@Bed",objInfo.Giuong),
                            WorkingServices.GetParaFromOject("@UserU",objInfo.Usercapnhat),
                            WorkingServices.GetParaFromOject("@PositionGet",string.Empty),
                            WorkingServices.GetParaFromOject("@UrgentTime",null),
                            WorkingServices.GetParaFromOject("@PID",objInfo.Mabn),
                            WorkingServices.GetParaFromOject("@Age",objInfo.Tuoi),
                            WorkingServices.GetParaFromOject("@SoBHYT",objInfo.Sobhyt),
                            WorkingServices.GetParaFromOject("@PDoctorName",objInfo.TenBScd),
                            WorkingServices.GetParaFromOject("@OrderID",objInfo.Sophieuyeucau),
                            WorkingServices.GetParaFromOject("@CurrentLocationID",objInfo.Makhoahienthoi),
                            WorkingServices.GetParaFromOject("@Urgent",objInfo.Capcuu),
                            WorkingServices.GetParaFromOject("@DoctorIDReceive",string.Empty),
                            WorkingServices.GetParaFromOject("@KSK",false),
                            WorkingServices.GetParaFromOject("@PrintOut",0),
                            WorkingServices.GetParaFromOject("@UpdateTestTime",null),
                            WorkingServices.GetParaFromOject("@BHYTDenNgay",objInfo.Ngayhethanbhyt),
                            WorkingServices.GetParaFromOject("@Internal",objInfo.Noitru),
                            WorkingServices.GetParaFromOject("@IndexHIS",objInfo.Hisproviderid),
                            WorkingServices.GetParaFromOject("@DoctorIDGet",string.Empty),
                            WorkingServices.GetParaFromOject("@DateIN",objInfo.Ngaytiepnhan, true),
                            WorkingServices.GetParaFromOject("@DateReceiveResult",null),
                            WorkingServices.GetParaFromOject("@SoHoSo",objInfo.Bn_id),
                            WorkingServices.GetParaFromOject("@UserD ",string.Empty),
                            WorkingServices.GetParaFromOject("@Room",objInfo.Masophong),
                            WorkingServices.GetParaFromOject("@Diagnostic",objInfo.Chandoan),
                            WorkingServices.GetParaFromOject("@ReturnResult",false),
                            WorkingServices.GetParaFromOject("@Sex",objInfo.Gioitinh),
                            WorkingServices.GetParaFromOject("@Reason",string.Empty),
                            WorkingServices.GetParaFromOject("@LocationReceive",string.Empty),
                            WorkingServices.GetParaFromOject("@UserI",objInfo.Usernhap),
                            WorkingServices.GetParaFromOject("@Child",false),
                            WorkingServices.GetParaFromOject("@Birthday",objInfo.Sinhnhat),
                            WorkingServices.GetParaFromOject("@PDescription",objInfo.Chandoan),
                            WorkingServices.GetParaFromOject("@MaDKBD",string.Empty),
                            WorkingServices.GetParaFromOject("@DoctorCom",string.Empty),
                            WorkingServices.GetParaFromOject("@LocationID",objInfo.Madonvi),
                            WorkingServices.GetParaFromOject("@Seq",objInfo.Seq),
                            WorkingServices.GetParaFromOject("@DoctorReceive",string.Empty),
                            WorkingServices.GetParaFromOject("@Email",objInfo.Email),
                            WorkingServices.GetParaFromOject("@OrderDate",objInfo.Ngaydk),
                            WorkingServices.GetParaFromOject("@Address",objInfo.Diachi),
                            WorkingServices.GetParaFromOject("@DateReturn",null),
                            WorkingServices.GetParaFromOject("@InsuranceID",objInfo.Sobhyt),
                            WorkingServices.GetParaFromOject("@SIDTBH",objInfo.Matiepnhan),
                            WorkingServices.GetParaFromOject("@DMLFlag",actionFlag)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "Anapath_InsUpdDel_ThongTinBenhNhan", sqlPara);
        }
        public bool Update_BenhNhan_TiepNhan(BENHNHAN_TIEPNHAN objInfo)
        {
            var para = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@MaTiepNhan",objInfo.Matiepnhan),
                WorkingServices.GetParaFromOject("@Seq", WorkingServices.ConvertObjectForSQPara(objInfo.Seq)),
                WorkingServices.GetParaFromOject("@NoiTru",WorkingServices.ConvertObjectForSQPara(objInfo.Noitru)),
                WorkingServices.GetParaFromOject("@MaBN ",WorkingServices.ConvertObjectForSQPara(objInfo.Mabn)),
                WorkingServices.GetParaFromOject("@SoBHYT",WorkingServices.ConvertObjectForSQPara(objInfo.Sobhyt)),
                WorkingServices.GetParaFromOject("@NgayHetHanBHYT",WorkingServices.ConvertObjectForSQPara(objInfo.Ngayhethanbhyt)),
                WorkingServices.GetParaFromOject("@TenBN ",WorkingServices.ConvertObjectForSQPara(objInfo.Tenbn)),
                WorkingServices.GetParaFromOject("@SinhNhat",WorkingServices.ConvertObjectForSQPara(objInfo.Sinhnhat, true)),
                WorkingServices.GetParaFromOject("@Tuoi",WorkingServices.ConvertObjectForSQPara(objInfo.Tuoi)),
                WorkingServices.GetParaFromOject("@CoNgaySinh",WorkingServices.ConvertObjectForSQPara(objInfo.Congaysinh)),
                WorkingServices.GetParaFromOject("@GioiTinh",WorkingServices.ConvertObjectForSQPara(objInfo.Gioitinh)),
                WorkingServices.GetParaFromOject("@NgayTiepNhan",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaytiepnhan, true)),
                WorkingServices.GetParaFromOject("@UserNhap",WorkingServices.ConvertObjectForSQPara(objInfo.Usernhap)),
                WorkingServices.GetParaFromOject("@DoiTuongDichVu",WorkingServices.ConvertObjectForSQPara(objInfo.Doituongdichvu)),
                WorkingServices.GetParaFromOject("@DiaChi",WorkingServices.ConvertObjectForSQPara(objInfo.Diachi)),
                WorkingServices.GetParaFromOject("@SoNha",WorkingServices.ConvertObjectForSQPara(objInfo.Sonha)),
                WorkingServices.GetParaFromOject("@PhuongXa",WorkingServices.ConvertObjectForSQPara(objInfo.Phuongxa)),
                WorkingServices.GetParaFromOject("@MaHuyen",WorkingServices.ConvertObjectForSQPara(objInfo.Mahuyen)),
                WorkingServices.GetParaFromOject("@MaTinh",WorkingServices.ConvertObjectForSQPara(objInfo.Matinh)),
                WorkingServices.GetParaFromOject("@Email",WorkingServices.ConvertObjectForSQPara(objInfo.Email)),
                WorkingServices.GetParaFromOject("@SDT",WorkingServices.ConvertObjectForSQPara(objInfo.Sdt)),
                WorkingServices.GetParaFromOject("@DaGuiMail",WorkingServices.ConvertObjectForSQPara(objInfo.Daguimail)),
                WorkingServices.GetParaFromOject("@TGGuiMail",WorkingServices.ConvertObjectForSQPara(objInfo.Tgguimail)),
                WorkingServices.GetParaFromOject("@DichVuKhamBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvukhambenh)),
                WorkingServices.GetParaFromOject("@DichVuXetNghiem",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvuxetnghiem)),
                WorkingServices.GetParaFromOject("@DichVuXQuang",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvuxquang)),
                WorkingServices.GetParaFromOject("@DichVuSieuAm",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvusieuam)),
                WorkingServices.GetParaFromOject("@DichVuNoiSoi",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvunoisoi)),
                WorkingServices.GetParaFromOject("@DichVuDienTim",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvudientim)),
                WorkingServices.GetParaFromOject("@DichVuKhac",WorkingServices.ConvertObjectForSQPara(objInfo.Dichvukhac)),
                WorkingServices.GetParaFromOject("@KhamLanDau",WorkingServices.ConvertObjectForSQPara(objInfo.Khamlandau)),
                WorkingServices.GetParaFromOject("@TGVaoVien",WorkingServices.ConvertObjectForSQPara(objInfo.Tgvaovien)),
                WorkingServices.GetParaFromOject("@YeuCau",WorkingServices.ConvertObjectForSQPara(objInfo.Yeucau)),
                WorkingServices.GetParaFromOject("@MaDonVi",WorkingServices.ConvertObjectForSQPara(objInfo.Madonvi)),
                WorkingServices.GetParaFromOject("@TenDonVi",WorkingServices.ConvertObjectForSQPara(objInfo.Tendonvi)),
                WorkingServices.GetParaFromOject("@TienSuBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Tiensubenh)),
                WorkingServices.GetParaFromOject("@TinhTrangBenh",WorkingServices.ConvertObjectForSQPara(objInfo.Tinhtrangbenh)),
                WorkingServices.GetParaFromOject("@NhanXetBS",WorkingServices.ConvertObjectForSQPara(objInfo.Nhanxetbs)),
                WorkingServices.GetParaFromOject("@UserCapNhat",WorkingServices.ConvertObjectForSQPara(objInfo.Usercapnhat)),
                WorkingServices.GetParaFromOject("@BacSiCD",WorkingServices.ConvertObjectForSQPara(objInfo.Bacsicd)),
                WorkingServices.GetParaFromOject("@ChanDoan",WorkingServices.ConvertObjectForSQPara(objInfo.Chandoan)),
                WorkingServices.GetParaFromOject("@Sent",WorkingServices.ConvertObjectForSQPara(objInfo.Sent)),
                WorkingServices.GetParaFromOject("@nguonnhap",WorkingServices.ConvertObjectForSQPara(objInfo.Nguonnhap)),
                WorkingServices.GetParaFromOject("@datesent",WorkingServices.ConvertObjectForSQPara(objInfo.Datesent)),
                WorkingServices.GetParaFromOject("@chietkhau",WorkingServices.ConvertObjectForSQPara(objInfo.Chietkhau)),
                WorkingServices.GetParaFromOject("@SoPhieuYeuCau",WorkingServices.ConvertObjectForSQPara(objInfo.Sophieuyeucau)),
                WorkingServices.GetParaFromOject("@mamayin",WorkingServices.ConvertObjectForSQPara(objInfo.Mamayin)),
                WorkingServices.GetParaFromOject("@ngaydk",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaydk)),
                WorkingServices.GetParaFromOject("@allowdownload",WorkingServices.ConvertObjectForSQPara(objInfo.Allowdownload)),
                WorkingServices.GetParaFromOject("@makhuvuc",WorkingServices.ConvertObjectForSQPara(objInfo.Makhuvuc)),
                WorkingServices.GetParaFromOject("@dotkham_id",WorkingServices.ConvertObjectForSQPara(objInfo.Dotkham_id)),
                WorkingServices.GetParaFromOject("@chuyenkhoa_id",WorkingServices.ConvertObjectForSQPara(objInfo.Chuyenkhoa_id)),
                WorkingServices.GetParaFromOject("@giayto_id",WorkingServices.ConvertObjectForSQPara(objInfo.Giayto_id)),
                WorkingServices.GetParaFromOject("@bn_id",WorkingServices.ConvertObjectForSQPara(objInfo.Bn_id)),
                WorkingServices.GetParaFromOject("@manoicapthebhyt",WorkingServices.ConvertObjectForSQPara(objInfo.Manoicapthebhyt)),
                WorkingServices.GetParaFromOject("@manoidangkythebhyt",WorkingServices.ConvertObjectForSQPara(objInfo.Manoidangkythebhyt)),
                WorkingServices.GetParaFromOject("@Giuong",WorkingServices.ConvertObjectForSQPara(objInfo.Giuong)),
                WorkingServices.GetParaFromOject("@Buong",WorkingServices.ConvertObjectForSQPara(objInfo.Buong)),
                WorkingServices.GetParaFromOject("@capcuu",WorkingServices.ConvertObjectForSQPara(objInfo.Capcuu)),
                WorkingServices.GetParaFromOject("@IdCongDan",WorkingServices.ConvertObjectForSQPara(objInfo.Idcongdan)),
                WorkingServices.GetParaFromOject("@DaThuTien",WorkingServices.ConvertObjectForSQPara(objInfo.Dathutien)),
                WorkingServices.GetParaFromOject("@TongThanhTien",WorkingServices.ConvertObjectForSQPara(objInfo.Tongthanhtien)),
                WorkingServices.GetParaFromOject("@DoiTuong",WorkingServices.ConvertObjectForSQPara(objInfo.Doituong)),
                WorkingServices.GetParaFromOject("@HisProviderID",WorkingServices.ConvertObjectForSQPara(objInfo.Hisproviderid)),
                WorkingServices.GetParaFromOject("@ABO",WorkingServices.ConvertObjectForSQPara(objInfo.Abo)),
                WorkingServices.GetParaFromOject("@Rh",WorkingServices.ConvertObjectForSQPara(objInfo.Rh)),
                WorkingServices.GetParaFromOject("@MaDonViHopDong",WorkingServices.ConvertObjectForSQPara(objInfo.Madonvihopdong)),
                WorkingServices.GetParaFromOject("@TenDonviHopDong",WorkingServices.ConvertObjectForSQPara(objInfo.Tendonvihopdong)),
                WorkingServices.GetParaFromOject("@MaSoPhong",WorkingServices.ConvertObjectForSQPara(objInfo.Masophong)),
                WorkingServices.GetParaFromOject("@TenPhong",WorkingServices.ConvertObjectForSQPara(objInfo.Tenphong)),
                WorkingServices.GetParaFromOject("@UuTien",WorkingServices.ConvertObjectForSQPara(objInfo.Uutien)),
                WorkingServices.GetParaFromOject("@BenhKemtheo",WorkingServices.ConvertObjectForSQPara(objInfo.Benhkemtheo)),
                WorkingServices.GetParaFromOject("@MaKhoaHienThoi",WorkingServices.ConvertObjectForSQPara(objInfo.Makhoahienthoi)),
                WorkingServices.GetParaFromOject("@TenKhoaHienThoi",WorkingServices.ConvertObjectForSQPara(objInfo.Tenkhoahienthoi)),
                WorkingServices.GetParaFromOject("@NoiCongTac",WorkingServices.ConvertObjectForSQPara(objInfo.Noicongtac)),
                WorkingServices.GetParaFromOject("@KhamSucKhoe",WorkingServices.ConvertObjectForSQPara(objInfo.Khamsuckhoe)),
                WorkingServices.GetParaFromOject("@NgayNhapVien",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaynhapvien)),
                WorkingServices.GetParaFromOject("@QuocTich",WorkingServices.ConvertObjectForSQPara(objInfo.Quoctich)),
                WorkingServices.GetParaFromOject("@MaCongTacVien",WorkingServices.ConvertObjectForSQPara(objInfo.MaCongTacVien)),
                WorkingServices.GetParaFromOject("@NgayCapHoChieu",WorkingServices.ConvertObjectForSQPara(objInfo.Ngaycaphochieu)),
                WorkingServices.GetParaFromOject("@MaSinhLy",WorkingServices.ConvertObjectForSQPara(objInfo.Masinhly)),
                WorkingServices.GetParaFromOject("@TenSinhLy",WorkingServices.ConvertObjectForSQPara(objInfo.Tensinhly)),
                WorkingServices.GetParaFromOject("@ChieuCao",WorkingServices.ConvertObjectForSQPara(objInfo.Chieucao)),
                WorkingServices.GetParaFromOject("@CanNang",WorkingServices.ConvertObjectForSQPara(objInfo.Cannang))
                };
            if (PatientLog(objInfo.Matiepnhan, objInfo.Usercapnhat, LogActionId.Update) > -1)
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updCapNhat_BenhNhanTiepNhan", para) > -1;
            else
                return false;
        }
        public bool UpdatePatientInfoADT(BENHNHAN_TIEPNHAN objInfo)
        {

            /*
             @mabn varchar(30),    
              @TenBN nvarchar(50) = NULL,    
              @tuoi int = NULL,    
              @sinhnhat datetime = NULL,    
              @gioitinh char(1) = NULL,    
              @sdt varchar(20) = NULL,    
              @diachi nvarchar(200)= NULL,    
              @sobhyt nvarchar(50)  = NULL,    
              @sohoso nvarchar(50) = NULL,    
              @Makhoahienthoi nvarchar(50) =NULL,    
              @makhoa nvarchar(50) = NULL      
             * */
            var result = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure,
                "updADTPatient", new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@mabn", objInfo.Mabn),
                WorkingServices.GetParaFromOject("@TenBN", objInfo.Tenbn),
                WorkingServices.GetParaFromOject("@tuoi", objInfo.Tuoi),
                WorkingServices.GetParaFromOject("@sinhnhat", objInfo.Sinhnhat),
                WorkingServices.GetParaFromOject("@gioitinh", objInfo.Gioitinh),
                WorkingServices.GetParaFromOject("@sdt", objInfo.Sdt),
                WorkingServices.GetParaFromOject("@diachi", objInfo.Diachi),
                WorkingServices.GetParaFromOject("@sohoso", objInfo.Bn_id),
                WorkingServices.GetParaFromOject("@Makhoahienthoi", objInfo.Makhoahienthoi),
                WorkingServices.GetParaFromOject("@makhoa", objInfo.Madonvi),
                WorkingServices.GetParaFromOject("@TenkhoaHienThoi", objInfo.Tenkhoahienthoi),
                WorkingServices.GetParaFromOject("@sophieuyeucau", objInfo.Sophieuyeucau),
                WorkingServices.GetParaFromOject("@TGVaoVien", objInfo.Tgvaovien),
                WorkingServices.GetParaFromOject("@NgayNhapVien", objInfo.Ngaynhapvien)

                //WorkingServices.GetParaFromOject("@sobhyt", StringConverter.ToString(patient.b)),
            });

            return result != -1;
        }
        public bool UpdatePatientInfoADTInternal_Manual(BENHNHAN_TIEPNHAN objInfo)
        {
            var result = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure,
                "updADTPatient_Internal_Manual", new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@mabn", objInfo.Mabn),
                WorkingServices.GetParaFromOject("@TenBN", objInfo.Tenbn),
                WorkingServices.GetParaFromOject("@tuoi", objInfo.Tuoi),
                WorkingServices.GetParaFromOject("@SinhNhat",objInfo.Sinhnhat,false, true),
                WorkingServices.GetParaFromOject("@gioitinh", objInfo.Gioitinh),
                WorkingServices.GetParaFromOject("@sdt", objInfo.Sdt),
                WorkingServices.GetParaFromOject("@diachi", objInfo.Diachi),
                WorkingServices.GetParaFromOject("@sohoso", objInfo.Bn_id),
                WorkingServices.GetParaFromOject("@Makhoahienthoi", objInfo.Makhoahienthoi),
                WorkingServices.GetParaFromOject("@makhoa", objInfo.Madonvi),
                WorkingServices.GetParaFromOject("@TenkhoaHienThoi", objInfo.Tenkhoahienthoi),
                WorkingServices.GetParaFromOject("@sophieuyeucau", objInfo.Sophieuyeucau),
                WorkingServices.GetParaFromOject("@TGVaoVien", objInfo.Tgvaovien),
                WorkingServices.GetParaFromOject("@NgayNhapVien", objInfo.Ngaynhapvien),
                WorkingServices.GetParaFromOject("@SoHoChieu", objInfo.Sohochieu),
                WorkingServices.GetParaFromOject("@NgayCapHoChieu", objInfo.Ngaycaphochieu),
                WorkingServices.GetParaFromOject("@GhiChuHoChieu", objInfo.Ghichuhochieu)
            });

            return result != -1;
        }
        public double Get_MaBnNhanGanNhat()
        {
            var dtPidlastest = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_MaBNGanNhat").Tables[0];
            double currentPidSeq = 0;
            currentPidSeq = dtPidlastest.Rows.Count > 0 ? NumberConverter.To<double>(dtPidlastest.Rows[0]["MaBN"]) : 0;
            return currentPidSeq;
        }
        public int Update_NgayChiDinh(string maTiepNhan, DateTime NgayChiDinh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Update benhnhan_tiepnhan set NgayDK = '{0}' where MaTiepNhan = '{1}' "
                , NgayChiDinh.ToString("yyyy-MM-dd HH:mm:ss")
                , maTiepNhan);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public int PatientLog(string maTiepNhan, string userAction, LogActionId action)
        {
            return (int)_workingLog.WriteLog_BenhNhan_TiepNhan(action, userAction, maTiepNhan);
        }
        public bool Delete_BenhNhan_TiepNhan(string maTiepNhan, string UserAction)
        {
            try
            {
                string strSql = "delete KetQua_CLS_XetNghiem where MaTiepNhan ='" + maTiepNhan + "'";
                //Ghi log kết quả - XN
                _workingLog.WriteLog_KetQua_CLS_XetNghiem(LogActionId.Delete, UserAction, maTiepNhan, new List<string>(), string.Empty);
                //Xóa KetQua_CLS_XetNghiem
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                //ghi log sieu am
                strSql = "delete KetQua_CLS_SieuAm where MaTiepNhan ='" + maTiepNhan + "'";
                //Ghi log kết quả - XN
                _workingLog.WriteLog_KetQua_CLS_SieuAm(LogActionId.Delete, UserAction, maTiepNhan, string.Empty);
                //Xóa KetQua_CLS_XetNghiem
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);

                //ghi log benhnhan_cls_xetnghiem
                strSql = string.Format("delete benhnhan_cls_xetnghiem where MaTiepNhan='{0}'", maTiepNhan);

                //xóa benhnhan_cls_xetnghiem
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);

                strSql = String.Format("delete p_payment where MaTiepNhan = '{0}'",maTiepNhan);
                //Ghi log p_payment
                _workingLog.WriteLog_p_payment(LogActionId.Delete, UserAction, maTiepNhan, string.Empty);
                //xóa p_payment
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);

                strSql = "delete BenhNhan_TiepNhan where MaTiepNhan ='" + maTiepNhan + "'";
                //ghi log Benh nhan
                _workingLog.WriteLog_BenhNhan_TiepNhan(LogActionId.Delete, UserAction, maTiepNhan);
                //xóa
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql) > -1;
            }
            catch
            {
                return false;
            }
        }
        private string SQLSelect_Data_BenhNhan_TiepNhan(string matiepnhan, string[] condition, string bophanXN = "")
        {
            var sqlQuery = "SELECT b.*,nv.TenNhanVien from BenhNhan_TiepNhan(nolock) b left join {{TPH_Standard}}_Dictionary.dbo.ql_nhanvien nv on nv.MaNhanVien = b.BacSiCD where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                sqlQuery += "\n and  b.matiepnhan = '" + matiepnhan + "'";

            if (condition != null)
            {
                if (condition.Length > 0)
                {
                    foreach (var VARIABLE in condition)
                    {
                        if (!string.IsNullOrEmpty(VARIABLE))
                            sqlQuery += string.Format("\nand {0}", VARIABLE);
                    }
                }
            }

            if (string.IsNullOrEmpty(bophanXN)) return sqlQuery;

            sqlQuery += string.Format(" and ((select count(k.MaTiepNhan) from ketqua_cls_xetnghiem k inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom(nolock) n on k.MaNhomCLS=n.MaNhomCLS where k.MaTiepNhan=b.MaTiepNhan and n.MaBoPhan='{0}')>0\n", bophanXN);
            sqlQuery += " or (select count(k.MaTiepNhan) from ketqua_cls_xetnghiem k where k.MaTiepNhan=b.MaTiepNhan)=0)";

            return sqlQuery;
        }

        public DataTable Data_BenhNhan_TiepNhan(string matiepnhan, string[] condition, string bophanXN = "")
        {
            DataTable dtData = new DataTable();
            if (condition != null || !string.IsNullOrEmpty(bophanXN))
            {
                dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_BenhNhan_TiepNhan(matiepnhan, condition, bophanXN)).Tables[0];
            }
            else
            {
                var para = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@matiepNhan", matiepnhan)
                };

                dtData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selTimBenhNhan_TheoMaTiepNhan", para).Tables[0];
            }
            return dtData;
        }
        public DataTable Get_Data_BenhNhan_TiepNhan(DataGridView dtg, BindingNavigator bv, string matiepnhan, string[] condition, string bophanXN = "")
        {
            DataTable dtData = new DataTable();
            dtData = Data_BenhNhan_TiepNhan(matiepnhan, condition, bophanXN);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(string matiepnhan, string[] condition)
        {
            DataTable dt = Data_BenhNhan_TiepNhan(matiepnhan, condition);

            return Get_Info_BenhNhan_TiepNhan(dt);
        }
        public BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(DataTable dt)
        {
            var obj = new BENHNHAN_TIEPNHAN();
            if (dt.Rows.Count <= 0) return obj;

            return Get_Info_BenhNhan_TiepNhan(dt.Rows[0]);
        }
        public string Get_MaTiepNhanByBarcode(string barcode)
        {
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selTimBenhNhan_TheoBarcode", new SqlParameter[] { WorkingServices.GetParaFromOject("@Seq", barcode) }).Tables[0];
            if (data.Rows.Count > 0)
                return data.Rows[0]["MaTiepNhan"].ToString();
            return string.Empty;
        }
        public BENHNHAN_TIEPNHAN Get_Info_BenhNhan_TiepNhan(DataRow dr)
        {
            var obj = new BENHNHAN_TIEPNHAN();
            return (BENHNHAN_TIEPNHAN)WorkingServices.Get_InfoForObject(obj, dr);
          
        }
        #endregion

        #region Thông tin BENHNHAN_CLS_DVKHAC

        public bool Insert_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo)
        {
            string sqlQuery = "insert into  BENHNHAN_CLS_DVKHAC (";
            sqlQuery += "\nMatiepnhan";
            sqlQuery += "\n,Bacsicd";
            sqlQuery += "\n,Chandoan";
            sqlQuery += "\n,Bacsiklkhac";
            sqlQuery += "\n,Ketluankhac";
            sqlQuery += "\n,Dukqkhac";
            sqlQuery += "\n,Validkqkhac";
            sqlQuery += "\n,Dainkqkhac";
            sqlQuery += "\n,Thoigianvalidkhac";
            sqlQuery += "\n,Thoigiandukqkhac";
            sqlQuery += "\n,Thoigianinkhac";
            sqlQuery += "\n,Userinkhac";
            sqlQuery += "\n,Laninkhac";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n'" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n," + (objInfo.Bacsicd == null ? "NULL" : "'" + objInfo.Bacsicd + "'");
            sqlQuery += "\n," + (objInfo.Chandoan == null ? "NULL" : "N'" + objInfo.Chandoan + "'");
            sqlQuery += "\n," + (objInfo.Bacsiklkhac == null ? "NULL" : "'" + objInfo.Bacsiklkhac + "'");
            sqlQuery += "\n," + (objInfo.Ketluankhac == null ? "NULL" : "N'" + objInfo.Ketluankhac + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dukqkhac.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Validkqkhac.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dainkqkhac.ToString()) ? "1" : "0");
            sqlQuery += "\n," +
                      (objInfo.Thoigianvalidkhac == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianvalidkhac.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," +
                      (objInfo.Thoigiandukqkhac == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqkhac.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," +
                      (objInfo.Thoigianinkhac == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinkhac.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," + (objInfo.Userinkhac == null ? "NULL" : "'" + objInfo.Userinkhac + "'");
            sqlQuery += "\n," + (objInfo.Laninkhac < 0 ? "0" : objInfo.Laninkhac.ToString());
            if (
                !DataProvider.CheckExisted("select top 1 * from BenhNhan_CLS_DVKhac where 1 = 1  and Matiepnhan =  " +
                                           "'" + objInfo.Matiepnhan + "'"))
            {
                return DataProvider.ExecuteQuery(sqlQuery);
            }
            return true;
        }

        public bool Update_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo)
        {
            string sqlQuery = "Update BENHNHAN_CLS_DVKHAC set";
            sqlQuery += "\n Matiepnhan = '" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n, Bacsicd = " + (objInfo.Bacsicd == null ? "NULL" : "'" + objInfo.Bacsicd + "'");
            sqlQuery += "\n, Chandoan = " +
                      (objInfo.Chandoan == null ? "NULL" : "N'" + objInfo.Chandoan + "'");
            sqlQuery += "\n, Bacsiklkhac = " +
                      (objInfo.Bacsiklkhac == null ? "NULL" : "'" + objInfo.Bacsiklkhac + "'");
            sqlQuery += "\n, Ketluankhac = " +
                      (objInfo.Ketluankhac == null ? "NULL" : "N'" + objInfo.Ketluankhac + "'");
            sqlQuery += "\n, Dukqkhac = " + (bool.Parse(objInfo.Dukqkhac.ToString()) ? "1" : "0");
            sqlQuery += "\n, Validkqkhac = " + (bool.Parse(objInfo.Validkqkhac.ToString()) ? "1" : "0");
            sqlQuery += "\n, Dainkqkhac = " + (bool.Parse(objInfo.Dainkqkhac.ToString()) ? "1" : "0");
            sqlQuery += "\n, Thoigianvalidkhac = " +
                      (objInfo.Thoigianvalidkhac == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianvalidkhac.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Thoigiandukqkhac = " +
                      (objInfo.Thoigiandukqkhac == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqkhac.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Thoigianinkhac = " +
                      (objInfo.Thoigianinkhac == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinkhac.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Userinkhac = " +
                      (objInfo.Userinkhac == null ? "NULL" : "'" + objInfo.Userinkhac + "'");
            sqlQuery += "\n, Laninkhac = " + (objInfo.Laninkhac < 0 ? "0" : objInfo.Laninkhac.ToString());
            sqlQuery += "\nwhere 1 = 1  and Matiepnhan =  '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_BenhNhan_CLS_DVKhac(BENHNHAN_CLS_DVKHAC objInfo)
        {
            string sqlQuery = "Delete BenhNhan_CLS_DVKhac";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Matiepnhan = '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_BenhNhan_CLS_DVKhac(string matiepnhan)
        {
            string sqlQuery = "select * from BenhNhan_CLS_DVKhac where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                sqlQuery += "\n and  matiepnhan = '" + matiepnhan + "'";
            return sqlQuery;
        }

        public DataTable Data_BenhNhan_CLS_DVKhac(string matiepnhan)
        {
            DataTable dtData =
                DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_BenhNhan_CLS_DVKhac(matiepnhan)).Tables[0];
            return dtData;
        }

        public DataTable Get_Data_BenhNhan_CLS_DVKhac(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            DataTable dtData;
            dtData = Data_BenhNhan_CLS_DVKhac(matiepnhan);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }

        public BENHNHAN_CLS_DVKHAC Get_Info_BenhNhan_CLS_DVKhac(string matiepnhan)
        {
            DataTable dt = Data_BenhNhan_CLS_DVKhac(matiepnhan);
            BENHNHAN_CLS_DVKHAC obj = new BENHNHAN_CLS_DVKHAC();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = dt.Rows[0]["matiepnhan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsicd"].ToString()))
                    obj.Bacsicd = dt.Rows[0]["bacsicd"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["chandoan"].ToString()))
                    obj.Chandoan = dt.Rows[0]["chandoan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsiklkhac"].ToString()))
                    obj.Bacsiklkhac = dt.Rows[0]["bacsiklkhac"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluankhac"].ToString()))
                    obj.Ketluankhac = dt.Rows[0]["ketluankhac"].ToString();
                obj.Dukqkhac = (bool)dt.Rows[0]["dukqkhac"];
                obj.Validkqkhac = (bool)dt.Rows[0]["validkqkhac"];
                obj.Dainkqkhac = (bool)dt.Rows[0]["dainkqkhac"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianvalidkhac"].ToString()))
                    obj.Thoigianvalidkhac = (DateTime)dt.Rows[0]["thoigianvalidkhac"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandukqkhac"].ToString()))
                    obj.Thoigiandukqkhac = (DateTime)dt.Rows[0]["thoigiandukqkhac"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianinkhac"].ToString()))
                    obj.Thoigianinkhac = (DateTime)dt.Rows[0]["thoigianinkhac"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userinkhac"].ToString()))
                    obj.Userinkhac = dt.Rows[0]["userinkhac"].ToString();
                obj.Laninkhac = int.Parse(dt.Rows[0]["laninkhac"].ToString());
            }
            return obj;
        }

        #endregion

        #region Thông tin bệnh nhân nội soi

        public bool Insert_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo)
        {
            string sqlQuery = "insert into  BENHNHAN_CLS_NOISOI (";
            sqlQuery += "\nMatiepnhan";
            sqlQuery += "\n,Bacsiklnoisoi";
            sqlQuery += "\n,Ketluannoisoi";
            sqlQuery += "\n,Dukqnoisoi";
            sqlQuery += "\n,Validkqnoisoi";
            sqlQuery += "\n,Dainkqnoisoi";
            sqlQuery += "\n,Thoigiandukqnoisoi";
            sqlQuery += "\n,Thoigianinnoisoi";
            sqlQuery += "\n,Userinnoisoi";
            sqlQuery += "\n,Laninnoisoi";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n'" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n," + (objInfo.Bacsiklnoisoi == null ? "NULL" : "'" + objInfo.Bacsiklnoisoi + "'");
            sqlQuery += "\n," + (objInfo.Ketluannoisoi == null ? "NULL" : "N'" + objInfo.Ketluannoisoi + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dukqnoisoi.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Validkqnoisoi.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dainkqnoisoi.ToString()) ? "1" : "0");
            sqlQuery += "\n," +
                      (objInfo.Thoigiandukqnoisoi == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqnoisoi.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," +
                      (objInfo.Thoigianinnoisoi == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinnoisoi.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," + (objInfo.Userinnoisoi == null ? "NULL" : "'" + objInfo.Userinnoisoi + "'");
            sqlQuery += "\n," + (objInfo.Laninnoisoi < 0 ? "0" : objInfo.Laninnoisoi.ToString());
            if (
                !DataProvider.CheckExisted("select top 1 * from BenhNhan_CLS_NoiSoi where 1 = 1  and Matiepnhan =  " +
                                           "'" +
                                           objInfo.Matiepnhan + "'"))
            {
                return DataProvider.ExecuteQuery(sqlQuery);
            }
            return true;
        }

        public bool Update_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo)
        {
            string sqlQuery = "Update BENHNHAN_CLS_NOISOI set";
            sqlQuery += "\n Matiepnhan = '" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n, Bacsiklnoisoi = " +
                      (objInfo.Bacsiklnoisoi == null ? "NULL" : "'" + objInfo.Bacsiklnoisoi + "'");
            sqlQuery += "\n, Ketluannoisoi = " +
                      (objInfo.Ketluannoisoi == null ? "NULL" : "N'" + objInfo.Ketluannoisoi + "'");
            sqlQuery += "\n, Dukqnoisoi = " + (bool.Parse(objInfo.Dukqnoisoi.ToString()) ? "1" : "0");
            sqlQuery += "\n, Validkqnoisoi = " + (bool.Parse(objInfo.Validkqnoisoi.ToString()) ? "1" : "0");
            sqlQuery += "\n, Dainkqnoisoi = " + (bool.Parse(objInfo.Dainkqnoisoi.ToString()) ? "1" : "0");
            sqlQuery += "\n, Thoigiandukqnoisoi = " +
                      (objInfo.Thoigiandukqnoisoi == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqnoisoi.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Thoigianinnoisoi = " +
                      (objInfo.Thoigianinnoisoi == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinnoisoi.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Userinnoisoi = " +
                      (objInfo.Userinnoisoi == null ? "NULL" : "'" + objInfo.Userinnoisoi + "'");
            sqlQuery += "\n, Laninnoisoi = " + (objInfo.Laninnoisoi < 0 ? "0" : objInfo.Laninnoisoi.ToString());
            sqlQuery += "\nwhere 1 = 1  and Matiepnhan =  '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_BenhNhan_CLS_NoiSoi(BENHNHAN_CLS_NOISOI objInfo)
        {
            string sqlQuery = "Delete BenhNhan_CLS_NoiSoi";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Matiepnhan = '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_BenhNhan_CLS_NoiSoi(string matiepnhan)
        {
            string sqlQuery = "select * from BenhNhan_CLS_NoiSoi where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                sqlQuery += "\n and  matiepnhan = '" + matiepnhan + "'";
            return sqlQuery;
        }

        public DataTable Data_BenhNhan_CLS_NoiSoi(string matiepnhan)
        {
            DataTable dtData;
            dtData =
                DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_BenhNhan_CLS_NoiSoi(matiepnhan)).Tables[0];
            return dtData;
        }

        public DataTable Get_Data_BenhNhan_CLS_NoiSoi(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            DataTable dtData;
            dtData = Data_BenhNhan_CLS_NoiSoi(matiepnhan);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }

        #endregion

        #region Thông tin bệnh nhân siêu âm

        public BENHNHAN_CLS_NOISOI Get_Info_BenhNhan_CLS_NoiSoi(string matiepnhan)
        {
            DataTable dt = Data_BenhNhan_CLS_NoiSoi(matiepnhan);
            BENHNHAN_CLS_NOISOI obj = new BENHNHAN_CLS_NOISOI();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = dt.Rows[0]["matiepnhan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsiklnoisoi"].ToString()))
                    obj.Bacsiklnoisoi = dt.Rows[0]["bacsiklnoisoi"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluannoisoi"].ToString()))
                    obj.Ketluannoisoi = dt.Rows[0]["ketluannoisoi"].ToString();
                obj.Dukqnoisoi = (bool)dt.Rows[0]["dukqnoisoi"];
                obj.Validkqnoisoi = (bool)dt.Rows[0]["validkqnoisoi"];
                obj.Dainkqnoisoi = (bool)dt.Rows[0]["dainkqnoisoi"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandukqnoisoi"].ToString()))
                    obj.Thoigiandukqnoisoi = (DateTime)dt.Rows[0]["thoigiandukqnoisoi"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianinnoisoi"].ToString()))
                    obj.Thoigianinnoisoi = (DateTime)dt.Rows[0]["thoigianinnoisoi"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userinnoisoi"].ToString()))
                    obj.Userinnoisoi = dt.Rows[0]["userinnoisoi"].ToString();
                obj.Laninnoisoi = int.Parse(dt.Rows[0]["laninnoisoi"].ToString());
            }
            return obj;
        }

        public bool Insert_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo)
        {
            string sqlQuery = "insert into  BENHNHAN_CLS_SIEUAM (";
            sqlQuery += "\nMatiepnhan";
            sqlQuery += "\n,Bacsiklsieuam";
            sqlQuery += "\n,Ketluansieuam";
            sqlQuery += "\n,Dukqsieuam";
            sqlQuery += "\n,Validkqsieuam";
            sqlQuery += "\n,Dainkqsieuam";
            sqlQuery += "\n,Thoigiandukqsieuam";
            sqlQuery += "\n,Thoigianinsieuam";
            sqlQuery += "\n,Userinsieuam";
            sqlQuery += "\n,Laninsieuam";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n'" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n," + (objInfo.Bacsiklsieuam == null ? "NULL" : "'" + objInfo.Bacsiklsieuam + "'");
            sqlQuery += "\n," + (objInfo.Ketluansieuam == null ? "NULL" : "N'" + objInfo.Ketluansieuam + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dukqsieuam.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Validkqsieuam.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dainkqsieuam.ToString()) ? "1" : "0");
            sqlQuery += "\n," +
                      (objInfo.Thoigiandukqsieuam == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqsieuam.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," +
                      (objInfo.Thoigianinsieuam == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinsieuam.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," + (objInfo.Userinsieuam == null ? "NULL" : "'" + objInfo.Userinsieuam + "'");
            sqlQuery += "\n," + (objInfo.Laninsieuam < 0 ? "0" : objInfo.Laninsieuam.ToString());
            if (
                !DataProvider.CheckExisted("select top 1 * from BenhNhan_CLS_SieuAm where 1 = 1  and Matiepnhan =  " +
                                           "'" +
                                           objInfo.Matiepnhan + "'"))
            {
                return DataProvider.ExecuteQuery(sqlQuery);
            }
            return true;
        }

        public bool Update_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo)
        {
            string sqlQuery = "Update BENHNHAN_CLS_SIEUAM set";
            sqlQuery += "\n Matiepnhan = '" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n, Bacsiklsieuam = " +
                      (objInfo.Bacsiklsieuam == null ? "NULL" : "'" + objInfo.Bacsiklsieuam + "'");
            sqlQuery += "\n, Ketluansieuam = " +
                      (objInfo.Ketluansieuam == null ? "NULL" : "N'" + objInfo.Ketluansieuam + "'");
            sqlQuery += "\n, Dukqsieuam = " + (bool.Parse(objInfo.Dukqsieuam.ToString()) ? "1" : "0");
            sqlQuery += "\n, Validkqsieuam = " + (bool.Parse(objInfo.Validkqsieuam.ToString()) ? "1" : "0");
            sqlQuery += "\n, Dainkqsieuam = " + (bool.Parse(objInfo.Dainkqsieuam.ToString()) ? "1" : "0");
            sqlQuery += "\n, Thoigiandukqsieuam = " +
                      (objInfo.Thoigiandukqsieuam == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqsieuam.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Thoigianinsieuam = " +
                      (objInfo.Thoigianinsieuam == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinsieuam.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Userinsieuam = " +
                      (objInfo.Userinsieuam == null ? "NULL" : "'" + objInfo.Userinsieuam + "'");
            sqlQuery += "\n, Laninsieuam = " + (objInfo.Laninsieuam < 0 ? "0" : objInfo.Laninsieuam.ToString());
            sqlQuery += "\nwhere 1 = 1  and Matiepnhan =  '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_BenhNhan_CLS_SieuAm(BENHNHAN_CLS_SIEUAM objInfo)
        {
            string sqlQuery = "Delete BenhNhan_CLS_SieuAm";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Matiepnhan = '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_BenhNhan_CLS_SieuAm(string matiepnhan)
        {
            string sqlQuery = "select * from BenhNhan_CLS_SieuAm where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                sqlQuery += "\n and  matiepnhan = '" + matiepnhan + "'";
            return sqlQuery;
        }

        public DataTable Data_BenhNhan_CLS_SieuAm(string matiepnhan)
        {
            var dtData =
                DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_BenhNhan_CLS_SieuAm(matiepnhan)).Tables[0];
            return dtData;
        }

        public DataTable Get_Data_BenhNhan_CLS_SieuAm(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            DataTable dtData;
            dtData = Data_BenhNhan_CLS_SieuAm(matiepnhan);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }

        public BENHNHAN_CLS_SIEUAM Get_Info_BenhNhan_CLS_SieuAm(string matiepnhan)
        {
            DataTable dt = Data_BenhNhan_CLS_SieuAm(matiepnhan);
            BENHNHAN_CLS_SIEUAM obj = new BENHNHAN_CLS_SIEUAM();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = dt.Rows[0]["matiepnhan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsiklsieuam"].ToString()))
                    obj.Bacsiklsieuam = dt.Rows[0]["bacsiklsieuam"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluansieuam"].ToString()))
                    obj.Ketluansieuam = dt.Rows[0]["ketluansieuam"].ToString();
                obj.Dukqsieuam = (bool)dt.Rows[0]["dukqsieuam"];
                obj.Validkqsieuam = (bool)dt.Rows[0]["validkqsieuam"];
                obj.Dainkqsieuam = (bool)dt.Rows[0]["dainkqsieuam"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandukqsieuam"].ToString()))
                    obj.Thoigiandukqsieuam = (DateTime)dt.Rows[0]["thoigiandukqsieuam"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianinsieuam"].ToString()))
                    obj.Thoigianinsieuam = (DateTime)dt.Rows[0]["thoigianinsieuam"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userinsieuam"].ToString()))
                    obj.Userinsieuam = dt.Rows[0]["userinsieuam"].ToString();
                obj.Laninsieuam = int.Parse(dt.Rows[0]["laninsieuam"].ToString());
            }
            return obj;
        }

        #endregion

        #region Thông tin bệnh nhân xét nghiệm

        public bool Insert_BenhNhan_CLS_XetNghiem(string maTiepNhan)
        {
            if (!DataProvider.CheckExisted("select * from BenhNhan_CLS_XetNghiem(nolock) where MaTiepNhan ='" + maTiepNhan + "'"))
            {
                string sqlQuery = "insert into BenhNhan_CLS_XetNghiem (MaTiepNhan) select '" + maTiepNhan + "'";
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery) > 0;
            }
            return true;
        }

        public bool Update_BenhNhan_CLS_XetNghiem(BENHNHAN_CLS_XETNGHIEM objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update BENHNHAN_CLS_XETNGHIEM set");
            sb.AppendFormat("\n Matiepnhan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Matiepnhan.ToString()) + "'");
            sb.AppendFormat("\n, Bacsicd = {0}", (objInfo.Bacsicd == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Bacsicd.ToString()) + "'"));
            sb.AppendFormat("\n, Chandoan = {0}", (objInfo.Chandoan == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Chandoan.ToString()) + "'"));
            sb.AppendFormat("\n, Bacsiklxn = {0}", (objInfo.Bacsiklxn == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Bacsiklxn.ToString()) + "'"));
            sb.AppendFormat("\n, Ketluanxn = {0}", (objInfo.Ketluanxn == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluanxn.ToString()) + "'"));
            sb.AppendFormat("\n, Dukqxn = {0}", (bool.Parse(objInfo.Dukqxn.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Validkqxn = {0}", (bool.Parse(objInfo.Validkqxn.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Dainkqxn = {0}", (bool.Parse(objInfo.Dainkqxn.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Thoigianvalidxn = {0}", (objInfo.Thoigianvalidxn == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianvalidxn.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Thoigiandukqxn = {0}", (objInfo.Thoigiandukqxn == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiandukqxn.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Thoigianinxn = {0}", (objInfo.Thoigianinxn == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianinxn.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Userinxn = {0}", (objInfo.Userinxn == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Userinxn.ToString()) + "'"));
            sb.AppendFormat("\n, Laninxn = {0}", (objInfo.Laninxn < 0 ? "0" : objInfo.Laninxn.ToString()));
            sb.AppendFormat("\n, Thoigianhentrakq = {0}", (objInfo.Thoigianhentrakq == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianhentrakq.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Thoigiantrakq = {0}", (objInfo.Thoigiantrakq == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiantrakq.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Usertrakq = {0}", (objInfo.Usertrakq == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Usertrakq.ToString()) + "'"));
            sb.AppendFormat("\n, Ghichuxn = {0}", (objInfo.Ghichuxn == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ghichuxn.ToString()) + "'"));
            sb.AppendFormat("\n, Bacsiklvisinh = {0}", (objInfo.Bacsiklvisinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Bacsiklvisinh.ToString()) + "'"));
            sb.AppendFormat("\n, Ketluanvisinh = {0}", (objInfo.Ketluanvisinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluanvisinh.ToString()) + "'"));
            sb.AppendFormat("\n, Dukqvisinh = {0}", (bool.Parse(objInfo.Dukqvisinh.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Validkqvisinh = {0}", (bool.Parse(objInfo.Validkqvisinh.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Dainkqvisinh = {0}", (bool.Parse(objInfo.Dainkqvisinh.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Thoigianvalidvisinh = {0}", (objInfo.Thoigianvalidvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianvalidvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Thoigiandukqvisinh = {0}", (objInfo.Thoigiandukqvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiandukqvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Thoigianinvisinh = {0}", (objInfo.Thoigianinvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianinvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Userinvisinh = {0}", (objInfo.Userinvisinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Userinvisinh.ToString()) + "'"));
            sb.AppendFormat("\n, Laninvisinh = {0}", (objInfo.Laninvisinh < 0 ? "0" : objInfo.Laninvisinh.ToString()));
            sb.AppendFormat("\n, Thoigianhentrakqvisinh = {0}", (objInfo.Thoigianhentrakqvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianhentrakqvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Thoigiantrakqvisinh = {0}", (objInfo.Thoigiantrakqvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiantrakqvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Usertrakqvisinh = {0}", (objInfo.Usertrakqvisinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Usertrakqvisinh.ToString()) + "'"));
            sb.AppendFormat("\n, Ghichuvisinh = {0}", (objInfo.Ghichuvisinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ghichuvisinh.ToString()) + "'"));
            sb.AppendFormat("\n, Userdanhgia = {0}", (objInfo.Userdanhgia == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Userdanhgia.ToString()) + "'"));
            sb.AppendFormat("\n, Thoigiandanhgia = {0}", (objInfo.Thoigiandanhgia == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiandanhgia.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Ngayphathanhketqua = {0}", (objInfo.Ngayphathanhketqua == null ? "NULL" : "'" + DateTime.Parse(objInfo.Ngayphathanhketqua.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Userphathanh = {0}", (objInfo.Userphathanh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Userphathanh.ToString()) + "'"));
            sb.AppendFormat("\n, Danhgia = {0}", (string.IsNullOrEmpty(objInfo.Danhgia.ToString()) ? "0" : objInfo.Danhgia.ToString()));
            sb.AppendFormat("\n, Phathanhkqlenweb = {0}", (bool.Parse(objInfo.Phathanhkqlenweb.ToString()) ? "1" : "0"));
            sb.AppendFormat("\n, Thoigianindautien = {0}", (objInfo.Thoigianindautien == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigianindautien.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Ketluanhuyettuydo = {0}", (objInfo.Ketluanhuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluanhuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Denghihuyettuydo = {0}", (objInfo.Denghihuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Denghihuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Nhanxethuyettuydo = {0}", (objInfo.Nhanxethuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nhanxethuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Tomtatbenhli = {0}", (objInfo.Tomtatbenhli == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tomtatbenhli.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoilamhuyettuydo = {0}", (objInfo.Nguoilamhuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nguoilamhuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Tglamhuyettuydo = {0}", (objInfo.Tglamhuyettuydo == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tglamhuyettuydo.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Ketquaxylocain = {0}", (objInfo.Ketquaxylocain == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketquaxylocain.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoidocxylocain = {0}", (objInfo.Nguoidocxylocain == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nguoidocxylocain.ToString()) + "'"));
            sb.AppendFormat("\n, Yeucauxetnghiem = {0}", (objInfo.Yeucauxetnghiem == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Yeucauxetnghiem.ToString()) + "'"));
            sb.AppendFormat("\n, Ketluanhuyetdo = {0}", (objInfo.Ketluanhuyetdo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluanhuyetdo.ToString()) + "'"));
            sb.AppendFormat("\n, Denghihuyetdo = {0}", (objInfo.Denghihuyetdo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Denghihuyetdo.ToString()) + "'"));
            sb.AppendFormat("\n, Nhanxethuyetdo = {0}", (objInfo.Nhanxethuyetdo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nhanxethuyetdo.ToString()) + "'"));
            sb.AppendFormat("\n, Tgnhanmaumau = {0}", (objInfo.Tgnhanmaumau == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tgnhanmaumau.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tgnhanmaunt = {0}", (objInfo.Tgnhanmaunt == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tgnhanmaunt.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tgnhanmauvisinh = {0}", (objInfo.Tgnhanmauvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tgnhanmauvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Nguoinhanmaumau = {0}", (objInfo.Nguoinhanmaumau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhanmaumau.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoinhanmaunt = {0}", (objInfo.Nguoinhanmaunt == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhanmaunt.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoinhanmauvisinh = {0}", (objInfo.Nguoinhanmauvisinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhanmauvisinh.ToString()) + "'"));
            sb.Append("\nwhere Matiepnhan =  '" + Utilities.ConvertSqlString(objInfo.Matiepnhan.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());

        }

        public bool Delete_BenhNhan_CLS_XetNghiem(BENHNHAN_CLS_XETNGHIEM objInfo)
        {
            string sqlQuery = "Delete benhnhan_cls_xetnghiem";
            sqlQuery += string.Format("\n where Matiepnhan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Matiepnhan.ToString()).ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_benhnhan_cls_xetnghiem(string matiepnhan)
        {
            string sqlQuery = "select * from benhnhan_cls_xetnghiem where ";

            sqlQuery += string.Format("\n matiepnhan = {0}", "'" + matiepnhan + "'");
            return sqlQuery;
        }
        public DataTable Data_benhnhan_cls_xetnghiem(string matiepnhan)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selThongTinBN_XetNghiem", WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_benhnhan_cls_xetnghiem(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            DataTable dtData = new DataTable();
            dtData = Data_benhnhan_cls_xetnghiem(matiepnhan);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public BENHNHAN_CLS_XETNGHIEM Get_Info_benhnhan_cls_xetnghiem(string matiepnhan)
        {
            DataTable dt = Data_benhnhan_cls_xetnghiem(matiepnhan);
            BENHNHAN_CLS_XETNGHIEM obj = new BENHNHAN_CLS_XETNGHIEM();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = StringConverter.ToString(dt.Rows[0]["matiepnhan"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsicd"].ToString()))
                    obj.Bacsicd = StringConverter.ToString(dt.Rows[0]["bacsicd"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["chandoan"].ToString()))
                    obj.Chandoan = StringConverter.ToString(dt.Rows[0]["chandoan"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsiklxn"].ToString()))
                    obj.Bacsiklxn = StringConverter.ToString(dt.Rows[0]["bacsiklxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluanxn"].ToString()))
                    obj.Ketluanxn = StringConverter.ToString(dt.Rows[0]["ketluanxn"]);
                obj.Dukqxn = NumberConverter.To<bool>(dt.Rows[0]["dukqxn"]);
                obj.Validkqxn = NumberConverter.To<bool>(dt.Rows[0]["validkqxn"]);
                obj.Dainkqxn = NumberConverter.To<bool>(dt.Rows[0]["dainkqxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianvalidxn"].ToString()))
                    obj.Thoigianvalidxn = (DateTime)dt.Rows[0]["thoigianvalidxn"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandukqxn"].ToString()))
                    obj.Thoigiandukqxn = (DateTime)dt.Rows[0]["thoigiandukqxn"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianinxn"].ToString()))
                    obj.Thoigianinxn = (DateTime)dt.Rows[0]["thoigianinxn"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userinxn"].ToString()))
                    obj.Userinxn = StringConverter.ToString(dt.Rows[0]["userinxn"]);
                obj.Laninxn = NumberConverter.To<int>(dt.Rows[0]["laninxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianhentrakq"].ToString()))
                    obj.Thoigianhentrakq = (DateTime)dt.Rows[0]["thoigianhentrakq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiantrakq"].ToString()))
                    obj.Thoigiantrakq = (DateTime)dt.Rows[0]["thoigiantrakq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["usertrakq"].ToString()))
                    obj.Usertrakq = StringConverter.ToString(dt.Rows[0]["usertrakq"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ghichuxn"].ToString()))
                    obj.Ghichuxn = StringConverter.ToString(dt.Rows[0]["ghichuxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsiklvisinh"].ToString()))
                    obj.Bacsiklvisinh = StringConverter.ToString(dt.Rows[0]["bacsiklvisinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluanvisinh"].ToString()))
                    obj.Ketluanvisinh = StringConverter.ToString(dt.Rows[0]["ketluanvisinh"]);
                obj.Dukqvisinh = NumberConverter.To<bool>(dt.Rows[0]["dukqvisinh"]);
                obj.Validkqvisinh = NumberConverter.To<bool>(dt.Rows[0]["validkqvisinh"]);
                obj.Dainkqvisinh = NumberConverter.To<bool>(dt.Rows[0]["dainkqvisinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianvalidvisinh"].ToString()))
                    obj.Thoigianvalidvisinh = (DateTime)dt.Rows[0]["thoigianvalidvisinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandukqvisinh"].ToString()))
                    obj.Thoigiandukqvisinh = (DateTime)dt.Rows[0]["thoigiandukqvisinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianinvisinh"].ToString()))
                    obj.Thoigianinvisinh = (DateTime)dt.Rows[0]["thoigianinvisinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userinvisinh"].ToString()))
                    obj.Userinvisinh = StringConverter.ToString(dt.Rows[0]["userinvisinh"]);
                obj.Laninvisinh = NumberConverter.To<int>(dt.Rows[0]["laninvisinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianhentrakqvisinh"].ToString()))
                    obj.Thoigianhentrakqvisinh = (DateTime)dt.Rows[0]["thoigianhentrakqvisinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiantrakqvisinh"].ToString()))
                    obj.Thoigiantrakqvisinh = (DateTime)dt.Rows[0]["thoigiantrakqvisinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["usertrakqvisinh"].ToString()))
                    obj.Usertrakqvisinh = StringConverter.ToString(dt.Rows[0]["usertrakqvisinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ghichuvisinh"].ToString()))
                    obj.Ghichuvisinh = StringConverter.ToString(dt.Rows[0]["ghichuvisinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["userdanhgia"].ToString()))
                    obj.Userdanhgia = StringConverter.ToString(dt.Rows[0]["userdanhgia"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandanhgia"].ToString()))
                    obj.Thoigiandanhgia = (DateTime)dt.Rows[0]["thoigiandanhgia"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["ngayphathanhketqua"].ToString()))
                    obj.Ngayphathanhketqua = (DateTime)dt.Rows[0]["ngayphathanhketqua"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userphathanh"].ToString()))
                    obj.Userphathanh = StringConverter.ToString(dt.Rows[0]["userphathanh"]);
                obj.Danhgia = NumberConverter.To<int>(dt.Rows[0]["danhgia"]);
                obj.Phathanhkqlenweb = NumberConverter.To<bool>(dt.Rows[0]["phathanhkqlenweb"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianindautien"].ToString()))
                    obj.Thoigianindautien = (DateTime)dt.Rows[0]["thoigianindautien"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluanhuyettuydo"].ToString()))
                    obj.Ketluanhuyettuydo = StringConverter.ToString(dt.Rows[0]["ketluanhuyettuydo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["denghihuyettuydo"].ToString()))
                    obj.Denghihuyettuydo = StringConverter.ToString(dt.Rows[0]["denghihuyettuydo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nhanxethuyettuydo"].ToString()))
                    obj.Nhanxethuyettuydo = StringConverter.ToString(dt.Rows[0]["nhanxethuyettuydo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tomtatbenhli"].ToString()))
                    obj.Tomtatbenhli = StringConverter.ToString(dt.Rows[0]["tomtatbenhli"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoilamhuyettuydo"].ToString()))
                    obj.Nguoilamhuyettuydo = StringConverter.ToString(dt.Rows[0]["nguoilamhuyettuydo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tglamhuyettuydo"].ToString()))
                    obj.Tglamhuyettuydo = (DateTime)dt.Rows[0]["tglamhuyettuydo"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketquaxylocain"].ToString()))
                    obj.Ketquaxylocain = StringConverter.ToString(dt.Rows[0]["ketquaxylocain"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoidocxylocain"].ToString()))
                    obj.Nguoidocxylocain = StringConverter.ToString(dt.Rows[0]["nguoidocxylocain"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["yeucauxetnghiem"].ToString()))
                    obj.Yeucauxetnghiem = StringConverter.ToString(dt.Rows[0]["yeucauxetnghiem"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluanhuyetdo"].ToString()))
                    obj.Ketluanhuyetdo = StringConverter.ToString(dt.Rows[0]["ketluanhuyetdo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["denghihuyetdo"].ToString()))
                    obj.Denghihuyetdo = StringConverter.ToString(dt.Rows[0]["denghihuyetdo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nhanxethuyetdo"].ToString()))
                    obj.Nhanxethuyetdo = StringConverter.ToString(dt.Rows[0]["nhanxethuyetdo"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tgnhanmaumau"].ToString()))
                    obj.Tgnhanmaumau = (DateTime)dt.Rows[0]["tgnhanmaumau"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["tgnhanmaunt"].ToString()))
                    obj.Tgnhanmaunt = (DateTime)dt.Rows[0]["tgnhanmaunt"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["tgnhanmauvisinh"].ToString()))
                    obj.Tgnhanmauvisinh = (DateTime)dt.Rows[0]["tgnhanmauvisinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoinhanmaumau"].ToString()))
                    obj.Nguoinhanmaumau = StringConverter.ToString(dt.Rows[0]["nguoinhanmaumau"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoinhanmaunt"].ToString()))
                    obj.Nguoinhanmaunt = StringConverter.ToString(dt.Rows[0]["nguoinhanmaunt"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoinhanmauvisinh"].ToString()))
                    obj.Nguoinhanmauvisinh = StringConverter.ToString(dt.Rows[0]["nguoinhanmauvisinh"]);
            }
            return obj;
        }
        public DateTime NgayTiepNhan_TheoBarcode(string barcode)
        {
            var sqlQuery = string.Format("select top 1 NgayTiepNhan from BenhNhan_TiepNhan where Seq ='{0}' Order by NgayTiepNhan desc", barcode);
            var data = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
            if (data.Rows.Count > 0)
            {
                return DateTime.Parse(data.Rows[0]["NgayTiepNhan"].ToString());
            }
            else
            {
                sqlQuery = string.Format("select top 1 NgayTiepNhan from BenhNhan_TiepNhan where SoPhieuYeuCau ='{0}' Order by NgayTiepNhan desc", barcode);
                data = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
                if (data.Rows.Count > 0)
                {
                    return DateTime.Parse(data.Rows[0]["NgayTiepNhan"].ToString());
                }
                else
                {
                    sqlQuery = string.Format("select top 1 NgayTiepNhan from BenhNhan_TiepNhan where Bn_Id ='{0}' Order by NgayTiepNhan desc", barcode);
                    data = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery).Tables[0];
                    if (data.Rows.Count > 0)
                    {
                        return DateTime.Parse(data.Rows[0]["NgayTiepNhan"].ToString());
                    }
                    else
                        return DateTime.Now;
                }
            }
        }
        #endregion

        #region Thông tin bệnh nhân xquang

        public bool Insert_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo)
        {
            string sqlQuery = "insert into  BENHNHAN_CLS_XQUANG (";
            sqlQuery += "\nMatiepnhan";
            sqlQuery += "\n,Bacsiklxquang";
            sqlQuery += "\n,Ketluanxquang";
            sqlQuery += "\n,Dukqxquang";
            sqlQuery += "\n,Validkqxquang";
            sqlQuery += "\n,Dainkqxquang";
            sqlQuery += "\n,Thoigiandukqxquang";
            sqlQuery += "\n,Thoigianvalidxquang";
            sqlQuery += "\n,Thoigianinxquang";
            sqlQuery += "\n,Userinxquang";
            sqlQuery += "\n,Laninxquang";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n'" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n," + (objInfo.Bacsiklxquang == null ? "NULL" : "'" + objInfo.Bacsiklxquang + "'");
            sqlQuery += "\n," + (objInfo.Ketluanxquang == null ? "NULL" : "N'" + objInfo.Ketluanxquang + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dukqxquang.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Validkqxquang.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dainkqxquang.ToString()) ? "1" : "0");
            sqlQuery += "\n," +
                      (objInfo.Thoigiandukqxquang == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqxquang.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," +
                      (objInfo.Thoigianvalidxquang == null
                          ? "NULL"
                          : "'" +
                            DateTime.Parse(objInfo.Thoigianvalidxquang.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," +
                      (objInfo.Thoigianinxquang == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinxquang.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n," + (objInfo.Userinxquang == null ? "NULL" : "'" + objInfo.Userinxquang + "'");
            sqlQuery += "\n," + (objInfo.Laninxquang < 0 ? "0" : objInfo.Laninxquang.ToString());
            if (
                !DataProvider.CheckExisted("select top 1 * from BenhNhan_CLS_XQuang where 1 = 1  and Matiepnhan =  " +
                                           "'" +
                                           objInfo.Matiepnhan + "'"))
            {
                return DataProvider.ExecuteQuery(sqlQuery);
            }
            return true;

        }

        public bool Update_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo)
        {
            string sqlQuery = "Update BENHNHAN_CLS_XQUANG set";
            sqlQuery += "\n Matiepnhan = '" + objInfo.Matiepnhan + "'";
            sqlQuery += "\n, Bacsiklxquang = " +
                      (objInfo.Bacsiklxquang == null ? "NULL" : "'" + objInfo.Bacsiklxquang + "'");
            sqlQuery += "\n, Ketluanxquang = " +
                      (objInfo.Ketluanxquang == null ? "NULL" : "N'" + objInfo.Ketluanxquang + "'");
            sqlQuery += "\n, Dukqxquang = " + (bool.Parse(objInfo.Dukqxquang.ToString()) ? "1" : "0");
            sqlQuery += "\n, Validkqxquang = " + (bool.Parse(objInfo.Validkqxquang.ToString()) ? "1" : "0");
            sqlQuery += "\n, Dainkqxquang = " + (bool.Parse(objInfo.Dainkqxquang.ToString()) ? "1" : "0");
            sqlQuery += "\n, Thoigiandukqxquang = " +
                      (objInfo.Thoigiandukqxquang == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigiandukqxquang.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Thoigianvalidxquang = " +
                      (objInfo.Thoigianvalidxquang == null
                          ? "NULL"
                          : "'" +
                            DateTime.Parse(objInfo.Thoigianvalidxquang.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Thoigianinxquang = " +
                      (objInfo.Thoigianinxquang == null
                          ? "NULL"
                          : "'" + DateTime.Parse(objInfo.Thoigianinxquang.ToString()).ToString("yyyy-MM-dd HH:mm:ss") +
                            "'");
            sqlQuery += "\n, Userinxquang = " +
                      (objInfo.Userinxquang == null ? "NULL" : "'" + objInfo.Userinxquang + "'");
            sqlQuery += "\n, Laninxquang = " + (objInfo.Laninxquang < 0 ? "0" : objInfo.Laninxquang.ToString());
            sqlQuery += "\nwhere 1 = 1  and Matiepnhan =  '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_BenhNhan_CLS_XQuang(BENHNHAN_CLS_XQUANG objInfo)
        {
            string sqlQuery = "Delete BenhNhan_CLS_XQuang";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Matiepnhan = '" + objInfo.Matiepnhan + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_BenhNhan_CLS_XQuang(string matiepnhan)
        {
            string sqlQuery = "select * from BenhNhan_CLS_XQuang where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                sqlQuery += "\n and  matiepnhan = '" + matiepnhan + "'";
            return sqlQuery;
        }

        public DataTable Data_BenhNhan_CLS_XQuang(string matiepnhan)
        {
            DataTable dtData;
            dtData =
                DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_BenhNhan_CLS_XQuang(matiepnhan)).Tables[0];
            return dtData;
        }

        public DataTable Get_Data_BenhNhan_CLS_XQuang(DataGridView dtg, BindingNavigator bv, string matiepnhan)
        {
            DataTable dtData;
            dtData = Data_BenhNhan_CLS_XQuang(matiepnhan);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }

        public BENHNHAN_CLS_XQUANG Get_Info_BenhNhan_CLS_XQuang(string matiepnhan)
        {
            DataTable dt = Data_BenhNhan_CLS_XQuang(matiepnhan);
            BENHNHAN_CLS_XQUANG obj = new BENHNHAN_CLS_XQUANG();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = dt.Rows[0]["matiepnhan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["bacsiklxquang"].ToString()))
                    obj.Bacsiklxquang = dt.Rows[0]["bacsiklxquang"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketluanxquang"].ToString()))
                    obj.Ketluanxquang = dt.Rows[0]["ketluanxquang"].ToString();
                obj.Dukqxquang = (bool)dt.Rows[0]["dukqxquang"];
                obj.Validkqxquang = (bool)dt.Rows[0]["validkqxquang"];
                obj.Dainkqxquang = (bool)dt.Rows[0]["dainkqxquang"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiandukqxquang"].ToString()))
                    obj.Thoigiandukqxquang = (DateTime)dt.Rows[0]["thoigiandukqxquang"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianvalidxquang"].ToString()))
                    obj.Thoigianvalidxquang = (DateTime)dt.Rows[0]["thoigianvalidxquang"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigianinxquang"].ToString()))
                    obj.Thoigianinxquang = (DateTime)dt.Rows[0]["thoigianinxquang"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["userinxquang"].ToString()))
                    obj.Userinxquang = dt.Rows[0]["userinxquang"].ToString();
                obj.Laninxquang = int.Parse(dt.Rows[0]["laninxquang"].ToString());
            }
            return obj;
        }

        #endregion

        #region Chỉ định dịch vụ

        public List<SeviceOrderedInformation> GetOrderServiceDetail(string maTiepNhan, bool checkGia
            , string idPhieuIn, bool Xngui, bool sapXepTheoThuTuInNhom)
        {
            var result = new List<SeviceOrderedInformation>();
            var sqlPara = new SqlParameter[]
            {
                new SqlParameter("@matiepnhan", maTiepNhan),
                new SqlParameter("@cogia", checkGia),
                new SqlParameter("@idbienlai", string.IsNullOrEmpty(idPhieuIn) ? (object) DBNull.Value : idPhieuIn),
                new SqlParameter("@Xngui", Xngui)
            };

            var detailData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChiTietChiDinh", sqlPara);
            if (detailData == null ||
                detailData.Tables == null ||
                detailData.Tables.Count == 0 ||
                detailData.Tables[0] == null ||
                detailData.Tables[0].Rows.Count == 0)
            {
                return result;
            }

            var data = detailData.Tables[0];

            if (sapXepTheoThuTuInNhom)
            {
                var distinctCatePrint = data.DefaultView.ToTable(true,
                    new string[] { "ThuTuPhanLoai", "ThuTuIn", "TenNhomChiDinh" });
                distinctCatePrint.DefaultView.Sort = "ThuTuPhanLoai, ThuTuIn asc";

                var totalRows = data.Rows.Count;
                for (var i = 0; i < totalRows; i++)
                {
                    var catePrint = StringConverter.ToString(data.Rows[i]["TenNhomChiDinh"]).Trim();
                    var currentIndex = 0;
                    var totalCate = distinctCatePrint.Rows.Count;
                    for (var a = 0; a < totalCate; a++)
                    {
                        if (catePrint.Trim().Equals(StringConverter.ToString(distinctCatePrint.Rows[a]["TenNhomChiDinh"]).Trim()))
                        {
                            currentIndex = a + 1;
                            break;
                        }
                    }

                    data.Rows[i]["TenNhomChiDinh"] = string.Format("[{0}] - {1}", Utilities.LayStt(currentIndex, 1), catePrint.Trim().ToUpper());
                }
            }

            result = detailData.Tables[0].AsEnumerable().Select(dataRow => new SeviceOrderedInformation
            {
                isChecked = NumberConverter.To<bool>(dataRow["isChecked"]),
                chon = NumberConverter.To<bool>(dataRow["chon"]),
                stt = NumberConverter.ToInt(dataRow["stt"]),
                SapXep = NumberConverter.ToInt(dataRow["SapXep"]),
                ThuTuIn = NumberConverter.ToInt(dataRow["ThuTuIn"]),
                MaTiepNhan = StringConverter.ToString(dataRow["MaTiepNhan"]),
                MaBenhNhan = StringConverter.ToString(dataRow["MaBenhNhan"]),
                SoBHYT = StringConverter.ToString(dataRow["SoBHYT"]),
                NgayHetHanBHYT = (string.IsNullOrEmpty(dataRow["NgayHetHanBHYT"].ToString())
                    ? (DateTime?)null
                    : DateTime.Parse(dataRow["NgayHetHanBHYT"].ToString())),
                TenBenhNhan = StringConverter.ToString(dataRow["TenBenhNhan"]),
                NamSinh = NumberConverter.ToInt(dataRow["NamSinh"]),
                SinhNhat = (string.IsNullOrEmpty(dataRow["SinhNhat"].ToString())
                    ? (DateTime?)null
                    : DateTime.Parse(dataRow["SinhNhat"].ToString())),
                CoNgaySinh = NumberConverter.To<bool>(dataRow["CoNgaySinh"]),
                GioiTinh = StringConverter.ToString(dataRow["GioiTinh"]),
                NgayTiepNhan = DateTime.Parse(dataRow["NgayTiepNhan"].ToString()),
                ThoiGianNhap = DateTime.Parse(dataRow["ThoiGianNhap"].ToString()),
                UserNhap = StringConverter.ToString(dataRow["UserNhap"]),
                MaDoiTuongDichVu = StringConverter.ToString(dataRow["MaDoiTuongDichVu"]),
                TenDoiTuongDichVu = StringConverter.ToString(dataRow["TenDoiTuongDichVu"]),
                SoNha = StringConverter.ToString(dataRow["SoNha"]),
                PhuongXa = StringConverter.ToString(dataRow["PhuongXa"]),
                MaHuyen = StringConverter.ToString(dataRow["MaHuyen"]),
                MaTinh = StringConverter.ToString(dataRow["MaTinh"]),
                DiaChi = StringConverter.ToString(dataRow["DiaChi"]),
                RSoPhieuYeuCau = StringConverter.ToString(dataRow["RSoPhieuYeuCau"]),
                MaChiDinh = StringConverter.ToString(dataRow["MaChiDinh"]),
                TenChiDinh = StringConverter.ToString(dataRow["TenChiDinh"]),
                MaNhomChiDinh = StringConverter.ToString(dataRow["MaNhomChiDinh"]),
                TenNhomChiDinh = StringConverter.ToString(dataRow["TenNhomChiDinh"]),
                MaPhanLoai = StringConverter.ToString(dataRow["MaPhanLoai"]),
                TenPhanLoai = StringConverter.ToString(dataRow["TenPhanLoai"]),
                ThuTuPhanLoai = NumberConverter.ToInt(dataRow["ThuTuPhanLoai"]),
                GiaRieng = NumberConverter.To<double>(dataRow["GiaRieng"]),
                DaKkoa = NumberConverter.To<bool>(dataRow["DaKkoa"]),
                MaProfile = StringConverter.ToString(dataRow["MaProfile"]),
                ChiDinhCha = NumberConverter.To<bool>(dataRow["ChiDinhCha"]),
                LoaiMau = StringConverter.ToString(dataRow["LoaiMau"]),
                TienCong = NumberConverter.To<double>(dataRow["TienCong"]),
                DaThuTien = NumberConverter.To<bool>(dataRow["DaThuTien"]),
                SoLuong = NumberConverter.ToInt(dataRow["SoLuong"]),
                IDBienLai = StringConverter.ToString(dataRow["IDBienLai"]),
                DonViTinh = StringConverter.ToString(dataRow["DonViTinh"]),
                KetQua = StringConverter.ToString(dataRow["KetQua"]),
                Flat = NumberConverter.ToInt(dataRow["Flat"]),
                MauGui = NumberConverter.To<bool>(dataRow["MauGui"]),
                MaCapTren = StringConverter.ToString(dataRow["MaCapTren"]),
                DaCoKQ = NumberConverter.To<bool>(dataRow["DaCoKQ"]),
                ThoiGianNhapKQ = (detailData.Tables[0].Columns.Contains("ThoiGianNhapKQ")
                    ? string.IsNullOrEmpty(dataRow["ThoiGianNhapKQ"].ToString()) ? (DateTime?)null :
                    DateTime.Parse(dataRow["ThoiGianNhapKQ"].ToString())
                    : DateTime.Now),
                ThoiGianLayMau = (detailData.Tables[0].Columns.Contains("ThoiGianLayMau")
                    ? string.IsNullOrEmpty(dataRow["ThoiGianLayMau"].ToString()) ? (DateTime?)null :
                    DateTime.Parse(dataRow["ThoiGianLayMau"].ToString())
                    : DateTime.Now),
                ThoiGianNhanMau = (detailData.Tables[0].Columns.Contains("ThoiGianNhanMau")
                    ? string.IsNullOrEmpty(dataRow["ThoiGianNhanMau"].ToString()) ? (DateTime?)null :
                    DateTime.Parse(dataRow["ThoiGianNhanMau"].ToString())
                    : DateTime.Now),
                ThoiGianInKQ = (detailData.Tables[0].Columns.Contains("ThoiGianInKQ")
                    ? string.IsNullOrEmpty(dataRow["ThoiGianInKQ"].ToString()) ? (DateTime?)null :
                    DateTime.Parse(dataRow["ThoiGianInKQ"].ToString())
                    : DateTime.Now),
                XacNhanKQ = NumberConverter.To<bool>(dataRow["XacNhanKQ"]),
            }).ToList();

            return result;
        }
        //public List<SeviceOrderedInformation> OrderedServices(string condit, bool sapXepTheoThuTuInNhom)
        //{
        //    StringBuilder sqlQuery = new StringBuilder();
        //    sqlQuery.Append("select cast (0 as bit) as isChecked, A.*, D.TenPhanLoai, D.ThuTuIn as ThuTuPhanLoai, T.[MaBN] as MaBenhNhan , T.[SoBHYT], T.[NgayHetHanBHYT], T.[TenBN] as TenBenhNhan");
        //    sqlQuery.AppendLine(", T.[SinhNhat], T.[Tuoi] as NamSinh, T.[CoNgaySinh], T.[GioiTinh], T.[NgayTiepNhan], T.[ThoiGianNhap], T.[UserNhap]");
        //    sqlQuery.AppendLine(", dt.MaDoiTuongDichVu, dt.TenDoiTuongDichVu, T.[DiaChi], T.[SoNha], T.[PhuongXa], T.[MaHuyen], T.[MaTinh], T.SDT, T.Seq");
        //    sqlQuery.AppendLine(" from(");
        //    sqlQuery.AppendLine("select STT, RSoPhieuYeuCau, dm.Sapxep, cast(0 as bit) as chon, MatiepNhan, x.MaXN as MaChiDinh");
        //    sqlQuery.AppendLine(", x.TenXN as TenChiDinh, x.ThuTuIn, x.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
        //    sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, x.XacNhanKQ as DaKkoa, x.ProfileID as MaProfile, x.XNChinh as ChiDinhCha, DaThuTien");
        //    sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, x.LoaiMau, TienCong, IDBienLai, N'Lần' as DonViTinh, x.KetQua, x.Flat, dm.LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, x.DoiTacNhanMauXN, x.TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KetQua_CLS_XetNghiem x inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on x.MaNhomCLS = n.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm on x.maxn = dm.maxn ");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and GiaRieng > 0", "and dm.KhongSD = 1"));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine("Union all");
        //    sqlQuery.AppendLine("select 0 as STT, x.HISOrderID as RSoPhieuYeuCau, dm.Sapxep, cast(0 as bit) as chon, x.SID as MatiepNhan, dm.MaXN as MaChiDinh");
        //    sqlQuery.AppendLine(", dm.TenXN as TenChiDinh, dm.ThuTuIn, dm.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, 'ClsXetNghiem' as MaPhanLoai, 0 as GiaRieng");
        //    sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, x.Validated as DaKkoa, null as MaProfile, dm.XNChinh as ChiDinhCha, cast(0 as bit) as DaThuTien");
        //    sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 0 as ThanhTien, dm.LoaiMau, 0 as TienCong, null as IDBienLai, N'Lần' as DonViTinh, null as KetQua, 0 as Flat, dm.LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from {{TPH_Standard}}_LabBlood.dbo.tbl_Patient_Element x inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm on x.TestCodeLis = dm.MaXN");
        //    sqlQuery.AppendLine("inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on dm.MaNhomCLS = n.MaNhomCLS");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("MaTiepNhan", "x.SID").Replace("and GiaRieng > 0", "and dm.KhongSD = 1"));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine("Union all");
        //    sqlQuery.AppendLine("select 0 as STT, RSoPhieuYeuCau, dm.Sapxep, cast(0 as bit) as chon, MatiepNhan, x.MaYeuCau as MaChiDinh");
        //    sqlQuery.AppendLine(", x.TenYeuCau as TenChiDinh, x.ThuTuIn, n.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
        //    sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, x.DaXacNhan as DaKkoa, null as MaProfile, cast (0 as bit) as ChiDinhCha, DaThuTien");
        //    sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, x.MaLoaiMau as LoaiMau, TienCong, IDBienLai, N'Lần' as DonViTinh, null as KetQua, cast (0 as int) as Flat, dm.LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, x.DoiTacNhanMauXN, x.TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KetQua_CLS_XetNghiem_ViSinh x inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on x.MaNhomYeuCau = n.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm on x.MaYeuCau = dm.maxn ");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and GiaRieng > 0", "and dm.KhongSD = 1"));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine("Union all");
        //    sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaSoMau as varchar(20)) as MaChiDinh");
        //    sqlQuery.AppendLine(", TenMauSieuAm as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomSieuAm as MaNhomChiDinh, n.TenNhomSieuAm as TenNhomChiDinh");
        //    sqlQuery.AppendLine(" , MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe");
        //    sqlQuery.AppendLine(" , XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong");
        //    sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat, 0 as LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KetQua_CLS_SieuAm x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm n on x.MaNhomSieuAm = n.MaNhomSieuAm");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and XNGui = 1", ""));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine(" Union all");
        //    sqlQuery.AppendLine("select distinct 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon");
        //    sqlQuery.AppendLine(", MatiepNhan, cast(k.MaVungChup as varchar(20)) as MaChiDinh, VC.TenVungChup as TenChiDinh, cast(100 as int) as ThuTuIn");
        //    sqlQuery.AppendLine(", k.MaKyThuatChup as MaNhomChiDinh, n.TenKyThuatChup as TenNhomChiDinh, MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa");
        //    sqlQuery.AppendLine(", null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau");
        //    sqlQuery.AppendLine(", 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat, 0 as LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KetQua_CLS_XQuang k left");
        //    sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup");
        //    sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup n on n.MaKyThuatChup = vc.MaKyThuatChup");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and XNGui = 1", ""));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine("Union all");
        //    sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaSoMauNoiSoi as varchar(20)) as MaChiDinh");
        //    sqlQuery.AppendLine(", TenMauNoiSoi as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomNoiSoi as MaNhomChiDinh, n.TenNhomNoiSoi as TenNhomChiDinh, MaPhanLoai");
        //    sqlQuery.AppendLine(", GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien");
        //    sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat, 0 as LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KetQua_CLS_NoiSoi x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi n on x.MaNhomNoiSoi = n.MaNhomNoiSoi");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and XNGui = 1", ""));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine("Union all");
        //    sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan");
        //    sqlQuery.AppendLine(", cast(MaYeuCau as varchar(20)) as MaChiDinh, TenYeuCau as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomDichVu as MaNhomChiDinh");
        //    sqlQuery.AppendLine(", n.TenNhomDichVu as TenNhomChiDinh, MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile");
        //    sqlQuery.AppendLine(", cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat, 0 as LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KhamBenh_KetQua x left join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu n on x.MaNhomDichVu = n.MaNhomDichVu");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and XNGui = 1", ""));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine(" Union all");
        //    sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaDVKhac as varchar(20)) as MaChiDinh");
        //    sqlQuery.AppendLine(", TenDVKhac as TenChiDinh, cast(101 as int) as ThuTuIn, n.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
        //    sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong");
        //    sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat, 0 as LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from KetQua_CLS_DVKhac x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac n  on x.MaNhomCLS = n.MaNhomCLS");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and XNGui = 1", ""));
        //    sqlQuery.AppendLine("");
        //    sqlQuery.AppendLine("Union all");
        //    sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan");
        //    sqlQuery.AppendLine(", cast(MaThuoc as varchar(20)) as MaChiDinh, TenThuoc as TenChiDinh, cast(102 as int) as ThuTuIn");
        //    sqlQuery.AppendLine(" , n.MaNhomThuoc as MaNhomChiDinh, n.TenNhomThuoc as TenNhomChiDinh, MaPhanLoai, DonGia as GiaRieng, cast(0 as bit) as TieuDe, DaXuatKho as DaKkoa");
        //    sqlQuery.AppendLine(", null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, Soluong as SoLuong, Soluong * DonGia as ThanhTien, 'A' as LoaiMau");
        //    sqlQuery.AppendLine(", 0 as TienCong, IDBienLai, case when XuatTheoQCDG = 1 then DVTQuiCachCap1 else DonViTinh end as DonViTinh, N'' as KetQua, 0 as Flat, 0 as LoaiXetNghiem");
        //    sqlQuery.AppendLine("\n, NULL as DoiTacNhanMauXN, NULL as TGThucHienGuiDoiTac");
        //    sqlQuery.AppendLine("from ThuPhi_Thuoc x left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on x.MaGocThuoc = g.MaGocThuoc");
        //    sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc n on g.MaGocThuoc = n.MaNhomThuoc");
        //    sqlQuery.AppendFormat("where {0}", condit.Replace("and XNGui = 1", "").ToUpper().Replace("GIARIENG", "DonGia"));
        //    sqlQuery.AppendLine(") as A left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = A.MaPhanLoai");
        //    sqlQuery.AppendLine("Inner join BenhNhan_TiepNhan T on T.MaTiepNhan = A.MaTiepNhan");
        //    sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu dt on T.DoiTuongDichVu = dt.MaDoiTuongDichVu");
        //    sqlQuery.AppendLine("order by D.ThuTuIn, D.MaPhanLoai, A.ThuTuIn, A.Sapxep, MaNhomChiDinh, MaChiDinh, TenChiDinh");

        //    var returnlist = new List<SeviceOrderedInformation>();

        //    var ds = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString());
        //    var data = ds.Tables[0];

        //    if (sapXepTheoThuTuInNhom)
        //    {
        //        var distinctCatePrint = data.DefaultView.ToTable(true, new string[] { "ThuTuPhanLoai", "ThuTuIn", "TenNhomChiDinh" });
        //        distinctCatePrint.DefaultView.Sort = "ThuTuPhanLoai, ThuTuIn asc";

        //        for (int i = 0; i < data.Rows.Count; i++)
        //        {
        //            string catePrint = data.Rows[i]["TenNhomChiDinh"].ToString().Trim();
        //            var currentIndex = 0;
        //            for (int a = 0; a < distinctCatePrint.Rows.Count; a++)
        //            {
        //                if (catePrint.Trim().Equals(distinctCatePrint.Rows[a]["TenNhomChiDinh"].ToString().Trim()))
        //                {
        //                    currentIndex = a + 1;
        //                    break;
        //                }
        //            }
        //            data.Rows[i]["TenNhomChiDinh"] = string.Format("[{0}] - {1}", Utilities.LayStt(currentIndex, 1), catePrint.Trim().ToUpper());
        //        }
        //    }
        //    returnlist = ds.Tables[0].AsEnumerable().Select(dataRow => new SeviceOrderedInformation
        //    {
        //        isChecked = bool.Parse(dataRow["isChecked"].ToString()),
        //        chon = bool.Parse(dataRow["chon"].ToString()),
        //        stt = int.Parse(string.IsNullOrEmpty(dataRow["stt"].ToString()) ? "0" : dataRow["stt"].ToString()),
        //        SapXep = int.Parse(dataRow["SapXep"].ToString()),
        //        ThuTuIn = int.Parse(dataRow["ThuTuIn"].ToString()),
        //        MaTiepNhan = dataRow["MaTiepNhan"].ToString(),
        //        MaBenhNhan = dataRow["MaBenhNhan"].ToString(),
        //        SoBHYT = dataRow["SoBHYT"].ToString(),
        //        NgayHetHanBHYT = (string.IsNullOrEmpty(dataRow["NgayHetHanBHYT"].ToString()) ? (DateTime?)null : DateTime.Parse(dataRow["NgayHetHanBHYT"].ToString())),
        //        TenBenhNhan = dataRow["TenBenhNhan"].ToString(),
        //        NamSinh = int.Parse(dataRow["NamSinh"].ToString()),
        //        SinhNhat = (string.IsNullOrEmpty(dataRow["SinhNhat"].ToString()) ? (DateTime?)null : DateTime.Parse(dataRow["SinhNhat"].ToString())),
        //        CoNgaySinh = bool.Parse(dataRow["CoNgaySinh"].ToString()),
        //        GioiTinh = dataRow["GioiTinh"].ToString(),
        //        NgayTiepNhan = DateTime.Parse(dataRow["NgayTiepNhan"].ToString()),
        //        ThoiGianNhap = DateTime.Parse(dataRow["ThoiGianNhap"].ToString()),
        //        UserNhap = dataRow["UserNhap"].ToString(),
        //        MaDoiTuongDichVu = dataRow["MaDoiTuongDichVu"].ToString(),
        //        TenDoiTuongDichVu = dataRow["TenDoiTuongDichVu"].ToString(),
        //        SoNha = dataRow["SoNha"].ToString(),
        //        PhuongXa = dataRow["PhuongXa"].ToString(),
        //        MaHuyen = dataRow["MaHuyen"].ToString(),
        //        MaTinh = dataRow["MaTinh"].ToString(),
        //        DiaChi = dataRow["DiaChi"].ToString(),
        //        RSoPhieuYeuCau = dataRow["RSoPhieuYeuCau"].ToString(),
        //        MaChiDinh = dataRow["MaChiDinh"].ToString(),
        //        TenChiDinh = dataRow["TenChiDinh"].ToString(),
        //        MaNhomChiDinh = dataRow["MaNhomChiDinh"].ToString(),
        //        TenNhomChiDinh = dataRow["TenNhomChiDinh"].ToString(),
        //        MaPhanLoai = dataRow["MaPhanLoai"].ToString(),
        //        TenPhanLoai = dataRow["TenPhanLoai"].ToString(),
        //        ThuTuPhanLoai = int.Parse(dataRow["ThuTuPhanLoai"].ToString()),
        //        GiaRieng = double.Parse(dataRow["GiaRieng"].ToString()),
        //        DaKkoa = bool.Parse(dataRow["DaKkoa"].ToString()),
        //        MaProfile = dataRow["MaProfile"].ToString(),
        //        ChiDinhCha = bool.Parse(dataRow["ChiDinhCha"].ToString()),
        //        LoaiMau = dataRow["LoaiMau"].ToString(),
        //        TienCong = double.Parse(dataRow["TienCong"].ToString()),
        //        DaThuTien = bool.Parse(dataRow["DaThuTien"].ToString()),
        //        SoLuong = int.Parse(dataRow["SoLuong"].ToString()),
        //        IDBienLai = dataRow["IDBienLai"].ToString(),
        //        DonViTinh = dataRow["DonViTinh"].ToString(),
        //        KetQua = dataRow["KetQua"].ToString(),
        //        Flat = int.Parse(dataRow["Flat"].ToString()),
        //        SDT = dataRow["SDT"].ToString(),
        //        Seq = dataRow["Seq"].ToString(),
        //        LoaiXetNghiem = int.Parse(dataRow["LoaiXetNghiem"].ToString())
        //    }).ToList();

        //    return returnlist;
        //}

        public List<SeviceOrderedInformation> OrderedServices(string condit, bool sapXepTheoThuTuInNhom)
        {
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select cast (0 as bit) as isChecked, A.*, D.TenPhanLoai, D.ThuTuIn as ThuTuPhanLoai, T.[MaBN] as MaBenhNhan , T.[SoBHYT], T.[NgayHetHanBHYT], T.[TenBN] as TenBenhNhan");
            sqlQuery.AppendLine(", T.[SinhNhat], T.[Tuoi] as NamSinh, T.[CoNgaySinh], T.[GioiTinh], T.[NgayTiepNhan], T.[ThoiGianNhap], T.[UserNhap]");
            sqlQuery.AppendLine(", dt.MaDoiTuongDichVu, dt.TenDoiTuongDichVu, T.[DiaChi], T.[SoNha], T.[PhuongXa], T.[MaHuyen], T.[MaTinh], T.SDT, T.Seq, nv.TenNhanVien as TenBSChiDinh");
            sqlQuery.AppendLine(", kdt.TenBoPhan as KhuDieuTri, kh.TenKhoaPhong as TenKhoa, ph.TenPhong");
            sqlQuery.AppendLine(" from(");
            sqlQuery.AppendLine("select STT, RSoPhieuYeuCau, dm.Sapxep, cast(0 as bit) as chon, MatiepNhan, x.MaXN as MaChiDinh");
            sqlQuery.AppendLine(", x.TenXN as TenChiDinh, x.ThuTuIn, x.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
            sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, x.XacNhanKQ as DaKkoa, x.ProfileID as MaProfile, x.XNChinh as ChiDinhCha, DaThuTien");
            sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, x.LoaiMau, TienCong, IDBienLai, N'Lần' as DonViTinh, x.KetQua, x.Flat");
            sqlQuery.AppendLine("from KetQua_CLS_XetNghiem x inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on x.MaNhomCLS = n.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm on x.maxn = dm.maxn ");
            sqlQuery.AppendFormat("where {0}", condit.Replace("and GiaRieng > 0", "and dm.KhongSD = 1"));
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, RSoPhieuYeuCau, dm.Sapxep, cast(0 as bit) as chon, MatiepNhan, x.MaYeuCau as MaChiDinh");
            sqlQuery.AppendLine(", x.TenYeuCau as TenChiDinh, x.ThuTuIn, n.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
            sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, x.DaXacNhan as DaKkoa, null as MaProfile, cast (0 as bit) as ChiDinhCha, DaThuTien");
            sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, x.MaLoaiMau as LoaiMau, TienCong, IDBienLai, N'Lần' as DonViTinh, null as KetQua, cast (0 as int) as Flat");
            sqlQuery.AppendLine("from KetQua_CLS_XetNghiem_ViSinh x inner join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n on x.MaNhomYeuCau = n.MaNhomCLS inner join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm on x.MaYeuCau = dm.maxn ");
            sqlQuery.AppendFormat("where {0}", condit.Replace("and GiaRieng > 0", "and dm.KhongSD = 1"));
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaSoMau as varchar(20)) as MaChiDinh");
            sqlQuery.AppendLine(", TenMauSieuAm as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomSieuAm as MaNhomChiDinh, n.TenNhomSieuAm as TenNhomChiDinh");
            sqlQuery.AppendLine(" , MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe");
            sqlQuery.AppendLine(" , XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong");
            sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat");
            sqlQuery.AppendLine("from KetQua_CLS_SieuAm x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_SieuAm n on x.MaNhomSieuAm = n.MaNhomSieuAm");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(" Union all");
            sqlQuery.AppendLine("select distinct 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon");
            sqlQuery.AppendLine(", MatiepNhan, cast(k.MaVungChup as varchar(20)) as MaChiDinh, VC.TenVungChup as TenChiDinh, cast(100 as int) as ThuTuIn");
            sqlQuery.AppendLine(", k.MaKyThuatChup as MaNhomChiDinh, n.TenKyThuatChup as TenNhomChiDinh, MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa");
            sqlQuery.AppendLine(", null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau");
            sqlQuery.AppendLine(", 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat");
            sqlQuery.AppendLine("from KetQua_CLS_XQuang k left");
            sqlQuery.AppendLine("join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_vungchup VC on k.MaVungChup = VC.MaVungChup");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_xquang_kythuatchup n on n.MaKyThuatChup = vc.MaKyThuatChup");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaSoMauNoiSoi as varchar(20)) as MaChiDinh");
            sqlQuery.AppendLine(", TenMauNoiSoi as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomNoiSoi as MaNhomChiDinh, n.TenNhomNoiSoi as TenNhomChiDinh, MaPhanLoai");
            sqlQuery.AppendLine(", GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien");
            sqlQuery.AppendLine(", cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat");
            sqlQuery.AppendLine("from KetQua_CLS_NoiSoi x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_NoiSoi n on x.MaNhomNoiSoi = n.MaNhomNoiSoi");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan");
            sqlQuery.AppendLine(", cast(MaYeuCau as varchar(20)) as MaChiDinh, TenYeuCau as TenChiDinh, cast(100 as int) as ThuTuIn, n.MaNhomDichVu as MaNhomChiDinh");
            sqlQuery.AppendLine(", n.TenNhomDichVu as TenNhomChiDinh, MaPhanLoai, GiaRieng, cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile");
            sqlQuery.AppendLine(", cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong, 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat");
            sqlQuery.AppendLine("from KhamBenh_KetQua x left join {{TPH_Standard}}_Dictionary.dbo.dm_khambenh_nhomdichvu n on x.MaNhomDichVu = n.MaNhomDichVu");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine(" Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan, cast(MaDVKhac as varchar(20)) as MaChiDinh");
            sqlQuery.AppendLine(", TenDVKhac as TenChiDinh, cast(101 as int) as ThuTuIn, n.MaNhomCLS as MaNhomChiDinh, n.TenNhomCLS as TenNhomChiDinh, MaPhanLoai, GiaRieng");
            sqlQuery.AppendLine(", cast(0 as bit) as TieuDe, XacNhanKQ as DaKkoa, null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, cast(1 as int) as SoLuong");
            sqlQuery.AppendLine(", 1 * GiaRieng as ThanhTien, 'A' as LoaiMau, 0 as TienCong, IDBienLai, N'Lần' as DonViTinh, N'' as KetQua, 0 as Flat");
            sqlQuery.AppendLine("from KetQua_CLS_DVKhac x left join {{TPH_Standard}}_Dictionary.dbo.DM_NhomCLS_DVKhac n  on x.MaNhomCLS = n.MaNhomCLS");
            sqlQuery.AppendFormat("where {0}", condit);
            sqlQuery.AppendLine("");
            sqlQuery.AppendLine("Union all");
            sqlQuery.AppendLine("select 0 as STT, null as RSoPhieuYeuCau, 0, cast(0 as bit) as chon, MatiepNhan");
            sqlQuery.AppendLine(", cast(MaThuoc as varchar(20)) as MaChiDinh, TenThuoc as TenChiDinh, cast(102 as int) as ThuTuIn");
            sqlQuery.AppendLine(" , n.MaNhomThuoc as MaNhomChiDinh, n.TenNhomThuoc as TenNhomChiDinh, MaPhanLoai, DonGia as GiaRieng, cast(0 as bit) as TieuDe, DaXuatKho as DaKkoa");
            sqlQuery.AppendLine(", null as MaProfile, cast(0 as bit) as ChiDinhCha, DaThuTien, Soluong as SoLuong, Soluong * DonGia as ThanhTien, 'A' as LoaiMau");
            sqlQuery.AppendLine(", 0 as TienCong, IDBienLai, case when XuatTheoQCDG = 1 then DVTQuiCachCap1 else DonViTinh end as DonViTinh, N'' as KetQua, 0 as Flat");
            sqlQuery.AppendLine("from ThuPhi_Thuoc x left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on x.MaGocThuoc = g.MaGocThuoc");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc n on g.MaGocThuoc = n.MaNhomThuoc");
            sqlQuery.AppendFormat("where {0}", condit.ToUpper().Replace("GIARIENG", "DonGia"));
            sqlQuery.AppendLine(") as A left join {{TPH_Standard}}_Dictionary.dbo.CauHinh_PhanLoaiChucNang D on D.MaPhanLoai = A.MaPhanLoai");
            sqlQuery.AppendLine("Inner join BenhNhan_TiepNhan T on T.MaTiepNhan = A.MaTiepNhan");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu dt on T.DoiTuongDichVu = dt.MaDoiTuongDichVu");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.ql_nhanvien nv on nv.MaNhanVien = t.BacSiCD");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_khoaphong kh on kh.MaKhoaPhong = t.MaDonVi");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_bophan kdt on kdt.MaBoPhan = kh.MaBoPhan");
            sqlQuery.AppendLine("left join {{TPH_Standard}}_Dictionary.dbo.dm_phong ph on ph.MaKhoaPhong = kh.MaKhoaPhong and ph.maphong = t.MaSoPhong");
            sqlQuery.AppendLine("order by D.ThuTuIn, D.MaPhanLoai, A.ThuTuIn, A.Sapxep, MaNhomChiDinh, MaChiDinh, TenChiDinh");

            var returnlist = new List<SeviceOrderedInformation>();


            var ds = DataProvider.ExecuteDataset(CommandType.Text, sqlQuery.ToString());
            var data = ds.Tables[0];

            if (sapXepTheoThuTuInNhom)
            {
                var distinctCatePrint = data.DefaultView.ToTable(true, new string[] { "ThuTuPhanLoai", "ThuTuIn", "TenNhomChiDinh" });
                distinctCatePrint.DefaultView.Sort = "ThuTuPhanLoai, ThuTuIn asc";

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string catePrint = data.Rows[i]["TenNhomChiDinh"].ToString().Trim();
                    var currentIndex = 0;
                    for (int a = 0; a < distinctCatePrint.Rows.Count; a++)
                    {
                        if (catePrint.Trim().Equals(distinctCatePrint.Rows[a]["TenNhomChiDinh"].ToString().Trim()))
                        {
                            currentIndex = a + 1;
                            break;
                        }
                    }
                    data.Rows[i]["TenNhomChiDinh"] = string.Format("[{0}] - {1}", Utilities.LayStt(currentIndex, 1), catePrint.Trim().ToUpper());
                }
            }
            returnlist = ds.Tables[0].AsEnumerable().Select(dataRow => new SeviceOrderedInformation
            {
                isChecked = bool.Parse(dataRow["isChecked"].ToString()),
                chon = bool.Parse(dataRow["chon"].ToString()),
                stt = int.Parse(string.IsNullOrEmpty(dataRow["stt"].ToString()) ? "0" : dataRow["stt"].ToString()),
                SapXep = int.Parse(dataRow["SapXep"].ToString()),
                ThuTuIn = int.Parse(dataRow["ThuTuIn"].ToString()),
                MaTiepNhan = dataRow["MaTiepNhan"].ToString(),
                MaBenhNhan = dataRow["MaBenhNhan"].ToString(),
                SoBHYT = dataRow["SoBHYT"].ToString(),
                NgayHetHanBHYT = (string.IsNullOrEmpty(dataRow["NgayHetHanBHYT"].ToString()) ? (DateTime?)null : DateTime.Parse(dataRow["NgayHetHanBHYT"].ToString())),
                TenBenhNhan = dataRow["TenBenhNhan"].ToString(),
                NamSinh = int.Parse(dataRow["NamSinh"].ToString()),
                SinhNhat = (string.IsNullOrEmpty(dataRow["SinhNhat"].ToString()) ? (DateTime?)null : DateTime.Parse(dataRow["SinhNhat"].ToString())),
                CoNgaySinh = bool.Parse(dataRow["CoNgaySinh"].ToString()),
                GioiTinh = dataRow["GioiTinh"].ToString(),
                NgayTiepNhan = DateTime.Parse(dataRow["NgayTiepNhan"].ToString()),
                ThoiGianNhap = DateTime.Parse(dataRow["ThoiGianNhap"].ToString()),
                UserNhap = dataRow["UserNhap"].ToString(),
                MaDoiTuongDichVu = dataRow["MaDoiTuongDichVu"].ToString(),
                TenDoiTuongDichVu = dataRow["TenDoiTuongDichVu"].ToString(),
                SoNha = dataRow["SoNha"].ToString(),
                PhuongXa = dataRow["PhuongXa"].ToString(),
                MaHuyen = dataRow["MaHuyen"].ToString(),
                MaTinh = dataRow["MaTinh"].ToString(),
                DiaChi = dataRow["DiaChi"].ToString(),
                RSoPhieuYeuCau = dataRow["RSoPhieuYeuCau"].ToString(),
                MaChiDinh = dataRow["MaChiDinh"].ToString(),
                TenChiDinh = dataRow["TenChiDinh"].ToString(),
                MaNhomChiDinh = dataRow["MaNhomChiDinh"].ToString(),
                TenNhomChiDinh = dataRow["TenNhomChiDinh"].ToString(),
                MaPhanLoai = dataRow["MaPhanLoai"].ToString(),
                TenPhanLoai = dataRow["TenPhanLoai"].ToString(),
                ThuTuPhanLoai = int.Parse(dataRow["ThuTuPhanLoai"].ToString()),
                GiaRieng = double.Parse(dataRow["GiaRieng"].ToString()),
                DaKkoa = bool.Parse(dataRow["DaKkoa"].ToString()),
                MaProfile = dataRow["MaProfile"].ToString(),
                ChiDinhCha = bool.Parse(dataRow["ChiDinhCha"].ToString()),
                LoaiMau = dataRow["LoaiMau"].ToString(),
                TienCong = double.Parse(dataRow["TienCong"].ToString()),
                DaThuTien = bool.Parse(dataRow["DaThuTien"].ToString()),
                SoLuong = int.Parse(dataRow["SoLuong"].ToString()),
                IDBienLai = dataRow["IDBienLai"].ToString(),
                DonViTinh = dataRow["DonViTinh"].ToString(),
                KetQua = dataRow["KetQua"].ToString(),
                Flat = int.Parse(dataRow["Flat"].ToString()),
                SDT = dataRow["SDT"].ToString(),
                Seq = dataRow["Seq"].ToString(),
                KhuDieuTri = dataRow["KhuDieuTri"].ToString(),
                TenKhoa = dataRow["TenKhoa"].ToString(),
                TenPhong = dataRow["TenPhong"].ToString(),
                TenBSChiDinh = dataRow["TenBSChiDinh"].ToString(),
            }).ToList();
            return returnlist;
        }
        #endregion

        #region Thao tác với thông tin bệnh nhân
        public bool Check_TonTai_MaTiepNhan(string matiepNhan)
        {
            return DataProvider.CheckExisted("select top 1 * from BenhNhan_TiepNhan where Matiepnhan =  '" + matiepNhan + "'");
        }
        public DataTable TimBenhNhan(SearchPatientCondit objCondit)
        {
            var sqlPara = new SqlParameter[]
               {
                        WorkingServices.GetParaFromOject("@tungay", objCondit.tungay??(object)DBNull.Value)
                         , WorkingServices.GetParaFromOject("@denngay",objCondit.denngay??(object)DBNull.Value)
                         , WorkingServices.GetParaFromOject("@maDoiTuong", string.IsNullOrEmpty(objCondit.maDoiTuong)?(object)DBNull.Value: objCondit.maDoiTuong)
                         , WorkingServices.GetParaFromOject("@tenBN", string.IsNullOrEmpty(objCondit.tenBN)?(object)DBNull.Value: objCondit.tenBN)
                         , WorkingServices.GetParaFromOject("@barcode",  string.IsNullOrEmpty(objCondit.barcode)?(object)DBNull.Value: objCondit.barcode)
                         , WorkingServices.GetParaFromOject("@maBN", string.IsNullOrEmpty(objCondit.maBN)?(object)DBNull.Value: objCondit.maBN)
                         , WorkingServices.GetParaFromOject("@sdt",  string.IsNullOrEmpty(objCondit.sdt)?(object)DBNull.Value: objCondit.sdt)
                         , WorkingServices.GetParaFromOject("@sophieuHis", string.IsNullOrEmpty(objCondit.sophieuHis)?(object)DBNull.Value: objCondit.sophieuHis)
                         , WorkingServices.GetParaFromOject("@idCongDan", string.IsNullOrEmpty(objCondit.idCongDan)?(object)DBNull.Value: objCondit.idCongDan)
                         , WorkingServices.GetParaFromOject("@maKhuVuc",  string.IsNullOrEmpty(objCondit.khuTiepNhan)?(object)DBNull.Value: objCondit.khuTiepNhan)
                         , WorkingServices.GetParaFromOject("@nguonnhap",  objCondit.nguonnhap)
                         , WorkingServices.GetParaFromOject("@soHoSo",  objCondit.soHoSo)
               };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selTim_BenhNhan"
             , sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable TimBenhNhanXetNghiem(SearchPatientCondit_XN objCondit)
        {
            var sqlPara = new SqlParameter[]
               {
                        WorkingServices.GetParaFromOject("@tungay", objCondit.tungay??(object)DBNull.Value)
                         , WorkingServices.GetParaFromOject("@denngay",objCondit.denngay??(object)DBNull.Value)
                         , WorkingServices.GetParaFromOject("@maDoiTuong", string.IsNullOrEmpty(objCondit.maDoiTuong)?(object)DBNull.Value: objCondit.maDoiTuong)
                         , WorkingServices.GetParaFromOject("@tenBN", string.IsNullOrEmpty(objCondit.tenBN)?(object)DBNull.Value: objCondit.tenBN)
                         , WorkingServices.GetParaFromOject("@barcode",  string.IsNullOrEmpty(objCondit.barcode)?(object)DBNull.Value: objCondit.barcode)
                         , WorkingServices.GetParaFromOject("@maBN", string.IsNullOrEmpty(objCondit.maBN)?(object)DBNull.Value: objCondit.maBN)
                         , WorkingServices.GetParaFromOject("@sdt",  string.IsNullOrEmpty(objCondit.sdt)?(object)DBNull.Value: objCondit.sdt)
                         , WorkingServices.GetParaFromOject("@sophieuHis", string.IsNullOrEmpty(objCondit.sophieuHis)?(object)DBNull.Value: objCondit.sophieuHis)
                         , WorkingServices.GetParaFromOject("@idCongDan", string.IsNullOrEmpty(objCondit.idCongDan)?(object)DBNull.Value: objCondit.idCongDan)
                         , WorkingServices.GetParaFromOject("@daNhanMau", (int)objCondit.daNhanMau)
                         , WorkingServices.GetParaFromOject("@daLayMauTatCa", (int)objCondit.daLayMau)
                         , WorkingServices.GetParaFromOject("@daTraKQ",(int)objCondit.daTraKQ)
                         , WorkingServices.GetParaFromOject("@daDuKQ", (int)objCondit.daDuKQ)
                         , WorkingServices.GetParaFromOject("@dainKQ",(int)objCondit.dainKQ)
                         , WorkingServices.GetParaFromOject("@daXacNhanKQ", (int)objCondit.daXacNhanKQ)
                         , WorkingServices.GetParaFromOject("@loaiDichVu",(object)DBNull.Value)
                         , WorkingServices.GetParaFromOject("@maKhuVuc",  string.IsNullOrEmpty(objCondit.khuTiepNhan)?(object)DBNull.Value: objCondit.khuTiepNhan)
                         , WorkingServices.GetParaFromOject("@testType",(objCondit.testType == null ?  string.Empty : Utilities.ConvertStrinArryToInClauseSQL(objCondit.testType.Select(a=>((int)a).ToString()).ToArray(), false) ))
                         , WorkingServices.GetParaFromOject("@nguonnhap",  objCondit.nguonnhap)
                         , WorkingServices.GetParaFromOject("@soHoSo",  objCondit.soHoSo)
               };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selTim_BenhNhan_XnThuongQui"
             , sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable LayThongtin_TiepNhan_TheoMaBN(string _MaBN)
        {
            DataTable dtNoiTru = new DataTable();
            string strSQL = "select top 1 * from BenhNhan_TiepNhan where MaBN ='" + _MaBN + "' order by NgayTiepNhan desc";
            dtNoiTru = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtNoiTru;
        }
        public DataTable LayThongtin_TiepNhan_TheoSoDienThoai(string sodienThoai)
        {
            DataTable dtSodienthoai = new DataTable();
            string strSQL = "select top 1 * from BenhNhan_TiepNhan where SDT ='" + sodienThoai + "' order by NgayTiepNhan desc";
            dtSodienthoai = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtSodienthoai;
        }
        public DataTable LayThongtin_TiepNhan_IdCongDan(string idCongDan)
        {
            DataTable dtIdCongDan = new DataTable();
            string strSQL = "select top 1 * from BenhNhan_TiepNhan where IdCongDan ='" + idCongDan + "' order by NgayTiepNhan desc";
            dtIdCongDan = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtIdCongDan;
        }
        public DataTable LayDanhSach_TiepNhan_TheoMaBN(string _MaBN)
        {
            DataTable dtNoiTru = new DataTable();
            string strSQL = "select t.*, nv.TenNhanVien from BenhNhan_TiepNhan t left join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD = nv.MaNhanVien where MaBN ='" + _MaBN + "' order by NgayTiepNhan desc";
            dtNoiTru = DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
            return dtNoiTru;
        }
        public DataTable LayDanhSach_NoiTru(string _MaBN, string _Name)
        {
            DataTable dtNoiTru = new DataTable();
            string strSQL = "";
            _Name = Utilities.ConvertSqlString(_Name);
            strSQL = "select A.* , ct.HinhBN, ct.QuocTich, ct.DanToc, ct.HocVan, ct.NgheNghiep, ct.NoiLamViec";
            strSQL += "\n from (";
            strSQL += "\n Select distinct t.NoiTru, t.MaBN, t.SoBHYT, t.TenBN, t.SinhNhat, ";
            strSQL += "\n t.Tuoi, t.CoNgaySinh, t.GioiTinh, t.DoiTuongDichVu, t.DiaChi, t.PhuongXa,T.SoNha,t.MaHuyen,T.MaTinh, ";
            strSQL += "\n  t.Email, t.SDT,t.TenDonVi,t.YeuCau,t.NhanXetBS,t.TGVaoVien,t.KhamLanDau ";
            strSQL += "\n from BenhNhan_TiepNhan t where 1 = 1";
            if (_MaBN != "")
            {
                strSQL += "\n and MaBN = '" + _MaBN + "'";
            }
            if (_Name != "")
            {
                strSQL += "  \n and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            strSQL += "\n ) as A left join BenhNhan_ThongTinChiTiet ct on A.MaBN = ct.MaBN order by A.TenBN ";
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }
        public DataTable LayDanhSach_LichSuNoiTru(string _MaBN, string _Name)
        {
            var dtNoiTru = new DataTable();
            _Name = Utilities.ConvertSqlString(_Name);
            var strSql = "select A.* , ct.HinhBN, ct.QuocTich, ct.DanToc, ct.HocVan, ct.NgheNghiep, ct.NoiLamViec";
            strSql += "\n from (";
            strSql += "\n Select distinct t.MaTiepNhan, t.NgayTiepNhan,t.Seq, t.NoiTru, t.MaBN, t.SoBHYT, t.TenBN, t.SinhNhat, ";
            strSql += "\n t.Tuoi, t.CoNgaySinh, t.GioiTinh, t.DoiTuongDichVu, t.DiaChi, t.PhuongXa,T.SoNha,t.MaHuyen,T.MaTinh, ";
            strSql += "\n  t.Email, t.SDT,t.TenDonVi,t.YeuCau,t.NhanXetBS,t.TGVaoVien,t.KhamLanDau ";
            strSql += "\n from BenhNhan_TiepNhan t where 1 = 1";
            //if (_MaBN != "")
            //{
            strSql += "\n and MaBN = '" + _MaBN + "'";
            //}
            if (_Name != "")
            {
                strSql += "  \n and (t.tenBN like N'%" + _Name.Trim() + "%' or t.tenBN like N'%" + _Name.Trim() + "' or t.tenBN like N'" + _Name.Trim() + "%' or t.tenBN = N'" + _Name.Trim() + "')";
            }
            strSql += "\n ) as A left join BenhNhan_ThongTinChiTiet ct on A.MaBN = ct.MaBN order by A.TenBN ";
            dtNoiTru = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            return dtNoiTru;
        }
        public bool Insert_BenhNhan_ThongTinChiTiet(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec, string _quoctich)
        {
            string _strSQL = "insert into  BENHNHAN_THONGTINCHITIET (";
            _strSQL += Environment.NewLine + "dantoc";
            _strSQL += "\n," + "hocvan";
            _strSQL += "\n," + "mabn";
            _strSQL += "\n," + "nghenghiep";
            _strSQL += "\n," + "noilamviec";
            _strSQL += "\n," + "quoctich";
            _strSQL += Environment.NewLine + ")";
            _strSQL += Environment.NewLine + "select ";
            _strSQL += Environment.NewLine + (_dantoc == "" ? "NULL" : "N'" + _dantoc + "'");
            _strSQL += "\n," + (_hocvan == "" ? "NULL" : "N'" + _hocvan + "'");
            _strSQL += "\n," + (_mabn == "" ? "''" : "'" + _mabn + "'");
            _strSQL += "\n," + (_nghenghiep == "" ? "NULL" : "N'" + _nghenghiep + "'");
            _strSQL += "\n," + (_noilamviec == "" ? "NULL" : "N'" + _noilamviec + "'");
            _strSQL += "\n," + (_quoctich == "" ? "NULL" : "'" + _quoctich + "'");
            if (!DataProvider.CheckExisted("select top 1 * from BenhNhan_ThongTinChiTiet where 1 = 1  and mabn =  " + (_mabn == "" ? "''" : "'" + _mabn + "'")))
            {
                DataProvider.ExecuteNonQuery(CommandType.Text, _strSQL);
                Update_HinhChiTiet(_mabn, _hinhbn);
                return true;
            }
            else
            {
                Update_HinhChiTiet(_mabn, _hinhbn);
                return Update_BENHNHAN_THONGTINCHITIET(_dantoc, _hinhbn, _hocvan, _mabn, _nghenghiep, _noilamviec, _quoctich);
            }
        }
        public bool Update_BENHNHAN_THONGTINCHITIET(string _dantoc, Image _hinhbn, string _hocvan, string _mabn, string _nghenghiep, string _noilamviec, string _quoctich)
        {
            string _strSQL = "Update BenhNhan_ThongTinChiTiet set " + Environment.NewLine;
            _strSQL += Environment.NewLine + "dantoc = " + (_dantoc == "" ? "NULL" : "N'" + _dantoc + "'");
            _strSQL += Environment.NewLine + ",hocvan = " + (_hocvan == "" ? "NULL" : "N'" + _hocvan + "'");
            _strSQL += Environment.NewLine + ",nghenghiep = " + (_nghenghiep == "" ? "NULL" : "N'" + _nghenghiep + "'");
            _strSQL += Environment.NewLine + ",noilamviec = " + (_noilamviec == "" ? "NULL" : "N'" + _noilamviec + "'");
            _strSQL += Environment.NewLine + ",quoctich = " + (_quoctich == "" ? "NULL" : "'" + _quoctich + "'");
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and mabn =  " + (_mabn == "" ? "''" : "'" + _mabn + "'");
            return DataProvider.ExecuteQuery(_strSQL);
        }
        private void Update_HinhChiTiet(string _MaBenhNhan, Image img)
        {
            string strSQL = "update BenhNhan_ThongTinChiTiet set hinhbn = @hinhanh where MaBN ='" + _MaBenhNhan + "'";
            DataProvider.ExcuteWithImage(strSQL, GraphicSupport.ImageToByteArray(img), img == null);
        }
        public bool Delete_BENHNHAN_THONGTINCHITIET(string _mabn)
        {
            string _strSQL = "Delete from BenhNhan_ThongTinChiTiet" + Environment.NewLine;
            _strSQL += Environment.NewLine + " where 1=1 ";
            _strSQL += Environment.NewLine + " and mabn =  " + (_mabn == "" ? "''" : "'" + _mabn + "'");
            return DataProvider.ExecuteQuery(_strSQL);
        }
        public bool Update_KetQua_huyetTuyDo(BENHNHAN_CLS_XETNGHIEM objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update BENHNHAN_CLS_XETNGHIEM set");
            sb.AppendFormat("\nKetluanhuyettuydo = {0}", (objInfo.Ketluanhuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluanhuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Denghihuyettuydo = {0}", (objInfo.Denghihuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Denghihuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Nhanxethuyettuydo = {0}", (objInfo.Nhanxethuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nhanxethuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Tomtatbenhli = {0}", (objInfo.Tomtatbenhli == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tomtatbenhli.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoilamhuyettuydo = {0}", (objInfo.Nguoilamhuyettuydo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nguoilamhuyettuydo.ToString()) + "'"));
            sb.AppendFormat("\n, Tglamhuyettuydo = {0}", (objInfo.Tglamhuyettuydo == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tglamhuyettuydo.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tglamxylocain = {0}", (objInfo.Tglamxylocain == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tglamxylocain.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Ketquaxylocain = {0}", (objInfo.Ketquaxylocain == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketquaxylocain.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoidocxylocain = {0}", (objInfo.Nguoidocxylocain == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nguoidocxylocain.ToString()) + "'"));
            sb.AppendFormat("\n, Yeucauxetnghiem = {0}", (objInfo.Yeucauxetnghiem == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Yeucauxetnghiem.ToString()) + "'"));
            sb.AppendFormat("\n, Ketluanhuyetdo = {0}", (objInfo.Ketluanhuyetdo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Ketluanhuyetdo.ToString()) + "'"));
            sb.AppendFormat("\n, Denghihuyetdo = {0}", (objInfo.Denghihuyetdo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Denghihuyetdo.ToString()) + "'"));
            sb.AppendFormat("\n, Nhanxethuyetdo = {0}", (objInfo.Nhanxethuyetdo == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Nhanxethuyetdo.ToString()) + "'"));
            sb.AppendFormat("\n, Tgnhanmaumau = {0}", (objInfo.Tgnhanmaumau == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tgnhanmaumau.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tgnhanmaunt = {0}", (objInfo.Tgnhanmaunt == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tgnhanmaunt.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tgnhanmauvisinh = {0}", (objInfo.Tgnhanmauvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tgnhanmauvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Nguoinhanmaumau = {0}", (objInfo.Nguoinhanmaumau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhanmaumau.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoinhanmaunt = {0}", (objInfo.Nguoinhanmaunt == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhanmaunt.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoinhanmauvisinh = {0}", (objInfo.Nguoinhanmauvisinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhanmauvisinh.ToString()) + "'"));
            sb.AppendFormat("\n, Tglaymaumau = {0}", (objInfo.Tglaymaumau == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tglaymaumau.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tglaymaunt = {0}", (objInfo.Tglaymaunt == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tglaymaunt.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Tglaymauvisinh = {0}", (objInfo.Tglaymauvisinh == null ? "NULL" : "'" + DateTime.Parse(objInfo.Tglaymauvisinh.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, Nguoilaymaumau = {0}", (objInfo.Nguoilaymaumau == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoilaymaumau.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoilaymaunt = {0}", (objInfo.Nguoilaymaunt == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoilaymaunt.ToString()) + "'"));
            sb.AppendFormat("\n, Nguoilaymauvisinh = {0}", (objInfo.Nguoilaymauvisinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoilaymauvisinh.ToString()) + "'"));

            sb.Append("\nwhere Matiepnhan =  " + "'" + Utilities.ConvertSqlString(objInfo.Matiepnhan.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool Update_DaNhanMau_Mau(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            if (trangThai != enumThucHien.TatCa)
            {
                StringBuilder sb = new StringBuilder();
                if (trangThai == enumThucHien.DaThucHien)
                {
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGNhanmauMau = getdate() , NguoiNhanMauMau = '{0}' where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                }
                else
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGNhanmauMau =null , NguoiNhanMauMau = null where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public bool Update_DaNhanMau_NT(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            if (trangThai != enumThucHien.TatCa)
            {
                StringBuilder sb = new StringBuilder();
                if (trangThai == enumThucHien.DaThucHien)
                {
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGNhanmauNT = getdate() , NguoiNhanMauNT = '{0}' where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                }
                else
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGNhanmauNT =null , NguoiNhanMauNT = null where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public bool Update_DaNhanMau_ViSinh(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            if (trangThai != enumThucHien.TatCa)
            {
                StringBuilder sb = new StringBuilder();
                if (trangThai == enumThucHien.DaThucHien)
                {
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGNhanmauViSinh = getdate() , NguoiNhanMauViSinh = '{0}' where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                }
                else
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGNhanmauViSinh =null , NguoiNhanMauViSinh = null where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public bool Update_DaLayMau_Mau(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            if (trangThai != enumThucHien.TatCa)
            {
                StringBuilder sb = new StringBuilder();
                if (trangThai == enumThucHien.DaThucHien)
                {
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGLaymauMau = getdate() , NguoiLayMauMau = '{0}' where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                }
                else
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGLaymauMau =null , NguoiLayMauMau = null where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public bool Update_DaLayMau_NT(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            if (trangThai != enumThucHien.TatCa)
            {
                StringBuilder sb = new StringBuilder();
                if (trangThai == enumThucHien.DaThucHien)
                {
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGLaymauNT = getdate() , NguoiLayMauNT = '{0}' where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                }
                else
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGLaymauNT = null , NguoiLayMauNT = null where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public bool Update_DaLayMau_ViSinh(string maTiepNhan, enumThucHien trangThai, string nguoiThucHien)
        {
            if (trangThai != enumThucHien.TatCa)
            {
                StringBuilder sb = new StringBuilder();
                if (trangThai == enumThucHien.DaThucHien)
                {
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGLaymauViSinh = getdate() , NguoiLayMauViSinh = '{0}' where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                }
                else
                    sb.AppendFormat("update benhnhan_cls_xetnghiem set TGLaymauViSinh = null , NguoiLayMauViSinh = null where MaTiepNhan = '{1}'", nguoiThucHien, maTiepNhan);
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }

        #endregion

        #region Hẹn trả kết quả - thời gian thực hiện xét nghiệm
        public DataTable Calculate_TraKetQua(string maTiepNhan, string soHoSo, DateTime? ngayTiepNhan
            , string barcode, string GioLamViec, string GioNghiTrua, string GioLamChieu
            , string GioNghiChieu, int NghiCuoiTuan, ServiceType[] arrLoaiDichVu, bool traTheoXnNghiem)
        {
            string conditLoaiDichVu = string.Empty;
            if (arrLoaiDichVu.Length > 0)
            {
                foreach (var item in arrLoaiDichVu)
                {
                    conditLoaiDichVu += (string.IsNullOrEmpty(conditLoaiDichVu) ? "" : ",") + string.Format("'{0}'", item.ToString());
                }
            }
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@maTiepNhan", WorkingServices.ConvertObjectForSQPara( maTiepNhan))
                , WorkingServices.GetParaFromOject("@MaPhanLoai", conditLoaiDichVu)
                , WorkingServices.GetParaFromOject("@SoHoSo", WorkingServices.ConvertObjectForSQPara(soHoSo))
                , WorkingServices.GetParaFromOject("@NgayTiepNhan", WorkingServices.ConvertObjectForSQPara(ngayTiepNhan))
                , WorkingServices.GetParaFromOject("@Barcode", WorkingServices.ConvertObjectForSQPara(barcode))
            };
            var dataTra = new DataTable();
            if (traTheoXnNghiem)
            {
                dataTra = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_HenTraKetQua_TheoXetNghiem", sqlPara).Tables[0];
            }
            else
            {
                dataTra = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_HenTraKetQua_TheoboPhan", sqlPara).Tables[0];
            }
            if (dataTra.Rows.Count > 0)
            {
                try
                {
                    var dataNghi = sysConfig.Data_dm_ngaynghi_benhnhan(dataTra.Rows[0]["MaTiepNhan"].ToString());
                    KiemTraNgayNghi(ref dataTra, dataNghi, GioLamViec, GioNghiTrua, GioLamChieu, GioNghiChieu, NghiCuoiTuan, DateTime.Now);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.MSG_Error_OK(ex.Message, ex);
                    return dataTra.Clone();
                }
            }
            return dataTra;
        }
        private void KiemTraNgayNghi(ref DataTable dataTra, DataTable dataNghi, string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, DateTime ngayKiemtra)
        {
            foreach (DataRow drTra in dataTra.Rows)
            {
                KiemTraNgayNghi(drTra, dataNghi, GioLamViec, GioNghiTrua, GioLamChieu, GioNghiChieu, NghiCuoiTuan, ngayKiemtra);
            }
            dataTra.AcceptChanges();
        }
        private void KiemTraNgayNghi(DataRow drTra, DataTable dataNghi, string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, DateTime ngayKiemtra)
        {
            var ngay_GioLamViec = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
                , int.Parse(GioLamViec.Split(':')[0]), int.Parse(GioLamViec.Split(':')[1]), 0);
            var ngay_GioNghiTrua = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
                , int.Parse(GioNghiTrua.Split(':')[0]), int.Parse(GioNghiTrua.Split(':')[1]), 59);

            var ngay_GioLamChieu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
         , int.Parse(GioLamChieu.Split(':')[0]), int.Parse(GioLamChieu.Split(':')[1]), 0);
            var ngay_GioNghiChieu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
                , int.Parse(GioNghiChieu.Split(':')[0]), int.Parse(GioNghiChieu.Split(':')[1]), 59);

            if (!string.IsNullOrEmpty(drTra["GioTraKQ"].ToString()))
            {
                var ngayTra = DateTime.Parse(drTra["GioTraKQ"].ToString());

                if (ngayTra.TimeOfDay > ngay_GioNghiChieu.TimeOfDay)
                {
                    ngayTra = ngayTra.AddDays(1);
                    ngayTra = new DateTime(ngayTra.Year, ngayTra.Month, ngayTra.Day, ngayTra.Hour, ngayTra.Minute, 0);
                }
                else if (ngayTra.TimeOfDay > ngay_GioNghiTrua.TimeOfDay && ngayTra.TimeOfDay < ngay_GioLamChieu.TimeOfDay)
                {
                    ngayTra = new DateTime(ngayTra.Year, ngayTra.Month, ngayTra.Day, ngayTra.Hour, ngayTra.Minute, 0);
                }


                if (dataNghi.Rows.Count > 0)
                {
                    foreach (DataRow drNghi in dataNghi.Rows)
                    {
                        var ngayNghi = DateTime.Parse(drNghi["Ngaynghi"].ToString());
                        if (ngayTra.Date == ngayNghi.Date)
                        {
                            ngayTra = ngayTra.AddDays(1);
                        }
                    }
                }

                //Kiểm tra ngày cuối tuần
                var enumCuoiTuan = (EnumNghiCuoiTuan)Enum.Parse(typeof(EnumNghiCuoiTuan), NghiCuoiTuan.ToString());

                if (enumCuoiTuan == EnumNghiCuoiTuan.ChieuChuNhat && ngayTra.DayOfWeek == DayOfWeek.Sunday && ngayTra.TimeOfDay > ngay_GioNghiTrua.TimeOfDay)
                {
                    ngayTra = ngayTra.AddDays(1);
                    ngayTra = new DateTime(ngayTra.Year, ngayTra.Month, ngayTra.Day, ngay_GioLamViec.Hour, ngay_GioLamViec.Minute, 0);
                }
                else if (enumCuoiTuan == EnumNghiCuoiTuan.ChuNhat && ngayTra.DayOfWeek == DayOfWeek.Sunday)
                {
                    ngayTra = ngayTra.AddDays(1);
                    ngayTra = new DateTime(ngayTra.Year, ngayTra.Month, ngayTra.Day, ngay_GioLamViec.Hour, ngay_GioLamViec.Minute, 0);
                }
                else if (enumCuoiTuan == EnumNghiCuoiTuan.ThuBayChuNhat && (ngayTra.DayOfWeek == DayOfWeek.Saturday || ngayTra.DayOfWeek == DayOfWeek.Sunday))
                {
                    if (ngayTra.DayOfWeek == DayOfWeek.Saturday)
                        ngayTra = ngayTra.AddDays(2);
                    else
                        ngayTra = ngayTra.AddDays(1);

                    ngayTra = new DateTime(ngayTra.Year, ngayTra.Month, ngayTra.Day, ngay_GioLamViec.Hour, ngay_GioLamViec.Minute, 0);
                }
                else if (enumCuoiTuan == EnumNghiCuoiTuan.ChieuThubayChuNhat && ((ngayTra.DayOfWeek == DayOfWeek.Saturday && ngayTra.TimeOfDay > ngay_GioNghiTrua.TimeOfDay)
                    || ngayTra.DayOfWeek == DayOfWeek.Sunday))
                {
                    if (ngayTra.DayOfWeek == DayOfWeek.Saturday)
                        ngayTra = ngayTra.AddDays(2);
                    else
                        ngayTra = ngayTra.AddDays(1);

                    ngayTra = new DateTime(ngayTra.Year, ngayTra.Month, ngayTra.Day, (ngayTra.Hour < ngay_GioLamViec.Hour ? ngay_GioLamViec.Hour : ngayTra.Hour), (ngayTra.Hour < ngay_GioLamViec.Hour ? ngay_GioLamViec.Minute : ngayTra.Minute), 0);
                }

                drTra["GioTraKQ"] = ngayTra;
                if (ngayTra != ngayKiemtra)
                {
                    KiemTraNgayNghi(drTra, dataNghi, GioLamViec, GioNghiTrua, GioLamChieu, GioNghiChieu, NghiCuoiTuan, ngayTra);
                }
            }
        }
        public int Update_ThoiGianThucHien(string maTiepNhan)
        {
            var sqlPara = new SqlParameter[] {
                WorkingServices.GetParaFromOject("@MatiepNhan", maTiepNhan)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
              , "updThoiGianThucHien"
              , sqlPara);
        }
        public bool Update_GhiChuHenTraKQ(string matTiepNhan, string maXn, string maNhom, bool cotKetQua, string noidung, DateTime tgtraKQ)
        {
            StringBuilder sb = new StringBuilder();

            sb = new StringBuilder();
            sb.AppendFormat("Update kq set kq.{0} = case when exists (select dm.MaXN from {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem dm where dm.HenTraVaoketQua = 1 and dm.MaXN = kq.maXN) then {1} else null end ", (cotKetQua ? "KetQua" : "GhiChu"), (string.IsNullOrEmpty(noidung) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(noidung))));
            sb.AppendFormat("\n,kq.TGTraKetQua = '{0}'", tgtraKQ.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendFormat("\n from ketqua_cls_xetnghiem kq");
            sb.AppendFormat("\nwhere kq.MaTiepNhan = '{0}' and kq.KetQua is null ", matTiepNhan);
            if (!string.IsNullOrEmpty(maNhom))
                sb.AppendFormat("\n and kq.MaNhomCLS = '{0}'", maNhom);
            if (!string.IsNullOrEmpty(maXn))
                sb.AppendFormat("\n and kq.MaXN = '{0}'", maXn);

            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public DataTable Calculate_TraKetQuaXN(string maTiepNhan, string GioLamViec, string GioNghiTrua, string GioLamChieu, string GioNghiChieu, int NghiCuoiTuan, int cachTinhThoigian)
        {
            var sqlPara = new SqlParameter[] { WorkingServices.GetParaFromOject("@maTiepNhan", maTiepNhan), WorkingServices.GetParaFromOject("@LoaiThoiGian", cachTinhThoigian) };
            var dataTra = DataProvider.ExecuteDataset(CommandType.StoredProcedure
             , "selThoiGianThucHienNhomXN_TheoThoiGian"
             , sqlPara).Tables[0];
            var dataNghi = sysConfig.Data_dm_ngaynghi_benhnhan(maTiepNhan);
            KiemTraNgayNghi(ref dataTra, dataNghi, GioLamViec, GioNghiTrua, GioLamChieu, GioNghiChieu, NghiCuoiTuan, DateTime.Now);

            return dataTra;
        }
        public int Update_ThoiGianThucHienXN(string matiepnhan)
        {
            var para = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MatiepNhan", matiepnhan)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updThoiGianThucHien_XN", para);
        }
        public int Update_ThoiGianThucHienXN_Nhom(string matiepnhan, int loaiThoigian)
        {
            var para = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MatiepNhan", matiepnhan),
                WorkingServices.GetParaFromOject("@LoaiThoiGian", loaiThoigian)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpThoiGianThucHien_XNNhom", para);
        }

        #endregion

        #region Trạng thái mẫu
        public bool KiemTraCoKetQua(string maTiepNhan, string maNhomLoaiMau)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select count (MaXN) as SL from ketqua_cls_xetnghiem where MaTiepNhan = '{0}' and loaimau in (select MaLoaiMau from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU where MaNhomLoaiMau  = '{1}') and KetQua is not null "
                , maTiepNhan, maNhomLoaiMau);
            return int.Parse(DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0].Rows[0]["SL"].ToString()) > 0;
        }
        public bool KiemTraKetQuaDaGuiHis(string maTiepNhan, string maNhomLoaiMau)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select count (MaXN) as SL from ketqua_cls_xetnghiem where MaTiepNhan = '{0}' and loaimau in (select MaLoaiMau from {{TPH_Standard}}_Dictionary.dbo.DM_XETNGHIEM_LOAIMAU where MaNhomLoaiMau  = '{1}') and uploadweb = 1 "
                , maTiepNhan, maNhomLoaiMau);
            return int.Parse(DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0].Rows[0]["SL"].ToString()) > 0;
        }
        public bool Update_MauXn_LayMau(List<LayMauInfo> lstLayMau)
        {
            if (lstLayMau.Count <= 0) return false;
            var icount = 0;
            //Xử lý update theo từng mã tiếp nhận
            //List mã tiếp nhận
            var lstMaTiepNhan = lstLayMau.Select(x => x.MaTiepNhan).Distinct().ToList();
            foreach (var itmMaTiepNhan in lstMaTiepNhan)
            {
                var lstDSLayMauTheoMaTiepNhan = lstLayMau.Where(x => x.MaTiepNhan.Equals(itmMaTiepNhan, StringComparison.OrdinalIgnoreCase)).ToList();
                var lstLoaiXn = lstDSLayMauTheoMaTiepNhan.Select(x => x.LoaiXetNghiem).Distinct().ToList();
                foreach (var itmLoaiXn in lstLoaiXn)
                {
                    var lstThucThi = lstDSLayMauTheoMaTiepNhan.Where(x => x.LoaiXetNghiem.Equals(itmLoaiXn)).ToList();
                    foreach (var itmThucThi in lstThucThi)
                    {
                        var para = new[]
                      {
                        WorkingServices.GetParaFromOject("@MatiepNhan", lstThucThi[0].MaTiepNhan),
                        WorkingServices.GetParaFromOject("@trangThai", lstThucThi[0].TrangThai),
                        WorkingServices.GetParaFromOject("@maXn",itmThucThi.Maxn),
                        WorkingServices.GetParaFromOject("@maLoaiMau", lstThucThi[0].MaNhomLoaiMau),
                        WorkingServices.GetParaFromOject("@pcName", lstThucThi[0].Pcthuchien),
                        WorkingServices.GetParaFromOject("@checkXacNhanHis", lstThucThi[0].CheckXacNhanHis),
                        WorkingServices.GetParaFromOject("@nguoiThucHien", lstThucThi[0].NguoiThucHien),
                        WorkingServices.GetParaFromOject("@IDKhuLayMau", lstThucThi[0].IDKhuLayMau),
                        WorkingServices.GetParaFromOject("@Thoigianthuchien", lstThucThi[0].ThoiGianLayMau),
                        WorkingServices.GetParaFromOject("@loaixetnghiem", lstThucThi[0].LoaiXetNghiem),
                        WorkingServices.GetParaFromOject("@idLayLoaiMau", lstThucThi[0].IdLayLoaiMau),
                        WorkingServices.GetParaFromOject("@banlayMau", lstThucThi[0].BanLayMau),
                        WorkingServices.GetParaFromOject("@macaptren",string.IsNullOrEmpty(itmThucThi.MaCapTren)? (object)DBNull.Value: itmThucThi.MaCapTren),
                        WorkingServices.GetParaFromOject("@profileId", string.IsNullOrEmpty(itmThucThi.ProfileId) ? (object)DBNull.Value : itmThucThi.ProfileId)
                      };
                        icount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpUpdateXetNghiem_LayMau", para);
                    }
                }
            }
            return icount > 0;
        }

        public bool Update_TG_Khoa_User_LayMau(List<LayMauInfo> lstLayMau)
        {
            if (lstLayMau.Count <= 0) return false;
            var icount = 0;
            var lstMaTiepNhan = lstLayMau.Select(x => x.MaTiepNhan).Distinct().ToList();
            foreach (var itmMaTiepNhan in lstMaTiepNhan)
            {
                var lstThucThi = lstLayMau.Where(x => x.MaTiepNhan.Equals(itmMaTiepNhan)).ToList();
                var para = new[]
                {
                    WorkingServices.GetParaFromOject("@MatiepNhan", itmMaTiepNhan),
                    WorkingServices.GetParaFromOject("@TenNguoiLayMau", lstThucThi[0].NguoiThucHien),
                    WorkingServices.GetParaFromOject("@ThoiGianLayMau", lstThucThi[0].ThoiGianLayMau),
                    WorkingServices.GetParaFromOject("@NoiSinh", lstThucThi[0].NoiSinh)
                };
                icount +=
                    (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpTG_Khoa_User_LayMau", para);
            }
            return icount > 0;
        }

        public bool Update_MauXn_NhanMau(List<NhanMauInfo> lstNhanMau)
        {
            if (lstNhanMau.Count <= 0) return false;
            var icount = 0;
            //Xử lý update theo từng mã tiếp nhận
            //List mã tiếp nhận
            var lstMaTiepNhan = lstNhanMau.Select(x => x.MaTiepNhan).Distinct().ToList();
            foreach (var itmMaTiepNhan in lstMaTiepNhan)
            {
                var lstDSNhanMauTheoMaTiepNhan = lstNhanMau.Where(x => x.MaTiepNhan.Equals(itmMaTiepNhan, StringComparison.OrdinalIgnoreCase)).ToList();
                var lstLoaiXn = lstDSNhanMauTheoMaTiepNhan.Select(x => x.LoaiXetNghiem).Distinct().ToList();
                foreach (var itmLoaiXn in lstLoaiXn)
                {
                    var lstThucThi = lstDSNhanMauTheoMaTiepNhan.Where(x => x.LoaiXetNghiem.Equals(itmLoaiXn)).ToList();
                    foreach (var itmThucThi in lstThucThi)
                    {
                        //var maXN = lstThucThi.Select(x => x.Maxn);
                        //var maCaptren = lstThucThi.Where(x => !string.IsNullOrEmpty(x.MaCapTren)).Select(x => x.MaCapTren);
                        //var maProfile = lstThucThi.Where(x => !string.IsNullOrEmpty(x.ProfileId)).Select(x => x.ProfileId);
                        var para = new[]
                           {
                          WorkingServices.GetParaFromOject("@maTiepNhan",lstThucThi[0].MaTiepNhan),
                          WorkingServices.GetParaFromOject("@nguoiThucHien",lstThucThi[0].NguoiThucHien ),
                          WorkingServices.GetParaFromOject("@nguoiThucHienNhanmau",lstThucThi[0].NguoiThucHienNhanMau ),
                          WorkingServices.GetParaFromOject("@mayTinh",lstThucThi[0].Pcthuchien ),
                          WorkingServices.GetParaFromOject("@danhan",lstThucThi[0].TrangThaiNhan == enumThucHien.DaThucHien ? true: false ),
                          WorkingServices.GetParaFromOject("@lydotuchoi",string.IsNullOrEmpty(lstThucThi[0].LyDoTuChoi) ? (object)DBNull.Value: lstThucThi[0].LyDoTuChoi),
                          WorkingServices.GetParaFromOject("@tinhtrangmau",lstThucThi[0].TinhTrangMau ),
                          WorkingServices.GetParaFromOject("@loaimau",lstThucThi[0].MaLoaiMau),
                          WorkingServices.GetParaFromOject("@maXN",itmThucThi.Maxn),
                          WorkingServices.GetParaFromOject("@checkXacNhanHis", lstThucThi[0].CheckXacNhanHis),
                          WorkingServices.GetParaFromOject("@deleteOrder", lstThucThi[0].DeleteOrder),
                          WorkingServices.GetParaFromOject("@loaimauNhan",string.IsNullOrEmpty(lstThucThi[0].MaLoaiMauNhan) ? (object)DBNull.Value: lstThucThi[0].MaLoaiMauNhan),
                          WorkingServices.GetParaFromOject("@loaixetnghiem",itmLoaiXn),
                          WorkingServices.GetParaFromOject("@idLayLoaiMau",lstThucThi[0].IdLayLoaiMau),
                          WorkingServices.GetParaFromOject("@KhuThucHienID",lstThucThi[0].KhuThucHienID),
                          WorkingServices.GetParaFromOject("@macaptren", string.IsNullOrEmpty(itmThucThi.MaCapTren)? (object)DBNull.Value: itmThucThi.MaCapTren),
                          WorkingServices.GetParaFromOject("@profileId", string.IsNullOrEmpty(itmThucThi.ProfileId) ? (object)DBNull.Value : itmThucThi.ProfileId),
                          WorkingServices.GetParaFromOject("@MaBenhPhamGui",itmThucThi.MaBenhPhamGui)
                           };
                        icount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpUpdateXetNghiem_NhanMau", para);
                    }
                }
            }
            return icount > 0;
        }

        public bool Update_IDChuyenMau(List<NhanMauInfo> lstNhanMau)
        {
            if (lstNhanMau.Count <= 0) return false;
            var icount = 0;
            //var lstMaTiepNhan = lstNhanMau.Select(x => x.MaTiepNhan).Distinct().ToList();
            foreach (var itm in lstNhanMau)
            {
                var para = new[]
                {
                    WorkingServices.GetParaFromOject("@maTiepNhan", itm.MaTiepNhan),
                    WorkingServices.GetParaFromOject("@maXN", itm.Maxn),
                };
                icount +=
                    (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpIDChuyenMau_KQCLSXN", para);
            }
            return icount > 0;
        }

        public bool Update_MauXn_HoanDichVu_TuChoiMau(List<TuChoiMauInfo> lstTuChoiMau)
        {
            int iCount = -1;
            if (lstTuChoiMau.Count > 0)
            {
                foreach (var obj in lstTuChoiMau)
                {
                    var sqlPara = new SqlParameter[]
                    {
                        WorkingServices.GetParaFromOject("@maTiepNhan",obj.MaTiepNhan),
                        WorkingServices.GetParaFromOject("@maloaimau",obj.MaLoaiMau),
                        WorkingServices.GetParaFromOject("@maXN",obj.Maxn),
                        WorkingServices.GetParaFromOject("@nguoiThucHien",obj.NguoiThucHien),
                        WorkingServices.GetParaFromOject("@mayTinh",obj.Pcthuchien),
                        WorkingServices.GetParaFromOject("@tuchoimau",obj.TuChoi),
                        WorkingServices.GetParaFromOject("@lydotuchoi",obj.LyDoTuChoi),
                        WorkingServices.GetParaFromOject("@Thoigianthuchien",obj.ThoiGianThucHien),
                        WorkingServices.GetParaFromOject("@loaixetnghiem",obj.LoaiXetNghiem),
                        WorkingServices.GetParaFromOject("@idLayLoaiMau",obj.IdLayLoaiMau),
                        WorkingServices.GetParaFromOject("@maCaptren",obj.MaCapTren),
                        WorkingServices.GetParaFromOject("@profileId",obj.ProfileId)
                    };
                    iCount += (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpUpdateTrangThai_TuChoi_HoanDichVu", sqlPara);
                }
            }
            return iCount > -1;
        }
        public int Update_TrangThaiLayMau_NhanMau(string matiepnhan, bool fromNhanmau, bool daNhanMau)
        {
            return (int)DataProvider.ExecuteNonQuery
            (
                CommandType.StoredProcedure, "udpTrangThaiLayMau_NhanMau",
                new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                    WorkingServices.GetParaFromOject("@FromNhanMau", fromNhanmau),
                    WorkingServices.GetParaFromOject("@DaNhanMau", daNhanMau)
                }
            );
        }
        public int Update_TrangThaiLayMau(string matiepnhan)
        {
            return (int)DataProvider.ExecuteNonQuery
            (
                CommandType.StoredProcedure, "udpTrangThaiLayMau",
                new SqlParameter[]
                {
                WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                }
            );
        }
        public int Update_TrangThaiNhanMau(string matiepnhan, bool nhanMau)
        {
            return (int)DataProvider.ExecuteNonQuery
            (
                CommandType.StoredProcedure, "udpTrangThaiNhanMau",
                new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                    WorkingServices.GetParaFromOject("@nhanmau", nhanMau)
                }
            );
        }

        public int Update_TinhTrangMau(string maTiepNhan, string lstMaXn, string tinhtrangmau, bool checkXacNhanHis)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@tinhtrangmau", tinhtrangmau),
                WorkingServices.GetParaFromOject("@maXN", lstMaXn),
                WorkingServices.GetParaFromOject("@checkXacNhanHis", checkXacNhanHis),
            };
            return (int)DataProvider.ExecuteNonQuery
                (CommandType.StoredProcedure, "udpTinhTrangMau_XetNghiem", sqlPara);
        }
        public int Update_ThoigianThaoTacMau(CapNhatThaoTacMau objInfo)
        {
            var sqlPara = new SqlParameter[]{WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXn", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@Tgcu", objInfo.Tgcu),
                        WorkingServices.GetParaFromOject("@Tgmoi", objInfo.Tgmoi),
                        WorkingServices.GetParaFromOject("@Nguoithuchiencu", objInfo.Nguoithuchiencu),
                        WorkingServices.GetParaFromOject("@pcThuchiencu", objInfo.Pcthuchiencu),
                        WorkingServices.GetParaFromOject("@Nguoithuchienmoi", objInfo.Nguoithuchienmoi),
                        WorkingServices.GetParaFromOject("@pcThuchienmoi", objInfo.Pcthuchienmoi),
                        WorkingServices.GetParaFromOject("@IdThaoTac", objInfo.Idthaotac)};
            return (int)DataProvider.ExecuteNonQuery
                    (CommandType.StoredProcedure, "updXetNghiem_DoiThoiGianThaoTacMau", sqlPara);
        }
        public int Update_XetNghiem_MaSoBenhPhamGui(string maTiepNhan, string maXN, string maBenhPham)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan),
                WorkingServices.GetParaFromOject("@maXN", maXN),
                WorkingServices.GetParaFromOject("@MaBenhPham", maBenhPham)
            };
            return (int)DataProvider.ExecuteNonQuery
                (CommandType.StoredProcedure, "updXetNghiem_MaBenhPhamGui", sqlPara);
        }

        public int Insert_Update_KiemSoatLayMau(string userId, List<string> lstDnMau, DateTime tgGianBatDau,
            DateTime TGKhoa, bool dangKhoa)
        {
            //,@DanhSachCode varchar(250)
            //, @TGGianBatDau datetime
            //, @TGKhoa datetime
            //, @DangKhoa bit
            return (int)DataProvider.ExecuteNonQuery
            (
                CommandType.StoredProcedure, "insInsert_Update_KiemSoatLayMau",
                WorkingServices.GetParaFromOject("@MaNguoiDUng", userId),
                WorkingServices.GetParaFromOject("@DanhSachCode", Utilities.ConvertStrinArryToInClauseSQL(lstDnMau, false)),
                WorkingServices.GetParaFromOject("@TGGianBatDau", tgGianBatDau), WorkingServices.GetParaFromOject("@TGKhoa", TGKhoa),
                WorkingServices.GetParaFromOject("@DangKhoa", dangKhoa));
        }

        public KiemSoatChayMau ThongKiemSoatLayMau(string userId)
        {
            var obj = new KiemSoatChayMau();
            obj.MaNguoiDung = userId;
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selKiemSoatLayMau"
                , new SqlParameter[] { WorkingServices.GetParaFromOject("@MaNguoiDUng", userId) }).Tables[0];
            if (data.Rows.Count > 0)
            {
                obj.DangKhoa = bool.Parse(data.Rows[0]["DangKhoa"].ToString());
                obj.MaNguoiDung = data.Rows[0]["MaNguoiDung"].ToString();
                obj.DanhSachCode = Utilities.StringToList(data.Rows[0]["CodeDangQuet"].ToString(), ",");
                if (!string.IsNullOrEmpty(data.Rows[0]["TGGianBatDau"].ToString()))
                {
                    obj.TGGianBatDau = DateTime.Parse(data.Rows[0]["TGGianBatDau"].ToString());
                }
                if (!string.IsNullOrEmpty(data.Rows[0]["TGKhoa"].ToString()))
                {
                    obj.TGKhoa = DateTime.Parse(data.Rows[0]["TGKhoa"].ToString());
                }
                else
                    obj.DangKhoa = false;
            }
            return obj;
        }
        public bool Check_OpenOrder(string matiepnhan)
        {
            var obj = DataProvider.ExecuteScalar
            (
                CommandType.StoredProcedure, "selCheckOrderClose",
                new SqlParameter[]
                {
                WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                }
            );

            if (obj != null && !DBNull.Value.Equals(obj))
            {
                return true;
            }
            return false;
        }

        public bool update_XN_TGChuyen_BNCLSXN(string matiepnhan)
        {
            var sqlPara = new[]
               {
                    WorkingServices.GetParaFromOject("@IDChuyenMau", (object)DBNull.Value),
                    WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_ChuyenMau_ThoiGianChuyen_BNCLSXN", sqlPara) > -1;
        }

        public int Update_OpenOrder(string matiepnhan, string nguoithuchien, string userid, string pcname)
        {
            return (int)DataProvider.ExecuteNonQuery
            (
                CommandType.StoredProcedure, "udpUpdateOpenOrder",
                new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@matiepnhan", matiepnhan),
                    WorkingServices.GetParaFromOject("@nguoithuchien", userid),
                    WorkingServices.GetParaFromOject("@userid", userid),
                    WorkingServices.GetParaFromOject("@pcname", pcname),
                }
            );
        }
        public bool Insert_nhatky_mauxetnghiem(List<NHATKY_MAUXETNGHIEM> lstObjInfo)
        {
            if (lstObjInfo.Count > 0)
            {
                string spStorefTemplate = "exec insNhatKy_MauXetNghiem @MaTiepNhan = {0} " +
                    ",@MaXn = {1}, @LyDo = {2}, @Nguoithuchien = {3}" +
                    ",@Pcthuchien = {4},@Idthuchien = {5},@Maphanloaidichvu = {6},@Thoigianthuchien = {7}, @idLayLoaiMau = {8}, @NoiDungLyDo = {9}";
                var sb = new StringBuilder();
                int iCount = 0;
                foreach (var obj in lstObjInfo)
                {
                    iCount++;
                    if (iCount > 1)
                        sb.Append(";\n");

                    sb.AppendFormat(spStorefTemplate
                        , string.IsNullOrEmpty(obj.Matiepnhan) ? "NULL" : string.Format("'{0}'", obj.Matiepnhan)
                        , string.IsNullOrEmpty(obj.Maxn) ? "NULL" : string.Format("'{0}'", obj.Maxn)
                        , string.IsNullOrEmpty(obj.Lydo) ? "NULL" : string.Format("N'{0}'", obj.Lydo)
                        , string.IsNullOrEmpty(obj.Nguoithuchien) ? "NULL" : string.Format("'{0}'", obj.Nguoithuchien)
                        , string.IsNullOrEmpty(obj.Pcthuchien) ? "NULL" : string.Format("N'{0}'", obj.Pcthuchien)
                        , obj.Idthuchien
                        , string.IsNullOrEmpty(obj.Maphanloaidichvu) ? "NULL" : string.Format("'{0}'", obj.Maphanloaidichvu)
                        , !obj.Thoigianthuchien.HasValue ? "NULL" : string.Format("'{0}'", obj.Thoigianthuchien.Value.ToString("yyyy-MM-dd HH:mm:ss"))
                        , obj.IdLayLoaiMau
                        , string.IsNullOrEmpty(obj.NoiDungLydo) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(obj.NoiDungLydo))
                        );
                }
                return DataProvider.ExecuteQuery(sb.ToString());
            }
            return false;
        }
        public DataTable Data_nhatky_mauxetnghiem(string id, string matiepnhan
            , string nguoithuchien, DateTime? tungay, DateTime? denngay
            , bool xemChiTiet, string allowNhom)
        {
            /*
             * @id int null
                ,@matiepnhan varchar(20) =''
                ,@nguoithuchien varchar(25) = ''
                ,@tungay datetime = null
                ,@denngay datetime = null
             * */
            var paFromDate = WorkingServices.GetParaFromOject("@tungay", SqlDbType.DateTime);
            if (tungay == null)
                paFromDate.Value = DBNull.Value;
            else
                paFromDate.Value = tungay.Value.Date;

            var paToDate = WorkingServices.GetParaFromOject("@denngay", SqlDbType.DateTime);
            if (denngay == null)
                paToDate.Value = DBNull.Value;
            else
                paToDate.Value = denngay.Value.Date;
            var sqlPara = new SqlParameter[]
              {
                paFromDate, paToDate,
                WorkingServices.GetParaFromOject("@id", string.IsNullOrEmpty(id)? (object)DBNull.Value: id ),
                WorkingServices.GetParaFromOject("@matiepnhan", string.IsNullOrEmpty(matiepnhan)? (object)DBNull.Value: matiepnhan ),
                WorkingServices.GetParaFromOject("@nguoithuchien", string.IsNullOrEmpty(nguoithuchien)? (object)DBNull.Value: nguoithuchien ),
                WorkingServices.GetParaFromOject("@xemchitiet", xemChiTiet ),
                WorkingServices.GetParaFromOject("@nhomPhanQuyen", string.IsNullOrEmpty(allowNhom)? (object)DBNull.Value: allowNhom )
              };

            var dtData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNgiem_NhatKyMau", sqlPara).Tables[0];
            return dtData;
        }
        public DataTable  Data_NhatKy_DoiGioThaoTacMau(DateTime? tungay, DateTime? denngay, string matiepNhan, string nguoiThucHien)
        {
            var sqlPara = new SqlParameter[]{WorkingServices.GetParaFromOject("@TuNgay", tungay),
                WorkingServices.GetParaFromOject("@DenNgay", denngay),
                WorkingServices.GetParaFromOject("@MaTiepNhan", matiepNhan),
                WorkingServices.GetParaFromOject("@NguoiThucHien", nguoiThucHien)};
            var dtData = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNhatKy_DoiThoiGianMau", sqlPara).Tables[0];
            return dtData;
        }
        public DataTable DanhSach_MaTiepNhan_TheoSHS(string soHoSo)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@SoHoSo", soHoSo)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selBenhNhan_MaTiepNhanTheoSHS", sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DanhSach_MaTiepNhan_TheoBarcode(string barcode)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Barcode", barcode)
            };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selBenhNhan_MaTiepNhanTheoBarcode", sqlPara);

            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DanhSach_BenhNhan_TheoTrangThaiMau(DieuKienTimDanhSachBNTheoTrangThaiMau condit)
        {
            var sqlPara = new SqlParameter[]
                {
                        WorkingServices.GetParaFromOject("@tungay",condit.tungay, true)
                        , WorkingServices.GetParaFromOject("@denngay",condit.denngay, true) 
                        , WorkingServices.GetParaFromOject("@maDoiTuong", string.IsNullOrEmpty(condit.maDoiTuong)? (object)DBNull.Value: condit.maDoiTuong)
                        , WorkingServices.GetParaFromOject("@tenBN",string.IsNullOrEmpty(condit.tenBN)? (object)DBNull.Value: condit.tenBN)
                        , WorkingServices.GetParaFromOject("@barcode",string.IsNullOrEmpty(condit.barcode)? (object)DBNull.Value: condit.barcode)
                        , WorkingServices.GetParaFromOject("@maBN",string.IsNullOrEmpty(condit.maBN)? (object)DBNull.Value: condit.maBN)
                        , WorkingServices.GetParaFromOject("@sdt",string.IsNullOrEmpty(condit.sdt)? (object)DBNull.Value: condit.sdt)
                        , WorkingServices.GetParaFromOject("@idCongDan",string.IsNullOrEmpty(condit.idCongDan)? (object)DBNull.Value: condit.idCongDan)
                        , WorkingServices.GetParaFromOject("@daNhanMau",(int)condit.daNhanMau)
                        , WorkingServices.GetParaFromOject("@daLayMauTatCa",(int)condit.daLayMauTatCa)
                        , WorkingServices.GetParaFromOject("@daTraKQ",(int)condit.daTraKQ)
                        , WorkingServices.GetParaFromOject("@daDuKQ",(int)condit.daDuKQ)
                        , WorkingServices.GetParaFromOject("@dainKQ",(int)condit.dainKQ)
                        , WorkingServices.GetParaFromOject("@daXacNhanKQ",(int)condit.daXacNhanKQ)
                        , WorkingServices.GetParaFromOject("@loaiDichVu",(int)condit.loaiDichVu)
                        , WorkingServices.GetParaFromOject("@coLayMau",(int)condit.coLayMau)
                        , WorkingServices.GetParaFromOject("@daNhanMauTatCa ",(int)condit.daNhanMauTatCa)
                        , WorkingServices.GetParaFromOject("@daTuChoiMau ",(int)condit.daTuChoiMau)
                        , WorkingServices.GetParaFromOject("@daHoanDichVu",(int)condit.daHoanDichVu)
                        , WorkingServices.GetParaFromOject("@tacvu",(int)condit.tacvu)
                        , WorkingServices.GetParaFromOject("@pcName",string.IsNullOrEmpty(condit.pcName)? (object)DBNull.Value: condit.pcName)
                        , WorkingServices.GetParaFromOject("@sophieuHis",string.IsNullOrEmpty(condit.sophieuHis)? (object)DBNull.Value: condit.sophieuHis)
                        , WorkingServices.GetParaFromOject("@nguoiLayMau",string.IsNullOrEmpty(condit.nguoiLayMau)? (object)DBNull.Value: condit.nguoiLayMau)
                        , WorkingServices.GetParaFromOject("@nguoiNhanMau",string.IsNullOrEmpty(condit.nguoiNhanMau)? (object)DBNull.Value: condit.nguoiNhanMau)
                        , WorkingServices.GetParaFromOject("@maKhuVuc",string.IsNullOrEmpty(condit.maKhuVuc)? (object)DBNull.Value: condit.maKhuVuc)
                        , WorkingServices.GetParaFromOject("@IDChuyenMau", condit.IDChuyenMau)
                        , WorkingServices.GetParaFromOject("@lstNhomXN", condit.quyennhomXn == null ?(object)DBNull.Value: Utilities.ConvertStrinArryToInClauseSQLForSplitString(condit.quyennhomXn) )
                        , WorkingServices.GetParaFromOject("@checkDaLayMau",condit.CheckDaLayMau)
                        , WorkingServices.GetParaFromOject("@checkSoHoSo", condit.CheckSoHoSo)
                };
            var spName = string.Empty;
            if (condit.CheckSoHoSo && !string.IsNullOrEmpty(condit.barcode))
                spName = "selDanhSach_BenhNhan_ThaoTacMau_SoHoSo";
            else if (!string.IsNullOrEmpty(condit.barcode) && !condit.CheckSoHoSo)
                spName = "selDanhSach_BenhNhan_ThaoTacMau_Barcode";
            else
                spName = "selDanhSach_BenhNhan_ThaoTacMau_NgayTiepNhan";

            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, spName, sqlPara);
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DanhSachOngMau(string maTiepNhan, enumThucHien daLayMau, enumThucHien daNhanMau
            , enumThucHien daTuChoi, bool checkPhanQuyenNhom, string userCheckQuyenNhom, int idLayLoaiMau)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                , "selXetNghiem_TrangThaiOngMau"
                , new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MatiepNhan", maTiepNhan)
                    , WorkingServices.GetParaFromOject("@daLayMau", (int)daLayMau)
                    , WorkingServices.GetParaFromOject("@daNhanMau", (int)daNhanMau)
                    , WorkingServices.GetParaFromOject("@daTuChoi", (int)daTuChoi)
                    , WorkingServices.GetParaFromOject("@checkPhanQuyenNhom", checkPhanQuyenNhom)
                    , WorkingServices.GetParaFromOject("@userCheckNhom", userCheckQuyenNhom)
                    , WorkingServices.GetParaFromOject("@idLayLoaiMau", idLayLoaiMau)
                });
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable DanhSachChiDinh_OngMau(string maTiepNhan, int idLayLoaiMau)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure
                , "selXetNghiem_ChiTietChiDinhTQ"
                , new SqlParameter[]
                {
                    new SqlParameter("@MatiepNhan", maTiepNhan)
                    , new SqlParameter("@idLayLoaiMau", idLayLoaiMau)
                });
            if (ds != null)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable Data_ChiDinhDaNhanMau(string maTiepNhan)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
               "selDanhSach_ChiDinhDaNhanMauTheoBN"
               , new SqlParameter[]
               {
                 WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)

               });
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();

        }
        public DataTable Data_ChiDinhDaLayMau(string maTiepNhan)
        {
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure,
               "selDanhSach_ChiDinhDaLayMauTheoBN"
               , new SqlParameter[]
               {
                             WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)

               });
            if (ds != null)
                return ds.Tables[0];
            else
                return new DataTable();
        }
        //thông tin chuyển mẫu
        public TaoMoiChuyenMau Create_ChuyenMau_IdChuyenMau(TaoMoiChuyenMau obj)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@PCTao", obj.PCName)
                ,WorkingServices.GetParaFromOject("@UserTao", obj.UserTao)
            };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "insXetNghiem_ChuyenMau", sqlPara);
            if (data != null)
            {
                var dataInfo = data.Tables[0];
                if (dataInfo.Rows.Count > 0)
                    obj.IDChuyenMau = long.Parse(dataInfo.Rows[0]["IDChuyenMau"].ToString());
                else
                    obj.IDChuyenMau = -1;
            }
            else
                obj.IDChuyenMau = -1;

            return obj;
        }
        public bool Insert_ChuyenMau_ChiTiet(ThemChuyenMauChiTiet obj)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@idChuyenMau", obj.idChuyenMau)
                    ,WorkingServices.GetParaFromOject("@Barcode", obj.Barcode)
                    ,WorkingServices.GetParaFromOject("@PcTao", obj.PcTao)
                    ,WorkingServices.GetParaFromOject("@UserTao", obj.UserTao)
                    ,WorkingServices.GetParaFromOject("@MaOngMau", obj.MaLoaiMau)
                    ,WorkingServices.GetParaFromOject("@SoLuong", obj.SoLuong)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_ChuyenMau_ChiTiet", sqlPara) > -1;
        }
        public bool Update_ChuyenMau_XacNhanChuyen(CapNhatChuyenMau obj)
        {
            if (obj.ChiCapNhatGhiChu)
            {
                //@IDChuyenMau, @UserCapNhat, @GhiChu
                var sqlPara = new SqlParameter[]
                    {
                        WorkingServices.GetParaFromOject("@IDChuyenMau", obj.IDChuyenMau)
                        , WorkingServices.GetParaFromOject("@UserCapNhat", obj.UserChuyen)
                        , WorkingServices.GetParaFromOject("@GhiChu", obj.GhiChu)
                    };
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_ChuyenMau_GhiChu", sqlPara) > -1;
            }
            else
            {
                //@IDChuyenMau, @UserChuyen, @PcChuyen, @GhiChu
                var sqlPara = new SqlParameter[]
                    {
                    WorkingServices.GetParaFromOject("@IDChuyenMau", obj.IDChuyenMau)
                    ,WorkingServices.GetParaFromOject("@UserChuyen", obj.UserChuyen)
                    ,WorkingServices.GetParaFromOject("@PcChuyen", obj.PcChuyen)
                    ,WorkingServices.GetParaFromOject("@GhiChu", obj.GhiChu)
                    };
                return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_ChuyenMau_XacNhanChuyen", sqlPara) > -1;
            }
        }
        public bool Update_ChuyenMau_SoLuong(long idChuyenMau, string barcode, string maOngMau, bool tang)
        {            //@idChuyenMau, @Barcode, @PcTao, @UserTao
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@idChuyenMau", idChuyenMau)
                    ,WorkingServices.GetParaFromOject("@Barcode", barcode)
                    ,WorkingServices.GetParaFromOject("@MaOngMau", maOngMau)
                    ,WorkingServices.GetParaFromOject("@TangSL", tang)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_ChuyenMau_ChiTiet_SoLuong", sqlPara) > -1;
        }
        public DataTable Data_ChuyenMau(long? idChuyenMau, DateTime? tuNgay, DateTime? DenNgay, string userTao = "")
        {
            //@IDChuyenMau, @TuNgay, @DenNgay
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@IDChuyenMau", idChuyenMau??(object)DBNull.Value)
                    , WorkingServices.GetParaFromOject("@TuNgay", tuNgay??(object)DBNull.Value)
                    , WorkingServices.GetParaFromOject("@DenNgay", DenNgay??(object)DBNull.Value)
                    , WorkingServices.GetParaFromOject("@UserTao", string.IsNullOrEmpty(userTao)?(object)DBNull.Value: userTao)
                };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_DanhSach_ChuyenMau", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        public DataTable Data_ChuyenMau_ChiTiet(long? idChuyenMau, string Barcode
            , DateTime? tuNgay, DateTime? DenNgay, string userTao = "")
        {
            //@IDChuyenMau, @Barcode,@TuNgay datetime = null,@DenNgay datetime = null
            var sqlPara = new SqlParameter[]
                    {
                        WorkingServices.GetParaFromOject("@IDChuyenMau", idChuyenMau??(object)DBNull.Value)
                        , WorkingServices.GetParaFromOject("@Barcode", string.IsNullOrEmpty(Barcode)?(object)DBNull.Value: Barcode)
                        , WorkingServices.GetParaFromOject("@TuNgay", tuNgay??(object)DBNull.Value)
                        , WorkingServices.GetParaFromOject("@DenNgay", DenNgay??(object)DBNull.Value)
                        , WorkingServices.GetParaFromOject("@UserTao", string.IsNullOrEmpty(userTao)?(object)DBNull.Value: userTao)
                    };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_DanhSach_ChuyenMau_ChiTiet", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public bool Delete_ChuyenMau(long IDChuyenMau)
        {
            //@IDChuyenMau, @TuNgay, @DenNgay
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@IDChuyenMau", IDChuyenMau)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delXetNghiem_ChuyenMau", sqlPara) > -1;
        }
        public bool Delete_ChuyenMau_ChiTiet(long IDChuyenMauChiTiet)
        {
            //@IDChuyenMau, @barcode
            var sqlPara = new SqlParameter[]
                {
                     WorkingServices.GetParaFromOject("@IdChuyenMauChiTiet", IDChuyenMauChiTiet)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delXetNghiem_ChuyenMau_ChiTiet", sqlPara) > -1;
        }
        #endregion
        #region Danh sach đã có kết quả và chờ lấy
        public int Update_TraKetqua(string matiepnhan, string userThucHien, string nguoiNhan, string noiNhan, bool thucHienTra)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update benhnhan_cls_xetnghiem set ");
            if (thucHienTra)
            {
                sb.AppendFormat("\nUserTraKQ = '{0}'", userThucHien);
                sb.Append("\n,ThoiGianTraKQ = getdate()");
                sb.AppendFormat("\n,NguoiNhanketQua = {0}", string.IsNullOrEmpty(nguoiNhan) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(nguoiNhan)));
                sb.AppendFormat("\n,NoiNhanKetQua= {0}", string.IsNullOrEmpty(noiNhan) ? "NULL" : string.Format("N'{0}'", Utilities.ConvertSqlString(noiNhan)));
            }
            else
            {
                sb.Append("\nUserTraKQ = NULL");
                sb.Append("\n,ThoiGianTraKQ = NULL");
                sb.Append("\n,NguoiNhanketQua = NULL");
                sb.Append("\n,NoiNhanKetQua= NULL");
                sb.AppendFormat("\n,UserCapNhatraKQ = '{0}'", userThucHien);
                sb.AppendFormat("\n,ThoiGianCapNhanTraKQ = getdate()");
            }
            sb.AppendFormat("\n where MaTiepNhan = '{0}'", matiepnhan);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
        public DataTable DanhSach_ChoTraKetQua(bool TheoNgayHen, bool ThuongQuy, string KhoaPhong, int soPhut)
        {
            var para = new SqlParameter[]
                {
                     WorkingServices.GetParaFromOject("@TheoNgayHen",TheoNgayHen?"1":"0" )
                     , WorkingServices.GetParaFromOject("@ThuongQuy", ThuongQuy?"1":"0")
                     , WorkingServices.GetParaFromOject("@KhoaPhong", string.IsNullOrEmpty(KhoaPhong)?(object)DBNull.Value: KhoaPhong)
                     , WorkingServices.GetParaFromOject("@SoPhut",soPhut)
                };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_ChoTraKetQua", para);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        #endregion
        public DataTable Data_ChiDInhTheoSoHoSo(string soHoSo, string sophieuChiDinh, string maBenhNhan)
        {
            var para = new SqlParameter[]
            {
                     WorkingServices.GetParaFromOject("@Bn_Id",soHoSo )
                     , WorkingServices.GetParaFromOject("@RSoPhieuYeuCau", sophieuChiDinh)
                     , WorkingServices.GetParaFromOject("@MaBenhNhan", maBenhNhan)
            };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selThongTinChiDinh_TheoSoHoSo", para);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable Data_TheoDoiMau(string maBenhNhan, string maTiepNhan
            , string barcode, string maHosSo
            , string allowBophan, DateTime? ngayKiemTra)
        {
            //,@allowBophan varchar(150) = null
            //,@ngaykiemtra datetime = null
            var para = new SqlParameter[]
            {
                     WorkingServices.GetParaFromOject("@SoHoSo",string.IsNullOrEmpty(maHosSo)?(object)DBNull.Value: maHosSo )
                     , WorkingServices.GetParaFromOject("@barcode", string.IsNullOrEmpty(barcode)?(object)DBNull.Value: barcode)
                     , WorkingServices.GetParaFromOject("@MaTiepNhan", string.IsNullOrEmpty(maTiepNhan)?(object)DBNull.Value: maTiepNhan)
                     , WorkingServices.GetParaFromOject("@MaBenhNhan",string.IsNullOrEmpty(maBenhNhan)?(object)DBNull.Value: maBenhNhan)
                     , WorkingServices.GetParaFromOject("@allowBophan", string.IsNullOrEmpty(allowBophan)?(object)DBNull.Value: allowBophan)
                     , WorkingServices.GetParaFromOject("@ngaykiemtra",ngayKiemTra == null?(object)DBNull.Value: ngayKiemTra.Value)
            };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSach_TheoDoiMau", para);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public bool DuaVaoDanhSachUploadHIS(string maTiepNhan)
        {
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure
            , "insInsert_UploadList"
            , new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan) }) > -1;
        }
        #region Quản lý phân phối bàn
        public bool Insert_LayMauDangKyBan(string maNguoiDung, int soBan, string maKhuLayMau, string pcName)
        {
            var sqlPara = new SqlParameter[]
             {
                     WorkingServices.GetParaFromOject("@MaNguoiDung", maNguoiDung),
                     WorkingServices.GetParaFromOject("@BanDangKy", soBan),
                     WorkingServices.GetParaFromOject("@KhuLayMau", maKhuLayMau),
                     WorkingServices.GetParaFromOject("@PC", pcName)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insLayMau_DangNhap", sqlPara) > -1;
        }
        public bool Update_LayMauLogOut(string maNguoiDung, int soBan, string maKhuLayMau, string pcName)
        {
            var sqlPara = new SqlParameter[]
           {
                    WorkingServices.GetParaFromOject("@MaNguoiDung", maNguoiDung),
                    WorkingServices.GetParaFromOject("@PC", pcName),
                    WorkingServices.GetParaFromOject("@SoBan", soBan),
                    WorkingServices.GetParaFromOject("@KhuLayMau", maKhuLayMau)
           };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpLayMau_dangXuat", sqlPara) > -1;
        }
        public bool Update_LayMauTamDung(string maNguoiDung, int soBan, string maKhuLayMau, bool tamDung)
        {
            var sqlPara = new SqlParameter[]
           {
                     WorkingServices.GetParaFromOject("@MaNguoiDung", maNguoiDung),
                     WorkingServices.GetParaFromOject("@KhuLayMau", maKhuLayMau),
                     WorkingServices.GetParaFromOject("@TamDung", tamDung),
                     WorkingServices.GetParaFromOject("@SoBan", soBan)
           };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpLayMau_TamDung", sqlPara) > -1;
        }
        public DataTable DanhSach_LayMau_DaDangKySoBan(string maNguoiDung, int soBan, string maKhuLayMau, bool checkChuaDangXuat)
        {
            var sqlPara = new SqlParameter[]
           {
                WorkingServices.GetParaFromOject("@MaNguoiDung", string.IsNullOrEmpty(maNguoiDung)?(object)DBNull.Value: maNguoiDung),
                WorkingServices.GetParaFromOject("@BanDangKy",soBan == -1?(object)DBNull.Value:  soBan),
                WorkingServices.GetParaFromOject("@KhuLayMau",string.IsNullOrEmpty(maKhuLayMau)?(object)DBNull.Value: maKhuLayMau ),
                WorkingServices.GetParaFromOject("@CheckDaDangXuat", checkChuaDangXuat)
           };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLayMau_TrangThaiDangNhap", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable LayMau_LaySoBan(string maKhuLayMau)
        {
            var sqlPara = new SqlParameter[]
                {
                WorkingServices.GetParaFromOject("@KhuLayMau", maKhuLayMau)
                };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sellayMau_CapSoBan", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        #endregion
        #region Quản lý đăng nhập lấy mẫu
        public bool Insert_LayMauThuCong_DangNhap(string maNguoiDung, string maKhuLayMau)
        {
            var sqlPara = new SqlParameter[]
             {
                     WorkingServices.GetParaFromOject("@MaNguoiDung", maNguoiDung),
                     WorkingServices.GetParaFromOject("@KhuLayMau", maKhuLayMau)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insLayMauThuCong_DangNhap", sqlPara) > -1;
        }
        public bool Update_LayMauThuCong_LogOut(int idDangNhap)
        {
            var sqlPara = new SqlParameter[]
           {
                    WorkingServices.GetParaFromOject("@IdDangNhap", idDangNhap),
           };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updLayMauThuCong_DangXuat", sqlPara) > -1;
        }
        public DataTable DanhSach_LayMau_DangNhap(string maKhuLayMau)
        {
            var sqlPara = new SqlParameter[]
                {
                WorkingServices.GetParaFromOject("@KhuLayMau", maKhuLayMau)
                };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLayMauThuCong_DanhSachDangNhap", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        #endregion
        #region Chuyển kết quả
        public long Insert_PhieuChuyenKQ(string nguoiChuyen, string pcChuyen)
        {
            var sqlPara = new SqlParameter[]
               {
                 WorkingServices.GetParaFromOject("@NguoiTao", nguoiChuyen)
                ,WorkingServices.GetParaFromOject("@PCTao", pcChuyen)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "insChuyenketQua_TaoLanChuyen", sqlPara);
            if (data != null)
            {
                return long.Parse(data.Tables[0].Rows[0]["STT"].ToString());
            }
            else
                return -1;
        }
        public int Delete_PhieuChuyenKQ(long idChuyenMau)
        {
            var sqlPara = new SqlParameter[]
               {
                 WorkingServices.GetParaFromOject("@IdChuyen", idChuyenMau)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delChuyenKetQua_HuyLenhChuyen", sqlPara);
        }
        public DataTable DanhSach_PhieuChuyenKetQua(DateTime ngayChuyen, string barcode)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@NgayChuyen",ngayChuyen)
                 , WorkingServices.GetParaFromOject("@Barcode",barcode)
              };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuyenKetQua_DSPhieuChuyen", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        public int Insert_PhieuChuyenMau_ChiTiet(CHUYENPHIEUKETQUA_CHITIET objInfo)
        {
            var sqlPara = new SqlParameter[]
           {
                WorkingServices.GetParaFromOject("@IDChuyen",objInfo.Idchuyen ),
                WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                WorkingServices.GetParaFromOject("@Barcode", objInfo.Barcode),
                WorkingServices.GetParaFromOject("@NguoiChuyen", objInfo.Nguoichuyen),
                WorkingServices.GetParaFromOject("@PCChuyen", objInfo.Pcthuchien)
           };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insChuyenKetQua_ChiTietLanChuyen", sqlPara);
        }
        public int Update_PhieuChuyenKQ_XacNhanChuyen(long idChuyenKetQua, string nguoiXacNhan, string tenMayTinhXacNhan, bool thucHienChuyen)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@IDChuyen",idChuyenKetQua ),
                WorkingServices.GetParaFromOject("@NguoiChuyen", nguoiXacNhan),
                WorkingServices.GetParaFromOject("@PCChuyen", tenMayTinhXacNhan),
                WorkingServices.GetParaFromOject("@ThucHienChuyen", thucHienChuyen)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updChuyenKetQua_XacNhanChuyen", sqlPara);
        }
        public int Update_PhieuChuyenKQ_DaNhanKetQua(long idCHiTiet, long idChuyenKetQua, string nguoiNhan
            , string tenMayTinhNhan, string maTiepNhan)
        {
            //updChuyenKetQua_DaNhanKetQua
            //@IdChiTiet bigint
            //, @IdChuyen bigint
            // , @NguoiNhan varchar(25)
            //,@PcNhanKetQua nvarchar(100)
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@IdChiTiet",idCHiTiet ),
                    WorkingServices.GetParaFromOject("@IdChuyen", idChuyenKetQua),
                    WorkingServices.GetParaFromOject("@NguoiNhan", nguoiNhan),
                    WorkingServices.GetParaFromOject("@PcNhanKetQua", tenMayTinhNhan),
                    WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updChuyenKetQua_DaNhanKetQua", sqlPara);
        }
        public DataTable DanhSach_ThongTinChuyenChuyenKQ_TheoID(int idChuyenKetQua)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@IDChuyen",idChuyenKetQua)
              };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuyenKetQua_ThongTin", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        public DataTable DanhSach_ChuyenChuyenKQ_TheoID(int idChuyenKetQua)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@IDChuyen",idChuyenKetQua)
              };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuyenKetQua_ChiTiet", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        public DataTable DanhSach_ChuyenChuyenKQ_TheoBarcode(string barcode)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@Barcode",barcode)
              };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuyenKetQua_ThongTinTheoBarcode", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        public int Xoa_ChuyenChuyenK_ChiTiet(long idChitiet)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@idChiTiet", idChitiet),
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delChuyenKetQua_ChiTiet", sqlPara);
        }
        public DataTable DanhSach_ChuyenKQ_InPhieu(long idChuyen)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@IdChuyen",idChuyen)
              };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChuyenKetQua_DanhSachIn", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        public DataTable DanhSach_NhanKetQQua_InPhieu(long idChuyen)
        {
            var sqlPara = new SqlParameter[]
              {
                WorkingServices.GetParaFromOject("@IdChuyen",idChuyen)
              };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selNhanKetQua_DanhSachIn", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }
        #endregion
        #region Lưu mẫu
        public int ThemOngMauLuu(ArchiveSample tubeInfo)
        {
            /*
            @MaSoTuLuu varchar(30)
            , @MaHopLuuMau varchar(30)
            , @Barcode varchar(15)
            , @MaOngMau varchar(25)
            , @NguoiLuu varchar(25)
            , @PCThucHien nvarchar(100)
            , @ViTri int
            , @MauOngMau varchar(15)
            */
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@MaSoTuLuu", tubeInfo.Masotuluu),
                    WorkingServices.GetParaFromOject("@MaHopLuuMau", tubeInfo.Mahopluumau),
                    WorkingServices.GetParaFromOject("@Barcode", tubeInfo.Barcode),
                    WorkingServices.GetParaFromOject("@MaOngMau", tubeInfo.Maongmau),
                    WorkingServices.GetParaFromOject("@NguoiLuu", tubeInfo.Nguoiluu),
                    WorkingServices.GetParaFromOject("@PCThucHien", tubeInfo.Pcthuchien),
                    WorkingServices.GetParaFromOject("@ViTri", tubeInfo.Vitri),
                    WorkingServices.GetParaFromOject("@MauOngMau", tubeInfo.Mauongmau)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insLuuMau_ThongTinLuu", sqlPara);
        }
        public long GetIDLuuMau(ArchiveSample tubeInfo)
        {
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@MaSoTuLuu", tubeInfo.Masotuluu),
                    WorkingServices.GetParaFromOject("@MaHopLuuMau", tubeInfo.Mahopluumau),
                    WorkingServices.GetParaFromOject("@Barcode", tubeInfo.Barcode),
                    WorkingServices.GetParaFromOject("@ViTri", tubeInfo.Vitri)
               };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLuuMau_IdMauLuu", sqlPara);
            if (ds != null)
            {
                var data = ds.Tables[0];
                if (data.Rows.Count > 0)
                {
                    return long.Parse(data.Rows[0]["IDLuuMau"].ToString());
                }
            }
            return -1;
        }
        public int XoaOngMauLuu(long Idluumau, string nguoiXoa, string PCXoa)
        {
            /*@idLuuMau bigint,
                @NguoiXoa varchar(25),
                @PCThucHienXoa nvarchar(100)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@idLuuMau", Idluumau),
                    WorkingServices.GetParaFromOject("@NguoiXoa", nguoiXoa),
                    WorkingServices.GetParaFromOject("@PCThucHienXoa", PCXoa)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delLuuMau_ThongTinLuu", sqlPara);
        }
        public int HuyOngMauLuu(long Idluumau, string nguoiHuy, string PCHuy)
        {
            /*@idLuuMau bigint,
                @NguoiXoa varchar(25),
                @PCThucHienXoa nvarchar(100)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@IdMauLuu", Idluumau),
                    WorkingServices.GetParaFromOject("@NguoiHuy", nguoiHuy),
                    WorkingServices.GetParaFromOject("@PCHuy", PCHuy)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updLuuMau_HuyMauLuu", sqlPara);
        }
        public int DuyetMauLuu(long Idluumau, string nguoiduyet, string PCHuy, bool thuchienDuyet)
        {
            /*@IdLuuMau bigint,
                @NguoiLDuyet varchar(20),
                @Duyet bit,
                @PcThuHien nvarchar(100)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@IdLuuMau", Idluumau),
                    WorkingServices.GetParaFromOject("@NguoiLDuyet", nguoiduyet),
                    WorkingServices.GetParaFromOject("@Duyet", thuchienDuyet),
                    WorkingServices.GetParaFromOject("@PcThuHien", PCHuy)
               };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updLuuMau_DuyetLuuMau", sqlPara);
        }
        public DataTable DanhSach_OngMauLuu(string Barcode, string MaSoHop, string MaSoTu)
        {
            /*
             * @Barcode varchar(15)
            ,@MaSoHop varchar(30)
            ,@MaSoTu varchar(30)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@Barcode", Barcode),
                    WorkingServices.GetParaFromOject("@MaSoHop", MaSoHop),
                    WorkingServices.GetParaFromOject("@MaSoTu", MaSoTu)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLuuMau_DanhSachLuu", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable DanhSach_OngMauLuuTheoNgay(DateTime? TuNgay, DateTime? DenNgay, string Barcode, string MaSoHop, string MaSoTu)
        {
            /*
             * @Barcode varchar(15)
            ,@MaSoHop varchar(30)
            ,@MaSoTu varchar(30)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@TuNgay", TuNgay, true),
                    WorkingServices.GetParaFromOject("@DenNgay", DenNgay, true),
                    WorkingServices.GetParaFromOject("@Barcode", Barcode),
                    WorkingServices.GetParaFromOject("@MaSoHop", MaSoHop),
                    WorkingServices.GetParaFromOject("@MaSoTu", MaSoTu)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLuuMau_DanhSachLuuTheoNgay", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable DanhSach_OngMauHuyTheoNgay(DateTime? TuNgay, DateTime? DenNgay, string Barcode, string MaSoHop, string MaSoTu)
        {
            /*
             * @Barcode varchar(15)
            ,@MaSoHop varchar(30)
            ,@MaSoTu varchar(30)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@TuNgay", TuNgay, true),
                    WorkingServices.GetParaFromOject("@DenNgay", DenNgay, true),
                    WorkingServices.GetParaFromOject("@Barcode", Barcode),
                    WorkingServices.GetParaFromOject("@MaSoHop", MaSoHop),
                    WorkingServices.GetParaFromOject("@MaSoTu", MaSoTu)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLuuMau_DanhSachHuyTheoNgay", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable ChiTiet_OngMauLuu(long idLuuMau)
        {
            /*
             * @Barcode varchar(15)
            ,@MaSoHop varchar(30)
            ,@MaSoTu varchar(30)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@IdLuuMau", idLuuMau)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLuuMau_ThongTinOngMau", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable ChiTiet_OngMauLuuTheoViTri(string MaSoHop, string MaSoTu, int viTri)
        {
            /*
             * @Barcode varchar(15)
            ,@MaSoHop varchar(30)
            ,@MaSoTu varchar(30)
            */
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@ViTri", viTri),
                    WorkingServices.GetParaFromOject("@MaHop", MaSoHop),
                    WorkingServices.GetParaFromOject("@MaTuLuu", MaSoTu)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selLuuMau_ThongTinTheoVitri", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public DataTable OngMau_LoaiMauChinh(string barcode, string manhom)
        {
            var sqlPara = new SqlParameter[]
               {
                    WorkingServices.GetParaFromOject("@Barcode", barcode),
                    WorkingServices.GetParaFromOject("@MaNhomCLS", manhom)
               };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selChiDinh_DanhSachLoaiMauChinh_Barcode", sqlPara);
            if (data != null)
                return data.Tables[0];
            else
                return null;
        }
        public ArchiveSample Get_Info_mauxetnghiem_luumau(long idLuuMau)
        {
            DataTable dt = ChiTiet_OngMauLuu(idLuuMau);
            var obj = new ArchiveSample();
            if (dt.Rows.Count > 0)
            {
                return Get_Info_mauxetnghiem_luumau_FromDatarow(dt.Rows[0]);
            }
            return obj;
        }
        public ArchiveSample Get_Info_mauxetnghiem_luumau_FromDatarow(DataRow dr)
        {
            var obj = new ArchiveSample();
            obj.Idluumau = NumberConverter.To<Int64>(dr["idluumau"]);
            obj.Masotuluu = StringConverter.ToString(dr["masotuluu"]);
            obj.Mahopluumau = StringConverter.ToString(dr["mahopluumau"]);
            obj.Barcode = StringConverter.ToString(dr["barcode"]);
            if (!string.IsNullOrEmpty(dr["maongmau"].ToString()))
                obj.Maongmau = StringConverter.ToString(dr["maongmau"]);
            obj.Nguoiluu = StringConverter.ToString(dr["nguoiluu"]);
            obj.Pcthuchien = StringConverter.ToString(dr["pcthuchien"]);
            obj.Ngayluu = (DateTime)dr["ngayluu"];
            obj.Vitri = NumberConverter.To<int>(dr["vitri"]);
            if (!string.IsNullOrEmpty(dr["mauongmau"].ToString()))
                obj.Mauongmau = StringConverter.ToString(dr["mauongmau"]);
            return obj;
        }

        #endregion
        #region Thông tin sàn lọc sơ sinh 
        public int Ins_Update_Del_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj, string flag)
        {
            //ins_upd_del_ThongTinSLSoSinh
            var sqlPara = new SqlParameter[] {
                 WorkingServices.GetParaFromOject("@MaTiepNhan",obj.Matiepnhan )
                , WorkingServices.GetParaFromOject("@BarcodeLayMau",obj.Barcodelaymau )
                , WorkingServices.GetParaFromOject("@TuoiThai",obj.Tuoithai )
                , WorkingServices.GetParaFromOject("@NoiSinh",obj.Noisinh )
                , WorkingServices.GetParaFromOject("@CanNang",obj.Cannang )
                , WorkingServices.GetParaFromOject("@ChieuCao",obj.Chieucao )
                , WorkingServices.GetParaFromOject("@NgaySinh",obj.Ngaysinh )
                , WorkingServices.GetParaFromOject("@DanToc",obj.Dantoc )
                , WorkingServices.GetParaFromOject("@SoLuongSinh",obj.Soluongsinh )
                , WorkingServices.GetParaFromOject("@TTBinhThuong",obj.Ttbinhthuong )
                , WorkingServices.GetParaFromOject("@TTDangBenh",obj.Ttdangbenh )
                , WorkingServices.GetParaFromOject("@TTDungKhangSinh",obj.Ttdungkhangsinh )
                , WorkingServices.GetParaFromOject("@TTDungSteriod",obj.Ttdungsteriod )
                , WorkingServices.GetParaFromOject("@TTTruyenMau",obj.Tttruyenmau )
                , WorkingServices.GetParaFromOject("@TTLuongTruyenMau",obj.Ttluongtruyenmau )
                , WorkingServices.GetParaFromOject("@ViTriGotChan",obj.Vitrigotchan )
                , WorkingServices.GetParaFromOject("@ViTriTinhMach",obj.Vitritinhmach )
                , WorkingServices.GetParaFromOject("@ViTriKhac",obj.Vitrikhac )
                , WorkingServices.GetParaFromOject("@DinhDuongBuMe",obj.Dinhduongbume )
                , WorkingServices.GetParaFromOject("@DinhDuongBuBinh",obj.Dinhduongbubinh )
                , WorkingServices.GetParaFromOject("@DinhDuongTinhMach",obj.Dinhduongtinhmach )
                , WorkingServices.GetParaFromOject("@KieuDeThuong",obj.Kieudethuong )
                , WorkingServices.GetParaFromOject("@KieuDeMo",obj.Kieudemo )
                , WorkingServices.GetParaFromOject("@KieuDeKhac",obj.Kieudekhac )
                , WorkingServices.GetParaFromOject("@HoTenMe",obj.Hotenme )
                , WorkingServices.GetParaFromOject("@HoTenBo",obj.Hotenbo )
                , WorkingServices.GetParaFromOject("@DiaChi",obj.Diachi)
                , WorkingServices.GetParaFromOject("@NamSinhMe",obj.Namsinhme )
                , WorkingServices.GetParaFromOject("@NamSinhBo",obj.Namsinhbo )
                , WorkingServices.GetParaFromOject("@MaTinh",obj.Matinh )
                , WorkingServices.GetParaFromOject("@MaHuyen",obj.Mahuyen )
                , WorkingServices.GetParaFromOject("@DienThoaiBan",obj.Dienthoaiban )
                , WorkingServices.GetParaFromOject("@DienThoaiDiDong",obj.Dienthoaididong )
                , WorkingServices.GetParaFromOject("@Para1",obj.Para1)
                , WorkingServices.GetParaFromOject("@Para2",obj.Para2 )
                , WorkingServices.GetParaFromOject("@Para3",obj.Para3 )
                , WorkingServices.GetParaFromOject("@Para4",obj.Para4 )
                , WorkingServices.GetParaFromOject("@Para5",obj.Para5 )
                , WorkingServices.GetParaFromOject("@ThoiGianLayMau",obj.Thoigianlaymau )
                , WorkingServices.GetParaFromOject("@TenNguoiLayMau",obj.Tennguoilaymau )
                , WorkingServices.GetParaFromOject("@MaNguoiLayMau",obj.Manguoilaymau )
                , WorkingServices.GetParaFromOject("@NoiGuiMau",obj.Noiguimau )
                , WorkingServices.GetParaFromOject("@DiaChiNoiGuiMau",obj.Diachinoiguimau )
                , WorkingServices.GetParaFromOject("@MaTinhGuiMau",obj.Matinhguimau )
                , WorkingServices.GetParaFromOject("@MaHuyenGuiMau",obj.Mahuyenguimau )

                , WorkingServices.GetParaFromOject("@CanNangMe ",obj.Cannangme )
                , WorkingServices.GetParaFromOject("@SoThai",obj.Sothai )
                , WorkingServices.GetParaFromOject("@TuoiThaiMe",obj.Tuoithaime )
                , WorkingServices.GetParaFromOject("@IVF",obj.Ivf )
                , WorkingServices.GetParaFromOject("@HutThuoc",obj.Hutthuoc )
                , WorkingServices.GetParaFromOject("@BPD",obj.Bpd )
                , WorkingServices.GetParaFromOject("@ChungToc",obj.Chungtoc )
                , WorkingServices.GetParaFromOject("@DaiThaoDuong",obj.Daithaoduong )
                , WorkingServices.GetParaFromOject("@TienSu",obj.Tiensu )
                , WorkingServices.GetParaFromOject("@BSSieuAm",obj.Bssieuam )
                , WorkingServices.GetParaFromOject("@NgaySieuAm",obj.Ngaysieuam )
                , WorkingServices.GetParaFromOject("@BMI",obj.Bmi )
                , WorkingServices.GetParaFromOject("@CRL",obj.Crl )
                , WorkingServices.GetParaFromOject("@XuongMui",obj.Xuongmui )
                , WorkingServices.GetParaFromOject("@DaiThaoDuong2",obj.Daithaoduong2 )
                , WorkingServices.GetParaFromOject("@TangHAManTinh",obj.Tanghamantinh )
                , WorkingServices.GetParaFromOject("@ThaiPhuMacTSG",obj.Thaiphumactsg )
                , WorkingServices.GetParaFromOject("@MeThaiPhuMacTSG",obj.Methaiphumactsg )
                , WorkingServices.GetParaFromOject("@AntiphosphoLipid",obj.Antiphospholipid )
                , WorkingServices.GetParaFromOject("@LupusBanDo",obj.Lupusbando )
                , WorkingServices.GetParaFromOject("@DaCoThaiHon24",obj.Dacothaihon24 )
                , WorkingServices.GetParaFromOject("@NgaySinhTruoc",obj.Ngaysinhtruoc )
                , WorkingServices.GetParaFromOject("@TuoiThaiSinhTruoc",obj.Tuoithaisinhtruoc )
                , WorkingServices.GetParaFromOject("@SinhConT21T18T13 ",obj.Sinhcont21t18t13 )
                , WorkingServices.GetParaFromOject("@Chieucaome",obj.Chieucaome )
                , WorkingServices.GetParaFromOject("@Tenme",obj.Tenme)
                , WorkingServices.GetParaFromOject("@Tiensan",obj.Tiensan )
                , WorkingServices.GetParaFromOject("@Sosinh",obj.Sosinh )
                , WorkingServices.GetParaFromOject("@NgayDuSinh",obj.Ngaydusinh )
                , WorkingServices.GetParaFromOject("@TraKQSLTaiNha",obj.TraKQSLTaiNha )
                , WorkingServices.GetParaFromOject("@Goixn",obj.Goixn )
                , WorkingServices.GetParaFromOject("@DMLFlag ",flag )
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_upd_del_ThongTinSLSoSinh", sqlPara);
        }
        public int Insert_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj)
        {
            return Ins_Update_Del_ThongTinSLSoSinh(obj, "I");
        }
        public int Update_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj)
        {
            return Ins_Update_Del_ThongTinSLSoSinh(obj, "U");
        }
        public int Delete_ThongTinSLSoSinh(BENHNHAN_MAUSANGLOC obj)
        {
            return Ins_Update_Del_ThongTinSLSoSinh(obj, "D");
        }
        public DataTable Data_ThongTinSLSoSinh(string maTiepNhan)
        {
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_ThongTinSLSoSinh", new SqlParameter[] { WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan) }).Tables[0];
        }
        public BENHNHAN_MAUSANGLOC Get_ThongTinSLSoSinh(string maTiepNhan)
        {
            var data = Data_ThongTinSLSoSinh(maTiepNhan);
            if (data.Rows.Count > 0)
            {
                return Get_ThongTinSLSoSinh_ByRow(data.Rows[0]);
            }
            return null;
        }
        public BENHNHAN_MAUSANGLOC Get_ThongTinSLSoSinh_ByRow(DataRow dr)
        {
            var obj = new BENHNHAN_MAUSANGLOC();
            obj.Matiepnhan = StringConverter.ToString(dr["matiepnhan"]);
            if (!string.IsNullOrEmpty(dr["barcodelaymau"].ToString()))
                obj.Barcodelaymau = StringConverter.ToString(dr["barcodelaymau"]);
            obj.Tuoithai = NumberConverter.To<int>(dr["tuoithai"]);
            if (!string.IsNullOrEmpty(dr["noisinh"].ToString()))
                obj.Noisinh = StringConverter.ToString(dr["noisinh"]);
            obj.Cannang = NumberConverter.To<float>(dr["cannang"]);
            obj.Chieucao = NumberConverter.To<float>(dr["chieucao"]);
            obj.Ngaysinh = (DateTime)dr["ngaysinh"];
            if (!string.IsNullOrEmpty(dr["dantoc"].ToString()))
                obj.Dantoc = StringConverter.ToString(dr["dantoc"]);
            obj.Soluongsinh = NumberConverter.To<int>(dr["soluongsinh"]);
            obj.Ttbinhthuong = NumberConverter.To<bool>(dr["ttbinhthuong"]);
            obj.Ttdangbenh = NumberConverter.To<bool>(dr["ttdangbenh"]);
            obj.Ttdungkhangsinh = NumberConverter.To<bool>(dr["ttdungkhangsinh"]);
            obj.Ttdungsteriod = NumberConverter.To<bool>(dr["ttdungsteriod"]);
            obj.Tttruyenmau = NumberConverter.To<bool>(dr["tttruyenmau"]);
            if (!string.IsNullOrEmpty(dr["ttluongtruyenmau"].ToString()))
                obj.Ttluongtruyenmau = NumberConverter.To<int>(dr["ttluongtruyenmau"]);
            obj.Vitrigotchan = NumberConverter.To<bool>(dr["vitrigotchan"]);
            obj.Vitritinhmach = NumberConverter.To<bool>(dr["vitritinhmach"]);
            obj.Vitrikhac = NumberConverter.To<bool>(dr["vitrikhac"]);
            obj.Dinhduongbume = NumberConverter.To<bool>(dr["dinhduongbume"]);
            obj.Dinhduongbubinh = NumberConverter.To<bool>(dr["dinhduongbubinh"]);
            obj.Dinhduongtinhmach = NumberConverter.To<bool>(dr["dinhduongtinhmach"]);
            obj.Kieudethuong = NumberConverter.To<bool>(dr["kieudethuong"]);
            obj.Kieudemo = NumberConverter.To<bool>(dr["kieudemo"]);
            obj.Kieudekhac = NumberConverter.To<bool>(dr["kieudekhac"]);
            if (!string.IsNullOrEmpty(dr["hotenme"].ToString()))
                obj.Hotenme = StringConverter.ToString(dr["hotenme"]);
            if (!string.IsNullOrEmpty(dr["hotenbo"].ToString()))
                obj.Hotenbo = StringConverter.ToString(dr["hotenbo"]);
            if (!string.IsNullOrEmpty(dr["diachi"].ToString()))
                obj.Diachi = StringConverter.ToString(dr["diachi"]);
            obj.Namsinhme = NumberConverter.To<int>(dr["namsinhme"]);
            obj.Namsinhbo = NumberConverter.To<int>(dr["namsinhbo"]);
            obj.Matinh = NumberConverter.To<int>(dr["matinh"]);
            obj.Mahuyen = NumberConverter.To<int>(dr["mahuyen"]);
            if (!string.IsNullOrEmpty(dr["dienthoaiban"].ToString()))
                obj.Dienthoaiban = StringConverter.ToString(dr["dienthoaiban"]);
            if (!string.IsNullOrEmpty(dr["dienthoaididong"].ToString()))
                obj.Dienthoaididong = StringConverter.ToString(dr["dienthoaididong"]);
            if (!string.IsNullOrEmpty(dr["para1"].ToString()))
                obj.Para1 = StringConverter.ToString(dr["para1"]);
            if (!string.IsNullOrEmpty(dr["para2"].ToString()))
                obj.Para2 = StringConverter.ToString(dr["para2"]);
            if (!string.IsNullOrEmpty(dr["para3"].ToString()))
                obj.Para3 = StringConverter.ToString(dr["para3"]);
            if (!string.IsNullOrEmpty(dr["para4"].ToString()))
                obj.Para4 = StringConverter.ToString(dr["para4"]);
            if (!string.IsNullOrEmpty(dr["para5"].ToString()))
                obj.Para5 = StringConverter.ToString(dr["para5"]);
            if (!string.IsNullOrEmpty(dr["thoigianlaymau"].ToString()))
                obj.Thoigianlaymau = (DateTime)dr["thoigianlaymau"];
            if (!string.IsNullOrEmpty(dr["tennguoilaymau"].ToString()))
                obj.Tennguoilaymau = StringConverter.ToString(dr["tennguoilaymau"]);
            if (!string.IsNullOrEmpty(dr["manguoilaymau"].ToString()))
                obj.Manguoilaymau = StringConverter.ToString(dr["manguoilaymau"]);
            if (!string.IsNullOrEmpty(dr["noiguimau"].ToString()))
                obj.Noiguimau = StringConverter.ToString(dr["noiguimau"]);
            if (!string.IsNullOrEmpty(dr["diachinoiguimau"].ToString()))
                obj.Diachinoiguimau = StringConverter.ToString(dr["diachinoiguimau"]);
            obj.Matinhguimau = NumberConverter.To<int>(dr["matinhguimau"]);
            obj.Mahuyenguimau = NumberConverter.To<int>(dr["mahuyenguimau"]);
            obj.DeNghiSangLoc = StringConverter.ToString(dr["DeNghiSangLoc"]);
            obj.NhanXetSangLoc = StringConverter.ToString(dr["NhanXetSangLoc"]);
            obj.KetLuanSangLoc = StringConverter.ToString(dr["KetLuanSangLoc"]);
            obj.NguoiNhanXet = StringConverter.ToString(dr["NguoiNhanXet"]);
            obj.NguoiDeNghi = StringConverter.ToString(dr["NguoiDeNghi"]);
            obj.NguoiKetLuan = StringConverter.ToString(dr["NguoiKetLuan"]);
            obj.Cannangme = float.Parse(dr["cannangme"].ToString());
            obj.Sothai = int.Parse(dr["sothai"].ToString());
            obj.Tuoithaime = int.Parse(dr["tuoithaime"].ToString());
            obj.Ivf = (bool)dr["ivf"];
            obj.Hutthuoc = (bool)dr["hutthuoc"];
            obj.Bpd = int.Parse(dr["bpd"].ToString());
            if (!string.IsNullOrEmpty(dr["chungtoc"].ToString()))
                obj.Chungtoc = dr["chungtoc"].ToString();
            if (!string.IsNullOrEmpty(dr["daithaoduong"].ToString()))
                obj.Daithaoduong = dr["daithaoduong"].ToString();
            if (!string.IsNullOrEmpty(dr["tiensu"].ToString()))
                obj.Tiensu = dr["tiensu"].ToString();
            if (!string.IsNullOrEmpty(dr["bssieuam"].ToString()))
                obj.Bssieuam = dr["bssieuam"].ToString();
            if (!string.IsNullOrEmpty(dr["ngaysieuam"].ToString()))
                obj.Ngaysieuam = (DateTime)dr["ngaysieuam"];
            obj.Bmi = NumberConverter.To<float>(dr["bmi"]);
            obj.Crl = NumberConverter.To<int>(dr["crl"]);
            obj.Xuongmui = NumberConverter.To<float>(dr["xuongmui"]);
            if (!string.IsNullOrEmpty(dr["daithaoduong2"].ToString()))
                obj.Daithaoduong2 = StringConverter.ToString(dr["daithaoduong2"]);
            obj.Tanghamantinh = NumberConverter.To<bool>(dr["tanghamantinh"]);
            obj.Thaiphumactsg = NumberConverter.To<bool>(dr["thaiphumactsg"]);
            obj.Methaiphumactsg = NumberConverter.To<bool>(dr["methaiphumactsg"]);
            obj.Antiphospholipid = NumberConverter.To<bool>(dr["antiphospholipid"]);
            obj.Lupusbando = NumberConverter.To<bool>(dr["lupusbando"]);
            obj.Dacothaihon24 = NumberConverter.To<bool>(dr["dacothaihon24"]);
            if (!string.IsNullOrEmpty(dr["ngaysinhtruoc"].ToString()))
                obj.Ngaysinhtruoc = (DateTime)dr["ngaysinhtruoc"];
            obj.Tuoithaisinhtruoc = NumberConverter.To<int>(dr["tuoithaisinhtruoc"]);
            obj.Chieucaome = NumberConverter.To<float>(dr["Chieucaome"]);
            obj.Sinhcont21t18t13 = NumberConverter.To<bool>(dr["sinhcont21t18t13"]);
            obj.Tenme = dr["tenme"].ToString();
            obj.Sosinh = NumberConverter.To<bool>(dr["Sosinh"]);
            obj.Tiensan = NumberConverter.To<bool>(dr["Tiensan"]);
            obj.TraKQSLTaiNha = NumberConverter.To<bool>(dr["TraKQSLTaiNha"]);
            if (!string.IsNullOrEmpty(dr["ngaydusinh"].ToString()))
                obj.Ngaydusinh = (DateTime)dr["ngaydusinh"];
            if (!string.IsNullOrEmpty(dr["Goixetnghiem"].ToString()))
                obj.Goixn = dr["Goixetnghiem"].ToString();
            return obj;
        }
        public DataTable Data_DSTreSoSinhSangLoc(DateTime fromDate, DateTime toDate)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@TuNgayTiepNhan", fromDate, true),
                WorkingServices.GetParaFromOject("@DenNgayTiepNhan", toDate, true)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_SangLocSoSinh_DanhSachTre", sqlPara).Tables[0];
        }
        public DataTable Data_DSSangLocTruocSinh(DateTime fromDate, DateTime toDate)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@TuNgayTiepNhan", fromDate, true),
                WorkingServices.GetParaFromOject("@DenNgayTiepNhan", toDate, true)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_SangLocTruoSinh_DanhSachBN", sqlPara).Tables[0];
        }
        public int Update_NhanXetDeNghi_SangLoc(string maTiepNhan, string nhanXet, string nguoiNhanXet
            , string deNghi, string nguoiDeNghi, string ketLuan, string nguoiKetLuan)
        {
            var sqlPara = new SqlParameter[] {
                  WorkingServices.GetParaFromOject("@MaTiepNhan", maTiepNhan)
                , WorkingServices.GetParaFromOject("@NguoiNhanXet", nguoiNhanXet)
                , WorkingServices.GetParaFromOject("@NhanXet", nhanXet)
                , WorkingServices.GetParaFromOject("@NguoiDeNghi", nguoiDeNghi)
                , WorkingServices.GetParaFromOject("@DeNghi", deNghi)
                , WorkingServices.GetParaFromOject("@NguoiKetLuan", nguoiKetLuan)
                , WorkingServices.GetParaFromOject("@KetLuan", ketLuan)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_SangLoc_NhanXet_DeNghi", sqlPara);
        }
        public DataTable Data_PhieuHen_SLSS(string matiepNhan)
        {
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@MaTiepNhan", matiepNhan)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_SangLocSoSinh_PhieuHen", sqlPara).Tables[0]; 
        }
        #endregion
        #region Chi dinh tu mau
        public int DeleteOrderOfElement(string sid, string elementId, string userDel, string pcDel)
        {
            var para = new SqlParameter[]
             {
                WorkingServices.GetParaFromOject("@SID",sid),
                WorkingServices.GetParaFromOject("@ElementID",elementId),
                WorkingServices.GetParaFromOject("@UserDel",userDel),
                WorkingServices.GetParaFromOject("@PCDel",pcDel)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "LabBlood_del_BenhNhanDuTru_ChiDinh", para);
        }
        public int DeletePatientWithoutElement(string sid, string userDel, string pcDel)
        {
            var para = new SqlParameter[]
                  {
                    WorkingServices.GetParaFromOject("@SID",sid),
                    WorkingServices.GetParaFromOject("@UserDel",userDel),
                    WorkingServices.GetParaFromOject("@PCDel",pcDel)
                  };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "LabBlood_del_Patient_WithoutOrder", para);
        }
        #endregion
        #region Chi dinh GPB
        public int DeleteOrderOfGPB(string sid, string testCodeLIS, string userDel, string pcDel)
        {
            var para = new SqlParameter[]
             {
                WorkingServices.GetParaFromOject("@SID",sid),
                WorkingServices.GetParaFromOject("@TestCodeLIS",testCodeLIS),
                WorkingServices.GetParaFromOject("@UserDel",userDel),
                WorkingServices.GetParaFromOject("@PCDel",pcDel)
             };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "Anapath_del_TestOrderFromHIS", para);
        }
        public int DeletePatientWithoutGPB(string sid, string userDel, string pcDel)
        {
            var para = new SqlParameter[]
                  {
                    WorkingServices.GetParaFromOject("@SID",sid),
                    WorkingServices.GetParaFromOject("@UserDel",userDel),
                    WorkingServices.GetParaFromOject("@PCDel",pcDel)
                  };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "Anapath_del_PatientOrderFromHIS", para);
        }
        #endregion
        #region xetnghiem_ghichu_laymau
        public int Insert_xetnghiem_ghichu_laymau(XETNGHIEM_GHICHU_LAYMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@NoiDungGhiChu", objInfo.Noidungghichu),
                        WorkingServices.GetParaFromOject("@MaGhiChu", objInfo.Maghichu),
                        WorkingServices.GetParaFromOject("@NguoiGhiChu", objInfo.Nguoighichu),
                        WorkingServices.GetParaFromOject("@PcThucHien", objInfo.Pcthuchien)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_xetnghiem_ghichu_laymau", para);
        }
        public int Delete_xetnghiem_ghichu_laymau(XETNGHIEM_GHICHU_LAYMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@NguoiGhiChu", objInfo.Nguoighichu),
                        WorkingServices.GetParaFromOject("@PcThucHien", objInfo.Pcthuchien)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_xetnghiem_ghichu_laymau", para);
        }
        public DataTable Data_xetnghiem_ghichu_laymau(string maxn, string matiepnhan)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_xetnghiem_ghichu_laymau", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public XETNGHIEM_GHICHU_LAYMAU Get_Info_xetnghiem_ghichu_laymau(DataRow drInfo)
        {
            return (XETNGHIEM_GHICHU_LAYMAU)WorkingServices.Get_InfoForObject(new XETNGHIEM_GHICHU_LAYMAU(), drInfo);
        }
        public XETNGHIEM_GHICHU_LAYMAU Get_Info_xetnghiem_ghichu_laymau(string maxn, string matiepnhan)
        {
            DataTable dt = Data_xetnghiem_ghichu_laymau(maxn, matiepnhan);
            XETNGHIEM_GHICHU_LAYMAU obj = new XETNGHIEM_GHICHU_LAYMAU();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_xetnghiem_ghichu_laymau(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_xetnghiem_ghichu_laymau(string maxn, string matiepnhan)
        {
            return Data_xetnghiem_ghichu_laymau(maxn, matiepnhan).Rows.Count > 0;
        }

        #endregion
        #region Quản lý mẫu gửi nội bộ
        public int Insert_GuimauNoiBo(GuiMauNoiBoModel info)
        {
            var sqlPara = new SqlParameter[] {WorkingServices.GetParaFromOject("@MaTiepNhan",info.Matiepnhan)
                            ,WorkingServices.GetParaFromOject("@MaXN",info.Madichvu)
                            ,WorkingServices.GetParaFromOject("@MaNhomCLS",info.Manhomdichvu)
                            ,WorkingServices.GetParaFromOject("@MaOngMau",info.Maongmau)
                            ,WorkingServices.GetParaFromOject("@PCGui",info.Pcgui)
                            ,WorkingServices.GetParaFromOject("@NguoiGui",info.Nguoigui)
                            ,WorkingServices.GetParaFromOject("@KhuVucGuiID",info.Khuvucguiid)
                            ,WorkingServices.GetParaFromOject("@KhuVucNhanID",info.Khuvucnhanid)
                                 };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_GuiMauNoiBo", sqlPara);
        }
        public int Insert_NhatKyGuiMauNoiBo(GuiMauNoiBoModel info)
        {
            /*@ID bigint
            ,@NguoiThucHien varchar(25)
            ,@PCThucHien nvarchar(100)
            ,@IDThucHien int
            ,@ThoiGianThucHien datetime
            ,@LyDo nvarchar(250)
            ,@IDLyDo varchar(25)
            */
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@ID",info.Idgui)
                            ,WorkingServices.GetParaFromOject("@NguoiThucHien",info.Nguoithuchien)
                            ,WorkingServices.GetParaFromOject("@PCThucHien",info.Pcthuchien)
                            ,WorkingServices.GetParaFromOject("@IDThucHien",info.Idloaithuchien)
                            ,WorkingServices.GetParaFromOject("@ThoiGianThucHien",info.Tgthuchien)
                            ,WorkingServices.GetParaFromOject("@LyDo",info.Lydo)
                            ,WorkingServices.GetParaFromOject("@IDLyDo",info.Idlydo)
                                 };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insXetNghiem_NhatKy_GuiMauNoiBo", sqlPara);
        }
        public int Delete_XetNghiem_GuiMau(GuiMauNoiBoModel info)
        {
            //create proc delXetNghiem_GuiMauNoiBo
            //@ID bigint
            //,@NguoiThucHien varchar(25)
            //, @PCThucHien nvarchar(100)
            //, @IDThucHien int
            //, @ThoiGianThucHien datetime
            //, @LyDo nvarchar(250)
            //, @IDLyDo varchar(25)
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@ID",info.Idgui)
                            ,WorkingServices.GetParaFromOject("@NguoiThucHien",info.Nguoithuchien)
                            ,WorkingServices.GetParaFromOject("@PCThucHien",info.Pcthuchien)
                            ,WorkingServices.GetParaFromOject("@IDThucHien",info.Idloaithuchien)
                            ,WorkingServices.GetParaFromOject("@ThoiGianThucHien",info.Tgthuchien)
                            ,WorkingServices.GetParaFromOject("@LyDo",info.Lydo)
                            ,WorkingServices.GetParaFromOject("@IDLyDo",info.Idlydo)
                           };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delXetNghiem_GuiMauNoiBo", sqlPara);
        }
        public int Update_XetNghiem_NhanMauGui(GuiMauNoiBoModel info)
        {
            //            create proc udpXetNghiem_NhanMauGui
            //@IDGui bigint
            //,@DaNhanMau bit
            //, @KhuVucNhanID varchar(20)
            //,@PCNhan nvarchar(100)
            //, @NguoiNhan varchar(25)
            //, @TgNhan datetime
            //, @IDBoNhanMau int
            //, @LyDo nvarchar(250)
            //, @IDLyDo varchar(25)
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@IDGui",info.Idgui)
                            ,WorkingServices.GetParaFromOject("@DaNhanMau",info.Danhanmau)
                            ,WorkingServices.GetParaFromOject("@KhuVucNhanID",info.Khuvucnhanid)
                            ,WorkingServices.GetParaFromOject("@PCNhan",info.Pcnhan)
                            ,WorkingServices.GetParaFromOject("@NguoiNhan",info.Nguoinhan)
                            ,WorkingServices.GetParaFromOject("@TgNhan",info.Tgnhan)
                            ,WorkingServices.GetParaFromOject("@IDBoNhanMau",info.Idloaithuchien)
                            ,WorkingServices.GetParaFromOject("@LyDo",info.Lydo)
                            ,WorkingServices.GetParaFromOject("@IDLyDo",info.Idlydo)
                           };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpXetNghiem_NhanMauGui", sqlPara);
        }
        public DataTable Data_XetNghiem_GuiMau(string lstMaTiepNhan, int trangThaiNhan, string[] arrPhanQuyenNhom)
        {
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@lstMaTiepNhan",lstMaTiepNhan)
                           ,WorkingServices.GetParaFromOject("@trangThaiNhan",trangThaiNhan)
                           ,WorkingServices.GetParaFromOject("@PhanQuyenNhom",string.Join(",",arrPhanQuyenNhom))
                                 };
            var data = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selXetNghiem_DanhSach_MauGui", sqlPara);
            if (data != null)
            {
                return data.Tables[0];
            }
            else
                return null;
        }

        public int Update_TrangThaiGuiMau_Nhom(string maTiepNhan, string maNhomCLS)
        {
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                           ,WorkingServices.GetParaFromOject("@MaNhomCLS ",maNhomCLS)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_Nhom_ThongTinGuiMau", sqlPara);
        }
        public int Update_TrangThaiNhanMauGui_Nhom(string maTiepNhan, string maNhomCLS)
        {
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
                           ,WorkingServices.GetParaFromOject("@MaNhomCLS ",maNhomCLS)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_Nhom_ThongTinNhanMauGui", sqlPara);
        }
        public int Update_TrangThaiGuiMau_BoPhan(string maTiepNhan)
        {
            var sqlPara = new SqlParameter[] {
                            WorkingServices.GetParaFromOject("@MaTiepNhan",maTiepNhan)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "updXetNghiem_BoPhan_TrangThaiMauGuiNoiBo", sqlPara);
        }
        #endregion
        #region Gửi mẫu cho đơn vị khác
        public int Insert_xetnghiem_guimau(XETNGHIEM_GUIMAU objInfo)
        {
            if (CheckExists_xetnghiem_guimau(objInfo.Matiepnhan, objInfo.Maxn)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaDonViNhan", objInfo.Madonvinhan),
                        WorkingServices.GetParaFromOject("@Barcode", objInfo.Barcode),
                        WorkingServices.GetParaFromOject("@NguoiChon", objInfo.Nguoichon),
                        WorkingServices.GetParaFromOject("@NguoiGui", objInfo.Nguoigui),
                        WorkingServices.GetParaFromOject("@PcThucHienGui", objInfo.Pcthuchiengui)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_xetnghiem_guimau", para);
        }
        public int Update_xetnghiem_guimau_donvinhan(XETNGHIEM_GUIMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@MaDonViNhan", objInfo.Madonvinhan)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_xetnghiem_guimau_donvinhan", para);
        }
        public int Update_xetnghiem_guimau_Xacnhangui(XETNGHIEM_GUIMAU objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@NguoiGui", objInfo.Nguoigui),
                        WorkingServices.GetParaFromOject("@PcThucHienGui", objInfo.Pcthuchiengui)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_xetnghiem_guimau_xacnhangui", para);
        }
        public int Delete_xetnghiem_guimau(string matiepnhan, string maxn, string NguoiXoa, string PCXoa)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                         WorkingServices.GetParaFromOject("@NguoiXoa", NguoiXoa),
                        WorkingServices.GetParaFromOject("@PCXoa", PCXoa)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_xetnghiem_guimau", para);
        }
        public DataTable Data_xetnghiem_guimau(string matiepnhan, string maxn, string donvinhan, DateTime? ngaytao)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                        WorkingServices.GetParaFromOject("@MaDonViNhan", donvinhan),
                        WorkingServices.GetParaFromOject("@Ngaytao", ngaytao)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_xetnghiem_guimau", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable Data_xetnghiem_guimau_daxoa(string matiepnhan, string maxn, string donvinhan, DateTime? ngaytao)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaTiepNhan", matiepnhan),
                        WorkingServices.GetParaFromOject("@MaXN", maxn),
                        WorkingServices.GetParaFromOject("@MaDonViNhan", donvinhan),
                        WorkingServices.GetParaFromOject("@Ngaytao", ngaytao)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_xetnghiem_guimau_daxoa", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public XETNGHIEM_GUIMAU Get_Info_xetnghiem_guimau(DataRow drInfo)
        {
            return (XETNGHIEM_GUIMAU)WorkingServices.Get_InfoForObject(new XETNGHIEM_GUIMAU(), drInfo);
        }
        public XETNGHIEM_GUIMAU Get_Info_xetnghiem_guimau(string matiepnhan, string maxn)
        {
            DataTable dt = Data_xetnghiem_guimau(matiepnhan, maxn, string.Empty, null);
            XETNGHIEM_GUIMAU obj = new XETNGHIEM_GUIMAU();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_xetnghiem_guimau(dt.Rows[0]);
            }
            return obj;
        }

        public bool CheckExists_xetnghiem_guimau(string matiepnhan, string maxn)
        {
            return Data_xetnghiem_guimau(matiepnhan, maxn, string.Empty, null).Rows.Count > 0;
        }

        public int Insert_xetnghiem_guimau_ketqua(XETNGHIEM_GUIMAU_KETQUA objInfo)
        {
            if (CheckExists_xetnghiem_guimau_ketqua(objInfo.Id)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", objInfo.Id),
                        WorkingServices.GetParaFromOject("@Barcode", objInfo.Barcode),
                        WorkingServices.GetParaFromOject("@DonViTra", objInfo.Donvitra),
                        WorkingServices.GetParaFromOject("@MaXn", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@KetQua", objInfo.Ketqua),
                        WorkingServices.GetParaFromOject("@CoKetQua", objInfo.Coketqua),
                        WorkingServices.GetParaFromOject("@CSBT", objInfo.Csbt),
                        WorkingServices.GetParaFromOject("@NguoiKy", objInfo.Nguoiky),
                        WorkingServices.GetParaFromOject("@ChucVu", objInfo.Chucvu),
                        WorkingServices.GetParaFromOject("@NgayKy", objInfo.Ngayky),
                        WorkingServices.GetParaFromOject("@NgayGuiKetQua", objInfo.Ngayguiketqua),
                        WorkingServices.GetParaFromOject("@TrangThai", objInfo.Trangthai),
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaTiepNhanNoiTra", objInfo.Matiepnhannoitra),
                        WorkingServices.GetParaFromOject("@BarcodeNoiTra", objInfo.Barcodenoitra),
                        WorkingServices.GetParaFromOject("@IdMayXn", objInfo.Idmayxn),
                        WorkingServices.GetParaFromOject("@TenMayXn", objInfo.Tenmayxn),
                        WorkingServices.GetParaFromOject("@NguonNhan", objInfo.Nguonnhan)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_xetnghiem_guimau_ketqua", para);
        }
        public int Update_xetnghiem_guimau_ketqua(XETNGHIEM_GUIMAU_KETQUA objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", objInfo.Id),
                        WorkingServices.GetParaFromOject("@Barcode", objInfo.Barcode),
                        WorkingServices.GetParaFromOject("@DonViTra", objInfo.Donvitra),
                        WorkingServices.GetParaFromOject("@MaXn", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@KetQua", objInfo.Ketqua),
                        WorkingServices.GetParaFromOject("@CoKetQua", objInfo.Coketqua),
                        WorkingServices.GetParaFromOject("@CSBT", objInfo.Csbt),
                        WorkingServices.GetParaFromOject("@NguoiKy", objInfo.Nguoiky),
                        WorkingServices.GetParaFromOject("@ChucVu", objInfo.Chucvu),
                        WorkingServices.GetParaFromOject("@NgayKy", objInfo.Ngayky),
                        WorkingServices.GetParaFromOject("@NgayGuiKetQua", objInfo.Ngayguiketqua),
                        WorkingServices.GetParaFromOject("@TrangThai", objInfo.Trangthai),
                        WorkingServices.GetParaFromOject("@MaTiepNhan", objInfo.Matiepnhan),
                        WorkingServices.GetParaFromOject("@MaTiepNhanNoiTra", objInfo.Matiepnhannoitra),
                        WorkingServices.GetParaFromOject("@BarcodeNoiTra", objInfo.Barcodenoitra),
                        WorkingServices.GetParaFromOject("@IdMayXn", objInfo.Idmayxn),
                        WorkingServices.GetParaFromOject("@TenMayXn", objInfo.Tenmayxn),
                        WorkingServices.GetParaFromOject("@NguonNhan", objInfo.Nguonnhan)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_xetnghiem_guimau_ketqua", para);
        }
        public int Delete_xetnghiem_guimau_ketqua(int id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", id)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_xetnghiem_guimau_ketqua", para);
        }
        public DataTable Data_xetnghiem_guimau_ketqua(int id)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@ID", id)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_xetnghiem_guimau_ketqua", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public XETNGHIEM_GUIMAU_KETQUA Get_Info_xetnghiem_guimau_ketqua(DataRow drInfo)
        {
            return (XETNGHIEM_GUIMAU_KETQUA)WorkingServices.Get_InfoForObject(new XETNGHIEM_GUIMAU_KETQUA(), drInfo);
        }
        public XETNGHIEM_GUIMAU_KETQUA Get_Info_xetnghiem_guimau_ketqua(int id)
        {
            DataTable dt = Data_xetnghiem_guimau_ketqua(id);
            XETNGHIEM_GUIMAU_KETQUA obj = new XETNGHIEM_GUIMAU_KETQUA();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_xetnghiem_guimau_ketqua(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_xetnghiem_guimau_ketqua(int id)
        {
            return Data_xetnghiem_guimau_ketqua(id).Rows.Count > 0;
        }

        #endregion

    }
}
