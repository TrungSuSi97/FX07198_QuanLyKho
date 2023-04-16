using System;
using System.Collections.Generic;
using System.IO;
using ImageMagick;

namespace TPH.LIS.Common.Extensions
{
    public class PdfExtension
    {
        public static List<string> ConvertPdfToImage(string pdfFilePath, 
            string outPutFolder = "", 
            bool deletePdfFile = false,
            int dpi = 450, 
            MagickFormat fileType = MagickFormat.Jpeg)
        {
            try
            {
                var result = new List<string>();

                var ghostscriptPath = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "ghostscript");
                MagickNET.SetGhostscriptDirectory(ghostscriptPath);
                
                var settings = new MagickReadSettings { Density = new Density(450, 450) };
                var exporttedPath = string.Format(@"{0}\{1}", outPutFolder, pdfFilePath);
                using (var images = new MagickImageCollection())
                {
                    images.Read(exporttedPath, settings);
                    var fileName = Path.GetFileNameWithoutExtension(pdfFilePath);
                    var page = 1;
                    foreach (var magickImage in images)
                    {
                        var image = (MagickImage)magickImage;
                        image.Format = fileType;
                        var imageOutPutPath = string.Format("{0}\\{1}_Page{2}.{3}", outPutFolder, fileName, page, fileType);
                        if (File.Exists(imageOutPutPath))
                            File.Delete(imageOutPutPath);
                        image.Write(imageOutPutPath);
                        page++;

                        result.Add(imageOutPutPath);
                    }
                }

                if (deletePdfFile)
                {
                    DeleteFile(pdfFilePath);
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        private static void DeleteFile(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    return;
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
                
            }
        }
    }
}
