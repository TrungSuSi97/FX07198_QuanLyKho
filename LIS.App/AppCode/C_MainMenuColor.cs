using System.Drawing;
using System.Windows.Forms;

namespace TPH.LIS.App.AppCode
{
    class C_MainMenuColor : ProfessionalColorTable
    {

            public override Color ToolStripGradientBegin
            { get { return Color.BlueViolet; } }

            public override Color ToolStripGradientMiddle
            { get { return Color.CadetBlue; } }

            public override Color ToolStripGradientEnd
            { get { return Color.CornflowerBlue; } }

            public override Color MenuStripGradientBegin
            { get { return Color.Salmon; } }

            public override Color MenuStripGradientEnd
            { get { return Color.OrangeRed; } }
        
    }
}
