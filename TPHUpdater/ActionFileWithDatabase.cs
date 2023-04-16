using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using TPH.Data.Configuration;
using TPH.LIS.Data;
using System.IO.Compression;

namespace TPH.LabIMS.Updater
{
    public class ActionFileWithDatabase
    {
        public const string rootName = "{root}";
        public const string updateFolder = "TPHUpdate";
        public const string downloadFolder = "Downloaded";
        public const string downloadZipFolder = "ZipDownloaded";
        public const string backupFolder = "Backup";
        public static string AppName = "KXD";
        public static int databaseFilePut(string fileName, string directory, DateTime creattiondate
            , DateTime modifieddate, string pcconfirm, string userconfirm, string varFilePath, string fileversion)
        {
            byte[] file;
            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            if (fileversion != null)
            {
                var splitVersion = fileversion.Split('.');
                if (splitVersion.Length == 4)
                {
                    fileversion = string.Format("{0}.{1:00}.{2:00}.{3}", splitVersion[0], int.Parse(splitVersion[1]), int.Parse(splitVersion[2]), splitVersion[3]);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem (fileName, directory, creattiondate, dateconfirm, pcconfirm, userconfirm,modifieddate,FileVersion,PhanHe)");
            sb.AppendFormat("\nselect N'{0}' as fileName, N'{1}' as directory,'{2}' as creattiondate, getdate(), N'{3}' as pcconfirm, '{4}' as userconfirm, '{5}' as modifieddate, {6} as FileVersion, '{7}' as PhanHe"
                , fileName, directory, creattiondate.ToString("yyyy-MM-dd HH:mm:ss"), pcconfirm, userconfirm
                , modifieddate.ToString("yyyy-MM-dd HH:mm:ss")
                , (fileversion == null ? "0" : fileversion.Replace(".", ""))
                , AppName);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString(), null);
        }
        public static int Insert_FileContent(string fileName, string filepath)
        {
            byte[] file;
            using (var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem_noidungfile (fileName,phanhe,filecontent)");
            sb.AppendFormat("\nselect N'{0}' as fileName, '{1}' as PhanHe,@FileContent", fileName, AppName);
            var paraFile = new SqlParameter("@FileContent", file);
            paraFile.SqlDbType = SqlDbType.VarBinary;
            SqlParameter[] para = new SqlParameter[] { paraFile };
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString(), paraFile);
        }
        public static int DeleteAllFileput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Delete {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem where PhanHe = '{0}';Delete {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem_noidungfile where PhanHe = '{0}' ", AppName);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }

        public static bool CheckFolder(string folderName)
        {
            return Directory.Exists(folderName);
        }
        public static int DownloadUpdate(string updateTimeString, Label lblFolderStatus, Label lblFileStatus)
        {
            lblFileStatus.Text = string.Empty;
            lblFolderStatus.Text = "Kiểm tra các thư mục update";
            string updateRoot = string.Format(@"{0}\{1}", Environment.CurrentDirectory, updateFolder);
            string updatePrepare = string.Format(@"{0}\{1}", updateRoot, downloadFolder);
            string updateBackup = string.Format(@"{0}\{1}", updateRoot, backupFolder);
            string downloadZip = string.Format("{0}TPHUpdateZipFile_{1}", Path.GetTempPath(), ActionFileWithDatabase.AppName.Replace(".", ""));
            if (!CheckFolder(updateRoot))
                Directory.CreateDirectory(updateRoot);
            if (!CheckFolder(updatePrepare))
                Directory.CreateDirectory(updatePrepare);
            if (!CheckFolder(updateBackup))
                Directory.CreateDirectory(updateBackup);
            if (!CheckFolder(downloadZip))
                Directory.CreateDirectory(downloadZip);
            
            DeleteAllFileInfolder(updatePrepare);
            DeleteAllFileInfolder(downloadZip);
            // Đọc nội dung file 
            var data = DataProvider.ExecuteDataset(CommandType.Text, string.Format("select fileName from {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem_noidungfile where PhanHe = '{0}'", AppName)).Tables[0]; ;
            if (data.Rows.Count > 0)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    var fileName = dataRow["fileName"].ToString();
                    StringBuilder sbFile = new StringBuilder();
                    sbFile.Append("select filecontent from {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem_noidungfile");
                    sbFile.AppendFormat("\n where fileName = N'{0}'", fileName);
                    sbFile.AppendFormat("\n and PhanHe = N'{0}'", AppName);
                    using (SqlDataReader reader = DataProvider.ExecuteReader(CommandType.Text, sbFile.ToString()))
                    {
                        while (reader.Read())
                        {
                            var blob = new Byte[(reader.GetBytes(0, 0, null, 0, int.MaxValue))];
                            reader.GetBytes(0, 0, blob, 0, blob.Length);
                            using (var fs = new FileStream(string.Format("{0}\\{1}", downloadZip, fileName), FileMode.Create, FileAccess.Write)) fs.Write(blob, 0, blob.Length);
                        }
                    }
                }
                lblFolderStatus.Text = "Xử lý update - ghép file";
                //Xử lý mergeFile 
                MergeFile(downloadZip);
                //Lấy tên file zip
                var files = Directory.GetFiles(downloadZip);
                var fullFilePath = files[0];
                //Giải nén tất cả các file.
                lblFolderStatus.Text = "Xử lý update - giải nén";
                ZipFile.ExtractToDirectory(fullFilePath, downloadZip);
                File.Delete(fullFilePath);
                //Lấy lại các file trong temp
                files = Directory.GetFiles(downloadZip);
                //Lấy danh sách tên file và thông tin file
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select fileName, directory, creattiondate,modifieddate from {{TPH_Standard}}_System.dbo.hethong_capnhatphanmem where PhanHe = '{0}'", AppName);
                DataTable dataList = DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
                if (dataList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dataList.Rows)
                    {
                        lblFolderStatus.Text = dr["directory"].ToString();
                        lblFileStatus.Text = dr["fileName"].ToString();
                        lblFolderStatus.Refresh();
                        lblFileStatus.Refresh();
                        var fileName = dr["fileName"].ToString();

                        CopyFileFromTempToUpdateFolder(string.Format("{0}\\{1}", downloadZip, fileName), fileName
                            , dr["directory"].ToString(), updateTimeString, DateTime.Parse(dr["creattiondate"].ToString())
                            , DateTime.Parse(dr["modifieddate"].ToString()));
                    }
                    Directory.Delete(downloadZip, true);
                    return dataList.Rows.Count;
                }
                else
                    return -1;
            }
            else
                return -1;
        }
        public static void Update_FinishUpdate()
        {
            SqlParameter[] para = new SqlParameter[]
          {
                    new SqlParameter("@pcName", Environment.MachineName),
                     new SqlParameter("@AppName",AppName)
          };
            if ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insPcUpdateSoftware", para) > 0)
            {
                Update_ForceUpdate(Environment.MachineName, false);
            }
        }
        public static int Update_NewUpdate_Date()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update {{TPH_Standard}}_System.dbo.cauhinh_hethong set GiaTri = getdate() where MaCauHinh = 'System_LastestUpdateDate_{0}'", AppName);
            return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());

        }
        public static int Update_ForceUpdate(string pcName, bool isRequested)
        {
            SqlParameter[] para = new SqlParameter[]
             {
                    new SqlParameter("@pcName",pcName),
                     new SqlParameter("@AppName",AppName),
                     new SqlParameter("@UpdateFinish",false)
             };
            if ((int)DataProvider.ExecuteNonQuery(CommandType.StoredProcedure, "insPcUpdateSoftware", para) > -2)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("update {{TPH_Standard}}_System.dbo.hethong_quanlycapnhat set YeuCauCapNhat = {0}", isRequested ? "1" : "0");
                if (!string.IsNullOrEmpty(pcName))
                    sb.AppendFormat("\n where pcname = N'{0}' and PhanHe = '{1}'", pcName, AppName);
                return (int)DataProvider.ExecuteNonQuery(CommandType.Text, sb.ToString());
            }
            return 0;
        }
        public static DataTable DataDanhSachMayTinh(string pcName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Select m.*, k.TenKhuVuc,cast(isnull(cn.YeuCauCapNhat,0) as bit) as CancapNhat,cn.VersiondangDung  from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH m inner join {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC k on k.MaKhuVuc = m.MaKhuVuc left join {{TPH_Standard}}_System.dbo.hethong_quanlycapnhat cn on cn.PcName = m.TenMayTinh and  cn.PhanHe = '{0}' ", AppName);
            if (!string.IsNullOrEmpty(pcName))
                sb.AppendFormat("\n where m.TenMayTinh = N'{0}'", pcName);
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }

        public static void DeleteAllFileInfolder(string folderCheck)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(folderCheck);
            foreach (string fileName in fileEntries)
            {
                File.Delete(fileName);
            }
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(folderCheck);
            foreach (string subdirectory in subdirectoryEntries)
                DeleteAllFileInfolder(subdirectory);
        }
        public static DataTable DataKhuVucMayTinh(string pcName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Select * from {{TPH_Standard}}_Dictionary.dbo.DM_KHUVUC_MAYTINH where TenMayTinh = N'{0}'", pcName);
            return DataProvider.ExecuteDataset(CommandType.Text, sb.ToString()).Tables[0];
        }

        public static void CopyFileFromTempToUpdateFolder(string sourceFile, string fileName, string folderPath, string updateTimeString, DateTime createTime, DateTime modifieddate)
        {
            string newLocationFolder = string.Format(@"{0}\{1}\{2}{3}", Environment.CurrentDirectory, updateFolder, downloadFolder, folderPath.Replace(rootName, ""));
            if (!CheckFolder(newLocationFolder))
                Directory.CreateDirectory(newLocationFolder);
            string newLocationFile = string.Format(@"{0}\{1}", newLocationFolder, fileName);

            string newLocationBackupFolder = string.Format(@"{0}\{1}\{2}\{3}{4}", Environment.CurrentDirectory, updateFolder, backupFolder, updateTimeString, folderPath.Replace(rootName, ""));

            string runningFile = string.Format(@"{0}{1}\{2}", Environment.CurrentDirectory, folderPath.Replace(rootName, ""), fileName);
            string backupFile = string.Format(@"{0}\{1}", newLocationBackupFolder, fileName);
            //Backup file current
            if (File.Exists(runningFile))
            {
                if (!CheckFolder(newLocationBackupFolder))
                    Directory.CreateDirectory(newLocationBackupFolder);
                File.Copy(runningFile, backupFile);
            }
            //Copy from temp
            File.Copy(sourceFile, newLocationFile);
            File.SetCreationTime(newLocationFile, modifieddate);
            File.SetLastWriteTime(newLocationFile, createTime);
        }
        public static List<string> SplitFile(string inputFile, int numberOfFiles)
        {
            FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            int sizeOfEachFile = (int)Math.Ceiling((double)fs.Length / numberOfFiles);
            var returnList = new List<string>();    
            for (int i = 1; i <= numberOfFiles; i++)
            {
                string baseFileName = Path.GetFileNameWithoutExtension(inputFile);
                string extension = Path.GetExtension(inputFile);
                var fileSplitpath = Path.GetDirectoryName(inputFile) + "\\" + baseFileName + "." + i.ToString().PadLeft(5, Convert.ToChar("0")) + extension + ".tmp";
                if (File.Exists(fileSplitpath))
                    File.Delete(fileSplitpath);
                FileStream outputFile = new FileStream(fileSplitpath, FileMode.Create, FileAccess.Write);
                int bytesRead = 0;
                byte[] buffer = new byte[sizeOfEachFile];

                if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
                {
                    outputFile.Write(buffer, 0, bytesRead);
                }
                returnList.Add(fileSplitpath);
                outputFile.Close();
            }
            fs.Close();
            return returnList;
        }
        public static void MergeFile(string outPath)
        {
            string[] tmpFiles = Directory.GetFiles(outPath, "*.tmp");
            FileStream outputFile = null;
            string prevFileName = "";
            foreach (string tempFile in tmpFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(tempFile);
                string baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                string extension = Path.GetExtension(fileName);

                if (!prevFileName.Equals(baseFileName))
                {
                    var outPutpath = outPath + "\\" + baseFileName + extension;
                    if(File.Exists(outPutpath))
                        File.Delete(outPutpath);
                    if (outputFile != null)
                    {
                        outputFile.Flush();
                        outputFile.Close();
                    }
                    outputFile = new FileStream(outPutpath, FileMode.OpenOrCreate, FileAccess.Write);
                }

                int bytesRead = 0;
                byte[] buffer = new byte[1024];
                FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);

                while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                    outputFile.Write(buffer, 0, bytesRead);

                inputTempFile.Close();
                File.Delete(tempFile);
                prevFileName = baseFileName;
            }
            outputFile.Close();
        }
    }
}


