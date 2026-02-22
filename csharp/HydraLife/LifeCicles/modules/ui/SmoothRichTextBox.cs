// Usings mínimos para RichTextBox
using System.Windows.Forms;

namespace HydraLife.LifeCicles.Modules.UI
{
    public class SmoothRichTextBox : RichTextBox
    {
        public SmoothRichTextBox()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
