using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClinicManagementSystem;

namespace CustomControl
{
    public partial class Custom_DatagridView : DataGridView
    {
        public Custom_DatagridView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private bool _CheckBoldColumn = false;
        [Category("CustomOption")]
        public bool CheckBoldColumn
        {
            get { return _CheckBoldColumn; }
            set { _CheckBoldColumn = value; }
        }

        private bool _MarkOddEven = true;
        [Category("CustomOption")]
        public bool MarkOddEven
        {
            get { return _MarkOddEven; }
            set { _MarkOddEven = value; }
        }

        private bool _AllignNumberText = false;
        [Category("CustomOption")]
        public bool AllignNumberText
        {
            get { return _AllignNumberText; }
            set { _AllignNumberText = value; }
        }

        private string _AlignColumns = "";

        [Category("CustomOption")]
        public string AlignColumns
        {
            get { return _AlignColumns; }
            set { _AlignColumns = value; }
        }
        DataGridViewContentAlignment _TextAlign = DataGridViewContentAlignment.MiddleLeft;
        [Category("CustomOption")]
        public DataGridViewContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; }
        }

        DataGridViewContentAlignment _NumberAlign = DataGridViewContentAlignment.MiddleRight;
        [Category("CustomOption")]
        public DataGridViewContentAlignment NumberAlign
        {
            get { return _NumberAlign; }
            set { _NumberAlign = value; }
        }

        private void CustomDatagridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.RowCount > 0)
            {
                bool _Bold = false;
                string _BoldColName = "";
                foreach (DataGridViewColumn dc in this.Columns)
                {
                    if (dc.ReadOnly)
                    {
                        dc.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                    if (dc.DataPropertyName.ToLower().Contains("bold") && dc.CellTemplate is DataGridViewCheckBoxCell)
                    {
                        _Bold = true;
                        _BoldColName = dc.Name;
                    }
                }
                for (int i = 0; i < RowCount; i++)
                {
                    //Dánh dấu chẳn lẻ
                    if (_MarkOddEven)
                    {
                        if (i % 2 == 0)
                        {
                            Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
                        }
                    }
                    //Kiểm tra in đậm
                    if (CheckBoldColumn)
                    {
                        if (_Bold)
                        {
                            if (this[_BoldColName, i].Value != null)
                            {
                                if ((bool)this[_BoldColName, i].Value)
                                {
                                    if (Rows[i].DefaultCellStyle.Font != null)
                                    {
                                        Rows[i].DefaultCellStyle.Font = new Font(Rows[i].DefaultCellStyle.Font.FontFamily, Rows[i].DefaultCellStyle.Font.Size, FontStyle.Bold);
                                    }
                                    else
                                    {
                                        Rows[i].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);
                                    }
                                }
                                else
                                {
                                    if (Rows[i].DefaultCellStyle.Font != null)
                                    {
                                        Rows[i].DefaultCellStyle.Font = new Font(Rows[i].DefaultCellStyle.Font.FontFamily, Rows[i].DefaultCellStyle.Font.Size, FontStyle.Regular);
                                    }
                                    else
                                    {
                                        Rows[i].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);
                                    }
                                }
                            }
                        }
                    }

                    //Canh lề
                    if (_AllignNumberText && _AlignColumns.Length > 0)
                    {
                        string[] _array = _AlignColumns.Split(',');
                        if (_array.Length > 0)
                        {
                            for (int a = 0; a < _array.Length; a++)
                            {
                                if (_array[a] != "")
                                {
                                    try
                                    {
                                        if (ProcessServices.IsNumeric(this[_array[a], i].Value.ToString()))
                                        {
                                            this[_array[a], i].Style.Alignment = _NumberAlign;
                                        }
                                        else
                                        {
                                            this[_array[a], i].Style.Alignment = _TextAlign;
                                        }
                                    }
                                    catch
                                    { }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
