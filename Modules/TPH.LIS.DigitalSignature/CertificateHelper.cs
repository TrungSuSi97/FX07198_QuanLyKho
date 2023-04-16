using DevExpress.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using DevExpress.Office.DigitalSignatures;
using iTextSharp.text;
using TPH.LIS.Common.Extensions;
using System.Runtime.ConstrainedExecution;
using TPH.LIS.Common.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.DigitalSignature
{
    public class CertificateHelper
    {
        public static Dictionary<X509Certificate, Pkcs7Signer> dicSignInfo = new Dictionary<X509Certificate, Pkcs7Signer>();
        public static X509Certificate2 GetCertificate()
        {
            // Get a certificate from a Windows Store
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            // Display a dialog box to select a certificate from the Windows Store
            X509Certificate2Collection selectedCertificates =
                    X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, X509SelectionFlag.SingleSelection);

            // Get the first certificate that has a primary key
            foreach (var certificate in selectedCertificates)
            {
                if (certificate.HasPrivateKey)
                    return certificate;
            }

            return null;
        }
        public static MemoryStream SignPDF(X509Certificate2 cert
            , string pdfinputPath, string signName
            , System.Drawing.Image imgSignPicture
            , string outputPath)
        {
            var pdfstr = new MemoryStream();
            string outFileName = string.Format("{0}.pdf", outputPath);
            using (var signer = new PdfDocumentSigner(File.OpenRead(pdfinputPath)))
            {
                // Create a PKCS#7 signature
                Pkcs7Signer pkcs7Signature = new Pkcs7Signer(cert, HashAlgorithmType.SHA256);

                // Create a signature field on the first page
                var signatureFieldInfo = new PdfSignatureFieldInfo(1);

                // Specify the field's name and location
                signatureFieldInfo.Name = signName;
                signatureFieldInfo.SignatureBounds = new PdfRectangle(20, 20, 150, 150);

                // Apply a signature to a newly created signature field
                var cooperSignature = new PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo);
                if (imgSignPicture != null)
                    cooperSignature.SetImageData(GraphicSupport.ImageToByteArray(imgSignPicture));
                try
                {
                    // Sign and save the document
                    signer.SaveDocument(pdfstr, cooperSignature);
                    // Sign and save the document
                    if (!string.IsNullOrEmpty(outputPath) && pdfstr != null)
                        File.WriteAllBytes(outFileName, pdfstr.ToArray());
                }
                catch (Exception ex)
                {
                    ErrorService.GetFrameworkErrorMessage(ex, "Ký số", false, cert.FriendlyName);
                    CustomMessageBox.MSG_Information_OK("Quá trình ký bị lỗi!.");
                    return null;
                }
            }
;
            return pdfstr;
        }
        public static MemoryStream SignPDF(string pdfinputPath, string signName
     , System.Drawing.Image imgSignPicture
     , string outputPath)
        {
            var cert = GetCertificate();
            if (cert != null)
            {
                var pdfstr = new MemoryStream();
                string outFileName = string.Format("{0}.pdf", outputPath);
                using (var signer = new PdfDocumentSigner(File.OpenRead(pdfinputPath)))
                {
                    // Create a PKCS#7 signature
                    Pkcs7Signer pkcs7Signature = new Pkcs7Signer(cert, HashAlgorithmType.SHA256);

                    // Create a signature field on the first page
                    var signatureFieldInfo = new PdfSignatureFieldInfo(1);

                    // Specify the field's name and location
                    signatureFieldInfo.Name = signName;
                    signatureFieldInfo.SignatureBounds = new PdfRectangle(20, 20, 150, 150);

                    // Apply a signature to a newly created signature field
                    var cooperSignature = new PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo);
                    if (imgSignPicture != null)
                        cooperSignature.SetImageData(GraphicSupport.ImageToByteArray(imgSignPicture));

                    try
                    {
                        // Sign and save the document
                        signer.SaveDocument(pdfstr, cooperSignature);
                        if (!string.IsNullOrEmpty(outputPath) && pdfstr != null)
                            File.WriteAllBytes(outFileName, pdfstr.ToArray());
                    }
                    catch (Exception ex)
                    {
                        ErrorService.GetFrameworkErrorMessage(ex, "Ký số", false, cert.FriendlyName);
                        CustomMessageBox.MSG_Information_OK("Quá trình ký bị lỗi!.");
                        return null;
                    }
                }

                return pdfstr;
            }
            return null;
        }
        public static MemoryStream SignPDF(X509Certificate2 cert
         , Stream pdfInputStream, string signName
         , System.Drawing.Image imgSignPicture
         , string outputPath, string AppName = "TPH.LabIMS", double left = 380, double bottom = 65, double right = 580, double height = 125)
        {
            Pkcs7Signer pkcs7Signature;
            var pdfstr = new MemoryStream();
            string outFileName = string.Format("{0}.pdf", outputPath);
            if (dicSignInfo.Where(x => x.Key.Equals(cert)).Any())
            {
                pkcs7Signature = dicSignInfo[cert];
            }
            else
            {
                // Create a PKCS#7 signature
                pkcs7Signature = new Pkcs7Signer(cert, HashAlgorithmType.SHA256);
                dicSignInfo.Add(cert, pkcs7Signature);
            }
            using (var signer = new PdfDocumentSigner(pdfInputStream))
            {
                var sigInfo = signer.GetSignatureInfo();
                // Create a signature field for all page
                var lstAll = new List<int>();
                for (int i = 0; i < signer.PageCount; i++)
                {
                    lstAll.Add(i + 1);
                }
                var signatureFieldInfo = new PdfSignatureFieldInfo(lstAll);
                signatureFieldInfo.Name = signName;
                signatureFieldInfo.SignatureBounds = new PdfRectangle(left, bottom, right, height);
                // Apply a signature to a newly created signature field
                var cooperSignature = new PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo);
                PdfSignatureAppearance appearance = new PdfSignatureAppearance();
                appearance.DateTimeFormat = "dd/MM/yyyy HH:mm:ss";
                //appearance.ShowLabels = true;
                //appearance.ShowDistinguishedName = true;
                appearance.ShowDate = false;
                //appearance.ShowLabels = true;
                //appearance.ShowName = true;
                appearance.SignatureNameFont.Bold = true;
                appearance.SignatureNameFont.Size = 9;
                appearance.SignatureNameFont.Color = new PdfRGBColor(Color.DarkRed.R / 255.0, Color.DarkGreen.G / 255.0, Color.DarkBlue.B / 255.0);
                appearance.SignatureDetailsFont.Size = 8;
                if (imgSignPicture != null)
                {
                    appearance.SetImageData(GraphicSupport.ImageToByteArray(imgSignPicture));
                    appearance.AppearanceType = PdfSignatureAppearanceType.Image;
                    appearance.ShowLabels = true;
                }
                else
                {
                    appearance.AppearanceType = PdfSignatureAppearanceType.None;
                    appearance.ShowLabels = false;
                }
                cooperSignature.ApplicationName = AppName;
                cooperSignature.Name = signName;
                cooperSignature.SigningTime = DateTime.Now;
                cooperSignature.SetSignatureAppearance(appearance);

                try
                {
                    // Sign and save the document
                    signer.SaveDocument(pdfstr, cooperSignature);
                    if (!string.IsNullOrEmpty(outputPath) && pdfstr != null)
                        File.WriteAllBytes(outFileName, pdfstr.ToArray());
                }
                catch (Exception ex)
                {
                    ErrorService.GetFrameworkErrorMessage(ex, "Ký số", false, cert.FriendlyName);
                    CustomMessageBox.MSG_Information_OK("Quá trình ký bị lỗi!.");
                    return null;
                }
            }

            return pdfstr;
        }
        private static System.Drawing.Image SingByImage(string sigName)
        {
            System.Drawing.Bitmap bmpOut = new System.Drawing.Bitmap(35, 250);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawRectangle(new Pen(Brushes.Red), 0, 0, 250, 35);
            g.DrawString(string.Format("Digtal signed by:\n{0}", sigName), new System.Drawing.Font("Arial", 10, FontStyle.Bold), Brushes.Red,5, 5);
            return bmpOut;
        }
        public static MemoryStream SignPDF(Stream pdfInputStream, string signName
        , System.Drawing.Image imgSignPicture
        , string outputPath)
        {
            var pdfstr = new MemoryStream();
            var cert = GetCertificate();
            if (cert != null)
            {
                string outFileName = string.Format("{0}.pdf", outputPath);
                using (var signer = new PdfDocumentSigner(pdfInputStream))
                {
                    // Create a PKCS#7 signature
                    Pkcs7Signer pkcs7Signature = new Pkcs7Signer(cert, HashAlgorithmType.SHA256);

                    // Create a signature field on the first page
                    var signatureFieldInfo = new PdfSignatureFieldInfo(1);

                    // Specify the field's name and location
                    signatureFieldInfo.Name = signName;
                    signatureFieldInfo.SignatureBounds = new PdfRectangle(20, 20, 150, 150);

                    // Apply a signature to a newly created signature field
                    var cooperSignature = new PdfSignatureBuilder(pkcs7Signature, signatureFieldInfo);
                    if (imgSignPicture != null)
                        cooperSignature.SetImageData(GraphicSupport.ImageToByteArray(imgSignPicture));

                    try
                    {
                        // Sign and save the document
                        signer.SaveDocument(pdfstr, cooperSignature);
                        if (!string.IsNullOrEmpty(outputPath) && pdfstr != null)
                            File.WriteAllBytes(outFileName, pdfstr.ToArray());
                    }
                    catch (Exception ex)
                    {
                     
                        ErrorService.GetFrameworkErrorMessage(ex, "Ký số", false, cert.FriendlyName);
                        CustomMessageBox.MSG_Information_OK("Quá trình ký bị lỗi!.");
                        return null;
                    }
                }
                return pdfstr;
            }
            return null;
        }
    }
}
