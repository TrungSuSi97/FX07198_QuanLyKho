using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.Controls
{
    public static class ppwag
    {
        private static GraphicsPath GetGraphicPathFromHeight(Rectangle daas, float hghg)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            float num = hghg * 2f;
            graphicsPath.StartFigure();
            graphicsPath.AddArc(daas.X, daas.Y, num, num, 180f, 90f);
            graphicsPath.AddArc((float)daas.Right - num, daas.Y, num, num, 270f, 90f);
            graphicsPath.AddArc((float)daas.Right - num, (float)daas.Bottom - num, num, num, 0f, 90f);
            graphicsPath.AddArc(daas.X, (float)daas.Bottom - num, num, num, 90f, 90f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public static void DrawBorder(Control controlSource, int height)
        {
            if (height >= 1)
            {
                using (GraphicsPath path = GetGraphicPathFromHeight(controlSource.ClientRectangle, height))
                {
                    controlSource.Region = new Region(path);
                }
                controlSource.Resize += delegate
                {
                    using (GraphicsPath path2 = GetGraphicPathFromHeight(controlSource.ClientRectangle, height))
                    {
                        controlSource.Region = new Region(path2);
                    }
                };
            }
            else
            {
                controlSource.Region = new Region(controlSource.ClientRectangle);
                controlSource.Resize += delegate
                {
                    controlSource.Region = new Region(controlSource.ClientRectangle);
                };
            }
        }

        public static void DrawBorderRadius(Control controlSource, int borderRadius, Graphics graphic)
        {
            if (borderRadius > 1)
            {
                using (GraphicsPath path = GetGraphicPathFromHeight(controlSource.ClientRectangle, borderRadius))
                using (Pen pen = new Pen(controlSource.Parent.BackColor, 1f))
                {
                    graphic.SmoothingMode = SmoothingMode.AntiAlias;
                    controlSource.Region = new Region(path);
                    graphic.DrawPath(pen, path);
                }
            }
            else
            {
                controlSource.Region = new Region(controlSource.ClientRectangle);
            }
        }
        private static Color BackColorFromParent(Control parent)
        {
            if (parent != null)
            {
                if (parent.BackColor != Color.Empty)
                {
                    return parent.BackColor;
                }
                else
                    return BackColorFromParent(parent.Parent);
            }
            return Color.Empty;
        }
        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public static double GetOSVersion()
        {
            var objO = new ManagementObjectSearcher("SELECT Version FROM Win32_OperatingSystem").Get().Cast<ManagementObject>();
            var name = (from x in objO
                        select x.GetPropertyValue("Version")).FirstOrDefault();
            return double.Parse(name == null ? "0": name.ToString().Replace(".", ""));
        }
        public static void DrawBorderRadius(Control controlSource, int borderRadius, Graphics graphic, Color borderColor, float borderSize)
        {
            if (borderRadius > 1)
            {
                using (GraphicsPath path = GetGraphicPathFromHeight(controlSource.ClientRectangle, borderRadius))
                {
                    using (Pen pen = new Pen(BackColorFromParent(controlSource.Parent), borderSize + 1f))
                    using (Pen pen2 = new Pen(borderColor, borderSize))
                    using (Matrix matrix = new Matrix())
                    {
                        graphic.SmoothingMode = SmoothingMode.AntiAlias;
                        controlSource.Region = new Region(path);
                        graphic.DrawPath(pen, path);
                        if (borderSize >= 1f)
                        {
                            Rectangle clientRectangle = controlSource.ClientRectangle;
                            float scaleX = 1f - (borderSize + 1f) / (float)clientRectangle.Width;
                            float scaleY = 1f - (borderSize + 1f) / (float)clientRectangle.Height;
                            matrix.Scale(scaleX, scaleY);
                            matrix.Translate(borderSize / 1.6f, borderSize / 1.6f);
                            graphic.Transform = matrix;
                            graphic.DrawPath(pen2, path);
                        }
                    }
                }
                return;
            }
            controlSource.Region = new Region(controlSource.ClientRectangle);
            if (borderSize >= 1f && GetOSVersion() < 1002)
            {
                using (Pen pen2 = new Pen(borderColor, borderSize))
                {
                    pen2.Alignment = PenAlignment.Inset;
                    graphic.DrawRectangle(pen2, 0f, 0f, (float)controlSource.Width - 0.5f, (float)controlSource.Height - 0.5f);
                }
            }
        }
    }
    internal class MenuColorTable : ProfessionalColorTable
    {
        //Fields
        private Color backColor;
        private Color leftColumnColor;
        private Color borderColor;
        private Color menuItemBorderColor;
        private Color menuItemSelectedColor;
        //Constructor
        public MenuColorTable(bool isMainMenu, Color primaryColor, Color backColor)
        {
            if (isMainMenu)
            {
                backColor = backColor == Color.Empty ? primaryColor : backColor;
                leftColumnColor = primaryColor;
                borderColor = primaryColor;
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
            else
            {
                backColor = Color.White;
                leftColumnColor = Color.LightGray;
                borderColor = Color.LightGray;
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
        }
        //Overrides
        public override Color ToolStripDropDownBackground { get { return backColor; } }
        public override Color MenuBorder { get { return borderColor; } }
        public override Color MenuItemBorder { get { return menuItemBorderColor; } }
        public override Color MenuItemSelected { get { return menuItemSelectedColor; } }
        public override Color ImageMarginGradientBegin { get { return leftColumnColor; } }
        public override Color ImageMarginGradientMiddle { get { return leftColumnColor; } }
        public override Color ImageMarginGradientEnd { get { return leftColumnColor; } }
    }
    public static class kkgegea
    {
        public static Color gegeagge(Color hfghfg, ushort gfdgdfg)
        {
            if (gfdgdfg <= 100)
            {
                float num = (float)(int)gfdgdfg / 100f;
                float num2 = (int)hfghfg.R;
                float num3 = (int)hfghfg.G;
                float num4 = (int)hfghfg.B;
                num2 = (255f - num2) * num + num2;
                num3 = (255f - num3) * num + num3;
                num4 = (255f - num4) * num + num4;
                return Color.FromArgb(hfghfg.A, (int)num2, (int)num3, (int)num4);
            }
            return hfghfg;
        }

        public static Color hgfhfg(Color gh, ushort asd)
        {
            if (asd <= 100)
            {
                float num = (float)(int)asd / 100f * -1f;
                num = 1f + num;
                float num2 = (int)gh.R;
                float num3 = (int)gh.G;
                float num4 = (int)gh.B;
                num2 *= num;
                num3 *= num;
                num4 *= num;
                return Color.FromArgb(gh.A, (int)num2, (int)num3, (int)num4);
            }
            return gh;
        }
    }
    public static class clors
    {
        public static int colorIndex;

        public static readonly Color SideMenuColor = Color.FromArgb(49, 42, 81);

        public static readonly Color DefaultFormBorderColor = Color.FromArgb(111, 106, 143);

        public static readonly Color Axolotl = Color.FromArgb(248, 112, 171);

        public static readonly Color FireOpal = Color.FromArgb(245, 124, 37);

        public static readonly Color Forest = Color.FromArgb(20, 138, 75);

        public static readonly Color Lisianthus = Color.FromArgb(123, 104, 238);

        public static readonly Color Neptune = Color.FromArgb(83, 97, 212);

        public static readonly Color Petunia = Color.FromArgb(171, 48, 243);

        public static readonly Color Ruby = Color.FromArgb(224, 40, 67);

        public static readonly Color Sky = Color.FromArgb(90, 146, 246);

        public static readonly Color Spinel = Color.FromArgb(251, 111, 126);

        public static readonly Color FantasyColorScheme1 = Color.FromArgb(104, 85, 230);

        public static readonly Color FantasyColorScheme2 = Color.FromArgb(47, 168, 210);

        public static readonly Color FantasyColorScheme3 = Color.FromArgb(70, 132, 235);

        public static readonly Color FantasyColorScheme4 = Color.FromArgb(238, 96, 112);

        public static readonly Color FantasyColorScheme5 = Color.FromArgb(73, 84, 228);

        public static readonly Color FantasyColorScheme6 = Color.FromArgb(230, 52, 114);

        public static readonly Color FantasyColorScheme7 = Color.FromArgb(208, 101, 243);

        public static readonly Color FantasyColorScheme8 = Color.FromArgb(238, 134, 139);

        public static readonly Color FantasyColorScheme9 = Color.FromArgb(249, 88, 155);

        public static readonly Color FantasyColorScheme10 = Color.FromArgb(249, 170, 114);

        public static readonly Color FantasyColorScheme11 = Color.FromArgb(224, 195, 252);

        public static readonly Color FantasyColorScheme12 = Color.FromArgb(125, 179, 250);

        public static readonly Color DarkBackground = Color.FromArgb(58, 52, 95);

        public static readonly Color DarkItemBackground = Color.FromArgb(66, 60, 109);

        public static readonly Color DarkActiveBackground = Color.FromArgb(77, 70, 130);

        public static readonly Color DarkTextColor = Color.FromArgb(122, 119, 170);

        public static readonly Color LightBackground = Color.FromArgb(240, 245, 249);

        public static readonly Color LightItemBackground = Color.FromArgb(250, 252, 253);

        public static readonly Color LightActiveBackground = Color.FromArgb(231, 238, 246);

        public static readonly Color LightTextColor = Color.FromArgb(132, 129, 132);

        public static readonly Color Delete = Color.FromArgb(234, 79, 82);

        public static readonly Color Confirm = Color.FromArgb(55, 159, 113);

        public static readonly Color Cancel = Color.FromArgb(104, 110, 134);

        public static readonly Color Deactive = Color.FromArgb(111, 127, 148);

        public static readonly Color DeactiveDark = Color.FromArgb(53, 64, 81);

        private static readonly List<Color> SupernovaColors = new List<Color>
        {
            FantasyColorScheme1,
            FantasyColorScheme2,
            FantasyColorScheme3,
            FantasyColorScheme4,
            FantasyColorScheme5,
            FantasyColorScheme6,
            FantasyColorScheme7,
            FantasyColorScheme8,
            FantasyColorScheme9,
            FantasyColorScheme10
        };

        public static Color GetSupernovaColor()
        {
            Color result = SupernovaColors[colorIndex];
            colorIndex++;
            if (colorIndex >= SupernovaColors.Count)
            {
                colorIndex = 0;
            }
            return result;
        }
    }
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct AppearanceStyle
    {
        internal static uuufteme theme = uuufteme.Light;

        internal static stekeely colorStyle = stekeely.Forest;

        internal static Color LightBackground = clors.LightBackground;

        internal static Color LightItemBackground = clors.LightItemBackground;

        internal static Color LightActiveBackground = clors.LightActiveBackground;

        internal static Color LightTextColor = clors.LightTextColor;

        internal static Color Neptune = clors.Neptune;

        internal static Color From76_70_116 = Color.FromArgb(76, 70, 116);

        //internal static int m = 1;

        //internal static bool n = true;

        //internal static bool o = false;

        //internal static bool p = true;

        internal static string fontName = "Arial";

        internal static float fontSize = 10f;
    }
    public enum stekeely
    {
        Axolotl,
        FireOpal,
        Forest,
        Lisianthus,
        Neptune,
        Petunia,
        Ruby,
        Sky,
        Spinel,
        Supernova
    }
    public enum dmp
    {
        TopRight,
        BottomRight,
        LeftTop,
        LeftBottom
    }
    //UserInterFaceTheme
    public enum uuufteme
    {
        Light,
        Dark
    }
    //LabelStyle
    public enum ls
    {
        Normal,
        Description,
        Subtitle,
        Title,
        Title2,
        BarCaption,
        BarText,
        Custom
    }

    public enum bd
    {
        Normal,
        IconButton,
        Metro,
        Confirm,
        Cancel,
        Delete,
        Custom
    }
    //ControlBackColorStyle
    public enum ctrls
    {
        Glass,
        Solid
    }
    //TextBocBorderStyle
    public enum tbs
    {
        MatteBorder,
        FlaringBorder,
        MatteLine,
        FlaringLine
    }
    public enum txp
    {
        Left,
        Right,
        Center,
        Sliding,
        None
    }
}
