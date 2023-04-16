using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Repository;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.LIS.Analyzer.Services;
using DevExpress.XtraGrid.Views.Base;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;

namespace TPH.LIS.Analyzer.Controls
{
    public partial class ucMappingViKhuan : UserControl
    {
        public ucMappingViKhuan()
        {
            InitializeComponent();
        }
        public string[] arrAnalyzerAllow = new string[] { };
        private readonly IBacteriumAntibioticService _bacteriumAntibioticService = new BacteriumAntibioticService();
        private readonly IAnalyzerConfigService _iAnalyzerConfig = new AnalyzerConfigService();
        private readonly ISystemConfigService sysConfig = new SystemConfigService();

        public void Load_DanhSach_MayXN()
        {
            string allowanalyzer = Utilities.ArrayToSqlValue(arrAnalyzerAllow);
            var mayXetNghiem = from selectData in _iAnalyzerConfig.Data_h_mayxetnghiem(false, false, 2).AsEnumerable()
                               where allowanalyzer.Contains(string.Format("'{0}'", selectData["idmay"].ToString()))
                               select selectData;
            if (mayXetNghiem.Any())
            {
                var data = mayXetNghiem.AsDataView().ToTable();

                foreach (DataColumn dtc in data.Columns)
                {
                    dtc.ColumnName = dtc.ColumnName.ToLower();
                }
                gcMayXN.DataSource = data;
                gvMayXN.ExpandAllGroups();
            }
            else
                gcMayXN.DataSource = null;
            Load_LoaiMau();
            Load_DanhSachChiDinh();
        }
        #region Loại mẫu
        private void Load_LoaiMau()
        {
            var data = sysConfig.Data_dm_xetnghiem_loaimau(string.Empty, "ClsXNViSinh");
            data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcLoaiMau.DataSource = data;
            gvLoaiMau.ExpandAllGroups();
        }
        private void Load_DanhSachChiDinh()
        {
            var data = sysConfig.Data_dm_xetnghiem(string.Empty, false, string.Empty);
            if(data != null)
            {
                if (data.Rows.Count >0)
                {
                    data = WorkingServices.SearchResult_OnDatatable_NoneSort(data, string.Format("LoaiXetNghiem in ({0})", (int)Common.TestType.EnumTestType.ViSinhNuoiCay));
                }
            }
            data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
            gcChiDinh.DataSource = data;
            gvChiDinh.ExpandAllGroups();
        }

