using System;
using System.Data;
using System.Data.SqlClient;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.App.AppCode.DAO
{
    public class VT_DM_LOAIVT_DAL
    {
        public VT_DM_LOAIVT_DAL() { }
        public int Insert_Update_VT_DM_LOAIVT(VT_DM_LOAIVT objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_dm_loaivt set";
                strSQL += "\nmaloaivt = @maloaivt,tenloaivt = @tenloaivt where maloaivt = @maloaivt";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_dm_loaivt (";
                strSQL += "\nmaloaivt,tenloaivt)";
                strSQL += "\nValues (@maloaivt,@tenloaivt)";
            }
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivt",objInfo.Maloaivt),
					new SqlParameter("@Tenloaivt",objInfo.Tenloaivt)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public int Delete_VT_DM_LOAIVT(VT_DM_LOAIVT objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_dm_loaivt";
            strSQL += "\n where maloaivt = @maloaivt";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivt", objInfo.Maloaivt)
				};

            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public bool Check_Exists(VT_DM_LOAIVT objInfo)
        {
            string strSQL = "select top 1 * from VT_DM_LoaiVT  where maloaivt = @maloaivt";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivt",objInfo.Maloaivt)
				};
            return DataProvider.CheckExisted(strSQL, param);
        }
        private string SQL_Select_Data_VT_DM_LoaiVT(string _maloaivt)
        {
            string strSQL = "select *  from vt_dm_loaivt where 1=1";
            if (_maloaivt.Trim() != "")
            {
                strSQL += "\nand maloaivt ='" + _maloaivt + "'";
            }
            return strSQL;
        }
        public DataTable Data_VT_DM_LoaiVT(string _maloaivt)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_DM_LoaiVT(_maloaivt)).Tables[0];
        }
        public void Data_VT_DM_LoaiVT(ref SqlDataAdapter da, ref DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, string _maloaivt)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_DM_LoaiVT(_maloaivt), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Data_VT_DM_LoaiVT(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string _maloaivt)
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
            cbo.DataSource = Data_VT_DM_LoaiVT(_maloaivt);
            cbo.SelectedIndex = -1;
        }
        public void Update_DataTable_VT_DM_LoaiVT(ref SqlDataAdapter da, ref DataTable dt, TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }
    public class VT_DM_NHOMVT_DAL
    {
        
        public VT_DM_NHOMVT_DAL() {  }
        public int Insert_Update_VT_DM_NHOMVT(VT_DM_NHOMVT objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_dm_nhomvt set";
                strSQL += "\nmaloaivt = @maloaivt,manhomvt = @manhomvt,tennhomvt = @tennhomvt where manhomvt = @manhomvt";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_dm_nhomvt (";
                strSQL += "\nmaloaivt,manhomvt,tennhomvt)";
                strSQL += "\nValues (@maloaivt,@manhomvt,@tennhomvt)";
            }
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivt",objInfo.Maloaivt),
					new SqlParameter("@Manhomvt",objInfo.Manhomvt),
					new SqlParameter("@Tennhomvt",objInfo.Tennhomvt)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public int Delete_VT_DM_NHOMVT(VT_DM_NHOMVT objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_dm_nhomvt";
            strSQL += "\n where manhomvt = @manhomvt";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Manhomvt",objInfo.Manhomvt)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public bool Check_Exists(VT_DM_NHOMVT objInfo)
        {
            string strSQL = "select top 1 * from VT_DM_NhomVT  where manhomvt = @manhomvt";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Manhomvt",objInfo.Manhomvt)
				};
            return DataProvider.CheckExisted(strSQL, param);
        }
        private string SQL_Select_Data_VT_DM_NhomVT(string _maloaivt, string _manhomvt)
        {
            string strSQL = "select *  from vt_dm_nhomvt where 1=1";
            if (_maloaivt.Trim() != "")
            {
                strSQL += "\nand maloaivt ='" + _maloaivt + "'";
            }
            if (_manhomvt.Trim() != "")
            {
                strSQL += "\nand manhomvt ='" + _manhomvt + "'";
            }
            return strSQL;
        }
        public DataTable Data_VT_DM_NhomVT(string _maloaivt, string _manhomvt)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_DM_NhomVT(_maloaivt, _manhomvt)).Tables[0];
        }
        public void Data_VT_DM_NhomVT(ref SqlDataAdapter da, ref DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, string _maloaivt, string _manhomvt)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_DM_NhomVT(_maloaivt, _manhomvt), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Data_VT_DM_NhomVT(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string _maloaivt, string _manhomvt)
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
            cbo.DataSource = Data_VT_DM_NhomVT(_maloaivt, _manhomvt);
            cbo.SelectedIndex = -1;
        }
        public void Update_DataTable_VT_DM_NhomVT(ref SqlDataAdapter da, ref DataTable dt, TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }
    public class VT_DM_VATTU_DAL
    {
        
        public VT_DM_VATTU_DAL() {  }
        public int Insert_Update_VT_DM_VATTU(VT_DM_VATTU objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_dm_vattu set";
                strSQL += "\ncohsd = @cohsd,donvitinh = @donvitinh,dvtquicachcap1 = @dvtquicachcap1,dvtquicachcap2 = @dvtquicachcap2,dvttieuhao = @dvttieuhao,maloaivt = @maloaivt,manhomvt = @manhomvt,mavattu = @mavattu,slcothedung = @slcothedung,sldgtieuhao = @sldgtieuhao";
                strSQL += "\n,slquicachcap1 = @slquicachcap1,slquicachcap2 = @slquicachcap2,tenvattu = @tenvattu,tieuhao = @tieuhao,xuattheoqcdg = @xuattheoqcdg where mavattu = @mavattu";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_dm_vattu (";
                strSQL += "\ncohsd,donvitinh,dvtquicachcap1,dvtquicachcap2,dvttieuhao,maloaivt,manhomvt,mavattu,slcothedung,sldgtieuhao";
                strSQL += "\n,slquicachcap1,slquicachcap2,tenvattu,tieuhao,xuattheoqcdg)";
                strSQL += "\nValues (@cohsd,@donvitinh,@dvtquicachcap1,@dvtquicachcap2,@dvttieuhao,@maloaivt,@manhomvt,@mavattu,@slcothedung,@sldgtieuhao";
                strSQL += "\n,@slquicachcap1,@slquicachcap2,@tenvattu,@tieuhao,@xuattheoqcdg)";
            }
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Cohsd",objInfo.Cohsd),
					new SqlParameter("@Donvitinh",objInfo.Donvitinh),
					new SqlParameter("@Dvtquicachcap1",objInfo.Dvtquicachcap1),
					new SqlParameter("@Dvtquicachcap2",objInfo.Dvtquicachcap2),
					new SqlParameter("@Dvttieuhao",objInfo.Dvttieuhao),
					new SqlParameter("@Maloaivt",objInfo.Maloaivt),
					new SqlParameter("@Manhomvt",objInfo.Manhomvt),
					new SqlParameter("@Mavattu",objInfo.Mavattu),
					new SqlParameter("@Slcothedung",objInfo.Slcothedung),
					new SqlParameter("@Sldgtieuhao",objInfo.Sldgtieuhao),
					new SqlParameter("@Slquicachcap1",objInfo.Slquicachcap1),
					new SqlParameter("@Slquicachcap2",objInfo.Slquicachcap2),
					new SqlParameter("@Tenvattu",objInfo.Tenvattu),
					new SqlParameter("@Tieuhao",objInfo.Tieuhao),
					new SqlParameter("@Xuattheoqcdg",objInfo.Xuattheoqcdg)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public int Delete_VT_DM_VATTU(VT_DM_VATTU objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_dm_vattu";
            strSQL += "\n where mavattu = @mavattu";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Mavattu",objInfo.Mavattu)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public bool Check_Exists(VT_DM_VATTU objInfo)
        {
            string strSQL = "select top 1 * from VT_DM_VatTu  where mavattu = @mavattu";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Mavattu",objInfo.Mavattu)
				};
            return DataProvider.CheckExisted(strSQL, param);
        }
        private string SQL_Select_Data_VT_DM_VatTu(string _maloaivt, string _manhomvt, string _mavattu)
        {
            string strSQL = "select *  from vt_dm_vattu where 1=1";
            if (_maloaivt.Trim() != "")
            {
                strSQL += "\nand maloaivt ='" + _maloaivt + "'";
            }
            if (_manhomvt.Trim() != "")
            {
                strSQL += "\nand manhomvt ='" + _manhomvt + "'";
            }
            if (_mavattu.Trim() != "")
            {
                strSQL += "\nand mavattu ='" + _mavattu + "'";
            }
            return strSQL;
        }
        public DataTable Data_VT_DM_VatTu(string _maloaivt, string _manhomvt, string _mavattu)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_DM_VatTu(_maloaivt, _manhomvt, _mavattu)).Tables[0];
        }
        public void Data_VT_DM_VatTu(ref SqlDataAdapter da, ref DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, string _maloaivt, string _manhomvt, string _mavattu)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_DM_VatTu(_maloaivt, _manhomvt, _mavattu), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Data_VT_DM_VatTu(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string _maloaivt, string _manhomvt, string _mavattu)
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
            cbo.DataSource = Data_VT_DM_VatTu(_maloaivt, _manhomvt, _mavattu);
            cbo.SelectedIndex = -1;
        }
        public void Update_DataTable_VT_DM_VatTu(ref SqlDataAdapter da, ref DataTable dt, TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }
    public class VT_DONVITINH_DAL
    {
        
        public VT_DONVITINH_DAL() {  }
        public int Insert_Update_VT_DONVITINH(VT_DONVITINH objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_donvitinh set";
                strSQL += "\nid = @id,unitname = @unitname where id = @id";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_donvitinh (";
                strSQL += "\nid,unitname)";
                strSQL += "\nValues (@id,@unitname)";
            }
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Id",objInfo.Id),
					new SqlParameter("@Unitname",objInfo.Unitname)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public int Delete_VT_DONVITINH(VT_DONVITINH objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_donvitinh";
            strSQL += "\n where id = @id";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Id",objInfo.Id)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public bool Check_Exists(VT_DONVITINH objInfo)
        {
            string strSQL = "select top 1 * from VT_DonViTinh  where id = @id";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Id",objInfo.Id)
				};
            return DataProvider.CheckExisted(strSQL, param);
        }
        private string SQL_Select_Data_VT_DonViTinh(string _id)
        {
            string strSQL = "select *  from vt_donvitinh where 1=1";
            if (_id.Trim() != "")
            {
                strSQL += "\nand id ='" + _id + "'";
            }
            return strSQL;
        }
        public DataTable Data_VT_DonViTinh(string _id)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_DonViTinh(_id)).Tables[0];
        }
        public void Data_VT_DonViTinh(ref SqlDataAdapter da, ref DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, string _id)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_DonViTinh(_id), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Data_VT_DonViTinh(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string _id)
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
            cbo.DataSource = Data_VT_DonViTinh(_id);
            cbo.SelectedIndex = -1;
        }
        public void Update_DataTable_VT_DonViTinh(ref SqlDataAdapter da, ref DataTable dt, TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }
    public class VT_DM_NHACUNGCAP_DAL
    {
        
        public VT_DM_NHACUNGCAP_DAL() {  }
        public int Insert_Update_VT_DM_NHACUNGCAP(VT_DM_NHACUNGCAP objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_dm_nhacungcap set";
                strSQL += "\ndiachi = @diachi,dienthoai = @dienthoai,email = @email,ghichu = @ghichu,gotat = @gotat,manhacungcap = @manhacungcap,tennhacungcap = @tennhacungcap where manhacungcap = @manhacungcap";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_dm_nhacungcap (";
                strSQL += "\ndiachi,dienthoai,email,ghichu,gotat,manhacungcap,tennhacungcap)";
                strSQL += "\nValues (@diachi,@dienthoai,@email,@ghichu,@gotat,@manhacungcap,@tennhacungcap)";
            }
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Diachi",objInfo.Diachi),
					new SqlParameter("@Dienthoai",objInfo.Dienthoai),
					new SqlParameter("@Email",objInfo.Email),
					new SqlParameter("@Ghichu",objInfo.Ghichu),
					new SqlParameter("@Gotat",objInfo.Gotat),
					new SqlParameter("@Manhacungcap",objInfo.Manhacungcap),
					new SqlParameter("@Tennhacungcap",objInfo.Tennhacungcap)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public int Delete_VT_DM_NHACUNGCAP(VT_DM_NHACUNGCAP objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_dm_nhacungcap";
            strSQL += "\n where manhacungcap = @manhacungcap";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Manhacungcap",objInfo.Manhacungcap)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public bool Check_Exists(VT_DM_NHACUNGCAP objInfo)
        {
            string strSQL = "select top 1 * from VT_DM_NhaCungCap  where manhacungcap = @manhacungcap";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Manhacungcap",objInfo.Manhacungcap)
				};
            return DataProvider.CheckExisted(strSQL, param);
        }
        private string SQL_Select_Data_VT_DM_NhaCungCap(string _manhacungcap)
        {
            string strSQL = "select *  from vt_dm_nhacungcap where 1=1";
            if (_manhacungcap.Trim() != "")
            {
                strSQL += "\nand manhacungcap ='" + _manhacungcap + "'";
            }
            return strSQL;
        }
        public DataTable Data_VT_DM_NhaCungCap(string _manhacungcap)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_DM_NhaCungCap(_manhacungcap)).Tables[0];
        }
        public void Data_VT_DM_NhaCungCap(ref SqlDataAdapter da, ref DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, string _manhacungcap)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_DM_NhaCungCap(_manhacungcap), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Data_VT_DM_NhaCungCap(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string _manhacungcap)
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
            cbo.DataSource = Data_VT_DM_NhaCungCap(_manhacungcap);
            cbo.SelectedIndex = -1;
        }
        public void Update_DataTable_VT_DM_NhaCungCap(ref SqlDataAdapter da, ref DataTable dt, TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }
    public class VT_NHACUNGCAP_VATTU_DAL
    {
        
        public VT_NHACUNGCAP_VATTU_DAL() {  }
        public int Insert_Update_VT_NHACUNGCAP_VATTU(VT_NHACUNGCAP_VATTU objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_nhacungcap_vattu set";
                strSQL += "\nmaloaivattu = @maloaivattu,manhacungcap = @manhacungcap,mavattu = @mavattu where maloaivattu = @maloaivattu and manhacungcap = @manhacungcap and mavattu = @mavattu";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_nhacungcap_vattu (";
                strSQL += "\nmaloaivattu,manhacungcap,mavattu)";
                strSQL += "\nValues (@maloaivattu,@manhacungcap,@mavattu)";
            }
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivattu",objInfo.Maloaivattu),
					new SqlParameter("@Manhacungcap",objInfo.Manhacungcap),
					new SqlParameter("@Mavattu",objInfo.Mavattu)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public int Delete_VT_NHACUNGCAP_VATTU(VT_NHACUNGCAP_VATTU objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_nhacungcap_vattu";
            strSQL += "\n where maloaivattu = @maloaivattu and manhacungcap = @manhacungcap and mavattu = @mavattu";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivattu",objInfo.Maloaivattu),
					new SqlParameter("@Manhacungcap",objInfo.Manhacungcap),
					new SqlParameter("@Mavattu",objInfo.Mavattu)
				};
            return (int)DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }
        public bool Check_Exists(VT_NHACUNGCAP_VATTU objInfo)
        {
            string strSQL = "select top 1 * from VT_NhaCungCap_VatTu  where maloaivattu = @maloaivattu and manhacungcap = @manhacungcap and mavattu = @mavattu";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@Maloaivattu",objInfo.Maloaivattu),
					new SqlParameter("@Manhacungcap",objInfo.Manhacungcap),
					new SqlParameter("@Mavattu",objInfo.Mavattu)
				};
            return DataProvider.CheckExisted(strSQL, param);
        }
        private string SQL_Select_Data_VT_NhaCungCap_VatTu(string _maloaivattu, string _manhacungcap, string _mavattu)
        {
            string strSQL = "";
            strSQL = "select t.TenThuoc as TenVatTu, t.MaThuoc as MaVatTu, v.MaLoaiVatTu, v.MaNhaCungCap from VT_NhaCungCap_VatTu v inner join {{TPH_Standard}}_Dictionary.dbo.dm_Thuoc t on (t.MaThuoc = v.MaVatTu and v.MaLoaiVatTu = 'THUOC') where 1=1 ";
            if (_maloaivattu.Trim() != "")
            {
                strSQL += "\nand v.maloaivattu ='" + _maloaivattu + "'";
            }
            if (_manhacungcap.Trim() != "")
            {
                strSQL += "\nand v.manhacungcap ='" + _manhacungcap + "'";
            }
            if (_mavattu.Trim() != "")
            {
                strSQL += "\nand v.mavattu ='" + _mavattu + "'";
            }
            strSQL += "\nUnion all \n";
            strSQL += "select t.TenVatTu as  TenVatTu, t.MaVatTu as MaVatTu, v.MaLoaiVatTu, v.MaNhaCungCap from VT_NhaCungCap_VatTu v inner join VT_DM_VatTu t on (t.mavattu = v.MaVatTu and v.MaLoaiVatTu not in('THUOC')) where 1=1 ";
            if (_maloaivattu.Trim() != "")
            {
                strSQL += "\nand v.maloaivattu ='" + _maloaivattu + "'";
            }
            if (_manhacungcap.Trim() != "")
            {
                strSQL += "\nand v.manhacungcap ='" + _manhacungcap + "'";
            }
            if (_mavattu.Trim() != "")
            {
                strSQL += "\nand v.mavattu ='" + _mavattu + "'";
            }
            return strSQL;
        }
        public DataTable Data_VT_NhaCungCap_VatTu(string _maloaivattu, string _manhacungcap, string _mavattu)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_NhaCungCap_VatTu(_maloaivattu, _manhacungcap, _mavattu)).Tables[0];
        }
        public void Data_VT_NhaCungCap_VatTu(ref SqlDataAdapter da, ref DataTable dt, ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv, string _maloaivattu, string _manhacungcap, string _mavattu)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_NhaCungCap_VatTu(_maloaivattu, _manhacungcap, _mavattu), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }
        public void Data_VT_NhaCungCap_VatTu(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex, string _maloaivattu, string _manhacungcap, string _mavattu)
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
            cbo.DataSource = Data_VT_NhaCungCap_VatTu(_maloaivattu, _manhacungcap, _mavattu);
            cbo.SelectedIndex = -1;
        }
        public void Update_DataTable_VT_NhaCungCap_VatTu(ref SqlDataAdapter da, ref DataTable dt, TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }
    public class VT_THONGKE_DAL
    {        
        
        public VT_THONGKE_DAL() {  }
        public DataTable Data_NhapXuatTon_Thuoc(DateTime dateFrom, DateTime dateTo, string _MaVatTu, string _NhomVatTu, string _NhaCungCap, string _NguoiNhap)
        {
            string strSQL = "";
            strSQL = "select A.MaVatTu, A.TenThuoc as TenVatTu, sum(A.NhapDauKy) - sum(A.XuatDauKy) as TonDau, sum(A.NhapTrongKy) as Nhap, Sum(A.XuatTrongKy) as Xuat,  (sum(A.NhapDauKy) - sum(A.XuatDauKy) + sum(A.NhapTrongKy)) - Sum(A.XuatTrongKy) as TonCuoi,A.DonViTinh,A.TenNhaCungCap";
            strSQL += "\nfrom";
            strSQL += "\n(";
            strSQL += "\nselect d.MaVatTu, d.TenThuoc,ncc.TenNhaCungCap,case when d.XuatTheoQCDG = 1 then d.DVTQuiCachCap1 else d.DonViTinh end as DonViTinh,  sum (case when d.XuatTheoQCDG = 1 then d.SoLuongTheoQuiCach else d.SoLuongNhap end )  as NhapDauKy, 0 as XuatDauKy, 0 as NhapTrongKy, 0 as XuatTrongKy";
            strSQL += "\nfrom VT_NhapKho_ChietTiet_Thuoc d inner join VT_NhapKho_PhieuNhap_Thuoc p on d.MaPhieuNhap = p.MaPhieuNhap";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on d.MaGocThuoc = g.MaGocThuoc";
            strSQL += "\nleft join VT_DM_NhaCungCap ncc on ncc.MaNhaCungCap = d.MaNhaCungCap";
            strSQL += "\nwhere p.TGNhap < @DateFrom";
            strSQL += "\nand d.MaVatTu = isnull(nullif(rtrim(@MaVatTu),''),d.MaVatTu)";
            strSQL += "\nand d.MaNhaCungCap = isnull(nullif(rtrim(@MaNhaCungCap),''),d.MaNhaCungCap)";
            strSQL += "\nand p.NguoiNhap = isnull(nullif(rtrim(@NguoiNhap),''),p.NguoiNhap)";
            strSQL += "\nand g.MaNhomThuoc = isnull(nullif(rtrim(@MaNhomVatTu),''),g.MaNhomThuoc)";
            strSQL += "\ngroup by d.MaVatTu, d.TenThuoc,ncc.TenNhaCungCap,d.XuatTheoQCDG,d.DVTQuiCachCap1, d.DonViTinh";
            strSQL += "\nunion all";
            strSQL += "\nselect d.MaThuoc as MaVatTu, d.TenThuoc,ncc.TenNhaCungCap,case when d.XuatTheoQCDG = 1 then d.DVTQuiCachCap1 else d.DonViTinh end as DonViTinh, 0 as NhapDauKy, sum(SoLuong) as XuatDauKy, 0 as NhapTrongKy, 0 as XuatTrongKy  ";
            strSQL += "\nfrom VT_XuatKho_ChiTiet_Thuoc d inner join VT_XuatKho_PhieuXuat_Thuoc p on d.MaPhieuXuat = p.MaPhieuXuat";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on d.MaGocThuoc = g.MaGocThuoc";
            strSQL += "\nleft join VT_DM_NhaCungCap ncc on ncc.MaNhaCungCap = d.MaNhaCungCap";
            strSQL += "\nwhere p.TGNhap < @DateFrom";
            strSQL += "\nand d.MaVatTu = isnull(nullif(rtrim(@MaVatTu),''),d.MaVatTu)";
            strSQL += "\nand d.MaNhaCungCap = isnull(nullif(rtrim(@MaNhaCungCap),''),d.MaNhaCungCap)";
            strSQL += "\nand p.NguoiNhap = isnull(nullif(rtrim(@NguoiNhap),''),p.NguoiNhap)";
            strSQL += "\nand g.MaNhomThuoc = isnull(nullif(rtrim(@MaNhomVatTu),''),g.MaNhomThuoc)";
            strSQL += "\ngroup by d.MaThuoc, d.TenThuoc,ncc.TenNhaCungCap,d.XuatTheoQCDG,d.DVTQuiCachCap1, d.DonViTinh";
            strSQL += "\nunion all";
            strSQL += "\nselect d.MaVatTu, d.TenThuoc,ncc.TenNhaCungCap,case when d.XuatTheoQCDG = 1 then d.DVTQuiCachCap1 else d.DonViTinh end as DonViTinh,0  as  NhapDauKy, 0 as XuatDauKy,   sum (case when d.XuatTheoQCDG = 1 then d.SoLuongTheoQuiCach else d.SoLuongNhap end ) as NhapTrongKy, 0 as XuatTrongKy ";
            strSQL += "\nfrom VT_NhapKho_ChietTiet_Thuoc d inner join VT_NhapKho_PhieuNhap_Thuoc p on d.MaPhieuNhap = p.MaPhieuNhap";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on d.MaGocThuoc = g.MaGocThuoc";
            strSQL += "\nleft join VT_DM_NhaCungCap ncc on ncc.MaNhaCungCap = d.MaNhaCungCap";
            strSQL += "\nwhere p.TGNhap between @DateFrom and @DateTo";
            strSQL += "\nand d.MaVatTu = isnull(nullif(rtrim(@MaVatTu),''),d.MaVatTu)";
            strSQL += "\nand d.MaNhaCungCap = isnull(nullif(rtrim(@MaNhaCungCap),''),d.MaNhaCungCap)";
            strSQL += "\nand p.NguoiNhap = isnull(nullif(rtrim(@NguoiNhap),''),p.NguoiNhap)";
            strSQL += "\nand g.MaNhomThuoc = isnull(nullif(rtrim(@MaNhomVatTu),''),g.MaNhomThuoc)";
            strSQL += "\ngroup by d.MaVatTu, d.TenThuoc,ncc.TenNhaCungCap,d.XuatTheoQCDG,d.DVTQuiCachCap1, d.DonViTinh";
            strSQL += "\nunion all";
            strSQL += "\nselect d.MaThuoc as MaVatTu, d.TenThuoc,ncc.TenNhaCungCap,case when d.XuatTheoQCDG = 1 then d.DVTQuiCachCap1 else d.DonViTinh end as DonViTinh,0  as  NhapDauKy, 0 as XuatDauKy, 0 as NhapTrongKy, sum(SoLuong) as XuatTrongKy ";
            strSQL += "\nfrom VT_XuatKho_ChiTiet_Thuoc d inner join VT_XuatKho_PhieuXuat_Thuoc p on d.MaPhieuXuat = p.MaPhieuXuat";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on d.MaGocThuoc = g.MaGocThuoc";
            strSQL += "\nleft join VT_DM_NhaCungCap ncc on ncc.MaNhaCungCap = d.MaNhaCungCap";
            strSQL += "\nwhere p.TGNhap between @DateFrom and @DateTo";
            strSQL += "\nand d.MaVatTu = isnull(nullif(rtrim(@MaVatTu),''),d.MaVatTu)";
            strSQL += "\nand d.MaNhaCungCap = isnull(nullif(rtrim(@MaNhaCungCap),''),d.MaNhaCungCap)";
            strSQL += "\nand p.NguoiNhap = isnull(nullif(rtrim(@NguoiNhap),''),p.NguoiNhap)";
            strSQL += "\nand g.MaNhomThuoc = isnull(nullif(rtrim(@MaNhomVatTu),''),g.MaNhomThuoc)";
            strSQL += "\ngroup by d.MaThuoc, d.TenThuoc,ncc.TenNhaCungCap,d.XuatTheoQCDG,d.DVTQuiCachCap1, d.DonViTinh";
            strSQL += "\n) as A";
            strSQL += "\nGroup by a.MaVatTu, a.TenThuoc, a.TenNhaCungCap, a.DonViTinh";
            SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@DateFrom",dateFrom),
					new SqlParameter("@DateTo",dateTo),
					new SqlParameter("@MaVatTu",_MaVatTu),
                    new SqlParameter("@MaNhaCungCap",_NhaCungCap),
					new SqlParameter("@NguoiNhap",_NguoiNhap),
					new SqlParameter("@MaNhomVatTu",_NhomVatTu)
				};
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL, param).Tables[0];
        }
    }
}
