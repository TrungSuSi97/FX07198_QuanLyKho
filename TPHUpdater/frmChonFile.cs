using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.LIS.Common.Controls;
using TPH.LIS.Configuration.Models;
using TPH.LIS.Configuration.Services.SystemConfig;
using TPH.UpdaterManagement.Contants;
using TPH.UpdaterManagement.Services;
using TPH.UpdaterManagement.Services.Impl;

namespace TPH.LabIMS.Updater
{
    public partial class frmChonFile : Form
    {
        private readonly IUpdaterService updateService = new UpdaterService();
        private ISystemConfigService _sysConfig = new SystemConfigService();
        private string CustomerId = string.Empty;
        public frmChonFile()
        {
            InitializeComponent();
        }
        DataTable dataSource;
        ConfigurationDetail objConfigurationDetail = new ConfigurationDetail();
        private void btnDuongDan_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();

            folderDlg.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog.

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                StartLoadFile(folderDlg.SelectedPath);
            }
        }
        private void txtDuongDan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtDuongDan.Text))
                {
                    StartLoadFile(txtDuongDan.Text);
                    e.Handled = true;
                }
            }
        }
        private void StartLoadFile(string targetDirectory)
        {
            txtDuongDan.Text = targetDirectory;

            dataSource = new DataTable();
            dataSource.Columns.Add("Chon", typeof(bool));
            dataSource.Columns.Add("TenFile", typeof(string));
            dataSource.Columns.Add("NgaySua", typeof(DateTime));
            dataSource.Columns.Add("NgayTao", typeof(DateTime));
            dataSource.Columns.Add("ThuMuc", typeof(string));
            dataSource.Columns.Add("DuongDan", typeof(string));

            ProcessDirectory(txtDuongDan.Text, dataSource);
            dataSource.DefaultView.Sort = "NgaySua DESC";
            dataSource = dataSource.DefaultView.ToTable();

            BindingSource bs = new BindingSource();
            bs.DataSource = dataSource;
            bvFileList.BindingSource = bs;
            dtgFileList.DataSource = bs;
            chkCheckAll.Checked = false;
        }
        private void ProcessDirectory(string targetDirectory, DataTable dataFileList)
        {
            DataRow dr = dataFileList.NewRow();
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                var fi = new FileInfo(fileName);
                if (!txtNotLoad.Text.Contains( fi.Extension))
                {
                    dr = dataFileList.NewRow();
                    dr["NgaySua"] = File.GetCreationTimeUtc(fileName).AddHours(7); ;
                    dr["NgayTao"] = File.GetLastWriteTimeUtc(fileName).AddHours(7); ;
                    dr["TenFile"] = string.Format("{0}", fi.Name);
                    dr["ThuMuc"] = targetDirectory.Replace(txtDuongDan.Text, ActionFileWithDatabase.rootName);
                    dr["Chon"] = false;
                    dr["DuongDan"] = fileName;
                    dataFileList.Rows.Add(dr);
                }
            }
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, dataFileList);
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgFileList.RowCount; i++)
            {
                dtgFileList[colChon.Index, i].Value = chkCheckAll.Checked;
            }
        }
        private string CreateZipFile(string directory)
        {
            string zipPath = string.Format("{0}TPHFileUpdate_{1}.zip", Path.GetTempPath(), ActionFileWithDatabase.AppName.Replace(".", ""));
            //  string extractPath = @"c:\example\extract";
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            ZipFile.CreateFromDirectory(directory, zipPath);
            //  ZipFile.ExtractToDirectory(zipPath, extractPath);
            Directory.Delete(directory, true);
            return zipPath;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuongDan.Text) && dtgFileList.RowCount > 0)
            {
                if (CustomMessageBox.MSG_Question_YesNo_GetYes("Thực hiện upload các file đã chọn vào danh sách cập nhật ?"))
                {
                    txtDuongDan.Focus();
               
                    ActionFileWithDatabase.DeleteAllFileput();
                    var havechecked = 0;
                    var pdthDicrectoryTemp = string.Format("{0}TPHUpdateFile_{1}", Path.GetTempPath(), ActionFileWithDatabase.AppName.Replace(".",""));
                    Directory.CreateDirectory(pdthDicrectoryTemp);
                    ActionFileWithDatabase.DeleteAllFileInfolder(pdthDicrectoryTemp);
                    bvFileList.BindingSource.MoveFirst();
                    for (int i = 0; i < dtgFileList.RowCount; i++)
                    {
                        if ((bool)dtgFileList[colChon.Index, i].Value)
                        {
                            havechecked++;
                            string varFilePath = dtgFileList[colDuongDan.Name, i].Value.ToString();
                            var fi = new FileInfo(varFilePath);

                            ActionFileWithDatabase.databaseFilePut(
                                dtgFileList[colTenFile.Name, i].Value.ToString()
                                , dtgFileList[colThuMuc.Name, i].Value.ToString()
                                , fi.LastWriteTime, fi.CreationTime, Environment.MachineName
                                , "admin", varFilePath, FileVersionInfo.GetVersionInfo(varFilePath).FileVersion);
                            dtgFileList[colChon.Index, i].Value = false;

                            File.Copy(varFilePath, string.Format("{0}\\{1}", pdthDicrectoryTemp, dtgFileList[colTenFile.Name, i].Value.ToString()));
                        }
                        bvFileList.BindingSource.MoveNext();
                    }
                    CustomMessageBox.ShowAlert("Đang xử lý đóng gói bản cập nhật.");
                    var zileFile = CreateZipFile(pdthDicrectoryTemp);
                    var zipFileList = ActionFileWithDatabase.SplitFile(zileFile, 250);
                    foreach (var item in zipFileList)
                    {
                        string baseFileName = Path.GetFileName(item);
                        ActionFileWithDatabase.Insert_FileContent(baseFileName, item);
                        File.Delete(item);
                    }
                    File.Delete(zileFile);
                    CustomMessageBox.CloseAlert();
                    if (havechecked > 0)
                    {
                        if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận bản cập nhật ?"))
                        {
                            ActionFileWithDatabase.Update_NewUpdate_Date();
                        }
                    }
                    else
                        CustomMessageBox.MSG_Information_OK("Không có file nào được chọn!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDownloadUpdate f = new FrmDownloadUpdate();
            f.ShowDialog();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.MSG_Question_YesNo_GetYes("Xác nhận bản cập nhật ?"))
            {
                ActionFileWithDatabase.Update_NewUpdate_Date();
            }
        }
        private void frmChonFile_Load(object sender, EventArgs e)
        {
            objConfigurationDetail = _sysConfig.GetSystemConfigurationDetail(string.Empty);
            CustomerId = objConfigurationDetail.CustomerID;
            if (!string.IsNullOrEmpty(objConfigurationDetail.SignalR_HostName))
            {
                updateService.CreateServiceConnect(new UpdaterManagement.Models.UpdateServiceHostInfo
                {
                    HostName = objConfigurationDetail.SignalR_HostName,
                    Port = objConfigurationDetail.SignalR_Port,
                    UserName = Environment.MachineName,
                    HubName = UpdaterManagementCommon.HubIMS
                });
            }
            label1.Text = string.Format(label1.Text, ActionFileWithDatabase.AppName);
            SetLowerCaseForXGridColumns(gvDSMayXN);
            Load_DanHSachMayTinh();
            
          
        }
        private void SetLowerCaseForXGridColumns(GridView gv)
        {
            foreach (GridColumn item in gv.Columns)
            {
                item.FieldName = item.FieldName.ToLower();
            }
            foreach (GridColumn item in gv.GroupedColumns)
            {
                item.FieldName = item.FieldName.ToLower();
            }
        }
        private void Load_DanHSachMayTinh()
        {
            var dataTaCaMayTinh = ActionFileWithDatabase.DataDanhSachMayTinh(string.Empty);
            gcDanhSach.DataSource = SetColumnLower(dataTaCaMayTinh);
            gvDSMayXN.ExpandAllGroups();
        }
        private DataTable SetColumnLower(DataTable data)
        {
            for (int i = 0; i < data.Columns.Count; i++)
            {
               var colName = data.Columns[i].ColumnName.Trim();
                data.Columns[i].ColumnName = colName.ToLower();
            }
            return data;
        }
        private void Check_SetColorForISRequesting()
        {
           
        }
        private void AddMayTinhTheoKhuVuc(DataTable dataMayTinh, string TenKhuVuc)
        {
            var masterPanel = new Panel();
           
            Label lblKhuVuc = new Label();
            lblKhuVuc.Text = string.Format("[+] KHU VỰC: {0}", TenKhuVuc.ToUpper().Trim());
            masterPanel.Controls.Add(lblKhuVuc);
            lblKhuVuc.AutoSize = false;
            lblKhuVuc.Dock = DockStyle.Top;
            lblKhuVuc.Height = 30;
            lblKhuVuc.Font = new Font(lblKhuVuc.Font.FontFamily, 14, FontStyle.Bold);
            lblKhuVuc.BackColor = Color.LightGray;

            FlowLayoutPanel pnKhuVuc = new FlowLayoutPanel();
            pnKhuVuc.AutoScroll = true;
            pnKhuVuc.FlowDirection = FlowDirection.LeftToRight;
            int count = 0;
            foreach (DataRow drMayTinh in dataMayTinh.Rows)
            {
                count++;
                var uc = new ucComputerClient();
                uc.lblversion.Text = drMayTinh["versionID"].ToString();
                uc.txtThoiGianTruyCap.Text = string.IsNullOrEmpty(drMayTinh["ThoiGianLogInGanNhat"].ToString()) ? "" : string.Format("{0: HH:mm:ss dd/MM/yyyy}", DateTime.Parse(drMayTinh["ThoiGianLogInGanNhat"].ToString()));
                uc.txtTenMayTinh.Text = drMayTinh["TenMayTinh"].ToString();
                uc.isHuyYeuCau = bool.Parse(drMayTinh["YeuCauCapNhat"].ToString());
                if ((count % 2) > 0)
                {
                    uc.BackColor = Color.LightBlue;
                }
                pnKhuVuc.Controls.Add(uc);
            }
            masterPanel.Controls.Add(pnKhuVuc);
            pnKhuVuc.Dock = DockStyle.Fill;
            pnKhuVuc.BringToFront();
            pnDanhSachMayTinh.Controls.Add(masterPanel);
            masterPanel.Dock = DockStyle.Top;
            masterPanel.Height = tabMayTinh.Height - 15;
            masterPanel.BringToFront();
        }

        private void btnLamMoiDanhSach_Click(object sender, EventArgs e)
        {
            Load_DanHSachMayTinh(); 
        }

        private void gvDSMayXN_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    var priority = (bool) View.GetRowCellValue(e.RowHandle, colDangYeuCau);
            //    if (priority)
            //    {
            //        e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
            //        e.Appearance.BackColor2 = Color.White;
            //    }
            //}
        }

        private void gvDSMayXN_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var priority = (bool)View.GetRowCellValue(e.RowHandle, colDangYeuCau);
                if (priority)
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
                    e.Appearance.BackColor2 = Color.White;
                }
            }
        }

        private void btnViewInfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
          
        }

        private void btnRequestUpdate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var isHuyYeuCau = (bool)gvDSMayXN.GetRowCellValue(gvDSMayXN.FocusedRowHandle, colDangYeuCau);
            if (isHuyYeuCau)
            {
              
                if (MessageBox.Show(string.Format("Hủy yêu cầu cập nhật cho máy tính: {0}", gvDSMayXN.GetRowCellValue(gvDSMayXN.FocusedRowHandle, colTenMayTinh).ToString()), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ActionFileWithDatabase.Update_ForceUpdate(gvDSMayXN.GetRowCellValue(gvDSMayXN.FocusedRowHandle, colTenMayTinh).ToString(), false);
                    isHuyYeuCau = false;
                }
            }
            else
            {
                if (MessageBox.Show(string.Format("Yêu cầu cập nhật cho máy tính: {0}", gvDSMayXN.GetRowCellValue(gvDSMayXN.FocusedRowHandle, colTenMayTinh).ToString()), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ActionFileWithDatabase.Update_ForceUpdate(gvDSMayXN.GetRowCellValue(gvDSMayXN.FocusedRowHandle, colTenMayTinh).ToString(), true);
                    isHuyYeuCau = true;
                }
            }
            gvDSMayXN.SetRowCellValue(gvDSMayXN.FocusedRowHandle, colDangYeuCau, isHuyYeuCau); 
        }

        private void btnViewFileInfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var data = ActionFileWithDatabase.DataKhuVucMayTinh(gvDSMayXN.GetRowCellValue(gvDSMayXN.FocusedRowHandle, colTenMayTinh).ToString());
            if (data.Rows.Count > 0)
            {
                var xmlString = data.Rows[0]["FileInfo"].ToString();
                if (!string.IsNullOrEmpty(xmlString))
                {
                    StringReader theReader = new StringReader(xmlString);
                    DataSet theDataSet = new DataSet();
                    theDataSet.ReadXml(theReader);
                    var f = new FrmDetailFileInPc();
                    f.dtgChiTietFile.AutoGenerateColumns = true;
                    f.dtgChiTietFile.DataSource = theDataSet.Tables[0];
                    f.dtgChiTietFile.AutoResizeColumns();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có thông tin file!");
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin file!");
            }
        }
        bool isJoinedGroup = false;
        private async void JoinUpdateGroup()
        {
            if (!isJoinedGroup)
            {
                if (updateService.IsReady())
                {
                  await  updateService.JoinGroup(UpdaterManagementCommon.UpdaterGroupName);
                    isJoinedGroup = true;
                }
                //else
                //{
                //    if (!string.IsNullOrEmpty(objConfigurationDetail.SignalR_HostName))
                //    {
                //         updateService.CreateServiceConnect(new UpdaterManagement.Models.UpdateServiceHostInfo
                //        {
                //            HostName = objConfigurationDetail.SignalR_HostName,
                //            Port = objConfigurationDetail.SignalR_Port,
                //            UserName = Environment.MachineName,
                //            HubName = UpdaterManagementCommon.HubIMS
                //        });
                //    }

                //    if (updateService.IsReady())
                //    {
                //        await updateService.JoinGroup(UpdaterManagementCommon.UpdaterGroupName);
                //        isJoinedGroup = true;
                //    }
                //}
            }
        }
        private void btnYeuCauCacMayChon_Click(object sender, EventArgs e)
        {
            if (gvDSMayXN.SelectedRowsCount > 0)
            {
               JoinUpdateGroup();
                foreach (int i in gvDSMayXN.GetSelectedRows())
                {
                    if (gvDSMayXN.GetRowCellValue(i, colTenMayTinh) != null)
                    {
                        ActionFileWithDatabase.Update_ForceUpdate(gvDSMayXN.GetRowCellValue(i, colTenMayTinh).ToString(), true);
                        gvDSMayXN.SetRowCellValue(i, colDangYeuCau, true);
                        if (updateService.IsReady())
                        {
                            var computername = gvDSMayXN.GetRowCellValue(i, colTenMayTinh).ToString();
                            var mess = UpdaterManagementCommon.GetMessageUpdateStruct(UpdaterManagementCommon.LabIMS, CustomerId, computername);
                            updateService.SendMessage(mess, UpdaterManagementCommon.UpdaterGroupName);
                        }
                    }
                }
            }
        }

        private void btnBoYeuCauCapNhat_Click(object sender, EventArgs e)
        {
            if (gvDSMayXN.SelectedRowsCount > 0)
            {
                JoinUpdateGroup();
                foreach (int i in gvDSMayXN.GetSelectedRows())
                {
                    if (gvDSMayXN.GetRowCellValue(i, colTenMayTinh) != null)
                    {
                        ActionFileWithDatabase.Update_ForceUpdate(gvDSMayXN.GetRowCellValue(i, colTenMayTinh).ToString(), false);
                        gvDSMayXN.SetRowCellValue(i, colDangYeuCau, false);
                        if (updateService.IsReady())
                        {
                            var computername = gvDSMayXN.GetRowCellValue(i, colTenMayTinh).ToString();
                            var mess = UpdaterManagementCommon.GetMessageCancelUpdateStruct(UpdaterManagementCommon.LabIMS, CustomerId, computername);
                            updateService.SendMessage(mess, UpdaterManagementCommon.UpdaterGroupName);
                        }
                    }
                }
            }
        }

        private void tabMayTinh_Enter(object sender, EventArgs e)
        {
           
        }

        private void frmChonFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateService.CloseConnect();
        }
    }
}
