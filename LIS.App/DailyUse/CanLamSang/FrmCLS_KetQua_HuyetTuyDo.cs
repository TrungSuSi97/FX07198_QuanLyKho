using Common.Logging;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.Controls;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.Settings.HeThong;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Model;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Services.UserManagement;
using TPH.Report.Constants;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmCLS_KetQua_HuyetTuyDo : FrmTemplate
    {
        public FrmCLS_KetQua_HuyetTuyDo()
        {
            InitializeComponent();
            ricKetQuaSinhThiet.ToolStripVisible = ricBienBanChocHutTuyXuong.ToolStripVisible = ricDeNghiHuyetDo.ToolStripVisible = ricDeNghiTuyDo.ToolStripVisible
               = ricKetLuanHuyetDo.ToolStripVisible = ricKetLuanTuyDo.ToolStripVisible = ricNhanXetHuyetDo.ToolStripVisible
               = ricNhanXetTuyDo.ToolStripVisible = true;
            ricKetQuaSinhThiet.GroupAlignmentVisible = ricBienBanChocHutTuyXuong.GroupAlignmentVisible = ricDeNghiHuyetDo.GroupAlignmentVisible = ricDeNghiTuyDo.GroupAlignmentVisible
                = ricKetLuanHuyetDo.GroupAlignmentVisible = ricKetLuanTuyDo.GroupAlignmentVisible = ricNhanXetHuyetDo.GroupAlignmentVisible
                = ricNhanXetTuyDo.GroupAlignmentVisible = true;
            ricKetQuaSinhThiet.GroupBoldUnderlineItalicVisible = ricBienBanChocHutTuyXuong.GroupBoldUnderlineItalicVisible = ricDeNghiHuyetDo.GroupBoldUnderlineItalicVisible = ricDeNghiTuyDo.GroupBoldUnderlineItalicVisible
               = ricKetLuanHuyetDo.GroupBoldUnderlineItalicVisible = ricKetLuanTuyDo.GroupBoldUnderlineItalicVisible = ricNhanXetHuyetDo.GroupBoldUnderlineItalicVisible
               = ricNhanXetTuyDo.GroupBoldUnderlineItalicVisible = true;
            ricKetQuaSinhThiet.GroupFontNameAndSizeVisible = ricBienBanChocHutTuyXuong.GroupFontNameAndSizeVisible = ricDeNghiHuyetDo.GroupFontNameAndSizeVisible = ricDeNghiTuyDo.GroupFontNameAndSizeVisible
              = ricKetLuanHuyetDo.GroupFontNameAndSizeVisible = ricKetLuanTuyDo.GroupFontNameAndSizeVisible = ricNhanXetHuyetDo.GroupFontNameAndSizeVisible
              = ricNhanXetTuyDo.GroupFontNameAndSizeVisible = true;
            ricKetQuaSinhThiet.GroupFontColorVisible = ricBienBanChocHutTuyXuong.GroupFontColorVisible = true;
        }

        TestResult.Services.ITestResultService _iTestResult = new TestResult.Services.TestResultService();
        Patient.Services.IPatientInformationService _iPatient = new Patient.Services.PatientInformationService();
        private readonly ISystemConfigService _isSysConfig = new SystemConfigService();
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        IUserManagementService _userManagement = new UserManagementService();

        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private List<ReportModel> lstResultReportInfo = new List<ReportModel>();

        DataTable dataResultBN = new DataTable();
        private static DM_XETNGHIEM_MAUPHIEUIN ThongTinPhieuIn;
        private static List<DM_XETNGHIEM_MAUPHIEUIN> lstThongTinPhieuIn;
        private ReportModel GetReportFromConfig(string reportemplateId)
        {
            if (lstThongTinPhieuIn == null)
            {
                lstThongTinPhieuIn = new List<DM_XETNGHIEM_MAUPHIEUIN>();
                var objreport = _isSysConfig.Get_Info_dm_xetnghiem_mauphieuin(reportemplateId);
                if (!string.IsNullOrEmpty(objreport.Idreport))
                {
                    ThongTinPhieuIn = objreport;
                    lstThongTinPhieuIn.Add(ThongTinPhieuIn);
                    return GetReportInList(objreport.Idreport);
                }
            }
            else
            {
                var reportID = lstThongTinPhieuIn.Where(x => x.Idmauketqua.Equals(reportemplateId));
                if (reportID.Any())
                {
                    ThongTinPhieuIn = reportID.First();
                    return GetReportInList(ThongTinPhieuIn.Idreport);
                }
                else
                {
                    var objreport = _isSysConfig.Get_Info_dm_xetnghiem_mauphieuin(reportemplateId);
                    if (!string.IsNullOrEmpty(objreport.Idreport))
                    {
                        ThongTinPhieuIn = objreport;
                        lstThongTinPhieuIn.Add(ThongTinPhieuIn);
                        return GetReportInList(objreport.Idreport);
                    }
                }
            }
            return null;
        }
        private ReportModel GetReportInList(string reportID)
        {
            var lst = lstResultReportInfo.Where(x => x.ReportId.Equals(reportID));
            if (lst.Any())
            {
                return lst.FirstOrDefault();
            }
            else
            {
                var rp = _reportInfo.Info_Report(reportID);
                if (!string.IsNullOrEmpty(rp.ReportId))
                {
                    lstResultReportInfo.Add(rp);
                    return rp;
                }
            }
            return null;
        }
        private bool _allowEdit;
        private bool _allowInsert;
        private bool _allowEditResulFromOtherUser;
        public string inputMatiepnhan { get; set; }
        public DateTime ngaytiepnhan { get; set; }
        DataTable _dtPatient;
        private Image reportLogo;
        private void Load_ThongTinBenhNhan(string maTiepNhan)
        {
            //Thông tin hành chính
            ucPatientInformation1.LoadInformation(maTiepNhan);
            //Thông tin xét nghiệm
            var objthongtinXetNghiem = _iPatient.Get_Info_BenhNhan_CLS_XetNghiem(maTiepNhan);
            if (objthongtinXetNghiem.Matiepnhan == null) return;
            txtTomTatBenhLi.Text = objthongtinXetNghiem.Tomtatbenhli;
            txtYeuCauXN.Text = objthongtinXetNghiem.Yeucauxetnghiem;
            ricDeNghiTuyDo.Rtf = objthongtinXetNghiem.Denghihuyettuydo;
            ricNhanXetTuyDo.Rtf = objthongtinXetNghiem.Nhanxethuyettuydo;
            ricKetLuanTuyDo.Rtf = objthongtinXetNghiem.Ketluanhuyettuydo;

            ricDeNghiHuyetDo.Rtf = objthongtinXetNghiem.Denghihuyetdo;
            ricNhanXetHuyetDo.Rtf = objthongtinXetNghiem.Nhanxethuyetdo;
            ricKetLuanHuyetDo.Rtf = objthongtinXetNghiem.Ketluanhuyetdo;

            dtpThoiGianLam.Value = objthongtinXetNghiem.Tglamxylocain == null ? DateTime.Now : objthongtinXetNghiem.Tglamxylocain.Value;
            txtBSDocXylocain.Text = objthongtinXetNghiem.Nguoidocxylocain;
            txtKetQuaXylocain.Text = objthongtinXetNghiem.Ketquaxylocain;


            //Chi tiết xét nghiệm
            //Xét nghiem huyết đồ và tế bào học.
            _dtPatient = ucPatientInformation1.DataSource;
            Load_ChiTietXetNghiemHTD();
        }
        private void LoadThongTinBienBan()
        {
            var objthongtinXetNghiem = _iPatient.Get_Info_BenhNhan_CLS_XetNghiem(ucPatientInformation1.MaTiepNhan);
            if (objthongtinXetNghiem.Matiepnhan == null) return;
            ricBienBanChocHutTuyXuong.Rtf = objthongtinXetNghiem.BienBanHTD;
        }
        public void CheckPhanQuyen()
        {
            btnBoXacNhanKQ.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestInValidateResult);
            btnXacNhanKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestValidateResult);
            btnInKetQua.Enabled = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestViewResult);
            //Quyền nhập kết quả
            _allowInsert = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestInsertResult);
            //Quyền sửa kết quả
            _allowEdit = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestEditResult);
            //Quyền sửa kết quả của user khác
            _allowEditResulFromOtherUser = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionEditResultOtherUser);
        }
        private void XacNhanKetQua(bool valid)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes((valid ? "Xác nhận " : "Hủy xác nhận ") + "kết quả?"))
            {
                string validText = (valid
                 ? CommonConstant.IsValided
                 : CommonConstant.InValid);
                string maXn = string.Empty;
                bool alertUnactionHD = false;
                bool alertUnactionTD = false;
                if (gvKetQuaHuyetDo.RowCount > 0)
                {
                    for (int i = 0; i < gvKetQuaHuyetDo.RowCount; i++)
                    {
                        if (gvKetQuaHuyetDo.GetRowCellValue(i, colHuyetDo_MaXn) != null)
                        {
                            var userXacNhan = gvKetQuaHuyetDo.GetRowCellValue(i, colHuyetDo_NguoiXacNhanKQ).ToString().Trim();
                            if (string.IsNullOrEmpty(userXacNhan) || (!valid && userXacNhan.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                            {
                                maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                                maXn += gvKetQuaHuyetDo.GetRowCellValue(i, colHuyetDo_MaXn).ToString();
                            }
                            else if (!valid && !userXacNhan.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                alertUnactionHD = true;
                            }
                        }
                    }
                }
                //if (dtgKetQuaHoaHocTeBao.RowCount > 0)
                //{
                //    for (int i = 0; i < dtgKetQuaHoaHocTeBao.RowCount; i++)
                //    {
                //        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                //        maXn += dtgKetQuaHoaHocTeBao[colTBTenXN.Name, i].Value.ToString();
                //    }
                //}
                if (gvTuyDo.RowCount > 0)
                {
                    for (int i = 0; i < gvTuyDo.RowCount; i++)
                    {
                        if (gvTuyDo.GetRowCellValue(i, colTuyDo_MaXn) != null)
                        {
                            var userXacNhan = gvTuyDo.GetRowCellValue(i, colTuyDo_NguoiXacNhan).ToString().Trim();
                            if (string.IsNullOrEmpty(userXacNhan) || (!valid && userXacNhan.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                            {
                                maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                                maXn += gvTuyDo.GetRowCellValue(i, colTuyDo_MaXn).ToString();
                            }
                            else if (!valid && !userXacNhan.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                alertUnactionTD = true;
                            }
                        }
                    }
                }
                var maXnGet = string.Empty;
                var nguoiXacNhanget = string.Empty;
                if (ricKetLuanHuyetDo.Tag != null)
                {
                    Split_TagInfo(ricKetLuanHuyetDo.Tag.ToString(), ref maXnGet, ref nguoiXacNhanget);

                    if (string.IsNullOrEmpty(nguoiXacNhanget) || (!valid && nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                        maXn += maXnGet;
                    }
                    else if (!valid && !nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        alertUnactionHD = true;
                    }
                }
                if (ricDeNghiHuyetDo.Tag != null)
                {
                    Split_TagInfo(ricDeNghiHuyetDo.Tag.ToString(), ref maXnGet, ref nguoiXacNhanget);

                    if (string.IsNullOrEmpty(nguoiXacNhanget) || (!valid && nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                        maXn += maXnGet;
                    }
                    else if (!valid && !nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        alertUnactionHD = true;
                    }
                }
                if (ricNhanXetHuyetDo.Tag != null)
                {
                    Split_TagInfo(ricNhanXetHuyetDo.Tag.ToString(), ref maXnGet, ref nguoiXacNhanget);

                    if (string.IsNullOrEmpty(nguoiXacNhanget) || (!valid && nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                        maXn += maXnGet;
                    }
                    else if (!valid && !nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        alertUnactionHD = true;
                    }
                }

                if (ricKetLuanTuyDo.Tag != null)
                {
                    Split_TagInfo(ricKetLuanTuyDo.Tag.ToString(), ref maXnGet, ref nguoiXacNhanget);

                    if (string.IsNullOrEmpty(nguoiXacNhanget) || (!valid && nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                        maXn += maXnGet;
                    }
                    else if (!valid && !nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        alertUnactionTD = true;
                    }
                }
                if (ricNhanXetHuyetDo.Tag != null)
                {
                    Split_TagInfo(ricNhanXetHuyetDo.Tag.ToString(), ref maXnGet, ref nguoiXacNhanget);

                    if (string.IsNullOrEmpty(nguoiXacNhanget) || (!valid && nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                        maXn += maXnGet;
                    }
                    else if (!valid && !nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        alertUnactionTD = true;
                    }
                }
                if (ricDeNghiTuyDo.Tag != null)
                {
                    Split_TagInfo(ricDeNghiTuyDo.Tag.ToString(), ref maXnGet, ref nguoiXacNhanget);

                    if (string.IsNullOrEmpty(nguoiXacNhanget) || (!valid && nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        maXn += string.IsNullOrEmpty(maXn) ? "" : ",";
                        maXn += maXnGet;
                    }
                    else if (!valid && !nguoiXacNhanget.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        alertUnactionTD = true;
                    }
                }
                if (alertUnactionHD && alertUnactionTD)
                {
                    CustomMessageBox.MSG_Information_OK("Không thể bỏ duyệt các kết quả đo người khác duyệt!");
                }
                else if (alertUnactionHD)
                {
                    CustomMessageBox.MSG_Information_OK("Không thể bỏ duyệt các kết quả HUYẾT ĐỒ đo người khác duyệt!");
                }
                else if (alertUnactionTD)
                {
                    CustomMessageBox.MSG_Information_OK("Không thể bỏ duyệt các kết quả TỦY ĐỒ đo người khác duyệt!");
                }
                if (!string.IsNullOrEmpty(maXn))
                {
                    _iTestResult.XacNhan_KQ_XN(ucPatientInformation1.MaTiepNhan, maXn, validText, valid
                        , CommonAppVarsAndFunctions.UserID.Trim(), CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
                    Load_ThongTinBenhNhan(ucPatientInformation1.MaTiepNhan);
                }
            }
        }
        private void Split_TagInfo(string tagIn, ref string maXN, ref string nguongXacNhan)
        {
            var arr = tagIn.Split(new string[] { "|^|" }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length > 1)
            {
                maXN = arr[0];
                nguongXacNhan = arr[1];
            }
            else
                maXN = arr[0];
        }
        private void Load_ChiTietXetNghiemHTD()
        {
            string reporttype = string.Empty;

            dataResultBN = _iTestResult.DuLieuKetQua_XN(_dtPatient, 0, false, CommonAppVarsAndFunctions.UserID, string.Empty, false
                , null, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false
                , new TestType.EnumTestType[] { TestType.EnumTestType.HuyetDo
                , TestType.EnumTestType.TuyDo , TestType.EnumTestType.KetLuanHuyetDo
                , TestType.EnumTestType.DeNghiHuyetDo, TestType.EnumTestType.NhanXetHuyetDo
                ,TestType.EnumTestType.KetLuanHuyetTuyDo, TestType.EnumTestType.DeNghiHuyetTuyDo
                , TestType.EnumTestType.NhanXetHuyetTuyDo}
                , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, false);

            var _dtClsKetQua = WorkingServices.SearchResult_OnDatatable(dataResultBN
                , string.Format("LoaiXetNghiem = {0}", (int)TestType.EnumTestType.HuyetDo));

            //    _iTestResult.DuLieuKetQua_XN(_dtPatient, 0, false, CommonAppVarsAndFunctions.UserID,string.Empty,false
            //    ,null, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false
            //    , new TestType.EnumTestType[] { TestType.EnumTestType.HuyetDo }
            //    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, false);
            foreach (DataColumn dc in _dtClsKetQua.Columns)
                dc.ColumnName = dc.ColumnName.ToLower();
            gcKetQuaHuyetDo.DataSource = _dtClsKetQua;

            //var _dtClsKetQuaHoaTebao = new DataTable();
            //_iTestResult.Get_CLS_KetQua_XN(_dtPatient, 0, null, null,
            //     ref _dtClsKetQuaHoaTebao, CommonAppVarsAndFunctions.UserID
            //    , DateTime.Now, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false, new TestType.EnumTestType[] { TestType.EnumTestType.HoaHocTebao }, Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false,string.Empty, false);

            //ControlExtension.BindDataToGrid(_dtClsKetQuaHoaTebao, ref dtgKetQuaHoaHocTeBao, ref bvKetQuaHoaHocTeBao);

            var _dtClsKetQuaHuyetTuyDo = WorkingServices.SearchResult_OnDatatable(dataResultBN
                , string.Format("LoaiXetNghiem = {0}", (int)TestType.EnumTestType.TuyDo));
            //_iTestResult.DuLieuKetQua_XN(_dtPatient, 0, false, CommonAppVarsAndFunctions.UserID, string.Empty, false
            //    , null, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false
            //    , new TestType.EnumTestType[] { TestType.EnumTestType.TuyDo }
            //    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, false);

            foreach (DataColumn dc in _dtClsKetQuaHuyetTuyDo.Columns)
                dc.ColumnName = dc.ColumnName.ToLower();
            gcTuyDo.DataSource = _dtClsKetQuaHuyetTuyDo;

            var dtClsKetQuaKetLuanHuyetDo = WorkingServices.SearchResult_OnDatatable(dataResultBN
                , string.Format("LoaiXetNghiem = {0} or LoaiXetNghiem = {1} or LoaiXetNghiem = {2}"
                    , (int)TestType.EnumTestType.KetLuanHuyetDo, (int)TestType.EnumTestType.DeNghiHuyetDo, (int)TestType.EnumTestType.NhanXetHuyetDo));

            //_iTestResult.DuLieuKetQua_XN(_dtPatient, 0, false, CommonAppVarsAndFunctions.UserID, string.Empty, false
            //    , null, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false
            //     , new[] { TestType.EnumTestType.KetLuanHuyetDo, TestType.EnumTestType.DeNghiHuyetDo, TestType.EnumTestType.NhanXetHuyetDo }
            //    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, false);

            ricKetLuanHuyetDo.Tag = null;
            ricNhanXetHuyetDo.Tag = null;
            ricDeNghiHuyetDo.Tag = null;
            if (dtClsKetQuaKetLuanHuyetDo != null)
            {
                foreach (DataRow drHd in dtClsKetQuaKetLuanHuyetDo.Rows)
                {
                    var id = (TestType.EnumTestType)Enum.Parse(typeof(TestType.EnumTestType), drHd["LoaiXetnghiem"].ToString());
                    if (id == TestType.EnumTestType.KetLuanHuyetDo)
                    {
                        ricKetLuanHuyetDo.Enabled = !bool.Parse(drHd["XacNhanKQ"].ToString());
                        ricKetLuanHuyetDo.Tag = string.Format("{0}|^|{1}", drHd["MaXN"].ToString(), drHd["NguoiXacNhan"].ToString());
                    }
                    else if (id == TestType.EnumTestType.NhanXetHuyetDo)
                    {
                        ricNhanXetHuyetDo.Enabled = !bool.Parse(drHd["XacNhanKQ"].ToString());
                        ricNhanXetHuyetDo.Tag = string.Format("{0}|^|{1}", drHd["MaXN"].ToString(), drHd["NguoiXacNhan"].ToString());
                    }
                    else if (id == TestType.EnumTestType.DeNghiHuyetDo)
                    {
                        ricDeNghiHuyetDo.Enabled = !bool.Parse(drHd["XacNhanKQ"].ToString());
                        ricDeNghiHuyetDo.Tag = string.Format("{0}|^|{1}", drHd["MaXN"].ToString(), drHd["NguoiXacNhan"].ToString());
                    }
                }
            }
            var dtClsKetQuaKetLuanHuyetTuyDo = WorkingServices.SearchResult_OnDatatable(dataResultBN
                , string.Format("LoaiXetNghiem = {0} or LoaiXetNghiem = {1} or LoaiXetNghiem = {2}"
                    , (int)TestType.EnumTestType.KetLuanHuyetTuyDo
                    , (int)TestType.EnumTestType.DeNghiHuyetTuyDo
                    , (int)TestType.EnumTestType.NhanXetHuyetTuyDo));
            //_iTestResult.DuLieuKetQua_XN(_dtPatient, 0, false, CommonAppVarsAndFunctions.UserID, string.Empty, false
            //    , null, CommonAppVarsAndFunctions.UserWorkPlace, reporttype, false
            //    , new[] { TestType.EnumTestType.KetLuanHuyetTuyDo, TestType.EnumTestType.DeNghiHuyetTuyDo, TestType.EnumTestType.NhanXetHuyetTuyDo }
            //    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, false);

            ricKetLuanTuyDo.Tag = null;
            ricNhanXetTuyDo.Tag = null;
            ricDeNghiTuyDo.Tag = null;
            if (dtClsKetQuaKetLuanHuyetTuyDo != null)
            {
                foreach (DataRow drHd in dtClsKetQuaKetLuanHuyetTuyDo.Rows)
                {
                    var id = (TestType.EnumTestType)Enum.Parse(typeof(TestType.EnumTestType), drHd["LoaiXetnghiem"].ToString());
                    if (id == TestType.EnumTestType.KetLuanHuyetTuyDo)
                    {
                        ricKetLuanTuyDo.Enabled = !bool.Parse(drHd["XacNhanKQ"].ToString());
                        ricKetLuanTuyDo.Tag = string.Format("{0}|^|{1}", drHd["MaXN"].ToString(), drHd["NguoiXacNhan"].ToString()); 
                    }
                    else if (id == TestType.EnumTestType.NhanXetHuyetTuyDo)
                    {
                        ricNhanXetTuyDo.Enabled = !bool.Parse(drHd["XacNhanKQ"].ToString());
                        ricNhanXetTuyDo.Tag = string.Format("{0}|^|{1}", drHd["MaXN"].ToString(), drHd["NguoiXacNhan"].ToString());
                    }
                    else if (id == TestType.EnumTestType.DeNghiHuyetTuyDo)
                    {
                        ricDeNghiTuyDo.Enabled = !bool.Parse(drHd["XacNhanKQ"].ToString());
                        ricDeNghiTuyDo.Tag = string.Format("{0}|^|{1}", drHd["MaXN"].ToString(), drHd["NguoiXacNhan"].ToString());
                    }
                }
            }
        }
        private void CapNhat_ThongTinHuyetDo()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu kết quả?"))
            {
                var objthongtinXetNghiem = _iPatient.Get_Info_BenhNhan_CLS_XetNghiem(ucPatientInformation1.MaTiepNhan);
                objthongtinXetNghiem.Tomtatbenhli = txtTomTatBenhLi.Text;
                objthongtinXetNghiem.Yeucauxetnghiem = txtYeuCauXN.Text;
                objthongtinXetNghiem.Denghihuyettuydo = ricDeNghiTuyDo.Rtf;
                objthongtinXetNghiem.Nhanxethuyettuydo = ricNhanXetTuyDo.Rtf;
                objthongtinXetNghiem.Ketluanhuyettuydo = ricKetLuanTuyDo.Rtf;

                objthongtinXetNghiem.Denghihuyetdo = ricDeNghiHuyetDo.Rtf;
                objthongtinXetNghiem.Nhanxethuyetdo = ricNhanXetHuyetDo.Rtf;
                objthongtinXetNghiem.Ketluanhuyetdo = ricKetLuanHuyetDo.Rtf;


                objthongtinXetNghiem.DenghihuyettuydoText = ricDeNghiTuyDo.Text;
                objthongtinXetNghiem.NhanxethuyettuydoText = ricNhanXetTuyDo.Text;
                objthongtinXetNghiem.KetluanhuyettuydoText = ricKetLuanTuyDo.Text;

                objthongtinXetNghiem.DenghihuyetdoText = ricDeNghiHuyetDo.Text;
                objthongtinXetNghiem.NhanxethuyetdoText = ricNhanXetHuyetDo.Text;
                objthongtinXetNghiem.KetluanhuyetdoText = ricKetLuanHuyetDo.Text;


                objthongtinXetNghiem.Tglamxylocain = dtpThoiGianLam.Value;
                objthongtinXetNghiem.Nguoidocxylocain = txtBSDocXylocain.Text;
                objthongtinXetNghiem.Ketquaxylocain = txtKetQuaXylocain.Text;
                objthongtinXetNghiem.BienBanHTD = (string.IsNullOrEmpty(ricBienBanChocHutTuyXuong.Text) ? string.Empty : ricBienBanChocHutTuyXuong.Rtf);
                if (_iPatient.Update_KetQua_huyetTuyDo(objthongtinXetNghiem))
                {
                    //Cập nhật các kết quả dạng text
                    _iTestResult.CapNhatKetQuaXN_TheoLoaiXN(objthongtinXetNghiem.Matiepnhan, objthongtinXetNghiem.NhanxethuyetdoText, (int)TestType.EnumTestType.NhanXetHuyetDo);
                    _iTestResult.CapNhatKetQuaXN_TheoLoaiXN(objthongtinXetNghiem.Matiepnhan, objthongtinXetNghiem.KetluanhuyetdoText, (int)TestType.EnumTestType.KetLuanHuyetDo);
                    _iTestResult.CapNhatKetQuaXN_TheoLoaiXN(objthongtinXetNghiem.Matiepnhan, objthongtinXetNghiem.DenghihuyetdoText, (int)TestType.EnumTestType.DeNghiHuyetDo);

                    _iTestResult.CapNhatKetQuaXN_TheoLoaiXN(objthongtinXetNghiem.Matiepnhan, objthongtinXetNghiem.NhanxethuyettuydoText, (int)TestType.EnumTestType.NhanXetHuyetTuyDo);
                    _iTestResult.CapNhatKetQuaXN_TheoLoaiXN(objthongtinXetNghiem.Matiepnhan, objthongtinXetNghiem.KetluanhuyettuydoText, (int)TestType.EnumTestType.KetLuanHuyetTuyDo);
                    _iTestResult.CapNhatKetQuaXN_TheoLoaiXN(objthongtinXetNghiem.Matiepnhan, objthongtinXetNghiem.DenghihuyettuydoText, (int)TestType.EnumTestType.DeNghiHuyetTuyDo);
                }

                Load_ThongTinBenhNhan(objthongtinXetNghiem.Matiepnhan);
                Load_ChiTietXetNghiemHTD();
            }
        }
        private void LuuBienBanHTD()
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu biên bản"))
            {
                var objthongtinXetNghiem = _iPatient.Get_Info_BenhNhan_CLS_XetNghiem(ucPatientInformation1.MaTiepNhan);
                objthongtinXetNghiem.BienBanHTD = (string.IsNullOrEmpty(ricBienBanChocHutTuyXuong.Text) ? string.Empty : ricBienBanChocHutTuyXuong.Rtf);
                _iPatient.Update_KetQua_huyetTuyDo(objthongtinXetNghiem);
            }
        }
        private void LoadDSThongTinBenhNhan()
        {
            gcDSTiepNhan.DataSource = null;
            gcKetQuaHuyetDo.DataSource = null;
            gcTuyDo.DataSource = null;
            gcKetQuaSinhThiet.DataSource = null;

            gvDSTiepNhan.FocusedRowChanged -= GvDSTiepNhan_FocusedRowChanged;
            DataTable dataTiepNhan = new DataTable();
            if (radCheDoSHS.Checked)
            {
                dataTiepNhan = _iPatient.DanhSach_MaTiepNhan_TheoSHS(txtTimBenhNhan.Text);
            }
            else
            {
                dataTiepNhan = _iPatient.DanhSach_MaTiepNhan_TheoBarcode(txtTimBenhNhan.Text);
            }
            gcDSTiepNhan.DataSource = dataTiepNhan;
            gvDSTiepNhan.FocusedRowChanged += GvDSTiepNhan_FocusedRowChanged;
            if (gvDSTiepNhan.FocusedRowHandle > -1)
            {
                if (gvDSTiepNhan.GetFocusedRowCellValue(colDSTiepNhan_MaTiepNhan) != null)
                {
                    var maTiepNhan = gvDSTiepNhan.GetFocusedRowCellValue(colDSTiepNhan_MaTiepNhan).ToString();
                    Load_ThongTinBenhNhan(maTiepNhan);
                    LoadThongTinBienBan();
                    Load_KetQuaSinhThiet();
                }
            }
        }
        private void GvDSTiepNhan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gcDSTiepNhan.DataSource = null;
            gcKetQuaHuyetDo.DataSource = null;
            gcTuyDo.DataSource = null;
            gcKetQuaSinhThiet.DataSource = null;
            if (gvDSTiepNhan.GetFocusedRowCellValue(colDSTiepNhan_MaTiepNhan) != null)
            {
                var maTiepNhan = gvDSTiepNhan.GetFocusedRowCellValue(colDSTiepNhan_MaTiepNhan).ToString();
                Load_ThongTinBenhNhan(maTiepNhan);
                LoadThongTinBienBan();
                Load_KetQuaSinhThiet();
            }
        }
        private void FrmCLS_KetQua_HuyetTuyDo_Load(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterResult, false);
            Configuration.Services.SystemConfig.ISystemConfigService _systemConfig = new Configuration.Services.SystemConfig.SystemConfigService();
           
            var currentUserSign = CommonAppVarsAndFunctions.TempSignIdXetNghiem;
            ControlExtension.BindDataToCobobox(_userManagement.GetUsersByConditions("", true), ref cboNguoiKyTen, "MaNguoiDung", "MaNguoiDung", "MaNguoiDung, TenNhanVien", "50,150", txtNguoiKyTen, 1);
            if (!string.IsNullOrEmpty(currentUserSign))
                CommonAppVarsAndFunctions.TempSignIdXetNghiem = currentUserSign;
            else
                cboNguoiKyTen.SelectedValue = CommonAppVarsAndFunctions.UserID;
            //dtpNgayTiepNhan.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpThoiGianLam.Value = CommonAppVarsAndFunctions.ServerTime;
           // chkPrintTitle.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryPrintTitle).Equals("1");
            reportLogo = _isSysConfig.Load_Logo("XN");

            ucPatientInformation1.Load_DanhMucCauHinh();
            Set_ColumnDataPropertyLoweCase();
            //Lấy dữ liệu khi gọi từ form khác
            if (!string.IsNullOrEmpty(inputMatiepnhan))
            {
                txtTimBenhNhan.Text = inputMatiepnhan.Split('.')[1];
                LoadDSThongTinBenhNhan();
            }
            radCheDoSHS.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo;
            if (!radCheDoSHS.Visible)
                radCheDoBarcode.Checked = true;
            CheckPhanQuyen();
            txtTimBenhNhan.Focus();
        }
        private void btnDanhGiaHuyetTuyDO_Click(object sender, EventArgs e)
        {
            CapNhat_ThongTinHuyetDo();
        }
        private void btnNhanXetHuyetDo_Click(object sender, EventArgs e)
        {
            var f = new FrmDanhMuc_ChonBieuMau();
            f.LoaiBieuMau = new TemplateInput.EnumTemplateInput[] { TemplateInput.EnumTemplateInput.NhanXetHuyetDo, TemplateInput.EnumTemplateInput.KetLuanHuyetDo, TemplateInput.EnumTemplateInput.DeNghiHuyetDo };
            f.FromResult = true;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            if (f.noidungChon != null)
            {
                for (int i = 0; i < f.noidungChon.Length / 2; i++)
                {
                    var idloaiMau = f.noidungChon[i, 0];
                    var noidung = f.noidungChon[i, 1];
                    Check_SetHuyetDo(idloaiMau, noidung);
                }
            }
        }
        private void Check_SetHuyetDo(string id, string noidung)
        {
            var checkId = (TemplateInput.EnumTemplateInput)Enum.Parse(typeof(TemplateInput.EnumTemplateInput), id);
            if (checkId == TemplateInput.EnumTemplateInput.NhanXetHuyetDo)
            {
                Check_AppendText(noidung,ref ricNhanXetHuyetDo);
            }
            else if (checkId == TemplateInput.EnumTemplateInput.DeNghiHuyetDo)
            {
                Check_AppendText(noidung, ref ricDeNghiHuyetDo);
            }
            else if (checkId == TemplateInput.EnumTemplateInput.KetLuanHuyetDo)
            {
                Check_AppendText(noidung,ref  ricKetLuanHuyetDo);
            }
        }
        private void Check_SetTuyDo(string id, string noidung)
        {
            var checkId = (TemplateInput.EnumTemplateInput)Enum.Parse(typeof(TemplateInput.EnumTemplateInput), id);
            if (checkId == TemplateInput.EnumTemplateInput.NhanXetTuyDo)
            {
                Check_AppendText(noidung,ref ricNhanXetTuyDo);
            }
            else if (checkId == TemplateInput.EnumTemplateInput.DeNghiTuyDo)
            {
                Check_AppendText(noidung,ref ricDeNghiTuyDo);
            }
            else if (checkId == TemplateInput.EnumTemplateInput.KetLuanTuyDo)
            {
                Check_AppendText(noidung,ref ricKetLuanTuyDo);
            }
        }
        private void Check_AppendText(string noidung, TextBox txt)
        {
            txt.Text += (string.IsNullOrEmpty(txt.Text) ? "" : Environment.NewLine) + noidung;
        }
        private void Check_AppendText(string noidung,ref RicherTextBox.RicherTextBox txt)
        {
            var ric = new RichTextBox();
            ric.Rtf = txt.Rtf;

            ric.Select(ric.TextLength, 0);
            ric.SelectedRtf = noidung;
            txt.Rtf = ric.Rtf;
        }
        private void btnNhanXetTuyDo_Click(object sender, EventArgs e)
        {
            var f = new FrmDanhMuc_ChonBieuMau();
            f.LoaiBieuMau = new TemplateInput.EnumTemplateInput[] 
            {
                TemplateInput.EnumTemplateInput.NhanXetTuyDo
                , TemplateInput.EnumTemplateInput.KetLuanTuyDo
                , TemplateInput.EnumTemplateInput.DeNghiTuyDo
            };
            f.FromResult = true;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            if (f.noidungChon != null)
            {
                for (int i = 0; i < f.noidungChon.Length / 2; i++)
                {
                    var idloaiMau = f.noidungChon[i, 0];
                    var noidung = f.noidungChon[i, 1];
                    Check_SetTuyDo(idloaiMau, noidung);
                }
            }
        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(CommonAppVarsAndFunctions.LstPrinter, UserConstant.RegistryPrinterResult, true);
            LoadPrinterList();
        }
        private void LoadPrinterList()
        {
            LabServices_Helper.LoadPrinterName(listPrinter, UserConstant.RegistryPrinterResult, false);
        }

        private void btnInKetQua_Click(object sender, EventArgs e)
        {
            var userSign = cboNguoiKyTen.SelectedIndex > -1 ? cboNguoiKyTen.SelectedValue.ToString().Trim() : CommonAppVarsAndFunctions.UserID;
            if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                return;
            }
            var kyTen = string.Empty;
            if (cboNguoiKyTen.SelectedIndex > -1)
                kyTen = cboNguoiKyTen.SelectedValue.ToString();
            else
                kyTen = CommonAppVarsAndFunctions.UserID;


            var printerName = string.Empty;
            if (listPrinter.Items.Count > 0)
            {
                if (listPrinter.SelectedIndex == -1)
                {
                    listPrinter.SelectedIndex = 0;
                }
                printerName = listPrinter.SelectedItem.ToString();
            }
            string headerFlat = "XN";
            var havePrintHuyetDo = false;
            var havePrintTuyDo = false;
            if (gvTuyDo.RowCount > 0)
            {
                var f = new FrmPreViewReport();
                var dataTuyDo = _iTestResult.DuLieuIn_XN(_dtPatient, 0, false
                                                    , kyTen
                                                    , string.Empty
                                                    , true, DateTime.Now
                                                    , CommonAppVarsAndFunctions.UserWorkPlace
                                                    , ReportResultTemplateConstant.Mau_BYT_29BV01
                                                    , false, new TestType.EnumTestType[] { TestType.EnumTestType.HuyetDo, TestType.EnumTestType.TuyDo}
                                                    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), true, true, huyetDo: true);

                var lstIdChiDinhHIS = new List<string>();
                var conditSomeTestPrint = new List<string>();
                foreach (DataRow dataRow in dataTuyDo.Rows)
                {
                    if (!lstIdChiDinhHIS.Where(x => x.Equals(dataRow["IdChiDinhHis"].ToString(), StringComparison.OrdinalIgnoreCase)).Any())
                        lstIdChiDinhHIS.Add(dataRow["IdChiDinhHis"].ToString());
                    if (!conditSomeTestPrint.Where(x => x.Equals(dataRow["MaXN"].ToString(), StringComparison.OrdinalIgnoreCase)).Any())
                        conditSomeTestPrint.Add(dataRow["MaXN"].ToString());
                }
                var dataTuyDoPrint = _iTestResult.ConvertDataResultPrintFrom_RowToColumn(dataTuyDo, string.Empty);
               

                if (dataTuyDoPrint.Rows.Count > 0)
                {
                    var resultReportInfo = new ReportModel();
                    var reportTemplateID = dataTuyDoPrint.Rows[0]["IDMauKetQua"].ToString();
                    resultReportInfo = GetReportFromConfig(reportTemplateID);
                    if (resultReportInfo == null)
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Phiếu in của mẫu: \"{0}\" chưa được khai báo.", reportTemplateID));
                        return;
                    }
                    headerFlat = "XNBYT";
                    if (!dataTuyDoPrint.Columns.Contains("ReportLogo"))
                        dataTuyDoPrint.Columns.Add("ReportLogo", typeof(byte[]));

                    foreach (DataRow dr in dataTuyDoPrint.Rows)
                    {
                        dr["ReportLogo"] = GraphicSupport.ImageToByteArray(reportLogo);
                    }

                    f.SampleID = string.Format("Ketqua_{0}_{1}", "Mau_BYT_29BV01_TD", dataTuyDoPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
                    f.lstIDChiDinhHis = lstIdChiDinhHIS;
                    f.conditSomeTestPrint = string.Join(",", conditSomeTestPrint);
                    f.TenBN = dataTuyDoPrint.Rows[0]["TenBN"].ToString().Trim();
                    f.InMau = false;
                    f.UserSign = kyTen;
                    var rpPrint = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    havePrintTuyDo = f.ShowReport(rpPrint, dataTuyDoPrint, !chkPrintPreview.Checked, printerName, "XN", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);
                }
                if (havePrintTuyDo)
                {
                    string categoryPrint = string.Empty;
                    var dataDistincCategory = dataTuyDo.AsDataView().ToTable(true, new string[] { "manhomcls" });
                    foreach (DataRow drC in dataDistincCategory.Rows)
                    {
                        categoryPrint += (string.IsNullOrEmpty(categoryPrint) ? "" : ",") + string.Format("{0}", drC["manhomcls"].ToString());
                    }
                    //var conditSomeTestPrint = string.Empty;
                    //foreach (DataRow dr in dataTuyDo.Rows)
                    //{
                    //    conditSomeTestPrint += string.IsNullOrEmpty(conditSomeTestPrint) ? "" : ",";
                    //    conditSomeTestPrint += dr["MaXN"].ToString().Trim();
                    //}

                    _iTestResult.CapNhatPrintOut_WithoutReportType(dataTuyDo.Rows[0]["MaTiepNhan"].ToString().Trim()
                        , string.Join(",", conditSomeTestPrint), categoryPrint, true, CommonAppVarsAndFunctions.UserID, string.Empty
                        , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, kyTen, CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);

                    _iTestResult.CapNhat_In_KQ_XN(dataTuyDo.Rows[0]["MaTiepNhan"].ToString().Trim(), CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan);
                    _iTestResult.UpdatePrintOutCategory(dataTuyDo.Rows[0]["MaTiepNhan"].ToString().Trim(), categoryPrint, true, CommonAppVarsAndFunctions.UserID);
                }
            }
            else if (gvKetQuaHuyetDo.RowCount > 0)
            {
                var dataHuyetDo = _iTestResult.DuLieuIn_XN(_dtPatient, 0, false
                    , kyTen
                    , string.Empty
                    , chkPrintTitle.Checked, DateTime.Now
                    , CommonAppVarsAndFunctions.UserWorkPlace
                    , ReportResultTemplateConstant.Mau_BYT_29BV01
                    , false, new TestType.EnumTestType[] { TestType.EnumTestType.ThongThuong, TestType.EnumTestType.HuyetDo }
                    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, true, string.Empty, true, huyetDo: true, idLoaiXnHuyetDo: TestType.EnumTestType.HuyetDo);

                string exportFileName = string.Empty;

                var dataHuyetDoPrint = _iTestResult.ConvertDataResultPrintFrom_RowToColumn(dataHuyetDo, string.Empty);
                var f = new FrmPreViewReport();

                if (dataHuyetDoPrint.Rows.Count > 0)
                {
                    var resultReportInfo = new ReportModel();
                    var reportTemplateID = dataHuyetDoPrint.Rows[0]["IDMauKetQua"].ToString();
                    resultReportInfo = GetReportFromConfig(reportTemplateID);
                    if (resultReportInfo == null)
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Phiếu in của mẫu: \"{0}\" chưa được khai báo.", reportTemplateID));
                        return;
                    }
                    if (!dataHuyetDoPrint.Columns.Contains("ReportLogo"))
                        dataHuyetDoPrint.Columns.Add("ReportLogo", typeof(byte[]));

                    foreach (DataRow dr in dataHuyetDoPrint.Rows)
                    {
                        dr["ReportLogo"] = GraphicSupport.ImageToByteArray(reportLogo); ;
                    }
                    

                    f.SampleID = string.Format("Ketqua_{0}_{1}", "Mau_BYT_29BV01_HD", dataHuyetDoPrint.Rows[0]["MaTiepNhan"].ToString().Trim());

                    f.TenBN = dataHuyetDoPrint.Rows[0]["TenBN"].ToString().Trim();
                    f.InMau = false;
                    f.UserSign = kyTen;
                    var rpPrint = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    havePrintHuyetDo = f.ShowReport(rpPrint, dataHuyetDoPrint, !chkPrintPreview.Checked, printerName, "XN", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);

                    if (havePrintHuyetDo)
                    {
                        string categoryPrint = string.Empty;
                        var dataDistincCategory = dataHuyetDo.AsDataView().ToTable(true, new string[] { "manhomcls" });
                        foreach (DataRow drC in dataDistincCategory.Rows)
                        {
                            categoryPrint += (string.IsNullOrEmpty(categoryPrint) ? "" : ",") + string.Format("{0}", drC["manhomcls"].ToString());
                        }
                        var conditSomeTestPrint = string.Empty;
                        foreach (DataRow dr in dataHuyetDo.Rows)
                        {
                            conditSomeTestPrint += string.IsNullOrEmpty(conditSomeTestPrint) ? "" : ",";
                            conditSomeTestPrint += dr["MaXN"].ToString().Trim();
                        }

                        _iTestResult.CapNhatPrintOut_WithoutReportType(dataHuyetDo.Rows[0]["MaTiepNhan"].ToString().Trim()
                            , conditSomeTestPrint, categoryPrint, true, CommonAppVarsAndFunctions.UserID, string.Empty
                            , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, kyTen, CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);

                        _iTestResult.CapNhat_In_KQ_XN(dataHuyetDo.Rows[0]["MaTiepNhan"].ToString().Trim(), CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan);
                        _iTestResult.UpdatePrintOutCategory(dataHuyetDo.Rows[0]["MaTiepNhan"].ToString().Trim(), categoryPrint, true, CommonAppVarsAndFunctions.UserID);
                    }
                }

            }
           
        }
        private void Set_ColumnDataPropertyLoweCase()
        {
            for (var i = 0; i < gvKetQuaHuyetDo.Columns.Count; i++)
            {
                var col = gvKetQuaHuyetDo.Columns[i];
                col.FieldName = col.FieldName.ToLower().Trim();
            }
            for (var c = 0; c < gvTuyDo.Columns.Count; c++)
            {
                var col = gvTuyDo.Columns[c];
                col.FieldName = col.FieldName.ToLower().Trim();
            }
        }

        private void btnChonMauKetLuanHD_Click(object sender, EventArgs e)
        {
            var f = new FrmDanhMuc_ChonBieuMau();
            f.LoaiBieuMau = new TemplateInput.EnumTemplateInput[] {TemplateInput.EnumTemplateInput.KetLuanHuyetDo };
            f.FromResult = true;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            if (f.noidungChon != null)
            {
                for (int i = 0; i < f.noidungChon.Length / 2; i++)
                {
                    var idloaiMau = f.noidungChon[i, 0];
                    var noidung = f.noidungChon[i, 1];
                    Check_SetHuyetDo(idloaiMau, noidung);
                }
            }
        }

        private void btnXacNhanKetQua_Click(object sender, EventArgs e)
        {
            XacNhanKetQua(true);
        }

        private void btnBoXacNhanKQ_Click(object sender, EventArgs e)
        {
            XacNhanKetQua(false);
        }

        private void txtTimBenhNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTimBenhNhan.Text = WorkingServices.GetBarcodeInString(txtTimBenhNhan.Text, int.Parse(CommonAppVarsAndFunctions.sysConfig.BenhNhanSoKyTuBarCode));
                LoadDSThongTinBenhNhan();
            }
           
        }
        private HorzAlignment GetHorzAlignmentChoKetQua(string ketQua)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 3 || CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 4)
            {
                if (WorkingServices.IsNumeric(ketQua))
                {
                    return (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 3 ? HorzAlignment.Far : HorzAlignment.Near);
                }
                else
                {
                    return (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 3 ? HorzAlignment.Near : HorzAlignment.Far);
                }
            }
            else if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 1)
            {
                return HorzAlignment.Center; //bên trái
            }
            else if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhLeKetQuaTrenLuoi == 1)
            {
                return HorzAlignment.Far; //bên phải
            }
            else
            {
                return HorzAlignment.Near;
            }
        }
        private void gvKetQuaHuyetDo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            e.Appearance.Font = new Font("Arial", 9, FontStyle.Regular);
            
            if (e.Column.FieldName.Equals(colHuyetDo_TenXetNghiem.FieldName, StringComparison.OrdinalIgnoreCase))
            {
                var rVal = view.GetRowCellValue(e.RowHandle, view.Columns[colHuyetDo_XnChinh.FieldName]);
                var value = bool.Parse(rVal == null ? "false" : rVal.ToString());
                if (value)
                {
                    e.Appearance.Font = new Font("Arial", 9, FontStyle.Bold);
                }
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns[colHuyetDo_XacNhanKQ.FieldName]))
                {
                    ricBienBanChocHutTuyXuong.Enabled = false;
                    btnLuuBienBan.Enabled = false;
                    btnMauHutTuyXuong.Enabled = false;
                }
                else
                {
                    ricBienBanChocHutTuyXuong.Enabled = true;
                    btnLuuBienBan.Enabled = false;
                    btnMauHutTuyXuong.Enabled = false;
                }
            }

            if (e.Column == colHuyetDo_KetQua)
            {
                if (view.GetRowCellValue(e.RowHandle, view.Columns[colHuyetDo_Flag.FieldName]) == null) return;
                var flag = (int)view.GetRowCellValue(e.RowHandle, view.Columns[colHuyetDo_Flag.FieldName]);
                var fs = new FontStyle();
                //1:
                var color = LabResultService.MauKQ(flag, ref fs);
                var font = new Font(e.Appearance.Font.Name, 9, fs);
                e.Appearance.Font = font;
                e.Appearance.ForeColor = color;
                e.Appearance.TextOptions.HAlignment = GetHorzAlignmentChoKetQua(view.GetRowCellValue(e.RowHandle, view.Columns[colHuyetDo_KetQua.FieldName]).ToString());
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns[colHuyetDo_XacNhanKQ.FieldName]))
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }

        private void gvKetQuaHuyetDo_ShowingEditor(object sender, CancelEventArgs e)
        {
            var rowHandle = ((ColumnView)gcKetQuaHuyetDo.FocusedView).FocusedRowHandle;
            var colhandle = ((ColumnView)gcKetQuaHuyetDo.FocusedView).FocusedColumn;
            if (colhandle.Name != colHuyetDo_KetQua.Name) return;
            var daXacNhan = (bool)gvKetQuaHuyetDo.GetRowCellValue(rowHandle, colHuyetDo_XacNhanKQ);
            var userNhap = gvKetQuaHuyetDo.GetRowCellValue(rowHandle, colHuyetDo_NguoiNhap).ToString();

            if (!AllowEditCurrentRow(userNhap, daXacNhan))
            {
                e.Cancel = true;
            }
        }
        private bool AllowEditCurrentRow(string userNhapKq, bool daXacNhan)
        {
            if (daXacNhan)
                return false;
            else
            {
                if (_allowInsert && string.IsNullOrWhiteSpace(userNhapKq))
                {
                    //Đảm bảo user có quyền nhập và vị trí chưa nhập kết quả lần nào
                    return true;
                }
                else if (_allowEdit)
                {
                    if (userNhapKq.Equals(CommonAppVarsAndFunctions.UserID, StringComparison.OrdinalIgnoreCase) || _allowEditResulFromOtherUser)
                        //Đảm bảo user có quyền sửa và vị trí có kết quả đã nhập
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        private string _currentValueHD = string.Empty;
        private void gvKetQuaHuyetDo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals(colHuyetDo_KetQua.Name, StringComparison.OrdinalIgnoreCase))
            {
                var newValue = (e.Value ?? string.Empty);
                if (!newValue.Equals(_currentValueHD))
                {
                    UpdateResult_HuyetDo(e.RowHandle, false);
                }
            }
        }

        private void gvKetQuaHuyetDo_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (gvKetQuaHuyetDo.RowCount == 0)
            {
                _currentValueHD = string.Empty;
            }
            else if (e.Column.Name.Equals(colHuyetDo_KetQua.Name, StringComparison.OrdinalIgnoreCase))
            {
                _currentValueHD = gvKetQuaHuyetDo.GetRowCellValue(e.RowHandle, colHuyetDo_KetQua).ToString().Trim();
            }
        }
        private void UpdateResult_TuyDo(int rowIndex, bool fromAuto)
        {
            if (gvTuyDo.RowCount == 0)
                return;
            var log = string.Empty;
            try
            {
                log = "Lấy các giá trị";
                log += Environment.NewLine + "     _indexKQ";
                //var indexKq = 3;
                log += Environment.NewLine + "     _KetQua";
                var ketQuaMau = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_KetQua) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_KetQua).ToString().Trim()
                    : string.Empty;
                var ketQuaTuy = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_KetQuaTuy) != null
                  ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_KetQuaTuy).ToString().Trim()
                  : string.Empty;
                log += Environment.NewLine + "     _MaXN";
                var maXn = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_MaXn) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_MaXn).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _GhiChu";
                var ghiChu = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_GhiChu) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_GhiChu).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _NguongTren";
                var nguongTren = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguongTren) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguongTren).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _NguongDuoi";
                var nguongDuoi = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguongDuoi) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguongDuoi).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _DieuKienBatThuong";
                var dieuKienBatThuong = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_DKBatThuong) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_DKBatThuong).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _Co";
                var flag = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_Flag) != null
                    ? int.Parse(gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_Flag).ToString())
                    : 0;
                log += Environment.NewLine + "     _UserNhap";
                var userNhap = gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguoiNhap) != null
                    ? gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguoiNhap).ToString().Trim()
                    : string.Empty;

                var lamtron = string.Empty;

                log += Environment.NewLine + "Thực hiện kiểm tra đánh giá khi nhập hoặc sửa kết quả";
                log += Environment.NewLine + "Đánh giá kết quả";

                var maTiepNhan = ucPatientInformation1.MaTiepNhan;

                flag = LabResultService.SetColor(ketQuaMau, nguongTren, nguongDuoi, dieuKienBatThuong);
                var objResult = new KetQuaHuyetTuyDo
                {
                    Matiepnhan = maTiepNhan,
                    Maxn = maXn,
                    Ketqua = ketQuaMau,
                    Ketquatuy = ketQuaTuy,
                    Ghichu = String.Empty,
                    Flag = flag,
                    Userluu = CommonAppVarsAndFunctions.UserID,
                    SuaKetQua = !string.IsNullOrEmpty(userNhap),
                    Idmayxetnghiem = 0,
                    Uploadweb = false
                };

                _iTestResult.CapNhat_KQ_XN_TuyDo(objResult);
                _iTestResult.CapNhat_CSBT(maTiepNhan, maXn, "0", true);

                if (!fromAuto)
                {
                    if (string.IsNullOrEmpty(gvTuyDo.GetRowCellValue(rowIndex, colTuyDo_NguoiNhap).ToString()))
                    {
                        gvTuyDo.SetRowCellValue(rowIndex, colTuyDo_NguoiNhap, CommonAppVarsAndFunctions.UserID);
                        gvTuyDo.SetRowCellValue(rowIndex, colTuyDo_TgNhap, CommonAppVarsAndFunctions.ServerTime);
                    }
                    else
                    {
                        gvTuyDo.SetRowCellValue(rowIndex, colTuyDo_NguoiSua, CommonAppVarsAndFunctions.UserID);
                        gvTuyDo.SetRowCellValue(rowIndex, colTuyDo_TGSua, CommonAppVarsAndFunctions.ServerTime);
                    }

                    gvTuyDo.SetRowCellValue(rowIndex, colTuyDo_Flag, flag);
                    //  gvTuyDo.SetRowCellValue(rowIndex, colmaythuchien, userNhap);
                    _iTestResult.CapNhat_DuKQ_XN(maTiepNhan);
                    _iTestResult.CapNhat_ThongTinMayXn_XnChinh(maTiepNhan);
                    gvTuyDo.CellValueChanged -= gvTuyDo_CellValueChanged;
                    gvTuyDo.SetRowCellValue(rowIndex, colTuyDo_GhiChu, _iTestResult.Get_GhiChuCuaXetNghiem(maTiepNhan, maXn));
                    gvTuyDo.CellValueChanged += gvTuyDo_CellValueChanged;
                }
                _currentValueTD = string.Empty;
            }
            catch (Exception ex)
            {
                LabServices_Helper.RecordError(log);
                ErrorService.GetFrameworkErrorMessage(ex, "CapNhatKQTuyDo_KiemTraHienthi", CommonAppVarsAndFunctions.UserID);
            }
        }
        private void UpdateResult_HuyetDo(int rowIndex, bool fromAuto)
        {
            if (gvKetQuaHuyetDo.RowCount == 0)
                return;
            var log = string.Empty;
            try
            {
                log = "Lấy các giá trị";
                log += Environment.NewLine + "     _indexKQ";
                //var indexKq = 3;
                log += Environment.NewLine + "     _KetQua";
                var ketQua = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_KetQua) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_KetQua).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _MaXN";
                var maXn = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_MaXn) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_MaXn).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _GhiChu";
                var ghiChu = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_GhiChu) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_GhiChu).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _NguongTren";
                var nguongTren = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguongTren) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguongTren).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _NguongDuoi";
                var nguongDuoi = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguongDuoi) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguongDuoi).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _DieuKienBatThuong";
                var dieuKienBatThuong = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_DKBatThuong) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_DKBatThuong).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _Co";
                var flag = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_Flag) != null
                    ? int.Parse(gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_Flag).ToString())
                    : 0;
                log += Environment.NewLine + "     _UserNhap";
                var userNhap = gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguoiNhap) != null
                    ? gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguoiNhap).ToString().Trim()
                    : string.Empty;

                var lamtron = string.Empty;

                log += Environment.NewLine + "Thực hiện kiểm tra đánh giá khi nhập hoặc sửa kết quả";
                log += Environment.NewLine + "Đánh giá kết quả";

                var maTiepNhan = ucPatientInformation1.MaTiepNhan;

                flag = LabResultService.SetColor(ketQua, nguongTren, nguongDuoi, dieuKienBatThuong);
                var obUpdate = new UpdateResultNormalInfo
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
                    userUpdate = CommonAppVarsAndFunctions.UserID
                };
                if (string.IsNullOrEmpty(ketQua))
                {
                    obUpdate.capnhatCoKetQua = true;
                    obUpdate.coKetQua = string.Empty;
                }

                _iTestResult.CapNhat_KQ_XN(obUpdate);

                _iTestResult.CapNhat_CSBT(maTiepNhan, maXn, "0", true);

                if (!fromAuto)
                {
                    if (string.IsNullOrEmpty(gvKetQuaHuyetDo.GetRowCellValue(rowIndex, colHuyetDo_NguoiNhap).ToString()))
                    {
                        gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colHuyetDo_NguoiNhap, CommonAppVarsAndFunctions.UserID);
                        gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colHuyetDo_TGNhap, CommonAppVarsAndFunctions.ServerTime);
                    }
                    else
                    {
                        gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colHuyetDo_NguoiSua, CommonAppVarsAndFunctions.UserID);
                        gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colHuyetDo_TGSua, CommonAppVarsAndFunctions.ServerTime);
                    }

                    gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colHuyetDo_Flag, flag);
                    //  gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colmaythuchien, userNhap);
                    _iTestResult.CapNhat_DuKQ_XN(maTiepNhan);
                    _iTestResult.CapNhat_ThongTinMayXn_XnChinh(maTiepNhan);
                    gvKetQuaHuyetDo.CellValueChanged -= gvKetQuaHuyetDo_CellValueChanged;
                    gvKetQuaHuyetDo.SetRowCellValue(rowIndex, colHuyetDo_GhiChu, _iTestResult.Get_GhiChuCuaXetNghiem(maTiepNhan, maXn));
                    gvKetQuaHuyetDo.CellValueChanged += gvKetQuaHuyetDo_CellValueChanged;
                }

            }
            catch (Exception ex)
            {
                LabServices_Helper.RecordError(log);
                ErrorService.GetFrameworkErrorMessage(ex, "CapNhatKQHuyetDo_KiemTraHienthi", CommonAppVarsAndFunctions.UserID);
            }
        }
        private void repositoryItemMemoEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is MemoEdit)
            {
                var obj = (MemoEdit)sender;
                if (e.Shift && e.KeyCode == Keys.Enter)
                {
                    obj.EditValue += Environment.NewLine;
                    obj.SelectionStart = obj.Text.Length;
                    e.Handled = true;
                }
            }
        }

        private void gcKetQuaHuyetDo_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var currentRow = ((ColumnView)gcKetQuaHuyetDo.FocusedView).FocusedRowHandle;
            ((ColumnView)gcKetQuaHuyetDo.FocusedView).FocusedRowHandle++;
            if (currentRow < ((ColumnView)gcKetQuaHuyetDo.FocusedView).FocusedRowHandle)
                ((ColumnView)gcKetQuaHuyetDo.FocusedView).ShowEditor(); e.Handled = true;
        }

        private void repositoryItemMemoEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is MemoEdit)
            {
                var obj = (MemoEdit)sender;
                if (e.Shift && e.KeyCode == Keys.Enter)
                {
                    obj.EditValue += Environment.NewLine;
                    obj.SelectionStart = obj.Text.Length;
                    e.Handled = true;
                }
            }
        }

        private void gcTuyDo_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var currentRow = ((ColumnView)gcTuyDo.FocusedView).FocusedRowHandle;
            ((ColumnView)gcTuyDo.FocusedView).FocusedRowHandle++;
            if (currentRow < ((ColumnView)gcTuyDo.FocusedView).FocusedRowHandle)
                ((ColumnView)gcTuyDo.FocusedView).ShowEditor(); e.Handled = true;
        }

        private void gvTuyDo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            e.Appearance.Font = new Font("Arial", 9, FontStyle.Regular);
            if (e.Column.FieldName.Equals(colTuyDo_TenXN.FieldName, StringComparison.OrdinalIgnoreCase))
            {
                var rVal = view.GetRowCellValue(e.RowHandle, view.Columns[colTuyDo_XNChinh.FieldName]);
                var value = bool.Parse(rVal == null ? "false" : rVal.ToString());
                if (value)
                {
                    e.Appearance.Font = new Font("Arial", 9, FontStyle.Bold);
                }
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns[colTuyDo_XacNhanKQ.FieldName]))
                {
                    ricBienBanChocHutTuyXuong.Enabled = false;
                    btnLuuBienBan.Enabled = false;
                    btnMauHutTuyXuong.Enabled = false;
                }
                else
                {
                    ricBienBanChocHutTuyXuong.Enabled = true;
                    btnLuuBienBan.Enabled = false;
                    btnMauHutTuyXuong.Enabled = false;
                }
            }
            if (e.Column == colTuyDo_KetQua || e.Column == colTuyDo_KetQuaTuy)
            {
                if (view.GetRowCellValue(e.RowHandle, view.Columns[colTuyDo_Flag.FieldName]) == null) return;
                var flag = (int)view.GetRowCellValue(e.RowHandle, view.Columns[colTuyDo_Flag.FieldName]);
                var fs = new FontStyle();
                //1:
                var color = LabResultService.MauKQ(flag, ref fs);
                var font = new Font(e.Appearance.Font.Name, 9, fs);
                e.Appearance.Font = font;
                e.Appearance.ForeColor = color;
                e.Appearance.TextOptions.HAlignment = GetHorzAlignmentChoKetQua(view.GetRowCellValue(e.RowHandle, view.Columns[colTuyDo_KetQua.FieldName]).ToString());
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns[colTuyDo_XacNhanKQ.FieldName]))
                {
                    e.Appearance.BackColor = Color.LightGray;
                }
            }
        }
        private void gvTuyDo_ShowingEditor(object sender, CancelEventArgs e)
        {
            var rowHandle = ((ColumnView)gcTuyDo.FocusedView).FocusedRowHandle;
            var colhandle = ((ColumnView)gcTuyDo.FocusedView).FocusedColumn;
            if (colhandle.Name != colTuyDo_KetQuaTuy.Name && colhandle.Name != colTuyDo_KetQua.Name) return;
            var daXacNhan = (bool)gvTuyDo.GetRowCellValue(rowHandle, colTuyDo_XacNhanKQ);
            var userNhap = gvTuyDo.GetRowCellValue(rowHandle, colTuyDo_NguoiNhap).ToString();

            if (!AllowEditCurrentRow(userNhap, daXacNhan))
            {
                e.Cancel = true;
            }
        }
        private string _currentValueTD = string.Empty;
        private void gvTuyDo_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (gvTuyDo.RowCount == 0)
            {
                _currentValueHD = string.Empty;
            }
            else if (e.Column.Name.Equals(colTuyDo_KetQua.Name, StringComparison.OrdinalIgnoreCase))
            {
                _currentValueTD = gvTuyDo.GetRowCellValue(e.RowHandle, colHuyetDo_KetQua).ToString().Trim();
            }
            else if (e.Column.Name.Equals(colTuyDo_KetQuaTuy.Name, StringComparison.OrdinalIgnoreCase))
                _currentValueTD = gvTuyDo.GetRowCellValue(e.RowHandle, colTuyDo_KetQuaTuy).ToString().Trim();
        }

        private void gvTuyDo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name.Equals(colTuyDo_KetQua.Name, StringComparison.OrdinalIgnoreCase)
           || e.Column.Name.Equals(colTuyDo_KetQuaTuy.Name, StringComparison.OrdinalIgnoreCase))
            {
                var newValue = (e.Value ?? string.Empty);
                if (!newValue.Equals(_currentValueTD))
                {
                    UpdateResult_TuyDo(e.RowHandle, false);
                }
            }
        }

        private void radCheDoSHS_CheckedChanged(object sender, EventArgs e)
        {
            
            radCheDoSHS.BackColor = (radCheDoSHS.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty);
            if(radCheDoSHS.Checked && !string.IsNullOrEmpty(txtTimBenhNhan.Text))
                LoadDSThongTinBenhNhan();
        }

        private void radCheDoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            radCheDoBarcode.BackColor = (radCheDoBarcode.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty);
            if (radCheDoBarcode.Checked && !string.IsNullOrEmpty(txtTimBenhNhan.Text))
                LoadDSThongTinBenhNhan();
        }

        private void btnMauHutTuyXuong_Click(object sender, EventArgs e)
        {
            var f = new FrmDanhMuc_ChonBieuMau();
            f.LoaiBieuMau = new TemplateInput.EnumTemplateInput[] { TemplateInput.EnumTemplateInput.BienBanHutTuyXuong };
            f.FromResult = true;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            if (f.noidungChon != null)
            {
                for (int i = 0; i < f.noidungChon.Length / 2; i++)
                {
                    var idloaiMau = f.noidungChon[i, 0];
                    var noidung = f.noidungChon[i, 1];
                    Check_AppendText(noidung, ref ricBienBanChocHutTuyXuong);
                }
            }
        }

        private void btnInBienBan_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(ricBienBanChocHutTuyXuong.Text) && !string.IsNullOrEmpty(ucPatientInformation1.MaTiepNhan))
            {
              

                var kyTen = string.Empty;
                if (cboNguoiKyTen.SelectedIndex > -1)
                    kyTen = cboNguoiKyTen.SelectedValue.ToString();
                else
                    kyTen = CommonAppVarsAndFunctions.UserID;

                var printerName = string.Empty;

                if (listPrinter.Items.Count > 0)
                {
                    if (listPrinter.SelectedIndex == -1)
                    {
                        listPrinter.SelectedIndex = 0;
                    }
                    printerName = listPrinter.SelectedItem.ToString();
                }

                DataTable dataPrint = new DataTable();

                dataPrint = _iTestResult.DuLieuIn_XN(_dtPatient, 0, false
                                                       , kyTen
                                                       , string.Empty
                                                       , true, DateTime.Now
                                                       , CommonAppVarsAndFunctions.UserWorkPlace
                                                       , ReportResultTemplateConstant.Mau_BYT_29BV01
                                                       , false, new TestType.EnumTestType[] { TestType.EnumTestType.TuyDo }
                                                       , string.Empty, true, true);

                if (dataPrint.Rows.Count == 0)
                {
                    dataPrint = _iTestResult.DuLieuIn_XN(_dtPatient, 0, false
                                       , kyTen
                                       , string.Empty
                                       , chkPrintTitle.Checked, DateTime.Now
                                       , CommonAppVarsAndFunctions.UserWorkPlace
                                       , ReportResultTemplateConstant.Mau_BYT_29BV01
                                       , false, new TestType.EnumTestType[] { TestType.EnumTestType.ThongThuong, TestType.EnumTestType.HuyetDo }
                                       , string.Empty, false, false, string.Empty, true, string.Empty, true, huyetDo: true, idLoaiXnHuyetDo: TestType.EnumTestType.HuyetDo);

                }

                if(dataPrint.Rows.Count >0)
                {
                    var objthongtinXetNghiem = _iPatient.Get_Info_BenhNhan_CLS_XetNghiem(ucPatientInformation1.MaTiepNhan);
                    dataPrint.Columns.Add("BienBanHTD", typeof(string));
                    var dataPrintFinal = dataPrint.Clone();
                    if (!dataPrintFinal.Columns.Contains("ReportLogo"))
                        dataPrintFinal.Columns.Add("ReportLogo", typeof(byte[]));


                    var dr = dataPrintFinal.NewRow();
                    foreach (DataColumn dtc in dataPrint.Columns)
                    {
                        dr[dtc.ColumnName] = dataPrint.Rows[0][dtc.ColumnName];
                        if (dtc.ColumnName.Equals("BienBanHTD"))
                            dr[dtc.ColumnName] = objthongtinXetNghiem.BienBanHTD;
                    }
                    dataPrintFinal.Rows.Add(dr);
                    foreach (DataRow drLogo in dataPrintFinal.Rows)
                    {
                        drLogo["ReportLogo"] = GraphicSupport.ImageToByteArray(reportLogo);
                    }
                    var resultReportInfo = new XtraReport();
                    var reportUse = new ReportModel();
                    var f = new FrmPreViewReport();
                    reportUse = GetReportInList(ReportConstants.KetQuaXn_BBChocHutTuy);
                    f.SampleID = string.Format("Ketqua_{0}_{1}", "BB_HTD", dataPrintFinal.Rows[0]["MaTiepNhan"].ToString().Trim());

                    f.TenBN = dataPrintFinal.Rows[0]["TenBN"].ToString().Trim();
                    f.InMau = false;
                    f.UserSign = kyTen;
                    resultReportInfo = _reportInfo.CreateReportFromStream(reportUse.ReportSuDung);
                    f.ShowReport(resultReportInfo, dataPrintFinal, !chkPrintPreview.Checked, printerName, "XN", reportUse.TenDataset, reportUse.TenDatatable);
                }
            }
        }

        private void btnLuuBienBan_Click(object sender, EventArgs e)
        {
            LuuBienBanHTD();
        }


        #region Sinh thiết
        private void Load_KetQuaSinhThiet()
        {
            gvKetQuaSinhThiet.FocusedRowChanged -= gvKetQuaSinhThiet_FocusedRowChanged;
            var _dtClsKetQua = _iTestResult.DuLieuKetQua_XN(_dtPatient, 0, false, CommonAppVarsAndFunctions.UserID, string.Empty, false
                , null, CommonAppVarsAndFunctions.UserWorkPlace, string.Empty, false
                , new TestType.EnumTestType[] { TestType.EnumTestType.SinhThietTuySinhMau }
                , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, false, string.Empty, false);

            //_iTestResult.Get_CLS_KetQua_XN(_dtPatient, 0, null, null,
            //    ref _dtClsKetQua, CommonAppVarsAndFunctions.UserID
            //    , DateTime.Now, CommonAppVarsAndFunctions.UserWorkPlace, string.Empty, false
            //    , new TestType.EnumTestType[] { TestType.EnumTestType.SinhThietTuySinhMau }
            //    , Utilities.ArrayToSqlValue(CommonAppVarsAndFunctions.NhomClsXetNghiem), false, string.Empty, false);
            if (_dtClsKetQua != null)
            {
                foreach (DataColumn dc in _dtClsKetQua.Columns)
                    dc.ColumnName = dc.ColumnName.ToLower();
            }
            gcKetQuaSinhThiet.DataSource = _dtClsKetQua;
            gvKetQuaSinhThiet.FocusedRowChanged += gvKetQuaSinhThiet_FocusedRowChanged;
        }
        private void gvKetQuaSinhThiet_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            HienThiThogninSinhThiet();
        }
        private void HienThiThogninSinhThiet()
        {
            txtKetLuanSinhThiet.Text = string.Empty;
            ricKetQuaSinhThiet.Text = string.Empty;

            if (gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN) != null)
            {
                txtKetLuanSinhThiet.Text = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_KetQua).ToString();
                ricKetQuaSinhThiet.Rtf = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NoiKiemTraChatLuong).ToString();
                var daDuyet = bool.Parse(gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_XacNhaKetQua).ToString());
                txtKetLuanSinhThiet.ReadOnly = !daDuyet;
                ricKetQuaSinhThiet.Enabled = !daDuyet;
                btnLuuKetQuaSinhThiet.Enabled = !daDuyet;
            }
        }
        private void btnLuuKetQuaSinhThiet_Click(object sender, EventArgs e)
        {
            LuuKetQuaSinhThiet();
        }
        private void LuuKetQuaSinhThiet()
        {
            if (gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN) != null)
            {
                var daDuyet = bool.Parse(gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_XacNhaKetQua).ToString());
                if (daDuyet)
                    CustomMessageBox.MSG_Information_OK("Không thể lưu kết quả đã duyệt.");
                else
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Lưu kết quả sinh thiết?"))
                    {
                        var maTiepNhan = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaTiepNhan).ToString();
                        var ketqua = txtKetLuanSinhThiet.Text;
                        var noiKiemTraChatLuong = ricKetQuaSinhThiet.Rtf;
                        var maXn = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN).ToString();
                        var ghiChu = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_GhiChu) != null
                          ? gvTuyDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_GhiChu).ToString().Trim()
                          : string.Empty;
                        var nguongTren = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguongTren) != null
                            ? gvTuyDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguongTren).ToString().Trim()
                            : string.Empty;

                        var nguongDuoi = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguongDuoi) != null
                            ? gvTuyDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguongDuoi).ToString().Trim()
                            : string.Empty;

                        var dieuKienBatThuong = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_DKBatThuong) != null
                            ? gvTuyDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_DKBatThuong).ToString().Trim()
                            : string.Empty;

                        var flag = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_Flag) != null
                            ? int.Parse(gvTuyDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_Flag).ToString())
                            : 0;
                        var userNhap = gvKetQuaHuyetDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguoiNhap) != null
                            ? gvTuyDo.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguoiNhap).ToString().Trim()
                            : string.Empty;

                        var lamtron = string.Empty;

                        flag = LabResultService.SetColor(ketqua, nguongTren, nguongDuoi, dieuKienBatThuong);
                        var obUpdate = new UpdateResultNormalInfo
                        {
                            maTiepNhan = maTiepNhan,
                            maXN = maXn,
                            ketQua = ketqua,
                            capNhatghiChu = true,
                            ghiChu = ghiChu,
                            co = flag.ToString(),
                            userNhap = CommonAppVarsAndFunctions.UserID,
                            suaKQ = (!string.IsNullOrWhiteSpace(userNhap)),
                            round = lamtron,
                            userUpdate = CommonAppVarsAndFunctions.UserID
                        };
                        if (string.IsNullOrEmpty(ketqua))
                        {
                            obUpdate.capnhatCoKetQua = true;
                            obUpdate.coKetQua = string.Empty;
                        }

                        _iTestResult.CapNhat_KQ_XN(obUpdate);
                        _iTestResult.CapNhat_NoiKiemTraChatLuong(maTiepNhan, maXn, noiKiemTraChatLuong);

                        _iTestResult.CapNhat_ThongTinMayXn_XnChinh(maTiepNhan);

                        gvKetQuaSinhThiet.SetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_GhiChu, _iTestResult.Get_GhiChuCuaXetNghiem(maTiepNhan, maXn));

                        if (string.IsNullOrEmpty(gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguoiNhap).ToString()))
                        {
                            gvKetQuaSinhThiet.SetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguoiNhap, CommonAppVarsAndFunctions.UserID);
                            gvKetQuaSinhThiet.SetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_TGNhap, CommonAppVarsAndFunctions.ServerTime);
                        }
                        else
                        {
                            gvKetQuaSinhThiet.SetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguoiSua, CommonAppVarsAndFunctions.UserID);
                            gvKetQuaSinhThiet.SetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_TGSua, CommonAppVarsAndFunctions.ServerTime);
                        }

                        gvKetQuaSinhThiet.SetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_Flag, flag);
                    }
                }
            }
        }
        private void btnXacNhanSinhThiet_Click(object sender, EventArgs e)
        {
            if (gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN) != null)
            {
                var daDuyet = bool.Parse(gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_XacNhaKetQua).ToString());
                if(daDuyet)
                {
                    CustomMessageBox.MSG_Information_OK("Kết quả đã được duyệt trước!");
                }
                else if (CustomMessageBox.MSG_Question_YesNo_GetYes("Duyệt kết quả?"))
                {
                    var maTiepNhan = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaTiepNhan).ToString();
                    var maXn = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN).ToString();

                    if (!string.IsNullOrEmpty(maXn))
                    {
                        _iTestResult.XacNhan_KQ_XN(maTiepNhan, maXn, CommonConstant.IsValided
                            , true, CommonAppVarsAndFunctions.UserID.Trim(), CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
                        Load_KetQuaSinhThiet();
                    }
                }
            }
        }

        private void btnHuyXacNhanSinhThiet_Click(object sender, EventArgs e)
        {
            if (gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN) != null)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bỏ duyệt kết quả?"))
                {
                    var maTiepNhan = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaTiepNhan).ToString();
                    var maXn = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN).ToString();
                    var userXacNhan = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_NguoiDuyet).ToString().Trim();
                    if (string.IsNullOrEmpty(userXacNhan) || userXacNhan.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        _iTestResult.XacNhan_KQ_XN(maTiepNhan, maXn, CommonConstant.InValid
                               , false, CommonAppVarsAndFunctions.UserID.Trim(), CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
                        Load_KetQuaSinhThiet();
                    }
                    else
                    {
                        CustomMessageBox.MSG_Question_YesNo_GetYes("Không thể bỏ duyệt kết quả của user khác!");
                    }
                }
            }
        }

        private void btnChonMauSinhThiet_Click(object sender, EventArgs e)
        {
            var f = new FrmDanhMuc_ChonBieuMau();
            f.LoaiBieuMau = new TemplateInput.EnumTemplateInput[] { TemplateInput.EnumTemplateInput.SinhThietTuySinhMau };
            f.FromResult = true;
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
            if (f.noidungChon != null)
            {
                for (int i = 0; i < f.noidungChon.Length / 2; i++)
                {
                    var idloaiMau = f.noidungChon[i, 0];
                    var noidung = f.noidungChon[i, 1];
                    Check_AppendText(noidung, ref ricKetQuaSinhThiet);
                }
            }
        }
        private void InKetQuaSinhThiet()
        {
            if (gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN) != null)
            {
               
              

                var userSign = cboNguoiKyTen.SelectedIndex > -1 ? cboNguoiKyTen.SelectedValue.ToString().Trim() : CommonAppVarsAndFunctions.UserID;
                if (userSign.Equals(CommonAppVarsAndFunctions.UserID.Trim(), StringComparison.OrdinalIgnoreCase)
                    && !CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChoChuKyGiongUserDangNhap)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn người ký tên khác user đăng nhập!");
                    return;
                }
                var kyTen = string.Empty;
                if (cboNguoiKyTen.SelectedIndex > -1)
                    kyTen = cboNguoiKyTen.SelectedValue.ToString();
                else
                    kyTen = CommonAppVarsAndFunctions.UserID;


                var printerName = string.Empty;
                if (listPrinter.Items.Count > 0)
                {
                    if (listPrinter.SelectedIndex == -1)
                    {
                        listPrinter.SelectedIndex = 0;
                    }
                    printerName = listPrinter.SelectedItem.ToString();
                }
                var havePrintTuyDo = false;
                var maXn = gvKetQuaSinhThiet.GetRowCellValue(gvKetQuaSinhThiet.FocusedRowHandle, colKetQuaSinhThiet_MaXN).ToString();
                var f = new FrmPreViewReport();
                var dataSinhThiet = _iTestResult.DuLieuIn_XN(_dtPatient, 0, false
                                                    , kyTen
                                                    , maXn
                                                    , true, DateTime.Now
                                                    , CommonAppVarsAndFunctions.UserWorkPlace
                                                    , string.Empty
                                                    , false, new TestType.EnumTestType[] { TestType.EnumTestType.SinhThietTuySinhMau }
                                                    , string.Empty, true, true);
                if (!dataSinhThiet.Columns.Contains("ReportLogo"))
                    dataSinhThiet.Columns.Add("ReportLogo", typeof(byte[]));

                foreach (DataRow dr in dataSinhThiet.Rows)
                {
                    dr["ReportLogo"] = GraphicSupport.ImageToByteArray(reportLogo);
                }
                if (dataSinhThiet.Rows.Count > 0)
                {
                   
                    var dataPrint = _iTestResult.DataPrintList_NotAutoSplit(dataSinhThiet, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemPhieuInTachTheoNhom);
                    var resultReportInfo = new ReportModel();
                    var reportTemplateID = dataPrint.Rows[0]["IDMauKetQua"].ToString();
                    resultReportInfo = GetReportFromConfig(reportTemplateID);
                    if (resultReportInfo == null)
                    {
                        CustomMessageBox.MSG_Information_OK(string.Format("Phiếu in của mẫu: \"{0}\" chưa được khai báo.", reportTemplateID));
                        return;
                    }

                    //reportUse = GetReportInList(ReportConstants.KetQuaXn_SinhThiet);
                    f.SampleID = string.Format("Ketqua_{0}_{1}", "SinhThietTuy", dataSinhThiet.Rows[0]["MaTiepNhan"].ToString().Trim());

                    f.TenBN = dataSinhThiet.Rows[0]["TenBN"].ToString().Trim();
                    f.InMau = false;
                    f.UserSign = kyTen;
                    var reportTemplate = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    havePrintTuyDo = f.ShowReport(reportTemplate, dataPrint, !chkPrintPreview.Checked, printerName, "XN", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);
                }

                if (havePrintTuyDo)
                {
                    string categoryPrint = string.Empty;
                    var dataDistincCategory = dataSinhThiet.AsDataView().ToTable(true, new string[] { "manhomcls" });
                    foreach (DataRow drC in dataDistincCategory.Rows)
                    {
                        categoryPrint += (string.IsNullOrEmpty(categoryPrint) ? "" : ",") + string.Format("{0}", drC["manhomcls"].ToString());
                    }
                    var conditSomeTestPrint = string.Empty;
                    foreach (DataRow dr in dataSinhThiet.Rows)
                    {
                        conditSomeTestPrint += string.IsNullOrEmpty(conditSomeTestPrint) ? "" : ",";
                        conditSomeTestPrint += dr["MaXN"].ToString().Trim();
                    }

                    _iTestResult.CapNhatPrintOut_WithoutReportType(dataSinhThiet.Rows[0]["MaTiepNhan"].ToString().Trim()
                        , conditSomeTestPrint, categoryPrint, true, CommonAppVarsAndFunctions.UserID, string.Empty
                        , CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, kyTen, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);

                    _iTestResult.CapNhat_In_KQ_XN(dataSinhThiet.Rows[0]["MaTiepNhan"].ToString().Trim(), CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemInTuXacNhan);
                    _iTestResult.UpdatePrintOutCategory(dataSinhThiet.Rows[0]["MaTiepNhan"].ToString().Trim(), categoryPrint, true, CommonAppVarsAndFunctions.UserID);
                }
            }
        }
        private void btnInKetQuaSinhThiet_Click(object sender, EventArgs e)
        {
            InKetQuaSinhThiet();
        }
        #endregion

        private void FrmCLS_KetQua_HuyetTuyDo_SizeChanged(object sender, EventArgs e)
        {
            if(xtraScrollableControl1.Height > splitContainerControlKetquaHTD.Height)
            {
                splitContainerControlKetquaHTD.Tag = splitContainerControlKetquaHTD.Height;
                splitContainerControlKetquaHTD.Height = xtraScrollableControl1.Height;
            }
            else if (splitContainerControlKetquaHTD.Tag != null)
            {
                splitContainerControlKetquaHTD.Height = int.Parse(splitContainerControlKetquaHTD.Tag.ToString());
            }
        }
    }
}
