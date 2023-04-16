using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPH.Controls
{
    public partial class TPHDropdownMenuStrip : ContextMenuStrip
    {
        //Fields
        private Bitmap _menuItemHeaderSize;
        //Constructor
        public TPHDropdownMenuStrip(IContainer container)
        : base(container)
    {
        }
        //Properties
        //Optionally, hide the properties in the toolbox to avoid the problem of displaying and/or 
        //saving control property changes in the designer at design time in Visual Studio.
        //If the problem I mention does not occur you can expose the properties and manipulate them from the toolbox.
        [Browsable(false)]
        public bool IsMainMenu { private get; set; }

        [Browsable(false)]
        public int MenuItemHeight { private get; set; } = 25;

        [Browsable(false)]
        public Color MenuItemTextColor { private get; set; } = Color.Empty;

        [Browsable(false)]
        public Color PrimaryColor { private get; set; } = Color.Empty;

        [Browsable(false)]
        public Color MenuItemTextSelectedColor { private get; set; } = Color.Empty;

        [Browsable(false)]
        public Color MenuItemBackColor { private get; set; } = Color.Empty;

        //Private methods
        private void LoadMenuItemHeight()
        {
            _menuItemHeaderSize = IsMainMenu ? new Bitmap(25, 35) : new Bitmap(20, MenuItemHeight);

            foreach (var menuItemL in this.Items)
            {
                if (!(menuItemL is ToolStripMenuItem)) continue;

                var menuItemL1 = (ToolStripMenuItem)menuItemL;
                menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItemL1.Image == null) menuItemL1.Image = _menuItemHeaderSize;
                foreach (ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems)
                {
                    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItemL2.Image == null) menuItemL2.Image = _menuItemHeaderSize;
                    foreach (ToolStripMenuItem menuItemL3 in menuItemL2.DropDownItems)
                    {
                        menuItemL3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuItemL3.Image == null) menuItemL3.Image = _menuItemHeaderSize;
                        foreach (ToolStripMenuItem menuItemL4 in menuItemL3.DropDownItems)
                        {
                            menuItemL4.ImageScaling = ToolStripItemImageScaling.None;
                            if (menuItemL4.Image == null) menuItemL4.Image = _menuItemHeaderSize;
                            ///Level 5++
                        }
                    }
                }
            }
        }
        //Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode) return;
            this.Renderer = new MenuRenderer(IsMainMenu, PrimaryColor, MenuItemTextColor, MenuItemTextSelectedColor,
                MenuItemBackColor);
            LoadMenuItemHeight();
        }
    }
}
