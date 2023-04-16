using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPH.Data.HIS.HISDataCommon;
using TPH.Lab.Middleware.LISConnect.DataAccesses;
using TPH.Data.HIS.Models;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Controls;
using TPH.Controls;
using TPH.HIS.Controls;
using TPH.HIS.WebAPI.Models.HisReponses;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinh_His : FrmTemplate
    {
        public FrmCauHinh_His()
        {
            InitializeComponent();
        }
        private string radHiProvdernameFirst = "radHisProvider_";
        private readonly IConnectHISDataAccess _iHisConfig = new ConnectHISDataAccess();
        HisConnection hisConnectInfo = new HisConnection();
        HisFunctionConfig hisFunction = new HisFunctionConfig();
        private Dictionary<string, Dictionary<string, string>> dicFunctions = new Dictionary<string, Dictionary<string, string>>();
        private HisFunctionID objHisFunctionID = new HisFunctionID();
        private void FrmCauHinh_His_Load(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabCauHinh.TabPages)
            {
                tab.BackColor = CommonAppColors.ColorMainAppFormColor;
            }
            LoadDicFunctionList();

            Load_HisConnectType();
            Load_LisConfigColunms();
            Load_HISCommandType();
            Load_ListOfHis();
        }
        private void LoadDicFunctionList()
        {
            dicFunctions = WorkingServices.GetPorpetiesAndDescriptionAndCategoryList(objHisFunctionID);
            //Tab danh mục
            var dicAction = dicFunctions["DanhMuc"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("DanhMuc_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 2;
                obj.Load_Config();
                tabDanhMuc.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }
            //Tab chỉ định
            dicAction = dicFunctions["ChiDinh"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("ChiDinh_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 2;
                obj.Load_Config();
                tabDanhSachChiDinh.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }

            //Tab KẾT QUẢ
            dicAction = dicFunctions["TraKetQua"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("TraKetQua_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 0;
                obj.Load_Config();
                tabUploadKetQua.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }
            //Tab KẾT QUẢ
            dicAction = dicFunctions["TraKetQua_OBX"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("TraKetQua_OBX_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 0;
                obj.UseHL7Field = true;
                obj.HL7Fame = 0;
                obj.Load_Config();
                tabUploadKetQua.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }
            //Tab KẾT QUẢ
            dicAction = dicFunctions["TraKetQua_ORC"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("TraKetQua_ORC_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 0;
                obj.UseHL7Field = true;
                obj.HL7Fame = 1;
                obj.Load_Config();
                tabUploadKetQua.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }
            //Tab KẾT QUẢ
            dicAction = dicFunctions["TraKetQua_PID"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("TraKetQua_PID_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 0;
                obj.UseHL7Field = true;
                obj.HL7Fame = 2;
                obj.Load_Config();
                tabUploadKetQua.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }
            //Thông tin mẫu
            dicAction = dicFunctions["ThongTinMau"];
            foreach (var itm in dicAction)
            {
                var obj = new ucFunctionConfig();
                obj.Name = String.Format("ThongTinMau_{0}", itm.Key);
                obj.FunctionID = itm.Key;
                obj.SetTitle = itm.Value;
                obj.LoaiThamSo = 1;
                obj.HL7Fame = 2;
                obj.Load_Config();
                tabThongTinMau.Controls.Add(obj);
                obj.Dock = DockStyle.Top;
                obj.BringToFront();
            }
            
        }
        private void Load_ListOfHis()
        {
            var list = CommonData.GetEnumValuesAndDescriptions<HisProvider>().Where(x => CommonAppVarsAndFunctions.allWorkingHis.Contains(x.Key));
            foreach (var item in list)
            {
                RadioButton rad = new RadioButton();
                rad.Name = string.Format("{0}{1}", radHiProvdernameFirst, item.Key);
                rad.Text = item.Value;
                rad.AutoSize = true;
                Font font = new Font(rad.Font, FontStyle.Bold);
                rad.Font = font;
                rad.CheckedChanged += Rad_CheckedChanged;
                flpHisList.Controls.Add(rad);
                rad.Dock = DockStyle.Left;
                rad.BringToFront();
                rad.Checked = true;
            }
        }
        private void Load_HisConnectType()
        {
            var list = CommonData.GetEnumValuesAndDescriptions<DBConnectType>();
            cboThongTinKieuKetNoi.DataSource = list;
            cboThongTinKieuKetNoi.ValueMember = "Key";
            cboThongTinKieuKetNoi.DisplayMember = "Value";
            cboThongTinKieuKetNoi.SelectedIndex = -1;
        }
        private void Load_HISCommandType()
        {
            var list = CommonData.GetEnumValuesAndDescriptions<FunctionType>();
            ControlExtension.BindDataToCobobox(list.ToList(), ref cboToken_LoaiLenh, "Key", "Value");
        }
        private void Rad_CheckedChanged(object sender, EventArgs e)
        {
            var obj = (RadioButton)sender;
            if (obj.Checked)
            {
                obj.BackColor = Color.Yellow;
            }
            else
                obj.BackColor = Color.Empty;
            if (obj.Checked)
            {
                LoadHisConfig(obj.Name);
            }
        }
        private void Load_LisConfigColunms()
        {
            var listColumn = HISModelHelper.HisColumnsMappingList().ToList();
            colChiDinhTenTruong.DataSource = listColumn;
            colChiDinhTenTruong.ValueMember = "Key";
            colChiDinhTenTruong.DisplayMember = "Value";

            colDanhMucTenTruong.DataSource = listColumn;
            colDanhMucTenTruong.ValueMember = "Key";
            colDanhMucTenTruong.DisplayMember = "Value";


            cboThongTinHisCotNoiTru.DataSource = listColumn;
            cboThongTinHisCotNoiTru.ValueMember = "Key";
            cboThongTinHisCotNoiTru.DisplayMember = "Value";
        }
        private void ClearInfo()
        {
            //Thông tin kết nối
            cboThongTinKieuKetNoi.SelectedIndex = -1;
            txtThongTinTenMaychu.Text = string.Empty;
            txtThongTinTenDatabase.Text = string.Empty;
            txtThongTinPort.Text = string.Empty;
            txtThongTinTaiKhoan.Text = string.Empty;
            txtThongTinMatKhau.Text = string.Empty;
            chkThongTinSuDungHis.Checked = false;
            chkThongTinHisPhanBietNoiTru.Checked = false;
            radThongTinHisNoiTruBangGiaTriTrongChuoi.Checked = false;
            radThongTinHisNoiTruGiaTriTruFalse.Checked = false;
            radThongTinHisNoiTruGiaTriCoTrongChuoi.Checked = false;
            chkKhongLoaDanhSach.Checked = false;
            chkTimTenTrenHIS.Checked = false;
            txtThongTinGiaTriNoiTru.Text = string.Empty;
            txtThongTinViTriBatDau.Text = string.Empty;

            txtLISServerName.Text = string.Empty;
            txtLISDatabaseName.Text = string.Empty;
            txtLISServerName.Text = string.Empty;
            txtLISPassword.Text = string.Empty;
            txtLISADTFunction.Text = string.Empty;

            foreach (var item in tabDanhMuc.Controls)
            {
                if (item is ucFunctionConfig)
                {
                    ((ucFunctionConfig)item).ClearData();
                }
            }
            foreach (var item in tabDanhSachChiDinh.Controls)
            {
                if (item is ucFunctionConfig)
                {
                    ((ucFunctionConfig)item).ClearData();
                }
            }
            foreach (var item in tabUploadKetQua.Controls)
            {
                if (item is ucFunctionConfig)
                {
                    ((ucFunctionConfig)item).ClearData();
                }
            }
            foreach (var item in tabThongTinMau.Controls)
            {
                if (item is ucFunctionConfig)
                {
                    ((ucFunctionConfig)item).ClearData();
                }
            }

            txtToken_TenHam.Text = string.Empty;
            txtToken_GiaTriLis.Text = string.Empty;
            txtToken_ThamSo.Text = string.Empty;
            cboToken_LoaiLenh.SelectedIndex = -1;
        }
        private void LoadHisConfig(string radioHisName)
        {
            ClearInfo();

            string idHis = radioHisName.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1];
            var hisIDEnum = (HisProvider)Enum.Parse(typeof(HisProvider), idHis);
            //Thông tin kết nối
            hisConnectInfo = _iHisConfig.DataHisThongTin().Where(x => x.HisID == hisIDEnum).FirstOrDefault();

            if (hisConnectInfo != null)
            {
                radThongTinFalse.CheckedChanged -= radThongTinFalse_CheckedChanged;

                cboThongTinKieuKetNoi.SelectedValue = (int)hisConnectInfo.DbType;
                txtThongTinTenMaychu.Text = hisConnectInfo.ServerName;
                txtThongTinTenDatabase.Text = hisConnectInfo.DatabaseName;
                txtThongTinPort.Text = hisConnectInfo.PortNumber;
                txtThongTinTaiKhoan.Text = hisConnectInfo.UserName;
                txtThongTinMatKhau.Text = hisConnectInfo.PassWord;
                chkKhongLoaDanhSach.Checked = hisConnectInfo.NotUsePatientList;
                chkTimTenTrenHIS.Checked = hisConnectInfo.FindNameOnHIS;
                chkThongTinSuDungHis.Checked = hisConnectInfo.IsActive;
                chkThongTinHisPhanBietNoiTru.Checked = hisConnectInfo.DifferenceInOut;
                radThongTinHisNoiTruBangGiaTriTrongChuoi.Checked = hisConnectInfo.InteralByCharIndex;
                radThongTinHisNoiTruGiaTriTruFalse.Checked = hisConnectInfo.InternalBitValue;
                radThongTinHisNoiTruGiaTriCoTrongChuoi.Checked = hisConnectInfo.InternalContaint;
                txtThongTinGiaTriNoiTru.Text = hisConnectInfo.InternalCharValue;
                txtThongTinViTriBatDau.Text = hisConnectInfo.InternalCharStartIndex;

                txtLISServerName.Text = hisConnectInfo.LISServerName;
                txtLISDatabaseName.Text = hisConnectInfo.LISDatabasename;
                txtLISUsername.Text = hisConnectInfo.LISUserName;
                txtLISPassword.Text = hisConnectInfo.LISPassword;
                txtLISADTFunction.Text = hisConnectInfo.LISCallADTName;
                radThongTinFalse.CheckedChanged += radThongTinFalse_CheckedChanged;
            }
            //Thông tin cá hàm / thủ tục

            var hisFunctionList = _iHisConfig.DataHisThongTinHam().Where(x => x.HisID == hisIDEnum);

            if (hisFunctionList != null)
            {
                hisFunction = hisFunctionList.Where(x => x.FunctionID == objHisFunctionID.LayToken).FirstOrDefault();
                if (hisFunction != null)
                {
                    txtToken_TenHam.Text = hisFunction.FunctionName;
                    txtToken_ThamSo.Text = hisFunction.FunctionParaNames;
                    txtToken_GiaTriLis.Text = hisFunction.LISColumns;
                    cboToken_LoaiLenh.SelectedValue = (int)hisFunction.FunctionTypeID;
                }

                foreach (var item in tabDanhMuc.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        var obj = (ucFunctionConfig)item;
                        hisFunction = hisFunctionList.Where(x => x.FunctionID == obj.FunctionID).FirstOrDefault();
                        if (hisFunction != null)
                        {
                            obj.SetInfo(hisFunction);
                        }
                    }
                }
                foreach (var item in tabDanhSachChiDinh.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        var obj = (ucFunctionConfig)item;
                        hisFunction = hisFunctionList.Where(x => x.FunctionID == obj.FunctionID).FirstOrDefault();
                        if (hisFunction != null)
                        {
                            obj.SetInfo(hisFunction);
                        }
                    }
                }
                foreach (var item in tabUploadKetQua.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        var obj = (ucFunctionConfig)item;
                        hisFunction = hisFunctionList.Where(x => x.FunctionID == obj.FunctionID).FirstOrDefault();
                        if (hisFunction != null)
                        {
                            obj.SetInfo(hisFunction);
                        }
                    }
                }
                foreach (var item in tabThongTinMau.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        var obj = (ucFunctionConfig)item;
                        hisFunction = hisFunctionList.Where(x => x.FunctionID == obj.FunctionID).FirstOrDefault();
                        if (hisFunction != null)
                        {
                            obj.SetInfo(hisFunction);
                        }
                    }
                }
                //Thông tin mapping trường
                var dataMappingCot = _iHisConfig.DataTableHisThongTinMappingCot(idHis);
                var dataDanhMuc = WorkingServices.SearchResult_OnDatatable_NoneSort(dataMappingCot, "HisColumnsName like 'dm%'");
                ControlExtension.BindToGrid(dataDanhMuc, dtgDanhMucTruongTraVe, bvDanhMucTruongTraVe);
                var dataChiDinh = WorkingServices.SearchResult_OnDatatable_NoneSort(dataMappingCot, "HisColumnsName like 'chidinh%' or HisColumnsName like 'ketqua%' or HisColumnsName like 'tumau%'");
                ControlExtension.BindToGrid(dataChiDinh, dtgChiDinhTruongTraVe, bvChiDinhTruongTraVe);
            }
        }
        private void Save_ThongTin()
        {
            if (cboThongTinKieuKetNoi.SelectedIndex > -1)
            {
                if (hisConnectInfo == null || hisConnectInfo.HisID == null)
                {
                    CustomMessageBox.MSG_Information_OK("Chưa có cấu hình HIS này. Vui lòng bấm Thêm cấu hình HIS!");
                    return;
                }
                var infoUpdate = new HisConnection();
                infoUpdate.HisID = hisConnectInfo.HisID;

                infoUpdate.DbType = (DBConnectType)Enum.Parse(typeof(DBConnectType), cboThongTinKieuKetNoi.SelectedValue.ToString());
                infoUpdate.ServerName = txtThongTinTenMaychu.Text;
                infoUpdate.DatabaseName = txtThongTinTenDatabase.Text;
                infoUpdate.PortNumber = txtThongTinPort.Text;
                infoUpdate.UserName = txtThongTinTaiKhoan.Text;
                infoUpdate.PassWord = txtThongTinMatKhau.Text;

                infoUpdate.NotUsePatientList = chkKhongLoaDanhSach.Checked;
                infoUpdate.IsActive = chkThongTinSuDungHis.Checked;
                infoUpdate.DifferenceInOut = chkThongTinHisPhanBietNoiTru.Checked;
                infoUpdate.InteralByCharIndex = radThongTinHisNoiTruBangGiaTriTrongChuoi.Checked;
                infoUpdate.InternalBitValue = radThongTinHisNoiTruGiaTriTruFalse.Checked;
                infoUpdate.InternalContaint = radThongTinHisNoiTruGiaTriCoTrongChuoi.Checked;
                infoUpdate.InternalCharValue = txtThongTinGiaTriNoiTru.Text;
                infoUpdate.InternalCharStartIndex = txtThongTinViTriBatDau.Text;

                infoUpdate.LISServerName = txtLISServerName.Text;
                infoUpdate.LISDatabasename = txtLISDatabaseName.Text;
                infoUpdate.LISCallADTName = txtLISADTFunction.Text;
                infoUpdate.LISUserName = txtLISUsername.Text;
                infoUpdate.LISPassword = txtLISPassword.Text;
                infoUpdate.FindNameOnHIS = chkTimTenTrenHIS.Checked;
                _iHisConfig.Update_HisConnection(infoUpdate);

                var functionInfo = new HisFunctionConfig();
                //Lấy token
                functionInfo.HisID = hisConnectInfo.HisID;
                functionInfo.FunctionID = objHisFunctionID.LayToken;
                functionInfo.FunctionName = txtToken_TenHam.Text;
                functionInfo.FunctionParaNames = txtToken_ThamSo.Text;
                functionInfo.LISColumns = txtToken_GiaTriLis.Text;
                functionInfo.FunctionTypeID = (cboToken_LoaiLenh.SelectedValue == null ? FunctionType.StoreProcedure : (FunctionType)Enum.Parse(typeof(FunctionType), cboToken_LoaiLenh.SelectedValue.ToString()));
                _iHisConfig.Update_ThongTinHam(functionInfo);
            }
        }

        private void dtgDanhMucTruongTraVe_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDanhMucTruongTraVe.RowCount > 0)
            {
                _iHisConfig.Update_ThongTinMappingCot(dtgDanhMucTruongTraVe[colDanhMucHISID.Name, e.RowIndex].Value.ToString().Trim()
                    , dtgDanhMucTruongTraVe[colDanhMucTenTruong.Name, e.RowIndex].Value.ToString().Trim()
                   , dtgDanhMucTruongTraVe[colDanhMucTenTruongTrenHIS.Name, e.RowIndex].Value.ToString().Trim());
            }
        }

        private void dtgChiDinhTruongTraVe_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgChiDinhTruongTraVe.RowCount > 0)
            {
                _iHisConfig.Update_ThongTinMappingCot(dtgChiDinhTruongTraVe[colChiDinhHisID.Name, e.RowIndex].Value.ToString().Trim()
                    , dtgChiDinhTruongTraVe[colChiDinhTenTruong.Name, e.RowIndex].Value.ToString().Trim()
                   , dtgChiDinhTruongTraVe[colChiDinhTenTruongHis.Name, e.RowIndex].Value.ToString().Trim());
            }
        }

        private void btnThemCauHinh_Click(object sender, EventArgs e)
        {
            var radioName = string.Empty;
            var hisName = string.Empty;
            var hisId = GetSelectedHisID(ref hisName, ref radioName);
            if (!string.IsNullOrEmpty(hisId))
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes(string.Format("Thêm cho HIS [{0}] ?", hisName)))
                {
                    //Nạp lại cấu hình chuẩn các trường trả về
                    var listColumn = HISModelHelper.HisColumnsMappingList().ToList();
                    foreach (var item in listColumn)
                    {
                        if (!item.Key.Equals("hisid", StringComparison.OrdinalIgnoreCase))
                            _iHisConfig.Insert_ThongTinTruongHISTraVe(item.Key);
                    }

                    //Nạp lại cấu hình chuẩn các thủ tục
                    var listFunction = WorkingServices.GetPorpetiesAndDescriptionAndCategoryList(objHisFunctionID);
                    foreach (var item in listFunction)
                    {
                        foreach (var itemSub in item.Value)
                        {
                            if (!itemSub.Key.Equals("hisid", StringComparison.OrdinalIgnoreCase))
                                _iHisConfig.Insert_ThongTinThuTucHIS(itemSub.Key);
                        }
                    }
                    //Thêm cấu hình his hiện tại theo chuẩn
                    _iHisConfig.HisNhapCauHinhTheoChuan(int.Parse(hisId), hisName);
                    LoadHisConfig(radioName);
                }
            }
        }
        private string GetSelectedHisID(ref string hisName, ref string radioName)
        {
            foreach (var coltr in flpHisList.Controls)
            {
                if (coltr is RadioButton)
                {
                    var obj = (RadioButton)coltr;
                    if (obj.Checked)
                    {
                        radioName = obj.Name;
                        hisName = obj.Text;
                        string idHis = obj.Name.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        return idHis;
                    }
                }
            }
            return string.Empty;
        }


        private void radThongTinHisNoiTruGiaTriTruFalse_CheckedChanged(object sender, EventArgs e)
        {
            pnTrueFalse.Visible = radThongTinHisNoiTruGiaTriTruFalse.Checked;

            txtThongTinGiaTriNoiTru.Enabled = !radThongTinHisNoiTruGiaTriTruFalse.Checked;
            if (radThongTinHisNoiTruGiaTriTruFalse.Checked)
                txtThongTinGiaTriNoiTru.MaxLength = 4;
            else
                txtThongTinGiaTriNoiTru.MaxLength = 10;
        }

        private void chkThongTinHisPhanBietNoiTru_CheckedChanged(object sender, EventArgs e)
        {
            gbInternal.Enabled = chkThongTinHisPhanBietNoiTru.Checked;
        }

        private void txtThongTinGiaTriNoiTru_TextChanged(object sender, EventArgs e)
        {
            if (radThongTinHisNoiTruGiaTriTruFalse.Checked)
            {
                if (!string.IsNullOrEmpty(txtThongTinGiaTriNoiTru.Text))
                {
                    if (txtThongTinGiaTriNoiTru.Text.Trim().Equals("1") || txtThongTinGiaTriNoiTru.Text.Trim().Equals("True"))
                        radThongTinTrue.Checked = true;
                    else
                        radThongTinTrue.Checked = false;
                }
            }
        }

        private void txtThongTinGiaTriNoiTru_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radThongTinHisNoiTruGiaTriTruFalse.Checked)
            {
                ControlExtension.KeyNumber(e, false);
            }
        }

        private void radThongTinHisNoiTruBangGiaTriTrongChuoi_CheckedChanged(object sender, EventArgs e)
        {

            txtThongTinViTriBatDau.Enabled = radThongTinHisNoiTruBangGiaTriTrongChuoi.Checked;
        }

        private void radThongTinTrue_CheckedChanged(object sender, EventArgs e)
        {
            if (radThongTinTrue.Checked)
                txtThongTinGiaTriNoiTru.Text = "True";
        }

        private void radThongTinFalse_CheckedChanged(object sender, EventArgs e)
        {
            if (radThongTinFalse.Checked)
                txtThongTinGiaTriNoiTru.Text = "False";
        }
        private void SetTextWhenAdd(ComboBox cboValue, TextBox txt)
        {
            if (cboValue.SelectedIndex > -1)
            {
                txt.Text += (string.IsNullOrEmpty(txt.Text) ? "" : ",") + cboValue.SelectedValue.ToString().Trim();
            }
        }

       
        private void txtTraKetQuaThamSo_KeyDown(object sender, KeyEventArgs e)
        {
            ControlExtension.SelectAll_CtrlA(sender, e);
        }

        private void txtTraKetQuaNoiTruThamSo_KeyDown(object sender, KeyEventArgs e)
        {
            ControlExtension.SelectAll_CtrlA(sender, e);
        }

        private void FrmCauHinh_His_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommonAppVarsAndFunctions.RefreshHisConfigData();
        }

       

        private void btnHL7Parser_Click(object sender, EventArgs e)
        {
            var f = new frmHL7Parser();
            f.Show();
        }
        private void btnLuuCauHinhThongTin_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin kết nối ?"))
            {
                Save_ThongTin();
            }
        }
        private void btnLuuCauHinhDanhMuc_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin cấu hình danh mục?"))
            {
                foreach (var item in tabDanhMuc.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        _iHisConfig.Update_ThongTinHam(((ucFunctionConfig)item).GetInfo());
                    }
                }
            }
        }
        private void btnLuuCauHinh_ThongTinChiDinh_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin chỉ định?"))
            {
                foreach (var item in tabDanhSachChiDinh.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        _iHisConfig.Update_ThongTinHam(((ucFunctionConfig)item).GetInfo());
                    }
                }
            }
        }
        private void btnLuCauHinhChiDinhKetQua_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin upload kết quả?"))
            {
                foreach (var item in tabUploadKetQua.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        _iHisConfig.Update_ThongTinHam(((ucFunctionConfig)item).GetInfo());
                    }
                }
            }
        }
        private void btnLuuCauHinhThongTinMau_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Cập nhật thông tin lấy thông tin mẫu?"))
            {
                foreach (var item in tabThongTinMau.Controls)
                {
                    if (item is ucFunctionConfig)
                    {
                        _iHisConfig.Update_ThongTinHam(((ucFunctionConfig)item).GetInfo());
                    }
                }
            }
        }
    }
}
