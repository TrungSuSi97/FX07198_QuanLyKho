using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public static class HighDpiHelper
    {
        public static void AdjustControlImagesDpiScale(Control container)
        {
            var dpiScale = GetDpiScale(container).Value;
            if (CloseToOne(dpiScale))
                return;

            AdjustControlImagesDpiScale(container.Controls, dpiScale);
        }

        private static void AdjustButtonImageDpiScale(ButtonBase button, float dpiScale)
        {
            var image = button.Image;
            if (image == null)
                return;

            button.Image = ScaleImage(image, dpiScale);
        }
        private static void AdjustButtonImageDpiScale(SimpleButton button, float dpiScale)
        {
            var image = button.Image;
            if (image == null)
                return;

            button.Image = ScaleImage(image, dpiScale);
        }
        private static void AdjustControlImagesDpiScale(Control.ControlCollection controls, float dpiScale)
        {
            foreach (Control control in controls)
            {
                var button = control as ButtonBase;
                if (button != null)
                    AdjustButtonImageDpiScale(button, dpiScale);
                else
                {
                    var buttonSimple = control as SimpleButton;
                    if (buttonSimple != null)
                        AdjustButtonImageDpiScale(buttonSimple, dpiScale);
                    else
                    {
                        var pictureBox = control as PictureBox;
                        if (pictureBox != null)
                            AdjustPictureBoxDpiScale(pictureBox, dpiScale);
                    }
                }

                AdjustControlImagesDpiScale(control.Controls, dpiScale);
            }
        }

        private static void AdjustPictureBoxDpiScale(PictureBox pictureBox, float dpiScale)
        {
            var image = pictureBox.Image;
            if (image == null)
                return;

            if (pictureBox.SizeMode == PictureBoxSizeMode.CenterImage)
                pictureBox.Image = ScaleImage(pictureBox.Image, dpiScale);
        }

        private static bool CloseToOne(float dpiScale)
        {
            return Math.Abs(dpiScale - 1) < 0.001;
        }

        public static Lazy<float> GetDpiScale(Control control)
        {
            return new Lazy<float>(() =>
            {
                using (var graphics = control.CreateGraphics())
                    return graphics.DpiX / 96.0f;
            });
        }

        private static Image ScaleImage(Image image, float dpiScale)
        {
            var newSize = ScaleSize(image.Size, dpiScale);
            var newBitmap = new Bitmap(newSize.Width, newSize.Height);

            using (var g = Graphics.FromImage(newBitmap))
            {
                // According to this blog post http://blogs.msdn.com/b/visualstudio/archive/2014/03/19/improving-high-dpi-support-for-visual-studio-2013.aspx
                // NearestNeighbor is more adapted for 200% and 200%+ DPI

                var interpolationMode = InterpolationMode.HighQualityBicubic;
                if (dpiScale >= 2.0f)
                    interpolationMode = InterpolationMode.NearestNeighbor;

                g.InterpolationMode = interpolationMode;
                g.DrawImage(image, new Rectangle(new Point(), newSize));
            }

            return newBitmap;
        }

        private static Size ScaleSize(Size size, float scale)
        {
            return new Size((int)(size.Width * scale), (int)(size.Height * scale));
        }
    }
    public struct CommonAppColors
    {
        public static Color ColorTextNormal = Color.FromArgb(232, 234, 238); //232, 234, 238 //236, 245, 252
        public static Color ColorTextSelected = Color.FromArgb(0, 54, 100);

        public static Color ColorBottomAppColor = Color.FromArgb(19, 50, 84); //1, 32, 15 //16, 79, 85 //19, 50, 84
        public static Color ColorButtonTextForceColor = Color.FromArgb(56, 60, 68);

        public static Color ColorMainAppColor = Color.FromArgb(6, 57, 112);//0, 54, 100 //16, 79, 85 //11, 111, 152 //4, 161, 228 //22, 115, 189 //6, 57, 112
        public static Color ColorMainAppFormColor = Color.FromArgb(251, 251, 251); //50, 116, 109 //35, 130, 167 //158, 197, 171 //122, 227, 250 //251,251,251,255
        public static Color ColorMainAppColorSub1 = Color.FromArgb(4, 161, 228); //14, 132, 171 //4, 161, 228 //35, 130, 167
        public static Color ColorMainAppColorSub2 = Color.FromArgb(66, 91, 118); //37, 150, 190
        public static Color ColorAppFormColor = Color.FromArgb(251, 251, 251); //242, 252, 255 //122, 227, 250 //191, 249, 255 //241, 243, 248 //251, 251, 251
        public static Color ColorAppFormColor2 = Color.FromArgb(30, 129, 176);

        public static Color ColorButtonBackColor = Color.FromArgb(252, 251, 249); //35,42,65 //12, 105, 136 //12, 105, 136
        public static Color ColorButtonForceColor = Color.FromArgb(25, 25, 25); //125,227,255,255 //223, 240, 246
        public static Color ColorButtonBorderColor = Color.FromArgb(224, 217, 214); //235, 229, 225
        public static Color ColorButtonForceColorHover = Color.FromArgb(254, 218, 89); //254, 218, 89 //249, 170, 11 //
        public static Color ColorButtonBackColorHover = Color.FromArgb(249, 245, 244); //248, 248, 248 //249, 88, 155 //253, 253, 253
        public static Color ColorButtonMenuSelectedForce = Color.Red; 
        public static Color ColorButtonMenuNormalForce = Color.White; 
        public static Color ColorButtonMenuSelectedBackColor = Color.FromArgb(219, 207, 150);
        public static Color ColorCheckedSelectedBackColor = Color.FromArgb(219, 207, 150);
        public static Color ColorTabActiveBackColor = Color.FromArgb(219, 207, 150);

        public static Color ColorNormalPage = Color.FromArgb(19, 50, 84); //19,50,84 //30, 73, 115
        public static Color ColorSelectedPage = Color.FromArgb(254, 218, 89); //199, 227, 248 //254, 218, 89 //188,188,188
        public static Color ColorTextCaption = Color.FromArgb(254, 218, 89);
        public static Color ColorFormTextCaption = Color.GreenYellow;
        public static Color ColorTextBorder = Color.FromArgb(188, 188, 188);

        public static Color MenuItemTextColor = Color.FromArgb(56, 60, 68); //8, 48, 48 //68,70,71 //56, 60, 68
        public static Color MenuItemTextSelectedColor = Color.FromArgb(56, 60, 68);
        public static Color MenuItemPrimaryColor = Color.FromArgb(203, 205, 206); //14, 132, 171 //249, 249, 249 //154,156,157 //250,250,250 //225, 225, 225
        public static Color MenuItemBackColor = Color.FromArgb(249, 249, 249);
    }
}
