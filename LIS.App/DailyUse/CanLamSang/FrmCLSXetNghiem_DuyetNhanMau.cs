using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
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
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Common.Extensions;
using TPH.Controls;
using TPH.Data.HIS.HISDataCommon;
using TPH.Lab.Middleware.LISConnect.Models;
using TPH.Lab.Middleware.LISConnect.Services;
using TPH.Language;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.DailyUse.BenhNhan;
using TPH.LIS.BarcodePrinting;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log;
using TPH.LIS.Log.Constants;
using TPH.LIS.Patient.Constants;
using TPH.LIS.Patient.Model;
using TPH.LIS.Patient.Services;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.Report.Constants;
using TPH.Report.Services.Impl;
using TPH.Report.Services;
using TPH.Report.Models;
//using static TPH.LIS.Common.TestType;

namespace TPH.LIS.App.DailyUse.CanLamSang
{
    public partial class FrmCLSXetNghiem_DuyetNhanMau : FrmTemplate
    {
        private readonly IConnectHISService _iHisData = new ConnectHISService();
        private readonly IPatientInformationService _iPatient = new PatientInformationService();
        private readonly ITestResultService _iTestResult = new TestResultService();
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private GridElementsPainter _PainterChoDuyetMau;
        private GridElementsPainter _PainterChoLayLai;
        private GridElementsPainter _PainterDaDuyetMau;
        TrangThaiNhanMau objTrangThaiCuaMau = new TrangThaiNhanMau();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);
        int reloadAfter = (5 * 60);
        int reloadCount = 0;
        List<string> lstDanhSachNhom = new List<string>();
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
        public FrmCLSXetNghiem_DuyetNhanMau()
        {
            InitializeComponent();
            gbThaotac.BackColor = gbChucNang.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnNguoiNhanMau.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnChoDuyet.BackColor = CommonAppColors.ColorMainAppColor;
            //pnChoDuyet.TopColor = CommonAppColors.ColorMainAppColor;
            //pnChoDuyet.BottomColor = CommonAppColors.ColorMainAppColor;

            pnLayLai.BackColor = CommonAppColors.ColorMainAppColor;
            //pnLayLai.TopColor = CommonAppColors.ColorMainAppColor;
            //pnLayLai.BottomColor = CommonAppColors.ColorMainAppColor;

            pnDaDuyet.BackColor = CommonAppColors.ColorMainAppColor;
            //pnDaDuyet.TopColor = CommonAppColors.ColorMainAppColor;
            //pnDaDuyet.BottomColor = CommonAppColors.ColorMainAppColor;

            //pnCapNhatGioNhanMau.BackColor = CommonAppColors.ColorMainAppColor;
            //pnCapNhatGioNhanMau.TopColor = CommonAppColors.ColorMainAppColor;
            //pnCapNhatGioNhanMau.BottomColor = CommonAppColors.ColorMainAppFormColor;

            gbThaotac.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
            gbChucNang.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
            gbDSBN.AppearanceCaption.ForeColor = CommonAppColors.ColorTextCaption;
            Load_XnGuiMau();
            Load_DSKhuVuc();
        }
        private DieuKienTimDanhSachBNTheoTrangThaiMau DieuKienLoad_DanhSachBN()
        {
            var obj = new DieuKienTimDanhSachBNTheoTrangThaiMau();
            //--- Tất cả ---
            //Chưa nhận mẫu
            //Đã nhận mẫu đủ//Nhận mẫu chưa đủ
            //Yêu cầu lấy lại
            obj.tungay = dtpNgayChiDinh.Value;
            obj.denngay = dtpDenNgayChiDinh.Value;
            obj.SampleCode = (string.IsNullOrEmpty(txtBarcode.Text) ? string.Empty : txtBarcode.Text.Replace(WorkingServices.SplitSampleCode(txtBarcode.Text), ""));
            var temBarcode = string.IsNullOrEmpty(obj.SampleCode) ? txtBarcode.Text : (string.IsNullOrEmpty(txtBarcode.Text) ? string.Empty : txtBarcode.Text.Replace(obj.SampleCode, ""));
            obj.barcode = WorkingServices.IsNumeric(temBarcode) ? temBarcode : string.Empty;
            obj.tenBN = WorkingServices.IsNumeric(temBarcode) ? string.Empty : txtBarcode.Text;
            obj.maBN = txtBarcode.Text;
            obj.loaiDichVu = ServiceType.ClsXetNghiem;
            obj.sophieuHis = txtBarcode.Text;
            obj.quyennhomXn = lstDanhSachNhom;

            var indexSelected = cboTrangThaiDuyet.SelectedIndex;
            if (indexSelected == 0)
            {
                obj.daNhanMau = Common.enumThucHien.TatCa;
            }
            else if (indexSelected == 1)
            {
                obj.daNhanMau = Common.enumThucHien.ChuaThucHien;
                obj.daNhanMauTatCa = Common.enumThucHien.ChuaThucHien;
            }
            else if (indexSelected == 2)
            {
                obj.daNhanMau = Common.enumThucHien.TatCa;
                obj.daNhanMauTatCa = Common.enumThucHien.DaThucHien;
            }
            else if (indexSelected == 3)
            {
                obj.daNhanMau = Common.enumThucHien.DaThucHien;
            }
            else if (indexSelected == 4)
            {
                obj.daNhanMau = Common.enumThucHien.TatCa;
                obj.daTuChoiMau = Common.enumThucHien.DaThucHien;
            }
            obj.CheckDaLayMau = QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
            obj.CheckSoHoSo = radCheDoSHS.Checked;
            return obj;
        }
        private void Load_DanhSachChuyenMau()
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                var data = _iPatient.Data_ChuyenMau_ChiTiet(null, txtBarcode.Text
                , null, null, string.Empty);
                if (data.Rows.Count > 0)
                {
                    if (data.Rows.Count == 1)
                    {
                        Load_DanhSachBenhNhan(false, int.Parse(data.Rows[0]["IDChuyenMau"].ToString()));
                    }
                    else
                    {
                        var f = new FrmDSChuyenMauTheoBarcode();
                        f.dataChuyenMau = data;
                        f.pnMenu.Visible = true;
                        f.AdjustForm();
                        f.ShowDialog();
                        if (f.IDChuyenMau > 0)
                        {
                            Load_DanhSachBenhNhan(false, f.IDChuyenMau);
                        }
                    }
                }
            }
            else
                Load_DanhSachBenhNhan(false);
        }
        private void Load_DanhSachBenhNhan(bool chiLoadChuaNhanMau, int idChuyenMau = 0, bool khongLoadChiTiet = false)
        {
            reloadCount = 0;
            gvDanhSach.FocusedRowChanged -= GvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged -= GvDanhSach_FocusedColumnChanged;
            var dieuKien = DieuKienLoad_DanhSachBN();
            dieuKien.IDChuyenMau = idChuyenMau;
            if (dieuKien.IDChuyenMau > 0)
                dieuKien.barcode = string.Empty;
            var data = _iPatient.DanhSach_BenhNhan_TheoTrangThaiMau(dieuKien);
            if (data != null)
            {
                if (data.Rows.Count > 0)
                {
                    data.DefaultView.Sort = "TGTheoPhut DESC";
                    data = data.DefaultView.ToTable();
                    WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                }
            }
            gcDanhSach.DataSource = data;
            gvDanhSach.FocusedRowChanged += GvDanhSach_FocusedRowChanged;
            gvDanhSach.FocusedColumnChanged += GvDanhSach_FocusedColumnChanged;
            if (!string.IsNullOrEmpty(txtBarcode.Text) && radXemTheoDSChuyenMau.Checked)
            {
                var idxFound = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, txtBarcode.Text);
                gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
            }

            if (!khongLoadChiTiet)
            {
                if (gvDanhSach.SelectedRowsCount == gvDanhSach.RowCount && gvDanhSach.OptionsSelection.MultiSelectMode == DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect)
                    KiemTraThongTinCheckVaLoaChiTiet(chiLoadChuaNhanMau);
                else
                    Load_ChiTietOngMau(chiLoadChuaNhanMau);
                if (!string.IsNullOrEmpty(dieuKien.SampleCode))
                    CheckWithSampleCode(dieuKien.SampleCode);
            }

            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanhBaoNhanTre)
            {
                if (!string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDuongDanCanhBao))
                {
                    for (int i = 0; i < gvDanhSach.RowCount; i++)
                    {
                        var thoiGian = TPH.Common.Converter.NumberConverter.ToInt(gvDanhSach.GetRowCellValue(i, colDS_TGTheoPhut));
                        if (thoiGian > CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanTrenNhanTre || (10 <= CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanDuoiNhanTre && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanTrenNhanTre <= 13))
                        {
                            Task.Factory.StartNew(() => PlaySound());
                            break;
                        }
                    }
                }
            }
            reloadCount = 0;
        }
        private void PlaySound()
        {
            if (File.Exists(@".\Audio\" + CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDuongDanCanhBao))
            {
                using (var splayer = new SoundPlayer(@".\Audio\" + CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemDuongDanCanhBao))
                {
                    splayer.Play();
                }
            }

        }
        private void GvDanhSach_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //reloadCount = 0;
            //Load_ChiTietOngMau(false);
        }

        private void GvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            reloadCount = 0;
            Load_ChiTietOngMau(false);
        }
        private void Load_ChiTietOngMau(bool chiLoadChuaNhanMau)
        {
            lblMsg.Text = "";
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                var statusTQ = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiNhanMauTQ).ToString();
                var statusVS = gvDanhSach.GetFocusedRowCellValue(colDS_TrangThaiNhanMauVS).ToString();
                GetLableTitle(statusTQ, statusVS);
            }

            //data tất cả chỉ định
            gcMauChoDuyet.DataSource = null;
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
                if (gvDanhSach.SelectedRowsCount > 0)
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
            var dataIn = _iPatient.DanhSachChiDinh_OngMau(maTiepNhan, CommonAppVarsAndFunctions.IDLayLoaiMau);
            if (dataIn != null)
            {
                if (dataIn.Rows.Count > 0)
                {
                    dataIn = XuLyDuLieu(dataIn);
                    dataIn = WorkingServices.ConvertColumnNameToLower_Upper(dataIn, true);
                    var dataVoiPhanQuyen = WorkingServices.SearchResult_OnDatatable(dataIn, string.Format("MaNhomChiDinh in ({0})", Utilities.ConvertStrinArryToInClauseSQL(CommonAppVarsAndFunctions.NhomClsXetNghiem, true)));
                    if (dataVoiPhanQuyen.Rows.Count > 0)
                    {
                        Get_DanhSachMauChoDuyet(dataIn);
                        Get_DanhSachMauDaDuyet(dataIn);
                        Get_DanhSachTuChoi(dataIn);
                    }
                }
            }
        }
        private void Get_DanhSachMauChoDuyet(DataTable dataIn)
        {
            if (dataIn != null)
            {
                var dataChoDuyet = WorkingServices.SearchResult_OnDatatable(dataIn, string.Format("{0} and DaNhanMau = 0 and TuChoiMau = 0", (QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh) ? "DaLayMau = 1" : "(DaLayMau = 0 or DaLayMau = 1)")));
                //Nếu có kiểm soát chuyển mẫu thì remove các mâu chưa chuyển ra
                if (dataChoDuyet.Rows.Count > 0 && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemKiemSoatChuyenMau)
                {
                    for (int i = 0; i < dataChoDuyet.Rows.Count; i++)
                    {
                        if (long.Parse(dataChoDuyet.Rows[i]["IDChuyenMau"].ToString()) == 0)
                        {
                            dataChoDuyet.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                    dataChoDuyet.AcceptChanges();
                }
                gcMauChoDuyet.DataSource = dataChoDuyet;
                gvMauChoDuyet.ExpandAllGroups();
                gvMauChoDuyet.SelectAll();
                if (!chkChiTietMauChoDuyet.Checked)
                {
                    gvMauChoDuyet.CollapseAllGroups();
                    gvMauChoDuyet.ExpandGroupLevel(0);
                }
                else
                {
                    gvMauChoDuyet.ExpandAllGroups();
                    gvMauChoDuyet.SelectAll();
                }
                var maKhuvucnhan = CommonAppVarsAndFunctions.PCWorkPlace;

                for (int i = 0; i < gvMauChoDuyet.RowCount; i++)
                {
                    if (gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_IDNoiDuKienThucHien) != null)
                    {
                        var khuDukien = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_IDNoiDuKienThucHien).ToString();
                        if (!khuDukien.Equals(maKhuvucnhan))
                        {
                            gvMauChoDuyet.UnselectRow(i);
                        }
                    }
                }
            }
        }
        private void Get_DanhSachMauDaDuyet(DataTable dataIn)
        {
            if (dataIn != null)
            {
                var data = WorkingServices.SearchResult_OnDatatable(dataIn, string.Format("DaLayMau = 1 and danhanmau = 1 and tuchoimau = 0"));
                //_iPatient.DanhSachOngMau(maTiepNhan, enumThucHien.DaThucHien
                //    , enumThucHien.DaThucHien, enumThucHien.TatCa, true, CommonAppVarsAndFunctions.UserID, string.Join(",", lstDanhSachNhom));
                var maKhuvucnhan = string.Empty;

                if (data != null)
                {
                    foreach (DataRow item in data.Rows)
                    {
                        maKhuvucnhan = item["IDKhuVucNhanMau"].ToString();
                        var lstkhuNhan = lstKhuVuc.Where(x => x.Makhuvuc.Equals(maKhuvucnhan.Trim(), StringComparison.OrdinalIgnoreCase));
                        if (lstkhuNhan.Any())
                            maKhuvucnhan = string.Format("{0} ({1})", lstkhuNhan.FirstOrDefault().Tenkhuvuc, lstkhuNhan.FirstOrDefault().Makhuvuc);
                        var idGui = long.Parse(item["IdGui"].ToString());
                        if (idGui > 0)
                        {
                            maKhuvucnhan += string.Format(" - Gửi từ {0}", item["IDNoiGuiMau"].ToString());
                        }
                        item["NoiDuKienThucHien"] = maKhuvucnhan;
                    }
                }
                gcMauDaDuyet.DataSource = data;
                gvMauDaDuyet.ExpandAllGroups();
                // gvMauDaDuyet.SelectAll();
                if (!chkCHiTietMauDaDuyet.Checked)
                {
                    gvMauDaDuyet.CollapseAllGroups();
                    gvMauDaDuyet.ExpandGroupLevel(0);
                }
            }
        }
        private void Get_DanhSachTuChoi(DataTable dataIn)
        {
            if (dataIn != null)
            {
                var data = WorkingServices.SearchResult_OnDatatable(dataIn, string.Format("DaLayMau = 0 and danhanmau = 0 and tuchoimau = 1"));
                var maKhuvucnhan = string.Empty;
                gcMauLayLai.DataSource = data;
                gvMauLayLai.ExpandAllGroups();
                if (!chkChiTietMauLayLai.Checked)
                {
                    gvMauLayLai.CollapseAllGroups();
                }
            }
        }
        private DataTable XuLyDuLieu(DataTable DataIn)
        {
            DataIn.Columns.Add("HinhOngMau", typeof(Image));
            DataIn.Columns.Add("NoiDuKienThucHien", typeof(string));
            DataIn.Columns.Add("IDNoiDuKienThucHien", typeof(string));
            DataIn.Columns.Add("IDNoiGuiMau", typeof(string));
            DataIn.Columns.Add("IDNoiNhanGuiMau", typeof(string));
            DataIn.Columns.Add("IdGui", typeof(long));
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
                var maNhomCLS = dr["MaNhomChiDinh"].ToString();
                var maTiepNhan = dr["MaTiepNhan"].ToString();
                if (!lstDanhSachNhom.Contains(maNhomCLS))
                {
                    DataIn.Rows.RemoveAt(i);
                    i--;
                    continue;
                }
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
                //Xử lý trạng thái gửi mẫu
               var maXN = dr["MaDichVu"].ToString();
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
                        dr["IDNoiDuKienThucHien"] = lstkhuGuiDen.FirstOrDefault().Makhuvuc.Trim();
                    }
                }
                else if (lstkhuNhan.Any())
                {
                    dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", lstkhuNhan.FirstOrDefault().Tenkhuvucnhan, lstkhuNhan.FirstOrDefault().Makhuvucnhan, (idGui > 0 ? " - Gửi mẫu" : string.Empty));
                    dr["IDNoiDuKienThucHien"] = lstkhuNhan.FirstOrDefault().Makhuvucnhan;
                }
                else
                {
                    dr["NoiDuKienThucHien"] = string.Format("{0} ({1}){2}", CommonAppVarsAndFunctions.PCWorkPlaceName, CommonAppVarsAndFunctions.PCWorkPlace, (idGui > 0 ? " - Gửi mẫu" : string.Empty));
                    dr["IDNoiDuKienThucHien"] = CommonAppVarsAndFunctions.PCWorkPlace;
                }

            }
            return WorkingServices.ConvertColumnNameToLower_Upper(DataIn, true);
        }
        private void btnCapNhatTinhTrangMau_Click(object sender, EventArgs e)
        {
            if (gvMauDaDuyet.SelectedRowsCount > 0)
            {
                if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue != null)
                {
                    var tinhTrangMau = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString(); ;
                    if (
                        CustomMessageBox.MSG_Question_YesNoCancel_GetYes(
                            string.Format("Cập nhật tình trạng: {0} cho các XN đang chọn?", tinhTrangMau)))
                    {
                        var matiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();

                        var lstMaXn = gvMauDaDuyet.GetSelectedRows()
                            .Where(iSelect => gvMauDaDuyet.GetRowCellValue(iSelect, colMauDaDuyet_MaDichVu) != null)
                            .Aggregate(string.Empty,
                                (current, iSelect) => current + ((string.IsNullOrEmpty(current) ? string.Empty : ",") +
                                                                 gvMauDaDuyet.GetRowCellValue(iSelect,
                                                                     colMauDaDuyet_MaDichVu).ToString()));
                        if (_iPatient.Update_TinhTrangMau(matiepNhan, lstMaXn, tinhTrangMau, false) > 0)
                            Load_ChiTietOngMau(false);
                    }
                }
                else
                {
                    CustomMessageBox.MSG_Information_OK("Chưa chọn tình trạng mẫu");
                }
            }
        }
        private void btnTuChoiMauChon_Click(object sender, EventArgs e)
        {
            reloadCount = 0;
            KiemTraCapNhat_TuChoiMau();
            reloadCount = 0;
        }

        void LoadStatusSample()
        {

            var lst = new Dictionary<string, string>
            {
                {
                    CommonAppVarsAndFunctions.LangMessageConstant.Tatca,
                    CommonAppVarsAndFunctions.LangMessageConstant.Tatca
                },
                {
                    CommonAppVarsAndFunctions.LangMessageConstant.ChuaNhanMau,
                    CommonAppVarsAndFunctions.LangMessageConstant.ChuaNhanMau
                },
                {
                    CommonAppVarsAndFunctions.LangMessageConstant.Danhanmau,
                    CommonAppVarsAndFunctions.LangMessageConstant.Danhanmau
                },
                {
                    CommonAppVarsAndFunctions.LangMessageConstant.ChuaNhanMauDu,
                    CommonAppVarsAndFunctions.LangMessageConstant.ChuaNhanMauDu
                },
                {
                    CommonAppVarsAndFunctions.LangMessageConstant.Yeucaulaylai,
                    CommonAppVarsAndFunctions.LangMessageConstant.Yeucaulaylai
                }
            };

            cboTrangThaiDuyet.DataSource = new BindingSource(lst, null);
            cboTrangThaiDuyet.DisplayMember = "Value";
            cboTrangThaiDuyet.ValueMember = "Key";
        }

        private void FrmCLSXetNghiem_DuyetNhanMau_Load(object sender, EventArgs e)
        {
            LoadStatusSample();
            btnTuChoiMauChon.Visible = QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh);
            if (!btnTuChoiMauChon.Visible)
                splitContainerControl4.PanelVisibility = SplitPanelVisibility.Panel2;

            var objCauHinhLuoiKQ = _iSysConfig.lstThongTinHienThi(HienthiConstants.DanhSachBNNhanMau);
            if (objCauHinhLuoiKQ != null)
            {
                if (objCauHinhLuoiKQ.Count > 0)
                {
                    foreach (GridColumn item in gvDanhSach.Columns)
                    {
                        var colFind = objCauHinhLuoiKQ
                            .Where(x => x.Idhienthi.Equals(item.Name, StringComparison.OrdinalIgnoreCase)).ToList();
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

            ControlExtension.SetLowerCaseForXGridColumns(gvMauChoDuyet);
            ControlExtension.SetLowerCaseForXGridColumns(gvMauDaDuyet);
            ControlExtension.SetLowerCaseForXGridColumns(gvMauLayLai);
            dtpNgayChiDinh.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpDenNgayChiDinh.Value = CommonAppVarsAndFunctions.ServerTime;
            dtpNhanCuaNgayLay.Value = CommonAppVarsAndFunctions.ServerTime;

            _PainterChoDuyetMau = new GridSkinElementsPainter(gvMauChoDuyet);
            _PainterChoLayLai = new GridSkinElementsPainter(gvMauLayLai);
            _PainterDaDuyetMau = new GridSkinElementsPainter(gvMauDaDuyet);
            cboTrangThaiDuyet.SelectedIndexChanged -= CboTrangThaiDuyet_SelectedIndexChanged;
            cboTrangThaiDuyet.SelectedIndex = 0;
            ComboboxTrangThaiDuyet_Changed();
            lstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            Set_DSNhomVaoTitle();
            //    radXemTheoDSChuyenMau.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryDanhSachNhanMauTheoIDChuyen) == "1";
            chkKhongTuNhanMauKhiComauDaDuocNhan.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryKhongTuNhanKhiComauDaNhan) == "1";
            chkNhanMauKhiQuetCode.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryNhanMauKhiQuetCode) == "1";
            chkChiNhanKhiCo1Code.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryNhanMauKhiCo1Code) == "1";
            chkNhanMauKhiQuetCode.BackColor = (chkNhanMauKhiQuetCode.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty);
            chkChiNhanKhiCo1Code.BackColor = chkChiNhanKhiCo1Code.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty;
            radXemTheoDSChuyenMau.BackColor = radXemTheoDSChuyenMau.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty;
            radXemTheoDSThongThuong.BackColor = radXemTheoDSThongThuong.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty;
            ucSearchLookupEditor_Doctor1.Load_NhanVienNhanMau();
            ucSearchLookupEditor_Doctor1.SelectedValue = CommonAppVarsAndFunctions.UserID;
            ucSearchLookupEditor_LoaiMauVS.Load_DanhMucLoaiMau(ServiceType.ClsXNViSinh.ToString());
            ucSearchLookupEditor_LoaiMauSHPT.Load_DanhMucLoaiMau(ServiceType.ClsSHPT.ToString());
            ucSearchLookupEditor_LoaiMauSLSS.Load_DanhMucLoaiMau(ServiceType.ClsSLSS.ToString());
            btnOpenOrder.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemLoaiKetNoiMay == EnumLoaiKetNoiMay.CoPhanMemTrungGian;
            ucSearchLookupEditor_TinhTrangMau1.Load_CauHinh(0);

            chkInChiDinhKhiNhanMau.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryNhanMauInChiDinh) == "1";
            chkInChiDinhKhiNhanMau.CheckedChanged += ChkInChiDinhKhiNhanMau_CheckedChanged;
            radCheDoSHS.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo;
            colDS_SoHoSoHis.Visible = CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo;
            if (!CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSuDungSoHoSo)
                radCheDoBarcode.Checked = true;
            else
                radCheDoBarcode.Checked = _registryExtension.ReadRegistry(CommonConstant.RegistrySearchByPIDAndLisCode) == "1";

            Get_MaMauDat();
            if (radCheDoBarcode.Checked)
                Check_LoadDanhSach(false);

            chkIntemSHPTkhiNhanMau.Checked = _registryExtension.ReadRegistry(UserConstant.RegistryInTemMaSoMauSHPTKhiNhanMau) == "1";
            numSotemMaSoMau.Value = int.Parse(string.IsNullOrEmpty(_registryExtension.ReadRegistry(UserConstant.RegistrySoTemMaSoMau))

                ? "1" : _registryExtension.ReadRegistry(UserConstant.RegistrySoTemMaSoMau));
            ComboboxTrangThaiDuyet_Changed();
            radXemTheoDSChuyenMau.CheckedChanged += radXemTheoDSChuyenMau_CheckedChanged;
            radXemTheoDSThongThuong.CheckedChanged += radXemTheoDSChuyenMau_CheckedChanged;
            chkNhanMauKhiQuetCode.CheckedChanged += ChkNhanMauKhiQuetCode_CheckedChanged;
            chkChiNhanKhiCo1Code.CheckedChanged += chkChiNhanKhiCo1Code_CheckedChanged;
            chkIntemSHPTkhiNhanMau.CheckedChanged += ChkIntemSHPTkhiNhanMau_CheckedChanged;
            numSotemMaSoMau.ValueChanged += NumSotemMaSoMau_ValueChanged;
            ucSearchLookupEditor_TinhTrangMau1.SelectedValue = maMauDat;
            ucSearchLookupEditor_TinhTrangMau1.EditValueChange += UcSearchLookupEditor_TinhTrangMau1_EditValueChange;
            reloadCount = 0;
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSoPhutLoadDSNhanMau > 0)
            {
                reloadAfter = (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSoPhutLoadDSNhanMau > 0 ? CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemSoPhutLoadDSNhanMau : 5) * 60;
                tmAutoLoadList.Interval = 1000;
                tmAutoLoadList.Enabled = true;
                tmAutoLoadList.Start();
            }
            pnCapNhatGioNhanMau.Visible = CommonAppVarsAndFunctions.CheckUserPermissionToAccessFunctions(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionUpdateGettime);
            if (!CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemSHPT))
            {
                chkIntemSHPTkhiNhanMau.Checked = false;
                chkIntemSHPTkhiNhanMau.Visible = false;
                lblSotemSHPT.Visible = false;
                numSotemMaSoMau.Visible = false;
                btnIntemSHPT.Visible = false;
            }
            TinhToanDoRongCuaChonMau();
            radCheDoSHS.CheckedChanged += new System.EventHandler(radCheDoSHS_CheckedChanged);
            LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterNhanMauInChiDinh, true);
        }

        private void ChkInChiDinhKhiNhanMau_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryNhanMauInChiDinh, chkInChiDinhKhiNhanMau.Checked ? "1" : "0");
        }

        private void UcSearchLookupEditor_TinhTrangMau1_EditValueChange(object sender, EventArgs e)
        {
            if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue != null)
            {
                var value = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString();
                txtLyDo_TinhTrangMau.ReadOnly = !value.Equals("lydokhac", StringComparison.OrdinalIgnoreCase);
                if (txtLyDo_TinhTrangMau.ReadOnly)
                    txtLyDo_TinhTrangMau.Text = ucSearchLookupEditor_TinhTrangMau1.SelectedText.ToString();
                else
                    txtLyDo_TinhTrangMau.Text = string.Empty;
            }
            else
            {
                txtLyDo_TinhTrangMau.ReadOnly = true;
                txtLyDo_TinhTrangMau.Text = string.Empty;
            }
        }

        private void TinhToanDoRongCuaChonMau()
        {
            var heightTotal = 0;
            pnChonMauSangloc.Visible = CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemSangLoc);
            pnChonmauSHPT.Visible = CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemSHPT);
            pnChonMauViSinh.Visible = CommonAppVarsAndFunctions.CheckExist_IMSModule(IMSModule.XetNghiemViSinhNuoicay);
            heightTotal += (pnChonMauSangloc.Visible ? pnChonMauSangloc.Height : 0);
            heightTotal += (pnChonmauSHPT.Visible ? pnChonmauSHPT.Height : 0);
            heightTotal += (pnChonMauViSinh.Visible ? pnChonMauViSinh.Height : 0);
            if (heightTotal > 0)
                heightTotal += 10;
            pnNguoiNhanMau.Height = heightTotal;
        }
        private void NumSotemMaSoMau_ValueChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistrySoTemMaSoMau, ((int)numSotemMaSoMau.Value).ToString());
        }

        private void ChkIntemSHPTkhiNhanMau_CheckedChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(UserConstant.RegistryInTemMaSoMauSHPTKhiNhanMau, chkIntemSHPTkhiNhanMau.Checked ? "1" : "0");
        }

        private void ucSearchLookupEditor_TinhTrangMau1_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }
        private void ChkNhanMauKhiQuetCode_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            if (chk.Checked)
            {
                chk.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
            }
            else
                chk.BackColor = Color.Empty;
            _registryExtension.WriteRegistry(UserConstant.RegistryNhanMauKhiQuetCode, chkNhanMauKhiQuetCode.Checked ? "1" : "0");
        }
        private void chkChiNhanKhiCo1Code_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            if (chk.Checked)
            {
                chk.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
            }
            else
                chk.BackColor = Color.Empty;
            _registryExtension.WriteRegistry(UserConstant.RegistryNhanMauKhiCo1Code, chkChiNhanKhiCo1Code.Checked ? "1" : "0");
        }
        string maMauDat = string.Empty;
        private void Get_MaMauDat()
        {
            if (ucSearchLookupEditor_TinhTrangMau1.DataSource != null)
            {
                var data = (DataTable)ucSearchLookupEditor_TinhTrangMau1.DataSource;
                foreach (DataRow dr in data.Rows)
                {
                    var maTinhTrang = dr["MaTinhTrang"].ToString();
                    var tinhTrangMau = dr["TinhTrangMau"].ToString();
                    if (tinhTrangMau.Trim().Equals("mẫu đạt", StringComparison.OrdinalIgnoreCase) || tinhTrangMau.Trim().Equals("đạt", StringComparison.OrdinalIgnoreCase))
                    {
                        maMauDat = maTinhTrang;
                        break;
                    }
                }
            }
        }
        private void CboTrangThaiDuyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_LoadDanhSach(false);
        }

        private void gvDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        void GetLableTitle(string statusTQ, string statusVS)
        {
            objTrangThaiCuaMau = LayThongTintrangThai(statusTQ, statusVS);
            lblMsg.Text = objTrangThaiCuaMau.TrangThaiChung;
        }
        private TrangThaiNhanMau LayThongTintrangThai(string statusTQ, string statusVS)
        {
            return SampleStatus.Get_TrangNhanMau(statusTQ, statusVS);
        }
        bool checkAllChiLoadChuaNhanMau = false;
        private void Check_LoadDanhSach(bool chiLoadChuaNhanMau)
        {
            reloadCount = 0;
            gvDanhSach.SelectionChanged -= GvDanhSach_SelectionChanged;
            if (radXemTheoDSChuyenMau.Checked)
            {
                Load_DanhSachChuyenMau();
            }
            else
            {
                Load_DanhSachBenhNhan(chiLoadChuaNhanMau, 0, radCheDoSHS.Checked);
            }
            gvDanhSach.SelectionChanged += GvDanhSach_SelectionChanged;
            if (radCheDoSHS.Checked && !string.IsNullOrEmpty(txtBarcode.Text) && gvDanhSach.RowCount > 0)
            {
                checkAllChiLoadChuaNhanMau = chiLoadChuaNhanMau;
                gvDanhSach.SelectAll();
            }
            reloadCount = 0;
        }

        private void GvDanhSach_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            KiemTraThongTinCheckVaLoaChiTiet(checkAllChiLoadChuaNhanMau);
            //set lại false để các thao tác khác không bị chặn
            checkAllChiLoadChuaNhanMau = false;
        }

        private void KiemTraThongTinCheckVaLoaChiTiet(bool chiLoadChuaNhanMau)
        {
            Load_ChiTietOngMau(chiLoadChuaNhanMau);
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var barcodeMain = txtBarcode.Text;
                var sampleCode = (string.IsNullOrEmpty(barcodeMain) ? string.Empty : barcodeMain.Replace(WorkingServices.SplitSampleCode(barcodeMain), "")); 
                cboTrangThaiDuyet.SelectedIndexChanged -= CboTrangThaiDuyet_SelectedIndexChanged;
                cboTrangThaiDuyet.SelectedIndex = 0;

                if (radCheDoSHS.Checked && string.IsNullOrEmpty(txtBarcode.Text))
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập số hồ sơ.");
                }
                else
                {
                    txtBarcode.Text = (string.IsNullOrEmpty(sampleCode) ? barcodeMain : barcodeMain.Replace(sampleCode, "").Trim());
                    gcMauDaDuyet.DataSource = null;
                    gcMauLayLai.DataSource = null;
                    Check_LoadDanhSach(chkNhanMauKhiQuetCode.Checked);
                    ComboboxTrangThaiDuyet_Changed();

                    CheckWithSampleCode(sampleCode);

                    if (chkNhanMauKhiQuetCode.Checked)
                    {
                        if (gvMauChoDuyet.RowCount > 0 && gvMauDaDuyet.RowCount > 0 && chkKhongTuNhanMauKhiComauDaDuocNhan.Checked)
                        {
                            txtBarcode.Focus();
                            txtBarcode.SelectAll();
                            e.Handled = true;
                            //Load_ChiTietOngMau(false);
                            return;
                        }
                        if (gvMauChoDuyet.RowCount > 0
                        && ((chkChiNhanKhiCo1Code.Checked && gvDanhSach.RowCount == 1) || (chkChiNhanKhiCo1Code.Checked && radCheDoSHS.Checked) || !chkChiNhanKhiCo1Code.Checked))
                        {
                            gcMauChoDuyet.Refresh();
                            string alert = CommonAppVarsAndFunctions.LangMessageConstant.Thuchientunhanmaukhiquetcode; //"Thực hiện tự nhận mẫu khi quét code!";
                            if (chkChiNhanKhiCo1Code.Checked)
                            {
                                if (radCheDoSHS.Checked)
                                {
                                    alert += string.Format(
                                        CommonAppVarsAndFunctions.LangMessageConstant.Chinhanmaucongaylay,
                                        dtpNhanCuaNgayLay.Value.ToString("dd/MM/yyyy"));
                                    foreach (int i in gvMauChoDuyet.GetSelectedRows())
                                    {
                                        if (gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_TGLayMau) != null)
                                        {
                                            if (!string.IsNullOrEmpty(gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_TGLayMau).ToString()))
                                            {
                                                var ngayLayMau = DateTime.Parse(gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_TGLayMau).ToString());
                                                if (ngayLayMau.Date != dtpNhanCuaNgayLay.Value.Date)
                                                {
                                                    gvMauChoDuyet.UnselectRow(i);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (gvMauChoDuyet.SelectedRowsCount > 0)
                            {
                                ShowMess(alert);
                                KiemTraCapNhat_NhanMau();
                            }
                        }
                        else
                        {
                            Load_ChiTietOngMau(false);
                        }
                    }
                }
                CheckWithSampleCode(sampleCode);
                txtBarcode.Text =  barcodeMain;
                txtBarcode.Focus();
                txtBarcode.SelectAll();
                e.Handled = true;
            }
        }
        private void ShowMess(string Mess)
        {
            lblMessage.Text = Mess;
        }
        //---------------===================================----------------------------
        #region Sự kiện cho lưới chờ nhận mẫu
        private void gvMauChoDuyet_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            
            if (info.Column.Name == colDaLayMau_TenNhomLoaiMau.Name && info.GroupText != null && info.Level == 1)
            {
                int handle = gvMauChoDuyet.GetChildRowHandle((radCheDoSHS.Checked ? e.RowHandle - 1 : e.RowHandle), 0);
                string text = gvMauChoDuyet.GetGroupRowDisplayText(e.RowHandle);
                text = text.Replace(String.Format("- {0}: ,", colDaLayMau_NoiDungGhiChu.Caption), ",").Replace(String.Format("{0}:", colDaLayMau_TenNhomLoaiMau.Caption), String.Format("{0}:        ", colDaLayMau_TenNhomLoaiMau.Caption)).Replace(" - ", "\t-\t").Replace(", ", "\t-\t")
                     .Replace(info.GroupValueText, KiemTraThemKhoangTrangChoTenLoaiMau(info.GroupValueText)).Replace(" \t","\t");
                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;

                _PainterChoDuyetMau.GroupRow.DrawGroupRowBackground(info);
                _PainterChoDuyetMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();

                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                bool haveGhiChu = text.Contains(String.Format("-\t{0}:", colMauLayLai_NoiDungGhiChu.Caption));
                Point textPos = GetTextPos(e, text, info);
                e.Graphics.DrawRectangle(e.Cache.GetPen(gvMauChoDuyet.Appearance.GroupRow.BackColor), e.Bounds);
                e.Graphics.DrawString(text
                    , e.Appearance.Font, e.Cache.GetSolidBrush((haveGhiChu ? Color.DarkRed : e.Appearance.ForeColor)), textPos);

                Point imgPos = GetImgPos(info, textPos.X + (int)e.Graphics.MeasureString(String.Format("{0}:", colDaLayMau_TenNhomLoaiMau.Caption), e.Appearance.Font).Width
                    , Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Width));
                if (gvMauChoDuyet.GetRowCellValue(handle, colDaLayMau_HinhOngMau) != null && !string.IsNullOrEmpty(gvMauChoDuyet.GetRowCellValue(handle, colDaLayMau_HinhOngMau).ToString()))
                {
                    Image img = (Bitmap)(gvMauChoDuyet.GetRowCellValue(handle, colDaLayMau_HinhOngMau));
                    imgPos.Y = e.Bounds.Location.Y + e.Bounds.Height / 2 - img.Height / 2 - 1;
                    e.Graphics.DrawImage(img, imgPos);
                }
                e.Handled = true;
            }
            else if  (info.Column.Name == colDaLayMau_NoiDuKienThucHien.Name && info.GroupText != null && info.Level == 0)
            {
               // info.GroupText = info.GroupText.Replace(String.Format("- {0}: ,", colDaLayMau_NoiDungGhiChu.Caption), ",").Replace("  ,", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",", ", ");
              
                string text = gvMauChoDuyet.GetGroupRowDisplayText(e.RowHandle);
                var arr = text.Split(new string[] { String.Format("- {0}", colDaLayMau_NoiDungGhiChu.Caption) }, StringSplitOptions.RemoveEmptyEntries);
                text = arr[0];

                _PainterChoDuyetMau.GroupRow.DrawGroupRowBackground(info);
                _PainterChoDuyetMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

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
        List<string> listNguoiLayMau = new List<string>();
        List<string> listDaLayMau_GhiChuLayMau = new List<string>();
        private void gvMauChoDuyet_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

            if (e.Item == gvMauChoDuyet.GroupSummary.Where(x => x.FieldName.Equals("MaLoaiMauSeq", StringComparison.OrdinalIgnoreCase)).First())
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
            else if (e.Item == gvMauChoDuyet.GroupSummary.Where(x => x.FieldName.Equals("LoaiMauPhuSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctDaLayMau = 0;
                    listDaLayMau = new List<string>();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!string.IsNullOrEmpty(e.FieldValue.ToString()))
                        {
                            if (!listDaLayMau.Contains(e.FieldValue.ToString().Trim()))
                            {
                                countDistinctDaLayMau++;
                                listDaLayMau.Add(e.FieldValue.ToString().Trim());
                            }
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctDaLayMau;
                    listDaLayMau.Clear();
                }
            }
            else if (e.Item == gvMauChoDuyet.GroupSummary.Where(x => x.FieldName.Equals("NguoiLayMau", StringComparison.OrdinalIgnoreCase)).First())
            {

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listNguoiLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listNguoiLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listNguoiLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(",", listNguoiLayMau);
                    listNguoiLayMau.Clear();
                }

            }
            else if (e.Item == gvMauChoDuyet.GroupSummary.First(x => x.FieldName.Equals("NoiDungGhiChu", StringComparison.OrdinalIgnoreCase)))
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
        private void chkChiTietMauChoDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChiTietMauChoDuyet.Checked)
            {
                gvMauChoDuyet.ExpandAllGroups();
            }
            else
            {
                gvMauChoDuyet.CollapseAllGroups();
                if (radCheDoSHS.Checked)
                {
                    gvMauChoDuyet.ExpandGroupLevel(0);
                    gvMauChoDuyet.ExpandGroupLevel(1);
                }
                else
                    gvMauChoDuyet.ExpandGroupLevel(0);
            }
        }
        #endregion
        //---------------===================================----------------------------
        #region Sự kiện cho lưới đã duyệt nhận mẫu
        private void gvMauDaDuyet_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.Name == colMauDaDuyet_TenNhomMau.Name && info.GroupText != null && info.Level == 1)
            {
                int handle = gvMauDaDuyet.GetChildRowHandle((radCheDoSHS.Checked ? e.RowHandle - 1 : e.RowHandle), 0);
                string text = gvMauDaDuyet.GetGroupRowDisplayText(e.RowHandle);
                //text = text.Replace("- Ghi chú lấy mẫu: ,", ",").Replace("Ống mẫu:", "Ống mẫu:        ").Replace(" - ", "\t-\t").Replace(", ", "\t-\t")
                //        .Replace(info.GroupValueText, KiemTraThemKhoanTrangChoTenLoaiMau(info.GroupValueText));

                text = text.Replace(String.Format("- {0}: ,", colMaDaDuyet_NoiDungGhiChu.Caption), ",").Replace(String.Format("{0}:", colMauDaDuyet_TenNhomMau.Caption), String.Format("{0}:        ", colMauDaDuyet_TenNhomMau.Caption)).Replace(" - ", "\t-\t").Replace(", ", "\t-\t")
            .Replace(info.GroupValueText, KiemTraThemKhoangTrangChoTenLoaiMau(info.GroupValueText));

                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;

                _PainterDaDuyetMau.GroupRow.DrawGroupRowBackground(info);
                _PainterDaDuyetMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();

                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                bool haveGhiChu = text.Contains(String.Format("-\t{0}:", colMaDaDuyet_NoiDungGhiChu.Caption));
                Point textPos = GetTextPos(e, text, info);
                e.Graphics.DrawRectangle(e.Cache.GetPen(gvMauDaDuyet.Appearance.GroupRow.BackColor), e.Bounds);
                e.Graphics.DrawString(text
                    , e.Appearance.Font, e.Cache.GetSolidBrush((haveGhiChu ? Color.DarkRed : e.Appearance.ForeColor)), textPos);

                Point imgPos = GetImgPos(info, textPos.X + (int)e.Graphics.MeasureString(String.Format("{0}:", colMauDaDuyet_TenNhomMau.Caption), e.Appearance.Font).Width
                    , Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Width));
                if (gvMauDaDuyet.GetRowCellValue(handle, colMauDaDuyet_HinhOngMau) != null && !string.IsNullOrEmpty(gvMauDaDuyet.GetRowCellValue(handle, colMauDaDuyet_HinhOngMau).ToString()))
                {
                    Image img = (Bitmap)(gvMauDaDuyet.GetRowCellValue(handle, colMauDaDuyet_HinhOngMau));
                    imgPos.Y = e.Bounds.Location.Y + e.Bounds.Height / 2 - img.Height / 2 - 1;
                    e.Graphics.DrawImage(img, imgPos);
                }
                e.Handled = true;
            }
            else if (info.Column.Name == colDaNhanMau_NoiDuKienThucHien.Name && info.GroupText != null && info.Level == 0)
            {
                //info.GroupText = info.GroupText.Replace(String.Format("- {0}: ,", colMaDaDuyet_NoiDungGhiChu.Caption), ",").Replace("  ,", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",", ", ");
                string text = gvMauDaDuyet.GetGroupRowDisplayText(e.RowHandle);
                var arr = text.Split(new string[] { String.Format("- {0}", colMaDaDuyet_NoiDungGhiChu.Caption) }, StringSplitOptions.RemoveEmptyEntries);
                text = arr[0];

                _PainterDaDuyetMau.GroupRow.DrawGroupRowBackground(info);
                _PainterDaDuyetMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

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
        Int32 countDistinctDaDuyetLayMau = 0;
        List<string> listDaDuyetLayMau = new List<string>();
        List<string> listDaDuyetLayMau_NguoiLay = new List<string>();
        List<string> listDaDuyetLayMau_GhiChuLayMau = new List<string>();
        private void gvMauDaDuyet_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item == gvMauDaDuyet.GroupSummary.Where(x => x.FieldName.Equals("MaLoaiMauSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctDaDuyetLayMau = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listDaDuyetLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            countDistinctDaDuyetLayMau++;
                            listDaDuyetLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctDaDuyetLayMau;
                    listDaDuyetLayMau.Clear();
                }
            }
            else if (e.Item == gvMauDaDuyet.GroupSummary.Where(x => x.FieldName.Equals("LoaiMauPhuSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctDaDuyetLayMau = 0;
                    listDaDuyetLayMau = new List<string>();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!string.IsNullOrEmpty(e.FieldValue.ToString()))
                        {
                            if (!listDaDuyetLayMau.Contains(e.FieldValue.ToString().Trim()))
                            {
                                countDistinctDaDuyetLayMau++;
                                listDaDuyetLayMau.Add(e.FieldValue.ToString().Trim());
                            }
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctDaDuyetLayMau;
                    listDaDuyetLayMau.Clear();
                }
            }
            else if (e.Item == gvMauDaDuyet.GroupSummary.Where(x => x.FieldName.Equals("NguoiNhanMau", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listDaDuyetLayMau_NguoiLay.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listDaDuyetLayMau_NguoiLay.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listDaDuyetLayMau_NguoiLay.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(",", listDaDuyetLayMau_NguoiLay);
                    listDaDuyetLayMau_NguoiLay.Clear();
                }
            }
            else if (e.Item == gvMauDaDuyet.GroupSummary.First(x => x.FieldName.Equals("NoiDungGhiChu", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listDaDuyetLayMau_GhiChuLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listDaDuyetLayMau_GhiChuLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listDaDuyetLayMau_GhiChuLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(", ", listDaDuyetLayMau_GhiChuLayMau);
                    listDaDuyetLayMau_GhiChuLayMau.Clear();
                }
            }
        }
        private void chkChiTietMauDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCHiTietMauDaDuyet.Checked)
            {
                gvMauDaDuyet.ExpandAllGroups();
            }
            else
            {
                gvMauDaDuyet.CollapseAllGroups();
                if (radCheDoSHS.Checked)
                {
                    gvMauDaDuyet.ExpandGroupLevel(0);
                    gvMauDaDuyet.ExpandGroupLevel(1);
                }
                else
                    gvMauDaDuyet.ExpandGroupLevel(0);
            }
        }
        #endregion
        //---------------===================================----------------------------
        #region Sự kiện cho lưới yêu cầu lấy lại mẫu
        private void gvMauLayLai_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            if (info.Column.Name == colMauLayLai_TenNhomLoaiMau.Name && info.GroupText != null && info.Level == 1)
            {
                int handle = gvMauLayLai.GetChildRowHandle((radCheDoSHS.Checked ? e.RowHandle - 1 : e.RowHandle), 0);
                string text = gvMauLayLai.GetGroupRowDisplayText(e.RowHandle);
                text = text.Replace(String.Format("- {0}: ,", colMauLayLai_NoiDungGhiChu.Caption), ",").Replace(String.Format("{0}:", colMauLayLai_TenNhomLoaiMau.Caption), String.Format("{0}:        ", colMauLayLai_TenNhomLoaiMau.Caption)).Replace(" - ", "\t-\t").Replace(", ", "\t-\t")
                 .Replace(info.GroupValueText, KiemTraThemKhoangTrangChoTenLoaiMau(info.GroupValueText));

                int textY = e.Bounds.Location.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Height)) / 2;
                info.ButtonBounds.Y = textY;

                _PainterChoLayLai.GroupRow.DrawGroupRowBackground(info);
                _PainterChoLayLai.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

                info.UpdateSelectorState();

                var rect = info.SelectorInfo.Bounds;
                rect.Y = textY;
                rect.X = info.ButtonBounds.Right + 12;

                info.SelectorInfo.Bounds = rect;
                info.SelectorInfo.GlyphRect = rect;
                info.SelectorInfo.CaptionRect = new Rectangle(rect.X + rect.Width, rect.Y, -3, 1);

                ObjectPainter.DrawObject(e.Cache, info.SelectorPainter, info.SelectorInfo);
                bool haveGhiChu = text.Contains(String.Format("-\t{0}:", colMauLayLai_NoiDungGhiChu.Caption));
                Point textPos = GetTextPos(e, text, info);
                e.Graphics.DrawRectangle(e.Cache.GetPen(gvMauLayLai.Appearance.GroupRow.BackColor), e.Bounds);
                e.Graphics.DrawString(text
                    , e.Appearance.Font, e.Cache.GetSolidBrush((haveGhiChu ? Color.DarkRed : e.Appearance.ForeColor)), textPos);

                Point imgPos = GetImgPos(info, textPos.X + (int)e.Graphics.MeasureString(String.Format("{0}:", colMauLayLai_TenNhomLoaiMau.Caption), e.Appearance.Font).Width
                    , Convert.ToInt32(e.Graphics.MeasureString(text, e.Appearance.Font).Width));
                if (gvMauLayLai.GetRowCellValue(handle, colMauLayLai_HinhOngMau) != null
                    && !string.IsNullOrEmpty(gvMauLayLai.GetRowCellValue(handle, colMauLayLai_HinhOngMau).ToString()))
                {
                    Image img = (Bitmap)(gvMauLayLai.GetRowCellValue(handle, colMauLayLai_HinhOngMau));
                    imgPos.Y = e.Bounds.Location.Y + e.Bounds.Height / 2 - img.Height / 2 - 1;
                    e.Graphics.DrawImage(img, imgPos);
                }
                e.Handled = true;
            }
            else if (info.Column.Name == colMauLayLai_NoiDuKienThucHien.Name && info.GroupText != null && info.Level == 0)
            {
                //info.GroupText = info.GroupText.Replace(String.Format("- {0}: ,", colMauLayLai_NoiDungGhiChu.Caption), ",").Replace("  ,", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",", ", "); ;
                string text = gvMauLayLai.GetGroupRowDisplayText(e.RowHandle);
                var arr = text.Split(new string[] { String.Format("- {0}", colMauLayLai_NoiDungGhiChu.Caption) }, StringSplitOptions.RemoveEmptyEntries);
                text = arr[0];

                _PainterDaDuyetMau.GroupRow.DrawGroupRowBackground(info);
                _PainterDaDuyetMau.OpenCloseButton.DrawObject(new OpenCloseButtonInfoArgs(e.Cache, info.ButtonBounds, info.GroupExpanded, info.AppearanceGroupButton, ObjectState.Normal));

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
        Int32 countDistinctMauLayLai = 0;
        List<string> listMauLayLai = new List<string>();
        List<string> listMauLayLai_NguoiLayMau = new List<string>();
        List<string> listMauLayLai_GhiChuLayMau = new List<string>();

        private void gvMauLayLai_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.Item == gvMauLayLai.GroupSummary.Where(x => x.FieldName.Equals("MaLoaiMauSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctMauLayLai = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listMauLayLai.Contains(e.FieldValue.ToString().Trim()))
                        {
                            countDistinctMauLayLai++;
                            listMauLayLai.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctMauLayLai;
                    listMauLayLai.Clear();
                }
            }
            else if (e.Item == gvMauLayLai.GroupSummary.Where(x => x.FieldName.Equals("LoaiMauPhuSeq", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    countDistinctMauLayLai = 0;
                    listDaDuyetLayMau = new List<string>();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!string.IsNullOrEmpty(e.FieldValue.ToString()))
                        {
                            if (!listDaDuyetLayMau.Contains(e.FieldValue.ToString().Trim()))
                            {
                                countDistinctMauLayLai++;
                                listDaDuyetLayMau.Add(e.FieldValue.ToString().Trim());
                            }
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = countDistinctMauLayLai;
                    listDaDuyetLayMau.Clear();
                }
            }
            else if (e.Item == gvMauLayLai.GroupSummary.Where(x => x.FieldName.Equals("NguoiTuChoi", StringComparison.OrdinalIgnoreCase)).First())
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listMauLayLai_NguoiLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listMauLayLai_NguoiLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listMauLayLai_NguoiLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(",", listMauLayLai_NguoiLayMau);
                    listMauLayLai_NguoiLayMau.Clear();
                }
            }
            else if (e.Item == gvMauLayLai.GroupSummary.First(x => x.FieldName.Equals("NoiDungGhiChu", StringComparison.OrdinalIgnoreCase)))
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    listMauLayLai_GhiChuLayMau.Clear();
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue != null)
                    {
                        if (!listMauLayLai_GhiChuLayMau.Contains(e.FieldValue.ToString().Trim()))
                        {
                            listMauLayLai_GhiChuLayMau.Add(e.FieldValue.ToString().Trim());
                        }
                    }
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = string.Join(", ", listMauLayLai_GhiChuLayMau);
                    listMauLayLai_GhiChuLayMau.Clear();
                }
            }
        }
        private void chkChiTietMauLayLai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChiTietMauLayLai.Checked)
            {
                gvMauLayLai.ExpandAllGroups();
            }
            else
            {
                gvMauLayLai.CollapseAllGroups();
                if (radCheDoSHS.Checked)
                {
                    gvMauLayLai.ExpandGroupLevel(0);
                    gvMauLayLai.ExpandGroupLevel(1);
                }
                else
                    gvMauLayLai.ExpandGroupLevel(0);
            }
        }
        #endregion
        private string KiemTraThemKhoangTrangChoTenLoaiMau(string giaTriTen)
        {
            var returnTen = giaTriTen.Trim().ToUpper();
            giaTriTen = Utilities.ChuyenTvKhongDau(returnTen);
            var giatrilen = Encoding.Default.GetByteCount(giaTriTen);
            if (giaTriTen.Equals("PHAN", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("DIEN DI", StringComparison.OrdinalIgnoreCase))
                giatrilen = 6;
            else if (giaTriTen.Equals("HEPARIN", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("KHI MAU", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "  ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("SHPT", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "   ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("URINE", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + " ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("VI SINH", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "    ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            if (giatrilen < 16)
            {
                if (giatrilen < 7)
                    returnTen += "\t\t";
                else
                    returnTen += "\t";
            }
            return returnTen;
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

        private void btnLoadDanhSach_Click(object sender, EventArgs e)
        {
            if (radCheDoSHS.Checked && string.IsNullOrEmpty(txtBarcode.Text))
            {
                CustomMessageBox.MSG_Information_OK("Hãy nhập số hồ sơ.");
                txtBarcode.Focus();
            }
            else
            {
                Check_LoadDanhSach(false);
            }
        }

        private void FrmCLSXetNghiem_DuyetNhanMau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                txtBarcode.Focus();
                txtBarcode.SelectAll();
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnNhanMauChon_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnInBarcode_Click(sender, e);
            }
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
                var bnInfo = bnExisted.FirstOrDefault();
                var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                chidinh.TrangThaiMau = orderStatus;
                bnInfo.ChiDinh.Add(chidinh);
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
        private void btnNhanMauChon_Click(object sender, EventArgs e)
        {
            reloadCount = -10000;
            KiemTraCapNhat_NhanMau();
            reloadCount = 0;
        }
        private void KiemTraCapNhat_NhanMau()
        {
            if (gvDanhSach.RowCount == 0) return;
            if (gvDanhSach.FocusedRowHandle > -1 && gvMauChoDuyet.SelectedRowsCount > 0)
            {
                var danhSachViSinhChuaChonLoaiMauVS = string.Empty;
                var danhSachViSinhChuaChonLoaiMauSHPT = string.Empty;
                var danhSachViSinhChuaChonLoaiMauSLSS = string.Empty;
                var lstMatiepnhan = new List<string>();

                if (btnOpenOrder.Enabled && btnOpenOrder.Visible)
                {
                    CustomMessageBox.MSG_Information_OK("Bệnh phẩm đã bị đóng, nếu muốn thao tác xin vui lòng OPEN ORDER trên TPH và Infinity, sau đó thực hiện lại các tác vụ mong muốn");
                    return;
                }

                if (ucSearchLookupEditor_Doctor1.SelectedValue == null)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn thông tin người nhận mẫu!");
                    ucSearchLookupEditor_Doctor1.Focus();
                    ucSearchLookupEditor_Doctor1.ShowPopup();
                    return;
                }

                var barcode = string.IsNullOrEmpty(txtBarcode.Text) ? gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString() : txtBarcode.Text;
                //DataTable lưu thông tin mã tiếp nhận và xn sẽ in tem mã số mẫu
                var dataXnVaMaTiepNhanIntemSHPT = new DataTable();
                dataXnVaMaTiepNhanIntemSHPT.Columns.Add("MaTiepNhan", typeof(string));
                dataXnVaMaTiepNhanIntemSHPT.Columns.Add("MaXn", typeof(string));

                if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue == null)
                {
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = maMauDat;
                }
                var tinhtrangMau = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString();
                if (tinhtrangMau.Equals("lydokhac", StringComparison.OrdinalIgnoreCase))
                {
                    CustomMessageBox.MSG_Information_OK("Không thể nhận mẫu với tình trạng mẫu \"khác\".");
                    ucSearchLookupEditor_TinhTrangMau1.Focus();
                    return;
                }
                if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue != null)
                {
                    var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();

                    foreach (int i in gvMauChoDuyet.GetSelectedRows())
                    {
                        if (gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaTiepNhan) != null)
                        {
                            var itm = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaTiepNhan).ToString();
                            if (!lstMatiepnhan.Contains(itm))
                            {
                                lstMatiepnhan.Add(itm);
                               
                                GetDataForHL7ByMaTiepNhan(lstMaTiepNhanHL7, new GetUploadCondit
                                {
                                    userID = CommonAppVarsAndFunctions.UserID,
                                    matiepnhan = itm,
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
                        }
                    }
                    //Lấy danh sách mẫu đã lấy để đảm bảo ko bị sai
                    var data = _iPatient.Data_ChiDinhDaLayMau(string.Join(",", lstMatiepnhan));

                    if (data.Rows.Count > 0 || !QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh))
                    {
                        var lstDaLayMau = data.AsEnumerable().Select(x => x["MaXNBarcode"].ToString().Trim()).ToList();
                        var listCapNhatNhanMau = new List<string>();
                        var lstDSNhanMau = new List<NhanMauInfo>();
                        var maChidinh = string.Empty;
                        var chiDinhChuaLayMau = string.Empty;
                        var loaiMauNhanVS = (ucSearchLookupEditor_LoaiMauVS.SelectedValue == null ? string.Empty : ucSearchLookupEditor_LoaiMauVS.SelectedValue.ToString());
                        var benhphamSHPT = (ucSearchLookupEditor_LoaiMauSHPT.SelectedValue == null ? string.Empty : ucSearchLookupEditor_LoaiMauSHPT.SelectedValue.ToString());
                        var benhphamSLSS = (ucSearchLookupEditor_LoaiMauSLSS.SelectedValue == null ? string.Empty : ucSearchLookupEditor_LoaiMauSLSS.SelectedValue.ToString());
                        var maCapTren = string.Empty;
                        var profileID = string.Empty;
                        DateTime tgThucHien = C_Ultilities.ServerDate();
                        lstMatiepnhan = new List<string>();
                        var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                        foreach (int i in gvMauChoDuyet.GetSelectedRows())
                        {
                            maChidinh = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu) != null ? gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu).ToString() : "";
                            if (!string.IsNullOrEmpty(maChidinh))
                            {
                                var maloaiMau = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaLoaiMau).ToString().Trim();
                                var tenongmau = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_TenNhomLoaiMau).ToString().Trim();
                                var loaixetnghiem = int.Parse(gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_LoaiXetNghiem).ToString());
                                var matiepNhanChiTiet = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaTiepNhan).ToString().Trim();
                                if (lstDaLayMau.Contains(string.Format("{0}_{1}", maChidinh.Trim(), matiepNhanChiTiet.Trim())) || !QuiTrinhLAB.GetTrangThaiLayMauTheoRule(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXemQuiTrinh))
                                {
                                    var dataXNDaLayMau = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("MaxnBarcode = '{0}_{1}'", maChidinh.Trim(), matiepNhanChiTiet.Trim()));
                                    maCapTren = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaXN_His).ToString().Trim();
                                    profileID = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaProfile).ToString().Trim();
                                    var loaiDVXN = layLoaiXN(loaixetnghiem);
                                    if (loaiDVXN == ServiceType.ClsXNViSinh
                                        && string.IsNullOrEmpty(loaiMauNhanVS))
                                    {
                                        danhSachViSinhChuaChonLoaiMauVS += string.IsNullOrEmpty(danhSachViSinhChuaChonLoaiMauVS) ? "" : "\n";
                                        danhSachViSinhChuaChonLoaiMauVS += string.Format("{0}:{1}", maChidinh, tenongmau);
                                    }
                                    else if (loaiDVXN == ServiceType.ClsSHPT
                                       && string.IsNullOrEmpty(benhphamSHPT))
                                    {
                                        danhSachViSinhChuaChonLoaiMauSHPT += string.IsNullOrEmpty(danhSachViSinhChuaChonLoaiMauSHPT) ? "" : "\n";
                                        danhSachViSinhChuaChonLoaiMauSHPT += string.Format("{0}:{1}", maChidinh, tenongmau);
                                    }
                                    else if (loaiDVXN == ServiceType.ClsSLSS
                                     && string.IsNullOrEmpty(benhphamSLSS))
                                    {
                                        danhSachViSinhChuaChonLoaiMauSLSS += string.IsNullOrEmpty(danhSachViSinhChuaChonLoaiMauSHPT) ? "" : "\n";
                                        danhSachViSinhChuaChonLoaiMauSLSS += string.Format("{0}:{1}", maChidinh, tenongmau);
                                    }
                                    else
                                    {
                                        if (!lstMatiepnhan.Contains(matiepNhanChiTiet))
                                        {
                                            lstMatiepnhan.Add(matiepNhanChiTiet);

                                        }

                                        lstDSNhanMau.Add(new NhanMauInfo()
                                        {
                                            MaTiepNhan = matiepNhanChiTiet,
                                            NguoiThucHien = ucSearchLookupEditor_Doctor1.SelectedValue.ToString(),
                                            NguoiThucHienNhanMau = CommonAppVarsAndFunctions.UserID,
                                            Pcthuchien = Environment.MachineName,
                                            TrangThaiNhan = enumThucHien.DaThucHien,
                                            LyDoTuChoi = string.Empty,
                                            TinhTrangMau = tinhtrangMau,
                                            MaLoaiMau = maloaiMau,
                                            CheckXacNhanHis = false,
                                            Maxn = maChidinh,
                                            DeleteOrder = false,
                                            ThoiGianNhanMau = tgThucHien,
                                            LoaiXetNghiem = loaixetnghiem,
                                            MaLoaiMauNhan = (loaiDVXN == ServiceType.ClsSHPT) ? benhphamSHPT : ((loaiDVXN == ServiceType.ClsSLSS) ? benhphamSLSS : loaiMauNhanVS),
                                            IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                            KhuThucHienID = CommonAppVarsAndFunctions.PCWorkPlace,
                                            MaCapTren = maCapTren,
                                            ProfileId = profileID,
                                            MaBenhPhamGui = txtMaBenhPhamGui.Text
                                        });
                                        listCapNhatNhanMau.Add(maloaiMau);

                                        //Add data cho ds in tem mã số mẫu
                                        var drM = dataXnVaMaTiepNhanIntemSHPT.NewRow();
                                        drM["MaTiepNhan"] = matiepNhanChiTiet;
                                        drM["MaXn"] = maChidinh;
                                        dataXnVaMaTiepNhanIntemSHPT.Rows.Add(drM);

                                        //Thêm thông tin update HL7 về ISOFH
                                        AddInfoHL7(lstBnHL7Upate, lstMaTiepNhanHL7, matiepNhanChiTiet, maChidinh, maCapTren, OrderStatus.SampleGet);

                                        //var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet));
                                        //if (bnExisted.Any())
                                        //{
                                        //    var bnInfo = bnExisted.FirstOrDefault();
                                        //    var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                                        //    chidinh.TrangThaiMau = OrderStatus.SampleGet;
                                        //    bnInfo.ChiDinh.Add(chidinh);
                                        //}
                                        //else
                                        //{
                                        //    var bnAdd = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChiTiet)).First().CopyHISInfo();
                                        //    var chidinh = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(maChidinh) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).ToList();
                                        //    foreach (var itmChiDinh in chidinh)
                                        //    {
                                        //        itmChiDinh.TrangThaiMau = OrderStatus.SampleGet;
                                        //    }
                                        //    bnAdd.ChiDinh = chidinh;
                                        //    lstBnHL7Upate.Add(bnAdd);
                                        //}

                                    }
                                }
                                else
                                {
                                    chiDinhChuaLayMau += (string.IsNullOrEmpty(chiDinhChuaLayMau) ? "" : "\n");
                                    chiDinhChuaLayMau += string.Format("XN: {0} - Mẫu: {1}", maChidinh, tenongmau);
                                }
                            }
                        }
                        if (lstDSNhanMau.Count > 0)
                        {
                            _iPatient.Update_MauXn_NhanMau(lstDSNhanMau);
                            //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
                            _iPatient.Update_TrangThaiLayMau_NhanMau(string.Join(",", lstMatiepnhan), true, true);
                            //Trung > Cập nhật time chuyển, chỗ này luôn luôn là 1 MaTiepNhan, nhưng cứ dùng loop
                            foreach (var itemMaTiepNhan in lstMatiepnhan)
                                _iPatient.update_XN_TGChuyen_BNCLSXN(itemMaTiepNhan);

                            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT ==
                                (int)enumGioTinhThucHien.ThoiGianNhanMau)
                            {
                                _iPatient.Update_ThoiGianThucHienXN(string.Join(",", lstMatiepnhan));
                                _iPatient.Update_ThoiGianThucHienXN_Nhom(string.Join(",", lstMatiepnhan),
                                    CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCachTinhTAT);
                            }

                            if (lstBnHL7Upate.Count > 0)
                            {
                                Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                            }
                            // ucSearchLookupEditor_LoaiMauSHPT.SelectedValue = null;
                            ucSearchLookupEditor_LoaiMauVS.SelectedValue = null;
                            //ucSearchLookupEditor_LoaiMauSLSS.SelectedValue = null;
                        }
                        if (!string.IsNullOrEmpty(chiDinhChuaLayMau))
                            CustomMessageBox.MSG_Information_OK(string.Format(LanguageExtension.GetResourceValueFromValue(PatientLogConstant.CacXNChuaLayMau,
                        LanguageExtension.AppLanguage), chiDinhChuaLayMau));
                        if (!string.IsNullOrEmpty(danhSachViSinhChuaChonLoaiMauVS))
                            CustomMessageBox.MSG_Information_OK(string.Format(LanguageExtension.GetResourceValueFromValue(PatientLogConstant.CacXNViSinhChuaChonMauNhan,
                        LanguageExtension.AppLanguage), danhSachViSinhChuaChonLoaiMauVS));
                        if (!string.IsNullOrEmpty(danhSachViSinhChuaChonLoaiMauSHPT))
                            CustomMessageBox.MSG_Information_OK(string.Format(LanguageExtension.GetResourceValueFromValue(PatientLogConstant.CacXNSHPTChuaChonBenhPham,
                        LanguageExtension.AppLanguage), danhSachViSinhChuaChonLoaiMauSHPT));
                        if (!string.IsNullOrEmpty(danhSachViSinhChuaChonLoaiMauSLSS))
                            CustomMessageBox.MSG_Information_OK(string.Format(LanguageExtension.GetResourceValueFromValue(PatientLogConstant.CacXNSangLocChuaChonBenhPham,
                        LanguageExtension.AppLanguage), danhSachViSinhChuaChonLoaiMauSLSS));
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK(LanguageExtension.GetResourceValueFromValue(PatientLogConstant.KhongTimThayThongTinMauDaDuocLay,
                        LanguageExtension.AppLanguage));
                    }

                    if (chkInChiDinhKhiNhanMau.Checked)
                    {
                        foreach (var item in lstMatiepnhan)
                        {
                            InChiDinh(item);
                        }
                    }
                    Load_DanhSachBenhNhan(false);
                    //khi người dùng lick vào dòng thì không có số barcode trong textbox mà lấy theo row
                    if (!string.IsNullOrEmpty(txtBarcode.Text))
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, txtBarcode.Text);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    else if (lstMatiepnhan.Count > 0)
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_MaTiepNhan.FieldName, lstMatiepnhan[0]);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }

                    if (chkIntemSHPTkhiNhanMau.Checked && dataXnVaMaTiepNhanIntemSHPT.Rows.Count > 0)
                        XuLyInTemmaSoMauTheoBNvaXN(dataXnVaMaTiepNhanIntemSHPT);

                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtLyDo_TinhTrangMau.Text = string.Empty;
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtMaBenhPhamGui.Text = string.Empty;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn tình trạng mẫu.");
            }
        }
        private void UpdateTrangThaiVeHIS(List<BenhNhanInfoForHIS> lst)
        {
            foreach (var item in lst)
            {
                if (item.Hisproviderid.Equals((int)HisProvider.ISofH))
                {
                    var hisInfo = CommonAppVarsAndFunctions.HisConnectList.Where(x => ((int)x.HisID).Equals(item.Hisproviderid)).FirstOrDefault();
                    //Gọi về his nhận mẫu
                    _iHisData.LISCheckOrder(hisInfo, CommonAppVarsAndFunctions.HisFunctionConfigList, item);
                }
            }
        }
        private ServiceType layLoaiXN(int loaiXn)
        {
            if (loaiXn == (int)TestType.EnumTestType.ViSinh
                                    || loaiXn == (int)TestType.EnumTestType.ViSinhSoiNhuom
                                    || loaiXn == (int)TestType.EnumTestType.ViSinhNuoiCay
                                    || loaiXn == (int)TestType.EnumTestType.ViSinhNam)
                return ServiceType.ClsXNViSinh;
            else if (loaiXn == (int)TestType.EnumTestType.SinhHocPhanTu || loaiXn == (int)TestType.EnumTestType.SHPTThuongQuy)
                return ServiceType.ClsSHPT;
            else if (loaiXn == (int)TestType.EnumTestType.SLSS || loaiXn == (int)TestType.EnumTestType.TienSan)
                return ServiceType.ClsSLSS;
            else
                return ServiceType.ClsXetNghiem;
        }

        private void KiemTraCapNhat_TuChoiMau()
        {
            if (gvDanhSach.RowCount == 0) return;
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Từ chối / yêu cầu lấy lại các mẫu đang chọn?"))
            {
                var lstMatiepnhan = new List<string>();

                if (btnOpenOrder.Enabled && btnOpenOrder.Visible)
                {
                    CustomMessageBox.MSG_Information_OK("Bệnh phẩm đã bị đóng, nếu muốn thao tác xin vui lòng OPEN ORDER trên TPH và Infinity, sau đó thực hiện lại các tác vụ mong muốn");
                    return;
                }

                if (ucSearchLookupEditor_Doctor1.SelectedValue == null)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn thông tin người nhận mẫu!");
                    ucSearchLookupEditor_Doctor1.Focus();
                    ucSearchLookupEditor_Doctor1.ShowPopup();
                    return;
                }
                if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue == null)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập lý do yêu cầu lấy lại mẫu!");
                    ucSearchLookupEditor_TinhTrangMau1.Focus();
                    //ucSearchLookupEditor_TinhTrangMau1.sho = true;
                    return;
                }
                var lyDo = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString();
                if (lyDo.Equals("lydokhac", StringComparison.OrdinalIgnoreCase))
                {
                    lyDo = txtLyDo_TinhTrangMau.Text;
                }
                if (string.IsNullOrEmpty(lyDo))
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập lý do yêu cầu lấy lại mẫu!");
                    txtLyDo_TinhTrangMau.Focus();
                    return;
                }
                if (gvMauChoDuyet.SelectedRowsCount > 0 && gvMauDaDuyet.SelectedRowsCount > 0)
                {
                    CustomMessageBox.MSG_Information_OK("Chỉ chọn yêu cầu lấy lại trên 1 lưới chờ duyệt hoặc đã duyệt!");
                }
                else if (gvDanhSach.FocusedRowHandle > -1 && gvMauChoDuyet.SelectedRowsCount > 0)
                {
                    lstMatiepnhan = new List<string>();
                    List<string> listCapNhatTuChoiMau = new List<string>();
                    var lstTuChoiMau = new List<TuChoiMauInfo>();
                    var lstnhatKyMau = new List<NHATKY_MAUXETNGHIEM>();
                    var ok = false;
                    var maChidinh = string.Empty;
                    var maloaiMau = string.Empty;
                    var loaiXetNghiem = -1;
                    var matiepNhanChitiet = string.Empty;
                    var maCapTren = string.Empty;
                    var profileID = string.Empty;
                    DateTime tgThucHien = C_Ultilities.ServerDate();
                    var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();
                    var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                    foreach (int i in gvMauChoDuyet.GetSelectedRows())
                    {
                        maChidinh = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu) != null ? gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu).ToString() : "";

                        if (!string.IsNullOrEmpty(maChidinh))
                        {
                            maloaiMau = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaLoaiMau).ToString().Trim();
                            loaiXetNghiem = int.Parse(gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_LoaiXetNghiem).ToString().Trim());
                            matiepNhanChitiet = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaTiepNhan).ToString().Trim();
                            maCapTren = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaXN_His).ToString().Trim();
                            profileID = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaProfile).ToString().Trim();

                            if (!lstMatiepnhan.Contains(matiepNhanChitiet))
                            {
                                lstMatiepnhan.Add(matiepNhanChitiet);
                                GetDataForHL7ByMaTiepNhan(lstMaTiepNhanHL7, new GetUploadCondit
                                {
                                    userID = CommonAppVarsAndFunctions.UserID,
                                    matiepnhan = matiepNhanChitiet,
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
                            lstTuChoiMau.Add(new TuChoiMauInfo
                            {
                                MaTiepNhan = matiepNhanChitiet,
                                NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                Pcthuchien = Environment.MachineName,
                                TuChoi = true,
                                LyDoTuChoi = lyDo,
                                Maxn = maChidinh,
                                ThoiGianThucHien = tgThucHien,
                                LoaiXetNghiem = loaiXetNghiem,
                                IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                MaCapTren = maCapTren,
                                ProfileId = profileID
                            });

                            lstnhatKyMau.Add(new NHATKY_MAUXETNGHIEM
                            {
                                Matiepnhan = matiepNhanChitiet,
                                Maxn = maChidinh,
                                Lydo = lyDo,
                                NoiDungLydo = txtLyDo_TinhTrangMau.Text,
                                Nguoithuchien = CommonAppVarsAndFunctions.UserID,
                                Pcthuchien = Environment.MachineName,
                                Idthuchien = (int)TrangThaiThongTinXetNghiem.TuChoiMau,
                                Maphanloaidichvu = ServiceType.ClsXetNghiem.ToString(),
                                Maloaimau = maloaiMau,
                                Thoigianthuchien = tgThucHien,
                                IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau
                            });
                            //Thêm thông tin update HL7 về ISOFH
                            AddInfoHL7(lstBnHL7Upate, lstMaTiepNhanHL7, matiepNhanChitiet, maChidinh, maCapTren, OrderStatus.OrderRecieved);
                            //var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(matiepNhanChitiet));
                            //if (bnExisted.Any())
                            //{
                            //    var bnInfo = bnExisted.FirstOrDefault();
                            //    var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChitiet)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                            //    chidinh.TrangThaiMau = OrderStatus.OrderRecieved;
                            //    bnInfo.ChiDinh.Add(chidinh);
                            //}
                            //else
                            //{
                            //    var bnAdd = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(matiepNhanChitiet)).First().CopyHISInfo();
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
                    if (lstnhatKyMau.Count > 0)
                        ok = _iPatient.Insert_nhatky_mauxetnghiem(lstnhatKyMau);
                    if (ok)
                        ok = _iPatient.Update_MauXn_HoanDichVu_TuChoiMau(lstTuChoiMau);

                    if (lstBnHL7Upate.Count > 0)
                    {
                        Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                    }
                    if (lstMatiepnhan.Count > 0)
                    {
                        foreach (var itemMaTiepNhan in lstMatiepnhan)
                            _iPatient.update_XN_TGChuyen_BNCLSXN(itemMaTiepNhan);
                        //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
                        //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
                        _iPatient.Update_TrangThaiLayMau_NhanMau(string.Join(",", lstMatiepnhan), true, false);
                    }

                    //cboTrangThaiDuyet.SelectedIndex = 0;
                    Check_LoadDanhSach(true);
                    if (!string.IsNullOrEmpty(txtBarcode.Text))
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, txtBarcode.Text);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    else if (lstMatiepnhan.Count > 0)
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_MaTiepNhan.FieldName, lstMatiepnhan[0]);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtLyDo_TinhTrangMau.Text = string.Empty;
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
                else if (gvDanhSach.FocusedRowHandle > -1 && gvMauDaDuyet.SelectedRowsCount > 0)
                {
                    if (ucSearchLookupEditor_Doctor1.SelectedValue == null)
                    {
                        CustomMessageBox.MSG_Information_OK("Hãy chọn thông tin người nhận mẫu!");
                        ucSearchLookupEditor_Doctor1.Focus();
                        ucSearchLookupEditor_Doctor1.ShowPopup();
                        return;
                    }
                    lstMatiepnhan = new List<string>();
                    var lstTuChoiMau = new List<TuChoiMauInfo>();
                    var lstnhatKyMau = new List<NHATKY_MAUXETNGHIEM>();
                    var ok = false;
                    List<string> listCapNhatTuChoiMau = new List<string>();
                    var maChidinh = string.Empty;
                    var loaiXetNghiem = -1;
                    var matiepNhanChitiet = string.Empty;
                    var maCapTren = string.Empty;
                    var profileID = string.Empty;
                    //var matiepnhan = string.Empty;
                    DateTime tgThucHien = C_Ultilities.ServerDate();
                    foreach (int i in gvMauDaDuyet.GetSelectedRows())
                    {
                        maChidinh = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaDichVu) != null ? gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaDichVu).ToString() : "";
                        if (!string.IsNullOrEmpty(maChidinh))
                        {
                            loaiXetNghiem = int.Parse(gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_LoaiXetNghiem).ToString().Trim());
                            matiepNhanChitiet = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaTiepNhan).ToString().Trim();
                            maCapTren = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaXnHis).ToString().Trim();
                            profileID = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaProfile).ToString().Trim();
                            //matiepnhan = (string)gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaTiepNhan);
                            var maloaiMau = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaLoaiMau).ToString().Trim();
                            if (!lstMatiepnhan.Contains(matiepNhanChitiet))
                                lstMatiepnhan.Add(matiepNhanChitiet);
                            lstTuChoiMau.Add(new TuChoiMauInfo
                            {
                                MaTiepNhan = matiepNhanChitiet,
                                NguoiThucHien = CommonAppVarsAndFunctions.UserID,
                                Pcthuchien = Environment.MachineName,
                                TuChoi = true,
                                LyDoTuChoi = lyDo,
                                Maxn = maChidinh,
                                ThoiGianThucHien = tgThucHien,
                                LoaiXetNghiem = loaiXetNghiem,
                                IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                MaCapTren = maCapTren,
                                ProfileId = profileID

                            });
                            lstnhatKyMau.Add(new NHATKY_MAUXETNGHIEM
                            {
                                Matiepnhan = matiepNhanChitiet,
                                Maxn = maChidinh,
                                Lydo = lyDo,
                                NoiDungLydo = txtLyDo_TinhTrangMau.Text,
                                Nguoithuchien = CommonAppVarsAndFunctions.UserID,
                                Pcthuchien = Environment.MachineName,
                                Idthuchien = (int)TrangThaiThongTinXetNghiem.TuChoiMau,
                                Maphanloaidichvu = ServiceType.ClsXetNghiem.ToString(),
                                Maloaimau = maloaiMau,
                                Thoigianthuchien = tgThucHien,
                                IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau
                            });
                        }
                    }
                    //Tùng >> Cập nhật trạng thái
                    if (lstnhatKyMau.Count > 0)
                        ok = _iPatient.Insert_nhatky_mauxetnghiem(lstnhatKyMau);
                    if (ok)
                        ok = _iPatient.Update_MauXn_HoanDichVu_TuChoiMau(lstTuChoiMau);
                    if (lstMatiepnhan.Count > 0)
                    {
                        foreach (var itemMaTiepNhan in lstMatiepnhan)
                            _iPatient.update_XN_TGChuyen_BNCLSXN(itemMaTiepNhan);
                        //Tín > Cập nhật trạng thái lấy mẫu cho nhóm và bộ phận
                        _iPatient.Update_TrangThaiLayMau_NhanMau(string.Join(",", lstMatiepnhan), true, false);
                        if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhanMau)
                        {
                            _iPatient.Update_ThoiGianThucHienXN(string.Join(",", lstMatiepnhan));
                            _iPatient.Update_ThoiGianThucHienXN_Nhom(string.Join(",", lstMatiepnhan), (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                        }
                        foreach (var itemMaTiepNhan in lstMatiepnhan)
                            _iPatient.update_XN_TGChuyen_BNCLSXN(itemMaTiepNhan);
                    }

                    //cboTrangThaiDuyet.SelectedIndex = 0;
                    Load_DanhSachBenhNhan(true);
                    if (!string.IsNullOrEmpty(txtBarcode.Text))
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, txtBarcode.Text);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    else if (lstMatiepnhan.Count > 0)
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_MaTiepNhan.FieldName, lstMatiepnhan[0]);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtLyDo_TinhTrangMau.Text = string.Empty;
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
            }
        }
        private void Bo_DuyetNhanMau()
        {
            if (gvDanhSach.RowCount == 0) return;

            if (btnOpenOrder.Enabled && btnOpenOrder.Visible)
            {
                CustomMessageBox.MSG_Information_OK("Bệnh phẩm đã bị đóng, nếu muốn thao tác xin vui lòng OPEN ORDER trên TPH và Infinity, sau đó thực hiện lại các tác vụ mong muốn");
                return;
            }

            if (gvDanhSach.FocusedRowHandle > -1 && gvMauDaDuyet.SelectedRowsCount > 0)
            {
                var lstMatiepnhan = new List<string>();
                if (ucSearchLookupEditor_Doctor1.SelectedValue == null)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy chọn thông tin người nhận mẫu!");
                    ucSearchLookupEditor_Doctor1.Focus();
                    ucSearchLookupEditor_Doctor1.ShowPopup();
                    return;
                }
                if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue == null)
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập lý do bỏ duyệt mẫu!");
                    ucSearchLookupEditor_TinhTrangMau1.Focus();
                    return;
                }
                else if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString().Equals(maMauDat, StringComparison.OrdinalIgnoreCase))
                {
                    CustomMessageBox.MSG_Information_OK("Không thể bỏ duyệt với lý do mẫu Đạt.");
                    ucSearchLookupEditor_TinhTrangMau1.Focus();
                    return;
                }
                var lyDo = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString();
                if (lyDo.Equals("lydokhac", StringComparison.OrdinalIgnoreCase))
                {
                    lyDo = txtLyDo_TinhTrangMau.Text;
                }
                //Sau khi xử lý lấy lý do thì kiểm tra lại xem trường hợp khác có nhập thông tin không
                if (string.IsNullOrEmpty(lyDo))
                {
                    CustomMessageBox.MSG_Information_OK("Hãy nhập lý do bỏ duyệt mẫu!");
                    ucSearchLookupEditor_TinhTrangMau1.Focus();
                    return;
                }
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Bỏ duyệt nhận mẫu với các mẫu được chọn? \n* Lưu ý: Chỉ có thể hoàn tác nhận mẫu khi user được cấp quyền!"))
                {
                    var maChidinh = string.Empty;
                    var daCoKetQua = false;
                    var daUploadHis = false;
                    var tenNhomLoaiMau = string.Empty;
                    var ok = false;
                    var lstDSNhanMau = new List<NhanMauInfo>();
                    var lstnhatKyMau = new List<NHATKY_MAUXETNGHIEM>();
                    DateTime tgThucHien = C_Ultilities.ServerDate();
                    var loaiXetNghiem = -1;
                    var maloaiMau = string.Empty;
                    var Matiepnhan = string.Empty;
                    var barcode = string.Empty;
                    var maCapTren = string.Empty;
                    var profileID = string.Empty;
                    var lstMaTiepNhanHL7 = new List<BenhNhanInfoForHIS>();
                    var lstBnHL7Upate = new List<BenhNhanInfoForHIS>();
                    foreach (int i in gvMauDaDuyet.GetSelectedRows())
                    {
                        maChidinh = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaDichVu) != null ? gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaDichVu).ToString() : "";
                        if (!string.IsNullOrEmpty(maChidinh))
                        {
                            tenNhomLoaiMau = (string)gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_TenNhomMau);
                            maloaiMau = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaLoaiMau).ToString().Trim();
                            Matiepnhan = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaTiepNhan).ToString().Trim();
                            barcode = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_Barcode).ToString().Trim();
                            daCoKetQua = _iPatient.KiemTraCoKetQua(Matiepnhan, maloaiMau);
                            daUploadHis = _iPatient.KiemTraKetQuaDaGuiHis(Matiepnhan, maloaiMau);
                            loaiXetNghiem = int.Parse(gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_LoaiXetNghiem).ToString().Trim());
                            maCapTren = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaXnHis).ToString().Trim();
                            profileID = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaProfile).ToString().Trim();
                            bool continueAction = false;
                            if (daCoKetQua && ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestReturnWithResult))
                                continueAction = CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xét nghiệm của mẫu \"{0}\" \n- Số code: {1} đã có kết quả!\n Tiếp tục hủy mẫu?", tenNhomLoaiMau.ToUpper(), barcode));
                            else if (daUploadHis && ConfigurationDetail.CheckFunction(CommonAppVarsAndFunctions.PhanQuyenXetNghiem, UserConstant.PermissionTestDeleteCollectSampleValided))
                                continueAction = CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Xét nghiệm của mẫu \"{0}\" \n- Số code: {1} đã trả kết quả về HIS!\n Tiếp tục hủy mẫu?", tenNhomLoaiMau.ToUpper(), barcode));
                            else if (daCoKetQua)
                                CustomMessageBox.MSG_Error_OK(string.Format("Xét nghiệm của mẫu \"{0}\" \n- Số code: {1} đã có kết quả!", tenNhomLoaiMau.ToUpper(), barcode));
                            else if (daUploadHis)
                                CustomMessageBox.MSG_Error_OK(string.Format("Xét nghiệm của mẫu \"{0}\" \n- Số code: {1} đã trả kết quả về HIS!", tenNhomLoaiMau.ToUpper(), barcode));
                            else
                                continueAction = true;

                            if (continueAction)
                            {
                                if (!lstMatiepnhan.Contains(Matiepnhan))
                                {
                                    lstMatiepnhan.Add(Matiepnhan);
                                    GetDataForHL7ByMaTiepNhan(lstMaTiepNhanHL7, new GetUploadCondit
                                    {
                                        userID = CommonAppVarsAndFunctions.UserID,
                                        matiepnhan = Matiepnhan,
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

                                lstnhatKyMau.Add(new NHATKY_MAUXETNGHIEM
                                {
                                    Matiepnhan = Matiepnhan,
                                    Maxn = maChidinh,
                                    Lydo = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString(),
                                    Nguoithuchien = CommonAppVarsAndFunctions.UserID,
                                    Pcthuchien = Environment.MachineName,
                                    Idthuchien = (int)TrangThaiThongTinXetNghiem.HuyNhanMau,
                                    Maphanloaidichvu = ServiceType.ClsXetNghiem.ToString(),
                                    Maloaimau = maloaiMau,
                                    Thoigianthuchien = tgThucHien,
                                    IdLayLoaiMau = CommonAppVarsAndFunctions.IDLayLoaiMau,
                                    NoiDungLydo = txtLyDo_TinhTrangMau.Text
                                });

                                lstDSNhanMau.Add(new NhanMauInfo()
                                {
                                    MaTiepNhan = Matiepnhan
                                    ,
                                    NguoiThucHien = ucSearchLookupEditor_Doctor1.SelectedValue.ToString()
                                    ,
                                    NguoiThucHienNhanMau = CommonAppVarsAndFunctions.UserID
                                    ,
                                    Pcthuchien = Environment.MachineName
                                    ,
                                    TrangThaiNhan = enumThucHien.ChuaThucHien
                                    ,
                                    LyDoTuChoi = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString()
                                    ,
                                    TinhTrangMau = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString()
                                    ,
                                    MaLoaiMau = maloaiMau
                                    ,
                                    CheckXacNhanHis = false
                                    ,
                                    Maxn = maChidinh
                                    ,
                                    DeleteOrder = false
                                    ,
                                    LoaiXetNghiem = loaiXetNghiem,
                                    MaCapTren = maCapTren,
                                    ProfileId = profileID,
                                    MaBenhPhamGui = txtMaBenhPhamGui.Text
                                });

                                //Thêm thông tin update HL7 về ISOFH
                                AddInfoHL7(lstBnHL7Upate, lstMaTiepNhanHL7, Matiepnhan, maChidinh, maCapTren, OrderStatus.SampleCollect);
                                //var bnExisted = lstBnHL7Upate.Where(x => x.Matiepnhan.Equals(Matiepnhan));
                                //if (bnExisted.Any())
                                //{
                                //    var bnInfo = bnExisted.FirstOrDefault();
                                //    var chidinh = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(Matiepnhan)).First().ChiDinh.Where(c => c.MaXN.Equals(maChidinh)).First();
                                //    chidinh.TrangThaiMau = OrderStatus.SampleCollect;
                                //    bnInfo.ChiDinh.Add(chidinh);
                                //}
                                //else
                                //{
                                //    var bnAdd = lstMaTiepNhanHL7.Where(x => x.Matiepnhan.Equals(Matiepnhan)).First().CopyHISInfo();
                                //    var chidinh = bnAdd.ChiDinh.Where(c => c.MaXN.Equals(maChidinh) || (c.MaXNCha_His ?? string.Empty).Equals(maCapTren)).ToList();
                                //    foreach (var itmChiDinh in chidinh)
                                //    {
                                //        itmChiDinh.TrangThaiMau = OrderStatus.SampleCollect;
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
                        _iPatient.Update_MauXn_NhanMau(lstDSNhanMau);
                        //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
                        _iPatient.Update_TrangThaiLayMau_NhanMau(string.Join(",", lstMatiepnhan), true, false);
                        if (lstBnHL7Upate.Count > 0)
                        {
                            Task.Factory.StartNew(() => { UpdateTrangThaiVeHIS(lstBnHL7Upate); });
                        }
                        //Trung > Cập nhật ID chuyển mẫu = 0
                        //_iPatient.Update_IDChuyenMau(lstDSNhanMau);
                        foreach (var itemMaTiepNhan in lstMatiepnhan)
                            _iPatient.update_XN_TGChuyen_BNCLSXN(itemMaTiepNhan);
                        if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhanMau)
                        {
                            _iPatient.Update_ThoiGianThucHienXN(string.Join(",", lstMatiepnhan));
                            _iPatient.Update_ThoiGianThucHienXN_Nhom(string.Join(",", lstMatiepnhan), (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                        }
                    }
                    //// Cập nhật trạng thái
                    //foreach (var matiepNhan in lstMatiepnhan)
                    //{
                    //    if (CommonAppVarsAndFunctions.gioTinhTgThucHien == enumGioTinhThucHien.ThoiGianNhanMau)
                    //    {
                    //        _iPatient.Update_ThoiGianThucHienXN(matiepNhan);
                    //        _iPatient.Update_ThoiGianThucHienXN_Nhom(matiepNhan, (int)CommonAppVarsAndFunctions.gioTinhTgThucHien);
                    //    }
                    //    //Cập nhật trạng thái
                    //    _iPatient.Update_TrangThaiNhanMau(matiepNhan);
                    //}
                    //cboTrangThaiDuyet.SelectedIndex = 0;

                    Load_DanhSachBenhNhan(true);
                    //khi người dùng lick vào dòng thì không có số barcode trong textbox mà lấy theo row
                    if (!string.IsNullOrEmpty(txtBarcode.Text))
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_Barcode.FieldName, txtBarcode.Text);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    else if (lstMatiepnhan.Count > 0)
                    {
                        var idxFound = gvDanhSach.LocateByValue(colDS_MaTiepNhan.FieldName, lstMatiepnhan[0]);
                        gvDanhSach.FocusedRowHandle = (idxFound > -1 ? idxFound : 0);
                    }
                    txtLyDo_TinhTrangMau.Text = string.Empty;
                    ucSearchLookupEditor_TinhTrangMau1.SelectedValue = null;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
            }
        }

        private void btnHuyNhanMau_Click(object sender, EventArgs e)
        {
            reloadCount = 0;
            Bo_DuyetNhanMau();
            reloadCount = 0;
        }

        private void btnNhatKyMau_Click(object sender, EventArgs e)
        {
            var f = new FrmNhatkyTuChoi_Huy();
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                f.findBarcode = gvDanhSach.GetFocusedRowCellValue(colDS_Barcode).ToString();
                f.tuNgay = DateTime.Parse(gvDanhSach.GetFocusedRowCellValue(colDS_NgayTiepNhan).ToString());
            }
            f.pnMenu.Visible = true;
            f.AdjustForm();
            f.ShowDialog();
        }
        private DM_MAYTINH_MAYIN objPrintInfo;
        private void Load_Config()
        {
            var data = _iSysConfig.Data_DanhSach_CauHinhMayInbarcode(Environment.MachineName, 0, 1);
            if (data.Rows.Count == 0)
            {
                var dr = data.NewRow();
                dr["IDMay"] = "0";
                dr["TenMay"] = CommonAppVarsAndFunctions.LangMessageConstant.Barcodetieuchuan;
                data.Rows.Add(dr);
                data.AcceptChanges();
            }
            var idMay = _registryExtension.ReadRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample);
            cboMayInTem1.DataSource = data;
            cboMayInTem1.ValueMember = "IDMay";
            cboMayInTem1.DisplayMember = "TenMay";
            cboMayInTem1.ColumnNames = "IDMay,TenMay";
            cboMayInTem1.ColumnWidths = "15,150";
            cboMayInTem1.SelectedValue = string.IsNullOrEmpty(idMay) ? "0" : idMay;
            if (data != null & data.Rows.Count == 1)
                cboMayInTem1.SelectedIndex = 0;
            cboMayInTem1.SelectedIndexChanged += CboMayInTem_SelectedIndexChanged;
            LoadPrintbarcodeConfig();
        }
        private void LoadPrintbarcodeConfig()
        {
            var idMayXN = 0;

            if (cboMayInTem1.SelectedIndex > -1)
                idMayXN = WorkingServices.ValueString_Int_Zero(cboMayInTem1.SelectedValue.ToString());

            _registryExtension.WriteRegistry(CommonConstant.RegistryPrinterBarcode_OnGetSample, idMayXN.ToString());
            objPrintInfo = _iSysConfig.Get_info_CauHinh_MaInbarcode(Environment.MachineName, idMayXN, 1);
        }
        private void CboMayInTem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPrintbarcodeConfig();
        }
        private void Inbarcode(bool isRePrint)
        {
            var matiepNhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
            var bnInfo = _iPatient.Get_Info_BenhNhan_TiepNhan(matiepNhan, new string[] { });
            List<BENHNHAN_TIEPNHAN> lstBnInfo = new List<LIS.Patient.Model.BENHNHAN_TIEPNHAN>() { bnInfo };
            List<KETQUA_CLS_XETNGHIEM> objXetNghiem = null;
            if (objPrintInfo != null)
            {
                if (objPrintInfo.Giaothuc != null)
                {
                    if (objPrintInfo.Giaothuc.Equals(PrintingSystemProtocolList.BCRoboMT))
                    {
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog, " InBarcode : BCRoboMT", this.Text);
                        var lstMaTiepNhan = new List<string>();
                        foreach (var obj in lstBnInfo)
                        {
                            lstMaTiepNhan.Add(obj.Matiepnhan);
                        }
                        var objPrint = lstBnInfo.First();
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(
                                " InBarcode : BCRoboMT - Lấy danh sách chỉ dinh theo số hồ sơ:{0}{1}Các số code:{2} ",
                                objPrint.Bn_id, Environment.NewLine, lstMaTiepNhan), this.Text);
                        objXetNghiem = _iTestResult.lstXetnghiem(lstMaTiepNhan, string.Empty);
                        WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                            string.Format(" InBarcode : BCRoboMT - objXetNghiem -> Số record:{0}", objXetNghiem.Count),
                            this.Text);
                        PrintBarcodeHelper.PrintBarcode(new List<BENHNHAN_TIEPNHAN> { objPrint }, (isRePrint ? 3 : 1), objPrintInfo, isRePrint, null, objXetNghiem);
                        return;
                    }
                }
            }

            WriteLog.LogService.RecordLogFile(LogFile.ActionLog,
                string.Format(" InBarcode : {0} - objXetNghiem -> Số record:{1}",
                    objPrintInfo == null
                        ? "Normal"
                        : (objPrintInfo.Giaothuc == null ? "Normal" : objPrintInfo.Giaothuc),
                    objXetNghiem == null ? lstBnInfo.Count : objXetNghiem.Count), this.Text);
            PrintBarcodeHelper.PrintBarcode(lstBnInfo, (isRePrint ? 3 : 1), objPrintInfo, isRePrint, null, objXetNghiem, null, null);
        }
        private void btnInBarcode_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.FocusedRowHandle > -1)
            {
                Inbarcode(true);
            }
        }

        private void radXemTheoDSChuyenMau_CheckedChanged(object sender, EventArgs e)
        {
            var rad = (RadioButton)sender;
            if (rad.Checked)
            {
                rad.BackColor = CommonAppColors.ColorCheckedSelectedBackColor;
                _registryExtension.WriteRegistry(UserConstant.RegistryDanhSachNhanMauTheoIDChuyen, radXemTheoDSChuyenMau.Checked ? "1" : "0");
                Check_LoadDanhSach(false);
            }
            else
                rad.BackColor = Color.Empty;
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void txtBarcode_MouseClick(object sender, MouseEventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void radXemTheoDSThongThuong_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnChonNhom_Click(object sender, EventArgs e)
        {
            ChonNhomXN();
            btnLoadDanhSach_Click(sender, e);
        }
        private void ChonNhomXN()
        {
            var f = new FrmChonNhomNhanMau();
            f.ShowDialog();
            lstDanhSachNhom = (f.lstNhomNhanMau.Count == 0 ? CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList() : f.lstNhomNhanMau);
            Set_DSNhomVaoTitle();
        }

        private void Set_DSNhomVaoTitle()
        {
            if (lstDanhSachNhom.Count > 0 && lstDanhSachNhom.Count != CommonAppVarsAndFunctions.NhomClsXetNghiem.Count())
                lblNhom.Text = string.Join(",", lstDanhSachNhom);
            else
            {
                lblNhom.Text = "TẤT CẢ NHÓM";
                lstDanhSachNhom = CommonAppVarsAndFunctions.NhomClsXetNghiem.ToList();
            }
        }

        private void radCheDoSHS_CheckedChanged(object sender, EventArgs e)
        {
            gvDanhSach.OptionsSelection.MultiSelectMode = (radCheDoSHS.Checked ? GridMultiSelectMode.CheckBoxRowSelect : GridMultiSelectMode.CellSelect);
            gvDanhSach.OptionsSelection.MultiSelect = radCheDoSHS.Checked;

            radCheDoSHS.BackColor = radCheDoSHS.Checked ? CommonAppColors.ColorSelectedPage : Color.Empty;
            if (radCheDoSHS.Checked)
            {
                chkChiNhanKhiCo1Code.Text = CommonAppVarsAndFunctions.LangMessageConstant.Tunhanmaucuangaylay;
                dtpNhanCuaNgayLay.Visible = true;
                colDaLayMau_Barcode.GroupIndex = 1;
                colMauDaDuyet_Barcode.GroupIndex = 1;
                colMauLayLai_Barcode.GroupIndex = 1;
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    gcDanhSach.DataSource = null;
                    gcMauDaDuyet.DataSource = null;
                    gcMauChoDuyet.DataSource = null;
                    gcMauLayLai.DataSource = null;
                }
                else
                    Check_LoadDanhSach(false);
                txtBarcode.Focus();
            }
            else
            {
                chkChiNhanKhiCo1Code.Text = CommonAppVarsAndFunctions.LangMessageConstant.TunhanmaukhicoMOTBarcode;
                dtpNhanCuaNgayLay.Visible = false;
                colDaLayMau_Barcode.GroupIndex = -1;
                colMauDaDuyet_Barcode.GroupIndex = -1;
                colMauLayLai_Barcode.GroupIndex = -1;
                Check_LoadDanhSach(false);
                txtBarcode.Focus();
            }
        }

        private void radCheDoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            radCheDoBarcode.BackColor = radCheDoBarcode.Checked ? CommonAppColors.ColorSelectedPage : Color.Empty;
        }

        private void btnHoanXetNghiem_Click(object sender, EventArgs e)
        {

        }

        private void tmAutoLoadList_Tick(object sender, EventArgs e)
        {
            if (reloadCount >= reloadAfter)
            {
                reloadCount = 0;
                txtBarcode.Text = string.Empty;
                radCheDoBarcode.Checked = true;
                Check_LoadDanhSach(false);
            }
            else
                reloadCount++;
        }

        private void FrmCLSXetNghiem_DuyetNhanMau_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmAutoLoadList.Stop();
            reloadCount = 0;
            tmAutoLoadList.Enabled = false;

        }

        private void txtMaBenhPhamGui_Enter(object sender, EventArgs e)
        {
            txtMaBenhPhamGui.SelectAll();
        }

        private void txtMaBenhPhamGui_Click(object sender, EventArgs e)
        {
            txtMaBenhPhamGui.SelectAll();
        }

        private void btnCapNhatGioNhanMau_Click(object sender, EventArgs e)
        {
            if (gvMauDaDuyet.SelectedRowsCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Cập nhật thời gian nhận mẫu cho các xét nghiệm được chọn?{0} Thời gian mới:{1}", Environment.NewLine, dtpCapNhatGioNhanMau.Value.ToString("HH:mm:ss dd/MM/yyy"))))
                {
                    var lstMatiepnhan = new List<string>();
                    foreach (var itm in gvMauDaDuyet.GetSelectedRows())
                    {
                        if (gvMauDaDuyet.GetRowCellValue(itm, colMauDaDuyet_MaTiepNhan) != null)
                        {
                            var obj = new CapNhatThaoTacMau();
                            obj.Idthaotac = 1;
                            obj.Matiepnhan = WorkingServices.ObjecToString(gvMauDaDuyet.GetRowCellValue(itm, colMauDaDuyet_MaTiepNhan));
                            obj.Maxn = WorkingServices.ObjecToString(gvMauDaDuyet.GetRowCellValue(itm, colMauDaDuyet_MaDichVu));
                            obj.Nguoithuchiencu = WorkingServices.ObjecToString(gvMauDaDuyet.GetRowCellValue(itm, colMauDaDuyet_NguoiLayMau));
                            obj.Nguoithuchienmoi = CommonAppVarsAndFunctions.UserID;
                            obj.Pcthuchiencu = WorkingServices.ObjecToString(gvMauDaDuyet.GetRowCellValue(itm, colMaudaDuyet_PcNhanMau));
                            obj.Pcthuchienmoi = Environment.MachineName;
                            obj.Tgcu = WorkingServices.ConvertDate(WorkingServices.ObjecToString(gvMauDaDuyet.GetRowCellValue(itm, colMauDaDuyet_TGNhanMau)));
                            obj.Tgmoi = dtpCapNhatGioNhanMau.Value;
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
                            //Tín > Cập nhật trạng thái nhận mẫu cho nhóm và bộ phận
                            _iPatient.Update_TrangThaiNhanMau(string.Join(",", lstMatiepnhan), true);
                        }
                    }
                    Load_ChiTietOngMau(false);
                }
            }
        }
        private void InTemMaSoMau(List<string> lstMaXn, string maTiepNhan)
        {
            var bnInfo = _iPatient.Get_Info_BenhNhan_TiepNhan(maTiepNhan, new string[] { });
            var lstBarcode = new List<BarcodeProperties>();
            var currentdate = CommonAppVarsAndFunctions.ServerTime;
            var barcode = new BarcodeProperties();
            barcode.NamSinh = bnInfo.Tuoi.ToString();
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
            barcode.LableMachineID = 0;
            barcode.LoaiTem = BarcodePrinting.Constants.Loaibarcode.EnumLoaiBarcode.MaSoMauSHPT;
            barcode.DanhSachTube = new List<BarcodeTubeDetail>();
            for (int i = 0; i < gvMauDaDuyet.RowCount; i++)
            {
                if (gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaDichVu) != null)
                {
                    if (lstMaXn.Where(x => x.Equals(gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaDichVu).ToString())).Any())
                    {
                        //đảm bảo đúng mã tiếp nhận vì khi chế độ nhiều barcode có thể sai.
                        if (
                            !string.IsNullOrEmpty(gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaSoMau).ToString())
                            && maTiepNhan.Equals(gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaTiepNhan).ToString())
                            )
                        {
                            var obj = new BarcodeTubeDetail();
                            obj.Barcode = barcode.SoBarcode;
                            obj.BarcodeName = barcode.TenBarcode;
                            obj.NgayLayMau = DateTime.Parse(gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_TGLayMau).ToString());
                            obj.NguoiLayMau = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_NguoiLayMau).ToString();
                            obj.MaSoMau = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaSoMau).ToString();
                            obj.Tubecode = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaNhomLoaiMau).ToString();
                            obj.TubeCount = (int)numSotemMaSoMau.Value;
                            obj.Tubename = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_TenNhomMau).ToString();
                            obj.NhomXetNghiem = gvMauDaDuyet.GetRowCellValue(i, colMaudaDuyet_MaNhomChiDinh).ToString();
                            obj.BoPhanXetNghiem = string.Empty;
                            obj.KyTuDanhDau = string.Empty;
                            obj.TubeCate = gvMauDaDuyet.GetRowCellValue(i, colMauDaDuyet_MaLoaiMau).ToString();
                            barcode.DanhSachTube.Add(obj);
                        }
                    }
                }
            }
            if (barcode.DanhSachTube.Count > 0)
            {
                lstBarcode.Add(barcode);
                var t = new Task(() =>
                {
                    PrintBarcodeHelper.PrintBarcode(new DM_MAYTINH_MAYIN(), lstBarcode, null);
                });
                t.Start();
                CustomMessageBox.CloseAlert();
            }
        }

        private void btnIntemSHPT_Click(object sender, EventArgs e)
        {
            if (gvMauDaDuyet.SelectedRowsCount > 0)
            {
                //Xử lý dài do có chế độ nhận mẫu hàng loạt nhiều barcode cùng lúc nên phải tìm dựa vào lưới chi tiết
                var dataXnVaMaTiepNhanIntemSHPT = new DataTable();
                dataXnVaMaTiepNhanIntemSHPT.Columns.Add("MaTiepNhan", typeof(string));
                dataXnVaMaTiepNhanIntemSHPT.Columns.Add("MaXn", typeof(string));
                foreach (var item in gvMauDaDuyet.GetSelectedRows())
                {
                    if (gvMauDaDuyet.GetRowCellValue(item, colMauDaDuyet_MaDichVu) != null)
                    {
                        var dr = dataXnVaMaTiepNhanIntemSHPT.NewRow();
                        dr["MaTiepNhan"] = gvMauDaDuyet.GetRowCellValue(item, colMauDaDuyet_MaTiepNhan).ToString();
                        dr["MaXn"] = gvMauDaDuyet.GetRowCellValue(item, colMauDaDuyet_MaDichVu).ToString();
                        dataXnVaMaTiepNhanIntemSHPT.Rows.Add(dr);
                    }
                }
                XuLyInTemmaSoMauTheoBNvaXN(dataXnVaMaTiepNhanIntemSHPT);
            }
        }
        private void XuLyInTemmaSoMauTheoBNvaXN(DataTable dataXnVaMaTiepNhanIntemSHPT)
        {
            if (dataXnVaMaTiepNhanIntemSHPT.Rows.Count > 0)
            {
                var distinctMaTiepNhan = dataXnVaMaTiepNhanIntemSHPT.DefaultView.ToTable(true, "MaTiepNhan");
                if (distinctMaTiepNhan.Rows.Count > 0)
                {
                    foreach (DataRow drTn in distinctMaTiepNhan.Rows)
                    {
                        var maTiepNhan = drTn["MaTiepNhan"].ToString();
                        var dtMaXn = WorkingServices.SearchResult_OnDatatable(dataXnVaMaTiepNhanIntemSHPT, string.Format("MaTiepNhan = '{0}'", maTiepNhan));
                        if (dtMaXn.Rows.Count > 0)
                        {
                            var lstmaXn = new List<string>();
                            foreach (DataRow drXn in dtMaXn.Rows)
                            {
                                lstmaXn.Add(drXn["MaXn"].ToString());
                            }
                            InTemMaSoMau(lstmaXn, maTiepNhan);
                        }
                    }
                }
            }
        }

        private void gvDanhSach_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colDS_TGTheoPhut)
            {
                if (e.RowHandle > -1)
                {
                    var thoiGian = TPH.Common.Converter.NumberConverter.ToInt(e.CellValue);
                    if (thoiGian > CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanTrenNhanTre)
                    {
                        e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauNgoaiKhoangTre) ? Color.Red : ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauNgoaiKhoangTre));
                    }
                    else if (10 <= CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanDuoiNhanTre && CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemCanTrenNhanTre <= 13)
                    {
                        e.Appearance.BackColor = (string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauTrongKhoangTre) ? CommonAppColors.ColorCheckedSelectedBackColor : ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMauTrongKhoangTre));
                    }
                   
                }
            }
            else if (
                ((gvDanhSach.OptionsSelection.MultiSelectMode == GridMultiSelectMode.CheckBoxRowSelect 
                && gvDanhSach.OptionsSelection.MultiSelect) 
                && (e.Column.VisibleIndex == 1 || e.Column.VisibleIndex == 2))
                ||(!gvDanhSach.OptionsSelection.MultiSelect && (e.Column.VisibleIndex == 0 || e.Column.VisibleIndex == 1)) 
                )
            {
                var statusTQ = gvDanhSach.GetRowCellValue(e.RowHandle, colDS_TrangThaiNhanMauTQ).ToString();
                var statusVS = gvDanhSach.GetRowCellValue(e.RowHandle, colDS_TrangThaiNhanMauVS).ToString();
                var objTrangThai = LayThongTintrangThai(statusTQ, statusVS);
                if (objTrangThai.idTrangThaiNhanMauChung == enumTrangThaiNhanMau.DaNhanDu
                    && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauDuThaoTac))
                {
                    if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauDuThaoTac) != Color.Empty)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauDuThaoTac);
                    }
                }
                else if (objTrangThai.idTrangThaiNhanMauChung == enumTrangThaiNhanMau.ChuaNhanDu
                    && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauThaoTacChuaDu))
                {
                    if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauThaoTacChuaDu) != Color.Empty)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauThaoTacChuaDu);
                    }
                }
                else if (objTrangThai.idTrangThaiNhanMauChung == enumTrangThaiNhanMau.YeuCauLayLai
                    && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauYeuCauLayLai))
                {
                    if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauYeuCauLayLai) != Color.Empty)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauYeuCauLayLai);
                    }
                }
                else if ((objTrangThai.idTrangThaiNhanMauChung == enumTrangThaiNhanMau.ChuaThucHien || objTrangThai.idTrangThaiNhanMauChung == enumTrangThaiNhanMau.ChuaNhanMau)
                   && !string.IsNullOrEmpty(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauChuaThaoTac))
                {
                    if (ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauChuaThaoTac) != Color.Empty)
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemMau_MauChuaThaoTac);
                    }
                }
            }
        }

        private void chkKhongTuNhanMauKhiComauDaDuocNhan_CheckedChanged(object sender, EventArgs e)
        {
            chkKhongTuNhanMauKhiComauDaDuocNhan.BackColor = chkKhongTuNhanMauKhiComauDaDuocNhan.Checked ? CommonAppColors.ColorCheckedSelectedBackColor : Color.Empty;
            _registryExtension.WriteRegistry(UserConstant.RegistryKhongTuNhanKhiComauDaNhan, chkKhongTuNhanMauKhiComauDaDuocNhan.Checked ? "1" : "0");
        }  
        private void CheckWithSampleCode(string sampleCode)
        {
            if (CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemPhanBietMauTheobarcode)
            {
                if (!string.IsNullOrEmpty(sampleCode))
                {
                    if (gvMauChoDuyet.RowCount > 0)
                    {
                        var dta = (DataTable)gcMauChoDuyet.DataSource;
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
                        gcMauChoDuyet.DataSource = dta;
                        gvMauChoDuyet.ExpandAllGroups();
                        gvMauChoDuyet.SelectAll();
                        chkChiTietMauChoDuyet_CheckedChanged(chkChiTietMauChoDuyet, new EventArgs());
                    }
                    if (gvMauDaDuyet.RowCount > 0)
                    {
                        var dta = (DataTable)gcMauDaDuyet.DataSource;
                        for (int i = 0; i < dta.Rows.Count; i++)
                        {
                            var idMau = dta.Rows[i][colMauDaDuyet_MaNhomLoaiMau.FieldName].ToString();
                            if (!idMau.Equals(sampleCode))
                            {
                                dta.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                        dta.AcceptChanges();
                        gcMauDaDuyet.DataSource = dta;
                        gvMauDaDuyet.ExpandAllGroups();
                        gvMauDaDuyet.SelectAll();
                        chkChiTietMauDaDuyet_CheckedChanged(chkCHiTietMauDaDuyet, new EventArgs());
                    }
                    if (gvMauLayLai.RowCount > 0)
                    {
                        var dta = (DataTable)gcMauLayLai.DataSource;
                        for (int i = 0; i < dta.Rows.Count; i++)
                        {
                            var idMau = dta.Rows[i][colMauLayLai_MaNhomLoaiMau.FieldName].ToString();
                            if (!idMau.Equals(sampleCode))
                            {
                                dta.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                        dta.AcceptChanges();
                        gcMauDaDuyet.DataSource = dta;
                        gvMauLayLai.ExpandAllGroups();
                        chkChiTietMauLayLai_CheckedChanged(chkChiTietMauLayLai, new EventArgs());
                    }
                }
            }
        }
        private void ComboboxTrangThaiDuyet_Changed()
        {
            cboTrangThaiDuyet.SelectedIndexChanged -= CboTrangThaiDuyet_SelectedIndexChanged;
            cboTrangThaiDuyet.SelectedIndexChanged += CboTrangThaiDuyet_SelectedIndexChanged;
        }

        private void btnGuiMau_Click(object sender, EventArgs e)
        {
            if (gvMauChoDuyet.SelectedRowsCount > 0)
            {
                var tgGui = C_Ultilities.ServerDate();
                var lstUpdateNhom = new List<string>();
                var lstUpdateMaTiepNhan = new List<string>();
                var nhomUpdate = string.Empty;
                var manoiNhan = string.Empty;
                var haveAction = false;
                var guiMau = new GuiMauNoiBoModel();
                var matiepNhan = new List<string>();
                //Lấy danh sách mẫu gửi của barcode để kiểm tra
                var lstMauGui = new List<GuiMauNoiBoModel>();
                foreach (var i in gvMauChoDuyet.GetSelectedRows())
                {
                    if (gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu) != null)
                    {

                        guiMau = new GuiMauNoiBoModel();
                        guiMau.Nguoigui = CommonAppVarsAndFunctions.UserID;
                        guiMau.Pcgui = Environment.MachineName;
                        guiMau.Tggui = tgGui;
                        guiMau.Khuvucguiid = CommonAppVarsAndFunctions.PCWorkPlace;
                        guiMau.Manhomdichvu = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaNhomDichVu).ToString();
                        guiMau.Madichvu = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu).ToString();
                        guiMau.Matiepnhan = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaTiepNhan).ToString();
                        guiMau.Maongmau = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaNhomLoaiMau).ToString();
                        if (!matiepNhan.Where(x => x.Equals(guiMau.Matiepnhan)).Any())
                        {
                            matiepNhan.Add(guiMau.Matiepnhan);
                            var dataMauGui = Data_DS_XnGui(guiMau.Matiepnhan);

                            if (dataMauGui != null)
                            {
                                foreach (DataRow dataRow in dataMauGui.Rows)
                                {
                                    var obj = new GuiMauNoiBoModel();
                                    lstMauGui.Add((GuiMauNoiBoModel)WorkingServices.Get_InfoForObject(obj, dataRow));
                                }
                            }
                        }

                        //kiểm tra xn của mẫu này có gửi chưa
                        if (lstMauGui.Count > 0)
                        {
                            if (lstMauGui.Where(x => x.Matiepnhan.Equals(guiMau.Matiepnhan) && x.Madichvu.Equals(guiMau.Madichvu) && !x.Danhanmau).Any())
                            {
                                CustomMessageBox.MSG_Information_OK(string.Format("Không thể gửi mẫu nhiều lần.\nXét nghiệm: {0} đã được gửi mẫu và chưa được nhận.", guiMau.Madichvu));
                                continue;
                            }
                        }
                        if (string.IsNullOrEmpty(manoiNhan))
                        {
                            manoiNhan = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_IDNoiDuKienThucHien).ToString();
                            var f = new FrmChonKhuVuc();
                            f.IdKhuNhan = manoiNhan;
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                manoiNhan = f.IdKhuNhan;
                            }
                            else
                                break;
                        }
                        if (!string.IsNullOrEmpty(manoiNhan))
                        {
                            haveAction = true;
                            guiMau.Khuvucnhanid = manoiNhan;
                            _iPatient.Insert_GuimauNoiBo(guiMau);
                            nhomUpdate = string.Format("{0}^^{1}", guiMau.Matiepnhan, guiMau.Manhomdichvu);
                            if (!lstUpdateNhom.Contains(nhomUpdate))
                                lstUpdateNhom.Add(nhomUpdate);
                            if (!lstUpdateMaTiepNhan.Contains(guiMau.Matiepnhan))
                                lstUpdateMaTiepNhan.Add(guiMau.Matiepnhan);
                        }
                    }
                }
                if (lstUpdateNhom.Count > 0)
                {
                    foreach (var item in lstUpdateNhom)
                    {
                        var arr = item.Split(new string[] { "^^" }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length > 1)
                        {
                            _iPatient.Update_TrangThaiGuiMau_Nhom(arr[0], arr[1]);
                        }
                    }
                }

                if (haveAction)
                    Load_ChiTietOngMau(false);
            }
        }

        private void btnHuyGuiMau_Click(object sender, EventArgs e)
        {
            if (gvMauChoDuyet.SelectedRowsCount > 0)
            {
                var tgThucHien = C_Ultilities.ServerDate();
                var lstUpdateNhom = new List<string>();
                var lstUpdateMaTiepNhan = new List<string>();
                var nhomUpdate = string.Empty;
                var haveAction = false;
                var guiMau = new GuiMauNoiBoModel();
                if (ucSearchLookupEditor_TinhTrangMau1.SelectedValue != null && !string.IsNullOrEmpty(txtLyDo_TinhTrangMau.Text))
                {
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Hủy gửi mẫu các xét nghiệm đang chọn?"))
                    {
                        var dataMauGui = new DataTable();

                        var matiepNhan = new List<string>();
                        foreach (var i in gvMauChoDuyet.GetSelectedRows())
                        {
                            if (gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaDichVu) != null)
                            {
                                guiMau = new GuiMauNoiBoModel();
                                guiMau.Nguoithuchien = CommonAppVarsAndFunctions.UserID;
                                guiMau.Pcthuchien = Environment.MachineName;
                                guiMau.Tgthuchien = tgThucHien;
                                guiMau.Idloaithuchien = 2;
                                guiMau.Lydo = txtLyDo_TinhTrangMau.Text;
                                guiMau.Idlydo = ucSearchLookupEditor_TinhTrangMau1.SelectedValue.ToString();
                                guiMau.Idgui = long.Parse(gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_IdGui).ToString());
                                guiMau.Manhomdichvu = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaNhomDichVu).ToString();
                                guiMau.Matiepnhan = gvMauChoDuyet.GetRowCellValue(i, colDaLayMau_MaTiepNhan).ToString();
                                if (!matiepNhan.Where(x => x.Equals(guiMau.Matiepnhan)).Any())
                                {
                                    matiepNhan.Add(guiMau.Matiepnhan);
                                    if (dataMauGui.Rows.Count == 0)
                                        dataMauGui = Data_DS_XnGui(guiMau.Matiepnhan);
                                    else
                                        dataMauGui.Merge(Data_DS_XnGui(guiMau.Matiepnhan));
                                }

                                var dataTheoId = WorkingServices.SearchResult_OnDatatable_NoneSort(dataMauGui, string.Format("Idgui = {0} and DaNhanMau = 0", guiMau.Idgui));
                                if (dataTheoId.Rows.Count > 0)
                                {
                                    haveAction = true;
                                    _iPatient.Delete_XetNghiem_GuiMau(guiMau);
                                    nhomUpdate = string.Format("{0}^^{1}", guiMau.Matiepnhan, guiMau.Manhomdichvu);
                                    if (!lstUpdateNhom.Contains(nhomUpdate))
                                        lstUpdateNhom.Add(nhomUpdate);
                                    if (!lstUpdateMaTiepNhan.Contains(guiMau.Matiepnhan))
                                        lstUpdateMaTiepNhan.Add(guiMau.Matiepnhan);
                                }
                                else
                                {
                                    CustomMessageBox.MSG_Information_OK(string.Format("Xét nghiệm đã được nhận mẫu:\n{0}", gvMauChoDuyet.GetRowCellValue(i, colMauDaDuyet_TenDichVu).ToString()));
                                }
                            }
                        }
                        if (lstUpdateNhom.Count > 0)
                        {
                            foreach (var item in lstUpdateNhom)
                            {
                                var arr = item.Split(new string[] { "^^" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arr.Length > 1)
                                {
                                    _iPatient.Update_TrangThaiGuiMau_Nhom(arr[0], arr[1]);
                                }
                            }
                        }
                        if (haveAction)
                            Load_ChiTietOngMau(false);
                    }
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn lý do.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn xét nghiệm muốn hủy gửi.");
        }
        private DataTable Data_DS_XnGui(string matiepnhan)
        {
            return _iPatient.Data_XetNghiem_GuiMau(matiepnhan, 2, CommonAppVarsAndFunctions.NhomClsXetNghiem);
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

        private void pnCapNhatGioNhanMau_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdRefreshPrinter_Click(object sender, EventArgs e)
        {
            LabServices_Helper.LoadPrinterName(CommonAppVarsAndFunctions.LstPrinter, UserConstant.RegistryPrinterNhanMauInChiDinh, true);
            LabServices_Helper.LoadPrinterNameNormal(listPrinter, UserConstant.RegistryPrinterNhanMauInChiDinh, true);
        }

        #region InChiDinh
        private readonly IReportService _reportInfo = new ReportServiceImpl();

        private Image logo;
        private static ReportModel resultReportInfo;
        private static XtraReport ticketReport;
        private void InChiDinh(string matiepNhan)
        {
            if (!string.IsNullOrEmpty(matiepNhan))
            {
                if(logo == null)
                    logo = _iSysConfig.Load_Logo("BL");

                var dataPrint = _iPatient.DanhSachChiDinh_OngMau(matiepNhan, CommonAppVarsAndFunctions.IDLayLoaiMau);
                if (dataPrint.Rows.Count > 0)
                {
                    if (!dataPrint.Columns.Contains("Logo"))
                    {
                        dataPrint.Columns.Add("Logo", typeof(byte[]));
                    }
                    var logoAdd = GraphicSupport.ImageToByteArray(logo);
                    foreach (DataRow dr in dataPrint.Rows)
                    {
                        dr["Logo"] = logoAdd;
                    }
                    if (resultReportInfo == null)
                    {
                        resultReportInfo = _reportInfo.Info_Report(ReportConstants.DanhSachChiDinhNhanMau);
                    }

                    if (resultReportInfo.ReportSuDung == null)
                        return;

                    ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    var crv = new FrmPreViewReport
                    {
                        SampleID = string.Format("DanhSachChiDinh_{0}", dataPrint.Rows[0]["MaTiepNhan"].ToString().Trim()),
                        TenBN = dataPrint.Rows[0]["TenBN"].ToString().Trim()
                    };
                    var printerName = string.Empty;
                    if (listPrinter.Items.Count > 0)
                    {
                        if (listPrinter.SelectedIndex == -1)
                        {
                            listPrinter.SelectedIndex = 0;
                        }
                        printerName = listPrinter.SelectedItem.ToString();
                    }
                    ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
                    var havePrint = crv.ShowReport(ticketReport, dataPrint, true, printerName, "BL", resultReportInfo.TenDataset, resultReportInfo.TenDatatable, isInChiDinh: true);
                }
            }
        }
        #endregion

        private void btnInPhieuChiDinh_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.FocusedRowHandle >-1)
            {
                var matiepnhan = gvDanhSach.GetFocusedRowCellValue(colDS_MaTiepNhan).ToString();
                InChiDinh(matiepnhan);
            }
        }
    }
}
