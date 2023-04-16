using DevExpress.Office.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Skins;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.Controls;
using TPH.Data.HIS.HISDataCommon;
using TPH.Data.HIS.Models;
using TPH.HIS.WebAPI.Models.HisReponses;
using TPH.Lab.Middleware.HISConnect.Services;
using TPH.Lab.Middleware.LISConnect.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.BarcodePrinting;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Model;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.WriteLog;

namespace TPH.LIS.App.DailyUse.BenhNhan
{
    public partial class FrmLayMau : FrmTemplate
    {
        public FrmLayMau()
        {
            InitializeComponent();
            pnChoLayMau.BackColor = CommonAppColors.ColorMainAppColor;
            //pnChoLayMau.TopColor = CommonAppColors.ColorMainAppColor;
            //pnChoLayMau.BottomColor = CommonAppColors.ColorMainAppFormColor;
            pnDaLayMau.BackColor = CommonAppColors.ColorMainAppColor;
            //pnDaLayMau.TopColor = CommonAppColors.ColorMainAppColor;
            //pnDaLayMau.BottomColor = CommonAppColors.ColorMainAppFormColor;
            lblMsgOrder.BackColor = CommonAppColors.MenuItemTextSelectedColor;
            //pnHuylayMau.BackColor = pnCapNhatGioLayMau.BackColor = CommonAppColors.ColorMainAppFormColor;
            //pnHuylayMau.TopColor = pnCapNhatGioLayMau.TopColor = CommonAppColors.ColorMainAppColor;
            //pnHuylayMau.BottomColor = pnCapNhatGioLayMau.BottomColor = CommonAppColors.ColorMainAppFormColor;
            gbDieuKien.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
        }
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        TestResult.Services.ITestResultService _iTestResult = new TestResult.Services.TestResultService();
        Patient.Services.IPatientInformationService _iPatient = new Patient.Services.PatientInformationService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly IGetHISService _iHisService = new GetHISService();
        private readonly IConnectHISService _iHisData = new ConnectHISService();

