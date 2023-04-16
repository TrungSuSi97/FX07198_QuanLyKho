using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TPH.Controls
{
    public partial class TPHDataGridview : DataGridView
    {

        private bool customizable = true;

        private bool b;

        private int c;

        private DataGridViewCellStyle d;

        private DataGridViewCellStyle e;

        private DataGridViewCellStyle f;

        private bool s = true;

        [Category("TPH CustomControl")]
        public int HeadersHeight
        {
            get
            {
                return base.ColumnHeadersHeight;
            }
            set
            {
                base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                if (value < 40)
                {
                    base.ColumnHeadersHeight = 40;
                }
                else
                {
                    base.ColumnHeadersHeight = value;
                }
            }
        }

        [Category("TPH CustomControl")]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get
            {
                return base.AutoSizeColumnsMode;
            }
            set
            {
                base.AutoSizeColumnsMode = value;
            }
        }

        [Category("TPH CustomControl")]
        public bool UserCustomColor
        {
            get
            {
                return customizable;
            }
            set
            {
                customizable = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color ColumnHeaderBackColor
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.BackColor;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.BackColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color ColumnHeaderForceColor
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.ForeColor;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.ForeColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public Font ColumnHeaderFont
        {
            get
            {
                return base.ColumnHeadersDefaultCellStyle.Font;
            }
            set
            {
                base.ColumnHeadersDefaultCellStyle.Font = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color RowHeadersBackColor
        {
            get
            {
                return base.RowHeadersDefaultCellStyle.BackColor;
            }
            set
            {
                base.RowHeadersDefaultCellStyle.BackColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color DefaultCellSelectionBackColor
        {
            get
            {
                return base.RowHeadersDefaultCellStyle.SelectionBackColor;
            }
            set
            {
                base.RowHeadersDefaultCellStyle.SelectionBackColor = value;
                base.RowsDefaultCellStyle.SelectionBackColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color DefaultCellBackColor
        {
            get
            {
                return base.RowsDefaultCellStyle.BackColor;
            }
            set
            {
                base.RowsDefaultCellStyle.BackColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public bool AlterDefaultCellStyle
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                if (!value)
                {
                    base.AlternatingRowsDefaultCellStyle.BackColor = Color.Empty;
                }
            }
        }

        [Category("TPH CustomControl")]
        public Color CellBackColor
        {
            get
            {
                return base.AlternatingRowsDefaultCellStyle.BackColor;
            }
            set
            {
                if (b)
                {
                    base.AlternatingRowsDefaultCellStyle.BackColor = value;
                }
            }
        }

        [Category("TPH CustomControl")]
        public Color CellForeColor
        {
            get
            {
                return base.RowsDefaultCellStyle.ForeColor;
            }
            set
            {
                base.RowsDefaultCellStyle.ForeColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color CellSelectionForeColor
        {
            get
            {
                return base.RowsDefaultCellStyle.SelectionForeColor;
            }
            set
            {
                base.RowsDefaultCellStyle.SelectionForeColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public int RowHeight
        {
            get
            {
                return base.RowTemplate.Height;
            }
            set
            {
                base.RowTemplate.Height = value;
            }
        }

        [Category("TPH CustomControl")]
        public Color GridBackgroundColor
        {
            get
            {
                return base.BackgroundColor;
            }
            set
            {
                base.BackgroundColor = value;
            }
        }

        [Category("TPH CustomControl")]
        public int BorderRadius
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                Invalidate();
            }
        }

        public TPHDataGridview()
        {
            d = new DataGridViewCellStyle();
            e = new DataGridViewCellStyle();
            f = new DataGridViewCellStyle();
            base.AllowUserToResizeRows = false;
            base.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            base.BackgroundColor = clors.LightItemBackground;
            base.BorderStyle = BorderStyle.None;
            base.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            base.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            base.EnableHeadersVisualStyles = false;
            base.GridColor = Color.FromArgb(224, 224, 224);
            base.ReadOnly = true;
            RightToLeft = RightToLeft.No;
            base.Size = new Size(450, 250);
            d.Alignment = DataGridViewContentAlignment.MiddleLeft;
            d.BackColor = Color.MediumPurple;
            d.Font = new Font("Arial", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
            d.ForeColor = Color.White;
            d.WrapMode = DataGridViewTriState.True;
            d.Padding = new Padding(15, 0, 0, 0);
            base.ColumnHeadersDefaultCellStyle = d;
            base.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            base.ColumnHeadersHeight = 40;
            e.Alignment = DataGridViewContentAlignment.MiddleLeft;
            e.BackColor = Color.WhiteSmoke;
            e.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            e.ForeColor = Color.White;
            e.SelectionBackColor = Color.FromArgb(213, 199, 241);
            e.SelectionForeColor = SystemColors.HighlightText;
            e.WrapMode = DataGridViewTriState.False;
            base.RowHeadersDefaultCellStyle = e;
            base.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            base.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            base.RowHeadersWidth = 30;
            base.RowHeadersVisible = false;
            f.Alignment = DataGridViewContentAlignment.MiddleLeft;
            f.BackColor = clors.LightItemBackground;
            f.Font = new Font("Arial", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
            f.ForeColor = Color.Gray;
            f.Padding = new Padding(15, 0, 0, 0);
            f.SelectionBackColor = Color.FromArgb(232, 225, 247);
            f.SelectionForeColor = Color.Gray;
            base.RowsDefaultCellStyle = f;
            base.RowTemplate.Height = 40;
            BorderRadius = 13;
            HScrollBar hScrollBar = base.Controls.OfType<HScrollBar>().First();
            VScrollBar vScrollBar = base.Controls.OfType<VScrollBar>().First();
            hScrollBar.Scroll += trhtyjjyujyu;
            vScrollBar.Scroll += trhtyjjyujyu;
        }

        private void gtrh()
        {
            if (customizable)
            {
                return;
            }
            if (AppearanceStyle.theme == uuufteme.Dark)
            {
                GridBackgroundColor = clors.DarkItemBackground;
                DefaultCellBackColor = clors.DarkItemBackground;
                ColumnHeaderBackColor = clors.DarkActiveBackground;
                ColumnHeaderForceColor = Color.Gainsboro;
                CellForeColor = AppearanceStyle.LightTextColor;
                base.GridColor = AppearanceStyle.LightBackground;
                if (b)
                {
                    CellBackColor = kkgegea.gegeagge(clors.DarkActiveBackground, 5);
                    DefaultCellSelectionBackColor = kkgegea.gegeagge(AppearanceStyle.Neptune, 30);
                    CellSelectionForeColor = Color.White;
                }
                else
                {
                    DefaultCellSelectionBackColor = kkgegea.gegeagge(clors.DarkActiveBackground, 5);
                    CellSelectionForeColor = AppearanceStyle.LightTextColor;
                }
            }
            else
            {
                GridBackgroundColor = clors.LightItemBackground;
                DefaultCellBackColor = clors.LightItemBackground;
                ColumnHeaderBackColor = AppearanceStyle.Neptune;
                ColumnHeaderForceColor = Color.WhiteSmoke;
                CellForeColor = AppearanceStyle.LightTextColor;
                base.GridColor = Color.Gainsboro;
                if (b)
                {
                    CellBackColor = kkgegea.gegeagge(AppearanceStyle.Neptune, 80);
                    DefaultCellSelectionBackColor = kkgegea.gegeagge(AppearanceStyle.Neptune, 40);
                    CellSelectionForeColor = Color.White;
                }
                else
                {
                    DefaultCellSelectionBackColor = kkgegea.gegeagge(AppearanceStyle.Neptune, 80);
                    CellSelectionForeColor = AppearanceStyle.LightTextColor;
                }
            }
        }

        private void trhtyjjyujyu(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                s = true;
                Invalidate();
            }
            else
            {
                s = false;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!base.DesignMode)
            {
                gtrh();
            }
            if (base.ColumnHeadersHeight < 40)
            {
                HeadersHeight = 40;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (s)
            {
                ppwag.DrawBorderRadius(this, c, e.Graphics);
            }
        }
    }
}
