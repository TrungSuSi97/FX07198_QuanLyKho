using System;
using System.Linq;
using System.Windows.Forms;
using TPH.Data.HIS.Models;
using TPH.LIS.Common.Extensions;
using TPH.Data.HIS.HISDataCommon;
using System.ComponentModel;

namespace TPH.HIS.Controls
{
    public partial class ucFunctionConfig : UserControl
    {
        public ucFunctionConfig()
        {
            InitializeComponent();
        }
        private HisProvider HISID = 0;
        public string FunctionID = string.Empty;
        public string SetTitle
        {
            get { return ucGroupHeader1.GroupCaption; }
            set { ucGroupHeader1.GroupCaption = value; }
        }
        public bool UseHL7Field
        {
            get
            {
                return pnHL7Field.Visible;
            }
            set
            {
                pnHL7Field.Visible = value;
            }
        }
        /// <summary>
        /// Loại tham tham số: 0-Kết quả | 1-Valid | 2-Trạng thái
        /// </summary>
        public int LoaiThamSo { get; set; } = 0;
        /// <summary>
        /// Loại frame cho HL7: 0: Kết quả - 1: OBX_NTE - 2: PID_PV1
        /// </summary>
        [Description("Loại frame cho HL7: 0: Kết quả (OBX) - 1: ORC_NTE - 2: PID_PV1")]
        public int HL7Fame { get; set; } = 0;
        public void Load_Config()
        {
            //Chọn giá trị LIS
            if (LoaiThamSo == 1)
            {
                var listValidTraKQ = HISModelHelper.HISResultValidConfigList();
                ControlExtension.BindDataToCobobox(listValidTraKQ.ToList(), ref cboGiaTriLis, "Key", "Value");
            }
            else if (LoaiThamSo == 2)
            {
                var list = HISModelHelper.HisParaConfigList().ToList();
                ControlExtension.BindDataToCobobox(list.ToList(), ref cboGiaTriLis, "Key", "Value");
            }
            else
            {
                //pnHL7Field.Visible = true;
                var listTraKQ = HISModelHelper.HisResultBaseConfigList();
                ControlExtension.BindDataToCobobox(listTraKQ.ToList(), ref cboGiaTriLis, "Key", "Value");
            }
            //HL7 Frame properties
            if (HL7Fame == 0)
            {
                var obxList = HISModelHelper.HisHL7ResultOBX();
                ControlExtension.BindDataToCobobox(obxList.ToList(), ref cboHL7Filed, "Key", "Value");
            }
            else if (HL7Fame == 1)
            {
                var orcList = HISModelHelper.HisHL7ResultORCOBR();
                ControlExtension.BindDataToCobobox(orcList.ToList(), ref cboHL7Filed, "Key", "Value");
            }
            else if (HL7Fame == 2)
            {
                var pidList = HISModelHelper.HisHL7PID_PV();
                ControlExtension.BindDataToCobobox(pidList.ToList(), ref cboHL7Filed, "Key", "Value");
            }
            //Loại lệnh thực hiện
            var listLenh = CommonData.GetEnumValuesAndDescriptions<FunctionType>();
            ControlExtension.BindDataToCobobox(listLenh.ToList(), ref cboLoaiLenh, "Key", "Value");
        }
        private void btnChonGiaTriLis_Click(object sender, EventArgs e)
        {
            if (cboGiaTriLis.SelectedIndex > -1)
            {
                txtGiaTriLis.Text += (string.IsNullOrEmpty(txtGiaTriLis.Text) ? "" : ",") + cboGiaTriLis.SelectedValue.ToString().Trim();
            }
        }
        public void ClearData()
        {
            txtTenHam.Text = string.Empty;
            txtThamSo.Text = string.Empty;
            txtGiaTriLis.Text = string.Empty;
            cboLoaiLenh.SelectedIndex = -1;
            cboGiaTriLis.SelectedIndex = -1;
        }
        public void SetInfo(HisFunctionConfig hisFunction)
        {
            FunctionID = hisFunction.FunctionID;
            HISID = hisFunction.HisID;
            txtTenHam.Text = hisFunction.FunctionName;
            txtThamSo.Text = hisFunction.FunctionParaNames;
            txtGiaTriLis.Text = hisFunction.LISColumns;
            cboLoaiLenh.SelectedValue = (int)hisFunction.FunctionTypeID;
        }
        public HisFunctionConfig GetInfo()
        {
            var functionInfo = new HisFunctionConfig();
            functionInfo.HisID = HISID;
            functionInfo.FunctionID = FunctionID;
            functionInfo.FunctionName = txtTenHam.Text;
            functionInfo.FunctionParaNames = txtThamSo.Text;
            functionInfo.LISColumns = txtGiaTriLis.Text;
            functionInfo.FunctionTypeID = (cboLoaiLenh.SelectedValue == null ? FunctionType.StoreProcedure : (FunctionType)Enum.Parse(typeof(FunctionType), cboLoaiLenh.SelectedValue.ToString()));
            return functionInfo;
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            var f = new FrmCompareConfig();
            f.HISParaList = txtThamSo.Text;
            f.LISParaList = txtGiaTriLis.Text;
            f.SetLISValue(cboGiaTriLis.DataSource);
            f.ShowDialog();
            txtThamSo.Text = f.HISParaList;
            txtGiaTriLis.Text = f.LISParaList;
        }

        private void btnChonHL7_Click(object sender, EventArgs e)
        {
            if (cboHL7Filed.SelectedIndex > -1)
            {
                txtThamSo.Text += (string.IsNullOrEmpty(txtThamSo.Text) ? "" : ",") + cboHL7Filed.SelectedValue.ToString().Trim();
            }
        }

        private void cboHL7Filed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cboHL7Filed.SelectedIndex > -1)
                {
                    txtThamSo.Text += (string.IsNullOrEmpty(txtThamSo.Text) ? "" : ",") + cboHL7Filed.SelectedValue.ToString().Trim();
                    e.Handled = true;
                }
            }
        }
    }
}
