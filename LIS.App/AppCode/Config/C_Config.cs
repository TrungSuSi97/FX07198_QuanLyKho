using System;
using System.Data;
using TPH.LIS.Common.Extensions;
using TPH.LIS.Data;

namespace TPH.LIS.App.AppCode.Config
{
    internal class C_Config
    {
        public C_Config()
        {
        }


        public void LoadPrintHeader(string locatioId)
        {
            var strSql = " select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_TieuDeTrangIn where MaDonVi='" + locatioId + "'";
            var dt = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables[0];

            if (dt.Rows.Count <= 0) return;

            CommonAppVarsAndFunctions.TenPhieu = dt.Rows[0]["TenPhieuIn"].ToString().Trim();
            CommonAppVarsAndFunctions.TenNguoiKy = dt.Rows[0]["NguoiKyTen"].ToString().Trim();
            CommonAppVarsAndFunctions.ChucVu = dt.Rows[0]["ChucVu"].ToString().Trim();
            CommonAppVarsAndFunctions.TieuDe1 = dt.Rows[0]["TieuDe1"].ToString().Trim();
            CommonAppVarsAndFunctions.TieuDe2 = dt.Rows[0]["TieuDe2"].ToString().Trim();
            CommonAppVarsAndFunctions.TieuDe3 = dt.Rows[0]["TieuDe3"].ToString().Trim();
            CommonAppVarsAndFunctions.TieuDe4 = dt.Rows[0]["TieuDe4"].ToString().Trim();
            CommonAppVarsAndFunctions.TieuDe5 = dt.Rows[0]["TieuDe5"].ToString().Trim();
            CommonAppVarsAndFunctions.TieuDe6 = dt.Rows[0]["TieuDe6"].ToString().Trim();
            CommonAppVarsAndFunctions.InMau = bool.Parse(dt.Rows[0]["InMau"].ToString());
        }

        public DataTable Data_SystemConfig_WithComputer(string startKey)
        {
            var dataTableCollection = DataProvider.ExecuteDataset(CommandType.Text,
                "Select * from {{TPH_Standard}}_System.dbo.cauhinh_hethong where MaCauHinh like '" + startKey + "_%' and MayTinh = N'" + Environment.MachineName + "'").Tables;
            
            return dataTableCollection[0];
        }

        public bool Save_SystemConfig(string keyWord, string value)
        {
            if (
                DataProvider.ExecuteDataset(CommandType.Text,
                    "select * from {{TPH_Standard}}_System.dbo.cauhinh_hethong where MaCauHinh = '" + keyWord + "' and MayTinh = N'"+ Environment.MachineName +"'").Tables[0].Rows.Count > 0)
            {
                return
                    DataProvider.ExecuteQuery("update {{TPH_Standard}}_System.dbo.cauhinh_hethong set Giatri = N'" + Utils.ConvertString(value) +
                                              "' where  MaCauHinh = '" + keyWord + "' and MayTinh = N'" + Environment.MachineName + "'");
            }

            return
                DataProvider.ExecuteQuery("insert into {{TPH_Standard}}_System.dbo.cauhinh_hethong (MaCauHinh,Giatri,MayTinh) Values (N'" + keyWord +
                                          "','" + Utils.ConvertString(value) + "',N'" + Environment.MachineName + "')");
        }

        public DataTable Data_Config()
        {
            return DataProvider.ExecuteDataset(CommandType.Text, "Select * from {{TPH_Standard}}_System.dbo.CauHinh_ThietBi where MayTinh = N'AllComputer'").Tables[0];
        }

        public string DeviceType(string val)
        {
            switch (val)
            {
                case "1":
                    return "Thiết bị Capture";
                case "2":
                    return "Máy xét nghiệm";
                case "3":
                    return "Máy X-Quang";
                default:
                    return "";
            }
        }

        public DataTable Get_CauHinhCaptureSA(string computerName)
        {
            var strSql =
                "select b.*, m.TenMay  from {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi b left join {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm m on b.DeviceAlias = m.IDMay where ComputerName = N'" +
                computerName + "'  and DeviceType = 1";

            var dataTableCollection = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables;
            
            return dataTableCollection[0];
        }

        public DataTable Get_CauHinhCaptureSA(string computerName, string deviceName)
        {
            var strSql =
                "select b.*, m.TenMay  from {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi b left join {{TPH_Standard}}_Dictionary.dbo.DM_MaySieuAm m on b.DeviceAlias = m.IDMay where ComputerName = N'" +
                computerName.Trim() + "'  and DeviceType = 1 and DeviceName = N'" + deviceName.Trim() + "'";
            var dataTableCollection = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables;
            
            return dataTableCollection[0];
        }

        public void WriteReg(string name, string value)
        {
           CommonAppVarsAndFunctions.RegistryExt.WriteRegistry(name, value);
        }

        public string ReadReg(string name)
        {
            return CommonAppVarsAndFunctions.RegistryExt.ReadRegistry(name);
        }

        public DataTable Get_CauHinhCaptureNS(string computerName)
        {
            var strSql =
                "select b.*, m.TenMay  from {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi b left join {{TPH_Standard}}_Dictionary.dbo.DM_MayNoiSoi m on b.DeviceAlias = m.IDMay where ComputerName = N'" +
                computerName + "'  and DeviceType = 1";

            var dataTableCollection = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables;
            return dataTableCollection[0];
        }

        public DataTable Get_CauHinhCaptureNS(string computerName, string deviceName)
        {
            var strSql =
                "select b.*, m.TenMay  from {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi b left join {{TPH_Standard}}_Dictionary.dbo.DM_MayNoiSoi m on b.DeviceAlias = m.IDMay where ComputerName = N'" +
                computerName.Trim() + "'  and DeviceType = 1 and DeviceName = N'" + deviceName.Trim() + "'";

            var dataTableCollection = DataProvider.ExecuteDataset(CommandType.Text, strSql).Tables;
            return dataTableCollection[0];
        }

