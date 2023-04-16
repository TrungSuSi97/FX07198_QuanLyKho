using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Common.Controls;
using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Extensions;
using DevExpress.Office.Utils;

namespace TPH.LIS.Configuration.Controls
{
    public partial class ucDanhMucGioiHanThamChieu : UserControl
    {
        public ucDanhMucGioiHanThamChieu()
        {
            InitializeComponent();
        }
        private readonly ISystemConfigService _systemConfigService = new SystemConfigService();
        private IWorkingLogService _logService = new WorkingLogService();
        public bool isAdmin = false;
        public string[] arrPhanQuyenNhom = new string[0];
        public string UserId = string.Empty;
        bool isCreatedGrid = false;
        public event EventHandler BuutonThemMoiClick;
        public event EventHandler BuutonXoaClick;
        public event EventHandler LuoiChinhSua;
        public DataTable CurrentDataSource;
        private string prefixColumnName = "coldmcsbt_";
        public void Load_Config(DataTable dataDMXN)
        {
            if (!isCreatedGrid)
            {
                ControlExtension.CreateGridColumnWithObject(new DM_XETNGHIEM_CSBT(), gvDanhSach, prefixColumnName, true, true, true, true, true, true
                    , new string[] { ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Nguoinhap)
                    , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Tgnhap) });
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)].Width = 50;
                gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbt)].Width = 250;
                var gridCol1 = gvDanhSach.Columns[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbt)];
                var cbo2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                gridCol1.ColumnEdit = cbo2;
                ucDanhSachXetNghiem1.arrPhanQuyenNhom = arrPhanQuyenNhom;
                ucDanhSachXetNghiem1.isAdmin = isAdmin;
                ucDanhSachXetNghiem1.AutoExpandAll = true;
                radXemTatCa.CheckedChanged += radKieuXem_CheckedChanged;
                radXemTheoXetNghiem.CheckedChanged += radKieuXem_CheckedChanged;
                ucDanhSachXetNghiem1.LuoiCellFocusChanged += ucDanhSachXetNghiem1_LuoiCellFocusChanged;
                isCreatedGrid = true;
            }
            Load_DanhMucXetNghiem(dataDMXN);
            Load_DanhMucCauHinh();
        }

        private void LoadDanhSachMayXetNghiem()
        {
            var data = _systemConfigService.Data_DanhSachMayXetNghiem();
            cboDenMayXetNghiem.DataSource = data;
            cboTumayXetNghiem.DataSource = data.Copy();
            cboTumayXetNghiem.ValueMember = cboDenMayXetNghiem.ValueMember = "IdMay";
            cboTumayXetNghiem.DisplayMember = cboDenMayXetNghiem.DisplayMember = "IdMay";
            cboTumayXetNghiem.ColumnNames = cboDenMayXetNghiem.ColumnNames = "IdMay;TenMay";
            cboTumayXetNghiem.ColumnWidths = cboDenMayXetNghiem.ColumnWidths = "35;150";
            cboDenMayXetNghiem.SelectedIndex = -1;
            cboTumayXetNghiem.SelectedIndex = -1;
        }
        public void Load_DanhMucXetNghiem(DataTable data)
        {
            ucDanhSachXetNghiem1.Load_DanhSach(data);
        }
        private void SetMauTrungData(DataTable dataSource = null, string maXN = "")
        {
            if (gvDanhSach.DataSource != null || dataSource != null)
            {
                if (gvDanhSach.DataSource != null && dataSource == null)
                    dataSource = (DataTable)gcDanhSach.DataSource;
                List<Color> lstColorAdd = new List<Color>();
                if(gvDanhSach.RowCount > 0)
                {
                    for (int r = 0; r < gvDanhSach.RowCount; r++)
                    {
                        if (gvDanhSach.GetRowCellValue(r, colMauTrungKhaiBao) != null)
                        {
                            if(!string.IsNullOrEmpty(gvDanhSach.GetRowCellValue(r, colMauTrungKhaiBao).ToString()))
                            {
                                var color = ColorTranslator.FromHtml(gvDanhSach.GetRowCellValue(r, colMauTrungKhaiBao).ToString());
                                if(!lstColorAdd.Where( x => x.Equals(color)).Any())
                                {
                                    lstColorAdd.Add(color); 
                                }
                            }
                        }
                    }
                }
  
                if (!dataSource.Columns.Contains("mautrungkhaibao"))
                    dataSource.Columns.Add("mautrungkhaibao", typeof(string));
                var dataFinal = dataSource.Clone();
                var distinctMaXn = dataSource.DefaultView.ToTable(true, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn));
                if (!string.IsNullOrEmpty(maXN))
                    distinctMaXn = WorkingServices.SearchResult_OnDatatable(distinctMaXn, string.Format("{0}='{1}'", ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn), maXN));

                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(200, 255), rnd.Next(150, 255), rnd.Next(150, 255));
          
                foreach (DataRow dataRow in distinctMaXn.Rows)
                {
                    var maxnCheck = dataRow[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)].ToString();
                    var dataFind = WorkingServices.SearchResult_OnDatatable(dataSource, string.Format("{0}='{1}'", ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)
                        , maxnCheck));
                    if(dataFind.Rows.Count > 0)
                    {
                        if (dataFind.Columns.Contains("mautrungkhaibao"))
                            dataFind.Columns.Remove("mautrungkhaibao");
                        dataFind.Columns.Add("mautrungkhaibao", typeof(string));

                        //reset mau hiện tại trên lưới
                        if(gcDanhSach.DataSource != null)
                        {
                            foreach (DataRow dataF in dataFind.Rows)
                            {
                                var autoId = int.Parse(dataF[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)].ToString());
                                var findId= gvDanhSach.LocateByValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid), autoId);
                                if (gvDanhSach.GetRowCellValue(findId, colMauTrungKhaiBao) != null)
                                {
                                    if (!string.IsNullOrEmpty(gvDanhSach.GetRowCellValue(findId, colMauTrungKhaiBao).ToString()))
                                    {
                                        var color = ColorTranslator.FromHtml(gvDanhSach.GetRowCellValue(findId, colMauTrungKhaiBao).ToString());
                                        if (lstColorAdd.Where(x => x.Equals(color)).Any())
                                        {
                                            lstColorAdd.Remove(color);
                                        }
                                    }
                                }
                                gvDanhSach.SetRowCellValue(findId, "mautrungkhaibao", ColorTranslator.ToHtml(Color.Empty));
                            }
                        
                        }
                        for (int i = 0; i < dataFind.Rows.Count; i++)
                        {
                            var listAutoIdChecked = new List<int>();
                            var drA = dataFind.Rows[i];
                            var autoIdA = int.Parse(drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)].ToString());
                            var findIdA = gvDanhSach.LocateByValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid), autoIdA);
                            randomColor = GetColor(Color.FromArgb(rnd.Next(200, 255), rnd.Next(150, 255), rnd.Next(150, 255)), lstColorAdd);
                            if (i + 1 < dataFind.Rows.Count)
                            {
                                for (int y = i + 1; y < dataFind.Rows.Count; y++)
                                {
                                    var drB = dataFind.Rows[y];
                                    var autoIdB = int.Parse(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)].ToString());
                                    if (!listAutoIdChecked.Where(x => x.Equals(autoIdB)).Any())
                                    {
                                        if (string.IsNullOrEmpty(drB["mautrungkhaibao"].ToString()))
                                        {
                                            if (drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)].ToString()))
                                            {
                                                if (drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Idmayxn)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Idmayxn)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Gioitinh)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Gioitinh)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Loaituoi)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Loaituoi)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Tutuoi)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Tutuoi)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Dentuoi)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Dentuoi)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbtcannang)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbtcannang)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbttucannang)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbttucannang)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbtdencannang)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbtdencannang)].ToString())
                                                    && drA[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Masinhly)].ToString().Equals(drB[ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Masinhly)].ToString())
                                                    )
                                                {
                                                    drA["mautrungkhaibao"] = ColorTranslator.ToHtml(randomColor);
                                                    drB["mautrungkhaibao"] = ColorTranslator.ToHtml(randomColor);
                                                    if (gcDanhSach.DataSource != null)
                                                    {
                                                        gvDanhSach.SetRowCellValue(findIdA, "mautrungkhaibao", ColorTranslator.ToHtml(randomColor));
                                                        var findIdB = gvDanhSach.LocateByValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid), autoIdB);
                                                        gvDanhSach.SetRowCellValue(findIdB, "mautrungkhaibao", ColorTranslator.ToHtml(randomColor));
                                                    }
                                                    listAutoIdChecked.Add(autoIdB);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        dataFinal.Merge(dataFind);
                    }
                }
                dataFinal.AcceptChanges();

                dataSource = SortDataTable(dataFinal);
                CurrentDataSource = dataSource;
                if (gcDanhSach.DataSource == null)
                {
                    gcDanhSach.DataSource = dataSource;
                }
            }
        }
        private Color GetColor(Color cl, List<Color> lst)
        {
            if (lst.Where( x=> x.Equals(cl)).Any())
            {
                Random rnd = new Random();
                Color randomColor = Color.FromArgb(rnd.Next(200, 255), rnd.Next(150, 255), rnd.Next(150, 255));
                return GetColor(randomColor, lst);
            }
            lst.Add(cl);
            return cl;
        }
        private DataTable SortDataTable(DataTable dataIn)
        {
            dataIn.DefaultView.Sort = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9} ASC"
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Idmayxn)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Gioitinh)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Loaituoi)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Tutuoi)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Dentuoi)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbtcannang)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbttucannang)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Csbtdencannang)
                  , ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Masinhly));
            return dataIn.DefaultView.ToTable();
        }
       
        private void Load_DanhMucCauHinh()
        {
            var dataSource = new DataTable();
            gcDanhSach.DataSource = null;
            //Kiển tra load xét nghiệm theo đúng nhóm quyền được cấp.
            //Dựa vào xét nghiệm danh mục
            if (ucDanhSachXetNghiem1.CurrentDataSource != null)
            {
                var dataCheck = ucDanhSachXetNghiem1.CurrentDataSource;
                dataSource = _systemConfigService.Data_dm_xetnghiem_csbt(null, (radXemTatCa.Checked ? string.Empty : (string.IsNullOrEmpty(ucDanhSachXetNghiem1.MaXnDangChon) ? "--NONE---" : ucDanhSachXetNghiem1.MaXnDangChon)));
                dataSource.Columns.Add("IdDuplicate", typeof(int));
                CurrentDataSource = null;
                if (dataSource != null)
                {
                   
                    if (dataSource.Rows.Count > 0 && !isAdmin)
                    {
                        for (int i = 0; i < dataSource.Rows.Count; i++)
                        {
                            var checkXN = dataSource.Rows[i]["MaXN"].ToString();
                            var dtSearch = WorkingServices.SearchResult_OnDatatable(dataCheck, string.Format("MaXN = '{0}'", checkXN));
                            if (dtSearch.Rows.Count == 0)
                            {
                                dataSource.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                    CurrentDataSource = dataSource.Copy();
                    dataSource = WorkingServices.ConvertColumnNameToLower_Upper(dataSource, true);
                }
            }
            SetMauTrungData(dataSource);
           // gcDanhSach.DataSource = dataSource;
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucDanhSachXetNghiem1.MaXnDangChon))
            {
                var objNew = new DM_XETNGHIEM_CSBT();
                objNew.Maxn = ucDanhSachXetNghiem1.MaXnDangChon;
                objNew.Nguoinhap = UserId;
                _systemConfigService.Insert_dm_xetnghiem_csbt(objNew);
                Load_DanhMucCauHinh();
                gvDanhSach.FocusedRowHandle = gvDanhSach.RowCount - 1;
                //bubble the event up to the parent
                this.BuutonThemMoiClick?.Invoke(this, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.SelectedRowsCount > -1)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa các cài đặt giới hạn tham chiếu đang chọn?"))
                {
                    foreach (var item in gvDanhSach.GetSelectedRows())
                    {
                        var id = int.Parse(gvDanhSach.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)).ToString());
                        var maxn = gvDanhSach.GetRowCellValue(item, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)).ToString();
                        var obj = _systemConfigService.Get_Info_dm_xetnghiem_csbt(id);
                        if (_systemConfigService.Delete_dm_xetnghiem_csbt(id) > 0)
                        {
                            _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                            {
                                Idhanhdong = (int)Log.LogActionId.Delete,
                                Madanhmuc = string.Format("Id_{0}_MaXN_{1}", id.ToString(), maxn),
                                Nguoithuchien = UserId,
                                Noidung = string.Format("Xóa CSBT: {0}", WorkingServices.GetDelete_Containt(obj)),
                                Idnhatky = Log.LogTableIds.Dm_xetnghiem_csbt,
                                Pcthuchien = Environment.MachineName
                            });
                        }
                    }
                    Load_DanhMucCauHinh();
                    this.BuutonXoaClick?.Invoke(this, new EventArgs());
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Load_DanhMucCauHinh();
        }

        private void gvDanhSach_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colMauTrungKhaiBao)
            {
                var id = int.Parse(gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)).ToString());
                var maxn = gvDanhSach.GetRowCellValue(e.RowHandle, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Maxn)).ToString();
                var obj = _systemConfigService.Get_Info_dm_xetnghiem_csbt(id);
                var objSource = obj.Copy();
                DataRow row = gvDanhSach.GetDataRow(e.RowHandle);
                obj.Tgnhap = objSource.Tgnhap;
                obj = (DM_XETNGHIEM_CSBT)WorkingServices.Get_InfoForObject(obj, row);
                _logService.Insert_HeThong_NhatKyDanhMuc(new Log.Model.HETHONG_NHATKYDANHMUC()
                {
                    Idhanhdong = (int)Log.LogActionId.Update,
                    Madanhmuc = string.Format("Id_{0}_MaXN_{1}", id.ToString(), maxn),
                    Nguoithuchien = UserId,
                    Noidung = WorkingServices.GetUpdate_Differences(obj, objSource),
                    Idnhatky = Log.LogTableIds.Dm_xetnghiem_csbt,
                    Pcthuchien = Environment.MachineName
                });
                _systemConfigService.Update_dm_xetnghiem_csbt(obj);
                //if (chkdanhdautrungKhiSua.Checked)
                //{
                SetMauTrungData(null, maxn);
                //    var findId = gvDanhSach.LocateByValue(ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid), id);
                //    gvDanhSach.FocusedRowHandle = findId;
                //    gvDanhSach.FocusedColumn = e.Column;
                //}
                //bubble the event up to the parent
                this.LuoiChinhSua?.Invoke(this, new EventArgs());
            }
        }
        private void radKieuXem_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                Load_DanhMucCauHinh();
        }
        private void ucDanhSachXetNghiem1_LuoiCellFocusChanged(object sender, EventArgs e)
        {
            Load_DanhMucCauHinh();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            pnCopy.Visible = true;
            LoadDanhSachMayXetNghiem();
        }

        private void btnDongCopy_Click(object sender, EventArgs e)
        {
            pnCopy.Visible = false;
        }

        private void btnThucHienCopy_Click(object sender, EventArgs e)
        {
            if (cboTumayXetNghiem.SelectedIndex > -1)
            {
                if (cboDenMayXetNghiem.SelectedIndex > -1)
                {
                    List<DM_XETNGHIEM_CSBT> lstCurrentConfig = new List<DM_XETNGHIEM_CSBT>();
                    foreach (DataRow dr in CurrentDataSource.Rows)
                    {
                        lstCurrentConfig.Add((DM_XETNGHIEM_CSBT)WorkingServices.Get_InfoForObject(new DM_XETNGHIEM_CSBT(), dr));
                    }
                    var idCu = int.Parse(cboTumayXetNghiem.SelectedValue.ToString());
                    var idMoi = int.Parse(cboDenMayXetNghiem.SelectedValue.ToString());
                    if (gvDanhSach.SelectedRowsCount > 0)
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Sao chép các cài đặt đang chọn từ máy {0} đến máy {1}?", idCu, idMoi)))
                        {
                            foreach (var idex in gvDanhSach.GetSelectedRows())
                            {
                                if (idex > -1)
                                {
                                    var mayXn = gvDanhSach.GetRowCellValue(idex, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Idmayxn)).ToString();
                                    var idMayXn = int.Parse(string.IsNullOrEmpty(mayXn) ? "0" : mayXn);
                                    if (idCu.Equals(idMayXn))
                                    {
                                        var id = int.Parse(gvDanhSach.GetRowCellValue(idex, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)).ToString());
                                        var objSource = _systemConfigService.Get_Info_dm_xetnghiem_csbt(id);

                                        if (!lstCurrentConfig.Where(x => x.Masinhly == objSource.Masinhly && x.Loaituoi == objSource.Loaituoi && x.Tutuoi == objSource.Tutuoi
                                        && x.Maxn == objSource.Maxn && x.Idmayxn == idMoi && x.Gioitinh == objSource.Gioitinh && x.Csbttucannang == objSource.Csbttucannang && x.Csbtdencannang == objSource.Csbtdencannang).Any())
                                        {
                                            objSource.Idmayxn = idMoi;
                                            objSource.Nguoinhap = UserId;
                                            _systemConfigService.Insert_dm_xetnghiem_csbt(objSource);
                                       
                                        }
                                        else
                                        {
                                            var mess = string.Format("Cấu hình Mã XN: {0} - Id máy: {1} - Loại tuổi: {2} - Từ tuổi: {3} - Đến tuổi: {4} {8}- Từ cân nặng: {5} - Đến cân nặng: {6} - Sinh lý: {7}{8}Đã tồn tại."
                                                , objSource.Maxn, objSource.Idmayxn, objSource.Loaituoi, objSource.Tutuoi, objSource.Dentuoi, objSource.Csbtcannang, objSource.Csbtdencannang, objSource.Masinhly, Environment.NewLine);
                                            CustomMessageBox.MSG_Information_OK(mess);
                                        }
                                    }
                                }
                            }
                            Load_DanhMucCauHinh();
                        }
                    }
                    else
                    {
                        if (gvDanhSach.RowCount > 0)
                        {
                            if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Sao chép tất cả cài đặt từ máy {0} đến máy {1}?", idCu, idMoi)))
                            {
                                for (int i = 0; i < gvDanhSach.RowCount; i++)
                                {
                                    var mayXn = gvDanhSach.GetRowCellValue(i, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Idmayxn)).ToString();
                                    var idMayXn = int.Parse(string.IsNullOrEmpty(mayXn) ? "0" : mayXn);
                                    if (idCu.Equals(idMayXn))
                                    {
                                        var id = int.Parse(gvDanhSach.GetRowCellValue(i, ControlExtension.PropertyNameToLowerCase<DM_XETNGHIEM_CSBT>(x => x.Autoid)).ToString());
                                        var objSource = _systemConfigService.Get_Info_dm_xetnghiem_csbt(id);
                                        if (!lstCurrentConfig.Where(x => x.Masinhly == objSource.Masinhly && x.Loaituoi == objSource.Loaituoi && x.Tutuoi == objSource.Tutuoi
                                        && x.Maxn == objSource.Maxn && x.Idmayxn == idMoi && x.Gioitinh == objSource.Gioitinh && x.Csbttucannang == objSource.Csbttucannang && x.Csbtdencannang == objSource.Csbtdencannang).Any())
                                        {
                                            objSource.Idmayxn = idMoi;
                                            objSource.Nguoinhap = UserId;
                                            _systemConfigService.Insert_dm_xetnghiem_csbt(objSource);
                                        }
                                        else
                                        {
                                            var mess = string.Format("Cấu hình Mã XN: {0} - Id máy: {1} - Loại tuổi: {2} - Từ tuổi: {3} - Đến tuổi: {4} {8}- Từ cân nặng: {5} - Đến cân nặng: {6} - Sinh lý: {7}{8}Đã tồn tại."
                                                , objSource.Maxn, objSource.Idmayxn, objSource.Loaituoi, objSource.Tutuoi, objSource.Dentuoi, objSource.Csbtcannang, objSource.Csbtdencannang, objSource.Masinhly, Environment.NewLine);
                                            CustomMessageBox.MSG_Information_OK(mess);
                                        }
                                    }
                                }
                                Load_DanhMucCauHinh();
                            }
                        }
                    }
                    pnCopy.Visible = false;
                }
                else
                    CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm đích.");
            }
            else
                CustomMessageBox.MSG_Information_OK("Hãy chọn máy xét nghiệm nguồn.");

        }

        private void radTheoMay_CheckedChanged(object sender, EventArgs e)
        {
            pnTumayXN.Visible = radTheoMay.Checked;
        }

        private void gvDanhSach_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            string rowValue = view.GetRowCellDisplayText(e.RowHandle, colMauTrungKhaiBao);
            if (!string.IsNullOrEmpty(rowValue))
            {
                e.Appearance.BackColor = ColorTranslator.FromHtml(rowValue);
                e.HighPriority = true;
            }
        }

        private void btnXuatExcelDanhMuc_Click(object sender, EventArgs e)
        {
            TPH.Excel.ExportToExcel.Export(gvDanhSach);
        }

        private void btnTimKhaiBaotrung_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                bool have = false;
                for (int r = 0; r < gvDanhSach.RowCount; r++)
                {
                    if (gvDanhSach.GetRowCellValue(r, colMauTrungKhaiBao) != null)
                    {
                        if (!string.IsNullOrEmpty(gvDanhSach.GetRowCellValue(r, colMauTrungKhaiBao).ToString()))
                        {
                            have = true;
                            gvDanhSach.FocusedRowHandle = r;
                            break;
                        }
                    }
                }
                if (!have)
                    CustomMessageBox.MSG_Information_OK("Không tìm thấy thông tin khai báo trùng.");
            }
        }
    }
}
