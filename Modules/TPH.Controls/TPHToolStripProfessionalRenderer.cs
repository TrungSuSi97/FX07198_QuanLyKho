using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FontAwesome.Sharp;

namespace TPH.Controls
{
    public partial class MenuRenderer : ToolStripProfessionalRenderer
    {
        //Fields
        private Color primaryColor;
        private Color textColor;
        private Color textSelectedColor;
        private Color backColor;
        private int arrowThickness;
        //Constructor
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor, Color textSelectedColor, Color backColor)
            : base(new MenuColorTable(isMainMenu, primaryColor, backColor))
        {
            this.primaryColor = primaryColor;
            this.textSelectedColor = textSelectedColor;
            this.backColor = backColor;
            if (isMainMenu)
            {
                arrowThickness = 3;
                this.textColor = textColor == Color.Empty ? Color.Gainsboro : textColor;
            }
            else
            {
                arrowThickness = 2;
                this.textColor = textColor == Color.Empty ? Color.DimGray : textColor;
            }
        }

        //Overrides
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? textSelectedColor : textColor;
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //Fields
            var graph = e.Graphics;
            var arrowSize = new Size(5, 12);
            var arrowColor = e.Item.Selected ? textSelectedColor : primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height);
            using (var path = new GraphicsPath())
            using (var pen = new Pen(arrowColor, arrowThickness))
            {
                //Drawing
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rect.Left, rect.Top, rect.Right, rect.Top + rect.Height / 2);
                path.AddLine(rect.Right, rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
                graph.DrawPath(pen, path);
            }
        }
    }
}