        private GridElementsPainter _PainterChuaLayMau;
        private GridElementsPainter _PainterDaLayMau;
        string idKhuLaymau = "-1";
        private DM_MAYTINH_MAYIN objPrintInfo;
        private DM_KHULAYMAU objKhuLayMau = new DM_KHULAYMAU();
        private TrangThaiLayMau objTrangThaiCuaMau = new TrangThaiLayMau();
        private KiemSoatChayMau objKiemSoatLayMau = new KiemSoatChayMau();
        List<DM_KHUVUC> lstKhuVuc = new List<DM_KHUVUC>();
        List<DM_KHUVUC_XNKHONGTHUCHIEN> lstXnGui = new List<DM_KHUVUC_XNKHONGTHUCHIEN>();
        private void Load_XnGuiMau()
        {
            var data = _iSysConfig.Data_dm_khuvuc_xnkhongthuchien(CommonAppVarsAndFunctions.PCWorkPlace, string.Empty, string.Empty);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    lstXnGui.Add(_iSysConfig.Get_Info_dm_khuvuc_xnkhongthuchien(dataRow));
                }
            }
        }
        private void Load_DSKhuVuc()
        {
            var data = _iSysConfig.Data_dm_khuvuc(string.Empty);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    lstKhuVuc.Add(_iSysConfig.Get_Info_dm_khuvuc(dataRow));
                }
            }
        }
        private void Load_PrintConfig()
        {
            var idMayXN = 0;
            if (cboMayInTem.SelectedValue != null && cboMayInTem.SelectedIndex > -1)
                idMayXN = NumberConverter.ToInt(cboMayInTem.SelectedValue);
            _registryExtension.WriteRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample, idMayXN.ToString());
            objPrintInfo = _iSysConfig.Get_info_CauHinh_MaInbarcode(Environment.MachineName, idMayXN, 1);
        }
        private DieuKienTimDanhSachBNTheoTrangThaiMau DieuKienLoad_DanhSachBN()
        {
            var obj = new DieuKienTimDanhSachBNTheoTrangThaiMau();
            //--- Tất cả ---
            //Chưa lấy mẫu
            //Đã lấy mẫu đủ
            //Chưa lấy mẫu đủ
            //Yêu cầu lấy lại
            obj.tungay = dtpNgayChiDinh.Value;
            obj.denngay = dtpDenNgayChiDinh.Value;
            obj.SampleCode = (string.IsNullOrEmpty(txtBarcode.Text) ? string.Empty : txtBarcode.Text.Replace(WorkingServices.SplitSampleCode(txtBarcode.Text), ""));
            var temBarcode = string.IsNullOrEmpty(obj.SampleCode) ? txtBarcode.Text : (string.IsNullOrEmpty(txtBarcode.Text) ? string.Empty : txtBarcode.Text.Replace(obj.SampleCode, ""));
            obj.barcode = WorkingServices.IsNumeric(temBarcode) ? temBarcode : string.Empty;
            obj.tenBN = WorkingServices.IsNumeric(temBarcode) ? string.Empty : txtBarcode.Text;
            obj.loaiDichVu = ServiceType.ClsXetNghiem;
            obj.sophieuHis = txtBarcode.Text;
            //  obj.quyennhomXn = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            var indexSelected = cboTrangThaiLayMau.SelectedIndex;
            if (indexSelected == 1)
            {
                obj.daLayMauTatCa = Common.enumThucHien.ChuaThucHien;
            }
            else if (indexSelected == 2)
            {
                obj.daLayMauTatCa = Common.enumThucHien.DaThucHien;
            }
            else if (indexSelected == 3)
            {
                obj.coLayMau = Common.enumThucHien.DaThucHien;
                obj.daLayMauTatCa = Common.enumThucHien.ChuaThucHien;
            }
            else if (indexSelected == 4)
            {
                obj.daTuChoiMau = Common.enumThucHien.DaThucHien;
            }
            obj.CheckDaLayMau = false;
            obj.CheckSoHoSo = radCheDoSHS.Checked;
            return obj;
        }

        private void Get_DanhSachBenhNhan(string searchValue)
        {

            try
            {
                if (string.IsNullOrEmpty(txtBarcode.Text) && radCheDoSHS.Checked)
                {
                    return;
                }
                gvDanhSach.SelectionChanged -= GvDanhSach_SelectionChanged;
                var currentbarcode = searchValue; // txtBarcode.Text;
                var dieuKien = DieuKienLoad_DanhSachBN();
                var data = WorkingServices.ConvertColumnNameToLower_Upper(_iPatient.DanhSach_BenhNhan_TheoTrangThaiMau(dieuKien), true);
                gcDanhSach.DataSource = data;

                if (gvDanhSach.RowCount == 0)
                {
                    lblMsg.Text = "";
                    SetNullGridDetailData();
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentbarcode) && radCheDoBarcode.Checked)
                    {
                        var date = (DateTime)gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan);
                        dtpNgayChiDinh.Value = date;
                        dtpDenNgayChiDinh.Value = date;
                    }
                };
                gvDanhSach.SelectionChanged += GvDanhSach_SelectionChanged;
                if (gvDanhSach.FocusedRowHandle > -1)
                {
                    var maTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                    //gvDanhSach_RowEnter(gvDanhSach, new DataGridViewCellEventArgs(0, 0));
                    LayChiTietMau();
                    if (!string.IsNullOrEmpty(dieuKien.SampleCode))
                        CheckWithSampleCode(dieuKien.SampleCode);
                    Get_TrangThaiLayMau();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.MSG_Error_OK(ex.Message);
            }
        }

        private void GvDanhSach_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            LayChiTietMau();
            Get_TrangThaiLayMau();
        }

        private void SetNullGridDetailData()
        {
            gcChuaLayMau.DataSource = null;
            gcMauDaLay.DataSource = null;
        }
        private void GetDataForHL7ByMaTiepNhan(List<BenhNhanInfoForHIS> lstMaTiepNhanHL7, GetUploadCondit condit)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ConnectHIS)
            {
                //Xử lý check null trước khi add tránh bị slõi khi select = linq bị null x
                var obj = _iHisData.GetDataUploadToHIS(condit);
                if (obj != null)
                    lstMaTiepNhanHL7.Add(obj);
            }
        }
        private void AddInfoHL7(List<BenhNhanInfoForHIS> lstBnHL7Upate, List<BenhNhanInfoForHIS> lstMaTiepNhanHL7, string matiepNhanChiTiet, string maChidinh, string maCapTren, string orderStatus)
        {
            if (!CommonAppVarsAndFunctions.sysConfig.ConnectHIS || lstMaTiepNhanHL7 == null || lstMaTiepNhanHL7.Count == 0) return;
            //Thêm thông tin update HL7 về ISOFH
            var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet));
            if (bnExisted.Any())
            {
                if (lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).Any())
                {
                    if (lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).First().ChiDinh != null)
                    {
                        if (lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).Any())
                        {
                            var bnInfo = bnExisted.FirstOrDefault();
                            var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                            chidinh.TrangThaiMau = orderStatus;
                            bnInfo.ChiDinh.Add(chidinh);
                        }
                    }
                }
            }
            else
            {
                if (lstMaTiepNhanHL7.Where(x => (x.Matiepnhan ?? String.Empty).Equals(matiepNhanChiTiet)).Any())
                {
                    var bnAdd = lstMaTiepNhanHL7.Where(x => (x.Matiepnhan ?? String.Empty).Equals(matiepNhanChiTiet)).First().CopyHISInfo();
                    var chidinh = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(maChidinh) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).ToList();
                    foreach (var itmChiDinh in chidinh)
                    {
                        itmChiDinh.TrangThaiMau = orderStatus;
                    }
                    bnAdd.ChiDinh = chidinh;
                    lstBnHL7Upate.Add(bnAdd);
                }
            }
        }
        //private void LayChiTietMau()
        //{
        //    var maTiepNhan = string.Empty;
        //    if (radCheDoSHS.Checked)
        //    {
        //        for (int i = 0; i < gvDanhSach.RowCount; i++)
        //        {
        //            var check = gvDanhSach[colChonBarcode.Name, i].Value;
        //            var isCheck = check == null ? false : (bool)check;
        //            if (isCheck)
        //            {
        //                maTiepNhan += (string.IsNullOrEmpty(maTiepNhan) ? "" : ",");
        //                maTiepNhan += gvDanhSach[colDS_MaTiepNhan.Name, i].Value.ToString();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (gvDanhSach.FocusedRowHandle > -1)
        //        {
        //            maTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
        //        }
        //    }
        //    Get_ChiTietXetNghiem_ChuaLayMau(maTiepNhan);
        //    Get_ChiTietXetNghiem_DaLayMau(maTiepNhan);
        //}
        private void LayChiTietMau()
        {
            gcMauDaLay.DataSource = null;
            gcChuaLayMau.DataSource = null;
            var maTiepNhan = string.Empty;
            //if (radCheDoSHS.Checked)
            //{
            //    if (gvDanhSach.SelectedRowsCount > 0)
            //    {
            //        foreach (var i in gvDanhSach.GetSelectedRows())
            //        {
            //            if (gvDanhSach.GetRowCellValue(i, colDS_MaTiepNhan) != null)
            //            {
            //                maTiepNhan += (string.IsNullOrEmpty(maTiepNhan) ? "" : ",");
            //                maTiepNhan += gvDanhSach.GetRowCellValue(i, colDS_MaTiepNhan).ToString();
            //            }
            //        }
            //    }
            //}
            //else
            //{
                if (gvDanhSach.SelectedRowsCount >0)
                {
                    foreach (var i in gvDanhSach.GetSelectedRows())
                    {
                        if (gvDanhSach.GetRowCellValue(i, colDS_MaTiepNhan) != null)
                        {
                            maTiepNhan += (string.IsNullOrEmpty(maTiepNhan) ? "" : ",");
                            maTiepNhan += gvDanhSach.GetRowCellValue(i, colDS_MaTiepNhan).ToString();
                        }
                    }
                }
               else if (gvDanhSach.FocusedRowHandle > -1)
                {
                    maTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                }
            //}
            var data = _iPatient.DanhSachChiDinh_OngMau(maTiepNhan, CommonAppVarsAndFunctions.IDLayLoaiMau);
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    data = XuLyDuLieu(data);
                    data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                    var dataVoiPhanQuyen = data;
                    if (dataVoiPhanQuyen.Rows.Count > 0)
                    {
                        var dataDaLayMau = WorkingServices.SearchResult_OnDatatable(dataVoiPhanQuyen, string.Format("DaLayMau = 1"));
                        var dataChuaLayMau = WorkingServices.SearchResult_OnDatatable(dataVoiPhanQuyen, string.Format("DaLayMau = 0"));

                        gcChuaLayMau.DataSource = dataChuaLayMau;
                        gvChuaLayMau.ExpandAllGroups();
                        gvChuaLayMau.SelectAll();

                        if (!chkChiTietChuaLayMau.Checked)
                        {
                            gvChuaLayMau.CollapseAllGroups();
                            if (gvDanhSach.SelectedRowsCount > 0)
                            {
                                gvChuaLayMau.ExpandGroupLevel(0);
                                gvChuaLayMau.ExpandGroupLevel(1);
                            }
                            else
                                gvChuaLayMau.ExpandGroupLevel(0);
                        }
                        else
                        {
                            gvChuaLayMau.ExpandAllGroups();

                            gvChuaLayMau.SelectAll();
                        }

                        gcMauDaLay.DataSource = dataDaLayMau;
                        gvMauDaLay.ExpandAllGroups();
                        if (!chkChiTietDaLayMau.Checked)
                        {
                            gvMauDaLay.CollapseAllGroups();
                            if (gvDanhSach.SelectedRowsCount > 0)
                            {
                                gvMauDaLay.ExpandGroupLevel(0);
                                gvMauDaLay.ExpandGroupLevel(1);
                            }
                            else
                                gvMauDaLay.ExpandGroupLevel(0);
                        }
                        else
                            gvMauDaLay.ExpandAllGroups();
                    }
                }
            }
            CheckLoadDShenDangShow();
        }
        private DataTable XuLyDuLieu(DataTable DataIn)
        {
            DataIn.Columns.Add("HinhOngMau", typeof(Image));
            DataIn.Columns.Add("NoiDuKienThucHien", typeof(string));
            DataIn.Columns.Add("IdGui", typeof(long));
            DataIn.Columns.Add("IDNoiGuiMau", typeof(string));
            DataIn.Columns.Add("IDNoiNhanGuiMau", typeof(string));
            var maXN = string.Empty;
            var maKhuvucnhan = string.Empty;
            var manhomCls = string.Empty;

            var distinctMaTiepNhan = DataIn.DefaultView.ToTable(true, "MaTiepNhan");
            var dataMauGui = new DataTable();
            foreach (DataRow drT in distinctMaTiepNhan.Rows)
            {
                var temDT = _iPatient.Data_XetNghiem_GuiMau(drT["MaTiepNhan"].ToString(), 2, CommonAppVarsAndFunctions.NhomClsXetNghiem);
                if (temDT != null)
                {
                    if (dataMauGui.Rows.Count == 0)
                        dataMauGui = temDT.Copy();
                    else
                    {
                        dataMauGui.Merge(temDT);
                    }
                }
            }
            var lstMauGui = new List<GuiMauNoiBoModel>();
            if (dataMauGui != null)
            {
                foreach (DataRow dataRow in dataMauGui.Rows)
                {
                    var obj = new GuiMauNoiBoModel();
                    lstMauGui.Add((GuiMauNoiBoModel)WorkingServices.Get_InfoForObject(obj, dataRow));
                }
            }

            for (int i = 0; i < DataIn.Rows.Count; i++)
            {
                DataRow dr = DataIn.Rows[i];
                if (!string.IsNullOrEmpty(dr["MauNhanMau"].ToString()))
                {
                    string[] split = dr["MauNhanMau"].ToString().Split(',');
                    if (split.Length == 3)
                    {
                        Bitmap b = new Bitmap(18, 28);
                        using (Graphics g = Graphics.FromImage(b))
                            g.Clear(Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
                        dr["HinhOngMau"] = b;
                    }
                }
                var maTiepNhan = dr["MaTiepNhan"].ToString();
                //Xử lý trạng thái gửi mẫu
                maXN = dr["MaDichVu"].ToString();
                long idGui = 0;
                if (lstMauGui.Count > 0)
                {
                    var mauGui = lstMauGui.Where(g => g.Madichvu.Equals(maXN, StringComparison.OrdinalIgnoreCase) && g.Matiepnhan.Equals(maTiepNhan));
                    if (mauGui.Any())
                    {
                        idGui = mauGui.First().Idgui;
                        dr["IDNoiGuiMau"] = mauGui.First().Khuvucguiid;
                        dr["IDNoiNhanGuiMau"] = mauGui.First().Khuvucnhanid;
                    }
                }
                dr["IdGui"] = idGui;
                var lstkhuNhan = lstXnGui.Where(x => x.Maxn.Equals(maXN.Trim(), StringComparison.OrdinalIgnoreCase));
                if (idGui > 0)
                {
                    var lstkhuGuiDen = lstKhuVuc.Where(x => x.Makhuvuc.Trim().Equals(dr["IDNoiNhanGuiMau"].ToString().Trim(), StringComparison.OrdinalIgnoreCase));
                    if (lstkhuGuiDen.Any())
                    {
                        dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", lstkhuGuiDen.FirstOrDefault().Tenkhuvuc, lstkhuGuiDen.FirstOrDefault().Makhuvuc, (idGui > 0 ? " - Gửi mẫu" : string.Empty));
                    }
                }
                else if (lstkhuNhan.Any())
                {
                    dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", lstkhuNhan.FirstOrDefault().Tenkhuvucnhan, lstkhuNhan.FirstOrDefault().Makhuvucnhan, (idGui > 0 ? " - Gửi mẫu" : string.Empty));

                }
                else
                {
                    dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", CommonAppVarsAndFunctions.PCWorkPlaceName, CommonAppVarsAndFunctions.PCWorkPlace, (idGui > 0 ? " - Gửi mẫu" : string.Empty));
                }

               
            }
            return DataIn;
        }
        private void ChkChonBarcodeAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Get_SoLuongMau(string maTiepNhan)
        {
            int slBarcode = _iTestResult.SoLuongMau(maTiepNhan, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemTinhSoTemTheoNhom) + int.Parse(CommonAppVarsAndFunctions.sysConfig.TiepNhanHisSoLuongBarcodeToiThieu);
            txtSoLuongBarcode.Text = slBarcode.ToString();
        }
        private void PrintBarcode(List<string> lstMatiepNhan
            , List<string> lstLoaiMau = null, bool isRePrint = false
            , DateTime? thoigianLaymau = null)
        {
            var lstiepNhan = new List<BENHNHAN_TIEPNHAN>();
            foreach (var item in lstMatiepNhan)
            {
                lstiepNhan.Add(_iPatient.Get_Info_BenhNhan_TiepNhan(item, new string[] { }));
            }
            List<KETQUA_CLS_XETNGHIEM> objXetNghiem = null;
            if (objPrintInfo != null)
            {
                if (objPrintInfo.Giaothuc != null)
                {
                    if (objPrintInfo.Giaothuc.Equals(PrintingSystemProtocolList.BCRoboMT))
                    {
                        WriteLog.LogService.RecordLogFile("Inbarcode", " InBarcode : BCRoboMT");
                        var lstMaTiepNhan = new List<string>();
                        foreach (var obj in lstiepNhan)
                        {
                            lstMaTiepNhan.Add(obj.Matiepnhan);
                        }
                        var objPrint = lstiepNhan.First();
                        WriteLog.LogService.RecordLogFile("Inbarcode", string.Format(" InBarcode : BCRoboMT - Lấy danh sách chỉ dinh theo số hồ sơ:{0}{1}Các số code:{2} ", objPrint.Bn_id, Environment.NewLine, lstMaTiepNhan));
                        objXetNghiem = _iTestResult.lstXetnghiem(lstMaTiepNhan, string.Empty);
                        WriteLog.LogService.RecordLogFile("Inbarcode", string.Format(" InBarcode : BCRoboMT - objXetNghiem -> Số record:{0}", objXetNghiem.Count));
                        PrintBarcodeHelper.PrintBarcode(new List<BENHNHAN_TIEPNHAN> { objPrint }, cboTrangThaiLayMau.SelectedIndex, objPrintInfo, isRePrint, null, objXetNghiem);
                        txtBarcode.Focus();
                        txtBarcode.SelectAll();
                        return;
                    }
                }
            }
            PrintBarcodeHelper.PrintBarcode(lstiepNhan, cboTrangThaiLayMau.SelectedIndex, objPrintInfo, isRePrint, lstLoaiMau, objXetNghiem, thoigianLaymau, lblMsgOrder);
            txtBarcode.Focus();
            txtBarcode.SelectAll();
        }
        private C_BenhNhan_TiepNhan data = new C_BenhNhan_TiepNhan();

        void GetLableTitle(string statusTQ, string statusVS)
        {
            objTrangThaiCuaMau = LayThongTintrangThai(statusTQ, statusVS);
            lblMsg.Text = objTrangThaiCuaMau.TrangThaiChung;
        }
        private TrangThaiLayMau LayThongTintrangThai(string statusTQ, string statusVS)
        {
            return SampleStatus.Get_TrangLayMau(statusTQ, statusVS);
        }

        private void Load_KiemSoatLayMau()
        {
            objKiemSoatLayMau = _iPatient.ThongKiemSoatLayMau(CommonAppVarsAndFunctions.UserID);
        }

        private bool CheckAllow_LayMau(string barcode)
        {
            if (objKhuLayMau.Sophutgioihanlaymau == 0 && objKhuLayMau.Gioihanlaymau == 0)
            {
                return true;
            }
            else
            {
                if (objKiemSoatLayMau.DangKhoa && objKiemSoatLayMau.TGKhoa.AddMinutes(objKhuLayMau.Sophutgioihanlaymau) >= DateTime.Now)
                {
                    return false;
                }
                else
                {
                    //=> reset lại bộ đếm
                    // nếu đã cộng số phút giới hạn nhưng vẫn nhỏ hơn giờ hiện tại 
                    // hoặc đã hết thời gian khóa
                    // hoặc bắt đầu lấy lần đầu => lúc này objKiemSoatLayMau.DanhSachCode.Count == 0
                    if (objKiemSoatLayMau.TGGianBatDau.AddMinutes(objKhuLayMau.Sophutgioihanlaymau) < DateTime.Now
                        || objKiemSoatLayMau.DangKhoa
                        || objKiemSoatLayMau.DanhSachCode.Count == 0)
                    {
                        objKiemSoatLayMau.TGGianBatDau = DateTime.Now;
                        objKiemSoatLayMau.DanhSachCode = new List<string>();
                        objKiemSoatLayMau.DangKhoa = false;
                    }

                    //Vào range: số lượng = giới hạn  - 1 và số code này sẽ được tính 1 lần quét (code chưa có trong list hiện tại) 
                    if (objKiemSoatLayMau.DanhSachCode.Count == objKhuLayMau.Gioihanlaymau - 1 && !objKiemSoatLayMau.DanhSachCode.Contains(barcode))
                    {
                        objKiemSoatLayMau.TGKhoa = DateTime.Now;
                        objKiemSoatLayMau.DangKhoa = true;
                        objKiemSoatLayMau.DanhSachCode.Add(barcode);
                        return true;
                    }
                    else
                    {
                        if (!objKiemSoatLayMau.DanhSachCode.Contains(barcode))
                            objKiemSoatLayMau.DanhSachCode.Add(barcode);
                        return true;
                    }
                }
            }
        }
        int banLayMau = 0;
        string nguoiLayMau = string.Empty;
        int soTTLayMau = 0;
        DateTime tgThucHienLayMau = CommonAppVarsAndFunctions.ServerTime;
        private bool LayBanLayMau()
        {
            tgThucHienLayMau = C_Ultilities.ServerDate().AddMinutes(objKhuLayMau.Sophutconglaymau);
            if (objKhuLayMau.NhapDanhSachUserLayMau)
            {
                var data = _iPatient.LayMau_LaySoBan(objKhuLayMau.Idkhulaymau);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        banLayMau = int.Parse(data.Rows[0]["SoBanKeTiep"].ToString());
                        nguoiLayMau = data.Rows[0]["MaNguoiDung"].ToString();
                        soTTLayMau = int.Parse(data.Rows[0]["SoLuongDaCap"].ToString());
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Chưa có bàn đăng ký lấy mẫu.");
                        ShowMessage("Chưa có bàn đăng ký lấy mẫu.");
                        return false;
                    }
                }
            }
            else
            {
                if (objKhuLayMau.ChonNguoiLayMau)
                {
                    if (ucSearchLookupEditor_NguoiDungDKLayMau1.SelectedValue != null)
                    {
                        banLayMau = 0;
                        nguoiLayMau = ucSearchLookupEditor_NguoiDungDKLayMau1.SelectedValue.ToString();
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Chưa chọn thông tin người lấy mẫu");
                        ShowMessage("Chưa chọn thông tin người lấy mẫu");
                        return false;
                    }
                }
                else
                {
                    banLayMau = 0;
                    nguoiLayMau = CommonAppVarsAndFunctions.UserID;
                }
            }
            return true;
        }
        private void UpdateLayMau(string soHoSo, bool fromClick = false)
        {
            try
            {
                if (!string.IsNullOrEmpty(soHoSo))
                {
                    if (LayBanLayMau())
                    {
                        if (CheckAllow_LayMau(soHoSo))
                        {
                            bool ok = false;
                            List<string> listCapNhatLayMau = new List<string>();
                            List<string> listMauInbarcode = new List<string>();
                            var lstMatiepnhan = new List<string>();
                            var lstDSLayMau = new List<LayMauInfo>();
                            var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();
                            var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                            if (gvChuaLayMau.RowCount > 0)
                            {
                                var maloaiMau = string.Empty;
                                var manhomloaiMau = string.Empty;
                                var madichvu = string.Empty;
                                var matiepNhan = string.Empty;
                                var loaiXetNghiem = -1;
                                var maCapTren = string.Empty;
                                var profileID = string.Empty;
                                var maKhoaPhong = string.Empty;
                                var noiSinh = (ucSearchLookupEditor_Location1.SelectedValue ?? (object)string.Empty).ToString();
                                foreach (int i in gvChuaLayMau.GetSelectedRows())
                                {
                                    if (gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaDichVu) != null)
                                    {
                                        maloaiMau = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaLoaiMau).ToString().Trim();
                                        manhomloaiMau = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaNhomLoaiMau).ToString().Trim();
                                        madichvu = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaDichVu).ToString().Trim();
                                        matiepNhan = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaTiepNhan).ToString().Trim();
                                        loaiXetNghiem = int.Parse(gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_LoaiXetNghiem).ToString().Trim());
                                        maCapTren = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaXN_His).ToString().Trim();
                                        profileID = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaProfile).ToString().Trim();
                                        maKhoaPhong = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaKhoaPhong).ToString().Trim();
                                        if (!lstMatiepnhan.Contains(matiepNhan))
                                        {
                                            lstMatiepnhan.Add(matiepNhan);
                                            GetDataForHL7ByMaTiepNhan(lstMaTiepNhanHL7, new GetUploadCondit
                                            {
                                                userID = CommonAppVarsAndFunctions.UserID,
                                                matiepnhan = matiepNhan,
                                                onlyValid = false,
                                                onlyPrinted = false,
                                                arrCatePrint = null,
                                                arrtestCodePrint = null,
                                                arrTestTypeID = new string[] { },
                                                frombackup = false,
                                                manualUpload = true,
                                                forStatus = true
                                            });

                                        }

                                        lstDSLayMau.Add(
                                            new LayMauInfo
                                            {
                                                MaTiepNhan = matiepNhan,
                                                TrangThai = enumThucHien.DaThucHien,
                                                MaNhomLoaiMau = maloaiMau,
                                                NguoiThucHien = nguoiLayMau,
                                                Pcthuchien = Environment.MachineName,
                                                CheckXacNhanHis = true,
                                                Maxn = madichvu,
                                                IDKhuLayMau = idKhuLaymau,
                                                ThoiGianLayMau = tgThucHienLayMau,
                                                LoaiXetNghiem = loaiXetNghiem,
                                                IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                                BanLayMau = banLayMau,
                                                MaCapTren = maCapTren,
                                                ProfileId = profileID,
                                                MaKhoaPhong = maKhoaPhong,
                                                NoiSinh = noiSinh
                                            });

                                        if (!listChuaLayMau.Contains(maloaiMau))
                                        {
                                            listChuaLayMau.Add(maloaiMau);
                                        }
                                        if (!listMauInbarcode.Contains(manhomloaiMau))
                                            listMauInbarcode.Add(manhomloaiMau);

                                        //Thêm thông tin update HL7 về ISOFH
                                        AddInfoHL7(lstBnHL7Upate, lstMaTiepNhanHL7, matiepNhan, madichvu, maCapTren, OrderStatus.SampleCollect);
                                    }
                                }
                                //Cap nhat lay mau cho test
                                _iPatient.Update_MauXn_LayMau(lstDSLayMau);
                                //Insert nhóm
                                _iTestResult.InsertCategoryOfTest(string.Join(",", lstMatiepnhan));
                                //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
                                _iPatient.Update_TrangThaiLayMau_NhanMau(string.Join(",", lstMatiepnhan), false, false);
                                Task.Factory.StartNew(() => UpdateTrangThaiVaTGHen(lstMatiepnhan));
                                //Trung - Cập nhật TG lấy mẫu, Tên người lấy mẫu, Khoa chỉ định của Tiền sản, Sàng lọc sơ sinh
                                if (lstDSLayMau.Count > 0)
                                {
                                    var lstDSLayMau_SoSinh_TruocSinh = lstDSLayMau.Where(t => t.LoaiXetNghiem.Equals(32) || t.LoaiXetNghiem.Equals(28));
                                    if (lstDSLayMau_SoSinh_TruocSinh.Any())
                                    {
                                        _iPatient.Update_TG_Khoa_User_LayMau(lstDSLayMau_SoSinh_TruocSinh.ToList());
                                    }
                                }
                                if (lstBnHL7Upate.Count > 0)
                                {
                                    Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                                }
                                //Chỉ áp dụng in từng mã tiếp nhận khi lấy mẫu theo SỐ HỒ SƠ
                                if (chkTuInbarcode.Checked)
                                {
                                    foreach (var matiepNhanChiTiet in lstMatiepnhan)
                                    {
                                        if (cboTrangThaiLayMau.SelectedIndex == 1 && radCheDoBarcode.Checked)
                                        {
                                            var data = (DataTable)gcChuaLayMau.DataSource;
                                            if (data.Rows.Count > 0)
                                            {
                                                for (int c = 0; c < data.Rows.Count; c++)
                                                {
                                                    manhomloaiMau = data.Rows[c]["MaNhomLoaiMau"].ToString().Trim();
                                                    var maTiepNhan = data.Rows[c]["MaTiepNhan"].ToString().Trim();
                                                    var tuInKhiQuet = int.Parse(data.Rows[c]["TuInBarCodeKhiQuet"].ToString().Trim());
                                                    if (tuInKhiQuet == 1 && !listChuaLayMau.Contains(manhomloaiMau) && maTiepNhan.Equals(matiepNhanChiTiet))
                                                    {
                                                        listMauInbarcode.Add(manhomloaiMau);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (listMauInbarcode.Count > 0)
                                    {
                                        ShowMessage("Thực hiện gửi dữ liệu đến máy in barcode.....");
                                        PrintBarcode(lstMatiepnhan, listMauInbarcode, false, tgThucHienLayMau);
                                    }
                                }
                            }

                            if (chkInPhieuHen.Checked)
                            {
                                foreach (var strMaTiepNhan in lstMatiepnhan)
                                {
                                    ShowMessage(string.Format("In phiếu hẹn: {0}", strMaTiepNhan));
                                    InPhieuHen(strMaTiepNhan);
                                }
                            }

                            if (objKhuLayMau.NhapDanhSachUserLayMau)
                            {
                                ShowMessage(string.Format("BÀN LẤY MẪU: {0} - Số TT: {1}", banLayMau, soTTLayMau));
                            }
                            else
                                ShowMessage("");

                            banLayMau = 0;
                            soTTLayMau = 0;
                        }
                        else
                        {
                            CustomMessageBox.MSG_Information_OK(string.Format("Số lượng mẫu đã đến giới hạn lấy. Vui lòng chờ đến {0} để tiếp tục", objKiemSoatLayMau.TGKhoa.AddMinutes(objKhuLayMau.Sophutgioihanlaymau).ToString("HH:mm:ss fff")));
                        }
                    }
                    CustomMessageBox.CloseAlert();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.CloseAlert();
                CustomMessageBox.MSG_Error_OK(ex.Message);
            }
        }
        private void UpdateTrangThaiVeHIS(List<BenhNhanInfoForHIS> lst)
        {
            foreach (var item in lst)
            {
                var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals(item.Hisproviderid)).FirstOrDefault();
                if (item.Hisproviderid.Equals((int)HisProvider.ISofH) || item.Hisproviderid.Equals((int)HisProvider.VNPTMN))
                {
                    //Gọi về his nhận mẫu
                    _iHisData.LISCheckOrder(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, item);
                }
                else if (item.Hisproviderid == (int)HisProvider.DH_API || item.Hisproviderid == (int)HisProvider.DH_DHG)
                {
                    var hisInfoparaInfoList = new List<HisParaGetList>();
                    foreach (var itmChiDinh in item.ChiDinh)
                    {
                        hisInfoparaInfoList.Add(new HisParaGetList()
                        {
                            IDChiDinh = itmChiDinh.IdChiTiet,
                            IDChiDinhDichVu = itmChiDinh.IDDichVuChiDinh,
                            SoPhieuChiDinh = itmChiDinh.SoPhieuChiDinh,
                            MaBenhAn = item.Bn_id,
                            IDGiayto = item.Giayto_id,
                            MaXetNghiemLIS = itmChiDinh.TestCode,
                            MaTiepNhanLIS = item.Matiepnhan,
                            NgayTiepNhan = item.Ngaytiepnhan,
                            NoiTru = item.Noitru,
                            TrangThai = 1,
                            TrangThaiHL7 = OrderStatus.OrderRecieved,
                            IDBangKe = itmChiDinh.Bangkeid,
                            IDUserThucHien = itmChiDinh.MaNhanVienThucHien,
                            NgayChiDinh = itmChiDinh.Thoigiangui,
                            TenDichVu = itmChiDinh.TenXN_His,
                            ThoiGianThucHien = itmChiDinh.Thoigianxacnhan,
                            IDUserLayMau = itmChiDinh.NguoiLayMauHIS,
                            ThoiGianLayMau = itmChiDinh.ThoiGianLayMau,
                            MaDichVu = itmChiDinh.MaXN_His
                        });
                    }
                    var para = hisInfoparaInfoList
                        .GroupBy(x => new { x.SoPhieuChiDinh, x.NgayChiDinh, x.IDUserThucHien })
                        .Select(g => new { g.Key.SoPhieuChiDinh, g.Key.NgayChiDinh, g.Key.IDUserThucHien }).ToList();
                    hisInfoparaInfoList = new List<HisParaGetList>();
                    foreach (var itemCollect in para)
                    {
                        hisInfoparaInfoList.Add(new HisParaGetList { SoPhieuChiDinh = itemCollect.SoPhieuChiDinh, NgayChiDinh = itemCollect.NgayChiDinh, IDUserThucHien = itemCollect.IDUserThucHien });
                    }
                    _iHisService.LISCheck(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, hisInfoparaInfoList);
                }
            }
        }
        private void UpdateTrangThaiVaTGHen(List<string> lstMatiepnhan)
        {

            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT == (int)enumGioTinhThucHien.ThoiGianLayMau)
            {
                _iPatient.Update_ThoiGianThucHienXN(string.Join(",", lstMatiepnhan));
                _iPatient.Update_ThoiGianThucHienXN_Nhom(string.Join(",", lstMatiepnhan),
                    CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT);
            }
        }
        private void btnChoLayMauXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.ExportToExcel.Export(gvDanhSach);
        }
        string barcodeScan = "";
        private void btnLayMau_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle < 0)
                return;

            barcodeScan = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
            ShowMessage(string.Format("Thực hiện duyệt lấy mẫu ................"));
            DuyetLayMau(true);
            if (string.IsNullOrEmpty(txtBarcode.Text))
                txtBarcode.Text = barcodeScan;
            cboTrangThaiLayMau.SelectedIndexChanged -= cboTrangThaiLayMau_SelectedIndexChanged;
            cboTrangThaiLayMau.SelectedIndex = 0;
            Get_DanhSachBenhNhan(txtBarcode.Text);
            if (CommonAppVarsAndFunctions.WorkingHis == TPH.Data.HIS.HISDataCommon.HisProvider.PTT_API)
                UpLoadThoiGianhenTraKQ();
            cboTrangThaiLayMau.SelectedIndexChanged += cboTrangThaiLayMau_SelectedIndexChanged;
            txtBarcode.Focus();
            txtBarcode.SelectAll();
            CustomMessageBox.CloseAlert();
        }

        private void DuyetLayMau(bool fromclick = false)
        {
            if ((!string.IsNullOrEmpty(txtBarcode.Text) && gvDanhSach.FocusedRowHandle > -1) || (fromclick && gvDanhSach.FocusedRowHandle > -1))
            {
                if (radCheDoSHS.Checked)
                {
                    barcodeScan = gvDanhSach.GetFocusedRowCellValue(colDS_SoHoSoHis).ToString();
                }
                else
                {
                    barcodeScan = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                }
                UpdateLayMau(barcodeScan);
                _iPatient.Insert_Update_KiemSoatLayMau(objKiemSoatLayMau.MaNguoiDung, objKiemSoatLayMau.DanhSachCode, objKiemSoatLayMau.TGGianBatDau, objKiemSoatLayMau.TGKhoa, objKiemSoatLayMau.DangKhoa);


            }
        }
        public void UpLoadThoiGianhenTraKQ()
        {
            if (gvMauDaLay.RowCount > 0)
            {
                var paraList = new List<HisParaGetList>();

                for (int i = 0; i < gvMauDaLay.RowCount; i++)
                {
                    if (gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaDichVu) != null)
                    {
                        if (!string.IsNullOrEmpty(gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaDichVu).ToString()))
                        {
                            var maXNHIS = gvMauDaLay.GetRowCellValue(i, colChiDinhLis_MaXnHis).ToString();
                            var RIdChiDinhChiTiet = gvMauDaLay.GetRowCellValue(i, colChiDinhLis_RIdChiDinhChiTiet).ToString();
                            var RidChiDinh = gvMauDaLay.GetRowCellValue(i, colChiDinhLis_RIdChiDinhHis).ToString();
                            var RSoPhieuYeuCau = gvMauDaLay.GetRowCellValue(i, colDaLayMau_RSoPhieuYeuCau).ToString();
                            var MaTiepNhan = gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaTiepNhan).ToString();
                            var TGHenTra = (string.IsNullOrEmpty(gvMauDaLay.GetRowCellValue(i, colDaLayMau_GioHenTraKetQua).ToString()) ? (DateTime?)null : DateTime.Parse(gvMauDaLay.GetRowCellValue(i, colDaLayMau_GioHenTraKetQua).ToString()));
                            /*
                            "CodeHeader": "1908130042",
                              "ServiceCode": "CLS.XN.0025",
                              "SlipPrintedDetailIdline": "31e28f25-4fef-49f6-9ba5-505bdc6f42af",
                              "ReceptionNumber": "Số tiếp nhận của LIS",
                              "AppointmentDate": "2019/08/12 15:30"
                          */
                            paraList.Add(
                     new HisParaGetList
                     {
                         SoPhieuChiDinh = RSoPhieuYeuCau,
                         IDChiDinhDichVu = RidChiDinh,
                         IDChiDinh = RIdChiDinhChiTiet,
                         MaXetNghiemLIS = maXNHIS,
                         MaTiepNhanLIS = MaTiepNhan,
                         NgayHenTraKQ = TGHenTra
                     });
                        }
                    }
                }
                var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => x.HisID == CommonAppVarsAndFunctions.WorkingHis).FirstOrDefault();
                Task.Factory.StartNew(() =>
                {
                    _iHisService.Update_TGHenTraKetQua(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, paraList);
                });
            }
        }
        private void gvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    LayChiTietMau();
        }
        private void gvDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex > -1)
            //{
            //    var ngayTiepNhan = DateTime.Parse(gvDanhSach.Rows[e.RowIndex].Cells[colDS_NgayTiepNhan).ToString(););
            //    var soHoSo = gvDanhSach.Rows[e.RowIndex].Cells[colDS_SoHoSoHis).ToString();
            //    Get_DanhSachHenTraKetQua(string.Empty, soHoSo, ngayTiepNhan);
            //}
        }
        private void Get_TrangThaiLayMau()
        {
            lblMsg.Text = string.Empty;
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var statusTQ = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiLayMauTQ).ToString();
                var statusVS = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiLayMauVS).ToString();
                GetLableTitle(statusTQ, statusVS);
            }
        }
        private void FrmLayMau_Load(object sender, EventArgs e)
        {
            var objCauHinhLuoiKQ = _iSysConfig.lstThongTinHienThi(HienthiConstants.DanhSachBNLayMau);
            if (objCauHinhLuoiKQ != null)
            {
                if (objCauHinhLuoiKQ.Count > 0)
                {
                    foreach (GridColumn item in gvDanhSach.Columns)
                    {
                        var colFind = objCauHinhLuoiKQ.Where(x => x.Idhienthi.Equals(item.Name, StringComparison.OrdinalIgnoreCase));
                        if (colFind.Any())
                        {
                            var colInfo = colFind.First();
                            item.Visible = colInfo.Hienthi;
                            item.Caption = colInfo.Mota;
                            item.Width = colInfo.Dorong;
                            if (colInfo.Hienthi && colInfo.Sapxep > 0)
                            {
                                item.VisibleIndex = colInfo.Sapxep;
                            }
                        }
                        item.FieldName = item.FieldName.ToLower();
                    }
                }
                else
                    ControlExtension.SetLowerCaseForXGridColumns(gvDanhSach);
            }
            else
                ControlExtension.SetLowerCaseForXGridColumns(gvDanhSach);

            ControlExtension.SetLowerCaseForXGridColumns(gvChuaLayMau);
            ControlExtension.SetLowerCaseForXGridColumns(gvMauDaLay);
            dtpNgayChiDinh.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpDenNgayChiDinh.Value = CommonAppVarsAndFunctions.ServerTime;
            Load_DanhSachCauHinhMayin();
            Load_KiemSoatLayMau();
            _PainterChuaLayMau = new GridSkinElementsPainter(gvChuaLayMau);
            _PainterDaLayMau = new GridSkinElementsPainter(gvMauDaLay);
            chkTuInbarcode.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryAutoPrintBarcode_OnGetSample) == "1";
            Load_XnGuiMau();
            Load_DSKhuVuc();
            //  chkLayMauKhiQuet.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryAutoCompleteGetSample_OnGetSample) == "1";
            radCheDoSHS.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo;
            colDS_SoHoSoHis.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo;
            ucSearchLookupEditor_Location1.Load_DonVi(string.Empty);
            if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo)
                radCheDoBarcode.Checked = true;
            else
                radCheDoBarcode.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistrySearchByPIDAndLisCode) == "1";

            chkInPhieuHen.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistryPrintReturnTicket) == "1";

            objKhuLayMau = _iSysConfig.Get_Info_dm_khulaymau_Theomaytinh(Environment.MachineName);
            chkInPhieuHen.Visible = objKhuLayMau.CoPhieuHen;
            btnShowPhieuHen.Visible = objKhuLayMau.CoPhieuHen;
            if (!chkInPhieuHen.Visible)
                chkInPhieuHen.Checked = false;

            if (!string.IsNullOrEmpty(objKhuLayMau.Tenkhulaymau))
                lblTitle.Text = string.Format("{0}", objKhuLayMau.Tenkhulaymau.ToUpper());
            if (objKhuLayMau.Gioihanlaymau > 0)
            {
                lblCount.Text = string.Format("{0}/{1}", objKiemSoatLayMau.DanhSachCode.Count, objKhuLayMau.Gioihanlaymau);
            }
            else
            {
                lblStatus.Visible = false;
                lblCount.Visible = false;
            }
            pnNguoiLayMau.Visible = objKhuLayMau.ChonNguoiLayMau;
            if (pnNguoiLayMau.Visible)
            {
                ucSearchLookupEditor_NguoiDungDKLayMau1.IDKhuLayMau = objKhuLayMau.Idkhulaymau;
                ucSearchLookupEditor_NguoiDungDKLayMau1.Load_NhanVienDKLayMau();
            }
            ControlExtension.BindDataToCobobox(_iSysConfig.Data_DanhMucTinhTrangMau(0), ref cboLyDo, "MaTinhTrang", "MaTinhTrang", "MaTinhTrang,TinhTrangMau", "45,150", txtLyDo, 1);
            cboLyDo.SelectedIndexChanged += cboLyDo_SelectedIndexChanged;
            gbHentraKQ.Size = new Size(0, 0);
            ucGioHenTraKetQua1.LoadCauHinh();
            ucGioHenTraKetQua1.InGioHen = objKhuLayMau.InGiohen;
            //Khóa chức năng n=in barcode tự động
            chkTuInbarcode.Checked = false;
            chkTuInbarcode.Visible = false;
            pnCapNhatGioLayMau.Visible = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionUpdateCollectTime);
            txtBarcode.Focus();
        }
        private void cboLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLyDo.SelectedIndex > -1)
            {
                var value = cboLyDo.SelectedValue.ToString();
                txtLyDo.ReadOnly = !value.Equals("lydokhac", StringComparison.OrdinalIgnoreCase);
            }
            else
                txtLyDo.ReadOnly = true;
        }
        private void Load_DanhSachCauHinhMayin()
        {
            var data = _iSysConfig.Data_DanhSach_CauHinhMayInbarcode(Environment.MachineName, 0, 1);
            if (data.Rows.Count == 0)
            {
                var dr = data.NewRow();
                dr["IDMay"] = "0";
                dr["TenMay"] = "Barcode tiêu chuẩn";
                data.Rows.Add(dr);
                data.AcceptChanges();
            }
            var idMay = _registryExtension.ReadRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample);

            cboMayInTem.DataSource = data;
            cboMayInTem.ValueMember = "IDMay";
            cboMayInTem.DisplayMember = "TenMay";
            cboMayInTem.SelectedValue = string.IsNullOrEmpty(idMay) ? "0" : idMay;

            cboMayInTem.SelectedIndexChanged += CboMayInTem_SelectedIndexChanged;
            Load_PrintConfig();
        }

        private void CboMayInTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_PrintConfig();
        }

        private void ShowMessage(string inputMess)
        {
            if (InvokeRequired)
            {
                lblMsgOrder.Invoke((MethodInvoker)delegate ()
                {
                    lblMsgOrder.Text = inputMess;
                    lblMsgOrder.Refresh();
                    //lblMsgOrder.Visible = true;
                    return;
                });
            }
            lblMsgOrder.Text = inputMess;
            lblMsgOrder.Refresh();
            //lblMsgOrder.Visible = true;
        }
        private void dtpNgayChiDinh_ValueChanged(object sender, EventArgs e)
        {
        }
        private void TimBenhNhan(string searchFilter)
        {
            if (gcDanhSach.DataSource != null)
            {
                gvDanhSach.ActiveFilter.Clear();
                gvDanhSach.ActiveFilter.NonColumnFilter = string.Format("seq = '{0}' or sophieuyeucau ='{0}' or mabn = '{0}' or tenbn like '%{0}%'", WorkingServices.EscapeLikeValue(searchFilter));
            }
        }
        private void TimTrangThai(int status)
        {
            if (gcDanhSach.DataSource != null)
            {
                if (status > 0)
                    colDS_TrangThaiNhanMauTQ.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(string.Format("{0} = '{1}'", colDS_TrangThaiNhanMauTQ.FieldName, status));
                else
                    colDS_TrangThaiNhanMauTQ.FilterInfo = null;
            }
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    var barcodeMain = txtBarcode.Text;
                    if (string.IsNullOrEmpty(txtBarcode.Text) && radCheDoSHS.Checked)
                    {
                        CustomMessageBox.MSG_Information_OK("Hãy nhập số hồ sơ.");
                        gcDanhSach.DataSource = null;
                        SetNullGridDetailData();
                        e.Handled = true;
                        return;
                    }
                    var sampleCode = (string.IsNullOrEmpty(barcodeMain) ? string.Empty : barcodeMain.Replace(WorkingServices.SplitSampleCode(barcodeMain), ""));
                    txtBarcode.Text = (string.IsNullOrEmpty(sampleCode) ? barcodeMain : barcodeMain.Replace(sampleCode, "").Trim());

                    if (chkLayMauKhiQuet.Checked)
                    {
                        cboTrangThaiLayMau.SelectedIndexChanged -= cboTrangThaiLayMau_SelectedIndexChanged;
                        cboTrangThaiLayMau.SelectedIndex = 0;

                        if (string.IsNullOrEmpty(txtBarcode.Text))
                            Get_DanhSachBenhNhan(txtBarcode.Text);

                        if (!string.IsNullOrEmpty(txtBarcode.Text))
                        {
                            Get_DanhSachBenhNhan(txtBarcode.Text);
                            if (gvDanhSach.RowCount > 0)
                            {
                                CheckWithSampleCode(sampleCode);
                                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "gvDanhSach.RowCount > 0");

                                var barcode = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                                LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "_iPatient.GetOrderHistory(barcode)");
                                if (gvDanhSach.RowCount > 1 && radCheDoBarcode.Checked)
                                {
                                    LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "gvDanhSach.RowCount > 1");
                                    LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "TimTrangThai(3)");
                                    TimTrangThai(3);

                                    if (gvDanhSach.RowCount > 1)
                                    {
                                        LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "gvDanhSach.RowCount > 1");
                                        CustomMessageBox.CloseAlert();
                                        CustomMessageBox.MSG_Information_OK("Hãy chọn barcode để lấy mẫu!");
                                    }
                                }
                                //không else chổ này nhé---đọc kỹ code trên
                                if (gvDanhSach.RowCount == 1 || (radCheDoSHS.Checked && gvChuaLayMau.RowCount > 0))
                                {
                                    LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "gvDanhSach.RowCount == 1");

                                    var status = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiLayMauTQ).ToString();

                                    if (!status.Equals("4") || (radCheDoSHS.Checked && gvChuaLayMau.RowCount > 0))
                                    {
                                        LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "!status.Equals(4) || (radCheDoSHS.Checked && gvChuaLayMau.RowCount > 0)");

                                        barcodeScan = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                                        ShowMessage("Duyệt lấy mẫu.........");
                                        DuyetLayMau();
                                        LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "DuyetLayMau();");
                                        cboTrangThaiLayMau.SelectedIndex = 0;
                                        LogService.RecordLogError(CommonAppVarsAndFunctions.UserID, "LayMau", null, 0, "Get_DanhSachBenhNhan(false, txtBarcode.Text);");
                                        Get_DanhSachBenhNhan(txtBarcode.Text);
                                        if (!string.IsNullOrEmpty(barcodeScan) && !radCheDoSHS.Checked)
                                        {
                                            gvDanhSach.FocusedRowHandle = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, barcodeScan);
                                        }
                                        CustomMessageBox.CloseAlert();
                                        if (CommonAppVarsAndFunctions.WorkingHis == TPH.Data.HIS.HISDataCommon.HisProvider.PTT_API)
                                            UpLoadThoiGianhenTraKQ();
                                    }
                                }
                                else if (gvDanhSach.RowCount == 0)
                                {
                                    TimTrangThai(0);
                                    if (!string.IsNullOrEmpty(txtBarcode.Text))
                                    {
                                        TimBenhNhan(txtBarcode.Text);
                                    }
                                }
                            }
                            else
                            {
                                lblMsgOrder.Text = "";
                                var barcode = txtBarcode.Text;
                                CustomMessageBox.MSG_Information_OK("Không tìm thấy chỉ định, vui lòng kiểm tra lại");
                            }
                        }
                        cboTrangThaiLayMau.SelectedIndexChanged += cboTrangThaiLayMau_SelectedIndexChanged;
                    }
                    else
                    {
                        lblMsgOrder.Text = "";
                        Get_DanhSachBenhNhan(txtBarcode.Text);
                    }
                    CheckWithSampleCode(sampleCode);
                    txtBarcode.Text = barcodeMain;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();

                    e.Handled = true;
                }
                CustomMessageBox.CloseAlert();
            }
            catch
            {
                CustomMessageBox.CloseAlert();
            }
        }
        //private int Search_Position(string barcode)
        //{
        //    var posFind = bvChoLayMau.BindingSource.Find("SEQ", barcode);
        //    if (posFind == -1)
        //        posFind = bvChoLayMau.BindingSource.Find("sophieuyeucau", barcode);
        //    if (posFind == -1)
        //        posFind = bvChoLayMau.BindingSource.Find("mabn", barcode);
        //    return posFind;
        //}
        private void InPhieuHen(string matiepnhan)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                for (int i = 0; i < gvDanhSach.RowCount; i++)
                {
                    var rMatiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                    if (rMatiepNhan.Equals(matiepnhan.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        var ngayTiepNhan = DateTime.Parse(gvDanhSach.GetRowCellValue(i, colDS_NgayTiepNhan).ToString());
                        var barcode = gvDanhSach.GetRowCellValue(i, colDS_Barcode).ToString();
                        Get_DanhSachHenTraKetQua(string.Empty, string.Empty, ngayTiepNhan, barcode);
                        ucGioHenTraKetQua1.SoTTLayMau = soTTLayMau;
                        ucGioHenTraKetQua1.ThoiGianLayMau = tgThucHienLayMau;
                        ucGioHenTraKetQua1.InPhieuHen(false);
                        break;
                    }
                }
            }
        }
        private void Update_henTraKQ(DataTable dtPrint)
        {
            foreach (DataRow dr in dtPrint.Rows)
            {
                var thoiGianCoKetqua = dr["ThoiGianCoKetQua"].ToString();
                string matiepNhan = dr["MaTiepNhan"].ToString();
                string maNhom = dr["MaNhom"].ToString();
                var tgtra = DateTime.Parse(dr["GioTraKQ"].ToString());
                var isXetNghiem = bool.Parse(dr["XetNghiem"].ToString());
                string gioTra = string.Format("Trả KQ: {0}", tgtra.ToString("HH:mm dd/MM/yyyy"));
                _iTestResult.CapNhat_GhiChuHenTraKQ(matiepNhan, (isXetNghiem ? maNhom : string.Empty), (isXetNghiem ? string.Empty : maNhom), true, gioTra, tgtra, thoiGianCoKetqua);
            }
        }
        private void btnInBarcode_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var maTiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                PrintBarcode(new List<string> { maTiepNhan }, null, true);
            }
        }
        bool haveClick = false;
        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }
        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }
        private void txtSoLuongBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlExtension.KeyNumber(e, false);
        }
        private void btnLoadDanhSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text) && radCheDoSHS.Checked)
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập số hồ sơ.");
                gcDanhSach.DataSource = null;
                SetNullGridDetailData();
                return;
            }
            Get_DanhSachBenhNhan(txtBarcode.Text);
        }
        private void chkTuInbarcode_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                chkTuInbarcode.AutoCheck = true;
            }
        }
        private void btnCapNhatGioLayMau_Click(object sender, EventArgs e)
        {
            if (gvMauDaLay.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Cập nhật thời gian lấy mẫu cho các xét nghiệm được chọn?{0}Thời gian mới:{1}", Environment.NewLine, dtpCapNhatGioLayMau.Value.ToString("HH:mm:ss dd/MM/yyy"))))
                {
                    var lstMatiepnhan = new List<string>();
                    foreach (var itm in gvMauDaLay.GetSelectedRows())
                    {
                        if (gvMauDaLay.GetRowCellValue(itm, colDaLayMau_MaTiepNhan) != null)
                        {
                            var obj = new CapNhatThaoTacMau();
                            obj.Idthaotac = 0;
                            obj.Matiepnhan = WorkingServices.ObjecToString(gvMauDaLay.GetRowCellValue(itm, colDaLayMau_MaTiepNhan));
                            obj.Maxn = WorkingServices.ObjecToString(gvMauDaLay.GetRowCellValue(itm, colDaLayMau_MaDichVu));
                            obj.Nguoithuchiencu = WorkingServices.ObjecToString(gvMauDaLay.GetRowCellValue(itm, colDaLayMau_NguoiLayMau));
                            obj.Nguoithuchienmoi = CommonAppVarsAndFunctions.UserID;
                            obj.Pcthuchiencu = WorkingServices.ObjecToString(gvMauDaLay.GetRowCellValue(itm, colDaLayMau_PCLayMau));
                            obj.Pcthuchienmoi = Environment.MachineName;
                            obj.Tgcu = WorkingServices.ConvertDate(WorkingServices.ObjecToString(gvMauDaLay.GetRowCellValue(itm, colDaLayMau_TGLayMau)));
                            obj.Tgmoi = dtpCapNhatGioLayMau.Value;
                            _iPatient.Update_ThoigianThaoTacMau(obj);
                            if (!lstMatiepnhan.Where(x => x.Equals(obj.Matiepnhan)).Any())
                            {
                                lstMatiepnhan.Add(obj.Matiepnhan);
                            }
                        }
                    }
                    if (lstMatiepnhan.Count > 0)
                    {
                        foreach (var maTiepNhan in lstMatiepnhan)
                        {
                            //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
                            _iPatient.Update_TrangThaiLayMau(maTiepNhan);
                        }
                    }
                    LayChiTietMau();
                }
            }
        }
        //---------------===================================----------------------------
        #region Sự kiện cho lưới chưa nhận mẫu
        private void gvChuaLayMau_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.Name == colChuaLayMau_TenNhomLoaiMau.Name && info.GroupText != null && info.Level == 1)
            {
                int handle = gvChuaLayMau.GetChildRowHandle((gvDanhSach.SelectedRowsCount > 0 && gvDanhSach.IsMultiSelect ? e.RowHandle - 1 : e.RowHandle), 0);
                string text = gvChuaLayMau.GetGroupRowDisplayText(e.RowHandle);
                if (!string.IsNullOrEmpty(info.GroupValueText))
                {
                    text = text.Replace(String.Format("- {0}: ,", colChuaLayMau_NoiDungGhiChu.Caption), ",").Replace(String.Format("{0}:", colChuaLayMau_TenNhomLoaiMau.Caption), String.Format("{0}:        ", colChuaLayMau_TenNhomLoaiMau.Caption)).Replace(" - ", "\t-\t").Replace(", ", "\t-\t")
                        .Replace(info.GroupValueText, LabResultService.KiemTraThemKhoatrangChoTenLoaiMau(info.GroupValueText));
                }
                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;

                _PainterChuaLayMau.GroupRow.DrawGroupRowBackground(info);
                _PainterChuaLayMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();

                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                bool haveGhiChu = text.Contains(String.Format("-\t{0}:", colChuaLayMau_NoiDungGhiChu.Caption));
                Point textPos = GetTextPos(e, text, info);
                e.Graphics.DrawRectangle(e.Cache.GetPen(gvChuaLayMau.Appearance.GroupRow.BackColor), e.Bounds);
                e.Graphics.DrawString(text
                    , e.Appearance.Font, e.Cache.GetSolidBrush((haveGhiChu ? Color.DarkRed : e.Appearance.ForeColor)), textPos);
                //"Ống mẫu:"
                Point imgPos = GetImgPos(info,
                    textPos.X + (int)e.Graphics.MeasureString(colChuaLayMau_TenNhomLoaiMau.Caption, e.Appearance.Font).Width, Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Width));
                if (gvChuaLayMau.GetRowCellValue(handle, colChuaLayMau_HinhOngMau) != null && !string.IsNullOrEmpty(gvChuaLayMau.GetRowCellValue(handle, colChuaLayMau_HinhOngMau).ToString()))
                {
                    Image img = (Bitmap)(gvChuaLayMau.GetRowCellValue(handle, colChuaLayMau_HinhOngMau));
                    imgPos.Y = e.Bounds.Location.Y + e.Bounds.Height / 2 - img.Height / 2 - 1;
                    e.Graphics.DrawImage(img, imgPos);
                }
                e.Handled = true;
            }
            else if (info.Column.Name == colChuaLayMau_TenLoaiMau.Name && info.GroupText != null)
            {
                info.GroupText = info.GroupText.Replace(", SL Mẫu: 1", "")
                    .Replace(", SL Mẫu: 2", "").Replace(", SL Mẫu: 3,", "").Replace(", SL Mẫu: 4", "")
                    .Replace(", SL Mẫu: 5", "").Replace(", SL Mẫu: 6", "").Replace(", SL Mẫu: 7", "");
            }
            else if (info.Column.Name == colChuaLayMau_NoiDuKienThucHien.Name && info.GroupText != null && info.Level == 0)
            {
                // info.GroupText = info.GroupText.Replace(String.Format("- {0}: ,", colDaLayMau_NoiDungGhiChu.Caption), ",").Replace("  ,", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",", ", ");

                string text = gvChuaLayMau.GetGroupRowDisplayText(e.RowHandle);
                var arr = text.Split(new string[] { String.Format("- {0}", colChuaLayMau_NoiDungGhiChu.Caption) }, StringSplitOptions.RemoveEmptyEntries);
                text = arr[0];

                _PainterChuaLayMau.GroupRow.DrawGroupRowBackground(info);
                _PainterChuaLayMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();
                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;
                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                Point textPos = GetTextPos(e, text, info);
                // e.Graphics.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128)), e.Bounds);
                e.Graphics.DrawString(text, new Font(e.Appearance.Font.FontFamily.Name, 13, FontStyle.Bold), e.Cache.GetSolidBrush(Color.DarkGreen), textPos);
                e.Handled = true;
            }
        }
        private Point GetTextPos(DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e, string text, GridGroupRowInfo info)
        {
            int height = Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height);
            Point textPos = new Point(info.SelectorInfo.Bounds.Right + 5, e.Bounds.Location.Y + (e.Bounds.Height - height) / 2);
            return textPos;
        }
        private Point GetImgPos(GridGroupRowInfo info, int textX, int textWidth)
        {
            Point imgPos = new Point(textX + 5, info.DataBounds.Y);
            return imgPos;
        }
        Int32 countDistinctChuaLayMau = 0;
        List<string> listChuaLayMau = new List<string>();
        List<string> listChuaLayMau_BSChiDinh = new List<string>();
        List<string> listChuaLayMau_BanLayMau = new List<string>();
        List<string> listChuaLayMau_GhiChuLayMau = new List<string>();
        string bsChiDinh = string.Empty;
        private void gvChuaLayMau_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item == gvChuaLayMau.GroupSummary.Where(x => x.FieldName.Equals("MaLoaiMauSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctChuaLayMau = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listChuaLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            countDistinctChuaLayMau++;
                            listChuaLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctChuaLayMau;
                    listChuaLayMau.Clear();
                }
            }
            else if (e.Item == gvChuaLayMau.GroupSummary.Where(x => x.FieldName.Equals("LoaiMauPhuSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctChuaLayMau = 0;
                    listChuaLayMau = new List<string>();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!string.IsNullOrEmpty(e.FieldValue.ToString()))
                        {
                            if (!listChuaLayMau.Contains(e.FieldValue.ToString().Trim()))
                            {
                                countDistinctChuaLayMau++;
                                listChuaLayMau.Add(e.FieldValue.ToString().Trim());
                            }
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctChuaLayMau;
                    listChuaLayMau.Clear();
                }
            }
            else if (e.Item == gvChuaLayMau.GroupSummary.Where(x => x.FieldName.Equals("BSChiDinh", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listChuaLayMau_BSChiDinh.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listChuaLayMau_BSChiDinh.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listChuaLayMau_BSChiDinh.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(",", listChuaLayMau_BSChiDinh);
                    listChuaLayMau_BSChiDinh.Clear();
                }
            }
            else if (e.Item == gvChuaLayMau.GroupSummary.First(x => x.FieldName.Equals("BanLayMauSeq", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listChuaLayMau_BanLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        var lst = e.FieldValue.ToString().Trim().Split('_')[0];
                        if (!listChuaLayMau_BanLayMau.Contains(lst))
                        {
                            listChuaLayMau_BanLayMau.Add(lst);
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join("|", listChuaLayMau_BanLayMau);
                    listChuaLayMau_BanLayMau.Clear();
                }
            }
            else if (e.Item == gvChuaLayMau.GroupSummary.First(x => x.FieldName.Equals("NoiDungGhiChu", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listChuaLayMau_GhiChuLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listChuaLayMau_GhiChuLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listChuaLayMau_GhiChuLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(", ", listChuaLayMau_GhiChuLayMau);
                    listChuaLayMau_GhiChuLayMau.Clear();
                }
            }
        }
        private void chkChiTietChuaLayMau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChiTietChuaLayMau.Checked)
            {
                gvChuaLayMau.ExpandAllGroups();

            }
            else
            {
                gvChuaLayMau.CollapseAllGroups();
                if (gvDanhSach.SelectedRowsCount > 0)
                {
                    gvChuaLayMau.ExpandGroupLevel(0);
                    gvChuaLayMau.ExpandGroupLevel(1);
                }
                else
                    gvChuaLayMau.ExpandGroupLevel(0);

            }
        }
        #endregion
        //---------------===================================----------------------------
        #region Sự kiện cho lưới đã lấy mẫu
        private void gvMauDaLay_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.Name == colDaLayMau_TenNhomLoaiMau.Name && info.GroupText != null && info.Level == 1)
            {
                int handle = gvMauDaLay.GetChildRowHandle((gvDanhSach.SelectedRowsCount > 0 && gvDanhSach.IsMultiSelect ? e.RowHandle - 1 : e.RowHandle), 0);
                string text = gvMauDaLay.GetGroupRowDisplayText(e.RowHandle);
                text = text.Replace(String.Format("- {0}: ,", colDaLayMau_NoiDungGhiChu.Caption), ",").Replace(String.Format("{0}:", colDaLayMau_TenNhomLoaiMau.Caption), String.Format("{0}:        ", colDaLayMau_TenNhomLoaiMau.Caption)).Replace(" - ", "\t-\t").Replace(", ", "\t-\t")
                        .Replace(info.GroupValueText, LabResultService.KiemTraThemKhoatrangChoTenLoaiMau(info.GroupValueText));
                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;

                _PainterDaLayMau.GroupRow.DrawGroupRowBackground(info);
                _PainterDaLayMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();

                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                bool haveGhiChu = text.Contains(String.Format("-\t{0}:", colDaLayMau_NoiDungGhiChu.Caption));
                Point textPos = GetTextPos(e, text, info);
                e.Graphics.DrawRectangle(e.Cache.GetPen(gvMauDaLay.Appearance.GroupRow.BackColor), e.Bounds);
                e.Graphics.DrawString(text
                    , e.Appearance.Font, e.Cache.GetSolidBrush((haveGhiChu ? Color.DarkRed : e.Appearance.ForeColor)), textPos);

                Point imgPos = GetImgPos(info, textPos.X + (int)e.Graphics.MeasureString(colDaLayMau_TenNhomLoaiMau.Caption, e.Appearance.Font).Width
                    , Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Width));
                if (gvMauDaLay.GetRowCellValue(handle, colDaLayMau_HinhOngMau) != null && !string.IsNullOrEmpty(gvMauDaLay.GetRowCellValue(handle, colDaLayMau_HinhOngMau).ToString()))
                {
                    Image img = (Bitmap)(gvMauDaLay.GetRowCellValue(handle, colDaLayMau_HinhOngMau));
                    imgPos.Y = e.Bounds.Location.Y + e.Bounds.Height / 2 - img.Height / 2 - 1;
                    e.Graphics.DrawImage(img, imgPos);
                }
                e.Handled = true;
            }
            else if (info.Column.Name == colDaLayMau_TenLoaiMau.Name && info.GroupText != null)
            {
                info.GroupText = info.GroupText.Replace(", SL Mẫu: 1", "")
                    .Replace(", SL Mẫu: 2", "").Replace(", SL Mẫu: 3,", "").Replace(", SL Mẫu: 4", "")
                    .Replace(", SL Mẫu: 5", "").Replace(", SL Mẫu: 6", "").Replace(", SL Mẫu: 7", "");
            }
            else if (info.Column.Name == colDaLayMau_NoiDuKienThucHien.Name && info.GroupText != null && info.Level == 0)
            {
                // info.GroupText = info.GroupText.Replace(String.Format("- {0}: ,", colDaLayMau_NoiDungGhiChu.Caption), ",").Replace("  ,", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",", ", ");

                string text = gvMauDaLay.GetGroupRowDisplayText(e.RowHandle);
                var arr = text.Split(new string[] { String.Format("- {0}", colDaLayMau_NoiDungGhiChu.Caption) }, StringSplitOptions.RemoveEmptyEntries);
                text = arr[0];

                _PainterChuaLayMau.GroupRow.DrawGroupRowBackground(info);
                _PainterChuaLayMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();
                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;
                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                Point textPos = GetTextPos(e, text, info);
                // e.Graphics.DrawRectangle(e.Cache.GetPen(Color.FromArgb(255, 128, 128)), e.Bounds);
                e.Graphics.DrawString(text, new Font(e.Appearance.Font.FontFamily.Name, 13, FontStyle.Bold), e.Cache.GetSolidBrush(Color.DarkGreen), textPos);
                e.Handled = true;
            }
        }
        Int32 countDistinctDaLayMau = 0;
        List<string> listDaLayMau = new List<string>();
        List<string> listDaLayMau_NguoiLayMau = new List<string>();
        List<string> listDaLayMau_BanLayMau = new List<string>();
        List<string> listDaLayMau_GhiChuLayMau = new List<string>();
        private void gvMauDaLay_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item == gvMauDaLay.GroupSummary.Where(x => x.FieldName.Equals("MaLoaiMauSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctDaLayMau = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listDaLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            countDistinctDaLayMau++;
                            listDaLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctDaLayMau;
                    listDaLayMau.Clear();
                }
            }
            else if (e.Item == gvMauDaLay.GroupSummary.Where(x => x.FieldName.Equals("LoaiMauPhuSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctChuaLayMau = 0;
                    listChuaLayMau = new List<string>();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!string.IsNullOrEmpty(e.FieldValue.ToString()))
                        {
                            if (!listChuaLayMau.Contains(e.FieldValue.ToString().Trim()))
                            {
                                countDistinctChuaLayMau++;
                                listChuaLayMau.Add(e.FieldValue.ToString().Trim());
                            }
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctChuaLayMau;
                    listChuaLayMau.Clear();
                }
            }
            else if (e.Item == gvMauDaLay.GroupSummary.Where(x => x.FieldName.Equals("NguoiLayMau", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listDaLayMau_NguoiLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listDaLayMau_NguoiLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listDaLayMau_NguoiLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join("|", listDaLayMau_NguoiLayMau);
                }
            }
            else if (e.Item == gvMauDaLay.GroupSummary.First(x => x.FieldName.Equals("BanLayMauSeq", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listDaLayMau_BanLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        var lst = e.FieldValue.ToString().Trim().Split('_')[0];
                        if (!listDaLayMau_BanLayMau.Contains(lst))
                        {
                            listDaLayMau_BanLayMau.Add(lst);
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join("|", listDaLayMau_BanLayMau);
                }
            }
            else if (e.Item == gvMauDaLay.GroupSummary.First(x => x.FieldName.Equals("NoiDungGhiChu", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listDaLayMau_GhiChuLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listDaLayMau_GhiChuLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listDaLayMau_GhiChuLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(", ", listDaLayMau_GhiChuLayMau);
                    listDaLayMau_GhiChuLayMau.Clear();
                }
            }
        }
        private void chkChiTietDaLayMau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChiTietDaLayMau.Checked)
            {
                gvMauDaLay.ExpandAllGroups();
            }
            else
            {
                gvMauDaLay.CollapseAllGroups();
                if (gvDanhSach.SelectedRowsCount > 0)
                {
                    gvMauDaLay.ExpandGroupLevel(0);
                    gvMauDaLay.ExpandGroupLevel(1);
                }
                else
                    gvMauDaLay.ExpandGroupLevel(0);
            }
        }
        #endregion
        //---------------===================================----------------------------
        
        private void btnHuyLayMau_Click(object sender, EventArgs e)
        {
            if (gvMauDaLay.SelectedRowsCount > 0)
            {
                if (cboLyDo.SelectedIndex == -1)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập hoặc chọn lý do bỏ duyệt lấy mẫu!");
                    return;
                }
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy lấy mẫu cho các loại mẫu được chọn ?\n* Lưu ý: Chỉ có thể hủy mẫu đã lấy khi user được cấp quyền!"))
                {
                    var lstMatiepnhan = new List<string>();
                    bool ok = false;
                    List<string> listCapNhatLayMau = new List<string>();
                    var DaCapNhatHis = false;
                    var DaNhanMau = false;
                    var _tenChidinh = string.Empty;
                    var maChidinh = string.Empty;
                    var barcode = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                    var lstBoLayMau = new List<LayMauInfo>();
                    var lstnhatKyMau = new List<NHATKY_MAUXETNGHIEM>();
                    DateTime tgThucHien = C_Ultilities.ServerDate();
                    var loaiXetNghiem = -1;
                    var maloaiMau = string.Empty;
                    var maCapTren = string.Empty;
                    var profileID = string.Empty;
                    var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();
                    var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                    foreach (int i in gvMauDaLay.GetSelectedRows())
                    {
                        maChidinh = gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaDichVu) != null ? gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaDichVu).ToString() : "";
                        if (!string.IsNullOrEmpty(maChidinh))
                        {
                            DaCapNhatHis = gvMauDaLay.GetRowCellValue(i, colDaLayMau_DaCapNhatLayMauHIS) == null ? false : (bool)gvMauDaLay.GetRowCellValue(i, colDaLayMau_DaCapNhatLayMauHIS);
                            DaNhanMau = gvMauDaLay.GetRowCellValue(i, colDaLayMau_DaNhanMau) == null ? false : (bool)gvMauDaLay.GetRowCellValue(i, colDaLayMau_DaNhanMau);
                            _tenChidinh = gvMauDaLay.GetRowCellValue(i, colDaLayMau_TenDichVu) != null ? gvMauDaLay.GetRowCellValue(i, colDaLayMau_TenDichVu).ToString() : "";
                            if (!DaNhanMau)
                            {
                                if ((!DaCapNhatHis) || CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestDeleteGetSampleValided))
                                {
                                    var matiepnhan = (string)gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaTiepNhan);
                                    maloaiMau = gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaLoaiMau).ToString().Trim();
                                    loaiXetNghiem = int.Parse(gvMauDaLay.GetRowCellValue(i, colDaLayMau_LoaiXetNghiem).ToString().Trim());
                                    maCapTren = gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaXN_His).ToString().Trim();
                                    profileID = gvMauDaLay.GetRowCellValue(i, colDaLayMau_ProfileID).ToString().Trim();
                                    if (!lstMatiepnhan.Contains(matiepnhan))
                                    {
                                        lstMatiepnhan.Add(matiepnhan);
                                        GetDataForHL7ByMaTiepNhan(lstMaTiepNhanHL7, new GetUploadCondit
                                        {
                                            userID = CommonAppVarsAndFunctions.UserID,
                                            matiepnhan = matiepnhan,
                                            onlyValid = false,
                                            onlyPrinted = false,
                                            arrCatePrint = null,
                                            arrtestCodePrint = null,
                                            arrTestTypeID = new string[] { },
                                            frombackup = false,
                                            manualUpload = true,
                                            forStatus = true
                                        });
                                    }
                                    lstBoLayMau.Add(
                                             new LayMauInfo
                                             {
                                                 MaTiepNhan = matiepnhan,
                                                 TrangThai = enumThucHien.ChuaThucHien,
                                                 MaNhomLoaiMau = maloaiMau,
                                                 NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                                 Pcthuchien = Environment.MachineName,
                                                 CheckXacNhanHis = !CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestDeleteGetSampleValided),
                                                 Maxn = maChidinh,
                                                 IDKhuLayMau = idKhuLaymau,
                                                 ThoiGianLayMau = tgThucHien,
                                                 LoaiXetNghiem = loaiXetNghiem,
                                                 IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                                 MaCapTren = maCapTren,
                                                 ProfileId = profileID
                                             });
                                    lstnhatKyMau.Add(new NHATKY_MAUXETNGHIEM
                                    {
                                        Matiepnhan = matiepnhan,
                                        Maxn = maChidinh,
                                        Lydo = cboLyDo.SelectedValue.ToString(),
                                        NoiDungLydo = txtLyDo.Text,
                                        Nguoithuchien = CommonAppVarsAndFunctions.UserID,
                                        Pcthuchien = Environment.MachineName,
                                        Idthuchien = (int)TrangThaiThongTinXetNghiem.HuyLayMau,
                                        Maphanloaidichvu = ServiceType.ClsXetNghiem.ToString(),
                                        Maloaimau = maloaiMau,
                                        Thoigianthuchien = tgThucHien,
                                        IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau
                                    });
                                    //Thêm thông tin update HL7 về ISOFH
                                    AddInfoHL7(lstBnHL7Upate, lstMaTiepNhanHL7, matiepnhan, maChidinh, maCapTren, OrderStatus.OrderRecieved);
                                    //var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(matiepnhan));
                                    //if (bnExisted.Any())
                                    //{
                                    //    var bnInfo = bnExisted.FirstOrDefault();
                                    //    var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepnhan)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                                    //    chidinh.TrangThaiMau = OrderStatus.OrderRecieved;
                                    //    bnInfo.ChiDinh.Add(chidinh);
                                    //}
                                    //else
                                    //{
                                    //    var bnAdd = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepnhan)).First().CopyHISInfo();
                                    //    var chidinh = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(maChidinh) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).ToList();
                                    //    foreach (var itmChiDinh in chidinh)
                                    //    {
                                    //        itmChiDinh.TrangThaiMau = OrderStatus.OrderRecieved;
                                    //    }
                                    //    bnAdd.ChiDinh = chidinh;
                                    //    lstBnHL7Upate.Add(bnAdd);
                                    //}
                                }
                                else
                                {
                                    CustomMessageBox.MSG_Waring_OK(string.Format("Xét nghiệm: \"{0}\" đã xác nhận LẤY MẪU với HIS! Không thể hủy lấy mẫu.", _tenChidinh));
                                }
                            }
                            else
                                CustomMessageBox.MSG_Waring_OK(string.Format("Xét nghiệm: \"{0}\" đã NHẬN MẪU! Không thể hủy lấy mẫu.", _tenChidinh));
                        }
                    }
                    //Chưa lấy mẫu đủ
                    if (cboTrangThaiLayMau.SelectedIndex == 3 && radCheDoBarcode.Checked)
                    {
                        foreach (int i in gvChuaLayMau.GetSelectedRows())
                        {
                            maChidinh = gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaDichVu) != null ? gvChuaLayMau.GetRowCellValue(i, colChuaLayMau_MaDichVu).ToString() : "";
                            if (!string.IsNullOrEmpty(maChidinh))
                            {
                                var matiepnhan = (string)gvChuaLayMau.GetRowCellValue(i, colDaLayMau_MaTiepNhan);
                                maloaiMau = gvChuaLayMau.GetRowCellValue(i, colDaLayMau_MaLoaiMau).ToString().Trim();
                                loaiXetNghiem = int.Parse(gvMauDaLay.GetRowCellValue(i, colChuaLayMau_LoaiXetNghiem).ToString().Trim());
                                maCapTren = gvMauDaLay.GetRowCellValue(i, colDaLayMau_MaXN_His).ToString().Trim();
                                profileID = gvMauDaLay.GetRowCellValue(i, colDaLayMau_ProfileID).ToString().Trim();
                                if (!lstMatiepnhan.Contains(matiepnhan))
                                {
                                    lstMatiepnhan.Add(matiepnhan);
                                    GetDataForHL7ByMaTiepNhan(lstMaTiepNhanHL7, new GetUploadCondit
                                    {
                                        userID = CommonAppVarsAndFunctions.UserID,
                                        matiepnhan = matiepnhan,
                                        onlyValid = false,
                                        onlyPrinted = false,
                                        arrCatePrint = null,
                                        arrtestCodePrint = null,
                                        arrTestTypeID = new string[] { },
                                        frombackup = false,
                                        manualUpload = true,
                                        forStatus = true
                                    });
                                }
                                lstBoLayMau.Add(
                                                 new LayMauInfo
                                                 {
                                                     MaTiepNhan = matiepnhan,
                                                     TrangThai = enumThucHien.ChuaThucHien,
                                                     MaNhomLoaiMau = maloaiMau,
                                                     NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                                     Pcthuchien = Environment.MachineName,
                                                     CheckXacNhanHis = !CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestDeleteGetSampleValided),
                                                     Maxn = maChidinh,
                                                     LoaiXetNghiem = loaiXetNghiem,
                                                     IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                                     MaCapTren = maCapTren,
                                                     ProfileId = profileID

                                                 });
                                //Thêm thông tin update HL7 về ISOFH
                                AddInfoHL7(lstBnHL7Upate, lstMaTiepNhanHL7, matiepnhan, maChidinh, maCapTren, OrderStatus.OrderRecieved);
                                //var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(matiepnhan));
                                //if (bnExisted.Any())
                                //{
                                //    var bnInfo = bnExisted.FirstOrDefault();
                                //    var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepnhan)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                                //    chidinh.TrangThaiMau = OrderStatus.OrderRecieved;
                                //    bnInfo.ChiDinh.Add(chidinh);
                                //}
                                //else
                                //{
                                //    var bnAdd = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(maChidinh)).First().CopyHISInfo();
                                //    var chidinh = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(maChidinh) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).ToList();
                                //    foreach (var itmChiDinh in chidinh)
                                //    {
                                //        itmChiDinh.TrangThaiMau = OrderStatus.OrderRecieved;
                                //    }
                                //    bnAdd.ChiDinh = chidinh;
                                //    lstBnHL7Upate.Add(bnAdd);
                                //}
                            }
                        }
                    }
                    if (lstnhatKyMau.Count > 0)
                        ok = _iPatient.Insert_nhatky_mauxetnghiem(lstnhatKyMau);
                    if (ok)
                    {
                        if (lstBnHL7Upate.Count > 0)
                        {
                            Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                        }
                        _iPatient.Update_MauXn_LayMau(lstBoLayMau);
                        //Cập nhật trạng thái
                        if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianLayMau)
                        {
                            _iPatient.Update_ThoiGianThucHienXN(string.Join(",", lstMatiepnhan));
                            _iPatient.Update_ThoiGianThucHienXN_Nhom(string.Join(",", lstMatiepnhan), (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                        }
                        _iPatient.Update_TrangThaiLayMau(string.Join(",", lstMatiepnhan));
                        _iTestResult.DeleteCategoryOfTest(string.Join(",", lstMatiepnhan));
                    }
                    haveClick = false;
                    cboTrangThaiLayMau.SelectedIndexChanged -= cboTrangThaiLayMau_SelectedIndexChanged;
                    cboTrangThaiLayMau.SelectedIndex = 0;
                    if (radCheDoBarcode.Checked && string.IsNullOrEmpty(txtBarcode.Text))
                        txtBarcode.Text = barcode;
                    Get_DanhSachBenhNhan(txtBarcode.Text);
                    if (gvMauDaLay.RowCount == 0)
                    {
                        var matiepNhan = (radCheDoBarcode.Checked ? lstMatiepnhan[0] : txtBarcode.Text); //--> barcode thì lấy theo ma tiếp nhận (vì lúc này chỉ thực thi 1 row) -> shs thì theo số hs đang tìm
                        // xóa khỏi danh sách đếm cho mẫu vừa hủy lấy
                        if (objKiemSoatLayMau.DanhSachCode.Contains(matiepNhan))
                        {
                            objKiemSoatLayMau.DanhSachCode.Remove(matiepNhan);
                            objKiemSoatLayMau.DangKhoa = false;
                            _iPatient.Insert_Update_KiemSoatLayMau(objKiemSoatLayMau.MaNguoiDung, objKiemSoatLayMau.DanhSachCode, objKiemSoatLayMau.TGGianBatDau, objKiemSoatLayMau.TGKhoa, objKiemSoatLayMau.DangKhoa);
                        }
                    }
                    cboLyDo.SelectedIndex = -1;
                    cboTrangThaiLayMau.SelectedIndexChanged += cboTrangThaiLayMau_SelectedIndexChanged;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
            }
        }

        private void FrmLayMau_Shown(object sender, EventArgs e)
        {
            cboTrangThaiLayMau.SelectedIndex = 0;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemChonKhuLayMau)
            {
                var f = new FmChonKhulayMau { userId = CommonAppVarsAndFunctions.UserID };
                f.pnMenu.Visible = true;
                f.AdjustForm();
                f.ShowDialog();
                if (!string.IsNullOrEmpty(f.IDKhuLayMau))
                {
                    idKhuLaymau = f.IDKhuLayMau;
                    lblTitle.Text = string.Format("KHU LẤY MẪU: {0}", f.TenKhuLayMau.ToUpper());
                }
                else
                {
                    lblTitle.Text = "USER CHƯA KHAI BÁO KHU LẤY MẪU";
                }
            }
            this.Text = lblTitle.Text.First().ToString().ToUpper() + lblTitle.Text.Remove(0, 1).ToLower();
            pnLabel.Visible = false;
            splitContainer1.SplitterPosition = btnInBarcode.Location.X + btnInBarcode.Width + 1;
            txtBarcode.Focus();
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                lblMsgOrder.Text = "";
                // lblMsgOrder.Visible = false;
            }
            //else
            //TimBenhNhan(txtBarcode.Text);
        }
        private void chkTuInbarcode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox rad = (CheckBox)sender;
            if (rad.Checked)
            {
                rad.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
            }
            else
                rad.BackColor = Color.Empty;
            if (rad == chkTuInbarcode)
                _registryExtension.WriteRegistry(CommonConstant.RegistryAutoPrintBarcode_OnGetSample, chkTuInbarcode.Checked ? "1" : "0");
            if (rad == chkLayMauKhiQuet)
                _registryExtension.WriteRegistry(CommonConstant.RegistryAutoCompleteGetSample_OnGetSample, chkLayMauKhiQuet.Checked ? "1" : "0");
        }


        private void gvDanhSach_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        private void btnNhatKyMau_Click(object sender, EventArgs e)
        {
            var f = new FrmNhatkyTuChoi_Huy();
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                f.findBarcode = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                f.tuNgay = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan).ToString());
            }
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (dtpDenNgayChiDinh.Value < DateTime.Now.Date && DateTime.Now.Hour == 0)
            //{
            //    dtpDenNgayChiDinh.Value = DateTime.Now;
            //    dtpNgayChiDinh.Value = dtpDenNgayChiDinh.Value.AddDays(-1);
            //}
            if (objKiemSoatLayMau.DangKhoa && objKiemSoatLayMau.TGKhoa.AddMinutes(objKhuLayMau.Sophutgioihanlaymau) >= DateTime.Now)
            {
                lblStatus.Text = string.Format("CHỜ LẤY MẪU\n{0}", objKiemSoatLayMau.TGKhoa.AddMinutes(objKhuLayMau.Sophutgioihanlaymau).ToString("HH:mm:ss"));
                lblStatus.BackColor = Color.Red;
            }
            else
            {
                if (objKiemSoatLayMau.TGGianBatDau.AddMinutes(objKhuLayMau.Sophutgioihanlaymau) < DateTime.Now
                     || objKiemSoatLayMau.DangKhoa
                     || objKiemSoatLayMau.DanhSachCode.Count == 0)
                {
                    objKiemSoatLayMau.TGGianBatDau = DateTime.Now;
                    objKiemSoatLayMau.DanhSachCode = new List<string>();
                    objKiemSoatLayMau.DangKhoa = false;
                    //  _iPatient.Insert_Update_KiemSoatLayMau(objKiemSoatLayMau.MaNguoiDung, objKiemSoatLayMau.DanhSachCode, objKiemSoatLayMau.TGGianBatDau, objKiemSoatLayMau.TGKhoa, objKiemSoatLayMau.DangKhoa);
                }

                lblStatus.Text = "SẴN SÀNG";
                lblStatus.BackColor = Color.LightGreen;
            }
            lblCount.Text = string.Format("{0}/{1}", objKiemSoatLayMau.DanhSachCode.Count, objKhuLayMau.Gioihanlaymau);
        }

        private void dtpNgayChiDinh_Leave(object sender, EventArgs e)
        {
            Get_DanhSachBenhNhan(txtBarcode.Text);
        }

        private void dtpNgayChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtBarcode.Focus();
            }
        }

        private void FrmLayMau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnLayMau_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnInBarcode_Click(sender, e);
            }
        }

        //private void gvDanhSach_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex > -1)
        //    {
        //        gvDanhSach.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        //    }
        //}

        private void gvDanhSach_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1)
            //    gvDanhSach.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Empty;
        }

        private void btnUpdateADT_Click(object sender, EventArgs e)
        {
            //var f = new FrmInputBox();
            //f.ShowDialog();
            //if (!string.IsNullOrEmpty(f.InputString))
            //{
            //    var inputString = f.InputString;
            //    ShowMessage("Thực hiện yêu cầu cập nhật thông tin!");
            //    var updateResult = _iSofhHisService.GetPatient(inputString);
            //    f.Dispose();
            //    CustomMessageBox.CloseAlert();
            //    if (updateResult.Code == ApiMessageConstant.Fail)
            //    {
            //        CustomMessageBox.MSG_Information_OK(updateResult.Message);
            //        txtBarcode.Focus();
            //        txtBarcode.SelectAll();
            //    }
            //    else
            //    {
            //        if (inputString.Trim().Equals(txtBarcode.Text.Trim()))
            //        {
            //            txtBarcode_KeyPress(sender, new KeyPressEventArgs((char)Keys.Enter));
            //        }
            //        else
            //        {
            //            txtBarcode.Focus();
            //            txtBarcode.SelectAll();
            //        }
            //    }
            //}
        }

        private void gvChuaLayMau_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //if (CommonAppVarsAndFunctions.sysConfig.KetNoiHISWebAPI)
            //{
            //    GridView view = sender as GridView;
            //    view.SelectionChanged -= gvChuaLayMau_SelectionChanged;
            //    var rows = view.GetSelectedRows();
            //    foreach (int i in rows)
            //    {
            //        if (gvChuaLayMau.GetRowCellValue(i, colDS__DaHuyLayMau) != null)
            //        {
            //            if ((bool)gvChuaLayMau.GetRowCellValue(i, colDS__DaHuyLayMau))
            //            {
            //                gvChuaLayMau.UnselectRow(i);
            //            }
            //        }
            //    }
            //    view.SelectionChanged += gvChuaLayMau_SelectionChanged;
            //}
        }

        private void gvChuaLayMau_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //if (CommonAppVarsAndFunctions.sysConfig.KetNoiHISWebAPI)
            //{
            //    GridView view = sender as GridView;
            //    if (gvChuaLayMau.GetRowCellValue(e.RowHandle, colDS__DaHuyLayMau) != null)
            //    {
            //        bool value = (bool)view.GetRowCellValue(e.RowHandle, view.Columns[colDS__DaHuyLayMau.FieldName]);
            //        if (value)
            //        {
            //            e.Appearance.ForeColor = Color.DarkGray;
            //        }
            //    }
            //}
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtBarcode.TextChanged -= txtBarcode_TextChanged;
            txtBarcode.Text = string.Empty;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtBarcode.TextChanged -= txtBarcode_TextChanged;
            txtBarcode.Text = string.Empty;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
        }
        private void Get_DanhSachHenTraKetQua(string maTiepNhan, string soHoSo, DateTime? ngayTiepNhan, string barcode)
        {
            ucGioHenTraKetQua1.ClearDanhSach();
            ucGioHenTraKetQua1.Load_DanhSachHenTraKetQua(true, maTiepNhan, soHoSo, ngayTiepNhan, barcode);
        }

        private void cboTrangThaiLayMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_DanhSachBenhNhan(txtBarcode.Text);
        }
        private void radCheDoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            radCheDoBarcode.BackColor = radCheDoBarcode.Checked ? CommonAppColors.ColorButtonForceColorHover : Color.Empty;
        }
        private void radCheDoSHS_CheckedChanged(object sender, EventArgs e)
        {
            gvDanhSach.OptionsSelection.MultiSelectMode = (radCheDoSHS.Checked ? GridMultiSelectMode.CheckBoxRowSelect : GridMultiSelectMode.CellSelect);
            gvDanhSach.OptionsSelection.MultiSelect = radCheDoSHS.Checked;
            radCheDoSHS.BackColor = radCheDoSHS.Checked ? CommonAppColors.ColorButtonForceColorHover : Color.Empty;
            if (radCheDoSHS.Checked)
            {
                colChuaLayMau_Barcode.GroupIndex = 1;
                colDaLayMau_Barcode.GroupIndex = 1;

                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    gcDanhSach.DataSource = null;
                    SetNullGridDetailData();
                }
                else
                    Get_DanhSachBenhNhan(txtBarcode.Text);

                ucGroupHeaderTimKiem.GroupCaption =
                    CommonAppVarsAndFunctions.LangMessageConstant.TIMKIEMLATHEOSOHOSOVATHOIGIANNHAP; //string.Format("TÌM KIẾM: THEO SỐ HỒ SƠ VÀ THỜI GIAN NHẬP");
                txtBarcode.Focus();
            }
            else
            {
                colChuaLayMau_Barcode.GroupIndex = -1;
                colDaLayMau_Barcode.GroupIndex = -1;
                Get_DanhSachBenhNhan(txtBarcode.Text);
                ucGroupHeaderTimKiem.GroupCaption =
                    CommonAppVarsAndFunctions.LangMessageConstant.TIMKIEMLATHEOBARCODEXETNGHIEM; //string.Format("TÌM KIẾM: THEO BARCODE XÉT NGHIỆM");
                txtBarcode.Focus();
            }
            _registryExtension.WriteRegistry(CommonConstant.RegistrySearchByPIDAndLisCode, radCheDoBarcode.Checked ? "1" : "0");
        }

        private void chkInPhieuHen_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(CommonConstant.RegistryPrintReturnTicket, chkInPhieuHen.Checked ? "1" : "0");
            chkInPhieuHen.BackColor = (chkInPhieuHen.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty);
        }

        private void btnShowPhieuHen_Click(object sender, EventArgs e)
        {
            ucGioHenTraKetQua1.ClearDanhSach();
            gbHentraKQ.Size = new Size(563, 353);
            gbHentraKQ.Location = new Point(gbDaLayMau.Width - gbHentraKQ.Width, 0);
            CheckLoadDShenDangShow();
        }
        private void CheckLoadDShenDangShow()
        {
            if (gbHentraKQ.Size.Width > 0 && gvDanhSach.FocusedRowHandle > -1)
            {
                ucGioHenTraKetQua1.Load_DanhSachHenTraKetQua(true, String.Empty, String.Empty
                    , DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan).ToString()).Date
                    , gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString());
            }
        }
        private void btnDongPhieuHen_Click(object sender, EventArgs e)
        {
            gbHentraKQ.Size = new Size(0, 0);
        }

        private void gvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            SetNullGridDetailData();
            Get_TrangThaiLayMau();
            LayChiTietMau();
        }

        private void gvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetNullGridDetailData();
            Get_TrangThaiLayMau();
            LayChiTietMau();
        }
        private void CheckWithSampleCode(string sampleCode)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemPhanBietMauTheobarcode)
            {
                if (!string.IsNullOrEmpty(sampleCode))
                {
                    if (gvChuaLayMau.RowCount > 0)
                    {
                        var dta = (DataTable)gcChuaLayMau.DataSource;
                        for (int i = 0; i < dta.Rows.Count; i++)
                        {
                            var idMau = dta.Rows[i][colChuaLayMau_MaNhomLoaiMau.FieldName].ToString();
                            if (!idMau.Equals(sampleCode))
                            {
                                dta.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                        dta.AcceptChanges();
                        gcChuaLayMau.DataSource = dta;
                        //Show all và check lại
                        gvChuaLayMau.ExpandAllGroups();
                        gvChuaLayMau.SelectAll();
                        //Kiểm tra show như checkbox chọn
                        chkChiTietChuaLayMau_CheckedChanged(chkChiTietChuaLayMau, new EventArgs());
                    }
                    if (gvMauDaLay.RowCount > 0)
                    {
                        var dta = (DataTable)gcMauDaLay.DataSource;
                        for (int i = 0; i < dta.Rows.Count; i++)
                        {
                            var idMau = dta.Rows[i][colDaLayMau_MaNhomLoaiMau.FieldName].ToString();
                            if (!idMau.Equals(sampleCode))
                            {
                                dta.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                        dta.AcceptChanges();
                        gcMauDaLay.DataSource = dta;
                        //Show all và check lại
                        gvMauDaLay.ExpandAllGroups();
                        gvMauDaLay.SelectAll();
                        //Kiểm tra show như checkbox chọn
                        chkChiTietDaLayMau_CheckedChanged(chkChiTietDaLayMau, new EventArgs());
                    }
                }
            }
        }
        private void gvMau_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            if (e.RowHandle > -1)
                return;
            else if (e.RowHandle != GridControl.InvalidRowHandle)
            {
                if (e.RowHeight < 35)
                    e.RowHeight = 35;
            }
        }

        private void gvDanhSach_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle > -1)
            {
                if (((gvDanhSach.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CheckBoxRowSelect
                && gvDanhSach.OptionsSelection.MultiSelect)
                && (e.Column.VisibleIndex == 1 || e.Column.VisibleIndex == 2))
                || (!gvDanhSach.OptionsSelection.MultiSelect && (e.Column.VisibleIndex == 0 || e.Column.VisibleIndex == 1)))
                {
                    var statusTQ = gvDanhSach.GetRowCellValue(e.RowHandle, colDS_TrangThaiLayMauTQ).ToString();
                    var statusVS = gvDanhSach.GetRowCellValue(e.RowHandle, colDS_TrangThaiLayMauVS).ToString();
                    var objTrangThai = LayThongTintrangThai(statusTQ, statusVS);
                    if (objTrangThai.idTrangThaiLayMauChung == enumTrangThaiLayMau.DaLayDu
                        && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauDuThaoTac))
                    {
                        if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauDuThaoTac) != Color.Empty)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauDuThaoTac);
                        }
                    }
                    else if (objTrangThai.idTrangThaiLayMauChung == enumTrangThaiLayMau.ChuaLayDu
                        && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauThaoTacChuaDu))
                    {
                        if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauThaoTacChuaDu) != Color.Empty)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauThaoTacChuaDu);
                        }
                    }
                    else if (objTrangThai.idTrangThaiLayMauChung == enumTrangThaiLayMau.YeuCauLayLai
                        && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauYeuCauLayLai))
                    {
                        if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauYeuCauLayLai) != Color.Empty)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauYeuCauLayLai);
                        }
                    }
                    else if ((objTrangThai.idTrangThaiLayMauChung == enumTrangThaiLayMau.ChuaThucHien || objTrangThai.idTrangThaiLayMauChung == enumTrangThaiLayMau.ChuaLayMau)
                       && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauChuaThaoTac))
                    {
                        if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauChuaThaoTac) != Color.Empty)
                        {
                            e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauChuaThaoTac);
                        }
                    }
                }
            }
        }
    }
}
