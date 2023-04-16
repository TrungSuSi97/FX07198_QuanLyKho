using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.App.AppCode;
using TPH.LIS.App.AppCode.Config;
using TPH.LIS.App.AppCode.Patient;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Patient.Services;
using TPH.LIS.Data;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.VisualBasic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using TPH.LIS.TestResult.Services;
using TPH.LIS.TestResult.Model;

namespace TPH.LIS.App.ThucThi.BenhNhan
{
    public partial class FrmCheckUploadHIS : FrmTemplate
    {
        
        private readonly C_BenhNhan_TiepNhan _data = new C_BenhNhan_TiepNhan();
        private DataTable _dtDanhMucDichVu = new DataTable();
        private DataTable _dtDanhsanhChiDinh = new DataTable();
        private readonly IPatientInformationService _informationService = new PatientInformationService();
        private readonly ITestResultService _xetnghiem = new TestResultService();

        private readonly C_Patient_SieuAm _pSieuam = new C_Patient_SieuAm();
        private readonly C_Patient_XQuang _pXquang = new C_Patient_XQuang();
        private readonly C_Patient_NoiSoi _pNoisoi = new C_Patient_NoiSoi();
        private readonly C_Patient_KhamBenh _pKhambenh = new C_Patient_KhamBenh();
        private readonly C_Patient_DichVu_Khac _pDvkhac = new C_Patient_DichVu_Khac();

        private string _displayMember = string.Empty;
        private string _valueMember = string.Empty;

        string strABO = string.Empty;
        string strRhD = string.Empty;
        List<string> strListNAT = new List<string>();
        public FrmCheckUploadHIS()
        {
            InitializeComponent();
        }
        private void LoadBloodTest()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT kq.stt,kq.RSoPhieuYeuCau,kq.maxn_his,kq.transferresultothis,kq.uploadweb, bt.MaTiepNhan, bt.Seq, bt.MaBN, bt.TenBN, bt.SinhNhat, bt.Tuoi, bt.CoNgaySinh, bt.GioiTinh, bt.NgayTiepNhan, bt.ThoiGianNhap, bt.DichVuXetNghiem, bt.nguonnhap, bt.UserCapNhat, bx.DuKQXN, bx.ValidKQXN, \n");
            sql.Append("bx.DaInKQXN, bx.ThoiGianValidXN, bx.ThoiGianDuKQXN, bx.ThoiGianInXN, bx.UserInXN, bx.LanInXN, bx.ThoiGianHenTraKQ, bx.ThoiGianTraKQ, bx.UserTraKQ, bx.ghichuxn, bx.danhgia, bx.userdanhgia,\n");
            sql.Append("bx.thoigiandanhgia, kq.MaXN, kq.TenXN, kq.KetQua, kg.GhiChu, kq.MaNhomCLS, kq.CSBT, kq.DonVi, kq.NguongTren, kq.NguongDuoi, xn.SapXep, xn.InDam, xn.InDamKQ, xn.KichCoChu, xn.KichCoKQ, xn.CanhLe, \n");
            sql.Append("kq.ThuTuIn, kq.XNChinh, kq.TrangThai, kq.Flat, kq.ProfileID, kq.XacNhanKQ, kq.NguoiXacNhan, kq.DKBatThuong, kq.TGCoKetQua, kq.HeSoXN, kq.ThoiGianNhapKQ, kq.ThoiGianSuaKQ, kq.UserNhapKQ,\n");
            sql.Append("kq.UserSuaKQ, kq.UserNhapCD, kq.IDMayDownload, kq.IDMayXetNghiem, m.tenmay as TenMayXetNghiem, kq.MaXNMay,\n");
            sql.Append("case when kq.IDMayXetNghiem=0 then isnull(UserSuaKQ,kq.UserNhapKQ) else cast(kq.IDMayXetNghiem as varchar) + ': ' + m.tenmay end as maythuchien,n.TenNhomCLS,n.ThuTuIn as ThuTuNhom,d.TenDoiTuongDichVu\n");
            sql.Append("FROM benhnhan_tiepnhan bt WITH (nolock)\n");
            sql.Append("INNER JOIN benhnhan_cls_xetnghiem bx WITH (nolock) ON bt.MaTiepNhan = bx.MaTiepNhan \n");
            sql.Append("INNER JOIN ketqua_cls_xetnghiem kq WITH (nolock) ON bx.MaTiepNhan = kq.MaTiepNhan\n");
            sql.Append("left join {{TPH_Standard}}_Dictionary.dbo.DM_DoiTuongDichVu D WITH (nolock) on d.MaDoiTuongDichVu=bt.DoiTuongDichVu\n");
            sql.Append("left join {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Nhom n WITH (nolock) on n.MaNhomCLS = kq.MaNhomCLS\n");
            sql.Append("left join ketqua_cls_xetnghiem_ghichu kg WITH (nolock) on kg.MaTiepNhan = kq.MaTiepNhan and kg.MaXN = kq.MaXn\n");
            sql.Append("left join {{TPH_Standard}}_Dictionary.dbo.dm_xetnghiem xn WITH (nolock) on xn.MaXN = kq.MaXN\n");
            sql.Append("left join {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem m WITH (nolock) on m.idmay = kq.IDMayXetNghiem\n");
            if (radDateIn.Checked)
                sql.AppendFormat("where bt.NgayTiepNhan='{0:MM/dd/yyyy}'\n", dtpDateIn.Value);
            else
            {
                sql.Append("inner join {{TPH_Standard}}_Sample.dbo.ketqua_cls_xetnghiem_transfer_his h WITH (nolock) on h.MaXN = kq.MaXN and h.matiepnhan = kq.matiepnhan \n");
                sql.AppendFormat("where h.thoigiantransfer between '{0:yyyy-MM-dd 00:00:00}' and '{0:yyyy-MM-dd 23:59:59}'\n", dtpUploadDate.Value);
            }
            //sql.AppendFormat("and nguonnhap='{0}'\n", InputSourceEnum.NHM.ToString());

