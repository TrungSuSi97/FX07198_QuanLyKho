using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Common.Model;
using TPH.LIS.Configuration.Constants;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Data;

namespace TPH.LIS.Configuration.Repositories.SystemConfig
{
    public class BacteriumAntibioticReposity : IBacteriumAntibioticReposity
    {
        public BacteriumAntibioticReposity() { }
        #region Bacterium
        public bool Insert_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo)
        {
            var strSql = "insert into  [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan (";
            strSql += "\n Maphanloai";
            strSql += "\n,Tenphanloai";
            strSql += "\n,Tenthuonggoi";
            strSql += "\n,Danhphap";
            strSql += "\n,Maphanloaicha";
            strSql += "\n,Donviphanloai";
            strSql += "\n,Thutusapxep";
            strSql += "\n,Gionhap";
            strSql += "\n,Nguoinhap, LoaiKetQua";
            strSql += "\n,GRAM";
            strSql += "\n,ORG_GROUP";
            strSql += "\n,Status";
            strSql += "\n,Common";
            strSql += "\n,Sub_Group";
            strSql += "\n,Genus_Code";
            strSql += "\n,SCT_Code";
            strSql += "\n,SCT_Text";
            strSql += ")";

            strSql += "select ";
            strSql += "\n" + "'" + objInfo.Maphanloai + "'";
            strSql += "\n," + (objInfo.Tenphanloai == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenphanloai) + "'");
            strSql += "\n," + (objInfo.Tenthuonggoi == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenthuonggoi) + "'");
            strSql += "\n," + (objInfo.Danhphap == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Danhphap) + "'");
            strSql += "\n," + (objInfo.Maphanloaicha == null ? "NULL" : "'" + objInfo.Maphanloaicha + "'");
            strSql += "\n," + "'" + objInfo.Donviphanloai.ToString() + "'";
            strSql += "\n," + (objInfo.Thutusapxep < 0 ? "1000" : objInfo.Thutusapxep.ToString());
            strSql += "\n,getdate()";
            strSql += "\n," + (objInfo.Nguoinhap == null ? "NULL" : "'" + objInfo.Nguoinhap + "'");
            strSql += "\n," + objInfo.Loaiketqua;
            strSql += "\n," + (objInfo.Gram == null ? "NULL" : "'" + objInfo.Gram + "'");
            strSql += "\n," + (objInfo.Org_group == null ? "NULL" : "'" + objInfo.Org_group + "'");
            strSql += "\n," + (objInfo.Status == null ? "NULL" : "'" + objInfo.Status + "'");
            strSql += "\n," + (objInfo.Common ? "1" : "0");
            strSql += "\n," + (objInfo.Sub_group == null ? "NULL" : "'" + objInfo.Sub_group + "'");
            strSql += "\n," + (objInfo.Genus_code == null ? "NULL" : "'" + objInfo.Genus_code + "'");
            strSql += "\n," + (objInfo.Sct_code == null ? "NULL" : "'" + objInfo.Sct_code + "'");
            strSql += "\n," + (objInfo.Sct_text == null ? "NULL" : "'" + objInfo.Sct_text + "'");

            if (DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan where Maphanloai = '" + objInfo.Maphanloai + "'"))
            {
                if (objInfo.insertWithMess)
                {
                    CustomMessageBox.MSG_Error_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
                }
                else
                {
                    return Update_dm_xetnghiem_vikhuan(objInfo, objInfo);
                }
            }
            return DataProvider.ExecuteQuery(strSql);
        }

        public bool Update_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo, DM_XETNGHIEM_VIKHUAN objInfoOld)
        {
            string strSql = "Update [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan set";
            strSql += "\n Maphanloai = " + "'" + objInfo.Maphanloai.ToString() + "'";
            strSql += "\n, Tenphanloai = " + (objInfo.Tenphanloai == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenphanloai) + "'");
            strSql += "\n, Tenthuonggoi = " + (objInfo.Tenthuonggoi == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenthuonggoi) + "'");
            strSql += "\n, Danhphap = " + (objInfo.Danhphap == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Danhphap) + "'");
            strSql += "\n, Maphanloaicha = " + (objInfo.Maphanloaicha == null ? "NULL" : "'" + objInfo.Maphanloaicha.ToString() + "'");
            strSql += "\n, Donviphanloai = " + "'" + objInfo.Donviphanloai.ToString() + "'";
            strSql += "\n, Thutusapxep = " + (objInfo.Thutusapxep < 0 ? "1000" : objInfo.Thutusapxep.ToString());
            strSql += "\n, Giosua = getdate()";
            strSql += "\n, Nguoisua = " + (objInfo.Nguoisua == null ? "NULL" : "'" + objInfo.Nguoisua.ToString() + "'");
            strSql += "\n, LoaiKetQua = " + objInfo.Loaiketqua.ToString();
            strSql += "\n, GRAM = " + (objInfo.Gram == null ? "NULL" : "'" + objInfo.Gram + "'");
            strSql += "\n, ORG_GROUP = " + (objInfo.Org_group == null ? "NULL" : "'" + objInfo.Org_group + "'");
            strSql += "\n, Status = " + (objInfo.Status == null ? "NULL" : "'" + objInfo.Status + "'");
            strSql += "\n, Common = " + (objInfo.Common ? "1" : "0");
            strSql += "\n, Sub_Group = " + (objInfo.Sub_group == null ? "NULL" : "'" + objInfo.Sub_group + "'");
            strSql += "\n, Genus_Code = " + (objInfo.Genus_code == null ? "NULL" : "'" + objInfo.Genus_code + "'");
            strSql += "\n, SCT_Code = " + (objInfo.Sct_code == null ? "NULL" : "'" + objInfo.Sct_code + "'");
            strSql += "\n, SCT_Text = " + (objInfo.Sct_text == null ? "NULL" : "'" + objInfo.Sct_text + "'");
            strSql += "\n where Maphanloai = '" + objInfoOld.Maphanloai.ToString() + "'";
            // + ";Update [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan set Maphanloaicha = '" + objInfo.Maphanloai.ToString() + "' where Maphanloaicha =  '" + objInfoOld.Maphanloai.ToString() + "'";
            return DataProvider.ExecuteQuery(strSql);
        }

        public bool Delete_dm_xetnghiem_vikhuan(DM_XETNGHIEM_VIKHUAN objInfo)
        {
            string strSql = "Delete [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan";
            strSql += "\n where Maphanloai = " + "'" + objInfo.Maphanloai.ToString() + "'";
            return DataProvider.ExecuteQuery(strSql);
        }

        private string SQLSelect_Data_dm_xetnghiem_vikhuan(string maphanloai, string MaPhanLoaiCha, string donViPhanLoai)
        {
            string strSql = "select * from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan where 1=1";
            if (!string.IsNullOrEmpty(maphanloai))
                strSql += "\n and  maphanloai = '" + maphanloai + "'";
            if (!string.IsNullOrEmpty(MaPhanLoaiCha))
                strSql += "\n and  MaPhanLoaiCha = '" + MaPhanLoaiCha + "'";
            if (!string.IsNullOrEmpty(donViPhanLoai))
                strSql += "\n and  DonViPhanLoai = '" + donViPhanLoai + "'";
            return strSql;
        }
        private string SQLSelect_Data_dm_xetnghiem_vikhuan_loai(string maphanloai, string maHoViKhuan)
        {
            string strSql = "select * from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan where 1=1";
            if (!string.IsNullOrEmpty(maphanloai))
                strSql += "\n and  maphanloai = '" + maphanloai + "'";
            if (!string.IsNullOrEmpty(maHoViKhuan))
            {
                strSql += "\n and  MaPhanLoaiCha in (select MaPhanLoai from  [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan where MaPhanLoaiCha = '" + maHoViKhuan + "' and DonViPhanLoai = '" + BacteriumCategory.genus.ToString() + "') ";
            }
            strSql += "\n  and DonViPhanLoai = '" + BacteriumCategory.species.ToString() + "'";
            return strSql;
        }
        public DataTable Data_dm_xetnghiem_vikhuan_loai(string maphanloai, string maHoViKhuan)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_vikhuan_loai(maphanloai, maHoViKhuan)).Tables[0];
            return dtData;
        }
        public DataTable Data_dm_xetnghiem_vikhuan(string maphanloai, string MaPhanLoaiCha, string donViPhanLoai)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_vikhuan(maphanloai, MaPhanLoaiCha, donViPhanLoai)).Tables[0];
            return dtData;
        }
        public DataTable Data_dm_xetnghiem_vikhuan(string maphanloai)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_vikhuan(maphanloai, string.Empty, string.Empty)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan(DataGridView dtg, BindingNavigator bv, string maphanloai)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_vikhuan(maphanloai);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string maphanloai)
        {
            DataTable dtData = Data_dm_xetnghiem_vikhuan(maphanloai);
            cbo.DataSource = dtData.Copy();
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }

            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_VIKHUAN Get_Info_dm_xetnghiem_vikhuan(DataRow drInfo)
        {
            DM_XETNGHIEM_VIKHUAN obj = new DM_XETNGHIEM_VIKHUAN();
            obj.Maphanloai = drInfo["maphanloai"].ToString();
            if (!string.IsNullOrEmpty(drInfo["tenphanloai"].ToString()))
                obj.Tenphanloai = drInfo["tenphanloai"].ToString();
            if (!string.IsNullOrEmpty(drInfo["tenthuonggoi"].ToString()))
                obj.Tenthuonggoi = drInfo["tenthuonggoi"].ToString();
            if (!string.IsNullOrEmpty(drInfo["danhphap"].ToString()))
                obj.Danhphap = drInfo["danhphap"].ToString();
            if (!string.IsNullOrEmpty(drInfo["maphanloaicha"].ToString()))
                obj.Maphanloaicha = drInfo["maphanloaicha"].ToString();
            obj.Donviphanloai = drInfo["donviphanloai"].ToString();
            obj.Thutusapxep = int.Parse(drInfo["thutusapxep"].ToString());
            obj.Gionhap = (DateTime)drInfo["gionhap"];
            if (!string.IsNullOrEmpty(drInfo["nguoinhap"].ToString()))
                obj.Nguoinhap = drInfo["nguoinhap"].ToString();
            if (!string.IsNullOrEmpty(drInfo["giosua"].ToString()))
                obj.Giosua = (DateTime)drInfo["giosua"];
            if (!string.IsNullOrEmpty(drInfo["nguoisua"].ToString()))
                obj.Nguoisua = drInfo["nguoisua"].ToString();
            obj.Loaiketqua = int.Parse(drInfo["LoaiKetQua"].ToString());

            return obj;
        }
        public DM_XETNGHIEM_VIKHUAN Get_Info_dm_xetnghiem_vikhuan(string maphanloai)
        {
            DataTable dt = Data_dm_xetnghiem_vikhuan(maphanloai);
            DM_XETNGHIEM_VIKHUAN obj = new DM_XETNGHIEM_VIKHUAN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_vikhuan(dt.Rows[0]);
            }
            return obj;
        }

        public DataTable Get_dm_xetnghiem_vikhuan_loai()
        {
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDM_BCVS_Loai").Tables[0];
        }

        #endregion
        #region Antibiotic
        public bool Insert_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo)
        {
            string strSql = "insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_NHOMKHANGSINH (";
            strSql += "\nManhomkhangsinh";
            strSql += "\n,Tennhomkhangsinh";
            strSql += "\n,Thutuin";
            strSql += "\n,Gionhap";
            strSql += "\n,Nguoinhap";
            strSql += ")";

            strSql += "select ";
            strSql += "\n" + "'" + objInfo.Manhomkhangsinh.ToString() + "'";
            strSql += "\n," + (objInfo.Tennhomkhangsinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennhomkhangsinh) + "'");
            strSql += "\n," + (objInfo.Thutuin < 0 ? "1000" : objInfo.Thutuin.ToString());
            strSql += "\n,getdate()";
            strSql += "\n," + (objInfo.Nguoinhap == null ? "NULL" : "'" + objInfo.Nguoinhap.ToString() + "'");
            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_NHOMKHANGSINH where Manhomkhangsinh =  '" + objInfo.Manhomkhangsinh.ToString() + "'"))
            {

                return DataProvider.ExecuteQuery(strSql);
            }
            else
            {
                if (objInfo.insertWithMess)
                    CustomMessageBox.MSG_Error_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
                return false;
            }
        }
        public bool Update_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo, DM_XETNGHIEM_NHOMKHANGSINH objInfoOld)
        {
            string strSql = "Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_NHOMKHANGSINH set";
            strSql += "\n Manhomkhangsinh = '" + objInfo.Manhomkhangsinh.ToString() + "'";
            strSql += "\n, Tennhomkhangsinh = " + (objInfo.Tennhomkhangsinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tennhomkhangsinh) + "'");
            strSql += "\n, Thutuin = " + (objInfo.Thutuin < 0 ? "1000" : objInfo.Thutuin.ToString());
            strSql += "\n, Giosua = getdate()";
            strSql += "\n, Nguoisua = '" + objInfo.Nguoisua.ToString() + "'";
            strSql += "\nwhere Manhomkhangsinh = '" + objInfoOld.Manhomkhangsinh + "'";
            return DataProvider.ExecuteQuery(strSql);
        }
        public bool Delete_dm_xetnghiem_nhomkhangsinh(DM_XETNGHIEM_NHOMKHANGSINH objInfo)
        {
            string strSql = "Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_NHOMKHANGSINH";
            strSql += "\n where Manhomkhangsinh = '" + objInfo.Manhomkhangsinh.ToString() + "'";
            return DataProvider.ExecuteQuery(strSql);
        }
        private string SQLSelect_Data_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh)
        {
            string strSql = "select * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_NHOMKHANGSINH where 1=1";
            if (!string.IsNullOrEmpty(manhomkhangsinh))
                strSql += "\n and  manhomkhangsinh = " + "'" + manhomkhangsinh + "'";
            return strSql;
        }
        public DataTable Data_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_nhomkhangsinh(manhomkhangsinh)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_nhomkhangsinh(DataGridView dtg, BindingNavigator bv, string manhomkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_nhomkhangsinh(manhomkhangsinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_nhomkhangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string manhomkhangsinh)
        {
            DataTable dtData = Data_dm_xetnghiem_nhomkhangsinh(manhomkhangsinh);
            cbo.DataSource = dtData.Copy();
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }

            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_NHOMKHANGSINH Get_Info_dm_xetnghiem_nhomkhangsinh(DataRow drInfo)
        {
            DM_XETNGHIEM_NHOMKHANGSINH obj = new DM_XETNGHIEM_NHOMKHANGSINH();
            obj.Manhomkhangsinh = drInfo["manhomkhangsinh"].ToString();
            if (!string.IsNullOrEmpty(drInfo["tennhomkhangsinh"].ToString()))
                obj.Tennhomkhangsinh = drInfo["tennhomkhangsinh"].ToString();
            obj.Thutuin = int.Parse(drInfo["thutuin"].ToString());
            obj.Gionhap = (DateTime)drInfo["gionhap"];
            if (!string.IsNullOrEmpty(drInfo["nguoinhap"].ToString()))
                obj.Nguoinhap = drInfo["nguoinhap"].ToString();
            if (!string.IsNullOrEmpty(drInfo["giosua"].ToString()))
                obj.Giosua = (DateTime)drInfo["giosua"];
            obj.Nguoisua = drInfo["nguoisua"].ToString();
            return obj;
        }
        public DM_XETNGHIEM_NHOMKHANGSINH Get_Info_dm_xetnghiem_nhomkhangsinh(string manhomkhangsinh)
        {
            DataTable dt = Data_dm_xetnghiem_nhomkhangsinh(manhomkhangsinh);
            DM_XETNGHIEM_NHOMKHANGSINH obj = new DM_XETNGHIEM_NHOMKHANGSINH();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_nhomkhangsinh(dt.Rows[0]);
            }
            return obj;
        }

        public bool Insert_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo)
        {
            var strSql = "insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH (";
            strSql += "\nMakhangsinh";
            strSql += "\n,Manhomkhangsinh";
            strSql += "\n,Tenkhangsinh";
            strSql += "\n,Cantren";
            strSql += "\n,Canduoi";
            strSql += "\n,Sapxep";
            strSql += "\n,Gionhap, WHONETVersion, WHONETID, GuideLineType";
            strSql += "\n,Nguoinhap";
            strSql += "\n,CLSI_DI,CLSI_DS,CLSI_DR,CLSI_MIC_R,CLSI_MIC_S";
            strSql += "\n,Potency";
            strSql += "\n,WHON4_CODE,WHO_CODE,DIN_CODE,JAC_CODE,USER_CODE,GUIDELINES,ABX_NUMBER,BETALACTAM";
            strSql += "\n,SUBCLASS,PROF_CLASS,HUMAN,VETERINARY,ANIMAL_GP,WHO_IMPORT,GuideLineYear";
            strSql += ")";

            strSql += "select ";
            strSql += "\n" + "'" + objInfo.Makhangsinh + "'";
            strSql += "\n," + "'" + objInfo.Manhomkhangsinh + "'";
            strSql += "\n," + (objInfo.Tenkhangsinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenkhangsinh) + "'");
            strSql += "\n," + (objInfo.Cantren == null ? "NULL" : objInfo.Cantren.ToString());
            strSql += "\n," + (objInfo.Canduoi == null ? "NULL" : objInfo.Canduoi.ToString());
            strSql += "\n," + (objInfo.Sapxep < 0 ? "1000" : objInfo.Sapxep.ToString());
            strSql += "\n,getdate(), " + objInfo.Whonetversion;
            strSql += "\n, " + (objInfo.Whonetid == null ? "NULL" : "'" + objInfo.Whonetid + "'");
            strSql += "\n, " + (objInfo.Guidelinetype == null ? "''" : "'" + objInfo.Guidelinetype + "'");
            strSql += "\n," + (objInfo.Nguoinhap == null ? "NULL" : "'" + objInfo.Nguoinhap + "'");
            strSql += "\n," + (objInfo.Clsi_di == null ? "NULL" : "'" + objInfo.Clsi_di + "'");
            strSql += "\n," + (objInfo.Clsi_ds == null ? "NULL" : "'" + objInfo.Clsi_ds + "'");
            strSql += "\n," + (objInfo.Clsi_dr == null ? "NULL" : "'" + objInfo.Clsi_dr + "'");
            strSql += "\n," + (objInfo.Clsi_mic_r == null ? "NULL" : "'" + objInfo.Clsi_mic_r + "'");
            strSql += "\n," + (objInfo.Clsi_mic_s == null ? "NULL" : "'" + objInfo.Clsi_mic_s + "'");
            strSql += "\n," + (objInfo.Potency == null ? "''" : "'" + objInfo.Potency + "'");
            strSql += "\n," + (objInfo.Whon4_code == null ? "NULL" : "'" + objInfo.Whon4_code + "'");
            strSql += "\n," + (objInfo.Who_code == null ? "NULL" : "'" + objInfo.Who_code + "'");
            strSql += "\n," + (objInfo.Din_code == null ? "NULL" : "'" + objInfo.Din_code + "'");
            strSql += "\n," + (objInfo.Jac_code == null ? "NULL" : "'" + objInfo.Jac_code + "'");
            strSql += "\n," + (objInfo.User_code == null ? "NULL" : "'" + objInfo.User_code + "'");
            strSql += "\n," + (objInfo.Guidelines == null ? "NULL" : "'" + objInfo.Guidelines + "'");
            strSql += "\n," + (objInfo.Abx_number == null ? "NULL" : objInfo.Abx_number.ToString());
            strSql += "\n," + (objInfo.Betalactam ? "1" : "0");
            strSql += "\n," + (objInfo.Subclass == null ? "NULL" : "'" + objInfo.Subclass + "'");
            strSql += "\n," + (objInfo.Prof_class == null ? "NULL" : "'" + objInfo.Prof_class + "'");
            strSql += "\n," + (objInfo.Human ? "1" : "0");
            strSql += "\n," + (objInfo.Veterinary ? "1" : "0");
            strSql += "\n," + (objInfo.Animal_gp ? "1" : "0");
            strSql += "\n," + (objInfo.Who_import ? "1" : "0");
            strSql += "\n," + (objInfo.Guidelineyear);

            //Kiểm tra nếu khong có thì cho import vào
            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH where Makhangsinh =  '"
                + objInfo.Makhangsinh + "' AND GuideLineType = '" + objInfo.Guidelinetype + "' AND Potency = '" + objInfo.Potency + "'"))
            {
                if (string.IsNullOrEmpty(objInfo.OldWHONetCode)) return DataProvider.ExecuteQuery(strSql);
                if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH where Makhangsinh =  '"
                                               + objInfo.OldWHONetCode + "' AND GuideLineType = '"
                                               + objInfo.Guidelinetype + "' AND Potency = '" +
                                               objInfo.Potency + "'"))
                    return DataProvider.ExecuteQuery(strSql);
                var objOld = objInfo.Copy();
                objOld.Makhangsinh = objOld.OldWHONetCode;
                return Update_dm_xetnghiem_khangsinh(objInfo, objOld);
            }
            else
            {
                if (objInfo.insertWithMess)
                    CustomMessageBox.MSG_Error_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
                return false;
            }
        }
        public bool Update_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo, DM_XETNGHIEM_KHANGSINH objInfoOld)
        {
            string strSql = "Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH set";
            strSql += "\n Makhangsinh = " + "'" + objInfo.Makhangsinh.ToString() + "'";
            strSql += "\n, Manhomkhangsinh = " + "'" + objInfo.Manhomkhangsinh.ToString() + "'";
            strSql += "\n, Tenkhangsinh = " + (objInfo.Tenkhangsinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenkhangsinh) + "'");
            strSql += "\n, Cantren = " + (objInfo.Cantren == null ? "NULL" : objInfo.Cantren.ToString());
            strSql += "\n, Canduoi = " + (objInfo.Canduoi == null ? "NULL" : objInfo.Canduoi.ToString());
            strSql += "\n, Sapxep = " + (objInfo.Sapxep < 0 ? "1000" : objInfo.Sapxep.ToString());
            strSql += "\n, Gionhap = " + "'" + objInfo.Gionhap.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            strSql += "\n, Nguoinhap = " + (objInfo.Nguoinhap == null ? "NULL" : "'" + objInfo.Nguoinhap.ToString() + "'");
            strSql += "\n, Giosua = getdate()";
            strSql += "\n, Nguoisua = " + (objInfo.Nguoisua == null ? "NULL" : "'" + objInfo.Nguoisua.ToString() + "'");
            strSql += "\n, WHONETVersion = " + (objInfo.Whonetversion < 0 ? "0" : objInfo.Whonetversion.ToString());
            strSql += "\n, GuideLineType = " + (objInfo.Guidelinetype == null ? "NULL" : "'" + objInfo.Guidelinetype.ToString() + "'");
            strSql += "\n, Potency = " + (objInfo.Potency == null ? "NULL" : "'" + objInfo.Potency.ToString() + "'");
            strSql += "\n, WHON4_CODE = " + (objInfo.Whon4_code == null ? "NULL" : "'" + objInfo.Whon4_code + "'");
            strSql += "\n, WHO_CODE = " + (objInfo.Who_code == null ? "NULL" : "'" + objInfo.Who_code + "'");
            strSql += "\n, DIN_CODE = " + (objInfo.Din_code == null ? "NULL" : "'" + objInfo.Din_code + "'");
            strSql += "\n, JAC_CODE = " + (objInfo.Jac_code == null ? "NULL" : "'" + objInfo.Jac_code + "'");
            strSql += "\n, USER_CODE = " + (objInfo.User_code == null ? "NULL" : "'" + objInfo.User_code + "'");
            strSql += "\n, GUIDELINES = " + (objInfo.Guidelines == null ? "NULL" : "'" + objInfo.Guidelines + "'");
            strSql += "\n, ABX_NUMBER = " + (objInfo.Abx_number == null ? "NULL" : objInfo.Abx_number.ToString());
            strSql += "\n, BETALACTAM = " + (objInfo.Betalactam ? "1" : "0");
            strSql += "\n, SUBCLASS = " + (objInfo.Subclass == null ? "NULL" : "'" + objInfo.Subclass + "'");
            strSql += "\n, PROF_CLASS = " + (objInfo.Prof_class == null ? "NULL" : "'" + objInfo.Prof_class + "'");
            strSql += "\n, HUMAN = " + (objInfo.Human ? "1" : "0");
            strSql += "\n, VETERINARY = " + (objInfo.Veterinary ? "1" : "0");
            strSql += "\n, ANIMAL_GP = " + (objInfo.Animal_gp ? "1" : "0");
            strSql += "\n, WHO_IMPORT = " + (objInfo.Who_import ? "1" : "0");
            strSql += "\n, GuideLineYear = " + (objInfo.Guidelineyear);

            strSql += "\nwhere Makhangsinh =  '" + objInfoOld.Makhangsinh.ToString() + "'"
                    + " AND GuideLineType = '" + objInfo.Guidelinetype + "' AND Potency = '" + objInfo.Potency + "'";
            return DataProvider.ExecuteQuery(strSql);
        }
        public bool Delete_dm_xetnghiem_khangsinh(DM_XETNGHIEM_KHANGSINH objInfo)
        {
            string strSql = "Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH";
            strSql += "\n where Makhangsinh = '" + objInfo.Makhangsinh.ToString() + "'";
            return DataProvider.ExecuteQuery(strSql);
        }
        private string SQLSelect_Data_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh)
        {
            string strSql = "select ks.*, n.TenNhomKhangSinh, n.ThuTuIn as ThuTuInNhom from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH ks left join [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_NHOMKHANGSINH n on ks.MaNhomKhangSinh = n.MaNhomKhangSinh where 1=1";
            if (!string.IsNullOrEmpty(makhangsinh))
                strSql += "\n and  ks.makhangsinh = '" + makhangsinh + "'";
            if (!string.IsNullOrEmpty(manhomkhangsinh))
                strSql += "\n and  ks.manhomkhangsinh = '" + manhomkhangsinh + "'";
            return strSql;
        }
        public DataTable Data_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_khangsinh(makhangsinh, manhomkhangsinh)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khangsinh(DataGridView dtg, BindingNavigator bv, string makhangsinh, string manhomkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_khangsinh(makhangsinh, manhomkhangsinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string makhangsinh, string manhomkhangsinh)
        {
            DataTable dtData = Data_dm_xetnghiem_khangsinh(makhangsinh, manhomkhangsinh);
            cbo.DataSource = dtData.Copy();
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }

            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_KHANGSINH Get_Info_dm_xetnghiem_khangsinh(DataRow drInfo)
        {
            DM_XETNGHIEM_KHANGSINH obj = new DM_XETNGHIEM_KHANGSINH();
            obj.Makhangsinh = drInfo["makhangsinh"].ToString();
            obj.Manhomkhangsinh = drInfo["manhomkhangsinh"].ToString();
            if (!string.IsNullOrEmpty(drInfo["tenkhangsinh"].ToString()))
                obj.Tenkhangsinh = drInfo["tenkhangsinh"].ToString();
            if (!string.IsNullOrEmpty(drInfo["cantren"].ToString()))
                obj.Cantren = float.Parse(drInfo["cantren"].ToString());
            if (!string.IsNullOrEmpty(drInfo["canduoi"].ToString()))
                obj.Canduoi = float.Parse(drInfo["canduoi"].ToString());
            obj.Sapxep = int.Parse(drInfo["sapxep"].ToString());
            obj.Gionhap = (DateTime)drInfo["gionhap"];
            if (!string.IsNullOrEmpty(drInfo["nguoinhap"].ToString()))
                obj.Nguoinhap = drInfo["nguoinhap"].ToString();
            if (!string.IsNullOrEmpty(drInfo["giosua"].ToString()))
                obj.Giosua = (DateTime)drInfo["giosua"];
            if (!string.IsNullOrEmpty(drInfo["nguoisua"].ToString()))
                obj.Nguoisua = drInfo["nguoisua"].ToString();
            if (!string.IsNullOrEmpty(drInfo["WHONetVersion"].ToString()))
                obj.Whonetversion = int.Parse(drInfo["WHONetVersion"].ToString());
            if (!string.IsNullOrEmpty(drInfo["GuideLine"].ToString()))
                obj.Guidelinetype = drInfo["GuideLine"].ToString();
            if (!string.IsNullOrEmpty(drInfo["WHONETID"].ToString()))
                obj.Whonetid = drInfo["WHONETID"].ToString();
            return obj;
        }
        public DM_XETNGHIEM_KHANGSINH Get_Info_dm_xetnghiem_khangsinh(string makhangsinh, string manhomkhangsinh, string guideLineType, string potency)
        {
            DataTable dt = Data_dm_xetnghiem_khangsinh(makhangsinh, manhomkhangsinh);
            dt = dt.AsEnumerable().Where(x => x.Field<string>("GuideLineType").Equals(guideLineType, StringComparison.OrdinalIgnoreCase)
                                    && x.Field<string>("Potency").Equals(potency, StringComparison.OrdinalIgnoreCase)).CopyToDataTable();
            DM_XETNGHIEM_KHANGSINH obj = new DM_XETNGHIEM_KHANGSINH();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_xetnghiem_khangsinh(dt.Rows[0]);
            }
            return obj;
        }

        #endregion
        #region Bacterium-Antibiotic
        public bool Insert_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.Append("insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VIKHUAN_KHANGSINH (");
            sqlQuery.Append("\nMavikhuan");
            sqlQuery.Append("\n,Makhangsinh");
            sqlQuery.Append("\n,Cannhay");
            sqlQuery.Append("\n,Cankhang");
            sqlQuery.Append("\n,Cantrunggiantren");
            sqlQuery.Append("\n,Cantrunggianduoi");
            sqlQuery.Append("\n,Donvitinh");
            sqlQuery.Append("\n,Gionhap");
            sqlQuery.Append("\n,Nguoinhap");
            sqlQuery.Append("\n,Hisid");
            sqlQuery.Append("\n,Whonetid");
            sqlQuery.Append("\n,Guideline");
            sqlQuery.Append("\n,Mabangkhangsinh");
            sqlQuery.Append("\n,Kythuat");
            sqlQuery.Append("\n,Potency");
            sqlQuery.Append("\n,SiteInfection");
            sqlQuery.Append("\n,BreakPoint_Type");
            sqlQuery.Append("\n,Host");
            sqlQuery.Append("\n,Ref_Table");
            sqlQuery.Append("\n,Ref_Seq");
            sqlQuery.Append("\n,WHON5_TEST");
            sqlQuery.Append("\n,GuideLineYear");
            sqlQuery.Append(")");
            if (string.IsNullOrEmpty(objInfo.Mabangkhangsinh) && !string.IsNullOrEmpty(objInfo.Makhangsinh))
            {
                sqlQuery.Append("select ");
                sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'");
                sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'");
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Cannhay == null ? "NULL" : objInfo.Cannhay.ToString()));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Cankhang == null ? "NULL" : objInfo.Cankhang.ToString()));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Cantrunggiantren == null ? "NULL" : objInfo.Cantrunggiantren.ToString()));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Cantrunggianduoi == null ? "NULL" : objInfo.Cantrunggianduoi.ToString()));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Donvitinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Donvitinh.ToString()) + "'"));
                sqlQuery.Append("\n ,getdate()");
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Nguoinhap == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoinhap.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Hisid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Hisid.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Whonetid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Whonetid.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Guideline == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Guideline.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Mabangkhangsinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Mabangkhangsinh.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Potency == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Potency.ToString()) + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Siteinfection == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Siteinfection.ToString()) + "'"));

                sqlQuery.AppendFormat("\n ,{0}", ("'" + objInfo.Breakpoint_type + "'"));
                sqlQuery.AppendFormat("\n ,{0}", ("'" + objInfo.Host + "'"));
                sqlQuery.AppendFormat("\n ,{0}", ("'" + objInfo.Ref_table + "'"));
                sqlQuery.AppendFormat("\n ,{0}", ("'" + objInfo.Ref_seq + "'"));
                sqlQuery.AppendFormat("\n ,{0}", ("'" + objInfo.Whon5_test + "'"));
                sqlQuery.AppendFormat("\n ,{0}", (objInfo.Guidelineyear));

                if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VIKHUAN_KHANGSINH where Mavikhuan = '" +
                    objInfo.Mavikhuan + "'" +
                    " and Makhangsinh = '" + objInfo.Makhangsinh + "'" +
                    " and Kythuat =  " + (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat) + "'") +
                    " and GuideLine =  " + (objInfo.Guideline == null ? "''" : "'" + objInfo.Guideline + "'") +
                    " and SiteInfection = '" + objInfo.Siteinfection + "'" +
                    " and Potency = '" + objInfo.Potency + "'"))
                {
                    if (DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan where MaPhanLoai = '" + objInfo.Mavikhuan + "'")
                    && DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH where MaKhangSinh = '" + objInfo.Makhangsinh + "'"))
                        return DataProvider.ExecuteQuery(sqlQuery.ToString());
                    else
                        return false;
                }
                else
                {
                    if (objInfo.insertWithMess)
                        CustomMessageBox.MSG_Error_OK("Kháng sinh cho Loài đã có!\nHãy chọn mã khác.");
                    return Update_dm_xetnghiem_vikhuan_khangsinh(objInfo);
                }
            }
            else if (!string.IsNullOrEmpty(objInfo.Mabangkhangsinh) && string.IsNullOrEmpty(objInfo.Makhangsinh))
            {
                sqlQuery.AppendFormat("\nselect '{0}' as Mavikhuan", objInfo.Mavikhuan);
                sqlQuery.Append("\n,ct.Makhangsinh");
                sqlQuery.Append("\n,null as Cannhay");
                sqlQuery.Append("\n,null as Cankhang");
                sqlQuery.Append("\n,null as Cantrunggiantren");
                sqlQuery.Append("\n,null as Cantrunggianduoi");
                sqlQuery.Append("\n,null as  Donvitinh");
                sqlQuery.Append("\n,getdate() as Gionhap");
                sqlQuery.AppendFormat("\n,'{0}' as Nguoinhap", objInfo.Nguoinhap);
                sqlQuery.Append("\n,ks.Hisid");
                sqlQuery.Append("\n,ks.Whonetid");
                sqlQuery.Append("\n,ks.Guidelines");
                sqlQuery.Append("\n,ct.MaBoKhangSinh as Mabangkhangsinh");
                sqlQuery.AppendFormat("\n ,{0} as Kythuat", (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'"));
                sqlQuery.AppendFormat("\n from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET ct inner join [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH ks " +
                                      "on ct.MaKhangSinh = ks.MaKhangSinh where ct.MaBoKhangSinh = '{0}' " +
                                      "and not exists (select top 1 ksd.MaKhangSinh from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VIKHUAN_KHANGSINH ksd " +
                                      "where ksd.MaKhangSinh = ks.MaKhangSinh and ksd.MaViKhuan = '{1}' and ksd.KyThuat = {2}) "
                    , objInfo.Mabangkhangsinh, objInfo.Mavikhuan
                    , (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'"));
                return DataProvider.ExecuteQuery(sqlQuery.ToString());
            }
            return false;
        }

        public bool Update_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo)
        {
            var sb = new StringBuilder();
            sb.Append("Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VIKHUAN_KHANGSINH set");
            sb.AppendFormat("\n Mavikhuan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'");
            sb.AppendFormat("\n, Makhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'");
            sb.AppendFormat("\n, Kythuat = {0}", (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'"));
            sb.AppendFormat("\n, Cannhay = {0}", (objInfo.Cannhay == null ? "NULL" : objInfo.Cannhay.ToString()));
            sb.AppendFormat("\n, Cankhang = {0}", (objInfo.Cankhang == null ? "NULL" : objInfo.Cankhang.ToString()));
            sb.AppendFormat("\n, Cantrunggiantren = {0}", (objInfo.Cantrunggiantren == null ? "NULL" : objInfo.Cantrunggiantren.ToString()));
            sb.AppendFormat("\n, Cantrunggianduoi = {0}", (objInfo.Cantrunggianduoi == null ? "NULL" : objInfo.Cantrunggianduoi.ToString()));
            sb.AppendFormat("\n, Donvitinh = {0}", (objInfo.Donvitinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Donvitinh.ToString()) + "'"));
            sb.Append("\n, Giosua = getdate()");
            sb.AppendFormat("\n, Nguoisua = {0}", (objInfo.Nguoisua == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoisua.ToString()) + "'"));
            sb.AppendFormat("\n, Hisid = {0}", (objInfo.Hisid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Hisid.ToString()) + "'"));
            sb.AppendFormat("\n, Whonetid = {0}", (objInfo.Whonetid == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Whonetid.ToString()) + "'"));
            sb.AppendFormat("\n, Guideline = {0}", (objInfo.Guideline == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Guideline.ToString()) + "'"));
            sb.AppendFormat("\n, Mabangkhangsinh = {0}", (objInfo.Mabangkhangsinh == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Mabangkhangsinh) + "'"));

            sb.AppendFormat("\n ,BreakPoint_Type = {0}", (objInfo.Breakpoint_type == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Breakpoint_type) + "'"));
            sb.AppendFormat("\n ,Host = {0}", (objInfo.Host == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Host) + "'"));
            sb.AppendFormat("\n ,Ref_Table = {0}", (objInfo.Ref_table == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Ref_table) + "'"));
            sb.AppendFormat("\n ,Ref_Seq = {0}", (objInfo.Ref_seq == null ? "NULL" : objInfo.Ref_seq.ToString()));
            sb.AppendFormat("\n ,WHON5_TEST = {0}", (objInfo.Whon5_test == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Whon5_test) + "'"));
            sb.AppendFormat("\n ,GuideLineYear = {0}", (objInfo.Guidelineyear));

            sb.Append("\nwhere Mavikhuan =  '" + Utilities.ConvertSqlString(objInfo.Mavikhuan)
                + "' and Makhangsinh = '" + Utilities.ConvertSqlString(objInfo.Makhangsinh)
                + "' and Kythuat =  " + (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat) + "'")
                + " and GuideLine =  " + (objInfo.Guideline == null ? "''" : "'" + objInfo.Guideline + "'")
                + " and SiteInfection = '" + objInfo.Siteinfection + "'"
                + " and Potency = '" + objInfo.Potency + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_xetnghiem_vikhuan_khangsinh(DM_XETNGHIEM_VIKHUAN_KHANGSINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VIKHUAN_KHANGSINH");
            sb.AppendFormat("\n where Mavikhuan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'");
            sb.AppendFormat("\n and Makhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'");
            sb.AppendFormat("\n and Kythuat = {0}", (objInfo.Kythuat == null ? "'DISK'" : "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'"));
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public DataTable Get_DM_Site_INF()
        {
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selGet_DM_Site_INF", null).Tables[0];
        }

        private string SQLSelect_Data_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat)
        {
            string strSql = "select ksd.*, vk.MaPhanLoai, vk.TenPhanLoai, vk.DanhPhap, ks.TenKhangSinh from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VIKHUAN_KHANGSINH ksd left join [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan vk  on ksd.mavikhuan = vk.MaPhanLoai";
            strSql += "\nleft join [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH ks on ks.makhangsinh = ksd.makhangsinh";
            strSql += "\nwhere 1=1";
            if (!string.IsNullOrEmpty(mavikhuan))
                strSql += "\n and  ksd.mavikhuan = '" + mavikhuan + "'";
            if (!string.IsNullOrEmpty(makhangsinh))
                strSql += "\n and  ksd.makhangsinh = '" + makhangsinh + "'";
            if (!string.IsNullOrEmpty(kythuat))
                strSql += "\n and  ksd.Kythuat = '" + kythuat + "'";
            return strSql;
        }
        public DataTable Data_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_vikhuan_khangsinh(mavikhuan, makhangsinh, kythuat)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan_khangsinh(DataGridView dtg, BindingNavigator bv
            , string mavikhuan, string makhangsinh, string kythuat)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_vikhuan_khangsinh(mavikhuan, makhangsinh, kythuat);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_vikhuan_khangsinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName
            , string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex
            , string mavikhuan, string makhangsinh, string kythuat)
        {
            DataTable dtData = Data_dm_xetnghiem_vikhuan_khangsinh(mavikhuan, makhangsinh, kythuat);
            cbo.DataSource = dtData.Copy();
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }

            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_VIKHUAN_KHANGSINH Get_Info_dm_xetnghiem_vikhuan_khangsinh(string mavikhuan, string makhangsinh, string kythuat)
        {
            DataTable dt = Data_dm_xetnghiem_vikhuan_khangsinh(mavikhuan, makhangsinh, kythuat);
            DM_XETNGHIEM_VIKHUAN_KHANGSINH obj = new DM_XETNGHIEM_VIKHUAN_KHANGSINH();
            if (dt.Rows.Count > 0)
            {
                obj.Mavikhuan = StringConverter.ToString(dt.Rows[0]["mavikhuan"]);
                obj.Makhangsinh = StringConverter.ToString(dt.Rows[0]["makhangsinh"]);
                obj.Kythuat = StringConverter.ToString(dt.Rows[0]["kythuat"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["cannhay"].ToString()))
                    obj.Cannhay = NumberConverter.To<float>(dt.Rows[0]["cannhay"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["cankhang"].ToString()))
                    obj.Cankhang = NumberConverter.To<float>(dt.Rows[0]["cankhang"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["cantrunggiantren"].ToString()))
                    obj.Cantrunggiantren = NumberConverter.To<float>(dt.Rows[0]["cantrunggiantren"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["cantrunggianduoi"].ToString()))
                    obj.Cantrunggianduoi = NumberConverter.To<float>(dt.Rows[0]["cantrunggianduoi"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["donvitinh"].ToString()))
                    obj.Donvitinh = StringConverter.ToString(dt.Rows[0]["donvitinh"]);
                obj.Gionhap = (DateTime)dt.Rows[0]["gionhap"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoinhap"].ToString()))
                    obj.Nguoinhap = StringConverter.ToString(dt.Rows[0]["nguoinhap"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["giosua"].ToString()))
                    obj.Giosua = (DateTime)dt.Rows[0]["giosua"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoisua"].ToString()))
                    obj.Nguoisua = StringConverter.ToString(dt.Rows[0]["nguoisua"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["hisid"].ToString()))
                    obj.Hisid = StringConverter.ToString(dt.Rows[0]["hisid"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["whonetid"].ToString()))
                    obj.Whonetid = StringConverter.ToString(dt.Rows[0]["whonetid"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["guideline"].ToString()))
                    obj.Guideline = StringConverter.ToString(dt.Rows[0]["guideline"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["mabangkhangsinh"].ToString()))
                    obj.Mabangkhangsinh = StringConverter.ToString(dt.Rows[0]["mabangkhangsinh"]);

            }
            return obj;
        }
        #endregion
        #region DaiThe
        public bool Insert_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            string sqlQuery = "insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE (";
            sqlQuery += "\nMakhaosat";
            sqlQuery += "\n,Tenkhaosat";
            sqlQuery += "\n,Makhaosatcon";
            sqlQuery += "\n,Khaosatprofile";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n" + "'" + objInfo.Makhaosat.ToString() + "'";
            sqlQuery += "\n," + (objInfo.Tenkhaosat == null ? "NULL" : "N'" + objInfo.Tenkhaosat.ToString() + "'");
            sqlQuery += "\n," + "'" + objInfo.Makhaosatcon.ToString() + "'";
            sqlQuery += "\n," + (bool.Parse(objInfo.Khaosatprofile.ToString()) ? "1" : "0");
            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE where Makhaosat =  " + "'" + objInfo.Makhaosat.ToString() + "'"))
            {
                return DataProvider.ExecuteQuery(sqlQuery);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
                return false;
            }
        }

        public bool Update_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo, DM_XETNGHIEM_KHAOSATDAITHE objInfoOld)
        {
            string sqlQuery = "Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE set";
            sqlQuery += "\n Makhaosat = " + "'" + objInfo.Makhaosat.ToString() + "'";
            sqlQuery += "\n, Tenkhaosat = " + (objInfo.Tenkhaosat == null ? "NULL" : "N'" + objInfo.Tenkhaosat.ToString() + "'");
            sqlQuery += "\n, Makhaosatcon = " + "'" + objInfo.Makhaosatcon.ToString() + "'";
            sqlQuery += "\n, Khaosatprofile = " + (bool.Parse(objInfo.Khaosatprofile.ToString()) ? "1" : "0");
            sqlQuery += "\nwhere Makhaosat =  " + "'" + objInfoOld.Makhaosat.ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_dm_xetnghiem_khaosatdaithe(DM_XETNGHIEM_KHAOSATDAITHE objInfo)
        {
            string sqlQuery = "Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE";
            sqlQuery += "\n where Makhaosat = " + "'" + objInfo.Makhaosat.ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_dm_xetnghiem_khaosatdaithe(string makhaosat)
        {
            string strSql = "select * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE where 1=1";
            if (!string.IsNullOrEmpty(makhaosat))
                strSql += "\n and  makhaosat = " + "'" + makhaosat + "'";
            return strSql;
        }
        public DataTable Data_dm_xetnghiem_khaosatdaithe(string makhaosat)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_khaosatdaithe(makhaosat)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe(DataGridView dtg, BindingNavigator bv, string makhaosat)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_khaosatdaithe(makhaosat);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string makhaosat)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_dm_xetnghiem_khaosatdaithe(makhaosat);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_KHAOSATDAITHE Get_Info_dm_xetnghiem_khaosatdaithe(string makhaosat)
        {
            DataTable dt = Data_dm_xetnghiem_khaosatdaithe(makhaosat);
            DM_XETNGHIEM_KHAOSATDAITHE obj = new DM_XETNGHIEM_KHAOSATDAITHE();
            if (dt.Rows.Count > 0)

            {
                obj.Makhaosat = dt.Rows[0]["makhaosat"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenkhaosat"].ToString()))
                    obj.Tenkhaosat = dt.Rows[0]["tenkhaosat"].ToString();
                obj.Makhaosatcon = dt.Rows[0]["makhaosatcon"].ToString();
                obj.Khaosatprofile = (bool)dt.Rows[0]["khaosatprofile"];
            }
            return obj;
        }


        public bool Insert_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo)
        {
            string sqlQuery = "insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE_KETQUA (";
            sqlQuery += "\nMakhaosat";
            sqlQuery += "\n,Ketquakhaosat";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n" + "'" + objInfo.Makhaosat.ToString() + "'";
            sqlQuery += "\n," + (objInfo.Ketquakhaosat == null ? "NULL" : "N'" + objInfo.Ketquakhaosat.ToString() + "'");
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Update_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo, DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfoOld)
        {
            string sqlQuery = "Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE_KETQUA set";
            sqlQuery += "\n Makhaosat = " + "'" + objInfo.Makhaosat.ToString() + "'";
            sqlQuery += "\n, Ketquakhaosat = " + (objInfo.Ketquakhaosat == null ? "NULL" : "N'" + objInfo.Ketquakhaosat.ToString() + "'");
            sqlQuery += "\nwhere Autoid =  " + objInfo.Autoid.ToString();
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_dm_xetnghiem_khaosatdaithe_ketqua(DM_XETNGHIEM_KHAOSATDAITHE_KETQUA objInfo)
        {
            string sqlQuery = "Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE_KETQUA";
            sqlQuery += "\n where Autoid = " + objInfo.Autoid.ToString();
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_dm_xetnghiem_khaosatdaithe_ketqua(string autoid, string makhaosat)
        {
            string strSql = "select * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHAOSATDAITHE_KETQUA where 1=1 ";
            if (!string.IsNullOrEmpty(makhaosat))
                strSql += string.Format("\nand Makhaosat ='{0}'", makhaosat);
            if (!string.IsNullOrEmpty(autoid))
                strSql += "\nand autoid = " + autoid;
            return strSql;
        }
        public DataTable Data_dm_xetnghiem_khaosatdaithe_ketqua(string autoid, string makhaosat)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_khaosatdaithe_ketqua(autoid, makhaosat)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(DataGridView dtg, BindingNavigator bv, string autoid, string makhaosat)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_khaosatdaithe_ketqua(autoid, makhaosat);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khaosatdaithe_ketqua(CustomComboBox cbo, string _ValueColumn
            , string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt
            , int LinkColumnIndex, string autoid, string makhaosat)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_dm_xetnghiem_khaosatdaithe_ketqua(autoid, makhaosat);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_KHAOSATDAITHE_KETQUA Get_Info_dm_xetnghiem_khaosatdaithe_ketqua(string autoid)
        {
            DataTable dt = Data_dm_xetnghiem_khaosatdaithe_ketqua(autoid, string.Empty);
            DM_XETNGHIEM_KHAOSATDAITHE_KETQUA obj = new DM_XETNGHIEM_KHAOSATDAITHE_KETQUA();
            if (dt.Rows.Count > 0)

            {
                obj.Autoid = int.Parse(dt.Rows[0]["autoid"].ToString());
                obj.Makhaosat = dt.Rows[0]["makhaosat"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketquakhaosat"].ToString()))
                    obj.Ketquakhaosat = dt.Rows[0]["ketquakhaosat"].ToString();
            }
            return obj;
        }




        #endregion
        #region [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_khangsinh_bo_chitiet
        public BaseModel Insert_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo)
        {
            var sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET (");
            sqlQuery.Append("\nMabokhangsinh");
            sqlQuery.Append("\n,Makhangsinh");
            sqlQuery.Append("\n,MaViKhuan");
            sqlQuery.Append("\n,KyThuat");
            sqlQuery.Append("\n,GuideLine");
            sqlQuery.Append("\n,CanNhay");
            sqlQuery.Append("\n,CanKhang");
            sqlQuery.Append("\n,CanTrungGianTren");
            sqlQuery.Append("\n,CanTrungGianDuoi");
            sqlQuery.Append("\n,GioNhap");
            sqlQuery.Append("\n,NguoiNhap");
            sqlQuery.Append("\n,Potency");
            sqlQuery.Append("\n,SiteInfection");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", "'" + Utilities.ConvertSqlString(objInfo.Guideline.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", objInfo.Cannhay == null ? "NULL" : objInfo.Cannhay.ToString());
            sqlQuery.AppendFormat("\n ,{0}", objInfo.Cankhang == null ? "NULL" : objInfo.Cankhang.ToString());
            sqlQuery.AppendFormat("\n ,{0}", objInfo.Cantrunggiantren == null ? "NULL" : objInfo.Cantrunggiantren.ToString());
            sqlQuery.AppendFormat("\n ,{0}", objInfo.Cantrunggianduoi == null ? "NULL" : objInfo.Cantrunggianduoi.ToString());
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Gionhap == null ? "NULL" : "'" + objInfo.Gionhap.ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Nguoinhap == null ? "NULL" : "'" + objInfo.Nguoinhap.ToString() + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Potency == null ? "''" : "'" + objInfo.Potency.ToString() + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Siteinfection == null ? "''" : "'" + objInfo.Siteinfection.ToString() + "'"));

            //if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET where Mabokhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'"
            //    + " and Makhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString())
            //    + "'"))
            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET where Mabokhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString())
                    + "'"
                    + " and Makhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh) + "'"
                    + " and MaViKhuan =  " + "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan) + "'"
                    + " and KyThuat =  " + "'" + Utilities.ConvertSqlString(objInfo.Kythuat) + "'"
                    + " and GuideLine =  " + "'" + Utilities.ConvertSqlString(objInfo.Guideline) + "'"
                    + " and SiteInfection =  " + "'" + Utilities.ConvertSqlString(objInfo.Siteinfection) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = 0,
                    Name = string.Empty
                };
                //if (string.IsNullOrEmpty(objInfo.SiteInfection))
                //{
                //    return new BaseModel()
                //    {
                //        Id = -1,
                //        Name = string.Format("Kháng sinh đã được khai báo trước!")
                //    };
                //}
                //else
                //{
                //    return new BaseModel()
                //    {
                //        Id = -1,
                //        Name = string.Format("Kháng sinh: {0}, SiteInfection: {1} đã được khai báo trước!"
                //    , Utilities.ConvertSqlString(objInfo.Makhangsinh)
                //    , Utilities.ConvertSqlString(objInfo.SiteInfection))
                //    };
                //}
            }
        }

        public bool Update_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET set");
            sb.AppendFormat("\n Mabokhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            sb.AppendFormat("\n, Makhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'");
            sb.AppendFormat("\n, MaViKhuan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'");
            sb.AppendFormat("\n, KyThuat = {0}", "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'");
            sb.AppendFormat("\n, GuideLine = {0}", "'" + Utilities.ConvertSqlString(objInfo.Guideline.ToString()) + "'");
            sb.AppendFormat("\n, CanNhay = {0}", objInfo.Cannhay == null ? "NULL" : objInfo.Cannhay.ToString());
            sb.AppendFormat("\n, CanKhang = {0}", objInfo.Cankhang == null ? "NULL" : objInfo.Cankhang.ToString());
            sb.AppendFormat("\n, CanTrungGianTren = {0}", (objInfo.Cantrunggiantren == null ? "NULL" : objInfo.Cantrunggiantren.ToString()));
            sb.AppendFormat("\n, CanTrungGianDuoi = {0}", (objInfo.Cantrunggianduoi == null ? "NULL" : objInfo.Cantrunggianduoi.ToString()));
            sb.AppendFormat("\n, GioSua = {0}", (objInfo.Giosua == null ? "NULL" : "'" + objInfo.Giosua?.ToString("yyyy-MM-dd HH:mm:ss") + "'"));
            sb.AppendFormat("\n, NguoiSua = {0}", "'" + Utilities.ConvertSqlString(objInfo.Nguoisua.ToString()) + "'");
            sb.AppendFormat("\n, Potency = {0}", "'" + Utilities.ConvertSqlString(objInfo.Potency.ToString()) + "'");

            sb.Append("\nwhere Mabokhangsinh = '" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'"
                + " and Makhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'"
                + " and MaViKhuan =  " + "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'"
                + " and KyThuat =  " + "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'"
                + " and GuideLine =  " + "'" + Utilities.ConvertSqlString(objInfo.Guideline.ToString()) + "'"
                );
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_xetnghiem_khangsinh_bo_chitiet(DM_XETNGHIEM_KHANGSINH_BO_CHITIET objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET");
            sb.AppendFormat("\n where Mabokhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            sb.AppendFormat("\n and Makhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangsinh.ToString()) + "'");
            sb.AppendFormat("\n and MaViKhuan = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mavikhuan.ToString()) + "'");
            sb.AppendFormat("\n and KyThuat = {0}", "'" + Utilities.ConvertSqlString(objInfo.Kythuat.ToString()) + "'");
            sb.AppendFormat("\n and GuideLine = {0}", "'" + Utilities.ConvertSqlString(objInfo.Guideline.ToString()) + "'");
            sb.AppendFormat("\n and SiteInfection = {0}", "'" + Utilities.ConvertSqlString(objInfo.Siteinfection.ToString()) + "'");

            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh)
        {
            var sb = new StringBuilder();
            sb.Append("select distinct ct.*, ks.TenKhangSinh from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET ct left join [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH ks on ct.MaKhangSinh = ks.MaKHangSinh where 1=1");
            //if (!string.IsNullOrEmpty(mabokhangsinh))
            //    sb.AppendFormat("\n and  ct.mabokhangsinh = {0}", "'" + mabokhangsinh + "'");
            //if (!string.IsNullOrEmpty(makhangsinh))
            //    sb.AppendFormat("\n and  ct.makhangsinh = {0}", "'" + makhangsinh + "'");
            //sb.Append("SELECT * FROM dbo.dm_xetnghiem_khangsinh_bo_chitiet WHERE 1=1");
            if (!string.IsNullOrEmpty(mabokhangsinh))
                sb.AppendFormat("\n and  MaBoKhangSinh = {0}", "'" + mabokhangsinh + "'");
            return sb.ToString();
        }

        private string SQLSelect_Data_dm_xetnghiem_khangsinh_bo_chitiet_mavikhuan(string mavikhuan)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("select ct.*, ks.TenKhangSinh from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET ct left join [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH ks on ct.MaKhangSinh = ks.MaKHangSinh where 1=1");
            //if (!string.IsNullOrEmpty(mabokhangsinh))
            //    sb.AppendFormat("\n and  ct.mabokhangsinh = {0}", "'" + mabokhangsinh + "'");
            //if (!string.IsNullOrEmpty(makhangsinh))
            //    sb.AppendFormat("\n and  ct.makhangsinh = {0}", "'" + makhangsinh + "'");
            sb.Append("SELECT * FROM dbo.dm_xetnghiem_khangsinh_bo_chitiet WHERE 1=1");
            if (!string.IsNullOrEmpty(mavikhuan))
                sb.AppendFormat("\n and  MaViKhuan = {0}", "'" + mavikhuan + "'");
            return sb.ToString();
        }

        public DataTable Data_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh)).Tables[0];
            return dtData;
        }

        public DataTable Data_dm_xetnghiem_khangsinh_bo_chitiet(string mavikhuan)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_khangsinh_bo_chitiet_mavikhuan(mavikhuan)).Tables[0];
            return dtData;
        }

        public DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(DataGridView dtg, BindingNavigator bv, string mabokhangsinh, string makhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string mabokhangsinh, string makhangsinh)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_khangsinh_bo_chitiet(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabokhangsinh, string makhangsinh)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_KHANGSINH_BO_CHITIET Get_Info_dm_xetnghiem_khangsinh_bo_chitiet(string mabokhangsinh, string makhangsinh)
        {
            DataTable dt = Data_dm_xetnghiem_khangsinh_bo_chitiet(mabokhangsinh, makhangsinh);
            DM_XETNGHIEM_KHANGSINH_BO_CHITIET obj = new DM_XETNGHIEM_KHANGSINH_BO_CHITIET();
            if (dt.Rows.Count > 0)

            {
                obj.Mabokhangsinh = StringConverter.ToString(dt.Rows[0]["mabokhangsinh"]);
                obj.Makhangsinh = StringConverter.ToString(dt.Rows[0]["makhangsinh"]);
            }
            return obj;
        }
        #endregion
        #region [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_visinh_bo
        public BaseModel Insert_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_BO (");
            sqlQuery.Append("\nMabokhangsinh");
            sqlQuery.Append("\n,Tenbokhangsinh");
            sqlQuery.Append("\n,Sapxep");
            sqlQuery.Append("\n,Nguoinhap");
            sqlQuery.Append("\n,Gionhap");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Tenbokhangsinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenbokhangsinh.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Sapxep < 0 ? "1000" : objInfo.Sapxep.ToString()));
            sqlQuery.Append("\n ,getdate()");
            sqlQuery.AppendFormat("\n ,{0}", "'" + objInfo.Gionhap.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_BO where Mabokhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã bị trùng"
                };
            }
        }
        public bool Update_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_BO set");
            sb.AppendFormat("\n Mabokhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            sb.AppendFormat("\n, Tenbokhangsinh = {0}", (objInfo.Tenbokhangsinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Tenbokhangsinh.ToString()) + "'"));
            sb.AppendFormat("\n, Sapxep = {0}", (objInfo.Sapxep < 0 ? "1000" : objInfo.Sapxep.ToString()));
            sb.AppendFormat("\n, Nguoisua = {0}", (objInfo.Nguoisua == null ? "NULL" : "'" + Utilities.ConvertSqlString(objInfo.Nguoisua.ToString()) + "'"));
            sb.AppendFormat("\n, Giosua = getdate()");
            sb.Append("\nwhere 1 = 1  and Mabokhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool Delete_dm_xetnghiem_visinh_bo(DM_XETNGHIEM_VISINH_BO objInfo)
        {
            var sqlCheckExisted = new StringBuilder();
            sqlCheckExisted.Append("SELECT TOP 1 * FROM [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGSINH_BO_CHITIET ");
            sqlCheckExisted.AppendFormat("\n WHERE MaBoKhangSinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh) + "'");

            if (DataProvider.CheckExisted(sqlCheckExisted.ToString()))
            {
                CustomMessageBox.MSG_Information_OK(string.Format("Vui lòng xóa hết kháng sinh đồ của Panel: {0}!", objInfo.Tenbokhangsinh));
                return false;
            }
            var sb = new StringBuilder();
            sb.Append("Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_BO");
            sb.AppendFormat("\n where Mabokhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Mabokhangsinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_dm_xetnghiem_visinh_bo(string mabokhangsinh)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_BO where 1=1");
            if (!string.IsNullOrEmpty(mabokhangsinh))
                sb.AppendFormat("\n and  mabokhangsinh = {0}", "'" + mabokhangsinh + "'");
            return sb.ToString();
        }

        //private string SQLSelect_Data_dm_xetnghiem_visinh_bo_by_mvk(string mavikhuan)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("select * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_BO where 1=1");
        //    if (!string.IsNullOrEmpty(mavikhuan))
        //        sb.AppendFormat("\n and  mabokhangsinh = {0}", "'" + mavikhuan + "'");
        //    return sb.ToString();
        //}

        public DataTable Data_dm_xetnghiem_visinh_bo_by_mvk(string mavikhuan)
        {
            //DataTable dtData = new DataTable();
            var para = new SqlParameter[] { new SqlParameter("@MaViKhuan", mavikhuan) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDM_XetNghiem_ViSinh_Bo_By_MVK", para).Tables[0];
            //dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_visinh_bo_by_mvk(mavikhuan)).Tables[0];
            //return dtData;
        }
        public DataTable Data_dm_xetnghiem_visinh_bo(string mabokhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_visinh_bo(mabokhangsinh)).Tables[0];
            return dtData;
        }


        public DataTable Get_Data_dm_xetnghiem_visinh_bo(DataGridView dtg, BindingNavigator bv, string mabokhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_visinh_bo(mabokhangsinh);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_visinh_bo(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter
            , ref DataTable dtData, string mabokhangsinh)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_visinh_bo(mabokhangsinh), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_visinh_bo(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string mabokhangsinh)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_dm_xetnghiem_visinh_bo(mabokhangsinh);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_VISINH_BO Get_Info_dm_xetnghiem_visinh_bo(string mabokhangsinh)
        {
            DataTable dt = Data_dm_xetnghiem_visinh_bo(mabokhangsinh);
            DM_XETNGHIEM_VISINH_BO obj = new DM_XETNGHIEM_VISINH_BO();
            if (dt.Rows.Count > 0)

            {
                obj.Mabokhangsinh = StringConverter.ToString(dt.Rows[0]["mabokhangsinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenbokhangsinh"].ToString()))
                    obj.Tenbokhangsinh = StringConverter.ToString(dt.Rows[0]["tenbokhangsinh"]);
                obj.Sapxep = NumberConverter.To<int>(dt.Rows[0]["sapxep"]);
                obj.Nguoinhap = StringConverter.ToString(dt.Rows[0]["nguoinhap"]);
                obj.Gionhap = (DateTime)dt.Rows[0]["gionhap"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoisua"].ToString()))
                    obj.Nguoisua = StringConverter.ToString(dt.Rows[0]["nguoisua"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["giosua"].ToString()))
                    obj.Giosua = (DateTime)dt.Rows[0]["giosua"];
            }
            return obj;
        }

        public DataTable Get_Info_KS_KSD(string maViKhuan, string maKhangSinh, string kyThuat, string guideLine, string potency, string guideLineType)
        {
            //Chỗ này tìm lấy kt ETEST như MIC
            if (kyThuat.Equals("ETEST", StringComparison.OrdinalIgnoreCase))
            {
                kyThuat = "MIC";
            }
            var sqlParaVK_KS = new[] {
                WorkingServices.GetParaFromOject("@maViKhuan", maViKhuan),
                WorkingServices.GetParaFromOject("@maKhangSinh", maKhangSinh),
                new SqlParameter("@potency", potency),
                WorkingServices.GetParaFromOject("@kyThuat", kyThuat),
                WorkingServices.GetParaFromOject("@guideLineType", guideLineType)};

            var sqlParaKS = new[] {
                WorkingServices.GetParaFromOject("@maKhangSinh", maKhangSinh),
                new SqlParameter("@potency", potency),
                WorkingServices.GetParaFromOject("@guideLine", guideLineType)};

            var dtVK_KS = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_vk_ks", sqlParaVK_KS).Tables[0];
            var dtKS = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_xetnghiem_ks", sqlParaKS).Tables[0];

            return dtVK_KS.Rows.Count > 0 ? dtVK_KS : dtKS;

            #region Lấy không dùng Stored
            //var dt = new DataTable();
            //var sqlSubQuery = new StringBuilder();
            //sqlSubQuery.Append("SELECT  MAX(CAST (RIGHT(GuideLine,2) AS INT)) FROM [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan_khangsinh WHERE ");
            //sqlSubQuery.AppendFormat("\n MaViKhuan = {0}", "'" + maViKhuan + "'");
            //sqlSubQuery.AppendFormat("\n AND MaKhangSinh = {0}", "'" + maKhangSinh + "'");
            //sqlSubQuery.AppendFormat("\n AND Potency = {0}", "'" + potency + "'");
            //sqlSubQuery.AppendFormat("\n AND KyThuat = {0}", "'" + kyThuat + "'");
            //sqlSubQuery.AppendFormat("\n AND BreakPoint_Type = 'Human'");
            //sqlSubQuery.AppendFormat("\n AND LEFT(GuideLine,LEN(GuideLine) - 2) = '{0}'", guideLineType);

            //var sqlQueryVkKs = new StringBuilder();
            //sqlQueryVkKs.Append("select CAST(RIGHT(GuideLine,2) AS INT) as Year,* from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_vikhuan_khangsinh where  ");
            //sqlQueryVkKs.AppendFormat("\n MaViKhuan = {0}", "'" + maViKhuan + "'");
            //sqlQueryVkKs.AppendFormat("\n AND MaKhangSinh = {0}", "'" + maKhangSinh + "'");
            //sqlQueryVkKs.AppendFormat("\n AND Potency = {0}", "'" + potency + "'");
            //sqlQueryVkKs.AppendFormat("\n AND KyThuat = {0}", "'" + kyThuat + "'");
            //sqlQueryVkKs.AppendFormat("\n AND BreakPoint_Type = 'Human'");
            //sqlQueryVkKs.AppendFormat("\n AND LEFT(GuideLine,LEN(GuideLine) - 2) = '{0}'", guideLineType);
            //sqlQueryVkKs.AppendFormat("\n AND CAST(RIGHT(GuideLine,2) AS INT) = ({0})", sqlSubQuery);

            ////var sqlQueryKs = new StringBuilder();
            ////sqlQueryKs.Append("SELECT * FROM dbo.dm_xetnghiem_khangsinh WHERE ");
            ////sqlQueryKs.AppendFormat("\n MaKhangSinh = {0}", "'" + maKhangSinh + "'");
            ////sqlQueryKs.AppendFormat("\n AND Potency = {0}", "'" + potency + "'");
            ////sqlQueryKs.AppendFormat("\n AND GuideLineType = {0}", "'" + guideLineType + "'");

            //if (DataProvider.CheckExisted(sqlQueryVkKs.ToString()))
            //{
            //    dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQueryVkKs.ToString()).Tables[0];
            //}
            //else
            //{
            //    dt = DataProvider.CheckExisted(sqlQueryKs.ToString()) ? DataProvider.ExecuteDataset(CommandType.Text, sqlQueryKs.ToString()).Tables[0] : null;
            //}
            //return dt;
            #endregion

        }

        public DataTable Get_F_Info_KS_KSD_MaBoKhangSinh_MaViKhuan(string maBoKhangSinh, string maViKhuan)
        {
            var dt = new DataTable();
            var sqlQueryVkKs = new StringBuilder();
            sqlQueryVkKs.Append("select TOP 1 * from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_khangsinh_bo_chitiet where MaViKhuan = ");
            sqlQueryVkKs.AppendFormat("\n {0}", "'" + maViKhuan + "'");
            sqlQueryVkKs.AppendFormat("\n AND MaBoKhangSinh <> {0}", "'" + maBoKhangSinh + "'");

            if (DataProvider.CheckExisted(sqlQueryVkKs.ToString()))
            {
                dt = DataProvider.ExecuteDataset(CommandType.Text, sqlQueryVkKs.ToString()).Tables[0];
            }
            //else
            //{
            //    dt = DataProvider.CheckExisted(sqlQueryKs.ToString()) ? DataProvider.ExecuteDataset(CommandType.Text, sqlQueryKs.ToString()).Tables[0] : null;
            //}
            return dt;
        }

        #endregion
        #region [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_khangkhangsinh
        public BaseModel Insert_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGKHANGSINH (");
            sqlQuery.Append("\nMakhangkhangsinh,TenKhangKhangSinh");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0},", "'" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Tenkhangkhangsinh.ToString()) + "'");

            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGKHANGSINH where Makhangkhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'"))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã bị trùng"
                };
            }
        }
        public bool Update_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGKHANGSINH set");
            sb.AppendFormat("\n Makhangkhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'");
            sb.Append("\nwhere Makhangkhangsinh =  " + "'" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        public bool Delete_dm_xetnghiem_khangkhangsinh(DM_XETNGHIEM_KHANGKHANGSINH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGKHANGSINH");
            sb.AppendFormat("\n where Makhangkhangsinh = {0}", "'" + Utilities.ConvertSqlString(objInfo.Makhangkhangsinh.ToString()) + "'");
            return DataProvider.ExecuteQuery(sb.ToString());
        }
        private string SQLSelect_Data_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_KHANGKHANGSINH where 1=1");
            if (!string.IsNullOrEmpty(makhangkhangsinh))
                sb.AppendFormat("\n and  makhangkhangsinh = {0}", "'" + makhangkhangsinh + "'");
            return sb.ToString();
        }
        public DataTable Data_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_khangkhangsinh(makhangkhangsinh)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_khangkhangsinh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string makhangkhangsinh)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_khangkhangsinh(makhangkhangsinh), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DM_XETNGHIEM_KHANGKHANGSINH Get_Info_dm_xetnghiem_khangkhangsinh(string makhangkhangsinh)
        {
            DataTable dt = Data_dm_xetnghiem_khangkhangsinh(makhangkhangsinh);
            DM_XETNGHIEM_KHANGKHANGSINH obj = new DM_XETNGHIEM_KHANGKHANGSINH();
            if (dt.Rows.Count > 0)
            {
                obj.Makhangkhangsinh = StringConverter.ToString(dt.Rows[0]["makhangkhangsinh"]);
            }
            return obj;
        }
        #endregion
        #region Danh mục mapping
        //mapping vi khuan may
        public DataTable Data_ViKhuan_ChuaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_ViKhuan_ChuaMapping", para).Tables[0];
        }
        public DataTable Data_ViKhuan_DaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_ViKhuan_DaMapping", para).Tables[0];
        }
        public int Insert_ViKhuan_Mapping(int idMayXN, string maVikhuan)
        {
            //var sqlChecked = string.Format("SELECT * FROM H_VISINH_MAVIKHUANMAYXN WHERE MaViKhuan = N'{0}' " +
            //     " and IDMayXetNghiem = {1} and MaViKhuanMay = N'{2}'",maVikhuan,idMayXN,"??????");
            //if (DataProvider.CheckExisted(sqlChecked))
            //    return -2;
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN), new SqlParameter("@MaViKhuan", maVikhuan) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insViSinh_DM_H_MaViKhuan_Mapping", para);
        }
        public int Update_ViKhuan_Mapping(int idMayXN, string maVikhuan, string maViKhuanMay)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN), new SqlParameter("@MaViKhuan", maVikhuan), new SqlParameter("@MaViKhuanMay", maViKhuanMay) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_DM_H_MaViKhuan_Mapping", para);
        }
        public int Delete_ViKhuan_Mapping(int idMayXN, string maVikhuan, string maViKhuanMay)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN), new SqlParameter("@MaViKhuan", maVikhuan), new SqlParameter("@MaViKhuanMay", maViKhuanMay) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delViSinh_DM_H_MaViKhuan_Mapping", para);
        }
        //Mapping khang sinh
        public DataTable Data_KhangSinh_ChuaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_KhangSinh_ChuaMapping", para).Tables[0];
        }
        public DataTable Data_KhangSinh_DaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_KhangSinh_DaMapping", para).Tables[0];
        }
        public int Insert_KhangSinh_Mapping(int idMayXN, string maKhangSinh)
        {
            var sqlCheck = "SELECT * FROM h_visinh_makhangsinhmayxn where 1=1 ";
            sqlCheck += string.Format("\nAND IDMayXetNghiem = N'{0}'", idMayXN);
            sqlCheck += string.Format("\nAND makhangsinh = N'{0}'", maKhangSinh);
            sqlCheck += string.Format("\nAND makhangsinhmay = N'??????'");
            sqlCheck += string.Format("\nAND SiteInfection = N''");
            if (DataProvider.CheckExisted(sqlCheck))
            {
                CustomMessageBox.MSG_Information_OK("Mapping kháng sinh đã được nhập trước!");
                return -1;
            }
            var para = new[] { new SqlParameter("@IdMayXn", idMayXN), new SqlParameter("@MaKhangSinh", maKhangSinh) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insViSinh_DM_H_KhangSinh_Mapping", para);
        }
        public int Update_KhangSinh_Mapping(int idMayXN, string maKhangSinh, string maKhangSinhMay, string SiteINF, int autoID)
        {
            var sqlCheck = "SELECT * FROM h_visinh_makhangsinhmayxn where 1=1 ";
            sqlCheck += string.Format("\nAND IDMayXetNghiem = N'{0}'", idMayXN);
            sqlCheck += string.Format("\nAND makhangsinh = N'{0}'", maKhangSinh);
            sqlCheck += string.Format("\nAND makhangsinhmay = N'{0}'", maKhangSinhMay);
            sqlCheck += string.Format("\nAND SiteInfection = N'{0}'", SiteINF);
            if (DataProvider.CheckExisted(sqlCheck))
            {
                CustomMessageBox.MSG_Information_OK("Mapping kháng sinh đã được nhập trước!");
                return -1;
            }

            var para = new[] {
                new SqlParameter("@IdMayXn", idMayXN),
                new SqlParameter("@MaKhangSinh", maKhangSinh),
                new SqlParameter("@MaKhangSinhMay", maKhangSinhMay),
                new SqlParameter("@SiteINF", SiteINF),
                new SqlParameter("@AutoID", autoID)};

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_DM_H_KhangSinh_Mapping", para);
        }
        public int Delete_KhangSinh_Mapping(int autoID)
        {
            var para = new[] { WorkingServices.GetParaFromOject("@AutoID", autoID) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delViSinh_DM_H_KhangSinh_Mapping", para);
        }
        //Khang Khang Sinh
        public DataTable Data_KhangKhangSinh_ChuaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_KhangKhangSinh_ChuaMapping", para).Tables[0];
        }
        public DataTable Data_KhangKhangSinh_DaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_khangkhangSinh_DaMapping", para).Tables[0];
        }
        public int Insert_KhangKhangSinh_Mapping(int idMayXN, string maKhangKhangSinh)
        {

            var sqlCheck = "SELECT * FROM H_VISINH_MAKHANGKHANGSINHMAYXN where 1=1 ";
            sqlCheck += string.Format("\nAND IDMayXetNghiem = N'{0}'", idMayXN);
            sqlCheck += string.Format("\nAND makhangkhangsinh = N'{0}'", maKhangKhangSinh);
            sqlCheck += string.Format("\nAND makhangkhangsinhmay = N'??????'");
            if (DataProvider.CheckExisted(sqlCheck))
            {
                CustomMessageBox.MSG_Information_OK("Mapping kháng sinh đã được nhập trước!");
                return -1;
            }
            var para = new[] { new SqlParameter("@IdMayXn", idMayXN), new SqlParameter("@MaKKS", maKhangKhangSinh) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insViSinh_DM_H_KhangKhangSinh_Mapping", para);
        }
        public int Update_KhangKhangSinh_Mapping(int idMayXN, string maKhangKhangSinh, string maKhangKhangSinhMay, int autoID)
        {
            var sqlCheck = "SELECT * FROM H_VISINH_MAKHANGKHANGSINHMAYXN where 1=1 ";
            sqlCheck += string.Format("\nAND IDMayXetNghiem = N'{0}'", idMayXN);
            sqlCheck += string.Format("\nAND makhangkhangsinh = N'{0}'", maKhangKhangSinh);
            sqlCheck += string.Format("\nAND makhangkhangsinhmay = N'{0}'", maKhangKhangSinhMay);
            if (DataProvider.CheckExisted(sqlCheck))
            {
                CustomMessageBox.MSG_Information_OK("Mapping kháng sinh đã được nhập trước!");
                return -1;
            }

            var para = new[] {
                new SqlParameter("@IdMayXn", idMayXN),
                new SqlParameter("@MaKhangKhangSinh", maKhangKhangSinh),
                new SqlParameter("@MaKhangKhangSinhMay", maKhangKhangSinhMay),
                new SqlParameter("@AutoID", autoID)};

            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_DM_H_KhangKhangSinh_Mapping", para);
        }
        public int Delete_KhangKhangSinh_Mapping(int autoID)
        {
            var para = new[] { WorkingServices.GetParaFromOject("@AutoID", autoID) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delViSinh_DM_H_KhangKhangSinh_Mapping", para);
        }
        //mapping chỉ định
        public DataTable Data_ChiDinh_DaMapping(int idMayXN)
        {
            var para = new SqlParameter[] { new SqlParameter("@IdMayXn", idMayXN) };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selViSinh_DM_H_ChiDinhMapping", para).Tables[0];
        }
        public int Insert_ChiDinh_Mapping(int idMayXN, string maChiDinh, string maLoaiMau)
        {
            var sqlCheck = "SELECT * FROM h_visinh_bangmayeucaumayxn where 1=1 ";
            sqlCheck += string.Format("\nAND mayeucau = N'{0}'", maChiDinh);
            sqlCheck += string.Format("\nAND maloaimau = N'{0}'", maLoaiMau);
            sqlCheck += string.Format("\nAND idmay = {0}", idMayXN);
            sqlCheck += string.Format("\nAND IDThe = '?????'");
            if (DataProvider.CheckExisted(sqlCheck))
            {
                CustomMessageBox.MSG_Information_OK("Chỉ định đã được nhập trước!");
                return -1;
            }
            var para = new[] { new SqlParameter("@IdMayXn", idMayXN),
                               new SqlParameter("@MaChiDinh", maChiDinh),
                               new SqlParameter("@maLoaiMau", maLoaiMau)};
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insViSinh_DM_H_ChiDinhMapping", para);
        }
        public int Update_ChiDinh_Mapping(H_VISINH_BANGMAYEUCAUMAYXN obj)
        {
            var sqlCheck = "SELECT * FROM h_visinh_bangmayeucaumayxn where 1=1 ";
            //sqlCheck += string.Format("\nAND ID = {0}", obj.ID);
            sqlCheck += string.Format("\nAND mayeucau = N'{0}'", obj.Mayeucau);
            sqlCheck += string.Format("\nAND maloaimau = N'{0}'", obj.Maloaimau);
            sqlCheck += string.Format("\nAND IDLoaiMau = N'{0}'", obj.Idloaimau);
            sqlCheck += string.Format("\nAND IDThe = N'{0}'", obj.Idthe);
            sqlCheck += string.Format("\nAND IDTheKSD = N'{0}'", obj.Idtheksd);
            //sqlCheck += string.Format("\nAND SiteInfection = N'{0}'", obj.SiteInfection);
            if (DataProvider.CheckExisted(sqlCheck))
            {
                CustomMessageBox.MSG_Information_OK("Chỉ định đã được nhập trước!");
                return -1;
            }
            var para = new[] { new SqlParameter("@ID", obj.Id)
                , new SqlParameter("@IDThe", obj.Idthe)
                , new SqlParameter("@IDLoaiMau", obj.Idloaimau)
                , new SqlParameter("@IDTheKSD", obj.Idtheksd)
                , new SqlParameter("@Gram", obj.Gram)
                //, new SqlParameter("@SiteInf", obj.SiteInfection)
            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpViSinh_DM_H_ChiDinhMapping", para);
        }
        public int Delete_ChiDinh_Mapping(int id)
        {
            var para = new[] { new SqlParameter("@ID", id) };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delViSinh_DM_H_ChiDinhMapping", para);
        }
        #endregion
        #region dm_visinh_maunhapnhanh
        //================================|||=====================================
        public BaseModel Insert_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_VISINH_MAUNHAPNHANH (");
            sqlQuery.Append("\nNoidung");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", (objInfo.Noidung == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Noidung.ToString()) + "'"));

            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                Name = string.Empty
            };

        }

        public bool Update_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update [{{TPH_Standard}}_Dictionary].[dbo].DM_VISINH_MAUNHAPNHANH set");
            sb.AppendFormat("\n  Noidung = {0}", (objInfo.Noidung == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Noidung.ToString()) + "'"));
            sb.AppendFormat("\n  ,Gotat = {0}", (objInfo.Gotat == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Gotat.ToString()) + "'"));
            sb.Append("\nwhere Id =  " + objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_visinh_maunhapnhanh(DM_VISINH_MAUNHAPNHANH objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete [{{TPH_Standard}}_Dictionary].[dbo].dm_visinh_maunhapnhanh");
            sb.AppendFormat("\n where Id = {0}", objInfo.Id.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_visinh_maunhapnhanh(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from [{{TPH_Standard}}_Dictionary].[dbo].dm_visinh_maunhapnhanh ");
            if (!string.IsNullOrEmpty(id))
                sb.AppendFormat("\n where id = {0}", id);
            return sb.ToString();
        }
        public DataTable Data_dm_visinh_maunhapnhanh(string id)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_visinh_maunhapnhanh(id)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_visinh_maunhapnhanh(DataGridView dtg, BindingNavigator bv, string id)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_visinh_maunhapnhanh(id);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_visinh_maunhapnhanh(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string id)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_visinh_maunhapnhanh(id), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_visinh_maunhapnhanh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string id)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_dm_visinh_maunhapnhanh(id);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1;
            return dtData;
        }
        public DM_VISINH_MAUNHAPNHANH Get_Info_dm_visinh_maunhapnhanh(string id)
        {
            DataTable dt = Data_dm_visinh_maunhapnhanh(id);
            DM_VISINH_MAUNHAPNHANH obj = new DM_VISINH_MAUNHAPNHANH();
            if (dt.Rows.Count > 0)

            {
                obj.Id = NumberConverter.To<int>(dt.Rows[0]["id"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["noidung"].ToString()))
                    obj.Noidung = StringConverter.ToString(dt.Rows[0]["noidung"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["Gotat"].ToString()))
                    obj.Gotat = StringConverter.ToString(dt.Rows[0]["Gotat"]);
            }
            return obj;
        }
        //================================|||=====================================
        #endregion
        #region Quy trình vi sinh
        public BaseModel Insert_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo)
        {
            var para = new SqlParameter[] {
                 new SqlParameter("@MaKhangSinh", objInfo.Makhangsinh)
                , new SqlParameter("@KyThuat", objInfo.Kythuat)
                , new SqlParameter("@IDMayXN", objInfo.Idmayxn)
                , new SqlParameter("@QuyTrinh", (string.IsNullOrEmpty( objInfo.Quytrinh)?(object)DBNull.Value:  objInfo.Quytrinh))
            };
            return new BaseModel()
            {
                Id = (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insDmXetNghiem_VinhSinh_QuiTrinh", para),
                Name = string.Empty
            };
        }
        public bool Update_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo)
        {
            var para = new SqlParameter[] {
                 new SqlParameter("@MaKhangSinh", objInfo.Makhangsinh)
                , new SqlParameter("@KyThuat", objInfo.Kythuat)
                , new SqlParameter("@QuyTrinh", objInfo.Quytrinh)
                , new SqlParameter("@PhuongPhap", objInfo.Phuongphap)
                , new SqlParameter("@DatChungNhan", objInfo.Datchungnhan)
                , new SqlParameter("@IDMayXN", objInfo.Idmayxn)
            };

            return
                (int)
                    DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpDmXetNghiem_ViSinh_QuiTrinh", para) > -1;
        }
        public bool Delete_dm_visinh_quitrinh(DM_XETNGHIEM_VISINH_QUITRINH objInfo)
        {
            var para = new SqlParameter[] {
                 new SqlParameter("@MaKhangSinh", objInfo.Makhangsinh)
                , new SqlParameter("@KyThuat", objInfo.Kythuat)
                , new SqlParameter("@IDMayXN", objInfo.Idmayxn)
            };

            return
                (int)
                    DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "delDmXetNghiem_ViSinh_QuiTrinh", para) > -1;
        }
        public DataTable Data_dm_visinh_quitrinh(string maKhangsinh, string kyThuat, string idMay)
        {
            var para = new SqlParameter[] {
                 new SqlParameter("@MaKhangSinh",(string.IsNullOrEmpty(maKhangsinh)?(object)DBNull.Value: maKhangsinh))
                , new SqlParameter("@KyThuat",string.IsNullOrEmpty(kyThuat)?(object)DBNull.Value: kyThuat)
                  , new SqlParameter("@IDMayXN",string.IsNullOrEmpty(idMay)?(object)DBNull.Value: idMay)
            };

            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDmXetNghiem_VinhSinh_QuiTrinh", para).Tables[0];

        }
        #endregion
        #region [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_visinh_quytrinh_loaimau
        public BaseModel Insert_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo)
        {
            StringBuilder sqlQuery = new StringBuilder(); sqlQuery.Append("insert into  [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU (");
            sqlQuery.Append("\nMaloaimau");
            sqlQuery.Append("\n,Idmayxn");
            sqlQuery.Append("\n,Quytrinh");
            sqlQuery.Append("\n,Phuongphap");
            sqlQuery.Append("\n,Datchungnhan");
            sqlQuery.Append(")");

            sqlQuery.Append("select ");
            sqlQuery.AppendFormat("\n {0}", "'" + Utilities.ConvertSqlString(objInfo.Maloaimau.ToString()) + "'");
            sqlQuery.AppendFormat("\n ,{0}", objInfo.Idmayxn.ToString());
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Quytrinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Quytrinh.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (objInfo.Phuongphap == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Phuongphap.ToString()) + "'"));
            sqlQuery.AppendFormat("\n ,{0}", (bool.Parse(objInfo.Datchungnhan.ToString()) ? "1" : "0"));
            if (!DataProvider.CheckExisted("select top 1 * from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_visinh_quytrinh_loaimau where 1 = 1  and Maloaimau =  " + "'" + Utilities.ConvertSqlString(objInfo.Maloaimau.ToString()) + "'" + " and Idmayxn =  " + objInfo.Idmayxn.ToString()))
            {
                return new BaseModel()
                {
                    Id = (int)DataProvider.ExecuteNonQuery(CommandType.Text, sqlQuery.ToString()),
                    Name = string.Empty
                };
            }
            else
            {
                return new BaseModel()
                {
                    Id = -1,
                    Name = "Mã bị trùng"
                };
            }
        }

        public bool Update_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Update [{{TPH_Standard}}_Dictionary].[dbo].DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU set");
            sb.AppendFormat("\n Maloaimau = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maloaimau.ToString()) + "'");
            sb.AppendFormat("\n, Idmayxn = {0}", objInfo.Idmayxn.ToString());
            sb.AppendFormat("\n, Quytrinh = {0}", (objInfo.Quytrinh == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Quytrinh.ToString()) + "'"));
            sb.AppendFormat("\n, Phuongphap = {0}", (objInfo.Phuongphap == null ? "NULL" : "N'" + Utilities.ConvertSqlString(objInfo.Phuongphap.ToString()) + "'"));
            sb.AppendFormat("\n, Datchungnhan = {0}", (bool.Parse(objInfo.Datchungnhan.ToString()) ? "1" : "0"));
            sb.Append("\nwhere Maloaimau =  " + "'" + Utilities.ConvertSqlString(objInfo.Maloaimau.ToString()) + "'" + " and Idmayxn =  " + objInfo.Idmayxn.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        public bool Delete_dm_xetnghiem_visinh_quytrinh_loaimau(DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU objInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_visinh_quytrinh_loaimau");
            sb.AppendFormat("\n where Maloaimau = {0}", "'" + Utilities.ConvertSqlString(objInfo.Maloaimau.ToString()) + "'");
            sb.AppendFormat("\n and Idmayxn = {0}", objInfo.Idmayxn.ToString());
            return DataProvider.ExecuteQuery(sb.ToString());
        }

        private string SQLSelect_Data_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select qm.*, lm.LoaiMau as TenLoaiMau from [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_visinh_quytrinh_loaimau qm inner join [{{TPH_Standard}}_Dictionary].[dbo].dm_xetnghiem_loaimau lm on qm.MaLoaiMau = lm.MaLoaiMau where 1=1");
            if (!string.IsNullOrEmpty(maloaimau))
                sb.AppendFormat("\n and  qm.maloaimau = {0}", "'" + maloaimau + "'");
            if (!string.IsNullOrEmpty(idmayxn))
                sb.AppendFormat("\n and  qm.idmayxn = {0}", idmayxn);
            return sb.ToString();
        }
        public DataTable Data_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(DataGridView dtg, BindingNavigator bv, string maloaimau, string idmayxn)
        {
            DataTable dtData = new DataTable();
            dtData = Data_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(DataGridView dtg, BindingNavigator bv, ref SqlDataAdapter sqlDataAdapter, ref DataTable dtData, string maloaimau, string idmayxn)
        {
            dtData = new DataTable();
            DataProvider.SelInsUpdDelODBC(SQLSelect_Data_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn), ref sqlDataAdapter, ref dtData);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData.Copy();
        }
        public DataTable Get_Data_dm_xetnghiem_visinh_quytrinh_loaimau(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string maloaimau, string idmayxn)
        {
            cbo.ValueMember = _ValueColumn;
            cbo.DisplayMember = _DisplayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            DataTable dtData = Data_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU Get_Info_dm_xetnghiem_visinh_quytrinh_loaimau(string maloaimau, string idmayxn)
        {
            DataTable dt = Data_dm_xetnghiem_visinh_quytrinh_loaimau(maloaimau, idmayxn);
            DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU obj = new DM_XETNGHIEM_VISINH_QUYTRINH_LOAIMAU();
            if (dt.Rows.Count > 0)
            {
                obj.Maloaimau = StringConverter.ToString(dt.Rows[0]["maloaimau"]);
                obj.Idmayxn = NumberConverter.To<int>(dt.Rows[0]["idmayxn"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["quytrinh"].ToString()))
                    obj.Quytrinh = StringConverter.ToString(dt.Rows[0]["quytrinh"]);
                if (!string.IsNullOrEmpty(dt.Rows[0]["phuongphap"].ToString()))
                    obj.Phuongphap = StringConverter.ToString(dt.Rows[0]["phuongphap"]);
                obj.Datchungnhan = NumberConverter.To<bool>(dt.Rows[0]["datchungnhan"]);
            }
            return obj;
        }
        #endregion
    }
}

