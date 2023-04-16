using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPH.Controls;
using TPH.Data.HIS.HISDataCommon;
using TPH.Lab.BusinessService.Models;
using TPH.Lab.Middleware.LISConnect.Controls;
using TPH.LIS.App.AppCode;

namespace TPH.LIS.App.Settings.HeThong
{
    public partial class FrmCauHinh_MappingHIS : FrmTemplate
    {
        List<FlyoutPanel> flpAdded = new List<FlyoutPanel>();
        FlyoutPanel activedFlp;
        public HisProvider currentHis = HisProvider.Default;
        internal string ActiveSearchValue = string.Empty;

        ucTestCodeHisMapping ucTestCode;
        public FrmCauHinh_MappingHIS()
        {
            InitializeComponent();
            pnmain.BackColor = CommonAppColors.ColorMainAppFormColor;
            label1.BackColor = CommonAppColors.ColorMainAppFormColor;
            label1.ForeColor = CommonAppColors.ColorTextCaption;

        }
        private void Load_HisProvider()
        {
            var list = CommonData.GetEnumValuesAndDescriptions<HisProvider>().Where(x => CommonAppVarsAndFunctions.allWorkingHis.Contains(x.Key));
            cboChonHIS.ComboBox.DataSource = list.ToList();
            cboChonHIS.ComboBox.ValueMember = "Key";
            cboChonHIS.ComboBox.DisplayMember = "Value";
            cboChonHIS.ComboBox.SelectedIndex = 0;
            cboChonHIS.SelectedIndexChanged += CboChonHIS_SelectedIndexChanged;
            SetHISID();
        }
        private void SetHISID()
        {
            if (cboChonHIS.SelectedIndex > -1)
            {
                currentHis = (HisProvider)Enum.Parse(typeof(HisProvider), CommonAppVarsAndFunctions.allWorkingHis.Where(x => x.Equals(int.Parse(cboChonHIS.ComboBox.SelectedValue.ToString()))).FirstOrDefault().ToString());
            }
            else
                currentHis = HisProvider.Default;
        }
        private void CboChonHIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHISID();
            ShowFlyPanel("noname");
            flpAdded = new List<FlyoutPanel>();
        }

