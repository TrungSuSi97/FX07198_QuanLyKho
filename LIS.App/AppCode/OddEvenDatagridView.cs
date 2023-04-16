using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace ClinicManagementSystem
{
    public partial class OddEvenDatagridView : DataGridView
    {
        public OddEvenDatagridView()
        {
            InitializeComponent();
        }
        private bool IsNumeric(string text)
        {
            return string.IsNullOrEmpty(text) ? false :
                    Regex.IsMatch(text, @"^\s*\-?\d+(\.\d+)?\s*$");
        }

        private DataGridViewContentAlignment _NumberAlign = DataGridViewContentAlignment.MiddleCenter;

        public DataGridViewContentAlignment NumberAlign
        {
            get { return _NumberAlign; }
            set { _NumberAlign = value; }
        }

        private DataGridViewContentAlignment _TextAlign = DataGridViewContentAlignment.MiddleLeft;

        public DataGridViewContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; }
        }
        private string _FormatedColumns = "";

        public string FormatedColumns
        {
            get { return _FormatedColumns; }
            set { _FormatedColumns = value; }
        }
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            if (this.RowCount > 0)
            {
                for (int i = 0; i < RowCount; i++)
                {
                    if (i % 2 != 0)
                    {
                        Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 250, 255);
                    }
                }
            }
        }
    }
}
