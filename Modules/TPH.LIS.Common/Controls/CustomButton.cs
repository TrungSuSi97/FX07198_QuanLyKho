using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace TPH.LIS.Common.Controls
{
    public partial class CustomButton : DevExpress.XtraEditors.SimpleButton
    {
        public CustomButton()
        {
            InitializeComponent();
            // _oldColor = ForeColor;
         
        }

        private Color _oldColor;

        private ContentAlignment imageAlign = ContentAlignment.TopLeft;
        public ContentAlignment ImageAlign
        {
            get { return imageAlign; }
            set
            {
                imageAlign = value;
                switch (imageAlign)
                {
                    case ContentAlignment.BottomCenter:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomCenter;
                        break;
                    case ContentAlignment.BottomLeft:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomLeft;
                        break;
                    case ContentAlignment.BottomRight:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.BottomRight;
                        break;
                    case ContentAlignment.MiddleCenter:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
                        break;
                    case ContentAlignment.MiddleLeft:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
                        break;
                    case ContentAlignment.MiddleRight:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
                        break;
                    case ContentAlignment.TopCenter:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
                        break;
                    case ContentAlignment.TopLeft:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.TopLeft;
                        break;
                    case ContentAlignment.TopRight:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.TopRight;
                        break;
                    default:
                        ImageLocation = DevExpress.XtraEditors.ImageLocation.Default;
                        break;
                }
            }
        }
        private ContentAlignment textAlign = ContentAlignment.TopLeft;
        public ContentAlignment TextAlign
        {
            get { return textAlign; }
            set { textAlign = (int)value < 1 ? ContentAlignment.TopLeft : value; }
        }
        private bool useVisualStyleBackColor = false;
        private AutoSizeMode autoSizeMode = AutoSizeMode.GrowOnly;
        public AutoSizeMode AutoSizeMode
        {
            get { return autoSizeMode; }
            set { autoSizeMode = value;
            }
        }
        private TextImageRelation textImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
        public TextImageRelation TextImageRelation
        {
            get { return textImageRelation; }
            set { textImageRelation = value; }
        }
        private FlatStyle flatStyle = FlatStyle.Standard;
        public FlatStyle FlatStyle
        {
            get { return flatStyle; }
            set { flatStyle = value; }
        }
        public bool UseVisualStyleBackColor
        {
            get { return useVisualStyleBackColor; }
            set { useVisualStyleBackColor = value; }
        }

        private int buttonStyle = -1;
        [Description("-1: Bình thường - 0: Thêm - 1: Sửa - 2: Xóa - 3: Hủy - 4: Lưu - 5: Làm mới - 6: Đồng ý - 7: Đóng - 8: In - 9: Duyệt - 10: Bỏ duyệt - 11: Xuất Excel - 12: Tìm kiếm")]
        /// <summary>
        /// -1: Bình thường - 0: Thêm - 1: Sửa - 2: Xóa - 3: Hủy - 4: Lưu - 5: Làm mới - 6: Đồng ý - 7: Đóng - 8: In - 9: Duyệt - 10: Bỏ duyệt - 11: Xuất Excel - 12: Tìm kiếm
        /// </summary>
        public int SetButtonStyle
        {
            get { return buttonStyle; }
            set
            {
                buttonStyle = value;
                SetImage();
            }
        }
        private bool imageSizeSmall = true;

        [Description("True: 16x16 - False: 24x24")]
        /// <summary>
        /// True: 16x16 - False: 24x24
        /// </summary>
        public bool ImageSizeSmall
        {
            get { return imageSizeSmall; }
            set
            {
                imageSizeSmall = value;
                SetImage();
            }
        }
        public string ImageKey { get; set; }
        public bool UseHightLight { get; set; }
        private FlatButtonAppearance flatAppearance;

        public FlatButtonAppearance FlatAppearance { get { return flatAppearance?? new Button().FlatAppearance; } set { flatAppearance = value; } }

        public Color BackColorHover { get; internal set; }
        public Color BackgroundColor { get; internal set; }
        public Color BorderColor { get; internal set; }
        public int BorderRadius { get; internal set; }
        public int BorderSize { get; internal set; }
        public Color ForceColorHover { get; internal set; }
        public Color TextColor { get; internal set; }

        //public int TabIndex { get; set; }
        //public EventHandler Click { get; set; }
        private Image lastImage = null;
        private void SetImage()
        {
            if (buttonStyle > -1 && buttonStyle < 12)
            {
                if (imageSizeSmall)
                {
                    ImageList = imageCollection16;
                }
                else
                {
                    ImageList = imageCollection24;
                }
                ImageIndex = buttonStyle;
                lastImage = Image;
                Image = null;
                this.Invalidate();
            }
            else
            {
                ImageList = null;
                ImageIndex = -1;
                if (lastImage != null)
                {
                    Image = lastImage;
                    lastImage = null;
                }
                this.Invalidate();
            }
        }

        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}

        //protected override void OnEnter(EventArgs e)
        //{
        //    base.OnEnter(e);
        //    if (UseHightLight)
        //    {
        //        if (this.ForeColor == _oldColor)
        //        {
        //            _oldColor = this.ForeColor;
        //            //this.ForeColor = Color.Crimson;
        //            this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
        //        }
        //    }
        //}

        //protected override void OnLeave(EventArgs e)
        //{
        //    base.OnLeave(e);
        //    if (UseHightLight)
        //    {
        //        //this.ForeColor = _oldColor;
        //        this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
        //    }
        //}

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    if (UseHightLight)
        //    {
        //        _oldColor = this.ForeColor;
        //        //this.ForeColor = Color.Crimson;
        //        this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
        //        this.Cursor = Cursors.Hand;
        //    }
        //}

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    if (UseHightLight)
        //    {
        //        //this.ForeColor = _oldColor;
        //        this.Font = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold);
        //    }
        //}

        public void Clone(Control targetControl)
        {
            // make sure these are the same
            if (this.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (PropertyInfo sourceProperty in this.GetType().GetProperties())
            {
                object newValue = sourceProperty.GetValue(this, null);

                MethodInfo mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }
    }
}