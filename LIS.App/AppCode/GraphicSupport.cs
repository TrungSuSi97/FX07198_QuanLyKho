namespace TPH.LIS.App.AppCode
{
    //    class GraphicSupport
    //    {

    //        /// <summary>
    //        /// Hàm Load image lên PictureBox
    //        /// </summary>
    //        /// <param name="pbx">Đối tượng PictureBox</param>
    //        /// <param name="s">Chuỗi Binary</param>
    //        public static void LoadImage(PictureBox pbx, string s)
    //        {
    //            try
    //            {
    //                byte[] bArr = BinaryToString.FromBase64(s);
    //                ImageConverter imc = new ImageConverter();
    //                pbx.Image = (Image)imc.ConvertFrom(bArr);
    //            }
    //            catch
    //            {
    //                pbx.Image = null;
    //            }
    //        }
    //        /// <summary>
    //        /// Hàm Load image lên PictureBox
    //        /// </summary>
    //        /// <param name="pbx">Đối tượng PictureBox</param>
    //        /// <param name="s">Chuỗi Binary</param>
    //        public static void LoadImage(PictureBox pbx, object image)
    //        {
    //            try
    //            {
    //                //byte[] bArr = BinaryToString.FromBase64(s);
    //                //byte[] bArr = b;
    //                ImageConverter imc = new ImageConverter();
    //                pbx.Image = (Image)imc.ConvertFrom(image);
    //            }
    //            catch
    //            {
    //                pbx.Image = null;
    //            }
    //        }
    //        /// <summary>
    //        /// Hàm đọc file ảnh lên PictureBox và dịch ra Binary
    //        /// </summary>
    //        /// <param name="pbx"></param>
    //        /// <returns></returns>
    //        public static byte[] BufferBinary(PictureBox pbx)
    //        {
    //            byte[] bBff = new byte[0]; 
    //            OpenFileDialog ofd = new OpenFileDialog();
    //            ofd.Filter = "Image file (*.Bmp,*.Jpg,*.Gif)|*.Bmp;*.Jpg;*.Gif";
    //            if (ofd.ShowDialog() == DialogResult.OK)
    //            {
    //                pbx.Image = Image.FromFile(ofd.FileName);
    //                ImageConverter ic = new ImageConverter();
    //                bBff = (byte[])ic.ConvertTo(pbx.Image, bBff.GetType());
    //            }
    //            return bBff;
    //        }
    //        public static byte[] BufferBinaryFromPicturebox(PictureBox pbx)
    //        {
    //            byte[] bBff = new byte[0]; 
    //            ImageConverter ic = new ImageConverter();
    //            bBff = (byte[])ic.ConvertTo(pbx.Image, bBff.GetType());
    //            return bBff;
    //        }
    //        //Crop image
    //        public static Image cropImage(Bitmap imgSrc, Rectangle cropArea)
    //        {
    //            //Bitmap bmpImage = new Bitmap(imgSrc);
    //            //var Temp = imgSrc.Clone(cropArea, bmpImage.PixelFormat);
    //            //bmpImage.Dispose();
    //            //return Temp;
    //            Bitmap target = new Bitmap(cropArea.Width, cropArea.Height);

    //            using (Graphics g = Graphics.FromImage(target))
    //            {
    //                g.DrawImage(imgSrc, new Rectangle(0, 0, target.Width, target.Height), cropArea, GraphicsUnit.Pixel);
    //            }
    //            return target;
    //        }


    //        public static Image cropCenter640x480(Bitmap imgSrc)
    //        {
    //            Rectangle cropArea = new Rectangle(new Point(80, 0), new Size(480, 480));
    //            return cropImage(imgSrc, cropArea);
    //        }
    //        public static Image cropCenter640x480_NoiSoi(Bitmap imgSrc)
    //        {
    //            Rectangle cropArea = new Rectangle(new Point(14, 0), new Size(490, 480));
    //            return cropImage(imgSrc, cropArea);
    //        }
    //        public static Image cropCenter800x600_NoiSoi(Bitmap imgSrc)
    //        {
    //            Rectangle cropArea = new Rectangle(new Point(14, 0), new Size(612, 600));
    //            return cropImage(imgSrc, cropArea);
    //        }
    //        public static Image cropCenter1024x768_NoiSoi(Bitmap imgSrc)
    //        {
    //            Rectangle cropArea = new Rectangle(new Point(14, 0), new Size(778, 768));
    //            return cropImage(imgSrc, cropArea);
    //        }
    //        public static Image cropCenterPicturebox(PictureBox pb, Size imgCropSize)
    //        {
    //            int Xpoint = (pb.Width - imgCropSize.Width) / 2;
    //            Rectangle cropArea = new Rectangle(new Point(Xpoint, 0), imgCropSize);
    //            return cropImage((Bitmap)pb.Image, cropArea);
    //        }
    ////Resize Image
    //        public static Image ResizeImage(Image imgSource, Size newSize)
    //        {

    //            ImageConverter converter = new ImageConverter();
    //            byte[] imgArray = (byte[])converter.ConvertTo(imgSource, typeof(byte[]));

    //            MemoryStream ms = new MemoryStream(imgArray);
    //            Image original = Image.FromStream(ms);
    //            Image resized = ResizeWithSameRatio(imgSource, newSize.Width, newSize.Height);
    //            ms.Dispose();
    //            return resized;

    //        }
    //        public static Image ResizeImage_NoAutoScale(Image imgSource, Size newSize)
    //        {

    //            ImageConverter converter = new ImageConverter();
    //            byte[] imgArray = (byte[])converter.ConvertTo(imgSource, typeof(byte[]));

    //            MemoryStream ms = new MemoryStream(imgArray);
    //            Image original = Image.FromStream(ms);
    //            Image resized = ResizeWithSameRatio_noAutoScale(imgSource, newSize.Width, newSize.Height);
    //            ms.Dispose();
    //            return resized;

    //        } 
    //        private static Image ResizeWithSameRatio_noAutoScale(Image image, float NewWidth, float NewHeight)
    //        {
    //            // the colour for letter boxing, can be a parameter
    //            var brush = new SolidBrush(Color.Transparent);

    //            // target scaling factor
    //           // float scale = Math.Min(NewWidth / image.Width, NewHeight / image.Height);

    //            // target image
    //            var bmp = new Bitmap((int)NewWidth, (int)NewHeight);
    //            var graph = Graphics.FromImage(bmp);

    //            var scaleWidth = (int)(image.Width * (NewWidth / image.Width));
    //            var scaleHeight = (int)(image.Height * (NewHeight / image.Height));

    //            // fill the background and then draw the image in the 'centre'
    //            graph.FillRectangle(brush, new RectangleF(0, 0, NewWidth, NewHeight));
    //            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    //            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //            graph.DrawImage(image, new Rectangle(((int)NewWidth - scaleWidth) / 2, ((int)NewHeight - scaleHeight) / 2, scaleWidth, scaleHeight));

    //            return bmp;
    //        }
    //        //Resize Image
    //        private static Image ResizeWithSameRatio(Image image, float NewWidth, float NewHeight)
    //        {
    //            // the colour for letter boxing, can be a parameter
    //            var brush = new SolidBrush(Color.Transparent);

    //            // target scaling factor
    //            float scale = Math.Min(NewWidth / image.Width, NewHeight / image.Height);

    //            // target image
    //            var bmp = new Bitmap((int)NewWidth, (int)NewHeight);
    //            var graph = Graphics.FromImage(bmp);

    //            var scaleWidth = (int)(image.Width * scale);
    //            var scaleHeight = (int)(image.Height * scale);

    //            // fill the background and then draw the image in the 'centre'
    //            graph.FillRectangle(brush, new RectangleF(0, 0, NewWidth, NewHeight));
    //            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    //            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //            graph.DrawImage(image, new Rectangle(((int)NewWidth - scaleWidth) / 2, ((int)NewHeight - scaleHeight) / 2, scaleWidth, scaleHeight));

    //            return bmp;
    //        }
    //        //Convert black wite color
    //        public static Image Convert_BW_Image(Image img)
    //        {
    //            Bitmap originalbmp = new Bitmap(img); // Load the  image
    //            Bitmap newbmp = new Bitmap(img);
    //            for (int row = 0; row < originalbmp.Width; row++) // Indicates row number
    //            {
    //                for (int column = 0; column < originalbmp.Height; column++) // Indicate column number
    //                {
    //                    Color colorValue = originalbmp.GetPixel(row, column); // Get the color pixel
    //                    int averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
    //                    newbmp.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
    //                }
    //            }
    //            return newbmp;
    //        }

    //        //Edit AdjustContrast
    //        //Note Enable Usafe mode for project
    //        public static Bitmap AdjustContrast(Bitmap Image, float Value)
    //        {
    //            Value = (100.0f + Value) / 100.0f;
    //            Value *= Value;
    //            Bitmap NewBitmap = (Bitmap)Image.Clone();
    //            BitmapData data = NewBitmap.LockBits(
    //                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
    //                ImageLockMode.ReadWrite,
    //                NewBitmap.PixelFormat);
    //            int Height = NewBitmap.Height;
    //            int Width = NewBitmap.Width;

    //            unsafe
    //            {
    //                for (int y = 0; y < Height; ++y)
    //                {
    //                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
    //                    int columnOffset = 0;
    //                    for (int x = 0; x < Width; ++x)
    //                    {
    //                        byte B = row[columnOffset];
    //                        byte G = row[columnOffset + 1];
    //                        byte R = row[columnOffset + 2];

    //                        float Red = R / 255.0f;
    //                        float Green = G / 255.0f;
    //                        float Blue = B / 255.0f;
    //                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
    //                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
    //                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

    //                        int iR = (int)Red;
    //                        iR = iR > 255 ? 255 : iR;
    //                        iR = iR < 0 ? 0 : iR;
    //                        int iG = (int)Green;
    //                        iG = iG > 255 ? 255 : iG;
    //                        iG = iG < 0 ? 0 : iG;
    //                        int iB = (int)Blue;
    //                        iB = iB > 255 ? 255 : iB;
    //                        iB = iB < 0 ? 0 : iB;

    //                        row[columnOffset] = (byte)iB;
    //                        row[columnOffset + 1] = (byte)iG;
    //                        row[columnOffset + 2] = (byte)iR;

    //                        columnOffset += 4;
    //                    }
    //                }
    //            }

    //            NewBitmap.UnlockBits(data);

    //            return NewBitmap;
    //        }
    //    }
}
