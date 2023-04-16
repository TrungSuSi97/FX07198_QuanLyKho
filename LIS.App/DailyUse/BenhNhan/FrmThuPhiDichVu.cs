using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TPH.Cashier.CashierContanst;
using TPH.Cashier.Service;
using TPH.Common.Converter;
using TPH.Common.Extensions;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.DAO;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.BarcodePrinting.Barcode;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.TestResult.Services;
using TPH.LIS.User.Constants;
using TPH.LIS.User.Enum;
using TPH.Report.Constants;
using TPH.Report.Models;
using TPH.Report.Services;
using TPH.Report.Services.Impl;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmThuPhiDichVu : FrmTemplate
    {
        private readonly ISystemConfigService _iSysConfig = new SystemConfigService();
        private readonly ICashierService _isCashier = new CashierService();
        private Image logo;
        private static XtraReport ticketReport;
        private static ReportModel resultReportInfo;
        private readonly IReportService _reportInfo = new ReportServiceImpl();
        private readonly RegistryExtension _registryExtension = new RegistryExtension(0, UserConstant.RegistrySubKey);


        public FrmThuPhiDichVu()
        {
            InitializeComponent();
            ucChiTietChiDinh1.gvChiDinh.RowCellClick += GvChiDinh_RowCellClick;
            ucChiTietChiDinh1.gvChiDinh.KeyPress += GvChiDinh_KeyPress;
        }

        private void GvChiDinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            int RowHandle = (ucChiTietChiDinh1.gcChiDinh.FocusedView as ColumnView).FocusedRowHandle;
            var colhandle = (ucChiTietChiDinh1.gcChiDinh.FocusedView as ColumnView).FocusedColumn;

            if (colhandle.FieldName.Equals("DX$CheckboxSelectorColumn", StringComparison.OrdinalIgnoreCase))
            {
                if (ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(RowHandle, ucChiTietChiDinh1.MaChiDinh) != null)
                {
                    var maBienLai = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(RowHandle, ucChiTietChiDinh1.colMaBienLai).ToString();
                    if (!maBienLai.Trim().Equals("0"))
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void GvChiDinh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName.Equals("DX$CheckboxSelectorColumn", StringComparison.OrdinalIgnoreCase))
            {
                if (ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(e.RowHandle, ucChiTietChiDinh1.MaChiDinh) != null)
                {
                    var maBienLai = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(e.RowHandle, ucChiTietChiDinh1.colMaBienLai).ToString();
                    if (!maBienLai.Trim().Equals("0"))
                    {
                        ucChiTietChiDinh1.gvChiDinh.SetRowCellValue(e.RowHandle, e.Column, false);
                    }
                }
            }
        }


        C_Config config = new C_Config();
        C_BenhNhan_TiepNhan patient = new C_BenhNhan_TiepNhan();
        THUPHI_THUOC_DAL thuphithuocDAL = new THUPHI_THUOC_DAL();
        C_Patient pinfo = new C_Patient();
        DataTable dtPatientList = new DataTable();
        DataTable dtDSChiDinh = new DataTable();
        C_Patient_SieuAm p_sieuam = new C_Patient_SieuAm();
        ITestResultService p_xetnghiem = new TestResultService();
        C_Patient_XQuang p_xquang = new C_Patient_XQuang();
        C_Patient_NoiSoi p_noisoi = new C_Patient_NoiSoi();
        C_Patient_KhamBenh p_khambenh = new C_Patient_KhamBenh();
        C_Patient_DichVu_Khac p_dvkhac = new C_Patient_DichVu_Khac();
        private string _currencyFormat = "{0:#,###}";
        private void Load_List_BenhNhan(string seq = "")
        {
            dtPatientList = pinfo.GetPatient_List_InDay(dtpDateIn.Value, seq);
            ControlExtension.BindDataToGrid(dtPatientList.Copy(), ref dtgPatient, ref bvPatient);
            BindPatient(bvPatient.BindingSource);
        }
        private void Load_DS_ChiDinh()
        {
            string _MaTiepNhan = "";
            if (dtgPatient.RowCount > 0)
            {
                _MaTiepNhan = dtgPatient.CurrentRow.Cells[MaTiepNhan.Name].Value.ToString();
            }
            ucChiTietChiDinh1.Get_ChiTietChiDinh(_MaTiepNhan, new ServiceType[] { ServiceType.ClsXetNghiem, ServiceType.ClsSieuAm });
            if (ucChiTietChiDinh1.gvChiDinh.RowCount > 0)
            {
                for (int i = 0; i < ucChiTietChiDinh1.gvChiDinh.RowCount; i++)
                {
                    if (ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(i, ucChiTietChiDinh1.MaChiDinh) != null)
                    {
                        var maBienLai = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(i, ucChiTietChiDinh1.colMaBienLai).ToString();
                        if (maBienLai.Equals("0"))
                        {
                            ucChiTietChiDinh1.gvChiDinh.SelectRow(i);
                        }

                    }
                }
            }
            txtTongTien.Text = string.Format("{0: ### ### ### ##0}", ucChiTietChiDinh1.TotalMoney).Trim();
            txtDaThu.Text = string.Empty;
            txtChuaThu.Text = txtTongTien.Text;
        }


        private void ClearControl()
        {

            txtMaTiepNhan.DataBindings.Clear();
            txtMaTiepNhan.Text = "";
            txtTenBN.DataBindings.Clear();
            txtTenBN.Text = "";
            txtAddress.DataBindings.Clear();
            txtAddress.Text = "";
            txtPhone.DataBindings.Clear();
            txtPhone.Text = "";
            txtEmail.DataBindings.Clear();
            txtEmail.Text = "";
            txtAge.DataBindings.Clear();
            txtAge.Text = "";
            txtSex.DataBindings.Clear();
            txtSex.Text = "";
            chkAgeType.DataBindings.Clear();
            chkAgeType.Checked = false;
            dtpBirthday.DataBindings.Clear();
            dtpBirthday.Value = DateTime.Now;
            lblSex.Text = "";
            txtBSChiDinh.DataBindings.Clear();
            txtBSChiDinh.Text = "";
            txtDoiTuong.DataBindings.Clear();
            txtDoiTuong.Text = "";
            txtChanDoan.DataBindings.Clear();
            txtChanDoan.Text = "";

        }
        private void BindPatient(BindingSource bs)
        {
            ClearControl();

            txtMaTiepNhan.DataBindings.Clear();
            txtMaTiepNhan.DataBindings.Add("Text", bs, "MaTiepNhan");
            txtTenBN.DataBindings.Add("Text", bs, "TenBN");
            txtAddress.DataBindings.Add("Text", bs, "DiaChi");
            txtPhone.DataBindings.Add("Text", bs, "SDT");
            txtEmail.DataBindings.Add("Text", bs, "Email");
            txtAge.DataBindings.Add("Text", bs, "Tuoi");
            txtDoiTuong.DataBindings.Add("Text", bs, "TenDoiTuongDichVu");
            txtBSChiDinh.DataBindings.Add("Text", bs, "TenBacSiCD");
            chkAgeType.DataBindings.Add("Checked", bs, "CoNgaySinh");
            txtSex.DataBindings.Add("Text", bs, "GioiTinh");
            txtChanDoan.DataBindings.Add("Text", bs, "ChanDoan");
            dtpBirthday.DataBindings.Add("Value", bs, "SinhNhat", true, DataSourceUpdateMode.OnValidation, DateTime.Now);
        }
        private List<CashierItemSelected> Get_ChiDinhThuTien()
        {
            string maDV = "";
            string maLoaiDichVu = "";
            bool xnChinh = false;
            string profileID = string.Empty;
            List<CashierItemSelected> lstCashierItemSelected = new List<CashierItemSelected>();

            if (ucChiTietChiDinh1.gvChiDinh.GetSelectedRows().Length > 0)
            {
                for (int i = 0; i < ucChiTietChiDinh1.gvChiDinh.GetSelectedRows().Length; i++)
                {
                    if (ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.MaChiDinh) != null)
                    {
                        maDV = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.MaChiDinh).ToString();
                        maLoaiDichVu = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.MaPhanLoai).ToString();
                        xnChinh = bool.Parse(ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.ChiDinhCha).ToString());
                        lstCashierItemSelected.Add(new CashierItemSelected
                        {
                            ItemId = maDV,
                            ItemName = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.TenChiDinh).ToString(),
                            ItemCatagory = maLoaiDichVu,
                            IsProfile = xnChinh,
                            ProfileId = profileID,
                            ItemCount = 1,
                            ItemCost = double.Parse(ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.GiaRieng).ToString()),
                            ItemUnit = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.colDonViTinh).ToString(),
                            TestGruopId = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.colMaNhomChiDinh).ToString(),
                            TestGroupName = ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.colTenNhomChiDinh).ToString(),
                            ItemSort = int.Parse(ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.colSapXep).ToString()),
                            GroupSort = int.Parse(ucChiTietChiDinh1.gvChiDinh.GetRowCellValue(ucChiTietChiDinh1.gvChiDinh.GetSelectedRows()[i], ucChiTietChiDinh1.colThuTuIn).ToString())
                        });
                    }
                }
            }
            return lstCashierItemSelected;
        }
        private void TaoBienLai_TuChiDinh()
        {
            if (txtMaTiepNhan.Text != "")
            {
                string _MaTiepNhan = txtMaTiepNhan.Text.Trim();
                var selectedList = Get_ChiDinhThuTien();
                var idBienLai = TaoBienlaiThuTien(selectedList);
                if (string.IsNullOrEmpty(idBienLai)) return;
                if (chkThuPhi_InTrucTiep.Checked)
                    CustomMessageBox.ShowAlert("Đang tạo biên lai!");
                InBienLai(idBienLai, _MaTiepNhan, selectedList, chkUpdateChagreAuto.Checked, !chkThuPhi_InTrucTiep.Checked);
                Load_DS_ChiDinh();
                Load_DanhSach_BienLai();
                gvBienLai.FocusedRowHandle = gvBienLai.LocateByValue("ID", idBienLai);
                //bvDanhSachBienLai.BindingSource.Position = bvDanhSachBienLai.BindingSource.Find("ID", idBienLai);
                CustomMessageBox.CloseAlert();
            }
        }
        private void InBienLai(string idBienLai, string _MaTiepNhan, List<CashierItemSelected> selectedList, bool batThuTien, bool xemTruoc, List<string> listMaDichVu = null)
        {
            if (string.IsNullOrEmpty(idBienLai)) return;
            var inBienLai = In_BienLai(xemTruoc, LabServices_Helper.Get_PrinterSelected(listPrinterCharge), idBienLai,
                EnumThaoTacThuPhi.ThuTien, listMaDichVu);
            if (inBienLai)
            {
                _isCashier.CapNhat_InBL(idBienLai, CommonAppVarsAndFunctions.UserID, true);
            }
            if (batThuTien)
            {
                BatCoThuTien(_MaTiepNhan, idBienLai, selectedList, true);
            }
            //if (!string.IsNullOrEmpty(idBienLai))
            //{
            //    Print_Invoice(xemTruoc, LabServices_Helper.Get_PrinterSelected(listPrinterCharge), idBienLai, EnumThaoTacThuPhi.ThuTien);

            //    if (batThuTien)
            //    {
            //        BatCoThuTien(_MaTiepNhan, idBienLai, selectedList, true);
            //    }
            //}
        }

        public bool In_BienLai(bool isReView, string printerName, string idBienLai, EnumThaoTacThuPhi loai, List<string> listMaDichVu)
        {

            var dataPrint = _isCashier.Data_DanhSachChiDinh_BL(idBienLai, loai, EnumChon.TatCa, listMaDichVu: listMaDichVu);
            if (dataPrint.Rows.Count == 0) return false;
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
                resultReportInfo = _reportInfo.Info_Report(ReportConstants.BienLaiThuTien);
            }

            if (resultReportInfo.ReportSuDung == null)
                return false;

            ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
            var crv = new FrmPreViewReport
            {
                SampleID = string.Format("Bienlai_{0}", dataPrint.Rows[0]["MaTiepNhan"].ToString().Trim()),
                TenBN = dataPrint.Rows[0]["TenBN"].ToString().Trim()
            };
            ticketReport = _reportInfo.CreateReportFromStream(resultReportInfo.ReportSuDung);
            return crv.ShowReport(ticketReport, dataPrint, !isReView, printerName, "BL", resultReportInfo.TenDataset, resultReportInfo.TenDatatable);
        }

        private void btnDaThuTien_Click(object sender, EventArgs e)
        {
            if (txtMaTiepNhan.Text != "")
            {
                if (gvBienLai.RowCount > 0)
                {
                    string maTiepNhan = StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaTiepNhan));
                    string idBienlai = StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaBienLai));
                    List<CashierItemSelected> selectedList = Get_SelectedDetail_List(0);
                    if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật đã thu tiền?"))
                    {
                        BatCoThuTien(maTiepNhan, idBienlai, selectedList, true);
                    }
                }
            }
        }
        /// <summary>
        /// Lấy danh sách để thực hiện bật cờ
        /// </summary>
        /// <param name="kieuLay">0: Thu tiền - 1 : Hoàn tiền - 2: In dịch vụ</param>
        /// <returns></returns>
        private List<CashierItemSelected> Get_SelectedDetail_List(int kieuLay)
        {
            List<CashierItemSelected> lst = new List<CashierItemSelected>();

            if (gvChiTietBienlai.RowCount > 0)
            {
                for (int i = 0; i < gvChiTietBienlai.RowCount; i++)
                {
                    if (gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu) != null)
                    {
                        var chon = gvChiTietBienlai.GetRowCellValue(i, colChiTietnBl_Chon) == null ? false : (bool)gvChiTietBienlai.GetRowCellValue(i, colChiTietnBl_Chon);
                        if (chon || kieuLay == 2)
                        {
                            var dathuTien = (bool)gvChiTietBienlai.GetRowCellValue(i, colBienLai_DaThuTien);
                            var daHoatien = (bool)gvChiTietBienlai.GetRowCellValue(i, colBienLai_DaHoanTien);
                            if ((kieuLay == 0 && dathuTien == false) || (kieuLay == 1 && daHoatien == false && dathuTien) || kieuLay == 2)
                            {
                                lst.Add(new CashierItemSelected
                                {
                                    ItemId = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu).ToString(),
                                    ItemName = gvChiTietBienlai.GetRowCellValue(i, colBienLai_TenDichVu).ToString(),
                                    ItemCatagory = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaPhanLoai).ToString(),
                                    IsProfile = false,
                                    ProfileId = string.Empty,
                                    ItemCount = 1,
                                    ItemCost = double.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_Dongia).ToString()),
                                    ItemUnit = gvChiTietBienlai.GetRowCellValue(i, colBienLai_DonViTinh).ToString(),
                                    TestGruopId = gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaNhomDichVu).ToString(),
                                    TestGroupName = gvChiTietBienlai.GetRowCellValue(i, colBienLai_TenNhomDichVu).ToString(),
                                    ItemSort = int.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_ThuTuInDichVu).ToString()),
                                    GroupSort = int.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_ThuTuInNhom).ToString())
                                });
                            }
                            else
                            {
                                gvChiTietBienlai.SetRowCellValue(i, colBienLaiMaBienLai, false);
                            }
                        }
                    }
                }
            }
            return lst;
        }
        private string TaoBienlaiThuTien(List<CashierItemSelected> selectedList)
        {
            //string _MaTiepNhan = txtMaTiepNhan.Text.Trim();
            //return _isCashier.TaoBienlaiThuTien(_MaTiepNhan, selectedList, Environment.MachineName
            //       , cboUsersign.SelectedValue.ToString(), decimal.Parse(txtTongTien.Text.Replace(" ", ""))
            //         , decimal.Parse(string.IsNullOrEmpty(txtDaThu.Text.Replace(" ", "")) ? txtTongTien.Text.Replace(" ", "") : txtDaThu.Text.Replace(" ", ""))
            //          , string.Empty, EnumHinhThucThanhToan.TienMat, CommonAppVarsAndFunctions.UserID);
            var _MaTiepNhan = txtMaTiepNhan.Text.Trim();
            if (cboUsersign.SelectedIndex > -1)
            {
                decimal chietKhau = 0;
                int phanTramChietKhau = 0;
                bool IsCalPhanTramChietKhau = false;

                if (radCK_VND.Checked)
                {
                    chietKhau = NumberConverter.ToDecimal(txtCK.Text);
                }
                else if (radCK_Per.Checked)
                {
                    chietKhau = NumberConverter.ToDecimal(txtTongTien.Text.Replace(" ", "")) * NumberConverter.ToDecimal(txtCK.Text) / 100;
                    phanTramChietKhau = NumberConverter.ToInt(txtCK.Text);
                    IsCalPhanTramChietKhau = radCK_Per.Checked ? true : false;
                }

                return _isCashier.TaoBienlaiThuTien(_MaTiepNhan, selectedList, Environment.MachineName
                       , cboUsersign.SelectedValue.ToString(), decimal.Parse(txtTongTien.Text.Replace(" ", ""))
                         , decimal.Parse(string.IsNullOrEmpty(txtDaThu.Text.Replace(" ", "")) ? txtTongTien.Text.Replace(" ", "") : txtDaThu.Text.Replace(" ", ""))
                          , string.Empty, EnumHinhThucThanhToan.TienMat, CommonAppVarsAndFunctions.UserID, chietKhau, phanTramChietKhau, IsCalPhanTramChietKhau);
            }

            CustomMessageBox.MSG_Information_OK("Hãy chọn thu ngân");
            return string.Empty;

        }
        private void BatCoThuTien(string maTiepNhan, string idBienlai, List<CashierItemSelected> lstCashierItemSelected, bool isThuTien)
        {
            if (_isCashier.CapNhat_ThuTien(maTiepNhan, isThuTien, lstCashierItemSelected, idBienlai) && isThuTien)
            {
                _isCashier.CapNhat_ThuTien_BienLai(idBienlai);
                _isCashier.CapNhat_ThuTien_ChiTiet_BienLai(idBienlai, lstCashierItemSelected);
            }
        }
        private void btnRefreshChargeList_Click(object sender, EventArgs e)
        {
            Load_List_BenhNhan();
            Load_DS_ChiDinh();
            Load_DanhSach_BienLai();
            SearchDS_TiepNhan();
        }

        private void dtgPatient_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Load_DS_ChiDinh();
            Load_DanhSach_BienLai();
        }

        private void dtpDateIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Load_List_BenhNhan();
                Load_DS_ChiDinh();
                Load_DanhSach_BienLai();
            }
        }

        private void txtFindSEQ_KeyUp(object sender, KeyEventArgs e)
        {
            txtFindName.Text = "";
            if (txtFindSEQ.Text == "")
            {
                ClearGridView();
                Load_List_BenhNhan();
                if (ucChiTietChiDinh1.gvChiDinh.RowCount <= 0) return;
                Load_DS_ChiDinh();
                Load_DanhSach_BienLai();
            }
            else
                bvPatient.BindingSource.Position = bvPatient.BindingSource.Find("SEQ", txtFindSEQ.Text);
        }

        private void ClearGridView()
        {
            ucChiTietChiDinh1.gcChiDinh.DataSource = null;
            gcBienLai.DataSource = null;
            gcChiTietBienLai.DataSource = null;
        }

        private void txtFindName_KeyUp(object sender, KeyEventArgs e)
        {
            txtFindSEQ.Text = "";
            if (txtFindName.Text == "")
            {
                Load_List_BenhNhan();
                Load_DS_ChiDinh();
            }
            else
                LabServices_Helper.Filter_BindingSource(dtgPatient, bvPatient, dtPatientList, "TenBN", txtFindName.Text);

        }
        private void listPrinterCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            _registryExtension.WriteRegistry(
                UserConstant.RegistryListPrinterCharge,
                listPrinterCharge.SelectedItem.ToString());
        }

        private void btnTaoBienLai_BienLai_Click(object sender, EventArgs e)
        {
            if (ucChiTietChiDinh1.gvChiDinh.SelectedRowsCount > 0)
            {
                TaoBienLai_TuChiDinh();
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Không có chỉ định được chọn\nHoặc biên lai đã được tạo!");
            }
        }

        private void FrmThuPhiDichVu_Load(object sender, EventArgs e)
        {
            C_NguoiDung user = new C_NguoiDung();
            user.Get_Group_UserSign(cboUsersign, ServiceType.ThuNgan, " and d.MaNguoiDung not in ('admin')");
            user.Get_Group_UserSign(cboThuNgan2, ServiceType.ThuNgan, " and d.MaNguoiDung not in ('admin')");
            user.Get_Group_UserSign(cboThuNganHoantien, ServiceType.ThuNgan, " and d.MaNguoiDung not in ('admin')");

            cboUsersign.SelectedValue = CommonAppVarsAndFunctions.UserID;
            cboThuNgan2.SelectedValue = CommonAppVarsAndFunctions.UserID;

            cboThuNganHoantien.SelectedValue = CommonAppVarsAndFunctions.UserID;

            LabServices_Helper.LoadPrinterName(listPrinterCharge, UserConstant.RegistryListPrinterCharge, false);
            Load_List_BenhNhan();
            Load_DS_ChiDinh();
            logo = _iSysConfig.Load_Logo("BL");

        }

        public bool Print_Invoice(
            bool isReView,
            string printerName, string idBienLai, EnumThaoTacThuPhi loai)
        {

            var dtPrint = _isCashier.Data_DanhSachChiDinh_BL(idBienLai, loai, EnumChon.TatCa);
            if (dtPrint.Rows.Count == 0) return false;

            var ic = new ImageConverter();
            var barcode =
                (byte[])
                    ic.ConvertTo(
                        Code128Rendering.MakeBarcodeImage(dtPrint.Rows[0]["SEQ"].ToString().Trim(), 1, true),
                        typeof(byte[]));

            foreach (DataRow dr in dtPrint.Rows)
            {
                dr["barcode"] = barcode;
            }

            //var rp = new Reports.rpBienLaiA5();
            //var crv = new FrmReport();
            //crv.SampleID = string.Format("Bienlai_{0}", dtPrint.Rows[0]["MaTiepNhan"].ToString().Trim());
            //crv.TenBN = dtPrint.Rows[0]["TenBN"].ToString().Trim();

            //return crv.Excute_Show_Print_Report(rp, dtPrint, "BL", false, false, isReView, !isReView, printerName, false);
            return false;
        }

        #region Bien lai thu phí
        private void Load_DanhSach_BienLai(string idBienLai = "")
        {
            string matiepNhan = "NULL";
            if (dtgPatient.RowCount > 0)
                matiepNhan = dtgPatient.CurrentRow.Cells[MaTiepNhan.Name].Value.ToString();
            else
                matiepNhan = string.Empty;
            var data = _isCashier.Data_p_payment(idBienLai, matiepNhan, null, null, string.Empty);
            gcBienLai.DataSource = data;
            gvBienLai.ExpandAllGroups();
            if (gvBienLai.RowCount > 0)
                gvBienLai.FocusedRowHandle = 0;
        }


        private void txtDaThu_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtTongTien.Text))
            //{
            //    if (!string.IsNullOrEmpty(txtDaThu.Text))
            //    {
            //        if (WorkingServices.IsNumeric(txtDaThu.Text))
            //        {
            //            txtChuaThu.Text = string.Format("{0: ### ### ### ##0}", double.Parse(txtTongTien.Text.Replace(" ", "")) - double.Parse(txtDaThu.Text)).Trim();
            //        }
            //    }
            //    else
            //        txtChuaThu.Text = "0";
            //}
            calChuaThu();
        }

        private void gvBienLai_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void gvBienLai_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_ChitietBienLai();
        }

        private void Load_ChitietBienLai()
        {
            DataTable data = new DataTable();
            if (gvBienLai.RowCount == 0)
            {
                data = _isCashier.Data_DanhSachChiDinh_BL("0000", EnumThaoTacThuPhi.ThuTien, EnumChon.TatCa);
            }
            else
            {
                string maTiepNhan = StringConverter.ToString(gvBienLai.GetFocusedRowCellValue(colBienLaiMaTiepNhan));
                string idBienlai = StringConverter.ToString(gvBienLai.GetFocusedRowCellValue(colBienLaiMaBienLai));
                if (!string.IsNullOrEmpty(maTiepNhan) && !string.IsNullOrEmpty(idBienlai))
                {
                    EnumThaoTacThuPhi loai = (EnumThaoTacThuPhi)Enum.Parse(typeof(EnumThaoTacThuPhi), gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThaoTac).ToString());
                    data = _isCashier.Data_DanhSachChiDinh_BL(idBienlai, loai, EnumChon.TatCa);

                    if (loai == EnumThaoTacThuPhi.ThuTien)
                    {
                        KiemTra_checkTuDongDichVuThuPhi(true);
                    }
                }
            }
            Set_ThongTinBienLai();
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            bvChiTietBienLai.BindingSource = bs;
            gcChiTietBienLai.DataSource = bs;
            gvChiTietBienlai.ExpandAllGroups();
        }
        private void Set_ThongTinBienLai()
        {
            txtTongTien_BienLai.Text = string.Empty;
            txtThanhToan_BienLai.Text = string.Empty;
            txtConNo_BienLai.Text = string.Empty;
            cboThuNgan2.SelectedIndex = -1;

            if (gvBienLai.FocusedRowHandle > -1)
            {
                txtTongTien_BienLai.Text = string.Format("{0: ### ### ### ##0}", double.Parse(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiTongTien).ToString()));
                txtThanhToan_BienLai.Text = string.Format("{0: ### ### ### ##0}", double.Parse(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThanhToan).ToString()));
                txtConNo_BienLai.Text = string.Format("{0: ### ### ### ##0}", double.Parse(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiConLai).ToString()));
                cboThuNgan2.SelectedValue = gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThuNgan).ToString();
            }
        }
        private void txtThanhToan_BienLai_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTongTien_BienLai.Text))
            {
                if (!string.IsNullOrEmpty(txtThanhToan_BienLai.Text))
                {
                    if (WorkingServices.IsNumeric(txtThanhToan_BienLai.Text))
                    {
                        txtConNo_BienLai.Text = string.Format("{0: ### ### ### ##0}", double.Parse(txtTongTien_BienLai.Text.Replace(" ", "")) - double.Parse(txtThanhToan_BienLai.Text.Replace(" ", ""))).Trim();
                    }
                }
                else
                    txtConNo_BienLai.Text = "0";
            }
        }

        private void btnCapNhatThanhToan_Click(object sender, EventArgs e)
        {
            if (gvBienLai.FocusedRowHandle > -1)
            {
                string idBienlai = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaBienLai));
                _isCashier.CapNhat_ThanhToan_ChoBL(idBienlai, decimal.Parse(string.IsNullOrEmpty(txtThanhToan_BienLai.Text) ? txtTongTien_BienLai.Text.Replace(" ", "") : txtThanhToan_BienLai.Text.Replace(" ", "")));
                Load_DanhSach_BienLai();
                gvBienLai.FocusedRowHandle = gvBienLai.LocateByValue("ID", idBienlai);
            }
        }

        private void txtThanhToan_BienLai_Enter(object sender, EventArgs e)
        {
            txtThanhToan_BienLai.SelectAll();
        }

        private void txtThanhToan_BienLai_Click(object sender, EventArgs e)
        {
            txtThanhToan_BienLai.SelectAll();
        }

        private void bntChonThuTien_Click(object sender, EventArgs e)
        {
            KiemTra_checkTuDongDichVuThuPhi(true);
        }
        private void KiemTra_checkTuDongDichVuThuPhi(bool CheckThuTien)
        {
            if (gvChiTietBienlai.RowCount > 0)
            {
                for (int i = 0; i < gvChiTietBienlai.RowCount; i++)
                {
                    if (gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu) != null)
                    {
                        var thuTien = bool.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_DaThuTien).ToString());
                        var hoantien = bool.Parse(gvChiTietBienlai.GetRowCellValue(i, colBienLai_DaHoanTien).ToString());
                        gvChiTietBienlai.SetRowCellValue(i, colChiTietnBl_Chon, (CheckThuTien ? (!thuTien) : (thuTien ? (!hoantien) : false)));
                    }
                }
            }
        }

        private void bntChonHoanTien_Click(object sender, EventArgs e)
        {
            KiemTra_checkTuDongDichVuThuPhi(false);
            Tinh_SotienHoan();
        }

        private void btnInBienLai_BienLai_Click(object sender, EventArgs e)
        {
            if (gvBienLai.FocusedRowHandle > -1)
            {
                string idBienlai = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaBienLai));
                string idMatiepNhan = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLai_MaTiepNhan));
                var list = Get_SelectedDetail_List(2);
                var listMaDichVu = GetMaDichVuChecked();
                if (listMaDichVu.Count > 0)
                {
                    var listTemp = new List<CashierItemSelected>();
                    foreach (var item in listMaDichVu)
                    {
                        listTemp.Add(list.Where(x => x.ItemId.Equals(item)).FirstOrDefault());
                    }
                    list = listTemp;
                }
                if (list.Count > 0)
                {
                    InBienLai(idBienlai, idMatiepNhan, list, chkBienLai_BatThuTien.Checked, !chkBienLai_inTrucTiep.Checked, listMaDichVu);
                }
                Load_ChitietBienLai();
            }
        }
        private List<string> GetMaDichVuChecked()
        {
            var lstMaDichVu = new List<string>();
            for (int i = 0; i < gvChiTietBienlai.RowCount; i++)
            {
                if (gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu) != null
                    && NumberConverter.ToBool(gvChiTietBienlai.GetRowCellValue(i, colChiTietnBl_Chon)))
                {
                    lstMaDichVu.Add(gvChiTietBienlai.GetRowCellValue(i, colBienLai_MaDichVu).ToString());
                }
            }
            return lstMaDichVu;
        }
        //private void btnHoanTien_Click(object sender, EventArgs e)
        //{
        //    if (gvBienLai.FocusedRowHandle > -1)
        //    {
        //        EnumThaoTacThuPhi loai = (EnumThaoTacThuPhi)Enum.Parse(typeof(EnumThaoTacThuPhi), gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThaoTac).ToString());
        //        //Đang ở thu tiền mới cho hoàn tiền
        //        if (loai == EnumThaoTacThuPhi.ThuTien)
        //        {
        //            var  idBienlaiThu = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiMaBienLai));
        //            var idMatiepNhan = TPH.Common.Converter.StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLai_MaTiepNhan));

        //            //lấy danh sách dịch vụ hoàn tiền (chỉ dịch vụ thu tiền rồi mới cho hoàn)
        //            var lstDanhSachHoan = Get_SelectedDetail_List(1);
        //            if (lstDanhSachHoan.Count > 0)
        //            {
        //                var sumReturn = lstDanhSachHoan.Sum(x => x.ItemCost * x.ItemCount);
        //                if (CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Thực hiền hoàn tiền các dịch vụ đã chọn ?"))
        //                {
        //                    if (cboThuNganHoantien.SelectedIndex > -1)
        //                    {
        //                        var idBienaiHoan = _isCashier.TaoBienLaiHoanTien(idMatiepNhan, lstDanhSachHoan, Environment.MachineName, cboThuNganHoantien.SelectedValue.ToString()
        //                             , decimal.Parse(sumReturn.ToString()), 0, string.Empty, idBienlaiThu, CommonAppVarsAndFunctions.UserID);
        //                        if (!string.IsNullOrEmpty(idBienaiHoan))
        //                        {
        //                            Load_DanhSach_BienLai();
        //                            bvDanhSachBienLai.BindingSource.Position = bvDanhSachBienLai.BindingSource.Find("ID", idBienaiHoan);
        //                        }
        //                    }
        //                    else
        //                        CustomMessageBox.MSG_Information_OK("Hãy chọn thu ngân hoàn tiền.");
        //                }
        //            }
        //            else
        //            {
        //                CustomMessageBox.MSG_Information_OK("Không có dịch vụ đã thu phí và chưa hoàn tiền được chọn!");
        //            }
        //        }
        //    }
        //}

        private void btnHoanTien_Click(object sender, EventArgs e)
        {
            if (gvBienLai.FocusedRowHandle <= -1) return;
            var loai = (EnumThaoTacThuPhi)Enum.Parse(typeof(EnumThaoTacThuPhi),
                gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiThaoTac).ToString());
            //Đang ở thu tiền mới cho hoàn tiền
            if (loai != EnumThaoTacThuPhi.ThuTien) return;
            var idBienlaiThu =
                StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle,
                    colBienLaiMaBienLai));
            var idMatiepNhan =
                StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle,
                    colBienLai_MaTiepNhan));

            //lấy danh sách dịch vụ hoàn tiền (chỉ dịch vụ thu tiền rồi mới cho hoàn)
            var lstDanhSachHoan = Get_SelectedDetail_List(1);
            var dtDanhSachXNDaDuyet = new DataTable();
            var thongBaoXNDaDuyet = string.Empty;
            //Kiểm tra các mã xn đã duoc duyệt chưa
            if (lstDanhSachHoan.Count > 0)
            {
                //string phân cách maXN với comma
                var lstMaXN = string.Join(",", lstDanhSachHoan.Select(x => x.ItemId).ToList());
                dtDanhSachXNDaDuyet = _isCashier.DanhSachXetNghiemDaDuyet(idMatiepNhan, lstMaXN);
            }

            if (dtDanhSachXNDaDuyet.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDanhSachXNDaDuyet.Rows)
                {
                    bool daCoKQ = NumberConverter.ToBool((dr["DaCoKQ"]));
                    bool xacNhanKQ = NumberConverter.ToBool((dr["XacNhanKQ"]));

                    if (xacNhanKQ)
                        thongBaoXNDaDuyet += string.Format("Xét nghiệm: \"{0}\" đã được duyệt! \n", StringConverter.ToString(dr["TenXN"]));
                    else if (daCoKQ)
                        thongBaoXNDaDuyet += string.Format("Xét nghiệm: \"{0}\" đã có kết quả! \n", StringConverter.ToString(dr["TenXN"]));
                    //lấy các xn đã duyệt ra khỏi list danh sách hoàn
                    lstDanhSachHoan = lstDanhSachHoan.Where(x => x.ItemId != StringConverter.ToString(dr["MaXN"])).ToList();
                }
            }
            if (cboThuNganHoantien.SelectedIndex < 0)
            {
                CustomMessageBox.MSG_Information_OK("Hãy chọn thu ngân hoàn tiền.");
                return;
            }

            if (lstDanhSachHoan.Count > 0)
            {
                var sumReturn = lstDanhSachHoan.Sum(x => x.ItemCost * x.ItemCount);
                if (!CustomMessageBox.MSG_Question_YesNoCancel_GetYes("Thực hiền hoàn tiền các dịch vụ đã chọn ?")
                ) return;
                //if (cboThuNganHoantien.SelectedIndex > -1)
                //{
                var idBieLaiHoan = _isCashier.TaoBienLaiHoanTien(idMatiepNhan, lstDanhSachHoan,
                    Environment.MachineName, cboThuNganHoantien.SelectedValue.ToString()
                    , decimal.Parse(sumReturn.ToString()), 0, string.Empty, idBienlaiThu, CommonAppVarsAndFunctions.UserID);
                if (string.IsNullOrEmpty(idBieLaiHoan)) return;
                Load_DanhSach_BienLai();
                gvBienLai.FocusedRowHandle = gvBienLai.LocateByValue("ID", idBieLaiHoan);
                //}
                //else
                //    CustomMessageBox.MSG_Information_OK("Hãy chọn thu ngân hoàn tiền.");
            }
            else if (string.IsNullOrEmpty(thongBaoXNDaDuyet))
            {
                CustomMessageBox.MSG_Information_OK("Không có dịch vụ đã thu phí và chưa hoàn tiền được chọn!");
            }

            if (!string.IsNullOrEmpty(thongBaoXNDaDuyet))
            {
                CustomMessageBox.MSG_Information_OK(thongBaoXNDaDuyet);
            }
        }

        private void Tinh_SotienHoan()
        {
            //lấy danh sách dịch vụ hoàn tiền (chỉ dịch vụ thu tiền rồi mới cho hoàn)
            var lstDanhSachHoan = Get_SelectedDetail_List(1);
            txtTotalReturnCount.Text = string.Empty;
            if (lstDanhSachHoan.Count > 0)
            {
                var sumReturn = lstDanhSachHoan.Sum(x => x.ItemCost * x.ItemCount);
                txtTotalReturnCount.Text = string.Format("{0:### ### ##0}", sumReturn);
            }
            else
                txtTotalReturnCount.Text = "0";
        }
        #endregion

        private void gvChiTietBienlai_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colChiTietnBl_Chon)
            {
                Tinh_SotienHoan();
            }
        }

        private void chkUpdateChagreAuto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkThuPhi_InTrucTiep_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtCK_TextChanged(object sender, EventArgs e)
        {
            calChuaThu();
        }
        private void calChuaThu()
        {
            if (string.IsNullOrEmpty(txtTongTien.Text)) return;
            if (!WorkingServices.IsNumeric(NumberConverter.ToDecimal(txtCK.Text))) return;
            if (!WorkingServices.IsNumeric(NumberConverter.ToDecimal(txtDaThu.Text))) return;
            if (!string.IsNullOrEmpty(txtCK.Text) || !string.IsNullOrEmpty(txtDaThu.Text))
            {
                decimal chietKhau = 0;
                if (radCK_VND.Checked)
                    chietKhau = NumberConverter.ToDecimal(txtCK.Text);
                else if (radCK_Per.Checked)
                    chietKhau = NumberConverter.ToDecimal(txtTongTien.Text.Replace(" ", "")) * NumberConverter.ToDecimal(txtCK.Text) / 100;
                //if (WorkingServices.IsNumeric(txtCK.Text) && WorkingServices.IsNumeric(txtDaThu.Text))
                //{
                txtChuaThu.Text = string.Format("{0: ### ### ### ##0}", NumberConverter.ToDecimal(txtTongTien.Text.Replace(" ", ""))
                    - NumberConverter.ToDecimal(txtDaThu.Text) - chietKhau).Trim();
                //}
                //else if (WorkingServices.IsNumeric(txtCK.Text))
                //{
                //    txtChuaThu.Text = string.Format("{0: ### ### ### ##0}", double.Parse(txtTongTien.Text.Replace(" ", ""))
                //        - chietKhau).Trim();
                //}
            }
            else
                txtChuaThu.Text = "0";

        }

        private void radCK_VND_CheckedChanged(object sender, EventArgs e)
        {
            calChuaThu();
        }

        private void radCK_Per_CheckedChanged(object sender, EventArgs e)
        {
            calChuaThu();
        }

        private void radFinishCharge_CheckedChanged(object sender, EventArgs e)
        {
            SearchDS_TiepNhan();
        }

        private void radNotCharge_CheckedChanged(object sender, EventArgs e)
        {
            SearchDS_TiepNhan();
        }

        private void radAllCharge_CheckedChanged(object sender, EventArgs e)
        {
            SearchDS_TiepNhan();
        }
        private void SearchDS_TiepNhan()
        {
            if (radAllCharge.Checked)
                bvPatient.BindingSource.Filter = string.Empty;
            else if (radFinishCharge.Checked)
                bvPatient.BindingSource.Filter = "DaThuTien = 1";
            else if (radNotCharge.Checked)
                bvPatient.BindingSource.Filter = "DaThuTien = 0";
        }

        private void txtFindName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFindIDBienLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtFindIDBienLai.Text))
            {
                ClearGridView();
                Load_DanhSach_BienLai(txtFindIDBienLai.Text.Trim());
                if (gvBienLai.RowCount > 0)
                {
                    var ngayTN = TPH.Common.Converter.DateTimeConverter.ToDateTime(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiNgayTiepNhan));
                    var SEQ = StringConverter.ToString(gvBienLai.GetRowCellValue(gvBienLai.FocusedRowHandle, colBienLaiSEQ));
                    dtpDateIn.Value = ngayTN;
                    Load_List_BenhNhan(SEQ);
                    txtFindSEQ.Text = SEQ;
                    Load_DanhSach_BienLai(txtFindIDBienLai.Text.Trim());
                }
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
