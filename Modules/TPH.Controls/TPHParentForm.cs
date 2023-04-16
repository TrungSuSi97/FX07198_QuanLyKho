using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TPH.Controls
{
    public partial class TPHParentForm : TPHTemplateForm
    {      
        //Fields for button menu
        private IconButton _currentBtn;
        private readonly Panel _leftBorderBtn;
        private List<Form> _currentChildForm;
        protected bool AutoCollapseMenu { get; set; }
        private int pnMenuCollapseWidth = 60;
        private int pnMenuExpandWidth = 200;

        public readonly ToolTip _toolTipButton = new ToolTip();
        //Event for mneu
        public TPHParentForm()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            BackColor = CommonAppColors.ColorAppFormColor2;
            pnMenu.BackColor = CommonAppColors.ColorMainAppColor;
            pnMenu.TopColor = CommonAppColors.ColorMainAppColor;
            pnMenu.BottomColor = CommonAppColors.ColorMainAppColor;
            pnTPHLogo.BackColor = CommonAppColors.ColorMainAppFormColor;
            pnMainFooter.BackColor = CommonAppColors.ColorMainAppColor;
            pnMainFooter.TopColor = CommonAppColors.ColorBottomAppColor;
            pnMainFooter.BottomColor = CommonAppColors.ColorMainAppFormColor;
            pnMainHeader.BackColor = CommonAppColors.ColorMainAppColor;
            pnTabHeader.BackColor = pnMainHeader.BackColor;
            pnTabHeader.BorderStyle = BorderStyle.None;
            tabMain.Appearance = TabAppearance.FlatButtons;
            tabMain.ItemSize = new Size(0, 1);
            //tabMain.SizeMode = TabSizeMode.Fixed;
            
            _leftBorderBtn = new Panel {Size = new Size(7, 60)};
            pnMenuContent.Controls.Add(_leftBorderBtn);
            btnNext.BackColor = CommonAppColors.ColorButtonBackColor;
            btnPrevious.BackColor = CommonAppColors.ColorButtonBackColor;
            btnNext.ForeColor = CommonAppColors.ColorButtonForceColor;
            btnPrevious.ForeColor = CommonAppColors.ColorButtonForceColor;
            //if (AutoCollapseMenu)
            //    CollapseMenu();
            
        }
        #region Private methods

   
        //Private methods
        public void CollapseMenu()
        {
            if (this.pnMenu.Width >= pnMenuExpandWidth) //Collapse menu
            {
                pnMenu.Width = pnMenuCollapseWidth;
              //  btnMenu.Dock = DockStyle.Top;
                foreach (var menuButton in pnMenuContent.Controls.OfType<Button>())
                {
                    menuButton.Tag = menuButton.Text;
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    //menuButton.Padding = new Padding(5);
                }
            }
            else
            {
                //Expand menu
                pnMenu.Width = pnMenuExpandWidth;
                foreach (Button menuButton in pnMenuContent.Controls.OfType<Button>())
                {
                    if (menuButton.Tag == null)
                        continue;
                    menuButton.Text = menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    //menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
     
        //Create Button for tab
        public bool CloseChild(Form frm)
        {
            foreach (HeaderWithCloseButton header in pnTabHeader.Controls)
            {
                if (header.TabName.Replace("tab_", "").Equals(frm.Name))
                {
                    foreach (TabPage item in tabMain.TabPages)
                    {
                        if (item.Name.Equals(header.TabName))
                        {
                            if (CloseOpenForm(header.TabName.Replace("tab_", "")))
                            {
                                tabMain.TabPages.Remove(item);
                                pnTabHeader.Controls.Remove(header);
                                if (tabMain.TabPages.Count > 0)
                                    SetButtonSelectedColor(tabMain.SelectedTab.Name);
                                return true;
                            }
                            break;
                        }
                    }
                }
            }
            return false;
        }
        public void CloseForm(Form frmTemplate)
        {
            CloseChild(frmTemplate);
        }

        public void SetMainMenu(TPH.Controls.TPHDropdownMenuStrip menu)
        {
            menu.IsMainMenu = true;
            menu.PrimaryColor = CommonAppColors.MenuItemPrimaryColor;
            menu.MenuItemTextColor = CommonAppColors.MenuItemTextColor;
            menu.MenuItemTextSelectedColor = CommonAppColors.MenuItemTextSelectedColor;
            menu.MenuItemBackColor = CommonAppColors.MenuItemBackColor;
        }
        public void ShowMenu(Button btnm, TPHDropdownMenuStrip menu)
        {
            menu.Show(btnm, btnm.Location.X + btnm.Width / 2, btnm.Height);
        }
        public void ShowFormFromMenu(Button btnm, Form f)
        {
          //  ActivateButton(btnm);
            OpenChildForm(f);
        }
        private void CheckShowTabMoveHeader()
        {
            pnMoveTabHeader.Visible = (pnTabHeader.Width > pnMainHeader.Width);
        }
        private string GetTabName(string formname)
        {
            return string.Format("tab_{0}", formname);
        }

        private void CreateTabHeaderAndTabPage(Form newForm)
        {

            var header = new HeaderWithCloseButton();
            header.ButtonCloseClick += Header_ButtonCloseClick;
            header.TabName = GetTabName(newForm.Name);
            header.Height = pnMainHeader.Height;
            header.SetBackColor = CommonAppColors.ColorNormalPage;
            header.BorderStyle = BorderStyle.None;
            var tpage = new TabPage
            {
                Name = header.TabName,
                BackColor = newForm.BackColor,
                ForeColor = newForm.ForeColor,
                Font = newForm.Font,
                AutoSizeMode = AutoSizeMode.GrowOnly
            };
            newForm.AutoScaleMode = AutoScaleMode.Dpi;
            newForm.TopLevel = false;
            tpage.Controls.Add(newForm);
            tabMain.TabPages.Add(tpage);
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            newForm.Show();
            tabMain.SelectedTab = tpage;
            if (newForm.DialogResult != DialogResult.Cancel)
            {
                pnTabHeader.Controls.Add(header);
                HighDpiHelper.AdjustControlImagesDpiScale(header);
                header.BringToFront();
                header.Dock = DockStyle.Left;
                header.HeaderClick += Header_Click;
                header.CreateNewTitle(newForm.Text.ToUpper(), newForm.Name);
                pnTabHeader.Width += header.Width;
                CheckShowTabMoveHeader();
                CanhChinhPanelHeader(header);
            }
            else
            {
                tabMain.TabPages.Remove(tpage);
            }
        }

        private void Header_Click(object sender, EventArgs e)
        {
            var header = (HeaderWithCloseButton)sender;
            CheckShowTabPage(header.TabName.Replace("tab_", ""));
        }

        private void Header_ButtonCloseClick(object sender, EventArgs e)
        {
            var header = (HeaderWithCloseButton)sender;
            foreach (TabPage item in tabMain.TabPages)
            {
                if (item.Name.Equals(header.TabName))
                {
                    if (CloseOpenForm(header.TabName.Replace("tab_", "")))
                    {
                        tabMain.TabPages.Remove(item);
                        pnTabHeader.Controls.Remove(header);
                        pnTabHeader.Width -= header.Width;
                        if (pnTabHeader.Location.X < 0)
                        {
                            if (pnTabHeader.Location.X + header.Width > 0)
                                pnTabHeader.Location = new Point(0, pnTabHeader.Location.Y);
                            else
                                pnTabHeader.Location = new Point(pnTabHeader.Location.X + header.Width, pnTabHeader.Location.Y);
                        }
                        CheckShowTabMoveHeader();
                        if (tabMain.TabPages.Count > 0)
                            SetButtonSelectedColor(tabMain.SelectedTab.Name);
                    }
                    break;
                }
            }
        }
        private bool CloseOpenForm(string formName)
        {
            var f = _currentChildForm.Where(x => x.Name.Equals(formName)).First();
            f.Close();
            if (f.IsDisposed)
            {
                _currentChildForm.Remove(f);
                return true;
            }
            return false;
        }

        //Methods
        public void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                _currentBtn = (IconButton)senderBtn;
               
                _currentBtn.ForeColor = CommonAppColors.ColorTextSelected;
                _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                _currentBtn.IconColor = CommonAppColors.ColorTextSelected;
                _currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                _currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                _currentBtn.BackColor = CommonAppColors.ColorSelectedPage;
                ////Left border button
                //if (leftBorderBtn != null)
                //{
                //    leftBorderBtn.BackColor = CommonAppColors.colorSelectedPage;
                //    leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                //    leftBorderBtn.Height = currentBtn.Height;
                //    leftBorderBtn.Visible = true;
                //    leftBorderBtn.BringToFront();
                //}
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = _currentBtn.IconChar;
                iconCurrentChildForm.IconColor = CommonAppColors.ColorTextSelected;
            }
        }

        private void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.Empty;
                _currentBtn.ForeColor = CommonAppColors.ColorTextNormal;
                _currentBtn.IconColor = CommonAppColors.ColorTextNormal;
                _currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                if (this.pnMenu.Width >= pnMenuExpandWidth) //Is expanded
                {
                    _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                    _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                }
                else
                {
                    _currentBtn.ImageAlign = ContentAlignment.MiddleCenter;
                }
            }
        }
        private void CheckShowTabPage(string formname)
        {
            var tabname = GetTabName(formname);
            foreach (TabPage item in tabMain.TabPages)
            {
                if (item.Name.Equals(GetTabName(formname)))
                {
                    tabMain.SelectedTab = item;
                    break;
                }
            }
            SetButtonSelectedColor(tabname);
        }
        private void SetButtonSelectedColor(string tabname)
        {
            foreach (HeaderWithCloseButton item in pnTabHeader.Controls)
            {
                if (item.TabName.Equals(tabname))
                {
                    item.SetBackColor = CommonAppColors.ColorSelectedPage;
                    item.SetForeColor = CommonAppColors.ColorTextSelected;

                    CanhChinhPanelHeader(item);
                }
                else
                {
                    item.SetBackColor = CommonAppColors.ColorNormalPage;
                    item.SetForeColor = CommonAppColors.ColorTextNormal;
                }
            }
        }
        private void CanhChinhPanelHeader(HeaderWithCloseButton item)
        {
            if (pnTabHeader.Location.X < 0 && Math.Abs(pnTabHeader.Location.X) > item.Location.X)
            {
                var moveX = Math.Abs(pnTabHeader.Location.X) - item.Location.X;

                pnTabHeader.Location = new Point(pnTabHeader.Location.X + moveX, pnTabHeader.Location.Y);
            }
            else if ((pnTabHeader.Location.X + item.Location.X + item.Width) > pnMoveTabHeader.Location.X)
            {
                //vi trí dấu đóng
                var xbutton = pnMoveTabHeader.Location.X - 1;
                var xlocation = pnTabHeader.Width - xbutton;
                pnTabHeader.Location = new Point(-xlocation, pnTabHeader.Location.Y);
            }
        }
        private void OpenChildForm(Form childForm)
        {
            childForm.AutoScaleDimensions = new SizeF(96F, 96F);
            childForm.AutoScaleMode = AutoScaleMode.Dpi;

            if (_currentChildForm == null)
                _currentChildForm = new List<Form>();
            if (_currentChildForm.Any(x => x.Name.Equals(childForm.Name)))
            {
                CheckShowTabPage(childForm.Name);
            }
            else
            {
                CreateTabHeaderAndTabPage(childForm);
                _currentChildForm.Add(childForm);
                CheckShowTabPage(childForm.Name);
            }

            lblTitleChildForm.Text = childForm.Text;
        }
        public void Reset()
        {
            DisableButton();
            _leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "TRANG CHÍNH";
        }

        #endregion
        Size maxsize = new Size(0, 0);
        Size normalSize = new Size(0, 0);
        private bool isNormalSize = false;
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pnTabHeader.Location = pnTabHeader.Location.X <= -100
                ? new Point(pnTabHeader.Location.X + 100, pnTabHeader.Location.Y)
                : new Point(0, pnTabHeader.Location.Y);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pnTabHeader.Location.X + pnTabHeader.Width > pnMoveTabHeader.Location.X)
            {
                var calPosX = pnTabHeader.Location.X - 100;
                pnTabHeader.Location = pnTabHeader.Location.X >= -pnTabHeader.Width
                    ? new Point(((calPosX + pnTabHeader.Width) < pnMoveTabHeader.Location.X ? -(pnTabHeader.Width - pnMoveTabHeader.Location.X) : calPosX), pnTabHeader.Location.Y)
                    : new Point(0, pnTabHeader.Location.Y);
            }
        }

        private void pnTabHeader_MouseDown(object sender, MouseEventArgs e)
        {
            panelTitleBar_MouseDown(sender, e);
        }

        private void pnMoveTabHeader_SizeChanged(object sender, EventArgs e)
        {
            CheckShowTabMoveHeader();
        }

        private void TPHParrentForm_SizeChanged(object sender, EventArgs e)
        {
            CheckShowTabMoveHeader();
        }

        private void pnLogo_Click(object sender, EventArgs e)
        {
            //CollapseMenu();
        }
        private void pnMainHeader_DoubleClick(object sender, EventArgs e)
        {
            BtnMaximize_Click(sender, e);
        }

        private void TPHParentForm_Load(object sender, EventArgs e)
        {
            //if (!pnMenuContent.Controls.OfType<Button>().Any()) return;
            //foreach (var menuButton in pnMenuContent.Controls.OfType<Button>())
            //{
            //    //menuButton.Tag = menuButton.Text;
            //    _toolTipButton.SetToolTip(menuButton,
            //        menuButton.Tag.ToString());
            //}
        }
    }
}
