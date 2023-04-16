using System;
using System.Drawing;
using System.Windows.Forms;
using TPH.Controls;
using TPH.LIS.Common.Extensions;

namespace TPH.LIS.Common.Controls
{
    public partial class ucPictureTool : UserControl
    {
        public ucPictureTool()
        {
            InitializeComponent();
            panel2.BackColor = CommonAppColors.ColorMainAppColor;
        }
        public Size KichCoHinh = new Size(646, 380);
        public event EventHandler ThemHinh;
        public event EventHandler XoaHinh;
        public Image GetImage { get { return pbHinhKetQua.Image; } }
        public string GetImageLocation { get { return pbHinhKetQua.ImageLocation; } }
        public Image SetImage { set { pbHinhKetQua.Image = value; } }
        public string SetImageLocation { set { pbHinhKetQua.ImageLocation = value; } }
        public void Lock_UnlockFunction(bool isLock)
        {
            btnPaste.Enabled = !isLock;
            btnThemHinh.Enabled = !isLock;
            btnXoaHinh.Enabled = !isLock;
        }
        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            ControlExtension.LoadImage_ToPicturebox(pbHinhKetQua, KichCoHinh);
            this.ThemHinh?.Invoke(this, e);
        }

        private void btnXoaHinh_Click(object sender, EventArgs e)
        {
            pbHinhKetQua.Image = null;
            this.XoaHinh?.Invoke(this, e);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            var obj = Clipboard.GetImage();
            if (obj != null)
            {
                var img2 = GraphicSupport.ResizeImage_NoAutoScale(Clipboard.GetImage(), KichCoHinh);
                pbHinhKetQua.Image = img2;
            }
            else
                CustomMessageBox.MSG_Information_OK("Không có thông tin hình ảnh trong clipboard!");
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            var f = new Common.Controls.FrmZoomImage();
            f.pbImage.Image = pbHinhKetQua.Image;
            f.ShowDialog();
        }
    }
}
