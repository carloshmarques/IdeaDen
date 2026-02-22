using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HydraLife.Modules.UI
{
    public static class SmoothTransitions
    {
        // Fade suave do fundo para uma cor alvo
        public static async Task TriggerBackgroundFade(Form target, Color finalColor, int steps = 20, int delay = 50)
        {
            Color initialColor = target.BackColor;

            for (int i = 0; i <= steps; i++)
            {
                int r = initialColor.R + (finalColor.R - initialColor.R) * i / steps;
                int g = initialColor.G + (finalColor.G - initialColor.G) * i / steps;
                int b = initialColor.B + (finalColor.B - initialColor.B) * i / steps;

                target.BackColor = Color.FromArgb(r, g, b);
                await Task.Delay(delay);
            }
        }
    }
}
