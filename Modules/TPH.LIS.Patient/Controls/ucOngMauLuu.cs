using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.LIS.Patient.Controls
{
    public partial class ucOngMauLuu : UserControl
    {
        public ucOngMauLuu()
        {
            InitializeComponent();
        }
        public Color TubeColor
        {
            get { return pnTubeColor.BackColor; }
            set { pnTubeColor.BackColor = value; }
        }
        public bool VisibleTube
        {
            get { return pnTubeBody.Visible; }
            set
            {
                pnTubeBody.Visible = value;
                pnTubeColor.Visible = value;
            }
        }
        public string SetSampleID
        {
            get { return lblSampleID.Text; }
            set { lblSampleID.Text = value; }
        }
    }
}
