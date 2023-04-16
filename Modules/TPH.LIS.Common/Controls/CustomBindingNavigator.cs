using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomBindingNavigator : BindingNavigator
    {
        public CustomBindingNavigator()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}