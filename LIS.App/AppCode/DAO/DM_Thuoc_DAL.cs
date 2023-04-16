using System;
using System.Data;
using System.Data.SqlClient;
using TPH.LIS.App.AppCode.PropertiesMember;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.App.AppCode.DAO
{
    public class DM_THUOC_DAL
    {
        public int Insert_Update_DM_THUOC(DM_THUOC objInfo, bool isUpdate)
        {
            var strSql = "";
            if (isUpdate)
            {
                strSql = "Update {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc set";
                strSql +=
                    "\ncachdung = @cachdung,chieu = @chieu,cohsd = @cohsd,donvitinh = @donvitinh,dvtquicachcap1 = @dvtquicachcap1,dvtquicachcap2 = @dvtquicachcap2,gia = @gia,gotat = @gotat,magocthuoc = @magocthuoc";
                strSql +=
                    "\n,mathuoc = @mathuoc,mavattu = @mavattu,sang = @sang,sapxep = @sapxep,slquicachcap1 = @slquicachcap1,slquicachcap2 = @slquicachcap2,tenthuoc = @tenthuoc,toi = @toi,trua = @trua,xuattheoqcdg = @xuattheoqcdg where mathuoc = @mathuoc";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\r\nHãy nhập mã khác !");
                    return -1;
                }
                strSql = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc (";
                strSql += "\ncachdung,chieu,cohsd,donvitinh,dvtquicachcap1,dvtquicachcap2,gia,gotat,magocthuoc";
                strSql += "\n,mathuoc,mavattu,sang,sapxep,slquicachcap1,slquicachcap2,tenthuoc,toi,trua,xuattheoqcdg)";
                strSql +=
                    "\nValues (@cachdung,@chieu,@cohsd,@donvitinh,@dvtquicachcap1,@dvtquicachcap2,@gia,@gotat,@magocthuoc";
                strSql +=
                    "\n,@mathuoc,@mavattu,@sang,@sapxep,@slquicachcap1,@slquicachcap2,@tenthuoc,@toi,@trua,@xuattheoqcdg)";
            }

            var param = new SqlParameter[]
            {
                new SqlParameter("@Cachdung", objInfo.Cachdung),
                new SqlParameter("@Chieu", objInfo.Chieu),
                new SqlParameter("@Cohsd", objInfo.Cohsd),
                new SqlParameter("@Donvitinh", objInfo.Donvitinh),
                new SqlParameter("@Dvtquicachcap1", objInfo.Dvtquicachcap1),
                new SqlParameter("@Dvtquicachcap2", objInfo.Dvtquicachcap2),
                new SqlParameter("@Gia", objInfo.Gia),
                new SqlParameter("@Gotat", objInfo.Gotat),
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Mavattu", objInfo.Mavattu),
                new SqlParameter("@Sang", objInfo.Sang),
                new SqlParameter("@Sapxep", objInfo.Sapxep),
                new SqlParameter("@Slquicachcap1", objInfo.Slquicachcap1),
                new SqlParameter("@Slquicachcap2", objInfo.Slquicachcap2),
                new SqlParameter("@Tenthuoc", objInfo.Tenthuoc),
                new SqlParameter("@Toi", objInfo.Toi),
                new SqlParameter("@Trua", objInfo.Trua),
                new SqlParameter("@Xuattheoqcdg", objInfo.Xuattheoqcdg)
            };

            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSql, param);
        }

        public int Delete_DM_THUOC(DM_THUOC objInfo)
        {
            var strSql = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc";
            strSql += "\n where mathuoc = @mathuoc";
            var param = new SqlParameter[]
            {
                new SqlParameter("@Mathuoc", objInfo.Mathuoc)
            };

            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSql, param);
        }

        public bool Check_Exists(DM_THUOC objInfo)
        {
            var strSql = "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc  where mathuoc = @mathuoc";
            var param = new SqlParameter[]
            {
                new SqlParameter("@Mathuoc", objInfo.Mathuoc)
            };

            return DataProvider.CheckExisted(strSql, param);
        }

        private string SQL_Select_Data_DM_Thuoc(string mathuoc, string maGocThuoc)
        {
            var strSql = "select *  from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(mathuoc.Trim()))
            {
                strSql += "\nand mathuoc ='" + mathuoc + "'";
            }
            if (!string.IsNullOrWhiteSpace(maGocThuoc.Trim()))
            {
                strSql += "\nand MaGocThuoc = '" + maGocThuoc + "'";
            }

            return strSql;
        }

        private string SQL_Select_Data_DMThuoc_ForIn_Output(string manhacungcap, string manhomthuoc)
        {
            var strSql =
                "\nselect t.MaThuoc as MaVatTu, t.TenThuoc as TenVatTu,CoHSD, case when t.XuatTheoQCDG = 1 then t.DVTQuiCachCap1 else T.DonViTinh end as DonViTinh , v.MaLoaiVatTu, v.MaNhaCungCap from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t inner join VT_NhaCungCap_VatTu v on (v.MaVatTu = t.MaThuoc and MaLoaiVatTu = 'THUOC')";
            strSql += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on t.MaGocThuoc = g.MaGocThuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(manhacungcap))
            {
                strSql += "\nand v.MaNhaCungCap = '" + manhacungcap.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(manhomthuoc))
            {
                strSql += "\n and g.MaNhomThuoc = '" + manhomthuoc + "'";
            }

            return strSql;
        }

        private string SQL_Select_Data_DMThuoc_ForWork(string manhacungcap, string manhomthuoc, string maDoiTuongDv)
        {
            var strSql = "Select A.*,isnull(C.TonKho,0) as TonKho, isnull(dv.GiaRieng, 0) as  GiaRieng from (";
            strSql +=
                "\nselect t.MaThuoc as MaVatTu, t.TenThuoc as TenVatTu,CoHSD, case when t.XuatTheoQCDG = 1 then t.DVTQuiCachCap1 else T.DonViTinh end as DonViTinh  from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t ";
            strSql += "\n inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on t.MaGocThuoc = g.MaGocThuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(manhacungcap ))
            {
                strSql += "\nand v.MaNhaCungCap = '" + manhacungcap.Trim() + "'";
            }
            if (!string.IsNullOrWhiteSpace(manhomthuoc))
            {
                strSql += "\n and g.MaNhomThuoc = '" + manhomthuoc + "'";
            }
            strSql += "\n) as A";
            strSql += "\nLeft join ( ";
            strSql += "\nSelect sum(B.TonKho - B.SLX) as TonKho, B.MaVatTu";
            strSql += "\nfrom (";
            strSql += "\n\t select 0 as TonKho, sum(soluong) as SLX, MaThuoc as MaVatTu  from ThuPhi_Thuoc";
            strSql += "\n\t Group by MaThuoc";
            strSql += "\n\t union ";
            strSql +=
                "\n\t select sum(case when XuatTheoQCDG = 1 then SoLuongTheoQuiCach else SoLuongNhap end) as TonKho , 0 as SLX, MaVatTu as MaVatTu";
            strSql += "\n\t from VT_NhapKho_ChietTiet_Thuoc";
            strSql += "\n\t Group by MaVatTu";
            strSql += "\n\t ) as B Group by B.MaVatTu";
            strSql += "\n) as C on A.MaVatTu = C.MaVatTu";
            strSql += "\nleft join {{TPH_Standard}}_Dictionary.dbo.dm_doituongdichvu_gia dv on (dv.MaDichVu = A.MaVatTu and dv.MaDoiTuongDichVu = '" +
                      maDoiTuongDv.Trim() + "') ";

            return strSql;
        }

        private string SQL_Select_Data_DM_Thuoc(string mathuoc, string maGocThuoc, string manhomthuoc)
        {
            var strSql =
                "select t.*, g.MaNhomThuoc from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on g.MaGocThuoc = t.MaGocThuoc where 1=1";
            if (!string.IsNullOrWhiteSpace(mathuoc.Trim()))
            {
                strSql += "\nand t.mathuoc ='" + mathuoc + "'";
            }
            if (!string.IsNullOrWhiteSpace(manhomthuoc.Trim() ))
            {
                strSql += "\nand g.MaNhomThuoc = '" + manhomthuoc + "'";
            }
            if (!string.IsNullOrWhiteSpace(maGocThuoc.Trim() ))
            {
                strSql += "\nand t.MaGocThuoc = '" + maGocThuoc + "'";
            }

            return strSql;
        }

        public DataTable Data_DM_Thuoc(string mathuoc)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_DM_Thuoc(mathuoc, "", "")).Tables[0];
        }

        public DataTable Data_DM_Thuoc(string mathuoc, string maGocThuoc, string manhomthuoc)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_DM_Thuoc(mathuoc, "", manhomthuoc))
                    .Tables[0];
        }

        public DataTable Data_DM_Thuoc(string mathuoc, string maGocThuoc)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_DM_Thuoc(mathuoc, maGocThuoc)).Tables[0];
        }

        public void Data_DM_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string mathuoc, string maGocthuoc)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_DM_Thuoc(mathuoc, maGocthuoc), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_DM_Thuoc(CustomComboBox cbo, string valueColumn, string displayColumn,
            string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex,
            string _mathuoc, string _MaGocThuoc, string _ManhomThuoc)
        {
            cbo.ValueMember = valueColumn;
            cbo.DisplayMember = displayColumn;
            cbo.ColumnNames = ColumnsName;
            cbo.ColumnWidths = ColumnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = LinkColumnIndex;
            }
            cbo.DataSource = Data_DM_Thuoc(_mathuoc, _MaGocThuoc, _ManhomThuoc);
            cbo.SelectedIndex = -1;
        }

        public DataTable Data_DM_Thuoc_ForWork(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
            string maNhaCungCap, string manhomThuoc, string doiTuongDv)
        {
            var dt =
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_DMThuoc_ForWork(maNhaCungCap, manhomThuoc, doiTuongDv)).Tables[0];
            if (cbo != null)
            {
                ControlExtension.BindDataToCobobox(dt, ref cbo, valueColumn, displayColumn, columnsName, columnsWidth,
                    txt, linkColumnIndex);
            }
            return dt;
        }

        public void Data_DM_Thuoc_ForInput(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex,
            string maNhaCungCap, string manhomThuoc)
        {
            cbo.ValueMember = valueColumn;
            cbo.DisplayMember = displayColumn;
            cbo.ColumnNames = columnsName;
            cbo.ColumnWidths = columnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = linkColumnIndex;
            }
            var dt =
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_DMThuoc_ForIn_Output(maNhaCungCap, manhomThuoc)).Tables[0];
            cbo.DataSource = dt;
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_DM_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class DM_THUOC_CACHDUNG_DAL
    {
        
        public int Insert_Update_DM_THUOC_CACHDUNG(DM_THUOC_CACHDUNG objInfo, bool isUpdate)
        {
            var strSql = "";
            if (isUpdate)
            {
                strSql = "Update {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_cachdung set";
                strSql += "\nid = @id,tencachdung = @tencachdung where id = @id";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSql = "Insert into {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_cachdung (";
                strSql += "\nid,tencachdung)";
                strSql += "\nValues (@id,@tencachdung)";
            }
            var param = new SqlParameter[]
            {
                new SqlParameter("@Id", objInfo.Id),
                new SqlParameter("@Tencachdung", objInfo.Tencachdung)
            };

            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSql, param);
        }

        public int Delete_DM_THUOC_CACHDUNG(DM_THUOC_CACHDUNG objInfo)
        {
            var strSql = "Delete {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_cachdung";
            strSql += "\n where id = @id";
            var param = new SqlParameter[]
            {
                new SqlParameter("@Id", objInfo.Id)
            };

            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSql, param);
        }

        public bool Check_Exists(DM_THUOC_CACHDUNG objInfo)
        {
            var strSql = "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung  where id = @id";
            var param = new SqlParameter[]
            {
                new SqlParameter("@Id", objInfo.Id)
            };
            return DataProvider.CheckExisted(strSql, param);
        }

        private string SQL_Select_Data_DM_Thuoc_CachDung(string id)
        {
            var strSql = "select *  from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_cachdung where 1=1";
            if (!string.IsNullOrWhiteSpace(id.Trim()))
            {
                strSql += "\nand id ='" + id + "'";
            }

            return strSql;
        }

        public DataTable Data_DM_Thuoc_CachDung(string id)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_DM_Thuoc_CachDung(id)).Tables[0];
        }

        public void Data_DM_Thuoc_CachDung(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string id)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_DM_Thuoc_CachDung(id), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_DM_Thuoc_CachDung(CustomComboBox cbo, string valueColumn, string displayColumn,
            string columnsName, string columnsWidth, System.Windows.Forms.TextBox txt, int linkColumnIndex, string id)
        {
            cbo.ValueMember = valueColumn;
            cbo.DisplayMember = displayColumn;
            cbo.ColumnNames = columnsName;
            cbo.ColumnWidths = columnsWidth;
            if (txt != null)
            {
                cbo.LinkedTextBox1 = txt;
                cbo.LinkedColumnIndex1 = linkColumnIndex;
            }
            cbo.DataSource = Data_DM_Thuoc_CachDung(id);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_DM_Thuoc_CachDung(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class DM_THUOC_GOCTHUOC_DAL
    {
        public int Insert_Update_DM_THUOC_GOCTHUOC(DM_THUOC_GOCTHUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc set";
                strSQL +=
                    "\nmagocthuoc = @magocthuoc,manhomthuoc = @manhomthuoc,tengocthuoc = @tengocthuoc,thutuin = @thutuin where magocthuoc = @magocthuoc";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc (";
                strSQL += "\nmagocthuoc,manhomthuoc,tengocthuoc,thutuin)";
                strSQL += "\nValues (@magocthuoc,@manhomthuoc,@tengocthuoc,@thutuin)";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc),
                new SqlParameter("@Manhomthuoc", objInfo.Manhomthuoc),
                new SqlParameter("@Tengocthuoc", objInfo.Tengocthuoc),
                new SqlParameter("@Thutuin", objInfo.Thutuin)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_DM_THUOC_GOCTHUOC(DM_THUOC_GOCTHUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Delete {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc";
            strSQL += "\n where magocthuoc = @magocthuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(DM_THUOC_GOCTHUOC objInfo)
        {
            string strSQL = "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc  where magocthuoc = @magocthuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_DM_Thuoc_GocThuoc(string _magocthuoc, string _manhomthuoc)
        {
            string strSQL = "select *  from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc where 1=1";
            if (_magocthuoc.Trim() != "")
            {
                strSQL += "\nand magocthuoc ='" + _magocthuoc + "'";
            }
            if (_manhomthuoc.Trim() != "")
            {
                strSQL += "\nand manhomthuoc ='" + _manhomthuoc + "'";
            }
            return strSQL;
        }

        public DataTable Data_DM_Thuoc_GocThuoc(string _magocthuoc, string _manhomthuoc)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_DM_Thuoc_GocThuoc(_magocthuoc, _manhomthuoc)).Tables[0];
        }

        public void Data_DM_Thuoc_GocThuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _magocthuoc, string _manhomthuoc)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_DM_Thuoc_GocThuoc(_magocthuoc, _manhomthuoc), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_DM_Thuoc_GocThuoc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn,
            string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex,
            string _magocthuoc, string _manhomthuoc)
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
            cbo.DataSource = Data_DM_Thuoc_GocThuoc(_magocthuoc, _manhomthuoc);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_DM_Thuoc_GocThuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class DM_THUOC_NHOMTHUOC_DAL
    {

        public DM_THUOC_NHOMTHUOC_DAL()
        {
        }

        public int Insert_Update_DM_THUOC_NHOMTHUOC(DM_THUOC_NHOMTHUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc set";
                strSQL += "\nmanhomthuoc = @manhomthuoc,tennhomthuoc = @tennhomthuoc where manhomthuoc = @manhomthuoc";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc (";
                strSQL += "\nmanhomthuoc,tennhomthuoc)";
                strSQL += "\nValues (@manhomthuoc,@tennhomthuoc)";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Manhomthuoc", objInfo.Manhomthuoc),
                new SqlParameter("@Tennhomthuoc", objInfo.Tennhomthuoc)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_DM_THUOC_NHOMTHUOC(DM_THUOC_NHOMTHUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Delete {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc";
            strSQL += "\n where manhomthuoc = @manhomthuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Manhomthuoc", objInfo.Manhomthuoc)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(DM_THUOC_NHOMTHUOC objInfo)
        {
            string strSQL = "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc  where manhomthuoc = @manhomthuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Manhomthuoc", objInfo.Manhomthuoc)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_DM_Thuoc_NhomThuoc(string _manhomthuoc)
        {
            string strSQL = "select *  from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc where 1=1";
            if (_manhomthuoc.Trim() != "")
            {
                strSQL += "\nand manhomthuoc ='" + _manhomthuoc + "'";
            }
            return strSQL;
        }

        public DataTable Data_DM_Thuoc_NhomThuoc(string _manhomthuoc)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_DM_Thuoc_NhomThuoc(_manhomthuoc)).Tables[0
                    ];
        }

        public void Data_DM_Thuoc_NhomThuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _manhomthuoc)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_DM_Thuoc_NhomThuoc(_manhomthuoc), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_DM_Thuoc_NhomThuoc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn,
            string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex,
            string _manhomthuoc)
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
            cbo.DataSource = Data_DM_Thuoc_NhomThuoc(_manhomthuoc);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_DM_Thuoc_NhomThuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class DM_THUOC_PROFILE_DAL
    {

        public DM_THUOC_PROFILE_DAL()
        {
        }

        public int Insert_Update_DM_THUOC_PROFILE(DM_THUOC_PROFILE objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile set";
                strSQL += "\nmaprofile = @maprofile,tenprofile = @tenprofile where maprofile = @maprofile";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile (";
                strSQL += "\nmaprofile,tenprofile)";
                strSQL += "\nValues (@maprofile,@tenprofile)";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maprofile", objInfo.Maprofile),
                new SqlParameter("@Tenprofile", objInfo.Tenprofile)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_DM_THUOC_PROFILE(DM_THUOC_PROFILE objInfo)
        {
            string strSQL = "";
            strSQL = "Delete {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile";
            strSQL += "\n where maprofile = @maprofile";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maprofile", objInfo.Maprofile)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(DM_THUOC_PROFILE objInfo)
        {
            string strSQL = "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile  where maprofile = @maprofile";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maprofile", objInfo.Maprofile)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_DM_Thuoc_Profile(string _maprofile)
        {
            string strSQL = "select *  from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile where 1=1";
            if (_maprofile.Trim() != "")
            {
                strSQL += "\nand maprofile ='" + _maprofile + "'";
            }
            return strSQL;
        }

        public DataTable Data_DM_Thuoc_Profile(string _maprofile)
        {
            return DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_DM_Thuoc_Profile(_maprofile)).Tables[0];
        }

        public void Data_DM_Thuoc_Profile(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _maprofile)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_DM_Thuoc_Profile(_maprofile), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_DM_Thuoc_Profile(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn,
            string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex,
            string _maprofile)
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
            cbo.DataSource = Data_DM_Thuoc_Profile(_maprofile);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_DM_Thuoc_Profile(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class DM_THUOC_PROFILE_CHITIET_DAL
    {

        public DM_THUOC_PROFILE_CHITIET_DAL()
        {
        }

        public int Insert_Update_DM_THUOC_PROFILE_CHITIET(DM_THUOC_PROFILE_CHITIET objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_chitiet set";
                strSQL +=
                    "\ncachdung = @cachdung,chieu = @chieu,maprofile = @maprofile,mathuoc = @mathuoc,sang = @sang,toi = @toi,trua = @trua where maprofile = @maprofile and mathuoc = @mathuoc";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_chitiet (";
                strSQL += "\ncachdung,chieu,maprofile,mathuoc,sang,toi,trua)";
                strSQL += "\nValues (@cachdung,@chieu,@maprofile,@mathuoc,@sang,@toi,@trua)";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Cachdung", objInfo.Cachdung),
                new SqlParameter("@Chieu", objInfo.Chieu),
                new SqlParameter("@Maprofile", objInfo.Maprofile),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Sang", objInfo.Sang),
                new SqlParameter("@Toi", objInfo.Toi),
                new SqlParameter("@Trua", objInfo.Trua)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_DM_THUOC_PROFILE_CHITIET(DM_THUOC_PROFILE_CHITIET objInfo)
        {
            string strSQL = "";
            strSQL = "Delete {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_chitiet";
            strSQL += "\n where maprofile = @maprofile and mathuoc = @mathuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maprofile", objInfo.Maprofile),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(DM_THUOC_PROFILE_CHITIET objInfo)
        {
            string strSQL =
                "select top 1 * from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_ChiTiet  where maprofile = @maprofile and mathuoc = @mathuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maprofile", objInfo.Maprofile),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_DM_Thuoc_Profile_ChiTiet(string _maprofile, string _mathuoc)
        {
            string strSQL = "select *  from {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_profile_chitiet where 1=1";
            if (_maprofile.Trim() != "")
            {
                strSQL += "\nand maprofile ='" + _maprofile + "'";
            }
            if (_mathuoc.Trim() != "")
            {
                strSQL += "\nand mathuoc ='" + _mathuoc + "'";
            }
            return strSQL;
        }

        public DataTable Data_DM_Thuoc_Profile_ChiTiet(string _maprofile, string _mathuoc)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_DM_Thuoc_Profile_ChiTiet(_maprofile, _mathuoc)).Tables[0];
        }

        public void Data_DM_Thuoc_Profile_ChiTiet(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _maprofile, string _mathuoc)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_DM_Thuoc_Profile_ChiTiet(_maprofile, _mathuoc), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_DM_Thuoc_Profile_ChiTiet(CustomComboBox cbo, string _ValueColumn,
            string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt,
            int LinkColumnIndex, string _maprofile, string _mathuoc)
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
            cbo.DataSource = Data_DM_Thuoc_Profile_ChiTiet(_maprofile, _mathuoc);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_DM_Thuoc_Profile_ChiTiet(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    //Kho thuoc
    public class VT_NHAPKHO_CHIETTIET_THUOC_DAL
    {

        public VT_NHAPKHO_CHIETTIET_THUOC_DAL()
        {
        }

        public int Insert_Update_VT_NHAPKHO_CHIETTIET_THUOC(VT_NHAPKHO_CHIETTIET_THUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_nhapkho_chiettiet_thuoc set";
                strSQL +=
                    "\ncohsd = @cohsd,donvitinh = @donvitinh,dvtquicachcap1 = @dvtquicachcap1,dvtquicachcap2 = @dvtquicachcap2,magocthuoc = @magocthuoc,manhacungcap = @manhacungcap,maphieunhap = @maphieunhap,mavattu = @mavattu,slquicachcap1 = @slquicachcap1,slquicachcap2 = @slquicachcap2";
                strSQL +=
                    "\n,soluongnhap = @soluongnhap,soluongtheoquicach = @soluongtheoquicach,soluongxuat = @soluongxuat,soluongxuattheoquicach = @soluongxuattheoquicach,tenthuoc = @tenthuoc,xuattheoqcdg = @xuattheoqcdg where maphieunhap = @maphieunhap and mavattu = @mavattu";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_nhapkho_chiettiet_thuoc (";
                strSQL +=
                    "\ncohsd,donvitinh,dvtquicachcap1,dvtquicachcap2,magocthuoc,manhacungcap,maphieunhap,mavattu,slquicachcap1,slquicachcap2";
                strSQL +=
                    "\n,soluongnhap,soluongtheoquicach,soluongxuat,soluongxuattheoquicach,tenthuoc,tgnhap,xuattheoqcdg,HanSuDung,Gianhap,Hangtang)";
                strSQL +=
                    "\nSelect @cohsd,t.donvitinh,t.dvtquicachcap1,t.dvtquicachcap2,t.magocthuoc,@manhacungcap,@maphieunhap,@mavattu,t.slquicachcap1,t.slquicachcap2";
                strSQL +=
                    "\n,@soluongnhap, case when t.XuatTheoQCDG = 1 then @soluongnhap * t.slquicachcap1 else 0 end as soluongtheoquicach,0,0,t.tenthuoc,getdate(),t.XuatTheoQCDG,case when @cohsd = 1 then @HanSuDung else NULL end as hansudung,@Gianhap,@Hangtang from {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t where t.MaThuoc = @mavattu";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Cohsd", objInfo.Cohsd),
                new SqlParameter("@Donvitinh", objInfo.Donvitinh),
                new SqlParameter("@Dvtquicachcap1", objInfo.Dvtquicachcap1),
                new SqlParameter("@Dvtquicachcap2", objInfo.Dvtquicachcap2),
                new SqlParameter("@Gianhap", objInfo.Gianhap),
                new SqlParameter("@Hangtang", objInfo.Hangtang),
                new SqlParameter("@Hansudung", objInfo.Hansudung),
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc),
                new SqlParameter("@Manhacungcap", objInfo.Manhacungcap),
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Mavattu", objInfo.Mavattu),
                new SqlParameter("@Slquicachcap1", objInfo.Slquicachcap1),
                new SqlParameter("@Slquicachcap2", objInfo.Slquicachcap2),
                new SqlParameter("@Soluongnhap", objInfo.Soluongnhap),
                new SqlParameter("@Soluongtheoquicach", objInfo.Soluongtheoquicach),
                new SqlParameter("@Soluongxuat", objInfo.Soluongxuat),
                new SqlParameter("@Soluongxuattheoquicach", objInfo.Soluongxuattheoquicach),
                new SqlParameter("@Tenthuoc", objInfo.Tenthuoc),
                new SqlParameter("@Tgnhap", objInfo.Tgnhap),
                new SqlParameter("@Xuattheoqcdg", objInfo.Xuattheoqcdg)
            };


            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Update_Output(string _MaphieuNhap, string _MaThuoc, float _soluong, bool _xuatTheoQCDG)
        {
            string strSQL = "update vt_nhapkho_chiettiet_thuoc set";
            if (_xuatTheoQCDG)
            {
                strSQL += " SoLuongXuatTheoQuiCach = SoLuongXuatTheoQuiCach + @SoLuongXuat ";
            }
            else
            {
                strSQL += " SoLuongXuat = SoLuongXuat + @SoLuongXuat ";
            }
            strSQL += "\n where Maphieunhap = @Maphieunhap and Mavattu = @Mavattu";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", _MaphieuNhap),
                new SqlParameter("@Mavattu", _MaThuoc),
                new SqlParameter("@SoLuongXuat", _soluong)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Update_Output_return(string _MaphieuNhap, string _MaThuoc, float _soluong, bool _xuatTheoQCDG)
        {
            string strSQL = "update vt_nhapkho_chiettiet_thuoc set";
            if (_xuatTheoQCDG)
            {
                strSQL += " SoLuongXuatTheoQuiCach = SoLuongXuatTheoQuiCach - @SoLuongXuat ";
            }
            else
            {
                strSQL += " SoLuongXuat = SoLuongXuat - @SoLuongXuat ";
            }
            strSQL += "\n where Maphieunhap = @Maphieunhap and Mavattu = @Mavattu";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", _MaphieuNhap),
                new SqlParameter("@Mavattu", _MaThuoc),
                new SqlParameter("@SoLuongXuat", _soluong)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_VT_NHAPKHO_CHIETTIET_THUOC(VT_NHAPKHO_CHIETTIET_THUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_nhapkho_chiettiet_thuoc";
            strSQL += "\n where maphieunhap = @maphieunhap and mavattu = @mavattu";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Mavattu", objInfo.Mavattu)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(VT_NHAPKHO_CHIETTIET_THUOC objInfo)
        {
            string strSQL =
                "select top 1 * from VT_NhapKho_ChietTiet_Thuoc  where maphieunhap = @maphieunhap and mavattu = @mavattu";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Mavattu", objInfo.Mavattu)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_VT_NhapKho_ChietTiet_Thuoc(string _manhacungcap, string _maphieunhap,
            string _mavattu)
        {
            string strSQL =
                "select t.MatHuoc, t.TenThuoc, v.*  from vt_nhapkho_chiettiet_thuoc v inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t on v.MaVatTu = t.MaThuoc where 1=1";
            if (_manhacungcap.Trim() != "")
            {
                strSQL += "\nand manhacungcap ='" + _manhacungcap + "'";
            }
            if (_maphieunhap.Trim() != "")
            {
                strSQL += "\nand maphieunhap ='" + _maphieunhap + "'";
            }
            if (_mavattu.Trim() != "")
            {
                strSQL += "\nand mavattu ='" + _mavattu + "'";
            }
            return strSQL;
        }

        public DataTable Data_VT_NhapKho_ChiTiet_Xuat(string _MaVatTu, string _MaPhieuNhap)
        {
            string strSQL = "select d.MaVatTu, d.TenThuoc, d.CoHSD, ";
            strSQL +=
                "\ncase when d.XuatTheoQCDG =1 then d.SoLuongTheoQuiCach - d.SoLuongXuatTheoQuiCach else d.SoLuongNhap - SoLuongXuat end as TonKho,";
            strSQL +=
                "\n0 as SLXuat, d.HanSuDung,d.MaNhaCungCap, d.DonViTinh, d.DVTQuiCachCap1, d.DVTQuiCachCap2, d.SoLo, d.MaPhieuNhap, d.MaNhaCungCap,d.XuatTheoQCDG";
            strSQL += "\n,d.HangTang, d.SLQuiCachCap1, d.DVTQuiCachCap2, d.MaVatTu, n.TenNhomThuoc,ncc.TenNhaCungCap ";
            strSQL += "\nfrom VT_NhapKho_ChietTiet_Thuoc d";
            strSQL += "\ninner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t on d.MaVatTu = t.MaThuoc";
            strSQL += "\nLeft join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on g.MaGocthuoc = t.MaGocThuoc";
            strSQL += "\nLeft join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_nhomthuoc n on g.MaNhomThuoc = n.MaNhomThuoc";
            strSQL += "\nLeft join VT_DM_NhaCungCap ncc on ncc.MaNhaCungCap = d.MaNhaCungCap";
            strSQL +=
                "\nwhere case when d.XuatTheoQCDG =1 then d.SoLuongTheoQuiCach - d.SoLuongXuatTheoQuiCach else d.SoLuongNhap - SoLuongXuat end > 0";
            strSQL += "\n and d.MaVatTu = isnull(case when len(@Mavattu) = 0 then null else @Mavattu end, d.MaVatTu)";
            strSQL +=
                "\n and d.Maphieunhap = isnull(case when len(@Maphieunhap) = 0 then null else @Maphieunhap end, d.Maphieunhap)";
            strSQL += "\norder by d.MaVatTu ASC, d.HanSuDung ASC";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", _MaPhieuNhap),
                new SqlParameter("@Mavattu", _MaVatTu)
            };
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL, param).Tables[0];
        }

        public DataTable Data_VT_NhapKho_ChietTiet_Thuoc(string _manhacungcap, string _maphieunhap, string _mavattu)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_VT_NhapKho_ChietTiet_Thuoc(_manhacungcap, _maphieunhap, _mavattu)).Tables[0];
        }

        public void Data_VT_NhapKho_ChietTiet_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _manhacungcap, string _maphieunhap, string _mavattu)
        {
            DataProvider.SelInsUpdDelODBC(
                SQL_Select_Data_VT_NhapKho_ChietTiet_Thuoc(_manhacungcap, _maphieunhap, _mavattu), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_VT_NhapKho_ChietTiet_Thuoc(CustomComboBox cbo, string _ValueColumn,
            string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt,
            int LinkColumnIndex, string _manhacungcap, string _maphieunhap, string _mavattu)
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
            cbo.DataSource = Data_VT_NhapKho_ChietTiet_Thuoc(_manhacungcap, _maphieunhap, _mavattu);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_VT_NhapKho_ChietTiet_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class VT_NHAPKHO_PHIEUNHAP_THUOC_DAL
    {

        public VT_NHAPKHO_PHIEUNHAP_THUOC_DAL()
        {
        }

        public int Insert_Update_VT_NHAPKHO_PHIEUNHAP_THUOC(VT_NHAPKHO_PHIEUNHAP_THUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_nhapkho_phieunhap_thuoc set";
                strSQL +=
                    "\nghichu = @ghichu,maphieunhap = @maphieunhap,ngaynhap = @ngaynhap,nguoicapnhat = @nguoicapnhat,tgcapnhat = getdate() where maphieunhap = @maphieunhap";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_nhapkho_phieunhap_thuoc (";
                strSQL += "\nghichu,maphieunhap,ngaynhap,nguoinhap,tgnhap)";
                strSQL += "\nValues (@ghichu,@maphieunhap,@ngaynhap,@nguoinhap,getdate())";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ghichu", objInfo.Ghichu),
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Ngaynhap", objInfo.Ngaynhap),
                new SqlParameter("@Nguoicapnhat", objInfo.Nguoicapnhat),
                new SqlParameter("@Nguoinhap", objInfo.Nguoinhap),
                new SqlParameter("@Tgcapnhat", objInfo.Tgcapnhat)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_VT_NHAPKHO_PHIEUNHAP_THUOC(VT_NHAPKHO_PHIEUNHAP_THUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_nhapkho_phieunhap_thuoc";
            strSQL += "\n where maphieunhap = @maphieunhap";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(VT_NHAPKHO_PHIEUNHAP_THUOC objInfo)
        {
            string strSQL = "select top 1 * from VT_NhapKho_PhieuNhap_Thuoc  where maphieunhap = @maphieunhap";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_VT_NhapKho_PhieuNhap_Thuoc(string _maphieunhap)
        {
            string strSQL = "select *  from vt_nhapkho_phieunhap_thuoc where 1=1";
            if (_maphieunhap.Trim() != "")
            {
                strSQL += "\nand maphieunhap ='" + _maphieunhap + "'";
            }
            return strSQL;
        }

        public DataTable Data_Search_InputList(DateTime dateFrom, DateTime dateTo, string _maphieunhap,
            string _nguoinhap, string _manhacungcap, string _manhomthuoc, string _mathuoc)
        {
            string strSQL = "select distinct n.*  from vt_nhapkho_phieunhap_thuoc n ";
            if (_manhacungcap != "" || _manhomthuoc != "" || _mathuoc != "")
            {
                strSQL += "\n inner join VT_NhapKho_ChietTiet_Thuoc d on n.MaPhieuNhap = d.MaPhieuNhap";
                strSQL +=
                    "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t on t.MaThuoc = d.MaVatTu inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on g.MaGocThuoc = t.MaGocThuoc";
            }
            strSQL += "\n where n.NgayNhap between '" + dateFrom.ToString("yyyy-MM-dd 00:00:00") + "' and '" +
                      dateTo.ToString("yyyy-MM-dd 23:59:59") + "'";

            if (_maphieunhap.Trim() != "")
            {
                strSQL += "\nand n.maphieunhap ='" + _maphieunhap.Trim() + "'";
            }
            if (_nguoinhap.Trim() != "")
            {
                strSQL += "\n and n.NguoiNhap ='" + _nguoinhap.Trim() + "'";
            }
            if (_manhacungcap.Trim() != "")
            {
                strSQL += "\n and d.MaNhaCungCap ='" + _manhacungcap.Trim() + "'";
            }
            if (_manhomthuoc.Trim() != "")
            {
                strSQL += "\n and g.MaNhomThuoc ='" + _manhomthuoc.Trim() + "'";
            }
            if (_mathuoc.Trim() != "")
            {
                strSQL += "\n and d.MaVatTu ='" + _mathuoc.Trim() + "'";
            }

            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }

        public DataTable Data_VT_NhapKho_PhieuNhap_Thuoc_CodeList(string _Filter)
        {
            string strSQL = "select top 1 maphieunhap,cast(right(rtrim(maphieunhap),len(rtrim(maphieunhap)) - len('" +
                            _Filter + "')) as int) as CodeNo from  VT_NhapKho_PhieuNhap_Thuoc where maphieunhap like '" +
                            _Filter + "%' order by cast(right(rtrim(maphieunhap),len(rtrim(maphieunhap)) - len('" +
                            _Filter + "')) as int) desc  ";
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }

        public DataTable Data_VT_NhapKho_PhieuNhap_Thuoc(string _maphieunhap)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_NhapKho_PhieuNhap_Thuoc(_maphieunhap))
                    .Tables[0];
        }

        public void Data_VT_NhapKho_PhieuNhap_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _maphieunhap)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_NhapKho_PhieuNhap_Thuoc(_maphieunhap), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_VT_NhapKho_PhieuNhap_Thuoc(CustomComboBox cbo, string _ValueColumn,
            string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt,
            int LinkColumnIndex, string _maphieunhap)
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
            cbo.DataSource = Data_VT_NhapKho_PhieuNhap_Thuoc(_maphieunhap);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_VT_NhapKho_PhieuNhap_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    //Xuất thuốc
    public class VT_XUATKHO_PHIEUXUAT_THUOC_DAL
    {

        public VT_XUATKHO_PHIEUXUAT_THUOC_DAL()
        {
        }

        public int Insert_Update_VT_XUATKHO_PHIEUXUAT_THUOC(VT_XUATKHO_PHIEUXUAT_THUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_xuatkho_phieuxuat_thuoc set";
                strSQL +=
                    "\nghichu = @ghichu,maphieuxuat = @maphieuxuat,matiepnhan = @matiepnhan,ngaynhap = @ngaynhap,nguoicapnhat = @nguoicapnhat,nguoinhap = @nguoinhap,tgcapnhat = @tgcapnhat,tgnhap = @tgnhap where maphieuxuat = @maphieuxuat";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into vt_xuatkho_phieuxuat_thuoc (";
                strSQL += "\nghichu,maphieuxuat,matiepnhan,ngaynhap,nguoicapnhat,nguoinhap,tgcapnhat,tgnhap)";
                strSQL +=
                    "\nValues (@ghichu,@maphieuxuat,@matiepnhan,@ngaynhap,@nguoicapnhat,@nguoinhap,@tgcapnhat,@tgnhap)";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ghichu", objInfo.Ghichu),
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat),
                new SqlParameter("@Matiepnhan", objInfo.Matiepnhan),
                new SqlParameter("@Ngaynhap", objInfo.Ngaynhap),
                new SqlParameter("@Nguoicapnhat", objInfo.Nguoicapnhat),
                new SqlParameter("@Nguoinhap", objInfo.Nguoinhap),
                new SqlParameter("@Tgcapnhat", objInfo.Tgcapnhat),
                new SqlParameter("@Tgnhap", objInfo.Tgnhap)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_VT_XUATKHO_PHIEUXUAT_THUOC(VT_XUATKHO_PHIEUXUAT_THUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Delete vt_xuatkho_phieuxuat_thuoc";
            strSQL += "\n where maphieuxuat = @maphieuxuat";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(VT_XUATKHO_PHIEUXUAT_THUOC objInfo)
        {
            string strSQL = "select top 1 * from VT_XuatKho_PhieuXuat_Thuoc  where maphieuxuat = @maphieuxuat";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        public DataTable Data_VT_XuatKho_PhieuXuat_Thuoc_CodeList(string _Filter)
        {
            string strSQL = "select top 1 MaPhieuXuat,cast(right(rtrim(MaPhieuXuat),len(rtrim(MaPhieuXuat)) - len('" +
                            _Filter + "')) as int) as CodeNo from  VT_XuatKho_PhieuXuat_Thuoc where MaPhieuXuat like '" +
                            _Filter + "%' order by cast(right(rtrim(MaPhieuXuat),len(rtrim(MaPhieuXuat)) - len('" +
                            _Filter + "')) as int) desc  ";
            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }

        public DataTable Data_Search_OutputList(DateTime dateFrom, DateTime dateTo, string _maphieuxuat,
            string _nguoinhap, string _manhacungcap, string _manhomthuoc, string _mathuoc)
        {
            string strSQL = "select distinct n.*  from VT_XuatKho_PhieuXuat_Thuoc n ";
            if (_manhacungcap != "" || _manhomthuoc != "" || _mathuoc != "")
            {
                strSQL += "\n inner join VT_XuatKho_ChiTiet_Thuoc d on n.MaPhieuXuat = d.MaPhieuXuat";
                strSQL +=
                    "\n inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t on t.MaThuoc = d.MaVatTu inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on g.MaGocThuoc = t.MaGocThuoc";
            }
            strSQL += "\n where n.NgayNhap between '" + dateFrom.ToString("yyyy-MM-dd 00:00:00") + "' and '" +
                      dateTo.ToString("yyyy-MM-dd 23:59:59") + "'";

            if (_maphieuxuat.Trim() != "")
            {
                strSQL += "\nand n.MaPhieuXuat ='" + _maphieuxuat.Trim() + "'";
            }
            if (_nguoinhap.Trim() != "")
            {
                strSQL += "\n and n.NguoiNhap ='" + _nguoinhap.Trim() + "'";
            }
            if (_manhacungcap.Trim() != "")
            {
                strSQL += "\n and d.MaNhaCungCap ='" + _manhacungcap.Trim() + "'";
            }
            if (_manhomthuoc.Trim() != "")
            {
                strSQL += "\n and g.MaNhomThuoc ='" + _manhomthuoc.Trim() + "'";
            }
            if (_mathuoc.Trim() != "")
            {
                strSQL += "\n and d.MaVatTu ='" + _mathuoc.Trim() + "'";
            }

            return DataProvider.ExecuteDataset(CommandType.Text, strSQL).Tables[0];
        }

        private string SQL_Select_Data_VT_XuatKho_PhieuXuat_Thuoc(string _maphieuxuat)
        {
            string strSQL = "select *  from vt_xuatkho_phieuxuat_thuoc where 1=1";
            if (_maphieuxuat.Trim() != "")
            {
                strSQL += "\nand maphieuxuat ='" + _maphieuxuat + "'";
            }
            return strSQL;
        }

        public DataTable Data_VT_XuatKho_PhieuXuat_Thuoc(string _maphieuxuat)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_VT_XuatKho_PhieuXuat_Thuoc(_maphieuxuat))
                    .Tables[0];
        }

        public void Data_VT_XuatKho_PhieuXuat_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _maphieuxuat)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_VT_XuatKho_PhieuXuat_Thuoc(_maphieuxuat), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_VT_XuatKho_PhieuXuat_Thuoc(CustomComboBox cbo, string _ValueColumn,
            string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt,
            int LinkColumnIndex, string _maphieuxuat)
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
            cbo.DataSource = Data_VT_XuatKho_PhieuXuat_Thuoc(_maphieuxuat);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_VT_XuatKho_PhieuXuat_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class THUPHI_THUOC_DAL
    {

        public THUPHI_THUOC_DAL()
        {
        }

        public int Insert_Update_THUPHI_THUOC(THUPHI_THUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update thuphi_thuoc set";
                strSQL +=
                    "\ncachdung = @cachdung,chieu = @chieu,dainbienlai = @dainbienlai,dathutien = @dathutien,dongia = @dongia,donvitinh = @donvitinh,dvtquicachcap1 = @dvtquicachcap1,dvtquicachcap2 = @dvtquicachcap2,magocthuoc = @magocthuoc,mathuoc = @mathuoc";
                strSQL +=
                    "\n,matiepnhan = @matiepnhan,nguoinhap = @nguoinhap,sang = @sang,slquicachcap1 = @slquicachcap1,slquicachcap2 = @slquicachcap2,soluong = @soluong,tenthuoc = @tenthuoc,tgnhap = @tgnhap,thanhtien = @thanhtien,toi = @toi";
                strSQL +=
                    "\n,trua = @trua,xuattheoqcdg = @xuattheoqcdg where mathuoc = @mathuoc and matiepnhan = @matiepnhan";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Mã đã tồn tại.\nHãy nhập mã khác !");
                    return -1;
                }
                strSQL = "Insert into thuphi_thuoc (";
                strSQL +=
                    "\ncachdung,chieu,dainbienlai,dathutien,dongia,donvitinh,dvtquicachcap1,dvtquicachcap2,magocthuoc,mathuoc";
                strSQL +=
                    "\n,matiepnhan,nguoinhap,sang,slquicachcap1,slquicachcap2,soluong,tenthuoc,tgnhap,thanhtien,toi";
                strSQL += "\n,trua,xuattheoqcdg)";
                strSQL +=
                    "\nValues (@cachdung,@chieu,@dainbienlai,@dathutien,@dongia,@donvitinh,@dvtquicachcap1,@dvtquicachcap2,@magocthuoc,@mathuoc";
                strSQL +=
                    "\n,@matiepnhan,@nguoinhap,@sang,@slquicachcap1,@slquicachcap2,@soluong,@tenthuoc,@tgnhap,@thanhtien,@toi";
                strSQL += "\n,@trua,@xuattheoqcdg)";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Cachdung", objInfo.Cachdung),
                new SqlParameter("@Chieu", objInfo.Chieu),
                new SqlParameter("@Dainbienlai", objInfo.Dainbienlai),
                new SqlParameter("@Dathutien", objInfo.Dathutien),
                new SqlParameter("@Dongia", objInfo.Dongia),
                new SqlParameter("@Donvitinh", objInfo.Donvitinh),
                new SqlParameter("@Dvtquicachcap1", objInfo.Dvtquicachcap1),
                new SqlParameter("@Dvtquicachcap2", objInfo.Dvtquicachcap2),
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Matiepnhan", objInfo.Matiepnhan),
                new SqlParameter("@Nguoinhap", objInfo.Nguoinhap),
                new SqlParameter("@Sang", objInfo.Sang),
                new SqlParameter("@Slquicachcap1", objInfo.Slquicachcap1),
                new SqlParameter("@Slquicachcap2", objInfo.Slquicachcap2),
                new SqlParameter("@Soluong", objInfo.Soluong),
                new SqlParameter("@Tenthuoc", objInfo.Tenthuoc),
                new SqlParameter("@Tgnhap", objInfo.Tgnhap),
                new SqlParameter("@Thanhtien", objInfo.Thanhtien),
                new SqlParameter("@Toi", objInfo.Toi),
                new SqlParameter("@Trua", objInfo.Trua),
                new SqlParameter("@Xuattheoqcdg", objInfo.Xuattheoqcdg)
            };
            return (int) DataProvider.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        private bool Check_Allow_Insert(string _MaThuoc, int _SoLuong)
        {
            string strSQL = "";
            strSQL +=
                "\nselect cast (case when sum(A.TonKho - A.SLX) >= @SoLuong then 1 else 0 end as bit) as allow   from";
            strSQL += "\n(";
            strSQL += "\nselect 0 as TonKho, sum(soluong) as SLX from ThuPhi_Thuoc where MaThuoc= @MaThuoc";
            strSQL += "\nunion ";
            strSQL +=
                "\nselect sum(case when XuatTheoQCDG = 1 then SoLuongTheoQuiCach else SoLuongNhap end) as TonKho , 0 as SLX";
            strSQL += "\nfrom VT_NhapKho_ChietTiet_Thuoc where MaVatTu = @MaThuoc";
            strSQL += "\n) as A";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MaThuoc", _MaThuoc),
                new SqlParameter("@SoLuong", _SoLuong)
            };
            DataTable dt = DataProvider.ExecuteDataset(CommandType.Text, strSQL, param).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return (bool) dt.Rows[0]["allow"];

            }
            else
                return false;
        }

        public int Insert_ThuPhi_Thuoc(string _MaThuoc, string _MaTiepNhan, string _MaDoiTuongDV, int _Soluong,
            float _DonGia, bool _Profile)
        {
            if (Check_Allow_Insert(_MaThuoc, _Soluong))
            {
                string strSQL = "", alias = (_Profile == true ? "P" : "T");
                strSQL = "insert into  THUPHI_THUOC (";
                strSQL += Environment.NewLine + "matiepnhan";
                strSQL += Environment.NewLine + "," + "mathuoc";
                strSQL += Environment.NewLine + "," + "tenthuoc";
                strSQL += Environment.NewLine + "," + "dongia";
                strSQL += Environment.NewLine + "," + "magocthuoc";
                strSQL += Environment.NewLine + "," + "donvitinh";
                strSQL += Environment.NewLine + "," + "cachdung";
                strSQL += Environment.NewLine + "," + "sang";
                strSQL += Environment.NewLine + "," + "trua";
                strSQL += Environment.NewLine + "," + "chieu";
                strSQL += Environment.NewLine + "," + "toi";
                strSQL += Environment.NewLine + "," + "soluong";
                strSQL += Environment.NewLine + "," + "thanhtien";
                strSQL += Environment.NewLine + "," + "xuattheoqcdg";
                strSQL += Environment.NewLine + "," + "dvtquicachcap1";
                strSQL += Environment.NewLine + "," + "dvtquicachcap2";
                strSQL += Environment.NewLine + "," + "nguoinhap";
                strSQL += Environment.NewLine + "," + "slquicachcap1";
                strSQL += Environment.NewLine + "," + "slquicachcap2";
                strSQL += Environment.NewLine + "," + "tgnhap";
                strSQL += Environment.NewLine + ")";
                strSQL += Environment.NewLine + "SELECT @MaTiepNhan";
                strSQL += Environment.NewLine + ",T.[MaThuoc]";
                strSQL += Environment.NewLine + ",T.[TenThuoc]";
                strSQL += Environment.NewLine + ",@DonGia";
                strSQL += Environment.NewLine + ",T.[MaGocThuoc]";
                strSQL += Environment.NewLine + ",[DonViTinh]";
                strSQL += Environment.NewLine + "," + alias + ".[CachDung]";
                strSQL += Environment.NewLine + "," + alias + ".[Sang]";
                strSQL += Environment.NewLine + "," + alias + ".[Trua]";
                strSQL += Environment.NewLine + "," + alias + ".[Chieu]";
                strSQL += Environment.NewLine + "," + alias + ".[Toi]";
                strSQL += Environment.NewLine + ", @SoLuong";
                strSQL += Environment.NewLine + ", (@SoLuong * isnull(nullif(@DonGia,-1), isnull(d.GiaRieng,0)) as ThanhTien";
                strSQL += Environment.NewLine + ",T.xuattheoqcdg";
                strSQL += Environment.NewLine + ",T.dvtquicachcap1";
                strSQL += Environment.NewLine + ",T.dvtquicachcap2";
                strSQL += Environment.NewLine + ",@nguoinhap";
                strSQL += Environment.NewLine + ",T.slquicachcap1";
                strSQL += Environment.NewLine + ",T.slquicachcap2";
                strSQL += Environment.NewLine + ",GETDATE()";
                strSQL += Environment.NewLine + "FROM";
                if (_Profile)
                {
                    strSQL += Environment.NewLine + "DM_Thuoc_Profile_ChiTiet P inner join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc T on P.MaThuoc = T.MaThuoc and P.MaProfile = @MaThuoc";
                    strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm d  on (T.MaThuoc = d.MaDichVu and d.MaDoiTuongDichVu= @MaDoiTuongDV and MaLoaiDichVu = 'ClsSieuAm')";
                }
                else
                {
                    strSQL += Environment.NewLine + "DM_Thuoc T ";
                    strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm d  on (T.MaThuoc = d.MaDichVu and d.MaDoiTuongDichVu= @MaDoiTuongDV and MaLoaiDichVu = 'ClsSieuAm')";
                    strSQL += "\nwhere T.MaThuoc = @MaThuoc";
                }
                strSQL += Environment.NewLine + " and " + alias + ".MaThuoc not in (select MaThuoc from ThuPhi_Thuoc where MaTiepNhan = @MaTiepNhan)";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@Mathuoc", _MaThuoc),
                    new SqlParameter("@Matiepnhan", _MaTiepNhan),
                    new SqlParameter("@MaDoiTuongDV", _MaDoiTuongDV),
                    new SqlParameter("@SoLuong", _Soluong),
                    new SqlParameter("@DonGia", _DonGia),
                    new SqlParameter("@nguoinhap", CommonAppVarsAndFunctions.UserID)
                };
                return (int) DataProvider.ExecuteNonQuery(CommandType.Text, strSQL, param);
            }
            else
            {
                CustomMessageBox.MSG_Information_OK("Số lượng trong kho tạm tính còn ít hơn số lượng xuất!");
                return -1;
            }
        }

        public int Update_ThuTien_Thuoc(string _MaTiepNhan, string _MaThuoc, bool _DaThuTien)
        {
            string strSQL = "update THUPHI_THUOC set DaThuTien = @DaThuTien where MaThuoc in (" + _MaThuoc +
                            ") and MaTiepNhan = @MaTiepNhan";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Matiepnhan", _MaTiepNhan),
                new SqlParameter("@DaThuTien", _DaThuTien)
            };
            return (int) DataProvider.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        public int Update_InBienLai_Thuoc(string _MaTiepNhan, string _MaThuoc, bool _DaInBienLai)
        {
            string strSQL = "update THUPHI_THUOC set DaInBienLai = @DaInBienLai where MaThuoc in (" + _MaThuoc +
                            ") and MaTiepNhan = @MaTiepNhan";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Mathuoc", _MaThuoc.Replace("'", "")),
                new SqlParameter("@Matiepnhan", _MaTiepNhan),
                new SqlParameter("@DaInBienLai", _DaInBienLai)
            };
            return (int) DataProvider.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        public int Delete_THUPHI_THUOC(THUPHI_THUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Delete thuphi_thuoc";
            strSQL += "\n where mathuoc = @mathuoc and matiepnhan = @matiepnhan";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Matiepnhan", objInfo.Matiepnhan)
            };
            return (int) DataProvider.ExecuteNonQuery(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(THUPHI_THUOC objInfo)
        {
            string strSQL = "select top 1 * from ThuPhi_Thuoc  where mathuoc = @mathuoc and matiepnhan = @matiepnhan";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Matiepnhan", objInfo.Matiepnhan)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_ThuPhi_Thuoc(string _mathuoc, string _matiepnhan, bool _dathuphi)
        {
            string strSQL = "select *  from thuphi_thuoc where 1=1";
            if (_mathuoc.Trim() != "")
            {
                strSQL += "\nand mathuoc ='" + _mathuoc + "'";
            }
            if (_matiepnhan.Trim() != "")
            {
                strSQL += "\nand matiepnhan ='" + _matiepnhan + "'";
            }
            if (_dathuphi)
            {
                strSQL += "\nand DaThuTien = 1";
            }
            return strSQL;
        }

        public DataTable Data_ThuPhi_Thuoc(string _mathuoc, string _matiepnhan)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text, SQL_Select_Data_ThuPhi_Thuoc(_mathuoc, _matiepnhan, false))
                    .Tables[0];
        }

        public DataTable Data_ThuPhi_Thuoc(string _mathuoc, string _matiepnhan, bool _DaThuTien)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_ThuPhi_Thuoc(_mathuoc, _matiepnhan, _DaThuTien)).Tables[0];
        }

        public THUPHI_THUOC Get_Info(string _mathuoc, string _matiepnhan)
        {
            DataTable dt = Data_ThuPhi_Thuoc(_mathuoc, _matiepnhan);
            THUPHI_THUOC obj = new THUPHI_THUOC();
            if (dt.Rows.Count > 0)
            {
                obj.Cachdung = dt.Rows[0]["cachdung"].ToString();
                obj.Chieu = dt.Rows[0]["chieu"].ToString();
                obj.Dainbienlai = (bool) dt.Rows[0]["dainbienlai"];
                obj.Dathutien = (bool) dt.Rows[0]["dathutien"];
                obj.Dongia = (decimal) dt.Rows[0]["dongia"];
                obj.Donvitinh = dt.Rows[0]["donvitinh"].ToString();
                obj.Dvtquicachcap1 = dt.Rows[0]["dvtquicachcap1"].ToString();
                obj.Dvtquicachcap2 = dt.Rows[0]["dvtquicachcap2"].ToString();
                obj.Magocthuoc = dt.Rows[0]["magocthuoc"].ToString();
                obj.Mathuoc = dt.Rows[0]["mathuoc"].ToString();
                obj.Matiepnhan = dt.Rows[0]["matiepnhan"].ToString();
                obj.Nguoinhap = dt.Rows[0]["nguoinhap"].ToString();
                obj.Sang = dt.Rows[0]["sang"].ToString();
                obj.Slquicachcap1 = (int?) dt.Rows[0]["slquicachcap1"];
                obj.Slquicachcap2 = (int?) dt.Rows[0]["slquicachcap2"];
                obj.Soluong = (int) dt.Rows[0]["soluong"];
                obj.Tenthuoc = dt.Rows[0]["tenthuoc"].ToString();
                obj.Tgnhap = (DateTime) dt.Rows[0]["tgnhap"];
                obj.Thanhtien = (decimal) dt.Rows[0]["thanhtien"];
                obj.Toi = dt.Rows[0]["toi"].ToString();
                obj.Trua = dt.Rows[0]["trua"].ToString();
                obj.Xuattheoqcdg = (bool) dt.Rows[0]["xuattheoqcdg"];
            }
            return obj;
        }

        public void Data_ThuPhi_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _mathuoc, string _matiepnhan)
        {
            DataProvider.SelInsUpdDelODBC(SQL_Select_Data_ThuPhi_Thuoc(_mathuoc, _matiepnhan, false), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_ThuPhi_Thuoc(CustomComboBox cbo, string _ValueColumn, string _DisplayColumn,
            string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt, int LinkColumnIndex,
            string _mathuoc, string _matiepnhan)
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
            cbo.DataSource = Data_ThuPhi_Thuoc(_mathuoc, _matiepnhan);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_ThuPhi_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }
    }

    public class VT_XUATKHO_CHITIET_THUOC_DAL
    {

        public VT_XUATKHO_CHITIET_THUOC_DAL()
        {
        }

        public int Insert_Update_VT_XUATKHO_CHITIET_THUOC(VT_XUATKHO_CHITIET_THUOC objInfo, bool _isUpdate)
        {
            string strSQL = "";
            if (_isUpdate)
            {
                strSQL = "Update vt_xuatkho_chitiet_thuoc set";
                strSQL +=
                    "\ncachdung = @cachdung,chieu = @chieu,dain = @dain,dongia = @dongia,donvitinh = @donvitinh,dvtquicachcap1 = @dvtquicachcap1,dvtquicachcap2 = @dvtquicachcap2,ghichu = @ghichu,magocthuoc = @magocthuoc,manhacungcap = @manhacungcap";
                strSQL +=
                    "\n,manhomthuoc = @manhomthuoc,maphieunhap = @maphieunhap,maphieuxuat = @maphieuxuat,mathuoc = @mathuoc,mavattu = @mavattu,sang = @sang,slquicachcap1 = @slquicachcap1,slquicachcap2 = @slquicachcap2,solo = @solo,soluong = @soluong";
                strSQL +=
                    "\n,tenthuoc = @tenthuoc,tgcapnhat = @tgcapnhat,tgnhap = @tgnhap,thanhtien = @thanhtien,toi = @toi,trua = @trua,xuattheoqcdg = @xuattheoqcdg where maphieunhap = @maphieunhap and maphieuxuat = @maphieuxuat and mathuoc = @mathuoc";
            }
            else
            {
                if (Check_Exists(objInfo))
                {
                    CustomMessageBox.MSG_Information_OK("Không thể xuất 2 lần cho thuốc.\nHãy xóa thuốc đã xuất và nhập lại!");
                    return -1;
                }
                strSQL = "Insert into vt_xuatkho_chitiet_thuoc (";
                strSQL += "\ncachdung,chieu,dain,dongia,donvitinh,dvtquicachcap1,dvtquicachcap2,magocthuoc,manhacungcap";
                strSQL +=
                    "\n,manhomthuoc,maphieunhap,maphieuxuat,mathuoc,mavattu,sang,slquicachcap1,slquicachcap2,solo,soluong";
                strSQL += "\n,tenthuoc,tgnhap,thanhtien,toi,trua,xuattheoqcdg)";
                strSQL +=
                    "\nselect cachdung,chieu,0,gia,donvitinh,dvtquicachcap1,dvtquicachcap2,t.magocthuoc,@Manhacungcap";
                strSQL +=
                    "\n,g.manhomthuoc,@Maphieunhap,@Maphieuxuat,t.mathuoc,mavattu,sang,slquicachcap1,slquicachcap2,@Solo,@Soluong";
                strSQL += "\n,tenthuoc,getdate(),@Soluong * gia  as ThanhTien,toi,trua,xuattheoqcdg";
                strSQL +=
                    "\nfrom {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc t inner join {{TPH_Standard}}_Dictionary.dbo.dm_thuoc_gocthuoc g on g.MaGocThuoc = t.MaGocThuoc where t.MaThuoc = @Mathuoc";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Cachdung", objInfo.Cachdung),
                new SqlParameter("@Chieu", objInfo.Chieu),
                new SqlParameter("@Dain", objInfo.Dain),
                new SqlParameter("@Dongia", objInfo.Dongia),
                new SqlParameter("@Ghichu", objInfo.Ghichu),
                new SqlParameter("@Magocthuoc", objInfo.Magocthuoc),
                new SqlParameter("@Manhacungcap", objInfo.Manhacungcap),
                new SqlParameter("@Manhomthuoc", objInfo.Manhomthuoc),
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Mavattu", objInfo.Mavattu),
                new SqlParameter("@Sang", objInfo.Sang),
                new SqlParameter("@Solo", objInfo.Solo),
                new SqlParameter("@Soluong", objInfo.Soluong),
                new SqlParameter("@Tenthuoc", objInfo.Tenthuoc),
                new SqlParameter("@Thanhtien", objInfo.Thanhtien),
                new SqlParameter("@Toi", objInfo.Toi),
                new SqlParameter("@Trua", objInfo.Trua),
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Update_Donthuoc(VT_XUATKHO_CHITIET_THUOC objInfo)
        {
            string strSQL = "";
            strSQL = "Update vt_xuatkho_chitiet_thuoc set";
            strSQL += "\ncachdung = @cachdung,ghichu = @ghichu";
            strSQL += "\n,sang = @sang,trua = @trua,chieu = @chieu,toi = @toi,soluong = @soluong";
            strSQL +=
                "\n,tgcapnhat = getdate() where maphieunhap = @maphieunhap and maphieuxuat = @maphieuxuat and mathuoc = @mathuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Cachdung", objInfo.Cachdung),
                new SqlParameter("@Sang", objInfo.Sang),
                new SqlParameter("@Trua", objInfo.Trua),
                new SqlParameter("@Chieu", objInfo.Chieu),
                new SqlParameter("@Toi", objInfo.Toi),
                new SqlParameter("@Ghichu", objInfo.Ghichu),
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc),
                new SqlParameter("@Soluong", objInfo.Soluong),
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public int Delete_VT_XUATKHO_CHITIET_THUOC(VT_XUATKHO_CHITIET_THUOC objInfo, bool _TheoPhieuXuat)
        {
            string strSQL = "";
            strSQL = "Delete vt_xuatkho_chitiet_thuoc";
            if (_TheoPhieuXuat)
            {
                strSQL += "\n where maphieuxuat = @maphieuxuat";
            }
            else
            {
                strSQL += "\n where maphieunhap = @maphieunhap and maphieuxuat = @maphieuxuat and mathuoc = @mathuoc";
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc)
            };
            return (int) DataProvider.ExecuteScalar(CommandType.Text, strSQL, param);
        }

        public bool Check_Exists(VT_XUATKHO_CHITIET_THUOC objInfo)
        {
            string strSQL =
                "select top 1 * from VT_XuatKho_ChiTiet_Thuoc  where maphieunhap = @maphieunhap and maphieuxuat = @maphieuxuat and mathuoc = @mathuoc";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Maphieunhap", objInfo.Maphieunhap),
                new SqlParameter("@Maphieuxuat", objInfo.Maphieuxuat),
                new SqlParameter("@Mathuoc", objInfo.Mathuoc)
            };
            return DataProvider.CheckExisted(strSQL, param);
        }

        private string SQL_Select_Data_VT_XuatKho_ChiTiet_Thuoc(string _maphieunhap, string _maphieuxuat,
            string _mathuoc)
        {
            string strSQL = "select *  from vt_xuatkho_chitiet_thuoc where 1=1";
            if (_maphieunhap.Trim() != "")
            {
                strSQL += "\nand maphieunhap ='" + _maphieunhap + "'";
            }
            if (_maphieuxuat.Trim() != "")
            {
                strSQL += "\nand maphieuxuat ='" + _maphieuxuat + "'";
            }
            if (_mathuoc.Trim() != "")
            {
                strSQL += "\nand mathuoc ='" + _mathuoc + "'";
            }
            return strSQL;
        }

        public DataTable Data_VT_XuatKho_ChiTiet_Thuoc(string _maphieunhap, string _maphieuxuat, string _mathuoc)
        {
            return
                DataProvider.ExecuteDataset(CommandType.Text,
                    SQL_Select_Data_VT_XuatKho_ChiTiet_Thuoc(_maphieunhap, _maphieuxuat, _mathuoc)).Tables[0];
        }

        public VT_XUATKHO_CHITIET_THUOC Get_Info(string _maphieunhap, string _maphieuxuat, string _mathuoc)
        {
            DataTable dt = Data_VT_XuatKho_ChiTiet_Thuoc(_maphieunhap, _maphieuxuat, _mathuoc);
            VT_XUATKHO_CHITIET_THUOC obj = new VT_XUATKHO_CHITIET_THUOC();
            if (dt.Rows.Count > 0)
            {
                obj.Cachdung = dt.Rows[0]["cachdung"].ToString();
                obj.Chieu = dt.Rows[0]["chieu"].ToString();
                obj.Dain = (bool) dt.Rows[0]["dain"];
                obj.Dongia = (decimal) dt.Rows[0]["dongia"];
                obj.Donvitinh = dt.Rows[0]["donvitinh"].ToString();
                obj.Dvtquicachcap1 = dt.Rows[0]["dvtquicachcap1"].ToString();
                obj.Dvtquicachcap2 = dt.Rows[0]["dvtquicachcap2"].ToString();
                obj.Ghichu = dt.Rows[0]["ghichu"].ToString();
                obj.Magocthuoc = dt.Rows[0]["magocthuoc"].ToString();
                obj.Manhacungcap = dt.Rows[0]["manhacungcap"].ToString();
                obj.Manhomthuoc = dt.Rows[0]["manhomthuoc"].ToString();
                obj.Maphieunhap = dt.Rows[0]["maphieunhap"].ToString();
                obj.Maphieuxuat = dt.Rows[0]["maphieuxuat"].ToString();
                obj.Mathuoc = dt.Rows[0]["mathuoc"].ToString();
                obj.Mavattu = dt.Rows[0]["mavattu"].ToString();
                obj.Sang = dt.Rows[0]["sang"].ToString();
                obj.Slquicachcap1 = (int?) dt.Rows[0]["slquicachcap1"];
                obj.Slquicachcap2 = (int?) dt.Rows[0]["slquicachcap2"];
                obj.Solo = dt.Rows[0]["solo"].ToString();
                obj.Soluong = (float) dt.Rows[0]["soluong"];
                obj.Tenthuoc = dt.Rows[0]["tenthuoc"].ToString();
                obj.Tgcapnhat = (DateTime?) dt.Rows[0]["tgcapnhat"];
                obj.Tgnhap = (DateTime) dt.Rows[0]["tgnhap"];
                obj.Thanhtien = (decimal) dt.Rows[0]["thanhtien"];
                obj.Toi = dt.Rows[0]["toi"].ToString();
                obj.Trua = dt.Rows[0]["trua"].ToString();
                obj.Xuattheoqcdg = (bool) dt.Rows[0]["xuattheoqcdg"];
            }
            return obj;
        }

        public void Data_VT_XuatKho_ChiTiet_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            ref TPH.LIS.Common.Controls.CustomDatagridView dtg, ref TPH.LIS.Common.Controls.CustomBindingNavigator bv,
            string _maphieunhap, string _maphieuxuat, string _mathuoc)
        {
            DataProvider.SelInsUpdDelODBC(
                SQL_Select_Data_VT_XuatKho_ChiTiet_Thuoc(_maphieunhap, _maphieuxuat, _mathuoc), ref da, ref dt);
            ControlExtension.BindDataToGrid(dt, ref dtg, ref bv);
        }

        public void Data_VT_XuatKho_ChiTiet_Thuoc(CustomComboBox cbo, string _ValueColumn,
            string _DisplayColumn, string ColumnsName, string ColumnsWidth, System.Windows.Forms.TextBox txt,
            int LinkColumnIndex, string _maphieunhap, string _maphieuxuat, string _mathuoc)
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
            cbo.DataSource = Data_VT_XuatKho_ChiTiet_Thuoc(_maphieunhap, _maphieuxuat, _mathuoc);
            cbo.SelectedIndex = -1;
        }

        public void Update_DataTable_VT_XuatKho_ChiTiet_Thuoc(ref SqlDataAdapter da, ref DataTable dt,
            TPH.LIS.Common.Controls.CustomDatagridView dtg, TPH.LIS.Common.Controls.CustomBindingNavigator bv)
        {
            dtg.BindingContext[dt].EndCurrentEdit();
            DataProvider.UpdateData(da, ref dt, "", "");
        }

        //In đơn thuốc
        public void Print_DonThuoc(string _MaPhieuXuat, bool _PrintDirect, string _PrinterName)
        {
            DataTable dt = new DataTable();
            string _strSQL =
                "select t.MaBN,t.MatiepNhan, t.TenBN,t.DiaChi,t.Tuoi,t.SinhNhat, t.CoNgaySinh,case when t.GioiTinh = 'F' then N'Nữ' when t.GioiTinh ='M' then N'Nam' else '' end as GioiTinh,t.Email";
            _strSQL += "\n,t.GioiTinh,t.MaDonVi, t.SDT,t.SoBHYT";
            _strSQL += "\n,t.TenDonVi,t.NgayTiepNhan,nv.TenNhanVien as BSDieuTri, t.ChanDoan,";
            _strSQL +=
                "\n N'' as LoiDan, N'' as DeNghi, null as NgayDieuTri,null as NgayTaiKham, cast (0 as bit) as HentaiKham";
            _strSQL += "\n,A.*";
            _strSQL += "\nfrom (";
            _strSQL +=
                "\nselect d.MaPhieuXuat,d.MaThuoc,d.TenThuoc, sum(d.SoLuong) as SoLuong, d.Sang,d.Trua,d.Chieu,d.Toi,";
            _strSQL += "\nd.DonViTinh,cd.TenCachDung, N'Ngày ' + LOWER(cd.TenCachDung) + ' ' ";
            _strSQL += "\n+ cast (sum(case when Sang is null or len (rtrim(d.Sang))=0 then 0 else 1 end +";
            _strSQL += "\ncase when d.Trua is null or len (rtrim(d.Trua))=0 then 0 else 1 end + ";
            _strSQL += "\ncase when d.Chieu is null or len (rtrim(d.Chieu))=0 then 0 else 1 end + ";
            _strSQL += "\ncase when d.Toi is null or len (rtrim(d.Toi))=0 then 0 else 1 end) as varchar(5)) + ";
            _strSQL += "\nN' lần'";
            _strSQL += "\nas ChiDinhDung";
            _strSQL += "\nfrom VT_XuatKho_ChiTiet_Thuoc d left join {{TPH_Standard}}_Dictionary.dbo.DM_Thuoc_CachDung cd on d.CachDung=cd.ID";
            _strSQL += "\ngroup by d.MaPhieuXuat,d.MaThuoc,d.TenThuoc, Sang,Trua,Chieu,Toi,DonViTinh,cd.TenCachDung";
            _strSQL += "\n) as A";
            _strSQL += "\ninner join VT_XuatKho_PhieuXuat_Thuoc k on A.MaPhieuXuat = k.MaPhieuXuat";
            _strSQL += "\ninner join BenhNhan_TiepNhan t on t.MaTiepNhan = k.MaTiepNhan";
            _strSQL += "\nleft join {{TPH_Standard}}_Dictionary.dbo.QL_NHANVIEN nv on t.BacSiCD = nv.MaNhanVien ";
            _strSQL += "\nwhere k.MaPhieuXuat = '" + _MaPhieuXuat + "'";

            dt = DataProvider.ExecuteDataset(CommandType.Text, _strSQL).Tables[0];

            //Reports.rpDonThuoc rp = new Reports.rpDonThuoc();
            //FrmReport frm = new FrmReport();
            //frm.crViewer.ReportSource = rp;
            //frm.PrinterName = _PrinterName;
            //frm.Excute_Show_Print_Report(rp, dt, "TT", false, false, !_PrintDirect, _PrintDirect, _PrinterName, false);
        }
    }
}