            if (radHH.Checked)
                sql.AppendFormat("and n.MaBoPhan='HH'");
            else if (radSH.Checked)
                sql.AppendFormat("and n.MaBoPhan='SH'");

            if (!string.IsNullOrEmpty(txtFromBarcode.Text))
                sql.AppendFormat("and bt.Seq='{0}'", txtFromBarcode.Text);

            DataSet ds = DataProvider.ExecuteDataset(CommandType.Text, sql.ToString());
            if (ds.Tables.Count == 0) return;
            DataTable dt = ds.Tables[0];
            gcKetQua.DataSource = dt;
            gvKetQua.ExpandAllGroups();
            
        }
        private void FrmNhapKSK_Load(object sender, EventArgs e)
        {
            LoadBloodTest();
            LoadConfig();
        }

        void LoadConfig()
        {
            DataTable dt = _xetnghiem.GetValueConfig(3);
            if (dt.Rows.Count > 0)
            {
                strABO = dt.Rows[0]["value1"].ToString();
                strRhD = dt.Rows[0]["value2"].ToString();
            }
            string sql = "select maxn from {{TPH_Standard}}_Dictionary.dbo.DM_XetNghiem_Profile_ChiTiet where profileid in (select value1 from {{TPH_Standard}}_System.dbo.config where idconfig=9)";
            DataTable dt2 = DataProvider.ExecuteDataset(CommandType.Text, sql).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow r in dt2.Rows)
                {
                    strListNAT.Add(string.Format("{0}", r[0]));
                }
            }
        }
        private void txtFromBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadBloodTest();
            }
        }

        private void txtFromBarcode_Enter(object sender, EventArgs e)
        {
            txtFromBarcode.SelectAll();
        }

        private void txtFromBarcode_Click(object sender, EventArgs e)
        {
            txtFromBarcode.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void gcKetQua_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gcKetQua.FocusedView as ColumnView).FocusedRowHandle++;
                (gcKetQua.FocusedView as ColumnView).ShowEditor();
                e.Handled = true;
            }
        }

        private void gvKetQua_ShowingEditor(object sender, CancelEventArgs e)
        {
            int RowHandle = (gcKetQua.FocusedView as ColumnView).FocusedRowHandle;

            if (gvKetQua.Columns["KetQua"].FieldName.Equals("KetQua", StringComparison.OrdinalIgnoreCase))
            {
                if (gvKetQua.GetRowCellValue(RowHandle, colXacNhanKQ) != null)
                {
                    var userNhap = gvKetQua.GetRowCellValue(RowHandle, colmaythuchien).ToString();
                    if ((bool)gvKetQua.GetRowCellValue(RowHandle, colXacNhanKQ))
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
        }

        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radAmTinh_Click(object sender, EventArgs e)
        {

        }

        private void radAmTinh_CheckedChanged(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radDuongTinh_CheckedChanged(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radChuaXacDinh_CheckedChanged(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            LoadBloodTest();
        }
        private void ValidResult(bool valid)
        {
            var haveUpdate = false;
            string maTiepNhan = "";
            string maXn = "";
            if (gvKetQua.RowCount == 0) return;

            if (
                CustomMessageBox.MSG_Question_YesNo_GetYes((valid ? "Xác nhận " : "Hủy xác nhận ") +
                                                           "các kết quả được chọn?"))
            {
                string validText = (valid
                    ? Common.CommonConstant.IsValided
                    : Common.CommonConstant.InValid);
                List<string> lisMatiepNhan = new List<string>();
                string matiepnhantemp = "";
                foreach (int i in gvKetQua.GetSelectedRows())
                {
                    if (gvKetQua.GetRowCellValue(i, colXacNhanKQ) != null)
                    {
                        if ((bool)gvKetQua.GetRowCellValue(i, colXacNhanKQ) != valid)
                        {
                            if (!string.IsNullOrEmpty(gvKetQua.GetRowCellValue(i, colKetQua) != null ? gvKetQua.GetRowCellValue(i, colKetQua).ToString() : string.Empty))
                            {
                                maXn = gvKetQua.GetRowCellValue(i, colMaXN).ToString().Trim();
                                maTiepNhan = gvKetQua.GetRowCellValue(i, colMaTiepNhan).ToString().Trim();
                                _xetnghiem.XacNhan_KQ_XN(maTiepNhan, maXn, validText,
                                    valid, CommonAppVarsAndFunctions.UserID, CommonAppVarsAndFunctions.sysConfig.ClsXetNghiemXacNhanDe, (int)CommonAppVarsAndFunctions.sysConfig.LayNguoiThucHien);
                                gvKetQua.SetRowCellValue(i, colTrangThai, validText);
                                gvKetQua.SetRowCellValue(i, colXacNhanKQ, valid);
                                

                                if (matiepnhantemp != maTiepNhan)
                                {
                                    matiepnhantemp = maTiepNhan;

                                    lisMatiepNhan.Add(matiepnhantemp);
                                }
                                haveUpdate = true;
                            }
                        }
                    }
                }

                if (haveUpdate)
                {

                    foreach (var matiepnhan in lisMatiepNhan)
                    {
                        if (valid)
                        {
                            //Insert NAT Infinity
                            _xetnghiem.InsertNATToInfinity(matiepnhan, dtpDateIn.Value);
                        }
                        //Cập nhật đủ kết quả
                        _xetnghiem.CapNhat_DuKQ_XN(matiepnhan);
                        //Đánh giá
                        _xetnghiem.CapNhat_Valid_XN(matiepnhan, CommonAppVarsAndFunctions.UserID);
                    }
                    LoadBloodTest();
                }
            }
        }
        private void UpdateResult(int rowIndex, bool caNhatKq)
        {
            if (gvKetQua.RowCount == 0)
                return;
            var log = string.Empty;
            try
            {
                log = "Lấy các giá trị";
                log += Environment.NewLine + "     _indexKQ";
                //var indexKq = 3;
                log += Environment.NewLine + "     _KetQua";
                var ketQua = gvKetQua.GetRowCellValue(rowIndex, colKetQua) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colKetQua).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _MaXN";
                var maXn = gvKetQua.GetRowCellValue(rowIndex, colMaXN) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colMaXN).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _GhiChu";
                var ghiChu = gvKetQua.GetRowCellValue(rowIndex, colGhiChu) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colGhiChu).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _NguongTren";
                var nguongTren = gvKetQua.GetRowCellValue(rowIndex, colNguongTren) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colNguongTren).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _NguongDuoi";
                var nguongDuoi = gvKetQua.GetRowCellValue(rowIndex, colNguongDuoi) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colNguongDuoi).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _DieuKienBatThuong";
                var dieuKienBatThuong = gvKetQua.GetRowCellValue(rowIndex, colDKBatThuong) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colDKBatThuong).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _Co";
                var flag = gvKetQua.GetRowCellValue(rowIndex, colFlat) != null
                    ? int.Parse(gvKetQua.GetRowCellValue(rowIndex, colFlat).ToString())
                    : 0;
                log += Environment.NewLine + "     _UserNhap";
                var userNhap = gvKetQua.GetRowCellValue(rowIndex, colmaythuchien) != null
                    ? gvKetQua.GetRowCellValue(rowIndex, colmaythuchien).ToString().Trim()
                    : string.Empty;
                log += Environment.NewLine + "     _XNChinh";
                var xnChinh = gvKetQua.GetRowCellValue(rowIndex, colXNChinh) != null
                    ? (bool)gvKetQua.GetRowCellValue(rowIndex, colXNChinh)
                    : false;

                log += Environment.NewLine + "Thực hiện kiểm tra đánh giá khi nhập hoặc sửa kết quả";
                log += Environment.NewLine + "Đánh giá kết quả";
                var maTiepNhan = gvKetQua.GetRowCellValue(rowIndex, colMaTiepNhan).ToString();
                flag = SetColor(ketQua, nguongTren, nguongDuoi, dieuKienBatThuong);
                var obUpdate = new UpdateResultNormalInfo
                {
                    maTiepNhan = maTiepNhan,
                    maXN = maXn,
                    ketQua = ketQua,
                    capNhatghiChu = false,
                    ghiChu = ghiChu,
                    co = flag.ToString(),
                    userNhap = CommonAppVarsAndFunctions.UserID,
                    suaKQ = (!string.IsNullOrWhiteSpace(userNhap)),
                    round = "",
                    userUpdate = CommonAppVarsAndFunctions.UserID
                };
                _xetnghiem.CapNhat_KQ_XN(obUpdate);

                gvKetQua.SetRowCellValue(rowIndex, colFlat, flag);

                _xetnghiem.CapNhat_DuKQ_XN(maTiepNhan);
                if (string.IsNullOrEmpty(userNhap))
                {
                    gvKetQua.SetRowCellValue(rowIndex, colmaythuchien, CommonAppVarsAndFunctions.UserID);
                }
            }
            catch (Exception ex)
            {
                LabServices_Helper.RecordError(log);
                ErrorService.GetFrameworkErrorMessage(ex, "CapNhatKQ_KiemTraHienthi", CommonAppVarsAndFunctions.UserID);
            }
        }
        private int SetColor(string strResult, string high, string low, string criteria)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            if (!LabServices_Helper.IsNumeric(strResult))
            {
                if (strResult.Contains(">") && !string.IsNullOrWhiteSpace(Strings.RTrim(high)))
                {
                    return 3;
                }
                else if (strResult.Contains("<") && !string.IsNullOrWhiteSpace(Strings.RTrim(low)))
                {
                    return 2;
                }
                else if (Compare_Criteria(criteria, strResult, '|') == 1)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                var dLow = string.IsNullOrWhiteSpace(low) ? -1000000000 : (double.Parse(low));
                var dHigh = string.IsNullOrWhiteSpace(high) ? 1000000000 : (double.Parse(high));
                var dResult = double.Parse(strResult);

                if (dResult < dLow)
                {
                    return 2;
                }
                else if (dResult > dHigh)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
        }

        /// <summary>
        /// So sánh chuỗi cho trường hợp đặt nhiều điều kiện
        /// </summary>
        /// <param name="orgrial">Chuỗi điều kiện</param>
        /// <param name="beingCompare">Chuỗi muốn so sánh</param>
        /// <param name="splitChar">Ký tự cắt trong chuỗi điều kiện</param>
        /// <returns>0: Không tìm thấy chuỗi khớp - 1: Tìm thấy chuỗi khớp</returns>
        public int Compare_Criteria(string orgrial, string beingCompare, char splitChar)
        {
            if (orgrial.Length > 0)
            {
                var arrayOrignal = orgrial.Split(splitChar);
                if (arrayOrignal.Length > 0)
                {
                    for (var i = 0; i < arrayOrignal.Length; i++)
                    {
                        if (arrayOrignal[i].Trim().Equals(beingCompare.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            return 1;
                        }
                    }

                    //trường hợp hết vòng lập mà có trong điều kiện so sánh thì kiểm tra truờng hợp định tính có ghép định lượng
                    for (var a = 0; a < arrayOrignal.Length; a++)
                    {
                        if (beingCompare.ToLower().Contains(arrayOrignal[a].Trim().ToLower()))
                        {
                            return 1;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

            return 0;
        }
        private void btnValid_Click(object sender, EventArgs e)
        {
            ValidResult(true);
        }

        private void btnInvalid_Click(object sender, EventArgs e)
        {
            ValidResult(false);
        }
        bool AddAllResult = false;
        private void gvKetQua_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName.Equals("KetQua")
            //{
            //    string newValue = (e.Value == null ? string.Empty : e.Value.ToString());

            //    if (AddAllResult)
            //    {
            //        UpdateResult(e.RowHandle, true);
            //        AddAllResult = false;
            //    }
            //    else
            //    {
            //        if (!newValue.Equals(_currentValue))
            //        {
            //            UpdateResult(e.RowHandle, true);
            //        }
            //    }
            //}
        }
        string _currentValue = "";
        private void gvKetQua_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (gvKetQua.RowCount == 0)
            {
                _currentValue = string.Empty;
                return;
            }
            _currentValue = gvKetQua.GetRowCellValue(e.RowHandle, colKetQua) != null ? gvKetQua.GetRowCellValue(e.RowHandle, colKetQua).ToString() : "";
        }
        private Color _MauKQ(int co, ref FontStyle fstyle)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            switch (co)
            {
                case 2:
                    fstyle = FontStyle.Bold;
                    return Color.Blue;

                case 3:
                    fstyle = FontStyle.Bold;
                    return Color.Red;

                default:
                    fstyle = FontStyle.Regular;
                    return Color.Black;
            }
        }
        private void gvKetQua_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //txtTongSoTuiMau.Text = "";
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (e.Column.FieldName.Equals("TenXN", StringComparison.OrdinalIgnoreCase))
                {
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["XNChinh"]) != null)
                    {
                        bool value = (bool)view.GetRowCellValue(e.RowHandle, view.Columns["XNChinh"]);
                        if (value)
                        {
                            e.Appearance.Font = new Font("Arial", 9, FontStyle.Bold);
                        }
                    }
                }
                if (e.Column.FieldName.Equals("KetQua", StringComparison.OrdinalIgnoreCase))
                {
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Flat"]) != null)
                    {
                        int flag = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Flat"]);
                        FontStyle fs = new FontStyle();
                        var color = _MauKQ(flag, ref fs);
                        Font font = new Font("Arial", 10, fs);
                        e.Appearance.Font = font;
                        e.Appearance.ForeColor = color;

                        string kq = view.GetRowCellValue(e.RowHandle, view.Columns["KetQua"]).ToString();
                        if (LabServices_Helper.IsNumeric(kq))
                        {
                            e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                        }

                        if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns["XacNhanKQ"]))
                        {
                            //e.Column.OptionsColumn.ReadOnly = true;
                            //e.Column.OptionsColumn.AllowEdit = false;
                            //e.Appearance.
                            e.Appearance.BackColor = Color.LightGray;
                        }
                        else
                        {
                            //e.Column.OptionsColumn.ReadOnly = false;
                            //e.Column.OptionsColumn.AllowEdit = true;
                            //e.Appearance.BackColor;
                        }

                    }
                }
                //DataTable dt = ((DataTable)gcKetQua.DataSource).DefaultView.ToTable(true, "MaTiepNhan");
                //txtTongSoTuiMau.Text = dt.Rows.Count.ToString();
            }
        }

        private void txtFromBarcode_Click_1(object sender, EventArgs e)
        {
            txtFromBarcode.SelectAll();
        }

        private void gcKetQua_DataSourceChanged(object sender, EventArgs e)
        {
            //txtTongSoTuiMau.Text = "";
            //DataTable dt = ((DataTable)gcKetQua.DataSource).DefaultView.ToTable(true, "MaTiepNhan");
            //txtTongSoTuiMau.Text = dt.Rows.Count.ToString();
        }

        private void gcKetQua_DefaultViewChanged(object sender, EventArgs e)
        {
            //txtTongSoTuiMau.Text = "";
            //DataTable dt = ((DataTable)gcKetQua.DataSource).DefaultView.ToTable(true, "MaTiepNhan");
            //txtTongSoTuiMau.Text = dt.Rows.Count.ToString();
        }

        private void gvKetQua_DataSourceChanged(object sender, EventArgs e)
        {
            txtTongSoTuiMau.Text = "";
            DataTable dt = ((DataTable)gcKetQua.DataSource).DefaultView.ToTable(true, "MaTiepNhan");
            txtTongSoTuiMau.Text = dt.Rows.Count.ToString();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (gvKetQua.RowCount > 0)
            {
               Excel.ExportToExcel.Export(gvKetQua, "Result");
            }
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radHH_Click(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radSH_Click(object sender, EventArgs e)
        {
            LoadBloodTest();
        }

        private void radDateIn_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateIn.Enabled = radDateIn.Checked;
        }

        private void radUploadDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpUploadDate.Enabled = radUploadDate.Checked;
        }
    }
}
