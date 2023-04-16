using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomDatagridView : DataGridView
    {
        public CustomDatagridView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        [Category("CustomOption")]
        public bool CheckBoldColumn
        {
            get; set;
        }

        [Category("CustomOption")]
        public bool MarkOddEven
        {
            get; set;
        }

        [Category("CustomOption")]
        public bool AllignNumberText
        {
            get; set;
        }

        [Category("CustomOption")]
        public string AlignColumns
        {
            get; set;
        }
        [Category("CustomOption")]
        public DataGridViewContentAlignment TextAlign = DataGridViewContentAlignment.MiddleLeft;

        [Category("CustomOption")]
        public DataGridViewContentAlignment NumberAlign = DataGridViewContentAlignment.MiddleRight;

        private void CustomDatagridView_DataBindingComplete(
            object sender,
            DataGridViewBindingCompleteEventArgs e)
        {
            //if (this.RowCount > 0)
            //{
            //    var bold = false;
            //    var boldColName = string.Empty;
            //    foreach (DataGridViewColumn dc in this.Columns)
            //    {
            //        if (dc.ReadOnly)
            //        {
            //            dc.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            //        }

            //        if (dc.DataPropertyName.ToUpper().Contains("BOLD") && 
            //            dc.CellTemplate is DataGridViewCheckBoxCell)
            //        {
            //            bold = true;
            //            boldColName = dc.Name;
            //        }
            //    }

            //    for (var i = 0; i < RowCount; i++)
            //    {
            //        //Dánh dấu chẳn lẻ
            //        if (MarkOddEven)
            //        {
            //            if (i % 2 == 0)
            //            {
            //                Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            //            }
            //        }
            //        //Kiểm tra in đậm
            //        if (CheckBoldColumn)
            //        {
            //            if (bold)
            //            {
            //                if (this[boldColName, i].Value != null)
            //                {
            //                    if ((bool)this[boldColName, i].Value)
            //                    {
            //                        if (Rows[i].DefaultCellStyle.Font != null)
            //                        {
            //                            Rows[i].DefaultCellStyle.Font =
            //                                new Font(Rows[i].DefaultCellStyle.Font.FontFamily,
            //                                    Rows[i].DefaultCellStyle.Font.Size, FontStyle.Bold);
            //                        }
            //                        else
            //                        {
            //                            Rows[i].DefaultCellStyle.Font = new Font(SystemStypeConstant.DefaultFont,
            //                                SystemStypeConstant.DefaultFontSize, FontStyle.Bold);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (Rows[i].DefaultCellStyle.Font != null)
            //                        {
            //                            Rows[i].DefaultCellStyle.Font =
            //                                new Font(Rows[i].DefaultCellStyle.Font.FontFamily,
            //                                    Rows[i].DefaultCellStyle.Font.Size, FontStyle.Regular);
            //                        }
            //                        else
            //                        {
            //                            Rows[i].DefaultCellStyle.Font = new Font(SystemStypeConstant.DefaultFont,
            //                                SystemStypeConstant.DefaultFontSize, FontStyle.Regular);
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        //Canh lề
            //        if (AllignNumberText && AlignColumns.Length > 0)
            //        {
            //            var array = AlignColumns.Split(',');
            //            var total = array.Length;
            //            if (total <= 0) continue;

            //            for (var a = 0; a < total; a++)
            //            {
            //                if (string.IsNullOrWhiteSpace(array[a])) continue;

            //                try
            //                {
            //                    this[array[a], i].Style.Alignment =
            //                        IsNumeric(this[array[a], i].Value.ToString())
            //                            ? NumberAlign
            //                            : TextAlign;
            //                }
            //                catch
            //                {
            //                    // ignored
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private bool IsNumeric(string text)
        {
            return !string.IsNullOrEmpty(text) && Regex.IsMatch(text, @"^\s*\-?\d+(\.\d+)?\s*$");
        }
    }
}
