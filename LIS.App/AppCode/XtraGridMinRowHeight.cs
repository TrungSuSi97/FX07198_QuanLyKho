using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.Handler;
using System;

namespace MinRowHeightXtraGrid
{
    public class MinRowHeightGridControl : GridControl
    {
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridViewInfoRegistrator());
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
    public class MyGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return MinRowHeightGridView.MinRowHeightName; } }
        public override BaseView CreateView(GridControl grid)
        {
            return new MinRowHeightGridView(grid as GridControl);
        }
        public override BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new MinRowHeightGridViewInfo(view as MinRowHeightGridView);
        }
        public override BaseViewHandler CreateHandler(BaseView view)
        {
            return new GridHandler(view as GridView);
        }
    }

    public class MinRowHeightGridView : GridView
    {
        public const string MinRowHeightName = "MinRowHeightGridView";
        public MinRowHeightGridView(GridControl grid) : base(grid) { }
        public MinRowHeightGridView()
        {
        }
        public MinRowHeightGridView(GridView gridView) : base(gridView.GridControl) {  }
        //public override bool Editable
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}
        protected override string ViewName { get { return MinRowHeightName; } }
    }
    public class MinRowHeightGridViewInfo : GridViewInfo
    {
        public MinRowHeightGridViewInfo(MinRowHeightGridView view) : base(view) { }
        protected override int CalcMinRowHeight()
        {
            return Convert.ToInt32(PaintAppearance.Row.CalcTextSize(GInfo.Cache, "Gq", int.MaxValue).Width );
        }
    }
}