        public int Insert_Update_CauHinhCapture(string computerName, string deviceName, string videoStandard,
            string inputType, string framerate, string frameSize, string vCompressor, string alias,
            string maDicVuCls, bool _Default)
        {
            var strSql = "";
            if (CheckNotExit_Device(computerName, deviceName, "1"))
            {
                if (_Default)
                {
                    strSql = "Update {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi set SetDefault = 0 where ComputerName =N'" + computerName +
                             "' and DeviceType = 1";
                    DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                }
                strSql =
                    "insert into {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi (ComputerName, DeviceType, DeviceName, Para1, Para2,DeviceAlias,MaPhanLoai, SetDefault) \n";
                strSql += "select N'" + computerName + "' as ComputerName, cast (1 as int) as DeviceType,N'" +
                          deviceName + "' as DeviceName, N'" +
                          Utilities.ConvertSqlString(Set_StringPara(videoStandard, inputType, framerate, frameSize,
                              vCompressor)) + "' , NULL," + (alias == "" ? "NULL" : "'" + alias + "'") + "," +
                          (maDicVuCls == "" ? "0" : "'" + maDicVuCls + "'") + "," + (_Default == true ? "1" : "0");
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
                return 1;
            }

            if (_Default)
            {
                strSql = "Update {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi set SetDefault = 0 where ComputerName =N'" + computerName +
                         "' and DeviceType = 1";
                DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
            }
            strSql = "Update {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi set ComputerName = N'" + computerName + "', DeviceName = N'" +
                     deviceName + "', Para1 =  N'" +
                     Utilities.ConvertSqlString(Set_StringPara(videoStandard, inputType, framerate, frameSize,
                         vCompressor)) + "',Para2=Null, DeviceAlias = " + (alias == "" ? "NULL" : "'" + alias + "'") +
                     ", SetDefault = " + (_Default == true ? "1" : "0") + "\n";
            strSql += "where ComputerName =N'" + computerName + "' and DeviceType = 1 and DeviceName = N'" +
                      deviceName + "'";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);

            return 2;
        }

        private string Set_StringPara(string videoStandard, string inputType, string framerate, string frameSize,
            string vCompressor)
        {
            return videoStandard + ";" + inputType + ";" + framerate + ";" + frameSize.Replace(" x ", ";") + ";" +
                   vCompressor;
        }

        private bool CheckNotExit_Device(string computerName, string deviceName, string type)
        {
            var dtCheck =
                DataProvider.ExecuteDataset(CommandType.Text,
                    "Select * from {{TPH_Standard}}_Dictionary.dbo.CauHinh_ThietBi where ComputerName =N'" + computerName + "' and DeviceType = " + type +
                    " and DeviceName = N'" + deviceName + "'").Tables[0];
            return dtCheck.Rows.Count <= 0;
        }

        public void Check_AutoSetConfig_Capture(bool check)
        {
            DataProvider.ExecuteNonQuery(CommandType.Text,
                "update {{TPH_Standard}}_System.dbo.CauHinh_ThietBi set AutoConfigCapture = " + (check == true ? "1" : "0"));
        }

        public void Update_CauHinhTiepNhan(bool idTuDong)
        {
            var strSql = "update  {{TPH_Standard}}_System.dbo.CauHinh_ThietBi set AutoID = " + (idTuDong == true ? "1" : "0") + "\n";
            strSql += " where ID = 1";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Update_CauHinhXN(bool validPrintXn, bool autoCalculate, int autoCalculateTime, bool autoCalculateAll)
        {
            var strSql = "update  {{TPH_Standard}}_System.dbo.CauHinh_ThietBi set ValidPrintXN = " + (validPrintXn == true ? "1" : "0") + " \n" +
                             ", AutoCalculate = " + (autoCalculate == true ? "1" : "0") + "\n" +
                             ", AutoCalculateTime = " +
                             (autoCalculateTime.ToString() == "0" ? "10" : autoCalculateTime.ToString()) + "\n" +
                             ", AutoCalculateAll= " + (autoCalculateAll == true ? "1" : "0") + "\n";
            strSql += " where ID = 1";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Update_CauHinhSA(string capturePath, string videoPath)
        {
            var strSql = "update  {{TPH_Standard}}_System.dbo.CauHinh_ThietBi set CapturePath = N'" + Utilities.ConvertSqlString(capturePath) +
                             "', VideoStreamPath = N'" + Utilities.ConvertSqlString(videoPath) + "' \n";
            strSql += " where ID = 1";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Update_CauHinhNS(string capturePath, string videoPath, string connectPreview)
        {
            var strSql = "update  {{TPH_Standard}}_System.dbo.CauHinh_ThietBi set CapturePathNS = N'" + Utilities.ConvertSqlString(capturePath) +
                             "', VideoStreamPathNS = N'" + Utilities.ConvertSqlString(videoPath) +
                             "',PreviewCaptureNS='" + connectPreview + "' \n";
            strSql += " where ID = 1";
            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

        public void Update_CauHinhDienTim(string insPath, string resultPath, string resultImageSize)
        {
            var strSql = "update  {{TPH_Standard}}_System.dbo.CauHinh_ThietBi set ECGInsPath = N'" + Utilities.ConvertSqlString(insPath) +
                             "', ECGResultPath = N'" + Utilities.ConvertSqlString(resultPath) + "',ECGImageSize='" +
                             resultImageSize + "' \n";
            strSql += " where ID = 1";

            DataProvider.ExecuteNonQuery(CommandType.Text, strSql);
        }

    }
}
