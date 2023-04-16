using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH.UpdaterManagement.Contants
{
    public class UpdaterManagementCommon
    {
        public const string HubUpdater = "UpdaterHub";
        public const string HubIMS = "IMSHub";
        public const string HubInterface = "InterfaceHub";
        public const string UpdateCommand = "Update";
        public const string CancelUpdateCommand = "CancelUpdateCommand";
        public const string ReceivedUpdate = "ReceivedUpdate";
        public const string CheckWorkingCode = "CheckWorkingCode";
        public const string RespneWorkingCode = "RespneWorkingCode";
        public const string AllPC = "AllPC";
        public const string LabIMS = "TPH.LabIMS";
        public const string LabIQC = "TPH.LabIMS.IQC";
        public const string LabBlood = "TPH.LabBlood";
        public const string FBlood = "TPH.FBlood";
        public const string CIS = "TPH.CIS";
        public const string SegmentChar = "^";
        public const string UpdaterGroupName = "Updater";
        public const string TestResultNormalGroupName = "TestResultNormalAsk";
        public const string TestResultNormalResponeGroupName = "TestResultNormalRespone";
        public static string GetMessageUpdateStruct(string AppName, string customerID, string pcName = AllPC)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}", SegmentChar, pcName, UpdateCommand, customerID, AppName);
        }
        public static string GetMessageCancelUpdateStruct(string AppName, string customerID, string pcName = AllPC)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}", SegmentChar, pcName, CancelUpdateCommand, customerID, AppName);
        }
        public static bool CheckIsMessageUpdate(string inputMess, string appName, string pcName, string customerID)
        {
            if (!string.IsNullOrEmpty(inputMess))
            {
                var arrSplit = inputMess.Split(new string[] { SegmentChar }, StringSplitOptions.RemoveEmptyEntries);
                if (arrSplit.Length >= 3)
                {
                    return ((arrSplit[0].Equals(AllPC) || arrSplit[0].Equals(pcName)) && arrSplit[1].Equals(UpdateCommand) && arrSplit[2].Equals(customerID) && arrSplit[3].Equals(appName));
                }
            }
            return false;
        }
        public static bool CheckIsMessageCancelUpdate(string inputMess, string appName, string pcName, string customerID)
        {
            if (!string.IsNullOrEmpty(inputMess))
            {
                var arrSplit = inputMess.Split(new string[] { SegmentChar }, StringSplitOptions.RemoveEmptyEntries);
                if (arrSplit.Length >= 3)
                {
                    return ((arrSplit[0].Equals(AllPC) || arrSplit[0].Equals(pcName)) && arrSplit[1].Equals(CancelUpdateCommand) && arrSplit[2].Equals(customerID) && arrSplit[3].Equals(appName));
                }
            }
            return false;
        }
        public static string GetMessageRecievedUpdateCommand(string AppName, string customerID, string pcName)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}", SegmentChar, pcName, ReceivedUpdate, customerID, AppName);
        }
        public static void GetMessageRecievedUpdateInfo(string inputMess, out string PcName, out string Appname)
        {
            PcName = string.Empty;
            Appname = string.Empty;
            if (!string.IsNullOrEmpty(inputMess))
            {
                var arrSplit = inputMess.Split(new string[] { SegmentChar }, StringSplitOptions.RemoveEmptyEntries);
                if (arrSplit.Length >= 3)
                {
                    if (arrSplit[1].Equals(ReceivedUpdate))
                    {
                        PcName = arrSplit[0];
                        Appname = arrSplit[3];
                    }
                }
            }
        }

        #region Check test showing
        public static string GetAskWorkingString(string MaTiepNhan, List<string> lstNhomDangXem, string pcName)
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}", SegmentChar, CheckWorkingCode, MaTiepNhan, string.Join(",", lstNhomDangXem), pcName);
        }
        public static string GetResponeWorkingString(string inputMess, Dictionary<string, List<string>> currentListWorking, string pcName, string userId)
        {
            if (!string.IsNullOrEmpty(inputMess))
            {
                var arrSplit = inputMess.Split(new string[] { SegmentChar }, StringSplitOptions.RemoveEmptyEntries);
                if (arrSplit.Length >= 2)
                {
                    if (arrSplit[0].Equals(CheckWorkingCode))
                    {
                        var matiepNhan = arrSplit[1];
                        var lstmessage = arrSplit[2].Split(',').ToList();
                        var PCAskName = arrSplit[3];
                        //if (!PCAskName.Equals(pcName))
                        //{
                            if (currentListWorking.Where(x => (x.Key ?? String.Empty).ToString().Equals(matiepNhan)).Any())
                            {
                                var lstDangXem = currentListWorking[matiepNhan];
                                if (lstDangXem.Intersect(lstmessage).Any())
                                    return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", SegmentChar, RespneWorkingCode, matiepNhan, string.Join(",", lstDangXem), pcName, PCAskName, userId);
                            }
                        //}
                    }
                }
            }
            return string.Empty;
        }
        public static string GetPCWorkingWithCode(string inputMess, string pcName,ref string matiepNhan)
        {
            if (!string.IsNullOrEmpty(inputMess))
            {
                var arrSplit = inputMess.Split(new string[] { SegmentChar }, StringSplitOptions.RemoveEmptyEntries);
                if (arrSplit.Length >= 4)
                {
                    if (arrSplit[0].Equals(RespneWorkingCode))
                    {
                        matiepNhan = arrSplit[1];
                      //  var lstmessage = arrSplit[3].Split(',').ToList();
                        var PCRespone = arrSplit[3];
                        var PCAsk = arrSplit[4];
                        var UserWorking = arrSplit[5];
                        if (PCAsk.Equals(pcName) && !PCRespone.Equals(pcName))
                            return string.Format("Mã tiếp nhận: {0}\r\nđang được xử lý trên máy {1}\r\nbởi tài khoản {2}", matiepNhan, PCRespone.ToUpper(), UserWorking.ToUpper());
                    }
                }
            }
            return string.Empty;
        }
        //public static bool CheckAskString(string inputMess, Dictionary<string, List<string>> currentListWorking )
        //{
        //    if (!string.IsNullOrEmpty(inputMess))
        //    {
        //        var arrSplit = inputMess.Split(new string[] { SegmentChar }, StringSplitOptions.RemoveEmptyEntries);
        //        if (arrSplit.Length >= 2)
        //        {
        //            if (arrSplit[0].Equals(CheckWorkingCode))
        //            {
        //                var matiepNhan = arrSplit[2];
        //                var lstmessage = arrSplit[3].Split(',').ToList();
        //                if (currentListWorking.Where(x => (x.Key??String.Empty).ToString().Equals(matiepNhan)).Any())
        //                {
        //                    var lstDangXem = currentListWorking[matiepNhan];
        //                    if (lstDangXem.Intersect(lstmessage).Any())
        //                        return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
        #endregion
    }
}