        private void Load_DannSachChiDinh_DaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                int idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                var data = _bacteriumAntibioticService.Data_ChiDinh_DaMapping(idMay);
                data = WorkingServices.ConvertColumnNameToLower_Upper(data, true);
                gcMappingThe.DataSource = data;
                gvMappingThe.ExpandAllGroups();
            }
            else
                gcMappingThe.DataSource = null;
        }
        private void Insert_ChiDinh_Mapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) == null) return;
            var idMayXn = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
            if (gvChiDinh.GetFocusedRowCellValue(colChiDinh_MaXn) == null) return;
            var maXn = gvChiDinh.GetFocusedRowCellValue(colChiDinh_MaXn).ToString();
            if (gvLoaiMau.GetFocusedRowCellValue(colLoaiMau_MaLoaiMau) == null) return;
            var maloaiMau = gvLoaiMau.GetFocusedRowCellValue(colLoaiMau_MaLoaiMau).ToString();

            if (_bacteriumAntibioticService.Insert_ChiDinh_Mapping(idMayXn, maXn, maloaiMau) > -1)
            {
                Load_DannSachChiDinh_DaMapping();
            }
        }
        private void Update_ChiDinh_Mapping(int rowIndex)
        {
            if (gvMappingThe.GetRowCellValue(rowIndex, colthe_MaXN) == null) return;
            var obj = new H_VISINH_BANGMAYEUCAUMAYXN()
            {
                Id = NumberConverter.ToInt(gvMappingThe.GetRowCellValue(rowIndex, colThe_ID)),
                Mayeucau = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colthe_MaXN)),
                Maloaimau = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_MaLoaiMau)),
                Idmay = NumberConverter.ToInt(gvMappingThe.GetRowCellValue(rowIndex, colThe_IDMayXn)),
                Idthe = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_MaThe)),
                Idtheksd = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_IDTheKS)),
                //SiteInfection = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_SF)),
                Idloaimau = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_IdLoaiMau)),
                Gram = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_GRAM)),
            };
            //var maYeuCau = gvMappingThe.GetRowCellValue(rowIndex, colthe_MaXN).ToString();
            //var maLoaiMau = gvMappingThe.GetRowCellValue(rowIndex, colThe_MaLoaiMau).ToString();
            //var id = int.Parse(gvMappingThe.GetRowCellValue(rowIndex, colThe_ID).ToString());
            //var idThe = gvMappingThe.GetRowCellValue(rowIndex, colThe_MaThe).ToString();
            //var idTheKSD = gvMappingThe.GetRowCellValue(rowIndex, colThe_IDTheKS).ToString();
            //var idLoaiMau = gvMappingThe.GetRowCellValue(rowIndex, colThe_IdLoaiMau).ToString();
            //var Gram = gvMappingThe.GetRowCellValue(rowIndex, colThe_GRAM).ToString();
            //var SiteInf = TPH.Common.Converter.StringConverter.ToString(gvMappingThe.GetRowCellValue(rowIndex, colThe_SF));
            _bacteriumAntibioticService.Update_ChiDinh_Mapping(obj);
            Load_DannSachChiDinh_DaMapping();
        }
        private void Delete_ChiDinh_Mapping()
        {
            if (gvMappingThe.GetFocusedRowCellValue(colthe_MaXN) != null)
            {
                var maXN = gvMappingThe.GetFocusedRowCellValue(colthe_MaXN).ToString();
                var maLoaiMau = gvMappingThe.GetFocusedRowCellValue(colThe_MaLoaiMau).ToString();
                var id = int.Parse(gvMappingThe.GetFocusedRowCellValue(colThe_ID).ToString());
                var maThe = gvMappingThe.GetFocusedRowCellValue(colThe_MaThe).ToString();

                if (_bacteriumAntibioticService.Delete_ChiDinh_Mapping(id) > -1)
                {
                    Load_DannSachChiDinh_DaMapping();
                }
            }
        }
        private void gvMappingThe_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            Update_ChiDinh_Mapping(e.RowHandle);
        }
        private void gcMappingThe_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gcMappingThe.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void btnThemXn_LoaiMau_Click(object sender, EventArgs e)
        {
            Insert_ChiDinh_Mapping();
        }
        private void btnXoaXn_LoaiMau_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khai báo mapping của thẻ?"))
                Delete_ChiDinh_Mapping();
        }
        #endregion
        #region  Vi khuẩn
        private void Load_DanhSach_ViKhuanChuaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                int idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                DataTable dtMainSource = new DataTable();
                //  dtMainSource = dtViKhuan.Copy();
                var dtViKhuan = _bacteriumAntibioticService.Data_ViKhuan_ChuaMapping(idMay);

                var colMaOrder = string.Format("MaPhanLoai_{0}", BacteriumCategory.order.ToString());
                var colTenOrder = string.Format("TenPhanLoai_{0}", BacteriumCategory.order.ToString());


                var colMafamily = string.Format("MaPhanLoai_{0}", BacteriumCategory.family.ToString());
                var colTenfamily = string.Format("TenPhanLoai_{0}", BacteriumCategory.family.ToString());


                var colMagenus = string.Format("MaPhanLoai_{0}", BacteriumCategory.genus.ToString());
                var colTengenus = string.Format("TenPhanLoai_{0}", BacteriumCategory.genus.ToString());


                var colMaspecies = string.Format("MaPhanLoai_{0}", BacteriumCategory.species.ToString());
                var colTenspecies = string.Format("TenPhanLoai_{0}", BacteriumCategory.species.ToString());
                //Phan loai chi
                dtMainSource.Columns.Add(colMaOrder);
                dtMainSource.Columns.Add(colTenOrder);
                //Phan loai chi
                dtMainSource.Columns.Add(colMafamily);
                dtMainSource.Columns.Add(colTenfamily);
                //Phan loai họ
                dtMainSource.Columns.Add(colMagenus);
                dtMainSource.Columns.Add(colTengenus);
                //Phan loai họ
                dtMainSource.Columns.Add(colMaspecies);
                dtMainSource.Columns.Add(colTenspecies);

                DataTable dtSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, "MaPhanLoaiCha is null or MaPhanLoaiCha = ''");
                string maBo = string.Empty;
                string tenBo = string.Empty;
                string maHo = string.Empty;
                string tenHo = string.Empty;
                string maChi = string.Empty;
                string tenChi = string.Empty;
                string maLoai = string.Empty;
                string tenLoai = string.Empty;

                foreach (DataRow drOrder in dtSearch.Rows)
                {
                    maBo = drOrder["MaPhanLoai"].ToString();
                    tenBo = drOrder["TenPhanLoai"].ToString();
                    var drSource = dtMainSource.NewRow();
                    drSource[colMaOrder] = maBo;
                    drSource[colTenOrder] = tenBo;
                    //lấy toàn bộ con của bộ
                    var dataFamily = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maBo));
                    if (dataFamily.Rows.Count > 0)
                    {
                        foreach (DataRow drFamily in dataFamily.Rows)
                        {
                            maHo = drFamily["MaPhanLoai"].ToString();
                            tenHo = drFamily["TenPhanLoai"].ToString();
                            drSource = dtMainSource.NewRow();
                            drSource[colMaOrder] = maBo;
                            drSource[colTenOrder] = tenBo;
                            drSource[colMafamily] = maHo;
                            drSource[colTenfamily] = tenHo;

                            var dataGenus = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maHo));
                            if (dataGenus.Rows.Count > 0)
                            {
                                foreach (DataRow drGenus in dataGenus.Rows)
                                {
                                    maChi = drGenus["MaPhanLoai"].ToString();
                                    tenChi = drGenus["TenPhanLoai"].ToString();
                                    drSource = dtMainSource.NewRow();
                                    drSource[colMaOrder] = maBo;
                                    drSource[colTenOrder] = tenBo;
                                    drSource[colMafamily] = maHo;
                                    drSource[colTenfamily] = tenHo;
                                    drSource[colMagenus] = maChi;
                                    drSource[colTengenus] = tenChi;
                                    var dataSpices = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maChi));
                                    if (dataSpices.Rows.Count > 0)
                                    {
                                        foreach (DataRow drSpices in dataSpices.Rows)
                                        {
                                            maLoai = drSpices["MaPhanLoai"].ToString();
                                            tenLoai = drSpices["TenPhanLoai"].ToString();
                                            drSource = dtMainSource.NewRow();
                                            drSource[colMaOrder] = maBo;
                                            drSource[colTenOrder] = tenBo;
                                            drSource[colMafamily] = maHo;
                                            drSource[colTenfamily] = tenHo;
                                            drSource[colMagenus] = maChi;
                                            drSource[colTengenus] = tenChi;
                                            drSource[colMaspecies] = maLoai;
                                            drSource[colTenspecies] = tenLoai;
                                            dtMainSource.Rows.Add(drSource);
                                        }
                                    }
                                    else
                                        dtMainSource.Rows.Add(drSource);
                                }
                            }
                            else
                                dtMainSource.Rows.Add(drSource);
                        }
                    }
                    else
                        dtMainSource.Rows.Add(drSource);
                }
                gcKSD_ViKhuan.DataSource = dtMainSource;
                gvKSD_ViKhuan.ExpandAllGroups();
            }
            else
                gcKSD_ViKhuan.DataSource = null;
        }
        private void Load_DanhSach_ViKhuanDaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                int idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                DataTable dtMainSource = new DataTable();
                //  dtMainSource = dtViKhuan.Copy();
                var dtViKhuan = _bacteriumAntibioticService.Data_ViKhuan_DaMapping(idMay);

                var colMaOrder = string.Format("MaPhanLoai_{0}", BacteriumCategory.order.ToString());
                var colTenOrder = string.Format("TenPhanLoai_{0}", BacteriumCategory.order.ToString());


                var colMafamily = string.Format("MaPhanLoai_{0}", BacteriumCategory.family.ToString());
                var colTenfamily = string.Format("TenPhanLoai_{0}", BacteriumCategory.family.ToString());


                var colMagenus = string.Format("MaPhanLoai_{0}", BacteriumCategory.genus.ToString());
                var colTengenus = string.Format("TenPhanLoai_{0}", BacteriumCategory.genus.ToString());


                var colMaspecies = string.Format("MaPhanLoai_{0}", BacteriumCategory.species.ToString());
                var colTenspecies = string.Format("TenPhanLoai_{0}", BacteriumCategory.species.ToString());
                //Phan loai chi
                dtMainSource.Columns.Add(colMaOrder);
                dtMainSource.Columns.Add(colTenOrder);
                //Phan loai chi
                dtMainSource.Columns.Add(colMafamily);
                dtMainSource.Columns.Add(colTenfamily);
                //Phan loai họ
                dtMainSource.Columns.Add(colMagenus);
                dtMainSource.Columns.Add(colTengenus);
                //Phan loai họ
                dtMainSource.Columns.Add(colMaspecies);
                dtMainSource.Columns.Add(colTenspecies);
                //Thong tin mapping
                dtMainSource.Columns.Add("MaViKhuanMay");
                dtMainSource.Columns.Add("IDMayXetNghiem");

                DataTable dtSearch = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, "MaPhanLoaiCha is null or MaPhanLoaiCha = ''");
                string maBo = string.Empty;
                string tenBo = string.Empty;
                string maHo = string.Empty;
                string tenHo = string.Empty;
                string maChi = string.Empty;
                string tenChi = string.Empty;
                string maLoai = string.Empty;
                string tenLoai = string.Empty;

                foreach (DataRow drOrder in dtSearch.Rows)
                {
                    maBo = drOrder["MaPhanLoai"].ToString();
                    tenBo = drOrder["TenPhanLoai"].ToString();
                    var drSource = dtMainSource.NewRow();
                    drSource[colMaOrder] = maBo;
                    drSource[colTenOrder] = tenBo;
                    //lấy toàn bộ con của bộ
                    var dataFamily = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maBo));
                    if (dataFamily.Rows.Count > 0)
                    {
                        foreach (DataRow drFamily in dataFamily.Rows)
                        {
                            maHo = drFamily["MaPhanLoai"].ToString();
                            tenHo = drFamily["TenPhanLoai"].ToString();
                            drSource = dtMainSource.NewRow();
                            drSource[colMaOrder] = maBo;
                            drSource[colTenOrder] = tenBo;
                            drSource[colMafamily] = maHo;
                            drSource[colTenfamily] = tenHo;

                            var dataGenus = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maHo));
                            if (dataGenus.Rows.Count > 0)
                            {
                                foreach (DataRow drGenus in dataGenus.Rows)
                                {
                                    maChi = drGenus["MaPhanLoai"].ToString();
                                    tenChi = drGenus["TenPhanLoai"].ToString();
                                    drSource = dtMainSource.NewRow();
                                    drSource[colMaOrder] = maBo;
                                    drSource[colTenOrder] = tenBo;
                                    drSource[colMafamily] = maHo;
                                    drSource[colTenfamily] = tenHo;
                                    drSource[colMagenus] = maChi;
                                    drSource[colTengenus] = tenChi;
                                    var dataSpices = WorkingServices.SearchResult_OnDatatable_NoneSort(dtViKhuan, string.Format("MaPhanLoaiCha = '{0}'", maChi));
                                    if (dataSpices.Rows.Count > 0)
                                    {
                                        foreach (DataRow drSpices in dataSpices.Rows)
                                        {
                                            maLoai = drSpices["MaPhanLoai"].ToString();
                                            tenLoai = drSpices["TenPhanLoai"].ToString();
                                            drSource = dtMainSource.NewRow();
                                            drSource[colMaOrder] = maBo;
                                            drSource[colTenOrder] = tenBo;
                                            drSource[colMafamily] = maHo;
                                            drSource[colTenfamily] = tenHo;
                                            drSource[colMagenus] = maChi;
                                            drSource[colTengenus] = tenChi;
                                            drSource[colMaspecies] = maLoai;
                                            drSource[colTenspecies] = tenLoai;

                                            drSource["MaViKhuanMay"] = drSpices["MaViKhuanMay"].ToString(); ;
                                            drSource["IDMayXetNghiem"] = drSpices["IDMayXetNghiem"].ToString(); ;

                                            dtMainSource.Rows.Add(drSource);
                                        }
                                    }
                                    else
                                        dtMainSource.Rows.Add(drSource);

                                }
                            }
                            else
                                dtMainSource.Rows.Add(drSource);

                        }
                    }
                    else
                        dtMainSource.Rows.Add(drSource);
                }
                gcMappingViKhuan.DataSource = dtMainSource;
                gvMappingViKhuan.ExpandAllGroups();
            }
            else
                gcMappingViKhuan.DataSource = null;
        }
        private void Insert_ViKhuan_Mapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMayXn = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                if (gvKSD_ViKhuan.GetFocusedRowCellValue(colKSD_ViKhuan_MaPhanLoai_species) != null)
                {
                    var maviKhuan = gvKSD_ViKhuan.GetFocusedRowCellValue(colKSD_ViKhuan_MaPhanLoai_species).ToString();
                    if (_bacteriumAntibioticService.Insert_ViKhuan_Mapping(idMayXn, maviKhuan) > -1)
                    {
                        Load_DanhSach_ViKhuanChuaMapping();
                        Load_DanhSach_ViKhuanDaMapping();
                    }
                    else
                    {
                        CustomMessageBox.MSG_Information_OK("Mapping vi khuẩn đã được nhập trước!");
                    }
                }
            }
        }
        private void Update_ViKhuan_Mapping(int rowIndex)
        {
            if (gvMappingViKhuan.GetRowCellValue(rowIndex, colMappingViKhuan_MaPhanLoai_species) != null)
            {
                var maViKhuan = gvMappingViKhuan.GetRowCellValue(rowIndex, colMappingViKhuan_MaPhanLoai_species).ToString();
                var maVikhuanMay = gvMappingViKhuan.GetRowCellValue(rowIndex, colMappingViKhuan_MaXnMay).ToString();
                var idMayXn = int.Parse(gvMappingViKhuan.GetRowCellValue(rowIndex, colMappingViKhuan_IDMayXetNghiem).ToString());
                _bacteriumAntibioticService.Update_ViKhuan_Mapping(idMayXn, maViKhuan, maVikhuanMay);
            }
        }
        private void Delete_ViKhuan_Mapping()
        {
            if (gvMappingViKhuan.GetFocusedRowCellValue(colMappingViKhuan_MaPhanLoai_species) != null)
            {
                var maViKhuan = gvMappingViKhuan.GetFocusedRowCellValue(colMappingViKhuan_MaPhanLoai_species).ToString();
                var maVikhuanMay = gvMappingViKhuan.GetFocusedRowCellValue(colMappingViKhuan_MaXnMay).ToString();
                var idMayXn = int.Parse(gvMappingViKhuan.GetFocusedRowCellValue(colMappingViKhuan_IDMayXetNghiem).ToString());
                if (_bacteriumAntibioticService.Delete_ViKhuan_Mapping(idMayXn, maViKhuan, maVikhuanMay) > -1)
                {
                    Load_DanhSach_ViKhuanChuaMapping();
                    Load_DanhSach_ViKhuanDaMapping();
                }
            }
        }
        #endregion
        #region  Kháng sinh
        private void Load_DanhSach_KhangSinhChuaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                var data = _bacteriumAntibioticService.Data_KhangSinh_ChuaMapping(idMay);
                gcKhangSinh.DataSource = data;
                gvKhangSinh.ExpandAllGroups();
            }
            else
                gcKhangSinh.DataSource = null;
        }
        private void Load_DanhSach_KhangSinhDaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                var data = _bacteriumAntibioticService.Data_KhangSinh_DaMapping(idMay);

                //ucSearchLookupEditor_AntibioticPanel

                var listSF = _bacteriumAntibioticService.Get_DM_Site_INF();
                lookUp_SiteINF.DataSource = listSF;
                lookUp_SiteINF.ValueMember = "SiteInfection";
                lookUp_SiteINF.DisplayMember = "SiteInfection";
                lookUp_SiteINF.NullText = @"--Chọn SiteInfection--";
                colMappingKhangSinh_SiteINF.ColumnEdit = lookUp_SiteINF;


                gcMappingKhangSinh.DataSource = data;
                gvMappingKhangSinh.ExpandAllGroups();
            }
            else
                gcMappingKhangSinh.DataSource = null;
        }
        private void Insert_KhangSinh_Mapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMayXn = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                if (gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh) != null)
                {
                    var maKhangSinh = gvKhangSinh.GetFocusedRowCellValue(colKhangSinh_MaKhangSinh).ToString();

                    //var maKhangSinhMay = TPH.Common.Converter.StringConverter.ToString(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_MaKhangSinhMay));
                    //var siteINF = TPH.Common.Converter.StringConverter.ToString(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_SiteINF));


                    if (_bacteriumAntibioticService.Insert_KhangSinh_Mapping(idMayXn, maKhangSinh) > -1)
                    {
                        Load_DanhSach_KhangSinhChuaMapping();
                        Load_DanhSach_KhangSinhDaMapping();
                    }
                }
            }
        }
        private void Update_KhangSinh_Mapping(int rowIndex)
        {
            if (gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_MaKhangSinh) != null)
            {
                var maKhangSinh = TPH.Common.Converter.StringConverter.ToString(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_MaKhangSinh));
                var maKhangSinhMay = TPH.Common.Converter.StringConverter.ToString(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_MaKhangSinhMay));
                var idMayXn = int.Parse(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_IDMayXetNghiem).ToString());
                var siteINF = TPH.Common.Converter.StringConverter.ToString(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_SiteINF));
                var autoID = TPH.Common.Converter.NumberConverter.ToInt(gvMappingKhangSinh.GetRowCellValue(rowIndex, colMappingKhangSinh_AutoID));

                _bacteriumAntibioticService.Update_KhangSinh_Mapping(idMayXn, maKhangSinh, maKhangSinhMay, siteINF,autoID);
            }
            Load_DanhSach_KhangSinhChuaMapping();
            Load_DanhSach_KhangSinhDaMapping();
        }

        private void Delete_KhangSinh_Mapping()
        {
            if (gvMappingKhangSinh.GetFocusedRowCellValue(colMappingKhangSinh_MaKhangSinh) == null) return;
            var maKhangSinh = gvMappingKhangSinh.GetFocusedRowCellValue(colMappingKhangSinh_MaKhangSinh).ToString();
            var maKhangSinhMay = gvMappingKhangSinh.GetFocusedRowCellValue(colMappingKhangSinh_MaKhangSinhMay).ToString();
            var idMayXn = int.Parse(gvMappingKhangSinh.GetFocusedRowCellValue(colMappingKhangSinh_IDMayXetNghiem).ToString());
            var autoID = TPH.Common.Converter.NumberConverter.ToInt(gvMappingKhangSinh.GetFocusedRowCellValue(colMappingKhangSinh_AutoID));

            if (_bacteriumAntibioticService.Delete_KhangSinh_Mapping(autoID) <= -1)
                return;
            Load_DanhSach_KhangSinhChuaMapping();
            Load_DanhSach_KhangSinhDaMapping();
        }
        #endregion

        private void gvMayXN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_DannSachChiDinh_DaMapping();

            Load_DanhSach_ViKhuanChuaMapping();
            Load_DanhSach_ViKhuanDaMapping();

            Load_DanhSach_KhangSinhChuaMapping();
            Load_DanhSach_KhangSinhDaMapping();

            Load_DanhSach_KhangKhangSinhChuaMapping();
            Load_DanhSach_KhangKhangSinhDaMapping();
        }

        private void btnThemVK_Click(object sender, EventArgs e)
        {
            Insert_ViKhuan_Mapping();
        }

        private void btnThemKS_Click(object sender, EventArgs e)
        {
            Insert_KhangSinh_Mapping();
        }

        private void gvMappingViKhuan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Update_ViKhuan_Mapping(e.RowHandle);
        }

        private void gvMappingKhangSinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Update_KhangSinh_Mapping(e.RowHandle);
        }

        private void btnXoaVK_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khai báo mapping của vi khuẩn?"))
                Delete_ViKhuan_Mapping();
        }

        private void btnXoaKS_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khai báo mapping của kháng sinh?"))
                Delete_KhangSinh_Mapping();
        }

        private void gcMappingViKhuan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gcMappingViKhuan.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void gcMappingKhangSinh_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gcMappingKhangSinh.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void gcMappingKhangSinh_Click(object sender, EventArgs e)
        {

        }

        private void btnThemKKS_Click(object sender, EventArgs e)
        {
            Insert_KhangKhangSinh_Mapping();
        }

        private void btnXoaKKS_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xóa khai báo mapping của kháng kháng sinh?"))
                Xoa_KhangKhangSinh_Mapping();
        }
        private void Insert_KhangKhangSinh_Mapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMayXn = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                if (gvKKS.GetFocusedRowCellValue(colKKS_MaKKS) != null)
                {
                    var maKKS = gvKKS.GetFocusedRowCellValue(colKKS_MaKKS).ToString();
                    if (_bacteriumAntibioticService.Insert_KhangKhangSinh_Mapping(idMayXn, maKKS) > -1)
                    {
                        Load_DanhSach_KhangKhangSinhChuaMapping();
                        Load_DanhSach_KhangKhangSinhDaMapping();
                    }
                }
            }
        }
        private void Xoa_KhangKhangSinh_Mapping()
        {
            if (gvMappingKKS.GetFocusedRowCellValue(colMappingKKS_MaKKS) == null) return;
            var autoID = TPH.Common.Converter.NumberConverter.ToInt(gvMappingKKS.GetFocusedRowCellValue(colMappingKKS_AutoID));

            if (_bacteriumAntibioticService.Delete_KhangKhangSinh_Mapping(autoID) <= -1)
                return;
            Load_DanhSach_KhangKhangSinhChuaMapping();
            Load_DanhSach_KhangKhangSinhDaMapping();
        }

        private void Load_DanhSach_KhangKhangSinhChuaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                var data = _bacteriumAntibioticService.Data_KhangKhangSinh_ChuaMapping(idMay);
                gcKKS.DataSource = data;
                gvKKS.ExpandAllGroups();
            }
            else
                gcKKS.DataSource = null;
        }
        private void Load_DanhSach_KhangKhangSinhDaMapping()
        {
            if (gvMayXN.GetFocusedRowCellValue(colIDMayXn) != null)
            {
                var idMay = int.Parse(gvMayXN.GetFocusedRowCellValue(colIDMayXn).ToString());
                var data = _bacteriumAntibioticService.Data_KhangKhangSinh_DaMapping(idMay);

                gcMappingKKS.DataSource = data;
                gvMappingKKS.ExpandAllGroups();
            }
            else
                gcMappingKKS.DataSource = null;
        }

        private void Update_KhangKhangSinh_Mapping(int rowIndex)
        {
            if (gvMappingKKS.GetRowCellValue(rowIndex, colMappingKKS_MaKKS) != null)
            {
                var maKKS = TPH.Common.Converter.StringConverter.ToString(gvMappingKKS.GetRowCellValue(rowIndex, colMappingKKS_MaKKS));
                var maKKSmay = TPH.Common.Converter.StringConverter.ToString(gvMappingKKS.GetRowCellValue(rowIndex, colMappingKKS_MaMay));
                var idMayXn = int.Parse(gvMappingKKS.GetRowCellValue(rowIndex, colMappingKKS_IdMayXN).ToString());
                var autoID = TPH.Common.Converter.NumberConverter.ToInt(gvMappingKKS.GetRowCellValue(rowIndex, colMappingKKS_AutoID));

                _bacteriumAntibioticService.Update_KhangKhangSinh_Mapping(idMayXn, maKKS, maKKSmay, autoID);
            }
            Load_DanhSach_KhangKhangSinhChuaMapping();
            Load_DanhSach_KhangKhangSinhDaMapping();
        }

        private void gvMappingKKS_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            Update_KhangKhangSinh_Mapping(e.RowHandle);
        }
    }
}
