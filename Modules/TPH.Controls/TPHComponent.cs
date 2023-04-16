using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TPH.Controls
{
    public class TPHDragControl : Component
    {
        private Control childControl;

        private Form parrentForm;

        [Category("TPH CustomControl")]
        public Control gdfg
        {
            get
            {
                return childControl;
            }
            set
            {
                childControl = value;
                if (childControl != null)
                {
                    childControl.HandleCreated += abd;
                    childControl.MouseDown += cmd;
                }
            }
        }

        public TPHDragControl()
        {
        }

        public TPHDragControl(IContainer container)
        {
            container.Add(this);
        }

        public TPHDragControl(Control _dragControl, Form _targetForm)
        {
            parrentForm = _targetForm;
            childControl = _dragControl;
            childControl.MouseDown += cmd;
        }

        public TPHDragControl(Control _dragControl, Form _targetForm, IContainer container)
        {
            container.Add(this);
            parrentForm = _targetForm;
            childControl = _dragControl;
            childControl.MouseDown += cmd;
        }

        [DllImport("user32.DLL")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void abd(object sender, EventArgs e)
        {
            if (!base.DesignMode)
            {
                parrentForm = childControl.FindForm();
            }
        }

        private void cmd(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(parrentForm.Handle, 274, 61458, 0);
        }
    }
}
