using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Log.Services.WorkingLog;
using TPH.LIS.Patient.Model;

namespace TPH.LIS.Patient.Repositories
{
    public class TestResultInformationRepository : ITestResultInformationRepository
    {
        public readonly IWorkingLogService _workingLog = new WorkingLogService();
        public TestResultInformationRepository() { }
        public bool Insert_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo)
        {
            string sqlQuery = "insert into  KETQUA_CLS_XETNGHIEM (";
            sqlQuery += "\nMatiepnhan";
            sqlQuery += "\n,Maxn";
            sqlQuery += "\n,Tenxn";
            sqlQuery += "\n,Ketqua";
            sqlQuery += "\n,Ghichu";
            sqlQuery += "\n,Manhomcls";
            sqlQuery += "\n,Csbt";
            sqlQuery += "\n,Donvi";
            sqlQuery += "\n,Nguongtren";
            sqlQuery += "\n,Nguongduoi";
            sqlQuery += "\n,Sapxep";
            sqlQuery += "\n,Indam";
            sqlQuery += "\n,Indamkq";
            sqlQuery += "\n,Kichcochu";
            sqlQuery += "\n,Kichcokq";
            sqlQuery += "\n,Canhle";
            sqlQuery += "\n,Thutuin";
            sqlQuery += "\n,Xnchinh";
            sqlQuery += "\n,Khongsudung";
            sqlQuery += "\n,Loaimau";
            sqlQuery += "\n,Thoigiannhap";
            sqlQuery += "\n,Profileid";
            sqlQuery += "\n,Flat";
            sqlQuery += "\n,Trangthai";
            sqlQuery += "\n,Xacnhankq";
            sqlQuery += "\n,Nguoixacnhan";
            sqlQuery += "\n,Dkbatthuong";
            sqlQuery += "\n,Tgcoketqua";
            sqlQuery += "\n,Giachuan";
            sqlQuery += "\n,Giarieng";
            sqlQuery += "\n,Hesoxn";
            sqlQuery += "\n,Madichvucls";
            sqlQuery += "\n,Thoigiannhapkq";
            sqlQuery += "\n,Thoigiansuakq";
            sqlQuery += "\n,Usernhapkq";
            sqlQuery += "\n,Usersuakq";
            sqlQuery += "\n,Dathutien";
            sqlQuery += "\n,Usernhapcd";
            sqlQuery += "\n,Mavattu";
            sqlQuery += "\n,Dvttieuhao";
            sqlQuery += "\n,Tieuhao";
            sqlQuery += "\n,Chietkhau";
            sqlQuery += "\n,Tiencong";
            sqlQuery += "\n,Hesoquidoi";
            sqlQuery += "\n,Ketquaquidoi";
            sqlQuery += "\n,Donviquidoi";
            sqlQuery += "\n,Csbtquidoi";
            sqlQuery += "\n,Dadownload";
            sqlQuery += "\n,Idmaydownload";
            sqlQuery += "\n,Idmayxetnghiem";
            sqlQuery += "\n,Tenmayxetnghiem";
            sqlQuery += "\n,Maphanloai";
            sqlQuery += "\n,Datedownload";
            sqlQuery += "\n,Maxnmay";
            sqlQuery += "\n,Uploadweb";
            sqlQuery += "\n,Khongin";
            sqlQuery += ")";

            sqlQuery += "select ";
            sqlQuery += "\n" + "'" + objInfo.Matiepnhan.ToString() + "'";
            sqlQuery += "\n," + "'" + objInfo.Maxn.ToString() + "'";
            sqlQuery += "\n," + (objInfo.Tenxn == null ? "NULL" : "N'" + objInfo.Tenxn.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Ketqua == null ? "NULL" : "N'" + objInfo.Ketqua.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Ghichu == null ? "NULL" : "N'" + objInfo.Ghichu.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Manhomcls == null ? "NULL" : "'" + objInfo.Manhomcls.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Csbt == null ? "NULL" : "N'" + objInfo.Csbt.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Donvi == null ? "NULL" : "N'" + objInfo.Donvi.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Nguongtren == null ? "NULL" : objInfo.Nguongtren.ToString());
            sqlQuery += "\n," + (objInfo.Nguongduoi == null ? "NULL" : objInfo.Nguongduoi.ToString());
            sqlQuery += "\n," + (objInfo.Sapxep < 0 ? "1" : objInfo.Sapxep.ToString());
            sqlQuery += "\n," + (bool.Parse(objInfo.Indam.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Indamkq.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (objInfo.Kichcochu < 0 ? "12" : objInfo.Kichcochu.ToString());
            sqlQuery += "\n," + (objInfo.Kichcokq < 0 ? "12" : objInfo.Kichcokq.ToString());
            sqlQuery += "\n," + (objInfo.Canhle < 0 ? "1" : objInfo.Canhle.ToString());
            sqlQuery += "\n," + (objInfo.Thutuin < 0 ? "1" : objInfo.Thutuin.ToString());
            sqlQuery += "\n," + (bool.Parse(objInfo.Xnchinh.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Khongsudung.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (objInfo.Loaimau == null ? "NULL" : "'" + objInfo.Loaimau.ToString() + "'");
            sqlQuery += "\n," + "'" + objInfo.Thoigiannhap.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            sqlQuery += "\n," + (objInfo.Profileid == null ? "NULL" : "'" + objInfo.Profileid.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Flat < 0 ? "1" : objInfo.Flat.ToString());
            sqlQuery += "\n," + (objInfo.Trangthai == null ? "NULL" : "N'" + objInfo.Trangthai.ToString() + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Xacnhankq.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (objInfo.Nguoixacnhan == null ? "NULL" : "'" + objInfo.Nguoixacnhan.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Dkbatthuong == null ? "NULL" : "N'" + objInfo.Dkbatthuong.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Tgcoketqua < 0 ? "0" : objInfo.Tgcoketqua.ToString());
            sqlQuery += "\n," + (string.IsNullOrEmpty(objInfo.Giachuan.ToString()) ? "0" : objInfo.Giachuan.ToString());
            sqlQuery += "\n," + (string.IsNullOrEmpty(objInfo.Giarieng.ToString()) ? "0" : objInfo.Giarieng.ToString());
            sqlQuery += "\n," + (objInfo.Hesoxn < 0 ? "1" : objInfo.Hesoxn.ToString());
            sqlQuery += "\n," + (objInfo.Madichvucls < 0 ? "1" : objInfo.Madichvucls.ToString());
            sqlQuery += "\n," + (objInfo.Thoigiannhapkq == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiannhapkq.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery += "\n," + (objInfo.Thoigiansuakq == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiansuakq.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery += "\n," + (objInfo.Usernhapkq == null ? "NULL" : "'" + objInfo.Usernhapkq.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Usersuakq == null ? "NULL" : "'" + objInfo.Usersuakq.ToString() + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dathutien.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (objInfo.Usernhapcd == null ? "NULL" : "'" + objInfo.Usernhapcd.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Mavattu == null ? "NULL" : "'" + objInfo.Mavattu.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Dvttieuhao == null ? "NULL" : "N'" + objInfo.Dvttieuhao.ToString() + "'");
            sqlQuery += "\n," + (string.IsNullOrEmpty(objInfo.Tieuhao.ToString()) ? "1" : objInfo.Tieuhao.ToString());
            sqlQuery += "\n," + (string.IsNullOrEmpty(objInfo.Chietkhau.ToString()) ? "0" : objInfo.Chietkhau.ToString());
            sqlQuery += "\n," + (string.IsNullOrEmpty(objInfo.Tiencong.ToString()) ? "0" : objInfo.Tiencong.ToString());
            sqlQuery += "\n," + (string.IsNullOrEmpty(objInfo.Hesoquidoi.ToString()) ? "0" : objInfo.Hesoquidoi.ToString());
            sqlQuery += "\n," + (objInfo.Ketquaquidoi == null ? "NULL" : objInfo.Ketquaquidoi.ToString());
            sqlQuery += "\n," + (objInfo.Donviquidoi == null ? "NULL" : "N'" + objInfo.Donviquidoi.ToString() + "'");
            sqlQuery += "\n," + (objInfo.Csbtquidoi == null ? "NULL" : "N'" + objInfo.Csbtquidoi.ToString() + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Dadownload.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (objInfo.Idmaydownload < 0 ? "0" : objInfo.Idmaydownload.ToString());
            sqlQuery += "\n," + (objInfo.Idmayxetnghiem < 0 ? "0" : objInfo.Idmayxetnghiem.ToString());
            sqlQuery += "\n," + (objInfo.Tenmayxetnghiem == null ? "NULL" : "N'" + objInfo.Tenmayxetnghiem.ToString() + "'");
            sqlQuery += "\n," + "'" + objInfo.Maphanloai.ToString() + "'";
            sqlQuery += "\n," + (objInfo.Datedownload == null ? "NULL" : "'" + DateTime.Parse(objInfo.Datedownload.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery += "\n," + (objInfo.Maxnmay == null ? "NULL" : "'" + objInfo.Maxnmay.ToString() + "'");
            sqlQuery += "\n," + (bool.Parse(objInfo.Uploadweb.ToString()) ? "1" : "0");
            sqlQuery += "\n," + (bool.Parse(objInfo.Khongin.ToString()) ? "1" : "0");
            if (!DataProvider.CheckExisted("select top 1 * from ketqua_cls_xetnghiem where 1 = 1  and Matiepnhan =  " + "'" + objInfo.Matiepnhan.ToString() + "'" + " and Maxn =  " + "'" + objInfo.Maxn.ToString() + "'"))
            {
                return DataProvider.ExecuteQuery(sqlQuery);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Thông tin bị trùng !\nHãy chọn mã khác.");
                return false;
            }
        }
        public bool Update_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo)
        {
            string sqlQuery = "Update KETQUA_CLS_XETNGHIEM set";
            sqlQuery += "\n Matiepnhan = " + "'" + objInfo.Matiepnhan.ToString() + "'";
            sqlQuery += "\n, Maxn = " + "'" + objInfo.Maxn.ToString() + "'";
            sqlQuery += "\n, Tenxn = " + (objInfo.Tenxn == null ? "NULL" : "N'" + objInfo.Tenxn.ToString() + "'");
            sqlQuery += "\n, Ketqua = " + (objInfo.Ketqua == null ? "NULL" : "N'" + objInfo.Ketqua.ToString() + "'");
            sqlQuery += "\n, Ghichu = " + (objInfo.Ghichu == null ? "NULL" : "N'" + objInfo.Ghichu.ToString() + "'");
            sqlQuery += "\n, Manhomcls = " + (objInfo.Manhomcls == null ? "NULL" : "'" + objInfo.Manhomcls.ToString() + "'");
            sqlQuery += "\n, Csbt = " + (objInfo.Csbt == null ? "NULL" : "N'" + objInfo.Csbt.ToString() + "'");
            sqlQuery += "\n, Donvi = " + (objInfo.Donvi == null ? "NULL" : "N'" + objInfo.Donvi.ToString() + "'");
            sqlQuery += "\n, Nguongtren = " + (objInfo.Nguongtren == null ? "NULL" : objInfo.Nguongtren.ToString());
            sqlQuery += "\n, Nguongduoi = " + (objInfo.Nguongduoi == null ? "NULL" : objInfo.Nguongduoi.ToString());
            sqlQuery += "\n, Sapxep = " + (objInfo.Sapxep < 0 ? "1" : objInfo.Sapxep.ToString());
            sqlQuery += "\n, Indam = " + (bool.Parse(objInfo.Indam.ToString()) ? "1" : "0");
            sqlQuery += "\n, Indamkq = " + (bool.Parse(objInfo.Indamkq.ToString()) ? "1" : "0");
            sqlQuery += "\n, Kichcochu = " + (objInfo.Kichcochu < 0 ? "12" : objInfo.Kichcochu.ToString());
            sqlQuery += "\n, Kichcokq = " + (objInfo.Kichcokq < 0 ? "12" : objInfo.Kichcokq.ToString());
            sqlQuery += "\n, Canhle = " + (objInfo.Canhle < 0 ? "1" : objInfo.Canhle.ToString());
            sqlQuery += "\n, Thutuin = " + (objInfo.Thutuin < 0 ? "1" : objInfo.Thutuin.ToString());
            sqlQuery += "\n, Xnchinh = " + (bool.Parse(objInfo.Xnchinh.ToString()) ? "1" : "0");
            sqlQuery += "\n, Khongsudung = " + (bool.Parse(objInfo.Khongsudung.ToString()) ? "1" : "0");
            sqlQuery += "\n, Loaimau = " + (objInfo.Loaimau == null ? "NULL" : "'" + objInfo.Loaimau.ToString() + "'");
            sqlQuery += "\n, Thoigiannhap = " + "'" + objInfo.Thoigiannhap.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            sqlQuery += "\n, Profileid = " + (objInfo.Profileid == null ? "NULL" : "'" + objInfo.Profileid.ToString() + "'");
            sqlQuery += "\n, Flat = " + (objInfo.Flat < 0 ? "1" : objInfo.Flat.ToString());
            sqlQuery += "\n, Trangthai = " + (objInfo.Trangthai == null ? "NULL" : "N'" + objInfo.Trangthai.ToString() + "'");
            sqlQuery += "\n, Xacnhankq = " + (bool.Parse(objInfo.Xacnhankq.ToString()) ? "1" : "0");
            sqlQuery += "\n, Nguoixacnhan = " + (objInfo.Nguoixacnhan == null ? "NULL" : "'" + objInfo.Nguoixacnhan.ToString() + "'");
            sqlQuery += "\n, Dkbatthuong = " + (objInfo.Dkbatthuong == null ? "NULL" : "N'" + objInfo.Dkbatthuong.ToString() + "'");
            sqlQuery += "\n, Tgcoketqua = " + (objInfo.Tgcoketqua < 0 ? "0" : objInfo.Tgcoketqua.ToString());
            sqlQuery += "\n, Giachuan = " + (string.IsNullOrEmpty(objInfo.Giachuan.ToString()) ? "0" : objInfo.Giachuan.ToString());
            sqlQuery += "\n, Giarieng = " + (string.IsNullOrEmpty(objInfo.Giarieng.ToString()) ? "0" : objInfo.Giarieng.ToString());
            sqlQuery += "\n, Hesoxn = " + (objInfo.Hesoxn < 0 ? "1" : objInfo.Hesoxn.ToString());
            sqlQuery += "\n, Madichvucls = " + (objInfo.Madichvucls < 0 ? "1" : objInfo.Madichvucls.ToString());
            sqlQuery += "\n, Thoigiannhapkq = " + (objInfo.Thoigiannhapkq == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiannhapkq.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery += "\n, Thoigiansuakq = " + (objInfo.Thoigiansuakq == null ? "NULL" : "'" + DateTime.Parse(objInfo.Thoigiansuakq.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery += "\n, Usernhapkq = " + (objInfo.Usernhapkq == null ? "NULL" : "'" + objInfo.Usernhapkq.ToString() + "'");
            sqlQuery += "\n, Usersuakq = " + (objInfo.Usersuakq == null ? "NULL" : "'" + objInfo.Usersuakq.ToString() + "'");
            sqlQuery += "\n, Dathutien = " + (bool.Parse(objInfo.Dathutien.ToString()) ? "1" : "0");
            sqlQuery += "\n, Usernhapcd = " + (objInfo.Usernhapcd == null ? "NULL" : "'" + objInfo.Usernhapcd.ToString() + "'");
            sqlQuery += "\n, Mavattu = " + (objInfo.Mavattu == null ? "NULL" : "'" + objInfo.Mavattu.ToString() + "'");
            sqlQuery += "\n, Dvttieuhao = " + (objInfo.Dvttieuhao == null ? "NULL" : "N'" + objInfo.Dvttieuhao.ToString() + "'");
            sqlQuery += "\n, Tieuhao = " + (string.IsNullOrEmpty(objInfo.Tieuhao.ToString()) ? "1" : objInfo.Tieuhao.ToString());
            sqlQuery += "\n, Chietkhau = " + (string.IsNullOrEmpty(objInfo.Chietkhau.ToString()) ? "0" : objInfo.Chietkhau.ToString());
            sqlQuery += "\n, Tiencong = " + (string.IsNullOrEmpty(objInfo.Tiencong.ToString()) ? "0" : objInfo.Tiencong.ToString());
            sqlQuery += "\n, Hesoquidoi = " + (string.IsNullOrEmpty(objInfo.Hesoquidoi.ToString()) ? "0" : objInfo.Hesoquidoi.ToString());
            sqlQuery += "\n, Ketquaquidoi = " + (objInfo.Ketquaquidoi == null ? "NULL" : objInfo.Ketquaquidoi.ToString());
            sqlQuery += "\n, Donviquidoi = " + (objInfo.Donviquidoi == null ? "NULL" : "N'" + objInfo.Donviquidoi.ToString() + "'");
            sqlQuery += "\n, Csbtquidoi = " + (objInfo.Csbtquidoi == null ? "NULL" : "N'" + objInfo.Csbtquidoi.ToString() + "'");
            sqlQuery += "\n, Dadownload = " + (bool.Parse(objInfo.Dadownload.ToString()) ? "1" : "0");
            sqlQuery += "\n, Idmaydownload = " + (objInfo.Idmaydownload < 0 ? "0" : objInfo.Idmaydownload.ToString());
            sqlQuery += "\n, Idmayxetnghiem = " + (objInfo.Idmayxetnghiem < 0 ? "0" : objInfo.Idmayxetnghiem.ToString());
            sqlQuery += "\n, Tenmayxetnghiem = " + (objInfo.Tenmayxetnghiem == null ? "NULL" : "N'" + objInfo.Tenmayxetnghiem.ToString() + "'");
            sqlQuery += "\n, Maphanloai = " + "'" + objInfo.Maphanloai.ToString() + "'";
            sqlQuery += "\n, Datedownload = " + (objInfo.Datedownload == null ? "NULL" : "'" + DateTime.Parse(objInfo.Datedownload.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sqlQuery += "\n, Maxnmay = " + (objInfo.Maxnmay == null ? "NULL" : "'" + objInfo.Maxnmay.ToString() + "'");
            sqlQuery += "\n, Uploadweb = " + (bool.Parse(objInfo.Uploadweb.ToString()) ? "1" : "0");
            sqlQuery += "\n, Khongin = " + (bool.Parse(objInfo.Khongin.ToString()) ? "1" : "0");
            
            sqlQuery += "\nwhere  Matiepnhan =  " + "'" + objInfo.Matiepnhan.ToString() + "'" + " and Maxn =  " + "'" + objInfo.Maxn.ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        public bool Delete_ketqua_cls_xetnghiem(KETQUA_CLS_XETNGHIEM objInfo)
        {
            string sqlQuery = "Delete ketqua_cls_xetnghiem";
            sqlQuery += "\n where 1=1 ";
            sqlQuery += "\n and Matiepnhan = " + "'" + objInfo.Matiepnhan.ToString() + "'";
            sqlQuery += "\n and Maxn = " + "'" + objInfo.Maxn.ToString() + "'";
            return DataProvider.ExecuteQuery(sqlQuery);
        }

        private string SQLSelect_Data_ketqua_cls_xetnghiem(string matiepnhan, string maxn)
        {
            string strSql = "select * from ketqua_cls_xetnghiem where 1=1";
            if (!string.IsNullOrEmpty(matiepnhan))
                strSql += "\n and  matiepnhan = " + "'" + matiepnhan + "'";
            if (!string.IsNullOrEmpty(maxn))
                strSql += "\n and  maxn = " + "'" + maxn + "'";
            return strSql;
        }
        public DataTable Data_ketqua_cls_xetnghiem(string matiepnhan, string maxn)
        {
            DataTable dtData = new DataTable();
            dtData = DataProvider.ExecuteDataset(CommandType.Text, SQLSelect_Data_ketqua_cls_xetnghiem(matiepnhan, maxn)).Tables[0];
            return dtData;
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem(DataGridView dtg, BindingNavigator bv, string matiepnhan, string maxn)
        {
            DataTable dtData = new DataTable();
            dtData = Data_ketqua_cls_xetnghiem(matiepnhan, maxn);
            ControlExtension.BindDataToGrid(dtData, ref dtg, ref bv, false);
            return dtData;
        }
        public DataTable Get_Data_ketqua_cls_xetnghiem(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, TextBox txt, int LinkColumnIndex, string matiepnhan, string maxn)
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
            DataTable dtData = Data_ketqua_cls_xetnghiem(matiepnhan, maxn);
            cbo.DataSource = dtData.Copy();
            cbo.SelectedIndex = -1; return dtData;
        }
        public KETQUA_CLS_XETNGHIEM Get_Info_ketqua_cls_xetnghiem(string matiepnhan, string maxn)
        {
            DataTable dt = Data_ketqua_cls_xetnghiem(matiepnhan, maxn);

            return Get_Info_ketqua_cls_xetnghiem(dt);
        }
        public KETQUA_CLS_XETNGHIEM Get_Info_ketqua_cls_xetnghiem(DataTable dt)
        {
            KETQUA_CLS_XETNGHIEM obj = new KETQUA_CLS_XETNGHIEM();
            if (dt.Rows.Count > 0)
            {
                obj.Matiepnhan = dt.Rows[0]["matiepnhan"].ToString();
                obj.Maxn = dt.Rows[0]["maxn"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenxn"].ToString()))
                    obj.Tenxn = dt.Rows[0]["tenxn"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketqua"].ToString()))
                    obj.Ketqua = dt.Rows[0]["ketqua"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["ghichu"].ToString()))
                    obj.Ghichu = dt.Rows[0]["ghichu"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["manhomcls"].ToString()))
                    obj.Manhomcls = dt.Rows[0]["manhomcls"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["csbt"].ToString()))
                    obj.Csbt = dt.Rows[0]["csbt"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["donvi"].ToString()))
                    obj.Donvi = dt.Rows[0]["donvi"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguongtren"].ToString()))
                    obj.Nguongtren = float.Parse(dt.Rows[0]["nguongtren"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguongduoi"].ToString()))
                    obj.Nguongduoi = float.Parse(dt.Rows[0]["nguongduoi"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["sapxep"].ToString()))
                    obj.Sapxep = int.Parse(dt.Rows[0]["sapxep"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["indam"].ToString()))
                    obj.Indam = (bool)dt.Rows[0]["indam"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["indamkq"].ToString()))
                    obj.Indamkq = (bool)dt.Rows[0]["indamkq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["kichcochu"].ToString()))
                    obj.Kichcochu = int.Parse(dt.Rows[0]["kichcochu"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["kichcokq"].ToString()))
                    obj.Kichcokq = int.Parse(dt.Rows[0]["kichcokq"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["canhle"].ToString()))
                    obj.Canhle = int.Parse(dt.Rows[0]["canhle"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["thutuin"].ToString()))
                    obj.Thutuin = int.Parse(dt.Rows[0]["thutuin"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["xnchinh"].ToString()))
                    obj.Xnchinh = (bool)dt.Rows[0]["xnchinh"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["khongsudung"].ToString()))
                    obj.Khongsudung = (bool)dt.Rows[0]["khongsudung"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["loaimau"].ToString()))
                    obj.Loaimau = dt.Rows[0]["loaimau"].ToString();
                obj.Thoigiannhap = (DateTime)dt.Rows[0]["thoigiannhap"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["profileid"].ToString()))
                    obj.Profileid = dt.Rows[0]["profileid"].ToString();
                obj.Flat = int.Parse(dt.Rows[0]["flat"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["trangthai"].ToString()))
                    obj.Trangthai = dt.Rows[0]["trangthai"].ToString();
                obj.Xacnhankq = (bool)dt.Rows[0]["xacnhankq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["nguoixacnhan"].ToString()))
                    obj.Nguoixacnhan = dt.Rows[0]["nguoixacnhan"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["dkbatthuong"].ToString()))
                    obj.Dkbatthuong = dt.Rows[0]["dkbatthuong"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tgcoketqua"].ToString()))
                    obj.Tgcoketqua = int.Parse(dt.Rows[0]["tgcoketqua"].ToString());
                obj.Giachuan = decimal.Parse(dt.Rows[0]["giachuan"].ToString());
                obj.Giarieng = decimal.Parse(dt.Rows[0]["giarieng"].ToString());
                obj.Hesoxn = int.Parse(dt.Rows[0]["hesoxn"].ToString());
                obj.Madichvucls = int.Parse(dt.Rows[0]["madichvucls"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiannhapkq"].ToString()))
                    obj.Thoigiannhapkq = (DateTime)dt.Rows[0]["thoigiannhapkq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["thoigiansuakq"].ToString()))
                    obj.Thoigiansuakq = (DateTime)dt.Rows[0]["thoigiansuakq"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["usernhapkq"].ToString()))
                    obj.Usernhapkq = dt.Rows[0]["usernhapkq"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["usersuakq"].ToString()))
                    obj.Usersuakq = dt.Rows[0]["usersuakq"].ToString();
                obj.Dathutien = (bool)dt.Rows[0]["dathutien"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["usernhapcd"].ToString()))
                    obj.Usernhapcd = dt.Rows[0]["usernhapcd"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["mavattu"].ToString()))
                    obj.Mavattu = dt.Rows[0]["mavattu"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["dvttieuhao"].ToString()))
                    obj.Dvttieuhao = dt.Rows[0]["dvttieuhao"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["tieuhao"].ToString()))
                    obj.Tieuhao = float.Parse(dt.Rows[0]["tieuhao"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["chietkhau"].ToString()))
                    obj.Chietkhau = float.Parse(dt.Rows[0]["chietkhau"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["tiencong"].ToString()))
                    obj.Tiencong = decimal.Parse(dt.Rows[0]["tiencong"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["hesoquidoi"].ToString()))
                    obj.Hesoquidoi = float.Parse(dt.Rows[0]["hesoquidoi"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["ketquaquidoi"].ToString()))
                    obj.Ketquaquidoi = float.Parse(dt.Rows[0]["ketquaquidoi"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["donviquidoi"].ToString()))
                    obj.Donviquidoi = dt.Rows[0]["donviquidoi"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["csbtquidoi"].ToString()))
                    obj.Csbtquidoi = dt.Rows[0]["csbtquidoi"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["dadownload"].ToString()))
                    obj.Dadownload = (bool)dt.Rows[0]["dadownload"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["idmaydownload"].ToString()))
                    obj.Idmaydownload = int.Parse(dt.Rows[0]["idmaydownload"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["idmayxetnghiem"].ToString()))
                    obj.Idmayxetnghiem = int.Parse(dt.Rows[0]["idmayxetnghiem"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["tenmayxetnghiem"].ToString()))
                    obj.Tenmayxetnghiem = dt.Rows[0]["tenmayxetnghiem"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["maphanloai"].ToString()))
                    obj.Maphanloai = dt.Rows[0]["maphanloai"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["datedownload"].ToString()))
                    obj.Datedownload = DateTime.Parse(dt.Rows[0]["datedownload"].ToString());
                if (!string.IsNullOrEmpty(dt.Rows[0]["maxnmay"].ToString()))
                    obj.Maxnmay = dt.Rows[0]["maxnmay"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["uploadweb"].ToString()))
                    obj.Uploadweb = (bool)dt.Rows[0]["uploadweb"];
                if (!string.IsNullOrEmpty(dt.Rows[0]["khongin"].ToString()))
                    obj.Khongin = (bool)dt.Rows[0]["khongin"];

            }
            return obj;
        }
        public bool UpdateTrangThaiDoiTacNhanMau(string maTiepNhan, string doiTacNhanMau, string maXN, DateTime ngayGui)
        {
            var para = new SqlParameter[]
            {
                new SqlParameter("@maTiepNhan", maTiepNhan),
                new SqlParameter("@doiTacNhanMau", doiTacNhanMau),
                new SqlParameter("@maXN", maXN),
                new SqlParameter("@ngayGui", ngayGui),

            };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "udpUpdateXetNghiem_DoiTacNhanMau", para) > 0;
        }
    }
}