        private void ShowFlyPanel(string flpName)
        {
            foreach (FlyoutPanel item in flpAdded)
            {
                if (item.Name.Equals(flpName, StringComparison.OrdinalIgnoreCase))
                {
                    item.Size = pnmain.Size;
                    item.ShowPopup();
                }
                else
                    item.HidePopup();
            }
        }
        private FlyoutPanel ResizeAuto()
        {
            FlyoutPanel activedFlyout = null;
            foreach (FlyoutPanel item in flpAdded)
            {
                if (item.IsPopupOpen)
                {
                    activedFlyout = new FlyoutPanel();
                    activedFlyout = item;
                }
                item.HidePopup();
                item.Hide();
            }
            return activedFlyout;
        }
        private bool CheckExistsFlyPanel(string flpName)
        {
            foreach (FlyoutPanel item in flpAdded)
            {
                if (item.Name.Equals(flpName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
        private void AddOrShowFlyoutPanel(string flpName, HisMappingCategory currentCategory)
        {
            if (CheckExistsFlyPanel(flpName))
                ShowFlyPanel(flpName);
            else
            {
                if (currentCategory == HisMappingCategory.DichVuXetNghiem)
                {
                    ucTestCode = new ucTestCodeHisMapping();
                    ucTestCode.Name = string.Format("uc{0}", flpName);
                    ucTestCode.currentHis = currentHis;
                    ucTestCode.currentCategory = currentCategory;
                    ucTestCode.UserId = CommonAppVarsAndFunctions.UserID;
                    LabServices_Helper.SetControlColor(ucTestCode);
                    activedFlp = new FlyoutPanel();
                    activedFlp.Name = flpName;
                    activedFlp.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Left;
                    activedFlp.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Slide;

                    activedFlp.Controls.Add(ucTestCode);
                    activedFlp.ParentForm = this;
                    flpAdded.Add(activedFlp);
                    ucTestCode.LoadCauHinh();
                    ucTestCode.Dock = DockStyle.Fill;
                    activedFlp.Size = pnmain.Size;
                    activedFlp.OwnerControl = pnmain;
                    activedFlp.ShowPopup();
                }
                else
                {
                    var uc = new ucNormalHisMapping();
                    uc.Name = string.Format("uc{0}", flpName);
                    uc.currentHis = currentHis;
                    uc.currentCategory = currentCategory;
                    uc.UserId = CommonAppVarsAndFunctions.UserID;
                    LabServices_Helper.SetControlColor(uc);
                    activedFlp = new FlyoutPanel();
                    activedFlp.Name = flpName;
                    activedFlp.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Left;
                    activedFlp.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Slide;

                    activedFlp.Controls.Add(uc);
                    activedFlp.ParentForm = this;
                    flpAdded.Add(activedFlp);
                    uc.LoadCauHinh();
                    uc.Dock = DockStyle.Fill;
                    activedFlp.Size = pnmain.Size;
                    activedFlp.OwnerControl = pnmain;
                    activedFlp.ShowPopup();
                }
            }
        }
        private void FrmCauHinh_MappingHIS_Load(object sender, EventArgs e)
        {
            Load_HisProvider();
            if(!string.IsNullOrEmpty(ActiveSearchValue))
            {
                cboChonHIS.ComboBox.SelectedValue = (int)currentHis;
                btnDmXetNghiem_Click(sender, e);
                ucTestCode.AutoFilterMaDichVu = ActiveSearchValue;
            }
        }

        private void btnDmXetNghiem_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmXetNghiem", HisMappingCategory.DichVuXetNghiem);
            HightLightButton(btnDmXetNghiem);
        }

        private void btnDmNhanVien_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmNhanVien", HisMappingCategory.NhanVien);
            HightLightButton((Button)sender);
        }

        private void btnDmDoiTuong_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmDoiTuong", HisMappingCategory.DoiTuong);
            HightLightButton((Button)sender);
        }

        private void btnDmKhoa_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmKhoa", HisMappingCategory.KhoaPhong);
            HightLightButton((Button)sender);
        }

        private void btnDmPhong_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmPhong", HisMappingCategory.Phong);
            HightLightButton((Button)sender);
        }

        private void btnDmChanDoan_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmChanDoan", HisMappingCategory.ChanDoan);
            HightLightButton((Button)sender);
        }

        private void btnDmMayXetNghiem_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmMayXetNghiem", HisMappingCategory.MayXetNghiem);
            HightLightButton((Button)sender);
        }

        private void btnDmSinhLy_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmSinhLy", HisMappingCategory.SinhLy);
            HightLightButton((Button)sender);
        }

        private void FrmCauHinh_MappingHIS_SizeChanged(object sender, EventArgs e)
        {
            var itm = ResizeAuto();
            if (itm != null)
            {
                activedFlp = itm;
                var tim = new Timer();
                tim.Interval = 500;
                tim.Tick += Tim_Tick;
                tim.Start();
            }
        }
        private void Tim_Tick(object sender, EventArgs e)
        {
            var tm = (Timer)sender;
            tm.Stop();
            if (activedFlp != null)
            {
                activedFlp.Size = pnmain.Size;
                activedFlp.ShowPopup();
            }
            tm.Dispose();
        }

        private void FrmCauHinh_MappingHIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SizeChanged -= FrmCauHinh_MappingHIS_SizeChanged;
        }

        private void btnDMCongTy_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmCongTy", HisMappingCategory.CongTyHopDong);
            HightLightButton((Button)sender);
        }

        private void btnDanhMucLoaiMau_Click(object sender, EventArgs e)
        {
            AddOrShowFlyoutPanel("DmLoaiMau", HisMappingCategory.LoaiMau);
            HightLightButton((Button)sender);
        }
    }
}
