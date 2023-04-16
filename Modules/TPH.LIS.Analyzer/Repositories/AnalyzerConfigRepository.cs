using System;
using System.Data;
using System.Data.SqlClient;
using TPH.Common.Converter;
using TPH.LIS.Analyzer.Model;
using TPH.LIS.Common;
using TPH.LIS.Common.Controls;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;
using TPH.LIS.Log.Services.WorkingLog;

namespace TPH.LIS.Analyzer.Repositories
{
    public class AnalyzerConfigRepository : IAnalyzerConfigRepository
    {
        private readonly IWorkingLogService _ilog = new WorkingLogService();

        #region H_MAYXETNGHIEM
        public int Insert_Update_H_MAYXETNGHIEM(H_MAYXETNGHIEM objInfo, bool isUpdate)
        {
            var strSql = "";
            if (isUpdate)
            {
                strSql = "Update {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem set";
                strSql +=
                    "\nloaiketnoi = @loaiketnoi,protocol = @protocol,tenmay = @tenmay,tudongvalid = @tudongvalid where idmay = @idmay";
            }
            else
            {
                if (DataProvider.CheckExisted("Select * from {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem where idmay = '" + objInfo.Idmay + "'"))
                {
                    CustomMessageBox.MSG_Information_OK("Mã máy đã tồn tại ! \nHãy nhập mã máy khác.");
                    return -1;
                }

                strSql = "Insert into {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem (";
                strSql += "\nidmay,loaiketnoi,protocol,tenmay,tudongvalid)";
                strSql += "\nValues (@idmay,@loaiketnoi,@protocol,@tenmay,@tudongvalid)";
            }

            var param = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Idmay", objInfo.Idmay),
                WorkingServices.GetParaFromOject("@Loaiketnoi", objInfo.Loaiketnoi),
                WorkingServices.GetParaFromOject("@Protocol", objInfo.Protocol),
                WorkingServices.GetParaFromOject("@Tenmay", objInfo.Tenmay),
                WorkingServices.GetParaFromOject("@Tudongvalid", objInfo.Tudongvalid)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql, param);
        }
        public DataTable Data_h_mayxetnghiem(bool withEmpty = false, bool withZero = false, int loaiMay = -1)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@withEmpty", withEmpty)
                    , WorkingServices.GetParaFromOject("@withZero", withZero)
                    , WorkingServices.GetParaFromOject("@loaiMay", loaiMay)
                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_MayXN", sqlPara).Tables[0];
        }

        public bool Delete_MayXetNghiem(H_MAYXETNGHIEM info)
        {
            var param = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Idmay", info.Idmay)
            };
            DataProvider.ExecuteNonQuery(CommandType.Text, "delete {{TPH_Standard}}_Dictionary.dbo.h_mayxetnghiem where Idmay = @Idmay ", param);

            return true;
        }
        public DataTable Data_Loai_KetNoi()
        {
            using (var dt = new DataTable())
            {
                dt.Columns.Add("MaLoaiKetNoi", typeof(string));
                dt.Columns.Add("TenLoaiKetNoi", typeof(string));
                var dr = dt.NewRow();
                dr["MaLoaiKetNoi"] = "COM";
                dr["TenLoaiKetNoi"] = "COM Port";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["MaLoaiKetNoi"] = "LAN";
                dr["TenLoaiKetNoi"] = "LAN (IP)";
                dt.Rows.Add(dr);

                return dt;
            }
        }
        public DataTable DataDanhMucMayXN_GhepCode(string userAllow)
        {
            // selDanhSachMayXn_GhepCodeTrenIMS
            var sqlPara = new SqlParameter[]
                {
                        WorkingServices.GetParaFromOject("@userAllow", userAllow)
                };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhSachMayXn_GhepCodeTrenIMS", sqlPara).Tables[0];
        }
        #endregion
        #region H_BANGMAMAYXN
        public int Insert_h_bangmamayxn(H_BANGMAMAYXN objInfo)
        {
            if (CheckExists_h_bangmamayxn(objInfo.Idmay, objInfo.Maxn)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@idmay", objInfo.Idmay),
                        WorkingServices.GetParaFromOject("@maxn", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@UserD", objInfo.Userd)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_h_bangmamayxn", para);
        }
        public int Update_h_bangmamayxn(H_BANGMAMAYXN objInfo)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@idmay", objInfo.Idmay),
                        WorkingServices.GetParaFromOject("@maxn", objInfo.Maxn),
                        WorkingServices.GetParaFromOject("@mamay", objInfo.Mamay),
                        WorkingServices.GetParaFromOject("@chothem", objInfo.Chothem),
                        WorkingServices.GetParaFromOject("@loaimau", objInfo.Loaimau),
                        WorkingServices.GetParaFromOject("@canduoi", objInfo.Canduoi),
                        WorkingServices.GetParaFromOject("@cantren", objInfo.Cantren),
                        WorkingServices.GetParaFromOject("@Inside", objInfo.Inside),
                        WorkingServices.GetParaFromOject("@LonNho", objInfo.Lonnho),
                        WorkingServices.GetParaFromOject("@camdown", objInfo.Camdown),
                        WorkingServices.GetParaFromOject("@VALhigher", objInfo.Valhigher),
                        WorkingServices.GetParaFromOject("@VALlower", objInfo.Vallower),
                        WorkingServices.GetParaFromOject("@LowLimit", objInfo.Lowlimit),
                        WorkingServices.GetParaFromOject("@LowValue", objInfo.Lowvalue),
                        WorkingServices.GetParaFromOject("@HighLimit", objInfo.Highlimit),
                        WorkingServices.GetParaFromOject("@HighValue", objInfo.Highvalue),
                        WorkingServices.GetParaFromOject("@lamtron", objInfo.Lamtron),
                        WorkingServices.GetParaFromOject("@dinhluong", objInfo.Dinhluong),
                        WorkingServices.GetParaFromOject("@dinhtinh", objInfo.Dinhtinh),
                        WorkingServices.GetParaFromOject("@Stat", objInfo.Stat),
                        WorkingServices.GetParaFromOject("@mamay2", objInfo.Mamay2),
                        WorkingServices.GetParaFromOject("@OrtherNMR", objInfo.Orthernmr),
                        WorkingServices.GetParaFromOject("@TestCode_old", objInfo.Testcode_old),
                        WorkingServices.GetParaFromOject("@heso", objInfo.Heso),
                        WorkingServices.GetParaFromOject("@dieukien", objInfo.Dieukien),
                        WorkingServices.GetParaFromOject("@MasterTest", objInfo.Mastertest),
                        WorkingServices.GetParaFromOject("@Tube", objInfo.Tube),
                        WorkingServices.GetParaFromOject("@matrunggian", objInfo.Matrunggian),
                        WorkingServices.GetParaFromOject("@GetFlag", objInfo.Getflag),
                        WorkingServices.GetParaFromOject("@KhongLamTronQC", objInfo.Khonglamtronqc),
                        WorkingServices.GetParaFromOject("@LayLog10QC", objInfo.Laylog10qc),
                        WorkingServices.GetParaFromOject("@QCOut", objInfo.Qcout)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_h_bangmamayxn", para);
        }
        public int Delete_h_bangmamayxn(int idmay, string maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@idmay", idmay),
                        WorkingServices.GetParaFromOject("@maxn", maxn)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_h_bangmamayxn", para);
        }
        public DataTable Data_h_bangmamayxn(int idmay, string maxn)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@idmay", idmay),
                        WorkingServices.GetParaFromOject("@maxn", maxn)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_h_bangmamayxn", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DataTable Data_h_bangmamayxn(int idmay, string maxn, string maXnMay)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@idmay", idmay),
                        WorkingServices.GetParaFromOject("@maxn", maxn),
                        WorkingServices.GetParaFromOject("@maxnMay", maXnMay)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_h_bangmamayxn", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public H_BANGMAMAYXN Get_Info_h_bangmamayxn(DataRow drInfo)
        {
            return (H_BANGMAMAYXN)WorkingServices.Get_InfoForObject(new H_BANGMAMAYXN(), drInfo);
        }
        public H_BANGMAMAYXN Get_Info_h_bangmamayxn(int idmay, string maxn)
        {
            DataTable dt = Data_h_bangmamayxn(idmay, maxn);
            H_BANGMAMAYXN obj = new H_BANGMAMAYXN();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_h_bangmamayxn(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_h_bangmamayxn(int idmay, string maxn)
        {
            return Data_h_bangmamayxn(idmay, maxn).Rows.Count > 0;
        }

        public DataTable Data_h_bangmamayxn_xetnghiem_forSelect(string idMay, string maXnMay, string maXn, string nhomXn)
        {
            var para = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@idMay", idMay)
                ,WorkingServices.GetParaFromOject("@maXn", maXn)
                ,WorkingServices.GetParaFromOject("@maXnMay", maXnMay)
                ,WorkingServices.GetParaFromOject("@NhomXn", nhomXn)
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "selDanhMuc_XetNghiemMappingMay", para).Tables[0];
        }
        public DataTable Data_Status()
        {
            var data = new DataTable();
            data.Columns.Add("StatusID", typeof(string));
            data.Columns.Add("StatusName", typeof(string));

            var Data_Status = TestingResultStatusConstant.TestingResultStatusConstantList;

            foreach (string column in Data_Status.Values)
            {
                var datarow = data.NewRow();
                datarow["StatusID"] = column;
                datarow["StatusName"] = column;
                data.Rows.Add(datarow);
            }
            return data;

        }
        #endregion
        #region H_HOSTCONFIG
        public int Insert_Update_H_HOSTCONFIG(H_HOSTCONFIG objInfo, bool isUpdate)
        {
            var strSql = "";
            if (isUpdate)
            {
                strSql = "Update {{TPH_Standard}}_System.dbo.h_hostconfig set";
                strSql +=
                    "\ncomport = @comport,idmay = @idmay,ipaddress = @ipaddress,ipport = @ipport,loai = @loai,mayxn = @mayxn,pcname = @pcname,portid = @portid,protocol = @protocol,setting = @setting";
            }
            else
            {
                strSql = "Insert into {{TPH_Standard}}_System.dbo.h_hostconfig (";
                strSql += "\ncomport,idmay,ipaddress,ipport,loai,mayxn,pcname,portid,protocol,setting)";
                strSql +=
                    "\nValues (@comport,@idmay,@ipaddress,@ipport,@loai,@mayxn,@pcname,@portid,@protocol,@setting)";
            }

            var param = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Comport", objInfo.Comport),
                WorkingServices.GetParaFromOject("@Idmay", objInfo.Idmay),
                WorkingServices.GetParaFromOject("@Ipaddress", objInfo.Ipaddress),
                WorkingServices.GetParaFromOject("@Ipport", objInfo.Ipport),
                WorkingServices.GetParaFromOject("@Loai", objInfo.Loai),
                WorkingServices.GetParaFromOject("@Mayxn", objInfo.Mayxn),
                WorkingServices.GetParaFromOject("@Pcname", objInfo.Pcname),
                WorkingServices.GetParaFromOject("@Portid", objInfo.Portid),
                WorkingServices.GetParaFromOject("@Protocol", objInfo.Protocol),
                WorkingServices.GetParaFromOject("@Setting", objInfo.Setting)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql, param);
        }
        public DataTable Data_h_hostconfig()
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select * from {{TPH_Standard}}_System.dbo.h_hostconfig").Tables[0];
        }
        #endregion
        #region H_KETQUAMAY
        public int Insert_Update_H_KETQUAMAY(H_KETQUAMAY objInfo, bool isUpdate)
        {
            var strSql = "";
            if (isUpdate)
            {
                strSql = "Update h_ketquamay set";
                strSql +=
                    "\ncongketnoi = @congketnoi,donvi = @donvi,id = @id,idmay = @idmay,ketqua = @ketqua,ketquagoc = @ketquagoc,mamay = @mamay,maxn = @maxn,ngayxn = @ngayxn,pid = @pid";
                strSql +=
                    "\n,seq = @seq,sid = @sid,thoigiantumay = @thoigiantumay,trangthai = @trangthai,userdelete = @userdelete,uservalid = @uservalid";
            }
            else
            {
                strSql = "Insert into h_ketquamay (";
                strSql += "\ncongketnoi,donvi,id,idmay,ketqua,ketquagoc,mamay,maxn,ngayxn,pid";
                strSql += "\n,seq,sid,thoigiantumay,trangthai,userdelete,uservalid)";
                strSql += "\nValues (@congketnoi,@donvi,@id,@idmay,@ketqua,@ketquagoc,@mamay,@maxn,@ngayxn,@pid";
                strSql += "\n,@seq,@sid,@thoigiantumay,@trangthai,@userdelete,@uservalid)";
            }

            var param = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Congketnoi", objInfo.Congketnoi),
                WorkingServices.GetParaFromOject("@Donvi", objInfo.Donvi),
                WorkingServices.GetParaFromOject("@Id", objInfo.Id),
                WorkingServices.GetParaFromOject("@Idmay", objInfo.Idmay),
                WorkingServices.GetParaFromOject("@Ketqua", objInfo.Ketqua),
                WorkingServices.GetParaFromOject("@Ketquagoc", objInfo.Ketquagoc),
                WorkingServices.GetParaFromOject("@Mamay", objInfo.Mamay),
                WorkingServices.GetParaFromOject("@Maxn", objInfo.Maxn),
                WorkingServices.GetParaFromOject("@Ngayxn", objInfo.Ngayxn),
                WorkingServices.GetParaFromOject("@Pid", objInfo.Pid),
                WorkingServices.GetParaFromOject("@Seq", objInfo.Seq),
                WorkingServices.GetParaFromOject("@Sid", objInfo.Sid),
                WorkingServices.GetParaFromOject("@Thoigiantumay", objInfo.Thoigiantumay),
                WorkingServices.GetParaFromOject("@Trangthai", objInfo.Trangthai),
                WorkingServices.GetParaFromOject("@Userdelete", objInfo.Userdelete),
                WorkingServices.GetParaFromOject("@Uservalid", objInfo.Uservalid)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql, param);
        }
        public DataTable Data_h_ketquamay()
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select * from h_ketquamay").Tables[0];
        }
        #endregion
        #region H_THONGTINKETQUAMAY
        public int Insert_Update_H_THONGTINKETQUAMAY(H_THONGTINKETQUAMAY objInfo, bool isUpdate)
        {
            var strSql = "";
            if (isUpdate)
            {
                strSql = "Update h_thongtinketquamay set";
                strSql += "\nid = @id,idmay = @idmay,intime = @intime,ngayxn = @ngayxn,pcname = @pcname,sid = @sid";
            }
            else
            {
                strSql = "Insert into h_thongtinketquamay (";
                strSql += "\nid,idmay,intime,ngayxn,pcname,sid)";
                strSql += "\nValues (@id,@idmay,@intime,@ngayxn,@pcname,@sid)";
            }

            var param = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@Id", objInfo.Id),
                WorkingServices.GetParaFromOject("@Idmay", objInfo.Idmay),
                WorkingServices.GetParaFromOject("@Intime", objInfo.Intime),
                WorkingServices.GetParaFromOject("@Ngayxn", objInfo.Ngayxn),
                WorkingServices.GetParaFromOject("@Pcname", objInfo.Pcname),
                WorkingServices.GetParaFromOject("@Sid", objInfo.Sid)
            };

            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, strSql, param);
        }
        public DataTable Data_h_thongtinketquamay()
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "select * from h_thongtinketquamay").Tables[0];
        }
        #endregion
        #region chaymau_vitrimau
        public int Insert_ViTriChayMau_Plate(CHAYMAU_VITRIMAU objIn)
        {
            //@IDLanTao int,
            //@NgayChayMau datetime,
            //@idmayXn int,
            //@PlateCode varchar(50),
            //@PlateCount int,
            //@PosCode varchar(30),
            //@MaXetNghiem varchar(25),
            //@Samples int,
            //@MaXetNghiemMay varchar(50),
            //@ViTriDoc int,
            //@ViTriNgang int
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@IDLanTao",objIn.Idlantao),
                    WorkingServices.GetParaFromOject("@NgayChayMau",objIn.Ngaychaymau,true),
                    WorkingServices.GetParaFromOject("@idmayXn",objIn.Insid),
                    WorkingServices.GetParaFromOject("@PlateCode",objIn.Platecode),
                    WorkingServices.GetParaFromOject("@PlateCount",objIn.Platecount),
                    WorkingServices.GetParaFromOject("@PosCode",objIn.Poscode),
                    WorkingServices.GetParaFromOject("@MaXetNghiem",objIn.Maxetnghiem),
                    WorkingServices.GetParaFromOject("@Samples",objIn.Samples),
                    WorkingServices.GetParaFromOject("@MaXetNghiemMay",objIn.Maxetnghiemmay),
                    WorkingServices.GetParaFromOject("@ViTriDoc",objIn.Vitridoc),
                    WorkingServices.GetParaFromOject("@ViTriNgang",objIn.Vitringang),
                    WorkingServices.GetParaFromOject("@RunType",objIn.Runtype),
                    WorkingServices.GetParaFromOject("@ValueDisplay",objIn.Valuedisplay)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_ViTriMauChay_Plate", sqlPara);
        }
        public int Delete_ViTriChayMa_Plate(int idLantao)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@IDLanTao",idLantao)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_ViTriMauChay_Plate", sqlPara);
        }
        public int Update_ViTriChayMau_Pos(CHAYMAU_VITRIMAU objIn)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@id",objIn.Id),
                    WorkingServices.GetParaFromOject("@Barcode",objIn.Barcode)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_ViTriMauChay_Barcode_Plate", sqlPara);
        }
        public int Update_ViTriChayMau_Pos_Runtype(CHAYMAU_VITRIMAU objIn)
        {
            var sqlPara = new SqlParameter[]
                {
                    WorkingServices.GetParaFromOject("@id",objIn.Id),
                    WorkingServices.GetParaFromOject("@RunType",objIn.Runtype),
                    WorkingServices.GetParaFromOject("@DisplayValue",objIn.Valuedisplay)
                };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "upd_ViTriMauChay_Barcode_Plate_Runtype", sqlPara);
        }
        public DataTable Data_VitriChayChaiMau_Plate(DateTime tuNgay, DateTime denNgay, int idMay, string maXn)
        {
            //sel_ViTriMauChay_Plate
            //@TuNgay datetime
            //,@DenNgay datetime
            //, @IdMayXN int
            // , @MaXn varchar(25)
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@TuNgay",tuNgay,true),
                WorkingServices.GetParaFromOject("@DenNgay",denNgay,true),
                WorkingServices.GetParaFromOject("@IdMayXN",idMay),
                WorkingServices.GetParaFromOject("@MaXn",maXn),
            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_ViTriMauChay_Plate", sqlPara).Tables[0];
        }
        public DataTable Data_ViTriChayMau_Pos(int id)
        {
            
            var sqlPara = new SqlParameter[]
            {
                WorkingServices.GetParaFromOject("@IDLanTao",id)

            };
            return DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_VitriMauChay_Chitiet_Plate", sqlPara).Tables[0];
        }
        public int ViTriChayMau_IdLanTao()
        {
            return int.Parse(DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_ViTriMauChay_MaxIdLanTao").Tables[0].Rows[0]["ID"].ToString());
        }
        public CHAYMAU_VITRIMAU GetInfo_VitriChayMua_Pos (int id)
        {
            var data = Data_ViTriChayMau_Pos(id);
            if(data.Rows.Count >0)
            {
                return GetInfo_VitriChayMua_Pos_ByRow(data.Rows[0]);
            }
            return null;
        }
        public CHAYMAU_VITRIMAU GetInfo_VitriChayMua_Pos_ByRow(DataRow dr)
        {
            var obj = new CHAYMAU_VITRIMAU();
                obj.Id = NumberConverter.To<int>(dr["id"]);
                obj.Idlantao = NumberConverter.To<int>(dr["idlantao"]);
                obj.Ngaychaymau = (DateTime)dr["ngaychaymau"];
                obj.Insid = NumberConverter.To<int>(dr["insid"]);
                obj.Platecode = StringConverter.ToString(dr["platecode"]);
                obj.Platecount = NumberConverter.To<int>(dr["platecount"]);
                obj.Vitridoc = NumberConverter.To<int>(dr["vitridoc"]);
                obj.Vitringang = NumberConverter.To<int>(dr["vitringang"]);
                if (!string.IsNullOrEmpty(dr["barcode"].ToString()))
                    obj.Barcode = StringConverter.ToString(dr["barcode"]);
                if (!string.IsNullOrEmpty(dr["poscode"].ToString()))
                    obj.Poscode = StringConverter.ToString(dr["poscode"]);
                if (!string.IsNullOrEmpty(dr["maxetnghiem"].ToString()))
                    obj.Maxetnghiem = StringConverter.ToString(dr["maxetnghiem"]);
                if (!string.IsNullOrEmpty(dr["maxetnghiemmay"].ToString()))
                    obj.Maxetnghiemmay = StringConverter.ToString(dr["maxetnghiemmay"]);
                obj.Samples = NumberConverter.To<int>(dr["samples"]);
            if (!string.IsNullOrEmpty(dr["RunType"].ToString()))
                obj.Runtype = NumberConverter.To<int>(dr["RunType"]);
            if (!string.IsNullOrEmpty(dr["ValueDisplay"].ToString()))
                obj.Valuedisplay = StringConverter.ToString(dr["ValueDisplay"]);


            return obj;
        }
        #endregion
        #region dm_maytinh_mayxetnghiem
        public int Insert_dm_maytinh_mayxetnghiem(DM_MAYTINH_MAYXETNGHIEM objInfo)
        {
            if (CheckExists_dm_maytinh_mayxetnghiem(objInfo.Makhuvuc, objInfo.Tenmaytinh, objInfo.Idmayxetnghiem)) return -1;
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", objInfo.Makhuvuc),
                        WorkingServices.GetParaFromOject("@TenMayTinh", objInfo.Tenmaytinh),
                        WorkingServices.GetParaFromOject("@IdMayXetNghiem", objInfo.Idmayxetnghiem),
                        WorkingServices.GetParaFromOject("@NguoiNhap", objInfo.Nguoinhap)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "ins_dm_maytinh_mayxetnghiem", para);
        }
        public int Delete_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", makhuvuc),
                        WorkingServices.GetParaFromOject("@TenMayTinh", tenmaytinh),
                        WorkingServices.GetParaFromOject("@IdMayXetNghiem", idmayxetnghiem)
                        };
            return (int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "del_dm_maytinh_mayxetnghiem", para);
        }
        public DataTable Data_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {
            var para = new SqlParameter[] {
                        WorkingServices.GetParaFromOject("@MaKhuVuc", makhuvuc),
                        WorkingServices.GetParaFromOject("@TenMayTinh", tenmaytinh),
                        WorkingServices.GetParaFromOject("@IdMayXetNghiem", idmayxetnghiem)
                        };
            var ds = DataProvider.ExecuteDataset(CommandType.StoredProcedure, "sel_dm_maytinh_mayxetnghiem", para);
            if (ds == null) return null;
            return ds.Tables[0];
        }
        public DM_MAYTINH_MAYXETNGHIEM Get_Info_dm_maytinh_mayxetnghiem(DataRow drInfo)
        {
            return (DM_MAYTINH_MAYXETNGHIEM)WorkingServices.Get_InfoForObject(new DM_MAYTINH_MAYXETNGHIEM(), drInfo);
        }
        public DM_MAYTINH_MAYXETNGHIEM Get_Info_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {
            DataTable dt = Data_dm_maytinh_mayxetnghiem(makhuvuc, tenmaytinh, idmayxetnghiem);
            DM_MAYTINH_MAYXETNGHIEM obj = new DM_MAYTINH_MAYXETNGHIEM();
            if (dt.Rows.Count > 0)
            {
                obj = Get_Info_dm_maytinh_mayxetnghiem(dt.Rows[0]);
            }
            return obj;
        }
        public bool CheckExists_dm_maytinh_mayxetnghiem(string makhuvuc, string tenmaytinh, int? idmayxetnghiem)
        {
            return Data_dm_maytinh_mayxetnghiem(makhuvuc, tenmaytinh, idmayxetnghiem).Rows.Count > 0;
        }
        #endregion
    }
}
