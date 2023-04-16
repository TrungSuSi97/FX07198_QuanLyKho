using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace TPH.LIS.App.AppCode
{
    public partial class ucDanhMucDichVu : UserControl
    {
        public ucDanhMucDichVu()
        {
            InitializeComponent();
        }
        [Category("Custom")]
        public string TenNhom
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        [Category("Custom")]
        public string MaLoaiDicVu { get; set; }
        [Category("Custom")]
        public bool IsCategory { get; set; }
        [Category("Custom")]
        public string CotGiaTri { get; set; }
        [Category("Custom")]
        public string CotHienThi { get; set; }
        [Category("Custom")]
        public EventHandler labelClick;
        private DataTable dataNhom;
        [Category("Custom")]
        Panel pnMan = new Panel();
        public DataTable DataList
        {
            set
            {
                pnMan = new Panel();
                pnMan.BackColor = Color.WhiteSmoke;
                this.Controls.Add(pnMan);
                pnMan.Size = this.Size;
                pnMan.BringToFront();

                flpNhom.Controls.Clear();

                if (value != null)
                {
                    int count = 0;
                    dataNhom = value;
                    foreach (DataRow dr in dataNhom.Rows)
                    {
                        count++;
                        AddObjectToPanel(flpNhom, string.Format("{0}_{1}_{2}", MaLoaiDicVu, (IsCategory ? "1" : "0"), dr[CotGiaTri].ToString()), dr[CotHienThi].ToString(), count);
                    }
                }
                MakeSameWithForControlInflowPanel(flpNhom);
                pnMan.Visible = false;
            }
        }
        private void AddObjectToPanel(FlowLayoutPanel fpl, string controlName, string controlText, int count)
        {
            LinkLabel lbl = new LinkLabel();
           // lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.AutoSize = false;
            // lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            lbl.Name = controlName.Trim();
            lbl.Text = controlText.ToUpper().Trim();
            if (labelClick != null)
            {
                lbl.Click += labelClick;
            }
            fpl.Controls.Add(lbl);
            lbl.Padding = new Padding(2);
            lbl.AutoSize = true;
        }
        private void MakeSameWithForControlInflowPanel(FlowLayoutPanel fpl)
        {
            int maxWidthlabel = 0;
            int labelheight = 0;
            foreach (Control ctrl in fpl.Controls)
            {
                if (ctrl is LinkLabel)
                {
                    if (ctrl.Width > maxWidthlabel)
                        maxWidthlabel = ctrl.Width;
                    labelheight = ctrl.Height;
                }
            }
            foreach (Control ctrl in fpl.Controls)
            {
                if (ctrl is LinkLabel)
                {
                    if (ctrl is LinkLabel)
                    {
                        var obj = (LinkLabel)ctrl;
                        obj.AutoSize = false;
                        obj.Width = maxWidthlabel;
                    }
                }
            }
            fpl.Refresh();
            this.AutoSize = false;
            //calculate item per line
            int numberItm = int.Parse((fpl.Width / (maxWidthlabel + 2)).ToString()[0].ToString());
            int nunberofline = (dataNhom.Rows.Count / numberItm);
            int currentHeight = (labelheight + 2) * nunberofline;
            // int currentHeight = fpl.Height;
            pnMan.Height = currentHeight + lblTitle.Height;
            fpl.AutoSize = false;
            fpl.Height = currentHeight;
            this.Height = currentHeight + lblTitle.Height;
        }
    }
}
