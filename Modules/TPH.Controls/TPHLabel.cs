using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public class TPHLabel : Label
    {
        private ls labelStyle;

        private bool hyperLink;
     
        private Color forceColor;

        [Category("TPH CustomControl")]
        public ls LabelStyle
        {
            get
            {
                return labelStyle;
            }
            set
            {
                labelStyle = value;
                Setlabel();
            }
        }

        [Category("TPH CustomControl")]
        public bool HyperLink
        {
            get
            {
                return hyperLink;
            }
            set
            {
                hyperLink = value;
                if (hyperLink)
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = Cursors.Arrow;
                }
            }
        }

        public TPHLabel()
        {
            ForeColor = AppearanceStyle.LightTextColor;
            Font = new Font("Arial", AppearanceStyle.fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStyle = ls.Normal;
            base.MouseEnter += Label_MouseEnter;
            base.MouseLeave += Label_MouseLeave;
        }

        private void Setlabel()
        {
            switch (labelStyle)
            {
                case ls.Normal:
                    forceColor = AppearanceStyle.LightTextColor;
                    ForeColor = forceColor;
                    Font = new Font(Font.Name, AppearanceStyle.fontSize, Font.Style, Font.Unit);
                    break;
                case ls.Description:
                    if (AppearanceStyle.theme == uuufteme.Dark)
                    {
                        forceColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 10);
                    }
                    else
                    {
                        forceColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 15);
                    }
                    ForeColor = forceColor;
                    Font = new Font(Font.Name, 10f, Font.Style, Font.Unit);
                    break;
                case ls.Subtitle:
                    if (AppearanceStyle.theme == uuufteme.Dark)
                    {
                        forceColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 45);
                    }
                    else
                    {
                        forceColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 20);
                    }
                    ForeColor = forceColor;
                    Font = new Font(Font.Name, 12f, Font.Style, Font.Unit);
                    break;
                case ls.Title:
                    forceColor = AppearanceStyle.Neptune;
                    ForeColor = forceColor;
                    Font = new Font(Font.Name, 14f, Font.Style, Font.Unit);
                    break;
                case ls.Title2:
                    if (AppearanceStyle.theme == uuufteme.Dark)
                    {
                        forceColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 50);
                    }
                    else
                    {
                        forceColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 25);
                    }
                    ForeColor = forceColor;
                    Font = new Font(Font.Name, 14f, Font.Style, Font.Unit);
                    break;
                case ls.BarCaption:
                    Font = new Font("Montserrat", 12.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    phphp();
                    break;
                case ls.BarText:
                    Font = new Font("Arial", 9.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    phphp();
                    break;
                case ls.Custom:
                    //forceColor = AppearanceStyle.LightTextColor;
                    //ForeColor = forceColor;
                    break;
            }
        }

        private void phphp()
        {
            if (AppearanceStyle.theme == uuufteme.Light && AppearanceStyle.colorStyle == stekeely.Supernova)
            {
                ForeColor = kkgegea.hgfhfg(AppearanceStyle.LightTextColor, 25);
            }
            else if (AppearanceStyle.theme == uuufteme.Dark && AppearanceStyle.colorStyle == stekeely.Supernova)
            {
                ForeColor = kkgegea.gegeagge(AppearanceStyle.LightTextColor, 65);
            }
            else
            {
                ForeColor = Color.WhiteSmoke;
            }
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            if (hyperLink)
            {
                ForeColor = kkgegea.gegeagge(AppearanceStyle.Neptune, 20);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            if (hyperLink)
            {
                ForeColor = forceColor;
            }
        }
    }
}
