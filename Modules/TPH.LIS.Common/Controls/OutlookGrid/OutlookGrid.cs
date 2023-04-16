// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace OutlookStyleControls
{
    #region implementation of the OutlookGrid!
    public partial class OutlookGrid : DataGridView
    {
        #region OutlookGrid constructor
        public OutlookGrid()
        {
            InitializeComponent();

            // very important, this indicates that a new default row class is going to be used to fill the grid
            // in this case our custom OutlookGridRow class
            base.RowTemplate = new OutlookGridRow();
            this.groupTemplate = new OutlookgGridDefaultGroup();

        }
        #endregion OutlookGrid constructor

        #region OutlookGrid property definitions
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewRow RowTemplate
        {
            get { return base.RowTemplate;}
        }

        private IOutlookGridGroup groupTemplate;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IOutlookGridGroup GroupTemplate
        {
            get
            {
                return groupTemplate;
            }
            set
            {
                groupTemplate = value;
            }
        }

        private Image iconCollapse;
        [Category("Appearance")]
        public Image CollapseIcon
        {
            get { return iconCollapse; }
            set { iconCollapse = value; }
        }

        private string itemsText = "item";
        [Category("Appearance")]
        public string ItemsText
        {
            get { return itemsText; }
            set { itemsText = value; }
        }

        private Image iconExpand;
        [Category("Appearance")]
        public Image ExpandIcon
        {
            get { return iconExpand; }
            set { iconExpand = value; }
        }

        private string sortExpression;
        [Category("Appearance")]
        public string SortExpression
        {
            get { return sortExpression; }
            set { sortExpression = value; }
        }

        private DataSourceManager dataSource;
        public new object DataSource
        {
            get
            {
                if (dataSource == null) return null;

                // special case, datasource is bound to itself.
                // for client it must look like no binding is set,so return null in this case
                if (dataSource.DataSource.Equals(this)) return null;

                // return the origional datasource.
                return dataSource.DataSource;
            }
        }
        private object _binData_Source;

        public object BinData_Source
        {
            get { return _binData_Source; }
            set { _binData_Source = value; }
        }

        #endregion OutlookGrid property definitions

        #region OutlookGrid new methods
        public void CollapseAll()
        {
            SetGroupCollapse(true);
        }

        public void ExpandAll()
        {
            SetGroupCollapse(false);
        }

        public void ClearGroups()
        {
            groupTemplate.Column = null; //reset
            FillGrid(null);
        }

        public void Set_DataToGrid(DataTable dataDource, DataGridViewColumn dcSort, string sortColumns)
        {
            DataGridViewColumn[] dgc = new DataGridViewColumn[this.Columns.Count];
            for (int i = 0; i < this.Columns.Count; i++)
            {
                dgc[i] = (DataGridViewColumn)this.Columns[i].Clone();
                var dataGridViewColumn = dgc[i];
                if (dataGridViewColumn != null)
                {
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                    //dataGridViewColumn.Resizable = DataGridViewTriState.True;
                }

            }
            // first clear any previous bindings
            this.BindData(null, null);
            this.Columns.AddRange(dgc);
            // example of unbound items
            OutlookGridRow outlookRow = new OutlookGridRow();
            if (this.Rows.Count != 0)
                this.Rows.Clear();
            foreach (DataRow dr in dataDource.Rows)
            {
                object[] val = new object[dgc.Length];
                for (int a = 0; a < dgc.Length; a++)
                {
                    //foreach (DataColumn dc in dataDource.Columns)
                    //{
                    //    if (dgc[a].DataPropertyName.ToLower().Trim().Equals(dc.ColumnName.ToLower().Trim()))
                    //    {
                            val[a] = dr[dgc[a].DataPropertyName];
                    //        break;
                    //    }
                    //}
                }
                // notice that the outlookgrid only works with OutlookGridRow objects
                outlookRow = new OutlookGridRow();
                outlookRow.CreateCells(this, val);
                this.Rows.Add(outlookRow);
            }
            //DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            //dataGridViewCellStyle2.BackColor = this.DefaultCellStyle.BackColor;
            //dataGridViewCellStyle2.Font = new System.Drawing.Font(this.DefaultCellStyle.Font.Name, 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //dataGridViewCellStyle2.ForeColor = this.DefaultCellStyle.ForeColor;
            //dataGridViewCellStyle2.SelectionBackColor = this.DefaultCellStyle.SelectionBackColor;
            //dataGridViewCellStyle2.SelectionForeColor = this.DefaultCellStyle.SelectionForeColor;
            //this.DefaultCellStyle = dataGridViewCellStyle2;

            //  this.AlternatingRowsDefaultCellStyle = this.DefaultCellStyle;
            // set the column to be grouped
            // this must always be done before sorting
            this.GroupTemplate.Column = this.Columns[dcSort.Index];
            this.ExpandAll();
            this.SortExpression = sortColumns;
            this.Sort(dcSort, System.ComponentModel.ListSortDirection.Ascending);
            this._binData_Source  = new DataTable("Data");
            _binData_Source = dataDource;
        }
        public void BindData(object dataSource, string dataMember)
        {
            this.DataMember = DataMember;
            if (dataSource == null)
            {
                this.dataSource = null;
                Columns.Clear();
            }
            else
            {
                this.dataSource = new DataSourceManager(dataSource, dataMember);
                SetupColumns();
                FillGrid(null);
            }
        }
        public override void Sort(System.Collections.IComparer comparer)
        {
            if (dataSource == null) // if no datasource is set, then bind to the grid itself
                dataSource = new DataSourceManager(this, null);
            dataSource.Sort(comparer);
            FillGrid(groupTemplate);
        }


        public override void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
        {
            if (dataSource == null) // if no datasource is set, then bind to the grid itself
                dataSource = new DataSourceManager(this, null);

            dataSource.Sort(new OutlookGridRowComparer(dataGridViewColumn.Index, direction));
            FillGrid(groupTemplate);
        }
        #endregion OutlookGrid new methods

        #region OutlookGrid event handlers
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            OutlookGridRow row = (OutlookGridRow)base.Rows[e.RowIndex];
            if (row.IsGroupRow)
                e.Cancel = true;
            else
                base.OnCellBeginEdit(e);
        }
        protected override void OnCellParsing(DataGridViewCellParsingEventArgs e)
        {
            OutlookGridRow row = (OutlookGridRow)base.Rows[e.RowIndex];
            if (row.IsGroupRow)
                e.ParsingApplied = false;
            else
                base.OnCellParsing(e);
        }
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
        }
        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                OutlookGridRow row = (OutlookGridRow)base.Rows[e.RowIndex];
                if (row.IsGroupRow)
                {
                    row.Group.Collapsed = !row.Group.Collapsed;

                    //this is a workaround to make the grid re-calculate it's contents and backgroun bounds
                    // so the background is updated correctly.
                    // this will also invalidate the control, so it will redraw itself
                    row.Visible = false;
                    row.Visible = true;
                    return;
                }
            }
            base.OnCellClick(e);
        }

        // the OnCellMouseDown is overriden so the control can check to see if the
        // user clicked the + or - sign of the group-row
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            OutlookGridRow row = (OutlookGridRow)base.Rows[e.RowIndex];
            if (row.IsGroupRow && row.IsIconHit(e))
            {
                System.Diagnostics.Debug.WriteLine("OnCellMouseDown " + DateTime.Now.Ticks.ToString());
                row.Group.Collapsed = !row.Group.Collapsed;

                //this is a workaround to make the grid re-calculate it's contents and backgroun bounds
                // so the background is updated correctly.
                // this will also invalidate the control, so it will redraw itself
                row.Visible = false;
                row.Visible = true;
            }
            else
                base.OnCellMouseDown(e);
        }
        #endregion OutlookGrid event handlers

        #region Grid Fill functions
        private void SetGroupCollapse(bool collapsed)
        {
            if (Rows.Count == 0) return;
            if (groupTemplate == null) return;

            // set the default grouping style template collapsed property
            groupTemplate.Collapsed = collapsed;

            // loop through all rows to find the GroupRows
            foreach (OutlookGridRow row in Rows)
            {
                if (row.IsGroupRow)
                    row.Group.Collapsed = collapsed;
            }

            // workaround, make the grid refresh properly
            Rows[0].Visible = !Rows[0].Visible;
            Rows[0].Visible = !Rows[0].Visible;
        }

        private void SetupColumns()
        {
            ArrayList list;

            // clear all columns, this is a somewhat crude implementation
            // refinement may be welcome.
            Columns.Clear();

            // start filling the grid
            if (dataSource == null)
                return;
            else
                list = dataSource.Rows;
            if (list.Count <= 0) return;

            foreach (string c in dataSource.Columns)
            {
                int index;
                DataGridViewColumn column = Columns[c];
                if (column == null)
                    index = Columns.Add(c, c);
                else
                    index = column.Index;
            //    Columns[index].SortMode = DataGridViewColumnSortMode.Programmatic; // always programmatic!
            }

        }

        /// <summary>
        /// the fill grid method fills the grid with the data from the DataSourceManager
        /// It takes the grouping style into account, if it is set.
        /// </summary>
        private void FillGrid(IOutlookGridGroup groupingStyle)
        {

            ArrayList list;
            OutlookGridRow row;
            if (this.Rows.Count > 0)
                this.Rows.Clear();

            // start filling the grid
            if (dataSource == null) 
                return; 
            else
                list = dataSource.Rows;
            if (list.Count <= 0) return;
            else
            {
                if (sortExpression != "")
                {
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn dgv in this.Columns)
                    {
                        //,CLSOrder, MaPhanLoai,ThuTuIn,MaNhomCLS
                        if (dgv.CellTemplate is DataGridViewCheckBoxCell)
                            dt.Columns.Add(dgv.DataPropertyName, typeof(bool));
                        else if (dgv.DataPropertyName.ToLower().Trim().Equals("showorder")
                            || dgv.DataPropertyName.ToLower().Trim().Equals("ThuTuIn")
                            || dgv.DataPropertyName.ToLower().Trim().Equals("sapxep")
                            || dgv.DataPropertyName.ToLower().Trim().Equals("CLSOrder") 
                            || dgv.DataPropertyName.ToLower().Trim().Equals("sortorder") 
                            ||dgv.DataPropertyName.ToLower().Trim().Equals("printorder"))
                            dt.Columns.Add(dgv.DataPropertyName, typeof(int));
                        else 
                            dt.Columns.Add(dgv.DataPropertyName, typeof(string));
                    }
                    //readd datata

                    foreach (DataSourceRow r in list)
                    {
                        int _colCoun = -1;
                        DataRow dr = dt.NewRow();
                        foreach (object obj in r)
                        {
                            _colCoun++;
                            dr[_colCoun] = obj;
                        }
                        dt.Rows.Add(dr);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = sortExpression;
                        dt = dv.ToTable();
                        list.Clear();
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt.Columns.Count - 1; j++)
                            {
                                list.Add(dt.Rows[i][j]);
                            }
                        }

                        DataSourceManager d = new DataSourceManager(dt, null);
                        list = d.Rows;
                    }

                }
            }
            // this block is used of grouping is turned off
            // this will simply list all attributes of each object in the list
            if (groupingStyle == null)
            {
                foreach (DataSourceRow r in list)
                {
                    row = (OutlookGridRow) this.RowTemplate.Clone();
                    int _aCount = -1;
                    foreach (object obj in r)
                    {
                        _aCount++;
                        DataGridViewCell cell = (DataGridViewCell)Columns[_aCount].CellTemplate.Clone();
                        cell.Value = obj;
                        row.Cells.Add(cell);
                    }
                    Rows.Add(row);
                }
            }

            // this block is used when grouping is used
            // items in the list must be sorted, and then they will automatically be grouped
            else
            {
                IOutlookGridGroup groupCur = null;
                object result = null;
                int counter = 0; // counts number of items in the group

                foreach (DataSourceRow r in list)
                {
                    row = (OutlookGridRow)this.RowTemplate.Clone();
                    result = r[groupingStyle.Column.Index];
                    if (groupCur != null && groupCur.CompareTo(result) == 0) // item is part of the group
                    {
                        row.Group = groupCur;
                        counter++;
                    }
                    else // item is not part of the group, so create new group
                    {
                        if (groupCur != null)
                            groupCur.ItemCount = counter;

                        groupCur = (IOutlookGridGroup)groupingStyle.Clone(); // init
                        groupCur.Value = result;
                        row.Group = groupCur;
                        row.IsGroupRow = true;
                        row.Height = groupCur.Height;
                        object[] objAdd = new object[r.Count];
                        int _bCount =-1;
                        foreach (object obj in r)
                        {
                            _bCount++;
                            objAdd[_bCount] = obj;
                        }

                        row.CreateCells(this, objAdd);
                        Rows.Add(row);

                        // add content row after this
                        row = (OutlookGridRow)this.RowTemplate.Clone();
                        row.Group = groupCur;
                        counter = 1; // reset counter for next group
                    }

                    int _cCount = -1;
                    foreach (object obj in r)
                    {
                        _cCount++;
                        DataGridViewCell cell = (DataGridViewCell)Columns[_cCount].CellTemplate.Clone();
                        cell.Value = obj;
                        row.Cells.Add(cell);
                    }
                    Rows.Add(row);
                    groupCur.ItemCount = counter;
                }
            }

        }
        #endregion Grid Fill functions
    }
    #endregion implementation of the OutlookGrid!
}
