using System;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class ucNumberPosOfAnalyzerPlate : UserControl
    {
        public ucNumberPosOfAnalyzerPlate()
        {
            InitializeComponent();
        }
        public EventHandler UpdateRuntype { get; set; }
        public int Id = 0;
        private SampleRunType runType = SampleRunType.None;
        public SampleRunType RunType
        {
            get { return runType; }
            set
            {
                runType = value;
                SetBackground();
            }
        }
        public int VPos = 0;
        public int HPos = 0;

        public string PosNo
        {
            get { return lblPosNo.Text; }
            set { lblPosNo.Text = value; }
        }
        public string Barcode
        {
            get { return lblBarcode.Text; }
            set { lblBarcode.Text = value; }
        }
        public void SetPosInfo(string posNo, string barcodeName)
        {
            lblPosNo.Text = posNo;
            lblBarcode.Text = barcodeName;
        }
        private void SetBackground()
        {
            if (runType == SampleRunType.Result)
                pnPosNo.BackgroundImage = imageList1.Images[1];
            else if (runType == SampleRunType.QualityControl)
                pnPosNo.BackgroundImage = imageList1.Images[2];
            else if (runType == SampleRunType.Calibration)
                pnPosNo.BackgroundImage = imageList1.Images[3];
            else
                pnPosNo.BackgroundImage = imageList1.Images[0];
        }

        private void CallUpdate()
        {
            UpdateRuntype?.Invoke(this, new EventArgs());
        }
        private void emptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.None;
            PosNo = string.Empty;
            CallUpdate();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Result;
            PosNo = string.Empty;
            CallUpdate();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Calibration;
            PosNo = "A";
            CallUpdate();
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Calibration;
            PosNo = "B";
            CallUpdate();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Calibration;
            PosNo = "C";
            CallUpdate();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Calibration;
            PosNo = "D";
            CallUpdate();
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Calibration;
            PosNo = "E";
            CallUpdate();
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.Calibration;
            PosNo = "F";
            CallUpdate();
        }

        private void q1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.QualityControl;
            PosNo = "Q1";
            CallUpdate();
        }

        private void q2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.QualityControl;
            PosNo = "Q2";
            CallUpdate();
        }

        private void q3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.QualityControl;
            PosNo = "Q3";
            CallUpdate();
        }

        private void q4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.QualityControl;
            PosNo = "Q4";
            CallUpdate();
        }

        private void q5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.QualityControl;
            PosNo = "Q5";
            CallUpdate();
        }

        private void q6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunType = SampleRunType.QualityControl;
            PosNo = "Q6";
            CallUpdate();
        }

        private void lblPosNo_Click(object sender, EventArgs e)
        {

        }
    }
}
