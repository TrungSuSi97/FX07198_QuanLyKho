using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using TPH.LIS.Common.Controls;
using System.Diagnostics;
using System.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TPH.LIS.Common.Extensions
{
    public enum Precedence
    {
        None = 11,
        Unary = 10,     // Not actually used.
        Power = 9,      // We use ^ to mean exponentiation.
        Times = 8,
        Div = 7,
        Modulus = 6,
        Plus = 5,
    }
    public class EvaluateExpression
    {
        public static double EvalExpression(string expression)
        {
            int best_pos = 0;
            int parens = 0;

            // Remove all spaces.
            string expr = expression.Replace(" ", "");
            int expr_len = expr.Length;
            if (expr_len == 0) return 0;

            // If we find + or - now, then it's a unary operator.
            bool is_unary = true;

            // So far we have nothing.
            Precedence best_prec = Precedence.None;

            // Find the operator with the lowest precedence.
            // Look for places where there are no open
            // parentheses.
            for (int pos = 0; pos < expr_len; pos++)
            {
                // Examine the next character.
                string ch = expr.Substring(pos, 1);

                // Assume we will not find an operator. In
                // that case, the next operator will not
                // be unary.
                bool next_unary = false;

                if (ch == " ")
                {
                    // Just skip spaces. We keep them here
                    // to make the error messages easier to
                }
                else if (ch == "(")
                {
                    // Increase the open parentheses count.
                    parens += 1;

                    // A + or - after "(" is unary.
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    // Decrease the open parentheses count.
                    parens -= 1;

                    // An operator after ")" is not unary.
                    next_unary = false;

                    // If parens < 0, too many )'s.
                    if (parens < 0)
                        throw new FormatException(
                            "Too many close parentheses in '" +
                            expression + "'");
                }
                else if (parens == 0)
                {
                    // See if this is an operator.
                    if ((ch == "^") || (ch == "*") ||
                        (ch == "/") || (ch == "\\") ||
                        (ch == "%") || (ch == "+") ||
                        (ch == "-"))
                    {
                        // An operator after an operator
                        // is unary.
                        next_unary = true;

                        // See if this operator has higher
                        // precedence than the current one.
                        switch (ch)
                        {
                            case "^":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;

                            case "*":
                            case "/":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }
                                break;

                            case "%":
                                if (best_prec >= Precedence.Modulus)
                                {
                                    best_prec = Precedence.Modulus;
                                    best_pos = pos;
                                }
                                break;

                            case "+":
                            case "-":
                                // Ignore unary operators
                                // for now.
                                if ((!is_unary) &&
                                    best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                        } // End switch (ch)
                    } // End if this is an operator.
                } // else if (parens == 0)

                is_unary = next_unary;
            } // for (int pos = 0; pos < expr_len; pos++)

            // If the parentheses count is not zero,
            // there's a ) missing.
            if (parens != 0)
            {
                throw new FormatException(
                    "Missing close parenthesis in '" +
                    expression + "'");
            }

            // Hopefully we have the operator.
            if (best_prec < Precedence.None)
            {
                string lexpr = expr.Substring(0, best_pos);
                string rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case "^":
                        return Math.Pow(
                            EvalExpression(lexpr),
                            EvalExpression(rexpr));
                    case "*":
                        return
                            EvalExpression(lexpr) *
                            EvalExpression(rexpr);
                    case "/":
                        return
                            EvalExpression(lexpr) /
                            EvalExpression(rexpr);
                    case "%":
                        return
                            EvalExpression(lexpr) %
                            EvalExpression(rexpr);
                    case "+":
                        return
                            EvalExpression(lexpr) +
                            EvalExpression(rexpr);
                    case "-":
                        return
                            EvalExpression(lexpr) -
                            EvalExpression(rexpr);
                }
            }

            // if we do not yet have an operator, there
            // are several possibilities:
            //
            // 1. expr is (expr2) for some expr2.
            // 2. expr is -expr2 or +expr2 for some expr2.
            // 3. expr is Fun(expr2) for a function Fun.
            // 4. expr is a primitive.
            // 5. It's a literal like "3.14159".

            // Look for (expr2).
            if (expr.StartsWith("(") && expr.EndsWith(")"))
            {
                // Remove the parentheses.
                return EvalExpression(expr.Substring(1, expr_len - 2));
            }

            // Look for -expr2.
            if (expr.StartsWith("-"))
            {
                return -EvalExpression(expr.Substring(1));
            }

            // Look for +expr2.
            if (expr.StartsWith("+"))
            {
                return EvalExpression(expr.Substring(1));
            }

            // Look for Fun(expr2).
            if (expr_len > 5 && expr.EndsWith(")"))
            {
                // Find the first (.
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    // See what the function is.
                    string lexpr = expr.Substring(0, paren_pos);
                    string rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr.ToLower())
                    {
                        case "exp":
                            return Math.Exp(EvalExpression(rexpr));
                        case "sin":
                            return Math.Sin(EvalExpression(rexpr));
                        case "cos":
                            return Math.Cos(EvalExpression(rexpr));
                        case "tan":
                            return Math.Tan(EvalExpression(rexpr));
                        case "sqrt":
                            return Math.Sqrt(EvalExpression(rexpr));
                        case "factorial":
                            return Factorial(EvalExpression(rexpr));
                        case "log10":
                            return Math.Log10(EvalExpression(rexpr));
                        case "log1":
                            return Math.Log(EvalExpression(rexpr), 1);
                        case "log2":
                            return Math.Log(EvalExpression(rexpr), 2);
                        case "log3":
                            return Math.Log(EvalExpression(rexpr), 3);
                        case "log4":
                            return Math.Log(EvalExpression(rexpr), 4);
                        case "log5":
                            return Math.Log(EvalExpression(rexpr), 5);
                        case "log6":
                            return Math.Log(EvalExpression(rexpr), 6);
                        case "log7":
                            return Math.Log(EvalExpression(rexpr), 7);
                        case "log8":
                            return Math.Log(EvalExpression(rexpr), 8);
                        case "log9":
                            return Math.Log(EvalExpression(rexpr), 9);
                        case "ln":
                            return Math.Log(EvalExpression(rexpr));
                    }
                }
            }

            //// See if it's a primitive.
            //if (Primatives.ContainsKey(expr))
            //{
            //    // Return the corresponding value,
            //    // converted into a Double.
            //    try
            //    {
            //        // Try to convert the expression into a value.
            //        return double.Parse(Primatives[expr]);
            //    }
            //    catch (Exception)
            //    {
            //        throw new FormatException(
            //            "Primative '" + expr +
            //            "' has value '" +
            //            Primatives[expr] +
            //            "' which is not a Double.");
            //    }
            //}

            // It must be a literal like "2.71828".
            try
            {
                // Try to convert the expression into a Double.
                return double.Parse(expr);
            }
            catch (Exception)
            {
                throw new FormatException(
                    "Error evaluating '" + expression +
                    "' as a constant.");
            }
        }

        // Return the factorial of the expression.
        private static double Factorial(double value)
        {
            // Make sure the value is an integer.
            if ((long)value != value)
            {
                throw new ArgumentException(
                    "Parameter to Factorial function must be an integer in Factorial(" +
                    value.ToString() + ")");
            }

            double result = 1;
            for (int i = 2; i <= value; i++)
            {
                result *= i;
            }
            return result;
        }
    }
    public class ReadNumberToCharactor
    {
        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        // Hàm đọc số thành chữ
        public static string ReadNumber(long SoTien, string strTail)
        {
            int lan, i;
            long so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        // Hàm đọc số có 3 chữ số
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }
    }
    public class VNCurrency
    {
        public static string ToString(decimal number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str + " ";
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            str = str.Trim() + " đồng chẵn";
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }
        public static string ToString(double number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = "";
            bool booAm = false;
            double decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDouble(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str + " ";
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            str = str.Trim() + " đồng chẵn";
            return str.Substring(0, 1).ToUpper() + str.Substring(1);
        }
    }
    public class GraphicSupport
    {

        /// <summary>
        /// Hàm Load image lên PictureBox
        /// </summary>
        /// <param name="pbx">Đối tượng PictureBox</param>
        /// <param name="s">Chuỗi Binary</param>
        public static void LoadImage(PictureBox pbx, string s)
        {
            try
            {
                byte[] bArr = BinaryToString.FromBase64(s);
                ImageConverter imc = new ImageConverter();
                pbx.Image = (Image)imc.ConvertFrom(bArr);
            }
            catch
            {
                pbx.Image = null;
            }
        }

        /// <summary>
        /// Hàm Load image lên PictureBox
        /// </summary>
        /// <param name="pbx">Đối tượng PictureBox</param>
        /// <param name="s">Chuỗi Binary</param>
        public static void LoadImage(PictureBox pbx)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.Filter = "Image file (*.Bmp,*.Jpg,*.Gif)|*.Bmp;*.Jpg;*.Gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbx.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch
            {
                pbx.Image = null;
            }
        }

        public static void LoadImage(PictureBox pbx, object image)
        {
            try
            {
                ImageConverter imc = new ImageConverter();
                pbx.Image = (Image)imc.ConvertFrom(image);
            }
            catch
            {
                pbx.Image = null;
            }
        }

        private static byte[] _bBff;

        /// <summary>
        /// Hàm đọc file ảnh lên PictureBox và dịch ra Binary
        /// </summary>
        /// <param name="pbx"></param>
        /// <returns></returns>
        public static byte[] BufferBinary(PictureBox pbx)
        {
            //  bBff = new byte[0];
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Image file (*.Bmp,*.Jpg,*.Gif)|*.Bmp;*.Jpg;*.Gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbx.Image = Image.FromFile(ofd.FileName);
                ImageConverter ic = new ImageConverter();
                _bBff = (byte[])ic.ConvertTo(pbx.Image, _bBff.GetType());
            }
            return _bBff;
        }

        public static byte[] ImageToByteArrayFromPicturebox(PictureBox pbx)
        {

            ImageConverter ic = new ImageConverter();
            if (pbx.Image != null)
            {
                _bBff = new byte[0];
                _bBff = (byte[])ic.ConvertTo(pbx.Image, _bBff.GetType());
            }
            return _bBff;
        }

        public static byte[] ImageToByteArray(Image img)
        {
            if (img != null)
            {
                _bBff = new byte[0];
                ImageConverter ic = new ImageConverter();
                _bBff = (byte[])ic.ConvertTo(img, _bBff.GetType());
                return _bBff;
            }
            return null;
        }

        public static Bitmap ImageFromByteArray(byte[] byteArray)
        {
            return (Bitmap)((new ImageConverter()).ConvertFrom(byteArray));
        }

        //Crop image
        public static Image CropImage(Bitmap imgSrc, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(imgSrc);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Image CropCenter640X480(Bitmap imgSrc)
        {
            Rectangle cropArea = new Rectangle(new Point(80, 0), new Size(480, 480));
            return CropImage(imgSrc, cropArea);
        }

        public static Image CropCenterPicturebox(PictureBox pb, Size imgCropSize)
        {
            int xpoint = (pb.Width - imgCropSize.Width) / 2;
            Rectangle cropArea = new Rectangle(new Point(xpoint, 0), imgCropSize);
            return CropImage((Bitmap)pb.Image, cropArea);
        }

        public static Image ResizeImage(Image imgSource, Size newSize)
        {

            ImageConverter converter = new ImageConverter();
            byte[] imgArray = (byte[])converter.ConvertTo(imgSource, typeof(byte[]));

            MemoryStream ms = new MemoryStream(imgArray);
            Image original = Image.FromStream(ms);
            Image resized = ResizeWithSameRatio(imgSource, newSize.Width, newSize.Height);
            ms.Dispose();
            return resized;

        }

        //Resize Image
        public static Image ResizeImage_NoAutoScale(Image imgSource, Size newSize)
        {

            ImageConverter converter = new ImageConverter();
            byte[] imgArray = (byte[])converter.ConvertTo(imgSource, typeof(byte[]));

            MemoryStream ms = new MemoryStream(imgArray);
            Image original = Image.FromStream(ms);
            Image resized = ResizeWithSameRatio_noAutoScale(imgSource, newSize.Width, newSize.Height);
            ms.Dispose();
            return resized;

        }
        private static Image ResizeWithSameRatio_noAutoScale(Image image, float newWidth, float newHeight)
        {
            // the colour for letter boxing, can be a parameter
            var brush = new SolidBrush(Color.Transparent);

            // target scaling factor
            // float scale = Math.Min(NewWidth / image.Width, NewHeight / image.Height);

            // target image
            var bmp = new Bitmap((int)newWidth, (int)newHeight);
            var graph = Graphics.FromImage(bmp);

            var scaleWidth = (int)(image.Width * (newWidth / image.Width));
            var scaleHeight = (int)(image.Height * (newHeight / image.Height));

            // fill the background and then draw the image in the 'centre'
            graph.FillRectangle(brush, new RectangleF(0, 0, newWidth, newHeight));
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graph.DrawImage(image, new Rectangle(((int)newWidth - scaleWidth) / 2, ((int)newHeight - scaleHeight) / 2, scaleWidth, scaleHeight));

            return bmp;
        }
        private static Image ResizeWithSameRatio(Image image, float newWidth, float newHeight)
        {
            // the colour for letter boxing, can be a parameter
            var brush = new SolidBrush(Color.Transparent);

            // target scaling factor
            float scale = Math.Min(newWidth / image.Width, newHeight / image.Height);

            // target image
            var bmp = new Bitmap((int)newWidth, (int)newHeight);
            var graph = Graphics.FromImage(bmp);

            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);

            // fill the background and then draw the image in the 'centre'
            graph.FillRectangle(brush, new RectangleF(0, 0, newWidth, newHeight));
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graph.DrawImage(image,
                new Rectangle(((int)newWidth - scaleWidth) / 2, ((int)newHeight - scaleHeight) / 2, scaleWidth,
                    scaleHeight));

            return bmp;
        }

        //Convert black wite color
        public static Image Convert_BW_Image(Image img)
        {
            Bitmap originalbmp = new Bitmap(img); // Load the  image
            Bitmap newbmp = new Bitmap(img);
            for (int row = 0; row < originalbmp.Width; row++) // Indicates row number
            {
                for (int column = 0; column < originalbmp.Height; column++) // Indicate column number
                {
                    Color colorValue = originalbmp.GetPixel(row, column); // Get the color pixel
                    int averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3;
                    // get the average for black and white
                    newbmp.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue));
                    // Set the value to new pixel
                }
            }
            return newbmp;
        }

        //Edit AdjustContrast
        //Note Enable Usafe mode for project
        public static Bitmap AdjustContrast(Bitmap image, float value)
        {
            value = (100.0f + value) / 100.0f;
            value *= value;
            Bitmap newBitmap = (Bitmap)image.Clone();
            BitmapData data = newBitmap.LockBits(
                new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                ImageLockMode.ReadWrite,
                newBitmap.PixelFormat);
            int height = newBitmap.Height;
            int width = newBitmap.Width;

            unsafe
            {
                for (int y = 0; y < height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < width; ++x)
                    {
                        byte b = row[columnOffset];
                        byte g = row[columnOffset + 1];
                        byte r = row[columnOffset + 2];

                        float red = r / 255.0f;
                        float green = g / 255.0f;
                        float blue = b / 255.0f;
                        red = (((red - 0.5f) * value) + 0.5f) * 255.0f;
                        green = (((green - 0.5f) * value) + 0.5f) * 255.0f;
                        blue = (((blue - 0.5f) * value) + 0.5f) * 255.0f;

                        int iR = (int)red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            newBitmap.UnlockBits(data);

            return newBitmap;
        }
        public static Bitmap sharpen(Bitmap image)
        {
            Bitmap sharpenImage = new Bitmap(image.Width, image.Height);

            int filterWidth = 3;
            int filterHeight = 3;
            int w = image.Width;
            int h = image.Height;

            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = 0;
            filter[1, 1] = 1;

            double factor = 0.9999;
            double bias = -0.5;

            Color[,] result = new Color[image.Width, image.Height];

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    //=====[REMOVE LINES]========================================================
                    // Color must be read per filter entry, not per image pixel.
                    Color imageColor = image.GetPixel(x, y);
                    //===========================================================================

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + w) % w;
                            int imageY = (y - filterHeight / 2 + filterY + h) % h;

                            //=====[INSERT LINES]========================================================
                            // Get the color here - once per fiter entry and image pixel.
                            Color imgColor = image.GetPixel(imageX, imageY);
                            //===========================================================================

                            red += imgColor.R * filter[filterX, filterY];
                            green += imgColor.G * filter[filterX, filterY];
                            blue += imgColor.B * filter[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    sharpenImage.SetPixel(i, j, result[i, j]);
                }
            }
            return sharpenImage;
        }
    }

    public class Utilities
    {
        /// <summary>
        /// Hàm cắt đi dấu nháy trong chuổi
        /// </summary>
        /// <param name="str">Chuổi ký tự truyền vào</param>
        /// <returns>Chuổi ký tự trả về</returns>
        public static string ConvertSqlString(string str)
        {
            if (str != null)
                return str.Replace("'", "''");
            else
                return string.Empty;
        }
        public static string ConvertStrinArryToInClauseSQL(string[] array, bool isChar)
        {
            string returnString = string.Empty;
            if (array == null)
                return returnString;
            if (array.Length > 0)
            {
                foreach (string s in array)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (!string.IsNullOrEmpty(returnString))
                            returnString += ",";
                        if (isChar)
                            returnString += string.Format("'{0}'", s.Replace("'", ""));
                        else
                            returnString += string.Format("{0}", s.Replace("'", ""));
                    }
                }
            }
            return returnString;
        }
        public static string ConvertStrinArryToInClauseSQL(int[] array, bool isChar)
        {
            string returnString = string.Empty;
            foreach (int s in array)
            {
                if (!string.IsNullOrEmpty(returnString))
                    returnString += ",";
                if (isChar)
                    returnString += string.Format("'{0}'", s);
                else
                    returnString += string.Format("{0}", s);
            }
            return returnString;
        }
        public static string ConvertStrinArryToInClauseSQL(List<string> lst, bool isChar)
        {
            string returnString = string.Empty;
            if (lst != null)
            {
                if (lst.Count > 0)
                {
                    foreach (string s in lst)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (!string.IsNullOrEmpty(returnString))
                                returnString += ",";
                            if (isChar)
                                returnString += string.Format("'{0}'", s.Replace("'", ""));
                            else
                                returnString += string.Format("{0}", s.Replace("'", ""));
                        }
                    }
                }
            }
            return returnString;
        }
        public static string ConvertStrinArryToInClauseSQLForSplitString(List<string> lst)
        {
            string returnString = string.Empty;
            if (lst != null)
            {
                if (lst.Count > 0)
                {
                    foreach (string s in lst)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (!string.IsNullOrEmpty(returnString))
                                returnString += ",";

                            returnString += string.Format("{0}", s.Replace("'", ""));
                        }
                    }
                }
            }
            return returnString;
        }
        public static string ConvertStrinArryToInClauseSQLForSplitString(List<string> lst, string specialSPlitString)
        {
            string returnString = string.Empty;
            if (lst != null)
            {
                if (lst.Count > 0)
                {
                    foreach (string s in lst)
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (!string.IsNullOrEmpty(returnString))
                                returnString += specialSPlitString;

                            returnString += string.Format("{0}", s.Replace("'", ""));
                        }
                    }
                }
            }
            return returnString;
        }
        public static string ReplaceInStringForParameter(string str)
        {
            string result = "";
            if (str.Length > 0)
            {
                result = string.Empty;
                var temp = str.Trim();
                if (temp.Substring(0, 1) == "'" && temp.Substring(str.Trim().Length - 1, 1) == "'")
                {
                    temp = temp.Substring(1, temp.Length - 1);
                    temp = temp.Substring(0, temp.Length - 1);
                }
                result = temp.Replace("','", ",");
            }
            return result;
        }

        public static string ArrayToSqlValue(string[] str)
        {
            string result = "''";
            if (str != null)
            {
                if (str.Length > 0)
                {
                    result = string.Empty;
                    foreach (string s in str)
                    {
                        result += string.IsNullOrEmpty(result) ? "" : ",";
                        result += string.Format("'{0}'", s);
                    }
                }
            }
            return result;
        }
        public static List<string> StringToList(string inPut, string splitChar)
        {
            if (!string.IsNullOrEmpty(inPut))
            {
                return inPut.Split(new string[] { splitChar }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            return new List<string>();
        }
        /// <summary>
        /// Hàm dùng để chuyển tuổi ra năm
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static string ConvertBirthYear(string age)
        {
            if (string.IsNullOrEmpty(age)) age = "0";
            if (int.Parse(age) < 1000 && int.Parse(age) != 0)
                age = (DateTime.Now.Year - int.Parse(age)).ToString();

            return age;
        }

        public static string ChuyenTvKhongDau(string strVietNamese)
        {
            string findText =
                "áàảãạâấầẩẫậăắằẳẵặđèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            string replText =
                "aaaaaaaaaaaaaaaaadeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1, index2;
            while ((index = strVietNamese.IndexOfAny(findText.ToCharArray())) != -1)
            {
                index2 = findText.IndexOf(strVietNamese[index]);
                strVietNamese = strVietNamese.Replace(strVietNamese[index], replText[index2]);
            }
            return strVietNamese;
        }

        /// <summary>
        /// _TypeCOnvert=1 (Convert from UNI), _TypeCOnvert=2 (Convert from VNI), _TypeCOnvert=3 (Convert from ABC)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="typeConvert"></param>
        /// <returns></returns>
        public static string ConvertStringText(string source, int typeConvert)
        {
            string convertResult = "";
            string temp = "";
            if (string.IsNullOrEmpty(source))
                return "";

            #region UNI

            if (typeConvert == 1)
            {
                for (int i = 1; i <= source.Length; i++)
                {
                    temp = Strings.Mid(source, i, 1);
                    switch (temp)
                    {
                        case "á": //1
                            convertResult += "a";
                            break;
                        case "à": //2
                            convertResult += "a";
                            break;
                        case "ả": //3
                            convertResult += "a";
                            break;
                        case "ã": //4
                            convertResult += "a";
                            break;
                        case "ạ": //5
                            convertResult += "a";
                            break;
                        case "ă": //6
                            convertResult += "a";
                            break;
                        case "ắ": //7
                            convertResult += "a";
                            break;
                        case "ằ": //8
                            convertResult += "a";
                            break;
                        case "ẳ": //9
                            convertResult += "a";
                            break;
                        case "ẵ": //10
                            convertResult += "a";
                            break;
                        case "ặ": //11
                            convertResult += "a";
                            break;
                        case "â": //12
                            convertResult += "a";
                            break;
                        case "ấ": //13
                            convertResult += "a";
                            break;
                        case "ầ": //14
                            convertResult += "a";
                            break;
                        case "ẩ": //15
                            convertResult += "a";
                            break;
                        case "ẫ": //16
                            convertResult += "a";
                            break;
                        case "ậ": //17
                            convertResult += "a";
                            break;
                        case "é": //18
                            convertResult += "e";
                            break;
                        case "è": //19
                            convertResult += "e";
                            break;
                        case "ẻ": //20
                            convertResult += "e";
                            break;
                        case "ẽ": //21
                            convertResult += "e";
                            break;
                        case "ẹ": //22
                            convertResult += "e";
                            break;
                        case "ê": //23
                            convertResult += "e";
                            break;
                        case "ế": //24
                            convertResult += "e";
                            break;
                        case "ề": //25
                            convertResult += "e";
                            break;
                        case "ể": //26
                            convertResult += "e";
                            break;
                        case "ễ": //27
                            convertResult += "e";
                            break;
                        case "ệ": //28
                            convertResult += "e";
                            break;
                        case "ó": //29
                            convertResult += "o";
                            break;
                        case "ò": //30
                            convertResult += "o";
                            break;
                        case "ỏ": //31
                            convertResult += "o";
                            break;
                        case "õ": //32
                            convertResult += "o";
                            break;
                        case "ọ": //33
                            convertResult += "o";
                            break;
                        case "ô": //34
                            convertResult += "o";
                            break;
                        case "ố": //35
                            convertResult += "o";
                            break;
                        case "ồ": //36
                            convertResult += "o";
                            break;
                        case "ổ": //37
                            convertResult += "o";
                            break;
                        case "ỗ": //38
                            convertResult += "o";
                            break;
                        case "ộ": //39
                            convertResult += "o";
                            break;
                        case "ơ": //40
                            convertResult += "o";
                            break;
                        case "ớ": //41
                            convertResult += "o";
                            break;
                        case "ờ": //42
                            convertResult += "o";
                            break;
                        case "ở": //43
                            convertResult += "o";
                            break;
                        case "ỡ": //44
                            convertResult += "o";
                            break;
                        case "ợ": //45
                            convertResult += "o";
                            break;
                        case "ú": //46
                            convertResult += "u";
                            break;
                        case "ù": //47
                            convertResult += "u";
                            break;
                        case "ủ": //48
                            convertResult += "u";
                            break;
                        case "ũ": //49
                            convertResult += "u";
                            break;
                        case "ụ": //50
                            convertResult += "u";
                            break;
                        case "ư": //51
                            convertResult += "u";
                            break;
                        case "ứ": //52
                            convertResult += "u";
                            break;
                        case "ừ": //53
                            convertResult += "u";
                            break;
                        case "ử": //54
                            convertResult += "u";
                            break;
                        case "ữ": //55
                            convertResult += "u";
                            break;
                        case "ự": //56
                            convertResult += "u";
                            break;
                        case "ý": //57
                            convertResult += "y";
                            break;
                        case "ỳ": //58
                            convertResult += "y";
                            break;
                        case "ỷ": //59
                            convertResult += "y";
                            break;
                        case "ỹ": //60
                            convertResult += "y";
                            break;
                        case "ỵ": //61
                            convertResult += "y";
                            break;
                        case "Á": //62
                            convertResult += "A";
                            break;
                        case "À": //63
                            convertResult += "A";
                            break;
                        case "Ả": //64
                            convertResult += "A";
                            break;
                        case "Ã": //65
                            convertResult += "A";
                            break;
                        case "Ạ": //66
                            convertResult += "A";
                            break;
                        case "Ă": //67
                            convertResult += "A";
                            break;
                        case "Ắ": //68
                            convertResult += "A";
                            break;
                        case "Ằ": //69
                            convertResult += "A";
                            break;
                        case "Ẳ": //70
                            convertResult += "A";
                            break;
                        case "Ẵ": //71
                            convertResult += "A";
                            break;
                        case "Ặ": //72
                            convertResult += "A";
                            break;
                        case "Â": //73
                            convertResult += "A";
                            break;
                        case "Ấ": //74
                            convertResult += "A";
                            break;
                        case "Ầ": //75
                            convertResult += "A";
                            break;
                        case "Ẩ": //76
                            convertResult += "A";
                            break;
                        case "Ẫ": //77
                            convertResult += "A";
                            break;
                        case "Ậ": //78
                            convertResult += "A";
                            break;
                        case "É": //79
                            convertResult += "E";
                            break;
                        case "È": //80
                            convertResult += "E";
                            break;
                        case "Ẻ": //81
                            convertResult += "E";
                            break;
                        case "Ẽ": //82
                            convertResult += "E";
                            break;
                        case "Ẹ": //83
                            convertResult += "E";
                            break;
                        case "Ê": //84
                            convertResult += "E";
                            break;
                        case "Ế": //85
                            convertResult += "E";
                            break;
                        case "Ề": //86
                            convertResult += "E";
                            break;
                        case "Ể": //87
                            convertResult += "E";
                            break;
                        case "Ễ": //88
                            convertResult += "E";
                            break;
                        case "Ệ": //89
                            convertResult += "E";
                            break;
                        case "Ó": //90
                            convertResult += "O";
                            break;
                        case "Ò": //91
                            convertResult += "O";
                            break;
                        case "Ỏ": //92
                            convertResult += "O";
                            break;
                        case "Õ": //93
                            convertResult += "O";
                            break;
                        case "Ọ": //94
                            convertResult += "O";
                            break;
                        case "Ô": //95
                            convertResult += "O";
                            break;
                        case "Ố": //96
                            convertResult += "O";
                            break;
                        case "Ồ": //97
                            convertResult += "O";
                            break;
                        case "Ổ": //98
                            convertResult += "O";
                            break;
                        case "Ỗ": //99
                            convertResult += "O";
                            break;
                        case "Ộ": //100
                            convertResult += "O";
                            break;
                        case "Ơ": //101
                            convertResult += "O";
                            break;
                        case "Ớ": //102
                            convertResult += "O";
                            break;
                        case "Ờ": //103
                            convertResult += "O";
                            break;
                        case "Ở": //104
                            convertResult += "O";
                            break;
                        case "Ỡ": //105
                            convertResult += "O";
                            break;
                        case "Ợ": //106
                            convertResult += "O";
                            break;
                        case "Ú": //107
                            convertResult += "U";
                            break;
                        case "Ù": //108
                            convertResult += "U";
                            break;
                        case "Ủ": //109
                            convertResult += "U";
                            break;
                        case "Ũ": //110
                            convertResult += "U";
                            break;
                        case "Ụ": //111
                            convertResult += "U";
                            break;
                        case "Ư": //112
                            convertResult += "U";
                            break;
                        case "Ứ": //113
                            convertResult += "U";
                            break;
                        case "Ừ": //114
                            convertResult += "U";
                            break;
                        case "Ử": //115
                            convertResult += "U";
                            break;
                        case "Ữ": //116
                            convertResult += "U";
                            break;
                        case "Ự": //117
                            convertResult += "U";
                            break;
                        case "Ý": //118
                            convertResult += "U";
                            break;
                        case "Ỳ": //119
                            convertResult += "Y";
                            break;
                        case "Ỷ": //120
                            convertResult += "Y";
                            break;
                        case "Ỹ": //121
                            convertResult += "Y";
                            break;
                        case "í": //122
                            convertResult += "i";
                            break;
                        case "ì": //123
                            convertResult += "i";
                            break;
                        case "ỉ": //124
                            convertResult += "i";
                            break;
                        case "ĩ": //125
                            convertResult += "i";
                            break;
                        case "ị": //126
                            convertResult += "i";
                            break;
                        case "Ỵ": //127
                            convertResult += "Y";
                            break;
                        case "Í": //128
                            convertResult += "I";
                            break;
                        case "Ì": //129
                            convertResult += "I";
                            break;
                        case "Ỉ": //130
                            convertResult += "I";
                            break;
                        case "Ĩ": //131
                            convertResult += "I";
                            break;
                        case "Ị": //132
                            convertResult += "I";
                            break;
                        case "Đ": //133
                            convertResult += "D";
                            break;
                        case "đ": //134
                            convertResult += "d";
                            break;
                        default:
                            convertResult += temp;
                            break;
                    }
                }

                return convertResult;
            }
            #endregion

            #region VNI

            else if (typeConvert == 2)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Pos", typeof(int));
                dt.Columns.Add("Source", typeof(string));
                dt.Columns.Add("Convert", typeof(string));
                //134 row
                dt.Rows.Add(1, "aù", "a");
                dt.Rows.Add(2, "aø", "a");
                dt.Rows.Add(3, "aû", "a");
                dt.Rows.Add(4, "aõ", "a");
                dt.Rows.Add(5, "aï", "a");
                dt.Rows.Add(6, "aê", "a");
                dt.Rows.Add(7, "aé", "a");
                dt.Rows.Add(8, "aè", "a");
                dt.Rows.Add(9, "aú", "a");
                dt.Rows.Add(10, "aü", "a");
                dt.Rows.Add(11, "aë", "a");
                dt.Rows.Add(12, "aâ", "a");
                dt.Rows.Add(13, "aá", "a");
                dt.Rows.Add(14, "aà", "a");
                dt.Rows.Add(15, "aå", "a");
                dt.Rows.Add(16, "aã", "a");
                dt.Rows.Add(17, "aä", "a");
                dt.Rows.Add(18, "eù", "e");
                dt.Rows.Add(19, "eø", "e");
                dt.Rows.Add(20, "eû", "e");
                dt.Rows.Add(21, "eõ", "e");
                dt.Rows.Add(22, "eï", "e");
                dt.Rows.Add(23, "eâ", "e");
                dt.Rows.Add(24, "eá", "e");
                dt.Rows.Add(25, "eà", "e");
                dt.Rows.Add(26, "eå", "e");
                dt.Rows.Add(27, "eã", "e");
                dt.Rows.Add(28, "eä", "e");
                dt.Rows.Add(29, "où", "o");
                dt.Rows.Add(30, "oø", "o");
                dt.Rows.Add(31, "oû", "o");
                dt.Rows.Add(32, "oõ", "o");
                dt.Rows.Add(33, "oï", "o");
                dt.Rows.Add(34, "oâ", "o");
                dt.Rows.Add(35, "oá", "o");
                dt.Rows.Add(36, "oà", "o");
                dt.Rows.Add(37, "oå", "o");
                dt.Rows.Add(38, "oã", "o");
                dt.Rows.Add(39, "oä", "o");
                dt.Rows.Add(40, "ô", "o");
                dt.Rows.Add(41, "ôù", "o");
                dt.Rows.Add(42, "ôø", "o");
                dt.Rows.Add(43, "ôû", "o");
                dt.Rows.Add(44, "ôõ", "o");
                dt.Rows.Add(45, "ôï", "o");
                dt.Rows.Add(46, "uù", "u");
                dt.Rows.Add(47, "uø", "u");
                dt.Rows.Add(48, "uû", "u");
                dt.Rows.Add(49, "uõ", "u");
                dt.Rows.Add(50, "uï", "u");
                dt.Rows.Add(51, "ö", "u");
                dt.Rows.Add(52, "öù", "u");
                dt.Rows.Add(53, "öø", "u");
                dt.Rows.Add(54, "öû", "u");
                dt.Rows.Add(55, "öõ", "u");
                dt.Rows.Add(56, "öï", "u");
                dt.Rows.Add(57, "yù", "y");
                dt.Rows.Add(58, "yø", "y");
                dt.Rows.Add(59, "yû", "y");
                dt.Rows.Add(60, "yõ", "y");
                dt.Rows.Add(61, "î", "y");
                dt.Rows.Add(62, "AÙ", "A");
                dt.Rows.Add(63, "AØ", "A");
                dt.Rows.Add(64, "AÛ", "A");
                dt.Rows.Add(65, "AÕ", "A");
                dt.Rows.Add(66, "AÏ", "A");
                dt.Rows.Add(67, "AÊ", "A");
                dt.Rows.Add(68, "AÉ", "A");
                dt.Rows.Add(69, "AÈ", "A");
                dt.Rows.Add(70, "AÚ", "A");
                dt.Rows.Add(71, "AÜ", "A");
                dt.Rows.Add(72, "AË", "A");
                dt.Rows.Add(73, "AÂ", "A");
                dt.Rows.Add(74, "AÁ", "A");
                dt.Rows.Add(75, "AÀ", "A");
                dt.Rows.Add(76, "AÅ", "A");
                dt.Rows.Add(77, "AÃ", "A");
                dt.Rows.Add(78, "AÄ", "A");
                dt.Rows.Add(79, "EÙ", "E");
                dt.Rows.Add(80, "EØ", "E");
                dt.Rows.Add(81, "EÛ", "E");
                dt.Rows.Add(82, "EÕ", "E");
                dt.Rows.Add(83, "EÏ", "E");
                dt.Rows.Add(84, "EÂ", "E");
                dt.Rows.Add(85, "EÁ", "E");
                dt.Rows.Add(86, "EÀ", "E");
                dt.Rows.Add(87, "EÅ", "E");
                dt.Rows.Add(88, "EÃ", "E");
                dt.Rows.Add(89, "EÄ", "E");
                dt.Rows.Add(90, "OÙ", "O");
                dt.Rows.Add(91, "OØ", "O");
                dt.Rows.Add(92, "OÛ", "O");
                dt.Rows.Add(93, "OÕ", "O");
                dt.Rows.Add(94, "OÏ", "O");
                dt.Rows.Add(95, "OÂ", "O");
                dt.Rows.Add(96, "OÁ", "O");
                dt.Rows.Add(97, "OÀ", "O");
                dt.Rows.Add(98, "OÅ", "O");
                dt.Rows.Add(99, "OÃ", "O");
                dt.Rows.Add(100, "OÄ", "O");
                dt.Rows.Add(101, "Ô", "O");
                dt.Rows.Add(102, "ÔÙ", "O");
                dt.Rows.Add(103, "ÔØ", "O");
                dt.Rows.Add(104, "ÔÛ", "O");
                dt.Rows.Add(105, "ÔÕ", "O");
                dt.Rows.Add(106, "ÔÏ", "O");
                dt.Rows.Add(107, "UÙ", "U");
                dt.Rows.Add(108, "UØ", "U");
                dt.Rows.Add(109, "UÛ", "U");
                dt.Rows.Add(110, "UÕ", "U");
                dt.Rows.Add(111, "UÏ", "U");
                dt.Rows.Add(112, "Ö", "U");
                dt.Rows.Add(113, "ÖÙ", "U");
                dt.Rows.Add(114, "ÖØ", "U");
                dt.Rows.Add(115, "ÖÛ", "U");
                dt.Rows.Add(116, "ÖÕ", "U");
                dt.Rows.Add(117, "ÖÏ", "U");
                dt.Rows.Add(118, "YÙ", "Y");
                dt.Rows.Add(119, "YØ", "Y");
                dt.Rows.Add(120, "YÛ", "Y");
                dt.Rows.Add(121, "YÕ", "Y");
                dt.Rows.Add(122, "í", "i");
                dt.Rows.Add(123, "ì", "i");
                dt.Rows.Add(124, "æ", "i");
                dt.Rows.Add(125, "ó", "i");
                dt.Rows.Add(126, "ò", "i");
                dt.Rows.Add(127, "Î", "Y");
                dt.Rows.Add(128, "Í", "I");
                dt.Rows.Add(129, "Ì", "I");
                dt.Rows.Add(130, "Æ", "I");
                dt.Rows.Add(131, "Ó", "I");
                dt.Rows.Add(132, "Ò", "I");
                dt.Rows.Add(133, "Ñ", "D");
                dt.Rows.Add(134, "ñ", "d");

                string sourceTemp = source;
                string _Char = "";
                int pos = 0;

                do
                {
                    if (sourceTemp.Length >= 2)
                    {
                        _Char = Strings.Mid(sourceTemp, 1, 2);
                        pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                pos = i;
                                break;
                            }
                        }

                        if (pos > 0)
                        {
                            convertResult += dt.Rows[pos - 1][2].ToString();
                            sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 2);
                        }
                        else
                        {
                            _Char = Strings.Mid(sourceTemp, 1, 1);
                            pos = 0;
                            for (int i = 1; i <= 134; i++)
                            {
                                if (_Char == dt.Rows[i - 1][1].ToString())
                                {
                                    pos = i;
                                    break;
                                }
                            }
                            if (pos > 0)
                            {
                                convertResult += dt.Rows[pos - 1][2].ToString();
                                sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                            }
                            else
                            {
                                _Char = Strings.Mid(sourceTemp, 1, 1);
                                convertResult += _Char;
                                sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                            }
                        }

                    }
                    else
                    {
                        _Char = Strings.Mid(sourceTemp, 1, 1);
                        pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                pos = i;
                                break;
                            }
                        }
                        if (pos > 0)
                        {
                            convertResult += dt.Rows[pos - 1][2].ToString();
                            sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                        }
                        else
                        {
                            _Char = Strings.Mid(sourceTemp, 1, 1);
                            convertResult += _Char;
                            sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                        }
                    }

                } while (sourceTemp.Length > 0);

                return convertResult;

            }
            #endregion

            #region ABC

            else if (typeConvert == 3)
            {
                for (int i = 1; i <= source.Length; i++)
                {
                    temp = Strings.Mid(source, i, 1);
                    switch (temp)
                    {
                        case "¸": //1
                            convertResult += "a";
                            break;
                        case "µ": //2
                            convertResult += "a";
                            break;
                        case "¶": //3
                            convertResult += "a";
                            break;
                        case "·": //4
                            convertResult += "a";
                            break;
                        case "¹": //5
                            convertResult += "a";
                            break;
                        case "¨": //6
                            convertResult += "a";
                            break;
                        case "¾": //7
                            convertResult += "a";
                            break;
                        case "»": //8
                            convertResult += "a";
                            break;
                        case "¼": //9
                            convertResult += "a";
                            break;
                        case "½": //10
                            convertResult += "a";
                            break;
                        case "Æ": //11
                            convertResult += "a";
                            break;
                        case "©": //12
                            convertResult += "a";
                            break;
                        case "Ê": //13
                            convertResult += "a";
                            break;
                        case "Ç": //14
                            convertResult += "a";
                            break;
                        case "È": //15
                            convertResult += "a";
                            break;
                        case "É": //16
                            convertResult += "a";
                            break;
                        case "Ë": //17
                            convertResult += "a";
                            break;
                        case "Ð": //18
                            convertResult += "e";
                            break;
                        case "Ì": //19
                            convertResult += "e";
                            break;
                        case "Î": //20
                            convertResult += "e";
                            break;
                        case "Ï": //21
                            convertResult += "e";
                            break;
                        case "Ñ": //22
                            convertResult += "e";
                            break;
                        case "ª": //23
                            convertResult += "e";
                            break;
                        case "Õ": //24
                            convertResult += "e";
                            break;
                        case "Ò": //25
                            convertResult += "e";
                            break;
                        case "Ó": //26
                            convertResult += "e";
                            break;
                        case "Ô": //27
                            convertResult += "e";
                            break;
                        case "Ö": //28
                            convertResult += "e";
                            break;
                        case "ã": //29
                            convertResult += "o";
                            break;
                        case "ß": //30
                            convertResult += "o";
                            break;
                        case "á": //31
                            convertResult += "o";
                            break;
                        case "â": //32
                            convertResult += "o";
                            break;
                        case "ä": //33
                            convertResult += "o";
                            break;
                        case "«": //34
                            convertResult += "o";
                            break;
                        case "è": //35
                            convertResult += "o";
                            break;
                        case "å": //36
                            convertResult += "o";
                            break;
                        case "æ": //37
                            convertResult += "o";
                            break;
                        case "ç": //38
                            convertResult += "o";
                            break;
                        case "é": //39
                            convertResult += "o";
                            break;
                        case "¬": //40
                            convertResult += "o";
                            break;
                        case "í": //41
                            convertResult += "o";
                            break;
                        case "ê": //42
                            convertResult += "o";
                            break;
                        case "ë": //43
                            convertResult += "o";
                            break;
                        case "ì": //44
                            convertResult += "o";
                            break;
                        case "î": //45
                            convertResult += "o";
                            break;
                        case "ó": //46
                            convertResult += "u";
                            break;
                        case "ï": //47
                            convertResult += "u";
                            break;
                        case "ñ": //48
                            convertResult += "u";
                            break;
                        case "ò": //49
                            convertResult += "u";
                            break;
                        case "ô": //50
                            convertResult += "u";
                            break;
                        case "­": //51
                            convertResult += "u";
                            break;
                        case "ø": //52
                            convertResult += "u";
                            break;
                        case "õ": //53
                            convertResult += "u";
                            break;
                        case "ö": //54
                            convertResult += "u";
                            break;
                        case "÷": //55
                            convertResult += "u";
                            break;
                        case "ù": //56
                            convertResult += "u";
                            break;
                        case "ý": //57
                            convertResult += "y";
                            break;
                        case "ú": //58
                            convertResult += "y";
                            break;
                        case "û": //59
                            convertResult += "y";
                            break;
                        case "ü": //60
                            convertResult += "y";
                            break;
                        case "þ": //61
                            convertResult += "y";
                            break;
                        case "¡": //67
                            convertResult += "A";
                            break;
                        case "¢": //73
                            convertResult += "A";
                            break;
                        case "£": //84
                            convertResult += "E";
                            break;
                        case "¤": //95
                            convertResult += "O";
                            break;
                        case "¥": //101
                            convertResult += "O";
                            break;
                        case "Ý": //122
                            convertResult += "i";
                            break;
                        case "×": //123
                            convertResult += "i";
                            break;
                        case "Ø": //124
                            convertResult += "i";
                            break;
                        case "Ü": //125
                            convertResult += "i";
                            break;
                        case "Þ": //126
                            convertResult += "i";
                            break;
                        case "§": //133
                            convertResult += "D";
                            break;
                        case "®": //134
                            convertResult += "d";
                            break;
                        default:
                            convertResult += temp;
                            break;
                    }
                }
                return convertResult;
            }
            #endregion

            else
            {
                return "Wrong type !";
            }
        }

        /// <summary>
        /// _TypeCOnvert=1 (Convert from UNI), _TypeCOnvert=2 (Convert from VNI), _TypeCOnvert=3 (Convert from ABC)
        /// _outputType=1 (Convert to UNI), _outputType=2 (Convert to VNI), _outputType=3 (Convert to ABC)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="typeConvert"></param>
        /// <param name="outputType"></param>
        /// <returns></returns>
        public static string ConvertStringText(string source, int typeConvert, int outputType)
        {
            string convertResult = "";
            string temp = "";

            #region UNI

            if (typeConvert == 1)
            {
                for (int i = 1; i <= source.Length; i++)
                {
                    temp = Strings.Mid(source, i, 1);
                    switch (temp)
                    {
                        case "á": //1
                            convertResult += outputType == 2 ? "aù" : "¸";
                            break;
                        case "à": //2
                            convertResult += outputType == 2 ? "aø" : "µ";
                            break;
                        case "ả": //3
                            convertResult += outputType == 2 ? "aû" : "¶";
                            break;
                        case "ã": //4
                            convertResult += outputType == 2 ? "aõ" : "·";
                            break;
                        case "ạ": //5
                            convertResult += outputType == 2 ? "aï" : "¹";
                            break;
                        case "ă": //6
                            convertResult += outputType == 2 ? "aê" : "¨";
                            break;
                        case "ắ": //7
                            convertResult += outputType == 2 ? "aé" : "¾";
                            break;
                        case "ằ": //8
                            convertResult += outputType == 2 ? "aè" : "»";
                            break;
                        case "ẳ": //9
                            convertResult += outputType == 2 ? "aú" : "¼";
                            break;
                        case "ẵ": //10
                            convertResult += outputType == 2 ? "aü" : "½";
                            break;
                        case "ặ": //11
                            convertResult += outputType == 2 ? "aë" : "Æ";
                            break;
                        case "â": //12
                            convertResult += outputType == 2 ? "aâ" : "©";
                            break;
                        case "ấ": //13
                            convertResult += outputType == 2 ? "aá" : "Ê";
                            break;
                        case "ầ": //14
                            convertResult += outputType == 2 ? "aà" : "Ç";
                            break;
                        case "ẩ": //15
                            convertResult += outputType == 2 ? "aû" : "È";
                            break;
                        case "ẫ": //16
                            convertResult += outputType == 2 ? "aã" : "É";
                            break;
                        case "ậ": //17
                            convertResult += outputType == 2 ? "aä" : "Ë";
                            break;
                        case "é": //18
                            convertResult += outputType == 2 ? "eù" : "Ð";
                            break;
                        case "è": //19
                            convertResult += outputType == 2 ? "eø" : "Ì";
                            break;
                        case "ẻ": //20
                            convertResult += outputType == 2 ? "eû" : "Î";
                            break;
                        case "ẽ": //21
                            convertResult += outputType == 2 ? "eõ" : "Ï";
                            break;
                        case "ẹ": //22
                            convertResult += outputType == 2 ? "eï" : "Ñ";
                            break;
                        case "ê": //23
                            convertResult += outputType == 2 ? "eâ" : "ª";
                            break;
                        case "ế": //24
                            convertResult += outputType == 2 ? "eá" : "Õ";
                            break;
                        case "ề": //25
                            convertResult += outputType == 2 ? "eà" : "Ò";
                            break;
                        case "ể": //26
                            convertResult += outputType == 2 ? "eå" : "Ó";
                            break;
                        case "ễ": //27
                            convertResult += outputType == 2 ? "eã" : "Ô";
                            break;
                        case "ệ": //28
                            convertResult += outputType == 2 ? "eä" : "Ö";
                            break;
                        case "ó": //29
                            convertResult += outputType == 2 ? "où" : "ã";
                            break;
                        case "ò": //30
                            convertResult += outputType == 2 ? "oø" : "ß";
                            break;
                        case "ỏ": //31
                            convertResult += outputType == 2 ? "oû" : "á";
                            break;
                        case "õ": //32
                            convertResult += outputType == 2 ? "oõ" : "â";
                            break;
                        case "ọ": //33
                            convertResult += outputType == 2 ? "oï" : "ä";
                            break;
                        case "ô": //34
                            convertResult += outputType == 2 ? "oâ" : "«";
                            break;
                        case "ố": //35
                            convertResult += outputType == 2 ? "oá" : "è";
                            break;
                        case "ồ": //36
                            convertResult += outputType == 2 ? "oà" : "å";
                            break;
                        case "ổ": //37
                            convertResult += outputType == 2 ? "oå" : "æ";
                            break;
                        case "ỗ": //38
                            convertResult += outputType == 2 ? "oã" : "ç";
                            break;
                        case "ộ": //39
                            convertResult += outputType == 2 ? "oä" : "é";
                            break;
                        case "ơ": //40
                            convertResult += outputType == 2 ? "ô" : "¬";
                            break;
                        case "ớ": //41
                            convertResult += outputType == 2 ? "ôù" : "í";
                            break;
                        case "ờ": //42
                            convertResult += outputType == 2 ? "ôø" : "ê";
                            break;
                        case "ở": //43
                            convertResult += outputType == 2 ? "ôû" : "ë";
                            break;
                        case "ỡ": //44
                            convertResult += outputType == 2 ? "ôõ" : "ì";
                            break;
                        case "ợ": //45
                            convertResult += outputType == 2 ? "ôï" : "î";
                            break;
                        case "ú": //46
                            convertResult += outputType == 2 ? "uù" : "ó";
                            break;
                        case "ù": //47
                            convertResult += outputType == 2 ? "uø" : "ï";
                            break;
                        case "ủ": //48
                            convertResult += outputType == 2 ? "uû" : "ñ";
                            break;
                        case "ũ": //49
                            convertResult += outputType == 2 ? "uõ" : "ò";
                            break;
                        case "ụ": //50
                            convertResult += outputType == 2 ? "uõ" : "ô";
                            break;
                        case "ư": //51
                            convertResult += outputType == 2 ? "ö" : "­";
                            break;
                        case "ứ": //52
                            convertResult += outputType == 2 ? "uù" : "ø";
                            break;
                        case "ừ": //53
                            convertResult += outputType == 2 ? "öø" : "õ";
                            break;
                        case "ử": //54
                            convertResult += outputType == 2 ? "uû" : "ö";
                            break;
                        case "ữ": //55
                            convertResult += outputType == 2 ? "öõ" : "÷";
                            break;
                        case "ự": //56
                            convertResult += outputType == 2 ? "öï" : "ù";
                            break;
                        case "ý": //57
                            convertResult += outputType == 2 ? "yù" : "ý";
                            break;
                        case "ỳ": //58
                            convertResult += outputType == 2 ? "yø" : "ú";
                            break;
                        case "ỷ": //59
                            convertResult += outputType == 2 ? "yû" : "û";
                            break;
                        case "ỹ": //60
                            convertResult += outputType == 2 ? "yõ" : "ü";
                            break;
                        case "ỵ": //61
                            convertResult += outputType == 2 ? "î" : "y";
                            break;
                        case "Á": //62
                            convertResult += outputType == 2 ? "AÙ" : "A1";
                            break;
                        case "À": //63
                            convertResult += outputType == 2 ? "AØ" : "A2";
                            break;
                        case "Ả": //64
                            convertResult += outputType == 2 ? "AÛ" : "A3";
                            break;
                        case "Ã": //65
                            convertResult += outputType == 2 ? "AÕ" : "A4";
                            break;
                        case "Ạ": //66
                            convertResult += outputType == 2 ? "AÏ" : "A5";
                            break;
                        case "Ă": //67
                            convertResult += outputType == 2 ? "AÊ" : "¡"; // 
                            break;
                        case "Ắ": //68
                            convertResult += outputType == 2 ? "AÉ" : "¡1";
                            break;
                        case "Ằ": //69
                            convertResult += outputType == 2 ? "AÈ" : "¡2";
                            break;
                        case "Ẳ": //70
                            convertResult += outputType == 2 ? "AÚ" : "¡3";
                            break;
                        case "Ẵ": //71
                            convertResult += outputType == 2 ? "AÜ" : "¡4";
                            break;
                        case "Ặ": //72
                            convertResult += outputType == 2 ? "AË" : "¡5";
                            break;
                        case "Â": //73
                            convertResult += outputType == 2 ? "AÂ" : "¢";
                            break;
                        case "Ấ": //74
                            convertResult += outputType == 2 ? "AÁ" : "¢1";
                            break;
                        case "Ầ": //75
                            convertResult += outputType == 2 ? "AÀ" : "¢2";
                            break;
                        case "Ẩ": //76
                            convertResult += outputType == 2 ? "AÅ" : "¢3";
                            break;
                        case "Ẫ": //77
                            convertResult += outputType == 2 ? "AÃ" : "¢4";
                            break;
                        case "Ậ": //78
                            convertResult += outputType == 2 ? "AÄ" : "¢5";
                            break;
                        case "É": //79
                            convertResult += outputType == 2 ? "EÙ" : "E1";
                            break;
                        case "È": //80
                            convertResult += outputType == 2 ? "EØ" : "E2";
                            break;
                        case "Ẻ": //81
                            convertResult += outputType == 2 ? "EÛ" : "E3";
                            break;
                        case "Ẽ": //82
                            convertResult += outputType == 2 ? "EÕ" : "E4";
                            break;
                        case "Ẹ": //83
                            convertResult += outputType == 2 ? "EÏ" : "E5";
                            break;
                        case "Ê": //84
                            convertResult += outputType == 2 ? "EÂ" : "£";
                            break;
                        case "Ế": //85
                            convertResult += outputType == 2 ? "EÁ" : "£1";
                            break;
                        case "Ề": //86
                            convertResult += outputType == 2 ? "EÀ" : "£2";
                            break;
                        case "Ể": //87
                            convertResult += outputType == 2 ? "EÅ" : "£3";
                            break;
                        case "Ễ": //88
                            convertResult += outputType == 2 ? "EÃ" : "£4";
                            break;
                        case "Ệ": //89
                            convertResult += outputType == 2 ? "EÄ" : "£5";
                            break;
                        case "Ó": //90
                            convertResult += outputType == 2 ? "OÙ" : "O1";
                            break;
                        case "Ò": //91
                            convertResult += outputType == 2 ? "OØ" : "O2";
                            break;
                        case "Ỏ": //92
                            convertResult += outputType == 2 ? "OÛ" : "O3";
                            break;
                        case "Õ": //93
                            convertResult += outputType == 2 ? "OÕ" : "O4";
                            break;
                        case "Ọ": //94
                            convertResult += outputType == 2 ? "OÏ" : "O5";
                            break;
                        case "Ô": //95
                            convertResult += outputType == 2 ? "OÂ" : "¤";
                            break;
                        case "Ố": //96
                            convertResult += outputType == 2 ? "OÁ" : "¤1";
                            break;
                        case "Ồ": //97
                            convertResult += outputType == 2 ? "OÀ" : "¤2";
                            break;
                        case "Ổ": //98
                            convertResult += outputType == 2 ? "OÅ" : "¤3";
                            break;
                        case "Ỗ": //99
                            convertResult += outputType == 2 ? "OÃ" : "¤4";
                            break;
                        case "Ộ": //100
                            convertResult += outputType == 2 ? "OÄ" : "¤5";
                            break;
                        case "Ơ": //101
                            convertResult += outputType == 2 ? "Ô" : "¥";
                            break;
                        case "Ớ": //102
                            convertResult += outputType == 2 ? "ÔÙ" : "¥1";
                            break;
                        case "Ờ": //103
                            convertResult += outputType == 2 ? "ÔØ" : "¥2";
                            break;
                        case "Ở": //104
                            convertResult += outputType == 2 ? "ÔÛ" : "¥3";
                            break;
                        case "Ỡ": //105
                            convertResult += outputType == 2 ? "ÔÕ" : "¥4";
                            break;
                        case "Ợ": //106
                            convertResult += outputType == 2 ? "ÔÏ" : "¥5";
                            break;
                        case "Ú": //107
                            convertResult += outputType == 2 ? "UÙ" : "U1";
                            break;
                        case "Ù": //108
                            convertResult += outputType == 2 ? "UØ" : "U2";
                            break;
                        case "Ủ": //109
                            convertResult += outputType == 2 ? "UÛ" : "U3";
                            break;
                        case "Ũ": //110
                            convertResult += outputType == 2 ? "UÕ" : "U4";
                            break;
                        case "Ụ": //111
                            convertResult += outputType == 2 ? "UÏ" : "U5";
                            break;
                        case "Ư": //112
                            convertResult += outputType == 2 ? "Ö" : "¦";
                            break;
                        case "Ứ": //113
                            convertResult += outputType == 2 ? "UÙ" : "¦1";
                            break;
                        case "Ừ": //114
                            convertResult += outputType == 2 ? "ÖØ" : "¦2";
                            break;
                        case "Ử": //115
                            convertResult += outputType == 2 ? "UÛ" : "¦3";
                            break;
                        case "Ữ": //116
                            convertResult += outputType == 2 ? "UÕ" : "¦4";
                            break;
                        case "Ự": //117
                            convertResult += outputType == 2 ? "ÖÏ" : "¦5";
                            break;
                        case "Ý": //118
                            convertResult += outputType == 2 ? "YÙ" : "Y1";
                            break;
                        case "Ỳ": //119
                            convertResult += outputType == 2 ? "YØ" : "Y2";
                            break;
                        case "Ỷ": //120
                            convertResult += outputType == 2 ? "YÛ" : "Y3";
                            break;
                        case "Ỹ": //121
                            convertResult += outputType == 2 ? "YÕ" : "Y4";
                            break;
                        case "í": //122
                            convertResult += outputType == 2 ? "í" : "Ý";
                            break;
                        case "ì": //123
                            convertResult += outputType == 2 ? "ì" : "×";
                            break;
                        case "ỉ": //124
                            convertResult += outputType == 2 ? "æ" : "Ø";
                            break;
                        case "ĩ": //125
                            convertResult += outputType == 2 ? "ó" : "Ü";
                            break;
                        case "ị": //126
                            convertResult += outputType == 2 ? "ò" : "Þ";
                            break;
                        case "Ỵ": //127
                            convertResult += outputType == 2 ? "Î" : "Y5";
                            break;
                        case "Í": //128
                            convertResult += outputType == 2 ? "Í" : "I1";
                            break;
                        case "Ì": //129
                            convertResult += outputType == 2 ? "Ì" : "I2";
                            break;
                        case "Ỉ": //130
                            convertResult += outputType == 2 ? "Æ" : "I3";
                            break;
                        case "Ĩ": //131
                            convertResult += outputType == 2 ? "Ó" : "I4";
                            break;
                        case "Ị": //132
                            convertResult += outputType == 2 ? "Ò" : "I5";
                            break;
                        case "Đ": //133
                            convertResult += outputType == 2 ? "Ñ" : "§";
                            break;
                        case "đ": //134
                            convertResult += outputType == 2 ? "ñ" : "®";
                            break;
                        default:
                            convertResult += temp;
                            break;
                    }
                }

                return convertResult;
            }
            #endregion

            #region VNI

            else if (typeConvert == 2)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Pos", typeof(int));
                dt.Columns.Add("Source", typeof(string));
                dt.Columns.Add("Convert", typeof(string));
                dt.Columns.Add("ConvertABC", typeof(string));
                //134 row
                dt.Rows.Add(1, "aù", "á", "¸");
                dt.Rows.Add(2, "aø", "à", "µ");
                dt.Rows.Add(3, "aû", "ả", "¶");
                dt.Rows.Add(4, "aõ", "ã", "•");
                dt.Rows.Add(5, "aï", "ạ", "¹");
                dt.Rows.Add(6, "aê", "ă", "¨");
                dt.Rows.Add(7, "aé", "ắ", "¾");
                dt.Rows.Add(8, "aè", "ằ", "»");
                dt.Rows.Add(9, "aú", "ẳ", "¼");
                dt.Rows.Add(10, "aü", "ẵ", "½");
                dt.Rows.Add(11, "aë", "ặ", "Æ");
                dt.Rows.Add(12, "aâ", "â", "©");
                dt.Rows.Add(13, "aá", "ấ", "Ê");
                dt.Rows.Add(14, "aà", "ầ", "Ç");
                dt.Rows.Add(15, "aå", "ả", "È");
                dt.Rows.Add(16, "aã", "ẫ", "É");
                dt.Rows.Add(17, "aä", "ậ", "Ë");
                dt.Rows.Add(18, "eù", "é", "Ð");
                dt.Rows.Add(19, "eø", "è", "Ì");
                dt.Rows.Add(20, "eû", "ẻ", "Î");
                dt.Rows.Add(21, "eõ", "ẽ", "Ï");
                dt.Rows.Add(22, "eï", "ẹ", "Ñ");
                dt.Rows.Add(23, "eâ", "ê", "ª");
                dt.Rows.Add(24, "eá", "ế", "Õ");
                dt.Rows.Add(25, "eà", "ề", "Ò");
                dt.Rows.Add(26, "eå", "ể", "Ó");
                dt.Rows.Add(27, "eã", "ễ", "Ô");
                dt.Rows.Add(28, "eä", "ệ", "Ö");
                dt.Rows.Add(29, "où", "ó", "ã");
                dt.Rows.Add(30, "oø", "ò", "ß");
                dt.Rows.Add(31, "oû", "ỏ", "á");
                dt.Rows.Add(32, "oõ", "õ", "â");
                dt.Rows.Add(33, "oï", "ọ", "ä");
                dt.Rows.Add(34, "oâ", "ô", "«");
                dt.Rows.Add(35, "oá", "ố", "è");
                dt.Rows.Add(36, "oà", "ồ", "å");
                dt.Rows.Add(37, "oå", "ổ", "æ");
                dt.Rows.Add(38, "oã", "ỗ", "ç");
                dt.Rows.Add(39, "oä", "ộ", "é");
                dt.Rows.Add(40, "ô", "ơ", "¬");
                dt.Rows.Add(41, "ôù", "ớ", "í");
                dt.Rows.Add(42, "ôø", "ờ", "ê");
                dt.Rows.Add(43, "ôû", "ở", "ë");
                dt.Rows.Add(44, "ôõ", "ỡ", "ì");
                dt.Rows.Add(45, "ôï", "ợ", "î");
                dt.Rows.Add(46, "uù", "ú", "ó");
                dt.Rows.Add(47, "uø", "ù", "ï");
                dt.Rows.Add(48, "uû", "ủ", "ñ");
                dt.Rows.Add(49, "uõ", "ũ", "ò");
                dt.Rows.Add(50, "uï", "ụ", "ô");
                dt.Rows.Add(51, "ö", "ư", "­");
                dt.Rows.Add(52, "öù", "ứ", "ø");
                dt.Rows.Add(53, "öø", "ừ", "õ");
                dt.Rows.Add(54, "öû", "ử", "ö");
                dt.Rows.Add(55, "öõ", "ữ", "÷");
                dt.Rows.Add(56, "öï", "ự", "ù");
                dt.Rows.Add(57, "yù", "ý", "ý");
                dt.Rows.Add(58, "yø", "ỳ", "ú");
                dt.Rows.Add(59, "yû", "ỷ", "û");
                dt.Rows.Add(60, "yõ", "ỹ", "ü");
                dt.Rows.Add(61, "î", "ỵ", "þ");
                dt.Rows.Add(62, "AÙ", "Á", "A1");
                dt.Rows.Add(63, "AØ", "À", "A2");
                dt.Rows.Add(64, "AÛ", "Ả", "A3");
                dt.Rows.Add(65, "AÕ", "Ã", "A4");
                dt.Rows.Add(66, "AÏ", "Ạ", "A5");
                dt.Rows.Add(67, "AÊ", "Ă", "¡");
                dt.Rows.Add(68, "AÉ", "Ắ", "¡1");
                dt.Rows.Add(69, "AÈ", "Ằ", "¡2");
                dt.Rows.Add(70, "AÚ", "Ẳ", "¡3");
                dt.Rows.Add(71, "AÜ", "Ẵ", "¡4");
                dt.Rows.Add(72, "AË", "Ă", "¡");
                dt.Rows.Add(73, "AÂ", "Â", "¢");
                dt.Rows.Add(74, "AÁ", "Ấ", "¢1");
                dt.Rows.Add(75, "AÀ", "Ầ", "¢2");
                dt.Rows.Add(76, "AÅ", "Ẩ", "¢3");
                dt.Rows.Add(77, "AÃ", "Ẫ", "¢4");
                dt.Rows.Add(78, "AÄ", "Â", "¢5");
                dt.Rows.Add(79, "EÙ", "É", "E1");
                dt.Rows.Add(80, "EØ", "È", "E2");
                dt.Rows.Add(81, "EÛ", "Ẻ", "E3");
                dt.Rows.Add(82, "EÕ", "Ẽ", "E4");
                dt.Rows.Add(83, "EÏ", "Ẹ", "E5");
                dt.Rows.Add(84, "EÂ", "Ê", "£");
                dt.Rows.Add(85, "EÁ", "Ế", "£1");
                dt.Rows.Add(86, "EÀ", "Ề", "£2");
                dt.Rows.Add(87, "EÅ", "Ể", "£3");
                dt.Rows.Add(88, "EÃ", "Ễ", "£4");
                dt.Rows.Add(89, "EÄ", "Ệ", "£5");
                dt.Rows.Add(90, "OÙ", "Ó", "O1");
                dt.Rows.Add(91, "OØ", "Ò", "O2");
                dt.Rows.Add(92, "OÛ", "Ỏ", "O3");
                dt.Rows.Add(93, "OÕ", "Õ", "O4");
                dt.Rows.Add(94, "OÏ", "Ọ", "O5");
                dt.Rows.Add(95, "OÂ", "Ô", "¥");
                dt.Rows.Add(96, "OÁ", "Ố", "¤1");
                dt.Rows.Add(97, "OÀ", "Ồ", "¤2");
                dt.Rows.Add(98, "OÅ", "Ổ", "¤3");
                dt.Rows.Add(99, "OÃ", "Ỗ", "¤4");
                dt.Rows.Add(100, "OÄ", "Ộ", "¤5");
                dt.Rows.Add(101, "Ô", "Ơ", "¥");
                dt.Rows.Add(102, "ÔÙ", "Ớ", "¥1");
                dt.Rows.Add(103, "ÔØ", "Ờ", "¥2");
                dt.Rows.Add(104, "ÔÛ", "Ở", "¥3");
                dt.Rows.Add(105, "ÔÕ", "Ỡ", "¥4");
                dt.Rows.Add(106, "ÔÏ", "Ợ", "¥5");
                dt.Rows.Add(107, "UÙ", "Ú", "U1");
                dt.Rows.Add(108, "UØ", "Ù", "U2");
                dt.Rows.Add(109, "UÛ", "Ủ", "U3");
                dt.Rows.Add(110, "UÕ", "Ũ", "U4");
                dt.Rows.Add(111, "UÏ", "Ụ", "U5");
                dt.Rows.Add(112, "Ö", "Ư", "¦");
                dt.Rows.Add(113, "ÖÙ", "Ứ", "¦1");
                dt.Rows.Add(114, "ÖØ", "Ừ", "¦2");
                dt.Rows.Add(115, "ÖÛ", "Ử", "¦3");
                dt.Rows.Add(116, "ÖÕ", "Ữ", "¦4");
                dt.Rows.Add(117, "ÖÏ", "Ự", "¦5");
                dt.Rows.Add(118, "YÙ", "Ý", "Y1");
                dt.Rows.Add(119, "YØ", "Ỳ", "Y2");
                dt.Rows.Add(120, "YÛ", "Ỷ", "Y3");
                dt.Rows.Add(121, "YÕ", "Ỹ", "Y4");
                dt.Rows.Add(122, "í", "í", "Ý");
                dt.Rows.Add(123, "ì", "ì", "×");
                dt.Rows.Add(124, "æ", "ỉ", "Ø");
                dt.Rows.Add(125, "ó", "ĩ", "Ü");
                dt.Rows.Add(126, "ò", "ị", "Þ");
                dt.Rows.Add(127, "Î", "Ỵ", "Y5");
                dt.Rows.Add(128, "Í", "Í", "I1");
                dt.Rows.Add(129, "Ì", "Ì", "I2");
                dt.Rows.Add(130, "Æ", "Ỉ", "I3");
                dt.Rows.Add(131, "Ó", "Ĩ", "I4");
                dt.Rows.Add(132, "Ò", "Ị", "I5");
                dt.Rows.Add(133, "Ñ", "Đ", "§");
                dt.Rows.Add(134, "ñ", "đ", "®");

                string sourceTemp = source;
                string _Char = "";
                int pos = 0;

                do
                {
                    if (sourceTemp.Length >= 2)
                    {
                        _Char = Strings.Mid(sourceTemp, 1, 2);
                        pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                pos = i;
                                break;
                            }
                        }

                        if (pos > 0)
                        {
                            convertResult += outputType == 1
                                ? dt.Rows[pos - 1][2].ToString()
                                : dt.Rows[pos - 1][3].ToString();
                            sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 2);
                        }
                        else
                        {
                            _Char = Strings.Mid(sourceTemp, 1, 1);
                            pos = 0;
                            for (int i = 1; i <= 134; i++)
                            {
                                if (_Char == dt.Rows[i - 1][1].ToString())
                                {
                                    pos = i;
                                    break;
                                }
                            }
                            if (pos > 0)
                            {
                                convertResult += outputType == 1
                                    ? dt.Rows[pos - 1][2].ToString()
                                    : dt.Rows[pos - 1][3].ToString();
                                sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                            }
                            else
                            {
                                _Char = Strings.Mid(sourceTemp, 1, 1);
                                convertResult += _Char;
                                sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                            }
                        }

                    }
                    else
                    {
                        _Char = Strings.Mid(sourceTemp, 1, 1);
                        pos = 0;
                        for (int i = 1; i <= 134; i++)
                        {
                            if (_Char == dt.Rows[i - 1][1].ToString())
                            {
                                pos = i;
                                break;
                            }
                        }
                        if (pos > 0)
                        {
                            convertResult += outputType == 1
                                ? dt.Rows[pos - 1][2].ToString()
                                : dt.Rows[pos - 1][3].ToString();
                            sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                        }
                        else
                        {
                            _Char = Strings.Mid(sourceTemp, 1, 1);
                            convertResult += _Char;
                            sourceTemp = Strings.Right(sourceTemp, sourceTemp.Length - 1);
                        }
                    }

                } while (sourceTemp.Length > 0);

                return convertResult;

            }
            #endregion

            #region ABC

            else if (typeConvert == 3)
            {
                for (int i = 1; i <= source.Length; i++)
                {
                    temp = Strings.Mid(source, i, 1);
                    switch (temp)
                    {
                        case "¸": //1
                            convertResult += outputType == 1 ? "á" : "aù";
                            break;
                        case "µ": //2
                            convertResult += outputType == 1 ? "à" : "aø";
                            break;
                        case "¶": //3
                            convertResult += outputType == 1 ? "ả" : "aû";
                            break;
                        case "•": //4
                            convertResult += outputType == 1 ? "ã" : "aõ";
                            break;
                        case "¹": //5
                            convertResult += outputType == 1 ? "ạ" : "aï";
                            break;
                        case "¨": //6
                            convertResult += outputType == 1 ? "ă" : "aê";
                            break;
                        case "¾": //7
                            convertResult += outputType == 1 ? "ắ" : "aé";
                            break;
                        case "»": //8
                            convertResult += outputType == 1 ? "ằ" : "aè";
                            break;
                        case "¼": //9
                            convertResult += outputType == 1 ? "ẳ" : "aú";
                            break;
                        case "½": //10
                            convertResult += outputType == 1 ? "ẵ" : "aü";
                            break;
                        case "Æ": //11
                            convertResult += outputType == 1 ? "ặ" : "aë";
                            break;
                        case "©": //12
                            convertResult += outputType == 1 ? "â" : "aâ";
                            break;
                        case "Ê": //13
                            convertResult += outputType == 1 ? "ấ" : "aá";
                            break;
                        case "Ç": //14
                            convertResult += outputType == 1 ? "ầ" : "aà";
                            break;
                        case "È": //15
                            convertResult += outputType == 1 ? "ẩ" : "aå";
                            break;
                        case "É": //16
                            convertResult += outputType == 1 ? "a" : "aã";
                            break;
                        case "Ë": //17
                            convertResult += outputType == 1 ? "ậ" : "aä";
                            break;
                        case "Ð": //18
                            convertResult += outputType == 1 ? "é" : "eù";
                            break;
                        case "Ì": //19
                            convertResult += outputType == 1 ? "è" : "eø";
                            break;
                        case "Î": //20
                            convertResult += outputType == 1 ? "ẻ" : "eû";
                            break;
                        case "Ï": //21
                            convertResult += outputType == 1 ? "ẽ" : "eõ";
                            break;
                        case "Ñ": //22
                            convertResult += outputType == 1 ? "ẹ" : "eï";
                            break;
                        case "ª": //23
                            convertResult += outputType == 1 ? "ê" : "eâ";
                            break;
                        case "Õ": //24
                            convertResult += outputType == 1 ? "ế" : "eá";
                            break;
                        case "Ò": //25
                            convertResult += outputType == 1 ? "ề" : "eà";
                            break;
                        case "Ó": //26
                            convertResult += outputType == 1 ? "ể" : "eå";
                            break;
                        case "Ô": //27
                            convertResult += outputType == 1 ? "ễ" : "eã";
                            break;
                        case "Ö": //28
                            convertResult += outputType == 1 ? "ệ" : "eä";
                            break;
                        case "ã": //29
                            convertResult += outputType == 1 ? "ó" : "où";
                            break;
                        case "ß": //30
                            convertResult += outputType == 1 ? "ò" : "oø";
                            break;
                        case "á": //31
                            convertResult += outputType == 1 ? "ỏ" : "oû";
                            break;
                        case "â": //32
                            convertResult += outputType == 1 ? "õ" : "oõ";
                            break;
                        case "ä": //33
                            convertResult += outputType == 1 ? "ọ" : "oï";
                            break;
                        case "«": //34
                            convertResult += outputType == 1 ? "ô" : "oâ";
                            break;
                        case "è": //35
                            convertResult += outputType == 1 ? "ố" : "oá";
                            break;
                        case "å": //36
                            convertResult += outputType == 1 ? "ồ" : "oà";
                            break;
                        case "æ": //37
                            convertResult += outputType == 1 ? "ổ" : "oå";
                            break;
                        case "ç": //38
                            convertResult += outputType == 1 ? "ỗ" : "oã";
                            break;
                        case "é": //39
                            convertResult += outputType == 1 ? "ộ" : "oä";
                            break;
                        case "¬": //40
                            convertResult += outputType == 1 ? "ơ" : "ô";
                            break;
                        case "í": //41
                            convertResult += outputType == 1 ? "ớ" : "ôù";
                            break;
                        case "ê": //42
                            convertResult += outputType == 1 ? "ờ" : "ôø";
                            break;
                        case "ë": //43
                            convertResult += outputType == 1 ? "ở" : "ôû";
                            break;
                        case "ì": //44
                            convertResult += outputType == 1 ? "ỡ" : "ôõ";
                            break;
                        case "î": //45
                            convertResult += outputType == 1 ? "ợ" : "ôï";
                            break;
                        case "ó": //46
                            convertResult += outputType == 1 ? "ú" : "uù";
                            break;
                        case "ï": //47
                            convertResult += outputType == 1 ? "ù" : "uø";
                            break;
                        case "ñ": //48
                            convertResult += outputType == 1 ? "ủ" : "uû";
                            break;
                        case "ò": //49
                            convertResult += outputType == 1 ? "ũ" : "uõ";
                            break;
                        case "ô": //50
                            convertResult += outputType == 1 ? "ụ" : "uï";
                            break;
                        case "­": //51
                            convertResult += outputType == 1 ? "ư" : "ö";
                            break;
                        case "ø": //52
                            convertResult += outputType == 1 ? "ứ" : "öù";
                            break;
                        case "õ": //53
                            convertResult += outputType == 1 ? "ừ" : "öø";
                            break;
                        case "ö": //54
                            convertResult += outputType == 1 ? "ử" : "ö";
                            break;
                        case "÷": //55
                            convertResult += outputType == 1 ? "ữ" : "öõ";
                            break;
                        case "ù": //56
                            convertResult += outputType == 1 ? "ự" : "öï";
                            break;
                        case "ý": //57
                            convertResult += outputType == 1 ? "ý" : "yù";
                            break;
                        case "ú": //58
                            convertResult += outputType == 1 ? "ỳ" : "yø";
                            break;
                        case "û": //59
                            convertResult += outputType == 1 ? "ỷ" : "yû";
                            break;
                        case "ü": //60
                            convertResult += outputType == 1 ? "ỹ" : "yõ";
                            break;
                        case "þ": //61
                            convertResult += outputType == 1 ? "ỵ" : "î";
                            break;
                        case "¡": //67
                            convertResult += outputType == 1 ? "Ă" : "AÊ";
                            break;
                        case "¢": //73
                            convertResult += outputType == 1 ? "Â" : "AÂ";
                            break;
                        case "£": //84
                            convertResult += outputType == 1 ? "Ê" : "EÂ";
                            break;
                        case "¤": //95
                            convertResult += outputType == 1 ? "Ô" : "OÂ";
                            break;
                        case "¥": //101
                            convertResult += outputType == 1 ? "O" : "Ô";
                            break;
                        case "Ý": //122
                            convertResult += outputType == 1 ? "í" : "í";
                            break;
                        case "×": //123
                            convertResult += outputType == 1 ? "ì" : "ì";
                            break;
                        case "Ø": //124
                            convertResult += outputType == 1 ? "ỉ" : "æ";
                            break;
                        case "Ü": //125
                            convertResult += outputType == 1 ? "ĩ" : "ó";
                            break;
                        case "Þ": //126
                            convertResult += outputType == 1 ? "ị" : "ò";
                            break;
                        case "§": //133
                            convertResult += outputType == 1 ? "Đ" : "Ñ";
                            break;
                        case "®": //134
                            convertResult += outputType == 1 ? "đ" : "ñ";
                            break;
                        default:
                            convertResult += temp;
                            break;
                    }
                }
                return convertResult;
            }
            #endregion

            else
            {
                return "Wrong type !";
            }
        }

        /// <summary>
        /// Lấy số thứ tự
        /// </summary>
        /// <param name="num">số tt cần chuyển</param>
        /// <param name="loai">1: ABC - 2: LA Mã</param>
        /// <returns></returns>
        public static string LayStt(int num, int loai)
        {
            if (loai == 1)
            {
                switch (num)
                {
                    case 1:
                        return "A";
                    case 2:
                        return "B";
                    case 3:
                        return "C";
                    case 4:
                        return "D";
                    case 5:
                        return "E";
                    case 6:
                        return "F";
                    case 7:
                        return "G";
                    case 8:
                        return "H";
                    case 9:
                        return "I";
                    case 10:
                        return "J";
                    case 11:
                        return "K";
                    case 12:
                        return "L";
                    case 13:
                        return "M";
                    case 14:
                        return "N";
                    case 15:
                        return "O";
                }
            }
            else if (loai == 2)
            {
                switch (num)
                {
                    case 1:
                        return "I";
                    case 2:
                        return "II";
                    case 3:
                        return "III";
                    case 4:
                        return "IV";
                    case 5:
                        return "V";
                    case 6:
                        return "VI";
                    case 7:
                        return "VII";
                    case 8:
                        return "VIII";
                    case 9:
                        return "IX";
                    case 10:
                        return "X";
                    case 11:
                        return "XI";
                    case 12:
                        return "XII";
                    case 13:
                        return "XIII";
                    case 14:
                        return "XIV";
                    case 15:
                        return "XV";
                }
            }
            return "";
        }
    }
    public class RegKeys
    {
        private string _userRoot;
        private string _subkey;
        private string _keyName;

        /// <summary>
        /// Đọc đường dẫn của Registry
        /// </summary>
        /// <param name="localUser0LocalMachine1">0: HKEY_CURRENT_USER, 1: HKEY_LOCAL_MACHINE </param>
        /// <param name="subKey">Đường dẫn cấp con</param>
        public RegKeys(int localUser0LocalMachine1, string subKey)
        {
            if (localUser0LocalMachine1 == 0)
            {
                _userRoot = "HKEY_CURRENT_USER";
            }
            else
            {
                _userRoot = "HKEY_LOCAL_MACHINE";
            }
            _subkey = subKey;
            _keyName = _userRoot + "\\" + _subkey;
        }

        /// <summary>
        /// Hàm ghi thông số lên registry
        /// </summary>
        /// <param name="valueName">Tên</param>
        /// <param name="value">Giá trị</param>
        public void WriteRegistry(string valueName, string value)
        {
            Registry.SetValue(_keyName, valueName, value, RegistryValueKind.String);
        }

        public void WirteRegistry_Dword(string valueName, int value)
        {
            Registry.SetValue(_keyName, valueName, unchecked((int)value), RegistryValueKind.DWord);
        }

        /// <summary>
        /// Hàm đọc thông số của registry
        /// </summary>
        /// <param name="valueName">string valueName</param>
        /// <returns>Trả về giá trị</returns>
        public string ReadRegistry(string valueName)
        {
            try
            {
                return Registry.GetValue(_keyName, valueName, string.Empty).ToString();
            }
            catch
            {
                return "";
            }
        }
    }
    public class LabResultService
    {
        public static string KiemTraThemKhoatrangChoTenLoaiMau(string giaTriTen)
        {
            var returnTen = giaTriTen.Trim().ToUpper();
            giaTriTen = Utilities.ChuyenTvKhongDau(returnTen);
            var giatrilen = Encoding.Default.GetByteCount(giaTriTen);
            if (giaTriTen.Equals("PHAN", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("DIEN DI", StringComparison.OrdinalIgnoreCase))
                giatrilen = 6;
            else if (giaTriTen.Equals("HEPARIN", StringComparison.OrdinalIgnoreCase)
                || giaTriTen.Equals("KHI MAU", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "  ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("SHPT", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "  ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("URINE", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + " ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            else if (giaTriTen.Equals("VI SINH", StringComparison.OrdinalIgnoreCase))
            {
                returnTen = returnTen + "    ";
                giatrilen = Encoding.Default.GetByteCount(returnTen);
            }
            if (giatrilen < 16)
            {
                if (giatrilen < 7)
                    returnTen += "\t\t";
                else
                    returnTen += "\t";
            }
            return returnTen;
        }
        public static bool KiemtraCapNhatGhiChu(string ghiChu, string idMayXn, string ketqua, string ghiChuCu, int idMayCu, string ketquaCu)
        {
            //Ghi chú không có sửa đổi thủ công
            if (ghiChu.Equals(ghiChuCu))
            {
                if (!idMayXn.Equals(idMayCu) || !ketquaCu.Equals(ketqua))
                    return true;
            }
            return false;
        }
        public static int SetColor(string strResult, string high, string low, string criteria)
        {
            var dLow = string.IsNullOrWhiteSpace(low) ? -1000000000 : (double.Parse(low));
            var dHigh = string.IsNullOrWhiteSpace(high) ? 1000000000 : (double.Parse(high));
            strResult = strResult.Trim();
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            if (!WorkingServices.IsNumeric(strResult))
            {
                if (!string.IsNullOrEmpty(criteria))
                {
                    if (Compare_Criteria(criteria, strResult, '|') == 1)
                        return 3;
                    else
                        return 1;
                }
                else
                {
                    var symbol = new List<string>()
                    {
                        "<=",
                        ">=",
                        "<",
                        ">",
                    };
                    var index = IndexOfSymbol(strResult, symbol);
                    if (index > -1)
                    {
                        //var _rs = strResult.Split(' ');
                        string leftChars = strResult.Substring(0, index).Trim();
                        string temResult = strResult.Substring(index).Trim();

                        if (WorkingServices.IsNumeric(temResult) && !string.IsNullOrEmpty(leftChars))
                        {
                            var resultNew = double.Parse(temResult);
                            //kiểm tra trường hợp 2 ký tự trước
                            if (leftChars.Equals("<="))
                            {
                                if (resultNew < dLow)
                                    return 2;
                                else
                                    return 1;
                            }
                            else if (leftChars.Equals(">="))
                            {
                                if (resultNew > dHigh)
                                    return 3;
                                else
                                    return 1;
                            }
                            else if (leftChars.Equals("<"))
                            {
                                if (resultNew <= dLow)
                                    return 2;
                                else
                                    return 1;
                            }
                            else if (leftChars.Equals(">"))
                            {
                                if (resultNew >= dHigh)
                                    return 3;
                                else
                                    return 1;
                            }
                        }
                        else
                            return 1;
                    }

                    return 1;
                }
            }

            var dResult = double.Parse(strResult);

            if (dResult < dLow)
            {
                return 2;
            }
            else if (dResult > dHigh)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
        private static int IndexOfSymbol(string value, List<string> symbol)
        {
            foreach (string needle in symbol)
            {
                if (value.Contains(needle))
                    return needle.Length;
            }
            return -1;
        }

        public static int Compare_Criteria(string orgrial, string beingCompare, char splitChar)
        {
            if (orgrial.Length > 0)
            {
                var arrayOrignal = orgrial.Split(splitChar);
                if (arrayOrignal.Length > 0)
                {
                    for (var i = 0; i < arrayOrignal.Length; i++)
                    {
                        if (arrayOrignal[i].Trim().Equals(beingCompare.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            return 1;
                        }
                    }
                    //trường hợp hết vòng lập mà có trong điều kiện so sánh thì kiểm tra truờng hợp định tính có ghép định lượng
                    for (var i = 0; i < arrayOrignal.Length; i++)
                    {
                        if (beingCompare.ToLower().Contains(arrayOrignal[i].Trim().ToLower()))
                        {
                            if ((arrayOrignal[i].Trim().ToLower().Equals("reactive") && beingCompare.ToLower().Contains("nonreactive")))
                                continue;
                            else
                                return 1;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            return 0;
        }
        public static Color MauKQ(int co, ref FontStyle fstyle)
        {
            //1: Bình thường; 2: Dưới ngưỡng dưới ; 3: Ngưỡng trên
            switch (co)
            {
                case 2:
                    fstyle = FontStyle.Bold;
                    return Color.Blue;

                case 3:
                    fstyle = FontStyle.Bold;
                    return Color.Red;

                default:
                    fstyle = FontStyle.Regular;
                    return Color.Black;
            }
        }
    }
    public static class WorkingServices
    {
        public static void CleanTemp()
        {
            Timer tm = new Timer();
            tm.Interval = 1500;
            tm.Tick += Tm_Tick;
            tm.Start();
        }
        private static void Tm_Tick(object sender, EventArgs e)
        {
            var tm = (Timer)sender;
            tm.Stop();
            string tempfolder = Path.GetTempPath();
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "/c del /s /q \"" + tempfolder + "\"";
            Process.Start(startInfo);
            tm.Dispose();
        }
        public static void CleanTemporaryFolders()
        {
            var tempFolder = Environment.ExpandEnvironmentVariables("%TEMP%");
            // var recent = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + "\\Recent";
            // var prefetch = Environment.ExpandEnvironmentVariables("%SYSTEMROOT%") + "\\Prefetch";
            EmptyFolderContents(tempFolder);
            //EmptyFolderContents(recent);
            //  EmptyFolderContents(prefetch);
        }
        public static int EmptyFolderContents(string folderName, int olderDay, TextBox txtMess)
        {
            var fileCount = 0;
            fileCount += DeleteFileWithDay(folderName, olderDay, txtMess);
            if (Directory.Exists(folderName))
            {
                foreach (var folder in Directory.GetDirectories(folderName))
                {
                    if (txtMess != null)
                        txtMess.Text = string.Format("Đang kiểm tra xóa thư mục: {0}", folder);
                    try
                    {
                        DeleteFileWithDay(folder, olderDay, txtMess);
                        var direcInfo = new DirectoryInfo(folder);
                        var datecreate = direcInfo.CreationTime;
                        if (datecreate < DateTime.Now.AddDays(-olderDay) && direcInfo.GetFiles().Count() == 0 && direcInfo.GetDirectories().Count() == 0)
                        {
                            Directory.Delete(folder);
                        }
                        else
                        {
                            fileCount += EmptyFolderContents(folder, olderDay, txtMess);
                        }
                    }
                    catch (Exception excep)
                    {
                        //System.Diagnostics.Debug.WriteLine(excep);
                    }
                }
                if (txtMess != null)
                    txtMess.Text = string.Format("Hoàn thành xóa {1} file log lúc: {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), fileCount);
            }
            return fileCount;
        }
        private static int DeleteFileWithDay(string folderName, int olderDay, TextBox txtMess)
        {
            int count = 0;
            if (Directory.Exists(folderName))
            {
                foreach (var file in Directory.GetFiles(folderName))
                {
                    try
                    {
                        if (txtMess != null)
                            txtMess.Text = string.Format("Đang kiểm tra xóa file: {0}", file);
                        var fileInfo = new FileInfo(file);
                        var datecreate = fileInfo.CreationTime;
                        if (datecreate < DateTime.Now.AddDays(-olderDay) && (fileInfo.Extension.Equals(".txt", StringComparison.OrdinalIgnoreCase) || fileInfo.Extension.Equals(".log", StringComparison.OrdinalIgnoreCase)))
                        {
                            if (txtMess != null)
                                txtMess.Text = string.Format("Xóa file: {0}", file);
                            File.Delete(file);
                            count++;
                        }
                    }
                    catch (Exception excep)
                    {
                        // System.Diagnostics.Debug.WriteLine(excep);
                    }
                }
            }
            return count;
        }
        private static void EmptyFolderContents(string folderName)
        {
            foreach (var folder in Directory.GetDirectories(folderName))
            {
                try
                {
                    Directory.Delete(folder, true);
                }
                catch (Exception excep)
                {
                    //System.Diagnostics.Debug.WriteLine(excep);
                }
            }
            foreach (var file in Directory.GetFiles(folderName))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception excep)
                {
                    // System.Diagnostics.Debug.WriteLine(excep);
                }
            }
        }
        public static string GetUpdate_Differences(object objNew, object objOld)
        {
            PropertyInfo[] fiNew = objNew.GetType().GetProperties();
            PropertyInfo[] fiOld = objOld.GetType().GetProperties();
            var resultString = string.Empty;
            foreach (PropertyInfo f in fiNew)
            {
                var caption = f.Name;
                if (fiNew.GetType().GetProperty(f.Name) != null)
                {
                    caption += "(" + ((DescriptionAttribute)f.GetCustomAttributes(false)[0]).Description + ")";
                }
                var newVal = objNew.GetType().GetProperty(f.Name).GetValue(objNew, null);
                var oldVal = objOld.GetType().GetProperty(f.Name).GetValue(objOld, null);
                if (newVal != null && oldVal != null)
                {
                    if (!oldVal.Equals(newVal))
                    {
                        if (f.PropertyType == typeof(Image))
                        {
                            resultString += ((string.IsNullOrEmpty(resultString) ? "" : Environment.NewLine) + string.Format("Thay đổi \"{0}\":\"Hình ảnh\"", caption));
                        }
                        else if (f.PropertyType == typeof(byte[]))
                        {
                            resultString += ((string.IsNullOrEmpty(resultString) ? "" : Environment.NewLine) + string.Format("Thay đổi \"{0}\":\"Byte[]\"", caption));
                        }
                        else
                            resultString += ((string.IsNullOrEmpty(resultString) ? "" : Environment.NewLine) + string.Format("Thay đổi \"{0}\":\"{1}\" => \"{2}\"", caption, (oldVal ?? (object)"NULL"), (newVal ?? (object)"NULL")));
                    }
                }
                else if (objNew.GetType().GetProperty(f.Name).GetValue(objNew, null) != null || objOld.GetType().GetProperty(f.Name).GetValue(objOld, null) != null)
                {
                    if (f.PropertyType == typeof(Image))
                    {
                        resultString += ((string.IsNullOrEmpty(resultString) ? "" : Environment.NewLine) + string.Format("Thay đổi \"{0}\":\"Hình ảnh\"", caption));
                    }
                    else if (f.PropertyType == typeof(byte[]))
                    {
                        resultString += ((string.IsNullOrEmpty(resultString) ? "" : Environment.NewLine) + string.Format("Thay đổi \"{0}\":\"Byte[]\"", caption));
                    }
                    else
                    {
                        if (!(oldVal ?? (object)string.Empty).Equals((newVal ?? (object)string.Empty)))
                            resultString += ((string.IsNullOrEmpty(resultString) ? "" : Environment.NewLine) + string.Format("Thay đổi \"{0}\":\"{1}\" => \"{2}\"", caption, (oldVal ?? (object)"NULL"), (newVal ?? (object)"NULL")));
                    }
                }
            }
            return (string.IsNullOrEmpty(resultString) ? "Lưu với dữ liệu không thay đổi!" : resultString);
        }
        public static string GetDelete_Containt(object objDelete)
        {
            PropertyInfo[] fiNew = objDelete.GetType().GetProperties();
            var resultString = string.Empty;
            foreach (PropertyInfo f in fiNew)
            {
                var caption = f.Name;
                if (fiNew.GetType().GetProperty(f.Name) != null)
                {
                    caption = ((DescriptionAttribute)f.GetCustomAttributes(false)[0]).Description;
                }
                var currentVal = objDelete.GetType().GetProperty(f.Name).GetValue(objDelete, null);
                if (f.PropertyType == typeof(Image))
                {
                    resultString += ((string.IsNullOrEmpty(resultString) ? "" : ";") + string.Format("{0}(Hình ảnh)", caption));
                }
                else if (f.PropertyType == typeof(byte[]))
                {
                    resultString += ((string.IsNullOrEmpty(resultString) ? "" : ";") + string.Format("{0}(Byte[])", caption));
                }
                else
                    resultString += ((string.IsNullOrEmpty(resultString) ? "" : ";") + string.Format("{0}({1})", caption, (currentVal ?? (object)string.Empty)));
            }
            return resultString;
        }
        public static Dictionary<string, string> GetPorpetiesAndDescriptionList(object objIn)
        {
            var returnDictionary = new Dictionary<string, string>();

            var fiCheck = objIn.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo f in fiCheck)
            {
                var des = (f.GetCustomAttributes(typeof(DescriptionAttribute), false));
                returnDictionary.Add(f.Name, (des.Length == 0 ? f.Name : ((DescriptionAttribute)des[0]).Description));
            }
            return returnDictionary;
        }
        public static Dictionary<string, string> GetFieldAndDescriptionList(object objIn)
        {
            var returnDictionary = new Dictionary<string, string>();

            var fiCheck = objIn.GetType().GetFields();
            foreach (var f in fiCheck)
            {
                var des = (f.GetCustomAttributes(typeof(DescriptionAttribute), false));

                returnDictionary.Add(f.Name, (des.Length == 0 ? f.Name : ((DescriptionAttribute)des[0]).Description));
            }
            return returnDictionary;
        }
        public static Dictionary<string, Dictionary<string, string>> GetPorpetiesAndDescriptionAndCategoryList(object objIn)
        {
            var returnDictionary = new Dictionary<string, Dictionary<string, string>>();

            var fiCheck = objIn.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo f in fiCheck)
            {
                var des = (f.GetCustomAttributes(typeof(DescriptionAttribute), false));
                var category = (f.GetCustomAttributes(typeof(CategoryAttribute), false));
                var cateName = category.Length == 0 ? "Common" : ((CategoryAttribute)category[0]).Category;
                if (!returnDictionary.Keys.Where(x => x.Equals(cateName)).Any())
                {
                    returnDictionary.Add(cateName, new Dictionary<string, string>());
                }
                var dicInfo = returnDictionary[cateName];
                dicInfo.Add(f.Name, (des.Length == 0 ? f.Name : ((DescriptionAttribute)des[0]).Description));
            }
            return returnDictionary;
        }
        public static object Get_InfoForObject(object objInfo, DataRow drInfo)
        {
            PropertyInfo[] fiCheck = objInfo.GetType().GetProperties();
            foreach (PropertyInfo f in fiCheck)
            {
                var prop = objInfo.GetType().GetProperty(f.Name);
                if (objInfo.GetType().GetProperty(f.Name) != null)
                {
                    if (drInfo.Table.Columns.Contains(f.Name))
                    {
                        if (prop.PropertyType == typeof(Image) || prop.PropertyType == typeof(Bitmap))
                        {
                            var obj = drInfo[f.Name];
                            if (obj == null || obj == DBNull.Value)
                                prop.SetValue(objInfo, null, null);
                            else
                            {
                                var byteArr = (byte[])drInfo[f.Name];
                                Image image;
                                using (MemoryStream ms = new MemoryStream(byteArr))
                                {
                                    image = Image.FromStream(ms);
                                }
                                prop.SetValue(objInfo, image, null);
                            }
                        }
                        else
                            prop.SetValue(objInfo, ChangeTypeForOject(drInfo[f.Name], prop.PropertyType), null);
                    }
                }
            }
            return objInfo;
        }
        public static object ChangeTypeForOject(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value == DBNull.Value)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }
            else if (value == null || value == DBNull.Value)
            {
                return null;
            }

            if (value is Guid && t.Equals(typeof(string)))
                return Convert.ChangeType(value.ToString(), t);
            return Convert.ChangeType(value, t);
        }
        public static string NhapLyDo(bool multiLine = false)
        {
            var f = new FrmLyDo();
            f.Multiline = multiLine;
            f.ShowDialog();
            return f.NoiDung;
        }
        public static FolderBrowserDialog FolderBrowseDiaglog()
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            return f;
        }
        public static void ColumnToArry(DataTable dt, string columnName, ref string[] array)
        {
            array = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                array[i] = dt.Rows[i][columnName].ToString();
            }
        }
        public static object ConvertObjectForSQPara(object inObject, bool getOnlyDate = false, bool isImage = false)
        {
            if (inObject == null)
            {
                return DBNull.Value;
            }
            else
            {
                if (inObject is string)
                {
                    var str = (string)inObject;
                    return (string.IsNullOrEmpty(str) ? DBNull.Value : inObject);
                }
                else if (inObject is DateTime?)
                {
                    if ((DateTime)inObject == DateTime.MinValue)
                        return DBNull.Value;
                    var obj = (DateTime?)inObject;
                    if (obj == null)
                        return DBNull.Value;
                    else
                        return (getOnlyDate ? obj.Value.Date : obj.Value);
                }
                else if (inObject is DateTime)
                {
                    if ((DateTime)inObject == DateTime.MinValue)
                        return (object)DBNull.Value;
                    var obj = (DateTime)inObject;
                    if (obj == null)
                        return DBNull.Value;
                    else
                        return (getOnlyDate ? obj.Date : obj);
                }
                else if (inObject is float || inObject is float?)
                {
                    var obj = (float?)inObject;
                    return (obj == null ? (object)DBNull.Value : obj.Value.ToString());
                }
                else if (inObject is Image || inObject is Bitmap)
                {
                    var img = (Image)inObject;
                    byte[] byteArray = new byte[0];
                    using (MemoryStream stream = new MemoryStream())
                    {
                        img.Save(stream, img.RawFormat);
                        stream.Close();
                        byteArray = stream.ToArray();
                    }
                    return (byteArray == null ? (object)DBNull.Value : byteArray);
                }
            }
            return inObject;
        }
        public static SqlParameter GetParaFromOject(string paraName, object inObject
            , bool getOnlyDate = false, bool datetime2 = false, bool isImage = false
            , ParameterDirection paraDirection = ParameterDirection.Input)
        {
            if (datetime2)
            {
                var para = new SqlParameter(paraName, SqlDbType.DateTime2);
                para.Direction = paraDirection;
                para.Value = ConvertObjectForSQPara(inObject, getOnlyDate);
                return para;
            }
            else if (inObject is Image || isImage)
            {
                var para = new SqlParameter(paraName, SqlDbType.Image);
                para.Direction = paraDirection;
                para.Value = ConvertObjectForSQPara(inObject, getOnlyDate);
                return para;
            }
            else
            {
                return new SqlParameter(paraName, ConvertObjectForSQPara(inObject, getOnlyDate));
            }
        }
        public static string ValueCombobox(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? string.Empty : cbo.SelectedValue.ToString();
        }
        public static int? ValueCombobox_IntNull(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? (int?)null : int.Parse(cbo.SelectedValue.ToString());
        }
        public static int ValueCombobox_IntNull_Minus1(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? -1 : int.Parse(cbo.SelectedValue.ToString());
        }
        public static int ValueCombobox_IntNull_Zero(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? 0 : int.Parse(cbo.SelectedValue.ToString());
        }
        public static float? ValueCombobox_FloatNull(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? (float?)null : float.Parse(cbo.SelectedValue.ToString());
        }
        public static float ValueCombobox_FloatNull_Minus1(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? -1 : float.Parse(cbo.SelectedValue.ToString());
        }
        public static float ValueCombobox_FloatNull_Zero(ComboBox cbo)
        {
            return cbo.SelectedIndex == -1 ? 0 : float.Parse(cbo.SelectedValue.ToString());
        }
        public static int? ValueString_IntNull(string input)
        {
            return string.IsNullOrEmpty(input) ? (int?)null : int.Parse(input);
        }
        public static int ValueString_Int_Minus1(string input)
        {
            return string.IsNullOrEmpty(input) ? -1 : int.Parse(input);
        }
        public static int ValueString_Int_Zero(string input)
        {
            return string.IsNullOrEmpty(input) ? 0 : int.Parse(input);
        }
        public static float? ValueString_FloatNull(string input)
        {
            return string.IsNullOrEmpty(input) ? (float?)null : float.Parse(input);
        }
        public static float ValueString_Float_Minus1(string input)
        {
            return string.IsNullOrEmpty(input) ? -1 : float.Parse(input);
        }
        public static string ObjecToString(object valuein)
        {
            return (valuein ?? (object)string.Empty).ToString();
        }
        public static object GetValueFromDataRow_Object(DataRow drSource, string columnName)
        {
            return string.IsNullOrEmpty(columnName)
                            ? null
                            : (drSource.Table.Columns.IndexOf(columnName) > -1 ? (string.IsNullOrEmpty(ObjecToString(drSource[columnName])) ? null : drSource[columnName]) : null);
        }
        public static string GetValueFromDataRow_String(DataRow drSource, string columnName)
        {
            return ObjecToString(GetValueFromDataRow_Object(drSource, columnName));
        }
        public static DateTime GetValueFromDataRow_DateTime(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? DateTime.MinValue : DateTime.Parse(ObjecToString(obj));
        }
        public static DateTime? GetValueFromDataRow_DateTimeNull(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? (DateTime?)null : DateTime.Parse(ObjecToString(obj));
        }
        public static int GetValueFromDataRow_Int(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? int.MinValue : int.Parse(ObjecToString(obj));
        }
        public static int? GetValueFromDataRow_IntNull(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? (int?)null : int.Parse(ObjecToString(obj));
        }
        public static double GetValueFromDataRow_Double(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? double.MinValue : double.Parse(ObjecToString(obj));
        }
        public static double? GetValueFromDataRow_DoubleNull(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? (double?)null : double.Parse(ObjecToString(obj));
        }
        public static long GetValueFromDataRow_Long(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? long.MinValue : long.Parse(ObjecToString(obj));
        }
        public static double? GetValueFromDataRow_DoubleLong(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? (long?)null : long.Parse(ObjecToString(obj));
        }
        public static bool GetValueFromDataRow_Bool(DataRow drSource, string columnName)
        {
            var obj = GetValueFromDataRow_Object(drSource, columnName);
            return obj == null ? false : bool.Parse(ObjecToString(obj));
        }
        public static DateTime ConvertDate(string datetimeString)
        {
            var CurrentValue = DateTime.MinValue;
            DateTime.TryParse(datetimeString,
            CultureInfo.GetCultureInfo("en-US"),
            DateTimeStyles.None, out CurrentValue);
            return CurrentValue;
        }
        public static DataTable SearchResult_OnDatatable(DataTable dtSource, string searcCondit)
        {
            if (dtSource != null)
            {
                if (dtSource.Rows.Count > 0)
                {
                    DataRow[] resultFound;
                    resultFound = dtSource.Select(searcCondit);
                    DataTable dt = (resultFound.Length == 0 ? null : resultFound.CopyToDataTable());
                    DataTable sortedDT = new DataTable();
                    if (dt != null)
                    {
                        DataView dv = dt.DefaultView;
                        //dv.Sort = "MaXN asc, TenXN asc";
                        sortedDT = dv.ToTable();
                    }
                    else
                        sortedDT = dtSource.Clone();
                    return sortedDT;
                }
            }
            return dtSource;
        }
        public static DataTable SearchResult_OnDatatable_NoneSort(DataTable dtSource, string searcCondit)
        {
            if (dtSource.Rows.Count > 0)
            {
                DataRow[] resultFound;
                resultFound = dtSource.Select(searcCondit);
                DataTable dt = (resultFound.Length == 0 ? null : resultFound.CopyToDataTable());
                if (dt == null)
                    dt = dtSource.Clone();
                return dt;
            }
            else
                return dtSource;
        }
        /// <summary>
        /// Convert number to us standard
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(string source)
        {
            CultureInfo usCulture = new CultureInfo("en-US");

            if (string.IsNullOrEmpty(source.Trim()))
                return null;
            else
                return Convert.ToDecimal(source.Replace(",", ".").Trim(), usCulture);
        }
        public static decimal? ToDecimal(double sourceVal)
        {
            CultureInfo usCulture = new CultureInfo("en-US");
            string source = sourceVal.ToString();
            if (string.IsNullOrEmpty(source.Trim()))
                return null;
            else
                return Convert.ToDecimal(source.Replace(",", ".").Trim(), usCulture);
        }
        public static string Format_StringNumber(string input)
        {
            string format = (IsNumeric(input) ? string.Format("{0:0.###}", double.Parse(input)) : input);
            return format;
        }
        public static System.Boolean IsNumeric(System.Object expression)
        {
            if (expression == null || expression is DateTime)
                return false;

            if (expression is Int16 || expression is Int32 || expression is Int64 || expression is Decimal ||
                expression is Single || expression is Double || expression is Boolean)
                return true;

            try
            {
                if (expression is string)
                    Double.Parse(expression as string);
                else
                    Double.Parse(expression.ToString());
                return true;
            }
            catch
            {
            } // just dismiss errors but return false
            return false;
        }

        /// <summary>
        /// Chuyển ngày giờ về định dạng USA
        /// </summary>
        /// <param name="dtValue">DateTime to convert</param>
        /// <returns></returns>
        public static DateTime? To_USA_DateTime(DateTime dtValue)
        {
            string dateString = dtValue.ToString();
            var usCulture = "en-US";
            return DateTime.Parse(dateString, new CultureInfo(usCulture, false));
        }

        /// <summary>
        /// Chuyển ngày giờ về định dạng USA
        /// </summary>
        /// <param name="dateString">String datetiem to convert</param>
        /// <returns></returns>
        public static DateTime? To_USA_DateTime(string dateString)
        {
            var usCulture = "en-US";
            return DateTime.Parse(dateString, new CultureInfo(usCulture, false));
        }
        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 997);
        }

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
        public static DataTable ConvertToDataTable<T>(object obj)
        {
            if (obj != null)
            {
                if (obj is IList<T>)
                {
                    var data = (IList<T>)obj;
                    PropertyDescriptorCollection properties =
                        TypeDescriptor.GetProperties(typeof(T));
                    DataTable table = new DataTable();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        var keyName = prop.Name.Trim();
                        var validDate = (keyName.Equals("diachi", StringComparison.OrdinalIgnoreCase) || keyName.ToLower().Contains("ma") ? false : ValidateDate(prop.GetValue(data).ToString()));

                        if (validDate)
                        {
                            table.Columns.Add(keyName, typeof(DateTime));
                        }
                        else
                        {
                            table.Columns.Add(keyName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                        }
                    }
                    foreach (T item in data)
                    {
                        DataRow row = table.NewRow();
                        foreach (PropertyDescriptor prop in properties)
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        table.Rows.Add(row);
                    }
                    return table;
                }
                return null;
            }
            else
                return null;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data, bool isDDMMYYY = false, string formatDateChar = "-")
        {
            if (data != null)
            {
                if (data.Count == 0)
                    return null;
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                //foreach (PropertyDescriptor prop in properties)
                //    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (PropertyDescriptor prop in properties)
                {
                    var keyName = prop.Name.Trim();
                    var validDate = (keyName.Equals("diachi", StringComparison.OrdinalIgnoreCase) || keyName.ToLower().Contains("ma") ? false : ValidateDate((prop.GetValue(data[0])??string.Empty).ToString()));

                    if (validDate)
                    {
                        table.Columns.Add(keyName, typeof(DateTime));
                    }
                    else
                    {
                        table.Columns.Add(keyName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor propData in properties)
                    {
                        var keyName = propData.Name.Trim();
                        var validDate = (keyName.Equals("diachi", StringComparison.OrdinalIgnoreCase) || keyName.ToLower().Contains("ma") ? false : ValidateDate((propData.GetValue(item) ?? string.Empty).ToString()));
                        if (validDate)
                        {
                            if (propData.GetValue(item) != null)
                            {
                                if(isDDMMYYY)
                                {
                                    var date = GetDateFromDDMMYY((propData.GetValue(item) ?? string.Empty).ToString(), formatDateChar);
                                    if(date != null)
                                        row[propData.Name] = date;
                                }
                                else if (!string.IsNullOrEmpty((propData.GetValue(item) ?? string.Empty).ToString()))
                                {
                                    row[propData.Name] = DateTime.Parse(propData.GetValue(item).ToString());
                                }
                            }
                        }
                        else
                        {
                            row[propData.Name] = propData.GetValue(item) ?? DBNull.Value;
                        }
                   
                    }
                    table.Rows.Add(row);
                }
                return table;
            }
            else
                return null;
        }
        public static DateTime? GetDateFromDDMMYY(string dateString, string formatChar)
        {
            DateTime dateTime;
            CultureInfo culture = new CultureInfo("vi-VN");
            var DateTimeFormat = new DateTimeFormatInfo();
            DateTimeFormat.FullDateTimePattern =  string.Format("DD{0}MM{0}YYYY", formatChar);

            if (DateTime.TryParse(dateString, culture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }
        public static string ObjectToXMLGeneric<T>(T filter)
        {
            string xml = null;
            using (StringWriter sw = new StringWriter())
            {

                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(sw, filter);
                try
                {
                    xml = sw.ToString();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return xml;
        }

        public static string GetBarcodeInString(string barcodeIn, int codeLenght = 10)
        {
            var checkBarcode = barcodeIn.Trim();
            var codeSplit = checkBarcode.Split('.');
            if (codeSplit.Length == 1)
            {
                if (checkBarcode.Length > codeLenght)
                {
                    var digi = checkBarcode.Substring(0, codeLenght);
                    var removeCode = SplitSampleCode(checkBarcode.Replace(digi, ""));
                    if (IsNumeric(removeCode) && IsNumeric(digi))
                        return digi + removeCode;
                    else if (IsNumeric(digi))
                    {
                        return digi;
                    }
                }
            }
            return barcodeIn.Trim();
        }
        public static string SplitSampleCode(string inputCode)
        {
            //quy tắc: các ký tự từ phải qua liên tục là chữ
            if(string.IsNullOrEmpty(inputCode)) return string.Empty;
            var val = inputCode.Trim();
            for (int i = val.Length - 1; i > -1; i--)
            {
                if (IsNumeric(val[i].ToString()))
                {
                    return val.Substring(0, i + 1);
                }
            }
            return val;
        }
        public static DataTable DataTable_DistinctValue(DataTable dtSource, string _coloumn)
        {
            DataView view = new DataView(dtSource);
            return view.ToTable(true, _coloumn);
        }

        public static DataTable DataTable_DistinctValue(DataTable dtSource, string[] _coloumn)
        {
            DataView view = new DataView(dtSource);
            return view.ToTable(true, _coloumn);
        }

        public static DataTable DataTable_DistinctValue(DataTable dtSource, string _sortColumn, string _coloumn1, string _column2)
        {
            DataView view = new DataView(dtSource);
            view.Sort = _sortColumn + " asc";
            return view.ToTable(true, _coloumn1, _column2);
        }
        public static DataTable ConvertColumnNameToLower_Upper(DataTable dataSource, bool toLower)
        {
            if (dataSource == null) return dataSource;
            var colName = string.Empty;
            for (int i = 0; i < dataSource.Columns.Count; i++)
            {
                colName = dataSource.Columns[i].ColumnName.Trim();
                dataSource.Columns[i].ColumnName = (toLower ? colName.ToLower() : colName.ToUpper());
            }
            dataSource.AcceptChanges();
            return dataSource;
        }

        public static string EscapeLikeValue(string valueWithoutWildcards)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        public static DataTable MergeAll(IList<DataTable> tables, string primaryKeyColumn)
        {
            if (!tables.Any())
                throw new ArgumentException("Tables must not be empty", "tables");
            if (primaryKeyColumn != null)
                foreach (DataTable t in tables)
                    if (!t.Columns.Contains(primaryKeyColumn))
                        throw new ArgumentException("All tables must have the specified primarykey column " + primaryKeyColumn, "primaryKeyColumn");

            if (tables.Count == 1)
                return tables[0];

            DataTable table = new DataTable("TblUnion");
            table.BeginLoadData(); // Turns off notifications, index maintenance, and constraints while loading data
            foreach (DataTable t in tables)
            {
                table.Merge(t); // same as table.Merge(t, false, MissingSchemaAction.Add);
            }
            table.EndLoadData();

            if (primaryKeyColumn != null)
            {
                // since we might have no real primary keys defined, the rows now might have repeating fields
                // so now we're going to "join" these rows ...
                var pkGroups = table.AsEnumerable()
                    .GroupBy(r => r[primaryKeyColumn]);
                var dupGroups = pkGroups.Where(g => g.Count() > 1);
                foreach (var grpDup in dupGroups)
                {
                    // use first row and modify it
                    DataRow firstRow = grpDup.First();
                    foreach (DataColumn c in table.Columns)
                    {
                        if (firstRow.IsNull(c))
                        {
                            DataRow firstNotNullRow = grpDup.Skip(1).FirstOrDefault(r => !r.IsNull(c));
                            if (firstNotNullRow != null)
                                firstRow[c] = firstNotNullRow[c];
                        }
                    }
                    // remove all but first row
                    var rowsToRemove = grpDup.Skip(1);
                    foreach (DataRow rowToRemove in rowsToRemove)
                        table.Rows.Remove(rowToRemove);
                }
            }

            return table;
        }
        public static DataTable DataTable_MoveData(DataTable dtSource, DataRow rowInsert, int movePos)
        {
            DataTable dataReturn = dtSource.Clone();
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                if (movePos == i)
                {
                    dataReturn.ImportRow(rowInsert);
                    dataReturn.ImportRow(dtSource.Rows[i]);
                }
                else
                    dataReturn.ImportRow(dtSource.Rows[i]);
            }
            return dataReturn;
        }

        public static DataTable ConvertDynamicToDataTable<T>(IList<T> data)
        {
            var table = new DataTable();
            if (data != null && data.Any())
            {
                var firstRow = data[0].ToString();
                var firstRowData = JsonConvert.DeserializeObject<Dictionary<string, string>>(firstRow);
                var cols = new Dictionary<int, string>();
                var colIndex = 0;
                foreach (var kv in firstRowData)
                {
                    var keyName = kv.Key.Trim();
                    var validDate = (keyName.Equals("diachi", StringComparison.OrdinalIgnoreCase) || keyName.ToLower().Contains("ma") ? false : ValidateDate(kv.Value));

                    if (validDate)
                    {
                        table.Columns.Add(keyName, typeof(DateTime));
                    }
                    else
                    {
                        table.Columns.Add(keyName);
                    }

                    cols.Add(colIndex, keyName);

                    colIndex += 1;
                }

                foreach (T item in data)
                {
                    var currentRow = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.ToString());
                    DataRow row = table.NewRow();
                    for (var i = 0; i < colIndex; i++)
                    {
                        var keyName = cols[i].Trim();
                        var currentColValue = currentRow[keyName];
                        row[keyName] = (object)currentColValue;
                    }

                    table.Rows.Add(row);
                }
            }
            return table;
        }

   

        public static DataTable ConvertDynamicToDataTable1<T>(IList<dynamic> data)
        {
            var table = new DataTable();
            if (data != null && data.Any())
            {
                var firstRow = data[0].ToString();
                var firstRowData = JsonConvert.DeserializeObject<Dictionary<string, string>>(firstRow);
                var cols = new Dictionary<int, string>();
                var colIndex = 0;
                foreach (var kv in firstRowData)
                {
                    var keyName = kv.Key.Trim();
                    var validDate = (keyName.Equals("diachi", StringComparison.OrdinalIgnoreCase) || keyName.ToLower().Contains("ma") ? false : ValidateDate(kv.Value));

                    if (validDate)
                    {
                        table.Columns.Add(keyName, typeof(DateTime));
                    }
                    else
                    {
                        table.Columns.Add(keyName);
                    }

                    cols.Add(colIndex, keyName);

                    colIndex += 1;
                }

                foreach (T item in data)
                {
                    var currentRow = JsonConvert.DeserializeObject<Dictionary<string, string>>(item.ToString());
                    DataRow row = table.NewRow();
                    for (var i = 0; i < colIndex; i++)
                    {
                        var keyName = cols[i].Trim();
                        var currentColValue = currentRow[keyName];
                        row[keyName] = (object)currentColValue;
                    }

                    table.Rows.Add(row);
                }
            }

            return table;
        }
        public static Dictionary<String, Object> ConvertDynamicToDictionary(dynamic dynObj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynObj))
            {
                object obj = propertyDescriptor.GetValue(dynObj);
                dictionary.Add(propertyDescriptor.Name, obj);
            }
            return dictionary;
        }
        public static bool ValidateDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            var regexDates = new Dictionary<string, string>()
            {
                {"dd/MM/yyyy", @"^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})"},
                {"MM/dd/yyyy", @"^([0]?[1-9]|[1][0-2])[./-]([0]?[0-9]|[12][0-9]|[3][01])[./-]([0-9]{4}|[0-9]{2})"},
                {"yyyy/MM/dd", @"^([0-9]{4}|[0-9]{2})[./-]([0]?[1-9]|[1][0-2])[./-]([0]?[0-9]|[12][0-9]|[3][01])"},
                {"yyyy/dd/MM", @"^([0-9]{4}|[0-9]{2})[./-]([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])"}
            };

            foreach (var regexDate in regexDates)
            {
                var regex = new Regex(regexDate.Value);

                var isValid = regex.IsMatch(input.Trim());
                if (isValid)
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Hộp thoại lưu file
        /// </summary>
        /// <param name="Filter">"Text Files | *.txt"</param>
        /// <param name="DefaultExt">"txt"</param>
        /// <returns></returns>
        public static string OpenSaveDiaglog(string Filter, string DefaultExt)
        {
            var saveDiag = new System.Windows.Forms.SaveFileDialog();
            saveDiag.Filter = Filter;
            saveDiag.DefaultExt = DefaultExt;
            saveDiag.ShowDialog();
            var txtFileName = saveDiag.FileName;
            return txtFileName;
        }

        public static string Convert_SubSript(string inputString)
        {
            string returnString = string.Empty;
            returnString = inputString.Replace("E+01", " x 10¹")
                .Replace("E+02", " x 10²")
                .Replace("E+03", " x 10³")
                .Replace("E+04", " x 10⁴")
                .Replace("E+05", " x 10⁵")
                .Replace("E+06", " x 10⁶")
                .Replace("E+07", " x 10⁷")
                .Replace("E+08", " x 10⁸")
                .Replace("E+09", " x 10⁹")
                .Replace("E+10", " x 10¹⁰")
                .Replace("E+11", " x 10¹¹")
                .Replace("E+12", " x 10¹²")
                .Replace("E+13", " x 10¹³")
                .Replace("E+14", " x 10¹⁴")
                .Replace("E+15", " x 10¹⁵")
                .Replace("E+16", " x 10¹⁶")
                .Replace("E+17", " x 10¹⁷")
                .Replace("E+18", " x 10¹⁸")
                .Replace("E+19", " x 10¹⁹")
                .Replace("E+20", " x 10²⁰")
                .Replace("E+1", " x 10¹")
                .Replace("E+2", " x 10²")
                .Replace("E+3", " x 10³")
                .Replace("E+4", " x 10⁴")
                .Replace("E+5", " x 10⁵")
                .Replace("E+6", " x 10⁶")
                .Replace("E+7", " x 10⁷")
                .Replace("E+8", " x 10⁸")
                .Replace("E+9", " x 10⁹")
                .Replace("^1", "¹")
                .Replace("^2", "²")
                .Replace("^3", "³")
                .Replace("^4", "⁴")
                .Replace("^5", "⁵")
                .Replace("^6", "⁶")
                .Replace("^7", "⁷")
                .Replace("^8", "⁸")
                .Replace("^9", "⁹")
                .Replace("^01", "¹")
                .Replace("^02", "²")
                .Replace("^03", "³")
                .Replace("^04", "⁴")
                .Replace("^05", "⁵")
                .Replace("^06", "⁶")
                .Replace("^07", "⁷")
                .Replace("^08", "⁸")
                .Replace("^09", "⁹");

            return returnString;
        }
    }
}
