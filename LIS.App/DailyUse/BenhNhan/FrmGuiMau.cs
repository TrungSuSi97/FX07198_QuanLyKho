using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using TPH.Common.Converter;
using TPH.Data.HIS.Models;
using TPH.Lab.Middleware.Helpers.Enum;
using TPH.Lab.Middleware.HISConnect.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.App.AppCode;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Model;
using TPH.LIS.TestResult.Services;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmGuiMau : FrmTemplate
    {
        public string ReceptionCode = "";
        public bool ReloadResult = false;
        private HisConnection hisInfo;

        private readonly IConnectHISService _iHISService = new ConnectHISService();
        private readonly ITestResultService _xetnghiem = new TestResultService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ITestResultInformationService _iTestResult = new TestResultInformationService();
        private List<SeviceOrderedInformation> dsChiDinh = new List<SeviceOrderedInformation>();
        public FrmGuiMau()
        {
            InitializeComponent();
        }

        private void FrmGuiMau_Load(object sender, System.EventArgs e)
        {
            LoadPartners();
            LoadChiDinh();
        }

        private void btnGetPartners_Click(object sender, System.EventArgs e)
        {
            LoadPartners();
        }

        private void btnSendSample_Click(object sender, System.EventArgs e)
        {
            if (cboPartners == null || string.IsNullOrWhiteSpace(cboPartners.Text))
            {
                MessageBox.Show("Vui lòng chọn Đơn vị nhận mẫu!");
            }
            else if (gvChiDinh.GetSelectedRows().Count() > 0)
            {
                var xetNghiemGui = new List<object>();
                var xetNghiemDaGui = string.Empty;
                var xetNghiemChuaGui = string.Empty;
                var benhNhanTiepNhan = _iPatient.Get_Info_BenhNhan_TiepNhan(ReceptionCode, null);
                var doiTacNhanMauDangChon = StringConverter.ToString(cboPartners.SelectedValue);

                var dsXetNghiemDaGui = from q in dsChiDinh where !string.IsNullOrWhiteSpace(q.DoiTacNhanMauXN) select q;
                
                foreach (var i in gvChiDinh.GetSelectedRows())
                {
                    if (i < 0)
                    {
                        continue;
                    }

                    var dvCls = (string)gvChiDinh.GetRowCellValue(i, MaPhanLoai);
                    var isPaid = gvChiDinh.GetRowCellValue(i, DaThuTien) == null ? false : (bool)gvChiDinh.GetRowCellValue(i, DaThuTien);
                    var profileId = gvChiDinh.GetRowCellValue(i, MaProfile) != null ? gvChiDinh.GetRowCellValue(i, MaProfile).ToString() : string.Empty;
                    var maChiDinh = gvChiDinh.GetRowCellValue(i, MaChiDinh) != null ? gvChiDinh.GetRowCellValue(i, MaChiDinh).ToString() : string.Empty;
                    var tenChiDinh = gvChiDinh.GetRowCellValue(i, TenChiDinh) != null ? gvChiDinh.GetRowCellValue(i, TenChiDinh).ToString() : string.Empty;
                    var loaiXetNghiem = gvChiDinh.GetRowCellValue(i, colLoaiXetNghiem) != null ? int.Parse(gvChiDinh.GetRowCellValue(i, colLoaiXetNghiem).ToString()) : -1;
                    var doiTacNhanMauXN = gvChiDinh.GetRowCellValue(i, colDoiTacNhanMauXN) != null ? gvChiDinh.GetRowCellValue(i, colDoiTacNhanMauXN).ToString() : string.Empty;

                    if (!string.IsNullOrWhiteSpace(maChiDinh))
                    {
                        if (string.IsNullOrWhiteSpace(doiTacNhanMauXN))
                        {
                            if (dsXetNghiemDaGui != null && dsXetNghiemDaGui.Any() &&
                                !dsXetNghiemDaGui.FirstOrDefault().DoiTacNhanMauXN.ToLower().Equals(doiTacNhanMauDangChon.ToLower()))
                            {
                                MessageBox.Show("Mỗi tiếp nhận chỉ được gửi mẫu đến cùng 1 đối tác");
                                return;
                            }

                            var xnDetail = new Dictionary<string, string>
                            {
                                {"ReceptionCodeByInputBranch", ReceptionCode},
                                {"TestingCode", maChiDinh},
                                {"ServiceType", benhNhanTiepNhan.Doituongdichvu},
                                {"ProfileId", profileId},
                            };
                            xetNghiemChuaGui += $"{maChiDinh},";
                            xetNghiemGui.Add(xnDetail);
                        }
                        else
                        {
                            xetNghiemDaGui += $"{tenChiDinh}; ";
                        }
                    }
                }

                if (xetNghiemGui != null && xetNghiemGui.Count > 0)
                {
                    var donViNhanMau = JsonConvert.DeserializeObject<dynamic>(hisInfo.UserName);

                    var thongTinGuiMau = new Dictionary<string, object>
                    {
                        {"ReceptionDate", benhNhanTiepNhan.Ngaytiepnhan},
                        {"ReceptionCodeByInputBranch", ReceptionCode},
                        {"InputByBranch", donViNhanMau.Value},
                        {"SendByBranch", donViNhanMau.Value},
                        {"ReceiveByBranch", doiTacNhanMauDangChon},
                        {"PatientCodeByInputBranch", benhNhanTiepNhan.Mabn},
                        {"PatientName", benhNhanTiepNhan.Tenbn},
                        {"Birthday", benhNhanTiepNhan.Ngaytiepnhan},
                        {"Gender", benhNhanTiepNhan.Gioitinh},
                        {"PersonalId", benhNhanTiepNhan.Idcongdan},
                        //{"Passport", benhNhanTiepNhan.SoHoChieu},
                        //{"PassportIssuedDate", benhNhanTiepNhan.NgayCapHoChieu},
                        {"Phone", benhNhanTiepNhan.Sdt},
                        {"Email", benhNhanTiepNhan.Email},
                        {"Address", benhNhanTiepNhan.Diachi},
                        {"Diagnose", benhNhanTiepNhan.Chandoan},
                        {"ServiceType", benhNhanTiepNhan.Doituongdichvu},
                        {"PatientType", benhNhanTiepNhan.Doituong},

                        {"AssignationTests", xetNghiemGui}
                    };

                    var updateResult = GuiMauXetNghiem(thongTinGuiMau);
                    if (updateResult.Code == 0)
                    {
                        CapNhatMauXetNghiem(ReceptionCode, doiTacNhanMauDangChon.ToString(), xetNghiemChuaGui.TrimEnd(','), DateTime.Now);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(updateResult.Message);
                    }
                }

                if (!string.IsNullOrWhiteSpace(xetNghiemDaGui))
                {
                    MessageBox.Show($"Xét nghiệm đã gửi mẫu: {xetNghiemDaGui}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mẫu muốn gửi!");
            }
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            if (dsChiDinh != null && dsChiDinh.Count > 0)
            {
                var orderDetail = dsChiDinh.FirstOrDefault();
                var para = new Dictionary<string, object>()
                {
                    {"ReceptionCode", ReceptionCode },
                    {"PatientCode", orderDetail.MaBenhNhan}
                };

                var sampleResult = LayKetQua(para);
                if (sampleResult != null &&
                    sampleResult.Data != null &&
                    sampleResult.Data.Rows.Count > 0)
                {
                    UpdateResult(sampleResult.Data, ReceptionCode);
                    ReloadResult = true;
                    this.Close();
                }
            }
        }

        private void LoadPartners()
        {
            hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals(TPH.Data.HIS.HISDataCommon.HisProvider.TPHLabIMS_Web_API)).FirstOrDefault();
            var obj = _iHISService.DanhMucHIS(HISParaInfo.DonViGuiMau, hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList);

            cboPartners.DataSource = obj.Data;
            cboPartners.ValueMember = "PartnerCode";
            cboPartners.DisplayMember = "PartnerName";
            if (obj.Data != null && obj.Data.Rows != null && obj.Data.Rows.Count > 0)
            {
                cboPartners.SelectedIndex = -1;
            }
        }

        private void LoadChiDinh()
        {
            if (!string.IsNullOrWhiteSpace(ReceptionCode))
            {
                dsChiDinh = _iPatient.GetOrderServiceDetail(ReceptionCode, true, string.Empty, true, true);

                gcChiDinh.DataSource = dsChiDinh;
                gvChiDinh.ExpandAllGroups();
            }
        }

        private HISReturnBase GuiMauXetNghiem(Dictionary<string, object> tiepNhan)
        {
            //oderListData = _iHisData.GetPatientOrderedList(this.hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList, hColumnNames);
            return _iHISService.ThemTiepNhanVaChiDinh(hisInfo, tiepNhan);
        }

        private void CapNhatMauXetNghiem(string maTiepNhan, string doiTacNhanMau, string maXN, DateTime ngayGui)
        {
            _iTestResult.UpdateTrangThaiDoiTacNhanMau(maTiepNhan, doiTacNhanMau, maXN, ngayGui);
        }
        private HISReturnBase LayKetQua(Dictionary<string, object> para)
        {
            return _iHISService.LayKetQua(hisInfo, para);
        }
        private void UpdateResult(DataTable result, string maTiepNhan)
        {

            var log = string.Empty;
            try
            {
                log = "Lấy các giá trị";
                foreach (DataRow resultDetail in result.Rows)
                {

                    log += Environment.NewLine + "     _indexKQ";
                    //var indexKq = 3;
                    log += Environment.NewLine + "     _KetQua";
                    var ketQua = StringConverter.ToString(resultDetail["Result"]);

                    log += Environment.NewLine + "     _MaXN";
                    var maXn = StringConverter.ToString(resultDetail["TestingCode"]);

                    log += Environment.NewLine + "     _GhiChu";
                    var ghiChu = StringConverter.ToString(resultDetail["Note"]);

                    log += Environment.NewLine + "     _NguongTren";
                    var nguongTren = StringConverter.ToString(resultDetail["UpperRange"]);

                    log += Environment.NewLine + "     _NguongDuoi";
                    var nguongDuoi = StringConverter.ToString(resultDetail["LowerRange"]);

                    log += Environment.NewLine + "     _DieuKienBatThuong";
                    var dieuKienBatThuong = StringConverter.ToString(resultDetail["NormalRange"]);

                    log += Environment.NewLine + "     _Co";
                    var flag = NumberConverter.To<float>(resultDetail["Flat"]);

                    log += Environment.NewLine + "     _UserNhap";
                    var userNhap = "API"; //CommonAppVarsAndFunctions.UserID;

                    log += Environment.NewLine + "     _XNChinh";
                    var hesoquidoi = NumberConverter.To<float>(resultDetail["ConversionCoefficient"]);

                    var lamtron = string.Empty;

                    // cờ cảnh báo
                    log += Environment.NewLine + "     _NguongTrenCanhBao";
                    var nguongTrenCanhBao = string.Empty;

                    log += Environment.NewLine + "     _NguongDuoiCanhBao";
                    var nguongDuoiCanhBao = string.Empty;

                    log += Environment.NewLine + "     _DieuKienCanhBaoDinhTinh";
                    var dieuKienBatThuongCanhBao = string.Empty;

                    log += Environment.NewLine + "     _CoCanhBao";
                    var flagCanhBao = 0;

                    log += Environment.NewLine + "Thực hiện kiểm tra đánh giá khi nhập hoặc sửa kết quả";
                    log += Environment.NewLine + "Đánh giá kết quả";

                    flag = LabResultService.SetColor(ketQua, nguongTren, nguongDuoi, dieuKienBatThuong);
                    flagCanhBao = LabResultService.SetColor(ketQua, nguongTrenCanhBao, nguongDuoiCanhBao, dieuKienBatThuongCanhBao);
                    var obUpdate = new UpdateResultNormalInfo()
                    {
                        maTiepNhan = maTiepNhan,
                        maXN = maXn,
                        ketQua = ketQua,
                        capNhatghiChu = true,
                        ghiChu = ghiChu,
                        co = flag.ToString(),
                        userNhap = CommonAppVarsAndFunctions.UserID,
                        suaKQ = (!string.IsNullOrWhiteSpace(userNhap)),
                        round = lamtron,
                        userUpdate = CommonAppVarsAndFunctions.UserID,
                        coCanhBao = flagCanhBao,
                        Qcout = false
                    };
                    if (string.IsNullOrEmpty(ketQua))
                    {
                        obUpdate.capnhatCoKetQua = true;
                        obUpdate.coKetQua = "";
                    }
                    _xetnghiem.CapNhat_KQ_XN(obUpdate);
                    _xetnghiem.CapNhat_CSBT(maTiepNhan, maXn, "0", true);

                    _xetnghiem.CapNhat_DuKQ_XN(maTiepNhan);
                   // _xetnghiem.CapNhat_ThongTinMayXn_XnChinh(maTiepNhan);
                }
            }
            catch (Exception ex)
            {
                LabServices_Helper.RecordError(log);
                ErrorService.GetFrameworkErrorMessage(ex, "CapNhatKQ_API", CommonAppVarsAndFunctions.UserID);
            }
        }
    }
}