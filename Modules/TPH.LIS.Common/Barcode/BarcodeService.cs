namespace TPH.LIS.Common.Barcode
{
    using System;
    using App.Configurations;

    public class BarcodeService
    {
        private static BarTender.ApplicationClass btApp;
        private static BarTender.Format btFormat;
        private static BarTender.Messages btMsgs;
        public static void Print(BarcodeProperties info)
        {
            btApp = new BarTender.ApplicationClass();

            string fileparth = string.Empty;
            if (info.KSKMode)
            {
                //TPH.Lab.Barcode.btw
                fileparth = System.IO.Path.GetFullPath(@"Barcode\TPH.Lab.BarcodeKSK.btw");
                btFormat = btApp.Formats.Open(fileparth, false, "");
                btFormat.SetNamedSubStringValue("Barcode", info.BarcodeNumber);
                btFormat.SetNamedSubStringValue("BarcodeLable", info.BarcodeLabel);
            }
            else
            {
                fileparth = System.IO.Path.GetFullPath(string.Format(@"Barcode\{0}", AppSettings.BarcodeName));
                btFormat = btApp.Formats.Open(fileparth, false, "");
                btFormat.SetNamedSubStringValue("Barcode", info.BarcodeNumber);
                btFormat.SetNamedSubStringValue("NameLable", info.PatientName);
                btFormat.SetNamedSubStringValue("BarcodeLable", info.BarcodeLabel);
                btFormat.SetNamedSubStringValue("Date", info.DateIn.ToString("dd/MM/yy"));
                //btFormat.SetNamedSubStringValue("DepartmentID", info.DepartmentID ?? "");
                // btFormat.SetNamedSubStringValue("SoTT", info.SoTT);
                if (info.Sex.Equals("nữ", StringComparison.OrdinalIgnoreCase))
                    info.Sex = "F";
                else if (info.Sex.Equals("nam", StringComparison.OrdinalIgnoreCase))
                    info.Sex = "M";
                else if (info.Sex.Equals("?"))
                    info.Sex = "";
                var age = string.Empty;

                if (!string.IsNullOrEmpty(info.Sex))
                    age = string.Format("{0}.{1}", info.Sex, info.Age);
                btFormat.SetNamedSubStringValue("Age", age);
            }

            btFormat.PrintSetup.IdenticalCopiesOfLabel = info.NumberOfCopy;
            btFormat.PrintOut(true, false);

            //btFormat.Print("Barcode", true, -1, out btMsgs);
            //btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);

            btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(btApp);

        }
    }
}
